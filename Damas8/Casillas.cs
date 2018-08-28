using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Damas8
{
    public static class Casillas
    {
        //private static System.Media.SoundPlayer sonido = new System.Media.SoundPlayer("./Resources/correbb.wav");
        //private static Bitmap imagenB = new Bitmap("./Resources/dama40b.png");
        //private static Bitmap imagenN = new Bitmap("./Resources/dama40n.png");
        private static System.Media.SoundPlayer sonido = new System.Media.SoundPlayer("../../correbb.wav");
        private static Bitmap imagenB = new Bitmap("../../dama40b.png");
        private static Bitmap imagenN = new Bitmap("../../dama40n.png");
        //private static Image imagenB = Image.FromFile("../../Resources/dama40b.png");
        //private static Image imagenN = Image.FromFile("../../Resources/dama40n.png");
        public const int MAXC = 10;
        public const int MINC = 5;

        public static Bitmap ImagenB => imagenB;
        public static Bitmap ImagenN => imagenN;
        public static void Sonido() { sonido.Play(); }
    }
}
