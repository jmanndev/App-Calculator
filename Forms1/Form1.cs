using System;
using System.Windows.Forms;

namespace CalculatorForm
{
    public partial class CalculatorForm : Form
    {
        Calculator calc = new Calculator();

        private bool isSolvedEquation;

        public CalculatorForm()
        {
            InitializeComponent();
            ReplaceTextBox("0");
        }

        private void AddToTextBox(string input)
        {
            this.textBox.Text += input;
            isSolvedEquation = false;
        }

        private void ReplaceTextBox(string input)
        {
            this.textBox.Text = input;
            isSolvedEquation = false;
        }

        private void AddNumberToTextBox(string input)
        {
            if (this.textBox.Text == "0" || isSolvedEquation)
                ReplaceTextBox(input);
            else
                AddToTextBox(input);
        }

        private void AddOperatorToTextBox(string input)
        {
            if (!isErrorMessage())
                AddToTextBox(input);
            else
                ReplaceTextBox("0" + input);
        }

        private bool isErrorMessage()
        {
            bool isErrorMessage = false;
            double tempDouble;
            string tempString = this.textBox.Text;
            bool isNumber = double.TryParse(tempString, out tempDouble) && tempString != "Infinity" && tempString != "NaN";

            if (isSolvedEquation && !isNumber)
                isErrorMessage = true;
            return isErrorMessage;
        }

        #region OtherButtons
        private void buttonPeriod_Click(object sender, EventArgs e)
        {
            if (isSolvedEquation)
                ReplaceTextBox("0");
            AddToTextBox(".");
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            string tempString = this.textBox.Text;
            tempString = calc.Calculate(tempString);
            ReplaceTextBox(tempString);
            isSolvedEquation = true;
        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            string tempString = this.textBox.Text;
            if (tempString.Length == 1 || tempString == "0")
                tempString = "0";
            else
                tempString = tempString.Remove(tempString.Length - 1);
            ReplaceTextBox(tempString);
        }

        private void buttonCL_Click(object sender, EventArgs e)
        {
            ReplaceTextBox("0");
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddOperatorToTextBox("+");
        }

        private void buttonSubtract_Click(object sender, EventArgs e)
        {
            AddOperatorToTextBox("-");
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            AddOperatorToTextBox("*");
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            AddOperatorToTextBox("/");
        }

        private void buttonModulus_Click(object sender, EventArgs e)
        {
            AddOperatorToTextBox("%");
        }

        private void buttonPower_Click(object sender, EventArgs e)
        {
            AddOperatorToTextBox("^");
        }
        #endregion

        #region NumberButtons
        private void button1_Click(object sender, EventArgs e)
        {
            AddNumberToTextBox("1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddNumberToTextBox("2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddNumberToTextBox("3");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddNumberToTextBox("4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddNumberToTextBox("5");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddNumberToTextBox("6");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AddNumberToTextBox("7");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AddNumberToTextBox("8");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AddNumberToTextBox("9");
        }

        private void button0_Click(object sender, EventArgs e)
        {
            AddNumberToTextBox("0");
        }
        #endregion
    }
}
