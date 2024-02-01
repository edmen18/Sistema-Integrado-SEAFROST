<%@ Page 
    Title="Logística" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="listadoOC.aspx.cs" Inherits="listadoOC" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link type="text/css" href="../CSS/baseReq.css" rel="stylesheet" />
     <script type="text/javascript">
         $(function () {
             var uus = $("#HeadLoginView_HeadLoginName").html();
             $("#MainContent_hfusuario").val(uus);
             $("#MainContent_TextBox1").datepicker();
             $("#MainContent_TextBox2").datepicker();

         });
         function soloNumeros() {
             $(".numeric").numeric();
         }
         $(function () {
             $(".tb").autocomplete(
                 {
                     source: function (request, response) {
                         $.ajax({
                             url: "listadoOC.aspx/GetProductos",
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

             $(".ver").click(function () {
                 dtr = $(this).closest('tr');
                 myRow = dtr.index() - 1;
                 dtr1 = $(this).closest('td');
                 mycol = dtr1.index();

                 ccosto = $("#MainContent_gvRequerimientos_lblccosto" + "_" + myRow).html();
                 tcurso = $("#MainContent_gvRequerimientos_lbltrabajocurso" + "_" + myRow).html();
                 tcmoneda = $("#MainContent_gvRequerimientos_lblmonedatc" + "_" + myRow).html();
               
                 
                 $('#EstadoPedido').dialog('open');
                 trp = $(this).parent().parent();
                 numero = $("td:eq(0)", trp).html();
                 fecha = $("td:eq(1)", trp).html();
                 usu01 = $("td:eq(1)", trp).val();
                 usu02 = $("td:eq(2)", trp).val();
                 usu03 = $("td:eq(3)", trp).val();
                 estado = $("td:eq(3)", trp).html();
                 solicitante = $("td:eq(8)", trp).html();
                 costo = ccosto;
                 proveedor = $("td:eq(2)", trp).html();
                 uso = $("td:eq(5)", trp).val();
                 prioridad = $("td:eq(6)", trp).val();
                 fecha01 = $("td:eq(7)", trp).val();
                 fecha02 = $("td:eq(8)", trp).val();
                 fecha03 = $("td:eq(5)", trp).html();
                 $("#MainContent_lblnumero").text(numero);
                 $("#MainContent_lblfecha").text(fecha);
                 $("#MainContent_lblsolicitante").text(solicitante);
                 $("#MainContent_lblcosto").text(costo);
                 $("#MainContent_lblproveedor").text(proveedor);
                 $("#MainContent_lbluso").text(uso);
                 $("#MainContent_lblprioridad").text(prioridad);
                 $("#MainContent_lblusu01").text(usu01);
                 $("#MainContent_lblusu02").text(usu02);
                 $("#MainContent_lblusu03").text(usu03);
                 $("#MainContent_lblfecha01").text(fecha01);
                 $("#MainContent_lblfecha02").text(fecha02);
                 $("#MainContent_lblfecha03").text(fecha03);
                 $("#MainContent_txtestado").val(estado);

                 $("#MainContent_lbltrabajocursoDet").text(tcurso);

                 $("#MainContent_lblmonedatc1").text(tcmoneda);

                 
                 filtarcantidademb(numero);
             });

             $('#EstadoPedido').dialog({
                 autoOpen: false,
                 modal: true,
                 resizable: false,
                 width: 900,
                 heigth: 280,
                 title: 'Requerimiento',
                 open: function (event, ui) {

                 },
                 close: function (event, ui) {

                 }

             });
         });

      

         function filtarcantidademb(gidpped) {

             rr = gidpped;

             var REQ = {};
             REQ.RD_CNROREQ = rr;

             $.ajax({

                 type: "POST",
                 url: "listadoOC.aspx/ListarReqDetalle",
                 data: '{REQ: ' + JSON.stringify(REQ) + '}',
                 contentType: "application/json; charset=utf-8",
                 async: false,

                 dataType: "json",
                 success: function (data) {

                     if (data.d.length > 0) {
                         var row = $("[id*=gvdetalle] tr:last-child").clone(true);
                         $("[id*=gvdetalle] tr").not($("[id*=gvdetalle] tr:first-child")).remove();
                         zcant = 0; ztotal = 0;
                         for (var i = 0; i < data.d.length; i++) {

                             $("td", row).eq(0).html(data.d[i].RD_CITEM);
                             $("td", row).eq(1).html(data.d[i].RD_CCODIGO);
                             $("td", row).eq(2).html(data.d[i].RD_CDESCRI);
                             $("td", row).eq(3).html(data.d[i].RD_CUNID);
                             $("td", row).eq(4).html(data.d[i].RD_NQPEDI);
                             $("td", row).eq(5).html(data.d[i].RD_COBS);
                             $("td", row).eq(6).html(parseFloat(data.d[i].PRECIO_MOSTRAR).toFixed(2));
                             $("td", row).eq(7).html(parseFloat(data.d[i].PRECIO_MOSTRAR_TOTAL).toFixed(2));
                             zcant = zcant + data.d[i].RD_NQPEDI;
                             ztotal = ztotal + data.d[i].PRECIO_MOSTRAR_TOTAL;
                             $("[id*=gvdetalle]").append(row);
                             row = $("[id*=gvdetalle] tr:last-child").clone(true);

                         }
                         $("td", row).eq(0).html("");
                         $("td", row).eq(1).html("");
                         $("td", row).eq(2).html("");
                         $("td", row).eq(3).html("TOTAL=");
                         $("td", row).eq(4).html(zcant);
                         $("td", row).eq(5).html("");
                         $("td", row).eq(6).html("");
                         $("td", row).eq(7).html(ztotal);

                         $("[id*=gvdetalle]").append(row);
                       //  row = $("[id*=gvdetalle] tr:last-child").clone(true);

                     } else {
                         var row = $("[id*=gvdetalle] tr:last-child").clone(true);
                         $("[id*=gvdetalle] tr").not($("[id*=gvdetalle] tr:first-child")).remove();

                         $("td", row).eq(0).html("");
                         $("td", row).eq(1).html("");
                         $("td", row).eq(2).html("");
                         $("td", row).eq(3).html("");
                         $("td", row).eq(4).html("");
                         $("td", row).eq(5).html("");
                         $("td", row).eq(6).html("");
                         $("td", row).eq(7).html("");


                         $("[id*=gvdetalle]").append(row);
                         //alert("no se encontro registro");
                     }


                 },
                 error: function (response) {
                     if (response.length != 0)
                         alert(response);
                 }
             });

         }

   


	</script>
    



    <style type="text/css">
        .auto-style1 {
            width: 207px;
        }
    </style>
    



</asp:Content>
   <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
         <asp:ScriptManager ID="scriptManager" runat="server" EnablePageMethods="true" />
       <div id="contenedor" >
    <table width="100%" cellpadding="5" cellspacing="5" border="0">
       
        <tr>
            <td>
                 <fieldset >
   <legend  > <asp:Label ID="Label9" runat="server" Text="MANTENIMIENTO DE REQUERIMIENTO" Font-Bold="True" Font-Size="12pt"></asp:Label></legend>

                <table class="ContainerWrapper" border="0" cellpadding="2" cellspacing="0" style="width:800px">
                    
                    <tr>
                        <td  >

                            <table style="width: 1100px" >
                                <tr>
                                                <td >
                                                    <asp:Label ID="Label5" runat="server" Text="Año:" Font-Bold="True"></asp:Label>
                                 
                                               
                                                    <asp:DropDownList ID="ddlPeriodo" runat="server"></asp:DropDownList>

                                                    <asp:Label ID="Label6" runat="server" Text="Mes:" Font-Bold="True"></asp:Label>
                                 
                                               
                                                    <asp:DropDownList ID="ddlmes" runat="server"></asp:DropDownList>

                                                     <asp:Label ID="Label7" runat="server" Text="Solicitante:" Font-Bold="True"></asp:Label>
                                 
                                               
                                                    <asp:DropDownList ID="ddlUsuario" runat="server"></asp:DropDownList>

                                                    <asp:Label ID="lblestado" runat="server" Text="Estado:" Font-Bold="True"></asp:Label>
                                 
                                               
                                                    <asp:DropDownList ID="ddlestado" runat="server"></asp:DropDownList>
                                                    <br />  <br />
                                                     <asp:Label ID="Label15" runat="server" Text="Producto:" Font-Bold="True"></asp:Label>
                                       
                                                     <asp:TextBox ID="txtproducto" class="tb" runat="server" Width="350px"></asp:TextBox>
                                                     <asp:HiddenField ID="hfproducto" runat="server" />  
                                                    
                                                    <hr />
                                                    
                                                    <asp:Button ID="btnBuscar" class="btn" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="btnNuevo" runat="server" class="btn" Text="Nuevo" OnClick="btnNuevo_Click"  />

                                                     &nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="btnExel" runat="server" Text="Exel" class="btn" OnClick="btnExel_Click"  />
                                                </td>
                                               
                                            </tr>
                               
                              
                               
                            </table>
                            
                           
                           
                            
                           </td>
                    </tr>

                 

                  
                
                
                
                </table>
                     <table >
                         <tr>
                             <td>
                                 <asp:GridView ID="gvRequerimientos" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" DataKeyNames="RC_CUSUCRE,RC_CUSUCRE1">
                                     <Columns>
                                         <asp:BoundField DataField="RC_CNROREQ" HeaderText="REQUISICION" />
                                         <asp:BoundField DataField="RC_DFECREQ" HeaderText="FECHA" />
                                         <asp:BoundField DataField="PROVEEDOR" HeaderText="PROVEEDOR" />
                                         <asp:BoundField DataField="ESTADO" HeaderText="ESTADO" />
                                         <asp:BoundField DataField="APROBAC" HeaderText="APROBAC" />
                                         <asp:BoundField DataField="RC_DFECA03" HeaderText="FECHA.APROB" />
                                          <asp:BoundField DataField="RC_CAGEOT" HeaderText="D.ATENCIÓN" />
                                         <asp:BoundField DataField="RC_CNUMORD" HeaderText="NRO.ORDEN" />
                                         <asp:BoundField DataField="USUARIO" HeaderText="SOLICITANTE" />
                                         <asp:TemplateField HeaderText="EDITAR">
                                             <ItemTemplate>
                                                             <asp:ImageButton ID="ib_editar" runat="server" ImageUrl="~/Images/edit.png" Width="25px" OnClick="ib_editar_Click"  />
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="ELIMINAR">
                                             <ItemTemplate>
                                                 <asp:ImageButton ID="imbeliminar" runat="server" ImageUrl="~/Images/Trash.png" Width="25px" OnClick="ib_eliminar_Click" onclientclick="javascript:return confirm('Esta Seguro?')"/>
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                      
                                          <asp:TemplateField HeaderText="VISUALIZAR">
                                            <ItemTemplate>
                                                <div class="ver">
                                                    <img alt="" src="../Images/Message_Information.png" width="25" style="cursor: pointer" />
                                                    <asp:Label ID="lblccosto" runat="server" Style="display:none" Text='<%# Bind("COSTO") %>'></asp:Label>
                                                    <asp:Label ID="lbltrabajocurso" runat="server" Style="display:none" Text='<%# Bind("RC_CNUMOT") %>'></asp:Label>
                                                  <asp:Label ID="lblmonedatc" runat="server" Style="display:none" Text='<%# Bind("monedatc") %>'></asp:Label>
                                                      </div>

                                            </ItemTemplate>
                                        </asp:TemplateField>


                                         <asp:TemplateField HeaderText="IMPRIMIR">
                                             <ItemTemplate>
                                                 <asp:ImageButton ID="ibimprimir" Height="25" runat="server" ImageUrl="~/Images/Printer.png" OnClick="ibimprimir_Click" />
                                             </ItemTemplate>
                                         </asp:TemplateField>


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

                                 <div Style="display:none">
                                     <asp:GridView ID="gvreporte" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" DataKeyNames="RC_CUSUCRE">
                                     <Columns>
                                         <asp:BoundField DataField="RC_CNROREQ" HeaderText="REQUISICION" />
                                         <asp:BoundField DataField="RC_DFECREQ" HeaderText="FECHA" />
                                         <asp:BoundField DataField="PROVEEDOR" HeaderText="PROVEEDOR" />
                                         <asp:BoundField DataField="ESTADO" HeaderText="ESTADO" />
                                         <asp:BoundField DataField="APROBAC" HeaderText="APROBAC" />
                                         <asp:BoundField DataField="RC_DFECA03" HeaderText="FECHA.APROB" />
                                         <asp:BoundField DataField="RC_CNUMORD" HeaderText="NRO.ORDEN" />
                                         <asp:BoundField DataField="USUARIO" HeaderText="USUARIO" />
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
                                 </div>
                             </td>
                         </tr>
                     </table>
                      
                     
                     
                      </fieldset>
            </td>
        </tr>
    </table>
           <div id="EstadoPedido" style="display:none " >
        <table>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="lblcabnumero" runat="server" Text="Nro Requerimiento:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblnumero" runat="server"></asp:Label>
                    <br />

                    <asp:Label ID="lblcabfecha" runat="server" Text="Fecha:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblfecha" runat="server"></asp:Label>
                    <br />

                    <asp:Label ID="lblcabsolicitante" runat="server" Text="Solicitante:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblsolicitante" runat="server"></asp:Label>

                    <br />

                    <asp:Label ID="lblcabcosto" runat="server" Text="Centro de Costo:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblcosto" runat="server"></asp:Label>

                    <br />

                    <asp:Label ID="lblcabprovvedor" runat="server" Text="Proveedor:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblproveedor" runat="server"></asp:Label>
                     <br />

                    <asp:Label ID="lbltrabajocursoCab" runat="server" Text="Trabajo en curso:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="lbltrabajocursoDet" runat="server"></asp:Label>
                     <asp:Label ID="lblmonedatc" runat="server" Text="Moneda:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblmonedatc1" runat="server"></asp:Label>

                   




                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                     <div style="overflow: auto; width: 880px; height: 120px">
                    <asp:GridView ID="gvdetalle" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" Width="859px" Font-Size="8" >
                        <Columns>
                            <asp:BoundField DataField="RD_CITEM" HeaderText="ITEM" HeaderStyle-HorizontalAlign="Left" />
                            <asp:BoundField DataField="RD_CCODIGO" HeaderText="CODIGO" HeaderStyle-HorizontalAlign="Left" />
                            <asp:BoundField DataField="RD_CDESCRI" HeaderText="DESCRI" HeaderStyle-HorizontalAlign="Left" />
                            <asp:BoundField DataField="RD_CUNID" HeaderText="UNID" HeaderStyle-HorizontalAlign="Left" />
                            <asp:BoundField DataField="RD_NQPEDI" HeaderText="CANT" HeaderStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                           
                            <asp:BoundField DataField="RD_COBS" HeaderText="OBS" HeaderStyle-HorizontalAlign="Left" />
                            <asp:BoundField DataField="PRECIO_MOSTRAR" HeaderText="PRECIO" HeaderStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"  DataFormatString="{0:F2}" />
                             <asp:BoundField DataField="PRECIO_MOSTRAR_TOTAL" HeaderText="TOTAL" HeaderStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"  DataFormatString="{0:F2}"/>
                        
                            
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
                         </div>

                </td>
            </tr>
           
           
        </table>
    </div>
      </div>

       <asp:Panel ID="Panel1" runat="server" BackColor="White" style="display: "  >
           <table>
               <tr>
                   <td class="auto-style1">
                        <div style="color: #FF0000">
                       LOS REQUERIMIENTOS PENDIENTES <br />
                       DE APROBACIÓN SE ANULARÁN <br />
                       DESPUÉS DE 15 DÍAS
                       </div>
       
       
                   </td>
                        
                 
               </tr>

           </table>
          </asp:Panel>

        <ajaxToolkit:AlwaysVisibleControlExtender ID="ace" runat="server"
    TargetControlID="Panel1"         
    VerticalSide="Top"
    VerticalOffset="140"
    HorizontalSide="center"
    HorizontalOffset="30"
    ScrollEffectDuration=".1"/>
           
      

       </asp:Content>


 












  

