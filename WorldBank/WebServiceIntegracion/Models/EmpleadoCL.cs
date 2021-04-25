using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebServiceIntegracion.Models
{
    public class EmpleadoCL
    {
        [XmlIgnore]
        public int EmpleadoId { get; set; }

        public string Cedula { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public int RoleId { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public string Sexo { get; set; }

        public DateTime FechaNacimiento { get; set; }

        [XmlIgnore]
        public DateTime FechaIngreso { get; set; }

        public int Estado { get; set; }
    }
}