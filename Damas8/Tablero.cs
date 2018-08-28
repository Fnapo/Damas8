using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Damas8Completar;

namespace Damas8
{
    public partial class Tablero : FAncho
    {
        public Tablero() : base()
        {
            InitializeComponent();
            Ajustar();
            label66.Visible = false;
            label67.Visible = false;
        }

        public Tablero(int dato = Casillas.MINC) : base(dato)
        {
            InitializeComponent();
            Ajustar();
            label66.Visible = false;
            label67.Visible = false;
        }

        protected void BuscarSoluciones()
        {
            int dama, soluciones = 0, inicial;
            int[] filas = new int[casillas];
            bool seguir = true;

            label67.Text = String.Format("Soluciones encontradas: {0, 5}.", soluciones);
            inicial = dama = Preparar(ref filas); //Obtengo la primera Dama no fija.
            while(filas[inicial] < casillas && seguir)
            {
                SubirFila(ref dama, ref filas); //Intento subir una fila la dama.
                while((filas[dama] >= casillas) && (dama != inicial)) //Al salirse del tablero retrocedo una dama ... o más.
                {
                    BajarDama(ref dama, ref filas);
                }
                if(Correcta(dama, filas)) //Si la posición es correcta añado una dama o he econtrado una solución.
                {
                    if (dama < casillas - 1) //Añado otra dama.
                    {
                        SubirDama(ref dama, ref filas);
                    }
                    else //He encontrado una solución.   
                    {
                        BorrarTablero();
                        ++soluciones;
                        label67.Text = String.Format("Soluciones encontradas: {0, 5}.", soluciones);                        
                        PintarSolucion(filas);
                        seguir = Parar();
                        BajarDama(ref dama, ref filas); //Bajo una dama por si la última es fija.
                    }
                }
            }
            label66.Text = "Fin ... Cierra la ventana para continuar.";

            //return soluciones;
        }

        protected virtual int Preparar(ref int[] fila)
        {
            int indice;

            for (indice = 0; indice < casillas; ++indice) { fila[indice] = -1; }

            return 0;
        }

        //protected virtual int Final() { return casillas - 1; }

        protected virtual void SubirFila(ref int dama, ref int[] filas) { ++filas[dama]; }

        protected virtual void BajarDama(ref int dama, ref int[] filas)
        {
            --dama;
            ++filas[dama];
        }

        protected virtual void SubirDama(ref int dama, ref int[] filas)
        {
            ++dama;
            filas[dama] = -1;
        }

        protected virtual bool Parar()
        {
            Espera espera = new Espera();
            bool seguir;

            espera.ShowDialog();
            seguir = Espera.Seguir;

            return seguir;
        }

        protected bool Correcta(int dama, int []fila)
        {
            if(!FilaCorrecta(dama, fila)) { return false; }
            if(!DiagonalBajada(dama, fila)) { return false; }
            if (!DiagonalSubida(dama, fila)) { return false; }

            return true;
        }

        private bool FilaCorrecta(int dama, int []fila)
        {
            int indice;

            for (indice = 0; indice < dama; ++indice) { if (fila[indice] == fila[dama]) { return false; } }

            return true;
        }

        private bool DiagonalSubida(int dama, int[] fila)
        {
            int indice;

            for(indice = 0; indice < dama;  ++ indice) { if ((fila[indice] + indice) == (fila[dama] + dama)) { return false; } }

            return true;
        }

        private bool DiagonalBajada(int dama, int[] fila)
        {
            int indice;

            for (indice = 0; indice < dama; ++indice) { if ((fila[indice] - indice) == (fila[dama] - dama)) { return false; } }

            return true;
        }

        private void PintarSolucion(int []fila)
        {
            int indice;
            Label control;

            for (indice = 0; indice < casillas; ++indice)
            {
                control = (Label)tableLayoutPanel1.GetControlFromPosition(indice, fila[indice]);
                control.Image = ((indice + fila[indice]) % 2 == 0 ? Casillas.ImagenN : Casillas.ImagenB);
            }
            Update();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            label65.Visible = false;
            label66.Visible = true;
            label67.Visible = true;
            button1.Visible = false;
            Update();
            BuscarSoluciones();
        }

        protected virtual void BorrarTablero()
        {
            int indice, ifil;
            Label label;

            for (indice = 0; indice < casillas; ++indice)
            {
                for(ifil = 0; ifil < casillas; ++ifil)
                {
                    label = (Label)tableLayoutPanel1.GetControlFromPosition(indice, ifil);
                    label.Image = null;
                }
            }
            Update();
        }
    }
}
