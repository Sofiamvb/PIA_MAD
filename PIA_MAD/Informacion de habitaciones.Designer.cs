namespace PIA_MAD
{
    partial class Informacion_de_habitaciones
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
            BTN_EliminarChar = new Button();
            BTN_AgregarChar = new Button();
            LV_MostrarChar = new ListView();
            BTN_EliminarAm = new Button();
            BTN_AgregarAm = new Button();
            LV_MostrarAm = new ListView();
            LBL_CantHabDisponible = new Label();
            CB_RegHotelDHb = new ComboBox();
            label10 = new Label();
            TB_RegCaractHb = new TextBox();
            label9 = new Label();
            TB_RegAmeHb = new TextBox();
            label8 = new Label();
            DTP_RegHab = new DateTimePicker();
            button1 = new Button();
            TB_RegVistaHb = new TextBox();
            TB_RegNumCHb = new TextBox();
            label7 = new Label();
            label6 = new Label();
            CB_regNvHab = new ComboBox();
            CB_TipoCHab = new ComboBox();
            label5 = new Label();
            TB_RegCapHb = new TextBox();
            label4 = new Label();
            TB_RegPNHb = new TextBox();
            label3 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // BTN_EliminarChar
            // 
            BTN_EliminarChar.Location = new Point(229, 543);
            BTN_EliminarChar.Name = "BTN_EliminarChar";
            BTN_EliminarChar.Size = new Size(75, 23);
            BTN_EliminarChar.TabIndex = 59;
            BTN_EliminarChar.Text = "Eliminar";
            BTN_EliminarChar.UseVisualStyleBackColor = true;
            BTN_EliminarChar.Click += BTN_EliminarChar_Click;
            // 
            // BTN_AgregarChar
            // 
            BTN_AgregarChar.Location = new Point(229, 514);
            BTN_AgregarChar.Name = "BTN_AgregarChar";
            BTN_AgregarChar.Size = new Size(75, 23);
            BTN_AgregarChar.TabIndex = 58;
            BTN_AgregarChar.Text = "Agregar";
            BTN_AgregarChar.UseVisualStyleBackColor = true;
            BTN_AgregarChar.Click += BTN_AgregarChar_Click;
            // 
            // LV_MostrarChar
            // 
            LV_MostrarChar.Location = new Point(28, 514);
            LV_MostrarChar.Name = "LV_MostrarChar";
            LV_MostrarChar.Size = new Size(195, 73);
            LV_MostrarChar.TabIndex = 57;
            LV_MostrarChar.UseCompatibleStateImageBehavior = false;
            LV_MostrarChar.SelectedIndexChanged += LV_MostrarChar_SelectedIndexChanged;
            // 
            // BTN_EliminarAm
            // 
            BTN_EliminarAm.Location = new Point(229, 407);
            BTN_EliminarAm.Name = "BTN_EliminarAm";
            BTN_EliminarAm.Size = new Size(75, 23);
            BTN_EliminarAm.TabIndex = 56;
            BTN_EliminarAm.Text = "Eliminar";
            BTN_EliminarAm.UseVisualStyleBackColor = true;
            BTN_EliminarAm.Click += BTN_EliminarAm_Click;
            // 
            // BTN_AgregarAm
            // 
            BTN_AgregarAm.Location = new Point(229, 378);
            BTN_AgregarAm.Name = "BTN_AgregarAm";
            BTN_AgregarAm.Size = new Size(75, 23);
            BTN_AgregarAm.TabIndex = 55;
            BTN_AgregarAm.Text = "Agregar";
            BTN_AgregarAm.UseVisualStyleBackColor = true;
            BTN_AgregarAm.Click += BTN_AgregarAm_Click;
            // 
            // LV_MostrarAm
            // 
            LV_MostrarAm.Location = new Point(28, 378);
            LV_MostrarAm.Name = "LV_MostrarAm";
            LV_MostrarAm.Size = new Size(195, 73);
            LV_MostrarAm.TabIndex = 54;
            LV_MostrarAm.UseCompatibleStateImageBehavior = false;
            LV_MostrarAm.SelectedIndexChanged += LV_MostrarAm_SelectedIndexChanged;
            // 
            // LBL_CantHabDisponible
            // 
            LBL_CantHabDisponible.AutoSize = true;
            LBL_CantHabDisponible.Location = new Point(286, 129);
            LBL_CantHabDisponible.Name = "LBL_CantHabDisponible";
            LBL_CantHabDisponible.Size = new Size(0, 15);
            LBL_CantHabDisponible.TabIndex = 53;
            // 
            // CB_RegHotelDHb
            // 
            CB_RegHotelDHb.FormattingEnabled = true;
            CB_RegHotelDHb.Location = new Point(131, 92);
            CB_RegHotelDHb.Name = "CB_RegHotelDHb";
            CB_RegHotelDHb.Size = new Size(147, 23);
            CB_RegHotelDHb.TabIndex = 52;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(28, 95);
            label10.Name = "label10";
            label10.Size = new Size(97, 15);
            label10.TabIndex = 51;
            label10.Text = "Hotel designado:";
            // 
            // TB_RegCaractHb
            // 
            TB_RegCaractHb.Location = new Point(28, 485);
            TB_RegCaractHb.Name = "TB_RegCaractHb";
            TB_RegCaractHb.Size = new Size(196, 23);
            TB_RegCaractHb.TabIndex = 50;
            TB_RegCaractHb.KeyDown += TB_RegCaractHb_KeyDown;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(27, 464);
            label9.Name = "label9";
            label9.Size = new Size(86, 15);
            label9.TabIndex = 49;
            label9.Text = "Características:";
            // 
            // TB_RegAmeHb
            // 
            TB_RegAmeHb.Location = new Point(28, 349);
            TB_RegAmeHb.Name = "TB_RegAmeHb";
            TB_RegAmeHb.Size = new Size(195, 23);
            TB_RegAmeHb.TabIndex = 48;
            TB_RegAmeHb.KeyDown += TB_RegAmeHb_KeyDown;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(28, 331);
            label8.Name = "label8";
            label8.Size = new Size(76, 15);
            label8.TabIndex = 47;
            label8.Text = "Amenidades:";
            // 
            // DTP_RegHab
            // 
            DTP_RegHab.Location = new Point(27, 36);
            DTP_RegHab.Name = "DTP_RegHab";
            DTP_RegHab.Size = new Size(224, 23);
            DTP_RegHab.TabIndex = 46;
            // 
            // button1
            // 
            button1.BackColor = Color.Thistle;
            button1.Location = new Point(141, 617);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 45;
            button1.Text = "Actualizar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // TB_RegVistaHb
            // 
            TB_RegVistaHb.Location = new Point(69, 296);
            TB_RegVistaHb.Name = "TB_RegVistaHb";
            TB_RegVistaHb.Size = new Size(163, 23);
            TB_RegVistaHb.TabIndex = 44;
            // 
            // TB_RegNumCHb
            // 
            TB_RegNumCHb.Location = new Point(141, 126);
            TB_RegNumCHb.Name = "TB_RegNumCHb";
            TB_RegNumCHb.Size = new Size(82, 23);
            TB_RegNumCHb.TabIndex = 43;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(28, 129);
            label7.Name = "label7";
            label7.Size = new Size(107, 15);
            label7.TabIndex = 42;
            label7.Text = "Número de camas:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(28, 299);
            label6.Name = "label6";
            label6.Size = new Size(35, 15);
            label6.TabIndex = 41;
            label6.Text = "Vista:";
            // 
            // CB_regNvHab
            // 
            CB_regNvHab.FormattingEnabled = true;
            CB_regNvHab.Location = new Point(146, 264);
            CB_regNvHab.Name = "CB_regNvHab";
            CB_regNvHab.Size = new Size(132, 23);
            CB_regNvHab.TabIndex = 40;
            // 
            // CB_TipoCHab
            // 
            CB_TipoCHab.FormattingEnabled = true;
            CB_TipoCHab.Location = new Point(124, 159);
            CB_TipoCHab.Name = "CB_TipoCHab";
            CB_TipoCHab.Size = new Size(121, 23);
            CB_TipoCHab.TabIndex = 39;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(28, 267);
            label5.Name = "label5";
            label5.Size = new Size(112, 15);
            label5.TabIndex = 38;
            label5.Text = "Nivel de habitación:";
            // 
            // TB_RegCapHb
            // 
            TB_RegCapHb.Location = new Point(100, 224);
            TB_RegCapHb.Name = "TB_RegCapHb";
            TB_RegCapHb.Size = new Size(82, 23);
            TB_RegCapHb.TabIndex = 37;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(28, 227);
            label4.Name = "label4";
            label4.Size = new Size(66, 15);
            label4.TabIndex = 36;
            label4.Text = "Capacidad:";
            // 
            // TB_RegPNHb
            // 
            TB_RegPNHb.Location = new Point(134, 192);
            TB_RegPNHb.Name = "TB_RegPNHb";
            TB_RegPNHb.Size = new Size(82, 23);
            TB_RegPNHb.TabIndex = 35;
            TB_RegPNHb.TextChanged += TB_RegPNHb_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 195);
            label3.Name = "label3";
            label3.Size = new Size(100, 15);
            label3.TabIndex = 34;
            label3.Text = "Precio por noche:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 162);
            label2.Name = "label2";
            label2.Size = new Size(82, 15);
            label2.TabIndex = 33;
            label2.Text = "Tipo de cama:";
            // 
            // Informacion_de_habitaciones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(389, 652);
            Controls.Add(BTN_EliminarChar);
            Controls.Add(BTN_AgregarChar);
            Controls.Add(LV_MostrarChar);
            Controls.Add(BTN_EliminarAm);
            Controls.Add(BTN_AgregarAm);
            Controls.Add(LV_MostrarAm);
            Controls.Add(LBL_CantHabDisponible);
            Controls.Add(CB_RegHotelDHb);
            Controls.Add(label10);
            Controls.Add(TB_RegCaractHb);
            Controls.Add(label9);
            Controls.Add(TB_RegAmeHb);
            Controls.Add(label8);
            Controls.Add(DTP_RegHab);
            Controls.Add(button1);
            Controls.Add(TB_RegVistaHb);
            Controls.Add(TB_RegNumCHb);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(CB_regNvHab);
            Controls.Add(CB_TipoCHab);
            Controls.Add(label5);
            Controls.Add(TB_RegCapHb);
            Controls.Add(label4);
            Controls.Add(TB_RegPNHb);
            Controls.Add(label3);
            Controls.Add(label2);
            Name = "Informacion_de_habitaciones";
            Text = "Informacion_de_habitaciones";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BTN_EliminarChar;
        private Button BTN_AgregarChar;
        private ListView LV_MostrarChar;
        private Button BTN_EliminarAm;
        private Button BTN_AgregarAm;
        private ListView LV_MostrarAm;
        private Label LBL_CantHabDisponible;
        private ComboBox CB_RegHotelDHb;
        private Label label10;
        private TextBox TB_RegCaractHb;
        private Label label9;
        private TextBox TB_RegAmeHb;
        private Label label8;
        private DateTimePicker DTP_RegHab;
        private Button button1;
        private TextBox TB_RegVistaHb;
        private TextBox TB_RegNumCHb;
        private Label label7;
        private Label label6;
        private ComboBox CB_regNvHab;
        private ComboBox CB_TipoCHab;
        private Label label5;
        private TextBox TB_RegCapHb;
        private Label label4;
        private TextBox TB_RegPNHb;
        private Label label3;
        private Label label2;
    }
}