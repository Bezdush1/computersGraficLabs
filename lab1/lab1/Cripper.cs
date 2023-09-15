using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace lab1
{
    public class Cripper
    {
        private int headWidth = 100;
        private int headHeight = 100;
        private int legWidth = 50;
        private int legHeight = 40;
        private int bodyWidth = 80;
        private int bodyHeight = 150;
        private int eyeWidth = 20;
        private int eyeHeight = 20;
        private int mouthWidth = 80;
        private int mouthHeight = 20;

        private Bitmap bmp;
        private PictureBox pictureBox;

        private int xCenter => pictureBox.Width / 2;
        private int yCenter => pictureBox.Height / 2;

        private Point[] body;
        private Point[] head;
        private Point[] leftLegs;
        private Point[] rightLegs;
        private Point[] mouth;
        private Point[] rightEye;
        private Point[] leftEye;

        public Cripper(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
            bmp = new Bitmap(pictureBox.ClientSize.Width, pictureBox.ClientSize.Height);

            InitializeCoordinates();
        }

        private void InitializeCoordinates()
        {
            body = new Point[]
            {
                new Point (-bodyWidth/2,-bodyHeight/2),
                new Point (-bodyWidth/2,bodyHeight/2),
                new Point (bodyWidth/2,bodyHeight/2),
                new Point (bodyWidth/2,-bodyHeight/2)
            };

            head = new Point[]
            {
                new Point(-headWidth/2,bodyHeight/2),
                new Point(headWidth/2,bodyHeight/2),
                new Point(headWidth/2,bodyHeight/2+headHeight),
                new Point(-headWidth/2,bodyHeight/2+headHeight)
            };

            leftLegs = new Point[]
            {
                new Point(0,-bodyHeight/2),
                new Point(0,-bodyHeight/2-legHeight),
                new Point(-legWidth,-bodyHeight/2-legHeight),
                new Point(-legWidth,-bodyHeight/2)
            };

            rightLegs = new Point[]
            {
                new Point(0, -bodyHeight/2),
                new Point(0, -bodyHeight/2 - legHeight),
                new Point(legWidth, -bodyHeight/2 - legHeight),
                new Point(legWidth, -bodyHeight/2)
            };

            mouth = new Point[]
            {
                new Point(-mouthWidth/2, bodyHeight/2 + eyeHeight),
                new Point(mouthWidth/2, bodyHeight/2 + eyeHeight),
                new Point(mouthWidth/2, bodyHeight/2 + eyeHeight + mouthHeight),
                new Point(-mouthWidth/2, bodyHeight/2 + eyeHeight + mouthHeight)
            };

            rightEye = new Point[]
            {
                new Point (headWidth/2-eyeWidth, bodyHeight/2+headHeight-eyeHeight),
                new Point (headWidth/2-eyeWidth, bodyHeight/2+headHeight-2*eyeHeight),
                new Point (headWidth/2-2*eyeWidth, bodyHeight/2+headHeight-2*eyeHeight),
                new Point (headWidth/2-2*eyeWidth, bodyHeight/2+headHeight-eyeHeight),
            };

            leftEye = new Point[]
            {
                new Point(-headWidth/2 + 2*eyeWidth, bodyHeight/2 + headHeight - eyeHeight),
                new Point(-headWidth/2 + 2*eyeWidth, bodyHeight/2 + headHeight - 2*eyeHeight),
                new Point(-headWidth/2 + eyeWidth, bodyHeight/2 + headHeight - 2*eyeHeight),
                new Point(-headWidth/2 + eyeWidth, bodyHeight/2 + headHeight - eyeHeight),
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
                g.TranslateTransform(xCenter, yCenter);
                g.ScaleTransform(1, -1);

                DrawAndFillPolygons(g, greenFill, blackPen, body, head, leftLegs, rightLegs);
                DrawAndFillPolygons(g, blackFill, blackPen, mouth, rightEye, leftEye);
            }

            pictureBox.Image = bmp;
        }

        public void Clear()
        {
            pictureBox.Image = null;
            bmp = new Bitmap(pictureBox.ClientSize.Width, pictureBox.ClientSize.Height);
        }

        public void Rotate(float angleInDegrees)
        {
            ClearCanvas();

            // Преобразуйте угол в радианы
            float angleInRadians = angleInDegrees * (float)Math.PI / 180;

            // Матрица поворота
            Matrix rotationMatrix = new Matrix();
            rotationMatrix.Rotate(angleInDegrees);

            Pen blackPen = new Pen(Color.Black);
            SolidBrush greenFill = new SolidBrush(Color.Green);
            SolidBrush blackFill = new SolidBrush(Color.Black);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                g.TranslateTransform(xCenter, yCenter);
                g.ScaleTransform(1, -1);

                ApplyTransformation(rotationMatrix, body, head, leftLegs, rightLegs, mouth, rightEye, leftEye);

                DrawAndFillPolygons(g, greenFill, blackPen, body, head, leftLegs, rightLegs);
                DrawAndFillPolygons(g, blackFill, blackPen, mouth, rightEye, leftEye);
            }

            pictureBox.Image = bmp;
        }

        private void ClearCanvas()
        {
            pictureBox.Image = null;
            bmp = new Bitmap(pictureBox.ClientSize.Width, pictureBox.ClientSize.Height);
        }

        private void DrawAndFillPolygons(Graphics g, Brush fillBrush, Pen drawPen, params Point[][] polygons)
        {
            foreach (var polygon in polygons)
            {
                g.FillPolygon(fillBrush, polygon);
                g.DrawPolygon(drawPen, polygon);
            }
        }

        private void ApplyTransformation(Matrix matrix, params Point[][] polygons)
        {
            foreach (var polygon in polygons)
            {
                matrix.TransformPoints(polygon);     
            }
        }

        public void Scale(float scaleFactor)
        {
            ClearCanvas();

            // Матрица масштабирования
            Matrix scaleMatrix = new Matrix();
            scaleMatrix.Scale(scaleFactor, scaleFactor); 

            Pen blackPen = new Pen(Color.Black);
            SolidBrush greenFill = new SolidBrush(Color.Green);
            SolidBrush blackFill = new SolidBrush(Color.Black);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                g.TranslateTransform(xCenter, yCenter);
                g.ScaleTransform(1, -1);

                ApplyTransformation(scaleMatrix, body, head, leftLegs, rightLegs, mouth, rightEye, leftEye);

                DrawAndFillPolygons(g, greenFill, blackPen, body, head, leftLegs, rightLegs);
                DrawAndFillPolygons(g, blackFill, blackPen, mouth, rightEye, leftEye);
            }

            pictureBox.Image = bmp;
        }

        public void Transfer(int deltaX, int deltaY)
        {
            ClearCanvas();

            // Матрица переноса
            Matrix translationMatrix = new Matrix();
            translationMatrix.Translate(deltaX, deltaY);

            Pen blackPen = new Pen(Color.Black);
            SolidBrush greenFill = new SolidBrush(Color.Green);
            SolidBrush blackFill = new SolidBrush(Color.Black);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                g.TranslateTransform(xCenter, yCenter);
                g.ScaleTransform(1, -1);

                ApplyTransformation(translationMatrix, body, head, leftLegs, rightLegs, mouth, rightEye, leftEye);

                DrawAndFillPolygons(g, greenFill, blackPen, body, head, leftLegs, rightLegs);
                DrawAndFillPolygons(g, blackFill, blackPen, mouth, rightEye, leftEye);
            }

            pictureBox.Image = bmp;
        }
    }
}
