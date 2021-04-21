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

        public string TUsuarioCuenta { get; set; }

        public string TUsuarioCedula { get; set; }

        public string Notas { get; set; }

        public int TipoTranscId { get; set; }

        public int TUsuarioBancoId { get; set; }

        public int TipoMonedaId { get; set; }

        public float Debito { get; set; }

        public float Credito { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaAprobacion { get; set; }

        public string NoAprobacion { get; set; }

        public int TransaccionCompletada { get; set; }
    }
}
