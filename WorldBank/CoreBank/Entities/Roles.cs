using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBank.Entities
{
    public class Roles
    {
        public int RolId { get; set; }

        public string Nombre { get; set; }

        public string Nota { get; set; }

        public int Enabled { get; set; }
    }
}
