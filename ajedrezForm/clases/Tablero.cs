using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ajedrezForm
{
    class Tablero
    {
        public void inicializarTablero( Piezas[,] nuevaPieza)
        {
            for (int c = 0 ; c < 8; c++)
            {
                nuevaPieza[ 1 , c ] = new Peon("P","B",new Point (1,c));
                nuevaPieza[ 6 , c ] = new Peon("P","N", new Point(6, c));  
            }

            nuevaPieza[0, 0] = new Torre("T", "B", new Point(0, 0));
            nuevaPieza[0, 7] = new Torre("T", "B", new Point(1, 7));
            nuevaPieza[7, 0] = new Torre("T", "N", new Point(7, 0));
            nuevaPieza[7, 7] = new Torre("T", "N", new Point(7, 7));

            nuevaPieza[0, 1] = new Caballo("C", "B", new Point(0, 1));
            nuevaPieza[0, 6] = new Caballo("C", "B", new Point(1, 6));
            nuevaPieza[7, 1] = new Caballo("C", "N", new Point(7, 1));
            nuevaPieza[7, 6] = new Caballo("C", "N", new Point(7, 6));

            nuevaPieza[0, 2] = new Alfil("A", "B", new Point(0, 2));
            nuevaPieza[0, 5] = new Alfil("A", "B", new Point(0, 5));
            nuevaPieza[7, 2] = new Alfil("A", "N", new Point(7, 2));
            nuevaPieza[7, 5] = new Alfil("A", "N", new Point(7, 5));

            nuevaPieza[0, 3] = new Rey("Rey", "B", new Point(0, 3));
            nuevaPieza[7, 3] = new Rey("Rey", "N", new Point(7, 3));

            nuevaPieza[0, 4] = new Reina("Rei", "B", new Point(0, 4));
            nuevaPieza[7, 4] = new Reina("Rei", "N", new Point(7, 4));

            
        }    
  }
}
