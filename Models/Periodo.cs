using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cashflow.Models
{
    [Table("Periodos")]
    public class Periodo
    {
        public byte Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public short Valor { get; set; }

        public static readonly byte Ninguno = 0;
        public static readonly byte Diario = 1;
        public static readonly byte Semanal = 2;
        public static readonly byte Mensual = 3;
    }
}