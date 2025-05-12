namespace PIA_MAD
{
    partial class ModificarOperativos
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
            LV_Operativos = new ListView();
            label1 = new Label();
            BTN_Modificar = new Button();
            TB_Busqueda = new TextBox();
            BTN_Busqueda = new Button();
            SuspendLayout();
            // 
            // BTN_VerTodos
            // 
            BTN_VerTodos.Location = new Point(688, 30);
            BTN_VerTodos.Name = "BTN_VerTodos";
            BTN_VerTodos.Size = new Size(75, 23);
            BTN_VerTodos.TabIndex = 83;
            BTN_VerTodos.Text = "Ver Todos";
            BTN_VerTodos.UseVisualStyleBackColor = true;
            BTN_VerTodos.Click += BTN_VerTodos_Click;
            // 
            // LV_Operativos
            // 
            LV_Operativos.Location = new Point(84, 66);
            LV_Operativos.MultiSelect = false;
            LV_Operativos.Name = "LV_Operativos";
            LV_Operativos.Size = new Size(841, 287);
            LV_Operativos.TabIndex = 82;
            LV_Operativos.UseCompatibleStateImageBehavior = false;
            LV_Operativos.SelectedIndexChanged += LV_Operativos_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(84, 34);
            label1.Name = "label1";
            label1.Size = new Size(35, 15);
            label1.TabIndex = 81;
            label1.Text = "Dato:";
            // 
            // BTN_Modificar
            // 
            BTN_Modificar.Location = new Point(850, 30);
            BTN_Modificar.Name = "BTN_Modificar";
            BTN_Modificar.Size = new Size(75, 23);
            BTN_Modificar.TabIndex = 80;
            BTN_Modificar.Text = "Modificar";
            BTN_Modificar.UseVisualStyleBackColor = true;
            BTN_Modificar.Click += BTN_Modificar_Click;
            // 
            // TB_Busqueda
            // 
            TB_Busqueda.Location = new Point(125, 30);
            TB_Busqueda.Name = "TB_Busqueda";
            TB_Busqueda.Size = new Size(272, 23);
            TB_Busqueda.TabIndex = 79;
            // 
            // BTN_Busqueda
            // 
            BTN_Busqueda.Location = new Point(769, 30);
            BTN_Busqueda.Name = "BTN_Busqueda";
            BTN_Busqueda.Size = new Size(75, 23);
            BTN_Busqueda.TabIndex = 78;
            BTN_Busqueda.Text = "Buscar";
            BTN_Busqueda.UseVisualStyleBackColor = true;
            // 
            // ModificarOperativos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1003, 387);
            Controls.Add(BTN_VerTodos);
            Controls.Add(LV_Operativos);
            Controls.Add(label1);
            Controls.Add(BTN_Modificar);
            Controls.Add(TB_Busqueda);
            Controls.Add(BTN_Busqueda);
            Name = "ModificarOperativos";
            Text = "ModificarOperativos";
            Load += ModificarOperativos_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BTN_VerTodos;
        private ListView LV_Operativos;
        private Label label1;
        private Button BTN_Modificar;
        private TextBox TB_Busqueda;
        private Button BTN_Busqueda;
    }
}