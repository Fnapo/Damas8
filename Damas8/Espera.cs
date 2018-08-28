using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Damas8
{
    public partial class Espera : Form
    {
        private static bool seguir;

        public Espera()
        {
            InitializeComponent();
        }

        public static bool Seguir { get => seguir; }

        private void Espera_FormClosed(object sender, FormClosedEventArgs e)
        {
            seguir = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            seguir = true;
            Hide();
        }
    }
}
