using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JardinesEF.Web.Models.Carrito
{
    public class CarritoViewModel
    {
        public CarritoModel Carrito { get; set; }
        public string ReturnUrl { get; set; }

    }
}