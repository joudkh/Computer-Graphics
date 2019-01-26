using CsGL.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CG
{
    public class GLClass : OpenGLControl
    {

        public uint texture;

        protected override void InitGLContext()
        {
            base.InitGLContext();

            LoadTexture(Directory.GetCurrentDirectory() + "\\Glass.bmp");
        }

        public bool LoadTexture(string file)
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
                //image.RotateFlip(RotateFlipType.RotateNoneFlipY);

                Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);

                BitmapData bitmapdata;
                bitmapdata = image.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);


                // Create Nearest Filtered Texture
                GL.glBindTexture(GL.GL_TEXTURE_2D, this.texture);

                GL.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, GL.GL_NEAREST);
                GL.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, GL.GL_NEAREST);
                GL.glTexImage2D(GL.GL_TEXTURE_2D, 0, (int)GL.GL_RGB, image.Width, image.Height, 0, GL.GL_BGR_EXT, GL.GL_UNSIGNED_BYTE, bitmapdata.Scan0);

                image.UnlockBits(bitmapdata);
                image.Dispose();
                return true;
            }
            return false;
        }

        public override void glDraw()
        {
            base.glDraw();

            GL.glEnable(GL.GL_TEXTURE_2D);
            GL.glBindTexture(GL.GL_TEXTURE_2D, texture);

            drawSquare();

            GL.glDisable(GL.GL_TEXTURE_2D);
        }

        void drawSquare()
        {
            GL.glBegin(GL.GL_POLYGON);
            GL.glTexCoord2d(0,0);
            GL.glVertex3d(0.5, 0.5, 0);
            GL.glTexCoord2d(1, 0);
            GL.glVertex3d(-0.5, 0.5, 0);
            GL.glTexCoord2d(1,1);
            GL.glVertex3d(-0.5, -0.5, 0);
            GL.glTexCoord2d(0, 1);
            GL.glVertex3d(0.5, -0.5, 0);
            GL.glEnd();
        }

        void drawSquare2()
        {
            GL.glBegin(GL.GL_POLYGON);
            GL.glTexCoord2d(0.2, 0.2);
            GL.glVertex3d(0.5, 0.5, 0);
            GL.glTexCoord2d(0.8, 0.2);
            GL.glVertex3d(-0.5, 0.5, 0);
            GL.glTexCoord2d(0.8, 0.8);
            GL.glVertex3d(-0.5, -0.5, 0);
            GL.glTexCoord2d(0.2, 0.8);
            GL.glVertex3d(0.5, -0.5, 0);
            GL.glEnd();
        }


        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

        }


    }


}
