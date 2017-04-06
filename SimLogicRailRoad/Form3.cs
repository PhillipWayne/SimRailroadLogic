using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;


namespace testsim
{
    public delegate void Comm(object sender, EventArgs e);
    public partial class Form3 : Form
    {
        public Form3()
        {

            InitializeComponent();

            // One-Headed East Signal Handlers & Bitmap
            OH_E_Signal.Paint += new PaintEventHandler(OH_E_Signal_Paint);
            OH_E_Signal.MouseDown += new MouseEventHandler(pictureBox_OH_E_Signal_MouseDown);
            Bitmap bmp = new Bitmap(OH_E_Signal.ClientSize.Width, OH_E_Signal.ClientSize.Height);
            OH_E_Signal.DrawToBitmap(bmp, OH_E_Signal.ClientRectangle);
            OH_E_Signal.Image = bmp;

            // Horizontal Track Handlers & Bitmap
            H_Trk.Paint += new PaintEventHandler(H_Trk_Paint);
            H_Trk.MouseDown += new MouseEventHandler(pictureBox_H_Trk_MouseDown);
            Bitmap bmp1 = new Bitmap(H_Trk.ClientSize.Width, H_Trk.ClientSize.Height);
            H_Trk.DrawToBitmap(bmp1, H_Trk.ClientRectangle);
            H_Trk.Image = bmp1;

            // Two-Headed West Signal Handlers & Bitmap
            TH_W_Signal.Paint += new PaintEventHandler(TH_W_Signal_Paint);
            TH_W_Signal.MouseDown += new MouseEventHandler(pictureBox_TH_W_Signal_MouseDown);
            Bitmap bmp2 = new Bitmap(TH_W_Signal.ClientSize.Width, TH_W_Signal.ClientSize.Height);
            TH_W_Signal.DrawToBitmap(bmp2, TH_W_Signal.ClientRectangle);
            TH_W_Signal.Image = bmp2;

            // Switch Handlers & Bitmap
            Switch_BL.Paint += new PaintEventHandler(Switch_BL_Paint);
            Switch_BL.MouseDown += new MouseEventHandler(pictureBox_Switch_BL_MouseDown);
            Bitmap bmp3 = new Bitmap(Switch_BL.ClientSize.Width, Switch_BL.ClientSize.Height);
            Switch_BL.DrawToBitmap(bmp3, Switch_BL.ClientRectangle);
            Switch_BL.Image = bmp3;

        }

        //public int track;
        public static int sw;
        public static int trk_sig;
        public event Comm commbetween;
        //public static bool trk = false;


        // One-Headed East Signal MouseDown
        private void pictureBox_OH_E_Signal_MouseDown(object sender, MouseEventArgs e)
        {
            trk_sig = 1; // Changes Picturebox size in Form2
            OH_E_Signal.DoDragDrop(OH_E_Signal.Image, DragDropEffects.Copy);
        }

        // One-Headed East Signal Enter
        private void pictureBox_OH_E_Signal_Drag_enter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        // One-Headed East Signal Paint
        private void OH_E_Signal_Paint(object sender, PaintEventArgs e)
        {

            Rectangle rect = new Rectangle(); //Lamp 1
            rect.Location = new Point(27, 45);
            rect.Width = 14;
            rect.Height = 14;

            Rectangle rect1 = new Rectangle(); //Mast
            rect1.Location = new Point(12, 52);
            rect1.Width = 15;
            rect1.Height = 1;

            Rectangle rect2 = new Rectangle(); //IJ
            rect2.Location = new Point(0, 30);
            rect2.Width = 1;
            rect2.Height = 12;

            Rectangle rect3 = new Rectangle(); //Track
            rect3.Location = new Point(0, 35);
            rect3.Width = 10000;
            rect3.Height = 1;

            //Rectangle rect4 = new Rectangle(); //Lamp 2
            //rect4.Location = new Point(44, 45);
            //rect4.Width = 14;
            //rect4.Height = 14;

            Rectangle rect5 = new Rectangle(); //Base
            rect5.Location = new Point(12, 47);
            rect5.Width = 1;
            rect5.Height = 12;


            using (Pen pen = new Pen(Color.White, 2))
            {
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                e.Graphics.DrawEllipse(pen, rect);
                //e.Graphics.DrawEllipse(pen, rect4);

            }
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.FillEllipse(Brushes.Black, rect);
            e.Graphics.FillRectangle(Brushes.White, rect1);
            e.Graphics.FillRectangle(Brushes.White, rect2);
            e.Graphics.FillRectangle(Brushes.White, rect3);
            //e.Graphics.FillEllipse(Brushes.Black, rect4);
            e.Graphics.FillRectangle(Brushes.White, rect5);
        }

