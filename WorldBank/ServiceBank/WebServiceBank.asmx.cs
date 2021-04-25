using ServiceBank.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ServiceBank.Models;

namespace ServiceBank
{
    /// <summary>
    /// Summary description for WebServiceBank
    /// </summary>
    [WebService(Namespace = "ServiceBank")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceBank : System.Web.Services.WebService
    {

        [WebMethod]
        public Cliente GetClientResp(string username, string password)
        {
            Cliente client_result = GetServices.GetClient(username, password);
            return client_result;
        }

        [WebMethod]
        public Empleado GetEmployeeResp(string username, string password)
        {
            Empleado employee_result = GetServices.GetEmployee(username, password);
            return employee_result;
        }

        [WebMethod]
        public List<Cuenta> GetAccountResp(int clienteid)
        {
            List<Cuenta> account_result = GetServices.GetAccount(clienteid);
            return account_result;
        }

        [WebMethod]
        public Cuenta GetTUserAccountResp(string cedula, int cuenta)
        {
            Cuenta account_result = GetServices.GetTUserAccount(cedula, cuenta);
            return account_result;
        }

        [WebMethod]
        public List<Transaccione> GetTrasactionsResp(int cuenta)
        {
            List<Transaccione> account_result = GetServices.GetTrasactions(cuenta);
            return account_result;
        }

        [WebMethod]
        public Respuesta UpsertClientResp(ClienteCL reqCliente )
        {
            Respuesta upclient_result = UpsertServices.UpsertClient(reqCliente);

            return upclient_result;
        }

        [WebMethod]
        public Respuesta UpsertAccountResp(CuentaCL cuenta)
        {
            Respuesta upaccount_result = UpsertServices.UpsertAccount(cuenta);

            return upaccount_result;
        }

        [WebMethod]
        public Respuesta UpsertEmployeeResp(EmpleadoCL empleado)
        {
            Respuesta upemployee_result = UpsertServices.UpsertEmployee(empleado);

            return upemployee_result;
        }

        [WebMethod]
        public Respuesta InsertTransactionResp(TransaccioneCL transaccione)
        {
            Respuesta intransac_result = InsertServices.InsertTransaction(transaccione);

            return intransac_result;
        }
    }
}
