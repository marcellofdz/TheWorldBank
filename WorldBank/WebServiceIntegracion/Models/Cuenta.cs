using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebServiceIntegracion.Models
{
    public class Cuenta
    {
        public int CuentaId { get; set; }

        public int ClienteID { get; set; }

        public int TipoCuentaId { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public double Balance { get; set; }

        [XmlIgnore]
        public int Enabled { get; set; }
    }
}