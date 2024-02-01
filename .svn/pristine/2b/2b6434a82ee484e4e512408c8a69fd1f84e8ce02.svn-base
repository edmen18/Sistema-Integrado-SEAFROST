<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SOliberaStock.aspx.cs" Inherits="Default2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link type="text/css" href="../../CSS/Base-s.css?1.9" rel="stylesheet" />

    <script type="text/javascript">


        function ModifyEnterKeyPressAsTab(event, info) {

            if (event.keyCode == 13) {
                cb = parseInt($(info).attr('tabindex'));
                cb2 = cb + 1;
                if ($(':input[TabIndex=\'' + (cb2) + '\']') != null) {
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

           

            var filtro = function () {
                var dd = 0;

                //Agregar el comportamiento al texto (se selecciona por el ID) 
                $("#MainContent_txtfiltra").keyup(function () {
                    var upp = $(this).val().toUpperCase();
                    var s = upp.split(" ");
                    $(".filtrar tr").show();
                    $.each(s, function () {
                        $(".filtrar tr:visible .producto:not(:contains('" + this + "'))").parent().hide() && $(".filtrar tr:visible .sol:not(:contains('" + $('#MainContent_txtfiltra0').val().toUpperCase() + "'))").parent().hide();
                    });
                });
            }



            var filtro2 = function () {
                var dd = 0;
                //Agregar el comportamiento al texto (se selecciona por el ID) 
                $("#MainContent_txtfiltra0").keyup(function () {
                    var upp = $(this).val().toUpperCase();
                    var s = upp.split(" ");
                    $(".filtrar tr").show();
                    $.each(s, function () {
                        $(".filtrar tr:visible .sol:not(:contains('" + this + "'))").parent().hide() && $(".filtrar tr:visible .producto:not(:contains('" + $('#MainContent_txtfiltra').val().toUpperCase() + "'))").parent().hide();
                    });

                });
            }
            filtro2();
            filtro();




            $("#MainContent_btbuscar").hide();

            contarndw = 0;
            cc = 1;
            sw_edicion = 0;
            sw_nuevo = 0;
            sw_plan = 0;
            contaditem = 0; contaditemplan = 0;
            guardartmp = [];
            sindatosimport = 0;
            gsumadolaresf = 0; gsumasolesf = 0;
            $(".bttimp").hide();
            $(".btplan").hide();
            $(function () {
                UHTML.id = 'MainContent';
                Operacion.iValida(Operacion.mask("txtcan"), 1);
            });


        });

    </script>
        <script type="text/javascript">
        $(function () {
            $('#dvlibera').dialog({
                autoOpen: false,
                modal: true,
                resizable: true,
                width: 530,
                heigth: 100,
                title: 'Liberacion x Usuario',
                close: function (event, ui) {
                },
            }
           );

            
        });

    </script>

    <script type="text/javascript">
        $(function () {
            $("#MainContent_txtsoli").autocomplete(
                {
                    source: function (request, response) {
                        $.ajax({
                            url: "../../ORDENCOMPRA/OCnueva.aspx/Gettablaycodigo",
                            data: "{ 'dato': '" + "%" + request.term + "%" + "',codigo:'12' }",
                            dataType: "json",
                            type: "POST",
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
                        //primerApellido = cadena.substring(posicionEspacio + 1, str.length)
                        $('#MainContent_txtdcodsoli').val(str.trim());
                        Operacion.mask("txtcan").focus();
                    },
                    change: function (event, ui) {
                        if (ui.item == null || ui.item == undefined) {
                            $("#MainContent_txtdcodsoli").val("");
                            $("#MainContent_txtsoli").val("");
                            $("#MainContent_txtsoli").focus();
                            alert("No ha seleccionado solicitante");
                        }
                    }
                });




        });


        $(function () {

            $(".lib").click(function () {
                var trpp = $(this).parent().parent();
                lb_idprod = $("td", trpp).eq(0).html();
                lb_lote = $("td", trpp).eq(4).html();
                lb_cant = $("td", trpp).eq(5).html();
                lb_alma = $("td", trpp).eq(2).val();
                lb_codsoli = $("td", trpp).eq(3).val();
                lb_dessoli = $("td", trpp).eq(3).html();
                Operacion.mask("txtdcodsoli").focus();
                Operacion.mask("txtdcodsoli").val("");
                Operacion.mask("txtsoli").val("");
                Operacion.mask("txtcan").val("");

                var nvalida = Rvalidausuasoli(lb_codsoli).rtdatoa;
                if (nvalida < 1) {
                    alert("Usted No tiene Acceso a este Producto");
                }else{

                $('#dvlibera').dialog("open");
                }
            });

            $(".btacep").click(function () {
                var cantnew = Number(lb_cant) - Number(Operacion.mask("txtcan").val()) ;
                if (Number(Operacion.mask("txtcan").val()) > Number(lb_cant)) {
                    alert("La Cantidad no debe Exceder de su Stock");
                } else if (Operacion.mask("txtdcodsoli").val().trim() == lb_codsoli.trim()) {
                    alert("El solicitante Elegido debe Ser Diferente A: " + lb_dessoli);
                    Operacion.mask("txtdcodsoli").focus();
                } else if (Operacion.mask("txtdcodsoli").val().trim() == "") {
                    alert("No ha ingresado Solicitante  ");
                    Operacion.mask("txtdcodsoli").focus();
                } else {
                    if (confirm("Desea Confirmar transferencia?")){
                        InsertarStockxsoli(lb_idprod, lb_alma, Operacion.mask("txtdcodsoli").val(), lb_lote, Operacion.mask("txtcan").val(), "TU", lb_codsoli);
                        ActualizaCantNueva(lb_idprod, lb_alma, lb_codsoli, lb_lote, cantnew);
                        $("#dvlibera").dialog("close");
                        FiltragridxAlmacen(Operacion.mask("ddlfilt").val());

                    }
                }
            });

            $("#MainContent_ddlfilt").change(function () {
                FiltragridxAlmacen($("#MainContent_ddlfilt").val());
            });
            
            $("#MainContent_txtcan").change(function () {
                $(".btacep").focus();
            });
            
            $("#MainContent_txtdcodsoli").keypress(function (event) {
                if (event.keyCode == 13) {
                    var textdev = Mostrarundato($("#MainContent_txtdcodsoli").val(), '12').ee;
                    if (textdev != "") {
                        $("#MainContent_txtsoli").val(textdev);
                        $("#MainContent_txtcan").focus();
                    } else {
                        $("#MainContent_txtdcodsoli").val("");
                        alert("Codigo no existe");
                    }
                }
            });






            function Mostrarundato(codigocons, codigoe) {
                var codigowh = codigoe;
                var codigoconswh = codigocons;
                var ee = "";
                $.ajax({

                    type: "POST",
                    url: "../../ORDENCOMPRA/OCnueva.aspx/Getdescycodigo",
                    //data: '{CNUMDOC: ' + JSON.stringify(CNUMDOC) + '}',
                    data: "{dato: '" + codigoconswh + "',codigo:'" + codigowh + "' }",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        if (data.d != null) {
                            ee = data.d.TG_CDESCRI;
                        } else {
                            ee = "";
                        }
                    },
                    error: function (data) {
                        if (data.length != 0)
                            alert(data);
                    }

                });
                return { ee };
            }


            function InsertarStockxsoli(idcodix, almacx, solicx, loteix, cantix, estadox, usuorx) {

                var ADATA = {};
                ADATA.SS_CCODIGO = idcodix.trim();
                ADATA.SS_ALMACEN = almacx.trim();
                ADATA.SS_SOLICITAN = solicx;
                ADATA.SS_LOTES = loteix.trim();
                ADATA.SS_CANTID = cantix;
                ADATA.SS_ESTADO = estadox;
                ADATA.SS_SOLICORIGEN = usuorx;
                $.ajax({
                    type: "POST",
                    url: "SOliberaStock.aspx/InsertastockS",
                    data: '{ADATA: ' + JSON.stringify(ADATA) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                    },
                    error: function (response) {
                        if (response.length != 0)
                            console.table(response);
                    }
                });
            }


            function ActualizaCantNueva(idcodix, almacx, solicx, loteix, cantnueva) {

                var ADATA = {};
                ADATA.SS_CCODIGO = idcodix.trim();
                ADATA.SS_ALMACEN = almacx.trim();
                ADATA.SS_SOLICITAN = solicx.trim();
                ADATA.SS_LOTES = loteix.trim();
                ADATA.SS_CANTID = cantnueva;
                ADATA.SS_ESTADO = "TU";
                //ADATA.SS_SOLICORIGEN = "";
                $.ajax({
                    type: "POST",
                    url: "SOliberaStock.aspx/actualizaStocknuevo",
                    data: '{ADATA: ' + JSON.stringify(ADATA) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                    },
                    error: function (response) {
                        if (response.length != 0)
                            console.table(response);
                    }
                });
            }


            function Rvalidausuasoli(solicta) {
                rtdatoa = 0;
                var ADATA = {};
                ADATA.SU_USUA = $("#hfusu").val();
                ADATA.SU_SOLIC = solicta;
                $.ajax({
                    type: "POST",
                    url: "SOliberaStock.aspx/Nvalidaususol",
                    data: '{ADATA: ' + JSON.stringify(ADATA) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        rtdatoa = data.d;
                    },
                    error: function (data) {
                        if (data.length != 0)
                            alert(data);
                    }
                });
                return { rtdatoa };
            }

            function FiltragridxAlmacen(almac) {
                var ADATA = {};
                ADATA.SS_ALMACEN = almac;
                ADATA.SS_SOLICITAN = $("#hfusu").val();
                $.ajax({
                    type: "POST",
                    url: "SOliberaStock.aspx/stockxalmacen",
                    data: '{ADATA: ' + JSON.stringify(ADATA) + '}',
                    //data: "{almac: '" + almac + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {

                        if (data.d.length > 0) {
                            var row = $("[id*=gvsolicitudes] tr:last-child").clone(true);
                            $("[id*=gvsolicitudes] tr").not($("[id*=gvsolicitudes] tr:first-child")).remove();

                            for (var i = 0; i < data.d.length; i++) {

                                $("td", row).eq(0).html(data.d[i].SS_CCODIGO);
                                $("td", row).eq(1).html(data.d[i].SS_DESPROD);
                                $("td", row).eq(2).html(data.d[i].SS_ALMACEN);
                                $("td", row).eq(2).val(data.d[i].SS_CODALMACEN);
                                $("td", row).eq(3).html(data.d[i].SS_SOLICITAN);
                                $("td", row).eq(3).val(data.d[i].SS_CODSOLICITAN);
                                $("td", row).eq(4).html(data.d[i].SS_LOTES);
                                $("td", row).eq(5).html(data.d[i].SS_CANTID);
              
                                $("[id*=gvsolicitudes]").append(row);
                                row = $("[id*=gvsolicitudes] tr:last-child").clone(true);
                            }

                        } else {
                            var row = $("[id*=gvsolicitudes] tr:last-child").clone(true);
                            $("[id*=gvsolicitudes] tr").not($("[id*=gvsolicitudes] tr:first-child")).remove();

                            $("td", row).eq(0).html("");
                            $("td", row).eq(1).html("");
                            $("td", row).eq(2).html("");
                            $("td", row).eq(3).html("");
                            $("td", row).eq(4).html("");
                            $("td", row).eq(5).html("");

                            $("[id*=gvsolicitudes]").append(row);
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
        .auto-style1 {
            height: 26px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:HiddenField runat="server" ID="hffactual" />
    <asp:HiddenField runat="server" ID="hfusu" />
    <div id="contenedor" style="float:left;width:1000px">
        <fieldset style="float:left;width:900px">
            <legend>LIBERACION DE STOCK POR SOLICITANTE</legend>

            <table>

                <tr>
                    <td>Filtrar Por:
                          <asp:DropDownList runat="server" ID="ddlfilt" Width="230"  ></asp:DropDownList>
                
                     
                        <%--<img id="btimaga" class="btimag" runat="server" width="25" height="25" src="~/Images/exel.jpg" />--%>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:TextBox runat="server" ID="txtfiltra" Width="300" placeholder="PRODUCTO"></asp:TextBox>
                        <asp:TextBox runat="server" ID="txtfiltra0" Width="300" placeholder="SOLICITANTE"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td colspan="4">
                        <div id="expo">
                        <asp:GridView ID="gvsolicitudes" class="filtrar" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" Width="958px">
                            <Columns>
                                <asp:BoundField DataField="SS_CCODIGO" HeaderText="COD PROD" ItemStyle-Width="10">
                                     <ItemStyle CssClass="id"></ItemStyle>
                                </asp:BoundField>
                                  <asp:BoundField DataField="SS_DESPROD" HeaderText="PRODUCTO" ItemStyle-Width="300">
                                     <ItemStyle CssClass="producto"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="SS_ALMACEN" HeaderText="ALMACEN" ItemStyle-Width="250">
                                    <ItemStyle CssClass="alm"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="SS_SOLICITAN" HeaderText="SOLICITANTE" ItemStyle-Width="200"  ItemStyle-HorizontalAlign="center" >
                                 <ItemStyle CssClass="sol"></ItemStyle>
                                   </asp:BoundField>
                                <asp:BoundField DataField="SS_LOTES" HeaderText="LOTE" ItemStyle-Width="80" ItemStyle-HorizontalAlign="center">
                                    <ItemStyle CssClass="lot"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="SS_CANTID" HeaderText="CANTIDAD" ItemStyle-Width="100" ItemStyle-HorizontalAlign="center"/>
                                <asp:TemplateField ItemStyle-Width="11px" HeaderText="LIB"> 
                                    <ItemTemplate>
                                        <div class="lib" style="text-align: center">
                                            <div>
                                                <img alt="" src="../../Images/Message_Information.png" width="25" style="cursor: pointer" />
                                            </div>
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

        </fieldset>
        <table>
            <tr>
                <td>

                    <div id="dvp" style="display: compact">
                        <%--<asp:Button class="btn" Text="Buscar" runat="server" ID="btbuscar" Enabled="true" OnClick="btbuscar_Click"></asp:Button>--%>
                    </div>

                </td>
            </tr>
        </table>


        <div id="dvlibera" style="display:normal">
          <table>
              <tr>
                  <td>solicitante</td>
                  <td>
                      <asp:TextBox runat="server" ID="txtdcodsoli" Width="100" />
                  </td>
                  <td>
                      <asp:TextBox runat="server" ID="txtsoli" Width="280" />
                  </td>
              </tr>
              <tr>
                  <td>Cantidad</td>
                  <td>
                      <asp:TextBox runat="server" ID="txtcan" Width="100"  />
                  </td>
              </tr>
              <tr>
                  <td colspan="3">
                      <asp:Button Text="Aceptar"  class="btacep btn"  runat="server" />
                  </td>
              </tr>
          </table>
    </div>





    </div>
</asp:Content>

