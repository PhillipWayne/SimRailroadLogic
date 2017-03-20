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

namespace testsim
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        //1

        //int temp = 0;
        Form3 f31 = new Form3();
        bool capture = false;
        bool copy = false;
        private Point MouseDownLocation;
        private object gl;
      public static object knowbit;
        int rx;
        int ry;
        string f;
        Image text;
        int  x;
        int y;
       bool simstart=false;
     public static string[] assinbits;
        
        // string file_name;
        // string text_read;
        static string[] bitsass;
        private void Form3_bridggap(object sender, EventArgs e)
        {
            if (simstart == false)
            {
                int temp = Form3.trkw;
                
                
                PictureBox pb = new PictureBox();
                pb.SizeMode = PictureBoxSizeMode.Normal;
                pb.Location = new Point(100, 75);
                pb.MouseMove += new MouseEventHandler(pb_MouseMove);
                pb.MouseDown += new MouseEventHandler(pb_MouseDown);
                pb.MouseUp += new MouseEventHandler(pb_MouseButtonUp);

                switch (temp)
                {
                    case 45:
                        pb.Image = SimLogicRailRoad.Properties.Resources.track_45;
                        pb.Name = "Track_component_at_a_45_degree_angle";
                        pb.ContextMenuStrip = contextMenuStrip1;
                        pb.Tag = "track";
                        this.Controls.Add(pb);
                        break;
                    case 90:
                        pb.Image = SimLogicRailRoad.Properties.Resources.track_90;
                        pb.Name = "Track_component_at_a_90_degree_angle";
                        pb.ContextMenuStrip = contextMenuStrip1;
                        pb.Tag = "track";
                        this.Controls.Add(pb);
                        break;
                    case 135:
                        pb.Image = SimLogicRailRoad.Properties.Resources.track_135;
                        pb.Name = "Track_component_at_a_135_degree_angle";
                        pb.ContextMenuStrip = contextMenuStrip1;
                        pb.Tag = "track";
                        this.Controls.Add(pb);
                        break;
                }


            }
        }

        void pb_MouseMove(object sender, MouseEventArgs e)
        {
            if (capture == true)
            {
                PictureBox pb = (PictureBox)sender;
                pb.Left += e.X - MouseDownLocation.X;
                pb.Top += e.Y - MouseDownLocation.Y;
                gl = sender;
            }
           
            gl = sender;
        }

        void pb_MouseButtonUp(object sender, MouseEventArgs e)
        {
            capture = false;
        }

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

       void formmousemove(object send,MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }
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

        //Toolbox Button

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
                if (File.Exists("data.xml"))
                {

                    System.GC.Collect();
                    System.GC.WaitForPendingFinalizers();
                    File.Delete("data.xml");
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
                        go1.Trk1 = text;

                        go1.Piclocx = pBoxes[i].Location.X.ToString();
                        go1.Piclocy = pBoxes[i].Location.Y.ToString();
                        work.Add(go1);

                        // stores all the string values in the list go1
                        SaveXML.SaveData(work, "data.xml");
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

        //Open Button
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* Form1 f1 = new Form1();
                        f1.Close();
                        this.Close();*/
            if (File.Exists("data.xml"))
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
                    Deserialize(go12, "data.xml");
                }
            }
        }

        //Save Button
        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (File.Exists("data.xml"))
            {

                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
                File.Delete("data.xml");
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
                    go1.Trk1 = text;

                    go1.Piclocx = pBoxes[i].Location.X.ToString();
                    go1.Piclocy = pBoxes[i].Location.Y.ToString();
                    work.Add(go1);

                    // stores all the string values in the list go1
                    SaveXML.SaveData(work, "data.xml");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void Deserialize(object obj, string fileName)
        {
            //This creates a new instance of xmlserializer which serializes the the obj but needs it's type
            var serializer = new XmlSerializer(obj.GetType());

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
                    f = goy[i].Trk1;
                    rx = Int32.Parse(goy[i].Piclocx);
                    ry = Int32.Parse(goy[i].Piclocy);
                    byte[] imagebytes = Convert.FromBase64String(f);
                    //
                    MemoryStream ms = new MemoryStream(imagebytes, 0, imagebytes.Length);
                    ms.Write(imagebytes, 0, imagebytes.Length);
                    Image image = Image.FromStream(ms, true);
                    PictureBox pb = new PictureBox();

                    pb.Image = image;
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

        //Save As Button
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //Exit Button
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //Form1 f1 = new Form1();
            //f1.Close();
            //this.Close();
            Application.Exit();
        }

        //Undo Button
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f31.Show();
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
            if (File.Exists("data.xml"))
            {

                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
                File.Delete("data.xml");
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
                    go1.Trk1 = text;

                    go1.Piclocx = pBoxes[i].Location.X.ToString();
                    go1.Piclocy = pBoxes[i].Location.Y.ToString();
                    work.Add(go1);

                    // stores all the string values in the list go1
                    SaveXML.SaveData(work, "data.xml");
                    //After each component is saved it is removed of it's eventhandlers and contextmenu
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
          /*  for (int i = 0; i < pbList.Count; i++)
            {
               
                     pBoxes[i].MouseMove -= new MouseEventHandler(pb_MouseMove);
                pBoxes[i].MouseDown -= new MouseEventHandler(pb_MouseDown);
                pBoxes[i].MouseUp -= new MouseEventHandler(pb_MouseButtonUp);
                pBoxes[i].ContextMenuStrip = null;
            }*/
            simstart = true;
            //Removes the contextmenustrip for form2
            this.ContextMenuStrip = null;
        }
       


        //Stop Sim Button
        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var pBoxes = this.Controls.OfType<PictureBox>().ToArray();

            //This creates a list which passes the values of pBoxes to it
            List<PictureBox> pbList = new List<PictureBox>(pBoxes);
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
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        { 

            copy = true;
            // PictureBox pb = (PictureBox)gl;
        }

      

        private void pasteToolStripMenuItem2_Click(object sender, EventArgs e)
        {

            if (copy == true)
            {


                PictureBox pb = (PictureBox)gl;
                PictureBox kl = new PictureBox();
                kl.Image = pb.Image;

                /* kl.Left = MousePosition.X;
                 kl.Top = MousePosition.Y;*/
                kl.Left = x;
                kl.Top = y;
                
                kl.MouseMove += new MouseEventHandler(pb_MouseMove);
                kl.MouseDown += new MouseEventHandler(pb_MouseDown);
                kl.MouseUp += new MouseEventHandler(pb_MouseButtonUp);
                kl.ContextMenuStrip = contextMenuStrip1;
                Controls.Add(kl);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           /* Simulation sim = new Simulation();

            // sim.Hide();

            sim.text_file_parse(file_name, text_read);*/

             bitsass = Simulation.bitassign;
          // int cnt = bitsass.Count;
          int  n = Convert.ToInt32(bitsass.Length);
           
            for (int i = 0; i < n; i++)
        {
                if (bitsass[i] != null)
                {
                  // bitsass[i]  = bitsass[i];
                }

                else
                {
                    Array.Resize<string>(ref bitsass, i);
                    assinbits = bitsass;
                    
                    return;
                }
        }
        

    }

        private void assignBitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            /*  ListBox lb = new ListBox();
              lb.Location = new System.Drawing.Point(100, 100);
              lb.Items.AddRange(assinbits);
              this.Controls.Add(lb);

              */
            knowbit=gl;
            AssignBitform assbit = new AssignBitform();
            assbit.Show();

        }

        private void ladderLogicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ladder_Logic_Selection ladder = new Ladder_Logic_Selection();
            ladder.Show();
        }

        private void componentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new testsim.Form3();
            f3.commbetween += new Comm(Form3_bridggap);
            //f3.ControlAdded += new ControlEventHandler(this.Form3_FormControlAdd);

            f3.Show();
        }

        private void toolboxToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bitListsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bit_And_Boolean_Lists bit = new Bit_And_Boolean_Lists();
            bit.Show();
        }

        //DB Test in Menu
        /*  private void testToolStripMenuItem_Click(object sender, EventArgs e)
          {
              testsim.Database db = new testsim.Database();

              db.Show();
          }*/
    }

}
