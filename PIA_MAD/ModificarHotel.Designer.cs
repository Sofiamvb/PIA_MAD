namespace PIA_MAD
{
    partial class Mod_Hotel
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
            BTN_Modificar = new Button();
            TB_Busqueda = new TextBox();
            BTN_Busqueda = new Button();
            LV_Hoteles = new ListView();
            menuAdministrador1 = new MenuAdministrador();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(144, 80);
            label1.Name = "label1";
            label1.Size = new Size(35, 15);
            label1.TabIndex = 9;
            label1.Text = "Dato:";
            // 
            // BTN_Modificar
            // 
            BTN_Modificar.Location = new Point(910, 76);
            BTN_Modificar.Name = "BTN_Modificar";
            BTN_Modificar.Size = new Size(75, 23);
            BTN_Modificar.TabIndex = 8;
            BTN_Modificar.Text = "Modificar";
            BTN_Modificar.UseVisualStyleBackColor = true;
            BTN_Modificar.Click += BTN_Modificar_Click;
            // 
            // TB_Busqueda
            // 
            TB_Busqueda.Location = new Point(185, 76);
            TB_Busqueda.Name = "TB_Busqueda";
            TB_Busqueda.Size = new Size(272, 23);
            TB_Busqueda.TabIndex = 6;
            TB_Busqueda.TextChanged += TB_Busqueda_TextChanged;
            // 
            // BTN_Busqueda
            // 
            BTN_Busqueda.Location = new Point(829, 76);
            BTN_Busqueda.Name = "BTN_Busqueda";
            BTN_Busqueda.Size = new Size(75, 23);
            BTN_Busqueda.TabIndex = 5;
            BTN_Busqueda.Text = "Buscar";
            BTN_Busqueda.UseVisualStyleBackColor = true;
            BTN_Busqueda.Click += BTN_Busqueda_Click;
            // 
            // LV_Hoteles
            // 
            LV_Hoteles.Location = new Point(144, 112);
            LV_Hoteles.MultiSelect = false;
            LV_Hoteles.Name = "LV_Hoteles";
            LV_Hoteles.Size = new Size(841, 287);
            LV_Hoteles.TabIndex = 10;
            LV_Hoteles.UseCompatibleStateImageBehavior = false;
            LV_Hoteles.SelectedIndexChanged += LV_Hoteles_SelectedIndexChanged;
            // 
            // menuAdministrador1
            // 
            menuAdministrador1.Location = new Point(0, 0);
            menuAdministrador1.Name = "menuAdministrador1";
            menuAdministrador1.Size = new Size(1171, 47);
            menuAdministrador1.TabIndex = 11;
            // 
            // Mod_Hotel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1164, 421);
            Controls.Add(menuAdministrador1);
            Controls.Add(LV_Hoteles);
            Controls.Add(label1);
            Controls.Add(BTN_Modificar);
            Controls.Add(TB_Busqueda);
            Controls.Add(BTN_Busqueda);
            Name = "Mod_Hotel";
            Text = "Modificar Hotel";
            Load += Mod_Hotel_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button BTN_Modificar;
        private TextBox TB_Busqueda;
        private Button BTN_Busqueda;
        private ListView LV_Hoteles;
        private MenuAdministrador menuAdministrador1;
    }
}