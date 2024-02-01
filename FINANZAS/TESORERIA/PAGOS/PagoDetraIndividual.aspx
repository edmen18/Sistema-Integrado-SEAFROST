
<%@ Page Title="Programacion de Pagos" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="PagoDetraIndividual.aspx.cs" Inherits="FINANZAS_TESORERIA_PAGOS_PagoDetraIndividual" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link type="text/css" href="../../CSS/base.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {

            $('#Consulta').dialog({
                autoOpen: false,
                modal: true,
                resizable: true,
                width: 750,
                heigth: 100,
                title: 'Registro',
                close: function (event, ui) {
                    limpiar();
                },

            });

            $('#PagarComprobante').dialog({
                autoOpen: false,
                modal: true,
                resizable: true,
                width: 750,
                heigth: 500,
                title: 'Registro Pagos',
                close: function (event, ui) {
                   },

            });
            
            $('#Pagos').dialog({
                autoOpen: false,
                modal: true,
                resizable: true,
                width: 750,
                heigth: 100,
                title: 'Registro',
                close: function (event, ui) {

                },

            });


            $("#MainContent_txtfecha").datepicker();
            $('#Nuevo').dialog({
                autoOpen: false,
                modal: true,
                resizable: true,
                width: 1030,
                heigth: 100,
                title: 'Registro',
                close: function (event, ui) {
                    limpiardatos();
                },
            });                  

            $("#MainContent_txtdescripcion").autocomplete(
                   {                      
                       source: function (request, response) {
                           var VC = {};
                           VC.AC_CVANEXO = "P";
                           VC.AC_CCODIGO = $("#MainContent_txtdescripcion").val();
                           VC.AC_CNOMBRE = $("#MainContent_txtdescripcion").val();
                               $.ajax({
                                   url: "PagoDetraIndividual.aspx/listarautocomplete",
                                   data: '{VC: ' + JSON.stringify(VC) + '}',
                                   dataType: "json",
                                   type: "POST",
                                   contentType: "application/json; charset=utf-8",
                                   dataFilter: function (data) { return data; },
                                   success: function (data) {
                                       response($.map(data.d, function (item) {
                                           return {
                                               value: item.AC_CNOMBRE,
                                               id: item.AC_CCODIGO

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
                           $('#MainContent_txtcodigo').val(str);

                       }

                   });
            $(".Pagar").click(function () {
                $("#PagarComprobante").dialog('open');
            });

            function formato_numero(numero, decimales, separador_decimal, separador_miles) { // v2007-08-06
                numero = parseFloat(numero);
                if (isNaN(numero)) {
                    return "";
                }

                if (decimales !== undefined) {
                    // Redondeamos
                    numero = numero.toFixed(decimales);
                }

                // Convertimos el punto en separador_decimal
                numero = numero.toString().replace(".", separador_decimal !== undefined ? separador_decimal : ",");

                //if (separador_miles) {
                //    // Añadimos los separadores de miles
                //    var miles = new RegExp("(-?[0-9]+)([0-9]{3})");
                //    while (miles.test(numero)) {
                //        numero = numero.replace(miles, "$1" + separador_miles + "$2");
                //    }
                //}

                return numero;
            }


            $(".Pagos").click(function () {

                $("#Pagos").dialog('open');
                var VC = {};
                VC.CP_CNUMDOC = $('#MainContent_LBLFACTURA').html();
                VC.CP_CCODIGO = $('#MainContent_lblruc').html();
                $.ajax({
                    type: "POST",
                    url: "PagoDetraIndividual.aspx/PAGOS",
                    data: '{VC: ' + JSON.stringify(VC) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        if (data.d.length > 0) {
                            var row = $("[id*=gvordencompra0] tr:last-child").clone(true);
                            $("[id*=gvordencompra0] tr").not($("[id*=gvordencompra0] tr:first-child")).remove();
                         
                            for (var i = 0; i < data.d.length; i++) {
                           

                                $("td", row).eq(0).html((moment(data.d[i].PG_DFECCOM).format("DD/MM/YYYY")));
                                $("td", row).eq(1).html(data.d[i].PG_CCODMON);
                                $("td", row).eq(2).html(data.d[i].PG_CDEBHAB);
                                $("td", row).eq(3).html(data.d[i].PG_NIMPOMN);
                                $("td", row).eq(4).html(data.d[i].PG_NIMPOUS);
                                $("td", row).eq(5).html(data.d[i].PG_CSUBDIA);
                                $("td", row).eq(6).html(data.d[i].PG_CNUMCOM);
                                $("td", row).eq(7).html(data.d[i].PG_CGLOSA);
                                                                                              
                                $("[id*=gvordencompra0]").append(row);
                                row = $("[id*=gvordencompra0] tr:last-child").clone(true);
                            }
                        } else {
                            var row = $("[id*=gvordencompra0] tr:last-child").clone(true);
                            $("[id*=gvordencompra0] tr").not($("[id*=gvordencompra0] tr:first-child")).remove();

                            $("td", row).eq(0).html("");
                            $("td", row).eq(1).html("");
                            $("td", row).eq(2).html("");
                            $("td", row).eq(3).html("");

                            $("td", row).eq(4).html("");
                            $("td", row).eq(5).html("");
                            $("td", row).eq(6).html("");
                            $("td", row).eq(7).html("");
                          
                          
                            $("[id*=gvordencompra0]").append(row);
                            alert("no se encontro registro");
                        }


                    },
                    error: function (response) {
                        if (response.length != 0)
                            console.log(response);
                    }
                });

            });
            function limpiar() {
                $("#MainContent_lblruc").html("");

                $("#MainContent_LBLFACTURA").html("");
                $("#MainContent_lblcoddocumento").html("");
                $("#MainContent_lbldocumento").html("");
                $("#MainContent_lblfecha").html("");
                $("#MainContent_lblcodmoneda").html("");
                $("#MainContent_lblmoneda").html("");
                $("#MainContent_lblimporte").html("");
                $("#MainContent_lblsaldo").html("");
                    $("#MainContent_lblmoneda").html("");
                    $("#MainContent_lblimporte").html("");
                    $("#MainContent_lblsaldo").html("");
                $("#MainContent_lblcontabilizado").html("");
                $("#MainContent_lblcomprobante").html("");


                $("#MainContent_lblpago").html("SIN PROGRAMAR");
                $("#MainContent_lblproveedor").html("");
                $("#MainContent_lblmontodetraccion").html("");

                $("#MainContent_lbltipodetraccion").html("");
                $("#MainContent_lbldetracciondesc").html("");
                $("#MainContent_lbltasa").html("");
                $("#MainContent_lblobservacion").html("");
            }

            $(".Consultar").click(function () {

                $("#Consulta").dialog('open');
                             
                trp = $(this).parent().parent();
                id = $("td:eq(4)", trp).html();
                PROV=$("td:eq(0)", trp).html();
                var VC = {};
                VC.CP_CNUMDOC = id;
                VC.CP_CCODIGO = PROV;
                alert(id);
                              
                $.ajax({
                    type: "POST",
                    url: "PagoDetraIndividual.aspx/ConsultaReferencia",
                    data: '{adata: ' + JSON.stringify(VC) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {

                        //if (data.d.length > 0) {

                            for (var i = 0; i < data.d.length; i++) {
                                $("#MainContent_lblruc").html(data.d[i].CP_CCODIGO);
                               
                                $("#MainContent_LBLFACTURA").html(data.d[i].CP_CNUMDOC);
                                $("#MainContent_lblcoddocumento").html(data.d[i].CP_CTIPDOC);
                                $("#MainContent_lbldocumento").html(data.d[i].CP_CNUMDOC);
                                $("#MainContent_lblfecha").html((moment(data.d[i].CP_DFECDOC).format("DD/MM/YYYY")));
                              
                                

                                $("#MainContent_lblcodmoneda").html(data.d[i].CP_CCODMON);
                                if (data.d[i].CP_CCODMON == "MN") {
                                    $("#MainContent_lblmoneda").html("MONEDA NACIONAL");
                                    $("#MainContent_lblimporte").html(formato_numero(data.d[i].CP_NIMPOMN, 2, ".", ","));
                                    $("#MainContent_lblsaldo").html(formato_numero(data.d[i].CP_NSALDMN, 2, ".", ","));
                                }
                                else {
                                    $("#MainContent_lblmoneda").html("DOLARES");
                                    $("#MainContent_lblimporte").html(formato_numero(data.d[i].CP_NIMPOUS, 2, ".", ","));
                                    $("#MainContent_lblsaldo").html(formato_numero(data.d[i].CP_NSALDUS, 2, ".", ","));
                                }
                                $("#MainContent_lblcontabilizado").html(moment(data.d[i].CP_DFECCOM).format("DD/MM/YYYY"));
                                $("#MainContent_lblcomprobante").html(data.d[i].CP_CSUBDIA + "-" + data.d[i].CP_CCOMPRO);
                                
                            }                           
                        //}
                       
                     },
                    error: function (response) {
                        if (response.length != 0)
                            console.log(response);
                    }
                });
                consultadetracciones(id);

                                               
            });
            function consultadetracciones(id) {
               
                var VC = {};
                VC.CP_CNUMDOC = id
                VC.CP_CCODIGO= $("#MainContent_lblruc").html();
                var tasa = "";
                
                $.ajax({
                    type: "POST",
                    url: "PagoDetraIndividual.aspx/ConsultaDetracciones",
                    data: '{adata: ' + JSON.stringify(VC) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {

                        if (data.d.length > 0) {

                            for (var i = 0; i < data.d.length; i++) {
                               

                                $("#MainContent_lblpago").html("SIN PROGRAMAR");
                                $("#MainContent_lblproveedor").html(data.d[i].CP_CCODIGO);
                                $("#MainContent_lblmontodetraccion").html(formato_numero(data.d[i].CP_NSALDMN, 2, ".", ","));

                                $("#MainContent_lbltipodetraccion").html(data.d[i].CP_CTASDET);
                                $("#MainContent_lbldetracciondesc").html(data.d[i].CP_CAREA);
                                tasa = data.d[i].CP_CAREA.substring((data.d[i].CP_CAREA.length - 5));
                               
                                $("#MainContent_lbltasa").html(tasa);
                                $("#MainContent_lblobservacion").html("VENCIDO");
                                                             
                            }
                        }
                        else {
                            alert("no se encontro registro");
                        }
                    },
                    error: function (response) {
                        if (response.length != 0)
                            console.log(response);
                    }
                });
            }
                  
        });
    </script>
    <style type="text/css">
        #contenedor {
            width: 1120px;
        }

        #btnuevo {
            width: 75px;
        }
        .auto-style1 {
            width: 193px;
        }
        .auto-style2 {
            width: 112px;
        }
        .auto-style3 {
            width: 215px;
        }
        #btnpagar {
            width: 100px;
        }
        </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <%--<asp:ScriptManager ID="scriptManager" runat="server" EnablePageMethods="true" />--%>
    <div id="contenedor">
      <%--  <asp:HiddenField ID="hdUSUARIO" runat="server" />
        <asp:HiddenField ID="codM1" runat="server" />
        <asp:HiddenField ID="codM2" runat="server" />
        <asp:HiddenField ID="codM3" runat="server" />--%>
        <div id="Creacion" title="Creación">
           <table>
               <tr>
                   <td>Tipo Detracción</td>
                   <td>
                       <asp:DropDownList ID="ddldetraccion" runat="server" Height="16px" Width="207px"></asp:DropDownList>
                   </td>
                    <td>
                        <asp:Button ID="btnfiltro" runat="server" Text="Filtro" Width="120px" OnClick="btnfiltro_Click" />
                   </td>
                 
               </tr>
               <tr>
                    <td>Proveedor</td>
                   <td>
                       <asp:TextBox ID="txtcodigo" runat="server" Width="201px"></asp:TextBox>
                   </td>
                    <td>
                        <asp:TextBox ID="txtdescripcion" runat="server" Width="351px"></asp:TextBox>
                   </td>
               </tr>

           </table>
           
            <table>
                <tr>
                    <td>
                         <div style=" overflow: auto;width: 1200px; height: 480px">
                          <asp:GridView ID="gvordencompra" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" OnRowCreated="griddata_RowCreated" >
                    <Columns>
                        <asp:BoundField DataField="CP_CCODIGO" HeaderText="PROVEEDOR" />
                         <asp:BoundField DataField="CP_CSITUAC" HeaderText="PARTE Nº" />
                        <asp:BoundField DataField="CP_CCODIRF" HeaderText="ORDEN Nº" />
                        <asp:BoundField DataField="CP_CDESCRI" HeaderText="NOMBRE" />
                        <asp:BoundField DataField="CP_CTIPDOC" HeaderText="FACTURA" />
                        <asp:BoundField DataField="CP_CCODMON" HeaderText="MONEDA" />
                        <asp:BoundField DataField="CP_CNUMDOC" HeaderText="SALDO" />
                        <asp:BoundField DataField="CP_NSALDMN" HeaderText="DETRACCION" />
                        <asp:BoundField DataField="CP_CTASDET" HeaderText="TIPO" />
                        <asp:BoundField DataField="CP_DFECVEN" HeaderText="VENCE EL" />
                        <asp:BoundField DataField="CP_CAREA" HeaderText="ESTADO" />

                        <asp:TemplateField HeaderText="CONSULTAR">

                            <ItemTemplate>
                                <div class="Consultar" style="text-align: center">
                                    <img alt="" src="../../../Images/Message_Information.png" width="25" style="cursor: pointer" />
                                    <%--<asp:ImageButton ID="imbeliminar" runat="server" ImageUrl="~/Images/Message_Error.png" Width="25px" OnClick="ib_eliminar_Click" onclientclick="javascript:return confirm('Esta Seguro?')"/>--%>
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
                </div>

                    </td>
                </tr>
            </table>
           
        </div>
        <div id="Consulta">
             <table>
                 <tr>
                     <td class="auto-style1">DOCUMENTO DE REFERENCIA:</td>
                     <td>
                         <asp:Label ID="LBLFACTURA" runat="server" Text=""></asp:Label>
                     </td>
                 </tr>
                  </table>
             <table>
            <tr>
                <td class="auto-style2">Proveedor:</td>
                <td>
                    &nbsp;<asp:Label ID="lblruc" runat="server" Text=""></asp:Label></td>
                <td class="auto-style3">
                    <asp:Label ID="lblproveedor" runat="server" Text=""></asp:Label></td>

            </tr>
                 <tr>
                     <td class="auto-style2">Documento:</td>
                     <td>
                         <asp:Label ID="lblcoddocumento" runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                     <td class="auto-style3">
                         <asp:Label ID="lbldocumento" runat="server" Text=""></asp:Label></td>
                     <td>Fecha: </td>
                     <td>
                         <asp:Label ID="lblfecha" runat="server" Text=""></asp:Label></td>
                 </tr>
                 <tr>
                     <td class="auto-style2">Moneda:</td>
                     <td>
                         <asp:Label ID="lblcodmoneda" runat="server" Text=""></asp:Label></td>
                     <td class="auto-style3">
                         <asp:Label ID="lblmoneda" runat="server" Text=""></asp:Label></td>
                     <td>Importe:</td>
                     <td>
                         <asp:Label ID="lblimporte" runat="server" Text=""></asp:Label></td>
                 </tr>
                 <tr>
                     <td class="auto-style2">Saldo:</td>
                     <td>
                         <asp:Label ID="lblsaldo" runat="server" Text=""></asp:Label></td>
                 </tr>
                 <tr>
                     <td class="auto-style2">Contabilizado:</td>
                     <td>
                         <asp:Label ID="lblcontabilizado" runat="server" Text=""></asp:Label></td>
                     <td class="auto-style3">Comprobante:</td>
                     <td>
                         &nbsp;&nbsp;
                         <asp:Label ID="lblcomprobante" runat="server" Text="Label"></asp:Label>
                     </td>
                 </tr>
                 <tr>
                     <td class="auto-style2">Pago Programado:</td>
                     <td>
                         <asp:Label ID="lblpago" runat="server" Text=""></asp:Label></td>
                     <td class="auto-style3">
                         <input id="Button1" type="button" value="Consultar Pago" class="Pagos" /></td>
                 </tr>
             </table>
            <table>
                <tr>
                    <td>DETRACCIÓN</td>
                </tr>
                <tr>
                    <td>Monto detracción:</td>
                    <td>
                        <asp:Label ID="lblmontodetraccion" runat="server" Text=""></asp:Label></td>
                   </tr>
                <tr>
                    <td>Tipo Detracción:</td>
                    <td>
                        <asp:Label ID="lbltipodetraccion" runat="server" Text=""></asp:Label></td>
                    <td>
                        <asp:Label ID="lbldetracciondesc" runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                    <td>Tasa</td>
                    <td>
                        <asp:Label ID="lbltasa" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>Observación:</td>
                    <td>
                        <asp:Label ID="lblobservacion" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <input id="btnpagar" type="button" value="Pagar" class="Pagar" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="Pagos">
            <table>
                <tr>
                    <td>

                          <asp:GridView ID="gvordencompra0" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" OnRowCreated="griddata_RowCreated" >
                    <Columns>
                        <asp:BoundField DataField="PG_DFECCOM" HeaderText="Fech. Comp." />
                        <asp:BoundField DataField="PG_CCODMON" HeaderText="Mo." />
                        <asp:BoundField DataField="PG_CDEBHAB" HeaderText="D/H" />
                        <asp:BoundField DataField="PG_NIMPOMN" HeaderText="Importe MN" />
                        <asp:BoundField DataField="PG_NIMPOUS" HeaderText="Importe US." />
                        <asp:BoundField DataField="PG_CSUBDIA" HeaderText="SubDia" />
                        <asp:BoundField DataField="PG_CNUMCOM" HeaderText="Comprobante" />

                        <asp:BoundField DataField="PG_CGLOSA" HeaderText="Referencia" />

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
        <div id="PagarComprobante">
            <table title="DATOS GENERALES" >
                <tr>
                <td> Proveedor </td>
                    <td>
                        <asp:Label ID="lblproveedorp" runat="server" Text=""></asp:Label> </td>
                </tr>
                <tr>
                <td> Factura </td>
                    <td>
                        <asp:Label ID="lblfacturap" runat="server" Text=""></asp:Label> </td>
                 <td>Fecha Emisión </td>
                    <td>
                        <asp:Label ID="lblfechaemisionp" runat="server" Text=""></asp:Label> </td>
                </tr>
                <tr>
                <td>Importe Factura </td>
                    <td>
                        <asp:Label ID="lblimportefacturap" runat="server" Text=""></asp:Label> </td>
                 <td>Moneda </td>
                    <td>
                        <asp:Label ID="lblmonedap" runat="server" Text=""></asp:Label> </td>
                </tr>
                <tr>
                <td>Tipo Detracción </td>
                    <td>
                        <asp:Label ID="lbltipodetraccionp" runat="server" Text=""></asp:Label> </td>
                   <td>
                        <asp:Label ID="lbldetraccion" runat="server" Text=""></asp:Label> </td>
                </tr>
                <tr>
                <td> Monto detraccion S/. </td>
                    <td>
                        <asp:Label ID="lblmontodetraccionSP" runat="server" Text=""></asp:Label> </td>
                 <td>Monto Detracción US$ </td>
                    <td>
                        <asp:Label ID="lblmontodetraccionUP" runat="server" Text=""></asp:Label> </td>
                </tr>
                
            </table>
            <table>
                <tr>
                    <td>Número de Operación</td> <td> <asp:TextBox ID="txtnumerooperacion" runat="server" Width="217px"></asp:TextBox> </td>
                    
                </tr>
                <tr>
                    <td>Número de Constancia</td> <td>  <asp:TextBox ID="txtconstancia" runat="server" Width="218px"></asp:TextBox> </td>
                    <td>Fecha Constancia</td> <td>  <asp:TextBox ID="txtfechaconstancia" runat="server"></asp:TextBox> </td>
                </tr>
                 <tr>
                    <td>Tipo de Pago</td> <td> <asp:DropDownList ID="ddltipopago" runat="server" Height="17px" Width="219px"></asp:DropDownList>  </td>
                    <td>Fecha Pago</td> <td>  <asp:TextBox ID="txtfechapago" runat="server"></asp:TextBox> </td>
                </tr>

                <tr>
                     <td>Banco</td> <td>  <asp:TextBox ID="txtcodbanco" runat="server" Height="16px" Width="217px"></asp:TextBox> </td>
                     <td>  <asp:TextBox ID="txtbanco" runat="server"></asp:TextBox> </td>
                </tr>
                <tr>
                    <td>Moneda</td> <td> <asp:DropDownList ID="ddlmoneda" runat="server" Height="21px" Width="222px"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>Cuenta Caja</td> <td> <asp:DropDownList ID="ddlcuentacaja" runat="server" Height="16px" Width="224px"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>Anexo</td> <td> <asp:TextBox ID="txtcodanexo" runat="server" Width="221px"></asp:TextBox></td> <td> <asp:TextBox ID="txtanexo" runat="server" Width="117px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Tipo Cambio</td> <td><asp:TextBox ID="txttipocambio" runat="server" Width="221px"></asp:TextBox></td>
                    <td>radio butoon</td>
                </tr>
                <tr> <td>Area</td> <td> <asp:DropDownList ID="ddlarea" runat="server" Height="16px" Width="219px"></asp:DropDownList> </td> </tr>
                <tr> <td>Medio de Pago Tributario</td> <td><asp:DropDownList ID="ddlmediopago" runat="server"></asp:DropDownList> </td></tr>
                <tr> <td>Subdiario</td> <td><asp:DropDownList ID="ddlsubdiario" runat="server"></asp:DropDownList> </td></tr>
            </table>


        </div>

    </div>
    <br />
</asp:Content>