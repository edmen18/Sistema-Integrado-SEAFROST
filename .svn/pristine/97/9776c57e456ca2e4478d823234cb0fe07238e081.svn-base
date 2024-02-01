<%@ Page Title="Consulta - Reimpresión de Documentos" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ReimpresionDocumentos.aspx.cs" Inherits="ReimpresionDocumentos" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link type="text/css" href="../CSS/base.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {
            MARRAY = [];

            UHTML.id = 'MainContent';
            $(".dp1").datepicker();
            Operacion.oDialog('detalle', false);

            var mialmacen = function (ALM, ND) {
                DATA = {};
                DATA.A1_CALMA = ALM;

                $.ajax({
                    type: "POST",
                    url: "ReimpresionDocumentos.aspx/mialmacen",
                    data: '{CALMA:' + JSON.stringify(DATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        if (data.d) {
                            MARRAY[ND].push(data.d.A1_CDESCRI);
                        }
                    },
                    error: function (data) {
                        console.log(data);
                    }
                });
            }

            var micabecera = function (KEY, PRO) {
                var DATA = {};
                DATA.LC_CTD = "LQ";
                DATA.LC_CNUMDOC = KEY;
                DATA.LC_CCODPRV = PRO;

                $.ajax({
                    type: "POST",
                    url: "ReimpresionDocumentos.aspx/listar",
                    data: '{DATA:' + JSON.stringify(DATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        if (data.d.length > 0) {
                            $.each(data.d, function (i, v) {
                                //console.log(v.LC_CNUMDOC);
                                MARRAY[v.LC_CNUMDOC] = [v.LC_NTIPCAM, v.LC_CALMA, v.LC_CGLOSA];
                            });
                            //console.log(MARRAY);
                        }
                    },
                    error: function (data) {

                    }
                });
            }

            $('.btPrinter').live("click", function () {
                var TD = $(this).parents("tr").find("td").eq(1).html();
                var ND = $(this).parents("tr").find("td").eq(2).html();
                var PR = $(this).parents("tr").find("td").eq(5).html();

                window.open("../ALMACEN/Reportes/ReporteRD.aspx?CTD=" + TD.trim() + "&NUM=" + ND.trim() + "&COP=" + PR.trim(), '_blank');
            });
            $('.btDetalle').live('click', function () {
                Operacion.oDialog('detalle', true);

                var AG = $(this).parents("tr").find("td").eq(0).html();
                var TD = $(this).parents("tr").find("td").eq(1).html();
                var ND = $(this).parents("tr").find("td").eq(2).html();
                var FD = $(this).parents("tr").find("td").eq(3).html();
                var CL = $(this).parents("tr").find("td").eq(5).html();//RUC
                var CD = $(this).parents("tr").find("td").eq(6).html();
                var FV = $(this).parents("tr").find("td").eq(7).html();
                var MN = $(this).parents("tr").find("td").eq(8).html();
                var ES = $(this).parents("tr").find("td").eq(10).html();

                micabecera(ND, CL);
                mialmacen(MARRAY[ND][1], ND);

                Operacion.mask('lbldAGE').text(AG);
                Operacion.mask('lbldTDO').text(TD);
                Operacion.mask('lbldNDO').text(ND);
                Operacion.mask('lbldCLI').text(CL + " " + CD);
                Operacion.mask('lbldALM').text(MARRAY[ND][1]+" "+MARRAY[ND][3]);//ALMACEN
                Operacion.mask('lbldGLO').text(MARRAY[ND][2]);//TRAER
                Operacion.mask('lbldFecha').text(FD);
                Operacion.mask('lbldEST').text(ES);
                Operacion.mask('lbldRUC').text(CL);
                Operacion.mask('lbldFOR').text(FV);
                Operacion.mask('lbldMON').text(MN);
                Operacion.mask('lbldTIC').text(MARRAY[ND][0]);


                var FACD = {};
                FACD.LD_CTD = "LQ";
                FACD.LD_CNUMDOC = ND;

                $.ajax({
                    type: "POST",
                    url: "ReimpresionDocumentos.aspx/listarD",
                    data: '{DATA:' + JSON.stringify(FACD) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        Operacion.mask('gvDetalle').empty();
                        var table = $('<table id=MainContent_gvDetalle rules="all" cellpadding=3 style=background-color:White;border-color:#CCCCCC;border-width:1px;border-style:None;border-collapse:collapse;></table>');
                        if (data.d.length > 0) {
                            table.append($('<tr style=color:white;background-color:#006699;font-weight:bold;border:1px solid #ccc></tr>')
                               .append($('<th style=text-align:left>Codigo</th>'))
                               .append($('<th style=text-align:left>Descripcion</th>'))
                               .append($('<th style=text-align:left>Cantidad</th>'))
                                .append($('<th style=text-align:left>Unidad</th>'))
                               .append($('<th style=text-align:left>Precio</th>'))
                               .append($('<th style=text-align:left>Valor Vta.</th>'))
                               .append($('<th style=text-align:left>Igv</th>'))
                               .append($('<th style=text-align:left>Precio Vta.</th>'))
                               );

                            var sum = 0;
                            $.each(data.d, function (i, elem) {
                                table.append($('<tr style=color:#000066;></tr>')
                                     .append($('<td>' + elem['LD_CCODIGO'] + '</td>'))
                                     .append($('<td style=width:250px>' + elem['LD_CDESCRI'] + '</td>'))
                                     .append($('<td style=text-align:right>' + elem['LD_NCANTID'].toFixed(2) + '</td>'))
                                     .append($('<td style=text-align:center>' + elem['LD_CUNIDAD'] + '</td>'))
                                     .append($('<td style=text-align:right>' + elem['LD_NPRECIO'] + '</td>'))
                                     .append($('<td style=text-align:right>' + elem['LD_NIMPMN'] + '</td>'))
                                     .append($('<td style=text-align:right>' + elem['LD_NIGVMN'].toFixed(2) + '</td>'))
                                     .append($('<td style=text-align:right>' + elem['LD_NIMPMN'].toFixed(2) + '</td>'))//ACTUALIZACION
                                     );
                                Operacion.mask('gvDetalle').append(table);
                                sum += elem['LD_NCANTID'];
                            });
                            table.append($('<tr style=color:#000066;></tr>')
                                     .append($('<td></td>'))
                                     .append($('<td style=text-align:right;font-weight:bold;>Total KG</td>'))
                                     .append($('<td style=text-align:right;font-weight:bold;>' + sum.toFixed(2) + '</td>'))
                                     .append($('<td></td>'))
                                     .append($('<td></td>'))
                                     .append($('<td></td>'))
                                     .append($('<td></td>'))
                                     .append($('<td></td>'))
                                     );
                            //Operacion.mask('lblCKG').text(sum.toFixed(2));
                        } else {
                            //Operacion.mask('gvDetalle').empty();
                            //Operacion.mask('gvDetalle').append("<tr style='color:White;background-color:#006699;font-weight:bold;'><th align='center' scope='col' style='font-size:8pt;width:100px;'>ITEM</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>CODIGO</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>DESCRIPCION</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>UNID</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>SERIE</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>CANTIDAD REC.</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>PRECIO UNITARIO</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>DSCTO GEN.</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>PRECIO COSTO</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>IMPORTE TOTAL</th></tr>");
                            //$("#MainContent_gvDetalle").append("<tr style='color:White;background-color:#006699;font-weight:bold;'><th align='center' scope='col' style='font-size:8pt;width:100px;'>TD</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Nro Documento</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Mov</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Fecha Documento</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Proveedor</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Cliente</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Nombre</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>TDRef</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Doc Ref</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>TD Ref2</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Doc Ref2</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Glosa</th></tr>");
                            //Operacion.mask('gvDetalle').append("<tr><td style='font-size:8pt;'>-</td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td></tr>");
                        }

                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert(textStatus);
                    }
                });


            });
            var filtro = function () {
                $(".filtro tr:has(td)").each(function () {
                    var t = $(this).text();
                    $("<td class='indexColumn'></td>")
                    .hide().text(t).appendTo(this);
                    //console.log(t);
                });
            }
            $(".mipro").autocomplete(
            {   //listarAnexoID
                source: function (request, response) {
                    var TM = Operacion.mask('txtIDMOV').val();
                    var DATA = {};
                    DATA.AC_CVANEXO = "P";
                    DATA.AC_CCODIGO = '%' + request.term + '%';
                    DATA.AV_CDOCIDE = "1";
                    DATA.AC_CTIPOAC = "PL";

                    $.ajax({
                        url: "LiquidacionCompra.aspx/listaMaestroID",
                        data: '{DATA:' + JSON.stringify(DATA) + '}',
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: false,
                        success: function (data) {
                            //console.log(data);
                            response($.map(data.d, function (item) {
                                return {
                                    value: item.AC_CCODIGO.trim(),
                                    id: item.AC_CNOMBRE.trim()
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
                    Operacion.mask('txtPROD').val(str);
                },
                change: function (event, ui) {
                    if (ui.item == null || ui.item == undefined) {
                        alert("No ha seleccionado un proveedor valido");
                    }
                }
            });
            $(".miprod").autocomplete(
                {   /*PROVEEDORES*/
                    source: function (request, response) {
                        var TM = Operacion.mask('txtIDMOV').val();
                        var ADATA = {};
                        ADATA.AC_CVANEXO = "P";
                        ADATA.AC_CNOMBRE = '%' + request.term + '%';
                        ADATA.AV_CDOCIDE = 1;//VARIAR 1:PL|6:PU
                        ADATA.AC_CTIPOAC = "PL";
                        //ACTUALIZO CONSULTA PROVEEDOR
                        $.ajax({
                            url: "RegistroEntrada.aspx/getClienteT1",
                            data: '{ADATA:' + JSON.stringify(ADATA) + '}',
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            dataFilter: function (data) { return data; },
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        value: item.AC_CNOMBRE.trim(),//value: item.ADESANE,
                                        id: item.AC_CCODIGO.trim()//id: item.ACODANE.trim()
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
                        Operacion.mask('txtPRO').val(str);
                        //Operacion.mask('txtIDREF').focus();
                    },
                    change: function (event, ui) {
                        if (ui.item == null || ui.item == undefined) {
                            alert("No ha seleccionado un proveedor valido");
                            Operacion.mask('txtProveedor').focus();
                            Operacion.mask('txtProveedor').val('');
                            Operacion.mask('lblProveedor').text('');
                        }
                    }
                });

            Operacion.mask('txtPRO').change(function () {
                filtro();
                var s = $(this).val().toUpperCase().split(" ");
                $(".filtro tr:hidden").show();
                $.each(s, function () {
                    $(".filtro tr:visible .proveedor:not(:contains('" + this + "'))").parent().hide();
                    //&& $(".filtrar tr:visible .orden:not(:contains('" + this + "'))").parent().hide();
                });
            });
            Operacion.mask('txtNDO').change(function () {
                var s = $(this).val().toUpperCase().split(" ");
                $(".filtro tr:hidden").show();
                $.each(s, function () {
                    //$(".filtro tr:visible .proveedor:not(:contains('" + this + "'))").parent().hide() &&
                     $(".filtro tr:visible .orden:not(:contains('" + this + "'))").parent().hide();
                });
            });
        });
    </script>
    <style type="text/css">
        #contenedor {
            width: 1200px;
        }

        fieldset {
            width: 1150px;
        }

        .auto-style1 {
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:ScriptManager ID="scriptManager" runat="server" EnablePageMethods="true" />
    <div id="contenedor">
        <asp:HiddenField ID="hdUSUARIO" runat="server" />
        <asp:HiddenField ID="codM" runat="server" />
        <asp:HiddenField ID="codAL" runat="server" />
        <fieldset>
            <legend>Reimpresion - Documentos</legend>
            <table>
                <tr>
                    <td class="auto-style1">Tipo Anexo</td>
                    <td>
                        <asp:DropDownList ID="ddlTA" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style2">Proveedor&nbsp;</td>
                    <td colspan="7">
                        <asp:TextBox ID="txtPRO" class="mipro" runat="server" AutoPostBack="True" OnTextChanged="txtPRO_TextChanged"></asp:TextBox>
                        <asp:TextBox ID="txtPROD" class="miprod" runat="server" Width="456px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">Agencia&nbsp;</td>
                    <td>
                        <asp:DropDownList ID="ddlAGE" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style2">Fecha&nbsp;</td>
                    <td colspan="2">
                        <asp:TextBox ID="txtFEC" class="dp1" runat="server" OnTextChanged="txtFEC_TextChanged" AutoPostBack="true"></asp:TextBox>
                    </td>
                    <td class="auto-style3">Tipo Documento</td>
                    <td colspan="2">
                        <asp:TextBox ID="txtTDO" runat="server" Width="35px"></asp:TextBox>
                        Numero</td>
                    <td colspan="2">
                        <asp:TextBox ID="txtNDO" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1" colspan="11">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style1" colspan="8">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="11">
                        <div id="LoadingImage" style="display: none">
                            <img src="../Images/loading.gif" style="width: 15px;" />Cargando...
                        </div>
                        <asp:GridView ID="gvRD" class="filtro" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="LC_CCODAGE" HeaderText="Agencia" ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="50" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="LC_CTD" HeaderText="TD" ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="30" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="LC_CNUMDOC" HeaderText="Numero" ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle CssClass="orden"></ItemStyle>
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="LC_CVENDE" HeaderText="Fecha Doc." ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="LC_CRFTD" HeaderText="Fecha Venc." ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="LC_CCODPRV" HeaderText="Codigo" ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="90" />
                                    <ItemStyle CssClass="proveedor"></ItemStyle>
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="LC_CNOMBRE" HeaderText="Nombre" ItemStyle-HorizontalAlign="Left">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="LC_CFORVEN" HeaderText="Forma Vta." ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="Center" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="LC_CCODMON" HeaderText="Moneda" ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="70" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="LC_NIMPORT" HeaderText="Importe" ItemStyle-HorizontalAlign="Right">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="LC_CESTADO" HeaderText="Estado" ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="50" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="LC_CUSUCRE" HeaderText="Usuario" ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="60" />
                                    <ItemTemplate>
                                        <div class="btDetalle" style="text-align: center; display: inline;">
                                            <img alt="" src="../Images/Detalle.png" width="25" style="cursor: pointer" />
                                            <%--<asp:ImageButton ID="imbeliminar" runat="server" ImageUrl="~/Images/Message_Error.png" Width="25px" OnClick="ib_eliminar_Click" onclientclick="javascript:return confirm('Esta Seguro?')"/>--%>
                                        </div>
                                        <div class="btPrinter" style="text-align: center; display: inline;">
                                            <img alt="" src="../Images/Printer.png" width="25" style="cursor: pointer" />
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
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;
                        <!--<input id="btnNuevo" type="button" value="Registro Entrada OC" class="boton" />-->
                    </td>

                    <td>&nbsp;</td>

                    <td>&nbsp;</td>

                    <td>&nbsp;</td>

                    <td>&nbsp;</td>

                    <td>&nbsp;</td>

                    <td class="auto-style1" colspan="2">&nbsp;</td>

                </tr>
            </table>

        </fieldset>

    </div>
    <br />
    <div id="detalle" title="Detalle" style="display:none;">
        <table style="width: 100%;">
            <tr>
                <td colspan="2">&nbsp;</td>
                <td>
                    <asp:Label ID="lbldetalleTitulo" runat="server" Text=""></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>Fecha:<asp:Label ID="lbldFecha" runat="server" Text=""></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">Agencia</td>
                <td>
                    <asp:Label ID="lbldAGE" runat="server" Text=""></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>Estado</td>
                <td>
                    <asp:Label ID="lbldEST" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">Tipo Documento</td>
                <td>
                    <asp:Label ID="lbldTDO" runat="server" Text=""></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>Almacen</td>
                <td>
                    <asp:Label ID="lbldALM" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">Numero</td>
                <td>
                    <asp:Label ID="lbldNDO" runat="server" Text=""></asp:Label></td>
                <td>&nbsp;</td>
                <td>RUC</td>
                <td>
                    <asp:Label ID="lbldRUC" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">Cliente</td>
                <td>
                    <asp:Label ID="lbldCLI" runat="server" Text=""></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>Forma de Venta</td>
                <td>
                    <asp:Label ID="lbldFOR" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">Vendedor</td>
                <td>
                    <asp:Label ID="lbldVEN" runat="server" Text=""></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>Tipo Cambio</td>
                <td>
                    <asp:Label ID="lbldTIC" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">Referencia</td>
                <td>
                    <asp:Label ID="lbldREF" runat="server" Text=""></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>Moneda</td>
                <td>
                    <asp:Label ID="lbldMON" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">Glosa</td>
                <td>
                    <asp:Label ID="lbldGLO" runat="server" Text=""></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="6">
                    <asp:GridView ID="gvDetalle" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
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
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
</asp:Content>

















