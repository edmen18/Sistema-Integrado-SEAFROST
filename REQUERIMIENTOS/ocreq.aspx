<%@ Page Title="Logística" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ocreq.aspx.cs" Inherits="ocreq" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">


.tooltip {
	display:none;
	position:absolute;
	border:1px solid #333;
	background-color:#161616;
	border-radius:5px;
	padding:10px;
	color:#fff;
	font-size:12px Arial;
}
</style>
<script type="text/javascript">
$(document).ready(function() {
        // Tooltip only Text
        $('.masterTooltip').hover(function(){
                // Hover over code
                var title = $(this).attr('title');

                $(this).data('tipText', title).removeAttr('title');
                $('<p class="tooltip"></p>')
                .text(title)
                .appendTo('body')
                .fadeIn('slow');
              
        }, function() {
                // Hover out code
                $(this).attr('title', $(this).data('tipText'));
                $('.tooltip').remove();
        }).mousemove(function(e) {
                var mousex = e.pageX + 20; //Get X coordinates
                var mousey = e.pageY + 10; //Get Y coordinates
                $('.tooltip')
                .css({ top: mousey, left: mousex })
        });
});
</script>
     <script type="text/javascript">
         $(function () {
             var uus = $("#HeadLoginView_HeadLoginName").html();
             $("#MainContent_hfusuario").val(uus);
             $("#MainContent_txtFecha").datepicker();
             $("#MainContent_txtffinal").datepicker();
             $("#MainContent_txtFechaRegistro").datepicker();
             
             $(".chequea").click(function () {
                 dtr = $(this).closest('tr');
                 myRow = dtr.index() - 1;
                 dtr1 = $(this).closest('td');
                 mycol = dtr1.index();

                 numero = $("#MainContent_gvDetalle_lblcodigo" + "_" + myRow).html();

                 trp = $(this).parent().parent();
                 articulo = $("td:eq(4)", trp).html();
                 requerimiento = $("td:eq(1)", trp).html();
                 $("#MainContent_lblnumero").text(articulo);
                 //filtarcantidademb(numero);
                 //$('.EstadoPedido').dialog('open');

                 cuenta = -1;

               //  alert(myRow);

                 //var rowt = $(this).is(':checked');
                 //var chkbox = (rowt).find(':checkbox2');
                 //asigna_sel_1 = chkbox.is(':checked');

                 var_chequea = $("#MainContent_gvDetalle_CheckBox2" + "_" + myRow);

                 asigna_sel = var_chequea.is(':checked');
                 //     alert($("#MainContent_gvDetalle_CheckBox2" + "_" + myRow));

               //  alert(var_chequea.is(':checked'));

                 $("#MainContent_gvDetalle tbody tr").each(function (index) {
                     var campo1, campo2, campo3;
                     $(this).children("td").each(function (index2) {

                         switch (index2) {
                             case 0: campo1 = $(this).text();
                                 break;
                             case 1: campo2 = $(this).text();
                                 break;
                             case 2: campo3 = $(this).text();
                                 break;
                         }
                         //  $(this).css("background-color", "#ECF8E0");

                         if (campo2 == requerimiento) {
                          //   alert(var_chequea);
                             if (asigna_sel)
                                 $("#MainContent_gvDetalle_CheckBox1" + "_" + cuenta).attr("checked", true);
                             else
                                 $("#MainContent_gvDetalle_CheckBox1" + "_" + cuenta).attr("checked", false);
                         }


                     })
                     cuenta++;
                 });



             });


             $(".ver").click(function () {
                                 
                 dtr = $(this).closest('tr');
                 myRow = dtr.index() - 1;
                 dtr1 = $(this).closest('td');
                 mycol = dtr1.index();
                 
                 numero= $("#MainContent_gvDetalle_lblcodigo" +"_" + myRow).html();

                 trp = $(this).parent().parent();
                 articulo = $("td:eq(4)", trp).html();
                 requerimiento = $("td:eq(1)", trp).html();
                 $("#MainContent_lblnumero").text(articulo);
                 filtarcantidademb(numero);
                 $('.EstadoPedido').dialog('open');

                 cuenta = -1;

                 $("#MainContent_gvDetalle tbody tr").each(function (index) {
                     var campo1, campo2, campo3;
                     $(this).children("td").each(function (index2) {

                             switch (index2) {
                             case 0: campo1 = $(this).text();
                                 break;
                             case 1: campo2 = $(this).text();
                                 break;
                             case 2: campo3 = $(this).text();
                                 break;
                         }
                         //  $(this).css("background-color", "#ECF8E0");

                             if (campo2 == requerimiento)
                         {
                           //  alert(cuenta);
                             $("#MainContent_gvDetalle_CheckBox1" + "_" + cuenta).attr("checked", true);
                         }

                       
                     })
                     cuenta++;
                 });



             });

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
             $('.moneda').change(function () {
                 dtr = $(this).closest('tr');
                 myRow = dtr.index() - 1;
                 dtr1 = $(this).closest('td');
                 mycol = dtr1.index();
                 $("#MainContent_GridView1_cbsel" + mycol + "_" + myRow).attr("checked", false);
           });
             $('.check1').click(function () {

               
                 var rowt = $(this);
                 var chkbox = (rowt).find(':checkbox');
                 trp = $(this).parent().parent();
                 trp1 = $(this).parent().children();
                 dtr = $(this).closest('tr');
                 myRow = dtr.index() - 1;
                 dtr1 = $(this).closest('td');
                 mycol = dtr1.index();

                 asigna_sel_1 = chkbox.is(':checked');

                 for (var i = 5; i <= 35; i++) {
                     $("#MainContent_GridView1_cbsel"+i+"_" + myRow).attr("checked", false);
                 }
                 if (asigna_sel_1) {
                     $("#MainContent_GridView1_cbsel" + mycol + "_" + myRow).attr("checked", true);
                 }

              var totalRows = $("#MainContent_GridView1 tr").length - 2;
              var cunenta_soles = 0;
              var cuenta_dolares = 0;
              var asigna_moneda = 0;
              var asigna_sel = false;

              for (var i = 0; i < totalRows; i++) {
                 
                  asigna_sel=$("#MainContent_GridView1_cbsel" + mycol + "_" + i).is(':checked');
                 
                  if (asigna_sel)
                  {
                      asigna_moneda = $("#MainContent_GridView1_ddlmoneda" + mycol + "_" + i).val();
                      if (asigna_moneda == "MN")
                          cunenta_soles++;
                      else
                          cuenta_dolares++;
                  }
                 
              }
              if (cunenta_soles > 0 && cuenta_dolares > 0)
              {
                  alert("Elija una moneda por orden de compra");
                  $("#MainContent_GridView1_cbsel" + mycol + "_" + myRow).attr("checked", false);
              }
              
                 });


           

             $('.EstadoPedido').dialog({
                 autoOpen: false,
                 modal: true,
                 resizable: false,
                 width: 600,
                 heigth: 250,
                 title: 'Historial de precios',
                 open: function (event, ui) {

                 },
                 close: function (event, ui) {

                 }

             });
         });
         function filtarcantidademb(gidpped) {
             rr = gidpped;
             var REQ = {};
             REQ.RD_CCODIGO = rr;
             $.ajax({

                 type: "POST",
                 url: "ocreq.aspx/ListarHistorialPrecios",
                 data: '{REQ: ' + JSON.stringify(REQ) + '}',
                 contentType: "application/json; charset=utf-8",
                 async: false,

                 dataType: "json",
                 success: function (data) {

                     if (data.d.length > 0) {
                         var row = $("[id*=gvdetallereq] tr:last-child").clone(true);
                         $("[id*=gvdetallereq] tr").not($("[id*=gvdetallereq] tr:first-child")).remove();

                         for (var i = 0; i < data.d.length; i++) {

                             $("td", row).eq(0).html(data.d[i].OC_CCODPRO);
                             $("td", row).eq(1).html(data.d[i].OC_CRAZSOC);
                             $("td", row).eq(2).html(data.d[i].OC_DFECDOC);
                             $("td", row).eq(3).html(data.d[i].OC_CCODMON);
                             $("td", row).eq(4).html(parseFloat( data.d[i].OC_NPREUN2).toFixed(2));
                             $("td", row).eq(5).html(data.d[i].OC_CNUMORD);


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
                         $("td", row).eq(4).html("");
                         $("td", row).eq(5).html("");


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
             $(".tb1").autocomplete(
                 {
                     source: function (request, response) {
                         $.ajax({
                             url: "listadoOC.aspx/GetProveedores",
                             data: "{ 'productos': '" + "%" + request.term + "%" + "' }",
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
                         $('#MainContent_txtruc').val(str);


                     }
                 });




         });
	</script>
     <style type="text/css">
         #txtproducto0 {
             width: 337px;
         }
         .check{
             display:inline; 
         }
         </style>
</asp:Content>
   <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
         <asp:ScriptManager ID="scriptManager" runat="server" EnablePageMethods="true" />
    <table width="100%" cellpadding="5" cellspacing="5" border="0">
       
        <tr>
            <td>
                 <fieldset style="background-color: #99CCFF">
   <legend style="font-weight: bold; background-color: #99CCFF;" > <asp:Label ID="Label9" runat="server" Text="REQUERIMIENTOS CONTRA OC" Font-Bold="True" Font-Size="12pt"></asp:Label></legend>

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
                                                   <asp:Label ID="Label1" runat="server" Text="F.Inicial Req:" Font-Bold="True"></asp:Label>
                                        <asp:TextBox ID="txtFecha" runat="server"></asp:TextBox>
                                                </td>
                                                 <td>
                                                   <asp:Label ID="Label19" runat="server" Text="F.Final Req:" Font-Bold="True"></asp:Label>
                                        <asp:TextBox ID="txtffinal" runat="server"></asp:TextBox>
                                                </td>
                                                
                                                <td>
                                                   <asp:Label ID="Label2" runat="server" Text="Nro Req:" Font-Bold="True"></asp:Label>
                                        <asp:TextBox ID="txtnroreq" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                                 
                                         

                                        </table>
                                            <table >
                                                 <tr>
                                                      <td>
                                                           <asp:Label ID="Label7" runat="server" Text="Solicitante:" Font-Bold="True"></asp:Label>
                                 
                                                    <asp:DropDownList ID="ddlsolicitante" runat="server"></asp:DropDownList>
                                                      </td>
                                                      
                                                  </tr>
                                            </table>
                                        <table >
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnGrabar" runat="server" Text="Mostrar requerimientos" OnClick="btnGrabar_Click" Width="150px" />
                                                                               <asp:Button ID="btnOC" runat="server" OnClick="btnOC_Click" Text="Generar" />
                                                                               <asp:HiddenField ID="hfcolumnas" runat="server" />
                                                                               <asp:HiddenField ID="hfip" runat="server" />
                                                                               </td>
                                            </tr>
                                        </table>
                                        </asp:Panel>
                                        <asp:Panel ID="pnDetalle" runat="server" >

                                             <table >
                                           
                                          
                                           
                                            
                                        </table>
                                        <table>
                                            <tr>
                                                <td>
                                                    <div style="overflow: scroll;  height: 150px">

                                                   
                                                    <asp:GridView ID="gvDetalle" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False"  ShowFooter="True" DataKeyNames="RC_CCODSOLI,RD_CCODIGO,RD_CCENCOS">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="SEL1">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="RC_CNROREQ" HeaderText="NRO " >
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="RC_DFECREQ" HeaderText="FECHA">
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="TG_CDESCRI" HeaderText="SOLICITANTE">
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="RD_CDESCRI" HeaderText="ARTICULO" />
                                                            <asp:BoundField DataField="RD_NQPEDI" HeaderText="CANTIDAD" />
                                                            <asp:BoundField DataField="CCOSTO" HeaderText="CCOSTO" />
                                                            <asp:TemplateField HeaderText="VER">
                                                                <ItemTemplate>
                                                                    <div class="ver">
                                                                        <img alt="" src="../Images/Message_Information.png" width="20" style="cursor:pointer"/>
                                                                        <asp:Label ID="lblcodigo" runat="server" Style="display:none" Text='<%# Bind("RD_CCODIGO") %>'></asp:Label>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="SEL2">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="CheckBox2" runat="server" class="chequea" />
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

                                                         </div>
                                                    
                                                </td>
                                               
                                            </tr>
                                           
                                        </table><br />
                                            <table >
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblFechaRegistro" runat="server" Text="Fecha Registro:" Font-Bold="True"></asp:Label><asp:TextBox ID="txtFechaRegistro" runat="server" AutoPostBack="True" OnTextChanged="txtFechaRegistro_TextChanged"></asp:TextBox><asp:Label ID="lbltcambio" runat="server" Text="Tipo Cambio:" Font-Bold="True"></asp:Label><asp:TextBox ID="txtlbltcambio" class="numeric" runat="server" ReadOnly="True"></asp:TextBox>
                                                         <asp:Label ID="lblCabObservacion" runat="server" Text="Observación:" Font-Bold="True" Font-Strikeout="False"></asp:Label><asp:TextBox ID="txtObservacion" runat="server" TextMode="MultiLine" Width="270px" Height="45px"></asp:TextBox>
                                                        
                                                        <br />
                                                        <asp:Label ID="lblalmacen" runat="server" Text="Almacén:" Font-Bold="True"></asp:Label>
                                                        <asp:DropDownList ID="ddlalma" class="selalma" runat="server" Width="300"></asp:DropDownList>
                                                        
                                                     <%--   <asp:Label ID="lblCabFormaPago" runat="server" Font-Bold="True" >Forma de Pago:</asp:Label>
                                                        <asp:DropDownList ID="ddlFormaPago" runat="server">
                                                        </asp:DropDownList>--%>
                                                   <br />
                                                        <asp:Label ID="Label3" runat="server" Text="Proveedor:" Font-Bold="True"></asp:Label>
                                        <asp:TextBox ID="txtProveedor" class="tb1" runat="server" Width="350px"></asp:TextBox><asp:TextBox ID="txtruc" runat="server" AutoPostBack="True" OnTextChanged="txtruc_TextChanged"></asp:TextBox>
                                                        <asp:Button ID="btnaddprov" runat="server" Text="Agregar" OnClick="btnaddprov_Click" />
                                                     <asp:HiddenField ID="hfproveedor" runat="server" />
                                                         </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" DataKeyNames="RD_CCODIGO,RC_CCODSOLI,RD_CCENCOS" ShowFooter="True" >
                                                            <Columns>
                                                                <asp:BoundField DataField="RC_CNROREQ" HeaderText="NRO REQ" />
                                                                <asp:BoundField DataField="TG_CDESCRI" HeaderText="SOLICITANTE" />
                                                                <asp:BoundField DataField="CCOSTO" HeaderText="CCOSTO" />
                                                                <asp:BoundField DataField="RD_CDESCRI" HeaderText="ARTICULO" />
                                                                <asp:TemplateField HeaderText="CANTIDAD">
                                                                 
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtcantidad" class ="numeric" runat="server" Width="50px" Text='<%# Bind("RD_NQPEDI","{0:f2}") %>' ReadOnly="True"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="P5">
                                                                   <FooterTemplate>
                                                                        <asp:CheckBox ID="cbigv5" runat="server" Text="IGV" />
                                                                        <br />
                                                                        <asp:DropDownList ID="ddltipooc5" runat="server">
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                                    <div class="check">
                                                                                        <asp:DropDownList ID="ddlmoneda5" class="moneda" runat="server"></asp:DropDownList>
                                                                                        <asp:TextBox ID="txtprecio5" class ="numeric"  runat="server" Width="40"></asp:TextBox>
                                                                                       <asp:CheckBox ID="cbsel5" runat="server" class="check1 masterTooltip" ToolTip='<%# Bind("RD_CDESCRI") %>'   />
                                                                                        </div>
                                                                      <asp:HiddenField ID="hfruc5" runat="server" />
                                                                         </ItemTemplate>
                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="P6">
                                                                   <FooterTemplate>
                                                                        <asp:CheckBox ID="cbigv6" runat="server" Text="IGV" />
                                                                        <br />
                                                                        <asp:DropDownList ID="ddltipooc6" runat="server">
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                                    <div class="check">
                                                                                        <asp:DropDownList ID="ddlmoneda6"  class="moneda" runat="server"></asp:DropDownList>
                                                                              <asp:TextBox ID="txtprecio6"  class ="numeric" runat="server" Width="40"></asp:TextBox>
                                                                                       <asp:CheckBox ID="cbsel6" runat="server" class="check1 masterTooltip" ToolTip='<%# Bind("RD_CDESCRI") %>'  />
                                                                                        </div>
                                                                                
                                                                      <asp:HiddenField ID="hfruc6" runat="server" />
                                                                         </ItemTemplate>

                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="P7">
                                                                   <FooterTemplate>
                                                                       <asp:CheckBox ID="cbigv7" runat="server" Text="IGV" />
                                                                        <br />
                                                                        <asp:DropDownList ID="ddltipooc7" runat="server">
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                       <div class ="check">
                                                                               <asp:DropDownList ID="ddlmoneda7"  class="moneda" runat="server"></asp:DropDownList>
                                                                                <asp:TextBox ID="txtprecio7"  class ="numeric"  runat="server" Width="40"></asp:TextBox>
                                                                            <asp:CheckBox ID="cbsel7" runat="server" class="check1 masterTooltip" ToolTip='<%# Bind("RD_CDESCRI") %>'/>
                                                                            </div>
                                                                      <asp:HiddenField ID="hfruc7" runat="server" />
                                                                         </ItemTemplate>

                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="P8">
                                                                     <FooterTemplate>
                                                                        <asp:CheckBox ID="cbigv8" runat="server" Text="IGV" />
                                                                        <br />
                                                                        <asp:DropDownList ID="ddltipooc8" runat="server">
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                       <div class ="check">
                                                                          <asp:DropDownList ID="ddlmoneda8"  class="moneda" runat="server"></asp:DropDownList>
                                                                            <asp:TextBox ID="txtprecio8"  class ="numeric"  runat="server" Width="40"></asp:TextBox>
                                                                        <asp:CheckBox ID="cbsel8" runat="server" class="check1 masterTooltip" ToolTip='<%# Bind("RD_CDESCRI") %>'/>
                                                                           </div>
                                                                       <asp:HiddenField ID="hfruc8" runat="server" />
                                                                    </ItemTemplate>

                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="P9">
                                                                    <FooterTemplate>
                                                                        <asp:CheckBox ID="cbigv9" runat="server" Text="IGV"/>
                                                                        <br />
                                                                        <asp:DropDownList ID="ddltipooc9" runat="server">
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                         <div class ="check">
                                                                             <asp:DropDownList ID="ddlmoneda9"  class="moneda" runat="server"></asp:DropDownList>
                                                                               <asp:TextBox ID="txtprecio9"   class ="numeric" runat="server" Width="40"></asp:TextBox>
                                                                          <asp:CheckBox ID="cbsel9" runat="server" class="check1 masterTooltip" ToolTip='<%# Bind("RD_CDESCRI") %>' />
                                                                            </div>
                                                                       <asp:HiddenField ID="hfruc9" runat="server" />
                                                                    </ItemTemplate>

                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="P10">
                                                               <FooterTemplate>
                                                                        <asp:CheckBox ID="cbigv10" Text="IGV" runat="server" />
                                                                        <br />
                                                                        <asp:DropDownList ID="ddltipooc10" runat="server">
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                     <div class ="check">
                                                                         <asp:DropDownList ID="ddlmoneda10"  class="moneda" runat="server"></asp:DropDownList>
                                                                                <asp:TextBox ID="txtprecio10"  class ="numeric"  runat="server" Width="40"></asp:TextBox>
                                                                            <asp:CheckBox ID="cbsel10" runat="server"  class="check1 masterTooltip" ToolTip='<%# Bind("RD_CDESCRI") %>'/>
                                                                         </div>
                                                                            
                                                                       
                                                                      <asp:HiddenField ID="hfruc10" runat="server" />
                                                                         </ItemTemplate>

                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="P11">
                                                                 <FooterTemplate>
                                                                       <asp:CheckBox ID="cbigv11" runat="server" Text="IGV" />
                                                                        <br />
                                                                        <asp:DropDownList ID="ddltipooc11" runat="server">
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                         <div class ="check">
                                                                             <asp:DropDownList ID="ddlmoneda11" class="moneda" runat="server"></asp:DropDownList>

                                                                              <asp:TextBox ID="txtprecio11"   class ="numeric" runat="server" Width="40"></asp:TextBox>
                                                                         <asp:CheckBox ID="cbsel11" runat="server"  class="check1 masterTooltip" ToolTip='<%# Bind("RD_CDESCRI") %>'/>
                                                                          </div>
                                                                       <asp:HiddenField ID="hfruc11" runat="server" />
                                                                    </ItemTemplate>

                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="P12">
                                                                 <FooterTemplate>
                                                                        <asp:CheckBox ID="cbigv12" runat="server" Text="IGV"/>
                                                                        <br />
                                                                        <asp:DropDownList ID="ddltipooc12" runat="server">
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                         <div class ="check">
                                                                       <asp:DropDownList ID="ddlmoneda12"  class="moneda" runat="server"></asp:DropDownList>
                                                                        <asp:TextBox ID="txtprecio12"   class ="numeric" runat="server" Width="40"></asp:TextBox>
                                                                            <asp:CheckBox ID="cbsel12" runat="server"  class="check1 masterTooltip" ToolTip='<%# Bind("RD_CDESCRI") %>'/>
                                                                             </div>
                                                                            
                                                                           
                                                                       <asp:HiddenField ID="hfruc12" runat="server" />
                                                                    </ItemTemplate>

                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="P13">
                                                                 <FooterTemplate>
                                                                        <asp:CheckBox ID="cbigv13"  class="moneda" runat="server" Text="IGV"/>
                                                                        <br />
                                                                        <asp:DropDownList ID="ddltipooc13" runat="server">
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                      <div class ="check">
                                                                          <asp:DropDownList ID="ddlmoneda13" runat="server"></asp:DropDownList>

                                                                                <asp:TextBox ID="txtprecio13"   class ="numeric" runat="server" Width="40"></asp:TextBox>
                                                                        <asp:CheckBox ID="cbsel13" runat="server" class="check1 masterTooltip" ToolTip='<%# Bind("RD_CDESCRI") %>' />
                                                                            </div>
                                                                        
                                                                      <asp:HiddenField ID="hfruc13" runat="server" />
                                                                         </ItemTemplate>

                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="P14">
                                                                <FooterTemplate>
                                                                        <asp:CheckBox ID="cbigv14" runat="server" Text="IGV"/>
                                                                        <br />
                                                                        <asp:DropDownList ID="ddltipooc14"  class="moneda" runat="server">
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                         <div class ="check">
                                                                             <asp:DropDownList ID="ddlmoneda14" runat="server"></asp:DropDownList>
                                                                           <asp:TextBox ID="txtprecio14"   class ="numeric" runat="server" Width="40"></asp:TextBox>
                                                                            <asp:CheckBox ID="cbsel14" runat="server" class="check1 masterTooltip" ToolTip='<%# Bind("RD_CDESCRI") %>'/>
                                                                            </div>
                                                                            
                                                                      <asp:HiddenField ID="hfruc14" runat="server" />
                                                                         </ItemTemplate>

                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="P15">
                                                                <FooterTemplate>
                                                                      <asp:CheckBox ID="cbigv15" runat="server" Text="IGV"/>
                                                                        <br />
                                                                        <asp:DropDownList ID="ddltipooc15" runat="server">
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                       <div class ="check">
                                                                           <asp:DropDownList ID="ddlmoneda15"  class="moneda" runat="server"></asp:DropDownList>
                                                                           <asp:TextBox ID="txtprecio15"   class ="numeric" runat="server" Width="40"></asp:TextBox>
                                                                          <asp:CheckBox ID="cbsel15" runat="server"  class="check1 masterTooltip" ToolTip='<%# Bind("RD_CDESCRI") %>'/>
                                                                            </div>
                                                                      <asp:HiddenField ID="hfruc15" runat="server" />
                                                                         </ItemTemplate>

                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="P16">
                                                                <FooterTemplate>
                                                                        <asp:CheckBox ID="cbigv16" runat="server" Text="IGV"/>
                                                                        <br />
                                                                        <asp:DropDownList ID="ddltipooc16" runat="server">
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                           <div class ="check">
                                                                               <asp:DropDownList ID="ddlmoneda16"  class="moneda" runat="server"></asp:DropDownList>
                                                                               <asp:TextBox ID="txtprecio16"  class ="numeric"  runat="server" Width="40"></asp:TextBox>
                                                                            <asp:CheckBox ID="cbsel16" runat="server" class="check1 masterTooltip" ToolTip='<%# Bind("RD_CDESCRI") %>'/>
                                                                            </div>
                                                                      <asp:HiddenField ID="hfruc16" runat="server" />
                                                                         </ItemTemplate>

                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="P17">
                                                                <FooterTemplate>
                                                                       <asp:CheckBox ID="cbigv17" runat="server" Text="IGV"/>
                                                                        <br />
                                                                        <asp:DropDownList ID="ddltipooc17" runat="server">
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                         <div class ="check">
                                                                                <asp:DropDownList ID="ddlmoneda17"  class="moneda" runat="server"></asp:DropDownList>
                                                                                <asp:TextBox ID="txtprecio17"   class ="numeric" runat="server" Width="40"></asp:TextBox>
                                                                            <asp:CheckBox ID="cbsel17" runat="server" class="check1 masterTooltip" ToolTip='<%# Bind("RD_CDESCRI") %>' />
                                                                           </div>
                                                                      <asp:HiddenField ID="hfruc17" runat="server" />
                                                                         </ItemTemplate>

                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="P18">
                                                                <FooterTemplate>
                                                                         <asp:CheckBox ID="cbigv18" runat="server" Text="IGV"/>
                                                                        <br />
                                                                        <asp:DropDownList ID="ddltipooc18" runat="server">
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                       <div class ="check">
                                                                              <asp:DropDownList ID="ddlmoneda18"  class="moneda" runat="server"></asp:DropDownList>
                                                                                <asp:TextBox ID="txtprecio18"   class ="numeric" runat="server" Width="40"></asp:TextBox>
                                                                            <asp:CheckBox ID="cbsel18" runat="server"  class="check1 masterTooltip" ToolTip='<%# Bind("RD_CDESCRI") %>'/>
                                                                            
                                                                           </div>
                                                                      <asp:HiddenField ID="hfruc18" runat="server" />
                                                                         </ItemTemplate>

                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="P19">
                                                                <FooterTemplate>
                                                                         <asp:CheckBox ID="cbigv19" runat="server" Text="IGV"/>
                                                                        <br />
                                                                        <asp:DropDownList ID="ddltipooc19" runat="server">
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                         <div class ="check">
                                                                              <asp:DropDownList ID="ddlmoneda19"  class="moneda" runat="server"></asp:DropDownList>
                                                                                <asp:TextBox ID="txtprecio19"   class ="numeric" runat="server" Width="40"></asp:TextBox>
                                                                            <asp:CheckBox ID="cbsel19" runat="server" class="check1 masterTooltip" ToolTip='<%# Bind("RD_CDESCRI") %>'/>
                                                                            
                                                                          </div>
                                                                      <asp:HiddenField ID="hfruc19" runat="server" />
                                                                         </ItemTemplate>

                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="P20">
                                                                <FooterTemplate>
                                                                         <asp:CheckBox ID="cbigv20" runat="server" Text="IGV"/>
                                                                        <br />
                                                                        <asp:DropDownList ID="ddltipooc20" runat="server">
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                       <div class ="check">
                                                                            <asp:DropDownList ID="ddlmoneda20"  class="moneda" runat="server"></asp:DropDownList>
                                                                             
                                                                                <asp:TextBox ID="txtprecio20"   class ="numeric" runat="server" Width="40"></asp:TextBox>
                                                                            <asp:CheckBox ID="cbsel20" runat="server" class="check1 masterTooltip" ToolTip='<%# Bind("RD_CDESCRI") %>'/>
                                                                            </div>
                                                                           
                                                                      <asp:HiddenField ID="hfruc20" runat="server" />
                                                                         </ItemTemplate>

                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="P21">
                                                                <FooterTemplate>
                                                                         <asp:CheckBox ID="cbigv21" runat="server" Text="IGV"/>
                                                                        <br />
                                                                        <asp:DropDownList ID="ddltipooc21" runat="server">
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                      <div class ="check">
                                                                          <asp:DropDownList ID="ddlmoneda21"  class="moneda" runat="server"></asp:DropDownList>
                                                                                 
                                                                           <asp:TextBox ID="txtprecio21"   class ="numeric" runat="server" Width="40"></asp:TextBox>
                                                                           <asp:CheckBox ID="cbsel21" runat="server" class="check1 masterTooltip" ToolTip='<%# Bind("RD_CDESCRI") %>' />
                                                                            </div>
                                                                           
                                                                      <asp:HiddenField ID="hfruc21" runat="server" />
                                                                         </ItemTemplate>

                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="P22">
                                                                <FooterTemplate>
                                                                         <asp:CheckBox ID="cbigv22" runat="server" Text="IGV"/>
                                                                        <br />
                                                                        <asp:DropDownList ID="ddltipooc22" runat="server">
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <div class ="check">
                                                                            <asp:DropDownList ID="ddlmoneda22"  class="moneda" runat="server"></asp:DropDownList>
                                                                            
                                                                              <asp:TextBox ID="txtprecio22"   class ="numeric" runat="server" Width="40"></asp:TextBox>
                                                                            <asp:CheckBox ID="cbsel22" runat="server"    class="check1 masterTooltip" ToolTip='<%# Bind("RD_CDESCRI") %>'/>
                                                                            </div>
                                                                           
                                                                      <asp:HiddenField ID="hfruc22" runat="server" />
                                                                         </ItemTemplate>

                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="P23">
                                                                <FooterTemplate>
                                                                         <asp:CheckBox ID="cbigv23" runat="server" Text="IGV"/>
                                                                        <br />
                                                                        <asp:DropDownList ID="ddltipooc23" runat="server">
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                         <div class ="check">
                                                                       <asp:DropDownList ID="ddlmoneda23"  class="moneda" runat="server"></asp:DropDownList>
                                                                            
                                                                                      <asp:TextBox ID="txtprecio23"   class ="numeric" runat="server" Width="40"></asp:TextBox>
                                                                            <asp:CheckBox ID="cbsel23" runat="server"  class="check1 masterTooltip" ToolTip='<%# Bind("RD_CDESCRI") %>'/>
                                                                            </div>
                                                                           
                                                                      <asp:HiddenField ID="hfruc23" runat="server" />
                                                                         </ItemTemplate>

                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="P24">
                                                                <FooterTemplate>
                                                                        <asp:CheckBox ID="cbigv24" runat="server" Text="IGV"/>
                                                                        <br />
                                                                        <asp:DropDownList ID="ddltipooc24" runat="server">
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <div class ="check">
                                                                            <asp:DropDownList ID="ddlmoneda24"  class="moneda" runat="server"></asp:DropDownList>
                                                                          
                                                                             <asp:TextBox ID="txtprecio24"   class ="numeric" runat="server" Width="40"></asp:TextBox>
                                                                            <asp:CheckBox ID="cbsel24" runat="server"  class="check1 masterTooltip" ToolTip='<%# Bind("RD_CDESCRI") %>'/>
                                                                            
                                                                        </div>
                                                                      <asp:HiddenField ID="hfruc24" runat="server" />
                                                                         </ItemTemplate>

                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="P25">
                                                                <FooterTemplate>
                                                                     <asp:CheckBox ID="cbigv25" runat="server" Text="IGV"/>
                                                                        <br />
                                                                        <asp:DropDownList ID="ddltipooc25" runat="server">
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                         <div class ="check">
                                                                              
                                                                             <asp:DropDownList ID="ddlmoneda25"  class="moneda" runat="server"></asp:DropDownList>
                                                                          
                                                                               <asp:TextBox ID="txtprecio25"   class ="numeric" runat="server" Width="40"></asp:TextBox>
                                                                            <asp:CheckBox ID="cbsel25" runat="server" class="check1 masterTooltip" ToolTip='<%# Bind("RD_CDESCRI") %>' />
                                                                             </div>
                                                                      <asp:HiddenField ID="hfruc25" runat="server" />
                                                                         </ItemTemplate>

                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="P26">
                                                                <FooterTemplate>
                                                                         <asp:CheckBox ID="cbigv26" runat="server" Text="IGV"/>
                                                                        <br />
                                                                        <asp:DropDownList ID="ddltipooc26" runat="server">
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                         <div class ="check">
                                                                                <asp:DropDownList ID="ddlmoneda26"  class="moneda" runat="server"></asp:DropDownList>
                                                                          
                                                                               <asp:TextBox ID="txtprecio26"   class ="numeric" runat="server" Width="40"></asp:TextBox>
                                                                            <asp:CheckBox ID="cbsel26" runat="server"  class="check1 masterTooltip" ToolTip='<%# Bind("RD_CDESCRI") %>'/>
                                                                            </div>
                                                                           
                                                                      <asp:HiddenField ID="hfruc26" runat="server" />
                                                                         </ItemTemplate>

                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="P27">
                                                                <FooterTemplate>
                                                                          <asp:CheckBox ID="cbigv27" runat="server" Text="IGV"/>
                                                                        <br />
                                                                        <asp:DropDownList ID="ddltipooc27" runat="server">
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <div class ="check">
                                                                            <asp:DropDownList ID="ddlmoneda27"  class="moneda" runat="server"></asp:DropDownList>
                                                                           
                                                                            <asp:TextBox ID="txtprecio27"   class ="numeric" runat="server" Width="40"></asp:TextBox>
                                                                           <asp:CheckBox ID="cbsel27" runat="server"  class="check1 masterTooltip" ToolTip='<%# Bind("RD_CDESCRI") %>'/>
                                                                            </div>
                                                                         
                                                                      <asp:HiddenField ID="hfruc27" runat="server" />
                                                                         </ItemTemplate>

                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="P28">
                                                                <FooterTemplate>
                                                                           <asp:CheckBox ID="cbigv28" runat="server" Text="IGV"/>
                                                                        <br />
                                                                        <asp:DropDownList ID="ddltipooc28" runat="server">
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                         <div class ="check">
                                                                    <asp:DropDownList ID="ddlmoneda28"  class="moneda" runat="server"></asp:DropDownList>
                                                                           
                                                                             
                                                                                        <asp:TextBox ID="txtprecio28"   class ="numeric" runat="server" Width="40"></asp:TextBox>
                                                                            <asp:CheckBox ID="cbsel28" runat="server"  class="check1 masterTooltip" ToolTip='<%# Bind("RD_CDESCRI") %>'/>
                                                                            
                                                                           
                                                                       
                                                                             </div>
                                                                      <asp:HiddenField ID="hfruc28" runat="server" />
                                                                         </ItemTemplate>

                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="P29">
                                                                <FooterTemplate>
                                                                          <asp:CheckBox ID="cbigv29" runat="server" Text="IGV"/>
                                                                        <br />
                                                                        <asp:DropDownList ID="ddltipooc29" runat="server">
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                         <div class ="check">
                                                                             <asp:DropDownList ID="ddlmoneda29"  class="moneda" runat="server"></asp:DropDownList>
                                                                    

                                                                                <asp:TextBox ID="txtprecio29"   class ="numeric" runat="server" Width="40"></asp:TextBox>
                                                                            <asp:CheckBox ID="cbsel29" runat="server" class="check1 masterTooltip" ToolTip='<%# Bind("RD_CDESCRI") %>' />
                                                                            </div>
                                                                           
                                                                      <asp:HiddenField ID="hfruc29" runat="server" />
                                                                         </ItemTemplate>

                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="P30">
                                                                <FooterTemplate>
                                                                           <asp:CheckBox ID="cbigv30" runat="server" Text="IGV"/>
                                                                        <br />
                                                                        <asp:DropDownList ID="ddltipooc30" runat="server">
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                         <div class ="check">
                                                                             <asp:DropDownList ID="ddlmoneda30"  class="moneda" runat="server"></asp:DropDownList>
                                                                                <asp:TextBox ID="txtprecio30"   class ="numeric" runat="server" Width="40"></asp:TextBox>
                                                                            <asp:CheckBox ID="cbsel30" runat="server" class="check1 masterTooltip" ToolTip='<%# Bind("RD_CDESCRI") %>'/>
                                                                             </div>
                                                                    <asp:HiddenField ID="hfruc30" runat="server" />
                                                                         </ItemTemplate>

                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="P31">
                                                                <FooterTemplate>
                                                                           <asp:CheckBox ID="cbigv31" runat="server" Text="IGV"/>
                                                                        <br />
                                                                        <asp:DropDownList ID="ddltipooc31" runat="server">
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                       <div class ="check">
                                                                           <asp:DropDownList ID="ddlmoneda31"  class="moneda" runat="server"></asp:DropDownList>
                                                                                <asp:TextBox ID="txtprecio31"   class ="numeric" runat="server" Width="40"></asp:TextBox>
                                                                            <asp:CheckBox ID="cbsel31" runat="server" class="check1 masterTooltip" ToolTip='<%# Bind("RD_CDESCRI") %>' />
                                                                            </div>
                                                                          
                                                                      <asp:HiddenField ID="hfruc31" runat="server" />
                                                                         </ItemTemplate>

                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="P32">
                                                                <FooterTemplate>
                                                                       <asp:CheckBox ID="cbigv32" runat="server" Text="IGV"/>
                                                                        <br />
                                                                        <asp:DropDownList ID="ddltipooc32" runat="server">
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                          <div class ="check">
                                                                              <asp:DropDownList ID="ddlmoneda32"   class="moneda" runat="server"></asp:DropDownList>
                                                                               <asp:TextBox ID="txtprecio32"   class ="numeric" runat="server" Width="40"></asp:TextBox>
                                                                           <asp:CheckBox ID="cbsel32" runat="server" class="check1 masterTooltip" ToolTip='<%# Bind("RD_CDESCRI") %>'  />
                                                                              </div>
                                                                        
                                                                      <asp:HiddenField ID="hfruc32" runat="server" />
                                                                         </ItemTemplate>

                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="P33">
                                                                <FooterTemplate>
                                                                        <asp:CheckBox ID="cbigv33" runat="server" Text="IGV"/>
                                                                        <br />
                                                                        <asp:DropDownList ID="ddltipooc33" runat="server">
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <div class ="check">
                                                                            <asp:DropDownList ID="ddlmoneda33"   class="moneda" runat="server"></asp:DropDownList>
                                                                             <asp:TextBox ID="txtprecio33"   class ="numeric" runat="server" Width="40"></asp:TextBox>
                                                                            <asp:CheckBox ID="cbsel33" runat="server" class="check1 masterTooltip" ToolTip='<%# Bind("RD_CDESCRI") %>'/>
                                                                            </div>
                                                                            
                                                                      <asp:HiddenField ID="hfruc33" runat="server" />
                                                                         </ItemTemplate>

                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="P34">
                                                                <FooterTemplate>
                                                                         <asp:CheckBox ID="cbigv34" runat="server" Text="IGV"/>
                                                                        <br />
                                                                        <asp:DropDownList ID="ddltipooc34" runat="server">
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                         <div class ="check">
                                                                             <asp:DropDownList ID="ddlmoneda34"   class="moneda" runat="server"></asp:DropDownList>
                                                                         <asp:TextBox ID="txtprecio34"   class ="numeric" runat="server" Width="40"></asp:TextBox>
                                                                         <asp:CheckBox ID="cbsel34" runat="server" class="check1 masterTooltip" ToolTip='<%# Bind("RD_CDESCRI") %>'/>
                                                                         </div>
                                                                            
                                                                           
                                                                      <asp:HiddenField ID="hfruc34" runat="server" />
                                                                         </ItemTemplate>

                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="P35">
                                                                <FooterTemplate>
                                                                         <asp:CheckBox ID="cbigv35" runat="server" Text="IGV"/>
                                                                        <br />
                                                                        <asp:DropDownList ID="ddltipooc35" runat="server">
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <div class ="check">
                                                                            <asp:DropDownList ID="ddlmoneda35"   class="moneda" runat="server"></asp:DropDownList>
                                                                           <asp:TextBox ID="txtprecio35"   class ="numeric"  runat="server" Width="40"></asp:TextBox>
                                                                <asp:CheckBox ID="cbsel35" runat="server" class="check1 masterTooltip" ToolTip='<%# Bind("RD_CDESCRI") %>'/>
                                                                            </div>
                                                                            
                                                                      <asp:HiddenField ID="hfruc35" runat="server" />
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
                                                <tr>
                                                    <td align="right">
                                                        <asp:Button ID="btnFinalizar" runat="server" OnClick="btnFinalizar_Click" Text="Finalizar" />
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
       <div class="EstadoPedido" Style="display:none">
           <table >
               
               <tr>
                   <td>
                       <asp:Label ID="lblcabnumero" runat="server" Text="Artículo:" Font-Bold="True" ></asp:Label>
                        <asp:Label ID="lblnumero" runat="server"  ></asp:Label>
                       <br />
                       <asp:GridView ID="gvdetallereq" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False">
                           <Columns>
                               <asp:BoundField DataField="OC_CCODPRO" HeaderText="RUC" HeaderStyle-HorizontalAlign="Left" >
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                               </asp:BoundField>
                                 <asp:BoundField DataField="OC_CRAZSOC" HeaderText="PROVEEDOR" HeaderStyle-HorizontalAlign="Left" >
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                               </asp:BoundField>
                                 <asp:BoundField DataField="OC_DFECDOC" HeaderText="FECHA" HeaderStyle-HorizontalAlign="Left" >
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                               </asp:BoundField>
                                <asp:BoundField DataField="OC_CCODMON" HeaderText="MONEDA" HeaderStyle-HorizontalAlign="Left" >
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                               </asp:BoundField>
                                   <asp:BoundField DataField="OC_NPREUN2" HeaderText="PRECIO" HeaderStyle-HorizontalAlign="Left"  >
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                               </asp:BoundField>
                               <asp:BoundField DataField="OC_CNUMORD" HeaderText="NRO O.C" HeaderStyle-HorizontalAlign="Left" >
                               
                               
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
      
       </asp:Content>


 












  

