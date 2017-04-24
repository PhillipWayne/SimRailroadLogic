using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using testsim;

namespace SimLogicRailRoad
{
   public class GettingPaintevent
    {
        private bool onlyone = true;

        public void painting(object obj)
        {
           
            SizeablePictureBox pb1 = (SizeablePictureBox)obj;

            pb1.Tag = (string[])pb1.Tag;


            string[] trk = (string[])pb1.Tag;

            switch (trk[1])
            {
                case "trk180":
                  
                    pb1.Paint += new PaintEventHandler(paintfortrack);
                    break;

            }
            string[] twosignal = (string[])pb1.Tag;

            switch (twosignal[1])
            {
                case "TH_W_signal":
                    
                    pb1.Paint += new PaintEventHandler(TH_W_Signal_Paint);
                    break;
            }

            string[] onesignal = (string[])pb1.Tag;

            switch (onesignal[1])
            {
                case "OH_E_Signal":
                    
                    pb1.Paint += new PaintEventHandler(OH_E_Signal_Paint);
                    break;
            }

            string[] switches = (string[])pb1.Tag;

            switch (switches[1])
            {
                case "SwitchBL":

                    pb1.Paint += new PaintEventHandler(Switch_BL_Paint);
                    break;
            }

        }


        private void Switch_BL_Paint(object sender, PaintEventArgs e)
        {

            Rectangle rect14 = new Rectangle(); // Horizontal Track
            rect14.Location = new Point(0, 35);
            rect14.Width = 10000;
            rect14.Height = 1;
            if (Form2.mouseenter == true )
            {
               
                SizeablePictureBox pb1 = (SizeablePictureBox)sender;
                Rectangle rect5 = new Rectangle();
                rect5.Location = new Point(0, 0);
                rect5.Width = 5;
                rect5.Height = 5;

                Rectangle rect6 = new Rectangle();
                rect6.Location = new Point(pb1.ClientRectangle.Width - 5, 0);
                rect6.Width = 5;
                rect6.Height = 5;

                Rectangle rect7 = new Rectangle();
                rect7.Location = new Point(0, pb1.ClientRectangle.Height - 5);
                rect7.Width = 5;
                rect7.Height = 5;

                Rectangle rect1 = new Rectangle();
                rect1.Location = new Point(pb1.ClientRectangle.Width - 5, pb1.ClientRectangle.Height - 5);
                rect1.Width = 5;
                rect1.Height = 5;
                e.Graphics.FillRectangle(Brushes.White, rect5);
                e.Graphics.FillRectangle(Brushes.White, rect6);
                e.Graphics.FillRectangle(Brushes.White, rect7);
                e.Graphics.FillRectangle(Brushes.White, rect1);
                
            }
            Pen whitePen = new Pen(Color.White, 1); // Angled Track

            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.FillRectangle(Brushes.White, rect14);
            e.Graphics.DrawLine(whitePen, 0, 105, 50, 45); // Angled Track Draw

            
            
                SizeablePictureBox pb = (SizeablePictureBox)sender;
            if (pb.Componentval != null)
            {
                if (pb.Componentval[6]=="1")
                {
                    e.Graphics.FillRectangle(Brushes.Red, rect14);
                   // Pen redPen = new Pen(Color.Red, 1);
                   // e.Graphics.DrawLine(redPen, 0, 105, 50, 45);
                }
                if (pb.Componentval[13] == "1")
                {



                    SizeablePictureBox pb1 = (SizeablePictureBox)sender;
                    pb1.Invalidate();

                
                    Rectangle rect15 = new Rectangle(); // Horizontal Track
                    rect15.Location = new Point(0, 35);
                   
                    rect15.Width = 5000;
                    rect14.Height = 1;
                    Rectangle rect16 = new Rectangle(); // Horizontal Track
                    rect16.Location = new Point(rect15.Width +20, 35);
                    rect16.Width = 5000;
                    rect14.Height = 1;
                    e.Graphics.FillRectangle(Brushes.Red, rect15);
                    e.Graphics.FillRectangle(Brushes.Red, rect16);
                    Pen white1Pen = new Pen(Color.White, 1); // Angled Track
                   

                    
                   
                    e.Graphics.DrawLine(white1Pen, 0, 105, 50, 45); // Angled Track Draw
                }


            }


        }

