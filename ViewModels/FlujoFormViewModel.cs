using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cashflow.Models;

namespace Cashflow.ViewModels
{
    public class FlujoFormViewModel
    {
        public Flujo Flujo { get; set; }

        public IEnumerable<Periodo> Periodos { get; set; }  
    }
}