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
    public delegate void Comm(object sender, EventArgs e);
    public partial class Form3 : Form
    {
        public Form3()
        {
            
            InitializeComponent();
            

        }
        
        public int track;
        public event Comm commbetween;
        public static bool trk = false;
        int i = 0;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            trk = true;
            pictureBox1.DoDragDrop(pictureBox1.Image, DragDropEffects.Copy);
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            trk = true;
            pictureBox2.DoDragDrop(pictureBox2.Image, DragDropEffects.Copy);
        }
        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            trk = true;
            pictureBox3.DoDragDrop(pictureBox3.Image, DragDropEffects.Copy);
        }
        private void pictureBox4_MouseDown(object sender, MouseEventArgs e)
        {
            trk = true;
            pictureBox4.DoDragDrop(pictureBox4.Image, DragDropEffects.Copy);
        }

      /*  private void pictureBox1_Click(object sender, EventArgs e)
        {
           trkw = 45;

            if (commbetween != null)
            {
                commbetween(sender, e);
            }
            Label sel = new Label();
            sel.Text = "Component added ";
            var selLocX = sel.Location.X;
            var selLocY = sel.Location.Y;
            selLocX = 0;
            selLocY = 0;
            sel.ForeColor = Color.Red;
            this.Controls.Add(sel);
            

            if (i >= 1)
            {
                this.Controls.Remove(sel);
                sel.Dispose();    // no problem if already disposed
                sel = null;
            }
            i++;    
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            trkw = 135;
            if (commbetween != null)
            {
                commbetween(sender, e);
            }
            Label sel = new Label();
            sel.Text = "Component added";
            var selLocX = sel.Location.X;
            var selLocY = sel.Location.Y;
            selLocX = 0;
            selLocY = 0;
            sel.ForeColor = Color.Red;
            this.Controls.Add(sel);

            if (i >= 1)
            {
                this.Controls.Remove(sel);
                sel.Dispose();    // no problem if already disposed
                sel = null;
            }
            i++;
            


            //  Form2 f2 = new Form2();
            // f2.Show();

            //  f2.ShowDialog(ref trk);

            //  this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            trkw = 90;
            if (commbetween != null)
            {
                commbetween(sender, e);
            }
            
                Label sel = new Label();
            sel.Text = "Component added";
            var selLocX = sel.Location.X;
            var selLocY = sel.Location.Y;
            selLocX = 0;
            selLocY = 0;
            sel.ForeColor = Color.Red;
            this.Controls.Add(sel);
            if (i >= 1)
            {
                this.Controls.Remove(sel);
                sel.Dispose();    // no problem if already disposed
                sel = null;
            }
            i++;

        }
        */
        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    

}
