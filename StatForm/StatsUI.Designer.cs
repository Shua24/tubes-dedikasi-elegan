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
            Table = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            button4 = new Button();
            button2 = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)Table).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(522, 533);
            button1.Name = "button1";
            button1.Size = new Size(141, 33);
            button1.TabIndex = 0;
            button1.Text = "File...";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Table
            // 
            Table.AllowDrop = true;
            Table.AllowUserToAddRows = false;
            Table.AllowUserToDeleteRows = false;
            Table.AllowUserToOrderColumns = true;
            Table.AllowUserToResizeRows = false;
            Table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Table.EditMode = DataGridViewEditMode.EditProgrammatically;
            Table.Enabled = false;
            Table.Location = new Point(10, 42);
            Table.Name = "Table";
            Table.ReadOnly = true;
            Table.Size = new Size(1181, 444);
            Table.TabIndex = 2;
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
            label4.Font = new Font("Segoe UI", 11F);
            label4.Location = new Point(466, 9);
            label4.Name = "label4";
            label4.Size = new Size(246, 20);
            label4.TabIndex = 10;
            label4.Text = "Selamat Datang, Tim Mikrobiologi! ";
            // 
            // button4
            // 
            button4.Location = new Point(12, 610);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 6;
            button4.Text = "Keluar";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button2
            // 
            button2.Location = new Point(1116, 610);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 11;
            button2.Text = "Logout";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F);
            label1.Location = new Point(469, 497);
            label1.Name = "label1";
            label1.Size = new Size(258, 20);
            label1.TabIndex = 12;
            label1.Text = "Pilih file pola kuman yang dibutuhkan";
            // 
            // StatsUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1203, 647);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button4);
            Controls.Add(Table);
            Controls.Add(button1);
            Name = "StatsUI";
            Text = "Statistika Pola Kuman";
            ((System.ComponentModel.ISupportInitialize)Table).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private DataGridView Table;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button4;
        private Button button2;
        private Label label1;
    }
}