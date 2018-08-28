using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Damas8;

namespace Damas8Completar
{
    public partial class Version : Damas8.Tablero
    {
        protected int[] fijas;

        //public Version(int[] sitas) : base()
        //{
        //    InitializeComponent();
        //    Inicio(sitas);
        //}

        public Version(int[] sitas/*, int dato=Casillas.MINC*/) : base(sitas.Length)
        {
            InitializeComponent();
            if(sitas.Length != casillas) { Close(); }
            Inicio(sitas);
        }

        private void Inicio(int[] sitas)
        {
            fijas = sitas;
            Ajustar();
            PintarFijas();
        }

        protected override int Preparar(ref int[] fila)
        {
            int indice, salida = -1;

            for (indice = 0; indice < casillas; ++indice)
            {
                fila[indice] = fijas[indice];
                if ((fijas[indice] == -1) && (salida == -1))
                    salida = indice; //Primera dama no fija.
            }

            return salida;
        }

        private void PintarFijas()
        {
            int indice;
            Label control;

            for (indice = 0; indice < casillas; ++indice)
            {
                if (fijas[indice] != -1)
                {
                    control = (Label)tableLayoutPanel1.GetControlFromPosition(indice, fijas[indice]);
                    control.Image = ((indice + fijas[indice]) % 2 == 0 ? Casillas.ImagenN : Casillas.ImagenB);
                }
            }
            Update();
        }

        //protected override int Final()
        //{
        //    int indice, salida = 0;

        //    for (indice = 0; indice < casillas; ++indice) { if(fijas[indice] == -1) { salida = indice; } }

        //    return salida;
        //}

        protected override void SubirFila(ref int dama, ref int[] filas)
        {
            if (fijas[dama] == -1) //No es fija.
                ++filas[dama];
            else
            {
                if(!Correcta(dama, filas)) //Posición no correcta.
                {
                    while (fijas[dama] != -1) { --dama; }
                    ++filas[dama];
                }
            }
        }

        protected override void BajarDama(ref int dama, ref int[] filas)
        {
            do
                --dama;
            while (fijas[dama] != -1);
            ++filas[dama];
        }

        protected override void SubirDama(ref int dama, ref int[] filas)
        {
            ++dama;
            if (fijas[dama] == -1) //Si no es fija inicio filas.
                filas[dama] = -1;
       
        }

        protected override void BorrarTablero()
        {
            //int indice, ifil;
            //Label label;

            //for (indice = 0; indice < casillas; ++indice)
            //{
            //    for (ifil = 0; ifil < casillas; ++ifil)
            //    {
            //        label = (Label)tableLayoutPanel1.GetControlFromPosition(indice, ifil);
            //        label.Image = null;
            //    }
            //}
            base.BorrarTablero();
            PintarFijas();
            Update();
        }
    }
}
