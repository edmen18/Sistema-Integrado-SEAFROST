<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ALcentroconsumo.aspx.cs" Inherits="Default2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link type="text/css" href="../../CSS/Base-s.css?1.4" rel="stylesheet" />

    <script type="text/javascript">

      
        function ModifyEnterKeyPressAsTab(event,info){ 
           
            if (event.keyCode == 13) {
                cb = parseInt($(info).attr('tabindex'));
                cb2 = cb + 1;
                if ($(':input[TabIndex=\'' + (cb2) + '\']') != null  ) {
                    if ($(':input[TabIndex=\'' + (cb2) + '\']').attr("disabled") == false) {

                        $(':input[TabIndex=\'' + (cb2) + '\']').focus();
                        $(':input[TabIndex=\'' + (cb2) + '\']').select();
                    } else {
                        $(':input[TabIndex=\'' + (cb2 + 1) + '\']').focus();
                        $(':input[TabIndex=\'' + (cb2 + 1) + '\']').select();
                    }
                    event.preventDefault();
                    return false;
                }
            }
        }




        $(window).load(function () {
            
          

            contarndw = 0;
            cc = 1;
            sw_edicion = 0;
            sw_nuevo = 0;
            sw_plan = 0;
            contaditem = 0; contaditemplan=0;
            guardartmp = [];
            sindatosimport = 0;
            gsumadolaresf = 0; gsumasolesf = 0;
            $(".bttimp").hide();
            $(".btplan").hide();
            $(function () {
                UHTML.id = 'MainContent';
                Operacion.iValida(Operacion.mask("txtdcant"), 1);
                $("#MainContent_txtfecha1").datepicker({ dateFormat: 'yy/mm' });
                $("#MainContent_txtfecha2").datepicker({ dateFormat: 'yy/mm' });
                $("#MainContent_txtfcomp").datepicker();

            });
            
            $.urlParam = function (name) {
                var results = new RegExp('[\?&]' + name + '=([^&#]*)').exec(window.location.href);
                return (results != null ? results[1] || 0 : "");
            }
            

            var codextraido = $.urlParam("ID");//window.location.search.substring(1);
            
            if (codextraido.length > 1) {
                MostrarunRegistro(codextraido);
                validaboton();
                $("#MainContent_ddltipo").attr("disabled", true);
                $("#MainContent_ddlsuboc").attr("disabled", true);
                $(".btadd").show();
            } else {
                //$("#MainContent_txtfecha1").focus();
            }
        
        });

    </script>

    <script type="text/javascript">
        $(function () {
            $(".idart").live("focus", function () {
                if (Operacion.mask("ddlagrup").val() == "4") {
                    $(".idart").autocomplete(
                                  {
                                      source: function (request, response) {
                                          $.ajax({
                                              url: "../../ORDENCOMPRA/OCnueva.aspx/Getmateriales",//GetProductos
                                              data: "{ 'productos': '" + "%" + request.term + "%" + "',tipop:'" + "N" + "',subtip:'" + "-1" + "' ,idusuario:'" + $("#hfusu").val() + "',idprovee:'',tipolinea:'',parm:'' }",
                                              dataType: "json",
                                              type: "POST",
                                              async:false,
                                              contentType: "application/json; charset=utf-8",
                                              dataFilter: function (data) { return data; },
                                              success: function (data) {
                                                  response($.map(data.d, function (item) {
                                                      return {
                                                          value: item.AR_CDESCRI,
                                                          id: item.AR_CCODIGO.trim(),
                                                          um: item.AR_CUNIDAD,
                                                          igvp: item.AR_NIGVCPR
                                                      }
                                                  }))
                                              },
                                              error: function (XMLHttpRequest, textStatus, errorThrown) { //alert(textStatus); 
                                              }
                                          });
                                      },
                                      minLength: 1,
                                      select: function (event, ui) {
                                          var str = ui.item.id;
                                          var strum = ui.item.um;
                                          var strigv = ui.item.igvp;
                                          $('#MainContent_txtidprod1').val(str);
                                      },
                                      change: function (event, ui) {
                                          if (ui.item == null || ui.item == undefined) {
                                              $("#MainContent_txtidprod1").val("");
                                              $(".idart").focus();
                                              alert("No ha seleccionado El producto");
                                          }
                                      }
                                  });
                } else if (Operacion.mask("ddlagrup").val() == "5") {
                    $(".idart").autocomplete(
                                  {
                                      source: function (request, response) {
                                          $.ajax({
                                              url: "../../ORDENCOMPRA/OCnueva.aspx/Getcentrocosto",//GetProductos
                                              data: "{ 'dato': '" + "%" + request.term + "%" + "' }",
                                              dataType: "json",
                                              type: "POST",
                                              async: false,
                                              contentType: "application/json; charset=utf-8",
                                              dataFilter: function (data) { return data; },
                                              success: function (data) {
                                                  response($.map(data.d, function (item) {
                                                      return {
                                                          value: item.TG_CDESCRI,
                                                          id: item.TG_CCLAVE.trim()
                                                      }
                                                  }))
                                              },
                                              error: function (XMLHttpRequest, textStatus, errorThrown) { //alert(textStatus); 
                                              }
                                          });
                                      },
                                      minLength: 1,
                                      select: function (event, ui) {
                                          var str = ui.item.id;
                                          var cadena = str
                                          $('#MainContent_txtidprod1').val(str.trim());
                                      },
                                      change: function (event, ui) {
                                          if (ui.item == null || ui.item == undefined) {
                                              $("#MainContent_txtidprod1").val("");
                                              $(".idart").focus();
                                              alert("No ha seleccionado El producto");
                                          }
                                      }
                                  });
                }
            });

            $(".idart2").live("focus", function () {
                if (Operacion.mask("ddlagrup").val() == "4") {
                    $(".idart2").autocomplete(
                               {
                                   source: function (request, response) {
                                       $.ajax({
                                           url: "../../ORDENCOMPRA/OCnueva.aspx/Getmateriales",
                                           data: "{ 'productos': '" + "%" + request.term + "%" + "',tipop:'" + "N" + "',subtip:'" + "-1" + "',idusuario:'" + $("#hfusu").val() + "',idprovee:'',tipolinea:'',parm:'' }",
                                           dataType: "json",
                                           type: "POST",
                                           contentType: "application/json; charset=utf-8",
                                           dataFilter: function (data) { return data; },
                                           success: function (data) {
                                               response($.map(data.d, function (item) {
                                                   return {
                                                       value: item.AR_CDESCRI,
                                                       id: item.AR_CCODIGO.trim(),
                                                       um: item.AR_CUNIDAD,
                                                       igvp: item.AR_NIGVCPR
                                                   }
                                               }))
                                           },
                                           error: function (XMLHttpRequest, textStatus, errorThrown) { //alert(textStatus); 
                                           }
                                       });
                                   },
                                   minLength: 1,
                                   select: function (event, ui) {
                                       var str = ui.item.id;
                                       var strum = ui.item.um;
                                       var strigv = ui.item.igvp;
                                       $('#MainContent_txtidprod2').val(str);
                                   },
                                   change: function (event, ui) {
                                       if (ui.item == null || ui.item == undefined) {
                                           $("#MainContent_txtidprod2").val("");
                                           $(".idart2").focus();
                                           alert("No ha seleccionado El producto");
                                       }
                                   }
                               });

                } else if (Operacion.mask("ddlagrup").val() == "5") {

                    $(".idart2").autocomplete(
              {
                  source: function (request, response) {
                      $.ajax({
                          url: "../../ORDENCOMPRA/OCnueva.aspx/Getcentrocosto",//GetProductos
                          data: "{ 'dato': '" + "%" + request.term + "%" + "' }",
                          dataType: "json",
                          type: "POST",
                          async: false,
                          contentType: "application/json; charset=utf-8",
                          dataFilter: function (data) { return data; },
                          success: function (data) {
                              response($.map(data.d, function (item) {
                                  return {
                                      value: item.TG_CDESCRI,
                                      id: item.TG_CCLAVE.trim()
                                  }
                              }))
                          },
                          error: function (XMLHttpRequest, textStatus, errorThrown) { //alert(textStatus); 
                          }
                      });
                  },
                  minLength: 1,
                  select: function (event, ui) {
                      var str = ui.item.id;
                      var cadena = str
                      $('#MainContent_txtidprod2').val(str.trim());
                  },
                  change: function (event, ui) {
                      if (ui.item == null || ui.item == undefined) {
                          $("#MainContent_txtidprod2").val("");
                          $(".idart2").focus();
                          alert("No ha seleccionado El producto");
                      }
                  }
              });

                }
                });
        });

    </script>



    <script type="text/javascript">
        $(function () {
            $(".btbuscar").click(function () {
                filtarocompra();
            });

            $(".btelimina").click(function () {
                var nf = $(this).parent().parent();
                var nfila = $("#MainContent_gvconsumo td").length;
                if (confirm("Esta Seguro que desea Eliminar Item?")) {
                    if (nfila > 2) {
                        nf.remove();
                    } else {
                        $("td:eq(0)", nf).html("");
                        $("td:eq(1)", nf).html("");
                        $("td:eq(2)", nf).html("");
                        $("td:eq(3)", nf).html("");
                        $("td:eq(4)", nf).html("");
                        $("td:eq(5)", nf).html("");
                    }
                }
            });

            

            $("#MainContent_txtidpro").change(function () {
                if (Mostrarunproveedor($(this).val()).ee == "") {
                    alert("No se encontrol informacion");
                    $(this).focus();
                } else {
                    $("#MainContent_txtprove").val(Mostrarunproveedor($(this).val()).ee);
                    $("#MainContent_txtnumref").focus();
                }
            });

            $("#MainContent_ddlagrup").change(function () {
                Operacion.mask("txtprod").val("");
                Operacion.mask("txtprod2").val("");
                Operacion.mask("txtidprod1").val("");
                Operacion.mask("txtidprod2").val("");
            });
            

        });

    </script>

    <script type="text/javascript">

        function confirmacion() {
            if (confirm("desea confirmar") ) {
                var rowt = $("[id*=gvconsumo] tr:last-child").clone(true);
                $("[id*=gvconsumo] tr").not($("[id*=gvconsumo] tr:first-child")).remove();
                $("td", rowt).eq(0).html("oka");

                $("[id*=gvconsumo]").append(rowt);
                rowt = $("[id*=gvconsumo] tr:last-child").clone(true);
            }
        }

        function MostrarTcambio() {
            var dato;
            var fec1 = moment($("#MainContent_txtfecha1").val(), "DD/MM/YYYY");
            fec1 = new Date(fec1);

            var TCAM = {};
            TCAM.XFECCAM2 = fec1;

            $.ajax({

                type: "POST",
                url: "OCregistrovb.aspx/extraetcambio",
                data: '{TCAM: ' + JSON.stringify(TCAM) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.d == null) {
                        dato = "";
                        alert("No se encuentra registrado tipo de cambio - Comunicarse con contabilidad");
                    } else {
                        dato = data.d.XMEIMP2;
                    }

                },
                error: function (data) {
                    if (data.length != 0)
                        alert(data);
                }

            });
            return dato;
        }

        function MostrarunRegistroLG() {
            var rtdato;
            $.ajax({
                type: "POST",
                url: "ALcosteo.aspx/GetLogC",
                //data: '{INFO: ' + JSON.stringify(INFO) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d == null) {
                        rtdato = data.d.LC_CPERIODO;
                    }
                },
                error: function (data) {
                    if (data.length != 0)
                        alert(data);
                }
            });
        }
    </script>


    <style type="text/css">
        /*.auto-style1 {
            width: 132px;
        }

        fieldset {
            padding: 10px;
            border: 1px solid black;
            border-radius: 5px;
            background-color: white;
            margin:0 auto;
            width: 900px;
        }

        legend {
            padding: 5px;
            font-size: 15px;
            border-radius: 10px;
            background-color: white;
        }*/
        #btbuscaplan {
            height: 27px;
            width: 126px;
        }
        #btlimpiaplan {
            height: 26px;
            width: 118px;
        }
        .btbuscaplan {
            width: 152px;
            height: 30px;
        }
        .btlimpiaplan {
            width: 179px;
            height: 29px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:HiddenField runat="server" ID="hffactual" />
    <asp:HiddenField runat="server" ID="hfusu" />
        <div id="contenedor">
        <fieldset>
            <legend>CONSUMO POR CENTRO COSTO MENSUAL</legend>

            <table>
                <tr>
                    <td>Codigo Almacen</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlalma" Width="350" AutoPostBack="True"  OnSelectedIndexChanged="ddlalma_SelectedIndexChanged" ></asp:DropDownList> 
                    </td>
                </tr>

                                <tr>
                    <td>Almacen Ref</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlalma2" Width="350" Enabled="false" ></asp:DropDownList> 
                    </td>
                </tr>
                <tr>
                    <td>Del Mes :
                    </td> 
                    <td colspan="3">
                        <asp:TextBox runat="server" ID="txtfecha1" Width="130" MaxLength="7" placeholder="AAAA/MM" />
                    </td>
                    
                    </tr><tr>
                    <td>Al Mes:</td>
                    <td>
                        <asp:TextBox ID="txtfecha2" class="tcamb" runat="server" Width="130" placeholder="AAAA/MM" EnableViewState="false"></asp:TextBox>
                    </td>
                </tr>
                <tr><td>Consumo en:</td>
                    <td >
                        <asp:DropDownList ID="ddlconsu" runat="server" Width="150" MaxLength="7"></asp:DropDownList>
                    </td>
                   </tr>
                <tr>
                    <td>Agrupado por:</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlagrup" Width="250"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Producto:</td>
                    <td>
                        <asp:TextBox runat="server" Width="350" ID="txtprod" class="idart" ></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox runat="server" Width="150" ID="txtidprod1" placenholder="CODIGO"  AutoPostBack="True"  OnTextChanged="txtidprod1_TextChanged" ></asp:TextBox>
                    </td>
                    </tr>
                <tr>
                    <td>Producto:</td>
                    <td>
                        <asp:TextBox runat="server" Width="350" ID="txtprod2" class="idart2" ></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox runat="server" Width="150" ID="txtidprod2" AutoPostBack="True"  placenholder="CODIGO" OnTextChanged="txtidprod2_TextChanged" ></asp:TextBox>
                    </td>
                    </tr><tr>
                        <td></td>
                    <td>
                      <%--  OnClick="btacepta_Click"--%>
                         <asp:Button class="btn" Text="Aceptar" runat="server" ID="btacepta"    Enabled="true" OnClick="btacepta_Click" ></asp:Button>

                            <asp:Button class="btn" Text="Generar" runat="server" ID="btgenera" OnClick="btgenera_Click" Enabled="false" />
                      
                            <asp:Button class="btn" Text="Excel" runat="server" ID="btexcel" Enabled="true" OnClick="btexcel_Click" />
                        </td>
                </tr>
                </table>

 <div id="dvasientos">
     <hr />
     <table>

     </table>
     <asp:GridView ID="gvconsumo" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" Width="822px">
                            <Columns>
                                <asp:BoundField DataField="RUB" HeaderText="RUBRO" ItemStyle-Width="150" >
<ItemStyle Width="150px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="CTAV" HeaderText="TIPO DE INSUMO" ItemStyle-Width="200"  ItemStyle-HorizontalAlign="Left" >
<ItemStyle HorizontalAlign="left" Width="200px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="C6_NMNIMPO" HeaderText="SUMA SOLES" ItemStyle-Width="80" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N}" >
<ItemStyle HorizontalAlign="Right" Width="80px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="C6_NUSIMPO" HeaderText="SUMA DOLARES" ItemStyle-Width="80" DataFormatString="{0:N}" ItemStyle-HorizontalAlign="Right">
<ItemStyle Width="80px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="C6_CCUENTA" HeaderText="CUENTA" ItemStyle-Width="80" ItemStyle-HorizontalAlign="Right" >
<ItemStyle HorizontalAlign="Right" Width="80px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="C6_CCODIGO" HeaderText="D/H" ItemStyle-Width="80" ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center" Width="80px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="IP_PC" HeaderText="CTA ORIGEN" ItemStyle-Width="80" ItemStyle-HorizontalAlign="Right" >
<ItemStyle HorizontalAlign="Right" Width="80px"></ItemStyle>
                                </asp:BoundField>
                               
                               

                                <asp:TemplateField HeaderText="ELI">
                                    <ItemTemplate>
                                        <div class="btelimina" style="text-align: center">
                                           <%-- <img alt="" src="../../Images/desaprob.png" width="20" style="cursor: pointer" />--%>
                                            <asp:ImageButton ID="btelimin" ImageUrl="~/Images/Grid_ActionDelete.png" runat="server" OnClick="btelimin_Click"   /> 
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>

                               


                               


                               

                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="false" ForeColor="White" Height="25" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle ForeColor="#000066" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>
     <fieldset>
     <table>
                  <tr>
             <td>N° Comprobante</td>
             <td>
                 <asp:TextBox runat="server" Width="120" Enabled="false" ID="txtncomprob" />
             </td>
         </tr>
             <tr>
             <td>Fecha Comprob.</td>
             <td>
                 <asp:TextBox runat="server" Width="120" ID="txtfcomp" />
             </td>
         </tr>
         <tr>
             <td>
                 <asp:Button Text="Guardar" class="btn" ID="btgrabar" runat="server" OnClick="btgrabar_Click" />
                 <%--<input type="button" value="Grabar" class="btn" />--%>
             </td>
         </tr>
     </table>
         </fieldset>
 </div>




        </fieldset>

    </div>




   
</asp:Content>

