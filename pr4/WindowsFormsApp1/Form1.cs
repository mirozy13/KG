using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        float[,] shape = {
            {    -60, -60,   28,  1 },
            {    -30, -60,   28,  1 },
            {     80,  45,   28,  1 },
            {     80,  10,   28,  1 },
            {    -60,  18,   28,  1 },
            {    -60, -60, - 28,  1 },
            {    -30, -60, - 28,  1 },
            {     80,  45, - 28,  1 },
            {     80,  10, - 28,  1 },
            {    -60,  18, - 28,  1 },
        };
        float[,] new_shape = {
            {    -60, -60,   28,  1 },
            {    -30, -60,   28,  1 },
            {     80,  45,   28,  1 },
            {     80,  10,   28,  1 },
            {    -60,  18,   28,  1 },
            {    -60, -60, - 28,  1 },
            {    -30, -60, - 28,  1 },
            {     80,  45, - 28,  1 },
            {     80,  10, - 28,  1 },
            {    -60,  18, - 28,  1 },
        };
        void coordinates()
        {
            Refresh();
            int H = pictureBox1.Height / 2;
            int W = pictureBox1.Width / 2;
            var c = new PointF(W, H);
            var x1 = new PointF(W, H);
            var x2 = new PointF(W + 230, H);
            var y1 = new PointF(W, H);
            var y2 = new PointF(W, H - 190);
            var z1 = new PointF(W, H);
            var z2 = new PointF(W - 150, H + 150);
            var c1 = new PointF(W + 28, H);

            Graphics g = pictureBox1.CreateGraphics();
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0),2);
            g.DrawLine(pen, x1, x2);
            g.DrawLine(pen, y1, y2);
            g.DrawLine(pen, z1, z2);
            Font style = new Font("Arial", 12);
            g.DrawString("x", style, Brushes.Black, x2);
            g.DrawString("y", style, Brushes.Black, y2);
            g.DrawString("z", style, Brushes.Black, z2);
            g.DrawString("0", style, Brushes.Black, c);
            g.DrawString("1", style, Brushes.Black, c1);
        }
        
        void Draw_shape(float[,] a)
        {
            Graphics g = pictureBox1.CreateGraphics();
            Pen pen = new Pen(Color.Red, 3);
            int height = pictureBox1.Height / 2;
            int width = pictureBox1.Width / 2;

            g.DrawLine(pen, width + a[0, 0], height + a[0, 1], width + a[1, 0], height + a[1, 1]);
            g.DrawLine(pen, width + a[1, 0], height + a[1, 1], width + a[2, 0], height + a[2, 1]);
            g.DrawLine(pen, width + a[2, 0], height + a[2, 1], width + a[3, 0], height + a[3, 1]);
            g.DrawLine(pen, width + a[3, 0], height + a[3, 1], width + a[4, 0], height + a[4, 1]);
            g.DrawLine(pen, width + a[4, 0], height + a[4, 1], width + a[0, 0], height + a[0, 1]);

            g.DrawLine(pen, width + a[5, 0], height + a[5, 1], width + a[6, 0], height + a[6, 1]);
            g.DrawLine(pen, width + a[6, 0], height + a[6, 1], width + a[7, 0], height + a[7, 1]);
            g.DrawLine(pen, width + a[7, 0], height + a[7, 1], width + a[8, 0], height + a[8, 1]);
            g.DrawLine(pen, width + a[8, 0], height + a[8, 1], width + a[9, 0], height + a[9, 1]);
            g.DrawLine(pen, width + a[9, 0], height + a[9, 1], width + a[5, 0], height + a[5, 1]);

            g.DrawLine(pen, width + a[0, 0], height + a[0, 1], width + a[5, 0], height + a[5, 1]);
            g.DrawLine(pen, width + a[1, 0], height + a[1, 1], width + a[6, 0], height + a[6, 1]);
            g.DrawLine(pen, width + a[2, 0], height + a[2, 1], width + a[7, 0], height + a[7, 1]);
            g.DrawLine(pen, width + a[3, 0], height + a[3, 1], width + a[8, 0], height + a[8, 1]);
            g.DrawLine(pen, width + a[4, 0], height + a[4, 1], width + a[9, 0], height + a[9, 1]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            coordinates();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Draw_shape(new_shape);
        }

        static float[,] multiplication(float[,] a, float[,] b)
        {
            int line1 = a.GetLength(0);
            int line2 = b.GetLength(0);
            int column2 = b.GetLength(1);

            float[,] result = new float[line1, column2];

            for (int i = 0; i < line1; i++)
            {
                for (int j = 0; j < column2; j++)
                {
                    for (int k = 0; k < line2; k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return result;
        }

        private void button3_Click(object sender, EventArgs e) 
        {
            float p = float.Parse(textBox1.Text);
            float[,] rotation = { 
                { 1, 0, 0 ,0},
                { 0, (float)Math.Cos(p*Math.PI/180), (float)Math.Sin(p*Math.PI/180), 0 },
                { 0, -(float)Math.Sin(p*Math.PI/180), (float)Math.Cos(p*Math.PI/180), 0},
                { 0, 0, 0, 1 } };
            shape = multiplication(shape, rotation);
            coordinates();
            Draw_shape(shape);
        }

        private void button4_Click(object sender, EventArgs e) 
        {
            float p = float.Parse(textBox1.Text);
            float[,] rotation = {
                { (float)Math.Cos(p*Math.PI/180), 0, -(float)Math.Sin(p*Math.PI/180), 0 },
                { 0, 1, 0, 0 },
                { (float)Math.Sin(p*Math.PI/180), 0, (float)Math.Cos(p*Math.PI/180), 0 },
                {0, 0, 0, 1 } };
            shape = multiplication(shape, rotation);
            coordinates();
            Draw_shape(shape);
        }

        private void button5_Click(object sender, EventArgs e) 
        {
            float p = float.Parse(textBox1.Text);
            float[,] rotation = {
                { (float)Math.Cos(p*Math.PI/180), (float)Math.Sin(p*Math.PI/180), 0, 0},
                {-(float)Math.Sin(p*Math.PI/180), (float)Math.Cos(p*Math.PI/180), 0, 0 },
                { 0 ,0, 1, 0 },
                {0, 0, 0, 1 } };
            shape = multiplication(shape, rotation);
            coordinates();
            Draw_shape(shape);
        }
    }
}
