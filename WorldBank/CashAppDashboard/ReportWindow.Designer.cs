namespace Dashboard
{
    partial class ReportWindow
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.TransaccionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CashDBDataSet = new Dashboard.CashDBDataSet();
            this.TransaccionesTableAdapter = new Dashboard.CashDBDataSetTableAdapters.TransaccionesTableAdapter();
            this.sQLServerCashDBDataSet = new Dashboard.SQLServerCashDBDataSet();
            this.sQLServerCashDBDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.transaccionesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.transaccionesTableAdapter1 = new Dashboard.SQLServerCashDBDataSetTableAdapters.TransaccionesTableAdapter();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TransaccionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CashDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sQLServerCashDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sQLServerCashDBDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transaccionesBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panel4.Controls.Add(this.button2);
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.reportViewer1);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(713, 529);
            this.panel4.TabIndex = 18;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(545, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(138, 25);
            this.button2.TabIndex = 14;
            this.button2.Text = "Actualizar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(680, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(42, 25);
            this.button1.TabIndex = 13;
            this.button1.Text = "X";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "SQLServerDataSet";
            reportDataSource1.Value = this.transaccionesBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Dashboard.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(713, 529);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // TransaccionesBindingSource
            // 
            this.TransaccionesBindingSource.DataMember = "Transacciones";
            this.TransaccionesBindingSource.DataSource = this.CashDBDataSet;
            // 
            // CashDBDataSet
            // 
            this.CashDBDataSet.DataSetName = "CashDBDataSet";
            this.CashDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // TransaccionesTableAdapter
            // 
            this.TransaccionesTableAdapter.ClearBeforeFill = true;
            // 
            // sQLServerCashDBDataSet
            // 
            this.sQLServerCashDBDataSet.DataSetName = "SQLServerCashDBDataSet";
            this.sQLServerCashDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sQLServerCashDBDataSetBindingSource
            // 
            this.sQLServerCashDBDataSetBindingSource.DataSource = this.sQLServerCashDBDataSet;
            this.sQLServerCashDBDataSetBindingSource.Position = 0;
            // 
            // transaccionesBindingSource1
            // 
            this.transaccionesBindingSource1.DataMember = "Transacciones";
            this.transaccionesBindingSource1.DataSource = this.sQLServerCashDBDataSetBindingSource;
            // 
            // transaccionesTableAdapter1
            // 
            this.transaccionesTableAdapter1.ClearBeforeFill = true;
            // 
            // ReportWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(711, 531);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReportWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TransaccionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CashDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sQLServerCashDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sQLServerCashDBDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transaccionesBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel4;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource TransaccionesBindingSource;
        private CashDBDataSet CashDBDataSet;
        private CashDBDataSetTableAdapters.TransaccionesTableAdapter TransaccionesTableAdapter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.BindingSource sQLServerCashDBDataSetBindingSource;
        private SQLServerCashDBDataSet sQLServerCashDBDataSet;
        private System.Windows.Forms.BindingSource transaccionesBindingSource1;
        private SQLServerCashDBDataSetTableAdapters.TransaccionesTableAdapter transaccionesTableAdapter1;
    }
}

