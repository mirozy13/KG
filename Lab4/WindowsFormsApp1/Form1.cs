using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        float[,] points = {
            { -56,  56,  56, 1 },
            {  56,  56,  56, 1 },
            {  56, -56,  56, 1 },
            { -56, -56,  56, 1 },
            { -56,  56, -56, 1 },
            {  56,  56, -56, 1 },
            {  56, -56, -56, 1 },
            { -56, -56, -56, 1 }
        };

        float[,] new_fig = {
            { -56,  56,  56, 1 },
            {  56,  56,  56, 1 },
            {  56, -56,  56, 1 },
            { -56, -56,  56, 1 },
            { -56,  56, -56, 1 },
            {  56,  56, -56, 1 },
            {  56, -56, -56, 1 },
            { -56, -56, -56, 1 }
        };

        void coords()
        {
            Refresh();
            int H = pictureBox1.Height / 2;
            int W = pictureBox1.Width / 2;
            var center = new PointF(W, H);
            var x1 = new PointF(W, H);
            var x2 = new PointF(W + 170, H);
            var y1 = new PointF(W, H);
            var y2 = new PointF(W, H - 170);
            var z1 = new PointF(W, H);
            var z2 = new PointF(W - 100, H + 100);
            var zed = new PointF(W - 20, H + 20);
            var center1 = new PointF(W + 28, H);
            Graphics g = pictureBox1.CreateGraphics();
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            g.DrawLine(pen, x1, x2);
            g.DrawLine(pen, y1, y2);
            g.DrawLine(pen, z1, z2);
            Font mf = new Font("Arial", 12);
            g.DrawString("x", mf, Brushes.Black, x2);
            g.DrawString("y", mf, Brushes.Black, y2);
            g.DrawString("z", mf, Brushes.Black, z2);
            g.DrawString("0", mf, Brushes.Black, center);
            g.DrawString("1", mf, Brushes.Black, center1);
            g.DrawString("1", mf, Brushes.Black, zed);
        }

        void Draw(float[,] a)
        {
            Graphics g = pictureBox1.CreateGraphics();
            Pen pen = new Pen(Color.Red, 3);
            int height = pictureBox1.Height / 2;
            int width = pictureBox1.Width / 2;

            g.DrawLine(pen, width + a[0, 0], height + a[0, 1], width + a[1, 0], height + a[1, 1]);
            g.DrawLine(pen, width + a[1, 0], height + a[1, 1], width + a[2, 0], height + a[2, 1]);
            g.DrawLine(pen, width + a[2, 0], height + a[2, 1], width + a[3, 0], height + a[3, 1]);
            g.DrawLine(pen, width + a[3, 0], height + a[3, 1], width + a[0, 0], height + a[0, 1]);

            g.DrawLine(pen, width + a[4, 0], height + a[4, 1], width + a[5, 0], height + a[5, 1]);
            g.DrawLine(pen, width + a[5, 0], height + a[5, 1], width + a[6, 0], height + a[6, 1]);
            g.DrawLine(pen, width + a[6, 0], height + a[6, 1], width + a[7, 0], height + a[7, 1]);
            g.DrawLine(pen, width + a[7, 0], height + a[7, 1], width + a[4, 0], height + a[4, 1]);

            g.DrawLine(pen, width + a[0, 0], height + a[0, 1], width + a[4, 0], height + a[4, 1]);
            g.DrawLine(pen, width + a[1, 0], height + a[1, 1], width + a[5, 0], height + a[5, 1]);
            g.DrawLine(pen, width + a[2, 0], height + a[2, 1], width + a[6, 0], height + a[6, 1]);
            g.DrawLine(pen, width + a[3, 0], height + a[3, 1], width + a[7, 0], height + a[7, 1]);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            coords();
            Draw(new_fig);
        }

        static float[,] operations(float[,] a, float[,] b)
        {
            int al = a.GetLength(0);
            int bl = b.GetLength(0);
            int bl2 = b.GetLength(1);

            float[,] result = new float[al, bl2];

            for (int i = 0; i < al; i++)
            {
                for (int j = 0; j < bl2; j++)
                {
                    for (int k = 0; k < bl; k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return result;
        }

        private void button6_Click_1(object sender, EventArgs e) // по оси х
        {
            float[,] pl =
            {
                {1,0,0,0},
                {0,1,0,0 },
                {0,0,1,0 },
                {float.Parse(textBox1.Text)*28,1,1,1 }
            };
            points = operations(points, pl);
            coords();
            Draw(points);
        }

        private void button1_Click(object sender, EventArgs e)// по оси у
        {
            float[,] place =
            {
                {1,0,0,0},
                {0,1,0,0 },
                {0,0,1,0 },
                {1,float.Parse(textBox1.Text)*28,1,1 }
            };
            points = operations(points, place);
            coords();
            Draw(points);
        }

        private void button3_Click(object sender, EventArgs e)// по оси z
        {
            float[,] p =
            {
                {1,0,0,0},
                {0,1,0,0 },
                {0,0,1,0 },
                {-20,20,float.Parse(textBox1.Text)*28,1}
            };
            points = operations(points, p);
            coords();
            Draw(points);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            float[,] T = { 
                { 0.926f, 0.134f, 0 ,0},
                { 0, 0.935f, 0, 0 },
                { 0.378f, -0.327f, 0, 0},
                { 0, 0, 0, 1 } };

            points = operations(points, T);
            coords();
            Draw(points);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        
        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
