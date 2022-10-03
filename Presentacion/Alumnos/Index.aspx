<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Presentacion.Alumnos.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <hr /> 
    
        <asp:Button CssClass="btn btn-success" ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
    <hr />
    <asp:GridView ID="DDAlumnos" HeaderStyle-BackColor="DarkMagenta" HeaderStyle-ForeColor="White" CssClass="table" runat="server" AutoGenerateColumns="False" OnRowCommand="DDAlumnos_RowCommand" AllowPaging="True" OnPageIndexChanging="DDAlumnos_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="ID" />
            <asp:BoundField DataField="nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="apellPaterno" HeaderText="Apellido Paterno" />
            <asp:BoundField DataField="apellMaterno" HeaderText="Apellido Materno" />
             <asp:BoundField DataField="correo" HeaderText="Correo Electronico" />
             <asp:BoundField DataField="telefono" HeaderText="Telefono" />
             <asp:BoundField DataField="idEstadoOrig" HeaderText="Estado" />
             <asp:BoundField DataField="idEstatus" HeaderText="Estatus" />
            <asp:ButtonField CommandName="btnDetails" Text="Detalles" >
            <ControlStyle CssClass="btn btn-warning" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="btnEdit" Text="Actualizar" >
            <ControlStyle CssClass="btn btn-primary" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="btnDelete" Text="Eliminar" > 
            <ControlStyle CssClass="btn btn-danger" />
            </asp:ButtonField>
        </Columns>
   

<HeaderStyle BackColor="DarkMagenta" ForeColor="White"></HeaderStyle>
        <RowStyle BorderColor="Black" />
    </asp:GridView>
</asp:Content>
