using Minesweeper.Controllers;
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
    public partial class Form1 : Form
    {
        static int sec = 0, min = 0;
        static bool timerClear = false;
        static string playerName;

        public static bool TimerClear
        {
            get
            {
                return timerClear;
            }
            set
            {
                timerClear = value;
            }
        }

        public static string PlayerName
        {
            get
            {
                return playerName;
            }
            set
            {
                playerName = value;
            }
        }

        public static int Sec
        {
            get
            {
                return sec;
            }
            set
            {
                sec = value;
            }
        }

        public static int Min
        {
            get
            {
                return min;
            }
            set
            {
                min = value;
            }
        }

        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            toolStripStatusLabel1.Text = "Начните игру";
            MapController.Init(this);
            DifficultySelection f4 = new DifficultySelection();
            f4.ShowDialog();
            if (f4.name == "" | f4.name == null)
                PlayerName = "Без имени";
            else
                PlayerName = f4.name;
            MapController.NewDifficult(this, f4.dif, PlayerName);
            timer1.Enabled = true;
        }

        private void правилаИгрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rools f2 = new Rools();
            f2.ShowDialog();
        }

        private void оПриложенииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutApp f3 = new AboutApp();
            f3.ShowDialog();
        }

        private void начатьНовуюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sec = -1;
            Min = 0;
            MapController.NewGame(this);
        }

        private void сменитьСложностьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Sec = -1;
            Min = 0;
            DifficultySelection f4 = new DifficultySelection();
            f4.ShowDialog();
            if (f4.name == "" | f4.name == null)
                PlayerName = "Без имени";
            else
                PlayerName = f4.name;
            MapController.NewDifficult(this, f4.dif, PlayerName);
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timerClear)
            {
                timer1.Enabled = false;
                Sec = -1;
                Min = 0;
                timerClear = false;
                timer1.Enabled = true;
            }
            if (Sec == 59)
            {
                Min++;
                Sec = 0;
            }
            Sec++;
            toolStripStatusLabel1.Text = "Время: " + Min.ToString() + ":" + Sec.ToString();
        }

        private void таблицаЛидеровToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LeaderTable f5 = new LeaderTable();
            f5.ShowDialog();
        }
    }
}
