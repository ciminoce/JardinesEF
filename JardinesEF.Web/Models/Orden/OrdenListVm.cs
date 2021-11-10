using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using JardinesEf.Entidades.Entidades;

namespace JardinesEF.Web.Models.Orden
{
    public class OrdenListVm
    {
        [Display(Name = "Vta. No.")]
        public int OrdenId { get; set; }
        public string Cliente { get; set; }
        [Display(Name = "Fecha Compra")]
        public DateTime FechaCompra { get; set; }
        
        [Display(Name = "Fecha Entrega")]
        public DateTime? FechaEntrega { get; set; }
        //public List<DetalleOrdenListVm> listaItems { get; set; } = new List<DetalleOrdenListVm>();

        //public decimal TotalVenta => listaItems.Sum(d => d.PrecioUnitario * (decimal)d.Cantidad);

    }
}