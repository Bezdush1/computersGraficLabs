using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            cripper.Draw(); 
        }

        private void buttonDeleteImage_Click(object sender, EventArgs e)
        {
            cripper.Clear(); 
        }

        private void buttonTurnImage_Click(object sender, EventArgs e)
        {
            int rotate = (int)numericUpDownRotate.Value;
            cripper.Rotate(rotate);
        }

        private void buttonScaling_Click(object sender, EventArgs e)
        {
            float scale = (float)numericUpDownScaling.Value;
            cripper.Scale(scale);
        }

        private void buttonMove_Click(object sender, EventArgs e)
        {
            int newX = (int)numericUpDownTransferX.Value;
            int newY = (int)numericUpDownTransferY.Value;
            cripper.Transfer(newX,newY);
        }
    }
}
