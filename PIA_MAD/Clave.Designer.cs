namespace PIA_MAD
{
    partial class Ini_Clave
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
            TB_ClaveIni = new TextBox();
            BT_IniClave = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(184, 48);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 0;
            label1.Text = "Clave de inicio:";
            // 
            // TB_ClaveIni
            // 
            TB_ClaveIni.Location = new Point(120, 80);
            TB_ClaveIni.Name = "TB_ClaveIni";
            TB_ClaveIni.Size = new Size(216, 23);
            TB_ClaveIni.TabIndex = 1;
            // 
            // BT_IniClave
            // 
            BT_IniClave.Location = new Point(184, 128);
            BT_IniClave.Name = "BT_IniClave";
            BT_IniClave.Size = new Size(75, 23);
            BT_IniClave.TabIndex = 2;
            BT_IniClave.Text = "Ingresar";
            BT_IniClave.UseVisualStyleBackColor = true;
            BT_IniClave.Click += BT_IniClave_Click;
            // 
            // Ini_Clave
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(454, 163);
            Controls.Add(BT_IniClave);
            Controls.Add(TB_ClaveIni);
            Controls.Add(label1);
            Name = "Ini_Clave";
            Text = "Clave";
            Load += Ini_Clave_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox TB_ClaveIni;
        private Button BT_IniClave;
    }
}