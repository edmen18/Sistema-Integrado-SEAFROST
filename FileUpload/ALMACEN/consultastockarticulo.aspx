<%@ Page Title="Logística" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="consultastockarticulo.aspx.cs" Inherits="consultastockarticulo" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link type="text/css" href="../CSS/base.css" rel="stylesheet" />
     <script type="text/javascript">

         $(function () {
             var myRow;

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

                 },
                 buttons: {
                     "GRABAR": function () {
                         grabaStockMinimo();
                         $(this).dialog("close");
                     }
                 }


             });

             $('.EstadoPedido1').dialog({
                 autoOpen: false,
                 modal: true,
                 resizable: false,
                 width: 600,
                 heigth: 250,
                 title: 'STOCK MINIMO',
                 open: function (event, ui) {

                 },
                 close: function (event, ui) {

                 }


             });

             $(".ver").click(function () {
                     trp = $(this).parent().parent();
                     articulo = $("td:eq(0)", trp).html();
                    articulo1 = $("td:eq(1)", trp).html();
                   alma=$("#MainContent_ddlalmacen").val();
                  $("#MainContent_lblnumero1").text(articulo1);
                     filtarcantidademb(articulo, alma);
                     $('.EstadoPedido1').dialog('open');
                 });








                 $(".editar").click(function () {
                     trp = $(this).parent().parent();
                     articulo = $("td:eq(0)", trp).html();
                     articulo1 = $("td:eq(1)", trp).html();

                     articulo2 = $("td:eq(4)", trp).html();
                     articulo3 = $("td:eq(5)", trp).html();

                     $("#MainContent_txtminimo").val(articulo2);
                     $("#MainContent_txteoq").val(articulo3);
                     
                     $("#MainContent_lblcodigo").text(articulo);

                     alma = $("#MainContent_ddlalmacen").val();
                     $("#MainContent_lblnumero").text(articulo1);
                  //   filtarcantidademb(articulo, alma);
                     $('.EstadoPedido').dialog('open');

                     dtr = $(this).closest('tr');
                     myRow = dtr.index() +1;

                     //dtr1 = $(this).closest('td');
                     //mycol = dtr1.index();

                  //   alert(myRow);
                     //alert(mycol);

                 });

                 function grabaStockMinimo() {
                     codigo = $("#MainContent_lblcodigo").text();
                     minimo = $("#MainContent_txtminimo").val();
                     eoq = $("#MainContent_txteoq").val();
                     alma = $("#MainContent_ddlalmacen").val();

                     var ARTI = {};
                     ARTI.AR_CCODIGO = codigo;
                     ARTI.AR_NMARGE1 = minimo;
                     ARTI.AR_NMARGE2 = eoq;
                     ARTI.AR_CCATALO = alma;
                   //  alert(myRow);
                     $.ajax({

                         type: "POST",
                         url: "consultastockarticulo.aspx/actualizaStockMinimo",
                         data: '{ARTI: ' + JSON.stringify(ARTI) + '}',
                         contentType: "application/json; charset=utf-8",
                         async: false,

                         dataType: "json",
                         success: function (data) {

                             //  if (data.d.length > 0) {


                             //alert(myRow);

                             $("#MainContent_gvRequerimientos tr:nth-child(" + (myRow) + ") td:nth-child(5)").html(minimo);
                             $("#MainContent_gvRequerimientos tr:nth-child(" + (myRow) + ") td:nth-child(6)").html(eoq);


                             //var row = $("[id*=gvRequerimientos] tr:last-child").clone(true);
                             //$("[id*=gvRequerimientos] tr").not($("[id*=gvRequerimientos] tr:first-child")).remove();

                             //for (var i = 0; i < data.d.length; i++) {

                             //var dat = data.d[i].SR_DFECVEN;
                             //console.log(dat);
                             //var fech = (dat == null ? "" : moment(dat).format('DD/MM/YYYY'))

                             //$("td", row).eq(0).html("XXXXX");
                             //$("td", row).eq(1).html(data.d[i].SR_CSERIE);
                             //$("td", row).eq(2).html(parseFloat(data.d[i].SR_NSKDIS).toFixed(2));
                             //$("td", row).eq(3).html(fech);


                             //$("[id*=gvRequerimientos]").append(row);
                             //row = $("[id*=gvRequerimientos] tr:last-child").clone(true);

                             //    }
                             //} else {
                             //    var row = $("[id*=gvdetallereq] tr:last-child").clone(true);
                             //    $("[id*=gvdetallereq] tr").not($("[id*=gvdetallereq] tr:first-child")).remove();

                             //    $("td", row).eq(0).html("");
                             //    $("td", row).eq(1).html("");
                             //    $("td", row).eq(2).html("");
                             //    $("td", row).eq(3).html("");



                             //    $("[id*=gvdetallereq]").append(row);
                             //    //alert("no se encontro registro");
                             //}


                         },
                         error: function (response) {
                             if (response.length != 0)
                                 alert(response);
                         }
                     });

                 }

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
                         //    alert("hola");
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
         </style>
