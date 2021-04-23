using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBank.Entities
{
	public class Cuenta
	{
		public int CuentaId { get; set; }
		public int ClienteID { get; set; }
		public int TipoCuentaId { get; set; }
		public DateTime? FechaCreacion { get; set; }
		public double Balance { get; set; }
		public int Enabled { get; set; }
	}
}
