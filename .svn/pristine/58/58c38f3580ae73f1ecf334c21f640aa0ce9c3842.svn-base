<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ALkardexval.aspx.cs" Inherits="Default2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link type="text/css" href="../../CSS/Base-s.css?1.4" rel="stylesheet" />

    <script type="text/javascript">

      
        function ModifyEnterKeyPressAsTab(event,info) {
           
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
            //} else {
               // $("#MainContent_txtfecha1").focus();
            }
        
        });

    </script>

    <script type="text/javascript">
        $(function () {
            $(".idart").autocomplete(
                          {
                              source: function (request, response) {
                                  $.ajax({
                                      //url: "/ORDENCOMPRA/OCnueva.aspx/GetProductos",
                                      url: "../../ORDENCOMPRA/OCnueva.aspx/Getmateriales",//GetProductos
                                      //data: "{ 'productos': '" + "%" + request.term + "%" + "',tipop:'" + "N" + "',subtip:'" + "-1" + "' }",
                                      data: "{ 'productos': '" + "%" + request.term + "%" + "',tipop:'" + "N" + "',subtip:'" + "-1" + "' ,idusuario:'" + $("#hfusu").val() + "',idprovee:'',tipolinea:'',parm:'' }",
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
            $(".idart2").autocomplete(
                          {
                              source: function (request, response) {
                                  $.ajax({
                                      //url: "/ORDENCOMPRA/OCnueva.aspx/GetProductos",
                                      url: "../../ORDENCOMPRA/OCnueva.aspx/Getmateriales",//GetProductos
                                      //data: "{ 'productos': '" + "%" + request.term + "%" + "',tipop:'" + "N" + "',subtip:'" + "-1" + "' }",
                                      data: "{ 'productos': '" + "%" + request.term + "%" + "',tipop:'" + "N" + "',subtip:'" + "-1" + "' ,idusuario:'" + $("#hfusu").val() + "',idprovee:'',tipolinea:'',parm:'' }",
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

        });

    </script>



    <script type="text/javascript">
        $(function () {
            $(".btbuscar").click(function () {
                filtarocompra();
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



        });

    </script>

    <script type="text/javascript">

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
            <legend>KARDEX VALORIZADO POR PERIODO</legend>

            <table>
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
                <tr><td>Moneda:</td>
                    <td >
                        <asp:DropDownList ID="ddlmone" runat="server" Width="150" MaxLength="7"></asp:DropDownList>
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
                    <td >
                         <asp:Button class="btn" Text="Aceptar" runat="server" ID="btacepta" OnClick="btacepta_Click" Enabled="true"></asp:Button>
                    </td>
                </tr>
                </table>
            <div id="dvkardex">

                <asp:GridView ID="gvkardex" class="filtrar" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" Width="709px">
                            <Columns>
                                <asp:BoundField DataField="C6_CCODIGO" HeaderText="ITM" ItemStyle-Width="2" />
                                <asp:BoundField DataField="C6_DFECDOC" HeaderText="CANTIDAD" ItemStyle-Width="10" ItemStyle-BackColor="#ffffcc" ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField DataField="C6_CTD" HeaderText="UNIDAD" ItemStyle-Width="10" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="C6_CCODMOV" HeaderText="MATERIAL" ItemStyle-Width="400" />
                                <asp:BoundField DataField="C6_CALMA" HeaderText="PRECIO" ItemStyle-Width="70" ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField DataField="C6_CNUMDOC" HeaderText="PRECIO" ItemStyle-Width="70" ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField DataField="C6_CRFNDOC" HeaderText="PRECIO" ItemStyle-Width="70" ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField DataField="C6_CCODPRO" HeaderText="PRECIO" ItemStyle-Width="70" ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField DataField="MONEDA" HeaderText="PRECIO" ItemStyle-Width="70" ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField DataField="C6_NCANTIN" HeaderText="PRECIO" ItemStyle-Width="70" ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField DataField="MONTOING" HeaderText="PRECIO" ItemStyle-Width="70" ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField DataField="C6_NCANTSA" HeaderText="PRECIO" ItemStyle-Width="70" ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField DataField="MONTOSAL" HeaderText="PRECIO" ItemStyle-Width="70" ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField DataField="C6_CGLOSA" HeaderText="PRECIO" ItemStyle-Width="70" ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField DataField="VL_NACTCAN" HeaderText="PRECIO" ItemStyle-Width="70" ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField DataField="VL_NACVL" HeaderText="PRECIO" ItemStyle-Width="70" ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField DataField="TM_CPRIVAL" HeaderText="PRECIO" ItemStyle-Width="70" ItemStyle-HorizontalAlign="Right" />

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

            </div>
        </fieldset>
    </div>
 



   
</asp:Content>

