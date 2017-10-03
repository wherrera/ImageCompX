using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageCompX
{
    public partial class Form1 : Form
    {
        Bitmap image_1;
        Bitmap image_2;

        public Form1()
        {
            InitializeComponent();
        }

        void LoadImage(string file)
        {
            Image img = Image.FromFile(file);

            if(image_1 == null)
            {
                image_1 = new Bitmap(img);
            }
            else
            {
                image_2 = new Bitmap(img);
            }

            pictureBox1.Image = image_1;
            pictureBox2.Image = image_2;

            if (image_1 != null && image_2 != null)
            {
                pictureBox3.Image = Compare.CompareImages(image_1, image_2);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream image = null;
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "images (*.png)|*.png|(*.tif)|*.tif|All files (*.*)|*.*";
            dialog.FilterIndex = 3;
            dialog.RestoreDirectory = true;
            dialog.Multiselect = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image_1 = null;
                image_2 = null;

                pictureBox1.Image = null;
                pictureBox2.Image = null;
                pictureBox3.Image = null;

                try
                {
                    foreach(string file in dialog.FileNames)
                    {
                        LoadImage(file);
                    }                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. " + ex.Message);
                    Console.Write(ex.StackTrace);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
