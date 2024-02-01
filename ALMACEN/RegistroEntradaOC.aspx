<%@ Page Title="Registro Entrada con Orden de Compra" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="RegistroEntradaOC.aspx.cs" Inherits="RegistroEntradaOC" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link type="text/css" href="../CSS/base.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {
            var aa = 1, idCod = "", $tr, myRow, aux, CTD = 'PE', CODATA = {}, DOCDATA = {}, OAUX = [];//ITEMS DETALLE CANTIDAD
            var OBJG = [];//ITEMS SI TIENE SERIE
            var IT = [], SALDO = [];
            var OA = [], IND = [];//LOTES
            var cont = [];//$('#MainContent_gvDIC tr').length;//1;
            var ct = true, rpta;
            //LOAD:INICIA
            UHTML.id = 'MainContent';
            $('.dp1').datepicker();
            $('.dp2').datepicker();
            Operacion.oDialog('detalle', false);
            Operacion.oDialog('iCantidad', false);

            Operacion.inputEstado('btnGuardar', 1, false);
            Operacion.inputEstado('txtFC', 1, true);
            /*Operacion.inputEstado('txtTC', 1, true);*/
            Operacion.mask('ddlTipoConversion').val('V');//v
            Operacion.inputVisible($('#opcion'), 1);//ACTUALIZAR-TC COMPRA/VENTA
            Operacion.iValida(Operacion.mask('txticRec'), 1);//SEAN NUMEROS
            Operacion.iValida(Operacion.mask('txticPUC'), 1);//SEAN NUMEROS
            Operacion.iValida(Operacion.mask('txticST'), 1);//SEAN NUMEROS
            Operacion.inputEstado('ddlicMoneda', 1, true);
            Operacion.inputVisible($('#btnModificar'), 1);
            Operacion.inputEstado('btnFinalizar', 1, false);
            Operacion.iValida(Operacion.mask('txtCANL'), 1);//SEAN NUMEROS
            CODATA.XFECCAM2 = moment(Operacion.mask('lblFechaE').text(), 'DD-MM-YYYY 00:00:00.000');

            var uus = $("#HeadLoginView_HeadLoginName").html();
            Operacion.mask('hfusuario').val(uus);

            $(".tb").autocomplete(
                {
                    source: function (request, response) {
                        var OCDATA = {};
                        OCDATA.OC_CNUMORD = "%" + request.term + "%";
                        OCDATA.OC_CTIPORD = "N";
                        //data: "{COD:'P',CAD: '" + request.term + "%" + "'}",
                        $.ajax({
                            url: "RegistroEntradaOC.aspx/getOC",
                            data: '{ OCDATA: ' + JSON.stringify(OCDATA) + '}',
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            dataFilter: function (data) { return data; },
                            success: function (data) {
                                //console.log(data.d);
                                var aux = "";
                                if (data.d.length > 0) {
                                    //console.log(data.d);
                                    Operacion.mask('txtFOC').val('');
                                    Operacion.mask('txtPROV').val('');
                                    /*if (data.d[0].situanum == "5") {
                                        alert('El documento ya se encuentra atentido totalmente');
                                    } else if (data.d[0].situanum == "1") {
                                        alert('El documento esta emitido, pero no esta aprobado');
                                    } else if (data.d[0].situanum == "6") {
                                        alert('El documento se encuentra liquidado');
                                    } else if (data.d[0].situanum == "7") {
                                        alert('El documento de encuentra anulado');
                                    } else if (data.d[0].situanum == "2" || data.d[0].situanum == "4") {
                                        aux = data.d;
                                    }*/
                                    aux = data.d;
                                }
                                response($.map(aux, function (item) {

                                    return {
                                        value: item.OC_CNUMORD,
                                        id: item.OC_DFECDOC,
                                        rs: item.OC_CRAZSOC,
                                        pv: item.OC_CODPRO,
                                        mn: item.OC_CCODMON
                                    }
                                }))
                            },
                            error: function (response) {
                                console.log(response);
                            }
                        });
                    },
                    minLength: 1,
                    select: function (event, ui) {
                        if (ui.item.et == "5") {
                            alert('El documento ya se encuentra atentido totalmente');
                        } else {
                            var str = ui.item.id;//FECDOC
                            var str1 = ui.item.rs;//RAZON
                            var str2 = ui.item.pv;//PROVEEDOR
                            var str3 = ui.item.value;
                            var str4 = ui.item.mn;
                            Operacion.mask('lblNOC').text(str1);
                            Operacion.mask('txtFOC').val(str);
                            Operacion.mask('txtPROV').val(str2);
                            Operacion.mask('lblNROD').text(str3);
                            Operacion.inputEstado('btnGuardar', 0, false);
                            Operacion.mask('txtTDR').focus();
                            Operacion.mask('ddlicMoneda').append("<option value=" + str4 + ">" + str4 + "</option");
                        }
                    }
                });

            //FUNCIONES
            var correlativo = function (AL, TD) {
                $.ajax({
                    type: "POST",
                    url: "RegistroEntrada.aspx/correlativoID",
                    data: "{ AL: '" + AL.trim() + "', TDOC:'" + TD.trim() + "'}",
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        Operacion.mask('txtNumeroDoc').val(data.d);
                        Operacion.mask('lblDND').text(data.d);
                        idCod = data.d;
                        //guardarCabecera();
                    },
                    error: function (response) {
                        console.log(response);
                    }
                });
            }
            var valida = function () {
                return Operacion.iVALC(['txtCM', 'txtNumeroDoc', 'ddlTipoConversion', 'txtTC', 'txtNOC',
                    'txtFOC', 'txtPROV', 'txtTDR',
                    'txtNDOC']);
            }
            var obtieneTC = function (CODATA, OP) {
                $.ajax({
                    type: "POST",
                    url: "RegistroEntradaOC.aspx/getTC",
                    data: '{CODATA:' + JSON.stringify(CODATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        if (typeof data.d != 'undefined' && data.d != null) {
                            //jQuery.each(data.d, function (i, val) {
                            Operacion.mask('txtTC').val((OP == "M" ? data.d['XMEIMP'] : data.d['XMEIMP2']));
                            //});
                        } else {
                            Operacion.mask('txtTC').val('');
                        }
                    },
                    error: function (response) {
                        console.log(response);
                    }
                });
            }
            var obtieneDato = function (COD, KEY) {
                var codigowh = KEY;
                var codigoconswh = COD;
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
                        //console.log(data.d);
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
                return {ee}
            }
            var verificaLF = function (COD) {
                $.ajax({
                    url: "RegistroEntrada.aspx/getProductoID",
                    data: "{ 'dato': '" + COD + "'}",
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {

                        if (data.d.length != 0) {
                            //verificaLF(data.d[0]['AR_CCODIGO']);
                            (data.d[0]['AR_CFLOTE'] == "N" ? Operacion.inputEstado('txtCANL', 1, true) : Operacion.inputEstado('txtCANL', 0, true));
                            (data.d[0]['AR_CFLOTE'] == "N" ? Operacion.inputEstado('txticSL', 1, true) : Operacion.inputEstado('txticSL', 0, true));
                            (data.d[0]['AR_CFLOTE'] == "N" ? Operacion.inputEstado('txticFV', 1, true) : Operacion.inputEstado('txticFV', 0, true));
                            (data.d[0]['AR_CFLOTE'] == "N" ? Operacion.inputEstado('txtSTL', 1, true) : Operacion.inputEstado('txtSTL', 0, true));
                            (data.d[0]['AR_CFSERIE'] == "N" && data.d[0]['AR_CFLOTE'] == "N" ? Operacion.inputVisible($('#btnAgregar'), 1) : Operacion.inputVisible($('#btnAgregar'), 0));
                            (data.d[0]['AR_CFSERIE'] == "N" && data.d[0]['AR_CFLOTE'] == "N" ? Operacion.mask('gvDIC').hide(1) : Operacion.inputVisible($('#MainContent_gvDIC'), 0));
                            //(data.d[0]['AR_CFSERIE'] == "N" && data.d[0]['AR_CFLOTE'] == "N" ? Operacion.inputVisible($('#MainContent_gvDIC'),1) : Operacion.inputVisible($('#MainContent_gvDIC'), 0));
                        }
                    },
                    error: function (response) {
                        console.log(response);
                    }
                });
            }
            var llenarGDET = function (OC) {
                DOCDATA.OC_CNUMORD = OC;
                $.ajax({
                    type: "POST",
                    url: "RegistroEntradaOC.aspx/verLOD",
                    data: '{ DOCDATA: ' + JSON.stringify(DOCDATA) + ' }',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        Operacion.mask('gvDREOC').attr('style', 'background-color:White;border-color:#CCCCCC;border-width:1px;border-style:None;border-collapse:collapse;');
                        if (data.d.length > 0) {
                            Operacion.mask('gvDREOC').empty();
                            Operacion.mask('gvDREOC').append("<tr style='color:White;background-color:#006699;font-weight:bold;'><th align='center' scope='col' style='font-size:8pt;width:50px;'>ITEM</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>CODIGO</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>DESCRIPCION</th><th align='center' scope='col' style='font-size:8pt;width:60px;'>UNID.</th><th align='center' scope='col' style='font-size:8pt;width:60px;'>ORDE.</th><th align='center' scope='col' style='font-size:8pt;width:60px;'>ATEN.</th><th align='center' scope='col' style='font-size:8pt;width:60px;'>POR RECEP.</th><th align='left' scope='col' style='font-size:8pt;width:180px;'>SOLIC.</th><th align='center' scope='col' style='font-size:8pt;width:30px;'>ACCIÓN</th></tr>");
                            var sum = 0;
                            for (var i = 0; i < data.d.length; i++) {
                                OAUX[data.d[i].OC_CITEM] = [
                                                            data.d[i].OC_NPREUNI,//0:GENERAR 2 VECES DETALLE
                                                            data.d[i].OC_NPREUN2,//1:PRECIO
                                                            data.d[i].OC_NTOTMN,//2:TOTAL
                                                            data.d[i].OC_NIGVPOR,//3:IGV
                                                            data.d[i].OC_NTOTUS,//4:TUS
                                                            data.d[i].OC_CITEM,//5:ITEM
                                                            data.d[i].OC_CCODIGO,//6:CODIGO
                                                            data.d[i].OC_CDESREF,//7:DESCRIP
                                                            data.d[i].OC_CUNIDAD,//8:UNIDAD
                                                            data.d[i].OC_NCANORD,//9:CANT
                                                            data.d[i].OC_NCANTEN,//10:CANTE
                                                            data.d[i].OC_NCANSAL,//11:CANSA
                                                            data.d[i].OC_CESTADO,//12:ESTADO
                                                            data.d[i].OC_CNUMORD,//13:NOR
                                                            data.d[i].OC_CCODPRO,//14:COPRO
                                                            "",//15:MONEDA
                                                            data.d[i].OC_CSOLICI//16:CODIGO SOLICITANTE
                                ];
                                var prueba = "-";
                                //verificaLF(data.d[i].OC_CCODIGO);
                                Operacion.mask('gvDREOC').append("<tr><td style='text-align:center;font-size:8pt;'>" +
                                    data.d[i].OC_CITEM + "</td><td style='font-size:8pt;'>" +
                                    data.d[i].OC_CCODIGO + "</td><td style='font-size:8pt;'>" +
                                    data.d[i].OC_CDESREF + "</td><td style='font-size:8pt;text-align:center;'>" +
                                    data.d[i].OC_CUNIDAD + "</td><td style='font-size:8pt;text-align:right;'>" +
                                    parseFloat(data.d[i].OC_NCANORD).toFixed(2) + "</td><td style='font-size:8pt;text-align:right;'>" +
                                    (parseFloat(data.d[i].OC_NCANORD) - parseFloat(data.d[i].OC_NCANSAL)).toFixed(2) + "</td><td style='font-size:8pt;text-align:right;'>" +
                                    //parseFloat(data.d[i].OC_NCANTEN).toFixed(2) + "</td><td style='font-size:8pt;text-align:right;'>" + ACTUALIZACION 19.04.2016
                                    parseFloat(data.d[i].OC_NCANSAL).toFixed(2) + "</td><td style='width:100px;'>" +
                                    obtieneDato(data.d[i].OC_CSOLICI, '12').ee + "</td><td style='width:100px;'>" +
                                    (data.d[i].OC_CESTADO == "5" ? "<div id=parcial style='text-align:center;'><img alt='Atender Compra' src='../Images/checked.png' width='15' style='cursor:pointer'></div>" : "<div class='btAtender' style='text-align:center;'><img title='Atender Compra' src='../Images/unchecked.png' width='15' style='cursor:pointer'></div>") + "</tr>");

                                sum += data.d[i].OC_NCANSAL;
                            }
                            Operacion.mask('hfSubtotal').val(sum);
                        } else {
                            Operacion.mask('gvDREOC').empty();
                            Operacion.mask('gvDREOC').append("<tr style='color:White;background-color:#006699;font-weight:bold;'><th align='center' scope='col' style='font-size:8pt;width:100px;'>ITEM</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>CODIGO</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>DESCRIPCION</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>UNID</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>ORDENADO</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>ATENDIDO</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>POR RECEPCIONAR</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>SOLICITANTE</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>ACCIÓN</th></tr>");
                            Operacion.mask('gvDREOC').append("<tr><td style='font-size:8pt;'>-</td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td></tr>");
                        }

                    },
                    error: function (response) {
                        console.log(response);
                    }
                });
            }
            var limpiarGRILLA = function () {
                //ACTUALIZACION 18/03/2016 - TODO COMENTADO
                var rowt = $("[id*=gvDIC] tr:last-child").clone(true);
                $("[id*=gvDIC] tr").not($("[id*=gvDIC] tr:first-child")).remove();
                $("td", rowt).eq(0).html('');
                $("td", rowt).eq(1).html('');
                $("td", rowt).eq(2).html('');
                $("[id*=gvDIC]").append(rowt);
                rowt = $("[id*=gvDIC] tr:last-child").clone(true);
                Operacion.mask('txtSTL').val(0);
                OBJG.length = 0;//REEMPLAZAR
            }
            var aITEMGRILLA = function () {
                var CR = Operacion.mask('txtSTL').val();//txtSTL
                var NR = Operacion.mask('txticRec').val();
                var SR = (Operacion.mask('txticSL').val() == "" ? 'SIN/SERIE' : Operacion.mask('txticSL').val());
                var CL = Operacion.mask('txtCANL').val();
                var FV = moment(Operacion.mask('txticFV').val(), 'DD/MM/YYYY');
                var AL = Operacion.mask('codAL').val();
                var CP = Operacion.mask('lblicCA').text();
                var FD = moment(Operacion.mask('lblFechaDocD').text(), 'DD/MM/YYYY');

                if (CR == NR) {
                    alert('El lote excede a la cantidad que se esta atendiendo.');
                    //ct = false;
                } else {
                    var ESVALIDO = (Number(CR) + Number(CL));
                    if (ESVALIDO > Operacion.mask('txticRec').val()) {
                        alert('La cantidad del lote no debe superar a la atendida');
                    } else {
                        //SALDO.push(SR);
                        var bandera;
                        var gridView = document.getElementById("<%=gvDIC.ClientID %>");
                            for (var t = 1; t < gridView.rows.length; t++) {
                                control0 = gridView.rows[t].cells[0];
                                control1 = control0.innerHTML;
                                if (control1.trim() == SR.trim()) {
                                    bandera = false; break;
                                } else {
                                    bandera = true;
                                }

                            }

                            if (bandera) {
                                //ct = true;
                                var rowt = $("[id*=gvDIC] tr:last-child").clone(true);
                                if (aa == 1) {
                                    $("[id*=gvDIC] tr").not($("[id*=gvDIC] tr:first-child")).remove();
                                    aa = 2;
                                }
                                Operacion.mask('txtSTL').val(Number(CR) + Number(CL));
                                OBJG = [SR, CL, FV, AL, CP, FD];
                                jQuery.each(OBJG, function (i, val) {
                                    if (i != 3 && i != 4 && i != 5) {
                                        $("td", rowt).eq(i).html((i == 2 ? Operacion.mask('txticFV').val() : val));
                                    } else {
                                        $("td", rowt).eq((i == 3 ? 0 : (i == 4 ? 1 : (i == 5 ? 2 : "")))).val(val);
                                    }
                                });
                                $("[id*=gvDIC]").append(rowt);
                                rowt = $("[id*=gvDIC] tr:last-child").clone(true);
                                //ct = false;
                            } else {
                                alert('Verificar que el valor no este duplicado');
                            }
                        }

                    }

                };
            var onumeracion = function () {
                var CDIR = {};
                CDIR.A1_CALMA = Operacion.mask('codAL').val();
                $.ajax({
                    type: "POST",
                    url: "../ORDENCOMPRA/OCnueva.aspx/extraeDirAlma",
                    data: '{ CDIR: ' + JSON.stringify(CDIR) + ' }',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        Operacion.mask('codCC').val(parseInt(data.d['A1_NNUMENT']));//INGRESOS
                        Operacion.mask('codCL').val((data.d['A1_NNUMSAL'] == "" ? 0.00 : data.d['A1_NNUMSAL']));//SALIDAS
                    },
                    error: function (response) {
                        console.log(response);
                    }
                });
            }
            var anumeracion = function (AL, EN, SL) {

                var AXAL = {};
                AXAL.A1_CALMA = AL;
                AXAL.A1_NNUMENT = EN;
                AXAL.A1_NNUMSAL = SL;

                $.ajax({
                    type: "POST",
                    url: "RegistroEntradaOC.aspx/actualizaNumeracion",
                    data: '{ AXAL: ' + JSON.stringify(AXAL) + ' }',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        //
                    },
                    error: function (response) {
                        console.log(response);
                    }
                });
            }
            var actualizaStock = function (codigo, cantidad) {
                if (cantidad != null) {
                    var CANTFINAL = Number(cantidad);//Number(AUXCANT) + Number(cantidad);
                    var DATAI = {};
                    DATAI.SK_CALMA = Operacion.mask('codAL').val();//ALMACEN ELEGIDO-STOCK
                    DATAI.SK_CCODIGO = codigo;
                    DATAI.SK_NSKDIS = CANTFINAL;
                    DATAI.SK_DFECMOV = moment(Operacion.mask('lblFechaE').text(), 'DD-MM-YYYY');

                    $.ajax({
                        type: "POST",
                        url: "RegistroEntrada.aspx/actualizaStock",
                        data: '{DATAI:' + JSON.stringify(DATAI) + ',OP:1}',
                        contentType: "application/json;charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (response) {
                            var MENSAJE = "PE " + Operacion.mask('lblDND').text();
                            if (confirm('Se ha generado el registro' + MENSAJE)) {
                                window.location.href = '../ALMACEN/ConsultaReimpresion.aspx';
                            }
                        },
                        error: function (response) {
                            console.log(response);
                        }
                    });
                }
            }

            //VERIFICAR
            var insertaCabecera = function () {

                fecha = moment($('#MainContent_lblFechaDocD').text(), 'DD-MM-YYYY 00:00:00.000');
                fechac = moment();
                var DATA = {};
                var numDoc = "";

                DATA.C5_CALMA = Operacion.mask('codAL').val();
                DATA.C5_CTD = "PE";
                DATA.C5_CNUMDOC = Operacion.mask('lblDND').text();
                DATA.C5_CLOCALI = "0001";
                DATA.C5_DFECDOC = fecha;//Operacion.mask('lblFechaE').text();//fecha;
                DATA.C5_DFECVEN = null;
                DATA.C5_CTIPMOV = Operacion.mask('lblEntrada').text();
                DATA.C5_CCODMOV = Operacion.mask('txtCM').val();
                DATA.C5_CSITUA = "V";//V
                DATA.C5_CRFTDOC = Operacion.mask('txtTDR').val();
                DATA.C5_CRFNDOC = Operacion.mask('txtNDOC').val();
                DATA.C5_CSOLI = "";
                DATA.C5_CCENCOS = "";//($('#MainContent_txtCentroCosto').val() != "" ? $('#MainContent_txtCentroCosto').val() : "");
                DATA.C5_CRFALMA = "";//($('#MainContent_ddlAlmacenRef').val() == "-1" ? "" : $('#MainContent_ddlAlmacenRef').val());//0101
                DATA.C5_CGLOSA1 = "";//($('#MainContent_txtGlosa1').val() != "" ? $('#MainContent_txtGlosa1').val() : "");
                DATA.C5_CGLOSA2 = "";//($('#MainContent_txtGlosa2').val() != "" ? $('#MainContent_txtGlosa2').val() : "");
                DATA.C5_CGLOSA3 = "";//($('#MainContent_txtGlosa3').val() != "" ? $('#MainContent_txtGlosa3').val() : "");
                DATA.C5_CTIPANE = "";
                DATA.C5_CCODANE = "";
                DATA.C5_DFECCRE = fechac;
                DATA.C5_CUSUCRE = Operacion.mask('hdUSUARIO').val();
                DATA.C5_DFECMOD = null;
                DATA.C5_CUSUMOD = "";
                DATA.C5_CCODCLI = "";//$('#MainContent_txtIDCL').val();
                DATA.C5_CNOMCLI = "";//$('#MainContent_txtCliente').val();
                DATA.C5_CRUC = "";
                DATA.C5_CCODCAD = "";
                DATA.C5_CCODINT = "";
                DATA.C5_CCODTRA = "";
                DATA.C5_CNOMTRA = "";
                DATA.C5_CCODVEH = "";//REL. GLOSA1 MP CH-MATRICULA
                DATA.C5_CTIPGUI = "";//3
                DATA.C5_CSITGUI = "";//F,A,V
                DATA.C5_CGUIFAC = "";//N,S
                DATA.C5_CDESTIN = ""; // 0001
                DATA.C5_CDIRENV = "";
                DATA.C5_CNUMORD = Operacion.mask('txtNOC').val();
                DATA.C5_CTIPORD = "";
                DATA.C5_CGUIDEV = "";
                DATA.C5_CCODPRO = Operacion.mask('txtPROV').val();
                DATA.C5_CNOMPRO = Operacion.mask('lblNOC').text();
                DATA.C5_CCIAS = "";
                DATA.C5_CFORVEN = "";//006,007,014
                DATA.C5_CCODMON = Operacion.mask('ddlicMoneda').val();
                DATA.C5_CVENDE = "";//BROKER
                DATA.C5_NTIPCAM = (Operacion.mask('txtTC').val() == "" ? 0.00 : Operacion.mask('txtTC').val());
                DATA.C5_CCODAGE = "";//001
                DATA.C5_CNUMPED = ""; //PROFORMAS
                DATA.C5_CDIRECC = ""; //DIRECCION
                DATA.C5_NIMPORT = 0;
                DATA.C5_CTIPO = "V";
                DATA.C5_CSUBDIA = "";
                DATA.C5_CCOMPRO = "";
                DATA.C5_NPORDE1 = 0;
                DATA.C5_NPORDE2 = 0;
                DATA.C5_CTF = "";//02
                DATA.C5_NFLETE = 0;
                DATA.C5_CCODAUT = "";
                DATA.C5_CRFTDO2 = "";
                DATA.C5_CRFNDO2 = "";
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
                DATA.C5_CESTFIN = "";//S
                DATA.C5_CFLGPEN = "";//F
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
                        return true;
                    },
                    error: function (response) {
                        console.log(response);
                    }
                });
            }
            var insertaDetalle = function (IT, CO, COD, MN, CANT, DES) {
                var FDOC = moment(Operacion.mask('lblFechaE').text(), 'DD-MM-YYYY');
                var DATAD = {};
                DATAD.C6_CALMA = Operacion.mask('codAL').val();
                DATAD.C6_CTD = "PE";//$('#MainContent_txtIDREF').val().trim();
                DATAD.C6_CNUMDOC = Operacion.mask('lblDND').text();
                DATAD.C6_CITEM = CO;//RECORRER GRILLA
                DATAD.C6_CLOCALI = "0001";//REEMPLAZAR
                DATAD.C6_CCODIGO = COD;
                DATAD.C6_NCANTID = CANT;
                DATAD.C6_NCANTEN = 0;
                DATAD.C6_NCANFAC = 0;
                DATAD.C6_NPREUN1 = Operacion.mask('txticPUC').val();//REEMPLAZAR
                DATAD.C6_NPREUNI = Operacion.mask('txticPUC').val();//REEMPLAZAR
                DATAD.C6_NMNPRUN = Operacion.mask('txticPUC').val();//REEMPLAZAR
                DATAD.C6_NUSPRUN = (Operacion.mask('txticPUC').val() / Operacion.mask('txtTC').val());//REEMPLAZAR
                DATAD.C6_CSERIE = "";
                DATAD.C6_CSITUA = "-";
                DATAD.C6_DFECDOC = FDOC;//Operacion.mask('lblFechaE').text();
                DATAD.C6_DFECVEN = null;
                DATAD.C6_DFECENT = null;
                DATAD.C6_CRFALMA = "";
                DATAD.C6_CTALLA = "";
                DATAD.C6_CESTADO = "V";
                DATAD.C6_CCODMOV = Operacion.mask('txtCM').val();
                DATAD.C6_CORDEN = "";
                DATAD.C6_NVALTOT = Operacion.mask('txticST').val();//REEMPLAZAR
                DATAD.C6_NMNIMPO = Operacion.mask('txticST').val();//REEMPLAZAR
                DATAD.C6_NUSIMPO = (Operacion.mask('txticST').val() / Operacion.mask('txtTC').val());//REEMPLAZAR
                DATAD.C6_CSUBDIA = "";
                DATAD.C6_CCOMPRO = "";
                DATAD.C6_CCODMON = MN;//REEMPLAZAR
                DATAD.C6_CTIPO = "V";
                DATAD.C6_NTIPCAM = (Operacion.mask('txtTC').val() == "" ? 0.00 : Operacion.mask('txtTC').val());
                DATAD.C6_NPREVTA = 0;
                DATAD.C6_CMONVTA = "";
                DATAD.C6_NUNXENV = 0;
                DATAD.C6_NNUMENV = 0;
                DATAD.C6_NDEVOL = 0;
                DATAD.C6_CCENCOS = "";//OPCIONAL
                DATAD.C6_CSOLI = "";
                DATAD.C6_NPRECIO = 0;
                DATAD.C6_NPRECI1 = 0;
                DATAD.C6_NDESCTO = 0;
                DATAD.C6_NIGV = 0;
                DATAD.C6_NIGVPOR = 0;
                DATAD.C6_NIMPMN = 0;
                DATAD.C6_NIMPUS = 0;
                DATAD.C6_CDESCRI = DES;
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
                DATAD.C6_CITEMOC = IT;//NRO ITEM DE OC
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
                        actualizaStock(COD, CANT);
                        //window.location.href = 'http://localhost:2510/ALMACEN/RegistroEntrada.aspx';
                    },
                    error: function (response) {
                        console.log(response);
                    }
                });
            }
            var verificaSL = function (AL, COD, SE) {

                $.ajax({
                    url: "RegistroEntradaOC.aspx/verificaSL",
                    data: "{ AL: '" + AL + "',COD:'" + COD + "',SER:'" + SE.trim() + "'}",
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    async: false,
                    success: function (data) {
                        if (data.d != null) {
                            alert('La serie/lote ya existe');
                            Operacion.mask('txticSL').val('');
                            rpta = false;
                        } else {
                            rpta = true;
                            /*aITEMGRILLA();
                            Operacion.mask('txtCANL').val('');
                            Operacion.mask('txticSL').val('');
                            Operacion.mask('txticFV').val('');*/
                        }

                    },
                    error: function (response) {
                        console.log(response);
                    }
                });
                return { rpta }
            }
            
            var insertaSTXS = function (LT,CA) {
                var DATA = {};
                DATA.SS_CCODIGO = Operacion.mask('lblicCA').text().trim();
                DATA.SS_ALMACEN = Operacion.mask('codAL').val().trim();
                DATA.SS_SOLICITAN = OAUX[Operacion.mask('codCL').val()][16];
                DATA.SS_LOTES = LT;
                DATA.SS_CANTID = CA;
                DATA.SS_ESTADO = "N";
                DATA.SS_SOLICORIGEN = "";

                $.ajax({
                    url: "RegistroEntradaOC.aspx/registraSXS",
                    data: '{ DATA: ' + JSON.stringify(DATA) + ',OP:1}',
                    dataType: "json",
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        alert('Se ha registrado stock por solicitante');
                    },
                    error: function (response) {
                        alert('Hubo error en el ingreso, ponerse en contacto con el area de sistemas');
                        console.log(response);
                    }
                });
            };
            var insertaALSE = function (AL, ITA, SL, CL, FD) {
                var ASDATA = {};
                ASDATA.C6_CLOCALI = "0001";
                ASDATA.C6_CALMA = AL;
                ASDATA.C6_CTD = "PE";
                ASDATA.C6_CNUMDOC = Operacion.mask('lblDND').text().trim();
                ASDATA.C6_CITEM = ITA;
                ASDATA.C6_CCODIGO = Operacion.mask('lblicCA').text().trim();
                ASDATA.C6_CSERIE = SL;
                ASDATA.C6_NCANTID = CL;
                ASDATA.C6_CUSUCRE = Operacion.mask('hdUSUARIO').val();
                //ASDATA.C6_DFECCRE=;
                ASDATA.C6_DFECDOC = FD;
                ASDATA.C6_CITEREQ = "";
                ASDATA.C6_CNUMCEL = "";
                ASDATA.C6_NCANRPE = 0;
                //insertaALSE(gitem00,Operacion.cadenaMascara(i, 4),);
                $.ajax({
                    url: "RegistroEntradaOC.aspx/registraAlmacenSerie",
                    data: '{ ASDATA: ' + JSON.stringify(ASDATA) + '}',
                    dataType: "json",
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        alert('Se ha registrado los lotes con exito');

                    },
                    error: function (response) {
                        alert('Hubo error en el ingreso, ponerse en contacto con el area de sistemas');
                        console.log(response);
                    }
                });
            }
            var insertaSL = function () {
                gitem = "";
                var gridView = document.getElementById("<%=gvDIC.ClientID %>");
                    var MLEN = gridView.rows.length;
                    for (var t = 1; t < MLEN; t++) {
                        cellPivot00 = gridView.rows[t].cells[0];
                        gitem00 = cellPivot00.value;//ALMACEN
                        cellPivot01 = gridView.rows[t].cells[0];
                        gitem01 = cellPivot01.innerHTML;//SERIE
                        cellPivot10 = gridView.rows[t].cells[1];
                        gitem10 = cellPivot10.value;//CODIGO PRODUCTO
                        cellPivot11 = gridView.rows[t].cells[1];
                        gitem11 = cellPivot11.innerHTML;//CANTIDAD LOTE
                        cellPivot21 = gridView.rows[t].cells[2];
                        gitem21 = moment(cellPivot21.value, 'DD/MM/YYYY');//FECHA DOCUMENTO
                        cellPivot22 = gridView.rows[t].cells[2];
                        gitem22 = moment(cellPivot22.innerHTML, 'DD/MM/YYYY');//FECHA VENCIMIENTO
                        /*cellPivot3 = gridView.rows[t].cells[3];
                        gitem3 = cellPivot3.innerHTML;
                        cellPivot4 = gridView.rows[t].cells[4];
                        gitem4 = cellPivot4.innerHTML;
                        cellPivot5 = gridView.rows[t].cells[5];
                        gitem5 = cellPivot5.innerHTML;*/

                        //gsumadolares = Number(gsumadolares) + Number(gtus01);
                        //gsumasoles = Number(gsumasoles) + Number(gtmn01);
                        //InsertarDetalle("InsertaDet");
                        //InsertarDetallecopia();
                        var SDATA = {};
                        SDATA.SR_CALMA = gitem00;
                        SDATA.SR_CCODIGO = gitem10;
                        SDATA.SR_CSERIE = gitem01;
                        SDATA.SR_NSKDIS = gitem11;
                        SDATA.SR_DFECMOV = gitem21;
                        SDATA.SR_DFECVEN = gitem22;

                        $.ajax({
                            url: "RegistroEntradaOC.aspx/registraSerie",
                            data: '{ SDATA: ' + JSON.stringify(SDATA) + '}',
                            dataType: "json",
                            type: "POST",
                            async: false,
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                if (t == (MLEN - 1)) {
                                    alert('Se ha registrado los lotes con exito');

                                }
                                //console.log("t=>" + t + "Operacion.cadenaMascara(" + Operacion.cadenaMascara((t-1), 4)+"");
                            },
                            error: function (response) {
                                alert('Hubo error en el ingreso, ponerse en contacto con el area de sistemas');
                                console.log(response);
                            }
                        });
                        insertaALSE(gitem00, Operacion.cadenaMascara(t, 4), gitem01, gitem11, gitem21);
                        insertaSTXS(gitem01, gitem11);
                    }
                }

            var ocUCabecera = function (IDOC, ES) {
                var ACDATA = {}
                //SDATA = $.extend({}, OBJG);
                ACDATA.OC_CNUMORD = IDOC;
                ACDATA.OC_CSITORD = ES;
                $.ajax({
                    url: "RegistroEntradaOC.aspx/actualizaCabecera",
                    data: '{ ACDATA: ' + JSON.stringify(ACDATA) + '}',
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        //
                    },
                    error: function (response) {
                        console.log(response);
                    }
                });
            }
            var ocUDetalle = function (IDOC, OCCP, OCIT, ES, CA, CS) {
                //IDOC:NUMERO DE ORDEN | OCCP:CODIGO PROVEEDOR |OCIT:ITEMS| ES:ESTADO ATENDIDO/POR ATENDER | CA: CANTIDAD ATENDIDA | CS:CANTIDAD SALIDA
                var DCAB = {}
                //SDATA = $.extend({}, OBJG);
                DCAB.OC_CNUMORD = IDOC;
                DCAB.OC_CCODPRO = OCCP;
                DCAB.OC_CITEM = OCIT;
                DCAB.OC_NCANTEN = CA;
                DCAB.OC_NCANSAL = CS;
                DCAB.OC_CESTADO = ES;

                $.ajax({
                    url: "RegistroEntradaOC.aspx/actualizaDetalle",
                    data: '{ DCAB: ' + JSON.stringify(DCAB) + '}',
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        //
                    },
                    error: function (response) {
                        console.log(response);
                    }
                });
            }

            obtieneTC(CODATA, "V");
            //EVENTOS
            $('input:radio[name=rb]').click(function () {
                CODATA.XFECCAM2 = moment(Operacion.mask('txtFC').val(), 'DD-MM-YYYY');
                //Operacion.inputVisible(Operacion.mask('lblFC'), 1);
                //Operacion.inputVisible(Operacion.mask('txtFC'), 1);
                Operacion.inputVisible($('#opcion'), 1);
                obtieneTC(CODATA, Operacion.conTC($(this).val()));
            });
            Operacion.mask('ddlTipoConversion').change(function () {

                CODATA.XFECCAM2 = moment(Operacion.mask('lblFechaE').text(), 'DD-MM-YYYY 00:00:00.000');
                //var dfecha = moment($('#MainContent_txtMfechaE').val(), 'DD-MM-YYYY 00:00:00.000');

                if ($(this).val().trim() == "F") {
                    Operacion.inputEstado('txtFC', 0, true);
                    Operacion.inputVisible($('#opcion'), 0);//ACTUALIZAR
                } else {
                    Operacion.inputEstado('txtFC', 1, true);
                    Operacion.inputVisible($('#opcion'), 1);//ACTUALIZAR
                    //obtieneTC(CODATA,Operacion.conTC($('#rb').val()));
                    obtieneTC(CODATA, Operacion.conTC($(this).val()));
                }

            });
            Operacion.mask('txtCM').change(function () {

                var OBJ = {};
                OBJ.datos = $(this).val();
                OBJ.tipo = "E";
                //Operacion.oAjax('RegistroEntrada.aspx/getMovimientosID', OBJ);
                //console.log(UHTML.dt);
                $.ajax({
                    type: "POST",
                    url: "RegistroEntrada.aspx/getMovimientosID",
                    data: JSON.stringify(OBJ),
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        if (data.d.length > 0) {
                            jQuery.each(data.d, function (i, val) {
                                Operacion.mask('txtCodigoMov').val(val['TM_CDESCRI']);
                                correlativo(Operacion.mask('codAL').val(), "PE");
                                Operacion.mask('lblcodigoMovimiento').text($(this).val() + "" + val['TM_CDESCRI']);
                                Operacion.mask('txtCM').val(Operacion.mask('txtCM').val().toUpperCase());
                                Operacion.mask('txtNOC').focus();
                            });
                        } else {
                            $('#MainContent_lblMCodigoMov').val("");
                        }
                    },
                    error: function (response) {
                        console.log(response);
                    }
                });
            });
            Operacion.mask('txticRec').change(function () {
                if (Number($(this).val()) > Operacion.mask('txtcPR').val()) {
                    alert('La cantidad no debe exceder a lo pendiente');
                    Operacion.mask('txticRec').val('');
                } else if (Number(Operacion.mask('txticRec').val()) < 0) {
                    Operacion.mask('txticRec').val('');
                } else {
                    var calculo = $(this).val() * Operacion.mask('txticPUC').val();//*(Operacion.mask('txtIGV').val()!=""?(Operacion.mask('txtIGV').val()/1000):1);
                    Operacion.mask('txtcPN').val(parseFloat(Number(Operacion.mask('txtcPR').val()) - Number($(this).val())).toFixed(2));
                    Operacion.mask('txticST').val(calculo);
                }

            });
            Operacion.mask('txtFC').change(function () {
                CODATA.XFECCAM2 = moment($(this).val(), 'DD-MM-YYYY');
                obtieneTC(CODATA, Operacion.conTC($('input:radio[name=rb]').val()));
            });
            Operacion.mask('txtTDR').change(function () {
                $.ajax({
                    type: "POST",
                    url: "ModificacionCabecera.aspx/getLISTATD",
                    data: "{ dato: '" + $(this).val() + "', codigo:'04' }",
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        if (data.d.length > 0) {
                            Operacion.mask('txtTDR').val(Operacion.mask('txtTDR').val().toUpperCase());
                            jQuery.each(data.d, function (i, val) {
                                Operacion.mask('lblTDRD').text(val['TG_CDESCRI']);
                            });
                            Operacion.mask('txtNDOC').focus();
                        } else {
                            Operacion.mask('txtTDR').val("");
                            Operacion.mask('lblTDRD').text("");
                        }
                    }, error: function (response) {
                        console.log(response);
                    }
                });
            });
            Operacion.mask('txtNDOC').change(function () {
                Operacion.mask('txtNRI').focus();
            });
            Operacion.mask('txtNRI').change(function () {
                Operacion.mask('txtGlosa').focus();
            });
            //ACCIONES
            $('#btnAgregar').click(function () {
                if (Operacion.iVALC(['txtCANL', 'txticSL', 'txticFV'])) {

                    var AL = Operacion.mask('codAL').val();
                    var CP = Operacion.mask('lblicCA').text();
                    var SR = (Operacion.mask('txticSL').val() == "" ? 'SIN/SERIE' : Operacion.mask('txticSL').val());
                    var resolve = verificaSL(AL, CP, SR).rpta;
                    if (resolve == true) {
                        aITEMGRILLA();
                        Operacion.mask('txtCANL').val('');
                        Operacion.mask('txticSL').val('');
                        Operacion.mask('txticFV').val('');
                    }

                } else {
                    if (Number(Operacion.mask('txtCANL').val()) > Number(Operacion.mask('txticRec').val())) {
                        alert('Cantidad de lote a ingresar, no debe exceder a la cantidad atendida');
                        Operacion.mask('txtCANL').val('');
                    } else {
                        alert('Verificar campos requeridos');
                    }
                }
            });
            $('#btnActualizar').click(function () {
                //txtcPN:SALDO->OAUX[id][11]
                //GUARDAR LOTES SI LO HUBIERA-ACTUALIZA CUADRO DE PEDIDOS
                //var id = Operacion.cadenaMascara(myRow, 4);
                var id = Operacion.mask('codCL').val();
                var idvid = "<div id=parcial style='text-align:center;'><img alt='Atender Compra' src='../Images/checked.png' width='15' style='cursor:pointer'></div>";
                //NO TIENE LOTE: SIN/LOTE
                //1:CASO NO NECESITA LOTE O FECHA
                OAUX[id][10] = parseFloat(Operacion.mask('txticRec').val()).toFixed(2);//CANTIDAD ELEGIDA 14
                OAUX[id][11] = Operacion.mask('txtcPN').val();//SALDO 11-> OAUX[IT[i]][11]
                OAUX[id][12] = (Operacion.mask('txtcPN').val() == 0 ? "5" : "4");//ESTADO
                if (Operacion.mask('txticSL').is('[disabled]') && Operacion.mask('txticFV').is('[disabled]')) {
                    if (confirm('¿Esta todo conforme?')) {
                        alert('Articulo atendido en ' + Operacion.mask('txticRec').val() + ' unidades');
                        $('#iCantidad').dialog('close');
                        $("#MainContent_gvDREOC tr:nth-child(" + (myRow + 1) + ") td:nth-child(6)").html(parseFloat(Operacion.mask('txticRec').val()).toFixed(2));
                        $("#MainContent_gvDREOC tr:nth-child(" + (myRow + 1) + ") td:nth-child(7)").html(Operacion.mask('txtcPN').val());
                        (Operacion.mask('txtcPN').val() == 0  ? $("#MainContent_gvDREOC tr:nth-child(" + (myRow + 1) + ") td:nth-child(9)").html(idvid) : $("#MainContent_gvDREOC tr:nth-child(" + (myRow + 1) + ") td:nth-child(9)").html(idvid+" Atencion Parcial"));//9
                        Operacion.inputEstado('btnFinalizar', 0, false);
                        Operacion.mask('hfSubtotal').val(Operacion.mask('hfSubtotal').val() - Operacion.mask('txticRec').val());
                        //STOCK X SOLICITANTE-24.05.16
                        insertaSTXS('SIN/SERIE',Operacion.mask('txticRec').val());
                    } else {

                    }
                } else {
                    if (Operacion.mask('txtSTL').val() == Operacion.mask('txticRec').val()) {
                        //2: CASO NECESITA LOTE O FECHA
                        if (confirm('¿Esta todo conforme?')) {
                            alert('Articulo atendido en ' + Operacion.mask('txticRec').val() + ' unidades');
                            $('#iCantidad').dialog('close');
                            Operacion.mask('txtCANL').val('');
                            insertaSL();//REGISTRA SERIE O LOTE
                            var rowt = $("[id*=gvDIC] tr:last-child").clone(true);
                            $("[id*=gvDIC] tr").not($("[id*=gvDIC] tr:first-child")).remove();
                            $("td", rowt).eq(0).html('');
                            $("td", rowt).eq(1).html('');
                            $("td", rowt).eq(2).html('');
                            $("[id*=gvDIC]").append(rowt);
                            rowt = $("[id*=gvDIC] tr:last-child").clone(true);
                            Operacion.mask('txtSTL').val(0);
                            Operacion.inputEstado('btnFinalizar', 0, false);
                            $("#MainContent_gvDREOC tr:nth-child(" + (myRow + 1) + ") td:nth-child(6)").html(Operacion.mask('txticRec').val());
                            $("#MainContent_gvDREOC tr:nth-child(" + (myRow + 1) + ") td:nth-child(7)").html(Operacion.mask('txtcPN').val());
                            (Operacion.mask('txtcPN').val() == 0 ? $("#MainContent_gvDREOC tr:nth-child(" + (myRow + 1) + ") td:nth-child(9)").html(idvid) : $("#MainContent_gvDREOC tr:nth-child(" + (myRow + 1) + ") td:nth-child(9)").html(idvid + " Atencion Parcial"));//ATENDIDO
                            Operacion.mask('hfSubtotal').val(Operacion.mask('hfSubtotal').val() - Operacion.mask('txticRec').val());
                        } else {

                        }
                    } else {
                        alert('Debe completar los lotes , solo ha ingresado ' + Operacion.mask('txtSTL').val() + ' lotes');
                    }
                }

            });
            $('#btnGuardar').click(function () {
                if (valida()) {
                    Operacion.oDialog('detalle', true);
                    Operacion.inputEstado('btnGuardar', 1, false);
                    Operacion.mask('lblFechaDocD').text(Operacion.mask('lblFechaE').text());
                    llenarGDET(Operacion.mask('txtNOC').val());
                } else {
                    alert('Debe completar los campos');
                }

            });
            $('.btAtender').live("click", function () {
                $tr = $(this).closest('tr');
                myRow = $tr.index();
                //COAX = Operacion.cadenaMascara(myRow, 4);
                var ITM = $(this).parents("tr").find("td").eq(0).html();
                var ART = $(this).parents("tr").find("td").eq(1).html();
                var DES = $(this).parents("tr").find("td").eq(2).html();
                var UND = $(this).parents("tr").find("td").eq(3).html();
                var ORD = $(this).parents("tr").find("td").eq(4).html();
                var PRE = $(this).parents("tr").find("td").eq(6).html();
                var SOL = $(this).parents("tr").find("td").eq(7).html();//GRILLA SOLICITANTE
                //var UND = $(this).parents("tr").find("td").eq(3).html();
                verificaLF(ART);
                Operacion.mask('lblSOL').text(SOL);//
                Operacion.mask('lblicCA').text(ART);//CODIGO ARTICULO
                Operacion.mask('lblicDA').text(DES);
                Operacion.mask('lblicUM').text(UND);
                Operacion.mask('txtcREC').val(parseFloat(ORD - PRE).toFixed(2));
                Operacion.mask('txtcORD').val(ORD);
                Operacion.mask('txtcPR').val(PRE);
                Operacion.mask('txtcPN').val(PRE);
                Operacion.mask('codCL').val(ITM);//ITEM ELEGIDO

                var MN = Operacion.mask('ddlicMoneda').val();
                OAUX[ITM][15] = MN;//MONEDA
                //OAUX[ITM][14] = ITM;//ITEM
                $.each(OAUX[ITM], function (i, val) {
                    (MN == "US" ? (i == 0 ? Operacion.mask('lblicUC').text(parseFloat(val).toFixed(8)) : 0.00) : (i == 1 ? Operacion.mask('lblicUC').text(parseFloat(val).toFixed(8)) : 0.00));
                    (MN == "US" ? (i == 4 ? Operacion.mask('lblicST').text(parseFloat(val).toFixed(8)) : 0.00) : (i == 2 ? Operacion.mask('lblicST').text(parseFloat(Operacion.mask('lblicUC').text() * Operacion.mask('txtcORD').val()).toFixed(8)) : 0.00));
                    (i == 3 ? Operacion.mask('txtIGV').val(val) : "");
                });
                Operacion.mask('txticPUC').val(Operacion.mask('lblicUC').text());//txticPUC<-OC_NPREUN2
                Operacion.mask('txticST').val(1 * Operacion.mask('lblicST').text());

                Operacion.mask('txticRec').val("");
                Operacion.mask('txticSL').val("");
                Operacion.mask('txticFV').val("");
                Operacion.inputEstado('btnAgregar', 0, false);
                aa = 1;
                limpiarGRILLA();
                Operacion.oDialog('iCantidad', true);
                IT.push(Operacion.mask('codCL').val());//ITEM QUE SE ATENDERAN //Operacion.cadenaMascara(myRow, 4)
                IT = jQuery.unique(IT);
            });
            $('.btEditar').click(function () {
                //Operacion.inputEstado('txticSL', 1, true);
                Operacion.inputVisible($('#btnAgregar'), 1);
                Operacion.inputVisible($('#btnModificar'), 0);
                //captura fila actual
                $tr = $(this).closest('tr');
                myRow = $tr.index();

                var serie = $(this).parents("tr").find("td").eq(0).html();
                var cantidad = $(this).parents("tr").find("td").eq(1).html();
                var fecha = $(this).parents("tr").find("td").eq(2).html();

                Operacion.mask('txticSL').val(serie);
                Operacion.mask('txtCANL').val(cantidad);
                Operacion.mask('txticFV').val(fecha);

            });
            $('.btEliminar').click(function () {
                var rowCount = $('#MainContent_gvDIC tr').length;
                var trp = $(this).parent().parent();
                //var serie = $(this).parents("tr").find("td").eq(0).html();
                var cantidad = $(this).parents("tr").find("td").eq(1).html();
                if (rowCount == 2) {
                    aa = 1; cont1 = 0;
                    $("td:eq(0)", trp).html("");
                    $("td:eq(1)", trp).html("");
                    $("td:eq(2)", trp).html("");
                    $("[id*=gvDIC]").append(trp);
                    Operacion.mask('txtSTL').val(Operacion.mask('txtSTL').val() - cantidad);
                } else {
                    $($(this).closest("tr")).remove();
                    var removeItem = myRow;
                    cont = $.grep(cont, function (value) {
                        return value != removeItem;
                    });
                    Operacion.mask('txtSTL').val(Operacion.mask('txtSTL').val() - cantidad);
                }
                Operacion.inputEstado('txticSL', 0, true);
                Operacion.mask('txticSL').val('');
                Operacion.mask('txtCANL').val('');
                Operacion.mask('txticFV').val('');
            });
            $('#btnModificar').click(function () {
                //ACTUALIZACION 19/03/2016
                var VC = $("#MainContent_gvDIC tr:nth-child(" + (myRow + 1) + ") td:nth-child(1)").html();
                var CR = Operacion.mask('txticRec').val();
                var AL = Operacion.mask('codAL').val();
                var CP = Operacion.mask('lblicCA').text();
                var SR = Operacion.mask('txticSL').val();//txticSL
                var NI = AL + "" + CP.trim() + "" + VC;//KEY ANTERIOR
                var aux = $("#MainContent_gvDIC tr:nth-child(" + (myRow + 1) + ") td:nth-child(2)").html();
                var STL = Operacion.mask('txtSTL').val();
                var CLO = Operacion.mask('txtCANL').val();
                var resolve = verificaSL(AL, CP.trim(), SR).rpta;
                if (resolve == true) {
                    var OPERACION = Number(STL) - Number(aux) + Number(CLO);
                    if (OPERACION > CR) {
                        alert('Cantidad no debe superar a la cantidad atendida');
                    } else {
                        if (VC.trim() == SR.trim()) {
                            $("#MainContent_gvDIC tr:nth-child(" + (myRow + 1) + ") td:nth-child(1)").html(Operacion.mask('txticSL').val());
                            $("#MainContent_gvDIC tr:nth-child(" + (myRow + 1) + ") td:nth-child(3)").html(Operacion.mask('txticFV').val());
                            $("#MainContent_gvDIC tr:nth-child(" + (myRow + 1) + ") td:nth-child(2)").html(CLO);
                            Operacion.mask('txtSTL').val(Number(STL) - Number(aux) + Number(CLO));
                        } else {
                            //    var bw = 0; aw = 0;
                            //    var rpt = false;
                            var gridView1 = document.getElementById("<%=gvDIC.ClientID %>");
                            LEN = gridView1.rows.length;
                            for (var t = 1; t < LEN; t++) {
                                control0 = gridView1.rows[t].cells[0];
                                control1 = control0.innerHTML;
                                if (control1.trim() != SR.trim()) {
                                    rpt = true;
                                } else {
                                    rpt = false; break;
                                }
                                aw = t;
                            }
                            if (rpt == true && (LEN - 1) == aw) {
                                $("#MainContent_gvDIC tr:nth-child(" + (myRow + 1) + ") td:nth-child(1)").html(Operacion.mask('txticSL').val());
                                $("#MainContent_gvDIC tr:nth-child(" + (myRow + 1) + ") td:nth-child(3)").html(Operacion.mask('txticFV').val());
                                $("#MainContent_gvDIC tr:nth-child(" + (myRow + 1) + ") td:nth-child(2)").html(CLO);
                                Operacion.mask('txtSTL').val(Number(STL) - Number(aux) + Number(CLO));
                            } else {
                                alert('Verificar que serie no este duplicado');
                            }
                        }

                    }
                    Operacion.inputVisible($('#btnAgregar'), 0);
                    Operacion.inputVisible($('#btnModificar'), 1);
                    Operacion.inputEstado('txticSL', 0, true);
                    Operacion.mask('txticSL').val('');
                    Operacion.mask('txtCANL').val('');
                    Operacion.mask('txticFV').val('');
                }
                });
            $('#btnFinalizar').click(function () {
                //IT:ITEM QUE SOLO SE ATENDERAN
                //ocUCabecera(#NRO ORDEN,5:ATENCION TOTAL|4:ATENCION PARCIAL):
                //ocUDetalle(#NRO ORDEN,ID PRODUCTO,ITEM PRODUCTO,ESTADO DETALLE OC,CANTIDAD ATENTIDA(NUEVO),CANTIDAD SALIDA);
                //OAUX[IT[i]][11]:txtcPN|13->NRO ORDEN|14->CODIGO PROVEEDOR|10:CANTIDAD RECIBIDAD|5:ITEM


                insertaCabecera();
                for (i = 0; i < IT.length; i++) {
                    //console.log(OAUX[IT[i]]);
                    (Operacion.mask('hfSubtotal').val() == 0 ? ocUCabecera(OAUX[IT[i]][13], 5) : ocUCabecera(OAUX[IT[i]][13], 4));//ACTUALIZO CABECERA ESTADO
                    (Number(OAUX[IT[i]][11]) == Number(0) ? ocUDetalle(OAUX[IT[i]][13], OAUX[IT[i]][14], OAUX[IT[i]][5], OAUX[IT[i]][12], (OAUX[IT[i]][9] - OAUX[IT[i]][11]), 0) : ocUDetalle(OAUX[IT[i]][13], OAUX[IT[i]][14], OAUX[IT[i]][5], 4, OAUX[IT[i]][10], OAUX[IT[i]][11]));//ACTUALIZO DETALLE 
                    insertaDetalle(OAUX[IT[i]][5], Operacion.cadenaMascara(i + 1, 4), OAUX[IT[i]][6], OAUX[IT[i]][15], OAUX[IT[i]][10], OAUX[IT[i]][7]);
                }
                OBJG = [];
                Operacion.inputEstado('btnFinalizar', 1, false);


                //ocUDetalle(OAUX[IT[i]][13], OAUX[IT[i]][14], OAUX[IT[i]][5], OAUX[id][12], 0, 0) : ocUDetalle(OAUX[IT[i]][13], OAUX[IT[i]][14], OAUX[IT[i]][5], 4, OAUX[IT[i]][10], OAUX[IT[i]][11]));//ACTUALIZO DETALLE 
                //onumeracion();
                //var id = Operacion.cadenaMascara(myRow, 4);
                //anumeracion(Operacion.mask('codAL').val(), OAUX[id][10],Operacion.mask('codCL').val());
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
            <legend>Datos Principales</legend>
            <table style="width: 95%;">
                <tr>
                    <td colspan="4" style="text-align: center;">
                        <asp:Label ID="lblAlmacen" class="titulo" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">Entrada</td>
                    <td>
                        <asp:Label ID="lblEntrada" runat="server" Text=""></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">Codigo Movimiento</td>
                    <td>
                        <asp:TextBox ID="txtCM" runat="server" TabIndex="0" Width="35px"></asp:TextBox>
                        <!--<asp:Label ID="lblCodigoM" runat="server" Text=""></asp:Label>-->

                        <asp:TextBox ID="txtCodigoMov" Width="280px" runat="server" class="tb1" TabIndex="1" ReadOnly="true"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">Numero de documento</td>
                    <td>
                        <asp:TextBox ID="txtNumeroDoc" runat="server" TabIndex="2" ReadOnly="true"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>

        </fieldset>
        <fieldset>
            <legend>Datos Generales</legend>
            <table style="width: 95%;">
                <tr>
                    <td class="auto-style2">Fecha Documento</td>
                    <td colspan="2">
                        <asp:Label ID="lblFechaE" runat="server" Text="FechaElegida"></asp:Label>
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">Tipo Conversión</td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlTipoConversion" TabIndex="3" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style3">Fecha Cambio</td>
                    <td>
                        <asp:TextBox ID="txtFC" class="dp1" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Tipo de Cambio&nbsp;</td>
                    <td colspan="2">
                        <asp:TextBox ID="txtTC" runat="server" ReadOnly="true"></asp:TextBox>
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>
                        <div id="opcion">
                            <input id="rb1" name="rb" type="radio" value="M" checked="checked" />Compra<br />
                            <input id="rb2" name="rb" type="radio" value="V" />Venta
                        </div>
                    </td>

                </tr>
                <tr>
                    <td class="auto-style2">Nro de Orden Compra&nbsp;</td>
                    <td colspan="4">
                        <asp:TextBox ID="txtNOC" class="tb" TabIndex="4" MaxLength="11" runat="server"></asp:TextBox>
                        <asp:Label ID="lblNOC" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Fecha Ord. Compra</td>
                    <td colspan="2">
                        <asp:TextBox ID="txtFOC" ReadOnly="true" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblPROV" runat="server" Text="Proveedor"></asp:Label></td>
                    <td colspan="3">
                        <asp:TextBox ID="txtPROV" class="tb4" Width="134px" TabIndex="3" runat="server" ReadOnly="true"></asp:TextBox>
                        <asp:Label ID="lblProveedor" runat="server" Text=""></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblTDR1" runat="server" Text="Tipo Documento Referencia 1"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtTDR" runat="server" TabIndex="5" Width="38px"></asp:TextBox>
                        <!--<asp:Label ID="lblTDRef1" runat="server" Text=""></asp:Label>-->
                        <asp:Label ID="lblTDRD" runat="server" Text=""></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblND1" runat="server" Text="Nro Documento Ref"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtNDOC" runat="server" TabIndex="6"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">Nro Importación</td>
                    <td>
                        <asp:TextBox ID="txtNRI" TabIndex="7" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblG1" runat="server" Text="Glosa 1"></asp:Label></td>
                    <td colspan="3">
                        <asp:TextBox ID="txtGlosa" TabIndex="8" runat="server" Width="322px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                        <input class='btn' id="btnGuardar" type="button" tabindex="9" value="Ver Orden" /></td>
                    <td>&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </fieldset>
        <div id="detalle" title="Detalle de Entrada con Orden de Compra" style="display:none;">
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">Entrada</td>
                    <td>
                        <asp:Label ID="lbltipoRegistro" runat="server" Text=""></asp:Label>
                    </td>
                    <td>Fecha Documento</td>
                    <td colspan="2">
                        <asp:Label ID="lblFechaDocD" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Codigo Movimiento</td>
                    <td>
                        <asp:Label ID="lblcodigoMovimiento" runat="server" Text=""></asp:Label>
                    </td>
                    <td>Nro Orden</td>
                    <td colspan="2">
                        <asp:Label ID="lblNROD" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Nro Documento</td>
                    <td>
                        <asp:Label ID="lblDND" runat="server" Text=""></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <!--<asp:Button ID="btnagregarItem" runat="server" Text="Agregar"/>-->
                        &nbsp;</td>
                    <td>&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="5">
                        <asp:GridView ID="gvDREOC" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField DataField="OC_ITEM" HeaderText="ITEM" ItemStyle-HorizontalAlign="Right">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>

                                <asp:BoundField DataField="OC_CCODIGO" HeaderText="Codigo" ItemStyle-HorizontalAlign="right">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="OC_CDESREF" HeaderText="Descripcion" ItemStyle-HorizontalAlign="right">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="OC_CUNIDAD" HeaderText="Unidad" ItemStyle-HorizontalAlign="right">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="OC_NCANORD" HeaderText="Ordenado" ItemStyle-HorizontalAlign="right">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="OC_NCANTEN" HeaderText="Atendido" ItemStyle-HorizontalAlign="right">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="OC_NCANSAL" HeaderText="Por recepcionar" ItemStyle-HorizontalAlign="right" DataFormatString="&quot;{0:d}&quot;">
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
                    <td class="auto-style1"></td>
                    <td></td>
                    <td>
                        <asp:HiddenField ID="hfSubtotal" runat="server" />
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;<input id="btnFinalizar" class="btn" type="button" value="Finalizar" /></td>
                </tr>
            </table>
        </div>
        <div id="iCantidad" title="Ingresar Cantidad" style="display:none;">
            <table>
                <tr>
                    <td colspan="2"><strong>Solicitante</strong></td>
                    <td colspan="5">
                        <strong>
                        <asp:Label ID="lblSOL" runat="server" Text=""></asp:Label>
                        </strong>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">Articulo</td>
                    <td>Unidad Med.</td>
                    <td>Producto</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblicCA" runat="server" Style="width: 100px;"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblicUM" runat="server"></asp:Label>
                    </td>
                    <td colspan="4">
                        <asp:Label ID="lblicDA" runat="server" Style="width: 480px;"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Ordenado&nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtcORD" Style="text-align: right; width: 100px;" runat="server" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                        <!--<asp:Label ID="lblcORD" style="text-align: right;width:100px;padding-left:30px;" runat="server"></asp:Label>-->
                    </td>
                    <td>&nbsp;</td>
                    <td>Precio U. Compra</td>
                    <td>
                        <asp:Label ID="lblicUC" runat="server" Text=""></asp:Label>
                    </td>
                    <td>Total</td>
                    <td>
                        <asp:Label ID="lblicST" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Recibido</td>
                    <td>
                        <asp:TextBox ID="txtcREC" runat="server" Style="text-align: right; width: 100px" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                        <!--<asp:Label ID="lblcREC" style="text-align: right;width:100px;padding-left:30px;" runat="server" Text=""></asp:Label>-->
                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Por recibir</td>
                    <td>
                        <asp:TextBox ID="txtcPR" runat="server" Style="text-align: right; width: 100px;" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                        <!--<asp:Label ID="lblcPR" style="text-align: right;width:100px;padding-left:30px;" runat="server" Text=""></asp:Label>-->
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Recibiendo</td>
                    <td>
                        <asp:TextBox ID="txticRec" Style="text-align: right; width: 100px;" placeholder="0.00" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>Precio U. Compra</td>
                    <td>
                        <asp:TextBox ID="txticPUC" placeholder="0.00" runat="server"></asp:TextBox>
                    </td>
                    <td>Total</td>
                    <td>
                        <asp:TextBox ID="txticST" placeholder="0.00" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Pendiente</td>
                    <td>
                        <asp:TextBox ID="txtcPN" Style="text-align: right; width: 100px;" runat="server" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                        <!--<asp:Label ID="lblcPN" style="text-align: right;width:100px;padding-left:30px;" runat="server" Text=""></asp:Label>-->
                    </td>
                    <td></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Incluye I.G.V.</td>
                    <td>
                        <asp:TextBox ID="txtIGV" runat="server" Width="59px" Enabled="false"></asp:TextBox>
                        %</td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td colspan="7">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td>Precio Venta</td>
                    <td>
                        <asp:Label ID="lblicPV1" runat="server" Text=""></asp:Label>
                    </td>
                    <td>Precio Venta2&nbsp;</td>
                    <td>
                        <asp:Label ID="lblicPV2" runat="server" Text=""></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td>Moneda</td>
                    <td>
                        <asp:DropDownList ID="ddlicMoneda" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>

                <tr>
                    <td>
                        <input id="btnAgregar" class="btn" type="button" value="Agregar" />
                        <input id="btnModificar" class="btn" type="button" value="Modificar" /></td>
                    <td>
                        <asp:Label ID="lblCANL" runat="server" Text="Cantidad"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtCANL" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblicSL" runat="server" Text="Serie/Lote"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txticSL" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblicFV" runat="server" Text="Fecha Venci"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txticFV" class="dp2" placeholder="DD/MM/AAAA" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td colspan="7">
                        <asp:GridView ID="gvDIC" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField DataField="OC_ITEM" HeaderText="SERIE/LOTE" ItemStyle-HorizontalAlign="Right">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="OC_NCANTEN" HeaderText="CANTIDAD" ItemStyle-HorizontalAlign="Right">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SR_DFECVEN" HeaderText="FECHA VENCIMIENTO" ItemStyle-HorizontalAlign="Right">
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
                        <asp:Label ID="lblSTL" runat="server" Text="SubTotal Lotes"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSTL" runat="server" value="0" ReadOnly="true"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>
                        <input id="btnActualizar" type="button" class="btn" value="Guardar" /></td>
                </tr>

            </table>
        </div>
    </div>
    <br />
</asp:Content>

















