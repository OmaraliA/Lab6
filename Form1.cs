using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace SpaceShip
{
    
    public partial class Form1 : Form
    {

        
        public Form1()
        {
            
            InitializeComponent();
            
            Draw();
            


        }

        public PointF[] GetPointsForStar(double x0, double y0, double R, double r)
        {
            int n = 6;          
            double alpha = Math.PI/6;        
                                     
            Bitmap bmp = new Bitmap(400, 500);
            Graphics grph = Graphics.FromImage(bmp);


            PointF[] points = new PointF[2 * n + 1];
            double a = alpha, da = Math.PI / n, l;
            for (int k = 0; k < 2 * n + 1; k++)
            {
                l = k % 2 == 0 ? r : R;
                points[k] = new PointF((float)(x0 + l * Math.Cos(a)), (float)(y0 + l * Math.Sin(a)));
                a += da;
            }
            

            return points;
        }
        public PointF[] GetPointsForBullet(double x0, double y0, double R, double r)
        {
            int n = 4;
            double alpha = Math.PI / 2;

            Bitmap bmp = new Bitmap(400, 500);
            Graphics grph = Graphics.FromImage(bmp);


            PointF[] points = new PointF[2 * n + 1];
            double a = alpha, da = Math.PI / n, l;
            for (int k = 0; k < 2 * n + 1; k++)
            {
                l = k % 2 == 0 ? r : R;
                points[k] = new PointF((float)(x0 + l * Math.Cos(a)), (float)(y0 + l * Math.Sin(a)));
                a += da;
            }


            return points;
        }
        public Point[] GetPointsForStarForPolygons(int count, int dx, int dy,int r)
        {
            
            
            
            Bitmap bmp = new Bitmap(400, 500);
            Graphics grph = Graphics.FromImage(bmp);
            

            double angle = -Math.PI * 0.5;
            Point[] points = new Point[count];
            for (int i = 0; i < count; i++)
            {
                points[i] = new Point(
                    dx + (int)Math.Round(Math.Cos(angle + Math.PI * 2.0 * i / count) * r),
                    dy + (int)Math.Round(Math.Sin(angle + Math.PI * 2.0 * i / count) * r)
                );
            }

            return points;
        }
        public Point[] GetPointsForStarForRectangle(int dx, int dy, int r)
        {

            int count = 4;

            Bitmap bmp = new Bitmap(400, 500);
            Graphics grph = Graphics.FromImage(bmp);


            double angle = Math.PI/4 ;
            Point[] points = new Point[count];
            for (int i = 0; i < count; i++)
            {
                points[i] = new Point(
                    dx + (int)Math.Round(Math.Cos(angle + Math.PI * 2.0 * i / count) * r),
                    dy + (int)Math.Round(Math.Sin(angle + Math.PI * 2.0 * i / count) * r)
                );
            }

            return points;
        }


        public void Draw()
        {
            Bitmap bmp = new Bitmap(picture.Width, picture.Height);
            Graphics grph = Graphics.FromImage(bmp);
            Pen pn = new Pen(Color.Red);
            Brush brsh = new SolidBrush(Color.Pink);
            //grph.DrawRectangle(pn, 30, 40, 200, 100);
            grph.FillRectangle(brsh, new Rectangle(0, 0, picture.Width, picture.Height));

            brsh = new SolidBrush(Color.Black);
            grph.FillRectangle(brsh, new Rectangle(0, 0, picture.Width, picture.Height));
            brsh = new SolidBrush(Color.DarkGray);
            grph.FillRectangle(brsh, new Rectangle(10, 10, picture.Width - 20, picture.Height - 20));

            brsh = new SolidBrush(Color.White);
            grph.FillEllipse(brsh, new Rectangle(65, 75, 28, 28));
            grph.FillEllipse(brsh, new Rectangle(75, 335, 28, 28));
            grph.FillEllipse(brsh, new Rectangle(275, 65, 28, 28));
            grph.FillEllipse(brsh, new Rectangle(275, 300, 28, 28));
            grph.FillEllipse(brsh, new Rectangle(435, 98, 28, 28));
            grph.FillEllipse(brsh, new Rectangle(550, 235, 28, 28));
            grph.FillEllipse(brsh, new Rectangle(615, 180, 28, 28));
            grph.FillEllipse(brsh, new Rectangle(615, 355, 28, 28));


            Brush redBrush = new SolidBrush(Color.Red);


            grph.FillPolygon(redBrush, GetPointsForStar(150, 140, 14, 26));
            grph.FillPolygon(redBrush, GetPointsForStar(220, 290, 14, 26));
            grph.FillPolygon(redBrush, GetPointsForStar(480, 315, 14, 26));
            grph.FillPolygon(redBrush, GetPointsForStar(580, 150, 14, 26));


            brsh = new SolidBrush(Color.Yellow);

            grph.FillPolygon(brsh, GetPointsForStarForPolygons(6, picture.Width / 2 + 45, picture.Height / 2, 50));

            brsh = new SolidBrush(Color.Green);

            grph.FillPolygon(brsh, GetPointsForStarForPolygons(3, picture.Width / 2 + 45, picture.Height / 2 - 10, 18));
            grph.FillPolygon(brsh, GetPointsForStarForRectangle(picture.Width / 2 + 45, picture.Height /2 + 8 , 13));
            grph.FillPolygon(brsh, GetPointsForBullet(picture.Width / 2 + 57, picture.Height / 2 - 70, 8,17));










            picture.Image = bmp;
        }

        private void picture_Click(object sender, EventArgs e)
        {

        }
    }
}

