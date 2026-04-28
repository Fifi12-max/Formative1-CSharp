using System;
using System.Drawing;
using System.Windows.Forms;

namespace HomeAffairsDigitalIdentityProcessor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            cmbCitizen.Items.Add("South African");
            cmbCitizen.Items.Add("Permanent Resident");
            cmbCitizen.Items.Add("Visitor");
            cmbCitizen.SelectedIndex = 0;   
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string id = txtID.Text.Trim();
            string status = cmbCitizen.Text;

            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(id) ||
                string.IsNullOrWhiteSpace(status))
            {
                MessageBox.Show("Please fill in all fields.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CitizenProfile profile = new CitizenProfile(name, id, status);
            string result = profile.GetValidationMessage();    

            txtOutput.Text = result;
            txtOutput.ForeColor = result.StartsWith("Valid ID") ? Color.Green : Color.Red;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string id = txtID.Text.Trim();
            string status = cmbCitizen.Text;

            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(id) ||
                string.IsNullOrWhiteSpace(status))
            {
                MessageBox.Show("Please fill in all fields.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CitizenProfile profile = new CitizenProfile(name, id, status);

            txtOutput.Text = profile.GenerateProfileSummary();
            txtOutput.ForeColor = Color.Black;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to clear all fields?",
                "Confirm Clear",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                txtName.Clear();
                txtID.Clear();
                cmbCitizen.SelectedIndex = 0;
                txtOutput.Clear();
                txtName.Focus();
            }
        }

        private void lblID_Click(object sender, EventArgs e) { }
        private void cmbCitizen_SelectedIndexChanged(object sender, EventArgs e) { }
        private void lblName_Click(object sender, EventArgs e) { }
    }
}