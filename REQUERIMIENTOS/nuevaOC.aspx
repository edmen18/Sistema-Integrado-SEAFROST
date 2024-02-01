<%@ Page Title="Logística" Language="C#" MasterPageFile="~/Site.master" EnableEventValidation="false" AutoEventWireup="true"
    CodeFile="nuevaOC.aspx.cs" Inherits="nuevaOC" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
       <link type="text/css" href="../CSS/base.css" rel="stylesheet" />
  
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
                             url: "nuevaOC.aspx/GetProductos",
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
                                         //AR_CTIPDES: item.AR_CTIPDES,
                                         //AR_NPRECI2:item.AR_NPRECI2,
                                         //AR_NPRECI3: item.AR_NPRECI3

                                     }
                                 }))
                             },
                             error: function (XMLHttpRequest, textStatus, errorThrown) {
                                // alert(textStatus);
                             }
                         });
                     },
                     minLength: 3,
                     select: function (event, ui) {
                         var str = ui.item.id;
                         $('#MainContent_hfproducto').val(str);
                         $('#MainContent_txtcodprod').val(str);

                         filtarcantidademb(str);

                         //alert(ui.item.AR_CTIPDES);
                         //alert(ui.item.AR_NPRECI2);
                         //alert(ui.item.AR_NPRECI3);
                         //$('#MainContent_txtprecio').val(ui.item.AR_NPRECI3);

                    

                         
                     }
                 });

             function filtarcantidademb(gidpped) {
                 rr = gidpped;
                 var REQ = {};
                 REQ.RD_CCODIGO = rr;
                 $.ajax({
                    async:false,
                     type: "POST",
                     url: "nuevaOC.aspx/UltimolPrecioPorProducto",
                     data: '{REQ: ' + JSON.stringify(REQ) + '}',
                     contentType: "application/json; charset=utf-8",


                     dataType: "json",
                     success: function (response) {

                       $('#MainContent_txtprecio').val( response.d.AR_NPRECI3);
                    //    $('#MainContent_txtprecio').value =response.d.AR_NPRECI3;
                         $('#MainContent_hfmoneda').val(response.d.AR_CTIPDES);
                         $('#MainContent_hftcambio').val(response.d.AR_NPRECI2);
                         $('#MainContent_txtmonedatc0').val(response.d.AR_CTIPDES);

                         $('#MainContent_hfpreciomn').val((response.d.AR_CTIPDES == "MN" ? response.d.AR_NPRECI3 : (response.d.AR_NPRECI3 * response.d.AR_NPRECI2)));
                         $('#MainContent_hfprecious').val((response.d.AR_CTIPDES == "US" ? response.d.AR_NPRECI3 : (response.d.AR_NPRECI2==0 ? 0: (response.d.AR_NPRECI3 / response.d.AR_NPRECI2))));


                         $('#MainContent_hfprecio').val(response.d.AR_NPRECI3);
                         
                         if (response.d.AR_NPRECI3 > 0) {
                             $('#MainContent_txtprecio').attr('disabled', '-1');
                             $('#MainContent_ddlmoneda').attr('disabled', '-1');
                         }
                         else {
                             $('#MainContent_txtprecio').removeAttr('disabled');
                             $('#MainContent_ddlmoneda').removeAttr('disabled');
                         }
                      

                         $("#MainContent_ddlmoneda").html("");

                       

                         if (response.d.AR_CTIPDES == "MN") {
                             var option = $(document.createElement('option'));
                             option.text("MN");
                             option.val("MN");
                             $("#MainContent_ddlmoneda").append(option);

                             var option2 = $(document.createElement('option'));
                             option2.text("US");
                             option2.val("US");
                             $("#MainContent_ddlmoneda").append(option2);
                         }else
                         {
                             var option = $(document.createElement('option'));
                             option.text("US");
                             option.val("US");
                             $("#MainContent_ddlmoneda").append(option);

                             var option2 = $(document.createElement('option'));
                             option2.text("MN");
                             option2.val("MN");
                             $("#MainContent_ddlmoneda").append(option2);
                         }
                      

                       
                     },
                     error: function (response) {
                         if (response.length != 0)
                             alert(response);
                     }
                 });

             }
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
         $(function () {
             $(".tb2").autocomplete(
                 {
                     source: function (request, response) {
                         $.ajax({
                             url: "nuevaOC.aspx/GetCentroCosto",
                             data: "{ 'productos': '" + "%" + request.term + "%" + "' }",
                             dataType: "json",
                             type: "POST",
                             contentType: "application/json; charset=utf-8",
                             dataFilter: function (data) { return data; },
                             success: function (data) {
                                 response($.map(data.d, function (item) {
                                     return {
                                         value: item.TG_CDESCRI,
                                         id: item.TG_CCLAVE

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
                         $('#MainContent_hfccosto').val(str);
                         $('#MainContent_txtccosto').val(str);

                         
                     }
                 });




         });
         $(function () {
             $(".tb3").autocomplete(
                 {
                     source: function (request, response) {
                         $.ajax({
                             url: "nuevaOC.aspx/GetSolicitante",
                             data: "{ 'productos': '" + "%" + request.term + "%" + "' }",
                             dataType: "json",
                             type: "POST",
                             contentType: "application/json; charset=utf-8",
                             dataFilter: function (data) { return data; },
                             success: function (data) {
                                 response($.map(data.d, function (item) {
                                     return {
                                         value: item.TG_CDESCRI,
                                         id: item.TG_CCLAVE

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
                         $('#MainContent_txtsolicitante').val(str);
                        
                     }
                 });




         });
         $(function () {
             $(".tb4").autocomplete(
                 {
                     source: function (request, response) {
                         $.ajax({
                             url: "nuevaOC.aspx/GetSolicitante",
                             data: "{ 'productos': '" + "%" + request.term + "%" + "' }",
                             dataType: "json",
                             type: "POST",
                             contentType: "application/json; charset=utf-8",
                             dataFilter: function (data) { return data; },
                             success: function (data) {
                                 response($.map(data.d, function (item) {
                                     return {
                                         value: item.TG_CDESCRI,
                                         id: item.TG_CCLAVE

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
                         $('#MainContent_txtsolicitante0').val(str);

                     }
                 });




         });
         $(function () {
             $(".tb5").autocomplete(
                 {
                     source: function (request, response) {
                         $.ajax({
                             url: "nuevaOC.aspx/GetCentroCosto",
                             data: "{ 'productos': '" + "%" + request.term + "%" + "' }",
                             dataType: "json",
                             type: "POST",
                             contentType: "application/json; charset=utf-8",
                             dataFilter: function (data) { return data; },
                             success: function (data) {
                                 response($.map(data.d, function (item) {
                                     return {
                                         value: item.TG_CDESCRI,
                                         id: item.TG_CCLAVE

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
                         $('#MainContent_txtcostodet').val(str);

                     }
                 });




         });

       

	</script>
   
</asp:Content>
   <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
         <asp:ScriptManager ID="scriptManager" runat="server" EnablePageMethods="true" />
    <table >
       
        <tr>
            <td>
                 <fieldset style="background-color: #99CCFF">
   <legend style="font-weight: bold; background-color: #99CCFF;" > <asp:Label ID="Label9" runat="server" Text="CREACIÓN" Font-Bold="True" Font-Size="12pt"></asp:Label></legend>

                <table  >
                    
                    <tr>
                        <td  >

                            <table   >
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
                                                        <asp:TextBox ID="txtFecha" runat="server" AutoPostBack="True" OnTextChanged="txtFecha_TextChanged"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label5" runat="server" Text="Area:" Font-Bold="True"></asp:Label>
                                                        <asp:DropDownList ID="ddlArea" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlArea_SelectedIndexChanged"></asp:DropDownList>
                                                    </td>
                                                    <td>  <asp:Label ID="Label6" runat="server" Text="Solicitante:" Font-Bold="True"></asp:Label>
                                                                                                         
                                                        <asp:TextBox ID="txtsolicitante" runat="server" Width="50px" AutoPostBack="True" OnTextChanged="txtsolicitante_TextChanged" ></asp:TextBox>
                                                        <asp:TextBox ID="txtsolicitantesensitivo" class="tb3" Width="350px" runat="server"></asp:TextBox>
                                        

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
                                                        <asp:TextBox ID="txtccostosensitivo" class="tb2" Width="350px" runat="server"></asp:TextBox>
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
                                                    <td class="auto-style3">
                                                        <asp:Label ID="Label7" runat="server" Text="Uso:" Font-Bold="True"></asp:Label>
                                                        <asp:DropDownList ID="ddluso" runat="server"></asp:DropDownList>
                                                    </td>
                                                    <td class="auto-style3">
                                                        <asp:Label ID="Label14" runat="server" Text="Prioridad:" Font-Bold="True"></asp:Label>
                                                        <asp:DropDownList ID="ddlPrioridad" runat="server"></asp:DropDownList>
                                                       
                                                    </td>
                                                </tr>
                                               
                                               
                                                 <tr>
                                                    <td>
                                                        <asp:Label ID="lbltcambio" runat="server" Text="Tipo Cambio:" Font-Bold="True"></asp:Label><asp:TextBox ID="txtlbltcambio" class="numeric" runat="server" ReadOnly="True"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Panel ID="pntrabajocurso" runat="server" Visible="False">
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                          <asp:Label ID="Label20" runat="server" Text="Trabajo en curso:" Font-Bold="True"></asp:Label>
                                                        <asp:TextBox ID="txttrabajoencurso" Width="50px" runat="server" AutoPostBack="True" OnTextChanged="txttrabajoencurso_TextChanged"></asp:TextBox>
                                                          <asp:DropDownList ID="ddltrabajoencurso" runat="server" Width="250px" AutoPostBack="True" OnSelectedIndexChanged="ddltrabajoencurso_SelectedIndexChanged"></asp:DropDownList>
                                        
                                                                          <asp:Label ID="lblmonedatc" runat="server" Font-Bold="True" Text="Moneda:"></asp:Label>
                                                                          <asp:TextBox ID="txtmonedatc" runat="server" Enabled="False" Width="50px"></asp:TextBox>
                                        
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblpresupuesto" runat="server" Font-Bold="True" Text="Presupuesto:"></asp:Label>
                                                             <asp:TextBox ID="txtpresupuesto" runat="server" Enabled="False" Width="60px"></asp:TextBox>

                                                            <asp:Label ID="lblTolerancia" runat="server" Font-Bold="True" Text="Tolerancia%:"></asp:Label>
                                                             <asp:TextBox ID="txttolerancia" runat="server" Enabled="False" Width="60px"></asp:TextBox>

                                                                           <asp:Label ID="Label21" runat="server" Font-Bold="True" Text="Total:"></asp:Label>
                                                             <asp:TextBox ID="txttotal" runat="server" Enabled="False" Width="60px"></asp:TextBox>
                                        

                                                            <asp:Label ID="lblAcumulado" runat="server" Font-Bold="True" Text="Acumulado:"></asp:Label>
                                                             <asp:TextBox ID="txtacumulado" Enabled="False" runat="server" Width="60px"></asp:TextBox>
                                        
                                                                           <asp:Label ID="Label22" runat="server" Font-Bold="True" Text="Saldo:"></asp:Label>
                                                             <asp:TextBox ID="txtsaldo" runat="server" Width="60px" Enabled="False"></asp:TextBox>
                                        

                                                                    </td>
                                                                       
                                                                </tr>
                                                            </table>
                                                           
                                                          
                                                        </asp:Panel>
                                                                   </td>
                                                    
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Label ID="Label10" runat="server" Text="Observ1:" Font-Bold="True"></asp:Label>
                                                        <asp:TextBox ID="txtObserv1" runat="server"  Width="350px" TextMode="MultiLine"></asp:TextBox>
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
                                                        <asp:TextBox ID="txtdias" runat="server" class="numeric" Height="17px" Width="50px"></asp:TextBox>
                                                    </td>
                                                </tr>

                                            </table>
                                        <table >
                                            <tr>
                                                <td >
                                                    <asp:Button ID="btnGrabar"  class="btn"  UseSubmitBehavior="false" runat="server" Text="Grabar" OnClick="btnGrabar_Click" Width="115px" />
                                               
                                                    </td>
                                                 <td >
                                                               <asp:Button ID="btnModificarcab" runat="server" Text="Modificar" class="btn"  UseSubmitBehavior="false" Width="115px" Visible="False" OnClick="btnModificarcab_Click" />
                                      
                                                      </td>

                                            </tr>
                                        </table>
                                        </asp:Panel>
                                        <asp:Panel ID="pnDetalle" runat="server" Enabled="False">

                                             <table  >
                                            <tr>
                                                 <td colspan="2" style=" vertical-align: top;"> 
                                                    <asp:Label ID="Label15" runat="server" Text="Producto:" Font-Bold="True"></asp:Label>
                                        <asp:TextBox ID="txtproducto" class="tb" runat="server" Width="350px"></asp:TextBox>
                                                     <asp:TextBox ID="txtcodprod" runat="server" AutoPostBack="True" OnTextChanged="txtcodprod_TextChanged"></asp:TextBox>
                                                     <asp:HiddenField ID="hfproducto" runat="server" />   
                                                     <asp:HiddenField ID="hfitem" runat="server" />

                                                     <asp:HiddenField ID="hfprecio" runat="server" />   
                                                     <asp:HiddenField ID="hftotal" runat="server" />
                                                     <asp:HiddenField ID="hfccosto" runat="server" />

                                                </td>
                                               
                                            </tr>
                                            <tr>
                                                <td >
                                                      <asp:Label ID="Label16" runat="server" Text="Cantidad:" Font-Bold="True"></asp:Label>
                                        <asp:TextBox ID="txtCantidaad" class="numeric" runat="server" Width="50px" ></asp:TextBox>
                                                     <asp:Label ID="lblPrecio" runat="server" Text="Precio:" Font-Bold="True"></asp:Label>
                                        <asp:TextBox ID="txtprecio" class="numeric" runat="server" Width="50px"  >0</asp:TextBox>
                                
                                                      <asp:Label ID="lblmonedatc0" runat="server" Font-Bold="True" Text="Moneda:"></asp:Label>
                                                    <asp:DropDownList ID="ddlmoneda" runat="server"></asp:DropDownList>
                                                      <asp:HiddenField ID="hfmoneda" runat="server" />
                                                      <asp:HiddenField ID="hftcambio" runat="server" />

                                                    <asp:HiddenField ID="hfpreciomn" runat="server" />
                                                    <asp:HiddenField ID="hfprecious" runat="server" />
                                
                                                </td>
                                               
                                            </tr>
                                                 <tr>
                                                     <td colspan="2" >
                                                         <asp:Label ID="Label19" runat="server" Text="Solicitante:" Font-Bold="True"></asp:Label>
                                                         <asp:TextBox ID="txtsolicitante0" runat="server" AutoPostBack="True" OnTextChanged="txtsolicitante0_TextChanged" Width="50px"></asp:TextBox>
                                                         <asp:TextBox ID="txtsolicitantesensitivo0" runat="server" class="tb4" Width="350px"></asp:TextBox>
                                                     </td>
                                                 </tr>
                                                 <tr>
                                                      <td >
                                                    <asp:Label ID="Label18" runat="server" Text="CCosto:" Font-Bold="True"></asp:Label>
                                        <asp:TextBox ID="txtcostodet" runat="server" Width="50px" AutoPostBack="True" OnTextChanged="txtcostodet_TextChanged"></asp:TextBox>
                                                    <asp:TextBox ID="txtccostosensitivo0" runat="server" class="tb5" Width="350px"></asp:TextBox>
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
                                                    <asp:Button ID="btnAgregar" class="btn"  UseSubmitBehavior="false" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
                                                    
                                       <asp:Button ID="btnModificar" class="btn"  UseSubmitBehavior="false" runat="server" Text="Modificar" OnClick="btnModificar_Click"  />
                                       
                                                    <asp:Button ID="btnimprimir" class="btn"  runat="server" OnClick="btnimprimir_Click" Text="Imprimir" />
                                       
                                                </td>
                                            </tr>
                                        </table>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="gvDetalle" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" OnRowDataBound="gvDetalle_RowDataBound" ShowFooter="True" DataKeyNames="RD_CUSRCOM,RD_CCENCOS,RD_CCODCOM,RD_NPRU2MN,RD_NPRU2US">
                                                        <Columns>
                                                            <asp:BoundField DataField="RD_CITEM" HeaderText="ITEM " />
                                                            <asp:BoundField DataField="RD_CCODIGO" HeaderText="CODIGO" />
                                                            <asp:BoundField DataField="RD_CDESCRI" HeaderText="DESCRIPCION" />
                                                            <asp:BoundField DataField="RD_CUNID" HeaderText="UNIDAD" />
                                                            <asp:BoundField DataField="RD_NQPEDI" HeaderText="CANTIDAD" DataFormatString="{0:F0}" />
                                                            <asp:BoundField DataField="RD_COBS" HeaderText="OBSERVACION" />
                                                            <asp:BoundField DataField="CCENCOSDESCRIP" HeaderText="C.COSTO" />
                                                            
                                                            <asp:BoundField DataField="SOLICITANTE" HeaderText="SOLICITANTE" />
                                                            
                                                            <asp:BoundField DataField="PRECIO_MOSTRAR" HeaderText="U.PRECIO" DataFormatString="{0:F2}" />
                                                            <asp:BoundField DataField="PRECIO_MOSTRAR_TOTAL" HeaderText="TOTAL" DataFormatString="{0:F2}" />
                                                            
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


 












  

