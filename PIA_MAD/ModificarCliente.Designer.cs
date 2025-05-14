namespace PIA_MAD
{
    partial class ModificarCliente
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
            BTN_VerTodos = new Button();
            LV_Clientes = new ListView();
            label1 = new Label();
            BTN_Modificar = new Button();
            TB_Busqueda = new TextBox();
            BTN_Busqueda = new Button();
            menuSuperior1 = new MenuSuperior();
            SuspendLayout();
            // 
            // BTN_VerTodos
            // 
            BTN_VerTodos.Location = new Point(716, 68);
            BTN_VerTodos.Name = "BTN_VerTodos";
            BTN_VerTodos.Size = new Size(75, 23);
            BTN_VerTodos.TabIndex = 77;
            BTN_VerTodos.Text = "Ver Todos";
            BTN_VerTodos.UseVisualStyleBackColor = true;
            BTN_VerTodos.Click += BTN_VerTodos_Click;
            // 
            // LV_Clientes
            // 
            LV_Clientes.Location = new Point(112, 104);
            LV_Clientes.MultiSelect = false;
            LV_Clientes.Name = "LV_Clientes";
            LV_Clientes.Size = new Size(841, 287);
            LV_Clientes.TabIndex = 76;
            LV_Clientes.UseCompatibleStateImageBehavior = false;
            LV_Clientes.SelectedIndexChanged += LV_Clientes_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(112, 72);
            label1.Name = "label1";
            label1.Size = new Size(35, 15);
            label1.TabIndex = 75;
            label1.Text = "Dato:";
            // 
            // BTN_Modificar
            // 
            BTN_Modificar.Location = new Point(878, 68);
            BTN_Modificar.Name = "BTN_Modificar";
            BTN_Modificar.Size = new Size(75, 23);
            BTN_Modificar.TabIndex = 74;
            BTN_Modificar.Text = "Modificar";
            BTN_Modificar.UseVisualStyleBackColor = true;
            BTN_Modificar.Click += BTN_Modificar_Click;
            // 
            // TB_Busqueda
            // 
            TB_Busqueda.Location = new Point(153, 68);
            TB_Busqueda.Name = "TB_Busqueda";
            TB_Busqueda.Size = new Size(272, 23);
            TB_Busqueda.TabIndex = 73;
            TB_Busqueda.TextChanged += TB_Busqueda_TextChanged;
            // 
            // BTN_Busqueda
            // 
            BTN_Busqueda.Location = new Point(797, 68);
            BTN_Busqueda.Name = "BTN_Busqueda";
            BTN_Busqueda.Size = new Size(75, 23);
            BTN_Busqueda.TabIndex = 72;
            BTN_Busqueda.Text = "Buscar";
            BTN_Busqueda.UseVisualStyleBackColor = true;
            BTN_Busqueda.Click += BTN_Busqueda_Click;
            // 
            // menuSuperior1
            // 
            menuSuperior1.Location = new Point(312, 0);
            menuSuperior1.Name = "menuSuperior1";
            menuSuperior1.Size = new Size(459, 33);
            menuSuperior1.TabIndex = 78;
            // 
            // ModificarCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1079, 425);
            Controls.Add(menuSuperior1);
            Controls.Add(BTN_VerTodos);
            Controls.Add(LV_Clientes);
            Controls.Add(label1);
            Controls.Add(BTN_Modificar);
            Controls.Add(TB_Busqueda);
            Controls.Add(BTN_Busqueda);
            Name = "ModificarCliente";
            Text = "Información del cliente";
            Load += ModificarCliente_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BTN_VerTodos;
        private ListView LV_Clientes;
        private Label label1;
        private Button BTN_Modificar;
        private TextBox TB_Busqueda;
        private Button BTN_Busqueda;
        private MenuSuperior menuSuperior1;
    }
}