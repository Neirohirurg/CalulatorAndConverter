using ConverterLib;

namespace Converter2024App
{
    public partial class Form1 : Form
    {
        private double num;
        Manager cm = new Manager();

        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(cm.GetPhysicValuesList().ToArray());
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string valueName = comboBox1.Text;
            string from = comboBox2.Text;
            string to = comboBox3.Text;

            textBox2.Text = cm.GetConvertedValue(num, valueName, from, to).ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(cm.GetMeasureList(comboBox1.Text).ToArray());
            comboBox2.SelectedIndex = 0;

            comboBox3.Items.Clear();
            comboBox3.Items.AddRange(cm.GetMeasureList(comboBox1.Text).ToArray());
            comboBox3.SelectedIndex = 0;
        }

        private void textBox_textChanged(TextBox box)
        {
            if (box.Text.Length > 0)
            {
                try
                {
                    num = Convert.ToDouble(box.Text);
                }
                catch (FormatException)
                {
                    box.Text = box.Text.Remove(box.Text.Length - 1, 1);
                    box.SelectionStart = box.Text.Length;
                }
            }
            else { box.Clear(); }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox_textChanged(textBox1);
        }

    }
}