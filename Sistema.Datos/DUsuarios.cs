using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Sistema.Entidad;


namespace Sistema.Datos
{
    public class DUsuarios
    {
        public DataTable Login(string email, string clave)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection sqlConn = new SqlConnection();

            try
            {
                sqlConn = Conexion.getInstance().CrearConexion();

                SqlCommand Comando = new SqlCommand("usuario_login", sqlConn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                Comando.Parameters.Add("@clave", SqlDbType.VarChar).Value = clave;


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

        public DataTable Listar()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection sqlConn = new SqlConnection();

            try
            {
                sqlConn = Conexion.getInstance().CrearConexion();
                SqlCommand Comando = new SqlCommand("usuario_listar", sqlConn);
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

                SqlCommand Comando = new SqlCommand("usuario_buscar", sqlConn);
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

                SqlCommand Comando = new SqlCommand("usuario_existe", sqlConn);
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

        public string Insertar(Usuario obj)
        {
            string Respuesta = "";
            SqlConnection sqlConn = new SqlConnection();

            try
            {
                sqlConn = Conexion.getInstance().CrearConexion();
                SqlCommand Comando = new SqlCommand("usuario_insertar", sqlConn);

                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@idrol", SqlDbType.Int).Value = obj.IdRol;
                Comando.Parameters.Add("@telefono", SqlDbType.VarChar).Value = obj.Telefono;
                Comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = obj.Nombre;
                Comando.Parameters.Add("@tipo_documento", SqlDbType.VarChar).Value = obj.TipoDocumento;
                Comando.Parameters.Add("@num_documento", SqlDbType.VarChar).Value = obj.Documento;
                Comando.Parameters.Add("@email", SqlDbType.VarChar).Value = obj.Email;
                Comando.Parameters.Add("@clave", SqlDbType.VarChar).Value = obj.Clave;
                Comando.Parameters.Add("@direccion", SqlDbType.VarChar).Value = obj.Direccion;

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

        public string Actualizar(Usuario obj)
        {
            string Respuesta = "";
            SqlConnection sqlConn = new SqlConnection();

            try
            {
                sqlConn = Conexion.getInstance().CrearConexion();
                SqlCommand Comando = new SqlCommand("usuario_actualizar", sqlConn);

                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@idusuario", SqlDbType.Int).Value = obj.IdUsuario;
                Comando.Parameters.Add("@idrol", SqlDbType.Int).Value = obj.IdRol;
                Comando.Parameters.Add("@telefono", SqlDbType.VarChar).Value = obj.Telefono;
                Comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = obj.Nombre;
                Comando.Parameters.Add("@tipo_documento", SqlDbType.VarChar).Value = obj.TipoDocumento;
                Comando.Parameters.Add("@num_documento", SqlDbType.VarChar).Value = obj.Documento;
                Comando.Parameters.Add("@email", SqlDbType.VarChar).Value = obj.Email;
                Comando.Parameters.Add("@clave", SqlDbType.VarChar).Value = obj.Clave;
                Comando.Parameters.Add("@direccion", SqlDbType.VarChar).Value = obj.Direccion;

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
                SqlCommand Comando = new SqlCommand("usuario_eliminar", sqlConn);

                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@idusuario", SqlDbType.Int).Value = id;

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
                SqlCommand Comando = new SqlCommand("usuario_activar", sqlConn);

                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@idusuario", SqlDbType.Int).Value = id;

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
                SqlCommand Comando = new SqlCommand("usuario_desactivar", sqlConn);

                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@idusuario", SqlDbType.Int).Value = id;

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
