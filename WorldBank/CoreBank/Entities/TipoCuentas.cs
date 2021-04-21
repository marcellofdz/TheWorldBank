using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBank.Entities
{
    public class TipoCuentas
    {
        public int TipoCuentasId { get; set; }

        public string Nombre { get; set; }
        
        public string Descripcion { get; set; }

        public int Enabled { get; set; }
    }
}
