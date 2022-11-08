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

        float[,] shape ={
            {    -60, -60,  1 },
            {    -30,  -60, 1 },
            {     80,  45,  1 },
            {     80,  10,  1 },
            {     -60, 18,  1 },
        };
        float[,] shape2 ={
            {    -60, -60,  1 },
            {    -30,  -60, 1 },
            {     80,  45,  1 },
            {     80,  10,  1 },
            {     -60, 18,  1 },
        };

        void coordinates()
        {
            Refresh();
            var c1 = new PointF(pictureBox1.Width / 2, pictureBox1.Height / 2);
            var coorx = new PointF((pictureBox1.Width / 2) + 28, pictureBox1.Height / 2);
            var x1 = new PointF((pictureBox1.Width / 2) - 230, pictureBox1.Height / 2);
            var x2 = new PointF((pictureBox1.Width / 2) + 230, pictureBox1.Height / 2);
            var y1 = new PointF(pictureBox1.Width / 2, (pictureBox1.Height / 2) + 160);
            var y2 = new PointF(pictureBox1.Width / 2, (pictureBox1.Height / 2) - 165);
            Graphics g = pictureBox1.CreateGraphics();
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0),2);
            g.DrawLine(pen, x1, x2);
            g.DrawLine(pen, y1, y2);
            Font st = new Font("Arial", 10);
            g.DrawString("x", st, Brushes.Black, x2);
            g.DrawString("y", st, Brushes.Black, y2);
            g.DrawString("0", st, Brushes.Black, c1);
            g.DrawString("1", st, Brushes.Black, coorx);
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
        }
        private void button1_Click(object sender, EventArgs e) // рисуем и обновляем фигуру
        {
            coordinates();
            Draw_shape(shape2);
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
        private void button2_Click(object sender, EventArgs e) //отражение по х
        {
            float[,] ref_x = {
            { -1, 0, 0 },
            { 0,  1, 0 },
            { 0,  0, 1 }
        };
            shape = multiplication(shape, ref_x);
            coordinates();
            Draw_shape(shape);
        }

        private void button3_Click(object sender, EventArgs e) // отражение по у
        {
            float[,] ref_y = {
            { 1,  0,  0 },
            { 0, -1,  0 },
            { 0,  0,  1 }
        };
            shape = multiplication(shape, ref_y);
            coordinates();
            Draw_shape(shape);
        }

        private void button4_Click(object sender, EventArgs e) // растяжение, сжатие
        {
            float[,] size = {
                { float.Parse(textBox1.Text), 0, 0 },
                { 0, float.Parse(textBox5.Text), 0 },
                { 0,  0, 1 } 
            };
            shape = multiplication(shape, size);
            coordinates();
            Draw_shape(shape);
        }

        private void button5_Click(object sender, EventArgs e) // перенос
        {
            float[,] place = {
                { 1, 0, 0 },
                { 0, 1, 0 },
                { float.Parse(textBox2.Text) * 28, float.Parse(textBox3.Text) * -28, 1 } 
            };
            shape = multiplication(shape, place);
            coordinates();
            Draw_shape(shape);
        }
        private void button6_Click(object sender, EventArgs e)// поворот
        {
            float p = float.Parse(textBox4.Text);

            float[,] rotation = { 
                { (float)Math.Cos(p * Math.PI / 180), (float)Math.Sin(p * Math.PI / 180), 0 }, 
                { -(float)Math.Sin(p * Math.PI / 180), (float)Math.Cos(p * Math.PI / 180), 0 },
                { 0, 0, 1 }
            };
            shape = multiplication(shape, rotation);
            coordinates();
            Draw_shape(shape);
        }
        private void PictureBox1_Click(object sender, EventArgs e)
        { }
        private void label7_Click(object sender, EventArgs e)
        {}

        private void label6_Click(object sender, EventArgs e)
        {}

        private void label1_Click(object sender, EventArgs e)
        {}

        private void label7_Click_1(object sender, EventArgs e)
        {}

        private void label3_Click(object sender, EventArgs e)
        {}

        private void textBox4_TextChanged(object sender, EventArgs e)
        {}
    }
}
