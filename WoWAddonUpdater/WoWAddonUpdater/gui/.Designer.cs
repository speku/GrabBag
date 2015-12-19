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
            this.AddonListView = new System.Windows.Forms.ListView();
            this.AddonDetails = new System.Windows.Forms.SplitContainer();
            this.AddonFacts = new System.Windows.Forms.SplitContainer();
            this.AddonFactsView = new System.Windows.Forms.ListView();
            this.AddonPictureBox = new System.Windows.Forms.PictureBox();
            this.AddonDescriptionText = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
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
            this.AddonList.Location = new System.Drawing.Point(0, 24);
            this.AddonList.Name = "AddonList";
            // 
            // AddonList.Panel1
            // 
            this.AddonList.Panel1.Controls.Add(this.LeftListTableLayout);
            // 
            // AddonList.Panel2
            // 
            this.AddonList.Panel2.Controls.Add(this.AddonDetails);
            this.AddonList.Size = new System.Drawing.Size(603, 584);
            this.AddonList.SplitterDistance = 175;
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
            this.LeftListTableLayout.Size = new System.Drawing.Size(175, 584);
            this.LeftListTableLayout.TabIndex = 0;
            // 
            // AddonProgressBar
            // 
            this.AddonProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddonProgressBar.Location = new System.Drawing.Point(3, 3);
            this.AddonProgressBar.Name = "AddonProgressBar";
            this.AddonProgressBar.Size = new System.Drawing.Size(169, 14);
            this.AddonProgressBar.TabIndex = 0;
            // 
            // AddonListView
            // 
            this.AddonListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddonListView.Location = new System.Drawing.Point(3, 23);
            this.AddonListView.Name = "AddonListView";
            this.AddonListView.Size = new System.Drawing.Size(169, 1068);
            this.AddonListView.TabIndex = 1;
            this.AddonListView.UseCompatibleStateImageBehavior = false;
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
            this.AddonDetails.Size = new System.Drawing.Size(424, 584);
            this.AddonDetails.SplitterDistance = 344;
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
            this.AddonFacts.Size = new System.Drawing.Size(424, 344);
            this.AddonFacts.SplitterDistance = 230;
            this.AddonFacts.TabIndex = 0;
            // 
            // AddonFactsView
            // 
            this.AddonFactsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddonFactsView.Location = new System.Drawing.Point(0, 0);
            this.AddonFactsView.Name = "AddonFactsView";
            this.AddonFactsView.Size = new System.Drawing.Size(230, 344);
            this.AddonFactsView.TabIndex = 0;
            this.AddonFactsView.UseCompatibleStateImageBehavior = false;
            // 
            // AddonPictureBox
            // 
            this.AddonPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddonPictureBox.Location = new System.Drawing.Point(0, 0);
            this.AddonPictureBox.Name = "AddonPictureBox";
            this.AddonPictureBox.Size = new System.Drawing.Size(190, 344);
            this.AddonPictureBox.TabIndex = 0;
            this.AddonPictureBox.TabStop = false;
            // 
            // AddonDescriptionText
            // 
            this.AddonDescriptionText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddonDescriptionText.Location = new System.Drawing.Point(0, 0);
            this.AddonDescriptionText.Name = "AddonDescriptionText";
            this.AddonDescriptionText.Size = new System.Drawing.Size(424, 236);
            this.AddonDescriptionText.TabIndex = 0;
            this.AddonDescriptionText.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(603, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 608);
            this.Controls.Add(this.AddonList);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
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
            this.PerformLayout();

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
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}

