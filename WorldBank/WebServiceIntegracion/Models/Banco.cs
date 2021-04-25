using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceIntegracion.Models
{
    public class Banco
    {
        public int BancoId { get; set; }

        public string Nombre { get; set; }

        public int Enabled { get; set; }
    }
}