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
using testsim;
using SimLogicRailRoad;

namespace RailRoadLogicSim
{
    public partial class AssignBitform : Form
    {
        public AssignBitform()
        {
            InitializeComponent();
        }
        public string[] bitsin;
        public string[] guibits;
        string [] allbits;
        public string [] lastofbit1;
        string assignbit;
        private object namebit;
        private void AssignBitform_Load(object sender, EventArgs e)
        {
            guibits = Simulation.bitssofbits;
            int n = Convert.ToInt32(guibits.Length);

            for (int i = 0; i < n; i++)
            {
                if (guibits[i] != null)
                {

                }

                else
                {
                    Array.Resize<string>(ref guibits, i);
                    //  listBox2.Items.AddRange(guibits);
                    bitsin = Form2.assinbits;
                    //  listBox1.Items.AddRange(bitsin);
                    lastofbit1 = Simulation.lastofbit;
                    List<String> bitsinas = new List<String>();
                    bitsinas.AddRange(guibits);
                    bitsinas.AddRange(bitsin);
                    bitsinas.AddRange(lastofbit1);
                    allbits = bitsinas.ToArray();

                    listBox1.Items.AddRange(allbits);

                    return;
                }

            }
        }
            private void listbox1_mouseclick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
               namebit =Form2.knowbit;
                PictureBox pb = (PictureBox)namebit;
               /* MemoryStream ms = new MemoryStream();
                pb.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                Byte[] a = ms.ToArray();

                String text = Convert.ToBase64String(a);
                switch (text)
                {

                    case 45:
                        pb.Image = RailRoadLogicSim.Properties.Resources.track_45;
                        pb.Name = "Pic";
                        pb.ContextMenuStrip = contextMenuStrip1;
                        this.Controls.Add(pb);
                        break;
                    case 90:
                        pb.Image = RailRoadLogicSim.Properties.Resources.track_90;
                        pb.Name = "Pic";
                        pb.ContextMenuStrip = contextMenuStrip1;
                        this.Controls.Add(pb);
                        break;
                    case 135:
                        pb.Image = RailRoadLogicSim.Properties.Resources.track_135;
                        pb.Name = "Pic";
                        pb.ContextMenuStrip = contextMenuStrip1;
                        this.Controls.Add(pb);
                        break;
                }
                */
                
                assignbit = listBox1.SelectedItem.ToString();
                pb.Tag = assignbit;
                MessageBox.Show("Your component is now assigned the bit "+ assignbit);
            }

        }


    }

    }

