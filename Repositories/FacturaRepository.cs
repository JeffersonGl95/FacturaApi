namespace FacturaApi.Repositories
{
    using FacturaApi.Data;
    using FacturaApi.Models;
    using Microsoft.EntityFrameworkCore;

    public class FacturaRepository : IFacturaRepository
    {
        private readonly FacturaDbContext _context;

        public FacturaRepository(FacturaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Factura>> ObtenerTodasAsync() =>
            await _context.Facturas.ToListAsync();

        public async Task<Factura> ObtenerPorIdAsync(int id) =>
            await _context.Facturas.FindAsync(id);

        public async Task CrearAsync(Factura factura)
        {
            _context.Facturas.Add(factura);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Factura factura)
        {
            _context.Entry(factura).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
