namespace PIA_MAD
{
    partial class Modificar_Habitaciones
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
            LV_Habitaciones = new ListView();
            label1 = new Label();
            BTN_Modificar = new Button();
            TB_Busqueda = new TextBox();
            BTN_Busqueda = new Button();
            BTN_VerTodos = new Button();
            SuspendLayout();
            // 
            // LV_Habitaciones
            // 
            LV_Habitaciones.Location = new Point(46, 58);
            LV_Habitaciones.MultiSelect = false;
            LV_Habitaciones.Name = "LV_Habitaciones";
            LV_Habitaciones.Size = new Size(841, 287);
            LV_Habitaciones.TabIndex = 15;
            LV_Habitaciones.UseCompatibleStateImageBehavior = false;
            LV_Habitaciones.SelectedIndexChanged += LV_Habitaciones_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 26);
            label1.Name = "label1";
            label1.Size = new Size(35, 15);
            label1.TabIndex = 14;
            label1.Text = "Dato:";
            // 
            // BTN_Modificar
            // 
            BTN_Modificar.Location = new Point(812, 22);
            BTN_Modificar.Name = "BTN_Modificar";
            BTN_Modificar.Size = new Size(75, 23);
            BTN_Modificar.TabIndex = 13;
            BTN_Modificar.Text = "Modificar";
            BTN_Modificar.UseVisualStyleBackColor = true;
            BTN_Modificar.Click += BTN_Modificar_Click;
            // 
            // TB_Busqueda
            // 
            TB_Busqueda.Location = new Point(87, 22);
            TB_Busqueda.Name = "TB_Busqueda";
            TB_Busqueda.Size = new Size(272, 23);
            TB_Busqueda.TabIndex = 12;
            TB_Busqueda.TextChanged += TB_Busqueda_TextChanged;
            // 
            // BTN_Busqueda
            // 
            BTN_Busqueda.Location = new Point(731, 22);
            BTN_Busqueda.Name = "BTN_Busqueda";
            BTN_Busqueda.Size = new Size(75, 23);
            BTN_Busqueda.TabIndex = 11;
            BTN_Busqueda.Text = "Buscar";
            BTN_Busqueda.UseVisualStyleBackColor = true;
            BTN_Busqueda.Click += BTN_Busqueda_Click;
            // 
            // BTN_VerTodos
            // 
            BTN_VerTodos.Location = new Point(650, 22);
            BTN_VerTodos.Name = "BTN_VerTodos";
            BTN_VerTodos.Size = new Size(75, 23);
            BTN_VerTodos.TabIndex = 16;
            BTN_VerTodos.Text = "Ver Todos";
            BTN_VerTodos.UseVisualStyleBackColor = true;
            BTN_VerTodos.Click += BTN_VerTodos_Click;
            // 
            // Modificar_Habitaciones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(932, 366);
            Controls.Add(BTN_VerTodos);
            Controls.Add(LV_Habitaciones);
            Controls.Add(label1);
            Controls.Add(BTN_Modificar);
            Controls.Add(TB_Busqueda);
            Controls.Add(BTN_Busqueda);
            Name = "Modificar_Habitaciones";
            Text = "Modificar Habitaciones";
            Load += Modificar_Habitaciones_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView LV_Habitaciones;
        private Label label1;
        private Button BTN_Modificar;
        private TextBox TB_Busqueda;
        private Button BTN_Busqueda;
        private Button BTN_VerTodos;
    }
}