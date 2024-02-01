﻿<%@ Page Title="Registro de Salida" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="RegistroSalida.aspx.cs" Inherits="RegistroSalida" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link type="text/css" href="../CSS/base.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {
            contaditem = 0; MARRAY = [];
            vfg = 1;
            tcontg = 1;
            bandera = true;
            var idCod = "", miconsulta = 'getProducto';
            var idCodA;
            var $tr;
            var myRow;
            var aTR;
            var aIDMOV;
            var aALREF;
            var aIDREF;
            var aNROD;
            var aCENC;
            var aAELE;
            var aNORD;
            var CTD = 'PS';
            var IDE;
            var IDS;
            Sumatotallote = 0;
            UHTML.id = 'MainContent';
            //--------------------------------------------------------------------------------
            //Operacion.inputEstado('btnGuardar', 1, false);
            Operacion.inputEstado('btnGuardar', 1, false);
            Operacion.inputVisible($('#btnActualizar'), 1);//revisar
            Operacion.oDialog('detalleCabecera', false);
            Operacion.iValida(Operacion.mask("txtclscan"), 1);
            Operacion.oDialog('serie', false);
            Operacion.inputVisible('lblND2', 1);
            Operacion.inputVisible('ddlOrigen', 1);
            Operacion.inputVisible('ddlDepa', 1);
            Operacion.inputVisible('txtNT', 1);
            Operacion.inputVisible('lblNT', 1);
            Operacion.mask('hfG1').val('-1');
            Operacion.mask('ddlMoneda').val('MN');

            function inputEstado(val, est) {
                (est == 1 ? val.attr('disabled', true) : val.removeAttr("disabled"));
            }

            var uus = $("#HeadLoginView_HeadLoginName").html();
            Operacion.mask('hfusuario').val(uus);
            $(".dpFecha1").datepicker();
            $(".dpFecha2").datepicker();
            bloqueo(Operacion.mask('codM').val());
            Operacion.inputEstado('ddlTipoCambio', 0, true);
            Operacion.inputVisible('txtAG1', 1);
            $("input[type='text']:visible:enabled:first").focus();

            var valida = function () {
                return Operacion.iVALC(['txtIDMOV', 'txtProveedor', 'txtIDREF', 'txtTipoDocumentoRef1',
                    'txtNroDocumento1', 'txtOrdenCompra', 'txtOrdenTrabajo',
                    'txtSolicitante', 'txtCentroCosto', 'txtDetalleCC', 'txtGlosa1',
                    'ddlAlmacenRef', 'txtIDCL', 'txtCliente',
                    'ddlAnexo', 'txtAnexoDetalle']);
            }
            var validaDetalle = function () {
                return Operacion.iVALC(['txtdescripcion', 'txtCantidad', 'txtSerie', 'txtFechaL']);
                //return Operacion.iVALC(['txtidProducto', 'txtdescripcion', 'txtCantidad', 'txtSerie', 'txtFechaL']);
            }
            var addComplete1 = function () {
                $(".ace").autocomplete(
                {/*EMBARCACIONES*/
                    source: function (request, response) {
                        var AL = Operacion.mask('codAL').val();
                        var M_EB = (MARRAY[0] == AL || MARRAY[1] == AL ? "getBAR" : "getEMB");

                        if (M_EB == "getEMB") {
                            var EDATA = {};
                            EDATA.E_NOMBRE = "%" + request.term + "%";
                        } else {
                            var EDATA = {};
                            EDATA.AF_COD = "BA";
                            EDATA.AF_TDESCRI2 = "%" + request.term + "%";
                        }
                        $.ajax({
                            url: "RegistroEntrada.aspx/" + M_EB,
                            data: '{ EDATA:' + JSON.stringify(EDATA) + '}',
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            dataFilter: function (data) { return data; },
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    if (M_EB == "getEMB") {
                                        return {
                                            value: item.E_NOMBRE + " " + item.E_MATRIC,
                                            id: item.E_MATRIC
                                        }
                                    } else {
                                        return {
                                            value: item.AF_TDESCRI2 + " " + item.AF_TDESCRI3,
                                            id: item.AF_TDESCRI1
                                        }
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
                        var str = ui.item.value, str1 = ui.item.id;
                        Operacion.mask('txtGlosa1').val(str);
                        Operacion.mask('hfG1').val(str1);
                    }, change: function (event, ui) {
                        if (ui.item == null || ui.item == undefined) {
                            alert("No ha seleccionado un valor valido");
                            Operacion.mask('txtGlosa1').focus();
                            Operacion.mask('txtGlosa1').val('');
                            Operacion.mask('hfG1').val('');
                        }
                    }
                });
            }
            var iniciaPGE = function (CO) {
                var PDATA = {};
                PDATA.AF_COD = CO;
                $.ajax({
                    type: "POST",
                    url: "RegistroEntrada.aspx/getPARAM",
                    data: '{ PDATA: ' + JSON.stringify(PDATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        //console.log(data);
                        if (data.d.length > 0) {
                            jQuery.each(data.d, function (i, v) {
                                MARRAY.push(v.AF_TDESCRI1.trim());
                                //console.log(MARRAY);
                            });
                        } else {
                            //
                        }

                    },
                    error: function (response) {
                        console.table(response);
                    }
                });
            }
            var actualizaSerieS = function (AL, CD, SE, CT) {

                var SDATA = {};
                SDATA.SR_CALMA = AL;
                SDATA.SR_CCODIGO = CD;
                SDATA.SR_CSERIE = SE;
                SDATA.SR_NSKDIS = CT;
                //SDATA.SR_DFECMOV = gitem21;
                //SDATA.SR_DFECVEN = gitem22;

                $.ajax({
                    url: "RegistroEntrada.aspx/actualizaSSerie",
                    data: '{ SDATA: ' + JSON.stringify(SDATA) + ',OP:0}',
                    dataType: "json",
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        //var GAV = gridView.rows.length;
                        //((GAV - 1) == t ? alert('Se ha registrado los lotes con exito') : "");

                        //console.log("t=>" + t + "Operacion.cadenaMascara(" + Operacion.cadenaMascara((t-1), 4)+"");
                    },
                    error: function (response) {
                        alert('Hubo error en el ingreso, ponerse en contacto con el area de sistemas');
                        console.log(response);
                    }
                });
                //insertaALSE(gitem00, Operacion.cadenaMascara((t - 1), 4), gitem01, gitem11, gitem21);

            }
            var insertaALSE = function (AL, ITA, CD, SL, CL) {
                //AL:ALMACEN,ITA:ITEM GENERADO,CD:COD PRODUCTO,SL:SERIE/LOTE,CL:CANTIDAD LOTE,FD:FECHA DOCUMENTO
                var ASDATA = {};
                ASDATA.C6_CLOCALI = "0001";
                ASDATA.C6_CALMA = AL;
                ASDATA.C6_CTD = "PS";//CORREGIDO
                ASDATA.C6_CNUMDOC = Operacion.mask('lblNroDocumento').text().trim();
                ASDATA.C6_CITEM = ITA;
                ASDATA.C6_CCODIGO = CD;
                ASDATA.C6_CSERIE = SL;
                ASDATA.C6_NCANTID = CL;
                ASDATA.C6_CUSUCRE = Operacion.mask('hdUSUARIO').val();
                //ASDATA.C6_DFECCRE=;
                ASDATA.C6_DFECDOC = moment(Operacion.mask('lblFechaDocD').text(), 'DD/MM/YYYY');
                ASDATA.C6_CITEREQ = "";
                ASDATA.C6_CNUMCEL = "";
                ASDATA.C6_NCANRPE = 0;
                $.ajax({
                    url: "RegistroEntradaOC.aspx/registraAlmacenSerie",
                    data: '{ ASDATA: ' + JSON.stringify(ASDATA) + '}',
                    dataType: "json",
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        //alert('Se ha registrado los lotes con exito');
                    },
                    error: function (response) {
                        alert('Hubo error en el ingreso, ponerse en contacto con el area de sistemas');
                        console.log(response);
                    }
                });
            }
            /*
            Operacion.mask('txtidProducto').change(function () {
                stockCOD(Operacion.mask('codAL').val(), $(this).val(), Operacion.mask('lblSalida').text().trim());
            });*/
            Operacion.mask('txtIDMOV').change(function () {
                Operacion.mask('txtIDMOV').val($(this).val().toUpperCase());
                bloqueo($(this).val());

                cambiarLABEL(Operacion.mask('codAL').val(), $(this).val());
                $.ajax({
                    type: "POST",
                    url: "RegistroEntrada.aspx/getMovimientosID",
                    data: "{ datos: '" + $(this).val() + "',tipo:'S'}",
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        //console.log(data);
                        if (data.d.length > 0) {
                            jQuery.each(data.d, function (i, val) {
                                Operacion.mask('txtCodigoMov').val(val['TM_CDESCRI']);
                                //Operacion.mask('txtProveedor').focus();
                            });
                            (Operacion.mask('txtProveedor').is('[disabled]') == true ? Operacion.mask('txtIDREF').focus() : Operacion.mask('txtProveedor').focus());
                        } else {
                            Operacion.mask('lblMCodigoMov').val("");
                        }
                    }
                });
            });
            Operacion.mask('txtProveedor').change(function () {

            });
            Operacion.mask('txtIDREF').change(function () {
                Operacion.mask("txtSolicitante").val("");
                Operacion.mask("lblSolicitante").text("");
                $.ajax({
                    type: "POST",
                    url: "ModificacionCabecera.aspx/getLISTATD",
                    data: "{ dato: '" + $('#MainContent_txtIDREF').val() + "', codigo:'04' }",
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        //console.log(data);
                        if (data.d.length > 0) {
                            jQuery.each(data.d, function (i, val) {
                                Operacion.mask('txtTipoDocumentoRef1').val(val['TG_CDESCRI']);
                            });
                            Operacion.mask('txtNroDocumento1').focus();
                        } else {
                            Operacion.mask('txtTipoDocumentoRef1').text("");
                        }
                    }, error: function (response) {
                        console.table(response);
                    }
                });
            });
            Operacion.mask('txtTDRef2').change(function () {
                $.ajax({
                    type: "POST",
                    url: "ModificacionCabecera.aspx/getLISTATD",
                    data: "{ dato: '" + $('#MainContent_txtTDRef2').val() + "', codigo:'04' }",
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        //console.log(data);
                        if (data.d.length > 0) {
                            jQuery.each(data.d, function (i, val) {
                                $('#MainContent_txtTipoDocumentoRef2').val(val['TG_CDESCRI']);
                                (Operacion.mask('txtNroDocumento2').is(":visible") == true ? Operacion.mask('txtNroDocumento2').focus() : Operacion.mask('ddlDepa').focus());
                            });
                        } else {
                            $('#MainContent_txtTipoDocumentoRef2').text("");
                        }
                    }, error: function (response) {
                        console.table(response);
                    }
                });
            });
            Operacion.mask('txtNroDocumento2').change(function () {

                //Operacion.mask('txtOrdenCompra').focus();
                //Operacion.mask()txtOrdenTrabajo
                //Operacion.mask('txtSolicitante').focus();
            });
            Operacion.mask('txtSolicitante').change(function () {
                $.ajax({
                    type: "POST",
                    url: "RegistroEntrada.aspx/Gettablaycodigo",
                    data: "{ dato: '" + $(this).val() + "', codigo:'12' }",
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        //if (data.d.length > 0) {
                        //    jQuery.each(data.d, function (i, val) {
                        Operacion.mask('lblSolicitante').text(data.d);//val['TG_CDESCRI']);
                        //    });
                        Operacion.mask('txtCentroCosto').focus();
                        //} else {
                        //    Operacion.mask('lblSolicitante').text('');
                        //}
                    }, error: function (response) {
                        console.log(response);
                    }
                });
            });
            Operacion.mask('txtCentroCosto').change(function () {

                $.ajax({
                    url: "RegistroEntrada.aspx/Gettablaycodigo",
                    data: "{ dato: '" + $(this).val() + "', codigo:'10'}",
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        //console.log(data.d);
                        if (data.d != null || data.d != "") {
                            Operacion.mask('txtDetalleCC').val(data.d);
                            Operacion.mask('txtGlosa1').focus();
                        } else {
                            alert("Centro Costo No existe");
                            Operacion.mask('txtCentroCosto').focus();
                        }
                        //Operacion.mask('codCC').val(str);
                        //Operacion.mask('codCC').val(str);OPCIONAL
                    },
                    //error: function (XMLHttpRequest, textStatus, errorThrown) {
                    error: function (result) {
                        alert(result);
                    }
                });
            });
            $('input:radio[name=rb]').click(function () {
                miconsulta = ($(this).val() == "C" ? 'getProductoAS' : 'getProducto');
                Operacion.mask('txtdescripcion').val('');
                Operacion.mask('txtdescripcion').focus();
            });

            $('.clstxtdcan').blur(function () {
                var xtfil = $(this).parent().parent();
                var canvali = $("td", xtfil).eq(1).html();

                if (Number($(this).val()) > Number(canvali)) {
                    alert("La Cantidad Excede del Lote");
                    $(this).focus();
                } else {
                    var cantidad = recorregrid().sumacant;

                    Operacion.mask("txtCantidad").val(cantidad);
                    next = $(this).closest("tr").next().find("input[type=text]");
                    next.focus();
                }
            });

            $('.clstxtdcan').keydown(function (e) {
                if (e.keyCode == 13) {
                    var next = $(this).closest("tr").next().find("input[type=text]");
                    var xtfil = $(this).parent().parent();
                    var canvali = $("td", xtfil).eq(1).html();

                    if (Number($(this).val()) > Number(canvali)) {
                        alert("La Cantidad Excede del Lote");
                        $(this).focus();
                    } else {
                        var cantidad = recorregrid().sumacant;
                        Operacion.mask("txtCantidad").val(cantidad);
                        if (next.length > 0) {
                            next.focus();
                        } else {

                            next = $("[id*=gvDetalleEntrada] input[type=text]").eq(0);
                            //next.focus();
                            $(".clsgrab").focus();
                        }
                        return false;

                    }

                }
            });

            $('.clsgrab').click(function () {

                var sumacant = Number(recorregrid().sumacant) + Number(recorregridconlotessuma(idprodc).sumaglte);

                if (Number(sumacant) != Number(valcantxitem)) {
                    alert("La cantidad debe ser Igual al que solicitó");

                } else {
                    if (confirm("Desea agregar los item?")) {

                        var gridView = document.getElementById("<%=gvSerie.ClientID %>");
                        for (var t = 1; t < gridView.rows.length; t++) {
                            var inputs = gridView.rows[t].getElementsByTagName('input');
                            if (inputs[0].type == "text" && (inputs[0].value != "" || inputs[0].value != 0)) {

                                Gdr01 = gridView.rows[t].cells[0];
                                Seriev = Gdr01.innerHTML;
                                Gdr02 = gridView.rows[t].cells[2];
                                Fechav = Gdr02.innerHTML;
                                cantok = inputs[0].value;

                                var rowt = $("[id*=gvlotexvale] tr:last-child").clone(true);
                                if (vfg == 1) {
                                    $("[id*=gvlotexvale] tr").not($("[id*=gvlotexvale] tr:first-child")).remove();
                                    vfg = 2; contaditem = 0;
                                }
                                contaditem++;
                                $("td", rowt).eq(0).html(contaditem);
                                $("td", rowt).eq(1).html(idprodc);
                                $("td", rowt).eq(2).html(desprodc);
                                $("td", rowt).eq(3).html(undc);
                                $("td", rowt).eq(4).html(ccostoc);
                                $("td", rowt).eq(5).html(Seriev);
                                $("td", rowt).eq(6).html(Fechav);
                                $("td", rowt).eq(7).html(cantok);

                                $("[id*=gvlotexvale]").append(rowt);
                                rowt = $("[id*=gvlotexvale] tr:last-child").clone(true);

                                //actualizaSerieS(Operacion.mask('codAL').val(), idcodix, Seriev, cantok);
                                //insertaALSE(Operacion.mask('codAL').val(), contaditem, idcodix, Seriev, cantok); 
                            }
                        }
                        $("#serie").dialog("close");
                    }
                }
            });

            Operacion.mask('txtCantidad').change(function () {
                if (Operacion.mask('txtIDMOV').val() == "PR") {
                    if (Number($(this).val()) > Number(Operacion.mask('hfSERIE').val())) {
                        //alert('La serie/lote ' + Operacion.mask('txtSerie').val().trim() + " del Artículo " + Operacion.mask('txtidProducto').val() + ", no tiene suficiente Stock en el Almacén " + Operacion.mask('codAL').val() + ". El Stock actual es " + Operacion.mask('hfSERIE').val());
                        alert('La serie/lote ' + Operacion.mask('txtSerie').val().trim() + " del Artículo " + Operacion.mask('txtdescripcion').val() + ", no tiene suficiente Stock en el Almacén " + Operacion.mask('codAL').val() + ". El Stock actual es " + Operacion.mask('hfSERIE').val());
                        $(this).val('');
                    } else {
                        $('#btnagregarItem').focus();
                    }
                } else if (Number($(this).val()) > Number((Operacion.mask("lblSTOCK").text()))) {
                    alert('La cantidad no puede superar al stock actual');
                } else {
                    //
                }
            });

            function cambiarLABEL(AL, CM) {
                iniciaPGE("MP");
                Operacion.inputEstado('ddlMoneda', 0, true);
                Operacion.inputEstado('ddlTipoConversion', 0, true);
                //if ((AL == "A002" || AL == "A004" || AL == "0004" || AL=="0015") && (CM == "MP")) {
                if (jQuery.inArray(AL, MARRAY) !== -1 && (CM == "CO" || CM == "MP" || CM == "CX" || CM == "AI" || CM == "TD")) {
                    addComplete1();
                    Operacion.mask('lblOT').text('Bahia');
                    Operacion.mask('lblG1').text('Embarcación');//C5_CGLOSA1:EMBARCACION
                    Operacion.mask('lblG2').text('Transporte');
                    Operacion.mask('lblG3').text('Chofer/Matricula');
                    Operacion.mask('lblG4').text('DER');
                    Operacion.inputVisible('lblND2', 0);
                    Operacion.mask('lblND2').text('Localidad');
                    Operacion.mask('lblND3').text('Origen');
                    Operacion.inputVisible('ddlDepa', 0);
                    Operacion.inputVisible('ddlOrigen', 0);
                    Operacion.inputVisible('txtNroDocumento2', 1);
                } else {
                    Operacion.oACD('txtGlosa1');
                    Operacion.mask('txtGlosa1').val('');
                    Operacion.mask('hfG1').val('-1');
                    Operacion.mask('lblOT').text('Orden de Trabajo');
                    Operacion.mask('lblG1').text('Glosa 1');//C5_CGLOSA1:EMBARCACION
                    Operacion.mask('lblG2').text('Glosa 2');
                    Operacion.mask('lblG3').text('Glosa 3');
                    Operacion.mask('lblG4').text('Glosa 4');
                    Operacion.inputVisible('lblND2', 1);
                    Operacion.mask('lblND3').text('Nro Documento 2');
                    Operacion.inputVisible('ddlDepa', 1);
                    Operacion.inputVisible('ddlOrigen', 1);
                    Operacion.inputVisible('txtNroDocumento2', 0);
                }
            }
            function bloqueo(op) {
                //alert(op);
                $.ajax({
                    type: "POST",
                    url: "RegistroEntrada.aspx/obtenerCampo",
                    data: "{ CM: 'S',TM:'" + op + "'}",
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        //console.log(data.d);
                        if (data.d != null) {
                            if (op == "PR") {
                                Operacion.inputEstado('lblSL', 0, true);
                                Operacion.inputEstado('lblSCantidad', 0, true);
                            }
                            inputEstado($('#MainContent_RadioButton1'), 1);
                            //inputEstado($('#MainContent_ddlMoneda'), 1);
                            inputEstado($('#MainContent_ddlTipoConversion'), 1);
                            inputEstado($('#MainContent_ddlTipoCambio'), 1);
                            inputEstado($('#MainContent_txtProveedor'), (data.d['TM_CFPROV'] == "N" ? 1 : 0));//ok
                            Operacion.inputVisible('lblPROV', (data.d['TM_CFPROV'] == "N" ? 1 : 0));//NUEVO
                            inputEstado($('#MainContent_txtIDREF'), (data.d['TM_CFDOC'] == "N" ? 1 : 0));//ok
                            inputEstado($('#MainContent_txtTipoDocumentoRef1'), (data.d['TM_CFDOC'] == "N" ? 1 : 0));//ok
                            inputEstado($('#MainContent_txtNroDocumento1'), (data.d['TM_CFDOC'] == "N" ? 1 : 0));//ok
                            inputEstado($('#MainContent_txtTDRef2'), (data.d['TM_CFDOC'] == "N" ? 1 : 0));//ok
                            Operacion.inputVisible('lblOC', (data.d['TM_CORDCOM'] == "N" ? 1 : 0));//NUEVO
                            inputEstado($('#MainContent_txtTipoDocumentoRef2'), (data.d['TM_CFDOC'] == "N" ? 1 : 0));//ok
                            inputEstado($('#MainContent_txtNroDocumento2'), (data.d['TM_CFDOC'] == "N" ? 1 : 0));//ok
                            inputEstado($('#MainContent_txtOrdenCompra'), (data.d['TM_CORDCOM'] == "N" ? 1 : 0));//verificar ->TM_CORDEN
                            inputEstado($('#MainContent_txtOrdenCompraD'), (data.d['TM_CORDCOM'] == "N" ? 1 : 0));//verificar
                            inputEstado($('#MainContent_txtGlosa1'), (data.d['TM_CFGLOS'] == "N" ? 1 : 0));//ok
                            inputEstado($('#MainContent_txtGlosa2'), (data.d['TM_CFGLOS'] == "N" ? 1 : 0));//ok
                            inputEstado($('#MainContent_txtGlosa3'), (data.d['TM_CFGLOS'] == "N" ? 1 : 0));//ok
                            inputEstado($('#MainContent_txtGlosa4'), (data.d['TM_CFGLOS'] == "N" ? 1 : 0));//ok
                            Operacion.inputVisible('lblOT', (data.d['TM_CFORDEN'] == "N" ? 1 : 0));//NUEVO
                            inputEstado($('#MainContent_txtOrdenTrabajo'), (data.d['TM_CFORDEN'] == "N" ? 1 : 0));//ok//TM_CFORDEN revisar
                            Operacion.inputVisible('lblSOL', (data.d['TM_CFSOLI'] == "N" ? 1 : 0), true);
                            inputEstado($('#MainContent_txtSolicitante'), (data.d['TM_CFSOLI'] == "N" ? 1 : 0));//ok
                            inputEstado($('#MainContent_txtCentroCosto'), (data.d['TM_CFCCOS'] == "N" ? 1 : 0));//ok
                            inputEstado($('#MainContent_txtDetalleCC'), (data.d['TM_CFCCOS'] == "N" ? 1 : 0));
                            inputEstado($('#MainContent_ddlAlmacenRef'), (data.d['TM_CFALMA'] == "N" ? 1 : 0));//ok
                            Operacion.inputVisible('lblCL', (data.d['TM_CVANEXO'] == "N" ? 1 : 0));//NUEVO
                            inputEstado($('#MainContent_txtIDCL'), (data.d['TM_CVANEXO'] == "N" ? 1 : 0));
                            inputEstado($('#MainContent_txtCliente'), (data.d['TM_CVANEXO'] == "N" ? 1 : 0));//(op == "AI" ? 1 : 0));
                            inputEstado($('#MainContent_ddlAnexo'), (data.d['TM_CCODANE'] == "N" ? 1 : 0));
                            inputEstado($('#MainContent_txtAnexoDetalle'), (data.d['TM_CCODANE'] == "N" ? 1 : 0));
                            Operacion.inputEstado('btnGuardar', 0, false);
                        } else {
                            Operacion.inputEstado('RadioButton1', 1, true);
                            //Operacion.inputEstado('ddlMoneda'), 1);
                            //Operacion.inputEstado('ddlTipoConversion'), 1);
                            //Operacion.inputEstado('ddlTipoCambio'), 1);
                            Operacion.inputEstado('txtProveedor', 1, true);
                            Operacion.inputEstado('txtIDREF', 1, true);
                            Operacion.inputEstado('txtTipoDocumentoRef1', 1, true);
                            Operacion.inputEstado('txtNroDocumento1', 1, true);
                            Operacion.inputEstado('txtTDRef2', 1, true);
                            Operacion.inputEstado('txtTipoDocumentoRef2', 1, true);
                            Operacion.inputEstado('txtNroDocumento2', 1, true);
                            Operacion.inputEstado('txtOrdenCompra', 1, true);
                            Operacion.inputEstado('txtOrdenCompraD', 1, true);
                            Operacion.inputEstado('txtGlosa1', 1, true);
                            Operacion.inputEstado('txtGlosa2', 1, true);
                            Operacion.inputEstado('txtGlosa3', 1, true);
                            Operacion.inputEstado('txtOrdenTrabajo', 1, true);
                            Operacion.inputEstado('txtSolicitante', 1, true);
                            Operacion.inputEstado('txtCentroCosto', 1, true);
                            Operacion.inputEstado('txtDetalleCC', 1, true);
                            Operacion.inputEstado('ddlAlmacenRef', 1, true);
                            Operacion.inputEstado('txtIDCL', 1, true);
                            Operacion.inputEstado('txtCliente', 1, true);
                            Operacion.inputEstado('ddlAnexo', 1, true);
                            Operacion.inputEstado('txtAnexoDetalle', 1, true);
                            Operacion.inputEstado('lblSL', 1, true);
                            Operacion.inputEstado('lblSCantidad', 1, true);
                            $('#MainContent_txtIDMOV').val('');
                            $('#MainContent_txtCodigoMov').val('');
                        }
                    }, error: function (response) {
                        console.table(response);
                    }

                });

            }

            function limpiarIngresos() {
                //$('#MainContent_txtidProducto').val('');
                Operacion.mask('txtdescripcion').val('');
                Operacion.mask('hfidproducto').val('');
                Operacion.mask('hfdescripcion').val('');
                Operacion.mask('hdfUnidad').val('');
                //$('#MainContent_txtCentroCosto').val('');
                Operacion.mask('txtSerie').val('');
                Operacion.mask('txtFechaL').val('');
                Operacion.mask('lblSCantidad').text('');//CANTIDAD LOTE
                Operacion.mask('txtCantidad').val('');
                Operacion.mask('lblSTOCK').text('');
            }

            function recorregrid() {
                var sumacant = 0;
                var gridView = document.getElementById("<%=gvSerie.ClientID %>");

                for (var t = 1; t < gridView.rows.length; t++) {
                    var inputs = gridView.rows[t].getElementsByTagName('input');
                    if (inputs[0].type == "text" && (inputs[0].value != "" || inputs[0].value != 0)) {
                        sumacant = Number(sumacant) + Number(inputs[0].value);
                    }
                }
                return { sumacant}
            }

            function recorregridconlotes() {
                var AL = Operacion.mask('codAL').val();
                var gridView = document.getElementById("<%=gvlotexvale.ClientID %>");
                for (var t = 1; t < gridView.rows.length; t++) {
                    cellPivot00 = gridView.rows[t].cells[0];
                    gitem00 = cellPivot00.innerHTML;
                    cellPivot01 = gridView.rows[t].cells[1];
                    gitem01 = cellPivot01.innerHTML;
                    cellPivot02 = gridView.rows[t].cells[2];
                    gitem02 = cellPivot02.innerHTML;
                    cellPivot03 = gridView.rows[t].cells[5];
                    gitem03 = cellPivot03.innerHTML;
                    cellPivot031 = gridView.rows[t].cells[6];
                    gitem031 = cellPivot031.innerHTML;
                    cellPivot04 = gridView.rows[t].cells[7];
                    gitem04 = cellPivot04.innerHTML;
                    guardardetalleCabecera(Operacion.mask('codM').val(), Operacion.cadenaMascara(tcontg, 4), gitem01, gitem02, gitem04);
                    actualizaSerieS(AL, gitem01, gitem03, gitem04);
                    insertaALSE(AL, Operacion.cadenaMascara(tcontg, 4), gitem01, gitem03, gitem04);
                    InsertarStockxsoli(gitem01, gitem04, gitem03);
                    tcontg++;
                }
            }


            function recorregridconlotessuma(idproduv) {
                var sumaglte = 0;
                var gridView = document.getElementById("<%=gvlotexvale.ClientID %>");
                for (var t = 1; t < gridView.rows.length; t++) {
                    var cellPt0p = gridView.rows[t].cells[1];
                    if (cellPt0p.innerHTML == idproduv) {
                        cellPt00 = gridView.rows[t].cells[7];
                        sumacalte = cellPt00.innerHTML;
                        sumaglte = Number(sumaglte) + Number(sumacalte);
                    }
                }
                return { sumaglte }
            }


            function RgridClotesumaT() {
                var sumaglte = 0;
                var gridView = document.getElementById("<%=gvlotexvale.ClientID %>");
                for (var t = 1; t < gridView.rows.length; t++) {
                    //var cellPt0p = gridView.rows[t].cells[1];
                    //if (cellPt0p.innerHTML == idproduv) {
                    cellPt00 = gridView.rows[t].cells[7];
                    sumacalte = cellPt00.innerHTML;
                    sumaglte = Number(sumaglte) + Number(sumacalte);
                    //}
                }
                return { sumaglte }
            }


            function recorregridsinlotes() {
                var AL = Operacion.mask('codAL').val();
                var gridView = document.getElementById("<%=gvDetalleEntrada.ClientID %>");
                for (var h = 1; h < gridView.rows.length; h++) {
                    cellPivotvf = gridView.rows[h].cells[3];
                    if (cellPivotvf.value != "S") {

                        cellPivot000 = gridView.rows[h].cells[0];
                        gitem000 = cellPivot000.innerHTML;
                        cellPivot001 = gridView.rows[h].cells[1];
                        gitem001 = cellPivot001.innerHTML;
                        cellPivot002 = gridView.rows[h].cells[2];
                        gitem002 = cellPivot002.innerHTML;
                        cellPivot003 = gridView.rows[h].cells[5];
                        gitem003 = cellPivot003.innerHTML;
                        //cellPivot031 = gridView.rows[t].cells[6];
                        //gitem031 = cellPivot031.innerHTML;
                        cellPivot004 = gridView.rows[h].cells[7];
                        gitem004 = cellPivot004.innerHTML;
                        guardardetalleCabecera(Operacion.mask('codM').val(), Operacion.cadenaMascara(tcontg, 4), gitem001, gitem002, gitem004);
                        InsertarStockxsoli(gitem001, gitem004, "SIN/SERIE");
                        //actualizaSerieS(AL, gitem01, gitem03, gitem04);
                        //insertaALSE(AL, Operacion.cadenaMascara(gitem00, 4), gitem01, gitem03, gitem04);
                        tcontg++;
                    }
                }
            }


            function stockCOD(AL, COD, TR) {
                $.ajax({
                    type: "POST",
                    url: "RegistroEntrada.aspx/getSTOCKCOD",
                    data: "{ AL: '" + AL + "', COD:'" + COD.trim() + "',TR:'" + TR + "'}",
                    //data: "{ AL: '" + AL + "', COD:'" + COD + "'}",
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        if (data.d.length > 0) {
                            jQuery.each(data.d, function (i, val) {
                                Operacion.mask('lblSTOCK').text(Number(val['SK_NSKDIS']).toFixed(2));
                                //Operacion.mask('lblSTOCK').text(Number(val['SK_NSKDIS'] / 1000).toFixed(2));
                            });
                        } else {
                            alert('El producto elegido, no corresponde al almacen elegido');
                            limpiarIngresos();
                            Operacion.inputEstado('btnagregarItem', 1, false);
                        }

                    },
                    error: function (response) {
                        console.table(response);
                    }
                });
            }
            //CORRELATIVO ALMACENES
            function correlativo(AL, TD) {
                //AL:ALMACEN ELEGIDO,TD:TIPO DOCUMENTO//CTD
                //ACTUALIZACION 04.06.16 
                var CM = Operacion.mask('txtIDMOV').val();
                var dataPOST = "", urlPOST = "";
                if (CM == "AI") {
                    urlPOST = "RegistroSalida.aspx/correlativoIDX";;
                    dataPOST = "{ AL: '" + AL.trim() + "', TDOC:'" + TD.trim() + "',CM:'" + CM + "'}";
                } else {
                    urlPOST = "RegistroEntrada.aspx/correlativoID";
                    dataPOST = "{ AL: '" + AL.trim() + "', TDOC:'" + TD.trim() + "'}";
                }
                console.log(CM);
                console.log(urlPOST); console.log(dataPOST);
                $.ajax({
                    type: "POST",
                    url: urlPOST,
                    data: dataPOST,
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        //console.log(data.d);
                        $('#MainContent_txtNumeroDoc').val(data.d);
                        $('#MainContent_lblNroDocumento').text(data.d);
                        idCod = data.d;
                        //alert(idCod);
                    },
                    error: function (response) {
                        console.table(response);
                    }
                });
                return { idCod };
            }
            function ValidanVale(NV) {

                nvales = 0;
                $.ajax({
                    type: "POST",
                    url: "RegistroSalida.aspx/Existevale",
                    data: "{ dato: '" + NV + "'}",
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        if (data.d != null) {
                            nvales = data.d;
                            //alert(nvales);
                        }
                    },
                    error: function (response) {
                        console.table(response);
                    }
                });
                return { nvales };
            }

            function Validanstockxsoli(almacen, idprod, solict, lote) {
                nvales = 0;
                $.ajax({
                    type: "POST",
                    url: "RegistroSalida.aspx/ValidaStocxSoli",
                    data: "{ almacen: '" + almacen + "',idprod:'" + idprod + "',solict:'" + solict + "',lote:'" + lote + "'}",
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        if (data.d != null) {
                            nvales = data.d;
                            //alert(nvales); 
                        }
                    },
                    error: function (response) {
                        console.table(response);
                    }
                });
                return { nvales };
            }

            function Cantidadstockxsoli(almacen, idprod, solict, lote) {
                cantdiad = 0;
                $.ajax({
                    type: "POST",
                    url: "RegistroSalida.aspx/CantidadStocxSoli",
                    data: "{ almacen: '" + almacen + "',idprod:'" + idprod + "',solict:'" + solict + "',lote:'" + lote + "'}",
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        if (data.d != null) {
                            cantdiad = data.d.SS_CANTID;
                            //alert(nvales); 
                        }
                    },
                    error: function (response) {
                        console.table(response);
                    }
                });
                return { cantdiad };
            }





            function MostrarInfosolicitud(idsol) {

                var Solici = "";
                var Estado = "";
                var Atenci = "";
                $.ajax({
                    type: "POST",
                    url: "RegistroSalida.aspx/ObtenerinfSolic",
                    data: "{ idsol: '" + idsol + "'}",
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {

                        if (data.d != null) {
                            Solici = data.d.SM_IDSOLI;
                            Estado = data.d.SM_ESTADO;
                            Atenci = data.d.SM_ATENC;
                        } else {
                            Solici = "";
                            Estado = "";
                            Atenci = "";
                        }
                    },
                    error: function (response) {
                        console.table(response);
                    }
                });
                return { Solici, Estado, Atenci };
            }

            function Mostrarundato(codigocons, codigoe) {
                var codigowh = codigoe;
                var codigoconswh = codigocons;
                var ee = "";
                $.ajax({

                    type: "POST",
                    url: "../ORDENCOMPRA/OCnueva.aspx/Getdescycodigo",
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
                return { ee};
            }


            function correlativoAux(AL, TD) {
                //AL:ALMACEN ELEGIDO,TD:TIPO DOCUMENTO//CTD
                $.ajax({
                    type: "POST",
                    url: "RegistroEntrada.aspx/correlativoID",
                    data: "{ AL: '" + AL.trim() + "', TDOC:'" + TD.trim() + "'}",
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        //console.log(data.d);
                        idCodA = data.d;
                    },
                    error: function (response) {
                        console.table(response);
                    }
                });
                return { idCodA };
            }
            Operacion.mask('txtdescripcion').change(function () {
                if (Operacion.mask('txtSerie').is('disabled') == true) {
                    Operacion.mask('txtCantidad').focus();
                } else {
                    //Operacion.mask('txtSerie').focus()
                }

            });



            Operacion.mask('txtSerie').focus(function () {
                if ($("#MainContent_txtIDREF").val().trim().toUpperCase() == "VA" && $("#MainContent_txtIDMOV").val().trim().toUpperCase() == "PR") {
                    mostrarlot();
                } else {
                    //LISTAR SERIE - ELECCION
                    var SDATA = {};
                    SDATA.SR_CALMA = Operacion.mask('codAL').val();
                    SDATA.SR_CCODIGO = Operacion.mask('hfidproducto').val();//Operacion.mask('txtidProducto').val();
                    SDATA.SR_CSERIE = "S";
                    $('#serie').dialog("open");
                    $(".clstxtdcan").focus();
                    $.ajax({
                        type: "POST",
                        url: "RegistroEntrada.aspx/ListarSL",
                        data: '{ SDATA:' + JSON.stringify(SDATA) + '}',
                        contentType: "application/json;charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (data) {
                            $('#MainContent_gvSerie').attr('style', 'background-color:White;border-color:#CCCCCC;border-width:1px;border-style:None;border-collapse:collapse;');
                            if (data.d.length > 0) {
                                $('#MainContent_gvSerie').empty();
                                $('#MainContent_gvSerie').append("<tr style='color:White;background-color:#006699;font-weight:bold;'><th align='center' scope='col' style='font-size:8pt;width:50px;text-align:center;'>Serie/Lote</th><th align='center' scope='col' style='font-size:8pt;width:80px;'>Stock Disponible</th><th align='center' scope='col' style='font-size:8pt;width:50px;'>Fecha Venc.</th><th>Accion</th><th align='center' scope='col' style='font-size:8pt;width:50px;'>cantidad</th></tr>");
                                for (var i = 0; i < data.d.length; i++) {
                                    var fecha = moment(data.d[i].SR_DFECVEN).format('DD/MM/YYYY');
                                    $("#MainContent_gvSerie").append("<tr><td style='font-size:8pt;text-align:center;'>" +
                                        data.d[i].SR_CSERIE + "</td><td style='font-size:8pt;text-align:center;'>" +
                                        data.d[i].SR_NSKDIS + "</td><td style='font-size:8pt;text-align:center;'>" +
                                        fecha + "</td><td style='font-size:8pt;text-align:center;'>" +
                                        "<div class='btElegir' style='text-align:center;float:left;'><img alt='' src='../Images/unchecked.png' width='15' style='cursor:pointer'> </div></td><td>" +
                                        "<input type='text' style='width:100px' class='clstxtdcan' onkeypress=$(this).numeric('.') id='txtclscan' />" + "</td></tr>");

                                    Operacion.iValida(Operacion.mask("txtclscan"), 1);
                                }
                            } else {
                                Operacion.mask('gvSerie').empty();
                                Operacion.mask('gvSerie').append("<tr style='color:White;background-color:#006699;font-weight:bold;'><th align='center' scope='col' style='font-size:8pt;width:50px;text-align:center;'>Serie/Lote</th><th align='center' scope='col' style='font-size:8pt;width:80px;'>Stock Disponible</th><th align='center' scope='col' style='font-size:8pt;width:50px;'>Fecha Venc.</th><th>Accion</th></tr>");
                                Operacion.mask('gvSerie').append("<tr><td style='font-size:8pt;'>-</td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td></tr>");
                            }
                        },
                        error: function (response) {
                            console.table(response);
                        }
                    });
                }
            });


            function mostrarlot(idcodigo) {

                var SDATA = {};
                SDATA.SR_CALMA = Operacion.mask('codAL').val();
                SDATA.SR_CCODIGO = idcodigo;//Operacion.mask('txtidProducto').val();
                SDATA.SR_CSERIE = "S";
                $('#serie').dialog("open");
                $.ajax({
                    type: "POST",
                    url: "RegistroEntrada.aspx/ListarSL",
                    data: '{ SDATA:' + JSON.stringify(SDATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {

                        if (data.d.length > 0) {

                            var row0 = $("[id*=gvSerie] tr:last-child").clone(true);
                            $("[id*=gvSerie] tr").not($("[id*=gvSerie] tr:first-child")).remove();


                            for (var i = 0; i < data.d.length; i++) {


                                $("td", row0).eq(0).html(data.d[i].SR_CSERIE);
                                var fecha = moment(data.d[i].SR_DFECVEN).format('DD/MM/YYYY');
                                $("td", row0).eq(2).html(fecha);
                                //$("td", row).eq(4).html();
                                var nrxusu = Validanstockxsoli(Operacion.mask("codAL").val(), idcodigo.trim(), Operacion.mask("txtSolicitante").val(), data.d[i].SR_CSERIE.trim()).nvales;
                                var cantxusu = Cantidadstockxsoli(Operacion.mask("codAL").val(), idcodigo.trim(), Operacion.mask("txtSolicitante").val(), data.d[i].SR_CSERIE.trim()).cantdiad;

                                $('td:eq(4) :text', row0).val("");
                                if (nrxusu < 1) {
                                    $("td", row0).eq(1).html(data.d[i].SR_NSKDIS);
                                    //$('td:eq(4) :text', row0).attr("disabled",true);
                                } else {
                                    $("td", row0).eq(1).html(cantxusu);
                                    $('td:eq(4) :text', row0).attr("disabled", false);
                                }

                                $("[id*=gvSerie]").append(row0);
                                row0 = $("[id*=gvSerie] tr:last-child").clone(true);

                            }
                        } else {
                            var row0 = $("[id*=gvSerie] tr:last-gvSerie").clone(true);
                            $("[id*=gvSerie] tr").not($("[id*=gvSerie] tr:first-child")).remove();

                            $("td", row0).eq(0).html("");
                            $("td", row0).eq(1).html("");
                            $("td", row0).eq(2).html("");
                            $("td", row0).eq(3).html("");
                            $("td", row0).eq(4).html("");

                            $("[id*=gvSerie]").append(row0);
                            alert("no se encontro registro");
                        }
                    },
                    error: function (response) {
                        console.table(response);
                    }
                });
            }


            $('#btnagregarItem').click(function () {
                if (validaDetalle()) {
                    var cont = 0;
                    //if (rowCount == 2) {
                    //    aa = "1";
                    //}
                    if (Number(Operacion.mask('txtCantidad').val()) > Number(Operacion.mask('lblSTOCK').text())) {
                        alert('La cantidad ingresada no puede ser mayor al stock disponible');
                    } else {
                        aITEMGRILLA();
                    }
                    $(':input').removeAttr('placeholder');
                } else {
                    alert('Debe completar los campos');
                }
            });
            $('.btElegir').live("click", function () {
                //NUEVO ELEGIR UNA SERIE
                //NUEVO ELEGIR UNA SERIE
                var IDSERIE = $(this).parents("tr").find("td").eq(0).html();//SERIE/LOTE
                var CASERIE = $(this).parents("tr").find("td").eq(1).html();//CANTIDAD
                var IDFEVEN = $(this).parents("tr").find("td").eq(2).html();//FECHA VENCIMIENTO
                Operacion.mask('txtSerie').val(IDSERIE);
                Operacion.mask('hfSERIE').val(CASERIE);
                Operacion.mask('txtFechaL').val(IDFEVEN);
                Operacion.mask('txtCantidad').select();
                Operacion.mask('txtCantidad').focus();
                $('#serie').dialog('close');
            });
            $('.btEditar').click(function () {

                if (aIDMOV == "PR" && Operacion.mask("txtIDREF").val().toUpperCase() == "VA") {
                    var trrp = $(this).parent().parent();
                    idprodc = $("td", trrp).eq(1).html();
                    desprodc = $("td", trrp).eq(2).html();
                    undc = $("td", trrp).eq(3).html();
                    ccostoc = $("td", trrp).eq(4).html();
                    validasclot = $("td", trrp).eq(3).val();
                    valcantxitem = $("td", trrp).eq(7).html();
                    if (validasclot.trim() == "N") {
                        alert("Producto No tiene Lotes");
                    } else {
                        mostrarlot(idprodc);
                    }
                } else {

                    //william nose que es señorch
                    var trpex = $(this).parent().parent();
                    idcodix = $("td", trpex).eq(1).html();
                    bandera = false;
                    $('#btnagregarItem').attr('disabled', true);
                    $('#btnActualizar').show();
                    $tr = $(this).closest('tr');
                    myRow = $tr.index();
                    var idProducto = $(this).parents("tr").find("td").eq(1).html();
                    var descripcion = $(this).parents("tr").find("td").eq(2).html();
                    var unidad = $(this).parents("tr").find("td").eq(3).html();
                    var centroc = $(this).parents("tr").find("td").eq(4).html();
                    var serie = $(this).parents("tr").find("td").eq(5).html();
                    var fecha = $(this).parents("tr").find("td").eq(6).html();
                    var cantidad = $(this).parents("tr").find("td").eq(7).html();
                    //$('#MainContent_txtidProducto').val(idProducto);
                    Operacion.mask('txtdescripcion').val(idProducto.trim() + " " + descripcion);
                    Operacion.mask('hdidproducto').val(idProducto);
                    Operacion.mask('hddescripcion').val(descripcion);
                    Operacion.mask('hdfUnidad').val(unidad);
                    //Operacion.mask('txtCentroCosto').val(centroc);
                    Operacion.mask('txtSerie').val(serie);
                    Operacion.mask('txtFechaL').val(fecha);
                    Operacion.mask('txtCantidad').val(cantidad);
                    //if (aIDMOV == "PR" && Operacion.mask("txtIDREF").val().toUpperCase() == "VA") {
                    //}



                }

            });
            $('.btlote').click(function () {
                var trrp = $(this).parent().parent();
                idprodc = $("td", trrp).eq(1).html();
                desprodc = $("td", trrp).eq(2).html();
                undc = $("td", trrp).eq(3).html();
                ccostoc = $("td", trrp).eq(4).html();
                validasclot = $("td", trrp).eq(3).val();
                if (validasclot.trim() == "N") {
                    alert("Producto No tiene Lotes");
                } else {
                    mostrarlot(idprodc);
                }

            });

            $('#btnActualizar').click(function () {
                //$("#gvDetalleEntrada tr:nth-child("+(myRow+1)+") td:nth-child(0)").html();
                //$("#MainContent_gvDetalleEntrada tr:nth-child(" + (myRow + 1) + ") td:nth-child(2)").html($('#MainContent_txtidProducto').val());
                $("#MainContent_gvDetalleEntrada tr:nth-child(" + (myRow + 1) + ") td:nth-child(2)").html(Operacion.mask('hfidproducto').val());
                $("#MainContent_gvDetalleEntrada tr:nth-child(" + (myRow + 1) + ") td:nth-child(3)").html(Operacion.mask('hfdescripcion').val());
                $("#MainContent_gvDetalleEntrada tr:nth-child(" + (myRow + 1) + ") td:nth-child(4)").html(Operacion.mask('hdfUnidad').val());
                $("#MainContent_gvDetalleEntrada tr:nth-child(" + (myRow + 1) + ") td:nth-child(5)").html(Operacion.mask('txtCentroCosto').val());
                $("#MainContent_gvDetalleEntrada tr:nth-child(" + (myRow + 1) + ") td:nth-child(6)").html(Operacion.mask('txtSerie').val());
                $("#MainContent_gvDetalleEntrada tr:nth-child(" + (myRow + 1) + ") td:nth-child(7)").html(Operacion.mask('txtFechaL').val());
                $("#MainContent_gvDetalleEntrada tr:nth-child(" + (myRow + 1) + ") td:nth-child(8)").html(Operacion.mask('txtCantidad').val());
                $("#btnActualizar").hide();
                bandera = true;
                $('#btnagregarItem').removeAttr("disabled");
                limpiarIngresos();
            });
            $(".btEliminar").click(function () {
                var rowCount = $('#MainContent_gvDetalleEntrada tr').length;
                //console.log(rowCount);
                var trp = $(this).parent().parent();
                if (rowCount == 2) {
                    aa = 1; cont1 = 0;
                    vfg = 1;
                    $("td:eq(0)", trp).html("");
                    $("td:eq(1)", trp).html("");
                    $("td:eq(2)", trp).html("");
                    $("td:eq(3)", trp).html("");
                    $("td:eq(4)", trp).html("");
                    $("td:eq(5)", trp).html("");
                    $("td:eq(6)", trp).html("");
                    $("td:eq(7)", trp).html("");
                    $("[id*=gvDetalleEntrada]").append(trp);
                } else {
                    //cont1 = 0;
                    $($(this).closest("tr")).remove();
                }

            });

            $(".btEliminar02").click(function () {
                var rowCount = $('#MainContent_gvlotexvale tr').length;
                //console.log(rowCount);
                var trp = $(this).parent().parent();
                if (rowCount == 2) {
                    $("td:eq(0)", trp).html("");
                    $("td:eq(1)", trp).html("");
                    $("td:eq(2)", trp).html("");
                    $("td:eq(3)", trp).html("");
                    $("td:eq(4)", trp).html("");
                    $("td:eq(5)", trp).html("");
                    $("td:eq(6)", trp).html("");
                    $("td:eq(7)", trp).html("");
                    vfg = 1;
                    $("[id*=gvlotexvale]").append(trp);
                } else {
                    //cont1 = 0;
                    $($(this).closest("tr")).remove();
                }
            });


            $("#btnGuardar").click(function () {

                Operacion.inputEstado('txtSerie', 1, true);
                Operacion.inputEstado('txtFechaL', 1, true);
                if (valida()) {
                    Operacion.inputEstado('btnGuardar', 1, false);
                    aTR = $('#MainContent_lblSalida').text();
                    aIDMOV = $('#MainContent_txtIDMOV').val();//TD
                    aALREF = $('#MainContent_ddlAlmacenRef').val();
                    aIDREF = $('#MainContent_txtIDREF').val();
                    aNROD = $('#MainContent_txtNroDocumento1').val();
                    aCENC = $('#MainContent_txtCentroCosto').val();
                    aAELE = $('#MainContent_codAL').val();
                    aNORD = $('#MainContent_txtOrdenTrabajo').val();
                    Operacion.mask('lblcodigoMovimiento').text(Operacion.mask('txtIDMOV').val());
                    if (aIDMOV == "TD") {
                        IDE = correlativo(aALREF, "PE").idCod; //INGRESO
                        Operacion.mask('codM').val(IDE);
                        IDS = correlativoAux(Operacion.mask('codAL').val(), CTD).idCodA;//SALIDA
                        guardarCabecera(IDE);
                        guardarCabeceraAux(IDS);//TD 
                        $("#MainContent_gvlotexvale").hide();
                        Operacion.mask("lbinf01").hide();
                        Operacion.mask("lbinf02").hide();
                        Operacion.mask("lbinf03").hide();
                        Operacion.mask("txtdescripcion").attr("disabled", false);
                        Operacion.mask("txtCantidad").attr("disabled", false);
                    } else {

                        IDE = correlativo(Operacion.mask('codAL').val(), CTD).idCod;
                        Operacion.mask('codM').val(IDE);
                        guardarCabecera(IDE);//GUARDAR CABECERA

                        //agregar a la grilla la informacion del vale  Sergio 
                        if (aIDMOV == "PR" && Operacion.mask("txtIDREF").val().toUpperCase() == "VA") {
                            limpiargridxlote();
                            Operacion.inputEstado('btnagregarItem', 1, false);
                            ListarGridxVale($("#MainContent_txtNroDocumento1").val());
                            $("#MainContent_gvlotexvale").show();
                            Operacion.mask("lbinf01").show();
                            Operacion.mask("lbinf02").show();
                            Operacion.mask("lbinf03").show();
                            Operacion.mask("txtdescripcion").attr("disabled", true);
                            Operacion.mask("txtCantidad").attr("disabled", true);
                        } else {
                            Operacion.inputEstado('btnagregarItem', 1, true);
                            $("#MainContent_gvlotexvale").hide();
                            Operacion.mask("lbinf01").hide();
                            Operacion.mask("lbinf02").hide();
                            Operacion.mask("lbinf03").hide();
                            Operacion.mask("txtdescripcion").attr("disabled", false);
                            Operacion.mask("txtCantidad").attr("disabled", false);
                        }

                    }
                    $('#detalleCabecera').dialog("open");
                    aa = 1;
                } else {
                    alert('Debe completar todos los campos');
                }
            });

            Operacion.mask("txtNroDocumento1").blur(function () {

                if (Operacion.mask("txtIDREF").val().toUpperCase() == "VA" && Operacion.mask("txtIDMOV").val() == "PR") {
                    var idsolctud = Operacion.mask("txtNroDocumento1").val();
                    var S_solicitant = MostrarInfosolicitud(idsolctud).Solici;
                    var S_estado = MostrarInfosolicitud(idsolctud).Estado;
                    var S_atenc = MostrarInfosolicitud(idsolctud).Atenci;
                    var info = ValidanVale(idsolctud).nvales;
                    var textsolici = Mostrarundato(S_solicitant, '12').ee;
                    if (Number(info) > 0) {

                        if (S_estado == '1') {
                            alert("El vale se encuentra en Estado Emita - Verifique Aprobacion");
                            Operacion.mask("txtNroDocumento1").focus();
                        } else {
                            if (S_atenc == "2") {
                                alert("El vale se encuentra Atendido");
                                Operacion.mask("txtNroDocumento1").focus();
                            } else {
                                Operacion.mask("txtTDRef2").focus();
                                Operacion.mask("txtSolicitante").val(S_solicitant.trim());
                                Operacion.mask("lblSolicitante").text(textsolici);
                                Operacion.mask("txtSolicitante").attr("disabled", true);
                                Operacion.mask("lblSolicitante").attr("disabled", true);
                            }
                        }
                    } else {
                        alert("El Documento no Existe");
                        Operacion.mask("txtNroDocumento1").focus();
                        Operacion.mask("txtNroDocumento1").val("");
                    }


                }
            });

            Operacion.mask("txtNroDocumento1").change(function () {


                if (Operacion.mask("txtIDREF").val().toUpperCase() == "VA" && Operacion.mask("txtIDMOV").val() == "PR") {
                    var idsolctud = Operacion.mask("txtNroDocumento1").val();
                    var S_solicitant = MostrarInfosolicitud(idsolctud).Solici;
                    var S_estado = MostrarInfosolicitud(idsolctud).Estado;
                    var S_atenc = MostrarInfosolicitud(idsolctud).Atenci;
                    var info = ValidanVale(idsolctud).nvales;
                    var textsolici = Mostrarundato(S_solicitant, '12').ee;

                    if (Number(info) > 0) {

                        if (S_estado == '1') {
                            alert("El vale se encuentra en Estado Emita - Verifique Aprobacion");
                        } else {
                            if (S_atenc == "2") {
                                alert("El vale se encuentra Atendido");
                            } else {
                                Operacion.mask("txtTDRef2").focus();
                                Operacion.mask("txtSolicitante").val(S_solicitant.trim());
                                Operacion.mask("lblSolicitante").text(textsolici);
                                Operacion.mask("txtSolicitante").attr("disabled", true);
                                Operacion.mask("lblSolicitante").attr("disabled", true);
                            }
                        }
                    } else {
                        alert("El Documento no Existe");
                        Operacion.mask("txtNroDocumento1").focus();
                        Operacion.mask("txtNroDocumento1").val("");
                    }


                } else {
                    Operacion.mask("txtTDRef2").focus();
                }
            });

            $('#btnFinalizar').click(function () {
                var AL = Operacion.mask('codAL').val();
                var ND = Operacion.mask('txtNumeroDoc').val();
                var TD = "PS";
                var cont = 0;
                var result = confirm('Desea finalizar la operacion');
                if (result) {
                    if (Operacion.mask('txtIDMOV').val() != "PR" && Operacion.mask('txtIDREF').val().toUpperCase() != "VA") {

                        var MISER = Operacion.mask('txtSerie').is(':disabled');
                        gitem = "";
                        var gridView = document.getElementById("<%=gvDetalleEntrada.ClientID %>");
                        for (var t = 1; t < gridView.rows.length; t++) {
                            cellPivot00 = gridView.rows[t].cells[0];
                            gitem00 = cellPivot00.innerHTML;
                            cellPivot01 = gridView.rows[t].cells[1];
                            gitem01 = cellPivot01.innerHTML;
                            cellPivot02 = gridView.rows[t].cells[2];
                            gitem02 = cellPivot02.innerHTML;
                            cellPivot03 = gridView.rows[t].cells[5];
                            gitem03 = cellPivot03.innerHTML;
                            cellPivot031 = gridView.rows[t].cells[6];
                            gitem031 = cellPivot031.innerHTML;
                            cellPivot04 = gridView.rows[t].cells[7];
                            gitem04 = cellPivot04.innerHTML;

                            //KEY: IDE, IT, COD, DES, CANT
                            //pad(gitem00, 4)
                            //ACTUALIZA SERIE / LOTE

                            //solo wiliammm entiende
                            guardardetalleCabecera(Operacion.mask('codM').val(), Operacion.cadenaMascara(t, 4), gitem01, gitem02, gitem04);
                            (aIDMOV == "TD" ? guardardetalleCabeceraAux(IDS, Operacion.cadenaMascara(t, 4), gitem01, gitem02, gitem04) : "");
                            (Operacion.mask('txtIDMOV').val() == "PR" && MISER != true ? actualizaSerieS(AL, gitem01, gitem03, gitem04) : "");
                            (Operacion.mask('txtIDMOV').val() == "PR" && MISER != true ? insertaALSE(AL, Operacion.cadenaMascara(gitem00, 4), gitem01, gitem03, gitem04) : "");

                        }
                    } else {
                        //sergio
                        var stg = RgridClotesumaT().sumaglte;
                        if (Number(stg) < Number(Sumatotallote)) {
                            alert("No Ha completado El Despacho Total del Vale");
                            return;
                        } else {
                            recorregridconlotes();
                            recorregridsinlotes();
                            ActualizaSolitud(Operacion.mask("txtNroDocumento1").val().trim());
                        }
                    }

                    Operacion.inputEstado('btnGuardar', 1, false);//.attr('disabled', true);
                    Operacion.inputEstado('btnagregarItem', 1, false);//.attr('disabled', true);
                    Operacion.inputEstado('btnFinalizar', 1, false);//.attr('disabled', true);
                    //Operacion.inputEstado('txtidProducto', 1, true);//.attr('disabled', true);
                    Operacion.inputEstado('txtdescripcion', 1, true);//.attr('disabled', true);
                    Operacion.inputEstado('txtCantidad', 1, true);//.attr('disabled', true);

                    var rAux1 = (aIDMOV == "TD" ? aALREF : Operacion.mask('codAL').val());
                    var rAux2 = (aIDMOV == "TD" ? "PE" : CTD);
                    var rAux3 = (aIDMOV == "TD" ? Operacion.mask('codM').val() : Operacion.mask('txtNumeroDoc').val());
                    //console.log(rAux3);
                    var auxi = confirm("Documento generado Número " + rAux1 + " " + rAux2 + "-" + rAux3);
                    var auxTD = (aIDMOV == "TD" ? confirm("Documento generado Número " + Operacion.mask('codAL').val() + " " + CTD + "-" + IDS) : "");
                    if (aIDMOV == "TD") {
                        if (auxi && auxTD) {
                            window.location.href = '../ALMACEN/ConsultaReimpresion.aspx';
                        }
                    } else {
                        if (auxi) {
                            //window.location.href = '../ALMACEN/ConsultaReimpresion.aspx';
                            //javascript: window.close;
                            /*if (confirm('Desea imprimir el documento')) {
                                /*if (AL == "0001") {
                                    window.open("../ALMACEN/Reportes/ReporteFinaliza.aspx?AL=" + AL + "&TD=" + TD + "&ND=" + ND, '_blank');
                                    //window.location.href = '../ALMACEN/ConsultaReimpresion.aspx';
                                } else {
                                    window.open("../ALMACEN/Reportes/Reporte.aspx?AL=" + AL + "&TD=" + TD + "&ND=" + ND, '_blank');
                                    //window.location.href = '../ALMACEN/ConsultaReimpresion.aspx';
                                }
                            } else {
                                //window.location.href = '../ALMACEN/ConsultaReimpresion.aspx';
                            }*/
                        } else {
                            //window.location.href = '../ALMACEN/ConsultaReimpresion.aspx';
                        }
                    }
                } else {
                    var result2 = confirm('Desea realizar otro ingreso');
                    if (result2) {
                        //window.location.href = '../ALMACEN/RegistroEntrada.aspx';
                    } else {
                        //window.location.href = '../ALMACEN/ConsultaReimpresion.aspx';
                    }
                }
            });

            /*Autocomplete*/
            $(".tb1").autocomplete(
                {
                    source: function (request, response) {
                        $.ajax({
                            url: "RegistroEntrada.aspx/getMovimientos",
                            data: "{ datos: '" + request.term + "',tipo:'S'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            dataFilter: function (data) { return data; },
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        value: item.TM_CDESCRI,
                                        id: item.TM_CCODMOV

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

                        //$('#MainContent_lblCodigoM').text(str);
                        $('#MainContent_lblFechaDocD').val($('#MainContent_lblFechaE').val());
                        $("#MainContent_lbltipoRegistro").val($('#MainContent_lblSalida').val());
                        $('#MainContent_txtIDMOV').val(str);
                        $('#MainContent_codM').val(str);//CODIGO MOVIMIENTO
                        $('#MainContent_lblcodigoMovimiento').text($('#MainContent_txtIDMOV').val() + "-" + $('#MainContent_txtCodigoMov').val());//DETALLE CABECERA

                        bloqueo(str);
                    }
                });
            $(".tb2").autocomplete(
                {   /*TIPO DOCUMENTO*/
                    source: function (request, response) {
                        $.ajax({
                            url: "RegistroEntrada.aspx/Gettablaydetalle",
                            data: "{ 'dato': '" + request.term + "', codigo:'04' }",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            dataFilter: function (data) { return data; },
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        value: item.TG_CDESCRI,
                                        id: item.TG_CCLAVE
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
                        //alert(str);
                        //$('#MainContent_lblTDRef1').text(str);
                        $('#MainContent_txtIDREF').val(str);
                        $('#MainContent_codDR').val(str);
                        $('#MainContent_lblcodigoMovimiento').text(str);//cabecera detalle
                        //$('#txtCodigoMov').val(str);

                    }
                });
            $(".tb21").autocomplete(
                {   /*TIPO DOCUMENTO*/
                    source: function (request, response) {
                        $.ajax({
                            url: "RegistroEntrada.aspx/Gettablaydetalle",
                            data: "{ 'dato': '" + request.term + "', codigo:'04' }",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            dataFilter: function (data) { return data; },
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        value: item.TG_CDESCRI,
                                        id: item.TG_CCLAVE
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
                        $('#MainContent_txtTDRef2').val(str);
                        //$('#MainContent_codDR').val(str);
                    }
                });
            /*$(".tb3").autocomplete(
                {CENTRO DE COSTO
                    source: function (request, response) {
                        $.ajax({
                            url: "RegistroEntrada.aspx/Gettablaycodigo",
                            data: "{ 'dato': '" + request.term + "', codigo:'10'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            dataFilter: function (data) { return data; },
                            success: function (data) {

                                response($.map(data.d, function (item) {
                                    //var codigo = item.TG_CCLAVE;//.replace("/^\s*|\s*$/g", "");
                                    //codigo = codigo.replace("/^\s*|\s*$/g", "");
                                    var codigo = item.TG_CCLAVE;
                                    return {
                                        value: codigo.trim(),
                                        id: item.TG_CDESCRI
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
                        //CENTRO DE COSTO
                        Operacion.mask('txtDetalleCC').val(str);
                        Operacion.mask('codCC').val(str);
                        Operacion.mask('txtGlosa1').focus();
                    }
                });*/
            $(".tb4").autocomplete(
                {   /*PROVEEDORES*/
                    source: function (request, response) {
                        var TM = Operacion.mask('txtIDMOV').val();
                        var MOP = Operacion.mask('cb1').is(':checked');
                        var ADATA = {};
                        if (MOP == true) {
                            ADATA.AC_CVANEXO = "P";
                            ADATA.AC_CNOMBRE = '%' + request.term + '%';
                            ADATA.AV_CDOCIDE = "";
                            ADATA.AC_CTIPOAC = "PX";
                        } else {
                            ADATA.AC_CVANEXO = "P";
                            ADATA.AC_CNOMBRE = '%' + request.term + '%';
                            ADATA.AV_CDOCIDE = (TM == "MP" ? 1 : 6);//VARIAR 1:PL|6:PU
                            ADATA.AC_CTIPOAC = (jQuery.inArray(Operacion.mask('codAL').val(), MARRAY) !== -1 ? (TM == "MP" ? "PL" : "PU") : "");
                        }
                        console.log(ADATA);
                        $.ajax({
                            //url: "RegistroEntrada.aspx/getClienteT",
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
                        Operacion.mask('lblProveedor').text(str);
                        Operacion.mask('txtIDREF').focus();
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
            $(".tb41").autocomplete(
                {   /*CLIENTES*/
                    source: function (request, response) {
                        var TM = Operacion.mask('txtIDMOV').val();
                        var ADATA = {};
                        ADATA.AVANEXO = "C";
                        ADATA.ADESANE = '%' + request.term + '%';
                        ADATA.ATIPTRA = (TM == "CO" ? "J" : (TM == "MP" ? "N" : null));
                        $.ajax({
                            //data: "{COD:'C',CAD: '" + request.term + "'}",
                            url: "RegistroEntrada.aspx/getClienteT",
                            data: '{ADATA:' + JSON.stringify(ADATA) + '}',
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            dataFilter: function (data) { return data; },
                            success: function (data) {

                                response($.map(data.d, function (item) {
                                    return {
                                        value: item.ADESANE,
                                        id: item.ACODANE
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
                        //alert(str);
                        $('#MainContent_txtIDCL').val(str);
                    }
                });
            /*$(".tb5").autocomplete(
                {busca codigo-propducto
                    //txtidProducto
                    source: function (request, response) {
                        $.ajax({
                            //url: "RegistroEntrada.aspx/getProductoID",
                            //data: "{ 'dato': '" + request.term + "'}",
                            url: "RegistroEntrada.aspx/getProductoAS",
                            data: "{ dato: '" + "%" + request.term + "%" + "',TR:'S',AL:'" + Operacion.mask('codAL').val() + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            dataFilter: function (data) { return data; },
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    var codigo = item.AR_CCODIGO;
                                    return {
                                        value: codigo.trim(),// + " " + item.AR_CDESCRI,
                                        id: item.AR_CDESCRI,
                                        un: item.AR_CUNIDAD,
                                        sr: item.AR_CFSERIE,
                                        lt: item.AR_CFLOTE
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
                        var str = ui.item.id; var str1 = ui.item.value; var str2 = ui.item.un; var slt = ui.item.lt; var ser = ui.item.sr;
                        $('#MainContent_lblUnidad').text(str2);
                        $('#MainContent_hdfUnidad').val(str2);
                        stockCOD($('#MainContent_codAL').val(), str1, Operacion.mask('lblSalida').text().trim());
                        $('#MainContent_txtdescripcion').val(str);
                        Operacion.inputEstado('btnagregarItem', 0, false);
                        //(ser == "S" ? Operacion.inputEstado('txtSerie', 0, true) : Operacion.inputEstado('txtSerie', 1, true));//SI ESTA HABILITADO PARA SERIE
                        (slt == "S" ? Operacion.inputEstado('txtSerie', 0, true) : Operacion.inputEstado('txtSerie', 1, true));//SI ESTA HABILITADO PARA SERIE
                        (slt == "S" ? Operacion.inputEstado('txtFechaL', 0, true) : Operacion.inputEstado('txtFechaL', 1, true));//SI ESTA HABILITADO PARA LOTE
                    },
                    change: function (event, ui) {
                        if (ui.item == null || ui.item == undefined) {
                            alert("No ha seleccionado un codigo valido");
                            //Operacion.mask('txtidProducto').focus();
                            Operacion.mask('txtidProducto').val('');
                            Operacion.mask('txtdescripcion').val('');
                        }
                    }
                });*/
            $(".tb6").autocomplete(
                {/*busca propducto-codigo*/
                    //txtdescripcion
                    source: function (request, response) {
                        $.ajax({
                            url: "RegistroEntrada.aspx/" + miconsulta,//getProducto
                            data: "{ dato: '" + "%" + request.term + "%" + "',TR:'S',AL:'" + Operacion.mask('codAL').val() + "'}",
                            //data: "{ 'dato': '" + "%" + request.term + "%" + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            dataFilter: function (data) { return data; },
                            success: function (data) {
                                //console.log(data.d);
                                response($.map(data.d, function (item) {
                                    var codigo = item.AR_CCODIGO;
                                    return {
                                        //value: item.AR_CDESCRI,
                                        value: codigo.trim() + " " + item.AR_CDESCRI,
                                        ds: item.AR_CDESCRI,
                                        id: codigo,
                                        un: item.AR_CUNIDAD,
                                        sr: item.AR_CFSERIE,
                                        lt: item.AR_CFLOTE
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
                        var str = ui.item.id; var str1 = ui.item.un; var slt = ui.item.lt; var ser = ui.item.sr;
                        stockCOD(Operacion.mask('codAL').val(), str, Operacion.mask('lblSalida').text().trim());
                        Operacion.mask('lblUnidad').text(str1);
                        Operacion.mask('hfidproducto').val(str);//ID PRODUCTO
                        Operacion.mask('hfdescripcion').val(ui.item.ds);//DES PRODUCTO
                        Operacion.mask('hdfUnidad').val(str1);
                        Operacion.mask('txtidProducto').val(str);
                        //Operacion.mask('txtdescripcion').val(ui.item.ds);
                        (slt == "S" ? Operacion.inputEstado('txtSerie', 0, true) : Operacion.inputEstado('txtSerie', 1, true));
                        (slt == "S" ? Operacion.inputEstado('txtFechaL', 0, true) : Operacion.inputEstado('txtFechaL', 1, true));
                        (bandera == true ? Operacion.inputEstado('btnagregarItem', 0, false) : "");//.removeAttr("disabled");
                    },
                    change: function (event, ui) {
                        if (ui.item == null || ui.item == undefined) {
                            alert("No ha seleccionado un producto correcto");
                            Operacion.mask('txtdescripcion').focus();
                            Operacion.mask('txtdescripcion').val('');
                            //Operacion.mask('txtidProducto').val('');
                        }
                    }
                });
            $(".tb61").autocomplete(
               {/*SERIE*/
                   source: function (request, response) {
                       $.ajax({
                           url: "RegistroEntrada.aspx/getLOTES",
                           data: "{ AL:'" + Operacion.mask('codAL').val() + "',COD:'" + Operacion.mask('txtidProducto').val() + "',SER: '" + request.term + "'}",
                           dataType: "json",
                           type: "POST",
                           contentType: "application/json; charset=utf-8",
                           dataFilter: function (data) { return data; },
                           success: function (data) {
                               response($.map(data.d, function (item) {
                                   //var codigo = item.AR_CCODIGO;
                                   //stockCOD($('#MainContent_codAL').val(), codigo);
                                   return {
                                       value: item.SR_CSERIE,
                                       id: item.SR_NSKDIS,
                                       vfecha: item.SR_DFECVEN//item.SR_DFECMOV
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
                       var str1 = ui.item.vfecha;
                       var dfecha = moment(str1).format('DD/MM/YYYY');
                       Operacion.mask('txtFechaL').val(dfecha);//FECHA LOTE
                       Operacion.mask('lblSCantidad').text(str); // CANTIDAD LOTE
                   }
               });
            var cont1 = 0;
            function aITEMGRILLA() {
                //var counter = $('#myTable tr').length - 2;
                //$('#MainContent_gvDetalleEntrada').attr('style', 'background-color:White;border-color:#CCCCCC;border-width:1px;border-style:None;border-collapse:collapse;');
                var rowt = $("[id*=gvDetalleEntrada] tr:last-child").clone(true);
                if (aa == 1) {
                    $("[id*=gvDetalleEntrada] tr").not($("[id*=gvDetalleEntrada] tr:first-child")).remove();
                    aa = 2;
                }
                var rowCount = $('#MainContent_gvDetalleEntrada tr').length;
                //$("#MainContent_gvDetalleEntrada tr:nth-child(1) td:nth-child(2)").html('HOLA');
                //$('#MainContent_gvDetalleEntrada').empty();
                //$("#MainContent_gvDetalleEntrada").append("<tr style='color:White;background-color:#006699;font-weight:bold;'><th align='center' scope='col' style='font-size:8pt;width:100px;'>ITEM</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>CODIGO</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>DESCRIPCION</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>UNID</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>CENTRO COSTO</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>SERIE</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>FECHA DOC</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>CANTIDAD</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>-</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>-</th></tr>");
                cont1 = (rowCount - 1) + 1;
                OBJ = [
                    "*",
                    Operacion.mask('hfidproducto').val(),//Operacion.mask('txtidProducto').val(),
                    Operacion.mask('hfdescripcion').val(),//Operacion.mask('txtdescripcion').val(),
                    Operacion.mask('hdfUnidad').val(),
                    (Operacion.mask('txtCentroCosto').val() != "" ? Operacion.mask('txtCentroCosto').val() : Operacion.mask('txtOrdenTrabajo').val()),
                    Operacion.mask('txtSerie').val(),
                    Operacion.mask('txtFechaL').val(),
                    Operacion.mask('txtCantidad').val(),
                ];
                //ITEM, CODIGO, PRODUCTO, UNID, FECHA, CANTIDAD
                var aux; //var a = parseInt("10000000");
                jQuery.each(OBJ, function (i, val) {
                    $("td", rowt).eq(i).html((val == "*" ? cont1 : val));
                    //}
                });

                $("[id*=gvDetalleEntrada]").append(rowt);
                rowt = $("[id*=gvDetalleEntrada] tr:last-child").clone(true);
                limpiarIngresos();
            }

            function actualizaStock(codigo, cantidad, op, almacen) {
                if (cantidad != null) {
                    var CANTFINAL = Number(cantidad);//Number(AUXCANT) + Number(cantidad);
                    var DATAI = {};
                    DATAI.SK_CALMA = almacen;//Operacion.mask('codAL').val();
                    DATAI.SK_CCODIGO = codigo;
                    DATAI.SK_NSKDIS = CANTFINAL;

                    $.ajax({
                        type: "POST",
                        url: "RegistroEntrada.aspx/actualizaStock",
                        data: '{DATAI:' + JSON.stringify(DATAI) + ',OP:' + op + '}',
                        contentType: "application/json;charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (response) {

                        },
                        error: function (response) {
                            console.table(response);
                        }
                    });
                }
            }

            //INGRESO
            function guardarCabecera(IDE) {
                fecha = moment(Operacion.mask('lblFechaDocD').text(), 'DD-MM-YYYY 00:00:00.000');
                fechac = moment();
                var DATA = {};
                var numDoc = "";

                DATA.C5_CALMA = (aIDMOV == "TD" ? aALREF : aAELE);//Session["aID"].ToString(), //REEMPLAZAR
                DATA.C5_CTD = (aIDMOV == "TD" ? "PE" : "PS");
                DATA.C5_CNUMDOC = IDE;//idCod;
                DATA.C5_CLOCALI = "0001";//FIJO SE COORDINO
                DATA.C5_DFECDOC = fecha;
                DATA.C5_DFECVEN = null;
                DATA.C5_CTIPMOV = (aIDMOV == "TD" ? "E" : aTR);
                DATA.C5_CCODMOV = aIDMOV;
                DATA.C5_CSITUA = "";
                DATA.C5_CRFTDOC = (aIDMOV == "TD" ? "PS" : (aIDREF != " " ? aIDREF.trim() : ""));//FT,LQ,RQ
                DATA.C5_CRFNDOC = (aIDMOV == "TD" ? idCodA : (aNROD != "" ? aNROD : "-"));
                DATA.C5_CSOLI = "";
                DATA.C5_CCENCOS = (aCENC != "" ? aCENC : "");
                DATA.C5_CRFALMA = (aIDMOV == "TD" ? aAELE : (aALREF == "" ? "" : aALREF));
                DATA.C5_CGLOSA1 = (Operacion.mask('txtGlosa1').val() != "" ? Operacion.mask('txtGlosa1').val() : "");
                DATA.C5_CGLOSA2 = (Operacion.mask('txtGlosa2').val() != "" ? Operacion.mask('txtGlosa2').val() : "");
                DATA.C5_CGLOSA3 = (Operacion.mask('txtGlosa3').val() != "" ? Operacion.mask('txtGlosa3').val() : "");
                DATA.C5_CTIPANE = "";
                DATA.C5_CCODANE = "";
                DATA.C5_DFECCRE = fechac;
                DATA.C5_CUSUCRE = Operacion.mask('hdUSUARIO').val();
                DATA.C5_DFECMOD = null;
                DATA.C5_CUSUMOD = "";
                DATA.C5_CCODCLI = Operacion.mask('txtIDCL').val();
                DATA.C5_CNOMCLI = Operacion.mask('txtCliente').val();
                DATA.C5_CRUC = "";
                DATA.C5_CCODCAD = "";
                DATA.C5_CCODINT = "";
                DATA.C5_CCODTRA = "";
                DATA.C5_CNOMTRA = "";
                DATA.C5_CCODVEH = "";
                DATA.C5_CTIPGUI = (aIDMOV == "TD" ? aIDMOV : "");
                DATA.C5_CSITGUI = (aIDMOV == "TD" ? "V" : "");//F,A,V
                DATA.C5_CGUIFAC = "";
                DATA.C5_CDESTIN = "";
                DATA.C5_CDIRENV = "";
                DATA.C5_CNUMORD = (aNORD != "" ? aNORD : "");
                DATA.C5_CTIPORD = "";
                DATA.C5_CGUIDEV = "";
                DATA.C5_CCODPRO = Operacion.mask('lblProveedor').text();
                DATA.C5_CNOMPRO = Operacion.mask('txtProveedor').val();
                DATA.C5_CCIAS = (Operacion.mask('txtOrdenCompra').val() != "" ? Operacion.mask('txtOrdenCompra').val() : "");
                DATA.C5_CFORVEN = "";//006,007,014
                DATA.C5_CCODMON = (Operacion.mask('ddlMoneda').val() != "-1" ? Operacion.mask('ddlMoneda').val() : Operacion.mask('ddlMoneda').val().trim());
                DATA.C5_CVENDE = "";//BROKER
                DATA.C5_NTIPCAM = 0;
                DATA.C5_CCODAGE = "";//001
                DATA.C5_CNUMPED = ""; //PROFORMAS
                DATA.C5_CDIRECC = ""; //DIRECCION
                DATA.C5_NIMPORT = 0;
                DATA.C5_CTIPO = "";
                DATA.C5_CSUBDIA = "";
                DATA.C5_CCOMPRO = "";
                DATA.C5_NPORDE1 = 0;
                DATA.C5_NPORDE2 = 0;
                DATA.C5_CTF = "";//02
                DATA.C5_NFLETE = 0;
                DATA.C5_CCODAUT = "";
                DATA.C5_CRFTDO2 = (Operacion.mask('txtTDRef2').val() != "" ? Operacion.mask('txtTDRef2').val().trim() : "");
                DATA.C5_CRFNDO2 = (Operacion.mask('txtNroDocumento2').val() != "" ? Operacion.mask('txtNroDocumento2').val() : "");
                DATA.C5_CNUMLIQ = "";
                DATA.C5_CORDEN = "";
                DATA.C5_CTIPOGS = "";//
                DATA.C5_DFECANU = null;
                DATA.C5_CCODFER = "";
                DATA.C5_DFECEMB = null;
                DATA.C5_CGLOSA4 = "";//REEMPLAZAR
                DATA.C5_CVENDE2 = "";
                DATA.C5_CESTDEV = "";
                DATA.C5_CEXTOR = "";
                DATA.C5_CRENOM = "";
                DATA.C5_CRERUC = "";
                DATA.C5_CREREF = "";
                DATA.C5_CDSNOM = "";
                DATA.C5_CDSRUC = "";
                DATA.C5_CLLECIU = "";
                DATA.C5_CPARCIU = "";
                DATA.C5_CTTRACT = "";
                DATA.C5_CTRASRE = "";
                DATA.C5_CTRAREM = "";
                DATA.C5_CLICCON = "";
                DATA.C5_CSBNOM = "";
                DATA.C5_CSBRUC = "";
                DATA.C5_CSBMTC = "";
                DATA.C5_CMONPER = "";
                DATA.C5_NIMPPER = 0;
                DATA.C5_CFPERCP = "";
                DATA.C5_CESTFIN = "";
                DATA.C5_CFLGPEN = "";
                DATA.C5_CTIPFOR = "";
                DATA.C5_NPORPER = 0;
                DATA.C5_CFLGTRM = "";
                DATA.C5_CAGETRA = "";
                DATA.C5_CCONTAI = "";

                $.ajax({
                    type: "POST",
                    url: "RegistroEntrada.aspx/guardarCabecera",
                    data: '{DATA:' + JSON.stringify(DATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        //alert("Se realizo el ingreos");
                    },
                    error: function (response) {
                        console.table(response);
                    }
                });
            }
            //SALIDA
            function guardarCabeceraAux(IDS) {
                fecha = moment(Operacion.mask('lblFechaDocD').text(), 'DD-MM-YYYY 00:00:00.000');
                /*var aTR = ('#MainContent_lblSalida').text();
                var aIDMOV = $('#MainContent_txtIDMOV').val();//TD
                var aALREF = $('#MainContent_ddlAlmacenRef').val();
                var aIDREF = $('#MainContent_txtIDREF').val();
                var aNROD = $('#MainContent_txtNroDocumento1').val();
                var aCENC = $('#MainContent_txtCentroCosto').val();
                var aAELE = $('#MainContent_codAL').val();
                var aNORD = $('#MainContent_txtOrdenTrabajo').val();*/
                var DATA = {};
                var numDoc = "";

                DATA.C5_CALMA = (aIDMOV == "TD" ? aAELE : aALREF);//Session["aID"].ToString(), //REEMPLAZAR
                DATA.C5_CTD = (aIDMOV == "TD" ? "PS" : "PE");
                DATA.C5_CNUMDOC = IDS;//idCodA;
                DATA.C5_CLOCALI = "0001";//FIJO SE COORDINO
                DATA.C5_DFECDOC = fecha;
                DATA.C5_DFECVEN = null;
                DATA.C5_CTIPMOV = (aIDMOV == "TD" ? aTR : "E");
                DATA.C5_CCODMOV = aIDMOV;//TD
                DATA.C5_CSITUA = "";
                DATA.C5_CRFTDOC = (aIDMOV == "TD" ? "PE" : (aIDREF != " " ? aIDREF.trim() : ""));//FT,LQ,RQ
                DATA.C5_CRFNDOC = (aIDMOV == "TD" ? idCod : (aNROD != "" ? aNROD : "-"));
                DATA.C5_CSOLI = "";
                DATA.C5_CCENCOS = (aCENC != "" ? aCENC : "");
                DATA.C5_CRFALMA = (aIDMOV == "TD" ? (aALREF == "" ? "" : aALREF) : aAELE);
                DATA.C5_CGLOSA1 = (Operacion.mask('hfG1').val() != "-1" ? Operacion.mask('hfG1').val().trim() : Operacion.mask('txtGlosa1').val());
                DATA.C5_CGLOSA2 = ($('#MainContent_txtGlosa2').val() != "" ? $('#MainContent_txtGlosa2').val() : "");
                DATA.C5_CGLOSA3 = ($('#MainContent_txtGlosa3').val() != "" ? $('#MainContent_txtGlosa3').val() : "");
                DATA.C5_CTIPANE = "";
                DATA.C5_CCODANE = "";
                DATA.C5_DFECCRE = fecha;
                DATA.C5_CUSUCRE = $('#MainContent_hdUSUARIO').val();
                DATA.C5_DFECMOD = null;
                DATA.C5_CUSUMOD = "";
                DATA.C5_CCODCLI = $('#MainContent_txtIDCL').val();
                DATA.C5_CNOMCLI = $('#MainContent_txtCliente').val();
                DATA.C5_CRUC = "";
                DATA.C5_CCODCAD = "";
                DATA.C5_CCODINT = "";
                DATA.C5_CCODTRA = "";
                DATA.C5_CNOMTRA = "";
                DATA.C5_CCODVEH = "";
                DATA.C5_CTIPGUI = (aIDMOV == "TD" ? "" : aIDMOV);
                DATA.C5_CSITGUI = (aIDMOV == "TD" ? "" : "V");//F,A,V
                DATA.C5_CGUIFAC = "";
                DATA.C5_CDESTIN = "";
                DATA.C5_CDIRENV = "";
                DATA.C5_CNUMORD = (aNORD != "" ? aNORD : "");
                DATA.C5_CTIPORD = "";
                DATA.C5_CGUIDEV = "";
                DATA.C5_CCODPRO = $('#MainContent_txtProveedor').val();
                DATA.C5_CNOMPRO = $('#MainContent_lblProveedor').text();
                DATA.C5_CCIAS = "";
                DATA.C5_CFORVEN = "";//006,007,014
                DATA.C5_CCODMON = $('#MainContent_ddlMoneda').val().trim();
                DATA.C5_CVENDE = "";//BROKER
                DATA.C5_NTIPCAM = 0;
                DATA.C5_CCODAGE = "";//001
                DATA.C5_CNUMPED = ""; //PROFORMAS
                DATA.C5_CDIRECC = ""; //DIRECCION
                DATA.C5_NIMPORT = 0;
                DATA.C5_CTIPO = "";
                DATA.C5_CSUBDIA = "";
                DATA.C5_CCOMPRO = "";
                DATA.C5_NPORDE1 = 0;
                DATA.C5_NPORDE2 = 0;
                DATA.C5_CTF = "";//02
                DATA.C5_NFLETE = 0;
                DATA.C5_CCODAUT = "";
                DATA.C5_CRFTDO2 = ($('#MainContent_txtTDRef2').val() != "" ? $('#MainContent_txtTDRef2').val().trim() : "");
                DATA.C5_CRFNDO2 = ($('#MainContent_txtNroDocumento2').val() != "" ? $('#MainContent_txtNroDocumento2').val() : "");
                DATA.C5_CNUMLIQ = "";
                DATA.C5_CORDEN = "";
                DATA.C5_CTIPOGS = "";//N
                DATA.C5_DFECANU = null;
                DATA.C5_CCODFER = "";
                DATA.C5_DFECEMB = null;
                DATA.C5_CGLOSA4 = "";
                DATA.C5_CVENDE2 = "";
                DATA.C5_CESTDEV = "";
                DATA.C5_CEXTOR = "";
                DATA.C5_CRENOM = "";
                DATA.C5_CRERUC = "";
                DATA.C5_CREREF = "";
                DATA.C5_CDSNOM = "";
                DATA.C5_CDSRUC = "";
                DATA.C5_CLLECIU = "";
                DATA.C5_CPARCIU = "";
                DATA.C5_CTTRACT = "";
                DATA.C5_CTRASRE = "";
                DATA.C5_CTRAREM = "";
                DATA.C5_CLICCON = "";
                DATA.C5_CSBNOM = "";
                DATA.C5_CSBRUC = "";
                DATA.C5_CSBMTC = "";
                DATA.C5_CMONPER = "";
                DATA.C5_NIMPPER = 0;
                DATA.C5_CFPERCP = "";
                DATA.C5_CESTFIN = "";
                DATA.C5_CFLGPEN = "F";
                DATA.C5_CTIPFOR = "";
                DATA.C5_NPORPER = 0;
                DATA.C5_CFLGTRM = "";
                DATA.C5_CAGETRA = "";
                DATA.C5_CCONTAI = "";

                $.ajax({
                    type: "POST",
                    url: "RegistroEntrada.aspx/guardarCabecera",
                    data: '{DATA:' + JSON.stringify(DATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        //alert("Se realizo el ingreos");
                    },
                    error: function (response) {
                        console.table(response);
                    }
                });
            }

            //IT:ITEMS COD:CODIGO PROD DES:PRODUCTO CANT:CANTIDAD
            function guardardetalleCabecera(IDE, IT, COD, DES, CANT) {
                //stockCOD($('#MainContent_codAL').val(), COD);
                var fechaDC = moment(Operacion.mask('lblFechaDocD').text(), 'DD-MM-YYYY 00:00:00.000');
                var DATAD = {};
                var LDES = DES;
                var NDES = (typeof LDES == 'undefined' ? "" : LDES.substring(0, 50));

                DATAD.C6_CALMA = (aIDMOV == "TD" ? aALREF : aAELE);
                DATAD.C6_CTD = (aIDMOV == "TD" ? "PE" : "PS");//$('#MainContent_txtIDREF').val().trim();
                DATAD.C6_CNUMDOC = IDE;//$('#MainContent_txtNumeroDoc').val();
                DATAD.C6_CITEM = IT;//REEMPLAZAR-4
                DATAD.C6_CLOCALI = "0001";//REEMPLAZAR
                DATAD.C6_CCODIGO = COD;//$('#MainContent_txtidProducto').val();//REEMPLAZAR
                DATAD.C6_NCANTID = CANT;//$('#MainContent_txtdescripcion').val();//REEMPLAZAR
                DATAD.C6_NCANTEN = 0;
                DATAD.C6_NCANFAC = 0;
                DATAD.C6_NPREUN1 = 0;
                DATAD.C6_NPREUNI = 0;
                DATAD.C6_NMNPRUN = 0;
                DATAD.C6_NUSPRUN = 0;
                DATAD.C6_CSERIE = "";
                DATAD.C6_CSITUA = "-";
                DATAD.C6_DFECDOC = fechaDC;
                DATAD.C6_DFECVEN = null;
                DATAD.C6_DFECENT = null;
                DATAD.C6_CRFALMA = (aIDMOV == "TD" ? aAELE : (aALREF == "" ? "" : aALREF));
                DATAD.C6_CTALLA = "";
                DATAD.C6_CESTADO = (aIDMOV == "TD" ? "S" : "");
                DATAD.C6_CCODMOV = (aIDMOV == "TD" ? aIDMOV : Operacion.mask('txtIDMOV').val()); //$('#MainContent_codM').val());// EP/CO/SP
                DATAD.C6_CORDEN = "";
                DATAD.C6_NVALTOT = 0;
                DATAD.C6_NMNIMPO = 0;
                DATAD.C6_NUSIMPO = 0;
                DATAD.C6_CSUBDIA = "";
                DATAD.C6_CCOMPRO = "";
                DATAD.C6_CCODMON = "";
                DATAD.C6_CTIPO = "";
                DATAD.C6_NTIPCAM = 0;
                DATAD.C6_NPREVTA = 0;
                DATAD.C6_CMONVTA = "";
                DATAD.C6_NUNXENV = 0;
                DATAD.C6_NNUMENV = 0;
                DATAD.C6_NDEVOL = 0;
                DATAD.C6_CCENCOS = Operacion.mask('txtCentroCosto').val();//CENTRO COSTO-REEMPLAZAR
                DATAD.C6_CSOLI = "";
                DATAD.C6_NPRECIO = 0;
                DATAD.C6_NPRECI1 = 0;
                DATAD.C6_NDESCTO = 0;
                DATAD.C6_NIGV = 0;
                DATAD.C6_NIGVPOR = 0;
                DATAD.C6_NIMPMN = 0;
                DATAD.C6_NIMPUS = 0;
                DATAD.C6_CDESCRI = NDES;//$('#MainContent_txtdescripcion').val();//REEMPLAZAR-DESCRIPCION PRODUCTO
                DATAD.C6_NPORDE1 = 0;
                DATAD.C6_NIMPO1 = 0;
                DATAD.C6_NPORDE2 = 0;
                DATAD.C6_NIMPO2 = 0;
                DATAD.C6_NPORDE3 = 0;
                DATAD.C6_NIMPO3 = 0;
                DATAD.C6_NPORDE4 = 0;
                DATAD.C6_NIMPO4 = 0;
                DATAD.C6_NPORDE5 = 0;
                DATAD.C6_NIMPO5 = 0;
                DATAD.C6_NPORDES = 0;
                DATAD.C6_CTIPITM = "";
                DATAD.C6_CNUMPAQ = "";
                DATAD.C6_CCODLIN = "";
                DATAD.C6_CNROTAB = "";
                DATAD.C6_CNDSCF = "";
                DATAD.C6_CNDSCL = "";
                DATAD.C6_CNDSCA = "";
                DATAD.C6_CNDSCB = "";
                DATAD.C6_CNFLAT = "";
                DATAD.C6_NPESO = 0;
                DATAD.C6_CTR = "";//REVISAR
                DATAD.C6_NPRSIGV = 0;
                DATAD.C6_CTIPANE = "";
                DATAD.C6_CCODANE = "";
                DATAD.C6_CSTOCK = "";
                DATAD.C6_CCODAGE = "";
                DATAD.C6_CCODAUX = "";
                DATAD.C6_CITEREQ = "";
                DATAD.C6_CNROREQ = "";
                DATAD.C6_NTEMPER = 0;
                DATAD.C6_NISCPOR = 0;
                DATAD.C6_NISC = 0;
                DATAD.C6_CITEFAC = "";
                DATAD.C6_NCANRPE = 0;
                DATAD.C6_CNUMREQ = "";
                DATAD.C6_CITERQ = "";
                DATAD.C6_CCODRQ = "";
                DATAD.C6_DFECRQ = null;
                DATAD.C6_CTIPPRO = "";
                DATAD.C6_NCANREQ = 0;
                DATAD.C6_CCTACMO = "";
                DATAD.C6_CNUMORD = "";
                DATAD.C6_CUMREF = "";
                DATAD.C6_NCANDEC = 0;
                DATAD.C6_NCANREF = 0;
                DATAD.C6_CITEMOC = "";
                DATAD.C6_CVANEXO = "";
                DATAD.C6_CVANEX2 = "";
                DATAD.C6_CCODAN2 = "";
                DATAD.C6_CCODEMPQ = "";
                $.ajax({
                    type: "POST",
                    url: "RegistroEntrada.aspx/guardarDetalleCabecera",
                    data: '{DATA:' + JSON.stringify(DATAD) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        actualizaStock(COD, CANT, (aIDMOV == "TD" ? 1 : 0), (aIDMOV == "TD" ? aALREF : aAELE));
                    },
                    error: function (response) {
                        alert(response);
                        console.log(response);
                    }
                });
            }

            function limpiargridxlote() {
                var rowlg = $("[id*=gvlotexvale] tr:last-child").clone(true);
                $("[id*=gvlotexvale] tr").not($("[id*=gvlotexvale] tr:first-child")).remove();

                $("td", rowlg).eq(0).html("");
                $("td", rowlg).eq(1).html("");
                $("td", rowlg).eq(2).html("");
                $("td", rowlg).eq(3).html("");
                $("td", rowlg).eq(4).html("");
                $("td", rowlg).eq(5).html("");
                $("td", rowlg).eq(6).html("");
                $("td", rowlg).eq(7).html("");
                $("[id*=gvlotexvale]").append(rowlg);
            }
            //IT:ITEMS COD:CODIGO PROD DES:PRODUCTO CANT:CANTIDAD
            function guardardetalleCabeceraAux(IDS, IT, COD, DES, CANT) {
                //stockCOD($('#MainContent_codAL').val(), COD);
                var fechaDC = moment(Operacion.mask('lblFechaDocD').text(), 'DD-MM-YYYY 00:00:00.000');
                var DATAD = {};
                var LDES = DES;
                var NDES = (typeof LDES == 'undefined' ? "" : LDES.substring(0, 50));

                DATAD.C6_CALMA = (aIDMOV == "TD" ? aAELE : aALREF);
                DATAD.C6_CTD = (aIDMOV == "TD" ? "PS" : "PE");//$('#MainContent_txtIDREF').val().trim();
                DATAD.C6_CNUMDOC = IDS;//$('#MainContent_txtNumeroDoc').val();
                DATAD.C6_CITEM = IT;//REEMPLAZAR-4
                DATAD.C6_CLOCALI = "0001";//REEMPLAZAR
                DATAD.C6_CCODIGO = COD;//$('#MainContent_txtidProducto').val();//REEMPLAZAR
                DATAD.C6_NCANTID = CANT;//$('#MainContent_txtdescripcion').val();//REEMPLAZAR
                DATAD.C6_NCANTEN = 0;
                DATAD.C6_NCANFAC = 0;
                DATAD.C6_NPREUN1 = 0;
                DATAD.C6_NPREUNI = 0;
                DATAD.C6_NMNPRUN = 0;
                DATAD.C6_NUSPRUN = 0;
                DATAD.C6_CSERIE = "";
                DATAD.C6_CSITUA = "-";
                DATAD.C6_DFECDOC = fechaDC;
                DATAD.C6_DFECVEN = null;
                DATAD.C6_DFECENT = null;
                DATAD.C6_CRFALMA = (aIDMOV == "TD" ? (aALREF == "" ? "" : aALREF) : aAELE);
                DATAD.C6_CTALLA = "";
                DATAD.C6_CESTADO = (aIDMOV == "TD" ? "V" : "");
                DATAD.C6_CCODMOV = (aIDMOV == "TD" ? aIDMOV : Operacion.mask('codM').val());// EP/CO/SP
                DATAD.C6_CORDEN = "";
                DATAD.C6_NVALTOT = 0;
                DATAD.C6_NMNIMPO = 0;
                DATAD.C6_NUSIMPO = 0;
                DATAD.C6_CSUBDIA = "";
                DATAD.C6_CCOMPRO = "";
                DATAD.C6_CCODMON = "";
                DATAD.C6_CTIPO = "";
                DATAD.C6_NTIPCAM = 0;
                DATAD.C6_NPREVTA = 0;
                DATAD.C6_CMONVTA = "";
                DATAD.C6_NUNXENV = 0;
                DATAD.C6_NNUMENV = 0;
                DATAD.C6_NDEVOL = 0;
                DATAD.C6_CCENCOS = $('#MainContent_txtCentroCosto').val();//CENTRO COSTO-REEMPLAZAR
                DATAD.C6_CSOLI = "";
                DATAD.C6_NPRECIO = 0;
                DATAD.C6_NPRECI1 = 0;
                DATAD.C6_NDESCTO = 0;
                DATAD.C6_NIGV = 0;
                DATAD.C6_NIGVPOR = 0;
                DATAD.C6_NIMPMN = 0;
                DATAD.C6_NIMPUS = 0;
                DATAD.C6_CDESCRI = NDES;//$('#MainContent_txtdescripcion').val();//REEMPLAZAR-DESCRIPCION PRODUCTO
                DATAD.C6_NPORDE1 = 0;
                DATAD.C6_NIMPO1 = 0;
                DATAD.C6_NPORDE2 = 0;
                DATAD.C6_NIMPO2 = 0;
                DATAD.C6_NPORDE3 = 0;
                DATAD.C6_NIMPO3 = 0;
                DATAD.C6_NPORDE4 = 0;
                DATAD.C6_NIMPO4 = 0;
                DATAD.C6_NPORDE5 = 0;
                DATAD.C6_NIMPO5 = 0;
                DATAD.C6_NPORDES = 0;
                DATAD.C6_CTIPITM = "";
                DATAD.C6_CNUMPAQ = "";
                DATAD.C6_CCODLIN = "";
                DATAD.C6_CNROTAB = "";
                DATAD.C6_CNDSCF = "";
                DATAD.C6_CNDSCL = "";
                DATAD.C6_CNDSCA = "";
                DATAD.C6_CNDSCB = "";
                DATAD.C6_CNFLAT = "";
                DATAD.C6_NPESO = 0;
                DATAD.C6_CTR = "";//REVISAR
                DATAD.C6_NPRSIGV = 0;
                DATAD.C6_CTIPANE = "";
                DATAD.C6_CCODANE = "";
                DATAD.C6_CSTOCK = "";
                DATAD.C6_CCODAGE = "";
                DATAD.C6_CCODAUX = "";
                DATAD.C6_CITEREQ = "";
                DATAD.C6_CNROREQ = "";
                DATAD.C6_NTEMPER = 0;
                DATAD.C6_NISCPOR = 0;
                DATAD.C6_NISC = 0;
                DATAD.C6_CITEFAC = "";
                DATAD.C6_NCANRPE = 0;
                DATAD.C6_CNUMREQ = "";
                DATAD.C6_CITERQ = "";
                DATAD.C6_CCODRQ = "";
                DATAD.C6_DFECRQ = null;
                DATAD.C6_CTIPPRO = "";
                DATAD.C6_NCANREQ = 0;
                DATAD.C6_CCTACMO = "";
                DATAD.C6_CNUMORD = "";
                DATAD.C6_CUMREF = "";
                DATAD.C6_NCANDEC = 0;
                DATAD.C6_NCANREF = 0;
                DATAD.C6_CITEMOC = "";
                DATAD.C6_CVANEXO = "";
                DATAD.C6_CVANEX2 = "";
                DATAD.C6_CCODAN2 = "";
                DATAD.C6_CCODEMPQ = "";

                $.ajax({
                    type: "POST",
                    url: "RegistroEntrada.aspx/guardarDetalleCabecera",
                    data: '{DATA:' + JSON.stringify(DATAD) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        actualizaStock(COD, CANT, (aIDMOV == "TD" ? 0 : 1), (aIDMOV == "TD" ? aAELE : aALREF));
                    },
                    error: function (response) {
                        console.table(response);
                    }
                });
            }
        });
    </script>

    <script type="text/javascript">
        function Mostrarundato(idprod) {
            var a_desc = "";
            var a_und = "";
            var a_clote = "";
            $.ajax({
                type: "POST",
                url: "RegistroSalida.aspx/GEtProductoInf",
                //data: '{CNUMDOC: ' + JSON.stringify(CNUMDOC) + '}',
                data: "{idprod: '" + idprod + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.d != null) {
                        a_desc = data.d.AR_CDESCRI;
                        a_und = data.d.AR_CUNIDAD;
                        a_clote = data.d.AR_CFLOTE;
                    } else {
                        a_desc = "";
                        a_und = "";
                    }
                },
                error: function (data) {
                    if (data.length != 0)
                        alert(data);
                }

            });
            return { a_desc, a_und, a_clote };
        }


        function InsertarStockxsoli(idcodix, cantix, loteix) {

            var ADATA = {};
            ADATA.SS_CCODIGO = idcodix.trim();
            ADATA.SS_ALMACEN = Operacion.mask('codAL').val();
            ADATA.SS_SOLICITAN = Operacion.mask('txtSolicitante').val();
            ADATA.SS_LOTES = loteix.trim();
            ADATA.SS_CANTID = cantix;
            //ADATA.SS_ESTADO = "A";
            //ADATA.SS_SOLICORIGEN = "";

            $.ajax({
                type: "POST",
                url: "RegistroSalida.aspx/ActualizaStockxSolicitan",
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

        function ActualizaSolitud(idsolicitu) {

            var ADATA = {};
            ADATA.SM_ID = idsolicitu.trim();
            ADATA.SM_ATENC = "2";
            $.ajax({
                type: "POST",
                url: "RegistroSalida.aspx/ActualizaestadoSolic",
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


        function ListarGridxVale(idvale) {

            $.ajax({
                type: "POST",
                url: "RegistroSalida.aspx/GetListaVale",
                data: "{numvale: '" + idvale + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.d.length > 0) {
                        var row = $("[id*=gvDetalleEntrada] tr:last-child").clone(true);
                        $("[id*=gvDetalleEntrada] tr").not($("[id*=gvDetalleEntrada] tr:first-child")).remove();
                        for (var i = 0; i < data.d.length; i++) {

                            $("td", row).eq(0).html(Number(i) + 1);
                            $("td", row).eq(1).html(data.d[i].DS_CCODIGO);
                            $("td", row).eq(2).html(Mostrarundato(data.d[i].DS_CCODIGO).a_desc);
                            $("td", row).eq(3).html(Mostrarundato(data.d[i].DS_CCODIGO).a_und);
                            $("td", row).eq(3).val(Mostrarundato(data.d[i].DS_CCODIGO).a_clote);
                            $("td", row).eq(4).html($("#MainContent_txtCentroCosto").val());
                            $("td", row).eq(5).html("");
                            $("td", row).eq(6).html("");
                            $("td", row).eq(7).html(Number(data.d[i].DS_CANTID).toFixed(4));
                            $(".btEliminar", row).hide();

                            if (Mostrarundato(data.d[i].DS_CCODIGO).a_clote == "N") {
                                $("td", row).eq(2).css("color", "black");

                            } else {
                                $("td", row).eq(2).css("color", "#FF5722");
                                Sumatotallote = Number(Sumatotallote) + Number(data.d[i].DS_CANTID);
                            }


                            $("[id*=gvDetalleEntrada]").append(row);
                            row = $("[id*=gvDetalleEntrada] tr:last-child").clone(true);
                        }

                    } else {
                        var row = $("[id*=gvDetalleEntrada] tr:last-child").clone(true);
                        $("[id*=gvDetalleEntrada] tr").not($("[id*=gvDetalleEntrada] tr:first-child")).remove();

                        $("td", row).eq(0).html("");
                        $("td", row).eq(1).html("");
                        $("td", row).eq(2).html("");
                        $("td", row).eq(3).html("");
                        $("td", row).eq(4).html("");
                        $("td", row).eq(5).html("");
                        $("td", row).eq(6).html("");
                        $("td", row).eq(7).html("");

                        $("[id*=gvDetalleEntrada]").append(row);
                        alert("no se encontro registro");
                    }
                },
                error: function (response) {
                    if (response.length != 0)
                        alert(response);
                }
            });

        }

    </script>


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
            <legend>Registro de Salida</legend>
            <table>
                <tr>
                    <td colspan="4" style="text-align: center;">
                        <asp:Label ID="lblAlmacen" class="titulo" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>Fecha Documento</td>
                    <td style="border: 1px solid black; text-align: center;">
                        <asp:Label ID="lblFechaE" runat="server" Text="FechaElegida"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Salida</td>
                    <td>
                        <asp:Label ID="lblSalida" runat="server" Text=""></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Codigo Movimiento</td>
                    <td>
                        <asp:TextBox ID="txtIDMOV" runat="server" TabIndex="0" Width="35px"></asp:TextBox>
                        <!--<asp:Label ID="lblCodigoM" runat="server" Text=""></asp:Label>-->

                        <asp:TextBox ID="txtCodigoMov" Width="280px" runat="server" class="tb1" required></asp:TextBox>
                    </td>
                    <td>Fecha Cambio</td>
                    <td>
                        <asp:Label ID="lblFechaCambio" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Numero de documento</td>
                    <td>
                        <asp:TextBox ID="txtNumeroDoc" runat="server" ReadOnly="true"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Moneda</td>
                    <td>
                        <asp:DropDownList ID="ddlMoneda" runat="server">
                            <asp:ListItem>ASDFA</asp:ListItem>
                            <asp:ListItem>ASDFA</asp:ListItem>
                            <asp:ListItem>ASDF</asp:ListItem>
                            <asp:ListItem>ASDFASD</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                    <td rowspan="2"></td>
                </tr>
                <tr>
                    <td>Tipo Conversion</td>
                    <td>
                        <asp:DropDownList ID="ddlTipoConversion" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Tipo Cambio</td>
                    <td>
                        <asp:TextBox ID="ddlTipoCambio" runat="server" value="0" ReadOnly="true"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>

        </fieldset>
        <fieldset>
            <legend>Detalle</legend>
            <table style="width: 95%;">
                <tr>
                    <td>
                        <asp:Label ID="lblPROV" runat="server" Text="Proveedor"></asp:Label></td>
                    <td colspan="3">
                        <asp:Label ID="lblProveedor" runat="server" Text=""></asp:Label>
                        <asp:TextBox ID="txtProveedor" class="tb4" Width="394px" TabIndex="2" runat="server" required="required"></asp:TextBox>
                        <asp:CheckBox ID="cb1" Text="Exterior" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblTDR1" runat="server" Text="Tipo Documento Referencia 1"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtIDREF" runat="server" Width="38px"></asp:TextBox>
                        <!--<asp:Label ID="lblTDRef1" runat="server" Text=""></asp:Label>-->
                        <asp:TextBox ID="txtTipoDocumentoRef1" class="tb2" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblND1" runat="server" Text="Nro Documento 1"></asp:Label></td>
                    <td>
                        <%--<asp:TextBox ID="txtNroDocumento1" runat="server" TabIndex="3" onkeypress="Operacion.MEKPAT(event,this)"></asp:TextBox>--%>
                        <asp:TextBox ID="txtNroDocumento1" runat="server" TabIndex="3"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblTDR2" runat="server" Text="Tipo Documento Referencia 2"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtTDRef2" TabIndex="4" runat="server" Width="38px"></asp:TextBox>
                        <!--<asp:Label ID="lblTDRef2" runat="server" Text=""></asp:Label>-->
                        <asp:TextBox ID="txtTipoDocumentoRef2" runat="server" class="tb21"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblND2" runat="server" Text=""></asp:Label><br />
                        <asp:Label ID="lblND3" runat="server" Text="Nro Documento 2"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtNroDocumento2" runat="server" TabIndex="5" onkeypress="Operacion.MEKPAT(event,this)"></asp:TextBox>
                        <asp:DropDownList ID="ddlDepa" runat="server"></asp:DropDownList>
                        <br />
                        <asp:DropDownList ID="ddlOrigen" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblOC" runat="server" Text="Orden de Compra"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtOrdenCompra" TabIndex="6" runat="server" Width="46px" onkeypress="Operacion.MEKPAT(event,this)"></asp:TextBox>
                        <asp:TextBox ID="txtOrdenCompraD" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblOT" runat="server" Text="Orden de Trabajo"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtOrdenTrabajo" TabIndex="7" runat="server" onkeypress="Operacion.MEKPAT(event,this)"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSOL" runat="server" Text="Solicitante"></asp:Label></td>
                    <td colspan="3">
                        <asp:TextBox ID="txtSolicitante" TabIndex="8" runat="server" Width="47px"></asp:TextBox>
                        <asp:Label ID="lblSolicitante" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCENCO" runat="server" Text="Centro de Costo"></asp:Label></td>
                    <td colspan="3">
                        <asp:TextBox ID="txtCentroCosto" TabIndex="9" Width="84px" runat="server"></asp:TextBox>
                        <asp:TextBox ID="txtDetalleCC" runat="server" Width="345px"></asp:TextBox>
                        <!--<asp:Label ID="lblDetalleCC" runat="server" Text="" class="tb3"></asp:Label>-->
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblG1" runat="server" Text="Glosa 1"></asp:Label></td>
                    <td colspan="2">
                        <asp:TextBox ID="txtGlosa1" TabIndex="10" class="ace" runat="server" Width="291px" onkeypress="Operacion.MEKPAT(event,this)"></asp:TextBox>
                        <asp:HiddenField ID="hfG1" runat="server" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblG2" runat="server" Text="Glosa 2"></asp:Label></td>
                    <td colspan="2">
                        <asp:TextBox ID="txtGlosa2" runat="server" Width="291px" TabIndex="11" onkeypress="Operacion.MEKPAT(event,this)"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblG3" runat="server" Text="Glosa 3"></asp:Label></td>
                    <td colspan="2">
                        <asp:TextBox ID="txtGlosa3" TabIndex="12" MaxLength="28" runat="server" Width="291px" onkeypress="Operacion.MEKPAT(event,this)"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblAR" runat="server" Text="Almacen de Referencia"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddlAlmacenRef" TabIndex="13" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCL" runat="server" Text="Cliente"></asp:Label></td>
                    <td colspan="2">
                        <asp:TextBox ID="txtIDCL" Width="110px" runat="server"></asp:TextBox>
                        <asp:TextBox ID="txtCliente" TabIndex="14" class="tb41" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCA" runat="server" Text="Tipo/Codigo Anexo"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddlAnexo" runat="server">
                        </asp:DropDownList>
                        <asp:TextBox ID="txtAnexoDetalle" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;<input id="btnGuardar" class="btn" tabindex="25" type="button" value="Guardar" /></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </fieldset>
        <div id="detalleCabecera" title="Detalle de Entrada" style="display: compact;">
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">Entrada</td>
                    <td>
                        <asp:Label ID="lbltipoRegistro" runat="server" Text=""></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">Codigo Movimiento</td>
                    <td>
                        <asp:Label ID="lblcodigoMovimiento" runat="server" Text=""></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">Nro Documento</td>
                    <td>
                        <asp:Label ID="lblNroDocumento" runat="server" Text=""></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">Fecha Documento</td>
                    <td>
                        <asp:Label ID="lblFechaDocD" runat="server" Text=""></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td colspan="3">Filtrar por :&nbsp;
                        <input id="rb1" type="radio" name="rb" value="C" />Codigo
                        <input id="rb2" type="radio" name="rb" value="D" checked="checked" />
                        Descripción
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Producto&nbsp;</td>
                    <td colspan="3">
                        <!--<asp:TextBox ID="txtidProducto" class="tb5" placeholder="CODIGO" runat="server"></asp:TextBox>-->
                        <asp:TextBox ID="txtdescripcion" class="tb6" placeholder="DESCRIPCION" TabIndex="26" runat="server" Width="452px"></asp:TextBox>
                        <asp:HiddenField ID="hfidproducto" runat="server" />
                        <asp:HiddenField ID="hfdescripcion" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Unidad</td>
                    <td>

                        <asp:Label ID="lblUnidad" runat="server" Text=""></asp:Label>
                        <asp:HiddenField ID="hdfUnidad" runat="server" />
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">Serie</td>
                    <td>
                        <asp:TextBox ID="txtSerie" placeholder="-" runat="server"></asp:TextBox>
                        <asp:HiddenField ID="hfSERIE" runat="server" Value="0" />
                        <!--<asp:Label ID="lblSL" runat="server" Text="Stock Lote:"></asp:Label>-->
                        <!--<asp:Label ID="lblSCantidad" runat="server" Text=""></asp:Label>-->
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">Fecha Lote</td>
                    <td>
                        <asp:TextBox ID="txtFechaL" placeholder="00/00/0000" runat="server" class="dpFecha2"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">Cantidad</td>
                    <td>
                        <asp:TextBox ID="txtCantidad" TabIndex="27" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;Stock Actual:<asp:Label ID="lblSTOCK" runat="server" Text=""></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <%--                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td></td>
                    <td>
                       <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
                    </td>
                </tr>--%>
                <tr>
                    <td colspan="2">
                        <!--<asp:Button ID="btnagregarItem" runat="server" Text="Agregar"/>-->
                        <input id="btnagregarItem" tabindex="28" class="btn" type="button" value="Agregar" />
                        <input id="btnActualizar" class="btn" type="button" value="Modificar" /></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="__" BackColor="#FF5722" ID="lbinf01" ForeColor="#FF5722" runat="server" />
                        <asp:Label Text="Productos con Lote" ID="lbinf02" runat="server" /></td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="gvDetalleEntrada" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="ITEM" HeaderText="ITEM" ItemStyle-HorizontalAlign="center">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="50" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>

                                <asp:BoundField DataField="C6_CCODIGO" HeaderText="Codigo" ItemStyle-HorizontalAlign="center">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="C6_CDESCRI" HeaderText="Descripcion" ItemStyle-HorizontalAlign="left">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="left" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AR_CUNIDAD" HeaderText="Unidad" ItemStyle-HorizontalAlign="center">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="50" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="C6_CCENCOS" HeaderText="Centro de Costo" ItemStyle-HorizontalAlign="center">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="C6_CSERIE" HeaderText="Serie" ItemStyle-HorizontalAlign="right">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="C6_CFECDOC" HeaderText="Fecha" ItemStyle-HorizontalAlign="right">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="C6_CNCANTIDAD" HeaderText="Cantidad" ItemStyle-HorizontalAlign="right" DataFormatString="&quot;{0:d}&quot;">
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
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <div class="btEliminar" style="text-align: center">
                                            <img alt="" src="../Images/Trash.png" width="25" style="cursor: pointer" />
                                            <%--<asp:ImageButton ID="imbeliminar" runat="server" ImageUrl="~/Images/Message_Error.png" Width="25px" OnClick="ib_eliminar_Click" onclientclick="javascript:return confirm('Esta Seguro?')"/>--%>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--                                                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <div class="btlote" style="text-align: center">
                                            <img alt="" src="../Images/EDIT.png" width="25" style="cursor: pointer" />
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
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
                    <td>
                        <asp:Label Text="Detalle Productos / Lotes" runat="server" ID="lbinf03" />
                    </td>
                    <td></td>
                    <td></td>
                    <td>
                        <!--<asp:Button ID="btnFinalizar" runat="server" Text="Finalizar"/>-->
                        <input id="btnFinalizar" class="btn" type="button" value="Finalizar" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="gvlotexvale" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" Width="763px">
                            <Columns>
                                <asp:BoundField DataField="ITEM" HeaderText="ITEM" ItemStyle-HorizontalAlign="center">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="50" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>

                                <asp:BoundField DataField="C6_CCODIGO" HeaderText="Codigo" ItemStyle-HorizontalAlign="center">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="C6_CDESCRI" HeaderText="Descripcion" ItemStyle-HorizontalAlign="left">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="left" Width="150" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AR_CUNIDAD" HeaderText="Unidad" ItemStyle-HorizontalAlign="center">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="50" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="C6_CCENCOS" HeaderText="Centro de Costo" ItemStyle-HorizontalAlign="center">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="C6_CSERIE" HeaderText="Serie" ItemStyle-HorizontalAlign="right">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="C6_CFECDOC" HeaderText="Fecha" ItemStyle-HorizontalAlign="right">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="C6_CNCANTIDAD" HeaderText="Cantidad" ItemStyle-HorizontalAlign="right" DataFormatString="&quot;{0:d}&quot;">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>

                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <div class="btEliminar02" style="text-align: center">
                                            <img alt="" src="../Images/Trash.png" width="25" style="cursor: pointer" />
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
            </table>
        </div>
        <div id="serie" title="Series Disponibles" style="display: compact;">

            <asp:GridView ID="gvSerie" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False">

                <Columns>
                    <asp:BoundField DataField="SR_CSERIE" HeaderText="Serie o Lote" ItemStyle-HorizontalAlign="center">
                        <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                        <ItemStyle Font-Size="8pt" />
                    </asp:BoundField>
                    <asp:BoundField DataField="SR_NKDIS" HeaderText="Stock Disponible" ItemStyle-HorizontalAlign="center">
                        <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                        <ItemStyle Font-Size="8pt" />
                    </asp:BoundField>
                    <asp:BoundField DataField="SR_DFECVEN" HeaderText="Fecha Vencimiento" ItemStyle-HorizontalAlign="center">
                        <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                        <ItemStyle Font-Size="8pt" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="">

                        <ItemTemplate>
                            <div class="btEleccion" style="text-align: center">
                                <img alt="" src="../Images/unchecked.png" width="20" style="cursor: pointer" />
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Cantidad">
                        <ItemTemplate>
                            <input type="text" runat="server" style="width: 100px" class="clstxtdcan btn02" onkeypress="$(this).numeric('.');" />
                            <%--<asp:TextBox runat="server" ID="txtdcan" class="clstxtdcan" Width="100"></asp:TextBox>--%>
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

            <table>
                <tr>
                    <td>
                        <asp:Button Text="Agregar" class="clsgrab btn" runat="server" />
                    </td>
                </tr>
            </table>


        </div>
    </div>
    <br />
</asp:Content>