using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBank.Entities
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public int RolesId { get; set; }

        public string Nombres { get; set; }
        
        public string Apellidos { get; set; }

        public string Sexo { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public DateTime FechaIngreso { get; set; }

        public int Estado { get; set; }
    }
}
