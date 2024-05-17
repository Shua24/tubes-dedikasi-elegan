namespace StatForm
{
    partial class StatsUI2
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
            Table = new DataGridView();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            ((System.ComponentModel.ISupportInitialize)Table).BeginInit();
            SuspendLayout();
            // 
            // Table
            // 
            Table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Table.Location = new Point(12, 12);
            Table.Name = "Table";
            Table.Size = new Size(1181, 464);
            Table.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(476, 479);
            label1.Name = "label1";
            label1.Size = new Size(296, 21);
            label1.TabIndex = 1;
            label1.Text = "Tabel data pola kuman telah dimasukkan!";
            // 
            // button1
            // 
            button1.Location = new Point(369, 514);
            button1.Name = "button1";
            button1.Size = new Size(141, 23);
            button1.TabIndex = 2;
            button1.Text = "Update/Pilih FIle Lain";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(541, 514);
            button2.Name = "button2";
            button2.Size = new Size(141, 23);
            button2.TabIndex = 3;
            button2.Text = "Hapus";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(1116, 612);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 4;
            button3.Text = "Logout";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(12, 612);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 5;
            button4.Text = "Keluar";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(736, 514);
            button5.Name = "button5";
            button5.Size = new Size(158, 23);
            button5.TabIndex = 6;
            button5.Text = "Cari antibiotik terbaik...";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // StatsUI2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1203, 647);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(Table);
            Name = "StatsUI2";
            Text = "Statistika Pola Kuman";
            Load += StatsUI2_Load;
            ((System.ComponentModel.ISupportInitialize)Table).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView Table;
        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
    }
}