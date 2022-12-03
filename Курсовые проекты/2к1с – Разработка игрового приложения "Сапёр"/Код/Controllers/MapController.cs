using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper.Controllers
{
    public static class MapController
    {
        public static int mapWidht = 8;
        public static int mapHeight = 8; // Размер поля
        public static int minesCount = 10;  // Размер поля
        public const int cellSize = 25;  // Размер ячеек
        public static int difficult = 1;
        public static string begin = "C:\\Users\\pp111\\source\\repos\\Minesweeper\\Minesweeper\\LeaderScore\\Beginner.csv",
               midl = "C:\\Users\\pp111\\source\\repos\\Minesweeper\\Minesweeper\\LeaderScore\\Skilled.csv",
               prof = "C:\\Users\\pp111\\source\\repos\\Minesweeper\\Minesweeper\\LeaderScore\\Professional.csv",
               plrName;

        public static int[,] buttonImage = new int[mapWidht, mapHeight];

        public static int[,] map = new int[mapWidht, mapHeight];  // Массив значений поля

        public static Button[,] buttons = new Button[mapWidht, mapHeight];  // Массив кнопок

        public static Image spriteSet;  // Картинка

        private static bool isFirstStep;  // Флаг первого нажатия

        private static Point firstCoord;  // Точка первого нажатия

        public static Form form;

        private static void ConfigureMapSize(Form current)  // Создание игрового поля
        {
            current.Width = mapWidht * cellSize + 20;
            current.Height = (mapHeight + 1) * cellSize + 70;
        }

        private static void InitMap()  // Заполнение значений ячеек поля
        {
            map = new int[mapWidht, mapHeight];
            for (int i = 0; i < mapWidht; i++)
            {
                for (int j = 0; j < mapHeight; j++)
                {
                    map[i, j] = 0;
                }
            }
        }

        public static void Init(Form current)  // Инициализация новой игры
        {
            buttonImage = new int[mapWidht, mapHeight];
            form = current;
            isFirstStep = true;
            spriteSet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\tiles.png"));
            ConfigureMapSize(current);
            InitMap();
            InitButtons(current);
        }

        private static void InitButtons(Form current)  // Создание кнопок на поле
        {
            buttons = new Button[mapWidht, mapHeight];
            for (int i = 0; i < mapWidht; i++)
            {
                for (int j = 0; j < mapHeight; j++)
                {
                    Button button = new Button();
                    button.Location = new Point(i * cellSize, j * cellSize + 25);
                    button.Size = new Size(cellSize, cellSize);
                    button.Image = FindNeededImage(0, 0);
                    button.MouseUp += new MouseEventHandler(OnButtonPressedMouse);
                    current.Controls.Add(button);
                    buttons[i, j] = button;
                }
            }
        }

        private static void OnButtonPressedMouse(object sender, MouseEventArgs e)  // Обработчик нажатий по кнопкам
        {
            Button pressedButton = sender as Button;
            switch (e.Button.ToString())
            {
                case "Right":
                    OnRightButtonPressed(pressedButton);
                    break;
                case "Left":
                    OnLeftButtonPressed(pressedButton);
                    break;
            }
            IsVictory();
        }

        private static void OnRightButtonPressed(Button pressedButton)  // Нажатие ПКМ по кнопке (установка флага)
        {
            int iButton = pressedButton.Location.X / cellSize;
            int jButton = pressedButton.Location.Y / cellSize - 1;
            buttonImage[iButton, jButton] += 1;
            buttonImage[iButton, jButton] %= 3;
            int posX = 0;
            int posY = 0;
            switch (buttonImage[iButton, jButton])
            {
                case 0:
                    posX = 0;
                    posY = 0;
                    break;
                case 1:
                    posX = 0;
                    posY = 2;
                    break;
                case 2:
                    posX = 2;
                    posY = 2;
                    break;
            }
            pressedButton.Image = FindNeededImage(posX, posY);
        }

        private static void OnLeftButtonPressed(Button pressedButton)  // Нажатие ЛКМ по кнопке
        {
            pressedButton.Enabled = false;
            int iButton = pressedButton.Location.X / cellSize;
            int jButton = pressedButton.Location.Y / cellSize - 1;
            if (isFirstStep)
            {
                firstCoord = new Point(jButton, iButton);
                SeedMap();
                CountCellBomb();
                isFirstStep = false;
            }
            OpenCells(iButton, jButton);
            if (map[iButton, jButton] == -1)
            {
                ShowAllBombs(iButton, jButton);
                MessageBox.Show("Вы взорвались на мине!", "Поражение!");
                Form1.TimerClear = true;
                ClearMap();
                Init(form);
            }
        }

        private static void ShowAllBombs(int iBomb, int jBomb)  // Отображение оставшихся мин
        {
            for (int i = 0; i < mapWidht; i++)
            {
                for (int j = 0; j < mapHeight; j++)
                {
                    if (i == iBomb && j == jBomb)
                        continue;
                    if (map[i, j] == -1)
                    {
                        buttons[i, j].Image = FindNeededImage(3, 2);
                    }
                }
            }
        }

        public static Image FindNeededImage(int xPos, int yPos)  // Вырезание подходящей картинки
        {
            Image image = new Bitmap(cellSize, cellSize);
            Graphics g = Graphics.FromImage(image);
            g.DrawImage(spriteSet, new Rectangle(new Point(0, 0), new Size(cellSize, cellSize)), 0 + 32 * xPos, 0 + 32 * yPos, 33, 33, GraphicsUnit.Pixel);
            return image;
        }

        private static void SeedMap()  // Заполнение поля минами
        {
            Random r = new Random();
            for (int i = 0; i < minesCount; i++)
            {
                int posI = r.Next(0, mapWidht - 1);
                int posJ = r.Next(0, mapHeight - 1);
                while (map[posI, posJ] == -1 || (Math.Abs(posI - firstCoord.Y) <= 1 && Math.Abs(posJ - firstCoord.X) <= 1))
                {
                    posI = r.Next(0, mapWidht - 1);
                    posJ = r.Next(0, mapHeight - 1);
                }
                map[posI, posJ] = -1;
            }
        }

        private static void CountCellBomb()  // Подсчет мин вокруг ячейки
        {
            for (int i = 0; i < mapWidht; i++)
            {
                for (int j = 0; j < mapHeight; j++)
                {
                    if (map[i, j] == -1)
                    {
                        for (int k = i - 1; k < i + 2; k++)
                        {
                            for (int l = j - 1; l < j + 2; l++)
                            {
                                if (!IsInBorder(k, l) || map[k, l] == -1)
                                    continue;
                                map[k, l] = map[k, l] + 1;
                            }
                        }
                    }
                }
            }
        }

        private static void OpenCell(int i, int j)  // Открытие ячейки
        {
            buttons[i, j].Enabled = false;
            switch (map[i, j])
            {
                case 1:
                    buttons[i, j].Image = FindNeededImage(1, 0);
                    break;
                case 2:
                    buttons[i, j].Image = FindNeededImage(2, 0);
                    break;
                case 3:
                    buttons[i, j].Image = FindNeededImage(3, 0);
                    break;
                case 4:
                    buttons[i, j].Image = FindNeededImage(4, 0);
                    break;
                case 5:
                    buttons[i, j].Image = FindNeededImage(0, 1);
                    break;
                case 6:
                    buttons[i, j].Image = FindNeededImage(1, 1);
                    break;
                case 7:
                    buttons[i, j].Image = FindNeededImage(2, 1);
                    break;
                case 8:
                    buttons[i, j].Image = FindNeededImage(3, 1);
                    break;
                case -1:
                    buttons[i, j].Image = FindNeededImage(1, 2);
                    break;
                case 0:
                    buttons[i, j].Image = FindNeededImage(0, 0);
                    break;
            }
        }

        private static void OpenCells(int i, int j)  // Открытие всех безопасных ячеек
        {
            OpenCell(i, j);
            if (map[i, j] > 0)
                return;
            for (int k = i - 1; k < i + 2; k++)
            {
                for (int l = j - 1; l < j + 2; l++)
                {
                    if (!IsInBorder(k, l))
                        continue;
                    if (!buttons[k, l].Enabled)
                        continue;
                    if (map[k, l] == 0)
                        OpenCells(k, l);
                    else if (map[k, l] > 0)
                        OpenCell(k, l);
                }
            }
        }

        private static bool IsInBorder(int i, int j)  // Проверка на выход за границы поля
        {
            if (i < 0 || j < 0 || j > mapHeight - 1 || i > mapWidht - 1)
            {
                return false;
            }
            return true;
        }

        private static void ClearMap()  // Очистка поля от кнопок
        {
            for (int i = 0; i < mapWidht; i++)
            {
                for (int j = 0; j < mapHeight; j++)
                {
                    form.Controls.Remove(buttons[i, j] as Control);
                }
            }
        }

        public static void NewGame(Form current)  // Перезапуск партии
        {
            ClearMap();
            Init(current);
        }

        public static void NewDifficult(Form current, int dif, string pName) // Выбор сложности
        {
            plrName = pName;
            difficult = dif;
            ClearMap();
            switch (dif)
            {
                case 1:
                    mapWidht = 8;
                    mapHeight = 8;
                    minesCount = 10;
                    break;
                case 2:
                    mapWidht = 16;
                    mapHeight = 16;
                    minesCount = 40;
                    break;
                case 3:
                    mapWidht = 30;
                    mapHeight = 16;
                    minesCount = 99;
                    break;
            }
            Init(current);
        }

        private static void IsVictory()  // Проверка достигнута ли победа
        {
            for (int i = 0; i < mapWidht; i++)
            {
                for (int j = 0; j < mapHeight; j++)
                {
                    if (map[i, j] == -1)
                        continue;
                    if (!buttons[i, j].Enabled)
                        continue;
                    else
                    {
                        return;
                    }
                }
            }
            SaveResult();
            MessageBox.Show("Обезврежены все мины!", "Победа!");
            ClearMap();
            Form1.TimerClear = true;
            Init(form);
        }

        private static async void SaveResult()
        {
            int sec = Form1.Sec;
            int min = Form1.Min;
            string scores, newScore;
            int score;
            string[] results, line;
            switch (difficult)
            {
                case 1:
                    {
                        using (StreamReader reader = new StreamReader(begin))
                        {
                            results = reader.ReadToEnd().Split('\n');
                        }
                        for (int i = 1; i < results.Length; i++)
                        {
                            line = results[i].Split(',');
                            score = Convert.ToInt32(line[1]);
                            if (score > (60*min + sec))
                            {
                                newScore = $"{plrName},{60 * min + sec},Новичок";
                                results[i] = newScore;
                                break;
                            }
                        }
                        using (StreamWriter writer = new StreamWriter(begin))
                        {
                            scores = String.Join("\n", results);
                            await writer.WriteAsync(scores);
                        }
                        break;
                    }
                case 2:
                    {
                        using (StreamReader reader = new StreamReader(midl))
                        {
                            results = reader.ReadToEnd().Split('\n');
                        }
                        for (int i = 1; i < results.Length; i++)
                        {
                            line = results[i].Split(',');
                            score = Convert.ToInt32(line[1]);
                            if (score > (60 * min + sec))
                            {
                                newScore = $"{plrName},{60 * min + sec},Опытный";
                                results[i] = newScore;
                                break;
                            }
                        }
                        using (StreamWriter writer = new StreamWriter(midl))
                        {
                            scores = String.Join("\n", results);
                            await writer.WriteAsync(scores);
                        }
                        break;
                    }
                case 3:
                    {
                        using (StreamReader reader = new StreamReader(prof))
                        {
                            results = reader.ReadToEnd().Split('\n');
                        }
                        for (int i = 1; i < results.Length; i++)
                        {
                            line = results[i].Split(',');
                            score = Convert.ToInt32(line[1]);
                            if (score > (60 * min + sec))
                            {
                                newScore = $"{plrName},{60 * min + sec},Профессионал";
                                results[i] = newScore;
                                break;
                            }
                        }
                        using (StreamWriter writer = new StreamWriter(prof))
                        {
                            scores = String.Join("\n", results);
                            await writer.WriteAsync(scores);
                        }
                        break;
                    }
            }
        }
    }
}
