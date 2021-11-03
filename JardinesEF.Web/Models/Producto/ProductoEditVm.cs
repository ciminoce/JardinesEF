using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using JardinesEF.Web.Models.Categoria;
using JardinesEF.Web.Models.Proveedor;

namespace JardinesEF.Web.Models.Producto
{
    public class ProductoEditVm
    {
        public int ProductoId { get; set; }

        [Display(Name = "Producto")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(100,ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres",MinimumLength = 3)]
        public string NombreProducto { get; set; }
        [Display(Name = "Nombre en Latín")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe contener no más de 100 caracteres")]
        public string NombreLatin { get; set; }


        [Required(ErrorMessage = "El campo es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un proveedor")]
        [Display(Name = "Proveedor")]
        public int ProveedorId { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una categoría")]
        [Display(Name = "Categoría")]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [Display(Name = "Precio Vta")]
        public decimal PrecioUnitario { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [Display(Name = "Stock")]
        public int UnidadesEnStock { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [Display(Name = "Nivel Reposición")]
        public int NivelDeReposicion { get; set; }
        public bool Suspendido { get; set; }
        
        [DataType(DataType.ImageUrl)]
        public string Imagen { get; set; }

        public HttpPostedFileBase ImagenFile { get; set; }

        public string NombreProveedor { get;  }
        public List<ProveedorComboVm> Proveedores { get; set; }
        public string NombreCategoria { get; }
        public List<CategoriaListVm> Categorias { get; set; }
    }
}