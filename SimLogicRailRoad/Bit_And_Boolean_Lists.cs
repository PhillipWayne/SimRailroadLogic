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
    public partial class Bit_And_Boolean_Lists : Form
    {
        public Bit_And_Boolean_Lists()
        {
            InitializeComponent();
            list_box_values();

        }


        void list_box_values()
        {
            int data_limit = Simulation.string_array_cap_static;

            string[] valid_to_bits = new string[data_limit];
            string[] valid_bits = new string[data_limit];

            for(int i = 0; i <= data_limit - 1; i++)
            {
                valid_bits[i] = Simulation.bits_static[i];
                valid_to_bits[i] = Simulation.to_bits_static[i];
            }
            listBox1.Items.AddRange(valid_bits);
            listBox2.Items.AddRange(valid_to_bits);

        }

    }
}
