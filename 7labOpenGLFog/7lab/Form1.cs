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

namespace _7lab
{
	public partial class Form1 : Form
	{
		float a = 0;
		float[] fogColor = { 1, 1, 1, 1 };

		public Form1()
		{
			InitializeComponent();
			simp.InitializeContexts();
			Glut.glutInit();
			Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);
			Gl.glEnable(Gl.GL_DEPTH_TEST);
			Gl.glMatrixMode(Gl.GL_PROJECTION);
			Gl.glLoadIdentity();
			Gl.glFrustum(-1, 1, -1, 1, 2, 10);

			Gl.glMatrixMode(Gl.GL_MODELVIEW);
			Gl.glLoadIdentity();
			Gl.glTranslated(0, 0, -6);

			Gl.glEnable(Gl.GL_BLEND);
			Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);

			Gl.glEnable(Gl.GL_FOG);
			Gl.glFogi(Gl.GL_FOG_MODE, Gl.GL_LINEAR);
			Gl.glFogfv(Gl.GL_FOG_COLOR, fogColor);
			Gl.glFogf(Gl.GL_FOG_DENSITY, 0.3f);
			Gl.glFogf(Gl.GL_FOG_START, 0.5f);
			Gl.glFogf(Gl.GL_FOG_END, 7);
		}

		void Draw(float angle)
		{
			Gl.glClearColor(255, 255, 255, 1);
			Gl.glViewport(0, 0, simp.Width, simp.Height);
			Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
			Gl.glClear(Gl.GL_DEPTH_BUFFER_BIT);

			Gl.glPushMatrix();
			Gl.glRotated(45, 1, 1, 0);
			Gl.glColor4f(1.0f, 0.0f, 0.0f, 1f);
			Gl.glRotatef(angle, 1, 1, 1);
			Gl.glTranslatef(0f, 0.9f, 0);
			Glut.glutSolidTorus(0.1f,0.2f,20,20);
			Gl.glPopMatrix();

			Gl.glPushMatrix();
			Gl.glColor4f(0.0f, 0f, 0.0f, 1f);
			Gl.glRotatef(angle, 0f, 1f, 0f);
			Gl.glTranslatef(1f, 0, 0);
			Gl.glScaled(0.3, 0.3, 0.3);
			Glut.glutWireIcosahedron();
			Gl.glPopMatrix();

			Gl.glPushMatrix();
			Gl.glColor4f(1.0f, 0.0f, 1.0f, 0.5f);
			Gl.glRotatef(angle, 1f, 0f, 0f);
			Glut.glutSolidCylinder(0.2f, 1f, 50, 50);
			Gl.glPopMatrix();

			simp.Invalidate();

		}


		private void simp_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Q)
			{
				a += 10;
				Draw(a);
			}

			if (e.KeyCode == Keys.X)
				timer1.Stop();
			if (e.KeyCode == Keys.Space)
				timer1.Start();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			a += 10;
			Draw(a);
		}

		private void simp_Load(object sender, EventArgs e)
		{

		}
	}
}
