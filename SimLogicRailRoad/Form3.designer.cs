namespace testsim
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.OH_E_Signal = new System.Windows.Forms.PictureBox();
            this.H_Trk = new System.Windows.Forms.PictureBox();
            this.TH_W_Signal = new System.Windows.Forms.PictureBox();
            this.Switch_BL = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.OH_E_Signal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.H_Trk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TH_W_Signal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Switch_BL)).BeginInit();
            this.SuspendLayout();
            // 
            // OH_E_Signal
            // 
            this.OH_E_Signal.BackColor = System.Drawing.Color.Black;
            this.OH_E_Signal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.OH_E_Signal.Location = new System.Drawing.Point(15, 12);
            this.OH_E_Signal.Name = "OH_E_Signal";
            this.OH_E_Signal.Size = new System.Drawing.Size(100, 70);
            this.OH_E_Signal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.OH_E_Signal.TabIndex = 1;
            this.OH_E_Signal.TabStop = false;
            // 
            // H_Trk
            // 
            this.H_Trk.BackColor = System.Drawing.Color.Black;
            this.H_Trk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.H_Trk.Location = new System.Drawing.Point(15, 88);
            this.H_Trk.Name = "H_Trk";
            this.H_Trk.Size = new System.Drawing.Size(100, 70);
            this.H_Trk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.H_Trk.TabIndex = 2;
            this.H_Trk.TabStop = false;
            // 
            // TH_W_Signal
            // 
            this.TH_W_Signal.BackColor = System.Drawing.Color.Black;
            this.TH_W_Signal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TH_W_Signal.Location = new System.Drawing.Point(121, 12);
            this.TH_W_Signal.Name = "TH_W_Signal";
            this.TH_W_Signal.Size = new System.Drawing.Size(100, 70);
            this.TH_W_Signal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.TH_W_Signal.TabIndex = 3;
            this.TH_W_Signal.TabStop = false;
            // 
            // Switch_BL
            // 
            this.Switch_BL.BackColor = System.Drawing.Color.Black;
            this.Switch_BL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Switch_BL.Location = new System.Drawing.Point(15, 164);
            this.Switch_BL.Name = "Switch_BL";
            this.Switch_BL.Size = new System.Drawing.Size(100, 140);
            this.Switch_BL.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Switch_BL.TabIndex = 4;
            this.Switch_BL.TabStop = false;
            // 
            // Form3
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(394, 317);
            this.Controls.Add(this.Switch_BL);
            this.Controls.Add(this.TH_W_Signal);
            this.Controls.Add(this.H_Trk);
            this.Controls.Add(this.OH_E_Signal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form3";
            this.Text = "Toolbox";
            ((System.ComponentModel.ISupportInitialize)(this.OH_E_Signal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.H_Trk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TH_W_Signal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Switch_BL)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox OH_E_Signal;
        private System.Windows.Forms.PictureBox H_Trk;
        private System.Windows.Forms.PictureBox TH_W_Signal;
        private System.Windows.Forms.PictureBox Switch_BL;
    }
}