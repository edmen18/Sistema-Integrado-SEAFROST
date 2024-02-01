<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Reportes_Anticipos.aspx.cs" Inherits="Default2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">


    <script type="text/javascript">
        $(function () {
            $("#MainContent_txtfecha2").datepicker();
            $("#MainContent_txtfecha1").datepicker();
            $("#MainContent_txtprove").autocomplete(
                     {     source: function (request, response) {
                             $.ajax({
                                 url: "OCemision.aspx/GetProveedores",
                                 data: "{ 'productos': '" + request.term + "' }",
                                 dataType: "json",
                                 type: "POST",
                                 contentType: "application/json; charset=utf-8",
                                 dataFilter: function (data) { return data; },
                                 success: function (data) {
                                     response($.map(data.d, function (item) {
                                         return {
                                             value: item.ADESANE,
                                             id: item.ACODANE
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
                             $('#MainContent_txtidpro').val(str);


                         }
                     });
            $("#MainContent_txtsolicitante").autocomplete(
         {
             source: function (request, response) {
                 var VC = {};
                 VC.TG_CDESCRI = $("#MainContent_txtsolicitante").val();
                 $.ajax({
                     url: "Reportes_Anticipos.aspx/ListarTabla",
                     data: '{TABL: ' + JSON.stringify(VC) + '}',
                     dataType: "json",
                     type: "POST",
                     contentType: "application/json; charset=utf-8",
                     dataFilter: function (data) { return data; },
                     success: function (data) {
                         response($.map(data.d, function (item) {
                             return {
                                 value: item.TG_CCLAVE +"-"+item.TG_CDESCRI,
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
                 $('#MainContent_txtcodsolicitante').val(str);


             }
         });


            $(window).load(function () {
                contarndw = 0;
                cc = 1;
                sw_edicion = 0;
                sw_nuevo = 0;
                contaditem = 0;

            });

            $(".imprimi").click(function () {

                opciones = document.getElementsByName("opcion");

                var seleccionado = "";
                for (var i = 0; i < opciones.length; i++) {
                    if (opciones[i].checked) {
                        seleccionado = opciones[i].value;
                        break;
                    }
                }


                if (seleccionado == 1) {
                    //$("#MainContent_txtnumero").attr("disabled", false);
                    //$("#MainContent_ddlestad").attr("disabled", false);
                var idnumor = $('#MainContent_txtidpro').val();
  
                if (idnumor != "&nbsp;") {
                    window.open("../ORDENCOMPRA/REPORTES/RptAnticipoProv.aspx?ID= " + idnumor, '_blank');
                } else {
                    alert("Error en envio de Datos");
                }
                }

                if (seleccionado == 2) {
                    var idnumor = $('#MainContent_txtnumero').val();

                    if (idnumor != "&nbsp;") {
                        window.open("../ORDENCOMPRA/REPORTES/RptAnticipoNum.aspx?ID= " + idnumor, '_blank');
                    } else {
                        alert("Error en envio de Datos");
                    }
                }
                if (seleccionado == 3) {
                    var fecini = $('#MainContent_txtfecha1').val();
                    var fecfin = $('#MainContent_txtfecha2').val();
                    if (fecini != "&nbsp;" && fecfin != "&nbsp;") {
                        window.open("../ORDENCOMPRA/REPORTES/RptAnticiposFecha.aspx?FecIni= " + fecini + "&FecFin=" + fecfin, '_blank');
                    } else {
                        alert("Error en envio de Datos");
                    }
                }

                if (seleccionado == 4) {
                    var estado = $("#MainContent_ddlestad").val().trim();
                    if (estado != "&nbsp;") {
                        window.open("../ORDENCOMPRA/REPORTES/RptAnticipoEstado.aspx?ESTADO= " + estado.trim(), '_blank');
                    } else {
                        alert("Error en envio de Datos");
                    }
                }

            });

            $(".LIMPIAR").click(function () {

               if ((document.getElementById("<%=rbproveedor.ClientID%>").checked == true))
               {
                  
                    $('#MainContent_txtnumero').val("");
                    $('#MainContent_txtidpro').val("");
                    $('#MainContent_txtprove').val("");
                    $('#MainContent_txtcodsolicitante').val("");
                    $('#MainContent_txtsolicitante').val("");
               }
                if ((document.getElementById("<%=rbestado.ClientID%>").checked == true))
                {
                   
                    $('#MainContent_txtnumero').val("");
                    $('#MainContent_txtidpro').val("");
                    $('#MainContent_txtprove').val("");
                    $('#MainContent_txtcodsolicitante').val("");
                    $('#MainContent_txtsolicitante').val("");
                }
                if ((document.getElementById("<%=rbfechas.ClientID%>").checked == true))
                {
                    $('#MainContent_txtnumero').val("");
                    $('#MainContent_txtidpro').val("");
                    $('#MainContent_txtprove').val("");
                    $('#MainContent_txtcodsolicitante').val("");
                    $('#MainContent_txtsolicitante').val("");
                }
                if ((document.getElementById("<%=rbnumero.ClientID%>").checked == true))
                {
                    $('#MainContent_txtnumero').val("");
                    $('#MainContent_txtidpro').val("");
                    $('#MainContent_txtprove').val("");
                    $('#MainContent_txtcodsolicitante').val("");
                    $('#MainContent_txtsolicitante').val("");
                 }
              if ((document.getElementById("<%=rbsolicitante.ClientID%>").checked == true))
                {
                    $('#MainContent_txtnumero').val("");
                    $('#MainContent_txtidpro').val("");
                    $('#MainContent_txtprove').val("");
                    $('#MainContent_txtnumero').val("");
               }
          });
                                
        });

      
    </script>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <fieldset style="background-color: #99CCFF">
        <legend style="font-weight: bold; background-color: #99CCFF;">
            <asp:Label ID="Label9" runat="server" Text="OPCIONES DE FILTRADO" Font-Bold="True" Font-Size="12pt"></asp:Label></legend>
        <table>
              <tr>
              <td>
                  <input id="rbproveedor" name="opcion" type="radio" value="1" runat="server" class="LIMPIAR" /> Por proveedor<br />
                  <input id="rbnumero" name="opcion" type="radio" value="2" runat="server" class="LIMPIAR" /> Por Orden<br />
                  <input id="rbfechas" name="opcion" type="radio" value="3" runat="server" class="LIMPIAR"/> Por Fechas <br />
                  <input id="rbestado" name="opcion" type="radio" value="4" runat="server" class="LIMPIAR"/> Por estado <br />
                  <input id="rbsolicitante" name="opcion" type="radio" value="5" runat="server" class="LIMPIAR"/> Por Solicitante <br />
              </td>                 

              </tr>
            <tr>
                <td>
                 <input id="chktodos" name="opcion" type="checkbox" value="1" runat="server" /> Ver Todos<br />
                </td>

            </tr>


        </table>
        <table>

            <tr>
                <td>Solicitante</td>
                <td colspan="3">
                    <asp:TextBox ID="txtsolicitante" runat="server" Width="248px"></asp:TextBox>
                    <asp:TextBox ID="txtcodsolicitante" runat="server" Width="106px"></asp:TextBox>
                   </td>
               </tr>

            <tr>
                <td>Proveedor</td>
                <td colspan="3">
                    <asp:TextBox ID="txtprove" runat="server" Width="248px"></asp:TextBox>
                    <asp:TextBox ID="txtidpro" runat="server" Width="106px"></asp:TextBox>
                   </td>
               </tr>
            <tr>
                <td>Numero Orden</td>
                <td>  <asp:TextBox ID="txtnumero" runat="server" Width="124px"></asp:TextBox></td>

            </tr>

                 <tr>

                 <td>Fecha:</td>
                <td>
                         <asp:TextBox ID="txtfecha1" runat="server" Width="132px"></asp:TextBox>
                </td>
                <td>Fecha al:                                                                         
                    <asp:TextBox ID="txtfecha2" runat="server" Width="162px"></asp:TextBox>
                     </td>
                <td>
                    &nbsp;</td>

            </tr>
            <tr>
                <td>Estado </td>
                <td>
                    <asp:DropDownList ID="ddlestad" runat="server" Width="130">
                        <asp:ListItem Value="P">Pendiente</asp:ListItem>
                        <asp:ListItem Value="L">Liquidada</asp:ListItem>
                    </asp:DropDownList>
                </td>
                
                <td>
                    &nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Ver Excel" />
                                    </td>
            </tr>
        </table>
    </fieldset>


   
   

</asp:Content>


