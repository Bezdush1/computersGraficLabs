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
        {-2.5, -2.5, 0, 1},//1
        {-2.5, 2.5, 0, 1},//2
        {2.5, 2.5, 0, 1},//3
        {2.5, -2.5, 0, 1},//4

        {-2.5, 2.5, 0, 1},//5
        {2.5, 2.5, 0, 1},//6
        {2.5, 7.5, 0, 1},//7
        {-2.5, 7.5, 0, 1},//8

        {0, -2.5, 0, 1},//9
        {0, -4.5, 0, 1},//10
        {-2.5, -4.5, 0, 1},//11
        {-2.5, -2.5, 0, 1},//12

        {0, -2.5, 0, 1},//13
        {0, -4.5, 0, 1},//14
        {2.5, -4.5, 0, 1},//15
        {2.5, -2.5, 0, 1},//16

        {-2, 3, 0, 1},//17
        {2, 3, 0, 1},//18
        {2, 4, 0, 1},//19
        {-2, 4, 0, 1},//20

        {1.5, 6.5, 0, 1},//21
        {1.5, 5.5, 0, 1},//22
        {0.5, 5.5, 0, 1},//23
        {0.5, 6.5, 0, 1},//24

        {-0.5, 6.5, 0, 1},//25
        {-0.5, 5.5, 0, 1},//26
        {-1.5, 5.5, 0, 1},//27
        {-1.5, 6.5, 0, 1},//28
        };

        //матрица мировых координат
        private static readonly double[,] MatrixB = {
        {-2.5, -2.5, 5, 1},//29
        {-2.5, 2.5, 5, 1},//30
        {2.5, 2.5, 5, 1},//31
        {2.5, -2.5, 5, 1},//32

        {-2.5, 2.5, 5, 1},//33
        {2.5, 2.5, 5, 1},//34
        {2.5, 7.5, 5, 1},//35
        {-2.5, 7.5, 5, 1},//36

        {0, -2.5, 5, 1},//37
        {0, -4.5, 5, 1},//38
        {-2.5, -4.5, 5, 1},//39
        {-2.5, -2.5, 5, 1},//40

        {0, -2.5, 5, 1},//41
        {0, -4.5, 5, 1},//42
        {2.5, -4.5, 5, 1},//43
        {2.5, -2.5, 5, 1},//44
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
            //DrawXYFront(g, pen, a);
            //DrawXYBack(g, pen, b);
            //DrawConnection(g, pen, a, b);

            DefinePosition(a, b, g, pen);
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

        public static void DefinePosition(double[,] matrixA, double[,] matrixB, Graphics g, Pen pen)
        {
            decimal v06x = (decimal)matrixB[7, 0] - (decimal)matrixA[7, 0];
            decimal v06y = (decimal)matrixB[7, 1] - (decimal)matrixA[7, 1]; 
            decimal v05x = (decimal)matrixA[6, 0] - (decimal)matrixA[7, 0];
            decimal v05y = (decimal)matrixA[6, 1] - (decimal)matrixA[7, 1];

            decimal nz = v06x*v05y - v06y*v05x;

            if ( nz <= 0 )
            {
                //рисуем низ фигуры
                g.DrawLine(pen, (float)matrixA[10, 0], (float)matrixA[10, 1],
                    (float)matrixA[14, 0], (float)matrixA[14, 1]);

                g.DrawLine(pen, (float)matrixA[14, 0], (float)matrixA[14, 1],
                    (float)matrixB[14, 0], (float)matrixB[14, 1]);

                g.DrawLine(pen, (float)matrixB[14, 0], (float)matrixB[14, 1],
                    (float)matrixB[10, 0], (float)matrixB[10, 1]);

                g.DrawLine(pen, (float)matrixB[10, 0], (float)matrixB[10, 1],
                    (float)matrixA[10, 0], (float)matrixA[10, 1]);

                g.DrawLine(pen, (float)matrixA[13, 0], (float)matrixA[13, 1],
                    (float)matrixB[9, 0], (float)matrixB[9, 1]);
            }
            else
            {
                //рисуем верх
                g.DrawLine(pen, (float)matrixA[7, 0], (float)matrixA[7, 1],
                    (float)matrixA[6, 0], (float)matrixA[6, 1]);

                g.DrawLine(pen, (float)matrixA[6, 0], (float)matrixA[6, 1],
                     (float)matrixB[6, 0], (float)matrixB[6, 1]);

                g.DrawLine(pen, (float)matrixB[6, 0], (float)matrixB[6, 1],
                    (float)matrixB[7, 0], (float)matrixB[7, 1]);

                g.DrawLine(pen, (float)matrixB[7, 0], (float)matrixB[7, 1],
                    (float)matrixA[7, 0], (float)matrixA[7, 1]);
            }

            decimal v08x = (decimal)matrixA[7, 0] - (decimal)matrixA[10, 0];
            decimal v08y = (decimal)matrixA[7, 1] - (decimal)matrixA[10, 1];
            decimal v039x = (decimal)matrixB[10, 0] - (decimal)matrixA[10, 0];
            decimal v039y = (decimal)matrixB[10, 1] - (decimal)matrixA[10, 1];

            decimal nz2 = v08x*v039y - v08y*v039x;

            if (nz2 <= 0)
            {
                //рисуем левую сторону
                g.DrawLine(pen, (float)matrixA[10, 0], (float)matrixA[10, 1],
                    (float)matrixB[10, 0], (float)matrixB[10, 1]);

                g.DrawLine(pen, (float)matrixB[10, 0], (float)matrixB[10, 1],
                    (float)matrixB[11, 0], (float)matrixB[11, 1]);

                g.DrawLine(pen, (float)matrixB[11, 0], (float)matrixB[11, 1],
                    (float)matrixA[11, 0], (float)matrixA[11, 1]);

                g.DrawLine(pen, (float)matrixA[11, 0], (float)matrixA[11, 1],
                    (float)matrixA[10, 0], (float)matrixA[10, 1]);


                g.DrawLine(pen, (float)matrixA[0, 0], (float)matrixA[0, 1],
                    (float)matrixB[0, 0], (float)matrixB[0, 1]);

                g.DrawLine(pen, (float)matrixB[0, 0], (float)matrixB[0, 1],
                    (float)matrixB[1, 0], (float)matrixB[1, 1]);

                g.DrawLine(pen, (float)matrixB[1, 0], (float)matrixB[1, 1],
                    (float)matrixA[1, 0], (float)matrixA[1, 1]);

                g.DrawLine(pen, (float)matrixA[1, 0], (float)matrixA[1, 1],
                    (float)matrixA[0, 0], (float)matrixA[0, 1]);


                g.DrawLine(pen, (float)matrixA[4, 0], (float)matrixA[4, 1],
                    (float)matrixB[4, 0], (float)matrixB[4, 1]);

                g.DrawLine(pen, (float)matrixB[4, 0], (float)matrixB[4, 1],
                    (float)matrixB[7, 0], (float)matrixB[7, 1]);

                g.DrawLine(pen, (float)matrixB[7, 0], (float)matrixB[7, 1],
                    (float)matrixA[7, 0], (float)matrixA[7, 1]);

                g.DrawLine(pen, (float)matrixA[7, 0], (float)matrixA[7, 1],
                    (float)matrixA[4, 0], (float)matrixA[4, 1]);
            }
            else
            {
                //рисуем правую сторону
                g.DrawLine(pen, (float)matrixA[14, 0], (float)matrixA[14, 1],
                    (float)matrixB[14, 0], (float)matrixB[14, 1]);

                g.DrawLine(pen, (float)matrixB[14, 0], (float)matrixB[14, 1],
                    (float)matrixB[15, 0], (float)matrixB[15, 1]);

                g.DrawLine(pen, (float)matrixB[15, 0], (float)matrixB[15, 1],
                    (float)matrixA[15, 0], (float)matrixA[15, 1]);

                g.DrawLine(pen, (float)matrixA[15, 0], (float)matrixA[15, 1],
                    (float)matrixA[14, 0], (float)matrixA[14, 1]);


                g.DrawLine(pen, (float)matrixA[3, 0], (float)matrixA[3, 1],
                    (float)matrixB[3, 0], (float)matrixB[3, 1]);

                g.DrawLine(pen, (float)matrixB[3, 0], (float)matrixB[3, 1],
                    (float)matrixB[2, 0], (float)matrixB[2, 1]);

                g.DrawLine(pen, (float)matrixB[2, 0], (float)matrixB[2, 1],
                    (float)matrixA[2, 0], (float)matrixA[2, 1]);

                g.DrawLine(pen, (float)matrixA[2, 0], (float)matrixA[2, 1],
                    (float)matrixA[3, 0], (float)matrixA[3, 1]);


                g.DrawLine(pen, (float)matrixA[5, 0], (float)matrixA[5, 1],
                    (float)matrixB[5, 0], (float)matrixB[5, 1]);

                g.DrawLine(pen, (float)matrixB[5, 0], (float)matrixB[5, 1],
                    (float)matrixB[6, 0], (float)matrixB[6, 1]);

                g.DrawLine(pen, (float)matrixB[6, 0], (float)matrixB[6, 1],
                    (float)matrixA[6, 0], (float)matrixA[6, 1]);

                g.DrawLine(pen, (float)matrixA[6, 0], (float)matrixA[6, 1],
                    (float)matrixA[5, 0], (float)matrixA[5, 1]);
            }

            decimal v0015x = (decimal)matrixA[14, 0] - (decimal)matrixA[10, 0];
            decimal v0015y = (decimal)matrixA[14, 1] - (decimal)matrixA[10, 1];
            decimal v008x = (decimal)matrixA[7, 0] - (decimal)matrixA[10, 0];
            decimal v008y = (decimal)matrixA[7, 1] - (decimal)matrixA[10, 1];

            decimal nz3 = v0015x * v008y - v0015y * v008x;

            if (nz3 <= 0)
            {
                //рисуем фронт
                g.DrawLine(pen, (float)matrixA[10, 0], (float)matrixA[10, 1],
                    (float)matrixA[14, 0], (float)matrixA[14, 1]);

                g.DrawLine(pen, (float)matrixA[14, 0], (float)matrixA[14, 1],
                    (float)matrixA[15, 0], (float)matrixA[15, 1]);

                g.DrawLine(pen, (float)matrixA[15, 0], (float)matrixA[15, 1],
                    (float)matrixA[11, 0], (float)matrixA[11, 1]);

                g.DrawLine(pen, (float)matrixA[11, 0], (float)matrixA[11, 1],
                    (float)matrixA[10, 0], (float)matrixA[10, 1]);


                g.DrawLine(pen, (float)matrixA[12, 0], (float)matrixA[12, 1],
                    (float)matrixA[13, 0], (float)matrixA[13, 1]);


                g.DrawLine(pen, (float)matrixA[0, 0], (float)matrixA[0, 1],
                    (float)matrixA[3, 0], (float)matrixA[3, 1]);

                g.DrawLine(pen, (float)matrixA[3, 0], (float)matrixA[3, 1],
                    (float)matrixA[2, 0], (float)matrixA[2, 1]);

                g.DrawLine(pen, (float)matrixA[2, 0], (float)matrixA[2, 1],
                    (float)matrixA[1, 0], (float)matrixA[1, 1]);

                g.DrawLine(pen, (float)matrixA[1, 0], (float)matrixA[1, 1],
                    (float)matrixA[0, 0], (float)matrixA[0, 1]);


                g.DrawLine(pen, (float)matrixA[4, 0], (float)matrixA[4, 1],
                    (float)matrixA[5, 0], (float)matrixA[5, 1]);

                g.DrawLine(pen, (float)matrixA[5, 0], (float)matrixA[5, 1],
                    (float)matrixA[6, 0], (float)matrixA[6, 1]);

                g.DrawLine(pen, (float)matrixA[6, 0], (float)matrixA[6, 1],
                    (float)matrixA[7, 0], (float)matrixA[7, 1]);

                g.DrawLine(pen, (float)matrixA[7, 0], (float)matrixA[7, 1],
                    (float)matrixA[4, 0], (float)matrixA[4, 1]);



                g.DrawLine(pen, (float)matrixA[16, 0], (float)matrixA[16, 1],
                    (float)matrixA[17, 0], (float)matrixA[17, 1]);

                g.DrawLine(pen, (float)matrixA[17, 0], (float)matrixA[17, 1],
                    (float)matrixA[18, 0], (float)matrixA[18, 1]);

                g.DrawLine(pen, (float)matrixA[18, 0], (float)matrixA[18, 1],
                    (float)matrixA[19, 0], (float)matrixA[19, 1]);

                g.DrawLine(pen, (float)matrixA[19, 0], (float)matrixA[19, 1],
                    (float)matrixA[16, 0], (float)matrixA[16, 1]);


                g.DrawLine(pen, (float)matrixA[20, 0], (float)matrixA[20, 1],
                    (float)matrixA[21, 0], (float)matrixA[21, 1]);

                g.DrawLine(pen, (float)matrixA[21, 0], (float)matrixA[21, 1],
                    (float)matrixA[22, 0], (float)matrixA[22, 1]);

                g.DrawLine(pen, (float)matrixA[22, 0], (float)matrixA[22, 1],
                    (float)matrixA[23, 0], (float)matrixA[23, 1]);

                g.DrawLine(pen, (float)matrixA[23, 0], (float)matrixA[23, 1],
                    (float)matrixA[20, 0], (float)matrixA[20, 1]);


                g.DrawLine(pen, (float)matrixA[24, 0], (float)matrixA[24, 1],
                    (float)matrixA[25, 0], (float)matrixA[25, 1]);

                g.DrawLine(pen, (float)matrixA[25, 0], (float)matrixA[25, 1],
                    (float)matrixA[26, 0], (float)matrixA[26, 1]);

                g.DrawLine(pen, (float)matrixA[26, 0], (float)matrixA[26, 1],
                    (float)matrixA[27, 0], (float)matrixA[27, 1]);

                g.DrawLine(pen, (float)matrixA[27, 0], (float)matrixA[27, 1],
                    (float)matrixA[24, 0], (float)matrixA[24, 1]);
            }
            else
            {
                //рисуем зад
                g.DrawLine(pen, (float)matrixB[10, 0], (float)matrixB[10, 1],
                    (float)matrixB[14, 0], (float)matrixB[14, 1]);

                g.DrawLine(pen, (float)matrixB[14, 0], (float)matrixB[14, 1],
                    (float)matrixB[15, 0], (float)matrixB[15, 1]);

                g.DrawLine(pen, (float)matrixB[15, 0], (float)matrixB[15, 1],
                    (float)matrixB[11, 0], (float)matrixB[11, 1]);

                g.DrawLine(pen, (float)matrixB[11, 0], (float)matrixB[11, 1],
                    (float)matrixB[10, 0], (float)matrixB[10, 1]);

                g.DrawLine(pen, (float)matrixB[9, 0], (float)matrixB[9, 1],
                    (float)matrixB[8, 0], (float)matrixB[8, 1]);


                g.DrawLine(pen, (float)matrixB[0, 0], (float)matrixB[0, 1],
                    (float)matrixB[3, 0], (float)matrixB[3, 1]);

                g.DrawLine(pen, (float)matrixB[3, 0], (float)matrixB[3, 1],
                    (float)matrixB[2, 0], (float)matrixB[2, 1]);

                g.DrawLine(pen, (float)matrixB[2, 0], (float)matrixB[2, 1],
                    (float)matrixB[1, 0], (float)matrixB[1, 1]);

                g.DrawLine(pen, (float)matrixB[1, 0], (float)matrixB[1, 1],
                    (float)matrixB[0, 0], (float)matrixB[0, 1]);


                g.DrawLine(pen, (float)matrixB[4, 0], (float)matrixB[4, 1],
                    (float)matrixB[5, 0], (float)matrixB[5, 1]);

                g.DrawLine(pen, (float)matrixB[5, 0], (float)matrixB[5, 1],
                    (float)matrixB[6, 0], (float)matrixB[6, 1]);

                g.DrawLine(pen, (float)matrixB[6, 0], (float)matrixB[6, 1],
                    (float)matrixB[7, 0], (float)matrixB[7, 1]);

                g.DrawLine(pen, (float)matrixB[7, 0], (float)matrixB[7, 1],
                    (float)matrixB[4, 0], (float)matrixB[4, 1]);
            }
        }
    }
}
