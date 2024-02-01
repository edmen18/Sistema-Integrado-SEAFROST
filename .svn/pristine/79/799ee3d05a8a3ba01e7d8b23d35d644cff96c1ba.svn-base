<%@ Page Title="Ejecución de Programación" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="EjecucionProgramacion.aspx.cs" Inherits="FINANZAS_TESORERIA_PAGOS_EjecucionProgramacion" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link type="text/css" href="../../../CSS/base.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {
            $("#MainContent_txtfecha").datepicker();
            mi_detalle = [], dcuentas=[];
            M_ARRAY=[];
            UHTML.id = 'MainContent';
            Operacion.iValida('txttipocamb', 1);
            var valida = function (input) {
                var sw = true;
                $.each(input, function (k, v) {
                    sa = true;
                    sa = sa && (Operacion.mask(v).is('[disabled]'));//SI ESTA DESAHABILITADO
                    if (sa == false) {
                        sw = sw && (Operacion.mask(v).val() != '' && Operacion.mask(v).val() != null && Operacion.mask(v).val() != '-1');//COMPRUEBA VALOR
                        (Operacion.mask(v).is('input') ? Operacion.mask(v).css('border', 'red solid 1px') : "");
                        (Operacion.mask(v).is("select") ? Operacion.mask(v).css('color', 'red') : "");
                        if (sw) {
                            Operacion.mask(v).removeClass('style');
                        }
                    } else {
                        $(this).removeClass('placeholder');
                    }
                });
                return sw;
            }
            var mi_valida = function () {
                return valida([
                    'txtfechatransaccion', 'txttipocamb', 'ddlarea'
                    , 'ddlmediopago', 'ddlsubdiario'
                ]);
            }



            var iniciaPGE = function (CO) {
                var PDATA = {};
                PDATA.AF_COD = CO;
                $.ajax({
                    type: "POST",
                    url: "EjecucionProgramacion.aspx/getPARAM",
                    data: '{ PDATA: ' + JSON.stringify(PDATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        console.log(data);
                        if (data.d.length > 0) {
                            jQuery.each(data.d, function (i, v) {
                                console.log(v);
                                M_ARRAY.push(v.AF_TDESCRI1.trim());
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
            iniciaPGE("AD");
            console.log(M_ARRAY);

            $("#MainContent_txtfechatransaccion").datepicker();

            $(".INCONSISTENCIACTADET").click(function () {
                inconsistenciactadet();
            });

            function generarlote() {
                var contador = "";
                var formato = "";
                var fecha = new Date();
                var annio = fecha.getFullYear();


                $.ajax({

                    type: "POST",
                    url: "EjecucionProgramacion.aspx/GENERARLOTE",
                    //data: "{solicitud: '" + solicitud + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        var ultimodato = data.d;
                        formato = ultimodato.length < 4 ? pad("0" + ultimodato, 4) : ultimodato;
                        formato = annio.toString().substring(2, 4) + "" + formato;
                    },
                    error: function (data) {
                        if (data.length != 0)
                            alert(data);
                    }
                });
                return { formato };
            }

            function completarejed(numdoc) {

                var CP_CSUBDIA = "";
                var CP_CCOMPRO = "";
                var CP_CSECDET = "";
                var CP_CTIPDOC = "";
                var CP_CNDOCRE = "";
                var CP_NTIPCAM = "";
                $.ajax({

                    type: "POST",
                    url: "EjecucionProgramacion.aspx/datoscompletarejed",
                    data: '{ CODATA: ' + JSON.stringify(numdoc) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        for (var i = 0; i < data.d.length; i++) {
                            CP_CSUBDIA = data.d[i].CP_CSUBDIA;
                            CP_CCOMPRO = data.d[i].CP_CCOMPRO;
                            CP_CSECDET = data.d[i].CP_CSECDET;
                            CP_CTIPDOC = data.d[i].CP_CTIPDOC;
                            CP_CNDOCRE = data.d[i].CP_CNDOCRE;
                            CP_NTIPCAM = data.d[i].CP_NTIPCAM;
                        }

                    },
                    error: function (data) {
                        if (data.length != 0)
                            console.log(data);
                    }
                });
                // alert(CP_CSUBDIA + "-" + CP_CCOMPRO + "-" + CP_CSECDET + "-" + CP_CTIPDOC + "-" + CP_CNDOCRE + "-" + CP_NTIPCAM);
                return { CP_CSUBDIA, CP_CCOMPRO, CP_CSECDET, CP_CTIPDOC, CP_CNDOCRE, CP_NTIPCAM };
            }


            function datoscompletardetcomprobante(numdoc) {

                var AC_CVANEXO = "";
                var AC_CNOMBRE = "";
                
                $.ajax({

                    type: "POST",
                    url: "EjecucionProgramacion.aspx/datoscompletardetcomprobante",
                    data: '{ CODATA: ' + JSON.stringify(numdoc) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        for (var i = 0; i < data.d.length; i++) {
                            AC_CVANEXO = data.d[i].AC_CVANEXO;
                            AC_CNOMBRE = data.d[i].AC_CNOMBRE;
                        }

                    },
                    error: function (data) {
                        if (data.length != 0)
                            console.log(data);
                    }
                });
                return { AC_CVANEXO, AC_CNOMBRE };

            }
            function generar() {


                var element = $('#MainContent_txtfechatransaccion').val();
                var fecha = element.split('/');
                var FECDOC = fecha[2].substr(2, 2) + "" + fecha[1] + "" + fecha[0];
                var ultimodato = "";
                var formato = "";
                var DATA = {};
                DATA.CTSUBDIA = Operacion.mask('ddlsubdiario').val();//Operacion.mask('ddlSDIA').val();
                DATA.CTANO = fecha[2].substr(2, 2);
                DATA.CTMES = fecha[1];
                //DATA.LC_DFECCOM = moment(Operacion.mask('txtFEC').val(), 'DD/MM/YYYY');

                $.ajax({
                    type: "POST",
                    url: "EjecucionProgramacion.aspx/correlativoCP",
                    data: '{ DATA: ' + JSON.stringify(DATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        ultimodato = data.d;
                       // formato = ultimodato.length < 6 ? pad("0" + ultimodato, 6) : ultimodato;
                        //$('#MainContent_txtnumprog').val(formato);
                    },
                    error: function (response) {
                        console.table(response);
                    }
                });


                return { ultimodato };
            }
            function correlativo(ADATA) {

                var contador = "";
                var formato = "";
                $.ajax({

                    type: "POST",
                    url: "EjecucionProgramacion.aspx/CORRELATIVO",
                    data: '{ADATA: ' + JSON.stringify(ADATA) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        formato = data.d;
                    },
                    error: function (data) {
                        if (data.length != 0)
                            alert(data);
                    }
                });
                return { formato };
            }

            function pad(str, max) {
                if (str != undefined) {
                    str = str.toString();
                    return str.length < max ? pad("0" + str, max) : str;
                }
            }
            function inconsistenciactadet() {
                var ADATA = {};
                var cont = 0;

                var gridView = document.getElementById("<%=GridView1.ClientID %>");
                for (var t = 1; t < gridView.rows.length; t++) {
                    ADATA.AC_CVANEXO = gridView.rows[t].cells[0].innerHTML;
                    ADATA.AC_CCODIGO = gridView.rows[t].cells[1].innerHTML;
                    $.ajax({
                        type: "POST",
                        url: "AprobacionProgramacion.aspx/INCONSISTENCIACUENTADET",
                        data: '{ADATA: ' + JSON.stringify(ADATA) + '}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (data) {
                            if (data.d.length > 0) {
                                cont = cont + 1;
                            }
                        },
                        error: function (response) {
                            if (response.length != 0)
                                console.log(response);
                        }
                    });
                    // return { cont};
                }
                if (cont > 0) {
                    alert("No existen inconsistencias");
                }
                else {
                    alert("Se encontraron inconsistencias:\n El acreedor no tiene registrada cuenta de detracción");
                }
            }
            $('#MostrarDetalles').dialog({
                autoOpen: false,
                modal: true,
                resizable: true,
                width: 1000,
                heigth: 100,
                title: 'Mostrar Detalles',
                close: function (event, ui) {

                    var row = $("[id*=GridView3] tr:last-child").clone(true);
                    $("[id*=GridView3] tr").not($("[id*=GridView3] tr:first-child")).remove();

                    $("td", row).eq(0).val("");
                    $("td", row).eq(0).html("");
                    $("td", row).eq(1).html("");
                    $("td", row).eq(2).html("");
                    $("td", row).eq(3).html("");

                    $("[id*=GridView3]").append(row);
                    Operacion.mask("lblhabersoles").text("");
                    Operacion.mask("lblhaberdolares").text("");
                    Operacion.mask("lbldebesoles").text("");
                    Operacion.mask("lbldebedolares").text("");
                },
            });
            
            $('#Modificacion').dialog({
                autoOpen: false,
                modal: true,
                resizable: true,
                width: 1100,
                heigth: 100,
                title: 'Consulta',
                close: function (event, ui) {
                 
                },
            });
            $('#Ejecución').dialog({
                autoOpen: false,
                modal: true,
                resizable: true,
                width: 700,
                heigth: 100,
                title: 'Ejecución',
                close: function (event, ui) {
                    location.reload();
                },
            });
            $(".editar").click(function () {
                trp = $(this).parent().parent();
                id = $("td:eq(1)", trp).html();
                $("#Modificacion").dialog('open');
                filtrardetalles(id);
                cabecera(id);
            });

            $(".ejecucion").click(function () {
                trp = $(this).parent().parent();
                id = $("td:eq(1)", trp).html();
                $("#Ejecución").dialog('open');
                Operacion.mask("lblsobrante").text("0");
                Operacion.mask("lblmontosobrante").text("0");
                document.getElementById("btnejecutar").style.visibility = "hidden";
                document.getElementById("btnejecutar0").style.visibility = "visible";
                cabecerae(id);
                $("#MainContent_ddlarea").val("E03");
                 for (var area = 0 ; area < document.getElementById("<%= ddlarea.ClientID %>").length; area++) {
                 if (document.getElementById("<%= ddlarea.ClientID %>").options[area].text == ("E03-E03-PROVEEDORES DIVERSOS"))
                 document.getElementById("<%= ddlarea.ClientID %>").selectedIndex = area;
                 }
              document.getElementById("<%= rbventa.ClientID %>").checked = true;
                 tipocambioVenta();

             

            });

            function filtrardetalles(codigo) {
                $.ajax({

                    type: "POST",
                    url: "EjecucionProgramacion.aspx/LISTARTTODOS",
                    data: "{ 'dato': '" + codigo + "' }",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {

                        if (data.d.length > 0) {
                            var row = $("[id*=GridView1] tr:last-child").clone(true);
                            $("[id*=GridView1] tr").not($("[id*=GridView1] tr:first-child")).remove();

                            for (var i = 0; i < data.d.length; i++) {
                                $("td", row).eq(0).val(data.d[i].GD_CSECUE);
                                $("td", row).eq(0).html(data.d[i].GD_CVANEXO);
                                $("td", row).eq(1).html(data.d[i].GD_CCODIGO);
                                $("td", row).eq(2).html(data.d[i].GD_CNDREF);
                                $("td", row).eq(3).html(data.d[i].GD_CTIPDOC);
                                $("td", row).eq(4).html(data.d[i].GD_CNUMDOC);

                                $("td", row).eq(5).html((moment(data.d[i].GD_DFECDOC).format("DD/MM/YYYY")));
                                $("td", row).eq(6).html((moment(data.d[i].GD_DFECVEN).format("DD/MM/YYYY")));
                                $("td", row).eq(7).html(data.d[i].GD_CMONCAR);

                                $("td", row).eq(8).html(Number(data.d[i].GD_NORPROG).toFixed(2));
                                $("td", row).eq(10).html(Number(data.d[i].GD_NORRETE).toFixed(2));
                                $("td", row).eq(9).html(data.d[i].GD_CRETE);
                                $("td", row).eq(11).html(Number(data.d[i].GD_NMNPROG).toFixed(2));
                                long = data.d[i].GD_CTASDET.length;

                                $("td", row).eq(12).html("&nbsp;" + data.d[i].GD_CTASDET.substring(0, long - 15));
                                //$("td", row).eq(12).html(data.d[i].GD_CNDREF);


                                $("[id*=GridView1]").append(row);
                                row = $("[id*=GridView1] tr:last-child").clone(true);
                            }
                        } else {
                            var row = $("[id*=GridView1] tr:last-child").clone(true);
                            $("[id*=GridView1] tr").not($("[id*=GridView1] tr:first-child")).remove();

                            $("td", row).eq(1).html("");
                            $("td", row).eq(2).html("");
                            $("td", row).eq(3).html("");
                            $("td", row).eq(4).html("");
                            $("td", row).eq(5).html("");
                            $("td", row).eq(6).html("");
                            $("td", row).eq(7).html("");
                            $("td", row).eq(8).html("");
                            $("td", row).eq(9).html("");
                            $("td", row).eq(10).html("");
                            $("td", row).eq(11).html("");
                            $("td", row).eq(12).html("");
                            $("td", row).eq(0).html("");
                            $("[id*=GridView1]").append(row);
                            alert("no se encontro registro");
                        }
                    },
                    error: function (response) {
                        if (response.length != 0)
                            alert(response);
                    }
                });
            }

            function cabecera(codigo) {
                $.ajax({

                    type: "POST",
                    url: "EjecucionProgramacion.aspx/LISTARUNO",
                    data: "{ 'CODATA': '" + codigo + "' }",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {

                        if (data.d.length > 0) {

                            for (var i = 0; i < data.d.length; i++) {
                                $('#MainContent_lblcodagencia').html(data.d[i].AGENCIA);
                                $('#MainContent_lblagencia').html(data.d[i].AGENCIA2);
                                $('#MainContent_txtprogramacionmod').val(data.d[i].numope);
                                $('#MainContent_lblconcepto').html(data.d[i].CONCEPTO);
                                $('#MainContent_lbltipopago').html(data.d[i].tipopago);
                                $('#MainContent_lblmoneda').html(data.d[i].moneda);
                                $('#MainContent_txttipocambiomod').val(data.d[i].TIPOCAMBIO);
                                $('#MainContent_txtmontomod').val(Number(data.d[i].IMPORTE).toFixed(2));
                                $('#MainContent_txtfechaprogmod').val((moment(data.d[i].fecah).format("DD/MM/YYYY")));
                                if (data.d[i].TIPODETRACCION != null) {
                                    long = data.d[i].TIPODETRACCION.length;
                                    $('#MainContent_lbldetraccion').html(data.d[i].TIPODETRACCION.substring(0, long - 15));
                                }

                                $('#MainContent_lbldetraccion').html(data.d[i].TIPODETRACCION);
                                $('#MainContent_lblcoddetraccion').html(data.d[i].TASADETRACCION);

                                //  $('#MainContent_lblcoddepartamento').html(data.d[i].coddepartamento);
                                $('#MainContent_lbldepartamento').html(data.d[i].DEPARTAMENTO);
                                $('#MainContent_lblcodbanco').html(data.d[i].CODBANCO);
                                $('#MainContent_lblbanco').html(data.d[i].BANCO);
                                $('#MainContent_txtestadomod').val(data.d[i].ESTADO);
                                $('#MainContent_lblusuelaborado').html(data.d[i].USUCRE);
                                $('#MainContent_lblusumodificado').html(data.d[i].USUMOD);
                                $('#MainContent_lblusuaprobado').html(data.d[i].USUAPRO);
                                $('#MainContent_lblfechaelaborado').html((moment(data.d[i].FECRE).format("DD/MM/YYYY")));
                                $('#MainContent_lblfechamodificacion').html((moment(data.d[i].FEMOD).format("DD/MM/YYYY")));
                                $('#MainContent_lblfechaaprobacion').html((moment(data.d[i].FEAPRO).format("DD/MM/YYYY")));
                            }
                        } else {

                            alert("no se encontro registro");
                        }


                    },
                    error: function (response) {
                        if (response.length != 0)
                            console.log(response);
                    }
                });
            }

            function cabecerae(codigo) {
                $.ajax({

                    type: "POST",
                    url: "EjecucionProgramacion.aspx/LISTARUNO",
                    data: "{ 'CODATA': '" + codigo + "' }",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {

                        if (data.d.length > 0) {

                            for (var i = 0; i < data.d.length; i++) {

                                $('#MainContent_lblbancocuenta').text(data.d[i].BANCOCUENTA);
                                $('#MainContent_lblcodagenciae').html(data.d[i].AGENCIA);
                                $('#MainContent_lblagenciae').html(data.d[i].AGENCIA2);
                                $('#MainContent_txtprogramacione').val(data.d[i].numope);
                                $('#MainContent_lblconceptoe').html(data.d[i].CONCEPTO);
                                $('#MainContent_lbltipopagoe').html(data.d[i].tipopago);
                                $('#MainContent_lblmonedae').html(data.d[i].moneda);
                                $('#MainContent_txttipocambioe').val(data.d[i].TIPOCAMBIO);
                                $('#MainContent_txtmontoe').val(data.d[i].IMPORTE);
                                $('#MainContent_txtfechaprogramacione').val((moment(data.d[i].fecah).format("DD/MM/YYYY")));
                                if (data.d[i].TIPODETRACCION != null) {
                                    long = data.d[i].TIPODETRACCION.length;
                                    $('#MainContent_lbldetraccione').html(data.d[i].TIPODETRACCION.substring(0, long - 15));
                                }
                                else {
                                    $('#MainContent_lbldetraccione').html(data.d[i].TIPODETRACCION);
                                }
                                $('#MainContent_lblcoddetraccione').html(data.d[i].TASADETRACCION);
                                $('#MainContent_lbldepartamentoe').html(data.d[i].DEPARTAMENTO);
                                $('#MainContent_lblcodbancoe').html(data.d[i].CODBANCO);
                                $('#MainContent_lblbancoe').html(data.d[i].BANCO);
                                $('#MainContent_txtestadoe').val(data.d[i].ESTADO);
                               
                            }
                        } else {

                            alert("no se encontro registro");
                        }


                    },
                    error: function (response) {
                        if (response.length != 0)
                            console.log(response);
                    }
                });

            }

            $(".tipocambio").click(function () {

                if ((document.getElementById("<%=rbventa.ClientID%>").checked == true)) {
                    tipocambioVenta();

                }
                if ((document.getElementById("<%=rbcompra.ClientID%>").checked == true)) {
                    tipocambiocompra();

                }

            });

            function tipocambiocompra() {
                var fecemi = moment($("#MainContent_txtfechatransaccion").val(), "DD/MM/YYYY");
                fecemi = fecemi == null ? null : new Date(fecemi);
                var com = {};
                com.XDATE = fecemi;
                $.ajax({

                    type: "POST",
                    url: "EjecucionProgramacion.aspx/obetenertcambiocvEdgar",
                    data: '{COM: ' + JSON.stringify(com) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        if (data.d.length > 0) {

                            for (var i = 0; i < data.d.length; i++) {

                                $('#MainContent_txttipocamb').val(data.d[i].XMEIMP);

                            }

                        }

                    },
                    error: function (data) {
                        if (data.length != 0)
                            alert(data);
                    }
                });
            }
            function tipocambioVenta() {
                var fecemi = moment($("#MainContent_txtfechatransaccion").val(), "DD/MM/YYYY");
                fecemi = fecemi == null ? null : new Date(fecemi);
                var com = {};
                com.XDATE = fecemi;
                $.ajax({

                    type: "POST",
                    url: "ProgramacionPagos.aspx/obetenertcambiocvEdgar",
                    data: '{COM: ' + JSON.stringify(com) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        if (data.d.length > 0) {

                            for (var i = 0; i < data.d.length; i++) {

                                $('#MainContent_txttipocamb').val(data.d[i].XMEIMP2);

                            }

                        }

                    },
                    error: function (data) {
                        if (data.length != 0)
                            alert(data);
                    }
                });
            }

            function tipocambioVenta1() {
                var tc = 0;
                var fecemi = moment($("#MainContent_txtfechatransaccion").val(), "DD/MM/YYYY");
                fecemi = fecemi == null ? null : new Date(fecemi);
                var com = {};
                com.XDATE = fecemi;
                $.ajax({

                    type: "POST",
                    url: "ProgramacionPagos.aspx/obetenertcambiocvEdgar",
                    data: '{COM: ' + JSON.stringify(com) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        if (data.d.length > 0) {

                            for (var i = 0; i < data.d.length; i++) {

                                tc = (data.d[i].XMEIMP2);

                            }

                        }

                    },
                    error: function (data) {
                        if (data.length != 0)
                            alert(data);
                    }
                });
                return { tc};
            }
             $(".fecha").change(function () {
                document.getElementById("<%= rbventa.ClientID %>").checked = true;
                tipocambioVenta()
            });

            function formato_numero(numero, decimales, separador_decimal, separador_miles) { // v2007-08-06
                numero = parseFloat(numero);
                if (isNaN(numero)) {
                    return "";
                }

                if (decimales !== undefined) {

                    numero = numero.toFixed(decimales);
                }
                numero = numero.toString().replace(".", separador_decimal !== undefined ? separador_decimal : ",");

                return numero;
            }
            // FUNCIONES PARA EXTRACCION E INSERCION
            function Extraecabecerae(codigo, comprobante) {
                //console.log(comprobante);
                var fecha = new Date();
                var annio = fecha.getFullYear().toString();
                var GC = {};
                var DETACAB = {};

                $.ajax({

                    type: "POST",
                    url: "EjecucionProgramacion.aspx/EXTRAERPARAINSERTARCAB",
                    data: "{ 'CODATA': '" + codigo + "' }",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {

                        if (data.d.length > 0) {
                            for (var i = 0; i < data.d.length; i++) {
                                GC.GC_CCODAGE = data.d[i].GC_CCODAGE;
                                GC.GC_CNUMOPE = data.d[i].GC_CNUMOPE;
                                GC.GC_DFECPRO =(moment(data.d[i].GC_DFECPRO, "DD/MM/YYYY"));
                                GC.GC_CCODCON = data.d[i].GC_CCODCON.trim();
                                GC.GC_CTIPPAG = data.d[i].GC_CTIPPAG;
                                GC.GC_CCODBAN = data.d[i].GC_CCODBAN.trim();
                                GC.GC_CCODMON = data.d[i].GC_CCODMON;
                                GC.GC_CCODDEP = data.d[i].GC_CCODDEP;
                                GC.GC_CNUMLOT = generarlote().formato;
                                GC.GC_CTASDET = data.d[i].GC_CTASDET;
                                GC.GC_NTIPCAM = data.d[i].GC_NTIPCAM;
                                GC.GC_NMONPRO = data.d[i].GC_NMONPRO;
                                GC.GC_CESTADO = "E";
                                GC.GC_CUSUCRE = data.d[i].GC_CUSUCRE;
                                GC.GC_DFECCRE = (moment(data.d[i].GC_DFECCRE, "DD/MM/YYYY"));
                                GC.GC_CUSUMOD = data.d[i].GC_CUSUMOD;
                                GC.GC_DFECMOD =(moment(data.d[i].GC_DFECMOD, "DD/MM/YYYY"));
                                GC.GC_CUSUAPR = data.d[i].GC_CUSUAPR;
                                GC.GC_DFECAPR = (moment(data.d[i].GC_DFECAPR, "DD/MM/YYYY"));
                                GC.GC_CCHQCOR = annio.toString().substring(2, 4) + ""+ Operacion.mask('ddlsubdiario').val()+" " +comprobante;
                                GC.GC_CVOUCOR = Operacion.mask('ddlsubdiario').val()+" -" + comprobante;
                                GC.GC_DFECEJE = fecha;
                                GC.GC_CUSUEJE = $('#MainContent_lblusuario').html();
                                GC.GC_CNOPEDE = "-";
                                GC.GC_DFEDEPD = null;
                                GC.CCOMPRO = comprobante; // ESTE ES UN  DATO ADICIONAL QUE NO ESTA EN LA TABLA PARA CAPTURAR EL NUMERO DE COMPROBANTE
                            }
                            InsertaCabecera(GC);// INSERTA CABECERA EJECUCION
                            // inserta cabecera de comprobante
                            DETACAB.CSUBDIA = Operacion.mask('ddlsubdiario').val();
                            DETACAB.CCOMPRO = comprobante;
                            DETACAB.CFECCOM = annio.substr(2, 2) + (Number(fecha.getMonth() + 1) < 10 ? "0" + (fecha.getMonth() + 1) : (fecha.getMonth() + 1)) + fecha.getDate();
                            DETACAB.CCODMON = GC.GC_CCODMON;
                            DETACAB.CSITUA = "F"; //valor fijo q significxa finalizado
                            DETACAB.CTIPCAM = $('#MainContent_txttipocamb').val();
                            DETACAB.CGLOSA = "CARGO BANCARIO NRO" + $("#MainContent_txtprogramacione").val();
                            DETACAB.CTOTAL = Number($("#MainContent_txtmontoe").val()).toFixed(2);
                            DETACAB.CTIPO = (document.getElementById("<%=rbventa.ClientID%>").checked == true ? "V": document.getElementById("<%=rbcompra.ClientID%>").checked == true? "M": "V");
                            DETACAB.CFLAG = "N";  //NO SE DE DONDE SALE
                            DETACAB.CDATE = fecha;//(moment(fecha,"DD/MM/YYYY"));
                            DETACAB.CHORA = fecha.getHours() + ":" + ((fecha.getMinutes()).toString().length<2? "0"+ fecha.getMinutes(): fecha.getMinutes());
                            DETACAB.CUSER = $("#MainContent_lblusuario").html();
                            DETACAB.CFECCAM = "      "; // NO SE 
                            DETACAB.CORIG = "CP";// ORIGEN SISPAG
                            DETACAB.CFORM = "A";//SELECT * FROM CP0003TABL where (TG_CODIGO='A' OR TG_CODIGO='M') AND TG_INDICE='76'
                            DETACAB.CTIPCOM = "11";// PROGRAMACION INTERNA DE SISPAG 
                            DETACAB.CEXTOR = " ";// AL PARECER ES LA OPERcion de extorno 
                            DETACAB.CFECCOM2 = fecha;//(moment(fecha,"DD/MM/YYYY"));
                            DETACAB.CFECCAM2 = null;//(moment(fecha,"DD/MM/YYYY"));
                            DETACAB.CMEMO = " ";// NO SE pero en el ultimo comp'robante estaba vacio
                            DETACAB.CSERCER = "    ";// SELECT * FROM CT0003TABL where TCOD='S1' AND (TCLAVE='001' OR TCLAVE='002' OR TCLAVE='003')
                            DETACAB.CNUMCER = "          ";// NO SE pero en el ultimo comp'robante estaba vacio
                            //console.log(DETACAB);
                            InsertarCabComprobante(DETACAB); // INSERTA CABECERA COMPROBANTE
                        } else {

                            //alert("no se encontro registro");
                        }
                    },
                    error: function (response) {
                        if (response.length != 0)
                            console.log(response);
                    }
                });

            }



            function ExtraedetalleparaEliminarDetalle() {
                var GD = {};
                var pago = {};
                var f = new Date();
                var dia = "";
                var mes = "";
                var annio = "";
                var DETADC = {};
                var codigo = Operacion.mask('txtprogramacione').val();
               
                var annioven = "";
                var aannio = "";
                annio = Number(f.getFullYear()).toString();
                $.ajax({

                    type: "POST",
                    url: "EjecucionProgramacion.aspx/EXTRAERPARAINSERTARDET",
                    data: "{ 'CODATA': '" + codigo + "' }",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        if (data.d.length > 0) {
                            for (var i = 0; i < data.d.length; i++) {
                               
                                GD.GD_CCODAGE = data.d[i].GD_CCODAGE;
                                GD.GD_CNUMOPE = data.d[i].GD_CNUMOPE;
                                GD.GD_CSECUE = data.d[i].GD_CSECUE;
                                EliminaDetalle(GD.GD_CSECUE);
                            }

                        } else {

                            alert("no se encontro registro PARA DETALLE COMPROBANTE");
                        }
                    },
                    error: function (response) {
                        if (response.length != 0)
                            console.log(response);
                    }
                });
            }

             

            function ExtraeparaBalh(COMPROBANTE) {
                var CODATA = {};
                CODATA.DCOMPRO = COMPROBANTE;
                CODATA.DSUBDIA = Operacion.mask('ddlsubdiario').val();
                $.ajax({
                    type: "POST",
                    url: "EjecucionProgramacion.aspx/LISTARPARABALH",
                    data: '{CODATA: ' + JSON.stringify(CODATA) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        if (data.d.length > 0) {
                            var row = $("[id*=GridView2] tr:last-child").clone(true);
                            $("[id*=GridView2] tr").not($("[id*=GridView2] tr:first-child")).remove();

                            for (var i = 0; i < data.d.length; i++) {
                                $("td", row).eq(0).html(data.d[i].CUENTA);
                                $("td", row).eq(1).html(data.d[i].FECHA);
                                $("td", row).eq(2).html(Operacion.mround(Number(data.d[i].SUMASOLESDEBE), 2));
                                $("td", row).eq(3).html(Operacion.mround(Number(data.d[i].SUMASOLESHABER),2));
                                $("td", row).eq(4).html(Operacion.mround(Number(data.d[i].SUMADOLARESDEBE),2));
                                $("td", row).eq(5).html(Operacion.mround(Number(data.d[i].SUMADOLARESHABER), 2));
                                $("td", row).eq(6).html(data.d[i].TIPODOPC);

                                $("[id*=GridView2]").append(row);
                                row = $("[id*=GridView2] tr:last-child").clone(true);
                            }

                        } else {

                            var row = $("[id*=GridView2] tr:last-child").clone(true);
                            $("[id*=GridView2] tr").not($("[id*=GridView2] tr:first-child")).remove();

                            $("td", row).eq(1).html("");
                            $("td", row).eq(2).html("");
                            $("td", row).eq(3).html("");
                            $("td", row).eq(4).html("");
                            $("td", row).eq(5).html("");
                            $("td", row).eq(6).html("");
                            $("[id*=GridView2]").append(row);
                            alert("no se encontro registro");
                        }
                    },
                    error: function (response) {
                        if (response.length != 0)
                            console.log(response);
                    }
                });
               
            }


            function ExtraedetalleparaComrobante(codigo, comprobante) {
                var GD = {};
                var pago = {};
                var f = new Date();
                var dia = "";
                var mes = "";
                var annio = "";
                var DETADC = {};
                var cont = 0;
               // alert(codigo+"-"+comprobante)

                var annioven = "";
                var aannio = "";
                var i = 0;
                annio = Number(f.getFullYear()).toString();
                $.ajax({

                    type: "POST",
                    url: "EjecucionProgramacion.aspx/EXTRAERPARAINSERTARDET",
                    data: "{ 'CODATA': '" + codigo + "' }",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        if (data.d.length > 0) {
                            for ( i = 0; i < data.d.length; i++) {
                                //para insertar en la cabecera
                                GD.GD_CCODAGE = data.d[i].GD_CCODAGE;
                                GD.GD_CNUMOPE = data.d[i].GD_CNUMOPE;
                                GD.GD_CSECUE = data.d[i].GD_CSECUE;
                                GD.GD_CVANEXO = data.d[i].GD_CVANEXO;
                                GD.GD_CCODIGO = data.d[i].GD_CCODIGO;
                                GD.GD_CTIPDOC = data.d[i].GD_CTIPDOC;
                                GD.GD_CNUMDOC = data.d[i].GD_CNUMDOC;
                                GD.GD_DFECPRO = (moment(data.d[i].GD_DFECPRO, "DD/MM/YYYY"));
                                GD.GD_DFECDOC = (moment(data.d[i].GD_DFECDOC, "DD/MM/YYYY"));
                                GD.GD_DFECVEN = (moment(data.d[i].GD_DFECVEN, "DD/MM/YYYY"));
                                GD.GD_CMONCAR = data.d[i].GD_CMONCAR;
                                GD.GD_NORPROG = data.d[i].GD_NORPROG;
                                GD.GD_NTIPCAM = Number(data.d[i].GD_NMNPROG) / Number(data.d[i].GD_NUSPROG); //$('#MainContent_txttipocamb').val();
                                GD.GD_CCODMON = data.d[i].GD_CCODMON;
                                GD.GD_NUSPROG = data.d[i].GD_NUSPROG;
                                GD.GD_NMNPROG = data.d[i].GD_NMNPROG;
                                GD.GD_CTIPCTA = data.d[i].GD_CTIPCTA;
                                GD.GD_CTIPPRO = data.d[i].GD_CTIPPRO;
                                GD.GD_CNUMCTA = data.d[i].GD_CNUMCTA;
                                GD.GD_CSUBDIA = Operacion.mask('ddlsubdiario').val();
                                GD.GD_CCOMPRO = comprobante;
                                GD.GD_NMNRETE = data.d[i].GD_NMNRETE;
                                GD.GD_NUSRETE = data.d[i].GD_NUSRETE;
                                GD.GD_NORRETE = data.d[i].GD_NORRETE;
                                GD.GD_CRETE = data.d[i].GD_CRETE;
                                GD.GD_NPORRE = data.d[i].GD_NPORRE;
                                GD.GD_CTASDET = data.d[i].GD_CTASDET;
                                GD.GD_CSUBCOM = completarejed(GD).CP_CSUBDIA;
                                GD.GD_CNUMCOM = completarejed(GD).CP_CCOMPRO;
                                GD.GD_CSECCOM = completarejed(GD).CP_CSECDET;
                                GD.GD_CTDREF = completarejed(GD).CP_CTIPDOC;
                                GD.GD_CNDREF = completarejed(GD).CP_CNDOCRE;
                                GD.GD_NTCORI = completarejed(GD).CP_NTIPCAM;
                                GD.GD_CNOCONS = "";
                                annio = Number(f.getFullYear()).toString();

                                // PARA INSERTAR EN EL DETALLE
                                DETADC.DSUBDIA = $('#MainContent_ddlsubdiario').val();
                                DETADC.DCOMPRO = comprobante;
                                if (Number((f.getMonth() + 1)) < 10) {
                                    mes = "0" + "" + (f.getMonth() + 1);
                                }
                                else {
                                    mes = (f.getMonth() + 1);
                                }
                                if (Number(f.getDate()) < 10) {
                                    dia = "0" + "" + f.getDate();
                                }
                                else {
                                    dia = f.getDate();
                                }

                                var DFECDOC = (moment(data.d[i].GD_DFECDOC, "DD/MM/YYYY"));
                                DFECDOC = new Date(DFECDOC);
                                aannio = Number(DFECDOC.getFullYear()).toString();

                                var DFECVEN = (moment(data.d[i].GD_DFECVEN, "DD/MM/YYYY"));
                                DFECVEN = new Date(DFECVEN);
                                annioven = Number(DFECVEN.getFullYear()).toString();

                                for (var k = 0; k <= 3; k++) {  // numero de items en la tabla detalle comprobante.
                                   
                                    if (k == 1) {
                                        cont = cont + 1;
                                        //alert(cont);
                                       // DETADC.indicador = "1";
                                        DETADC.DCUENTA = M_ARRAY[0];
                                        DETADC.DCODANE = GD.GD_CCODIGO;
                                        DETADC.DDH = "D";
                                        DETADC.DIMPORT = GD.GD_NMNPROG;
                                        DETADC.DTIPDOC = "FT"; //SELECT * FROM CT0003TABL where TCOD='06'
                                        DETADC.DNUMDOC = data.d[i].GD_CNUMDOC;
                                        DETADC.DFECDOC = aannio.substr(2, 2) + "" + (Number(DFECDOC.getMonth() + 1) < 10 ? "0" + "" + (DFECDOC.getMonth() + 1) : DFECDOC.getMonth() + 1) + "" + (Number(DFECDOC.getDate()) < 10 ? "0" + "" + DFECDOC.getDate() : DFECDOC.getDate());
                                        DETADC.DFECVEN = annioven.substr(2, 2) + "" + (Number(DFECVEN.getMonth() + 1) < 10 ? "0" + "" + (DFECVEN.getMonth() + 1) : DFECVEN.getMonth() + 1) + "" + (Number(DFECVEN.getDate()) < 10 ? "0" + "" + DFECVEN.getDate() : DFECVEN.getDate());
                                        DETADC.DAREA = ""; // DETERMINADA POR EL AREA SELECCIONADA EN EL COMBO Y SE APLICA SOLO EN EL TOTAL
                                        DETADC.DXGLOSA = (GD.GD_CSUBCOM.trim() + " " + GD.GD_CNUMCOM.trim() + " " + datoscompletardetcomprobante(GD).AC_CNOMBRE.trim()).substr(0,29); // corregir
                                        DETADC.DUSIMPOR = Operacion.mround((Number(GD.GD_NMNPROG) / Number($("#MainContent_txttipocamb").val())),2);
                                        DETADC.DMNIMPOR = Operacion.mround(Number(GD.GD_NMNPROG),2);
                                        DETADC.DCODARC = "01";
                                        DETADC.DFECDO2 = (moment(DFECDOC,"DD/MM/YYYY")); 
                                        DETADC.DFECVEN2 = DFECVEN; //(moment(DFECVEN).format("DD/MM/YYYY"));
                                        DETADC.DVANEXO = data.d[i].GD_CVANEXO; // ASIGNADO POR EL PROVEEDOR DE LA TABLA MAES.
                                        DETADC.DTIPDOR = ""; // AJ CUANDO ES POR GANANCIA O PERDIDA POR DIFERENCIA DE PAGO para el total
                                        DETADC.DTIPTAS = GD.GD_CTASDET;
                                        DETADC.DMEDPAG = ""; // SE TOMA DEL COMBO Y SOLO SE APLICA PARA EL REGISTRO DEL TOTAL

                                        //campos comunes
                                        DETADC.DSECUE = Operacion.cadenaMascara(cont, 4);
                                        DETADC.DFECCOM = (annio.substr(2, 2) + "" + mes + "" + dia);
                                        DETADC.DCODMON = GD.GD_CCODMON;
                                        DETADC.CSITUA = "F"; //FINALIZADO PENDIENTE
                                        DETADC.CTIPCAM = $("#MainContent_txttipocamb").val();
                                        DETADC.DCENCOS = " ";
                                        DETADC.DFLAG = "N";
                                        DETADC.DDATE = (moment($("#MainContent_txtfechatransaccion").val(),"DD/MM/YYYY"));
                                        DETADC.DFECCOM2 = (moment($("#MainContent_txtfechatransaccion").val(),"DD/MM/YYYY"));
                                        DETADC.DCODANE2 = "";
                                        DETADC.DVANEXO2 = "";
                                        DETADC.DTIPCAM = 0;
                                        DETADC.DCANTID = 0;
                                        DETADC.DCTAORI = "";
                                        DETADC.DCCODMON = "";
                                        DETADC.DCIMPORT = 0;
                                        DETADC.DCNUMDOC = "";
                                        DETADC.DCESTADO = "";
                                        DETADC.DCCONFEC2 = null;
                                        DETADC.DCCONNRO = " ";
                                        DETADC.DCCONPRO = null;
                                        DETADC.DCNUMEST = "";
                                        DETADC.DCITEM = "";
                                        DETADC.DCIMPORTB = 0;
                                        DETADC.DCANO = "";
                                        DETADC.DNUMDOR = "";
                                        DETADC.DFECDO2 = null;
                                        DETADC.DIMPTAS = 0;
                                        DETADC.DIMPBMN = 0;
                                        DETADC.DIMPBUS = 0;
                                        DETADC.DMONCOM = "";
                                        DETADC.DCOLCOM = "";
                                        DETADC.DBASCOM = 0;
                                        DETADC.DINACOM = 0;
                                        DETADC.DIGVCOM = 0;
                                        DETADC.DTPCONV = "";
                                        DETADC.DFLGCOM = "";
                                        DETADC.DANECOM = "";
                                        DETADC.DTIPACO = "";
                                        DETADC.DTIPDO2 = "";
                                        DETADC.DNUMDO2 = "";
                                        DETADC.DRETE = "";
                                        DETADC.DPORRE = 0;
                                        InsertarDetComprobante(DETADC, "1");
                                       
                                    }
                                                             


                                    if (k == 2) {
                                        DETADC.DCUENTA =  M_ARRAY[0];
                                        DETADC.DCODANE = GD.GD_CCODIGO;
                                        cont = cont + 1;

                                        if ((Number(GD.GD_NMNPROG) / Number($('#MainContent_txttipocamb').val()))
                                            <
                                           (Number(data.d[i].GD_NMNPROG) / Number(GD.GD_NTCORI))) {
                                            DETADC.DDH = "D";
                                            DETADC.DXGLOSA = "Ganancia Diferencia Cambio";
                                        }
                                        if ((Number(GD.GD_NMNPROG) / Number($('#MainContent_txttipocamb').val()))
                                            >
                                            (Number(data.d[i].GD_NMNPROG) / Number(GD.GD_NTCORI))) {
                                            DETADC.DDH = "H";
                                            DETADC.DXGLOSA = "Perdida Diferencia Cambio";

                                        }

                                        DETADC.DIMPORT = 0;
                                        DETADC.DTIPDOC = "FT";
                                        DETADC.DNUMDOC = data.d[i].GD_CNUMDOC;
                                        DETADC.DFECDOC = "";
                                        DETADC.DFECVEN = "";
                                        DETADC.DAREA = "  ";
                                        DETADC.DUSIMPOR = Operacion.mround((Math.abs((Number(GD.GD_NMNPROG) / Number(GD.GD_NTCORI)) - (Number(GD.GD_NMNPROG) / Number($('#MainContent_txttipocamb').val())))),2);
                                        DETADC.DMNIMPOR = 0;
                                        DETADC.DCODARC = "01";
                                        DETADC.DFECDOC2 = null;
                                        DETADC.DFECVEN2 = null;
                                        DETADC.DVANEXO = datoscompletardetcomprobante(GD).AC_CVANEXO;
                                        DETADC.DTIPDOR = "AJ";
                                        DETADC.DTIPTAS = "";
                                        DETADC.DMEDPAG = "";
                                        //campos comunes
                                        DETADC.DSECUE = Operacion.cadenaMascara(cont, 4);
                                        DETADC.DFECCOM = (annio.substr(2, 2) + "" + mes + "" + dia);
                                        DETADC.DCODMON = GD.GD_CCODMON;
                                        DETADC.CSITUA = "F";
                                        DETADC.CTIPCAM = $("#MainContent_txttipocamb").val();
                                        DETADC.DCENCOS = " ";
                                        DETADC.DFLAG = "N"; // DEPENDE DE LA TABLA : SELECT * FROM CT0003TABL where TCOD='R7' OR TCOD='41'
                                        DETADC.DDATE = (moment($("#MainContent_txtfechatransaccion").val(), "DD/MM/YYYY"));
                                        DETADC.DFECCOM2 = (moment($("#MainContent_txtfechatransaccion").val(), "DD/MM/YYYY"));
                                        DETADC.DCODANE2 = "";
                                        DETADC.DVANEXO2 = "";
                                        DETADC.DTIPCAM = 0;
                                        DETADC.DCANTID = 0;
                                        DETADC.DCTAORI = "";
                                        DETADC.DCCODMON = "";
                                        DETADC.DCIMPORT = 0;
                                        DETADC.DCNUMDOC = "";
                                        DETADC.DCESTADO = "";
                                        DETADC.DCCONFEC2 = null;
                                        DETADC.DCCONNRO = "";
                                        DETADC.DCCONPRO = null;
                                        DETADC.DCNUMEST = "";
                                        DETADC.DCITEM = "";
                                        DETADC.DCIMPORTB = 0;
                                        DETADC.DCANO = "";
                                        DETADC.DNUMDOR = "";
                                        DETADC.DFECDO2 = null;
                                        DETADC.DIMPTAS = 0;
                                        DETADC.DIMPBMN = 0;
                                        DETADC.DIMPBUS = 0;
                                        DETADC.DMONCOM = "";
                                        DETADC.DCOLCOM = "";
                                        DETADC.DBASCOM = 0;
                                        DETADC.DINACOM = 0;
                                        DETADC.DIGVCOM = 0;
                                        DETADC.DTPCONV = "";
                                        DETADC.DFLGCOM = "";
                                        DETADC.DANECOM = "";
                                        DETADC.DTIPACO = "";
                                        DETADC.DTIPDO2 = "";
                                        DETADC.DNUMDO2 = "";
                                        DETADC.DRETE = "";
                                        DETADC.DPORRE = 0;
                                        InsertarDetComprobante(DETADC, "1");
                                      }


                                    if (k == 3) {
                                        cont = cont + 1;
                                       DETADC.DCODANE = data.d[i].GD_CCODIGO;
                                        if ((Number(GD.GD_NMNPROG) / Number($('#MainContent_txttipocamb').val()))
                                            <
                                           (Number(GD.GD_NMNPROG) / Number(GD.GD_NTCORI))) {
                                            DETADC.DDH = "H";
                                            DETADC.DCUENTA =  M_ARRAY[2];
                                        }
                                        if ((Number(data.d[i].GD_NMNPROG) / Number($('#MainContent_txttipocamb').val()))
                                            >
                                            (Number(GD.GD_NMNPROG) / Number(GD.GD_NTCORI))) {
                                            DETADC.DDH = "D";
                                            DETADC.DCUENTA =  M_ARRAY[1];
                                        }
                                        DETADC.DIMPORT = 0;
                                        DETADC.DTIPDOC = "FT";
                                        DETADC.DNUMDOC = GD.GD_CNUMDOC.trim();
                                        DETADC.DFECDOC = "";
                                        DETADC.DFECVEN = "";
                                        DETADC.DAREA = "";
                                        DETADC.DXGLOSA = "Ajuste Diferencia Cambio";
                                        DETADC.DMNIMPOR = 0;
                                        DETADC.DUSIMPOR = Operacion.mround((Math.abs((Number(GD.GD_NMNPROG) / Number(GD.GD_NTCORI)) - (Number(GD.GD_NMNPROG) / Number($('#MainContent_txttipocamb').val())))), 2);
                                        DETADC.DCODARC = "";
                                        DETADC.DFECDOC2 = null;
                                        DETADC.DFECVEN2 = null;
                                        DETADC.DVANEXO = datoscompletardetcomprobante(GD).AC_CVANEXO;
                                        DETADC.DTIPDOR = "";
                                        DETADC.DTIPTAS = "";
                                        DETADC.DMEDPAG = "";

                                        //campos comunes
                                        DETADC.DSECUE = Operacion.cadenaMascara(cont, 4);
                                        DETADC.DFECCOM = (annio.substr(2, 2) + "" + mes + "" + dia);
                                        DETADC.DCODMON = GD.GD_CCODMON;
                                        DETADC.CSITUA = "F";
                                        DETADC.CTIPCAM = $("#MainContent_txttipocamb").val();
                                        DETADC.DCENCOS = ""; 
                                        DETADC.DFLAG = "N";
                                        DETADC.DDATE = (moment($("#MainContent_txtfechatransaccion").val(),"DD/MM/YYYY"));
                                        DETADC.DFECCOM2 = (moment($("#MainContent_txtfechatransaccion").val(),"DD/MM/YYYY"));
                                        DETADC.DCODANE2 = "";
                                        DETADC.DVANEXO2 = "";
                                        DETADC.DTIPCAM = 0;
                                        DETADC.DCANTID = 0;
                                        DETADC.DCTAORI = "";
                                        DETADC.DCCODMON = "";
                                        DETADC.DCIMPORT = 0;
                                        DETADC.DCNUMDOC = "";
                                        DETADC.DCESTADO = "";
                                        DETADC.DCCONFEC2 = null;
                                        DETADC.DCCONNRO = "";
                                        DETADC.DCCONPRO = null;
                                        DETADC.DCNUMEST = "";
                                        DETADC.DCITEM = "";
                                        DETADC.DCIMPORTB = 0;
                                        DETADC.DCANO = "";
                                        DETADC.DNUMDOR = " ";
                                        DETADC.DFECDO2 = null;
                                        DETADC.DIMPTAS = 0;
                                        DETADC.DIMPBMN = 0;
                                        DETADC.DIMPBUS = 0;
                                        DETADC.DMONCOM = "";
                                        DETADC.DCOLCOM = "";
                                        DETADC.DBASCOM = 0;
                                        DETADC.DINACOM = 0;
                                        DETADC.DIGVCOM = 0;
                                        DETADC.DTPCONV = "";
                                        DETADC.DFLGCOM = "";
                                        DETADC.DANECOM = "";
                                        DETADC.DTIPACO = "";
                                        DETADC.DTIPDO2 = "";
                                        DETADC.DNUMDO2 = "";
                                        DETADC.DRETE = "";
                                        DETADC.DPORRE = 0;
                                        InsertarDetComprobante(DETADC,"1");
                                      
                                    }
                                }                               
                            }
                            if(Operacion.mask('lblsobrante').text()=="1"){
                                                           
                                // para insertar en caso de ajuste adicional adicional

                            for (i = 0; i < 1; i++) {
                                //para insertar en la cabecera
                                GD.GD_CCODAGE = data.d[i].GD_CCODAGE;
                                GD.GD_CNUMOPE = data.d[i].GD_CNUMOPE;
                                GD.GD_CSECUE = data.d[i].GD_CSECUE;
                                GD.GD_CVANEXO = data.d[i].GD_CVANEXO;
                                GD.GD_CCODIGO = data.d[i].GD_CCODIGO;
                                GD.GD_CTIPDOC = data.d[i].GD_CTIPDOC;
                                GD.GD_CNUMDOC = data.d[i].GD_CNUMDOC;
                                GD.GD_DFECPRO = (moment(data.d[i].GD_DFECPRO, "DD/MM/YYYY"));
                                GD.GD_DFECDOC = (moment(data.d[i].GD_DFECDOC, "DD/MM/YYYY"));
                                GD.GD_DFECVEN = (moment(data.d[i].GD_DFECVEN, "DD/MM/YYYY"));
                                GD.GD_CMONCAR = data.d[i].GD_CMONCAR;
                                GD.GD_NORPROG = data.d[i].GD_NORPROG;
                                GD.GD_NTIPCAM = Number(data.d[i].GD_NMNPROG) / Number(data.d[i].GD_NUSPROG); //$('#MainContent_txttipocamb').val();
                                GD.GD_CCODMON = data.d[i].GD_CCODMON;
                                GD.GD_NUSPROG = data.d[i].GD_NUSPROG;
                                GD.GD_NMNPROG = data.d[i].GD_NMNPROG;
                                GD.GD_CTIPCTA = data.d[i].GD_CTIPCTA;
                                GD.GD_CTIPPRO = data.d[i].GD_CTIPPRO;
                                GD.GD_CNUMCTA = data.d[i].GD_CNUMCTA;
                                GD.GD_CSUBDIA = Operacion.mask('ddlsubdiario').val();
                                GD.GD_CCOMPRO = comprobante;
                                GD.GD_NMNRETE = data.d[i].GD_NMNRETE;
                                GD.GD_NUSRETE = data.d[i].GD_NUSRETE;
                                GD.GD_NORRETE = data.d[i].GD_NORRETE;
                                GD.GD_CRETE = data.d[i].GD_CRETE;
                                GD.GD_NPORRE = data.d[i].GD_NPORRE;
                                GD.GD_CTASDET = data.d[i].GD_CTASDET;
                                GD.GD_CSUBCOM = completarejed(GD).CP_CSUBDIA;
                                GD.GD_CNUMCOM = completarejed(GD).CP_CCOMPRO;
                                GD.GD_CSECCOM = completarejed(GD).CP_CSECDET;
                                GD.GD_CTDREF = completarejed(GD).CP_CTIPDOC;
                                GD.GD_CNDREF = completarejed(GD).CP_CNDOCRE;
                                GD.GD_NTCORI = completarejed(GD).CP_NTIPCAM;
                                GD.GD_CNOCONS = "";
                                annio = Number(f.getFullYear()).toString();

                                DETADC.DSUBDIA = $('#MainContent_ddlsubdiario').val();
                                DETADC.DCOMPRO = comprobante;
                                if (Number((f.getMonth() + 1)) < 10) {
                                    mes = "0" + "" + (f.getMonth() + 1);
                                }
                                else {
                                    mes = (f.getMonth() + 1);
                                }
                                if (Number(f.getDate()) < 10) {
                                    dia = "0" + "" + f.getDate();
                                }
                                else {
                                    dia = f.getDate();
                                }

                               aannio = Number(DFECDOC.getFullYear()).toString();

                               for (var k = 0; k <= 3; k++) {  // numero de items en la tabla detalle comprobante.

                                    if (k == 3) {
                                        cont = cont + 1;
                                        DETADC.DCODANE ="";
                                      
                                        DETADC.DDH = Operacion.mask('lbldebehaber').text();
                                        if (DETADC.DDH=="D") {
                                            DETADC.DCUENTA = M_ARRAY[2];
                                        }
                                        if (DETADC.DDH == "H") {
                                            DETADC.DCUENTA = M_ARRAY[1];
                                        }
                                        DETADC.DIMPORT = 0;
                                        DETADC.DTIPDOC = "";
                                        DETADC.DNUMDOC ="";
                                        DETADC.DFECDOC = "";
                                        DETADC.DFECVEN = "";
                                        DETADC.DAREA = "";
                                        DETADC.DXGLOSA = "";
                                        DETADC.DMNIMPOR = 0;
                                        DETADC.DUSIMPOR =Number(Operacion.mask('lblmontosobrante').text());
                                        DETADC.DCODARC = "";
                                        DETADC.DFECDOC2 = null;
                                        DETADC.DFECVEN2 = null;
                                        DETADC.DVANEXO = "";
                                        DETADC.DTIPDOR = "";
                                        DETADC.DTIPTAS = "";
                                        DETADC.DMEDPAG = "";

                                        //campos comunes
                                        DETADC.DSECUE = Operacion.cadenaMascara(cont, 4);
                                        DETADC.DFECCOM = (annio.substr(2, 2) + "" + mes + "" + dia);
                                        DETADC.DCODMON = GD.GD_CCODMON;
                                        DETADC.CSITUA = "F";
                                        DETADC.CTIPCAM = $("#MainContent_txttipocamb").val();
                                        DETADC.DCENCOS = "";
                                        DETADC.DFLAG = "N";
                                        DETADC.DDATE = (moment($("#MainContent_txtfechatransaccion").val(), "DD/MM/YYYY"));
                                        DETADC.DFECCOM2 = (moment($("#MainContent_txtfechatransaccion").val(), "DD/MM/YYYY"));
                                        DETADC.DCODANE2 = "";
                                        DETADC.DVANEXO2 = "";
                                        DETADC.DTIPCAM = 0;
                                        DETADC.DCANTID = 0;
                                        DETADC.DCTAORI = "";
                                        DETADC.DCCODMON = "";
                                        DETADC.DCIMPORT = 0;
                                        DETADC.DCNUMDOC = "";
                                        DETADC.DCESTADO = "";
                                        DETADC.DCCONFEC2 = null;
                                        DETADC.DCCONNRO = "";
                                        DETADC.DCCONPRO = null;
                                        DETADC.DCNUMEST = "";
                                        DETADC.DCITEM = "";
                                        DETADC.DCIMPORTB = 0;
                                        DETADC.DCANO = "";
                                        DETADC.DNUMDOR = " ";
                                        DETADC.DFECDO2 = null;
                                        DETADC.DIMPTAS = 0;
                                        DETADC.DIMPBMN = 0;
                                        DETADC.DIMPBUS = 0;
                                        DETADC.DMONCOM = "";
                                        DETADC.DCOLCOM = "";
                                        DETADC.DBASCOM = 0;
                                        DETADC.DINACOM = 0;
                                        DETADC.DIGVCOM = 0;
                                        DETADC.DTPCONV = "";
                                        DETADC.DFLGCOM = "";
                                        DETADC.DANECOM = "";
                                        DETADC.DTIPACO = "";
                                        DETADC.DTIPDO2 = "";
                                        DETADC.DNUMDO2 = "";
                                        DETADC.DRETE = "";
                                        DETADC.DPORRE = 0;
                                        InsertarDetComprobante(DETADC, "2");

                                    }


                                   
                                }
                            }

                            }
                            if (i <= Number(data.d.length)) {
                            //****************para insertar el total
                            DETADC.DCUENTA = Operacion.mask('lblbancocuenta').text();
                            DETADC.DCODANE = $('#MainContent_lblcodbancoe').text().trim();
                            DETADC.DDH = "H";
                            DETADC.DIMPORT = Operacion.mround(Number(Operacion.mask('txtmontoe').val()),2);
                            DETADC.DTIPDOC = "ND";
                            DETADC.DNUMDOC = (annio.substr(2, 2)) + "" + $("#MainContent_ddlsubdiario").val() + " " + comprobante;
                            DETADC.DFECDOC = aannio.substr(2, 2) + "" + (Number(DFECDOC.getMonth() + 1) < 10 ? "0" + "" + (DFECDOC.getMonth() + 1) : DFECDOC.getMonth() + 1) + "" + (Number(DFECDOC.getDate()) < 10 ? "0" + "" + DFECDOC.getDate() : DFECDOC.getDate());
                            DETADC.DFECVEN = "";
                            DETADC.DAREA = $("#MainContent_ddlarea").val();
                            DETADC.DXGLOSA = "";
                            DETADC.DUSIMPOR = Operacion.mround((Number(Operacion.mask('txtmontoe').val()) / Number($("#MainContent_txttipocamb").val())),2);
                            DETADC.DMNIMPOR = Operacion.mround(Number(Operacion.mask('txtmontoe').val()),2);
                            DETADC.DCODAR = "";
                            DETADC.DFECDOC2 = (moment($("#MainContent_txtfechatransaccion").val(), "DD/MM/YYYY"));
                            DETADC.DFECVEN2 = null;
                            DETADC.DVANEXO = "0";
                            DETADC.DTIPDOR = "";
                            DETADC.DTIPTAS = "";
                            DETADC.DMEDPAG = Operacion.mask('ddlmediopago').val();

                            DETADC.DSECUE = Operacion.cadenaMascara(cont + 1, 4);
                            DETADC.DFECCOM = (annio.substr(2, 2) + "" + mes + "" + dia);
                            DETADC.DCODMON = GD.GD_CCODMON;
                            DETADC.CSITUA = "F";
                            DETADC.CTIPCAM = $("#MainContent_txttipocamb").val();
                            DETADC.DCENCOS = " ";
                            DETADC.DFLAG = "N"; // DEPENDE DE LA TABLA : SELECT * FROM CT0003TABL where TCOD='R7' OR TCOD='41'
                            DETADC.DDATE = (moment($("#MainContent_txtfechatransaccion").val(), "DD/MM/YYYY"));
                            DETADC.DFECCOM2 = (moment($("#MainContent_txtfechatransaccion").val(), "DD/MM/YYYY"));
                            DETADC.DCODANE2 = " ";
                            DETADC.DVANEXO2 = " ";
                            DETADC.DTIPCAM = 0;
                            DETADC.DCANTID = 0;
                            DETADC.DCTAORI = "";
                            DETADC.DCCODMON = "";
                            DETADC.DCIMPORT = 0;
                            DETADC.DCNUMDOC = "";
                            DETADC.DCESTADO = "";
                            DETADC.DCCONFEC2 = null;
                            DETADC.DCCONNRO = "";
                            DETADC.DCCONPRO = null;
                            DETADC.DCNUMEST = "";
                            DETADC.DCITEM = "";
                            DETADC.DCIMPORTB = 0;
                            DETADC.DCANO = "";
                            DETADC.DNUMDOR = "";
                            DETADC.DFECDO2 = null;
                            DETADC.DIMPTAS = 0;
                            DETADC.DIMPBMN = 0;
                            DETADC.DIMPBUS = 0;
                            DETADC.DMONCOM = "";
                            DETADC.DCOLCOM = "";
                            DETADC.DBASCOM = 0;
                            DETADC.DINACOM = 0;
                            DETADC.DIGVCOM = 0;
                            DETADC.DTPCONV = "";
                            DETADC.DFLGCOM = "";
                            DETADC.DANECOM = "";
                            DETADC.DTIPACO = "";
                            DETADC.DTIPDO2 = "";
                            DETADC.DNUMDO2 = "";
                            DETADC.DRETE = "";
                            DETADC.DPORRE = 0;
                           // alert("si es que llega aqui");
                            InsertarDetComprobante(DETADC, "0");
                            /// ****** fin de insercion total
                           
                            }
                        }
                        else {

                            alert("no se encontro registro PARA DETALLE COMPROBANTE");
                        }
                    },
                    error: function (response) {
                        if (response.length != 0)
                            console.log(response);
                    }
                });
            }

            function Extraedetallee(codigo, comprobante) {
                var GD = {};
                var pago = {};
                var f = new Date();
                var dia = "";
                var mes = "";
                var annio = "";
                
                $.ajax({

                    type: "POST",
                    url: "EjecucionProgramacion.aspx/EXTRAERPARAINSERTARDET",
                    data: "{ 'CODATA': '" + codigo + "' }",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        if (data.d.length > 0) {
                            for (var i = 0; i < data.d.length; i++) {
                                //para insertar en la cabecera
                                GD.GD_CCODAGE = data.d[i].GD_CCODAGE;
                                GD.GD_CNUMOPE = data.d[i].GD_CNUMOPE;
                                GD.GD_CSECUE = data.d[i].GD_CSECUE;
                                GD.GD_CVANEXO = data.d[i].GD_CVANEXO;
                                GD.GD_CCODIGO = data.d[i].GD_CCODIGO;
                                GD.GD_CTIPDOC = data.d[i].GD_CTIPDOC;
                                GD.GD_CNUMDOC = data.d[i].GD_CNUMDOC;
                                GD.GD_DFECPRO = (moment(data.d[i].GD_DFECPRO, "DD/MM/YYYY"));
                                GD.GD_DFECDOC = (moment(data.d[i].GD_DFECDOC, "DD/MM/YYYY"));
                                GD.GD_DFECVEN = (moment(data.d[i].GD_DFECVEN, "DD/MM/YYYY"));
                                GD.GD_CMONCAR = data.d[i].GD_CMONCAR;
                                GD.GD_NORPROG = data.d[i].GD_NORPROG;
                                GD.GD_NTIPCAM = Number(data.d[i].GD_NMNPROG) / Number(data.d[i].GD_NUSPROG); //$('#MainContent_txttipocamb').val();
                                GD.GD_CCODMON = data.d[i].GD_CCODMON;
                                GD.GD_NUSPROG = data.d[i].GD_NUSPROG;
                                GD.GD_NMNPROG = data.d[i].GD_NMNPROG;
                                GD.GD_CTIPCTA = data.d[i].GD_CTIPCTA;
                                GD.GD_CTIPPRO = data.d[i].GD_CTIPPRO;
                                GD.GD_CNUMCTA = data.d[i].GD_CNUMCTA;
                                GD.GD_CSUBDIA = Operacion.mask('ddlsubdiario').val();
                                GD.GD_CCOMPRO = comprobante;
                                GD.GD_NMNRETE = data.d[i].GD_NMNRETE;
                                GD.GD_NUSRETE = data.d[i].GD_NUSRETE;
                                GD.GD_NORRETE = data.d[i].GD_NORRETE;
                                GD.GD_CRETE = data.d[i].GD_CRETE;
                                GD.GD_NPORRE = data.d[i].GD_NPORRE;
                                GD.GD_CTASDET = data.d[i].GD_CTASDET;
                                GD.GD_CSUBCOM = completarejed(GD).CP_CSUBDIA;
                                GD.GD_CNUMCOM = completarejed(GD).CP_CCOMPRO;
                                GD.GD_CSECCOM = completarejed(GD).CP_CSECDET;
                                GD.GD_CTDREF = completarejed(GD).CP_CTIPDOC;
                                GD.GD_CNDREF = completarejed(GD).CP_CNDOCRE;
                                GD.GD_NTCORI = completarejed(GD).CP_NTIPCAM;
                                GD.GD_CNOCONS = "-";


                                //console.log(GD);
                                InsertarDetalles(GD)
                                // insertar en tabla pago
                                annio = Number(f.getFullYear()).toString();

                                for (var u = 1; u <= 2 ; u++) {
                                    if (u == 1) {
                                        pago.PG_CVANEXO = data.d[i].GD_CVANEXO;
                                        pago.PG_CCODIGO = data.d[i].GD_CCODIGO;
                                        pago.PG_CTIPDOC = data.d[i].GD_CTIPDOC;
                                        pago.PG_CNUMDOC = data.d[i].GD_CNUMDOC;
                                        pago.PG_CDEBHAB = "D";
                                        pago.PG_NIMPOMN = Operacion.mround(Number(data.d[i].GD_NMNPROG),2);
                                        pago.PG_NIMPOUS = Operacion.mround((Number(data.d[i].GD_NMNPROG) / Number($('#MainContent_txttipocamb').val())),2);

                                        if (Number((f.getMonth() + 1)) < 10) {
                                            mes = "0" + "" + (f.getMonth() + 1);
                                        }
                                        else {
                                            mes = (f.getMonth() + 1);
                                        }
                                        if (Number(f.getDate()) < 10) {
                                            dia = "0" + "" + f.getDate();
                                        }
                                        else {
                                            dia = f.getDate();
                                        }
                                        pago.PG_CFECCOM = (annio.substr(2, 2) + "" + mes + "" + dia);
                                        pago.PG_CSUBDIA = Operacion.mask('ddlsubdiario').val();
                                        pago.PG_CNUMCOM = comprobante;
                                        pago.PG_CGLOSA = ("ND: " + (f.getFullYear()).toString().substr(2, 2) + Operacion.mask('ddlsubdiario').val() + " " + comprobante + "," + datoscompletardetcomprobante(GD).AC_CNOMBRE).substr(0, 39);
                                        pago.PG_CCOGAST = "";
                                        pago.PG_CORIGEN = "CP";
                                        pago.PG_CUSUARI = $('#MainContent_lblusuario').text();
                                        pago.PG_CCODMON = data.d[i].GD_CCODMON;
                                        pago.PG_DFECCOM = f;
                                        pago.PG_CORDKEY = correlativo(pago).formato;

                                        InsertaPago(pago);
                                    }
                                    if (u == 2) {
                                        pago.PG_CVANEXO = data.d[i].GD_CVANEXO;
                                        pago.PG_CCODIGO = data.d[i].GD_CCODIGO;
                                        pago.PG_CTIPDOC = data.d[i].GD_CTIPDOC;
                                        pago.PG_CNUMDOC = data.d[i].GD_CNUMDOC;
                                        if ((Number(data.d[i].GD_NMNPROG) / Number($('#MainContent_txttipocamb').val()))
                                              <
                                             (Number(data.d[i].GD_NMNPROG) / Number(GD.GD_NTCORI))) {
                                            pago.PG_CDEBHAB = "D";
                                        }
                                        if ((Number(data.d[i].GD_NMNPROG) / Number($('#MainContent_txttipocamb').val()))
                                            >
                                            (Number(data.d[i].GD_NMNPROG) / Number(GD.GD_NTCORI))) {
                                            pago.PG_CDEBHAB = "H";
                                        }
                                        pago.PG_NIMPOMN = 0;
                                        pago.PG_NIMPOUS =Operacion.mround( Math.abs((Number(data.d[i].GD_NMNPROG) / Number(GD.GD_NTCORI)) - (Number(data.d[i].GD_NMNPROG) / Number($('#MainContent_txttipocamb').val()))),2);

                                        if (Number((f.getMonth() + 1)) < 10) {
                                            mes = "0" + "" + (f.getMonth() + 1);
                                        }
                                        else {
                                            mes = (f.getMonth() + 1);
                                        }
                                        if (Number(f.getDate()) < 10) {
                                            dia = "0" + "" + f.getDate();
                                        }
                                        else {
                                            dia = f.getDate();
                                        }
                                        pago.PG_CFECCOM = (annio.substr(2, 2) + "" + mes + "" + dia);
                                        pago.PG_CSUBDIA = Operacion.mask('ddlsubdiario').val();
                                        pago.PG_CNUMCOM = comprobante;
                                        pago.PG_CGLOSA = "Ajuste por Diferencia de Cambio";
                                        pago.PG_CCOGAST = "";
                                        pago.PG_CORIGEN = "CP";
                                        pago.PG_CUSUARI = $('#MainContent_lblusuario').text();
                                        pago.PG_CCODMON = data.d[i].GD_CCODMON;
                                        pago.PG_DFECCOM = f;
                                        pago.PG_CORDKEY = correlativo(pago).formato;
                                        InsertaPago(pago);
                                    }
                                }
                            }
                        } else {

                            alert("no se encontro registro PARA PAGO");
                        }
                    },
                    error: function (response) {
                        if (response.length != 0)
                            console.log(response);
                    }
                });
            }

            $(".EJECUTAR").click(function () {
                document.getElementById("btnejecutar").style.visibility = "hidden";
                var codigo = $('#MainContent_txtprogramacione').val();
                var comprobante = generar().ultimodato;
                             if (mi_valida()) {
                   // alert("-" + comprobante + "-");
                    if (comprobante != "" && comprobante != null) {
                        Extraecabecerae(codigo, comprobante); // GUARDAMOS EN EJEC Y CABECERA COMPROBANTE
                                              
                    }
                    else {
                        alert("No se ha generado ningun comprobante");
                    }
                }
                else {
                    alert("Complete los datos antes de continuar");
                             }
            });

            function InsertaCabecera(DETA) {
                   $.ajax({
                    type: "POST",
                    url: "EjecucionProgramacion.aspx/InsertaDet",
                    data: '{DETA: ' + JSON.stringify(DETA) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        //alert("Registro Grabado EN CABECERA DE EJECUCION");
                        EliminaCabecera();
                        Extraedetallee(Operacion.mask('txtprogramacione').val(), DETA.CCOMPRO); // inserta en la tabla detalle de ejecucion y la tabla pago
                    },
                    error: function (response)
                    {
                        if (response.length != 0)
                            console.log(response);
                    }
                });
            }

            function ActComprobante(numero) {
                var DETA = {};
                var fecha = new Date();
                DETA.CTSUBDIA=Operacion.mask('ddlsubdiario').val();
                DETA.CTANO= (fecha.getFullYear()).toString().substr(2,2);
                DETA.CTMES = (Number(fecha.getMonth() + 1) < 10 ? "0" + (fecha.getMonth() + 1).toString() : (fecha.getMonth() + 1).toString());
                DETA.CTNUMER = numero.toString();
                console.log(DETA);
                $.ajax({
                    type: "POST",
                    url: "EjecucionProgramacion.aspx/Numeracion",
                    data: '{DETA: ' + JSON.stringify(DETA) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        //alert("NUMERO DE COMPROBANTE ACTUALIZADO");
                       },
                    error: function (response) {
                        if (response.length != 0)
                            console.log(response);
                    }
                });
            }

            function ActCartera(anexo, proveedor, tipo, numdoc) {
                var DETA = {};
                var fecha = new Date();
                DETA.CP_CVANEXO = anexo;
                DETA.CP_CCODIGO = proveedor;
                DETA.CP_CTIPDOC = tipo;
                DETA.CP_CNUMDOC = numdoc;
                $.ajax({
                    type: "POST",
                    url: "EjecucionProgramacion.aspx/actualizarsaldoENEJECUCION",
                    data: '{DETA: ' + JSON.stringify(DETA) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                       // alert("CARTERA ACTUALIZADO");
                    },
                    error: function (response) {
                        if (response.length != 0)
                            console.log(response);
                    }
                });
            }

            function InsertaPago(DETA) {

                $.ajax({
                    type: "POST",
                    url: "EjecucionProgramacion.aspx/InsertaPago",
                    data: '{DETA: ' + JSON.stringify(DETA) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                       // alert("Pago Grabado");
                        // console.log(DETA);

                    },
                    error: function (response) {
                        if (response.length != 0)
                            console.log(DETA);
                    }
                });
            }
            function EliminaCabecera() {
                var DETA = {};
                // para cabecera
                DETA.GC_CCODAGE = Operacion.mask('lblcodagenciae').text();
                DETA.GC_CNUMOPE = Operacion.mask('txtprogramacione').val();
               

                $.ajax({
                    type: "POST",
                    url: "EjecucionProgramacion.aspx/EliminaItemsC",
                    data: '{DETA: ' + JSON.stringify(DETA) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        //alert("Registro Eliminado Cabecera");
                   },
                    error: function (response) {
                        if (response.length != 0)
                            console.log(DETA);
                    }
                });
            }
            function EliminaDetalle(SECUENCIA) {
                var DETA = {};
                DETA.GD_CCODAGE = Operacion.mask('lblcodagenciae').text();
                DETA.GD_CNUMOPE = Operacion.mask('txtprogramacione').val();
                DETA.GD_CSECUE = SECUENCIA;

                $.ajax({
                    type: "POST",
                    url: "EjecucionProgramacion.aspx/EliminaItemsD",
                    data: '{DETA: ' + JSON.stringify(DETA) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                       // alert("Registro Eliminado Detalle");
                    },
                    error: function (response) {
                        if (response.length != 0)
                            console.log(DETA);
                    }
                });
            }


            function InsertarDetalles(DETA) {
                $.ajax({
                    type: "POST",
                    url: "EjecucionProgramacion.aspx/InsertaDetalle",
                    data: '{DETA: ' + JSON.stringify(DETA) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        //alert("rEGISTRO GRABADO EN DETALLE EJECUCION");
                    },
                    error: function (response) {
                        if (response.length != 0)
                            console.log(response);

                    }
                });

            }
            $(".LIMPIAR").click(function () {

                if ((document.getElementById("<%=rbdia.ClientID%>").checked == true)) {

                    //  $('#MainContent_txtfecha').val("");
                    $('#MainContent_txtmes').val("");
                    $('#MainContent_txtannio').val("");
                    $("#MainContent_txtmes").attr("disabled", true);
                    $("#MainContent_txtannio").attr("disabled", true);
                    $("#MainContent_txtfecha").attr("disabled", false);
                }
                if ((document.getElementById("<%=rbmes.ClientID%>").checked == true)) {

                    $('#MainContent_txtfecha').val("");
                    // $('#MainContent_txtmes').val("");
                    $("#MainContent_txtmes").attr("disabled", false);
                    $("#MainContent_txtannio").attr("disabled", false);
                    $("#MainContent_txtfecha").attr("disabled", true);
                }

            });


            function pad(str, max) {
                if (str != undefined) {
                    str = str.toString();
                    return str.length < max ? pad("0" + str, max) : str;
                }
            }
            function InsertarDetComprobante(DETADC, IND) {

                $.ajax({
                    type: "POST",
                    url: "EjecucionProgramacion.aspx/InsertDetComprobante",
                    data: '{DETA: ' + JSON.stringify(DETADC) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        //alert("DETCOMPROBANTE GUARDADO");
                        if(IND=="1"){
                            ActCartera(DETADC.DVANEXO, DETADC.DCODANE, DETADC.DTIPDOC, DETADC.DNUMDOC);
                        }
                        if (IND=="0"){
                            ExtraedetalleparaEliminarDetalle();
                            ExtraeparaBalh(DETADC.DCOMPRO);
                            InsertaBalh();
                            alert("Se ha generado el comprobante Nº "+Operacion.mask('ddlsubdiario').val()+ " - "+ DETADC.DCOMPRO);
                        }
                    },
                    error: function (response) {
                        if (response.length != 0)
                            console.log(response);
                    }
                });
            }




           function InsertarCabComprobante(DETACAB) {
                $.ajax({
                    type: "POST",
                    url: "EjecucionProgramacion.aspx/InsertCabComprobante",
                    data: '{DETA: ' + JSON.stringify(DETACAB) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                       // alert("CABCOMPROBANTE GUARDADO");
                        ExtraedetalleparaComrobante(Operacion.mask('txtprogramacione').val(), DETACAB.CCOMPRO) // guardamos en comprobante y su detalle
                       ActComprobante(Number((DETACAB.CCOMPRO).substr(2,4)));
                    },
                    error: function (response) {
                        if (response.length != 0)
                            alert(response);
                        console.log(response);

                    }
                });
           }
          
           function InsertaBalh() {
               var fecha = new Date();
               var gridView = document.getElementById("<%=GridView2.ClientID %>");
               var BDATA = {};
               for (var t = 1; t < gridView.rows.length; t++) {

                   BDATA.BCUENTA = (gridView.rows[t].cells[0].innerHTML).trim();
                   BDATA.BMNSALA = 0;
                   BDATA.BMNDEBE = (gridView.rows[t].cells[2].innerHTML == "" ? 0 : Operacion.mround(Number(gridView.rows[t].cells[2].innerHTML),2));
                   BDATA.BMNHABER = (gridView.rows[t].cells[3].innerHTML == "" ? 0 :Operacion.mround(Number(gridView.rows[t].cells[3].innerHTML),2));
                   BDATA.BMNSALN = 0;
                   BDATA.BUSSALA = 0;
                   BDATA.BUSDEBE = (gridView.rows[t].cells[4].innerHTML == "" ? 0 : Operacion.mround(Number(gridView.rows[t].cells[4].innerHTML),2));
                   BDATA.BUSHABER = (gridView.rows[t].cells[5].innerHTML == "" ? 0 : Operacion.mround(Number(gridView.rows[t].cells[5].innerHTML),2));
                   BDATA.BUSSALN = 0;
                   BDATA.BMNSALI = 0;
                   BDATA.BUSSALI = 0;
                   BDATA.BFECPRO = "";
                   BDATA.BFORBAL = "1";//CONTROL PARA INCREMENTAR 
                   BDATA.BFORGYP = "";
                   BDATA.BFORRE1 = "";
                   BDATA.BCTAAJU = "";
                   BDATA.BFECPRO2 = (fecha.getFullYear().toString() + "" + (Number(fecha.getMonth() + 1) < 10 ? "0" + (fecha.getMonth() + 1) : (fecha.getMonth() + 1))).trim();
                  // alert(fecha.getFullYear().toString() + "" + (fecha.getMonth() + 1).toString());
                   $.ajax({
                       type: "POST",
                       url: "EjecucionProgramacion.aspx/ActualizarBalh",
                       data: '{DETA: ' + JSON.stringify(BDATA) + '}',
                       contentType: "application/json; charset=utf-8",
                       dataType: "json",
                       async: false,
                       success: function (response) {

                       },
                       error: function (response) {
                           if (response.length != 0)
                               alert(response);
                           console.log(BDATA);

                       }
                   });
                      
                 }
           }
            $(".EJECUTAR1").click(function () {
                //$("#MostrarDetalles").dialog('open');
                ExtraedetalleparaComrobante1();
                recorregriddetalle();
            });

            function ExtraedetalleparaComrobante1() {
                var GD = {};
                var pago = {};
                var f = new Date();
                var dia = "";
                var mes = "";
                var annio = "";
                var DETADC = {};
                var cont = 0;
                var rowt = 0;
                rowt = $("[id*=GridView3] tr:last-child").clone(true);
                var codigo = Operacion.mask('txtprogramacione').val();
                var comprobante = "";
                var annioven = "";
                var aannio = "";
                var i = 0;
                annio = Number(f.getFullYear()).toString();
                $.ajax({

                    type: "POST",
                    url: "EjecucionProgramacion.aspx/EXTRAERPARAINSERTARDET",
                    data: "{ 'CODATA': '" + codigo + "' }",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        if (data.d.length > 0) {
                            for (i = 0; i < data.d.length; i++) {
                                //para insertar en la cabecera
                                GD.GD_CCODAGE = data.d[i].GD_CCODAGE;
                                GD.GD_CNUMOPE = data.d[i].GD_CNUMOPE;
                                GD.GD_CSECUE = data.d[i].GD_CSECUE;
                                GD.GD_CVANEXO = data.d[i].GD_CVANEXO;
                                GD.GD_CCODIGO = data.d[i].GD_CCODIGO;
                                GD.GD_CTIPDOC = data.d[i].GD_CTIPDOC;
                                GD.GD_CNUMDOC = data.d[i].GD_CNUMDOC;
                                GD.GD_DFECPRO = (moment(data.d[i].GD_DFECPRO, "DD/MM/YYYY"));
                                GD.GD_DFECDOC = (moment(data.d[i].GD_DFECDOC, "DD/MM/YYYY"));
                                GD.GD_DFECVEN = (moment(data.d[i].GD_DFECVEN, "DD/MM/YYYY"));
                                GD.GD_CMONCAR = data.d[i].GD_CMONCAR;
                                GD.GD_NORPROG = data.d[i].GD_NORPROG;
                                GD.GD_NTIPCAM = Number(data.d[i].GD_NMNPROG) / Number(data.d[i].GD_NUSPROG); //$('#MainContent_txttipocamb').val();
                                GD.GD_CCODMON = data.d[i].GD_CCODMON;
                                GD.GD_NUSPROG = data.d[i].GD_NUSPROG;
                                GD.GD_NMNPROG = data.d[i].GD_NMNPROG;
                                GD.GD_CTIPCTA = data.d[i].GD_CTIPCTA;
                                GD.GD_CTIPPRO = data.d[i].GD_CTIPPRO;
                                GD.GD_CNUMCTA = data.d[i].GD_CNUMCTA;
                                GD.GD_CSUBDIA = Operacion.mask('ddlsubdiario').val();
                                GD.GD_CCOMPRO = comprobante;
                                GD.GD_NMNRETE = data.d[i].GD_NMNRETE;
                                GD.GD_NUSRETE = data.d[i].GD_NUSRETE;
                                GD.GD_NORRETE = data.d[i].GD_NORRETE;
                                GD.GD_CRETE = data.d[i].GD_CRETE;
                                GD.GD_NPORRE = data.d[i].GD_NPORRE;
                                GD.GD_CTASDET = data.d[i].GD_CTASDET;
                                GD.GD_CSUBCOM = completarejed(GD).CP_CSUBDIA;
                                GD.GD_CNUMCOM = completarejed(GD).CP_CCOMPRO;
                                GD.GD_CSECCOM = completarejed(GD).CP_CSECDET;
                                GD.GD_CTDREF = completarejed(GD).CP_CTIPDOC;
                                GD.GD_CNDREF = completarejed(GD).CP_CNDOCRE;
                                GD.GD_NTCORI = completarejed(GD).CP_NTIPCAM;
                                GD.GD_CNOCONS = "";
                                annio = Number(f.getFullYear()).toString();

                                // PARA INSERTAR EN EL DETALLE
                                DETADC.DSUBDIA = $('#MainContent_ddlsubdiario').val();
                                DETADC.DCOMPRO = comprobante;
                                if (Number((f.getMonth() + 1)) < 10) {
                                    mes = "0" + "" + (f.getMonth() + 1);
                                }
                                else {
                                    mes = (f.getMonth() + 1);
                                }
                                if (Number(f.getDate()) < 10) {
                                    dia = "0" + "" + f.getDate();
                                }
                                else {
                                    dia = f.getDate();
                                }

                                var DFECDOC = (moment(data.d[i].GD_DFECDOC, "DD/MM/YYYY"));
                                DFECDOC = new Date(DFECDOC);
                                aannio = Number(DFECDOC.getFullYear()).toString();

                                var DFECVEN = (moment(data.d[i].GD_DFECVEN, "DD/MM/YYYY"));
                                DFECVEN = new Date(DFECVEN);
                                annioven = Number(DFECVEN.getFullYear()).toString();

                                for (var k = 0; k <= 3; k++) {  // numero de items en la tabla detalle comprobante.

                                    if (k == 1) {
                                        cont = cont + 1;
                                        //alert(cont);
                                        // DETADC.indicador = "1";
                                        DETADC.DCUENTA = M_ARRAY[0];
                                        DETADC.DCODANE = GD.GD_CCODIGO;
                                        DETADC.DDH = "D";
                                        DETADC.DIMPORT = GD.GD_NMNPROG;
                                        DETADC.DTIPDOC = "FT"; //SELECT * FROM CT0003TABL where TCOD='06'
                                        DETADC.DNUMDOC = data.d[i].GD_CNUMDOC;
                                        DETADC.DFECDOC = aannio.substr(2, 2) + "" + (Number(DFECDOC.getMonth() + 1) < 10 ? "0" + "" + (DFECDOC.getMonth() + 1) : DFECDOC.getMonth() + 1) + "" + (Number(DFECDOC.getDate()) < 10 ? "0" + "" + DFECDOC.getDate() : DFECDOC.getDate());
                                        DETADC.DFECVEN = annioven.substr(2, 2) + "" + (Number(DFECVEN.getMonth() + 1) < 10 ? "0" + "" + (DFECVEN.getMonth() + 1) : DFECVEN.getMonth() + 1) + "" + (Number(DFECVEN.getDate()) < 10 ? "0" + "" + DFECVEN.getDate() : DFECVEN.getDate());
                                        DETADC.DAREA = ""; // DETERMINADA POR EL AREA SELECCIONADA EN EL COMBO Y SE APLICA SOLO EN EL TOTAL
                                        DETADC.DXGLOSA = (GD.GD_CSUBCOM.trim() + " " + GD.GD_CNUMCOM.trim() + " " + datoscompletardetcomprobante(GD).AC_CNOMBRE.trim()).substr(0, 29); // corregir
                                        DETADC.DUSIMPOR = Operacion.mround((Number(GD.GD_NMNPROG) / Number($("#MainContent_txttipocamb").val())), 2);
                                        DETADC.DMNIMPOR = Operacion.mround(Number(GD.GD_NMNPROG), 2);
                                        DETADC.DCODARC = "01";
                                        DETADC.DFECDO2 = (moment(DFECDOC, "DD/MM/YYYY"));
                                        DETADC.DFECVEN2 = DFECVEN; //(moment(DFECVEN).format("DD/MM/YYYY"));
                                        DETADC.DVANEXO = datoscompletardetcomprobante(GD).AC_CVANEXO; // ASIGNADO POR EL PROVEEDOR DE LA TABLA MAES.
                                        DETADC.DTIPDOR = ""; // AJ CUANDO ES POR GANANCIA O PERDIDA POR DIFERENCIA DE PAGO para el total
                                        DETADC.DTIPTAS = GD.GD_CTASDET;
                                        DETADC.DMEDPAG = ""; // SE TOMA DEL COMBO Y SOLO SE APLICA PARA EL REGISTRO DEL TOTAL

                                        //campos comunes
                                        DETADC.DSECUE = Operacion.cadenaMascara(cont, 4);
                                        DETADC.DFECCOM = (annio.substr(2, 2) + "" + mes + "" + dia);
                                        DETADC.DCODMON = GD.GD_CCODMON;
                                        DETADC.CSITUA = "F"; //FINALIZADO PENDIENTE
                                        DETADC.CTIPCAM = $("#MainContent_txttipocamb").val();
                                        DETADC.DCENCOS = " ";
                                        DETADC.DFLAG = "N";
                                        DETADC.DDATE = (moment($("#MainContent_txtfechatransaccion").val(), "DD/MM/YYYY"));
                                        DETADC.DFECCOM2 = (moment($("#MainContent_txtfechatransaccion").val(), "DD/MM/YYYY"));
                                        DETADC.DCODANE2 = "";
                                        DETADC.DVANEXO2 = "";
                                        DETADC.DTIPCAM = 0;
                                        DETADC.DCANTID = 0;
                                        DETADC.DCTAORI = "";
                                        DETADC.DCCODMON = "";
                                        DETADC.DCIMPORT = 0;
                                        DETADC.DCNUMDOC = "";
                                        DETADC.DCESTADO = "";
                                        DETADC.DCCONFEC2 = null;
                                        DETADC.DCCONNRO = " ";
                                        DETADC.DCCONPRO = null;
                                        DETADC.DCNUMEST = "";
                                        DETADC.DCITEM = "";
                                        DETADC.DCIMPORTB = 0;
                                        DETADC.DCANO = "";
                                        DETADC.DNUMDOR = "";
                                        DETADC.DFECDO2 = null;
                                        DETADC.DIMPTAS = 0;
                                        DETADC.DIMPBMN = 0;
                                        DETADC.DIMPBUS = 0;
                                        DETADC.DMONCOM = "";
                                        DETADC.DCOLCOM = "";
                                        DETADC.DBASCOM = 0;
                                        DETADC.DINACOM = 0;
                                        DETADC.DIGVCOM = 0;
                                        DETADC.DTPCONV = "";
                                        DETADC.DFLGCOM = "";
                                        DETADC.DANECOM = "";
                                        DETADC.DTIPACO = "";
                                        DETADC.DTIPDO2 = "";
                                        DETADC.DNUMDO2 = "";
                                        DETADC.DRETE = "";
                                        DETADC.DPORRE = 0;
                                        
                                        $("td", rowt).eq(0).html(DETADC.DCUENTA);
                                        $("td", rowt).eq(1).html(DETADC.DDH);
                                        $("td", rowt).eq(2).html(DETADC.DIMPORT);
                                        $("td", rowt).eq(3).html(DETADC.DXGLOSA);
                                        $("td", rowt).eq(4).html(DETADC.DUSIMPOR);
                                        $("td", rowt).eq(5).html(DETADC.DMNIMPOR);
                                        $("[id*=GridView3]").append(rowt);
                                        rowt = $("[id*=GridView3] tr:last-child").clone(true);

                                    }



                                    if (k == 2) {
                                        DETADC.DCUENTA = M_ARRAY[0];
                                        DETADC.DCODANE = GD.GD_CCODIGO;
                                        cont = cont + 1;

                                        if ((Number(GD.GD_NMNPROG) / Number($('#MainContent_txttipocamb').val()))
                                            <
                                           (Number(data.d[i].GD_NMNPROG) / Number(GD.GD_NTCORI))) {
                                            DETADC.DDH = "D";
                                            DETADC.DXGLOSA = "Ganancia Diferencia Cambio";
                                        }
                                        if ((Number(GD.GD_NMNPROG) / Number($('#MainContent_txttipocamb').val()))
                                            >
                                            (Number(data.d[i].GD_NMNPROG) / Number(GD.GD_NTCORI))) {
                                            DETADC.DDH = "H";
                                            DETADC.DXGLOSA = "Perdida Diferencia Cambio";

                                        }

                                        DETADC.DIMPORT = 0;
                                        DETADC.DTIPDOC = "FT";
                                        DETADC.DNUMDOC = data.d[i].GD_CNUMDOC;
                                        DETADC.DFECDOC = "";
                                        DETADC.DFECVEN = "";
                                        DETADC.DAREA = "  ";
                                        DETADC.DUSIMPOR = Operacion.mround((Math.abs((Number(GD.GD_NMNPROG) / Number(GD.GD_NTCORI)) - (Number(GD.GD_NMNPROG) / Number($('#MainContent_txttipocamb').val())))), 2);
                                        DETADC.DMNIMPOR = 0;
                                        DETADC.DCODARC = "01";
                                        DETADC.DFECDOC2 = null;
                                        DETADC.DFECVEN2 = null;
                                        DETADC.DVANEXO = datoscompletardetcomprobante(GD).AC_CVANEXO;
                                        DETADC.DTIPDOR = "AJ";
                                        DETADC.DTIPTAS = "";
                                        DETADC.DMEDPAG = "";
                                        //campos comunes
                                        DETADC.DSECUE = Operacion.cadenaMascara(cont, 4);
                                        DETADC.DFECCOM = (annio.substr(2, 2) + "" + mes + "" + dia);
                                        DETADC.DCODMON = GD.GD_CCODMON;
                                        DETADC.CSITUA = "F";
                                        DETADC.CTIPCAM = $("#MainContent_txttipocamb").val();
                                        DETADC.DCENCOS = " ";
                                        DETADC.DFLAG = "N"; // DEPENDE DE LA TABLA : SELECT * FROM CT0003TABL where TCOD='R7' OR TCOD='41'
                                        DETADC.DDATE = (moment($("#MainContent_txtfechatransaccion").val(), "DD/MM/YYYY"));
                                        DETADC.DFECCOM2 = (moment($("#MainContent_txtfechatransaccion").val(), "DD/MM/YYYY"));
                                        DETADC.DCODANE2 = "";
                                        DETADC.DVANEXO2 = "";
                                        DETADC.DTIPCAM = 0;
                                        DETADC.DCANTID = 0;
                                        DETADC.DCTAORI = "";
                                        DETADC.DCCODMON = "";
                                        DETADC.DCIMPORT = 0;
                                        DETADC.DCNUMDOC = "";
                                        DETADC.DCESTADO = "";
                                        DETADC.DCCONFEC2 = null;
                                        DETADC.DCCONNRO = "";
                                        DETADC.DCCONPRO = null;
                                        DETADC.DCNUMEST = "";
                                        DETADC.DCITEM = "";
                                        DETADC.DCIMPORTB = 0;
                                        DETADC.DCANO = "";
                                        DETADC.DNUMDOR = "";
                                        DETADC.DFECDO2 = null;
                                        DETADC.DIMPTAS = 0;
                                        DETADC.DIMPBMN = 0;
                                        DETADC.DIMPBUS = 0;
                                        DETADC.DMONCOM = "";
                                        DETADC.DCOLCOM = "";
                                        DETADC.DBASCOM = 0;
                                        DETADC.DINACOM = 0;
                                        DETADC.DIGVCOM = 0;
                                        DETADC.DTPCONV = "";
                                        DETADC.DFLGCOM = "";
                                        DETADC.DANECOM = "";
                                        DETADC.DTIPACO = "";
                                        DETADC.DTIPDO2 = "";
                                        DETADC.DNUMDO2 = "";
                                        DETADC.DRETE = "";
                                        DETADC.DPORRE = 0;
                                        $("td", rowt).eq(0).html(DETADC.DCUENTA);
                                        $("td", rowt).eq(1).html(DETADC.DDH);
                                        $("td", rowt).eq(2).html(DETADC.DIMPORT);
                                        $("td", rowt).eq(3).html(DETADC.DXGLOSA);
                                        $("td", rowt).eq(4).html(DETADC.DUSIMPOR);
                                        $("td", rowt).eq(5).html(DETADC.DMNIMPOR);
                                        $("[id*=GridView3]").append(rowt);
                                        rowt = $("[id*=GridView3] tr:last-child").clone(true);
                                    
                                    }


                                    if (k == 3) {
                                        cont = cont + 1;
                                        DETADC.DCODANE = data.d[i].GD_CCODIGO;
                                        if ((Number(GD.GD_NMNPROG) / Number($('#MainContent_txttipocamb').val()))
                                            <
                                           (Number(GD.GD_NMNPROG) / Number(GD.GD_NTCORI))) {
                                            DETADC.DDH = "H";
                                            DETADC.DCUENTA = M_ARRAY[1];
                                        }
                                        if ((Number(data.d[i].GD_NMNPROG) / Number($('#MainContent_txttipocamb').val()))
                                            >
                                            (Number(GD.GD_NMNPROG) / Number(GD.GD_NTCORI))) {
                                            DETADC.DDH = "D";
                                            DETADC.DCUENTA = M_ARRAY[2];
                                        }
                                        DETADC.DIMPORT = 0;
                                        DETADC.DTIPDOC = "FT";
                                        DETADC.DNUMDOC = GD.GD_CNUMDOC.trim();
                                        DETADC.DFECDOC = "";
                                        DETADC.DFECVEN = "";
                                        DETADC.DAREA = "";
                                        DETADC.DXGLOSA = "Ajuste Diferencia Cambio";
                                        DETADC.DMNIMPOR = 0;
                                        DETADC.DUSIMPOR = Operacion.mround((Math.abs((Number(GD.GD_NMNPROG) / Number(GD.GD_NTCORI)) - (Number(GD.GD_NMNPROG) / Number($('#MainContent_txttipocamb').val())))), 2);
                                        DETADC.DCODARC = "";
                                        DETADC.DFECDOC2 = null;
                                        DETADC.DFECVEN2 = null;
                                        DETADC.DVANEXO = datoscompletardetcomprobante(GD).AC_CVANEXO;
                                        DETADC.DTIPDOR = "";
                                        DETADC.DTIPTAS = "";
                                        DETADC.DMEDPAG = "";

                                        //campos comunes
                                        DETADC.DSECUE = Operacion.cadenaMascara(cont, 4);
                                        DETADC.DFECCOM = (annio.substr(2, 2) + "" + mes + "" + dia);
                                        DETADC.DCODMON = GD.GD_CCODMON;
                                        DETADC.CSITUA = "F";
                                        DETADC.CTIPCAM = $("#MainContent_txttipocamb").val();
                                        DETADC.DCENCOS = "";
                                        DETADC.DFLAG = "N";
                                        DETADC.DDATE = (moment($("#MainContent_txtfechatransaccion").val(), "DD/MM/YYYY"));
                                        DETADC.DFECCOM2 = (moment($("#MainContent_txtfechatransaccion").val(), "DD/MM/YYYY"));
                                        DETADC.DCODANE2 = "";
                                        DETADC.DVANEXO2 = "";
                                        DETADC.DTIPCAM = 0;
                                        DETADC.DCANTID = 0;
                                        DETADC.DCTAORI = "";
                                        DETADC.DCCODMON = "";
                                        DETADC.DCIMPORT = 0;
                                        DETADC.DCNUMDOC = "";
                                        DETADC.DCESTADO = "";
                                        DETADC.DCCONFEC2 = null;
                                        DETADC.DCCONNRO = "";
                                        DETADC.DCCONPRO = null;
                                        DETADC.DCNUMEST = "";
                                        DETADC.DCITEM = "";
                                        DETADC.DCIMPORTB = 0;
                                        DETADC.DCANO = "";
                                        DETADC.DNUMDOR = " ";
                                        DETADC.DFECDO2 = null;
                                        DETADC.DIMPTAS = 0;
                                        DETADC.DIMPBMN = 0;
                                        DETADC.DIMPBUS = 0;
                                        DETADC.DMONCOM = "";
                                        DETADC.DCOLCOM = "";
                                        DETADC.DBASCOM = 0;
                                        DETADC.DINACOM = 0;
                                        DETADC.DIGVCOM = 0;
                                        DETADC.DTPCONV = "";
                                        DETADC.DFLGCOM = "";
                                        DETADC.DANECOM = "";
                                        DETADC.DTIPACO = "";
                                        DETADC.DTIPDO2 = "";
                                        DETADC.DNUMDO2 = "";
                                        DETADC.DRETE = "";
                                        DETADC.DPORRE = 0;
                                        $("td", rowt).eq(0).html(DETADC.DCUENTA);
                                        $("td", rowt).eq(1).html(DETADC.DDH);
                                        $("td", rowt).eq(2).html(DETADC.DIMPORT);
                                        $("td", rowt).eq(3).html(DETADC.DXGLOSA);
                                        $("td", rowt).eq(4).html(DETADC.DUSIMPOR);
                                        $("td", rowt).eq(5).html(DETADC.DMNIMPOR);
                                        $("[id*=GridView3]").append(rowt);
                                        rowt = $("[id*=GridView3] tr:last-child").clone(true);
                                    

                                    }
                                }
                            }
                            if (i <= Number(data.d.length)) {


                                //****************para insertar el total
                                DETADC.DCUENTA = Operacion.mask('lblbancocuenta').text();
                                DETADC.DCODANE = $('#MainContent_lblcodbancoe').text().trim();
                                DETADC.DDH = "H";
                                DETADC.DIMPORT = Operacion.mround(Number(Operacion.mask('txtmontoe').val()), 2);
                                DETADC.DTIPDOC = "ND";
                                DETADC.DNUMDOC = (annio.substr(2, 2)) + "" + $("#MainContent_ddlsubdiario").val() + " " + comprobante;
                                DETADC.DFECDOC = aannio.substr(2, 2) + "" + (Number(DFECDOC.getMonth() + 1) < 10 ? "0" + "" + (DFECDOC.getMonth() + 1) : DFECDOC.getMonth() + 1) + "" + (Number(DFECDOC.getDate()) < 10 ? "0" + "" + DFECDOC.getDate() : DFECDOC.getDate());
                                DETADC.DFECVEN = "";
                                DETADC.DAREA = $("#MainContent_ddlarea").val();
                                DETADC.DXGLOSA = "";
                                DETADC.DUSIMPOR = Operacion.mround((Number(Operacion.mask('txtmontoe').val()) / Number($("#MainContent_txttipocamb").val())), 2);
                                DETADC.DMNIMPOR = Operacion.mround(Number(Operacion.mask('txtmontoe').val()), 2);
                                DETADC.DCODAR = "";
                                DETADC.DFECDOC2 = (moment($("#MainContent_txtfechatransaccion").val(), "DD/MM/YYYY"));
                                DETADC.DFECVEN2 = null;
                                DETADC.DVANEXO = "0";
                                DETADC.DTIPDOR = "";
                                DETADC.DTIPTAS = "";
                                DETADC.DMEDPAG = Operacion.mask('ddlmediopago').val();

                                DETADC.DSECUE = Operacion.cadenaMascara(cont + 1, 4);
                                DETADC.DFECCOM = (annio.substr(2, 2) + "" + mes + "" + dia);
                                DETADC.DCODMON = GD.GD_CCODMON;
                                DETADC.CSITUA = "F";
                                DETADC.CTIPCAM = $("#MainContent_txttipocamb").val();
                                DETADC.DCENCOS = " ";
                                DETADC.DFLAG = "N"; // DEPENDE DE LA TABLA : SELECT * FROM CT0003TABL where TCOD='R7' OR TCOD='41'
                                DETADC.DDATE = (moment($("#MainContent_txtfechatransaccion").val(), "DD/MM/YYYY"));
                                DETADC.DFECCOM2 = (moment($("#MainContent_txtfechatransaccion").val(), "DD/MM/YYYY"));
                                DETADC.DCODANE2 = " ";
                                DETADC.DVANEXO2 = " ";
                                DETADC.DTIPCAM = 0;
                                DETADC.DCANTID = 0;
                                DETADC.DCTAORI = "";
                                DETADC.DCCODMON = "";
                                DETADC.DCIMPORT = 0;
                                DETADC.DCNUMDOC = "";
                                DETADC.DCESTADO = "";
                                DETADC.DCCONFEC2 = null;
                                DETADC.DCCONNRO = "";
                                DETADC.DCCONPRO = null;
                                DETADC.DCNUMEST = "";
                                DETADC.DCITEM = "";
                                DETADC.DCIMPORTB = 0;
                                DETADC.DCANO = "";
                                DETADC.DNUMDOR = "";
                                DETADC.DFECDO2 = null;
                                DETADC.DIMPTAS = 0;
                                DETADC.DIMPBMN = 0;
                                DETADC.DIMPBUS = 0;
                                DETADC.DMONCOM = "";
                                DETADC.DCOLCOM = "";
                                DETADC.DBASCOM = 0;
                                DETADC.DINACOM = 0;
                                DETADC.DIGVCOM = 0;
                                DETADC.DTPCONV = "";
                                DETADC.DFLGCOM = "";
                                DETADC.DANECOM = "";
                                DETADC.DTIPACO = "";
                                DETADC.DTIPDO2 = "";
                                DETADC.DNUMDO2 = "";
                                DETADC.DRETE = "";
                                DETADC.DPORRE = 0;
                                $("td", rowt).eq(0).html(DETADC.DCUENTA);
                                $("td", rowt).eq(1).html(DETADC.DDH);
                                $("td", rowt).eq(2).html(DETADC.DIMPORT);
                                $("td", rowt).eq(3).html(DETADC.DXGLOSA);
                                $("td", rowt).eq(4).html(DETADC.DUSIMPOR);
                                $("td", rowt).eq(5).html(DETADC.DMNIMPOR);
                                $("[id*=GridView3]").append(rowt);
                                rowt = $("[id*=GridView3] tr:last-child").clone(true);
                             
                             
                            }
                        } else {

                            alert("no se encontro registro PARA DETALLE COMPROBANTE");
                        }
                    },
                    error: function (response) {
                        if (response.length != 0)
                            console.log(response);
                    }
                });
            }

            function recorregriddetalle() {
                contarndw = 0;
            subsoles = 0; descc = 0; igvv = 0;
            sumasoles = 0; subdolares = 0; sumadolares = 0;

            var gridView = document.getElementById("<%=GridView3.ClientID %>");

            for (var t = 1; t < gridView.rows.length; t++) {
               
                cellPivotdolares = gridView.rows[t].cells[4];
                cellPivotsoles = gridView.rows[t].cells[5];
                subdolares = cellPivotdolares.innerHTML;
                subsoles = cellPivotsoles.innerHTML;

                if (gridView.rows[t].cells[1].innerHTML == "D") {
                    sumasoles = new Number(Operacion.mask('lbldebesoles').text()) + Math.abs(new Number(subsoles));
                    sumadolares = new Number(Operacion.mask('lbldebedolares').text()) + Math.abs(new Number(subdolares));
                    Operacion.mask('lbldebedolares').text(Operacion.mround(sumadolares,2));
                    Operacion.mask('lbldebesoles').text(Operacion.mround(sumasoles,2));
                }
                if (gridView.rows[t].cells[1].innerHTML == "H") {
                    sumasoles = new Number(Operacion.mask('lblhabersoles').text()) + Math.abs(new Number(subsoles));
                    sumadolares = new Number(Operacion.mask('lblhaberdolares').text()) + Math.abs(new Number(subdolares));
                    Operacion.mask('lblhaberdolares').text(Operacion.mround(sumadolares,2));
                    Operacion.mask('lblhabersoles').text(Operacion.mround(sumasoles,2));
                }
                                           
            }
            if (Number(Operacion.mask('lblhaberdolares').text()) != Number(Operacion.mask('lbldebedolares').text())) {
                Operacion.mask('lblsobrante').text("1");


                if (Math.abs(Number(Operacion.mask('lblhaberdolares').text()) - Number(Operacion.mask('lbldebedolares').text())) < 0.1)
                {
                    document.getElementById("btnejecutar").style.visibility = "visible";
                    document.getElementById("btnejecutar0").style.visibility = "hidden";
                    Operacion.mask("lblmontosobrante").text((Math.abs((Operacion.mask('lblhaberdolares').text()) - Number(Operacion.mask('lbldebedolares').text()))).toFixed(2));
                    if (Number(Operacion.mask('lblhaberdolares').text()) > Number(Operacion.mask('lbldebedolares').text())) {
                        Operacion.mask('lbldebehaber').text("D");
                    }
                    else {
                        Operacion.mask('lbldebehaber').text("H");
                    }
                }
                else {
                    alert("No es posible procesar la ejecucion debido a que hay una diferencia de cambio mayor a 0.1");
           
                }
            }

            else {
                document.getElementById("btnejecutar").style.visibility = "visible";
                document.getElementById("btnejecutar0").style.visibility = "hidden";
            }

          }

        });
    </script>
    <style type="text/css">
        #contenedor {
            width: 1120px;
        }

        #btninconsistencias {
            width: 96px;
        }

        .auto-style1 {
            width: 82px;
        }
        .auto-style2 {
            height: 25px;
        }
          fieldset{
            width:1050px;
                    }
    </style>
