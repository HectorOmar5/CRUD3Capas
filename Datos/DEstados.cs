using Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DEstados
    {
        private List<Estado> _listEstados = new List<Estado>();
        string conexionn = ConfigurationManager.ConnectionStrings["ConexionLocal"].ConnectionString;
        SqlDataReader leer;
        SqlCommand comando;

        public List<Estado> ConsultarTdos()
        {
            _listEstados.Clear();
            String ConsultarTodosQuery = "sp_consultarEstado";
            using(SqlConnection conexion = new SqlConnection(conexionn))
            {
                comando = new SqlCommand(ConsultarTodosQuery, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idEstado", "-1");
                conexion.Open();
                leer = comando.ExecuteReader();
                while (leer.Read())
                {
                    _listEstados.Add(new Estado()
                    {
                        id = Convert.ToInt32( leer["id"]),
                        nombre = Convert.ToString(leer["nombre"]),
                        clave = Convert.ToString(leer["clave"])
                    });
                }
                conexion.Close();
            }
            return _listEstados;
        }
        public Estado ConsultarUno(int idEstado)
        {
            Estado estado = new Estado();
            string selectUno = "sp_consultarEstado";
            using (SqlConnection connection = new SqlConnection(conexionn))
            {
                comando = new SqlCommand(selectUno, connection);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idEstado", idEstado);
                connection.Open();
                leer = comando.ExecuteReader();
                while (leer.Read())
                {
                    estado = new Estado()
                    {
                        id = Convert.ToInt32(leer["id"]),
                        nombre = Convert.ToString(leer["nombre"]),
                        clave = Convert.ToString(leer["clave"])
                    };
                }
                connection.Close();
            }
            return estado;
        }

        public void Agregar(Estado estado)
        {
            string agregarEstado = "sp_agregarEstado";
            using (SqlConnection connection = new SqlConnection(conexionn))
            {
                comando = new SqlCommand(agregarEstado, connection);
                comando.CommandType = CommandType.StoredProcedure;

                connection.Open();
                comando.Parameters.AddWithValue("@nombre", estado.nombre);
                comando.Parameters.AddWithValue("@clave", estado.clave);

                comando.ExecuteNonQuery();
                connection.Close();
            }
        }
        public void Actualizar(Estado estado)
        {
            string actualizarEstado = "sp_actualizarEstado";
            using (SqlConnection conexioncita = new SqlConnection(conexionn))
            {
                comando = new SqlCommand (actualizarEstado, conexioncita);
                comando.CommandType = CommandType.StoredProcedure;
                conexioncita.Open();

                comando.Parameters.AddWithValue("@idEstado", estado.id);
                comando.Parameters.AddWithValue("@nombre", estado.nombre);
                comando.Parameters.AddWithValue("@clave", estado.clave);

                comando.ExecuteNonQuery();
                conexioncita.Close();
            }
        }

        public void Eliminar(int idEstado)
        {
            string eliminarAlumnos = "sp_eliminarEstados";
            using (SqlConnection conn =  new SqlConnection(conexionn))
            {
                comando = new SqlCommand(eliminarAlumnos, conn);
                comando.CommandType = CommandType.StoredProcedure;
                conn.Open();
                comando.Parameters.AddWithValue("@idEstado", idEstado);
                comando.ExecuteNonQuery();

                conn.Close();   
            }
        }
    }

   
}
