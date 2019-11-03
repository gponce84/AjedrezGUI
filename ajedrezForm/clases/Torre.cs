using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ajedrezForm
{
    class Torre  : Piezas
    {
        public Torre(string color)
            :base(color)
        {
            retornarPiezaColor(color);
            this.Nombre = this.GetType().Name;
        }

        public Bitmap retornarPiezaColor(String color)
        {
            if (color == "B")
            {
                return this.Img = Properties.Resources.TorreB;
            }
            else
            {
                return this.Img = Properties.Resources.TorreN;
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
            };

        }
    }
}
