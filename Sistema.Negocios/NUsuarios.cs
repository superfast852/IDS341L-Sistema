using System.Data;
using Sistema.Datos;
using Sistema.Entidad;

namespace Sistema.Negocios
{
    public class NUsuarios
    {
        public static DataTable Login(string email, string clave)
        {
            DUsuarios Datos = new DUsuarios();
            return Datos.Login(email, clave);
        }

        public static DataTable Listar()
        {
            DUsuarios Datos = new DUsuarios();
            return Datos.Listar();
        }

        public static DataTable Buscar(string valor)
        {
            DUsuarios Datos = new DUsuarios();
            return Datos.Buscar(valor);
        }

        // TODO
        public static string Insertar(string nombre, int idrol, string email, string clave, string tipoDocumento, string documento, string telefono, string direccion)
        {
            DUsuarios Datos = new DUsuarios();
            // Primero investigamos si la categoria existe
            string existe = Datos.Existe(nombre);
            if (existe == "1")
            {
                return "La categoria ya existe.";
            }
            else
            {
                Usuario obj = new Usuario();
                obj.Nombre = nombre;
                obj.IdRol = idrol;
                obj.Email = email;
                obj.Clave = clave;
                obj.TipoDocumento = tipoDocumento;
                obj.Documento = documento;
                obj.Telefono = telefono;
                obj.Direccion = direccion;
                return Datos.Insertar(obj);
            }
        }

        // TODO
        public static string Actualizar(int id, string nombreAnterior, string nombre, int idrol, string email, string clave, string tipoDocumento, string documento, string telefono, string direccion)
        {
            DUsuarios Datos = new DUsuarios();
            Usuario obj = new Usuario();

            if (nombre == nombreAnterior)  // If we didn't change the 
            {
                obj.IdUsuario = id;
                obj.Nombre = nombre;
                obj.IdRol = idrol;
                obj.Email = email;
                obj.Clave = clave;
                obj.TipoDocumento = tipoDocumento;
                obj.Documento = documento;
                obj.Telefono = telefono;
                obj.Direccion = direccion;
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
                    obj.IdUsuario = id;
                    obj.Nombre = nombre;
                    obj.IdRol = idrol;
                    obj.Email = email;
                    obj.Clave = clave;
                    obj.TipoDocumento = tipoDocumento;
                    obj.Documento = documento;
                    obj.Telefono = telefono;
                    obj.Direccion = direccion;
                    return Datos.Actualizar(obj);
                }

            }
        }
        public static string Eliminar(int id)
        {
            DUsuarios Datos = new DUsuarios();
            return Datos.Eliminar(id);
        }
        public static string Activar(int id)
        {
            DUsuarios Datos = new DUsuarios();
            return Datos.Activar(id);
        }
        public static string Desactivar(int id)
        {
            DUsuarios Datos = new DUsuarios();
            return Datos.Desactivar(id);
        }
    }
}
