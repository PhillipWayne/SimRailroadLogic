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
    public partial class Ladder_Logic_Selection : Form
    {

        public Ladder_Logic_Selection()
        {
            InitializeComponent();

            listBox1.Items.AddRange(Simulation.disp_to_bits_static.ToArray());
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int index = this.listBox1.IndexFromPoint(e.Location);

            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                MessageBox.Show(Simulation.disp_bits_static[index].ToString() + "\n\n" + Simulation.boolean_parsed_static[index].ToString() +
                    "\n \n Number of user inputs required: " + Simulation.user_input_num_static[index]);
            }

            Ladder_Logic logic = new Ladder_Logic();

            logic.input_info(Simulation.disp_bits_static[index].ToString(), Simulation.boolean_parsed_static[index].ToString(),
                Simulation.user_input_num_static[index]);

            logic.Show();
        }
    }
}