</asp:Content>
   <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
         <asp:ScriptManager ID="scriptManager" runat="server" EnablePageMethods="true" />
       <div id="contenedor" style="width:990px">
    <table width="100%" cellpadding="5" cellspacing="5" border="0">
       
        <tr>
            <td>
                 <fieldset >
   <legend  > <asp:Label ID="Label9" runat="server" Text="CONSULTA STOCK DE ARTICULOS" Font-Bold="True" Font-Size="12pt"></asp:Label></legend>

                <table class="ContainerWrapper" border="0" cellpadding="2" cellspacing="0" style="width:800px">
                    
                    <tr>
                        <td  >

                            <table style="width: 900px" >
                                <tr>
                                                <td >
                                                    <asp:Label ID="lblAlmacen" runat="server" Text="Almacén:" Font-Bold="True"></asp:Label>
                                 
                                               
                                                    <asp:DropDownList ID="ddlalmacen" runat="server"></asp:DropDownList>

                                                    <asp:Label ID="Label6" runat="server" Text="Listar Por:" Font-Bold="True"></asp:Label>
                                 
                                               
                                                    <asp:DropDownList ID="ddlmes" runat="server"></asp:DropDownList>

                                                    <br />  <br />
                                                     <asp:Label ID="Label15" runat="server" Text="Producto:" Font-Bold="True"></asp:Label>
                                       
                                                     <asp:TextBox ID="txtproducto" class="tb" runat="server" Width="350px"></asp:TextBox>
                                                     <asp:TextBox ID="txtarticulo" runat="server" Width="180px" AutoPostBack="True" OnTextChanged="txtarticulo_TextChanged"></asp:TextBox>
                                                     <asp:HiddenField ID="hfproducto" runat="server" />  
                                                    
                                                    <hr />
                                                    
                                                    <asp:Button ID="btnBuscar" class="btn" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                    
                                                     &nbsp;&nbsp;&nbsp;&nbsp;
                                                    </td>
                                               
                                            </tr>
                               
                              
                               
                            </table>
                            
                           
                           
                            
                           </td>
                    </tr>

                 

                  
                
                
                
                </table>
                     <table >
                         <tr>
                             <td>
                                 <asp:GridView ID="gvRequerimientos" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False">
                                     <Columns>
                                         <asp:BoundField DataField="SK_CCODIGO" HeaderText="CODIGO" />
                                         <asp:BoundField DataField="AR_CDESCRI" HeaderText="ARTICULO" />
                                         <asp:BoundField DataField="AR_CUNIDAD" HeaderText="UNIDAD" />
                                         <asp:BoundField DataField="SK_NSKDIS" HeaderText="CANTIDAD" />

                                            <asp:BoundField DataField="AR_NMARGE1" HeaderText="STOCK MINIMO" />
                                         <asp:BoundField DataField="AR_NMARGE2" HeaderText="EOQ" />

                                            <asp:TemplateField HeaderText="SERIE">
                                                                <ItemTemplate>
                                                                   <div class ="ver">
                                                      <img alt="" src="../Images/Message_Information.png" width="20" style="cursor:pointer"/>
                                                                       
                                                 </div>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                              <asp:TemplateField HeaderText="EDITAR">
                                                                <ItemTemplate>
                                                                   <div class ="editar">
                                                      <img alt="" src="../Images/edit.png" width="20" style="cursor:pointer"/>
                                                                       
                                                 </div>
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
                      
                     <div class="EstadoPedido" Style="display:none">
           <table >
               
               <tr>
                   <td>
                        <asp:Label ID="lblcabcodigo" runat="server" Text="Artículo:" Font-Bold="True" ></asp:Label>
                        <asp:Label ID="lblcodigo" runat="server"  ></asp:Label>
                        <br />
                       <asp:Label ID="lblcabnumero" runat="server" Text="Artículo:" Font-Bold="True" ></asp:Label>
                        <asp:Label ID="lblnumero" runat="server"  ></asp:Label>
                       <br />
                         <asp:Label ID="Label1" runat="server" Text="Stock Minimo:" Font-Bold="True"></asp:Label>
                                       
                                                     <asp:TextBox ID="txtminimo" runat="server" Width="350px"></asp:TextBox>
                       <br />
                         <asp:Label ID="Label2" runat="server" Text="EOQ:" Font-Bold="True"></asp:Label>
                                       
                                                     <asp:TextBox ID="txteoq"  runat="server" Width="350px"></asp:TextBox>
                   </td>
               </tr>
           </table>
       </div>

                     <div class="EstadoPedido1" Style="display:none">
           <table >
               
               <tr>
                   <td>
                       <asp:Label ID="Label3" runat="server" Text="Artículo:" Font-Bold="True" ></asp:Label>
                        <asp:Label ID="lblnumero1" runat="server"  ></asp:Label>
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


 












  

