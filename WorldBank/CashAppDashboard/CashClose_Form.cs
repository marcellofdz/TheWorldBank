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
using System.Timers;

namespace Dashboard
{
    public partial class CashClose_Form : Form
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

        public CashClose_Form()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));


        }

        public class Account
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void btnDashbord_Click(object sender, EventArgs e)
        {

        }

        private void btnAnalytics_Click(object sender, EventArgs e)
        {

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

        



      

        



        private void btnFiltro_Click(object sender, EventArgs e)
        {
          
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ConnectionStringSettings config = ConfigurationManager.ConnectionStrings["ConnectionString1"];

            SqlConnection connection = new SqlConnection(config.ConnectionString);
            connection.Open();

            SqlTransaction transact = null;


            int registros = 0, registro2 = 0;

            try
            {
                transact = connection.BeginTransaction();
                SqlCommand addHistoric = new SqlCommand("fillHistorico", connection, transact);
                SqlCommand closeCash = new SqlCommand("cierreCaja", connection, transact);

                addHistoric.CommandType = CommandType.StoredProcedure;
                closeCash.CommandType = CommandType.StoredProcedure;

                registros = addHistoric.ExecuteNonQuery();
                registro2 = closeCash.ExecuteNonQuery();

                transact.Commit();
                connection.Close();


                log.Info("Se registro el cierre");
                MessageBox.Show("Cierre Registrado!");
            }
            catch (Exception ex)
            {
                log.Error("Error al realizar el cierre", ex);
                transact.Rollback();

                MessageBox.Show("Error al realizar el cierre");
            }

            this.Close();

            Application.Exit();


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
