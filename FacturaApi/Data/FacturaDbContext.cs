namespace FacturaApi.Data
{
    using Microsoft.EntityFrameworkCore;
    using FacturaApi.Models;

    public class FacturaDbContext : DbContext
    {
        public FacturaDbContext(DbContextOptions<FacturaDbContext> options) : base(options) { }

        public DbSet<Factura> Facturas { get; set; }
    }
}
