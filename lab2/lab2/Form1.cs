using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2
{
    public partial class Form1 : Form
    {
        private Graphics g;

        public Form1()
        {
            InitializeComponent();
            g = this.CreateGraphics();

            // Преобразование системы отсчета
            g.TranslateTransform(this.Width / 2, this.Height / 2);
            g.ScaleTransform(1.0F, -1.0F);
        }

        private void buttonDraw_Click(object sender, EventArgs e)
        {
            Cripper.Draw(g, new Pen(Color.Black, 2), Cripper.coordinateMatrixFront, Cripper.coordinateMatrixBack);
        }

        private void buttonRotateX_Click(object sender, EventArgs e)
        {
            int rotateX = (int)numericUpDownRotateX.Value;
            g.Clear(Color.White);
            Cripper.Rotate(g, rotateX, 'X');
        }

        private void buttonRotateY_Click(object sender, EventArgs e)
        {
            int rotateY=(int)numericUpDownRotateY.Value;
            g.Clear(Color.White);
            Cripper.Rotate(g, rotateY, 'Y');
        }

        private void buttonRotateZ_Click(object sender, EventArgs e)
        {
            int rotateZ= (int)numericUpDownRotateZ.Value;
            g.Clear(Color.White);
            Cripper.Rotate(g, rotateZ, 'Z');
        }

        private void buttonScale_Click(object sender, EventArgs e)
        {
            double scaleX=(double)numericUpDownScaleX.Value;
            double scaleY=(double)numericUpDownScaleY.Value;
            double scaleZ=(double)numericUpDownScaleZ.Value;
            g.Clear(Color.White);
            Cripper.Scale(g, scaleX, scaleY, scaleZ);

        }

        private void buttonTransfer_Click(object sender, EventArgs e)
        {
            int transferX=(int)numericUpDownTransferX.Value;
            int transferY=(int)numericUpDownTransferY.Value;
            int transferZ=(int)numericUpDownTransferZ.Value;
            g.Clear(Color.White);
            Cripper.Move(g, transferX, transferY, transferZ);
        }

        private void buttonIsometricProection_Click(object sender, EventArgs e)
        {
           Cripper.DrawIzometric(g);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
        }

        private void buttonReturnBasic_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            Cripper.Reset();

            Cripper.Draw(g, new Pen(Color.Black, 2), Cripper.coordinateMatrixFront, Cripper.coordinateMatrixBack);
        }
    }
}
