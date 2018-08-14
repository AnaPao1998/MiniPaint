using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            mat = new Color[numOfCells, numOfCells];
            for (int i = 0; i < numOfCells; i++)
            {
                for (int j = 0; j < numOfCells; j++)
                {
                    mat[i, j] = Color.White;
                }
            }
        }
        int color = 0;
        int x1;
        int y1;
        int x2;
        int y2;
        int x3;
        int y3;
        private Color[,] mat;
        int cellSize = (Screen.PrimaryScreen.Bounds.Width / 100);
        int numOfCells = (Screen.PrimaryScreen.Bounds.Width / 5);

        protected override void OnPaint(PaintEventArgs e)

        {
            
            //esto es para crear la cuadricula
            Graphics g = e.Graphics;
            button1.SetBounds(this.Width - 100, 10, 75, 35);
            button2.SetBounds(this.Width - 100, 50, 75, 35);
            button3.SetBounds(this.Width - 100, 90, 75, 35);
            button4.SetBounds(this.Width - 100, 130, 75, 35);
            button5.SetBounds(this.Width - 100, 170, 75, 35);
            button6.SetBounds(this.Width - 100, 210, 75, 35);
            button8.SetBounds(this.Width - 100, 250, 35, 35);
            button9.SetBounds(this.Width - 60, 250, 35, 35);
            button7.SetBounds(this.Width - 100, 290, 35, 35);
            button10.SetBounds(this.Width - 60, 290, 35, 35);
            button11.SetBounds(this.Width - 100, 330, 35, 35);
            button12.SetBounds(this.Width - 60, 330, 35, 35);
            button13.SetBounds(this.Width - 100, 370, 35, 35);
            button14.SetBounds(this.Width - 60, 370, 35, 35);
            label9.SetBounds(20, this.Height - 70, 60, 20);

            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Lime);
            System.Drawing.Graphics formGraphics;
            formGraphics = this.CreateGraphics();
            for (int i = 0; i < numOfCells; i++)
            {
                for (int j = 0; j < numOfCells; j++)
                {
                    myBrush.Color = mat[i, j];
                    formGraphics.FillRectangle(myBrush, new Rectangle(i * cellSize, j*cellSize, cellSize, cellSize));
                }
            }

            
            Pen p = new Pen(Color.Black);
            for (int y = 0; y < numOfCells; ++y)
            {
                formGraphics.DrawLine(p, 0, y * cellSize, numOfCells * cellSize, y * cellSize);
            }

            for (int x = 0; x < numOfCells; ++x)
            {
                formGraphics.DrawLine(p, x * cellSize, 0, x * cellSize, numOfCells * cellSize);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            int xPunto = x2;
            int yPunto = y2;
            SetPixel(x2, y2);
        }


        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            x3 = x1;
            y3 = y1;
            x1 = x2;
            y1 = y2;
            x2 = (e.Location.X / cellSize) + 1;
            y2 = (e.Location.Y / cellSize) + 1;
            label9.Text = "Primer punto: x= " + x1 + "; y= " + y1 + "\n Segundo punto: x= " + x2 + "; y= " + y2;
        }
        private int Round(double x)
        {
            return (int)(x + 0.5);
        }

        private void SetPixel(int x, int y)
        {

            if (color == 1)
            {
                mat[x, y] = Color.Lime;
               /* System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Lime);
                System.Drawing.Graphics formGraphics;
                formGraphics = this.CreateGraphics();
                formGraphics.FillRectangle(myBrush, new Rectangle(cellSize * x - cellSize, cellSize * y - cellSize, cellSize, cellSize));
                myBrush.Dispose();
                formGraphics.Dispose();*/
            }
            else if (color == 2)
            {
                mat[x, y] = Color.Lime;
            }
            else if (color == 3)
            {
                mat[x, y] = Color.Blue;

            }
            else if (color == 4)
            {
                mat[x, y] = Color.Yellow;
                
            }
            else if (color == 5)
            {
                mat[x, y] = Color.Purple;
               
            }
            else if (color == 6)
            {
                mat[x, y] = Color.Red;
                
            }
            else
            {
                mat[x, y] = Color.Orange;
                
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int xInicial = x1;
            int xFinal = x2;
            int yInicial = y1;
            int yFinal = y2;
            int dx = xFinal - xInicial;
            int dy = yFinal - yInicial;
            int steps, k, xf, yf;
            float xIncrement, yIncrement, x = xInicial, y = yInicial;

            if (Math.Abs(dx) > Math.Abs(dy)) steps = Math.Abs(dx);

            else steps = Math.Abs(dy);
            xIncrement = dx / (float)steps;
            yIncrement = dy / (float)steps;

            SetPixel(Round(x), Round(y));
            for (k = 0; k < steps; k++)
            {
                x += xIncrement;
                xf = (int)xInicial;
                y += yIncrement;
                yf = (int)yInicial;
                SetPixel(Round(x), Round(y));
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void button3_Click(object sender, EventArgs e)
        {
            int xInicial = x1;
            int xFinal = x2;
            int yInicial = y1;
            int yFinal = y2;
            int dx = xFinal - xInicial;
            int dy = yFinal - yInicial;

            SetPixel(x1, y1);
            if (Math.Abs(dx) > Math.Abs(dy))
            {
                float m = (float)dy / (float)dx;
                float b = y1 - m * x1;
                if (dx < 0)
                    dx = -1;
                else
                    dx = 1;
                while (x1 != x2)
                {
                    x1 += dx;
                    y1 = Round(m * x1 + b);
                    SetPixel(x1, y1);
                }
            }
            else
            {
                if (dy != 0)
                {
                    float m = (float)dx / (float)dy;
                    float b = x1 - m * y1;
                    if (dy < 0)
                        dy = -1;
                    else
                        dy = 1;
                    while (y1 != y2)
                    {
                        y1 += dy;
                        x1 = Round(m * y1 + b);
                        SetPixel(x1, y1);
                    }
                }

            }
        }

        Graphics g;
        //funcion para limpiar
        private void button4_Click(object sender, EventArgs e)
        {
            /*System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
            System.Drawing.Graphics formGraphics;
            formGraphics = this.CreateGraphics();
            for (int i = 1; i <= numOfCells; i++)
            {
                for (int j = 1; j <= numOfCells; j++)
                {
                    formGraphics.FillRectangle(myBrush, new Rectangle(cellSize * i - cellSize, cellSize * j - cellSize, cellSize, cellSize));
                }
            }
            g = this.CreateGraphics();
            Pen p = new Pen(Color.Black);
            for (int y = 0; y < numOfCells; ++y)
            {
                g.DrawLine(p, 0, y * cellSize, numOfCells * cellSize, y * cellSize);
            }

            for (int x = 0; x < numOfCells; ++x)
            {
                g.DrawLine(p, x * cellSize, 0, x * cellSize, numOfCells * cellSize);
            }*/
            this.Refresh();
            //limpiar las posiciones de los mouse
            label9.Text = "Primer punto: x=   y=  \n Segundo punto: x=   y= ";
            x1 = x2 = x3 = y1 = y2 = y3 = 0;
           

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            //this.Refresh();
        }

        private void DibujarPuntosC(int xCenter, int yCenter, int x, int y)
        {

            SetPixel(xCenter + x, yCenter + y);
            SetPixel(xCenter - x, yCenter + y);
            SetPixel(xCenter + x, yCenter - y);
            SetPixel(xCenter - x, yCenter - y);
            SetPixel(xCenter + y, yCenter + x);
            SetPixel(xCenter - y, yCenter + x);
            SetPixel(xCenter + y, yCenter - x);
            SetPixel(xCenter - y, yCenter - x);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int xCenter = x2;
            int yCenter = y2;
            int radio = (int)Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            int x = 0;
            int y = radio;
            int p = 1 - radio;

            DibujarPuntosC(xCenter, yCenter, x, y);
            while (x < y)
            {
                x++;
                if (p < 0)

                    p += 2 * x + 1;
                else
                {
                    y--;
                    p += 2 * (x - y) + 1;
                }

                DibujarPuntosC(xCenter, yCenter, x, y);
            }

        }

        private void DibujarPuntosE(int xCenter, int yCenter, int x, int y)
        {
            SetPixel(xCenter + x, yCenter + y);
            SetPixel(xCenter - x, yCenter + y);
            SetPixel(xCenter + x, yCenter - y);
            SetPixel(xCenter - x, yCenter - y);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int rx2 = (x3 - x1) * (x3 - x1);
            int ry2 = (y3 - y1) * (y3 - y1);
            int p;
            int x = 0;
            int y = Math.Abs(y3 - y1);
            int px = 0;
            int py = 2 * rx2 * y;
            DibujarPuntosE(x3, y3, x, y);
            p = Round(ry2 - (rx2 * Math.Abs((y3 - y1))) + (0.25 * rx2));
            while (px < py)
            {
                x++;
                px += 2 * ry2;
                if (p < 0) p += ry2 + px;
                else
                {
                    y--;
                    py -= 2 * rx2;
                    p += ry2 + px - py;
                }
                DibujarPuntosE(x3, y3, x, y);
            }
            p = Round(ry2 * (x + 0.5) * (x + 0.5) + rx2 * (y - 1) * (y - 1) - rx2 * ry2);
            while (y > 0)
            {
                y--;
                py -= rx2 * 2;
                if (p > 0) p += rx2 - py;
                else
                {
                    x++;
                    px += 2 * ry2;
                    p += rx2 - py + px;
                }
                DibujarPuntosE(x3, y3, x, y);
            }
        }

        

        private void button8_Click(object sender, EventArgs e)
        {
            cellSize = cellSize + 2;
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
            System.Drawing.Graphics formGraphics;
            formGraphics = this.CreateGraphics();
            for (int i = 1; i <= numOfCells; i++)
            {
                for (int j = 1; j <= numOfCells; j++)
                {
                    formGraphics.FillRectangle(myBrush, new Rectangle(cellSize * i - cellSize, cellSize * j - cellSize, cellSize, cellSize));
                }
            }
            g = this.CreateGraphics();
            Pen p = new Pen(Color.Black);
            for (int y = 0; y < numOfCells; ++y)
            {
                g.DrawLine(p, 0, y * cellSize, numOfCells * cellSize, y * cellSize);
            }

            for (int x = 0; x < numOfCells; ++x)
            {
                g.DrawLine(p, x * cellSize, 0, x * cellSize, numOfCells * cellSize);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            cellSize = cellSize - 2;
            //this.Refresh();
             System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
             System.Drawing.Graphics formGraphics;
             formGraphics = this.CreateGraphics();
             for (int i = 1; i <= numOfCells; i++)
             {
                 for (int j = 1; j <= numOfCells; j++)
                 {
                     formGraphics.FillRectangle(myBrush, new Rectangle(cellSize * i - cellSize, cellSize * j - cellSize, cellSize, cellSize));
                 }
             }
             g = this.CreateGraphics();
             Pen p = new Pen(Color.Black);
             for (int y = 0; y < numOfCells; ++y)
             {
                 g.DrawLine(p, 0, y * cellSize, numOfCells * cellSize, y * cellSize);
             }

             for (int x = 0; x < numOfCells; ++x)
             {
                 g.DrawLine(p, x * cellSize, 0, x * cellSize, numOfCells * cellSize);
             }

        }
        private void button7_Click(object sender, EventArgs e)
        {

            color = 1;

        }

        private void button10_Click(object sender, EventArgs e)
        {
            color = 2;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            color = 3;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            color = 4;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            color = 5;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            color = 6;
        }
    }
}




