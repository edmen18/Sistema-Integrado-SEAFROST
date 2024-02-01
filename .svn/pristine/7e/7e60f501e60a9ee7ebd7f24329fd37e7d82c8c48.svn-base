<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SCreporte.aspx.cs" Inherits="Default2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link type="text/css" href="../../CSS/Base-s.css?2.5" rel="stylesheet" />

        <script type="text/javascript">
        $(window).load(function () {
           

        });
    </script>


    <script type="text/javascript">
        $(function () {
   
            $("#MainContent_txtfini").datepicker();
            $("#MainContent_txtffin").datepicker();
  
        $('#impresionsend').dialog({
            autoOpen: false,
            modal: true,
            resizable: false,
            width: 330,
            heigth: 250,
            title: 'Impresion de Pedido',
            open: function (event, ui) {
                $(this).parent().appendTo("form");
                $("#MainContent_inidpedido").attr("value", idpedido);
            },
            close: function (event, ui) {}
        });

            //popup reimprimir
        $('#reimprime').dialog({
            autoOpen: false,
            modal: true,
            resizable: false,
            width: 330,
            heigth: 250,
            title: 'Reimprimir Guia',
            open: function (event, ui) {
                $(this).parent().appendTo("form");
                //cargargrid(pedidosv);

                //filtarcantidademb(pedidosv);

                $("#MainContent_hfserie").val(idserie);
                $("#MainContent_txtnguia").val(idguia);
                //if (cantidademb > 110) {
                //    alert("EL PESO EXCEDE EN BASE AL PEDIDO");
                //    $('#reimprime').dialog('close');
                //}
            },
            close: function (event, ui) {
                $("#MainContent_txtnguia").val("");
            }
        });

        });

    </script>
    <script type="text/javascript">
        $(function () {
            $(".imppedido").click(function () {
                trp = $(this).parent().parent();
                idpedido = $("td:eq(1)", trp).html();
                $('#impresionsend').dialog('open');
            });

            $(".btexcel").click(function () {
               
            });

            $(".impguia").click(function () {
                idserie = "";
                pedidosv = "";
                trp = $(this).parent().parent();
                idguia = $("td:eq(1)", trp).html();
                idserie = idguia.substr(0, 4);
                pedidosv = $("td:eq(4)", trp).html();
                $('#reimprime').dialog('open');

            });


            $(".dfp").click(function () {
                $("#MainContent_hfestadoP").val("");
                $("#MainContent_hfestadoG").val("");
                $("#MainContent_hfestadoF").val("1");
                $("#fotocargando").show();
                $("#dvguias").hide();
                $("#dvpedido").hide();
                $("#dvfactura").show(800);
                $("#dvfactura").show("slow");
                var f01 = $("#MainContent_txtfini").val();
                var f02 = $("#MainContent_txtffin").val();
                Lstfacturas(f01,f02,"1","FT");
            });

            $(".dfsp").click(function () {
                $("#MainContent_hfestadoP").val("");
                $("#MainContent_hfestadoG").val("");
                $("#MainContent_hfestadoF").val("0");
                $("#fotocargando").show();
                $("#dvguias").hide();
                $("#dvpedido").hide();
                $("#dvfactura").show(800);
                $("#dvfactura").show("slow");
                var f01 = $("#MainContent_txtfini").val();
                var f02 = $("#MainContent_txtffin").val();
                Lstfacturas(f01, f02, "0", "FT");
            });

            $(".dbp").click(function () {
                $("#MainContent_hfestadoP").val("");
                $("#MainContent_hfestadoG").val("");
                $("#MainContent_hfestadoF").val("");
                $("#MainContent_hfestadoB").val("1");
                $("#fotocargando").show();
                $("#dvguias").hide();
                $("#dvpedido").hide();
                $("#dvfactura").hide();
                $("#dvboleta").show(800);
                $("#dvboleta").show("slow");
                var f01 = $("#MainContent_txtfini").val();
                var f02 = $("#MainContent_txtffin").val();
                Lstboletas(f01, f02, "1", "BV");
            });

            $(".dbsp").click(function () {
                $("#MainContent_hfestadoP").val("");
                $("#MainContent_hfestadoG").val("");
                $("#MainContent_hfestadoF").val("");
                $("#MainContent_hfestadoB").val("0");
                $("#fotocargando").show();
                $("#dvguias").hide();
                $("#dvpedido").hide();
                $("#dvfactura").hide();
                $("#dvboleta").show(800);
                $("#dvboleta").show("slow");
                var f01 = $("#MainContent_txtfini").val();
                var f02 = $("#MainContent_txtffin").val();
                Lstboletas(f01, f02, "0", "BV");
            });
            


            $(".detalleapro").click(function () {
                $("#MainContent_hfestadoP").val("A");
                $("#MainContent_hfestadoG").val("");
                $("#MainContent_hfestadoF").val("");
                $("#fotocargando").show();
                $("#dvfactura").hide();
                $("#dvguias").hide();
                $("#dvpedido").show(800);
                $("#dvpedido").show("slow");
                LstPedidos("A");
            });

            $(".detallepen").click(function () {
                $("#MainContent_hfestadoP").val("P");
                $("#MainContent_hfestadoG").val("");
                $("#MainContent_hfestadoF").val("");
                $("#fotocargando").show();
                $("#dvfactura").hide();
                $("#dvguias").hide();
                $("#dvpedido").show(800);
                $("#dvpedido").show("slow");
                LstPedidos("P");
            });
            
            $(".dguiasf").click(function () {
                $("#MainContent_hfestadoP").val("");
                $("#MainContent_hfestadoG").val("F");
                $("#MainContent_hfestadoF").val("");
                $("#fotocargando").show();
                $("#dvfactura").hide();
                $("#dvpedido").hide();
                $("#dvguias").show(800);
                $("#dvguias").show("slow");
                var f01 = $("#MainContent_txtfini").val();
                var f02 = $("#MainContent_txtffin").val();
                Lstguiass(f01,f02,"F");
            });
            
            $(".dguiassf").click(function () {
                $("#MainContent_hfestadoP").val("");
                $("#MainContent_hfestadoG").val("V");
                $("#MainContent_hfestadoF").val("");
                $("#fotocargando").show();
                $("#dvfactura").hide();
                $("#dvpedido").hide();
                $("#dvguias").show(800);
                $("#dvguias").show("slow");
                var f01 = $("#MainContent_txtfini").val();
                var f02 = $("#MainContent_txtffin").val();
                Lstguiass(f01, f02, "V");
            });
            
        });
    </script>
    <script type="text/javascript">

        function fnCopyReport(nomgrid) {
            var tab_text = "<table><tr>";
            var textRange;
            tab = document.getElementById(nomgrid); // id of actual table on your page
            for (j = 0 ; j < tab.rows.length ; j++) {
                tab_text = tab_text + tab.rows[j].innerHTML;
                tab_text = tab_text + "</tr><tr>";
            }
            tab_text = tab_text + "</tr></table>";
            txtArea1.document.open("txt/html", "replace");
            txtArea1.document.write(tab_text);
            txtArea1.document.close();
            txtArea1.focus();
            sa = txtArea1.document.execCommand("SaveAs", true, "sample.xls");
            return (sa);
        }

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

            if (separador_miles) {
                // Añadimos los separadores de miles
                var miles = new RegExp("(-?[0-9]+)([0-9]{3})");
                while (miles.test(numero)) {
                    numero = numero.replace(miles, "$1" + separador_miles + "$2");
                }
            }

            return numero;
        }

        function LstPedidos(EST) {
            gidpped = "";
            cantped = 0;
            $.ajax({
                url: "SCreporte.aspx/FlistaPedidos",
                data: "{ EST:'" + EST + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                async:false,
                load: function (data) { },
                success: function (data) {
                    if (data.d.length > 0) {
                        var rowce = $("[id*=gridpeda] tr:last-child").clone(true);
                        $("[id*=gridpeda] tr").not($("[id*=gridpeda] tr:first-child")).remove();
                        for (var i = 0; i < data.d.length; i++) {
                            var imprr = data.d[i].F5_NIMPORT;
                            imprr = imprr.toFixed(2);
                            $("td", rowce).eq(0).html(Number(i) + 1);
                            $("td", rowce).eq(1).html(data.d[i].F5_CNUMPED);
                            $("td", rowce).eq(1).val(data.d[i].F5_CNUMPED);
                            $("td", rowce).eq(2).html(data.d[i].F5_DFECDOC);
                            $("td", rowce).eq(3).html(data.d[i].F5_CNOMBRE.toUpperCase());
                            $("td", rowce).eq(4).html(data.d[i].FV_CDESCRI);
                            $("td", rowce).eq(5).html(data.d[i].F5_CCODMON);
                            $("td", rowce).eq(6).html(formato_numero(imprr, 2, ".", ","));
                            $("td", rowce).eq(7).html(data.d[i].TG_CDESCRI);
                            $("td", rowce).eq(8).html(data.d[i].XEMBARC);
                            var almacen = data.d[i].F5_CALMA == "0002" ? "CONGELADO" : data.d[i].F5_CALMA == "0003" ?"CONSERVA":"HARINA";
                            $("td", rowce).eq(9).html( almacen);
                            cantped = data.d[i].F6_NCANTID;
                            var diaspa = Number(data.d[i].DIASFE);
                            gidpped = data.d[i].F5_CNUMPED;
                            cantidademb = data.d[i].XEMBARC;
                            $("[id*=gridpeda]").append(rowce);
                            rowce = $("[id*=gridpeda] tr:last-child").clone(true);
                        }
                    } else {
                        var row = $("[id*=gridpeda] tr:last-child").clone(true);
                        $("[id*=gridpeda] tr").not($("[id*=gridpeda] tr:first-child")).remove();
                        $("td", row).eq(0).html("");
                        $("td", row).eq(1).html("");
                        $("td", row).eq(2).html("");
                        $("td", row).eq(3).html("");
                        $("td", row).eq(4).html("");
                        $("td", row).eq(5).html("");
                        $("td", row).eq(6).html("");
                        $("td", row).eq(7).html("");
                        $("td", row).eq(8).html("");
                        $("td", row).eq(9).html("");
                        $("[id*=gridpeda]").append(row);
                    }
                    $('#fotocargando').hide();
                }
            });
        }

        function Lstguiass(f1,f2,EST) {
            $.ajax({
                url: "SCreporte.aspx/FlistaGuias",
                data: "{f1:'" + f1 + "',f2:'" + f2 + "', EST:'" + EST + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                async: false,
                load: function (data) { },
                success: function (data) {
                    if (data.d.length > 0) {
                        var rowce = $("[id*=gvguias] tr:last-child").clone(true);
                        $("[id*=gvguias] tr").not($("[id*=gvguias] tr:first-child")).remove();
                        for (var i = 0; i < data.d.length; i++) {
                            $("td", rowce).eq(0).html(Number(i) + 1);
                            $("td", rowce).eq(1).html(data.d[i].C5_CNUMDOC);
                            $("td", rowce).eq(1).val(data.d[i].C5_CNUMDOC);
                            $("td", rowce).eq(2).html(data.d[i].C5_DFECDOC);
                            $("td", rowce).eq(3).html(data.d[i].C5_CNOMCLI.toUpperCase());
                            $("td", rowce).eq(4).html(data.d[i].C5_CNUMPED);
                            var almacen = data.d[i].C5_CALMA == "0002" ? "CONGELADO" : data.d[i].C5_CALMA == "0003" ? "CONSERVA" : "HARINA";
                            $("td", rowce).eq(5).html(almacen);
                            $("[id*=gvguias]").append(rowce);
                            rowce = $("[id*=gvguias] tr:last-child").clone(true);
                        }
                    } else {
                        var row = $("[id*=gvguias] tr:last-child").clone(true);
                        $("[id*=gvguias] tr").not($("[id*=gvguias] tr:first-child")).remove();
                        $("td", row).eq(0).html("");
                        $("td", row).eq(1).html("");
                        $("td", row).eq(2).html("");
                        $("td", row).eq(3).html("");
                        $("td", row).eq(4).html("");
                        $("td", row).eq(5).html("");
                        $("[id*=gvguias]").append(row);
                    }
                     $('#fotocargando').hide();
                }
            });
        }

        function Lstfacturas(f1, f2, EST, TDOC) {
            $.ajax({
                url: "SCreporte.aspx/FlistaFacturas",
                data: "{f1:'" + f1 + "',f2:'" + f2 + "', EST:'" + EST + "',TDOC:'"+TDOC+"'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                async: false,
                load: function (data) {  },
                success: function (data) {
                    if (data.d.length > 0) {
                        var rowce = $("[id*=gvfactura] tr:last-child").clone(true);
                        $("[id*=gvfactura] tr").not($("[id*=gvfactura] tr:first-child")).remove();
                        for (var i = 0; i < data.d.length; i++) {
                            $("td", rowce).eq(0).html(Number(i) + 1);
                            $("td", rowce).eq(1).html(data.d[i].F5_CNUMSER+"-"+data.d[i].F5_CNUMDOC);
                            $("td", rowce).eq(1).val(data.d[i].F5_CNUMDOC);
                            $("td", rowce).eq(2).html(moment(data.d[i].F5_DFECDOC).format("DD/MM/YYYY"));
                            $("td", rowce).eq(3).html(data.d[i].F5_CNOMBRE.toUpperCase());
                            $("td", rowce).eq(4).html(data.d[i].F5_CCODMON);
                            $("td", rowce).eq(5).html(formato_numero(data.d[i].F5_NIMPORT, 2, ".", ","));
                            var almacen = data.d[i].F5_CALMA == "0002" ? "CONGELADO" : data.d[i].F5_CALMA == "0003" ? "CONSERVA" : "HARINA";
                            $("td", rowce).eq(6).html(almacen);
                            $("[id*=gvfactura]").append(rowce);
                            rowce = $("[id*=gvfactura] tr:last-child").clone(true);
                        }
                        
                    } else {
                        var row = $("[id*=gvfactura] tr:last-child").clone(true);
                        $("[id*=gvfactura] tr").not($("[id*=gvfactura] tr:first-child")).remove();
                        $("td", row).eq(0).html("");
                        $("td", row).eq(1).html("");
                        $("td", row).eq(2).html("");
                        $("td", row).eq(3).html("");
                        $("td", row).eq(4).html("");
                        $("td", row).eq(5).html("");
                        $("[id*=gvfactura]").append(row);
                    }
                    $('#fotocargando').hide();
                }
            });
        }

        function Lstboletas(f1, f2, EST, TDOC) {
            $.ajax({
                url: "SCreporte.aspx/FlistaFacturas",
                data: "{f1:'" + f1 + "',f2:'" + f2 + "', EST:'" + EST + "',TDOC:'" + TDOC + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                async: false,
                load: function (data) { },
                success: function (data) {
                    if (data.d.length > 0) {
                        var rowce = $("[id*=gvboleta] tr:last-child").clone(true);
                        $("[id*=gvboleta] tr").not($("[id*=gvboleta] tr:first-child")).remove();
                        for (var i = 0; i < data.d.length; i++) {
                            $("td", rowce).eq(0).html(Number(i) + 1);
                            $("td", rowce).eq(1).html(data.d[i].F5_CNUMSER + "-" + data.d[i].F5_CNUMDOC);
                            $("td", rowce).eq(1).val(data.d[i].F5_CNUMDOC);
                            $("td", rowce).eq(2).html(moment(data.d[i].F5_DFECDOC).format("DD/MM/YYYY"));
                            $("td", rowce).eq(3).html(data.d[i].F5_CNOMBRE.toUpperCase());
                            $("td", rowce).eq(4).html(data.d[i].F5_CCODMON);
                            $("td", rowce).eq(5).html(formato_numero(data.d[i].F5_NIMPORT, 2, ".", ","));
                            var almacen = data.d[i].F5_CALMA == "0002" ? "CONGELADO" : data.d[i].F5_CALMA == "0003" ? "CONSERVA" : "HARINA";
                            $("td", rowce).eq(6).html(almacen);
                            $("[id*=gvboleta]").append(rowce);
                            rowce = $("[id*=gvboleta] tr:last-child").clone(true);
                        }

                    } else {
                        var row = $("[id*=gvboleta] tr:last-child").clone(true);
                        $("[id*=gvboleta] tr").not($("[id*=gvboleta] tr:first-child")).remove();
                        $("td", row).eq(0).html("");
                        $("td", row).eq(1).html("");
                        $("td", row).eq(2).html("");
                        $("td", row).eq(3).html("");
                        $("td", row).eq(4).html("");
                        $("td", row).eq(5).html("");
                        $("[id*=gvboleta]").append(row);
                    }
                    $('#fotocargando').hide();
                }
            });
        }
    </script>

