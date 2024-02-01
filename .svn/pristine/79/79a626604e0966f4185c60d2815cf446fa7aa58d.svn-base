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
            var IT = "";
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
            //console.log($('.nu').numeric());
            Operacion.inputVisible($('#opcion'), 1);//ACTUALIZAR-TC COMPRA/VENTA
            Operacion.oDialog('detalle', false);
            Operacion.inputVisible($('#btnSalida'), 1);
            //Operacion.mask('ddlMalmacen').val(Operacion.mask('codAL').val());
            //Operacion.inputEstado('txtFC', 1, true);
            Operacion.inputVisible(Operacion.mask('lblFC'), 1);
            Operacion.inputVisible(Operacion.mask('txtFC'), 1);
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
                switch (op) {
                    case 1:
                        Operacion.inputEstado('txtPRO', 1, true);
                        Operacion.inputEstado('txtDORE', 1, true);
                        Operacion.inputEstado('txtNDOC', 1, true);
                        Operacion.inputEstado('txtSUB', 1, true);
                        Operacion.inputEstado('txtCOM', 1, true);
                        Operacion.inputEstado('ddlMN', 1, true);
                        Operacion.inputEstado('ddlTICO', 1, true);
                        Operacion.inputEstado('txtTICA', 1, true);
                        Operacion.inputEstado('btnGuardar', 1, false);
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
                        //Operacion.inputEstado('txtTICA', 1, true);
                        Operacion.inputEstado('btnGuardar', 0, false);
                        break;
                }

            }
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
                            Operacion.mask('txtTICA').val((OP == "C" ? data.d['XMEIMP'] : data.d['XMEIMP2']));
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
                llenarGrilla(Operacion.mask('ddlMalmacen').val(), "PE", Operacion.mask('txtalcanceDia').val(), Operacion.mask('txtalcandeMA').val(), Operacion.mask('txtMNumeroDoc').val());
            }
            var unidad = function (ART, ID) {
                //console.log(ART + " " + ID);
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
                acum = 0;
                for (var t = 1; t < LEN; t++) {
                    //var input = gridView.rows[t].getElementsByTagName('input'); SI FUERA UN INPUT DENTRO DE UN TD
                    control50 = gridView1.rows[t].cells[7];
                    control51 = control50.innerHTML;
                    acum += Number(control51);
                }
                Operacion.mask('hfST').val(acum);
            }
            var llenarGrilla = function (AL, TD, FEC1, FEC2, ND) {
                var CDATA = {};
                CDATA.C5_CALMA = AL;
                CDATA.C5_CTD = TD;
                CDATA.C5_CNUMDOC = "";
                CDATA.C5_DFECDOC = moment(FEC1, 'DD-MM-YYYY 00:00:00.000');
                CDATA.C5_DFECCRE = FEC2;
                //console.log(CDATA);
                $.ajax({
                    type: "POST",
                    //url: "ConsultaReimpresion.aspx/listaDocumentos",
                    url: "ValorizacionMM.aspx/listaFinal",
                    //data: "{ AL: '" + AL + "',TD:'" + TD + "',FEC1:'" + FEC1 + "',FEC2:'" + FEC2 + "',ND:'" + ND + "',CCLI:''}",
                    data: '{ CDATA: ' + JSON.stringify(CDATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        //console.log(Object.keys(data.d).length);
                        Operacion.mask('gvVMM').attr('style', 'background-color:White;border-color:#CCCCCC;border-width:1px;border-style:None;border-collapse:collapse;');
                        if (data.d.length > 0) {
                            Operacion.mask('gvVMM').empty();
                            Operacion.mask('gvVMM').append("<tr style='color:White;background-color:#006699;font-weight:bold;'><th align='center' scope='col' style='font-size:8pt;width:100px;'>TD</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Nro Documento</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>MN</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Fecha Documento</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Mov</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Situacion</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Glosa</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Accion</th></tr>");
                            for (var i = 0; i < data.d.length; i++) {
                                OAUX[AL + "" + data.d[i].C5_CTD + "" + data.d[i].C5_CNUMDOC] = [
                                    (data.d[i].C5_CSOLI.trim() != "" ? (data.d[i].C5_CSOLI + " " + data.d[i].NOMSOL) : ""),
                                    (data.d[i].C5_CCENCOS.trim() != "" ? (data.d[i].C5_CCENCOS + " " + data.d[i].NOMCC) : ""),
                                    data.d[i].C5_CCODMON,
                                    (data.d[i].C5_CCODMOV + " " + data.d[i].NOMMOV),
                                    data.d[i].C5_CRFTDOC,
                                    data.d[i].NOMDR,
                                    data.d[i].C5_CRFNDOC,
                                    data.d[i].C5_CGLOSA1,
                                    data.d[i].C5_CCODPRO,
                                    data.d[i].C5_CNOMPRO,
                                    data.d[i].C5_NTIPCAM,
                                    data.d[i].C5_CNUMORD,
                                    data.d[i].C5_CGLOSA4,
                                    data.d[i].C5_CRFNDO2, //ORIGEN
                                    data.d[i].C5_CSUBDIA,
                                    data.d[i].C5_CCOMPRO,
                                    "",
                                    "",
                                    data.d[i].C5_CCENCOS
                                ];
                                //console.log(OAUX);
                                //var fecha = moment(data.d[i].C5_DFECDOC).format('DD/MM/YYYY');
                                Operacion.mask('gvVMM').append("<tr><td style='font-size:8pt;text-align:center;'>" +
                                    data.d[i].C5_CTD + "</td><td style='font-size:8pt;text-align:center;'>" +
                                    data.d[i].C5_CNUMDOC + "</td><td style='font-size:8pt;text-align:center;'>" +
                                    (data.d[i].C5_CCODMON.trim() == "" ? "-" : data.d[i].C5_CCODMON) + "</td><td style='font-size:8pt;text-align:center;'>" +
                                    data.d[i].C5_DFECDOC + "</td><td style='font-size:8pt;text-align:center;'>" +
                                    data.d[i].C5_CCODMOV + "</td><td style='font-size:8pt;text-align:center;'>" +
                                    data.d[i].C5_CSITUA + "</td><td style='font-size:8pt;'>" +
                                    data.d[i].C5_CGLOSA1 + "</td><td style='width:100px;'><div class='btDetalle' style='text-align:center'><img title='Valorizar' alt='' src='../Images/details.png' width='25' style='cursor:pointer;float:left;'> </div><div class='btPrinter' style='text-align:center'><img alt='' src='../Images/Printer.png' width='25' style='cursor:pointer;float:left;'></div></td></tr>");
                            }

                        } else {
                            Operacion.mask('gvVMM').empty();
                            Operacion.mask('gvVMM').append("<tr style='color:White;background-color:#006699;font-weight:bold;'><th align='center' scope='col' style='font-size:8pt;width:100px;'>TD</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Nro Documento</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>MN</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Fecha Documento</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Mov</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Situacion</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>Glosa</th><th>Accion</th></tr>");
                            Operacion.mask('gvVMM').append("<tr><td style='font-size:8pt;'>-</td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td></tr>");
                        }
                    },
                    error: function (result) {

                        console.log(result);
                    }
                });
            }
            var valorizar = function () {
                //console.log(OAUX[AL + "PE" + ND]);
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
                    success: function (data) {
                        return true;
                    },
                    error: function (data) {
                        console.log(data);
                    }
                });
            }
            var valorizarD = function (AL, TD, ND, IT) {
                //console.log(DOAUX);
                //valorizaDetalle
                var VDETA = {};
                VDETA.C6_CALMA = AL;
                VDETA.C6_CTD = TD;
                VDETA.C6_CNUMDOC = ND;
                VDETA.C6_CITEM = IT;
                VDETA.C6_NPREUN1 = DOAUX[AL + "PE" + ND + "" + IT][1];
                VDETA.C6_NPREUNI = DOAUX[AL + "PE" + ND + "" + IT][1];//PRECIO DESVALVE
                VDETA.C6_NMNPRUN = DOAUX[AL + "PE" + ND + "" + IT][1];
                VDETA.C6_NUSPRUN = DOAUX[AL + "PE" + ND + "" + IT][2];
                VDETA.C6_NVALTOT = DOAUX[AL + "PE" + ND + "" + IT][3];
                VDETA.C6_NMNIMPO = DOAUX[AL + "PE" + ND + "" + IT][3];
                VDETA.C6_NUSIMPO = DOAUX[AL + "PE" + ND + "" + IT][4];
                VDETA.C6_CCODMON = DOAUX[AL + "PE" + ND + "" + IT][5];
                VDETA.C6_CTIPO = DOAUX[AL + "PE" + ND + "" + IT][6];
                VDETA.C6_NTIPCAM = DOAUX[AL + "PE" + ND + "" + IT][7];
                VDETA.C6_CESTADO = DOAUX[AL + "PE" + ND + "" + IT][8];

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
            var correlativoOC = function () {
                //OBTIENE NUMERACION
                var ee;
                //var CNUMDOC = {};
                //CNUMDOC.TN_CCODIGO = "OC";
                //CNUMDOC.TN_CNUMSER = "0001";
                $.ajax({

                    type: "POST",
                    url: "../ORDENCOMPRA/OCnueva.aspx/insertarnumeracion",
                    //data: '{CNUMDOC: ' + JSON.stringify(CNUMDOC) + '}',
                    data: '{}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        Operacion.mask('codM').val(data.d);
                    },
                    error: function (data) {
                        if (data.length != 0)
                            alert(data);
                    }

                });
            }
            var actualizaNUM = function () {
                //ACTUALIZA NUMERACION OC:VERIFICAR
                var extraenum = Operacion.mask('codM').val().trim();
                var datos = {};
                datos.TN_CCODIGO = "OC";
                datos.TN_CNUMSER = "0001";
                datos.TN_NNUMERO = Number(extraenum.substring(5, 11));
                $.ajax({

                    type: "POST",
                    url: "..ORDENCOMRA/OCnueva.aspx/Actualizanum",
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
            var obtieneALDIR = function (ID) {
                //OBTIENE ALMACEN DIRECCION
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
            var registraCOC = function (ID) {

                var horao = obetenerhora();

                var fec1 = moment(Operacion.mask('lblFEC').text(), "DD/MM/YYYY");
                fec1 = fec1 == null ? null : new Date(fec1);
                var fec02 = moment(Operacion.mask('lblFEC').text(), "DD/MM/YYYY");//fecha entrega
                fec02 = fec02 == null ? null : new Date(fec02);
                var dfactual = moment();
                dfactual = dfactual == null ? null : new Date(dfactual);

                var fpagg = "AL CONTADO";
                //fpagg = fpagg.substring(0, 30);

                var CABC = {};
                CABC.OC_CNUMORD = Operacion.mask('codM').val().trim();
                CABC.OC_CCODPRO = OAUX[ID][8].trim();
                CABC.OC_CRAZSOC = OAUX[ID][9].trim();
                CABC.OC_CDIRPRO = "";//R
                CABC.OC_CCOTIZA = Operacion.mask('lblDOC').text().trim();//R
                CABC.OC_CCODMON = OAUX[ID][2].trim();
                CABC.OC_CFORPA1 = fpagg;
                CABC.OC_CFORPA2 = "";
                CABC.OC_CFORPA3 = "";
                CABC.OC_NTIPCAM = OAUX[ID][10].trim();
                CABC.OC_DFECENT = fec02;
                CABC.OC_NPORDES = 0;
                CABC.OC_CCARDES = "";
                CABC.OC_NIMPUS = 0;//importe dolares  R
                CABC.OC_NIMPMN = Operacion.mask('hfST').val();//importe soles  R
                CABC.OC_CSOLICT = "";//R
                CABC.OC_CTIPENV = "";//R
                CABC.OC_CLUGENT = OAUX[ID][19];//"MZA. D LOTE. 01 ZONA INDUSTRIAL II PIURA - PAITA - PAITA";//R:ALMACEN
                CABC.OC_CLUGFAC = OAUX[ID][19];//"MZA. D LOTE. 01 ZONA INDUSTRIAL II PIURA - PAITA - PAITA";//R:ALMACEN
                CABC.OC_CDETENT = Operacion.mask('lbldALM').text().trim() + "-" + Operacion.mask('lblDOC').text().trim();//GLOSA
                CABC.OC_CSITORD = "1";
                CABC.OC_DFECACT = dfactual;
                CABC.OC_CHORA = horao;
                CABC.OC_CUSUARI = Operacion.mask('hdUSUARIO').val();
                CABC.OC_DFECDOC = fec1;
                CABC.OC_CTIPORD = "N";
                CABC.OC_CRESPER1 = "";
                CABC.OC_CRESPER2 = "";
                CABC.OC_CRESPER3 = "";
                CABC.OC_CRESCARG1 = "";
                CABC.OC_CRESCARG2 = "";
                CABC.OC_CRESCARG3 = "";
                CABC.OC_CCOPAIS = "PERU";
                CABC.OC_CUSEA01 = "";
                CABC.OC_CUSEA02 = "";
                CABC.OC_CUSEA03 = "";
                //CABC.OC_DFECR01= ;
                //CABC.OC_DFECR02= ;
                //CABC.OC_DFECR03= ;
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
                CABC.OC_CCONDIC = "";//R: SUBTIPO
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
                CABC.OC_CTIPDOC = "";//R:DOCUMENTO REFERENCIA
                CABC.OC_CALMDES = Operacion.mask('ddlMalmacen').val().trim();
                CABC.OC_CDISTOC = OAUX[ID][20];//R:DISTRITO
                CABC.OC_CPROVOC = OAUX[ID][21];//R:PROVINCIA
                CABC.OC_CCOSTOC = OAUX[ID][18].trim();
                CABC.OC_CDOCPAG = "";
                //CABC.OC_DFECPAG= ;
                //CABC.OC_DFECVEN= ;
                CABC.OC_CESTPAG = "";
                CABC.OC_CMONPAG = "";
                CABC.OC_NIMPPAG = 0;
                CABC.OC_CGLOPAG = "";
                CABC.OC_CCODSOL = "";//R;
                CABC.OC_CCODAGE = "";
                CABC.OC_CCODTAL = "";
                CABC.OC_CORDTRA = "";


                $.ajax({

                    type: "POST",
                    url: "../ORDENCOMPRA/OCnueva.aspx/InsertaCab",
                    data: '{CABC: ' + JSON.stringify(CABC) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        /*if ($("#MainContent_ddltipo").val() == "I" && sindatosimport == 1) {
                            InsertarMovi();
                        }
                        */
                    },
                    error: function (response) {
                        if (response.length != 0)
                            alert(response);
                    }
                });

            }
            var recoreDetalle = function (ID) {

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
                    //cellPivot06 = gridView.rows[t].cells[5]; input; gprecinicial = cellPivot06.innerHTML;//REEEMPLAZAR
                    //--
                    //cellPivot07 = gridView.rows[t].cells[6]; gdesadicx = cellPivot07.innerHTML;
                    //cellPivot21 = gridView.rows[t].cells[6]; gdesadic = cellPivot21.value;
                    //cellPivot08 = gridView.rows[t].cells[7]; gdesitemx = cellPivot08.innerHTML;
                    //cellPivot20 = gridView.rows[t].cells[7]; gdesitem = cellPivot20.value;

                    //cellPivot09 = gridView.rows[t].cells[8]; gigvx = cellPivot09.innerHTML;
                    //cellPivot25 = gridView.rows[t].cells[8]; gvalidaigvx = cellPivot25.value;

                    //cellPivot10 = gridView.rows[t].cells[9]; giscx = cellPivot10.innerHTML;
                    //cellPivot11 = gridView.rows[t].cells[10]; gprecfinal = cellPivot11.innerHTML;

                    //cellPivot12 = gridView.rows[t].cells[11]; gtotaldesc = cellPivot12.innerHTML;
                    //cellPivot22 = gridView.rows[t].cells[11]; gtotaldescx = cellPivot22.value;

                    //cellPivot13 = gridView.rows[t].cells[12]; gigv = cellPivot13.innerHTML;
                    //cellPivot14 = gridView.rows[t].cells[13]; subbt = cellPivot14.innerHTML;//subtotal 
                    //cellPivot15 = gridView.rows[t].cells[14]; gcantent = cellPivot15.innerHTML;
                    //cellPivot151 = gridView.rows[t].cells[14]; ccodsol = cellPivot151.value;
                    //cellPivot23 = gridView.rows[t].cells[17]; gtus01 = cellPivot23.value;
                    //cellPivot16 = gridView.rows[t].cells[15]; gcantsald = cellPivot16.innerHTML;
                    cellPivot24 = gridView.rows[t].cells[7]; gtmn01 = cellPivot24.innerHTML;

                    //cellPivot17 = gridView.rows[t].cells[16]; gfechaent = cellPivot17.innerHTML;
                    //cellPivot18 = gridView.rows[t].cells[4]; gobser = cellPivot18.value;
                    //cellPivot19 = gridView.rows[t].cells[18]; gisc = cellPivot19.innerHTML;

                    gsumadolares = Number(gsumadolares) + Number(gtus01);
                    gsumasoles = Number(gsumasoles) + Number(gtmn01);

                    registraDETC(ID, gitem,t,(MILEN-1), "InsertaDet");
                    registraDETCC(ID);

                }
            }
            var registraDETC = function (ID, IT,MIN, MAX, METODO) {
                //REGISTRA DETALLE COPIA
                var horao = obetenerhora();

                var fec1 = moment(Operacion.mask('lblFEC').text(), "DD/MM/YYYY");
                fec1 = fec1 == null ? null : new Date(fec1);
                var fec2 = moment(Operacion.mask('lblFEC').text(), "DD/MM/YYYY");
                fec2 = fec2 == null ? null : new Date(fec2);

                var dfactual = moment();
                dfactual = dfactual == null ? null : new Date(dfactual);

                var DETA = {};

                DETA.OC_CNUMORD = Operacion.mask('codM').val().trim();//$("#MainContent_txtnumoc").val().trim();
                DETA.OC_CCODPRO = OAUX[ID][8].trim();//$("#MainContent_txtidpro").val().trim();
                DETA.OC_CITEM = IT;//gitem;
                DETA.OC_CCODIGO = gidcod;
                DETA.OC_CCODREF = "";
                DETA.OC_CDESREF = gdescod;
                DETA.OC_CUNIPRO = "";
                DETA.OC_CDEUNPR = "";
                DETA.OC_CUNIDAD = gunid;
                DETA.OC_NCANORD = gcant;
                DETA.OC_NPREUNI = DOAUX[ID + "" + IT][1];//gprecfinal;
                DETA.OC_NPREUN2 = DOAUX[ID + "" + IT][1]//gprecinicial;
                DETA.OC_NDSCPFI = 0;
                DETA.OC_NDESCFI = 0;
                DETA.OC_NDSCPIT = 0;//gdesitemx;
                DETA.OC_NDESCIT = gdesitem;
                DETA.OC_NDSCPAD = 0;//gdesadicx;//
                DETA.OC_NDESCAD = 0;//gdesadic;
                DETA.OC_NDSCPOR = 0;//gtotaldescx;
                DETA.OC_NDESCTO = 0;//gtotaldesc;
                DETA.OC_NIGV = 0;//gigv;
                DETA.OC_NIGVPOR = 0;//gigvx;
                DETA.OC_NISC = 0;//gisc;
                DETA.OC_NISCPOR = 0;//giscx;
                DETA.OC_NCANTEN = gcant;//gcantent;
                DETA.OC_NCANSAL = 0;//gcantsald;
                DETA.OC_NTOTUS = gtmn01 / Operacion.mask('txtTICA').val();//gtus01;
                DETA.OC_NTOTMN = gtmn01;
                DETA.OC_COMENTA = "";//gobser;R:
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
                DETA.OC_CSOLICI = "";//ccodsol;R
                DETA.OC_CITEREQ = "";
                DETA.OC_CREFCOD = "";
                DETA.OC_CPEDINT = "";
                DETA.OC_CITEINT = "";
                DETA.OC_CREFCOM = "";
                DETA.OC_CNOMFAB = "";
                DETA.OC_NCANEMB = 0;
                DETA.OC_DFECENT = fec2;
                DETA.OC_CITMPOR = "N";//(gdesitemx == 0 ? "N" : "S");//R
                DETA.OC_CDSCPOR = "N"; (gdesadicx == 0 ? "N" : "S");//R
                DETA.OC_CIGVPOR = "N"; (gvalidaigvx == 0 ? "N" : "S");//R
                DETA.OC_CISCPOR = "N"; (giscx == 0 ? "N" : "S");//R
                DETA.OC_NTOTMO = 0;
                DETA.OC_NUNXENV = 0;
                DETA.OC_NNUMENV = 0;
                DETA.OC_NCANFAC = 0;
                $.ajax({

                    type: "POST",
                    url: "../ORDENCOMPRA/OCnueva.aspx/" + METODO,
                    data: '{DETA: ' + JSON.stringify(DETA) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        if (MAX == MIN) {
                            if (confirm('Se ha generado la OC NRO:' + Operacion.mask('codM').val().trim() + ' para el \n\ PE:' + Operacion.mask('lblDOC').text().trim())) {
                                cargar();
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
                DETA.PM_CCOTIZA = "";//$("#MainContent_txtnumref").val().trim();R
                DETA.PM_CORDCOM = "";//$("#MainContent_txtnumoc").val().trim();R
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
            $('input:radio[name=rb]').click(function () {
                CODATA.XFECCAM2 = moment(Operacion.mask('txtFC').val(), 'DD-MM-YYYY');
                aux = $(this).val();
                Operacion.inputVisible(Operacion.mask('lblFC'), 1);
                Operacion.inputVisible(Operacion.mask('txtFC'), 1);
                Operacion.inputVisible($('#opcion'), 1);
                obtieneTC(CODATA, convierte($(this).val()));
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
                if (valida()) {
                    $tr1 = $(this).closest('tr');
                    myRow1 = $tr1.index();
                    IT = $(this).parents("tr").find("td").eq(0).html();
                    var cantidad = $(this).parents("tr").find("td").eq(5).html();
                    var oper = parseFloat(cantidad * $(this).val()).toFixed(2);
                    var est = (Number($(this).val()) != 0 ? "V" : "");
                    //0:CANTIDAD,1:PRECIO,2:PRECIOUS,3:TOTAL,4:TOTALUS,5:ESTADO
                    DOAUX[AL + "PE" + ND + "" + IT][1] = Number($(this).val());
                    DOAUX[AL + "PE" + ND + "" + IT][2] = ($(this).val() / Operacion.mask('txtTICA').val());
                    DOAUX[AL + "PE" + ND + "" + IT][3] = Number(oper);
                    DOAUX[AL + "PE" + ND + "" + IT][4] = (oper / Operacion.mask('txtTICA').val());
                    DOAUX[AL + "PE" + ND + "" + IT][5] = Operacion.mask('ddlMN').val();
                    DOAUX[AL + "PE" + ND + "" + IT][6] = Operacion.mask('ddlTICO').val();
                    DOAUX[AL + "PE" + ND + "" + IT][7] = Operacion.mask('txtTICA').val();
                    DOAUX[AL + "PE" + ND + "" + IT][8] = (est);
                    //console.log(DOAUX);
                    $("#MainContent_gvDetalle tr:nth-child(" + (myRow1 + 1) + ") td:nth-child(8)").html(oper);
                    $("#MainContent_gvDetalle tr:nth-child(" + (myRow1 + 1) + ") td:nth-child(9)").html(est);
                    //$("#MainContent_gvDetalle tr:nth-child(" + (myRow1 + 1) + ") td:nth-child(13)").html(oper);
                    //$("#MainContent_gvDetalle tr:nth-child(" + (myRow1 + 1) + ") td:nth-child(14)").html(est);
                    valorizarD(AL, TD, ND, IT);
                    Operacion.mask('ddlMN').removeAttr('style');
                    iniciaST();
                } else {
                    alert('Verificar que todo los campos esten completos');
                }

            });
            Operacion.mask('txtFC').change(function () {
                CODATA.XFECCAM2 = moment($(this).val(), 'DD-MM-YYYY');
                obtieneTC(CODATA, convierte($('input:radio[name=rb]').val()));
            });

            $(".tb4").autocomplete(
                {   /*getCliente:reemplazar CLIENTES - PROVEEDORES*/
                    source: function (request, response) {
                        //var TM = Operacion.mask('codCC').val();
                        //var ADATA = {};
                        //ADATA.AVANEXO = "P";
                        //ADATA.ADESANE = '%' + request.term + '%';
                        //ADATA.ATIPTRA = (TM == "CO" ? "J" : (TM == "MP" ? "N" : null));
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
                window.open("../ALMACEN/Reportes/ReporteFinaliza.aspx?AL=" + AL + "&TD=" + TD + "&ND=" + ND, '_blank');
            });
            $('.btDetalle').live("click", function () {
                //DETALLE
                Operacion.oDialog('detalle', true);
                $tr = $(this).closest('tr');
                myRow = $tr.index();

                TD = $(this).parents("tr").find("td").eq(0).html();
                ND = $(this).parents("tr").find("td").eq(1).html();//GENERAL
                var FD = $(this).parents("tr").find("td").eq(3).html();
                var MV = $(this).parents("tr").find("td").eq(4).html();
                var ME = $(this).parents("tr").find("td").eq(5).html();
                Operacion.mask('codCC').val(MV);
                CODATA.XFECCAM2 = moment(FD, 'DD/MM/YYYY');
                var mitc = (OAUX[AL + "" + TD + "" + ND][10] != "" ? OAUX[AL + "" + TD + "" + ND][10] : obtieneTC(CODATA, "V"));
                //0:SOLICITANTE 1:CENTRO COSTO 2:TIPO MOVIMIENTO 3:DOCUMENTO REFERENCIA
                Operacion.mask('lblDOC').text(TD + " " + ND);
                Operacion.mask('lbldALM').text(Operacion.mask('ddlMalmacen option:selected').text());
                Operacion.mask('lblFEC').text(FD);
                Operacion.mask('lblSOL').text(OAUX[AL + "" + TD + "" + ND][0]);
                Operacion.mask('lblCC').text(OAUX[AL + "" + TD + "" + ND][1]);
                Operacion.mask('ddlMN').val(OAUX[AL + "" + TD + "" + ND][2]);
                Operacion.mask('lblCM').text(OAUX[AL + "" + TD + "" + ND][3]);
                Operacion.mask('txtDORE').val(OAUX[AL + "" + TD + "" + ND][4]);
                Operacion.mask('lblDORE').text(OAUX[AL + "" + TD + "" + ND][5]);
                Operacion.mask('txtNDOC').val(OAUX[AL + "" + TD + "" + ND][6]);
                Operacion.mask('lblGLO').text(OAUX[AL + "" + TD + "" + ND][7]);
                Operacion.mask('txtPRO').val(OAUX[AL + "" + TD + "" + ND][8]);
                Operacion.mask('lblPRO').text(OAUX[AL + "" + TD + "" + ND][9]);
                Operacion.mask('txtTICA').val(mitc);
                Operacion.mask('lblDER').text((OAUX[AL + "" + TD + "" + ND][12] == "" ? OAUX[AL + "" + TD + "" + ND][11] : OAUX[AL + "" + TD + "" + ND][12]));
                Operacion.mask('ddlTICO').val('V');
                Operacion.mask('lblORI').text(OAUX[AL + "" + TD + "" + ND][13]);
                (OAUX[AL + "" + TD + "" + ND][11] != "" || OAUX[AL + "" + TD + "" + ND][12] != "" ? DER(true) : DER(false));
                //(Operacion.mask('txtDORE').val() == "FT" || Operacion.mask('txtDORE').val() == "LQ" ? bloqueo(1) : bloqueo(2));
                (ME == "V" ? bloqueo(1) : bloqueo(2));

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
                            Operacion.mask('gvDetalle').append("<tr style='color:White;background-color:#006699;font-weight:bold;'><th align='center' scope='col' style='font-size:8pt;width:30px;'>ITEM</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>CODIGO</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>DESCRIPCION</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>SERIE</th><th align='center' scope='col' style='font-size:8pt;width:50px;'>UNID</th><th align='center' scope='col' style='font-size:8pt;width:80px;'>CANTIDAD</th><th align='center' scope='col' style='font-size:8pt;'>PRECIO UNIT.</th><th align='center' scope='col' style='font-size:8pt;width:80px;'>%VALOR TOTAL</th><th align='center' scope='col' style='font-size:8pt;width:60px;'>ESTADO</th></tr>");
                            //Operacion.mask('gvDetalle').append("<tr style='color:White;background-color:#006699;font-weight:bold;'><th align='center' scope='col' style='font-size:8pt;width:30px;'>ITEM</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>CODIGO</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>DESCRIPCION</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>SERIE</th><th align='center' scope='col' style='font-size:8pt;width:50px;'>UNID</th><th align='center' scope='col' style='font-size:8pt;width:80px;'>CANTIDAD</th><th align='center' scope='col' style='font-size:8pt;width:70px;'>C/IGV</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>TASA IGV.</th><th align='center' scope='col' style='font-size:8pt;width:100px;'>PRECIO UNIT.</th><th align='center' scope='col' style='font-size:8pt;width:80px;'>%DSCTO1</th><th align='center' scope='col' style='font-size:8pt;width:80px;'>%DSCTO2</th><th align='center' scope='col' style='font-size:8pt;width:80px;'>%DSCTO3</th><th align='center' scope='col' style='font-size:8pt;width:80px;'>%VALOR TOTAL</th><th align='center' scope='col' style='font-size:8pt;width:60px;'>ESTADO</th></tr>");
                            for (var i = 0; i < data.d.length; i++) {
                                var COAUX = AL + "" + TD + "" + ND;
                                DOAUX[AL + "PE" + ND + "" + data.d[i].C6_CITEM] = [
                                    data.d[i].C6_NCANTID,
                                    data.d[i].C6_NPREUNI,
                                    0,
                                    data.d[i].C6_NVALTOT,
                                    0,
                                    data.d[i].C6_CCODMON,
                                    data.d[i].C6_CTIPO,
                                    data.d[i].C6_NTIPCAM,
                                    data.d[i].C6_CESTADO
                                ];
                                unidad(data.d[i].C6_CCODIGO, COAUX);

                                Operacion.mask('gvDetalle').append("<tr><td style='font-size:8pt;'>" +
                                data.d[i].C6_CITEM + "</td><td style='font-size:8pt;text-align:center;'>" +
                                data.d[i].C6_CCODIGO + "</td><td style='font-size:8pt;'>" +
                                data.d[i].C6_CDESCRI + "</td><td style='font-size:8pt;'>" +
                                data.d[i].C6_CSERIE + "</td><td style='font-size:8pt;text-align:center;'>" +
                                OAUX[COAUX][16] + "</td><td style='font-size:8pt;text-align:right;'>" +
                                data.d[i].C6_NCANTID + "</td><td style='font-size:8pt;text-align:right;'>" +
                                //data.d[i].C6_NDESCTO + "</td><td style='font-size:8pt;text-align:right;'>" +
                                //data.d[i].C6_NDESCTO + "</td><td style='font-size:8pt;text-align:right;'>" +
                                //"<input type='text' id='MainContent_txtPRE1' onkeypress=$(this).numeric('.') placeholder='0.00' value='" + data.d[i].C6_NPREUNI + "' " + (data.d[i].C6_CESTADO.trim() == "V" ? 'ReadOnly=true' : '') + "/></td><td style='font-size:8pt;text-align:right;'>" +
                                "<input type='text' id='MainContent_txtPRE1' onkeypress=$(this).numeric('.') placeholder='0.00' value='" + data.d[i].C6_NPREUNI + "' " + (ME=='V' ? 'ReadOnly=true' : '') + " style=text-align:right /></td><td style='font-size:8pt;text-align:right;'>" +
                                //data.d[i].C6_NPREUNI + "</td><td style='font-size:8pt;text-align:right;'>" +
                                //data.d[i].C6_NDESCTO + "</td><td style='font-size:8pt;text-align:right;'>" +
                                //data.d[i].C6_NDESCTO + "</td><td style='font-size:8pt;text-align:right;'>" +
                                //data.d[i].C6_NDESCTO + "</td><td style='font-size:8pt;text-align:right;'>" +
                                data.d[i].C6_NVALTOT + "</td><td style='font-size:8pt;text-align:center;'>" +
                                (data.d[i].C6_CESTADO.trim() == "" ? "<span style='color:red;'>S/V</span>" : data.d[i].C6_CESTADO) + "</td></tr>");

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
            });

            $('#btnGuardar').click(function () {
                if (confirm('Confirma desea finalizar la valorizacion de parte de entrada')) {
                    if (valida() && Operacion.mask('ddlMN').val() != "-1") {
                        $('#detalle').dialog('close');
                        var ID = AL + "PE" + ND;
                        OAUX[ID][4] = Operacion.mask('txtDORE').val();
                        OAUX[ID][6] = Operacion.mask('txtNDOC').val();
                        OAUX[ID][8] = Operacion.mask('txtPRO').val();
                        OAUX[ID][9] = Operacion.mask('lblPRO').text();
                        //OAUX[AL+"PE"+ND][]=Operacion.mask('ddlTICO').val();
                        OAUX[ID][10] = Operacion.mask('txtTICA').val();//TIPO CAMBIO
                        OAUX[ID][2] = Operacion.mask('ddlMN').val();
                        OAUX[ID][14] = Operacion.mask('txtSUB').val();
                        OAUX[ID][15] = Operacion.mask('txtCOM').val();
                        OAUX[ID][17] = Operacion.mask('ddlTICO').val();

                        valorizar();
                        if (Operacion.mask('codCC').val() == "CO" && Operacion.mask('txtDORE').val()=="FT") {
                            correlativoOC();
                            obtieneALDIR(ID);
                            registraCOC(ID);
                            recoreDetalle(ID);
                        } else {
                            cargar();
                        }
                        //console.log(OAUX);
                        //console.log(DOAUX);//ID:AL-PE-ND-ITEM
                        OAUX = [];
                        DOAUX = [];
                        Operacion.mask('ddlMN').removeAttr('style');
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
            width: 940px;
        }

        fieldset {
            width: 900px;
        }

        table {
            width: 100%;
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
                    <td class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
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
                    <td></td>
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
    <br />
    <div id="detalle" title="Valorización de Movimientos">
        <table style="width: 100%;">
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
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
                <td>
                    <strong>Documento</strong><asp:Label ID="lblDOC" runat="server" Text=""></asp:Label>
                </td>
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
                <td>&nbsp;</td>
                <td colspan="2">&nbsp;</td>
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
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td><strong></strong></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td><strong>Documento Referencia</strong></td>
                <td colspan="2">
                    <asp:TextBox ID="txtDORE" runat="server" Width="37px"></asp:TextBox>
                    <asp:Label ID="lblDORE" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <!--<asp:Label ID="lblDR2" runat="server" Text="Documento Referencia 2"></asp:Label>-->
                </td>
                <td>&nbsp;</td>
                <td colspan="2">
                    <!--<asp:TextBox ID="txtDORE0" runat="server" Width="37px"></asp:TextBox>
                    <asp:Label ID="lblDORE0" runat="server" Text=""></asp:Label>-->
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
                        <input id="rb1" checked="true" name="rb" type="radio" value="C" />Compra<br />
                        <input id="rb2" name="rb" type="radio" value="V" />Venta
                    </div>
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
                    <asp:HiddenField ID="hfST" runat="server" />
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    <input id="btnGuardar" type="button" value="Valorizar" class="btn" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

















