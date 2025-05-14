namespace PIA_MAD
{
    partial class Reporte_de_ventas
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
            BTN_Filtrar = new Button();
            CB_Hoteles = new ComboBox();
            label4 = new Label();
            TB_Ciudad = new TextBox();
            label3 = new Label();
            TB_Anio = new TextBox();
            label2 = new Label();
            TB_Pais = new TextBox();
            label1 = new Label();
            label5 = new Label();
            LV_ReporteVentas = new ListView();
            LBL_IngresosTotales = new Label();
            LBL_IngresosHospedaje = new Label();
            LBL_IngresosServicios = new Label();
            BTN_ObtenerTodo = new Button();
            SuspendLayout();
            // 
            // BTN_Filtrar
            // 
            BTN_Filtrar.Location = new Point(950, 107);
            BTN_Filtrar.Name = "BTN_Filtrar";
            BTN_Filtrar.Size = new Size(75, 23);
            BTN_Filtrar.TabIndex = 17;
            BTN_Filtrar.Text = "Filtrar";
            BTN_Filtrar.UseVisualStyleBackColor = true;
            BTN_Filtrar.Click += BTN_Filtrar_Click;
            // 
            // CB_Hoteles
            // 
            CB_Hoteles.FormattingEnabled = true;
            CB_Hoteles.Location = new Point(886, 64);
            CB_Hoteles.Name = "CB_Hoteles";
            CB_Hoteles.Size = new Size(139, 23);
            CB_Hoteles.TabIndex = 16;
            CB_Hoteles.SelectedIndexChanged += CB_Hoteles_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(841, 67);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 15;
            label4.Text = "Hotel:";
            // 
            // TB_Ciudad
            // 
            TB_Ciudad.Location = new Point(371, 64);
            TB_Ciudad.Name = "TB_Ciudad";
            TB_Ciudad.Size = new Size(130, 23);
            TB_Ciudad.TabIndex = 14;
            TB_Ciudad.TextChanged += TB_Ciudad_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(317, 67);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 13;
            label3.Text = "Ciudad:";
            // 
            // TB_Anio
            // 
            TB_Anio.Location = new Point(624, 64);
            TB_Anio.Name = "TB_Anio";
            TB_Anio.Size = new Size(130, 23);
            TB_Anio.TabIndex = 12;
            TB_Anio.TextChanged += TB_Anio_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(587, 67);
            label2.Name = "label2";
            label2.Size = new Size(32, 15);
            label2.TabIndex = 11;
            label2.Text = "Año:";
            // 
            // TB_Pais
            // 
            TB_Pais.Location = new Point(123, 64);
            TB_Pais.Name = "TB_Pais";
            TB_Pais.Size = new Size(130, 23);
            TB_Pais.TabIndex = 10;
            TB_Pais.TextChanged += TB_Pais_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(86, 67);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 9;
            label1.Text = "País:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(86, 107);
            label5.Name = "label5";
            label5.Size = new Size(51, 15);
            label5.TabIndex = 19;
            label5.Text = "Reporte:";
            // 
            // LV_ReporteVentas
            // 
            LV_ReporteVentas.Location = new Point(86, 147);
            LV_ReporteVentas.Name = "LV_ReporteVentas";
            LV_ReporteVentas.Size = new Size(939, 163);
            LV_ReporteVentas.TabIndex = 20;
            LV_ReporteVentas.UseCompatibleStateImageBehavior = false;
            // 
            // LBL_IngresosTotales
            // 
            LBL_IngresosTotales.AutoSize = true;
            LBL_IngresosTotales.Location = new Point(799, 392);
            LBL_IngresosTotales.Name = "LBL_IngresosTotales";
            LBL_IngresosTotales.Size = new Size(92, 15);
            LBL_IngresosTotales.TabIndex = 21;
            LBL_IngresosTotales.Text = "Ingresos totales:";
            // 
            // LBL_IngresosHospedaje
            // 
            LBL_IngresosHospedaje.AutoSize = true;
            LBL_IngresosHospedaje.Location = new Point(777, 359);
            LBL_IngresosHospedaje.Name = "LBL_IngresosHospedaje";
            LBL_IngresosHospedaje.Size = new Size(113, 15);
            LBL_IngresosHospedaje.TabIndex = 22;
            LBL_IngresosHospedaje.Text = "Ingresos Hospedaje:";
            // 
            // LBL_IngresosServicios
            // 
            LBL_IngresosServicios.AutoSize = true;
            LBL_IngresosServicios.Location = new Point(777, 331);
            LBL_IngresosServicios.Name = "LBL_IngresosServicios";
            LBL_IngresosServicios.Size = new Size(103, 15);
            LBL_IngresosServicios.TabIndex = 23;
            LBL_IngresosServicios.Text = "Ingresos Servicios:";
            // 
            // BTN_ObtenerTodo
            // 
            BTN_ObtenerTodo.Location = new Point(869, 107);
            BTN_ObtenerTodo.Name = "BTN_ObtenerTodo";
            BTN_ObtenerTodo.Size = new Size(75, 23);
            BTN_ObtenerTodo.TabIndex = 24;
            BTN_ObtenerTodo.Text = "Obtener todo";
            BTN_ObtenerTodo.UseVisualStyleBackColor = true;
            BTN_ObtenerTodo.Click += BTN_ObtenerTodo_Click;
            // 
            // Reporte_de_ventas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1105, 437);
            Controls.Add(BTN_ObtenerTodo);
            Controls.Add(LBL_IngresosServicios);
            Controls.Add(LBL_IngresosHospedaje);
            Controls.Add(LBL_IngresosTotales);
            Controls.Add(LV_ReporteVentas);
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
            Name = "Reporte_de_ventas";
            Text = "Reporte de ventas";
            Load += Reporte_de_ventas_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BTN_Filtrar;
        private ComboBox CB_Hoteles;
        private Label label4;
        private TextBox TB_Ciudad;
        private Label label3;
        private TextBox TB_Anio;
        private Label label2;
        private TextBox TB_Pais;
        private Label label1;
        private Label label5;
        private ListView LV_ReporteVentas;
        private Label LBL_IngresosTotales;
        private Label LBL_IngresosHospedaje;
        private Label LBL_IngresosServicios;
        private Button BTN_ObtenerTodo;
    }
}