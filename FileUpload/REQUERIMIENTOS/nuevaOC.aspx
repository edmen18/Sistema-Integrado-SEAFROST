<%@ Page Title="Logística" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="nuevaOC.aspx.cs" Inherits="nuevaOC" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
     <script type="text/javascript">
         $(function () {
             var uus = $("#HeadLoginView_HeadLoginName").html();
             $("#MainContent_hfusuario").val(uus);
             $("#MainContent_txtFecha").datepicker();
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
                                // alert(textStatus);
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
                             data: "{ 'productos': '" + "%" + request.term + "%"+"' }",
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
                               //  alert(textStatus);
                             }
                         });
                     },
                     minLength: 1,
                     select: function (event, ui) {
                         var str = ui.item.id;
                         $('#MainContent_hfproveedor').val(str);


                     }
                 });




         });
	</script>
     <style type="text/css">
         #txtproducto0 {
             width: 337px;
         }
         .auto-style1 {
             width: 200px;
         }
         </style>
</asp:Content>
   <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
         <asp:ScriptManager ID="scriptManager" runat="server" EnablePageMethods="true" />
    <table width="100%" cellpadding="5" cellspacing="5" border="0">
       
        <tr>
            <td>
                 <fieldset style="background-color: #99CCFF">
   <legend style="font-weight: bold; background-color: #99CCFF;" > <asp:Label ID="Label9" runat="server" Text="CREACIÓN" Font-Bold="True" Font-Size="12pt"></asp:Label></legend>

                <table class="ContainerWrapper" border="0" cellpadding="2" cellspacing="0" width="100%">
                    
                    <tr>
                        <td  >

                            <table >
                                <tr>
                                    <td>
                                        <asp:Panel ID="pnCabecera" runat="server">
                                              <table >
                                            <tr>
                                                <td>
                                                     <asp:Label ID="Label2" runat="server" Text="Nro Reque:" Font-Bold="True"></asp:Label>
                                        <asp:TextBox ID="txtnroreq" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td>
                                                   <asp:Label ID="Label1" runat="server" Text="Fecha:" Font-Bold="True"></asp:Label>
                                        <asp:TextBox ID="txtFecha" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label5" runat="server" Text="Area:" Font-Bold="True"></asp:Label>
                                        <asp:DropDownList ID="ddlArea" runat="server"></asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label6" runat="server" Text="Solicitante:" Font-Bold="True"></asp:Label>
                                        <asp:DropDownList ID="ddlsolicitante" runat="server"></asp:DropDownList>
                                                </td>
                                            </tr>

                                             <tr>
                                                <td>
                                                    <asp:Label ID="Label4" runat="server" Text="Tipo:" Font-Bold="True"></asp:Label>
                                        <asp:DropDownList ID="ddltipo" runat="server"></asp:DropDownList>
                                                </td>
                                                <td>
                                                    
                                                    <asp:Label ID="Label13" runat="server" Text="CCosto:" Font-Bold="True"></asp:Label>
                                        <asp:TextBox ID="txtccosto" runat="server" Width="50px" AutoPostBack="True" OnTextChanged="txtccosto_TextChanged"></asp:TextBox>
                                                    <asp:DropDownList ID="ddlccosto" runat="server"></asp:DropDownList>
                                                    
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2"> 
                                                    <asp:Label ID="Label3" runat="server" Text="Proveedor:" Font-Bold="True"></asp:Label>
                                        <asp:TextBox ID="txtProveedor" class="tb1" runat="server" Width="350px"></asp:TextBox>
                                                     <asp:HiddenField ID="hfproveedor" runat="server" />   
                                                </td>
                                            </tr>


                                            <tr>
                                                <td>
                                                     <asp:Label ID="Label7" runat="server" Text="Uso:" Font-Bold="True"></asp:Label>
                                        <asp:DropDownList ID="ddluso" runat="server"></asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label14" runat="server" Text="Prioridad:" Font-Bold="True"></asp:Label>
                                        <asp:DropDownList ID="ddlPrioridad" runat="server"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                     <asp:Label ID="Label10" runat="server" Text="Observ1:" Font-Bold="True"></asp:Label>
                                        <asp:TextBox ID="txtObserv1" runat="server" Width="350px" TextMode="MultiLine"></asp:TextBox>
                                                </td>
                                            </tr>
                                               <tr>
                                                <td colspan="2">
                                                     <asp:Label ID="Label8" runat="server" Text="Observ2:" Font-Bold="True"></asp:Label>
                                         <asp:TextBox ID="txtObserv2" runat="server" Width="350px" TextMode="MultiLine"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                
                                                 <td>
                                                    <asp:Label ID="Label12" runat="server" Text="Nro Cotiz:" Font-Bold="True"></asp:Label>
                                        <asp:TextBox ID="txtcotiz" runat="server"></asp:TextBox>
                                                </td>
                                                 <td>
                                                    <asp:Label ID="Label11" runat="server" Text="Días de atención:" Font-Bold="True"></asp:Label>
                                        <asp:TextBox ID="txtdias" runat="server" class="numeric" Height="17px" Width="50px" ></asp:TextBox>
                                                </td>
                                            </tr>

                                        </table>
                                        <table >
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnGrabar" runat="server" Text="Grabar Cabecera" OnClick="btnGrabar_Click" Width="115px" />
                                                <br />
                                                    <asp:Button ID="btnModificarcab" runat="server" Text="Modificar Cabecera"  Width="115px" Visible="False" OnClick="btnModificarcab_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                        </asp:Panel>
                                        <asp:Panel ID="pnDetalle" runat="server" Enabled="False">

                                             <table >
                                            <tr>
                                                 <td colspan="2"> 
                                                    <asp:Label ID="Label15" runat="server" Text="Producto:" Font-Bold="True"></asp:Label>
                                        <asp:TextBox ID="txtproducto" class="tb" runat="server" Width="350px"></asp:TextBox>
                                                     <asp:HiddenField ID="hfproducto" runat="server" />   
                                                     <asp:HiddenField ID="hfitem" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1">
                                                      <asp:Label ID="Label16" runat="server" Text="Cantidad:" Font-Bold="True"></asp:Label>
                                        <asp:TextBox ID="txtCantidaad" class="numeric" runat="server" Width="50px" ></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label18" runat="server" Text="CCosto:" Font-Bold="True"></asp:Label>
                                        <asp:TextBox ID="txtcostodet" runat="server" Width="50px" AutoPostBack="True" OnTextChanged="txtcostodet_TextChanged"></asp:TextBox>
                                                    <asp:DropDownList ID="ddlcostodet" runat="server"></asp:DropDownList>
                                                </td>
                                              
                                            </tr>
                                                 <tr>
                                                     <td colspan="2" >
                                                         <asp:Label ID="Label19" runat="server" Text="Solicitante:" Font-Bold="True"></asp:Label>
                                        <asp:DropDownList ID="ddlsolicitantedet" runat="server"></asp:DropDownList>
                                                     </td>
                                                 </tr>
                                            <tr>
                                                <td colspan="2">
                                                     <asp:Label ID="Label17" runat="server" Text="Observación:" Font-Bold="True"></asp:Label>
                                        <asp:TextBox ID="txtObserva" runat="server" Width="350px" TextMode="MultiLine"></asp:TextBox>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td colspan="2">
                                                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
                                                    
                                       <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click"  />
                                       
                                                </td>
                                            </tr>
                                        </table>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="gvDetalle" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" OnRowDataBound="gvDetalle_RowDataBound" ShowFooter="True" DataKeyNames="RD_CUSRCOM,RD_CCENCOS">
                                                        <Columns>
                                                            <asp:BoundField DataField="RD_CITEM" HeaderText="ITEM " />
                                                            <asp:BoundField DataField="RD_CCODIGO" HeaderText="CODIGO" />
                                                            <asp:BoundField DataField="RD_CDESCRI" HeaderText="DESCRIPCION" />
                                                            <asp:BoundField DataField="RD_CUNID" HeaderText="UNIDAD" />
                                                            <asp:BoundField DataField="RD_NQPEDI" HeaderText="CANTIDAD" DataFormatString="{0:F0}" />
                                                            <asp:BoundField DataField="RD_COBS" HeaderText="OBSERVACION" />
                                                            <asp:BoundField DataField="CCENCOSDESCRIP" HeaderText="DESCRIPCOSTO" />
                                                            
                                                            <asp:BoundField DataField="SOLICITANTE" HeaderText="SOLICITANTE" />
                                                            
                                                            <asp:TemplateField HeaderText="EDITAR">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="btnEditar" runat="server" ImageUrl="~/Images/edit.png" Width="25px" OnClick="btnEditar_Click"  />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="ELIMINAR">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ibEliminar" runat="server" ImageUrl="~/Images/Trash.png" Width="25px" OnClick="ibEliminar_Click" onclientclick="javascript:return confirm('Esta Seguro?')" />
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
                                                </td>
                                            </tr>
                                        </table>
                                        </asp:Panel>

                                       
                                         
                           
                                    </td>
                                </tr>
                             
                               
                              
                               
                            </table>
                            
                           
                           
                            
                           </td>
                    </tr>

                 

                  
                
                
                
                </table>
                     
                    
                      
                     
                     
                      </fieldset>
            </td>
        </tr>
    </table>
      
       </asp:Content>


 












  

