<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Presentacion.Alumnos.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <hr />

    <div class="form row">
        <div class="form-group col-md-3">
            <div> 
                <label class="col-form-label"> ID: </label>
                <asp:Label ID="ids" runat="server" Text="Id"></asp:Label>
            </div>
        </div>
    </div>
         
    <div class="form row">
        <div class="form-group col-md-3">
            <label class="col-form-label"> Nombre: </label>
            <asp:TextBox autocomplete="off" CssClass="form-control" ID="txtnombre" runat="server" required=""></asp:TextBox>
            <asp:RequiredFieldValidator ID="RFVNombreE" runat="server" ErrorMessage="El Campo Nombre Está Vacio" ControlToValidate="txtnombre" CssClass="text-danger"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="REVApellidoP" runat="server" ErrorMessage="Checa Bien Tu Texto" ControlToValidate="txtnombre" ValidationExpression="[a-zA-Z\u00C0-\u017F\s]*"></asp:RegularExpressionValidator>
       </div>

    <div class="form-group col-md-3">
        <label class="col-form-label"> Apellido Paterno: </label>
        <asp:TextBox CssClass="form-control" ID="txtapellidoP" runat="server" required=""></asp:TextBox>
        <asp:RequiredFieldValidator ID="RFVPapellido" runat="server" ErrorMessage="El Campo Nombre Está Vacio" ControlToValidate="txtapellidoP" CssClass="text-danger"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="REVPapellido" runat="server" ErrorMessage="Checa Bien Tu Texto" ControlToValidate="txtapellidoP" ValidationExpression="[a-zA-Z\u00C0-\u017F\s]*"></asp:RegularExpressionValidator>
     </div>

    <div class="form-group col-md-3">
        <label class="col-form-label"> Apellido Materno: </label>
        <asp:TextBox CssClass="form-control" ID="txtapellidoM" runat="server" required=""></asp:TextBox>
        <asp:RequiredFieldValidator ID="RFVMapellido" runat="server" ErrorMessage="El Campo Nombre Está Vacio" ControlToValidate="txtapellidoM" CssClass="text-danger"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="REVMapellido" runat="server" ErrorMessage="Checa Bien Tu Texto" ControlToValidate="txtapellidoM" ValidationExpression="[a-zA-Z\u00C0-\u017F\s]*"></asp:RegularExpressionValidator>
     </div>
     </div>

     <div class="form row">
         <div class="form-group col-md-3">
             <label class="col-form-label"> Correo: </label>
             <asp:TextBox CssClass="form-control" ID="txtcorreo" runat="server" required=""></asp:TextBox>
        </div>

   
   <div class="form-group col-md-3">
       <label class="col-form-label"> Telefono: </label>
            <asp:TextBox CssClass="form-control" ID="txttelefono" runat="server" required=""></asp:TextBox>
       </div>

    <div class="form-group col-md-3">
        <label class="col-form-label"> Fecha Nacimiento: </label>
        <asp:TextBox CssClass="form-control" TextMode="Date" ID="txtfechaNac" runat="server" required=""></asp:TextBox>
        <asp:CustomValidator ID="CVFechaNacim" runat="server" CssClass="text-danger" ControlToValidate="txtfechaNac" ErrorMessage="La fecha de nacimiento y curp no coinciden" OnServerValidate="CVFechaNacim_ServerValidate"></asp:CustomValidator>
     </div>
    </div>

    <div class="form row">
        <div class="form-group col-md-3">
            <label class="col-form-label"> Curp: </label>
            <asp:TextBox CssClass="form-control" ID="txtcurp" runat="server" required=""></asp:TextBox>
        </div>

        <div class="form-group col-md-3">
            <label class="col-form-label"> Sueldo: </label>
            <asp:TextBox CssClass="form-control" ID="txtsueldo" runat="server" required=""></asp:TextBox>
        </div>

    <div class="form-group col-md-3">
        <label class="col-form-label"> Estado Origen: </label>
        <asp:DropDownList CssClass="form-control" ID="DDEstado" runat="server"></asp:DropDownList>
     </div>

    <div class="form-group col-md-3">
        <label class="col-form-label"> Estatus: </label>
        <asp:DropDownList CssClass="form-control" ID="DDEstatus" runat="server"></asp:DropDownList>
     </div>
     </div>
    
    <div class="form row">
        <div>
            <asp:Button class="btn-block btn-primary btn center-block" ID="btnGurdar" runat="server" Text="Actualizar" OnClick="btnGurdar_Click" />
        </div>
    </div>
</asp:Content>
