using Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DEstatusAlumno
    {
        private List<EstatusAlumno> _listEstatusAlu = new List<EstatusAlumno>();
        string conexionn = ConfigurationManager.ConnectionStrings["ConexionLocal"].ConnectionString;
        SqlDataReader leer;
        SqlCommand comando;

        public List<EstatusAlumno> ConsultarTodos()
        {
            _listEstatusAlu.Clear();
            String ConsultarTodosQuery = "sp_consultarEstatusAlumno";
            using (SqlConnection conexion = new SqlConnection(conexionn))
            {
                comando = new SqlCommand(ConsultarTodosQuery, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idEstatus", "-1");
                conexion.Open();
                leer = comando.ExecuteReader();
                while (leer.Read())
                {
                    _listEstatusAlu.Add(new EstatusAlumno()
                    {
                        id = Convert.ToInt32(leer["id"]),
                        nombre = Convert.ToString(leer["nombre"]),
                        clave = Convert.ToString(leer["clave"])
                    });
                }
                conexion.Close();
            }
            return _listEstatusAlu;
        }

        public EstatusAlumno ConsultarUno(int idEstatus)
        {
            EstatusAlumno estatus = new EstatusAlumno();
            string selectUno = "sp_consultarEstatusAlumno";
            using (SqlConnection connection = new SqlConnection(conexionn))
            {
                comando = new SqlCommand(selectUno, connection);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idEstatus", idEstatus);
                connection.Open();
                leer = comando.ExecuteReader();
                while (leer.Read())
                {
                    estatus = new EstatusAlumno()
                    {
                        id = Convert.ToInt32(leer["id"]),
                        nombre = Convert.ToString(leer["nombre"]),
                        clave = Convert.ToString(leer["clave"])
                    };
                }
                connection.Close();
            }
            return estatus;
        }

        public void Agregar(EstatusAlumno estatusAlu)
        {
            string agregarEstatus = "sp_agregarEstatusAlumnos";
            using (SqlConnection connection = new SqlConnection(conexionn))
            {
                comando = new SqlCommand(agregarEstatus, connection);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@nombre", estatusAlu.nombre);
                comando.Parameters.AddWithValue("@clave", estatusAlu.clave);

                comando.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Actualizar(EstatusAlumno estatusAlu)
        {
            string actualizarEstatus = "sp_actualizarEstado";
            using (SqlConnection conexioncita = new SqlConnection(conexionn))
            {
                comando = new SqlCommand(actualizarEstatus, conexioncita);
                comando.CommandType = CommandType.StoredProcedure;
                conexioncita.Open();

                comando.Parameters.AddWithValue("@idEstado", estatusAlu.id);
                comando.Parameters.AddWithValue("@nombre", estatusAlu.nombre);
                comando.Parameters.AddWithValue("@clave", estatusAlu.clave);

                comando.ExecuteNonQuery();
                conexioncita.Close();
            }
        }

        public void Eliminar(int idEstatus)
        {
            string eliminarEstatus = "sp_eliminarEstatusAlumnos";
            using (SqlConnection conn = new SqlConnection(conexionn))
            {
                comando = new SqlCommand(eliminarEstatus, conn);
                comando.CommandType = CommandType.StoredProcedure;
                conn.Open();
                comando.Parameters.AddWithValue("@idEstatus", idEstatus);
                comando.ExecuteNonQuery();

                conn.Close();
            }
        }
    }
}
