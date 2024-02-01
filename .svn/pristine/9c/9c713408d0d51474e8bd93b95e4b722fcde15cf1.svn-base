<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ConsumoCCosto.aspx.cs" Inherits="Default2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/javascript">
        $(function () {

            $("#MainContent_txtdato").autocomplete(
                       {
                           source: function (request, response) {
                            
                               if (($("#MainContent_ddlorden").val().trim() != "PL")) {
                                   $.ajax({
                                       url: "ConsumoCCosto.aspx/GETVARIOS",
                                       data: "{ 'CLAVE': '" + request.term + "' ,  'INDICADOR': '" + $("#MainContent_ddlorden").val() + "' }",
                                       dataType: "json",
                                       type: "POST",
                                       contentType: "application/json; charset=utf-8",
                                       dataFilter: function (data) { return data; },
                                       success: function (data) {
                                           response($.map(data.d, function (item) {
                                               return {
                                                   value: item.TG_CCLAVE + " - " + item.TG_CDESCRI,
                                                   id: item.TG_CCLAVE

                                               }
                                           }))
                                       },
                                       error: function (XMLHttpRequest, textStatus, errorThrown) {
                                           //alert(textStatus);
                                       }
                                   });


                               }
                               if ($("#MainContent_ddlorden").val().trim() == "PL") {
                                   $.ajax({
                                       url: "ConsumoCCosto.aspx/GETLINEAS",
                                       data: "{ 'CLAVE': '" + request.term + "' }",
                                       dataType: "json",
                                       type: "POST",
                                       contentType: "application/json; charset=utf-8",
                                       dataFilter: function (data) { return data; },
                                       success: function (data) {
                                           response($.map(data.d, function (item) {
                                               return {
                                                   value: item.LI_CCODLIN + " - " + item.LI_CDESLIN,
                                                   id: item.LI_CCODLIN

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
                             if ($("#MainContent_ddlorden").val().trim() != "PL") {
                                   $.ajax({
                                       url: "ConsumoCCosto.aspx/GETVARIOS",
                                       data: "{ 'CLAVE': '" + request.term + "' ,  'INDICADOR': '" + $("#MainContent_ddlorden").val() + "' }",
                                       dataType: "json",
                                       type: "POST",
                                       contentType: "application/json; charset=utf-8",
                                       dataFilter: function (data) { return data; },
                                       success: function (data) {
                                           response($.map(data.d, function (item) {
                                               return {
                                                   value: item.TG_CCLAVE + " - " + item.TG_CDESCRI,
                                                   id: item.TG_CCLAVE

                                               }
                                           }))
                                       },
                                       error: function (XMLHttpRequest, textStatus, errorThrown) {
                                           //alert(textStatus);
                                       }
                                   });


                             }
                             if ($("#MainContent_ddlorden").val().trim() == "PL") {
                                 $.ajax({
                                     url: "ConsumoCCosto.aspx/GETLINEAS",
                                     data: "{ 'CLAVE': '" + request.term + "' }",
                                     dataType: "json",
                                     type: "POST",
                                     contentType: "application/json; charset=utf-8",
                                     dataFilter: function (data) { return data; },
                                     success: function (data) {
                                         response($.map(data.d, function (item) {
                                             return {
                                                 value: item.LI_CCODLIN + " - " + item.LI_CDESLIN,
                                                 id: item.LI_CCODLIN

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


            $("#MainContent_txtalmacen1").autocomplete(
                       {
                           source: function (request, response) {

                                       $.ajax({
                                       url: "ConsumoCCosto.aspx/GETVARIOS",
                                       data: "{ 'CLAVE': '" + request.term + "' ,  'INDICADOR': '10' }",
                                       dataType: "json",
                                       type: "POST",
                                       contentType: "application/json; charset=utf-8",
                                       dataFilter: function (data) { return data; },
                                       success: function (data) {
                                           response($.map(data.d, function (item) {
                                               return {
                                                   value: item.TG_CCLAVE + " - " + item.TG_CDESCRI,
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
                               $('#MainContent_txtcodini').val(str);


                           }
                       });
            $("#MainContent_txtalmacen2").autocomplete(
           {
               source: function (request, response) {

                   $.ajax({
                       url: "ConsumoCCosto.aspx/GETVARIOS",
                       data: "{ 'CLAVE': '" + request.term + "' ,  'INDICADOR': '10' }",
                       dataType: "json",
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       dataFilter: function (data) { return data; },
                       success: function (data) {
                           response($.map(data.d, function (item) {
                               return {
                                   value: item.TG_CCLAVE + " - " + item.TG_CDESCRI,
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
                   $('#MainContent_txtcodfin').val(str);


               }
           });


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


            function traercentrocosto() {
                var centro = [" "];

                $.ajax({
                    type: "POST",
                    url: "ConsumoCCosto.aspx/getrangoccosto",
                    data: "{ 'cod1': '" + $("#MainContent_txtcodini").val() + "' ,  'cod2': '" + $("#MainContent_txtcodfin").val() + "' }",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        if (data.d.length > 0) {
                            for (var i = 0; i < data.d.length; i++) {
                                centro.push(data.d[i].A1_CALMA);

                            }
                        }
                    },
                    error: function (response) {
                        if (response.length != 0)
                            alert(response);
                    }
                });
                return { centro};
            }

            function traerVarios() {
                var varios = [" "];

                $.ajax({
                    type: "POST",
                    url: "ConsumoCCosto.aspx/getrangovarios",
                    data: "{ 'cod1': '" + $("#MainContent_txtcodini").val() + "' ,  'cod2': '" + $("#MainContent_txtcodfin").val() + "' ,  'c3': '" + $("#MainContent_ddlorden").val() + "' }",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        if (data.d.length > 0) {
                            for (var i = 0; i < data.d.length; i++) {
                                varios.push(data.d[i].A1_CALMA);

                            }
                        }
                    },
                    error: function (response) {
                        if (response.length != 0)
                            alert(response);
                    }
                });
                return { varios};
            }

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

                 if ($('#MainContent_ddlorden').val() == "38") {

                     var anio = $('#MainContent_txtanio').val();
                     var mes = $('#MainContent_ddlmes').val();
                                              
                     window.open("../ALMACEN/REPORTES/consumo/CXCCOSTO.aspx?anio= " + anio + "&mes=" + mes + "&cadena= " + texto().arr + "&movimiento= " + mov + "&centrocosto1=" + ($('#MainContent_txtcodini').val()) + "&centrocosto2=" + ($('#MainContent_txtcodfin').val()) + "&indicador=" + ($('#MainContent_ddlorden').val()) + "&varios1=" + ($('#MainContent_txtcodigo').val()) + "&varios2=" + ($('#MainContent_txtcodigofin').val()), '_blank');
                       }

             });

                         $(".EXCEL").click(function () {
             
              //obtener los items seleccionados de los movimientros
              opciones = document.getElementsByName("opciones");
              var selec = "";
              var entrada = "E";
              var salida = "S";
              var mov = [];
              var nulo = "";
              for (var j = 0; j < opciones.length; j++) {
                  if (opciones[j].checked) {
                      selec = opciones[j].value;
                      break;
                  }
              }
              if ((document.getElementById("<%=rbentrada.ClientID%>").checked == true)) {
                  mov.push(nulo, entrada);
                  var anio = $('#MainContent_txtanio').val();
                  var mes = $('#MainContent_ddlmes').val();
                  window.open("../ALMACEN/REPORTES/consumo/ExcelConsumoEnt.aspx?anio= " + anio + "&mes=" + mes + "&cadena= " + texto().arr + "&movimiento= " + mov + "&centrocosto1=" + ($('#MainContent_txtcodini').val()) + "&centrocosto2=" + ($('#MainContent_txtcodfin').val()) + "&indicador=" + ($('#MainContent_ddlorden').val()) + "&varios1=" + ($('#MainContent_txtcodigo').val()) + "&varios2=" + ($('#MainContent_txtcodigofin').val()), '_blank');

              }
              if ((document.getElementById("<%=rbsalida.ClientID%>").checked == true)) {
                  mov.push(nulo, salida);
                  var anio = $('#MainContent_txtanio').val();
                  var mes = $('#MainContent_ddlmes').val();
                  window.open("../ALMACEN/REPORTES/consumo/ExcelConsumo.aspx?anio= " + anio + "&mes=" + mes + "&cadena= " + texto().arr + "&movimiento= " + mov + "&centrocosto1=" + ($('#MainContent_txtcodini').val()) + "&centrocosto2=" + ($('#MainContent_txtcodfin').val()) + "&indicador=" + ($('#MainContent_ddlorden').val()) + "&varios1=" + ($('#MainContent_txtcodigo').val()) + "&varios2=" + ($('#MainContent_txtcodigofin').val()), '_blank');

              }
              if ((document.getElementById("<%=rbambos.ClientID%>").checked == true)) {
                  mov.push(nulo, entrada, salida);
                  var anio = $('#MainContent_txtanio').val();
                  var mes = $('#MainContent_ddlmes').val();
                  window.open("../ALMACEN/REPORTES/consumo/ExcelConsumoES.aspx?anio= " + anio + "&mes=" + mes + "&cadena= " + texto().arr + "&movimiento= " + mov + "&centrocosto1=" + ($('#MainContent_txtcodini').val()) + "&centrocosto2=" + ($('#MainContent_txtcodfin').val()) + "&indicador=" + ($('#MainContent_ddlorden').val()) + "&varios1=" + ($('#MainContent_txtcodigo').val()) + "&varios2=" + ($('#MainContent_txtcodigofin').val()), '_blank');

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
    <fieldset style="background-color: #99CCFF">
        <legend style="font-weight: bold; background-color: #99CCFF;">
            <asp:Label ID="Label9" runat="server" Text="Centro de Costo" Font-Bold="True" Font-Size="10pt"></asp:Label></legend>

        <table class="auto-style3">
            <tr>
                <td>Centro de Costo Inicial&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td>  <asp:TextBox ID="txtalmacen1" runat="server" Width="333px" ></asp:TextBox>  </td>
                <td>
                    <asp:TextBox ID="txtcodini" runat="server" Width="100" ></asp:TextBox>
                </td>
              
              </tr>
             <tr>
                <td>Centro de Costo Final&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                 <td>  <asp:TextBox ID="txtalmacen2" runat="server" Width="329px" ></asp:TextBox>  </td>
                <td>
                    <asp:TextBox ID="txtcodfin" runat="server" Width="100" ></asp:TextBox>
                </td>
              
              </tr>
                </table>
         </fieldset></legend>

        
              
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
                <td>Al Mes</td> <td class="auto-style2"> <asp:TextBox ID="txtanio" runat="server" Width="166px" Height="17px"></asp:TextBox> <asp:DropDownList ID="ddlmes" runat="server" Height="22px" Width="145px">
                     <asp:ListItem Value="01">01</asp:ListItem>
                     <asp:ListItem Value="02">02</asp:ListItem>
                     <asp:ListItem Value="03">03</asp:ListItem>
                     <asp:ListItem Value="04">04</asp:ListItem>
                     <asp:ListItem Value="05">05</asp:ListItem>
                     <asp:ListItem Value="06">06</asp:ListItem>
                     <asp:ListItem Value="07">07</asp:ListItem>
                     <asp:ListItem Value="08">08</asp:ListItem>
                     <asp:ListItem Value="09">09</asp:ListItem>
                     <asp:ListItem Value="10">10</asp:ListItem>
                     <asp:ListItem Value="11">11</asp:ListItem>
                     <asp:ListItem Value="12">12</asp:ListItem>
                     </asp:DropDownList></td>
            </tr>
            <tr>
                <td>Agrupado Por</td>
                <td>
                    <asp:DropDownList ID="ddlorden" runat="server" Height="28px" Width="481px">
                        <asp:ListItem Value="07">POR CUENTA</asp:ListItem>
                        <asp:ListItem Value="06">POR GRUPO</asp:ListItem>
                        <asp:ListItem Value="38">POR FAMILIA</asp:ListItem>
                        <asp:ListItem Value="39">POR MODELO</asp:ListItem>
                        <asp:ListItem Value="PL">POR LINEA</asp:ListItem>
                        </asp:DropDownList></td>
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
                <td>&nbsp;</td> <td class="auto-style2"> 
                &nbsp;</td>
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
                    &nbsp;&nbsp;</td>
                <td>
                   <input id="Btnexcel" type="button" value="Excel" class="EXCEL" />                    
              </td>
              </tr>

        </table>

         </fieldset>

     <div id="dvdetalle">
  

    </div>

</asp:Content>

