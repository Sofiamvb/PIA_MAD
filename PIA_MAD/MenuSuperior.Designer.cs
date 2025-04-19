namespace PIA_MAD
{
    partial class MenuSuperior
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            Menu_VRegCli = new ToolStripMenuItem();
            Menu_VModCli = new ToolStripMenuItem();
            Menu_VReservacion = new ToolStripMenuItem();
            Menu_VCheckIn = new ToolStripMenuItem();
            Menu_VCheckOut = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { Menu_VRegCli, Menu_VReservacion, Menu_VCheckIn, Menu_VCheckOut });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(437, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // Menu_VRegCli
            // 
            Menu_VRegCli.DropDownItems.AddRange(new ToolStripItem[] { Menu_VModCli });
            Menu_VRegCli.Name = "Menu_VRegCli";
            Menu_VRegCli.Size = new Size(121, 20);
            Menu_VRegCli.Text = "Registro de clientes";
            Menu_VRegCli.Click += registroDeClientesToolStripMenuItem_Click;
            // 
            // Menu_VModCli
            // 
            Menu_VModCli.Name = "Menu_VModCli";
            Menu_VModCli.Size = new Size(165, 22);
            Menu_VModCli.Text = "Modificar Cliente";
            Menu_VModCli.Click += Menu_VModCli_Click;
            // 
            // Menu_VReservacion
            // 
            Menu_VReservacion.Name = "Menu_VReservacion";
            Menu_VReservacion.Size = new Size(93, 20);
            Menu_VReservacion.Text = "Reservaciones";
            Menu_VReservacion.Click += Menu_VReservacion_Click;
            // 
            // Menu_VCheckIn
            // 
            Menu_VCheckIn.Name = "Menu_VCheckIn";
            Menu_VCheckIn.Size = new Size(68, 20);
            Menu_VCheckIn.Text = "Check In ";
            Menu_VCheckIn.Click += Menu_VCheckIn_Click;
            // 
            // Menu_VCheckOut
            // 
            Menu_VCheckOut.Name = "Menu_VCheckOut";
            Menu_VCheckOut.Size = new Size(78, 20);
            Menu_VCheckOut.Text = "Check Out ";
            Menu_VCheckOut.Click += Menu_VCheckOut_Click;
            // 
            // MenuSuperior
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(menuStrip1);
            Name = "MenuSuperior";
            Size = new Size(437, 39);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem Menu_VRegCli;
        private ToolStripMenuItem Menu_VReservacion;
        private ToolStripMenuItem Menu_VCheckIn;
        private ToolStripMenuItem Menu_VCheckOut;
        private ToolStripMenuItem Menu_VModCli;
    }
}
