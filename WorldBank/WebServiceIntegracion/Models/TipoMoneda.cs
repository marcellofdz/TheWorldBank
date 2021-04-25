﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceIntegracion.Services;

namespace WebServiceIntegracion.Models
{
    public class TipoMoneda
    {
        public int MonedaId { get; set; }

        public string Nombre { get; set; }

        public int Enabled { get; set; }
    }
}