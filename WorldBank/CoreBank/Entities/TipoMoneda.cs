using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBank.Entities
{
    public class TipoMoneda
    {
        public int MonedaId { get; set; }

        public string Nombre { get; set; }

        public int Enabled { get; set; }
    }
}