namespace PIA_MAD
{
    partial class Reservaciones
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
            DTP_FechaEntrada = new DateTimePicker();
            DTP_FechaSalida = new DateTimePicker();
            TB_BusquedaCliente = new TextBox();
            BTN_BusquedaClientes = new Button();
            label1 = new Label();
            TB_BusquedaHoteles = new TextBox();
            LB_MostrarHoteles = new ListBox();
            label3 = new Label();
            TB_CantidadPersonas = new TextBox();
            LBL_CantidadPersonas = new Label();
            TB_Anticipo = new TextBox();
            LBL_Anticipo = new Label();
            DTP_FechaReservacion = new DateTimePicker();
            BTN_Reservar = new Button();
            BTN_BusquedaHoteles = new Button();
            BTN_AgregarHabitacion = new Button();
            label2 = new Label();
            label6 = new Label();
            LB_MostrarHabitaciones = new ListBox();
            RTB_MostrarAMHoteles = new RichTextBox();
            RTB_MostrarAMHabitaciones = new RichTextBox();
            LBL_MaxCapHab = new Label();
            LB_HabSeleccionadas = new ListBox();
            BTN_EliminarHab = new Button();
            LV_MostrarCliente = new ListView();
            CB_SeleccionNivelHab = new ComboBox();
            BTN_BuscarHabitaciones = new Button();
            SuspendLayout();
            // 
            // DTP_FechaEntrada
            // 
            DTP_FechaEntrada.Location = new Point(131, 511);
            DTP_FechaEntrada.Name = "DTP_FechaEntrada";
            DTP_FechaEntrada.Size = new Size(227, 23);
            DTP_FechaEntrada.TabIndex = 0;
            DTP_FechaEntrada.ValueChanged += DTP_FechaEntrada_ValueChanged;
            // 
            // DTP_FechaSalida
            // 
            DTP_FechaSalida.Location = new Point(389, 511);
            DTP_FechaSalida.Name = "DTP_FechaSalida";
            DTP_FechaSalida.Size = new Size(227, 23);
            DTP_FechaSalida.TabIndex = 1;
            DTP_FechaSalida.ValueChanged += DTP_FechaSalida_ValueChanged;
            // 
            // TB_BusquedaCliente
            // 
            TB_BusquedaCliente.Location = new Point(288, 103);
            TB_BusquedaCliente.Name = "TB_BusquedaCliente";
            TB_BusquedaCliente.Size = new Size(289, 23);
            TB_BusquedaCliente.TabIndex = 3;
            // 
            // BTN_BusquedaClientes
            // 
            BTN_BusquedaClientes.Location = new Point(588, 104);
            BTN_BusquedaClientes.Name = "BTN_BusquedaClientes";
            BTN_BusquedaClientes.Size = new Size(75, 23);
            BTN_BusquedaClientes.TabIndex = 4;
            BTN_BusquedaClientes.Text = "Buscar";
            BTN_BusquedaClientes.UseVisualStyleBackColor = true;
            BTN_BusquedaClientes.Click += BTN_BusquedaClientes_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(238, 309);
            label1.Name = "label1";
            label1.Size = new Size(48, 15);
            label1.TabIndex = 7;
            label1.Text = "Ciudad:";
            // 
            // TB_BusquedaHoteles
            // 
            TB_BusquedaHoteles.Location = new Point(287, 306);
            TB_BusquedaHoteles.Name = "TB_BusquedaHoteles";
            TB_BusquedaHoteles.Size = new Size(289, 23);
            TB_BusquedaHoteles.TabIndex = 8;
            // 
            // LB_MostrarHoteles
            // 
            LB_MostrarHoteles.FormattingEnabled = true;
            LB_MostrarHoteles.ItemHeight = 15;
            LB_MostrarHoteles.Location = new Point(131, 342);
            LB_MostrarHoteles.Name = "LB_MostrarHoteles";
            LB_MostrarHoteles.Size = new Size(318, 109);
            LB_MostrarHoteles.TabIndex = 9;
            LB_MostrarHoteles.SelectedIndexChanged += LB_MostrarHoteles_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(37, 554);
            label3.Name = "label3";
            label3.Size = new Size(71, 15);
            label3.TabIndex = 14;
            label3.Text = " Habitación:";
            // 
            // TB_CantidadPersonas
            // 
            TB_CantidadPersonas.Location = new Point(279, 662);
            TB_CantidadPersonas.Name = "TB_CantidadPersonas";
            TB_CantidadPersonas.Size = new Size(94, 23);
            TB_CantidadPersonas.TabIndex = 17;
            TB_CantidadPersonas.TextChanged += TB_CantidadPersonas_TextChanged;
            // 
            // LBL_CantidadPersonas
            // 
            LBL_CantidadPersonas.AutoSize = true;
            LBL_CantidadPersonas.Location = new Point(131, 665);
            LBL_CantidadPersonas.Name = "LBL_CantidadPersonas";
            LBL_CantidadPersonas.Size = new Size(124, 15);
            LBL_CantidadPersonas.TabIndex = 16;
            LBL_CantidadPersonas.Text = "Cantidad de personas:";
            // 
            // TB_Anticipo
            // 
            TB_Anticipo.Location = new Point(211, 754);
            TB_Anticipo.Name = "TB_Anticipo";
            TB_Anticipo.Size = new Size(91, 23);
            TB_Anticipo.TabIndex = 19;
            TB_Anticipo.TextChanged += TB_Anticipo_TextChanged;
            TB_Anticipo.KeyDown += TB_Anticipo_KeyDown;
            // 
            // LBL_Anticipo
            // 
            LBL_Anticipo.AutoSize = true;
            LBL_Anticipo.Location = new Point(131, 757);
            LBL_Anticipo.Name = "LBL_Anticipo";
            LBL_Anticipo.Size = new Size(55, 15);
            LBL_Anticipo.TabIndex = 18;
            LBL_Anticipo.Text = "Anticipo:";
            // 
            // DTP_FechaReservacion
            // 
            DTP_FechaReservacion.Location = new Point(328, 61);
            DTP_FechaReservacion.Name = "DTP_FechaReservacion";
            DTP_FechaReservacion.Size = new Size(227, 23);
            DTP_FechaReservacion.TabIndex = 20;
            // 
            // BTN_Reservar
            // 
            BTN_Reservar.Location = new Point(384, 808);
            BTN_Reservar.Name = "BTN_Reservar";
            BTN_Reservar.Size = new Size(75, 23);
            BTN_Reservar.TabIndex = 21;
            BTN_Reservar.Text = "Reservar";
            BTN_Reservar.UseVisualStyleBackColor = true;
            BTN_Reservar.Click += BTN_Reservar_Click;
            // 
            // BTN_BusquedaHoteles
            // 
            BTN_BusquedaHoteles.Location = new Point(587, 305);
            BTN_BusquedaHoteles.Name = "BTN_BusquedaHoteles";
            BTN_BusquedaHoteles.Size = new Size(75, 23);
            BTN_BusquedaHoteles.TabIndex = 22;
            BTN_BusquedaHoteles.Text = "Buscar";
            BTN_BusquedaHoteles.UseVisualStyleBackColor = true;
            BTN_BusquedaHoteles.Click += BTN_BusquedaHoteles_Click;
            // 
            // BTN_AgregarHabitacion
            // 
            BTN_AgregarHabitacion.Location = new Point(211, 706);
            BTN_AgregarHabitacion.Name = "BTN_AgregarHabitacion";
            BTN_AgregarHabitacion.Size = new Size(186, 23);
            BTN_AgregarHabitacion.TabIndex = 24;
            BTN_AgregarHabitacion.Text = "Agregar Habitacion";
            BTN_AgregarHabitacion.UseVisualStyleBackColor = true;
            BTN_AgregarHabitacion.Click += BTN_AgregarHabitacion_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(239, 106);
            label2.Name = "label2";
            label2.Size = new Size(46, 15);
            label2.TabIndex = 25;
            label2.Text = "Correo:";
            label2.Click += label2_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(400, 32);
            label6.Name = "label6";
            label6.Size = new Size(97, 15);
            label6.TabIndex = 26;
            label6.Text = "Fecha de registro";
            // 
            // LB_MostrarHabitaciones
            // 
            LB_MostrarHabitaciones.FormattingEnabled = true;
            LB_MostrarHabitaciones.ItemHeight = 15;
            LB_MostrarHabitaciones.Location = new Point(131, 554);
            LB_MostrarHabitaciones.Name = "LB_MostrarHabitaciones";
            LB_MostrarHabitaciones.Size = new Size(318, 94);
            LB_MostrarHabitaciones.TabIndex = 27;
            LB_MostrarHabitaciones.SelectedIndexChanged += LB_MostrarHabitaciones_SelectedIndexChanged;
            // 
            // RTB_MostrarAMHoteles
            // 
            RTB_MostrarAMHoteles.Location = new Point(473, 342);
            RTB_MostrarAMHoteles.Name = "RTB_MostrarAMHoteles";
            RTB_MostrarAMHoteles.Size = new Size(270, 110);
            RTB_MostrarAMHoteles.TabIndex = 30;
            RTB_MostrarAMHoteles.Text = "";
            // 
            // RTB_MostrarAMHabitaciones
            // 
            RTB_MostrarAMHabitaciones.Location = new Point(473, 554);
            RTB_MostrarAMHabitaciones.Name = "RTB_MostrarAMHabitaciones";
            RTB_MostrarAMHabitaciones.Size = new Size(270, 94);
            RTB_MostrarAMHabitaciones.TabIndex = 31;
            RTB_MostrarAMHabitaciones.Text = "";
            RTB_MostrarAMHabitaciones.TextChanged += RTB_MostrarAMHabitaciones_TextChanged;
            // 
            // LBL_MaxCapHab
            // 
            LBL_MaxCapHab.AutoSize = true;
            LBL_MaxCapHab.Location = new Point(397, 665);
            LBL_MaxCapHab.Name = "LBL_MaxCapHab";
            LBL_MaxCapHab.Size = new Size(0, 15);
            LBL_MaxCapHab.TabIndex = 32;
            // 
            // LB_HabSeleccionadas
            // 
            LB_HabSeleccionadas.FormattingEnabled = true;
            LB_HabSeleccionadas.ItemHeight = 15;
            LB_HabSeleccionadas.Location = new Point(473, 665);
            LB_HabSeleccionadas.Name = "LB_HabSeleccionadas";
            LB_HabSeleccionadas.Size = new Size(270, 94);
            LB_HabSeleccionadas.TabIndex = 33;
            LB_HabSeleccionadas.SelectedIndexChanged += LB_HabSeleccionadas_SelectedIndexChanged;
            // 
            // BTN_EliminarHab
            // 
            BTN_EliminarHab.Location = new Point(540, 775);
            BTN_EliminarHab.Name = "BTN_EliminarHab";
            BTN_EliminarHab.Size = new Size(130, 23);
            BTN_EliminarHab.TabIndex = 34;
            BTN_EliminarHab.Text = "Eliminar Habitacion";
            BTN_EliminarHab.UseVisualStyleBackColor = true;
            BTN_EliminarHab.Click += BTN_EliminarHab_Click;
            // 
            // LV_MostrarCliente
            // 
            LV_MostrarCliente.Location = new Point(131, 132);
            LV_MostrarCliente.Name = "LV_MostrarCliente";
            LV_MostrarCliente.Size = new Size(612, 154);
            LV_MostrarCliente.TabIndex = 35;
            LV_MostrarCliente.UseCompatibleStateImageBehavior = false;
            LV_MostrarCliente.SelectedIndexChanged += LV_MostrarCliente_SelectedIndexChanged;
            // 
            // CB_SeleccionNivelHab
            // 
            CB_SeleccionNivelHab.FormattingEnabled = true;
            CB_SeleccionNivelHab.Location = new Point(315, 473);
            CB_SeleccionNivelHab.Name = "CB_SeleccionNivelHab";
            CB_SeleccionNivelHab.Size = new Size(121, 23);
            CB_SeleccionNivelHab.TabIndex = 36;
            CB_SeleccionNivelHab.SelectedIndexChanged += CB_SeleccionNivelHab_SelectedIndexChanged;
            // 
            // BTN_BuscarHabitaciones
            // 
            BTN_BuscarHabitaciones.Location = new Point(651, 511);
            BTN_BuscarHabitaciones.Name = "BTN_BuscarHabitaciones";
            BTN_BuscarHabitaciones.Size = new Size(75, 23);
            BTN_BuscarHabitaciones.TabIndex = 37;
            BTN_BuscarHabitaciones.Text = "Buscar";
            BTN_BuscarHabitaciones.UseVisualStyleBackColor = true;
            BTN_BuscarHabitaciones.Click += BTN_BuscarHabitaciones_Click;
            // 
            // Reservaciones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(874, 837);
            Controls.Add(BTN_BuscarHabitaciones);
            Controls.Add(CB_SeleccionNivelHab);
            Controls.Add(LV_MostrarCliente);
            Controls.Add(BTN_EliminarHab);
            Controls.Add(LB_HabSeleccionadas);
            Controls.Add(LBL_MaxCapHab);
            Controls.Add(RTB_MostrarAMHabitaciones);
            Controls.Add(RTB_MostrarAMHoteles);
            Controls.Add(LB_MostrarHabitaciones);
            Controls.Add(label6);
            Controls.Add(label2);
            Controls.Add(BTN_AgregarHabitacion);
            Controls.Add(BTN_BusquedaHoteles);
            Controls.Add(BTN_Reservar);
            Controls.Add(DTP_FechaReservacion);
            Controls.Add(TB_Anticipo);
            Controls.Add(LBL_Anticipo);
            Controls.Add(TB_CantidadPersonas);
            Controls.Add(LBL_CantidadPersonas);
            Controls.Add(label3);
            Controls.Add(LB_MostrarHoteles);
            Controls.Add(TB_BusquedaHoteles);
            Controls.Add(label1);
            Controls.Add(BTN_BusquedaClientes);
            Controls.Add(TB_BusquedaCliente);
            Controls.Add(DTP_FechaSalida);
            Controls.Add(DTP_FechaEntrada);
            Name = "Reservaciones";
            Text = "Reservaciones";
            Load += Reservaciones_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker DTP_FechaEntrada;
        private DateTimePicker DTP_FechaSalida;
        private TextBox TB_BusquedaCliente;
        private Button BTN_BusquedaClientes;
        private Label label1;
        private TextBox TB_BusquedaHoteles;
        private ListBox LB_MostrarHoteles;
        private Label label3;
        private TextBox TB_CantidadPersonas;
        private Label LBL_CantidadPersonas;
        private TextBox TB_Anticipo;
        private Label LBL_Anticipo;
        private DateTimePicker DTP_FechaReservacion;
        private Button BTN_Reservar;
        private Button BTN_BusquedaHoteles;
        private Button BTN_AgregarHabitacion;
        private Label label2;
        private MenuSuperior menuSuperior1;
        private Label label6;
        private ListBox LB_MostrarHabitaciones;
        private RichTextBox RTB_MostrarAMHoteles;
        private RichTextBox RTB_MostrarAMHabitaciones;
        private Label LBL_MaxCapHab;
        private ListBox LB_HabSeleccionadas;
        private Button BTN_EliminarHab;
        private ListView LV_MostrarCliente;
        private ComboBox CB_SeleccionNivelHab;
        private Button BTN_BuscarHabitaciones;
    }
}