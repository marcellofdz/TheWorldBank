using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebServiceIntegracion.Models;
using WebServiceIntegracion.Services;

namespace WebServiceIntegracion
{
    /// <summary>
    /// Summary description for WorldBankWebService
    /// </summary>
    [WebService(Namespace = "http://TheWorldBank.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WorldBankWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public CoreWS.Cliente GetClientResp(string username, string password)
        {
            CoreWS.WebServiceBankSoapClient core = new CoreWS.WebServiceBankSoapClient();

            
            CoreWS.Cliente client_result = core.GetClientResp(username, password);

            return client_result;
        }

        [WebMethod]
        public CoreWS.Empleado GetEmployeeResp(string username, string password)
        {
            CoreWS.WebServiceBankSoapClient core = new CoreWS.WebServiceBankSoapClient();

            CoreWS.Empleado employee_result = core.GetEmployeeResp(username, password);
            return employee_result;
        }

        [WebMethod]
        public CoreWS.Cuenta[] GetAccountResp(int clienteid)
        {
            CoreWS.WebServiceBankSoapClient core = new CoreWS.WebServiceBankSoapClient();
            CoreWS.Cuenta[] account_result = core.GetAccountResp(clienteid);
            return account_result;
        }

        [WebMethod]
        public CoreWS.Cuenta GetTUserAccountResp(string cedula, int cuenta)
        {
            CoreWS.WebServiceBankSoapClient core = new CoreWS.WebServiceBankSoapClient();
            CoreWS.Cuenta account_result = core.GetTUserAccountResp(cedula, cuenta);
            return account_result;
        }

        [WebMethod]
        public CoreWS.Transaccione[] GetTrasactionsResp(int cuenta)
        {
            CoreWS.WebServiceBankSoapClient core = new CoreWS.WebServiceBankSoapClient();
            CoreWS.Transaccione[] account_result = core.GetTrasactionsResp(cuenta);
            return account_result;
        }

        [WebMethod]
        public CoreWS.Respuesta UpsertClientResp(CoreWS.ClienteCL reqCliente)
        {
            CoreWS.WebServiceBankSoapClient core = new CoreWS.WebServiceBankSoapClient();
            CoreWS.Respuesta upclient_result = core.UpsertClientResp(reqCliente);

            return upclient_result;
        }

        [WebMethod]
        public CoreWS.Respuesta UpsertAccountResp(CoreWS.CuentaCL cuenta)
        {
            CoreWS.WebServiceBankSoapClient core = new CoreWS.WebServiceBankSoapClient();
            CoreWS.Respuesta upaccount_result = core.UpsertAccountResp(cuenta);

            return upaccount_result;
        }

        [WebMethod]
        public CoreWS.Respuesta UpsertEmployeeResp(CoreWS.EmpleadoCL empleado)
        {
            CoreWS.WebServiceBankSoapClient core = new CoreWS.WebServiceBankSoapClient();
            CoreWS.Respuesta upemployee_result = core.UpsertEmployeeResp(empleado);

            return upemployee_result;
        }

        [WebMethod]
        public CoreWS.Respuesta InsertTransactionResp(CoreWS.TransaccioneCL transaccione)
        {
            CoreWS.WebServiceBankSoapClient core = new CoreWS.WebServiceBankSoapClient();
            CoreWS.Respuesta intransac_result = core.InsertTransactionResp(transaccione);

            return intransac_result;
        }

    }
}