</asp:Content>



<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="contenedor">
         <fieldset>
                <legend>
                    EJECUCIÓN DE PROGRAMACIÓN DE PAGO
                </legend>
        <div id="Creacion" title="Creación">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblusuario" runat="server" ForeColor="#f1f1f1"></asp:Label>
                    </td>

                </tr>
            </table>
            <table>
                <tr>
                    <td class="auto-style1">
                        <input id="rbdia" name="opcion" type="radio" value="1" runat="server" class="LIMPIAR" />
                        Dia<br />

                    </td>
                    <td>
                        <asp:TextBox ID="txtfecha" runat="server" Width="147px"></asp:TextBox>
                    </td>
                    <td>
                        <input id="rbmes" name="opcion" type="radio" value="2" runat="server" class="LIMPIAR" />Mes<br />
                    </td>
                    <td>
                        <asp:TextBox ID="txtmes" runat="server" Width="68px" MaxLength="2"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="txtannio" runat="server" Width="103px" MaxLength="4"></asp:TextBox></td>
                    <asp:Label ID="Label1" runat="server" ForeColor="#f1f1f1"></asp:Label>
                </tr>
            </table>
            <table>
                <tr>
                    <td>Agencia</td>
                    <td>
                        <asp:DropDownList ID="ddlagencia" runat="server" Height="16px" Width="371px"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Concepto</td>
                    <td>
                        <asp:DropDownList ID="ddlconcepto" runat="server" Height="16px" Width="371px"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Banco</td>
                    <td>
                        <asp:DropDownList ID="ddlbanco" runat="server" Height="16px" Width="371px"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Tipo Pago</td>
                    <td>
                        <asp:DropDownList ID="ddltipopago" runat="server" Height="16px" Width="371px"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Departamento</td>
                    <td>
                        <asp:DropDownList ID="ddldepartamento" runat="server" Height="16px" Width="371px"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnfiltro" runat="server" Text="Filtro" Width="76px" OnClick="btnfiltro_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>

            </table>
            </fieldset>
            <table>
                <tr>
                    <td>
                         <div style=" height: 450px">
                        <asp:GridView ID="gvordencompra" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" OnRowCreated="griddata_RowCreated" Width="100%" Font-Size="Small">
                            <Columns>
                                <asp:BoundField DataField="GC_CCODAGE" HeaderText="AGENCIA" />
                                <asp:BoundField DataField="GC_CNUMOPE" HeaderText="PROGRAMACION" />
                                <asp:BoundField DataField="GC_CUSUCRE" HeaderText="FECHA DE PROG" />
                                <asp:BoundField DataField="GC_CCODCON" HeaderText="CONCEPTO" />
                                <asp:BoundField DataField="GC_CTIPPAG" HeaderText="TIPO DE PAGO" />
                                <asp:BoundField DataField="GC_CCODBAN" HeaderText="BANCO" />
                                <asp:BoundField DataField="GC_CCODMON" HeaderText="MONEDA">

                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>

                                <asp:BoundField DataField="GC_NMONPRO" HeaderText="IMPORTE">
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="GC_CESTADO" HeaderText="ESTADO" />

                                <asp:TemplateField HeaderText="DETALLE">

                                    <ItemTemplate>
                                        <div class="editar" style="text-align: center">
                                            <img alt="" src="../../../Images/Detalle.png" width="25" style="cursor: pointer" />
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="EJECUTAR">

                                    <ItemTemplate>
                                        <div class="ejecucion" style="text-align: center">
                                            <img alt="" src="../../../Images/Valid.png" width="25" style="cursor: pointer" />
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
            </table>
        </div>
        <div id="Modificacion" style="display:none">
            <table>
                <tr>
                    <td>Agencia&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                    <td>
                        <asp:Label ID="lblcodagencia" runat="server" Text=""></asp:Label>
                        -
                        <asp:Label ID="lblagencia" runat="server" Text=""></asp:Label></td>
                    <td>Monto&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                    <td>
                        <asp:TextBox ID="txtmontomod" runat="server" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Num.Prog.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                    <td>
                        <asp:TextBox ID="txtprogramacionmod" runat="server" Width="170px" Enabled="false"></asp:TextBox>
                    </td>
                    <td>Fech. Prog.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                    <td>
                        <asp:TextBox ID="txtfechaprogmod" runat="server" Enabled="false"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td>Concepto&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                    <td>
                        <asp:Label ID="lblcodconcepto" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lblconcepto" runat="server" Text=""></asp:Label>
                    </td>

                    <td>Tipo Detracción:</td>
                    <td>
                        <asp:Label ID="lblcoddetraccion" runat="server" Text=""></asp:Label>-
                        <asp:Label ID="lbldetraccion" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Tipo Pago&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                    <td>
                        <asp:Label ID="lblcodtipopago" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lbltipopago" runat="server" Text=""></asp:Label>
                    </td>

                    <td>Departamento&nbsp; :</td>
                    <td>
                        <asp:Label ID="lblcoddepartamento" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lbldepartamento" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Moneda&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                    <td>
                        <asp:Label ID="lblcodmoneda" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lblmoneda" runat="server" Text=""></asp:Label>
                    </td>

                    <td>Banco&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                    <td>
                        <asp:Label ID="lblcodbanco" runat="server" Text=""></asp:Label>-
                        <asp:Label ID="lblbanco" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Tipo de Cambio:</td>
                    <td>
                        <asp:TextBox ID="txttipocambiomod" runat="server" Enabled="false"></asp:TextBox>

                    </td>
                    <td>Estado&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                    <td>
                        <asp:TextBox ID="txtestadomod" runat="server" Text="" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
            </table>
              <table>
                <tr>
                    <td>Elaborado por:</td>
                    <td> <asp:Label ID="lblusuelaborado" runat="server" Text=""></asp:Label> </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;Fecha Elaboración</td>
                     <td> <asp:Label ID="lblfechaelaborado" runat="server" Text=""></asp:Label> </td>
                </tr>
                <tr>
                    <td>Modificado por:</td>
                    <td> <asp:Label ID="lblusumodificado" runat="server" Text=""></asp:Label> </td>
                     <td>&nbsp;&nbsp;&nbsp;&nbsp;Fecha Modificación</td>
                     <td> <asp:Label ID="lblfechamodificacion" runat="server" Text=""></asp:Label> </td>
                </tr>
                <tr>
                    <td>Aprobado por:</td>
                    <td> <asp:Label ID="lblusuaprobado" runat="server" Text=""></asp:Label> </td>
                     <td>&nbsp;&nbsp;&nbsp;&nbsp;Fecha Aprobación</td>
                     <td> <asp:Label ID="lblfechaaprobacion" runat="server" Text=""></asp:Label> </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <div style="overflow: auto; width: 1000px; height: 150px">
                            <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" OnRowCreated="griddata_RowCreated" Font-Size="Smaller" Width="969px">
                                <Columns>
                                    <asp:BoundField DataField="GD_CVANEXO" HeaderText="T" />
                                    <asp:BoundField DataField="GD_CCODIGO" HeaderText="CODIGO" />
                                    <asp:BoundField DataField="GD_CNDREF" HeaderText="NOMBRE" />
                                    <asp:BoundField DataField="GD_CTIPDOC" HeaderText="TD" />
                                    <asp:BoundField DataField="GD_CNUMDOC" HeaderText="NRO. DOC" />
                                    <asp:BoundField DataField="GD_DFECDOC" HeaderText="FEC. DOC.">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="GD_DFECVEN" HeaderText="FEC. VENC.">

                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="GD_CMONCAR" HeaderText="MON">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="GD_NORPROG" HeaderText="PROGRAMADO">

                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="GD_NORRETE" HeaderText="T">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="GD_CRETE" HeaderText="RETE">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="GD_NMNPROG" HeaderText="PROG. NETO">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="GD_CTASDET" HeaderText="TASA DETRA." />


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
            </table>
       </div>
        <div id="Ejecución"> 
            <table>
                <tr>
                    <td>Agencia&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                    <td>
                        <asp:Label ID="lblcodagenciae" runat="server" Text=""></asp:Label>
                        -
                        <asp:Label ID="lblagenciae" runat="server" Text=""></asp:Label></td>
                    <td>Monto&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                    <td>
                        <asp:TextBox ID="txtmontoe" runat="server" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Num.Prog.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                    <td>
                        <asp:TextBox ID="txtprogramacione" runat="server" Width="170px" Enabled="false"></asp:TextBox>
                    </td>
                    <td>Fech. Prog.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                    <td>
                        <asp:TextBox ID="txtfechaprogramacione" runat="server" Enabled="false"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td>Concepto&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                    <td>
                        <asp:Label ID="lblcodconceptoe" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lblconceptoe" runat="server" Text=""></asp:Label>
                    </td>

                    <td>Tipo Detracción:</td>
                    <td>
                        <asp:Label ID="lblcoddetraccione" runat="server" Text=""></asp:Label>-
                        <asp:Label ID="lbldetraccione" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Tipo Pago&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                    <td>
                        <asp:Label ID="lblcodtipopagoe" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lbltipopagoe" runat="server" Text=""></asp:Label>
                    </td>

                    <td>Departamento&nbsp; :</td>
                    <td>
                        <asp:Label ID="lblcoddepartamentoe" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lbldepartamentoe" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Moneda&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                    <td>
                        <asp:Label ID="lblcodmonedae" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lblmonedae" runat="server" Text=""></asp:Label>
                    </td>

                    <td>Banco&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                    <td>
                        <asp:Label ID="lblcodbancoe" runat="server" Text=""></asp:Label>-
                        <asp:Label ID="lblbancoe" runat="server" Text=""></asp:Label>
                    &nbsp;<asp:Label ID="lblbancocuenta" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lbldebehaber" runat="server" ForeColor="White"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Tipo de Cambio:</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txttipocambioe" runat="server" Enabled="false"></asp:TextBox>

                    </td>
                    <td class="auto-style2">Estado&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtestadoe" runat="server" Text="" Enabled="false"></asp:TextBox>
                    &nbsp;<asp:Label ID="lblsobrante" runat="server" BorderStyle="None" Width="0px" ForeColor="White"></asp:Label>
                    &nbsp;<asp:Label ID="lblmontosobrante" runat="server" BorderStyle="None" Width="16px" ForeColor="White"></asp:Label>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>Fecha de Transacción </td>
                    <td>
                        <asp:TextBox ID="txtfechatransaccion" runat="server" Enabled="true" class="fecha"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Tipo de Cambio</td>
                    <td>
                        <asp:TextBox ID="txttipocamb" runat="server" Enabled="false"></asp:TextBox>
                        <input id="rbcompra" name="opcion" type="radio" value="1" runat="server" class="tipocambio" />
                        Comp.
                         <input id="rbventa" name="opcion" type="radio" value="2" runat="server" class="tipocambio" />
                        Vent.
                    </td>
                </tr>
                <tr>
                    <td>Area</td>
                    <td>
                        <asp:DropDownList ID="ddlarea" runat="server" Height="16px" Width="381px"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Medio Pago Tributario</td>
                    <td>
                        <asp:DropDownList ID="ddlmediopago" runat="server" Height="16px" Width="380px"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>Subdiario</td>
                    <td>
                        <asp:DropDownList ID="ddlsubdiario" runat="server" Height="19px" Width="380px"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>

                        <input id="btnejecutar0" type="button" value="Verificar" class="EJECUTAR1" /></td>
                    <td>
                        <input id="btnejecutar" type="button" value="Procesar" class="EJECUTAR" />
                    </td>
                </tr>
               
            </table>

            <table>
                <tr>
                    <td>
                        <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" OnRowCreated="griddata_RowCreated" Font-Size="Smaller" Width="510px" style="display:none" >
                                <Columns>
                                    <asp:BoundField DataField="CUENTA" HeaderText="CUENTA" />
                                    <asp:BoundField DataField="FECHA" HeaderText="FECHA" />
                                    <asp:BoundField DataField="SUMASOLESDEBE" HeaderText="DEBE_SOLES" />
                                    <asp:BoundField DataField="SUMASOLESHABER" HeaderText="HABER_SOLES" />
                                    <asp:BoundField DataField="SUMADOLARESDEBE" HeaderText="DEBE_DOLARES" />
                                    <asp:BoundField DataField="SUMADOLARESHABER" HeaderText="HABER_DOLARES">
                                                                           </asp:BoundField>
                                       <asp:BoundField DataField="TIPODOPC" HeaderText="TIPO_DOC" />
                                   

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
            </table>
        </div>

    </div>
    <div id="MostrarDetalles" style="display:none">
        <table>
            <tr>
                                    <td>
