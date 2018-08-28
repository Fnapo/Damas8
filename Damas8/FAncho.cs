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

    public partial class FAncho : Form
    {
        protected int casillas;

        public FAncho()
        {
            InitializeComponent();
            casillas = Casillas.MINC;
            Ajustar();
        }

        public FAncho(int dato = Casillas.MINC)
        {
            InitializeComponent();
            if(dato < Casillas.MINC) { dato = Casillas.MINC; }
            if (dato > Casillas.MAXC) { dato = Casillas.MAXC; }
            casillas = dato;
            Ajustar();
        }

        protected void Ajustar()
        {
            tableLayoutPanel1.Width = tableLayoutPanel1.Height = label1.Width * casillas;
            tableLayoutPanel1.Location = new Point((Width - label1.Width * casillas) / 2, 130);
            Height = 130 + label1.Width * casillas + 100;
        }

        protected virtual void Casilla_click(object sender, EventArgs e)
        {

        }
    }
}