<%--    <style type="text/css">
        .FixedHeader {
            position: absolute;
            font-weight: bold;
        }     
    </style>--%>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
     <asp:HiddenField runat="server" ID="hfestadoP"/>
     <asp:HiddenField runat="server" ID="hfestadoG"/>
     <asp:HiddenField runat="server" ID="hfestadoF"/>
    <asp:HiddenField runat="server" ID="hfestadoB"/>

    <fieldset style="width:98%;align-content:left;">
    <table>
        <tr>
            <td>  <b><u> REPORTE GENERAL:</u></b> </td>
        </tr>
        </table>
        
                <table>

                    <tr>
                        <td>Fecha Inicio</td>
                        <td>
                            <asp:TextBox ID="txtfini" runat="server" Width="90"></asp:TextBox>
                        </td>
                        <td>Fecha Fin</td>
                        <td>
                            <asp:TextBox ID="txtffin" runat="server" Width="90"></asp:TextBox>
                        </td>
                        <td></td>
                        <td colspan="2">
                            <asp:Button runat="server" ID="btbusqueda" class="btn" UseSubmitBehavior="false" Text="Buscar." OnClick="btbusqueda_Click" />
                        </td>
                        <td colspan="2" style="text-align:right">
                            <%--<input class="btexcel btn" type="button" value="Excel" />--%>
                            <asp:Button Text="Excel" runat="server" ID="btexc" class="btn" UseSubmitBehavior="false" OnClick="btexc_Click" />
                        </td>
                        <td></td>


                    </tr>

                    <tr>
                        <td colspan="5">Pedidos</td>
                    </tr>
                    <tr>
                      
                        <td colspan="5" style="vertical-align:top">
                           
                            <asp:GridView ID="gridpedido" BackColor="White"  runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                HeaderStyle-BackColor="#006699" HeaderStyle-ForeColor="White" HeaderStyle-Height="20"
                                OnRowCreated="griddata_RowCreated"  Height="69px" Width="352px" Font-Size="Smaller">
                                <Columns>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" >
                                        <ItemTemplate>
                                            <asp:Label runat="server" Text="CANTIDAD"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField ItemStyle-Width="150px" DataField="aprobados" HeaderText="APROBADOS" ItemStyle-HorizontalAlign="Center">
                                        <ItemStyle Width="100px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <div id="det" class="detalleapro" style="cursor:pointer" >
                                                <image src="../../Images/historial.png" height="20" />
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField ItemStyle-Width="150px" DataField="Pendientes" HeaderText="PENDIENTES" ItemStyle-HorizontalAlign="Center">
                                        <ItemStyle Width="100px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <div id="det" class="detallepen" style="cursor:pointer">
                                                <image src="../../Images/historial.png" height="20" />
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />

                            </asp:GridView>
                            Guia de Remsion
                             <asp:GridView ID="gridguia" runat="server" AutoGenerateColumns="False" BackColor="White" 
                                HeaderStyle-BackColor="#006699" HeaderStyle-ForeColor="White" HeaderStyle-Height="20"
                                OnRowCreated="griddata_RowCreated" SelectedRowStyle-ForeColor="#FBA16C" Height="69px" Width="352px" Font-Size="Smaller">
                                <Columns>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text="CANTIDAD"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField ItemStyle-Width="150px" DataField="aprobados" HeaderText="FACTURADOS" ItemStyle-HorizontalAlign="Center">
                                        <ItemStyle Width="100px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <div id="det" class="dguiasf">
                                                <image src="../../Images/historial.png" height="20" style="cursor:pointer"/>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField ItemStyle-Width="150px" DataField="Pendientes" HeaderText="SIN FACTURAS" ItemStyle-HorizontalAlign="Center">
                                        <ItemStyle Width="100px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <div id="det" class="dguiassf">
                                                <image src="../../Images/historial.png" height="20" style="cursor:pointer" />
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>

                            </asp:GridView>
                     Facturas
                            <asp:GridView ID="gridfacturas" runat="server" AutoGenerateColumns="False" BackColor="White" 
                                HeaderStyle-BackColor="#006699" HeaderStyle-ForeColor="White" HeaderStyle-Height="20"
                                OnRowCreated="griddata_RowCreated" SelectedRowStyle-ForeColor="#FBA16C" Height="69px" Width="352px" Font-Size="Smaller">
                                <Columns>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text="CANTIDAD"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField ItemStyle-Width="150px" DataField="aprobados" HeaderText="PAGADAS"  ItemStyle-HorizontalAlign="Center">
                                        <ItemStyle Width="100px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <div id="det" class="dfp">
                                                <image src="../../Images/historial.png" height="20"  style="cursor:pointer"/>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField ItemStyle-Width="150px" DataField="Pendientes" HeaderText="SIN PAGAR"  ItemStyle-HorizontalAlign="Center">
                                        <ItemStyle Width="100px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <div id="det" class="dfsp">
                                                <image src="../../Images/historial.png" height="20"  style="cursor:pointer"/>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>

                            </asp:GridView>
                            Boletas
                            <asp:GridView ID="gridboletas" runat="server" AutoGenerateColumns="False" BackColor="White" 
                                HeaderStyle-BackColor="#006699" HeaderStyle-ForeColor="White" HeaderStyle-Height="20"
                                OnRowCreated="griddata_RowCreated" SelectedRowStyle-ForeColor="#FBA16C" Height="69px" Width="352px" Font-Size="Smaller">
                                <Columns>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text="CANTIDAD"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField ItemStyle-Width="150px" DataField="aprobados" HeaderText="PAGADAS"  ItemStyle-HorizontalAlign="Center">
                                        <ItemStyle Width="100px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <div id="det" class="dbp">
                                                <image src="../../Images/historial.png" height="20"  style="cursor:pointer"/>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField ItemStyle-Width="150px" DataField="Pendientes" HeaderText="SIN PAGAR"  ItemStyle-HorizontalAlign="Center">
                                        <ItemStyle Width="100px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <div id="det" class="dbsp">
                                                <image src="../../Images/historial.png" height="20"  style="cursor:pointer"/>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>

                            </asp:GridView>
                              <div id="fotocargando" style="text-align:center;display:none">
                <img src="../../Images/loading.gif" style="height: 20px; width: 24px">
     </div>
                        </td>
                  <td></td>
                      <td rowspan="8" colspan="2" style="vertical-align:top">
                            <div id="dvpedido" style="overflow: auto; width: 850px; height: 450px;display:none"  >
                                 <asp:GridView ID="gridpeda" runat="server" AutoGenerateColumns="False"  BackColor="White" 
                                    HeaderStyle-BackColor="#006699" HeaderStyle-ForeColor="White" HeaderStyle-Height="20"
                                     SelectedRowStyle-ForeColor="#FBA16C" Height="69px" Width="766px" Font-Size="Smaller">
                                    <Columns>
                                        <asp:BoundField ItemStyle-Width="150px" DataField="D01" HeaderText="N°">
                                            <ItemStyle Width="40px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="150px" DataField="D02" HeaderText="N PEDIDO">
                                            <ItemStyle Width="100px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="150px" DataField="D03" HeaderText="F. DOC">
                                            <ItemStyle Width="80px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="150px" DataField="D04" HeaderText="CLIENTE">
                                            <ItemStyle Width="200px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="150px" DataField="D05" HeaderText="F.VTA">
                                            <ItemStyle Width="270px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="150px" DataField="D06" HeaderText="M">
                                            <ItemStyle Width="30px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="150px" DataField="D07" HeaderText="IMPORTE" ItemStyle-HorizontalAlign="Right">
                                            <ItemStyle Width="90px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="150px" DataField="D08" HeaderText="ESTADO">
                                            <ItemStyle Width="90px" HorizontalAlign="Center"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="150px" DataField="D09" HeaderText="ATENCION.%" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle Width="60px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="150px" DataField="D10" HeaderText="AREA">
                                            <ItemStyle Width="60px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div  class="imppedido" style="cursor:pointer">
                                                    <image src="../../Images/Printer.png" style="width: 23px;"/>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>



                                    </Columns>
                                </asp:GridView>
                        </div>

                            <div id="dvguias" style="overflow: auto; width: 850px; height: 450px;display:none" >
                                 <asp:GridView ID="gvguias" runat="server" AutoGenerateColumns="False" BackColor="White" 
                                    HeaderStyle-BackColor="#006699" HeaderStyle-ForeColor="White" HeaderStyle-Height="20"
                                     SelectedRowStyle-ForeColor="#FBA16C" Height="69px" Width="766px" Font-Size="Smaller">
                                    <Columns>
                                        <asp:BoundField ItemStyle-Width="150px" DataField="D01" HeaderText="N°">
                                            <ItemStyle Width="40px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="150px" DataField="D02" HeaderText="N GUIA">
                                            <ItemStyle Width="120px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="150px" DataField="D03" HeaderText="F. DOC">
                                            <ItemStyle Width="80px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="150px" DataField="D04" HeaderText="CLIENTE">
                                            <ItemStyle Width="700px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="150px" DataField="D05" HeaderText="NUM PEDIDO">
                                            <ItemStyle Width="270px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="150px" DataField="D06" HeaderText="AREA">
                                            <ItemStyle Width="300px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div  class="impguia" style="cursor:pointer">
                                                    <image src="../../Images/Printer.png" style="width: 23px;"/>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>



                                    </Columns>
                                </asp:GridView>
                        </div>


                           <div id="dvfactura" style="overflow: auto; width: 850px; height: 450px;display:none" >
                                 <asp:GridView ID="gvfactura" runat="server" AutoGenerateColumns="False" BackColor="White" 
                                    HeaderStyle-BackColor="#006699" HeaderStyle-ForeColor="White" HeaderStyle-Height="20"
                                     SelectedRowStyle-ForeColor="#FBA16C" Height="69px" Width="766px" Font-Size="Smaller">
                                    <Columns>
                                        <asp:BoundField ItemStyle-Width="150px" DataField="D01" HeaderText="N°">
                                            <ItemStyle Width="40px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="150px" DataField="D02" HeaderText="N FACTURA">
                                            <ItemStyle Width="120px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="150px" DataField="D03" HeaderText="F. DOC">
                                            <ItemStyle Width="80px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="150px" DataField="D04" HeaderText="CLIENTE">
                                            <ItemStyle Width="700px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="150px" DataField="D05" HeaderText="M">
                                            <ItemStyle Width="270px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="150px" DataField="D06" HeaderText="IMPORTE" ItemStyle-HorizontalAlign="Right">
                                            <ItemStyle Width="300px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="150px" DataField="D07" HeaderText="AREA" ItemStyle-HorizontalAlign="Right">
                                            <ItemStyle Width="300px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div  class="impfactura" style="cursor:pointer">
                                                    <image src="../../Images/Printer.png" style="width: 23px;" />
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>



                                    </Columns>
                                </asp:GridView>
                        </div>

                               <div id="dvboleta" style="overflow: auto; width: 850px; height: 450px;display:none" >
                                 <asp:GridView ID="gvboleta" runat="server" AutoGenerateColumns="False" BackColor="White" 
                                    HeaderStyle-BackColor="#006699" HeaderStyle-ForeColor="White" HeaderStyle-Height="20"
                                     SelectedRowStyle-ForeColor="#FBA16C" Height="69px" Width="766px" Font-Size="Smaller">
                                    <Columns>
                                        <asp:BoundField ItemStyle-Width="150px" DataField="D01" HeaderText="N°">
                                            <ItemStyle Width="40px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="150px" DataField="D02" HeaderText="N BOLETA">
                                            <ItemStyle Width="120px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="150px" DataField="D03" HeaderText="F. DOC">
                                            <ItemStyle Width="80px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="150px" DataField="D04" HeaderText="CLIENTE">
                                            <ItemStyle Width="700px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="150px" DataField="D05" HeaderText="M">
                                            <ItemStyle Width="270px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="150px" DataField="D06" HeaderText="IMPORTE" ItemStyle-HorizontalAlign="Right">
                                            <ItemStyle Width="300px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="150px" DataField="D07" HeaderText="AREA" ItemStyle-HorizontalAlign="Right">
                                            <ItemStyle Width="300px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div  class="impfactura" style="cursor:pointer">
                                                    <image src="../../Images/Printer.png" style="width: 23px;" />
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>



                                    </Columns>
                                </asp:GridView>
                        </div>
                                </td>
                   
                   
                     
                    </tr>
                </table>
         </fieldset>

            <div id="impresionsend"  style="display:none">
        <table>
             <tr>
                 <td>Pedido:</td>
                 <td>
                     <input type="text" id="inidpedido" runat="server" readonly="readonly"  />
                 </td>
             </tr>
            <tr>
                <td colspan="2">
                    <asp:Button class="btn" ID="bttimprimir" runat="server" Width="300" Text="Imprimir" OnClick="bttimprimir_Click"   />
                </td>
            </tr>
        </table>
    </div>


        <div id="reimprime" style="display:none">
        <asp:HiddenField ID="hfserie" runat="server"/>
        <table>
            <tr>
                
                <td>N Guia</td>
                <td>
                    <input id="txtnguia" type="text" runat="server" readonly="readonly" />
                </td>
           
           </tr><tr>
                <td colspan="2">
                    <asp:Button runat="server" class="btn" ID="btimp" Width="300" Text="Imprimir Guia" OnClick="btimprimir_Click" Height="29px"  />
                </td>
               </tr>  
           
        </table>
   
    </div>

     </asp:Content>

