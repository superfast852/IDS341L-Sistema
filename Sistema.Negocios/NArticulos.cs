using System.Data;
using System.Windows.Forms;
using Sistema.Datos;
using Sistema.Entidad;

namespace Sistema.Negocios
{
    public class NArticulos
    {
        public static DataTable Listar()
        {
            DArticulos Datos = new DArticulos();
            return Datos.Listar();
        }

        public static DataTable Buscar(string valor)
        {
            DArticulos Datos = new DArticulos();
            return Datos.Buscar(valor);
        }

        public static DataTable BuscarCodigo(string valor)
        {
            DArticulos Datos = new DArticulos();
            return Datos.BuscarCodigo(valor);
        }

        // TODO
        public static string Insertar(string nombre, string descripcion, int categoria, string codigo, double precio, int stock, string imagen)
        {
            DArticulos Datos = new DArticulos();
            // Primero investigamos si la categoria existe
            string existe = Datos.Existe(nombre);
            if (existe == "1")
            {
                return "La categoria ya existe.";
            }
            else
            {
                Articulo obj = new Articulo();
                obj.Nombre = nombre;
                obj.Descripcion = descripcion;
                obj.IdCategoria = categoria;
                obj.Codigo = codigo;
                obj.Stock = stock;
                obj.Imagen = imagen;
                obj.PrecioVenta = precio;
                return Datos.Insertar(obj);
            }
        }

        // TODO
        public static string Actualizar(int id, string nombreAnterior, string nombre, string descripcion, int categoria, string codigo, double precio, int stock, string imagen)
        {
            DArticulos Datos = new DArticulos();
            Articulo obj = new Articulo();

            if (nombre == nombreAnterior)  // If we didn't change the name
            {
                obj.IdArticulo = id;
                obj.Nombre = nombre;
                obj.Descripcion = descripcion;
                obj.IdCategoria = categoria;
                obj.Codigo = codigo;
                obj.Stock = stock;
                obj.Imagen = imagen;
                obj.PrecioVenta = precio;
                MessageBox.Show(obj.IdArticulo.ToString());
                return Datos.Actualizar(obj);  // The error happens at Data level.
            }
            else
            {  // If we did, check if the name is already occupied.
                string existencia = Datos.Existe(nombre);
                if (existencia == "1")
                {
                    return "La categoria existe";
                }
                else
                {  // If it isn't, go ahead, we're not overwriting anything.
                    obj.IdArticulo = id;
                    obj.Nombre = nombre;
                    obj.Descripcion = descripcion;
                    obj.IdCategoria = categoria;
                    obj.Codigo = codigo;
                    obj.Stock = stock;
                    obj.Imagen = imagen;
                    obj.PrecioVenta = precio;
                    return Datos.Actualizar(obj);
                }

            }
        }
        public static string Eliminar(int id)
        {
            DArticulos Datos = new DArticulos();
            return Datos.Eliminar(id);
        }
        public static string Activar(int id)
        {
            DArticulos Datos = new DArticulos();
            return Datos.Activar(id);
        }
        public static string Desactivar(int id)
        {
            DArticulos Datos = new DArticulos();
            return Datos.Desactivar(id);
        }
    }
}
