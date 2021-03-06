﻿using System;
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
        string forvalbit;
        
        private void Track_Assign_Load(object sender, EventArgs e)
        {
            allbits = Simulation.unique_bits.ToArray();







            comboBox1.Items.AddRange(allbits);



            comboBox2.Items.AddRange(allbits);



            comboBox3.Items.AddRange(allbits);



            comboBox4.Items.AddRange(allbits);



            comboBox5.Items.AddRange(allbits);







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
                        }


        }
        //comboBox1.Items.Add


        private void button1_Click(object sender, EventArgs e)
        {
            namebit = Form2.knowbit;
            SizeablePictureBox pb = (SizeablePictureBox)namebit;


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
            {
                refconver.Add("");
            }
            pb.Bitsofcomponents= refconver.ToArray();
            List<string> placeforval = new List<string>();
            if (pb.Componentval != null)
            {
                for (int i = 0; i < pb.Bitsofcomponents.Length; i++)
                {
                    if (Form2.Bitsref.ContainsKey(pb.Bitsofcomponents[i]) && pb.Componentval[i] == null)
                    {
                        Form2.Bitsref.TryGetValue(pb.Bitsofcomponents[i], out forvalbit);
                        placeforval.Add(forvalbit);
                    }
                    else if (Form2.Bitsref.ContainsKey(pb.Bitsofcomponents[i]) && pb.Componentval[i] != null)
                    {
                        placeforval.Add(pb.Componentval[i]);
                    }

                    else
                        placeforval.Add("");
                }

            }
            else
            {
                for (int i = 0; i < pb.Bitsofcomponents.Length; i++)
                {

                    if (Form2.Bitsref.ContainsKey(pb.Bitsofcomponents[i]))
                    {
                        Form2.Bitsref.TryGetValue(pb.Bitsofcomponents[i], out forvalbit);
                        placeforval.Add(forvalbit);

                    }
                    else
                        placeforval.Add("");
                }
            }
                pb.Componentval = placeforval.ToArray();
                this.Close();
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
