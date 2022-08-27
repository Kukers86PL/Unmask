using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Unmask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        List<Button> ButtonsList = new List<Button>();

        private void button_Click(object sender, EventArgs e)
        {
            if (((Button)sender).BackColor == Color.Green)
            {
                ((Button)sender).BackColor = SystemColors.Control;
            }
            else
            {
                ((Button)sender).BackColor = Color.Green;
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            int length = ButtonsList.Count;
            for(int i = 0; i < length; i++)
            {
                Controls.Remove(ButtonsList[i]);
            }

            ButtonsList.Clear();

            length = textBox1.Text.Length;
            for (int i = 0; i < length; i++)
            {
                Button button = new Button();
                button.Text = (i + 1).ToString();
                button.Location = new Point(10 + (40 * i), 50);
                button.Width = 40;
                button.Height = 40;
                button.Font = new Font("Microsoft Sans Serif", 10); ;
                button.Click += button_Click;
                Controls.Add(button);
                ButtonsList.Add(button);
            }

            int calculateHeight = 50;
            int calculateWidth = 40 + ButtonsList.Count * 40;

            Height = 90 + calculateHeight;
            Width = Math.Max(270, calculateWidth);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int length = ButtonsList.Count;
            string result = "";
            for (int i = 0; i < length; i++)
            {
                if (ButtonsList[i].BackColor == Color.Green)
                {
                    result += textBox1.Text[i];
                }
            }
            if (result.Length > 0) Clipboard.SetText(result);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
