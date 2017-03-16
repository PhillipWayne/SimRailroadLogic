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

        public Ladder_Logic()
        {
            InitializeComponent();
        }

        public void input_info(string boolean_logic, string boolean_placeholder, int user_input_num)
        {

   

            for (int i = 1;  i < user_input_num + 1; i++)
            {
                //Create label
                Label label = new Label();
                label.Text = String.Format("B" + i, i);

                //Position label on screen
                label.Left = 10;
                label.Top = (i + 1) * 22;

                //Create textbox
                TextBox textBox = new TextBox();

                //Position textbox on screen
                textBox.Left = 120;
                textBox.Top = (i + 1) * 22;
                //Add controls to form

                this.Controls.Add(label);
                this.Controls.Add(textBox);
            }

        

        }
    }
}
