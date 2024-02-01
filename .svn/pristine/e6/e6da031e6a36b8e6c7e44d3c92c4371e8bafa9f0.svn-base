<%@ Page Title="Modificación de Cabecera" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ModificacionCabecera.aspx.cs" Inherits="ModificacionCabecera" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link type="text/css" href="../CSS/base.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {
            UHTML.id = 'MainContent';
            $(".dpFecha1").datepicker();
            $("#btnGuardar").attr('disabled', true);
            $.urlParam = function (name) {
                var results = new RegExp('[\?&]' + name + '=([^&#]*)').exec(window.location.href);
                return (results != null ? results[1] || 0 : "");
            }
            if ($.urlParam('PE') == "S") {
                //$('#MainContent_ddlesM').val('S');
                comboNuevo();
            }
            
            //Operacion.inputEstado($('#MainContent_txtMNumeroDoc'), 0);
            Operacion.inputEstado('txtMIDMOV', 1,true);
            Operacion.inputEstado('txtMfechaE', 1,true);
            Operacion.inputEstado('txtMguiaF', 1,true);
            Operacion.inputEstado('txtMIDCL', 1,true);
            Operacion.inputEstado('txtMCODPRO', 1,true);
            Operacion.inputEstado('txtMtdr', 1,true);
            Operacion.inputEstado('txtMnroDocumento1', 1,true);
            Operacion.inputEstado('txtTDRef2', 1,true);
            Operacion.inputEstado('txtMnroDocumento2', 1,true);
            Operacion.inputEstado('txtMordenCompra', 1,true);
            Operacion.inputEstado('txtCentroCosto', 1,true);
            Operacion.inputEstado('txtSolicitante', 1,true);
            Operacion.inputEstado('ddlMalmacenRef', 1,true);
            Operacion.inputEstado('txtOrdenTrabajo', 1,true);
            Operacion.inputEstado('ddlManexo', 1,true);
            Operacion.inputEstado('txtManexoDetalle', 1,true);
            Operacion.inputEstado('txtMglosa1', 1,true);
            Operacion.inputEstado('txtMglosa2', 1,true);
            Operacion.inputEstado('txtMglosa3', 1,true);
            Operacion.inputEstado('txttransCod', 1,true);
            Operacion.inputEstado('txtcodigoVeh', 1,true);
            Operacion.inputEstado('txtdireccionE', 1,true);

            //obtiene get
            //if ($.urlParam('PE')!="0" && $.urlParam('TD')!=0 && $.urlParam('AL')!=0 && $.urlParam('ND')!=0) {
                $('#MainContent_ddlesM').val($.urlParam('PE'));
                $('#MainContent_ddlTipoMov').val($.urlParam('TD'));
                $('#MainContent_ddlMalmacen').val($.urlParam('AL'));
                $('#MainContent_txtMNumeroDoc').val($.urlParam('ND'));
            //}
            if ($('#MainContent_txtMNumeroDoc').val()!="") {
                cargar();
                Operacion.inputEstado('btnGuardar',0,false);
            }

            $('#MainContent_ddlesM').change(function () {
                comboNuevo();                
            });

            if ($('#MainContent_ddlesM').val()) {
                //MainContent_ddlTipoMov
                comboNuevo();
            }
            

            $('#MainContent_txtMIDMOV').change(function () {
                buscaContenido(1);
            });
            $('#MainContent_txtMtdr').change(function () {
                buscaContenido(2);
            });
            $('#MainContent_txtCentroCosto').change(function () {
                buscaContenido(3);
            });
            $('#MainContent_txtTDRef2').change(function () {
                buscaContenido(4);
            });
            $('#MainContent_txtMCODPRO').change(function () {
                buscaContenido(5);
            });


            function buscaContenido(op) {
                switch (op) {
                    case 1:
                        $.ajax({
                            type: "POST",
                            url: "ModificacionCabecera.aspx/getLISTAMOVID",
                            data: "{ datos: '" + $('#MainContent_txtMIDMOV').val() + "',tipo:'" + $('#MainContent_ddlesM').val() + "'}",
                            contentType: "application/json;charset=utf-8",
                            dataType: "json",
                            success: function (data) {
                                if (data.d.length > 0) {
                                    jQuery.each(data.d, function (i, val) {
                                        $('#MainContent_lblMCodigoMov').text(val['TM_CDESCRI']);
                                    });
                                }else{
                                    $('#MainContent_lblMCodigoMov').text("");
                                }
                            }
                        });
                        break;
                    case 2:
                        $.ajax({
                            type: "POST",
                            url: "ModificacionCabecera.aspx/getLISTATD",
                            data: "{ dato: '" + $('#MainContent_txtMtdr').val() + "', codigo:'04' }",
                            contentType: "application/json;charset=utf-8",
                            dataType: "json",
                            success: function (data) {
                                if (data.d.length > 0) {
                                    jQuery.each(data.d, function (i, val) {
                                        $('#MainContent_lblMdtdr').text(val['TG_CDESCRI']);
                                    });
                                } else {
                                    $('#MainContent_lblMdtdr').text("");
                                }
                            }
                        });
                        break;
                    case 3:
                        var variable = $('#MainContent_txtCentroCosto').val();
                        //alert(variable.trim());
                        $.ajax({
                            url: "ModificacionCabecera.aspx/getLISTATD",
                            data: "{ 'dato': '" + variable.trim() + "', codigo:'10'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            dataFilter: function (data) { return data; },
                            success: function (data) {
                                if (data.d.length > 0) {
                                    jQuery.each(data.d, function (i, val) {
                                        $('#MainContent_lblDetalleCC').text(val['TG_CDESCRI']);
                                    });
                                }else {
                                    $('#MainContent_lblDetalleCC').text("");
                                }
                            }
                        });
                        break;
                    case 4:
                        $.ajax({
                            type: "POST",
                            url: "ModificacionCabecera.aspx/getLISTATD",
                            data: "{ dato: '" + $('#MainContent_txtTDRef2').val() + "', codigo:'04' }",
                            contentType: "application/json;charset=utf-8",
                            dataType: "json",
                            success: function (data) {
                                if (data.d.length > 0) {
                                    jQuery.each(data.d, function (i, val) {
                                    
                                            $('#MainContent_lblMTipoDocumentoRef2').text(val['TG_CDESCRI']);                                    
                                    });
                                } else {
                                    $('#MainContent_lblMTipoDocumentoRef2').text("");
                                }
                            }
                        }); break;
                    case 5://MainContent_txtMCODPRO
                        /*$.ajax({
                            type: "POST",
                            url: "RegistroEntrada.aspx/getClienteT",
                            data: "{COD:'P',CAD: '" + $(this).val() + "'}",
                            contentType: "application/json;charset=utf-8",
                            dataType: "json",
                            success: function (data) {
                                console.log(data);
                                jQuery.each(data.d, function (i, val) {
                                    $('#MainContent_lblMproveedor').text(val['CL_CNOMCLI']);
                                });
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                alert(textStatus);
                            }
                        });*/
                        break;
                }
            }
            function comboNuevo() {
                
                $("#combo").html("");
                if ($('#MainContent_ddlesM').val() == "S") {
                    $("#combo").append("<select id='MainContent_ddlTipoMov' name='ctl00$MainContent$ddlTipoMov'><option value='PS' selected>PS - Parte de Salida</option><option value='GS'>GS - Guia de Salida</option></select>");
                    $('#MainContent_ddlTipoMov').val($.urlParam('TD'));
                } else {
                    $("#combo").append("<select id='MainContent_ddlTipoMov' name='ctl00$MainContent$ddlTipoMov'><option value='PS' selected>PE - Parte de Entrada</option></select>");
                }

            }
            $(".ac").autocomplete(
                {
                    source: function (request, response) {
                        $.ajax({
                            url: "ModificacionCabecera.aspx/getNRODOCUMENTO",
                            data: "{ ND: '" + request.term + "', ES:'" + $('#MainContent_ddlesM').val() + "',TD:'" + $('#MainContent_ddlTipoMov').val() + "',AL:'" + $('#MainContent_ddlMalmacen').val() + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            dataFilter: function (data) { return data; },
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        value: item.C5_CNUMDOC,
                                        id: item.C5_CNUMDOC
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
                        Operacion.inputEstado('btnGuardar',0,false);
                        //$("#btnGuardar").removeAttr('disabled');
                        //$('#MainContent_lblcodigoMovimiento').val();//cabecera detalle
                        obtieneDatos($('#MainContent_txtMNumeroDoc').val(), $('#MainContent_ddlesM').val(), $('#MainContent_ddlTipoMov').val(), $('#MainContent_ddlMalmacen').val());
                                                
                    }
                });
            $(".tb3").autocomplete(
                {
                    source: function (request, response) {
                        $.ajax({
                            url: "RegistroEntrada.aspx/getCliente",
                            data: "{COD:'C',CAD: '" + request.term + "%" + "'}",
                            //data: "{COD:'P',CAD: '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            dataFilter: function (data) { return data; },
                            success: function (data) {

                                response($.map(data.d, function (item) {
                                    return {
                                        value: item.ACODANE.trim(),
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
                        Operacion.mask('lblMCliente').text(str);
                    }
                });
            $(".tb4").autocomplete(
                {   
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
                        Operacion.mask('lblMproveedor').text(str);
                    }
                });
            

            function cargar() {
                obtieneDatos($('#MainContent_txtMNumeroDoc').val(), $('#MainContent_ddlesM').val(), $('#MainContent_ddlTipoMov').val(), $('#MainContent_ddlMalmacen').val());
            }

            function obtieneDatos(ND, ES, TD, AL) {
                $.ajax({
                    type: "POST",
                    url: "ModificacionCabecera.aspx/getNRODOCUMENTO",
                    data: "{ ND: '" + ND + "', ES:'" + ES + "',TD:'" + TD + "',AL:'" + AL + "'}",
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        jQuery.each(data.d, function (i, val) {
                            //console.log(val);
                            $('#MainContent_codAL').val(val['C5_CALMA']);//AL
                            $('#MainContent_codM').val(val['C5_CTD']);//TM PE
                            $('#MainContent_codDR').val(val['C5_CNUMDOC']);//NUMDOC
                            $('#MainContent_codCC').val(val['C5_CTIPOV']);//E

                            var dfecha = moment(val['C5_DFECDOC']).format('DD/MM/YYYY');
                            //MainContent_txtTDRef2
                            $('#MainContent_txtMIDMOV').val(val['C5_CCODMOV']);
                            $('#MainContent_txtMfechaE').val(dfecha);
                            $('#MainContent_txtMIDCL').val(val['C5_CCODCLI']);
                            $('#MainContent_lblMCliente').text(val['C5_CNOMCLI']);
                            $('#MainContent_txtMCODPRO').val(val['C5_CCODPRO']);
                            $('#MainContent_lblMproveedor').text(val['C5_CNOMPRO']);
                            $('#MainContent_txtMtdr').val(val['C5_CRFTDOC']);//val['C5_CTD']);
                            $('#MainContent_txtTDRef2').val(val['C5_CRFTDO2']);
                            $('#MainContent_txtMnroDocumento1').val(val['C5_CRFNDOC']);
                            $('#MainContent_txtMnroDocumento2').val(val['C5_CRFNDO2']);
                            $('#MainContent_txtCentroCosto').val(val['C5_CCENCOS']);
                            $('#MainContent_txtOrdenTrabajo').val(val['C5_CORDEN']);
                            $('#MainContent_txtMglosa1').val(val['C5_CGLOSA1']);
                            $('#MainContent_txtMglosa2').val(val['C5_CGLOSA2']);
                            $('#MainContent_txtMglosa3').val(val['C5_CGLOSA3']);
                            //console.log(val['C5_CRFTDO2']);
                            /*$('#MainContent_txtdescripcion1').val(val['AR_CDESCRI']);
                            $('#MainContent_txtdescripcion1').val(val['AR_CDESCRI']);
                            $('#MainContent_txtdescripcion1').val(val['AR_CDESCRI']);
                            $('#MainContent_txtdescripcion1').val(val['AR_CDESCRI']);
                            $('#MainContent_txtdescripcion1').val(val['AR_CDESCRI']);
                            $('#MainContent_txtdescripcion1').val(val['AR_CDESCRI']);
                            $('#MainContent_txtdescripcion1').val(val['AR_CDESCRI']);
                            $('#MainContent_txtdescripcion1').val(val['AR_CDESCRI']);
                            $('#MainContent_txtdescripcion1').val(val['AR_CDESCRI']);
                            $('#MainContent_txtdescripcion1').val(val['AR_CDESCRI']);
                            $('#MainContent_txtdescripcion1').val(val['AR_CDESCRI']);
                            $('#MainContent_txtdescripcion1').val(val['AR_CDESCRI']);
                            $('#MainContent_txtdescripcion1').val(val['AR_CDESCRI']);
                            $('#MainContent_txtdescripcion1').val(val['AR_CDESCRI']);
                            $('#MainContent_txtdescripcion1').val(val['AR_CDESCRI']);
                            $('#MainContent_txtdescripcion1').val(val['AR_CDESCRI']);
                            $('#MainContent_txtdescripcion1').val(val['AR_CDESCRI']);
                            $('#MainContent_txtdescripcion1').val(val['AR_CDESCRI']);
                            $('#MainContent_txtdescripcion1').val(val['AR_CDESCRI']);*/
                        });
                        buscaContenido(1);
                        buscaContenido(2);
                        buscaContenido(3);
                        buscaContenido(4);
                        ($('#MainContent_txtMIDMOV').val() != "" ? Operacion.inputEstado('txtMIDMOV', 0,true) : "");
                        ($('#MainContent_txtMfechaE').val() != "" ? Operacion.inputEstado('txtMfechaE', 0,true) : "");
                        ($('#MainContent_txtMguiaF').val() != "" ? Operacion.inputEstado('txtMguiaF', 0,true) : "");
                        ($('#MainContent_txtMIDCL').val() != "" ? Operacion.inputEstado('txtMIDCL', 0,true) : "");
                        ($('#MainContent_txtMCODPRO').val() != "" ? Operacion.inputEstado('txtMCODPRO', 0,true) : "");
                        ($('#MainContent_txtMtdr').val() != "" ? Operacion.inputEstado('txtMtdr', 0,true) : "");
                        ($('#MainContent_txtMnroDocumento1').val() != "" ? Operacion.inputEstado('txtMnroDocumento1', 0,true) : "");
                        ($('#MainContent_txtTDRef2').val() != "" ? Operacion.inputEstado('txtTDRef2', 0,true) : "");
                        ($('#MainContent_txtMnroDocumento2').val() != "" ? Operacion.inputEstado('txtMnroDocumento2', 0,true) : "");
                        ($('#MainContent_txtMordenCompra').val() != "" ? Operacion.inputEstado('txtMordenCompra', 0,true) : "");
                        ($('#MainContent_txtCentroCosto').val() != "" ? Operacion.inputEstado('txtCentroCosto', 0,true) : "");
                        ($('#MainContent_txtSolicitante').val() != "" ? Operacion.inputEstado('txtSolicitante', 0,true) : "");
                        ($('#MainContent_ddlMalmacenRef').val() != "" ? Operacion.inputEstado('ddlMalmacenRef', 0,true) : "");
                        ($('#MainContent_txtOrdenTrabajo').val() != "" ? Operacion.inputEstado('txtOrdenTrabajo', 0,true) : "");
                        ($('#MainContent_ddlManexo').val() != "" ? Operacion.inputEstado('ddlManexo', 0,true) : "");
                        ($('#MainContent_txtManexoDetalle').val() != "" ? Operacion.inputEstado('txtManexoDetalle', 0,true) : "");
                        ($('#MainContent_txtMglosa1').val() != "" ? Operacion.inputEstado('txtMglosa1', 0,true) : "");
                        ($('#MainContent_txtMglosa2').val() != "" ? Operacion.inputEstado('txtMglosa2', 0,true) : "");
                        ($('#MainContent_txtMglosa3').val() != "" ? Operacion.inputEstado('txtMglosa3', 0,true) : "");
                        ($('#MainContent_txttransCod').val() != "" ? Operacion.inputEstado('txttransCod', 0,true) : "");
                        ($('#MainContent_txtcodigoVeh').val() != "" ? Operacion.inputEstado('txtcodigoVeh', 0,true) : "");
                        ($('#MainContent_txtdireccionE').val() != "" ? Operacion.inputEstado('txtdireccionE', 0,true) : "");
                    }
                });
               
            }
            
            $("#btnGuardar").click(function () {

                if (confirm('Desea modificar los datos')) {
                    var DATA = {};
                    var numDoc = "";

                    var dfecha = moment($('#MainContent_txtMfechaE').val(), 'DD-MM-YYYY 00:00:00.000');

                    DATA.C5_CALMA = $('#MainContent_codAL').val();//Session["aID"].ToString(), //REEMPLAZAR
                    DATA.C5_CTD = $('#MainContent_codM').val();//CODIGO MOVIMIENTO:EP
                    DATA.C5_CNUMDOC = $('#MainContent_codDR').val();//NUMERO DE DOCUMENTO VENTA FINAL
                    DATA.C5_CLOCALI = "0001";
                    DATA.C5_DFECDOC = dfecha;//Convert.ToDateTime(lblFechaE.Text),
                    DATA.C5_DFECVEN = null;
                    DATA.C5_CTIPMOV = $('#MainContent_ddlesM').val();
                    DATA.C5_CCODMOV = $('#MainContent_codCC').val();
                    DATA.C5_CSITUA = "";//V
                    DATA.C5_CRFTDOC = ($('#MainContent_txtMtdr').val() != "" ? $('#MainContent_txtMtdr').val() : "");//($('#MainContent_txtIDREF').val() != " " ? $('#MainContent_txtIDREF').val() : "");//FT,LQ,RQ
                    DATA.C5_CRFNDOC = ($('#MainContent_txtMnroDocumento1').val() != " " ? $('#MainContent_txtMnroDocumento1').val() : "-");
                    DATA.C5_CSOLI = ""; 
                    DATA.C5_CCENCOS = $('#MainContent_txtCentroCosto').val();
                    DATA.C5_CRFALMA = ($('#MainContent_ddlAlmacenRef').val() == "-1" ? "" : $('#MainContent_ddlAlmacenRef').val());//0101
                    DATA.C5_CGLOSA1 = ($('#MainContent_txtMglosa1').val() != "" ? $('#MainContent_txtMglosa1').val() : "");
                    DATA.C5_CGLOSA2 = ($('#MainContent_txtMglosa2').val() != "" ? $('#MainContent_txtMglosa2').val() : "");
                    DATA.C5_CGLOSA3 = ($('#MainContent_txtMglosa3').val() != "" ? $('#MainContent_txtMglosa3').val() : "");
                    DATA.C5_CTIPANE = "";
                    DATA.C5_CCODANE = "";
                    DATA.C5_DFECCRE = "";
                    DATA.C5_CUSUCRE = $('#MainContent_hdUSUARIO').val();//$("#MainContent_hfusuario").val();//Session["codusu"].ToString(),
                    DATA.C5_DFECMOD = null;
                    DATA.C5_CUSUMOD = $('#MainContent_hdUSUARIO').val();
                    DATA.C5_CCODCLI = $('#MainContent_txtMIDCL').val();
                    DATA.C5_CNOMCLI = $('#MainContent_lblMCliente').text();
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
                    DATA.C5_CNUMORD = "";
                    DATA.C5_CTIPORD = "";
                    DATA.C5_CGUIDEV = "";
                    DATA.C5_CCODPRO = $('#MainContent_txtMCODPRO').val(); 
                    DATA.C5_CNOMPRO = $('#MainContent_lblMproveedor').text();
                    DATA.C5_CCIAS = "";
                    DATA.C5_CFORVEN = "";//006,007,014
                    DATA.C5_CCODMON = ($('#MainContent_ddlMoneda').val() != "" ? $('#MainContent_ddlMoneda').val() : ""); //$( "#myselect option:selected" ).text();
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
                    DATA.C5_CRFTDO2 = ($('#MainContent_txtTDRef2').val() != undefined ? $('#MainContent_txtTDRef21').val() : "");
                    DATA.C5_CRFNDO2 = ($('#MainContent_txtMnroDocumento2').val() != undefined ? $('#MainContent_txtMnroDocumento2').val() : "");
                    DATA.C5_CNUMLIQ = "";
                    DATA.C5_CORDEN = $('#MainContent_txtOrdenTrabajo').val();
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
                        url: "ModificacionCabecera.aspx/actualizaCabecera",
                        data: '{DATA:' + JSON.stringify(DATA) + '}',
                        contentType: "application/json;charset=utf-8",
                        dataType: "json",
                        success: function (response) {
                            alert("Se modifico el documento");
                        },
                        error: function (response) {
                            console.table(response);
                        }
                    });
                    var respuesta = confirm('Se ha actualizado el registro, desea realizar otra operación');
                    if (respuesta) {
                        window.location.href = 'http://localhost:2510/ALMACEN/ModificacionCabecera.aspx';
                    } else {
                        window.location.href = 'http://localhost:2510/ALMACEN/ConsultaReimpresion.aspx';
                    }
                } else {
                    alert('Ha cancelado la acción');
                }

            });
        });
    </script>
    <style type="text/css">
        .auto-style1 {
            width: 279px;
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
            <legend>Datos Principales</legend>
            <table style="width: 100%;">
                <tr>
                    <td colspan="4" style="text-align: center;">
                        <asp:Label ID="lblAlmacen" class="titulo" runat="server" Text="Modificacion de Documentos"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td class="auto-style1">Entrada/Salida</td>
                    <td>
                        <asp:DropDownList ID="ddlesM" runat="server">
                        </asp:DropDownList>
                        <!--OnSelectedIndexChanged="ddlesM_SelectedIndexChanged"-->
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">Tipo Movimiento</td>
                    <td>
                        <!--<asp:Label ID="lblCodigoM" runat="server" Text=""></asp:Label>-->
                        <div id="combo">
                        <asp:DropDownList ID="ddlTipoMov" runat="server">
                        </asp:DropDownList>
                        </div>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">Almacen</td>
                    <td>
                        <asp:DropDownList ID="ddlMalmacen" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">Numero de documento</td>
                    <td>
                        <asp:TextBox ID="txtMNumeroDoc" class="ac" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>

        </fieldset>
        <fieldset>
            <legend>Detalle</legend>
            <table>
                <tr>
                    <td >Codigo Movimiento&nbsp;</td>
                    <td class="auto-style1" >
                        <asp:TextBox ID="txtMIDMOV" class="tb1" runat="server" Width="49px"></asp:TextBox>
                        <asp:Label ID="lblMCodigoMov" runat="server" Text=""></asp:Label>
                        <!--<asp:TextBox ID="txtMCodigoMov" Width="280px" runat="server" class="tb1" required ></asp:TextBox>-->
                    </td>
                    <td>&nbsp;</td>
                    <td >&nbsp;</td>
                </tr>
                <tr>
                    <td >Fecha Documento</td>
                    <td class="auto-style1" >
                        <asp:TextBox ID="txtMfechaE" class="dpFecha1" runat="server"></asp:TextBox>
                    </td>
                    <td>Cliente</td>
                    <td >
                        <asp:TextBox ID="txtMIDCL" class="tb3" Width="110px" runat="server"></asp:TextBox>
                        <asp:Label ID="lblMCliente" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td >Guia Facturada&nbsp;</td>
                    <td class="auto-style1" >
                        <asp:TextBox ID="txtMguiaF" runat="server"></asp:TextBox>
                    </td>
                    <td>Proveedor</td>
                    <td style="width:450px;" >
                        <asp:TextBox ID="txtMCODPRO" Width="147px" class="tb4" runat="server"></asp:TextBox>
                        <asp:Label ID="lblMproveedor" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td >Tipo Documento Referencia</td>
                    <td class="auto-style1" >
                        <asp:TextBox ID="txtMtdr" runat="server" Width="38px"></asp:TextBox>
                        <asp:Label ID="lblMdtdr" runat="server" Text=""></asp:Label>
                    </td>
                    <td>Nro Documento 1</td>
                    <td >
                        <asp:TextBox ID="txtMnroDocumento1" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td >Tipo Documento Referencia 2</td>
                    <td class="auto-style1" >
                        <asp:TextBox ID="txtTDRef2" runat="server" Width="38px"></asp:TextBox>
                        <asp:Label ID="lblMTipoDocumentoRef2" runat="server" Text=""></asp:Label>
                    </td>
                    <td>Nro Documento 2</td>
                    <td >
                        <asp:TextBox ID="txtMnroDocumento2" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td >Nro Orden Compra</td>
                    <td class="auto-style1" >
                        <asp:TextBox ID="txtMordenCompra" runat="server"></asp:TextBox>
                    </td>
                    <td>Centro de Costo</td>
                    <td >
                        <asp:TextBox ID="txtCentroCosto" Width="84px" class="tb3" runat="server"></asp:TextBox>
                        <asp:Label ID="lblDetalleCC" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td >Almacen de Referencia</td>
                    <td class="auto-style1" >
                        <asp:DropDownList ID="ddlMalmacenRef" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>Solicitante</td>
                    <td >
                        <asp:TextBox ID="txtSolicitante" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td >Orden de Trabajo</td>
                    <td class="auto-style1" >
                        <asp:TextBox ID="txtOrdenTrabajo" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td >&nbsp;</td>
                </tr>
                <tr>
                    <td >Tipo/Codigo Anexo</td>
                    <td class="auto-style1" >
                        <asp:DropDownList ID="ddlManexo" runat="server">
                        </asp:DropDownList>
                        <asp:TextBox ID="txtManexoDetalle" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td >&nbsp;</td>
                </tr>
                <tr>
                    <td >Glosa 1</td>
                    <td class="auto-style1" >
                        <asp:TextBox ID="txtMglosa1" runat="server" Width="281px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td >&nbsp;</td>
                </tr>
                <tr>
                    <td >Glosa 2</td>
                    <td class="auto-style1" >
                        <asp:TextBox ID="txtMglosa2" runat="server" Width="281px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td >&nbsp;</td>
                </tr>
                <tr>
                    <td >Glosa 3</td>
                    <td class="auto-style1" >
                        <asp:TextBox ID="txtMglosa3" runat="server" Width="281px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td >&nbsp;</td>
                </tr>
                <tr>
                    <td >&nbsp;</td>
                    <td class="auto-style1" >&nbsp;</td>
                    <td>&nbsp;</td>
                    <td >&nbsp;</td>
                </tr>
                <tr>
                    <td >&nbsp;</td>
                    <td class="auto-style1" >&nbsp;</td>
                    <td>&nbsp;</td>
                    <td >&nbsp;</td>
                </tr>
            </table>
        </fieldset>
        <fieldset>
            <legend>Datos Adicionales</legend>
            <table style="width: 100%;">
                <tr>
                    <td>Codigo Transportista</td>
                    <td>
                        <asp:TextBox ID="txttransCod" runat="server"></asp:TextBox>
                    </td>
                    <td>Codigo Vehículo</td>
                    <td>
                        <asp:TextBox ID="txtcodigoVeh" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Dirección de entrega</td>
                    <td>
                        <asp:TextBox ID="txtdireccionE" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr id="pie">
                    <td colspan="3">&nbsp;</td>
                    <td>
                        <input id="btnGuardar" type="button" value="Guardar" /></td>
                </tr>
            </table>
        </fieldset>
    </div>
    <br />
</asp:Content>














