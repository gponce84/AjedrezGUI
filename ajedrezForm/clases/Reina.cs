using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ajedrezForm
{
    class Reina : Piezas
    {
        public Reina(string color)
            : base(color)
        {
            retornarPiezaColor(color);

        }
        public Bitmap retornarPiezaColor(String color)
        {
            if (color == "B")
            {
                return this.Img = Properties.Resources.ReinaB;
            }
            else
            {
                return this.Img = Properties.Resources.ReinaN;

            }
        }

        public void movimientos()
        {
            Moves = new Point[]
           {
                new Point( 0, 1 ),
                new Point( 0,-1 ),
                new Point( 1, 0 ),
                new Point(-1, 0 ),
                new Point( 1, 1 ),
                new Point(-1, 1 ),
                new Point( 1,-1 ),
                new Point(-1,-1 ),
           };
        }
    }
}
