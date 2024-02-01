<%@ Page Title="Aprobación de Programación" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ConsultaDetraccionesPorPagar.aspx.cs" Inherits="FINANZAS_TESORERIA_PAGOS_ConsultaDetraccionesPorPagar" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link type="text/css" href="../../../CSS/base.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {

            UHTML.id = 'MainContent';
            mi_detalle = [], dcuentas = [];
            M_ARRAY = [];
            var iniciaPGE = function (CO) {
                    var PDATA = {};
                    PDATA.AF_COD = CO;
                    $.ajax({
                        type: "POST",
                        url: "ConsultaDetraccionesPorPagar.aspx/getPARAM",
                        data: '{ PDATA: ' + JSON.stringify(PDATA) + '}',
                        contentType: "application/json;charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (data) {
                            //console.log(data);
                            if (data.d.length > 0) {
                                jQuery.each(data.d, function (i, v) {
                                    M_ARRAY.push(v.AF_CCLAVE.trim());
                                });
                            } else {
                                //
                            }

                        },
                        error: function (response) {
                            console.table(response);
                        }
                    });

                }
             
                iniciaPGE("AD");
                console.log(M_ARRAY);
          
                Operacion.mask('lblcuenta').text(M_ARRAY[0]);
          

            $("#MainContent_txtproveedor").autocomplete(
                  {
                      source: function (request, response) {
                          $.ajax({
                              url: "ConsultaDetraccionesPorPagar.aspx/GetProveedores",
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
                          $('#MainContent_txtruc').val(str);


                      }
                  });



            Operacion.mask('txttipodetraccion').change(function () {
                Operacion.oACD('txttipodetraccion');
                if ($(this).val() == "99999") {
                    //Operacion.mask('txtdetrar').val($(this).val());
                    Operacion.mask('txtdetraccion').val('Todos');
                } else {
                    $("#MainContent_txttipodetraccion").autocomplete(
                          {
                              source: function (request, response) {
                                  $.ajax({
                                      url: "ConsultaDetraccionesPorPagar.aspx/LISTARdetracciones",
                                      data: "{ 'productos': '" + request.term + "' }",
                                      dataType: "json",
                                      type: "POST",
                                      contentType: "application/json; charset=utf-8",
                                      dataFilter: function (data) { return data; },
                                      success: function (data) {
                                          if (data.d.length == 0) {
                                              if (request.term == "99999") {
                                                  return {
                                                      id: "Todos",
                                                      value: "99999"
                                                  };
                                              }
                                          }
                                          else {
                                              response($.map(data.d, function (item) {
                                                  return {
                                                      id: item.TDESCRI,
                                                      value: item.TCLAVE
                                                  }
                                              }))
                                          }

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
                                  $('#MainContent_txtdetraccion').val(str);
                              }
                          });
                }
            });

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
            $(".Consultar").click(function () {

                $("#Consulta").dialog('open');

                trp = $(this).parent().parent();
                id = $("td:eq(2)", trp).html();
                PROV = $("td:eq(0)", trp).html();
                var VC = {};
                VC.CP_CNUMDOC = id.substr(3,id.length);
                VC.CP_CCODIGO = PROV;
                alert(id);

                $.ajax({
                    type: "POST",
                    url: "ConsultaDetraccionesPorPagar.aspx/ConsultaReferencia",
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
            function consultadetracciones(id) {

                var VC = {};
                VC.CP_CNUMDOC = id.substr(3, id.length);
                VC.CP_CCODIGO = $("#MainContent_lblruc").html();
                var tasa = "";

                $.ajax({
                    type: "POST",
                    url: "ConsultaDetraccionesPorPagar.aspx/ConsultaDetracciones",
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

        });
    </script>
    <style type="text/css">
        #contenedor {
            width: 1120px;
        }

        #btninconsistencias {
            width: 96px;
        }

        .auto-style1 {
            width: 80px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="contenedor">
        <div id="Creacion" title="Creación">

            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblusuario" runat="server" ForeColor="#f1f1f1"></asp:Label>
                    </td>

                </tr>
               <%-- <tr>
                    <td>Tipo Detracción:  </td>
                    <td>
                        <asp:TextBox ID="txttipodetraccion" runat="server" Width="100px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtdetraccion" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>--%>
                <tr>
                    <td>Proveedor:  </td>
                    <td>
                        <asp:TextBox ID="txtruc" runat="server"  Width="100px"></asp:TextBox> </td>
                    <td>
                        <asp:TextBox ID="txtproveedor" runat="server" Width="300px"></asp:TextBox>
                        <asp:Label ID="lblcuenta" runat="server" ForeColor="White"></asp:Label>
                    </td>
                </tr>
            </table>
            <table>
            
<tr>
    <td>
        <asp:Button ID="btnfiltro" runat="server" Text="Filtro" Width="103px" OnClick="btnfiltro_Click" />
    </td>
</tr>
            </table>
            <table>
                <tr>
                    <td>
                         <div style="overflow: auto; width: 100%; height: 500px">
                        <asp:GridView ID="gvordencompra" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" OnRowCreated="griddata_RowCreated" Width="877px" Font-Size="X-Small">
                            <Columns>
                                <asp:BoundField DataField="CP_CCODIGO" HeaderText="PROVEEDOR" />
                                <asp:BoundField DataField="CP_CDESCRI" HeaderText="NOMBRE" />
                                <asp:BoundField DataField="CP_CNUMDOC" HeaderText="FACTURA">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CP_CCODMON" HeaderText="MONEDA" />
                                <asp:BoundField DataField="CP_NSALDUS" HeaderText="SALDO" />
                                <asp:BoundField DataField="CP_NSALDMN" HeaderText="DETRACCION" />

                                <asp:BoundField DataField="CP_CTASDET" HeaderText="TIPO">
                                </asp:BoundField>
                                <asp:BoundField DataField="CP_CNDOCCO" HeaderText="VENCE">

                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>

                                <asp:BoundField HeaderText="ESTADO" DataField="CP_CTIPO" />

                                <asp:TemplateField HeaderText="CONSULTAR">

                                    <ItemTemplate>
                                        <div class="Consultar" style="text-align: center">
                                            <img alt="" src="../../../Images/Detalle.png" width="25" style="cursor: pointer" />
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
       
    </div>
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
                    <asp:Label ID="lblruc" runat="server" BorderStyle="Outset"></asp:Label></td>
                <td class="auto-style3">
                    <asp:Label ID="lblproveedor" runat="server" BorderStyle="Outset"></asp:Label></td>

            </tr>
                 <tr>
                     <td class="auto-style2">Documento:</td>
                     <td>
                         <asp:Label ID="lblcoddocumento" runat="server" BorderStyle="Outset"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                     <td class="auto-style3">
                         <asp:Label ID="lbldocumento" runat="server" BorderStyle="Outset"></asp:Label></td>
                     <td>Fecha: </td>
                     <td>
                         <asp:Label ID="lblfecha" runat="server" BorderStyle="Outset"></asp:Label></td>
                 </tr>
                 <tr>
                     <td class="auto-style2">Moneda:</td>
                     <td>
                         <asp:Label ID="lblcodmoneda" runat="server" BorderStyle="Outset"></asp:Label></td>
                     <td class="auto-style3">
                         <asp:Label ID="lblmoneda" runat="server" BorderStyle="Outset"></asp:Label></td>
                     <td>Importe:</td>
                     <td>
                         <asp:Label ID="lblimporte" runat="server" BorderStyle="Outset"></asp:Label></td>
                 </tr>
                 <tr>
                     <td class="auto-style2">Saldo:</td>
                     <td>
                         <asp:Label ID="lblsaldo" runat="server" BorderStyle="Outset"></asp:Label></td>
                 </tr>
                 <tr>
                     <td class="auto-style2">Contabilizado:</td>
                     <td>
                         <asp:Label ID="lblcontabilizado" runat="server" BorderStyle="Outset"></asp:Label></td>
                     <td class="auto-style3">Comprobante:</td>
                     <td>
                         &nbsp;&nbsp;
                         <asp:Label ID="lblcomprobante" runat="server" Text="Label" BorderStyle="Outset"></asp:Label>
                     </td>
                 </tr>
                 <tr>
                     <td class="auto-style2">Pago Programado:</td>
                     <td>
                         <asp:Label ID="lblpago" runat="server" BorderStyle="Outset"></asp:Label></td>
                     <td class="auto-style3">
                         &nbsp;</td>
                 </tr>
             </table>
            <table>
                <tr>
                    <td>DETRACCIÓN</td>
                </tr>
                <tr>
                    <td>Monto detracción:</td>
                    <td>
                        <asp:Label ID="lblmontodetraccion" runat="server" BorderStyle="Outset"></asp:Label></td>
                   </tr>
                <tr>
                    <td>Tipo Detracción:</td>
                    <td>
                        <asp:Label ID="lbltipodetraccion" runat="server" BorderStyle="Outset"></asp:Label></td>
                    <td>
                        <asp:Label ID="lbldetracciondesc" runat="server" BorderStyle="Outset"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                    <td>Tasa</td>
                    <td>
                        <asp:Label ID="lbltasa" runat="server" BorderStyle="Outset"></asp:Label></td>
                </tr>
                <tr>
                    <td>Observación:</td>
                    <td>
                        <asp:Label ID="lblobservacion" runat="server" BorderStyle="Outset"></asp:Label></td>
                </tr>
               
            </table>
        </div>

</asp:Content>

