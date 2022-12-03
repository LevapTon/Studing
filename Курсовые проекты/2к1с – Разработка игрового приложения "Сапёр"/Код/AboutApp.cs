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
    public partial class AboutApp : Form
    {
        public AboutApp()
        {
            InitializeComponent();
            label1.Text = "Данное приложение выполнено в рамках курсовой работы.\nСтудент: Плотников П.С\nГруппа: ПИНб-21а";
        }
    }
}
