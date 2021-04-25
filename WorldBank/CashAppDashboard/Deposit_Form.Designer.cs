namespace Dashboard
{
    partial class Deposit_Form
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkCedula = new System.Windows.Forms.CheckBox();
            this.btnTransaccion = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTransaccion = new System.Windows.Forms.ComboBox();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbCuenta = new System.Windows.Forms.ComboBox();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panel4.Controls.Add(this.txtCedula);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.checkCedula);
            this.panel4.Controls.Add(this.btnTransaccion);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.cbTransaccion);
            this.panel4.Controls.Add(this.txtMonto);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.cbCuenta);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(746, 540);
            this.panel4.TabIndex = 18;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // txtCedula
            // 
            this.txtCedula.Location = new System.Drawing.Point(320, 114);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(121, 20);
            this.txtCedula.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(222, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 25);
            this.label3.TabIndex = 22;
            this.label3.Text = "Cedula:";
            // 
            // checkCedula
            // 
            this.checkCedula.AutoSize = true;
            this.checkCedula.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkCedula.ForeColor = System.Drawing.Color.White;
            this.checkCedula.Location = new System.Drawing.Point(461, 117);
            this.checkCedula.Name = "checkCedula";
            this.checkCedula.Size = new System.Drawing.Size(121, 17);
            this.checkCedula.TabIndex = 21;
            this.checkCedula.Text = "Transferencia Propia";
            this.checkCedula.UseVisualStyleBackColor = true;
            this.checkCedula.CheckedChanged += new System.EventHandler(this.checkCedula_CheckedChanged);
            // 
            // btnTransaccion
            // 
            this.btnTransaccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.btnTransaccion.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnTransaccion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan;
            this.btnTransaccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransaccion.Font = new System.Drawing.Font("Nirmala UI", 12.25F);
            this.btnTransaccion.ForeColor = System.Drawing.Color.White;
            this.btnTransaccion.Location = new System.Drawing.Point(320, 318);
            this.btnTransaccion.Name = "btnTransaccion";
            this.btnTransaccion.Size = new System.Drawing.Size(114, 35);
            this.btnTransaccion.TabIndex = 20;
            this.btnTransaccion.Text = "Aceptar";
            this.btnTransaccion.UseVisualStyleBackColor = false;
            this.btnTransaccion.Click += new System.EventHandler(this.btnFiltro_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(157, 258);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tipo Transaccion:";
            // 
            // cbTransaccion
            // 
            this.cbTransaccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbTransaccion.FormattingEnabled = true;
            this.cbTransaccion.Location = new System.Drawing.Point(320, 258);
            this.cbTransaccion.Name = "cbTransaccion";
            this.cbTransaccion.Size = new System.Drawing.Size(121, 21);
            this.cbTransaccion.TabIndex = 5;
            this.cbTransaccion.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged_1);
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(320, 213);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(121, 20);
            this.txtMonto.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(222, 208);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Monto:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(238, 160);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 25);
            this.label9.TabIndex = 1;
            this.label9.Text = "Cuenta:";
            // 
            // cbCuenta
            // 
            this.cbCuenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbCuenta.FormattingEnabled = true;
            this.cbCuenta.Location = new System.Drawing.Point(320, 164);
            this.cbCuenta.Name = "cbCuenta";
            this.cbCuenta.Size = new System.Drawing.Size(121, 21);
            this.cbCuenta.TabIndex = 0;
            this.cbCuenta.SelectedIndexChanged += new System.EventHandler(this.cbCuenta_SelectedIndexChanged);
            // 
            // Deposit_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(747, 541);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Deposit_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cbCuenta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbTransaccion;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Button btnTransaccion;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkCedula;
    }
}

