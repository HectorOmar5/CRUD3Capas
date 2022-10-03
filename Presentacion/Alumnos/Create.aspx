<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="Presentacion.Alumnos.Create" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

   <hr />

        <div class="form row">
            <div class="form-group col-md-4"> 
                <label for="text" class="col-form-label">Nombre: </label>
                <asp:TextBox autocomplete="off" placeholder="Nombre" class="form-control" ID="txtnombre" runat="server" required=""></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RFVNombre" runat="server" ErrorMessage="El Campo Nombre Está Vacio" ControlToValidate="txtnombre" CssClass="text-danger"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="REVNombre" runat="server" ErrorMessage="Checa Bien Tu Texto"  CssClass="text-danger" ControlToValidate="txtnombre" ValidationExpression="[a-zA-Z\u00C0-\u017F\s]*"></asp:RegularExpressionValidator>

            </div>

            <div class="form-group col-md-4"> 
                <label for="text" class="col-form-label">Apellido Paterno: </label>
                <asp:TextBox autocomplete="off" placeholder="Apellido Paterno" class="form-control" ID="txtapellidoP" runat="server" required=""></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFVApellidoP" runat="server" ErrorMessage="El Campo Apellido Paterno Está Vacio" ControlToValidate="txtapellidoP" CssClass="text-danger"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="REVApellidoP" runat="server" ErrorMessage="Checa Bien Tu Texto" ControlToValidate="txtapellidoP" ValidationExpression="[a-zA-Z\u00C0-\u017F\s]*"></asp:RegularExpressionValidator>
            </div>

            <div class="form-group col-md-4">
                <label for="text" class="col-form-label">Apellido Materno: </label>
                <asp:TextBox autocomplete="off" placeholder="Apellido Materno" class="form-control" ID="txtapellidoM" runat="server" required=""></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RFVApellidoM" runat="server" ErrorMessage="El Campo Apellido Materno Está Vacio" ControlToValidate="txtapellidoM" CssClass="text-danger"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="REVApellidoM" runat="server" ErrorMessage="Checa Bien Tu Texto" ControlToValidate="txtapellidoM" ValidationExpression="[a-zA-Z\u00C0-\u017F\s]*"></asp:RegularExpressionValidator>
            </div>
        </div>

     

      <div class="form row">
        <div class="form-group col-md-4">
            <label class="col-form-label">Correo Electronico: </label>
            <asp:TextBox autocomplete="off" TextMode="Email" class="form-control" placeholder="Correo Electronico" ID="txtcorreo" runat="server" required=""></asp:TextBox>
            <asp:RequiredFieldValidator ID="RFVCorreo" runat="server" ErrorMessage="El Campo Correo Está Vació" ControlToValidate="txtcorreo" CssClass="text-danger"></asp:RequiredFieldValidator>
        </div>
     
        <div class="form-group col-md-4">
            <label for="phone" class="col-form-label">Telefono: </label>
            <asp:TextBox autocomplete="off" TextMode="Phone" class="form-control" placeholder="Telefono" ID="txttelefono" runat="server" required=""></asp:TextBox>
            <asp:RequiredFieldValidator ID="RFVTel" runat="server" ErrorMessage="El Campo Telefono Está Vacio" ControlToValidate="txttelefono" CssClass="text-danger"></asp:RequiredFieldValidator>
            <div>
                <asp:RegularExpressionValidator ID="REVTelefono" runat="server" ErrorMessage="Telefono Incorrecto" ControlToValidate="txttelefono" CssClass="text-danger" ValidationExpression="/^\d{10}$/"></asp:RegularExpressionValidator>
            </div>
        </div>

        <div class="form-group col-md-4">
            <label class="col-form-label">Fecha Nacimiento: </label>
            <asp:TextBox CssClass="form-control"  TextMode="Date" ID="fechaNac" runat="server"></asp:TextBox>
            <div>
                <asp:RangeValidator ID="RVFechaNac" runat="server" ErrorMessage="La fecha debe de estar 01-01-1990 y 31-12-2000" CssClass="text-danger" MaximumValue="31-12-2000" MinimumValue="01-01-1990" Type="Date" ControlToValidate="fechaNac"></asp:RangeValidator>
            </div>
            <div>
                <asp:CustomValidator ID="CVFechaNac" runat="server" ErrorMessage="La fecha de nacimiento y curp no coinciden" CssClass="text-danger" ControlToValidate="fechaNac" ClientValidationFunction="ValidacionFechaCurp"></asp:CustomValidator>
            </div>
         </div>
        </div>


    <div class="form row">
        <div class="form-group col-md-3">
            <label class="col-form-label">Curp: </label>
            <asp:TextBox autocomplete="off" placeholder="Curp" CssClass="form-control" ID="txtcurp" runat="server" required=""></asp:TextBox>
            <asp:RegularExpressionValidator ID="REVCurp" runat="server" ErrorMessage="Formato de la curp es incorrecta" CssClass="text-danger" ControlToValidate="txtcurp" ValidationExpression="^([A-Z][AEIOUX][A-Z]{2}\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])[HM](?:AS|B[CS]|C[CLMSH]|D[FG]|G[TR]|HG|JC|M[CNS]|N[ETL]|OC|PL|Q[TR]|S[PLR]|T[CSL]|VZ|YN|ZS)[B-DF-HJ-NP-TV-Z]{3}[A-Z\d])(\d)$"></asp:RegularExpressionValidator>          
        </div>

     <div class="form-group col-md-3">
        <label class="col-form-label">Sueldo: </label>
        <asp:TextBox autocomplete="off" placeholder="Sueldo" CssClass="form-control" ID="txtsueldo" runat="server" required=""></asp:TextBox>
         <asp:RequiredFieldValidator ID="RFVSueldo" runat="server" ErrorMessage="El Campo Telefono Está Vacio" ControlToValidate="txtsueldo" CssClass="text-danger"></asp:RequiredFieldValidator>
         <asp:RangeValidator ID="RVSueldo" runat="server" ErrorMessage="El Sueldo Debe De Estar Entre 10,000 y 40,000" CssClass="text-danger"  MinimumValue="10000" MaximumValue="40000" Type="Double" ControlToValidate="txtsueldo"></asp:RangeValidator>
     </div>

    <div class="form-group col-md-3">
        <label class="col-form-label">Estado Origen: </label>
        <asp:DropDownList CssClass="form-control" placeholder="Estado Origen" Font-Bold="true" ID="DDEstadoOrigen" runat="server"></asp:DropDownList>
     </div>

    <div class="form-group col-md-3">
        <label class="col-form-label">Estatus: </label>
        <asp:DropDownList CssClass="form-control" placeholder="Estatus" Font-Bold="true" ID="DDEstatus" runat="server"></asp:DropDownList>
    </div>
    </div>
    

    <div class="form row">
    <div>
        <asp:Button CssClass="btn btn-block btn btn-success btn center-block" ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
    </div>
    </div>
       

    <script type="text/javascript">
        function CVFechaNac(source, args) {
            var fechaNac = args.val
            var ExtractCurp = $("<%=txtcurp.ClientID%>").val().substring(4, 6)
            var FormatCurp = fechaNac.substring(2, 2) + fechaNac(5, 2) + fechaNac(7, 3)
            args.IsValid = ExtractCurp == cFormatCurp;
        }
        
    </script>
</asp:Content>
