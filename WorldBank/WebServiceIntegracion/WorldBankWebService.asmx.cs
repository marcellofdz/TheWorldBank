using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

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
        public List<Transaccione> GetTrasactionsResp(int cuenta)
        {
            List<Transaccione> account_result = GetServices.GetTrasactions(cuenta);
            return account_result;
        }

        [WebMethod]
        public Respuesta UpsertClientResp(ClienteCL reqCliente)
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
