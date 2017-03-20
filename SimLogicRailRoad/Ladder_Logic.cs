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
    public partial class Ladder_Logic : Form
    {
        //strings used to get boolean logic from the input function
        string boolean_logic_message;
        string boolean_placeholder_message;
       
        public Ladder_Logic()
        {
            InitializeComponent();
        }

        public void input_info(string boolean_logic, string boolean_placeholder, int user_input_num)
        {
            //setting strings equal to public class strings for message box

            boolean_logic_message = boolean_logic;
            boolean_placeholder_message = boolean_placeholder;

            for (int i = 1;  i < user_input_num + 1; i++)
            {
                //Create label
                Label label = new Label();
                label.Text = String.Format("B" + i, i);
                label.Width = 20;

                //Position label on screen
                label.Left = 15;
                label.Top = (i + 2) * 24;

                //Create textbox
                NumericUpDown num = new NumericUpDown();

                //Position textbox on screen
                num.Left = 90;
                num.Top = (i + 2) * 24;
                num.Width = 35;
                num.Maximum = 1;
                //Add controls to form

                this.Controls.Add(label);
                this.Controls.Add(num);
                this.AutoSize = true;
               
            }

        
        

        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(boolean_logic_message + "\n\n" + boolean_placeholder_message);
        }
    }
}
