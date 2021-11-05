using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using JardinesEF.Web.Models.Ciudad;
using JardinesEF.Web.Models.Pais;

namespace JardinesEF.Web.Models.Carrito
{
    public class DireccionEnvio
    {
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(100, ErrorMessage = "El campo debe estar comprendido entre {2} y {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(10, ErrorMessage = "El campo debe estar comprendido entre {2} y {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Cód. Postal")]
        public string CodigoPostal { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un país")]
        [Display(Name = "País")]
        public int PaisId { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un ciudad")]
        [Display(Name = "Ciudad")]
        public int CiudadId { get; set; }
        public List<PaisListVm> Paises { get; set; }
        public List<CiudadListVm> Ciudades { get; set; }

    }
}