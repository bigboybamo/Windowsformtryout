using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace imagerotate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //button to rotate an image
        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap bmp = new Bitmap(pictureBox1.Image);
                bmp.RotateFlip(RotateFlipType.RotateNoneFlipX);
                pictureBox1.Image = bmp;
            }
            else
            {
                MessageBox.Show("no image");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        //button to clone a specific part of an image
        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap bmp = new Bitmap(pictureBox1.Image);
                Rectangle rect = new Rectangle(0, 0, 100, 100);
                Bitmap cloneImage = bmp.Clone(rect, PixelFormat.DontCare);
                pictureBox1.Image = cloneImage;
            }
            else
            {
                MessageBox.Show("No image");
            }


        }

        //button to change color of an image
        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            int x, y;
            for (x = 0; x < bmp.Width; x++)
            {
                for (y = 0; y < bmp.Height; y++)
                {
                    Color oldPixelcolor = bmp.GetPixel(x, y);
                    Color newPixelColor = Color.FromArgb(oldPixelcolor.B, 0, 0);
                    bmp.SetPixel(x, y, newPixelColor);
                }
            }
            pictureBox1.Image = bmp;
        }

        //invert color of image
        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            int x, y;
            for (x = 0; x < bmp.Width; x++)
            {
                for (y = 0; y < bmp.Height; y++)
                {
                    Color oldPixelcolor = bmp.GetPixel(x, y);
                    Color newPixelColor = Color.FromArgb(255 - oldPixelcolor.B,
                                                          255 - oldPixelcolor.R,
                                                          255 - oldPixelcolor.G);
                    bmp.SetPixel(x, y, newPixelColor);
                }
            }
            pictureBox1.Image = bmp;
        }

        //save picture after editing
        private void button5_Click(object sender, EventArgs e)
        {
            saveFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFD.FileName = "Save Image";
            saveFD.Filter = "JPEG|*.jpeg";
            if (saveFD.ShowDialog() != DialogResult.Cancel)
            {
                string savePath = saveFD.FileName;
                Bitmap bmp = new Bitmap(pictureBox1.Image);
                bmp.Save(savePath, ImageFormat.Jpeg);
            }


        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
