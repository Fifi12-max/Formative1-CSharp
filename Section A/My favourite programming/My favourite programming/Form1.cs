using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_favourite_programming
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string language = txtLanguage.Text.Trim();

            // Check if empty
            if (string.IsNullOrEmpty(language))
            {
                MessageBox.Show("Please enter a programming language.");
                return;
            }

            // Check for duplicates
            if (lstLanguages.Items.Contains(language))
            {
                MessageBox.Show("This language already exists!");
                return;
            }

            // Add to list
            lstLanguages.Items.Add(language);

            // Show date and time
            lblDateTime.Text = "Added on: " + DateTime.Now;

            // Clear textbox
            txtLanguage.Clear();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            // Check if something is selected
            if (lstLanguages.SelectedItem == null)
            {
                MessageBox.Show("Please select a language to remove.");
                return;
            }
            string removedLanguage = lstLanguages.SelectedItem.ToString();
            // Remove selected item
            lstLanguages.Items.Remove(lstLanguages.SelectedItem);
            lblDateTime.Text = removedLanguage + " removed on: " + DateTime.Now;
        }
    }
}
