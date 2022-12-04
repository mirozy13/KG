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

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            simpleOpenGlControl1.InitializeContexts();

            Gl.glViewport(0, 0, simpleOpenGlControl1.Width, simpleOpenGlControl1.Height);
            Gl.glClearColor(1, 1, 1, 1);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glClear(Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glFrustum(-1, 1, -1, 1, 0, 10);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glTranslatef(0f, 0f, -7f);
            Gl.glLoadIdentity();
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glPushMatrix();
            draw1();
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
            Gl.glEnable(Gl.GL_NORMALIZE);
            Gl.glLightModelf(Gl.GL_LIGHT_MODEL_TWO_SIDE, Gl.GL_TRUE);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, light_dif);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, lightx);
            simpleOpenGlControl1.Invalidate();
        }

        float[] lightx = { 1.0f, 0.0f, 0.0f, 0.0f };
        float[] lighty = { 0.0f, 1.0f, 0.0f, 0.0f };
        float[] lightz = { 0.0f, 0.0f, 1.0f, 0.0f };
        float[] light_dif = { 0.7f, 0.2f, 0.2f };
        float[] color1 = { 0.7f, 0.2f, 0.2f };


        void draw1()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glClear(Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glNormal3f(0.0f, 1.0f, 0.0f);
            Gl.glVertex3f(0.2f, 0.2f, -0.5f);
            Gl.glVertex3f(-0.2f, 0.2f, -0.5f);
            Gl.glVertex3f(-0.2f, 0.2f, 0.5f);
            Gl.glVertex3f(0.2f, 0.2f, 0.5f);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glNormal3f(0.0f, -1.0f, 0.0f);
            Gl.glVertex3f(0.2f, -0.2f, 0.5f);
            Gl.glVertex3f(-0.2f, -0.2f, 0.5f);
            Gl.glVertex3f(-0.2f, -0.2f, -0.5f);
            Gl.glVertex3f(0.2f, -0.2f, -0.5f);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glNormal3f(0.0f, 0.0f, 1.0f);
            Gl.glVertex3f(0.2f, 0.2f, 0.5f);
            Gl.glVertex3f(-0.2f, 0.2f, 0.5f);
            Gl.glVertex3f(-0.2f, -0.2f, 0.5f);
            Gl.glVertex3f(0.2f, -0.2f, 0.5f);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glNormal3f(0.0f, 0.0f, -1.0f);
            Gl.glVertex3f(0.2f, -0.2f, -0.5f);
            Gl.glVertex3f(-0.2f, -0.2f, -0.5f);
            Gl.glVertex3f(-0.2f, 0.2f, -0.5f);
            Gl.glVertex3f(0.2f, 0.2f, -0.5f);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glNormal3f(-1.0f, 0.0f, 0.0f);
            Gl.glVertex3f(-0.2f, 0.2f, 0.5f);
            Gl.glVertex3f(-0.2f, 0.2f, -0.5f);
            Gl.glVertex3f(-0.2f, -0.2f, -0.5f);
            Gl.glVertex3f(-0.2f, -0.2f, 0.5f);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glNormal3f(1.0f, 0.0f, 0.0f);
            Gl.glVertex3f(0.2f, 0.2f, -0.5f);
            Gl.glVertex3f(0.2f, 0.2f, 0.5f);
            Gl.glVertex3f(0.2f, -0.2f, 0.5f);
            Gl.glVertex3f(0.2f, -0.2f, -0.5f);
            Gl.glEnd();

            simpleOpenGlControl1.Invalidate();
        }

        private void paint(object sender, PaintEventArgs e)
        {
        }

        private void rotation(float x, float y, float z)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glClear(Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glPushMatrix();
            Gl.glRotatef(5, x, y, z);
            draw1();
            simpleOpenGlControl1.Invalidate();
        }

        private void keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Application.Exit();

            if (e.KeyCode == Keys.NumPad1)
                rotation(1f, 0, 0);
            if (e.KeyCode == Keys.NumPad2)
                rotation(0, 1f, 0);
            if (e.KeyCode == Keys.NumPad3)
                rotation(0, 0, 1f);

            if (e.KeyCode == Keys.Space)
                timer1.Stop();
            if (e.KeyCode == Keys.Enter)
                timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            rotation(1f, 0.3f, 1f);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Gl.glMaterialfv(Gl.GL_FRONT_AND_BACK, Gl.GL_EMISSION, color1);
            simpleOpenGlControl1.Invalidate();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Gl.glMaterialfv(Gl.GL_FRONT_AND_BACK, Gl.GL_AMBIENT, color1);
            simpleOpenGlControl1.Invalidate();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Gl.glMaterialfv(Gl.GL_FRONT_AND_BACK, Gl.GL_SPECULAR, color1);
            simpleOpenGlControl1.Invalidate();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Gl.glMaterialfv(Gl.GL_FRONT_AND_BACK, Gl.GL_DIFFUSE, color1);
            simpleOpenGlControl1.Invalidate();
        }

        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, light_dif);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, lightx);
        }

        private void yToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, light_dif);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, lighty);
        }

        private void zToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, light_dif);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, lightz);
        }
    }
}
