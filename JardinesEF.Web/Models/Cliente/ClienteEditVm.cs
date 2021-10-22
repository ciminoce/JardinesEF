using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using JardinesEF.Web.Models.Ciudad;
using JardinesEF.Web.Models.Pais;

namespace JardinesEF.Web.Models.Cliente
{
    public class ClienteEditVm
    {
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(50,ErrorMessage = "El campo debe estar comprendido entre {2} y {1} caracteres",MinimumLength = 3)]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(50, ErrorMessage = "El campo debe estar comprendido entre {2} y {1} caracteres", MinimumLength = 3)]

        public string Apellido { get; set; }
        [MaxLength(100, ErrorMessage = "El campo no puede contener más de {1} caracteres")]
        [Display(Name = "Dirección")]

        public string Direccion { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(10, ErrorMessage = "El campo debe estar comprendido entre {2} y {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Cód. Postal")]

        public string CodigoPostal { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [Range(1,int.MaxValue,ErrorMessage = "Debe seleccionar un páis")]
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