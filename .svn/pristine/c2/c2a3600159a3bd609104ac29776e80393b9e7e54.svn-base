<%@ Page Title="Logística" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ConsultaArticuloProveedor.aspx.cs" Inherits="ConsultaArticuloProveedor" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link type="text/css" href="../CSS/base.css" rel="stylesheet" />
     <script type="text/javascript">

         $(function () {

             $('.EstadoPedido').dialog({
                 autoOpen: false,
                 modal: true,
                 resizable: false,
                 width: 600,
                 heigth: 250,
                 title: 'SERIES',
                 open: function (event, ui) {

                 },
                 close: function (event, ui) {

                 }

             });

                 $(".ver").click(function () {

                 //dtr = $(this).closest('tr');
                 //myRow = dtr.index() - 1;
                 //dtr1 = $(this).closest('td');
                 //mycol = dtr1.index();

                 //numero = $("#MainContent_gvDetalle_lblcodigo" + "_" + myRow).html();

                 trp = $(this).parent().parent();
                 articulo = $("td:eq(0)", trp).html();
                 articulo1 = $("td:eq(1)", trp).html();

            alma=     $("#MainContent_ddlalmacen").val();

         

            $("#MainContent_lblnumero").text(articulo1);
            filtarcantidademb(articulo, alma);
                 $('.EstadoPedido').dialog('open');
             });

         });

         function filtarcantidademb(articulo, alma) {
            
             var REQ = {};
             REQ.SR_CALMA = alma.trim();  
             REQ.SR_CCODIGO = articulo.trim();

             $.ajax({

                 type: "POST",
                 url: "consultastockarticulo.aspx/consultaStockSerie",
                 data: '{REQ: ' + JSON.stringify(REQ) + '}',
                 contentType: "application/json; charset=utf-8",
                 async: false,

                 dataType: "json",
                 success: function (data) {

                     if (data.d.length > 0) {
                         var row = $("[id*=gvdetallereq] tr:last-child").clone(true);
                         $("[id*=gvdetallereq] tr").not($("[id*=gvdetallereq] tr:first-child")).remove();

                         for (var i = 0; i < data.d.length; i++) {

                             var dat = data.d[i].SR_DFECVEN;
                             console.log(dat);
                             var fech = ( dat == null ? "" : moment(dat).format('DD/MM/YYYY'))

                             $("td", row).eq(0).html(data.d[i].SR_CCODIGO);
                             $("td", row).eq(1).html(data.d[i].SR_CSERIE);
                             $("td", row).eq(2).html(parseFloat(data.d[i].SR_NSKDIS).toFixed(2));
                             $("td", row).eq(3).html(fech);

                             
                             $("[id*=gvdetallereq]").append(row);
                             row = $("[id*=gvdetallereq] tr:last-child").clone(true);

                         }
                     } else {
                         var row = $("[id*=gvdetallereq] tr:last-child").clone(true);
                         $("[id*=gvdetallereq] tr").not($("[id*=gvdetallereq] tr:first-child")).remove();

                         $("td", row).eq(0).html("");
                         $("td", row).eq(1).html("");
                         $("td", row).eq(2).html("");
                         $("td", row).eq(3).html("");
                       


                         $("[id*=gvdetallereq]").append(row);
                         //alert("no se encontro registro");
                     }


                 },
                 error: function (response) {
                     if (response.length != 0)
                         alert(response);
                 }
             });

         }

         $(function () {
             var uus = $("#HeadLoginView_HeadLoginName").html();
             $("#MainContent_hfusuario").val(uus);
             $("#MainContent_txtfechini").datepicker();
             $("#MainContent_txtfechfin").datepicker();

         });
         function soloNumeros() {
             $(".numeric").numeric();
         }
         $(function () {
             $(".tb").autocomplete(
                 {
                     source: function (request, response) {
                         $.ajax({
                             url: "../REQUERIMIENTOS/listadoOC.aspx/GetProductos",
                             data: "{ 'productos': '" + "%" + request.term + "%" + "' }",
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
                     },
                     minLength: 1,
                     select: function (event, ui) {
                         var str = ui.item.id;
                        
                         $('#MainContent_hfproducto').val(str);

                         $('#MainContent_txtcodprod1').val(str);

                        
                     }
                 });




         });

         $(function () {
             $(".tb2").autocomplete(
                 {
                     source: function (request, response) {
                         $.ajax({
                             url: "../REQUERIMIENTOS/listadoOC.aspx/GetProductos",
                             data: "{ 'productos': '" + "%" + request.term + "%" + "' }",
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
                     },
                     minLength: 1,
                     select: function (event, ui) {
                         var str = ui.item.id;

                         $('#MainContent_hfproducto').val(str);

                         $('#MainContent_txtcodprod2').val(str);


                     }
                 });




         });

         $(function () {
             $(".tb1").autocomplete(
                 {
                     source: function (request, response) {
                         $.ajax({
                             url: "listadoOC.aspx/GetProveedores",
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
                         $('#MainContent_HiddenField1').val(primerApellido);


                     }
                 });




         });
	</script>
    
</asp:Content>
   <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
         <asp:ScriptManager ID="scriptManager" runat="server" EnablePageMethods="true" />
       <div id="contenedor" style="width:1000"  >
    <table  cellpadding="5" cellspacing="5" border="0">
       
        <tr>
            <td>
                 <fieldset >
   <legend  > <asp:Label ID="Label9" runat="server" Text="CONSULTA ARTICULO PROVEEDOR" Font-Bold="True" Font-Size="12pt"></asp:Label></legend>

                <table  >
                    
                    <tr>
                        <td  >
                            <table >
                     
                                <tr>
                                    <td>
                                          <asp:Label ID="Label15" runat="server" Text="Producto Inicial:" Font-Bold="True"></asp:Label>
                                       
                                                      <asp:TextBox ID="txtcodprod1"  OnTextChanged="txtcodprod1_TextChanged" runat="server"  AutoPostBack="True"></asp:TextBox>
                                                     <asp:TextBox ID="txtproducto" class="tb" runat="server" Width="500px" ></asp:TextBox>
                                                                                           
                                                   
                                                      
                                                    <asp:HiddenField ID="hfproducto" runat="server" /> 
                                    </td>
                                </tr>
                           
                                <tr>
                                                <td >
                                                    

                                                

                                                    

                                           
                                                   
                                                   
                                            
                                                   
                                                   
                                                    
                                                    <hr />
                                                    
                                                    <asp:Button ID="btnBuscar" class="btn" runat="server" Text="Buscar" OnClick="btnBuscar_Click"  />
                                                  
                                                    </td>
                                               
                                            </tr>
                               
                              
                               
                            </table>
                            
                           
                           
                            
                           </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvarticulos" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField DataField="OC_CCODPRO" HeaderText="RUC" />
                                    <asp:BoundField DataField="OC_CRAZSOC" HeaderText="RAZON SOCIAL" />
                                    <asp:BoundField DataField="OC_DFECDOC" HeaderText="FECHA" />
                                    <asp:BoundField DataField="OC_CCODMON" HeaderText="MONEDA" />
                                    <asp:BoundField DataField="OC_NPREUN2" HeaderText="PRECIO"  DataFormatString="{0:F4}"/>
                                    <asp:BoundField DataField="OC_CNUMORD" HeaderText="ORDEN DE COMPRA" />
                                    <asp:BoundField DataField="OC_CFORPA1" HeaderText="FORMA DE PAGO" />
                                   
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
                        </td>
                    </tr>
                </table>
                   
                      
                     <div class="EstadoPedido" Style="display:none">
           <table >
               
               <tr>
                   <td>
                       <asp:Label ID="lblcabnumero" runat="server" Text="Artículo:" Font-Bold="True" ></asp:Label>
                        <asp:Label ID="lblnumero" runat="server"  ></asp:Label>
                       <br />
                       <asp:GridView ID="gvdetallereq" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False">
                           <Columns>
                               <asp:BoundField DataField="SR_CCODIGO" HeaderText="CCODIGO" HeaderStyle-HorizontalAlign="Left" >
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                               </asp:BoundField>
                                 <asp:BoundField DataField="SR_CSERIE" HeaderText="CSERIE" HeaderStyle-HorizontalAlign="Left" >
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                               </asp:BoundField>

  <asp:BoundField DataField="SR_NSKDIS" HeaderText="CANTIDAD" HeaderStyle-HorizontalAlign="Left" >
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                               </asp:BoundField>

                                 <asp:BoundField DataField="SR_DFECVEN" HeaderText="FECHA VENC." HeaderStyle-HorizontalAlign="Left" >
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                               </asp:BoundField>
                                
                             

                               
                               
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
                   </td>
               </tr>
           </table>
       </div>
                     
                      </fieldset>
            </td>
        </tr>
    </table>
           
      </div>
       </asp:Content>


 












  

