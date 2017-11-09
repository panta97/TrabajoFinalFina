using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Cashflow.Dtos;
using Cashflow.Models;
using Microsoft.AspNet.Identity;

namespace Cashflow.Controllers.Api
{
    public class GastosController : ApiController
    {
        private ApplicationDbContext _context;

        public GastosController()
        {
            _context = new ApplicationDbContext();
        }

        [Route("api/gastos/user/{userId}")]
        public IEnumerable<FlujoDto> GetIngresoByUser(string userId)
        {
            var gastos = _context.Flujos
                .Include(f => f.Periodo)
                .Where(f => f.TipoId == 2 && f.ApplicationUserId == userId)
                .ToList()
                .Select(Mapper.Map<Flujo, FlujoDto>);

            return gastos;
        }

        public IEnumerable<FlujoDto> GetGastos()
        {
            var gastos = _context.Flujos.Where(f => f.TipoId == 2)
                .ToList()
                .Select(Mapper.Map<Flujo, FlujoDto>);
            return gastos;
        }

        public IHttpActionResult GetGasto(int id)
        {
            var usedId = User.Identity.GetUserId();
            var gasto = _context.Flujos.Where(f => f.ApplicationUserId == usedId).SingleOrDefault(f => f.Id == id);

            if (gasto == null)
                return NotFound();

            return Ok(Mapper.Map<Flujo, FlujoDto>(gasto));
        }

        [HttpPost]
        public IHttpActionResult CreateGasto(FlujoDto gastoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            gastoDto.TipoId = 2;

            var gasto = Mapper.Map<FlujoDto, Flujo>(gastoDto);
            _context.Flujos.Add(gasto);
            _context.SaveChanges();

            gastoDto.Id = gasto.Id;

            return Created(new Uri(Request.RequestUri + "/" + gasto.Id), gastoDto);
        }

        [HttpPut]
        public void UpdateGasto(int id, FlujoDto flujoDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var flujoInDb = _context.Flujos.SingleOrDefault(f => f.Id == id);

            if (flujoInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map<FlujoDto, Flujo>(flujoDto, flujoInDb);
            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteGasto(int id)
        {
            var flujoIndb = _context.Flujos.SingleOrDefault(f => f.Id == id);

            if(flujoIndb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Flujos.Remove(flujoIndb);
            _context.SaveChanges();
        }
    }
}
