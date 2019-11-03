using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ajedrezForm.clases;

namespace ajedrezForm
{
 // ********************** probando github 
 
    public partial class Form1 : Form
    {
        Tablero tbr = new Tablero();
        //public static Piezas[,] piezas = new Piezas[8,8];
        public  Piezas[,] piezas = new Piezas[8, 8];
        public Button lastButton;
    
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            crearTablero();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void crearTablero()
        {
            Size _size = new Size(panel1.Width / 8, panel1.Height / 8);
            Point p;
            for (int f = 0; f < 8; f++)
                for (int c = 0; c < 8; c++)
                {
                    p = new Point(f, c);
                    //tbr.inicializarTablero(); //OBSOLETO
                    var csl = new Casilla();
                    csl.Pieza = Tablero.nuevaPieza[f,c]; 
                    csl.Size = _size;
                    csl.Pos = p;
                    csl.Location = new Point(c * _size.Width, f * _size.Height);
                    csl.Clr = (c + f) % 2 == 0 ? Color.Gray : Color.White;
                    csl.BackColor = csl.Clr;

                    csl.Click += new EventHandler(this.button_Click);
                    panel1.Controls.Add(csl);
                    

                    if (Tablero.nuevaPieza[f, c] != null)
                    {
                        csl.Name = Tablero.nuevaPieza[f, c].Color;
                        csl.BackgroundImage = Tablero.nuevaPieza[f, c].Img;
                        csl.BackgroundImageLayout = ImageLayout.Zoom;
                    }
                    
                }
        }

        private void button_Click(object sender, EventArgs e)
        {
            Casilla csl = (Casilla)sender;
            Size _size = new Size(panel1.Width / 8, panel1.Height / 8);
            
            MessageBox.Show(Tablero.nuevaPieza[csl.Location.Y / _size.Height, csl.Location.X / _size.Width].Nombre);
            //MessageBox.Show(Tablero.nuevaPieza[btn.Location.Y / _size.Height, btn.Location.X / _size.Width].GetType().ToString().Substring(12));
            for (int x = 0; x < 8; x++)
                for (int y = 0; y < 8; y++)
                {
                    //if (btn.Location.Equals(piezas[f,c].))
                }
            int f = 1;
            int c = 2;
            panel1.Controls[8*f+c].BackColor = Color.Aqua;
              if (lastButton !=null && lastButton.BackgroundImage != null && !(csl.Name.Equals(lastButton.Name, StringComparison.InvariantCultureIgnoreCase)))
                {
                    csl.BackgroundImage = lastButton.BackgroundImage;
                    csl.BackgroundImageLayout = ImageLayout.Zoom;
                    csl.Name = lastButton.Name;
                    lastButton.BackgroundImage = null;
                    lastButton.Name = null;
                    lastButton = null;
                    this.Cursor = Cursors.Default;

                
            }
            else
            {
                if(csl.BackgroundImage != null)
                {
                    this.Cursor = CreateCursor((Bitmap)csl.BackgroundImage, new Size(50, 50));
                }

                List<Point> list_p = new List<Point>();
                Casilla cs = (Casilla)panel1.Controls[8 * csl.Pos.X + csl.Pos.Y];
                list_p = cs.Pieza.Movimientos();

                foreach (Point p in list_p)
                {
                    panel1.Controls[8 * f + c].BackColor = Color.Aqua;
                }
                lastButton = csl;               
            }    
        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }


        public static Cursor CreateCursor (Bitmap bm, Size size)
        {
            bm = new Bitmap(bm, size);
            bm.MakeTransparent();
            return new Cursor(bm.GetHicon());
        }
    }
}
