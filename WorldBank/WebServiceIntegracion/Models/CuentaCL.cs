﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using WebServiceIntegracion.Services;
using WebServiceIntegracion.Models;

namespace WebServiceIntegracion.Models
{
    public class CuentaCL
    {
        [XmlIgnore]
        public int CuentaId { get; set; }

        public int ClienteID { get; set; }

        public int TipoCuentaId { get; set; }

        [XmlIgnore] 
        public DateTime? FechaCreacion { get; set; }

        [XmlIgnore] 
        public double Balance { get; set; }

        public int Enabled { get; set; }
    }
}