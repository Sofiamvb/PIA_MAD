﻿namespace PIA_MAD
{
    partial class Registro_de_habitaciones
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
            label2 = new Label();
            label3 = new Label();
            TB_RegPNHb = new TextBox();
            label4 = new Label();
            TB_RegCapHb = new TextBox();
            label5 = new Label();
            CB_TipoCHab = new ComboBox();
            CB_regNvHab = new ComboBox();
            label7 = new Label();
            TB_RegNumCHb = new TextBox();
            label6 = new Label();
            TB_RegVistaHb = new TextBox();
            button1 = new Button();
            DTP_RegHab = new DateTimePicker();
            label8 = new Label();
            TB_RegAmeHb = new TextBox();
            label9 = new Label();
            TB_RegCaractHb = new TextBox();
            label10 = new Label();
            CB_RegHotelDHb = new ComboBox();
            LBL_CantHabDisponible = new Label();
            LV_MostrarAm = new ListView();
            BTN_AgregarAm = new Button();
            BTN_EliminarAm = new Button();
            LV_MostrarChar = new ListView();
            BTN_AgregarChar = new Button();
            BTN_EliminarChar = new Button();
            TB_RegCantHhb = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(473, 188);
            label2.Name = "label2";
            label2.Size = new Size(81, 15);
            label2.TabIndex = 2;
            label2.Text = "Tipo de cama:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(473, 221);
            label3.Name = "label3";
            label3.Size = new Size(100, 15);
            label3.TabIndex = 4;
            label3.Text = "Precio por noche:";
            // 
            // TB_RegPNHb
            // 
            TB_RegPNHb.Location = new Point(579, 218);
            TB_RegPNHb.Name = "TB_RegPNHb";
            TB_RegPNHb.Size = new Size(82, 23);
            TB_RegPNHb.TabIndex = 5;
            TB_RegPNHb.TextChanged += TB_RegPNHb_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(473, 253);
            label4.Name = "label4";
            label4.Size = new Size(66, 15);
            label4.TabIndex = 6;
            label4.Text = "Capacidad:";
            // 
            // TB_RegCapHb
            // 
            TB_RegCapHb.Location = new Point(545, 250);
            TB_RegCapHb.Name = "TB_RegCapHb";
            TB_RegCapHb.Size = new Size(82, 23);
            TB_RegCapHb.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(473, 293);
            label5.Name = "label5";
            label5.Size = new Size(112, 15);
            label5.TabIndex = 8;
            label5.Text = "Nivel de habitación:";
            // 
            // CB_TipoCHab
            // 
            CB_TipoCHab.FormattingEnabled = true;
            CB_TipoCHab.Location = new Point(569, 185);
            CB_TipoCHab.Name = "CB_TipoCHab";
            CB_TipoCHab.Size = new Size(121, 23);
            CB_TipoCHab.TabIndex = 9;
            // 
            // CB_regNvHab
            // 
            CB_regNvHab.FormattingEnabled = true;
            CB_regNvHab.Location = new Point(591, 290);
            CB_regNvHab.Name = "CB_regNvHab";
            CB_regNvHab.Size = new Size(132, 23);
            CB_regNvHab.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(473, 155);
            label7.Name = "label7";
            label7.Size = new Size(107, 15);
            label7.TabIndex = 13;
            label7.Text = "Número de camas:";
            // 
            // TB_RegNumCHb
            // 
            TB_RegNumCHb.Location = new Point(586, 152);
            TB_RegNumCHb.Name = "TB_RegNumCHb";
            TB_RegNumCHb.Size = new Size(82, 23);
            TB_RegNumCHb.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(473, 325);
            label6.Name = "label6";
            label6.Size = new Size(35, 15);
            label6.TabIndex = 11;
            label6.Text = "Vista:";
            // 
            // TB_RegVistaHb
            // 
            TB_RegVistaHb.Location = new Point(514, 322);
            TB_RegVistaHb.Name = "TB_RegVistaHb";
            TB_RegVistaHb.Size = new Size(163, 23);
            TB_RegVistaHb.TabIndex = 15;
            // 
            // button1
            // 
            button1.BackColor = Color.Thistle;
            button1.Location = new Point(586, 619);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 16;
            button1.Text = "Registrar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // DTP_RegHab
            // 
            DTP_RegHab.Location = new Point(472, 32);
            DTP_RegHab.Name = "DTP_RegHab";
            DTP_RegHab.Size = new Size(224, 23);
            DTP_RegHab.TabIndex = 17;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(473, 357);
            label8.Name = "label8";
            label8.Size = new Size(76, 15);
            label8.TabIndex = 18;
            label8.Text = "Amenidades:";
            // 
            // TB_RegAmeHb
            // 
            TB_RegAmeHb.Location = new Point(473, 375);
            TB_RegAmeHb.Name = "TB_RegAmeHb";
            TB_RegAmeHb.Size = new Size(195, 23);
            TB_RegAmeHb.TabIndex = 19;
            TB_RegAmeHb.KeyDown += TB_RegAmeHb_KeyDown;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(472, 490);
            label9.Name = "label9";
            label9.Size = new Size(86, 15);
            label9.TabIndex = 20;
            label9.Text = "Características:";
            // 
            // TB_RegCaractHb
            // 
            TB_RegCaractHb.Location = new Point(473, 511);
            TB_RegCaractHb.Name = "TB_RegCaractHb";
            TB_RegCaractHb.Size = new Size(196, 23);
            TB_RegCaractHb.TabIndex = 21;
            TB_RegCaractHb.KeyDown += TB_RegCaractHb_KeyDown;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(473, 91);
            label10.Name = "label10";
            label10.Size = new Size(97, 15);
            label10.TabIndex = 22;
            label10.Text = "Hotel designado:";
            // 
            // CB_RegHotelDHb
            // 
            CB_RegHotelDHb.FormattingEnabled = true;
            CB_RegHotelDHb.Location = new Point(576, 88);
            CB_RegHotelDHb.Name = "CB_RegHotelDHb";
            CB_RegHotelDHb.Size = new Size(147, 23);
            CB_RegHotelDHb.TabIndex = 23;
            CB_RegHotelDHb.SelectedIndexChanged += CB_RegHotelDHb_SelectedIndexChanged;
            // 
            // LBL_CantHabDisponible
            // 
            LBL_CantHabDisponible.AutoSize = true;
            LBL_CantHabDisponible.Location = new Point(731, 125);
            LBL_CantHabDisponible.Name = "LBL_CantHabDisponible";
            LBL_CantHabDisponible.Size = new Size(0, 15);
            LBL_CantHabDisponible.TabIndex = 24;
            // 
            // LV_MostrarAm
            // 
            LV_MostrarAm.Location = new Point(473, 404);
            LV_MostrarAm.Name = "LV_MostrarAm";
            LV_MostrarAm.Size = new Size(195, 73);
            LV_MostrarAm.TabIndex = 25;
            LV_MostrarAm.UseCompatibleStateImageBehavior = false;
            LV_MostrarAm.SelectedIndexChanged += LV_MostrarAm_SelectedIndexChanged;
            // 
            // BTN_AgregarAm
            // 
            BTN_AgregarAm.Location = new Point(674, 404);
            BTN_AgregarAm.Name = "BTN_AgregarAm";
            BTN_AgregarAm.Size = new Size(75, 23);
            BTN_AgregarAm.TabIndex = 26;
            BTN_AgregarAm.Text = "Agregar";
            BTN_AgregarAm.UseVisualStyleBackColor = true;
            BTN_AgregarAm.Click += BTN_AgregarAm_Click;
            // 
            // BTN_EliminarAm
            // 
            BTN_EliminarAm.Location = new Point(674, 433);
            BTN_EliminarAm.Name = "BTN_EliminarAm";
            BTN_EliminarAm.Size = new Size(75, 23);
            BTN_EliminarAm.TabIndex = 27;
            BTN_EliminarAm.Text = "Eliminar";
            BTN_EliminarAm.UseVisualStyleBackColor = true;
            BTN_EliminarAm.Click += BTN_EliminarAm_Click;
            // 
            // LV_MostrarChar
            // 
            LV_MostrarChar.Location = new Point(473, 540);
            LV_MostrarChar.Name = "LV_MostrarChar";
            LV_MostrarChar.Size = new Size(195, 73);
            LV_MostrarChar.TabIndex = 28;
            LV_MostrarChar.UseCompatibleStateImageBehavior = false;
            LV_MostrarChar.SelectedIndexChanged += LV_MostrarChar_SelectedIndexChanged;
            // 
            // BTN_AgregarChar
            // 
            BTN_AgregarChar.Location = new Point(674, 540);
            BTN_AgregarChar.Name = "BTN_AgregarChar";
            BTN_AgregarChar.Size = new Size(75, 23);
            BTN_AgregarChar.TabIndex = 29;
            BTN_AgregarChar.Text = "Agregar";
            BTN_AgregarChar.UseVisualStyleBackColor = true;
            BTN_AgregarChar.Click += BTN_AgregarChar_Click;
            // 
            // BTN_EliminarChar
            // 
            BTN_EliminarChar.Location = new Point(674, 569);
            BTN_EliminarChar.Name = "BTN_EliminarChar";
            BTN_EliminarChar.Size = new Size(75, 23);
            BTN_EliminarChar.TabIndex = 30;
            BTN_EliminarChar.Text = "Eliminar";
            BTN_EliminarChar.UseVisualStyleBackColor = true;
            BTN_EliminarChar.Click += BTN_EliminarChar_Click;
            // 
            // TB_RegCantHhb
            // 
            TB_RegCantHhb.Location = new Point(623, 120);
            TB_RegCantHhb.Name = "TB_RegCantHhb";
            TB_RegCantHhb.Size = new Size(82, 23);
            TB_RegCantHhb.TabIndex = 1;
            TB_RegCantHhb.TextChanged += TB_RegCantHhb_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(473, 123);
            label1.Name = "label1";
            label1.Size = new Size(144, 15);
            label1.TabIndex = 0;
            label1.Text = "Cantidad de habitaciones:";
            // 
            // Registro_de_habitaciones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1164, 654);
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
            Controls.Add(TB_RegCantHhb);
            Controls.Add(label1);
            Name = "Registro_de_habitaciones";
            Text = "Registro de habitaciones";
            Load += Registro_de_habitaciones_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Label label3;
        private TextBox TB_RegPNHb;
        private Label label4;
        private TextBox TB_RegCapHb;
        private Label label5;
        private ComboBox CB_TipoCHab;
        private ComboBox CB_regNvHab;
        private Label label7;
        private TextBox TB_RegNumCHb;
        private Label label6;
        private TextBox TB_RegVistaHb;
        private Button button1;
        private DateTimePicker DTP_RegHab;
        private Label label8;
        private TextBox TB_RegAmeHb;
        private Label label9;
        private TextBox TB_RegCaractHb;
        private Label label10;
        private ComboBox CB_RegHotelDHb;
        private Label LBL_CantHabDisponible;
        private ListView LV_MostrarAm;
        private Button BTN_AgregarAm;
        private Button BTN_EliminarAm;
        private ListView LV_MostrarChar;
        private Button BTN_AgregarChar;
        private Button BTN_EliminarChar;
        private TextBox TB_RegCantHhb;
        private Label label1;
    }
}