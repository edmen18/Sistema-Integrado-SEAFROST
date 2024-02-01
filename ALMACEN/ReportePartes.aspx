<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ReportePartes.aspx.cs" Inherits="Default2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">

  <script type="text/javascript">
      $(function () {
          $("#MainContent_Txtfinicial").datepicker();
          $("#MainContent_txtffinal").datepicker();

          $("#MainContent_txtalmacen2").autocomplete(
                   {
                       source: function (request, response) {

                          
                               $.ajax({
                                   url: "ReportePartes.aspx/GetAlmacen",
                                   data: "{ 'productos': '" + request.term + "' }",
                                   dataType: "json",
                                   type: "POST",
                                   contentType: "application/json; charset=utf-8",
                                   dataFilter: function (data) { return data; },
                                   success: function (data) {
                                       response($.map(data.d, function (item) {
                                           return {
                                               value: item.A1_CALMA + "-" + item.A1_CDESCRI,
                                               id: item.A1_CALMA

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
                           $('#MainContent_txtcodfin').val(str);

                       }

                   });
          $("#MainContent_txtalmacen1").autocomplete(
                   {
                       source: function (request, response) {
                              $.ajax({
                                   url: "ReportePartes.aspx/GetAlmacen",
                                   data: "{ 'productos': '" + request.term + "' }",
                                   dataType: "json",
                                   type: "POST",
                                   contentType: "application/json; charset=utf-8",
                                   dataFilter: function (data) { return data; },
                                   success: function (data) {
                                       response($.map(data.d, function (item) {
                                           return {
                                               value: item.A1_CALMA + "-" + item.A1_CDESCRI,
                                               id: item.A1_CALMA

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
                           $('#MainContent_txtcodini').val(str);

                       }

                   });

          $("#MainContent_txtdato").autocomplete(
                    {
                        source: function (request, response) {

                            if ($("#MainContent_ddlorden").val().trim() == "PP") {
                                $.ajax({
                                    url: "ReportePartes.aspx/GetProveedores",
                                    data: "{ 'productos': '%" + request.term + "%' }",
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
                            }


                            if ($("#MainContent_ddlorden").val().trim() == "PA") {
                                $.ajax({
                                    url: "ReportePartes.aspx/GetArticulos",
                                    data: "{ 'productos': '" + request.term + "' }",
                                    dataType: "json",
                                    type: "POST",
                                    contentType: "application/json; charset=utf-8",
                                    dataFilter: function (data) { return data; },
                                    success: function (data) {
                                        response($.map(data.d, function (item) {
                                            return {
                                                value: item.AR_CDESCRI,
                                                id: item.AR_CCODIGO

                                            }
                                        }))
                                    },
                                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                                        //alert(textStatus);
                                    }
                                });
                            }


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

                         if ($("#MainContent_ddlorden").val().trim() == "PP") {
                             $.ajax({
                                 url: "ReportePartes.aspx/GetProveedores",
                                 data: "{ 'productos': '%" + request.term + "%' }",
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
                         }


                         if ($("#MainContent_ddlorden").val().trim() == "PA") {
                             $.ajax({
                                 url: "ReportePartes.aspx/GetArticulos",
                                 data: "{ 'productos': '" + request.term + "' }",
                                 dataType: "json",
                                 type: "POST",
                                 contentType: "application/json; charset=utf-8",
                                 dataFilter: function (data) { return data; },
                                 success: function (data) {
                                     response($.map(data.d, function (item) {
                                         return {
                                             value: item.AR_CDESCRI,
                                             id: item.AR_CCODIGO

                                         }
                                     }))
                                 },
                                 error: function (XMLHttpRequest, textStatus, errorThrown) {
                                     //alert(textStatus);
                                 }
                             });
                         }


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


          function filtrarmovimientos(indicador) {
              var VC = {};
              VC.TM_CTIPMOV = indicador;

              $.ajax({

                  type: "POST",
                  url: "ReportePartes.aspx/ListarMovimientos",
                  data: '{VC: ' + JSON.stringify(VC) + '}',
                  contentType: "application/json; charset=utf-8",
                  dataType: "json",
                  success: function (data) {

                      if (data.d.length > 0) {
                          var row = $("[id*=gvmovimientos] tr:last-child").clone(true);
                          $("[id*=gvmovimientos] tr").not($("[id*=gvmovimientos] tr:first-child")).remove();

                          for (var i = 0; i < data.d.length; i++) {

                              $("td", row).eq(1).html(data.d[i].TM_CTIPMOV);
                              $("td", row).eq(2).html(data.d[i].TM_CCODMOV);
                              $("td", row).eq(3).html(data.d[i].TM_CDESCRI);

                              $("[id*=gvmovimientos]").append(row);
                              row = $("[id*=gvmovimientos] tr:last-child").clone(true);
                          }
                      } else {
                          var row = $("[id*=gvmovimientos] tr:last-child").clone(true);
                          $("[id*=gvmovimientos] tr").not($("[id*=gvmovimientos] tr:first-child")).remove();

                          $("td", row).eq(1).html("");
                          $("td", row).eq(2).html("");
                          $("td", row).eq(3).html("");

                          $("[id*=gvmovimientos]").append(row);
                          alert("no se encontro registro");
                      }


                  },
                  error: function (response) {
                      if (response.length != 0)
                          alert(response);
                  }
              });

          }

          // para listar movimientos en la grilla por ambos (entrada y salida)
          function filtrarmovimientosTodos() {
              var VC = {};
              VC.TM_CTIPMOV = "";
              $.ajax({

                  type: "POST",
                  url: "ReportePartes.aspx/ListarMovimientosTodos",
                  data: '{VC: ' + JSON.stringify(VC) + '}',
                  contentType: "application/json; charset=utf-8",
                  dataType: "json",
                  success: function (data) {

                      if (data.d.length > 0) {
                          var row = $("[id*=gvmovimientos] tr:last-child").clone(true);
                          $("[id*=gvmovimientos] tr").not($("[id*=gvmovimientos] tr:first-child")).remove();

                          for (var i = 0; i < data.d.length; i++) {
                              $("td", row).eq(1).html(data.d[i].TM_CTIPMOV);
                              $("td", row).eq(2).html(data.d[i].TM_CCODMOV);
                              $("td", row).eq(3).html(data.d[i].TM_CDESCRI);

                              $("[id*=gvmovimientos]").append(row);
                              row = $("[id*=gvmovimientos] tr:last-child").clone(true);
                          }
                      } else {
                          var row = $("[id*=gvmovimientos] tr:last-child").clone(true);
                          $("[id*=gvmovimientos] tr").not($("[id*=gvmovimientos] tr:first-child")).remove();

                          $("td", row).eq(1).html("");
                          $("td", row).eq(2).html("");
                          $("td", row).eq(3).html("");

                          $("[id*=gvmovimientos]").append(row);
                          alert("no se encontro registro");
                      }


                  },
                  error: function (response) {
                      if (response.length != 0)
                          alert(response);
                  }
              });

          }

          //para listar las opciones de entrada y /o salida

          $(".valida").click(function () {

              if (document.getElementById("<%=rbentrada.ClientID%>").checked == true) {
                  filtrarmovimientos("E");
             }

              if (document.getElementById("<%=rbsalida.ClientID%>").checked == true) {
                  filtrarmovimientos("S");
              }
              if (document.getElementById("<%=rbambos.ClientID%>").checked == true) {
                  filtrarmovimientosTodos();
              }    
             
          });

          function TARERARTICULOS() {
              var LDE = [];

              $.ajax({
                  type: "POST",
                  url: "ReportePartes.aspx/getrangoarticulos",
                  data: "{ 'cod1': '" + $("#MainContent_txtcodigo").val() + "' ,  'cod2': '" + $("#MainContent_txtcodigofin").val() + "' }",
                  contentType: "application/json; charset=utf-8",
                  dataType: "json",
                  async: false,
                  success: function (data) {
                      if (data.d.length > 0) {
                          for (var i = 0; i < data.d.length; i++) {
                              LDE.push(data.d[i].AR_CCODIGO);
                              }
                      }

                  },
                  error: function (response) {
                      if (response.length != 0)
                          alert(response);
                  }

              });
              return { LDE};
          }

                function TRAERALMACEN() {
              var almacen = [" "];

              $.ajax({
                  type: "POST",
                  url: "ReportePartes.aspx/getrangoalmacen",
                  data: "{ 'cod1': '" + $("#MainContent_txtcodini").val() + "' ,  'cod2': '" + $("#MainContent_txtcodfin").val() + "' }",
                  contentType: "application/json; charset=utf-8",
                  dataType: "json",
                   async: false,
                  success: function (data) {
                      if (data.d.length > 0) {
                          for (var i = 0; i < data.d.length; i++) {
                              almacen.push(data.d[i].A1_CALMA);
                              
                          }
                      }
                    },
                  error: function (response) {
                      if (response.length != 0)
                          alert(response);
                  }
              });
               return {almacen};
             
             
            }

          //PARA IMPRIMIR LOS REPORTE

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
              if ((document.getElementById("<%=rbentrada.ClientID%>").checked == true)) {
                 mov.push(nulo,entrada);
              }
              if ((document.getElementById("<%=rbsalida.ClientID%>").checked == true)) {
                  mov.push(nulo,salida);
              }
              if ((document.getElementById("<%=rbambos.ClientID%>").checked == true)) {
                  mov.push(nulo,entrada,salida);
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
              if ((document.getElementById("<%=rbentrada.ClientID%>").checked == true)) {
                 mov.push(nulo,entrada);
              }
              if ((document.getElementById("<%=rbsalida.ClientID%>").checked == true)) {
                  mov.push(nulo,salida);
              }
              if ((document.getElementById("<%=rbambos.ClientID%>").checked == true)) {
                  mov.push(nulo,entrada,salida);
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

          $(".chigv").click(function () {

              if ($("#MainContent_chktalmacen").attr("checked") == false) {
                  $("#MainContent_txtcodini").val("");
                  $("#MainContent_txtcodini").attr("disabled", false);
              }

              else {
                  $("#MainContent_txtcodini").val("");
                   $("#MainContent_txtcodini").attr("disabled", true);
              }
          });
          $(".tod").click(function () {

              if ($("#MainContent_chktopciones").attr("checked") == false) {
                  $("#MainContent_txtcodigo").val("");
                  $("#MainContent_txtdato").val("");
                  $("#MainContent_txtcodigo").attr("disabled", false);
                  $("#MainContent_txtdato").attr("disabled", false);
              }

              else {
                  $("#MainContent_txtcodigo").val("");
                  $("#MainContent_txtdato").val("");
                  $("#MainContent_txtcodigo").attr("disabled", true);
                  $("#MainContent_txtdato").attr("disabled", true);
              }
          });

          function texto() {
             var arr = [" "];
             var imput = document.getElementsByName('opt');
             var gridView = document.getElementById("<%=gvmovimientos.ClientID %>");
              for (var i = 0; i < imput.length; i++) {
                  if (imput[i].checked)
                  {  arr.push(gridView.rows[i + 1].cells[2].innerHTML );
                     }
              }
               return {arr};
          }

          $(".lista").click(function () {

              if ((document.getElementById("<%=chklistar.ClientID%>").checked == true)) {
                var imput = document.getElementsByName('opt');
                var gridView = document.getElementById("<%=gvmovimientos.ClientID %>");
                for (var i = 0; i < imput.length; i++) {
                    imput[i].checked=true
                 }
              }
              else {
                  
                var imput = document.getElementsByName('opt');
                var gridView = document.getElementById("<%=gvmovimientos.ClientID %>");
                for (var i = 0; i < imput.length; i++) {
                    imput[i].checked=false
                 }
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
        .auto-style1 {
          width: 79px;
      }
        .auto-style2 {
          width: 318px;
      }
          .auto-style3 {
              width: 261px;
          }
          .auto-style4 {
              width: 431px;
          }
          .auto-style5 {
              width: 408px;
          }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    &nbsp;<fieldset style="background-color: #99CCFF">
        <legend style="font-weight: bold; background-color: #99CCFF;">
            <asp:Label ID="Label1" runat="server" Text="Orden" Font-Bold="True" Font-Size="10pt"></asp:Label>
    <fieldset style="background-color: #99CCFF">
        <legend style="font-weight: bold; background-color: #99CCFF;">
            <asp:Label ID="Label9" runat="server" Text="Almacen" Font-Bold="True" Font-Size="10pt"></asp:Label></legend>

        <table class="auto-style3">
            <tr>
                <td>Código inicio Almacen</td>
                <td>  <asp:TextBox ID="txtalmacen1" runat="server" Width="333px" ></asp:TextBox>  </td>
                <td>
                    <asp:TextBox ID="txtcodini" runat="server" Width="100" ></asp:TextBox>
                </td>
              
              </tr>
             <tr>
                <td>Código fin Almacen&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                 <td>  <asp:TextBox ID="txtalmacen2" runat="server" Width="329px" ></asp:TextBox>  </td>
                <td>
                    <asp:TextBox ID="txtcodfin" runat="server" Width="100" ></asp:TextBox>
                </td>
              
              </tr>
                </table>
         </fieldset></legend>

        <table>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlorden" runat="server" Height="16px" Width="345px">
                        <asp:ListItem Value="PA">POR ARTICULO</asp:ListItem>
                        <asp:ListItem Value="PP">POR PROVEEDOR</asp:ListItem>
                        </asp:DropDownList></td>
               </tr>
        </table>
              
    </fieldset>

     <fieldset style="background-color: #99CCFF">
        <legend style="font-weight: bold; background-color: #99CCFF;">
            <asp:Label ID="Label2" runat="server" Text="Movimientos" Font-Bold="True" Font-Size="10pt"></asp:Label></legend>

        <table>
             <tr>
              <td class="auto-style1">
                  <input id="rbentrada" name="opciones" type="radio" value="1" runat="server" /> Entrada<br />                                
              </td>
                 <td><input id="rbsalida" name="opciones" type="radio" value="2" runat="server"/> Salida&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br />
                  </td>

                 <td><input id="rbambos" name="opciones" type="radio" value="3" runat="server"/> Ambos&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br /></td>
                 <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <input id="btnlistar" type="button" value="Listar" class="valida"/>
                 </td>
              </tr>
            
        </table>

 <fieldset style="background-color: #99CCFF">
        <legend style="font-weight: bold; background-color: #99CCFF;">
            <asp:Label ID="Label3" runat="server" Text=" " Font-Bold="True" Font-Size="10pt"></asp:Label></legend>

     <table>
         <tr>
             <td class="auto-style5">
                  <asp:CheckBox runat="server" Text="Todos/Ninguno" class="lista" ID="chklistar" />  
             </td>


         </tr>
         
         <tr>

             <td class="auto-style5">
                 <div style="overflow: auto; width: 600px; height: 200px">
                  <asp:GridView ID="gvmovimientos" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" Width="590px" Height="183px" >
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <%--<input id="Checkbox2" type="checkbox" value="1" name="tod" class="marcar" />--%>
                              
                               </HeaderTemplate>
                            <ItemTemplate>
                                <input id="Checkbox1" type="checkbox" value="1" name="opt"  />
                            </ItemTemplate>

                        </asp:TemplateField>
                        <asp:BoundField DataField="TM_CTIPMOV" HeaderText="Tipo" />
                        <asp:BoundField HeaderText="Codigo" DataField="TM_CCODMOV" />
                        <asp:BoundField HeaderText="Descripcion" DataField="TM_CDESCRI" />

                                            
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>

                 <br />
             </div>
             </td>

         </tr>

     </table>
      </fieldset>             
    </fieldset>

    <fieldset style="background-color: #99CCFF">
        <legend style="font-weight: bold; background-color: #99CCFF;">
            <asp:Label ID="Label4" runat="server" Text="  " Font-Bold="True" Font-Size="10pt"></asp:Label></legend>
        <table>
            <tr>
                <td>Fecha Inicial</td> <td class="auto-style2"> <asp:TextBox ID="Txtfinicial" runat="server" Width="482px" Height="16px"></asp:TextBox></td>
            </tr>
             <tr>
                <td>Fecha Final</td> <td class="auto-style2"> <asp:TextBox ID="txtffinal" runat="server" Width="481px" Height="17px"></asp:TextBox></td>
            </tr>
             <tr>
                <td>Ingrese el Dato inical</td> <td class="auto-style2"> <asp:TextBox ID="txtdato" runat="server" Width="481px" Height="16px"></asp:TextBox>
                 <asp:TextBox ID="txtcodigo" runat="server" Width="480px"></asp:TextBox>
                   
                 </td>
            </tr>
            <tr>
                <td>Ingrese el Dato final</td> <td class="auto-style2"> <asp:TextBox ID="txtdato1" runat="server" Width="480px" Height="16px"></asp:TextBox>
                 <asp:TextBox ID="txtcodigofin" runat="server" Width="480px"></asp:TextBox>
                   
                 </td>
            </tr>
            <tr>
                <td>Moneda</td> <td class="auto-style2"> 
                <asp:DropDownList ID="ddlmoneda" runat="server" Height="22px" Width="481px">
                </asp:DropDownList>
                 </td>
            </tr>
             
        </table>

 </fieldset>
    <fieldset style="background-color: #99CCFF">
        <legend style="font-weight: bold; background-color: #99CCFF;">
            </legend>
        <table class="auto-style4">
            <tr> 
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                <td>
                    <input id="Button1" type="button" value="Vista" class="IMPRIMIR" />
                    &nbsp;</td>
                <td>
                   <input id="Btnexcel" type="button" value="Excel" class="EXCEL" />                    
              </td>
              </tr>

        </table>

         </fieldset>

     <div id="dvdetalle">
  

    </div>

</asp:Content>
