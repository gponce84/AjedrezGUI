using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ajedrezForm
{
    class Peon : Piezas
    {
        private Boolean primerMovimiento;

        public Peon(string color)
            :base(color)
        {
            primerMovimiento = false;
            retornarPiezaColor(color);

        }

        public Bitmap retornarPiezaColor(String color)
        {
            if (color == "B")
            {
                return this.Img = Properties.Resources.PeonB;
            }
            else
            {
                return this.Img = Properties.Resources.PeonN;

            }
        }

        public void movimientos()
        {
            Moves = new Point[]
            {
                new Point( 0 -1 ), // al frente solo puede mover, no atacar
                new Point( 0,-2 ), // al frente 2 casilleros solo puede mover, no atacar y se puede realizar si es el primer movimiento del peon
                new Point(-1,-1 ), // en diagonal solo puede atacar, no mover
                new Point( 1,-1 ), // en diagonal solo puede atacar, no mover
            };
        }

        public void mover(int posicionX, int posicionY)
        {

        }

        public void pisicionInicial()
        {

        }
    }
}
