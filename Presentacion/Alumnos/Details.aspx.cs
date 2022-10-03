using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.Alumnos
{
    public partial class Details : System.Web.UI.Page
    {
        NAlumno alumno = new NAlumno();
        NEstado estadoEntity = new NEstado();
        NEstatusAlumno estatusEntity = new NEstatusAlumno();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idAlumno = Convert.ToInt32(Request.QueryString["id"]);
                Alumno alu = alumno.ConsultarUno(idAlumno);
                idAlu.Text = alu.id.ToString();
                NombreAlu.Text = alu.nombre;
                ApellPaterno.Text = alu.apellPaterno;
                ApellMaterno.Text = alu.apellMaterno;
                correo.Text = alu.correo;
                tel.Text = alu.telefono;
                fechaNac.Text = Convert.ToString(alu.fechaNacimiento);
                curp.Text = alu.curp;
                sueldo.Text = Convert.ToString(alu.sueldo);
                idEstadoOrigen.Text = estadoEntity.ConsultarUno(alu.idEstadoOrig).nombre;
                idEstatus.Text = estatusEntity.ConsultarUno(alu.idEstatus).nombre;
            }
            
        }

        //protected void btnIMSS_Click(object sender, EventArgs e)
        //{
        //    int id = Convert.ToInt32(idAlu.Text);
        //    //Alumno alu = alumno.ConsultarUno(id);
        //    AportacionesIMSS aportaciones = NAlumno.CalcularIMSS(id);
        //    lblResultado.Text = aportaciones.Infonavit.ToString();
            //lblResultado.Text = aportaciones.Retiro.ToString();
        //}

        protected void btnISR_Click(object sender, EventArgs e)
        {
            NAlumno nAlumno = new NAlumno();
            mpeModalISR.Show();

            int id = Convert.ToInt32(idAlu.Text);
            //Alumno alu = alumno.ConsultarUno(id);
            ItemTablaISR aportaciones = nAlumno.CalcularISR(id);
            lblLimInf.Text = aportaciones.LimInferior.ToString();
            lblLimSup.Text = aportaciones.LimSuperior.ToString();
            lblCuotaFija.Text = aportaciones.CuotaFija.ToString();
            lblExcedente.Text = aportaciones.Excedente.ToString();
            lblSubsidio.Text = aportaciones.Subsidio.ToString();
            lblImpuesto.Text = aportaciones.ISR.ToString();
        }
    }
}