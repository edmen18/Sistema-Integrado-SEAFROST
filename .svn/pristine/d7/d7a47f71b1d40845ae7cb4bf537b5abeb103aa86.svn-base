<%@ Page Title="RegistroEntrada" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="RegistroEntrada.aspx.cs" Inherits="RegistroEntrada" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link type="text/css" href="../CSS/base.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {
            bandera = true;
            var idCod = "", MCL = [];//NUMERO DE ORDEN DE SERVICIO
            MARRAY = [], M_EB = "";
            var $tr;
            var myRow;
            var CTD = 'PE', miconsulta = 'getProducto';
            UHTML.id = 'MainContent';
            var oc = {};
            //Operacion.iValida($('#MainContent_txtIDMOV'), 1);//valida solo numeros
            Operacion.oDialog('serie', false);
            Operacion.inputEstado('btnGuardar', 1, false);
            Operacion.inputVisible($('#btnActualizar'), 1);
            Operacion.inputEstado('btnFinalizar', 1, false);
            Operacion.inputVisible('lblND2', 1);
            Operacion.inputVisible('ddlOrigen', 1);
            Operacion.inputVisible('ddlDepa', 1);
            Operacion.inputVisible('txtNT', 1);
            Operacion.inputVisible('lblNT', 1);
            Operacion.iValida('txtNT', 1);
            Operacion.iValida('txtCentroCosto', 1);
            Operacion.mask('hfG1').val('-1');
            Operacion.mask('hfOT').val('-1');
            //Operacion.inputVisible('txtAG1', 1);
            Operacion.inputEstado('lblSL', 1, true);
            Operacion.inputEstado('lblSCantidad', 1, true);
            Operacion.mask('ddlMoneda').val('MN');
            Operacion.oDialog('detalleCabecera', false);

            var uus = $("#HeadLoginView_HeadLoginName").html();
            $("#MainContent_hfusuario").val(uus);
            $(".dpFecha1").datepicker();
            $(".dpFecha2").datepicker();


            /*reemplazar*/
            function inputEstado(val, est) {
                (est == 1 ? val.attr('disabled', true) : val.removeAttr("disabled"));
            }

            /*reemplazar*/
            function pad(str, max) {
                if (str != undefined) {
                    str = str.toString();
                    return str.length < max ? pad("0" + str, max) : str;
                }
            }/*reemplazar*/
            var limpiar = function () {
                $(":text").each(function () {
                    if ("#" + $(this)[0].id != Operacion.mask('txtIDMOV').selector) {
                        $($(this)).val('');
                    }
                });
            }
            var valida = function () {
                var M_ALMACEN = Operacion.mask('codAL').val();
                //if (Operacion.mask('codAL').val() == "A002" || Operacion.mask('codAL').val() == "A004" || Operacion.mask('codAL').val() == "T01" || Operacion.mask('codAL').val() == "0015") {
                if (jQuery.inArray(M_ALMACEN, MARRAY) !== -1) {
                    return Operacion.iVALC(['txtProveedor', 'txtIDREF', 'txtTipoDocumentoRef1',
                    'txtNroDocumento1', 'txtNT', 'txtOrdenCompra', 'txtOrdenTrabajo',
                    'txtSolicitante', 'txtCentroCosto', 'txtGlosa1', 'txtGlosa2', 'txtGlosa3',
                    'ddlAlmacenRef', 'txtIDCL', 'txtCliente',
                    'ddlAnexo', 'txtAnexoDetalle']);
                } else {
                    return Operacion.iVALC(['txtProveedor', 'txtIDREF', 'txtTipoDocumentoRef1',
                    'txtNroDocumento1', 'txtOrdenCompra', 'txtOrdenTrabajo',
                    'txtSolicitante', 'txtCentroCosto', 'txtGlosa1',
                    'ddlAlmacenRef', 'txtIDCL', 'txtCliente',
                    'ddlAnexo', 'txtAnexoDetalle']);
                }

            }
            var validaDetalle = function () {
                return Operacion.iVALC(['txtdescripcion', 'txtCantidad', 'txtSerie', 'txtFechaL']);
                //return Operacion.iVALC(['txtidProducto', 'txtdescripcion', 'txtCantidad', 'txtSerie', 'txtFechaL']);
            }
            var filtroserie = function () {
                $(".filtrar tr:has(td)").each(function () {
                    var t = $(this).text();
                    $("<td class='indexColumn'></td>")
                    .hide().text(t).appendTo(this);
                    //console.log(t);
                });
                //Agregar el comportamiento al texto (se selecciona por el ID) 
                $("#texto").keyup(function () {
                    var s = $(this).val().split(" ");
                    //console.log(s);
                    $(".filtrar tr:hidden").show();
                    $.each(s, function () {
                        $(".filtrar tr:visible .indexColumn:not(:contains('"
                        + this + "'))").parent().hide();
                    });
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
                    data: '{ SDATA: ' + JSON.stringify(SDATA) + ',OP:1}',
                    dataType: "json",
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {

                    },
                    error: function (response) {
                        alert('Hubo error en el ingreso, ponerse en contacto con el area de sistemas');
                        console.log(response);
                    }
                });
            }
            var insertaALSE = function (AL, ITA, CD, SL, CL) {
                //AL:ALMACEN,ITA:ITEM GENERADO,CD:COD PRODUCTO,SL:SERIE/LOTE,CL:CANTIDAD LOTE,FD:FECHA DOCUMENTO
                var ASDATA = {};
                ASDATA.C6_CLOCALI = "0001";
                ASDATA.C6_CALMA = AL;
                ASDATA.C6_CTD = "PE";
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
                        alert('Se ha registrado los lotes con exito');
                    },
                    error: function (response) {
                        alert('Hubo error en el ingreso, ponerse en contacto con el area de sistemas');
                        console.log(response);
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
            //CAMBIAR TITULOS X ALMACEN
            var cambiarLABEL = function (AL, CM) {
                iniciaPGE("MP");
                //jQuery.inArray(label[1], EX)
                //if ((AL == "A002" || AL == "A004" || AL == "0004" || AL == "0015") && (CM == "CO" || CM == "MP" || CM == "CX")) {
                if (jQuery.inArray(AL, MARRAY) !== -1 && (CM == "CO" || CM == "MP" || CM == "CX")) {
                    addComplete1();
                    addComplete2();
                    Operacion.inputVisible('txtNT', 0);
                    Operacion.inputVisible('lblNT', 0);
                    //Operacion.inputVisible('txtAG1',0);
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
                    Operacion.inputVisible('lblCBO', 0);
                } else {
                    Operacion.oACD('txtGlosa1');
                    Operacion.oACD('txtOrdenTrabajo');
                    Operacion.mask('txtGlosa1').val('');
                    Operacion.mask('txtNT').val('');
                    Operacion.mask('hfOT').val("-1");
                    Operacion.inputVisible('lblNT', 1);
                    Operacion.inputVisible('txtNT', 1);
                    //Operacion.oACD('txtAG1');
                    //Operacion.inputVisible('txtAG1', 1);
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
                    Operacion.mask('ddlDepa').val("-1");
                    Operacion.mask('ddlOrigen').val("-1");
                    Operacion.inputVisible('txtNroDocumento2', 0);
                    Operacion.inputVisible('lblCBO', 1);
                    //CASO ALMACEN OTROS
                    if (Operacion.mask('txtIDMOV').val() == "CX") {
                        Operacion.inputVisible('lblND3', 1);
                        Operacion.inputVisible('txtNT', 0);
                        Operacion.inputVisible('lblNT', 0);
                    } else {
                        Operacion.inputVisible('txtNT', 1);
                        Operacion.inputVisible('lblNT', 1);
                    }

                }
            }
            //BLOQUEO DE OPCIONES DE ACUERDO AL ALMACEN
            var bloqueo = function (op) {
                $.ajax({
                    type: "POST",
                    url: "RegistroEntrada.aspx/obtenerCampo",
                    data: "{ CM: 'E',TM:'" + op + "'}",
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        if (data.d != null) {
                            if (op == "PR") {
                                Operacion.inputEstado('lblSL', 0, true);
                                Operacion.inputEstado('lblSCantidad', 0, true);
                            }
                            //--
                            Operacion.inputEstado('RadioButton1', 1, true);
                            Operacion.inputEstado('RadioButton2', 1, true);
                            //Operacion.inputEstado('ddlMoneda', 1, true);
                            Operacion.inputEstado('ddlTipoConversion', 1, true);
                            Operacion.inputEstado('ddlTipoCambio', 1, true);
                            Operacion.inputEstado('txtProveedor', (data.d['TM_CFPROV'] == "N" ? 1 : 0), true);
                            Operacion.inputVisible('lblPROV', (data.d['TM_CFPROV'] == "N" ? 1 : 0));//NUEVO
                            Operacion.inputEstado('txtIDREF', (data.d['TM_CFDOC'] == "N" ? 1 : 0), true);
                            Operacion.inputVisible('lblTDR1', (data.d['TM_CFDOC'] == "N" ? 1 : 0));//NUEVO
                            Operacion.inputEstado('txtTipoDocumentoRef1', (data.d['TM_CFDOC'] == "N" ? 1 : 0), true);
                            Operacion.inputVisible('lblND1', (data.d['TM_CFDOC'] == "N" ? 1 : 0));//NUEVO
                            Operacion.inputEstado('txtNroDocumento1', (data.d['TM_CFDOC'] == "N" ? 1 : 0), true);
                            Operacion.inputVisible('lblTDR2', (data.d['TM_CFDOC'] == "N" ? 1 : 0));//NUEVO
                            Operacion.inputEstado('txtTDRef2', (data.d['TM_CFDOC'] == "N" ? 1 : 0), true);
                            Operacion.inputEstado('txtTipoDocumentoRef2', (data.d['TM_CFDOC'] == "N" ? 1 : 0), true);
                            Operacion.inputVisible('lblND2', (data.d['TM_CFDOC'] == "N" ? 1 : 0));//NUEVO
                            Operacion.inputVisible('lblND3', (data.d['TM_CFDOC'] == "N" ? 1 : 0));//NUEVO
                            Operacion.inputEstado('txtNroDocumento2', (data.d['TM_CFDOC'] == "N" ? 1 : 0), true);
                            Operacion.inputVisible('lblOC', (data.d['TM_CORDCOM'] == "N" ? 1 : 0));//NUEVO
                            Operacion.inputEstado('txtOrdenCompra', (data.d['TM_CORDCOM'] == "N" ? 1 : 0), true);
                            Operacion.inputEstado('txtOrdenCompraD', (data.d['TM_CORDCOM'] == "N" ? 1 : 0), true);
                            Operacion.inputVisible('lblG1', (data.d['TM_CFGLOS'] == "N" ? 1 : 0));//NUEVO
                            Operacion.inputEstado('txtGlosa1', (data.d['TM_CFGLOS'] == "N" ? 1 : 0), true);
                            Operacion.inputVisible('lblG2', (data.d['TM_CFGLOS'] == "N" ? 1 : 0));//NUEVO
                            Operacion.inputEstado('txtGlosa2', (data.d['TM_CFGLOS'] == "N" ? 1 : 0), true);
                            Operacion.inputVisible('lblG3', (data.d['TM_CFGLOS'] == "N" ? 1 : 0));//NUEVO
                            Operacion.inputEstado('txtGlosa3', (data.d['TM_CFGLOS'] == "N" ? 1 : 0), true);
                            Operacion.inputVisible('lblG4', (data.d['TM_CFGLOS'] == "N" ? 1 : 0));//NUEVO
                            Operacion.inputEstado('txtGlosa4', (data.d['TM_CFGLOS'] == "N" ? 1 : 0), true);
                            Operacion.inputVisible('lblOT', (data.d['TM_CFORDEN'] == "N" ? 1 : 0));//NUEVO
                            Operacion.inputEstado('txtOrdenTrabajo', (data.d['TM_CFORDEN'] == "N" ? 1 : 0), true);
                            Operacion.inputVisible('lblSOL', (data.d['TM_CFSOLI'] == "N" ? 1 : 0), true);
                            Operacion.inputEstado('txtSolicitante', (data.d['TM_CFSOLI'] == "N" ? 1 : 0), true);
                            Operacion.inputVisible('lblCENCO', (data.d['TM_CFCCOS'] == "N" ? 1 : 0));//NUEVO
                            Operacion.inputEstado('txtCentroCosto', (data.d['TM_CFCCOS'] == "N" ? 1 : 0), true);
                            Operacion.inputEstado('txtDetalleCC', (data.d['TM_CFCCOS'] == "N" ? 1 : 0), true);
                            Operacion.inputVisible('lblAR', (data.d['TM_CFALMA'] == "N" ? 1 : 0));//NUEVO
                            Operacion.inputVisible('ddlAlmacenRef', (data.d['TM_CFALMA'] == "N" ? 1 : 0));
                            //Operacion.inputEstado('ddlAlmacenRef', (data.d['TM_CFALMA'] == "N" ? 1 : 0), true);
                            Operacion.inputVisible('lblCL', (data.d['TM_CVANEXO'] == "N" ? 1 : 0));//NUEVO
                            Operacion.inputEstado('txtIDCL', (data.d['TM_CVANEXO'] == "N" ? 1 : 0), true);
                            Operacion.inputEstado('txtCliente', (data.d['TM_CVANEXO'] == "N" ? 1 : 0), true);
                            Operacion.inputVisible('lblCA', (data.d['TM_CCODANE'] == "N" ? 1 : 0));//NUEVO
                            Operacion.inputVisible('ddlAnexo', (data.d['TM_CCODANE'] == "N" ? 1 : 0));
                            Operacion.inputEstado('txtAnexoDetalle', (data.d['TM_CCODANE'] == "N" ? 1 : 0), true);
                            Operacion.inputEstado('btnGuardar', 0, false);
                            limpiar();
                        } else {
                            inputEstado($('#MainContent_RadioButton2'), 1);
                            inputEstado($('#MainContent_RadioButton1'), 1);
                            //inputEstado($('#MainContent_ddlMoneda'), 1);
                            inputEstado($('#MainContent_ddlTipoConversion'), 1);
                            inputEstado($('#MainContent_ddlTipoCambio'), 1);
                            inputEstado($('#MainContent_txtProveedor'), 1);
                            inputEstado($('#MainContent_txtIDREF'), 1);
                            inputEstado($('#MainContent_txtTipoDocumentoRef1'), 1);
                            inputEstado($('#MainContent_txtNroDocumento1'), 1);
                            inputEstado($('#MainContent_txtTDRef2'), 1);
                            inputEstado($('#MainContent_txtTipoDocumentoRef2'), 1);
                            inputEstado($('#MainContent_txtNroDocumento2'), 1);
                            inputEstado($('#MainContent_txtOrdenCompra'), 1);
                            inputEstado($('#MainContent_txtOrdenCompraD'), 1);
                            inputEstado($('#MainContent_txtGlosa1'), 1);
                            inputEstado($('#MainContent_txtGlosa2'), 1);
                            inputEstado($('#MainContent_txtGlosa3'), 1);
                            inputEstado($('#MainContent_txtGlosa4'), 1);
                            inputEstado($('#MainContent_txtOrdenTrabajo'), 1);
                            inputEstado($('#MainContent_txtSolicitante'), 1);
                            inputEstado($('#MainContent_txtCentroCosto'), 1);
                            inputEstado($('#MainContent_txtDetalleCC'), 1);
                            inputEstado($('#MainContent_ddlAlmacenRef'), 1);
                            inputEstado($('#MainContent_txtIDCL'), 1);
                            inputEstado($('#MainContent_txtCliente'), 1);
                            inputEstado($('#MainContent_ddlAnexo'), 1);
                            inputEstado($('#MainContent_txtAnexoDetalle'), 1);
                            Operacion.inputEstado('lblSL', 1, true);
                            Operacion.inputEstado('lblSCantidad', 1, true);
                            Operacion.mask('txtIDMOV').val('');
                            Operacion.mask('txtCodigoMov').val('');
                            limpiar();
                            inputEstado($('#btnGuardar'), 1);
                        }
                    }, error: function (response) {
                        console.table(response);
                    }

                });

            }

            function limpiarIngresos() {
                Operacion.mask('txtidProducto').val('');
                Operacion.mask('txtdescripcion').val('');
                Operacion.mask('hfidproducto').val('');//
                Operacion.mask('hfdescripcion').val('');//
                Operacion.mask('hdfUnidad').val('');
                //$('#MainContent_txtCentroCosto').val('');
                Operacion.mask('txtSerie').val('');
                Operacion.mask('txtFechaL').val('');//FECHA LOTE
                Operacion.mask('lblSCantidad').text('');//CANTIDAD LOTE
                Operacion.mask('txtCantidad').val('');
                Operacion.mask('lblSTOCK').text('');
            }
            //STOCK DISPONIBLE
            function stockCOD(AL, COD, TR) {
                $.ajax({
                    type: "POST",
                    url: "RegistroEntrada.aspx/getSTOCKCOD",
                    data: "{ AL: '" + AL + "', COD:'" + COD + "',TR:'" + TR + "'}",
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        //console.log(data);
                        if (data.d.length >= 0) {
                            jQuery.each(data.d, function (i, val) {
                                Operacion.mask('lblSTOCK').text(Number(parseFloat(val['SK_NSKDIS']) / 1000).toFixed(2));
                            });
                        } else {
                            //REALIZAR SEGUIMIENTO
                            //alert('El producto elegido, no corresponde al almacen elegido');
                            //Operacion.inputEstado('btnagregarItem', 1, false);
                            //limpiarIngresos();//AGREGO
                        }

                    },
                    error: function (response) {
                        console.table(response);
                    }
                });
            }
            //CORRELATIVO INGRESO
            function correlativo(AL, TD) {
                $.ajax({
                    type: "POST",
                    url: "RegistroEntrada.aspx/correlativoID",
                    data: "{ AL: '" + AL.trim() + "', TDOC:'" + TD.trim() + "'}",
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        //console.log(data);
                        Operacion.mask('txtNumeroDoc').val(data.d);
                        Operacion.mask('lblNroDocumento').text(data.d);
                        idCod = data.d;
                        //guardarCabecera();
                    },
                    error: function (response) {
                        console.log(response);
                    }
                });
            }
            //correlativo("A002", "PE");
            bloqueo(Operacion.mask('codM').val());
            Operacion.mask('txtIDMOV').change(function () {
                Operacion.mask('txtIDMOV').val($(this).val().toUpperCase());
                //iniciaPGE("MP");
                bloqueo(Operacion.mask('txtIDMOV').val());
                cambiarLABEL(Operacion.mask('codAL').val(), $(this).val());
                $.ajax({
                    type: "POST",
                    url: "RegistroEntrada.aspx/getMovimientosID",
                    data: "{ datos: '" + $(this).val() + "',tipo:'E'}",
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        //console.log(data);
                        if (data.d.length > 0) {
                            jQuery.each(data.d, function (i, val) {
                                Operacion.mask('txtCodigoMov').val(val['TM_CDESCRI']);
                            });
                            (Operacion.mask('txtProveedor').is('[disabled]') == true ? Operacion.mask('txtIDREF').focus() : Operacion.mask('txtProveedor').focus());
                        } else {
                            Operacion.mask('lblMCodigoMov').val("");
                        }
                    }
                });
            });
            Operacion.mask('txtIDREF').change(function () {
                Operacion.mask('txtIDREF').val($(this).val().toUpperCase());
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
                Operacion.mask('txtTDRef2').val($(this).val().toUpperCase());
                $.ajax({
                    type: "POST",
                    url: "ModificacionCabecera.aspx/getLISTATD",
                    data: "{ dato: '" + Operacion.mask('txtTDRef2').val() + "', codigo:'04' }",
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        //console.log(data);
                        if (data.d.length > 0) {
                            jQuery.each(data.d, function (i, val) {
                                Operacion.mask('txtTipoDocumentoRef2').val(val['TG_CDESCRI']);
                                (Operacion.mask('txtNroDocumento2').is(":visible") == true ? Operacion.mask('txtNroDocumento2').focus() : Operacion.mask('ddlDepa').focus());
                            });
                        } else {
                            Operacion.mask('txtTipoDocumentoRef2').text("");
                        }
                    }, error: function (response) {
                        console.table(response);
                    }
                });
            });
            Operacion.mask('txtNroDocumento1').change(function () {
                Operacion.mask('txtTDRef2').focus();
            });
            Operacion.mask('ddlDepa').change(function () {
                Operacion.mask('ddlOrigen').focus();
            });
            Operacion.mask('ddlOrigen').change(function () {
                Operacion.mask('txtOrdenCompra').focus();
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
                        Operacion.mask('txtDetalleCC').val(data.d);
                        Operacion.mask('txtGlosa1').focus();
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
            /*Operacion.mask('txtidProducto').change(function () {
                //CORRECTO
                stockCOD(Operacion.mask('codAL').val(), $(this).val(), Operacion.mask('lblEntrada').text().trim());
            });*/
            Operacion.mask('txtSerie').focus(function () {
                if (M_EB == "getEMB") {
                    filtroserie();

                    //LISTAR SERIE - ELECCION
                    var SDATA = {};
                    SDATA.SR_CALMA = Operacion.mask('codAL').val();
                    SDATA.SR_CCODIGO = Operacion.mask('hfidproducto').val();
                    SDATA.SR_CSERIE = "E";
                    $('#serie').dialog("open");
                    $.ajax({
                        type: "POST",
                        url: "RegistroEntrada.aspx/ListarSL",
                        data: '{SDATA:' + JSON.stringify(SDATA) + '}',
                        contentType: "application/json;charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (data) {
                            $('#MainContent_gvSerie').attr('style', 'background-color:White;border-color:#CCCCCC;border-width:1px;border-style:None;border-collapse:collapse;');
                            if (data.d.length > 0) {
                                $('#MainContent_gvSerie').empty();
                                $('#MainContent_gvSerie').append("<tr style='color:White;background-color:#006699;font-weight:bold;'><th align='center' scope='col' style='font-size:8pt;width:50px;text-align:center;'>Serie/Lote</th><th align='center' scope='col' style='font-size:8pt;width:80px;'>Stock Disponible</th><th align='center' scope='col' style='font-size:8pt;width:50px;'>Fecha Venc.</th><th>Accion</th></tr>");
                                for (var i = 0; i < data.d.length; i++) {
                                    var fecha = moment(data.d[i].SR_DFECVEN).format('DD/MM/YYYY');
                                    $("#MainContent_gvSerie").append("<tr><td style='font-size:8pt;text-align:center;'>" +
                                        data.d[i].SR_CSERIE + "</td><td style='font-size:8pt;text-align:center;'>" +
                                        data.d[i].SR_NSKDIS + "</td><td style='font-size:8pt;text-align:center;'>" +
                                        fecha + "</td><td style='font-size:8pt;text-align:center;'>" +
                                        "<div class='btElegir' style='text-align:center;float:left;'><img alt='' src='../Images/unchecked.png' width='15' style='cursor:pointer'> </div></td></tr>");
                                }
                            } else {
                                Operacion.mask('gvSerie').empty();
                                Operacion.mask('gvSerie').append("<tr style='color:White;background-color:#006699;font-weight:bold;'><th align='center' scope='col' style='font-size:8pt;width:50px;text-align:center;'>Serie/Lote</th><th align='center' scope='col' style='font-size:8pt;width:80px;'>Stock Disponible</th><th align='center' scope='col' style='font-size:8pt;width:50px;'>Fecha Venc.</th><th>Accion</th></tr>");
                                Operacion.mask('gvSerie').append("<tr><td style='font-size:8pt;'>-</td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td><td style='font-size:8pt;'></td></tr>");
                            }

                            $(".filtrar tr:has(td)").each(function () {
                                var t = $(this).text();
                                $("<td class='indexColumn'></td>")
                                .hide().text(t).appendTo(this);
                            });
                        },
                        error: function (response) {
                            console.table(response);
                        }
                    });
                } else {
                    //nada
                }

            });
            Operacion.mask('txtCantidad').change(function () {
                $('#btnagregarItem').focus();
            });
            $('#btnagregarItem').click(function () {
                Operacion.iValida('txtCantidad', 1);
                Operacion.inputEstado('btnFinalizar', 0, false);
                if (validaDetalle()) {
                    var cont = 0;
                    //if (rowCount == 2) {
                    //    aa = "1";
                    //}
                    aITEMGRILLA();
                    $(':input').removeAttr('placeholder');
                } else {
                    alert('Debe completar los campos');
                }
            });
            $('.btElegir').live("click", function () {
                //NUEVO ELEGIR UNA SERIE
                var IDSERIE = $(this).parents("tr").find("td").eq(0).html();//SERIE/LOTE
                var CASERIE = $(this).parents("tr").find("td").eq(1).html();//CANTIDAD
                var IDFEVEN = $(this).parents("tr").find("td").eq(2).html();//FECHA VENCIMIENTO
                Operacion.mask('txtSerie').val(IDSERIE);
                Operacion.mask('hfSERIE').val(CASERIE);
                Operacion.mask('txtFechaL').val(IDFEVEN);
                $('#serie').dialog('close');
            });
            $('.btEditar').click(function () {
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

                //Operacion.mask('txtidProducto').val(idProducto);
                Operacion.mask('txtdescripcion').val(idProducto + " " + descripcion);
                //Operacion.mask('txtdescripcion').val(descripcion);
                Operacion.mask('hfidproducto').val(idProducto);
                Operacion.mask('hfdescripcion').val(descripcion);
                Operacion.mask('hdfUnidad').val(unidad);
                Operacion.mask('txtCentroCosto').val(centroc);
                Operacion.mask('txtSerie').val(serie);
                Operacion.mask('txtFechaL').val(fecha);
                Operacion.mask('txtCantidad').val(cantidad);
            });
            $('#btnActualizar').click(function () {
                //$("#MainContent_gvDetalleEntrada tr:nth-child(2) td:nth-child(3)").html('prueba');
                //$("#gvDetalleEntrada tr:nth-child("+(myRow+1)+") td:nth-child(0)").html();
                $("#MainContent_gvDetalleEntrada tr:nth-child(" + (myRow + 1) + ") td:nth-child(2)").html(Operacion.mask('hfidproducto').val());//Operacion.mask('txtidProducto').val());
                $("#MainContent_gvDetalleEntrada tr:nth-child(" + (myRow + 1) + ") td:nth-child(3)").html(Operacion.mask('hfdescripcion').val());//Operacion.mask('txtdescripcion').val());
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
            $("#btnGuardar").click(function () {
                Operacion.inputEstado('txtSerie', 1, true);
                Operacion.inputEstado('txtFechaL', 1, true);

                if (valida()) {
                    Operacion.inputEstado('btnGuardar', 1, false);
                    Operacion.iValida('txtCantidad', 1);//VALIDA ENTERO CANTIDAD
                    //(Operacion.mask('lblcodigoMovimiento').text() == "PR" ? Operacion.inputEstado('txtSerie', 0, true) : Operacion.inputEstado('txtSerie', 1, true));
                    Operacion.mask('lblcodigoMovimiento').text($('#MainContent_txtIDMOV').val());
                    correlativo(Operacion.mask('codAL').val(), CTD);//$('#MainContent_txtIDREF').val());
                    $('#detalleCabecera').dialog("open");
                    aa = 1;

                } else {
                    alert('Debe completar los campos');
                }
            });
            $('#btnFinalizar').click(function () {
                var cont = 0;
                var result = confirm('Desea finalizar la operacion');
                if (result) {
                    guardarCabecera();//NUEVO
                } else {//FIN DE CONFIRMACIÓN DE GUAR
                    /*var result2 = confirm('Desea realizar otro ingreso');
                    if (result2) {
                        window.location.href = '../ALMACEN/RegistroEntrada.aspx';
                    } else {
                        window.location.href = '../ALMACEN/ConsultaReimpresion.aspx';
                    }*/
                }
            });

            /*Autocomplete*/
            $(".tb1").autocomplete(
                {
                    source: function (request, response) {
                        $.ajax({
                            url: "RegistroEntrada.aspx/getMovimientos",
                            data: "{ datos: '" + request.term + "',tipo:'E'}",
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
                        Operacion.mask('lblFechaDocD').val(Operacion.mask('lblFechaE').text());
                        Operacion.mask('lbltipoRegistro').val(Operacion.mask('lblEntrada').text());
                        Operacion.mask('txtIDMOV').val(str);
                        Operacion.mask('codM').val(str);
                        Operacion.mask('lblcodigoMovimiento').text(Operacion.mask('txtIDMOV').val() + "-" + Operacion.mask('txtCodigoMov').val());//DETALLE CABECERA

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
                        Operacion.mask('txtIDREF').val(str);
                        Operacion.mask('codDR').val(str);
                        Operacion.mask('lblcodigoMovimiento').text(str);//cabecera detalle
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
                        Operacion.mask('txtTDRef2').val(str);
                        //$('#MainContent_codDR').val(str);
                    }
                });

            /*$(".tb3").autocomplete(
                {//CENTRO DE COSTO
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
                    },
                    change: function (event, ui) {
                        if (ui.item == null || ui.item == undefined) {
                            alert("No ha seleccionado un valor valido");
                            Operacion.mask('txtCentroCosto').focus();
                            Operacion.mask('txtCentroCosto').val('');
                        }
                    }
                });*/
            $(".tb4").autocomplete(
                {   /*PROVEEDORES*/
                    source: function (request, response) {
                        var TM = Operacion.mask('txtIDMOV').val();
                        var MOP = Operacion.mask('cb1').is(':checked');
                        //ACTUALIZO CONSULTA PROVEEDOR
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
                        $.ajax({
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
                        //onkeypress = "Operacion.MEKPAT(event,this);"
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
            var addComplete2 = function () {
                $(".tb40").autocomplete(
                {   /*BAHIAS*/
                    source: function (request, response) {
                        var BDATA = {};
                        BDATA.B_NOMBRES = '%' + request.term + '%';
                        $.ajax({
                            url: "RegistroEntrada.aspx/getBAHIA",
                            data: '{BDATA: ' + JSON.stringify(BDATA) + '}',
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            dataFilter: function (data) { return data; },
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        value: item.B_NOMBRES + " " + item.B_APELLIDOS,
                                        id: item.B_NOMBRES + " " + item.B_APELLIDOS,
                                        dni: item.ID.trim()
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
                        var str = ui.item.id, str1 = ui.item.dni;
                        Operacion.mask('txtOrdenTrabajo').val(str);
                        Operacion.mask('hfOT').val(str1);
                    },
                    change: function (event, ui) {
                        if (ui.item == null || ui.item == undefined) {
                            alert("No ha seleccionado un items valido para bahia/orden de trabajo");
                            Operacion.mask('txtOrdenTrabajo').focus();
                            Operacion.mask('txtOrdenTrabajo').val('');
                        }
                    }
                });
            }

            $(".tb41").autocomplete(
                {   /*getCliente:reemplazar CLIENTES - PROVEEDORES*/
                    source: function (request, response) {
                        var TM = Operacion.mask('txtIDMOV').val();
                        var ADATA = {};
                        ADATA.AVANEXO = "C";
                        ADATA.ADESANE = '%' + request.term + '%';
                        ADATA.ATIPTRA = (TM == "CO" ? "J" : (TM == "MP" ? "N" : null));
                        $.ajax({
                            //data: "{COD:'C',CAD: '" + request.term + "%" + "'}",
                            url: "RegistroEntrada.aspx/getClienteT",
                            data: '{ADATA:' + JSON.stringify(ADATA) + '}',
                            dataType: "json",
                            type: "POST",
                            /*timeout: 5000,*/
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
                                console.log(textStatus);
                            }
                        });
                    },
                    minLength: 1,
                    select: function (event, ui) {
                        var str = ui.item.id;
                        //alert(str);
                        Operacion.mask('txtIDCL').val(str);
                    }
                });
            $(".tb5").autocomplete(
                {/*busca codigo-propducto*/
                    //txtidProducto
                    source: function (request, response) {
                        $.ajax({
                            url: "RegistroEntrada.aspx/getProductoAS",
                            data: "{ dato: '" + "%" + request.term + "%" + "',TR:'E',AL:'" + Operacion.mask('codAL').val() + "'}",
                            //data: "{ 'dato': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            dataFilter: function (data) { return data; },
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    var codigo = item.AR_CCODIGO;
                                    return {
                                        value: codigo.trim(),
                                        //value: codigo.trim() + " " + item.AR_CDESCRI,
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
                        Operacion.mask('lblUnidad').text(str2);
                        Operacion.mask('hdfUnidad').val(str2);
                        //Operacion.mask('txtdescripcion').val(str1);
                        stockCOD(Operacion.mask('codAL').val(), str1, Operacion.mask('lblEntrada').text().trim());
                        (slt == "S" ? Operacion.inputEstado('txtSerie', 0, true) : Operacion.inputEstado('txtSerie', 1, true));
                        (slt == "S" ? Operacion.inputEstado('txtFechaL', 0, true) : Operacion.inputEstado('txtFechaL', 1, true));
                        $('#btnagregarItem').removeAttr("disabled");
                    },
                    change: function (event, ui) {
                        if (ui.item == null || ui.item == undefined) {
                            Operacion.mask('txtidProducto').val('');
                            Operacion.mask('txtdescripcion').val('');
                            Operacion.mask('lblUnidad').text('');
                            Operacion.mask('hdfUnidad').val('');
                            Operacion.mask('txtCantidad').val('');
                            Operacion.mask('lblSTOCK').val('');
                            Operacion.mask('txtdescripcion').focus();
                            alert("No ha seleccionado El producto");
                        }
                    }

                });/**/
            $(".tb6").autocomplete(
                {/*busca producto-codigo*/
                    //txtdescripcion||modificado value:C+D
                    source: function (request, response) {
                        //console.log(miconsulta);
                        $.ajax({
                            url: "RegistroEntrada.aspx/" + miconsulta,
                            data: "{ dato: '" + "%" + request.term + "%" + "',TR:'E',AL:'" + Operacion.mask('codAL').val() + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            dataFilter: function (data) { return data; },
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        //value: item.AR_CDESCRI,
                                        value: item.AR_CCODIGO.trim() + " " + item.AR_CDESCRI,
                                        ds: item.AR_CDESCRI,
                                        id: item.AR_CCODIGO.trim(),
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
                        var str = ui.item.id;
                        var str1 = ui.item.un;
                        var slt = ui.item.lt; var ser = ui.item.sr;
                        stockCOD(Operacion.mask('codAL').val(), str, Operacion.mask('lblEntrada').text().trim());
                        Operacion.mask('hfidproducto').val(str);//ID PRODUCTO
                        Operacion.mask('hfdescripcion').val(ui.item.ds);//DES PRODUCTO
                        Operacion.mask('lblUnidad').text(str1);
                        Operacion.mask('hdfUnidad').val(str1);
                        (slt == "S" ? Operacion.inputEstado('txtSerie', 0, true) : Operacion.inputEstado('txtSerie', 1, true));//SI ESTA HABILITADO PARA SERIE
                        (slt == "S" ? Operacion.inputEstado('txtFechaL', 0, true) : Operacion.inputEstado('txtFechaL', 1, true));//SI ESTA HABILITADO PARA LOTE
                        (bandera == true ? $('#btnagregarItem').removeAttr("disabled") : "");
                    },
                    change: function (event, ui) {
                        if (ui.item == null || ui.item == undefined) {
                            //Operacion.mask('txtidProducto').val('');
                            Operacion.mask('txtdescripcion').val('');
                            Operacion.mask('lblUnidad').text('');
                            Operacion.mask('hfidproducto').val('');
                            Operacion.mask('hfdescripcion').val('');
                            Operacion.mask('hdfUnidad').val('');
                            Operacion.mask('txtCantidad').val('');
                            Operacion.mask('lblSTOCK').val('');
                            Operacion.mask('txtdescripcion').focus();
                            alert("No ha seleccionado El producto");
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
                        //Operacion.mask('lblSCantidad').text(parseFloat(str).toFixed(2)); // CANTIDAD LOTE
                    }
                });
            var addComplete1 = function () {
                $(".ace").autocomplete(
                {/*EMBARCACIONES*/
                    source: function (request, response) {
                        //var EDATA = {};
                        //EDATA.E_NOMBRE = "%" + request.term + "%";

                        var AL = Operacion.mask('codAL').val();
                        M_EB = (MARRAY[0] == AL || MARRAY[1] == AL ? "getBAR" : "getEMB");
                        //console.log(M_EB);
                        if (M_EB == "getEMB") {
                            var EDATA = {};
                            EDATA.E_NOMBRE = "%" + request.term + "%";
                        } else {
                            var EDATA = {};
                            EDATA.AF_COD = "BA";
                            EDATA.AF_TDESCRI2 = "%" + request.term + "%";
                            //console.log(EDATA);
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
                                            id: item.E_MATRIC,
                                            cb: item.E_CABOM3
                                        }
                                    } else {
                                        return {
                                            value: item.AF_TDESCRI2 + " " + item.AF_TDESCRI3,
                                            id: item.AF_TDESCRI1,
                                            cb: item.AF_CUSUCRE
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
                        var str = ui.item.value, str1 = ui.item.id; str2 = ui.item.cb;
                        Operacion.mask('txtGlosa1').val(str);
                        Operacion.mask('hfG1').val(str1);
                        Operacion.mask('txtGlosa2').focus();
                        Operacion.mask('lblCBO').text("CAP. BODEGA:" + Number(str2).toFixed(2) + " TM MAXIMO:" + Number(Number(str2) * 0.70).toFixed(2));//CAPACIDAD BODEGA
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
                    Operacion.mask('hfidproducto').val(),//REEMPLAZAR
                    Operacion.mask('hfdescripcion').val(),//REEMPLAZAR
                    Operacion.mask('hdfUnidad').val(),
                    (Operacion.mask('txtCentroCosto').val() != "" ? Operacion.mask('txtCentroCosto').val() : Operacion.mask('txtOrdenTrabajo').val()),
                    Operacion.mask('txtSerie').val(),
                    Operacion.mask('txtFechaL').val(),
                    Operacion.mask('txtCantidad').val(),
                ];
                //ITEM, CODIGO, PRODUCTO, UNID, FECHA, CANTIDAD
                var aux; var a = parseInt("10000000");
                jQuery.each(OBJ, function (i, val) {
                    $("td", rowt).eq(i).html((val == "*" ? cont1 : val));
                    //}
                });

                $("[id*=gvDetalleEntrada]").append(rowt);
                rowt = $("[id*=gvDetalleEntrada] tr:last-child").clone(true);
                limpiarIngresos();
            }

            function actualizaStock(codigo, cantidad) {
                if (cantidad != null) {
                    var CANTFINAL = Number(cantidad);//Number(AUXCANT) + Number(cantidad);
                    var DATAI = {};
                    DATAI.SK_CALMA = Operacion.mask('codAL').val();
                    DATAI.SK_CCODIGO = codigo;
                    DATAI.SK_NSKDIS = CANTFINAL;

                    $.ajax({
                        type: "POST",
                        url: "RegistroEntrada.aspx/actualizaStock",
                        data: '{DATAI:' + JSON.stringify(DATAI) + ',OP:1}',
                        contentType: "application/json;charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (response) {
                            //window.location.href = '../ALMACEN/RegistroEntrada.aspx';
                        },
                        error: function (response) {
                            console.log(response);
                        }
                    });
                }
            }

            function guardarCabecera() {
                var XA = Operacion.mask('codAL').val();
                var XM = Operacion.mask('txtIDMOV').val();
                var XOT = Operacion.mask('hfOT').val();
                var OT = (XOT != "-1" ? XOT : Operacion.mask('txtOrdenTrabajo').val());//hfOT
                fecha = moment(Operacion.mask('lblFechaDocD').text(), 'DD-MM-YYYY hh:mm:ss');
                var VARO = ((XA == "A002" || XA == "A004" || XA == "0004" || XA == "0015") && (XM == "CO" || XM == "MP" || XM == "CX") ? Operacion.mask('ddlOrigen').val() : (Operacion.mask('txtNroDocumento2').val() != "" ? Operacion.mask('txtNroDocumento2').val() : ""));
                //(AL == "A002" || AL == "A004" || AL == "0004" || AL == "0015")
                fechac = moment();
                var DATA = {};
                var numDoc = "";
                var M_SOL = Operacion.mask('txtSolicitante').val();

                DATA.C5_CALMA = Operacion.mask('codAL').val();//Session["aID"].ToString(), //REEMPLAZAR
                DATA.C5_CTD = "PE"//$('#MainContent_txtIDREF').val().trim();//CODIGO MOVIMIENTO:EP
                DATA.C5_CNUMDOC = idCod;//NUMERO DE DOCUMENTO VENTA FINAL
                DATA.C5_CLOCALI = "0001";
                DATA.C5_DFECDOC = fecha;//Convert.ToDateTime(lblFechaE.Text),
                DATA.C5_DFECVEN = null;
                DATA.C5_CTIPMOV = "E";//$('#MainContent_lblEntrada').val();
                DATA.C5_CCODMOV = XM;
                DATA.C5_CSITUA = "";//V
                DATA.C5_CRFTDOC = (Operacion.mask('txtIDREF').val() != " " ? Operacion.mask('txtIDREF').val().trim() : "");//FT,LQ,RQ
                DATA.C5_CRFNDOC = (Operacion.mask('txtNroDocumento1').val() != " " ? Operacion.mask('txtNroDocumento1').val() : "-");
                DATA.C5_CSOLI = (M_SOL != "" ? M_SOL : "");
                DATA.C5_CCENCOS = (Operacion.mask('txtCentroCosto').val() != "" ? Operacion.mask('txtCentroCosto').val() : "");
                DATA.C5_CRFALMA = (Operacion.mask('ddlAlmacenRef').val() == "-1" ? "" : Operacion.mask('ddlAlmacenRef').val());//0101
                DATA.C5_CGLOSA1 = (Operacion.mask('hfG1').val() != "-1" ? Operacion.mask('hfG1').val().trim() : Operacion.mask('txtGlosa1').val());
                DATA.C5_CGLOSA2 = (Operacion.mask('txtGlosa2').val() != "" ? Operacion.mask('txtGlosa2').val() : "");
                DATA.C5_CGLOSA3 = (Operacion.mask('txtGlosa3').val() != "" ? Operacion.mask('txtGlosa3').val() : "");
                DATA.C5_CTIPANE = "";
                DATA.C5_CCODANE = "";
                DATA.C5_DFECCRE = fechac;//REEMPLAZAR
                DATA.C5_CUSUCRE = Operacion.mask('hdUSUARIO').val();//$("#MainContent_hfusuario").val();//Session["codusu"].ToString(),
                DATA.C5_DFECMOD = null;
                DATA.C5_CUSUMOD = "";
                DATA.C5_CCODCLI = Operacion.mask('txtIDCL').val();
                DATA.C5_CNOMCLI = Operacion.mask('txtCliente').val();
                DATA.C5_CRUC = "";
                DATA.C5_CCODCAD = "";
                DATA.C5_CCODINT = "";
                DATA.C5_CCODTRA = "";
                DATA.C5_CNOMTRA = "";
                DATA.C5_CCODVEH = "";//REL. GLOSA1 MP CH-MATRICULA
                DATA.C5_CTIPGUI = "";//3
                DATA.C5_CSITGUI = "";//F,A,V
                DATA.C5_CGUIFAC = "";//N,S(AL == "A002" || AL == "A004" || AL == "0004" || AL=="0015")
                DATA.C5_CDESTIN = ((XA == "A002" || XA == "A004" || XA == "0004" || XA == "0015") && (XM == "CO" || XM == "MP" || XM == "CX") ? Operacion.mask('ddlDepa').val().trim() : "");//MAX:4 
                DATA.C5_CDIRENV = "";
                DATA.C5_CNUMORD = "";//DER //(Operacion.mask('txtOrdenTrabajo').val() != "" ? Operacion.mask('txtOrdenTrabajo').val() : "");
                DATA.C5_CTIPORD = "";
                DATA.C5_CGUIDEV = "";
                DATA.C5_CCODPRO = Operacion.mask('lblProveedor').text().trim();
                DATA.C5_CNOMPRO = Operacion.mask('txtProveedor').val();
                DATA.C5_CCIAS = (Operacion.mask('txtOrdenCompra').val() != "" ? Operacion.mask('txtOrdenCompra').val() : "");
                DATA.C5_CFORVEN = "";//006,007,014
                DATA.C5_CCODMON = "";//(Operacion.mask('ddlMoneda').val() == "-1" ? "" : Operacion.mask('ddlMoneda').val().trim());
                DATA.C5_CVENDE = "";//BROKER
                DATA.C5_NTIPCAM = 0;//Convert.ToDecimal(ddlTipoCambio.SelectedValue.Trim()),
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
                DATA.C5_CRFNDO2 = VARO;
                DATA.C5_CNUMLIQ = "";
                DATA.C5_CORDEN = (Operacion.mask('hfOT').val() != "-1" ? Operacion.mask('hfOT').val() : Operacion.mask('txtOrdenTrabajo').val());
                DATA.C5_CTIPOGS = "";//N
                DATA.C5_DFECANU = null;
                DATA.C5_CCODFER = (Operacion.mask('txtNT').val() != "" ? Operacion.mask('txtNT').val() : "");//NUMERO TICKET PESAJE
                DATA.C5_DFECEMB = null;
                DATA.C5_CGLOSA4 = Operacion.mask('txtGlosa4').val().trim();//DER
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
                DATA.C5_CLICCON = "";//NUEVO 15.07.16
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

                //console.log(DATA);
                $.ajax({
                    type: "POST",
                    url: "RegistroEntrada.aspx/guardarCabecera",
                    data: '{DATA:' + JSON.stringify(DATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async:false,
                    success: function (response) {
                        guardarRegistroDetalle();
                    },
                    error: function (response) {
                        console.table(response);
                    }
                });
            }

            function guardardetalleCabecera(IT, COD, DES, CANT) {
                //stockCOD($('#MainContent_codAL').val(), COD);
                var fechaDC = moment(Operacion.mask('lblFechaDocD').text(), 'DD-MM-YYYY 00:00:00.000');
                var DATAD = {};
                var LDES = DES;
                var NDES = (typeof LDES == 'undefined' ? "" : LDES.substring(0, 50));
                //txtalcanceDia
                DATAD.C6_CALMA = Operacion.mask('codAL').val();
                DATAD.C6_CTD = "PE";//$('#MainContent_txtIDREF').val().trim();
                DATAD.C6_CNUMDOC = Operacion.mask('txtNumeroDoc').val();
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
                DATAD.C6_CSITUA = "";
                DATAD.C6_DFECDOC = fechaDC;
                DATAD.C6_DFECVEN = null;
                DATAD.C6_DFECENT = null;
                DATAD.C6_CRFALMA = "";
                DATAD.C6_CTALLA = "";
                DATAD.C6_CESTADO = "";
                DATAD.C6_CCODMOV = Operacion.mask('codM').val();// EP/CO/SP
                DATAD.C6_CORDEN = (Operacion.mask('hfOT').val() != "-1" ? Operacion.mask('hfOT').val() : Operacion.mask('txtOrdenTrabajo').val());
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
                        //alert('ga');
                        actualizaStock(COD, CANT);
                        //window.location.href = '../ALMACEN/RegistroEntrada.aspx';
                    },
                    error: function (response) {
                        console.table(response);
                    }
                });

            }
            function guardarRegistroDetalle(){
                var AL = Operacion.mask('codAL').val();
                    var TD = "PE";
                    var ND = Operacion.mask('txtNumeroDoc').val();
                    gitem = "";
                    var MOVID = Operacion.mask('txtIDMOV').val();
                    var MISER = Operacion.mask('txtSerie').is(':disabled');
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
                        
                        guardardetalleCabecera(pad(t, 4), gitem01, gitem02, gitem04);
                        //ACTUALIZA SERIE / LOTE
                        (MOVID == "PR" || MOVID == "CO" && MISER != true ? actualizaSerieS(AL, gitem01, gitem03, gitem04) : "");
                        (MOVID == "PR" || MOVID == "CO" && MISER != true ? insertaALSE(AL, pad(gitem00, 4), gitem01, gitem03, gitem04) : "");
                    }
                    $('#btnGuardar').attr('disabled', true);
                    $('#btnagregarItem').attr('disabled', true);
                    $('#btnFinalizar').attr('disabled', true);
                    
                    Operacion.mask('txtdescripcion').attr('disabled', true);
                    Operacion.mask('txtCantidad').attr('disabled', true);
                    var auxi = confirm("Documento generado Número " + AL + " " + CTD + "-" + Operacion.mask('txtNumeroDoc').val());
                    if (auxi) {
                        window.location.href = '../ALMACEN/ConsultaReimpresion.aspx';
                        javascript: window.close;
                        /*if (confirm('Desea imprimir el documento')) {
                            if (AL == "0001") {
                                window.open("../ALMACEN/Reportes/ReporteFinaliza.aspx?AL=" + AL + "&TD=" + TD + "&ND=" + ND, '_blank');
                                window.location.href = '../ALMACEN/ConsultaReimpresion.aspx';
                            } else {
                                window.open("../ALMACEN/Reportes/Reporte.aspx?AL=" + AL + "&TD=" + TD + "&ND=" + ND, '_blank');
                                window.location.href = '../ALMACEN/ConsultaReimpresion.aspx';
                            }
                        } else {
                            window.location.href = '../ALMACEN/ConsultaReimpresion.aspx';
                        }
                        */
                    }
            }
        });
    </script>
    <style type="text/css">
        /**/
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
            <legend>Registro de Entrada</legend>
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
                    <td>Entrada</td>
                    <td>
                        <asp:Label ID="lblEntrada" runat="server" Text=""></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Codigo Movimiento</td>
                    <td>
                        <asp:TextBox ID="txtIDMOV" runat="server" TabIndex="0" Width="35px"></asp:TextBox>
                        <!--<asp:Label ID="lblCodigoM" runat="server" Text=""></asp:Label>-->
                        <asp:TextBox ID="txtCodigoMov" Width="280px" runat="server" class="tb1"></asp:TextBox>
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
                    <td rowspan="2">
                        <asp:RadioButton ID="RadioButton1" runat="server" Text="Compra" />
                        <br />
                        <asp:RadioButton ID="RadioButton2" runat="server" Text="Venta" />
                    </td>
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
                        <asp:DropDownList ID="ddlTipoCambio" runat="server">
                        </asp:DropDownList>
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
                        <asp:TextBox ID="txtProveedor" class="tb4" Width="394px" TabIndex="1" runat="server" onkeypress="Operacion.MEKPAT(event,this)"></asp:TextBox>
                        <asp:CheckBox ID="cb1" Text="Exterior" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblTDR1" runat="server" Text="Tipo Documento Referencia 1"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtIDREF" runat="server" TabIndex="2" Width="38px"></asp:TextBox>
                        <!--<asp:Label ID="lblTDRef1" runat="server" Text=""></asp:Label>-->
                        <asp:TextBox ID="txtTipoDocumentoRef1" class="tb2" runat="server" Height="19px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblND1" runat="server" Text="Nro Documento 1"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtNroDocumento1" runat="server" TabIndex="3" onkeypress="Operacion.MEKPAT(event,this)"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblTDR2" runat="server" Text="Tipo Documento Referencia 2"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtTDRef2" runat="server" TabIndex="4" Width="38px"></asp:TextBox>
                        <!--<asp:Label ID="lblTDRef2" runat="server" Text=""></asp:Label>-->
                        <asp:TextBox ID="txtTipoDocumentoRef2" runat="server" class="tb21"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblND2" runat="server" Text=""></asp:Label><br />
                        <asp:Label ID="lblND3" runat="server" Text="Nro Documento 2"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNroDocumento2" runat="server" TabIndex="5" onkeypress="Operacion.MEKPAT(event,this)"></asp:TextBox>
                        <asp:DropDownList ID="ddlDepa" runat="server" onkeypress="Operacion.MEKPAT(event,this)"></asp:DropDownList>
                        <br />
                        <asp:DropDownList ID="ddlOrigen" runat="server" TabIndex="6" onkeypress="Operacion.MEKPAT(event,this)"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblOC" runat="server" Text="Orden de Compra"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtOrdenCompra" runat="server" TabIndex="6" Width="46px" onkeypress="Operacion.MEKPAT(event,this)"></asp:TextBox>
                        <asp:TextBox ID="txtOrdenCompraD" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblNT" runat="server" Text="Nro. Ticket Pesaje"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNT" TabIndex="7" runat="server" onkeypress="Operacion.MEKPAT(event,this)"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblOT" runat="server" Text="Orden de Trabajo"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtOrdenTrabajo" TabIndex="8" class="tb40" runat="server" onkeypress="Operacion.MEKPAT(event,this)"></asp:TextBox>
                        <asp:HiddenField ID="hfOT" runat="server" />
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSOL" runat="server" Text="Solicitante"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtSolicitante" TabIndex="9" runat="server" Width="47px"></asp:TextBox>
                        <asp:Label ID="lblSolicitante" runat="server" Text=""></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCENCO" runat="server" Text="Centro de Costo"></asp:Label></td>
                    <td colspan="3">
                        <asp:TextBox ID="txtCentroCosto" Width="84px" TabIndex="10" runat="server"></asp:TextBox>
                        <asp:TextBox ID="txtDetalleCC" runat="server" Width="343px"></asp:TextBox>
                        <!--class="tb3":centro costo-->
                        <!--<asp:Label ID="lblDetalleCC" runat="server" Text=""></asp:Label>-->
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblG1" runat="server" Text="Glosa 1"></asp:Label></td>
                    <td colspan="3">
                        <asp:TextBox ID="txtGlosa1" TabIndex="11" class="ace" runat="server" Width="305px" onkeypress="Operacion.MEKPAT(event,this)"></asp:TextBox>
                        <!--<asp:TextBox ID="txtAG1" class="ace" placeholder="Nombre de la embarcacion" runat="server" Width="243px"></asp:TextBox>-->
                        <asp:HiddenField ID="hfG1" runat="server" />
                        <asp:Label ID="lblCBO" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblG2" runat="server" Text="Glosa 2"></asp:Label></td>
                    <td colspan="2">
                        <asp:TextBox ID="txtGlosa2" TabIndex="12" runat="server" Width="305px" onkeypress="Operacion.MEKPAT(event,this)"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblG3" runat="server" Text="Glosa 3"></asp:Label></td>
                    <td colspan="2">
                        <asp:TextBox ID="txtGlosa3" MaxLength="27" TabIndex="13" runat="server" Width="305px" onkeypress="Operacion.MEKPAT(event,this)"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblG4" runat="server" Text="Glosa 4"></asp:Label></td>
                    <td colspan="2">
                        <asp:TextBox ID="txtGlosa4" TabIndex="14" runat="server" Width="305px" onkeypress="Operacion.MEKPAT(event,this)"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblAR" runat="server" Text="Almacen de Referencia"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddlAlmacenRef" TabIndex="15" runat="server" onkeypress="Operacion.MEKPAT(event,this)">
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
                        <asp:TextBox ID="txtCliente" class="tb41" runat="server" TabIndex="16" onkeypress="Operacion.MEKPAT(event,this)"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCA" runat="server" Text="Tipo/Codigo Anexo"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddlAnexo" TabIndex="17" runat="server">
                        </asp:DropDownList>
                        <asp:TextBox ID="txtAnexoDetalle" TabIndex="18" runat="server" onkeypress="Operacion.MEKPAT(event,this)"></asp:TextBox>
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
                    <td>
                        <input id="btnGuardar" class="btn" type="button" tabindex="25" value="Guardar" /></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </fieldset>
        <div id="detalleCabecera" title="Detalle de Entrada">
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
                </tr>
                <tr>
                    <td class="auto-style1">Producto&nbsp;</td>
                    <td colspan="3">
                        <!--<asp:TextBox ID="txtidProducto" class="tb5" placeholder="CODIGO" runat="server"></asp:TextBox>-->
                        <asp:TextBox ID="txtdescripcion" class="tb6" placeholder="DESCRIPCION" runat="server" Width="452px"></asp:TextBox>
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
                        <!--tb61:complete-->
                        <!--<asp:Label ID="lblSL" runat="server" Text="Stock Lote:"></asp:Label>-->
                        <!--<asp:Label ID="lblSCantidad" runat="server" Text=""></asp:Label>-->
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">Fecha Lote</td>
                    <td>
                        <asp:TextBox ID="txtFechaL" class="dpFecha2" placeholder="00/00/0000" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">Cantidad</td>
                    <td>
                        <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;Stock Actual (TM):<asp:Label ID="lblSTOCK" runat="server" Text=""></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>Total Unid.</td>
                    <td>
                        <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <!--<asp:Button ID="btnagregarItem" runat="server" Text="Agregar"/>-->
                        <input id="btnagregarItem" class="btn" type="button" value="Agregar" />
                        <input id="btnActualizar" class="btn" type="button" value="Modificar" /></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="gvDetalleEntrada" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="ITEM" HeaderText="ITEM" ItemStyle-HorizontalAlign="Right">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="50" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>

                                <asp:BoundField DataField="C6_CCODIGO" HeaderText="Codigo" ItemStyle-HorizontalAlign="center">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="C6_CDESCRI" HeaderText="Descripcion" ItemStyle-HorizontalAlign="left">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="LEFT" Width="150" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AR_CUNIDAD" HeaderText="Unidad" ItemStyle-HorizontalAlign="right">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="50" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="C6_CCENCOS" HeaderText="Centro de Costo" ItemStyle-HorizontalAlign="center">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="C6_CSERIE" HeaderText="Serie" ItemStyle-HorizontalAlign="center">
                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                    <ItemStyle Font-Size="8pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="C6_CFECDOC" HeaderText="Fecha" ItemStyle-HorizontalAlign="center">
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
                    <td></td>
                    <td>
                        <!--<asp:Button ID="btnFinalizar" runat="server" Text="Finalizar"/>-->
                        <input id="btnFinalizar" class="btn" type="button" value="Finalizar" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="serie" title="Series Disponibles" style="display: none;">
            <asp:Label ID="lblfiltro" runat="server" Text="Lote/Serie"></asp:Label><input id="texto" type="text" name="texto" />
            <asp:GridView ID="gvSerie" class="filtrar" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False">

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
                                <img alt="" src="../Images/unchecked.png" width="25" style="cursor: pointer" />
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
    <br />
</asp:Content>