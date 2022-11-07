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
            Gl.glClearColor(0, 0, 0, 0);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glFrustum(-1f, 1f, -1f, 1f, 3f, 10f);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glTranslatef(0f, 0f, -10f);
            draw1();
            simpleOpenGlControl1.Invalidate();
        }
        
        void draw1()
        {
            //front
            Gl.glBegin(Gl.GL_TRIANGLES);
            Gl.glColor4f(0.0f, 1.0f, 0.5f, 0.0f);
            Gl.glVertex3f(0.0f, 0.5f, 0.0f);//вершина
            Gl.glColor4f(0.0f, 1.0f, 0.5f, 0.0f);
            Gl.glVertex3f(-0.5f, -0.5f, 0.5f);//2
            Gl.glColor4f(1.0f, 1.0f, 1.0f, 0.0f);
            Gl.glVertex3f(0.5f, -0.5f, 0.5f);//3
            // right
            Gl.glColor4f(0.0f, 1.0f, 0.5f, 0.0f);
            Gl.glVertex3f(0.0f, 0.5f, 0.0f);//вершина
            Gl.glColor4f(1.0f, 1.0f, 1.0f, 0.0f);
            Gl.glVertex3f(0.5f, -0.5f, -0.5f);
            Gl.glColor4f(0.0f, 1.0f, 0.5f, 0.0f);
            Gl.glVertex3f(0.5f, -0.5f, 0.5f);
            // back
            Gl.glColor4f(0.0f, 1.0f, 0.5f, 0.0f);
            Gl.glVertex3f(0.0f, 0.5f, 0.0f);//вершина
            Gl.glColor4f(0.0f, 1.0f, 0.5f, 0.0f);
            Gl.glVertex3f(0.5f, -0.5f, -0.5f);
            Gl.glColor4f(1.0f, 1.0f, 1.0f, 0.0f);
            Gl.glVertex3f(-0.5f, -0.5f, -0.5f);
            // left
            Gl.glColor4f(0.0f, 1.0f, 0.5f, 0.0f);
            Gl.glVertex3f(0.0f, 0.5f, 0.0f);//вершина
            Gl.glColor4f(1.0f, 1.0f, 1.0f, 0.0f);
            Gl.glVertex3f(-0.5f, -0.5f, 0.5f);
            Gl.glColor4f(0.0f, 1.0f, 0.5f, 0.0f);
            Gl.glVertex3f(-0.5f, -0.5f, -0.5f);//1

            //bottom
            Gl.glColor4f(0.0f, 1.0f, 0.5f, 0.0f);
            Gl.glVertex3f(0.5f, -0.5f, 0.5f);//3
            Gl.glColor4f(1.0f, 1.0f, 1.0f, 0.0f);
            Gl.glVertex3f(-0.5f, -0.5f, 0.5f);//2
            Gl.glColor4f(0.0f, 1.0f, 0.5f, 0.0f);
            Gl.glVertex3f(-0.5f, -0.5f, -0.5f);//1

            Gl.glColor4f(1.0f, 1.0f, 1.0f, 0.0f);
            Gl.glVertex3f(0.5f, -0.5f, -0.5f);
            Gl.glColor4f(0.0f, 1.0f, 0.5f, 0.0f);
            Gl.glVertex3f(0.5f, -0.5f, 0.5f);
            Gl.glColor4f(0.0f, 1.0f, 0.5f, 0.0f);
            Gl.glVertex3f(-0.5f, -0.5f, -0.5f);
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

            if (e.KeyCode == Keys.D1)
                rotation(1f, 0, 0);
            if (e.KeyCode == Keys.D2)
                rotation(0, 1f, 0);
            if (e.KeyCode == Keys.D3)
                rotation(0, 0, 1f);

            if (e.KeyCode == Keys.Space)
                timer1.Stop();
            if (e.KeyCode == Keys.Enter)
                timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            rotation(0f, 1f, 1f);
        }
    }
}
