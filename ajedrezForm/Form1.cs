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

 
    public partial class Form1 : Form
    {
        Tablero tbr = new Tablero();
        public Piezas[,] piezas = new Piezas[8, 8];
        public Casilla lastButton;
        string turno = "B";

        public Form1()
        {
            InitializeComponent();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            crearTablero();
            Form2 frm2 = new Form2(panel1.Width / 8, panel1.Height / 8, this.Location.X, this.Location.Y, '-');
            Form2 frm3 = new Form2(panel1.Width / 8, panel1.Height / 8, this.Location.X, this.Location.Y, '+');
            this.AddOwnedForm(frm2);
            this.AddOwnedForm(frm3);
            frm2.Show();
            frm3.Show();
            this.Text = "Turno Blancas";
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
                        csl.BackgroundImage = Tablero.nuevaPieza[f, c].Img;
                        csl.BackgroundImageLayout = ImageLayout.Zoom;
                    }
                }
        }

        private void button_Click(object sender, EventArgs e)
        {
            Casilla csl = (Casilla)sender;
            Size _size = new Size(panel1.Width / 8, panel1.Height / 8);
            List<Point> list_p = new List<Point>();
            int ctrl_i = 8 * csl.Pos.X + csl.Pos.Y;
            if(lastButton != null && csl.BackgroundImage == lastButton.BackgroundImage)
            {
                this.Cursor = Cursors.Default;
                Limpiar_Colores();
                lastButton = null;
            }
            else if (lastButton !=null && lastButton.BackgroundImage != null && csl.Pieza != lastButton.Pieza &&
                csl.BackColor == Color.FromArgb(60,0, 0, 255)/* && !(csl.Pieza.Nombre.Equals(lastButton.Pieza.Nombre, StringComparison.InvariantCultureIgnoreCase))*/)
            {
                switch (csl.Pieza.Color)
                {
                    case "B":
                        ((Form2)(OwnedForms[0])).Eliminar_Pieza(csl.BackgroundImage);
                        break;
                    case "N":
                        ((Form2)(OwnedForms[1])).Eliminar_Pieza(csl.BackgroundImage);
                        break;
                }
                if ( csl.Pieza.Nombre == "Rey" && csl.Pieza.Color != lastButton.Pieza.Color )
                {
                    if(csl.Pieza.Color == "B")
                    {
                        MessageBox.Show("Ganan Negras");
                        Application.Exit();
                    }
                    else if(csl.Pieza.Color == "N")
                    {
                        MessageBox.Show("Ganan Blancas");
                        Application.Exit();
                    }
                }                
                int lb_i = 8 * lastButton.Pos.X + lastButton.Pos.Y;
                Piezas pn = new Piezas("V");
                csl.BackgroundImage = lastButton.BackgroundImage;
                csl.Pieza.Color = lastButton.Pieza.Color;
                csl.BackgroundImageLayout = ImageLayout.Zoom;
                csl.Pieza.Nombre = lastButton.Pieza.Nombre;
                csl.Pieza = lastButton.Pieza;
                ((Casilla)panel1.Controls[lb_i]).Pieza = pn;
                lastButton.BackgroundImage = null;
                lastButton.Name = null;
                lastButton = null;
                
                Limpiar_Colores();

                this.Cursor = Cursors.Default;
                if (turno == "B")
                {
                    this.Text = "Turno Negras";
                    turno = "N";
                }                   
                else
                {
                    this.Text = "Turno Blancas";
                    turno = "B";
                }                  
            }
            else if( (Cursor == Cursors.Default || csl.Pieza.Color == lastButton.Pieza.Color)&&
                    turno == csl.Pieza.Color)
            {

                if (csl.BackgroundImage != null)
                    this.Cursor = CreateCursor((Bitmap)csl.BackgroundImage, new Size(50, 50));
                if(lastButton != null)
                    if (csl.Pieza.Color == lastButton.Pieza.Color && csl.Pieza != lastButton.Pieza)
                        Limpiar_Colores();
                    


                list_p = csl.Pieza.Movimientos(csl.Pos);
                Pintar_MovimientosV2(list_p, csl);                
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

        public void Limpiar_Colores()
        {
            foreach (Casilla cs in panel1.Controls)
            {
                int cs_i = 8 * cs.Pos.X + cs.Pos.Y;
                if (cs.BackColor == Color.FromArgb(60,0, 0, 255))
                    panel1.Controls[cs_i].BackColor = cs.Clr;
            }
        }

        public void Pintar_MovimientosV2(List<Point> list_p, Casilla csl)
        {
            Point u = new Point(0, csl.Pos.Y);
            Point ur = new Point(0, 20);
            Point r = new Point(csl.Pos.X, 7);
            Point dr = new Point(7, 7);
            Point d = new Point(7, csl.Pos.Y);
            Point dl = new Point(20, 0);
            Point l = new Point(csl.Pos.X, 0);
            Point ul = new Point(0, 0);

            foreach (Point p in list_p)
            {
                int ctrl_i = 8 * p.X + p.Y;
                Casilla cp = ((Casilla)panel1.Controls[ctrl_i]);
                if (csl.Pieza.Nombre == "Peon")
                {
                    ur = new Point(csl.Pos.X, csl.Pos.Y); dr = new Point(csl.Pos.X, csl.Pos.Y);
                    ul = new Point(csl.Pos.X, csl.Pos.Y); dl = new Point(csl.Pos.X, csl.Pos.Y);
                    if (cp.Pos.Y != csl.Pos.Y && cp.Pieza.Nombre != "Piezas")
                        Pintar_Casilla(ctrl_i, csl);
                    else if (cp.Pieza.Nombre != "Piezas")
                    {
                        u.X = csl.Pos.X; d.X = csl.Pos.X;
                    }
                }
                if (cp.Pieza.Nombre != "Piezas")
                {

                    if (cp.Pos.Y > csl.Pos.Y)
                    {
                        if (cp.Pos.X == csl.Pos.X && p.Y < r.Y)
                            r.Y = p.Y;
                        else if (cp.Pos.X < csl.Pos.X && cp.Pos.X > ur.X && p.Y < ur.Y)
                            ur = p;
                        else if (cp.Pos.X > csl.Pos.X && cp.Pos.X < dr.X && p.Y < dr.Y)
                            dr = p;
                    }
                    else if (cp.Pos.Y < csl.Pos.Y)
                    {
                        if (cp.Pos.X == csl.Pos.X && p.Y > l.Y)
                            l = p;
                        else if (cp.Pos.X < csl.Pos.X && cp.Pos.X > ul.X && p.Y > ul.Y)
                            ul = p;
                        else if (cp.Pos.X > csl.Pos.X && cp.Pos.X < dl.X && p.Y > dl.Y)
                            dl = p;
                    }
                    else if (cp.Pos.X < csl.Pos.X && p.X > u.X)
                        u = p;
                    else if (cp.Pos.X > csl.Pos.X && p.X < d.X)
                        d = p;
                }
                if (cp.Pos.Y > csl.Pos.Y)
                {
                    if (cp.Pos.X == csl.Pos.X && p.Y <= r.Y)
                        Pintar_Casilla(ctrl_i, csl);
                    else if (cp.Pos.X < csl.Pos.X && (p.X + p.Y != ur.X + ur.Y || p == ur || ur.X + ur.Y == 20))
                        Pintar_Casilla(ctrl_i, csl);
                    else if (cp.Pos.X > csl.Pos.X && (p.X - p.Y != dr.X - dr.Y || p == dr || dr.X + dr.Y == 14))
                        Pintar_Casilla(ctrl_i, csl);
                }
                else if (cp.Pos.Y < csl.Pos.Y)
                {
                    if (cp.Pos.X == csl.Pos.X && p.Y >= l.Y)
                        Pintar_Casilla(ctrl_i, csl);
                    else if (cp.Pos.X < csl.Pos.X && (p.X - p.Y != ul.X - ul.Y || p == ul || ul.X + ul.Y == 0))
                        Pintar_Casilla(ctrl_i, csl);
                    else if (cp.Pos.X > csl.Pos.X && (p.X + p.Y != dl.X + dl.Y || p == dl || dl.X + dl.Y == 20))
                        Pintar_Casilla(ctrl_i, csl);
                }
                else if (cp.Pos.X < csl.Pos.X && p.X >= u.X)
                    Pintar_Casilla(ctrl_i, csl);
                else if (cp.Pos.X > csl.Pos.X && p.X <= d.X)
                    Pintar_Casilla(ctrl_i, csl);
            }
        }

        public void Pintar_Casilla(int i, Casilla csl)
        {
            if (((Casilla)panel1.Controls[i]).Pieza.Color != csl.Pieza.Color)
                panel1.Controls[i].BackColor = Color.FromArgb(60,0, 0, 255);
        }
    }
}
