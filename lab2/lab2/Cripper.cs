using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private int headWidth = 100;
        private int headHeight = 100;
        private int headDepth = 70;

        private int legWidth = 50;
        private int legHeight = 40;
        private int legDepth = 70;

        private int bodyWidth = 80;
        private int bodyHeight = 150;
        private int bodyDepth = 70;

        private int eyeWidth = 20;
        private int eyeHeight = 20;
        private int eyeDepth = 5;

        private int mouthWidth = 80;
        private int mouthHeight = 20;
        private int mouthDepth = 5;

        private Bitmap bmp;
        private PictureBox pictureBox;

        private int xCenter => pictureBox.Width / 2;
        private int yCenter => pictureBox.Height / 2;

        private Point3D[] body;
        private Point3D[] head;
        private Point3D[] leftLegs;
        private Point3D[] rightLegs;
        private Point3D[] mouth;
        private Point3D[] rightEye;
        private Point3D[] leftEye;

        private Point3D[][] figureArrays;

        private Matrix worldMatrix = new Matrix(); // Матрица для преобразований в мировых координатах
        private Matrix rotationMatrixX = new Matrix(); // Матрица для поворота вокруг оси X
        private Matrix rotationMatrixY = new Matrix(); // Матрица для поворота вокруг оси Y
        private Matrix rotationMatrixZ = new Matrix(); // Матрица для поворота вокруг оси Z

        public Cripper(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
            bmp = new Bitmap(pictureBox.ClientSize.Width, pictureBox.ClientSize.Height);

            InitializeCoordinates();

            figureArrays = new Point3D[][]
            {
                body, head, leftLegs, rightLegs, mouth, rightEye, leftEye
            };

        }

        private void InitializeCoordinates()
        {
            body = new Point3D[]
            {
                new Point3D(-bodyWidth/2, -bodyHeight/2, -bodyDepth),
                new Point3D(-bodyWidth/2, bodyHeight/2, -bodyDepth),
                new Point3D(bodyWidth/2, bodyHeight/2, -bodyDepth),
                new Point3D(bodyWidth/2, -bodyHeight/2, -bodyDepth)
            };

            head = new Point3D[]
            {
                new Point3D(-headWidth/2, bodyHeight/2, -headDepth),
                new Point3D(headWidth/2, bodyHeight/2, -headDepth),
                new Point3D(headWidth/2, bodyHeight/2 + headHeight, -headDepth),
                new Point3D(-headWidth/2, bodyHeight/2 + headHeight, -headDepth)
            };

            leftLegs = new Point3D[]
            {
                new Point3D(0, -bodyHeight/2, -legDepth),
                new Point3D(0, -bodyHeight/2 - legHeight, -legDepth),
                new Point3D(-legWidth, -bodyHeight/2 - legHeight, -legDepth),
                new Point3D(-legWidth, -bodyHeight/2, -legDepth)
            };

            rightLegs = new Point3D[]
            {
                new Point3D(0, -bodyHeight/2, -legDepth),
                new Point3D(0, -bodyHeight/2 - legHeight, -legDepth),
                new Point3D(legWidth, -bodyHeight/2 - legHeight, -legDepth),
                new Point3D(legWidth, -bodyHeight/2, -legDepth)
            };

            mouth = new Point3D[]
            {
                new Point3D(-mouthWidth/2, bodyHeight/2 + eyeHeight, mouthDepth),
                new Point3D(mouthWidth/2, bodyHeight/2 + eyeHeight, mouthDepth),
                new Point3D(mouthWidth/2, bodyHeight/2 + eyeHeight + mouthHeight, mouthDepth),
                new Point3D(-mouthWidth/2, bodyHeight/2 + eyeHeight + mouthHeight, mouthDepth)
            };

            rightEye = new Point3D[]
            {
                new Point3D(headWidth/2 - eyeWidth, bodyHeight/2 + headHeight - eyeHeight, eyeDepth),
                new Point3D(headWidth/2 - eyeWidth, bodyHeight/2 + headHeight - 2*eyeHeight, eyeDepth),
                new Point3D(headWidth/2 - 2*eyeWidth, bodyHeight/2 + headHeight - 2*eyeHeight, eyeDepth),
                new Point3D(headWidth/2 - 2*eyeWidth, bodyHeight/2 + headHeight - eyeHeight, eyeDepth),
            };

            leftEye = new Point3D[]
            {
                new Point3D(-headWidth/2 + 2*eyeWidth, bodyHeight/2 + headHeight - eyeHeight, eyeDepth),
                new Point3D(-headWidth/2 + 2*eyeWidth, bodyHeight/2 + headHeight - 2*eyeHeight, eyeDepth),
                new Point3D(-headWidth/2 + eyeWidth, bodyHeight/2 + headHeight - 2*eyeHeight, eyeDepth),
                new Point3D(-headWidth/2 + eyeWidth, bodyHeight/2 + headHeight - eyeHeight, eyeDepth),
            };


            worldMatrix = new Matrix();
            rotationMatrixX = new Matrix();
            rotationMatrixY = new Matrix();
            rotationMatrixZ = new Matrix();


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

                // Пересчитываем центр координат
                int centerX = pictureBox.Width / 2;
                int centerY = pictureBox.Height / 2;

                // Применяем текущие матрицы преобразований
                Matrix transformationMatrix = new Matrix();
                transformationMatrix.Translate(centerX, centerY); // Сдвигаем фигуры в центр
                transformationMatrix.Scale(1, -1); // Инвертируем ось Y
                transformationMatrix.Multiply(worldMatrix);
                transformationMatrix.Multiply(rotationMatrixX);
                transformationMatrix.Multiply(rotationMatrixY);
                transformationMatrix.Multiply(rotationMatrixZ);

                g.Transform = transformationMatrix;

                // Отрисовываем линии по оси Z перед полигонами
                DrawAndFillLinesZ(g, blackPen, body, head, leftLegs, rightLegs, mouth, rightEye, leftEye);

                // Отрисовываем и заливаем полигоны
                DrawAndFillPolygons(g, greenFill, blackPen, body, head, leftLegs, rightLegs);
                DrawAndFillPolygons(g, blackFill, blackPen, mouth, rightEye, leftEye);
            }

            pictureBox.Image = bmp;
        }



        public void ClearCanvas()
        {
            pictureBox.Image = null;
            bmp = new Bitmap(pictureBox.ClientSize.Width, pictureBox.ClientSize.Height);
        }

        private void DrawAndFillPolygons(Graphics g, Brush fillBrush, Pen drawPen, params Point3D[][] polygons)
        {
            foreach (var polygon in polygons)
            {
                var points2D = new PointF[polygon.Length];
                for (int i = 0; i < polygon.Length; i++)
                {
                    points2D[i] = new PointF(polygon[i].X, polygon[i].Y);
                }
                g.FillPolygon(fillBrush, points2D);
                g.DrawPolygon(drawPen, points2D);
            }
        }

        public void RotateX(int angleInDegrees)
        {
            ApplyRotationToFigure(angleInDegrees, 'X');
        }

        public void RotateY(int angleInDegrees)
        {
            ApplyRotationToFigure(angleInDegrees, 'Y');
        }

        public void RotateZ(int angleInDegrees)
        {
            ApplyRotationToFigure(angleInDegrees, 'Z');
        }

        private void ApplyRotationToFigure(int angleInDegrees, char axis)
        {
            Point3D[] originalBody = (Point3D[])body.Clone();
            Point3D[] originalHead = (Point3D[])head.Clone();
            Point3D[] originalLeftLegs = (Point3D[])leftLegs.Clone();
            Point3D[] originalRightLegs = (Point3D[])rightLegs.Clone();
            Point3D[] originalMouth = (Point3D[])mouth.Clone();
            Point3D[] originalRightEye = (Point3D[])rightEye.Clone();
            Point3D[] originalLeftEye = (Point3D[])leftEye.Clone();

            for (int i = 0; i < figureArrays.Length; i++)
            {
                ApplyRotationToFigure(figureArrays[i], angleInDegrees, axis);
            }

            // Перерисовываем объект
            Draw();

            body = originalBody;
            head = originalHead;
            leftEye = originalLeftEye;
            rightEye = originalRightEye;
            mouth = originalMouth;
            leftLegs = originalLeftLegs;
            rightLegs = originalRightLegs;

            figureArrays = new Point3D[][]
            {
                body, head, leftLegs, rightLegs, mouth, rightEye, leftEye
            };
        }


        private void ApplyRotationToFigure(Point3D[] figure, int angleInDegrees, char axis)
        {
            float radians = angleInDegrees * (float)Math.PI / 180;

            // Переводим угол в радианы

            for (int i = 0; i < figure.Length; i++)
            {
                // Вычитаем координаты центра
                float x = figure[i].X;
                float y = figure[i].Y;
                float z = figure[i].Z;

                if (axis == 'X')
                {
                    // Поворачиваем относительно оси X
                    float newY = (float)(y * Math.Cos(radians) - z * Math.Sin(radians));
                    float newZ = (float)(y * Math.Sin(radians) + z * Math.Cos(radians));
                    figure[i] = new Point3D((int)x, (int)newY, (int)newZ);
                }
                else if (axis == 'Y')
                {
                    // Поворачиваем относительно оси Y
                    float newX = (float)(x * Math.Cos(radians) + z * Math.Sin(radians));
                    float newZ = (float)(-x * Math.Sin(radians) + z * Math.Cos(radians));
                    figure[i] = new Point3D((int)newX, (int)y, (int)newZ);
                }
                else if (axis == 'Z')
                {
                    // Поворачиваем относительно оси Z
                    float newX = (float)(x * Math.Cos(radians) - y * Math.Sin(radians));
                    float newY = (float)(x * Math.Sin(radians) + y * Math.Cos(radians));
                    figure[i] = new Point3D((int)newX, (int)newY, (int)z);
                }
            }
        }

        public void Scale(double scaleX, double scaleY, double scaleZ)
        {
            for (int i = 0; i < figureArrays.Length; i++)
            {
                ScaleFigure(figureArrays[i], scaleX, scaleY, scaleZ);
            }

            // Перерисовываем объект
            Draw();
        }

        private void ScaleFigure(Point3D[] figure, double scaleX, double scaleY, double scaleZ)
        {
            for (int i = 0; i < figure.Length; i++)
            {
                // Масштабируем координаты фигуры
                figure[i] = new Point3D(
                    (int)(figure[i].X * scaleX),
                    (int)(figure[i].Y * scaleY),
                    (int)(figure[i].Z * scaleZ)
                );
            }
        }

        public void Move(int deltaX, int deltaY, int deltaZ)
        {
            for (int i = 0; i < figureArrays.Length; i++)
            {
                MoveFigure(figureArrays[i], deltaX, deltaY, deltaZ);
            }

            // Перерисовываем объект
            Draw();
        }

        private void MoveFigure(Point3D[] figure, int deltaX, int deltaY, int deltaZ)
        {
            for (int i = 0; i < figure.Length; i++)
            {
                // Смещаем координаты фигуры
                figure[i] = new Point3D(
                    figure[i].X + deltaX,
                    figure[i].Y + deltaY,
                    figure[i].Z + deltaZ
                );
            }
        }

        private void DrawAndFillLinesZ(Graphics g, Pen drawPen, params Point3D[][] polygons)
        {
            foreach (var polygon in polygons)
            {
                for (int i = 0; i < polygon.Length; i++)
                {
                    int nextIndex = (i + 1) % polygon.Length;
                    Point3D point1 = polygon[i];
                    Point3D point2 = polygon[nextIndex];

                    // Проверяем, что линия находится на одной глубине Z
                    if (point1.Z == point2.Z)
                    {
                        g.DrawLine(drawPen, point1.X, point1.Y, point2.X, point2.Y);
                    }
                }
            }
        }



    }
}