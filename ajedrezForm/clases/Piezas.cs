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
        private Point posicionPieza{ get; set; }//OBSOLETO
       
        public String[,] movimeintoPermitido { get; set; }//OBSOLETO
        public Point [] Moves { get; set; }
        private Bitmap img;
        

        public Piezas(string color)
        {
            this.Nombre = this.GetType().Name;
            this.color = color;
            //this.posicionPieza = posicionPieza; //OBSOLETO
            
        }


        public void imagenPieza()
        {
            
        }
        public  void posicionInicial()
        {

        }

        public virtual List<Point> Movimientos()
        {
            List<Point> lp = new List<Point>(); 
            return lp;
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
