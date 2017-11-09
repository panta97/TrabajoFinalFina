using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cashflow.Dtos
{
    public class DetalleAnualDto
    {
        public List<decimal> Ingresos { get; set; }
        public List<decimal> Gastos { get; set; }
    }
}