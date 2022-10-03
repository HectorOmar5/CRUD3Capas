using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace Presentacion.Alumnos
{
    public partial class Edit : System.Web.UI.Page
    {
        NAlumno alumno = new NAlumno();
        NEstado estadoEntity = new NEstado();
        NEstatusAlumno estatusEntity = new NEstatusAlumno();

        protected void Page_Load(object sender, EventArgs e) 
        {
            if (!IsPostBack)
            {
                int idAlu = Convert.ToInt32(Request.QueryString["id"]);
                Alumno alu = alumno.ConsultarUno(idAlu);
                ids.Text = alu.id.ToString();
                txtnombre.Text = alu.nombre;
                txtapellidoP.Text = alu.apellPaterno;
                txtapellidoM.Text = alu.apellMaterno;
                txtcorreo.Text = alu.correo;
                txttelefono.Text = alu.telefono;
                txtfechaNac.Text = alu.fechaNacimiento.ToString("yyyy-MM-dd");
                txtcurp.Text = alu.curp;
                txtsueldo.Text = Convert.ToString(alu.sueldo);
                DDEstado.SelectedValue = alu.idEstadoOrig.ToString();
                DDEstatus.SelectedValue = alu.idEstatus.ToString();

                MostrarEstados();
               
                
            }

            MostrarEstatus();
        }

        protected void btnGurdar_Click(object sender, EventArgs e)
        {
            Alumno alu = new Alumno();
            alu.id = Convert.ToInt32(ids.Text);

            alu.nombre = txtnombre.Text;
            alu.apellPaterno = txtapellidoP.Text;
            alu.apellMaterno = txtapellidoM.Text;
            alu.correo = txtcorreo.Text;
            alu.telefono = txttelefono.Text;
            alu.fechaNacimiento = Convert.ToDateTime(txtfechaNac.Text);
            alu.curp = txtcurp.Text;
            alu.sueldo = Convert.ToDecimal(txtsueldo.Text);
            alu.idEstadoOrig = Convert.ToInt32(DDEstado.SelectedValue);
            alu.idEstatus = Convert.ToInt32(DDEstatus.SelectedValue);
            alumno.Actualizar(alu);

            Response.Redirect("Index.aspx");
        }

        public void MostrarEstados()
        {
            DDEstado.DataSource = estadoEntity.ConsultarTodos();
            DDEstado.DataValueField = "id";
            DDEstado.DataTextField = "nombre";
            DDEstado.DataBind();
        }

        public void MostrarEstatus()
        {
            DDEstatus.DataSource = estatusEntity.ConsultarTodos();
            DDEstatus.DataValueField = "id";
            DDEstatus.DataTextField = "nombre";
            DDEstatus.DataBind();
        }

        protected void CVFechaNacim_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var fechaNac = args.Value;
            var ExtracCurp = txtfechaNac.Text.Substring(4,6);
            var FormatCurp = fechaNac.Substring(2, 2) + fechaNac.Substring(5, 2) + fechaNac.Substring(7, 3);
            args.IsValid = ExtracCurp == FormatCurp;
        }
    }
}