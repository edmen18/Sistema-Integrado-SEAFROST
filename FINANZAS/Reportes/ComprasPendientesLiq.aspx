<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="ComprasPendientesLiq.aspx.cs" Inherits="FINANZAS_Reportes_ComprasPendientesLiq" %>
<%--<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ComprasPendientesLiqq.aspx.cs" Inherits="ComprasPendientesLiq" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">

  <script type="text/javascript">
      $(function () {
        $("#MainContent_Txtfinicial").datepicker();
          $("#MainContent_txtffinal").datepicker();

       
          $("#MainContent_txtdato").autocomplete(
                    {
                        source: function (request, response) {

                           
                                $.ajax({
                                    url: "ComprasPendientesLiq.aspx/GetProveedores",
                                    data: "{ 'productos': '" + request.term + "' }",
                                    dataType: "json",
                                    type: "POST",
                                    contentType: "application/json; charset=utf-8",
                                    dataFilter: function (data) { return data; },
                                    success: function (data) {
                                        response($.map(data.d, function (item) {
                                            return {
                                                value:item.ACODANE+"-"+ item.ADESANE,
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
                            $('#MainContent_txtcodigo').val(str);

                        }

                    });

          $("#MainContent_txtdato1").autocomplete(
                 {
                     source: function (request, response) {

                      
                             $.ajax({
                                 url: "ComprasPendientesLiq.aspx/GetProveedores",
                                 data: "{ 'productos': '" + request.term + "' }",
                                 dataType: "json",
                                 type: "POST",
                                 contentType: "application/json; charset=utf-8",
                                 dataFilter: function (data) { return data; },
                                 success: function (data) {
                                     response($.map(data.d, function (item) {
                                         return {
                                             value: item.ACODANE + "-" + item.ADESANE,
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
                         $('#MainContent_txtcodigofin').val(str);

                     }

                 });


          $(".IMPRIMIR").click(function () {
             
              //obtener los items seleccionados de los movimientros
              opciones = document.getElementsByName("opciones");
              var selec = "";
              var mov = [];
              var entrada = "E";
              var salida = "S"
              var nulo = "";
              for (var j = 0; j < opciones.length; j++) {
                  if (opciones[j].checked) {
                      selec = opciones[j].value;
                      break;
                  }
              }
             

              ///// en caso de ser por articulo
              if ($('#MainContent_ddlorden').val() == "PA") {

                  var fecini = $('#MainContent_Txtfinicial').val();
                  var fecfin = $('#MainContent_txtffinal').val();
                  var articulo = "";
                  var almacen = "";
                  var moneda = $('#MainContent_ddlmoneda').val();
                  var indicador = "";

                                                    
                  if (fecini != "&nbsp;" && fecfin != "&nbsp;") {
                         indicador = "N"
                         almacenes = TRAERALMACEN().almacen;
                          window.open("../ALMACEN/REPORTES/ESVArticuloSC.aspx?FecIni= " + fecini + "&FecFin=" + fecfin + " &almacen=" + almacenes + "&moneda=" + moneda +"&articulo1=" + $('#MainContent_txtcodigo').val() + "&articulo2=" + $('#MainContent_txtcodigofin').val() + "&ind=" + indicador + "&cadena= " + texto().arr + "&movimiento= " + mov, '_blank');
                     
                                        
                  }
                  else { alert("Error en envio de Datos"); }
              }
              // fin en caso de ser por articulo.
              // EN CASO DE SER POR PROVEEDOR

              if ($('#MainContent_ddlorden').val() == "PP") {

                  var fecini = $('#MainContent_Txtfinicial').val();
                  var fecfin = $('#MainContent_txtffinal').val();
                  var moneda = $('#MainContent_ddlmoneda').val();
                  var indicador = "";
                                   
                  if (fecini != "&nbsp;" && fecfin != "&nbsp;") {
                      indicador = "N";
                          var almac = TRAERALMACEN().almacen;
                          window.open("../ALMACEN/REPORTES/ESVProveedorSC.aspx?FecIni= " + fecini + "&FecFin=" + fecfin + " &almacen=" + almac + "&moneda=" + moneda + "&proveedor1=" + $('#MainContent_txtcodigo').val() + "&proveedor2=" + $('#MainContent_txtcodigofin').val() + "&ind=" + indicador + "&cadena= " + texto().arr + "&movimiento= " + mov, '_blank');
                     
                  }
                  else { alert("Error en envio de Datos"); }
              }

          });

          
          $(".EXCEL").click(function () {
             
     
              //obtener los items seleccionados de los movimientros
              opciones = document.getElementsByName("opciones");
              var selec = "";
              var mov = [];
              var entrada = "E";
              var salida = "S"
              var nulo = "";
              for (var j = 0; j < opciones.length; j++) {
                  if (opciones[j].checked) {
                      selec = opciones[j].value;
                      break;
                  }
              }
             
              ///// en caso de ser por articulo
              if ($('#MainContent_ddlorden').val() == "PA") {

                  var fecini = $('#MainContent_Txtfinicial').val();
                  var fecfin = $('#MainContent_txtffinal').val();
                  var articulo = "";
                  var almacen = "";
                  var moneda = $('#MainContent_ddlmoneda').val();
                  var indicador = "";
                              
                  if (fecini != "&nbsp;" && fecfin != "&nbsp;") {
                   
                          indicador = "N"
                          almacenes = TRAERALMACEN().almacen;
                          window.open("../ALMACEN/REPORTES/Excel.aspx?FecIni= " + fecini + "&FecFin=" + fecfin + " &almacen=" + almacenes + "&moneda=" + moneda + "&articulo1=" + $('#MainContent_txtcodigo').val() + "&articulo2=" + $('#MainContent_txtcodigofin').val() + "&ind=" + indicador + "&cadena= " + texto().arr + "&movimiento= " + mov, '_blank');
                      }
                  else { alert("Error en envio de Datos"); }
              }
              // fin en caso de ser por articulo.
              // EN CASO DE SER POR PROVEEDOR

              if ($('#MainContent_ddlorden').val() == "PP") {

                  var fecini = $('#MainContent_Txtfinicial').val();
                  var fecfin = $('#MainContent_txtffinal').val();
                  var proveedor = "";
                  var almacen = "";
                  var moneda = $('#MainContent_ddlmoneda').val();
                  var indicador = "";
                                   
                  if (fecini != "&nbsp;" && fecfin != "&nbsp;") {
                    
                          indicador = "N"
                          almac = TRAERALMACEN().almacen;
                          window.open("../ALMACEN/REPORTES/ExcelProveedores.aspx?FecIni= " + fecini + "&FecFin=" + fecfin + " &almacen=" + almac + "&moneda=" + moneda + "&proveedor1=" + $('#MainContent_txtcodigo').val() + "&proveedor2=" + $('#MainContent_txtcodigofin').val() + "&ind=" + indicador + "&cadena= " + texto().arr + "&movimiento= " + mov, '_blank');
                                       

                  }
                  else { alert("Error en envio de Datos"); }
              }

              
          });

              
       });
      </script>
      <style type="text/css">
        #btnsalir {
            width: 67px;
        }
        #btngrabar {
            width: 67px;
        }
        .auto-style2 {
          width: 318px;
      }
          .auto-style3 {
              width: 674px;
          }
          .auto-style4 {
              width: 431px;
          }
          .auto-style5 {
              width: 193px;
          }
          #Btnexcel {
          }
          </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    &nbsp;<fieldset style="background-color: #99CCFF">
        <legend style="font-weight: bold; background-color: #99CCFF;">
    <fieldset style="background-color: #99CCFF; width: 674px;">
        <legend style="font-weight: bold; background-color: #99CCFF;">
            <asp:Label ID="Label9" runat="server" Text="Compras Pendientes de Liquidación" Font-Bold="True" Font-Size="10pt"></asp:Label></legend>

        <table class="auto-style3">
            <tr>
                <td class="auto-style5">Almacen&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td>
                    <asp:DropDownList ID="ddlalmacen" runat="server" Height="27px" Width="339px"></asp:DropDownList>  </td>
              </tr>  
                
            <tr>
                <td class="auto-style5">Fecha Inicial</td> <td class="auto-style2"> <asp:TextBox ID="Txtfinicial" runat="server" Width="339px" Height="16px"></asp:TextBox></td>
            </tr>
             <tr>
                <td class="auto-style5">Fecha Final</td> <td class="auto-style2"> <asp:TextBox ID="txtffinal" runat="server" Width="339px" Height="17px"></asp:TextBox></td>
            </tr>
             <tr>
                <td class="auto-style5">Ingrese el Dato Inical</td> <td class="auto-style2"> <asp:TextBox ID="txtdato" runat="server" Width="339px" Height="16px"></asp:TextBox>
                
                   
                 </td>
                 <td>
                  <asp:TextBox ID="txtcodigo" runat="server" Width="93px"></asp:TextBox>
                   
                 </td>
            </tr>
            <tr>
                <td class="auto-style5">Ingrese el Dato final</td> <td class="auto-style2"> <asp:TextBox ID="txtdato1" runat="server" Width="339px" Height="16px"></asp:TextBox>
                                  
                 </td>
                <td><asp:TextBox ID="txtcodigofin" runat="server" Width="93px"></asp:TextBox></td>
            </tr>
                        
        </table>
        </legend>
 </fieldset>
    <fieldset style="background-color: #99CCFF">
          <table class="auto-style4">
               <tr>
              <td class="auto-style1">
                  <input id="rbdetallado" name="opciones" type="radio" value="1" runat="server"/> Detallado<br />                                
              </td>
                 <td>
                  <input id="rbresumido" name="opciones" type="radio" value="2" runat="server"/> Resumido <br />
                                 
              </tr>
              <tr>
                  <td>
                      <br />
                                         
                  </td>

              </tr>
            <tr> 
                 <td>
                &nbsp;&nbsp;</td>
                <td>
                   &nbsp;<asp:Button ID="btnexcel" runat="server" Height="32px" Text="Excel" Width="111px" OnClick="btnexcel_Click" />
              </td>
              </tr>

        </table>

         </fieldset>

     <div id="dvdetalle">
  

    </div>

</asp:Content>

