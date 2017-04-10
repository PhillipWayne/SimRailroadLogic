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
    
        string[] allbits;       
        private object namebit;
        

        private void Track_Assign_Load(object sender, EventArgs e)
        {

        }



        //comboBox1.Items.Add


        private void button1_Click(object sender, EventArgs e)
        {
            namebit = Form2.knowbit;
            PictureBox pb = (PictureBox)namebit;


            List<string> refconver= new List<string>();

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
            pb.Tag= refconver.ToArray();

            this.Close();
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
