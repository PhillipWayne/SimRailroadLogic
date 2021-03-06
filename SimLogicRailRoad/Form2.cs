﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
//using Trydragand_drop;
using System.Xml.Linq;
using System.Data.Sql;
using SimLogicRailRoad;
using RailRoadLogicSim;
using System.Reflection;
using System.Drawing.Drawing2D;

namespace testsim
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        private string forvalbit;
        bool capture = false;
        public static bool copy = false;
        private Point MouseDownLocation;
        public static  object gl;
        public static object knowbit;
        int rx;
        int ry;
        string f;
        Image text;
        int x;
        int y;
        public static bool simstart = false;
        private const int GridGap = 8;
        public string xmlfile;
        private int directxcheck;
        private int directycheck;
        private bool drophapp = false;
        private bool drophapp1 = false;
        private object ttxloc;
        private object pbloc;
        private bool checkcomp = false;
        public static object copypic;
        private bool Exit = false;
        private bool click = false;
        public static Dictionary<string, string> Bitsref;
        public static Dictionary<string, string> SimBits = new Dictionary<string, string>();
        public static bool mouseenter = false;
        private void pictureBox_Drag_enter(object sender, DragEventArgs e)
        {

            e.Effect = DragDropEffects.Copy;
        }
      
        private void pictureBox_Drag_Drop(object sender, DragEventArgs e)
        {

            if (Form3.txt == 1) // Ensures user selected Textbox
            {
                // Creates Textbox
                TextBox text1 = new TextBox();
                text1.Text = (string)e.Data.GetData(DataFormats.Text);
                text1.MouseMove += new MouseEventHandler(text_MouseMove);
                text1.MouseDown += new MouseEventHandler(pb_MouseDown);
                text1.MouseUp += new MouseEventHandler(pb_MouseButtonUp);
                text1.BorderStyle = BorderStyle.None;
                text1.Size = new Size(300, 24);
                text1.TextAlign = HorizontalAlignment.Center;
                text1.Font = new Font("Arial", 12, FontStyle.Bold);
                text1.BackColor = Color.Black;
                text1.ForeColor = Color.White;
                text1.Text = "TEXT";
                ttxloc = text1;

                Controls.Add(text1);
                drophapp = true;
                Form3.txt = 0; // Resets MouseDown in Form 3
                return;
            }

            {
                  SizeablePictureBox pb1 = new SizeablePictureBox();
                   
                   pb1.Tag = (string[])e.Data.GetData(typeof(string[]));
                  
                string[] trk=(string[])pb1.Tag;
                pb1.Width = 100;
                pb1.Height = 70;
                GettingPaintevent gpe = new GettingPaintevent();
                gpe.painting(pb1);
                pb1.Click += new EventHandler(PictureBox_Click);
                pb1.SizeMode = PictureBoxSizeMode.Normal;
                pb1.Cursor = Cursors.SizeAll;
                pb1.MouseMove += new MouseEventHandler(pb_MouseMove);
                pb1.MouseDown += new MouseEventHandler(pb_MouseDown);
                pb1.MouseUp += new MouseEventHandler(pb_MouseButtonUp);
                pb1.MouseDown += new MouseEventHandler(Focus_MouseDown);
                pb1.MouseEnter += new EventHandler(pb_MouseEnter);
                pb1.MouseLeave += new EventHandler(pb_MouseLeave);
                pb1.ContextMenuStrip = contextMenuStrip1;
                pbloc = pb1;
               
                Controls.Add(pb1);
                drophapp1 = true;
              
            }
        }
        private void PictureBox_Click(object sender, EventArgs e)
        {
            if (simstart == false)
            {
                var checkclick = this.Controls.OfType<SizeablePictureBox>().ToList();
                for (int i = 0; i < checkclick.Count; i++)
                {
                    if (checkclick[i].BorderStyle == BorderStyle.Fixed3D)
                    {
                        checkclick[i].BorderStyle = BorderStyle.None;
                    }

                }
                // click = true;
                SizeablePictureBox pb1 = (SizeablePictureBox)sender;
                pb1.BorderStyle = BorderStyle.Fixed3D;
            }
            if (simstart == true)
            {
                SizeablePictureBox pb = (SizeablePictureBox)sender;
                List<string> bitval = new List<string>();
                if (pb.Bitsofcomponents != null)
                {
                    string[] trk = (string[])pb.Tag;

                    switch (trk[1])
                    {
                        case "trk180":

                            if (pb.Bitsofcomponents[2] != null && pb.Bitsofcomponents[2] != "")
                            {
                                if (pb.Componentval[2] != "1")
                                    pb.Componentval[2] = "1";
                                else
                                    pb.Componentval[2] = "0";
                            }
                            SimBits.Add(pb.Bitsofcomponents[2], pb.Componentval[2]);
                            break;

                    }
                    string[] twosignal = (string[])pb.Tag;

                    switch (twosignal[1])
                    {
                        case "TH_W_signal":

                            if (pb.Bitsofcomponents[6] != null && pb.Bitsofcomponents[6] != "")
                            {
                                if (pb.Componentval[6] != "1")
                                    pb.Componentval[6] = "1";
                                else
                                    pb.Componentval[6] = "0";
                            }
                            SimBits.Add(pb.Bitsofcomponents[6], pb.Componentval[6]);
                            break;
                    }

                    string[] onesignal = (string[])pb.Tag;

                    switch (onesignal[1])
                    {
                        case "OH_E_Signal":

                            if (pb.Bitsofcomponents[6] != null && pb.Bitsofcomponents[6] != "")
                            {
                                if (pb.Componentval[6] != "1")
                                    pb.Componentval[6] = "1";

                                else
                                    pb.Componentval[6] = "0";
                            }
                            SimBits.Add(pb.Bitsofcomponents[6], pb.Componentval[6]);
                            break;
                    }

                    string[] switches = (string[])pb.Tag;

                    switch (switches[1])
                    {
                        case "SwitchBL":
                            if (pb.Bitsofcomponents[6] != null && pb.Bitsofcomponents[6] != "")
                            {
                                if (pb.Componentval[6] != "1")
                                    pb.Componentval[6] = "1";

                                else
                                    pb.Componentval[6] = "0";

                            }
                            SimBits.Add(pb.Bitsofcomponents[6], pb.Componentval[6]);
                            break;
                    }
                    Choosingtrack ct = new Choosingtrack();
                    string []defaultbits=ct.whichcomponent(sender);
                    for (int i = 0; i < defaultbits.Length; i++)
                    {   if(defaultbits[i]!=null)
                        SimBits.Add(defaultbits[i], "0");
                    }
                    
                    /*  if (pb.Bitsofcomponents != null)
                      {
                          bitval.AddRange(pb.Bitsofcomponents);
                          for (int i = 0; i < bitval.Count; i++)
                          {
                              if (bitval[i] != (""))
                              {
                                  SimBits.Add(bitval[i], "1");
                                  pb.Componentval[i] = "1";

                              }
                          }*/
                    pb.Update();
                    Simulation_Logic Sl = new Simulation_Logic();
                    Dictionary<string, string> results = (Dictionary<string, string>)Sl.GUI_Input(SimBits);
                    SimBits.Clear();

                    List<string> placeforval = new List<string>();
                    var pboxes = this.Controls.OfType<SizeablePictureBox>().ToList();
                    for (int i = 0; i < pboxes.Count; i++)
                    {
                        if (pboxes[i].Bitsofcomponents != null)
                        {
                            for (int n = 0; n < pboxes[i].Bitsofcomponents.Length; n++)
                            {
                                if (results.ContainsKey(pboxes[i].Bitsofcomponents[n]))
                                {

                                    results.TryGetValue(pboxes[i].Bitsofcomponents[n], out forvalbit);
                                    placeforval.Add(forvalbit);
                                }
                                else
                                {
                                    placeforval.Add("");
                                }


                            }
                            pboxes[i].Componentval = placeforval.ToArray();
                            pboxes[i].Invalidate();
                            pboxes[i].Update();
                            placeforval.Clear();
                        }
                    }
                }

            }
        }
        
        

        ////Creates a Box Around Image When Mouse is Over the Image
        void pb_MouseEnter(object sender, EventArgs e)
        {
            
            
            mouseenter = true;
            SizeablePictureBox pb = (SizeablePictureBox)sender;
            pb.Refresh();


        }



        void pb_MouseLeave(object sender, EventArgs e)
        {
            mouseenter = false;
            SizeablePictureBox pb = (SizeablePictureBox)sender;
            pb.Refresh();

        }



        // Picture Box MouseMove
        void pb_MouseMove(object sender, MouseEventArgs e)
        {
            
            if (capture == true)
            {

                // Code to move GUI Components    

                SizeablePictureBox pb = (SizeablePictureBox)sender;
                
                double Lf = Math.Round((e.X - MouseDownLocation.X) / 10.0) * 10; // Rounds X Mouse/Component Location
                double Tp = Math.Round((e.Y - MouseDownLocation.Y) / 10.0) * 10; // Rounds Y Mouse/Component Location

                // Converts Double to Integer
                int pb_Lf = Convert.ToInt32(Lf);
                int pb_Tp = Convert.ToInt32(Tp);

                directxcheck = e.X - MouseDownLocation.X;
                directycheck = e.Y - MouseDownLocation.Y;
                // New Component Location


                // if (e.X > 0 && e.X < this.ClientSize.Width)
                // {



                // pb_Lf < this.Size.Width
                if (pb.Left > 0 && pb.Right < this.ClientSize.Width)
                {
                    pb.Left += pb_Lf;


                }

                // = e.Y - MouseDownLocation.Y;
                else if (directxcheck > 0 && pb.Left <= 0)
                {
                    pb.Left += pb_Lf;
                }
                else if (pb.Left > 0 && directxcheck < 0)
                {
                    pb.Left += pb_Lf;
                }
                // Y
                // New Component Location
                // pb.Left += pb_Lf; // X
                if (pb.Top > 25 && pb.Bottom < this.ClientSize.Height)
                {
                    pb.Top += pb_Tp; // Y

                }
                else if (directycheck > 0 && pb.Top <= 25)
                {
                    pb.Top += pb_Tp;
                }
                else if (directycheck < 0 && pb.Top > 25)
                {
                    pb.Top += pb_Tp;
                }
                gl = sender;
            }

            gl = sender;
        }

        // Text Box MouseMove
        void text_MouseMove(object sender, MouseEventArgs e)
        {
            if (capture == true)
            {

                // Code to move GUI Components    

                TextBox text1 = (TextBox)sender;

                double Lf = Math.Round((e.X - MouseDownLocation.X) / 10.0) * 10; // Rounds X Mouse/Component Location
                double Tp = Math.Round((e.Y - MouseDownLocation.Y) / 10.0) * 10; // Rounds Y Mouse/Component Location

                // Converts Double to Integer
                int pb_Lf = Convert.ToInt32(Lf);
                int pb_Tp = Convert.ToInt32(Tp);

                text1.Left += pb_Lf;
                text1.Top += pb_Tp;
                gl = sender;
            }

            gl = sender;
        }

        // Picture Box Mouse Button Up
        void pb_MouseButtonUp(object sender, MouseEventArgs e)
        {
            //PictureBox pb = (PictureBox)sender;

            // pb.BorderStyle = BorderStyle.None;
            
            capture = false;
        }

        // Picture Box MouseDown
        void pb_MouseDown(object sender, MouseEventArgs e)
        {
            

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
                capture = true;
                gl = sender;
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                SizeablePictureBox pb = (SizeablePictureBox)sender;
                pb.BorderStyle = BorderStyle.Fixed3D;
            }

            gl = sender;
        }

        // Mouse Move (Picture Box & Text Box)
        void formmousemove(object send, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
            mouseenter = false;
            /* var pb1 = this.Controls.OfType<SizeablePictureBox>().ToList();
             for (int i = 0; i < pb1.Count; i++)
             {
                 pb1[i].Refresh();
             }*/
            if (drophapp == true)
            {
                // PictureBox location after it is dragged and dropped on the form
                TextBox ttx = (TextBox)ttxloc;
                double Lf = Math.Round((e.X - MouseDownLocation.X) / 10.0) * 10; // Rounds X Mouse/Component Location
                double Tp = Math.Round((e.Y - MouseDownLocation.Y) / 10.0) * 10; // Rounds Y Mouse/Component Location

                // Converts Double to Integer
                int ttx_Lf = Convert.ToInt32(Lf);
                int ttx_Tp = Convert.ToInt32(Tp);

                ttx.Left = ttx_Lf;
                ttx.Top = ttx_Tp;

                drophapp = false;
            }

            if (drophapp1 == true)
            {
                // PictureBox location after it is dragged and dropped on the form
                SizeablePictureBox pb = (SizeablePictureBox)pbloc;
                double Lf = Math.Round((e.X - MouseDownLocation.X) / 10.0) * 10; // Rounds X Mouse/Component Location
                double Tp = Math.Round((e.Y - MouseDownLocation.Y) / 10.0) * 10; // Rounds Y Mouse/Component Location

                // Converts Double to Integer
                int pb_Lf = Convert.ToInt32(Lf);
                int pb_Tp = Convert.ToInt32(Tp);

                pb.Left = pb_Lf;
                pb.Top = pb_Tp;

                drophapp1 = false;
            }
        }

        // Delete Click
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //  temp = 0;
            DialogResult result1 = MessageBox.Show("Are you sure you want delete this part?",
            "Warning about to delete part",
            MessageBoxButtons.YesNo);

            if (result1 == DialogResult.Yes)
            {

                PictureBox pb = (PictureBox)gl;

                Controls.Remove(pb);
                pb.Dispose();
                pb = null;
            }
        }

        //New Button
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want to save before you start a new Simulation", "Open New Simulation without saving?",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.No)
            {
                Form2 f2 = new Form2();
                f2.Show();
                this.Close();

                // leave the method
                return;
            }
            // If the user presses Yes to load previous data 
            if (result == DialogResult.Yes)
            {
                if (xmlfile == null)
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();

                    saveFileDialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        /*file_name = dialog.SafeFileName;*/
                        xmlfile = saveFileDialog.FileName;

                        if (File.Exists(xmlfile))
                        {
                            System.GC.Collect();
                            System.GC.WaitForPendingFinalizers();
                            File.Delete(xmlfile);

                        }
                        //This gets a collection of controls in this form and places them in an array
                        var pBoxes1 = this.Controls.OfType<SizeablePictureBox>().ToArray();

                        //This creates a list which passes the values of pBoxes to it
                        List<SizeablePictureBox> pbList1 = new List<SizeablePictureBox>(pBoxes1);
                        List<Information> work1 = new List<Information>();

                        // This is created so the string values are stored in the list Information
                        for (int i = 0; i < pbList1.Count; i++)
                        {
                           /* MemoryStream ms = new MemoryStream();
                            pBoxes1[i].Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            Byte[] a = ms.ToArray();

                            String text = Convert.ToBase64String(a);*/
                            try
                            {
                                Information go1 = new Information();
                                go1.Componentvalue = pBoxes1[i].Componentval;
                                go1.ComponentIden = (string[])pBoxes1[i].Tag;
                                go1.Bitsofcomponents = pBoxes1[i].Bitsofcomponents;
                                go1.Piclocx = pBoxes1[i].Location.X.ToString();
                                go1.Piclocy = pBoxes1[i].Location.Y.ToString();
                                work1.Add(go1);

                                // stores all the string values in the list go1
                                SaveXML.SaveData(work1, xmlfile);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        Form2 f21 = new Form2();
                        f21.Show();
                        this.Close();

                        return;
                    }
                }
                if (File.Exists(xmlfile))
                {

                    System.GC.Collect();
                    System.GC.WaitForPendingFinalizers();
                    File.Delete(xmlfile);


                    //This gets a collection of controls in this form and places them in an array
                    var pBoxes = this.Controls.OfType<SizeablePictureBox>().ToArray();

                    //This creates a list which passes the values of pBoxes to it
                    List<SizeablePictureBox> pbList = new List<SizeablePictureBox>(pBoxes);
                    List<Information> work = new List<Information>();

                    // This is created so the string values are stored in the list Information
                    for (int i = 0; i < pbList.Count; i++)
                    {
                      /*  MemoryStream ms = new MemoryStream();
                        pBoxes[i].Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        Byte[] a = ms.ToArray();

                        String text = Convert.ToBase64String(a);*/
                        try
                        {
                            Information go1 = new Information();
                            go1.Componentvalue = pBoxes[i].Componentval;
                            go1.ComponentIden = (string[])pBoxes[i].Tag;
                            go1.Bitsofcomponents = pBoxes[i].Bitsofcomponents;
                            go1.Piclocx = pBoxes[i].Location.X.ToString();
                            go1.Piclocy = pBoxes[i].Location.Y.ToString();
                            work.Add(go1);

                            // stores all the string values in the list go1
                            SaveXML.SaveData(work, xmlfile);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    Form2 f2 = new Form2();
                    f2.Show();
                    this.Close();
                }

            }




        }

        //Open Button
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter =
               "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            dialog.Title = "Pick your xml file to load";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                /*file_name = dialog.SafeFileName;*/
                xmlfile = dialog.FileName;

                if (File.Exists(xmlfile))
                {
                    var result = MessageBox.Show("Do you want to load last saved data", "Data load?",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question);

                    // If the no button was pressed ...
                    if (result == DialogResult.No)
                    {
                        // leave the method
                        return;
                    }
                    // If the user presses Yes to load previous data 
                    if (result == DialogResult.Yes)
                    {
                        var delpics = this.Controls.OfType<PictureBox>().ToArray();
                        List<PictureBox> deletepic = new List<PictureBox>(delpics);
                        for (int i = 0; i < deletepic.Count; i++)
                        {
                            Controls.Remove(delpics[i]);
                            delpics[i].Dispose();
                            delpics[i] = null;
                        }
                        // A new instance of the class is made into a list
                        List<Information> go12 = new List<Information>();

                        // This passes to the method deserialize the values go12 and string "data.xml"
                        Deserialize(go12, xmlfile);
                    }
                }
            }
        }

        //Save Button
        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            if (xmlfile == null)
            {

                SaveFileDialog saveFileDialog = new SaveFileDialog();

                saveFileDialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
                // saveFileDialog.CreatePrompt = true;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    /*file_name = dialog.SafeFileName;*/
                    xmlfile = saveFileDialog.FileName;

                    if (File.Exists(xmlfile))
                    {
                        saveFileDialog.OverwritePrompt = true;


                    }
                    //This gets a collection of controls in this form and places them in an array
                    var pBoxes1 = this.Controls.OfType<SizeablePictureBox>().ToArray();

                    //This creates a list which passes the values of pBoxes to it
                    List<SizeablePictureBox> pbList1 = new List<SizeablePictureBox>(pBoxes1);
                    List<Information> work1 = new List<Information>();

                    // This is created so the string values are stored in the list Information
                    for (int i = 0; i < pbList1.Count; i++)
                    {
                       /* MemoryStream ms = new MemoryStream();
                        pBoxes1[i].Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        Byte[] a = ms.ToArray();

                        String text = Convert.ToBase64String(a);*/
                        try
                        {
                            Information go1 = new Information();
                            go1.Componentvalue = pBoxes1[i].Componentval;
                            go1.ComponentIden = (string[])pBoxes1[i].Tag;
                            go1.Bitsofcomponents = pBoxes1[i].Bitsofcomponents;
                            go1.Piclocx = pBoxes1[i].Location.X.ToString();
                            go1.Piclocy = pBoxes1[i].Location.Y.ToString();
                            work1.Add(go1);

                            // stores all the string values in the list go1
                            SaveXML.SaveData(work1, xmlfile);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }

                }

                return;
            }
            if (File.Exists(xmlfile))
            {

                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
                File.Delete(xmlfile);
            }

            //This gets a collection of controls in this form and places them in an array
            var pBoxes = this.Controls.OfType<SizeablePictureBox>().ToArray();

            //This creates a list which passes the values of pBoxes to it
            List<SizeablePictureBox> pbList = new List<SizeablePictureBox>(pBoxes);
            List<Information> work = new List<Information>();

            // This is created so the string values are stored in the list Information
            for (int i = 0; i < pbList.Count; i++)
            {
               /* MemoryStream ms = new MemoryStream();
                pBoxes[i].Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                Byte[] a = ms.ToArray();

                String text = Convert.ToBase64String(a);*/
                try
                {
                    Information go1 = new Information();
                    go1.Componentvalue = pBoxes[i].Componentval;
                    go1.ComponentIden = (string[])pBoxes[i].Tag;
                    go1.Bitsofcomponents = pBoxes[i].Bitsofcomponents;
                    go1.Piclocx = pBoxes[i].Location.X.ToString();
                    go1.Piclocy = pBoxes[i].Location.Y.ToString();
                    work.Add(go1);

                    // stores all the string values in the list go1
                    SaveXML.SaveData(work, xmlfile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //Deserialize
        public void Deserialize(object obj, string fileName)
        {
            //This creates a new instance of xmlserializer which serializes the the obj but needs it's type
            var serializer = new XmlSerializer(obj.GetType());

            try
            {
                // Opens and reads data.xml using filestream
                using (var stream = File.OpenRead(fileName))
                {
                    //This deserializes the xml document in that current stream
                    var other = (List<Information>)(serializer.Deserialize(stream));

                    // This creates a new instance of the list Information and passes through the values in other
                    List<Information> goy = new List<Information>(other);

                    //This for loop goes until the number of items in other is reached
                    for (int i = 0; i < other.Count; i++)
                    {
                        f = goy[i].Componentpic;
                        rx = Int32.Parse(goy[i].Piclocx);
                        ry = Int32.Parse(goy[i].Piclocy);

                      /*  byte[] imagebytes = Convert.FromBase64String(f);
                        //
                        MemoryStream ms = new MemoryStream(imagebytes, 0, imagebytes.Length);
                        ms.Write(imagebytes, 0, imagebytes.Length);
                        Image image = Image.FromStream(ms, true);*/
                        SizeablePictureBox pb = new SizeablePictureBox();

                       // pb.Image = image;
                       // pb.Name = goy[i].Componentname;
                        pb.Tag = goy[i].ComponentIden;
                        pb.Componentval = goy[i].Componentvalue;
                        pb.Bitsofcomponents = goy[i].Bitsofcomponents;
                        GettingPaintevent gpe = new GettingPaintevent();
                        gpe.painting(pb);
                        pb.Click += new EventHandler(PictureBox_Click);
                        pb.SizeMode = PictureBoxSizeMode.Normal;
                        pb.Location = new Point(rx, ry);
                        pb.MouseMove += new MouseEventHandler(pb_MouseMove);
                        pb.MouseDown += new MouseEventHandler(pb_MouseDown);
                        pb.MouseUp += new MouseEventHandler(pb_MouseButtonUp);
                        pb.ContextMenuStrip = contextMenuStrip1;
                        Controls.Add(pb);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }

        //Save As Button
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {

                xmlfile = saveFileDialog.FileName;

                if (File.Exists(xmlfile))
                {
                    saveFileDialog.OverwritePrompt = true;

                }
                //This gets a collection of controls in this form and places them in an array
                var pBoxes = this.Controls.OfType<SizeablePictureBox>().ToArray();

                //This creates a list which passes the values of pBoxes to it
                List<SizeablePictureBox> pbList = new List<SizeablePictureBox>(pBoxes);
                List<Information> work = new List<Information>();

                // This is created so the string values are stored in the list Information
                for (int i = 0; i < pbList.Count; i++)
                {
                   /* MemoryStream ms = new MemoryStream();
                    pBoxes[i].Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    Byte[] a = ms.ToArray();

                    String text = Convert.ToBase64String(a);*/
                    try
                    {
                        Information go1 = new Information();
                        go1.Componentvalue = pBoxes[i].Componentval;
                        go1.ComponentIden = (string[])pBoxes[i].Tag;
                        go1.Bitsofcomponents = pBoxes[i].Bitsofcomponents;
                        go1.Piclocx = pBoxes[i].Location.X.ToString();
                        go1.Piclocy = pBoxes[i].Location.Y.ToString();
                        work.Add(go1);

                        // stores all the string values in the list go1
                        SaveXML.SaveData(work, xmlfile);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
        }

        //Exit Button
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Exit = true;
            var result = MessageBox.Show("Do you want to save before leaving the Simulation", "Leave Simulation without saving?",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.No)
            {
                Application.Exit();

                // leave the method
                return;
            }
            // If the user presses Yes to load previous data 
            if (result == DialogResult.Yes)
            {
                if (xmlfile == null)
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();

                    saveFileDialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        /*file_name = dialog.SafeFileName;*/
                        xmlfile = saveFileDialog.FileName;

                        if (File.Exists(xmlfile))
                        {
                            System.GC.Collect();
                            System.GC.WaitForPendingFinalizers();
                            File.Delete(xmlfile);

                        }
                        //This gets a collection of controls in this form and places them in an array
                        var pBoxes1 = this.Controls.OfType<SizeablePictureBox>().ToArray();

                        //This creates a list which passes the values of pBoxes to it
                        List<SizeablePictureBox> pbList1 = new List<SizeablePictureBox>(pBoxes1);
                        List<Information> work1 = new List<Information>();

                        // This is created so the string values are stored in the list Information
                        for (int i = 0; i < pbList1.Count; i++)
                        {
                           /* MemoryStream ms = new MemoryStream();
                            pBoxes1[i].Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            Byte[] a = ms.ToArray();

                            String text = Convert.ToBase64String(a);*/
                            try
                            {
                                Information go1 = new Information();
                                go1.Componentvalue = pBoxes1[i].Componentval;
                                go1.ComponentIden = (string[])pBoxes1[i].Tag;
                                go1.Bitsofcomponents = pBoxes1[i].Bitsofcomponents;
                                go1.Piclocx = pBoxes1[i].Location.X.ToString();
                                go1.Piclocy = pBoxes1[i].Location.Y.ToString();
                                work1.Add(go1);

                                // stores all the string values in the list go1
                                SaveXML.SaveData(work1, xmlfile);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        Application.Exit();
                        return;
                    }
                }
                if (File.Exists(xmlfile))
                {

                    System.GC.Collect();
                    System.GC.WaitForPendingFinalizers();
                    File.Delete(xmlfile);


                    //This gets a collection of controls in this form and places them in an array
                    var pBoxes = this.Controls.OfType<SizeablePictureBox>().ToArray();

                    //This creates a list which passes the values of pBoxes to it
                    List<SizeablePictureBox> pbList = new List<SizeablePictureBox>(pBoxes);
                    List<Information> work = new List<Information>();

                    // This is created so the string values are stored in the list Information
                    for (int i = 0; i < pbList.Count; i++)
                    {
                       /* MemoryStream ms = new MemoryStream();
                        pBoxes[i].Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        Byte[] a = ms.ToArray();

                        String text = Convert.ToBase64String(a);*/
                        try
                        {
                            Information go1 = new Information();
                            go1.Componentvalue = pBoxes[i].Componentval;
                            go1.ComponentIden = (string[])pBoxes[i].Tag;
                            go1.Bitsofcomponents = pBoxes[i].Bitsofcomponents;
                            go1.Piclocx = pBoxes[i].Location.X.ToString();
                            go1.Piclocy = pBoxes[i].Location.Y.ToString();
                            work.Add(go1);

                            // stores all the string values in the list go1
                            SaveXML.SaveData(work, xmlfile);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }

                }

            }


            Application.Exit();
        }

        //Undo Button
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //Redo Button
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //Cut Button
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //Copy Button
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        //Paste Button
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //Delete Button
        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)gl;
            if (pb == null)
            {
                MessageBox.Show("Please click on a component that you want to delete",
                          "Component not selected");


                return;
            }
            DialogResult result1 = MessageBox.Show("Are you sure you want delete this part?",
           "Warning about to delete part",
           MessageBoxButtons.YesNo);


            if (result1 == DialogResult.Yes)
            {



                Controls.Remove(pb);
                pb.Dispose();
                pb = null;
            }

        }

        //Bits Button
        private void bitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* Simulation sim = new Simulation();

             sim.Show();*/
        }

        //Start Sim Button
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*  if (File.Exists(xmlfile))
              {

                  System.GC.Collect();
                  System.GC.WaitForPendingFinalizers();
                  File.Delete(xmlfile);
              }*/

            //This gets a collection of controls in this form and places them in an array
            var pBoxes = this.Controls.OfType<SizeablePictureBox>().ToArray();

            //This creates a list which passes the values of pBoxes to it
            List<SizeablePictureBox> pbList = new List<SizeablePictureBox>(pBoxes);
            List<Information> work = new List<Information>();

            // This is created so the string values are stored in the list Information
            for (int i = 0; i < pbList.Count; i++)
            {
              /*  MemoryStream ms = new MemoryStream();
                pBoxes[i].Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                Byte[] a = ms.ToArray();
                */
               // String text = Convert.ToBase64String(a);
                try
                {
                    Information go1 = new Information();
                   // go1.Componentpic = text;

                    go1.Piclocx = pBoxes[i].Location.X.ToString();
                    go1.Piclocy = pBoxes[i].Location.Y.ToString();
                    work.Add(go1);

                    // stores all the string values in the list go1
                    // SaveXML.SaveData(work, xmlfile);
                    //After each component is saved it is removed of it's eventhandlers and contextmenu
                    if (pBoxes[i].BorderStyle == BorderStyle.Fixed3D)
                    {
                        pBoxes[i].BorderStyle = BorderStyle.None;
                    }

                    pBoxes[i].MouseEnter -= new EventHandler(pb_MouseEnter);
                    pBoxes[i].Cursor = Cursors.Arrow;
                    pBoxes[i].MouseLeave -= new EventHandler(pb_MouseLeave);
                  //  pBoxes[i].MouseMove -= new MouseEventHandler(pb_MouseMove);
                    pBoxes[i].MouseDown -= new MouseEventHandler(pb_MouseDown);
                    pBoxes[i].MouseUp -= new MouseEventHandler(pb_MouseButtonUp);
                    pBoxes[i].ContextMenuStrip = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }



            simstart = true;
            MakeBackgroundGrid();
            //Removes the contextmenustrip for form2
            this.ContextMenuStrip = null;
        }

        //Stop Sim Button
        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var pBoxes = this.Controls.OfType<SizeablePictureBox>().ToArray();

            //This creates a list which passes the values of pBoxes to it
            List<SizeablePictureBox> pbList = new List<SizeablePictureBox>(pBoxes);
            for (int i = 0; i < pbList.Count; i++)
            {
                //This adds all the event handlers back for each image and the contextmenustrip is added back
                pBoxes[i].Cursor = Cursors.SizeAll;
                pBoxes[i].MouseEnter += new EventHandler(pb_MouseEnter);
                pBoxes[i].MouseLeave += new EventHandler(pb_MouseLeave);
              //  pBoxes[i].MouseMove += new MouseEventHandler(pb_MouseMove);
                pBoxes[i].MouseDown += new MouseEventHandler(pb_MouseDown);
                pBoxes[i].MouseUp += new MouseEventHandler(pb_MouseButtonUp);
                pBoxes[i].ContextMenuStrip = contextMenuStrip1;
            }
            // addeds back the contextmenustrip to the form and assigns it to a method
            this.ContextMenuStrip = contextMenuStrip2;

            simstart = false;
            MakeBackgroundGrid();
            
        }

        //Copy
        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            copy = true;
            var checkborder = this.Controls.OfType<SizeablePictureBox>().ToList();
            for (int i = 0; i < checkborder.Count; i++)
            {
                if (checkborder[i].BorderStyle == BorderStyle.Fixed3D)
                {
                    checkborder[i].BorderStyle = BorderStyle.None;
                    SizeablePictureBox pb = new SizeablePictureBox();
                     pb.Width = checkborder[i].Width;
                    pb.Height = checkborder[i].Height;
                    pb.Tag = checkborder[i].Tag;
                    pb.Bitsofcomponents = checkborder[i].Bitsofcomponents;
                    pb.Componentval = checkborder[i].Componentval;
                    var eventsField = typeof(Component).GetField("events", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                    var eventHandlerList = eventsField.GetValue(checkborder[i]);
                    eventsField.SetValue(pb, eventHandlerList);
                    copypic = pb;
                    checkborder[i].BorderStyle = BorderStyle.Fixed3D;
                }

            }

            // PictureBox pb = (PictureBox)gl;
        }

        // Paste Tool Strip
        private void pasteToolStripMenuItem2_Click(object sender, EventArgs e)
        {

            if (copy == true)
            {


                SizeablePictureBox pb = (SizeablePictureBox)copypic;
                SizeablePictureBox kl = new SizeablePictureBox();
                var eventsField = typeof(Component).GetField("events", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                var eventHandlerList = eventsField.GetValue(pb);
                eventsField.SetValue(kl, eventHandlerList);

                kl.Left = x;
                kl.Top = y;
                kl.Name = pb.Name;
                kl.Width = pb.ClientSize.Width;
                kl.Height = pb.ClientSize.Height;
                
                kl.Tag = pb.Tag;
                kl.Componentval = pb.Componentval;
                kl.Bitsofcomponents = pb.Bitsofcomponents;
              
              //  kl.SizeMode = PictureBoxSizeMode.Normal;
                kl.Cursor = Cursors.SizeAll;
                kl.ContextMenuStrip = contextMenuStrip1;
                /*  kl.MouseMove += new MouseEventHandler(pb_MouseMove);
                  kl.MouseDown += new MouseEventHandler(pb_MouseDown);
                  kl.MouseUp += new MouseEventHandler(pb_MouseButtonUp);*/
                
                Controls.Add(kl);
                kl.Refresh();
                copy = false;

            }
        }

        // Form2 Load
        private void Form2_Load(object sender, EventArgs e)
        {
            List<object> bits = new List<object>();

            // Simulation.unique_bits.ToArray();
            string[] val = new string[Simulation.unique_bits.Count];
            Bitsref = new Dictionary<string, string>();
            for (int i = 0; i < Simulation.unique_bits.Count; i++)
            {

                val[i] = "null";
                Bitsref.Add(Simulation.unique_bits[i], val[i]);
            }


            MakeBackgroundGrid(); //Loads Background Grid


        }

        // Assign Tool Strip Event
        private void assignBitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            knowbit = gl;
            SizeablePictureBox pb = (SizeablePictureBox)gl;
            string[] bitform = (string[])pb.Tag;
            if (bitform[0] == "trk")
            {
                Track_Assign Trk = new Track_Assign();
                Trk.Show();
            }

            if (bitform[0] == "switch")
            {
                Switch_Assign SW = new Switch_Assign();
                SW.Show();
            }

            if (bitform[0] == "oneheadsignal")
            {
                Signal_Assign SIG = new Signal_Assign();
                SIG.Show();
            }
            if (bitform[0] == "twoheadsignal")
            {
                Signal_Assign_2H SIG2H = new Signal_Assign_2H();
                SIG2H.Show();
            }
        }

        // Ladder Logic Tool Strip
        private void ladderLogicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ladder_Logic_Selection ladder = new Ladder_Logic_Selection();
            ladder.Show();
        }

        // Toolbox Tool Strip
        private void componentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new testsim.Form3();
            f3.Show();
        }

        // Bit List Tool Strip
        private void bitListsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bit_And_Boolean_Lists bit = new Bit_And_Boolean_Lists();
            bit.Show();
        }

        //Grid Background Method for GUI - Form2
        private void MakeBackgroundGrid()

        {
            Bitmap bm = new Bitmap(ClientSize.Width, ClientSize.Height);
            for (int x = 0; x < ClientSize.Width; x += GridGap)
            {
                for (int y = 0; y < ClientSize.Height; y += GridGap)
                {
                    if (simstart == true)
                    {
                        bm.SetPixel(x, y, Color.Black);
                    }
                    else
                    {
                        bm.SetPixel(x, y, Color.White);
                    }
                }
            }
            BackgroundImage = bm;
        }

        //Form2 Close Event
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*  if (Exit == false)
              {
                  var result = MessageBox.Show("Do you want to save before leaving the Simulation", "Leave Simulation without saving?",
                                       MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Question);

                  // If the no button was pressed ...
                  if (result == DialogResult.No)
                  {
                      Application.Exit();

                      // leave the method
                      return;
                  }
              }*/
        }



        // Form2 Focus on Label1 when MouseDown so cursor in Textbox will hide
        private void Focus_MouseDown(object sender, MouseEventArgs e)
        {
            label1.Focus();
        }
             
        private void FormClick(object sender, EventArgs e)
        {
            var formclickcheck = this.Controls.OfType<SizeablePictureBox>().ToList();

            for(int i = 0; i < formclickcheck.Count; i++)
            {
                
               if(formclickcheck[i].BorderStyle == BorderStyle.Fixed3D)
                {
                    formclickcheck[i].BorderStyle = BorderStyle.None;
                }
            }

        }
    }
}