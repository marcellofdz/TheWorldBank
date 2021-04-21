using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBank.Entities
{
    public class Cliente
    {
        public int ClienteID { get; set; }

        public int TipoDocumento { get; set; }

        public string Cedula { get; set; }

        public string PasaporteNo { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Sexo { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public DateTime FechaIngreso { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public int Estado { get; set; }

    }
}
