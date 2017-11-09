using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cashflow.Models
{
    [Table("Meses")]
    public class Mes
    {
        public byte Id { get; set; }
        public string Nombre { get; set; }
    }
}