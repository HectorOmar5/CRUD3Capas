using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Claims;
using System.IO.Packaging;

namespace Datos
{
    public class DAlumno
    {
        //private CD_Conexion conexion = new CD_Conexion();

        private List<Alumno> _listAlumnos = new List<Alumno>();
        private List<ItemTablaISR> _listISR = new List<ItemTablaISR>();

        string conexion = ConfigurationManager.ConnectionStrings["ConexionLocal"].ConnectionString;
        SqlDataReader leer;
        SqlCommand comando;


        public List<Alumno> ConsultarTodos()
        {
            _listAlumnos.Clear();
            string selectTodosQuery = "sp_consultaAlumnos";
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                comando = new SqlCommand(selectTodosQuery, conn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idAlumno", "-1");
                conn.Open();
                leer = comando.ExecuteReader();
                while (leer.Read())
                {
                    _listAlumnos.Add(new Alumno()
                    {
                        id = Convert.ToInt32(leer["id"]),
                        nombre = leer["nombre"].ToString(),
                        apellPaterno = leer["primerApellido"].ToString(),
                        apellMaterno = leer["segundoApellido"].ToString(),
                        correo = leer["correo"].ToString(),
                        telefono = leer["telefono"].ToString(),
                        fechaNacimiento = Convert.ToDateTime(leer["fechaNacimiento"]),
                        curp = leer["curp"].ToString(),
                        //sueldo = Convert.ToDecimal(leer["sueldo"]),
                        sueldo = DBNull.Value.Equals(leer["sueldo"]) ? 0: Convert.ToDecimal(leer["sueldo"]),
                        idEstadoOrig = Convert.ToInt32(leer["idEstadoOrigen"]),
                        idEstatus = Convert.ToInt32(leer["idEstatus"])
                    }
                        );
                }
                conn.Close();
            }
            return _listAlumnos;
        }

        public Alumno ConsultarUno(int idAlumno)
        {
            Alumno alumno = new Alumno();
            string selectUno = "sp_consultaAlumnos";
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                comando = new SqlCommand(selectUno, conn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idAlumno", idAlumno);
                conn.Open();
                leer = comando.ExecuteReader();
                while (leer.Read())
                {
                    alumno = new Alumno()
                    {
                        id = Convert.ToInt32(leer["id"]),
                        nombre = leer["nombre"].ToString(),
                        apellPaterno = leer["primerApellido"].ToString(),
                        apellMaterno = leer["segundoApellido"].ToString(),
                        correo = leer["correo"].ToString(),
                        telefono = leer["telefono"].ToString(),
                        fechaNacimiento = Convert.ToDateTime(leer["fechaNacimiento"]),
                        curp = leer["curp"].ToString(),
                        sueldo = Convert.ToDecimal(leer["sueldo"]),
                        idEstadoOrig = Convert.ToInt32(leer["idEstadoOrigen"]),
                        idEstatus = Convert.ToInt32(leer["idEstatus"])
                    };
                }
                conn.Close();
            }
            return alumno;
        }
        public void Agregar(Alumno alumno)
        {
            string agregarAlumno = "sp_agregarAlumnos";
            using (SqlConnection connection = new SqlConnection(conexion))
            {
                
                comando = new SqlCommand(agregarAlumno, connection);
                comando.CommandType = CommandType.StoredProcedure;
                connection.Open();
                comando.Parameters.AddWithValue("@nombre", alumno.nombre);
                comando.Parameters.AddWithValue("@primerApellido", alumno.apellPaterno);
                comando.Parameters.AddWithValue("@segundoApellido", alumno.apellMaterno);
                comando.Parameters.AddWithValue("@correo", alumno.correo);
                comando.Parameters.AddWithValue("@telefono", alumno.telefono);
                comando.Parameters.AddWithValue("@fechaNacimiento", alumno.fechaNacimiento);
                comando.Parameters.AddWithValue("@curp", alumno.curp);
                comando.Parameters.AddWithValue("@sueldo", alumno.sueldo);
                comando.Parameters.AddWithValue("@idEstadoOrigen", alumno.idEstadoOrig);
                comando.Parameters.AddWithValue("@idEstatus", alumno.idEstatus);

                comando.ExecuteNonQuery();

                connection.Close(); 
            }
        }
        public void Actualizar(Alumno alumno)
        {
            string actualizarAlumnos = "sp_actualizarAlumnos";
            using (SqlConnection Connection = new SqlConnection(conexion))
            {
                comando = new SqlCommand(actualizarAlumnos, Connection);
                comando.CommandType = CommandType.StoredProcedure;
                Connection.Open();
                comando.Parameters.AddWithValue("@idAlumno", alumno.id);
                comando.Parameters.AddWithValue("@nombre", alumno.nombre);
                comando.Parameters.AddWithValue("@primerApellido", alumno.apellPaterno);
                comando.Parameters.AddWithValue("@segundoApellido", alumno.apellMaterno);
                comando.Parameters.AddWithValue("@correo", alumno.correo);
                comando.Parameters.AddWithValue("@telefono", alumno.telefono);
                comando.Parameters.AddWithValue("@fechaNacimiento", alumno.fechaNacimiento);
                comando.Parameters.AddWithValue("@curp", alumno.curp);
                comando.Parameters.AddWithValue("@sueldo", alumno.sueldo);
                comando.Parameters.AddWithValue("@idEstadoOrigen", alumno.idEstadoOrig);
                comando.Parameters.AddWithValue("@idEstatus", alumno.idEstatus);

                comando.ExecuteNonQuery();
                Connection.Close();
            }
        }
        public void Eliminar(int idAlumno)
        {
            string eliminarAlumnos = "sp_eliminarAlumno";
            using (SqlConnection conection = new SqlConnection(conexion))
            {
                comando = new SqlCommand(eliminarAlumnos, conection);
                comando.CommandType = CommandType.StoredProcedure;
                conection.Open();
                comando.Parameters.AddWithValue("@idAlumno", idAlumno);
                comando.ExecuteNonQuery();
                conection.Close();
            }
        }

        public List<ItemTablaISR> ConsultarTablaISR()
        {
            string selecTabla = $"select * from TablaISR";
            List<ItemTablaISR> _lista = new List<ItemTablaISR>();
            using (SqlConnection conectionn = new SqlConnection(conexion))
            {
                comando = new SqlCommand(selecTabla, conectionn);
                comando.CommandType = CommandType.Text;
                conectionn.Open();
                leer = comando.ExecuteReader();
                while (leer.Read())
                {
                    _lista.Add(new ItemTablaISR()
                    {
                        LimInferior = Convert.ToDecimal( leer["LimInf"]),
                        LimSuperior = Convert.ToDecimal(leer["LimSup"]),
                        CuotaFija = Convert.ToDecimal(leer["CuotaFija"]),
                        Excedente = Convert.ToDecimal(leer["ExedLimInf"]),
                        Subsidio = Convert.ToDecimal(leer["Subsidio"])
                    });
                }
                conectionn.Close();
            }
            return _lista;
        }

    }
    
}
