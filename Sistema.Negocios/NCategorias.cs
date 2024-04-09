using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.Datos;
using Sistema.Entidad;

namespace Sistema.Negocios
{
    public class NCategorias
    {
        public static DataTable Listar()
        {
            DCategorias Datos = new DCategorias();
            return Datos.Listar();
        }

        public static DataTable Buscar(string valor)
        {
            DCategorias Datos = new DCategorias();
            return Datos.Buscar(valor);
        }

        public static string Insertar(string nombre, string descripcion)
        {
            DCategorias Datos = new DCategorias();
            // Primero investigamos si la categoria existe
            string existe = Datos.Existe(nombre);
            if (existe == "1")
            {
                return "La categoria ya existe.";
            }
            else
            {
                Categoria obj = new Categoria();
                obj.Nombre = nombre;
                obj.Descripcion = descripcion;
                return Datos.InsertarCategoria(obj);
            }
        }

        public static string Actualizar(int id, string nombreAnterior, string nombre, string descripcion)
        {
            DCategorias Datos = new DCategorias();
            Categoria obj = new Categoria();

            if (nombre == nombreAnterior)
            {
                obj.IdCategoria = id;
                obj.Nombre = nombre;
                obj.Descripcion = descripcion;

                return Datos.Actualizar(obj);
            }
            else
            {
                string existencia = Datos.Existe(nombre);
                if (existencia == "1")
                {
                    return "La categoria existe";
                }
                else
                {
                    obj.IdCategoria = id;
                    obj.Nombre = nombre;
                    obj.Descripcion = descripcion;

                    return Datos.Actualizar(obj);
                }

            }
        }

        public static string Eliminar(int id)
        {
            DCategorias Datos = new DCategorias();
            return Datos.Eliminar(id);
        }

        public static string Activar(int id)
        {
            DCategorias Datos = new DCategorias();
            return Datos.Activar(id);
        }
        public static string Desactivar(int id)
        {
            DCategorias Datos = new DCategorias();
            return Datos.Desactivar(id);
        }

    }
}
