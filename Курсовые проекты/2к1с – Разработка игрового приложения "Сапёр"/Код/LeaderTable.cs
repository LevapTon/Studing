using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class LeaderTable : Form
    {
        const int rowCount = 10;
        string begin = "C:\\Users\\pp111\\source\\repos\\Minesweeper\\Minesweeper\\LeaderScore\\Beginner.csv",
               midl = "C:\\Users\\pp111\\source\\repos\\Minesweeper\\Minesweeper\\LeaderScore\\Skilled.csv",
               prof = "C:\\Users\\pp111\\source\\repos\\Minesweeper\\Minesweeper\\LeaderScore\\Professional.csv";
        string[] scores, result;
        public LeaderTable()
        {
            InitializeComponent();
            dataGridView1.BackgroundColor = this.BackColor;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.RowCount = rowCount;
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ScrollBars = ScrollBars.None;
            dataGridView2.BackgroundColor = this.BackColor;
            dataGridView2.BorderStyle = BorderStyle.None;
            dataGridView2.RowCount = rowCount;
            dataGridView2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.ScrollBars = ScrollBars.None;
            dataGridView3.BackgroundColor = this.BackColor;
            dataGridView3.BorderStyle = BorderStyle.None;
            dataGridView3.RowCount = rowCount;
            dataGridView3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView3.RowHeadersVisible = false;
            dataGridView3.ScrollBars = ScrollBars.None;
            using (StreamReader reader = new StreamReader(begin))
            {
                scores = reader.ReadToEnd().Split('\n');
                for (int i = 1; i < scores.Length; i++)
                {
                    result = scores[i].Split(',');
                    dataGridView1.Rows[i - 1].Cells[0].Value = i;
                    dataGridView1.Rows[i - 1].Cells[1].Value = result[0];
                    dataGridView1.Rows[i - 1].Cells[2].Value = $"{Convert.ToInt32(result[1]) / 60}:{Convert.ToInt32(result[1]) % 60}";
                }
            }
            using (StreamReader reader = new StreamReader(midl))
            {
                scores = reader.ReadToEnd().Split('\n');
                for (int i = 1; i < scores.Length; i++)
                {
                    result = scores[i].Split(',');
                    dataGridView2.Rows[i - 1].Cells[0].Value = i;
                    dataGridView2.Rows[i - 1].Cells[1].Value = result[0];
                    dataGridView2.Rows[i - 1].Cells[2].Value = $"{Convert.ToInt32(result[1]) / 60}:{Convert.ToInt32(result[1]) % 60}";
                }
            }
            using (StreamReader reader = new StreamReader(prof))
            {
                scores = reader.ReadToEnd().Split('\n');
                for (int i = 1; i < scores.Length; i++)
                {
                    result = scores[i].Split(',');
                    dataGridView3.Rows[i - 1].Cells[0].Value = i;
                    dataGridView3.Rows[i - 1].Cells[1].Value = result[0];
                    dataGridView3.Rows[i - 1].Cells[2].Value = $"{Convert.ToInt32(result[1]) / 60}:{Convert.ToInt32(result[1]) % 60}";
                }
            }
        }

            private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
