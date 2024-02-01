<%@ Page Title="Modificación de Cabecera" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ModificacionCabecera.aspx.cs" Inherits="ModificacionCabecera" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link type="text/css" href="../CSS/base.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {
            UHTML.id = 'MainContent';
            $(".dpFecha1").datepicker();
            //AL = Operacion.mask('ddlMalmacen').val();
            //CO = Operacion.mask('txtMIDMOV').val();
			MARRAY = [];
            $("#btnGuardar").attr('disabled', true);
            $.urlParam = function (name) {
                var results = new RegExp('[\?&]' + name + '=([^&#]*)').exec(window.location.href);
                return (results != null ? results[1] || 0 : "");
            }
            if ($.urlParam('PE') == "S") {
                //$('#MainContent_ddlesM').val('S');
                comboNuevo();
            }

            //Inicializa
            Operacion.mask('hfG1').val('-1');
            Operacion.mask('hfOT').val('-1');
            Operacion.inputVisible('ddlOrigen', 1);
            Operacion.inputVisible('ddlDepa', 1);

            Operacion.inputVisible('lblCOTR', 1, true);
            Operacion.inputVisible('lblDIE', 1, true);
            Operacion.inputVisible('lblCOV', 1, true);
            Operacion.inputEstado('txttransCod', 1, true);
            Operacion.inputEstado('txtcodigoVeh', 1, true);
            Operacion.inputEstado('txtdireccionE', 1, true);

            //obtiene get
            //if ($.urlParam('PE')!="0" && $.urlParam('TD')!=0 && $.urlParam('AL')!=0 && $.urlParam('ND')!=0) {
            $('#MainContent_ddlesM').val($.urlParam('PE'));
            $('#MainContent_ddlTipoMov').val($.urlParam('TD'));
            $('#MainContent_ddlMalmacen').val($.urlParam('AL'));
            $('#MainContent_txtMNumeroDoc').val($.urlParam('ND'));
            MPAR = $.urlParam('AL');
            MCOD = Operacion.mask('txtMIDMOV').val();
            
            var campoActivo = function (OP) {
                $.ajax({
                    type: "POST",
                    url: "RegistroEntrada.aspx/obtenerCampo",
                    data: "{ CM: 'E',TM:'" + OP + "'}",
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async:false,
                    success: function (data) {
                        $.each(data, function (i, v) {
                            Operacion.inputVisible('lblPRO',(v.TM_CFPROV == "N" ? 1 : 0),true);
                            Operacion.inputEstado('lblMproveedor', (v.TM_CFPROV == "N" ? 1 : 0),true);
                            Operacion.inputEstado('txtProveedor', (v.TM_CFPROV == "N" ? 1 : 0), true);
                            Operacion.inputVisible('lblCLI', (data.d['TM_CVANEXO'] == "N" ? 1 : 0), true);
                            Operacion.inputEstado('txtMIDCL', (data.d['TM_CVANEXO'] == "N" ? 1 : 0), true);

                            Operacion.inputVisible('lblSOL', (data.d['TM_CFSOLI'] == "N" ? 1 : 0), true);
                            Operacion.inputEstado('txtSolicitante', (data.d['TM_CFSOLI'] == "N" ? 1 : 0), true);

                            Operacion.inputVisible('lblNOC', (data.d['TM_CORDCOM'] == "N" ? 1 : 0), true);
                            Operacion.inputEstado('txtMordenCompra', (data.d['TM_CORDCOM'] == "N" ? 1 : 0), true);
                            
                            Operacion.inputVisible('lblOT', (data.d['TM_CFORDEN'] == "N" ? 1 : 0));//NUEVO
                            Operacion.inputEstado('txtOrdenTrabajo', (data.d['TM_CFORDEN'] == "N" ? 1 : 0));//NUEVO

                            Operacion.inputVisible('lblCEC', (data.d['TM_CFCCOS'] == "N" ? 1 : 0));//NUEVO                      
                            Operacion.inputEstado('txtCentroCosto', (data.d['TM_CFCCOS'] == "N" ? 1 : 0));//NUEVO                      
                            
                            Operacion.inputVisible('lblG1', (data.d['TM_CFGLOS'] == "N" ? 1 : 0), true);
                            Operacion.inputEstado('txtG1', (data.d['TM_CFGLOS'] == "N" ? 1 : 0), true);
                            Operacion.inputVisible('lblG2', (data.d['TM_CFGLOS'] == "N" ? 1 : 0), true);
                            Operacion.inputEstado('txtG2', (data.d['TM_CFGLOS'] == "N" ? 1 : 0), true);
                            Operacion.inputVisible('lblG3', (data.d['TM_CFGLOS'] == "N" ? 1 : 0), true);
                            Operacion.inputEstado('txtG3', (data.d['TM_CFGLOS'] == "N" ? 1 : 0), true);
                            Operacion.inputVisible('lblG4', (data.d['TM_CFGLOS'] == "N" ? 1 : 0), true);
                            Operacion.inputEstado('txtG4', (data.d['TM_CFGLOS'] == "N" ? 1 : 0), true);
                            
                            Operacion.inputVisible('lblALR', (data.d['TM_CFALMA'] == "N" ? 1 : 0));//NUEVO
                            Operacion.inputVisible('ddlMalmacenRef', (data.d['TM_CFALMA'] == "N" ? 1 : 0));

                            Operacion.inputVisible('lblTICA', (data.d['TM_CCODANE'] == "N" ? 1 : 0));//NUEVO
                            Operacion.inputVisible('ddlManexo', (data.d['TM_CCODANE'] == "N" ? 1 : 0));
                            Operacion.inputVisible('txtManexoDetalle', (data.d['TM_CCODANE'] == "N" ? 1 : 0), true);
                            
                            //Operacion.inputVisible('lblNTP',())
                        });
                    }, error: function (data) {
                        console.log(data);
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
			iniciaPGE("MP");
            var addComplete1 = function () {
                $(".ace").autocomplete(
                {/*EMBARCACIONES*/
                    source: function (request, response) {
                        var EDATA = {};
                        EDATA.E_NOMBRE = "%" + request.term + "%";
                        $.ajax({
                            url: "RegistroEntrada.aspx/getEMB",
                            data: '{ EDATA:' + JSON.stringify(EDATA) + '}',
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            dataFilter: function (data) { return data; },
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        value: item.E_NOMBRE + " " + item.E_MATRIC,
                                        id: item.E_MATRIC,
                                        cb: item.E_CABOM3
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
                        Operacion.mask('hfG1').val(str1.trim());
                        //Operacion.mask('lblCBO').text(str2);
                    }, change: function (event, ui) {
                        if (ui.item == null || ui.item == undefined) {
                            alert("No ha seleccionado un valor valido");
                            Operacion.mask('txtGlosa1').focus();
                            //Operacion.mask('txtGlosa1').val('');
                            Operacion.mask('hfG1').val('');
                        }
                    }
                });
            }
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

            var cambiarLABEL = function (MPAR, MCOD) {
                if ((MPAR == "A002" || MPAR == "A004" || MPAR == "0004" || MPAR=="0015") && (MCOD == "CO" || MCOD == "MP" ||MCOD=="CX")) {
                    addComplete1();
                    addComplete2();
                    //Operacion.inputVisible('ddlDepa', 0);
                    Operacion.inputVisible('ddlOrigen', 0);
                    Operacion.inputVisible('txtMnroDocumento2', 1);
                    Operacion.mask('lblND2').text('Origen');
                    Operacion.mask('lblOT').text('Bahia');
                    Operacion.mask('lblG1').text('Embaracion');
                    Operacion.mask('lblG2').text('Transporte');
                    Operacion.mask('lblG3').text('Chofer/Matricula');
                    Operacion.mask('lblG4').text('DER');
                } else {
                    Operacion.oACD('txtMglosa1');
                    Operacion.mask('hfG1').val('-1');
                    Operacion.oACD('txtOrdenTrabajo');
                    Operacion.mask('hfOT').val("-1");
                    Operacion.inputVisible('ddlDepa', 1);
                    Operacion.inputVisible('ddlOrigen', 1);
                    Operacion.mask('ddlDepa').val("-1");
                    Operacion.mask('ddlOrigen').val("-1");
                    Operacion.inputVisible('txtMnroDocumento2', 0);
                }
            }
            //cambiarLABEL(MPAR,MCOD);
            if ($('#MainContent_txtMNumeroDoc').val() != "") {
                cargar();
                //cambiarLABEL(MPAR, MCOD);
                Operacion.inputEstado('btnGuardar', 0, false);
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
                            async: false,
                            success: function (data) {
                                if (data.d.length > 0) {
                                    jQuery.each(data.d, function (i, val) {
                                        $('#MainContent_lblMCodigoMov').text(val['TM_CDESCRI']);
                                    });
                                } else {
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
                            async: false,
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
                            async: false,
                            contentType: "application/json; charset=utf-8",
                            dataFilter: function (data) { return data; },
                            success: function (data) {
                                if (data.d.length > 0) {
                                    jQuery.each(data.d, function (i, val) {
                                        $('#MainContent_lblDetalleCC').text(val['TG_CDESCRI']);
                                    });
                                } else {
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
                            async: false,
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
                    case 6:
                        var EDATA = {};
                        EDATA.E_NOMBRE = "%" + Operacion.mask('txtMglosa1').val().trim() + "%";
                        $.ajax({
                            url: "RegistroEntrada.aspx/getEMB",
                            data: '{ EDATA:' + JSON.stringify(EDATA) + '}',
                            dataType: "json",
                            type: "POST",
                            async: false,
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                if (data.d.length > 0) {
                                    Operacion.mask('txtMglosa1').val(data.d[0].E_NOMBRE + " " + data.d[0].E_MATRIC);
                                    Operacion.mask('hfG1').val(data.d[0].E_MATRIC.trim());
                                } else {
                                    //Operacion.mask('txtMglosa1').val();
                                    Operacion.mask('hfG1').val("-1");
                                }
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                //  alert(textStatus);
                            }
                        });
                        break;
                    case 7:
                        $.ajax({
                            url: "ModificacionCabecera.aspx/obtieneBahia",
                            data: "{ KEY:'" + Operacion.mask('txtOrdenTrabajo').val() + "'}",
                            dataType: "json",
                            type: "POST",
                            async: false,
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                if (data.d.length > 0) {
                                    Operacion.mask('txtOrdenTrabajo').val(data.d);
                                    //Operacion.mask('hfOT').val(Operacion.mask('txtOrdenTrabajo').val());
                                } else {
                                    Operacion.mask('hfOT').val("-1");
                                }
                            },
                            error: function (data) {
                                console.log(data);
                            }
                        });
                        break;
                }
            }
            function comboNuevo() {

                $("#combo").html("");
                if ($('#MainContent_ddlesM').val() == "S") {
                    $("#combo").append("<select id='MainContent_ddlTipoMov' name='ctl00$MainContent$ddlTipoMov'><option value='PS' selected>PS - Parte de Salida</option><option value='GS'>GS - Guia de Salida</option></select>");
                    $('#MainContent_ddlTipoMov').val($.urlParam('TD'));
                } else {
                    $("#combo").append("<select id='MainContent_ddlTipoMov' name='ctl00$MainContent$ddlTipoMov'><option value='PE' selected>PE - Parte de Entrada</option></select>");
                }

            }
            $(".ac").autocomplete(
                {
                    source: function (request, response) {
                        var NDOC = '%' + request.term + '%';
                        $.ajax({
                            url: "ModificacionCabecera.aspx/getNRODOCUMENTO",
                            data: "{ ND: '" + NDOC + "', ES:'" + Operacion.mask('ddlesM').val() + "',TD:'" + Operacion.mask('ddlTipoMov').val() + "',AL:'" + Operacion.mask('ddlMalmacen').val() + "'}",
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
                        Operacion.inputEstado('btnGuardar', 0, false);
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
                        var TM = Operacion.mask('txtMIDMOV').val();//Operacion.mask('txtMIDMOV').val();
						var ADATA = {};
                        ADATA.AC_CVANEXO = "P";
                        ADATA.AC_CNOMBRE = '%' + request.term + '%';
                        ADATA.AV_CDOCIDE = (TM == "MP" ? 1 : 6);//VARIAR 1:PL|6:PU
                        ADATA.AC_CTIPOAC = (jQuery.inArray(Operacion.mask('codAL').val(), MARRAY) !== -1 ? (TM == "MP" ? "PL" : "PU") : "");
                        /*var ADATA = {};
                        ADATA.AVANEXO = "P";
                        ADATA.ADESANE = '%' + request.term + '%';
                        ADATA.ATIPTRA = (TM == "CO" ? "J" : (TM == "MP" ? "N" : null));*/
                        //console.log(ADATA);
                        $.ajax({
                            url: "RegistroEntrada.aspx/getClienteT1",//getClienteT",
                            data: '{ADATA:' + JSON.stringify(ADATA) + '}',
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            dataFilter: function (data) { return data; },
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        value: item.AC_CNOMBRE.trim(),//item.ADESANE.trim(),item.ACODANE.trim(),
                                        id: item.AC_CCODIGO.trim()//item.ACODANE.trim()
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
                            Operacion.mask('lblMproveedor').text(val['C5_CCODPRO']);
                            //$('#MainContent_txtMCODPRO').val(val['C5_CCODPRO']); lblMproveedor
                            Operacion.mask('txtMCODPRO').val(val['C5_CNOMPRO']);
                            $('#MainContent_txtMtdr').val(val['C5_CRFTDOC']);//val['C5_CTD']);
                            $('#MainContent_txtTDRef2').val(val['C5_CRFTDO2']);
                            $('#MainContent_txtMnroDocumento1').val(val['C5_CRFNDOC']);
                            $('#MainContent_txtMnroDocumento2').val(val['C5_CRFNDO2']);
                            Operacion.mask('ddlOrigen').val(val['C5_CRFNDO2'].trim());
                            $('#MainContent_txtCentroCosto').val(val['C5_CCENCOS']);
                            var miOT = val['C5_CORDEN'].trim();
                            $('#MainContent_txtOrdenTrabajo').val(val['C5_CORDEN']);
                            (miOT.length == "8" ? buscaContenido(7) : "");
                            Operacion.mask('hfOT').val((miOT.length == "8" ? val['C5_CORDEN'] : "-1"));
                            Operacion.mask('txtMordenCompra').val(val['C5_CNUMORD']);
                            $('#MainContent_txtMglosa1').val(val['C5_CGLOSA1']);
                            $('#MainContent_txtMglosa2').val(val['C5_CGLOSA2']);
                            $('#MainContent_txtMglosa3').val(val['C5_CGLOSA3']);
                            $('#MainContent_txtMglosa4').val(val['C5_CGLOSA4']);
                            $('#MainContent_txtNTP').val(val['C5_CCODFER']);//NUMERO TICKET PESAJE
                            cambiarLABEL(MPAR, val['C5_CCODMOV']);
                            campoActivo(Operacion.mask('txtMIDMOV').val());
                            if (val['C5_CNUMORD'].trim()!=""|| val['C5_CTIPORD'].trim() != "" || val['C5_CRFTDOC'] == "FT" || val['C5_CRFTDOC'] == "LQ") {
                                //console.log(val['C5_CTIPORD']);
                                alert('El documento no se puede modificar,' + (val['C5_CTIPORD'] == "5"?'ya ha sido provisionado':'el documento tiene una o/c'))
                                $("#ctl00").find(':input').each(function () {
                                    var elemento = this;
                                    if (elemento.type == "text") {// || elemento.type == "select-one") {
                                        var milabel = elemento.id;
                                        var label = milabel.split("_");
                                        (label[1] != 'txtMNumeroDoc' ? Operacion.inputEstado(label[1], 1, true) : "");
                                    }
                                });
                                Operacion.inputEstado('ddlOrigen', 1, true);
                                Operacion.inputEstado('btnGuardar', 1, false);
                                
                            } else {
                                /*$("#ctl00").find(':input').each(function () {
                                    var elemento = this;
                                    if (elemento.type == "text") {// || elemento.type == "select-one") {
                                        var milabel = elemento.id;
                                        var label = milabel.split("_");
                                        (label[1] != 'txtMNumeroDoc' ? Operacion.inputEstado(label[1], 0, true) : "");
                                        //Operacion.inputEstado(label[1], 0, true);
                                    }
                                });*/
                            }

                        });
                        buscaContenido(1);
                        buscaContenido(2);
                        buscaContenido(3);
                        buscaContenido(4);
                        buscaContenido(6);
                        /*
                        ($('#MainContent_txttransCod').val() != "" ? Operacion.inputEstado('txttransCod', 0, true) : "");
                        ($('#MainContent_txtcodigoVeh').val() != "" ? Operacion.inputEstado('txtcodigoVeh', 0, true) : "");
                        ($('#MainContent_txtdireccionE').val() != "" ? Operacion.inputEstado('txtdireccionE', 0, true) : "");*/
                    }
                });

            }

            $("#btnGuardar").click(function () {

                if (confirm('Desea modificar los datos')) {
                    var DATA = {};
                    var numDoc = "";

                    var dfecha = moment($('#MainContent_txtMfechaE').val(), 'DD-MM-YYYY 00:00:00.000');
                    var XA = Operacion.mask('ddlMalmacen').val();
                    var XM = Operacion.mask('txtMIDMOV').val();
                    var VARO = ((XA == "A002" || XA == "A004") && (XM == "CO" || XM == "MP") ? Operacion.mask('ddlOrigen').val() : (Operacion.mask('txtNroDocumento2').val() != "" ? Operacion.mask('txtNroDocumento2').val() : ""));

                    DATA.C5_CALMA = $('#MainContent_codAL').val();//Session["aID"].ToString(), //REEMPLAZAR
                    DATA.C5_CTD = $('#MainContent_codM').val();//CODIGO MOVIMIENTO:EP
                    DATA.C5_CNUMDOC = $('#MainContent_codDR').val();//NUMERO DE DOCUMENTO VENTA FINAL
                    DATA.C5_CLOCALI = "0001";
                    DATA.C5_DFECDOC = dfecha;//Convert.ToDateTime(lblFechaE.Text),
                    DATA.C5_DFECVEN = null;
                    DATA.C5_CTIPMOV = $('#MainContent_ddlesM').val();
                    DATA.C5_CCODMOV = Operacion.mask('txtMIDMOV').val();
                    DATA.C5_CSITUA = "";//V
                    DATA.C5_CRFTDOC = ($('#MainContent_txtMtdr').val() != "" ? $('#MainContent_txtMtdr').val() : "");//($('#MainContent_txtIDREF').val() != " " ? $('#MainContent_txtIDREF').val() : "");//FT,LQ,RQ
                    DATA.C5_CRFNDOC = ($('#MainContent_txtMnroDocumento1').val() != " " ? $('#MainContent_txtMnroDocumento1').val() : "-");
                    DATA.C5_CSOLI = Operacion.mask('txtSolicitante').val();
                    DATA.C5_CCENCOS = $('#MainContent_txtCentroCosto').val();
                    DATA.C5_CRFALMA = ($('#MainContent_ddlAlmacenRef').val() == "-1" ? "" : $('#MainContent_ddlAlmacenRef').val());//0101
                    DATA.C5_CGLOSA1 = (Operacion.mask('hfG1').val() != "-1" ? Operacion.mask('hfG1').val() : ($('#MainContent_txtMglosa1').val() != "" ? $('#MainContent_txtMglosa1').val() : ""));
                    DATA.C5_CGLOSA2 = (Operacion.mask('txtMglosa2').val() != "" ? Operacion.mask('txtMglosa2').val().trim() : "");
                    DATA.C5_CGLOSA3 = (Operacion.mask('txtMglosa3').val() != "" ? Operacion.mask('txtMglosa3').val().trim() : "");
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
                    DATA.C5_CCODPRO = Operacion.mask('lblMproveedor').text().trim();//$('#MainContent_txtMCODPRO').val();
                    DATA.C5_CNOMPRO = Operacion.mask('txtMCODPRO').val();
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
                    DATA.C5_CRFNDO2 = VARO;//(Operacion.mask('txtMnroDocumento2').val() != undefined ? Operacion.mask('txtMnroDocumento2').val() : "");//ORIGEN
                    DATA.C5_CNUMLIQ = "";
                    DATA.C5_CORDEN = (Operacion.mask('hfOT').val() != "-1" ? Operacion.mask('hfOT').val() : Operacion.mask('txtOrdenTrabajo').val());
                    DATA.C5_CTIPOGS = "";//N
                    DATA.C5_DFECANU = null;
                    DATA.C5_CCODFER = $('#MainContent_txtNTP').val();//TICKET PESAJE
                    DATA.C5_DFECEMB = null;
                    DATA.C5_CGLOSA4 = (Operacion.mask('txtMglosa4').val() != "" ? Operacion.mask('txtMglosa4').val() : "");
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

                    //console.log(DATA);

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
                        window.location.href = '../ALMACEN/ModificacionCabecera.aspx';
                    } else {
                        window.location.href = '../ALMACEN/ConsultaReimpresion.aspx';
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

        .auto-style2 {
            width: 215px;
        }

        .auto-style3 {
            width: 165px;
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
                    <td class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td class="auto-style2">Entrada/Salida</td>
                    <td>
                        <asp:DropDownList ID="ddlesM" runat="server">
                        </asp:DropDownList>
                        <!--OnSelectedIndexChanged="ddlesM_SelectedIndexChanged"-->
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">Tipo Movimiento</td>
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
                    <td class="auto-style2">Almacen</td>
                    <td>
                        <asp:DropDownList ID="ddlMalmacen" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">Numero de documento</td>
                    <td>
                        <asp:TextBox ID="txtMNumeroDoc" class="ac" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
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
                    <td class="auto-style2">Codigo Movimiento&nbsp;</td>
                    <td colspan="2">
                        <asp:TextBox ID="txtMIDMOV" class="tb1" runat="server" Width="49px"></asp:TextBox>
                        <asp:Label ID="lblMCodigoMov" runat="server" Text=""></asp:Label>
                    </td>
                    <td>Fecha Documento:<asp:TextBox ID="txtMfechaE" class="dpFecha1" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr id="PROVEEDOR">
                    <td class="auto-style2">
                        <asp:Label ID="lblPRO" runat="server" Text="Proveedor"></asp:Label></td>
                    <td colspan="3">
                        <asp:Label ID="lblMproveedor" runat="server" Text=""></asp:Label>
                        <asp:TextBox ID="txtMCODPRO" Width="396px" class="tb4" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblCLI" runat="server" Text="Cliente"></asp:Label></td>
                    <td colspan="2">
                        <asp:TextBox ID="txtMIDCL" class="tb3" Width="110px" runat="server"></asp:TextBox>
                        <asp:Label ID="lblMCliente" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblGF" runat="server" Text="Guia Facturada"></asp:Label>
                        &nbsp;&nbsp;<asp:TextBox ID="txtMguiaF" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblSOL" runat="server" Text="Solicitante"></asp:Label></td>
                    <td colspan="2">
                        <asp:TextBox ID="txtSolicitante" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">Tipo Documento Referencia</td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtMtdr" runat="server" Width="38px"></asp:TextBox>
                        <asp:Label ID="lblMdtdr" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="auto-style3">Nro Documento 1</td>
                    <td>
                        <asp:TextBox ID="txtMnroDocumento1" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Tipo Documento Referencia 2</td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtTDRef2" runat="server" Width="38px"></asp:TextBox>
                        <asp:Label ID="lblMTipoDocumentoRef2" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:Label ID="lblND2" runat="server" Text="Nro Documento 2"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtMnroDocumento2" runat="server"></asp:TextBox>
                        <asp:DropDownList ID="ddlDepa" runat="server" onkeypress="Operacion.MEKPAT(event,this)"></asp:DropDownList>
                        <br />
                        <asp:DropDownList ID="ddlOrigen" runat="server" TabIndex="6" onkeypress="Operacion.MEKPAT(event,this)"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblNOC" runat="server" Text="Nro Orden Compra"></asp:Label></td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtMordenCompra" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style3">
                        <asp:Label ID="lblNTP" runat="server" Text="Numero Ticket Pesaje"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNTP" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblOT" runat="server" Text="Orden de Trabajo"></asp:Label></td>
                    <td colspan="2">
                        <asp:TextBox ID="txtOrdenTrabajo" class="tb40" runat="server"></asp:TextBox>
                        <asp:HiddenField ID="hfOT" runat="server" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblCEC" runat="server" Text="Centro de Costo"></asp:Label>
                        </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtCentroCosto" Width="84px" class="tb3" runat="server"></asp:TextBox>
                        <asp:Label ID="lblDetalleCC" runat="server" Text=""></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblG1" runat="server" Text="Glosa 1"></asp:Label></td>
                    <td colspan="2">
                        <asp:TextBox ID="txtMglosa1" class="ace" runat="server" Width="281px"></asp:TextBox>
                        <asp:HiddenField ID="hfG1" runat="server" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblG2" runat="server" Text="Glosa 2"></asp:Label></td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtMglosa2" runat="server" Width="281px"></asp:TextBox>
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblG3" runat="server" Text="Glosa 3"></asp:Label></td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtMglosa3" runat="server" Width="281px"></asp:TextBox>
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblG4" runat="server" Text="Glosa 4"></asp:Label></td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtMglosa4" Width="281px" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblALR" runat="server" Text="Almacen de Referencia"></asp:Label>
                        </td>
                    <td class="auto-style1">
                        <asp:DropDownList ID="ddlMalmacenRef" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblTICA" runat="server" Text="Tipo/Codigo Anexo"></asp:Label>
                        </td>
                    <td class="auto-style1">
                        <asp:DropDownList ID="ddlManexo" runat="server">
                        </asp:DropDownList>
                        <asp:TextBox ID="txtManexoDetalle" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style1">
                        <input id="btnGuardar" class="btn" type="button" value="Guardar" /></td>
                    <td class="auto-style3">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </fieldset>
        <fieldset style="display:none;">
            <legend>Datos Adicionales</legend>
            <table style="width: 100%;">
                <tr>
                    <td>
                        <asp:Label ID="lblCOTR" runat="server" Text="Codigo Transportista"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txttransCod" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblCOV" runat="server" Text="Codigo Vehículo"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtcodigoVeh" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDIE" runat="server" Text="Dirección de entrega"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtdireccionE" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr id="pie">
                    <td colspan="3">&nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </fieldset>
    </div>
    <br />
</asp:Content>