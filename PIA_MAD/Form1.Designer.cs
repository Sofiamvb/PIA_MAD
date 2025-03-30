namespace PIA_MAD
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
            label2 = new Label();
            TB_IniContra = new TextBox();
            TB_IniCorreo = new TextBox();
            BTN_IngIni = new Button();
            button2 = new Button();
            RB_IniAdm = new RadioButton();
            RB_IniOp = new RadioButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Control;
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(192, 24);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 2;
            label1.Text = "Correo:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(182, 109);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 3;
            label2.Text = "Contraseña:";
            // 
            // TB_IniContra
            // 
            TB_IniContra.Location = new Point(122, 142);
            TB_IniContra.Name = "TB_IniContra";
            TB_IniContra.Size = new Size(193, 23);
            TB_IniContra.TabIndex = 4;
            // 
            // TB_IniCorreo
            // 
            TB_IniCorreo.Location = new Point(122, 54);
            TB_IniCorreo.Name = "TB_IniCorreo";
            TB_IniCorreo.Size = new Size(193, 23);
            TB_IniCorreo.TabIndex = 5;
            // 
            // BTN_IngIni
            // 
            BTN_IngIni.BackColor = Color.Thistle;
            BTN_IngIni.ForeColor = SystemColors.ControlText;
            BTN_IngIni.Location = new Point(120, 256);
            BTN_IngIni.Name = "BTN_IngIni";
            BTN_IngIni.Size = new Size(75, 23);
            BTN_IngIni.TabIndex = 6;
            BTN_IngIni.Text = "Ingresar";
            BTN_IngIni.UseVisualStyleBackColor = false;
            BTN_IngIni.Click += BTN_IngIni_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Thistle;
            button2.ForeColor = SystemColors.ControlText;
            button2.Location = new Point(238, 256);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 7;
            button2.Text = "Registrarse";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // RB_IniAdm
            // 
            RB_IniAdm.AutoSize = true;
            RB_IniAdm.Location = new Point(112, 192);
            RB_IniAdm.Name = "RB_IniAdm";
            RB_IniAdm.Size = new Size(101, 19);
            RB_IniAdm.TabIndex = 8;
            RB_IniAdm.TabStop = true;
            RB_IniAdm.Text = "Administrador";
            RB_IniAdm.UseVisualStyleBackColor = true;
            // 
            // RB_IniOp
            // 
            RB_IniOp.AutoSize = true;
            RB_IniOp.Location = new Point(248, 192);
            RB_IniOp.Name = "RB_IniOp";
            RB_IniOp.Size = new Size(77, 19);
            RB_IniOp.TabIndex = 9;
            RB_IniOp.TabStop = true;
            RB_IniOp.Text = "Operativo";
            RB_IniOp.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(448, 303);
            Controls.Add(RB_IniOp);
            Controls.Add(RB_IniAdm);
            Controls.Add(button2);
            Controls.Add(BTN_IngIni);
            Controls.Add(TB_IniCorreo);
            Controls.Add(TB_IniContra);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Inicio de sesión";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private TextBox TB_IniContra;
        private TextBox TB_IniCorreo;
        private Button BTN_IngIni;
        private Button button2;
        private RadioButton RB_IniAdm;
        private RadioButton RB_IniOp;
    }
}
