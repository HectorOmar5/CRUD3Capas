using Negocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.Alumnos
{
    public partial class Index : System.Web.UI.Page
    {
        private List<NAlumno> _listAlumnos = new List<NAlumno>();
        NAlumno alumno = new NAlumno();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //CargarTabla(); la linea de abajo es de aqui de lo que esta comentado
                 //< asp:DropDownList ID = "DDlistMuestra" runat = "server" ></ asp:DropDownList >
                CargarAlumnosTabla();
            }
                
        }

        //void CargarTabla()
        //{
        //    DDlistMuestra.DataSource = alumno.ConsultarTodos();
        //    DDlistMuestra.DataValueField = "id";
        //    DDlistMuestra.DataTextField = "nombre";
        //    DDlistMuestra.DataBind();
        //}

        //protected void btnDetalles_Click(object sender, EventArgs e)
        //{
        //    string idAlumno = DDlistMuestra.SelectedValue;
        //    Response.Redirect($"Details.aspx?id={idAlumno}");
        //}

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Create.aspx");
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Edit.aspx");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Delete.aspx");
        }

        public void CargarAlumnosTabla()
        {
            DDAlumnos.DataSource = alumno.ConsultarTodos();
            DDAlumnos.DataBind();
        }

        protected void DDAlumnos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Page")
            {
                return;
            }
            int numRenglon = Convert.ToInt32(e.CommandArgument);
            GridViewRow Renglon = DDAlumnos.Rows[numRenglon]; //Extraer La Columna
            TableCell Celda = Renglon.Cells[0]; //Obtener Celda
            int id = Convert.ToInt32(Celda.Text); //Extraer Celda


                switch(e.CommandName)
            {
                case "btnDetails":
                    Response.Redirect($"Details.aspx?id={id}");
                    break;
                case "btnEdit":
                    Response.Redirect($"Edit.aspx?id={id}");
                    break;
                case "btnDelete":
                    Response.Redirect($"Delete.aspx?id={id}");
                    break;
            }
        }

        protected void DDAlumnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DDAlumnos.PageIndex = e.NewPageIndex; //indice de la nueva pagina
            DDAlumnos.DataSource = alumno.ConsultarTodos();
            DDAlumnos.DataBind();
        }

    }
}