using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Damas8;

namespace Damas8Completar
{
    public partial class Colocar : FAncho
    {
        private int situadas = 0, maximas;
        protected int[] vector;

        public Colocar(int dato = Casillas.MINC) : base(dato)
        {
            InitializeComponent();
            Ajustar2();
        }

        private void Ajustar2()
        {
            int indice;

            maximas = 1 + casillas / 8;
            label66.Text = String.Format("Y como máximo {0,2} Dama(s).", maximas);
            button1.Enabled = false;
            vector = new int[casillas];
            for (indice = 0; indice < casillas; ++indice) { vector[indice] = -1; }
            Ajustar();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Version version = new Version(vector);

            Hide();
            version.ShowDialog();
            Close();
        }

        protected override void Casilla_click(object sender, EventArgs e)
        {
            int col, fila;
            Label label = (Label)sender;
           
            col = label.Location.X / label.Width;
            fila = label.Location.Y / label.Height;
            if(label.Image != null)
            {
                --situadas;
                label.Image = null;
                if (situadas == 0) { button1.Enabled = false; }
                vector[col] = -1;
            }
            else
            {
                if ((situadas < maximas) && OKparcial(col, fila))
                {
                    ++situadas;
                    label.Image = ((col + fila) % 2 == 0 ? Casillas.ImagenN : Casillas.ImagenB);
                    if(situadas == 1) { button1.Enabled = true; }
                    vector[col] = fila;
                }
                else { Casillas.Sonido(); }
            }
        }

        private Boolean OKparcial(int col, int fila)
        {
            if (vector[col] != -1) { return false; }
            if(!OKfila(fila)) { return false; }
            if(!OKsuma(col, fila)) { return false; }
            if(!OKresta(col, fila)) { return false; }

            return true;
        }

        private Boolean OKfila(int fila)
        {
            int inicio;

            for (inicio = 0; inicio < casillas; ++inicio) { if (vector[inicio] == fila) { return false; } }

            return true;
        }

        private Boolean OKsuma(int col, int fila)
        {
            int indice;

            for (indice = 0; indice < casillas; ++indice)
            {
                if ((vector[indice] != -1) && ((vector[indice] + indice) == (fila + col)))
                {
                    return false;
                }
            }

            return true;
        }

        private Boolean OKresta(int col, int fila)
        {
            int indice;

            for (indice = 0; indice < casillas; ++indice)
            {
                if ((vector[indice] != -1) && ((vector[indice] - indice) == (fila - col)))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