        // Horizontal Track MouseDown
        private void pictureBox_H_Trk_MouseDown(object sender, MouseEventArgs e)
        {
            trk_sig = 1; // Changes Picturebox size in Form2
            H_Trk.DoDragDrop(H_Trk.Image, DragDropEffects.Copy);
        }

        // Horizontal Track Enter
        private void pictureBox_H_Trk_Drag_enter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        // Horizontal Track Paint
        private void H_Trk_Paint(object sender, PaintEventArgs e)
        {

            //Rectangle rect6 = new Rectangle(); //IJ
            //rect6.Location = new Point(0, 30);
            //rect6.Width = 2;
            //rect6.Height = 12;

            Rectangle rect7 = new Rectangle(); //Track
            rect7.Location = new Point(0, 35);
            rect7.Width = 10000;
            rect7.Height = 1;

            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            //e.Graphics.FillRectangle(Brushes.White, rect6);
            e.Graphics.FillRectangle(Brushes.White, rect7);

        }

        // Two-Headed West Signal MouseDown
        private void pictureBox_TH_W_Signal_MouseDown(object sender, MouseEventArgs e)
        {
            trk_sig = 1; // Changes Picturebox size in Form2
            TH_W_Signal.DoDragDrop(TH_W_Signal.Image, DragDropEffects.Copy);
        }

        // Two-Headed West Signal Enter
        private void pictureBox_TH_W_Signal_Drag_enter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        // Two-Headed West Signal Paint
        private void TH_W_Signal_Paint(object sender, PaintEventArgs e)
        {

            Rectangle rect8 = new Rectangle(); //Bottom Unit Lamp
            rect8.Location = new Point(56, 45);
            rect8.Width = 14;
            rect8.Height = 14;

            Rectangle rect9 = new Rectangle(); //Mast
            rect9.Location = new Point(70, 52);
            rect9.Width = 15;
            rect9.Height = 1;

            Rectangle rect10 = new Rectangle(); //IJ
            rect10.Location = new Point(98, 30);
            rect10.Width = 1;
            rect10.Height = 12;

            Rectangle rect11 = new Rectangle(); //Track
            rect11.Location = new Point(0, 35);
            rect11.Width = 100;
            rect11.Height = 1;

            Rectangle rect12 = new Rectangle(); //Top Unit Lamp 
            rect12.Location = new Point(41, 45);
            rect12.Width = 14;
            rect12.Height = 14;

            Rectangle rect13 = new Rectangle(); //Base
            rect13.Location = new Point(85, 47);
            rect13.Width = 1;
            rect13.Height = 12;

            using (Pen pen = new Pen(Color.White, 2))
            {
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                e.Graphics.DrawEllipse(pen, rect8);
                e.Graphics.DrawEllipse(pen, rect12);

            }
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.FillEllipse(Brushes.Black, rect8);
            e.Graphics.FillRectangle(Brushes.White, rect9);
            e.Graphics.FillRectangle(Brushes.White, rect10);
            e.Graphics.FillRectangle(Brushes.White, rect11);
            e.Graphics.FillEllipse(Brushes.Black, rect12);
            e.Graphics.FillRectangle(Brushes.White, rect13);
        }

        // Switch (Bottom Left) MouseDown
        private void pictureBox_Switch_BL_MouseDown(object sender, MouseEventArgs e)
        {
            sw = 1; // Changes Picturebox size in Form2
            Switch_BL.DoDragDrop(Switch_BL.Image, DragDropEffects.Copy);
        }

        // Switch (Bottom Left) Enter
        private void pictureBox_Switch_BL_Drag_enter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        // Switch (Bottom Left) Paint
        private void Switch_BL_Paint(object sender, PaintEventArgs e)
        {

            Rectangle rect14 = new Rectangle(); // Horizontal Track
            rect14.Location = new Point(0, 35);
            rect14.Width = 10000;
            rect14.Height = 1;

            Pen whitePen = new Pen(Color.White, 1); // Angled Track

            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.FillRectangle(Brushes.White, rect14);
            e.Graphics.DrawLine(whitePen, 0, 105, 50, 45); // Angled Track Draw

        }
    }
}

     




















