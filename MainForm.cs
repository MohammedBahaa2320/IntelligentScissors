using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IntelligentScissors
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        RGBPixel[,] ImageMatrix;

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Open the browsed image and display it
                string OpenedFilePath = openFileDialog1.FileName;
                ImageMatrix = ImageOperations.OpenImage(OpenedFilePath);
                ImageOperations.DisplayImage(ImageMatrix, pictureBox1);
            }
            txtWidth.Text = ImageOperations.GetWidth(ImageMatrix).ToString();
            txtHeight.Text = ImageOperations.GetHeight(ImageMatrix).ToString();
        }

        private void btnGaussSmooth_Click(object sender, EventArgs e)
        {
            double sigma = double.Parse(txtGaussSigma.Text);
            int maskSize = (int)nudMaskSize.Value;
            ImageMatrix = ImageOperations.GaussianFilter1D(ImageMatrix, maskSize, sigma);
            ImageOperations.DisplayImage(ImageMatrix, pictureBox2);
        }

        //private void pictureBox1_Click(object sender, EventArgs e)
        //{

        //    // Draw Rectange
        //    // Track Mouse
        //    // Draw Lines
        //    // When Clicked again - draw rectangle

        //    Bitmap image = new Bitmap(306,161);
        //    Graphics g = Graphics.FromImage(image);

        //    g.FillRectangle(Brushes.Black, 60, 60, 200, 200); // PositionPair, SizePair


        //    pictureBox1.Image = image;





        //}

        int MouseX;
        int MouseY;
        int count = 0;
        int x1 = 0, y1 = 0, x2 = 0, y2 = 0;
        Pen black = new Pen(Brushes.Black);

        Graphics g;
        private void pictureBox1_Click(object sender, MouseEventArgs e)
        {
            MouseX = e.X;
            MouseY = e.Y;
            Graphics g = pictureBox1.CreateGraphics(); // Draws Graphics made during last click 

            List<Rectangle> reclist = new List<Rectangle>();
            List<Point> edgelist = new List<Point>();

            // Draw Recatange (1st Click)
            if (count % 2 == 0)
            {
                // Draws Rectagle
                g.FillRectangle(Brushes.Black, MouseX - 15, MouseY - 15, 30, 30);
                reclist.Add(new Rectangle(MouseX - 15, MouseY - 15, 30, 30));

                // Records Mouse Position
                x1 = MouseX;
                y1 = MouseY;

                // Bugfix
                if (x2 != 0 || y2 != 0)
                g.DrawLine(black, x2, y2, x1, y1);
            }

            // Draws a line (2nd Click)
            if (count % 2 == 1)
            {
                // Records Mouse Position
                x2 = MouseX;
                y2 = MouseY;

                // Draws Line
                g.DrawLine(black, x2, y2, x1, y1);

                //Adds Line to list of point
                edgelist.Add(new Point(x1, y1));
                edgelist.Add(new Point(x2, y2));
                           
                // Adds another rectangle
                g.FillRectangle(Brushes.Black, MouseX - 15, MouseY - 15, 30, 30);
                reclist.Add(new Rectangle(MouseX - 15, MouseY - 15, 30, 30));

            }
            count++;

        }
        
    
    }
}