        private void TH_W_Signal_Paint(object sender, PaintEventArgs e)
        {
            /* if (copy == false)
             {
                 SizeablePictureBox pb = (SizeablePictureBox)sender;
                 rect.Width = pb.ClientRectangle.Width;
                 e.Graphics.FillRectangle(Brushes.White, rect);


             }
             if (copy == true)
             {
                 SizeablePictureBox pb = (SizeablePictureBox)gl;
                 rect.Width = pb.ClientRectangle.Width;
                 e.Graphics.FillRectangle(Brushes.White, rect);
             }
             */
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

            if (Form2.mouseenter == true)
            {
                SizeablePictureBox pb1 = (SizeablePictureBox)sender;
                Rectangle rect5 = new Rectangle();
                rect5.Location = new Point(0, 0);
                rect5.Width = 5;
                rect5.Height = 5;

                Rectangle rect6 = new Rectangle();
                rect6.Location = new Point(pb1.ClientRectangle.Width - 5, 0);
                rect6.Width = 5;
                rect6.Height = 5;

                Rectangle rect7 = new Rectangle();
                rect7.Location = new Point(0, pb1.ClientRectangle.Height - 5);
                rect7.Width = 5;
                rect7.Height = 5;

                Rectangle rect1 = new Rectangle();
                rect1.Location = new Point(pb1.ClientRectangle.Width - 5, pb1.ClientRectangle.Height - 5);
                rect1.Width = 5;
                rect1.Height = 5;
                e.Graphics.FillRectangle(Brushes.White, rect5);
                e.Graphics.FillRectangle(Brushes.White, rect6);
                e.Graphics.FillRectangle(Brushes.White, rect7);
                e.Graphics.FillRectangle(Brushes.White, rect1);
                
            }

            using (Pen pen = new Pen(Color.White, 2))
            {
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                e.Graphics.DrawEllipse(pen, rect8);
                e.Graphics.DrawEllipse(pen, rect12);

            }
            SizeablePictureBox pb = (SizeablePictureBox)sender;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.FillEllipse(Brushes.Black, rect8);
            e.Graphics.FillRectangle(Brushes.White, rect9);
            e.Graphics.FillRectangle(Brushes.White, rect10);
            e.Graphics.FillRectangle(Brushes.White, rect11);
            e.Graphics.FillEllipse(Brushes.Black, rect12);
            e.Graphics.FillRectangle(Brushes.White, rect13);
            if (pb.Componentval != null)
            {
                if (pb.Componentval[6] == "1")
                {
                    e.Graphics.FillRectangle(Brushes.Red, rect11);
                }

                if (pb.Componentval[2] == "1")
                {
                    e.Graphics.FillEllipse(Brushes.Green, rect8);
                }

                if (pb.Componentval[3] == "1")
                {
                    e.Graphics.FillEllipse(Brushes.Yellow, rect8);
                }


                if (pb.Componentval[5] == "1")
                {
                    e.Graphics.FillEllipse(Brushes.Red, rect8);
                }

                if (pb.Componentval[8] == "1")
                {
                    e.Graphics.FillEllipse(Brushes.Gray, rect8);
                }

                if (pb.Componentval[16] == "1")
                {
                    e.Graphics.FillEllipse(Brushes.Green, rect12);
                }
                if (pb.Componentval[14] == "1")
                {
                    e.Graphics.FillEllipse(Brushes.Yellow, rect12);
                }
                if (pb.Componentval[12] == "1")
                {
                    e.Graphics.FillEllipse(Brushes.Red, rect12);
                }
                if (pb.Componentval[10] == "1")
                {
                    e.Graphics.FillEllipse(Brushes.Gray, rect12);
                }
            }

        }
        private void paintfortrack(object sender, PaintEventArgs e)
        {



            Rectangle rect = new Rectangle();
            rect.Location = new Point(0, 35);
            rect.Height = 1;

            if (Form2.copy == false)
            {
                SizeablePictureBox pb = (SizeablePictureBox)sender;
                rect.Width = pb.ClientRectangle.Width;
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                e.Graphics.FillRectangle(Brushes.White, rect);


            }
            if (Form2.copy == true)
            {
                SizeablePictureBox pb = (SizeablePictureBox)Form2.gl;
                rect.Width = pb.ClientRectangle.Width;
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                e.Graphics.FillRectangle(Brushes.White, rect);
            }

            if (Form2.mouseenter == true)
            {
                SizeablePictureBox pb1 = (SizeablePictureBox)sender;
                Rectangle rect1 = new Rectangle();
                rect1.Location = new Point(0, 0);
                rect1.Width = 5;
                rect1.Height = 5;

                Rectangle rect2 = new Rectangle();
                rect2.Location = new Point(pb1.ClientRectangle.Width - 5, 0);
                rect2.Width = 5;
                rect2.Height = 5;

                Rectangle rect4 = new Rectangle();
                rect4.Location = new Point(0, pb1.ClientRectangle.Height - 5);
                rect4.Width = 5;
                rect4.Height = 5;

                Rectangle rect5 = new Rectangle();
                rect5.Location = new Point(pb1.ClientRectangle.Width - 5, pb1.ClientRectangle.Height - 5);
                rect5.Width = 5;
                rect5.Height = 5;
                e.Graphics.FillRectangle(Brushes.White, rect1);
                e.Graphics.FillRectangle(Brushes.White, rect2);
                e.Graphics.FillRectangle(Brushes.White, rect4);
                e.Graphics.FillRectangle(Brushes.White, rect5);
               
            }
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;



            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //This will be a bit that the user assigns the tracktrain
            SizeablePictureBox pb2 = (SizeablePictureBox)sender;
            if (pb2.Bitsofcomponents != null)
            {
                if (pb2.Componentval[2] == "1")
                {
                    e.Graphics.FillRectangle(Brushes.Red, rect);
                }

            }
            else
            {
                e.Graphics.FillRectangle(Brushes.White, rect);
            }
        }
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

