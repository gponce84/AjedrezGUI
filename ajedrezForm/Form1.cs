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
    
    public partial class Form1 : Form
    {
        Tablero tbr = new Tablero();
        public Piezas[,] piezas = new Piezas[8, 8];
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
            for (int f = 0; f < 8; f++)
                for (int c = 0; c < 8; c++)
                {
                    tbr.inicializarTablero(piezas);
                    var btn = new Button(); 
                    btn.Size = _size;
                    
                    btn.Location = new Point(c * _size.Width, f * _size.Height);
                    btn.BackColor = (c + f) % 2 == 0 ? Color.Gray : Color.White;
                   
                    btn.Click += new EventHandler(this.button_Click);
                    panel1.Controls.Add(btn);
                    

                    if (piezas[f, c] != null)
                    {
                        btn.Name = piezas[f, c].Color;
                        btn.BackgroundImage = piezas[f, c].Img;
                        btn.BackgroundImageLayout = ImageLayout.Zoom;
                    }
                    
                }
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            for (int f = 0; f < 8; f++)
                for (int c = 0; c < 8; c++)
                {
                    //if (btn.Location.Equals(piezas[f,c].))
                }


              if (lastButton !=null && lastButton.BackgroundImage != null && !(btn.Name.Equals(lastButton.Name, StringComparison.InvariantCultureIgnoreCase)))
                {
                    btn.BackgroundImage = lastButton.BackgroundImage;
                    btn.BackgroundImageLayout = ImageLayout.Zoom;
                    btn.Name = lastButton.Name;
                    lastButton.BackgroundImage = null;
                    lastButton.Name = null;
                    lastButton = null;
                    this.Cursor = Cursors.Default;
            }
            else {
                   if(btn.BackgroundImage != null)
                   {
                    this.Cursor = CreateCursor((Bitmap)btn.BackgroundImage, new Size(50, 50));
                    }
                     lastButton = btn;
               
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
