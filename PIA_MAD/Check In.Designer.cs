namespace PIA_MAD
{
    partial class Check_In
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
            TB_CheckIn = new TextBox();
            label1 = new Label();
            BTN_CheckIn = new Button();
            SuspendLayout();
            // 
            // TB_CheckIn
            // 
            TB_CheckIn.Location = new Point(167, 52);
            TB_CheckIn.Name = "TB_CheckIn";
            TB_CheckIn.Size = new Size(201, 23);
            TB_CheckIn.TabIndex = 3;
            TB_CheckIn.TextChanged += TB_CheckIn_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 55);
            label1.Name = "label1";
            label1.Size = new Size(128, 15);
            label1.TabIndex = 2;
            label1.Text = "Código de reservación:";
            // 
            // BTN_CheckIn
            // 
            BTN_CheckIn.Location = new Point(155, 119);
            BTN_CheckIn.Name = "BTN_CheckIn";
            BTN_CheckIn.Size = new Size(75, 23);
            BTN_CheckIn.TabIndex = 4;
            BTN_CheckIn.Text = "Check In";
            BTN_CheckIn.UseVisualStyleBackColor = true;
            BTN_CheckIn.Click += BTN_CheckIn_Click;
            // 
            // Check_In
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(397, 166);
            Controls.Add(BTN_CheckIn);
            Controls.Add(TB_CheckIn);
            Controls.Add(label1);
            Name = "Check_In";
            Text = "Check In";
            Load += Check_In_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TB_CheckIn;
        private Label label1;
        private Button BTN_CheckIn;
        private MenuSuperior menuSuperior1;
    }
}