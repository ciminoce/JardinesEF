using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using JardinesEf.Entidades.Entidades;
using JardinesEF.Web.Models.Ciudad;
using JardinesEF.Web.Models.Pais;

namespace JardinesEF.Web.Classes
{
    public class Mapeador
    {
        public static PaisEditVm ConstruirPaisEditVm(Pais pais)
        {
            return new PaisEditVm()
            {
                PaisId = pais.PaisId,
                NombrePais = pais.NombrePais
            };
        }

        public static Pais ConstruirPais(PaisEditVm paisVm)
        {
            return new Pais()
            {
                PaisId = paisVm.PaisId,
                NombrePais = paisVm.NombrePais
            };
        }

        public static List<PaisListVm> ConstruirListaVm(List<Pais> listaPaises)
        {
            var lista = new List<PaisListVm>();
            foreach (var pais in listaPaises)
            {
                var paisVm = ConstruirPaisVm(pais);
                lista.Add(paisVm);
            }

            return lista;
        }

        public static PaisListVm ConstruirPaisVm(Pais pais)
        {
            return new PaisListVm()
            {
                PaisId = pais.PaisId,
                NombrePais = pais.NombrePais
            };
        }

        public static List<CiudadListVm> ConstruirListaCiudadListVm(List<Ciudad> listaCiudades)
        {
            var lista = new List<CiudadListVm>();
            foreach (var ciudad in listaCiudades)
            {
                var ciudadVm = ConstruirCiudadListVm(ciudad);
                lista.Add(ciudadVm);
            }

            return lista;
        }

        public static CiudadListVm ConstruirCiudadListVm(Ciudad ciudad)
        {
            return new CiudadListVm()
            {
                CiudadId = ciudad.CiudadId,
                NombreCiudad = ciudad.NombreCiudad,
                NombrePais = ciudad.Pais.NombrePais
            };
        }

        public static Ciudad ConstruirCiudad(CiudadEditVm ciudadVm)
        {
            return new Ciudad()
            {
                CiudadId = ciudadVm.CiudadId,
                NombreCiudad = ciudadVm.NombreCiudad,
                PaisId = ciudadVm.PaisId
            };
        }

        public static CiudadEditVm ConstruirCiudadEditVm(Ciudad ciudad)
        {
            return new CiudadEditVm()
            {
                CiudadId = ciudad.CiudadId,
                NombreCiudad = ciudad.NombreCiudad,
                PaisId = ciudad.PaisId
            };
        }

        public static PaisDetailsVm ConstruirPaisDetailsVm(Pais pais)
        {
            return new PaisDetailsVm()
            {
                PaisId = pais.PaisId,
                NombrePais = pais.NombrePais
            };
        }
    }
}