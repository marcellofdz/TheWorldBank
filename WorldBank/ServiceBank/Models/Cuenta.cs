using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceBank.Models
{
    public class Cuenta
    {
        public int CuentaId { get; set; }

        public int ClienteID { get; set; }

        public int TipoCuentaId { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public float Balance { get; set; }

        public int Enabled { get; set; }
    }
}