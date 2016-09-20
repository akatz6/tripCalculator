using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data;
using System;




public class Verification
{
    public Verification()
    {
    }

    public bool VerifyName(string name){
        Regex rgx = new Regex("^[A-Z][a-z]+$");     
        return rgx.IsMatch(name);
    }

    public bool DollarAmount(string amount)
    {
        Regex rgx = new Regex("^[1-9]?([0-9]+)?[.][0-9][0-9]$");
        var test = rgx.IsMatch(amount);
        return rgx.IsMatch(amount);
    }

    public double SumForEachPerson(DataGridView dataGridView)
    {
        var sum = 0.00;
        foreach (DataGridViewRow row in dataGridView.Rows)
        {
            sum += Convert.ToDouble(((DataGridViewTextBoxCell)row.Cells[0]).Value);
        }
        return sum;

    }

    public double PerPerson(double sum1, double sum2, double sum3)
    {
        return Math.Round((sum1 + sum2 + sum3) / 3, 2);
    }

    public double AmountOwed(double sum1, double total)
    {
        return sum1 - total;
    }
}