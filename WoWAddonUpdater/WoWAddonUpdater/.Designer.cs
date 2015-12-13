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
            this.LeftListTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.AddonProgressBar = new System.Windows.Forms.ProgressBar();
            this.AddonDetails = new System.Windows.Forms.SplitContainer();
            this.AddonFacts = new System.Windows.Forms.SplitContainer();
            this.AddonPictureBox = new System.Windows.Forms.PictureBox();
            this.AddonDescriptionText = new System.Windows.Forms.RichTextBox();
            this.AddonListView = new System.Windows.Forms.ListView();
            this.AddonFactsView = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.AddonList)).BeginInit();
            this.AddonList.Panel1.SuspendLayout();
            this.AddonList.Panel2.SuspendLayout();
            this.AddonList.SuspendLayout();
            this.LeftListTableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddonDetails)).BeginInit();
            this.AddonDetails.Panel1.SuspendLayout();
            this.AddonDetails.Panel2.SuspendLayout();
            this.AddonDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddonFacts)).BeginInit();
            this.AddonFacts.Panel1.SuspendLayout();
            this.AddonFacts.Panel2.SuspendLayout();
            this.AddonFacts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddonPictureBox)).BeginInit();
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
            this.AddonList.Panel1.Controls.Add(this.LeftListTableLayout);
            // 
            // AddonList.Panel2
            // 
            this.AddonList.Panel2.Controls.Add(this.AddonDetails);
            this.AddonList.Size = new System.Drawing.Size(731, 689);
            this.AddonList.SplitterDistance = 242;
            this.AddonList.TabIndex = 0;
            // 
            // LeftListTableLayout
            // 
            this.LeftListTableLayout.AutoSize = true;
            this.LeftListTableLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.LeftListTableLayout.ColumnCount = 1;
            this.LeftListTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LeftListTableLayout.Controls.Add(this.AddonProgressBar, 0, 0);
            this.LeftListTableLayout.Controls.Add(this.AddonListView, 0, 1);
            this.LeftListTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftListTableLayout.Location = new System.Drawing.Point(0, 0);
            this.LeftListTableLayout.Name = "LeftListTableLayout";
            this.LeftListTableLayout.RowCount = 2;
            this.LeftListTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.LeftListTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.LeftListTableLayout.Size = new System.Drawing.Size(242, 689);
            this.LeftListTableLayout.TabIndex = 0;
            // 
            // AddonProgressBar
            // 
            this.AddonProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddonProgressBar.Location = new System.Drawing.Point(3, 3);
            this.AddonProgressBar.Name = "AddonProgressBar";
            this.AddonProgressBar.Size = new System.Drawing.Size(236, 14);
            this.AddonProgressBar.TabIndex = 0;
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
            this.AddonDetails.Panel2.Controls.Add(this.AddonDescriptionText);
            this.AddonDetails.Size = new System.Drawing.Size(485, 689);
            this.AddonDetails.SplitterDistance = 407;
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
            this.AddonFacts.Panel1.Controls.Add(this.AddonFactsView);
            // 
            // AddonFacts.Panel2
            // 
            this.AddonFacts.Panel2.Controls.Add(this.AddonPictureBox);
            this.AddonFacts.Size = new System.Drawing.Size(485, 407);
            this.AddonFacts.SplitterDistance = 264;
            this.AddonFacts.TabIndex = 0;
            // 
            // AddonPictureBox
            // 
            this.AddonPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddonPictureBox.Location = new System.Drawing.Point(0, 0);
            this.AddonPictureBox.Name = "AddonPictureBox";
            this.AddonPictureBox.Size = new System.Drawing.Size(217, 407);
            this.AddonPictureBox.TabIndex = 0;
            this.AddonPictureBox.TabStop = false;
            // 
            // AddonDescriptionText
            // 
            this.AddonDescriptionText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddonDescriptionText.Location = new System.Drawing.Point(0, 0);
            this.AddonDescriptionText.Name = "AddonDescriptionText";
            this.AddonDescriptionText.Size = new System.Drawing.Size(485, 278);
            this.AddonDescriptionText.TabIndex = 0;
            this.AddonDescriptionText.Text = "";
            // 
            // AddonListView
            // 
            this.AddonListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddonListView.Location = new System.Drawing.Point(3, 23);
            this.AddonListView.Name = "AddonListView";
            this.AddonListView.Size = new System.Drawing.Size(236, 1068);
            this.AddonListView.TabIndex = 1;
            this.AddonListView.UseCompatibleStateImageBehavior = false;
            // 
            // AddonFactsView
            // 
            this.AddonFactsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddonFactsView.Location = new System.Drawing.Point(0, 0);
            this.AddonFactsView.Name = "AddonFactsView";
            this.AddonFactsView.Size = new System.Drawing.Size(264, 407);
            this.AddonFactsView.TabIndex = 0;
            this.AddonFactsView.UseCompatibleStateImageBehavior = false;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 689);
            this.Controls.Add(this.AddonList);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.AddonList.Panel1.ResumeLayout(false);
            this.AddonList.Panel1.PerformLayout();
            this.AddonList.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AddonList)).EndInit();
            this.AddonList.ResumeLayout(false);
            this.LeftListTableLayout.ResumeLayout(false);
            this.AddonDetails.Panel1.ResumeLayout(false);
            this.AddonDetails.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AddonDetails)).EndInit();
            this.AddonDetails.ResumeLayout(false);
            this.AddonFacts.Panel1.ResumeLayout(false);
            this.AddonFacts.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AddonFacts)).EndInit();
            this.AddonFacts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AddonPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer AddonList;
        private System.Windows.Forms.SplitContainer AddonDetails;
        private System.Windows.Forms.TableLayoutPanel LeftListTableLayout;
        private System.Windows.Forms.ProgressBar AddonProgressBar;
        private System.Windows.Forms.SplitContainer AddonFacts;
        private System.Windows.Forms.PictureBox AddonPictureBox;
        private System.Windows.Forms.RichTextBox AddonDescriptionText;
        private System.Windows.Forms.ListView AddonListView;
        private System.Windows.Forms.ListView AddonFactsView;
    }
}

