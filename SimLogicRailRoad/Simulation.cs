using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace testsim
{
    public partial class  Simulation : Form
    {
   
        string[] bits = new string[1000]; //bits and boolean logic
        public string[] to_bits = new string[1000]; //here bits and boolean logic go

        //display information

        string[] disp_bits = new string[1000];
        string[] disp_to_bits = new string[1000];
        
        //boolean logic parsed
        string[] boolean_parsed = new string[1000];

        //user input
        int[] user_input_num = new int[1000];

        //ismails static bits

        public static string[] bitassign;
        public static string[] bitssofbits;
        public static string[] lastofbit;

        //jimmys static bits

        public static string[] disp_bits_static;
        public static string[] boolean_parsed_static;
        public static int[] user_input_num_static;
        public static string[] disp_to_bits_static;
        public static string[] to_bits_static;
        public static string[] bits_static;
        public static int string_array_cap_static;

        public Simulation()
        {
            InitializeComponent();
        }

        public void text_file_parse(string text_file_name, string text_read)
        {
           string line; //streamreader string
            
           StreamReader reader = File.OpenText(text_read);

            int count = 0; // count used for the string arra used to store bits

            textBox2.Multiline = true; //enable textbox to have multiple lines

            int index_tab; //used for test purposes
            int index_to; //used for test purposes
            int index_plus; //used for test purposes
            int index_colon;


            string boolean_first_half; // used to store first half of soolean logic in the text fle
            string current_string; //current string in streamreader

            while ((line = reader.ReadLine()) != null)
            {
                //finds different points in the line currently being read

                index_tab = line.IndexOf("\t");
                index_to = line.IndexOf("TO ");
                index_plus = line.IndexOf("+");
                index_colon = line.IndexOf(";");

                //Starts with ASSIGN

                if (line.Length >= 9 && line.Substring(0,6) == "ASSIGN")
                {
                    //If there is no TO in the line

                    if (line.IndexOf("TO") == -1 || line.IndexOf("TO") == 0)
                    {
                        if (line.IndexOf(";") != -1)
                        {
                            bits[count] = line.Substring(7, line.IndexOf(";"));
                        }
                        else // case used for the oddly printed boolean logic
                        {
                            //store first half in a string

                            boolean_first_half = line.Substring(7, line.Length - 7);

                            //go to the next line

                            current_string = reader.ReadLine();

                            //read the rest of teh code and store it in teh string array
                             
                            bits[count] = boolean_first_half + current_string.Substring(7, current_string.IndexOf("TO")-7).Trim();

                            index_to = (bits[count].IndexOf("TO"));
                            index_colon = (bits[count].IndexOf(";"));

                            //change colon index and TO index for the current line

                            index_colon = current_string.IndexOf(";");
                            index_to = current_string.IndexOf("TO");
                            to_bits[count] = current_string.Substring(index_to + 3, (index_colon - index_to) - 3);

                        }
                    }
                    else if ((line.IndexOf("\t") == 6 || line.IndexOf(" ") == 6) && line.IndexOf("TO") != -1)
                    {
                        bits[count] = line.Substring(7, line.IndexOf("TO") - 7).Trim();
                        to_bits[count] = line.Substring(index_to + 3, (index_colon - index_to) - 3);
                    }
                    else
                    {
                        bits[count] = "unreadable";
                    }

                    //Starts with NV.ASSIGN

                    //increment textbox line and string array counter

                    textBox3.Text += to_bits[count] + Environment.NewLine;
                    textBox2.Text += bits[count] + Environment.NewLine;
                    count++;

                }

                //Starts with NV.ASSIGN

                else if (line.Length >= 9 && line.Substring(0, 9) == "NV.ASSIGN")
                {
                   

                    bits[count] = line.Substring(9, line.IndexOf("TO") - 9).Trim();
                    to_bits[count] = line.Substring(index_to+3, (index_colon - index_to) -3);

                    //increment textbox line and string array counter

                    textBox3.Text += to_bits[count] + Environment.NewLine;
                    textBox2.Text += bits[count] + Environment.NewLine;
                    count++;
                }
                else
                {
                    //do nothing
                }

            }

            to_bits_static = to_bits;
            bits_static = bits;

            //pass in count number to display_bits

            string_array_cap_static = count;
            display_bits(count);

        }

        //stores bits and boolean logic for display into new string arrays

        public void display_bits(int count)
        {


            int disp_count = 0;

            char[] chars = { '~', '*', '+' };

            //if the string contains a ~,*, or + then store it

            for (int i = 0; i < count; i++)
            {             
            
                if (bits[i].IndexOfAny(chars) >= 0)
                {

                    disp_bits[disp_count] = bits[i];
                    disp_to_bits[disp_count] = to_bits[i];
                    disp_count++;

                }         
            }

            //re seize string array to be displayed

            Array.Resize(ref disp_to_bits, disp_count);

            //display in list box

            Bit_List_Box.Items.AddRange(disp_to_bits);

            //Call parse function
            boolean_logic_sort(disp_count);

        }


        private void Bit_List_Box_MouseClick(object sender, MouseEventArgs e)
        {
            int index = this.Bit_List_Box.IndexFromPoint(e.Location);

            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                MessageBox.Show(disp_bits[index].ToString() + "\n\n" + boolean_parsed[index].ToString() + 
                    "\n \n Number of user inputs required: " + user_input_num[index]);
            }

            Ladder_Logic logic = new Ladder_Logic();

            logic.input_info(disp_bits[index].ToString(), boolean_parsed[index].ToString(), user_input_num[index]);

            logic.Show();

        }

        

        public void boolean_logic_sort(int count) // parse boolean logic to inf (,),+,*,~
        {
            for (int i = 0; i < count; i++)
            {
                //sort through boolean logic and find important emblems
                //pull them out
                //store in string with only those emblems

                //reference bit placeholder
                int bit_num = 1;

                //reference location in string
                int string_num = 0;

                //parses the boolean logic char by char
               
                foreach(char c in disp_bits[i])
            {
                    //evaluating the first boolean charcter

                    if (bit_num == 1)
                    {
                        if (c == '*')
                        {
                            boolean_parsed[i] = boolean_parsed[i] + "B" + bit_num + c;
                            bit_num = bit_num + 1;
                            if (disp_bits[i][string_num + 1] == '(' || disp_bits[i][string_num + 1] == '~')
                            {
                                // do not place bit holder
                                string_num++;
                            }
                            else
                            {
                                boolean_parsed[i] = boolean_parsed[i] + "B" + bit_num;
                                bit_num = bit_num + 1;
                                string_num++;
                            }
                        }
                        else if (c == '+')
                        {
                            boolean_parsed[i] = boolean_parsed[i] + "B" + bit_num + c;
                            bit_num = bit_num + 1;
                            if (disp_bits[i][string_num + 1] == '(' || disp_bits[i][string_num + 1] == '~')
                            {
                                // do not place bit holder
                                string_num++;
                            }
                            else
                            {
                                boolean_parsed[i] = boolean_parsed[i] + "B" + bit_num;
                                bit_num = bit_num + 1;
                                string_num++;
                            }
                        }
                        else if (c == '(')
                        {
                          
                                boolean_parsed[i] = boolean_parsed[i] + c;
                                string_num++;
                           
                        }
                        else if (c == ')')
                        {
                            boolean_parsed[i] = boolean_parsed[i] + c;
                            string_num++;

                        }
                        else if (c == '~')
                        {
                            boolean_parsed[i] = boolean_parsed[i] + c + "B" + bit_num;
                            bit_num = bit_num + 1;
                            string_num++;
                        }
                        else
                        {
                            //do nothing
                            string_num++;
                        }
                    }
                    else
                    {
                        if (c == '*')
                        {
                            if (boolean_parsed[i][boolean_parsed[i].Length - 1] == '(' && disp_bits[i][string_num + 1] != '(')
                            {
                                boolean_parsed[i] = boolean_parsed[i] + "B" + bit_num + c;
                                bit_num = bit_num + 1;
                                boolean_parsed[i] = boolean_parsed[i] + "B" + bit_num;
                                bit_num = bit_num + 1;
                                string_num++;
                            }
                            else if (boolean_parsed[i][boolean_parsed[i].Length - 1] == '(' && disp_bits[i][string_num + 1] == '(')
                            {
                                boolean_parsed[i] = boolean_parsed[i] + "B" + bit_num + c;
                                bit_num = bit_num + 1;
                                string_num++;
                            }
                            else if (disp_bits[i][string_num + 1] == '(' || disp_bits[i][string_num + 1] == '~')
                            {
                                // do not place bit holder
                                boolean_parsed[i] = boolean_parsed[i] + c;
                                string_num++;
                            }
                            else
                            {
                                boolean_parsed[i] = boolean_parsed[i] + c + "B" + bit_num;
                                bit_num = bit_num + 1;
                                string_num++;
                            }
                        }
                        else if (c == '+')
                        {
                            if(boolean_parsed[i][boolean_parsed[i].Length - 1] == '(' && disp_bits[i][string_num + 1] != '(')
                            {
                                boolean_parsed[i] = boolean_parsed[i] + "B" + bit_num + c;
                                bit_num = bit_num + 1;
                                boolean_parsed[i] = boolean_parsed[i] + "B" + bit_num;
                                bit_num = bit_num + 1;
                                string_num++;
                            }
                            else if (boolean_parsed[i][boolean_parsed[i].Length - 1] == '(' && disp_bits[i][string_num + 1] == '(')
                            {
                                boolean_parsed[i] = boolean_parsed[i] + "B" + bit_num + c;
                                bit_num = bit_num + 1;
                                string_num++;
                            }
                           else if (disp_bits[i][string_num + 1] == '(' || disp_bits[i][string_num + 1] == '~')
                            {
                                // do not place bit holder
                                boolean_parsed[i] = boolean_parsed[i] + c;
                                string_num++;
                            }
                            else
                            {
                                boolean_parsed[i] = boolean_parsed[i] + c + "B" + bit_num;
                                bit_num = bit_num + 1;
                                string_num++;
                            }
                        }
                        else if (c == '(')
                        {
                          
                                boolean_parsed[i] = boolean_parsed[i] + c;
                                string_num++;
                        }
                        else if (c == ')')
                        {
                            boolean_parsed[i] = boolean_parsed[i] + c;
                            string_num++;

                        }
                        else if (c == '~')
                        {
                            boolean_parsed[i] = boolean_parsed[i] + c + "B" + bit_num;
                            bit_num = bit_num + 1;
                            string_num++;
                        }
                        else
                        {
                            //do nothing
                            string_num++;
                        }
                    }


                }

                bitssofbits = bits;
                bitassign = to_bits;
                lastofbit = disp_to_bits;

                //store bit_num to record number of user inputs
                user_input_num[i] = bit_num - 1;
            }

            disp_bits_static = disp_bits;
            boolean_parsed_static = boolean_parsed;
            user_input_num_static = user_input_num;
            disp_to_bits_static = disp_to_bits;

        }
        
           
    }
}
