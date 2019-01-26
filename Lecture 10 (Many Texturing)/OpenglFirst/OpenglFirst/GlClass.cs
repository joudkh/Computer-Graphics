using System;
using System.Drawing;
using System.Windows.Forms;
using CsGL.OpenGL;
using System.Threading;
using System.IO;
using System.Drawing.Imaging;

namespace OpenglFirst
{
	public class GlClass : OpenGLControl
	{
        public uint[] texture = new uint[7];    // Texture array

        public GlClass(): base()
		{
            this.KeyDown += new KeyEventHandler(OurView_OnKeyDown);
        }

        protected override void InitGLContext() 
		{
            GL.glClearColor(0.5f, 0.5f, 0.5f, 0.5f);            // Gray Background
            GL.glEnable(GL.GL_DEPTH_TEST);                      // Enables Depth Testing

            GL.glGenTextures(texture.Length, this.texture);         // to generate multiple texture


            LoadTextures(0, Directory.GetCurrentDirectory() + "\\sky\\front.bmp");
            LoadTextures(1, Directory.GetCurrentDirectory() + "\\sky\\back.bmp");
            LoadTextures(2, Directory.GetCurrentDirectory() + "\\sky\\up.bmp");
            LoadTextures(3, Directory.GetCurrentDirectory() + "\\sky\\down.bmp");
            LoadTextures(4, Directory.GetCurrentDirectory() + "\\sky\\right.bmp");
            LoadTextures(5, Directory.GetCurrentDirectory() + "\\sky\\left.bmp");
            LoadTextures(6, Directory.GetCurrentDirectory() + "\\road.bmp");

        }

        protected bool LoadTextures(int index, string file)
        {
            // A Bitmap is an object used to work with images defined by pixel data
            Bitmap image = null;

            try
            {
                // If the file doesn't exist or can't be found, an ArgumentException is thrown instead of
                // just returning null
                image = new Bitmap(file);
            }
            catch (System.ArgumentException)
            {
                MessageBox.Show("Could not load " + file + ".  Please make sure that Data is a subfolder from where the application is running.", "Error", MessageBoxButtons.OK);
            }
            if (image != null)
            {
                image.RotateFlip(RotateFlipType.RotateNoneFlipY);

                Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);

                BitmapData bitmapdata;
                bitmapdata = image.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);


