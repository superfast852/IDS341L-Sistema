using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Sistema.Datos
{
    internal class Conexion
    {
        // create attributes
        private string BaseDatos;
        private string Servidor;
        private string Usuario;
        private string Clave;
        private bool Seguridad;
        private static Conexion conn;  // Static to instantiate exclusively inside the class

        // Constructores
        private Conexion()
        {
            BaseDatos = "master";
            this.Servidor = "LAPTOP-L4UKBVDH";
            this.Usuario = "sa";
            this.Clave = "";
            this.Seguridad = true;
        }

        // a connection establishment method
        public SqlConnection CrearConexion()
        {
            SqlConnection cadena = new SqlConnection();

            try
            {
                cadena.ConnectionString = $"Server={this.Servidor};Database={this.BaseDatos}";
                if (this.Seguridad)
                {
                    cadena.ConnectionString += ";Integrated Security = SSPI;TrustServerCertificate=True";
                }
                else
                {
                    cadena.ConnectionString += $"User Id={this.Usuario}; Password={this.Clave};";
                }
            }
            catch (Exception ex)
            {
                cadena = null;
                throw ex;
            }
            return cadena;
        }

        public static Conexion getInstance()
        {
            if (conn == null)
            {
                conn = new Conexion();
            }
            return conn;
        }

    }
}

