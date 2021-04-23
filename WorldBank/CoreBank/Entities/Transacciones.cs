using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBank.Entities
{
	public class Transacciones
	{
		public int TransacId { get; set; }
		public int ClienteId { get; set; }
		public int CuentaId { get; set; }
		public int? TUsuarioCuenta { get; set; }
		public string TUsuarioCedula { get; set; }
		public string Notas { get; set; }
		public int TipoTransacId { get; set; }
		public int TUsuarioBancoId { get; set; }
		public int? TipoMonedaId { get; set; }
		public double? Debito { get; set; }
		public double? Credito { get; set; }
		public DateTime FechaCreacion { get; set; }
		public DateTime? FechaAprobacion { get; set; }
		public string NoAprobacion { get; set; }
		public int TransaccionCompletada { get; set; }
	}
}
