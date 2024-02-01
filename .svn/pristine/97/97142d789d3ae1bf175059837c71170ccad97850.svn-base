<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ReporteStockValorizado.aspx.cs" Inherits="Default2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/javascript">
        $(function () {
            $("#MainContent_txtdato").autocomplete(
                        {
                            source: function (request, response) {
                                if (($("#MainContent_ddlorden").val().trim() == "A")) {
                                    $.ajax({
                                        url: "ReporteStockValorizado.aspx/gatarticulos",
                                        data: "{ 'productos': '" + request.term + "' }",
                                        dataType: "json",
                                        type: "POST",
                                        contentType: "application/json; charset=utf-8",
                                        dataFilter: function (data) { return data; },
                                        success: function (data) {
                                            response($.map(data.d, function (item) {
                                                return {
                                                    value: item.AR_CDESCRI,
                                                    id: item.AR_CCODIGO

                                                }
                                            }))
                                        },
                                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                                            //alert(textStatus);
                                        }
                                    });
                                }
                                if (($("#MainContent_ddlorden").val().trim() != "A") && ($("#MainContent_ddlorden").val().trim() != "L")) {
                                    $.ajax({
                                        url: "ReporteStockValorizado.aspx/GETVARIOS",
                                        data: "{ 'CLAVE': '" + request.term + "' ,  'INDICADOR': '" + $("#MainContent_ddlorden").val() + "' }",
                                        dataType: "json",
                                        type: "POST",
                                        contentType: "application/json; charset=utf-8",
                                        dataFilter: function (data) { return data; },
                                        success: function (data) {
                                            response($.map(data.d, function (item) {
                                                return {
                                                    value: item.TG_CCLAVE+" - "+item.TG_CDESCRI,
                                                    id: item.TG_CCLAVE

                                                }
                                            }))
                                        },
                                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                                            //alert(textStatus);
                                        }
                                    });


                                }
                            },
                            minLength: 1,
                            select: function (event, ui) {
                                var str = ui.item.id;
                                var cadena = str
                                posicionEspacio = cadena.indexOf("@"), //Obtengo la posición del espacio en la cadena
                                primerApellido = cadena.substring(0, posicionEspacio) //Obtengo la porción deseada de la cadena
                                enMinuscula = primerApellido.toLowerCase(); //Convierto el apellido a minúscula

                                primerApellido = cadena.substring(posicionEspacio + 1, str.length)
                                $('#MainContent_txtcodigo').val(str);


                            }
                        });

            $("#MainContent_txtdato1").autocomplete(
                       {
                           source: function (request, response) {
                               if (($("#MainContent_ddlorden").val().trim() == "A")) {
                                   $.ajax({
                                       url: "ReporteStockValorizado.aspx/gatarticulos",
                                       data: "{ 'productos': '" + request.term + "' }",
                                       dataType: "json",
                                       type: "POST",
                                       contentType: "application/json; charset=utf-8",
                                       dataFilter: function (data) { return data; },
                                       success: function (data) {
                                           response($.map(data.d, function (item) {
                                               return {
                                                   value: item.AR_CDESCRI,
                                                   id: item.AR_CCODIGO

                                               }
                                           }))
                                       },
                                       error: function (XMLHttpRequest, textStatus, errorThrown) {
                                           //alert(textStatus);
                                       }
                                   });
                               }
                               if (($("#MainContent_ddlorden").val().trim() != "A") && ($("#MainContent_ddlorden").val().trim() != "L")) {
                                   $.ajax({
                                       url: "ReporteStockValorizado.aspx/GETVARIOS",
                                       data: "{ 'CLAVE': '" + request.term + "' ,  'INDICADOR': '" + $("#MainContent_ddlorden").val() + "' }",
                                       dataType: "json",
                                       type: "POST",
                                       contentType: "application/json; charset=utf-8",
                                       dataFilter: function (data) { return data; },
                                       success: function (data) {
                                           response($.map(data.d, function (item) {
                                               return {
                                                   value: item.TG_CCLAVE + " - " + item.TG_CDESCRI,
                                                   id: item.TG_CCLAVE

                                               }
                                           }))
                                       },
                                       error: function (XMLHttpRequest, textStatus, errorThrown) {
                                           //alert(textStatus);
                                       }
                                   });


                               }
                           },
                           minLength: 1,
                           select: function (event, ui) {
                               var str = ui.item.id;
                               var cadena = str
                               posicionEspacio = cadena.indexOf("@"), //Obtengo la posición del espacio en la cadena
                               primerApellido = cadena.substring(0, posicionEspacio) //Obtengo la porción deseada de la cadena
                               enMinuscula = primerApellido.toLowerCase(); //Convierto el apellido a minúscula

                               primerApellido = cadena.substring(posicionEspacio + 1, str.length)
                               $('#MainContent_txtcodigofin').val(str);


                           }
                       });

            function TARERARTICULOS(){
                var LDE = [];
               
                $.ajax({
                    type: "POST",
                    url: "ReporteStockValorizado.aspx/getrangoarticulos",
                    data: "{ 'cod1': '" + $("#MainContent_txtcodigo").val() + "' ,  'cod2': '" + $("#MainContent_txtcodigofin").val() + "' }",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        if (data.d.length > 0) {
                            for (var i = 0; i < data.d.length; i++) {
                                LDE.push(data.d[i].AR_CCODIGO);
                               // alert(data.d[i].AR_CCODIGO);
                               }
                        }
                       
                    },
                    error: function (response) {
                        if (response.length != 0)
                            alert(response);
                    }
                            
                });
                return {LDE};
            }

            function TRAERVALORES() {
                var valores = [];

                $.ajax({
                    type: "POST",
                    url: "ReporteStockValorizado.aspx/getrangoarticulos",
                    data: "{ 'cod1': '" + $("#MainContent_txtcodigo").val() + "' ,  'cod2': '" + $("#MainContent_txtcodigofin").val() + "',  'COD3': '" + $("#MainContent_ddlorden").val() + "' }",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        if (data.d.length > 0) {
                            for (var i = 0; i < data.d.length; i++) {
                                valores.push(data.d[i].TG_CCLAVE);
                                
                            }
                        }

                    },
                    error: function (response) {
                        if (response.length != 0)
                            alert(response);
                    }

                });
                return { valores};
            }

            $(".IMPRIMIR").click(function () {

               

           if ( (document.getElementById("<%=chktodoalmacen.ClientID%>").checked == false) &&
                (document.getElementById("<%=rbdetallado.ClientID%>").checked == false)&&
                (document.getElementById("<%=rbresumen.ClientID%>").checked == false)) {

        if ($('#MainContent_ddlorden').val() == "A") {
            var periodo = "";
            var almacen = "";
            var moneda = $("#MainContent_ddlmoneda").val();
            var mes = $("#MainContent_ddlmes").val();
            var anio = $('#MainContent_txtannio').val();
                    periodo = anio + mes;
                   almacen = $('#MainContent_ddlalmacen').val();
                    window.open("../ALMACEN/REPORTES/stocvalorizado/SVALMACEN.aspx?PERIODO= " + periodo + "&ALMACEN=" + almacen + "&ARTICULO1=" + $('#MainContent_txtcodigo').val() + "&ARTICULO2=" + $('#MainContent_txtcodigofin').val() + " &MONEDA=" + moneda + " &indicador=" + "PA", '_blank');
               }
        if ($('#MainContent_ddlorden').val() == "06") {
            var periodo = "";
            var articulo = "";
            var moneda = $("#MainContent_ddlmoneda").val();
            var mes = $("#MainContent_ddlmes").val();
            var anio = $('#MainContent_txtannio').val();
            periodo = anio + mes;
            almacen = $('#MainContent_ddlalmacen').val();
            window.open("../ALMACEN/REPORTES/stocvalorizado/SVALMACEN.aspx?PERIODO= " + periodo + "&CODIGO=" + $('#MainContent_ddlorden').val() + "&ALMACEN=" + almacen + "&ARTICULO1=" + $('#MainContent_txtcodigo').val() + "&ARTICULO2=" + $('#MainContent_txtcodigofin').val() + " &DATO=" + dato + " &MONEDA=" + moneda + " &indicador=" + "TGF", '_blank');
        }
        if ($('#MainContent_ddlorden').val() == "38") {
            var periodo = "";
            var articulo = "";
            var almacen = "";
            var moneda = $("#MainContent_ddlmoneda").val();
            var mes = $("#MainContent_ddlmes").val();
            var anio = $('#MainContent_txtannio').val();
            periodo = anio + mes;
            dato = $('#MainContent_txtcodigo').val();
            almacen = $('#MainContent_ddlalmacen').val();
            window.open("../ALMACEN/REPORTES/stocvalorizado/SVALMACEN.aspx?PERIODO= " + periodo + "&CODIGO=" + $('#MainContent_ddlorden').val() + "&ALMACEN=" + almacen + "&ARTICULO1=" + $('#MainContent_txtcodigo').val() + "&ARTICULO2=" + $('#MainContent_txtcodigofin').val() + " &DATO=" + dato + " &MONEDA=" + moneda + " &indicador=" + "TFF", '_blank');
        }
        if ($('#MainContent_ddlorden').val() == "V7") {
            var periodo = "";
            var articulo = "";
            var almacen = "";
            var moneda = $("#MainContent_ddlmoneda").val();
            var mes = $("#MainContent_ddlmes").val();
            var anio = $('#MainContent_txtannio').val();
            periodo = anio + mes;
            almacen = $('#MainContent_ddlalmacen').val();
            window.open("../ALMACEN/REPORTES/stocvalorizado/SVALMACEN.aspx?PERIODO= " + periodo + "&CODIGO=" + $('#MainContent_ddlorden').val() + "&ALMACEN=" + almacen + "&ARTICULO1=" + $('#MainContent_txtcodigo').val() + "&ARTICULO2=" + $('#MainContent_txtcodigofin').val() + " &DATO=" + dato + " &MONEDA=" + moneda + " &indicador=" + "TMAF", '_blank');
        }
        if ($('#MainContent_ddlorden').val() == "39") {
            var periodo = "";
            var almacen = "";
            var moneda = $("#MainContent_ddlmoneda").val();
            var mes = $("#MainContent_ddlmes").val();
            var anio = $('#MainContent_txtannio').val();
            periodo = anio + mes;
            almacen = $('#MainContent_ddlalmacen').val();
            window.open("../ALMACEN/REPORTES/stocvalorizado/SVALMACEN.aspx?PERIODO= " + periodo + "&CODIGO=" + $('#MainContent_ddlorden').val() + "&ALMACEN=" + almacen + "&ARTICULO1=" + $('#MainContent_txtcodigo').val() + "&ARTICULO2=" + $('#MainContent_txtcodigofin').val() + " &DATO=" + dato + " &MONEDA=" + moneda + " &indicador=" + "TMOF", '_blank');
        }
        if ($('#MainContent_ddlorden').val() == "07") {
            var periodo = "";
            var almacen = "";
            var moneda = $("#MainContent_ddlmoneda").val();
            var mes = $("#MainContent_ddlmes").val();
            var anio = $('#MainContent_txtannio').val();
            periodo = anio + mes;
            almacen = $('#MainContent_ddlalmacen').val();
            window.open("../ALMACEN/REPORTES/stocvalorizado/SVALMACEN.aspx?PERIODO= " + periodo + "&CODIGO=" + $('#MainContent_ddlorden').val() + "&ALMACEN=" + almacen + "&ARTICULO1=" + $('#MainContent_txtcodigo').val() + "&ARTICULO2=" + $('#MainContent_txtcodigofin').val() + " &DATO=" + dato + " &MONEDA=" + moneda + " &indicador=" + "TCF", '_blank');
        }
       }

     
                //detallado item x item
     if (      (document.getElementById("<%=chktodoalmacen.ClientID%>").checked == true) &&
                (document.getElementById("<%=rbdetallado.ClientID%>").checked == true)&&
                (document.getElementById("<%=rbresumen.ClientID%>").checked == false)) {

        if ($('#MainContent_ddlorden').val() == "A") {
            var periodo = "";
            var articulo = "";
            var moneda = $("#MainContent_ddlmoneda").val();
            var mes = $("#MainContent_ddlmes").val();
            var anio = $('#MainContent_txtannio').val();
             var dato = $('#MainContent_txtcodigo').val();
                    periodo = anio + mes;
                    window.open("../ALMACEN/REPORTES/stocvalorizado/SVDETALLADO.aspx?PERIODO= " + periodo + "&CODIGO=" + $('#MainContent_ddlorden').val() +  "&ARTICULO1=" + $('#MainContent_txtcodigo').val() + "&ARTICULO2=" + $('#MainContent_txtcodigofin').val() + "&MONEDA=" + moneda + " &indicador=" + "TAD", '_blank');
               }
        if ($('#MainContent_ddlorden').val() == "06") {
            var periodo = "";
            var articulo = "";
            var moneda = $("#MainContent_ddlmoneda").val();
            var mes = $("#MainContent_ddlmes").val();
            var anio = $('#MainContent_txtannio').val();
            var dato = $('#MainContent_txtcodigo').val();
            periodo = anio + mes;
            window.open("../ALMACEN/REPORTES/stocvalorizado/SVDETALLADO.aspx?PERIODO= " + periodo + "&CODIGO=" + $('#MainContent_ddlorden').val() +  "&ARTICULO1=" + $('#MainContent_txtcodigo').val() + "&ARTICULO2=" + $('#MainContent_txtcodigofin').val() + "&MONEDA=" + moneda + " &indicador=" + "TGD", '_blank');
        }
        if ($('#MainContent_ddlorden').val() == "38") {
            var periodo = "";
            var articulo = "";
            var moneda = $("#MainContent_ddlmoneda").val();
            var mes = $("#MainContent_ddlmes").val();
            var anio = $('#MainContent_txtannio').val();
            var dato = $('#MainContent_txtcodigo').val();
            periodo = anio + mes;
            window.open("../ALMACEN/REPORTES/stocvalorizado/SVDETALLADO.aspx?PERIODO= " + periodo + "&CODIGO=" + $('#MainContent_ddlorden').val() +  "&ARTICULO1=" + $('#MainContent_txtcodigo').val() + "&ARTICULO2=" + $('#MainContent_txtcodigofin').val()  +"&MONEDA=" + moneda + " &indicador=" + "TFD", '_blank');
        }
        if ($('#MainContent_ddlorden').val() == "V7") {
            var periodo = "";
            var articulo = "";
            var moneda = $("#MainContent_ddlmoneda").val();
            var mes = $("#MainContent_ddlmes").val();
            var anio = $('#MainContent_txtannio').val();
            var dato = $('#MainContent_txtcodigo').val();
            periodo = anio + mes;
            window.open("../ALMACEN/REPORTES/stocvalorizado/SVDETALLADO.aspx?PERIODO= " + periodo + "&CODIGO=" + $('#MainContent_ddlorden').val() + "&ARTICULO1=" + $('#MainContent_txtcodigo').val() + "&ARTICULO2=" + $('#MainContent_txtcodigofin').val() + "&MONEDA=" + moneda + " &indicador=" + "TMAD", '_blank');
        }
        if ($('#MainContent_ddlorden').val() == "39") {
            var periodo = "";
            var articulo = "";
            var moneda = $("#MainContent_ddlmoneda").val();
            var mes = $("#MainContent_ddlmes").val();
            var anio = $('#MainContent_txtannio').val();
            var dato = $('#MainContent_txtcodigo').val();
            periodo = anio + mes;
            window.open("../ALMACEN/REPORTES/stocvalorizado/SVDETALLADO.aspx?PERIODO= " + periodo + "&CODIGO=" + $('#MainContent_ddlorden').val() + "&ARTICULO1=" + $('#MainContent_txtcodigo').val() + "&ARTICULO2=" + $('#MainContent_txtcodigofin').val() + "&MONEDA=" + moneda + " &indicador=" + "TMOD", '_blank');
        }
        if ($('#MainContent_ddlorden').val() == "07") {
            var periodo = "";
            var articulo = "";
            var moneda = $("#MainContent_ddlmoneda").val();
            var mes = $("#MainContent_ddlmes").val();
            var anio = $('#MainContent_txtannio').val();
            var dato = $('#MainContent_txtcodigo').val();
            periodo = anio + mes;
            window.open("../ALMACEN/REPORTES/stocvalorizado/SVDETALLADO.aspx?PERIODO= " + periodo + "&CODIGO=" + $('#MainContent_ddlorden').val() + "&ARTICULO1=" + $('#MainContent_txtcodigo').val() + "&ARTICULO2=" + $('#MainContent_txtcodigofin').val() + "&MONEDA=" + moneda + " &indicador=" + "TCD", '_blank');
        }


     }

                // REPORTE RESUMIDO

   if (      (document.getElementById("<%=chktodoalmacen.ClientID%>").checked == true) &&
                (document.getElementById("<%=rbdetallado.ClientID%>").checked == false)&&
                (document.getElementById("<%=rbresumen.ClientID%>").checked == true)) {

        if ($('#MainContent_ddlorden').val() == "A") {
            var periodo = "";
            var articulo = "";
            var moneda = $("#MainContent_ddlmoneda").val();
            var mes = $("#MainContent_ddlmes").val();
            var anio = $('#MainContent_txtannio').val();
             var dato = $('#MainContent_txtcodigo').val();
                    periodo = anio + mes;
                    window.open("../ALMACEN/REPORTES/stocvalorizado/SVRESUMEN.aspx?PERIODO= " + periodo + "&CODIGO=" + $('#MainContent_ddlorden').val() +  "&ARTICULO1=" + $('#MainContent_txtcodigo').val() + "&ARTICULO2=" + $('#MainContent_txtcodigofin').val() + "&MONEDA=" + moneda + " &indicador=" + "TAR", '_blank');
               }
        if ($('#MainContent_ddlorden').val() == "06") {
            var periodo = "";
            var articulo = "";
            var moneda = $("#MainContent_ddlmoneda").val();
            var mes = $("#MainContent_ddlmes").val();
            var anio = $('#MainContent_txtannio').val();
            var dato = $('#MainContent_txtcodigo').val();
            periodo = anio + mes;
            window.open("../ALMACEN/REPORTES/stocvalorizado/SVRESUMEN.aspx?PERIODO= " + periodo + "&CODIGO=" + $('#MainContent_ddlorden').val() + "&ARTICULO1=" + $('#MainContent_txtcodigo').val() + "&ARTICULO2=" + $('#MainContent_txtcodigofin').val() + "&MONEDA=" + moneda + " &indicador=" + "TGR", '_blank');
        }
        if ($('#MainContent_ddlorden').val() == "38") {
            var periodo = "";
            var articulo = "";
            var moneda = $("#MainContent_ddlmoneda").val();
            var mes = $("#MainContent_ddlmes").val();
            var anio = $('#MainContent_txtannio').val();
            var dato = $('#MainContent_txtcodigo').val();
            periodo = anio + mes;
            window.open("../ALMACEN/REPORTES/stocvalorizado/SVRESUMEN.aspx?PERIODO= " + periodo + "&CODIGO=" + $('#MainContent_ddlorden').val() + "&ARTICULO1=" + $('#MainContent_txtcodigo').val() + "&ARTICULO2=" + $('#MainContent_txtcodigofin').val() + "&MONEDA=" + moneda + " &indicador=" + "TFR", '_blank');
        }
        if ($('#MainContent_ddlorden').val() == "V7") {
            var periodo = "";
            var articulo = "";
            var moneda = $("#MainContent_ddlmoneda").val();
            var mes = $("#MainContent_ddlmes").val();
            var anio = $('#MainContent_txtannio').val();
            var dato = $('#MainContent_txtcodigo').val();
            periodo = anio + mes;
            window.open("../ALMACEN/REPORTES/stocvalorizado/SVRESUMEN.aspx?PERIODO= " + periodo + "&CODIGO=" + $('#MainContent_ddlorden').val() + "&ARTICULO1=" + $('#MainContent_txtcodigo').val() + "&ARTICULO2=" + $('#MainContent_txtcodigofin').val() + "&MONEDA=" + moneda + " &indicador=" + "TMAR", '_blank');
        }
        if ($('#MainContent_ddlorden').val() == "39") {
            var periodo = "";
            var articulo = "";
            var moneda = $("#MainContent_ddlmoneda").val();
            var mes = $("#MainContent_ddlmes").val();
            var anio = $('#MainContent_txtannio').val();
            var dato = $('#MainContent_txtcodigo').val();
            periodo = anio + mes;
            window.open("../ALMACEN/REPORTES/stocvalorizado/SVRESUMEN.aspx?PERIODO= " + periodo + "&CODIGO=" + $('#MainContent_ddlorden').val() + "&ARTICULO1=" + $('#MainContent_txtcodigo').val() + "&ARTICULO2=" + $('#MainContent_txtcodigofin').val() + "&MONEDA=" + moneda + " &indicador=" + "TMOR", '_blank');
        }
        if ($('#MainContent_ddlorden').val() == "07") {
            var periodo = "";
            var articulo = "";
            var moneda = $("#MainContent_ddlmoneda").val();
            var mes = $("#MainContent_ddlmes").val();
            var anio = $('#MainContent_txtannio').val();
            var dato = $('#MainContent_txtcodigo').val();
            periodo = anio + mes;
            window.open("../ALMACEN/REPORTES/stocvalorizado/SVRESUMEN.aspx?PERIODO= " + periodo + "&CODIGO=" + $('#MainContent_ddlorden').val() + "&ARTICULO1=" + $('#MainContent_txtcodigo').val() + "&ARTICULO2=" + $('#MainContent_txtcodigofin').val() + "&MONEDA=" + moneda + " &indicador=" + "TCR", '_blank');
        }


     }
            });

            $(".chtodos").click(function () {

                if ($("#MainContent_chktodos").attr("checked") == false) {
                    $("#MainContent_txtcodigo").val("");
                    $("#MainContent_txtcodigo").attr("disabled", false);
                    $("#MainContent_txtdato").val("");
                    $("#MainContent_txtdato").attr("disabled", false);
                }

                else {
                    $("#MainContent_txtcodigo").val("");
                    $("#MainContent_txtcodigo").attr("disabled", true);
                    $("#MainContent_txtdato").val("");
                    $("#MainContent_txtdato").attr("disabled", true);
                }
            });


            $(".chtodoalm").click(function () {

                if ($("#MainContent_chktodoalmacen").attr("checked") == false) {
                   
                    $("#MainContent_ddlalmacen").attr("disabled", false);
                    (document.getElementById("<%=rbresumen.ClientID%>").checked = false);
                    (document.getElementById("<%=rbdetallado.ClientID%>").checked = false);
                    (document.getElementById("<%=rbdetallado.ClientID%>").style.visibility = "hidden");
                     (document.getElementById("<%=rbresumen.ClientID%>").style.visibility = "hidden");
                   
                }

                else {
                    $("#MainContent_ddlalmacen").attr("disabled", true);
                    (document.getElementById("<%=rbresumen.ClientID%>").checked = false);
                    (document.getElementById("<%=rbdetallado.ClientID%>").checked = false);
                    (document.getElementById("<%=rbdetallado.ClientID%>").style.visibility = "visible");
                     (document.getElementById("<%=rbresumen.ClientID%>").style.visibility = "visible");
                }
            });
            $(window).load(function () {
                  (document.getElementById("<%=rbresumen.ClientID%>").checked = false);
                  (document.getElementById("<%=rbdetallado.ClientID%>").checked = false);
                 (document.getElementById("<%=rbdetallado.ClientID%>").style.visibility = "hidden");
                   (document.getElementById("<%=rbresumen.ClientID%>").style.visibility = "hidden");

            });




     $(".EXCEL").click(function () {
                if ( (document.getElementById("<%=chktodoalmacen.ClientID%>").checked == false) &&
                (document.getElementById("<%=rbdetallado.ClientID%>").checked == false)&&
                (document.getElementById("<%=rbresumen.ClientID%>").checked == false)) {

        if ($('#MainContent_ddlorden').val() == "A") {
            var periodo = "";
            var almacen = "";
            var moneda = $("#MainContent_ddlmoneda").val();
            var mes = $("#MainContent_ddlmes").val();
            var anio = $('#MainContent_txtannio').val();
                    periodo = anio + mes;
                    almacen = $('#MainContent_ddlalmacen').val();
                    var almdesc=$('#MainContent_ddlalmacen option:selected').text();
                    window.open("../ALMACEN/REPORTES/stocvalorizado/SVEXCEL.aspx?PERIODO= " + periodo + "&alm= " + almdesc + "&ALMACEN=" + almacen + "&MES=" + mes + "&ANNIO=" + anio + "&ARTICULO1=" + $('#MainContent_txtcodigo').val() + "&ARTICULO2=" + $('#MainContent_txtcodigofin').val() + " &MONEDA=" + moneda + " &indicador=" + "TAF", '_blank');
               }
        if ($('#MainContent_ddlorden').val() == "06") {
            var periodo = "";
            var almacen = "";
            var moneda = $("#MainContent_ddlmoneda").val();
            var mes = $("#MainContent_ddlmes").val();
            var anio = $('#MainContent_txtannio').val();
            periodo = anio + mes;
            almacen = $('#MainContent_ddlalmacen').val();
            var almdesc = $('#MainContent_ddlalmacen option:selected').text();
            window.open("../ALMACEN/REPORTES/stocvalorizado/SVEXCEL.aspx?PERIODO= " + periodo + "&alm= " + almdesc + "&MES=" + mes + "&ANNIO=" + anio + "&CODIGO=" + $('#MainContent_ddlorden').val() + "&ALMACEN=" + almacen + "&ARTICULO1=" + $('#MainContent_txtcodigo').val() + "&ARTICULO2=" + $('#MainContent_txtcodigofin').val() + " &MONEDA=" + moneda + " &indicador=" + "TG", '_blank');
        }
        if ($('#MainContent_ddlorden').val() == "38") {
            var periodo = "";
            var almacen = "";
            var moneda = $("#MainContent_ddlmoneda").val();
            var mes = $("#MainContent_ddlmes").val();
            var anio = $('#MainContent_txtannio').val();
            periodo = anio + mes;
            almacen = $('#MainContent_ddlalmacen').val();
            var almdesc = $('#MainContent_ddlalmacen option:selected').text();
            window.open("../ALMACEN/REPORTES/stocvalorizado/SVEXCEL.aspx?PERIODO= " + periodo + "&alm= "+ almdesc + "&MES=" + mes + "&ANNIO=" + anio + "&CODIGO=" + $('#MainContent_ddlorden').val() + "&ALMACEN=" + almacen + "&ARTICULO1=" + $('#MainContent_txtcodigo').val() + "&ARTICULO2=" + $('#MainContent_txtcodigofin').val() + " &MONEDA=" + moneda + " &indicador=" + "TF", '_blank');
        }
        if ($('#MainContent_ddlorden').val() == "V7") {
            var periodo = "";
            var almacen = "";
            var moneda = $("#MainContent_ddlmoneda").val();
            var mes = $("#MainContent_ddlmes").val();
            var anio = $('#MainContent_txtannio').val();
            periodo = anio + mes;
            almacen = $('#MainContent_ddlalmacen').val();
            var almdesc = $('#MainContent_ddlalmacen option:selected').text();
            window.open("../ALMACEN/REPORTES/stocvalorizado/SVEXCEL.aspx?PERIODO= " + periodo + "&alm= " + almdesc + "&MES=" + mes + "&ANNIO=" + anio + "&CODIGO=" + $('#MainContent_ddlorden').val() + "&ALMACEN=" + almacen + "&ARTICULO1=" + $('#MainContent_txtcodigo').val() + "&ARTICULO2=" + $('#MainContent_txtcodigofin').val() + " &MONEDA=" + moneda + " &indicador=" + "TM", '_blank');
        }
        if ($('#MainContent_ddlorden').val() == "39") {
            var periodo = "";
            var almacen = "";
            var moneda = $("#MainContent_ddlmoneda").val();
            var mes = $("#MainContent_ddlmes").val();
            var anio = $('#MainContent_txtannio').val();
            periodo = anio + mes;
            almacen = $('#MainContent_ddlalmacen').val();
            var almdesc = $('#MainContent_ddlalmacen option:selected').text();
            window.open("../ALMACEN/REPORTES/stocvalorizado/SVEXCEL.aspx?PERIODO= " + periodo + "&alm= " + almdesc + "&MES=" + mes + "&ANNIO=" + anio + "&CODIGO=" + $('#MainContent_ddlorden').val() + "&ALMACEN=" + almacen + "&ARTICULO1=" + $('#MainContent_txtcodigo').val() + "&ARTICULO2=" + $('#MainContent_txtcodigofin').val() + " &MONEDA=" + moneda + " &indicador=" + "TMO", '_blank');
        }
        if ($('#MainContent_ddlorden').val() == "07") {
            var periodo = "";
            var almacen = "";
            var moneda = $("#MainContent_ddlmoneda").val();
            var mes = $("#MainContent_ddlmes").val();
            var anio = $('#MainContent_txtannio').val();
            periodo = anio + mes;
            almacen = $('#MainContent_ddlalmacen').val();
            var almdesc = $('#MainContent_ddlalmacen option:selected').text();
            window.open("../ALMACEN/REPORTES/stocvalorizado/SVEXCEL.aspx?PERIODO= " + periodo + "&alm= " + almdesc + "&MES=" + mes + "&ANNIO=" + anio + "&CODIGO=" + $('#MainContent_ddlorden').val() + "&ALMACEN=" + almacen + "&ARTICULO1=" + $('#MainContent_txtcodigo').val() + "&ARTICULO2=" + $('#MainContent_txtcodigofin').val() + " &MONEDA=" + moneda + " &indicador=" + "TC", '_blank');
        }
       }

     
           //detallado item x item
     if (      (document.getElementById("<%=chktodoalmacen.ClientID%>").checked == true) &&
                (document.getElementById("<%=rbdetallado.ClientID%>").checked == true)&&
                (document.getElementById("<%=rbresumen.ClientID%>").checked == false)) {
         if ($('#MainContent_ddlorden').val() == "A") {
             var periodo = "";
             var almacen = "";
             var moneda = $("#MainContent_ddlmoneda").val();
             var mes = $("#MainContent_ddlmes").val();
             var anio = $('#MainContent_txtannio').val();
             periodo = anio + mes;
             almacen = $('#MainContent_ddlalmacen').val();
             window.open("../ALMACEN/REPORTES/stocvalorizado/SVEXCELDETALLADO.aspx?PERIODO= " + periodo + "&MES=" + mes + "&ANNIO=" + anio + "&ARTICULO1=" + $('#MainContent_txtcodigo').val() + "&ARTICULO2=" + $('#MainContent_txtcodigofin').val() + " &MONEDA=" + moneda + " &indicador=" + "PA", '_blank');
         }
         if ($('#MainContent_ddlorden').val() == "06") {
             var periodo = "";
             var almacen = "";
             var moneda = $("#MainContent_ddlmoneda").val();
             var mes = $("#MainContent_ddlmes").val();
             var anio = $('#MainContent_txtannio').val();
             periodo = anio + mes;
             almacen = $('#MainContent_ddlalmacen').val();
             window.open("../ALMACEN/REPORTES/stocvalorizado/SVEXCELDETALLADO.aspx?PERIODO= " + periodo + "&MES=" + mes + "&ANNIO=" + anio + "&CODIGO=" + $('#MainContent_ddlorden').val() + "&ARTICULO1=" + $('#MainContent_txtcodigo').val() + "&ARTICULO2=" + $('#MainContent_txtcodigofin').val() + " &MONEDA=" + moneda + " &indicador=" + "TG", '_blank');
         }
         if ($('#MainContent_ddlorden').val() == "38") {
             var periodo = "";
             var almacen = "";
             var moneda = $("#MainContent_ddlmoneda").val();
             var mes = $("#MainContent_ddlmes").val();
             var anio = $('#MainContent_txtannio').val();
             periodo = anio + mes;
             almacen = $('#MainContent_ddlalmacen').val();
             window.open("../ALMACEN/REPORTES/stocvalorizado/SVEXCELDETALLADO.aspx?PERIODO= " + periodo + "&MES=" + mes + "&ANNIO=" + anio + "&CODIGO=" + $('#MainContent_ddlorden').val() + "&ARTICULO1=" + $('#MainContent_txtcodigo').val() + "&ARTICULO2=" + $('#MainContent_txtcodigofin').val() + " &MONEDA=" + moneda + " &indicador=" + "TF", '_blank');
         }
         if ($('#MainContent_ddlorden').val() == "V7") {
             var periodo = "";
             var almacen = "";
             var moneda = $("#MainContent_ddlmoneda").val();
             var mes = $("#MainContent_ddlmes").val();
             var anio = $('#MainContent_txtannio').val();
             periodo = anio + mes;
             almacen = $('#MainContent_ddlalmacen').val();
             window.open("../ALMACEN/REPORTES/stocvalorizado/SVEXCELDETALLADO.aspx?PERIODO= " + periodo + "&MES=" + mes + "&ANNIO=" + anio + "&CODIGO=" + $('#MainContent_ddlorden').val() + "&ARTICULO1=" + $('#MainContent_txtcodigo').val() + "&ARTICULO2=" + $('#MainContent_txtcodigofin').val() + " &MONEDA=" + moneda + " &indicador=" + "TM", '_blank');
         }
         if ($('#MainContent_ddlorden').val() == "39") {
             var periodo = "";
             var almacen = "";
             var moneda = $("#MainContent_ddlmoneda").val();
             var mes = $("#MainContent_ddlmes").val();
             var anio = $('#MainContent_txtannio').val();
             periodo = anio + mes;
             almacen = $('#MainContent_ddlalmacen').val();
             window.open("../ALMACEN/REPORTES/stocvalorizado/SVEXCELDETALLADO.aspx?PERIODO= " + periodo + "&MES=" + mes + "&ANNIO=" + anio + "&CODIGO=" + $('#MainContent_ddlorden').val() + "&ARTICULO1=" + $('#MainContent_txtcodigo').val() + "&ARTICULO2=" + $('#MainContent_txtcodigofin').val() + " &MONEDA=" + moneda + " &indicador=" + "TMO", '_blank');
         }
         if ($('#MainContent_ddlorden').val() == "07") {
             var periodo = "";
             var almacen = "";
             var moneda = $("#MainContent_ddlmoneda").val();
             var mes = $("#MainContent_ddlmes").val();
             var anio = $('#MainContent_txtannio').val();
             periodo = anio + mes;
             almacen = $('#MainContent_ddlalmacen').val();
             window.open("../ALMACEN/REPORTES/stocvalorizado/SVEXCELDETALLADO.aspx?PERIODO= " + periodo + "&MES=" + mes + "&ANNIO=" + anio + "&CODIGO=" + $('#MainContent_ddlorden').val() +  "&ARTICULO1=" + $('#MainContent_txtcodigo').val() + "&ARTICULO2=" + $('#MainContent_txtcodigofin').val() + " &MONEDA=" + moneda + " &indicador=" + "TC", '_blank');
         }
     }

                // REPORTE RESUMIDO

       if (      (document.getElementById("<%=chktodoalmacen.ClientID%>").checked == true) &&
                (document.getElementById("<%=rbdetallado.ClientID%>").checked == false)&&
                (document.getElementById("<%=rbresumen.ClientID%>").checked == true)) {

        if ($('#MainContent_ddlorden').val() == "A") {
            var periodo = "";
            var articulo = "";
            var moneda = $("#MainContent_ddlmoneda").val();
            var mes = $("#MainContent_ddlmes").val();
            var anio = $('#MainContent_txtannio').val();
             var dato = $('#MainContent_txtcodigo').val();
                    periodo = anio + mes;
                    window.open("../ALMACEN/REPORTES/stocvalorizado/SVEXCELRESUMIDO.aspx?PERIODO= " + periodo + "&MES=" + mes + "&ANNIO=" + anio + "&CODIGO=" + $('#MainContent_ddlorden').val() + "&ARTICULO1=" + $('#MainContent_txtcodigo').val() + "&ARTICULO2=" + $('#MainContent_txtcodigofin').val() + "&MONEDA=" + moneda + " &indicador=" + "TAR", '_blank');
               }
        if ($('#MainContent_ddlorden').val() == "06") {
            var periodo = "";
            var articulo = "";
            var moneda = $("#MainContent_ddlmoneda").val();
            var mes = $("#MainContent_ddlmes").val();
            var anio = $('#MainContent_txtannio').val();
            var dato = $('#MainContent_txtcodigo').val();
            periodo = anio + mes;
            window.open("../ALMACEN/REPORTES/stocvalorizado/SVEXCELRESUMIDO.aspx?PERIODO= " + periodo + "&MES=" + mes + "&ANNIO=" + anio + "&CODIGO=" + $('#MainContent_ddlorden').val() + "&ARTICULO1=" + $('#MainContent_txtcodigo').val() + "&ARTICULO2=" + $('#MainContent_txtcodigofin').val() + "&MONEDA=" + moneda + " &indicador=" + "TGR", '_blank');
        }
        if ($('#MainContent_ddlorden').val() == "38") {
            var periodo = "";
            var articulo = "";
            var moneda = $("#MainContent_ddlmoneda").val();
            var mes = $("#MainContent_ddlmes").val();
            var anio = $('#MainContent_txtannio').val();
            var dato = $('#MainContent_txtcodigo').val();
            periodo = anio + mes;
            window.open("../ALMACEN/REPORTES/stocvalorizado/SVEXCELRESUMIDO.aspx?PERIODO= " + periodo + "&MES=" + mes + "&ANNIO=" + anio + "&CODIGO=" + $('#MainContent_ddlorden').val() + "&ARTICULO1=" + $('#MainContent_txtcodigo').val() + "&ARTICULO2=" + $('#MainContent_txtcodigofin').val() + "&MONEDA=" + moneda + " &indicador=" + "TFR", '_blank');
        }
        if ($('#MainContent_ddlorden').val() == "V7") {
            var periodo = "";
            var articulo = "";
            var moneda = $("#MainContent_ddlmoneda").val();
            var mes = $("#MainContent_ddlmes").val();
            var anio = $('#MainContent_txtannio').val();
            var dato = $('#MainContent_txtcodigo').val();
            periodo = anio + mes;
            window.open("../ALMACEN/REPORTES/stocvalorizado/SVEXCELRESUMIDO.aspx?PERIODO= " + periodo + "&MES=" + mes + "&ANNIO=" + anio + "&CODIGO=" + $('#MainContent_ddlorden').val() + "&ARTICULO1=" + $('#MainContent_txtcodigo').val() + "&ARTICULO2=" + $('#MainContent_txtcodigofin').val() + "&MONEDA=" + moneda + " &indicador=" + "TMAR", '_blank');
        }
        if ($('#MainContent_ddlorden').val() == "39") {
            var periodo = "";
            var articulo = "";
            var moneda = $("#MainContent_ddlmoneda").val();
            var mes = $("#MainContent_ddlmes").val();
            var anio = $('#MainContent_txtannio').val();
            var dato = $('#MainContent_txtcodigo').val();
            periodo = anio + mes;
            window.open("../ALMACEN/REPORTES/stocvalorizado/SVEXCELRESUMIDO.aspx?PERIODO= " + periodo + "&MES=" + mes + "&ANNIO=" + anio + "&CODIGO=" + $('#MainContent_ddlorden').val() + "&ARTICULO1=" + $('#MainContent_txtcodigo').val() + "&ARTICULO2=" + $('#MainContent_txtcodigofin').val() + "&MONEDA=" + moneda + " &indicador=" + "TMOR", '_blank');
        }
        if ($('#MainContent_ddlorden').val() == "07") {
            var periodo = "";
            var articulo = "";
            var moneda = $("#MainContent_ddlmoneda").val();
            var mes = $("#MainContent_ddlmes").val();
            var anio = $('#MainContent_txtannio').val();
            var dato = $('#MainContent_txtcodigo').val();
            periodo = anio + mes;
            window.open("../ALMACEN/REPORTES/stocvalorizado/SVEXCELRESUMIDO.aspx?PERIODO= " + periodo + "&MES=" + mes + "&ANNIO=" + anio + "&CODIGO=" + $('#MainContent_ddlorden').val() + "&ARTICULO1=" + $('#MainContent_txtcodigo').val() + "&ARTICULO2=" + $('#MainContent_txtcodigofin').val() + "&MONEDA=" + moneda + " &indicador=" + "TCR", '_blank');
        }


     }
            });







       })
 </script>
     <style type="text/css">
        #btnsalir {
            width: 67px;
        }
        #btngrabar {
            width: 67px;
        }
         .auto-style1 {
             width: 154px;
         }
         .auto-style2 {
             width: 390px;
         }
         .auto-style3 {
             width: 393px;
         }
        </style>
   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <fieldset style="background-color: #99CCFF">
        <legend style="font-weight: bold; background-color: #99CCFF;">
            <asp:Label ID="Label9" runat="server" Text="Reporte de Stock Valorizado" Font-Bold="True" Font-Size="12pt"></asp:Label></legend>

        <table>
            <tr>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Al Mes</td>
                <td class="auto-style3"> <asp:TextBox ID="txtannio" runat="server" Width="101px"></asp:TextBox> <asp:DropDownList ID="ddlmes" runat="server" Height="22px" Width="145px">
                     <asp:ListItem Value="01">01</asp:ListItem>
                     <asp:ListItem Value="02">02</asp:ListItem>
                     <asp:ListItem Value="03">03</asp:ListItem>
                     <asp:ListItem Value="04">04</asp:ListItem>
                     <asp:ListItem Value="05">05</asp:ListItem>
                     <asp:ListItem Value="06">06</asp:ListItem>
                     <asp:ListItem Value="07">07</asp:ListItem>
                     <asp:ListItem Value="08">08</asp:ListItem>
                     <asp:ListItem Value="09">09</asp:ListItem>
                     <asp:ListItem Value="10">10</asp:ListItem>
                     <asp:ListItem Value="11">11</asp:ListItem>
                     <asp:ListItem Value="12">12</asp:ListItem>
                     </asp:DropDownList> </td>
                
            </tr>
            <tr>
                <td> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Codigo Almacén</td>
                <td class="auto-style3"> <asp:DropDownList ID="ddlalmacen" runat="server" Height="23px" Width="247px"></asp:DropDownList> 
                    <asp:CheckBox ID="chktodoalmacen" runat="server" Text="Todos almacen" class="chtodoalm"/>
                </td>

            </tr>
            <tr>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Listar Por&nbsp;</td>
                 <td class="auto-style3"> <asp:DropDownList ID="ddlorden" runat="server" Height="16px" Width="248px">
                     <asp:ListItem Value="A">ARTÍCULO</asp:ListItem>
                     <asp:ListItem Value="38">FAMILIA</asp:ListItem>
                     <asp:ListItem Value="06">GRUPO</asp:ListItem>
                     <asp:ListItem Value="V7">MARCA</asp:ListItem>
                     <asp:ListItem Value="39">MODELO</asp:ListItem>
                     <asp:ListItem Value="07">CUENTA</asp:ListItem>
                     </asp:DropDownList>  
                </td>
            </tr>
            
            <tr> 
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Código Inicio&nbsp;</td>
                 <TD class="auto-style3"> <asp:TextBox ID="txtdato" runat="server" Width="395px"></asp:TextBox> 
                     <br />
                     <asp:TextBox ID="txtcodigo" runat="server" Width="396px"></asp:TextBox> 
                     </TD>
                </tr>
            <tr>
                <td> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Código fin</td> <td><asp:TextBox ID="txtdato1" runat="server" Width="395px"></asp:TextBox> 
                     <br />
                     <asp:TextBox ID="txtcodigofin" runat="server" Width="395px"></asp:TextBox> 
           </td>

            </tr>


          <tr>
              <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Moneda</td>
              <td class="auto-style3">
                  <asp:DropDownList ID="ddlmoneda" runat="server" Height="16px" Width="252px"></asp:DropDownList></td>
          </tr>
        </table>
        <table>
            <tr>
            <td class="auto-style1">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                Opciones 
            </td>
                <td class="auto-style2">
                    <input id="rbdetallado" type="radio" runat="server"/> Detallado<br />
                    <input id="rbresumen" type="radio" runat="server"/> Resumido
                    
                </td>
            </tr>
           
        </table>

        <table>
            <tr>
                <td>
                    <input id="Button1" type="button" value="IMPRIMIR"  class="IMPRIMIR"/></td>
                <td>
                    <input id="Button2" type="button" value="EXCEL" class="EXCEL" />
                </td>

            </tr>

        </table>
       
    </fieldset>


   

</asp:Content>
