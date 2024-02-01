<%@ Page Title="Liquidaciones de Compra" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="LiquidacionCompra.aspx.cs" Inherits="LiquidacionCompra" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link type="text/css" href="../CSS/base.css" rel="stylesheet" />
    <style type="text/css">
        .your-class::-webkit-input-placeholder {
            color: red;
        }
        /*#detalleP{
            display:none;
        }*/
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
    </style>
    <script type="text/javascript">
        $(function () {

            UHTML.id = 'MainContent';
            var CTD = Operacion.mask('txtTDOC').val(), CLQ, COMP, DI = "PE";
            var CODATA = {};
            var AMOVC = [],APE = [];
            var AUXO = [];//CARGADO CONSULTAR FECHAS
            var AL = "";
            var cAUX = 0;
            var ni = [];
            var IDX = [];//ITEM ELEGIDOS
            var IDXI = [];//ITEM
            var AT = [];//SUBTOTAL
            var $tr;
            var myRow;
            //CONFIGURACION
            var currentDate = moment().format('DD/MM/YYYY');
            Operacion.inputEstado('txtTDOC', 1, true);
            Operacion.inputEstado('ddlMON', 1, true);
            Operacion.mask('ddlMON').val('MN');
            Operacion.inputEstado('ddlTIA', 1, true);
            Operacion.inputEstado('ddlSDIA', 1, true);
            //Operacion.mask('ddlALM').val('A002');
            Operacion.mask('txtFEC').val(currentDate);
            //Operacion.inputEstado('btnConsultar', 1, false);
            Operacion.mask('txtFPAG').val('PRIORITARIO');
            Operacion.oDialog('detallePE', 0);
            $(".dp1").datepicker();
            $(".dp2").datepicker();
            $(".dp3").datepicker();
            CODATA.XFECCAM2 = Operacion.mask('txtFC').val();
            //METODOS
            var valida = function () {
                return Operacion.iVALC(['txtPRO', 'lblDNI', 'txtFEC',
                    'txtTIC', 'txtGLO']);
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
            var iniciaTD = function (ID) {
                $.ajax({
                    type: "POST",
                    url: "ModificacionCabecera.aspx/getLISTATD",
                    data: "{ dato: '" + ID + "', codigo:'04' }",
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        //console.log(data);
                        if (data.d.length > 0) {
                            jQuery.each(data.d, function (i, val) {
                                Operacion.mask('txtTDOC').val(val['TG_CCLAVE']);
                                Operacion.mask('lblTDOC').text(val['TG_CDESCRI']);
                            });
                        } else {
                            Operacion.mask('ddlSER').val('');
                            Operacion.mask('txtTDOC').val('');
                        }
                    }, error: function (response) {
                        console.table(response);
                    }
                });
            }
            var iniciaTC = function (CODATA, OP) {
                $.ajax({
                    type: "POST",
                    url: "RegistroEntradaOC.aspx/getTC",
                    data: '{CODATA:' + JSON.stringify(CODATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        if (data.d != null) {
                            Operacion.mask('txtTIC').val((OP == "C" ? data.d['XMEIMP'] : data.d['XMEIMP2']));
                        } else {
                            Operacion.mask('txtTIC').val('');
                        }
                    },
                    error: function (response) {
                        console.log(response);
                    }
                });
            }
            var iniciaPE = function () {
                AMOVC = [];//REEMPLAZAR
                AT = [];//REEMPLAZAR
                IDX = [];//REEMPLAZAR

                var PEPF = {};
                PEPF.C5_CALMA = Operacion.mask('ddlALM').val();
                PEPF.C5_CTD = "PE";
                PEPF.C5_CCODMOV = "MP";
                PEPF.C5_CRFTDOC = Operacion.mask('txtTDOC').val();
                PEPF.C5_CCODPRO = Operacion.mask('txtPRO').val();
                PEPF.C5_DFECDOC = moment(Operacion.mask('txtDFEC').val(), 'DD-MM-YYYY');
                PEPF.C5_DFECMOD = moment($(this).val(), 'DD-MM-YYYY');

                $.ajax({
                    type: "POST",
                    url: "LiquidacionCompra.aspx/getPEPF",
                    data: '{PDATA:' + JSON.stringify(PEPF) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        $('#cblPET').empty();
                        if (data.d.length > 0) {
                            Operacion.inputEstado('btnAceptar', 0, false);
                            Operacion.mask('cblPE').empty();
                            var table = $('<table id=MainContent_cblPE></table>');
                            var counter = 0;
                            $.each(data.d, function (i, elem) {
                                var CD = elem['C6_CCODIGO'].trim() + "-" + elem['C5_CNUMDOC']; //v1:solo codigo
                                AUXO[CD] = [
                                    elem['C5_CTD'],
                                    moment(elem['C5_DFECDOC']).format('DD/MM/YYYY'),
                                    //elem['C6_CITEM'],
                                    elem['C6_CCODIGO'],//2
                                    elem['C6_CDESCRI'],//3
                                    elem['C6_NCANTID'],//4
                                    elem['AR_CUNIDAD']//5
                                ];
                                var vfecha = (elem['C5_DFECDOC'] != 'undefined' ? moment(elem['C5_DFECDOC']).format('DD/MM/YYYY') : "");
                                table.append($('<tr></tr>').append($('<td></td>').append($('<input>').attr({
                                    type: 'checkbox', name: 'ctl00$MainContent$cblPE$' + counter, value: CD, id: 'MainContent_cblPE_' + counter
                                })).append($('<label>').attr({ for: '' + counter++ }).text(elem['C5_CNUMDOC'])).append(' | Producto:' + elem['C6_CDESCRI'] + ' | Cantidad:' + elem['C6_NCANTID'] + ' | Fecha Documento: <span id=fecha>' + elem['C5_DFECDOC'] + '</span>')));
                                $('#cblPET').append(table);
                                cAUX = counter;
                            });

                        } else {
                            $('#cblPET').html('No existe PE en el rango de fechas buscado');
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
            var iniciaST = function () {

                var gridView = document.getElementById("<%=gvDetalle.ClientID %>");
                LEN = gridView.rows.length;
                acum = 0;
                for (var t = 1; t < LEN; t++) {
                    //var input = gridView.rows[t].getElementsByTagName('input'); SI FUERA UN INPUT DENTRO DE UN TD
                    control50 = gridView.rows[t].cells[5];
                    control51 = control50.innerHTML;
                    //control51 = input[1].value;
                    acum += Number(control51);
                }

                Operacion.mask('lblVV').text(acum);
                Operacion.mask('lblIGV').text(0.00);
                Operacion.mask('lblTV').text(acum);
                //REEMPLAZAR CONFIGURACION
                Operacion.mask('txtRTOV').val(acum);
                Operacion.mask('txtRREN').val(0.015 * Number(Operacion.mask('lblVV').text()));//(0.015 * Operacion.mask('txtVALT').val());
                Operacion.mask('txtRNPA').val(Operacion.mask('txtRTOV').val() - Operacion.mask('txtRREN').val());
            }
            var iniciaGrilla = function () {
                Operacion.mask('gvDetalle').empty();
                Operacion.mask('gvDetalle').attr('style', 'background-color:White;border-color:#CCCCCC;border-width:1px;border-style:None;border-collapse:collapse;width: 100%;');
                Operacion.mask('gvDetalle').append("<tr style='color:White;background-color:#006699;font-weight:bold;'><th align='left' scope='col' style='font-size:8pt;width:100px;'>Codigo</th><th align='left' scope='col' style='font-size:8pt;width:500px;'>Descripcion</th><th align='center' scope='col' style='font-size:8pt;width:50px;'>UM</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Cantidad</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Precio</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Valor Venta</th></tr>");
                var LDATA = IDXI.length;//TODOS LOS PExCODIGO PRODUCTOxNUMERACION
                MU = jQuery.unique(IDX);
                sum = 0;
                for (var i = 0; i < LDATA; i++) {
                    if (MU.length != 1) {
                        sum = (AMOVC[IDXI[i]][4]);//OK
                    } else {
                        sum += (AMOVC[IDXI[i]][4]);
                    }
                }
                $.each(MU, function (i, v) {
                    Operacion.mask('gvDetalle').append("<tr><td style='font-size:8pt;text-align:center;'>" +
                    AMOVC[IDXI[i]]['2'] + "</td><td style='font-size:8pt;text-align:left;'>" +
                    AMOVC[IDXI[i]]['3'] + "</td><td style='font-size:8pt;text-align:center;'>" +
                    AMOVC[IDXI[i]]['5'] + "</td><td style='font-size:8pt;text-align:center;'>" +//AMOVC[v]['5']
                    sum + "</td><td style='font-size:8pt;text-align:right;'>" + //AMOVC[ID]['5']
                    "<input type='text' id='MainContent_txtPRE1' style=text-align:right onkeypress=$(this).numeric('.') placeholder='0.00' value='1.00'/></td><td style='font-size:8pt;text-align:right;;'>" +
                    (sum * 1) + "</td></tr>");
                    //"<input type='text' id='MainContent_txtVALT' style=text-align:right onkeypress=$(this).numeric('.') placeholder='0.00' place ReadOnly=true value='" + (sum * 1) + "'/></td></tr>");
                });
                iniciaST();
            };
            var correlativo = function () {
                //CORRELATIVO LQ
                var NDATA = {};
                NDATA.TN_CCODIGO = Operacion.mask('txtTDOC').val();
                NDATA.TN_CNUMSER = Operacion.mask('ddlSER').val();
                $.ajax({
                    type: "POST",
                    url: "LiquidacionCompra.aspx/correlativoID",
                    data: '{ NDATA: ' + JSON.stringify(NDATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
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
            var correlativoCP = function (FECHA) {
                //CORRELATIVO COMPROBANTE
                var DATA = {};
                DATA.TN_CCODIGO = moment(Operacion.mask('txtFEC').val(), 'DD/MM/YYYY');
                $.ajax({
                    type: "POST",
                    url: "LiquidacionCompra.aspx/correlativoCP",
                    data: '{ DATA: ' + JSON.stringify(DATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        COMP = data.d;
                    },
                    error: function (response) {
                        console.table(response);
                    }
                });
            }
            var insertaCLQ = function () {
                var fechac = moment();
                LCDATA = {};
                LCDATA.LC_CCODAGE = Operacion.mask('ddlAGE').val();
                LCDATA.LC_CTD = Operacion.mask('txtTDOC').val();
                LCDATA.LC_CNUMDOC = CLQ;
                LCDATA.LC_DFECCOM = moment(Operacion.mask('txtFEC').val(), 'DD/MM/YYYY');
                LCDATA.LC_DFECDOC = moment(Operacion.mask('txtFEC').val(), 'DD/MM/YYYY');
                LCDATA.LC_DFECVEN = moment(Operacion.mask('txtFEC').val(), 'DD/MM/YYYY');
                LCDATA.LC_CDH = "";
                LCDATA.LC_CVENDE = "";
                LCDATA.LC_CNROCAJ = Operacion.mask('lblNCAJ').text().trim();
                LCDATA.LC_CVANEXO = Operacion.mask('ddlTIA').val().trim();
                LCDATA.LC_CCODPRV = Operacion.mask('txtPRO').val();
                LCDATA.LC_NOMBRE = Operacion.mask('lblPRO').text();
                LCDATA.LC_CDIRECC = Operacion.mask('txtDIR').val();
                LCDATA.LC_CRUC = Operacion.mask('txtPRO').val();
                LCDATA.LC_CCHENUM = "";
                LCDATA.LC_CSUBDIA = Operacion.mask('ddlSDIA').val();
                LCDATA.LC_CCOMPRO = COMP;//CORRELATIVO COMPROBANTE
                LCDATA.LC_CALMA = Operacion.mask('ddlALM').val();
                LCDATA.LC_NIMPORT = Operacion.mask('txtRTOV').val();
                LCDATA.LC_NIMPRET = Operacion.mask('txtRREN').val();
                LCDATA.LC_CFORVEN = Operacion.mask('txtFPAG').val();
                LCDATA.LC_NSALDO = Operacion.mask('txtRTOV').val();
                LCDATA.LC_NIMPIGV = 0;
                LCDATA.LC_NTIPCAM = Operacion.mask('txtTIC').val();
                LCDATA.LC_CTIPO = 'V';//V:VIGENTE
                LCDATA.LC_DFECCAM = null;
                LCDATA.LC_CCODMON = Operacion.mask('ddlMON').val();
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

                $.ajax({
                    type: "POST",
                    url: "LiquidacionCompra.aspx/guardarLQ",
                    data: '{LCDATA:' + JSON.stringify(LCDATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        actualizaCPE();
                    },
                    error: function (response) {
                        alert('El proceso no se pudo completar LQ');
                        console.table(response);
                    }
                });
            }
            var insertaDLQ = function (IT, CP, DS, CT, UN, PR) {
                var sutt = (CT * PR);
                var oper = (sutt / Operacion.mask('txtTIC').val());
                var dret = (sutt * 0.015);
                var operus = dret / Operacion.mask('txtTIC').val();
                var fechac = moment();

                var LDDATA = {};
                LDDATA.LD_CCODAGE = Operacion.mask('ddlAGE').val();
                LDDATA.LD_CTD = CTD;
                LDDATA.LD_CNUMDOC = CLQ;
                LDDATA.LD_CITEM = IT;
                LDDATA.LD_CCODIGO = CP;
                LDDATA.LD_CDESCRI = DS;
                LDDATA.LD_CTR = "";
                LDDATA.LD_NCANTID = CT;
                LDDATA.LD_CUNIDAD = UN;
                LDDATA.LD_NPRECIO = PR;
                LDDATA.LD_NPRECI1 = PR;
                LDDATA.LD_DFECDOC = moment(Operacion.mask('txtFEC').val(), 'DD/MM/YYYY');
                LDDATA.LD_NIGVMN = 0;
                LDDATA.LD_NIGVUS = 0;
                LDDATA.LD_NIGVPOR = 0;
                LDDATA.LD_NIMPUS = oper;
                LDDATA.LD_NIMPMN = sutt;
                LDDATA.LD_NIMPRMN = dret;
                LDDATA.LD_NIMPRUS = operus;
                LDDATA.LD_CESTADO = "";
                LDDATA.LD_CVENDE = "";
                LDDATA.LD_CNROCAJ = Operacion.mask('lblNCAJ').text().trim();
                LDDATA.LD_CALMA = Operacion.mask('ddlALM').val();
                LDDATA.LD_CSTOCK = "";//N:REEMPLAZAR
                LDDATA.LD_CUSUCRE = Operacion.mask('hdUSUARIO').val();
                LDDATA.LD_DFECCRE = fechac;

                $.ajax({
                    type: "POST",
                    url: "LiquidacionCompra.aspx/guardarLQD",
                    data: '{LDDATA:' + JSON.stringify(LDDATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        //uCABPE();
                    },
                    error: function (response) {
                        alert('El proceso no se pudo completar LQD');
                        console.table(response);
                    }
                });
            }
            var actualizaCPE = function () {
                var ni = IDXI.split('-');
                APE.push(ni[1]);
                var LEN = IDX.length;
                for (var i = 0; i < LEN;i++){
                    var VDATA = {};
                    VDATA.C5_CALMA = Operacion.mask('codAL').val();
                    VDATA.C5_CTD = DI;//DOCUMENTO INGRESO:PE
                    VDATA.C5_CNUMDOC = APE[i];//CORRELATIVO N PE
                    //VDATA.C5_CCODMOV= "V";VALORIZADO
                    VDATA.C5_CRFTDOC = Operacion.mask('txtTDOC').val();//LQ
                    VDATA.C5_CRFNDOC = CLQ;
                    VDATA.C5_CGUIFAC="S";
                    VDATA.C5_CCODMON = Operacion.mask('ddlMON').val();//MONEDA
                    VDATA.C5_NTIPCAM = Operacion.mask('txtTIC').val();//CANTIDAD TC
                    VDATA.C5_CTIPO = "V";//REEMPLAZAR
                    VDATA.C5_CSUBDIA = Operacion.mask('ddlSDIA').val();//SUBDIARIO
                    VDATA.C5_CCOMPRO = COMP;//CORRELATIVO N. COMPROBANTE
                    //VDATA.C5_CUSUMOD = Operacion.mask('hdUSUARIO').val();//NO ES NECESARIO OPCIONAL.

                    $.ajax({
                        type: "POST",
                        url: "ValorizacionMM.aspx/valorizaCabecera",
                        data: '{ VDATA: ' + JSON.stringify(VDATA) + '}',
                        contentType: "application/json;charset=utf-8",
                        dataType: "json",
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
            var actualizaDPE = function (ND,IT,CT,PR,ST) {
                //(IT, CP, DS, CT, UN, PR)
                var VDETA = {};
                VDETA.C6_CALMA = Operacion.mask('codAL').val();
                VDETA.C6_CTD = DI;//DOCUMENTO DE INGRESO
                VDETA.C6_CNUMDOC = ND;
                VDETA.C6_CITEM = IT;
                VDETA.C6_CCANTEN=CT;
                VDETA.C6_NPREUN1=PR;
                VDETA.C6_NPREUNI=PR;
                VDETA.C6_NMNPRUN=PR;
                VDETA.C6_NUSPRUN=PR;
                VDETA.C6_CESTADO="V";
                VDETA.C6_NVALTOT=ST;
                VDETA.C6_NMNIMPO=ST;
                VDETA.C6_NUSIMPO=ST/Operacion.mask('txtTIC').val();
                VDETA.C6_CSUBDIA=Operacion.mask('ddlSDIA').val();
                VDETA.C6_CCOMPRO=COMP;
                VDETA.C6_CCODMON=Operacion.mask('ddlMON').val();
                VDETA.C6_CTIPO="V";

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
                        alert('El proceso no se pudo completar VD');
                        console.log(data);
                    }
                });
            }
            var insertaPLQ = function () {
                var element = Operacion.mask('txtFEC').val();
                var fecha = element.split('/');
                var nfecha = fecha[0]+""+fecha[1]+""+fecha[2];

                var DH = Operacion.mask('txtRREN').val();
                var TC = Operacion.mask('txtTIC').val();

                var PLQDATA = {};
                PLQDATA.PG_VANEXO=Operacion.mask('ddlTIA').val().trim();
                PLQDATA.PG_CCODIGO=Operacion.mask('lblDNI').text().trim();
                PLQDATA.PG_CTIPDOC=CTD;
                PLQDATA.PG_CNUMDOC=CLQ;
                PLQDATA.PG_CORDKEY="";//REEMPLAZAR
                PLQDATA.PG_CDEBHAB="D";
                PLQDATA.PG_NIMPOMN=DH;
                PLQDATA.PG_NIMPOUS=DH/TC;
                PLQDATA.PG_CFECCOM=nfecha;
                PLQDATA.PG_CSUBDIA=Operacion.mask('ddlSDIA').val();
                PLQDATA.PG_CNUMCOM=COMP;
                PLQDATA.PG_CGLOSA=Operacion.mask('txtGLO').val();
                PLQDATA.PG_CCOGAST="";
                PLQDATA.PG_CORIGEN="CP";//SISPAG
                PLQDATA.PG_CUSUARI=Operacion.mask('hdUSUARIO').val();
                PLQDATA.PG_CCODMON=Operacion.mask('ddlMON').val();
                PLQDATA.PG_DFECCOM=moment(element,'DD/MM/YYY');

                $.ajax({
                    type: "POST",
                    url: "LiquidacionCompra.aspx/guardarPLQ",
                    data: '{ PLQDATA: ' + JSON.stringify(PLQDATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        //
                    },
                    error: function (data) {
                        alert('El proceso no se pudo completar PLQ');
                        console.log(data);
                    }
                });
            }
            

            $(".tb4").autocomplete(
            {   //listarAnexoID
                source: function (request, response) {
                    $.ajax({
                        url: "RegistroEntrada.aspx/getCliente",
                        data: "{COD:'P',CAD: '" + request.term + "%" + "'}",
                        //data: "{COD:'P',CAD: '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        success: function (data) {

                            response($.map(data.d, function (item) {
                                return {
                                    value: item.ACODANE.trim(),
                                    dni: item.ANUMIDE.trim(),
                                    dir: item.AREFANE.trim(),
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
                    var str = ui.item.id, str1 = ui.item.dni, str2 = ui.item.dir;
                    Operacion.mask('lblPRO').text(str);
                    Operacion.mask('lblDNI').text((str1 == "" ? alert('La persona no cuenta con un documento registrado') : str1.trim()));
                    Operacion.mask('txtDIR').val(str2);
                },
                change: function (event, ui) {
                    if (ui.item == null || ui.item == undefined) {
                        alert("No ha seleccionado un proveedor valido");
                        Operacion.mask('txtPRO').focus();
                        Operacion.mask('txtPRO').val('');
                    }
                }
            });

            //INICIALIZA
            iniciaTD("LQ");
            iniciaTC(CODATA, "V");

            //EVENTOS
            Operacion.mask('txtFEC').change(function () {
                CODATA.XFECCAM2 = moment($(this).val(), 'DD-MM-YYYY');
                iniciaTC(CODATA, "V");
            });
            $('#btnConsultar').click(function () {
                AL = Operacion.mask('ddlALM').val();
                Operacion.mask('codAL').val(Operacion.mask('ddlALM').val());
                Operacion.inputEstado('ddlALM', 1, true);
                Operacion.inputEstado('txtFEC', 1, true);
                Operacion.inputEstado('btnAceptar', 1, false);
                if (valida()) {
                    $('#MainContent_cblPE').empty();
                    Operacion.oDialog('detallePE', 1);
                    //PEPF = {};
                    //iniciaPE(PEPF);
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
                $tr = $(this).closest('tr');
                myRow = $tr.index();
                var cantidad = $(this).parents("tr").find("td").eq(3).html();
                var oper = parseFloat(cantidad * $(this).val()).toFixed(2);
                //Operacion.mask('txtVALT').val(oper);//REEMPLAZAR
                $("#MainContent_gvDetalle tr:nth-child(" + (myRow + 1) + ") td:nth-child(6)").html(oper);
                iniciaST();
            });
            $("[id*=MainContent_cblPE]").live("click", function () {
                if ($(this).is(':checked')) {
                    if (Operacion.mask('txtFEC').val() == $('#fecha').text()) {

                        $(this).each(function () {
                            var value = $(this).val();//VALOR
                            var nitem = $(this).val();
                            var ni = nitem.split('-');
                            IDXI.push(value);// n elementos elegidos
                            IDX.push(ni[0]);//IDS INICIALIZADOS
                            AMOVC[value] = AUXO[value];
                        });
                    } else {
                        alert('El parte elegido no corresponde a la fecha de proceso');
                        Operacion.inputEstado('btnAceptar', 1, false);
                    }
                } else {
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
                Operacion.mask('txtDFEC').val('');
                Operacion.mask('txtHFEC').val('');
                Operacion.mask('btnConsultar', 1, false);
                $('#detallePE').dialog('close');
                iniciaGrilla();
            });
            $('#btnGuardar').click(function () {
                correlativoCP(Operacion.mask('txtFEC').val());
                if (valida()) {
                    insertaCLQ();
                    var gridView = document.getElementById("<%=gvDetalle.ClientID %>");
                    LEN = gridView.rows.length;
                    for (i = 1; i < LEN; i++) {
                        cellPivot00 = gridView.rows[t].cells[0];
                        gitem00 = cellPivot00.innerHTML;//CODIGO
                        cellPivot01 = gridView.rows[t].cells[1];
                        gitem01 = cellPivot01.innerHTML;//DESCRIPCION
                        cellPivot02 = gridView.rows[t].cells[2];
                        gitem02 = cellPivot02.innerHTML;//UNIDAD
                        cellPivot03 = gridView.rows[t].cells[3];
                        gitem03 = cellPivot03.innerHTML;//CANTIDAD
                        cellPivot04 = gridView.rows[t].cells[4];
                        gitem04 = cellPivot04.innerHTML;//PRECIO
                        cellPivot05 = gridView.rows[t].cells[5];
                        gitem05 = cellPivot05.innerHTML;//VALTOTAL
                        insertaDLQ(Operacion.cadenaMascara(i, 4), gitem00, gitem01, gitem03, gitem02, gitem04);
                        //(ND,IT,CT,PR,ST)
                        actualizaDPE(APE[i-1],IT,CT,PR,gitem05);
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
            <legend>Liquidación de Compra</legend>
            <table>
                <tr>
                    <td>&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td colspan="3">&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Serie</td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlSER" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td colspan="2">&nbsp;</td>
                    <td>Nro Caja</td>
                    <td colspan="3">
                        <asp:Label ID="lblNCAJ" class="e" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Agencia&nbsp;</td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlAGE" runat="server"></asp:DropDownList></td>
                    <td colspan="2"></td>
                    <td>Usuario&nbsp;</td>
                    <td colspan="3">
                        <asp:Label ID="lblUSER" class="e" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Almacen&nbsp;</td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlALM" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td colspan="2"></td>
                    <td colspan="6">Fecha Documento</td>
                    <td>
                        <asp:TextBox ID="txtFEC" placeholder="dd/mm/aaaa" class="dp1" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Moneda&nbsp;</td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlMON" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="6">Tipo Cambio</td>
                    <td>
                        <!--<asp:Label ID="lblTIC" class="e" runat="server" Text=""></asp:Label>-->
                        <asp:TextBox ID="txtTIC" runat="server" ReadOnly="TRUE"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Tipo Documento</td>
                    <td colspan="2">
                        <asp:TextBox ID="txtTDOC" runat="server" BorderStyle="None" Width="36px"></asp:TextBox>
                        <asp:Label ID="lblTDOC" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="6">Forma de pago</td>
                    <td>
                        <asp:TextBox ID="txtFPAG" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Tipo Anexo&nbsp;</td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlTIA" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="7">&nbsp;</td>
                </tr>
                <tr>
                    <td>Proveedor</td>
                    <td colspan="11">
                        <asp:TextBox ID="txtPRO" class="tb4" runat="server" Width="119px"></asp:TextBox>
                        <asp:Label ID="lblPRO" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Nro Doc Identidad&nbsp;&nbsp;</td>
                    <td colspan="2">
                        <asp:Label ID="lblDNI" class="e" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="6">Calidad Producto&nbsp;&nbsp;</td>
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
                    <td colspan="6">Origen Producto</td>
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
                    <td colspan="6">Glosa&nbsp;&nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtGLO" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Tipo Operación&nbsp;</td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlTOPE" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="6">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Observación&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="12">
                        <asp:TextBox ID="txtOBS" TextMode="MultiLine" runat="server" Width="713px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <input id="btnConsultar" class="btn" type="button" value="Consultar PE" /></td>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="12"></td>
                </tr>
                <tr>
                    <td colspan="12">
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
                    <td colspan="2">&nbsp;</td>
                    <td colspan="2" class="auto-style1">Valor Venta</td>
                    <td colspan="2" class="auto-style1">
                        <asp:Label ID="lblVV" runat="server" Text="0.00"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="2" class="auto-style1">IGV</td>
                    <td colspan="2" class="auto-style1">
                        <asp:Label ID="lblIGV" runat="server" Text="0.00"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="2" class="auto-style1">Total Venta</td>
                    <td colspan="2" class="auto-style1">
                        <asp:Label ID="lblTV" runat="server" Text="0.00"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="2" class="auto-style1">&nbsp;</td>
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
                    <td>Retención Renta 1.5%</td>
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
                    <input id="bntGuardar" class="btn" type="button" value="Guardar" /></td>
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
                        <td colspan="3">Nro Documentos</td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div id="cblPET">
                                <asp:CheckBoxList ID="cblPE" runat="server">
                                    <asp:ListItem Text="" Value="-"></asp:ListItem>
                                </asp:CheckBoxList>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <input id="btnAceptar" class="btn" type="button" value="Aceptar" /></td>
                    </tr>
                </table>
            </fieldset>

        </div>
    </div>
    <br />
</asp:Content>

















