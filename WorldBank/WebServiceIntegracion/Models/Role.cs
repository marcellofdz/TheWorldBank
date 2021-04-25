using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceIntegracion.Models
{
    public class Role
    {
        public int RolId { get; set; }

        public string Nombre { get; set; }

        public string Nota { get; set; }

        public int Enabled { get; set; }
    }
}