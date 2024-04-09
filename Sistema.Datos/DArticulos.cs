using System;
using Microsoft.Data.SqlClient;
using System.Data;
using Sistema.Entidad;

namespace Sistema.Datos
{
    public class DArticulos
    {
        // Listas las categorias
        public DataTable Listar()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection sqlConn = new SqlConnection();

            try
            {
                sqlConn = Conexion.getInstance().CrearConexion();
                SqlCommand Comando = new SqlCommand("articulo_listar", sqlConn);
                Comando.CommandType = CommandType.StoredProcedure;
                sqlConn.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (sqlConn.State == ConnectionState.Open)
                {
                    sqlConn.Close();
                }
            }
        }

        public DataTable Buscar(string valor)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection sqlConn = new SqlConnection();

            try
            {
                sqlConn = Conexion.getInstance().CrearConexion();

                SqlCommand Comando = new SqlCommand("articulo_buscar", sqlConn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = valor;

                sqlConn.Open();

                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (sqlConn.State == ConnectionState.Open)
                {
                    sqlConn.Close();
                }
            }
        }

        // Metodo para determinar si una categoria existe
        public string Existe(string valor)
        {
            string Respuesta;
            SqlConnection sqlConn = new SqlConnection();

            try
            {
                sqlConn = Conexion.getInstance().CrearConexion();

                SqlCommand Comando = new SqlCommand("articulo_existe", sqlConn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = valor;

                SqlParameter parExiste = new SqlParameter();
                parExiste.ParameterName = "@existe";
                parExiste.SqlDbType = SqlDbType.Int;
                parExiste.Direction = ParameterDirection.Output;

                Comando.Parameters.Add(parExiste);
                sqlConn.Open();
                Comando.ExecuteNonQuery();

                Respuesta = Convert.ToString(parExiste.Value);

            }
            catch (Exception ex)
            {
                Respuesta = ex.Message;
            }
            finally
            {
                if (sqlConn.State == ConnectionState.Open)
                {
                    sqlConn.Close();
                }
            }

            return Respuesta;
        }

        public string Insertar(Articulo obj)
        {
            string Respuesta = "";
            SqlConnection sqlConn = new SqlConnection();

            try
            {
                sqlConn = Conexion.getInstance().CrearConexion();
                SqlCommand Comando = new SqlCommand("articulo_insertar", sqlConn);

                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@idcategoria", SqlDbType.Int).Value = obj.IdCategoria;
                Comando.Parameters.Add("@codigo", SqlDbType.VarChar).Value = obj.Codigo;
                Comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = obj.Nombre;
                Comando.Parameters.Add("@precio_venta", SqlDbType.Decimal).Value = obj.PrecioVenta;
                Comando.Parameters.Add("@stock", SqlDbType.Int).Value = obj.Stock;
                Comando.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = obj.Descripcion;
                Comando.Parameters.Add("@imagen", SqlDbType.VarChar).Value = obj.Imagen;

                sqlConn.Open();
                Respuesta = Comando.ExecuteNonQuery() == 1 ? "OK" : "Error";
            }
            catch (Exception e)
            {
                Respuesta = e.Message;
            }
            finally
            {
                if (sqlConn.State == ConnectionState.Open)
                {
                    sqlConn.Close();
                }
            }
            return Respuesta;
        }

        public string Actualizar(Articulo obj)
        {
            string Respuesta = "";
            SqlConnection sqlConn = new SqlConnection();

            try
            {
                sqlConn = Conexion.getInstance().CrearConexion();
                SqlCommand Comando = new SqlCommand("articulo_actualizar", sqlConn);

                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@idarticulo",   SqlDbType.Int).Value     = obj.IdArticulo;
                Comando.Parameters.Add("@idcategoria",  SqlDbType.Int).Value     = obj.IdCategoria;
                Comando.Parameters.Add("@codigo",       SqlDbType.VarChar).Value = obj.Codigo;
                Comando.Parameters.Add("@nombre",       SqlDbType.VarChar).Value = obj.Nombre;
                Comando.Parameters.Add("@precio_venta", SqlDbType.Decimal).Value = obj.PrecioVenta;
                Comando.Parameters.Add("@stock",        SqlDbType.Int).Value     = obj.Stock;
                Comando.Parameters.Add("@descripcion",  SqlDbType.VarChar).Value = obj.Descripcion;
                Comando.Parameters.Add("@imagen",       SqlDbType.VarChar).Value = obj.Imagen;

                sqlConn.Open();
                Respuesta = Comando.ExecuteNonQuery() == 1 ? "OK" : "Error";
            }
            catch (Exception e)
            {
                Respuesta = e.Message;
            }
            finally
            {
                if (sqlConn.State == ConnectionState.Open)
                {
                    sqlConn.Close();
                }
            }
            return Respuesta;
        }

        public string Eliminar(int id)
        {
            string Respuesta = "";
            SqlConnection sqlConn = new SqlConnection();

            try
            {
                sqlConn = Conexion.getInstance().CrearConexion();
                SqlCommand Comando = new SqlCommand("articulo_eliminar", sqlConn);

                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@idarticulo", SqlDbType.Int).Value = id;

                sqlConn.Open();
                Respuesta = Comando.ExecuteNonQuery() == 1 ? "OK" : "Error";
            }
            catch (Exception e)
            {
                Respuesta = e.Message;
            }
            finally
            {
                if (sqlConn.State == ConnectionState.Open)
                {
                    sqlConn.Close();
                }
            }
            return Respuesta;
        }

        public string Activar(int id)
        {
            string Respuesta = "";
            SqlConnection sqlConn = new SqlConnection();

            try
            {
                sqlConn = Conexion.getInstance().CrearConexion();
                SqlCommand Comando = new SqlCommand("articulo_activar", sqlConn);

                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@idarticulo", SqlDbType.Int).Value = id;

                sqlConn.Open();
                Respuesta = Comando.ExecuteNonQuery() == 1 ? "OK" : "Error";
            }
            catch (Exception e)
            {
                Respuesta = e.Message;
            }
            finally
            {
                if (sqlConn.State == ConnectionState.Open)
                {
                    sqlConn.Close();
                }
            }
            return Respuesta;
        }

        public string Desactivar(int id)
        {
            string Respuesta = "";
            SqlConnection sqlConn = new SqlConnection();

            try
            {
                sqlConn = Conexion.getInstance().CrearConexion();
                SqlCommand Comando = new SqlCommand("articulo_desactivar", sqlConn);

                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@idarticulo", SqlDbType.Int).Value = id;

                sqlConn.Open();
                Respuesta = Comando.ExecuteNonQuery() == 1 ? "OK" : "Error";
            }
            catch (Exception e)
            {
                Respuesta = e.Message;
            }
            finally
            {
                if (sqlConn.State == ConnectionState.Open)
                {
                    sqlConn.Close();
                }
            }
            return Respuesta;
        }
    }
}
