using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Damas8Completar;

namespace Damas8
{
    public partial class Tamanyo : Form
    {
        public Tamanyo()
        {
            InitializeComponent();
            Topes();
        }

        private void Boton1Click(object sender, EventArgs e)
        {
            int valor = Casillas.MINC;

            valor = (int)numericUpDown1.Value;
            Hide();
            BuscarSoluciones(valor);
            Show();
        }

        private void Topes()
        {
            numericUpDown1.Maximum = Casillas.MAXC;
            numericUpDown1.Value = numericUpDown1.Minimum = Casillas.MINC;
            label2.Text = String.Format("Entre {0, 2} y {1, 2} casillas:", Casillas.MINC, Casillas.MAXC);
        }

        private void BuscarSoluciones(int valor)
        {
            //Tablero tablero = new Tablero(valor);
            Colocar tablero = new Colocar(valor);

            tablero.ShowDialog();
        }
    }
}