                // Create Nearest Filtered Texture
                GL.glBindTexture(GL.GL_TEXTURE_2D, this.texture[index]);
                GL.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, GL.GL_NEAREST);
                GL.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, GL.GL_NEAREST);
                GL.glTexImage2D(GL.GL_TEXTURE_2D, 0, (int)GL.GL_RGB, image.Width, image.Height, 0, GL.GL_BGR_EXT, GL.GL_UNSIGNED_BYTE, bitmapdata.Scan0);

                image.UnlockBits(bitmapdata);
                image.Dispose();
                return true;
            }
            return false;
        }

        double t = -5, x = 0, z = 600f, w, y = -80.0f, tt = 0.1;


        public override void glDraw()
        {
            GL.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            GL.glLoadIdentity();

            GLU.gluLookAt(x, y, z, x + Math.Cos(t), y + Math.Sin(w), z + Math.Sin(t), 0, 1, 0);


            GL.glEnable(GL.GL_TEXTURE_2D);

            GL.glTranslatef(0, 0, 500);
            cube();

            GL.glBindTexture(GL.GL_TEXTURE_2D, this.texture[6]);
            land();

            GL.glDisable(GL.GL_TEXTURE_2D);


            this.Refresh();
        }

        private void land()
        {
            GL.glBegin(GL.GL_QUADS);
            // Bottom Face
            GL.glTexCoord2f(1.0f, 1.0f); GL.glVertex3f(-200.0f, -100.0f, -200.0f);
            GL.glTexCoord2f(0.0f, 1.0f); GL.glVertex3f(200.0f, -100.0f, -200.0f);
            GL.glTexCoord2f(0.0f, 0.0f); GL.glVertex3f(200.0f, -100.0f, 200.0f);
            GL.glTexCoord2f(1.0f, 0.0f); GL.glVertex3f(-200.0f, -100.0f, 200.0f);
            GL.glEnd();
            GL.glFlush();

        }

        private void cube()
        {

            GL.glBindTexture(GL.GL_TEXTURE_2D, this.texture[0]);
            GL.glBegin(GL.GL_QUADS);
            // Front Face
            GL.glTexCoord2f(0.0f, 0.0f); GL.glVertex3f(-300.0f, -300.0f, 300.0f);
            GL.glTexCoord2f(1.0f, 0.0f); GL.glVertex3f(300.0f, -300.0f, 300.0f);
            GL.glTexCoord2f(1.0f, 1.0f); GL.glVertex3f(300.0f, 300.0f, 300.0f);
            GL.glTexCoord2f(0.0f, 1.0f); GL.glVertex3f(-300.0f, 300.0f, 300.0f);
            GL.glEnd();

            GL.glBindTexture(GL.GL_TEXTURE_2D, this.texture[1]);
            GL.glBegin(GL.GL_QUADS);
            // Back Face
            GL.glTexCoord2f(1.0f, 0.0f); GL.glVertex3f(-300.0f, -300.0f, -300.0f);
            GL.glTexCoord2f(1.0f, 1.0f); GL.glVertex3f(-300.0f, 300.0f, -300.0f);
            GL.glTexCoord2f(0.0f, 1.0f); GL.glVertex3f(300.0f, 300.0f, -300.0f);
            GL.glTexCoord2f(0.0f, 0.0f); GL.glVertex3f(300.0f, -300.0f, -300.0f);
            GL.glEnd();

            GL.glBindTexture(GL.GL_TEXTURE_2D, this.texture[2]);
            GL.glBegin(GL.GL_QUADS);
            // Top Face
            GL.glTexCoord2f(0.0f, 1.0f); GL.glVertex3f(-300.0f, 300.0f, -300.0f);
            GL.glTexCoord2f(0.0f, 0.0f); GL.glVertex3f(-300.0f, 300.0f, 300.0f);
            GL.glTexCoord2f(1.0f, 0.0f); GL.glVertex3f(300.0f, 300.0f, 300.0f);
            GL.glTexCoord2f(1.0f, 1.0f); GL.glVertex3f(300.0f, 300.0f, -300.0f);
            GL.glEnd();

            GL.glBindTexture(GL.GL_TEXTURE_2D, this.texture[3]);
            GL.glBegin(GL.GL_QUADS);
            // Bottom Face
            GL.glTexCoord2f(1.0f, 1.0f); GL.glVertex3f(-300.0f, -300.0f, -300.0f);
            GL.glTexCoord2f(0.0f, 1.0f); GL.glVertex3f(300.0f, -300.0f, -300.0f);
            GL.glTexCoord2f(0.0f, 0.0f); GL.glVertex3f(300.0f, -300.0f, 300.0f);
            GL.glTexCoord2f(1.0f, 0.0f); GL.glVertex3f(-300.0f, -300.0f, 300.0f);
            GL.glEnd();

            GL.glBindTexture(GL.GL_TEXTURE_2D, this.texture[4]);
            GL.glBegin(GL.GL_QUADS);
            // Right face
            GL.glTexCoord2f(1.0f, 0.0f); GL.glVertex3f(300.0f, -300.0f, -300.0f);
            GL.glTexCoord2f(1.0f, 1.0f); GL.glVertex3f(300.0f, 300.0f, -300.0f);
            GL.glTexCoord2f(0.0f, 1.0f); GL.glVertex3f(300.0f, 300.0f, 300.0f);
            GL.glTexCoord2f(0.0f, 0.0f); GL.glVertex3f(300.0f, -300.0f, 300.0f);
            GL.glEnd();

            GL.glBindTexture(GL.GL_TEXTURE_2D, this.texture[5]);
            GL.glBegin(GL.GL_QUADS);
            // Left Face
            GL.glTexCoord2f(0.0f, 0.0f); GL.glVertex3f(-300.0f, -300.0f, -300.0f);
            GL.glTexCoord2f(1.0f, 0.0f); GL.glVertex3f(-300.0f, -300.0f, 300.0f);
            GL.glTexCoord2f(1.0f, 1.0f); GL.glVertex3f(-300.0f, 300.0f, 300.0f);
            GL.glTexCoord2f(0.0f, 1.0f); GL.glVertex3f(-300.0f, 300.0f, -300.0f);
            GL.glEnd();

            GL.glFlush();
        }

        protected override void OnSizeChanged(EventArgs e)
		{
            base.OnSizeChanged(e);
            Size s = Size;
            //GL.glClearDepth(1.0);

            GL.glMatrixMode(GL.GL_PROJECTION);
            GL.glLoadIdentity();
            //GL.gluPerspective(100, (double)s.Width / (double)s.Height, 0.1f, 100000);
            GL.gluPerspective(45, (double)s.Width / (double)s.Height, 0.1f, 100000);
            GL.glMatrixMode(GL.GL_MODELVIEW);
            GL.glLoadIdentity();
        }

        protected void OurView_OnKeyDown(object Sender, KeyEventArgs kea)
        {
            //if escape was pressed exit the application
            if (kea.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }

            if (kea.KeyCode == Keys.W)
            {
                x += Math.Cos(t);
                z += Math.Sin(t);
            }
            if (kea.KeyCode == Keys.A)
            {
                t -= tt;
            }
            if (kea.KeyCode == Keys.S)
            {
                x -= Math.Cos(t);
                z -= Math.Sin(t);
            }
            if (kea.KeyCode == Keys.D)
            {
                t += tt;
            }

            if (kea.KeyCode == Keys.NumPad8)
            {
                w += 0.1;
            }
            if (kea.KeyCode == Keys.NumPad2)
            {
                w -= 0.1;
            }
        }

    }
	
}
