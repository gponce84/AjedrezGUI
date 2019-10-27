using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ajedrezForm
{

    public class Piezas
    {
        private string nombre;
        private string color;
        private Point posicionPieza{ get; set; }
       
        public String[,] movimeintoPermitido { get; set; }
        public Point [] Moves { get; set; }
        private Bitmap img;
        

        public Piezas(string nombre, string color, Point posicionPieza)
        {
            this.nombre = nombre;
            this.color = color;
            this.posicionPieza = posicionPieza;
            
        }


        public void imagenPieza()
        {
            
        }
        public  void posicionInicial()
        {

        }

        public  void posicionesPosiblres()
        {

        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Color
        {
            get
            {
                return color;
            }

            set
            {
                color = value;
            }
        }

        public Bitmap Img
        {
            get
            {
                return img;
            }

            set
            {
                img = value;
            }
        }




    }
}
