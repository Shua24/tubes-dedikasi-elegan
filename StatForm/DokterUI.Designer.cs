namespace StatForm
{
    partial class DokterUI
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
            dataGridView1 = new DataGridView();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(10, 42);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1181, 444);
            dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(505, 9);
            label1.Name = "label1";
            label1.Size = new Size(179, 21);
            label1.TabIndex = 1;
            label1.Text = "Selamat Datang, Dokter!";
            // 
            // button1
            // 
            button1.Location = new Point(507, 533);
            button1.Name = "button1";
            button1.Size = new Size(193, 23);
            button1.TabIndex = 2;
            button1.Text = "Cari antibiotik dari pola kuman...";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(1116, 610);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 3;
            button2.Text = "Logout";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(12, 610);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 4;
            button3.Text = "Keluar";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F);
            label2.Location = new Point(498, 497);
            label2.Name = "label2";
            label2.Size = new Size(220, 20);
            label2.TabIndex = 5;
            label2.Text = "Apa yang anda butuhkan disini?";
            label2.Click += label2_Click;
            // 
            // DokterUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1203, 647);
            Controls.Add(label2);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "DokterUI";
            Text = "Statistika Pola Kuman";
            Load += DokterUI_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label2;
    }
}