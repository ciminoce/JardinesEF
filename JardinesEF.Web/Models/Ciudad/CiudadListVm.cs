using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JardinesEF.Web.Models.Ciudad
{
    public class CiudadListVm
    {
        public int CiudadId { get; set; }

        [Display(Name = "Ciudad")]
        public string NombreCiudad { get; set; }

        [Display(Name = "País")]
        public string NombrePais { get; set; }

    }
}