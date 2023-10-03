using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace lab2
{
    public static class Cripper
    {
        // сторона одной клетки
        public static int Cell = 20;

        // экранные координаты передней части 
        public static double[,] coordinateMatrixFront;

        // экранные координаты задней части
        public static double[,] coordinateMatrixBack;

        //матрица мировых координат
        private static readonly double[,] MatrixF = {
        {-2, -2.5, 0, 1},
        {-2, 2.5, 0, 1},
        {2, 2.5, 0, 1},
        {2, -2.5, 0, 1},

        {-2.5, 2.5, 0, 1},
        {2.5, 2.5, 0, 1},
        {2.5, 7.5, 0, 1},
        {-2.5, 7.5, 0, 1},

        {0, -2.5, 0, 1},
        {0, -4.5, 0, 1},
        {-2.5, -4.5, 0, 1},
        {-2.5, -2.5, 0, 1},

        {0, -2.5, 0, 1},
        {0, -4.5, 0, 1},
        {2.5, -4.5, 0, 1},
        {2.5, -2.5, 0, 1},

        {-2, 3, 0, 1},
        {2, 3, 0, 1},
        {2, 4, 0, 1},
        {-2, 4, 0, 1},

        {1.5, 6.5, 0, 1},
        {1.5, 5.5, 0, 1},
        {0.5, 5.5, 0, 1},
        {0.5, 6.5, 0, 1},

        {-0.5, 6.5, 0, 1},
        {-0.5, 5.5, 0, 1},
        {-1.5, 5.5, 0, 1},
        {-1.5, 6.5, 0, 1},
        };

        //матрица мировых координат
        private static readonly double[,] MatrixB = {
        {-2, -2.5, 3, 1},
        {-2, 2.5, 3, 1},
        {2, 2.5, 3, 1},
        {2, -2.5, 3, 1},

        {-2.5, 2.5, 3, 1},
        {2.5, 2.5, 3, 1},
        {2.5, 7.5, 3, 1},
        {-2.5, 7.5, 3, 1},

        {0, -2.5, 3, 1},
        {0, -4.5, 3, 1},
        {-2.5, -4.5, 3, 1},
        {-2.5, -2.5, 3, 1},

        {0, -2.5, 3, 1},
        {0, -4.5, 3, 1},
        {2.5, -4.5, 3, 1},
        {2.5, -2.5, 3, 1},
        };

        // матрица смежности
        public static readonly int[,] contiguityMatrixFront = {
        {0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},

        {0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},

        {0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},

        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},

        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},

        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0},

        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0},
    };

        // матрица смежности
        public static readonly int[,] contiguityMatrixBack = {
        {0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},

        {0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},

        {0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},

        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
    };

        static Cripper()
        {
            coordinateMatrixFront = MatrixF.Clone() as double[,];
            coordinateMatrixBack = MatrixB.Clone() as double[,];
        }


        // Сброс координат
        public static void Reset()
        {
            Array.Clear(coordinateMatrixFront, 0, coordinateMatrixFront.Length);
            Array.Clear(coordinateMatrixBack, 0, coordinateMatrixBack.Length);
            coordinateMatrixFront = MatrixF.Clone() as double[,];
            coordinateMatrixBack = MatrixB.Clone() as double[,];
        }


        // Перевод из мировых в экранные
        public static double[,] GetDisplayCoordinates(double[,] matrix)
        {
            var m = matrix.Clone() as double[,];
            for (int i = 0; i < m.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    m[i, j] *= Cell;
                }
            }

            return m;
        }

        // Общая функция для отрисовки 2D изображения на основе матрицы смежности
        public static void Draw2DImage(Graphics g, Pen pen, double[,] matrix, int[,] contiguityMatrix)
        {
            for (int i = 0; i < contiguityMatrix.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < contiguityMatrix.GetUpperBound(0) + 1; j++)
                {
                    if (contiguityMatrix[i, j] == 1) // смотрим по матрице смежности
                        g.DrawLine(pen, (float)matrix[i, 0], (float)matrix[i, 1],
                            (float)matrix[j, 0], (float)matrix[j, 1]);
                }
            }
        }

        // Отрисовка 2D изображения для матрицы front
        public static void DrawXYFront(Graphics g, Pen pen, double[,] matrix)
        {
            Draw2DImage(g, pen, matrix, contiguityMatrixFront);
        }

        // Отрисовка 2D изображения для матрицы back
        public static void DrawXYBack(Graphics g, Pen pen, double[,] matrix)
        {
            Draw2DImage(g, pen, matrix, contiguityMatrixBack);
        }

        // Отрисовка связей для объема фигуры
        public static void DrawConnection(Graphics g, Pen pen, double[,] a, double[,] b)
        {

            for (int i = 0; i < b.GetUpperBound(0) + 1; i++)
            {
                g.DrawLine(pen, (float)a[i, 0], (float)a[i, 1],
                    (float)b[i, 0], (float)b[i, 1]);
            }
        }

        // Отрисовка проекции
        public static void Draw(Graphics g, Pen pen, double[,] ma, double[,] mb)
        {
            var a = GetDisplayCoordinates(ma);
            var b = GetDisplayCoordinates(mb);
            DrawXYFront(g, pen, a);
            DrawXYBack(g, pen, b);
            DrawConnection(g, pen, a, b);
        }

        public static void Rotate(Graphics g, int degrees, char axis)
        {
            // Преобразование угла
            double angle = Math.PI * degrees / 180.0;

            double cosAngle = Math.Cos(angle);
            double sinAngle = Math.Sin(angle);

            double[,] rotateT = null;

            if (axis == 'X')
            {
                rotateT = new double[,]
                {
            { 1, 0, 0, 0 },
            { 0, cosAngle, sinAngle, 0 },
            { 0, -sinAngle, cosAngle, 0 },
            { 0, 0, 0, 1 }
                };
            }
            else if (axis == 'Y')
            {
                rotateT = new double[,]
                {
            { cosAngle, 0, -sinAngle, 0 },
            { 0, 1, 0, 0 },
            { sinAngle, 0, cosAngle, 0 },
            { 0, 0, 0, 1 }
                };
            }
            else if (axis == 'Z')
            {
                rotateT = new double[,]
                {
            { cosAngle, sinAngle, 0, 0 },
            { -sinAngle, cosAngle, 0, 0 },
            { 0, 0, 1, 0 },
            { 0, 0, 0, 1 }
                };
            }

            if (rotateT != null)
            {
                double[,] newMatrixF = MultiplyMatrices(coordinateMatrixFront, rotateT);
                double[,] newMatrixB = MultiplyMatrices(coordinateMatrixBack, rotateT);

                coordinateMatrixFront = newMatrixF.Clone() as double[,];
                coordinateMatrixBack = newMatrixB.Clone() as double[,];

                Draw(g, new Pen(Color.Black, 2), coordinateMatrixFront, coordinateMatrixBack);
            }
        }


        // Масштабирование 
        public static void Scale(Graphics g, double x, double y, double z)
        {

            // Матрица масштабирования
            double[,] scaleT = {
                {x,0,0,0 },
                {0,y, 0, 0},
                {0, 0,z, 0 },
                {0, 0, 0, 1 }}
            ;

            double[,] newMatrixF = MultiplyMatrices(coordinateMatrixFront, scaleT);
            double[,] newMatrixB = MultiplyMatrices(coordinateMatrixBack, scaleT);

            coordinateMatrixFront = newMatrixF.Clone() as double[,];
            coordinateMatrixBack = newMatrixB.Clone() as double[,];

            Draw(g, new Pen(Color.Black, 2), coordinateMatrixFront, coordinateMatrixBack);
        }

        // Перемещение 
        public static void Move(Graphics g, int dx, int dy, int dz)
        {
            // Матрица перемещения
            double[,] moveT = {
                {1,0,0,0 },
                {0,1, 0, 0},
                {0, 0,1, 0 },
                {dx, dy, dz, 1 }
            };

            double[,] newMatrixF = MultiplyMatrices(coordinateMatrixFront, moveT);
            double[,] newMatrixB = MultiplyMatrices(coordinateMatrixBack, moveT);

            coordinateMatrixFront = newMatrixF.Clone() as double[,];
            coordinateMatrixBack = newMatrixB.Clone() as double[,];

            Draw(g, new Pen(Color.Black, 2), coordinateMatrixFront, coordinateMatrixBack);
        }

        public static void DrawIzometric(Graphics g)
        {
            // Матрица проекции
            double[,] projT = {
                {0.7071, -0.4082, 0, 0},
                {0, 0.8165, 0, 0},
                {0.7071, 0.4082, 0, 0},
                {0, 0, 0, 1}
            };

            double[,] newMatrixF = MultiplyMatrices(coordinateMatrixFront, projT);
            double[,] newMatrixB = MultiplyMatrices(coordinateMatrixBack, projT);

            Draw(g, new Pen(Color.Red, 2), newMatrixF, newMatrixB);
        }

        // Метод для перемножения матриц
        private static double[,] MultiplyMatrices(double[,] matrixA, double[,] matrixB)
        {
            int rowsA = matrixA.GetLength(0);
            int colsA = matrixA.GetLength(1);
            int colsB = matrixB.GetLength(1);
            double[,] result = new double[rowsA, colsB];

            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    for (int k = 0; k < colsA; k++)
                    {
                        result[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }

            return result;
        }
    }
}
