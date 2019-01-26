using CsGL.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CG
{
    public class GLClass : OpenGLControl
    {
        public GLClass():base()
        {
            this.KeyDown += new KeyEventHandler(onKeyDown);
        }

        public void onKeyDown(object Sender, KeyEventArgs key)
        {
            if (key.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        protected override void InitGLContext()
        {
            base.InitGLContext();
        }

        public override void glDraw()
        {
            base.glDraw();

            GL.gluLookAt(0, 0, 7, 0, 0, 0, 0, 1, 0);

            drawCube();
        }

        private void drawCube()
        {
            //Front Face (Cyan Color)
            GL.glBegin(GL.GL_POLYGON);
            GL.glColor3f(0.0f, 1.0f, 1.0f);
            GL.glVertex3f(0.0f, 1.0f, 1.0f);
            GL.glVertex3f(0.0f, 0.0f, 1.0f);
            GL.glVertex3f(1.0f, 0.0f, 1.0f);
            GL.glVertex3f(1.0f, 1.0f, 1.0f);
            GL.glEnd();

            //Up Face (Green Color)
            GL.glBegin(GL.GL_POLYGON);
            GL.glColor3f(0.0f, 1.0f, 0.0f);
            GL.glVertex3f(0.0f, 1.0f, 0.0f);
            GL.glVertex3f(0.0f, 1.0f, 1.0f);
            GL.glVertex3f(1.0f, 1.0f, 1.0f);
            GL.glVertex3f(1.0f, 1.0f, 0.0f);
            GL.glEnd();

            //Right Face (Yellow Color)
            GL.glBegin(GL.GL_POLYGON);
            GL.glColor3f(1.0f, 1.0f, 0.0f);
            GL.glVertex3f(1.0f, 1.0f, 0.0f);
            GL.glVertex3f(1.0f, 1.0f, 1.0f);
            GL.glVertex3f(1.0f, 0.0f, 1.0f);
            GL.glVertex3f(1.0f, 0.0f, 0.0f);
            GL.glEnd();

            //Left Face (Blue Color)
            GL.glBegin(GL.GL_POLYGON);
            GL.glColor3f(0.0f, 0.0f, 1.0f);
            GL.glVertex3f(0.0f, 1.0f, 0.0f);
            GL.glVertex3f(0.0f, 0.0f, 0.0f);
            GL.glVertex3f(0.0f, 0.0f, 1.0f);
            GL.glVertex3f(0.0f, 1.0f, 1.0f);
            GL.glEnd();

            //Back Face (Red Color)
            GL.glBegin(GL.GL_POLYGON);
            GL.glColor3f(1.0f, 0.0f, 0.0f);
            GL.glVertex3f(0.0f, 1.0f, 0.0f);
            GL.glVertex3f(1.0f, 1.0f, 0.0f);
            GL.glVertex3f(1.0f, 0.0f, 0.0f);
            GL.glVertex3f(0.0f, 0.0f, 0.0f);
            GL.glEnd();

            //Bottom Face (Purple Color)
            GL.glBegin(GL.GL_POLYGON);
            GL.glColor3f(1.0f, 0.0f, 1.0f);
            GL.glVertex3f(0.0f, 0.0f, 0.0f);
            GL.glVertex3f(1.0f, 0.0f, 0.0f);
            GL.glVertex3f(1.0f, 0.0f, 1.0f);
            GL.glVertex3f(0.0f, 0.0f, 1.0f);
            GL.glEnd();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            GL.glMatrixMode(GL.GL_PROJECTION);
            GL.gluPerspective(45.0f, (double)Size.Width / (double)Size.Height, 0.1f, 100.0f);
            GL.glMatrixMode(GL.GL_MODELVIEW);
            GL.glLoadIdentity();
        }


    }


}
