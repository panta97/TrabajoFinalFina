using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Cashflow.Models;

namespace Cashflow.Dtos
{
    public class FlujoDto
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Nombre { get; set; }

        public decimal Monto { get; set; }

        public DateTime Fecha { get; set; }

        public byte TipoId { get; set; }

        public byte PeriodoId { get; set; }

        public PeriodoDto Periodo { get; set; }

//        public string ApplicationUserId { get; set; }

    }
}