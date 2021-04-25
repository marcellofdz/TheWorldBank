using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Configuration;
using System.Data.SqlClient;

namespace Dashboard
{
    public partial class ReportWindowFilter : Form
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
         (
               int nLeftRect,
               int nTopRect,
               int nRightRect,
               int nBottomRect,
               int nWidthEllipse,
               int nHeightEllipse

         );

        public ReportWindowFilter()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));


            this.CashDBDataSet.Transacciones.Clear();
            this.TransaccionesTableAdapter.Fill(this.CashDBDataSet.Transacciones);

            this.reportViewer1.RefreshReport();

        }

        public class Account
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sQLServerCashDBDataSet.Transacciones' table. You can move, or remove it, as needed.
            this.transaccionesTableAdapter1.Fill(this.sQLServerCashDBDataSet.Transacciones);
            // TODO: This line of code loads data into the 'CashDBDataSet.Transacciones' table. You can move, or remove it, as needed.
            this.CashDBDataSet.Transacciones.Clear();
            this.TransaccionesTableAdapter.Fill(this.CashDBDataSet.Transacciones);


            this.reportViewer1.RefreshReport();
        }

        private void btnDashbord_Click(object sender, EventArgs e)
        {
            this.CashDBDataSet.Transacciones.Clear();
            this.TransaccionesTableAdapter.Fill(this.CashDBDataSet.Transacciones);


            this.reportViewer1.RefreshReport();
        }

        private void btnAnalytics_Click(object sender, EventArgs e)
        {
            this.CashDBDataSet.Transacciones.Clear();
            this.TransaccionesTableAdapter.Fill(this.CashDBDataSet.Transacciones);


            this.reportViewer1.RefreshReport();
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void cbCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {

            this.CashDBDataSet.Transacciones.Clear();
            this.TransaccionesTableAdapter.FillByCedula(this.CashDBDataSet.Transacciones, txtFilter.Text);


            this.reportViewer1.RefreshReport();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
