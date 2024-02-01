<%@ Page Title="Aprobación de Programación" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="AprobacionProgramacion.aspx.cs" Inherits="FINANZAS_TESORERIA_PAGOS_AprobacionProgramacion" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link type="text/css" href="../../../CSS/base.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {


            $("#MainContent_txtfecha").datepicker();
            $("#MainContent_txtfechaprog").datepicker();
            $("#MainContent_txtvencimiento1").datepicker();
            $("#MainContent_txtvencimiento2").datepicker();

            $(window).load(function () {
                inicio = 0;
                verificacheck();
            });
            function tipocambiocompra() {

                $.ajax({

                    type: "POST",
                    url: "AprobacionProgramacion.aspx/obetenertcambiocvEdgar",
                    data: "",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        if (data.d.length > 0) {

                            for (var i = 0; i < data.d.length; i++) {

                                $('#MainContent_txttipocambio').val(data.d[i].XMEIMP);

                            }

                        }

                    },
                    error: function (data) {
                        if (data.length != 0)
                            alert(data);
                    }
                });
            }
            function tipocambioVenta() {

                $.ajax({

                    type: "POST",
                    url: "AprobacionProgramacion.aspx/obetenertcambiocvEdgar",
                    data: "",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        if (data.d.length > 0) {

                            for (var i = 0; i < data.d.length; i++) {

                                $('#MainContent_txttipocambio').val(data.d[i].XMEIMP2);

                            }

                        }

                    },
                    error: function (data) {
                        if (data.length != 0)
                            alert(data);
                    }
                });
            }
            function formato_numero(numero, decimales, separador_decimal, separador_miles) {
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


            function pad(str, max) {
                if (str != undefined) {
                    str = str.toString();
                    return str.length < max ? pad("0" + str, max) : str;
                }
            }

            $('#Modificacion').dialog({
                autoOpen: false,
                modal: true,
                resizable: true,
                width: 1100,
                heigth: 100,
                title: 'Consulta',
                close: function (event, ui) {

                },
            });

            $(".editar").click(function () {
                trp = $(this).parent().parent();
                id = $("td:eq(1)", trp).html();
                $("#Modificacion").dialog('open');
                document.getElementById("btnaprobar").style.visibility = "hidden";
                filtrardetalles(id);
                cabecera(id);
            });

            function filtrardetalles(codigo) {
                var long = 0;
                $.ajax({

                    type: "POST",
                    url: "AprobacionProgramacion.aspx/LISTARTTODOS",
                    data: "{ 'dato': '" + codigo + "' }",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        //console.log(data);
                        if (data.d.length > 0) {
                            var row = $("[id*=GridView1] tr:last-child").clone(true);
                            $("[id*=GridView1] tr").not($("[id*=GridView1] tr:first-child")).remove();

                            for (var i = 0; i < data.d.length; i++) {
                                $("td", row).eq(0).val(data.d[i].GD_CSECUE);
                                $("td", row).eq(0).html(data.d[i].GD_CVANEXO);
                                $("td", row).eq(1).html(data.d[i].GD_CCODIGO);
                                $("td", row).eq(2).html(data.d[i].GD_CNDREF);
                                $("td", row).eq(3).html(data.d[i].GD_CTIPDOC);
                                $("td", row).eq(4).html(data.d[i].GD_CNUMDOC);

                                $("td", row).eq(5).html((moment(data.d[i].GD_DFECDOC).format("DD/MM/YYYY")));
                                $("td", row).eq(6).html((moment(data.d[i].GD_DFECVEN).format("DD/MM/YYYY")));
                                $("td", row).eq(7).html(data.d[i].GD_CMONCAR);
                                $("td", row).eq(8).html(Number(data.d[i].GD_NORPROG).toFixed(2));
                                $("td", row).eq(10).html(Number(data.d[i].GD_NORRETE).toFixed(2));
                                $("td", row).eq(9).html(data.d[i].GD_CRETE);
                                $("td", row).eq(11).html(Number(data.d[i].GD_NMNPROG).toFixed(2));
                                long = data.d[i].GD_CTASDET.length;

                                $("td", row).eq(12).html("&nbsp;" + data.d[i].GD_CTASDET.substring(0, long - 15));

                                $("[id*=GridView1]").append(row);
                                row = $("[id*=GridView1] tr:last-child").clone(true);
                            }
                        } else {
                            var row = $("[id*=GridView1] tr:last-child").clone(true);
                            $("[id*=GridView1] tr").not($("[id*=GridView1] tr:first-child")).remove();

                            $("td", row).eq(1).html("");
                            $("td", row).eq(2).html("");
                            $("td", row).eq(3).html("");
                            $("td", row).eq(4).html("");
                            $("td", row).eq(5).html("");
                            $("td", row).eq(6).html("");
                            $("td", row).eq(7).html("");
                            $("td", row).eq(8).html("");
                            $("td", row).eq(9).html("");
                            $("td", row).eq(10).html("");
                            $("td", row).eq(11).html("");
                            $("td", row).eq(12).html("");
                            $("td", row).eq(0).html("");
                            $("[id*=GridView1]").append(row);
                            alert("no se encontro registro");
                        }


                    },
                    error: function (response) {
                        if (response.length != 0)
                            alert(response);
                    }
                });
            }

            function cabecera(codigo) {
                $.ajax({

                    type: "POST",
                    url: "AprobacionProgramacion.aspx/LISTARUNO",
                    data: "{ 'CODATA': '" + codigo + "' }",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {

                        if (data.d.length > 0) {

                            for (var i = 0; i < data.d.length; i++) {
                                $('#MainContent_lblcodagencia').html(data.d[i].AGENCIA);
                                $('#MainContent_lblagencia').html(data.d[i].AGENCIA2);
                                $('#MainContent_txtprogramacionmod').val(data.d[i].numope);
                                $('#MainContent_lblconcepto').html(data.d[i].CONCEPTO);
                                $('#MainContent_lbltipopago').html(data.d[i].tipopago);
                                $('#MainContent_lblmoneda').html(data.d[i].moneda);
                                $('#MainContent_txttipocambiomod').val(data.d[i].TIPOCAMBIO);
                                $('#MainContent_txtmontomod').val(Number(data.d[i].IMPORTE).toFixed(2));
                                $('#MainContent_txtfechaprogmod').val((moment(data.d[i].fecah).format("DD/MM/YYYY")));
                                if (data.d[i].TIPODETRACCION !=null) {
                                    long = data.d[i].TIPODETRACCION.length;
                                    $('#MainContent_lbldetraccion').html(data.d[i].TIPODETRACCION.substring(0, long - 15));
                                }                               
                                $('#MainContent_lbldetraccion').html(data.d[i].TIPODETRACCION);
                                $('#MainContent_lblcoddetraccion').html(data.d[i].TASADETRACCION);
                                $('#MainContent_lbldepartamento').html(data.d[i].DEPARTAMENTO);
                                $('#MainContent_lblcodbanco').html(data.d[i].CODBANCO);
                                $('#MainContent_lblbanco').html(data.d[i].BANCO);
                                $('#MainContent_txtestadomod').val(data.d[i].ESTADO);

                                $('#MainContent_lblusuelaborado').html(data.d[i].USUCRE);
                                $('#MainContent_lblusumodificado').html(data.d[i].USUMOD);
                                $('#MainContent_lblusuaprobado').html(data.d[i].USUAPRO);
                                $('#MainContent_lblfechaelaborado').html((moment(data.d[i].FECRE).format("DD/MM/YYYY")));
                                $('#MainContent_lblfechamodificacion').html((moment(data.d[i].FEMOD).format("DD/MM/YYYY")));
                                $('#MainContent_lblfechaaprobacion').html((moment(data.d[i].FEAPRO).format("DD/MM/YYYY")));

                                if (data.d[i].ESTADO.trim() == "APROBADA") {
                                    Operacion.inputEstado('btninconsistencias', 1, false);
                                    Operacion.inputEstado('btneliminar', 1, false);
                                }
                                else {
                                    Operacion.inputEstado('btninconsistencias', 0, false);
                                    Operacion.inputEstado('btneliminar', 0, false);
                                }
                            }
                        } else {

                            alert("no se encontro registro");
                        }


                    },
                    error: function (response) {
                        if (response.length != 0)
                            console.log(response);
                    }
                });
            }
            function InsertaLog(ind) {
                var f = new Date();
                var ADATA = {};
                ADATA.L2_CNUMOPE = $('#MainContent_txtprogramacionmod').val();
                ADATA.L2_CCODAGE = $('#MainContent_lblcodagencia').html();
                ADATA.L2_CUSUCRE = $('#MainContent_lblusuario').html();
                ADATA.L2_DFECCRE = f;


                if (ind == "A") {
                    ADATA.L2_CTIPTRA = "03";
                    ADATA.L2_CDESCRI = "Aprobación de Programación";
                    ADATA.L2_CORIGEN = "CPPROG10";

                }
                else {

                    ADATA.L2_CTIPTRA = "02";
                    ADATA.L2_CDESCRI = "Eliminación de Programación";
                    ADATA.L2_CORIGEN = "CPPROG04";
                }


                $.ajax({
                    type: "POST",
                    url: "AprobacionProgramacion.aspx/InsertaLog2",
                    data: '{ADATA: ' + JSON.stringify(ADATA) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        // alert("Aprobado, ya puede ejecutar la programación");
                        location.reload();
                    },
                    error: function (response) {
                        if (response.length != 0)
                            console.log(response);

                    }
                });
             }

            $(".Estado").click(function () {

                if ($('#MainContent_txtestadomod').val() == "APROBADA") {
                    alert("La programación ya ha sido aprobada");
                }

                else {
                    var DETA = {};
                    DETA.GC_CNUMOPE = $('#MainContent_txtprogramacionmod').val();
                    DETA.GC_CUSUAPR = $('#MainContent_lblusuario').html();
                    DETA.GC_CCODAGE = $('#MainContent_lblcodagencia').html();
                    $.ajax({
                        type: "POST",
                        url: "AprobacionProgramacion.aspx/actualizaEstado",
                        data: '{alumno: ' + JSON.stringify(DETA) + '}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (response) {
                            alert("Aprobado, ya puede ejecutar la programación");
                            InsertaLog("A");
                            location.reload();
                        },
                        error: function (response) {
                            if (response.length != 0)
                                console.log(response);

                        }
                    });
                    $("#Modificacion").dialog('close');
                }
            });

            $(".eliminar").click(function () {

                if ($('#MainContent_txtestadomod').val() == "APROBADA") {
                    alert("No es posible eliminar una programación que ya ha sido aprobada");

                }
                else {
                    if (confirm("Desea Eliminar la programación: " + $('#MainContent_txtprogramacionmod').val())) {
                        var DETA = {};
                        DETA.GC_CNUMOPE = $('#MainContent_txtprogramacionmod').val();
                        DETA.GC_CCODAGE = $('#MainContent_lblcodagencia').html();
                        InsertaLog("E");
                        $.ajax({
                            type: "POST",
                            url: "AprobacionProgramacion.aspx/ELIMINACABECERA",
                            data: '{alumno: ' + JSON.stringify(DETA) + '}',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            async: false,
                            success: function (response) {
                                alert("REGISTRO ELIMINADO");
                            },
                            error: function (response) {
                                if (response.length != 0)
                                    console.log(response);

                            }
                        });
                        var ADATA = {};
                        var gridView = document.getElementById("<%=GridView1.ClientID %>");
                        for (var t = 1; t < gridView.rows.length; t++) {

                            ADATA.GD_CNUMOPE = $('#MainContent_txtprogramacionmod').val();
                            ADATA.GD_CCODAGE = $('#MainContent_lblcodagencia').html();
                            ADATA.GD_CSECUE = gridView.rows[t].cells[0].value;

                            $.ajax({
                                type: "POST",
                                url: "AprobacionProgramacion.aspx/ELIMINADETALLE",
                                data: '{ADATA: ' + JSON.stringify(ADATA) + '}',
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                async: false,
                                success: function (data) {
                                },
                                error: function (response) {
                                    if (response.length != 0)
                                        console.log(response);
                                }
                            });
                        }
                        $("#Modificacion").dialog('close');
                    }
                }

            });

            $(".INCONSISTENCIACTADET").click(function () {
                inconsistenciactadet();
            });
            function inconsistenciactadet() {
                var ADATA = {};
                var cont = 0;

                var gridView = document.getElementById("<%=GridView1.ClientID %>");
                for (var t = 1; t < gridView.rows.length; t++) {
                    ADATA.AC_CVANEXO = gridView.rows[t].cells[0].innerHTML;
                    ADATA.AC_CCODIGO = gridView.rows[t].cells[1].innerHTML;
                    $.ajax({
                        type: "POST",
                        url: "AprobacionProgramacion.aspx/INCONSISTENCIACUENTADET",
                        data: '{ADATA: ' + JSON.stringify(ADATA) + '}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (data) {                          
                            if (data.d == "" ||  data.d == "xx") {
                                  cont = cont + 1;
                            }
                        },
                        error: function (response) {
                            if (response.length != 0)
                                console.log(response);
                        }
                    });
                }

                if (cont == 0) {
                    alert("No existen inconsistencias");
                    document.getElementById("btnaprobar").style.visibility = "visible";
                }
                else {
                    if (confirm("Se encontraron inconsistencias, para emitir el informe debe dar clic en el boton informe de la pantalla anterior" )) {
                  
                    }
                 document.getElementById("btnaprobar").style.visibility = "hidden";
                }
            }
            $(".LIMPIAR").click(function () {
                verificacheck();
            });
            function verificacheck() {
                if ((document.getElementById("<%=rbdia.ClientID%>").checked == true)) {

                     //  $('#MainContent_txtfecha').val("");
                     $('#MainContent_txtmes').val("");
                     $('#MainContent_txtannio').val("");
                     $("#MainContent_txtmes").attr("disabled", true);
                     $("#MainContent_txtannio").attr("disabled", true);
                     $("#MainContent_txtfecha").attr("disabled", false);
                 }
                 if ((document.getElementById("<%=rbmes.ClientID%>").checked == true)) {

                     $('#MainContent_txtfecha').val("");
                     // $('#MainContent_txtmes').val("");
                     $("#MainContent_txtmes").attr("disabled", false);
                     $("#MainContent_txtannio").attr("disabled", false);
                     $("#MainContent_txtfecha").attr("disabled", true);
                 }
            }
                $(".listar").click(function () {
                trp = $(this).parent().parent();
                id = $("td:eq(1)", trp).html();
                $('#MainContent_txtprogramacion').val(id);
               // alert($('#MainContent_txtprogramacion').val());
                var boton = document.getElementById("<%=btnlistar.ClientID%>");
                boton.click();
                
                });
            $(".inconsistencia").click(function () {
                trp = $(this).parent().parent();
                id = $("td:eq(1)", trp).html();
                $('#MainContent_txtprogramacion').val(id);
                var boton = document.getElementById("<%=btninconsistencias1.ClientID%>");
                boton.click();
                
            });

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
       fieldset{
           width:1050px;
       }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="contenedor">
        <div id="Creacion" title="Creación">

            <fieldset>
                <legend>
                    APROBACIÓN DE PROGRAMACIÓN DE PAGO
                </legend>

            <table>
                 <tr style="display:none">
                    <td>
                        <asp:Label ID="lblusuario" runat="server" ForeColor="#f1f1f1"></asp:Label>
                    </td>

                </tr>
                <tr>
                    <td class="auto-style1">
                        <input id="rbdia" name="opcion" type="radio" value="1" runat="server" class="LIMPIAR" />
                        Dia                                                <br />

                    </td>
                    <td>
                        <asp:TextBox ID="txtfecha" runat="server" Width="146px"></asp:TextBox>
                    </td>
                    <td>
                        <input id="rbmes" name="opcion" type="radio" value="2" runat="server" class="LIMPIAR" />Mes<br />
                    </td>
                    <td>
                        <asp:TextBox ID="txtmes" runat="server" Width="68px" MaxLength="2"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="txtannio" runat="server" Width="103px" MaxLength="4"></asp:TextBox></td>
                    <asp:Label ID="Label1" runat="server" ForeColor="#f1f1f1"></asp:Label>
                </tr>
            </table>
            <table>
                <tr>
                    <td>Agencia</td>
                    <td>
                        <asp:DropDownList ID="ddlagencia" runat="server" Height="16px" Width="371px"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Concepto</td>
                    <td>
                        <asp:DropDownList ID="ddlconcepto" runat="server" Height="16px" Width="371px"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Banco</td>
                    <td>
                        <asp:DropDownList ID="ddlbanco" runat="server" Height="16px" Width="371px"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Tipo Pago</td>
                    <td>
                        <asp:DropDownList ID="ddltipopago" runat="server" Height="16px" Width="371px"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Departamento</td>
                    <td>
                        <asp:DropDownList ID="ddldepartamento" runat="server" Height="16px" Width="371px"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnfiltro" runat="server" Text="Filtro" Width="76px" OnClick="btnfiltro_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnlistar" runat="server" OnClick="btnlistar_Click" Width="0px" BorderStyle="None" />
                        <asp:TextBox ID="txtprogramacion" runat="server" BorderStyle="None" Width="0px"></asp:TextBox>
                    &nbsp;<asp:Button ID="btninconsistencias1" runat="server" Text="inconsistencias" OnClick="btninconsistencias1_Click" Width="0px" BorderStyle="None" />
                    </td>
                </tr>

            </table>
                </fieldset>
            <table>
                <tr>
                    <td>
                        <asp:GridView ID="gvordencompra" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" OnRowCreated="griddata_RowCreated">
                            <Columns>
                                <asp:BoundField DataField="GC_CCODAGE" HeaderText="AGENCIA" />
                                <asp:BoundField DataField="GC_CNUMOPE" HeaderText="PROGRAMACION" />
                                <asp:BoundField DataField="GC_CUSUCRE" HeaderText="FECHA DE PROG">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="GC_CCODCON" HeaderText="CONCEPTO" />
                                <asp:BoundField DataField="GC_CTIPPAG" HeaderText="TIPO DE PAGO" />
                                <asp:BoundField DataField="GC_CCODBAN" HeaderText="BANCO" />
                                <asp:BoundField DataField="GC_CCODMON" HeaderText="MONEDA">

                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>

                                <asp:BoundField DataField="GC_NMONPRO" HeaderText="IMPORTE">
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="GC_CESTADO" HeaderText="ESTADO" />

                                <asp:TemplateField HeaderText="DETALLE">

                                    <ItemTemplate>
                                        <div class="editar" style="text-align: center">
                                            <img alt="" src="../../../Images/Detalle.png" width="25" style="cursor: pointer" />
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="LISTAR">

                                     <ItemTemplate>
                                        <div class="listar" style="text-align: center">
                                            <img alt="" src="../../../Images/exel.jpg" width="25" style="cursor: pointer" />
                                        </div>
                                    </ItemTemplate>

                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="INFORME">

                                     <ItemTemplate>
                                        <div class="inconsistencia" style="text-align: center">
                                            <img alt="" src="../../../Images/exel.jpg" width="25" style="cursor: pointer" />
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
        </div>
        <div id="Modificacion" style="display:none">
            <table>
                <tr>
                    <td>Agencia&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                    <td>
                        <asp:Label ID="lblcodagencia" runat="server" Text=""></asp:Label>
                        -
                        <asp:Label ID="lblagencia" runat="server" Text=""></asp:Label></td>
                    <td>Monto&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                    <td>
                        <asp:TextBox ID="txtmontomod" runat="server" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Num.Prog.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                    <td>
                        <asp:TextBox ID="txtprogramacionmod" runat="server" Width="170px" Enabled="false"></asp:TextBox>
                    </td>
                    <td>Fech. Prog.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                    <td>
                        <asp:TextBox ID="txtfechaprogmod" runat="server" Enabled="false"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td>Concepto&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                    <td>
                        <asp:Label ID="lblcodconcepto" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lblconcepto" runat="server" Text=""></asp:Label>
                    </td>

                    <td>Tipo Detracción:</td>
                    <td>
                        <asp:Label ID="lblcoddetraccion" runat="server" Text=""></asp:Label>-
                        <asp:Label ID="lbldetraccion" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Tipo Pago&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                    <td>
                        <asp:Label ID="lblcodtipopago" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lbltipopago" runat="server" Text=""></asp:Label>
                    </td>

                    <td>Departamento&nbsp; :</td>
                    <td>
                        <asp:Label ID="lblcoddepartamento" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lbldepartamento" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Moneda&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                    <td>
                        <asp:Label ID="lblcodmoneda" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lblmoneda" runat="server" Text=""></asp:Label>
                    </td>

                    <td>Banco&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                    <td>
                        <asp:Label ID="lblcodbanco" runat="server" Text=""></asp:Label>-
                        <asp:Label ID="lblbanco" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Tipo de Cambio:</td>
                    <td>
                        <asp:TextBox ID="txttipocambiomod" runat="server" Enabled="false"></asp:TextBox>

                    </td>
                    <td>Estado&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                    <td>
                        <asp:TextBox ID="txtestadomod" runat="server" Text="" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                </table>
                                    <table>
                <tr>
                    <td>Elaborado por:</td>
                    <td> <asp:Label ID="lblusuelaborado" runat="server" Text=""></asp:Label> </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;Fecha Elaboración</td>
                     <td> <asp:Label ID="lblfechaelaborado" runat="server" Text=""></asp:Label> </td>
                </tr>
                <tr>
                    <td>Modificado por:</td>
                    <td> <asp:Label ID="lblusumodificado" runat="server" Text=""></asp:Label> </td>
                     <td>&nbsp;&nbsp;&nbsp;&nbsp;Fecha Modificación</td>
                     <td> <asp:Label ID="lblfechamodificacion" runat="server" Text=""></asp:Label> </td>
                </tr>
                <tr>
                    <td>Aprobado por:</td>
                    <td> <asp:Label ID="lblusuaprobado" runat="server" Text=""></asp:Label> </td>
                     <td>&nbsp;&nbsp;&nbsp;&nbsp;Fecha Aprobación</td>
                     <td> <asp:Label ID="lblfechaaprobacion" runat="server" Text=""></asp:Label> </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <div style="overflow: auto; width: 1000px; height: 150px">
                            <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" OnRowCreated="griddata_RowCreated" Font-Size="Smaller" Width="969px">
                                <Columns>
                                    <asp:BoundField DataField="GD_CVANEXO" HeaderText="T" />
                                    <asp:BoundField DataField="GD_CCODIGO" HeaderText="CODIGO" />
                                    <asp:BoundField DataField="GD_CNDREF" HeaderText="NOMBRE">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="GD_CTIPDOC" HeaderText="TD" />
                                    <asp:BoundField DataField="GD_CNUMDOC" HeaderText="NRO. DOC" />
                                    <asp:BoundField DataField="GD_DFECDOC" HeaderText="FEC. DOC.">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="GD_DFECVEN" HeaderText="FEC. VENC.">

                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="GD_CMONCAR" HeaderText="MON">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="GD_NORPROG" HeaderText="PROGRAMADO">

                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="GD_NORRETE" HeaderText="T" />
                                    <asp:BoundField DataField="GD_CRETE" HeaderText="RETE">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="GD_NMNPROG" HeaderText="PROG. NETO">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="GD_CTASDET" HeaderText="TASA DETRA.">


                                        <HeaderStyle HorizontalAlign="Left" />
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
                        </div>
                    </td>

                </tr>
            </table>
            <table style="width: 177px">
                <tr>
                    <td>
                        <input id="btnaprobar" type="button" value="Aprobar" class="Estado" />
                    </td>
                    <td>
                        <input id="btninconsistencias" type="button" value="Inconsistencias" class="INCONSISTENCIACTADET" />
                    </td>
                    <td>
                        <input id="btneliminar" type="button" value="Eliminar" class="eliminar" />
                    </td>

                </tr>

            </table>
        </div>

    </div>
    <br />
</asp:Content>
