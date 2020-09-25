using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IR
{
    public partial class SetPathForm : Form
    {
        string indexPath = "";
        string collectionPath = "";
        public static string wordsPath = "";

        public SetPathForm()
        {
            InitializeComponent();
        }

        private void getIndexButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                indexPath = folderBrowserDialog.SelectedPath;
            }
            indexPathLabel.Text = indexPath;
        }

        private void getCollectionButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                collectionPath = folderBrowserDialog.SelectedPath;
            }
            collectionPathlabel.Text = collectionPath;
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            //collectionPath = @"E:\QUT\Semester2\IFN647 Advanced Information Storage and Retrieval\Project";
            //indexPath = @"E:\QUT\Semester2\IFN647 Advanced Information Storage and Retrieval\Project\Index";
            string time_spend = Program.BuildIndex(collectionPath, indexPath).ToString();
            string message = "Time spent: " + time_spend + "ms";
            string title = "Finish indexing";
            MessageBox.Show(message, title);

            this.Hide();
            SearchForm searchForm = new SearchForm();
            searchForm.Closed += (s, args) => this.Close();
            searchForm.Show();
        }

        private void getWordsButton_Click(object sender, EventArgs e)
        {
            //FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            //if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            //{
            //    wordsPath = folderBrowserDialog.SelectedPath;
            //}
            //wordsPathLabel.Text = wordsPath;
        }
    }
}
