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
        string check;
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
            namebit = Form2.knowbit;
            PictureBox pb = (PictureBox)namebit;
            check = pb.Name;

            if (listBox1.SelectedItem != null)
            {
               
               
                switch (check)
                {

                    case "Track_component_at_a_45_degree_angle":
                        assignbit = listBox1.SelectedItem.ToString();
                        pb.Tag = assignbit;
                        MessageBox.Show(" Your "+ check + "\n\n" +"is now assigned the bit " + assignbit );
                        break;
                    case "Track_component_at_a_90_degree_angle":
                        assignbit = listBox1.SelectedItem.ToString();
                        pb.Tag = assignbit;
                        MessageBox.Show(" Your " + check +"\n\n" + " is now assigned the bit "  + assignbit);
                        break;
                    case "Track_component_at_a_135_degree_angle":
                        assignbit = listBox1.SelectedItem.ToString();
                        pb.Tag = assignbit;
                        MessageBox.Show(" Your " + check+ "\n\n" + " is now assigned the bit " + assignbit);
                        break;
                }
                
                
              
            }

        }


    }

    }

