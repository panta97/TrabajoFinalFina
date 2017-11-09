using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cashflow.Models
{
    [Table("FlujosMensuales")]
    public class FlujoMensual
    {
        public int Id { get; set; }

        public byte MesId { get; set; }
        public Mes Mes { get; set; }

        public int FlujoId { get; set; }
        public Flujo Flujo { get; set; }

        public decimal Monto { get; set; }
    }
}