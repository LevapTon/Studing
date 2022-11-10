using System;

namespace Классы
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число строк в отрезке [1;5]: ");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите число столбцов в отрезке [1;5]: ");
            int y = Convert.ToInt32(Console.ReadLine());
            // Console.WriteLine("Заполните созданную матрицу значениями");

            Matrix first = new();
            Matrix second = new Matrix();
            if (x == y)
            {
                first = new Matrix(x);
            }
            else
            {
                first = new Matrix(x, y);
            }
            
            first.PrintMatrix(first);
            first.IsSquare();
            first.IsDiagonal(first);
            first.IsZero(first);
            first.IsSingle(first);
            first.IsSymmetrical(first);
            first.IsUpperTriangular(first);
            first.IsLowerTriangular(first);
            Console.Write("Равенство матриц: ");
            Console.WriteLine(first == second);
        }
    }

    class Matrix
    {
        Random r = new Random();
        int[,] matrix;
        int row, col;

        public int Row  // Свойтво row
        {
            get
            {
                return row;  // Возвращает значение
            }
            set
            {
                if (value > 0 && value < 6)  // Если передаваемое значение входит в диапозон
                {
                    row = value;
                }
                else
                {
                    row = 1;  // Установка базового значения в поле
                }
            }
        }

        public int Col  // Свойтво col
        {
            get
            {
                return col;  // Возвращает значение
            }
            set
            {
                if (value > 0 && value < 6)  // Если передаваемое значение входит в диапозон
                {
                    col = value;
                }
                else
                {
                    col = 1;  // Установка базового значения в поле
                }
            }
        }

        public Matrix()  // Создание квадр. матр. 3*3
        {
            this.Row = 3;
            this.Col = 3;
            matrix = new int[this.Row, this.Col];
            for (int i = 0; i < this.Row; i++)
            {
                for (int j = 0; j < this.Col; j++)
                {
                    matrix[i, j] = r.Next(10);
                }
            }
        }

        public Matrix(int x)  // Создание квадр. матр. n*n
        {
            this.Row = x;
            this.Col = x;
            matrix = new int[this.Row, this.Row];
            for (int i = 0; i < this.Col; i++)
            {
                for (int j = 0; j < this.Row; j++)
                {
                    matrix[i, j] = r.Next(10);
                }
            }
        }

        public Matrix(int x, int y)  // Создание не квадр. матр. n*m
        {
            this.Row = x;
            this.Col = y;
            matrix = new int[this.Row, this.Col];
            for (int i = 0; i < this.Row; i++)
            {
                for (int j = 0; j < this.Col; j++)
                {
                    matrix[i, j] = r.Next(10);
                }
            }
        }

        public int this[int x, int y]  // Перегрузка индексирования матриц
        {
            get => matrix[x, y];
            set => matrix[x, y] = value;
        }

        public void PrintMatrix(Matrix m)  // Вывод матрицы на экран
        {
            for (int i = 0; i < this.Row; i++)
            {
                for (int j = 0; j < this.Col; j++)
                {
                    Console.Write(m[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public void IsSquare()  // Проверка на квадратную матрицу
        {
            if (this.Row == this.Col) 
            {
                Console.WriteLine("Матрица квадратная");
            }
            else
            {
                Console.WriteLine("Матрица не квадратная");
            }
        }

        public bool IsSquareBool()  // Проверка на квадратную матрицу
        {
            if (this.Row == this.Col) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void IsDiagonal(Matrix m)  // Проверка на диагональную матрицу
        {
            if (m.IsSquareBool())
            {
                bool flag = true;
                for (int i = 0; i < this.Row; i++)
                {
                    for (int j = 0; j < this.Col; j++)
                    {
                        if (i == j) continue;
                        if (m[i,j] != 0)
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (!flag) break;
                }
                if (flag) Console.WriteLine("Матрица диагональная");
                else Console.WriteLine("Матрица не диагональная");
            }
            else Console.WriteLine("Матрица не диагональная");
        }

        public void IsZero(Matrix m)  // Проверка на нулевуюую матрицу
        {
            if (m.IsSquareBool())
            {
                bool flag = true;
                for (int i = 0; i < this.Row; i++)
                {
                    for (int j = 0; j < this.Col; j++)
                    {
                        if (m[i,j] != 0)
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (!flag) break;
                }
                if (flag) Console.WriteLine("Матрица нулевая");
                else Console.WriteLine("Матрица не нулевая");
            }
            else Console.WriteLine("Матрица не нулевая");
        }

        public void IsSingle(Matrix m)  // Проверка на единичную матрицу
        {
            if (m.IsSquareBool())
            {
                bool flag = true;
                for (int i = 0; i < this.Row; i++)
                {
                    for (int j = 0; j < this.Col; j++)
                    {
                        if (i == j & m[i,j] == 1) continue;
                        if (m[i,j] != 0)
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (!flag) break;
                }
                if (flag) Console.WriteLine("Матрица единичная");
                else Console.WriteLine("Матрица не единичная");
            }
            else Console.WriteLine("Матрица не единичная");
        }

        public void IsSymmetrical(Matrix m)  // Проверка на симметричную матрицу
        {
            if (m.IsSquareBool())
            {
                bool flag = true;
                for (int i = 0; i < this.Row; i++)
                {
                    for (int j = 0; j < this.Col; j++)
                    {
                        if (i == j) continue;
                        if (m[i,j] != m[j,i])
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (!flag) break;
                }
                if (flag) Console.WriteLine("Матрица симметричная");
                else Console.WriteLine("Матрица не симметричная");
            }
            else Console.WriteLine("Матрица не симметричная");
        }

        public void IsUpperTriangular(Matrix m)  // Проверка на верхнюю треугольную матрицу
        {
            if (m.IsSquareBool())
            {
                bool flag = true;
                for (int i = 0; i < this.Row; i++)
                {
                    for (int j = 0; j < this.Col; j++)
                    {
                        if (i < j & m[i,j] != 0)
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (!flag) break;
                }
                if (flag) Console.WriteLine("Матрица верхняя треугольная");
                else Console.WriteLine("Матрица не верхняя треугольная");
            }
            else Console.WriteLine("Матрица не верхняя треугольная");
        }

        public void IsLowerTriangular(Matrix m)  // Проверка на нижнюю треугольную матрицу
        {
            if (m.IsSquareBool())
            {
                bool flag = true;
                for (int i = 0; i < this.Row; i++)
                {
                    for (int j = 0; j < this.Col; j++)
                    {
                        if (i > j & m[i,j] != 0)
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (!flag) break;
                }
                if (flag) Console.WriteLine("Матрица нижняя треугольная");
                else Console.WriteLine("Матрица не нижняя треугольная");
            }
            else Console.WriteLine("Матрица не нижняя треугольная");
        }

        public static bool operator == (Matrix m1, Matrix m2)
        {
            if (m1.Row == m2.Row && m1.Col == m2.Col)
            {
                bool flag = true;
                for (int i = 0; i < m1.Row; i++)
                {
                    for (int j = 0; j < m1.Col; j++)
                    {
                        if (m1[i, j] != m2[i, j])
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (!flag) break;
                }
                if (flag) return true;
                else return false;
            }
            else return false;
        }

        public static bool operator != (Matrix m1, Matrix m2)
        {
            if (m1.Row == m2.Row && m1.Col == m2.Col)
            {
                bool flag = true;
                for (int i = 0; i < m1.Row; i++)
                {
                    for (int j = 0; j < m1.Col; j++)
                    {
                        if (m1[i, j] == m2[i, j])
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (!flag) break;
                }
                if (flag) return true;
                else return false;
            }
            else return false;
        }
    }
}
