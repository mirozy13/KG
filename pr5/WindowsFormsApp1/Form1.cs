using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            holst.InitializeContexts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void simpleOpenGlControl1_Load(object sender, EventArgs e)
        {
            Gl.glViewport(0, 0, holst.Width, holst.Height);
            Gl.glClearColor(1.0f, 0.0f, 1.0f, 0.9f);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            holst.Invalidate();
        }

        private void holst_Paint(object sender, PaintEventArgs e)
        {  }

        private void figureToolStripMenuItem_Click(object sender, EventArgs e)
        {  }

        private void linesToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            Gl.glViewport(0, 0, holst.Width, holst.Height);
            Gl.glClearColor(0, 1, 1, 1);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

            Gl.glColor3f(0, 0, 0);
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2f(0, 1);
            Gl.glVertex2f(0, -1);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2f(1, 0);
            Gl.glVertex2f(-1, 0);
            Gl.glEnd();


            Gl.glColor3f(1, 0, 0);
            Gl.glLineWidth(3);
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2f(-0.5f, 0.6f);
            Gl.glVertex2f(-0.2f, 0.6f);
            Gl.glVertex2f(0.6f, -0.4f);
            Gl.glVertex2f(0.6f, -0.1f);
            Gl.glVertex2f(-0.5f, -0.26f);
            Gl.glEnd();
            holst.Invalidate();
        }

        private void poligonToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Gl.glViewport(0, 0, holst.Width, holst.Height);
            Gl.glClearColor(1, 1, 1, 1);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glLineWidth(3);

            Gl.glColor3f(0, 0, 0);
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2f(0, 1);
            Gl.glVertex2f(0, -1);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2f(1, 0);
            Gl.glVertex2f(-1, 0);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glColor3f(1, 0, 0);
            Gl.glVertex2f(-0.4f, 0.5f);
            Gl.glColor3f(1, 0, 1);
            Gl.glVertex2f(-0.2f, 0.5f);
            Gl.glColor3f(0, 0, 1);
            Gl.glVertex2f(0.3f, -0.15f);
            Gl.glColor3f(1, 0, 0);
            Gl.glVertex2f(-0.4f, -0.3f);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glColor3f(0, 0, 1);
            Gl.glVertex2f(0.3f, -0.15f);
            Gl.glColor3f(1, 0, 0);
            Gl.glVertex2f(0.5f, -0.4f);
            Gl.glColor3f(1, 0, 1);
            Gl.glVertex2f(0.5f, -0.1f);
            Gl.glEnd();
            holst.Invalidate();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
