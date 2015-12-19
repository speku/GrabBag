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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.TopTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.AddonList = new System.Windows.Forms.SplitContainer();
            this.AddonListView = new System.Windows.Forms.ListView();
            this.AddonDetails = new System.Windows.Forms.SplitContainer();
            this.AddonFacts = new System.Windows.Forms.SplitContainer();
            this.AddonFactsView = new System.Windows.Forms.ListView();
            this.AddonPictureBox = new System.Windows.Forms.PictureBox();
            this.AddonDescriptionText = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.AddonTagComboBox = new System.Windows.Forms.ComboBox();
            this.AddonSearchBox = new System.Windows.Forms.TextBox();
            this.AddonProgress = new System.Windows.Forms.ProgressBar();
            this.TopTableLayout.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.AddonPictureBox)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(481, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // TopTableLayout
            // 
            this.TopTableLayout.ColumnCount = 1;
            this.TopTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TopTableLayout.Controls.Add(this.AddonList, 0, 1);
            this.TopTableLayout.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.TopTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TopTableLayout.Location = new System.Drawing.Point(0, 24);
            this.TopTableLayout.Name = "TopTableLayout";
            this.TopTableLayout.RowCount = 2;
            this.TopTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.TopTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TopTableLayout.Size = new System.Drawing.Size(481, 443);
            this.TopTableLayout.TabIndex = 2;
            // 
            // AddonList
            // 
            this.AddonList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddonList.Location = new System.Drawing.Point(3, 33);
            this.AddonList.Name = "AddonList";
            // 
            // AddonList.Panel1
            // 
            this.AddonList.Panel1.Controls.Add(this.AddonListView);
            // 
            // AddonList.Panel2
            // 
            this.AddonList.Panel2.Controls.Add(this.AddonDetails);
            this.AddonList.Size = new System.Drawing.Size(475, 407);
            this.AddonList.SplitterDistance = 141;
            this.AddonList.TabIndex = 1;
            // 
            // AddonListView
            // 
            this.AddonListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddonListView.Location = new System.Drawing.Point(0, 0);
            this.AddonListView.Name = "AddonListView";
            this.AddonListView.Size = new System.Drawing.Size(141, 407);
            this.AddonListView.TabIndex = 2;
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
            this.AddonDetails.Size = new System.Drawing.Size(330, 407);
            this.AddonDetails.SplitterDistance = 239;
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
            this.AddonFacts.Size = new System.Drawing.Size(330, 239);
            this.AddonFacts.SplitterDistance = 178;
            this.AddonFacts.TabIndex = 0;
            // 
            // AddonFactsView
            // 
            this.AddonFactsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddonFactsView.Location = new System.Drawing.Point(0, 0);
            this.AddonFactsView.Name = "AddonFactsView";
            this.AddonFactsView.Size = new System.Drawing.Size(178, 239);
            this.AddonFactsView.TabIndex = 0;
            this.AddonFactsView.UseCompatibleStateImageBehavior = false;
            // 
            // AddonPictureBox
            // 
            this.AddonPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddonPictureBox.Location = new System.Drawing.Point(0, 0);
            this.AddonPictureBox.Name = "AddonPictureBox";
            this.AddonPictureBox.Size = new System.Drawing.Size(148, 239);
            this.AddonPictureBox.TabIndex = 0;
            this.AddonPictureBox.TabStop = false;
            // 
            // AddonDescriptionText
            // 
            this.AddonDescriptionText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddonDescriptionText.Location = new System.Drawing.Point(0, 0);
            this.AddonDescriptionText.Name = "AddonDescriptionText";
            this.AddonDescriptionText.Size = new System.Drawing.Size(330, 164);
            this.AddonDescriptionText.TabIndex = 0;
            this.AddonDescriptionText.Text = "";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.81878F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.18122F));
            this.tableLayoutPanel2.Controls.Add(this.splitContainer1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.AddonProgress, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(475, 24);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(144, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.AddonTagComboBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.AddonSearchBox);
            this.splitContainer1.Size = new System.Drawing.Size(328, 18);
            this.splitContainer1.SplitterDistance = 147;
            this.splitContainer1.TabIndex = 0;
            // 
            // AddonTagComboBox
            // 
            this.AddonTagComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddonTagComboBox.FormattingEnabled = true;
            this.AddonTagComboBox.Location = new System.Drawing.Point(0, 0);
            this.AddonTagComboBox.Name = "AddonTagComboBox";
            this.AddonTagComboBox.Size = new System.Drawing.Size(147, 21);
            this.AddonTagComboBox.TabIndex = 0;
            // 
            // AddonSearchBox
            // 
            this.AddonSearchBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddonSearchBox.Location = new System.Drawing.Point(0, 0);
            this.AddonSearchBox.Name = "AddonSearchBox";
            this.AddonSearchBox.Size = new System.Drawing.Size(177, 20);
            this.AddonSearchBox.TabIndex = 0;
            // 
            // AddonProgress
            // 
            this.AddonProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddonProgress.Location = new System.Drawing.Point(3, 3);
            this.AddonProgress.Name = "AddonProgress";
            this.AddonProgress.Size = new System.Drawing.Size(135, 18);
            this.AddonProgress.TabIndex = 1;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 467);
            this.Controls.Add(this.TopTableLayout);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.TopTableLayout.ResumeLayout(false);
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
            ((System.ComponentModel.ISupportInitialize)(this.AddonPictureBox)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox AddonTagComboBox;
        private System.Windows.Forms.TextBox AddonSearchBox;
        private System.Windows.Forms.ProgressBar AddonProgress;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.RichTextBox AddonDescriptionText;
        private System.Windows.Forms.PictureBox AddonPictureBox;
        private System.Windows.Forms.ListView AddonFactsView;
        private System.Windows.Forms.SplitContainer AddonFacts;
        private System.Windows.Forms.SplitContainer AddonDetails;
        private System.Windows.Forms.ListView AddonListView;
        private System.Windows.Forms.SplitContainer AddonList;
        private System.Windows.Forms.TableLayoutPanel TopTableLayout;
    }
}

