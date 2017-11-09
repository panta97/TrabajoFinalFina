using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cashflow.Models
{
    [Table("Flujos")]
    public class Flujo
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Nombre { get; set; }

        public decimal Monto { get; set; }

        public DateTime Fecha { get; set; }

        public byte TipoId { get; set; }

        public Tipo Tipo { get; set; }

        [Display(Name = "Periodo")]
        public byte PeriodoId { get; set; }

        public Periodo Periodo { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public DateTime? FechaFin { get; set; }


    }
}