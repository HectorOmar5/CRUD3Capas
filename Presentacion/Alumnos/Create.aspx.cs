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
    public partial class Create : System.Web.UI.Page
    {
        NAlumno alumnoentity = new NAlumno();
        NEstado estadoEntity = new NEstado();
        NEstatusAlumno estatusEntity = new NEstatusAlumno(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarEstados();
                MostrarEstatus();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Alumno alumno = new Alumno();

            alumno.nombre = txtnombre.Text;
            alumno.apellPaterno = txtapellidoP.Text;
            alumno.apellMaterno = txtapellidoM.Text;
            alumno.correo = txtcorreo.Text;
            alumno.telefono = txttelefono.Text;
            alumno.fechaNacimiento = DateTime.Parse(fechaNac.Text);
            alumno.curp = txtcurp.Text;
            alumno.sueldo = Convert.ToInt32(txtsueldo.Text);
            alumno.idEstadoOrig = Convert.ToInt32(DDEstadoOrigen.SelectedValue);
            alumno.idEstatus = Convert.ToInt32(DDEstatus.SelectedValue);
            
           alumnoentity.Agregar(alumno);

            Response.Redirect("Index.aspx");

        }

        public void MostrarEstados()
        {
            DDEstadoOrigen.DataSource = estadoEntity.ConsultarTodos();
            DDEstadoOrigen.DataValueField = "id";
            DDEstadoOrigen.DataTextField = "nombre";
            DDEstadoOrigen.DataBind();
        }

        public void MostrarEstatus()
        {
            DDEstatus.DataSource = estatusEntity.ConsultarTodos();
            DDEstatus.DataValueField = "id";
            DDEstatus.DataTextField = "nombre";
            DDEstatus.DataBind();
        }
    }
}