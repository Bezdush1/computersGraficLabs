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
        private Cripper cripper;
        Bitmap bmp;

        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
            cripper = new Cripper(pictureBox1); // Создание экземпляра Cripper
        }

        private void buttonDraw_Click(object sender, EventArgs e)
        {
            cripper.Draw();
        }

        private void buttonRotateX_Click(object sender, EventArgs e)
        {
            int rotateX = (int)numericUpDownRotateX.Value;
            cripper.RotateX(rotateX);
        }

        private void buttonRotateY_Click(object sender, EventArgs e)
        {
            int rotateY=(int)numericUpDownRotateY.Value;
            cripper.RotateY(rotateY);
        }

        private void buttonRotateZ_Click(object sender, EventArgs e)
        {
            int rotateZ= (int)numericUpDownRotateZ.Value;
           cripper.RotateZ(rotateZ);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            cripper.ResetToBaseCoordinates();
        }

        private void buttonScale_Click(object sender, EventArgs e)
        {
            double scaleX=(double)numericUpDownScaleX.Value;
            double scaleY=(double)numericUpDownScaleY.Value;
            double scaleZ=(double)numericUpDownScaleZ.Value;

            cripper.Scale(scaleX, scaleY, scaleZ);
        }

        private void buttonTransfer_Click(object sender, EventArgs e)
        {
            int transferX=(int)numericUpDownTransferX.Value;
            int transferY=(int)numericUpDownTransferY.Value;
            int transferZ=(int)numericUpDownTransferZ.Value;

            cripper.Move(transferX, transferY, transferZ);
        }

        private void buttonIsometricProection_Click(object sender, EventArgs e)
        {
            cripper.ApplyIsometricProjection();
        }
    }
}
