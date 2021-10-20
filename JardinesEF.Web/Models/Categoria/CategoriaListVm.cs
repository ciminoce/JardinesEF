using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JardinesEF.Web.Models.Categoria
{
    public class CategoriaListVm
    {
        public int CategoriaId { get; set; }
        [Display(Name = "Categoría")]
        public string NombreCategoria { get; set; }
        
    }
}