namespace StatForm
{
    partial class StatsUI
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
            button1 = new Button();
            button2 = new Button();
            Table = new DataGridView();
            textBox1 = new TextBox();
            label1 = new Label();
            button4 = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            listBox1 = new ListBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)Table).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(28, 158);
            button1.Name = "button1";
            button1.Size = new Size(141, 23);
            button1.TabIndex = 0;
            button1.Text = "File Pola Kuman...";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(28, 332);
            button2.Name = "button2";
            button2.Size = new Size(191, 23);
            button2.TabIndex = 1;
            button2.Text = "Tampilkan 3 antibiotik terbaik...";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Table
            // 
            Table.AllowUserToAddRows = false;
            Table.AllowUserToDeleteRows = false;
            Table.AllowUserToOrderColumns = true;
            Table.AllowUserToResizeColumns = false;
            Table.AllowUserToResizeRows = false;
            Table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Table.EditMode = DataGridViewEditMode.EditProgrammatically;
            Table.Enabled = false;
            Table.Location = new Point(351, 12);
            Table.Name = "Table";
            Table.ReadOnly = true;
            Table.Size = new Size(1280, 720);
            Table.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(28, 288);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(233, 23);
            textBox1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 258);
            label1.Name = "label1";
            label1.Size = new Size(137, 15);
            label1.TabIndex = 4;
            label1.Text = "Bakteri yang ingin dicari:";
            // 
            // button4
            // 
            button4.Location = new Point(267, 607);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 6;
            button4.Text = "Keluar";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(75, 618);
            label2.Name = "label2";
            label2.Size = new Size(0, 15);
            label2.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Red;
            label3.Location = new Point(28, 598);
            label3.Name = "label3";
            label3.Size = new Size(0, 15);
            label3.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(28, 196);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 10;
            label4.Text = "Referensi:";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(28, 386);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(233, 244);
            listBox1.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(28, 47);
            label5.Name = "label5";
            label5.Size = new Size(246, 15);
            label5.TabIndex = 12;
            label5.Text = "Pola kuman biasa dihitung dalam persentase.";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(28, 62);
            label6.Name = "label6";
            label6.Size = new Size(278, 15);
            label6.TabIndex = 13;
            label6.Text = "Angka kecil berarti bakteri kebal terhadap antibiotik";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(28, 77);
            label7.Name = "label7";
            label7.Size = new Size(307, 15);
            label7.TabIndex = 14;
            label7.Text = "Semakin tinggi angka, semakin responsif bakteri tersebut";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(28, 92);
            label8.Name = "label8";
            label8.Size = new Size(110, 15);
            label8.TabIndex = 15;
            label8.Text = "terhadap antibiotik.";
            // 
            // StatsUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1203, 647);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(listBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button4);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(Table);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "StatsUI";
            Text = "Statistika Pola Kuman";
            ((System.ComponentModel.ISupportInitialize)Table).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private DataGridView Table;
        private TextBox textBox1;
        private Label label1;
        private Button button4;
        private Label label2;
        private Label label3;
        private ListBox listBox1;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
    }
}