using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Newtonsoft.Json;

namespace Negocio
{
    public class NAlumno
    {
        static NAlumno alumno = new NAlumno();
        DAlumno dAlumno = new DAlumno();

        public List<Alumno> ConsultarTodos()
        {
            List<Alumno> _listAlumnos = dAlumno.ConsultarTodos();
            return _listAlumnos;
        }

        public Alumno ConsultarUno(int idAlumno)
        {
            return dAlumno.ConsultarUno(idAlumno);
        }

        public void Agregar(Alumno alumno)
        {
            dAlumno.Agregar(alumno);
        }

        public void Actualizar(Alumno alumno)
        {
            dAlumno.Actualizar(alumno);
        }

        public void Eliminar(int idAlumno)
        {
            dAlumno.Eliminar(idAlumno);
        }

        //public void ConsultarTablaISR()
        //{
        //    dAlumno.ConsultarTablaISR();
        //}

        public ItemTablaISR CalcularISR(int idAlumno)
        { 
            try
            {
                //Deserealizar Objeto
                Negocio.WSAlumnos.WSAlumnosSoapClient WSSoapAlumnos = new WSAlumnos.WSAlumnosSoapClient();
                string isrjson = JsonConvert.SerializeObject(WSSoapAlumnos.CalcularISR(idAlumno));
                ItemTablaISR item = JsonConvert.DeserializeObject<ItemTablaISR>(isrjson);
                return item;
            }
            catch
            {
                ItemTablaISR tablaISR = new ItemTablaISR();
                Alumno alu = alumno.ConsultarUno(idAlumno);
                decimal sueldoQuincenal = alu.sueldo / 2;
                List<ItemTablaISR> _listISR = dAlumno.ConsultarTablaISR();
                tablaISR = _listISR.Find(isr => sueldoQuincenal > isr.LimInferior && sueldoQuincenal < isr.LimSuperior);
                //foreach(ItemTablaISR tablaISR1 in _listISR)
                //{
                //    if (sueldoQuincenal >= tablaISR1.LimInferior && sueldoQuincenal <= tablaISR1.LimSuperior)
                //        tablaISR = tablaISR1;
                //}
                decimal resultadoISR = (sueldoQuincenal - tablaISR.LimInferior) * (tablaISR.Excedente / 100);
                tablaISR.ISR = resultadoISR + tablaISR.CuotaFija + tablaISR.Subsidio;
                return tablaISR;
            }

            
        }

        public static AportacionesIMSS CalcularIMSS(int idAlumno)
        {
            
            Alumno alu = alumno.ConsultarUno(idAlumno);
            decimal SueldoBase = alu.sueldo;
            AportacionesIMSS aportaciones = new AportacionesIMSS();
            decimal uma = Convert.ToDecimal(ConfigurationManager.AppSettings["UMA"]);
            aportaciones.EnfermedadMaternidad = SueldoBase - (3 * uma) * Convert.ToDecimal(1.1 / 100);
            aportaciones.InvalidezVida = SueldoBase * Convert.ToDecimal(1.75 / 100);
            aportaciones.Retiro = SueldoBase * Convert.ToDecimal(2 / 100);
            aportaciones.Cesantia = SueldoBase * Convert.ToDecimal(3.150 / 100);
            aportaciones.Infonavit = SueldoBase * 5 / 100;

            return aportaciones;
        }
    }

}
