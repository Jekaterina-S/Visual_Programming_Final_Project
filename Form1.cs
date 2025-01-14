using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final_project
{
    public partial class Form1 : Form
    {
        double firstValue, secondValue;
        string opr;
        Queue<string> historyQueue = new Queue<string>();
        int maxQueueLenght = 8;
        public Form1()
        {
            // To avoid issues with decimal separator
            Application.CurrentCulture = new CultureInfo("en-US");
            InitializeComponent();
        }

        // Number button logic
        private void ClickNumber(object sender, EventArgs e)
        {
            Button num = sender as Button;

            if (textBox1.Text == "0")
                textBox1.Text = "";
            {
                if (num.Text == ".")
                {
                    if (!textBox1.Text.Contains(".")) {
                        textBox1.Text = textBox1.Text + num.Text;
                    }
                } else
                {
                    textBox1.Text = textBox1.Text + num.Text;
                }
            }
        }

        // Math operators
        private void MathOperators(object sender, EventArgs e)
        {
            Button operatorButton = sender as Button;

            if (double.TryParse(textBox1.Text, out firstValue))
            {
                opr = operatorButton.Text;
                textBox1.Text = "";
            } else
            {
                textBox1.Text = "Invalid input";
            }
        }

        // Equality operation
        private void bEq_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out secondValue))
            {
                switch (opr)
                {
                    case "+":
                        textBox1.Text = (firstValue + secondValue).ToString();
                        break;
                    case "-":
                        textBox1.Text = (firstValue - secondValue).ToString();
                        break;
                    case "*":
                        textBox1.Text = (firstValue * secondValue).ToString();
                        break;
                    case "/":
                        if (secondValue != 0)
                        {
                            textBox1.Text = (firstValue / secondValue).ToString();
                        }
                        else
                        {
                            textBox1.Text = "Cannot divide by zero";
                        }
                        break;
                    case "mod":
                        if (secondValue != 0)
                        {
                            textBox1.Text = (firstValue % secondValue).ToString();
                        }
                        else
                        {
                            textBox1.Text = "Undefined";
                        }
                        break;
                    case "xʸ":
                        textBox1.Text = (Math.Pow(firstValue, secondValue)).ToString();
                        break;
                    default:
                        break;
                }

                historyAdd();
            }
            else
            {
                textBox1.Text = "Invalid input";
            }
        }

        // Clear button
        private void bClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            opr = "";
            firstValue = default;
            secondValue = default;
        }

        // Clear entry button
        private void bCE_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        // Change number sign
        private void bSign_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out firstValue))
            {
               textBox1.Text = Convert.ToString(-1 * firstValue);
            } else
            {
                textBox1.Text = "Invalid input";
            }            
        }

        // Backspace button
        private void bBackspace_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
            }

            if (textBox1.Text == "")
            {
                textBox1.Text = "0";
            }
        }

        // Resize window to standard calculator
        private void standardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Width = 358;
            textBox1.Width = 318;
        }

        // Resize window to scientific calculator
        private void sientificToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Width = 694;
            textBox1.Width = 656;
        }

        // Pi constant
        private void bPi_Click(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(Math.PI);
        }

        // Euler's number
        private void bE_Click(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(Math.E);
        }

        // Square button
        private void bSquare_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out firstValue))
            {
                textBox1.Text = Convert.ToString(firstValue * firstValue);
                historyAdd();
            }
            else
            {
                textBox1.Text = "Invalid input";
            }
            
        }

        // Power of 10 button
        private void bTenPow_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out firstValue))
            {
                textBox1.Text = Convert.ToString(Math.Pow(10, firstValue));
                historyAdd();
            }
            else
            {
                textBox1.Text = "Invalid input";
            }
            
        }

        // Square root button
        private void bSqrt_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out firstValue) && firstValue >= 0)
            {
                textBox1.Text = Convert.ToString(Math.Sqrt(firstValue));
                historyAdd();
            }
            else
            {
                textBox1.Text = "Invalid input";
            }
        }

        // Fraction button
        private void bFrac_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out firstValue))
            {
                if (firstValue != 0)
                {
                    textBox1.Text = (1 / firstValue).ToString();
                    historyAdd();
                }
                else
                {
                    textBox1.Text = "Cannot divide by zero";
                }
            }
            else
            {
                textBox1.Text = "Invalid input";
            }
            
        }

        // Factorial button
        private void bFact_Click(object sender, EventArgs e)
        {
            int fact = 1;

            if (int.TryParse(textBox1.Text, out int firstValue) && firstValue >= 0)
            {
                for (int i = 1; i <= firstValue; i++)
                {
                    fact = fact * i;
                }
                textBox1.Text = Convert.ToString(fact);
                historyAdd();
            } else
            {
                textBox1.Text = "Invalid input";
            }
        }

        // Absolute value button
        private void bAbs_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out firstValue))
            {
                textBox1.Text = Convert.ToString(Math.Abs(firstValue));
                historyAdd();
            }
            else
            {
                textBox1.Text = "Invalid input";
            }
            
        }

        // Trigonometric functions, measured in radians
        private void bSin_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out firstValue))
            {
                textBox1.Text = Convert.ToString(Math.Sin(firstValue));
                historyAdd();
            }
            else
            {
                textBox1.Text = "Invalid input";
            }
            
        }

        private void bCos_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out firstValue))
            {
                textBox1.Text = Convert.ToString(Math.Cos(firstValue));
                historyAdd();
            }
            else
            {
                textBox1.Text = "Invalid input";
            }
            
        }

        private void bTan_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out firstValue))
            {
                textBox1.Text = Convert.ToString(Math.Tan(firstValue));
                historyAdd();
            }
            else
            {
                textBox1.Text = "Invalid input";
            }
            
        }

        private void bSec_Click(object sender, EventArgs e)
        {
            
            if (double.TryParse(textBox1.Text, out firstValue))
            {
                double cos = Math.Cos(firstValue);

                if (cos != 0)
                {
                    textBox1.Text = Convert.ToString(1 / cos);
                    historyAdd();
                } else
                {
                    textBox1.Text = "Cannot divide by zero";
                }
            }
            else
            {
                textBox1.Text = "Invalid input";
            }
            
        }

        private void bCsc_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out firstValue))
            {
                double sin = Math.Sin(firstValue);

                if (sin != 0)
                {
                    textBox1.Text = Convert.ToString(1 / sin);
                    historyAdd();
                }
                else
                {
                    textBox1.Text = "Cannot divide by zero";
                }
            }
            else
            {
                textBox1.Text = "Invalid input";
            }
        }

        private void bCot_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out firstValue))
            {
                double tan = Math.Tan(firstValue);

                if (tan != 0)
                {
                    textBox1.Text = Convert.ToString(1 / tan);
                    historyAdd();
                }
                else
                {
                    textBox1.Text = "Cannot divide by zero";
                }
            }
            else
            {
                textBox1.Text = "Invalid input";
            }
        }

        // Logarithmic functions
        private void bLog_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out firstValue) && firstValue > 0)
            {
                textBox1.Text = Convert.ToString(Math.Log10(firstValue));
                historyAdd();
            } else
            {
                textBox1.Text = "Invalid input";
            }
        }

        private void bLn_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out firstValue) && firstValue > 0)
            {
                textBox1.Text = Convert.ToString(Math.Log(firstValue));
                historyAdd();
            }
            else
            {
                textBox1.Text = "Invalid input";
            }
        }

        // Floor button
        private void bFloor_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out firstValue))
            {
                textBox1.Text = Convert.ToString(Math.Floor(firstValue));
                historyAdd();
            }
            else
            {
                textBox1.Text = "Invalid input";
            }
            
        }

        // Ceil button
        private void bCeil_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out firstValue))
            {
                textBox1.Text = Convert.ToString(Math.Ceiling(firstValue));
                historyAdd();
            }
            else
            {
                textBox1.Text = "Invalid input";
            }
            
        }

        // Adding entries to history
        private void historyAdd()
        {
            if (historyQueue.Count() == maxQueueLenght)
            {
                historyQueue.Dequeue();
            }

            historyQueue.Enqueue(textBox1.Text);
            historyToolStripMenuItem.DropDownItems.Clear();
            
            // Populating dropdown menu
            foreach (string entry in historyQueue)
            {
                ToolStripMenuItem newEntry;

                newEntry = new ToolStripMenuItem();
                newEntry.Text = entry;
                newEntry.Click += new EventHandler(entry_Click);
                historyToolStripMenuItem.DropDownItems.Add(newEntry);
            }
        }

        // Clicking histroy entries
        private void entry_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem entry = sender as ToolStripMenuItem;
            textBox1.Text = entry.Text;
        }

        // Standard window size
        private void Form1_Load(object sender, EventArgs e)
        {
            Width = 358;
            textBox1.Width = 318;
        }

        // Exit button
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
