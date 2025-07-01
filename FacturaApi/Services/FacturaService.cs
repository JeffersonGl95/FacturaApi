using FacturaApi.Models;
using FacturaApi.Repositories;

namespace FacturaApi.Services
{
    public class FacturaService
    {
        private readonly IFacturaRepository _repo;

        public FacturaService(IFacturaRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<Factura>> ObtenerTodas() => _repo.ObtenerTodasAsync();
        public Task Crear(Factura f) => _repo.CrearAsync(f);
        public Task Actualizar(Factura f) => _repo.ActualizarAsync(f);
    }
}
