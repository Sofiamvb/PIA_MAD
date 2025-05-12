namespace PIA_MAD
{
    partial class Check_Out
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
            DTP_CheckOut = new DateTimePicker();
            TB_NumReserva = new TextBox();
            label3 = new Label();
            RB_DescuentoSi = new RadioButton();
            label4 = new Label();
            label5 = new Label();
            RB_DescuentoNo = new RadioButton();
            TB_CantDescuento = new TextBox();
            label6 = new Label();
            TB_MontoTotal = new TextBox();
            label7 = new Label();
            TB_AnticipoCO = new TextBox();
            BTN_CheckOut = new Button();
            label10 = new Label();
            LV_ServiciosAgregados = new ListView();
            BTN_AgregarServicio = new Button();
            BTN_EliminarServicio = new Button();
            LV_ServiciosAdicionales = new ListView();
            CB_FormaDePago = new ComboBox();
            FormaDePago = new Label();
            CB_MetodoDePago = new ComboBox();
            CB_MetodoPago = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 90);
            label1.Name = "label1";
            label1.Size = new Size(133, 15);
            label1.TabIndex = 0;
            label1.Text = "Número de reservación:";
            // 
            // DTP_CheckOut
            // 
            DTP_CheckOut.Location = new Point(32, 40);
            DTP_CheckOut.Name = "DTP_CheckOut";
            DTP_CheckOut.Size = new Size(230, 23);
            DTP_CheckOut.TabIndex = 1;
            // 
            // TB_NumReserva
            // 
            TB_NumReserva.Location = new Point(171, 87);
            TB_NumReserva.Name = "TB_NumReserva";
            TB_NumReserva.Size = new Size(251, 23);
            TB_NumReserva.TabIndex = 2;
            TB_NumReserva.KeyDown += TB_NumReserva_KeyDown;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 125);
            label3.Name = "label3";
            label3.Size = new Size(66, 15);
            label3.TabIndex = 5;
            label3.Text = "Descuento:";
            // 
            // RB_DescuentoSi
            // 
            RB_DescuentoSi.AutoSize = true;
            RB_DescuentoSi.Location = new Point(151, 127);
            RB_DescuentoSi.Name = "RB_DescuentoSi";
            RB_DescuentoSi.Size = new Size(14, 13);
            RB_DescuentoSi.TabIndex = 6;
            RB_DescuentoSi.TabStop = true;
            RB_DescuentoSi.UseVisualStyleBackColor = true;
            RB_DescuentoSi.CheckedChanged += RB_DescuentoSi_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(126, 127);
            label4.Name = "label4";
            label4.Size = new Size(16, 15);
            label4.TabIndex = 7;
            label4.Text = "Si";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(283, 127);
            label5.Name = "label5";
            label5.Size = new Size(23, 15);
            label5.TabIndex = 8;
            label5.Text = "No";
            // 
            // RB_DescuentoNo
            // 
            RB_DescuentoNo.AutoSize = true;
            RB_DescuentoNo.Location = new Point(312, 129);
            RB_DescuentoNo.Name = "RB_DescuentoNo";
            RB_DescuentoNo.Size = new Size(14, 13);
            RB_DescuentoNo.TabIndex = 9;
            RB_DescuentoNo.TabStop = true;
            RB_DescuentoNo.UseVisualStyleBackColor = true;
            // 
            // TB_CantDescuento
            // 
            TB_CantDescuento.Location = new Point(173, 122);
            TB_CantDescuento.Name = "TB_CantDescuento";
            TB_CantDescuento.Size = new Size(89, 23);
            TB_CantDescuento.TabIndex = 10;
            TB_CantDescuento.KeyDown += TB_CantDescuento_KeyDown;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(32, 387);
            label6.Name = "label6";
            label6.Size = new Size(73, 15);
            label6.TabIndex = 11;
            label6.Text = "Monto total:";
            // 
            // TB_MontoTotal
            // 
            TB_MontoTotal.Location = new Point(112, 384);
            TB_MontoTotal.Name = "TB_MontoTotal";
            TB_MontoTotal.Size = new Size(89, 23);
            TB_MontoTotal.TabIndex = 12;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(32, 160);
            label7.Name = "label7";
            label7.Size = new Size(55, 15);
            label7.TabIndex = 13;
            label7.Text = "Anticipo:";
            // 
            // TB_AnticipoCO
            // 
            TB_AnticipoCO.Location = new Point(93, 157);
            TB_AnticipoCO.Name = "TB_AnticipoCO";
            TB_AnticipoCO.Size = new Size(89, 23);
            TB_AnticipoCO.TabIndex = 14;
            // 
            // BTN_CheckOut
            // 
            BTN_CheckOut.Location = new Point(467, 622);
            BTN_CheckOut.Name = "BTN_CheckOut";
            BTN_CheckOut.Size = new Size(75, 23);
            BTN_CheckOut.TabIndex = 19;
            BTN_CheckOut.Text = "Check Out";
            BTN_CheckOut.UseVisualStyleBackColor = true;
            BTN_CheckOut.Click += BTN_CheckOut_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(32, 200);
            label10.Name = "label10";
            label10.Size = new Size(56, 15);
            label10.TabIndex = 21;
            label10.Text = "Servicios:";
            label10.Click += label10_Click;
            // 
            // LV_ServiciosAgregados
            // 
            LV_ServiciosAgregados.Location = new Point(349, 230);
            LV_ServiciosAgregados.Name = "LV_ServiciosAgregados";
            LV_ServiciosAgregados.Size = new Size(264, 109);
            LV_ServiciosAgregados.TabIndex = 23;
            LV_ServiciosAgregados.UseCompatibleStateImageBehavior = false;
            LV_ServiciosAgregados.SelectedIndexChanged += LV_ServiciosAgregados_SelectedIndexChanged;
            // 
            // BTN_AgregarServicio
            // 
            BTN_AgregarServicio.Location = new Point(93, 345);
            BTN_AgregarServicio.Name = "BTN_AgregarServicio";
            BTN_AgregarServicio.Size = new Size(108, 23);
            BTN_AgregarServicio.TabIndex = 24;
            BTN_AgregarServicio.Text = "Agregar servicio";
            BTN_AgregarServicio.UseVisualStyleBackColor = true;
            BTN_AgregarServicio.Click += BTN_AgregarServicio_Click;
            // 
            // BTN_EliminarServicio
            // 
            BTN_EliminarServicio.Location = new Point(421, 345);
            BTN_EliminarServicio.Name = "BTN_EliminarServicio";
            BTN_EliminarServicio.Size = new Size(110, 23);
            BTN_EliminarServicio.TabIndex = 25;
            BTN_EliminarServicio.Text = "Eliminar Servicio";
            BTN_EliminarServicio.UseVisualStyleBackColor = true;
            BTN_EliminarServicio.Click += BTN_EliminarServicio_Click;
            // 
            // LV_ServiciosAdicionales
            // 
            LV_ServiciosAdicionales.Location = new Point(32, 230);
            LV_ServiciosAdicionales.Name = "LV_ServiciosAdicionales";
            LV_ServiciosAdicionales.Size = new Size(294, 109);
            LV_ServiciosAdicionales.TabIndex = 26;
            LV_ServiciosAdicionales.UseCompatibleStateImageBehavior = false;
            LV_ServiciosAdicionales.SelectedIndexChanged += LV_ServiciosAdicionales_SelectedIndexChanged;
            // 
            // CB_FormaDePago
            // 
            CB_FormaDePago.FormattingEnabled = true;
            CB_FormaDePago.Location = new Point(133, 433);
            CB_FormaDePago.Name = "CB_FormaDePago";
            CB_FormaDePago.Size = new Size(121, 23);
            CB_FormaDePago.TabIndex = 27;
            CB_FormaDePago.SelectedIndexChanged += CB_FormaDePago_SelectedIndexChanged;
            // 
            // FormaDePago
            // 
            FormaDePago.AutoSize = true;
            FormaDePago.Location = new Point(32, 433);
            FormaDePago.Name = "FormaDePago";
            FormaDePago.Size = new Size(87, 15);
            FormaDePago.TabIndex = 28;
            FormaDePago.Text = "Forma de pago";
            // 
            // CB_MetodoDePago
            // 
            CB_MetodoDePago.FormattingEnabled = true;
            CB_MetodoDePago.Location = new Point(384, 433);
            CB_MetodoDePago.Name = "CB_MetodoDePago";
            CB_MetodoDePago.Size = new Size(121, 23);
            CB_MetodoDePago.TabIndex = 29;
            CB_MetodoDePago.SelectedIndexChanged += CB_MetodoDePago_SelectedIndexChanged;
            // 
            // CB_MetodoPago
            // 
            CB_MetodoPago.AutoSize = true;
            CB_MetodoPago.Location = new Point(283, 433);
            CB_MetodoPago.Name = "CB_MetodoPago";
            CB_MetodoPago.Size = new Size(95, 15);
            CB_MetodoPago.TabIndex = 30;
            CB_MetodoPago.Text = "Metodo de pago";
            // 
            // Check_Out
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(625, 657);
            Controls.Add(CB_MetodoPago);
            Controls.Add(CB_MetodoDePago);
            Controls.Add(FormaDePago);
            Controls.Add(CB_FormaDePago);
            Controls.Add(LV_ServiciosAdicionales);
            Controls.Add(BTN_EliminarServicio);
            Controls.Add(BTN_AgregarServicio);
            Controls.Add(LV_ServiciosAgregados);
            Controls.Add(label10);
            Controls.Add(BTN_CheckOut);
            Controls.Add(TB_AnticipoCO);
            Controls.Add(label7);
            Controls.Add(TB_MontoTotal);
            Controls.Add(label6);
            Controls.Add(TB_CantDescuento);
            Controls.Add(RB_DescuentoNo);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(RB_DescuentoSi);
            Controls.Add(label3);
            Controls.Add(TB_NumReserva);
            Controls.Add(DTP_CheckOut);
            Controls.Add(label1);
            Name = "Check_Out";
            Text = "Check Out";
            Load += Check_Out_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DateTimePicker dateTimePicker1;
        private TextBox textBox1;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
        private RadioButton radioButton1;
        private Label label4;
        private Label label5;
        private RadioButton radioButton2;
        private TextBox textBox3;
        private Label label6;
        private TextBox textBox4;
        private Label label7;
        private TextBox textBox5;
        private ListBox listBox2;
        private Label label8;
        private Label label9;
        private Button BTN_AgregarServicio;
        private Button button2;
        private Label label10;
        private TextBox textBox6;
        private MenuSuperior menuSuperior1;
        private TextBox TB_NumReserva;
        private TextBox TB_NumFactura;
        private RadioButton RB_DescuentoSi;
        private RadioButton RB_DescuentoNo;
        private TextBox TB_CantDescuento;
        private TextBox TB_MontoTotal;
        private TextBox TB_AnticipoCO;
        private DateTimePicker DTP_CheckOut;
        private Button BTN_CheckOut;
        private ListView LV_ServiciosAgregados;
        private Button BTN_EliminarServicio;
        private ListView LV_ServiciosAdicionales;
        private ComboBox CB_FormaDePago;
        private Label FormaDePago;
        private ComboBox CB_MetodoDePago;
        private Label CB_MetodoPago;
    }
}