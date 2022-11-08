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

namespace _5lab
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			simp.InitializeContexts();
            Gl.glViewport(0, 0, simp.Width, simp.Height);
            Gl.glClearColor(1, 1, 1, 1);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            drawA();
            drawB();
            simp.Invalidate();
        }
        float[,] figureA = {
            { -0.5f, 0.2f },
            { -0.35f, 0.15f },
            { -0.3f, 0f },
            { -0.35f, -0.15f },
            { -0.5f, -0.2f },
            { -0.65f, -0.15f },
            { -0.7f, 0f },
            { -0.65f, 0.15f },
            { -0.5f, 0f }
        };

        float[,] figureB = {
            { 0f, 0f },
            { 0.1f, 0.1f },
            { 0.1f, -0.1f },
            { -0.1f, -0.1f },
            { -0.1f, 0.1f },
            { -0.15f, 0.15f },
            { 0.15f, 0.15f },
            { 0.15f, -0.15f },
            { -0.15f, -0.15f }
        };

        void drawA()
        {      
            //Восьмиугольник, фиолетовый, полигон
            Gl.glColor4f(1.0f, 0.0f, 1.0f, 0.0f);
            Gl.glLineWidth(1);
            Gl.glBegin(Gl.GL_POLYGON);
                for (int i = 0; i < 8; i++)
                    {
                        Gl.glVertex2f(figureA[i, 0], figureA[i, 1]);
                    }
            Gl.glEnd();

            // обрамление восьмиугольника, линия, темно фиолетовый
            Gl.glColor4f(0.1f, 0.0f, 0.1f, 0.0f);
            Gl.glLineWidth(2);
            Gl.glBegin(Gl.GL_LINE_LOOP);
                for (int i = 0; i < 8; i++)
                    {
                        Gl.glVertex2f(figureA[i, 0], figureA[i, 1]);
                    }
            Gl.glEnd();

            //точки восьмиугольника, черные
            Gl.glPointSize(3f);
            Gl.glColor3f(0, 0, 0);
            Gl.glBegin(Gl.GL_POINTS);
                for (int i = 0; i < 8; i++)
                    {
                        Gl.glVertex2f(figureA[i, 0], figureA[i, 1]);
                    }
            Gl.glEnd();

            //четырехугольник, красный, полигон
            Gl.glColor4f(1.0f, 0.0f, 0.0f, 0.0f);
            Gl.glBegin(Gl.GL_POLYGON);
                for (int i = 0; i < 8; i = i + 2)
                    {
                        Gl.glVertex2f(figureA[i, 0], figureA[i, 1]);
                    }
            Gl.glEnd();

            //обрамление четырехугольника
            Gl.glColor4f(0.0f, 0.0f, 0.0f,0.0f);
            Gl.glLineWidth(1);
            Gl.glBegin(Gl.GL_LINE_LOOP);
                for (int i = 0; i < 8; i = i + 2)
                    {
                        Gl.glVertex2f(figureA[i, 0], figureA[i, 1]);
                    }
            Gl.glEnd();

            //линии внутри четырехугольника
            Gl.glColor4f(0.0f, 0.0f, 0.0f, 0.0f);
            Gl.glLineWidth(1);
            Gl.glBegin(Gl.GL_LINE_LOOP);
                for (int i = 0; i < 8; i = i + 4)
                    {
                        Gl.glVertex2f(figureA[i, 0], figureA[i, 1]);
                    }
            Gl.glEnd();

            Gl.glColor4f(0.0f, 0.0f, 0.0f, 0.0f);
            Gl.glLineWidth(1);
            Gl.glBegin(Gl.GL_LINE_LOOP);
                for (int i = 2; i < 8; i = i + 4)
                    {
                        Gl.glVertex2f(figureA[i, 0], figureA[i, 1]);
                    }
            Gl.glEnd();

            //точка внутри фигуры
            Gl.glPointSize(4f);
            Gl.glColor4f(0.0f, 0.0f, 1.0f, 0.0f);
            Gl.glEnable(Gl.GL_POINT_SMOOTH);
            Gl.glBegin(Gl.GL_POINTS);
            Gl.glVertex2f(figureA[8, 0], figureA[8, 1]);
            Gl.glEnd();
            simp.Invalidate(); }

        void drawB()
        {
            // отрисовка фигуры B
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(2);
           //внутренняя часть
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2f(figureB[0, 0], figureB[0, 1]);
            Gl.glVertex2f(figureB[1, 0], figureB[1, 1]);
            Gl.glVertex2f(figureB[2, 0], figureB[2, 1]);
            Gl.glVertex2f(figureB[3, 0], figureB[3, 1]);
            Gl.glVertex2f(figureB[4, 0], figureB[4, 1]);
            Gl.glEnd();
            //внешняя часть
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2f(figureB[5, 0], figureB[5, 1]);
            Gl.glVertex2f(figureB[6, 0], figureB[6, 1]);
            Gl.glVertex2f(figureB[7, 0], figureB[7, 1]);
            Gl.glVertex2f(figureB[8, 0], figureB[8, 1]);
            Gl.glEnd();
            //точка
            Gl.glPointSize(6f);
            Gl.glEnable(Gl.GL_POINT_SMOOTH);
            Gl.glBegin(Gl.GL_POINTS);
            Gl.glVertex2f(figureB[0, 0], figureB[0, 0]);
            Gl.glEnd();

            simp.Invalidate();
        }

        float angleA = 0, angleB = 0, dxA = 0, dyA = 0, dzA = 0, dxB = 0, dyB = 0, dzB = 0, sA = 1, sB = 1;
        private void simp_KeyDown(object sender, KeyEventArgs e)
		{

            if (e.KeyCode == Keys.Escape)
                Application.Exit();

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glPushMatrix();
            Gl.glMatrixMode(Gl.GL_MODELVIEW);

            if (e.KeyCode == Keys.Q || e.KeyCode == Keys.E || e.KeyCode == Keys.D1 || e.KeyCode == Keys.D2 || e.KeyCode == Keys.D3 || e.KeyCode == Keys.D4 || e.KeyCode == Keys.D5 || e.KeyCode == Keys.W || e.KeyCode == Keys.D || e.KeyCode == Keys.A || e.KeyCode == Keys.S)
            {
                Gl.glScaled(sB, sB, 1);
                Gl.glRotated(angleB, 0, 0, 1);
                Gl.glTranslatef(dxB, dyB, dzB);
                drawB();
                Gl.glPopMatrix();

                Gl.glPushMatrix();
                Gl.glMatrixMode(Gl.GL_MODELVIEW);
                Gl.glScaled(sA, sA, 1);
                Gl.glRotated(angleA, 0, 0, 1);
                Gl.glTranslatef(dxA, dyA, dzA);
                drawA();
                Gl.glPopMatrix();
            }
            else
			{
                Gl.glScaled(sA, sA, 1);
                Gl.glRotated(angleA, 0, 0, 1);
                Gl.glTranslatef(dxA, dyA, dzA);
                drawA();
                Gl.glPopMatrix();

                Gl.glPushMatrix();
                Gl.glMatrixMode(Gl.GL_MODELVIEW);
                Gl.glScaled(sB, sB, 1);
                Gl.glRotated(angleB, 0, 0, 1);
                Gl.glTranslatef(dxB, dyB, dzB);
                drawB();
                Gl.glPopMatrix();
            }
                
            if (e.KeyCode == Keys.D4)// 4 - увеличение А
            {
                    sA += 0.1f;
                }
            if (e.KeyCode == Keys.D5)//5 - уменьшение Б
            {
                    sA -= 0.1f;
                }

            if (e.KeyCode == Keys.D8)// 8 - увеличение Б
            {
                    sB += 0.1f;
                }
            if (e.KeyCode == Keys.D9)//9 - уменьшение Б
            {
                    sB -= 0.1f;
                }

            if (e.KeyCode == Keys.D)// движение А вправо
            {
                    dxA += 0.1f;
                }
            if (e.KeyCode == Keys.A)// движение А влево
            {
                    dxA -= 0.1f;
                }

            if (e.KeyCode == Keys.Z)// движение В влево
                {
                    dxB -= 0.1f;
                }
            if (e.KeyCode == Keys.X)// движение В вправо
                {
                    dxB += 0.1f;
                }

            if (e.KeyCode == Keys.W)//движение А вверх
            {
                    dyA += 0.1f;
                }
            if (e.KeyCode == Keys.S)//движение А вниз
            {
                    dyA -= 0.1f;
                }

            if (e.KeyCode == Keys.C)// движение В вверх
                {            
                    dyB += 0.1f;
                }
            if (e.KeyCode == Keys.V)//движение В вниз
                {
                    dyB -= 0.1f;
                }

            if (e.KeyCode == Keys.D1)//1 - поворот по час А вокруг Б
            {
                    angleA += 10;
                }
            if (e.KeyCode == Keys.D2)// 2 - поворот против час А вокруг Б
            {
                    angleA -= 10;
                }

            if (e.KeyCode == Keys.D3)//3 - цикл А
            {
                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
                for (int i = 0; i < 160; i++)
                {
                    Gl.glPushMatrix();
                    Gl.glMatrixMode(Gl.GL_MODELVIEW);
                    Gl.glScaled(sB, sB, 1);
                    Gl.glRotated(angleB, 0, 0, 1);
                    Gl.glTranslatef(dxB, dyB, dzB);
                    drawB();
                    Gl.glPopMatrix();

                    Gl.glPushMatrix();
                    Gl.glMatrixMode(Gl.GL_MODELVIEW);
                    Gl.glScaled(sA, sA, 1);
                    Gl.glRotated(angleA, 0, 0, 1);
                    Gl.glTranslatef(dxA, dyA, dzA);
                    drawA();
                    Gl.glPopMatrix();
                    angleA += 30;
                }
            }
            if (e.KeyCode == Keys.D6)//6 - поворот по час Б
                {
                    angleB += 10;
                }
            if (e.KeyCode == Keys.D7)// 7 - поворот против час Б
                {
                    angleB -= 10;
                }
            simp.Invalidate();
        }
    }
}
