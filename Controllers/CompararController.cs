using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Cashflow.Models;
using Microsoft.AspNet.Identity;

namespace Cashflow.Controllers
{

    [Authorize(Roles = "user")]
    public class CompararController : Controller
    {

        private ApplicationDbContext _context;

        public CompararController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Comparar
        public ActionResult Index()
        {

            var userId = User.Identity.GetUserId();

            var ingresosPorMes = _context.FlujosMensuales
                .Where(fm => fm.Flujo.ApplicationUserId == userId && fm.Flujo.TipoId == 1)
                .Select(fm => fm.Monto)
                .DefaultIfEmpty(0)
                .Sum();

            var gastosPorMes = _context.FlujosMensuales
                .Where(fm => fm.Flujo.ApplicationUserId == userId && fm.Flujo.TipoId == 2)
                .Select(fm => fm.Monto)
                .DefaultIfEmpty(0)
                .Sum();

            var total = ingresosPorMes - gastosPorMes;

            return View(total);
        }
    }
}