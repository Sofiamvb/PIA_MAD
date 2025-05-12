namespace PIA_MAD
{
    partial class Informacion_Hotel
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
            label11 = new Label();
            TB_RegAm = new TextBox();
            TB_RegChar = new TextBox();
            BTN_EliminarAm = new Button();
            BTN_AgregarAm = new Button();
            BTN_EliminarChar = new Button();
            BTN_AgregarChar = new Button();
            LV_MostrarAm = new ListView();
            LV_MostrarChar = new ListView();
            LV_ServiciosAgregados = new ListView();
            BTN_EliminarServicio = new Button();
            BTN_AgregarServicio = new Button();
            TB_RegServAdHPr = new TextBox();
            label18 = new Label();
            label12 = new Label();
            ChB_RegFrentePlayaH = new CheckBox();
            ChB_RegZTH = new CheckBox();
            RB_SEventNo = new RadioButton();
            label19 = new Label();
            RB_SEventSi = new RadioButton();
            TB_RegChabH = new TextBox();
            label20 = new Label();
            label21 = new Label();
            label22 = new Label();
            button1 = new Button();
            DTP_RegHotel = new DateTimePicker();
            TB_RegCantPisH = new TextBox();
            label23 = new Label();
            label24 = new Label();
            TB_RegServAdH = new TextBox();
            label25 = new Label();
            label26 = new Label();
            TB_RegNumPH = new TextBox();
            label27 = new Label();
            TB_RegDomH = new TextBox();
            label28 = new Label();
            TB_RegPaisH = new TextBox();
            TB_RegEstH = new TextBox();
            TB_RegCuH = new TextBox();
            label29 = new Label();
            label30 = new Label();
            label31 = new Label();
            label32 = new Label();
            TB_RegNomH = new TextBox();
            label33 = new Label();
            SuspendLayout();
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(19, 414);
            label11.Name = "label11";
            label11.Size = new Size(0, 15);
            label11.TabIndex = 59;
            // 
            // TB_RegAm
            // 
            TB_RegAm.Location = new Point(316, 380);
            TB_RegAm.Name = "TB_RegAm";
            TB_RegAm.Size = new Size(163, 23);
            TB_RegAm.TabIndex = 122;
            TB_RegAm.KeyDown += TB_RegAm_KeyDown;
            // 
            // TB_RegChar
            // 
            TB_RegChar.Location = new Point(59, 380);
            TB_RegChar.Name = "TB_RegChar";
            TB_RegChar.Size = new Size(159, 23);
            TB_RegChar.TabIndex = 121;
            TB_RegChar.KeyDown += TB_RegChar_KeyDown;
            // 
            // BTN_EliminarAm
            // 
            BTN_EliminarAm.Location = new Point(485, 438);
            BTN_EliminarAm.Name = "BTN_EliminarAm";
            BTN_EliminarAm.Size = new Size(75, 23);
            BTN_EliminarAm.TabIndex = 120;
            BTN_EliminarAm.Text = "Eliminar";
            BTN_EliminarAm.UseVisualStyleBackColor = true;
            BTN_EliminarAm.Click += BTN_EliminarAm_Click;
            // 
            // BTN_AgregarAm
            // 
            BTN_AgregarAm.Location = new Point(485, 409);
            BTN_AgregarAm.Name = "BTN_AgregarAm";
            BTN_AgregarAm.Size = new Size(75, 23);
            BTN_AgregarAm.TabIndex = 119;
            BTN_AgregarAm.Text = "Agregar";
            BTN_AgregarAm.UseVisualStyleBackColor = true;
            BTN_AgregarAm.Click += BTN_AgregarAm_Click;
            // 
            // BTN_EliminarChar
            // 
            BTN_EliminarChar.Location = new Point(224, 438);
            BTN_EliminarChar.Name = "BTN_EliminarChar";
            BTN_EliminarChar.Size = new Size(75, 23);
            BTN_EliminarChar.TabIndex = 118;
            BTN_EliminarChar.Text = "Eliminar";
            BTN_EliminarChar.UseVisualStyleBackColor = true;
            BTN_EliminarChar.Click += BTN_EliminarChar_Click;
            // 
            // BTN_AgregarChar
            // 
            BTN_AgregarChar.Location = new Point(224, 409);
            BTN_AgregarChar.Name = "BTN_AgregarChar";
            BTN_AgregarChar.Size = new Size(75, 23);
            BTN_AgregarChar.TabIndex = 117;
            BTN_AgregarChar.Text = "Agregar";
            BTN_AgregarChar.UseVisualStyleBackColor = true;
            BTN_AgregarChar.Click += BTN_AgregarChar_Click;
            // 
            // LV_MostrarAm
            // 
            LV_MostrarAm.Location = new Point(316, 409);
            LV_MostrarAm.Name = "LV_MostrarAm";
            LV_MostrarAm.Size = new Size(163, 97);
            LV_MostrarAm.TabIndex = 116;
            LV_MostrarAm.UseCompatibleStateImageBehavior = false;
            LV_MostrarAm.SelectedIndexChanged += LV_MostrarAm_SelectedIndexChanged;
            // 
            // LV_MostrarChar
            // 
            LV_MostrarChar.Location = new Point(58, 409);
            LV_MostrarChar.Name = "LV_MostrarChar";
            LV_MostrarChar.Size = new Size(159, 97);
            LV_MostrarChar.TabIndex = 115;
            LV_MostrarChar.UseCompatibleStateImageBehavior = false;
            LV_MostrarChar.SelectedIndexChanged += LV_MostrarChar_SelectedIndexChanged;
            // 
            // LV_ServiciosAgregados
            // 
            LV_ServiciosAgregados.Location = new Point(59, 606);
            LV_ServiciosAgregados.Name = "LV_ServiciosAgregados";
            LV_ServiciosAgregados.Size = new Size(321, 97);
            LV_ServiciosAgregados.TabIndex = 114;
            LV_ServiciosAgregados.UseCompatibleStateImageBehavior = false;
            LV_ServiciosAgregados.SelectedIndexChanged += LV_ServiciosAgregados_SelectedIndexChanged;
            // 
            // BTN_EliminarServicio
            // 
            BTN_EliminarServicio.Location = new Point(392, 606);
            BTN_EliminarServicio.Name = "BTN_EliminarServicio";
            BTN_EliminarServicio.Size = new Size(75, 23);
            BTN_EliminarServicio.TabIndex = 113;
            BTN_EliminarServicio.Text = "Eliminar";
            BTN_EliminarServicio.UseVisualStyleBackColor = true;
            BTN_EliminarServicio.Click += BTN_EliminarServicio_Click;
            // 
            // BTN_AgregarServicio
            // 
            BTN_AgregarServicio.Location = new Point(444, 563);
            BTN_AgregarServicio.Name = "BTN_AgregarServicio";
            BTN_AgregarServicio.Size = new Size(75, 23);
            BTN_AgregarServicio.TabIndex = 112;
            BTN_AgregarServicio.Text = "Agregar";
            BTN_AgregarServicio.UseVisualStyleBackColor = true;
            BTN_AgregarServicio.Click += BTN_AgregarServicio_Click;
            // 
            // TB_RegServAdHPr
            // 
            TB_RegServAdHPr.Location = new Point(316, 563);
            TB_RegServAdHPr.Name = "TB_RegServAdHPr";
            TB_RegServAdHPr.Size = new Size(100, 23);
            TB_RegServAdHPr.TabIndex = 111;
            TB_RegServAdHPr.KeyDown += TB_RegServAdHPr_KeyDown;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(265, 566);
            label18.Name = "label18";
            label18.Size = new Size(40, 15);
            label18.TabIndex = 110;
            label18.Text = "Precio";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(58, 567);
            label12.Name = "label12";
            label12.Size = new Size(51, 15);
            label12.TabIndex = 109;
            label12.Text = "Nombre";
            // 
            // ChB_RegFrentePlayaH
            // 
            ChB_RegFrentePlayaH.AutoSize = true;
            ChB_RegFrentePlayaH.Location = new Point(141, 718);
            ChB_RegFrentePlayaH.Name = "ChB_RegFrentePlayaH";
            ChB_RegFrentePlayaH.Size = new Size(15, 14);
            ChB_RegFrentePlayaH.TabIndex = 108;
            ChB_RegFrentePlayaH.UseVisualStyleBackColor = true;
            // 
            // ChB_RegZTH
            // 
            ChB_RegZTH.AutoSize = true;
            ChB_RegZTH.Location = new Point(140, 331);
            ChB_RegZTH.Name = "ChB_RegZTH";
            ChB_RegZTH.Size = new Size(15, 14);
            ChB_RegZTH.TabIndex = 107;
            ChB_RegZTH.UseVisualStyleBackColor = true;
            // 
            // RB_SEventNo
            // 
            RB_SEventNo.AutoSize = true;
            RB_SEventNo.Location = new Point(224, 749);
            RB_SEventNo.Name = "RB_SEventNo";
            RB_SEventNo.Size = new Size(41, 19);
            RB_SEventNo.TabIndex = 106;
            RB_SEventNo.TabStop = true;
            RB_SEventNo.Text = "No";
            RB_SEventNo.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(59, 752);
            label19.Name = "label19";
            label19.Size = new Size(96, 15);
            label19.TabIndex = 105;
            label19.Text = "Salón de eventos";
            // 
            // RB_SEventSi
            // 
            RB_SEventSi.AutoSize = true;
            RB_SEventSi.Location = new Point(160, 749);
            RB_SEventSi.Name = "RB_SEventSi";
            RB_SEventSi.Size = new Size(34, 19);
            RB_SEventSi.TabIndex = 104;
            RB_SEventSi.TabStop = true;
            RB_SEventSi.Text = "Sí";
            RB_SEventSi.UseVisualStyleBackColor = true;
            // 
            // TB_RegChabH
            // 
            TB_RegChabH.Location = new Point(420, 287);
            TB_RegChabH.Name = "TB_RegChabH";
            TB_RegChabH.Size = new Size(96, 23);
            TB_RegChabH.TabIndex = 103;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(265, 290);
            label20.Name = "label20";
            label20.Size = new Size(144, 15);
            label20.TabIndex = 102;
            label20.Text = "Cantidad de habitaciones:";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(316, 362);
            label21.Name = "label21";
            label21.Size = new Size(76, 15);
            label21.TabIndex = 101;
            label21.Text = "Amenidades:";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(59, 362);
            label22.Name = "label22";
            label22.Size = new Size(86, 15);
            label22.TabIndex = 100;
            label22.Text = "Características:";
            // 
            // button1
            // 
            button1.BackColor = Color.Thistle;
            button1.Location = new Point(278, 774);
            button1.Name = "button1";
            button1.Size = new Size(85, 23);
            button1.TabIndex = 99;
            button1.Text = "Actualizar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // DTP_RegHotel
            // 
            DTP_RegHotel.Location = new Point(308, 91);
            DTP_RegHotel.Name = "DTP_RegHotel";
            DTP_RegHotel.Size = new Size(239, 23);
            DTP_RegHotel.TabIndex = 98;
            // 
            // TB_RegCantPisH
            // 
            TB_RegCantPisH.Location = new Point(317, 711);
            TB_RegCantPisH.Name = "TB_RegCantPisH";
            TB_RegCantPisH.Size = new Size(84, 23);
            TB_RegCantPisH.TabIndex = 97;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(190, 718);
            label23.Name = "label23";
            label23.Size = new Size(116, 15);
            label23.TabIndex = 96;
            label23.Text = "Cantidad de piscinas";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(59, 716);
            label24.Name = "label24";
            label24.Size = new Size(80, 15);
            label24.TabIndex = 95;
            label24.Text = "Frente a playa";
            // 
            // TB_RegServAdH
            // 
            TB_RegServAdH.Location = new Point(117, 563);
            TB_RegServAdH.Name = "TB_RegServAdH";
            TB_RegServAdH.Size = new Size(114, 23);
            TB_RegServAdH.TabIndex = 94;
            TB_RegServAdH.KeyDown += TB_RegServAdH_KeyDown;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(245, 538);
            label25.Name = "label25";
            label25.Size = new Size(118, 15);
            label25.TabIndex = 93;
            label25.Text = "Servicios adicionales:";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new Point(58, 330);
            label26.Name = "label26";
            label26.Size = new Size(79, 15);
            label26.TabIndex = 92;
            label26.Text = "Zona turística";
            // 
            // TB_RegNumPH
            // 
            TB_RegNumPH.Location = new Point(167, 287);
            TB_RegNumPH.Name = "TB_RegNumPH";
            TB_RegNumPH.Size = new Size(75, 23);
            TB_RegNumPH.TabIndex = 91;
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new Point(58, 290);
            label27.Name = "label27";
            label27.Size = new Size(100, 15);
            label27.TabIndex = 90;
            label27.Text = "Número de pisos:";
            // 
            // TB_RegDomH
            // 
            TB_RegDomH.Location = new Point(132, 250);
            TB_RegDomH.Name = "TB_RegDomH";
            TB_RegDomH.Size = new Size(412, 23);
            TB_RegDomH.TabIndex = 89;
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new Point(58, 250);
            label28.Name = "label28";
            label28.Size = new Size(61, 15);
            label28.TabIndex = 88;
            label28.Text = "Domicilio:";
            // 
            // TB_RegPaisH
            // 
            TB_RegPaisH.Location = new Point(167, 210);
            TB_RegPaisH.Name = "TB_RegPaisH";
            TB_RegPaisH.Size = new Size(102, 23);
            TB_RegPaisH.TabIndex = 87;
            // 
            // TB_RegEstH
            // 
            TB_RegEstH.Location = new Point(307, 210);
            TB_RegEstH.Name = "TB_RegEstH";
            TB_RegEstH.Size = new Size(102, 23);
            TB_RegEstH.TabIndex = 86;
            // 
            // TB_RegCuH
            // 
            TB_RegCuH.Location = new Point(444, 210);
            TB_RegCuH.Name = "TB_RegCuH";
            TB_RegCuH.Size = new Size(102, 23);
            TB_RegCuH.TabIndex = 85;
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Location = new Point(338, 192);
            label29.Name = "label29";
            label29.Size = new Size(42, 15);
            label29.TabIndex = 84;
            label29.Text = "Estado";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Location = new Point(473, 192);
            label30.Name = "label30";
            label30.Size = new Size(45, 15);
            label30.TabIndex = 83;
            label30.Text = "Ciudad";
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Location = new Point(203, 192);
            label31.Name = "label31";
            label31.Size = new Size(28, 15);
            label31.TabIndex = 82;
            label31.Text = "País";
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Location = new Point(58, 210);
            label32.Name = "label32";
            label32.Size = new Size(63, 15);
            label32.TabIndex = 81;
            label32.Text = "Ubicación:";
            // 
            // TB_RegNomH
            // 
            TB_RegNomH.Location = new Point(168, 148);
            TB_RegNomH.Name = "TB_RegNomH";
            TB_RegNomH.Size = new Size(289, 23);
            TB_RegNomH.TabIndex = 80;
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Location = new Point(59, 151);
            label33.Name = "label33";
            label33.Size = new Size(103, 15);
            label33.TabIndex = 79;
            label33.Text = "Nombre del hotel:";
            // 
            // Informacion_Hotel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(614, 815);
            Controls.Add(TB_RegAm);
            Controls.Add(TB_RegChar);
            Controls.Add(BTN_EliminarAm);
            Controls.Add(BTN_AgregarAm);
            Controls.Add(BTN_EliminarChar);
            Controls.Add(BTN_AgregarChar);
            Controls.Add(LV_MostrarAm);
            Controls.Add(LV_MostrarChar);
            Controls.Add(LV_ServiciosAgregados);
            Controls.Add(BTN_EliminarServicio);
            Controls.Add(BTN_AgregarServicio);
            Controls.Add(TB_RegServAdHPr);
            Controls.Add(label18);
            Controls.Add(label12);
            Controls.Add(ChB_RegFrentePlayaH);
            Controls.Add(ChB_RegZTH);
            Controls.Add(RB_SEventNo);
            Controls.Add(label19);
            Controls.Add(RB_SEventSi);
            Controls.Add(TB_RegChabH);
            Controls.Add(label20);
            Controls.Add(label21);
            Controls.Add(label22);
            Controls.Add(button1);
            Controls.Add(DTP_RegHotel);
            Controls.Add(TB_RegCantPisH);
            Controls.Add(label23);
            Controls.Add(label24);
            Controls.Add(TB_RegServAdH);
            Controls.Add(label25);
            Controls.Add(label26);
            Controls.Add(TB_RegNumPH);
            Controls.Add(label27);
            Controls.Add(TB_RegDomH);
            Controls.Add(label28);
            Controls.Add(TB_RegPaisH);
            Controls.Add(TB_RegEstH);
            Controls.Add(TB_RegCuH);
            Controls.Add(label29);
            Controls.Add(label30);
            Controls.Add(label31);
            Controls.Add(label32);
            Controls.Add(TB_RegNomH);
            Controls.Add(label33);
            Controls.Add(label11);
            Name = "Informacion_Hotel";
            Text = "Informacion_Hotel";
            Load += Informacion_Hotel_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label11;
        private TextBox TB_RegAm;
        private TextBox TB_RegChar;
        private Button BTN_EliminarAm;
        private Button BTN_AgregarAm;
        private Button BTN_EliminarChar;
        private Button BTN_AgregarChar;
        private ListView LV_MostrarAm;
        private ListView LV_MostrarChar;
        private ListView LV_ServiciosAgregados;
        private Button BTN_EliminarServicio;
        private Button BTN_AgregarServicio;
        private TextBox TB_RegServAdHPr;
        private Label label18;
        private Label label12;
        private CheckBox ChB_RegFrentePlayaH;
        private CheckBox ChB_RegZTH;
        private RadioButton RB_SEventNo;
        private Label label19;
        private RadioButton RB_SEventSi;
        private TextBox TB_RegChabH;
        private Label label20;
        private Label label21;
        private Label label22;
        private Button button1;
        private DateTimePicker DTP_RegHotel;
        private TextBox TB_RegCantPisH;
        private Label label23;
        private Label label24;
        private TextBox TB_RegServAdH;
        private Label label25;
        private Label label26;
        private TextBox TB_RegNumPH;
        private Label label27;
        private TextBox TB_RegDomH;
        private Label label28;
        private TextBox TB_RegPaisH;
        private TextBox TB_RegEstH;
        private TextBox TB_RegCuH;
        private Label label29;
        private Label label30;
        private Label label31;
        private Label label32;
        private TextBox TB_RegNomH;
        private Label label33;
    }
}