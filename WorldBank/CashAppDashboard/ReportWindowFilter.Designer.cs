namespace Dashboard
{
    partial class ReportWindowFilter
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
            this.TransaccionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CashDBDataSet = new Dashboard.CashDBDataSet();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.TransaccionesTableAdapter = new Dashboard.CashDBDataSetTableAdapters.TransaccionesTableAdapter();
            this.sQLServerCashDBDataSet = new Dashboard.SQLServerCashDBDataSet();
            this.sQLServerCashDBDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.transaccionesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.transaccionesTableAdapter1 = new Dashboard.SQLServerCashDBDataSetTableAdapters.TransaccionesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.TransaccionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CashDBDataSet)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sQLServerCashDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sQLServerCashDBDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transaccionesBindingSource1)).BeginInit();
            this.SuspendLayout();
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
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.btnFilter);
            this.panel4.Controls.Add(this.txtFilter);
            this.panel4.Controls.Add(this.reportViewer1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(711, 531);
            this.panel4.TabIndex = 18;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(674, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 25);
            this.button1.TabIndex = 21;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.btnFilter.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnFilter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Font = new System.Drawing.Font("Nirmala UI", 8.25F);
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.Location = new System.Drawing.Point(238, 10);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 20;
            this.btnFilter.Text = "Filtrar";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(45, 12);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(187, 20);
            this.txtFilter.TabIndex = 1;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "SQLServerDataSet";
            reportDataSource1.Value = this.transaccionesBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Dashboard.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 51);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(713, 478);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
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
            // ReportWindowFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(711, 531);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReportWindowFilter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TransaccionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CashDBDataSet)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
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
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource sQLServerCashDBDataSetBindingSource;
        private SQLServerCashDBDataSet sQLServerCashDBDataSet;
        private System.Windows.Forms.BindingSource transaccionesBindingSource1;
        private SQLServerCashDBDataSetTableAdapters.TransaccionesTableAdapter transaccionesTableAdapter1;
    }
}

