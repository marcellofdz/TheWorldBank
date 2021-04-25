using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceBank.Models
{
    public class TipoTransaccione
    {
        public int TipoTransacId { get; set; }

        public string Nombre { get; set; }

        public string Nota { get; set; }

        public int Enabled { get; set; }
    }
}