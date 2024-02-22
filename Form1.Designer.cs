namespace lab1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            button1 = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            cbxColor = new ComboBox();
            cbxSysEl = new ComboBox();
            button6 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 39);
            label1.Name = "label1";
            label1.Size = new Size(112, 15);
            label1.TabIndex = 0;
            label1.Text = "Имя пользователя:";
            // 
            // button1
            // 
            button1.Location = new Point(338, 387);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(44, 68);
            label2.Name = "label2";
            label2.Size = new Size(106, 15);
            label2.TabIndex = 2;
            label2.Text = "Имя компьютера:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(44, 102);
            label3.Name = "label3";
            label3.Size = new Size(225, 15);
            label3.TabIndex = 3;
            label3.Text = "Пути к системным каталогам Windows:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(44, 136);
            label4.Name = "label4";
            label4.Size = new Size(185, 15);
            label4.TabIndex = 4;
            label4.Text = "Версия операционной системы:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(44, 175);
            label5.Name = "label5";
            label5.Size = new Size(126, 15);
            label5.TabIndex = 5;
            label5.Text = "Системные метрики: ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(305, 175);
            label6.Name = "label6";
            label6.Size = new Size(135, 15);
            label6.TabIndex = 6;
            label6.Text = "Системные параметры";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(494, 39);
            label8.Name = "label8";
            label8.Size = new Size(82, 15);
            label8.TabIndex = 8;
            label8.Text = "GetLocalTime:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(494, 68);
            label9.Name = "label9";
            label9.Size = new Size(144, 15);
            label9.TabIndex = 9;
            label9.Text = "GetTimeZonelnformation:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(44, 312);
            label10.Name = "label10";
            label10.Size = new Size(92, 15);
            label10.TabIndex = 10;
            label10.Text = "GetTimeFormat:";
            // 
            // button2
            // 
            button2.Location = new Point(473, 383);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 11;
            button2.Text = "ShowCursorButton";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(554, 383);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 12;
            button3.Text = "GetKeyboardLayoutList";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(635, 383);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 13;
            button4.Text = "GetTickCount";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(716, 383);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 14;
            button5.Text = "MessageBeep";
            button5.UseVisualStyleBackColor = true;
            // 
            // cbxColor
            // 
            cbxColor.FormattingEnabled = true;
            cbxColor.Location = new Point(508, 261);
            cbxColor.Name = "cbxColor";
            cbxColor.Size = new Size(121, 23);
            cbxColor.TabIndex = 15;
            // 
            // cbxSysEl
            // 
            cbxSysEl.FormattingEnabled = true;
            cbxSysEl.Location = new Point(635, 261);
            cbxSysEl.Name = "cbxSysEl";
            cbxSysEl.Size = new Size(121, 23);
            cbxSysEl.TabIndex = 16;
            // 
            // button6
            // 
            button6.Location = new Point(598, 312);
            button6.Name = "button6";
            button6.Size = new Size(75, 23);
            button6.TabIndex = 17;
            button6.Text = "Set";
            button6.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button6);
            Controls.Add(cbxSysEl);
            Controls.Add(cbxColor);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += addColornsInCB;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label8;
        private Label label9;
        private Label label10;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private ComboBox cbxColor;
        private ComboBox cbxSysEl;
        private Button button6;
    }
}
