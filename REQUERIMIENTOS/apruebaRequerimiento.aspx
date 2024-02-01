<%@ Page Title="Logística" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="apruebaRequerimiento.aspx.cs" Inherits="apruebaRequerimiento" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link type="text/css" href="../CSS/base.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {
            var uus = $("#HeadLoginView_HeadLoginName").html();
            $("#MainContent_hfusuario").val(uus);
            $("#MainContent_TextBox1").datepicker();
            $("#MainContent_TextBox2").datepicker();

        });
        function soloNumeros() {
            $(".numeric").numeric();
        }


        $(function () {

            $(".aprobar").click(function () {
            

                numero = $("#MainContent_lblnumero").html();
                estado = $("#MainContent_txtestado").val();
                usu01 = $("#MainContent_lblusu01").html();
                usu02 = $("#MainContent_lblusu02").html();
                usu03 = $("#MainContent_lblusu03").html();
                usu04 = $("#MainContent_hfusuario").text();
                //usu01 = $("td:eq(1)", trp).val();
                //usu02 = $("td:eq(2)", trp).val();
                //usu03 = $("td:eq(3)", trp).val();

                if (estado == "EMITIDO") {

                                  aprobarCab();
                    if (usu01.trim() != "" && usu02.trim() != "")
                        aprobarDet();
                   
                    if ($("td:eq(8)", trp).html() == "     ") {
                        $("td:eq(8)", trp).html($("#MainContent_hfusuario").text());
                        $("td:eq(1)", trp).val($("#MainContent_hfusuario").text())
                        $("td:eq(3)", trp).html("EMITIDO");
                    }
                    else {

                        if ($("td:eq(9)", trp).html() == "     ") {
                            $("td:eq(9)", trp).html($("#MainContent_hfusuario").text());
                            $("td:eq(2)", trp).val($("#MainContent_hfusuario").text())
                            $("td:eq(3)", trp).html("EMITIDO");
                        }
                        else {
                            if ($("td:eq(10)", trp).html() == "     ") {
                                var f = new Date();
                                if(f.getDate()<10){
                                    var dia ="0"+ f.getDate();
                                }
                                else { var dia = f.getDate(); }

                                if ((f.getMonth() + 1) < 10) {
                                    var mes = "0" + (f.getMonth() + 1);
                                }
                                else { var mes = (f.getMonth() + 1); }
                                                             
                                var annio = f.getFullYear();

                                $("td:eq(3)", trp).html("APROBADO");
                                $("td:eq(4)", trp).html("TOTAL");
                                $("td:eq(10)", trp).html($("#MainContent_hfusuario").text());
                                $("td:eq(3)", trp).val($("#MainContent_hfusuario").text())
                                $("td:eq(5)", trp).html(dia+"/"+mes+"/"+annio);
                              }


                        }
                    }

                    $('#EstadoPedido').dialog('close');
                } else {
                    alert("El estado debe ser Emitido");
                }
              
            });

            $(".btnBuscar").click(function () {

                filtarcgrid();
            });

            $(".imprimi").click(function () {

                var idnumor = $('#MainContent_lblnumero').html();

                if (idnumor != "&nbsp;") {
                    window.open("../REQUERIMIENTOS/reportes/CR_IMPREQUER.aspx?ID= " + idnumor, '_blank');
                } else {
                    alert("Error en envio de Datos");
                }
            });

            $(".desaprobar").click(function () {
               // trp = $(this).parent().parent();
                numero = $("#MainContent_lblnumero").html();;
                estado = $("#MainContent_txtestado").val();

                if (estado == "APROBADO") {

                    desaprobarCab();
                    desaprobarDet();
                    $("td:eq(4)", trp).html("     ");
                    $("td:eq(5)", trp).html("     ");
                    $("td:eq(8)", trp).html("     ");
                    $("td:eq(9)", trp).html("     ");
                    $("td:eq(10)", trp).html("     ");

                    $("td:eq(1)", trp).val("     ");
                    $("td:eq(2)", trp).val("     ");
                    $("td:eq(3)", trp).val("     ");
                    $("td:eq(10)", trp).val("1");
                    $("td:eq(3)", trp).html("EMITIDO");
                 
                    $('#EstadoPedido').dialog('close');
                }
                else {
                    alert("El estado debe ser Aprobado");
                }

            });

            $(".ver").click(function () {

                $('#EstadoPedido').dialog('open');

                trp = $(this).parent().parent();
                numero = $("td:eq(0)", trp).html();
                fecha = $("td:eq(1)", trp).html();
                usu01 = $("td:eq(1)", trp).val();
                usu02 = $("td:eq(2)", trp).val();
                usu03 = $("td:eq(3)", trp).val();
                estado = $("td:eq(3)", trp).html();

                solicitante = $("td:eq(7)", trp).html();
                costo = $("td:eq(4)", trp).val();
                proveedor = $("td:eq(2)", trp).html();

                uso = $("td:eq(5)", trp).val();
                prioridad = $("td:eq(6)", trp).val();

                fecha01 = $("td:eq(7)", trp).val();
                fecha02 = $("td:eq(8)", trp).val();
                fecha03 = $("td:eq(5)", trp).html();

                $("#MainContent_lblnumero").text(numero);
                $("#MainContent_lblfecha").text(fecha);
                $("#MainContent_lblsolicitante").text(solicitante);
                $("#MainContent_lblcosto").text(costo);
                $("#MainContent_lblproveedor").text(proveedor);

                $("#MainContent_lbluso").text(uso);
                $("#MainContent_lblprioridad").text(prioridad);

                $("#MainContent_lblusu01").text(usu01);
                $("#MainContent_lblusu02").text(usu02);
                $("#MainContent_lblusu03").text(usu03);

                $("#MainContent_lblfecha01").text(fecha01);
                $("#MainContent_lblfecha02").text(fecha02);
                $("#MainContent_lblfecha03").text(fecha03);
                $("#MainContent_txtestado").val(estado);

                filtarcantidademb(numero);


               

            });


       

        $(window).load(function () {
            filtarcgridinicio();
        });

        function aprobarCab() {
            var REQ = {};
            REQ.RC_CNROREQ = numero;
            REQ.RC_CUSEA01 = usu01;
            REQ.RC_CUSEA02 = usu02;
            REQ.RC_CUSEA03 = usu03;
            REQ.RC_CUSUCRE = usu04;

            $.ajax({

                type: "POST",
                url: "apruebaRequerimiento.aspx/aprobarCab",
                data: '{REQ: ' + JSON.stringify(REQ) + '}',
                contentType: "application/json; charset=utf-8",
                async: false,
                dataType: "json",
                success: function (data) {

                    if (data.d.length > 0) {
                        var row = $("[id*=gvdetalle] tr:last-child").clone(true);
                        $("[id*=gvdetalle] tr").not($("[id*=gvdetalle] tr:first-child")).remove();

                        for (var i = 0; i < data.d.length; i++) {

                            $("td", row).eq(0).html(data.d[i].RD_CITEM);
                            $("td", row).eq(1).html(data.d[i].RD_CCODIGO);
                            $("td", row).eq(2).html(data.d[i].RD_CDESCRI);
                            $("td", row).eq(3).html(data.d[i].RD_CUNID);
                            $("td", row).eq(4).html(data.d[i].RD_NQPEDI.toFixed(2));
                            $("td", row).eq(5).html(data.d[i].RD_COBS);


                            $("[id*=gvdetalle]").append(row);
                            row = $("[id*=gvdetalle] tr:last-child").clone(true);

                        }
                    } else {
                        var row = $("[id*=gvdetalle] tr:last-child").clone(true);
                        $("[id*=gvdetalle] tr").not($("[id*=gvdetalle] tr:first-child")).remove();

                        $("td", row).eq(0).html("");
                        $("td", row).eq(1).html("");
                        $("td", row).eq(2).html("");
                        $("td", row).eq(3).html("");
                        $("td", row).eq(4).html("");
                        $("td", row).eq(5).html("");


                        $("[id*=gvdetalle]").append(row);
                        //alert("no se encontro registro");
                    }


                },
                error: function (response) {
                    if (response.length != 0)
                        alert(response);
                }
            });

        }

        function aprobarDet() {
            var REQ = {};
            REQ.RD_CNROREQ = numero;
            REQ.RD_CSITUA = "7";

            $.ajax({

                type: "POST",
                url: "apruebaRequerimiento.aspx/aprobarDet",
                data: '{REQ: ' + JSON.stringify(REQ) + '}',
                contentType: "application/json; charset=utf-8",
                async: false,

                dataType: "json",
                success: function (data) {

                    if (data.d.length > 0) {
                        var row = $("[id*=gvdetalle] tr:last-child").clone(true);
                        $("[id*=gvdetalle] tr").not($("[id*=gvdetalle] tr:first-child")).remove();

                        for (var i = 0; i < data.d.length; i++) {

                            $("td", row).eq(0).html(data.d[i].RD_CITEM);
                            $("td", row).eq(1).html(data.d[i].RD_CCODIGO);
                            $("td", row).eq(2).html(data.d[i].RD_CDESCRI);
                            $("td", row).eq(3).html(data.d[i].RD_CUNID);
                            $("td", row).eq(4).html(data.d[i].RD_NQPEDI);
                            $("td", row).eq(5).html(data.d[i].RD_COBS);


                            $("[id*=gvdetalle]").append(row);
                            row = $("[id*=gvdetalle] tr:last-child").clone(true);

                        }
                    } else {
                        var row = $("[id*=gvdetalle] tr:last-child").clone(true);
                        $("[id*=gvdetalle] tr").not($("[id*=gvdetalle] tr:first-child")).remove();

                        $("td", row).eq(0).html("");
                        $("td", row).eq(1).html("");
                        $("td", row).eq(2).html("");
                        $("td", row).eq(3).html("");
                        $("td", row).eq(4).html("");
                        $("td", row).eq(5).html("");


                        $("[id*=gvdetalle]").append(row);
                        //alert("no se encontro registro");
                    }


                },
                error: function (response) {
                    if (response.length != 0)
                        alert(response);
                }
            });

        }

        function desaprobarCab() {
            var REQ = {};
            REQ.RC_CNROREQ = numero;
            REQ.RC_CESTADO = "1";
            REQ.RC_CTIPAPR = "";
            REQ.RC_CUSEA01 = "";
            REQ.RC_CUSEA02 = "";
            REQ.RC_CUSEA03 = "";
            REQ.RC_DFECA01 = null;
            REQ.RC_DFECA02 = null;
            REQ.RC_DFECA03 = null;

            $.ajax({

                type: "POST",
                url: "apruebaRequerimiento.aspx/desaprobarCab",
                data: '{REQ: ' + JSON.stringify(REQ) + '}',
                contentType: "application/json; charset=utf-8",
                async: false,

                dataType: "json",
                success: function (data) {

                    if (data.d.length > 0) {
                        var row = $("[id*=gvdetalle] tr:last-child").clone(true);
                        $("[id*=gvdetalle] tr").not($("[id*=gvdetalle] tr:first-child")).remove();

                        for (var i = 0; i < data.d.length; i++) {

                            $("td", row).eq(0).html(data.d[i].RD_CITEM);
                            $("td", row).eq(1).html(data.d[i].RD_CCODIGO);
                            $("td", row).eq(2).html(data.d[i].RD_CDESCRI);
                            $("td", row).eq(3).html(data.d[i].RD_CUNID);
                            $("td", row).eq(4).html(data.d[i].RD_NQPEDI);
                            $("td", row).eq(5).html(data.d[i].RD_COBS);


                            $("[id*=gvdetalle]").append(row);
                            row = $("[id*=gvdetalle] tr:last-child").clone(true);

                        }
                    } else {
                        var row = $("[id*=gvdetalle] tr:last-child").clone(true);
                        $("[id*=gvdetalle] tr").not($("[id*=gvdetalle] tr:first-child")).remove();

                        $("td", row).eq(0).html("");
                        $("td", row).eq(1).html("");
                        $("td", row).eq(2).html("");
                        $("td", row).eq(3).html("");
                        $("td", row).eq(4).html("");
                        $("td", row).eq(5).html("");


                        $("[id*=gvdetalle]").append(row);
                        //alert("no se encontro registro");
                    }


                },
                error: function (response) {
                    if (response.length != 0)
                        alert(response);
                }
            });

        }

        function desaprobarDet() {
            var REQ = {};
            REQ.RD_CNROREQ = numero;
            REQ.RD_CSITUA = "1";


            $.ajax({

                type: "POST",
                url: "apruebaRequerimiento.aspx/desaprobarDet",
                data: '{REQ: ' + JSON.stringify(REQ) + '}',
                contentType: "application/json; charset=utf-8",
                async: false,

                dataType: "json",
                success: function (data) {

                    if (data.d.length > 0) {
                        var row = $("[id*=gvdetalle] tr:last-child").clone(true);
                        $("[id*=gvdetalle] tr").not($("[id*=gvdetalle] tr:first-child")).remove();

                        for (var i = 0; i < data.d.length; i++) {

                            $("td", row).eq(0).html(data.d[i].RD_CITEM);
                            $("td", row).eq(1).html(data.d[i].RD_CCODIGO);
                            $("td", row).eq(2).html(data.d[i].RD_CDESCRI);
                            $("td", row).eq(3).html(data.d[i].RD_CUNID);
                            $("td", row).eq(4).html(data.d[i].RD_NQPEDI);
                            $("td", row).eq(5).html(data.d[i].RD_COBS);


                            $("[id*=gvdetalle]").append(row);
                            row = $("[id*=gvdetalle] tr:last-child").clone(true);

                        }
                    } else {
                        var row = $("[id*=gvdetalle] tr:last-child").clone(true);
                        $("[id*=gvdetalle] tr").not($("[id*=gvdetalle] tr:first-child")).remove();

                        $("td", row).eq(0).html("");
                        $("td", row).eq(1).html("");
                        $("td", row).eq(2).html("");
                        $("td", row).eq(3).html("");
                        $("td", row).eq(4).html("");
                        $("td", row).eq(5).html("");


                        $("[id*=gvdetalle]").append(row);
                        //alert("no se encontro registro");
                    }


                },
                error: function (response) {
                    if (response.length != 0)
                        alert(response);
                }
            });

        }

        function filtarcantidademb(gidpped) {

            rr = gidpped;

            var REQ = {};
            REQ.RD_CNROREQ = rr;

            $.ajax({

                type: "POST",
                url: "apruebaRequerimiento.aspx/ListarReqDetalle",
                data: '{REQ: ' + JSON.stringify(REQ) + '}',
                contentType: "application/json; charset=utf-8",
                async: false,

                dataType: "json",
                success: function (data) {

                    if (data.d.length > 0) {
                        var row = $("[id*=gvdetalle] tr:last-child").clone(true);
                        $("[id*=gvdetalle] tr").not($("[id*=gvdetalle] tr:first-child")).remove();

                        for (var i = 0; i < data.d.length; i++) {

                            $("td", row).eq(0).html(data.d[i].RD_CITEM);
                            $("td", row).eq(1).html(data.d[i].RD_CCODIGO);
                            $("td", row).eq(2).html(data.d[i].RD_CDESCRI);
                            $("td", row).eq(3).html(data.d[i].RD_CUNID);
                            $("td", row).eq(4).html(data.d[i].RD_NQPEDI);
                            $("td", row).eq(5).html(data.d[i].RD_COBS);


                            $("[id*=gvdetalle]").append(row);
                            row = $("[id*=gvdetalle] tr:last-child").clone(true);

                        }
                    } else {
                        var row = $("[id*=gvdetalle] tr:last-child").clone(true);
                        $("[id*=gvdetalle] tr").not($("[id*=gvdetalle] tr:first-child")).remove();

                        $("td", row).eq(0).html("");
                        $("td", row).eq(1).html("");
                        $("td", row).eq(2).html("");
                        $("td", row).eq(3).html("");
                        $("td", row).eq(4).html("");
                        $("td", row).eq(5).html("");


                        $("[id*=gvdetalle]").append(row);
                        //alert("no se encontro registro");
                    }


                },
                error: function (response) {
                    if (response.length != 0)
                        alert(response);
                }
            });

        }
        function filtarcgridinicio() {

            var REQ = {};
            var f = new Date();
            REQ.ANIO = f.getFullYear();
            REQ.MES = "-1";//f.getMonth();
            REQ.RC_CUSUCRE ="-1";
            REQ.RC_CESTADO = "1";
            REQ.USUARIO = $("#MainContent_hfproducto").val();

                var urld = "";
                if ($("#MainContent_lblpermiso").html() == "F ") {
                    urld = "apruebaRequerimiento.aspx/ListarReqIniC";
                }
                else {
                    urld = "apruebaRequerimiento.aspx/ListarReqIni";

                }
            $.ajax({

                type: "POST",
                url: urld,
                data: '{REQ: ' + JSON.stringify(REQ) + '}',
                //data:JSON.stringify(params),
                contentType: "application/json; charset=utf-8",
                //async: false,
                dataType: "json",
                success: function (data) {


                    if (data.d.length > 0) {
                        var row = $("[id*=gvRequerimientos] tr:last-child").clone(true);
                        $("[id*=gvRequerimientos] tr").not($("[id*=gvRequerimientos] tr:first-child")).remove();

                        for (var i = 0; i < data.d.length; i++) {

                            $("td", row).eq(0).html(data.d[i].RC_CNROREQ);
                            $("td", row).eq(1).html(data.d[i].RC_DFECREQ);
                            $("td", row).eq(1).val(data.d[i].RC_CUSEA01);
                            $("td", row).eq(2).html(data.d[i].PROVEEDOR);
                            $("td", row).eq(2).val(data.d[i].RC_CUSEA02);
                            $("td", row).eq(3).html(data.d[i].ESTADO);
                            $("td", row).eq(3).val(data.d[i].RC_CUSEA03);
                            $("td", row).eq(4).html(data.d[i].APROBAC);
                            $("td", row).eq(5).html(data.d[i].RC_DFECA03);
                            $("td", row).eq(6).html(data.d[i].RC_CNUMORD);
                            $("td", row).eq(7).html(data.d[i].USUARIO);
                            $("td", row).eq(8).html(data.d[i].RC_CUSEA01);
                            $("td", row).eq(9).html(data.d[i].RC_CUSEA02);
                            $("td", row).eq(10).html(data.d[i].RC_CUSEA03);

                            $("td", row).eq(4).val(data.d[i].COSTO);

                            $("td", row).eq(5).val(data.d[i].PRIORIDAD);
                            $("td", row).eq(6).val(data.d[i].USO);
                            $("td", row).eq(7).val(data.d[i].RC_DFECA01);
                            $("td", row).eq(8).val(data.d[i].RC_DFECA02);





                            $("[id*=gvRequerimientos]").append(row);
                            row = $("[id*=gvRequerimientos] tr:last-child").clone(true);

                        }
                    } else {
                        var row = $("[id*=gvRequerimientos] tr:last-child").clone(true);
                        $("[id*=gvRequerimientos] tr").not($("[id*=gvRequerimientos] tr:first-child")).remove();

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

                        $("[id*=gvRequerimientos]").append(row);
                        alert("no se encontro registro");
                    }


                },
                error: function (response) {
                    if (response.length != 0)
                        alert(response);
                }
            });

        }




        function filtarcgrid() {

            var REQ = {};
            REQ.ANIO = $("#MainContent_ddlPeriodo option:selected").text();
            REQ.MES = $("#MainContent_ddlmes option:selected").val();
            REQ.RC_CUSUCRE = $("#MainContent_ddlUsuario").val();
            REQ.RC_CESTADO = $("#MainContent_ddlestado").val();
            REQ.USUARIO = $("#MainContent_hfproducto").val();

            alert(JSON.stringify(REQ));

            $.ajax({

                type: "POST",
                url: "apruebaRequerimiento.aspx/ListarReq",
                data: '{REQ: ' + JSON.stringify(REQ) + '}',
                //data:JSON.stringify(params),
                contentType: "application/json; charset=utf-8",
                //async: false,
                dataType: "json",
                success: function (data) {


                    if (data.d.length > 0) {
                        var row = $("[id*=gvRequerimientos] tr:last-child").clone(true);
                        $("[id*=gvRequerimientos] tr").not($("[id*=gvRequerimientos] tr:first-child")).remove();

                        for (var i = 0; i < data.d.length; i++) {

                            $("td", row).eq(0).html(data.d[i].RC_CNROREQ);
                            $("td", row).eq(1).html(data.d[i].RC_DFECREQ);
                            $("td", row).eq(1).val(data.d[i].RC_CUSEA01);
                            $("td", row).eq(2).html(data.d[i].PROVEEDOR);
                            $("td", row).eq(2).val(data.d[i].RC_CUSEA02);
                            $("td", row).eq(3).html(data.d[i].ESTADO);
                            $("td", row).eq(3).val(data.d[i].RC_CUSEA03);
                            $("td", row).eq(4).html(data.d[i].APROBAC);
                            $("td", row).eq(5).html(data.d[i].RC_DFECA03);
                            $("td", row).eq(6).html(data.d[i].RC_CNUMORD);
                            $("td", row).eq(7).html(data.d[i].USUARIO);
                            $("td", row).eq(8).html(data.d[i].RC_CUSEA01);
                            $("td", row).eq(9).html(data.d[i].RC_CUSEA02);
                            $("td", row).eq(10).html(data.d[i].RC_CUSEA03);

                            $("td", row).eq(4).val(data.d[i].COSTO);

                            $("td", row).eq(5).val(data.d[i].PRIORIDAD);
                            $("td", row).eq(6).val(data.d[i].USO);
                            $("td", row).eq(7).val(data.d[i].RC_DFECA01);
                            $("td", row).eq(8).val(data.d[i].RC_DFECA02);





                            $("[id*=gvRequerimientos]").append(row);
                            row = $("[id*=gvRequerimientos] tr:last-child").clone(true);

                        }
                    } else {
                        var row = $("[id*=gvRequerimientos] tr:last-child").clone(true);
                        $("[id*=gvRequerimientos] tr").not($("[id*=gvRequerimientos] tr:first-child")).remove();

                        $("td", row).eq(0).html("");
                        $("td", row).eq(1).html("");
                        $("td", row).eq(2).html("");
                        $("td", row).eq(3).html("");
                        $("td", row).eq(4).html("");
                        $("td", row).eq(5).html("");
                        $("td", row).eq(6).html("");
                        $("td", row).eq(7).html("");

                        $("[id*=gvRequerimientos]").append(row);
                        alert("no se encontro registro");
                    }


                },
                error: function (response) {
                    if (response.length != 0)
                        alert(response);
                }
            });

        }

        $('#EstadoPedido').dialog({
            autoOpen: false,
            modal: true,
            resizable: false,
            width: 900,
            heigth: 280,
            title: 'Requerimiento',
            open: function (event, ui) {

            },
            close: function (event, ui) {

            }

        });

       

     

      


       
            $(".tb").autocomplete(
                {
                    source: function (request, response) {
                        $.ajax({
                            url: "listadoOC.aspx/GetProductos",
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
                    },
                    minLength: 1,
                    select: function (event, ui) {
                        var str = ui.item.id;

                        $('#MainContent_hfproducto').val(str);


                    }
                });




       

      
            $(".tb1").autocomplete(
                {
                    source: function (request, response) {
                        $.ajax({
                            url: "listadoOC.aspx/GetProveedores",
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
                        $('#MainContent_HiddenField1').val(primerApellido);


                    }
                });
        });
    </script>
    <style type="text/css">
        #txtproducto0 {
            width: 337px;
        }
        .auto-style1 {
            width: 685px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:ScriptManager ID="scriptManager" runat="server" EnablePageMethods="true" />
    <table width="100%" cellpadding="5" cellspacing="5" border="0">

        <tr>
            <td>
                <fieldset>
                    <legend >
                        <asp:Label ID="Label9" runat="server" Text="APROBACIÓN DE REQUERIMIENTO" Font-Bold="True" Font-Size="12pt"></asp:Label></legend>

                    <table class="ContainerWrapper" border="0" cellpadding="2" cellspacing="0" style="width:1000px">

                        <tr>
                            <td>

                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" Text="Año:" Font-Bold="True"></asp:Label>


                                            <asp:DropDownList ID="ddlPeriodo" runat="server"></asp:DropDownList>

                                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Label6" runat="server" Text="Mes:" Font-Bold="True"></asp:Label>


                                            <asp:DropDownList ID="ddlmes" runat="server"></asp:DropDownList>

                                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Label7" runat="server" Text="Solicitante:" Font-Bold="True"></asp:Label>


                                            <asp:DropDownList ID="ddlUsuario" runat="server"></asp:DropDownList>

                                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="lblestado" runat="server" Text="Estado:" Font-Bold="True"></asp:Label>


                                            <asp:DropDownList ID="ddlestado" runat="server"></asp:DropDownList>
                                            <br />
                                            <br />
                                            <asp:Label ID="Label15" runat="server" Text="Producto:" Font-Bold="True"></asp:Label>

                                            <asp:TextBox ID="txtproducto" class="tb" runat="server" Width="350px"></asp:TextBox>
                                            <asp:Label ID="lblusuario" runat="server" ForeColor="#DAEFFA"></asp:Label>
                    <asp:Label ID="lblpermiso" runat="server" ForeColor="#DAEFFA"></asp:Label>
                                            <asp:HiddenField ID="hfproducto" runat="server" />
                                            

                                            <hr />
                                            <input type="button" id="btb" class="btnBuscar btn" runat="server" value="Buscar" />
                                            <%--<asp:ImageButton ID="imbeliminar" runat="server" ImageUrl="~/Images/Message_Error.png" Width="25px" OnClick="ib_eliminar_Click" onclientclick="javascript:return confirm('Esta Seguro?')"/>--%>&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="btnExel" class="btn" runat="server" Text="Exel" OnClick="btnExel_Click" />



                                            <div style="display: none">
                                                <asp:Label ID="hfusuario" runat="server" Text="Label"></asp:Label>
                                            </div>

                                        </td>

                                    </tr>



                                </table>




                            </td>
                        </tr>







                    </table>
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="gvRequerimientos" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField DataField="RC_CNROREQ" HeaderText="REQUISICION" />
                                        <asp:BoundField DataField="RC_DFECREQ" HeaderText="FECHA" />
                                        <asp:BoundField DataField="PROVEEDOR" HeaderText="PROVEEDOR" />
                                        <asp:BoundField DataField="ESTADO" HeaderText="ESTADO" />
                                        <asp:BoundField DataField="APROBAC" HeaderText="APROBAC" />
                                        <asp:BoundField DataField="RC_DFECA03" HeaderText="FECHA.APROB" />
                                        <asp:BoundField DataField="RC_CNUMORD" HeaderText="NRO.ORDEN" />
                                        <asp:BoundField DataField="USUARIO" HeaderText="USUARIO" />
                                        <asp:BoundField DataField="RC_CUSEA01" HeaderText="APRUEBA1" />
                                        <asp:BoundField DataField="RC_CUSEA01" HeaderText="APRUEBA2" />
                                        <asp:BoundField DataField="RC_CUSEA01" HeaderText="APRUEBA3" />
                                        <asp:TemplateField HeaderText="VISUALIZAR">
                                            <ItemTemplate>
                                                <div class="ver">
                                                    <img alt="" src="../Images/Message_Information.png" width="25" style="cursor: pointer" />
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

                                <div style="display: none">
                                    <asp:GridView ID="gvreporte" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" DataKeyNames="RC_CUSUCRE">
                                        <Columns>
                                            <asp:BoundField DataField="RC_CNROREQ" HeaderText="REQUISICION" />
                                            <asp:BoundField DataField="RC_DFECREQ" HeaderText="FECHA" />
                                            <asp:BoundField DataField="PROVEEDOR" HeaderText="PROVEEDOR" />
                                            <asp:BoundField DataField="ESTADO" HeaderText="ESTADO" />
                                            <asp:BoundField DataField="APROBAC" HeaderText="APROBAC" />
                                            <asp:BoundField DataField="RC_DFECA03" HeaderText="FECHA.APROB" />
                                            <asp:BoundField DataField="RC_CNUMORD" HeaderText="NRO.ORDEN" />
                                            <asp:BoundField DataField="USUARIO" HeaderText="USUARIO" />
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
            </td>
        </tr>
    </table>
    <%-- style="display: none" --%>
    <div id="EstadoPedido" style="display:none" >
        <table>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="lblcabnumero" runat="server" Text="Nro Requerimiento:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblnumero" runat="server"></asp:Label>
                    <br />

                    <asp:Label ID="lblcabfecha" runat="server" Text="Fecha:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblfecha" runat="server"></asp:Label>
                    <br />

                    <asp:Label ID="lblcabsolicitante" runat="server" Text="Solicitante:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblsolicitante" runat="server"></asp:Label>

                    <br />

                    <asp:Label ID="lblcabcosto" runat="server" Text="Centro de Costo:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblcosto" runat="server"></asp:Label>

                    <br />

                    <asp:Label ID="lblcabprovvedor" runat="server" Text="Proveedor:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblproveedor" runat="server"></asp:Label>

                    <br />

                    <asp:Label ID="lblCabUso" runat="server" Text="Uso:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="lbluso" runat="server"></asp:Label>

                    <br />

                    <asp:Label ID="lblCabPrioridad" runat="server" Text="Prioridad:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblprioridad" runat="server"></asp:Label>
                    <br />

                    <asp:Label ID="lblcabusus1" runat="server" Text="Usuario1:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblusu01" runat="server"></asp:Label>

                    <asp:Label ID="lblcabusus2" runat="server" Text="Usuario2:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblusu02" runat="server"></asp:Label>

                    <asp:Label ID="lblcabusus3" runat="server" Text="Usuario3:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblusu03" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lblcabfecha1" runat="server" Text="Fecha1:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblfecha01" runat="server"></asp:Label>
                    <asp:Label ID="lblcabfecha2" runat="server" Text="Fecha2:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblfecha02" runat="server"></asp:Label>
                    <asp:Label ID="lblcabfecha3" runat="server" Text="Fecha3:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblfecha03" runat="server"></asp:Label>



                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                     <div style="overflow: auto; width: 880px; height: 120px">
                    <asp:GridView ID="gvdetalle" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" Width="859px" Font-Size="8">
                        <Columns>
                            <asp:BoundField DataField="RD_CITEM" HeaderText="ITEM" HeaderStyle-HorizontalAlign="Left" />
                            <asp:BoundField DataField="RD_CCODIGO" HeaderText="CODIGO" HeaderStyle-HorizontalAlign="Left" />
                            <asp:BoundField DataField="RD_CDESCRI" HeaderText="DESCRI" HeaderStyle-HorizontalAlign="Left" />
                            <asp:BoundField DataField="RD_CUNID" HeaderText="UNID" HeaderStyle-HorizontalAlign="Left" />
                            <asp:BoundField DataField="RD_NQPEDI" HeaderText="CANT" HeaderStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                           
                            <asp:BoundField DataField="RD_COBS" HeaderText="OBS" HeaderStyle-HorizontalAlign="Left" />


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
            <tr>
                <td>

                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <input id="btnimprimir" type="button" value="Imprimir" class="imprimi btn" style="width:90px; height:28px; color: #003366; background-color: #99CCFF" />
                    <input id="btnaprobar" type="button" value="Aprobar" class="aprobar btn" style="width:90px; height:28px; color: #003366; background-color: #99CCFF" />
                    <input id="btndesaprobar" type="button" value="Desaprobar" class="desaprobar btn" style="width:120px; height:28px; color: #003366; background-color: #99CCFF" />
                    
                    
                    <asp:TextBox ID="txtestado" runat="server" BorderStyle="None" Width="0px"></asp:TextBox>
                     </td>
            </tr>
        </table>
    </div>

      <asp:Panel ID="Panel1" runat="server" BackColor="White" style="display:">
           <table>
               <tr>
                   <td>
                        <div style="color: #FF0000">
                       LOS REQUERIMIENTOS PENDIENTES <br />
                       DE APROBACIÓN SE ANULARÁN <br />
                       DESPUÉS DE 15 DÍAS
                       </div>
       
       
                   </td>
                        
                 
               </tr>

           </table>
          </asp:Panel>

        <ajaxToolkit:AlwaysVisibleControlExtender ID="ace" runat="server"
    TargetControlID="Panel1"         
    VerticalSide="Top"
    VerticalOffset="140"
    HorizontalSide="right"
    HorizontalOffset="220"
    ScrollEffectDuration=".1"/>
     

</asp:Content>

















