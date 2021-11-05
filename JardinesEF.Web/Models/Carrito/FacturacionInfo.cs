using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JardinesEF.Web.Models.Cliente;

namespace JardinesEF.Web.Models.Carrito
{
    public class FacturacionInfo
    {
        [Required(ErrorMessage = "El campo es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un cliente")]
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }
        [Required(ErrorMessage = "Ingrese el nro de tarjeta de crédito")]
        public string TarjetaCreditoNro { get; set; }
        [Required(ErrorMessage = "Ingrese fecha de vencimiento")]
        public string MesVencimiento { get; set; }

        public SelectList Meses()
        {
            return new SelectList(new string[] { "Enero", "Febrero", "Marzo",
                "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre",
                "Noviembre", "Diciembre" });
        }

        [Required(ErrorMessage = "Ingrese fecha de vencimiento")]
        public string AnioVencimiento { get; set; }

        public SelectList Anios()
        {
            return new SelectList(new string[] { "2021", "2022", "2023",
                "2024", "2025", "2026", "2027", "2028", "2029", "2030",
                "2031", "2032" });
        }

        public List<ClienteListVm> Clientes { get; set; }
    }
}