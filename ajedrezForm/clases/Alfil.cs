using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ajedrezForm
{
    class Alfil : Piezas
    {
        public Alfil(string color)
            :base(color)
        {
            retornarPiezaColor(color);
        }

        public Bitmap retornarPiezaColor(String color)
        {
            if (color == "B")
            {
                return this.Img = Properties.Resources.AlfilB;
            }
            else
            {
                return this.Img = Properties.Resources.AlfilN;

            }
        }

        public void movimientos()
        {
            Moves = new Point[]
           {
                new Point( 1, 1 ),
                new Point(-1, 1 ),
                new Point( 1,-1 ),
                new Point(-1,-1 ),
           };
          

        }
      

    }
}
