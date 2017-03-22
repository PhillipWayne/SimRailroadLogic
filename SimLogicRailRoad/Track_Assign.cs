using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using testsim;
using RailRoadLogicSim;

namespace SimLogicRailRoad
{
    public partial class Track_Assign : Form
    {
        public Track_Assign()
        {
            InitializeComponent();
        }
        public string[] bitsin;
        public string[] guibits;
        string[] allbits;
        public string[] lastofbit1;
        string assignbit;
        private object namebit;
        string check;
        

        private void Track_Assign_Load(object sender, EventArgs e)
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

                    comboBox1.Items.AddRange(allbits);
                    comboBox2.Items.AddRange(allbits);
                    comboBox3.Items.AddRange(allbits);
                    comboBox4.Items.AddRange(allbits);
                    comboBox5.Items.AddRange(allbits);
                    return;
                }

            }


            //comboBox1.Items.Add
        }

        private void button1_Click(object sender, EventArgs e)
        {
            namebit = Form2.knowbit;
            PictureBox pb = (PictureBox)namebit;


            List<string> refconver= new List<string>();

            if (comboBox1.SelectedItem != null)
            {
                refconver.Add(comboBox1.SelectedItem.ToString());
            }
            if (comboBox2.SelectedItem != null)
            {
                refconver.Add(comboBox2.SelectedItem.ToString());
            }
            if (comboBox3.SelectedItem != null)
            {
                refconver.Add(comboBox3.SelectedItem.ToString());
            }
            if (comboBox4.SelectedItem != null)
            {
                refconver.Add(comboBox4.SelectedItem.ToString());
            }
            if (comboBox5.SelectedItem != null)
            {
                refconver.Add(comboBox5.SelectedItem.ToString());
            }
          pb.Tag= refconver.ToArray();

            this.Close();
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
