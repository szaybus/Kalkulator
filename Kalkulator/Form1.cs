using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalkulator {
    public partial class Form1 : Form {
        enum Operation { Add, Sub, Mul, Div, none };

        TextBox result;
        float mem;
        Operation operationPending;
        public Form1() {
            InitializeComponent();
            foreach (var button in this.Controls.OfType<Button>()) {
                int buttonNumber = int.Parse(button.Text);
                if (buttonNumber >= 0 && buttonNumber <= 9) {
                    button.Click += numberPressed;
                } else button.Click += functionPressed;
            }
            result = Controls["ResultTextBox"] as TextBox;
            this.operationPending = Operation.none;
        }
        private void numberPressed(object sender, EventArgs e) {
            Button buttonPressed = sender as Button;
            result.Text += buttonPressed.Text;
        }
        private void functionPressed(object sender, EventArgs e) {
            Button buttonPressed = sender as Button;
            switch (buttonPressed.Text) {
                case "C":
                    result.Text = "";
                    break;
                case "+":
                case "-":
                case "*":
                case "/":
                    if(operationPending == Operation.none) {
                        mem = float.Parse(result.Text);
                    } else {
                        calculate();
                    }
                    result.Text = buttonPressed.Text;
                    break;
                case "=":
                    calculate();
                    result.Text = mem.ToString();
                    break;
                default:
                    break;
            }
            
        }
        private void calculate() {
            switch(operationPending) {
                case Operation.Add:
                    mem += float.Parse(result.Text);
                    break;
                case Operation.Sub:
                    mem -= float.Parse(result.Text);
                    break;
                case Operation.Mul:
                    mem *= float.Parse(result.Text);
                    break;
                case Operation.Div:
                    mem /= float.Parse(result.Text);
                    break;
            }
        }
    }
}
