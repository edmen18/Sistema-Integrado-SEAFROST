<%@ Page Title="Listado" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ListadoCDOC.aspx.cs" Inherits="ListadoCDOC" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../../jquery/jquery.tablesorter.js"></script>
    <link type="text/css" href="../../Images/styles.css" rel="stylesheet" />
    <link type="text/css" href="../../CSS/Base-s.css?1.9" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {
            UHTML.id = 'MainContent';

            //Operacion.mask('txtOCF1').val(moment().format('DD/MM/YYYY'));
            Operacion.mask('txtOCF2').val(moment().format('DD/MM/YYYY'));
            //VARIABLES
            BANDERA = [];// M_USER = [];
            Operacion.inputVisible('lblBAH', 1);
            Operacion.inputVisible('txtBAH', 1);
            $("#MainContent_txtfecha2").datepicker();
            $("#MainContent_txtfecha1").datepicker();
            $(".mdp1").datepicker();
            $(".mdp2").datepicker();
            $(".dpoc1").datepicker();
            $(".dpoc2").datepicker();

            //CONFIGURACIONES
            var date = new Date()
            var primerDia = new Date(date.getFullYear(), date.getMonth(), 1);
            Operacion.mask('txtFI').val(moment(primerDia).format('DD/MM/YYYY'));
            Operacion.mask('txtFF').val(moment().format('DD/MM/YYYY'));

            Operacion.mask('txtfecha1').val(moment(primerDia).format('DD/MM/YYYY'));
            Operacion.mask('txtOCF1').val(moment(primerDia).format('DD/MM/YYYY'));
            Operacion.mask('ddlTIPOC').val('N');
            Operacion.mask('ddlTIOC').val('4');
            contarndw = 0;
            cc = 1;
            sw_edicion = 0;
            sw_nuevo = 0;
            contaditem = 0;

            $("#tabs").tabs({
                collapsible: true
            });
            filtarocomprainicio();
            var micontrol = function (USU) {
                var DATA = {};
                DATA.USUA_CAU = USU.toUpperCase().trim();
                DATA.ACCION_CAU = 3;
                //console.log(DATA); 
                $.ajax({
                    url: "../../ANTICIPO/OCemision.aspx/micontrol",
                    data: '{DATA:' + JSON.stringify(DATA) + '}',
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    async: false,
                    success: function (data) {

                        BANDERA = [data.d.CAMPO1_CAU, data.d.CAMPO2_CAU, data.d.CAMPO3_CAU];
                        //console.log(BANDERA);
                    },
                    error: function (data) {
                        console.log(data)
                    }
                });
            }

            var mi_combo = function (op) {

                if (op == "1") {
                    var data = [{ TN_CNUMSER: "0000", TDESCRI: "ELEGIR" },
                                    { TCLAVE: "-1", TDESCRI: "[Todos]" },
                                    { TCLAVE: "4", TDESCRI: "Rec. Parcial" },
                                    { TCLAVE: "5", TDESCRI: "Rec. Total" }
                    ];
                } else {
                    var data = [{ TCLAVE: "-1", TDESCRI: "[Todos]" },
                                { TCLAVE: "2", TDESCRI: "Aprobados" }
                    ];
                }

                $.each(data, function (i, v) {
                    //console.log(v);
                    Operacion.mask('ddlTIOC').append($('<option>', {
                        value: v.TCLAVE,
                        text: v.TDESCRI
                    }))
                });
            }
            var mi_combo1 = function (DATA) {
                var unico = $.unique(DATA);
                $.each(unico, function (i, v) {
                    Operacion.mask('ddlUSER').append($('<option>', {
                        value: v,
                        text: v
                    }));
                });
            }
            micontrol($('#hfusu').val());

            var dibujaTabla = function (NAME, ROW, ID, DATA, CSUM, CSS) {
                $("#MainContent_gvordencompra").tablesorter();
                var table = $('<table id=' + NAME + ' class=tablesorter cellspacing="0" cellpadding=3 rules=all style=background-color:White;border-color:#CCCCCC;border-width:1px;border-style:None;width:100%;border-collapse:collapse;></table>');
                var CAB = [], STY = [], STY1 = [], STY2 = [];
                var gridView = document.getElementById(NAME);
                var LEN = gridView.rows[0].cells.length;//CABECERA INICIAL 
                for (var z = 0; z < LEN; z++) {
                    var style1 = gridView.rows[0].cells[z].style.width;
                    var style2 = gridView.rows[0].cells[z].style.cssText;
                    var style3 = gridView.rows[0].cells[z].align;
                    cellPivot00 = gridView.rows[0].cells[z];
                    CAB[z] = cellPivot00.innerHTML;
                    STY[z] = style1;
                    STY1[z] = style2.replace(" ", "");
                    STY2[z] = style3;
                }
                $('#' + ID).empty();
                t_head = $('<thead></thead>');
                t_tr = $('<tr style=color:White;background-color:#006699;font-weight:bold;></tr>');
                for (var j = 0; j < CAB.length; j++) {
                    t_th = $('<th scope="col" style=font-size:8pt;text-align:left;width:' + STY[j] + '>' + CAB[j] + '</th>');
                    t_tr = t_tr.append(t_th);
                }
                t_head = t_head.append(t_tr);
                table = table.append(t_head);
                if (DATA != "") {
                    for (k = 0; k < ROW.length; k++) {
                        var a_table1 = ($('<tr style=color:#000066;></tr>'));
                        for (var j = 0; j < CAB.length; j++) {
                            var UL = STY1[j].replace(" ", "");
                            a_table1.append($('<td ' + (typeof DATA[ROW[k]][j] == "number" ? 'align=right' : "") + ' style=' + UL.replace(" ", "") + '>' + (typeof DATA[ROW[k]][j] == "number" ? Operacion.mi_formato(DATA[ROW[k]][j], 2) : DATA[ROW[k]][j].trim()) + '</td>'))
                            table = table.append(a_table1);
                        }
                    }
                } else {
                    for (k = 0; k < ROW.length; k++) {
                        var a_table1 = ($('<tr style=color:#000066;></tr>'));
                        for (var j = 0; j < CAB.length; j++) {
                            a_table1.append($('<td>&nbsp;</td>'));
                            table = table.append(a_table1);
                        }
                    }
                }
                $('#' + ID).append(table);
            }
            var dibujaTabla1 = function (NAME, ROW, ID, DATA, CSUM, CSS) {
                var table = $('<table id=' + NAME + ' class=tablesorter cellspacing="0" cellpadding=3 rules=all style=background-color:White;border-color:#CCCCCC;border-width:1px;border-style:None;width:100%;border-collapse:collapse;></table>');
                var CAB = [], STY = [], STY1 = [], STY2 = [];
                var gridView = document.getElementById(NAME);
                var LEN = gridView.rows[0].cells.length;//CABECERA INICIAL 
                for (var z = 0; z < LEN; z++) {
                    var style1 = gridView.rows[0].cells[z].style.width;
                    var style2 = gridView.rows[0].cells[z].style.cssText;
                    var style3 = gridView.rows[0].cells[z].align;
                    cellPivot00 = gridView.rows[0].cells[z];
                    CAB[z] = cellPivot00.innerHTML;
                    STY[z] = style1;
                    STY1[z] = style2.replace(" ", "");
                    STY2[z] = style3;
                }
                $('#' + ID).empty();
                t_head = $('<thead></thead>');
                t_tr = $('<tr style=color:White;background-color:#006699;font-weight:bold;></tr>');
                for (var j = 0; j < CAB.length; j++) {
                    t_th = $('<th scope="col" style=font-size:8pt;text-align:left;width:' + STY[j] + '>' + CAB[j] + '</th>');
                    t_tr = t_tr.append(t_th);
                }
                t_head = t_head.append(t_tr);
                table = table.append(t_head);
                if (DATA != "") {
                    var sum = 0;
                    for (k = 0; k < ROW.length; k++) {
                        var a_table1 = ($('<tr style=color:#000066;></tr>'));
                        for (var j = 0; j < CAB.length; j++) {
                            if (typeof DATA[ROW[k]][j] == "number") { sum = sum + DATA[ROW[k]][j]; } else { }
                            var UL = STY1[j].replace(" ", "");
                            a_table1.append($('<td ' + (typeof DATA[ROW[k]][j] == "number" ? 'style=text-align:right' : 'style=text-align:left') + '>' + (typeof DATA[ROW[k]][j] == "number" ? Operacion.mi_formato(DATA[ROW[k]][j], 2) : DATA[ROW[k]][j].trim()) + '</td>'))
                            table = table.append(a_table1);
                        }
                        //if ((k+1) == (ROW) && 
                        /*if(CSUM == true) {
                            a_table1.append($('<td ' + (typeof DATA[ROW[k]][j] == "number" ? 'align=right' : "") + ' style=' + UL.replace(" ", "") + '>' + (typeof DATA[ROW[k]][j] == "number" ? Operacion.mi_formato(sum, 2) : "") + '</td>'))
                            table = table.append(a_table1);
                        }*/
                    }
                    var a_ultimo = ($('<tr style=color:#000066;></tr>'))
                        .append($('<td></td>'))
                        .append($('<td></td>'))
                        .append($('<td style=text-align:right>Total:</td>'))
                        .append($('<td style=text-align:right>' + Operacion.mi_formato(sum, 2) + '</td>'))
                    table = table.append(a_ultimo);
                } else {
                    for (k = 0; k < ROW.length; k++) {
                        var a_table1 = ($('<tr style=color:#000066;></tr>'));
                        for (var j = 0; j < CAB.length; j++) {
                            a_table1.append($('<td>&nbsp;</td>'));
                            table = table.append(a_table1);
                        }
                    }
                }
                $('#' + ID).append(table);
            }
            //CUENTA X FECHA X USUARIO PROVISIONES
            var mi_resumen = function (fecha1, fecha2) {
                var DATA = {
                    CP_CSITUAC: "C",
                    CP_CVANEXO: "P",
                    //CP_CTIPDOC: "FT",
                    CP_CSUBDIA: "1",
                    CP_DFECCRE: fecha1,
                    CP_DFECMOD: fecha2
                };
                var result = Operacion.oAjax("ListadoCDOC.aspx/mi_resumen", DATA, "DATA");
                //console.log(result);
                var LEN1 = result.d.length;
                var ROWS = [], MI_DETALLE = [];
                try {
                    if (typeof result == 'object') {
                        for (var z = 0; z < LEN1; z++) {
                            ROWS.push(z);
                            MI_DETALLE[z] = [result.d[z].CP_CUSER, result.d[z].CP_CAREA, result.d[z].CP_CSUBDIA, result.d[z].CP_NIMP2MN];
                        }
                        dibujaTabla1("<%=gvRESUMEN.ClientID %>", ROWS, "mi_tabla1", MI_DETALLE, true, "");
                    } else {
                        alert('No existen registros');
                    }
                } catch (ex) {
                    alert(ex.message);
                }
            }
            //GRILLA PARA CONTABILIZAR
            var generaNGrilla = function () {
                var F1 = Operacion.mask('txtOCF1').val();
                var F2 = Operacion.mask('txtOCF2').val();
                var arraySinDuplicados = [];
                var M_USER = [];
                var DATA = {};
                DATA.CP_CVANEXO = "P";
                DATA.CP_CSITUAC = "C";//REGISTRADA:R
                //DATA.CP_CTIPDOC = "";//SI ENVIO NULO TODOS LOS DOCUMENTOS
                //DATA.CP_CAREA = "";
                DATA.CP_CSUBDIA = "";//"11";
                DATA.CP_CTDOCRE = "";//CP_CTDOCRE OC
                DATA.CP_CCENCOR = "";// (txtCCID.Text == "" ? "" : txtCCID.Text);//CONGELADO
                DATA.CP_DFECDOC = moment(F1, 'DD/MM/YYYY');
                DATA.CP_DFECUBI = moment(F2, 'DD/MM/YYYY');

                $.ajax({
                    type: "POST",
                    url: "ListadoCDOC.aspx/contabilizados",
                    data: '{DATA:' + JSON.stringify(DATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        var M_DATA = [];
                        var M_DATA_D = [];
                        $.each(data.d, function (i, v) {
                            M_DATA.push(i);
                            M_DATA_D[i] = [v['CP_CTDOCRE'], v['CP_CNDOCRE'], v['CP_CCODIGO'],
                                           v['NOMTIT'], v['CP_CTIPDOC'], v['CP_CNUMDOC'], v['CP_CCODMON'], v['IMPORTE'],
                                           v['CP_DFECCRE1'].trim(), v['CP_CCENCOR'], v['NOMARE'],
                                           v['CP_CUSER'], v['CP_CSITUAC'], ""];
                            M_USER[i] = v['CP_CUSER'];
                        });//O:v['CP_DFDOCRE'].trim()
                        //console.log(M_DATA_D);
                        dibujaTabla("<%=gvDOC.ClientID %>", M_DATA, "migrilla", M_DATA_D, "", "");

                        $.each(M_USER, function (i, el) {
                            if ($.inArray(el, arraySinDuplicados) === -1) arraySinDuplicados.push(el);
                        });
                        mi_combo1(arraySinDuplicados.sort());
                    },
                    error: function (response) {
                        alert('El proceso no se pudo completar:GNG');
                        console.table(response);
                    }
                });
            }
            var muestra_banco = function (RUC) {
                var DATA = {
                    AC_CVANEXO: "P",
                    AC_CCODIGO: RUC
                };
                var result = Operacion.oAjax("ListadoCDOC.aspx/obtiene_bc", DATA, "DATA");
                var LEN1 = result.d.length;
                var ROWS = [], MI_DETALLE = [];
                try {
                    if (typeof result == 'object') {
                        for (var z = 0; z < LEN1; z++) {
                            var banco1x= "MN:"+result.d[z].AC_CCTAMNT+"\nUS:"+result.d[z].AC_CCTAUST;
                            var banco2x = "MN:" + result.d[z].AC_CCTAMN7 + "\nUS:" + result.d[z].AC_CCTAUS7;
                            var banco3x = "MN:" + result.d[z].AC_CCTAMNK + "\nUS:" + result.d[z].AC_CCTAUSK;
                            //MI_DETALLE[z] = [result.d[z].CP_CUSER, result.d[z].CP_CAREA, result.d[z].CP_CSUBDIA, result.d[z].CP_NIMP2MN];
                        }
                    } else {
                        alert('No existen registros');
                    }
                } catch (ex) {
                    alert(ex.message);
                }
                return { banco1x, banco2x, banco3x }
            }

            $("#MainContent_txtprove").autocomplete(
            {
                source: function (request, response) {
                    $.ajax({
                        url: "OCemision.aspx/GetProveedores",
                        data: "{ 'productos': '" + request.term + "' }",
                        dataType: "json",
                        type: "POST",
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
                    $('#MainContent_txtidpro').val(str);


                }
            });

            $("#MainContent_txtsolicitante").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "ListadoCDOC.aspx/GETVARIOS",
                        data: "{ 'CLAVE': '" + request.term + "' ,  'INDICADOR': '12' }",
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
                    $('#MainContent_txtcodsol').val(str);


                }, change: function (event, ui) {
                    if (ui.item == null) {
                        alert("no ha seleccionado solicitante");
                        Operacion.mask("txtsolicitante").focus();
                        Operacion.mask("txtsolicitante").val("");
                        Operacion.mask("txtcodsol").val("");
                    }
                }
            });

            $(".btbuscar").click(function () {
                filtarocomprapopup();
            });

            $(".btimag").click(function (e) {
                window.open('data:application/vnd.ms-excel,' + encodeURIComponent($('#expo').html()));
                e.preventDefault();
            });

            $(".btedita").click(function () {
                var trp = $(this).parent().parent();
                idnumoc = $("td:eq(0)", trp).html();
                variableServidor = idnumoc;
                window.location.assign("\ListadoCDOC.aspx?" + variableServidor);

            });

            $(".btapro").click(function () {
                micontrol($('#hfusu').val());
                var codord = $("td:eq(0)", trp).html();
                var validanum = Validaaprobxusuario(codord).rtdatoa;

                var AAPRO = [], AAPRO1 = [];
                AAPRO = [$('#hfusu').val(), $('#hfusu').val(), $('#hfusu').val()];
                AAPRO1 = [$("#MainContent_txtusu1").val(), $("#MainContent_txtusu2").val(), $("#MainContent_txtusu3").val()];


                if ($('#MainContent_lblacceso').val() != "0") {

                    if ($("#MainContent_txtestadooc").val() != "1" && $("#MainContent_txtestadooc").val() != "2") {
                        alert("La orden de Compra No se Puede Aprobar, Se Encuentra en Estado: " + $("#MainContent_txtestadooc").val());
                    } else {
                        if ($("#MainContent_txtestadooc").val() == "1") {
                            if (AAPRO1[0].trim() == "" && BANDERA[0] == "X") {
                                aprobaroc($("#MainContent_txtnumoc").val(), "1", AAPRO[0].trim(), AAPRO1[1].trim(), AAPRO1[2].trim(), "N");
                                Insertadetalleprodusua(codord);//HISTORIAL
                                $("#dvdetalle").dialog('close');
                            } else if (AAPRO1[1].trim() == "" && BANDERA[1] == "X") {
                                aprobaroc($("#MainContent_txtnumoc").val(), "1", AAPRO1[0].trim(), AAPRO[1].trim(), AAPRO1[2].trim(), "N");
                                Insertadetalleprodusua(codord);//HISTORIAL
                                $("#dvdetalle").dialog('close');
                            } else if (AAPRO1[2].trim() == "" && BANDERA[2] == "X") {
                                aprobaroc($("#MainContent_txtnumoc").val(), "2", AAPRO1[0].trim(), AAPRO1[1].trim(), AAPRO[2].trim(), "S");
                                Insertadetalleprodusua(codord);//HISTORIAL
                                $("#dvdetalle").dialog('close');
                            } else {
                                alert("No tiene acceso a firmar");
                            }
                        } else {
                            alert("La orden de compra ya fue aprobada");
                        }

                    }
                }
                else {
                    alert("Ud. no tiene permisos para realizar esta operacion");
                }

            });

            $(".btdesapro").click(function () {
                micontrol($("#hfusu").val());

                if ($('#MainContent_lblacceso').val() != "0") {
                    if ($("#MainContent_txtestadooc").val() == "2") {
                        if (BANDERA[2] == "X") {
                            if (confirm("Desea Desaprobar la Orden de Compra: " + $("#MainContent_txtnumoc").val())) {
                                aprobaroc($("#MainContent_txtnumoc").val(), "1", $("#MainContent_txtusu1").val(), $("#MainContent_txtusu2").val(), $("#MainContent_txtusu3").val());
                                $("td:eq(8)", trp).html("");
                                $("td:eq(9)", trp).html("");
                                $("td:eq(10)", trp).html("");
                                $("td:eq(10)", trp).val("1");
                                $("td:eq(5)", trp).html("EMITIDA");
                                //$("#MainContent_txtnumoc").val(idnumoc);
                                $("#dvdetalle").dialog('close')
                            }
                        } else {
                            alert("Usted no tiene Acceso a Desaprobar");
                        }
                    }

                    else {
                        if ($("#MainContent_txtestadooc").val() == "1") {
                            alert("La orden de Compra aun está sin aprobar");
                        }
                        else {
                            alert("La orden de Compra No se Puede Desaprobar, Se Encuentra en Estado: " + $("#MainContent_txtestadooc").val());
                        }


                    }
                }
                else {
                    alert("Ud. no tiene permisos para realizar esta operacion");
                }
            });
            //MUESTRA DETALLE
            $(".btadd").click(function () { //  se debe colocar dentrp de una funcion 
                $("#dvdetalle").dialog('open');
                //extraer el numero orden
                trp = $(this).parent().parent();
                idnumoc = $("td:eq(0)", trp).html();
                $("#MainContent_txtnumoc").val(idnumoc);

                // extraer datos proveedor
                trp1 = $(this).parent().parent();
                ruc = $("td:eq(0)", trp1).val();
                $("#MainContent_txtruc").val(ruc)

                trp3 = $(this).parent().parent();
                razon = $("td:eq(2)", trp3).html();
                $("#MainContent_txtproveedor").val(razon)

                // extraer fecha
                trp4 = $(this).parent().parent();
                fecha = $("td:eq(1)", trp4).html();
                $("#MainContent_txtfecha").val(fecha);

                //BAHIA-MOSTRAR
                bahia = $("td:eq(11)", trp1).val();
                if (bahia.trim() != "") {
                    Operacion.inputVisible('lblBAH', 0);
                    Operacion.inputVisible('txtBAH', 0);
                    Operacion.mask('txtBAH').val(bahia);
                } else {
                    Operacion.inputVisible('lblBAH', 1);
                    Operacion.inputVisible('txtBAH', 1);
                }


                // extraer pais
                trp5 = $(this).parent().parent();
                pais = $("td:eq(8)", trp5).html();
                $("#MainContent_lblpais").val(pais);
                //EXTRAER FPAGO
                trp6 = $(this).parent().parent();
                fpago = $("td:eq(7)", trp6).html();
                $("#MainContent_ddlfpago").val(fpago);

                trp11 = $(this).parent().parent();
                provincia = $("td:eq(5)", trp11).val();
                $("#MainContent_txtprov").val(provincia);

                trp12 = $(this).parent().parent();
                cambio = $("td:eq(6)", trp12).val();
                $("#MainContent_txttcambio").val(cambio);

                trp16 = $(this).parent().parent();
                persona = $("td:eq(10)", trp16).val();
                $("#MainContent_txtaten").val(persona);


                trp17 = $(this).parent().parent();
                req = $("td:eq(7)", trp17).html();
                $("#MainContent_txtnumref").val(req);

                trp19 = $(this).parent().parent();
                moneda = $("td:eq(9)", trp19).val();
                $("#MainContent_txtmoneda").val(moneda);

                //codigo para aprobar
                trp18 = $(this).parent().parent();
                usu1 = $("td:eq(8)", trp18).html();
                $("#MainContent_txtusu1").val(usu1);

                trp19 = $(this).parent().parent();
                usu2 = $("td:eq(9)", trp19).html();
                $("#MainContent_txtusu2").val(usu2);

                trp20 = $(this).parent().parent();
                usu3 = $("td:eq(10)", trp20).html();
                $("#MainContent_txtusu3").val(usu3);

                trp25 = $(this).parent().parent();
                estadooc = $("td:eq(10)", trp25).val();
                $("#MainContent_txtestadooc").val(estadooc);

                var acceso = $('#MainContent_lblacceso').html();


                filtarListocompra(idnumoc);
            });

            $(".btaddgrilladetalle").click(function () { //  se debe colocar dentrp de una funcion 
                $("#dvdetalle").dialog('open');
                filtarListocompra()
            });

            $(".bthistorial").click(function () { //  se debe colocar dentrp de una funcion 
                $("#EstadoPedido").dialog('open');
                trp = $(this).parent().parent();
                articulo = $("td:eq(1)", trp).val();
                descripcion = $("td:eq(1)", trp).html();
                $('#MainContent_lblnumero').html(descripcion);
                filtarcantidademb(articulo);
            });
            /// para mostrar div
            $('#dvdetalle').dialog({
                autoOpen: false,
                modal: true,
                resizable: true,
                width: 1260,
                heigth: 300,
                title: 'Detalle Orden',
                close: function (event, ui) {
                },
            });

            $('#EstadoPedido').dialog({
                autoOpen: false,
                modal: true,
                resizable: true,
                width: 600,
                heigth: 300,
                title: 'Historial de Precios',
                close: function (event, ui) {
                },
            });

            /*NO USAR*/
            function aprobaroc(idnumoc, indice, usu1, usu2, usu3, ultimaf) {
                var idnumd = idnumoc;
                var COAPRUEBA = {};
                COAPRUEBA.OC_CNUMORD = idnumd;
                COAPRUEBA.OC_CSITORD = indice;
                var user = {};
                user = $("#MainContent_lblusuario").html();
                COAPRUEBA.OC_CUSEA01 = (usu1);
                COAPRUEBA.OC_CUSEA02 = (usu2);
                COAPRUEBA.OC_CUSEA03 = (usu3);
                COAPRUEBA.OC_CSITORD = indice;
                COAPRUEBA.OC_DFECR01 = ($("#MainContent_txtfec1").val() != "" ? moment($("#MainContent_txtfec1").val(), "DD/MM/YYYY") : "01/01/2000");
                COAPRUEBA.OC_DFECR02 = ($("#MainContent_txtfec2").val() != "" ? moment($("#MainContent_txtfec2").val(), "DD/MM/YYYY") : "01/01/2000");
                COAPRUEBA.OC_DFECR03 = ($("#MainContent_txtfec3").val() != "" ? moment($("#MainContent_txtfec3").val(), "DD/MM/YYYY") : "01/01/2000");

                $.ajax({
                    type: "POST",
                    url: "OCemision.aspx/aprobaroc",
                    data: '{COAPRUEBA: ' + JSON.stringify(COAPRUEBA) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        alert("Se Aprobo Correctamente");
                    },
                    error: function (response) {
                        console.log(response);
                    }
                });

                if (ultimaf == "S") {
                    //    if (COAPRUEBA.OC_CUSEA01.trim() != "" && COAPRUEBA.OC_CUSEA02.trim() != "" && COAPRUEBA.OC_CUSEA03.trim() != "") {
                    DETALLE(idnumd, "2");
                    //        $("td:eq(10)", trp).html(COAPRUEBA.OC_CUSEA03);
                    //        $("td:eq(10)", trp).val("2");
                    //        $("td:eq(5)", trp).html("APROBADA");
                    //    }
                    $("td", trp).remove();
                } else {
                    $("td:eq(8)", trp).html(usu1);
                    $("td:eq(9)", trp).html(usu2);
                    $("td:eq(10)", trp).html(usu3);
                }

            }

            /*NO USAR*/
            function aprobardet(numeroorden, indiceap, citem) {
                var idnumd = numeroorden;

                var DETAPRUEBA = {};
                DETAPRUEBA.OC_CNUMORD = numeroorden.trim();
                DETAPRUEBA.OC_CESTADO = indiceap.trim();
                DETAPRUEBA.OC_CITEM = citem.trim();
                // alert(numeroorden, indiceap, item);


                $.ajax({

                    type: "POST",
                    url: "OCemision.aspx/aprobardet",
                    data: '{DETAPRUEBA: ' + JSON.stringify(DETAPRUEBA) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {

                    },
                    error: function (response) {
                    }
                });

                //}
                // filtarocomprapopup()
            }

            /*NO USAR*/
            function Validaaprobxusuario(codigoprod) {
                rtdatoa = "";
                var parm = {};
                parm.DA_IDUSUA = $("#hfusu").val();
                parm.DA_CODIGO = codigoprod;
                parm.DA_TIPOCODIGO = 2;//ORDENES
                $.ajax({
                    type: "POST",
                    url: "OCemision.aspx/Extraenaprob",
                    data: '{parm: ' + JSON.stringify(parm) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        //console.log(data);
                        rtdatoa = data.d;
                    },
                    error: function (data) {
                        if (data.length != 0)
                            alert(data);
                    }
                });
                return { rtdatoa };
            }

            /*NO USAR*/
            function Insertadetalleprodusua(codigoprod) {

                var horao = Operacion.hora();
                var fecactual = moment($("#MainContent_hfactual").val(), "DD/MM/YYYY");
                fecactual = fecactual == null ? null : new Date(fecactual);

                var INF = {};
                INF.DA_CODIGO = codigoprod;
                INF.DA_IDUSUA = $("#hfusu").val();
                INF.DA_FECHA = fecactual;
                INF.DA_HORA = horao;
                INF.DA_TIPOCODIGO = 2;
                $.ajax({

                    type: "POST",
                    url: "OCemision.aspx/Insertadetallprodusua",
                    data: '{INF: ' + JSON.stringify(INF) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        // alert("Se Actualizo la Informacion");
                    },
                    error: function (response) {
                        if (response.length != 0)
                            console.table(response);
                    }
                });
            }

            //DETALLE
            function filtarListocompra(numorden) {
                var LDE = {};
                LDE.OC_CNUMORD = numorden;
                sumasub = 0; sumadesc = 0; sumaigvv = 0; sumatotall = 0;
                $.ajax({
                    type: "POST",
                    url: "../../ANTICIPO/OCemision.aspx/GetListaDetalle",
                    data: '{LDE: ' + JSON.stringify(LDE) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        if (data.d.length > 0) {
                            var row = $("[id*=GridView1] tr:last-child").clone(true);
                            $("[id*=GridView1] tr").not($("[id*=GridView1] tr:first-child")).remove();

                            for (var i = 0; i < data.d.length; i++) {

                                $("td", row).eq(0).html(data.d[i].OC_CITEM);
                                $("td", row).eq(1).html(data.d[i].OC_CDESREF);
                                $("td", row).eq(1).val(data.d[i].OC_CCODIGO);

                                $("td", row).eq(2).html(data.d[i].OC_CUNIDAD);
                                $("td", row).eq(2).val(data.d[i].OC_NDSCPFI);
                                $("td", row).eq(3).html(formato_numero(data.d[i].OC_NCANORD, 2, ".", ","));
                                $("td", row).eq(4).html(formato_numero(data.d[i].OC_NPREUN2, 2, ".", ","));
                                $("td", row).eq(5).html(formato_numero(data.d[i].OC_NDSCPAD, 2, ".", ","));
                                $("td", row).eq(5).val(data.d[i].OC_NDESCAD);
                                $("td", row).eq(6).html(formato_numero(data.d[i].OC_NDSCPIT, 2, ".", ","));
                                $("td", row).eq(6).val(data.d[i].OC_NDESCIT);
                                $("td", row).eq(7).html(formato_numero(data.d[i].OC_NIGVPOR, 2, ".", ","));
                                var checkigv = data.d[i].OC_CIGVPOR == "S" ? "1" : "0";
                                $("td", row).eq(7).val(checkigv);
                                //  $("td", row).eq(8).html(data.d[i].OC_NISCPOR.toFixed(2));
                                $("td", row).eq(8).html(formato_numero(data.d[i].OC_NPREUNI, 2, ".", ","));
                                $("td", row).eq(9).html(formato_numero(data.d[i].OC_NDESCTO, 2, ".", ","));
                                sumadesc = sumadesc + data.d[i].OC_NDESCTO;
                                $("td", row).eq(9).val(formato_numero(data.d[i].OC_NDSCPOR, 2, ".", ","));
                                $("td", row).eq(10).html(formato_numero(data.d[i].OC_NIGV, 2, ".", ","));//total igv
                                sumaigvv = sumaigvv + data.d[i].OC_NIGV;
                                $("td", row).eq(10).val(formato_numero(data.d[i].OC_NIGV, 2, ".", ","));//total igv
                                var subt = data.d[i].OC_NPREUN2 * data.d[i].OC_NCANORD;
                                $("td", row).eq(11).html(formato_numero(subt, 2, ".", ","));
                                $("td", row).eq(11).val(subt);//subtotal
                                sumasub = sumasub + subt;
                                $("td", row).eq(12).html(data.d[i].OC_COMENTA);
                                $("td", row).eq(12).val("B");
                                contaditem = Number(data.d[i].OC_CITEM);
                                contarndw = contarndw + 1;
                                cc = 2;
                                $("[id*=GridView1]").append(row);
                                row = $("[id*=GridView1] tr:last-child").clone(true);

                            }
                            $("#MainContent_txttbrutof").val(formato_numero(sumasub, 2, ".", ","));
                            $("#MainContent_txtdescf").val(formato_numero(sumadesc, 2, ".", ","));
                            $("#MainContent_txtigvf").val(formato_numero(sumaigvv, 2, ".", ","));
                            $("#MainContent_txtnetof").val(formato_numero(((sumasub - sumadesc) + sumaigvv), 2, ".", ","));
                        } else {
                            var row = $("[id*=GridView1] tr:last-child").clone(true);
                            $("[id*=GridView1] tr").not($("[id*=GridView1] tr:first-child")).remove();

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
                            $("td", row).eq(14).html("");
                            $("td", row).eq(15).html("");

                            $("[id*=GridView1]").append(row);
                            //alert("No se encontro registro");
                        }


                    },
                    error: function (response) {
                        if (response.length != 0)
                            alert(response);
                    }
                });

            }

            //BOTON BUSCAR
            function filtarocomprapopup() {
                var sumasol = 0; var sumadol = 0;
                var CB_OC = Operacion.mask('cbSOC').is(':checked');
                var VC = {};
                if (!CB_OC) {
                    var fec1 = moment($("#MainContent_txtfecha1").val(), "DD/MM/YYYY");
                    fec1 = new Date(fec1);
                    var fec2 = moment($("#MainContent_txtfecha2").val(), "DD/MM/YYYY");
                    fec2 = new Date(fec2);
                    VC.OC_CSITORD = Operacion.mask('ddlTIOC').val();
                    VC.OC_CTIPORD = Operacion.mask('ddlTIPOC').val();
                    VC.OC_DFECDOC = fec1;
                    VC.OC_DFECENT = fec2;
                    VC.OC_CCODPRO = $("#MainContent_txtidpro").val();
                    VC.OC_CCODSOL = $("#MainContent_txtcodsol").val();
                    VC.OC_CREMITE = $("#hfusu").val();
                } else {
                    //VC.OC_CSITORD = "-1";
                    //VC.OC_CTIPORD = "-1";
                    VC.OC_CNUMORD = Operacion.mask('txtOC').val();
                    VC.OC_CREMITE = $("#hfusu").val();
                }
                //console.log(VC);
                $.ajax({
                    type: "POST",
                    url: "../../ANTICIPO/OCemision.aspx/ListarCabOCpopup",
                    data: '{VC: ' + JSON.stringify(VC) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        if (data.d.length > 0) {
                            var row = $("[id*=gvordencompra] tr:last-child").clone(true);
                            $("[id*=gvordencompra] tr").not($("[id*=gvordencompra] tr:first-child")).remove();

                            for (var i = 0; i < data.d.length; i++) {
                                $("td", row).eq(0).html(data.d[i].OC_CNUMORD);
                                $("td", row).eq(0).val(data.d[i].OC_CODPRO);
                                $("td", row).eq(1).html(data.d[i].OC_DFECDOC);
                                $("td", row).eq(1).val(data.d[i].OC_CDIRPRO);
                                $("td", row).eq(2).html(data.d[i].OC_CRAZSOC);
                                $("td", row).eq(3).html(data.d[i].OC_CCODMON);
                                $("td", row).eq(3).val(data.d[i].OC_CLUGFAC);

                                if (data.d[i].OC_CCODMON.trim() == "MN") {
                                    $("td", row).eq(4).html(formato_numero(data.d[i].OC_NIMPMN, 2, ".", ","));
                                }
                                if (data.d[i].OC_CCODMON.trim() != "MN") {
                                    $("td", row).eq(4).html(formato_numero(data.d[i].OC_NIMPUS, 2, ".", ","));
                                }
                                (data.d[i].OC_DSITORD == "1" ? $('#btnimprimir0').attr('disabled', true) : $('#btnimprimir0').removeAttr('disabled'));//01.08.16
                                sumasol = Number(sumasol) + Number(data.d[i].OC_NIMPMN);
                                sumadol = Number(sumadol) + Number(data.d[i].OC_NIMPUS);

                                $("td", row).eq(4).val(data.d[i].OC_CDISTOC)
                                $("td", row).eq(5).html(data.d[i].OC_CTIPORD);
                                $("td", row).eq(5).val(data.d[i].OC_CPROVOC);
                                $("td", row).eq(6).html(data.d[i].OC_CSITORD);
                                $("td", row).eq(6).val(data.d[i].OC_NTIPCAM);
                                $("td", row).eq(7).html(data.d[i].OC_CFORPA1);
                                $("td", row).eq(7).val(data.d[i].OC_CREMITE);
                                $("td", row).eq(8).html(data.d[i].OC_CUSEA01.toUpperCase());
                                $("td", row).eq(8).val(data.d[i].OC_CDETENT);
                                $("td", row).eq(9).html(data.d[i].OC_CUSEA02.toUpperCase());
                                $("td", row).eq(9).val(data.d[i].MONEDA);
                                $("td", row).eq(10).html(data.d[i].OC_CUSEA03.toUpperCase());
                                $("td", row).eq(10).val(data.d[i].situanum);
                                $("td", row).eq(2).val(data.d[i].ALMACEN);
                                $("td", row).eq(11).html(data.d[i].OC_CSOLICIT);
                                $("td", row).eq(11).val(data.d[i].OC_CRESPER2);//BAHIA
                                //NUEVO 06.08.16
                                //console.log(data.d[i].OC_CODPRO);
                                var banco1 = muestra_banco(data.d[i].OC_CODPRO).banco1x;
                                var banco2 = muestra_banco(data.d[i].OC_CODPRO).banco2x;
                                var banco3 = muestra_banco(data.d[i].OC_CODPRO).banco3x;
                                $("td", row).eq(12).html(banco1);
                                //(data.d[i].OC_CUENTAB2!=''?$("td", row).eq(13).html(data.d[i].OC_CUENTAB2):"");
                                $("td", row).eq(13).html(banco2);
                                //(data.d[i].OC_CUENTAB4!=''?$("td", row).eq(15).html(data.d[i].OC_CUENTAB4):"");
                                $("td", row).eq(14).html(banco3);
                                //(data.d[i].OC_CUENTAB6!=''?$("td", row).eq(17).html(data.d[i].OC_CUENTAB6):"");
                                //$("td", row).eq(15).html(data.d[i].OC_CUENTAB7);
                                //console.log(data.d[i].OC_DTIPORD);
                                Operacion.mask('ddlTIPOC').val(data.d[i].OC_DTIPORD);
                                //mi_combo(0);01.08.16
                                Operacion.mask('ddlTIOC').val(data.d[i].OC_DSITORD);
                                //console.log(data.d);
                                $("[id*=gvordencompra]").append(row);
                                row = $("[id*=gvordencompra] tr:last-child").clone(true);
                            }
                            //copiaaa

                            var row = $("[id*=gvcopia] tr:last-child").clone(true);
                            $("[id*=gvcopia] tr").not($("[id*=gvcopia] tr:first-child")).remove();

                            for (var i = 0; i < data.d.length; i++) {
                                $("td", row).eq(0).html(data.d[i].OC_CNUMORD);
                                $("td", row).eq(0).val(data.d[i].OC_CODPRO);
                                $("td", row).eq(1).html(data.d[i].OC_DFECDOC);
                                $("td", row).eq(1).val(data.d[i].OC_CDIRPRO);
                                $("td", row).eq(2).html(data.d[i].OC_CRAZSOC);
                                $("td", row).eq(3).html(data.d[i].OC_CCODMON);
                                $("td", row).eq(3).val(data.d[i].OC_CLUGFAC);

                                if (data.d[i].OC_CCODMON.trim() == "MN") {
                                    $("td", row).eq(4).html(formato_numero(data.d[i].OC_NIMPMN, 2, ".", ","));
                                }
                                if (data.d[i].OC_CCODMON.trim() != "MN") {
                                    $("td", row).eq(4).html(formato_numero(data.d[i].OC_NIMPUS, 2, ".", ","));
                                }
                                (data.d[i].OC_DSITORD == "1" ? $('#btnimprimir0').attr('disabled', true) : $('#btnimprimir0').removeAttr('disabled'));//01.08.16
                                //sumasol = Number(sumasol) + Number(data.d[i].OC_NIMPMN);
                                //sumadol = Number(sumadol) + Number(data.d[i].OC_NIMPUS);

                                $("td", row).eq(4).val(data.d[i].OC_CDISTOC)
                                $("td", row).eq(5).html(data.d[i].OC_CTIPORD);
                                $("td", row).eq(5).val(data.d[i].OC_CPROVOC);
                                $("td", row).eq(6).html(data.d[i].OC_CSITORD);
                                $("td", row).eq(6).val(data.d[i].OC_NTIPCAM);
                                $("td", row).eq(7).html(data.d[i].OC_CFORPA1);
                                $("td", row).eq(7).val(data.d[i].OC_CREMITE);
                                $("td", row).eq(8).html(data.d[i].OC_CUSEA01.toUpperCase());
                                $("td", row).eq(8).val(data.d[i].OC_CDETENT);
                                $("td", row).eq(9).html(data.d[i].OC_CUSEA02.toUpperCase());
                                $("td", row).eq(9).val(data.d[i].MONEDA);
                                $("td", row).eq(10).html(data.d[i].OC_CUSEA03.toUpperCase());
                                $("td", row).eq(10).val(data.d[i].situanum);
                                $("td", row).eq(2).val(data.d[i].ALMACEN);
                                $("td", row).eq(11).html(data.d[i].OC_CSOLICIT);
                                $("td", row).eq(11).val(data.d[i].OC_CRESPER2);//BAHIA

                                //console.log(data.d[i].OC_DTIPORD);
                                //Operacion.mask('ddlTIPOC').val(data.d[i].OC_DTIPORD);
                                ////mi_combo(0);01.08.16
                                //Operacion.mask('ddlTIOC').val(data.d[i].OC_DSITORD);
                                //console.log(data.d);
                                $("[id*=gvcopia]").append(row);
                                row = $("[id*=gvcopia] tr:last-child").clone(true);
                            }






                            Operacion.mask("txtsumamn").val(formato_numero(sumasol, 2, ".", ","));
                            Operacion.mask("txtsumaus").val(formato_numero(sumadol, 2, ".", ","));
                            Operacion.mask("txtreg").val(data.d.length);
                        } else {
                            var row = $("[id*=gvordencompra] tr:last-child").clone(true);
                            $("[id*=gvordencompra] tr").not($("[id*=gvordencompra] tr:first-child")).remove();

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
                            $("td", row).eq(0).val("");
                            $("td", row).eq(1).val("");
                            $("td", row).eq(2).val("");
                            $("td", row).eq(3).val("");
                            $("td", row).eq(4).val("");
                            $("td", row).eq(5).val("");
                            $("td", row).eq(6).val("");
                            $("td", row).eq(7).val("");
                            $("td", row).eq(8).val("");
                            $("td", row).eq(9).val("");
                            $("td", row).eq(10).val("");
                            $("td", row).eq(11).html("");
                            Operacion.mask("txtsumamn").val("");
                            Operacion.mask("txtsumaus").val("");
                            Operacion.mask("txtreg").val("");
                            $("[id*=gvordencompra]").append(row);
                            //alert("no se encontro registro");
                        }






                    },
                    error: function (response) {
                        if (response.length != 0)
                            alert(response);
                    }
                });

            }

            function filtarocomprainicio() {
                var sumasol = 0; var sumadol = 0;
                //var date = new Date()
                //var primerDia = new Date(date.getFullYear(), date.getMonth(), 1);
                //console.log(primerDia);
                var fec1 = moment(Operacion.mask('txtfecha1').val(), "DD/MM/YYYY");
                //fec1 = new Date(fec1);
                //console.log(fec1);
                var fec2 = moment(Operacion.mask('txtfecha2').val(), "DD/MM/YYYY");
                //fec2 = new Date(fec2);
                //console.log(fec2);
                var VC = {};
                VC.OC_CSITORD = Operacion.mask('ddlTIOC').val();//VARIA
                VC.OC_CTIPORD = Operacion.mask('ddlTIPOC').val();//$("#MainContent_ddltipo option:selected").val();
                VC.OC_DFECDOC = fec1;
                VC.OC_DFECENT = fec2;
                VC.OC_CCODPRO = $("#MainContent_txtidpro").val();
                VC.OC_CCODSOL = $("#MainContent_txtcodsol").val();
                VC.OC_CREMITE = $("#hfusu").val();
                //console.log(VC);
                var urld = "";
                if ($("#MainContent_lblpermiso").html() == "F ") {
                    urld = "../../ANTICIPO/OCemision.aspx/ListarcabeceraocpopupCondosusuarios";
                }
                else {
                    urld = "../../ANTICIPO/OCemision.aspx/ListarCabOCpopup";

                }

                $.ajax({

                    type: "POST",
                    url: urld,
                    data: '{VC: ' + JSON.stringify(VC) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {

                        if (data.d.length > 0) {
                            var row = $("[id*=gvordencompra] tr:last-child").clone(true);
                            $("[id*=gvordencompra] tr").not($("[id*=gvordencompra] tr:first-child")).remove();

                            for (var i = 0; i < data.d.length; i++) {
                                $("td", row).eq(0).html(data.d[i].OC_CNUMORD);
                                $("td", row).eq(0).val(data.d[i].OC_CCODPRO);
                                $("td", row).eq(1).html(data.d[i].OC_DFECDOC);
                                $("td", row).eq(1).val(data.d[i].OC_CDIRPRO);
                                $("td", row).eq(2).html(data.d[i].OC_CRAZSOC);
                                $("td", row).eq(3).html(data.d[i].OC_CCODMON);
                                $("td", row).eq(3).val(data.d[i].OC_CLUGFAC);

                                if (data.d[i].OC_CCODMON.trim() == "MN") {
                                    $("td", row).eq(4).html(formato_numero(data.d[i].OC_NIMPMN, 2, ".", ","));
                                }
                                if (data.d[i].OC_CCODMON.trim() != "MN") {
                                    $("td", row).eq(4).html(formato_numero(data.d[i].OC_NIMPUS, 2, ".", ","));
                                }
                                sumasol = Number(sumasol) + Number(data.d[i].OC_NIMPMN);
                                sumadol = Number(sumadol) + Number(data.d[i].OC_NIMPUS);
                                $("td", row).eq(4).val(data.d[i].OC_CDISTOC)
                                $("td", row).eq(5).html(data.d[i].OC_CTIPORD);
                                $("td", row).eq(5).val(data.d[i].OC_CPROVOC);
                                $("td", row).eq(6).html(data.d[i].OC_CSITORD);
                                $("td", row).eq(6).val(data.d[i].OC_NTIPCAM);
                                $("td", row).eq(7).html(data.d[i].OC_CFORPA1);
                                $("td", row).eq(7).val(data.d[i].OC_CREMITE);
                                $("td", row).eq(8).html(data.d[i].OC_CUSEA01.toUpperCase());
                                $("td", row).eq(8).val(data.d[i].OC_CDETENT);
                                $("td", row).eq(9).html(data.d[i].OC_CUSEA02.toUpperCase());
                                $("td", row).eq(9).val(data.d[i].MONEDA);
                                $("td", row).eq(10).html(data.d[i].OC_CUSEA03.toUpperCase());
                                $("td", row).eq(10).val(data.d[i].situanum);
                                $("td", row).eq(2).val(data.d[i].ALMACEN);
                                $("td", row).eq(11).html(data.d[i].OC_CSOLICIT);
                                $("td", row).eq(11).val(data.d[i].OC_CRESPER2);

                                $("[id*=gvordencompra]").append(row);
                                row = $("[id*=gvordencompra] tr:last-child").clone(true);
                            }


                            //copiaaa

                            var row = $("[id*=gvcopia] tr:last-child").clone(true);
                            $("[id*=gvcopia] tr").not($("[id*=gvcopia] tr:first-child")).remove();

                            for (var i = 0; i < data.d.length; i++) {

                                $("td", row).eq(0).html(data.d[i].OC_CNUMORD);
                                $("td", row).eq(0).val(data.d[i].OC_CCODPRO);
                                $("td", row).eq(1).html(data.d[i].OC_DFECDOC);
                                $("td", row).eq(1).val(data.d[i].OC_CDIRPRO);
                                $("td", row).eq(2).html(data.d[i].OC_CRAZSOC);
                                $("td", row).eq(3).html(data.d[i].OC_CCODMON);
                                $("td", row).eq(3).val(data.d[i].OC_CLUGFAC);

                                if (data.d[i].OC_CCODMON.trim() == "MN") {
                                    $("td", row).eq(4).html(formato_numero(data.d[i].OC_NIMPMN, 2, ".", ","));
                                }
                                if (data.d[i].OC_CCODMON.trim() != "MN") {
                                    $("td", row).eq(4).html(formato_numero(data.d[i].OC_NIMPUS, 2, ".", ","));
                                }
                                //sumasol = Number(sumasol) + Number(data.d[i].OC_NIMPMN);
                                //sumadol = Number(sumadol) + Number(data.d[i].OC_NIMPUS);
                                $("td", row).eq(4).val(data.d[i].OC_CDISTOC)
                                $("td", row).eq(5).html(data.d[i].OC_CTIPORD);
                                $("td", row).eq(5).val(data.d[i].OC_CPROVOC);
                                $("td", row).eq(6).html(data.d[i].OC_CSITORD);
                                $("td", row).eq(6).val(data.d[i].OC_NTIPCAM);
                                $("td", row).eq(7).html(data.d[i].OC_CFORPA1);
                                $("td", row).eq(7).val(data.d[i].OC_CREMITE);
                                $("td", row).eq(8).html(data.d[i].OC_CUSEA01.toUpperCase());
                                $("td", row).eq(8).val(data.d[i].OC_CDETENT);
                                $("td", row).eq(9).html(data.d[i].OC_CUSEA02.toUpperCase());
                                $("td", row).eq(9).val(data.d[i].MONEDA);
                                $("td", row).eq(10).html(data.d[i].OC_CUSEA03.toUpperCase());
                                $("td", row).eq(10).val(data.d[i].situanum);
                                $("td", row).eq(2).val(data.d[i].ALMACEN);
                                $("td", row).eq(11).html(data.d[i].OC_CSOLICIT);
                                $("td", row).eq(11).val(data.d[i].OC_CRESPER2);

                                $("[id*=gvcopia]").append(row);
                                row = $("[id*=gvcopia] tr:last-child").clone(true);
                            }


                            Operacion.mask("txtsumamn").val(formato_numero(sumasol, 2, ".", ","));
                            Operacion.mask("txtsumaus").val(formato_numero(sumadol, 2, ".", ","));
                            Operacion.mask("txtreg").val(data.d.length);
                        } else {
                            var row = $("[id*=gvordencompra] tr:last-child").clone(true);
                            $("[id*=gvordencompra] tr").not($("[id*=gvordencompra] tr:first-child")).remove();

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
                            $("td", row).eq(0).val("");
                            $("td", row).eq(1).val("");
                            $("td", row).eq(2).val("");
                            $("td", row).eq(3).val("");
                            $("td", row).eq(4).val("");
                            $("td", row).eq(5).val("");
                            $("td", row).eq(6).val("");
                            $("td", row).eq(7).val("");
                            $("td", row).eq(8).val("");
                            $("td", row).eq(9).val("");
                            $("td", row).eq(10).val("");
                            $("td", row).eq(11).html("");
                            Operacion.mask("txtsumamn").val("");
                            Operacion.mask("txtsumaus").val("");
                            Operacion.mask("txtreg").val("");
                            $("[id*=gvordencompra]").append(row);
                            //alert("no se encontro registro");
                        }
                    },
                    error: function (response) {
                        if (response.length != 0)
                            alert(response);
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

                if (separador_miles) {
                    // Añadimos los separadores de miles
                    var miles = new RegExp("(-?[0-9]+)([0-9]{3})");
                    while (miles.test(numero)) {
                        numero = numero.replace(miles, "$1" + separador_miles + "$2");
                    }
                }

                return numero;
            }

            function DETALLE(numorden, indice) {
                var LDE = {};
                LDE.OC_CNUMORD = numorden;
                //var item = "";
                var numeroorden = numorden;
                var indiceap = indice;
                $.ajax({
                    type: "POST",
                    url: "../../ANTICIPO/OCemision.aspx/GetListaDetalle",
                    data: '{LDE: ' + JSON.stringify(LDE) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {

                        if (data.d.length > 0) {
                            for (var i = 0; i < data.d.length; i++) {
                                var ssitm = data.d[i].OC_CITEM;
                                aprobardet(numeroorden, indiceap, ssitm);
                            }

                        }
                        else {

                            alert("no se encontro registro");
                        }

                    },
                    error: function (response) {
                        if (response.length != 0)
                            alert(response);
                    }
                });

            }

            $(".imprimi").click(function () {

                var trp = $(this).parent().parent();
                if ($("#MainContent_txtnumoc").val() != "") {
                    var idnumor = $("#MainContent_txtnumoc").val();
                }
                else {

                    var idnumor = $("td:eq(0)", trp).html();
                }


                idprov = "";
                idnumor = idnumor.trim();

                var sidprov = $("td:eq(0)", trp).val();
                idnumor = idnumor.trim();

                var sidprov = $("td:eq(0)", trp).val();
                idnumor = idnumor.trim();

                desprov = "";
                if (idnumor != "&nbsp;") {
                    window.open("../../ORDENCOMPRA/REPORTES/ReporteOrden.aspx?ID=" + idnumor + "&IDPROC=" + sidprov + "&DEPRO=" + desprov + "&IDAG=0003", '_blank');

                }
                else {
                    alert("Error en envio de Datos");
                }
            });

            $(".imprimi02").click(function () {

                var trpa = $(this).parent().parent();
                var idnumor = $("td:eq(0)", trpa).html();

                var sidprov = $("td:eq(0)", trpa).val();
                idnumor = $("#MainContent_txtnumoc").val().trim();
                desprov = "";
                if (idnumor != "&nbsp;") {
                    window.open("../../ORDENCOMPRA/REPORTES/ReporteOrden.aspx?ID=" + idnumor + "&IDPROC=" + sidprov + "&DEPRO=" + desprov + "&IDAG=0003", '_blank');
                } else {
                    alert("Error en envio de Datos");
                }
            });

            //CONTABILIZAR DOCUMENTOS
            $(".imprimi00").click(function () {
                var trpa = $(this).parent().parent();
                var idnumor = $("td:eq(0)", trpa).html();

                var sidprov = $("td:eq(0)", trpa).val();
                idnumor = $("#MainContent_txtnumoc").val().trim();
                if (idnumor != "&nbsp;") {
                    var TIPO = Operacion.mask('ddlTIPOC').val();
                    if (TIPO == "N" || TIPO == "I") {
                        window.open("../../FINANZAS/DOCUMENTOS/ContabilizaDOC.aspx?ID=" + idnumor, '_blank');
                    } else {
                        window.open("../../FINANZAS/DOCUMENTOS/ContabilizaDOS.aspx?ID=" + idnumor, '_blank');
                    }

                } else {
                    alert("Error en envio de Datos");
                }
            });

            //para ver historial de precios
            function filtarcantidademb(gidpped) {
                rr = gidpped;
                var REQ = {};
                REQ.RD_CCODIGO = rr;
                $.ajax({

                    type: "POST",
                    url: "../../ANTICIPO/OCemision.aspx/ListarHistorialPrecios",
                    data: '{REQ: ' + JSON.stringify(REQ) + '}',
                    contentType: "application/json; charset=utf-8",
                    async: false,

                    dataType: "json",
                    success: function (data) {

                        if (data.d.length > 0) {
                            var row = $("[id*=gvdetallereq] tr:last-child").clone(true);
                            $("[id*=gvdetallereq] tr").not($("[id*=gvdetallereq] tr:first-child")).remove();

                            for (var i = 0; i < data.d.length; i++) {

                                $("td", row).eq(0).html(data.d[i].OC_CCODPRO);
                                $("td", row).eq(1).html(data.d[i].OC_CRAZSOC);
                                $("td", row).eq(2).html(data.d[i].OC_CNUMORD);
                                $("td", row).eq(3).html(data.d[i].OC_DFECDOC);
                                $("td", row).eq(4).html(data.d[i].OC_CCODMON);
                                $("td", row).eq(5).html(parseFloat(data.d[i].OC_NPREUN2).toFixed(2));

                                $("[id*=gvdetallereq]").append(row);
                                row = $("[id*=gvdetallereq] tr:last-child").clone(true);

                            }
                        } else {
                            var row = $("[id*=gvdetallereq] tr:last-child").clone(true);
                            $("[id*=gvdetallereq] tr").not($("[id*=gvdetallereq] tr:first-child")).remove();

                            $("td", row).eq(0).html("");
                            $("td", row).eq(1).html("");
                            $("td", row).eq(2).html("");
                            $("td", row).eq(3).html("");
                            $("td", row).eq(4).html("");
                            $("td", row).eq(5).html("");

                            $("[id*=gvdetallereq]").append(row);
                            //alert("no se encontro registro");
                        }
                    },
                    error: function (response) {
                        if (response.length != 0)
                            alert(response);
                    }
                });

            }

            Operacion.mask('ddlTIOC').change(function () {
                //ddlTIOC
                filtarocomprainicio();
            });

            Operacion.mask('ddlTIPOC').change(function () {
                if ($(this).val() == "S") {
                    Operacion.mask('ddlTIOC').empty();
                    mi_combo(0);
                    //filtarocomprainicio();
                } else {
                    Operacion.mask('ddlTIOC').empty();
                    mi_combo(1);
                    //filtarocomprainicio();
                }

            });

            Operacion.mask('cbSOC').live('change', function () {
                if (Operacion.mask('cbSOC').is(':checked')) {
                    Operacion.mask('txtOC').focus();
                } else {
                    Operacion.mask('txtOC').keypress(function () {
                        var CB_OC = Operacion.mask('cbSOC').is(':checked');
                        //console.log(CB_OC);
                        if (!CB_OC) {
                            var s = $(this).val().toUpperCase().split(" ");
                            $(".ordenes tr:hidden").show();
                            $.each(s, function () {
                                $(".ordenes tr:visible .oc:not(:contains('" + this + "'))").parent().hide();
                            });
                        }
                    });
                }
            });
            Operacion.mask('txtFF').change(function () {
                var MF1 = Operacion.mask('txtFI').val();
                mi_resumen(moment(MF1, 'DD/MM/YYYY'), moment($(this).val(), 'DD/MM/YYYY'));
            });
            Operacion.mask('txtOC').keypress(function () {
                var CB_OC = Operacion.mask('cbSOC').is(':checked');
                //console.log(CB_OC);
                if (!CB_OC) {
                    var s = $(this).val().toUpperCase().split(" ");
                    $(".ordenes tr:hidden").show();
                    $.each(s, function () {
                        $(".ordenes tr:visible .oc:not(:contains('" + this + "'))").parent().hide();
                    });
                } else {
                    //SOLO CUANDO QUIERE BUSCAR DIRECTAMENTE LA OC
                    if ($(this).val().length == "11") {
                        $('.btbuscar').focus();
                        $('.btbuscar').select();
                    }
                }
            });

            $('#btnOC').click(function () {
                generaNGrilla();
                // add parser through the tablesorter addParser method 
                $.tablesorter.addParser({
                    id: "commadigit",
                    is: function (s, table) {
                        var c = table.config;
                        return $.tablesorter.isDigit(s.replace(/[,.]/g, ""), c);
                    },
                    format: function (s) {
                        //alert($.tablesorter.formatFloat(s.replace(/[.,]/g, "")));
                        //return parseFloat(s).toFixed(2);
                        return $.tablesorter.formatFloat(s.replace(/[,.]/g, ""));
                    },
                    type: "numeric"
                });
                $("#MainContent_gvDOC").tablesorter({
                    dateFormat: "uk",
                    headers: {
                        7: {
                            sorter: 'commadigit'
                        }
                    },
                    widgets: ['zebra']
                });
            });

        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="tabs">
        <ul>
            <li><a href="#tabs-1">Ordenes por Contabilizar</a></li>
            <li><a href="#tabs-2">Ordenes contabilizadas</a></li>
            <li><a href="#tabs-3">Ordenes Resumen</a></li>
        </ul>
        <div id="tabs-1">
            <fieldset style="float: left; width: 1150px;">
                <legend>Ordenes</legend>
                <table>
                    <tr>
                        <td>Proveedor</td>
                        <td colspan="3">
                            <asp:TextBox ID="txtprove" runat="server" Width="300"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtidpro" Enabled="false" runat="server" Width="100"></asp:TextBox>
                        </td>
                        <td>Fecha del:</td>
                        <td>
                            <asp:TextBox ID="txtfecha1" runat="server" Width="80"></asp:TextBox>
                        </td>
                        <td colspan="2" rowspan="2">
                            <input class="btbuscar btn" value="Buscar" type="button" style="width: 100px" /></td>
                        <td>

                            <asp:Label ID="lblacceso" runat="server" ForeColor="#f1f1f1"></asp:Label>
                            <asp:Label ID="lblusuario" runat="server" ForeColor="#f1f1f1"></asp:Label>
                            <asp:Label ID="lblpermiso" runat="server" ForeColor="#f1f1f1"></asp:Label>
                        </td>
                        <td rowspan="2">
                            <img id="btimaga" class="btimag" runat="server" width="25" height="25" src="~/Images/exel.jpg" style="cursor: pointer" />
                        </td>
                    </tr>
                    <tr>
                        <td>Tipo</td>
                        <td>
                            <!--<asp:DropDownList ID="ddlestad" runat="server" Width="130"></asp:DropDownList>-->
                            <asp:DropDownList ID="ddlTIPOC" runat="server">
                                <asp:ListItem Value="-1">[Todos]</asp:ListItem>
                                <asp:ListItem Value="N">Nacional</asp:ListItem>
                                <asp:ListItem Value="I">Importacion</asp:ListItem>
                                <asp:ListItem Value="S">Servicio</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>Estado:<asp:DropDownList ID="ddlTIOC" runat="server">
                            <asp:ListItem Value="-1">[Todos]</asp:ListItem>
                            <asp:ListItem Value="4">Rec. Parcial</asp:ListItem>
                            <asp:ListItem Value="5">Rec. Total</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                        <td>
                            <!--<asp:DropDownList ID="ddltipo" runat="server" Width="130"></asp:DropDownList>-->
                        </td>
                        <td></td>
                        <td>Fecha al:</td>
                        <td>
                            <asp:TextBox ID="txtfecha2" runat="server" Width="80"></asp:TextBox>
                        </td>

                    </tr>

                    <tr>
                        <td>Solicitante</td>
                        <td colspan="3">
                            <asp:TextBox ID="txtsolicitante" runat="server" Width="297px"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtcodsol" runat="server" Width="100px"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td></td>
                    </tr>

                    <tr>
                        <td>Nro. O/C</td>
                        <td colspan="3">
                            <asp:TextBox ID="txtOC" MaxLength="11" runat="server"></asp:TextBox>
                            <asp:CheckBox ID="cbSOC" Text="Solo O/C" runat="server" />
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>

                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </fieldset>


            <table>
                <tr>
                    <td colspan="7">
                        <asp:GridView ID="gvordencompra" class="tablesorter" runat="server" OnRowCreated="griddata_RowCreated" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" Width="1200px">
                            <Columns>
                                <asp:BoundField DataField="OC_CNUMORD" HeaderText="N° DE ORDEN">
                                    <ItemStyle Font-Size="8pt" />
                                    <ItemStyle CssClass="oc"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="OC_DFECDOC" HeaderText="FECHA" ItemStyle-Width="70px">
                                    <ItemStyle Width="70px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="OC_CRAZSOC" HeaderText="PROVEEDOR" ItemStyle-Width="300px">
                                    <ItemStyle Width="300px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="OC_CCODMON" HeaderText="MONEDA" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="70px">
                                    <ItemStyle HorizontalAlign="Center" Width="70px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="OC_NIMPMN" HeaderText="IMPORTE" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="90px">
                                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="OC_CSITORD" HeaderText="ESTADO" />
                                <asp:BoundField DataField="OC_CTIPORD" HeaderText="TIPO" />
                                <asp:BoundField DataField="OC_CFORPA1" HeaderText="FPAGO" />
                                <asp:BoundField DataField="OC_CUSEA01" HeaderText="USER1" />
                                <asp:BoundField DataField="OC_CUSEA02" HeaderText="USER2" />
                                <asp:BoundField DataField="OC_CUSEA03" HeaderText="USER3" />
                                <asp:BoundField DataField="OC_CSOLICIT" HeaderText="SOLICITANTE" ItemStyle-Width="50px">
                                    <FooterStyle ForeColor="Black" />
                                    <ItemStyle Width="50px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="AC_CCTAMNT" HeaderText="BCP" />
                                <asp:BoundField DataField="AC_CCTAMN7" HeaderText="BBVA" />
                                <asp:BoundField HeaderText="INTER" DataField="AC_CCTAMNK" />

                                <asp:TemplateField HeaderText="VER">
                                    <ItemTemplate>
                                        <div class="btadd" style="text-align: center">
                                            <img alt="" src="../../Images/Message_Information.png" width="25" style="cursor: pointer" />
                                            <%--<asp:ImageButton ID="imbeliminar" runat="server" ImageUrl="~/Images/Message_Error.png" Width="25px" OnClick="ib_eliminar_Click" onclientclick="javascript:return confirm('Esta Seguro?')"/>--%>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="IMP">
                                    <ItemTemplate>
                                        <div class="imprimi" style="text-align: center">
                                            <img alt="" src="../../Images/printer.png" width="25" style="cursor: pointer" />
                                            <%--<asp:ImageButton ID="imbeliminar" runat="server" ImageUrl="~/Images/Message_Error.png" Width="25px" OnClick="ib_eliminar_Click" onclientclick="javascript:return confirm('Esta Seguro?')"/>--%>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" Height="28" />
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

            <table style="background-color: #f1f1f1; height: 30px" border="0">
                <tr>
                    <td><b>TOTAL REGISTROS:</b> </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtreg" Width="100" Enabled="false" Style="text-align: center" />
                    </td>
                    <td><b>SUMA SOLES:</b></td>
                    <td>
                        <asp:TextBox runat="server" ID="txtsumamn" Width="100" Enabled="false" Style="text-align: right" />
                    </td>
                    <td><b>SUMA DOLARES:</b></td>
                    <td>
                        <asp:TextBox runat="server" ID="txtsumaus" Width="100" Enabled="false" Style="text-align: right" />
                    </td>
                </tr>
            </table>

            <div id="expo" style="display: none">
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="gvcopia" class="tablesorter" runat="server" OnRowCreated="griddata_RowCreated" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" Width="1200px">
                                <Columns>
                                    <asp:BoundField DataField="OC_CNUMORD" HeaderText="N° DE ORDEN">
                                        <ItemStyle Font-Size="11pt" />
                                        <ItemStyle CssClass="oc"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OC_DFECDOC" HeaderText="FECHA" ItemStyle-Width="70px" />
                                    <asp:BoundField DataField="OC_CRAZSOC" HeaderText="PROVEEDOR" ItemStyle-Width="300px" />
                                    <asp:BoundField DataField="OC_CCODMON" HeaderText="MONEDA" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="70px" />
                                    <asp:BoundField DataField="OC_NIMPMN" HeaderText="IMPORTE" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="90px">
                                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OC_CSITORD" HeaderText="ESTADO" />
                                    <asp:BoundField DataField="OC_CTIPORD" HeaderText="TIPO" />
                                    <asp:BoundField DataField="OC_CFORPA1" HeaderText="FPAGO" />
                                    <asp:BoundField DataField="OC_CUSEA01" HeaderText="USER1" />
                                    <asp:BoundField DataField="OC_CUSEA02" HeaderText="USER2" />
                                    <asp:BoundField DataField="OC_CUSEA03" HeaderText="USER3" />
                                    <asp:BoundField DataField="OC_CSOLICIT" HeaderText="SOLICITANTE" ItemStyle-Width="50px">
                                        <FooterStyle ForeColor="Black" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="AC_CCTAMNT" HeaderText="BCP" />
                                    <asp:BoundField DataField="AC_CCTAMN7" HeaderText="BBVA" />
                                    <asp:BoundField HeaderText="INTER" DataField="AC_CCTAMNK" />
                                    <asp:BoundField HeaderText="BNA.DET MN" DataField="AC_CCTADET" />
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <div class="btadd" style="text-align: center">
                                                <%--  <img alt="" src="../../Images/Message_Information.png" width="25" style="cursor: pointer" />--%>
                                                <%--<asp:ImageButton ID="imbeliminar" runat="server" ImageUrl="~/Images/Message_Error.png" Width="25px" OnClick="ib_eliminar_Click" onclientclick="javascript:return confirm('Esta Seguro?')"/>--%>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <div class="imprimi" style="text-align: center">
                                                <%-- <img alt="" src="../../Images/printer.png" width="25" style="cursor: pointer" />--%>
                                                <%--<asp:ImageButton ID="imbeliminar" runat="server" ImageUrl="~/Images/Message_Error.png" Width="25px" OnClick="ib_eliminar_Click" onclientclick="javascript:return confirm('Esta Seguro?')"/>--%>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" Height="28" />
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

            <%--style="display:none"--%>

            <div id="dvdetalle" style="display: none;">
                <%--<asp:ImageButton ID="imbeliminar" runat="server" ImageUrl="~/Images/Message_Error.png" Width="25px" OnClick="ib_eliminar_Click" onclientclick="javascript:return confirm('Esta Seguro?')"/>--%>
                <table>
                    <tr>
                        <td colspan="6">

                            <input id="btnimprimir" type="button" value="Imprimir" class="imprimi02 btn" />

                            <input id="btnimprimir0" type="button" value="Contabilizar" class="imprimi00 btn" /></td>
                    </tr>
                    <tr>
                        <td colspan="6">&nbsp;</td>
                    </tr>
                    <tr>
                        <td>N° Orden:
                        </td>
                        <td colspan="3">

                            <asp:TextBox ID="txtnumoc" runat="server" Width="100" ReadOnly="true" class="txtmost" Enabled="False"></asp:TextBox>

                        </td>
                        <td>Fecha</td>
                        <td>
                            <asp:TextBox ID="txtfecha" class="tcamb" runat="server" Width="130" placeholder="00/00/0000" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Proveedor:</td>
                        <td colspan="4">
                            <asp:TextBox ID="txtproveedor" runat="server" Width="360" Enabled="False"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtruc" Enabled="false" runat="server" Width="130"></asp:TextBox>
                        </td>

                    </tr>
                    <tr>
                        <td>Moneda:</td>
                        <td class="auto-style1">

                            <asp:TextBox ID="txtmoneda" runat="server" Width="161px" Enabled="False"></asp:TextBox>

                        </td>
                        <td></td>
                        <td></td>
                        <td>
                            <asp:Label ID="lblBAH" runat="server" Text="Bahia"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBAH" runat="server" Width="130px" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Forma Pago:</td>
                        <td colspan="3">
                            <asp:TextBox ID="ddlfpago" runat="server" Width="292px" Enabled="False"></asp:TextBox>
                        </td>

                        <td>Tipo Cambio</td>
                        <td>
                            <asp:TextBox ID="txttcambio" runat="server" Width="130" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>

                </table>
                <hr />
                <fieldset style="background-color: #99CCFF">

                    <table>
                        <tr>
                            <td>
                                <div style="overflow: auto; width: 1210px; height: 120px">
                                    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" Font-Size="8pt" Width="1209px" HorizontalAlign="Center">
                                        <Columns>
                                            <asp:BoundField DataField="OC_CITEM" HeaderText="ITEM">
                                                <ItemStyle Width="8px" VerticalAlign="Top"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="OC_CCODREF" HeaderText="DESCRIPCIÓN">
                                                <ItemStyle Width="200px" VerticalAlign="Top"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="OC_CUNIDAD" HeaderText="UNID.">
                                                <ItemStyle Width="8px" VerticalAlign="Top"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="OC_NCANORD" HeaderText="CANT.">
                                                <FooterStyle HorizontalAlign="Right" />
                                                <ItemStyle Width="8px" HorizontalAlign="Right" VerticalAlign="Top"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="OC_NPREUN2" HeaderText="PRECIO">
                                                <FooterStyle HorizontalAlign="Right" />
                                                <ItemStyle Width="8px" HorizontalAlign="Right" VerticalAlign="Top"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="OC_NDSCPAD" HeaderText="DCTO. ADIC.">
                                                <FooterStyle HorizontalAlign="Right" />
                                                <ItemStyle Width="8px" HorizontalAlign="Right" VerticalAlign="Top"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="OC_NDSCPIT" HeaderText="DCTO. ITEM">
                                                <FooterStyle HorizontalAlign="Right" />
                                                <ItemStyle Width="8px" HorizontalAlign="Right" VerticalAlign="Top"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="OC_NIGVPOR" HeaderText="IGV">
                                                <FooterStyle HorizontalAlign="Right" />
                                                <ItemStyle Width="8px" HorizontalAlign="Right" VerticalAlign="Top"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="OC_NPREUNI" HeaderText="PREC. FINAL">
                                                <FooterStyle HorizontalAlign="Right" />
                                                <ItemStyle Width="8px" HorizontalAlign="Right" VerticalAlign="Top"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="OC_NDESCTO" HeaderText="TOTAL DSCT.">
                                                <FooterStyle HorizontalAlign="Right" />
                                                <ItemStyle Width="8px" HorizontalAlign="Right" VerticalAlign="Top"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="OC_NIGV" HeaderText="TOTAL IGV">
                                                <FooterStyle HorizontalAlign="Right" />
                                                <ItemStyle Width="8px" HorizontalAlign="Right" VerticalAlign="Top"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SUBTOTAL" HeaderText="SUBTOTAL">
                                                <FooterStyle HorizontalAlign="Right" />
                                                <ItemStyle Width="8px" HorizontalAlign="Right" VerticalAlign="Top"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="OC_NISC" HeaderText="Observaciones">
                                                <FooterStyle HorizontalAlign="Right" />
                                                <ItemStyle Width="8px" HorizontalAlign="Right" VerticalAlign="Top"></ItemStyle>
                                            </asp:BoundField>


                                            <asp:TemplateField HeaderText="H.Precios">
                                                <ItemTemplate>
                                                    <div class="bthistorial" style="text-align: center; vertical-align: top;">
                                                        <img alt="" src="../../Images/Message_Information.png" width="20" height="20" style="cursor: pointer" />
                                                        <%--<asp:ImageButton ID="imbeliminar" runat="server" ImageUrl="~/Images/Message_Error.png" Width="25px" OnClick="ib_eliminar_Click" onclientclick="javascript:return confirm('Esta Seguro?')"/>--%>
                                                    </div>
                                                </ItemTemplate>
                                                <ItemStyle Width="25px" HorizontalAlign="Center" />
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

                </fieldset>


                <table>
                    <tr>
                        <td>Total Bruto:</td>
                        <td>
                            <asp:TextBox runat="server" Width="150" ID="txttbrutof" Enabled="false" Style="text-align: right"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>Total Dcto:</td>
                        <td>
                            <asp:TextBox runat="server" Width="150" ID="txtdescf" Enabled="false" Style="text-align: right"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>IGV:</td>
                        <td>
                            <asp:TextBox runat="server" Width="150" ID="txtigvf" Enabled="false" Style="text-align: right"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>Neto a Pagar:</td>
                        <td>
                            <asp:TextBox runat="server" Width="150" ID="txtnetof" Enabled="false" Style="text-align: right"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>

                        <td>
                            <asp:TextBox ID="txtusu1" runat="server" Width="0px" BorderStyle="None"></asp:TextBox>
                            <asp:TextBox ID="txtusu2" runat="server" Width="0px" BorderStyle="None"></asp:TextBox>
                            <asp:TextBox ID="txtusu3" runat="server" Width="0px" BorderStyle="None"></asp:TextBox>
                            <asp:TextBox ID="txtestadooc" runat="server" Width="0px" BorderStyle="None"></asp:TextBox>

                        </td>
                        <td rowspan="2">&nbsp;&nbsp;

                        </td>

                        <td rowspan="2">&nbsp;</td>

                    </tr>
                </table>

            </div>
            <%--Style="display:none"--%>

            <div id="EstadoPedido" style="display: none;">
                <table>

                    <tr>
                        <td>
                            <asp:Label ID="lblcabnumero" runat="server" Text="Artículo:" Font-Bold="True"></asp:Label>
                            <asp:Label ID="lblnumero" runat="server"></asp:Label>
                            <br />
                            <asp:GridView ID="gvdetallereq" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="False" Font-Size="8pt">
                                <Columns>
                                    <asp:BoundField DataField="OC_CCODPRO" HeaderText="RUC" HeaderStyle-HorizontalAlign="Left">
                                        <FooterStyle HorizontalAlign="Right" />

                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>

                                        <ItemStyle Width="30px" HorizontalAlign="Right" VerticalAlign="Top"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OC_CRAZSOC" HeaderText="PROVEEDOR" HeaderStyle-HorizontalAlign="Left">
                                        <FooterStyle HorizontalAlign="Right" />

                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>

                                        <ItemStyle Width="250px" HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OC_CNUMORD" HeaderText="NRO O.C" HeaderStyle-HorizontalAlign="Left">

                                        <FooterStyle HorizontalAlign="Right" />

                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>

                                        <ItemStyle Width="8px" HorizontalAlign="Right" VerticalAlign="Top"></ItemStyle>
                                    </asp:BoundField>


                                    <asp:BoundField DataField="OC_DFECDOC" HeaderText="FECHA" HeaderStyle-HorizontalAlign="Left">
                                        <FooterStyle HorizontalAlign="Right" />

                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>

                                        <ItemStyle Width="20px" HorizontalAlign="Right" VerticalAlign="Top"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OC_CCODMON" HeaderText="MONEDA" HeaderStyle-HorizontalAlign="Left">
                                        <FooterStyle HorizontalAlign="Right" />

                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>

                                        <ItemStyle Width="30px" HorizontalAlign="Right" VerticalAlign="Top"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OC_NPREUN2" HeaderText="PRECIO" HeaderStyle-HorizontalAlign="Left">
                                        <FooterStyle HorizontalAlign="Right" />

                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>

                                        <ItemStyle Width="8px" HorizontalAlign="Right" VerticalAlign="Top"></ItemStyle>
                                    </asp:BoundField>


                                </Columns>
                                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                <RowStyle ForeColor="#003399" BackColor="White" />
                                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                <SortedDescendingHeaderStyle BackColor="#002876" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div id="tabs-2">
            <table>
                <tr>
                    <td>Fecha Inicio</td>
                    <td>
                        <asp:TextBox ID="txtOCF1" class="dpoc1" runat="server"></asp:TextBox></td>
                    <td>Fecha Final</td>
                    <td>
                        <asp:TextBox ID="txtOCF2" class="dpoc2" runat="server"></asp:TextBox></td>
                    <td rowspan="2">
                        <input id="btnOC" type="button" class="btn" value="Buscar" />
                        <!--<asp:Button ID="btnOC" class="btn" runat="server" Text="Buscar" OnClick="btnOC_Click" />-->
                    </td>

                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td>OC</td>
                    <td>
                        <asp:TextBox ID="txtOCC" runat="server"></asp:TextBox></td>
                    <td>Proveedor</td>
                    <td>
                        <asp:TextBox ID="txtOCP" runat="server"></asp:TextBox></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td>Usuario&nbsp;</td>
                    <td>
                        <asp:DropDownList ID="ddlUSER" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
            </table>
            <div id="migrilla">
                <asp:GridView ID="gvDOC" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" Width="100%" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                    <Columns>
                        <asp:BoundField DataField="CP_CTDOCRE" HeaderText="TDR" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="3%" />
                            <ItemStyle Font-Size="8pt" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CP_CNDOCRE" HeaderText="Num. Doc Ref." ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="30" />
                            <ItemStyle Font-Size="8pt" Width="7%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CP_CVANEXO" HeaderText="Agencia" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="50" />
                            <ItemStyle Font-Size="8pt" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CP_CCODIGO" HeaderText="Codigo" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="7%" />
                            <ItemStyle Font-Size="8pt" Width="7%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NOMTIT" HeaderText="Nombre" ItemStyle-HorizontalAlign="Left">
                            <HeaderStyle Font-Size="8pt" HorizontalAlign="Left" Width="14%" Wrap="False" />
                            <ItemStyle Font-Size="8pt" Width="110px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CP_CTIPDOC" HeaderText="T.Doc" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="3%" />
                            <ItemStyle Font-Size="8pt" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CP_CNUMDOC" HeaderText="Num. Dcto" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="20px" />
                            <ItemStyle Font-Size="8pt" Width="20px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CP_CCODMON" HeaderText="Moneda" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="5%" />
                            <ItemStyle Font-Size="8pt" />
                        </asp:BoundField>
                        <asp:BoundField DataField="IMPORTE" HeaderText="Importe" ItemStyle-HorizontalAlign="right">
                            <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="6%" />
                            <ItemStyle Font-Size="8pt" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CP_DFECCRE1" HeaderText="Fecha Registro" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="6%" />
                            <ItemStyle Font-Size="8pt" Width="10" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CENCOR" HeaderText="Centro Costo Ref" ItemStyle-HorizontalAlign="Left">
                            <HeaderStyle Font-Size="8pt" HorizontalAlign="Left" Width="110" />
                            <ItemStyle Font-Size="8pt" Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NOMARE" HeaderText="Dpto" ItemStyle-HorizontalAlign="Left">
                            <HeaderStyle Font-Size="8pt" HorizontalAlign="Left" Width="40" />
                            <ItemStyle Font-Size="8pt" Width="8%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CP_CUSER" HeaderText="Usuario" ItemStyle-HorizontalAlign="Left">
                            <HeaderStyle Font-Size="8pt" HorizontalAlign="Left" Width="10" />
                            <ItemStyle Font-Size="8pt" Width="8%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CP_CSITUAC" HeaderText="Situacion" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="5%" />
                            <ItemStyle Font-Size="8pt" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="">
                            <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="5%" />
                            <ItemTemplate>
                                <div class="btDetalle" style="text-align: center; display: inline;">
                                    <img alt="" src="../../Images/historial.png" width="25" style="cursor: pointer" />
                                    <%--<asp:ImageButton ID="imbeliminar" runat="server" ImageUrl="~/Images/Message_Error.png" Width="25px" OnClick="ib_eliminar_Click" onclientclick="javascript:return confirm('Esta Seguro?')"/>--%>
                                </div>
                                <div class="btPrinter" style="text-align: center; display: inline;">
                                    <img alt="" src="../../Images/Printer.png" width="25" style="cursor: pointer" />
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
        </div>
        <div id="tabs-3">
            <p>Ordenes contabilizadas con factura</p>
            <label>Fecha Inicial</label><asp:TextBox ID="txtFI" class="mdp1" runat="server"></asp:TextBox>&nbsp;&nbsp;<label>Fecha Final</label><asp:TextBox ID="txtFF" class="mdp2" runat="server"></asp:TextBox>
            <div id="mi_tabla1" style="width: 280px;">
                <asp:GridView ID="gvRESUMEN" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                    <Columns>
                        <asp:BoundField DataField="CP_CUSER" HeaderText="Usuario" />
                        <asp:BoundField DataField="CP_CAREA" HeaderText="Tipo Ordenes" />
                        <asp:BoundField DataField="CP_CSUBDIA" HeaderText="Subdiario">
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CP_NIMP2MN" HeaderText="Cantidad">
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
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
        </div>
    </div>



</asp:Content>
