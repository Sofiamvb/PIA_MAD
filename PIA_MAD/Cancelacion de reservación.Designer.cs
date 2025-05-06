namespace PIA_MAD
{
    partial class Cancelacion_de_reservación
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
            TB_CodigoCancelacion = new TextBox();
            DTP_CancelarReservacion = new DateTimePicker();
            BTN_CancelarReservacion = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 88);
            label1.Name = "label1";
            label1.Size = new Size(128, 15);
            label1.TabIndex = 0;
            label1.Text = "Código de reservación:";
            // 
            // TB_CodigoCancelacion
            // 
            TB_CodigoCancelacion.Location = new Point(160, 85);
            TB_CodigoCancelacion.Name = "TB_CodigoCancelacion";
            TB_CodigoCancelacion.Size = new Size(201, 23);
            TB_CodigoCancelacion.TabIndex = 1;
            TB_CodigoCancelacion.TextChanged += TB_CodigoCancelacion_TextChanged;
            TB_CodigoCancelacion.KeyDown += TB_CodigoCancelacion_KeyDown;
            // 
            // DTP_CancelarReservacion
            // 
            DTP_CancelarReservacion.Location = new Point(160, 12);
            DTP_CancelarReservacion.Name = "DTP_CancelarReservacion";
            DTP_CancelarReservacion.Size = new Size(220, 23);
            DTP_CancelarReservacion.TabIndex = 2;
            // 
            // BTN_CancelarReservacion
            // 
            BTN_CancelarReservacion.Location = new Point(171, 143);
            BTN_CancelarReservacion.Name = "BTN_CancelarReservacion";
            BTN_CancelarReservacion.Size = new Size(75, 23);
            BTN_CancelarReservacion.TabIndex = 3;
            BTN_CancelarReservacion.Text = "Cancelar";
            BTN_CancelarReservacion.UseVisualStyleBackColor = true;
            BTN_CancelarReservacion.Click += BTN_CancelarReservacion_Click;
            // 
            // Cancelacion_de_reservación
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(404, 193);
            Controls.Add(BTN_CancelarReservacion);
            Controls.Add(DTP_CancelarReservacion);
            Controls.Add(TB_CodigoCancelacion);
            Controls.Add(label1);
            Name = "Cancelacion_de_reservación";
            Text = "Cancelacion de reservación";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox TB_CodigoCancelacion;
        private DateTimePicker DTP_CancelarReservacion;
        private Button BTN_CancelarReservacion;
    }
}