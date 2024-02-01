<%@ Page Title="Facturacion" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="LiquidacionCompra.aspx.cs" Inherits="LiquidacionCompra" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link type="text/css" href="../CSS/base.css" rel="stylesheet" />
    <style type="text/css">
        .your-class::-webkit-input-placeholder {
            color: red;
        }

        .e {
            border: 1px solid #808080;
            display: block;
            padding-left: 1px;
            padding-right: 5px;
            min-width: 50px;
            max-width: 100px;
            min-height: 18px;
        }

        .auto-style1 {
            text-align: right;
        }

        .auto-style2 {
            width: 109px;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            UHTML.id = 'MainContent';
            var CTD = Operacion.mask('txtTDOC').val().trim(), CLQ, COMP, CORPAG, DI = "PE";
            var CODATA = {};
            PERREG = "";//PERMITE REGISTRAR
            AMOVC = [], APE = [], PAR = [], MADOC = [], RDCTA = [], M_DATA = [];
            var AUXO = [], MCP = [], DCUENTAS = [], AC_X = [];//CARGADO CONSULTAR FECHAS
            var AL = "";
            var cAUX = 0;
            var ni = [];
            var IDX = [];//ITEM ELEGIDOS
            var IDXI = [];//ITEM
            var AT = [];//SUBTOTAL
            var $tr;
            var myRow;
            miespecie = "";
            //CONFIGURACION
            var currentDate = moment().format('DD/MM/YYYY');
            Operacion.iValida('txtPRO', 1);
            Operacion.inputVisible($('#opcion'), 1);//NUEVO
            Operacion.inputEstado('txtTDOC', 1, true);
            Operacion.inputEstado('ddlMON', 1, true);
            Operacion.inputEstado('ddlTIA', 1, true);
            Operacion.inputEstado('ddlSDIA', 1, true);
            Operacion.inputVisible($('.detraccion1'), 1);
            Operacion.inputVisible($('.detraccion2'), 1);
            Operacion.mask('ddlTDOC').focus(-1);
            Operacion.mask('txtFPAG').val('PRIORITARIO');
            Operacion.oDialog('detallePE', 0);

            $(".dp1").datepicker();
            $(".dp2").datepicker();
            $(".dp3").datepicker();
            $(".dp4").datepicker();
            $(".dp5").datepicker();//FECHA VENCIMIENTO
            $('.dp6').datepicker();

            (Operacion.mask('txtFEC').val() != "" ? CODATA.XFECCAM2 = moment(Operacion.mask('txtFEC').val(), 'DD-MM-YYYY') : "");

            //METODOS1
            //BLOQUEO SEGUN CIERRE DE MES
            var bloqueoFE = function (FC) {

                var NFC = FC.split("/");
                NFC = NFC[1];

                var DATA = {
                    TMES: NFC,
                    TTIPCONS: "D"
                };
                //console.log(DATA);
                $.ajax({
                    url: "LiquidacionCompra.aspx/listarBC",
                    data: '{DATA:' + JSON.stringify(DATA) + '}',
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        if (data.d != null) {
                            if (data.d.TTIPCONS == "D") {
                                alert('El mes del comprobante ya ha sido bloqueado');
                                Operacion.mask('txtFCOM').val('');
                                Operacion.mask('txtFCOM').focus();
                                $("#ctl00").find(':input').each(function () {
                                    var elemento = this;
                                    if (elemento.type == "text" || elemento.type == "button" || elemento.type == "select-one") {// || elemento.type == "select-one") {
                                        var milabel = elemento.id;
                                        var label = milabel.split("_");
                                        Operacion.inputEstado(label[1], 1, true);
                                        Operacion.inputEstado(milabel, 1, false);
                                    }
                                });
                            } else {
                                Operacion.mask('txtDOC').focus();
                                CODATA.XFECCAM2 = moment(Operacion.mask('txtFEC').val(), 'DD-MM-YYYY');
                                //NUEVO 24.06.16
                                var MTC = moment(Operacion.mask('txtFEC').val(), 'DD-MM-YYYY');//FECHA ELEGIDA
                                var MTC1 = moment(MTC).format('YYYYMMDD');//FECHA ELEGIDA NUMEROS
                                var TCA = moment().format('YYYYMMDD');//FECHA ACTUAL
                                var TC = (Number(MTC1) == Number(TCA) ? "V" : "F");

                                iniciaTC(CODATA, TC);
                                if (PAR['QTIPDOC'] == "FT") {
                                    Operacion.mask('ddlTICO').val(TC);//motc);
                                    Operacion.mask('txtFAUX').val((TC == "V" ? Operacion.mask('txtFEC').val() : Operacion.mask('txtFEC').val()));
                                    Operacion.mask('txtARG').focus();
                                }
                            }
                        } else {
                            //CASO NO ESTE CREADO
                            Operacion.mask('txtDOC').focus();
                            CODATA.XFECCAM2 = moment(Operacion.mask('txtFEC').val(), 'DD-MM-YYYY');

                            //NUEVO 24.06.16
                            var MTC = moment(Operacion.mask('txtFEC').val(), 'DD-MM-YYYY');//FECHA ELEGIDA
                            var MTC1 = moment(MTC).format('YYYYMMDD');//FECHA ELEGIDA NUMEROS
                            var TCA = moment().format('YYYYMMDD');//FECHA ACTUAL
                            var TC = (Number(MTC1) == Number(TCA) ? "V" : "F");
                            //console.log(TCA);
                            //console.log(MTC1);
                            iniciaTC(CODATA, TC);//"V");
                            if (PAR['QTIPDOC'] == "FT") {
                                Operacion.mask('txtFAUX').val((TC == "V" ? Operacion.mask('txtFEC').val() : Operacion.mask('txtFEC').val()));
                                Operacion.mask('ddlTICO').val(TC);//PAR['QTIPCAM']);//motc);
                            }
                        }
                    },
                    error: function (data) {
                        console.log(data);
                    }
                });
            }
            //INICIA SERIES PARA FACTURAS
            var iniciaSE = function () {
                Operacion.mask('ddlSER').empty();
                if (PAR['QTIPDOC'] == "FT") {
                    var miseries = [{ TN_CNUMSER: "0000", TN_CNUMSER: "ELEGIR" }, { TN_CNUMSER: "0001", TN_CNUMSER: "0001" },
                                    { TN_CNUMSER: "0002", TN_CNUMSER: "0002" }, { TN_CNUMSER: "0003", TN_CNUMSER: "0003" },
                                    { TN_CNUMSER: "0004", TN_CNUMSER: "0004" }, { TN_CNUMSER: "0005", TN_CNUMSER: "0005" },
                                    { TN_CNUMSER: "0006", TN_CNUMSER: "0006" }, { TN_CNUMSER: "0007", TN_CNUMSER: "0007" }
                    ];
                    $.each(miseries, function (i, v) {
                        Operacion.mask('ddlSER').append($('<option>', {
                            value: v.TN_CNUMSER,
                            text: v.TN_CNUMSER
                        }));
                    });
                } else {
                    var FDATA = {};
                    FDATA.TN_CCODIGO = PAR['QTIPDOC'];
                    FDATA.TN_CNUMSER = "0001";

                    $.ajax({
                        url: "LiquidacionCompra.aspx/ListarNumeracion",
                        data: '{FDATA:' + JSON.stringify(FDATA) + '}',
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            $.each(data.d, function (i, v) {
                                Operacion.mask('ddlSER').append($('<option>', {
                                    value: v.TN_CNUMSER,
                                    text: v.TN_CNUMSER
                                }));
                            });
                        },
                        error: function (data) {
                            console.log(data);
                        }
                    });
                }
            }
            //PARAMETROS CONFIGURACION FT/LQ
            var confpara = function (OP) {
                var TABP = {};
                TABP.TG_INDICE = OP;//C6:PARAMETRO VARIOS LIQUIDACION COMPRAS
                $.ajax({
                    url: "LiquidacionCompra.aspx/configuracion",
                    data: '{TABP:' + JSON.stringify(TABP) + '}',
                    dataType: "json",
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        if (data.d.length > 0) {
                            PAR['QCTAIGV'] = data.d[0]['TG_DESCRI'];//CUENTA IGV SI HUBIERA
                            PAR['QCTAGRD'] = data.d[1]['TG_DESCRI'];//CUENTA IMPUESTO A LA RENTA-DETRACCION
                            PAR['QFORREG'] = data.d[2]['TG_DESCRI'];//CPE : CONTRA PARTE DE ENTRADA
                            PAR['QTIPANE'] = data.d[3]['TG_DESCRI'].substring(0, 1);//TIPO ANEXO
                            PAR['QCTAIGR'] = data.d[4]['TG_DESCRI'];//CUENTA DE IGV RETENCION
                            PAR['QTIPDOC'] = data.d[5]['TG_DESCRI'];//LQ
                            PAR['QTIPCAM'] = data.d[6]['TG_DESCRI'].substring(0, 1);//CONVERSION DE MONEDA
                            PAR['QTIPMON'] = data.d[7]['TG_DESCRI'].substring(0, 2);//TIPO MONEDA
                            PAR['QAFECRT'] = data.d[8]['TG_DESCRI'];//AFECTO A IMPUESTO DE RENTA: S/N
                            PAR['QIMPRTREN'] = data.d[9]['TG_DESCRI'];//IMPORTE LIMITE
                            PAR['PUVTOPRT'] = data.d[10]['TG_DESCRI'];//VARIABLE TOPE RETENCION;
                            PAR['PUFIMBRT'] = data.d[11]['TG_DESCRI'];//FACTOR IMPORTE BASE RETENCION;
                            PAR['QPORCRT'] = data.d[12]['TG_DESCRI'];//PORCENTAJE
                            PAR['TIPOPE'] = data.d[13]['TG_DESCRI'];//TIPO OPERACION
                            Operacion.mask('txtTDOC').val(PAR['QTIPDOC']);
                            //console.log(PAR);
                            if (Operacion.mask('txtTDOC').val() == "FT") {
                                Operacion.mask('ddlMON').val(PAR['QTIPMON']);
                                Operacion.inputEstado('ddlMON', 0, true);
                                Operacion.inputEstado('txtFEC0', 0, true);
                                Operacion.inputEstado('txtFEC1', 0, true);
                                Operacion.mask('txtFEC1').val(Operacion.mask('txtFEC').val());
                                Operacion.inputEstado('txtND', 0, true);
                                Operacion.inputEstado('txtCTAS', 0, true);
                                Operacion.inputEstado('txtNDET', 0, true);
                                Operacion.inputEstado('txtTASA', 0, true);
                                Operacion.inputEstado('txtARG', 0, true);
                                Operacion.mask('ddlTICO').val(PAR['QTIPCAM']);
                                iniciaSE();
                            } else {
                                Operacion.mask('ddlMON').val(PAR['QTIPMON']);
                                Operacion.inputEstado('ddlMON', 1, true);
                                Operacion.inputEstado('txtFEC0', 1, true);
                                Operacion.inputEstado('txtFEC1', 1, true);
                                Operacion.inputEstado('txtND', 1, true);
                                Operacion.inputEstado('txtCTAS', 1, true);
                                Operacion.inputEstado('txtNDET', 1, true);
                                Operacion.inputEstado('txtTASA', 1, true);
                                Operacion.inputEstado('txtARG', 1, true);
                                iniciaSE();
                            }
                            confcg();//CUENTAS 60
                            iniciaSDIA((OP == 'C6' ? '15' : '13'));
                        } else {
                            Operacion.mask('txtTDOC').val('');
                            Operacion.mask('ddlMON').val('');
                            Operacion.mask('ddlSDIA').empty();
                        }

                    },
                    error: function (result) {
                        alert(result);
                    }
                });
            }
            //CONFIGURACION CUENTAS COMPRA
            var confcc = function (TA) {
                var DATA = {};
                DATA.CE_CCODMON = PAR['QTIPMON'];
                DATA.CE_CTIPACR = TA;

                $.ajax({
                    url: "LiquidacionCompra.aspx/ListaCC",
                    data: '{DATA:' + JSON.stringify(DATA) + '}',
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        PAR['CE_CTIPACR'] = data.d[0]['CE_CTIPACR'].trim();//PL|PU
                        PAR['CE_CCTACOM'] = data.d[0]['CE_CCTACOM'].trim();//421204|421207
                        PAR['CE_CCTALET'] = data.d[0]['CE_CCTALET'].trim();//423101
                        PAR['CE_CCTAANT'] = data.d[0]['CE_CCTAANT'].trim();//422101
                        PAR['CE_CCTALIQ'] = data.d[0]['CE_CCTALIQ'].trim();//421204
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        //  alert(textStatus);
                    }
                });
            }
            //CUENTAS ANEXOS MATERIA PRIMA CONGELADOS
            var confcg = function () {
                PAR['QCTACGA'] = (PAR['QTIPDOC'] == "LQ" ? "602101" : (PAR['QTIPDOC'] == "FT" ? "602102" : "")); //CONCEPTO DEL GASTO
                //console.log(PAR);
                var PDATA = {};
                PDATA.PCUENTA = PAR['QCTACGA'];//MPCLC:602101-MPCFA:602102
                $.ajax({
                    url: "LiquidacionCompra.aspx/ListaPlanC",
                    data: '{PDATA:' + JSON.stringify(PDATA) + '}',
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        PAR['PCTACAR'] = data.d[0]['PCTACAR'].trim();//241101
                        PAR['PCTAABO'] = data.d[0]['PCTAABO'].trim();//612101
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        //  alert(textStatus);
                    }
                });
            }
            //CONFIGURACION ADICIONAL SOLO PARA FT
            var confadic = function () {
                Operacion.inputVisible($('.detraccion1'), 0);
                Operacion.inputVisible($('.detraccion2'), 0);
                iniciaCECO();
            }

            //METODOS2
            //VALIDA CAMPOS GENERALES
            var valida = function () {
                if (PAR['QTIPDOC'] == "FT") {
                    //'lblDNI',
                    return Operacion.iVALC(['txtTDOC', 'txtND', 'txtNDET', 'txtPRO', 'txtDPRO',
                                        'txtFEC', 'txtFEC0', 'txtTIC',
                                        'txtCTAS', 'txtTASA', 'txtARG']);
                } else {
                    //'lblDNI',
                    return Operacion.iVALC(['txtTDOC', 'txtND', 'txtNDET', 'txtPRO', 'txtDPRO',
                                        'txtDIR', 'txtFEC', 'txtFEC0', 'txtTIC', 'txtGLO',
                                        'txtCTAS', 'txtTASA', 'txtARG']);
                }

            }
            //UNIDAD DE PRODUCTO
            var unidad = function (ART, ID) {
                $.ajax({
                    url: "RegistroEntrada.aspx/getProductoID",
                    data: "{ 'dato': '" + ART + "'}",
                    dataType: "json",
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        OAUX[ID][16] = data.d[0]['AR_CUNIDAD'];
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        //  alert(textStatus);
                    }
                });
            }
            //SUBDIARIOS 15/13
            var iniciaSDIA = function (ID) {
                M_DATA['MISUB'] = ID;//---------------------------------------------------------------------------------SUBDIARIO
                var TABG = {};
                TABG.TCOD = "02";
                TABG.TCLAVE = ID;//SUBDIARIO
                $.ajax({
                    type: "POST",
                    url: "LiquidacionCompra.aspx/listaTAGE",
                    data: '{TABG:' + JSON.stringify(TABG) + ' }',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        Operacion.mask('ddlSDIA').empty();
                        $.each(data.d, function (i, v) {
                            Operacion.mask('ddlSDIA').append($('<option>', {
                                value: v.TCLAVE,
                                text: v.TDESCRI
                            }));
                        });
                    }, error: function (response) {
                        console.table(response);
                    }
                });
            }
            //INICIA TIPO TASA FT
            var iniciaTITA = function (KEY) {
                var TABG = {};
                TABG.TCOD = "28";
                TABG.TCLAVE = KEY;//SUBDIARIO
                $.ajax({
                    type: "POST",
                    url: "LiquidacionCompra.aspx/listaTAGE",
                    data: '{TABG:' + JSON.stringify(TABG) + ' }',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        if (data.d.length > 0) {
                            Operacion.mask('txtDTAS').val(data.d[0].TDESCRI.substring(0, 25));
                            var descri = data.d[0].TDESCRI.split(" ");
                            var auxiliar = (descri[28] == '0.00' ? descri[30] : descri[28]);
                            Operacion.mask('txtTASA').val(auxiliar).attr('readonly', true);
                        } else {
                            alert('El codigo no se encuentra registrado');
                            Operacion.mask('txtCTAS').val('');
                            Operacion.mask('txtDTAS').val('');
                            Operacion.mask('txtTASA').val('');
                        }
                    }, error: function (response) {
                        console.table(response);
                    }
                });
            }
            //INICIA CENTRO COSTO REFERENCIA FT
            var iniciaCECO = function () {
                var TABG = {};
                TABG.TCOD = "05";
                //TABG.TCLAVE = "";//SUBDIARIO
                $.ajax({
                    type: "POST",
                    url: "LiquidacionCompra.aspx/listaTAGE",
                    data: '{TABG:' + JSON.stringify(TABG) + ' }',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        Operacion.mask('ddlCREF').empty();
                        $.each(data.d, function (i, v) {
                            Operacion.mask('ddlCREF').append($('<option>', {
                                value: v.TCLAVE,
                                text: v.TDESCRI.substring(0, 25)
                            }));
                        });
                    }, error: function (response) {
                        console.table(response);
                    }
                });
            }
            //SELECCION TIPO CAMBIO
            var iniciaTC = function (CODATA, OP) {
                //console.log(CODATA);
                $.ajax({
                    type: "POST",
                    url: "RegistroEntradaOC.aspx/getTC",
                    data: '{CODATA:' + JSON.stringify(CODATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        if (data.d != null) {
                            Operacion.mask('txtTIC').val((OP == "M" ? data.d['XMEIMP'] : data.d['XMEIMP2']));
                        } else {
                            Operacion.mask('txtTIC').val('');
                        }
                    },
                    error: function (response) {
                        console.log(response);
                    }
                });
            }
            //CONSULTA PARTES DE ENTRADA
            var iniciaPE = function () {
                //AMOVC = [];//REEMPLAZAR
                //AT = [];//REEMPLAZAR
                //IDX = [];//REEMPLAZAR

                var PEPF = {};
                PEPF.C5_CALMA = Operacion.mask('ddlALM').val();
                PEPF.C5_CTD = "PE";
                PEPF.C5_CCODMOV = (PAR['CE_CTIPACR'] == "PL" ? "MP" : "CO");
                PEPF.C5_CTIPORD = "5";
                PEPF.C5_CRFTDOC = Operacion.mask('txtTDOC').val();
                PEPF.C5_CCODPRO = Operacion.mask('txtPRO').val();
                PEPF.C5_DFECDOC = moment(Operacion.mask('txtDFEC').val(), 'DD-MM-YYYY');
                PEPF.C5_DFECMOD = moment(Operacion.mask('txtHFEC').val(), 'DD-MM-YYYY');
                PEPF.C5_CCODMON = PAR['QTIPMON'];//Operacion.mask('ddlMON').val();//NUEVO 13.06.16
                //console.log(PEPF);

                $.ajax({
                    type: "POST",
                    url: "LiquidacionCompra.aspx/getPEPF",
                    data: '{PDATA:' + JSON.stringify(PEPF) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        //console.log(data.d);
                        $('#cblPET').empty();
                        if (data.d.length > 0) {
                            Operacion.inputEstado('btnAceptar', 0, false);
                            Operacion.mask('cblPE').empty();
                            var table = $('<table id=MainContent_cblPE cellpadding=3 style=background-color:White;border-color:#CCCCCC;border-width:1px;border-style:None;width:100%;border-collapse:collapse;></table>');
                            var counter = 0;
                            table.append($('<tr style=color:White;background-color:#006699;font-weight:bold;></tr>')
                                .append($('<th style=text-align:left>Nro Documento</th>'))
                                .append($('<th style=text-align:left>Especie</th>'))
                                .append($('<th style=text-align:left>Cantidad</th>'))
                                .append($('<th style=text-align:left>Nro. OC</th>'))
                                .append($('<th style=text-align:left>Fecha Doc.</th>'))
                                );

                            $.each(data.d, function (i, elem) {
                                var CD = elem['C6_CCODIGO'].trim() + "-" + elem['C5_CNUMDOC']; //v1:solo codigo

                                var vfecha = (elem['C5_DFECDOC'] != 'undefined' ? moment(elem['C5_DFECDOC']).format('DD/MM/YYYY') : "");
                                table.append($('<tr style=color:#000066;></tr>').append($('<td></td>')
                                     .append($('<input>').attr({
                                         type: 'checkbox', name: 'ctl00$MainContent$cblPE$' + counter, value: CD, id: 'MainContent_cblPE_' + counter
                                     })).append($('<label>').attr({ for: '' + counter++ }).text(elem['C5_CNUMDOC'])))
                                     .append($('<td>' + elem['C6_CDESCRI'] + '</td>'))
                                     .append($('<td >' + elem['C6_NCANTID'] + '</td>'))
                                     .append($('<td ><img src=../Images/Message_Success.png width=10% />' + elem['C5_CNUMORD'] + '</td>'))
                                     .append($('<td>' + elem['C5_DFECDOC'] + '</td>'))
                                     );
                                //.append(' | Especie:' + elem['C6_CDESCRI'] + ' | Cantidad:' + elem['C6_NCANTID'] + ' | Fecha Documento: <span id=fecha>' + elem['C5_DFECDOC'] + 'OC:' + elem['C5_CNUMORD'] + '</span>')));
                                $('#cblPET').append(table);
                                cAUX = counter;
                            });

                        } else {
                            $('#cblPET').html('No existe PE en el rango de fechas buscado. Verificar:Moneda/Almacen');
                            Operacion.inputEstado('btnAceptar', 1, false);
                            //var PEPF = {};
                            //iniciaPE();
                        }
                    },
                    error: function (response) {
                        console.log(response);
                    }
                });
            }
            //CALCULO SUBTOTALES-INICIA PARAMETROS DE REGISTRO
            var iniciaST = function () {
                M_DATA['MTTASA'] = Operacion.mask('txtCTAS').val();//---------------------------------------CUENTA TASA
                M_DATA['MMTASA'] = Number(Operacion.mask('txtTASA').val());//-------------------------------MONTO TASA
                M_DATA['MTIPCA'] = Number(Operacion.mask('txtTIC').val());//--------------------------------TIPO DE CAMBIO
                M_DATA['MTIPDS'] = Operacion.mask('ddlTICO').val();//---------------------------------------DESCRIPCION TIPO CAMBIO
                var gridView = document.getElementById("<%=gvDetalle.ClientID %>");
                LEN = gridView.rows.length;
                acum = 0;
                for (var t = 1; t < LEN; t++) {
                    control50 = gridView.rows[t].cells[5];
                    control51 = control50.innerHTML;
                    acum += Number(control51);
                }
                var migv = (PAR['QTIPDOC'] == "FT" ?
                              (M_DATA['MTTASA'] == "03501" ? ((acum) * 0)
                              : (M_DATA['MTTASA'] == "00404" ? ((acum) * (0.18)) : 0))
                            : 0);
                var mititulo = (PAR['QTIPDOC'] == "FT" ? 'Importe detracción ' + M_DATA['MMTASA'] + '%' : 'Retención Renta 1.5%');
                var mipor = (PAR['QTIPDOC'] == "FT" ? M_DATA['MMTASA'] : PAR['QPORCRT']);
                var misubtot = (Number(acum) + Number(migv));

                var miopera = Number((Number(mipor) / 100) * Number(misubtot));
                var mioperac = (PAR['QTIPMON'] == "MN" ? miopera : (miopera * Operacion.mask('txtTIC').val()));//RETENCION - DETRACCION
                var misubtotf = (PAR['QTIPMON'] == "US" ? Number(misubtot * M_DATA['MTIPCA']) : misubtot);
                //INICIA TEXTOS
                Operacion.mask('lblVV').text(acum.toFixed(2));//--------------------------------------------SUBTOTAL
                Operacion.mask('lblIGV').text(Operacion.mround(migv, 2));//MODIFICAR:CASOS DE FT------------IGV
                Operacion.mask('lblTV').text(Operacion.mround(misubtot, 2));//------------------------------TOTAL REAL US/MN
                //REEMPLAZAR CONFIGURACION
                Operacion.mask('lblRD').text(mititulo);//---------------------------------------------------TITULO RETENCION|DETRACCION
                Operacion.mask('txtRTOV').val(Operacion.mround(misubtotf, 2));//TOTAL VENTA SOLES-----------TOTAL VENTA                
                var V_DR = Operacion.mround(mioperac, (PAR['QTIPDOC'] == "LQ" ? 2 : 0));
                Operacion.mask('txtRREN').val(V_DR);//------------------------------------------------------RETENCION - DETRACCION
                Operacion.mask('txtRNPA').val(Operacion.mround(Number(misubtotf - V_DR), 2));//-------------NETO A PAGAR
                //VARIABLES REFERENCIA
                M_DATA['MISUBT'] = Operacion.mround(acum, 2);//----------------------------------------------SUBTOTAL
                M_DATA['MIIGV'] = Operacion.mround(migv, 2);//----------------------------------------------IGV CALCULADO
                M_DATA['MITOTR'] = Operacion.mround(misubtot, 2);//-----------------------------------------MONTO REAL US/MN
                M_DATA['MITOTMN'] = Operacion.mround(misubtotf, 2);//---------------------------------------MONTO PARA DETRACCIONES MN
                M_DATA['MIDR'] = V_DR;//--------------------------------------------------------------------IMPORTE APLICADO DETRACCION-RETENCION
                var DR_MO = (PAR['QTIPMON'] == "MN" ? M_DATA['MIDR'] : M_DATA['MIDR'] / M_DATA['MTIPCA']);
                var M_TAC = (PAR['QTIPDOC'] == "FT" ?
                                (Number(M_DATA['MITOTMN']) + Number(DR_MO) + Number(M_DATA['MISUBT'])) :
                                (Number(M_DATA['MITOTMN']) * 2 + Number(DR_MO)));

                M_DATA['TOTASI'] = M_TAC;
                //M_DATA['MTTASA'] = Operacion.mask('txtCTAS').val();---------------------------------------TIPO TASA FT
                //M_DATA['MMTASA'] = Operacion.mask('txtTASA').val();---------------------------------------MONTO TASA FT
                //M_DATA['MTIPCA'] = Operacion.mask('txtTIC').val();TIPO CAMBIO-----------------------------TIPO CAMBIO
                M_DATA['MITAX'] = mipor;//------------------------------------------------------------------TASA AUXILIAR
                M_DATA['MINP'] = Number(Operacion.mask('txtRNPA').val());//---------------------------------NETO A PAGAR
                M_DATA['FDOC'] = Operacion.mask('txtFEC').val();//------------------------------------------FECHA DOCUMENTO
                M_DATA['FVEN'] = Operacion.mask('txtFEC1').val();//-----------------------------------------FECHA VENCIMIENTO
                M_DATA['FCOT'] = Operacion.mask('txtFEC0').val();//-----------------------------------------FECHA CONTABLE/COMPROBANTE
                M_DATA['FREC'] = currentDate;//-------------------------------------------------------------FECHA RECEPCION
                // console.log(M_DATA);
            }
            //INCIA GRILLA PRINCIPAL
            var iniciaGrilla = function () {
                var MLEN = IDXI.length;

                var DATA = {};
                DATA.C5_CALMA = Operacion.mask('ddlALM').val();
                DATA.C5_CTD = "PE";
                //DATA.C5_CNUMDOC=APE;
                DATA.C5_CCODMOV = (PAR['CE_CTIPACR'] == "PL" ? "MP" : "CO");
                DATA.C5_CRFTDOC = Operacion.mask('txtTDOC').val();
                DATA.C5_CCODPRO = Operacion.mask('txtPRO').val();
                DATA.C5_DFECDOC = moment(Operacion.mask('txtDFEC').val(), 'DD-MM-YYYY');
                DATA.C5_DFECMOD = moment(Operacion.mask('txtHFEC').val(), 'DD-MM-YYYY');

                $.ajax({
                    type: "POST",
                    url: "LiquidacionCompra.aspx/getDPES",
                    data: '{DATA:' + JSON.stringify(DATA) + ',ND:' + JSON.stringify(IDX) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        Operacion.mask('gvDetalle').empty();
                        Operacion.mask('gvDetalle').attr('style', 'background-color:White;border-color:#CCCCCC;border-width:1px;border-style:None;border-collapse:collapse;width: 100%;');
                        Operacion.mask('gvDetalle').append("<tr style='color:White;background-color:#006699;font-weight:bold;'><th align='left' scope='col' style='font-size:8pt;width:100px;'>Codigo</th><th align='left' scope='col' style='font-size:8pt;width:500px;'>Descripcion</th><th align='center' scope='col' style='font-size:8pt;width:50px;'>UM</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Cantidad</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Precio</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Valor Venta</th></tr>");
                        var sum = 0;
                        $.each(data.d, function (i, v) {
                            //AUXO:RESUMEN X CODIGO
                            //FORMA NORMAL:BASE DE DATOS
                            Operacion.mask('gvDetalle').append("<tr><td style='font-size:8pt;text-align:center;'>" +
                            v.C6_CCODIGO + "</td><td style='font-size:8pt;text-align:left;'>" +
                            v.C6_CDESCRI + "</td><td style='font-size:8pt;text-align:center;'>" +
                            v.AR_CUNIDAD + "</td><td style='font-size:8pt;text-align:right;'>" +
                            v.C6_NCANTID.toFixed(2) + "</td><td style='font-size:8pt;text-align:right;'>" +
                            "<input type='text' id='MainContent_txtPRE1' style=text-align:right onkeypress=$(this).numeric('.') placeholder='0.00' ReadOnly='true' value='" + v.C6_NPREUN1 + "'/></td><td style='font-size:8pt;text-align:right;'>" +
                            (v.C6_NCANTID * v.C6_NPREUN1).toFixed(2) + "</td></tr>");
                            sum += v.C6_NCANTID;
                        });
                        var miglosa2 = Operacion.mask('txtGLO').val();
                        if (PAR['QTIPDOC'] == "FT") {
                            var TON = Number(sum / 1000).toFixed(4);
                            Operacion.mask('txtGLO').val(TON + " TM " + miglosa2);
                            //Operacion.mask('txtGLO').val(sum + " KG " + miespecie.toUpperCase() + " ENTERO FRESCO")
                        }
                    },
                    error: function (response) {
                        console.log(response);
                    }
                });
                iniciaST();
                Operacion.mask('txtDFEC').val('');
                Operacion.mask('txtHFEC').val('');
            };
            //CORRELATIVO LQ
            var correlativo = function () {
                var NDATA = {};
                NDATA.TN_CCODIGO = Operacion.mask('txtTDOC').val().trim();
                NDATA.TN_CNUMSER = Operacion.mask('ddlSER').val();

                $.ajax({
                    type: "POST",
                    url: "LiquidacionCompra.aspx/correlativoID",
                    data: '{ NDATA: ' + JSON.stringify(NDATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        Operacion.mask('txtNumeroDoc').val(data.d);
                        Operacion.mask('lblNroDocumento').text(data.d);
                        CLQ = data.d;
                    },
                    error: function (response) {
                        console.table(response);
                    }
                });
            }
            //CORRELATIVO COMPROBANTE
            var correlativoCP = function () {
                var element = (PAR['QTIPDOC'] == "FT" ? M_DATA['FCOT'] : M_DATA['FDOC']);
                var fecha = element.split('/');
                var FECDOC = fecha[2].substr(2, 2) + "" + fecha[1] + "" + fecha[0];

                var DATA = {};
                DATA.CTSUBDIA = M_DATA['MISUB'];//Operacion.mask('ddlSDIA').val();
                DATA.CTANO = fecha[2].substr(2, 2);
                DATA.CTMES = fecha[1];
                //DATA.LC_DFECCOM = moment(Operacion.mask('txtFEC').val(), 'DD/MM/YYYY');

                $.ajax({
                    type: "POST",
                    url: "LiquidacionCompra.aspx/correlativoCP",
                    data: '{ DATA: ' + JSON.stringify(DATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        //console.log(data.d);
                        COMP = data.d;
                    },
                    error: function (response) {
                        console.table(response);
                    }
                });
            }
            //CORRELATIVO PAGOS
            var correlativoPG = function (FF, FC) {

                var DATA = {};
                DATA.PG_CVANEXO = PAR['QTIPANE'];//Operacion.mask('ddlTIA').val().trim();
                DATA.PG_CTIPDOC = PAR['QTIPDOC'];//Operacion.mask('txtTDOC').val().trim();
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
            //ACTUALIZA DOCUMENTO
            var anumDOCU = function () {
                //SOFTCOM
                var FDATA = {};
                FDATA.TN_CCODIGO = PAR['QTIPDOC'];
                FDATA.TN_CNUMSER = Operacion.mask('ddlSER').val().trim();
                FDATA.TN_NNUMERO = Number(CLQ.substring(4, CLQ.length)).toString();
                //console.log(FDATA);

                $.ajax({
                    type: "POST",
                    url: "LiquidacionCompra.aspx/Actualizanum",
                    data: '{datos:' + JSON.stringify(FDATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {

                    },
                    error: function (response) {
                        alert('El proceso no se pudo completar ANUMDOCU');
                        console.table(response);
                    }
                });

            }
            //ACTUALIZA NUMERACION SISPAG/CONCAR
            var anumPAGO = function () {
                var element = (PAR['QTIPDOC'] == "FT" ? M_DATA['FCOT'] : M_DATA['FDOC']);//(PAR['QTIPDOC'] == "FT" ? Operacion.mask('txtFEC0').val() : Operacion.mask('txtFEC').val());
                var fecha = element.split('/');
                var NANO = fecha[2].substr(2, 2);
                var NMES = fecha[1];

                //SISPAG
                var CDATA = {};
                CDATA.CTSUBDIA = M_DATA['MISUB'];//Operacion.mask('ddlSDIA').val().trim();
                CDATA.CTANO = NANO;
                CDATA.CTMES = NMES;
                CDATA.CTNUMER = Number(COMP.substring(2, 6)).toString();
                //alert(CDATA);
                //console.log(CDATA);
                $.ajax({
                    type: "POST",
                    url: "LiquidacionCompra.aspx/aNumeracion",
                    data: '{CDATA:' + JSON.stringify(CDATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {

                    },
                    error: function (response) {
                        alert('El proceso no se pudo completar ANUMPAGO');
                        console.table(response);
                    }
                });
            };
            //VERIFICA DOCUMENTO
            var verificaDOC = function () {
                var NDOC = Operacion.mask('txtPRO').val();
                if (NDOC != "") {
                    var DATA = {};
                    DATA.CP_CVANEXO = PAR['QTIPANE'];
                    DATA.CP_CCODIGO = Operacion.mask('txtPRO').val();
                    DATA.CP_CTIPDOC = PAR['QTIPDOC'];
                    DATA.CP_CNUMDOC = Operacion.mask('txtND').val();//NUMERO DOCUMENTO

                    $.ajax({
                        type: "POST",
                        url: "LiquidacionCompra.aspx/obtenerDOC",
                        data: '{DATA:' + JSON.stringify(DATA) + '}',
                        contentType: "application/json;charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (data) {
                            if (data.d != null) {
                                Operacion.mask('txtND').focus();
                                Operacion.mask('txtNDET').val('');
                                alert('Documento registrado en cartera de pagos FT ' + DATA.CP_CNUMDOC + '\n Verificar Numero de documento');
                            }
                        },
                        error: function (response) {
                            alert('El proceso no se pudo completar verificaDOC');
                            console.table(response);
                        }
                    });
                }
            }
            //OBTIENE DATOS CUENTA
            var MDCTA = function (CTA) {
                var PDATA = {};
                PDATA.PCUENTA = CTA;
                $.ajax({
                    type: "POST",
                    url: "LiquidacionCompra.aspx/ListaPlanC",
                    data: '{PDATA:' + JSON.stringify(PDATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        $.each(data.d, function (i, v) {
                            RDCTA[CTA] = [v.PVANEXO, v.PVNIVEL, v.PVANEXO2, v.PVFECVEN];
                        });
                    },
                    error: function (response) {
                        alert('El proceso no se pudo completar ListaPlanC');
                        console.table(response);
                    }
                });
            }
            //CABECERA LIQUIDACIONES
            var insertaCLQ = function () {
                correlativo();

                //PROCESO 1:
                var fechac = moment();
                LCDATA = {};
                LCDATA.LC_CCODAGE = Operacion.mask('ddlAGE').val();//AGENCIA
                LCDATA.LC_CTD = PAR['QTIPDOC'];//Operacion.mask('txtTDOC').val().trim();//LQ
                LCDATA.LC_CNUMDOC = CLQ;//CORRELATIVO LQ
                LCDATA.LC_DFECCOM = moment(M_DATA['FDOC'], 'DD/MM/YYYY');
                LCDATA.LC_DFECDOC = moment(M_DATA['FDOC'], 'DD/MM/YYYY');
                LCDATA.LC_DFECVEN = moment(M_DATA['FDOC'], 'DD/MM/YYYY');
                LCDATA.LC_CDH = "";
                LCDATA.LC_CVENDE = "";
                LCDATA.LC_CNROCAJ = Operacion.mask('lblNCAJ').text().trim().substring(0, 5);
                LCDATA.LC_CVANEXO = PAR['QTIPANE'];//Operacion.mask('ddlTIA').val().trim();
                LCDATA.LC_CCODPRV = Operacion.mask('txtPRO').val();//CODIGO PROVEEDOR
                LCDATA.LC_CNOMBRE = Operacion.mask('txtDPRO').val();//Operacion.mask('lblPRO').text().trim();
                LCDATA.LC_CDIRECC = Operacion.mask('txtDIR').val();
                LCDATA.LC_CRUC = Operacion.mask('txtPRO').val();//RUC PROVEEDOR
                LCDATA.LC_CCHENUM = "";
                LCDATA.LC_CSUBDIA = M_DATA['MISUB'];//Operacion.mask('ddlSDIA').val();
                LCDATA.LC_CCOMPRO = COMP;//CORRELATIVO COMPROBANTE
                LCDATA.LC_CALMA = Operacion.mask('ddlALM').val();
                LCDATA.LC_NIMPORT = M_DATA['MITOTMN'];//Operacion.mask('txtRTOV').val();//SUBTOTAL
                LCDATA.LC_NIMPRET = M_DATA['MIDR'];//Operacion.mask('txtRREN').val();//IMPORTE RETENCION
                LCDATA.LC_CFORVEN = Operacion.mask('txtFPAG').val();
                LCDATA.LC_NSALDO = M_DATA['MITOTMN']; //Operacion.mask('txtRTOV').val();//=SUBTOTAL
                LCDATA.LC_NIMPIGV = 0;
                LCDATA.LC_NTIPCAM = M_DATA['MTIPCA'];//Operacion.mask('txtTIC').val();
                LCDATA.LC_CTIPO = PAR['QTIPCAM'];
                LCDATA.LC_DFECCAM = null;
                LCDATA.LC_CCODMON = PAR['QTIPMON'];//Operacion.mask('ddlMON').val();
                LCDATA.LC_CESTADO = 'V';//V:VIGENTE-A:ANULADO --AL0003TABL WHERE TG_CCOD='55'
                LCDATA.LC_CRFTD = "";
                LCDATA.LC_CRFNUMSER = "";
                LCDATA.LC_CRFNUMDOC = "";
                LCDATA.LC_CNROPED = "";
                LCDATA.LC_CGLOSA = Operacion.mask('txtGLO').val();
                LCDATA.LC_NDESCTO = 0;
                LCDATA.LC_CTF = "";
                LCDATA.LC_CNUMORD = "";
                LCDATA.LC_TOBSERV = "";
                LCDATA.LC_CCALIDA = "";
                LCDATA.LC_CORIGEN = "";
                LCDATA.LC_CUSUCRE = Operacion.mask('hdUSUARIO').val();
                LCDATA.LC_DFECCRE = fechac;
                LCDATA.LC_CUSUMOD = "";
                LCDATA.LC_DFECMOD = "";
                LCDATA.LC_CTIPOPE = "";

                //console.log(LCDATA);
                $.ajax({
                    type: "POST",
                    url: "LiquidacionCompra.aspx/guardarCLQ",
                    data: '{LCDATA:' + JSON.stringify(LCDATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        anumDOCU();
                    },
                    error: function (response) {
                        alert('El proceso no se pudo completar CLQ');
                        console.log(response);
                    }
                });
            }
            //DETALLE LIQUIDACIONES
            var insertaDLQ = function (IT, CP, DS, CT, UN, PR) {
                //PROCESO 2
                var sutt = (CT * PR);
                var oper = Operacion.mround((sutt / M_DATA['MTIPCA']), 2);//NUEVO APROX. EXACTO O:0
                var dret = Operacion.mround((sutt * (Number(PAR['QPORCRT']) / 100)), 2);//(sutt * 0.015);
                var operus = (dret / M_DATA['MTIPCA']);//Operacion.mask('txtTIC').val();
                var fechac = moment();

                var LDDATA = {};
                LDDATA.LD_CCODAGE = Operacion.mask('ddlAGE').val();
                LDDATA.LD_CTD = PAR['QTIPDOC'];//Operacion.mask('txtTDOC').val().trim();
                LDDATA.LD_CNUMDOC = CLQ;
                LDDATA.LD_CITEM = IT;
                LDDATA.LD_CCODIGO = CP.trim();
                LDDATA.LD_CDESCRI = DS;
                LDDATA.LD_CTR = "";
                LDDATA.LD_NCANTID = CT;
                LDDATA.LD_CUNIDAD = UN;
                LDDATA.LD_NPRECIO = PR;
                LDDATA.LD_NPRECI1 = Operacion.mround(PR, 4);//22.06.16
                LDDATA.LD_DFECDOC = moment(M_DATA['FDOC'], 'DD/MM/YYYY');//moment(Operacion.mask('txtFEC').val(), 'DD/MM/YYYY');
                LDDATA.LD_NIGVMN = 0;
                LDDATA.LD_NIGVUS = 0;
                LDDATA.LD_NIGVPOR = 0;
                LDDATA.LD_NIMPUS = oper;//MONTO SUBTOTAL US
                LDDATA.LD_NIMPMN = sutt;//VALOR ENVIADO - SUBTOTAL :Operacion.mask('txtRTOV').val()
                LDDATA.LD_NIMPRMN = dret;//CALCULO DETRACION X ITEM(CANTIDAD X PRECIO)
                LDDATA.LD_NIMPRUS = Operacion.mround(operus, 2);//DOLARES DE RETENCION 
                LDDATA.LD_CESTADO = "";
                LDDATA.LD_CVENDE = "";
                LDDATA.LD_CNROCAJ = Operacion.mask('lblNCAJ').text().trim().substring(0, 5);
                LDDATA.LD_CALMA = Operacion.mask('ddlALM').val();
                LDDATA.LD_CSTOCK = "N";//R
                LDDATA.LD_CUSUCRE = Operacion.mask('hdUSUARIO').val();
                LDDATA.LD_DFECCRE = fechac;

                //console.log(LDDATA);

                $.ajax({
                    type: "POST",
                    url: "LiquidacionCompra.aspx/guardarDLQ",
                    data: '{LDDATA:' + JSON.stringify(LDDATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        //
                    },
                    error: function (response) {
                        alert('El proceso no se pudo completar LQD');
                        console.table(response);
                    }
                });
            }
            //CABECERA PE
            var actualizaCPE = function () {
                //PROCESO 3:ACTUALIZA N PARTES DE ENTRADAS ELEGIDOS
                var MLEN = IDXI.length
                for (k = 0; k < MLEN; k++) {
                    //var me = IDXI[k];//.toString();//PE N:ELEGIDOS
                    //var ni = me.split("-");
                    //APE.push(ni[1]);

                    var VDATA = {};
                    VDATA.C5_CALMA = Operacion.mask('codAL').val();
                    VDATA.C5_CTD = DI;//DOCUMENTO INGRESO:PE
                    VDATA.C5_CNUMDOC = IDX[k];//APE[k];//CORRELATIVO N PE
                    //VDATA.C5_CCODMOV= "V";VALORIZADO
                    VDATA.C5_CRFTDOC = Operacion.mask('txtTDOC').val().trim();//LQ
                    VDATA.C5_CRFNDOC = (PAR['QTIPDOC'] == "LQ" ? CLQ : Operacion.mask('txtND').val());
                    VDATA.C5_CTIPORD = "5";//ATENDIDO
                    VDATA.C5_CGUIFAC = "S";//FACTURADA
                    //VDATA.C5_CCODMON = Operacion.mask('ddlMON').val();//MONEDA SOLO PARA LQ
                    //VDATA.C5_NTIPCAM = Operacion.mask('txtTIC').val();//CANTIDAD TC
                    //VDATA.C5_CTIPO = PAR['QTIPCAM'];
                    VDATA.C5_CSUBDIA = M_DATA['MISUB'];//Operacion.mask('ddlSDIA').val();//SUBDIARIO
                    VDATA.C5_CCOMPRO = COMP;//CORRELATIVO N. COMPROBANTE
                    //VDATA.C5_CUSUMOD = Operacion.mask('hdUSUARIO').val();//NO ES NECESARIO OPCIONAL.

                    //console.log(VDATA);
                    $.ajax({
                        type: "POST",
                        url: "LiquidacionCompra.aspx/actualizaVCAB",
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
            //DETALLE PE
            var actualizaDPE = function (CP, PR, CA) {
                //console.log(APE);
                //var mi = APE.length;
                //for (var ki = 0; ki < mi; ki++) {
                var VDETA = {};
                VDETA.C6_CALMA = Operacion.mask('codAL').val();
                VDETA.C6_CTD = DI;//DOCUMENTO DE INGRESO
                //VDETA.C6_CNUMDOC = APE;
                //VDETA.C6_CITEM = IT;QUITAR
                VDETA.C6_CCODIGO = CP.trim();
                VDETA.C6_CCANTEN = CA;//CT;
                //VDETA.C6_NPREUN1 = PR;
                //VDETA.C6_NPREUNI = PR;
                //VDETA.C6_NMNPRUN = PR;
                //VDETA.C6_NUSPRUN = PR;
                VDETA.C6_CESTADO = "V";
                //VDETA.C6_NVALTOT = 0;//ST;
                //VDETA.C6_NMNIMPO = 0;//ST;
                //VDETA.C6_NUSIMPO = 0;//ST / Operacion.mask('txtTIC').val();
                VDETA.C6_CSUBDIA = M_DATA['MISUB'];//Operacion.mask('ddlSDIA').val();
                VDETA.C6_CCOMPRO = COMP;
                //VDETA.C6_CCODMON = Operacion.mask('ddlMON').val();
                //VDETA.C6_CTIPO = PAR['QTIPCAM'];
                //VDETA.C6_NTIPCAM = Operacion.mask('txtTIC').val();

                //console.log(VDETA);
                $.ajax({
                    type: "POST",
                    url: "LiquidacionCompra.aspx/actualizaVDET",
                    data: '{ VDETA: ' + JSON.stringify(VDETA) + ',ND:' + JSON.stringify(IDX) + '}',
                    //data: '{ VDETA: ' + JSON.stringify(VDETA) + ',ND:' + JSON.stringify(APE) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        //actualizaDORDEN(NO, PR, IT);
                        return true;
                    },
                    error: function (data) {
                        alert('El proceso no se pudo completar VD');
                        console.log(data);
                    }
                });
            }
            //CARTERA PAGOS
            var insertaCAR = function () {
                //FECHA DOCUMENTO
                var element = M_DATA['FDOC'];//Operacion.mask('txtFEC').val();
                var fecha = element.split('/');
                var FECDOC = fecha[2].substr(2, 2) + "" + fecha[1] + "" + fecha[0];//--------------------------------CP_CFECDOC

                var TD = PAR['QTIPDOC'];
                if (TD == "FT") {
                    //FECHA CONTABLE
                    var element1 = M_DATA['FCOT'];//Operacion.mask('txtFEC0').val();
                    var fecha1 = element1.split('/');
                    var FECDOC1 = fecha1[2].substr(2, 2) + "" + fecha1[1] + "" + fecha1[0];//------------------------CP_CFECCOM

                    //FECHA VENCIMIENTO
                    var element2 = M_DATA['FVEN'];//Operacion.mask('txtFEC1').val();
                    var fecha2 = element2.split('/');
                    var FECVEN = fecha2[2].substr(2, 2) + "" + fecha2[1] + "" + fecha2[0];

                    //FECHA REGISTRO
                }
                //FECHA RECEPCION-REGISTRO
                var element4 = M_DATA['FREC'];//Operacion.mask('txtFREC').val();
                var fecha4 = element4.split('/');
                var NFECHA4 = fecha4[2].substr(2, 2) + "" + fecha4[1] + "" + fecha4[0];//----------------------------CP_CFECREC

                var ATT = M_DATA['MTTASA'];//Operacion.mask('txtCTAS').val();
                var CTASDET = (PAR['QTIPDOC'] == "FT" ? (ATT == "03501" ? ATT : (ATT == "00404" ? ATT : "")) : "");
                var CTASDETI = (PAR['QTIPDOC'] == "FT" ? (ATT == "03501" ? "0002" : (ATT == "00404" ? "0003" : "")) : "");

                var MIMP = [], CMON = [], FDC = [], FVEN = [], FUB = [], FUB1 = [], FUB2 = [], IUS = [], SUS = [], SMN = [], IGMN = [], IGUS = [], CPCTA = [], MAREA = [], TDR = [], AND = [], MFD = [], MFC = [], MFU = [], ACD = [], ASE = [], ACC = [];
                var FVEND = [], ARET = [], FCOMP = [], F_DRE = [], F_CRE = [];
                if (TD == "FT") {
                    MADOC = [M_DATA['DOC'].trim(), M_DATA['DOCD'].trim()];
                    CMON = [PAR['QTIPMON'], (PAR['QTIPMON'] == "US" ? "MN" : "MN")];
                    FDC = [NFECHA4, FECVEN];//FECHA RECEPCION----------------------------------------------------------CP_CFECREC
                    FCOMP = [FECDOC1, FECDOC1];//N 
                    FCOMPD = [moment(element1, 'DD/MM/YYYY'), moment(element1, 'DD/MM/YYYY')];//N 
                    FUB = [FECDOC1, FECDOC1];//FECHA UBICACION
                    FUB1 = [moment(element1, 'DD/MM/YYYY'), moment(element1, 'DD/MM/YYYY')];
                    FUB2 = [moment(element1, 'DD/MM/YYYY'), moment(element, 'DD/MM/YYYY')];
                    FVEN = [FECVEN, FECDOC];//[FECVEN, FECDOC];
                    FVEND = [moment(element2, 'DD/MM/YYYY'), moment(element2, 'DD/MM/YYYY')];
                    MIMP = (PAR['QTIPMON'] == "MN" ?
                            [Number(Operacion.mask('txtRTOV').val()), Number(M_DATA['MIDR'])]
                            : [Operacion.mround(Number(M_DATA['MITOTR'] * M_DATA['MTIPCA']), 2), Number(M_DATA['MIDR'])]);//IMPORTE MM->IMPORTANTE PARA PAGOS[TOTAL VENTA,]
                    IUS = (PAR['QTIPMON'] == "MN" ?
                           [Operacion.mround(Number(M_DATA['MITOTMN'] / M_DATA['MTIPCA']), 2), Operacion.mround(Number(M_DATA['MIDR'] / M_DATA['MTIPCA']), 2)] :
                           [Number(M_DATA['MITOTR']), Operacion.mround(Number(M_DATA['MIDR'] / M_DATA['MTIPCA']), 2)]);
                    SMN = //(PAR['QTIPMON'] == "MN" ?
                          [Number(M_DATA['MINP']), Number(M_DATA['MIDR'])];
                    //: [Number(M_DATA['MINP'] / M_DATA['MTIPCA']), Number(M_DATA['MIDR'])]);//NETO A PAGAR|DETRACCION-RETENCION
                    SUS = //(PAR['QTIPMON'] == "MN" ?
                            [Operacion.mround(Number(M_DATA['MINP'] / M_DATA['MTIPCA']), 2), Operacion.mround(Number(M_DATA['MIDR'] / M_DATA['MTIPCA']), 2)];
                    //: [Operacion.mround(Number(M_DATA['MINP'] / M_DATA['MTIPCA']), 2), Operacion.mround(Number(M_DATA['MIDR'] / M_DATA['MTIPCA']), 2)]);//NP/TC|RD/TC
                    IGMN = (PAR['QTIPMON'] == "MN" ?
                            [Number(M_DATA['MIIGV']), 0] :
                            [Operacion.mround(M_DATA['MIIGV'] * M_DATA['MTIPCA'], 2), 0]);
                    IGUS = (PAR['QTIPMON'] == "MN" ?
                            [Operacion.mround(M_DATA['MIIGV'] / M_DATA['MTIPCA'], 2), 0] :
                            [Number(M_DATA['MIIGV']), 0]);
                    CPCTA = [PAR['CE_CCTACOM'], PAR['QCTAGRD']];
                    MAREA = ['CG', 'CG'];
                    TDR = ['VB', 'FT'];
                    AND = [M_DATA['DOC'], M_DATA['DOC']];//-----AVANCE
                    MFD = ["", FECVEN];//CORREGIDO
                    ACD = ["", CTASDET];//Operacion.mask('txtCTAS').val()];
                    ASE = ["", CTASDETI];// "0003"];
                    ACC = [Operacion.mask('ddlCREF').val(), ""];
                    MFC = [null, moment(element2, 'DD/MM/YYYY')];//FECCRE1];
                    MFU = [null, null];
                    ARET = [2, ""];
                    F_CRE = [moment(element4, 'DD/MM/YYYY'), moment(element4, 'DD/MM/YYYY')];//FECHA CREACION BD ---REVISAR
                    F_DRE = [moment(element4, 'DD/MM/YYYY'), moment(element, 'DD/MM/YYYY')];//element2
                } else {
                    MADOC = [CLQ];//NUMERO DOCUMENTO
                    CMON = [PAR['QTIPMON']];
                    FDC = [NFECHA4];//ORIGINAL:FECDOC
                    FCOMP = [FECDOC];//FECHA COMPROBANTE
                    FCOMPD = [moment(element, 'DD/MM/YYYY')];
                    FUB = [NFECHA4];//FECREC
                    FUB1 = [moment(element4, 'DD/MM/YYYY')];//moment(element1, 'DD/MM/YYYY')
                    //FUB2 = [FECAUX];//--------------------------------------------------------------------------------------
                    FVEN = [FECDOC];
                    FVEND = [moment(element, 'DD/MM/YYYY')];
                    MIMP = [Number(M_DATA['MITOTMN'])];//PAGO SOLES
                    IUS = [Operacion.mround((M_DATA['MITOTMN'] / M_DATA['MTIPCA']), 2)];//PAGO SOLES
                    SMN = [Number(M_DATA['MINP'])];
                    SUS = [Operacion.mround((M_DATA['MINP'] / M_DATA['MTIPCA']), 2)];
                    IGMN = [0];
                    IGUS = [0];
                    CPCTA = [PAR['CE_CCTALIQ']];//421204(MN)
                    MAREA = ['01'];
                    TDR = ['VB'];
                    AND = ['0'];
                    MFD = [NFECHA4];//-------------------------------------------CP_CFDOCRE
                    ACD = [''];
                    ASE = [""];
                    ACC = [""];
                    //MFC = [null, moment(element2, 'DD/MM/YYYY')];
                    MFC = [moment(element4, 'DD/MM/YYYY')];//[FECCRE1];-----------DFDOCRE
                    MFU = [moment(element4, 'DD/MM/YYYY')];//[FECCRE1];
                    ARET = [""];
                    F_CRE = [moment(element4, 'DD/MM/YYYY')];//FECHA CREACION
                    F_DRE = [moment(element4, 'DD/MM/YYYY')];
                }
                //console.log(MADOC);
                for (i = 0; i < MADOC.length; i++) {

                    var CDATA = {};
                    CDATA.CP_CVANEXO = PAR['QTIPANE'];
                    CDATA.CP_CCODIGO = M_DATA['PRO'];//Operacion.mask('lblDNI').text().trim();
                    CDATA.CP_CTIPDOC = PAR['QTIPDOC'];
                    CDATA.CP_CNUMDOC = MADOC[i];
                    CDATA.CP_CFECDOC = FECDOC;
                    CDATA.CP_CFECVEN = FVEN[i];
                    CDATA.CP_CFECREC = FDC[i];
                    CDATA.CP_CSITUAC = "C";//CONTABILIZADA
                    CDATA.CP_CFECCOM = FCOMP[i];//FECDOC;
                    CDATA.CP_CSUBDIA = M_DATA['MISUB'];//Operacion.mask('ddlSDIA').val();
                    CDATA.CP_CCOMPRO = COMP;
                    CDATA.CP_CDEBHAB = "H";//CORRECTO
                    CDATA.CP_CCODMON = CMON[i];//PAR['QTIPMON'];
                    CDATA.CP_NTIPCAM = M_DATA['MTIPCA'];//Operacion.mask('txtTIC').val();
                    CDATA.CP_NIMPOMN = MIMP[i];//Operacion.mask('txtRTOV').val();//TOTAL VENTA
                    CDATA.CP_NIMPOUS = IUS[i];
                    CDATA.CP_NSALDMN = SMN[i];//NETO A PAGAR
                    CDATA.CP_NSALDUS = SUS[i];
                    CDATA.CP_NIGVMN = IGMN[i];//R
                    CDATA.CP_NIGVUS = IGUS[i];//R
                    CDATA.CP_NIMP2MN = 0;//R
                    CDATA.CP_NIMP2US = 0;//R
                    CDATA.CP_NIMPAJU = 0;//R
                    CDATA.CP_CCUENTA = CPCTA[i];//PAR['CE_CCTALIQ'];
                    CDATA.CP_CAREA = MAREA[i];//R
                    CDATA.CP_CFECUBI = FUB[i];//FECREC;
                    CDATA.CP_CTDOCRE = TDR[i];//"VB";//R VISTO BUENO
                    CDATA.CP_CNDOCRE = AND[i];
                    CDATA.CP_CFDOCRE = MFD[i];
                    CDATA.CP_CTDOCCO = "";
                    CDATA.CP_CNDOCCO = "";
                    CDATA.CP_CFDOCCO = "";
                    CDATA.CP_CFECPRO = "";
                    CDATA.CP_CFORMPG = "";
                    CDATA.CP_CCOGAST = (PAR['QTIPDOC'] == "FT" ? "101" : "");//CLASE:101 MATERIA PRIMA
                    CDATA.CP_CDESCRI = Operacion.mask('txtDPRO').val().substring(0, 20);
                    CDATA.CP_DFECCRE = F_CRE[i];//FUB1[i];//FECCRE;
                    CDATA.CP_DFECMOD = null;
                    CDATA.CP_CUSER = Operacion.mask('hdUSUARIO').val();
                    CDATA.CP_NINAFEC = 0;//modificar
                    CDATA.CP_CTIPSUN = "";
                    CDATA.CP_DFECDOC = moment(element, 'DD/MM/YYYY');
                    CDATA.CP_DFECVEN = FVEND[i];//moment(Operacion.mask('txtFEC2').val(), 'DD/MM/YYYY');
                    CDATA.CP_DFECREC = F_DRE[i];//FVEND[i];//FECCRE;
                    CDATA.CP_DFECCOM = FCOMPD[i];//moment(Operacion.mask('txtFEC').val(), 'DD/MM/YYYY');
                    CDATA.CP_DFDOCRE = MFC[i];//FECCRE;
                    CDATA.CP_DFDOCCO = null;
                    CDATA.CP_DFECPRO = null;
                    CDATA.CP_DFECUBI = MFU[i];//FECCRE;
                    CDATA.CP_CIMAGEN = 0;
                    CDATA.CP_CVANERF = "";
                    CDATA.CP_CCODIRF = "";
                    CDATA.CP_CNUMORD = "";
                    CDATA.CP_CTIPO = "";
                    CDATA.CP_CFECCAM = "";
                    CDATA.CP_DFECCAM = null;
                    CDATA.CP_CTASDET = ACD[i];
                    CDATA.CP_CSECDET = ASE[i];
                    CDATA.CP_CCENCOR = ACC[i];
                    CDATA.CP_CRETE = ARET[i];
                    CDATA.CP_NPORRE = 0;

                    //console.log(CDATA);
                    $.ajax({
                        type: "POST",
                        url: "LiquidacionCompra.aspx/guardarCART",
                        data: '{ CDATA: ' + JSON.stringify(CDATA) + '}',
                        contentType: "application/json;charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (data) {
                            //
                        },
                        error: function (data) {
                            alert('El proceso no se pudo completar CART');
                            console.log(data);
                        }
                    });

                }
            }
            //CABECERA ASIENTO
            var asientoCAB = function () {
                var element = M_DATA['FDOC'];
                var fecha = element.split('/');
                var nfecha = fecha[2].substr(2, 2) + "" + fecha[1] + "" + fecha[0];

                //NUEVO 28.06.16
                var elementFC = (M_DATA['MTIPDS'] == "F" ? Operacion.mask('txtFAUX').val() : M_DATA['FDOC']);
                var fechaFC = elementFC.split('/');
                var nfechaFC = fechaFC[2].substr(2, 2) + "" + fechaFC[1] + "" + fechaFC[0];

                if (PAR['QTIPDOC'] == "FT") {
                    //FECHA CONTABLE
                    var element1 = M_DATA['FCOT'];//Operacion.mask('txtFEC0').val();
                    var fecha1 = element1.split('/');
                    var nfecha1 = fecha1[2].substr(2, 2) + "" + fecha1[1] + "" + fecha1[0];
                }

                var fechar = moment();
                var MGLOSA = (PAR['QTIPDOC'] == "FT" ?
                                Operacion.mask('txtDPRO').val().substring(0, 24) + " FT " + Operacion.mask('txtND').val()
                                : "LIQ:" + CLQ + " " + Operacion.mask('txtDPRO').val().substring(0, 24)
                             );

                M_DATA['FLAG'] = (PAR['QTIPDOC'] == "FT" ? "N" : "S");

                var ACAB = {};
                ACAB.CSUBDIA = M_DATA['MISUB'];//Operacion.mask('ddlSDIA').val();
                ACAB.CCOMPRO = COMP;
                ACAB.CFECCOM = (PAR['QTIPDOC'] == "FT" ? nfecha1 : nfecha);//REVISAR
                ACAB.CCODMON = PAR['QTIPMON'];//Operacion.mask('ddlMON').val();
                ACAB.CSITUA = "F";//FINALIZADO
                ACAB.CTIPCAM = Operacion.mask('txtTIC').val();
                ACAB.CGLOSA = MGLOSA;
                ACAB.CTOTAL = Operacion.mround(M_DATA['TOTASI'], 2);
                ACAB.CTIPO = (PAR['QTIPDOC'] == "FT" ? M_DATA['MTIPDS'] : "C");//R
                ACAB.CFLAG = M_DATA['FLAG'];//R
                ACAB.CDATE = fechar;//(PAR['QTIPDOC'] == "FT" ? moment(element1, 'DD/MM/YYYY') : fechar);
                ACAB.CHORA = Operacion.hora();//REEMPLAZAR
                ACAB.CUSER = Operacion.mask('hdUSUARIO').val();
                ACAB.CFECCAM = (PAR['QTIPDOC'] == "FT" ? nfechaFC : "");//REVISAR
                ACAB.CORIG = "CP";//R SISPAG
                ACAB.CFORM = "A";//R
                ACAB.CTIPCOM = (PAR['QTIPDOC'] == "FT" ? "31" : "82");
                ACAB.CEXTOR = "";
                ACAB.CFECCOM2 = (PAR['QTIPDOC'] == "FT" ? moment(element1, 'DD/MM/YYYY') : moment(element, 'DD/MM/YYYY'));//FECHA COMPROBANTE
                ACAB.CFECCAM2 = (PAR['QTIPDOC'] == "FT" ? moment(elementFC, 'DD/MM/YYYY') : "");;//REEMPLAZAR
                ACAB.CMEMO = "";
                ACAB.CSERCER = "";
                ACAB.CNUMCER = "";
                //console.log(ACAB);
                $.ajax({
                    type: "POST",
                    url: "LiquidacionCompra.aspx/guardarACAB",
                    data: '{ ACDATA: ' + JSON.stringify(ACAB) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        anumPAGO();
                    },
                    error: function (data) {
                        alert('El proceso no se pudo completar PLQ');
                        console.log(data);
                    }
                });

            }
            //DETALLE ASIENTO
            var asientoDET = function () {
                var element = M_DATA['FDOC'];//Operacion.mask('txtFEC').val();
                var fecha = element.split('/');
                var nfecha = fecha[2].substr(2, 2) + "" + fecha[1] + "" + fecha[0];
                var fechar = moment();//.format('DD/MM/YYYY');

                //FECHA VENIMIENTO
                if (PAR['QTIPDOC'] == "FT") {
                    //FECHA CONTABLE
                    var F_CP = M_DATA['FCOT'];
                    var fechaX = F_CP.split('/');
                    var nfechaX = fechaX[2].substr(2, 2) + "" + fechaX[1] + "" + fechaX[0];

                    var element1 = M_DATA['FVEN'];//Operacion.mask('txtFEC1').val();
                    var fecha1 = element1.split('/');
                    var nfecha1 = fecha1[2].substr(2, 2) + "" + fecha1[1] + "" + fecha1[0];
                } else {
                    var nfecha1 = "";
                }
                //AC:CUENTA
                var ATT = M_DATA['MTTASA'];//Operacion.mask('txtCTAS').val();
                //FT:03501->0|5,FT:00404->0|6
                var ZONA = (PAR['QTIPDOC'] == "FT" ?
                                (ATT == "03501" ?
                                    ['H', 'H', 'D', 'D', 'D', 'H']
                                : (ATT == "00404" ?
                                    ['H', 'D', 'H', 'D', 'D', 'D', 'H'] :
                                    ""
                                ))
                           : ['H', 'D', 'H', 'D', 'D', 'H']);//---------------------------------------------------------MODIFICAR CON PARAMETROS
                var MFP = (PAR['QTIPDOC'] == "FT" ? PAR['CE_CCTACOM'] : PAR['CE_CCTALIQ']);
                var AC = (PAR['QTIPDOC'] == "FT" ?//CUENTAS
                            //EXONERADO IGV 
                            (ATT == "03501" ?
                                [MFP, PAR['QCTAGRD'], MFP, PAR['QCTACGA'], PAR['PCTACAR'], PAR['PCTAABO']]//AGREGO PARA DIFERENCIA -C
                            //NO EXONERADO
                            : (ATT == "00404" ?
                                [MFP, PAR['QCTAIGV'], PAR['QCTAGRD'], MFP, PAR['QCTACGA'], PAR['PCTACAR'], PAR['PCTAABO']]
                                : ""))
                         : [MFP, PAR['QCTACGA'], PAR['QCTAGRD'], MFP, PAR['PCTACAR'], PAR['PCTAABO']]);//ASIENTOS CONTABLES-A:PAR['QCTAIRE']=>PAR['QCTAGRD']
                AC_X = (PAR['QTIPDOC'] == "FT" ?//CUENTAS AUXILIARES
                            //EXONERADO IGV 
                            (ATT == "03501" ?
                                [MFP, PAR['QCTAGRD'], MFP + "-C", PAR['QCTACGA'], PAR['PCTACAR'], PAR['PCTAABO']]//AGREGO PARA DIFERENCIA -C
                            //NO EXONERADO
                            : (ATT == "00404" ?
                                [MFP, PAR['QCTAIGV'], PAR['QCTAGRD'], MFP + "-C", PAR['QCTACGA'], PAR['PCTACAR'], PAR['PCTAABO']]
                                : ""))
                         : [MFP, PAR['QCTACGA'], PAR['QCTAGRD'], MFP + "-C", PAR['PCTACAR'], PAR['PCTAABO']]);//ASIENTOS CONTABLES-A:PAR['QCTAIRE']=>PAR['QCTAGRD']
                var IC = (PAR['QTIPDOC'] == "FT" ?
                            (ATT == "03501" ?//SIN IGV
                                (PAR['QTIPMON'] == "MN" ?
                                [M_DATA['MITOTMN'], M_DATA['MIDR'], M_DATA['MIDR'], M_DATA['MITOTMN'], M_DATA['MITOTMN'], M_DATA['MITOTMN']] :
                                [M_DATA['MITOTR'], Operacion.mround(M_DATA['MIDR'] / M_DATA['MTIPCA'], 2), Operacion.mround(M_DATA['MIDR'] / M_DATA['MTIPCA'], 2), M_DATA['MITOTR'], M_DATA['MITOTR'], M_DATA['MITOTR']])
                            : (ATT == "00404" ?//CON IGV
                                (PAR['QTIPMON'] == "MN" ?
                                [M_DATA['MITOTR'], M_DATA['MIIGV'], M_DATA['MIDR'], M_DATA['MIDR'], M_DATA['MISUBT'], M_DATA['MISUBT'], M_DATA['MISUBT']] :
                                [M_DATA['MITOTR'], M_DATA['MIIGV'], Operacion.mround(M_DATA['MIDR'] / M_DATA['MTIPCA'], 2), Operacion.mround(M_DATA['MIDR'] / M_DATA['MTIPCA'], 2), M_DATA['MISUBT'], M_DATA['MISUBT'], M_DATA['MISUBT']])
                                : "")
                            )
                         : [M_DATA['MITOTMN'], M_DATA['MITOTMN'], M_DATA['MIDR'], M_DATA['MIDR'], M_DATA['MITOTMN'], M_DATA['MITOTMN']]);//SIEMPRE MN
                var ARC = (PAR['QTIPDOC'] == "FT" ?
                            (ATT == "03501" ?
                                ["01", "33", "31", "", "AT", "AT"]
                            : (ATT == "00404" ?
                                ["01", "", "33", "31", "", "AT", "AT"]
                            : ""))
                           : ["01", "", "", "01", "AT", "AT"]);
                var IDP = Operacion.mask('lblDNI').text().trim();
                var MADOCX = (ATT == "03501" ?
                                    [MADOC[0], MADOC[1], MADOC[0], MADOC[0], MADOC[0], MADOC[0]]
                              : (ATT == "00404" ?
                                    [MADOC[0], MADOC[0], MADOC[1], MADOC[0], MADOC[0], MADOC[0], MADOC[0]]
                                : ""));
                var MDATE = (PAR['QTIPDOC'] == "FT" ?
                                    (ATT == "03501" ? [fechar, fechar, fechar, fechar, null, null] :
                                    (ATT == "00404" ? [fechar, fechar, fechar, fechar, fechar, null, null] : ""))
                            : [fechar, fechar, fechar, fechar, null, null]);
                var VARD = (PAR['QTIPDOC'] == "FT" ?
                                (ATT == "03501" ? [null, moment(element, 'DD/MM/YYYY'), null, null, null, null] :
                                    (ATT == "00404" ? [null, null, moment(element, 'DD/MM/YYYY'), null, null, null, null] : ""))
                            : [""]);


                var PASBAL = [];//
                var LEN = ZONA.length;
                for (i = 0; i < LEN; i++) {
                    MDCTA(AC[i]);
                    //NUEVO 18.06.16
                    //PASBAL[AC[i]] = new Array();//ORIGINAL
                    PASBAL[AC_X[i]] = new Array();//COLUMNAS
                    if (ZONA[i] == "D") {//ORIGINAL AC->AC_X:PARA DIFERENCIA KEY
                        PASBAL[AC_X[i]][ZONA[i]] = Number(IC[i]);//D_SUM;//IMPORTE MONEDA X
                        //console.log(PASBAL[AC_X[i]][ZONA[i]]);
                    } else if (ZONA[i] == "H") {
                        PASBAL[AC_X[i]][ZONA[i]] = Number(IC[i]);//H_SUM;//IMPORTE MONEDA X
                        //console.log(PASBAL[AC_X[i]][ZONA[i]]);
                    }

                    //28.06.16-VALIDA PARA DETRACCIONES REDONDEO
                    var M_VR = (PAR['QTIPDOC'] == "FT" ?
                                    (ATT == "03501" && (i == 1 || i == 2) ? 0 :
                                    (ATT == "00404" && (i == 2 || i == 3) ? 0 : 2)) :
                                2);

                    //DCUENTAS.push(AC_X[i]);
                    DCUENTAS.push(AC[i]);//ORIGINAL
                    var ADET = {};
                    ADET.DSUBDIA = M_DATA['MISUB'];//Operacion.mask('ddlSDIA').val();
                    ADET.DCOMPRO = COMP;
                    ADET.DSECUE = Operacion.cadenaMascara(i + 1, 4);//FOR
                    ADET.DFECCOM = (PAR['QTIPDOC'] == "FT" ? nfechaX : nfecha);
                    ADET.DCUENTA = AC[i];
                    ADET.DCODANE = (RDCTA[AC[i]][0].trim() == "P" ? IDP : "");//(PAR['QTIPDOC'] == "FT" && i != 2 ? IDP : (i == 0 || i == 3 ? IDP : ""));//PROVEEDOR X TD
                    ADET.DCENCOS = "";//RDCTA
                    ADET.DCODMON = PAR['QTIPMON'];
                    ADET.DDH = ZONA[i];
                    ADET.DIMPORT = Number(IC[i]);//----------------------------------------------------------------------SELECCIONADO
                    ADET.DTIPDOC = PAR['QTIPDOC'];//Operacion.mask('txtTDOC').val().trim();//CTD;
                    ADET.DNUMDOC = (PAR['QTIPDOC'] == "FT" ? MADOCX[i] : CLQ);//CLQ;
                    ADET.DFECDOC = nfecha;
                    ADET.DFECVEN = (PAR['QTIPDOC'] == "FT" ? nfecha1 : "");//(RDCTA[AC[i]][3] == "S" ? nfecha1 : "")--VALIDA DEACUERDO A FECHA
                    ADET.DAREA = "";
                    ADET.DFLAG = M_DATA['FLAG'];
                    ADET.DDATE = MDATE[i];//FECHA REGISTRO X CUENTA -fechar;
                    ADET.DXGLOSA = Operacion.mask('txtGLO').val().substring(0, 27);
                    ADET.DUSIMPOR = (PAR['QTIPMON'] == "MN" ? Operacion.mround(Number(IC[i] / M_DATA['MTIPCA']), 2) : Operacion.mround(IC[i], 2));//.toFixed(2);//VALIDAR
                    ADET.DMNIMPOR = (PAR['QTIPMON'] == "MN" ? Operacion.mround(IC[i], 2) : Operacion.mround(Number(IC[i] * M_DATA['MTIPCA']), M_VR));//Number(IC[i]).toFixed(2);//R
                    ADET.DCODARC = ARC[i];//R
                    ADET.DFECCOM2 = (PAR['QTIPDOC'] == "FT" ? moment(M_DATA['FCOT'], 'DD/MM/YYYY') : moment(M_DATA['FDOC'], 'DD/MM/YYYY'));
                    ADET.DFECDOC2 = moment(element, 'DD/MM/YYYY');
                    ADET.DFECVEN2 = (PAR['QTIPDOC'] == "FT" ? moment(element1, 'DD/MM/YYYY') : null);//(RDCTA[AC[i]][3] == "S" ? moment(element1, 'DD/MM/YYYY') : null);
                    ADET.DCODANE2 = (PAR['QTIPDOC'] == "FT" ?
                                        (ATT == "03501" && i == 3 ? Operacion.mask('txtARG').val()
                                        : (ATT == "00404" && i == 4 ? Operacion.mask('txtARG').val() : ""))
                                    : "");//ANEXO REFERENCIA GASTO
                    ADET.DVANEXO = (RDCTA[AC[i]][0].trim() == "P" ? RDCTA[AC[i]][0] : "");/*(PAR['QTIPDOC'] == "FT" && ATT == "03501" && i != 4 || i != 5 ?: ""));*/
                    ADET.DVANEXO2 = (PAR['QTIPDOC'] == "FT" ?
                                        (ATT == "03501" && i == 3 ? RDCTA[AC[i]][2]
                                        : (ATT == "00404" && i == 4 ? RDCTA[AC[i]][2] : ""))
                                   : "");//(RDCTA[AC[i]][2].trim() != "" ? RDCTA[AC[i]][2] : "");//CONFIGURACION
                    ADET.DTIPCAM = 0;
                    ADET.DCANTID = 0;
                    ADET.DCTAORI = (PAR['QTIPDOC'] == "FT" ?
                                        (ATT == "03501" && (i == 4 || i == 5) ? AC[3] :
                                        (ATT == "00404" && (i == 5 || i == 6) ? AC[4] :
                                        "")) :
                                    (i == 4 || i == 5 ? AC[1] : ""));//R:602102-1
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
                    ADET.DTIPDOR = (PAR['QTIPDOC'] == "FT" ?
                                        (ATT == "03501" && i == 1 ? "DR"
                                        : (ATT == "00404" && i == 2 ? "DR" : ""))
                                    : "");
                    ADET.DNUMDOR = (PAR['QTIPDOC'] == "FT" ?
                                        (ATT == "03501" && i == 1 ? M_DATA['DOCD']
                                        : (ATT == "00404" && i == 2 ? M_DATA['DOCD'] : ""))
                                    : "");
                    ADET.DFECDO2 = VARD[i];//FECHA DETRACCION
                    ADET.DTIPTAS = (PAR['QTIPDOC'] == "FT" ?
                                        (ATT == "03501" && i == 1 ? M_DATA['MTTASA']
                                        : (ATT == "00404" && i == 2 ? M_DATA['MTTASA'] : ""))
                                    : "");
                    ADET.DIMPTAS = (PAR['QTIPDOC'] == "FT" ?
                                        (ATT == "03501" && i == 1 ? M_DATA['MMTASA']
                                        : (ATT == "00404" && i == 2 ? M_DATA['MMTASA'] : 0))
                                    : 0);
                    ADET.DIMPBMN = (PAR['QTIPDOC'] == "FT" ?
                                        (ATT == "03501" && i == 1 ? M_DATA['MITOTMN']
                                        : (ATT == "00404" && i == 2 ? M_DATA['MITOTMN'] : 0))
                                    : 0);
                    ADET.DIMPBUS = (PAR['QTIPDOC'] == "FT" ?
                                        (ATT == "03501" && i == 1 ? Operacion.mround(M_DATA['MITOTMN'] / M_DATA['MTIPCA'], 2)
                                        : (ATT == "00404" && i == 2 ? Operacion.mround(M_DATA['MITOTMN'] / M_DATA['MTIPCA'], 2) : 0))
                                    : 0);
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
                    ADET.DRETE = (PAR['QTIPDOC'] == "FT" && i == 0 ? "2" : "");//ACTUALIZAR
                    ADET.DPORRE = 0;
                    //console.log(ADET);
                    $.ajax({
                        type: "POST",
                        url: "LiquidacionCompra.aspx/guardarADET",
                        data: '{ ADDATA: ' + JSON.stringify(ADET) + '}',
                        contentType: "application/json;charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (data) {
                            if (i == (LEN - 1)) {
                                var resolve = balance(PASBAL).rpta;
                                if (resolve == true) {
                                    if (PAR['QTIPDOC'] == "LQ") {
                                        if (confirm('El proceso generó los siguientes documentos: \n Liquidación de compra Nro:' + CLQ + '\n Comprobante Contable 15-' + COMP)) {
                                            if (confirm('Desea Imprimir el documento')) {
                                                window.open("../ALMACEN/Reportes/ReporteRD.aspx?CTD=" + PAR['QTIPDOC'] + "&NUM=" + CLQ + "&COP=" + Operacion.mask('lblDNI').text().trim(), '_blank');
                                                location.reload();
                                            } else {
                                                location.reload();
                                                //window.location.href = '../ALMACEN/ConsultaReimpresion.aspx';
                                            }
                                        } else {
                                            window.location.href = '../ALMACEN/LiquidacionCompra.aspx';
                                        }
                                    } else {
                                        $(':input').removeAttr('placeholder');
                                        if (confirm('El proceso generó los siguientes documentos: \n Comprobante Contable 13-' + COMP + ' Finalizado \n Cartera Actualizada')) {
                                            //DESEA IMPRIMIR EL VOUCHER
                                            window.location.href = '../ALMACEN/LiquidacionCompra.aspx';
                                            //window.location.href = '../ALMACEN/ConsultaReimpresion.aspx';
                                        } else {
                                            window.location.href = '../ALMACEN/LiquidacionCompra.aspx';
                                        }
                                    }
                                }
                            }
                        },
                        error: function (data) {
                            alert('El proceso no se pudo completar ADET');
                            console.log(data);
                        }
                    });
                }
            }
            //REGISTRA PAGO
            var insertaPLQ = function () {
                //CP0003PAGO
                if (PAR['QTIPDOC'] == "FT") {
                    var element = M_DATA['FCOT'];//Operacion.mask('txtFEC').val();
                    var fecha = element.split('/');
                    console.log(fecha);
                    var nfecha = fecha[2].substr(2, 2) + "" + fecha[1] + "" + fecha[0];
                } else {
                    var element = M_DATA['FDOC'];//FECHA CONTABLE
                    var fecha = element.split('/');
                    var nfecha = fecha[2].substr(2, 2) + "" + fecha[1] + "" + fecha[0];
                }

                var DH = M_DATA['MIDR'];//Operacion.mask('txtRREN').val();//IMPORTE DETRACCION-RETENCION
                var TC = M_DATA['MTIPCA'];//Operacion.mask('txtTIC').val();
                var OPX = DH / TC;
                correlativoPG(nfecha, element);

                var PLQDATA = {};
                PLQDATA.PG_CVANEXO = M_DATA['MITANE'];//Operacion.mask('ddlTIA').val().trim();
                PLQDATA.PG_CCODIGO = M_DATA['PRO'];//Operacion.mask('lblDNI').text().trim();
                PLQDATA.PG_CTIPDOC = PAR['QTIPDOC'];//Operacion.mask('txtTDOC').val().trim();
                PLQDATA.PG_CNUMDOC = (PAR['QTIPDOC'] == "LQ" ? CLQ : M_DATA['DOC']);//Operacion.mask('txtND').val());
                PLQDATA.PG_CORDKEY = CORPAG;//REEMPLAZAR
                PLQDATA.PG_CDEBHAB = "D";
                PLQDATA.PG_NIMPOMN = DH;//DETRACCION-RETENCION MN
                PLQDATA.PG_NIMPOUS = Operacion.mround(OPX, 2);//D-R US
                PLQDATA.PG_CFECCOM = nfecha;
                PLQDATA.PG_CSUBDIA = M_DATA['MISUB'];//Operacion.mask('ddlSDIA').val();
                PLQDATA.PG_CNUMCOM = COMP;//CORRELATIVO DEL COMPROBANTE
                PLQDATA.PG_CGLOSA = M_DATA['GLO'].substring(0, 28);//Operacion.mask('txtGLO').val();
                PLQDATA.PG_CCOGAST = "";
                PLQDATA.PG_CORIGEN = "CP";//SISPAG
                PLQDATA.PG_CUSUARI = Operacion.mask('hdUSUARIO').val();
                PLQDATA.PG_CCODMON = PAR['QTIPMON'];//Operacion.mask('ddlMON').val();
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
                        insertaCAR();
                        asientoCAB();
                        asientoDET();
                    },
                    error: function (data) {
                        alert('El proceso no se pudo completar PLQ');
                        console.log(data);
                    }
                });

            }

            //RESUMEN X CUENTA PERIODO
            var balance = function (MIABAL) {
                var ATT = M_DATA['MTTASA'];//Operacion.mask('txtCTAS').val();

                var MN_DEBE = 0;
                var MN_HABER = 0;
                var US_DEBE = 0;
                var US_HABER = 0;

                //FECHAS CONTABLES/DOCUMENTO
                var element = (PAR['QTIPDOC'] == "FT" ? M_DATA['FCOT'] : M_DATA['FDOC']);
                var fecha = element.split('/');
                var FECPRO = fecha[2] + "" + fecha[1];

                var LEN = AC_X.length;//MIABAL.length;
                for (var i = 0; i < LEN; i++) {
                    if (PAR['QTIPMON'] == "MN") {
                        MN_DEBE = (MIABAL[AC_X[i]]['D'] != undefined ? Number(MIABAL[AC_X[i]]['D']) : 0);
                        MN_HABER = (MIABAL[AC_X[i]]['H'] != undefined ? Number(MIABAL[AC_X[i]]['H']) : 0);
                        US_DEBE = (MIABAL[AC_X[i]]['D'] != undefined ? Operacion.mround(MIABAL[AC_X[i]]['D'] / M_DATA['MTIPCA'], 2) : 0);
                        US_HABER = (MIABAL[AC_X[i]]['H'] != undefined ? Operacion.mround(MIABAL[AC_X[i]]['H'] / M_DATA['MTIPCA'], 2) : 0);
                    } else {
                        MN_DEBE = (MIABAL[AC_X[i]]['D'] != undefined ? Operacion.mround(MIABAL[AC_X[i]]['D'] * M_DATA['MTIPCA'], 2) : 0);
                        MN_HABER = (MIABAL[AC_X[i]]['H'] != undefined ? Operacion.mround(MIABAL[AC_X[i]]['H'] * M_DATA['MTIPCA'], 2) : 0);
                        US_DEBE = (MIABAL[AC_X[i]]['D'] != undefined ? Number(MIABAL[AC_X[i]]['D']) : 0);
                        US_HABER = (MIABAL[AC_X[i]]['H'] != undefined ? Number(MIABAL[AC_X[i]]['H']) : 0);
                    }

                    var BDATA = {};
                    BDATA.BCUENTA = (AC_X[i].indexOf('-C') > 0 ? DCUENTAS[i] : DCUENTAS[i]);
                    BDATA.BMNSALA = 0;
                    BDATA.BMNDEBE = MN_DEBE;
                    BDATA.BMNHABER = MN_HABER;
                    BDATA.BMNSALN = 0;
                    BDATA.BUSSALA = 0;
                    BDATA.BUSDEBE = Number(US_DEBE);
                    BDATA.BUSHABER = Number(US_HABER);
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
                        url: "LiquidacionCompra.aspx/actualizaBAL",
                        data: '{ BDATA: ' + JSON.stringify(BDATA) + '}',
                        contentType: "application/json;charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (data) {
                            if (i == 4) { rpta = true; }
                        },
                        error: function (data) {
                            alert('El proceso no se pudo completar BALH');
                            console.log(data);
                        }
                    });
                }
                return { rpta }
            }

            $(".tb4").autocomplete(
            {   //listarAnexoID
                source: function (request, response) {
                    var TM = Operacion.mask('txtIDMOV').val();
                    var DATA = {};
                    DATA.AC_CVANEXO = "P";
                    DATA.AC_CCODIGO = '%' + request.term + '%';
                    DATA.AV_CDOCIDE = (PAR['QTIPDOC'] == "LQ" ? 1 : 6);//VARIAR 1:PL|6:PU
                    DATA.AC_CTIPOAC = (PAR['QTIPDOC'] == "FT" ? "PU" : "PL");

                    Operacion.mask('txtDPRO').val('')
                    Operacion.mask('lblDNI').text('');
                    Operacion.mask('txtDIR').val('');
                    //console.log(DATA);
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
                                    dni: item.AV_CNUMIDE.trim(),
                                    dir: item.AC_CDIRECC.trim(),
                                    id: item.AC_CNOMBRE.trim(),
                                    ta: item.AC_CTIPOAC.trim(),
                                    cta: item.AC_CTASDET.trim()
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
                    var str = ui.item.id, str1 = ui.item.dni, str2 = ui.item.dir, str3 = ui.item.ta; str4 = ui.item.cta;
                    Operacion.mask('txtDPRO').val(str);//Operacion.mask('lblPRO').text(str);
                    Operacion.mask('lblDNI').text((str1 == "" ? alert('La persona no cuenta con un documento registrado') : str1.trim()));
                    Operacion.mask('txtDIR').val(str2);
                    confcc(str3);
                    if (PAR['QTIPDOC'] == "FT") {
                        Operacion.mask('txtCTAS').val(str4);
                        iniciaTITA(str4);
                        verificaDOC();
                    }

                },
                change: function (event, ui) {
                    if (ui.item == null || ui.item == undefined) {
                        alert("No ha seleccionado un proveedor valido");
                        Operacion.mask('txtPRO').focus();
                        Operacion.mask('txtPRO').val('');
                    }
                }
            });
            $(".tb41").autocomplete(
            {   //listarAnexoID
                source: function (request, response) {
                    var TM = Operacion.mask('txtIDMOV').val();
                    var DATA = {};
                    DATA.AC_CVANEXO = "P";
                    DATA.AC_CNOMBRE = '%' + request.term + '%';
                    DATA.AV_CDOCIDE = (PAR['QTIPDOC'] == "LQ" ? 1 : 6);//VARIAR 1:PL|6:PU
                    //DATA.AC_CTIPOAC = PAR['CE_CTIPACR'];
                    DATA.AC_CTIPOAC = (PAR['QTIPDOC'] == "FT" ? "PU" : "PL");

                    //Operacion.mask('txtDPRO').val('')
                    Operacion.mask('txtPRO').val('');
                    Operacion.mask('lblDNI').text('');
                    Operacion.mask('txtDIR').val('');

                    $.ajax({
                        url: "LiquidacionCompra.aspx/listaMaestro",
                        data: '{DATA:' + JSON.stringify(DATA) + '}',
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: false,
                        success: function (data) {

                            response($.map(data.d, function (item) {
                                return {
                                    value: item.AC_CNOMBRE.trim(),
                                    dni: item.AV_CNUMIDE.trim(),
                                    dir: item.AC_CDIRECC.trim(),
                                    id: item.AC_CCODIGO.trim(),
                                    ta: item.AC_CTIPOAC.trim(),
                                    cta: item.AC_CTASDET.trim()
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
                    var str = ui.item.id, str1 = ui.item.dni, str2 = ui.item.dir, str3 = ui.item.ta, str4 = ui.item.cta;
                    Operacion.mask('txtPRO').val(str);
                    Operacion.mask('lblDNI').text((str1 == "" ? alert('La persona no cuenta con un documento registrado') : str1.trim()));
                    Operacion.mask('txtDIR').val(str2);
                    confcc(str3);
                    if (PAR['QTIPDOC'] == "FT") {
                        Operacion.mask('txtCTAS').val(str4);
                        iniciaTITA(str4);
                        verificaDOC();
                    }
                },
                change: function (event, ui) {
                    if (ui.item == null || ui.item == undefined) {
                        alert("No ha seleccionado un proveedor valido");
                        Operacion.mask('txtPROD').focus();
                        Operacion.mask('txtPROD').val('');
                    }
                }
            });
            $(".acARFG").autocomplete(
            {   //listarAnexoID
                source: function (request, response) {
                    var DATA = {
                        AVANEXO: "M",
                        ADESANE: "%" + request.term + "%",
                        ATIPTRA: ""
                    }
                    //console.log(DATA);
                    $.ajax({
                        url: "LiquidacionCompra.aspx/listarAnexo",
                        data: '{DATA:' + JSON.stringify(DATA) + '}',
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    cod: item.ACODANE,
                                    value: item.ADESANE.trim()
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
                    Operacion.mask('txtGLO').val('');
                    $(".acARFG").val(ui.item.cod.trim());
                    var miglosa = Operacion.mask('txtGLO').val();
                    Operacion.mask('txtGLO').val(ui.item.value + "" + miglosa);
                    return false;
                },
                change: function (event, ui) {
                    if (ui.item == null || ui.item == undefined) {
                        alert("No ha seleccionado un codigo valido");
                        Operacion.mask('txtARG').focus();
                        Operacion.mask('txtARG').val('');
                    }
                }
            });
            //INICIALIZA
            //iniciaTC(CODATA, PAR['QTIPCAM']);

            //EVENTOS
            Operacion.mask('ddlSER').change(function () {
                if (PAR['QTIPDOC'] == "FT") {
                    Operacion.mask('txtND').val($(this).val() + "-");
                    Operacion.mask('txtND').focus();
                }
            });
            Operacion.mask('ddlMON').change(function () {
                PAR['QTIPMON'] = $(this).val();
                if (Operacion.mask('txtPRO').val() != "") {
                    confcc(PAR['CE_CTIPACR']);
                }
            });
            Operacion.mask('ddlTDOC').change(function () {
                confpara($(this).val());
                if ($(this).val() == "C7") {
                    confadic();
                    Operacion.mask('ddlSER').focus();
                    //Operacion.mask('txtND').focus();
                } else {
                    //$(':input').removeAttr('placeholder');
                    /*$("#ctl00").find(':input').each(function () {
                        var elemento = this;
                        if (elemento.type == "text") {// || elemento.type == "select-one") {
                            var milabel = elemento.id;
                            var label = milabel.split("_");
                            Operacion.mask(label[1]).val('');
                        }
                    });*/

                    Operacion.inputVisible($('#opcion'), 1);//NUEVO
                    Operacion.mask('txtFAUX').val('');
                    Operacion.mask('txtFEC').val('');
                    Operacion.mask('txtTIC').val('');
                    Operacion.inputVisible($('.detraccion1'), 1);
                    Operacion.inputVisible($('.detraccion2'), 1);
                    Operacion.mask('txtDPRO').focus();
                }

            });
            Operacion.mask('txtTDOC').focus().select();
            Operacion.mask('txtFEC').change(function () {
                if (PAR['QTIPDOC'] == "LQ") {
                    bloqueoFE($(this).val());
                } else {
                    Operacion.mask('txtFEC1').val(Operacion.mask('txtFEC').val());
                    bloqueoFE($(this).val());
                }
            });
            Operacion.mask('txtFEC0').change(function () {
                //PERREG = $(this).val();
                bloqueoFE($(this).val());
            });
            Operacion.mask('ddlTICO').change(function () {

                CODATA.XFECCAM2 = moment(Operacion.mask('txtFEC').val(), 'DD-MM-YYYY');
                if ($(this).val().trim() == "V") {
                    //nuevo 24.06.16
                    var MTC = moment(Operacion.mask('txtFEC').val(), 'DD-MM-YYYY');//FECHA ELEGIDA
                    var MTC1 = moment(MTC).format('YYYYMMDD');//FECHA ELEGIDA NUMEROS
                    var TCA = moment().format('YYYYMMDD');//FECHA ACTUAL
                    var TC = (Number(MTC1) == Number(TCA) ? true : false);
                    if (TC) {
                        iniciaTC(CODATA, $(this).val());
                        Operacion.inputVisible($('#opcion'), 1);//NUEVO
                        Operacion.mask('txtFAUX').val('');
                    } else {
                        alert('La fecha indicada no corresponde favor de cambiar la fecha');
                        Operacion.mask('txtFEC').val('');
                        Operacion.mask('txtFEC1').val('');
                    }

                } else if ($(this).val() == "C") {
                    Operacion.mask('txtTIC').val('');
                    Operacion.inputRead('txtTIC', 0);
                    Operacion.inputVisible($('#opcion'), 1);//NUEVO
                    Operacion.mask('txtFAUX').val('');
                    iniciaTC(CODATA, $(this).val());
                } else if ($(this).val() == "M") {
                    Operacion.inputVisible($('#opcion'), 1);//NUEVO
                    Operacion.mask('txtFAUX').val('');
                    iniciaTC(CODATA, $(this).val());
                } else if ($(this).val() == "F") {
                    Operacion.mask('txtFAUX').select();
                    Operacion.mask('txtTIC').val('0');
                    Operacion.inputVisible($('#opcion'), 0);
                }
            });
            $('input:radio[name=rb]').click(function () {
                //Operacion.inputVisible($('#opcion'), 1);//NUEVO
                CODATA.XFECCAM2 = moment(Operacion.mask('txtFAUX').val(), 'DD-MM-YYYY');
                iniciaTC(CODATA, $(this).val());
            });
            Operacion.mask('txtND').change(function () {
                var md = $(this).val();
                Operacion.mask('txtNDET').val(md + "-D").attr('readonly', true);
                verificaDOC();
                Operacion.mask('txtDPRO').focus();
            });
            Operacion.mask('txtCTAS').change(function () {
                iniciaTITA($(this).val());
                Operacion.mask('txtDPRO').focus();
                iniciaST();
            });
            Operacion.mask('txtARG').change(function () {

            });
            $('#btnConsultar').click(function () {
                AUXO = [];
                AMOVC = [];
                AT.length = 0;
                IDX.length = 0;
                IDXI.length = 0;
                APE.length = 0;
                var M_SERIE = Operacion.mask('ddlSER').val();
                if (valida() && M_SERIE != "-1") {
                    AL = Operacion.mask('ddlALM').val();
                    Operacion.mask('codAL').val(Operacion.mask('ddlALM').val());
                    Operacion.inputEstado('ddlALM', 1, true);
                    Operacion.inputEstado('txtFEC', 1, true);
                    Operacion.inputEstado('btnAceptar', 1, false);
                    $('#MainContent_cblPE').empty();
                    //Operacion.mask('txtDFEC').focus();
                    Operacion.oDialog('detallePE', 1);
                } else {
                    alert('Debe completar los campos requeridos(*)');
                }
            });
            Operacion.mask('txtHFEC').change(function () {
                //PROCESO:1
                Operacion.inputEstado('btnAceptar', 0, false);
                iniciaPE();
            });
            Operacion.mask('txtPRE1').live("change", function () {
                /* $tr = $(this).closest('tr');
                 myRow = $tr.index();
                 var cantidad = $(this).parents("tr").find("td").eq(3).html();
                 var oper = parseFloat(cantidad * $(this).val()).toFixed(2);
                 //Operacion.mask('txtVALT').val(oper);//REEMPLAZAR
                 $("#MainContent_gvDetalle tr:nth-child(" + (myRow + 1) + ") td:nth-child(6)").html(oper);
                 iniciaST();*/
            });
            $("[id*=MainContent_cblPE]").live("click", function () {
                //NO ES NECESARIO
                miespecie = $(this).parents("tr").find("td").eq(1).html();
                if ($(this).is(':checked')) {
                    $(this).each(function () {
                        var value = $(this).val();//VALOR
                        var nitem = $(this).val();
                        var ni = nitem.split('-');
                        IDXI.push(value);// n elementos elegidos:UTILIZO
                        IDX.push(ni[1]);
                        Operacion.mask('HFitems').val(IDXI.length);//CUANTOS ELEGI
                    });
                } else {
                    //LIMPIO ITEMS QUE NO HE ELEGIDO
                    var remove = $(this).val();
                    IDX = jQuery.grep(IDX, function (value) {
                        return value != remove;
                    });
                    Array.prototype.remove = function (v) { this.splice(this.indexOf(v) == -1 ? this.length : this.indexOf(v), 1); }
                    AT.remove(remove);

                }
            });
            $('#btnAceptar').click(function () {
                //PROCESO:2                
                Operacion.mask('btnConsultar', 1, false);
                $('#detallePE').dialog('close');
                M_DATA['PRO'] = Operacion.mask('lblDNI').text().trim();//PROVEEDOR                
                M_DATA['SER'] = Operacion.mask('ddlSER').val();//SERIE
                M_DATA['DOC'] = Operacion.mask('txtND').val();//NUMERO DETRACCION
                M_DATA['DOCD'] = Operacion.mask('txtNDET').val();//NUMERO DETRACCION
                iniciaGrilla();
                //console.log(M_DATA);
            });
            $('#btnGuardar').click(function () {
                if (valida() && Operacion.mask('txtTIC').val() != "0") {
                    if (confirm('Confirma que los datos son conformes:\nAlmacen \nTipo Moneda \Tipo Cambio \nNro Documento \nProveedor \nImporte Retencion/Detracción')) {
                        M_DATA['MITANE'] = Operacion.mask('ddlTIA').val().trim();//----------------------------TIPO ANEXO
                        M_DATA['GLO'] = Operacion.mask('txtGLO').val();//--------------------------------------GLOSA DETALLE
                        //SOLO CASO LQ
                        correlativoCP();
                        if (PAR['QTIPDOC'] == "LQ") {
                            insertaCLQ();
                        }
                        actualizaCPE();
                        var gridView = document.getElementById("<%=gvDetalle.ClientID %>");
                        LEN = gridView.rows.length;
                        for (i = 1; i < LEN; i++) {
                            cellPivot00 = gridView.rows[i].cells[0];
                            gitem00 = cellPivot00.innerHTML;//CODIGO
                            cellPivot01 = gridView.rows[i].cells[1];
                            gitem01 = cellPivot01.innerHTML;//DESCRIPCION
                            cellPivot02 = gridView.rows[i].cells[2];
                            gitem02 = cellPivot02.innerHTML;//UNIDAD
                            cellPivot03 = gridView.rows[i].cells[3];
                            gitem03 = cellPivot03.innerHTML;//CANTIDAD
                            //cellPivot04 = gridView.rows[i].cells[4];
                            //gitem04 = cellPivot04.innerHTML;//PRECIO
                            var input = gridView.rows[i].getElementsByTagName('input');
                            gitem04 = input[0].value;//PRECIO
                            cellPivot05 = gridView.rows[i].cells[5];
                            gitem05 = cellPivot05.innerHTML;//VALTOTAL

                            if (PAR['QTIPDOC'] == "LQ") {
                                insertaDLQ(Operacion.cadenaMascara(i, 4), gitem00, gitem01, gitem03, gitem02, gitem04);//SI HUBIERA MAS ITEMS.OK
                            }
                            //::::::::::|APE:NUMERO DOC,ITEMS,UNIDAD,CANTIDAD,MONTO TOTAL|
                            //actualizaDPE(APE[i - 1], Operacion.cadenaMascara(i, 4), gitem03, gitem04, gitem05);
                            actualizaDPE(gitem00, gitem04, gitem03);
                        }

                        insertaPLQ();
                        //TERMINA Y MUESTRA MENSAJE
                        Operacion.inputEstado('btnGuardar', 1);
                    } else {

                    }
                } else {
                    alert('Verificar que los campos esten completos.');
                }
            });

        });
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
            <legend>Facturacion Materia Prima</legend>
            <table style="width: 99%">
                <tr>
                    <td>&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td>Nro Caja</td>
                    <td colspan="2">
                        <asp:Label ID="lblNCAJ" class="e" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="2">Usuario</td>
                    <td>
                        <asp:Label ID="lblUSER" class="e" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Serie</td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlSER" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td colspan="2">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Agencia&nbsp;</td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlAGE" runat="server"></asp:DropDownList></td>
                    <td colspan="2"></td>
                    <td colspan="5">Fecha Documento</td>
                    <td>
                        <asp:TextBox ID="txtFEC" placeholder="dd/mm/aaaa" class="dp1" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Almacen&nbsp;</td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlALM" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td colspan="2"></td>
                    <td colspan="5">
                        <asp:Label ID="lblFC" class="detraccion1" runat="server" Text="Fecha Vencimiento"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFEC1" placeholder="dd/mm/aaaa" class="dp5 detraccion1" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Moneda&nbsp;</td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlMON" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="5">
                        <asp:Label ID="lblFC0" class="detraccion1" runat="server" Text="Tipo Cambio"></asp:Label>
                    </td>
                    <td>
                        <!--<asp:Label ID="lblTIC" class="e" runat="server" Text=""></asp:Label>-->
                        <asp:DropDownList ID="ddlTICO" class="detraccion1" TabIndex="3" runat="server">
                        </asp:DropDownList>
                        <div id="opcion">
                            <asp:TextBox ID="txtFAUX" class="dp6" runat="server"></asp:TextBox><br />
                            <input id="rb1" name="rb" type="radio" value="C" />Compra<br />
                            <input id="rb2" name="rb" type="radio" value="V" />Venta
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>Tipo Documento</td>
                    <td colspan="2">
                        <asp:TextBox ID="txtTDOC" runat="server" BorderStyle="None" Width="36px"></asp:TextBox>
                        <!--<asp:Label ID="lblTDOC" runat="server" Text=""></asp:Label>-->
                        <asp:DropDownList ID="ddlTDOC" runat="server">
                            <asp:ListItem Value="0" Selected="True">[Elegir]</asp:ListItem>
                            <asp:ListItem Value="C6">Liquidacion de Compra</asp:ListItem>
                            <asp:ListItem Value="C7">Factura</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="5">Detalle Cambio</td>
                    <td>
                        <asp:TextBox ID="txtTIC" runat="server" ReadOnly="TRUE"></asp:TextBox>
                    </td>
                </tr>

                <tr class="detraccion1">
                    <td class="auto-style2">Nro documento</td>
                    <td colspan="2">
                        <asp:TextBox ID="txtND" placeholder="0000-000000" MaxLength="11" TabIndex="1" runat="server"></asp:TextBox></td>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="5">Fecha Contable</td>
                    <td>
                        <asp:TextBox ID="txtFEC0" placeholder="dd/mm/aaaa" class="dp4" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>Tipo Anexo&nbsp;</td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlTIA" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="5">Forma de pago</td>
                    <td>
                        <asp:TextBox ID="txtFPAG" runat="server" TabIndex="3" onkeypress="Operacion.MEKPAT(event,this)"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td>Proveedor</td>
                    <td colspan="10">
                        <asp:TextBox ID="txtPRO" class="tb4" runat="server" Width="119px" TabIndex="2" placeholder="NRO RUC/DNI" onkeypress="Operacion.MEKPAT(event,this)"></asp:TextBox>
                        <asp:TextBox ID="txtDPRO" class="tb41" runat="server" TabIndex="2" Width="415px" placeholder="Nombre del proveedor" onkeypress="Operacion.MEKPAT(event,this)"></asp:TextBox>
                        <!--<asp:Label ID="lblPRO" runat="server" Text=""></asp:Label>-->
                    </td>
                </tr>
                <tr>
                    <td>Nro Doc Identidad&nbsp;&nbsp;</td>
                    <td colspan="2">
                        <asp:Label ID="lblDNI" class="e" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="5">
                        <asp:Label ID="lblCP" runat="server" Text="Calidad Producto"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddlCPRO" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Direccion</td>
                    <td colspan="2">
                        <asp:TextBox ID="txtDIR" TextMode="MultiLine" Rows="3" Columns="40" runat="server" ReadOnly="true"></asp:TextBox>
                    </td>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="5">
                        <asp:Label ID="lblOP" runat="server" Text="Origen Producto"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddlOPRO" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Sub Diario&nbsp;</td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlSDIA" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="5">Glosa&nbsp;&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Tipo Operación&nbsp;</td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlTOPE" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="6">
                        <asp:TextBox ID="txtGLO" runat="server" MaxLength="28" TabIndex="4" onkeypress="Operacion.MEKPAT(event,this)" Width="279px"></asp:TextBox>
                    </td>
                </tr>
                <tr class="detraccion2">
                    <td colspan="11">
                        <div style="padding: 2px; border-radius: 3px; border: 1px solid #808080">
                            <table style="width: 100%; color: blue;">
                                <tr>
                                    <td class="auto-style2">Tipo de Tasa&nbsp;&nbsp;</td>
                                    <td colspan="4">
                                        <asp:TextBox ID="txtCTAS" runat="server" Width="65px"></asp:TextBox>
                                        <asp:TextBox ID="txtDTAS" runat="server" Width="241px"></asp:TextBox>
                                        <!--<asp:DropDownList ID="ddlTITA" runat="server">
                                    </asp:DropDownList>-->
                                    </td>
                                    <td>Tasa</td>
                                    <td>
                                        <asp:TextBox ID="txtTASA" runat="server"></asp:TextBox>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">Nro. Detraccion</td>
                                    <td>
                                        <asp:TextBox ID="txtNDET" runat="server"></asp:TextBox>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>Centro Costo Ref</td>
                                    <td>
                                        <asp:DropDownList ID="ddlCREF" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>Anexo R.F. Gasto</td>
                                    <td>
                                        <asp:TextBox ID="txtARG" class="acARFG" TabIndex="4" onkeypress="Operacion.MEKPAT(event,this)" runat="server"></asp:TextBox>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </div>

                    </td>
                </tr>
                <tr>
                    <td>Observación&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="11">
                        <asp:TextBox ID="txtOBS" TextMode="MultiLine" runat="server" Width="713px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <input id="btnConsultar" tabindex="5" class="btn" type="button" value="Consultar PE" /></td>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="11"></td>
                </tr>
                <tr>
                    <td colspan="11">
                        <asp:GridView ID="gvDetalle" runat="server" Width="100%" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="CODIGO" HeaderText="Codigo" ItemStyle-HorizontalAlign="Right">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripcion" ItemStyle-HorizontalAlign="Right">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="UM" HeaderText="UM" ItemStyle-HorizontalAlign="Right">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CANTIDAD" HeaderText="Cantidad" ItemStyle-HorizontalAlign="Right">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PRECIO" HeaderText="Precio" ItemStyle-HorizontalAlign="Right">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="VALORVENTA" HeaderText="Valor Venta" ItemStyle-HorizontalAlign="Right">
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
                    <td colspan="2">&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="3" class="auto-style1">Valor Venta</td>
                    <td colspan="2" style="text-align: right; background-color: white; font-weight: bold">
                        <asp:Label ID="lblVV" runat="server" Text="0.00"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="3" class="auto-style1">IGV</td>
                    <td colspan="2" style="text-align: right; background-color: white; font-weight: bold">
                        <asp:Label ID="lblIGV" runat="server" Text="0.00"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="3" class="auto-style1">Total Venta</td>
                    <td colspan="2" style="background-color: white; text-align: right; font-weight: bold">
                        <asp:Label ID="lblTV" runat="server" Text="0.00"></asp:Label>
                    </td>
                </tr>
            </table>
        </fieldset>
        <fieldset>
            <legend>Retenciones y Neto a pagar</legend>
            <table style="width: 100%;">
                <tr>
                    <td>&nbsp;</td>
                    <td>Total Venta</td>
                    <td>&nbsp;</td>
                    <td>Retención IGV</td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Label ID="lblRD" runat="server" Text="Retención Renta 1.5%"></asp:Label></td>
                    <td>&nbsp;</td>
                    <td>Neto a pagar</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtRTOV" Style="text-align: right" runat="server" value="0.00" Font-Bold="True" ForeColor="Blue" ReadOnly="true"></asp:TextBox></td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtRIGV" Style="text-align: right" runat="server" value="0.00" Font-Bold="True" ForeColor="Blue" ReadOnly="true"></asp:TextBox></td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtRREN" Style="text-align: right" runat="server" value="0.00" Font-Bold="True" ForeColor="Blue" ReadOnly="True"></asp:TextBox></td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="txtRNPA" Style="text-align: right" runat="server" value="0.00" Font-Bold="True" ForeColor="Blue" ReadOnly="true"></asp:TextBox></td>
                </tr>
            </table>
        </fieldset>
        <table style="text-align: right; width: 99%;">
            <tr>
                <td>&nbsp;</td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td>
                    <input id="btnGuardar" class="btn" type="button" value="Guardar" /></td>
            </tr>
        </table>
        <div id="detallePE" title="Detalle Parte de Entrada" style="display: none;">
            <fieldset style="width: 680px;">
                <legend>Seleccionar</legend>
                <table>
                    <tr>
                        <td>&nbsp;</td>
                        <td></td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>Desde</td>
                        <td>
                            <asp:TextBox ID="txtDFEC" placeholder="dd/mm/aaaa" class="dp2" runat="server"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>Hasta</td>
                        <td>
                            <asp:TextBox ID="txtHFEC" placeholder="dd/mm/aaaa" class="dp3" runat="server"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="3"></td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div id="cblPET" style="width: 650px;">
                                <asp:CheckBoxList ID="cblPE" runat="server">
                                    <asp:ListItem Text="" Value="-"></asp:ListItem>
                                </asp:CheckBoxList>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <input id="btnAceptar" class="btn" type="button" value="Aceptar" />
                            <asp:HiddenField ID="HFitems" runat="server" />
                        </td>
                    </tr>
                </table>
            </fieldset>

        </div>
    </div>
    <br />
</asp:Content>
