using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace ServiceBank.Models
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }

        public string Cedula { get; set; }

        public string Username { get; set; }

        [XmlIgnore]
        public string Password { get; set; }

        public int RoleId { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public string Sexo { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public DateTime FechaIngreso { get; set; }

        [XmlIgnore]
        public int Estado { get; set; }
    }
}