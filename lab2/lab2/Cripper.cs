using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace lab2
{
    public struct Point3D
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Point3D(int x, int y, int z)
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
                new Point3D(-40, -75, 0),
                new Point3D(-40, 75, 0),
                new Point3D(40, 75, 0),
                new Point3D(40, -75, 0)
                        };

            headFront = new Point3D[]
            {
                new Point3D(-50, 75, 0),
                new Point3D(50, 75, 0),
                new Point3D(50, 175, 0),
                new Point3D(-50, 175, 0)
            };

            leftLegsFront = new Point3D[]
            {
                new Point3D(0, -75, 0),
                new Point3D(0, -115, 0),
                new Point3D(-50, -115, 0),
                new Point3D(-50, -75, 0)
            };

            rightLegsFront = new Point3D[]
            {
                new Point3D(0, -75, 0),
                new Point3D(0, -115, 0),
                new Point3D(50, -115, 0),
                new Point3D(50, -75, 0)
            };

            mouth = new Point3D[]
            {
                new Point3D(-40, 95, 0),
                new Point3D(40, 95, 0),
                new Point3D(40, 115, 0),
                new Point3D(-40, 115, 0)
            };

            rightEye = new Point3D[]
            {
                new Point3D(30, 155, 0),
                new Point3D(30, 135, 0),
                new Point3D(10, 135, 0),
                new Point3D(10, 155, 0),
            };

            leftEye = new Point3D[]
            {
                new Point3D(-10, 155, 0),
                new Point3D(-10, 135, 0),
                new Point3D(-30, 135, 0),
                new Point3D(-30, 155, 0),
            };

            headBack = new Point3D[]
            {
                new Point3D(-50, 75, 80),
                new Point3D(50, 75, 80),
                new Point3D(50, 175, 80),
                new Point3D(-50, 175, 80)
            };

            bodyBack = new Point3D[]
            {
                new Point3D(-40, -75, 80),
                new Point3D(-40, 75, 80),
                new Point3D(40, 75, 80),
                new Point3D(40, -75, 80)
            };

            leftLegsBack = new Point3D[]
            {
               new Point3D(0, -75, 80),
                new Point3D(0, -115, 80),
                new Point3D(-50, -115, 80),
                new Point3D(-50, -75, 80)
            };

            rightLegsBack = new Point3D[]
            {
                new Point3D(0, -75, 80),
                new Point3D(0, -115, 80),
                new Point3D(50, -115, 80),
                new Point3D(50, -75, 80)
            };


        }

        public void Draw()
        {
            ClearCanvas();

            Pen blackPen = new Pen(Color.Black);
            SolidBrush greenFill = new SolidBrush(Color.Green);
            SolidBrush blackFill = new SolidBrush(Color.Black);

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
                    points2D[i] = new PointF(polygon[i].X, polygon[i].Y);
                }
                g.DrawPolygon(drawPen, points2D);
            }
        }

        private void DrawZAxisConnections(Graphics g, Pen drawPen)
        {
            for (int i = 0; i < zAxisConnectionsFront.Length; i++)
            {
                g.DrawLine(drawPen, zAxisConnectionsFront[i].X, zAxisConnectionsFront[i].Y, zAxisConnectionsBack[i].X, zAxisConnectionsBack[i].Y);
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

        public void ApplyRotationToFigure(int angleInDegrees, char axis)
        {
            float radians = angleInDegrees * (float)Math.PI / 180;

            for (int i = 0; i < figureFrontArrays.Length; i++)
            {
                for (int j = 0; j < figureFrontArrays[i].Length; j++)
                {
                    float x = figureFrontArraysBase[i][j].X;
                    float y = figureFrontArraysBase[i][j].Y;
                    float z = figureFrontArraysBase[i][j].Z;

                    float newX = 0, newY = 0, newZ = 0;

                    if (axis == 'X')
                    {
                        newY = y * (float)Math.Cos(radians) - z * (float)Math.Sin(radians);
                        newZ = y * (float)Math.Sin(radians) + z * (float)Math.Cos(radians);
                        newX = x;
                    }
                    else if (axis == 'Y')
                    {
                        newX = x * (float)Math.Cos(radians) + z * (float)Math.Sin(radians);
                        newZ = -x * (float)Math.Sin(radians) + z * (float)Math.Cos(radians);
                        newY = y;
                    }
                    else if (axis == 'Z')
                    {
                        newX = x * (float)Math.Cos(radians) - y * (float)Math.Sin(radians);
                        newY = x * (float)Math.Sin(radians) + y * (float)Math.Cos(radians);
                        newZ = z;
                    }

                    figureFrontArrays[i][j] = new Point3D((int)newX, (int)newY, (int)newZ);
                }
            }

            // Обновление координат соединений точек по оси Z для фронтальной стороны
            UpdateZAxisConnectionsFront();

            for (int i = 0; i < figureBackArrays.Length; i++)
            {
                for (int j = 0; j < figureBackArrays[i].Length; j++)
                {
                    float x = figureBackArraysBase[i][j].X;
                    float y = figureBackArraysBase[i][j].Y;
                    float z = figureBackArraysBase[i][j].Z;

                    float newX = 0, newY = 0, newZ = 0;

                    if (axis == 'X')
                    {
                        newY = y * (float)Math.Cos(radians) - z * (float)Math.Sin(radians);
                        newZ = y * (float)Math.Sin(radians) + z * (float)Math.Cos(radians);
                        newX = x;
                    }
                    else if (axis == 'Y')
                    {
                        newX = x * (float)Math.Cos(radians) + z * (float)Math.Sin(radians);
                        newZ = -x * (float)Math.Sin(radians) + z * (float)Math.Cos(radians);
                        newY = y;
                    }
                    else if (axis == 'Z')
                    {
                        newX = x * (float)Math.Cos(radians) - y * (float)Math.Sin(radians);
                        newY = x * (float)Math.Sin(radians) + y * (float)Math.Cos(radians);
                        newZ = z;
                    }

                    figureBackArrays[i][j] = new Point3D((int)newX, (int)newY, (int)newZ);
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


        public void Scale(double scaleX, double scaleY, double scaleZ)
        {
            for (int i = 0; i < figureFrontArrays.Length; i++)
            {
                ScaleFigure(figureFrontArrays[i], scaleX, scaleY, scaleZ);
            }

            // Обновление координат соединений точек по оси Z
            UpdateZAxisConnections();

            Draw();
        }

        private void ScaleFigure(Point3D[] figure, double scaleX, double scaleY, double scaleZ)
        {
            for (int i = 0; i < figure.Length; i++)
            {
                figure[i] = new Point3D(
                    (int)(figure[i].X * scaleX),
                    (int)(figure[i].Y * scaleY),
                    (int)(figure[i].Z * scaleZ)
                );
            }
        }

        public void Move(int deltaX, int deltaY, int deltaZ)
        {
            for (int i = 0; i < figureFrontArrays.Length; i++)
            {
                MoveFigure(figureFrontArrays[i], deltaX, deltaY, deltaZ);
            }

            // Обновление координат соединений точек по оси Z
            UpdateZAxisConnections();

            Draw();
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

       public void ApplyIsometricProjection()
        {
            ApplyIsometricProjectionToFigure(figureFrontArrays);
            ApplyIsometricProjectionToFigure(figureBackArrays);

            // Обновление координат соединений точек по оси Z
            UpdateZAxisConnections();
    
            Draw();
        }

        private void ApplyIsometricProjectionToFigure(Point3D[][] figure)
        {
            // Коэффициенты для изометрической проекции
            double isometricX = 0.707;
            double isometricY = 0.707;

            for (int i = 0; i < figure.Length; i++)
            {
                for (int j = 0; j < figure[i].Length; j++)
                {
                    double x = figure[i][j].X;
                    double y = figure[i][j].Y;
                    double z = figure[i][j].Z;

                    // Применение изометрической проекции
                    double newX = x * isometricX - y * isometricX;
                    double newY = x * isometricY + y * isometricY - z;

                    figure[i][j] = new Point3D((int)newX, (int)newY, (int)z);
                }
            }
        }

        public void ResetToBaseCoordinates()
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

            Draw();
        }
 
    }
}
