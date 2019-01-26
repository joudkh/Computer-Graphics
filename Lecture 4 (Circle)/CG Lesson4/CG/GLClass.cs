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
            //drawLines();
            //drawTwoShapes();
            drawCircle();
        }

        void drawTwoTriangle()
        {
            // GL.glBegin(GL.GL_TRIANGLES);
            //GL.glBegin(GL.GL_TRIANGLE_STRIP);
            GL.glBegin(GL.GL_TRIANGLE_FAN);
            GL.glColor3d(1, 0, 0);
            GL.glVertex3d(-0.3, -0.2, 0);
            GL.glVertex3d(0.1, -0.2, 0);
            GL.glVertex3d(-0.1, 0.2, 0);

            GL.glColor3d(0, 1, 0);
            GL.glVertex3d(0.1, 0, 0);
            GL.glVertex3d(0.5, 0, 0);
            GL.glVertex3d(0.3, 0.4, 0);
            GL.glEnd();
        }

        void drawCircle()
        {
            GL.glBegin(GL.GL_TRIANGLE_FAN);
            
            // Center Point
            ////////////
            GL.glVertex3d(0, 0, 0);
            ////////////
            double R = 0.5;
            for(double O=0;O<=2*Math.PI;O=O+0.005)
            {
                // x2 + y2 = r2
                double y = Math.Sin(O) * R;
                double x = Math.Cos(O) * R;
                GL.glColor3d(x, y, 0);
                GL.glVertex3d(x, y, 0);
            }
            GL.glEnd();
        }

        void drawLines()
        {
            GL.glBegin(GL.GL_LINE_STRIP);
            GL.glColor3d(1, 1, 0);
            GL.glVertex3d(0.5, 0.5, 0);
            GL.glVertex3d(-0.5, 0.5, 0);
            GL.glVertex3d(-0.5, -0.5, 0);
            GL.glVertex3d(0.5, -0.5, 0);
            GL.glVertex3d(0.5, 0.5, 0);
            GL.glEnd();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

        }


    }


}
