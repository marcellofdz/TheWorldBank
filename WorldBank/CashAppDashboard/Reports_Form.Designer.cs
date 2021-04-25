namespace Dashboard
{
    partial class Reports_Form
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
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.btnCuadre = new System.Windows.Forms.Button();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panel4.Controls.Add(this.btnBuscarCliente);
            this.panel4.Controls.Add(this.btnCuadre);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(746, 529);
            this.panel4.TabIndex = 18;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.btnBuscarCliente.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBuscarCliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan;
            this.btnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarCliente.Font = new System.Drawing.Font("Nirmala UI", 12.25F);
            this.btnBuscarCliente.ForeColor = System.Drawing.Color.White;
            this.btnBuscarCliente.Location = new System.Drawing.Point(272, 141);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(189, 35);
            this.btnBuscarCliente.TabIndex = 24;
            this.btnBuscarCliente.Text = "Buscar por Cliente";
            this.btnBuscarCliente.UseVisualStyleBackColor = false;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // btnCuadre
            // 
            this.btnCuadre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.btnCuadre.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCuadre.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan;
            this.btnCuadre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCuadre.Font = new System.Drawing.Font("Nirmala UI", 12.25F);
            this.btnCuadre.ForeColor = System.Drawing.Color.White;
            this.btnCuadre.Location = new System.Drawing.Point(272, 204);
            this.btnCuadre.Name = "btnCuadre";
            this.btnCuadre.Size = new System.Drawing.Size(184, 35);
            this.btnCuadre.TabIndex = 22;
            this.btnCuadre.Text = "Todas";
            this.btnCuadre.UseVisualStyleBackColor = false;
            this.btnCuadre.Click += new System.EventHandler(this.btnCuadre_Click);
            // 
            // Reports_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(747, 531);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Reports_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.Button btnCuadre;
    }
}

