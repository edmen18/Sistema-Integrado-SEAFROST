<%@ Page Title="Valorizacion Manual de Movimientos" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ValorizacionMM.aspx.cs" Inherits="ValorizacionMM" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link type="text/css" href="../CSS/base.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {
            UHTML.id = 'MainContent';
            var AL = Operacion.mask('codAL').val();
            var FEC1 = "";
            var FEC2 = "";
            var TD = "";
            var ND = "";
            var IT = "", NOS = "";
            MARRAY = [],A_MP=[], PERMISO = [], M_DATA = [], M_DATA1 = [];
            OAUX = [];//CABECERA|ULTIMO ITEM:20(PROVINCIA)
            DOAUX = [];//DETALLE
            var CODATA = {};
            var $tr, $tr1;
            var myRow, myRow1;

            Operacion.mask('txtalcandeMA').hide();
            $(".dp1").datepicker();
            $(".dpFecha1").datepicker();
            $('.dpFecha2').datepicker({
                changeMonth: true,
                changeYear: true,
                showButtonPanel: true,
                dateFormat: 'mm/yy',
                onClose: function (dateText, inst) {
                    var month = $("#ui-datepicker-div .ui-datepicker-month :selected").val();
                    var year = $("#ui-datepicker-div .ui-datepicker-year :selected").val();
                    //$(this).datepicker('setDate', new Date(year, month, 1));
                }
            });

            Operacion.inputVisible($('#opcion'), 1);//ACTUALIZAR-TC COMPRA/VENTA
            Operacion.oDialog('detalle', false);
            Operacion.oDialog('aprobar', false);
            var dialogOpts = {
                buttons: {
                    "Ok": "",
                    "Cancel": ""
                }
            };
            //$.extend(mi_dialog, dialogOpts);

            Operacion.inputVisible($('#btnSalida'), 1);
            //Operacion.mask('ddlMalmacen').val(Operacion.mask('codAL').val());
            //Operacion.inputEstado('txtFC', 1, true);
            Operacion.inputVisible(Operacion.mask('lblFC'), 1);
            Operacion.inputVisible(Operacion.mask('txtFC'), 1);

            //NUEVO
            var MIALM = Operacion.mask('codAL').val();
            var MIALMD = (MIALM == "A002" || MIALM == "A004" || MIALM == "0015" ? 'CONG' :
                            (MIALM == "0004" || MIALM == "0008" ? 'CONS' : ""));

            var enviarCorreo = function (ID) {
                var DATA = [];
                DATA.push(M_DATA[0]);
                DATA.push(M_DATA[1]);
                DATA.push(M_DATA[2]);
                //--------
                M_DATA1[2] = OAUX[ID][8].trim();//RUC/DNI ORIGINAL
                M_DATA1[3] = OAUX[ID][9].trim();//DESCRIPCION 

                var DATA_A = [];
                DATA_A[0] = M_DATA1[0];
                DATA_A[1] = M_DATA1[1];
                DATA_A[2] = M_DATA1[2];
                DATA_A[3] = M_DATA1[3];
                DATA_A[4] = Operacion.mask('hdUSUARIO').val();//USUARIO MODIFICACION
                DATA_A[5] = M_DATA1[5];
                DATA_A[6] = M_DATA1[6];
                //console.log(DATA);
                //console.log(DATA_A);
                $.ajax({
                    type: "POST",
                    url: "ValorizacionMM.aspx/enviofinalemail",
                    data: '{DATA:' + JSON.stringify(DATA) + ',DATA_A:' + JSON.stringify(DATA_A) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        alert("Se envio email para su verificación");
                    },
                    error: function (response) {
                        //if (response.length != 0)
                        console.log(response);
                    }
                });
            }
            var inicia = function (CA) {
                $.ajax({
                    type: "POST",
                    url: "ValorizacionMM.aspx/ListarParametroID",
                    data: "{COD:'TS',KEY:'CONG'}",
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        //console.log(data);
                        MARRAY[0] = data.d.AF_TDESCRI1;
                        MARRAY[2] = data.d.AF_TDESCRI2;

                        //MARRAY.push(data.d);
                    },
                    error: function (response) {
                        console.log(response);
                    }
                });
                //console.log(MARRAY);
            }
            var inicia1 = function () {
                $.ajax({
                    type: "POST",
                    url: "ValorizacionMM.aspx/ListarParametroID",
                    data: "{COD:'PO',KEY:'01'}",
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        MARRAY[1] = data.d.AF_TDESCRI1;
                        //MARRAY.push(data.d);
                    },
                    error: function (response) {
                        console.log(response);
                    }
                });

            }
            var iniciaPGE = function (CO) {
                $.ajax({
                    type: "POST",
                    url: "ValorizacionMM.aspx/ListarParametroID",
                    data: "{COD:'PV',KEY:'" + Operacion.mask('hdUSUARIO').val() + "'}",
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        if (data.d) {
                            PERMISO[0] = data.d.AF_TDESCRI1;
                            PERMISO[1] = data.d.AF_TDESCRI2;
                            PERMISO[2] = data.d.AF_TDESCRI3;
                        } else {
                            PERMISO[0] = "";
                            PERMISO[1] = "";
                            PERMISO[2] = "";
                        }
                    },
                    error: function (response) {
                        console.log(response);
                    }
                });
            }
            //ALMACENES DE MATERIA PRIMA
            var iniciaPGE1 = function (CO) {
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
                                A_MP.push(v.AF_TDESCRI2);
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
            iniciaPGE1("MP");
            iniciaPGE("PV");
            inicia(MIALMD);
            inicia1();

            var DER = function (bw) {
                if (bw) {
                    Operacion.inputVisible(Operacion.mask('lblLDER'), 0);
                    Operacion.inputVisible(Operacion.mask('lblDER'), 0);
                } else {
                    Operacion.inputVisible(Operacion.mask('lblLDER'), 1);
                    Operacion.inputVisible(Operacion.mask('lblDER'), 1);
                }
            }
            var valida = function () {
                //EXCEPTION:'txtTDRef2', 'txtNroDocumento2',
                return Operacion.iVALC(['txtPRO', 'txtDORE', 'ddlMN',
                    'txtNDOC', 'txtTICA']);
            }
            var bloqueo = function (op) {
                //alert(op);
                switch (op) {
                    case 1:
                        //Operacion.inputEstado('txtPRO', 1, true);
                        Operacion.inputEstado('txtDORE', 1, true);
                        Operacion.inputEstado('txtNDOC', 1, true);
                        Operacion.inputEstado('txtSUB', 1, true);
                        Operacion.inputEstado('txtCOM', 1, true);
                        Operacion.inputEstado('ddlMN', 1, true);
                        Operacion.inputEstado('ddlTICO', 1, true);
                        Operacion.inputEstado('txtTICA', 1, true);
                        if (M_DATA[6] == "2") {
                            //console.log(M_DATA1[7]);
                            Operacion.inputEstado('txtPRO', 0, true);
                            Operacion.inputEstado('btnGuardar', 0, false);
                            $('#btnGuardar').val('Actualizar');
                        } else {
                            Operacion.inputEstado('txtPRO', 1, true);
                            Operacion.inputEstado('btnGuardar', 1, false);
                            $('#btnGuardar').val('Valorizar');
                        }
                        Operacion.inputEstado('cbIGV', 1, true);
                        break;
                    case 2:
                        Operacion.inputEstado('txtPRO', 0, true);
                        Operacion.inputEstado('txtDORE', 0, true);
                        Operacion.inputEstado('txtNDOC', 0, true);
                        Operacion.inputEstado('txtSUB', 0, true);
                        Operacion.inputEstado('txtCOM', 0, true);
                        Operacion.inputEstado('ddlMN', 0, true);
                        Operacion.inputEstado('ddlTICO', 0, true);
                        Operacion.inputRead('txtTICA', 1);
                        //Operacion.inputEstado('cbIGV', 0, true);
                        //Operacion.inputEstado('txtTICA', 1, true);
                        Operacion.inputEstado('btnGuardar', 0, false);
                        break;
                }

            }
            //VERIFICA PARTES VALORIZADOS
            var todoOK = function () {
                var CONT = 0;
                var gridView = document.getElementById("<%=gvDetalle.ClientID %>");
                var MILEN = gridView.rows.length;
                for (var t = 1; t < MILEN; t++) {

                    //cellPivot = gridView.rows[t].cells[0]; gitem = cellPivot.innerHTML;//OK
                    //cellPivot02 = gridView.rows[t].cells[1]; gidcod = cellPivot02.innerHTML;//OK
                    //cellPivot03 = gridView.rows[t].cells[2]; gdescod = cellPivot03.innerHTML;//OK
                    //cellPivot04 = gridView.rows[t].cells[4]; gunid = cellPivot04.innerHTML;//OK
                    //cellPivot05 = gridView.rows[t].cells[5]; gcant = cellPivot05.innerHTML;
                    var inputs = gridView.rows[t].getElementsByTagName('input');
                    gprecinicial = inputs[0].value;
                    //cellPivot24 = gridView.rows[t].cells[7]; gtmn01 = cellPivot24.innerHTML;
                    if (Number(gprecinicial) == 0) {
                        CONT++;
                    }
                }
                return { CONT }
            }
            //TIPO CAMBIO
            var obtieneTC = function (CODATA, OP) {

                $.ajax({
                    type: "POST",
                    url: "RegistroEntradaOC.aspx/getTC",
                    data: '{CODATA:' + JSON.stringify(CODATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {

                        if (typeof data.d != 'undefined' && data.d != null) {
                            Operacion.mask('txtTICA').val((OP == "M" ? data.d['XMEIMP'] : data.d['XMEIMP2']));
                        } else {
                            Operacion.mask('txtTICA').val('');
                        }
                    },
                    error: function (response) {
                        console.log(response);
                    }
                });
            }
            var cargar = function () {
                llenarGrilla(Operacion.mask('ddlMalmacen').val(), "PE", Operacion.mask('txtalcanceDia').val(), 
                    Operacion.mask('txtalcandeMA').val(), Operacion.mask('txtMNumeroDoc').val(), $("input[type='radio'].vb:checked").val());
            }
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
            var iniciaST = function () {
                var gridView1 = document.getElementById("<%=gvDetalle.ClientID %>");
                LEN = gridView1.rows.length;
                acum = 0, acum1 = 0, acum2 = 0;
                for (var t = 1; t < LEN; t++) {
                    //NUEVO 09.07.16 - DESVALVE
                    var input = gridView1.rows[t].getElementsByTagName('input'); //SI FUERA UN INPUT DENTRO DE UN TD
                    control60 = gridView1.rows[t].cells[5];//A:7
                    control61 = control60.innerHTML;//input[0].value-input[1].value //CANTIDAD KG
                    //SUBTOTAL
                    control50 = gridView1.rows[t].cells[8];//A:7
                    control51 = control50.innerHTML;
                    acum += Number(control51);
                    //NUEVO 09.07.16
                    acum1 += Number(control61 * input[0].value);//SUBTOTAL DESVALVE
                    acum2 += Number(control61 * input[1].value);//SUBTOTAL DESVALVE
                }
                Operacion.mask('hfST').val(acum.toFixed(2));
                var M_IGV = (Operacion.mask('cbIGV').attr('checked') == true ? Number(acum * 0.18).toFixed(2) : 0);
                var M_IGV1 = (Operacion.mask('cbIGV').attr('checked') == true ? Number(acum1 * 0.18).toFixed(2) : 0);
                //var M_IGV1 = (Operacion.mask('cbIGV').attr('checked') == true ? Number(acum2 * 0.18).toFixed(2) : 0);
                Operacion.mask('hfIGV').val(Number(M_IGV).toFixed(2));
                Operacion.mask('hfTOT').val((Number(acum) + Number(M_IGV)).toFixed(2));
                Operacion.mask('hfVAL1').val(Operacion.mround(acum1 + Number(M_IGV1), 2));//OC[ACTUALIZACIÓN O/C] subir
                Operacion.mask('hfVAL2').val(Operacion.mround(Number(acum2) + Number(acum2 * 0.18), 2));
                //Operacion.mask('hfVAL2').val(Operacion.mround(acum2, 2) + (Number(acum * 0.18).toFixed(2)));//OS SIEMPRE IGV
            }
            var llenarGrilla = function (AL, TD, FEC1, FEC2, ND,FIL) {
                var CDATA = {};
                CDATA.C5_CALMA = AL;
                CDATA.C5_CTD = TD;
                CDATA.C5_CNUMDOC = ND;
                CDATA.C5_DFECDOC = moment(FEC1, 'DD-MM-YYYY 00:00:00.000');
                CDATA.C5_DFECCRE = FEC2;
                CDATA.C5_CCODAUT = (FIL == "PA" ? "" : 1);
                console.log(CDATA);
                $.ajax({
                    type: "POST",
                    url: "ValorizacionMM.aspx/listaFinal",
                    data: '{ CDATA: ' + JSON.stringify(CDATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        Operacion.mask('gvVMM').attr('style', 'background-color:White;border-color:#CCCCCC;border-width:1px;border-style:None;border-collapse:collapse;');
                        //var verifica = ($('.vb').is(':checked')==true?data.d[i].C5_CCODAUT:"");
                        if (data.d.length > 0) {
                            Operacion.mask('gvVMM').empty();
                            Operacion.mask('gvVMM').append("<tr style='color:White;background-color:#006699;font-weight:bold;'><th align='center' scope='col' style='font-size:8pt;width:50px;'>TD</th><th align='center' scope='col' style='font-size:8pt;width:90px;'>Nro Documento</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>OC</th><th align='center' scope='col' style='font-size:8pt;width:60px;'>MONEDA</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Fecha Documento</th><th align='center' scope='col' style='font-size:8pt;width:50px;'>Mov</th><th align='center' scope='col' style='font-size:8pt;width:70px;'>Situacion</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Glosa</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>AP1</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>AP2</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Accion</th></tr>");
                            for (var i = 0; i < data.d.length; i++) {
                                //var verifica = ($("input[type='radio'].vb").val() == "PA" ? (data.d[i].C5_CCODAUT == "") : (data.d[i].C5_CCODAUT != ""));
                                //console.log(verifica);
                                //if (verifica) {
                                    OAUX[AL + "" + data.d[i].C5_CTD + "" + data.d[i].C5_CNUMDOC] = [
                                        (data.d[i].C5_CSOLI.trim() != "" ? (data.d[i].C5_CSOLI + " " + data.d[i].NOMSOL) : ""),
                                        (data.d[i].C5_CCENCOS.trim() != "" ? (data.d[i].C5_CCENCOS + " " + data.d[i].NOMCC) : ""),
                                        data.d[i].C5_CCODMON,
                                        (data.d[i].C5_CCODMOV + " " + data.d[i].NOMMOV),
                                        data.d[i].C5_CRFTDOC,
                                        data.d[i].NOMDR,
                                        data.d[i].C5_CRFNDOC,
                                        data.d[i].C5_CGLOSA1,
                                        data.d[i].C5_CCODPRO,//8:CODIGO PROVEEDOR
                                        data.d[i].C5_CNOMPRO,//9:DESCRIPCION PROVEEDOR
                                        data.d[i].C5_NTIPCAM,
                                        data.d[i].C5_CNUMORD,//11:NRO ORDEN
                                        data.d[i].C5_CGLOSA4,//12:DER
                                        data.d[i].C5_CRFNDO2, //ORIGEN
                                        data.d[i].C5_CSUBDIA,//14:SUBDIARIO
                                        data.d[i].C5_CCOMPRO,//15:NUMERO COMPROBANTE
                                        "",
                                        "",
                                        data.d[i].C5_CCENCOS, //18
                                        "",
                                        "",
                                        "",
                                        data.d[i].C5_CGLOSA2,
                                        data.d[i].C5_CORDEN,
                                        data.d[i].NOMBAH,
                                        data.d[i].C5_CSBNOM,//25:IGV
                                        data.d[i].C5_CLICCON//26:ORDEN COMPRA 
                                    ];

                                    var mipro = data.d[i].C5_CNOMPRO;
                                    //NOS = data.d[i].C5_CLICCON;//ORDEN DE SERVICIO
                                    var mipro1 = mipro.replace(',', '');
                                    var OCE = obtenerEOC(data.d[i].C5_CNUMORD).estado;
                                    var RPTA = (OCE == "8" ? "[FINALIZADA]" : (OCE == "2" ? "[APROBADA]" : (OCE == "1" ? "[EMITIDA]" : "-")));
                                    M_DATA[7] = (data.d[i].C5_CCODAUT != "" ? data.d[i].C5_CCODAUT : "");
                                    var APRO = (PERMISO[0] == "A" || PERMISO[0] == "A/V" && jQuery.inArray(PERMISO[2], A_MP) !== -1 && OCE != "8" ? (data.d[i].C5_CCODAUT != "" ? data.d[i].C5_CCODAUT :
                                                    "<div id=" + data.d[i].C5_CNUMDOC + " class='btAprobar' style='text-align:center'><img title='Aprobar' alt='' src='../Images/Detalle.png' width='25' style='cursor:pointer;float:left;'>Por Aprobar</div>")
                                                    : data.d[i].C5_CCODAUT);
                                    Operacion.mask('gvVMM').append("<tr><td style='font-size:8pt;text-align:center;'>" +
                                        data.d[i].C5_CTD + "</td><td style='font-size:8pt;text-align:center;'>" +
                                        data.d[i].C5_CNUMDOC + "</td><td style='font-size:8pt;text-align:left;'>&nbsp;<a href='../ORDENCOMPRA/REPORTES/ReporteOrden.aspx?ID=" + data.d[i].C5_CNUMORD + "&IDPROC=" + data.d[i].C5_CCODPRO + "&IDAG=0003&DEPRO=" + mipro1 + "' target=_blank>" +
                                        (data.d[i].C5_CGLOSA4.trim() == "" ? data.d[i].C5_CNUMORD : data.d[i].C5_CNUMORD) + "</a> " + RPTA + "</td><td style='font-size:8pt;text-align:center;'>" +
                                        (data.d[i].C5_CCODMON.trim() == "" ? "-" : data.d[i].C5_CCODMON) + "</td><td style='font-size:8pt;text-align:center;'>" +
                                        data.d[i].C5_DFECDOC + "</td><td style='font-size:8pt;text-align:center;'>" +
                                        data.d[i].C5_CCODMOV + "</td><td style='font-size:8pt;text-align:center;'>" +
                                        data.d[i].C5_CSITUA + "</td><td style='font-size:8pt;'>" +
                                        data.d[i].C5_CGLOSA1 + "</td><td style='font-size:8pt;text-align:center'>" +
                                        data.d[i].C5_CUSUCRE + "</td><td style='font-size:8pt;text-align:center'>" +
                                        APRO + "</td><td style='width:100px;text-align:center'>" +
                                        (PERMISO[0] == "V" || PERMISO[0] == "A/V" && jQuery.inArray(PERMISO[2], A_MP) !== -1 ? "<div id='" + data.d[i].C5_CNUMDOC + "' class='btDetalle' style='text-align:center'><img title='Valorizar' alt='' src='../Images/details.png' width='25' style='cursor:pointer;float:left;'></div>" : "") + "<div class='btPrinter' style='text-align:center'><img alt='' src='../Images/Printer.png' width='25' style='cursor:pointer;float:left;'></div>" + (OCE == "2" ? "<div id=" + data.d[i].C5_CNUMORD + " class='btAnticipo' style='text-align:center'><img alt='' src='../Images/anticipo.png' title='Anticipo' width='25' style='cursor:pointer;float:left;'></div>" : "") + "</td></tr>");
                                //}
                            }
                        } else {
                            Operacion.mask('gvVMM').empty();
                            Operacion.mask('gvVMM').append("<tr style='color:White;background-color:#006699;font-weight:bold;'><th align='center' scope='col' style='font-size:8pt;width:100px;'>TD</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Nro Documento</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Nro Documento</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>MN</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Fecha Documento</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Mov</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Situacion</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Glosa</th><th align='center' scope='col' style='font-size:8pt;'>Accion</th></tr>");
                            Operacion.mask('gvVMM').append("<tr><td style='font-size:8pt;'>-</td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td></tr>");
                        }
                    },
                    error: function (result) {
                        console.log(result);
                    }
                });
            }
            var obtenerEOC = function (OC) {
                var INFO = {};
                INFO.OC_CNUMORD = OC;
                var estado = "";
                $.ajax({
                    type: "POST",
                    url: "ValorizacionMM.aspx/Getcabecerae",
                    data: '{ INFO: ' + JSON.stringify(INFO) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        //console.log(data);
                        if (data.d) {
                            M_DATA = [data.d.OC_CUSEA01, data.d.OC_CUSEA02, data.d.OC_CUSEA03, data.d.OC_DFECR01, data.d.OC_DFECR02, data.d.OC_DFECR03, data.d.OC_CSITORD];
                            estado = data.d.OC_CSITORD;
                            //console.log(M_DATA);
                        } else {
                            M_DATA = ["", "", "", "", "", "", "", M_DATA[7]];
                            estado = 0;
                        }
                    },
                    error: function (data) {
                        console.log(data);
                    }
                });
                return { estado }

            }
            //GENERA OC
            var generaOC = function (ID) {
                obtieneALDIR(ID);
                registraCOC(ID, "1");
                recoreDetalle(ID, "1");
            }
            //GENERA OS
            var generaOS = function (ID) {
                if (OAUX[ID][26] != "") {
                    //Operacion.mask('codM').val(OAUX[ID][26]);
                    NOS = OAUX[ID][26];
                } else {
                    correlativoOC("2");
                }
                obtieneALDIR(ID);
                registraCOC(ID, "2");
                recoreDetalle(ID, "2");
            }

            var valorizar = function () {
                var MI_OC = Operacion.mask('txtOC').val().trim();
                var VDATA = {};
                VDATA.C5_CALMA = AL;
                VDATA.C5_CTD = TD;
                VDATA.C5_CNUMDOC = ND;
                VDATA.C5_CRFTDOC = OAUX[AL + "PE" + ND][4];
                VDATA.C5_CRFNDOC = OAUX[AL + "PE" + ND][6];
                VDATA.C5_NTIPCAM = OAUX[AL + "PE" + ND][10];//TIPO CAMBIO
                VDATA.C5_CTIPO = OAUX[AL + "PE" + ND][17];
                VDATA.C5_CCODPRO = OAUX[AL + "PE" + ND][8];
                VDATA.C5_CNOMPRO = OAUX[AL + "PE" + ND][9];
                VDATA.C5_CCODMON = OAUX[AL + "PE" + ND][2];
                VDATA.C5_CSUBDIA = OAUX[AL + "PE" + ND][14];
                VDATA.C5_CCOMPRO = OAUX[AL + "PE" + ND][15];
                VDATA.C5_CNUMORD = (MI_OC != "" ? MI_OC : Operacion.mask('codM').val().trim());
                VDATA.C5_CSBNOM = ($('#MainContent_cbIGV').is(':checked') == true ? "1" : "0");//IGV;
                VDATA.C5_CLICCON = NOS;//NUMERO
                //C5_CRFTDO2 <- FT <-2:SERVICIO DESVALVE-CONCHA
                //C5_CVENDE2 NRO FACTURA 2 - SERVICIO
                //C5_CNUMLIQ <- NUMERO LIQUIDACION GENERADA
                VDATA.C5_CUSUMOD = Operacion.mask('hdUSUARIO').val();

                $.ajax({
                    type: "POST",
                    url: "ValorizacionMM.aspx/valorizaCabecera",
                    data: '{ VDATA: ' + JSON.stringify(VDATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        //return true;
                        cargar();
                    },
                    error: function (data) {
                        console.log(data);
                    }
                });
            }

            var valorizarD = function (AL, TD, ND, IT) {

                var MONEDA = Operacion.mask('ddlMN').val();
                var TIPOCA = Operacion.mask('txtTICA').val();
                var A_PMNUS = DOAUX[AL + "PE" + ND + "" + IT][1];
                var A_PUSMN = DOAUX[AL + "PE" + ND + "" + IT][2];
                //NUEVO 09.07.16
                var A_PMNUS1 = DOAUX[AL + "PE" + ND + "" + IT][9];//DESVALVE PRECIO
                var A_PUSMN1 = DOAUX[AL + "PE" + ND + "" + IT][10];//DESVALVE PRECIO
                //TOTAL
                var M_OPERA = DOAUX[AL + "PE" + ND + "" + IT][3];//CANTIDAD POR PRECIO
                //valorizaDetalle
                var VDETA = {};
                VDETA.C6_CALMA = AL;
                VDETA.C6_CTD = TD;
                VDETA.C6_CNUMDOC = ND;
                VDETA.C6_CITEM = IT;
                VDETA.C6_NPREUN1 = Number(A_PMNUS);
                VDETA.C6_NPREUNI = Number(A_PMNUS);
                VDETA.C6_NMNPRUN = (MONEDA == "US" ? Number(A_PMNUS * TIPOCA) : Number(A_PMNUS));
                VDETA.C6_NUSPRUN = Number(A_PUSMN);
                VDETA.C6_NVALTOT = Number(M_OPERA);
                VDETA.C6_NMNIMPO = (MONEDA == "US" ? Number(M_OPERA * TIPOCA) : Number(M_OPERA));
                VDETA.C6_NUSIMPO = DOAUX[AL + "PE" + ND + "" + IT][4];
                VDETA.C6_CCODMON = DOAUX[AL + "PE" + ND + "" + IT][5];
                VDETA.C6_CTIPO = DOAUX[AL + "PE" + ND + "" + IT][6];
                VDETA.C6_NTIPCAM = DOAUX[AL + "PE" + ND + "" + IT][7];
                VDETA.C6_CESTADO = DOAUX[AL + "PE" + ND + "" + IT][8];
                VDETA.C6_NPRECIO = A_PMNUS1;//DOAUX[AL + "PE" + ND + "" + IT][9];//DESVALVE SOLES
                VDETA.C6_NPRECI1 = A_PUSMN1;//DOAUX[AL + "PE" + ND + "" + IT][10];//DESVALVE DOLARES
                //VDETA.C6_CNUMORD = Operacion.mask('codM').val().trim();

                $.ajax({
                    type: "POST",
                    url: "ValorizacionMM.aspx/valorizaDetalle",
                    data: '{ VDETA: ' + JSON.stringify(VDETA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        return true;
                    },
                    error: function (data) {
                        console.log(data);
                    }
                });
            }

            var obetenerhora = function () {
                chora = new Date();
                chora = chora.getHours();
                cminu = new Date().getMinutes();
                chora = new String(chora);
                cminu = new String(cminu);
                var hor = chora + ":" + cminu;
                return hor;
            }

            var correlativoOC = function (OP) {
                //OBTIENE NUMERACION
                var ee;
                //var CNUMDOC = {};
                //CNUMDOC.TN_CCODIGO = "OC";
                //CNUMDOC.TN_CNUMSER = "0001";
                $.ajax({
                    type: "POST",
                    url: "../ORDENCOMPRA/OCnueva.aspx/insertarnumeracion",
                    data: '{}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        try {
                            (OP == "2" ? "" : Operacion.mask('codM').val(data.d));//----AGREGADO
                            NOS = (OP == "2" ? data.d : "");
                        } catch (ex) {
                            alert(ex.message);
                        }
                    },
                    error: function (data) {
                        console.log(data);
                    }

                });
            }
            //ACTUALIZA NUMERACION OC:VERIFICAR
            var actualizaNUM = function () {
                var extraenum = Operacion.mask('codM').val().trim();
                var datos = {};
                datos.TN_CCODIGO = "OC";
                datos.TN_CNUMSER = "0001";
                datos.TN_NNUMERO = Number(extraenum.substring(5, 11));
                $.ajax({

                    type: "POST",
                    url: "../ORDENCOMPRA/OCnueva.aspx/Actualizanum",
                    data: '{datos: ' + JSON.stringify(datos) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {

                    },
                    error: function (response) {
                        if (response.length != 0)
                            console.log(response);
                    }
                });
            }
            //OBTIENE ALMACEN DIRECCION
            var obtieneALDIR = function (ID) {
                var dato;
                var CDIR = {};
                CDIR.A1_CALMA = Operacion.mask('codAL').val();

                $.ajax({
                    type: "POST",
                    url: "../ORDENCOMPRA/OCnueva.aspx/extraeDirAlma",
                    data: '{CDIR: ' + JSON.stringify(CDIR) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        //console.log(data);
                        if (data.d == null) {
                            dato = "";
                        } else {
                            OAUX[ID][19] = data.d.A1_CDIRECC;//DIRECCION ALMACEN
                            OAUX[ID][20] = data.d.A1_CDISTRI;//DISTRITO
                            OAUX[ID][21] = data.d.A1_CPROV;//PROVINCIA
                        }
                    },
                    error: function (data) {
                        if (data.length != 0)
                            alert(data);
                    }
                });
            }
            //obtieneALDIR('0015');
            var registraCOC = function (ID, OP) {
                var COS = Operacion.mask('codAL').val();
                var horao = obetenerhora();
                var MI_DER = Operacion.mask('lblDER').text().trim();
                //console.log(OAUX[ID][18].trim());
                var fec1 = moment(Operacion.mask('lblFEC').text(), "DD/MM/YYYY");
                fec1 = fec1 == null ? null : new Date(fec1);
                var fec02 = moment(Operacion.mask('lblFEC').text(), "DD/MM/YYYY");//fecha entrega
                fec02 = fec02 == null ? null : new Date(fec02);
                var dfactual = moment();
                dfactual = dfactual == null ? null : new Date(dfactual);

                var fpagg = "CONTADO";
                var TMN = Operacion.mask('ddlMN').val();
                var VDER = (OP == "1" ? Operacion.mask('hfVAL1').val() : Operacion.mask('hfVAL2').val());
                //VALIDACION PARA CONCHA

                if (OP == "1") {
                    //Operacion.mask('hfST').val()->07.09.16[CALCULO IGV O/C]
                    var MMN = (MI_DER != "" ? (TMN == "MN" ? VDER : VDER / Operacion.mask('txtTICA').val()) :
                   (TMN == "MN" ? Operacion.mask('hfVAL1').val() : Operacion.mask('hfVAL1').val() / Operacion.mask('txtTICA').val()));
                    var MUS = (TMN == "MN" ? MMN / Operacion.mask('txtTICA').val() : MMN * Operacion.mask('txtTICA').val());
                } else {
                    var MMN = (MI_DER != "" ? (TMN == "MN" ? (VDER * 1.18) : (VDER * 1.18) / Operacion.mask('txtTICA').val()) :
                    (TMN == "MN" ? (Operacion.mask('hfST').val() * 1.18) : (Operacion.mask('hfST').val() * 1.18) / Operacion.mask('txtTICA').val())
                    );
                    var MUS = (TMN == "MN" ? (MMN * 1.18) / Operacion.mask('txtTICA').val() : (MMN * 1.18) * Operacion.mask('txtTICA').val());
                }

                var CABC = {};
                CABC.OC_CNUMORD = (OP == "1" ? Operacion.mask('codM').val().trim() : NOS);//--AGREGADO
                CABC.OC_CCODPRO = OAUX[ID][8].trim();
                CABC.OC_CRAZSOC = OAUX[ID][9].trim();
                CABC.OC_CDIRPRO = "";//R
                CABC.OC_CCOTIZA = Operacion.mask('lblDOC').text().substring(3, 14);//R
                CABC.OC_CCODMON = OAUX[ID][2].trim();
                CABC.OC_CFORPA1 = fpagg;
                CABC.OC_CFORPA2 = "";
                CABC.OC_CFORPA3 = "";
                CABC.OC_NTIPCAM = Number(OAUX[ID][10]);//.trim();
                CABC.OC_DFECENT = fec02;
                CABC.OC_NPORDES = 0;
                CABC.OC_CCARDES = "";
                CABC.OC_NIMPUS = MUS;//importe dolares  R
                CABC.OC_NIMPMN = MMN;//importe soles  R
                CABC.OC_CSOLICT = MARRAY[2];//SOLICITANTE
                CABC.OC_CTIPENV = "";//R
                CABC.OC_CLUGENT = OAUX[ID][19];//"MZA. D LOTE. 01 ZONA INDUSTRIAL II PIURA - PAITA - PAITA";//R:ALMACEN
                CABC.OC_CLUGFAC = OAUX[ID][19];//"MZA. D LOTE. 01 ZONA INDUSTRIAL II PIURA - PAITA - PAITA";//R:ALMACEN
                CABC.OC_CDETENT = Operacion.mask('lbldALM').text().trim() + "-" + Operacion.mask('lblDOC').text().trim();//GLOSA
                CABC.OC_CSITORD = (M_DATA[6] == "2" && M_DATA[6] != null ? M_DATA[6] : "1");
                CABC.OC_DFECACT = dfactual;
                CABC.OC_CHORA = horao;
                CABC.OC_CUSUARI = Operacion.mask('hdUSUARIO').val();
                CABC.OC_DFECDOC = fec1;
                CABC.OC_CTIPORD = (OP == "1" ? "N" : "S");
                CABC.OC_CRESPER1 = "";
                CABC.OC_CRESPER2 = OAUX[ID][24];//BAHIA
                CABC.OC_CRESPER3 = "";
                CABC.OC_CRESCARG1 = "";
                CABC.OC_CRESCARG2 = "";
                CABC.OC_CRESCARG3 = "";
                CABC.OC_CCOPAIS = "PERU";
                CABC.OC_CUSEA01 = (M_DATA[0] != "" ? M_DATA[0] : M_DATA[7]);
                CABC.OC_CUSEA02 = (M_DATA[0] != "" ? M_DATA[1] : "");
                CABC.OC_CUSEA03 = (M_DATA[2] != "" ? M_DATA[2] : "");
                CABC.OC_DFECR01 = moment(M_DATA[3], 'DD/MM/YYYY');
                CABC.OC_DFECR02 = moment(M_DATA[4], 'DD/MM/YYYY');
                CABC.OC_DFECR03 = moment(M_DATA[5], 'DD/MM/YYYY');
                CABC.OC_CREMITE = "";//R
                CABC.OC_CPERATE = "";//R
                CABC.OC_CCONTA1 = "";
                CABC.OC_CCONTA2 = "";
                CABC.OC_CCONTA3 = "";
                CABC.OC_CNUMFAC = "";
                //CABC.OC_DFECEMB= ;
                CABC.OC_CUNIORD = "";
                CABC.OC_CCONVTA = "";
                CABC.OC_CCONEMB = "";
                CABC.OC_CCONDIC = MARRAY[1];//R: SUBTIPO
                CABC.OC_CTIPENT = "";
                CABC.OC_CDIAENT = "";
                CABC.OC_NFLEINT = 0;
                CABC.OC_NDOCCHA = 0;
                CABC.OC_NFLETE = 0;
                CABC.OC_NSEGURO = 0;
                CABC.OC_NIMPFAC = 0;
                CABC.OC_NIMPFOB = 0;
                CABC.OC_NIMPCF = 0;
                CABC.OC_NIMPCIF = 0;
                CABC.OC_CNUMREF = "";//R
                CABC.OC_CTIPDSP = "";//R
                CABC.OC_CTIPDOC = "PE";//R:DOCUMENTO REFERENCIA
                CABC.OC_CALMDES = Operacion.mask('ddlMalmacen').val().trim();
                CABC.OC_CDISTOC = OAUX[ID][20];//R:DISTRITO
                CABC.OC_CPROVOC = OAUX[ID][21];//R:PROVINCIA
                CABC.OC_CCOSTOC = (OAUX[ID][18].trim() != "" ? OAUX[ID][18].trim() : (COS == "A002" || COS == "A002" || COS == "A004" || COS == "0015" ? "100" : (COS == "0004" || COS == "0008" ? "101" : "")));
                CABC.OC_CDOCPAG = "";
                //CABC.OC_DFECPAG= ;
                //CABC.OC_DFECVEN= ;
                CABC.OC_CESTPAG = "";
                CABC.OC_CMONPAG = "";
                CABC.OC_NIMPPAG = 0;
                CABC.OC_CGLOPAG = "";
                CABC.OC_CCODSOL = MARRAY[0];//R;
                CABC.OC_CCODAGE = "";
                CABC.OC_CCODTAL = "";
                CABC.OC_CORDTRA = "";
                //console.log(CABC);
                //console.log(M_DATA);
                $.ajax({

                    type: "POST",
                    url: "../ORDENCOMPRA/OCnueva.aspx/InsertaCab",
                    data: '{CABC: ' + JSON.stringify(CABC) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        //(M_DATA[6] == "2" ? enviarCorreo(ID) : "");
                    },
                    error: function (response) {
                        //if (response.length != 0)
                        console.log(response);
                    }
                });

            }

            var recoreDetalle = function (ID, OP) {

                gitem = "";
                gidcod = "";
                gdescod = "";
                gobser = "";
                gunid = "";
                gcant = 0;
                gprecfinal = 0; gprecinicial = 0;
                gdesitem = 0; gdesitemx = 0;
                gdesadic = 0; gdesadicx = 0;
                gtotaldesc = 0; gtotaldescx = 0;
                gigv = 0; gigvx = 0; gvalidaigvx = 0;
                gisc = 0; giscx = 0;
                gcantent = 0; gcantsald = 0;
                gtus01 = 0; gtmn01 = 0; gsumasoles = 0; gsumadolares = 0;
                gestado = "1";
                gfechaent = "";
                subbt = ""; ccosto = ""; ccodsol = "";

                var gridView = document.getElementById("<%=gvDetalle.ClientID %>");
                var MILEN = gridView.rows.length;
                for (var t = 1; t < MILEN; t++) {

                    cellPivot = gridView.rows[t].cells[0]; gitem = cellPivot.innerHTML;//OK
                    cellPivot02 = gridView.rows[t].cells[1]; gidcod = cellPivot02.innerHTML;//OK
                    //cellPivot021 = gridView.rows[t].cells[1]; ccosto = cellPivot021.value;-->CAMPO CENTRO COSTO
                    cellPivot03 = gridView.rows[t].cells[2]; gdescod = cellPivot03.innerHTML;//OK
                    cellPivot04 = gridView.rows[t].cells[4]; gunid = cellPivot04.innerHTML;//OK
                    cellPivot05 = gridView.rows[t].cells[5]; gcant = cellPivot05.innerHTML;
                    //var inputs = gridView.rows[t].getElementsByTagName('input');
                    //gprecinicial = inputs[0].value;
                    cellPivot24 = gridView.rows[t].cells[8]; gtmn01 = cellPivot24.innerHTML;//7
                    //console.log(gtmn01);
                    //gsumadolares = Number(gsumadolares) + Number(gtus01); NO SE USAN
                    //gsumasoles = Number(gsumasoles) + Number(gtmn01);NO SE USAN

                    registraDETC(ID, gitem, t, (MILEN - 1), OP, "InsertaDet");
                    registraDETCC(ID, OP);

                }
            }
            var registraDETC = function (ID, IT, MIN, MAX, OP, METODO) {
                //REGISTRA DETALLE COPIA
                var horao = obetenerhora();

                var fec1 = moment(Operacion.mask('lblFEC').text(), "DD/MM/YYYY");
                fec1 = fec1 == null ? null : new Date(fec1);
                var fec2 = moment(Operacion.mask('lblFEC').text(), "DD/MM/YYYY");
                fec2 = fec2 == null ? null : new Date(fec2);

                var dfactual = moment();
                dfactual = dfactual == null ? null : new Date(dfactual);

                var M_PRECIO = (OP == "1" ? DOAUX[ID + "" + IT][1] : DOAUX[ID + "" + IT][9]);
                if (OP == "1") {
                    var M_PRECIO1 = (OP == "1" ? (Operacion.mask('cbIGV').attr('checked') == true ? (DOAUX[ID + "" + IT][1] * 1.18) : M_PRECIO) :
                                    (Operacion.mask('cbIGV').attr('checked') == true ? (DOAUX[ID + "" + IT][9] * 1.18) : M_PRECIO));
                    var V_IGV = (Operacion.mask('cbIGV').attr('checked') == true ? 0.18 : 0);
                } else {
                    var M_PRECIO1 = (DOAUX[ID + "" + IT][1] * 1.18);
                    var V_IGV = 0.18;
                }


                var M_IGV = Number(gcant * M_PRECIO * (V_IGV)).toFixed(2);
                var M_TOT = (Number(gtmn01) + Number(M_IGV));

                var DETA = {};

                DETA.OC_CNUMORD = (OP == "1" ? Operacion.mask('codM').val().trim() : NOS);//----AGREGADO
                DETA.OC_CCODPRO = OAUX[ID][8].trim();//$("#MainContent_txtidpro").val().trim();
                DETA.OC_CITEM = IT;//gitem;
                DETA.OC_CCODIGO = gidcod;
                DETA.OC_CCODREF = "";
                DETA.OC_CDESREF = gdescod;
                DETA.OC_CUNIPRO = "";
                DETA.OC_CDEUNPR = "";
                DETA.OC_CUNIDAD = gunid;
                DETA.OC_NCANORD = gcant;
                DETA.OC_NPREUNI = M_PRECIO1;//gprecfinal;CON IGV
                DETA.OC_NPREUN2 = M_PRECIO;//gprecinicial;SIN IGV
                DETA.OC_NDSCPFI = 0;
                DETA.OC_NDESCFI = 0;
                DETA.OC_NDSCPIT = 0;//gdesitemx;
                DETA.OC_NDESCIT = gdesitem;
                DETA.OC_NDSCPAD = 0;//gdesadicx;//
                DETA.OC_NDESCAD = 0;//gdesadic;
                DETA.OC_NDSCPOR = 0;//gtotaldescx;
                DETA.OC_NDESCTO = 0;//gtotaldesc;
                DETA.OC_NIGV = M_IGV;//gigv;
                DETA.OC_NIGVPOR = (V_IGV>0 ? 18.00 : 0);//gigvx;
                DETA.OC_NISC = 0;//gisc;
                DETA.OC_NISCPOR = 0;//giscx;
                DETA.OC_NCANTEN = 0;//gcantent;
                DETA.OC_NCANSAL = gcant;//gcantsald;
                DETA.OC_NTOTUS = (M_TOT / Operacion.mask('txtTICA').val());//gtus01;
                DETA.OC_NTOTMN = M_TOT;//(Number(gtmn01) + Number(M_IGV));
                DETA.OC_COMENTA = "";//gobser;R: OAUX[ID][13]
                DETA.OC_CESTADO = "1";//gestado;R:
                DETA.OC_FUNICOM = "";
                DETA.OC_NCANREF = 0;
                DETA.OC_CSERIE = "";
                DETA.OC_NANCHO = 0;
                DETA.OC_NCORTE = 0;
                DETA.OC_DFECDOC = fec1;
                DETA.OC_CTIPORD = "2";//$("#MainContent_ddltipo").val().trim();
                DETA.OC_CCENCOS = OAUX[ID][18];//ccosto;
                DETA.OC_CNUMREQ = "";
                DETA.OC_CSOLICI = MARRAY[0];//ccodsol;R
                DETA.OC_CITEREQ = "";
                DETA.OC_CREFCOD = "";
                DETA.OC_CPEDINT = "";
                DETA.OC_CITEINT = "";
                DETA.OC_CREFCOM = "";
                DETA.OC_CNOMFAB = "";
                DETA.OC_NCANEMB = 0;
                DETA.OC_DFECENT = fec2;
                DETA.OC_CITMPOR = "N";//(gdesitemx == 0 ? "N" : "S");//R
                DETA.OC_CDSCPOR = "N";// (gdesadicx == 0 ? "N" : "S");//R
                DETA.OC_CIGVPOR = "N";// (gvalidaigvx == 0 ? "N" : "S");//R
                DETA.OC_CISCPOR = "N";// (giscx == 0 ? "N" : "S");//R
                DETA.OC_NTOTMO = 0;
                DETA.OC_NUNXENV = 0;
                DETA.OC_NNUMENV = 0;
                DETA.OC_NCANFAC = 0;
                //console.log(DETA);
                $.ajax({

                    type: "POST",
                    url: "../ORDENCOMPRA/OCnueva.aspx/" + METODO,
                    data: '{DETA: ' + JSON.stringify(DETA) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        if (MAX == MIN) {
                            if (confirm('Se ha generado/actualizado la OC NRO:' + Operacion.mask('codM').val().trim() + ' para el \n\ ' + Operacion.mask('lblDOC').text().trim())) {
                                //cargar();
                            }
                        }
                    },
                    error: function (response) {
                        if (response.length != 0)
                            console.log(response);
                    }
                });

            }
            var registraDETCC = function (ID) {

                var horao = obetenerhora();
                var fec1 = moment(Operacion.mask('lblFEC').text(), "DD/MM/YYYY");
                fec1 = fec1 == null ? null : new Date(fec1);
                var fec2 = moment(Operacion.mask('lblFEC').text(), "DD/MM/YYYY");
                fec2 = fec2 == null ? null : new Date(fec2);
                var dfactual = moment();
                dfactual = dfactual == null ? null : new Date(dfactual);

                var DETA = {};
                DETA.PM_CCODMAT = gidcod;
                DETA.PM_CCODPRO = OAUX[ID][8];//$("#MainContent_txtidpro").val().trim();
                DETA.PM_DFECDOC = fec1;
                DETA.PM_CTIPMON = Operacion.mask('ddlMN').val().trim();//$("#MainContent_ddlmone").val().trim();
                DETA.PM_NVALOR = gprecinicial;//R:
                DETA.PM_CCOTIZA = ""; //ND//$("#MainContent_txtnumref").val().trim();R
                DETA.PM_CORDCOM = Operacion.mask('codM').val().trim();
                DETA.PM_DFECCRE = dfactual;
                //DETA.PM_DFECMOD=;
                DETA.PM_CHORA = horao;
                DETA.PM_CUSER = Operacion.mask('hdUSUARIO').val();//$("#MainContent_hfusu").val().trim();

                $.ajax({

                    type: "POST",
                    url: "../ORDENCOMPRA/OCnueva.aspx/InsertarOChistorial",
                    data: '{DETA: ' + JSON.stringify(DETA) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        //
                    },
                    error: function (response) {
                        if (response.length != 0)
                            console.log(response);
                    }
                });

            }
            var convierte = function (op) {
                var nv;
                switch (op) {
                    case 'C': break;
                    case 'F': break;
                    case 'M': nv = 'C'; break;
                    case 'V': nv = op; break;
                }
                return nv;
            }
            cargar();
            $("input[name$='MainContent$rbDDia']").click(function () {
                $("input[name$='MainContent$rbalcanceMA']").attr("checked", false);
                $("input[name$='MainContent$rbalcaneRF']").attr("checked", false);
                $("#MainContent_txtalcanceDia").show();
                $('#MainContent_txtalcandeMA').hide();
                $('#MainContent_lblFechaI').hide();
                $('#MainContent_lblFechaF').hide();
                $('#MainContent_txtalcandeMA').val("");
            });
            $("input[name$='MainContent$rbalcanceMA']").click(function () {
                $("input[name$='MainContent$rbDDia']").attr("checked", false);
                $('#MainContent_txtalcandeMA').show();
                $("#MainContent_txtalcanceDia").hide();
                $('#MainContent_lblFechaI').hide();
                $('#MainContent_lblFechaF').hide();
                Operacion.mask('txtalcanceDia').val("");
            });
            /*$('input:radio[name=rb]').click(function () {
                CODATA.XFECCAM2 = moment(Operacion.mask('txtFC').val(), 'DD-MM-YYYY');
                aux = $(this).val();
                Operacion.inputVisible(Operacion.mask('lblFC'), 1);
                Operacion.inputVisible(Operacion.mask('txtFC'), 1);
                Operacion.inputVisible($('#opcion'), 1);
                obtieneTC(CODATA, convierte($(this).val()));
            });*/
            $('.vb').click(function () {
                cargar();
            });
            Operacion.mask('ddlMalmacen').change(function () {
                AL = $(this).val();
                FEC1 = Operacion.mask('txtalcanceDia').val();
                cargar();
            });
            Operacion.mask('txtalcanceDia').change(function () {
                FEC1 = $(this).val();
                FEC2 = "";
                cargar();
            });
            Operacion.mask('txtalcandeMA').change(function () {
                FEC1 = "";
                FEC2 = $(this).val();
                cargar();
            });
            Operacion.mask('txtMNumeroDoc').change(function () {
                cargar();
            });
            Operacion.mask('ddlTICO').change(function () {
                if ($(this).val().trim() == "F") {
                    Operacion.inputVisible(Operacion.mask('lblFC'), 0);
                    Operacion.inputVisible(Operacion.mask('txtFC'), 0);
                    Operacion.inputEstado('txtFC', 0, true);
                    Operacion.inputVisible($('#opcion'), 0);//ACTUALIZAR
                } else if ($(this).val().trim() == "C") {
                    //ESPECIAL
                    Operacion.iValida('txtTICA', 1);
                    Operacion.inputRead('txtTICA', 0);
                } else if ($(this).val().trim() == "V") {
                    CODATA.XFECCAM2 = moment(Operacion.mask('lblFEC').text(), 'DD-MM-YYYY');
                    obtieneTC(CODATA, convierte($(this).val()));
                } else {
                    Operacion.inputVisible(Operacion.mask('lblFC'), 1);
                    Operacion.inputVisible(Operacion.mask('txtFC'), 1);
                    Operacion.inputEstado('txtFC', 1, true);
                    Operacion.inputVisible($('#opcion'), 1);//ACTUALIZAR
                    obtieneTC(CODATA, convierte($(this).val()));
                }
            });
            Operacion.mask('txtDORE').change(function () {
                $.ajax({
                    type: "POST",
                    url: "ModificacionCabecera.aspx/getLISTATD",
                    data: "{ dato: '" + $(this).val() + "', codigo:'04' }",
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        if (data.d.length > 0) {
                            jQuery.each(data.d, function (i, val) {
                                Operacion.mask('lblDORE').text(val['TG_CDESCRI']);
                            });
                        } else {
                            Operacion.mask('lblDORE').text("");
                        }
                    }, error: function (response) {
                        console.log(response);
                    }
                });
            });
            Operacion.mask('txtPRE1').live("change", function () {
                //INGRESA PRECIO - ACTUALIZO PRECIO DESVALVE
                if (valida() && Operacion.mask('ddlMN').val() != "-1" && $(this).val() > 0) {
                    $tr1 = $(this).closest('tr');
                    myRow1 = $tr1.index();

                    var mrow1 = $(this).parent().parent();
                    var M_MONEDA = Operacion.mask('ddlMN').val();
                    //console.log(mrow1);
                    IT = mrow1.find("td").eq(0).html();
                    var cantidad = mrow1.find("td").eq(5).html();
                    var oper = Operacion.mround(cantidad * $(this).val(), 2);
                    //Operacion.mask('hfVAL1').val(oper);//NUEVO: SUBTOTAL MP
                    var est = (Number($(this).val()) != 0 ? "V" : "");
                    //0:CANTIDAD,1:PRECIO,2:PRECIOUS,3:TOTAL,4:TOTALUS,5:ESTADO
                    //PRECIO:C6_NPREUN1
                    DOAUX[AL + "PE" + ND + "" + IT][1] = Number($(this).val());
                    //C6_NUSPRUN
                    DOAUX[AL + "PE" + ND + "" + IT][2] = (M_MONEDA == "US" ? $(this).val() : ($(this).val() / Operacion.mask('txtTICA').val()));
                    //VALOR TOTAL:C6_NVALTOT 
                    DOAUX[AL + "PE" + ND + "" + IT][3] = Number(oper);
                    //C6_NUSIMPO-VALOR TOTAL DOLARES
                    DOAUX[AL + "PE" + ND + "" + IT][4] = (M_MONEDA == "US" ? oper : (oper / Operacion.mask('txtTICA').val()));

                    DOAUX[AL + "PE" + ND + "" + IT][5] = Operacion.mask('ddlMN').val();
                    DOAUX[AL + "PE" + ND + "" + IT][6] = Operacion.mask('ddlTICO').val();
                    DOAUX[AL + "PE" + ND + "" + IT][7] = Operacion.mask('txtTICA').val();
                    DOAUX[AL + "PE" + ND + "" + IT][8] = (est);

                    $("#MainContent_gvDetalle tr:nth-child(" + (myRow1 + 1) + ") td:nth-child(9)").html(oper);//A:8
                    $("#MainContent_gvDetalle tr:nth-child(" + (myRow1 + 1) + ") td:nth-child(10)").html(est);//A:9
                    //$("#MainContent_gvDetalle tr:nth-child(" + (myRow1 + 1) + ") td:nth-child(13)").html(oper);
                    //$("#MainContent_gvDetalle tr:nth-child(" + (myRow1 + 1) + ") td:nth-child(14)").html(est);
                    valorizarD(AL, TD, ND, IT);
                    Operacion.mask('ddlMN').removeAttr('style');
                    iniciaST();

                } else {
                    alert('Verificar que todo los campos esten completos');
                }

            });
            Operacion.mask('txtPRE2').live("change", function () {
                //CONCHA
                $tr1 = $(this).closest('tr');
                myRow1 = $tr1.index();
                var mrow1 = $(this).parent().parent();
                IT = mrow1.find("td").eq(0).html();
                //console.log(AL + "PE" + ND + "" + IT);
                var M_MONEDA = Operacion.mask('ddlMN').val();
                DOAUX[AL + "PE" + ND + "" + IT][9] = (M_MONEDA == "US" ? $(this).val() * Operacion.mask('txtTICA').val() : $(this).val());//SOLES
                DOAUX[AL + "PE" + ND + "" + IT][10] = (M_MONEDA == "US" ? $(this).val() : $(this).val() / Operacion.mask('txtTICA').val()); //DOLARES
                //var oper = Operacion.mround(cantidad * $(this).val(), 2);
                //DOAUX[AL + "PE" + ND + "" + IT][3] = Number(oper);
                var cantidad = mrow1.find("td").eq(5).html();
                var A_CAL = Number(cantidad) * $(this).val();
                //Operacion.mask('hfVAL2').val(Operacion.mround(A_CAL, 2));//NUEVO: 09.07.16
                var PRETOT = (Number($(this).val()) + Number(DOAUX[AL + "PE" + ND + "" + IT][1]));
                var oper_x = Operacion.mround(cantidad * Number(PRETOT), 4);
                DOAUX[AL + "PE" + ND + "" + IT][3] = Number(oper_x);
                DOAUX[AL + "PE" + ND + "" + IT][4] = (M_MONEDA == "US" ? oper_x : (oper_x / Operacion.mask('txtTICA').val()));
                $("#MainContent_gvDetalle tr:nth-child(" + (myRow1 + 1) + ") td:nth-child(9)").html(oper_x.toFixed(2));//A:8
                //$("#MainContent_gvDetalle tr:nth-child(" + (myRow1 + 1) + ") td:nth-child(10)").html(est);//A:9
                iniciaST();
                valorizarD(AL, TD, ND, IT);
            });
            Operacion.mask('txtFC').change(function () {
                CODATA.XFECCAM2 = moment($(this).val(), 'DD-MM-YYYY');
                obtieneTC(CODATA, convierte($('input:radio[name=rb]').val()));
            });
            Operacion.mask('cbIGV').click(function () {
                iniciaST();
            });

            $(".tb4").autocomplete(
                {   /*getCliente:reemplazar CLIENTES - PROVEEDORES*/
                    source: function (request, response) {
                        var rq = '%' + request.term + '%'
                        $.ajax({
                            url: "RegistroEntrada.aspx/getCliente",
                            data: "{COD:'P',CAD: '" + rq + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            dataFilter: function (data) { return data; },
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        value: item.ACODANE,
                                        id: item.ADESANE
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
                        Operacion.mask('lblPRO').text(str);
                    }
                });
            $('.btPrinter').live("click", function () {
                var TD = $(this).parents("tr").find("td").eq(0).html();
                var AL = $('#MainContent_ddlMalmacen').val();
                var ND = $(this).parents("tr").find("td").eq(1).html();
                var PE = (TD == "PE" ? "E" : "S");
                window.open("../ALMACEN/Reportes/Reporte.aspx?AL=" + AL + "&TD=" + TD + "&ND=" + ND, '_blank');
                //window.open("../ALMACEN/Reportes/ReporteFinaliza.aspx?AL=" + AL + "&TD=" + TD + "&ND=" + ND, '_blank');
            });

            $('.btAnticipo').live("click", function () {
                var OC = $(this).attr("id");
                window.open("../ORDENCOMPRA/OCnueva.aspx?ID=" + OC + "&CT=1", '_blank');
            });
            //VERIFICA DETALLE
            $('.btDetalle').live("click", function () {
                var mrow1 = $(this).parent().parent();
                validafirma = $("td:eq(9)", mrow1).html();
                if (validafirma == "") {
                    alert('El P/E no ha sido aprobado');
                } else {
                    AL = Operacion.mask('ddlMalmacen').val();
                    //DETALLE
                    Operacion.oDialog('detalle', true);
                    TD = $("td:eq(0)", mrow1).html();//mrow1.find("td").eq(0).html();//$(this).parents("tr")
                    //M_DATA1[5] = $("td:eq(2)", mrow1).html();//NUMERO DE ORDEN COMPRA
                    ND = $(this).attr("id");//$("td:eq(1)", mrow1).html();//mrow1.find("td").eq(1).html();//GENERAL
                    M_DATA1[6] = ND;//ENVIO CORREO
                    var FD = $("td:eq(4)", mrow1).html();//mrow1.find("td").eq(4).html();//FECHA DOCUMENTO
                    var MV = $("td:eq(5)", mrow1).html();//mrow1.find("td").eq(5).html();
                    (MV == "MP" ? Operacion.inputEstado('cbIGV', 1, true) : Operacion.inputEstado('cbIGV', 0, true));
                    var ME = $("td:eq(6)", mrow1).html();//mrow1.find("td").eq(6).html();//ESTADO

                    Operacion.mask('codCC').val(MV);
                    CODATA.XFECCAM2 = moment(FD, 'DD/MM/YYYY');
                    var mitc = (OAUX[AL + "" + TD + "" + ND][10] != "" || OAUX[AL + "" + TD + "" + ND][10] > 0 ? OAUX[AL + "" + TD + "" + ND][10] : obtieneTC(CODATA, "V"));

                    //0:SOLICITANTE 1:CENTRO COSTO 2:TIPO MOVIMIENTO 3:DOCUMENTO REFERENCIA
                    Operacion.mask('lblDOC').text(TD + " " + ND);
                    Operacion.mask('lbldALM').text(Operacion.mask('ddlMalmacen option:selected').text());
                    Operacion.mask('lblFEC').text(FD);
                    Operacion.mask('lblSOL').text(OAUX[AL + "" + TD + "" + ND][0]);
                    Operacion.mask('lblCC').text(OAUX[AL + "" + TD + "" + ND][1]);
                    Operacion.mask('ddlMN').val(OAUX[AL + "" + TD + "" + ND][2]!=undefined?"MN":OAUX[AL + "" + TD + "" + ND][2]);
                    Operacion.mask('lblCM').text(OAUX[AL + "" + TD + "" + ND][3]);
                    Operacion.mask('txtDORE').val(OAUX[AL + "" + TD + "" + ND][4]);
                    Operacion.mask('lblDORE').text(OAUX[AL + "" + TD + "" + ND][5]);
                    Operacion.mask('txtNDOC').val(OAUX[AL + "" + TD + "" + ND][6]);
                    Operacion.mask('lblGLO').text(OAUX[AL + "" + TD + "" + ND][7]);
                    Operacion.mask('txtPRO').val(OAUX[AL + "" + TD + "" + ND][8]);
                    M_DATA1[0] = OAUX[AL + "" + TD + "" + ND][8];//EN CASO DE MODIFICACIÓN
                    Operacion.mask('lblPRO').text(OAUX[AL + "" + TD + "" + ND][9]);
                    M_DATA1[1] = OAUX[AL + "" + TD + "" + ND][9];//EN CASO DE MODIFICACIÓN
                    Operacion.mask('txtSUB').val(OAUX[AL + "" + TD + "" + ND][14]);//SUBDIARIO
                    Operacion.mask('txtCOM').val(OAUX[AL + "" + TD + "" + ND][15]);//NUMERO COMPROBANTE
                    Operacion.mask('lblOBS').text(OAUX[AL + "" + TD + "" + ND][22]);
                    Operacion.mask('lblDORE0').text(OAUX[AL + "" + TD + "" + ND][24]);
                    (OAUX[AL + "" + TD + "" + ND][11] != "" ? Operacion.inputEstado('txtOC', 1, true) : Operacion.inputEstado('txtOC', 0, true));
                    Operacion.mask('txtOC').val(OAUX[AL + "" + TD + "" + ND][11]);//ORDEN DE COMPRA
                    var ACTIVO = OAUX[AL + "" + TD + "" + ND][25];
                    //console.log(ACTIVO);
                    Operacion.mask('cbIGV').attr('checked', (ACTIVO == 1 ? true : false));//C5_CSBNOM

                    (mitc != undefined ? Operacion.mask('txtTICA').val(mitc) : "");
                    Operacion.mask('lblDER').text((OAUX[AL + "" + TD + "" + ND][12] == "" ? "" : OAUX[AL + "" + TD + "" + ND][12]));//OAUX[AL + "" + TD + "" + ND][11]
                    Operacion.mask('ddlTICO').val('V');
                    Operacion.mask('lblORI').text(OAUX[AL + "" + TD + "" + ND][13]);
                    (OAUX[AL + "" + TD + "" + ND][11] != "" || OAUX[AL + "" + TD + "" + ND][12] != "" ? DER(true) : DER(false));

                    //(ME == "V" ? bloqueo(1) : bloqueo(2));
                    var OCE = obtenerEOC(OAUX[AL + "" + TD + "" + ND][11]).estado;
                    M_DATA1[5] = OAUX[AL + "" + TD + "" + ND][11];
                    var MDER = Operacion.mask('lblDER').text();//OAUX[AL + "" + TD + "" + ND][12];
                    //console.log(MDER);
                    var TID = Operacion.mask('txtDORE').val();
                    (TID == "FT" || TID == "LQ" || OCE == "2" ? bloqueo(1) : bloqueo(2));//MV : SI ES LIQUIDACION

                    $.ajax({
                        type: "POST",
                        url: "ConsultaReimpresion.aspx/detalleCabecera",
                        data: "{ AL: '" + Operacion.mask('ddlMalmacen').val() + "',TD:'" + TD + "',ND:'" + ND + "' }",
                        contentType: "application/json;charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (data) {
                            //console.log(data);
                            Operacion.mask('gvDetalle').attr('style', 'background-color:White;border-color:#CCCCCC;border-width:1px;border-style:None;border-collapse:collapse;');
                            if (data.d.length > 0) {
                                Operacion.mask('gvDetalle').empty();
                                Operacion.mask('gvDetalle').append("<tr style='color:White;background-color:#006699;font-weight:bold;'><th align='center' scope='col' style='font-size:8pt;width:30px;'>ITEM</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>CODIGO</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>DESCRIPCION</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>SERIE</th><th align='center' scope='col' style='font-size:8pt;width:50px;'>UNID</th><th align='center' scope='col' style='font-size:8pt;width:80px;'>CANTIDAD</th><th align='center' scope='col' style='font-size:8pt;'>PRECIO UNIT.</th><th align='center' scope='col' style='font-size:8pt;'>PRECIO DESVA.</th><th align='center' scope='col' style='font-size:8pt;width:80px;'>VALOR TOTAL</th><th align='center' scope='col' style='font-size:8pt;width:60px;'>ESTADO</th></tr>");
                                //Operacion.mask('gvDetalle').append("<tr style='color:White;background-color:#006699;font-weight:bold;'><th align='center' scope='col' style='font-size:8pt;width:30px;'>ITEM</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>CODIGO</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>DESCRIPCION</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>SERIE</th><th align='center' scope='col' style='font-size:8pt;width:50px;'>UNID</th><th align='center' scope='col' style='font-size:8pt;width:80px;'>CANTIDAD</th><th align='center' scope='col' style='font-size:8pt;width:70px;'>C/IGV</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>TASA IGV.</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>PRECIO UNIT.</th><th align='center' scope='col' style='font-size:8pt;width:80px;'>%DSCTO1</th><th align='center' scope='col' style='font-size:8pt;width:80px;'>%DSCTO2</th><th align='center' scope='col' style='font-size:8pt;width:80px;'>%DSCTO3</th><th align='center' scope='col' style='font-size:8pt;width:80px;'>%VALOR TOTAL</th><th align='center' scope='col' style='font-size:8pt;width:60px;'>ESTADO</th></tr>");
                                for (var i = 0; i < data.d.length; i++) {
                                    var COAUX = AL + "" + TD + "" + ND;
                                    DOAUX[AL + "PE" + ND + "" + data.d[i].C6_CITEM] = [
                                        data.d[i].C6_NCANTID,//0
                                        data.d[i].C6_NPREUNI,//1
                                        0,//2
                                        data.d[i].C6_NVALTOT,//3
                                        0,//4
                                        data.d[i].C6_CCODMON,//5
                                        data.d[i].C6_CTIPO,//6
                                        data.d[i].C6_NTIPCAM,//7
                                        data.d[i].C6_CESTADO,//8,
                                        data.d[i].C6_NPRECIO,//9:nuevo
                                        data.d[i].C6_NPRECI1//10:nuevo
                                    ];
                                    unidad(data.d[i].C6_CCODIGO, COAUX);
                                    var MN = data.d[i].C6_CCODMON;
                                    Operacion.mask('gvDetalle').append("<tr><td style='font-size:8pt;'>" +
                                    data.d[i].C6_CITEM + "</td><td style='font-size:8pt;text-align:center;'>" +
                                    data.d[i].C6_CCODIGO + "</td><td style='font-size:8pt;'>" +
                                    data.d[i].C6_CDESCRI + "</td><td style='font-size:8pt;'>" +
                                    data.d[i].C6_CSERIE + "</td><td style='font-size:8pt;text-align:center;'>" +
                                    OAUX[COAUX][16] + "</td><td style='font-size:8pt;text-align:right;'>" +
                                    data.d[i].C6_NCANTID.toFixed(2) + "</td><td style='font-size:8pt;text-align:right;'>" +
                                    //data.d[i].C6_NDESCTO + "</td><td style='font-size:8pt;text-align:right;'>" +
                                    //data.d[i].C6_NDESCTO + "</td><td style='font-size:8pt;text-align:right;'>" +
                                    //"<input type='text' id='MainContent_txtPRE1' onkeypress=$(this).numeric('.') placeholder='0.00' value='" + data.d[i].C6_NPREUNI + "' " + (data.d[i].C6_CESTADO.trim() == "V" ? 'ReadOnly=true' : '') + "/></td><td style='font-size:8pt;text-align:right;'>" +
                                    "<input type='text' id='MainContent_txtPRE1' onkeypress=$(this).numeric('.') placeholder='0.00' value='" + data.d[i].C6_NPREUNI + "' " + ((TID == "FT" || TID == "LQ") || OCE == "2" ? 'ReadOnly=true' : '') + " style=text-align:right /></td><td style='font-size:8pt;text-align:right;'>" +
                                    "<input type='text' id='MainContent_txtPRE2' onkeypress=$(this).numeric('.') placeholder='0.00' value='" + (MN == "MN" ? data.d[i].C6_NPRECIO : data.d[i].C6_NPRECI1) + "' " + ((TID == "FT" || TID == "LQ") || OCE == "2" || MDER == "" ? 'ReadOnly=true' : '') + " style=text-align:right /></td><td style='font-size:8pt;text-align:right;'>" +//DESVALE:data.d[i].C6_NPREUNI + "</td><td style='font-size:8pt;text-align:right;'>" +
                                    //data.d[i].C6_NDESCTO + "</td><td style='font-size:8pt;text-align:right;'>" +
                                    //data.d[i].C6_NDESCTO + "</td><td style='font-size:8pt;text-align:right;'>" +
                                    //data.d[i].C6_NDESCTO + "</td><td style='font-size:8pt;text-align:right;'>" +
                                    data.d[i].C6_NVALTOT.toFixed(2) + "</td><td style='font-size:8pt;text-align:center;'>" +
                                    (data.d[i].C6_CESTADO.trim() == "" ? "<span style='color:red;'>S/V</span>" : "<img src=../Images/Message_Success.png width=35% />" + data.d[i].C6_CESTADO) + "</td></tr>");

                                }
                            } else {
                                Operacion.mask('gvDetalle').empty();
                                Operacion.mask('gvDetalle').append("<tr style='color:White;background-color:#006699;font-weight:bold;'><th align='center' scope='col' style='font-size:8pt;width:30px;'>ITEM</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>CODIGO</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>DESCRIPCION</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>SERIE</th><th align='center' scope='col' style='font-size:8pt;width:50px;'>UNID</th><th align='center' scope='col' style='font-size:8pt;width:80px;'>CANTIDAD</th><th align='center' scope='col' style='font-size:8pt;'>PRECIO UNIT.</th><th align='center' scope='col' style='font-size:8pt;width:80px;'>%VALOR TOTAL</th><th align='center' scope='col' style='font-size:8pt;width:60px;'>ESTADO</th></tr>");
                                //Operacion.mask('gvDetalle').append("<tr style='color:White;background-color:#006699;font-weight:bold;'><th align='center' scope='col' style='font-size:8pt;width:100px;'>ITEM</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>CODIGO</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>DESCRIPCION</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>SERIE</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>UNID</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>CANTIDAD</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>C/IGV</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>TASA IGV.</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>PRECIO UNIT.</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>%DSCTO1</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>%DSCTO2</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>%DSCTO3</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>VALOR TOTAL</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>ESTADO</th></tr>");
                                Operacion.mask('gvDetalle').append("<tr><td style='font-size:8pt;'>-</td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td></tr>");

                            }

                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert(textStatus);
                        }
                    });
                    iniciaST();
                }
            });
            //VERIFICA DETALLE 2
            $('.btAprobar').live("click", function () {
                var ID_PE = $(this).attr("id");
                ND = $(this).attr("id");
                Operacion.oDialog('aprobar', true);
                //$.extend({},Operacion.oDialog('aprobar', true), dialogOpts);
                var mrow1 = $(this).parent().parent();
                var DATA = {
                    C6_CALMA: Operacion.mask('ddlMalmacen').val(),
                    C6_CTD: "PE",
                    C6_CNUMDOC: ID_PE
                }
                var CODBUS = DATA.C6_CALMA + "" + DATA.C6_CTD + "" + DATA.C6_CNUMDOC
                Operacion.mask('lblPROA').text(OAUX[CODBUS][9]);
                Operacion.mask('lblRUCA').text(OAUX[CODBUS][8]);
                Operacion.mask('lblBAHA').text(OAUX[CODBUS][24]);
                Operacion.mask('lblFDA').text($("td:eq(4)", mrow1).html());
                Operacion.mask('lblEMBA').text($("td:eq(7)", mrow1).html());
                var result = Operacion.oAjax("ValorizacionMM.aspx/detalle", DATA, "DATA");
                var LEN1 = result.d.length;
                Operacion.mask('gvDetalleA').attr('style', 'background-color:White;border-color:#CCCCCC;border-width:1px;border-style:None;border-collapse:collapse;');
                if (LEN1 > 0) {
                    Operacion.mask('gvDetalleA').empty();
                    Operacion.mask('gvDetalleA').append("<tr style='color:White;background-color:#006699;font-weight:bold;'><th align='center' scope='col' style='font-size:8pt;width:30px;'>ITEM</th><th align='left' scope='col' style='font-size:8pt;width:100px;'>DESCRIPCION</th><th align='center' scope='col' style='font-size:8pt;width:50px;'>UNID</th><th align='rigth' scope='col' style='font-size:8pt;width:80px;'>CANTIDAD</th></tr>");
                    var sum = 0;
                    for (var i = 0; i < LEN1; i++) {
                        unidad(result.d[i].C6_CCODIGO, CODBUS);
                        var MN = result.d[i].C6_CCODMON;
                        Operacion.mask('gvDetalleA').append("<tr><td style='font-size:8pt;text-align:center'>" +
                        result.d[i].C6_CITEM + "</td><td style='font-size:8pt;text-align:left;'>" +
                        result.d[i].C6_CDESCRI + "</td><td style='font-size:8pt;text-align:center'>" +
                        OAUX[CODBUS][16] + "</td><td style='font-size:8pt;text-align:right;'>" +
                        result.d[i].C6_NCANTID.toFixed(2) + "</td>");
                        //result.d[i].C6_NVALTOT.toFixed(2) + "</td><td style='font-size:8pt;text-align:center;'>");
                        sum = sum + result.d[i].C6_NCANTID;
                    }
                    Operacion.mask('gvDetalleA').append("<tr><td></td><td></td><td style=font-size:8pt;text-align:right>Total:</td><td style=font-size:8pt;text-align:right>" + Number(sum).toFixed(2) + "</td></tr>");
                } else {
                    Operacion.mask('gvDetalleA').empty();
                    //Operacion.mask('gvDetalleA').append("<tr style='color:White;background-color:#006699;font-weight:bold;'><th align='center' scope='col' style='font-size:8pt;width:30px;'>ITEM</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>CODIGO</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>DESCRIPCION</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>SERIE</th><th align='center' scope='col' style='font-size:8pt;width:50px;'>UNID</th><th align='center' scope='col' style='font-size:8pt;width:80px;'>CANTIDAD</th><th align='center' scope='col' style='font-size:8pt;'>PRECIO UNIT.</th><th align='center' scope='col' style='font-size:8pt;width:80px;'>%VALOR TOTAL</th><th align='center' scope='col' style='font-size:8pt;width:60px;'>ESTADO</th></tr>");
                    //Operacion.mask('gvDetalleA').append("<tr><td style='font-size:8pt;'>-</td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td></tr>");
                }
            });
            //VALORIZAR PARTE ENTRADAS
            Operacion.mask('btnVB').click(function () {
                if (confirm('¿Usted da conformidad de los datos?')) {
                    var ID_PE = ND;//$(this).attr("id");
                    var DATA = {
                        C5_CALMA: Operacion.mask('ddlMalmacen').val(),
                        C5_CTD: "PE",
                        C5_CNUMDOC: ID_PE,
                        C5_CCODAUT: Operacion.mask('hdUSUARIO').val()
                    }
                    try {
                        var result = Operacion.oAjax("ValorizacionMM.aspx/aprobar", DATA, "DATA");
                        if (result) {
                            if (confirm('Se ha aprobado el PE ' + DATA.C5_CNUMDOC)) {
                                $('#aprobar').dialog('close');
                                cargar();
                            }
                        }
                    } catch (ex) {
                        alert(ex.message);
                    }
                }
            });

            $('#btnGuardar').click(function () {
                if (confirm('Confirma que ha verificado lo siguientes campos:\n Tipo Cambio \nMoneda \nProveedor \n Precio \nMontos \n antes de finalizar la valorización')) {
                    if (valida() && Operacion.mask('ddlMN').val() != "-1") {
                        $('#detalle').dialog('close');
                        var ID = AL + "PE" + ND;
                        //console.log(ND);
                        OAUX[ID][4] = Operacion.mask('txtDORE').val();
                        OAUX[ID][6] = Operacion.mask('txtNDOC').val(); //VDATA.C5_CRFTDOC = OAUX[AL + "PE" + ND][4];
                        OAUX[ID][8] = Operacion.mask('txtPRO').val();
                        OAUX[ID][9] = Operacion.mask('lblPRO').text();
                        //OAUX[AL+"PE"+ND][]=Operacion.mask('ddlTICO').val();
                        OAUX[ID][10] = Operacion.mask('txtTICA').val();//TIPO CAMBIO
                        OAUX[ID][2] = Operacion.mask('ddlMN').val();
                        OAUX[ID][14] = Operacion.mask('txtSUB').val();
                        OAUX[ID][15] = Operacion.mask('txtCOM').val();
                        OAUX[ID][17] = Operacion.mask('ddlTICO').val();
                        //ADICIONAL
                        //DOAUX[ID][5] = Operacion.mask('ddlMN').val();
                        if ((Operacion.mask('codCC').val() == "CO" || Operacion.mask('codCC').val() == "MP")) {
                            //VERIFICA SI EXISTE ->SINO GENERA
                            (OAUX[ID][11] != "" ? Operacion.mask('codM').val(OAUX[ID][11]) : "");
                            //console.log("VALOR GUARDAR "+OAUX[ID][11]);
                            if (obtenerEOC(Operacion.mask('codM').val()).estado == "1" || obtenerEOC(Operacion.mask('codM').val()).estado == "2" || obtenerEOC(Operacion.mask('codM').val()).estado == "0") {
                                //VERIFICA TODO ESTE CORRECTO
                                var result = todoOK().CONT;
                                if (result > 0) {
                                    alert('Debe verificar que todos los items han sido valorizados.\n Nro. Items sin valorizar: ' + result + ' \n La OC no se pudo generar');
                                } else {
                                    //06.07.16:VALIDACIÓN PARA ATUN
                                    if (AL == "0004") {
                                        if (confirm('Desea generar una O/C para el documento')) {
                                            (OAUX[ID][11] != "" ? "" : correlativoOC("1"));//ACTUALIZA VARIABLE : codM
                                            valorizar();//CONSIDERA VARIABLE: codM
                                            (OAUX[ID][11] != "" ? "" : actualizaNUM());//ACTUALIZA CORRELATIVO ORDENES DE COMPRA
                                            generaOC(ID);
                                        } else {
                                            OAUX[ID][11] = "";
                                            Operacion.mask('codM').val("");
                                            valorizar();
                                            cargar();
                                        }
                                    } else {
                                        //GLOSA4:|NUMERO ORDEN|NOS(2)
                                        (OAUX[ID][11] != "" ? "" : correlativoOC("1"));//ACTUALIZA VARIABLE : codM
                                        //valorizar();//CONSIDERA VARIABLE: codM
                                        (OAUX[ID][11] != "" ? "" : actualizaNUM());//ACTUALIZA CORRELATIVO ORDENES DE COMPRA
                                        generaOC(ID);
                                        var MI_DER = Operacion.mask('lblDER').text();
                                        var MI_TDES = Operacion.mask('hfVAL2').val();
                                        (MI_DER != "" && MI_TDES > 0 ? generaOS(ID) : "");
                                        valorizar();
                                    }
                                }
                            } else {
                                //VALIDA QUE SE ENCUENTRE APROBADA
                                alert('La OC:' + Operacion.mask('codM').val() + 'ya se encuentra aprobada no se modificaran el documento');
                            }
                        } else {
                            cargar();
                        }
                        //console.log(OAUX);
                        //console.log(DOAUX);//ID:AL-PE-ND-ITEM
                        //OAUX = [];
                        //DOAUX = [];
                        Operacion.mask('ddlMN').removeAttr('style');
                        //console.log(ND);
                    } else {
                        alert('Completar campos requeridos');
                    }
                } else {

                }
                Operacion.mask('ddlMN').removeAttr('style');
            });
        });
    </script>
    <style type="text/css">
        #contenedor {
            width: 1040px;
        }

        fieldset {
            width: 1000px;
        }

        table {
            width: 100%;
        }

        .mi_label {
            padding-left: 3px;
            padding-right: 3px;
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
            <legend>Valorización Manual de Movimientos</legend>
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
                        <asp:RadioButton ID="rbalcanceMA" name="radio1" Text="Mes/año:" runat="server" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtalcandeMA" class="dpFecha2" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">Nro Documento</td>
                    <td>
                        <asp:TextBox ID="txtMNumeroDoc" class="ac" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        <asp:Label ID="lblRevision" class="vb" runat="server" Text="Revisión"></asp:Label>
                    </td>
                    <td>
                            <input id="rb3" type="radio" class="vb" name="rb" value="PA" checked="checked" />Por aprobar
                            <input id="rb4" type="radio" class="vb" name="rb" value="A" />Aprobados</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
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
                        <asp:GridView ID="gvVMM" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="C5_CTD" HeaderText="TD" ItemStyle-HorizontalAlign="Right">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="C5_CNUMDOC" HeaderText="Nro Documento" ItemStyle-HorizontalAlign="Right">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="C5_CNUMORD" HeaderText="O/C" ItemStyle-HorizontalAlign="Right">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="C5_CCODMON" HeaderText="Moneda" ItemStyle-HorizontalAlign="Right">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="C5_DFECDOC" HeaderText="Fecha Documento" ItemStyle-HorizontalAlign="Right">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="C5_CCODMOV" HeaderText="Mov" ItemStyle-HorizontalAlign="Right">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="C5_CSITUA" HeaderText="Situacion" ItemStyle-HorizontalAlign="Right">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="C5_CGLOSA1" HeaderText="Glosa" ItemStyle-HorizontalAlign="Right">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="C5_CUSUCRE" HeaderText="AP1" ItemStyle-HorizontalAlign="center">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="C5_CCODAUT" HeaderText="AP2" ItemStyle-HorizontalAlign="center">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <div class="btEditar" style="text-align: center">
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
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
            </table>
        </fieldset>
    </div>
    <div id="detalle" title="Valorización de Movimientos" style="display: none;">
        <table style="width: 100%;">
            <tr>
                <td>
                    <strong>Documento</strong></td>
                <td>
                    <asp:Label ID="lblDOC" runat="server" Text=""></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td><strong>Fecha Documento</strong></td>
                <td>
                    <asp:Label ID="lblFEC" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td><strong>Almacen</strong></td>
                <td>
                    <asp:Label ID="lbldALM" runat="server" Text=""></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td><strong>Codigo Movimiento</strong></td>
                <td colspan="2">
                    <asp:Label ID="lblCM" runat="server" Text=""></asp:Label>
                </td>
                <td><strong>Centro de Costo</strong></td>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="lblCC" runat="server" Text=""></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td><strong>Solicitante</strong></td>
                <td colspan="2">
                    <asp:Label ID="lblSOL" runat="server" Text=""></asp:Label>
                </td>
                <td><strong>Glosa</strong></td>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="lblGLO" runat="server" Text=""></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td><strong>Almacen Referencia</strong></td>
                <td colspan="2">
                    <asp:Label ID="lblAR" runat="server" Text=""></asp:Label>
                </td>
                <td><strong>Origen</strong></td>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="lblORI" runat="server" Text=""></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td><strong>Orden Compra</strong></td>
                <td colspan="2">
                    <asp:TextBox ID="txtOC" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblLDER" runat="server" Style="font-weight: bold;" Text="DER"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="lblDER" runat="server" Text=""></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="7">&nbsp;</td>
            </tr>
            <tr>
                <td><strong>Proveedor&nbsp;</strong></td>
                <td colspan="2">
                    <asp:TextBox ID="txtPRO" runat="server" class="tb4" Width="139px"></asp:TextBox>
                    <asp:Label ID="lblPRO" runat="server" Text=""></asp:Label>
                </td>
                <td><strong>Observacion</strong></td>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="lblOBS" runat="server" Text=""></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td><strong>Documento Referencia</strong></td>
                <td colspan="2">
                    <asp:TextBox ID="txtDORE" runat="server" Width="37px"></asp:TextBox>
                    <asp:Label ID="lblDORE" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <strong>
                        <asp:Label ID="lblDR2" runat="server" Text="Bahia"></asp:Label></strong>
                </td>
                <td>&nbsp;</td>
                <td colspan="2">
                    <!--<asp:TextBox ID="txtDORE0" runat="server" Width="37px"></asp:TextBox>-->
                    <asp:Label ID="lblDORE0" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td><strong>Numero de Documento</strong></td>
                <td>
                    <asp:TextBox ID="txtNDOC" runat="server"></asp:TextBox>
                </td>
                <td><strong>Moneda&nbsp;</strong></td>
                <td>
                    <asp:DropDownList ID="ddlMN" runat="server">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
                <td>
                    <!--<asp:Label ID="lblND0" runat="server" Text="Numero de Documento"></asp:Label>-->
                </td>
                <td>
                    <!--<asp:TextBox ID="txtNDOC0" runat="server"></asp:TextBox>-->
                </td>
            </tr>
            <tr>
                <td><strong>Subdiario</strong></td>
                <td>
                    <asp:TextBox ID="txtSUB" runat="server" Width="44px"></asp:TextBox>
                </td>
                <td><strong>Tipo de Conversión</strong></td>
                <td>
                    <asp:DropDownList ID="ddlTICO" runat="server">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="lblFC" runat="server" Text="Fecha Cambio"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFC" class="dp1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td><strong>Comprobante</strong></td>
                <td><strong>
                    <asp:TextBox ID="txtCOM" runat="server"></asp:TextBox>
                </strong></td>
                <td><strong>Tipo de Cambio&nbsp;</strong></td>
                <td>
                    <asp:TextBox ID="txtTICA" runat="server" Width="57px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td rowspan="2">
                    <div id="opcion">
                        <input id="rb1" name="rb" type="radio" value="M" />Compra<br />
                        <input id="rb2" name="rb" type="radio" value="V" />Venta
                    </div>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td><strong>Incluye IGV&nbsp;</strong></td>
                <td>
                    <asp:CheckBox ID="cbIGV" runat="server" />
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <!--<input id="btnValorizar" type="button" value="Valorizar" /></td>-->
                    <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="7">
                    <asp:GridView ID="gvDetalle" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="C6_CITEM" HeaderText="IT" ItemStyle-HorizontalAlign="Right">
                                <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="50" />
                                <ItemStyle Font-Size="8pt" />
                            </asp:BoundField>
                            <asp:BoundField DataField="C6_CCODIGO" HeaderText="CODIGO" ItemStyle-HorizontalAlign="Right">
                                <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                <ItemStyle Font-Size="8pt" />
                            </asp:BoundField>
                            <asp:BoundField DataField="C6_CDESCRI" HeaderText="DESCRIPCION" ItemStyle-HorizontalAlign="Right">
                                <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                <ItemStyle Font-Size="8pt" />
                            </asp:BoundField>
                            <asp:BoundField DataField="C6_CSERIE" HeaderText="SERIE" ItemStyle-HorizontalAlign="Right">
                                <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                <ItemStyle Font-Size="8pt" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AR_CUNIDAD" HeaderText="UNIDAD" ItemStyle-HorizontalAlign="Right">
                                <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                <ItemStyle Font-Size="8pt" />
                            </asp:BoundField>
                            <asp:BoundField DataField="C6_NCANTID" HeaderText="CANTIDAD" ItemStyle-HorizontalAlign="Right">
                                <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                <ItemStyle Font-Size="8pt" />
                            </asp:BoundField>

                            <asp:BoundField DataField="C6_NPREUN1" HeaderText="PRECIO UNIT." ItemStyle-HorizontalAlign="Right">
                                <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                <ItemStyle Font-Size="8pt" />
                            </asp:BoundField>
                            <%--<asp:BoundField DataField="C6_NDESCTO1" HeaderText="%DSCTO1" ItemStyle-HorizontalAlign="Right">
                                <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                <ItemStyle Font-Size="8pt" />
                            </asp:BoundField>
                            <asp:BoundField DataField="C6_NDESCTO2" HeaderText="%DSCTO2" ItemStyle-HorizontalAlign="Right">
                                <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                <ItemStyle Font-Size="8pt" />
                            </asp:BoundField>
                            <asp:BoundField DataField="C6_NDESCTO3" HeaderText="%DSCTO3" ItemStyle-HorizontalAlign="Right">
                                <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                <ItemStyle Font-Size="8pt" />
                            </asp:BoundField>--%>
                            <asp:BoundField DataField="C6_NVALTOT" HeaderText="C6_NVALTOT" ItemStyle-HorizontalAlign="Right">
                                <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                <ItemStyle Font-Size="8pt" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <div class="btEditar" style="text-align: center">
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
                <td>
                    <strong>SUBTOTAL:</strong><asp:TextBox ID="hfST" runat="server" ReadOnly="true" Style="text-align: right" />
                </td>
                <td>
                    <strong>IGV</strong><asp:TextBox ID="hfIGV" runat="server" ReadOnly="true" Style="text-align: right" />
                </td>
                <td>
                    <strong>TOTAL</strong><asp:TextBox ID="hfTOT" runat="server" ReadOnly="true" Style="text-align: right" />
                </td>
                <td>
                    <asp:HiddenField ID="hfVAL1" runat="server" />
                </td>
                <td>
                    <asp:HiddenField ID="hfVAL2" runat="server" />
                </td>
                <td>&nbsp;</td>
                <td>
                    <input id="btnGuardar" type="button" value="Valorizar" class="btn" /></td>
            </tr>
        </table>
    </div>
    <div id="aprobar" title="Aprobar Parte de Entrada" style="display: none;">
        <table>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>Fecha Documento</td>
                <td>
                    <asp:Label ID="lblFDA" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Proveedor</td>
                <td>
                    <asp:Label ID="lblPROA" runat="server" BorderStyle="Solid" BorderWidth="1px" class="mi_label"></asp:Label>
                </td>
                <td>Embarcacion</td>
                <td>
                    <asp:Label ID="lblEMBA" runat="server" BorderStyle="Solid" BorderWidth="1px" class="mi_label"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Ruc</td>
                <td>
                    <asp:Label ID="lblRUCA" runat="server" BorderStyle="Solid" BorderWidth="1px" class="mi_label"></asp:Label>
                </td>
                <td>Bahia</td>
                <td>
                    <asp:Label ID="lblBAHA" runat="server" BorderStyle="Solid" BorderWidth="1px" class="mi_label"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:GridView ID="gvDetalleA" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                        <Columns>
                            <asp:BoundField DataField="C6_CITEM" HeaderText="ITEM" />
                            <asp:BoundField DataField="C6_CDESCRI" HeaderText="DESCRIPCION">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AR_CUNIDAD" HeaderText="UNID.">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="C6_NCANTID" HeaderText="CANTIDAD" />
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
                    <asp:Button ID="btnVB" runat="server" class="btn" Text="Dar VB°" />
                </td>
                <td></td>
                <td></td>
                <td></td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
</asp:Content>
