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
            TB_Pais = new TextBox();
            label2 = new Label();
            TB_Anio = new TextBox();
            label3 = new Label();
            TB_Ciudad = new TextBox();
            label4 = new Label();
            CB_Hoteles = new ComboBox();
            BTN_Filtrar = new Button();
            label5 = new Label();
            label6 = new Label();
            LV_InfoCompleta = new ListView();
            LV_Resumen = new ListView();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 66);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 0;
            label1.Text = "País:";
            // 
            // TB_Pais
            // 
            TB_Pais.Location = new Point(72, 63);
            TB_Pais.Name = "TB_Pais";
            TB_Pais.Size = new Size(130, 23);
            TB_Pais.TabIndex = 1;
            TB_Pais.TextChanged += TB_Pais_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(523, 66);
            label2.Name = "label2";
            label2.Size = new Size(32, 15);
            label2.TabIndex = 2;
            label2.Text = "Año:";
            // 
            // TB_Anio
            // 
            TB_Anio.Location = new Point(560, 63);
            TB_Anio.Name = "TB_Anio";
            TB_Anio.Size = new Size(130, 23);
            TB_Anio.TabIndex = 3;
            TB_Anio.TextChanged += TB_Anio_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(260, 66);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 4;
            label3.Text = "Ciudad:";
            // 
            // TB_Ciudad
            // 
            TB_Ciudad.Location = new Point(314, 63);
            TB_Ciudad.Name = "TB_Ciudad";
            TB_Ciudad.Size = new Size(130, 23);
            TB_Ciudad.TabIndex = 5;
            TB_Ciudad.TextChanged += TB_Ciudad_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(828, 66);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 6;
            label4.Text = "Hotel:";
            // 
            // CB_Hoteles
            // 
            CB_Hoteles.FormattingEnabled = true;
            CB_Hoteles.Location = new Point(873, 63);
            CB_Hoteles.Name = "CB_Hoteles";
            CB_Hoteles.Size = new Size(139, 23);
            CB_Hoteles.TabIndex = 7;
            CB_Hoteles.SelectedIndexChanged += CB_Hoteles_SelectedIndexChanged;
            // 
            // BTN_Filtrar
            // 
            BTN_Filtrar.Location = new Point(1101, 63);
            BTN_Filtrar.Name = "BTN_Filtrar";
            BTN_Filtrar.Size = new Size(75, 23);
            BTN_Filtrar.TabIndex = 8;
            BTN_Filtrar.Text = "Filtrar";
            BTN_Filtrar.UseVisualStyleBackColor = true;
            BTN_Filtrar.Click += BTN_Filtrar_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(36, 143);
            label5.Name = "label5";
            label5.Size = new Size(128, 15);
            label5.TabIndex = 10;
            label5.Text = "Información completa:";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(631, 143);
            label6.Name = "label6";
            label6.Size = new Size(59, 15);
            label6.TabIndex = 12;
            label6.Text = "Resumen:";
            // 
            // LV_InfoCompleta
            // 
            LV_InfoCompleta.Location = new Point(36, 174);
            LV_InfoCompleta.Name = "LV_InfoCompleta";
            LV_InfoCompleta.Size = new Size(567, 128);
            LV_InfoCompleta.TabIndex = 13;
            LV_InfoCompleta.UseCompatibleStateImageBehavior = false;
            // 
            // LV_Resumen
            // 
            LV_Resumen.Location = new Point(631, 174);
            LV_Resumen.Name = "LV_Resumen";
            LV_Resumen.Size = new Size(545, 128);
            LV_Resumen.TabIndex = 14;
            LV_Resumen.UseCompatibleStateImageBehavior = false;
            // 
            // Reporte_de_ocupación
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1188, 343);
            Controls.Add(LV_Resumen);
            Controls.Add(LV_InfoCompleta);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(BTN_Filtrar);
            Controls.Add(CB_Hoteles);
            Controls.Add(label4);
            Controls.Add(TB_Ciudad);
            Controls.Add(label3);
            Controls.Add(TB_Anio);
            Controls.Add(label2);
            Controls.Add(TB_Pais);
            Controls.Add(label1);
            Name = "Reporte_de_ocupación";
            Text = "Reporte de ocupación";
            Load += Reporte_de_ocupación_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox TB_Pais;
        private Label label2;
        private TextBox TB_Anio;
        private Label label3;
        private TextBox TB_Ciudad;
        private Label label4;
        private ComboBox CB_Hotel;
        private Button BTN_Filtrar;
        private Label label5;
        private Label label6;
        private ListView LV_InfoCompleta;
        private ListView LV_Resumen;
        private ComboBox CB_Hoteles;
    }
}