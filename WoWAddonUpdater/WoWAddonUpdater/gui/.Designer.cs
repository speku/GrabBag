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
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.BaseTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.AddonsSplitContainer = new System.Windows.Forms.SplitContainer();
            this.AddonListView = new System.Windows.Forms.ListView();
            this.AddonDetails = new System.Windows.Forms.SplitContainer();
            this.AddonFacts = new System.Windows.Forms.SplitContainer();
            this.AddonFactsView = new System.Windows.Forms.ListView();
            this.AddonPictureBox = new System.Windows.Forms.PictureBox();
            this.AddonDescriptionText = new System.Windows.Forms.RichTextBox();
            this.TopTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.SelectionSplitContainer = new System.Windows.Forms.SplitContainer();
            this.TagsComboBox = new System.Windows.Forms.ComboBox();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.TotalProgressBar = new System.Windows.Forms.ProgressBar();
            this.BaseTableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddonsSplitContainer)).BeginInit();
            this.AddonsSplitContainer.Panel1.SuspendLayout();
            this.AddonsSplitContainer.Panel2.SuspendLayout();
            this.AddonsSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddonDetails)).BeginInit();
            this.AddonDetails.Panel1.SuspendLayout();
            this.AddonDetails.Panel2.SuspendLayout();
            this.AddonDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddonFacts)).BeginInit();
            this.AddonFacts.Panel1.SuspendLayout();
            this.AddonFacts.Panel2.SuspendLayout();
            this.AddonFacts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddonPictureBox)).BeginInit();
            this.TopTableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SelectionSplitContainer)).BeginInit();
            this.SelectionSplitContainer.Panel1.SuspendLayout();
            this.SelectionSplitContainer.Panel2.SuspendLayout();
            this.SelectionSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(481, 24);
            this.MenuStrip.TabIndex = 1;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // BaseTableLayout
            // 
            this.BaseTableLayout.ColumnCount = 1;
            this.BaseTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BaseTableLayout.Controls.Add(this.AddonsSplitContainer, 0, 1);
            this.BaseTableLayout.Controls.Add(this.TopTableLayout, 0, 0);
            this.BaseTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BaseTableLayout.Location = new System.Drawing.Point(0, 24);
            this.BaseTableLayout.Name = "BaseTableLayout";
            this.BaseTableLayout.RowCount = 2;
            this.BaseTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.BaseTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BaseTableLayout.Size = new System.Drawing.Size(481, 443);
            this.BaseTableLayout.TabIndex = 2;
            // 
            // AddonsSplitContainer
            // 
            this.AddonsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddonsSplitContainer.Location = new System.Drawing.Point(3, 33);
            this.AddonsSplitContainer.Name = "AddonsSplitContainer";
            // 
            // AddonsSplitContainer.Panel1
            // 
            this.AddonsSplitContainer.Panel1.Controls.Add(this.AddonListView);
            // 
            // AddonsSplitContainer.Panel2
            // 
            this.AddonsSplitContainer.Panel2.Controls.Add(this.AddonDetails);
            this.AddonsSplitContainer.Size = new System.Drawing.Size(475, 407);
            this.AddonsSplitContainer.SplitterDistance = 141;
            this.AddonsSplitContainer.TabIndex = 1;
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
            // TopTableLayout
            // 
            this.TopTableLayout.ColumnCount = 2;
            this.TopTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.81878F));
            this.TopTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.18122F));
            this.TopTableLayout.Controls.Add(this.SelectionSplitContainer, 1, 0);
            this.TopTableLayout.Controls.Add(this.TotalProgressBar, 0, 0);
            this.TopTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TopTableLayout.Location = new System.Drawing.Point(3, 3);
            this.TopTableLayout.Name = "TopTableLayout";
            this.TopTableLayout.RowCount = 1;
            this.TopTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TopTableLayout.Size = new System.Drawing.Size(475, 24);
            this.TopTableLayout.TabIndex = 2;
            // 
            // SelectionSplitContainer
            // 
            this.SelectionSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelectionSplitContainer.Location = new System.Drawing.Point(144, 3);
            this.SelectionSplitContainer.Name = "SelectionSplitContainer";
            // 
            // SelectionSplitContainer.Panel1
            // 
            this.SelectionSplitContainer.Panel1.Controls.Add(this.TagsComboBox);
            // 
            // SelectionSplitContainer.Panel2
            // 
            this.SelectionSplitContainer.Panel2.Controls.Add(this.SearchTextBox);
            this.SelectionSplitContainer.Size = new System.Drawing.Size(328, 18);
            this.SelectionSplitContainer.SplitterDistance = 147;
            this.SelectionSplitContainer.TabIndex = 0;
            // 
            // TagsComboBox
            // 
            this.TagsComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TagsComboBox.FormattingEnabled = true;
            this.TagsComboBox.Location = new System.Drawing.Point(0, 0);
            this.TagsComboBox.Name = "TagsComboBox";
            this.TagsComboBox.Size = new System.Drawing.Size(147, 21);
            this.TagsComboBox.TabIndex = 0;
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchTextBox.Location = new System.Drawing.Point(0, 0);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(177, 20);
            this.SearchTextBox.TabIndex = 0;
            // 
            // TotalProgressBar
            // 
            this.TotalProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TotalProgressBar.Location = new System.Drawing.Point(3, 3);
            this.TotalProgressBar.Name = "TotalProgressBar";
            this.TotalProgressBar.Size = new System.Drawing.Size(135, 18);
            this.TotalProgressBar.TabIndex = 1;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 467);
            this.Controls.Add(this.BaseTableLayout);
            this.Controls.Add(this.MenuStrip);
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.BaseTableLayout.ResumeLayout(false);
            this.AddonsSplitContainer.Panel1.ResumeLayout(false);
            this.AddonsSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AddonsSplitContainer)).EndInit();
            this.AddonsSplitContainer.ResumeLayout(false);
            this.AddonDetails.Panel1.ResumeLayout(false);
            this.AddonDetails.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AddonDetails)).EndInit();
            this.AddonDetails.ResumeLayout(false);
            this.AddonFacts.Panel1.ResumeLayout(false);
            this.AddonFacts.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AddonFacts)).EndInit();
            this.AddonFacts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AddonPictureBox)).EndInit();
            this.TopTableLayout.ResumeLayout(false);
            this.SelectionSplitContainer.Panel1.ResumeLayout(false);
            this.SelectionSplitContainer.Panel2.ResumeLayout(false);
            this.SelectionSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SelectionSplitContainer)).EndInit();
            this.SelectionSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.SplitContainer SelectionSplitContainer;
        private System.Windows.Forms.ComboBox TagsComboBox;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.ProgressBar TotalProgressBar;
        private System.Windows.Forms.TableLayoutPanel TopTableLayout;
        private System.Windows.Forms.RichTextBox AddonDescriptionText;
        private System.Windows.Forms.PictureBox AddonPictureBox;
        private System.Windows.Forms.ListView AddonFactsView;
        private System.Windows.Forms.SplitContainer AddonFacts;
        private System.Windows.Forms.SplitContainer AddonDetails;
        private System.Windows.Forms.ListView AddonListView;
        private System.Windows.Forms.SplitContainer AddonsSplitContainer;
        private System.Windows.Forms.TableLayoutPanel BaseTableLayout;
    }
}

