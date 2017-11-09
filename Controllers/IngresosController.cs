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
    public class IngresosController : Controller
    {

        private ApplicationDbContext _context;

        public IngresosController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Ingresos
        public ActionResult Index()
        {
//            var userId = User.Identity.GetUserId();
//            var viewModel = _context.Flujos.Where(f => f.Tipo.Nombre == "Ingreso" && f.ApplicationUserId == userId).Include(f => f.Periodo).ToList();

            return View();

        }

        public ActionResult New()
        {
            var userId = User.Identity.GetUserId();
            //bootstrap datepicker
            var defaultDate = DateTime.Today;
            var nuevoIngreso = new Flujo()
            {
                Fecha = defaultDate,
                FechaFin = defaultDate,
                ApplicationUserId = userId
                
            };

            var periodos = _context.Periodos.ToList();
            var viewModel = new FlujoFormViewModel()
            {
                Flujo = nuevoIngreso,
                Periodos = periodos
            };

            return View("IngresoForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Flujo flujo)
        {
            //si el periodo es ninguno
            if (flujo.PeriodoId == 1)
                flujo.FechaFin = flujo.Fecha;

            if (flujo.Id == 0)
            {
                //tabla flujos
                var userId = User.Identity.GetUserId();
                var tipoIngreso = _context.Tipos.Single(t => t.Nombre == "Ingreso");
                flujo.Tipo = tipoIngreso;
                flujo.ApplicationUserId = userId;
                _context.Flujos.Add(flujo);


                //para obtener el id
                _context.SaveChanges();

                //tabla flujos mesuales

                var monthUtils = new MonthUtils();
                var montos = monthUtils
                    .GetMonthList(flujo.Fecha, flujo.FechaFin, flujo.PeriodoId - 1, Convert.ToDecimal(flujo.Monto));


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

                //tabla flujomensual
                var monthUtils = new MonthUtils();
                var montos = monthUtils
                    .GetMonthList(flujo.Fecha, flujo.FechaFin, flujo.PeriodoId - 1, Convert.ToDecimal(flujo.Monto));

                var flujosMensualesInDb = _context.FlujosMensuales
                    .Where(fm => fm.FlujoId == flujo.Id).ToList();
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

            return RedirectToAction("Index", "Ingresos");
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

            return View("IngresoForm", viewModel);
        }
    }
}