            if ( Form2.mouseenter == true)
            {
                SizeablePictureBox pb1 = (SizeablePictureBox)sender;
                Rectangle rect6 = new Rectangle();
                rect6.Location = new Point(0, 0);
                rect6.Width = 5;
                rect6.Height = 5;

                Rectangle rect7 = new Rectangle();
                rect7.Location = new Point(pb1.ClientRectangle.Width - 5, 0);
                rect7.Width = 5;
                rect7.Height = 5;

                Rectangle rect8 = new Rectangle();
                rect8.Location = new Point(0, pb1.ClientRectangle.Height - 5);
                rect8.Width = 5;
                rect8.Height = 5;

                Rectangle rect9 = new Rectangle();
                rect9.Location = new Point(pb1.ClientRectangle.Width - 5, pb1.ClientRectangle.Height - 5);
                rect9.Width = 5;
                rect9.Height = 5;
                e.Graphics.FillRectangle(Brushes.White, rect6);
                e.Graphics.FillRectangle(Brushes.White, rect7);
                e.Graphics.FillRectangle(Brushes.White, rect8);
                e.Graphics.FillRectangle(Brushes.White, rect9);
                
            }
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
            if (Form2.copy == false)
            {
                SizeablePictureBox pb = (SizeablePictureBox)sender;
                if (pb.Componentval != null)
                {


                    if (pb.Componentval[2] == "1")
                    {
                        e.Graphics.FillEllipse(Brushes.Green, rect);
                    }

                    if (pb.Componentval[3] == "1")
                    {
                        e.Graphics.FillEllipse(Brushes.Yellow, rect);
                    }

                    if (pb.Componentval[6] == "1")
                    {
                        e.Graphics.FillRectangle(Brushes.Red, rect3);
                    }

                    if (pb.Componentval[5] == "1")
                    {
                        e.Graphics.FillEllipse(Brushes.Red, rect);
                    }

                    if (pb.Componentval[8] == "1")
                    {
                        e.Graphics.FillEllipse(Brushes.Gray, rect);
                    }



                }
            }
                if (Form2.copy == true) { 
                SizeablePictureBox pb = (SizeablePictureBox)Form2.gl;
                    if (pb.Componentval != null)
                    {


                        if (pb.Componentval[2] == "1")
                        {
                            e.Graphics.FillEllipse(Brushes.Green, rect);
                        }

                        if (pb.Componentval[3] == "1")
                        {
                            e.Graphics.FillEllipse(Brushes.Yellow, rect);
                        }


                        if (pb.Componentval[5] == "1")
                        {
                            e.Graphics.FillEllipse(Brushes.Red, rect);
                        }
                    if (pb.Componentval[6] == "1")
                    {
                        e.Graphics.FillRectangle(Brushes.Red, rect3);
                    }
                    if (pb.Componentval[8] == "1")
                        {
                            e.Graphics.FillEllipse(Brushes.Gray, rect);
                        }

                    }

                }
            }
           
        }

    }

