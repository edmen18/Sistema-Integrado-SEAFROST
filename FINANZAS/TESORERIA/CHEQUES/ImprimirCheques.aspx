
<%@ Page Title="Impresión de Comprobante Cheques" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ImprimirCheques.aspx.cs" Inherits="FINANZAS_TESORERIA_CHEQUES_ImprimirCheques" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link type="text/css" href="../../../CSS/base.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {
            UHTML.id = 'MainContent';

            $("#MainContent_txtbancor").autocomplete(
     {
         source: function (request, response) {
             $.ajax({
                 url: "ImprimirCheques.aspx/ListarBancosProg",
                 data: "{ 'productos': '" + request.term + "' }",
                 dataType: "json",
                 type: "POST",
                 contentType: "application/json; charset=utf-8",
                 dataFilter: function (data) { return data; },
                 success: function (data) {
                     response($.map(data.d, function (item) {
                         return {
                             id: item.CT_CDESCTA,
                             value: item.CT_CNUMCTA,
                             v: item.CT_CCODMON,
                             b: item.CT_CCUENTA,
                         }
                     }))
                 },
                 error: function (XMLHttpRequest, textStatus, errorThrown) {
                 }
             });
         },
         minLength: 1,
         select: function (event, ui) {
             var str = ui.item.id;
             var cadena = str;
             posicionEspacio = cadena.indexOf("@"), //Obtengo la posición del espacio en la cadena
             primerApellido = cadena.substring(0, posicionEspacio) //Obtengo la porción deseada de la cadena
             enMinuscula = primerApellido.toLowerCase(); //Convierto el apellido a minúscula
             primerApellido = cadena.substring(posicionEspacio + 1, str.length)
             $('#MainContent_lblbancor').val(str);
             $('#MainContent_txtmoneda').val(ui.item.v);
             $('#MainContent_txtcuentabanco').val(ui.item.b);
            
         }
     });


            $("#MainContent_lblbancor").autocomplete(
     {
         source: function (request, response) {
             $.ajax({
                 url: "ImprimirCheques.aspx/ListarBancosProg",
                 data: "{ 'productos': '" + request.term + "' }",
                 dataType: "json",
                 type: "POST",
                 contentType: "application/json; charset=utf-8",
                 dataFilter: function (data) { return data; },
                 success: function (data) {
                     response($.map(data.d, function (item) {
                         return {
                             id: item.CT_CNUMCTA,
                             value: item.CT_CDESCTA,
                             v: item.CT_CCODMON,
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
             $('#MainContent_txtbancor').val(str);
             $('#MainContent_txtmoneda').val(ui.item.v);
            
         }
     });
            $(".imprimir").click(function () {
                trp = $(this).parent().parent();
                SUBDIA = $("td:eq(0)", trp).html();
                COMPRO = $("td:eq(1)", trp).html();
                CHEQUE = $("td:eq(2)", trp).html();
               if (CHEQUE !="&nbsp;") {
                     window.open("../CHEQUES/ImprimeCheque.aspx?SUB= " + CHEQUE + "&COM=" + SUBDIA + "&COMPROBANTE=" + COMPRO, '_blank');
                }
                else {
                    alert("El cheque esta anulado");
               }
            });

            $(".filtrar").click(function () {
                filtrardetalles()
            });

            function filtrardetalles() {
                var COM = {};                   
                COM.CH_CNUMCHE = Operacion.mask('txtchequeinicial').val();
                COM.CH_CNOMCHE =  Operacion.mask('txtchequefinal').val();
                COM.CH_CSUBDIA ="23";
                COM.CH_CNUMCTA = Operacion.mask('txtbancor').val();
                $.ajax({

                    type: "POST",
                    url: "ImprimirCheques.aspx/ConsultaChequeParametros",
                    data: '{COM: ' + JSON.stringify(COM) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {

                        if (data.d.length > 0) {
                            var row = $("[id*=gvcomprobantes] tr:last-child").clone(true);
                            $("[id*=gvcomprobantes] tr").not($("[id*=gvcomprobantes] tr:first-child")).remove();

                            for (var i = 0; i < data.d.length; i++) {
                                $("td", row).eq(0).html(data.d[i].CH_CSUBDIA);
                                $("td", row).eq(1).html(data.d[i].CH_CNUMCOM);
                                $("td", row).eq(2).html(data.d[i].CH_CNUMCHE);
                                $("td", row).eq(3).html((moment(data.d[i].CH_DFECHA).format("DD/MM/YYYY")));
                                $("td", row).eq(4).html(data.d[i].CH_CCODMON);
                                $("td", row).eq(5).html(data.d[i].CH_NIMPOCH);                              
                                $("td", row).eq(6).html(data.d[i].CH_CNOMCHE);

                                $("[id*=gvcomprobantes]").append(row);
                                row = $("[id*=gvcomprobantes] tr:last-child").clone(true);
                            }
                        } else {
                            var row = $("[id*=gvcomprobantes] tr:last-child").clone(true);
                            $("[id*=gvcomprobantes] tr").not($("[id*=gvcomprobantes] tr:first-child")).remove();

                            $("td", row).eq(1).html("");
                            $("td", row).eq(2).html("");
                            $("td", row).eq(3).html("");
                            $("td", row).eq(4).html("");
                            $("td", row).eq(5).html("");
                            $("td", row).eq(6).html("");
                            $("td", row).eq(0).html("");
                            $("[id*=gvcomprobantes]").append(row);
                            alert("no se encontro registro");
                        }


                    },
                    error: function (response) {
                        if (response.length != 0)
                            alert(response);
                    }
                });
            }
            function filtrartodos() {
                var COM = {};
                COM.CH_CSUBDIA = "23";
                  $.ajax({

                    type: "POST",
                    url: "ImprimirCheques.aspx/DETALLE",
                    data: '{CODATA: ' + JSON.stringify(COM) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {

                        if (data.d.length > 0) {
                            var row = $("[id*=gvcomprobantes] tr:last-child").clone(true);
                            $("[id*=gvcomprobantes] tr").not($("[id*=gvcomprobantes] tr:first-child")).remove();

                            for (var i = 0; i < data.d.length; i++) {
                                $("td", row).eq(0).html(data.d[i].CSUBDIA);
                                $("td", row).eq(1).html(data.d[i].CCOMPRO);
                                $("td", row).eq(2).html(data.d[i].CMEMO);
                                $("td", row).eq(3).html(moment(data.d[i].CDATE, "DD/MM/YYYY"));
                                $("td", row).eq(4).html(data.d[i].CCODMON);
                                $("td", row).eq(5).html(data.d[i].CTOTAL);
                                $("td", row).eq(6).html(data.d[i].CGLOSA);

                                $("[id*=gvcomprobantes]").append(row);
                                row = $("[id*=gvcomprobantes] tr:last-child").clone(true);
                            }
                        } else {
                            var row = $("[id*=gvcomprobantes] tr:last-child").clone(true);
                            $("[id*=gvcomprobantes] tr").not($("[id*=gvcomprobantes] tr:first-child")).remove();

                            $("td", row).eq(1).html("");
                            $("td", row).eq(2).html("");
                            $("td", row).eq(3).html("");
                            $("td", row).eq(4).html("");
                            $("td", row).eq(5).html("");
                            $("td", row).eq(6).html("");
                            $("td", row).eq(0).html("");
                            $("[id*=gvcomprobantes]").append(row);
                            alert("no se encontro registro");
                        }


                    },
                    error: function (response) {
                        if (response.length != 0)
                            console.log(response);
                    }
                });
            }
            $(window).load(function () {
          
               // filtrartodos();
            });

              });

         </script>
    <style type="text/css">
        #btnactualizar {
            width: 69px;
        }
        #btnact {
            width: 146px;
        }
        #btnsalir {
            width: 58px;
        }
        #btnadicionales {
            width: 115px;
        }
        #btnfinalizar {
            width: 31px;
        }
        .seleciona {}
    </style>
    </asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="contenedor">
      <div id="Creacion" title="Creación">
          <TABLE>
              <tr>
                
                  <td>
                      &nbsp;</td>
                  <td>
                      <asp:Label ID="lblcuentapago" runat="server" Text="" style="display:none"></asp:Label>
                      <asp:Label ID="lblusuario" runat="server" Text="" style="display:none"></asp:Label>
                  </td>
                  <td>
                      <asp:Label ID="lblcuentaretencion" runat="server" Text="" style="display:none"></asp:Label>
                  </td>
              </tr>
          </TABLE>
          <table>
              <tr>
                  <td>Nro. de Cuenta Bancaria&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                   <td>
                       <asp:TextBox ID="txtbancor" runat="server" Width="175px"></asp:TextBox>
                       </td>
                  <td>
                        <asp:TextBox ID="lblbancor" runat="server" Width="434px"></asp:TextBox>
                    </td>
                 
              </tr>
              <tr>
                  <td>
                      Moneda
                  </td>
                  <td>
                       <asp:TextBox ID="txtmoneda" runat="server" Width="175px" ReadOnly="true"></asp:TextBox>
                       <asp:Label ID="Label1" runat="server" BorderStyle="None" style="display:none"></asp:Label>
                  </td>
                  </tr>
         
              <tr> <td>Cheque Inicial</td> <td>  <asp:TextBox ID="txtchequeinicial" runat="server" Width="175px" ReadOnly="false"></asp:TextBox></td> </tr>
               <tr> <td>Cheque Final</td> <td>  <asp:TextBox ID="txtchequefinal" runat="server" Width="175px" ReadOnly="false"></asp:TextBox></td>
                   <td>
              &nbsp;<input id="btnfiltrat" type="button" value="Filtrar" class="filtrar" />
              </td>
               </tr>
          
          </table>
   
            <table>
                <tr>
                    <td>
                        <div style="overflow: auto; width: 850px; height: 450px">
                            <asp:GridView ID="gvcomprobantes" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" OnRowCreated="griddata_RowCreated" Font-Size="Smaller" Width="830px">
                                <Columns>
                                    <asp:BoundField DataField="CSUBDIA" HeaderText="SD." />
                                    <asp:BoundField DataField="CCOMPRO" HeaderText="COMPROB." />
                                    <asp:BoundField DataField="CMEMO" HeaderText="NUM. CHEQUE" />
                                    <asp:BoundField DataField="CDATE" HeaderText="FECHA">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CCODMON" HeaderText="MO" />
                                    <asp:BoundField DataField="CTOTAL" HeaderText="TOTAL" />


                                    <asp:BoundField DataField="CGLOSA" HeaderText="GLOSA" />


                                    <asp:TemplateField HeaderText="Imprimir">

                                        
                                    <ItemTemplate>
                                        <div class="imprimir" style="text-align: center">
                                            <img alt="" src="../../../Images/Printer.png" width="25" style="cursor: pointer" />
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
        </div>
   
   
</asp:Content>
