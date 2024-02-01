<%@ Page Title="Consulta - Reimpresión de Documentos" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ConsultaReimpresion.aspx.cs" Inherits="ConsultaReimpresion" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link type="text/css" href="../CSS/base.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {
            UHTML.id = 'MainContent';
            var fecha1, fecha2, $tr, myRow,prueba,oe;
            Operacion.oDialog('impresion',false);
            Operacion.mask('ddlMalmacen').val(Operacion.mask('codAL').val());
            $('#MainContent_ddlTipodocumento').val('PE');
            $(".dpFecha1").datepicker();
            $(".dpFecha3").datepicker();
            $(".dpFecha4").datepicker();
            $("#detalle").dialog({
                autoOpen: false,
                resizable: true,
                width: 'auto',
                modal: true
            });

            var unidad = function (ART) {
                //console.log(ART);
                $.ajax({
                    url: "RegistroEntrada.aspx/getProductoID",
                    data: "{ 'dato': '" + ART + "'}",
                    dataType: "json",
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        //console.log(data.d[0]['AR_CUNIDAD']);
                        prueba= data.d[0]['AR_CUNIDAD'];
                    },
                    error: function (result) {
                        console.log(result);
                    }
                });
            }
            var obtieneEmbaracion = function (ID) {
                $.ajax({
                    url: "ConsultaReimpresion.aspx/ListarEID",
                    data: "{ ID: '" + ID + "'}",
                    dataType: "json",
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        oe = data.d;
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        //  alert(textStatus);
                    }
                });
                return { oe }
            }

            fecha1 = Operacion.mask('txtalcanceDia').val();
            fecha2 = null;
            cargar();
            Operacion.mask('lblCliente').hide();
            Operacion.mask('txtnomCliente').hide();
            Operacion.mask('txtalcandeMA').hide();
            Operacion.mask('txtrango1').hide();
            Operacion.mask('txtrango2').hide();
            Operacion.mask('lblFechaI').hide();
            Operacion.mask('lblFechaF').hide();

            $("input[name$='MainContent$rbDDia']").click(function () {
                $("input[name$='MainContent$rbalcanceMA']").attr("checked", false);
                $("input[name$='MainContent$rbalcaneRF']").attr("checked", false);
                $("#MainContent_txtalcanceDia").show();
                Operacion.mask('txtalcandeMA').hide();
                Operacion.mask('lblFechaI').hide();
                Operacion.mask('lblFechaF').hide();
                Operacion.mask('txtrango1').hide();
                Operacion.mask('txtrango2').hide();
                cargar();
                Operacion.mask('txtalcandeMA').val("");

            });
            $("input[name$='MainContent$rbalcanceMA']").click(function () {
                $("input[name$='MainContent$rbDDia']").attr("checked", false);
                $("input[name$='MainContent$rbalcaneRF']").attr("checked", false);
                Operacion.mask('txtalcandeMA').show();
                $("#MainContent_txtalcanceDia").hide();
                Operacion.mask('lblFechaI').hide();
                Operacion.mask('lblFechaF').hide();
                Operacion.mask('txtrango1').hide();
                Operacion.mask('txtrango2').hide();
                //cargar();
                //Operacion.mask('txtalcanceDia').val("");
            });
            $("input[name$='MainContent$rbalcaneRF']").click(function () {
                $("input[name$='MainContent$rbDDia']").attr("checked", false);
                $("input[name$='MainContent$rbalcanceMA']").attr("checked", false);
                Operacion.mask('lblFechaI').show();
                Operacion.mask('lblFechaF').show();
                Operacion.mask('txtrango1').show();
                Operacion.mask('txtrango2').show();
                $("#MainContent_txtalcanceDia").hide();
                Operacion.mask('txtalcandeMA').hide();
            });

            Operacion.mask('ddlMalmacen').change(function () {
                //fecha1 = Operacion.mask('txtrango1').val();
                //fecha2 = Operacion.mask('txtrango2').val();
                cargar();
            });
            Operacion.mask('ddlTipodocumento').change(function () {
                //alert('hola');
                cargar();
            })
            Operacion.mask('txtalcanceDia').change(function () {
                fecha1 = $(this).val();
                fecha2 = null;
                cargar();
            });
            Operacion.mask('txtalcandeMA').change(function () {
                //fecha1 = null;
                //fecha2 = $(this).val();
                cargar();
            });
            Operacion.mask('txtMNumeroDoc').change(function () {
                cargar();
            });
            Operacion.mask('txtcodCliente').change(function () {
                cargar();
            });
            Operacion.mask('txtrango2').change(function () {
                fecha1 = Operacion.mask('txtrango1').val();
                fecha2 = $(this).val();
                cargar();
            });


            $('#btnNuevo').click(function () {
                window.location.href = '../ALMACEN/RegistroEntrada.aspx';
            });
            $('#btnSalida').click(function () {
                window.location.href = '../ALMACEN/RegistroSalida.aspx';
            });

            $('.btEditar').live("click", function () {
                var TD = $(this).parents("tr").find("td").eq(0).html();
                var AL = Operacion.mask('ddlMalmacen').val();
                var ND = $(this).parents("tr").find("td").eq(1).html();
                var PE = (TD == "PE" ? "E" : "S");
                window.location.href = '../ALMACEN/ModificacionCabecera.aspx?TD=' + TD + '&AL=' + AL + '&ND=' + ND + '&PE=' + PE;
            });
            $('.btPrinter').live("click", function () {
                var TD = $(this).parents("tr").find("td").eq(0).html();
                var AL = Operacion.mask('ddlMalmacen').val();
                var ND = $(this).parents("tr").find("td").eq(1).html();
                var PE = (TD == "PE" ? "E" : "S");
                
                if (AL == "0001") {
                    window.open("../ALMACEN/Reportes/ReporteFinaliza.aspx?AL=" + AL + "&TD=" + TD + "&ND=" + ND, '_blank');
                } else {
                    window.open("../ALMACEN/Reportes/Reporte.aspx?AL=" + AL + "&TD=" + TD + "&ND=" + ND, '_blank');
                }
            });
            $('.btDetalle').live("click", function () {
                $('#detalle').dialog("open");

                $tr = $(this).closest('tr');
                myRow = $tr.index();
                var sTexto = $('#MainContent_ddlMalmacen option:selected').text();
                var ND = $(this).parents("tr").find("td").eq(1).html();
                var CM = $(this).parents("tr").find("td").eq(2).html();
                var FE = $(this).parents("tr").find("td").eq(3).html();
                var CL = $(this).parents("tr").find("td").eq(5).html();
                var DCL = $(this).parents("tr").find("td").eq(6).html();
                var TD = $(this).parents("tr").find("td").eq(0).html();
                var DR = $(this).parents("tr").find("td").eq(8).html();
                var GL = $(this).parents("tr").find("td").eq(11).html();

                Operacion.mask('lbldetalleTitulo').text("NOTA DE INGRESO N°" + ND);
                Operacion.mask('lbldFecha').text(FE);
                Operacion.mask('lbldAlmacen').text(Operacion.mask('ddlMalmacen').val() + " " + sTexto);
                Operacion.mask('lbldDocr').text(TD + "-" + DR);
                Operacion.mask('lbldCliente').text(CL + " " + DCL);
                Operacion.mask('lbldRuc').text(CL);
                Operacion.mask('lbldCodM').text(CM);
                Operacion.mask('lbldGlosa').text(GL);
                
                $.ajax({
                    type: "POST",
                    url: "ConsultaReimpresion.aspx/detalleCabecera",
                    data: "{ AL: '" + Operacion.mask('ddlMalmacen').val() + "',TD:'" + TD + "',ND:'" + ND + "' }",
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        
                        $('#MainContent_gvDetalle').attr('style', 'background-color:White;border-color:#CCCCCC;border-width:1px;border-style:None;border-collapse:collapse;');
                        if (data.d.length > 0) {
                            $('#MainContent_gvDetalle').empty();
                            $('#MainContent_gvDetalle').append("<tr style='color:White;background-color:#006699;font-weight:bold;'><th align='center' scope='col' style='font-size:8pt;width:100px;'>ITEM</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>CODIGO</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>DESCRIPCION</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>UNID</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>SERIE</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>CANTIDAD REC.</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>PRECIO UNITARIO</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>DSCTO GEN.</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>PRECIO COSTO</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>IMPORTE TOTAL</th></tr>");
                            for (var i = 0; i < data.d.length; i++) {
                                //prueba = "-";
                                unidad(data.d[i].C6_CCODIGO);
                                $("#MainContent_gvDetalle").append("<tr><td style='font-size:8pt;text-align:center'>" +
                                    data.d[i].C6_CITEM + "</td><td style='font-size:8pt;'>" +
                                    data.d[i].C6_CCODIGO + "</td><td style='font-size:8pt;'>" +
                                    data.d[i].C6_CDESCRI + "</td><td style='font-size:8pt;text-align:center'>" +
                                    prueba + "</td><td style='font-size:8pt;'>" +
                                    data.d[i].C6_CSERIE + "</td><td style='font-size:8pt;text-align:right'>" +
                                    data.d[i].C6_NCANTID + "</td><td style='font-size:8pt;text-align:right'>" +
                                    data.d[i].C6_NPREUN1 + "</td><td style='font-size:8pt;text-align:right'>" +
                                    data.d[i].C6_NDESCTO + "</td><td style='font-size:8pt;text-align:right'>" +
                                    data.d[i].C6_NPREUNI + "</td><td style='font-size:8pt;text-align:right'>" +
                                    parseFloat((data.d[i].C6_NCANTID) * (data.d[i].C6_NPREUN1)).toFixed(2) + "</td></tr>");
                                    //data.d[i].C6_NUSPRUN + "</td></tr>");
                            }
                        } else {
                            Operacion.mask('gvDetalle').empty();
                            Operacion.mask('gvDetalle').append("<tr style='color:White;background-color:#006699;font-weight:bold;'><th align='center' scope='col' style='font-size:8pt;width:100px;'>ITEM</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>CODIGO</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>DESCRIPCION</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>UNID</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>SERIE</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>CANTIDAD REC.</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>PRECIO UNITARIO</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>DSCTO GEN.</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>PRECIO COSTO</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>IMPORTE TOTAL</th></tr>");
                            //$("#MainContent_gvDetalle").append("<tr style='color:White;background-color:#006699;font-weight:bold;'><th align='center' scope='col' style='font-size:8pt;width:100px;'>TD</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Nro Documento</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Mov</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Fecha Documento</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Proveedor</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Cliente</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Nombre</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>TDRef</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Doc Ref</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>TD Ref2</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Doc Ref2</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Glosa</th></tr>");
                            Operacion.mask('gvDetalle').append("<tr><td style='font-size:8pt;'>-</td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td></tr>");
                        }

                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert(textStatus);
                    }
                });
            });

            function cargar() {
                llenarGrilla(Operacion.mask('ddlMalmacen').val(), Operacion.mask('ddlTipodocumento').val(), fecha1, fecha2, Operacion.mask('txtMNumeroDoc').val(), Operacion.mask('txtcodCliente').val());
            }
            var aa = 1;

            function llenarGrilla(AL, TD, FEC1, FEC2, ND, CCLI) {

                var OBJ = [];
                if (aa == 1) {
                    $("[id*=gvCRD] tr").not($("[id*=gvCRD] tr:first-child")).remove();
                    aa = 2;
                }
                var DATA = {};
                DATA.C5_CALMA = AL;
                DATA.C5_CTD = TD;
                DATA.C5_CNUMDOC = ND;
                DATA.C5_DFECDOC = (FEC1 == null ? "" : new Date(moment(FEC1, 'DD/MM/YYYY')));
                DATA.C5_DFECVEN = (FEC2 == null ? "" : new Date(moment(FEC2, 'DD/MM/YYYY')));
                DATA.C5_CCODCLI = CCLI;

                $("#LoadingImage").show();
                $.ajax({
                    type: "POST",
                    url: "ConsultaReimpresion.aspx/listaDocumentos",
                    data: '{ DATOS: ' + JSON.stringify(DATA) + '}',
                    //data: "{ AL: '" + AL + "',TD:'"+TD+"',FEC1:'" + FEC1 + "',FEC2:'"+FEC2+"',ND:'"+ND+"',CCLI:'"+CCLI+"'}",//,FEC2:'',TD:'',MOV:'',CCLI:'',NCLI:'',PRO:''
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        $("#LoadingImage").hide();
                        $('#MainContent_gvCRD').attr('style', 'background-color:White;border-color:#CCCCCC;border-width:1px;border-style:None;border-collapse:collapse;');
                        if (data.d.length > 0) {
                            $('#MainContent_gvCRD').empty();
                            $('#MainContent_gvCRD').append("<tr style='color:White;background-color:#006699;font-weight:bold;'><th align='center' scope='col' style='font-size:8pt;width:50px;text-align:center;'>TD</th><th align='center' scope='col' style='font-size:8pt;width:80px;'>Nro Documento</th><th align='center' scope='col' style='font-size:8pt;width:50px;'>Mov</th><th align='center' scope='col' style='font-size:8pt;width:70px;'>Fecha Documento</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Proveedor</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Cliente</th><th align='center' scope='col' style='font-size:8pt;width:300px;'>Nombre</th><th align='center' scope='col' style='font-size:8pt;width:50px;'>TDRef</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Doc Ref</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>TD Ref2</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Doc Ref2</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Glosa</th><th>Accion</th></tr>");
                            for (var i = 0; i < data.d.length; i++) {
                                var fecha = moment(data.d[i].C5_DFECDOC).format('DD/MM/YYYY');
                                //00040018189
                                var oemb = (data.d[i].C5_CCODMOV == "MP" || data.d[i].C5_CCODMOV == "CO" && data.d[i].C5_CGLOSA1 != "" && (data.d[i].C5_CGLOSA1.length > 11) ? data.d[i].C5_CGLOSA1:
                                        (data.d[i].C5_CCODMOV == "MP" || data.d[i].C5_CCODMOV == "CO" && data.d[i].C5_CGLOSA1 != "" && data.d[i].C5_CGLOSA1.length <= 11?obtieneEmbaracion(data.d[i].C5_CGLOSA1).oe:data.d[i].C5_CGLOSA1));
                                $("#MainContent_gvCRD").append("<tr><td style='font-size:8pt;text-align:center;'>" +
                                    data.d[i].C5_CTD + "</td><td style='font-size:8pt;text-align:center;'>" +
                                    data.d[i].C5_CNUMDOC + "</td><td style='font-size:8pt;text-align:center;'>" +
                                    data.d[i].C5_CCODMOV + "</td><td style='font-size:8pt;text-align:center;'>" +
                                    fecha + "</td><td style='font-size:8pt;text-align:center;'>" +
                                    data.d[i].C5_CCODPRO + "</td><td style='font-size:8pt;text-align:center;'>" +
                                    data.d[i].C5_CCODCLI + "</td><td style='font-size:8pt;text-align:left;'>" +
                                    data.d[i].C5_CNOMCLI + "</td><td style='font-size:8pt;text-align:center;'>" +
                                    data.d[i].C5_CRFTDOC + "</td><td style='font-size:8pt;text-align:center;'>" +
                                    data.d[i].C5_CRFNDOC + "</td><td style='font-size:8pt;text-align:center;'>" +
                                    data.d[i].C5_CRFTDO2 + "</td><td style='font-size:8pt;text-align:center;'>" +
                                    data.d[i].C5_CRFNDO2 + "</td><td style='font-size:8pt;'>" +
                                    //data.d[i].C5_CNUMORD + "</td><td style='font-size:8pt;'>" + Printer
                                    oemb + "</td><td style='width:100px;'><div class='btEditar' style='text-align:center;float:left;'><img alt='' src='../Images/EDIT.png' width='25' style='cursor:pointer'> </div><div class='btDetalle' style='text-align:center'><img alt='' src='../Images/details.png' width='25' style='cursor:pointer;float:left;'> </div><div class='btPrinter' style='text-align:center'><img alt='' src='../Images/Printer.png' width='25' style='cursor:pointer;float:left;'> </div></td></tr>");
                            }
                        } else {
                            Operacion.mask('gvCRD').empty();
                            Operacion.mask('gvCRD').append("<tr style='color:White;background-color:#006699;font-weight:bold;'><th align='center' scope='col' style='font-size:8pt;width:100px;'>TD</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Nro Documento</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Mov</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Fecha Documento</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Proveedor</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Cliente</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Nombre</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>TDRef</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Doc Ref</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>TD Ref2</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Doc Ref2</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Glosa</th></tr>");
                            Operacion.mask('gvCRD').append("<tr><td style='font-size:8pt;'>-</td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td></tr>");
                        }
                        //$('#MainContent_gvCRD table th:eq(12)').hide();
                        //$("#MainContent_gvCRD td:nth-child(1), #Grid th:nth-child(11)").hide();
                    },
                    error: function (result) {
                        console.log(result);
                    }

                });

                //rowt = $("[id*=gvCRD] tr:last-child").clone(true);
            }
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
        <asp:HiddenField ID="codDR" runat="server" />
        <asp:HiddenField ID="codCC" runat="server" />
        <asp:HiddenField ID="codCL" runat="server" />
        <asp:HiddenField ID="codAL" runat="server" />
        <fieldset>
            <legend>Consulta Reimpresion - Documentos</legend>
            <table>
                <tr>
                    <td class="auto-style1">Almacén</td>
                    <td>
                        <!--OnSelectedIndexChanged="ddlesM_SelectedIndexChanged"-->
                        <asp:DropDownList ID="ddlMalmacen" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style2">Alcance</td>
                    <td>
                        <asp:RadioButton Text="Del dia" name="radio1" ID="rbDDia" runat="server" Checked="True" />
                        <asp:TextBox ID="txtalcanceDia" class="dpFecha1" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style3">
                        <!--MES/AÑO-->
                        <!--<asp:RadioButton ID="rbalcanceMA" name="radio1" Text="Mes/año:" runat="server" />-->
                        <asp:RadioButton ID="rbalcaneRF" name="radio1" Text="Rango de fechas" runat="server" />
                    </td>
                    <td>
                        <!--MES/AÑO-->
                        <!--<asp:TextBox ID="txtalcandeMA" class="dpFecha2" runat="server"></asp:TextBox>-->
                        <asp:Label ID="lblFechaI" runat="server" Text="Fecha inicio"></asp:Label>
                        <asp:TextBox ID="txtrango1" class="dpFecha3" runat="server"></asp:TextBox>

                    </td>
                    <td colspan="2">

                        <asp:Label ID="lblFechaF" runat="server" Text="Fecha Fin"></asp:Label>&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtrango2" class="dpFecha4" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">
                        <!--RF-->
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Tipo Documento</td>
                    <td>
                        <asp:DropDownList ID="ddlTipodocumento" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style2">Tipo Movimiento&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="2">
                        <!--RF-->
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Nro Documento</td>
                    <td>
                        <asp:TextBox ID="txtMNumeroDoc" class="ac" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style2">Codigo Cliente&nbsp;&nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtcodCliente" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style3">
                        <asp:Label ID="lblCliente" runat="server" Text="Nombre cliente"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtnomCliente" runat="server"></asp:TextBox>
                    </td>
                    <td></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="10">
                        <div id="LoadingImage" style="display: none">
                            <img src="../Images/loading.gif" style="width:15px;"/>Cargando...
                        </div>
                        <asp:GridView ID="gvCRD" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="C5_CTD" HeaderText="TD" ItemStyle-HorizontalAlign="Right">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="C5_CNUMDOC" HeaderText="Nro Documento" ItemStyle-HorizontalAlign="Right">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="C5_CCODMOV" HeaderText="Mov" ItemStyle-HorizontalAlign="Right">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="C5_DFECDOC" HeaderText="Fecha Documento" ItemStyle-HorizontalAlign="Right">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="C5_CCODPRO" HeaderText="Proveedor" ItemStyle-HorizontalAlign="Right">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="C5_CCODCLI" HeaderText="Cliente" ItemStyle-HorizontalAlign="Right">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="C5_CNOMCLI" HeaderText="Nombre" ItemStyle-HorizontalAlign="Right">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="C5_CRFTDOC" HeaderText="TDRef" ItemStyle-HorizontalAlign="Right">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="C5_CRFNDOC" HeaderText="Doc Ref" ItemStyle-HorizontalAlign="Right">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="C5_CRFTDO2" HeaderText="TDRef2" ItemStyle-HorizontalAlign="Right">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="C5_CRFNDO2" HeaderText="Doc Ref2" ItemStyle-HorizontalAlign="Right">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="C5_CGLOSA1" HeaderText="Glosa" ItemStyle-HorizontalAlign="Right">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <div class="btEditar" style="text-align: center">
                                            <img alt="" src="../Images/EDIT.png" width="25" style="cursor: pointer" />
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
                    <td></td>
                    <td></td>
                    <td>&nbsp;</td>
                    <td class="auto-style1" colspan="7">
                        <input id="btnNuevo" type="button" class="btn" value="Registro Ingreso" />
                        <input id="btnSalida" type="button" class="btn" value="Registro Salida" />
                        <!--<input id="btnNuevo" type="button" value="Registro Entrada OC" class="boton" />-->
                    </td>

                </tr>
            </table>

        </fieldset>

    </div>
    <br />
    <div id="detalle" title="Detalle" style="display:none;">
        <table style="width: 100%;">
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="lbldetalleTitulo" runat="server" Text=""></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>Fecha:<asp:Label ID="lbldFecha" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Almacen</td>
                <td>
                    <asp:Label ID="lbldAlmacen" runat="server" Text=""></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Nro. Doc Refencia</td>
                <td>
                    <asp:Label ID="lbldDocr" runat="server" Text=""></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Nro. Orden Compra</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Cliente</td>
                <td>
                    <asp:Label ID="lbldCliente" runat="server" Text=""></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Nro. Ruc</td>
                <td>
                    <asp:Label ID="lbldRuc" runat="server" Text=""></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Codigo Movimiento</td>
                <td>
                    <asp:Label ID="lbldCodM" runat="server" Text=""></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Glosa</td>
                <td>
                    <asp:Label ID="lbldGlosa" runat="server" Text=""></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
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
            </tr>
        </table>
    </div>
    <div id="impresion" title="Imprimir Guia" style="display:none;">
        <table>
            <tr>
                <td>Almacen</td>
                <td>
                    <asp:TextBox ID="txtAL" runat="server" ReadOnly="true"></asp:TextBox>
                </td>
                <td></td>
            </tr>
            <tr>
                <td>Numero Documento</td>
                <td>
                    <asp:TextBox ID="txtND" runat="server" ReadOnly="true"></asp:TextBox>
                </td>
                <td></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:HiddenField ID="hfTD" runat="server" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnExportar" runat="server" Text="Exportar" OnClick="btnExportar_Click"  />
                    
                </td>
                <td>
                    <asp:Label ID="lblPrueba" runat="server" Text="Label"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
</asp:Content>

















