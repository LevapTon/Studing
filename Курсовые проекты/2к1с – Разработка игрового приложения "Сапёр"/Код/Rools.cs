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
    public partial class Rools : Form
    {
        public Rools()
        {
            InitializeComponent();
            label1.Text = "При запуске игры Вам предложат выбрать один из уровней сложности:";
            label2.Text = "Новичок – размер игрового поля составляет 8×8, спрятаны 10 мин;";
            label3.Text = "Любитель – поле размером 16×16, где спрятаны 40 мин;";
            label4.Text = "Профессионал – поле 16×30 с 99 спрятанными минами.";
            label5.Text = "Вы никогда не наткнетесь на мину при первом нажатии,\nтак что не бойтесь сделать первый шаг!";
            label6.Text = "У многих ячеек есть своя цифра\n(желтая область).";
            label7.Text = "Эта цифра говорит о том, сколько рядом\nнаходится мин (зеленая область).";
            label8.Text = "Если вы уверены, что в ячейке стоит бомба,\nто нажмите по ней правой кнопкой мыши.";
            label9.Text = "Таким образом Вы поставите флаг\n(красная область). Если Вы сомневаетесь,";
            label10.Text = "то нажмите еще раз и Вы поставите\nзнак вопроса (синяя область).";
            label11.Text = "Для победы нужно открыть всё поле, не наткнувшись на мину.";
            label12.Text = "Вы проиграете, если нажмете на мину.";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
