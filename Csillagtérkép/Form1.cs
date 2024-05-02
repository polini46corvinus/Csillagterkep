using Csillagtérkép.Models;

namespace Csillagtérkép
{
    public partial class Form1 : Form
    {
        hajosContext context = new hajosContext();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            Brush b = new SolidBrush(Color.Fuchsia);

            Pen pen = new Pen(Color.Fuchsia);

            g.DrawEllipse(pen, 0, 0, 100, 100);
            //g.FillEllipse(b, ClientRectangle.Width / 2, ClientRectangle.Height / 2, 100, 100);

            var stars = (from x in context.StarData
                         select new { x.Hip, x.X, x.Y, x.Magnitude }).ToList();
            double nagyitas = 501;

            g.Clear(Color.Blue);
            /*
            foreach (var star in stars)
            {
                g.DrawEllipse(pen, ClientRectangle.Width / 2 + Convert.ToInt32(star.X * nagyitas),
                    ClientRectangle.Height / 2 + Convert.ToInt32(star.Y * nagyitas), 1, 1);
            }
            */

            Color c = Color.Gold;
            Pen toll = new(c, 1);
            Brush brush = new SolidBrush(c);
            float cx = ClientRectangle.Width / 2;
            float cy = ClientRectangle.Height / 2;

            foreach (var star in stars)
            {
                if (Math.Sqrt(Math.Pow(star.X, 2) + Math.Pow(star.Y, 2)) > 1) continue;
                {
                    float x1 = (float)(nagyitas * star.X);
                    float y1 = (float)(nagyitas * star.Y);

                    double size = 20 * Math.Pow(10, (star.Magnitude) / -2.5);

                    if (size < 2) size = 1;
                    g.FillEllipse(brush, x1 + cx, y1 + cy, (float)size, (float)size);
                }
            }
            var lines = context.ConstellationLines.ToList();

            foreach (var line in lines)
            {
                var star1 = (from s in stars where s.Hip == line.Star1 select s).FirstOrDefault();
                var star2 = (from s in stars where s.Hip == line.Star2 select s).FirstOrDefault();

                if (star1 == null || star2 == null) continue;

                float x1 = (float)(nagyitas * star1.X);
                float y1 = (float)(nagyitas * star1.Y);
                float x2 = (float)(nagyitas * star2.X);
                float y2 = (float)(nagyitas * star2.Y);

                g.DrawLine(toll, x1 + cx, y1 + cy, x2 + cx, y2 + cy);

            }
        }
            }
        }
