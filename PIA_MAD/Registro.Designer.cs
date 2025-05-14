namespace PIA_MAD
{
    partial class Registro
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
            linkLabel1 = new LinkLabel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            TB_NomRegEmp = new TextBox();
            TB_AMRegEmp = new TextBox();
            TB_APRegEmp = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label8 = new Label();
            DTP_FecNamEmp = new DateTimePicker();
            TB_CorreoRegEmp = new TextBox();
            TB_TelRegEmp = new TextBox();
            TB_CelRegEmp = new TextBox();
            label9 = new Label();
            TB_ContraRegEmp = new TextBox();
            label10 = new Label();
            button1 = new Button();
            DTP_RegEmpl = new DateTimePicker();
            label7 = new Label();
            TB_NumNoRegEmp = new TextBox();
            SuspendLayout();
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(584, 310);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(0, 15);
            linkLabel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(300, 103);
            label1.Name = "label1";
            label1.Size = new Size(70, 15);
            label1.TabIndex = 1;
            label1.Text = "Nombre (s):";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(300, 183);
            label2.Name = "label2";
            label2.Size = new Size(102, 15);
            label2.TabIndex = 2;
            label2.Text = "Apellido materno:";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(300, 140);
            label3.Name = "label3";
            label3.Size = new Size(98, 15);
            label3.TabIndex = 3;
            label3.Text = "Apellido paterno:";
            label3.Click += label3_Click;
            // 
            // TB_NomRegEmp
            // 
            TB_NomRegEmp.Location = new Point(376, 100);
            TB_NomRegEmp.Name = "TB_NomRegEmp";
            TB_NomRegEmp.Size = new Size(267, 23);
            TB_NomRegEmp.TabIndex = 4;
            // 
            // TB_AMRegEmp
            // 
            TB_AMRegEmp.Location = new Point(408, 180);
            TB_AMRegEmp.Name = "TB_AMRegEmp";
            TB_AMRegEmp.Size = new Size(235, 23);
            TB_AMRegEmp.TabIndex = 5;
            // 
            // TB_APRegEmp
            // 
            TB_APRegEmp.Location = new Point(408, 140);
            TB_APRegEmp.Name = "TB_APRegEmp";
            TB_APRegEmp.Size = new Size(235, 23);
            TB_APRegEmp.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(302, 216);
            label4.Name = "label4";
            label4.Size = new Size(46, 15);
            label4.TabIndex = 7;
            label4.Text = "Correo:";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(302, 253);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 8;
            label5.Text = "Teléfono:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(300, 286);
            label6.Name = "label6";
            label6.Size = new Size(47, 15);
            label6.TabIndex = 9;
            label6.Text = "Celular:";
            label6.Click += label6_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(300, 360);
            label8.Name = "label8";
            label8.Size = new Size(120, 15);
            label8.TabIndex = 11;
            label8.Text = "Fecha de nacimiento:";
            // 
            // DTP_FecNamEmp
            // 
            DTP_FecNamEmp.Location = new Point(426, 358);
            DTP_FecNamEmp.Name = "DTP_FecNamEmp";
            DTP_FecNamEmp.Size = new Size(217, 23);
            DTP_FecNamEmp.TabIndex = 12;
            // 
            // TB_CorreoRegEmp
            // 
            TB_CorreoRegEmp.Location = new Point(354, 213);
            TB_CorreoRegEmp.Name = "TB_CorreoRegEmp";
            TB_CorreoRegEmp.Size = new Size(289, 23);
            TB_CorreoRegEmp.TabIndex = 13;
            // 
            // TB_TelRegEmp
            // 
            TB_TelRegEmp.Location = new Point(363, 250);
            TB_TelRegEmp.Name = "TB_TelRegEmp";
            TB_TelRegEmp.Size = new Size(280, 23);
            TB_TelRegEmp.TabIndex = 14;
            // 
            // TB_CelRegEmp
            // 
            TB_CelRegEmp.Location = new Point(354, 283);
            TB_CelRegEmp.Name = "TB_CelRegEmp";
            TB_CelRegEmp.Size = new Size(289, 23);
            TB_CelRegEmp.TabIndex = 15;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(302, 400);
            label9.Name = "label9";
            label9.Size = new Size(70, 15);
            label9.TabIndex = 17;
            label9.Text = "Contraseña:";
            // 
            // TB_ContraRegEmp
            // 
            TB_ContraRegEmp.Location = new Point(378, 397);
            TB_ContraRegEmp.Name = "TB_ContraRegEmp";
            TB_ContraRegEmp.Size = new Size(265, 23);
            TB_ContraRegEmp.TabIndex = 18;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(38, 396);
            label10.Name = "label10";
            label10.Size = new Size(0, 15);
            label10.TabIndex = 20;
            // 
            // button1
            // 
            button1.BackColor = Color.Thistle;
            button1.Location = new Point(437, 481);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 22;
            button1.Text = "Registrar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // DTP_RegEmpl
            // 
            DTP_RegEmpl.Location = new Point(360, 8);
            DTP_RegEmpl.Name = "DTP_RegEmpl";
            DTP_RegEmpl.Size = new Size(232, 23);
            DTP_RegEmpl.TabIndex = 23;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(299, 324);
            label7.Name = "label7";
            label7.Size = new Size(114, 15);
            label7.TabIndex = 10;
            label7.Text = "Número de nomina:";
            // 
            // TB_NumNoRegEmp
            // 
            TB_NumNoRegEmp.Location = new Point(419, 316);
            TB_NumNoRegEmp.Name = "TB_NumNoRegEmp";
            TB_NumNoRegEmp.Size = new Size(223, 23);
            TB_NumNoRegEmp.TabIndex = 16;
            TB_NumNoRegEmp.TextChanged += TB_NumNoRegEmp_TextChanged;
            // 
            // Registro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(936, 546);
            Controls.Add(DTP_RegEmpl);
            Controls.Add(button1);
            Controls.Add(label10);
            Controls.Add(TB_ContraRegEmp);
            Controls.Add(label9);
            Controls.Add(TB_NumNoRegEmp);
            Controls.Add(TB_CelRegEmp);
            Controls.Add(TB_TelRegEmp);
            Controls.Add(TB_CorreoRegEmp);
            Controls.Add(DTP_FecNamEmp);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(TB_APRegEmp);
            Controls.Add(TB_AMRegEmp);
            Controls.Add(TB_NomRegEmp);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(linkLabel1);
            Name = "Registro";
            Text = "Registro Empleados";
            Load += Registro_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private LinkLabel linkLabel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox TB_NomRegEmp;
        private TextBox TB_AMRegEmp;
        private TextBox TB_APRegEmp;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label8;
        private DateTimePicker DTP_FecNamEmp;
        private TextBox TB_CorreoRegEmp;
        private TextBox TB_TelRegEmp;
        private TextBox TB_CelRegEmp;
        private Label label9;
        private TextBox TB_ContraRegEmp;
        private Label label10;
        private Button button1;
        private DateTimePicker dateTimePicker2;
        private Label label7;
        private TextBox TB_NumNoRegEmp;
        private DateTimePicker DTP_RegEmpl;
    }
}