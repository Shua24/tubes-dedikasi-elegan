namespace StatForm
{
    partial class DokterUI2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBox1 = new ListBox();
            ScreenTitle = new Label();
            button2 = new Button();
            label2 = new Label();
            textBox1 = new TextBox();
            button4 = new Button();
            button3 = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.Font = new Font("Segoe UI", 16F);
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 30;
            listBox1.Location = new Point(154, 208);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(890, 274);
            listBox1.TabIndex = 1;
            // 
            // ScreenTitle
            // 
            ScreenTitle.AutoSize = true;
            ScreenTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ScreenTitle.Location = new Point(482, 27);
            ScreenTitle.Name = "ScreenTitle";
            ScreenTitle.Size = new Size(266, 25);
            ScreenTitle.TabIndex = 3;
            ScreenTitle.Text = "Tampilkan 3 Antibiotik terbaik!";
            // 
            // button2
            // 
            button2.Location = new Point(154, 164);
            button2.Name = "button2";
            button2.Size = new Size(191, 23);
            button2.TabIndex = 4;
            button2.Text = "Tampilkan 3 antibiotik terbaik...";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(154, 95);
            label2.Name = "label2";
            label2.Size = new Size(137, 15);
            label2.TabIndex = 5;
            label2.Text = "Bakteri yang ingin dicari:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(154, 113);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(299, 23);
            textBox1.TabIndex = 6;
            // 
            // button4
            // 
            button4.Location = new Point(12, 610);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 8;
            button4.Text = "Keluar";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(901, 164);
            button3.Name = "button3";
            button3.Size = new Size(143, 23);
            button3.TabIndex = 9;
            button3.Text = "Keluar dari pencarian";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Red;
            label3.Location = new Point(154, 499);
            label3.Name = "label3";
            label3.Size = new Size(0, 15);
            label3.TabIndex = 10;
            // 
            // DokterUI2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1203, 647);
            Controls.Add(label3);
            Controls.Add(button3);
            Controls.Add(button4);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(ScreenTitle);
            Controls.Add(listBox1);
            Name = "DokterUI2";
            Text = "Cari Antibiotik";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListBox listBox1;
        private Label ScreenTitle;
        private Button button2;
        private Label label2;
        private TextBox textBox1;
        private Button button4;
        private Button button3;
        private Label label3;
    }
}