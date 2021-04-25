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
    public partial class Dashboard_Form : Form
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

        public Dashboard_Form()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            pnlNav.Height = btnDashbord.Height;
            pnlNav.Top = btnDashbord.Top;
            pnlNav.Left = btnDashbord.Left;
            btnDashbord.BackColor = Color.FromArgb(46, 51, 73);

            getMontoActual();
            getMontoDeposito();
            getMontoRetiro();

            IntegracionWS.WorldBankWebServiceSoapClient soapClient = new IntegracionWS.WorldBankWebServiceSoapClient();



            IntegracionWS.Empleado empleado = soapClient.GetEmployeeResp("poi", "456");


            label1.Text = empleado.Nombres.ToString();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getMontoActual();
            getMontoDeposito();
            getMontoRetiro();

            Deposit_Form deposit_Form = new Deposit_Form();
            deposit_Form.OnTimedEvent();

            getMontoActual();
            getMontoDeposito();
            getMontoRetiro();


        }

        private void getMontoActual()
        {

            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString);
            String respuesta = "";
            connection.Open();
            SqlCommand command = new SqlCommand("getMonto", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;  

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                respuesta = String.Format("{0}", reader["Monto_Final"]);
                labelMontoActual.Text = respuesta;
            }
            connection.Close();
        }

        private void getMontoDeposito() {

            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString);
            String respuesta = "";
            connection.Open();
            SqlCommand command = new SqlCommand("getMonto", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                respuesta = String.Format("{0}", reader["Monto_Deposito"]);
                labelTotalDeposito.Text = respuesta;
            }
            connection.Close();
        }

        private void getMontoRetiro() {

            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString);
            String respuesta = "";
            connection.Open();
            SqlCommand command = new SqlCommand("getMonto", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                respuesta = String.Format("{0}", reader["Monto_Retiro"]);
                labelTotalRetiro.Text = respuesta;
            }
            connection.Close();


        }


        private void btnDashbord_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnDashbord.Height;
            pnlNav.Top = btnDashbord.Top;
            pnlNav.Left = btnDashbord.Left;
            btnDashbord.BackColor = Color.FromArgb(46, 51, 73);

            panel3.Show();
            panel4.Show();
            panel5.Show();
            panel6.Show();
            panel7.Show();
            panel8.Show();
            panel9.Show();
            panel10.Show();

            getMontoActual();
            getMontoDeposito();
            getMontoRetiro();

        }

        private void btnAnalytics_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnAnalytics.Height;
            pnlNav.Top = btnAnalytics.Top;
            btnAnalytics.BackColor = Color.FromArgb(46, 51, 73);

            panel3.Hide();
            panel4.Hide();
            panel5.Hide();
            panel6.Hide();
            panel7.Hide();
            panel8.Hide();
            panel9.Hide();
            panel10.Hide();

            Reports_Form reports_Form = new Reports_Form();
            reports_Form.MdiParent = this;
            reports_Form.Show();

        }



        private void btnContactUs_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnDeposito.Height;
            pnlNav.Top = btnDeposito.Top;
            btnDeposito.BackColor = Color.FromArgb(46, 51, 73);

            panel3.Hide();
            panel4.Hide();
            panel5.Hide();
            panel6.Hide();
            panel7.Hide();
            panel8.Hide();
            panel9.Hide();
            panel10.Hide();

            Deposit_Form deposit_Form = new Deposit_Form();
            deposit_Form.MdiParent = this;
            deposit_Form.Show();


        }

        private void btnsettings_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnsettings.Height;
            pnlNav.Top = btnsettings.Top;
            btnsettings.BackColor = Color.FromArgb(46, 51, 73);


            CloseReportWindow closeReport = new CloseReportWindow();
            closeReport.Show();


        }

        private void btnDashbord_Leave(object sender, EventArgs e)
        {
            btnDashbord.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnAnalytics_Leave(object sender, EventArgs e)
        {
            btnAnalytics.BackColor = Color.FromArgb(24, 30, 54);
        }


        private void btnContactUs_Leave(object sender, EventArgs e)
        {
            btnDeposito.BackColor = Color.FromArgb(24, 30, 54);
            
        }

        private void btnsettings_Leave(object sender, EventArgs e)
        {
            btnsettings.BackColor = Color.FromArgb(24, 30, 54);
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

        private void btnFiltro_Click(object sender, EventArgs e)
        {

            try
            {
                IntegracionWS.WorldBankWebServiceSoapClient soapClient = new IntegracionWS.WorldBankWebServiceSoapClient();

                int cliente = int.Parse(txtFiltro.Text);

                IntegracionWS.Cuenta cuenta = new IntegracionWS.Cuenta();

                cuenta = soapClient.GetAccountResp(cliente)[0];

                string number = cuenta.ClienteID.ToString();

                if (!string.IsNullOrEmpty(number))
                {

                    MessageBox.Show("Cliente Registrado en Sistema");

                }
                else
                {

                    MessageBox.Show("Cliente NO se encuentra Registrado en Sistema");

                }

                txtFiltro.Text = "Validar Cliente";
            }
            catch (Exception ex)
            {

                log.Error("Error al validar el usuario", ex);
                MessageBox.Show("Usuario no se encuentra en sistema");
            }



        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelMontoActual_Click(object sender, EventArgs e)
        {

        }

        public void addDeposito(int montoDeposito = 0) {

            ConnectionStringSettings config = ConfigurationManager.ConnectionStrings["ConnectionString1"];

            SqlConnection connection = new SqlConnection(config.ConnectionString);
            connection.Open();

            SqlTransaction transact = null;


            int registros = 0;

            int Monto;

            if (montoDeposito == 0) {

                Monto = int.Parse(txtMontoEntrada.Text);

            }
            else 
            {
                Monto = montoDeposito;
            
            }

            try
            {
                SqlCommand addTransaccion = new SqlCommand("addMontoDeposito", connection);
                transact = connection.BeginTransaction();
                addTransaccion = new SqlCommand("addMontoDeposito", connection, transact);

                addTransaccion.Parameters.AddWithValue("@monto_deposito", Monto);

                addTransaccion.CommandType = CommandType.StoredProcedure;
                registros = addTransaccion.ExecuteNonQuery();

                transact.Commit();
                connection.Close();
            }
            catch (Exception ex)
            {
                log.Error("Error al registrar el deposito", ex);
                transact.Rollback();

                MessageBox.Show("Error al registrar el deposito");
            }


            if (registros >= 1)
            {
                log.Info("Se registro el deposito");
                MessageBox.Show("Deposito Registrado!");

            }

            txtMontoSalida.Clear();
            txtMontoEntrada.Clear();

        }

        public void addRetiro(int montoRetiro = 0)
        {

            ConnectionStringSettings config = ConfigurationManager.ConnectionStrings["ConnectionString1"];

            SqlConnection connection = new SqlConnection(config.ConnectionString);
            connection.Open();

            SqlTransaction transact = null;


            int registros = 0;

            int Monto;

            if (montoRetiro == 0)
            {

                Monto = int.Parse(txtMontoSalida.Text);

            }
            else
            {
                Monto = montoRetiro;

            }

            try
            {
                SqlCommand addTransaccion = new SqlCommand("addMontoRetiro", connection);
                transact = connection.BeginTransaction();
                addTransaccion = new SqlCommand("addMontoRetiro", connection, transact);

                addTransaccion.Parameters.AddWithValue("@monto_retiro", Monto);

                addTransaccion.CommandType = CommandType.StoredProcedure;
                registros = addTransaccion.ExecuteNonQuery();

                transact.Commit();
                connection.Close();
            }
            catch (Exception ex)
            {
                log.Error("Error al registrar el Retiro", ex);
                transact.Rollback();

                MessageBox.Show("Error al registrar el Retiro");
            }


            if (registros >= 1)
            {
                log.Info("Se registro el Retiro");
                MessageBox.Show("Retiro Registrado!");

            }

            txtMontoSalida.Clear();
            txtMontoEntrada.Clear();

        }

        private void btnEntradaE_Click(object sender, EventArgs e)
        {
            addDeposito();
        }

        private void btnSalidaE_Click(object sender, EventArgs e)
        {
            addRetiro();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void labelTotalRetiro_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
