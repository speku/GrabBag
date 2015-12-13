namespace WoWAddonUpdater
{
    partial class MainMenu
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
            this.AddonList = new System.Windows.Forms.SplitContainer();
            this.AddonDetails = new System.Windows.Forms.SplitContainer();
            this.AddonFacts = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.AddonList)).BeginInit();
            this.AddonList.Panel1.SuspendLayout();
            this.AddonList.Panel2.SuspendLayout();
            this.AddonList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddonDetails)).BeginInit();
            this.AddonDetails.Panel1.SuspendLayout();
            this.AddonDetails.Panel2.SuspendLayout();
            this.AddonDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddonFacts)).BeginInit();
            this.AddonFacts.Panel1.SuspendLayout();
            this.AddonFacts.Panel2.SuspendLayout();
            this.AddonFacts.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // AddonList
            // 
            this.AddonList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddonList.Location = new System.Drawing.Point(0, 0);
            this.AddonList.Name = "AddonList";
            // 
            // AddonList.Panel1
            // 
            this.AddonList.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // AddonList.Panel2
            // 
            this.AddonList.Panel2.Controls.Add(this.AddonDetails);
            this.AddonList.Size = new System.Drawing.Size(671, 477);
            this.AddonList.SplitterDistance = 223;
            this.AddonList.TabIndex = 0;
            // 
            // AddonDetails
            // 
            this.AddonDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddonDetails.Location = new System.Drawing.Point(0, 0);
            this.AddonDetails.Name = "AddonDetails";
            this.AddonDetails.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // AddonDetails.Panel1
            // 
            this.AddonDetails.Panel1.Controls.Add(this.AddonFacts);
            this.AddonDetails.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer2_Panel1_Paint);
            // 
            // AddonDetails.Panel2
            // 
            this.AddonDetails.Panel2.Controls.Add(this.richTextBox1);
            this.AddonDetails.Size = new System.Drawing.Size(444, 477);
            this.AddonDetails.SplitterDistance = 282;
            this.AddonDetails.TabIndex = 0;
            // 
            // AddonFacts
            // 
            this.AddonFacts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddonFacts.Location = new System.Drawing.Point(0, 0);
            this.AddonFacts.Name = "AddonFacts";
            // 
            // AddonFacts.Panel1
            // 
            this.AddonFacts.Panel1.Controls.Add(this.flowLayoutPanel2);
            // 
            // AddonFacts.Panel2
            // 
            this.AddonFacts.Panel2.Controls.Add(this.pictureBox1);
            this.AddonFacts.Size = new System.Drawing.Size(444, 282);
            this.AddonFacts.SplitterDistance = 200;
            this.AddonFacts.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.progressBar1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.670913F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95.32909F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(220, 471);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(3, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(214, 15);
            this.progressBar1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 24);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(214, 444);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(194, 276);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(237, 273);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(4, 4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(440, 187);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 477);
            this.Controls.Add(this.AddonList);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.AddonList.Panel1.ResumeLayout(false);
            this.AddonList.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AddonList)).EndInit();
            this.AddonList.ResumeLayout(false);
            this.AddonDetails.Panel1.ResumeLayout(false);
            this.AddonDetails.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AddonDetails)).EndInit();
            this.AddonDetails.ResumeLayout(false);
            this.AddonFacts.Panel1.ResumeLayout(false);
            this.AddonFacts.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AddonFacts)).EndInit();
            this.AddonFacts.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer AddonList;
        private System.Windows.Forms.SplitContainer AddonDetails;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.SplitContainer AddonFacts;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

