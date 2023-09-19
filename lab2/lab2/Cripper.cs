using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace lab2
{
    public struct Point3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }

    public class Cripper
    {
        private Bitmap bmp;
        private PictureBox pictureBox;

        const int CELL = 20;

        private Point3D[] bodyFront;
        private Point3D[] headFront;
        private Point3D[] leftLegsFront;
        private Point3D[] rightLegsFront;
        private Point3D[] mouth;
        private Point3D[] rightEye;
        private Point3D[] leftEye;
        private Point3D[] bodyBack;
        private Point3D[] headBack;
        private Point3D[] leftLegsBack;
        private Point3D[] rightLegsBack;

        private Point3D[] zAxisConnectionsFront;
        private Point3D[] zAxisConnectionsBack;

        private Point3D[][] figureFrontArrays;
        private Point3D[][] figureBackArrays;

        private Point3D[][] figureFrontArraysBase;
        private Point3D[][] figureBackArraysBase;

        public Cripper(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
            bmp = new Bitmap(pictureBox.ClientSize.Width, pictureBox.ClientSize.Height);

            InitializeCoordinates();

            figureFrontArraysBase = new Point3D[][]
            {
                bodyFront, headFront, leftLegsFront, rightLegsFront, mouth, rightEye, leftEye
            };

            figureBackArraysBase = new Point3D[][]
            {
                bodyBack, headBack, leftLegsBack, rightLegsBack
            };

            figureFrontArrays = CopyArray(figureFrontArraysBase);
            figureBackArrays = CopyArray(figureBackArraysBase);

            // Инициализация начальных координат соединений точек по оси Z для головы и ног
            zAxisConnectionsFront = new Point3D[bodyFront.Length + headFront.Length + leftLegsFront.Length + rightLegsFront.Length];
            zAxisConnectionsBack = new Point3D[bodyBack.Length + headBack.Length + leftLegsBack.Length + rightLegsBack.Length];

            int index = 0;

            for (int i = 0; i < bodyFront.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(bodyFront[i].X, bodyFront[i].Y, bodyFront[i].Z);
                zAxisConnectionsBack[index] = new Point3D(bodyBack[i].X, bodyBack[i].Y, bodyBack[i].Z);
                index++;
            }

            for (int i = 0; i < headFront.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(headFront[i].X, headFront[i].Y, headFront[i].Z);
                zAxisConnectionsBack[index] = new Point3D(headBack[i].X, headBack[i].Y, headBack[i].Z);
                index++;
            }

            for (int i = 0; i < leftLegsFront.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(leftLegsFront[i].X, leftLegsFront[i].Y, leftLegsFront[i].Z);
                zAxisConnectionsBack[index] = new Point3D(leftLegsBack[i].X, leftLegsBack[i].Y, leftLegsBack[i].Z);
                index++;
            }

            for (int i = 0; i < rightLegsFront.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(rightLegsFront[i].X, rightLegsFront[i].Y, rightLegsFront[i].Z);
                zAxisConnectionsBack[index] = new Point3D(rightLegsBack[i].X, rightLegsBack[i].Y, rightLegsBack[i].Z);
                index++;
            }

        }

        private void InitializeCoordinates()
        { 
            bodyFront = new Point3D[]
            {
        new Point3D(-2, -2.5, 0),
        new Point3D(-2, 2.5, 0),
        new Point3D(2, 2.5, 0),
        new Point3D(2, -2.5, 0)
            };

            headFront = new Point3D[]
            {
        new Point3D(-2.5, 2.5, 0),
        new Point3D(2.5, 2.5, 0),
        new Point3D(2.5, 7.5, 0),
        new Point3D(-2.5, 7.5, 0)
            };

            leftLegsFront = new Point3D[]
            {
        new Point3D(0, -2.5, 0),
        new Point3D(0, -4.5, 0),
        new Point3D(-2.5, -4.5, 0),
        new Point3D(-2.5, -2.5, 0)
            };

            rightLegsFront = new Point3D[]
            {
        new Point3D(0, -2.5, 0),
        new Point3D(0, -4.5, 0),
        new Point3D(2.5, -4.5, 0),
        new Point3D(2.5, -2.5, 0)
            };

            mouth = new Point3D[]
            {
        new Point3D(-2, 3, 0),
        new Point3D(2, 3, 0),
        new Point3D(2, 4, 0),
        new Point3D(-2, 4, 0)
            };

            rightEye = new Point3D[]
            {
        new Point3D(1.5, 6.5, 0),
        new Point3D(1.5, 5.5, 0),
        new Point3D(0.5, 5.5, 0),
        new Point3D(0.5, 6.5, 0),
            };

            leftEye = new Point3D[]
            {
        new Point3D(-0.5, 6.5, 0),
        new Point3D(-0.5, 5.5, 0),
        new Point3D(-1.5, 5.5, 0),
        new Point3D(-1.5, 6.5, 0),
            };

            headBack = new Point3D[]
            {
        new Point3D(-2.5, 2.5, 4),
        new Point3D(2.5, 2.5, 4),
        new Point3D(2.5, 7.5, 4),
        new Point3D(-2.5, 7.5, 4)
            };

            bodyBack = new Point3D[]
            {
        new Point3D(-2, -2.5, 4),
        new Point3D(-2, 2.5, 4),
        new Point3D(2, 2.5, 4),
        new Point3D(2, -2.5, 4)
            };

            leftLegsBack = new Point3D[]
            {
        new Point3D(0, -2.5, 4),
        new Point3D(0, -4.5, 4),
        new Point3D(-2.5, -4.5, 4),
        new Point3D(-2.5, -2.5, 4)
            };

            rightLegsBack = new Point3D[]
            {
        new Point3D(0, -2.5, 4),
        new Point3D(0, -4.5, 4),
        new Point3D(2.5, -4.5, 4),
        new Point3D(2.5, -2.5, 4)
            };
        }


        public void Draw()
        {
            ClearCanvas();

            MultiplyCoordinatesByCell();

            Pen blackPen = new Pen(Color.Black);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);

                int centerX = pictureBox.Width / 2;
                int centerY = pictureBox.Height / 2;

                Matrix transformationMatrix = new Matrix();
                transformationMatrix.Translate(centerX, centerY);
                transformationMatrix.Scale(1, -1);

                g.Transform = transformationMatrix;

                DrawAndFillPolygons(g, blackPen, figureFrontArrays);
                DrawAndFillPolygons(g, blackPen, figureBackArrays);

                // Рисование соединений точек по оси Z
                DrawZAxisConnections(g, blackPen);
            }

            pictureBox.Image = bmp;

            CopyBaseCoordinatesToFigures();
        }

        public void ClearCanvas()
        {
            pictureBox.Image = null;
            bmp = new Bitmap(pictureBox.ClientSize.Width, pictureBox.ClientSize.Height);
        }

        private void DrawAndFillPolygons(Graphics g, Pen drawPen, params Point3D[][] polygons)
        {
            foreach (var polygon in polygons)
            {
                var points2D = new PointF[polygon.Length];
                for (int i = 0; i < polygon.Length; i++)
                {
                    points2D[i] = new PointF((float)polygon[i].X, (float)polygon[i].Y);
                }
                g.DrawPolygon(drawPen, points2D);
            }
        }


        private void DrawZAxisConnections(Graphics g, Pen drawPen)
        {
            for (int i = 0; i < zAxisConnectionsFront.Length; i++)
            {
                g.DrawLine(drawPen, (float)zAxisConnectionsFront[i].X, (float)zAxisConnectionsFront[i].Y,
                    (float)zAxisConnectionsBack[i].X, (float)zAxisConnectionsBack[i].Y);
            }
        }

        public void RotateX(int angleInDegrees)
        {
            ApplyRotationToFigure(angleInDegrees, 'X');
            Draw();
        }

        public void RotateY(int angleInDegrees)
        {
            ApplyRotationToFigure(angleInDegrees, 'Y');
            Draw();
        }

        public void RotateZ(int angleInDegrees)
        {
            ApplyRotationToFigure(angleInDegrees, 'Z');
            Draw();
        }

        private void ApplyRotationToFigure(float angleInDegrees, char axis)
        {
            // Преобразование угла из градусов в радианы
            float angleInRadians = (float)(angleInDegrees * Math.PI / 180);

            for (int i = 0; i < figureFrontArrays.Length; i++)
            {
                for (int j = 0; j < figureFrontArrays[i].Length; j++)
                {
                    float x = (float)figureFrontArraysBase[i][j].X;
                    float y = (float)figureFrontArraysBase[i][j].Y;
                    float z = (float)figureFrontArraysBase[i][j].Z;

                    float newX = 0, newY = 0, newZ = 0;

                    if (axis == 'X')
                    {
                        newY = y * (float)Math.Cos(angleInRadians) - z * (float)Math.Sin(angleInRadians);
                        newZ = y * (float)Math.Sin(angleInRadians) + z * (float)Math.Cos(angleInRadians);
                        newX = x;
                    }
                    else if (axis == 'Y')
                    {
                        newX = x * (float)Math.Cos(angleInRadians) + z * (float)Math.Sin(angleInRadians);
                        newZ = -x * (float)Math.Sin(angleInRadians) + z * (float)Math.Cos(angleInRadians);
                        newY = y;
                    }
                    else if (axis == 'Z')
                    {
                        newX = x * (float)Math.Cos(angleInRadians) - y * (float)Math.Sin(angleInRadians);
                        newY = x * (float)Math.Sin(angleInRadians) + y * (float)Math.Cos(angleInRadians);
                        newZ = z;
                    }

                    figureFrontArrays[i][j] = new Point3D(newX, newY, newZ);

                    // Обновление угла в градусах
                    figureFrontArrays[i][j].Z = angleInDegrees;
                }
            }

            // Обновление координат соединений точек по оси Z для фронтальной стороны
            UpdateZAxisConnectionsFront();

            for (int i = 0; i < figureBackArrays.Length; i++)
            {
                for (int j = 0; j < figureBackArrays[i].Length; j++)
                {
                    float x = (float)figureBackArraysBase[i][j].X;
                    float y = (float)figureBackArraysBase[i][j].Y;
                    float z = (float)figureBackArraysBase[i][j].Z;

                    float newX = 0, newY = 0, newZ = 0;

                    if (axis == 'X')
                    {
                        newY = y * (float)Math.Cos(angleInRadians) - z * (float)Math.Sin(angleInRadians);
                        newZ = y * (float)Math.Sin(angleInRadians) + z * (float)Math.Cos(angleInRadians);
                        newX = x;
                    }
                    else if (axis == 'Y')
                    {
                        newX = x * (float)Math.Cos(angleInRadians) + z * (float)Math.Sin(angleInRadians);
                        newZ = -x * (float)Math.Sin(angleInRadians) + z * (float)Math.Cos(angleInRadians);
                        newY = y;
                    }
                    else if (axis == 'Z')
                    {
                        newX = x * (float)Math.Cos(angleInRadians) - y * (float)Math.Sin(angleInRadians);
                        newY = x * (float)Math.Sin(angleInRadians) + y * (float)Math.Cos(angleInRadians);
                        newZ = z;
                    }

                    figureBackArrays[i][j] = new Point3D(newX, newY, newZ);

                    // Обновление угла в градусах
                    figureBackArrays[i][j].Z = angleInDegrees;
                }
            }

            // Обновление координат соединений точек по оси Z для задней стороны
            UpdateZAxisConnectionsBack();
        }


        private void UpdateZAxisConnectionsFront()
        {
            int index = 0;

            for (int i = 0; i < bodyFront.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(figureFrontArrays[0][i].X, figureFrontArrays[0][i].Y, figureFrontArrays[0][i].Z);
                index++;
            }

            for (int i = 0; i < headFront.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(figureFrontArrays[1][i].X, figureFrontArrays[1][i].Y, figureFrontArrays[1][i].Z);
                index++;
            }

            for (int i = 0; i < leftLegsFront.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(figureFrontArrays[2][i].X, figureFrontArrays[2][i].Y, figureFrontArrays[2][i].Z);
                index++;
            }

            for (int i = 0; i < rightLegsFront.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(figureFrontArrays[3][i].X, figureFrontArrays[3][i].Y, figureFrontArrays[3][i].Z);
                index++;
            }
        }

        private void UpdateZAxisConnectionsBack()
        {
            int index = 0;

            for (int i = 0; i < bodyBack.Length; i++)
            {
                zAxisConnectionsBack[index] = new Point3D(figureBackArrays[0][i].X, figureBackArrays[0][i].Y, figureBackArrays[0][i].Z);
                index++;
            }

            for (int i = 0; i < headBack.Length; i++)
            {
                zAxisConnectionsBack[index] = new Point3D(figureBackArrays[1][i].X, figureBackArrays[1][i].Y, figureBackArrays[1][i].Z);
                index++;
            }

            for (int i = 0; i < leftLegsBack.Length; i++)
            {
                zAxisConnectionsBack[index] = new Point3D(figureBackArrays[2][i].X, figureBackArrays[2][i].Y, figureBackArrays[2][i].Z);
                index++;
            }

            for (int i = 0; i < rightLegsBack.Length; i++)
            {
                zAxisConnectionsBack[index] = new Point3D(figureBackArrays[3][i].X, figureBackArrays[3][i].Y, figureBackArrays[3][i].Z);
                index++;
            }
        }

        private void UpdateZAxisConnections()
        {
            int index = 0;

            for (int i = 0; i < bodyFront.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(figureFrontArrays[0][i].X, figureFrontArrays[0][i].Y, figureFrontArrays[0][i].Z);
                zAxisConnectionsBack[index] = new Point3D(figureBackArrays[0][i].X, figureBackArrays[0][i].Y, figureBackArrays[0][i].Z);
                index++;
            }

            for (int i = 0; i < headFront.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(figureFrontArrays[1][i].X, figureFrontArrays[1][i].Y, figureFrontArrays[1][i].Z);
                zAxisConnectionsBack[index] = new Point3D(figureBackArrays[1][i].X, figureBackArrays[1][i].Y, figureBackArrays[1][i].Z);
                index++;
            }

            for (int i = 0; i < leftLegsFront.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(figureFrontArrays[2][i].X, figureFrontArrays[2][i].Y, figureFrontArrays[2][i].Z);
                zAxisConnectionsBack[index] = new Point3D(figureBackArrays[2][i].X, figureBackArrays[2][i].Y, figureBackArrays[2][i].Z);
                index++;
            }

            for (int i = 0; i < rightLegsFront.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(figureFrontArrays[3][i].X, figureFrontArrays[3][i].Y, figureFrontArrays[3][i].Z);
                zAxisConnectionsBack[index] = new Point3D(figureBackArrays[3][i].X, figureBackArrays[3][i].Y, figureBackArrays[3][i].Z);
                index++;
            }
        }

        private Point3D[][] CopyArray(Point3D[][] source)
        {
            Point3D[][] copy = new Point3D[source.Length][];

            for (int i = 0; i < source.Length; i++)
            {
                copy[i] = new Point3D[source[i].Length];

                for (int j = 0; j < source[i].Length; j++)
                {
                    copy[i][j] = new Point3D(
                        source[i][j].X,
                        source[i][j].Y,
                        source[i][j].Z
                    );
                }
            }

            return copy;
        }

        private void MultiplyCoordinatesByCell()
        {
            double CELL = 20; // Замените это значение на нужное вам

            // Пройдемся по всем координатам и умножим их на CELL
            foreach (var array in figureFrontArrays)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i].X *= CELL;
                    array[i].Y *= CELL;
                    array[i].Z *= CELL;
                }
            }

            foreach (var array in figureBackArrays)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i].X *= CELL;
                    array[i].Y *= CELL;
                    array[i].Z *= CELL;
                }
            }

            for (int i = 0; i < zAxisConnectionsFront.Length; i++)
            {
                zAxisConnectionsFront[i].X *= CELL;
                zAxisConnectionsFront[i].Y *= CELL;
                zAxisConnectionsFront[i].Z *= CELL;
            }

            for (int i = 0; i < zAxisConnectionsBack.Length; i++)
            {
                zAxisConnectionsBack[i].X *= CELL;
                zAxisConnectionsBack[i].Y *= CELL;
                zAxisConnectionsBack[i].Z *= CELL;
            }
        }

        public void Scale(double scaleX, double scaleY, double scaleZ)
        {
            // Масштабирование фигуры в глобальных координатах
            for (int i = 0; i < figureFrontArrays.Length; i++)
            {
                ScaleFigure(figureFrontArrays[i], scaleX, scaleY, scaleZ);
            }

            for (int i = 0; i < figureBackArrays.Length; i++)
            {
                ScaleFigure(figureBackArrays[i], scaleX, scaleY, scaleZ);
            }

            // Масштабирование матрицы соединений
            ScaleMatrix(zAxisConnectionsFront, scaleX, scaleY, scaleZ);
            ScaleMatrix(zAxisConnectionsBack, scaleX, scaleY, scaleZ);

            // Обновление координат соединений точек по оси Z
            UpdateZAxisConnections();

            // Отобразить масштабированную фигуру
            Draw();
        }



        private void ScaleFigure(Point3D[] figure, double scaleX, double scaleY, double scaleZ)
        {
            for (int i = 0; i < figure.Length; i++)
            {
                figure[i].X *= scaleX;
                figure[i].Y *= scaleY;
                figure[i].Z *= scaleZ;
            }
        }

        private void ScaleMatrix(Point3D[] matrix, double scaleX, double scaleY, double scaleZ)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i].X *= scaleX;
                matrix[i].Y *= scaleY;
                matrix[i].Z *= scaleZ;
            }
        }

        public void Move(int deltaX, int deltaY, int deltaZ)
        {
            for (int i = 0; i < figureFrontArrays.Length; i++)
            {
                MoveFigure(figureFrontArrays[i], deltaX, deltaY, deltaZ);
            }

            for (int i = 0; i < figureBackArrays.Length; i++)
            {
                MoveFigure(figureBackArrays[i], deltaX, deltaY, deltaZ);
            }

            // Обновление координат соединений точек по оси Z
            UpdateZAxisConnections();

            Draw();
        }

        private void MoveFigure(Point3D[] figure, int deltaX, int deltaY, int deltaZ)
        {
            for (int i = 0; i < figure.Length; i++)
            {
                figure[i] = new Point3D(
                    figure[i].X + deltaX,
                    figure[i].Y + deltaY,
                    figure[i].Z + deltaZ
                );
            }
        }

        // В вашем классе Cripper, создайте метод для преобразования текущих трехмерных координат в изометрические координаты
        public void ConvertToIsometric()
        {
            for (int i = 0; i < figureFrontArrays.Length; i++)
            {
                for (int j = 0; j < figureFrontArrays[i].Length; j++)
                {
                    var point = figureFrontArraysBase[i][j];
                    float isoX = (float)((point.X - point.Y) * Math.Cos(Math.PI / 6));
                    float isoY = (float)(point.Z + (point.X + point.Y) * Math.Sin(Math.PI / 6));
                    figureFrontArrays[i][j] = new Point3D(isoX, isoY, point.Z);
                }
            }

            for (int i = 0; i < figureBackArrays.Length; i++)
            {
                for (int j = 0; j < figureBackArrays[i].Length; j++)
                {
                    var point = figureBackArraysBase[i][j];
                    float isoX = (float)((point.X - point.Y) * Math.Cos(Math.PI / 6));
                    float isoY = (float)(point.Z + (point.X + point.Y) * Math.Sin(Math.PI / 6));
                    figureBackArrays[i][j] = new Point3D(isoX, isoY, point.Z);
                }
            }

            // Обновите координаты соединений точек по оси Z
            UpdateZAxisConnections();

            Draw();
        }

        private void CopyBaseCoordinatesToFigures()
        {
            for (int i = 0; i < figureFrontArrays.Length; i++)
            {
                for (int j = 0; j < figureFrontArrays[i].Length; j++)
                {
                    figureFrontArrays[i][j] = new Point3D(
                        figureFrontArraysBase[i][j].X,
                        figureFrontArraysBase[i][j].Y,
                        figureFrontArraysBase[i][j].Z
                    );
                }
            }

            for (int i = 0; i < figureBackArrays.Length; i++)
            {
                for (int j = 0; j < figureBackArrays[i].Length; j++)
                {
                    figureBackArrays[i][j] = new Point3D(
                        figureBackArraysBase[i][j].X,
                        figureBackArraysBase[i][j].Y,
                        figureBackArraysBase[i][j].Z
                    );
                }
            }

            // Также обновите координаты соединений по оси Z
            UpdateZAxisConnectionsFront();
            UpdateZAxisConnectionsBack();
        }

    }
}
