using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testsim
{
    public class Simulation_Logic
    {
        //used to make bool value true when the class is called

        bool first_call = true;

        
        char[] chars = { '~', '*', '+' };

        //used in boolean logic convert methods

        string boolean_operator_convert;

        Dictionary<string, string> gui_input_bits = new Dictionary<string, string>();

            
       //dictionary of all unique bit values

        Dictionary<string, string> unique_bit_values_dict = new Dictionary<string, string>();

        //dictionary of all inputs and outputs from file

        Dictionary<string, string> inputs_and_outputs = new Dictionary<string, string>();

        List<string> input_bits =   new List<string>(Simulation.bits_static);
        List<string> output_bits = new List<string>(Simulation.to_bits_static);
        List<string> individual_bits = new List<string>(Simulation.unique_bits);
        List<string> boolean_logic = new List<string>(Simulation.disp_bits_static);
        List<string> boolean_logic_placeholders = new List<string>(Simulation.boolean_parsed_static);

        
        public object GUI_Input(Object obj)
        {
            
            //test print
            Console.WriteLine(obj);

            gui_input_bits = (Dictionary<string, string>)obj;

            //resets the inputs and outputs everytime the method is called
          
           // input_bits = Simulation.bits_static;
            
          //  output_bits = Simulation.to_bits_static;

            //finds all unique bits

         //   individual_bits = Simulation.unique_bits;

            //find all boolean logic and boolean logic with placeholders

         //   boolean_logic = Simulation.disp_bits_static;
         //   boolean_logic_placeholders = Simulation.boolean_parsed_static;

            //only make unique bits unkown when the class is called

            if (first_call == true)
            {
                for (int i = 0; i <= individual_bits.Count - 1; i++)
                {
                    
                    unique_bit_values_dict.Add(individual_bits[i], "UNK");
                }
            }

            //change all of the values to the individual bits listed in the bit_values distronary

            foreach(KeyValuePair<string,string> entry in gui_input_bits)
            {
                unique_bit_values_dict[entry.Key] = entry.Value;
            }


            //goes through each input and output and places in the bit values for specfied bits
            //and finds outputs based uppon inputs
            //for single inputs the value is made that same as the input
            //for boolean logic, the logic is executed and stored into the output
            
            //ADD IF HERE FOR OUTPUT BITS

            for (int i = 0;i <= input_bits.Count - 1; i++)
            {
                
                //if the input is boolean logic
                if (input_bits[i].IndexOfAny(chars) >= 0)
                {
                    string temp_in = input_bits[i];
                    string temp_out = output_bits[i];
                    string boolean_with_bits = input_bits[i];

                    //first make sure all bits are valid

                    //searches boolean logic for all individual bits and repalces them

                    foreach (KeyValuePair<string, string> entry in unique_bit_values_dict)
                    {
                        //search for bits in boolean logic
                        if (input_bits[i].Contains(entry.Key) == true)
                        {
                            //if its not unknown, replace the bit with the value associated with it
                            if (entry.Value != "UNK")
                            {
                                boolean_with_bits = boolean_with_bits.Replace(entry.Key, entry.Value);
                            }
                            else  //if it is unknown, throw an error message
                            {
                                MessageBox.Show("Unkown bit:" + " " + entry.Key);
                                break;
                            }
                        }

                    }


                    //execute the boolean logic
                    //input placeholder boolean logic into place_holder_replace()
                    //get result from Evaluate()

                    boolean_convert(boolean_with_bits);

                    string output = Evaluate(boolean_operator_convert);

                    //save inputs and outputs

                    input_bits[i] = output;

                    output_bits[i] = output;

                    unique_bit_values_dict[temp_out] = output;


                }
                else //if the value is a single input
                {
                    string temp_in = input_bits[i];
                    string temp_out = output_bits[i];

                    //change input bit equal to assigned 
                    
                     input_bits[i] = unique_bit_values_dict[input_bits[i]];
                    
                    //make output equal to the assigned value
                    output_bits[i] = unique_bit_values_dict[temp_in];

                    //change output bit in the dictonary
                    unique_bit_values_dict[temp_out] = unique_bit_values_dict[temp_in];


                }
            }


            foreach (KeyValuePair<string, string> entry in unique_bit_values_dict)
            {
                Console.WriteLine(entry.Key + " " + entry.Value);

            }

            //disable unique bits from being set as unoknown

            first_call = false;
            return unique_bit_values_dict;
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
