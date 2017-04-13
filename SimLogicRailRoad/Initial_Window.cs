using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testsim
{
    public partial class Initial_Window : Form
    {
        string file_name;
        string text_read;

        public Initial_Window()
        {
            InitializeComponent();

            //initially disable the sim start button before finding a text file

            Sim_start.Enabled = false;

            this.AutoSize = true;
        }

        public void findTextToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //prompt user to find the text file wanted
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter =
               "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            dialog.Title = "Select Vital Sim Text File";

            if (dialog.ShowDialog() == DialogResult.OK) 
            {
                file_name = dialog.SafeFileName;
                text_read = dialog.FileName;
            }

            if(dialog.SafeFileName != "")
            {
                // enable sim_start button

                Sim_start.Enabled = true;
            }

        }

        private void Sim_start_Click(object sender, EventArgs e)
        {
            Simulation sim = new Simulation();

            //  sim.Hide();
            //sim.Show();
           sim.text_file_parse(file_name,text_read);
           // sim.Close();
            Form2 f2 = new testsim.Form2();

            f2.Show();
            this.Hide();

           /* // TEST CODE FOR SIMULATION
            Simulation_Logic sim_test = new Simulation_Logic();
            sim_test.GUI_Input("TEST");*/


        }
    }
}
