namespace lab2
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
            this.buttonDraw = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonRotateX = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownRotateX = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownRotateY = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonRotateY = new System.Windows.Forms.Button();
            this.numericUpDownRotateZ = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonRotateZ = new System.Windows.Forms.Button();
            this.numericUpDownScaleX = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.numericUpDownScaleY = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownScaleZ = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.buttonScale = new System.Windows.Forms.Button();
            this.buttonTransfer = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.numericUpDownTransferZ = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownTransferY = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.numericUpDownTransferX = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRotateX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRotateY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRotateZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScaleX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScaleY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScaleZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTransferZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTransferY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTransferX)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonDraw
            // 
            this.buttonDraw.Location = new System.Drawing.Point(835, 15);
            this.buttonDraw.Name = "buttonDraw";
            this.buttonDraw.Size = new System.Drawing.Size(135, 44);
            this.buttonDraw.TabIndex = 0;
            this.buttonDraw.Text = "Отрисовка фигуры";
            this.buttonDraw.UseVisualStyleBackColor = true;
            this.buttonDraw.Click += new System.EventHandler(this.buttonDraw_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(835, 65);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(135, 44);
            this.buttonClear.TabIndex = 1;
            this.buttonClear.Text = "Стирание фигуры";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(771, 536);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // buttonRotateX
            // 
            this.buttonRotateX.Location = new System.Drawing.Point(835, 179);
            this.buttonRotateX.Name = "buttonRotateX";
            this.buttonRotateX.Size = new System.Drawing.Size(135, 44);
            this.buttonRotateX.TabIndex = 3;
            this.buttonRotateX.Text = "Повернуть";
            this.buttonRotateX.UseVisualStyleBackColor = true;
            this.buttonRotateX.Click += new System.EventHandler(this.buttonRotateX_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(788, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Поворот относительно оси x";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(788, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Повернуть на";
            // 
            // numericUpDownRotateX
            // 
            this.numericUpDownRotateX.Location = new System.Drawing.Point(932, 151);
            this.numericUpDownRotateX.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDownRotateX.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.numericUpDownRotateX.Name = "numericUpDownRotateX";
            this.numericUpDownRotateX.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownRotateX.TabIndex = 6;
            this.numericUpDownRotateX.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // numericUpDownRotateY
            // 
            this.numericUpDownRotateY.Location = new System.Drawing.Point(932, 272);
            this.numericUpDownRotateY.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDownRotateY.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.numericUpDownRotateY.Name = "numericUpDownRotateY";
            this.numericUpDownRotateY.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownRotateY.TabIndex = 10;
            this.numericUpDownRotateY.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(788, 272);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Повернуть на";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(788, 247);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(195, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Поворот относительно оси y";
            // 
            // buttonRotateY
            // 
            this.buttonRotateY.Location = new System.Drawing.Point(835, 298);
            this.buttonRotateY.Name = "buttonRotateY";
            this.buttonRotateY.Size = new System.Drawing.Size(135, 44);
            this.buttonRotateY.TabIndex = 7;
            this.buttonRotateY.Text = "Повернуть";
            this.buttonRotateY.UseVisualStyleBackColor = true;
            this.buttonRotateY.Click += new System.EventHandler(this.buttonRotateY_Click);
            // 
            // numericUpDownRotateZ
            // 
            this.numericUpDownRotateZ.Location = new System.Drawing.Point(932, 379);
            this.numericUpDownRotateZ.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDownRotateZ.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.numericUpDownRotateZ.Name = "numericUpDownRotateZ";
            this.numericUpDownRotateZ.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownRotateZ.TabIndex = 14;
            this.numericUpDownRotateZ.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(788, 385);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Повернуть на";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(788, 360);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(194, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Поворот относительно оси z";
            // 
            // buttonRotateZ
            // 
            this.buttonRotateZ.Location = new System.Drawing.Point(835, 411);
            this.buttonRotateZ.Name = "buttonRotateZ";
            this.buttonRotateZ.Size = new System.Drawing.Size(135, 44);
            this.buttonRotateZ.TabIndex = 11;
            this.buttonRotateZ.Text = "Повернуть";
            this.buttonRotateZ.UseVisualStyleBackColor = true;
            this.buttonRotateZ.Click += new System.EventHandler(this.buttonRotateZ_Click);
            // 
            // numericUpDownScaleX
            // 
            this.numericUpDownScaleX.DecimalPlaces = 2;
            this.numericUpDownScaleX.Location = new System.Drawing.Point(1256, 73);
            this.numericUpDownScaleX.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownScaleX.Name = "numericUpDownScaleX";
            this.numericUpDownScaleX.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownScaleX.TabIndex = 18;
            this.numericUpDownScaleX.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1112, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "Масштабировать на";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1112, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(183, 16);
            this.label8.TabIndex = 16;
            this.label8.Text = "Масштабирование по оси x";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1111, 140);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(138, 16);
            this.label9.TabIndex = 21;
            this.label9.Text = "Масштабировать на";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1111, 115);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(184, 16);
            this.label10.TabIndex = 20;
            this.label10.Text = "Масштабирование по оси y";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1111, 209);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(138, 16);
            this.label11.TabIndex = 24;
            this.label11.Text = "Масштабировать на";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1111, 184);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(183, 16);
            this.label12.TabIndex = 23;
            this.label12.Text = "Масштабирование по оси z";
            // 
            // numericUpDownScaleY
            // 
            this.numericUpDownScaleY.DecimalPlaces = 2;
            this.numericUpDownScaleY.Location = new System.Drawing.Point(1255, 138);
            this.numericUpDownScaleY.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownScaleY.Name = "numericUpDownScaleY";
            this.numericUpDownScaleY.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownScaleY.TabIndex = 25;
            this.numericUpDownScaleY.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // numericUpDownScaleZ
            // 
            this.numericUpDownScaleZ.DecimalPlaces = 2;
            this.numericUpDownScaleZ.Location = new System.Drawing.Point(1255, 209);
            this.numericUpDownScaleZ.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownScaleZ.Name = "numericUpDownScaleZ";
            this.numericUpDownScaleZ.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownScaleZ.TabIndex = 26;
            this.numericUpDownScaleZ.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1163, 15);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(132, 16);
            this.label13.TabIndex = 27;
            this.label13.Text = "Масштабирование ";
            // 
            // buttonScale
            // 
            this.buttonScale.Location = new System.Drawing.Point(1166, 237);
            this.buttonScale.Name = "buttonScale";
            this.buttonScale.Size = new System.Drawing.Size(135, 44);
            this.buttonScale.TabIndex = 28;
            this.buttonScale.Text = "Масштабировать";
            this.buttonScale.UseVisualStyleBackColor = true;
            this.buttonScale.Click += new System.EventHandler(this.buttonScale_Click);
            // 
            // buttonTransfer
            // 
            this.buttonTransfer.Location = new System.Drawing.Point(1166, 520);
            this.buttonTransfer.Name = "buttonTransfer";
            this.buttonTransfer.Size = new System.Drawing.Size(135, 44);
            this.buttonTransfer.TabIndex = 39;
            this.buttonTransfer.Text = "Переместить";
            this.buttonTransfer.UseVisualStyleBackColor = true;
            this.buttonTransfer.Click += new System.EventHandler(this.buttonTransfer_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(1195, 312);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(99, 16);
            this.label14.TabIndex = 38;
            this.label14.Text = "Перемещение";
            // 
            // numericUpDownTransferZ
            // 
            this.numericUpDownTransferZ.Location = new System.Drawing.Point(1255, 492);
            this.numericUpDownTransferZ.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownTransferZ.Name = "numericUpDownTransferZ";
            this.numericUpDownTransferZ.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownTransferZ.TabIndex = 37;
            // 
            // numericUpDownTransferY
            // 
            this.numericUpDownTransferY.Location = new System.Drawing.Point(1255, 421);
            this.numericUpDownTransferY.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownTransferY.Name = "numericUpDownTransferY";
            this.numericUpDownTransferY.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownTransferY.TabIndex = 36;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(1111, 492);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(113, 16);
            this.label15.TabIndex = 35;
            this.label15.Text = "Переместить на";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(1111, 467);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(148, 16);
            this.label16.TabIndex = 34;
            this.label16.Text = "Переместить по оси z";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(1111, 423);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(113, 16);
            this.label17.TabIndex = 33;
            this.label17.Text = "Переместить на";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(1111, 398);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(149, 16);
            this.label18.TabIndex = 32;
            this.label18.Text = "Переместить по оси y";
            // 
            // numericUpDownTransferX
            // 
            this.numericUpDownTransferX.Location = new System.Drawing.Point(1256, 356);
            this.numericUpDownTransferX.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownTransferX.Name = "numericUpDownTransferX";
            this.numericUpDownTransferX.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownTransferX.TabIndex = 31;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(1112, 358);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(113, 16);
            this.label19.TabIndex = 30;
            this.label19.Text = "Переместить на";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(1112, 333);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(148, 16);
            this.label20.TabIndex = 29;
            this.label20.Text = "Переместить по оси x";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1405, 576);
            this.Controls.Add(this.buttonTransfer);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.numericUpDownTransferZ);
            this.Controls.Add(this.numericUpDownTransferY);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.numericUpDownTransferX);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.buttonScale);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.numericUpDownScaleZ);
            this.Controls.Add(this.numericUpDownScaleY);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.numericUpDownScaleX);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.numericUpDownRotateZ);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonRotateZ);
            this.Controls.Add(this.numericUpDownRotateY);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonRotateY);
            this.Controls.Add(this.numericUpDownRotateX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonRotateX);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonDraw);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRotateX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRotateY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRotateZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScaleX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScaleY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScaleZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTransferZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTransferY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTransferX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDraw;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonRotateX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownRotateX;
        private System.Windows.Forms.NumericUpDown numericUpDownRotateY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonRotateY;
        private System.Windows.Forms.NumericUpDown numericUpDownRotateZ;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonRotateZ;
        private System.Windows.Forms.NumericUpDown numericUpDownScaleX;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numericUpDownScaleY;
        private System.Windows.Forms.NumericUpDown numericUpDownScaleZ;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button buttonScale;
        private System.Windows.Forms.Button buttonTransfer;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown numericUpDownTransferZ;
        private System.Windows.Forms.NumericUpDown numericUpDownTransferY;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown numericUpDownTransferX;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
    }
}

