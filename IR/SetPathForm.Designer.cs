namespace IR
{
    partial class SetPathForm
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
            this.getIndexButton = new System.Windows.Forms.Button();
            this.getCollectionButton = new System.Windows.Forms.Button();
            this.indexPathLabel = new System.Windows.Forms.Label();
            this.collectionPathlabel = new System.Windows.Forms.Label();
            this.nextButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // getIndexButton
            // 
            this.getIndexButton.Location = new System.Drawing.Point(12, 12);
            this.getIndexButton.Name = "getIndexButton";
            this.getIndexButton.Size = new System.Drawing.Size(227, 74);
            this.getIndexButton.TabIndex = 0;
            this.getIndexButton.Text = "browse";
            this.getIndexButton.UseVisualStyleBackColor = true;
            this.getIndexButton.Click += new System.EventHandler(this.getIndexButton_Click);
            // 
            // getCollectionButton
            // 
            this.getCollectionButton.Location = new System.Drawing.Point(12, 92);
            this.getCollectionButton.Name = "getCollectionButton";
            this.getCollectionButton.Size = new System.Drawing.Size(227, 74);
            this.getCollectionButton.TabIndex = 1;
            this.getCollectionButton.Text = "browse";
            this.getCollectionButton.UseVisualStyleBackColor = true;
            this.getCollectionButton.Click += new System.EventHandler(this.getCollectionButton_Click);
            // 
            // indexPathLabel
            // 
            this.indexPathLabel.AutoSize = true;
            this.indexPathLabel.Location = new System.Drawing.Point(309, 42);
            this.indexPathLabel.Name = "indexPathLabel";
            this.indexPathLabel.Size = new System.Drawing.Size(143, 15);
            this.indexPathLabel.TabIndex = 2;
            this.indexPathLabel.Text = "Select index path";
            // 
            // collectionPathlabel
            // 
            this.collectionPathlabel.AutoSize = true;
            this.collectionPathlabel.Location = new System.Drawing.Point(309, 122);
            this.collectionPathlabel.Name = "collectionPathlabel";
            this.collectionPathlabel.Size = new System.Drawing.Size(183, 15);
            this.collectionPathlabel.TabIndex = 3;
            this.collectionPathlabel.Text = "Select collection path";
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(12, 274);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(776, 164);
            this.nextButton.TabIndex = 4;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // SetPathForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.collectionPathlabel);
            this.Controls.Add(this.indexPathLabel);
            this.Controls.Add(this.getCollectionButton);
            this.Controls.Add(this.getIndexButton);
            this.Name = "SetPathForm";
            this.Text = "GUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button getIndexButton;
        private System.Windows.Forms.Button getCollectionButton;
        private System.Windows.Forms.Label indexPathLabel;
        private System.Windows.Forms.Label collectionPathlabel;
        private System.Windows.Forms.Button nextButton;
    }
}