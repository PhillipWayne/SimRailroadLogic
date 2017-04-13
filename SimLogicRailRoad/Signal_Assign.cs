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
    public partial class Signal_Assign : Form
    {
        public Signal_Assign()
        {
            InitializeComponent();
        }

        string[] allbits;
        private object namebit;


        private void Track_Assign_Load(object sender, EventArgs e)
        {


            allbits = Simulation.unique_bits.ToArray();

            comboBox1.Items.AddRange(allbits);
            comboBox2.Items.AddRange(allbits);
            comboBox3.Items.AddRange(allbits);
            comboBox4.Items.AddRange(allbits);
            comboBox5.Items.AddRange(allbits);
            comboBox6.Items.AddRange(allbits);
            comboBox7.Items.AddRange(allbits);
            comboBox8.Items.AddRange(allbits);
            comboBox9.Items.AddRange(allbits);

            namebit = Form2.knowbit;
            SizeablePictureBox pb = (SizeablePictureBox)namebit;


            if (pb.Bitsofcomponents != null)
            {

                string[] tagget = (string[])pb.Bitsofcomponents;
                //   string[] tagget = pb.Tag.ToString();

                comboBox1.Text = tagget[0];
                comboBox2.Text = tagget[1];
                comboBox3.Text = tagget[2];
                comboBox4.Text = tagget[3];
                comboBox5.Text = tagget[4];
                comboBox6.Text = tagget[5];
                comboBox7.Text = tagget[6];
                comboBox8.Text = tagget[7];
                comboBox9.Text = tagget[8];

                //comboBox1.Text = reass1(0).t;
            }


            return;
        }



        //comboBox1.Items.Add


        private void button1_Click(object sender, EventArgs e)
        {
            namebit = Form2.knowbit;
            SizeablePictureBox pb = (SizeablePictureBox)namebit;



            List<string> refconver = new List<string>();

            if (comboBox1.SelectedItem != null)
            {
                refconver.Add(comboBox1.SelectedItem.ToString());
            }
            else
                refconver.Add("");

            if (comboBox2.SelectedItem != null)
            {
                refconver.Add(comboBox2.SelectedItem.ToString());
            }
            else
                refconver.Add("");
            if (comboBox3.SelectedItem != null)
            {
                refconver.Add(comboBox3.SelectedItem.ToString());
            }
            else
                refconver.Add("");
            if (comboBox4.SelectedItem != null)
            {
                refconver.Add(comboBox4.SelectedItem.ToString());
            }
            else
                refconver.Add("");
            if (comboBox5.SelectedItem != null)
            {
                refconver.Add(comboBox5.SelectedItem.ToString());
            }
            else
                refconver.Add("");
            if (comboBox6.SelectedItem != null)
            {
                refconver.Add(comboBox6.SelectedItem.ToString());
            }
            else
            refconver.Add("");
            if (comboBox7.SelectedItem != null)
            {
                refconver.Add(comboBox7.SelectedItem.ToString());
            }
            else
                refconver.Add("");
            if (comboBox8.SelectedItem != null)
            {
                refconver.Add(comboBox8.SelectedItem.ToString());
            }
            else
                refconver.Add("");
            if (comboBox9.SelectedItem != null)
            {
                refconver.Add(comboBox9.SelectedItem.ToString());
            }
            else
                refconver.Add("");

            pb.Tag = refconver.ToArray();

            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}
