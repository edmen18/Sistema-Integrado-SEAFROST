<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MovArticulo.aspx.cs" Inherits="Default2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">

  <script type="text/javascript">
      $(function () {

          $("#MainContent_txtdescripcion").autocomplete(
                    {
                        source: function (request, response) {
                                                                $.ajax({
                                    url: "ReportePartes.aspx/GetArticulos",
                                    data: "{ 'productos': '" + request.term + "' }",
                                    dataType: "json",
                                    type: "POST",
                                    contentType: "application/json; charset=utf-8",
                                    dataFilter: function (data) { return data; },
                                    success: function (data) {
                                        response($.map(data.d, function (item) {
                                            return {
                                                value: item.AR_CDESCRI,
                                                id: item.AR_CCODIGO,
                                                un: item.AR_CUNIDAD

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
                            var cadena = str;
                            var un = ui.item.un;
                            posicionEspacio = cadena.indexOf("@"), //Obtengo la posición del espacio en la cadena
                            primerApellido = cadena.substring(0, posicionEspacio) //Obtengo la porción deseada de la cadena
                            enMinuscula = primerApellido.toLowerCase(); //Convierto el apellido a minúscula

                            primerApellido = cadena.substring(posicionEspacio + 1, str.length)
                            $('#MainContent_txtcodarticulo').val(str);
                           
                        }

                    });
          $(".consulta").click(function () {
              var LDE = {};
              LDE.AR_CCODIGO =  $('#MainContent_txtcodarticulo').val();
              LDE.C6_CALMA = $('#MainContent_ddlalmacen').val();
                  $.ajax({
                  type: "POST",
                  url: "MovArticulo.aspx/Movimientos",
                  data: '{LDE: ' + JSON.stringify(LDE) + '}',
                  contentType: "application/json; charset=utf-8",
                  dataType: "json",
                  success: function (data) {

                      if (data.d.length > 0) {
                          var row = $("[id*=gvmovimientos] tr:last-child").clone(true);
                          $("[id*=gvmovimientos] tr").not($("[id*=gvmovimientos] tr:first-child")).remove();

                          for (var i = 0; i < data.d.length; i++) {

                              $("td", row).eq(0).html(moment(data.d[i].C6_DFECDOC).format("DD/MM/YYYY"));
                              $("td", row).eq(1).html(data.d[i].C6_CTD);
                              $("td", row).eq(2).html(data.d[i].C6_CNUMDOC);
                              $("td", row).eq(3).html(data.d[i].C6_CCODMOV);
                              $("td", row).eq(4).html(data.d[i].TDR);
                              $("td", row).eq(5).html(data.d[i].PROVEEDOR);
                              $("td", row).eq(6).html(data.d[i].REFERENCIA);
                              if((data.d[i].AR_CFLOTE == "S") || (data.d[i].AR_CFSERIE == "S")) {
                                  $("td", row).eq(15).html(data.d[i].LOTE);
                                  $("td", row).eq(7).html("--");
                              }
                              else {
                                  $("td", row).eq(7).html(data.d[i].SERIE);
                                  $("td", row).eq(15).html("--");
                                 
                              }
                              $("td", row).eq(10).html(data.d[i].C6_CCODMON);
                              $("td", row).eq(11).html(data.d[i].C6_NMNPRUN.toFixed(2));
                              $("td", row).eq(12).html(data.d[i].TOTAL);
                              $("td", row).eq(13).html(data.d[i].CCOSTO);
                              $("td", row).eq(14).html(data.d[i].SOLICITANTE);
                              if (data.d[i].C6_CTD == "PS") {
                                  $("td", row).eq(8).html(data.d[i].CANSAL.toFixed(2));
                                  $("td", row).eq(9).html("0.00");
                                  $("td", row).eq(12).html((data.d[i].CANSAL * data.d[i].C6_NMNPRUN).toFixed(2));
                              }
                              else {
                                  $("td", row).eq(9).html(data.d[i].CANTENT.toFixed(2));
                                  $("td", row).eq(8).html("0.00");
                                  $("td", row).eq(12).html((data.d[i].CANTENT * data.d[i].C6_NMNPRUN).toFixed(2));
                              }
                             $("[id*=gvmovimientos]").append(row);
                              row = $("[id*=gvmovimientos] tr:last-child").clone(true);
                          }

                      } else {
                          var row = $("[id*=gvmovimientos] tr:last-child").clone(true);
                          $("[id*=gvmovimientos] tr").not($("[id*=gvmovimientos] tr:first-child")).remove();

                          $("td", row).eq(0).html("");
                          $("td", row).eq(1).html("");
                          $("td", row).eq(2).html("");
                          $("td", row).eq(3).html("");
                          $("td", row).eq(4).html("");
                          $("td", row).eq(5).html("");
                          $("td", row).eq(6).html("");
                          $("td", row).eq(7).html("");

                          $("[id*=gvmovimientos]").append(row);
                          alert("no se encontro registro");
                      }
                      totales()
                  },
                  error: function (response) {
                      if (response.length != 0)
                          alert(response);
                  }
              })
          });
          function totales() {
              var LDE = {};
              LDE.AR_CCODIGO = $('#MainContent_txtcodarticulo').val();
              LDE.C6_CALMA = $('#MainContent_ddlalmacen').val();
                   $.ajax({
                  type: "POST",
                  url: "MovArticulo.aspx/gettotales",
                  data: '{LDE: ' + JSON.stringify(LDE) + '}',
                  contentType: "application/json; charset=utf-8",
                  dataType: "json",
                  async: false,
                  success: function (data) {

                      if (data.d.length > 0) {
                          for (var i = 0; i <= data.d.length; i++) {
                              $('#MainContent_txtsalidas').val(data.d[i].salidas.toFixed(2));
                              $('#MainContent_txtentradas').val(data.d[i].entradas.toFixed(2));
                              $('#MainContent_txttotal').val(Math.abs((data.d[i].salidas - data.d[i].entradas)).toFixed(2));
                              $('#MainContent_txtserie').val(data.d[i].SERIE);
                              $('#MainContent_txtunidad').val(data.d[i].AR_CUNIDAD);
                              }

                      }
                      else {

                          alert("no se encontro registro");
                      }

                  },
                  error: function (response) {
                      if (response.length != 0)
                          alert(response);
                  }
              });

          }

      });
      </script>
      <style type="text/css">
        #btnsalir {
            width: 67px;
        }
        #btngrabar {
            width: 67px;
        }
          .auto-style3 {
              width: 261px;
          }
          .auto-style5 {
              width: 408px;
          }
          .auto-style6 {
              height: 19px;
          }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="scriptManager" runat="server" EnablePageMethods="true" />
    <table width="100%" cellpadding="5" cellspacing="5" border="0">
        <tr>
            <td>


            

       <fieldset style="background-color: #99CCFF">
        <legend style="font-weight: bold; background-color: #99CCFF;">
            <asp:Label ID="Label9" runat="server" Text="MOVIMIENTOS DE UN ARTICULO" Font-Bold="True" Font-Size="10pt"></asp:Label></legend>

        <table class="auto-style3">
            <tr>
                <td class="auto-style6">&nbsp;Almacen&nbsp;&nbsp;&nbsp; </td>
                <td class="auto-style6"> <asp:DropDownList ID="ddlalmacen" runat="server" Height="25px" Width="535px">
                        </asp:DropDownList></td> </td>
               
              </tr>
                             </table>
             <fieldset style="background-color: #99CCFF">
        <legend style="font-weight: bold; background-color: #99CCFF;">
            <asp:Label ID="Label2" runat="server" Text="  " Font-Bold="True" Font-Size="10pt"></asp:Label></legend>

        <table>
             <tr>
              <td class="GridRow">Código Articulo&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtcodarticulo" runat="server" Width="133px" Height="16px" Enabled="False"></asp:TextBox>
              </td>
              </tr>
            <tr>
                 <td>Descripción del Artículo <asp:TextBox ID="txtdescripcion" runat="server" Width="464px"></asp:TextBox>&nbsp; <input id="btnconsulta" type="button" value="Consulta" class="consulta"/>  &nbsp;&nbsp;&nbsp; </td>
            </tr>
            
        </table>
                 <table>

                      <tr>
                 <td>Unidad&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtunidad" runat="server" Width="158px" Enabled="False"></asp:TextBox></td>
                 <td>Serie&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtserie" runat="server" Width="167px" Height="17px" Enabled="False"></asp:TextBox></td>
 
                      </tr>
          
                 </table>

 <fieldset style="background-color: #99CCFF">
        <legend style="font-weight: bold; background-color: #99CCFF;">
            <asp:Label ID="Label3" runat="server" Text=" " Font-Bold="True" Font-Size="10pt"></asp:Label>LISTADO DE MOVIMIENTOS DEL ARTÍCULO SELECCIONADO</legend>

     <table>
          <tr>
             <td class="auto-style5">
            <div style=" overflow: auto;width: 1300px; height: 350px">
                  <asp:GridView ID="gvmovimientos" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="C6_DFECDOC" HeaderText="FEC. DOC." />
                        <asp:BoundField HeaderText="TD" DataField="C6_CTD" />
                        <asp:BoundField HeaderText="NUMERO" DataField="C6_CNUMDOC" />

                                            
                        <asp:BoundField DataField="C6_CCODMOV" HeaderText="CM" />

                                            
                        <asp:BoundField HeaderText="TDR" DataField="TDR" />
                                                                    
                        <asp:BoundField HeaderText="PROVEEDOR" DataField="PROVEEDOR" />
                        <asp:BoundField HeaderText="REFERENCIA" DataField="REFERENCIA" />
                        <asp:BoundField HeaderText="SERIE" DataField="SERIE" />

                                            
                        <asp:BoundField HeaderText="SALIDA" DataField="CANSAL" />
<asp:BoundField HeaderText="ENTRADA" DataField="CANTENT"></asp:BoundField>
                        <asp:BoundField HeaderText="MONEDA" DataField="C6_CCODMON" />
                                                                    
                        <asp:BoundField DataField="C6_NMNPRUN" HeaderText="P.UNIT." />
                        <asp:BoundField DataField="TOTAL" HeaderText="TOTAL" />
                        <asp:BoundField DataField="CCOSTO" HeaderText="C.COSTO" />
                        <asp:BoundField DataField="SOLICITANTE" HeaderText="SOLICITANTE" />
                                                                    
                        <asp:BoundField DataField="LOTE" HeaderText="LOTE" />
                                                                    
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

                 <br />
             </div>
             </td>

         </tr>

     </table>
      </fieldset>             
    </fieldset>

    <fieldset style="background-color: #99CCFF">
        <legend style="font-weight: bold; background-color: #99CCFF;">
            <asp:Label ID="Label4" runat="server" Text="  " Font-Bold="True" Font-Size="10pt"></asp:Label>Totales</legend>
        <table>
            <tr>
                <td>Salidas&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtsalidas" runat="server" BackColor="#CCFF66" Enabled="False" Font-Bold="True"></asp:TextBox></td>
                 <td>Entradas&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtentradas" runat="server" BackColor="#CCFF66" Enabled="False" Font-Bold="True"></asp:TextBox></td>
                 <td> Total&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txttotal" runat="server" BackColor="#CCFF99" Enabled="False" Font-Bold="True"></asp:TextBox></td>

            </tr>
        </table>
       
 </fieldset>
     </td>

        </tr>
</table>

</asp:Content>