<asp:GridView ID="GridView3" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" OnRowCreated="griddata_RowCreated" Font-Size="Smaller" Width="510px" >
                                <Columns>
                                    <asp:BoundField HeaderText="CUENTA" DataField="CUENTA" />
                                    <asp:BoundField HeaderText="DDH" DataField="DDH" />
                                    <asp:BoundField HeaderText="DIMPORT" DataField="DIMPORT" />
                                    <asp:BoundField HeaderText="GLOSA" DataField="GLOSA" />
                                    <asp:BoundField HeaderText="DUSIMPORT" DataField="DUSIMPORT" />
                                    <asp:BoundField HeaderText="DMNIMPOR" DataField="DMNIMPOR">
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
                <td>Debe s/.</td>
                <td><asp:Label ID="lbldebesoles" runat="server" Text=""></asp:Label> </td>
            </tr>
             <tr>
                <td>Haber s/.</td>
                <td><asp:Label ID="lblhabersoles" runat="server" Text=""></asp:Label> </td>
            </tr>
            <tr>
                <td>Debe U$</td>
                <td><asp:Label ID="lbldebedolares" runat="server" Text=""></asp:Label> </td>
            </tr>
             <tr>
                <td>Haber U$ </td>
                <td><asp:Label ID="lblhaberdolares" runat="server" Text=""></asp:Label> </td>
            </tr>
        </table>
    </div>
    <br />
</asp:Content>
