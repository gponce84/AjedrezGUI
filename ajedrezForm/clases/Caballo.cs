using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ajedrezForm
{
    
    class Caballo : Piezas
    {
       

        public Caballo(string color)
            :base (color)
         {
            retornarPiezaColor(color);
         }


        public Bitmap retornarPiezaColor(String color)
        {
            if(color == "B")
            {
                return this.Img = Properties.Resources.CaballoB;
            }
            else
            {
                return this.Img = Properties.Resources.CaballoN;

            }
        }

        public void movimientos()
        {
            Moves = new Point[]
             {
                new Point(-1,-2),
                new Point( 1,-2),

                new Point(-1, 2),
                new Point( 1, 2),

                new Point( 2,-1),
                new Point( 2, 1),

                new Point(-2,-1),
                new Point(-2, 1),
             };


        }


        /*
        public  void posicionInicial()
        {
            throw new NotImplementedException();
        }

        public  void posicionesPosiblres()
        {
            throw new NotImplementedException();
        }*/
    }
}
