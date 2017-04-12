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
        string bit_insert_result;
        string boolean_operator_convert;


        //List that tracks the numberupdowns

        List<NumericUpDown> num_list = new List<NumericUpDown>();

        public Ladder_Logic()
        {
            InitializeComponent();
        }

        public void input_info(string boolean_logic, string boolean_placeholder, int user_input_num)
        {
            //setting strings equal to public class strings for message box

            boolean_logic_message = boolean_logic;
            boolean_placeholder_message = boolean_placeholder;


            for (int i = 1; i < user_input_num + 1; i++)
            {
                //Create label
                Label label = new Label();
                label.Text = String.Format("B" + i);
                label.Width = 30;

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
                num_list.Add(num);

                this.Controls.Add(label);
                this.Controls.Add(num);
                this.AutoSize = true;

            }



        }


        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(boolean_logic_message + "\n\n" + boolean_placeholder_message);
                
        }


        private void disp_button_Click(object sender, EventArgs e)
        {

            place_holder_replace(boolean_placeholder_message);

            //textBox2.Text = bit_insert_result;

            textBox1.Text = Evaluate(boolean_operator_convert);

        }
        //replace bit palce hodlers with 1s and 0s

        private void place_holder_replace(string bit_insert)
        {
            int char_value;
            int list_value = 0;

            foreach (char c in bit_insert)
            {
                if (c == 'B')
                {
                    //remove B and next value
                    //replace it with the user input

                    char_value = bit_insert.IndexOf('B');

                    if (list_value >= 9)
                    {
                        bit_insert = bit_insert.Remove(char_value, 3);
                    }
                    else
                    {

                        bit_insert = bit_insert.Remove(char_value, 2);
                    }

                    bit_insert = bit_insert.Insert(char_value, num_list[list_value].Value.ToString());

                    list_value++;

                }

            }

            bit_insert_result = bit_insert;

            boolean_convert(bit_insert_result);

            // MessageBox.Show();

        }


        //replaced *,=,~ with &,|,!
        //replaed 1 and 0 with true and false

        private void boolean_convert(string input)
        {
            input = input.Replace("*", " && ");
            input = input.Replace("+", " || ");
            input = input.Replace('~', '!');
            input = input.Replace("1", "true");
            input = input.Replace("0", "false");

            boolean_operator_convert = input;


        }


        //converts string to boolean logic

        public string Evaluate(string expression)
        {
            expression =
            expression.ToLower();
            expression = expression.Replace("false", "0");
            expression = expression.Replace("true", "1");
            expression = expression.Replace(" ", "");
            string temp;

            // do while temp does not equal the expression being evaluated

            do
            {
                temp = expression;
                expression = expression.Replace("(0)", "0");
                expression = expression.Replace("(1)", "1");
                expression = expression.Replace("!0", "1");
                expression = expression.Replace("!1", "0");
                expression = expression.Replace("0&&0", "0");
                expression = expression.Replace("0&&1", "0");
                expression = expression.Replace("1&&0", "0");
                expression = expression.Replace("1&&1", "1");
                expression = expression.Replace("0||0", "0");
                expression = expression.Replace("0||1", "1");
                expression = expression.Replace("1||0", "1");
                expression = expression.Replace("1||1", "1");
            }
            while (temp != expression);

            if (expression == "0")
            {
                return "0";
            }
            else if (expression == "1")
            {
                return "1";
            }
            else
            {
                return "invalid: " + expression;
            }

            //throw new ArgumentException("expression");
        }
    }
}