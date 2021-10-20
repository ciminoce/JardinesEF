using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JardinesEF.Web.Models.Categoria
{
    public class CategoriaEditVm
    {
        public int CategoriaId { get; set; }

        [Display(Name = "Categoría")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(100,ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres",MinimumLength = 3)]
        public string NombreCategoria { get; set; }

        [Display(Name = "Descripción")]
        [MaxLength(255, ErrorMessage = "El campo {0} no puede contener más de {1} carecteres")]
        public string Descripcion { get; set; }

    }
}