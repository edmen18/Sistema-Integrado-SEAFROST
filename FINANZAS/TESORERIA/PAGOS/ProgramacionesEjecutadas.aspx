<%@ Page Title="Programaciones Ejecutadas" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ProgramacionesEjecutadas.aspx.cs" Inherits="FINANZAS_TESORERIA_PAGOS_ProgramacionesEjecutadas" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link type="text/css" href="../../../CSS/base.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {
            $("#MainContent_txtfecha").datepicker();
            $("#MainContent_txtfechaprog").datepicker();
            $("#MainContent_txtvencimiento1").datepicker();
            $("#MainContent_txtvencimiento2").datepicker();


            function tipocambiocompra() {

                $.ajax({

                    type: "POST",
                    url: "ProgramacionesEjecutadas.aspx/obetenertcambiocvEdgar",
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
                    url: "ProgramacionesEjecutadas.aspx/obetenertcambiocvEdgar",
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
                width: 1000,
                heigth: 100,
                title: 'Consulta',
                close: function (event, ui) {

                },
            });
            $(".editar").click(function () {
                trp = $(this).parent().parent();
                id = $("td:eq(1)", trp).html();
                $("#Modificacion").dialog('open');
              //  document.getElementById("btnaprobar").style.visibility = "hidden";
                filtrardetalles(id);
                cabecera(id);
            });
            $(".generar").click(function () {
                trp = $(this).parent().parent();
                id = $("td:eq(1)", trp).html();
                $('#MainContent_txtprogramacion').val(id);
                var boton = document.getElementById("<%=btnexportar.ClientID%>");
                boton.click();
                
            });

             $(".listar").click(function () {
                trp = $(this).parent().parent();
                id = $("td:eq(1)", trp).html();
                $('#MainContent_txtprogramacion').val(id);
               // alert($('#MainContent_txtprogramacion').val());
                var boton = document.getElementById("<%=btnlistar.ClientID%>");
                boton.click();
                
            });
            function filtrardetalles(codigo) {
                var long = 0;
                $.ajax({

                    type: "POST",
                    url: "ProgramacionesEjecutadas.aspx/LISTARTTODOS",
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
                    url: "ProgramacionesEjecutadas.aspx/LISTARUNO",
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
                                if (data.d[i].TIPODETRACCION != null) {
                                    long = data.d[i].TIPODETRACCION.length;
                                    $('#MainContent_lbldetraccion').html(data.d[i].TIPODETRACCION.substring(0, long - 15));
                                }
                                else {
                                    
                                    $('#MainContent_lbldetraccion').html(data.d[i].TIPODETRACCION);
                                }
                               
                                $('#MainContent_lblcoddetraccion').html(data.d[i].TASADETRACCION);
                                $('#MainContent_lbldepartamento').html(data.d[i].DEPARTAMENTO);
                                $('#MainContent_lblcodbanco').html(data.d[i].CODBANCO);
                                $('#MainContent_lblbanco').html(data.d[i].BANCO);
                                $('#MainContent_txtestadomod').val(data.d[i].ESTADO);
                               
                                if(data.d[i].ESTADO.trim()=="APROBADA")
                                {
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
                        url: "ProgramacionesEjecutadas.aspx/actualizaEstado",
                        data: '{alumno: ' + JSON.stringify(DETA) + '}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (response) {
                            alert("Aprobado, ya puede ejecutar la programación");
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

             $(".LIMPIAR").click(function () {

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
                    $("#MainContent_txtmes").attr("disabled", false);
                    $("#MainContent_txtannio").attr("disabled", false);
                    $("#MainContent_txtfecha").attr("disabled", true);
                }

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
                    PROGRAMACIONES EJECUTADAS
                </legend>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblusuario" runat="server" ForeColor="#f1f1f1" style="display:none"></asp:Label>
                    </td>

                </tr>
            </table>
                   <table>
                <tr>
                    <td class="auto-style1">
                        <input id="rbdia" name="opcion" type="radio" value="1" runat="server" class="LIMPIAR" />
                        Dia<br />

                    </td>
                    <td>
                        <asp:TextBox ID="txtfecha" runat="server" Width="147px"></asp:TextBox>
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
                        <asp:TextBox ID="txtprogramacion" runat="server" Width="0px" MaxLength="4" BorderStyle="None"></asp:TextBox></td>
                    <td>
                        <asp:Button ID="btnlistar" runat="server" Text="Listar" OnClick="btnlistar_Click" BorderStyle="None" Width="0px" />
                    </td>
                </tr>

            </table>
                 </fieldset>

            <table>
                <tr>
                    <td>
                         <div style="overflow: auto; width: 1100px; height: 400px">
                        <asp:GridView ID="gvordencompra" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" OnRowCreated="griddata_RowCreated">
                            <Columns>
                                <asp:BoundField DataField="GC_CCODAGE" HeaderText="AGENCIA" />
                                <asp:BoundField DataField="GC_CNUMOPE" HeaderText="PROGRAMACION" />
                                <asp:BoundField DataField="GC_CUSUCRE" HeaderText="FECHA DE PROG" >
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="GC_CCODCON" HeaderText="CONCEPTO" />
                                <asp:BoundField DataField="GC_CTIPPAG" HeaderText="TIPO DE PAGO" />
                                <asp:BoundField DataField="GC_CCODBAN" HeaderText="BANCO" />
                                <asp:BoundField DataField="GC_CCODMON" HeaderText="MONEDA" >

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

                                 <asp:TemplateField HeaderText="GENERAR ARCHIVO">

                                    <ItemTemplate>
                                        <div class="generar" style="text-align: center">
                                            <img alt="" src="../../../Images/details.png" width="25" style="cursor: pointer" />
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
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnexportar" runat="server" Text="Generar Archivo" OnClick="btnexportar_Click" BorderStyle="None" Width="0px" />
                    </td>
                </tr>

            </table>
        </div>
        <div id="Modificacion">
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
            <table>
                </table>
           
        </div>

    </div>
    <br />
</asp:Content>

