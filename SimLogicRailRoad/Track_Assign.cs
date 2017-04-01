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
        public List <string> bitsin;
        List<string> guibits;
        string[] allbits;
        List<string>  lastofbit1;
        string assignbit;
        private object namebit;
        string check;
        private Array bitstry;
        private Type gy;

        private void Track_Assign_Load(object sender, EventArgs e)
        {

            guibits = Simulation.bitssofbits;
            int n = Convert.ToInt32(guibits.Count);

            /*   for (int i = 0; i < n; i++)
               {
                   if (guibits[i] != null)
                   {

                   }

                   else
                   {
                   }
               }*/
            // Array.Resize<string>(ref guibits, i);
            //  listBox2.Items.AddRange(guibits);
                 bitsin = Form2.bitsass;
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

                namebit = Form2.knowbit;
                PictureBox pb = (PictureBox)namebit;
            
                   if (pb.Tag !=null)
                    {

                        string[] tagget = (string[])pb.Tag;
                     //   string[] tagget = pb.Tag.ToString();

                        comboBox1.Text = tagget[0];
                        comboBox2.Text = tagget[1];
                        comboBox3.Text = tagget[2];
                        comboBox4.Text = tagget[3];
                        comboBox5.Text = tagget[4];

                       
                        //comboBox1.Text = reass1(0).t;
                    }
                    
                
                    return;
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
