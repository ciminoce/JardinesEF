using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JardinesEF.Web.Models.Cliente
{
    public class ClienteListVm
    {
        public int ClienteId { get; set; }
        public string Nombres { get; set; }
        public string Apellido { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }

    }
}