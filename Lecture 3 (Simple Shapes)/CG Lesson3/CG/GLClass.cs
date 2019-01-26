using CsGL.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG
{
    public class GLClass : OpenGLControl
    {

        protected override void InitGLContext()
        {
            base.InitGLContext();


        }

        public override void glDraw()
        {
            base.glDraw();
            //drawTriangle();
            //drawPoints();
            //drawSquare();
            //drawLines();
            drawTwoShapes();
        }

        void drawTriangle()
        {
            GL.glBegin(GL.GL_TRIANGLES);
            GL.glColor3d(1, 0, 0);
            GL.glVertex3d(-1, -1, -1);
            GL.glColor3d(0, 1, 0);
            GL.glVertex3d(1, -1, -1);
            GL.glColor3d(0, 0, 1);
            GL.glVertex3d(0, 1, -1);
            GL.glEnd();
        }

        void drawSquare()
        {
            GL.glBegin(GL.GL_POLYGON);
            GL.glColor3d(1, 1, 0);
            GL.glVertex3d(0.5, 0.5, 0);
            GL.glVertex3d(-0.5, 0.5, 0);
            GL.glVertex3d(-0.5, -0.5, 0);
            GL.glVertex3d(0.5, -0.5, 0);
            GL.glEnd();
        }

        void drawLines()
        {
            GL.glBegin(GL.GL_LINES);
            GL.glColor3d(1, 1, 0);
            GL.glVertex3d(0.5, 0.5, 0);
            GL.glVertex3d(-0.5, 0.5, 0);
            GL.glVertex3d(-0.5, -0.5, 0);
            GL.glVertex3d(0.5, -0.5, 0);
            GL.glEnd();
        }

        void drawPoints()
        {
            GL.glPointSize(50);
            GL.glBegin(GL.GL_POINTS);
            GL.glColor3d(1, 0, 0);
            GL.glVertex3d(-1, -1, -1);
            GL.glColor3d(0, 1, 0);
            GL.glVertex3d(1, -1, -1);
            GL.glColor3d(0, 0, 1);
            GL.glVertex3d(0, 1, -1);
            GL.glEnd();
        }

        private void drawTwoShapes()
        {
            GL.glBegin(GL.GL_TRIANGLES);
            GL.glColor3d(1, 0, 0);
            GL.glVertex3f(-0.7f, 0f, 0.0f);
            GL.glColor3d(0, 1, 0);
            GL.glVertex3f(-0.3f, 0f, 0.0f);
            GL.glColor3d(0, 0, 1);
            GL.glVertex3f(-0.5f, 0.5f, 0.0f);
            GL.glEnd();


            GL.glBegin(GL.GL_POLYGON);
            GL.glColor3f(0, 0.7f, 0.70f);
            GL.glVertex3f(0.3f, 0f, 0.0f);
            GL.glVertex3f(0.7f, 0f, 0.0f);
            GL.glVertex3f(0.7f, 0.5f, 0.0f);
            GL.glVertex3f(0.3f, 0.5f, 0.0f);
            GL.glEnd();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

        }


    }


}
