
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ReportesTrabajos.aspx.cs" Inherits="Default2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server"> 

<script type="text/javascript">
    $(function () {

        $("#MainContent_txtcencosto0").autocomplete(
                 {
                     source: function (request, response) {

                         $.ajax({
                             url: "ReportesTrabajos.aspx/GETVARIOS",
                             data: "{ 'CLAVE': '" + request.term + "' ,  'INDICADOR': '10' }",
                             dataType: "json",
                             type: "POST",
                             contentType: "application/json; charset=utf-8",
                             dataFilter: function (data) { return data; },
                             success: function (data) {
                                 response($.map(data.d, function (item) {
                                     return {
                                         value: item.TG_CDESCRI + " - " + item.TG_CCLAVE,
                                         id: item.TG_CCLAVE

                                     }
                                 }))
                             },
                             error: function (XMLHttpRequest, textStatus, errorThrown) {
                                 //alert(textStatus);
                             }
                         });
                     },
                     minLength: 1,
                     select: function (event, ui) {
                         var str = ui.item.id;
                         var cadena = str
                         posicionEspacio = cadena.indexOf("@"), //Obtengo la posición del espacio en la cadena
                         primerApellido = cadena.substring(0, posicionEspacio) //Obtengo la porción deseada de la cadena
                         enMinuscula = primerApellido.toLowerCase(); //Convierto el apellido a minúscula

                         primerApellido = cadena.substring(posicionEspacio + 1, str.length)
                         $('#MainContent_txtcodcencosto0').val(str);


                     }
                 });

        $("#MainContent_txtfecha1").datepicker();
        $("#MainContent_txtfecha2").datepicker();
    });
        </script>
  </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <fieldset style="background-color: #99CCFF">
        <legend style="font-weight: bold; background-color: #99CCFF;">
            <asp:Label ID="Label9" runat="server" Text="REPORTE DE TRABAJOS EN CURSO" Font-Bold="True" Font-Size="12pt"></asp:Label></legend>

        <table>
            <tr>
                <td>Area</td>
                <td colspan="3">
                    <asp:DropDownList ID="ddlarea" runat="server" Height="16px" Width="324px">
                    </asp:DropDownList>
                </td>
               
                <td>
                    <asp:Label ID="lblacceso" runat="server" ForeColor="#66CCFF"></asp:Label>
                </td>
            </tr>
             <tr>
                <td>
                    Equipo</td>
                <td class="auto-style4">
                    <asp:DropDownList ID="ddlequipo" runat="server" Height="22px" Width="324px">
                    </asp:DropDownList>
                </td>
               
                  <td>
                    &nbsp;<asp:Label ID="lblusuario" runat="server" ForeColor="#66CCFF"></asp:Label>
                </td>
                 </tr>
             <tr>
                <td>Planta</td>
                <td colspan="3">
                    <asp:DropDownList ID="ddlplanta" runat="server" Height="16px" Width="324px">
                    </asp:DropDownList>
                &nbsp;</td>
                
                 </tr>
           <tr>
                <td>
                    C. Costo</td>
                <td>
                    <asp:TextBox ID="txtcencosto0" runat="server" Width="324px"></asp:TextBox> 
                </td>
                <td>
                  <asp:TextBox ID="txtcodcencosto0" runat="server" Width="130px"></asp:TextBox> 
                
                </td>
              
            </tr>
            
            <tr>
                <td>Situación Avance</td>
                <td>
                    <asp:DropDownList ID="ddlsituacion" runat="server" Height="18px" Width="324px">
                        <asp:ListItem Value="T">TODOS</asp:ListItem>
                        <asp:ListItem Value="P">PENDIENTES</asp:ListItem>
                        <asp:ListItem Value="C">CULMINADOS</asp:ListItem>
                    </asp:DropDownList> </td>
            </tr>
           
        </table>
        <table>
             <tr>
             <td>Fecha:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td>
                    <asp:TextBox ID="txtfecha1" runat="server" Width="93px" placeholder="00/00/0000"></asp:TextBox>
                </td>
                <td>Fecha al:</td>
                <td>
                    <asp:TextBox ID="txtfecha2" runat="server" Width="92px" placeholder="00/00/0000"></asp:TextBox>
                </td> <td>
                <asp:Button ID="btnbuscar" runat="server" Text="Buscar" Width="79px" OnClick="btnbuscar_Click" />
                </td>
            </tr>
        </table>
    </fieldset>
    <table>
        <tr>
            <td>
                &nbsp;</td>
        </tr>

   </table>   
</asp:Content>