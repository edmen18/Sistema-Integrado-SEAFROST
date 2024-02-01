<%@ Page Title="Logística" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="RepLiquidacionCompras.aspx.cs" Inherits="FINANZAS_Reportes_RepLiquidacionCompras" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<script type="text/javascript">
    $(function () {
        $("#MainContent_txtfinicial").datepicker();
        $("#MainContent_txtffinal").datepicker();
    $("#MainContent_txtdato").autocomplete(
                 {
               source: function (request, response) {

                   if (document.getElementById("<%=rbproveedor.ClientID%>").checked == true) {
                       $.ajax({
                           url: "RepLiquidacionCompras.aspx/GetProveedores",
                           data: "{ 'productos': '" + request.term + "' }",
                           dataType: "json",
                           type: "POST",
                           contentType: "application/json; charset=utf-8",
                           dataFilter: function (data) { return data; },
                           success: function (data) {
                               response($.map(data.d, function (item) {
                                   return {
                                       value: item.ACODANE+"-"+ item.ADESANE,
                                       id: item.ACODANE

                                   }
                               }))
                           },
                           error: function (XMLHttpRequest, textStatus, errorThrown) {
                              }
                       });
                   }


                   if (document.getElementById("<%=rbarticulo.ClientID%>").checked == true) {
                       $.ajax({
                           url: "RepLiquidacionCompras.aspx/GetArticulos",
                           data: "{ 'productos': '" + request.term + "' }",
                           dataType: "json",
                           type: "POST",
                           contentType: "application/json; charset=utf-8",
                           dataFilter: function (data) { return data; },
                           success: function (data) {
                               response($.map(data.d, function (item) {
                                   return {
                                       value: item.AR_CCODIGO +"-"+ item.AR_CDESCRI,
                                       id: item.AR_CCODIGO

                                   }
                               }))
                           },
                           error: function (XMLHttpRequest, textStatus, errorThrown) {
                               //alert(textStatus);
                           }
                       });
                   }
                    if (document.getElementById("<%=rbliquidacion.ClientID%>").checked == true) {
                       $.ajax({
                           url: "RepLiquidacionCompras.aspx/GetLiquidaciones",
                           data: "{ 'productos': '" + request.term + "' }",
                           dataType: "json",
                           type: "POST",
                           contentType: "application/json; charset=utf-8",
                           dataFilter: function (data) { return data; },
                           success: function (data) {
                               response($.map(data.d, function (item) {
                                   return {
                                       value: item.LC_CNUMDOC + "-" + item.LC_CNOMBRE,
                                       id: item.LC_CNUMDOC

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

                   if (document.getElementById("<%=rbproveedor.ClientID%>").checked == true) {
                       $.ajax({
                           url: "RepLiquidacionCompras.aspx/GetProveedores",
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
                   }


                   if (document.getElementById("<%=rbarticulo.ClientID%>").checked == true) {
                       $.ajax({
                           url: "RepLiquidacionCompras.aspx/GetArticulos",
                           data: "{ 'productos': '" + request.term + "' }",
                           dataType: "json",
                           type: "POST",
                           contentType: "application/json; charset=utf-8",
                           dataFilter: function (data) { return data; },
                           success: function (data) {
                               response($.map(data.d, function (item) {
                                   return {
                                       value: item.AR_CCODIGO + "-" + item.AR_CDESCRI,
                                       id: item.AR_CCODIGO

                                   }
                               }))
                           },
                           error: function (XMLHttpRequest, textStatus, errorThrown) {
                               //alert(textStatus);
                           }
                       });
                   }
                    if (document.getElementById("<%=rbliquidacion.ClientID%>").checked == true) {
                       $.ajax({
                           url: "RepLiquidacionCompras.aspx/GetLiquidaciones",
                           data: "{ 'productos': '" + request.term + "' }",
                           dataType: "json",
                           type: "POST",
                           contentType: "application/json; charset=utf-8",
                           dataFilter: function (data) { return data; },
                           success: function (data) {
                               response($.map(data.d, function (item) {
                                   return {
                                       value: item.LC_CNUMDOC +"-"+ item.LC_CNOMBRE,
                                       id: item.LC_CNUMDOC

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
        });

</script>


</asp:Content>
   <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
         <asp:ScriptManager ID="scriptManager" runat="server" EnablePageMethods="true" />
       <div id="contenedor" style="width:990px">
           <table width="100%" cellpadding="5" cellspacing="5" border="0">
               <tr>
                   <td> 
                        <fieldset > 
                             <legend  > <asp:Label ID="Label9" runat="server" Text="Reporte Liquidación de Compras" Font-Bold="True" Font-Size="12pt"></asp:Label></legend>
                            <table class="ContainerWrapper" border="0" cellpadding="2" cellspacing="0" style="width:800px"> 
                                <tr>
                   <td class="auto-style1">
                  <input id="rbarticulo" name="opciones" type="radio" value="1" runat="server"/> Artículo<br />                                
              </td>
                 <td>
                  <input id="rbproveedor" name="opciones" type="radio" value="2" runat="server"/> Proveedor <br />
                   </td>
                   <td>
                        <input id="rbliquidacion" name="opciones" type="radio" value="3" runat="server"/> Liquidacion <br />
                   </td>
                              </tr>

                            </table>
                            </fieldset>
                   </td>
               </tr>

           <%--</table>
    <table width="100%" cellpadding="5" cellspacing="5" border="0">--%>
       
        <tr>
            <td>
                 <fieldset >
                  <table class="ContainerWrapper" border="0" cellpadding="2" cellspacing="0" style="width:800px">
                    
                    <tr>
                        <td  >

                            <table style="width: 900px" >
                                <tr>
                                    <td>
                                        <asp:Label ID="lblAlmacen" runat="server" Text="Agencia:" Font-Bold="True"></asp:Label> </td>
                                     <td><asp:DropDownList ID="ddlagencia" runat="server" Height="29px" Width="645px"></asp:DropDownList><td>

                                 </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="Moneda:" Font-Bold="True"></asp:Label>
                                       
                                    </td>
                                    <td> <asp:DropDownList ID="ddlmoneda" runat="server" Height="29px" Width="644px"></asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td>
                                         <asp:Label ID="FechaInicial" runat="server" Text="Fecha Inicial:" Font-Bold="True"></asp:Label>
                                         </td>
                                    <td> <asp:TextBox ID="txtfinicial" runat="server" Width="136px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>
                                                    <asp:Label ID="FechaFinal" runat="server" Text="Fecha Final:" Font-Bold="True"></asp:Label>
                                                                     
                                    </td>
                                    <td><asp:TextBox ID="txtffinal" runat="server" Width="136px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>
                                          <asp:Label ID="Label15" runat="server" Text="Producto Inicial:" Font-Bold="True"></asp:Label>
                                         <asp:HiddenField ID="hfproducto" runat="server" /> 
                                    </td>
                                    <td><asp:TextBox ID="txtcodigo"  runat="server" Width="170" AutoPostBack="True"></asp:TextBox>
                                                     <asp:TextBox ID="txtdato" class="tb" runat="server" Width="471px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>
                                          <asp:Label ID="Label1" runat="server" Text="Producto Final:" Font-Bold="True"></asp:Label>
                                        <asp:HiddenField ID="hfproducto1" runat="server" />  
                                    </td>
                                    <td> <asp:TextBox ID="txtcodigofin" runat="server" Width="170" AutoPostBack="True"></asp:TextBox>
                                                  <asp:TextBox ID="txtdato1" class="tb2" runat="server" Width="469px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                                <td>
                                                    <hr />
                                                    
                                                    <asp:Button ID="btnBuscar" class="btn" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                                                  </td>                                               
                                            </tr>

                            </table>
                           </td></tr>
</table>
                   
                     
                      </fieldset>
            </td>
        </tr>
    </table>
           
      </div>
       </asp:Content>