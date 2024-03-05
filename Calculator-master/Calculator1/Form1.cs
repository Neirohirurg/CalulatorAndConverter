using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Calculator1
{
    public partial class Form1 : Form
    {
        // первое вводимое число
        private double x;
        // Второе вводимое число
        private double y;
        // Результат из значений x и y 
        private double result;
        // массив символов для метода Trim
        private char[] chars = {'+', ' ', '-', '*', '/', '=', ',', '^'};
        public Form1()
        {
            InitializeComponent();
        }          
        // Проверка вводимых цифр
        private void FunctionForButton(TextBox box, Button button)
        {
            if (box.Text == "0" && box.Text != null) box.Text = button.Text;
            else
            {
                if (box.Text.Length <= 15 && box.Text != "0" && box.Text != "∞") box.Text += box.Text = button.Text;
            }
        }
        // 1
        private void button1_Click(object sender, EventArgs e)
        {
            FunctionForButton(textBox1, button1);
        }
        // 2
        private void button2_Click(object sender, EventArgs e)
        {
            FunctionForButton(textBox1, button2);
        }       
        // 3
        private void button3_Click(object sender, EventArgs e)
        {
            FunctionForButton(textBox1, button3);
        }
        // 4
        private void button4_Click(object sender, EventArgs e)
        {
            FunctionForButton(textBox1, button4);
        }
       // 5
        private void button5_Click(object sender, EventArgs e)
        {
            FunctionForButton(textBox1, button5);
        }
        // 6
        private void button6_Click(object sender, EventArgs e)
        {
            FunctionForButton(textBox1, button6);
        }
        // 7
        private void button7_Click(object sender, EventArgs e)
        {
            FunctionForButton(textBox1, button7);
        } 
        // 8
        private void button8_Click(object sender, EventArgs e)
        {
            FunctionForButton(textBox1, button8);
        }
        // 9
        private void button9_Click(object sender, EventArgs e)
        {
            FunctionForButton(textBox1, button9);
        }
        // 0
        private void button0_Click(object sender, EventArgs e)
        {
            FunctionForButton(textBox1, button0);
        }
        // C
        private void button13_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text = "0";
            TurnOffButtonStyle();
        }
        // CE
        private void button29_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }
        // Удаление последнего символа в TextBox1 
        private void button21_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length > 0 && textBox1.Text != "0") textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);  
        }
        // Свойства TextBox1
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0) { textBox1.Text = "0"; }
            if(textBox1.Text.Length >= 10) 
            {
                textBox1.Font = new System.Drawing.Font("Times New Roman", 22);
                textBox1.TextAlign = HorizontalAlignment.Center;
                if(textBox1.Text.Length >= 25) textBox1.Font = new System.Drawing.Font("Times New Roman", 11);
            }
            else
            {
                textBox1.Font = new System.Drawing.Font("Times New Roman", 35);
                textBox1.TextAlign = HorizontalAlignment.Right;         
            }                        
        }
        // Свойства TextBox2
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length >= 25)
            {
                textBox2.Font = new System.Drawing.Font("Times New Roman", 11);
                textBox2.TextAlign = HorizontalAlignment.Center;
                if (textBox2.Text.Length >= 35) textBox2.Font = new System.Drawing.Font("Times New Roman", 8);
            }
            else
            {
                textBox2.Font = new System.Drawing.Font("Times New Roman", 14);
                textBox2.TextAlign = HorizontalAlignment.Right;
            }
        }
        // Cвойство FlatStyle.System для всех кнопок
        private void TurnOffButtonStyle()
        {
            button27.FlatStyle = FlatStyle.System;
            button26.FlatStyle = FlatStyle.System;
            button28.FlatStyle = FlatStyle.System;
            button18.FlatStyle = FlatStyle.System;
            button17.FlatStyle = FlatStyle.System;
            button22.FlatStyle = FlatStyle.System;
            button23.FlatStyle = FlatStyle.System;
            button24.FlatStyle = FlatStyle.System;
            button25.FlatStyle = FlatStyle.System;
        }
        // Математические действия
        private void MathActions(Button bt, char ch)
        {
            TurnOffButtonStyle();
            bt.FlatStyle = FlatStyle.Popup;
            if (textBox1.Text != "0" && textBox2.Text != "0")
            {
                
                x = Convert.ToDouble(textBox1.Text);
                try
                {
                    y = Convert.ToDouble(textBox2.Text.TrimEnd(chars));
                }
                catch (FormatException)
                {
                    y = x;
                    if (ch == '+' || ch == '-') x = 0;
                    else x = 1;
                }
                if (textBox1.Text == "0" && textBox2.Text != "0")
                {
                    bt.FlatStyle = FlatStyle.System;
                    textBox2.Text = textBox2.Text.TrimEnd(chars);
                }
                else
                {
                    textBox1.Clear();
                    textBox2.Clear();

                    if(ch == '/')
                    {
                        try { textBox2.Text = Convert.ToString(y / x) + " / "; }
                        catch (DivideByZeroException)
                        {
                            textBox1.Clear();
                            textBox2.Clear();
                        }
                    }
                    if(ch == '*')
                    {
                        textBox2.Text = Convert.ToString(x * y) + " * ";
                    }
                    if(ch == '-')
                    {
                        textBox2.Text = Convert.ToString(y - x) + " - ";
                    }
                    if(ch == '+')
                    {
                        textBox2.Text = Convert.ToString(x + y) + " + ";
                    }
                }
            }
            
            if(textBox2.Text.Contains('=') == false)
            {
                if (textBox1.Text != "0")
                {
                    textBox2.Text = textBox1.Text + $" {ch} ";
                    textBox1.Text = "0";
                }
                else 
                { 
                    textBox2.Text = textBox2.Text.TrimEnd(chars) + $" {ch} ";  
                }           
            }
        }
         // Сложение
        private void button23_Click(object sender, EventArgs e)
        {
            MathActions(button23, '+');
        }
        // Вычитание
        private void button26_Click(object sender, EventArgs e)
        {
            MathActions(button26, '-');
        }
        // Умножение
        private void button24_Click(object sender, EventArgs e)
        {
            MathActions(button24, '*');
        } 
        // Деление
        private void button25_Click(object sender, EventArgs e)
        {
            MathActions(button25, '/');
        }
        // =
        private void button22_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Contains('=') == false)
            {
                TurnOffButtonStyle();
                try
                {
                    if (textBox2.Text[textBox2.Text.Length - 2] == '+') result = Convert.ToDouble(textBox1.Text) + Convert.ToDouble(textBox2.Text.TrimEnd(chars));
                    if (textBox2.Text[textBox2.Text.Length - 2] == '-') result = Convert.ToDouble(textBox2.Text.TrimEnd(chars)) - Convert.ToDouble(textBox1.Text);
                    if (textBox2.Text[textBox2.Text.Length - 2] == '/') result = Convert.ToDouble(textBox2.Text.TrimEnd(chars)) / Convert.ToDouble(textBox1.Text);
                    if (textBox2.Text[textBox2.Text.Length - 2] == '*') result = Convert.ToDouble(textBox1.Text) * Convert.ToDouble(textBox2.Text.TrimEnd(chars));
                    if (textBox2.Text[textBox2.Text.Length - 2] == '^') result = Math.Pow(Convert.ToDouble(textBox2.Text.TrimEnd(chars)), Convert.ToDouble(textBox1.Text));
                    if (textBox2.Text.Contains(' ') == true)
                    {
                        textBox2.Text = textBox2.Text.TrimEnd() + " " + Convert.ToDouble(textBox1.Text) + " =";
                        textBox1.Text = result.ToString();
                    }
                }
                catch (IndexOutOfRangeException) { textBox1.Text = textBox2.Text; };
            }
        }
        // Разделитель дробной части
        private void button20_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Contains(',') == false) textBox1.Text += ',';
            else textBox1.Text = textBox1.Text.TrimEnd(chars);
        }
        // Добавление -
        private void button19_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains("-") == false && textBox1.Text != "0") textBox1.Text = "-" + textBox1.Text;
            else textBox1.Text = textBox1.Text.Remove(0, 1);
        }
        // %
        private void button27_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "0" && textBox1.Text != null) textBox1.Text = Convert.ToString(Convert.ToDouble(textBox1.Text) / 100);
        }
        // 1/x
        private void button28_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "0" && textBox1.Text != null) textBox1.Text = Convert.ToString(1/Convert.ToDouble(textBox1.Text));
        }
        // 2√x
        private void button18_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "0" && textBox1.Text != null) textBox1.Text = Convert.ToString(Math.Sqrt(Convert.ToDouble(textBox1.Text)));
        }
        // x^x
        private void button17_Click(object sender, EventArgs e)
        {
            TurnOffButtonStyle();
            if (textBox1.Text != "0")
            {
                x = Convert.ToDouble(textBox1.Text);
                textBox2.Text = x.ToString() + " ^ ";
                textBox1.Clear();
            }
            else
            {
                textBox2.Text = textBox2.Text.TrimEnd(chars) + " ^ " +textBox1.Text + " =";
                textBox1.Text = "1";
            }
        }
        // Событие: Загрузка формы
        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
