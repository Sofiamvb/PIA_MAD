namespace PIA_MAD
{
    partial class Historial_del_cliente
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
            TB_Busqueda = new TextBox();
            BTN_Busqueda = new Button();
            label2 = new Label();
            BTN_Filtrar = new Button();
            CB_Anio = new ComboBox();
            LV_Clientes = new ListView();
            LV_Historial = new ListView();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(252, 63);
            label1.Name = "label1";
            label1.Size = new Size(82, 15);
            label1.TabIndex = 0;
            label1.Text = "Dato a buscar:";
            // 
            // TB_Busqueda
            // 
            TB_Busqueda.Location = new Point(342, 60);
            TB_Busqueda.Name = "TB_Busqueda";
            TB_Busqueda.Size = new Size(532, 23);
            TB_Busqueda.TabIndex = 1;
            TB_Busqueda.TextChanged += TB_Busqueda_TextChanged;
            // 
            // BTN_Busqueda
            // 
            BTN_Busqueda.Location = new Point(899, 60);
            BTN_Busqueda.Name = "BTN_Busqueda";
            BTN_Busqueda.Size = new Size(72, 24);
            BTN_Busqueda.TabIndex = 2;
            BTN_Busqueda.Text = "Buscar";
            BTN_Busqueda.UseVisualStyleBackColor = true;
            BTN_Busqueda.Click += BTN_Busqueda_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(500, 267);
            label2.Name = "label2";
            label2.Size = new Size(32, 15);
            label2.TabIndex = 4;
            label2.Text = "Año:";
            // 
            // BTN_Filtrar
            // 
            BTN_Filtrar.Location = new Point(689, 264);
            BTN_Filtrar.Name = "BTN_Filtrar";
            BTN_Filtrar.Size = new Size(72, 24);
            BTN_Filtrar.TabIndex = 6;
            BTN_Filtrar.Text = "Filtrar";
            BTN_Filtrar.UseVisualStyleBackColor = true;
            BTN_Filtrar.Click += BTN_Filtrar_Click;
            // 
            // CB_Anio
            // 
            CB_Anio.FormattingEnabled = true;
            CB_Anio.Location = new Point(538, 264);
            CB_Anio.Name = "CB_Anio";
            CB_Anio.Size = new Size(114, 23);
            CB_Anio.TabIndex = 7;
            CB_Anio.SelectedIndexChanged += CB_Anio_SelectedIndexChanged;
            // 
            // LV_Clientes
            // 
            LV_Clientes.Location = new Point(256, 104);
            LV_Clientes.MultiSelect = false;
            LV_Clientes.Name = "LV_Clientes";
            LV_Clientes.Size = new Size(715, 97);
            LV_Clientes.TabIndex = 9;
            LV_Clientes.UseCompatibleStateImageBehavior = false;
            LV_Clientes.SelectedIndexChanged += LV_Clientes_SelectedIndexChanged;
            // 
            // LV_Historial
            // 
            LV_Historial.Location = new Point(27, 316);
            LV_Historial.Name = "LV_Historial";
            LV_Historial.Size = new Size(1183, 230);
            LV_Historial.TabIndex = 10;
            LV_Historial.UseCompatibleStateImageBehavior = false;
            // 
            // Historial_del_cliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1254, 574);
            Controls.Add(LV_Historial);
            Controls.Add(LV_Clientes);
            Controls.Add(CB_Anio);
            Controls.Add(BTN_Filtrar);
            Controls.Add(label2);
            Controls.Add(BTN_Busqueda);
            Controls.Add(TB_Busqueda);
            Controls.Add(label1);
            Name = "Historial_del_cliente";
            Text = "Historial del cliente";
            Load += Historial_del_cliente_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox TB_Busqueda;
        private Button BTN_Busqueda;
        private Label label2;
        private Button BTN_Filtrar;
        private ComboBox CB_Anio;
        private ListView LV_Clientes;
        private ListView LV_Historial;
    }
}