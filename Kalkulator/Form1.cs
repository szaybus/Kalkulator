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
        }
        private void Start(object sender, EventArgs e) {
            result = Controls["tableLayoutPanel"].Controls["ResultTextBox"] as TextBox;
            this.operationPending = Operation.none;
        }
        private void buttonPressed(object sender, EventArgs e) {
            Button buttonPressed = sender as Button;
            switch (buttonPressed.Text) {
                case "C":
                    result.Text = "";
                    break;
                case "+":
                case "-":
                case "*":
                case "/":
                case "=":
                    calculate();
                    result.Text = "";
                    switch (buttonPressed.Text) {
                        case "+": operationPending = Operation.Add;
                            break;
                        case "-": operationPending = Operation.Sub;
                            break;
                        case "*": operationPending = Operation.Mul;
                            break;
                        case "/": operationPending = Operation.Div;
                            break;
                        case "=": operationPending = Operation.none;
                            result.Text = mem.ToString();
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    result.Text += buttonPressed.Text;
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
                case Operation.none:
                    mem = float.Parse(result.Text);
                    break;
            }
        }
    }
}
