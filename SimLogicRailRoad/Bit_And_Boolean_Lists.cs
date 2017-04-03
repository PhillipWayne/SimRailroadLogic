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
            listBox1.Items.AddRange(Simulation.bits_static.ToArray());
            listBox2.Items.AddRange(Simulation.to_bits_static.ToArray());

            //sorts list alphabetically
            Simulation.unique_bits.Sort();

            listBox3.Items.AddRange(Simulation.unique_bits.ToArray());
            label4.Text = "Total number: " + Simulation.unique_bits.Count;

        }

    }
}
