using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{

    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics grp;

        static Random rnd = new Random();

        public class point
        {
            public float x, y;
            public point(float x, float y)
            {
                this.x = x;
                this.y = y;
            }
            public point()
            {
                x = rnd.Next(500);
                y = rnd.Next(300);
            }

            public void draw(Graphics grp)
            {
                grp.DrawEllipse(new Pen(Color.Red, -2), x, y, 2, 2);
            }
        }
        static float Aria(point A, point B, point C)
        {
            return 0.5f * ((A.x * B.y) + (B.x * C.y) + (C.x * A.y) - (C.x * B.y) - (A.x * C.y) - (A.y * B.x));
        }


        public Form1()
        {

            InitializeComponent();
        }
        static float Lungime(point A, point B)
        {
            float lungime;
            lungime = (float)Math.Sqrt((A.x - B.x) * (A.x - B.x) + (A.y - B.y) * (A.y - B.y));

            return lungime;
        }

        public float ariap(point A, point B, point C, point D)
        {
            point O = new point(0, 0);
            float val = Aria(A, B, O) + Aria(B, C, O) + Aria(C, D, O) + Aria(D, A, O);
            return Math.Abs(val);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            grp.Clear(Color.LightBlue);

            int n = 30;
            point[] p = new point[n];
            for (int i = 0; i < n; i++)
            {
                p[i] = new point();
                p[i].draw(grp);
            }

            float aria, ariaMaxima = ariap(p[0], p[1], p[2], p[3]);


            int x1 = 0, x2 = 1, x3 = 2, x4 = 3;
            for (int i1 = 0; i1 < n - 3; i1++)
            {
                for (int i2 = i1 + 1; i2 < n - 2; i2++)
                {
                    for (int i3 = i2 + 1; i3 < n - 1; i3++)
                        for (int i4 = i3 + 1; i4 < n; i4++)
                        {
                            aria = ariap(p[i1], p[i2], p[i3], p[i4]);// ariap=aria poligonului
                            if (aria > ariaMaxima)
                            {
                                ariaMaxima = aria;
                                x1 = i1; x2 = i2; x3 = i3; x4 = i4;
                            }
                        }
                }
            }

            PointF[] t = new PointF[4];
            t[0] = new PointF(p[x1].x, p[x1].y);
            t[1] = new PointF(p[x2].x, p[x2].y);
            t[2] = new PointF(p[x3].x, p[x3].y);
            t[3] = new PointF(p[x4].x, p[x4].y);
            grp.FillPolygon(new SolidBrush(Color.Red), t);
            t[0] = new PointF(p[x1].x, p[x1].y);
            t[1] = new PointF(p[x3].x, p[x3].y);
            t[2] = new PointF(p[x2].x, p[x2].y);
            t[3] = new PointF(p[x4].x, p[x4].y);
            grp.FillPolygon(new SolidBrush(Color.Red), t);
            pictureBox1.Image = bmp;
        }
    }
}
