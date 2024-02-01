<%@ Page Title="Listado" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CancelaDR.aspx.cs" Inherits="CancelaDR" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../../../jquery/jquery.tablesorter.js"></script>
    <link type="text/css" href="../../../Images/styles.css" rel="stylesheet" />
    <link type="text/css" href="../../../CSS/base.css?1.9" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {
            MASIENTO = []/*CONTENIDO DE COMPROBANTE DETALLE*/, DCUENTAS = []/*INICIALIZA CUENTAS*/, A_DCUENTAS = []/*AUXILIAR CUENTAS*/, PAUX = []/*PARAMETROS AUXILIARES ASIENTO*/;
            var dialog, CODATA = {}, myRow, VA = []/*PARAMETROS AUXILIARES*/, CTOK = []/*VALIDA SI ERRORES*/, RDCTA = []/*PERMISO CUENTA*/;
            var EX = ['txtNCU', 'txtFCOM', 'ddlArea', 'ddlTIPA', 'ddlSUB', 'txtCITB'];
            UHTML.id = 'MainContent';
            var miconsulta = 'BancosxCta';
            //CONFIGURACIONES
            $(".dp_1").datepicker();//Aplica jquery fechas
            $(".dp_2").datepicker();//Aplica jquery fechas
            var i_fecha = moment().format('DD/MM/YYYY');
            Operacion.mask('txtFCOM').val(i_fecha);//Fecha por defecto del dia
            Operacion.iValida('txtTICA', 1);//Solo numeros tipo cambio
            $('#mis_pagos').hide();
            $('.pie_dctos').hide();
            $('.cont_sel').hide();
            $('#forpag').hide();
            Operacion.inputEstado('btnDoc', 1, true);
            Operacion.inputEstado('btnMad', 1, true);
            Operacion.inputEstado('btnFpa', 1, true);
            Operacion.inputEstado('btnConfirma', 1, true);
            Operacion.mask('txtNCU').focus();
            var dialog = $("#dvcandoc").dialog({
                autoOpen: false,
                height: 'auto',
                width: 'auto',
                modal: true,
                buttons: {
                    /*"Continuar": function () {
                        guardarVB();
                    },*/
                    "Cancelar": function () {
                        dialog.dialog("close");
                        Operacion.inputEstado('btnDoc', 1, true);
                        $('#mis_pagos').hide();
                        $('.pie_dctos').hide();

                    }
                },
                close: function () {
                    //dialog.dialog("close");
                    Operacion.inputEstado('btnDoc', 1, true);
                    $('#mis_pagos').hide();
                    $('.pie_dctos').hide();
                }
            });
            var dialog1 = $("#dvforpag").dialog({
                autoOpen: false,
                height: 'auto',
                width: 'auto',
                modal: true,
                buttons: {
                    "Grabar": function () {

                    },
                    "Salir": function () {
                        dialog1.close();
                    }
                }, close: function () {

                }
            });
            //FILTROS-------------------------------------------------------------------------------------
            var filtro1 = function () {
                var dd = 0;
                //Agregar el comportamiento al texto (se selecciona por el ID) 
                $("#MainContent_txtidpro").keyup(function () {
                    var upp = $(this).val().toUpperCase();
                    var s = upp.split(" ");
                    $(".tablesorter tr").show();
                    $.each(s, function () {
                        $(".tablesorter tr:visible .codigo:not(:contains('" + this + "'))").parent().hide();// && $(".filtrar tr:visible .producto:not(:contains('" + $('#MainContent_txtfiltra').val().toUpperCase() + "'))").parent().hide();
                    });
                });
            }
            var filtro2 = function () {
                var dd = 0;
                //Agregar el comportamiento al texto (se selecciona por el ID) 
                $("#MainContent_txtprove").keyup(function () {
                    var upp = $(this).val().toUpperCase();
                    var s = upp.split(" ");
                    $(".tablesorter tr").show();
                    $.each(s, function () {
                        $(".tablesorter tr:visible .descripcion:not(:contains('" + this + "'))").parent().hide();// && $(".filtrar tr:visible .producto:not(:contains('" + $('#MainContent_txtfiltra').val().toUpperCase() + "'))").parent().hide();
                    });
                });
            }
            filtro1(); filtro2();
            //--------------------------------------------------------------------------------------------------------------------
            //REGISTRO FINAL
            var dialog2 = $("#DCO").dialog({
                autoOpen: false,
                height: 'auto',
                width: '860px',
                modal: true,
                buttons: {
                    "Finalizar": function () {
                        var M_DHC = Operacion.mask('txtDC_DI').val();//MI DEBE HABE CONTROL
                        var MI_SW = (Number(M_DHC) == 0 ? 0 : (Number(M_DHC) > 0 && Number(M_DHC) <= 0.10 ? 1 : (Number(M_DHC) == -0.01 ? 1 : 3)));
                        if (jQuery.inArray(false, CTOK) == -1) {
                            switch (Number(MI_SW)) {
                                case 0:
                                    asientoCAB();/*asientoDET();carteraCHE();registraPAG();actualizaCart();*/
                                    break;
                                case 1:
                                    if (confirm('Existe diferencia de ' + M_DHC + ' en el comprobante, desea considerarlo')) {

                                    }
                                    break;
                                default:
                                    alert('El comprobante tiene diferencia:\n Verificar:\n(1)Cuenta existencia \n(2)Cuenta Compra \n(3)Configuracion de D/H');
                                    break;
                            }
                        } else {
                            alert('El registro tienes inconsistencias, verificar operaciones');
                        }
                    },
                    "Cancelar": function () {
                        //dialog3.dialog("close");
                    }
                },
                close: function () {

                }
            });
            var iniciaDialogo = function () {
                dialog.find(':input').each(function () {
                    var elemento = this;
                    if (elemento.type == "text" || elemento.type == "select-one") {
                        var milabel = elemento.id;
                        var label = milabel.split("_");
                        (jQuery.inArray(label[1], EX) !== -1 ? Operacion.inputEstado(label[1], 0, true) : Operacion.inputEstado(label[1], 1, true));
                    }
                });
            }
            var limpiar = function (ex) {
                dialog.find(':input').each(function () {
                    var elemento = this;
                    if (elemento.type == "text") {
                        var milabel = elemento.id;
                        var label = milabel.split("_");
                        //ENCONTRO
                        if (jQuery.inArray(label[1], ex) !== -1) {

                        } else {
                            Operacion.mask(label[1]).val('');
                        }

                    } else if (elemento.type == "select-one") {
                        //var milabel = elemento.id;
                        //var label = milabel.split("_");
                        //Operacion.mask(label[1]).empty();
                    }
                });
                $('.tr_oculta1').hide();
            }
            //PROCESO INICIA - ARREGLO COMPROBANTE
            var CF6D = function (VALOR, OP) {
                //console.log(VALOR);
                if (OP == "1") {
                    var fecha = VALOR.split('/');
                    var NFECHA = fecha[2].substr(2, 2) + "" + fecha[1] + "" + fecha[0];
                    return NFECHA;
                } else if (OP == "3") {
                    var fecha = VALOR.split('/');
                    var NFECHA = fecha[2].substr(2, 2);
                    return NFECHA;
                } else if (OP == "4") {
                    //FECHA 20160816
                    var fecha = VALOR.split('/');
                    var NFECHA = fecha[2] + "" + fecha[1] + "" + fecha[0];
                    return NFECHA;
                } else if (OP == "5") {
                    var fecha = VALOR.split('/');
                    var NFECHA = fecha[2] + "" + fecha[1];
                    return NFECHA;
                } else {
                    return moment(VALOR, 'DD/MM/YYYY');
                }
            }
            $(".ac_nrocta").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "ContabilizaDOS.aspx/listactas",
                        data: "{ texto: '" + request.term + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    value: item.PDESCRI,
                                    id: item.PCUENTA.trim()
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
                    $('#MainContent_lblMCTA').text(str);
                    //iniciaval(str, "1");
                },
                change: function (event, ui) {
                    var str = ui.item;
                    if (str == null || str == undefined || str == "") {
                        $("#MainContent_lblMCTA").val("");
                        //iniciaval(str, "2");
                        $(".clcuenta").focus();
                        alert("No ha seleccionado El item");
                    } else {
                        // $(".clprove").focus();
                    }
                }
            });
            //AC:BANCOS
            $(".ac_bancos").autocomplete(
               {
                   source: function (request, response) {
                       var DATA = { CT_CDESCTA: "%" + request.term + "%" };
                       $.ajax({
                           url: "CancelaDR.aspx/" + miconsulta,
                           data: '{DATA:' + JSON.stringify(DATA) + '}',
                           dataType: "json",
                           type: "POST",
                           contentType: "application/json; charset=utf-8",
                           dataFilter: function (data) { return data; },
                           success: function (data) {
                               response($.map(data.d, function (item) {
                                   return {
                                       value: item.CT_CNUMCTA.trim() + " " + item.CT_CDESCTA.trim(),
                                       ds: item.CT_CDESCTA, ct: item.CT_CCUENTA.trim(),
                                       mn: item.CT_CCODMON, nc: item.CT_CNUMCTA, dc: item.CT_CDESCOR
                                   }
                               }))
                           },
                           error: function (XMLHttpRequest, textStatus, errorThrown) {
                               //  alert(textStatus);
                           }
                       });
                   },
                   minLength: 4,
                   select: function (event, ui) {
                       var str = ui.item.id; var str1 = ui.item.ct, str2 = ui.item.mn, str3 = ui.item.nc; str4 = ui.item.dc;
                       verificaBAPR(str4.trim(), str2.trim());

                       Operacion.mask('hfIDB').val(str1);//CUENTA CONTABLE BANCOS
                       Operacion.mask('hfBAN').val(str4);//BANCO BCP-.--
                       Operacion.mask('lblMON').text(str2);
                       Operacion.mask('hfIDC').val(str3.trim());
                       Operacion.mask('txtFCOM').focus();
                   },
                   change: function (event, ui) {
                       if (ui.item == null || ui.item == undefined) {
                           Operacion.mask('txtNCU').val('');
                           alert("No ha seleccionado el banco correcto");
                       }
                   }
               });
            //MI TABLA INICIA
            var dibujaTabla = function (NAME, ROW, ID, DATA, CSUM, ATTR) {
                var table = $('<table id=' + NAME + ' cellspacing="0" cellpadding=3 rules=all style=background-color:White;border-color:#CCCCCC;border-width:1px;border-style:None;width:113%;border-collapse:collapse;width:820></table>');
                var CAB = [];
                var gridView = document.getElementById(NAME);
                var LEN = gridView.rows[0].cells.length;//CABECERA INICIAL 
                for (var z = 0; z < LEN; z++) {
                    cellPivot00 = gridView.rows[0].cells[z];
                    CAB[z] = cellPivot00.innerHTML;
                }
                $('#' + ID).empty();
                var a_table = $('<tr style=color:White;background-color:#006699;font-weight:bold;></tr>');
                for (var j = 0; j < CAB.length; j++) {
                    var sa = ";width:12%;text-align:center", sa1 = ";width:5%", sa2 = ";width:12%", sa3 = ";width:9%";
                    a_table.append($('<th scope="col" style=' + (ATTR[j] != "" ? 'display:none' : "") + '' + (j == 2 ? sa : (j == 1 ? sa1 : (j == 8 ? sa2 : (j == 9 ? sa3 : "")))) + ' >' + CAB[j] + '</th>'))
                    //text-align:center
                }
                table = table.append(a_table);
                if (typeof DATA == 'object') {
                    var LEN = ($.isArray(ROW) ? ROW.length : ROW);
                    for (k = 0; k < LEN; k++) {
                        var a_table1 = ($('<tr style=color:#000066;></tr>'));
                        for (var j = 0; j < CAB.length; j++) {
                            a_table1.append($('<td ' + (typeof DATA[ROW[k]][j] == "number" ? 'style=text-align:right' + (ATTR[j] != "" ? ';display:none' : "") : (j == 2 ? 'style=text-align:left' + (ATTR[j] != "" ? ';display:none' : "") : 'style=text-align:center' + (ATTR[j] != "" ? ';display:none' : ""))) + ' >' + (typeof DATA[ROW[k]][j] == "number" ? Number(DATA[ROW[k]][j]).toFixed(2) : DATA[ROW[k]][j]) + '</td>'))
                            table = table.append(a_table1);
                        }
                    }
                } else {
                    for (k = 0; k < ROW.length; k++) {
                        var a_table1 = ($('<tr style=color:#000066;></tr>'));
                        for (var j = 0; j < CAB.length; j++) {
                            a_table1.append($('<td>&nbsp;</td>'));
                            table = table.append(a_table1);
                        }
                    }
                }
                $('#' + ID).append(table);
            }

            //VALIDA CAMPOS
            var valida = function () {
                return Operacion.iVALC(['txtNCU', 'txtFCOM', 'txtTICA-',
                                    'ddlArea', 'ddlTIPA', 'ddlSUB']);
            }
            //TIPO CAMBIO
            var iniciaTC = function (CODATA, OP) {
                $.ajax({
                    type: "POST",
                    url: "CancelaDR.aspx/tipoCambio",
                    data: '{CODATA:' + JSON.stringify(CODATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        if (data.d != null) {
                            Operacion.mask('txtTICA').val((OP == "M" ? data.d['XMEIMP'] : data.d['XMEIMP2']));
                            VA['VTIC'] = Operacion.mask('txtTICA').val();//VALOR TIPO CAMBIO
                            VA['CTIC'] = OP;
                        } else {
                            alert('No existe tipo cambio para la fecha, coordinar con contabilidad');
                            Operacion.mask('txtTICA').val('');
                        }
                    },
                    error: function (response) {
                        console.log(response);
                    }
                });
            }
            //BLOQUEO FECHA CONTABLE
            var bloqueoFE = function (FC) {
                var NFC = FC.split("/");
                NFC = NFC[1];

                var DATA = {
                    TMES: NFC,
                    TTIPCONS: "D"
                };
                $.ajax({
                    url: "../../../ALMACEN/LiquidacionCompra.aspx/listarBC",
                    data: '{DATA:' + JSON.stringify(DATA) + '}',
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        if (data.d != null) {
                            if (data.d.TTIPCONS == "D") {
                                alert('Mes de comprobante cerrado');
                                Operacion.mask('txtFCOM').val('');
                                Operacion.mask('txtFCOM').focus();
                            } else {
                                /*CODATA.XFECCAM2 = moment(Operacion.mask('txtFCOM').val(), 'DD-MM-YYYY');
                                var TC = $('input:radio[name=rb_1]:checked').val();
                                iniciaTC(CODATA, TC);*/
                            }
                        } else {
                            CODATA.XFECCAM2 = moment(Operacion.mask('txtFCOM').val(), 'DD-MM-YYYY');
                            var TC = $('input:radio[name=rb_1]:checked').val();
                            if (TC == "C") {
                                Operacion.inputEstado('txtTICA', 0, true);
                                Operacion.iValida('txtTICA', 1);
                                Operacion.mask('txtTICA').focus();
                            } else {
                                Operacion.inputEstado('txtTICA', 1, true);
                                iniciaTC(CODATA, TC);
                            }
                        }
                    },
                    error: function (data) {
                        console.log(data);
                    }
                });
            }
            var verificaBAPR = function (BTEXTO,MONEDA) {
                /*var flag=true;
                if (BTEXTO == "CREDITO") {

                }
                return flag;*/
            }
            //VERIFICA PAGOS PROVEEDOR
            var verificaPAPR = function (ANE, RUC) {
                ROWS = [], MI_DETALLE = [];
                var DATA = { CP_CVANEXO: ANE, CP_CCODIGO: RUC };
                var result = Operacion.oAjax("CancelaDR.aspx/pagos_proveedor", DATA, null);
                var LEN1 = result.d.length;
                var ANIO = moment().format('YYYY');
                try {
                    if (typeof result == 'object') {
                        for (var z = 0; z < LEN1; z++) {
                            var descri = result.d[z].PORDET.split(" ");
                            auxiliar = $.grep(descri, function (n) {
                                return (n);
                            });
                            ROWS.push(z); var MIREF = result.d[z].CP_CSUBDIA + "-" + result.d[z].CP_CCOMPRO, COMDET = result.d[z].CP_CCUENTA.trim(), TD = result.d[z].CP_CTIPDOC, DOC = result.d[z].CP_DFECDOC;// console.log(ANIO); console.log(moment(DOC).format('YYYY'));
                            MI_DETALLE[z] = [(COMDET != 421205 && TD != "PA" && moment(DOC).format('YYYY') >= ANIO ? "<input type=checkbox name=opt_" + z + " id=opt" + z + " class=validaunoporuno>" : "<input type=checkbox disabled=disabled name=opt_" + z + " id=opt" + z + " class=validaunoporuno>"), TD, result.d[z].CP_CNUMDOC, moment(DOC).format('DD/MM/YYYY'),
                                            moment(result.d[z].CP_DFECVEN).format('DD/MM/YYYY'), result.d[z].CP_CCODMON, result.d[z].IMPORTE,
                                            result.d[z].SALDO, 0.00, result.d[z].CP_CRETE, result.d[z].CP_NPORRE, (result.d[z].PORDET != "" ? auxiliar[auxiliar.length - 1] : ""), COMDET, MIREF, (result.d[z].CP_NTIPCAM).toFixed(4),
                                            (COMDET != 421205 ? "<div class=open_row><img alt='' src='../../../Images/open_row.png' width='21' style='cursor:pointer' /></div>" : "")];
                        }
                        var MVISIBLE = ["", "", "", "", "", "", "", "", "", "", "", "", 1, 1, 1, ""];
                        dibujaTabla("<%=gvDCTOS.ClientID %>", ROWS, "mis_pagos", MI_DETALLE, true, MVISIBLE);
                    }
                } catch (ex) {
                    alert(ex.message);
                }
            }
            var verificaACR = function (RUC, TA) {
                var DATA = {};
                DATA.AC_CVANEXO = TA;//Operacion.mask('ddlACR').val();
                DATA.AC_CCODIGO = '%' + RUC + '%';
                DATA.AV_CDOCIDE = 6;
                //DATA.AC_CTIPOAC = PAR['CE_CTIPACR'];
                $.ajax({
                    url: "../../../ALMACEN/LiquidacionCompra.aspx/listaMaestroID",
                    data: '{DATA:' + JSON.stringify(DATA) + '}',
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    async: false,
                    success: function (data) {
                        var MONEDAS = Operacion.mask('lblMON').text();
                        if (data.d.length > 0) {
                            $.each(data.d, function (i, v) {
                                VA['P-COD'] = v.AC_CRETE;
                                VA['P-POR'] = v.AC_NPORRE;
                                VA['P-BCP'] = (MONEDAS = "MN" ? v.AC_CCTAMNT : v.AC_CCTAUST);
                                //VA['P-BCPUS'] = v.AC_CCTAUST;
                                VA['P-BBVA'] = (MONEDAS = "MN" ? v.AC_CCTAMN7 : v.AC_CCTAUS7);
                                //VA['P-BBVAUS'] = v.AC_CCTAUS7;
                                VA['P-INTE'] = (MONEDAS = "MN" ? v.AC_CCTAMNK : v.AC_CCTAUSK);
                                //VA['P-INTEUS'] = v.AC_CCTAUSK;
                            });
                        } else {
                            alert('Verificar proveedor:\n(1)Que Exista\n(2)Que tenga un tipo documento asignado');
                            CTOK.push(false);
                        }
                    },
                    error: function (data) {
                        console.log(data);
                    }
                });
            }
            //INICIA SUBTOTAL DE PAGOS SELECCIONADOS
            var iniciaSP = function () {
                var gridView1 = document.getElementById("<%=gvDCTOS.ClientID %>");
                LEN = gridView1.rows.length; CONT = 0;
                var AMN = 0, AUS = 0, USA = 0, MNA = 0;
                for (var t = 1; t < LEN; t++) {
                    var cellPivot = gridView1.rows[t].cells[0].getElementsByTagName("input")[0].checked;
                    if (cellPivot == true) {
                        CONT++;
                        var cellPivot1 = gridView1.rows[t].cells[5]; MONEDA = cellPivot1.innerHTML;
                        var cellPivot2 = gridView1.rows[t].cells[8]; SALDO = cellPivot2.innerHTML;
                        if (MONEDA == "MN") {
                            AMN = AMN + Number(SALDO);
                            USA = USA + parseFloat((SALDO / VA['TC']).toFixed(2));
                        } else {
                            AUS = AUS + Number(SALDO);
                            MNA = MNA + parseFloat((SALDO * VA['TC']).toFixed(2));
                        }
                    }
                }
                var M_FMN = AMN + MNA;//(AUS * VA['TC']);//SUMA SU EQUIVALENTE SEGUN MONEDA SOLES
                var M_FUS = AUS + USA;//O:(AMN / VA['TC']); SUMA SU EQUIVALENTE SEGUN MONEDA DOLARES
                Operacion.mask('txtNDOC').val(CONT);
                Operacion.mask('txtPMN').val(Operacion.mround(M_FMN, 2).toFixed(2));
                Operacion.mask('txtPUS').val(Operacion.mround(M_FUS, 2).toFixed(2));
                if (Number(M_FMN) > 0) {
                    Operacion.inputEstado('btnFinalizar', 0, true);
                } else {
                    $('.cont_sel').hide();//
                    Operacion.inputEstado('btnFinalizar', 1, true);
                    monto_seleccionado();
                }
            }
            //OBTIENE DATOS CUENTA X
            var MDCTA = function (CTA) {
                var PDATA = {};
                PDATA.PCUENTA = CTA;
                $.ajax({
                    type: "POST",
                    url: "CancelaDR.aspx/ListaPlanC",
                    data: '{PDATA:' + JSON.stringify(PDATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        $.each(data.d, function (i, v) {
                            RDCTA[CTA] = [
                                v.PVCONBAN, v.PVANEXO, v.PVCENCOS,
                                v.PVDOCREF, v.PVFECVEN, v.PVANEXO2,
                                v.PVAREA, v.PVDOCRE2, v.PTASA,
                                "", v.PCTACAR.trim(), v.PCTAABO.trim(), v.PDESCRI
                            ];
                        });
                    },
                    error: function (response) {
                        alert('El proceso no se pudo completar RDCTA');
                        console.log(response);
                    }
                });
            }
            //ASIGNA DEBE/HABER
            var verificaDH = function (SUB, CTA) {
                var CTA1 = CTA.substring(0, 2);
                var DATA = {
                    AF_COD: SUB,
                    AF_CCLAVE: "FI" + CTA1 + "" + SUB,
                    AF_TDESCRI1: CTA1
                }
                var result = Operacion.oAjax("CancelaDR.aspx/ListarParametroID", DATA, null);
                try {
                    if (typeof result == 'object') {
                        RDCTA[CTA][9] = result.d.AF_TDESCRI2;
                        RDCTA[CTA][10] = result.d.AF_TDESCRI3;//CODARC
                    } else {
                        alert('Verificar metodo verificaDH');
                    }
                } catch (ex) {
                    alert(ex.message);
                }
            }
            //PARAMETROS ASIENTO RETENCIONES
            var paraAsientoRet = function (CO) {
                var DATA = {};
                DATA.AF_COD = CO;
                var result = Operacion.oAjax("CancelaDR.aspx/getPARAM", DATA, null);
                try {
                    if (typeof result == 'object') {
                        jQuery.each(result.d, function (i, v) {
                            PAUX.push(v.AF_TDESCRI1.trim());
                        });
                    } else {
                        alert('Verificar metodo paraAsientoRet');
                    }
                } catch (ex) {
                    alert(ex.message);
                }
            }
            //[TC]:TIPO CAMBIO
            var compDetalle = function (SUB, COR, TD, DH, TC) {
                var DATA = { DSUBDIA: SUB, DCOMPRO: COR, DTIPDOC: TD, DDH: DH };
                var result = Operacion.oAjax("CancelaDR.aspx/c_detalle", DATA, null);
                try {
                    if (typeof result == 'object') {
                        jQuery.each(result.d, function (i, v) {
                            var SEC = DCUENTAS.length;
                            DCUENTAS.push(v.DCUENTA.trim() + "-" + (SEC == 1 ? SEC + 1 : SEC + 1));//CUENTA ORIGEN 25
                            DCUENTAS.push(PAUX[0] + "-" + (SEC == 1 ? SEC + 2 : SEC + 2));

                            MASIENTO[v.DCUENTA.trim() + "-" + (SEC == 1 ? SEC + 1 : SEC + 1)] = [Operacion.cadenaMascara((SEC == 1 ? SEC + 1 : SEC + 1), 4), v.DCUENTA, "", v.DCODANE, "", "", (v.DCODMON == "MN" ? v.DMNIMPOR : v.DUSIMPOR), v.DTIPDOC, v.DNUMDOC, moment(v.DFECDOC2).format('DD/MM/YYYY'), moment(v.DFECVEN2).format('DD/MM/YYYY'), VA['SUB'], CF6D(VA['FCOM'], 1), "",
                               v.DCODMON, "", "", "", v.DMNIMPOR, v.DUSIMPOR, "CODARC", CF6D(VA['FCOM'], 2), v.DFECDOC2, v.DXGLOSA, v.DCANTID];

                            MASIENTO[PAUX[0] + "-" + (SEC == 1 ? SEC + 2 : SEC + 2)] = [Operacion.cadenaMascara((SEC == 1 ? SEC + 2 : SEC + 2), 4), PAUX[0], "", VA['PRO'].trim(), "", "", Number(v.DIMPORT), v.DTIPDOC, v.DNUMDOC, moment(v.DFECDOC2).format('DD/MM/YYYY'), moment(v.DFECVEN2).format('DD/MM/YYYY'), VA['SUB'], CF6D(VA['FCOM'], 1), "",
                               v.DCODMON, "", "", "", (v.DCODMON == "MN" ? v.DIMPORT : v.DIMPORT * VA['TC']), (v.DCODMON == "MN" ? v.DIMPORT / VA['TC'] : v.DIMPORT), "CODARC", CF6D(VA['FCOM'], 2), v.DFECDOC2, v.DXGLOSA, v.DCANTID];
                            //18:SOLES|19:DOLARES|20:CODARC|23:DXGLOSA|24:DCANTID
                        });
                    } else {
                        alert('Verificar metodo paraAsientoRet');
                    }
                } catch (ex) {
                    alert(ex.message);
                }
            }

            paraAsientoRet("AR");
            //
            var monto_seleccionado = function () {
                var MIITEMS = Operacion.mask('txtNDOC').val();
                VA['MON'] = Operacion.mask('lblMON').text();
                var CDOC = (VA['MON'] == "MN" ? Operacion.mask('txtPMN').val() : Operacion.mask('txtPUS').val());//MIITEMS > 1 
                var CRI_RET = (VA['AREA'] != "E04" ? (Number(CDOC) > 700 ? Number(CDOC) * Number(VA['P-POR'] / 100) : 0) : 0);//14.09.16|VALIDACION PARA LETRAS
                var ORET = (CRI_RET).toFixed(2);//OPERACION RETENCION;
                var MPAG = Number(CDOC - ORET).toFixed(2);
                var gridView1 = document.getElementById("<%=gvDCTOS.ClientID %>");
                LEN = gridView1.rows.length;
                var CONT = 0;
                for (var t = 1; t < LEN; t++) {
                    var cellPivot = gridView1.rows[t].cells[0].getElementsByTagName("input")[0].checked;
                    if (cellPivot == true) {
                        CONT++;
                        var cellPivot0 = gridView1.rows[t].cells[1]; TD = cellPivot0.innerHTML;
                        var cellPivot01 = gridView1.rows[t].cells[2]; NDOC = cellPivot01.innerHTML;
                        var cellPivot02 = gridView1.rows[t].cells[3]; FDOC = cellPivot02.innerHTML;
                        var cellPivot03 = gridView1.rows[t].cells[3]; FVEN = cellPivot03.innerHTML;
                        var cellPivot1 = gridView1.rows[t].cells[5]; MONEDA = cellPivot1.innerHTML;
                        var cellPivot2 = gridView1.rows[t].cells[8]; SALDO = cellPivot2.innerHTML;
                        var cellPivot10 = gridView1.rows[t].cells[10]; PORET = cellPivot10.innerHTML;
                        var cellPivot12 = gridView1.rows[t].cells[12]; CUENTA = cellPivot12.innerHTML;
                        var cellPivot13 = gridView1.rows[t].cells[13]; SUBCOMP = cellPivot13.innerHTML;
                        var cellPivot14 = gridView1.rows[t].cells[14]; TIPCAM = cellPivot14.innerHTML;
                        var SEC = DCUENTAS.length; var SARET = Number(SALDO) * Number(VA['P-POR'] / 100); VA['CONCEPTO'] = TD + " " + NDOC; //E04
                        //--1:ITEM ASIENTO
                        DCUENTAS.push(CUENTA + "-" + (SEC == 0 ? (SEC + 1) : SEC + 1));//421142
                        MASIENTO[CUENTA + "-" + (SEC == 0 ? (SEC + 1) : SEC + 1)] = [Operacion.cadenaMascara((SEC == 0 ? (SEC + 1) : SEC + 1), 4), CUENTA, "", VA['PRO'].trim(), "", "", Number(SALDO), TD, NDOC.trim(), FDOC, FVEN, VA['SUB'], CF6D(VA['FCOM'], 1), TIPCAM,
                               MONEDA, "", "", "", (MONEDA == "MN" ? SALDO : SALDO * TIPCAM), (MONEDA == "MN" ? SALDO / TIPCAM : SALDO), "CODARC", CF6D(VA['FCOM'], 2), CF6D(FDOC, 2), "", 0];
                        //V1:(MONEDA == "MN" ? SALDO : SALDO * (VA['AREA'] == "E04" ? TIPCAM : VA['TC'])) | (MONEDA == "MN" ? SALDO / (VA['AREA'] == "E04" ? TIPCAM : VA['TC']) : SALDO)
                        //24:DCANTID
                        switch (VA['AREA']) {
                            case "E04"://LETRAS
                                var PA_CO = SUBCOMP.split("-");
                                compDetalle(PA_CO[0].trim(), PA_CO[1], "FT", "H", TIPCAM);
                                //DCUENTAS.push(PAUX[0] + "-" + (SEC == 0 ? (SEC + 2) : SEC + 2));
                                //console.log(DCUENTAS);
                                //console.log(MASIENTO);
                                break;
                            default:
                                //MIITEMS > 1
                                (Number(CDOC) > 700 && Number(PORET) != 0 ? DCUENTAS.push(PAUX[0] + "-" + (SEC == 0 ? (SEC + 2) : SEC + 2)) : "");
                                (Number(CDOC) > 700 && Number(PORET) != 0 ?
                                    MASIENTO[PAUX[0] + "-" + (SEC == 0 ? (SEC + 2) : SEC + 2)] = [Operacion.cadenaMascara((SEC == 0 ? (SEC + 2) : SEC + 2), 4), PAUX[0], "", VA['PRO'].trim(), "", "", SARET, TD, NDOC.trim(), FDOC, FVEN, VA['SUB'], CF6D(VA['FCOM'], 1), "",
                                           MONEDA, "", "", "", (MONEDA == "MN" ? SARET : SARET * VA['TC']), (MONEDA == "MN" ? SARET / VA['TC'] : SARET), "CODARC", CF6D(VA['FCOM'], 2), CF6D(FDOC, 2), "", 0]
                                    : "");
                                //MASIENTO[PAUX[0] + "-" + (SEC == 0 ? (SEC + 2) : SEC + 2)] = [Operacion.cadenaMascara((SEC == 0 ? (SEC + 2) : SEC + 2), 4), PAUX[0], "", VA['PRO'].trim(), "", "", SARET, TD, NDOC.trim(), FDOC, FVEN, VA['SUB'], CF6D(VA['FCOM'], 1), "",
                                //MONEDA, "", "", "", (MONEDA == "MN" ? SALDO : SALDO * VA['TC']), (MONEDA == "MN" ? SALDO / VA['TC'] : SALDO), "CODARC", CF6D(VA['FCOM'], 2), CF6D(FDOC, 2), "", ""]
                                break;
                        }

                        //10:DFECVEN|20:CODARC
                    }
                }

                Operacion.mask('txtDSEL').val(CDOC);
                Operacion.mask('txtMADI').val(0.00);//PENDIENTE
                Operacion.mask('txtIRET').val(ORET);
                Operacion.mask('txtMPAG').val(MPAG);
                $('.cont_sel').show();
                $('#mis_pagos').hide();
                $('.pie_dctos').hide();
                Operacion.inputEstado('btnFpa', 0, true);
            }
            //CORRELAVITO COMPROBANTE
            var correlativoCP = function () {
                var element = VA['FCOM'];//Operacion.mask('txtFCOM').val();
                var fecha = element.split('/');

                var DATA = {};
                DATA.CTSUBDIA = VA['SUB'];//SUBDIARIO;
                DATA.CTANO = fecha[2].substr(2, 2);
                DATA.CTMES = fecha[1];
                $.ajax({
                    type: "POST",
                    url: "CancelaDR.aspx/correlativoCP",
                    data: '{ DATA: ' + JSON.stringify(DATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        VA['NCOMP'] = data.d;//NUMERO COMPROBANTE
                        Operacion.mask('txtDC_CU').val(data.d);
                    },
                    error: function (response) {
                        console.table(response);
                    }
                });
            }

            //ACTUALIZA NUMERACION SISPAG/CONCAR
            var anumCOMP = function () {
                var element = VA['FCOM'];
                var fecha = element.split('/');
                var NANO = fecha[2].substr(2, 2);
                var NMES = fecha[1];

                //SISPAG
                var CDATA = {};
                CDATA.CTSUBDIA = VA['SUB'];
                CDATA.CTANO = NANO;
                CDATA.CTMES = NMES;
                CDATA.CTNUMER = Number(VA['NCOMP'].substring(2, 6)).toString();

                $.ajax({
                    type: "POST",
                    url: "CancelaDR.aspx/aNumeracion",
                    data: '{CDATA:' + JSON.stringify(CDATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {

                    },
                    error: function (response) {
                        alert('El proceso no se pudo completar ANUMCOMP');
                        console.table(response);
                    }
                });
            };
            //CORRELATIVO PAGO
            var correlativoPG = function () {
                var TDOC = VA['CONCEPTO'].split(' ');

                var DATA = {};
                DATA.PG_CVANEXO = VA['AX'];
                DATA.PG_CTIPDOC = TDOC[0];
                DATA.PG_CCODIGO = VA['PRO'];
                DATA.PG_CFECCOM = CF6D(VA['FCOM'], 4);//YYYYMMDD
                DATA.PG_DFECCOM = CF6D(VA['FCOM'], 2);
                console.log(DATA);
                $.ajax({
                    type: "POST",
                    url: "CancelaDR.aspx/correlativoPG",
                    data: '{ DATA: ' + JSON.stringify(DATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        VA['CORDKEY'] = data.d;
                    },
                    error: function (response) {
                        console.table(response);
                    }
                });
            }
            //REGISTRA PAGO
            var registraPAG = function () {
                correlativoPG();
                var TDOC = VA['CONCEPTO'].split(' ');
                var DH = 0, OPX = 0, TC = VA['TC'];//TIPO CAMBIO;
                //CASO 1:
                var DATA = {};
                var gridView2 = document.getElementById('<%=gvDCOM.ClientID%>');
                var FLAG = Operacion.mask('txtIMRE').val();
                var LEN = (VA['AREA'] == "E04" ? 2 : (FLAG==0?gridView2.rows.length:gridView2.rows.length-1));
                var LENX = LEN - 2;//2 ULTIMOS ITEMS 10/77
                for (var k = 1; k < LENX; k++) {
                    switch (VA['AREA']) {
                        case "E04":
                            //var LEN = DCUENTAS.length;
                            DH = MASIENTO[DCUENTAS[0]][18]; OPX = MASIENTO[DCUENTAS[0]][19];
                            break;
                        default:
                            DH = MASIENTO[DCUENTAS[k - 1]][18];
                            OPX = MASIENTO[DCUENTAS[k - 1]][19];
                            break;
                    }
                    //SOLO IMPARES
                    var count = 0;
                    if (k % 2 == 1) {
                        //console.log("COUNT->"+count+"k"+k);
                        count++;
                        DATA.PG_CVANEXO = VA['AX'];//ANEXO
                        DATA.PG_CCODIGO = VA['PRO'].trim();//CODIGO PROVEEDOR
                        DATA.PG_CTIPDOC = (VA['AREA'] == "E04" ? TDOC[0] : TDOC[0]);
                        DATA.PG_CNUMDOC = (VA['AREA'] == "E04" ? TDOC[1] : TDOC[1]);
                        DATA.PG_CORDKEY = VA['CORDKEY'];//GENERO EN LA BASE
                        DATA.PG_CDEBHAB = (VA['AREA'] == "E04" ? "D" : (count % 2 == 0 ? 'H' : MASIENTO[DCUENTAS[k - 1]][5]));//VALIDA VARIACION DINA. CTA D/H
                        DATA.PG_NIMPOMN = Number(DH);//DETRACCION-RETENCION MN
                        DATA.PG_NIMPOUS = Number(OPX);
                        DATA.PG_CFECCOM = CF6D(VA['FCOM'], 1);//NFECHA;
                        DATA.PG_CSUBDIA = VA['SUB'];
                        DATA.PG_CNUMCOM = VA['NCOMP'];//CORRELATIVO DEL COMPROBANTE
                        DATA.PG_CGLOSA = "WI.:" + VA['CHCHE'] + "," + Operacion.mask('txtNGIR').val();
                        DATA.PG_CCOGAST = "";
                        DATA.PG_CORIGEN = "CP";//CP:SISPAG
                        DATA.PG_CUSUARI = $('#hfusu').val();
                        DATA.PG_CCODMON = VA['MON'];
                        DATA.PG_DFECCOM = CF6D(VA['FCOM'], 2);
                        var result = Operacion.oAjax("CancelaDR.aspx/guardarPLQ", DATA, null);
                        try {
                            if (typeof result == 'object') {
                                console.log(DATA);
                                var RED = Operacion.mround(LENX / 2,0);
                                (count == RED ? actualizaCart(VA['AREA']) : "");
                            }
                        } catch (ex) {
                            alert(ex.message);
                        }
                    }
                }

            }
            //REGISTRA CARTERA DE PAGO
            var actualizaCart = function (KEY) {
                switch (KEY) {
                    case 'E04':
                        if (confirm('Se ha generado el comprobante:Sub[' + VA['SUB'] + '] Comprobante' + VA['NCOMP'] + '\nDesea imprimir el comprobante')) {
                            //IMPRIMIR
                        } else {

                        }
                        break;
                    default:
                        var LEN = Number(Operacion.mask('txtNDOC').val()) * 2;//NUMERO DE DOCUMENTOS ELEGIDOS
                        for (var i = 0; i < LEN; i++) {
                            if (i % 2 == 1) {
                                var DATA = { CP_CVANEXO: VA['AX'], CP_CCODIGO: VA['PRO'].trim(), CP_CTIPDOC: MASIENTO[DCUENTAS[i-1]][7], CP_CNUMDOC: MASIENTO[DCUENTAS[i-1]][8] }
                                //console.log(CDATA);
                                var result = Operacion.oAjax("CancelaDR.aspx/actualizarSaldo", DATA, null);
                                //var LEN1 = result.d.length;
                                try {
                                    if (typeof result == 'object') {
                                        if (i == (LEN - 1)) {
                                            if (confirm('Se ha generado el comprobante:Sub[' + VA['SUB'] + '] Comprobante [' + VA['NCOMP'] + ']\nDesea imprimir el comprobante')) {
                                                //GENERAR IMPRESIÓN PDF
                                                window.open("Reportes/IComprobante.aspx?SD=" + VA['SUB'] + "&COMP=" + VA['NCOMP'] + "&FCOMP=" + CF6D(VA['FCOM'], 2), '_blank');
                                                if (confirm('Desea generar archivo [.txt]')) {
                                                    //GENERA ARCHIVO TXT TELEMATICO
                                                    window.open("TelematicoBanco.aspx?ANEXO=" + VA['AX'] + "&PRO=" + VA['PRO'].trim() + "&SD=" + VA['SUB'] + "&CO=" + VA['NCOMP'] + "&BA=" + Operacion.mask('hfBAN').val() + "&CB=" + VA['CHCCON'].trim(), '_blank');
                                                } else {
                                                    //location.reload();
                                                }
                                            } else {
                                                location.reload();
                                                //javascript.close();
                                            }
                                        } else {

                                        }
                                    }
                                } catch (ex) {
                                    alert(ex.message);
                                }
                            }
                        }
                        break;
                }
            }
            //REGISTRA CARTERA CHEQUE
            var carteraCHE = function () {
                //VA['CHNCTA'] = CTABAN; VA['CHCCON'] = CNOBAN;
                var DATA = {
                    CH_CNUMCTA: VA['CHCCON'].trim(),
                    CH_CNUMCHE: VA['CHCHE'],
                    CH_CFECCHE: CF6D(VA['FCOM'], 1),
                    CH_CNOMCHE: VA['PROD'],
                    CH_CFECCOM: CF6D(VA['FCOM'], 1),
                    CH_CSUBDIA: VA['SUB'],
                    CH_CNUMCOM: VA['NCOMP'],
                    CH_NIMPOCH: VA['CHIMP'],
                    CH_CCODMON: VA['MON'],
                    CH_CVANEXO: VA['AX'],
                    CH_CCODIGO: VA['PRO'].trim(),
                    CH_CESTADO: "C",
                    CH_CFECEST: CF6D(VA['FCOM'], 1),
                    CH_CUSUARI: $('#hfusu').val(),
                    CH_DFECHA: CF6D(VA['FCOM'], 2),
                    CH_CHORA: Operacion.hora(),
                    CH_CCTACON: VA['CHNCTA'],
                    CH_CSITUAC: "",
                    CH_DOCREFT: "",
                    CH_DOCREFN: "",
                    CH_CCOGAST: "",
                    CH_CCONCEP: Operacion.mask('txtCPAG').val(),
                    CH_CFECDIF: CF6D(VA['FCOM'], 1),/*OBSERVACION*/
                    CH_NTIPCAM: VA['TC'],
                    CH_CCTACTE: "",
                    CH_CFORPAG: "",
                    CH_CTIPPAG: "",
                    CH_DFECCHE: CF6D(VA['FCOM'], 2),
                    CH_DFECCOM: CF6D(VA['FCOM'], 2),
                    CH_DFECEST: CF6D(VA['FCOM'], 2),
                    CH_DFECDIF: CF6D(VA['FCOM'], 2),
                    CH_CPAGTEL: "",
                    CH_CNUMLIQ: ""
                }
                console.log(DATA);
                var result = Operacion.oAjax("CancelaDR.aspx/registrar_vari", DATA, null);
                var LEN1 = result.d.length;
                try {
                    if (typeof result == 'object') {
                        //console.log(result);
                        registraPAG();
                    }
                } catch (ex) {
                    alert(ex.message);
                }
            }
            var balance = function (MIABAL, MIABAL1) {
                /*var element = Operacion.mask('txtFCOM').val();//FECHA COMPROBANTE
                var fecha = element.split('/');
                var FECPRO = fecha[2] + "" + fecha[1];*/
                var MN_DEBE = 0;
                var MN_HABER = 0;
                var US_DEBE = 0;
                var US_HABER = 0;
                var US1_DEBE = 0;
                var US1_HABER = 0;
                //console.log(MIABAL);
                var LEN = A_DCUENTAS.length;
                for (var i = 0; i < LEN; i++) {
                    if (A_DCUENTAS[i] != "") {
                        if (VA['MON'] == "MN") {
                            //MASIENTO[DCUENTAS[i+1]][19]
                            MN_DEBE = (MIABAL[A_DCUENTAS[i]]['D'] != undefined ? Number(MIABAL[A_DCUENTAS[i]]['D']) : 0);
                            MN_HABER = (MIABAL[A_DCUENTAS[i]]['H'] != undefined ? Number(MIABAL[A_DCUENTAS[i]]['H']) : 0);
                            US_DEBE = (MIABAL[A_DCUENTAS[i]]['D'] != undefined ? Operacion.mround(MIABAL1[A_DCUENTAS[i]]['D'], 2) : 0);
                            US_HABER = (MIABAL[A_DCUENTAS[i]]['H'] != undefined ? Operacion.mround(MIABAL1[A_DCUENTAS[i]]['H'], 2) : 0);
                        } else {
                            MN_DEBE = (MIABAL[A_DCUENTAS[i]]['D'] != undefined ? Operacion.mround(MIABAL1[A_DCUENTAS[i]]['D'], 2) : 0);
                            MN_HABER = (MIABAL[A_DCUENTAS[i]]['H'] != undefined ? Operacion.mround(MIABAL1[A_DCUENTAS[i]]['H'], 2) : 0);
                            US_DEBE = (MIABAL[A_DCUENTAS[i]]['D'] != undefined ? Number(MIABAL[A_DCUENTAS[i]]['D']) : 0);
                            US_HABER = (MIABAL[A_DCUENTAS[i]]['H'] != undefined ? Number(MIABAL[A_DCUENTAS[i]]['H']) : 0);
                        }
                        var MCTALI = A_DCUENTAS[i].split("-");
                        var BDATA = {};
                        BDATA.BCUENTA = MCTALI[0].trim();//DCUENTAS[i];
                        BDATA.BMNSALA = 0;
                        BDATA.BMNDEBE = MN_DEBE;
                        BDATA.BMNHABER = MN_HABER;
                        BDATA.BMNSALN = 0;
                        BDATA.BUSSALA = 0;
                        BDATA.BUSDEBE = Number(US_DEBE).toFixed(2);
                        BDATA.BUSHABER = Number(US_HABER).toFixed(2);
                        BDATA.BUSSALN = 0;
                        BDATA.BMNSALI = 0;
                        BDATA.BUSSALI = 0;
                        BDATA.BFECPRO = "";
                        BDATA.BFORBAL = "1";
                        BDATA.BFORGYP = "";
                        BDATA.BFORRE1 = "";
                        BDATA.BCTAAJU = "";
                        BDATA.BFECPRO2 = CF6D(VA['FCOM'], 5);//FECPRO;
                        console.log(BDATA);
                        $.ajax({
                            type: "POST",
                            url: "CancelaDR.aspx/actualizaBAL",
                            data: '{ BDATA: ' + JSON.stringify(BDATA) + '}',
                            contentType: "application/json;charset=utf-8",
                            dataType: "json",
                            async: false,
                            success: function (data) {
                                if (i == (LEN - 1)) {
                                    rpta = true;
                                }
                            },
                            error: function (data) {
                                alert('El proceso no se pudo completar BAL');
                                console.log(data);
                            }
                        });
                    }//VALIDACION PARA ITEM ELIMINADO

                }
                return { rpta }
            }
            //REGSITRO DETALLE COMPROBANTE
            var asientoDET = function () {
                var PASBAL = [], PASBAL1 = [];
                var gridView = document.getElementById('<%=gvDCOM.ClientID%>');//"";
                var LEN = gridView.rows.length;
                var D_SUM = 0;
                var H_SUM = 0;
                for (var i = 1; i < LEN; i++) {
                    cellPivot01 = gridView.rows[i].cells[0];//SECUENCIA
                    gitem01 = cellPivot01.innerHTML;
                    cellPivot02 = gridView.rows[i].cells[1];//CUENTA
                    gitem02 = cellPivot02.innerHTML;
                    cellPivot03 = gridView.rows[i].cells[2];//DETALLE
                    gitem03 = cellPivot03.innerHTML;
                    //ARREGLO BALANCE----------------------------
                    cellPivot04 = gridView.rows[i].cells[3];//PROVEEDOR
                    gitem04 = cellPivot04.innerHTML;
                    cellPivot05 = gridView.rows[i].cells[4];//CENTRO COSTO
                    gitem05 = cellPivot05.innerHTML;
                    cellPivot06 = gridView.rows[i].cells[5];//DEBE-HABER
                    gitem06 = cellPivot06.innerHTML.trim();
                    cellPivot07 = gridView.rows[i].cells[6];//IMPORTE
                    gitem07 = cellPivot07.innerHTML;
                    cellPivot08 = gridView.rows[i].cells[7];//TIPO DOCUMENTO
                    gitem08 = cellPivot08.innerHTML;
                    cellPivot09 = gridView.rows[i].cells[8];//NUMERO DOCUMENTO
                    gitem09 = cellPivot09.innerHTML;
                    cellPivot10 = gridView.rows[i].cells[9];//FECHA DOCUMENTO
                    gitem10 = cellPivot10.innerHTML;
                    cellPivot11 = gridView.rows[i].cells[10];//FECHA VENCIMIENTO
                    gitem11 = cellPivot11.innerHTML;
                    //cellPivot12 = gridView.rows[i].cells[11];//CONVERSION MONEDA
                    //gitem12 = cellPivot12.innerHTML;

                    //BALANCE X CUENTA ---------------------------------------------------------------------------
                    var MCOD = gitem02 + "-" + i;
                    A_DCUENTAS.push(MCOD);
                    PASBAL[MCOD] = new Array();//COLUMNAS
                    PASBAL1[MCOD] = new Array();
                    if (gitem06 == "D" && gitem05.trim() == "") {
                        PASBAL[MCOD][gitem06] = gitem07;//D_SUM;//IMPORTE MONEDA X
                        PASBAL1[MCOD][gitem06] = (VA['MON'] == "MN" ? MASIENTO[DCUENTAS[i - 1]][19] : MASIENTO[DCUENTAS[i - 1]][18]);//CONVERSION DE MONEDA
                    } else if (gitem06 == "H" && gitem05.trim() == "") {
                        PASBAL[MCOD][gitem06] = gitem07;//H_SUM;//IMPORTE MONEDA X
                        PASBAL1[MCOD][gitem06] = (VA['MON'] == "MN" ? MASIENTO[DCUENTAS[i - 1]][19] : MASIENTO[DCUENTAS[i - 1]][18]);//CONVERSION DE MONEDA
                    } else if (gitem06 == "D" && gitem05.trim() != "") {
                        PASBAL[MCOD][gitem06] = gitem07;//H_SUM;//IMPORTE MONEDA X
                        PASBAL1[MCOD][gitem06] = (VA['MON'] == "MN" ? MASIENTO[DCUENTAS[i - 1]][19] : MASIENTO[DCUENTAS[i - 1]][18]);//CONVERSION DE MONEDA
                    }//--------------------------------------------------------------------------------------------

                    //0:SUBDIARIO 11
                    var MI_CONTROL1 = Operacion.mask('txtDC_DI').val();//SOLES-DOLARES
                    var MI_CONTROL2 = Operacion.mask('txtDC_DI0').val();//DOLARES-SOLES

                    //NUEVO 30.06.2016|RENDONDEO X FORMULA---------------------------------------------------------
                    /*var gitem07_N = Number(gitem07);/*(Number(MI_CONTROL1) == Number(0) ? Number(gitem07) :
                                        ((LEN - 1) == i || (LEN - 2) == i || (LEN - 3) == i ?
                                            Number(gitem07) - Number((M_DATA[12] == "US" ? MI_CONTROL2 : MI_CONTROL1)) ://NUEVO 04.08.16
                                            Number(gitem07))
                                    );
                    var gitem07US = /*(Number(MI_CONTROL2) == Number(0) ? Operacion.mround(gitem07 / M_DATA[13], 2) :
                                        ((LEN - 1) == i || (LEN - 2) == i || (LEN - 3) == i ?
                                            Operacion.mround(gitem07_N / M_DATA[13], 2) - Number(MI_CONTROL2) :
                                            Operacion.mround(gitem07_N / M_DATA[13], 2))
                                    );*/
                    //VALIDA REF. CHEQUE
                    if (gitem02.startsWith("10") == true) {
                        VA['CHCHE'] = gitem09 + "" + VA['NCOMP'];
                    }
                    var ADET = {};
                    ADET.DSUBDIA = VA['SUB'];
                    ADET.DCOMPRO = VA['NCOMP'];
                    ADET.DSECUE = gitem01;
                    ADET.DFECCOM = CF6D(VA['FCOM'], 1);
                    ADET.DCUENTA = gitem02.trim();
                    ADET.DCODANE = gitem04.trim();
                    ADET.DCENCOS = gitem05;
                    ADET.DCODMON = MASIENTO[DCUENTAS[i - 1]][14];
                    ADET.DDH = gitem06;
                    ADET.DIMPORT = Number(gitem07);
                    ADET.DTIPDOC = gitem08;
                    ADET.DNUMDOC = (gitem02.startsWith("10") == true ? gitem09 + "" + VA['NCOMP'] : gitem09);
                    ADET.DFECDOC = (gitem10 != "" ? CF6D(gitem10, 1) : "");
                    ADET.DFECVEN = (gitem11 != "" ? CF6D(gitem11, 1) : "");
                    ADET.DAREA = MASIENTO[DCUENTAS[i - 1]][15];
                    ADET.DFLAG = VA['FLAG'];
                    ADET.DDATE = moment();
                    ADET.DXGLOSA = (i == (LEN - 1) ? "" : (VA['AREA'] == "E04" ? MASIENTO[DCUENTAS[i - 1]][23] : Operacion.mask('txtCPAG').val().substring(0, 29)));
                    ADET.DUSIMPOR = Operacion.mround(MASIENTO[DCUENTAS[i - 1]][19], 2);//(VA['MON'] == "MN" ? gitem07US : gitem07_N);
                    ADET.DMNIMPOR = Operacion.mround(MASIENTO[DCUENTAS[i - 1]][18], 2);//(VA['MON'] == "MN" ? gitem07_N : Operacion.mround(gitem07_N * M_DATA[13], (Number(M_DATA[68]) == Number(gitem07) ? 0 : 2)));//O:gitem07:
                    ADET.DCODARC = MASIENTO[DCUENTAS[i - 1]][20];
                    ADET.DFECCOM2 = CF6D(VA['FCOM'], 2);
                    ADET.DFECDOC2 = CF6D(gitem10, 2);
                    ADET.DFECVEN2 = (gitem11.trim() != "" ? CF6D(gitem11, 2) : null);
                    ADET.DCODANE2 = "";
                    ADET.DVANEXO = MASIENTO[DCUENTAS[i - 1]][17];//PRIMERA VALIDACION "P"--------------------------------
                    ADET.DVANEXO2 = "";
                    ADET.DTIPCAM = 0;
                    ADET.DCANTID = MASIENTO[DCUENTAS[i - 1]][24];
                    ADET.DCTAORI = "";//CUENTA ORIGEN
                    ADET.DCCODMON = "";
                    ADET.DCIMPORT = 0;
                    ADET.DCNUMDOC = "";
                    ADET.DCESTADO = "";
                    ADET.DCCONFEC2 = null;
                    ADET.DCCONNRO = "";
                    ADET.DCCONPRO = null;
                    ADET.DCNUMEST = "";
                    ADET.DCITEM = "";
                    ADET.DCIMPORTB = 0;
                    ADET.DCANO = "";
                    ADET.DTIPDOR = "";
                    ADET.DNUMDOR = "";
                    ADET.DFECDO2 = null;
                    ADET.DTIPTAS = "";
                    ADET.DIMPTAS = 0;
                    ADET.DIMPBMN = 0;
                    ADET.DIMPBUS = 0;
                    ADET.DMONCOM = "";
                    ADET.DCOLCOM = "";
                    ADET.DBASCOM = 0;
                    ADET.DINACOM = 0;
                    ADET.DIGVCOM = 0;
                    ADET.DTPCONV = "";
                    ADET.DFLGCOM = "";
                    ADET.DANECOM = "";
                    ADET.DTIPACO = "";
                    ADET.DMEDPAG = MASIENTO[DCUENTAS[i - 1]][16];
                    ADET.DTIPDO2 = "";
                    ADET.DNUMDO2 = "";
                    ADET.DRETE = "";
                    ADET.DPORRE = 0;
                    //console.log("I=>"+i+"LEN=>"+LEN);
                    $.ajax({
                        type: "POST",
                        url: "CancelaDR.aspx/guardarADET",
                        data: '{ ADDATA: ' + JSON.stringify(ADET) + '}',
                        contentType: "application/json;charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (data) {
                            console.log(ADET);
                            if (i == (LEN - 1)) {
                                var resolve = balance(PASBAL, PASBAL1).rpta;
                                if (resolve == true) {
                                    carteraCHE();
                                } else {
                                    //location.reload();
                                }//confirm
                            }//fin resolve
                        },
                        error: function (data) {
                            alert('El proceso no se pudo completar ADET');
                            console.log(data);
                        }
                    });

                }//FIN FOR
            }
            //REGITRO COMPROBANTE CABECERA
            var asientoCAB = function () {
                correlativoCP();//CORRELATIVO COMPROBANTE

                var fechar = moment();//FECHA ACTUAL
                var total = Number(Operacion.mask('txtDC_DE').val());//Number(Operacion.mask('txtTACU').val());//REEMPLAZAR
                var MGLOSA = Operacion.mask('txtACR1').val();

                var M_SETC = VA['FCOM'];
                var nfecha2 = CF6D(M_SETC, 1);

                var ACAB = {};
                ACAB.CSUBDIA = VA['SUB'];
                ACAB.CCOMPRO = VA['NCOMP'];//NUMERO CORRELATIVO COMPROBANTE
                ACAB.CFECCOM = CF6D(VA['FCOM'], 1);//FECCOM;
                ACAB.CCODMON = VA['MON'];
                ACAB.CSITUA = "F";//FINALIZADO
                ACAB.CTIPCAM = VA['VTIC'];
                ACAB.CGLOSA = MGLOSA;//REEMPLAZAR
                ACAB.CTOTAL = total;//REEMPLAZAR
                ACAB.CTIPO = "C";//VA['CTIC'];//TIPO CONVERSION
                ACAB.CFLAG = (VA['CTIC'] == "F" ? "S" : "N");//VERIFICAR
                ACAB.CDATE = fechar;
                ACAB.CHORA = Operacion.hora();
                ACAB.CUSER = $('#hfusu').val();
                ACAB.CFECCAM = "";//(M_SETC != "" ? nfecha2 : "");
                ACAB.CORIG = "CP";//CP:SISPAG
                ACAB.CFORM = "A";//A:AUTOMATICO
                ACAB.CTIPCOM = "25";//25:DESCONOCIDO
                ACAB.CEXTOR = "";
                ACAB.CFECCOM2 = CF6D(VA['FCOM'], 2);//moment(element1, 'DD/MM/YYYY');
                ACAB.CFECCAM2 = "";//(M_SETC != "" ? moment(M_SETC, 'DD/MM/YYYY') : "");
                ACAB.CMEMO = "";
                ACAB.CSERCER = "";
                ACAB.CNUMCER = "";
                VA['FLAG'] = (VA['CTIC'] == "F" ? "S" : "N");
                //console.log(ACAB);

                $.ajax({
                    type: "POST",
                    url: "CancelaDR.aspx/guardarACAB",
                    data: '{ ACDATA: ' + JSON.stringify(ACAB) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        anumCOMP();
                        asientoDET();
                    },
                    error: function (data) {
                        alert('El proceso no se pudo completar ACAB');
                        console.log(data);
                    }
                });
            }
            //PROCESO DE PAGO
            var registro_pago = function () {
                //ANEXOS---------------------------------------10
                var LEN = DCUENTAS.length;
                var CTABAN = Operacion.mask('hfIDB').val();
                var CNOBAN = Operacion.mask('hfIDC').val();
                var NDOBAN = CF6D(VA['FCOM'], 3) + "" + VA['SUB'];
                var TOTACU = Operacion.mask('txtTACU').val();
                VA['CHNCTA'] = CTABAN; VA['CHCCON'] = CNOBAN; VA['CHIMP'] = TOTACU;
                DCUENTAS.push(CTABAN + "-" + (Number(LEN) + 1));//CUENTA BANCOS // DCUENTAS.push("776101");
                MASIENTO[CTABAN + "-" + (Number(LEN) + 1)] = [Operacion.cadenaMascara((Number(LEN) + 1), 4), CTABAN, "", CNOBAN, "", "", Number(TOTACU), "WI", NDOBAN, VA['FCOM'], "", VA['SUB'], CF6D(VA['FCOM'], 1), "",
                               MONEDA, VA['AREA'], VA['MEPA'], "G", (MONEDA == "MN" ? TOTACU : TOTACU * VA['TC']), (MONEDA == "MN" ? TOTACU / VA['TC'] : TOTACU), "01", CF6D(VA['FCOM'], 2), CF6D(FDOC, 2), Operacion.mask('txtCPAG').val().trim(), 0];
                //---------------------------------------------0:(MONEDA == "MN" ? TOTACU : TOTACU * VA['TC'])
                //8:DNUMDOC 24:DCANTID
                detalleCO();
            }
            var detalleCO = function () {
                var S_MD = 0, S_MH = 0, U_MD = 0, U_MH = 0;
                var DMN = (VA['MON'] == "MN" ? "SOLES" : "DOLARES");
                Operacion.mask('txtDC_SU').val(VA['SUB']);
                Operacion.mask('txtDC_CU').val("");
                Operacion.mask('txtDC_MO ').val(VA['MON'] + " " + DMN);
                Operacion.mask('txtDC_FD').val(VA['FCOM']);
                var LEN = DCUENTAS.length;
                MASIENTO[DCUENTAS[0]][23] = Operacion.mask('txtCPAG').val().trim();
                for (var i = 0; i < LEN; i++) {
                    var DAUX = DCUENTAS[i].split("-");
                    MDCTA(DAUX[0]);//PERMISOS CUENTA
                    verificaDH(VA['SUB'], DAUX[0]);// ASIGNA D/H
                    var M_DH = RDCTA[DAUX[0]][9];//VALOR-POSICION D/H
                    MASIENTO[DCUENTAS[i]][5] = (VA['AREA'] == "E04" ? (i == 0 || DCUENTAS[i].startsWith("10") == true ? M_DH : (i % 2 == 0 ? 'H' : 'D')) : M_DH);// : M_DH)
                    MASIENTO[DCUENTAS[i]][17] = RDCTA[DAUX[0]][1];//DANEXO
                    MASIENTO[DCUENTAS[i]][20] = (VA['AREA'] == "E04" ? (i != 0 && i < (LEN - 1) ? "" : RDCTA[DAUX[0]][10]) : RDCTA[DAUX[0]][10]);
                    //console.log("DAUX[0]=>" + DAUX[0] + "RDCTA[DAUX[0]][1]=>" + RDCTA[DAUX[0]][1]);
                    if (MASIENTO[DCUENTAS[i]][5] == "D") { //M_DH
                        //USA = USA + parseFloat((SALDO / VA['TC']).toFixed(2));
                        //V1O:(VA['MON'] == "MN" ? parseFloat((MASIENTO[DCUENTAS[i]][6] / VA['TC']).toFixed(2)) : parseFloat((MASIENTO[DCUENTAS[i]][6] * VA['TC']).toFixed(2))) :
                        var M_CAL1 = (VA['AREA'] != "E04" ?
                                        (VA['MON'] == "MN" ? parseFloat((MASIENTO[DCUENTAS[i]][19]).toFixed(2)) : parseFloat((MASIENTO[DCUENTAS[i]][18]).toFixed(2))) :
                                        (VA['MON'] == "MN" ? parseFloat((MASIENTO[DCUENTAS[i]][19]).toFixed(2)) : parseFloat((MASIENTO[DCUENTAS[i]][18]).toFixed(2))));
                        S_MD = Operacion.mround(Number(S_MD) + Number(MASIENTO[DCUENTAS[i]][6]), 2);
                        U_MD = Operacion.mround(Number(U_MD) + Number(M_CAL1), 2);
                        //console.log("CTA=>" + DCUENTAS[i] + "->" + U_MD + "->US" + MASIENTO[DCUENTAS[i]][19] + "->SL" + MASIENTO[DCUENTAS[i]][18]+" C1=>"+M_CAL1);
                    } else {
                        //V2O:(VA['MON'] == "MN" ? parseFloat((MASIENTO[DCUENTAS[i]][6] / VA['TC']).toFixed(2)) : parseFloat((MASIENTO[DCUENTAS[i]][6] * VA['TC']).toFixed(2))) :
                        var M_CAL2 = (VA['AREA'] != "E04" ?
                                        (VA['MON'] == "MN" ? parseFloat((MASIENTO[DCUENTAS[i]][19]).toFixed(2)) : parseFloat((MASIENTO[DCUENTAS[i]][18]).toFixed(2))) :
                                        (VA['MON'] == "MN" ? parseFloat((MASIENTO[DCUENTAS[i]][19]).toFixed(2)) : parseFloat((MASIENTO[DCUENTAS[i]][18]).toFixed(2)))
                                     );
                        S_MH = Operacion.mround(Number(S_MH) + Number(MASIENTO[DCUENTAS[i]][6]), 2);
                        U_MH = Operacion.mround(Number(U_MH) + Number(M_CAL2), 2);
                        //console.log("CTA=>" + DCUENTAS[i] + "->" + U_MH + "->US" + MASIENTO[DCUENTAS[i]][19] + "->SO" + MASIENTO[DCUENTAS[i]][18]+" C2=>"+M_CAL2);
                    }
                }
                Operacion.mask('txtDC_DE').val(S_MD);//DEBE
                Operacion.mask('txtDC_HA').val(S_MH);//HABER
                Operacion.mask('txtDC_DI').val(Number(S_MD) - Number(S_MH));

                Operacion.mask('txtDC_DE0').val(U_MD);
                Operacion.mask('txtDC_HA0').val(U_MH);//DOLARES HABER
                Operacion.mask('txtDC_DI0').val(Operacion.mround(Number(U_MD) - Number(U_MH), 2));
                //CUENTAS DE AJUSTE
                //SEGUNDA MONEDA
                var ACA = Operacion.mask('txtDC_DI0').val();
                if (Number(ACA) > 0) {
                    //console.log(PAUX);
                    var NCTA = PAUX[2] + "-" + (Number(LEN) + 1);
                    DCUENTAS.push(NCTA); MASIENTO[NCTA] = new Array(24);
                    MDCTA(PAUX[2].trim());//PERMISOS CUENTA
                    verificaDH(VA['SUB'], PAUX[2].trim());// ASIGNA D/H 
                    MASIENTO[NCTA] = [Operacion.cadenaMascara((Number(LEN) + 1), 4), PAUX[2], "", "", "", RDCTA[PAUX[2]][9], Number(S_MD - S_MH), "", "", "", "", VA['SUB'],
                                     "", "", VA['MON'], "", "", RDCTA[PAUX[2].trim()][1], (VA['MON'] == "MN" ? 0 : Math.abs(ACA)), (VA['MON'] == "MN" ? Math.abs(ACA) : 0), "", "", "", "", 0];
                    //15:AREA RDCTA[PAUX[2]][1]|20:CODARC
                } else {
                    var NCTA = PAUX[1] + "-" + (Number(LEN) + 1);
                    DCUENTAS.push(NCTA); MASIENTO[NCTA] = new Array(24);
                    MDCTA(PAUX[1].trim());//PERMISOS CUENTA
                    verificaDH(VA['SUB'], PAUX[1].trim());// ASIGNA D/H | VALIDA AREA LETRAS (VA['AREA'] == "E04" ? "" : 
                    MASIENTO[NCTA] = [Operacion.cadenaMascara((Number(LEN) + 1), 4), PAUX[1], "", "", "", RDCTA[PAUX[1].trim()][9], Number(S_MD - S_MH), "", "", "", "", VA['SUB'],
                                     "", "", VA['MON'], "", "", RDCTA[PAUX[1].trim()][1], (VA['MON'] == "MN" ? 0 : Math.abs(ACA)), (VA['MON'] == "MN" ? Math.abs(ACA) : 0), "", "", "", "", 0];
                    //15:AREA RDCTA[PAUX[2]][1]|20:CODARC|23:DXGLOSA
                }
                var MVISIBLE = ["", "", "", "", "", "", "", "", "", "", "", "", "", ""];
                dibujaTabla("<%=gvDCOM.ClientID %>", DCUENTAS, "mi_tabla", MASIENTO, true, MVISIBLE);
                dialog2.dialog("open");
                console.log(MASIENTO);
            }
            //OPCIONES
            $("#tabs").tabs({
                collapsible: true
            });
            //ELECCION DE FORMA DE BUSQUEDA - BANCO
            $('input:radio[name=rb]').click(function () {
                miconsulta = ($(this).val() == "C" ? 'BancosxCta' : 'BancosxCtaD');
                Operacion.mask('txtdescripcion').val('');
                Operacion.mask('txtdescripcion').focus();
            });
            //ELECCION MODO TIPO CAMBIO
            $('input:radio[name=rb_1]').click(function () {
                CODATA.XFECCAM2 = moment(Operacion.mask('txtFCOM').val(), 'DD-MM-YYYY');
                var TC = $('input:radio[name=rb_1]:checked').val();
                if (TC == "C") {
                    Operacion.inputEstado('txtTICA', 0, true);
                    Operacion.inputRead('txtTICA', 0);
                    Operacion.iValida('txtTICA', 1);
                    Operacion.mask('txtTICA').focus();
                } else {
                    Operacion.inputEstado('txtTICA', 1, true);
                    iniciaTC(CODATA, TC);
                }
            });
            //FECHA COMPROBANTE
            Operacion.mask('txtFCOM').change(function () {
                bloqueoFE($(this).val());
                VA['FCOM'] = $(this).val();//FECHA COMPROBANTE
                var copiaFecha = $(this).val();
                Operacion.mask('txtCITB').val(copiaFecha);
                if (valida) {
                    Operacion.mask('ddlArea').focus();
                    Operacion.mask('ddlArea').select();
                }
            });
            Operacion.mask('txtCITB').change(function () {
                if (valida()) {
                    Operacion.inputEstado('btnDoc', 0, true);
                    $('.cont_comp').hide();
                    $('.pie_dctos').hide();
                    $('#mis_pagos').show();
                    $('.pie_dctos').show();
                    VA['SUB'] = Operacion.mask('ddlSUB').val();//SUBDIARIO ELEGIDO
                    VA['AREA'] = Operacion.mask('ddlArea').val();
                    VA['MEPA'] = Operacion.mask('ddlTIPA').val();
                } else {
                    alert('Completar los datos');
                }
                //(VA['AREA'] != "E04" ? paraAsientoRet("AR") : "");//VALIDA QUE NO SE LETRAS
            });
            //APERTURA REGISTRO DE PAGO
            $(".btaper").click(function () {
                var EX = ['txtFCOM'];
                limpiar(EX);
                Operacion.inputEstado('btnFpa', 1, true);
                Operacion.inputEstado('btnFinalizar', 1, true);
                Operacion.mask('txtNCU').focus();
                $('#forpag').hide();
                $('.cont_comp').show();//APERTURA DOCUMENTOS
                $("#dvcandoc").dialog('open');
                var mrow1 = $(this).parent().parent();
                var AX0 = mrow1.find("td").eq(0).html();//ANEXO
                var AX1 = mrow1.find("td").eq(1).html();//RUC
                var AX2 = mrow1.find("td").eq(2).html();//DESCRIPCION
                Operacion.mask('txtACR0').val(AX0 + "-" + AX1);
                Operacion.mask('txtACR1').val(AX2);
                Operacion.mask('hfPRO').val(AX0 + "-" + AX1.trim());
                verificaPAPR(AX0, AX1);
                verificaACR(AX1, AX0);
                Operacion.inputRead('txtPMN', 1);
                Operacion.inputRead('txtPUS', 1); VA['AX'] = AX0; VA['PRO'] = AX1; VA['PROD'] = AX2;
            });
            $(".validaunoporuno").live("click", function () {
                $tr = $(this).closest('tr');
                myRow = $tr.index();
                VA['TC'] = Operacion.mask('txtTICA').val();
                if (valida() && Number(VA['TC']) > 0) {
                    var mrow1 = $(this).parent().parent();
                    if ($(this).is(':checked') == true) {
                        var id = mrow1.find("td").eq(7).html();
                        $("#MainContent_gvDCTOS tr:nth-child(" + (myRow + 1) + ") td:nth-child(8)").html("0.00");
                        $("#MainContent_gvDCTOS tr:nth-child(" + (myRow + 1) + ") td:nth-child(9)").html(id);
                        iniciaSP();
                    } else {
                        var id = mrow1.find("td").eq(8).html();
                        $("#MainContent_gvDCTOS tr:nth-child(" + (myRow + 1) + ") td:nth-child(8)").html(id);
                        $("#MainContent_gvDCTOS tr:nth-child(" + (myRow + 1) + ") td:nth-child(9)").html("0.00");
                        iniciaSP();
                        VA['MOOR'] = 0;//SALDO ORIGINAL - ITEM DESELECCIONA
                    }
                } else {
                    (valida ? alert('Debe completar los datos') : "");
                    alert('No ha seleccionado un tipo cambio valido');
                    $(".validaunoporuno").attr("checked", false);
                }
            });
            //APERTURA DE LA CANTIDAD DE LA SELECCIÓN : MONTO INDICADO (SELECCION) ->DIFERENCIA A SALDO
            $(".open_row").live("click", function () {
                var mrow2 = $(this).parent().parent();
                var saldop = mrow2.find("td").eq(7).html();
                var seleccion = mrow2.find("td").eq(8).html();
                Operacion.iValida('txtMAP', 1);
                if ($('.validaunoporuno').is(':checked') == true && Number(seleccion) > 0) {
                    Operacion.inputRead('txtMAP', 0);
                    var documento = mrow2.find("td").eq(2).html();
                    var moneda = mrow2.find("td").eq(5).html();
                    Operacion.mask('txtDOXP').val(documento);
                    Operacion.mask('txtMOP').val(moneda);
                    Operacion.mask('txtMAP').val(seleccion);
                    VA['MOBA'] = Number(seleccion); //MONTO BASE;
                    VA['MOOR'] = Number(Number(seleccion) + Number(saldop)).toFixed(2);// MONTO ORIGINAL;
                } else {
                    alert('El saldo no se puede editar, es menos a 0');
                }
            });
            //MODIFICA MONTO A CANTIDAD - INDICADA
            Operacion.mask('txtMAP').keypress(function (e) {
                if (e.which == 13) {
                    if (Number($(this).val()) > Number(VA['MOOR'])) {
                        alert('El monto ingresado es mayor al saldo ' + Number(VA['MOOR']));
                    } else {
                        var Vi = VA['MOBA'], Vm = $(this).val(), Vf = (Vm == VA['MOOR'] ? 0.00 : Number(Vi - Vm).toFixed(2));
                        $("#MainContent_gvDCTOS tr:nth-child(" + (myRow + 1) + ") td:nth-child(8)").html(Number(Vf).toFixed(2));//SALDO
                        $("#MainContent_gvDCTOS tr:nth-child(" + (myRow + 1) + ") td:nth-child(9)").html(Number(Vm).toFixed(2));//PAGAR
                        iniciaSP();
                        Operacion.mask('txtDOXP').val("");
                        Operacion.mask('txtMOP').val("");
                        Operacion.mask('txtMAP').val("");
                        Operacion.inputRead('txtMAP', 1);
                    }
                }
            });
            Operacion.mask('btnFinalizar').click(function () {
                //ddlArea <-aqui debe ser
                MASIENTO = []; DCUENTAS = [];
                monto_seleccionado();
                $("span.ui-dialog-title").text('Cancelación de documentos');
            });
            Operacion.mask('btnDcom').click(function () {
                $("span.ui-dialog-title").text('Cancelación de Documentos');
                $('#forpag').hide();
                $('#mis_pagos').hide();
                $('.cont_comp').show();
                $('.cont_sel').hide();
                $('.pie_dctos').hide();
                Operacion.inputEstado('btnFpa', 1, true);
            });
            Operacion.mask('btnDoc').click(function () {
                $("span.ui-dialog-title").text('Selección de documentos');
                $('.cont_comp').hide();
                $('#mis_pagos').show();
                $('.pie_dctos').show();//3
                $('.cont_sel').hide();
                Operacion.inputRead('txtMAP', 1);
                Operacion.inputEstado('btnFpa', 1, true);
            });
            Operacion.mask('btnFpa').click(function () {
                $("span.ui-dialog-title").text('Forma de Pago');
                $('.cont_sel').hide();
                Operacion.inputEstado('btnDoc', 1, true);
                $('#forpag').show();
                Operacion.mask('lblM1').text((VA['MON'] == "MN" ? "S/." : "US$"));
                Operacion.mask('lblM2').text((VA['MON'] == "MN" ? "S/." : "US$"));
                Operacion.mask('lblM3').text((VA['MON'] == "MN" ? "S/. _" : "US$"));
                Operacion.mask('lblM4').text((VA['MON'] == "MN" ? "S/. _" : "US$"));
                Operacion.mask('lblM5').text((VA['MON'] == "MN" ? "S/." : "US$"));
                var MONTO = Operacion.mask('txtDSEL').val();
                var RETEN = Operacion.mask('txtIRET').val();
                var OPERA = Number(MONTO - RETEN).toFixed(2);
                var AREA = Operacion.mask('ddlArea option:selected').text();
                var NOMAGI = Operacion.mask('txtACR1').val();
                Operacion.mask('txtMADIC').val("0.00");
                Operacion.mask('txtLGEN').val("0.00");
                //Operacion.mask('lblFPAG').val();DATOS PROVEEDOR
                Operacion.mask('txtMSEL').val(MONTO);
                Operacion.mask('txtIMRE').val(RETEN);
                Operacion.mask('txtTACU').val(OPERA);
                Operacion.mask('lblAREA').text(AREA);
                Operacion.mask('txtNGIR').val(NOMAGI);
                Operacion.mask('txtCPAG').val((VA['AREA'] == "E04" ? "CANC. DE :" + VA['CONCEPTO'] : "CANC. DE:"));
                Operacion.mask('txtCPAG').focus();
                Operacion.inputEstado('btnConfirma', 0, true);
            });
            Operacion.mask('btnConfirma').click(function () {
                Operacion.inputEstado('btnConfirma', 1, true);
                //if ($(this).val() != "") {
                if (confirm('¿Es correcta la información?')) {
                    registro_pago();
                    /*if (confirm('Comprobante, Finalizado.\n¿Desea imprimr el Voucher?')) {
                        //open...
                    } else {
                        //NO IMPRIMIR
                    }*/
                } else {
                    //NO ES CORRECTA
                }
                //} else {
                //    alert('No ha completado la glosa de concepto');
                //}
            });
        });
    </script>
    <style type="text/css">
        #MainContent_gvpersonas a {
            padding: 2px;
            border: 1px solid #ccc;
        }

        .mi_button {
            padding: 6px;
            border-radius: 3px;
            /*border:1px solid #d3d3d3;*/
        }

            .mi_button a:hover {
                border: 1px solid #d3d3d3;
            }

        .mi_centro {
            text-align: center;
        }

        .mi_derecha {
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="tabs">
        <ul>
            <li><a href="#tabs-1">Documentos por Persona</a></li>
            <li><a href="#tabs-2">1</a></li>
            <li><a href="#tabs-3">2</a></li>
        </ul>
        <div id="tabs-1">
            <fieldset style="float: left; width: 1150px;">
                <legend>Listado Personas</legend>
                <table>
                    <tr>
                        <td colspan="3">&nbsp;</td>
                    </tr>
                    <tr>
                        <td>Criterio</td>
                        <td>
                            <asp:TextBox ID="txtidpro" placeholder="[RUC]" runat="server" Width="100"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtprove" placeholder="[NOMBRE PROVEEDOR]" runat="server" Width="300"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </fieldset>
            <table>
                <tr>
                    <td colspan="7">
                        <!--PageSize="10" AllowPaging="true"-->
                        <asp:GridView ID="gvpersonas" class="tablesorter" runat="server" OnRowCreated="gvpersonas_RowCreated" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" Width="1200px">
                            <Columns>
                                <asp:BoundField DataField="CP_CVANEXO" HeaderText="ANEXO">
                                    <HeaderStyle Width="10px" />
                                    <ItemStyle Font-Size="8pt" />
                                    <ItemStyle CssClass="oc"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="CP_CCODIGO" HeaderText="CODIGO">
                                    <HeaderStyle Width="10px" HorizontalAlign="Left" />
                                    <ItemStyle Font-Size="8pt" />
                                    <ItemStyle CssClass="codigo"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="NOMTIT" HeaderText="NOMBRE">
                                    <HeaderStyle Width="350px" HorizontalAlign="Left" />
                                    <FooterStyle ForeColor="Black" />
                                    <ItemStyle CssClass="descripcion" Width="50px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="CP_CTIPO" HeaderText="TIPO" ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle Width="20px" />

                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="CP_CDESCRI" HeaderText="DIRECCION" ItemStyle-HorizontalAlign="Left">
                                    <HeaderStyle Width="300px" HorizontalAlign="Left" />

                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="IMPORTE" HeaderText="TOTALES" ItemStyle-HorizontalAlign="Right">
                                    <HeaderStyle Width="10px" />

                                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="VER">
                                    <ItemTemplate>
                                        <div class="btaper" style="text-align: center">
                                            <img alt="" src="../../../Images/historial.png" width="25" style="cursor: pointer" />
                                            <%--<asp:ImageButton ID="imbeliminar" runat="server" ImageUrl="~/Images/Message_Error.png" Width="25px" OnClick="ib_eliminar_Click" onclientclick="javascript:return confirm('Esta Seguro?')"/>--%>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" Height="28" />
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
            <table style="background-color: #f1f1f1; height: 30px" border="0">
                <tr>
                    <td><b>TOTAL REGISTROS:</b> </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtreg" Width="100" Enabled="false" Style="text-align: center" />
                    </td>
                    <td><b>SUMA SOLES:</b></td>
                    <td>
                        <asp:TextBox runat="server" ID="txtsumamn" Width="100" Enabled="false" Style="text-align: right" />
                    </td>
                    <td><b>SUMA DOLARES:</b></td>
                    <td>
                        <asp:TextBox runat="server" ID="txtsumaus" Width="100" Enabled="false" Style="text-align: right" />
                    </td>
                </tr>
            </table>
            <!--cancela documentos-->
            <div id="dvcandoc" title="Cancelación de documentos" style="">

                <table>
                    <tr>
                        <td>Acreedor</td>
                        <td>
                            <asp:TextBox ID="txtACR0" runat="server" ReadOnly="true"></asp:TextBox>
                            <asp:TextBox ID="txtACR1" runat="server" AutoPostBack="false" Width="408px" ReadOnly="true"></asp:TextBox>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <input id="rb1" type="radio" name="rb" value="C" checked="checked" />Codigo
                                <input id="rb2" type="radio" name="rb" value="D" />Descripción</td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>Cuenta Bancaria</td>
                        <td>
                            <asp:TextBox ID="txtNCU" placeholder="[NRO. CUENTA]" runat="server" class="ac_bancos" Width="368px"></asp:TextBox>&nbsp;Moneda
                            <asp:Label ID="lblMON" runat="server" BorderStyle="Solid" BorderWidth="1px"></asp:Label>
                            <asp:HiddenField ID="hfBAN" runat="server" />
                        </td>
                        <td>
                            <asp:HiddenField ID="hfIDC" runat="server" />
                            <asp:HiddenField ID="hfIDB" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Label ID="lblBANCO" runat="server"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>

                <fieldset class="cont_comp">
                    <legend>Datos del comprobante</legend>
                    <table>
                        <tr>
                            <td>Fecha Comprobante</td>
                            <td>
                                <asp:TextBox ID="txtFCOM" class="dp_1" runat="server"></asp:TextBox></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>Tipo Cambio</td>
                            <td>
                                <asp:TextBox ID="txtTICA" ReadOnly="true" runat="server" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                <input id="rb3" type="radio" name="rb_1" value="M" />Compra
                                <input id="rb4" type="radio" name="rb_1" value="V" checked="true" />Venta
                                <input id="rb5" type="radio" name="rb_1" value="C" />
                                C.Esp
                            </td>
                            <td>
                            &nbsp;
                        </tr>
                        <tr>
                            <td>Area</td>
                            <td>
                                <asp:DropDownList ID="ddlArea" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>Tipo Pago</td>
                            <td>
                                <asp:DropDownList ID="ddlTIPA" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>Subdiario&nbsp;</td>
                            <td>
                                <asp:DropDownList ID="ddlSUB" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>Fecha Deposito CITB&nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtCITB" class="dp_2" runat="server"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </fieldset>
                <table>
                    <tr>
                        <td colspan="6">
                            <asp:Button ID="btnDcom" runat="server" Text="Datos Comprobante" />|<asp:Button ID="btnDoc" runat="server" Text="Documentos" />|<asp:Button ID="btnMad" runat="server" Text="Mov. Adicionales" />|<asp:Button ID="btnFpa" runat="server" Text="Forma de Pago" /></td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <div id="mis_pagos" style="overflow: auto; width: 850px; height: 200px">
                                <asp:GridView ID="gvDCTOS" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" Width="782px" Font-Size="Smaller">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <%--<input id="Checkbox2" type="checkbox" value="1" name="tod" class="marcar" />--%>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <input type="checkbox" value="1" name="opt" class="validaunoporuno" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="CP_CTIPDOC" HeaderText="TD.">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CP_CNUMDOC" HeaderText="NUM.DOC.">
                                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CP_DFECDOC" HeaderText="FEC. DOC.">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CP_DFECVEN" HeaderText="FEC. VEN." DataFormatString="{0:F2}">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CP_CCODMON" HeaderText="MONEDA" DataFormatString="{0:F2}">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="IMPORTE"></asp:BoundField>
                                        <asp:BoundField HeaderText="SALDO" DataFormatString="{0:F2}">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>

                                        <asp:BoundField HeaderText="SELECCION">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="EST. RET." DataField="CP_CRETE">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="% RET.">

                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="PORDET" HeaderText="%DET">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CP_CCUENTA" HeaderText="CUENTA" />
                                        <asp:BoundField DataField="CP_CCOMPRO" HeaderText="REFPRO" />
                                        <asp:BoundField DataField="CP_NTIPCAM" HeaderText="TCAMBIO" />
                                        <asp:TemplateField HeaderText="VER">
                                            <ItemTemplate>
                                                <div class="btopen" style="text-align: center">
                                                    <img alt="" src="../../../Images/open_row.png" width="21" style="cursor: pointer" />
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
                    <tr class="pie_dctos">
                        <td>N°Dctos</td>
                        <td>
                            <asp:TextBox ID="txtNDOC" ReadOnly="true" runat="server"></asp:TextBox></td>
                        <td>Pagos MN</td>
                        <td>
                            <asp:TextBox ID="txtPMN" class="mi_centro" runat="server"></asp:TextBox></td>
                        <td>Pagos US</td>
                        <td>
                            <asp:TextBox ID="txtPUS" class="mi_centro" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr class="pie_dctos">
                        <td>Documento</td>
                        <td>
                            <asp:TextBox ID="txtDOXP" ReadOnly="true" runat="server"></asp:TextBox>
                        </td>
                        <td>Moneda</td>
                        <td>
                            <asp:TextBox ID="txtMOP" ReadOnly="true" runat="server"></asp:TextBox>
                        </td>
                        <td>Monto</td>
                        <td>
                            <asp:TextBox ID="txtMAP" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr class="pie_dctos">
                        <td>
                            <asp:Button ID="btnFinalizar" class="mi_button" runat="server" Text="[Finalizar]" />
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
                <fieldset class="cont_sel">
                    <legend>Montos Seleccionados</legend>
                    <table>
                        <tr>
                            <td>Documentos&nbsp;</td>
                            <td>Mov. Adicionales</td>
                            <td>Importe Retenido</td>
                            <td>Monto del Pago</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtDSEL" class="mi_derecha" ReadOnly="true" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtMADI" class="mi_derecha" runat="server" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtIRET" class="mi_derecha" runat="server" ReadOnly="True" BorderColor="#3399FF"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMPAG" class="mi_derecha" runat="server" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td></td>
                        </tr>
                    </table>
                </fieldset>
                <table id="forpag">
                    <tr>
                        <td>Monto Seleccionado</td>
                        <td>
                            <asp:Label ID="lblM1" runat="server" Text=""></asp:Label>
                            &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtMSEL" class="mi_derecha" runat="server" ReadOnly="true"></asp:TextBox></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>Mov.Adicional</td>
                        <td>
                            <asp:Label ID="lblM2" runat="server" Text=""></asp:Label>
                            &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtMADIC" class="mi_derecha" runat="server" ReadOnly="true"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>Letras Generadas&nbsp;</td>
                        <td>
                            <asp:Label ID="lblM3" runat="server" Text=""></asp:Label>
                            <asp:TextBox ID="txtLGEN" class="mi_derecha" runat="server" ReadOnly="true"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>Importe Retenido&nbsp;</td>
                        <td>
                            <asp:Label ID="lblM4" runat="server" Text=""></asp:Label>
                            <asp:TextBox ID="txtIMRE" class="mi_derecha" runat="server" ReadOnly="true"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>Total Acumulado</td>
                        <td>
                            <asp:Label ID="lblM5" runat="server" Text=""></asp:Label>
                            &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtTACU" class="mi_derecha" runat="server" ReadOnly="true"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>Area</td>
                        <td>
                            <asp:Label ID="lblAREA" runat="server" Text=""></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>Nombre a girar</td>
                        <td>
                            <asp:TextBox ID="txtNGIR" runat="server" Width="275px"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>Concepto</td>
                        <td>
                            <asp:TextBox ID="txtCPAG" Text="CANC. DE :" runat="server" Width="274px"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>Forma de Pago</td>
                        <td>
                            <asp:Label ID="lblFPAG" runat="server" Text=""></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btnConfirma" runat="server" Text="Confirmación de Proceso" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
                <div id="DCO" title="Detalle del Comprobante" style="display: none;">
                    <table>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Label ID="lblMONEDA1" runat="server" Text=""></asp:Label>
                            </td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Label ID="lblMONEDA2" runat="server" Text=""></asp:Label>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>Sub Comprobante</td>
                            <td>
                                <asp:TextBox ID="txtDC_SU" runat="server" Width="42px" ReadOnly="true"></asp:TextBox>
                                <asp:TextBox ID="txtDC_CU" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td>Debe</td>
                            <td>
                                <asp:TextBox ID="txtDC_DE" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td>Debe</td>
                            <td>
                                <asp:TextBox ID="txtDC_DE0" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Moneda</td>
                            <td>
                                <asp:TextBox ID="txtDC_MO" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td>Haber</td>
                            <td>
                                <asp:TextBox ID="txtDC_HA" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td>Haber</td>
                            <td>
                                <asp:TextBox ID="txtDC_HA0" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Fecha</td>
                            <td>
                                <asp:TextBox ID="txtDC_FD" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td>Diferencia</td>
                            <td>
                                <asp:TextBox ID="txtDC_DI" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td>Diferencia</td>
                            <td>
                                <asp:TextBox ID="txtDC_DI0" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <div style="display: none;">
                                    <input id="hfPRO" runat="server" type="hidden" />
                                </div>
                                <div id="mi_tabla">
                                    <asp:GridView ID="gvDCOM" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False">
                                        <Columns>
                                            <asp:BoundField DataField="DSECUE" HeaderText="Sec." ItemStyle-HorizontalAlign="Center">
                                                <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                                <ItemStyle Font-Size="8pt" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DCUENTA" HeaderText="Cuenta" ItemStyle-HorizontalAlign="Left">
                                                <HeaderStyle Font-Size="8pt" HorizontalAlign="Left" Width="100" />
                                                <ItemStyle Font-Size="8pt" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DDETALLE" HeaderText="Detalle" ItemStyle-HorizontalAlign="Left">
                                                <HeaderStyle Font-Size="8pt" HorizontalAlign="Left" Width="100" />
                                                <ItemStyle Font-Size="8pt" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DCODANE" HeaderText="Anexo" ItemStyle-HorizontalAlign="Left">
                                                <HeaderStyle Font-Size="8pt" HorizontalAlign="Left" Width="100" />
                                                <ItemStyle Font-Size="8pt" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DCENCOS" HeaderText="Cos." ItemStyle-HorizontalAlign="Center">
                                                <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                                <ItemStyle Font-Size="8pt" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DDH" HeaderText="F" ItemStyle-HorizontalAlign="Right">
                                                <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                                <ItemStyle Font-Size="8pt" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DIMPORT" HeaderText="Importe" ItemStyle-HorizontalAlign="Right">
                                                <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                                <ItemStyle Font-Size="8pt" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DTIPDOC" HeaderText="TP" ItemStyle-HorizontalAlign="Right">
                                                <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                                <ItemStyle Font-Size="8pt" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DNUMDOC" HeaderText="Docmto" ItemStyle-HorizontalAlign="Center">
                                                <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                                <ItemStyle Font-Size="8pt" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DFECDOC2" HeaderText="Fec. Doc." ItemStyle-HorizontalAlign="Center">
                                                <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                                <ItemStyle Font-Size="8pt" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DFECVEN2" HeaderText="Fec. Ven." ItemStyle-HorizontalAlign="Center">
                                                <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                                <ItemStyle Font-Size="8pt" />
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
                        <tr>
                            <td>&nbsp;</td>
                            <td colspan="2">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td colspan="2">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </div>
            </div>
            <div id="EstadoPedido" style="display: none;">
                <table>

                    <tr>
                        <td>
                            <asp:Label ID="lblcabnumero" runat="server" Text="Artículo:" Font-Bold="True"></asp:Label>
                            <asp:Label ID="lblnumero" runat="server"></asp:Label>
                            <br />
                            <asp:GridView ID="gvdetallereq" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="False" Font-Size="8pt">
                                <Columns>
                                    <asp:BoundField DataField="OC_CCODPRO" HeaderText="RUC" HeaderStyle-HorizontalAlign="Left">
                                        <FooterStyle HorizontalAlign="Right" />

                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>

                                        <ItemStyle Width="30px" HorizontalAlign="Right" VerticalAlign="Top"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OC_CRAZSOC" HeaderText="PROVEEDOR" HeaderStyle-HorizontalAlign="Left">
                                        <FooterStyle HorizontalAlign="Right" />

                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>

                                        <ItemStyle Width="250px" HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OC_CNUMORD" HeaderText="NRO O.C" HeaderStyle-HorizontalAlign="Left">

                                        <FooterStyle HorizontalAlign="Right" />

                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>

                                        <ItemStyle Width="8px" HorizontalAlign="Right" VerticalAlign="Top"></ItemStyle>
                                    </asp:BoundField>


                                    <asp:BoundField DataField="OC_DFECDOC" HeaderText="FECHA" HeaderStyle-HorizontalAlign="Left">
                                        <FooterStyle HorizontalAlign="Right" />

                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>

                                        <ItemStyle Width="20px" HorizontalAlign="Right" VerticalAlign="Top"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OC_CCODMON" HeaderText="MONEDA" HeaderStyle-HorizontalAlign="Left">
                                        <FooterStyle HorizontalAlign="Right" />

                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>

                                        <ItemStyle Width="30px" HorizontalAlign="Right" VerticalAlign="Top"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OC_NPREUN2" HeaderText="PRECIO" HeaderStyle-HorizontalAlign="Left">
                                        <FooterStyle HorizontalAlign="Right" />

                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>

                                        <ItemStyle Width="8px" HorizontalAlign="Right" VerticalAlign="Top"></ItemStyle>
                                    </asp:BoundField>


                                </Columns>
                                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                <RowStyle ForeColor="#003399" BackColor="White" />
                                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                <SortedDescendingHeaderStyle BackColor="#002876" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div id="tabs-2">
            <table>
                <tr>
                    <td>Fecha Inicio</td>
                    <td>
                        <asp:TextBox ID="txtOCF1" class="dpoc1" runat="server"></asp:TextBox></td>
                    <td>Fecha Final</td>
                    <td>
                        <asp:TextBox ID="txtOCF2" class="dpoc2" runat="server"></asp:TextBox></td>
                    <td rowspan="2">
                        <input id="btnOC" type="button" class="btn" value="Buscar" />
                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td>OC</td>
                    <td>
                        <asp:TextBox ID="txtOCC" runat="server"></asp:TextBox></td>
                    <td>Proveedor</td>
                    <td>
                        <asp:TextBox ID="txtOCP" runat="server"></asp:TextBox></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td>Usuario&nbsp;</td>
                    <td>
                        <asp:DropDownList ID="ddlUSER" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
            </table>
            <div id="migrilla">
                <asp:GridView ID="gvDOC" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" Width="100%" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                    <Columns>
                        <asp:BoundField DataField="CP_CTDOCRE" HeaderText="TDR" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="3%" />
                            <ItemStyle Font-Size="8pt" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CP_CNDOCRE" HeaderText="Num. Doc Ref." ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="30" />
                            <ItemStyle Font-Size="8pt" Width="7%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CP_CVANEXO" HeaderText="Agencia" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="50" />
                            <ItemStyle Font-Size="8pt" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CP_CCODIGO" HeaderText="Codigo" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="7%" />
                            <ItemStyle Font-Size="8pt" Width="7%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NOMTIT" HeaderText="Nombre" ItemStyle-HorizontalAlign="Left">
                            <HeaderStyle Font-Size="8pt" HorizontalAlign="Left" Width="14%" Wrap="False" />
                            <ItemStyle Font-Size="8pt" Width="110px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CP_CTIPDOC" HeaderText="T.Doc" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="3%" />
                            <ItemStyle Font-Size="8pt" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CP_CNUMDOC" HeaderText="Num. Dcto" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="20px" />
                            <ItemStyle Font-Size="8pt" Width="20px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CP_CCODMON" HeaderText="Moneda" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="5%" />
                            <ItemStyle Font-Size="8pt" />
                        </asp:BoundField>
                        <asp:BoundField DataField="IMPORTE" HeaderText="Importe" ItemStyle-HorizontalAlign="right">
                            <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="6%" />
                            <ItemStyle Font-Size="8pt" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CP_DFDOCRE" HeaderText="Fecha Registro" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="6%" />
                            <ItemStyle Font-Size="8pt" Width="10" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CENCOR" HeaderText="Centro Costo Ref" ItemStyle-HorizontalAlign="Left">
                            <HeaderStyle Font-Size="8pt" HorizontalAlign="Left" Width="110" />
                            <ItemStyle Font-Size="8pt" Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NOMARE" HeaderText="Dpto" ItemStyle-HorizontalAlign="Left">
                            <HeaderStyle Font-Size="8pt" HorizontalAlign="Left" Width="40" />
                            <ItemStyle Font-Size="8pt" Width="8%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CP_CUSER" HeaderText="Usuario" ItemStyle-HorizontalAlign="Left">
                            <HeaderStyle Font-Size="8pt" HorizontalAlign="Left" Width="10" />
                            <ItemStyle Font-Size="8pt" Width="8%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CP_CSITUAC" HeaderText="Situacion" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="5%" />
                            <ItemStyle Font-Size="8pt" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="">
                            <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="5%" />
                            <ItemTemplate>
                                <div class="btDetalle" style="text-align: center; display: inline;">
                                    <img alt="" src="../../Images/historial.png" width="25" style="cursor: pointer" />
                                    <%--<asp:ImageButton ID="imbeliminar" runat="server" ImageUrl="~/Images/Message_Error.png" Width="25px" OnClick="ib_eliminar_Click" onclientclick="javascript:return confirm('Esta Seguro?')"/>--%>
                                </div>
                                <div class="btPrinter" style="text-align: center; display: inline;">
                                    <img alt="" src="../../Images/Printer.png" width="25" style="cursor: pointer" />
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
            </div>
        </div>
        <div id="tabs-3">
            <p>Ordenes contabilizadas con factura</p>
            <asp:GridView ID="gvRESUMEN" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                <Columns>
                    <asp:BoundField DataField="CP_CUSER" HeaderText="Usuario" />
                    <asp:BoundField DataField="CP_CAREA" HeaderText="Tipo Ordenes" />
                    <asp:BoundField DataField="CP_CSUBDIA" HeaderText="Subdiario">
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CP_NIMP2MN" HeaderText="Cantidad">
                        <HeaderStyle HorizontalAlign="Center" />
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
    </div>


</asp:Content>
