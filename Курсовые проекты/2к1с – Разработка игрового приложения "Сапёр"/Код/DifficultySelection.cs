using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class DifficultySelection : Form
    {
        public int dif;
        public string name;
        public DifficultySelection()
        {
            InitializeComponent();
            label1.Text = "Введите имя игрока и\nвыберите подходящий уровень сложности.";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            name = Convert.ToString(textBox1.Text);
            dif = 1;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            name = Convert.ToString(textBox1.Text);
            dif = 2;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            name = Convert.ToString(textBox1.Text);
            dif = 3;
            this.Close();
        }
    }
}
