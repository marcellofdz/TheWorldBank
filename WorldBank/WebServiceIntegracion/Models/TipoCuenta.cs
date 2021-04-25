using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceIntegracion.Models
{
    public class TipoCuenta
    {
        public int TipoCuentasId { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int Enabled { get; set; }
    }
}