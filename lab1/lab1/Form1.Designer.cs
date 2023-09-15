namespace lab1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonPrint = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonDeleteImage = new System.Windows.Forms.Button();
            this.buttonTurnImage = new System.Windows.Forms.Button();
            this.buttonScaling = new System.Windows.Forms.Button();
            this.buttonMove = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownScaling = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownTransferX = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownTransferY = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownRotate = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScaling)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTransferX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTransferY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRotate)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPrint
            // 
            this.buttonPrint.Location = new System.Drawing.Point(808, 34);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(146, 47);
            this.buttonPrint.TabIndex = 0;
            this.buttonPrint.Text = "Отрисовка фигуры";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(27, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(754, 574);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // buttonDeleteImage
            // 
            this.buttonDeleteImage.Location = new System.Drawing.Point(808, 87);
            this.buttonDeleteImage.Name = "buttonDeleteImage";
            this.buttonDeleteImage.Size = new System.Drawing.Size(146, 47);
            this.buttonDeleteImage.TabIndex = 2;
            this.buttonDeleteImage.Text = "Удаление фигуры";
            this.buttonDeleteImage.UseVisualStyleBackColor = true;
            this.buttonDeleteImage.Click += new System.EventHandler(this.buttonDeleteImage_Click);
            // 
            // buttonTurnImage
            // 
            this.buttonTurnImage.Location = new System.Drawing.Point(808, 140);
            this.buttonTurnImage.Name = "buttonTurnImage";
            this.buttonTurnImage.Size = new System.Drawing.Size(146, 47);
            this.buttonTurnImage.TabIndex = 3;
            this.buttonTurnImage.Text = "Повернуть фигуру";
            this.buttonTurnImage.UseVisualStyleBackColor = true;
            this.buttonTurnImage.Click += new System.EventHandler(this.buttonTurnImage_Click);
            // 
            // buttonScaling
            // 
            this.buttonScaling.Location = new System.Drawing.Point(799, 282);
            this.buttonScaling.Name = "buttonScaling";
            this.buttonScaling.Size = new System.Drawing.Size(146, 47);
            this.buttonScaling.TabIndex = 4;
            this.buttonScaling.Text = "Масштабирование фигуры";
            this.buttonScaling.UseVisualStyleBackColor = true;
            this.buttonScaling.Click += new System.EventHandler(this.buttonScaling_Click);
            // 
            // buttonMove
            // 
            this.buttonMove.Location = new System.Drawing.Point(799, 407);
            this.buttonMove.Name = "buttonMove";
            this.buttonMove.Size = new System.Drawing.Size(146, 47);
            this.buttonMove.TabIndex = 5;
            this.buttonMove.Text = "Переместить фигуру";
            this.buttonMove.UseVisualStyleBackColor = true;
            this.buttonMove.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(778, 345);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Коэффициент увеличения";
            // 
            // numericUpDownScaling
            // 
            this.numericUpDownScaling.Location = new System.Drawing.Point(799, 364);
            this.numericUpDownScaling.Name = "numericUpDownScaling";
            this.numericUpDownScaling.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownScaling.TabIndex = 7;
            this.numericUpDownScaling.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // numericUpDownTransferX
            // 
            this.numericUpDownTransferX.Location = new System.Drawing.Point(799, 489);
            this.numericUpDownTransferX.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownTransferX.Name = "numericUpDownTransferX";
            this.numericUpDownTransferX.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownTransferX.TabIndex = 9;
            this.numericUpDownTransferX.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(796, 470);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Новая координата x";
            // 
            // numericUpDownTransferY
            // 
            this.numericUpDownTransferY.Location = new System.Drawing.Point(799, 547);
            this.numericUpDownTransferY.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownTransferY.Name = "numericUpDownTransferY";
            this.numericUpDownTransferY.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownTransferY.TabIndex = 11;
            this.numericUpDownTransferY.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(796, 528);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Новая координата y";
            // 
            // numericUpDownRotate
            // 
            this.numericUpDownRotate.Location = new System.Drawing.Point(808, 222);
            this.numericUpDownRotate.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDownRotate.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.numericUpDownRotate.Name = "numericUpDownRotate";
            this.numericUpDownRotate.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownRotate.TabIndex = 13;
            this.numericUpDownRotate.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(815, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Угол поворота";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 606);
            this.Controls.Add(this.numericUpDownRotate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDownTransferY);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDownTransferX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDownScaling);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonMove);
            this.Controls.Add(this.buttonScaling);
            this.Controls.Add(this.buttonTurnImage);
            this.Controls.Add(this.buttonDeleteImage);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonPrint);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScaling)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTransferX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTransferY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRotate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonDeleteImage;
        private System.Windows.Forms.Button buttonTurnImage;
        private System.Windows.Forms.Button buttonScaling;
        private System.Windows.Forms.Button buttonMove;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownScaling;
        private System.Windows.Forms.NumericUpDown numericUpDownTransferX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownTransferY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownRotate;
        private System.Windows.Forms.Label label4;
    }
}

