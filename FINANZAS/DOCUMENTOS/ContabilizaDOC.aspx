﻿<%@ Page Title="Contabilizacion con Orden Compra" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ContabilizaDOC.aspx.cs" Inherits="ContabilizaDOC" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link type="text/css" href="../../CSS/base.css" rel="stylesheet" />
    <link href="../../jquery/miniTip.min.css" rel="stylesheet" />
    <script src="../../jquery/jquery.miniTip.min.js"></script>
    <script type="text/javascript">
        $(function () {
            UHTML.id = 'MainContent';
            M_PAR = [], IDX = [], COMP = "", CORPAG = "", C_DET = "";
            M_DATA = [], DCUENTAS = [], RDCTA = [], MI_DETALLE = [];
            M_AUX = [], DMONTO = [], MONTO = [], DC_COD = [];//PARTE ENTRADA//MONTO-CUENTA
            var ATP = [], AT = [], AD = [], CTOK = [];//SUBTOTAL
            var EX = ['txtBNPE', 'txtDOC', 'txtFDOC', 'ddlTCON', 'txtFCOM', 'ddlCOC', 'ddlSUB'];// 'txtNDR'
            $(".dp1").datepicker();
            $(".dp2").datepicker();
            $(".dp3").datepicker();
            $('.tr_oculta').hide();
            $('.tr_oculta1').hide();
            $('.tr_oculta2').hide();
            $('.tr_oculta4').hide();
            var dialog, dialog1, dialog2, dialog3;
            var M_DIAS = "";
            var CODATA = {};

            //CONFIGURACIONES
            //$(document).tooltip();
            Operacion.inputVisible('txtSITU', '1');
            Operacion.inputVisible('lblSIT', '1');
            Operacion.inputVisible('txtFCRE', '1');
            Operacion.inputVisible('lblFCRE', '1');
            Operacion.inputVisible('txtFVB', '1');
            Operacion.inputVisible('lblFVB', '1');
            Operacion.inputVisible('ddlTCON', '1');
            Operacion.inputVisible('lblTCON', '1');
            Operacion.inputVisible('lblFCAM', '1');
            Operacion.inputVisible('txtFCAM', '1');

            //CAPTURAR VALOR 
            $.urlParam = function (name) {
                var results = new RegExp('[\?&]' + name + '=([^&#]*)').exec(window.location.href);
                return (results != null ? results[1] || 0 : "");
            }

            var ID = $.urlParam('ID');

            //TOOLTIP
            var iniciaTooltip = function () {
                $('.tip').miniTip();
            }

            //BLOQUEO FECHA CONTABLE
            var bloqueoFE = function (FC) {
                var NFC = FC.split("/");
                NFC = NFC[1];

                var DATA = {
                    TMES: NFC,
                    TTIPCONS: "D"
                };
                //console.log(DATA);
                $.ajax({
                    url: "../../ALMACEN/LiquidacionCompra.aspx/listarBC",
                    data: '{DATA:' + JSON.stringify(DATA) + '}',
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        //console.log(data);
                        if (data.d != null) {
                            if (data.d.TTIPCONS == "D") {
                                alert('Mes de comprobante cerrado');
                                Operacion.mask('txtFCOM').val('');
                                Operacion.mask('txtFCOM').focus();
                            } else {
                                Operacion.mask('txtDOC').focus();
                            }
                        } else {
                            Operacion.mask('txtDOC').focus();
                        }
                    },
                    error: function (data) {
                        console.log(data);
                    }
                });
            }
            //SUBTOTAL VALOR DECLARADO-CALCULADO
            var misubtotal = function (VAL1, VAL2) {
                var M_CALCULO = VAL1;//Operacion.mask('txtIGV').val();
                var M_TOTAL = VAL2;
                var M_FINAL = (((Number(M_PAR[1]) + 100) * Number(VAL1)) / Number(M_PAR[1])) / (Number(M_PAR[1] / 100) + 1);//((M_CALCULO * 100) / 18);
                var M_CC = (VAL2 - VAL1);//IMPORTE TOTAL-IGV

                Operacion.mask('txtVCDE').val(Number(Operacion.mround(M_CC, 2)).toFixed(2));//M_OPER1 -M_VCD.toFixed(2)                                
                Operacion.mask('txtVCCA').val(Operacion.mround(M_FINAL, 2));//SISTEMA

                //var M_INAF = Number(M_FINAL) - Number(M_CC);
                Operacion.mask('txtINAF').val(Number(Operacion.mask('txtVCCA').val() - Operacion.mask('txtVCDE').val()).toFixed(2));
            }
            //GLOSA ASIGNADA DEACUERDO A PE
            var miglosadet = function (IDX) {
                var LEN1 = IDX.length;
                C_DET = "";
                for (i = 0; i < LEN1; i++) {
                    C_DET += parseInt(IDX[i]) + (LEN1 > 1 ? "," : "");
                }
                //console.log(C_DET.length);
            }
            //DIBUJAR TABLA
            var dibujaTabla = function (NAME, ROW, ID, DATA, CSUM, CSS) {
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
                    var sa = ";width:24%;text-align:center", sa1 = ";width:7%", sa2 = ";width:12%", sa3 = ";width:9%";
                    a_table.append($('<th scope="col" style=text-align:left' + (j == 2 ? sa : (j == 1 ? sa1 : (j == 8 ? sa2 : (j == 9 ? sa3 : "")))) + ' >' + CAB[j] + '</th>'))
                }
                table = table.append(a_table);
                //console.log(typeof DATA);
                if (DATA != "") {
                    for (k = 0; k < ROW.length; k++) {
                        var a_table1 = ($('<tr style=color:#000066;></tr>'));
                        for (var j = 0; j < CAB.length; j++) {
                            a_table1.append($('<td>' + DATA[ROW[k]][j] + '</td>'))
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
            //PARAMETROS VARIOS
            var iniciaPAVA = function () {
                var DATA = {};
                DATA.TCOD = '53';
                var PAR = ['IGV', 'TIGV'];

                $.ajax({
                    type: "POST",
                    url: "ContabilizaDOC.aspx/ListarTGLA",
                    data: '{DATA:' + JSON.stringify(DATA) + ',PAR:' + JSON.stringify(PAR) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        $.each(data.d, function (i, v) {
                            var M_CUENTA = v.TDESCRI;
                            M_CUENTA = M_CUENTA.split(" ");
                            M_PAR[i] = (i == 0 ? M_CUENTA[0] : v.TDESCRI);
                        });
                    },
                    error: function (response) {
                        console.log(response);
                    }
                });
                //console.log(M_PAR);
            }
            iniciaPAVA();
            //VALIDA CAMPOS REQUERIDOS
            var valida = function () {
                //console.log(M_PAR[3]);
                if (M_PAR[3] == "0") {
                    return Operacion.iVALC(['txtNDR', 'txtDOC', 'txtFCOM',
                                        'txtFDOC', 'txtVTIC', 'txtIMP', 'txtFVEN-', 'txtGCOM',
                                        'txtGMOV']);
                } else {
                    return Operacion.iVALC(['txtNDR', 'txtDOC', 'txtFCOM',
                                        'txtFDOC', 'txtVTIC', 'txtGCOM',
                                        'txtGMOV', 'txtTTAS', 'txtTDES', 'txtNDET']);
                }
            }
            //VERIFICA DEBE O HABER
            var verificaDH = function (SUB, CTA) {
                //console.log(CTA);
                var CTA1 = CTA.substring(0, 2);
                var DATA = {
                    AF_COD: SUB,
                    AF_CCLAVE: (M_PAR[7] != "S" ? "OC" + CTA1 + "" + SUB : "OS" + CTA1 + "" + SUB),
                    AF_TDESCRI1: CTA1
                }
                //AF_TDESCRI1: ""
                //console.log(DATA);
                $.ajax({
                    type: "POST",
                    url: "ContabilizaDOC.aspx/ListarParametroID",
                    data: '{DATA:' + JSON.stringify(DATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {

                        try {
                            if (data.d != null) {
                                RDCTA[CTA][9] = data.d.AF_TDESCRI2;
                                RDCTA[CTA][10] = data.d.AF_TDESCRI3;//CODARC
                            } else {
                                alert('Verificar metodo verificaDH');
                            }
                        } catch (ex) {
                            alert(JSON.parse(ex));
                        }
                    },
                    error: function (response) {
                        console.log(response);
                    }
                });
            }
            //CUENTAS ANEXOS
            var obtenerCA = function (CTA, CANT) {
                var PDATA = {};
                PDATA.PCUENTA = CTA;//MPCLC:602101-MPCFA:602102
                $.ajax({
                    url: "../../ALMACEN/LiquidacionCompra.aspx/ListaPlanC",
                    data: '{PDATA:' + JSON.stringify(PDATA) + '}',
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    async: false,
                    success: function (data) {
                        var M_A = data.d[0]['PCTACAR'].trim();
                        var M_O = data.d[0]['PCTAABO'].trim();
                        try {
                            if (data.d != null) {
                                if (M_A != "" && M_O != "") {
                                    DCUENTAS.push(data.d[0]['PCTACAR'].trim());
                                    DCUENTAS.push(data.d[0]['PCTAABO'].trim());
                                    (M_PAR[7] == "S" ? A_DCUENTAS.push(data.d[0]['PCTACAR'].trim()) : "");
                                    (M_PAR[7] == "S" ? A_DCUENTAS.push(data.d[0]['PCTAABO'].trim()) : "");
                                    MONTO.push(CANT);
                                    MONTO.push(CANT);
                                    DC_COD[data.d[0]['PCTACAR'].trim()] = CTA;
                                    DC_COD[data.d[0]['PCTAABO'].trim()] = CTA;
                                } else {
                                    alert('Verificar que la cuenta' + CTA + ' tenga cta. cargo y abono');
                                }
                                //DC_COD = (RDCTA[CTA][10] == data.d[0]['PCTACAR'].trim() || RDCTA[CTA][11] ==data.d[0]['PCTAABO'].trim() ? CTA : "");
                            }
                        } catch (ex) {
                            alert(ex);
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        //  alert(textStatus);
                    }
                });
            }
            //OBTENER CUENTA COMPRA
            var obtenerCCO = function (ID) {
                var DATA = {};
                DATA.C5_CCODMOV = "CO";
                DATA.C5_CCODPRO = Operacion.mask('txtCOD').val().trim();
                DATA.C5_CNUMORD = ID.trim();
                $.ajax({
                    type: "POST",
                    url: "ContabilizaDOC.aspx/listaCCE",
                    data: '{DATA:' + JSON.stringify(DATA) + ',ND:' + JSON.stringify(IDX) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        //console.log(data);
                        $.each(data.d, function (i, v) {
                            //console.log(v.TC_CCOMPRA);
                            DCUENTAS.push(v.TC_CCOMPRA);
                            MONTO.push(v.C6_NCANTID);
                            obtenerCA(v.TC_CCOMPRA, v.C6_NCANTID);
                            //DMONTO.push(v.TC_CCOMPRA);
                            //DMONTO[v.TC_CCOMPRA]=v.C6_NCANTID;
                            //console.log(MI_DETALLE);
                        });
                    },
                    error: function (data) {
                        console.log(data);
                    }
                });
            }
            //OBTENER CUENTA SERVICIO
            var obtenerAOS = function (CADENA, CANTIDAD) {
                //CADENA, CANTIDAD
                $.ajax({
                    type: "POST",
                    url: "ContabilizaDOC.aspx/listaAID",
                    data: "{CADENA:'" + CADENA + "'}",
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        DCUENTAS.push(data.d.AR_CCUENTA.trim());
                        A_DCUENTAS.push(data.d.AR_CCUENTA.trim());
                        MONTO.push(CANTIDAD);
                        obtenerCA(data.d.AR_CCUENTA.trim(), CANTIDAD);
                        //DMONTO.push(v.TC_CCOMPRA);
                        //DMONTO[v.TC_CCOMPRA]=v.C6_NCANTID;
                        //console.log(MI_DETALLE);
                    },
                    error: function (data) {
                        console.log(data);
                    }
                });
            }
            //VERIFICA DOCUMENTO EN CARTERA PAGOS
            var verificaDOC = function (VAL) {
                var NDOC = VAL;
                if (NDOC != "") {
                    var DATA = {};
                    DATA.CP_CVANEXO = Operacion.mask('ddlACR').val();
                    DATA.CP_CCODIGO = Operacion.mask('txtCOD').val().trim();
                    DATA.CP_CTIPDOC = "FT"
                    DATA.CP_CNUMDOC = NDOC;
                    //console.log(DATA)
                    $.ajax({
                        type: "POST",
                        url: "../../ALMACEN/LiquidacionCompra.aspx/obtenerDOC",
                        data: '{DATA:' + JSON.stringify(DATA) + '}',
                        contentType: "application/json;charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (data) {
                            //console.log(data);
                            var M_SUB = Operacion.mask('ddlSUB').val();
                            if (data.d != null && M_SUB != "SUB3") {
                                Operacion.mask('txtDOC').val('');
                                Operacion.mask('txtDOC').focus();
                                Operacion.mask('txtNDET').val('');
                                alert('Documento registrado en cartera de pagos FT ' + DATA.CP_CNUMDOC + '\n Verificar Numero de documento');
                            } else {
                                var M_DESF = Operacion.mask('txtDOC').val();
                                Operacion.mask('txtNDET').val(M_DESF + "-D");
                                Operacion.mask('txtFDOC').focus();
                            }
                        },
                        error: function (response) {
                            alert('El proceso no se pudo completar verificaDOC');
                            console.table(response);
                        }
                    });
                }
            }
            //PARTES ENTRADA DE LA OC
            var iniciaPEOC = function () {

                var DATA = {};
                DATA.C5_CCODPRO = Operacion.mask('txtCOD').val();//C:Operacion.mask('txtCOD').val();
                DATA.C5_CNUMORD = Operacion.mask('txtNDR').val();//C:Operacion.mask('txtPOC_OC').val();

                $.ajax({
                    type: "POST",
                    url: "ContabilizaDOC.aspx/listaPOC",
                    data: '{DATA:' + JSON.stringify(DATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        try {
                            $('#cblPET').empty();
                            var table = $('<table id=MainContent_cblPE class=buscar rules=all cellpadding=3 style=background-color:White;border-color:#CCCCCC;border-width:1px;border-style:None;width:100%;border-collapse:collapse;></table>');
                            table.append($('<tr style=color:White;background-color:#006699;font-weight:bold;></tr>')
                                    .append($('<th style=text-align:left>Almacen</th>'))
                                    .append($('<th style=text-align:left>E/S</th>'))
                                    .append($('<th style=text-align:left>Documento</th>'))
                                    .append($('<th style=text-align:left>Fecha Doc.</th>'))
                                    .append($('<th style=text-align:left>Mov.</th>'))
                                    .append($('<th style=text-align:left>Sub</th>'))
                                    .append($('<th style=text-align:left>Comp</th>'))
                                    .append($('<th style=text-align:left>Glosa</th>'))
                                    .append($('<th style=text-align:left></th>'))
                                    );
                            var counter = 0;

                            if (data.d.length > 0) {
                                Operacion.mask('cblPE').empty();
                                $.each(data.d, function (i, elem) {
                                    table.append($('<tr style=color:#000066;></tr>').append($('<td></td>')
                                         .append($('<input>').attr({
                                             type: 'checkbox', name: 'ctl00$MainContent$cblPE$' + counter, value: elem['C5_CNUMDOC'], id: 'MainContent_cblPE_' + counter, disabled: (elem['C5_CSUBDIA'].trim() != "" ? true : false)
                                         })).append($('<label>').attr({ for: '' + counter++ }).text(elem['C5_CALMA'])))
                                         .append($('<td>' + elem['C5_CTD'] + '</td>'))
                                         .append($('<td class=pe>' + elem['C5_CNUMDOC'] + '</td>'))
                                         .append($('<td>' + elem['C5_DFECDOC'] + '</td>'))
                                         .append($('<td>' + elem['C5_CCODMOV'] + '</td>'))
                                         .append($('<td>' + elem['C5_CSUBDIA'] + '</td>'))
                                         .append($('<td>' + elem['C5_CCOMPRO'] + '</td>'))
                                         .append($('<td>' + elem['C5_CGLOSA1'] + '</td>'))
                                         .append($('<td><div id=' + elem['C5_CNUMDOC'] + ' class=btDetalle style=text-align:center><img title=Detalle  src=../../Images/Detalle.png width=25 style=cursor:pointer;float:left;></div></td>'))
                                         );
                                    M_AUX[elem['C5_CNUMDOC']] = [elem['C5_CALMA'], elem['C5_CTD'], elem['C5_CCODMOV'], moment(elem['C5_DFECDOC'], 'DD/MM/YYYY')];
                                    $('#cblPET').append(table);
                                    cAUX = counter;
                                });

                            } else {
                                Operacion.mask('cblPE').empty();
                                table.append($('<tr></tr>').append($('<td></td>')
                                         .append($('<input>').attr({
                                             type: 'checkbox', name: 'ctl00$MainContent$cblPE$' + counter, value: "", id: 'MainContent_cblPE_' + counter
                                         })).append($('<label>').attr({ for: '' + counter++ }).text("")))
                                         .append($('<td></td>'))
                                         .append($('<td></td>'))
                                         .append($('<td></td>'))
                                         .append($('<td></td>'))
                                         .append($('<td></td>'))
                                         .append($('<td></td>'))
                                         .append($('<td></td>'))
                                         .append($('<td></td>'))
                                         );
                                $('#cblPET').append(table);
                                //$('#cblPE').append(table);
                            }
                        } catch (ex) {
                            alert(JSON.parse(ex));
                        }
                    }, error: function (data) {
                        console.log(data);
                    }
                });
            }
            //INICIA PE DETALLE
            var iniciaPEDE = function (ID) {
                var ND = [];
                ND.push(ID);
                $('.gvd').empty();
                //Operacion.mask('gvDetalle').empty();
                var DATA = {};
                DATA.C5_CALMA = (ID['d'] == 0 ? "" : M_AUX[ID][0]);
                DATA.C5_CTD = "PE";//(ID['d'] == 0 ? "" : M_AUX[ID][1]);
                //DATA.C5_CNUMDOC=APE;
                DATA.C5_CCODMOV = "CO";//(ID['d'] == 0 ? "" : M_AUX[ID][2]);
                DATA.C5_CRFTDOC = "";
                DATA.C5_CCODPRO = Operacion.mask('txtCOD').val().trim();
                DATA.C5_DFECDOC = (ID['d'] == 0 ? "" : M_AUX[ID][3]);
                DATA.C5_DFECMOD = (ID['d'] == 0 ? "" : M_AUX[ID][3]);
                //console.log(DATA);
                $.ajax({
                    type: "POST",
                    url: "ContabilizaDOC.aspx/getDPES",
                    data: '{DATA:' + JSON.stringify(DATA) + ',ND:' + JSON.stringify(ND) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        try {
                            var table = $('<table id=MainContent_gvDetalle cellspacing="0" cellpadding=3 rules=all style=background-color:White;border-color:#CCCCCC;border-width:1px;border-style:None;width:113%;border-collapse:collapse;></table>');
                            table.append($('<tr style=color:White;background-color:#006699;font-weight:bold;></tr>')
                                    .append($('<th scope="col" style=text-align:left>Item</th>'))
                                    .append($('<th scope="col" style=text-align:left>Articulo</th>'))
                                    .append($('<th scope="col" style=text-align:left>Descripcion</th>'))
                                    .append($('<th scope="col" style=text-align:left>UM</th>'))
                                    .append($('<th scope="col" style=text-align:left>Cantidad</th>'))
                                    .append($('<th scope="col" style=text-align:left>Precio</th>'))
                                    .append($('<th scope="col" style=text-align:left>Importe</th>'))
                                    .append($('<th scope="col" style=text-align:left>Mon.</th>'))
                                    .append($('<th scope="col" style=text-align:left>CUENTA</th>'))
                                    );
                            if (data.d.length > 0) {
                                var sum = 0;
                                $.each(data.d, function (i, elem) {
                                    var PRE_MON = (M_PAR[4] == "MN" ? elem['C6_NPREUN1'] : elem['C6_NPREUNI']);
                                    var IMP = Operacion.mround(elem['C6_NCANTID'] * PRE_MON, 2);
                                    table.append($('<tr style=color:#000066;></tr>')
                                         .append($('<td>' + elem['C6_CITEM'] + '</td>'))
                                         .append($('<td>' + elem['C6_CCODIGO'] + '</td>'))
                                         .append($('<td>' + elem['C6_CDESCRI'] + '</td>'))
                                         .append($('<td>' + elem['AR_CUNIDAD'] + '</td>'))
                                         .append($('<td>' + elem['C6_NCANTID'].toFixed(3) + '</td>'))
                                         .append($('<td>' + Operacion.mround(PRE_MON, 3) + '</td>'))//original C6_NPREUN1
                                         .append($('<td>' + IMP + '</td>'))
                                         .append($('<td style=font-weight:bold>' + elem['C6_CCODMON'] + '</td>'))
                                         .append($("<td><div class=tip title='" + elem['TC_CDESCRI'] + "'>" + elem['AR_CCUENTA'] + "</div></td>"))
                                    );
                                    $('.gvd').append(table);
                                    sum += IMP;
                                });
                                Operacion.mask('hfIMT').val(sum);
                            } else {
                                //Operacion.mask('gvDetalle').empty();
                                table.append($('<tr style=color:#000066;></tr>')
                                         .append($('<td>&nbsp;</td>'))
                                         .append($('<td>&nbsp;</td>'))
                                         .append($('<td>&nbsp;</td>'))
                                         .append($('<td>&nbsp;</td>'))
                                         .append($('<td>&nbsp;</td>'))
                                         .append($('<td>&nbsp;</td>'))
                                         .append($('<td>&nbsp;</td>'))
                                         .append($('<td>&nbsp;</td>'))
                                         .append($('<td>&nbsp;</td>'))//NUEVO 23.06.16
                                         );
                                //$('#MainContent_gvDetalle').append(table);
                                $('.gvd').append(table);
                                Operacion.inputEstado('button-n1', 1, false);
                            }
                        } catch (ex) {
                            alert(JSON.parse(ex));
                        }
                    },
                    error: function (response) {
                        console.log(response);
                    }
                });
            };
            //INICIA CALCULO PE
            var iniciaGrilla = function (ID) {
                var DATA = {};
                DATA.C5_CALMA = (ID['d'] == 0 ? "" : M_AUX[ID][0]);
                DATA.C5_CTD = "PE";
                DATA.C5_CCODMOV = "CO";
                DATA.C5_CRFTDOC = "";
                DATA.C5_CCODPRO = Operacion.mask('txtCOD').val().trim();
                DATA.C5_DFECDOC = (ID['d'] == 0 ? "" : M_AUX[ID][3]);
                DATA.C5_DFECMOD = (ID['d'] == 0 ? "" : M_AUX[ID][3]);
                //console.log(DATA);
                $.ajax({
                    type: "POST",
                    url: "ContabilizaDOC.aspx/getDPES1",
                    data: '{DATA:' + JSON.stringify(DATA) + ',ND:' + JSON.stringify(IDX) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        if (data.d.length > 0) {
                            var sum = 0;
                            $.each(data.d, function (i, elem) {
                                //console.log(AD);
                                var IMP = Number(elem['C6_NCANTID']);// * Number(elem['C6_NPREUN1']);
                                sum += IMP;//(M_PAR['DSCTO']=="S"?Number(IMP-AD[MI_COD]):IMP);
                            });
                            var M_OPER1 = (sum * (M_PAR[1] / 100))
                            M_DATA[61] = Operacion.mround(M_OPER1, 2);
                            Operacion.mask('txtIGV').val(Operacion.mround(M_OPER1, 2));//IGV
                            var M_OPER2 = (Number(M_OPER1) + Number(sum));
                            M_DATA[62] = Operacion.mround(M_OPER2, 2);
                            Operacion.mask('txtIMP').val(Operacion.mround(M_OPER2, 2));//IMPORTE TOTAL
                            Operacion.mask('hfIMT').val(sum);//AGREGADO 14.07.16
                            //--NUEVO 02.06.16|10.06.2016
                            misubtotal(M_DATA[61], M_DATA[62])//(M_OPER1, M_OPER2);
                            //-----------------------------------------------------------------------------------------------
                            /*var M_CALCULO = M_OPER1;//Operacion.mask('txtIGV').val();
                            var M_TOTAL = M_OPER2;
                            var M_FINAL = ((M_CALCULO * 100) / 18);
                            Operacion.mask('txtVCDE').val(Number(M_FINAL).toFixed(2));//M_OPER1 -M_VCD.toFixed(2)
                            var M_CC = (M_OPER2 - M_OPER1);
                            Operacion.mask('txtVCCA').val(Number(M_CC).toFixed(2));//SISTEMA
                            //var M_INAF = Number(M_FINAL) - Number(M_CC);
                            Operacion.mask('txtINAF').val(Operacion.mask('txtVCDE').val() - Operacion.mask('txtVCCA').val());*/
                            //-------------------------------------------------------------------------------------------------
                            //var M_OC = Operacion.mask('txtNDR').val();
                            //detalleOC(M_OC);
                            //NUEVO 06.06.2016
                            Operacion.mask('txtGCOM').val('');
                            Operacion.mask('txtGMOV').val('');

                            //var M_TDOC = Operacion.mask('ddlTDOC').val();
                            //var N_DOC = Operacion.mask('txtDOC').val();
                            //var N_PRO = IDX;
                            miglosadet(IDX);
                            var G_COM = "OC " + Operacion.mask('txtNDR').val() + " " + Operacion.mask('lblCodigo').text().substring(0, 9);// + " " + N_DOC;
                            var G_COMD = "NI " + C_DET;// + " " + N_DOC;

                            Operacion.mask('txtGCOM').val(G_COM);
                            Operacion.mask('txtGMOV').val(G_COMD);
                            //27.09.16
                            Operacion.mask('txtRefer').attr('maxlength',(29-G_COMD.length));
                            Operacion.inputEstado('txtRefer', 0, true);
                        } else {
                            Operacion.mask('txtIGV').val(0.00);
                            Operacion.mask('txtIMP').val(0.00);
                            Operacion.mask('txtVCDE').val(0.00);
                            Operacion.mask('txtVCCA').val(0.00);
                            Operacion.mask('txtINAF').val(0.00);
                            //Operacion.inputEstado('button-n1', 1, false);
                            Operacion.mask('txtRefer').val('');
                            Operacion.mask('txtGCOM').val('');
                            Operacion.mask('txtGMOV').val('');
                            //27.09.16
                            Operacion.inputEstado('txtRefer', 1, true);
                        }
                    },
                    error: function (response) {
                        console.log(response);
                    }
                });
            };
            //CONSULTA TASA SUBDIARIO 13
            var iniciaTITA = function (KEY) {
                var TABG = {};
                TABG.TCOD = "28";
                TABG.TCLAVE = KEY;//SUBDIARIO
                $.ajax({
                    type: "POST",
                    url: "../../ALMACEN/LiquidacionCompra.aspx/listaTAGE",
                    data: '{TABG:' + JSON.stringify(TABG) + ' }',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        //console.log(data);
                        if (data.d.length > 0) {
                            Operacion.mask('txtTDES').val(data.d[0].TDESCRI.substring(0, 25));
                            var descri = data.d[0].TDESCRI.split("  ");
                            auxiliar = $.grep(descri, function (n) {
                                return (n);
                            });
                            //var auxiliar = (descri[28] == '0.00' ? descri[30] : descri[28]);
                            Operacion.mask('txtTASA').val(auxiliar[2]);//.attr('readonly', true);
                            var M_CAL1 = Operacion.mask('txtIMP').val();
                            var M_OPER = M_CAL1 * (auxiliar[2] / 100);
                            Operacion.mask('txtIMDE').val(Operacion.mround(M_OPER, 0));
                            //var M_DESF = Operacion.mask('txtDOC').val();
                            //Operacion.mask('txtNDET').val(M_DESF + "-D");
                            var M_FECD = Operacion.mask('txtFDOC').val();
                            Operacion.mask('txtFDET').val(M_FECD);
                            Operacion.mask('txtMBAS').val(M_CAL1);
                        } else {
                            alert('El codigo no se encuentra registrado');
                            Operacion.mask('txtTTAS').val('');
                            Operacion.mask('txtTDES').val('');
                            Operacion.mask('txtTASA').val('');
                            Operacion.mask('txtIMDE').val('');
                            //Operacion.mask('txtNDET').val('');
                            Operacion.mask('txtFDET').val('');
                            //Operacion.mask('txtDOC').val('');
                            Operacion.mask('txtMBAS').val('');
                        }
                    }, error: function (response) {
                        console.table(response);
                    }
                });
            }
            //VERIFICA ACREEDOR
            var verificaACR = function (RUC) {
                var DATA = {};
                DATA.AC_CVANEXO = Operacion.mask('ddlACR').val();
                DATA.AC_CCODIGO = '%' + RUC + '%';
                DATA.AV_CDOCIDE = 6;
                //DATA.AC_CTIPOAC = PAR['CE_CTIPACR'];

                $.ajax({
                    url: "../../ALMACEN/LiquidacionCompra.aspx/listaMaestroID",
                    data: '{DATA:' + JSON.stringify(DATA) + '}',
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    async: false,
                    success: function (data) {
                        //console.log(data);
                        //try {
                        if (data.d.length > 0) {
                            $.each(data.d, function (i, v) {
                                //Operacion.mask('lblDES').text('Retención:');
                                Operacion.mask('lblPOR').text(v.AC_NPORRE);//PORCENTAJE RETENCION
                                M_DATA[59] = v.AC_CRETE;
                                M_DATA[60] = v.AC_NPORRE;
                            });
                            /*var index = items.indexOf(false);
                            if (index !== -1) {
                                CTOK[index] = true;
                            }*/
                            //console.log(CTOK);
                        } else {
                            alert('Verificar proveedor:\n(1)Que Exista\n(2)Que tenga un tipo documento asignado');
                            CTOK.push(false);
                            console.log(CTOK);
                        }
                        /*} catch (ex) {
                            //console.log(ex);
                            alert(ex.message);
                            CTOK.push(false);
                        }*/

                    },
                    error: function (data) {
                        console.log(data);
                    }
                });
            }
            //CUENTA COMPRA
            var iniciaCOC = function (MON) {
                Operacion.mask('ddlCOC').empty();
                var DATA = {};
                DATA.TCOD = "53";
                DATA.TDESCRI = MON;

                $.ajax({
                    type: "POST",
                    url: "ContabilizaDOC.aspx/ListarTGL",
                    data: '{DATA:' + JSON.stringify(DATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        //console.log(data);
                        $.each(data.d, function (i, v) {
                            Operacion.mask('ddlCOC').append($('<option>', {
                                value: v.TCLAVE,
                                text: v.TDESCRI
                            }));
                        });
                    },
                    error: function (response) {
                        console.log(response);
                    }
                });
            }
            //OBTIENE DATOS CUENTA X
            var MDCTA = function (CTA) {
                var PDATA = {};
                PDATA.PCUENTA = CTA;
                $.ajax({
                    type: "POST",
                    url: "../../ALMACEN/LiquidacionCompra.aspx/ListaPlanC",
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
            //MUESTRA DETRACCION DEPENDIENDO SUBDIARIO
            var validaSUB = function () {
                var M_SUB = Operacion.mask('ddlSUB').val();
                //console.log(M_SUB);
                if (M_SUB == "SUB3") {
                    $('.tr_oculta2').show();
                    M_PAR[3] = 1;//SUBDIARIO 13
                    var M_DOC = Operacion.mask('txtDOC').val();
                    Operacion.mask('txtNDET').val(M_DOC + "-D");
                    //var M_DESF = Operacion.mask('txtDOC').val();
                    //Operacion.mask('txtNDET').val(M_DESF + "-D");
                    Operacion.inputEstado('txtTTAS', 0, true);
                    Operacion.mask('txtTTAS').focus();
                } else {
                    M_PAR[3] = 0;//SUBDIARIO 11
                    $('.tr_oculta2').hide();
                    Operacion.mask('txtTTAS').val('');
                    Operacion.mask('txtTDES').val('');
                    Operacion.mask('txtTASA').val('');
                    Operacion.mask('txtIMDE').val('');
                    Operacion.mask('txtNDET').val('');
                    Operacion.mask('txtFDET').val('');
                    Operacion.mask('txtDOC').val('');
                    Operacion.mask('txtMBAS').val('');
                    Operacion.inputEstado('txtTTAS', 1, true);
                }
            }
            //SUBDIARIO
            var iniciaSUB = function () {
                Operacion.mask('ddlSUB').empty();
                var DATA = {};
                DATA.TCOD = "53";
                DATA.TCLAVE = "SUB";
                DATA.TDESCRI = null;

                $.ajax({
                    type: "POST",
                    url: "ContabilizaDOC.aspx/ListarTGL",
                    data: '{DATA:' + JSON.stringify(DATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        $.each(data.d, function (i, v) {
                            Operacion.mask('ddlSUB').append($('<option>', {
                                value: v.TCLAVE,
                                text: v.TDESCRI
                            }));
                        });
                        if (M_PAR[7].trim() != "S") {
                            Operacion.mask('ddlSUB').val('SUB01');
                            Operacion.inputEstado('ddlSUB', 1, true);
                            validaSUB();//NUEVO
                        } else {
                            Operacion.mask('ddlSUB').val('SUB3');
                            Operacion.inputEstado('ddlSUB', 1, true);
                            validaSUB();
                        }
                    },
                    error: function (response) {
                        console.log(response);
                    }
                });
            }
            var correlativoPG = function (FF, FC) {

                var DATA = {};
                DATA.PG_CVANEXO = M_DATA[0];
                DATA.PG_CTIPDOC = M_DATA[2];
                DATA.PG_CCODIGO = M_DATA[1];
                DATA.PG_CFECCOM = FF;
                DATA.PG_DFECCOM = moment(FC, 'DD/MM/YYYY');

                //console.log(DATA);
                $.ajax({
                    type: "POST",
                    url: "../../ALMACEN/LiquidacionCompra.aspx/correlativoPG",
                    data: '{ DATA: ' + JSON.stringify(DATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        //console.log(data.d);
                        CORPAG = data.d;
                    },
                    error: function (response) {
                        console.table(response);
                    }
                });
            }
            //CORRELAVITO COMPROBANTE
            var correlativoCP = function () {
                //CORRELATIVO COMPROBANTE
                var element = Operacion.mask('txtFCOM').val();
                var fecha = element.split('/');
                //var FECDOC = fecha[2].substr(2, 2) + "" + fecha[1] + "" + fecha[0];

                var DATA = {};
                DATA.CTSUBDIA = M_DATA[9];//Operacion.mask('ddlSDIA').val();
                DATA.CTANO = fecha[2].substr(2, 2);
                DATA.CTMES = fecha[1];
                //DATA.LC_DFECCOM = moment(Operacion.mask('txtFEC').val(), 'DD/MM/YYYY');
                //console.log(DATA);
                $.ajax({
                    type: "POST",
                    url: "../../ALMACEN/LiquidacionCompra.aspx/correlativoCP",
                    data: '{ DATA: ' + JSON.stringify(DATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        //console.log(data.d);
                        COMP = data.d;
                        Operacion.mask('txtDC_CU').val(COMP);
                        Operacion.mask('txtNCOM').val(COMP);
                        M_DATA[10] = COMP;//NUMERO COMPROBANTE
                    },
                    error: function (response) {
                        console.table(response);
                    }
                });
            }
            //CORRELATIVO PAGO-NO SE USA
            var correlativoPG = function (FF, FC) {

                var DATA = {};
                DATA.PG_CVANEXO = Operacion.mask('ddlTIA').val().trim();
                DATA.PG_CTIPDOC = Operacion.mask('txtTDOC').val().trim();
                DATA.PG_CCODIGO = Operacion.mask('lblDNI').text().trim();
                DATA.PG_CFECCOM = FF;
                DATA.PG_DFECCOM = moment(FC, 'DD/MM/YYYY');

                //console.log(DATA);
                $.ajax({
                    type: "POST",
                    url: "LiquidacionCompra.aspx/correlativoPG",
                    data: '{ DATA: ' + JSON.stringify(DATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        //console.log(data.d);
                        CORPAG = data.d;
                    },
                    error: function (response) {
                        console.table(response);
                    }
                });
            }
            //ACTUALIZA NUMERACION SISPAG/CONCAR
            var anumCOMP = function () {
                var element = Operacion.mask('txtFCOM').val();
                var fecha = element.split('/');
                var NANO = fecha[2].substr(2, 2);
                var NMES = fecha[1];

                //SISPAG
                var CDATA = {};
                CDATA.CTSUBDIA = M_DATA[9];//Operacion.mask('ddlSDIA').val().trim();
                CDATA.CTANO = NANO;
                CDATA.CTMES = NMES;
                CDATA.CTNUMER = Number(COMP.substring(2, 6)).toString();
                //alert(CDATA);
                //console.log(CDATA);
                $.ajax({
                    type: "POST",
                    url: "../../ALMACEN/LiquidacionCompra.aspx/aNumeracion",
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
            //TIPO CAMBIO
            var iniciaTC = function (CODATA, OP) {
                //console.log(OP);
                $.ajax({
                    type: "POST",
                    url: "../../ALMACEN/RegistroEntradaOC.aspx/getTC",
                    data: '{CODATA:' + JSON.stringify(CODATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        //console.log(data);
                        if (data.d != null) {
                            Operacion.mask('txtVTIC').val((OP == "M" ? data.d['XMEIMP'] : data.d['XMEIMP2']));
                        } else {
                            alert('No existe tipo cambio para la fecha, coordinar con contabilidad');
                            Operacion.mask('txtVTIC').val('');
                        }
                    },
                    error: function (response) {
                        console.log(response);
                    }
                });
            }
            //LIMPIAR CAMPOS DIALOGO 1
            var iniciaDialogo = function () {
                $("#Creacion").find(':input').each(function () {
                    var elemento = this;
                    if (elemento.type == "text" || elemento.type == "select-one") {
                        var milabel = elemento.id;
                        var label = milabel.split("_");
                        (jQuery.inArray(label[1], EX) !== -1 ? Operacion.inputEstado(label[1], 0, true) : Operacion.inputEstado(label[1], 1, true));
                    }
                });
            }
            //LIMPIAR CAMPOS
            var limpiar = function () {
                $("#Creacion").find(':input').each(function () {
                    var elemento = this;
                    if (elemento.type == "text") {
                        var milabel = elemento.id;
                        var label = milabel.split("_");
                        Operacion.mask(label[1]).val('');
                    } else if (elemento.type == "select-one") {
                        //var milabel = elemento.id;
                        //var label = milabel.split("_");
                        //Operacion.mask(label[1]).empty();
                    }
                });
                $('.tr_oculta1').hide();
            }
            //PARTE ORDEN COMPRA
            var iniciaRE = function () {
                iniciaDialogo();
                dialog.dialog("open");
                Operacion.mask('txtNDR').focus();
            }
            //DETALLE COMPROBANTE
            var detalleCO = function () {

                var DMN = Operacion.mask('ddlMON').find('option:selected').text();
                Operacion.mask('txtDC_SU').val(M_DATA[9]);
                Operacion.mask('txtDC_CU').val(COMP);
                Operacion.mask('txtDC_MO ').val(M_DATA[12] + " " + DMN);
                Operacion.mask('txtDC_FD').val(M_DATA[45]);//moment(M_DATA[45]).format('DD/MM/YYYY'));

                var A_IGV = (M_DATA[61] != "" && M_DATA[61] != 0 ? 1 : 0);

                if (M_PAR[7] != "S") {
                    //ORDENES COMPRAS
                    DCUENTAS = [M_PAR[0], M_DATA[23]];//C.IGV|C.COMPRA|
                    MONTO = [M_DATA[61], M_DATA[62]];
                    obtenerCCO(M_DATA[27]);//[ORDEN COMPRA]
                } else {
                    //ORDENES SERVICIO
                    DCUENTAS = [M_PAR[0], M_DATA[23], "421205", M_DATA[23]];//C.IGV|C.COMPRA|DETRACCIONES|C.COMPRA
                    A_DCUENTAS = [M_PAR[0], M_DATA[23], "421205", M_DATA[23] + "-C"]
                    MONTO = [M_DATA[61], M_DATA[62], Operacion.mask('txtIMDE').val(), Operacion.mask('txtIMDE').val()];// M_DATA[62]-M_DATA[62]
                    var LEN = AT.length;
                    for (var i = 0; i < LEN; i++) {
                        obtenerAOS(AT[i], ATP[AT[i]]);
                    }

                }

                if (A_IGV != "1") {
                    DCUENTAS.shift();
                    MONTO.shift();
                }

                var LEN = DCUENTAS.length;
                //RECORRO CUENTA
                var S_MD = 0;
                var S_MH = 0;
                var U_MD = 0;
                var U_MH = 0;
                try {
                    for (var i = 0; i < LEN; i++) {

                        MDCTA(DCUENTAS[i]);//PERMISOS CUENTA
                        DMONTO[(M_PAR[7] != "S" ? DCUENTAS[i] : A_DCUENTAS[i])] = Number(MONTO[i]);
                        //console.log(DMONTO);
                        verificaDH(M_DATA[9], DCUENTAS[i]);
                        //for (var j = 0; j < 11; j++) {
                        //RDCTA:CONSIDERA REPETIDO----------------------------------------------------PENDIENTE
                        var DC_PRO = (RDCTA[DCUENTAS[i]][1] == "P" ? M_DATA[1] : "");//PROVEEDOR
                        var DC_COS = (RDCTA[DCUENTAS[i]][2] == "S" ? M_PAR[8] : "");//CENTRO COSTO
                        var DC_DRE = (RDCTA[DCUENTAS[i]][3] == "S" ? M_DATA[2] : "FT");//TIPO DOCUMENTO - AGREGO TOME FT
                        var DC_DRED = (RDCTA[DCUENTAS[i]][3] == "S" ? M_DATA[3] : M_DATA[3]);//DETALLE DOCUMENTO - AGREGO TOME NUMERO DOCUMENTO
                        var DC_FDOC = M_DATA[41];//REVISAR CON CONFIGURACION
                        var DC_FVEN = (RDCTA[DCUENTAS[i]][4] == "S" ? M_DATA[42] : "");//FECHA VENCIMIENTO
                        //var DC_AREA = (RDCTA[DCUENTAS[i]][6] == "S" ? "" : "");//AREA
                        var DC_OD = (DC_COD[DCUENTAS[i]] != undefined ? DC_COD[DCUENTAS[i]] : "");//ORIGEN Y DESTINO
                        var D_DET = RDCTA[DCUENTAS[i]][12];//DESCRIPCION CUENTA
                        //CARGA D/H
                        var M_DH = (M_PAR[7] != "S" ? RDCTA[DCUENTAS[i]][9] : (A_DCUENTAS[i].indexOf('-C') > 0 ? "D" : RDCTA[DCUENTAS[i]][9]));
                        //RETENCION
                        var M_CRET = (DCUENTAS[i] == M_DATA[23] ? M_DATA[59] : "");
                        var M_PRET = (DCUENTAS[i] == M_DATA[23] ? M_DATA[60] : 0);
                        //CONFIGURACION DETRACCION-"1"
                        var DC_DT1 = (RDCTA[DCUENTAS[i]][8] == "1" ? "DR" : "");
                        var DC_DT2 = (RDCTA[DCUENTAS[i]][8] == "1" ? Operacion.mask('txtNDET').val() : "");
                        var DC_DT3 = (RDCTA[DCUENTAS[i]][8] == "1" ? Operacion.mask('txtFDET').val() : "");
                        var DC_DT4 = (RDCTA[DCUENTAS[i]][8] == "1" ? Operacion.mask('txtTTAS').val().trim() : "");
                        var DC_DT5 = (RDCTA[DCUENTAS[i]][8] == "1" ? Operacion.mask('txtTASA').val().trim() : 0);
                        var DC_DT6 = (RDCTA[DCUENTAS[i]][8] == "1" ? Operacion.mask('txtMBAS').val().trim() : 0);
                        var DC_DT7 = (RDCTA[DCUENTAS[i]][8] == "1" ? Operacion.mask('txtMBAS').val().trim() / M_DATA[13] : 0);
                        var M_CODARC = (DCUENTAS[i] == "421201" ? "01" : (DCUENTAS[i] == "421205" ? "33" : ""));//RDCTA[DCUENTAS[i]][10]

                        //M_DATA[12] Moneda
                        MI_DETALLE[(M_PAR[7] != "S" ? DCUENTAS[i] : A_DCUENTAS[i])] = [
                            Operacion.cadenaMascara(i + 1, 4), DCUENTAS[i], D_DET, (DCUENTAS[i].charAt("0") == "2" ? M_DATA[1] : DC_PRO), DC_COS, M_DH, Number(DMONTO[(M_PAR[7] != "S" ? DCUENTAS[i] : A_DCUENTAS[i])]).toFixed(2),
                            DC_DRE, (DC_DT2 != "" ? DC_DT2 : DC_DRED), DC_FDOC, DC_FVEN, "", "", RDCTA[DCUENTAS[i]][5], DC_OD, DC_DT1, DC_DT2, DC_DT3, DC_DT4, DC_DT5,
                            DC_DT6, DC_DT7, M_CRET, M_PRET, RDCTA[DCUENTAS[i]][10]
                        ];
                        //console.log(MI_DETALLE);
                        //0:CORRELATIVO|1:CUENTA|2:DETALLE|3:PROVEEDOR|4:CENTRO COSTO|5:MONEDA|6:D/H|IMPORTE|TIPOD|NRO.DOC|FECDOC|FECVEN|AREA(X)|-|-|ANEXO2|ORIGEN
                        //|CODITO DET.|NRO DET.|FEC. DET|TIPO DET.|MMN DET|MUS DET|21:CODIGO RET|22:POR RET
                        /*MI_DETALLE[DCUENTAS[i]] = [
                            Operacion.cadenaMascara(i + 1, 4), DCUENTAS[i], DC_PRO, DC_COS, RDCTA[DCUENTAS[i]][9],
                            DMONTO[DCUENTAS[i]], DC_DRE, DC_DRED, moment(M_DATA[41]).format('DD/MM/YYYY'), DC_FVEN,
                            "", "", RDCTA[DCUENTAS[i]][5], DC_OD, DC_DT1, DC_DT2, DC_DT3, DC_DT4, DC_DT5, DC_DT6, DC_DT7, M_CRET, M_PRET
                        ];*/

                        if (M_DH == "D") {
                            var M_CAL1 = (M_DATA[12] == "MN" ? DMONTO[DCUENTAS[i]] / M_DATA[13] : DMONTO[DCUENTAS[i]] * M_DATA[13]);//SOLES-DOLARES
                            S_MD = Operacion.mround(Number(S_MD) + Number(DMONTO[(M_PAR[7] != "S" ? DCUENTAS[i] : A_DCUENTAS[i])]), 2);//.toFixed(2);
                            U_MD = Operacion.mround(Number(U_MD) + Number(M_CAL1), 2);//Number(DMONTO[(M_PAR[7] != "S" ? M_CAL1 : A_DCUENTAS[i])]), 2);//.toFixed(2);
                        } else {
                            var M_CAL2 = (M_DATA[12] == "MN" ? DMONTO[DCUENTAS[i]] / M_DATA[13] : DMONTO[DCUENTAS[i]] * M_DATA[13]);//DOLARES-SOLES
                            S_MH = Operacion.mround(Number(S_MH) + Number(DMONTO[(M_PAR[7] != "S" ? DCUENTAS[i] : A_DCUENTAS[i])]), 2);//.toFixed(2);
                            U_MH = Operacion.mround(Number(U_MH) + Number(M_CAL2), 2);//Number(DMONTO[(M_PAR[7] != "S" ? M_CAL2 : A_DCUENTAS[i])]), 2);//.toFixed(2);
                        }

                    }//TERMINA FOR
                    Operacion.mask('lblMONEDA1').text((M_DATA[12] == "MN" ? "SOLES" : "DOLARES"));
                    Operacion.mask('lblMONEDA2').text((M_DATA[12] == "MN" ? "DOLARES" : "SOLES"));
                    //--MONEDA 1
                    Operacion.mask('txtDC_DE').val(S_MD);//DEBE
                    Operacion.mask('txtDC_HA').val(S_MH);//HABER
                    var P_CAL1 = Operacion.mround(Number(S_MD) - Number(S_MH), 2);
                    Operacion.mask('txtDC_DI').val(P_CAL1);
                    if (Number(P_CAL1) < -0.01) {// && Number(P_CAL1) < 0) {
                        alert('Verificar operaciones');
                        CTOK.push(false);
                    }
                    //--MONEDA 2
                    Operacion.mask('txtDC_DE0').val(U_MD);
                    Operacion.mask('txtDC_HA0').val(U_MH);
                    Operacion.mask('txtDC_DI0').val(Operacion.mround(Number(U_MD) - Number(U_MH), 2));
                    //console.log($.extend({},MI_DETALLE));
                    dibujaTabla("<%=gvDCOM.ClientID %>", (M_PAR[7] != "S" ? DCUENTAS : A_DCUENTAS), "mi_tabla", MI_DETALLE, "", "");
                    dialog3.dialog("open");
                } catch (ex) {
                    CTOK.push(false);
                    alert(JSON.parse(ex));
                }
            }
            var actualizaCPE = function () {
                //PROCESO 3:ACTUALIZA N PARTES DE ENTRADAS ELEGIDOS
                //var MLEN = IDXI.length
                var MLEN = IDX.length;
                for (k = 0; k < MLEN; k++) {

                    var VDATA = {};
                    VDATA.C5_CALMA = M_AUX[IDX[k]][0];//Operacion.mask('codAL').val();
                    VDATA.C5_CTD = "PE";//DOCUMENTO INGRESO:PE
                    VDATA.C5_CNUMDOC = IDX[k];//N PE NUMERO DOCUMENTO
                    VDATA.C5_CRFTDOC = "FT";
                    VDATA.C5_CRFNDOC = M_DATA[3];
                    VDATA.C5_CTIPORD = "5";//(M_PAR[6].trim()=="5"?"5":(M_PAR[6].trim()=="4"?"4":""));//ATENDIDO
                    VDATA.C5_CGUIFAC = "S";
                    VDATA.C5_CSUBDIA = M_DATA[9];//SUBDIARIO
                    VDATA.C5_CCOMPRO = COMP;//CORRELATIVO N. COMPROBANTE
                    VDATA.C5_CNUMPED = (M_PAR[6].trim() == "5" ? M_PAR[6] : (M_PAR[6].trim() == "4" ? M_PAR[6] : ""));//ATENDIDO;//USADO PARA DETERMINAR ESTADO 
                    //console.log(VDATA);
                    $.ajax({
                        type: "POST",
                        url: "../../ALMACEN/LiquidacionCompra.aspx/actualizaVCAB",
                        data: '{ VDATA: ' + JSON.stringify(VDATA) + '}',
                        contentType: "application/json;charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (data) {
                            //return true;
                        },
                        error: function (data) {
                            alert('El proceso no se pudo completar CPE');
                            console.log(data);
                        }
                    });
                }

            }
            var actualizaDPE = function () {
                var M_LEN2 = IDX.length;
                for (var i = 0; i < M_LEN2; i++) {
                    var VDETA = {};
                    VDETA.C6_CALMA = M_AUX[IDX[i]][0];//Operacion.mask('codAL').val();M_AUX[elem['C5_CNUMDOC']][0]
                    VDETA.C6_CTD = "PE";//DOCUMENTO DE INGRESO
                    //VDETA.C6_CCODIGO = CP.trim();
                    //VDETA.C6_CCANTEN = CA;//CT;
                    VDETA.C6_CESTADO = "V";
                    VDETA.C6_CSUBDIA = M_DATA[9];
                    VDETA.C6_CCOMPRO = COMP;

                    //console.log(VDETA);
                    $.ajax({
                        type: "POST",
                        url: "../../ALMACEN/LiquidacionCompra.aspx/actualizaVDET",
                        data: '{ VDETA: ' + JSON.stringify(VDETA) + ',ND:' + JSON.stringify(IDX) + '}',
                        contentType: "application/json;charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (data) {
                            return true;
                        },
                        error: function (data) {
                            alert('El proceso no se pudo completar VD');
                            console.log(data);
                        }
                    });
                }
            }
            var balance = function (MIABAL) {
                //var ATT = Operacion.mask('txtCTAS').val(); TIPO TASA
                var element = Operacion.mask('txtFCOM').val();//FECHA COMPROBANTE
                var fecha = element.split('/');
                var FECPRO = fecha[2] + "" + fecha[1];

                var MN_DEBE = 0;
                var MN_HABER = 0;
                var US_DEBE = 0;
                var US_HABER = 0;

                var LEN = DCUENTAS.length;
                for (var i = 0; i < LEN; i++) {
                    if (M_DATA[12] == "MN") {
                        MN_DEBE = (MIABAL[DCUENTAS[i]]['D'] != undefined ? Number(MIABAL[DCUENTAS[i]]['D']) : 0);
                        MN_HABER = (MIABAL[DCUENTAS[i]]['H'] != undefined ? Number(MIABAL[DCUENTAS[i]]['H']) : 0);
                        US_DEBE = (MIABAL[DCUENTAS[i]]['D'] != undefined ? Operacion.mround(MIABAL[DCUENTAS[i]]['D'] / M_DATA[13], 2) : 0);
                        US_HABER = (MIABAL[DCUENTAS[i]]['H'] != undefined ? Operacion.mround(MIABAL[DCUENTAS[i]]['H'] / M_DATA[13], 2) : 0);
                    } else {
                        MN_DEBE = (MIABAL[DCUENTAS[i]]['D'] != undefined ? Operacion.mround(MIABAL[DCUENTAS[i]]['D'] * M_DATA[13], 2) : 0);
                        MN_HABER = (MIABAL[DCUENTAS[i]]['H'] != undefined ? Operacion.mround(MIABAL[DCUENTAS[i]]['H'] * M_DATA[13], 2) : 0);
                        US_DEBE = (MIABAL[DCUENTAS[i]]['D'] != undefined ? Number(MIABAL[DCUENTAS[i]]['D']) : 0);
                        US_HABER = (MIABAL[DCUENTAS[i]]['H'] != undefined ? Number(MIABAL[DCUENTAS[i]]['H']) : 0);
                    }
                    var BDATA = {};
                    BDATA.BCUENTA = DCUENTAS[i];
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
                    BDATA.BFORBAL = "1";//CONTROL PARA INCREMENTAR 
                    BDATA.BFORGYP = "";
                    BDATA.BFORRE1 = "";
                    BDATA.BCTAAJU = "";
                    BDATA.BFECPRO2 = FECPRO;

                    //console.log(BDATA);
                    $.ajax({
                        type: "POST",
                        url: "../../ALMACEN/LiquidacionCompra.aspx/actualizaBAL",
                        data: '{ BDATA: ' + JSON.stringify(BDATA) + '}',
                        contentType: "application/json;charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (data) {
                            if (i == (LEN - 1)) { rpta = true; }
                        },
                        error: function (data) {
                            alert('El proceso no se pudo completar PLQ');
                            console.log(data);
                        }
                    });
                }
                return { rpta }
            }
            //REGSITRO DETALLE COMPROBANTE
            var asientoDET = function () {

                //FECHA COMPROBANTE
                var element = Operacion.mask('txtFCOM').val();
                var fecha = element.split('/');
                var NFECHA = fecha[2].substr(2, 2) + "" + fecha[1] + "" + fecha[0];

                //FECHA REGISTRO
                var element_x = Operacion.mask('txtFVB').val();
                //var fecha_x = element_x.split('/');
                //var FECHAR = moment();//.format('DD/MM/YYYY');

                //FECHA DOCUMENTO
                var element0 = Operacion.mask('txtFDOC').val();
                var fecha0 = element0.split('/');
                var NFECHA0 = fecha0[2].substr(2, 2) + "" + fecha0[1] + "" + fecha0[0];

                //FECHA VENCIMIENTO
                var element1 = Operacion.mask('txtFVEN').val();
                var fecha1 = element1.split('/');
                var NFECHA1 = fecha1[2].substr(2, 2) + "" + fecha1[1] + "" + fecha1[0];

                //FECHA RECEPCION
                var element2 = Operacion.mask('txtFREC').val();
                var fecha2 = element2.split('/');
                var NFECHA2 = fecha2[2].substr(2, 2) + "" + fecha2[1] + "" + fecha2[0];

                //FECHA DETRACCION
                if (Operacion.mask('txtTTAS').val() != "") {
                    var element3 = Operacion.mask('txtFDET').val();
                    var fecha3 = element3.split('/');
                    var NFECHA3 = fecha3[2].substr(2, 2) + "" + fecha3[1] + "" + fecha3[0];
                }

                var PASBAL = [];
                var gridView = document.getElementById('<%=gvDCOM.ClientID%>');
                var LEN = gridView.rows.length;
                var D_SUM = 0;
                var H_SUM = 0;
                for (i = 1; i < LEN; i++) {
                    cellPivot01 = gridView.rows[i].cells[0];//SECUENCIA
                    gitem01 = cellPivot01.innerHTML;
                    cellPivot02 = gridView.rows[i].cells[1];//CUENTA
                    gitem02 = cellPivot02.innerHTML;
                    //------------------------------------------------------------------N:06.06.16
                    cellPivot03 = gridView.rows[i].cells[2];//DETALLE
                    gitem03 = cellPivot03.innerHTML;
                    //PASBAL.push(gitem02);//ARREGLO BALANCE----------------------------
                    cellPivot04 = gridView.rows[i].cells[3];//PROVEEDOR
                    gitem04 = cellPivot04.innerHTML;
                    cellPivot05 = gridView.rows[i].cells[4];//CENTRO COSTO
                    gitem05 = cellPivot05.innerHTML;
                    cellPivot06 = gridView.rows[i].cells[5];//DEBE-HABER
                    gitem06 = cellPivot06.innerHTML;
                    cellPivot07 = gridView.rows[i].cells[6];//IMPORTE
                    gitem07 = cellPivot07.innerHTML;
                    cellPivot08 = gridView.rows[i].cells[7];//TIPO DOCUMENTO
                    gitem08 = cellPivot08.innerHTML;
                    cellPivot09 = gridView.rows[i].cells[8];//NUMERO DOCUMENTO
                    gitem09 = cellPivot09.innerHTML;

                    PASBAL[gitem02] = new Array();//COLUMNAS
                    if (gitem06 == "D") {
                        //D_SUM += gitem06;
                        PASBAL[gitem02][gitem06] = gitem07;//D_SUM;//IMPORTE MONEDA X
                    } else if (gitem06 == "H") {
                        //H_SUM += gitem06;
                        PASBAL[gitem02][gitem06] = gitem07;//H_SUM;//IMPORTE MONEDA X
                    }
                    //console.log(PASBAL.length);
                    //cellPivot09 = gridView.rows[t].cells[8];//FECHA DOCUMENTO
                    //gitem09 = cellPivot09.innerHTML;
                    //cellPivot10 = gridView.rows[t].cells[9];//FECHA DOCUMENTO
                    //gitem10 = cellPivot10.innerHTML;
                    var MI_CONTROL1 = Operacion.mask('txtDC_DI').val();
                    var MI_CONTROL2 = Operacion.mask('txtDC_DI0').val();
                    //NUEVO 30.06.2016
                    var gitem07_N = (Number(MI_CONTROL1) == Number(0) ? Number(gitem07) :
                                        ((LEN - 1) == i || (LEN - 2) == i || (LEN - 3) == i ?
                                            Number(gitem07) - Number(MI_CONTROL1) :
                                            Number(gitem07))
                                    );
                    var gitem07US = (Number(MI_CONTROL2) == Number(0) ? Operacion.mround(gitem07 / M_DATA[13], 2) :
                                        ((LEN - 1) == i || (LEN - 2) == i || (LEN - 3) == i ?
                                            Operacion.mround(gitem07_N / M_DATA[13], 2) - Number(MI_CONTROL2) :
                                            Operacion.mround(gitem07_N / M_DATA[13], 2))
                                    );//RENDONDEO X FORMULA
                    //27.09.16
                    var DXGLOSA = Operacion.mask('txtGMOV').val().trim() + " / " + Operacion.mask('txtRefer').val().trim();//.substring(0, 29);

                    var ADET = {};
                    ADET.DSUBDIA = M_DATA[9];
                    ADET.DCOMPRO = COMP;
                    ADET.DSECUE = gitem01;
                    ADET.DFECCOM = NFECHA;
                    ADET.DCUENTA = gitem02;
                    ADET.DCODANE = gitem04.trim();
                    ADET.DCENCOS = gitem05;
                    ADET.DCODMON = M_DATA[12];
                    ADET.DDH = gitem06;
                    ADET.DIMPORT = gitem07_N;//Number(gitem07);
                    ADET.DTIPDOC = gitem08;
                    ADET.DNUMDOC = gitem09;
                    ADET.DFECDOC = NFECHA0;
                    ADET.DFECVEN = (MI_DETALLE[gitem02][10] != "" ? NFECHA1 : "");//NFECHA1;
                    ADET.DAREA = "";
                    ADET.DFLAG = (M_DATA[63] == "F" ? "S" : "N");//S:SEGUIMIENTO
                    ADET.DDATE = moment(element_x, 'DD/MM/YYYY');//FECHAR;//Operacion.mround();
                    ADET.DXGLOSA = DXGLOSA.substring(0, 29);//27.09.16 Operacion.mask('txtGMOV').val().substring(0, 29);
                    ADET.DUSIMPOR = (M_DATA[12] == "MN" ? gitem07US : gitem07_N);//O:gitem07 |Operacion.mround(gitem07 / M_DATA[13],2));//R-----------------------------------------------
                    ADET.DMNIMPOR = (M_DATA[12] == "MN" ? gitem07_N : Operacion.mround(gitem07_N * M_DATA[13], 2));//O:gitem07:..-------------------------------------------------
                    ADET.DCODARC = MI_DETALLE[gitem02][24];//ARC[i];//R---------------------------------------------------
                    ADET.DFECCOM2 = moment(element, 'DD/MM/YYYY');
                    ADET.DFECDOC2 = moment(element0, 'DD/MM/YYYY');
                    ADET.DFECVEN2 = (MI_DETALLE[gitem02][10] != "" ? moment(element1, 'DD/MM/YYYY') : "");
                    ADET.DCODANE2 = "";//R:ANEXO REFERENCIA GASTO-------------------------------
                    ADET.DVANEXO = (gitem04 != "" ? "P" : "");
                    ADET.DVANEXO2 = MI_DETALLE[gitem02][13];//CONFIGURACION
                    ADET.DTIPCAM = 0;
                    ADET.DCANTID = 0;
                    ADET.DCTAORI = MI_DETALLE[gitem02][14];//CONFIGURACION
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
                    ADET.DTIPDOR = MI_DETALLE[gitem02][15];//R:DETRRACION->DR
                    ADET.DNUMDOR = MI_DETALLE[gitem02][16];//R
                    ADET.DFECDO2 = MI_DETALLE[gitem02][17];//R:FECHA DETRACCION
                    ADET.DTIPTAS = MI_DETALLE[gitem02][18];//R:
                    ADET.DIMPTAS = MI_DETALLE[gitem02][19];//R
                    ADET.DIMPBMN = MI_DETALLE[gitem02][20];//R:
                    ADET.DIMPBUS = MI_DETALLE[gitem02][21];//R:
                    ADET.DMONCOM = "";
                    ADET.DCOLCOM = "";
                    ADET.DBASCOM = 0;
                    ADET.DINACOM = 0;
                    ADET.IGVCOM = 0;
                    ADET.DTPCONV = "";
                    ADET.DFLGCOM = "";
                    ADET.DANECOM = "";
                    ADET.DTIPACO = "";
                    ADET.DMEDPAG = "";
                    ADET.DTIPDO2 = "";
                    ADET.DNUMDO2 = "";
                    ADET.DRETE = MI_DETALLE[gitem02][22];
                    ADET.DPORRE = MI_DETALLE[gitem02][23];
                    //console.log(ADET);
                    $.ajax({
                        type: "POST",
                        url: "../../ALMACEN/LiquidacionCompra.aspx/guardarADET",
                        data: '{ ADDATA: ' + JSON.stringify(ADET) + '}',
                        contentType: "application/json;charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (data) {
                            if (i == (LEN - 1)) {

                                actualizaCPE();
                                actualizaDPE();

                                IDX.length;
                                Operacion.mask('cblPE').empty();
                                Operacion.mask('gvDetalle').empty();
                                var resolve = balance(PASBAL).rpta;
                                if (resolve == true) {
                                    $(':input').removeAttr('placeholder');
                                    if (confirm('Se ha generado el comprobante \nSubdiario:' + M_DATA[9] + '\nComprobante:' + COMP)) {
                                        //DESEA IMPRIMIR EL VOUCHER

                                        javascript: window.close();
                                    } else {
                                        location.reload();
                                    }
                                }
                            }
                        },
                        error: function (data) {
                            CTOK.push(false);
                            alert('El proceso no se pudo completar ADET');
                            console.log(data);
                        }
                    });
                }
            }
            //REGITRO COMPROBANTE CABECERA
            var asientoCAB = function () {

                //FECHA CONTABLE
                var element1 = Operacion.mask('txtFCOM').val();
                var fecha1 = element1.split('/');
                var nfecha1 = fecha1[2].substr(2, 2) + "" + fecha1[1] + "" + fecha1[0];

                var fechar = moment();
                var total = Operacion.mask('txtDC_DE').val();
                var MGLOSA = Operacion.mask('txtGCOM').val();

                var M_SETC = Operacion.mask('txtFCAM').val();
                var fecha2 = M_SETC.split('/');
                var nfecha2 = fecha2[2].substr(2, 2) + "" + fecha2[1] + "" + fecha2[0];

                var ACAB = {};
                ACAB.CSUBDIA = M_DATA[9];//SUBDIARIO
                ACAB.CCOMPRO = M_DATA[10];
                ACAB.CFECCOM = nfecha1;
                ACAB.CCODMON = M_DATA[12];
                ACAB.CSITUA = "F";//FINALIZADO
                ACAB.CTIPCAM = M_DATA[13];
                ACAB.CGLOSA = MGLOSA;
                ACAB.CTOTAL = total;
                ACAB.CTIPO = Operacion.mask('ddlTCON').val();
                ACAB.CFLAG = (Operacion.mask('ddlTCON').val() == "F" ? "S" : "N");//----TOMAR EN CUENTA LIQUIDACIONES
                ACAB.CDATE = fechar;
                ACAB.CHORA = Operacion.hora();
                ACAB.CUSER = Operacion.mask('hdUSUARIO').val();
                ACAB.CFECCAM = (M_SETC != "" ? nfecha2 : "");
                ACAB.CORIG = "CP";//R SISPAG
                ACAB.CFORM = "A";//R
                ACAB.CTIPCOM = "01";//01:CONTABILIZACIÓN DE DOCUMENTOS
                ACAB.CEXTOR = "";
                ACAB.CFECCOM2 = moment(element1, 'DD/MM/YYYY');
                ACAB.CFECCAM2 = (M_SETC != "" ? moment(M_SETC, 'DD/MM/YYYY') : "");
                ACAB.CMEMO = "";
                ACAB.CSERCER = "";
                ACAB.CNUMCER = "";

                //console.log(ACAB);
                $.ajax({
                    type: "POST",
                    url: "../../ALMACEN/LiquidacionCompra.aspx/guardarACAB",
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
            //REGISTRA PAGO
            var registraPAG = function () {
                //CP0003PAGO
                var element = Operacion.mask('txtFEC').val();
                var fecha = element.split('/');
                var nfecha = fecha[2].substr(2, 2) + "" + fecha[1] + "" + fecha[0];

                var DH = Operacion.mask('txtIMDE').val();//IMPORTE DETRACCION-RETENCION
                var TC = Operacion.mask('txtTIC').val();
                var OPX = DH / TC;
                correlativoPG(nfecha, element);

                var PLQDATA = {};
                PLQDATA.PG_CVANEXO = M_DATA[0];
                PLQDATA.PG_CCODIGO = M_DATA[1].trim();
                PLQDATA.PG_CTIPDOC = M_DATA[2];
                PLQDATA.PG_CNUMDOC = M_DATA[3];
                PLQDATA.PG_CORDKEY = CORPAG;//REEMPLAZAR
                PLQDATA.PG_CDEBHAB = "D";
                PLQDATA.PG_NIMPOMN = DH;//DETRACCION-RETENCION MN
                PLQDATA.PG_NIMPOUS = Operacion.mround(OPX, 2);//D-R US
                PLQDATA.PG_CFECCOM = nfecha;
                PLQDATA.PG_CSUBDIA = Operacion.mask('ddlSDIA').val();
                PLQDATA.PG_CNUMCOM = COMP;//CORRELATIVO DEL COMPROBANTE
                PLQDATA.PG_CGLOSA = Operacion.mask('txtGLO').val();
                PLQDATA.PG_CCOGAST = "";
                PLQDATA.PG_CORIGEN = "CP";//SISPAG
                PLQDATA.PG_CUSUARI = Operacion.mask('hdUSUARIO').val();
                PLQDATA.PG_CCODMON = Operacion.mask('ddlMON').val();
                PLQDATA.PG_DFECCOM = moment(element, 'DD/MM/YYYY');

                //console.log(PLQDATA);
                $.ajax({
                    type: "POST",
                    url: "LiquidacionCompra.aspx/guardarPLQ",
                    data: '{ PLQDATA: ' + JSON.stringify(PLQDATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        //insertaCAR();
                        //asientoCAB();
                        //asientoDET();
                    },
                    error: function (data) {
                        CTOK.push(false);
                        alert('El proceso no se pudo completar PLQ');
                        console.log(data);
                    }
                });

            }
            //REGISTRA CARTERA DE PAGO
            var carteraPAG = function () {
                //FECHA DOCUMENTO
                var element = Operacion.mask('txtFDOC').val();
                var fecha = element.split('/');
                var FECDOC = fecha[2].substr(2, 2) + "" + fecha[1] + "" + fecha[0];

                //FECHA VENCIMIENTO
                var element1 = Operacion.mask('txtFVEN').val();
                var fecha1 = element1.split('/');
                var FECVEN = fecha1[2].substr(2, 2) + "" + fecha1[1] + "" + fecha1[0];

                //FECHA REGISTRO
                var element2 = Operacion.mask('txtFVB').val();
                var fecha2 = element2.split('/');
                var FECVB = fecha2[2].substr(2, 2) + "" + fecha2[1] + "" + fecha2[0];

                //FECHA COMPROBANTE
                var element3 = Operacion.mask('txtFCOM').val();
                var fecha3 = element3.split('/');
                var FECCOM = fecha3[2].substr(2, 2) + "" + fecha3[1] + "" + fecha3[0];

                //FECHA CREACION
                var element4 = Operacion.mask('txtFCRE').val();
                var fecha4 = element4.split('/');
                var FECCRE = fecha4[2].substr(2, 2) + "" + fecha4[1] + "" + fecha4[0];

                //var MN = Operacion.mask('ddlMON').val();
                var MONTO = Operacion.mask('txtIMP').val();
                var MONTO_C = (MONTO / M_DATA[13]);
                var SALDO = "";
                var IGV = Operacion.mask('txtIGV').val();

                //var M_SDIARIO = Operacion.mask('ddlSUB').find('option:selected').text();
                //M_SDIARIO = M_SDIARIO.split(" ");
                //console.log(M_SDIARIO);
                var CDET = Operacion.mask('txtNDET').val();
                if (M_DATA[9] == "13") {
                    MADOC = [Operacion.mask('txtDOC').val(), Operacion.mask('txtNDET').val()];
                    FDC = ["", ""];//FECHA DOCUMENTO
                    FVEN = [FECVEN, FECVEN];
                    FCRE = [FECCRE, FECCRE];
                    FCOMP = [FECCOM, FECCOM];
                    CMON = [M_DATA[12], (M_DATA[12] == "US" ? "MN" : "MN")];
                    MIMP = ["", ""];
                    IUS = ["", ""];
                    IGMN = [Number(IGV).toFixed(2), 0];
                    IGUS = [Number(IGV / M_DATA[13]).toFixed(2), 0];
                    CPCTA = [M_DATA[23], ""];
                    MAREA = ['CG', 'CG'];
                    FUB = ["", ""];
                    TDR = ['VB', 'FT'];
                    AND = [M_DATA[3], M_DATA[3]];
                    MFD = ["", FECDOC];
                    INF = [Operacion.mask('txtINAF').val()];
                    FDCD = [moment(element, 'DD/MM/YYYY'), ""];
                    FVEND = ["", ""];
                    FCOMPD = [moment(element3, 'DD/MM/YYYY'), ""];
                    FCRED = [moment(element4, 'DD/MM/YYYY'), ""];
                    FUBD = [moment(element3, 'DD/MM/YYYY'), ""];
                    PDES = [M_DATA[35]];//DESCRIPCION PROVEEDOR
                    ACD = ["", Operacion.mask('txtCTAS').val()];
                    ASE = ["", "0003"];
                    ACC = ["", ""];
                    CRET = [MI_DETALLE[M_DATA[23]][22], ""];//CODIGO RETENCION
                    PRET = [MI_DETALLE[M_DATA[23]][23], ""];//PORCENTAJE RETENCION
                } else {
                    MADOC = [Operacion.mask('txtDOC').val()];
                    FDC = [FECDOC];//FECHA DOCUMENTO
                    FVEN = [FECVEN];//--------------------------------------------------------CP_CFECVEN
                    FCRE = [FECCRE];//--------------------------------------------------------CP_CFECREC
                    FCRE_D = [moment(element4, 'DD/MM/YYYY')];
                    FCOMP = [FECCOM];
                    CMON = [M_DATA[12]];
                    MIMP = [(CMON[0] == "MN" ? MONTO : Operacion.mround(MONTO * M_DATA[13], 2))];
                    IUS = [(CMON[0] == "MN" ? Operacion.mround(MONTO / M_DATA[13], 2) : MONTO)];
                    //SMN = [Operacion.mask('txtIGV').val()];
                    //SUS = [Operacion.mask('txtRNPA').val() / Operacion.mask('txtTIC').val()];
                    IGMN = [(CMON[0] == "MN" ? IGV : Operacion.mround(IGV * M_DATA[13], 2))];
                    IGUS = [(CMON[0] == "MN" ? Operacion.mround(IGV / M_DATA[13], 2) : IGV)];
                    CPCTA = [M_DATA[23]];
                    MAREA = [M_DATA[24]];
                    FUB = [FECCOM];//FECHA UBICACION
                    TDR = ['OC'];
                    AND = [M_DATA[27]];
                    MFD = [FECVB];//M_DATA[28]
                    INF = [Operacion.mask('txtINAF').val()];
                    FDCD = [moment(element, 'DD/MM/YYYY')];
                    FVEND = [moment(element1, 'DD/MM/YYYY')];
                    FCOMPD = [moment(element3, 'DD/MM/YYYY')];
                    FCRED = [moment(element2, 'DD/MM/YYYY')];//MFD VB
                    FUBD = [moment(element3, 'DD/MM/YYYY')];
                    PDES = [M_DATA[35]];//DESCRIPCION PROVEEDOR
                    ACD = [""];//CUENTAS DETALLE
                    ASE = [""];
                    ACC = [""];
                    CRET = [MI_DETALLE[M_DATA[23]][22]];//CODIGO RETENCION
                    PRET = [MI_DETALLE[M_DATA[23]][23]];//PORCENTAJE RETENCION
                }

                for (i = 0; i < MADOC.length; i++) {

                    var CDATA = {};
                    CDATA.CP_CVANEXO = M_DATA[0];
                    CDATA.CP_CCODIGO = M_DATA[1].trim();//Operacion.mask('lblDNI').text().trim();
                    CDATA.CP_CTIPDOC = M_DATA[2];
                    CDATA.CP_CNUMDOC = MADOC[i];//CASO FT:(NDOC|NDOC-D)
                    CDATA.CP_CFECDOC = FDC[i];//FECHA DOCUMENTO
                    CDATA.CP_CFECVEN = FVEN[i];//FECHA DE VENCIMIENTO
                    CDATA.CP_CFECREC = FCRE[i];//FECHA CREACION
                    CDATA.CP_CSITUAC = "C";//CONTABILIZADA
                    CDATA.CP_CFECCOM = FCOMP[i];//FECCOM[i];
                    CDATA.CP_CSUBDIA = M_DATA[9];
                    CDATA.CP_CCOMPRO = COMP;
                    CDATA.CP_CDEBHAB = "H";
                    CDATA.CP_CCODMON = CMON[i];//PAR['QTIPMON'];
                    CDATA.CP_NTIPCAM = M_DATA[13];//TIPO CAMBIO
                    CDATA.CP_NIMPOMN = MIMP[i];
                    CDATA.CP_NIMPOUS = IUS[i];
                    CDATA.CP_NSALDMN = MIMP[i];
                    CDATA.CP_NSALDUS = IUS[i];
                    CDATA.CP_NIGVMN = IGMN[i];
                    CDATA.CP_NIGVUS = IGUS[i];
                    CDATA.CP_NIMP2MN = 0;//R
                    CDATA.CP_NIMP2US = 0;//R
                    CDATA.CP_NIMPAJU = 0;//R
                    CDATA.CP_CCUENTA = CPCTA[i];
                    CDATA.CP_CAREA = MAREA[i];
                    CDATA.CP_CFECUBI = FUB[i]
                    CDATA.CP_CTDOCRE = TDR[i];
                    CDATA.CP_CNDOCRE = AND[i];
                    CDATA.CP_CFDOCRE = MFD[i];
                    CDATA.CP_CTDOCCO = "";
                    CDATA.CP_CNDOCCO = "";
                    CDATA.CP_CFDOCCO = "";
                    CDATA.CP_CFECPRO = "";
                    CDATA.CP_CFORMPG = "";
                    CDATA.CP_CCOGAST = "";//R:
                    CDATA.CP_CDESCRI = PDES[i];//R:Operacion.mask('txtDPRO').val().substring(0, 20);
                    CDATA.CP_DFECCRE = FCRED[i];
                    CDATA.CP_DFECMOD = null;
                    CDATA.CP_CUSER = Operacion.mask('hdUSUARIO').val();
                    CDATA.CP_NINAFEC = INF[i];
                    CDATA.CP_CTIPSUN = "";
                    CDATA.CP_DFECDOC = FDCD[i];
                    CDATA.CP_DFECVEN = FVEND[i];//--------------------------------------------------CP_CFECVEN
                    CDATA.CP_DFECREC = FCRE_D[i];//-------------------------------------------------CP_CFECREC
                    CDATA.CP_DFECCOM = FCOMPD[i];
                    CDATA.CP_DFDOCRE = FCRED[i];
                    CDATA.CP_DFDOCCO = null;
                    CDATA.CP_DFECPRO = null;
                    CDATA.CP_DFECUBI = FUBD[i];//FECCRE;
                    CDATA.CP_CIMAGEN = 0;//POR DEFECTO 0:NO SELECCIONADO NINGUNA IMAGEN
                    CDATA.CP_CVANERF = "";
                    CDATA.CP_CCODIRF = "";
                    CDATA.CP_CNUMORD = "";
                    CDATA.CP_CTIPO = "";
                    CDATA.CP_CFECCAM = "";
                    CDATA.CP_DFECCAM = null;
                    CDATA.CP_CTASDET = ACD[i];
                    CDATA.CP_CSECDET = ASE[i];
                    CDATA.CP_CCENCOR = ACC[i];
                    CDATA.CP_CRETE = CRET[i];//CODIGO RETENCION
                    CDATA.CP_NPORRE = PRET[i];//PORCENTAJE RETENCION
                    //console.log(CDATA);
                    $.ajax({
                        type: "POST",
                        url: "../../ALMACEN/LiquidacionCompra.aspx/guardarCART",
                        data: '{ CDATA: ' + JSON.stringify(CDATA) + '}',
                        contentType: "application/json;charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (data) {
                            asientoCAB();
                        },
                        error: function (data) {
                            CTOK.push(false);
                            alert('El proceso no se pudo completar CART');
                            console.log(data);
                        }
                    });

                }
            }
            //R/A PE-CART. PAGOS-COMPROBANTE - COMPROBANTE
            var registroCOC = function () {
                //REGISTRA CARTERA PAGOS
                correlativoCP();
                carteraPAG();
                (M_PAR[7] != "S" ? "" : registraPAG());
                //alert('Se registro el documento');
            }
            //VERIFICA CALCULO COMPRA
            var verificaCC = function () {
                var M_VALOR = Operacion.mask('hfIMT').val();
                Operacion.mask('txMPE').val(Number(M_VALOR).toFixed(2));//PARTE ENTRADA
                var M_VALOR1 = Operacion.mask('txtVCDE').val();//Operacion.mask('txtVCCA').val();
                Operacion.mask('txtMOC').val(Number(M_VALOR1).toFixed(2));//VALOR OC
                var RESULTADO = Number(M_VALOR1) - Number(M_VALOR);
                Operacion.mask('txtMDI').val(RESULTADO.toFixed(2));
                var M_IGV = Operacion.mask('txtIGV').val();//IMPORTE FT PANTALLA1
                var M_TOT = Operacion.mask('txtIMP').val();//IMPORTE FT PANTALLA2
                Operacion.mask('txtMIGV').val(M_IGV);
                Operacion.mask('txtMTOT').val(M_TOT);
                dialog2.dialog("open");
            }
            //GUARDAR CABECERA 
            var guardarVB = function () {
                var MI_POR = Number(Operacion.mask('lblPOR').text());
                //PASO 1: REGISTRO DOCUMENTO CON VoBo
                //if (valida() && MI_POR >= 0 && Operacion.mask('txtVTIC').val() != "" && Number(Operacion.mask('txtIMP').val()) > 0) {
                if (valida() && MI_POR >= 0 && Number(Operacion.mask('txtIMP').val()) > 0) {
                    var MN = Operacion.mask('ddlMON').val();
                    var M_COSU = Operacion.mask('ddlSUB').find('option:selected').text();
                    M_COSU = M_COSU.split(" ");
                    var M_COCO = Operacion.mask('ddlCOC').find('option:selected').text();
                    M_COCO = M_COCO.split(" ");

                    M_DATA[0] = Operacion.mask('ddlACR').val();//TIPO ACREEDOR
                    M_DATA[1] = Operacion.mask('txtCOD').val();//CODIGO PROVEEDOR
                    M_DATA[2] = Operacion.mask('ddlTDOC').val();//TIPO DOCUMENTO
                    M_DATA[3] = Operacion.mask('txtDOC').val();//NRO DOCUMENTO
                    M_DATA[9] = M_COSU[0];//M_SDIARIO[0];//V1:NO NECESITA|V2:SI SE REGISTRA
                    M_DATA[12] = MN;//MONEDA
                    M_DATA[13] = Operacion.mask('txtVTIC').val();//VALOR TIPO CAMBIO;
                    //M_DATA[14] = 
                    M_DATA[18] = "";//IGV;
                    M_DATA[23] = M_COCO[5];//CODIGO COMPRA
                    M_DATA[24] = Operacion.mask('ddlDEPA').val();//AREA
                    M_DATA[26] = Operacion.mask('ddlDRE').val();//
                    M_DATA[27] = Operacion.mask('txtNDR').val();
                    M_DATA[28] = Operacion.mask('txtFCRE').val();
                    M_DATA[35] = Operacion.mask('lblCodigo').text().substring(0, 18);
                    M_DATA[41] = Operacion.mask('txtFDOC').val();//FECHA DOCUMENTO
                    M_DATA[42] = Operacion.mask('txtFVEN').val();//FECHA VENCIMIENTO
                    M_DATA[45] = Operacion.mask('txtFCOM').val();//FECHA COMPROBANTE
                    //M_DATA[61] = Operacion.mask('txtIGV').val();//IMPORTE IGV
                    //M_DATA[62] = Operacion.mask('txtIMP').val();//IMPORTE TOTAL
                    //M_DATA[59] = Operacion.mask('').text();
                    //M_DATA[60] = Operacion.mask('').text();
                    //M_DATA[61]="";
                    //M_DATA[62]="";
                    M_DATA[63] = Operacion.mask('ddlTCON').val();//TIPO CONVERSION

                    detalleCO();
                    //console.log(M_DATA);
                } else {
                    alert('Debe completar los campos requeridos');
                }
            }
            //DETALLE ORDEN COMPRA
            var detalleOC = function (op) {
                var DATA = {};
                DATA.OC_CNUMORD = Operacion.mask('txtNDR').val();//OC;
                //console.log(OC);
                $.ajax({
                    url: "ContabilizaDOC.aspx/GetListaDetalle",
                    data: '{DATA:' + JSON.stringify(DATA) + '}',
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    async: false,
                    success: function (data) {
                        var sum = 0;
                        if (op == "1") {
                            $.each(data.d, function (i, v) {
                                var M_ST = (v.OC_NDESCTO);
                                AD[v.OC_CCODIGO.trim()] = M_ST;
                            });
                        } else {
                            /*$.each(data.d, function (i, v) {
                            var M_ST = (v.OC_NCANORD * v.OC_NPREUN2);
                            AT.push(v.OC_CCODIGO.trim());
                            ATP[v.OC_CCODIGO.trim()] = M_ST;
                            table.append($('<tr style=color:#000066;></tr>')
                                 .append($('<td>' + v.OC_CITEM + '</td>'))
                                 .append($('<td>' + v.OC_CCODIGO + '</td>'))
                                 .append($('<td>' + v.OC_CDESREF + '</td>'))
                                 .append($('<td>' + v.OC_CUNIDAD + '</td>'))
                                 .append($('<td>' + Number(v.OC_NCANORD).toFixed(2) + '</td>'))
                                 .append($('<td>' + Number(v.OC_NPREUNI).toFixed(2) + '</td>'))
                                 .append($('<td>' + Number(IMP).toFixed(2) + '</td>'))
                                 .append($('<td>' + M_PAR[4] + '</td>'))
                                 );
                            $('#MainContent_gvDetalle').append(table);
                            sum += M_ST;
                        });
                        var M_IGV = (sum * (M_PAR[1] / 100));
                        M_DATA[61] = Operacion.mround(M_IGV, 2);
                        var M_TOTAL = Number(sum) + Number(M_IGV);
                        M_DATA[62] = Operacion.mround(M_TOTAL, 2);
                        Operacion.mask('txtIGV').val(M_IGV);
                        Operacion.mask('txtIMP').val(M_TOTAL);
                        misubtotal(M_IGV, M_TOTAL);*/
                        }

                    },
                    error: function (data) {
                        console.log(data);
                    }
                });
            }
            //OBTENER OC AUTOMATICA
            var completarOC = function (OC) {
                var M_FECHA = moment().format('DD/MM/YYYY');
                //console.log(M_FECHA);
                Operacion.mask('txtFCRE').val(M_FECHA);
                Operacion.mask('txtFREC').val(M_FECHA);
                Operacion.mask('txtFVB').val(M_FECHA);

                var DATA = {};
                DATA.OC_CNUMORD = OC;
                DATA.OC_CSITORD = "0";

                $.ajax({
                    url: "ContabilizaDOC.aspx/mioc",
                    data: '{DATA:' + JSON.stringify(DATA) + '}',
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    async: false,
                    success: function (data) {
                        //console.log(data);
                        if (data.d != null) {
                            $.each(data, function (i, v) {
                                var M_FACTUAL = moment(v.OC_DFECDOC).format('DD/MM/YYYY');
                                Operacion.mask('txtCOD').val(v.OC_CCODPRO);
                                verificaACR(v.OC_CCODPRO);
                                Operacion.mask('lblCodigo').text(v.OC_CRAZSOC);
                                Operacion.mask('txtDIA').val();
                                Operacion.mask('ddlMON').val(v.OC_CCODMON);
                                M_PAR[4] = v.OC_CCODMON;
                                M_PAR[5] = v.OC_CALMDES;//ALMACENES--------------|
                                M_PAR[6] = v.OC_CSITORD;//SITUACION ORDEN
                                M_PAR[7] = v.OC_CTIPORD;//TIPO ORDEN
                                M_PAR[8] = v.OC_CCOSTOC;//CENTRO COSTO
                                M_PAR['DSCTO'] = v.OC_CCONVTA.trim();//SI TIENE DESCUENTO
                                //console.log(M_PAR);
                                iniciaCOC(v.OC_CCODMON);//CUENTAS X MONEDA
                                iniciaSUB();//SUBDARIO
                                Operacion.mask('txtFDOC').val(M_FACTUAL);
                                Operacion.mask('txtFBAS').val(M_FACTUAL);
                                var M_VALOR = (v.OC_CCODMON.trim() == "US" ? v.OC_NIMPUS : v.OC_NIMPMN);
                                var M_IGV = M_PAR[1];
                                var M_CIGV = (M_VALOR / ((M_IGV / 100) + 1)) * (M_IGV / 100);
                                M_PAR[5] = M_CIGV;//PARAMETROS
                                //Operacion.mask('txtIGV').val(Number(M_CIGV).toFixed(2));
                                Operacion.mask('txtTIGV').val(M_IGV);
                                //Operacion.mask('txtIMP').val(Number(M_VALOR).toFixed(2));
                                //Operacion.mask('txtVCDE').val((Number(M_VALOR) - Number(M_CIGV)).toFixed(2));
                                //Operacion.mask('txtVCCA').val((Number(M_VALOR) - Number(M_CIGV)).toFixed(2));
                                M_DIAS = v.OC_CFORPA1;
                                var M_NDIA = M_DIAS.split(" ");
                                var N_DIA = (M_DIAS.trim() == "AL CONTADO" || M_DIAS.trim() == "CONTADO" || M_DIAS.trim() == "PAGO ADELANTADO" || M_DIAS.trim() == "" ? 0 : M_NDIA[((M_DIAS.indexOf('DIFERIDO') != -1 ? 2 : 1))]);
                                Operacion.mask('txtDIA').val(N_DIA);
                                var SFECHA = Operacion.sumaFecha(N_DIA, M_FACTUAL);
                                Operacion.mask('txtFVEN').val(SFECHA);
                                //NUEVO:02.06.16--
                                //console.log(M_PAR[7]);
                                //console.log(typeof M_PAR['DSCTO']);
                                //VALIDACION ORDENES
                                if (M_PAR[7] != "S") {
                                    //CASO CON DESCUENTO
                                    (M_PAR['DSCTO'] == "S" ? detalleOC("1") : "");
                                    //PARTE DE ENTRADA
                                    iniciaPEOC();
                                    $('.tr_oculta3').show();
                                } else {
                                    //S:SERVICIOS
                                    detalleOC("2");
                                    $('.tr_oculta3').hide();//OCULTAR OPCIONES PARA O/C
                                }
                            });
                            Operacion.mask('txtFCOM').focus();
                        } else {
                            alert('No existe la O/C');
                        }
                    },
                    error: function (data) {
                        console.log(data);
                    }
                });
            }

            //REGISTRO
            dialog = $("#Creacion").dialog({
                autoOpen: false,
                height: 'auto',
                width: 'auto',
                modal: true,
                buttons: {
                    "Continuar": function () {
                        var VERIFICA = Operacion.mask('hfIMT').val();
                        var VFVEN = (Operacion.mask('txtFVEN').val().indexOf('NaN') != -1 ? false : true);
                        if (VERIFICA != "" && VERIFICA != null && VERIFICA != 0 && VFVEN == true) {
                            verificaCC();
                        } else {
                            valida();
                        }
                        //guardarVB()
                    },
                    "Cancelar": function () {
                        dialog.dialog("close");
                        Operacion.mask('cblPE').empty();
                        Operacion.mask('gvDetalle').empty();
                        iniciaCOC("");
                        limpiar();
                    }
                },
                close: function () {
                    limpiar();
                    Operacion.mask('cblPE').empty();
                    Operacion.mask('gvDetalle').empty();
                }
            });
            //PARTE ORDEN COMPRA--- PENDIENTE UTILIZAR
            dialog1 = $("#POC").dialog({
                autoOpen: false,
                height: 'auto',
                width: '847px',
                modal: true,
                buttons: {
                    "Continuar": function () {
                        /*var VERIFICA = Operacion.mask('hfIMT').val();
                        if (VERIFICA != "" && VERIFICA != null && VERIFICA != 0) {
                            verificaCC();
                        }*/
                    },
                    "Cancelar": function () {
                        dialog1.dialog("close");
                    }
                },
                close: function () {
                    //limpiar();
                }
            });
            //CALCULO COMPRA
            dialog2 = $("#PCC").dialog({
                autoOpen: false,
                height: 'auto',
                width: '300px',
                modal: true,
                buttons: {
                    "Continuar": function () {
                        var M_DHC = Operacion.mask('txtMDI').val();//MI DIFERENCIA
                        var MI_SW = (Number(M_DHC) == 0 ? true : (Number(M_DHC) > 0 && Number(M_DHC) <= 0.10 ? true : (Number(M_DHC) == -0.01 ? true : false)));
                        if (MI_SW) {
                            dialog2.dialog("close");
                            guardarVB();
                        } else {
                            alert('Verificar Parte de entrada');
                        }
                        //verificaCC();//ORIGINAL
                        //detalleCO(); SIN USO 02.06.15
                    },
                    "Cancelar": function () {
                        dialog2.dialog("close");
                    }
                },
                close: function () {
                    //limpiar();
                }
            });
            //REGISTRO FINAL
            dialog3 = $("#DCO").dialog({
                autoOpen: false,
                height: 'auto',
                width: '860px',
                modal: true,
                buttons: {
                    "Finalizar": function () {
                        var M_DHC = Operacion.mask('txtDC_DI').val();//MI DEBE HABE CONTROL
                        //var MI_SW = (Number(M_DHC) == 0 ? 0 : (Number(M_DHC) > 0 && Number(M_DHC) <= 0.10 ? 1 : 3));
                        var MI_SW = (Number(M_DHC) == 0 ? 0 : (Number(M_DHC) > 0 && Number(M_DHC) <= 0.10 ? 1 : (Number(M_DHC) == -0.01 ? 1 : 3)));
                        if (jQuery.inArray(false, CTOK) == -1) {
                            //var VALIDA=Operacion.mask('txtDC_DI').val();
                            switch (Number(MI_SW)) {
                                case 0:
                                    if (M_PAR[7] != "S") {
                                        registroCOC();//FINALIZA
                                    } else {
                                        alert('Comprobante generado');
                                        location.reload();
                                    }
                                    break;
                                case 1:
                                    //alert(1);
                                    if (M_PAR[7] != "S") {
                                        if (confirm('Existe diferencia de ' + M_DHC + ' en el comprobante, desea considerarlo')) {
                                            registroCOC();//FINALIZA
                                        }
                                    } else {
                                        alert('Comprobante generado');
                                        location.reload();
                                    }
                                    break;
                                default:
                                    //console.log(M_DHC);
                                    alert('El comprobante tiene diferencia:\n Verificar:\n(1)Cuenta existencia \n(2)Cuenta Compra \n(3)Configuracion de D/H');
                                    break;
                            }
                        } else {
                            alert('El registro tienes inconsistencias, verificar operaciones');
                        }
                    },
                    "Cancelar": function () {
                        dialog3.dialog("close");
                        //dialog.dialog("close");
                        //dialog1.dialog("close");
                        //dialog2.dialog("close");
                        //$(this).dialog("close");
                        IDX.length;
                        //Operacion.mask('cblPE').empty();
                        //Operacion.mask('gvDetalle').empty();
                        //limpiar();
                        //location.reload();
                    }
                },
                close: function () {
                    //$(this).dialog("close");
                    //dialog3.dialog("close");
                    //dialog.dialog("close");
                    IDX.length;
                    //Operacion.mask('cblPE').empty();
                    //Operacion.mask('gvDetalle').empty();
                    //limpiar();
                    //location.reload();
                }
            });
            Operacion.oDialog('Comprobante', false);
            $(".ac_nd").autocomplete(
                {
                    source: function (request, response) {
                        var TM = Operacion.mask('txtIDMOV').val();
                        var DATA = {};
                        DATA.TCOD = "05";
                        $.ajax({
                            url: "ContabilizaDOC.aspx/listarTG",
                            data: '{DATA:' + JSON.stringify(DATA) + '}',
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            dataFilter: function (data) { return data; },
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        value: item.TDESCRI,
                                        id: item.TCLAVE
                                    }
                                }))
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                console.log(textStatus);
                            }
                        });
                    },
                    minLength: 1,
                    select: function (event, ui) {
                        var str = ui.item.id;//, str1 = ui.item.value;
                        Operacion.mask('txtCCID').val(str);
                        //Operacion.mask().val(str1);
                    }
                });
            //CENTRO COSTO
            $(".ac_cc").autocomplete(
                {
                    source: function (request, response) {
                        var TM = Operacion.mask('txtIDMOV').val();
                        var DATA = {};
                        DATA.TCOD = "05";
                        $.ajax({
                            url: "ContabilizaDOC.aspx/listarTG",
                            data: '{DATA:' + JSON.stringify(DATA) + '}',
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            dataFilter: function (data) { return data; },
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        value: item.TDESCRI,
                                        id: item.TCLAVE
                                    }
                                }))
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                console.log(textStatus);
                            }
                        });
                    },
                    minLength: 1,
                    select: function (event, ui) {
                        var str = ui.item.id;//, str1 = ui.item.value;
                        Operacion.mask('txtCCID').val(str);
                        //Operacion.mask().val(str1);
                    }
                });

            //INICIALIZA--------------------------
            iniciaPEOC();
            Operacion.iValida('txtNDR', 1);
            //alert(ID);
            if (ID != "" && ID != null) {
                Operacion.mask('txtNDR').val(ID);
                iniciaRE();
                completarOC(ID);
            } else {
                alert(typeof ID);
            }

            //CODIGO OC
            /*Operacion.mask('txtNDR').change(function () {
                //limpiar();
                completarOC($(this).val());
                //detalleOC($(this).val());
            });*/
            $('#btnNuevo').click(function () {
                iniciaRE();
            });
            Operacion.mask('txtFCOM').change(function () {
                var FD = moment(Operacion.mask('txtFDOC').val(), 'DD/MM/YYYY');
                var FC = moment($(this).val(), 'DD/MM/YYYY');//'YYYYDDMM');
                //console.log(Number(FD));
                //console.log(Number(FC));
                if (Number(FC) < Number(FD)) {
                    alert('La fecha del comprobante, no debe ser menor al documento');
                    bloqueoFE($(this).val());
                } else {
                    bloqueoFE($(this).val());
                }
            });
            Operacion.mask('txtFDOC').change(function () {
                var MTC = moment($(this).val(), 'DD-MM-YYYY');//FECHA ELEGIDA
                var MTC1 = moment($(this).val()).format('YYYYDDMM');//FECHA ELEGIDA NUMEROS
                var TCA = moment().format('YYYYMMDD');//FECHA ACTUAL

                //-----------------------------------------------
                var M_FACTUAL = $(this).val();
                var M_NDIA = M_DIAS.split(" ");
                var N_DIA = (M_DIAS.trim() == "AL CONTADO" || M_DIAS.trim() == "CONTADO" || M_DIAS.trim() == "PAGO ADELANTADO" || M_DIAS.trim() == "" ? 0 : M_NDIA[((M_DIAS.indexOf('DIFERIDO') != -1 ? 2 : 1))]);
                Operacion.mask('txtDIA').val(N_DIA);
                var SFECHA = Operacion.sumaFecha(N_DIA, M_FACTUAL);
                Operacion.mask('txtFVEN').val(SFECHA);

                //var MTC = moment($(this).val(), 'DD-MM-YYYY');//FECHA ELEGIDA
                //var MTC1 = moment($(this).val()).format('YYYYDDMM');//FECHA ELEGIDA
                CODATA.XFECCAM2 = MTC;
                var TC = (Number(MTC1) == Number(TCA) ? "V" : "F");
                //console.log(TC);
                Operacion.mask('ddlTCON').val(TC);
                Operacion.mask('txtFCAM').val($(this).val());
                iniciaTC(CODATA, TC);
                Operacion.mask('txtBNPE').focus();

            });
            $('input:radio[name=rb]').click(function () {
                CODATA.XFECCAM2 = moment(Operacion.mask('txtFCAM').val(), 'DD-MM-YYYY');
                iniciaTC(CODATA, $(this).val());
                //$('.tr_oculta1').hide();
            });
            Operacion.mask('ddlTCON').change(function () {
                CODATA.XFECCAM2 = moment(Operacion.mask('txtFCOM').val(), 'DD-MM-YYYY');
                if ($(this).val() == "C") {
                    //ESPECIAL
                    Operacion.inputRead('txtVTIC', 0);
                    Operacion.mask('txtVTIC').val('0.000');
                    //Operacion.inputEstado('txtVTIC', 0, true);
                    Operacion.mask('txtVTIC').focus();
                    Operacion.mask('txtFCAM').val("");
                } else if ($(this).val() == "F") {
                    //FECHA
                    Operacion.inputRead('txtVTIC', 1);
                    Operacion.mask('txtVTIC').val('0.000');
                    Operacion.inputEstado('txtFCAM', 0, true);
                    Operacion.mask('txtFCAM').focus();
                    $('.tr_oculta1').show();
                } else if ($(this).val() == "M") {
                    //COMPRA
                    iniciaTC(CODATA, $(this).val());
                    Operacion.inputEstado('txtFCAM', 1, true);
                    $('.tr_oculta1').hide();
                    Operacion.inputRead('txtVTIC', 1);
                    Operacion.mask('txtFCAM').val("");
                } else if ($(this).val() == "V") {
                    //VENTA
                    iniciaTC(CODATA, $(this).val());
                    Operacion.inputRead('txtVTIC', 1);
                    Operacion.inputEstado('txtFCAM', 1, true);
                    $('.tr_oculta1').hide();
                    Operacion.mask('txtFCAM').val("");
                }

                /*Operacion.mask('txtGCOM').val('');
                Operacion.mask('txtGMOV').val('');

                var M_TDOC = Operacion.mask('ddlTDOC').val();
                var N_DOC = Operacion.mask('txtDOC').val();
                var N_PRO = Operacion.mask('lblCodigo').text().substr(0, 15);
                var G_COM = N_PRO + "," + M_TDOC + " " + N_DOC;

                Operacion.mask('txtGCOM').val(G_COM);
                Operacion.mask('txtGMOV').val(G_COM);*/
            });
            Operacion.mask('ddlSUB').change(function () {
                validaSUB();
            });
            Operacion.mask('txtTTAS').change(function () {
                iniciaTITA($(this).val());
                //NUEVO:10.06.2016
                var G_COM = "OC " + Operacion.mask('txtNDR').val() + " " + Operacion.mask('lblCodigo').text().substring(0, 9);// + " " + N_DOC;
                var G_COMD = "";
                Operacion.mask('txtGCOM').val(G_COM);
                Operacion.mask('txtGMOV').val(G_COMD);
            });
            $("[id*=MainContent_cblPE]").live("click", function () {
                if ($(this).is(':checked') == true) {
                    $(this).each(function () {
                        var value = $(this).val();//VALOR
                        //console.log(value);
                        IDX.push(value);
                        iniciaGrilla(value);//INICIA CALCULO X PE ELEGIDOS
                        //console.log(IDX);
                    });
                } else if ($(this).val() != "") {
                    //LIMPIO ITEMS QUE NO HE ELEGIDO
                    var data = [];
                    data["d"] = 0;
                    //iniciaGrilla(data);
                    var remove = $(this).val();
                    IDX = jQuery.grep(IDX, function (value) {
                        return value != remove;
                    });
                    Array.prototype.remove = function (v) { this.splice(this.indexOf(v) == -1 ? this.length : this.indexOf(v), 1); }
                    AT.remove(remove);
                    iniciaGrilla($(this).val());
                }
            });
            Operacion.mask('txtDOC').change(function () {
                verificaDOC($(this).val());
            });
            Operacion.mask('txtBNPE').keypress(function () {
                var s = $(this).val().toUpperCase().split(" ");
                $(".buscar tr:hidden").show();
                $.each(s, function () {
                    $(".buscar tr:visible .pe:not(:contains('" + this + "'))").parent().hide();
                });
            });
            $('#btnAjustar').click(function () {

            });
            //CALCULO VCC-VCC
            //Operacion.mask('txtIMP').change(function () {
            //    var M_CALCULO = Operacion.mask('txtIGV').val();
            //    var M_TOTAL = $(this).val();
            //    var M_VCD = Number(M_TOTAL) - Number(M_CALCULO);
            //    Operacion.mask('txtVCDE').val(M_VCD.toFixed(2));
            //    var M_OC = Operacion.mask('txtNDR').val();
            //    detalleOC(M_OC);
            //    Operacion.mask('txtINAF').val(Number(M_PAR[5]-M_VCD).toFixed(2));
            //});
            $('.btDetalle').live("click", function () {
                //Operacion.oDialog('Comprobante', true);
                ND = $(this).attr("id");
                Operacion.mask('txtPOC_OC').val(ND);
                iniciaPEDE(ND);
                //var M_PR = Operacion.mask('txtCOD').val()
                //Operacion.mask('txtPOC_P').val(M_PR);
                iniciaTooltip();
                dialog1.dialog("open");
            });
            //Operacion.mask().change
            Operacion.mask('cbVR').live('change', function () {
                if (Operacion.mask('cbVR').is(':checked')) {
                    Operacion.inputEstado('txtMBAS', 0, true);
                } else {
                    Operacion.inputEstado('txtMBAS', 1, true);
                }
            });
        });
    </script>
    <style type="text/css">
        #contenedor {
            width: 1120px;
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
        <asp:HiddenField ID="codM1" runat="server" />
        <asp:HiddenField ID="codM2" runat="server" />
        <asp:HiddenField ID="codM3" runat="server" />
        <fieldset style="width: 1075px; display: none;">
            <legend>VB.Documentos</legend>
            <table>
                <tr>
                    <td>Centro Costo Referencia</td>
                    <td>
                        <asp:TextBox ID="txtCCID" runat="server" Width="60px" AutoPostBack="true" OnTextChanged="txtCCID_TextChanged"></asp:TextBox>
                        <asp:TextBox ID="txtCCDE" class="ac_cc" runat="server" Width="313px" AutoPostBack="true" OnTextChanged="txtCCDE_TextChanged"></asp:TextBox>
                    </td>
                    <td>Departamento</td>
                    <td>
                        <asp:DropDownList ID="ddlDEP" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDEP_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td></td>
                    <td>
                        <asp:CheckBox ID="cbVB" Text="VB" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <input id="btnNuevo" class="btn" type="button" value="Nuevo" /></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>
                </tr>
                <tr>
                    <td colspan="6">
                        <asp:GridView ID="gvDOC" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" Width="113%" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                            <Columns>
                                <asp:BoundField DataField="CP_CVANEXO" HeaderText="Agencia" ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="50" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CP_CCODIGO" HeaderText="Codigo" ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" />
                                    <ItemStyle Font-Size="8pt" Width="50" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NOMTIT" HeaderText="Nombre" ItemStyle-HorizontalAlign="Left">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="Left" Width="20px" Wrap="False" />
                                    <ItemStyle Font-Size="8pt" Width="110px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CP_CTIPDOC" HeaderText="T.Doc" ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="35" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CP_CNUMDOC" HeaderText="Num. Dcto" ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="20px" />
                                    <ItemStyle Font-Size="8pt" Width="20px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CP_CCODMON" HeaderText="Moneda" ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="50" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="IMPORTE" HeaderText="Importe" ItemStyle-HorizontalAlign="right">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" />
                                    <ItemStyle Font-Size="8pt" Width="40px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CP_CTDOCRE" HeaderText="TDR" ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="30" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CP_CNDOCRE" HeaderText="Num. Doc Ref." ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="30" />
                                    <ItemStyle Font-Size="8pt" Width="30" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CP_DFDOCRE" HeaderText="Fecha VB°" ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="10" />
                                    <ItemStyle Font-Size="8pt" Width="10" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CENCOR" HeaderText="Centro Costo Ref" ItemStyle-HorizontalAlign="Left">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="Left" Width="20" />
                                    <ItemStyle Font-Size="8pt" Width="110px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NOMARE" HeaderText="Dpto" ItemStyle-HorizontalAlign="Left">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="Left" Width="40" />
                                    <ItemStyle Font-Size="8pt" Width="40" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CP_CSITUAC" HeaderText="Situacion" ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="50" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="60" />
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
            </table>
        </fieldset>
        <div id="Creacion" title="Creación">
            <table>
                <tr>
                    <td>Doc Refencia</td>
                    <td>
                        <asp:DropDownList ID="ddlDRE" runat="server" Style="width: 170px">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                    <td>Numero Doc Ref.</td>
                    <td>
                        <!--class="ac_nd" -->
                        <asp:TextBox ID="txtNDR" MaxLength="11" TabIndex="0" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Código Compra</td>
                    <td colspan="3">
                        <asp:DropDownList ID="ddlCOC" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Subdiario&nbsp;&nbsp;</td>
                    <td colspan="3">
                        <asp:DropDownList ID="ddlSUB" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Comprobante</td>
                    <td>
                        <asp:TextBox ID="txtNCOM" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>Fecha Registro&nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtFCOM" class="dp1" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Departamento&nbsp;&nbsp;</td>
                    <td>
                        <asp:DropDownList ID="ddlDEPA" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                    <td>Fecha Recepción</td>
                    <td>
                        <asp:TextBox ID="txtFREC" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">&nbsp;</td>
                </tr>
                <tr>
                    <td>Tipo Acreedor</td>
                    <td>
                        <asp:DropDownList ID="ddlACR" runat="server" Style="width: 170px">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Codigo</td>
                    <td>

                        <asp:TextBox ID="txtCOD" class="ac_cod" runat="server"></asp:TextBox>

                    </td>
                    <td colspan="3">
                        <input id="btnCodigo" type="button" value="..."><asp:Label ID="lblCodigo" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Retención</td>
                    <td>
                        <!--<asp:Label ID="lblDES" runat="server" Text=""></asp:Label>-->
                        <asp:Label ID="lblPOR" runat="server" Text=""></asp:Label>
                        %</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Documento&nbsp;</td>
                    <td>
                        <asp:DropDownList ID="ddlTDOC" runat="server" Style="width: 170px;">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDOC" runat="server"></asp:TextBox>
                    </td>
                    <td>Fecha Dcmto./Emisión</td>
                    <td>
                        <asp:TextBox ID="txtFDOC" class="dp2" TabIndex="1" onkeypress="Operacion.MEKPAT(event,this)" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Fecha Base</td>
                    <td>
                        <asp:TextBox ID="txtFBAS" runat="server"></asp:TextBox>
                    </td>
                    <td>Dias&nbsp;<asp:TextBox ID="txtDIA" runat="server" Width="40px"></asp:TextBox>
                    </td>
                    <td>Fecha Vmto.</td>
                    <td>
                        <asp:TextBox ID="txtFVEN" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">&nbsp;</td>
                </tr>
                <tr class="tr_oculta3">
                    <td colspan="2">Parte de Entrada O/C<asp:TextBox ID="txtBNPE" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr class="tr_oculta3">
                    <td colspan="5">
                        <div id="cblPET" style="width: 840px; width: 840px; overflow-y: scroll; height: 100px;">
                            <asp:CheckBoxList ID="cblPE" runat="server">
                                <asp:ListItem Text="" Value="-"></asp:ListItem>
                            </asp:CheckBoxList>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:HiddenField ID="hfIMT" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Moneda&nbsp;</td>
                    <td>
                        <asp:DropDownList ID="ddlMON" runat="server" Font-Bold="True" ForeColor="#333333">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Importe IGV</td>
                    <td>
                        <asp:TextBox ID="txtIGV" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>Valor Compra Declarado&nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtVCDE" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Tasa IGV</td>
                    <td>
                        <asp:TextBox ID="txtTIGV" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>Valor Compra Calculado</td>
                    <td>
                        <asp:TextBox ID="txtVCCA" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Importe Total&nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtIMP" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>Inafecto</td>
                    <td>
                        <asp:TextBox ID="txtINAF" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr class="tr_oculta">
                    <td>Descripción&nbsp;</td>
                    <td colspan="2">
                        <asp:TextBox ID="txtDES" runat="server" Width="232px"></asp:TextBox>
                    </td>
                    <td>Clase</td>
                    <td>
                        <asp:DropDownList ID="ddlCLA" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr class="tr_oculta">
                    <td>Tipo Anexo&nbsp;Ref</td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlTIAR" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr class="tr_oculta">
                    <td>C. Costo Ref.&nbsp;&nbsp;</td>
                    <td colspan="3">
                        <asp:TextBox ID="txtCCR" runat="server" Width="52px"></asp:TextBox>
                        <asp:TextBox ID="txtCDE" runat="server" Width="346px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr class="tr_oculta">
                    <td>Codigo Ref</td>
                    <td>
                        <asp:TextBox ID="txtCREF" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="5">&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblTCON" runat="server" Text="Tipo Conversión"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddlTCON" TabIndex="4" onkeypress="Operacion.MEKPAT(event,this)" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                    <td>Glosa Comprobante</td>
                    <td>
                        <asp:TextBox ID="txtGCOM" runat="server" Width="287px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>&nbsp;</td>
                    <td>Glosa Referencia</td>
                    <td>
                        <asp:TextBox ID="txtRefer" Width="284px" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Tipo Cambio</td>
                    <td>
                        <asp:TextBox ID="txtVTIC" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>Glosa Movimiento</td>
                    <td>
                        <asp:TextBox ID="txtGMOV" runat="server" Width="284px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblFCAM" runat="server" Text="Fecha Cambio"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFCAM" TabIndex="4" class="dp3" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2" class="tr_oculta1">
                        <input id="rb1" name="rb" type="radio" value="M" />Compra
                        <input id="rb2" name="rb" type="radio" value="V" />Venta</td>
                    <td>&nbsp;</td>
                </tr>
                <tr class="tr_oculta2">
                    <td>Tipo Tasa</td>
                    <td colspan="2">
                        <asp:TextBox ID="txtTTAS" runat="server" Width="49px"></asp:TextBox>
                        <asp:TextBox ID="txtTDES" runat="server" Width="241px"></asp:TextBox>
                    </td>
                    <td>Tasa&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtTASA" runat="server" Width="64px"></asp:TextBox>
                    </td>
                    <td>Imp. Detracción&nbsp;&nbsp;
                        <asp:TextBox ID="txtIMDE" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr class="tr_oculta2">
                    <td>Nro. Detracción</td>
                    <td>
                        <asp:TextBox ID="txtNDET" runat="server"></asp:TextBox>
                    </td>
                    <td>Fecha Detracción</td>
                    <td>
                        <asp:TextBox ID="txtFDET" runat="server"></asp:TextBox>
                    </td>
                    <td>Monto Base&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtMBAS" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSIT" runat="server" Text="Situación"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSITU" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblFCRE" runat="server" Text="Fecha Creación"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFCRE" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Label ID="lblFVB" runat="server" Text="Fec. V.B"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFVB" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr class="tr_oculta4">
                    <td>Con Valor Ref.&nbsp;</td>
                    <td>
                        <asp:CheckBox ID="cbVR" Text="SI" runat="server" />
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
        <div id="POC" title="Partes Orden Compra" style="display: none">
            <table>
                <tr>
                    <td>PARTE ENTRADA</td>
                    <td colspan="2">
                        <asp:TextBox ID="txtPOC_OC" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td colspan="4">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="5" class="gvd">
                        <asp:GridView ID="gvDetalle" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                            <Columns>
                                <asp:BoundField DataField="C6_CITEM" HeaderText="ITEM" ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="C6_CCODIGO" HeaderText="Articulo" ItemStyle-HorizontalAlign="Left">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="Left" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="C6_CDESCRI" HeaderText="Descripcion" ItemStyle-HorizontalAlign="Left">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="Left" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="UM" HeaderText="UM" ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="C6_NCANTID" HeaderText="Cantidad" ItemStyle-HorizontalAlign="Right">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="C6_NPREUN1" HeaderText="Precio" ItemStyle-HorizontalAlign="Right">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="IMPORTE" HeaderText="Importe" ItemStyle-HorizontalAlign="Right">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MON" HeaderText="Mon." ItemStyle-HorizontalAlign="Center">
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
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                </tr>
            </table>
        </div>
        <div id="PCC" title="Calculo Compra" style="display: none">
            <table>
                <tr>
                    <td>Parte Entrada</td>
                    <td>
                        <asp:TextBox ID="txMPE" ReadOnly="true" runat="server"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>Valor Compra</td>
                    <td>
                        <asp:TextBox ID="txtMOC" ReadOnly="true" runat="server"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>Diferencia</td>
                    <td>
                        <asp:TextBox ID="txtMDI" ReadOnly="true" runat="server"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>IGV</td>
                    <td>
                        <asp:TextBox ID="txtMIGV" ReadOnly="true" runat="server"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>Total</td>
                    <td>
                        <asp:TextBox ID="txtMTOT" ReadOnly="true" runat="server"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
            </table>
        </div>
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
                            <!--<asp:BoundField DataField="DAREA" HeaderText="Area" ItemStyle-HorizontalAlign="Center">
                                        <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                        <ItemStyle Font-Size="8pt" />
                                    </asp:BoundField>-->
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
    <br />
</asp:Content>