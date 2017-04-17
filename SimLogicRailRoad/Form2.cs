using System;
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
        bool copy = false;
        private Point MouseDownLocation;
        private object gl;
        public static object knowbit;
        int rx;
        int ry;
        string f;
        Image text;
        int x;
        int y;
        bool simstart = false;
        private const int GridGap = 8;
        public string xmlfile;
        private int directxcheck;
        private int directycheck;
        private bool drophapp = false;
        private bool drophapp1 = false;
        private object ttxloc;
        private object pbloc;
        private bool checkcomp = false;
        private bool Exit = false;
        private bool click = false;
        public static Dictionary<string, string> Bitsref;
        public static Dictionary<string, string> SimBits = new Dictionary<string, string>();
        private bool mouseenter = false;
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

                  switch(trk[1])
                   {
                       case "trk180":
                           pb1.Width = 100;
                           pb1.Height = 70;
                            pb1.Paint += new PaintEventHandler(paintfortrack);
                           break;

                   }
                   string[] twosignal = (string[])pb1.Tag;

                   switch (twosignal[1])
                   {
                       case "TH_W_signal":
                           pb1.Width = 100;
                           pb1.Height = 70;
                            pb1.Paint += new PaintEventHandler(TH_W_Signal_Paint);
                           break;
                   }
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
                /*
             if (Form3.img == 1) // Ensures user selected Signal/Track and not a Textbox
             {
                 //checkcomp = Form3.trk;

                 // Creates Tracks & Signals
                 SizeablePictureBox pb1 = new SizeablePictureBox();
                 pb1.Image = (Image)e.Data.GetData(DataFormats.Bitmap);

                 if (Form3.sw == 1) //Switch
                 {
                     pb1.Name = "Switch";
                     pb1.Width = 100;
                     pb1.Height = 140;
                     Form3.sw = 0; // Resets MouseDown in Form 3
                 }

                 if (Form3.sig == 1) //Signal
                 {
                     pb1.Name = "Signal";
                     pb1.Width = 100;
                     pb1.Height = 70;
                     Form3.sig = 0; // Resets MouseDown in Form 3
                 }

                 if (Form3.trk == 1) //Track
                 {
                     pb1.Name = "Track";
                     pb1.Width = 100;
                     pb1.Height = 70;
                     Form3.trk = 0; // Resets MouseDown in Form 3
                 }*/
                //pb1.Click += new EventHandler(PictureBox_Click);
                //    pb1.SizeMode = PictureBoxSizeMode.Normal;
                //    pb1.Cursor = Cursors.SizeAll;
                //    pb1.MouseMove += new MouseEventHandler(pb_MouseMove);
                //    pb1.MouseDown += new MouseEventHandler(pb_MouseDown);
                //    pb1.MouseUp += new MouseEventHandler(pb_MouseButtonUp);
                //    pb1.MouseDown += new MouseEventHandler(Focus_MouseDown);
                //    //pb1.MouseEnter += new EventHandler(pb_MouseEnter);
                //    //pb1.MouseLeave += new EventHandler(pb_MouseLeave);
                //    pb1.ContextMenuStrip = contextMenuStrip1;
                //    pbloc = pb1;
                //    if (checkcomp == true)
                //    {
                //        pb1.Name = "Track";
                //    }
                //    Controls.Add(pb1);
                //    drophapp1 = true;
                //    Form3.img = 0; // Resets MouseDown in for PictureBox (Track/Signal) Form 3
              //  }
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
                    bitval.AddRange(pb.Bitsofcomponents);
                    for (int i = 0; i < bitval.Count; i++)
                    {
                        if (bitval[i] != (""))
                        {
                            SimBits.Add(bitval[i], "1");
                            pb.Componentval[i] = "1";

                        }
                    }
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

            gl = sender;
        }

        // Mouse Move (Picture Box & Text Box)
        void formmousemove(object send, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;

            /* var checkborder = this.Controls.OfType<PictureBox>().ToList();
             for (int i = 0; i < checkborder.Count; i++)
             {
                 if (checkborder[i].BorderStyle == BorderStyle.FixedSingle)
                 {
                     checkborder[i].BorderStyle = BorderStyle.None;
                 }
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
                PictureBox pb = (PictureBox)pbloc;
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
                        var pBoxes1 = this.Controls.OfType<PictureBox>().ToArray();

                        //This creates a list which passes the values of pBoxes to it
                        List<PictureBox> pbList1 = new List<PictureBox>(pBoxes1);
                        List<Information> work1 = new List<Information>();

                        // This is created so the string values are stored in the list Information
                        for (int i = 0; i < pbList1.Count; i++)
                        {
                            MemoryStream ms = new MemoryStream();
                            pBoxes1[i].Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            Byte[] a = ms.ToArray();

                            String text = Convert.ToBase64String(a);
                            try
                            {
                                Information go1 = new Information();
                                go1.Componentpic = text;
                                go1.Bitsofcomponents = (string[])pBoxes1[i].Tag;
                                go1.Componentname = pBoxes1[i].Name;
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
                    var pBoxes = this.Controls.OfType<PictureBox>().ToArray();

                    //This creates a list which passes the values of pBoxes to it
                    List<PictureBox> pbList = new List<PictureBox>(pBoxes);
                    List<Information> work = new List<Information>();

                    // This is created so the string values are stored in the list Information
                    for (int i = 0; i < pbList.Count; i++)
                    {
                        MemoryStream ms = new MemoryStream();
                        pBoxes[i].Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        Byte[] a = ms.ToArray();

                        String text = Convert.ToBase64String(a);
                        try
                        {
                            Information go1 = new Information();
                            go1.Componentpic = text;
                            go1.Bitsofcomponents = (string[])pBoxes[i].Tag;
                            go1.Componentname = pBoxes[i].Name;
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
                    var pBoxes1 = this.Controls.OfType<PictureBox>().ToArray();

                    //This creates a list which passes the values of pBoxes to it
                    List<PictureBox> pbList1 = new List<PictureBox>(pBoxes1);
                    List<Information> work1 = new List<Information>();

                    // This is created so the string values are stored in the list Information
                    for (int i = 0; i < pbList1.Count; i++)
                    {
                        MemoryStream ms = new MemoryStream();
                        pBoxes1[i].Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        Byte[] a = ms.ToArray();

                        String text = Convert.ToBase64String(a);
                        try
                        {
                            Information go1 = new Information();
                            go1.Componentpic = text;
                            go1.Bitsofcomponents = (string[])pBoxes1[i].Tag;
                            go1.Componentname = pBoxes1[i].Name;
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
            var pBoxes = this.Controls.OfType<PictureBox>().ToArray();

            //This creates a list which passes the values of pBoxes to it
            List<PictureBox> pbList = new List<PictureBox>(pBoxes);
            List<Information> work = new List<Information>();

            // This is created so the string values are stored in the list Information
            for (int i = 0; i < pbList.Count; i++)
            {
                MemoryStream ms = new MemoryStream();
                pBoxes[i].Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                Byte[] a = ms.ToArray();

                String text = Convert.ToBase64String(a);
                try
                {
                    Information go1 = new Information();
                    go1.Componentpic = text;
                    go1.Bitsofcomponents = (string[])pBoxes[i].Tag;
                    go1.Componentname = pBoxes[i].Name;
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

                        byte[] imagebytes = Convert.FromBase64String(f);
                        //
                        MemoryStream ms = new MemoryStream(imagebytes, 0, imagebytes.Length);
                        ms.Write(imagebytes, 0, imagebytes.Length);
                        Image image = Image.FromStream(ms, true);
                        PictureBox pb = new PictureBox();

                        pb.Image = image;
                        pb.Name = goy[i].Componentname;
                        pb.Tag = goy[i].Bitsofcomponents;
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
                var pBoxes = this.Controls.OfType<PictureBox>().ToArray();

                //This creates a list which passes the values of pBoxes to it
                List<PictureBox> pbList = new List<PictureBox>(pBoxes);
                List<Information> work = new List<Information>();

                // This is created so the string values are stored in the list Information
                for (int i = 0; i < pbList.Count; i++)
                {
                    MemoryStream ms = new MemoryStream();
                    pBoxes[i].Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    Byte[] a = ms.ToArray();

                    String text = Convert.ToBase64String(a);
                    try
                    {
                        Information go1 = new Information();
                        go1.Componentpic = text;
                        go1.Bitsofcomponents = (string[])pBoxes[i].Tag;
                        go1.Componentname = pBoxes[i].Name;
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
                        var pBoxes1 = this.Controls.OfType<PictureBox>().ToArray();

                        //This creates a list which passes the values of pBoxes to it
                        List<PictureBox> pbList1 = new List<PictureBox>(pBoxes1);
                        List<Information> work1 = new List<Information>();

                        // This is created so the string values are stored in the list Information
                        for (int i = 0; i < pbList1.Count; i++)
                        {
                            MemoryStream ms = new MemoryStream();
                            pBoxes1[i].Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            Byte[] a = ms.ToArray();

                            String text = Convert.ToBase64String(a);
                            try
                            {
                                Information go1 = new Information();
                                go1.Componentpic = text;
                                go1.Bitsofcomponents = (string[])pBoxes1[i].Tag;
                                go1.Componentname = pBoxes1[i].Name;
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
                    var pBoxes = this.Controls.OfType<PictureBox>().ToArray();

                    //This creates a list which passes the values of pBoxes to it
                    List<PictureBox> pbList = new List<PictureBox>(pBoxes);
                    List<Information> work = new List<Information>();

                    // This is created so the string values are stored in the list Information
                    for (int i = 0; i < pbList.Count; i++)
                    {
                        MemoryStream ms = new MemoryStream();
                        pBoxes[i].Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        Byte[] a = ms.ToArray();

                        String text = Convert.ToBase64String(a);
                        try
                        {
                            Information go1 = new Information();
                            go1.Componentpic = text;
                            go1.Bitsofcomponents = (string[])pBoxes[i].Tag;
                            go1.Componentname = pBoxes[i].Name;
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
                    pBoxes[i].MouseEnter -= new EventHandler(pb_MouseEnter);

                    pBoxes[i].MouseLeave -= new EventHandler(pb_MouseLeave);
                    pBoxes[i].MouseMove -= new MouseEventHandler(pb_MouseMove);
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
                pBoxes[i].MouseMove += new MouseEventHandler(pb_MouseMove);
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
            // PictureBox pb = (PictureBox)gl;
        }

        // Paste Tool Strip
        private void pasteToolStripMenuItem2_Click(object sender, EventArgs e)
        {

            if (copy == true)
            {


                PictureBox pb = (PictureBox)gl;
                PictureBox kl = new PictureBox();
                kl.Image = pb.Image;
                kl.Left = x;
                kl.Top = y;
                kl.Name = pb.Name;
                kl.MouseMove += new MouseEventHandler(pb_MouseMove);
                kl.MouseDown += new MouseEventHandler(pb_MouseDown);
                kl.MouseUp += new MouseEventHandler(pb_MouseButtonUp);
                kl.Cursor = Cursors.SizeAll;
                //kl.MouseEnter += new EventHandler(pb_MouseEnter);
                //kl.MouseLeave += new EventHandler(pb_MouseLeave);
                kl.ContextMenuStrip = contextMenuStrip1;
                Controls.Add(kl);
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

            if (bitform[0] == "twoheadedsignal")
            {
                Signal_Assign SIG = new Signal_Assign();
                SIG.Show();
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
        private void paintfortrack(object sender, PaintEventArgs e)
        {



            Rectangle rect = new Rectangle();
            rect.Location = new Point(0, 35);
            rect.Height = 1;

            if (copy == false)
            {
                SizeablePictureBox pb = (SizeablePictureBox)sender;
                rect.Width = pb.ClientRectangle.Width;
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                e.Graphics.FillRectangle(Brushes.White, rect);


            }
            if (copy == true)
            {
                SizeablePictureBox pb = (SizeablePictureBox)gl;
                rect.Width = pb.ClientRectangle.Width;
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                e.Graphics.FillRectangle(Brushes.White, rect);
            }

            if (mouseenter == true)
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
            else {
                e.Graphics.FillRectangle(Brushes.White, rect);
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

            if (mouseenter == true)
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
                if (pb.Componentval[6] == "0")
                {
                    e.Graphics.FillRectangle(Brushes.Red, rect11);
                }
               
                if (pb.Componentval[2] == "1")
                {
                    e.Graphics.FillEllipse(Brushes.Green, rect12);
                }
                
                if (pb.Componentval[3] == "1")
                {
                    e.Graphics.FillEllipse(Brushes.Yellow, rect12);
                }
            

                if (pb.Componentval[5] == "1")
                {
                    e.Graphics.FillEllipse(Brushes.Red, rect12);
                }
             
                if(pb.Componentval[8] == "1")
                {
                    e.Graphics.FillEllipse(Brushes.Gray, rect12);
                }

                if (pb.Componentval[0] == "1")
                {
                    e.Graphics.FillEllipse(Brushes.Green, rect8);
                }
                if (pb.Componentval[1] == "1")
                {
                    e.Graphics.FillEllipse(Brushes.Yellow, rect8);
                }
                if (pb.Componentval[4] == "1")
                {
                    e.Graphics.FillEllipse(Brushes.Red, rect8);
                }
                if (pb.Componentval[7] == "1")
                {
                    e.Graphics.FillEllipse(Brushes.Gray, rect8);
                }
            }
            

            
        }
        private void FormClick(object sender, EventArgs e)
        {
            var formclickcheck = this.Controls.OfType<PictureBox>().ToList();

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