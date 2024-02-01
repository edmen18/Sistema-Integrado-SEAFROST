<%@ Page Title="Logística" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="listadoOC.aspx.cs" Inherits="listadoOC" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link type="text/css" href="../CSS/base.css" rel="stylesheet" />
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




         });
	</script>
     <style type="text/css">
         #txtproducto0 {
             width: 337px;
         }
         .auto-style1 {
             height: 19px;
         }
         </style>
</asp:Content>
   <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
         <asp:ScriptManager ID="scriptManager" runat="server" EnablePageMethods="true" />
       <div id="contenedor" style="width:990px">
    <table width="100%" cellpadding="5" cellspacing="5" border="0">
       
        <tr>
            <td>
                 <fieldset >
   <legend  > <asp:Label ID="Label9" runat="server" Text="MANTENIMIENTO DE REQUERIMIENTO" Font-Bold="True" Font-Size="12pt"></asp:Label></legend>

                <table class="ContainerWrapper" border="0" cellpadding="2" cellspacing="0" style="width:800px">
                    
                    <tr>
                        <td  >

                            <table style="width: 900px" >
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
                                 <asp:GridView ID="gvRequerimientos" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" DataKeyNames="RC_CUSUCRE">
                                     <Columns>
                                         <asp:BoundField DataField="RC_CNROREQ" HeaderText="REQUISICION" />
                                         <asp:BoundField DataField="RC_DFECREQ" HeaderText="FECHA" />
                                         <asp:BoundField DataField="PROVEEDOR" HeaderText="PROVEEDOR" />
                                         <asp:BoundField DataField="ESTADO" HeaderText="ESTADO" />
                                         <asp:BoundField DataField="APROBAC" HeaderText="APROBAC" />
                                         <asp:BoundField DataField="RC_DFECA03" HeaderText="FECHA.APROB" />
                                          <asp:BoundField DataField="RC_CAGEOT" HeaderText="D.ATENCIÓN" />
                                         <asp:BoundField DataField="RC_CNUMORD" HeaderText="NRO.ORDEN" />
                                         <asp:BoundField DataField="USUARIO" HeaderText="USUARIO" />
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
                                                 <asp:ImageButton ID="ibVisualizar" runat="server" ImageUrl="~/Images/Message_Information.png" Width="25px" OnClick="ibVisualizar_Click"/>
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
           
      </div>
       </asp:Content>


 












  

