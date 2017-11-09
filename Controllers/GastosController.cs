using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cashflow.Models;
using Cashflow.ViewModels;
using Microsoft.AspNet.Identity;

namespace Cashflow.Controllers
{   
    [Authorize(Roles = "user")]
    public class GastosController : Controller
    {

        private ApplicationDbContext _context;

        public GastosController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Gastos
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var viewModel = _context.Flujos.Where(f => f.Tipo.Nombre == "Gasto" && f.ApplicationUserId == userId).Include(f => f.Periodo).ToList();

            var title = "Aun no tienes gastos registrados";

            return View(viewModel);
        }

        public ActionResult New()
        {
            var userId = User.Identity.GetUserId();
            var defaultDate = DateTime.Today;
            var nuevoGasto = new Flujo()
            {
                Fecha = defaultDate,
                FechaFin = defaultDate,
                ApplicationUserId = userId
            };

            var periodos = _context.Periodos.ToList();
            var viewModel = new FlujoFormViewModel()
            {
                Flujo = nuevoGasto,
                Periodos = periodos
            };

            return View("GastoForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Flujo flujo)
        {
            if (flujo.Id == 0)
            {
                var userId = User.Identity.GetUserId();
                var tipoIngreso = _context.Tipos.Single(t => t.Nombre == "Gasto");
                flujo.Tipo = tipoIngreso;
                flujo.ApplicationUserId = userId;
                _context.Flujos.Add(flujo);

                _context.SaveChanges();

                var monthUtils = new MonthUtils();
                var montos = monthUtils.GetMonthList(flujo.Fecha, flujo.FechaFin, flujo.PeriodoId - 1,
                    Convert.ToDecimal(flujo.Monto));

                for (var mes = 0; mes < 12; mes++)
                {
                    if (montos[mes] == 0) continue;

                    var newFlujoMensual = new FlujoMensual()
                    {
                        FlujoId = flujo.Id,
                        MesId = Convert.ToByte(mes + 1),
                        Monto = montos[mes]
                    };

                    _context.FlujosMensuales.Add(newFlujoMensual);
                }
            }
            else
            {
                var flujoInDb = _context.Flujos.Single(f => f.Id == flujo.Id);
                flujoInDb.Nombre = flujo.Nombre;
                flujoInDb.Monto = flujo.Monto;
                flujoInDb.Fecha = flujo.Fecha;
                flujoInDb.PeriodoId = flujo.PeriodoId;
                flujoInDb.FechaFin = flujo.FechaFin;

                var monthUtils = new MonthUtils();
                var montos = monthUtils
                    .GetMonthList(flujo.Fecha, flujo.FechaFin, flujo.PeriodoId - 1, Convert.ToDecimal(flujo.Monto));


                for (var mes = 0; mes < 12; mes++)
                {
                    var flujoMensualInDb = _context.FlujosMensuales
                        .Where(fm => fm.MesId == (mes + 1) && fm.FlujoId == flujoInDb.Id)
                        .DefaultIfEmpty(null)
                        .Single();

                    if (flujoMensualInDb == null)
                    {
                        if (montos[mes] == 0) continue;

                        var newFlujoMensual = new FlujoMensual()
                        {
                            FlujoId = flujoInDb.Id,
                            MesId = Convert.ToByte(mes + 1),
                            Monto = montos[mes]
                        };

                        _context.FlujosMensuales.Add(newFlujoMensual);
                    }
                    else
                    {
                        flujoMensualInDb.Monto = montos[mes];
                    }
                }

            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Gastos");
        }

        public ActionResult Edit(int id)
        {
            var ingreso = _context.Flujos.SingleOrDefault(i => i.Id == id);

            if (ingreso == null)
                return HttpNotFound();

            var viewModel = new FlujoFormViewModel()
            {
                Flujo = ingreso,
                Periodos = _context.Periodos.ToList()
            };

            return View("GastoForm", viewModel);
        }
    }
}