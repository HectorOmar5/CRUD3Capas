using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NEstado
    {
        DEstados dEstados = new DEstados();

        public List<Estado> ConsultarTodos()
        {
            List<Estado> _listEstados = dEstados.ConsultarTdos();
            return _listEstados;
        }

        public Estado ConsultarUno(int idEstado)
        {
            return dEstados.ConsultarUno(idEstado);
        }

        public void Agregar(Estado estado)
        {
            dEstados.Agregar(estado);
        }

        public void Actualizar(Estado estado)
        {
            dEstados.Actualizar(estado);
        }

        public void Eliminar(int idEstado)
        {
            dEstados.Eliminar(idEstado);
        }
    }
}
