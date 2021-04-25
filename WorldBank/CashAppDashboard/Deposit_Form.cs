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
    public partial class Deposit_Form : Form
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

        public Deposit_Form()
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

           // IntegracionWS.WorldBankWebServiceSoapClient soapClient = new IntegracionWS.WorldBankWebServiceSoapClient();

            //string cliente = "001";

            //string respuesta = soapClient.GetDataPaciente(cliente);

            var dataSource = new List<Account>();

            dataSource.Add(new Account() { Name = "Deposito", Value = "deposito" });
            dataSource.Add(new Account() { Name = "Retiro", Value = "retiro" });

            //Setup data binding
            this.cbTransaccion.DataSource = dataSource;
            this.cbTransaccion.DisplayMember = "Name";
            this.cbTransaccion.ValueMember = "Value";

            // make it readonly
            this.cbTransaccion.DropDownStyle = ComboBoxStyle.DropDownList;

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

        private bool getServer()
        {
            
            try
            {
                IntegracionWS.WorldBankWebServiceSoapClient soapClient = new IntegracionWS.WorldBankWebServiceSoapClient();

                IntegracionWS.Empleado respuesta = soapClient.GetEmployeeResp("poi", "456");

                return true;
            }
            catch (Exception ex)
            {

                log.Error("Servidor Caido", ex);

                return false;

            }

        }



         public void OnTimedEvent()
         {

            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(1);
            bool server = false;

            var timer = new System.Threading.Timer((e) =>
            {
                server = getServer();

                if (server)
                {
                    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString);
                    
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Transacciones WHERE Estado = 0;", connection);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        addOfflineTransaccion(int.Parse(reader["Id"].ToString()), reader["Cedula_Cliente"].ToString(), reader["Cuenta"].ToString(), reader["Tipo_Transaccion"].ToString(),
                            int.Parse(reader["Monto"].ToString()), bool.Parse(reader["Estado"].ToString()));
                    }
                    connection.Close();
                }

            }, null, startTimeSpan, periodTimeSpan);


        
         }

        private void addOfflineTransaccion(int ID, string Cedula_Cliente, string Cuenta, string Tipo_Transaccion, int Monto, bool Estado = true)
        {

            ConnectionStringSettings config = ConfigurationManager.ConnectionStrings["ConnectionString1"];

            SqlConnection connection = new SqlConnection(config.ConnectionString);
            connection.Open();

            SqlTransaction transact = null;


            int registros = 0;

            SqlCommand addTransaccion = new SqlCommand("updateTransaccion", connection);

            int ServerTipo_Transaccion = 0;
            int Debito = 0;
            int Credito = 0;


            bool server = getServer();

            if (!server)
            {

                Estado = false;

                OnTimedEvent();

            }
            else 
            {


                try
                {

                    if (Tipo_Transaccion == "Retiro")
                    {

                        ServerTipo_Transaccion = 1;
                        Debito = Monto;
                        ServerTipo_Transaccion = 2;

                    }
                    else if (Tipo_Transaccion == "Deposito")
                    {
                        ServerTipo_Transaccion = 2;
                        Credito = Monto;
                        ServerTipo_Transaccion = 1;
                    }

                    IntegracionWS.WorldBankWebServiceSoapClient soapClient = new IntegracionWS.WorldBankWebServiceSoapClient();

                    IntegracionWS.TransaccioneCL transaccione = new IntegracionWS.TransaccioneCL();

                    
                    transaccione.ClienteId = int.Parse(Cedula_Cliente);
                    transaccione.CuentaId = int.Parse(Cuenta);
                    transaccione.TUsuarioCuenta = int.Parse(Cuenta);
                    transaccione.TipoTransacId = ServerTipo_Transaccion;
                    transaccione.TUsuarioBancoId = 1;
                    transaccione.TipoMonedaId = 1;
                    transaccione.Debito = Debito;
                    transaccione.Credito = Credito;
                    transaccione.TUsuarioId = int.Parse(Cedula_Cliente);

                    IntegracionWS.Respuesta respuesta = soapClient.InsertTransactionResp(transaccione);


                    transact = connection.BeginTransaction();
                    addTransaccion = new SqlCommand("updateTransaccion", connection, transact);

                    addTransaccion.Parameters.AddWithValue("@Id", ID);

                    addTransaccion.CommandType = CommandType.StoredProcedure;
                    registros = addTransaccion.ExecuteNonQuery();

                    transact.Commit();
                    connection.Close();

                }
                catch (Exception ex)
                {
                    log.Error($"Error al actualizar la transaccion {ID}", ex);
                    transact.Rollback();


                }


                if (registros >= 1)
                {


                    log.Info($"Se actualizo la transaccion {ID} una transaccion");

                }


            }



        }

        private void addTransaccion()
        {

            ConnectionStringSettings config = ConfigurationManager.ConnectionStrings["ConnectionString1"];

            SqlConnection connection = new SqlConnection(config.ConnectionString);
            connection.Open();

            SqlTransaction transact = null;


            int registros = 0;


            string Cedula_Cliente;
            string Cuenta;
            string Tipo_Transaccion;
            int Monto;
            bool Estado;

         

            Cedula_Cliente = txtCedula.Text;

            Cuenta = cbCuenta.Text;
            Monto = int.Parse(txtMonto.Text);
            Tipo_Transaccion = cbTransaccion.Text;
            Estado = true;





            int ServerTipo_Transaccion = 0;
            int Debito = 0;
            int Credito = 0;




            bool server = getServer();

            if (!server)
            {

                Estado = false;

                OnTimedEvent();

            }

            try
            {
                SqlCommand addTransaccion = new SqlCommand("addTransaccion", connection);
                transact = connection.BeginTransaction();
                addTransaccion = new SqlCommand("addTransaccion", connection, transact);

                addTransaccion.Parameters.AddWithValue("@Cedula_Cliente", Cedula_Cliente);
                addTransaccion.Parameters.AddWithValue("@Cuenta", Cuenta);
                addTransaccion.Parameters.AddWithValue("@Monto", Monto);
                addTransaccion.Parameters.AddWithValue("@Tipo_Transaccion", Tipo_Transaccion);
                addTransaccion.Parameters.AddWithValue("@Estado", Estado);

                addTransaccion.CommandType = CommandType.StoredProcedure;
                registros = addTransaccion.ExecuteNonQuery();

                transact.Commit();
                connection.Close();

                Dashboard_Form dashboard_Form = new Dashboard_Form();

                if (Tipo_Transaccion == "Retiro")
                {
                    dashboard_Form.addRetiro(Monto);
                    ServerTipo_Transaccion = 1;
                    Debito = Monto;
                    ServerTipo_Transaccion = 2;

                } else if (Tipo_Transaccion == "Deposito") {

                    dashboard_Form.addDeposito(Monto);
                    ServerTipo_Transaccion = 2;
                    Credito = Monto;
                    ServerTipo_Transaccion = 1;
                }


            }
            catch (Exception ex)
            {
                log.Error("Error al registrar la transaccion", ex);
                transact.Rollback();

                MessageBox.Show("Error al registra la transaccion");
            }

            IntegracionWS.WorldBankWebServiceSoapClient soapClient = new IntegracionWS.WorldBankWebServiceSoapClient();

            IntegracionWS.TransaccioneCL transaccione = new IntegracionWS.TransaccioneCL();

            transaccione.ClienteId = int.Parse(Cedula_Cliente);
            transaccione.CuentaId = int.Parse(Cuenta);
            transaccione.TUsuarioCuenta = int.Parse(Cuenta);
            transaccione.TipoTransacId = ServerTipo_Transaccion;
            transaccione.TUsuarioBancoId = 1;
            transaccione.TipoMonedaId = 1;
            transaccione.Debito = Debito;
            transaccione.Credito = Credito;
            transaccione.TUsuarioId = int.Parse(Cedula_Cliente);

            IntegracionWS.Respuesta respuesta =  soapClient.InsertTransactionResp(transaccione);



            if (registros >= 1)
            {

                MessageBox.Show("Transaccion Registrada!");
                log.Info("Se registro una transaccion");

            }

            txtCedula.Clear();

            cbCuenta.Text = "";
            txtMonto.Clear();

        }



        private void btnFiltro_Click(object sender, EventArgs e)
        {
            

            Dashboard_Form dashboard_Form = new Dashboard_Form();

            int Monto = int.Parse(txtMonto.Text);

            string tipo = cbTransaccion.Text;


            addTransaccion();




        }

        private void checkCedula_CheckedChanged(object sender, EventArgs e)
        {

            IntegracionWS.WorldBankWebServiceSoapClient soapClient = new IntegracionWS.WorldBankWebServiceSoapClient();

            int cliente = int.Parse(txtCedula.Text);

            IntegracionWS.Cuenta[] cuentas = soapClient.GetAccountResp(cliente);

            var dataSource = new List<Account>();

            foreach (IntegracionWS.Cuenta cuenta in cuentas)
            {
                dataSource.Add(new Account() { Name = cuenta.CuentaId.ToString(), Value = cuenta.CuentaId.ToString() });

            }


            this.cbCuenta.DataSource = dataSource;
            this.cbCuenta.DisplayMember = "Name";
            this.cbCuenta.ValueMember = "Value";

           this.cbTransaccion.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
