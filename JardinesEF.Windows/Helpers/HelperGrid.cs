using JardinesEf.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JardinesEF.Windows.Helpers
{
    public class HelperGrid
    {
        public static void LimpiarGrilla(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
        }

        public static DataGridViewRow CrearFila(DataGridView dataGridView)
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dataGridView);
            return r;
        }

        public static void AgregarFila(DataGridView dataGridView, DataGridViewRow r)
        {
            dataGridView.Rows.Add(r);
        }

        public static void BorrarFila(DataGridView dataGridView, DataGridViewRow r)
        {
            dataGridView.Rows.Remove(r);
        }

        public static void SetearFila(DataGridViewRow r, Object obj)
        {
            switch (obj)
            {
                case Pais _:
                    r.Cells[0].Value = ((Pais)obj).NombrePais;
                    break;
                case Categoria _:
                    r.Cells[0].Value = ((Categoria)obj).NombreCategoria;

                    break;
                case Ciudad _:
                    r.Cells[0].Value = ((Ciudad)obj).NombreCiudad;
                    r.Cells[1].Value = ((Ciudad)obj).Pais.NombrePais;

                    break;

                case Cliente _:
                    r.Cells[0].Value = ((Cliente)obj).ApeNombre;
                    r.Cells[1].Value = ((Cliente)obj).Ciudad.NombreCiudad;
                    r.Cells[2].Value = ((Cliente)obj).Pais.NombrePais;

                    break;

                case Proveedor _:
                    r.Cells[0].Value = ((Proveedor)obj).NombreProveedor;
                    r.Cells[1].Value = ((Proveedor)obj).Ciudad.NombreCiudad;
                    r.Cells[2].Value = ((Proveedor)obj).Pais.NombrePais;

                    break;
                case Producto _:
                    r.Cells[0].Value = ((Producto)obj).NombreProducto;
                    r.Cells[1].Value = ((Producto)obj).Categoria.NombreCategoria;
                    r.Cells[2].Value = ((Producto)obj).PrecioUnitario;
                    r.Cells[3].Value = ((Producto)obj).UnidadesEnStock;
                    r.Cells[4].Value = ((Producto)obj).Suspendido;
                    break;
                case Orden _:
                    r.Cells[0].Value = ((Orden)obj).OrdenId;
                    r.Cells[1].Value = ((Orden)obj).FechaCompra;
                    r.Cells[2].Value = ((Orden)obj).Cliente.ApeNombre;
                    r.Cells[3].Value = ((Orden)obj).TotalVenta;
                    break;
                case DetalleOrden _:
                    r.Cells[0].Value = ((DetalleOrden)obj).Producto.NombreProducto;
                    r.Cells[1].Value = ((DetalleOrden)obj).PrecioUnitario.ToString("C");
                    r.Cells[2].Value = ((DetalleOrden)obj).Cantidad;
                    r.Cells[3].Value = ((DetalleOrden)obj).PrecioUnitario*(decimal)((DetalleOrden)obj).Cantidad;

                    break;

                default:
                    break;
            }
            //if (obj is Pais)
            //{
            //    r.Cells[0].Value = ((Pais)obj).NombrePais;
            //} 
            //if (obj is Categoria)
            //{
            //    r.Cells[0].Value = ((Categoria)obj).NombreCategoria;
            //}

            //if (obj is Ciudad)
            //{
            //    r.Cells[0].Value = ((Ciudad) obj).NombreCiudad;
            //    r.Cells[1].Value = ((Ciudad) obj).Pais.NombrePais;
            //}

            //if (obj is Cliente)
            //{
            //    r.Cells[0].Value = ((Cliente)obj).ApeNombre;
            //    r.Cells[1].Value = ((Cliente)obj).Ciudad.NombreCiudad;
            //    r.Cells[2].Value = ((Cliente)obj).Pais.NombrePais;
            //}

            //if (obj is Proveedor)
            //{
            //    r.Cells[0].Value = ((Proveedor)obj).NombreProveedor;
            //    r.Cells[1].Value = ((Proveedor)obj).Ciudad.NombreCiudad;
            //    r.Cells[2].Value = ((Proveedor)obj).Pais.NombrePais;

            //}

            //if (obj is Producto)
            //{
            //    r.Cells[0].Value = ((Producto)obj).NombreProducto;
            //    r.Cells[1].Value = ((Producto)obj).Categoria.NombreCategoria;
            //    r.Cells[2].Value = ((Producto)obj).PrecioUnitario;
            //    r.Cells[3].Value = ((Producto)obj).UnidadesEnStock;
            //    r.Cells[4].Value = ((Producto)obj).Suspendido;
            //}
            r.Tag = obj;
        }

    }
}
