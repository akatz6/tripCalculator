using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace tripCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            FirstName(label1);

        }

        private void label2_Click(object sender, EventArgs e)
        {
            FirstName(label2);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            FirstName(label3);
        }

        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 200,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 100 };
            Button confirmation = new Button() { Text = "Ok", Left = 50, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }



        private void FirstName(Label label)
        {
            Verification ver = new Verification();
            string name = ShowDialog("Name of User", "");
            if (ver.VerifyName(name))
            {
                label.Text = name;
            }
            else
            {
                MessageBox.Show("First name must be all letters.  First letter must be capitalized and the rest lower case");
            }
        }


        void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ValNumber(dataGridView1, e);
        }

        void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ValNumber(dataGridView2, e);
        }

        void dataGridView3_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ValNumber(dataGridView3, e);
        }

        void ValNumber(DataGridView dataGridView, DataGridViewCellEventArgs e)
        {
            Verification ver = new Verification();
            if (!ver.DollarAmount(dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString()))
            {
                MessageBox.Show("No need to enter currency symbol before amount. Amount must had only two numbers after decimal and Number cannot start with a 0");
                dataGridView.Rows[e.RowIndex].SetValues("0.00");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Verification ver = new Verification();
            double sum1 = ver.SumForEachPerson(dataGridView1);
            double sum2 = ver.SumForEachPerson(dataGridView2);
            double sum3 = ver.SumForEachPerson(dataGridView3);

            double total = ver.PerPerson(sum1, sum2, sum3);

            double amount1 = ver.AmountOwed(sum1, total);
            double amount2 = ver.AmountOwed(sum2, total);
            double amount3 = ver.AmountOwed(sum3, total);

            label4.Text = amount2.ToString();
            label5.Text = amount1.ToString();
            label6.Text = amount3.ToString();

        }
    }
}
