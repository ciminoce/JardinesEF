using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using JardinesEF.Web.Models.DetalleOrden;

namespace JardinesEF.Web.Models.Orden
{
    public class OrdenDetailsVm
    {
        [Display(Name = "Vta. No.")]
        public int OrdenId { get; set; }
        public string Cliente { get; set; }
        [Display(Name = "Fecha Compra")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaCompra { get; set; }

        [Display(Name = "Fecha Entrega")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? FechaEntrega { get; set; }

        [Display(Name = "Dirección Envío")]
        public string DireccionEnvio { get; set; }
        
        [Display(Name = "Cod. Postal")]
        public string CodigoPostalEnvio { get; set; }
        [Display(Name = "País")]
        public string Pais  { get; set; }
        public string Ciudad  { get; set; }

        public List<DetalleOrdenListVm>  DetalleOrdenes { get; set; }

        public decimal TotalVenta => DetalleOrdenes.Sum(d => d.PrecioUnitario * (decimal)d.Cantidad);

    }
}