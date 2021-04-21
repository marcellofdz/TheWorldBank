using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBank.Entities
{
    public class Cuenta
    {
        public int CuentaID { get; set; }

        public int ClienteId { get; set; }

        public int TipoCuentaId { get; set; }

        public DateTime FechaCreacion;

        public float Balance { get; set; }

        public int Enabled { get; set; }
    }
}
