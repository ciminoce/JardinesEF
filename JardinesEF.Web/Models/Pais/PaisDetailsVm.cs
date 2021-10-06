using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using JardinesEF.Web.Models.Ciudad;

namespace JardinesEF.Web.Models.Pais
{
    public class PaisDetailsVm
    {
        public int PaisId { get; set; }
        [Display(Name = "País")]
        public string NombrePais { get; set; }
        [Display(Name = "Cant. Ciudades")]
        public int CantidadCiudades { get; set; }
        public List<CiudadListVm> Ciudades { get; set; }
    }
}