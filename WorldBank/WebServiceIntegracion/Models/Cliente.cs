using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using WebServiceIntegracion.Models;
using WebServiceIntegracion.Services;

namespace WebServiceIntegracion.Models
{
    public class Cliente
    {
        public int ClienteID { get; set; }

        public string Cedula { get; set; }

        public string Username { get; set; }

        [XmlIgnore]
        public string Password { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public string Sexo { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public DateTime FechaIngreso { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        [XmlIgnore]
        public int Estado { get; set; }
    }
}