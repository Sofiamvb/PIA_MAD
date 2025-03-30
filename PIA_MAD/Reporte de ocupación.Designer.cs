namespace PIA_MAD
{
    partial class Reporte_de_ocupación
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
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            comboBox1 = new ComboBox();
            button1 = new Button();
            listBox1 = new ListBox();
            label5 = new Label();
            label6 = new Label();
            listBox2 = new ListBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(73, 66);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 0;
            label1.Text = "País:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(110, 63);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(130, 23);
            textBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(265, 66);
            label2.Name = "label2";
            label2.Size = new Size(32, 15);
            label2.TabIndex = 2;
            label2.Text = "Año:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(302, 63);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(130, 23);
            textBox2.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(463, 66);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 4;
            label3.Text = "Ciudad:";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(517, 63);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(130, 23);
            textBox3.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(676, 66);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 6;
            label4.Text = "Hotel:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(721, 63);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(139, 23);
            comboBox1.TabIndex = 7;
            // 
            // button1
            // 
            button1.Location = new Point(436, 110);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 8;
            button1.Text = "Filtrar";
            button1.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(270, 208);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(190, 94);
            listBox1.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(302, 168);
            label5.Name = "label5";
            label5.Size = new Size(128, 15);
            label5.TabIndex = 10;
            label5.Text = "Información completa:";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(547, 168);
            label6.Name = "label6";
            label6.Size = new Size(59, 15);
            label6.TabIndex = 12;
            label6.Text = "Resumen:";
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 15;
            listBox2.Location = new Point(487, 208);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(190, 94);
            listBox2.TabIndex = 11;
            // 
            // Reporte_de_ocupación
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(943, 343);
            Controls.Add(label6);
            Controls.Add(listBox2);
            Controls.Add(label5);
            Controls.Add(listBox1);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(label4);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "Reporte_de_ocupación";
            Text = "Reporte de ocupación";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox3;
        private Label label4;
        private ComboBox comboBox1;
        private Button button1;
        private ListBox listBox1;
        private Label label5;
        private Label label6;
        private ListBox listBox2;
    }
}