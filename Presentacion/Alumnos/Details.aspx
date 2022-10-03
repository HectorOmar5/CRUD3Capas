<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="Presentacion.Alumnos.Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
    <asp:Label ID="lblHidden" runat="server" Text=""></asp:Label>
    <ajaxToolkit:ModalPopupExtender ID="mpeModalISR" runat="server" TargetControlID="lblHidden" PopupControlID="venModalSrvISR" DropShadow="true" BackgroundCssClass="modalBackground"></ajaxToolkit:ModalPopupExtender>
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
        <label class="col-form-label"> Estatus: </label>
        <asp:Label Font-Size="Medium" ID="idEstatus" runat="server" Text="ID Estatus" required=""></asp:Label>
    </div>

    <!-- LABEL CALCULAR IMSS E ISR -->
    <div>
        <label class="col-form-label"> Resultado: </label>
        <asp:Label ID="lblResultado" runat="server" Text="Label"></asp:Label>
    </div>

    <!-- BOTONES DE CALCULAR ISR E IMSS -->
    <div class="btn-group">
        
       
        <input id="iModal" type="button" onclick="CalcularIMSS()" class="btn btn-primary btn-md" value="CalcularIMSS" />
    </div>
    <div class="btn-group">
        <asp:Button CssClass="btn btn-block btn btn-success" ID="btnISR" runat="server" Text="Calcular ISR" Width="160px" OnClick="btnISR_Click" />
    </div>
    <div class="form row">
        <a href="./Index.aspx" title="Ir la página anterior">Volver Al Inicio</a>
    </div>

    <!-- INICIALIZANDO CONTROLES MODALES -->

    <%--Ventana Modal IMSS - Servidor--%>
  <div class="modal" id="venModalclienteIMSS">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Cálculo del IMSS</h4>
                    <asp:Button ID="btnX" runat="server" Text="&times;" class="close" />
                </div>
                <!-- Cuerpo de la Modal -->
                <div class="modal-body">
                    <dl>
                        <dt>Enfermedades y Maternidad</dt>
                        <dd>
                            <asp:Label ID="lblEnfermedades" runat="server" Text="Label"></asp:Label>
                        </dd>
                        <dt>Invalidez y Vida</dt>
                        <dd>
                            <asp:Label ID="lblInvalidez" runat="server" Text="Label"></asp:Label>
                        </dd>
                        <dt>Retiro</dt>
                        <dd>
                            <asp:Label ID="lblRetiro" runat="server" Text="Label"></asp:Label>
                        </dd>

                        <dt>Cesantia</dt>
                        <dd>
                            <asp:Label ID="lblCesantia" runat="server" Text="Label"></asp:Label>
                        </dd>
                        <dt>Infonavit</dt>
                        <dd>
                            <asp:Label ID="lblInfonavit" runat="server" Text="Label"></asp:Label>
                        </dd>

                    </dl>

                </div>
                <!-- Modal footer -->
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>

    </div>
    <%--Ventana Modal IMSS - Servidor--%>
  <div id="venModalSrvISR">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Cálculo del ISR</h4>
                    <asp:Button ID="btnXISR" runat="server" Text="&times;" class="close" />
                </div>
                <!-- Cuerpo de la Modal -->
                <div class="modal-body">
                    <dl>
                        <dt>Limite Inferior</dt>
                        <dd>
                            <asp:Label ID="lblLimInf" runat="server" Text="Label"></asp:Label>
                        </dd>
                        <dt>Limite Superior</dt>
                        <dd>
                            <asp:Label ID="lblLimSup" runat="server" Text="Label"></asp:Label>
                        </dd>

                        <dt>Cuota Fija</dt>
                        <dd>
                            <asp:Label ID="lblCuotaFija" runat="server" Text="Label"></asp:Label>
                        </dd>
                        <dt>Excedente Limite Inferior</dt>
                        <dd>
                            <asp:Label ID="lblExcedente" runat="server" Text="Label"></asp:Label>
                        </dd>

                        <dt>Subsidio</dt>
                        <dd>
                            <asp:Label ID="lblSubsidio" runat="server" Text="Label"></asp:Label>
                        </dd>
                        <dt>Impuesto</dt>
                        <dd>
                            <asp:Label ID="lblImpuesto" runat="server" Text="Label"></asp:Label>
                        </dd>

                    </dl>

                </div>
                <!-- Modal footer -->
                <div class="modal-footer">
                    <asp:Button ID="btnCerrarISR" runat="server" Text="Cerrar" CssClass="btn btn-danger" />
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function CalcularIMSS() {
            $("#venModalclienteIMSS").modal();

            var id = $("#<%= idAlu.ClientID%>").text();
            $.ajax({
                type: "POST",
                url: "https://localhost:44338/WSAlumnos.asmx/CalcularIMSS",
                data: "{'id':" + id + " }",
                contentType:"application/json; charset=utf-8",
                dataType: "json",
                success: Response => {
                    //alert("Exito");

                    //JQuery
                    var aportacionesIMSS = Response.d;
                    $("#<%= lblEnfermedades.ClientID%>").text(aportacionesIMSS.EnfermedadMaternidad);
                    $("#<%=lblInvalidez.ClientID%>").text(aportacionesIMSS.InvalidezVida);
                    $("#<%=lblRetiro.ClientID%>").text(aportacionesIMSS.Retiro);
                    $("#<%=lblCesantia.ClientID%>").text(aportacionesIMSS.Cesantia);
                    $("#<%=lblInfonavit.ClientID%>").text(aportacionesIMSS.Infonavit);
                }

            });
        }
    </script>

</asp:Content>
