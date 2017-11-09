using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cashflow.Dtos
{
    public class PeriodoDto
    {
        public byte Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public short Valor { get; set; }
    }
}