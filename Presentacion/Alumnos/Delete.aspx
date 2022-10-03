<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="Presentacion.Alumnos.Delete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <hr />
        <div>
             <label class="col-form-label"> ID: </label>
        <asp:Label Font-Size="Medium" ID="idAlu" runat="server" Text="ID" required=""></asp:Label>
    </div>
    <div>
       <label class="col-form-label"> Nombre: </label> 
        <asp:Label Font-Size="Medium" ID="NombreAlu" runat="server" Text="Nombre" required=""></asp:Label>
    </div>
    <div>
        <label class="col-form-label"> Apellido Paterno: </label>
        <asp:Label Font-Size="Medium" ID="ApellPaterno" runat="server" Text="Apellido Paterno" required=""></asp:Label>
    </div>
    <div>
        <label class="col-form-label"> Apellido Materno: </label>
        <asp:Label Font-Size="Medium" ID="ApellMaterno" runat="server" Text="Apellido Materno" required=""></asp:Label>
    </div>
    <div>
        <label class="col-form-label"> Correo: </label>
        <asp:Label Font-Size="Medium" ID="correo" runat="server" Text="Correo" required=""></asp:Label>
    </div>
    <div>
        <label class="col-form-label"> Telefono: </label>
        <asp:Label Font-Size="Medium" ID="tel" runat="server" Text="Telefono" required=""></asp:Label>
    </div>
    <div>
        <label class="col-form-label"> Fecha Nacimiento: </label>
        <asp:Label Font-Size="Medium" ID="fechaNac" runat="server" Text="Fecha Nacimeinto" required=""></asp:Label>
    </div>
    <div>
        <label class="col-form-label"> Curp: </label>
        <asp:Label Font-Size="Medium" ID="curp" runat="server" Text="Curp" required=""></asp:Label>
    </div>
    <div>
        <label class="col-form-label"> Sueldo: </label>
        <asp:Label Font-Size="Medium" ID="sueldo" runat="server" Text="Sueldo" required=""></asp:Label>
    </div>
    <div>
        <label class="col-form-label"> Estado Origen: </label>
        <asp:Label Font-Size="Medium" ID="idEstadoOrigen" runat="server" Text="ID Estado origen" required=""></asp:Label>
    </div>
    <div>
        <label class="col-form-label"> Esatus: </label>
        <asp:Label Font-Size="Medium" ID="idEstatus" runat="server" Text="ID Estatus" required=""></asp:Label>
    </div>

   <div class="form row">
       <div>
           <asp:Button CssClass=" btn btn-block btn btn-danger" ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
       </div>
    </div>
</asp:Content>
