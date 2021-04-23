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
		public string Cedula { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string Nombres { get; set; }
		public string Apellidos { get; set; }
		public string Sexo { get; set; }
		public DateTime FechaNacimiento { get; set; }
		public DateTime FechaIngreso { get; set; }
		public string Direccion { get; set; }
		public string Telefono { get; set; }
		public int Estado { get; set; }
	}
}
