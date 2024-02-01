<%@ Page Title="Programacion de Pagos" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ProgramacionPagos.aspx.cs" Inherits="FINANZAS_TESORERIA_PAGOS_ProgramacionPagos" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link type="text/css" href="../../../CSS/base.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {
            UHTML.id = 'MainContent';
            var pcuenta = "";
            M_ARRAY = [];
            var valida_x = function (input) {
                var sw = true;
                $.each(input, function (k, v) {
                    sa = true;
                    sa = sa && (Operacion.mask(v).is('[disabled]'));//SI ESTA DESAHABILITADO
                    if (sa == false) {
                        sw = sw && (Operacion.mask(v).val().trim() != '' && Operacion.mask(v).val() != null && Operacion.mask(v).val() != '-1');//COMPRUEBA VALOR
                        if (sw) {
                            sw = true;//ACTUALIZO MOV. 11.07.2016
                            (Operacion.mask(v).is('input') ? Operacion.mask(v).css('border', '#aaaaaa solid 1px') : "");
                            (Operacion.mask(v).is("select") ? Operacion.mask(v).css('border', '#aaaaaa solid 1px') : "");
                            (Operacion.mask(v).is("select") ? Operacion.mask(v).css('color', 'black') : "");
                        } else {
                            (Operacion.mask(v).is('input') ? Operacion.mask(v).css('border', 'red solid 1px') : "");
                            (Operacion.mask(v).is("select") ? Operacion.mask(v).css('color', 'red') : "");
                        }
                        //console.log("k=>" + k + " v=>" + v + " e=>" + sw + "valor=>" + Operacion.mask(v).val() + "VALOR" + (Operacion.mask(v).val() != '' && Operacion.mask(v).val() != null));
                    } else {
                        $(this).removeClass('placeholder');
                    }
                });
                return sw;
            }
            var mi_valida = function () {
                return valida_x([
                        'ddlagencia0', 'txtnumprog', 'ddlconcepto0',
                        'ddltipopago0', 'ddlmoneda', 'txtbancor',
                        'ddldepartamento0', 'txtdetrar'
                ]);//'lbldetarr', 'lblusuario','lblbancor',ddlagencia
            }

            var iniciaPGE = function (CO) {
                var PDATA = {};
                PDATA.AF_COD = CO;
                $.ajax({
                    type: "POST",
                    url: "ProgramacionPagos.aspx/getPARAM",
                    data: '{ PDATA: ' + JSON.stringify(PDATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        //console.log(data);
                        if (data.d.length > 0) {
                            jQuery.each(data.d, function (i, v) {
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
            pcuenta = M_ARRAY[0];


            Operacion.oACD('txtdetrar');
            Operacion.mask('txtdetrar').change(function () {
                Operacion.oACD('txtdetrar');
                if ($(this).val() == "99999") {
                    //Operacion.mask('txtdetrar').val($(this).val());
                    Operacion.mask('lbldetrar').text('Todos');
                } else {
                    $("#MainContent_txtdetrar").autocomplete(
                          {
                              source: function (request, response) {
                                  $.ajax({
                                      url: "ProgramacionPagos.aspx/LISTARdetracciones",
                                      data: "{ 'productos': '" + request.term + "' }",
                                      dataType: "json",
                                      type: "POST",
                                      contentType: "application/json; charset=utf-8",
                                      dataFilter: function (data) { return data; },
                                      success: function (data) {
                                          if (data.d.length == 0) {
                                              if (request.term == "99999") {
                                                  return {
                                                      id: "Todos",
                                                      value: "99999"
                                                  };
                                              }
                                          }
                                          else {
                                              response($.map(data.d, function (item) {
                                                  return {
                                                      id: item.TDESCRI,
                                                      value: item.TCLAVE
                                                  }
                                              }))
                                          }

                                      },
                                      error: function (XMLHttpRequest, textStatus, errorThrown) {
                                          //alert(textStatus);
                                      }
                                  });
                              },
                              minLength: 1,
                              select: function (event, ui) {
                                  var str = ui.item.id;
                                  var cadena = str
                                  posicionEspacio = cadena.indexOf("@"), //Obtengo la posición del espacio en la cadena
                                  primerApellido = cadena.substring(0, posicionEspacio) //Obtengo la porción deseada de la cadena
                                  enMinuscula = primerApellido.toLowerCase(); //Convierto el apellido a minúscula

                                  primerApellido = cadena.substring(posicionEspacio + 1, str.length)
                                  $('#MainContent_lbldetrar').html(str);
                              }
                          });
                }
            });

           

            $("#MainContent_txtbancor").autocomplete(
                { 
                    source: function (request, response) {
                        $.ajax({
                            url: "ProgramacionPagos.aspx/ListarBancosProg",
                            data: "{ 'productos': '" + request.term + "' }",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            dataFilter: function (data) { return data; },
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        id: item.CT_CDESCTA,
                                        value: item.CT_CNUMCTA,
                                                                            }
                                }))
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                //alert(textStatus);
                            }
                        });
                    },
                    minLength: 1,
                    select: function (event, ui) {
                        var str = ui.item.id;
                        var cadena = str
                        posicionEspacio = cadena.indexOf("@"), //Obtengo la posición del espacio en la cadena
                        primerApellido = cadena.substring(0, posicionEspacio) //Obtengo la porción deseada de la cadena
                        enMinuscula = primerApellido.toLowerCase(); //Convierto el apellido a minúscula
                        primerApellido = cadena.substring(posicionEspacio + 1, str.length)
                        $('#MainContent_lblbancor').val(str);
                     }
                });

            $("#MainContent_lblbancor").autocomplete(
     {
         source: function (request, response) {
             $.ajax({
                 url: "ProgramacionPagos.aspx/ListarBancosProg",
                 data: "{ 'productos': '" + request.term + "' }",
                 dataType: "json",
                 type: "POST",
                 contentType: "application/json; charset=utf-8",
                 dataFilter: function (data) { return data; },
                 success: function (data) {
                     response($.map(data.d, function (item) {
                         return {
                             id: item.CT_CNUMCTA,
                             value: item.CT_CDESCTA

                         }
                     }))
                 },
                 error: function (XMLHttpRequest, textStatus, errorThrown) {
                     //alert(textStatus);
                 }
             });
         },
         minLength: 1,
         select: function (event, ui) {
             var str = ui.item.id;
             var cadena = str
             posicionEspacio = cadena.indexOf("@"), //Obtengo la posición del espacio en la cadena
             primerApellido = cadena.substring(0, posicionEspacio) //Obtengo la porción deseada de la cadena
             enMinuscula = primerApellido.toLowerCase(); //Convierto el apellido a minúscula
             primerApellido = cadena.substring(posicionEspacio + 1, str.length)
             $('#MainContent_txtbancor').val(str);
         }
     });
            $("#MainContent_txtfecha").datepicker();
            $("#MainContent_txtfechaprog").datepicker();
            $("#MainContent_txtvencimiento1").datepicker();
            $("#MainContent_txtvencimiento2").datepicker();

            $(window).load(function () {
                inicio = 0;
                verificacheck();
            });

            function generar() {

                var contador = "";

                $.ajax({

                    type: "POST",
                    url: "ProgramacionPagos.aspx/GENERAR",
                    data: "",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        var ultimodato = Number(data.d) + 1;
                        var formato = Operacion.cadenaMascara(ultimodato, 10)
                        $('#MainContent_txtnumprog').val(formato);

                    },
                    error: function (data) {
                        if (data.length != 0)
                            alert(data);
                    }
                });
            }
            function tipocambiocompra() {
                var fecemi = moment($("#MainContent_txtfechaprog").val(), "DD/MM/YYYY");
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
                                $('#MainContent_txttipocambio').val(data.d[i].XMEIMP);
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
                var fecemi = moment($("#MainContent_txtfechaprog").val(), "DD/MM/YYYY");
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
                                $('#MainContent_txttipocambio').val(data.d[i].XMEIMP2);
                            }
                        }
                    },
                    error: function (data) {
                        if (data.length != 0)
                            console.log(data);
                    }
                });
            }
            function formato_numero(numero, decimales, separador_decimal, separador_miles) { // v2007-08-06
                numero = parseFloat(numero);
                if (isNaN(numero)) {
                    return "";
                }

                if (decimales !== undefined) {
                    // Redondeamos
                    numero = numero.toFixed(decimales);
                }

                // Convertimos el punto en separador_decimal
                numero = numero.toString().replace(".", separador_decimal !== undefined ? separador_decimal : ",");

                //if (separador_miles) {
                //    // Añadimos los separadores de miles
                //    var miles = new RegExp("(-?[0-9]+)([0-9]{3})");
                //    while (miles.test(numero)) {
                //        numero = numero.replace(miles, "$1" + separador_miles + "$2");
                //    }
                //}

                return numero;
            }


            function pad(str, max) {
                if (str != undefined) {
                    str = str.toString();
                    return str.length < max ? pad("0" + str, max) : str;
                }
            }

            $('#Nuevo').dialog({
                autoOpen: false,
                modal: true,
                resizable: true,
                width: 1000,
                heigth: 100,
                title: 'Registro',
                close: function (event, ui) {
                    location.reload();
                },
            });


            $('#Modificacion').dialog({
                autoOpen: false,
                modal: true,
                resizable: true,
                width: 1000,
                heigth: 100,
                title: 'Modificación',
                close: function (event, ui) {

                },
            });
            $('#Edicion').dialog({
                autoOpen: false,
                modal: true,
                resizable: true,
                width: 1000,
                heigth: 100,
                title: 'Edicion',
                close: function (event, ui) {

                },
            });

            $('#detalle').dialog({
                autoOpen: false,
                modal: true,
                resizable: true,
                width: 1000,
                heigth: 100,
                title: 'Selección de Items',
                close: function (event, ui) {
                    limpiarchecks();
                    limpiargrilla2();
                    document.getElementById("<%=chklistar.ClientID%>").checked = false;
                },
            });


            $(".Nuevo").click(function () {
                $("#Nuevo").dialog('open');
                generar();
                 //para obtener el area
                $("#MainContent_ddldepartamento0").val("FI");
                 for (var area = 0 ; area < document.getElementById("<%= ddldepartamento0.ClientID %>").length; area++) {
                 if (document.getElementById("<%= ddldepartamento0.ClientID %>").options[area].text == ("FI-FINANZAS"))
                 document.getElementById("<%= ddldepartamento0.ClientID %>").selectedIndex = area;
                 }
                Operacion.mask('lbldetrar').text("Todos");
                Operacion.mask('txtdetrar').val("99999");
                 document.getElementById("<%= rbventa.ClientID %>").checked = true;
                tipocambioVenta();
            });
            $(".fecha").change(function () {
                document.getElementById("<%= rbventa.ClientID %>").checked = true;
                tipocambioVenta()
            });

            $(".seleccionar").click(function () {
                $("#detalle").dialog('open');
                trp = $(this).parent().parent();
                id = $("td:eq(1)", trp).html();
                des = $("td:eq(2)", trp).html();
                anexo = $("td:eq(0)", trp).html();
                var codigo = id;
                $('#MainContent_lblruc').html(id);
                $('#MainContent_lblproveedor').html(des);
                $('#MainContent_lblanexo').html(anexo);
                filtrardetalles(id);
                listariguales();


            });
            $(".editar").click(function () {

                $("#Modificacion").dialog('open');

            });

            $(".grabar").click(function () {
                var MI_TC = Operacion.mask('txttipocambio').val();
                //console.log(MI_TC);
                var MI_TOT = Operacion.mask('lbltotalacumulado1').text();
                if (mi_valida() && Number(MI_TOT) > 0) {// && Number(MI_TOT)==0 
                    InsertarSolicitud();
                   // InsertarDetalles();
                    limpiargrilla3();
                    $("#MainContent_lbltotalacumulado").html("");
                    $("#Nuevo").dialog('close');
                }
                else {
                    alert("No ha seleccionado ninguna factura");
                }


            });

            $(".LIMPIAR").click(function () {

                verificacheck();

            });
            function verificacheck() {
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
            }

            $(".tipocambio").click(function () {

                if ((document.getElementById("<%=rbventa.ClientID%>").checked == true)) {
                    tipocambioVenta();

                }
                if ((document.getElementById("<%=rbcompra.ClientID%>").checked == true)) {
                    tipocambiocompra();

                }

            });

            $(".ListarTotales").click(function () {
                var MI_TC = Operacion.mask('txttipocambio').val();
                if (mi_valida() && MI_TC != "") {
                    
                    $.ajax({
                        type: "POST",
                        url: "ProgramacionPagos.aspx/LISTARTOTALES",
                        data: "{ 'VC': '" + pcuenta + "' }",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (data) {
                            if (data.d.length > 0) {
                                var row = $("[id*=GridView1] tr:last-child").clone(true);
                                $("[id*=GridView1] tr").not($("[id*=GridView1] tr:first-child")).remove();

                                for (var i = 0; i < data.d.length; i++) {
                                    $("td", row).eq(0).html(data.d[i].Ane);
                                    $("td", row).eq(1).html(data.d[i].Codigo);
                                    $("td", row).eq(2).html(data.d[i].Acreedor);

                                    if (data.d[i].Vencido == null) {
                                        $("td", row).eq(3).html("0.00");
                                    }
                                    else {
                                        $("td", row).eq(3).html(formato_numero(data.d[i].Vencido, 2, ".", ","));
                                    }

                                    if (data.d[i].PorVencer == null) {
                                        $("td", row).eq(4).html("0.00");
                                    }
                                    else {
                                        $("td", row).eq(4).html(formato_numero(data.d[i].PorVencer, 2, ".", ","));
                                    }
                                    if (data.d[i].Stotal == null) {
                                        $("td", row).eq(5).html(formato_numero((Number(data.d[i].Vencido) + Number(data.d[i].PorVencer)), 2, ".", ","));
                                    }
                                    else {
                                        $("td", row).eq(5).html(formato_numero(data.d[i].Stotal, 2, ".", ","));
                                    }

                                    $("td", row).eq(6).html("0.00");
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
                                $("td", row).eq(0).html("");
                                $("[id*=GridView1]").append(row);
                                alert("No se encontro registro");
                            }
                        },
                        error: function (response) {
                            if (response.length != 0)
                                console.log(response);
                        }
                    });
                }
                else {
                    alert("Complete los datos antes de continuar");
                }
                recorregridtotales();

            });


            function InsertarSolicitud() {

                var fecemi = moment($("#MainContent_txtfechaprog").val(), "DD/MM/YYYY");

                fecemi = fecemi == null ? null : new Date(fecemi);

                var DETA = {};
                DETA.GC_CCODAGE = $("#MainContent_ddlagencia0").val();
                DETA.GC_CNUMOPE = $("#MainContent_txtnumprog").val();
                DETA.GC_DFECPRO = fecemi;
                DETA.GC_CCODCON = $("#MainContent_ddlconcepto0").val();
                DETA.GC_CTIPPAG = $("#MainContent_ddltipopago0").val();
                DETA.GC_CCODBAN = $("#MainContent_txtbancor").val();
                DETA.GC_CCODMON = $("#MainContent_ddlmoneda").val();;
                DETA.GC_CCODDEP = $("#MainContent_ddldepartamento0").val();
                DETA.GC_CNUMLOT = "-";
                DETA.GC_CTASDET = $("#MainContent_txtdetrar").val();
                DETA.GC_NTIPCAM = $("#MainContent_txttipocambio").val();
                DETA.GC_NMONPRO = $("#MainContent_lbltotalacumulado1").html();
                DETA.GC_CESTADO = "P"; // estado pendiente
                DETA.GC_CUSUCRE = $("#MainContent_lblusuario").html();
                DETA.GC_DFECCRE = fecemi;
                DETA.GC_CUSUMOD = $("#MainContent_lblusuario").html();
                DETA.GC_DFECMOD = fecemi;
                DETA.GC_CUSUAPR = "-";
                DETA.GC_DFECAPR = null; // aparece la fecah de aprobacion cuando se apruebe.
                //console.log(DETA);
                $.ajax({
                    type: "POST",
                    url: "ProgramacionPagos.aspx/InsertaDet",
                    data: '{DETA: ' + JSON.stringify(DETA) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        alert("Registro Grabado");
                        InsertarDetalles();
                        ActualizaProg();
                    },
                    error: function (response) {
                        if (response.length != 0)
                            console.log(response);
                    }
                });
            }

            function ActualizaProg() {

                var DETA = {};
                DETA.AG_CCODAGE = $("#MainContent_ddlagencia0").val();
                DETA.AG_NULTOPE = Number($("#MainContent_txtnumprog").val());
               
                $.ajax({
                    type: "POST",
                    url: "ProgramacionPagos.aspx/ActualizaProg",
                    data: '{DETA: ' + JSON.stringify(DETA) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                       // alert("Registro Actualizado");
                        
                    },
                    error: function (response) {
                        if (response.length != 0)
                            console.log(response);
                    }
                });
            }



            function InsertarDetalles() {

                var fecemi = moment($("#MainContent_txtfechaprog").val(), "DD/MM/YYYY");

                fecemi = fecemi == null ? null : new Date(fecemi);

                var DETA = {};

                var gridView = document.getElementById("<%=GridView3.ClientID %>");
                var MI_LEN = gridView.rows.length;
                for (var t = 1; t < MI_LEN; t++) {
                    if (gridView.rows[t].cells[0].innerHTML.trim()!="") {
                                      

                    var N_PRO = $("#MainContent_txtnumprog").val();
                    //var ultimodato = t.toString();
                    var formato = Operacion.cadenaMascara(t, 4);//ultimodato.length < 4 ? pad("0" + ultimodato, 4) : ultimodato;
                    DETA.GD_CCODAGE = $("#MainContent_ddlagencia0").val();
                    DETA.GD_CNUMOPE = N_PRO;
                    DETA.GD_CSECUE = formato;
                    DETA.GD_CVANEXO = $("#MainContent_lblanexo").text();
                    DETA.GD_CCODIGO = (gridView.rows[t].cells[13].innerHTML).trim();
                    DETA.GD_CTIPDOC = (gridView.rows[t].cells[0].innerHTML).trim();
                    DETA.GD_CNUMDOC = (gridView.rows[t].cells[1].innerHTML).trim();
                    DETA.GD_DFECPRO = fecemi;

                    var FECDOC = moment(gridView.rows[t].cells[2].innerHTML, "DD/MM/YYYY");
                    FECDOC = FECDOC == null ? null : new Date(FECDOC);
                    DETA.GD_DFECDOC = FECDOC;

                    var FECVEN = moment(gridView.rows[t].cells[3].innerHTML, "DD/MM/YYYY");
                    FECVEN = FECVEN == null ? null : new Date(FECVEN);
                    DETA.GD_DFECVEN = FECVEN;
                    DETA.GD_CMONCAR = gridView.rows[t].cells[5].innerHTML; // moneda
                    DETA.GD_NORPROG = Number(gridView.rows[t].cells[6].innerHTML);
                    DETA.GD_NTIPCAM = Number($("#MainContent_txttipocambio").val());
                    DETA.GD_CCODMON = $("#MainContent_ddlmoneda").val();
                    DETA.GD_NUSPROG = Operacion.mround((Number(gridView.rows[t].cells[6].innerHTML) / Number($("#MainContent_txttipocambio").val())),2);
                    DETA.GD_NMNPROG = Operacion.mround((Number(gridView.rows[t].cells[11].innerHTML)),2);
                    DETA.GD_CTIPCTA = "";
                    DETA.GD_CTIPPRO = "";
                    DETA.GD_CNUMCTA = "";
                    DETA.GD_CSUBDIA = "";
                    DETA.GD_CCOMPRO = "";
                    DETA.GD_NMNRETE =Operacion.mround((Number(gridView.rows[t].cells[10].innerHTML)),2);
                    DETA.GD_NUSRETE =Operacion.mround(( Number(gridView.rows[t].cells[10].innerHTML) / Number($("#MainContent_txttipocambio").val())),2);
                    DETA.GD_NORRETE = Number("0.00");
                    DETA.GD_CRETE ="";
                    DETA.GD_NPORRE = Number("0.00");
                    DETA.GD_CTASDET = (gridView.rows[t].cells[12].innerHTML).trim();
                    DETA.GD_CSUBCOM = "";
                    DETA.GD_CNUMCOM = "";
                    DETA.GD_CSECCOM = "";
                    DETA.GD_CTDREF = "";
                    DETA.GD_CNDREF = "";
                    DETA.GD_NTCORI = Number("0.00");
                   
                    $.ajax({
                        type: "POST",
                        url: "ProgramacionPagos.aspx/InsertaDetalle",
                        data: '{DETA: ' + JSON.stringify(DETA) + '}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (response) {
                            if (i == (MI_LEN - 1)) {
                                alert('Se ha generado un nueva programacion:' + N_PRO);
                            }
                        },
                        error: function (response) {
                            if (response.length != 0)
                                console.log(DETA);

                        }
                    });

                    } // fin if

                }
            }

            function filtrardetalles(codigo) {
                var VC = {};
                VC.CP_CCODIGO = codigo;
                VC.CP_CCUENTA = pcuenta;
                VC.CP_CVANEXO = $("#MainContent_lblanexo").text().substring(0, 1);
               // alert(VC.CP_CVANEXO);
                $.ajax({

                    type: "POST",
                    url: "ProgramacionPagos.aspx/filtrodetalle",
                    data: '{VC: ' + JSON.stringify(VC) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {

                        if (data.d.length > 0) {
                            var row = $("[id*=GridView2] tr:last-child").clone(true);
                            $("[id*=GridView2] tr").not($("[id*=GridView2] tr:first-child")).remove();

                            for (var i = 0; i < data.d.length; i++) {
                                $("td", row).eq(1).html(data.d[i].CP_CTIPDOC);
                                $("td", row).eq(2).html(data.d[i].CP_CNUMDOC);
                                $("td", row).eq(3).html((moment(data.d[i].CP_DFECDOC).format("DD/MM/YYYY")));

                                $("td", row).eq(4).html((moment(data.d[i].CP_DFECVEN).format("DD/MM/YYYY")));
                                $("td", row).eq(5).html("0.00");
                                $("td", row).eq(6).html(data.d[i].CP_CCODMON);
                                $("td", row).eq(7).html(data.d[i].CP_NSALDMN);
                                $("td", row).eq(8).html("0.00");
                                $("td", row).eq(9).html("0.00");
                                $("td", row).eq(10).html("");
                                if (data.d[i].CP_CRETE == " ") {
                                    $("td", row).eq(11).html("0.00");
                                }
                                else {
                                    $("td", row).eq(11).html(data.d[i].CP_CRETE);
                                }
                                $("td", row).eq(12).html("0.00");
                                $("td", row).eq(13).html(data.d[i].CP_CTASDET);

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
                            $("td", row).eq(7).html("");
                            $("td", row).eq(8).html("");
                            $("td", row).eq(9).html("");
                            $("td", row).eq(10).html("");
                            $("td", row).eq(11).html("");
                            $("td", row).eq(12).html("");
                            $("td", row).eq(13).html("");
                            $("[id*=GridView2]").append(row);
                            alert("no se encontro registro");
                        }


                    },
                    error: function (response) {
                        if (response.length != 0)
                            alert(response);
                    }
                });
            }
            $(".validaunoporuno").click(function () {
                var imput = document.getElementsByName('opt');
                var gridView = document.getElementById("<%=GridView2.ClientID %>");

                for (var i = 0; i < imput.length; i++) {
                    if (imput[i].checked) {
                        gridView.rows[i + 1].cells[9].innerHTML = gridView.rows[i + 1].cells[7].innerHTML
                        gridView.rows[i + 1].cells[12].innerHTML = Number(gridView.rows[i + 1].cells[9].innerHTML) - Number(gridView.rows[i + 1].cells[11].innerHTML)

                    }
                    else {
                        gridView.rows[i + 1].cells[9].innerHTML = "0.00";
                        gridView.rows[i + 1].cells[12].innerHTML = "0.00";
                    }
                }
                recorregridaux();
            });
            $(".Continuar").click(function () {

                var gridView = document.getElementById("<%=GridView1.ClientID %>");
                for (var t = 0; t < gridView.rows.length; t++) {
                    if (gridView.rows[t].cells[1].innerHTML == $("#MainContent_lblruc").html()) {
                        gridView.rows[t].cells[6].innerHTML = $("#MainContent_lbltotalacumulado").html();
                    }
                }
                borrariguales();
                var gv3 = document.getElementById("<%=GridView3.ClientID %>");
                //alert(gv3.rows.length);
                if (gv3.rows.length == 1) {
                    agregarblanco();
                }
                AgregarGrilla();
                recorregridaux1();
                limpiarchecks();
                limpiargrilla2();
                $("#MainContent_lbltotalacumulado").html("0.00")
                document.getElementById("<%=chklistar.ClientID%>").checked = false;
                $("#detalle").dialog('close');
                
            });
            function limpiargrilla2() {

                var row = $("[id*=GridView2] tr:last-child").clone(true);
                $("[id*=GridView2] tr").not($("[id*=GridView2] tr:first-child")).remove();
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
                $("td", row).eq(13).html("");
                $("[id*=GridView2]").append(row);

            }

            function limpiargrilla3() {

                var row = $("[id*=GridView3] tr:last-child").clone(true);
                $("[id*=GridView3] tr").not($("[id*=GridView3] tr:first-child")).remove();
                $("td", row).eq(0).html("");
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
                $("td", row).eq(13).html("");
                $("[id*=GridView3]").append(row);

            }

            function limpiarchecks() {


                var imput = document.getElementsByName('opt');
                // var gridView = document.getElementById("<%=GridView2.ClientID %>");
                for (var i = 0; i < imput.length; i++) {
                    imput[i].checked = false;
                }


            }

            $(".valida").click(function () {

                $("#detalle").dialog('open');

                if ((document.getElementById("<%=chklistar.ClientID%>").checked == true)) {
                    var imput = document.getElementsByName('opt');
                    var gridView = document.getElementById("<%=GridView2.ClientID %>");
                    for (var i = 0; i < imput.length; i++) {
                        imput[i].checked = true
                    }
                    for (var i = 0; i < imput.length; i++) {
                        if (imput[i].checked) {
                            gridView.rows[i + 1].cells[9].innerHTML = gridView.rows[i + 1].cells[7].innerHTML
                            gridView.rows[i + 1].cells[12].innerHTML = Number(gridView.rows[i + 1].cells[9].innerHTML) - Number(gridView.rows[i + 1].cells[11].innerHTML)

                        }
                        else {
                            gridView.rows[i + 1].cells[9].innerHTML = "0.00";
                            gridView.rows[i + 1].cells[12].innerHTML = "0.00";
                        }
                    }
                }
                else {

                    var imput = document.getElementsByName('opt');
                    var gridView = document.getElementById("<%=GridView2.ClientID %>");
                    for (var i = 0; i < imput.length; i++) {
                        imput[i].checked = false
                    }

                    for (var i = 0; i < imput.length; i++) {
                        if (imput[i].checked) {
                            gridView.rows[i + 1].cells[9].innerHTML = gridView.rows[i + 1].cells[7].innerHTML
                            gridView.rows[i + 1].cells[12].innerHTML = Number(gridView.rows[i + 1].cells[9].innerHTML) - Number(gridView.rows[i + 1].cells[11].innerHTML)

                        }
                        else {
                            gridView.rows[i + 1].cells[9].innerHTML = "0.00";
                            gridView.rows[i + 1].cells[12].innerHTML = "0.00";
                        }
                    }
                }

                recorregridaux();

            });

            function recorregridaux() {
                subtt = 0; acum = 0;
                sumasub = 0;

                var gridView = document.getElementById("<%=GridView2.ClientID %>");

                for (var t = 1; t < gridView.rows.length; t++) {
                    var inputs = gridView.rows[t].getElementsByTagName('input');

                    cellPivot = gridView.rows[t].cells[12];
                    subtt = cellPivot.innerHTML;
                    sumasub = new Number(sumasub) + new Number(subtt);
                }

                $("#MainContent_lbltotalacumulado").html(formato_numero(sumasub, 2, ".", ","));
            }

            function recorregridaux1() {
                subtt = 0; acum = 0;
                sumasub = 0; tc =  Number($("#MainContent_txttipocambio").val());

                var gridView = document.getElementById("<%=GridView3.ClientID %>");

                for (var t = 1; t < gridView.rows.length; t++) {
                    var inputs = gridView.rows[t].getElementsByTagName('input');
                   
                    if (gridView.rows[t].cells[5].textContent == "MN") {
                        cellPivot = gridView.rows[t].cells[11];
                        subtt = cellPivot.innerHTML;
                        sumasub = new Number(sumasub) + new Number(subtt);
                    }
                    else {
                        cellPivot = gridView.rows[t].cells[11];
                        subtt = cellPivot.innerHTML;
                        sumasub = new Number(sumasub) + (Number(subtt) * Number(tc)); 
                       // alert(sumasub);
                    }
                }

                $("#MainContent_lbltotalacumulado1").html(formato_numero(sumasub, 2, ".", ","));
            }

           function recorregridtotales() {
               subtt = 0; acum = 0;
               subtt2 = 0;
               subtt3 = 0;
               subtt4 = 0;
                sumasub = 0; tc = Number($("#MainContent_txttipocambio").val());
                sumasub2 = 0;
                sumasub3 = 0;
                sumasub4 = 0;
                var gridView = document.getElementById("<%=GridView1.ClientID %>");
                for (var t = 1; t < gridView.rows.length; t++) {
                    var inputs = gridView.rows[t].getElementsByTagName('input');
                        cellPivot = gridView.rows[t].cells[3];
                        subtt = cellPivot.innerHTML;
                        sumasub = new Number(sumasub) + new Number(subtt);

                        cellPivot2 = gridView.rows[t].cells[4];
                        subtt2 = cellPivot2.innerHTML;
                        sumasub2 = new Number(sumasub2) + new Number(subtt2);

                        cellPivot3 = gridView.rows[t].cells[5];
                        subtt3 = cellPivot3.innerHTML;
                        sumasub3 = new Number(sumasub3) + new Number(subtt3);

                        cellPivot4 = gridView.rows[t].cells[6];
                        subtt4 = cellPivot4.innerHTML;
                        sumasub4 = new Number(sumasub4) + new Number(subtt4);
                }

                $("#MainContent_lbltotal1").html(formato_numero(sumasub, 2, ".", ","));
                $("#MainContent_lbltotal2").html(formato_numero(sumasub2, 2, ".", ","));
                $("#MainContent_lbltotal3").html(formato_numero(sumasub3, 2, ".", ","));
                $("#MainContent_lbltotal4").html(formato_numero(sumasub4, 2, ".", ","));
            }



            function AgregarGrilla() {
                var imput = document.getElementsByName('opt');
                var gridView = document.getElementById("<%=GridView2.ClientID %>");
                var gridView3 = document.getElementById("<%=GridView3.ClientID %>");
                var rowt = $("[id*=GridView3] tr:last-child").clone(true);
                if (inicio == 0) {
                    $("[id*=GridView3] tr").not($("[id*=GridView3] tr:first-child")).remove();
                }
                for (var i = 0; i < imput.length; i++) {
                    if (imput[i].checked) {
                        $("td", rowt).eq(0).html(gridView.rows[i + 1].cells[1].innerHTML);
                        $("td", rowt).eq(1).html(gridView.rows[i + 1].cells[2].innerHTML);
                        $("td", rowt).eq(2).html(gridView.rows[i + 1].cells[3].innerHTML);
                        $("td", rowt).eq(3).html(gridView.rows[i + 1].cells[4].innerHTML);

                        $("td", rowt).eq(4).html(gridView.rows[i + 1].cells[5].innerHTML);
                        $("td", rowt).eq(5).html(gridView.rows[i + 1].cells[6].innerHTML);
                        $("td", rowt).eq(6).html(gridView.rows[i + 1].cells[7].innerHTML);
                        $("td", rowt).eq(7).html(gridView.rows[i + 1].cells[8].innerHTML);

                        $("td", rowt).eq(8).html(gridView.rows[i + 1].cells[9].innerHTML);
                        $("td", rowt).eq(9).html(gridView.rows[i + 1].cells[10].innerHTML);
                        $("td", rowt).eq(10).html(gridView.rows[i + 1].cells[11].innerHTML);
                        $("td", rowt).eq(11).html(gridView.rows[i + 1].cells[12].innerHTML);
                        $("td", rowt).eq(12).html(gridView.rows[i + 1].cells[13].innerHTML);
                        $("td", rowt).eq(13).html($("#MainContent_lblruc").html());
                        $("[id*=GridView3]").append(rowt);
                        rowt = $("[id*=GridView3] tr:last-child").clone(true);
                    }
                }
                inicio = 1;
            }
            function agregarblanco() {
                var table = document.getElementById('<%=GridView3.ClientID %>');
                var newRow = table.insertRow();
                var i = 0;
                for (i = 0; i < 14; i++) {
                    var newCell = newRow.insertCell();
                    newCell.innerHTML = '';
                }

            }

            function listariguales() {

                var gridView2 = document.getElementById("<%=GridView2.ClientID %>");//gd
                var gridView3 = document.getElementById("<%=GridView3.ClientID %>");//gs
                var imput = document.getElementsByName('opt');//egd-gd

                for (var t = 0; t < gridView2.rows.length; t++) {
                    for (var u = 0; u < gridView3.rows.length; u++) {
                        if ((gridView3.rows[u].cells[1].textContent == gridView2.rows[t].cells[2].textContent) && ($("#MainContent_lblruc").html() == gridView3.rows[u].cells[13].textContent)) {
                            imput[t - 1].checked = true;
                            gridView2.rows[t].cells[9].innerHTML = gridView2.rows[t].cells[7].innerHTML
                            gridView2.rows[t].cells[12].innerHTML = Number(gridView2.rows[t].cells[9].innerHTML) - Number(gridView2.rows[t].cells[11].innerHTML)
                        }

                    }
                }
                recorregridaux();
            }

            function borrariguales() {

                var gridView2 = document.getElementById("<%=GridView2.ClientID %>");//gd
                var gridView3 = document.getElementById("<%=GridView3.ClientID %>");//gs

                for (var t = 1; t < gridView2.rows.length; t++) {
                    for (var u = 1; u < gridView3.rows.length; u++) {
                        if ((gridView3.rows[u].cells[1].textContent == gridView2.rows[t].cells[2].textContent) && ($("#MainContent_lblruc").html() == gridView3.rows[u].cells[13].textContent)) {
                            gridView3.deleteRow(u);
                        }

                    }
                }
               
            }
            Operacion.mask('txtbusca').keypress(function () {
                var s = $(this).val().toUpperCase().split(" ");
                $(".buscar tr:hidden").show();
                $.each(s, function () {
                    $(".buscar tr:visible .pro:not(:contains('" + this + "'))").parent().hide();
                });
            });

            $(".editar1").click(function () {
                trp = $(this).parent().parent();
                id = $("td:eq(1)", trp).html();
                $("#Edicion").dialog('open');
               // document.getElementById("btnaprobar").style.visibility = "hidden";
               filtrardetallese(id);
                cabecera(id);
            });
            function filtrardetallese(codigo) {
                var long = 0;
                $.ajax({

                    type: "POST",
                    url: "ProgramacionPagos.aspx/LISTARTTODOS",
                    data: "{ 'dato': '" + codigo + "' }",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        //console.log(data);
                        if (data.d.length > 0) {
                            var row = $("[id*=GridView4] tr:last-child").clone(true);
                            $("[id*=GridView4] tr").not($("[id*=GridView4] tr:first-child")).remove();

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

                                $("[id*=GridView4]").append(row);
                                row = $("[id*=GridView4] tr:last-child").clone(true);
                            }
                        } else {
                            var row = $("[id*=GridView4] tr:last-child").clone(true);
                            $("[id*=GridView4] tr").not($("[id*=GridView4] tr:first-child")).remove();

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
                            $("[id*=GridView4]").append(row);
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
                    url: "ProgramacionPagos.aspx/LISTARUNO",
                    data: "{ 'CODATA': '" + codigo + "' }",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {

                        if (data.d.length > 0) {

                            for (var i = 0; i < data.d.length; i++) {
                                $('#MainContent_lblcodagenciae').html(data.d[i].AGENCIA);
                                $('#MainContent_lblagenciae').html(data.d[i].AGENCIA2);
                                $('#MainContent_txtprogramacionmode').val(data.d[i].numope);
                                $('#MainContent_lblconceptoe').html(data.d[i].CONCEPTO);
                                $('#MainContent_lbltipopagoe').html(data.d[i].tipopago);
                                $('#MainContent_lblmonedae').html(data.d[i].moneda);
                                $('#MainContent_txttipocambiomode').val(data.d[i].TIPOCAMBIO);
                                $('#MainContent_txtmontomode').val(Number(data.d[i].IMPORTE).toFixed(2));
                                $('#MainContent_txtfechaprogmode').val((moment(data.d[i].fecah).format("DD/MM/YYYY")));
                                if (data.d[i].TIPODETRACCION != null) {
                                    long = data.d[i].TIPODETRACCION.length;
                                    $('#MainContent_lbldetraccione').html(data.d[i].TIPODETRACCION.substring(0, long - 15));
                                }
                                $('#MainContent_lbldetraccione').html(data.d[i].TIPODETRACCION);
                                $('#MainContent_lblcoddetraccione').html(data.d[i].TASADETRACCION);
                                $('#MainContent_lbldepartamentoe').html(data.d[i].DEPARTAMENTO);
                                $('#MainContent_lblcodbancoe').html(data.d[i].CODBANCO);
                                $('#MainContent_lblbancoe').html(data.d[i].BANCO);
                                $('#MainContent_txtestadomode').val(data.d[i].ESTADO);

                                $('#MainContent_lblusuelaboradoe').html(data.d[i].USUCRE);
                                $('#MainContent_lblusumodificadoe').html(data.d[i].USUMOD);
                                $('#MainContent_lblusuaprobadoe').html(data.d[i].USUAPRO);
                                $('#MainContent_lblfechaelaboradoe').html((moment(data.d[i].FECRE).format("DD/MM/YYYY")));
                                $('#MainContent_lblfechamodificacione').html((moment(data.d[i].FEMOD).format("DD/MM/YYYY")));
                                $('#MainContent_lblfechaaprobacione').html((moment(data.d[i].FEAPRO).format("DD/MM/YYYY")));

                                if (data.d[i].ESTADO.trim() == "APROBADA") {
                                    Operacion.inputEstado('btninconsistencias', 1, false);
                                    Operacion.inputEstado('btneliminar', 1, false);
                                }
                                else {
                                    Operacion.inputEstado('btninconsistencias', 0, false);
                                    Operacion.inputEstado('btneliminar', 0, false);
                                }
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

            function InsertaLog(ind) {
                var f = new Date();
                var ADATA = {};
                ADATA.L2_CNUMOPE = $('#MainContent_txtprogramacionmode').val();
                ADATA.L2_CCODAGE = $('#MainContent_lblcodagenciae').html();
                ADATA.L2_CUSUCRE = $('#MainContent_lblusuario').html();
                ADATA.L2_DFECCRE = f;


                if (ind == "A") {
                    ADATA.L2_CTIPTRA = "03";
                    ADATA.L2_CDESCRI = "Aprobación de Programación";
                    ADATA.L2_CORIGEN = "CPPROG10";

                }
                else {

                    ADATA.L2_CTIPTRA = "02";
                    ADATA.L2_CDESCRI = "Eliminación de Programación";
                    ADATA.L2_CORIGEN = "CPPROG04";
                }


                $.ajax({
                    type: "POST",
                    url: "ProgramacionPagos.aspx/InsertaLog2",
                    data: '{ADATA: ' + JSON.stringify(ADATA) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        // alert("Aprobado, ya puede ejecutar la programación");
                        location.reload();
                    },
                    error: function (response) {
                        if (response.length != 0)
                            console.log(response);

                    }
                });
            }
            
            $(".eliminar").click(function () {

                if ($('#MainContent_txtestadomod').val() == "APROBADA") {
                    alert("No es posible eliminar una programación que ya ha sido aprobada");

                }
                else {
                    if (confirm("Desea Eliminar la programación: " + $('#MainContent_txtprogramacionmode').val())) {
                        var DETA = {};
                        DETA.GC_CNUMOPE = $('#MainContent_txtprogramacionmode').val();
                        DETA.GC_CCODAGE = $('#MainContent_lblcodagenciae').html();
                        InsertaLog("E");
                        $.ajax({
                            type: "POST",
                            url: "ProgramacionPagos.aspx/ELIMINACABECERA",
                            data: '{alumno: ' + JSON.stringify(DETA) + '}',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            async: false,
                            success: function (response) {
                                alert("REGISTRO ELIMINADO");
                            },
                            error: function (response) {
                                if (response.length != 0)
                                    console.log(response);

                            }
                        });
                        var ADATA = {};
                        var gridView = document.getElementById("<%=GridView4.ClientID %>");
                        for (var t = 1; t < gridView.rows.length; t++) {

                            ADATA.GD_CNUMOPE = $('#MainContent_txtprogramacionmode').val();
                            ADATA.GD_CCODAGE = $('#MainContent_lblcodagenciae').html();
                            ADATA.GD_CSECUE = gridView.rows[t].cells[0].value;

                            $.ajax({
                                type: "POST",
                                url: "ProgramacionPagos.aspx/ELIMINADETALLE",
                                data: '{ADATA: ' + JSON.stringify(ADATA) + '}',
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                async: false,
                                success: function (data) {
                                },
                                error: function (response) {
                                    if (response.length != 0)
                                        console.log(response);
                                }
                            });
                        }
                        $("#Edicion").dialog('close');
                    }
                }

            });

        });
    </script>
    <style type="text/css">
        #contenedor {
            width: 1120px;
        }

        .auto-style2 {
            width: 83px;
        }
        fieldset{
            width:1050px;
                    }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <%--<asp:ImageButton ID="imbeliminar" runat="server" ImageUrl="~/Images/Message_Error.png" Width="25px" OnClick="ib_eliminar_Click" onclientclick="javascript:return confirm('Esta Seguro?')"/>--%>
    <div id="contenedor">
        <%--<input id="Checkbox2" type="checkbox" value="1" name="tod" class="marcar" />--%>
        <div id="Creacion" title="Creación">
             <fieldset>
                <legend>
                    REGISTRO DE PROGRAMACIÓN DE PAGO
                </legend>
            <table>
                <tr>
                    <td class="auto-style2">
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
                        <asp:TextBox ID="txtannio" runat="server" Width="103px" MaxLength="4"></asp:TextBox>
                        <asp:Label ID="lblusuario" runat="server" Text="" ForeColor="#f1f1f1"></asp:Label>
                    </td>

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
                    <td>
                        <input id="btnnuevo" type="button" value="Nuevo" class="Nuevo" />
                    </td>
                </tr>

            </table>
                
                 </fieldset>
            <table>
                <tr>
                    <td>
                        <asp:GridView ID="gvordencompra" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" OnRowCreated="griddata_RowCreated" Width="817px">
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
                                <asp:TemplateField HeaderText="Consultar">

                                        <ItemTemplate>
                                            <div class="editar1" style="text-align: center">
                                                <img alt="" src="../../../Images/valid.png" width="25" style="cursor: pointer" />
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
            </table>
        </div>
        <div id="Nuevo" style="display:none" >
            <table>
                <tr>
                    <td>Agencia</td>
                    <td>
                        <asp:DropDownList ID="ddlagencia0" runat="server" Height="19px" Width="280px"></asp:DropDownList>
                    </td>
                    <td>Estado</td>
                    <td>
                        <asp:TextBox ID="txtestado" runat="server" Text="PENDIENTE" Enabled="false"></asp:TextBox>
                    </td>
                    <td>

                        <asp:TextBox ID="txtmonto" runat="server" ReadOnly="true" Visible="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Num.Prog.</td>
                    <td>
                        <asp:TextBox ID="txtnumprog" runat="server" Width="278px" ReadOnly="true"></asp:TextBox>
                    </td>
                    <td>Fech. Prog.</td>
                    <td>
                        <asp:TextBox ID="txtfechaprog" runat="server" Enabled="true" Class="fecha"></asp:TextBox>
                    </td>                  
                    
                </tr>
                <tr>
                    <td>Concepto</td>
                    <td>
                        <asp:DropDownList ID="ddlconcepto0" runat="server" Height="16px" Width="280px"></asp:DropDownList>
                    </td>

                    <td>Tipo Detracción</td>
                    <td>
                        <asp:TextBox ID="txtdetrar" runat="server" Width="56px"></asp:TextBox>
                        <asp:Label ID="lbldetrar" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Tipo Pago</td>
                    <td>
                        <asp:DropDownList ID="ddltipopago0" runat="server" Height="16px" Width="279px"></asp:DropDownList>
                    </td>

                    <td>Departamento</td>
                    <td>
                        <asp:DropDownList ID="ddldepartamento0" runat="server" Height="20px" Width="246px"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Moneda</td>
                    <td>
                        <asp:DropDownList ID="ddlmoneda" runat="server" Height="30px" Width="280px"></asp:DropDownList>
                    </td>

                    <td>Banco</td>
                    <td>
                        <asp:TextBox ID="txtbancor" runat="server" Width="58px"></asp:TextBox>
                        <asp:TextBox ID="lblbancor" runat="server" Width="183px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Tipo de Cambio</td>
                    <td>
                        <asp:TextBox ID="txttipocambio" runat="server" Enabled="false"></asp:TextBox>
                        <input id="rbcompra" name="opcion" type="radio" value="1" runat="server" class="tipocambio" />
                        Comp.
                         <input id="rbventa" name="opcion" type="radio" value="2" runat="server" class="tipocambio" />
                        Vent.
          
                    </td>

                    <td>Vencimiento</td>
                    <td>
                        <asp:TextBox ID="txtvencimiento1" runat="server" Width="93px" Enabled="false"></asp:TextBox>
                        <asp:TextBox ID="txtvencimiento2" runat="server" Width="97px" Enabled="false"></asp:TextBox>
                    </td>
                    <td>
                        <input id="btnprecesar" type="button" value="Procesar" class="ListarTotales" />
                    </td>
                </tr>
                <tr>
                    <td>Criterio:&nbsp;&nbsp;&nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtbusca" runat="server" placeholder="Busqueda Criterio"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <div style="overflow: auto; width: 800px; height: 300px">
                            <asp:GridView ID="GridView1" class="buscar" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" OnRowCreated="griddata_RowCreated" Width="782px">
                                <Columns>
                                    <asp:BoundField DataField="Ane" HeaderText="Ane" />
                                    <asp:BoundField DataField="Codigo" HeaderText="Código" >
                                            <ItemStyle CssClass="pro"></ItemStyle>
                                        </asp:BoundField>
                                    <asp:BoundField DataField="Acreedor" HeaderText="Acreedor" />
                                    <asp:BoundField DataField="Vencido" HeaderText="Vencido" DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PorVencer" HeaderText="Por Vencer" DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Stotal" HeaderText="S.Total" DataFormatString="{0:F2}">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ProgTotal" HeaderText="Prog. Total" DataFormatString="{0:F2}">

                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="REGISTROS">

                                        <ItemTemplate>
                                            <div class="seleccionar" style="text-align: center">
                                                <img alt="" src="../../../Images/valid.png" width="25" style="cursor: pointer" />
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

                        </div>
                    </td>
                    <td>
                        <%--<input id="Checkbox2" type="checkbox" value="1" name="tod" class="marcar" />--%>
                        <asp:GridView ID="GridView3" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" OnRowCreated="griddata_RowCreated" Width="200px" Font-Size="Smaller" Height="200px" style="display:none" >
                            <Columns>
                                <asp:BoundField DataField="CP_CTIPDOC" HeaderText="TD." />
                                <asp:BoundField DataField="CP_CNUMDOC" HeaderText="NUM.DOC." />
                                <asp:BoundField DataField="CP_DFECDOC" HeaderText="FEC. DOC." />
                                <asp:BoundField DataField="CP_DFECVEN" HeaderText="FEC. VEN." DataFormatString="{0:F2}">
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="DIAS" DataFormatString="{0:F2}">
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CP_CCODMON" HeaderText="MONEDA" DataFormatString="{0:F2}">
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CP_NSALDMN" HeaderText="SALDO" DataFormatString="{0:F2}">

                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>

                                <asp:BoundField HeaderText="OTRAS PROG." />
                                <asp:BoundField HeaderText="PROGRAMADO" />
                                <asp:BoundField HeaderText="T" />
                                <asp:BoundField DataField="CP_CRETE" HeaderText="RETE" />
                                <asp:BoundField HeaderText="PROG. NETO" />
                                <asp:BoundField DataField="CP_CTASDET" HeaderText="TASA" />

                                <asp:BoundField DataField="ACREEDOR" HeaderText="ACREEDOR" />

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
            <table>
                <tr>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; </td>
                    <td> 
                        <asp:Label ID="lbltotal1" runat="server" BorderStyle="Outset"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:Label ID="lbltotal2" runat="server" BorderStyle="Outset"></asp:Label> &nbsp;&nbsp;&nbsp; </td>
                    <td> <asp:Label ID="lbltotal3" runat="server" BorderStyle="Outset"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                    <td> <asp:Label ID="lbltotal4" runat="server" BorderStyle="Outset"></asp:Label></td>
                    <td>   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                </tr>
            </table>
            <table>
                
                <tr>

                    <td>TOTAL:</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lbltotalacumulado1" runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>

                    
                </tr>
                <tr>
                    <td>
                        <input id="btngrabar" type="button" value="Grabar" class="grabar" />

                    </td>
                     <td>
                        &nbsp;</td>
                </tr>

            </table>




        </div>
        <div id="detalle" style="display:none">
            <table>
                <tr>
                    <td>
                        <asp:CheckBox runat="server" Text="Todos/Ninguno" class="valida" ID="chklistar" />
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Acreedor:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                    <td>
                        <asp:Label ID="lblanexo" runat="server" Text=""></asp:Label>-
                    </td>
                    <td>
                        <asp:Label ID="lblruc" runat="server" Text=""></asp:Label></td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblproveedor" runat="server" Text=""></asp:Label>
                    </td>

                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" OnRowCreated="griddata_RowCreated" Width="782px" Font-Size="Smaller">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <%--<input id="Checkbox2" type="checkbox" value="1" name="tod" class="marcar" />--%>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <input type="checkbox" value="1" name="opt" class="validaunoporuno" />
                                    </ItemTemplate>

                                </asp:TemplateField>
                                <asp:BoundField DataField="CP_CTIPDOC" HeaderText="TD." />
                                <asp:BoundField DataField="CP_CNUMDOC" HeaderText="NUM.DOC." />
                                <asp:BoundField DataField="CP_DFECDOC" HeaderText="FEC. DOC." />
                                <asp:BoundField DataField="CP_DFECVEN" HeaderText="FEC. VEN." DataFormatString="{0:F2}">
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="DIAS" DataFormatString="{0:F2}">
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CP_CCODMON" HeaderText="MONEDA" DataFormatString="{0:F2}">
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CP_NSALDMN" HeaderText="SALDO" DataFormatString="{0:F2}">

                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>

                                <asp:BoundField HeaderText="OTRAS PROG." />
                                <asp:BoundField HeaderText="PROGRAMADO" />
                                <asp:BoundField HeaderText="T" />
                                <asp:BoundField DataField="CP_CRETE" HeaderText="RETE" />
                                <asp:BoundField HeaderText="PROG. NETO" />
                                <asp:BoundField DataField="CP_CTASDET" HeaderText="TASA" />

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
            <table>
                <tr>
                    <td>TOTAL</td>
                    <td>
                        <asp:Label ID="lbltotalacumulado" runat="server" Text=""></asp:Label></td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <input id="btncontinuar" type="button" value="Continuar" class="Continuar" /></td>
                </tr>
            </table>
        </div>
        <div id="Modificacion" style="display:none">
            <table>
                <tr>
                    <td>Agencia</td>
                    <td>
                        <asp:Label ID="lblcodagencia" runat="server" Text=""></asp:Label>
                        -
                        <asp:Label ID="lblagencia" runat="server" Text=""></asp:Label></td>
                    <td>Monto</td>
                    <td>
                        <asp:TextBox ID="txtmontomod" runat="server" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Num.Prog.</td>
                    <td>
                        <asp:TextBox ID="txtprogramacionmod" runat="server" Width="170px" Enabled="false"></asp:TextBox>
                    </td>
                    <td>Fech. Prog.</td>
                    <td>
                        <asp:TextBox ID="txtfechaprogmod" runat="server" Enabled="false"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td>Concepto</td>
                    <td>
                        <asp:Label ID="lblcodconcepto" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lblconcepto" runat="server" Text=""></asp:Label>
                    </td>

                    <td>Tipo Detracción</td>
                    <td>
                        <asp:Label ID="lblcoddetraccion" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lbldetraccion" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Tipo Pago</td>
                    <td>
                        <asp:Label ID="lblcodtipopago" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lbltipopago" runat="server" Text=""></asp:Label>
                    </td>

                    <td>Departamento</td>
                    <td>
                        <asp:Label ID="lblcoddepartamento" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lbldepartamento" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Moneda</td>
                    <td>
                        <asp:Label ID="lblcodmoneda" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lblmoneda" runat="server" Text=""></asp:Label>
                    </td>

                    <td>Banco</td>
                    <td>
                        <asp:Label ID="lblcodbanco" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lblbanco" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Tipo de Cambio</td>
                    <td>
                        <asp:TextBox ID="txttipocambiomod" runat="server" Enabled="false"></asp:TextBox>

                    </td>
                    <td>Estado</td>
                    <td>
                        <asp:TextBox ID="txtestadomod" runat="server" Text="PENDIENTE" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="Edicion" style="display:none">
            <table>
                <tr>
                    <td>Agencia&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                    <td>
                        <asp:Label ID="lblcodagenciae" runat="server" Text=""></asp:Label>
                        -
                        <asp:Label ID="lblagenciae" runat="server" Text=""></asp:Label></td>
                    <td>Monto&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                    <td>
                        <asp:TextBox ID="txtmontomode" runat="server" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Num.Prog.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                    <td>
                        <asp:TextBox ID="txtprogramacionmode" runat="server" Width="170px" Enabled="false"></asp:TextBox>
                    </td>
                    <td>Fech. Prog.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                    <td>
                        <asp:TextBox ID="txtfechaprogmode" runat="server" Enabled="false"></asp:TextBox>
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
                    </td>
                </tr>
                <tr>
                    <td>Tipo de Cambio:</td>
                    <td>
                        <asp:TextBox ID="txttipocambiomode" runat="server" Enabled="false"></asp:TextBox>

                    </td>
                    <td>Estado&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                    <td>
                        <asp:TextBox ID="txtestadomode" runat="server" Text="" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                </table>
                                    <table>
                <tr>
                    <td>Elaborado por:</td>
                    <td> <asp:Label ID="lblusuelaboradoe" runat="server" Text=""></asp:Label> </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;Fecha Elaboración</td>
                     <td> <asp:Label ID="lblfechaelaboradoe" runat="server" Text=""></asp:Label> </td>
                </tr>
                <tr>
                    <td>Modificado por:</td>
                    <td> <asp:Label ID="lblusumodificadoe" runat="server" Text=""></asp:Label> </td>
                     <td>&nbsp;&nbsp;&nbsp;&nbsp;Fecha Modificación</td>
                     <td> <asp:Label ID="lblfechamodificacione" runat="server" Text=""></asp:Label> </td>
                </tr>
                <tr>
                    <td>Aprobado por:</td>
                    <td> <asp:Label ID="lblusuaprobadoe" runat="server" Text=""></asp:Label> </td>
                     <td>&nbsp;&nbsp;&nbsp;&nbsp;Fecha Aprobación</td>
                     <td> <asp:Label ID="lblfechaaprobacione" runat="server" Text=""></asp:Label> </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <div style="overflow: auto; width: 1000px; height: 150px">
                            <asp:GridView ID="GridView4" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" OnRowCreated="griddata_RowCreated" Font-Size="Smaller" Width="969px">
                                <Columns>
                                    <asp:BoundField DataField="GD_CVANEXO" HeaderText="T" />
                                    <asp:BoundField DataField="GD_CCODIGO" HeaderText="CODIGO" />
                                    <asp:BoundField DataField="GD_CNDREF" HeaderText="NOMBRE">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="GD_CTIPDOC" HeaderText="TD" />
                                    <asp:BoundField DataField="GD_CNUMDOC" HeaderText="NRO. DOC" />
                                    <asp:BoundField DataField="GD_DFECDOC" HeaderText="FEC. DOC.">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="GD_DFECVEN" HeaderText="FEC. VENC.">

                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="GD_CMONCAR" HeaderText="MON">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="GD_NORPROG" HeaderText="PROGRAMADO">

                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="GD_NORRETE" HeaderText="T" />
                                    <asp:BoundField DataField="GD_CRETE" HeaderText="RETE">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="GD_NMNPROG" HeaderText="PROG. NETO">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="GD_CTASDET" HeaderText="TASA DETRA.">


                                        <HeaderStyle HorizontalAlign="Left" />
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
                        </div>
                    </td>

                </tr>
            </table>
            <table style="width: 177px">
                <tr>
                   <td>
                        <input id="btneliminar" type="button" value="Eliminar" class="eliminar" />
                    </td>

                </tr>

            </table>
        </div>
    <br />
</asp:Content>
