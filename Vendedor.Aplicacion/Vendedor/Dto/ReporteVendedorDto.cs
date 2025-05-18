
using Vendedor.Aplicacion.Comun;

namespace Vendedor.Aplicacion.Vendedor.Dto
{
    public class ReporteVendedorDto
    {
        public Guid Idvendedor { get; set; }
        public int Idtipodocumento { get; set; }
        public string Numerodocumento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public decimal Valortotal { get; set; }
        public string Nombrepais { get; set; }
        public string Moneda { get; set; }
        public string Acronimomoneda { get; set; }
        public string Region { get; set; }
        public string Ciudad { get; set; }
        public string Zona { get; set; }
        public int Idproducto { get; set; }
        public string Producto { get; set; }
        public string Categoria { get; set; }
        public int Cantidad { get; set; }
        public decimal Preciounitario { get; set; }
        public decimal Totalproducto { get; set; }
    }

    public class Encabezado
    {
        public Guid Idvendedor { get; set; }
        public int Idtipodocumento { get; set; }
        public string Numerodocumento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public decimal Valortotal { get; set; }
        public string Nombrepais { get; set; }
        public string Moneda { get; set; }
        public string Acronimomoneda { get; set; }
        public string Region { get; set; }
        public string Ciudad { get; set; }
        public string Zona { get; set; }

    }

    public class Detalle
    {
        public int Idproducto { get; set; }
        public string Producto { get; set; }
        public string Categoria { get; set; }
        public int Cantidad { get; set; }
        public decimal Preciounitario { get; set; }
        public decimal Totalproducto { get; set; }
    };

    public class ReporteVendedorOut : BaseOut
    {
        public Encabezado Encabezado { get; set; }
        public List<Detalle> Detalle { get; set; }

    }
}
