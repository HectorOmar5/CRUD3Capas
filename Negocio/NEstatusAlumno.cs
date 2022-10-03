using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NEstatusAlumno
    {
        DEstatusAlumno dEstatusAlumno = new DEstatusAlumno();

        public List<EstatusAlumno> ConsultarTodos()
        {
            List<EstatusAlumno> _listEstatusAlu = dEstatusAlumno.ConsultarTodos();
            return _listEstatusAlu;
        }

        public EstatusAlumno ConsultarUno(int idEstatus)
        {
            return dEstatusAlumno.ConsultarUno(idEstatus);
        }

        public void Agregar(EstatusAlumno estatusAlumno)
        {
            dEstatusAlumno.Agregar(estatusAlumno);
        }

        public void Actualizar(EstatusAlumno estatusAlumno)
        {
            dEstatusAlumno.Actualizar(estatusAlumno);
        }

        public void Eliminar(int idEstatus)
        {
            dEstatusAlumno.Eliminar(idEstatus);
        }
    }
}
