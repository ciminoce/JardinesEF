using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using JardinesEF.Web.Models.Pais;

namespace JardinesEF.Web.Models.Ciudad
{
    public class CiudadEditVm
    {
        public int CiudadId { get; set; }

        [Display(Name = "Ciudad")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string NombreCiudad { get; set; }

        [Display(Name = "País")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1,int.MaxValue,ErrorMessage = "Debe seleccionar un país")]
        public int PaisId { get; set; }
        
        public PaisListVm Pais { get; set; }
        public List<PaisListVm> Paises { get; set; }

    }
}