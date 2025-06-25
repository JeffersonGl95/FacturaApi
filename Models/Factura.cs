namespace FacturaApi.Models
{
    public class Factura
    {
        public int Id { get; set; }
        public required string Identificacion { get; set; }
        public required string Nombre { get; set; }
        public required string NumeroFactura { get; set; }
        public DateTime Fecha { get; set; }
        public required string Proveedor { get; set; }
        public int ProductoId { get; set; }
        public int SubproductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }
        public bool Sincronizada { get; set; }
    }
}
