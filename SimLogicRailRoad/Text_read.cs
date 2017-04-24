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
using SimLogicRailRoad;
using testsim;
using RailRoadLogicSim;
using System.Text.RegularExpressions;


namespace testsim
{
    public partial class  Simulation : Form
    {


        List<string> bits = new List<string>(); //bits and boolean logic
        public List<string> to_bits = new List<string>(); //here bits and boolean logic go

        //display information

        //disp_bits contains all the boolean logic
        //disp_to_bits are the output bits for the boolean logic

        List<string> disp_bits = new List<string>();
        List<string> disp_to_bits = new List<string>();

        //boolean logic parsed
        List<string> boolean_parsed = new List<string>();

        //user input
        List<int> user_input_num = new List<int>();


     
        

        //jimmys static bits
        public static List<string> disp_bits_static = new List<string>(); //boolean logic
        public static List<string> boolean_parsed_static = new List<string>(); //boolean logic with placeholders
        public static List<int> user_input_num_static = new List<int>(); //number of user inputs required
        public static List<string> disp_to_bits_static = new List<string>();
        public static List<string> to_bits_static = new List<string>();
        public static List<string> bits_static = new List<string>();
        public static List<int> string_array_cap_static = new List<int>();


        //Lists used to store unique bits in the input

       //ISMAIL USE THIS ONE FOR ALL THE BITS YOU WANT
       //DO IT FOR PAT
        public static List<string> unique_bits = new List<string>();

        public List<string> boolean_logic_edit = new List<string>();
        public List<string> boolean_logic_bits = new List<string>();
        public List<string> single_input_bits = new List<string>();
        public  List<string> input_bits = new List<string>();


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

                            bits.Add(boolean_first_half + current_string.Substring(7, current_string.IndexOf("TO") - 7).Trim());


                            index_to = (bits[count].IndexOf("TO"));
                            index_colon = (bits[count].IndexOf(";"));

                            //change colon index and TO index for the current line

                            index_colon = current_string.IndexOf(";");
                            index_to = current_string.IndexOf("TO");
                            to_bits.Add(current_string.Substring(index_to + 3, (index_colon - index_to) - 3));
                        }
                    }
                    else if ((line.IndexOf("\t") == 6 || line.IndexOf(" ") == 6) && line.IndexOf("TO") != -1)
                    {
                        bits.Add(line.Substring(7, line.LastIndexOf("TO") - 7).Trim());
                        to_bits.Add(line.Substring(index_to + 3, (index_colon - index_to) - 3));
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


                    bits.Add(line.Substring(9, line.IndexOf("TO") - 9).Trim());
                    to_bits.Add(line.Substring(index_to + 3, (index_colon - index_to) - 3));
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

            string_array_cap_static.Add(count);
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

                    disp_bits.Add(bits[i]);
                    disp_to_bits.Add(to_bits[i]);
                    disp_count++;

                }         
            }

            //re seize string array to be displayed

            //Array.Resize(ref disp_to_bits, disp_count);

            //display in list box

           //t_List_Box.Items.AddRange(disp_to_bits);

            //Call parse function
            boolean_logic_sort(disp_count);
            unique_bit_sort();
        

            }


        //Listbox event
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

                boolean_parsed.Add("");
               
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

                

                //store bit_num to record number of user inputs
                user_input_num.Add(bit_num - 1);
            }

            disp_bits_static = disp_bits;
            boolean_parsed_static = boolean_parsed;
            user_input_num_static = user_input_num;
            disp_to_bits_static = disp_to_bits;

        }
        

        //check for unique bits
        //finds bits in boolean logic
        //Compares bits in boolean logic to single input bits
        //stores unique input values
        //Compares unique input values to ouput values and stores result in unique_bits

        public void unique_bit_sort()
        {

            //disp_bits contains all the boolean logic
            //to_bits are the output bits for the boolean logic
            //bits are all the inputs


            // unique_bits are all the unique bits
            // boolean_logic_bits are the unique bits in the boolean logic
            // single_input_bits are all the single input bits
            // input_bits are the uinique input bits


            string temp;
            char[] chars = { '~', '*', '+' };

            //----------------------------------------
            //checks for the bits in the boolean logic
            //----------------------------------------

            for (int i = 0; i <= disp_bits.Count - 1; i++)
            {
                boolean_logic_edit.Add("");

                boolean_logic_edit[i] = disp_bits[i];

                //replace all boolean logic chars with spaces

                do
                {
                    temp = boolean_logic_edit[i];
                    boolean_logic_edit[i] = boolean_logic_edit[i].Replace('(', ' ');
                    boolean_logic_edit[i] = boolean_logic_edit[i].Replace(')', ' ');
                    boolean_logic_edit[i] = boolean_logic_edit[i].Replace('*', ' ');
                    boolean_logic_edit[i] = boolean_logic_edit[i].Replace('+', ' ');
                    boolean_logic_edit[i] = boolean_logic_edit[i].Replace('~', ' ');
                }
                while (temp != boolean_logic_edit[i]);


                //replace two spaces and three spaces with one space

                do
                {
                    temp = boolean_logic_edit[i];
                    boolean_logic_edit[i] = boolean_logic_edit[i].Replace("  ", " ");
                    boolean_logic_edit[i] = boolean_logic_edit[i].Replace("   ", " ");
                    boolean_logic_edit[i] = boolean_logic_edit[i].Replace("    ", " ");
                }
                while (temp != boolean_logic_edit[i]);

                if(boolean_logic_edit[i].StartsWith(" ") == true)
                {
                    boolean_logic_edit[i] = boolean_logic_edit[i].Remove(0, 1);
                }
                //split individual parts based upon spaces
                //stores each bit in parts

                var parts = boolean_logic_edit[i].Split(' ');

                for (int j = 0; j <= parts.Length - 1; j++)
                {
                    //set bit check bool equal to ture

                    bool bit_check = true;

                    // compare each part bit to whats already in the boolean_logic bits class, then store it
                    for (int a = 0; a < +boolean_logic_bits.Count; a++)
                    {
                        // if one of the btis in the boolean logic being evaluated is already int the boolean bits list
                        //then dont add it

                        if (parts[j] == boolean_logic_bits[a])
                        {
                            bit_check = false;
                        }
                        
                        //if bit is null then dont include it (seems like a problem with a text file)

                        if (parts[j] == "")
                        {
                            bit_check = false;
                        }
                    }

                    // add bit if its not already in the list

                    if(bit_check == true)
                    {
                        boolean_logic_bits.Add(parts[j]);
                    }
                    
                }

            }


            //----------------------------------------
            //checks for individual bits in the inputs
            //----------------------------------------

            for(int i = 0; i <= bits.Count - 1; i++)
            {
                if (bits[i].IndexOfAny(chars) >= 0)
                {
                    //do nothing

                }
                else
                {
                    single_input_bits.Add(bits[i]);
                }
            }

            //----------------------------------------
            //compare single input bits with the bits in the boolean logic
            //----------------------------------------

           input_bits = single_input_bits.Union(boolean_logic_bits).ToList();

            //----------------------------------------
            //compare input bits to to_bits and store it in uni_Que bits
            //----------------------------------------

            unique_bits = input_bits.Union(to_bits).ToList();




        }

    }
}
