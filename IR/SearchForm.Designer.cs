namespace IR
{
    partial class SearchForm
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
            this.searchButton = new System.Windows.Forms.Button();
            this.searchText = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Rank = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.content = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Url = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.preProcessCheckBox = new System.Windows.Forms.CheckBox();
            this.searchTimeLabel = new System.Windows.Forms.Label();
            this.totalHitsLabel = new System.Windows.Forms.Label();
            this.saveResultButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(597, 49);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(115, 25);
            this.searchButton.TabIndex = 0;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // searchText
            // 
            this.searchText.Location = new System.Drawing.Point(65, 49);
            this.searchText.Name = "searchText";
            this.searchText.Size = new System.Drawing.Size(513, 25);
            this.searchText.TabIndex = 1;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Rank,
            this.Title,
            this.content,
            this.Url});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(65, 120);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(647, 277);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // Rank
            // 
            this.Rank.Text = "Rank";
            this.Rank.Width = 53;
            // 
            // Title
            // 
            this.Title.Text = "Title";
            this.Title.Width = 123;
            // 
            // content
            // 
            this.content.Text = "Content";
            this.content.Width = 342;
            // 
            // Url
            // 
            this.Url.Text = "Url";
            this.Url.Width = 118;
            // 
            // preProcessCheckBox
            // 
            this.preProcessCheckBox.AutoSize = true;
            this.preProcessCheckBox.Location = new System.Drawing.Point(65, 80);
            this.preProcessCheckBox.Name = "preProcessCheckBox";
            this.preProcessCheckBox.Size = new System.Drawing.Size(141, 19);
            this.preProcessCheckBox.TabIndex = 3;
            this.preProcessCheckBox.Text = "No Pre-process";
            this.preProcessCheckBox.UseVisualStyleBackColor = true;
            // 
            // searchTimeLabel
            // 
            this.searchTimeLabel.AutoSize = true;
            this.searchTimeLabel.Location = new System.Drawing.Point(62, 400);
            this.searchTimeLabel.Name = "searchTimeLabel";
            this.searchTimeLabel.Size = new System.Drawing.Size(111, 15);
            this.searchTimeLabel.TabIndex = 4;
            this.searchTimeLabel.Text = "search time: ";
            // 
            // totalHitsLabel
            // 
            this.totalHitsLabel.AutoSize = true;
            this.totalHitsLabel.Location = new System.Drawing.Point(581, 400);
            this.totalHitsLabel.Name = "totalHitsLabel";
            this.totalHitsLabel.Size = new System.Drawing.Size(95, 15);
            this.totalHitsLabel.TabIndex = 5;
            this.totalHitsLabel.Text = "total hits:";
            // 
            // saveResultButton
            // 
            this.saveResultButton.Enabled = false;
            this.saveResultButton.Location = new System.Drawing.Point(718, 120);
            this.saveResultButton.Name = "saveResultButton";
            this.saveResultButton.Size = new System.Drawing.Size(75, 277);
            this.saveResultButton.TabIndex = 6;
            this.saveResultButton.Text = "Save";
            this.saveResultButton.UseVisualStyleBackColor = true;
            this.saveResultButton.Click += new System.EventHandler(this.saveResultButton_Click);
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.saveResultButton);
            this.Controls.Add(this.totalHitsLabel);
            this.Controls.Add(this.searchTimeLabel);
            this.Controls.Add(this.preProcessCheckBox);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.searchText);
            this.Controls.Add(this.searchButton);
            this.Name = "SearchForm";
            this.Text = "SearchForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox searchText;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Rank;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader content;
        private System.Windows.Forms.ColumnHeader Url;
        private System.Windows.Forms.CheckBox preProcessCheckBox;
        private System.Windows.Forms.Label searchTimeLabel;
        private System.Windows.Forms.Label totalHitsLabel;
        private System.Windows.Forms.Button saveResultButton;
    }
}