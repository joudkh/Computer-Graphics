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

        protected override void InitGLContext()
        {
            base.InitGLContext();
        }

        float step = 0.5f;
        float eyeX = 0f, eyeY = 0f, eyeZ = 35f;
        float centerX = 0, centerY = 0, centerZ = 0;
        float upX = 0, upY = 1, upZ = 0;

        public override void glDraw()
        {
            GL.glClear(GL.GL_COLOR_BUFFER_BIT);
            GL.glLoadIdentity();

            GLU.gluLookAt(eyeX, eyeY, eyeZ, centerX, centerY, centerZ, upX, upY, upZ);

            drawMovTriangle();

            this.Refresh();
        }

        private void drawTriangle()
        {
            //GL.glTranslated(0, 0, 0);
            //GL.glRotated(60, 0, 1, 0);
            //GL.glScaled(1, 1, 1);

            GL.glColor3f(1.0f, 0.0f, 0.0f);
            GL.glBegin(GL.GL_TRIANGLES);
            GL.glVertex3d(1, 0, 0);
            GL.glVertex3d(-1, 0, 0);
            GL.glVertex3d(0, 2, 0);
            GL.glEnd();

        }

        private void drawMovTriangle()
        {
            GL.glPushMatrix();

            GL.glRotated(step3, 0, 0, 1);

            drawTriangle();
            GL.glPopMatrix();

            GL.glPushMatrix();

            GL.glTranslated(step2, step2, 0);
            GL.glScaled(step2 / 2, step2 / 2, step2 / 2);
            drawTriangle();
            GL.glPopMatrix();

        }

        public float step2 = 0,step3=0;
        public bool f = true;

        public override void Refresh()
        {
            base.Refresh();
            if (f)
            {
                if (step2 < 3)
                    step2 = step2 + 0.005f;
                else
                    f = false;
            }
            else
            {
                if (step2 > -3)
                    step2 = step2 - 0.005f;
                else
                    f = true;
            }

            step3 += 0.5f;

        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            GL.glMatrixMode(GL.GL_PROJECTION);
            GL.gluPerspective(20.0f, (double)Size.Width / (double)Size.Height, 0.1f, 100.0f);
            GL.glMatrixMode(GL.GL_MODELVIEW);
            GL.glLoadIdentity();
        }

        public void onKeyDown(object Sender, KeyEventArgs key)
        {
            if (key.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }


            if (key.KeyCode == Keys.Q)
            {
                eyeX += step;
            }
            if (key.KeyCode == Keys.W)
            {
                eyeX -= step;
            }
            if (key.KeyCode == Keys.E)
            {
                eyeY += step;
            }
            if (key.KeyCode == Keys.R)
            {
                eyeY -= step;
            }
            if (key.KeyCode == Keys.T)
            {
                eyeZ += step;
            }
            if (key.KeyCode == Keys.Y)
            {
                eyeZ -= step;
            }



            if (key.KeyCode == Keys.A)
            {
                centerX += step;
            }
            if (key.KeyCode == Keys.S)
            {
                centerX -= step;
            }
            if (key.KeyCode == Keys.D)
            {
                centerY += step;
            }
            if (key.KeyCode == Keys.F)
            {
                centerY -= step;
            }
            if (key.KeyCode == Keys.G)
            {
                centerZ += step;
            }
            if (key.KeyCode == Keys.H)
            {
                centerZ -= step;
            }


            if (key.KeyCode == Keys.Z)
            {
                upX += step;
            }
            if (key.KeyCode == Keys.X)
            {
                upX -= step;
            }
            if (key.KeyCode == Keys.C)
            {
                upY += step;
            }
            if (key.KeyCode == Keys.V)
            {
                upY -= step;
            }
            if (key.KeyCode == Keys.B)
            {
                upZ += step;
            }
            if (key.KeyCode == Keys.N)
            {
                upZ -= step;
            }
        }
    }
}
