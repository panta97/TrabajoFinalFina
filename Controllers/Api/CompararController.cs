using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cashflow.Dtos;
using Cashflow.Models;

namespace Cashflow.Controllers.Api
{
    public class CompararController : ApiController
    {
        private ApplicationDbContext _context;

        public CompararController()
        {
            _context = new ApplicationDbContext();
        }
        

        [Route("api/comparar/{year}/{userId}")]
        public DetalleAnualDto GetFlujosByYear(int year, string userId)
        {

            DateTime firstDay = new DateTime(year, 1, 1);


            List<decimal> ingresos = new List<decimal>();
            List<decimal> gastos = new List<decimal>();

            for (var m = firstDay.Month; m <= 12; m++)
            {

                var ingresosPorMes = _context.FlujosMensuales
                    .Where(fm => fm.Flujo.Fecha.Year == year)
                    .Where(fm => fm.Flujo.ApplicationUserId == userId && fm.Flujo.TipoId == 1 && fm.MesId == m)
                    .Select(fm => fm.Monto)
                    .DefaultIfEmpty(0)
                    .Sum();

                var gastosPorMes = _context.FlujosMensuales
                    .Where(fm => fm.Flujo.Fecha.Year == year)
                    .Where(fm => fm.Flujo.ApplicationUserId == userId && fm.Flujo.TipoId == 2 && fm.MesId == m)
                    .Select(fm => fm.Monto)
                    .DefaultIfEmpty(0)
                    .Sum();

                ingresos.Add(ingresosPorMes);
                gastos.Add(gastosPorMes);
            }

            var detalle = new DetalleAnualDto()
            {
                Ingresos = ingresos,
                Gastos = gastos
            };

            return detalle;
        }
    }
}
