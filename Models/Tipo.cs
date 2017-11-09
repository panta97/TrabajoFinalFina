using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cashflow.Models
{
    [Table("Tipos")]
    public class Tipo
    {
        public byte Id { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}