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
            button1 = new Button();
            label1 = new Label();
            button2 = new Button();
            label2 = new Label();
            textBox1 = new TextBox();
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.Font = new Font("Segoe UI", 20F);
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 37;
            listBox1.Location = new Point(267, 306);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(747, 300);
            listBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(1116, 612);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Logout";
            button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(497, 73);
            label1.Name = "label1";
            label1.Size = new Size(257, 25);
            label1.TabIndex = 3;
            label1.Text = "Tampilan 3 Antibiotik terbaik!";
            // 
            // button2
            // 
            button2.Location = new Point(267, 262);
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
            label2.Location = new Point(267, 193);
            label2.Name = "label2";
            label2.Size = new Size(137, 15);
            label2.TabIndex = 5;
            label2.Text = "Bakteri yang ingin dicari:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(267, 211);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(299, 23);
            textBox1.TabIndex = 6;
            // 
            // button3
            // 
            button3.Location = new Point(823, 262);
            button3.Name = "button3";
            button3.Size = new Size(191, 23);
            button3.TabIndex = 7;
            button3.Text = "Kembali ke Tabel";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(12, 612);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 8;
            button4.Text = "Keluar";
            button4.UseVisualStyleBackColor = true;
            // 
            // DokterUI2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1203, 647);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(listBox1);
            Name = "DokterUI2";
            Text = "DokterUI2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListBox listBox1;
        private Button button1;
        private Label label1;
        private Button button2;
        private Label label2;
        private TextBox textBox1;
        private Button button3;
        private Button button4;
    }
}