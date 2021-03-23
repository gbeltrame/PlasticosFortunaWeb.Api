using PlasticosFortunaWeb.Api.Models;
using PlasticosFortunaWeb.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace PlasticosFortunaWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenTrabajoController : ControllerBase
    {
        private readonly OrdenTrabajoService _ordenTrabajoService;
        private readonly HistorialOrdenTrabajoService _histOrdenTrabajoService;

        public OrdenTrabajoController(OrdenTrabajoService ordenTrabajoService, HistorialOrdenTrabajoService histOrdenTrabajoService)
        {
            _ordenTrabajoService = ordenTrabajoService;
            _histOrdenTrabajoService = histOrdenTrabajoService;
        }

        [HttpGet]
        public ActionResult<List<OrdenTrabajo>> Get() =>
            _ordenTrabajoService.Get();

        [HttpGet("{id:length(24)}", Name = "GetOrdenTrabajo")]
        public ActionResult<OrdenTrabajo> Get(string id)
        {
            var orden = _ordenTrabajoService.Get(id);

            if (orden == null)
            {
                return NotFound();
            }

            return orden;
        }

        [HttpPost]
        public ActionResult<OrdenTrabajo> Create(OrdenTrabajo orden)
        {
            var ordenCreated = _ordenTrabajoService.Create(orden);

            if (orden == null)
            {
                return BadRequest();
            }
            else
            {
                HistorialOrdenTrabajo hist = new HistorialOrdenTrabajo();
                hist.estado = orden.estado;
                hist.fechaCambio = DateTime.Now;
                hist.idOrden = orden.Id;
                hist.sector = orden.sector;
                _histOrdenTrabajoService.Create(hist);
            }

            return CreatedAtRoute("GetOrdenTrabajo", new { id = orden.Id.ToString() }, orden);
        }

        // [HttpPut("{id:length(24)}")]
        // public IActionResult Update(string id, Book bookIn)
        // {
        //     var book = _bookService.Get(id);

        //     if (book == null)
        //     {
        //         return NotFound();
        //     }

        //     _bookService.Update(id, bookIn);

        //     return NoContent();
        // }

        // [HttpDelete("{id:length(24)}")]
        // public IActionResult Delete(string id)
        // {
        //     var book = _bookService.Get(id);

        //     if (book == null)
        //     {
        //         return NotFound();
        //     }

        //     _bookService.Remove(book.Id);

        //     return NoContent();
        // }
    }
}