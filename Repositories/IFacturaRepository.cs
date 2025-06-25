namespace FacturaApi.Repositories
{
    using FacturaApi.Models;

    public interface IFacturaRepository
    {
        Task<IEnumerable<Factura>> ObtenerTodasAsync();
        Task<Factura> ObtenerPorIdAsync(int id);
        Task CrearAsync(Factura factura);
        Task ActualizarAsync(Factura factura);
    }
}
