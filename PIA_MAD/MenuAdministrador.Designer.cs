namespace PIA_MAD
{
    partial class MenuAdministrador
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
            registroDeHotelesToolStripMenuItem = new ToolStripMenuItem();
            modificarRegistroDeHotelToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            modificarRegistroDeHabitaciónToolStripMenuItem = new ToolStripMenuItem();
            cancelarReservaciónToolStripMenuItem = new ToolStripMenuItem();
            reporteDeVentasToolStripMenuItem = new ToolStripMenuItem();
            reporteDeOcupaciónToolStripMenuItem = new ToolStripMenuItem();
            historialDelClienteToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { registroDeHotelesToolStripMenuItem, toolStripMenuItem1, cancelarReservaciónToolStripMenuItem, reporteDeVentasToolStripMenuItem, reporteDeOcupaciónToolStripMenuItem, historialDelClienteToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(777, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // registroDeHotelesToolStripMenuItem
            // 
            registroDeHotelesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { modificarRegistroDeHotelToolStripMenuItem });
            registroDeHotelesToolStripMenuItem.Name = "registroDeHotelesToolStripMenuItem";
            registroDeHotelesToolStripMenuItem.Size = new Size(119, 20);
            registroDeHotelesToolStripMenuItem.Text = "Registro de hoteles";
            registroDeHotelesToolStripMenuItem.Click += registroDeHotelesToolStripMenuItem_Click;
            // 
            // modificarRegistroDeHotelToolStripMenuItem
            // 
            modificarRegistroDeHotelToolStripMenuItem.Name = "modificarRegistroDeHotelToolStripMenuItem";
            modificarRegistroDeHotelToolStripMenuItem.Size = new Size(214, 22);
            modificarRegistroDeHotelToolStripMenuItem.Text = "Modificar registro de hotel";
            modificarRegistroDeHotelToolStripMenuItem.Click += modificarRegistroDeHotelToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { modificarRegistroDeHabitaciónToolStripMenuItem });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(148, 20);
            toolStripMenuItem1.Text = "Registro de habitaciones";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // modificarRegistroDeHabitaciónToolStripMenuItem
            // 
            modificarRegistroDeHabitaciónToolStripMenuItem.Name = "modificarRegistroDeHabitaciónToolStripMenuItem";
            modificarRegistroDeHabitaciónToolStripMenuItem.Size = new Size(243, 22);
            modificarRegistroDeHabitaciónToolStripMenuItem.Text = "Modificar registro de habitación";
            modificarRegistroDeHabitaciónToolStripMenuItem.Click += modificarRegistroDeHabitaciónToolStripMenuItem_Click;
            // 
            // cancelarReservaciónToolStripMenuItem
            // 
            cancelarReservaciónToolStripMenuItem.Name = "cancelarReservaciónToolStripMenuItem";
            cancelarReservaciónToolStripMenuItem.Size = new Size(128, 20);
            cancelarReservaciónToolStripMenuItem.Text = "Cancelar reservación";
            cancelarReservaciónToolStripMenuItem.Click += cancelarReservaciónToolStripMenuItem_Click;
            // 
            // reporteDeVentasToolStripMenuItem
            // 
            reporteDeVentasToolStripMenuItem.Name = "reporteDeVentasToolStripMenuItem";
            reporteDeVentasToolStripMenuItem.Size = new Size(113, 20);
            reporteDeVentasToolStripMenuItem.Text = "Reporte de ventas";
            reporteDeVentasToolStripMenuItem.Click += reporteDeVentasToolStripMenuItem_Click;
            // 
            // reporteDeOcupaciónToolStripMenuItem
            // 
            reporteDeOcupaciónToolStripMenuItem.Name = "reporteDeOcupaciónToolStripMenuItem";
            reporteDeOcupaciónToolStripMenuItem.Size = new Size(135, 20);
            reporteDeOcupaciónToolStripMenuItem.Text = "Reporte de ocupación";
            reporteDeOcupaciónToolStripMenuItem.Click += reporteDeOcupaciónToolStripMenuItem_Click;
            // 
            // historialDelClienteToolStripMenuItem
            // 
            historialDelClienteToolStripMenuItem.Name = "historialDelClienteToolStripMenuItem";
            historialDelClienteToolStripMenuItem.Size = new Size(120, 20);
            historialDelClienteToolStripMenuItem.Text = "Historial del cliente";
            historialDelClienteToolStripMenuItem.Click += historialDelClienteToolStripMenuItem_Click;
            // 
            // MenuAdministrador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(menuStrip1);
            Name = "MenuAdministrador";
            Size = new Size(777, 37);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem registroDeHotelesToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem cancelarReservaciónToolStripMenuItem;
        private ToolStripMenuItem reporteDeVentasToolStripMenuItem;
        private ToolStripMenuItem reporteDeOcupaciónToolStripMenuItem;
        private ToolStripMenuItem historialDelClienteToolStripMenuItem;
        private ToolStripMenuItem modificarRegistroDeHotelToolStripMenuItem;
        private ToolStripMenuItem modificarRegistroDeHabitaciónToolStripMenuItem;
    }
}
