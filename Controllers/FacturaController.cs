using FacturaApi.Models;
using FacturaApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace FacturaApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class FacturaController : ControllerBase
    {
        private readonly FacturaService _service;

        public FacturaController(FacturaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> Get() =>
            Ok(await _service.ObtenerTodas());

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] List<Factura> facturas)
        {
            foreach (var f in facturas)
            {
                await _service.Crear(f);
            }

            return Ok(new { total = facturas.Count });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Factura factura)
        {
            if (id != factura.Id) return BadRequest();
            await _service.Actualizar(factura);
            return NoContent();
        }
    }
}
