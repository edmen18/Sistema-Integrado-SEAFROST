<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile=" AprobAnticipo.aspx.cs" Inherits="Default2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
 


    <script type="text/javascript">
        $(function () {
            $("#MainContent_txtfecha2").datepicker();
            $("#MainContent_txtfecha1").datepicker();
            $("#MainContent_txtfechaproceso").datepicker();
            $("#MainContent_txtfechaemision").datepicker();
            $("#MainContent_txtsolicitante").autocomplete(
{

    source: function (request, response) {
        $.ajax({
            url: "AprobAnticipo.aspx/GETVARIOS",
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


    }
});

            $("#MainContent_txtprove").autocomplete(
                     {
                         source: function (request, response) {
                             $.ajax({
                                 url: "AprobAnticipo.aspx/GetProveedores",
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

            $(".btbuscar").click(function () {
                filtarsolicitudes();
            });



            $(".btadd").click(function () { //  se debe colocar dentrp de una funcion 
                $("#dvdetalle").dialog('open');
                $("#MainContent_txtindicador").val("G");
                $("#MainContent_lblsolicitud").html("");
                $("#MainContent_txtorden").val("");
                $("#MainContent_lblruc").html("");
                $("#MainContent_lblrazonsocial").html("");
                $("#MainContent_txtcuentaprov").val("");
                $("#MainContent_txtfechaemision").val("");
                $("#MainContent_txtfechaproceso").val("");
                $("#MainContent_lblmone").html("");
                $("#MainContent_lblmoneda").html("");
                $("#MainContent_txtmsolicitado").val("");
                $("#MainContent_txtporcentaje").val("");
                $("#MainContent_txtanticipo").val("");
                $("#MainContent_txtmpagar").val("");
                $("#MainContent_txtmotivo").val("");
                $("#MainContent_txtanterior").val("");
                $("#MainContent_txtorden").attr("disabled", false);
                document.getElementById("btncalcular").style.visibility = "visible";
                document.getElementById("btnonsultaroc").style.visibility = "visible";
                document.getElementById("btngrabar").style.visibility = "visible";
            });

            $(".btvisualizar").click(function () { //  se debe colocar dentrp de una funcion 
                $("#dvdetalle").dialog('open');
                $("#MainContent_txtindicador").val("V");

                trp = $(this).parent().parent();
                id = $("td:eq(0)", trp).html();
                $("#MainContent_lblsolicitud").html(id);
                codsol = $("td:eq(0)", trp).val();
                solicitante = $("td:eq(1)", trp).val();
                $("#MainContent_lblcodsol").html(codsol);
                $("#MainContent_lblsolicitante").html(solicitante);
              
                trp = $(this).parent().parent();
                orden = $("td:eq(1)", trp).html();
                $("#MainContent_txtorden").val(orden);

                trp = $(this).parent().parent();
                ruc = $("td:eq(2)", trp).html();
                $("#MainContent_lblruc").html(ruc);

                trp = $(this).parent().parent();
                prov = $("td:eq(3)", trp).html();
                $("#MainContent_lblrazonsocial").html(prov);

                trp = $(this).parent().parent();
                emision = $("td:eq(4)", trp).html();
                $("#MainContent_txtfechaemision").val(emision);

                trp = $(this).parent().parent();
                proceso = $("td:eq(5)", trp).html();
                $("#MainContent_txtfechaproceso").val(proceso);

                trp = $(this).parent().parent();
                moneda = $("td:eq(6)", trp).html();
                $("#MainContent_lblmone").html(moneda);

                trp = $(this).parent().parent();
                moneda1 = $("td:eq(6)", trp).val();
                $("#MainContent_lblmoneda").html(moneda1);


                trp = $(this).parent().parent();
                total = $("td:eq(7)", trp).html();
                $("#MainContent_txtmsolicitado").val(total);

                trp = $(this).parent().parent();
                pdetra = $("td:eq(7)", trp).val();
                $("#MainContent_txtdetraccion").val(pdetra);


                trp = $(this).parent().parent();
                porcentaje = $("td:eq(8)", trp).html();
                $("#MainContent_txtporcentaje").val(porcentaje);

                trp = $(this).parent().parent();
                detra = $("td:eq(8)", trp).val();
                $("#MainContent_lbldetraccion").html(detra);

                trp = $(this).parent().parent();
                anticipo = $("td:eq(9)", trp).html();
                $("#MainContent_txtanticipo").val(anticipo);

                trp = $(this).parent().parent();
                pret = $("td:eq(9)", trp).val();
                $("#MainContent_txtretencion").val(pret);

                trp = $(this).parent().parent();
                pagar = $("td:eq(10)", trp).html();
                $("#MainContent_txtmpagar").val(pagar);

                trp = $(this).parent().parent();
                ret = $("td:eq(10)", trp).val();
                $("#MainContent_lblretencion").html(ret);

                trp = $(this).parent().parent();
                motivo = $("td:eq(11)", trp).html();
                $("#MainContent_txtmotivo").val(motivo);

                trp = $(this).parent().parent();
                dias = $("td:eq(11)", trp).val();
                $("#MainContent_txtdias").val(dias);

                trp = $(this).parent().parent();
                ctaprov = $("td:eq(12)", trp).val();
                $("#MainContent_txtcuentaprov").val(ctaprov);

                trp = $(this).parent().parent();
                ctabanco = $("td:eq(15)", trp).val();
                $("#MainContent_ddlbanco option:selected").val(ctabanco);

                trp = $(this).parent().parent();
                banco = $("td:eq(12)", trp).html();
                $("#MainContent_ddlbanco option:selected").text(banco);
                AnticiposAnteriores();


                //////codigo aprobacion
                trp = $(this).parent().parent();
                idnumoc = $("td:eq(0)", trp).html();
                $("#MainContent_txtidnumoc").val(idnumoc);

                //USUARIO  S
                //trp18 = $(this).parent().parent();
                //usu1 = $("td:eq(13)", trp18).html();
                //$("#MainContent_txtusu1").val(usu1);

                //trp19 = $(this).parent().parent();
                //usu2 = $("td:eq(14)", trp19).html();
                //$("#MainContent_txtusu2").val(usu2);

                //trp20 = $(this).parent().parent();
                //usu3 = $("td:eq(15)", trp20).html();
                //$("#MainContent_txtusu3").val(usu3);

                //trp21 = $(this).parent().parent();
                //usu4 = $("td:eq(16)", trp21).html();
                //$("#MainContent_txtusu4").val(usu4);
                traerdatosusu();
                var estadooc = $("td:eq(14)", trp).val();
                $("#MainContent_txtestadooc").val(estadooc);
                var est = $("td:eq(13)", trp).val();
                $("#MainContent_txtest").val(est);
                /////

                if ($("#MainContent_txtindicador").val() == "V") {

                    $("#MainContent_txtorden").attr("disabled", true);
                    $("#MainContent_txtcuentaprov").attr("disabled", true);
                    $("#MainContent_txtfechaemision").attr("disabled", true);
                    $("#MainContent_txtfechaproceso").attr("disabled", true);
                    $("#MainContent_txtporcentaje").attr("disabled", true);
                    $("#MainContent_txtmotivo").attr("disabled", true);
                    $("#MainContent_ddlbanco").attr("disabled", true);
                    $("#MainContent_txtdetraccion").attr("disabled", true);
                    $("#MainContent_txtretencion").attr("disabled", true);
                    $("#MainContent_txtdias").attr("disabled", true);
                    //$("#MainContent_btncalcular").attr("disabled", true);
                    document.getElementById("btncalcular").style.visibility = "hidden";
                    document.getElementById("btnonsultaroc").style.visibility = "hidden";
                    document.getElementById("btngrabar").style.visibility = "hidden";

                }




            });

          $(".btproveedordatos").click(function () { //  se debe colocar dentrp de una funcion 
                if ($("#MainContent_txtindicador").val() == "G") {
                    $("#MainContent_lblsolicitud").html("");
                    $("#MainContent_lblruc").html("");
                    $("#MainContent_lblrazonsocial").html("");
                    $("#MainContent_txtcuentaprov").val("");
                    $("#MainContent_txtfechaemision").val("");
                    $("#MainContent_txtfechaproceso").val("");
                    $("#MainContent_lblmone").html("");
                    $("#MainContent_lblmoneda").html("");
                    $("#MainContent_lbldetraccion").html("");
                    $("#MainContent_lblretencion").html("");
                    $("#MainContent_txtdetraccion").val("0.00");
                    $("#MainContent_txtretencion").val("0.00");
                    $("#MainContent_txtmsolicitado").val("0.00");
                    $("#MainContent_txtporcentaje").val("0.00");
                    $("#MainContent_txtanticipo").val("0.00");
                    $("#MainContent_txtmpagar").val("0.00");
                    $("#MainContent_txtmotivo").val("");
                    $("#MainContent_txtanterior").val("0.00");
                  
                var textdev = datosOrdenyProveedor().ruc;
                var textdev1 = datosOrdenyProveedor().prov;
                var monedac = datosOrdenyProveedor().moneda;
                var montosoles = datosOrdenyProveedor().montosol;
                var montodolares = datosOrdenyProveedor().montodol;
                var monedadescripcion = datosOrdenyProveedor().moneda1;
                if (datosOrdenyProveedor().prov !=null) {
                $("#MainContent_lblruc").html(textdev);
                $("#MainContent_lblrazonsocial").html(textdev1);
                $("#MainContent_lblmone").html(monedac);
                $("#MainContent_lblmoneda").html(monedadescripcion);

                if ($("#MainContent_lblmone").val() == "MN") {
                    $("#MainContent_txtmsolicitado").val(montosoles);
                }
                else {
                    $("#MainContent_txtmsolicitado").val(montodolares);
                }
                var ultimodato = generar().contador;
                var formato = ultimodato.length < 10 ? pad("0" + ultimodato, 10) : ultimodato;
                $("#MainContent_lblsolicitud").html(formato);
                  
                }

                else {
                    alert("La solicitud no existe o no está aprobada");

                }

                }
                
               });
      
            $(".total").click(function () { //  se debe colocar dentrp de una funcion 
                calculartotales();
            });
              

            $(".btgrabar").click(function () { //  se debe colocar dentrp de una funcion 
                if ($("#MainContent_txtindicador").val() == "G") {
                    InsertarSolicitud();


                }
                if ($("#MainContent_txtindicador").val() == "A") {
                    InsertarSolicitud();

                }
            });
                  
               $('#dvdetalle').dialog({
                autoOpen: false,
                modal: true,
                resizable: true,
                width: 550,
                heigth: 100,
                title: 'Registro',
                close: function (event, ui) {
                    limpiardatos();
                    filtarsolicitudesInicio();
                },

               // buttons: {

               //     Grabar: function () {
                        // aqui va el contenido
               //     }
               //}



                });
        

                                  
               function limpiardatos() {

                $("#MainContent_txtindicador").val("");
                $("#MainContent_lblsolicitud").html("");
                $("#MainContent_txtorden").val("");
                $("#MainContent_lblruc").html("");
                $("#MainContent_lblrazonsocial").html("");
                $("#MainContent_txtcuentaprov").val("");
                $("#MainContent_txtfechaemision").val("");
                $("#MainContent_txtfechaproceso").val("");
                $("#MainContent_lblmone").html("");
                $("#MainContent_lblmoneda").html("");
                $("#MainContent_lbldetraccion").html("");
                $("#MainContent_lblretencion").html("");
                $("#MainContent_txtdetraccion").val("0.00");
                $("#MainContent_txtretencion").val("0.00");
                $("#MainContent_txtmsolicitado").val("0.00");
                $("#MainContent_txtporcentaje").val("0.00");
                $("#MainContent_txtanticipo").val("0.00");
                $("#MainContent_txtmpagar").val("0.00");
                $("#MainContent_txtmotivo").val("");
                $("#MainContent_txtanterior").val("0.00");
                $("#MainContent_txtorden").attr("disabled", false);
                $("#MainContent_txtcuentaprov").attr("disabled", false);
                $("#MainContent_txtfechaemision").attr("disabled", false);
                $("#MainContent_txtfechaproceso").attr("disabled", false);
                $("#MainContent_txtporcentaje").attr("disabled", false);
                $("#MainContent_txtmotivo").attr("disabled", false);
                $("#MainContent_ddlbanco").attr("disabled", false);
                $("#MainContent_txtdetraccion").attr("disabled", false);
                $("#MainContent_txtretencion").attr("disabled", false);
                $("#MainContent_txtdias").attr("disabled", false);

            }


            function InsertarSolicitud() {

                var fecemi = moment($("#MainContent_txtfechaemision").val(), "DD/MM/YYYY");
                fecemi = fecemi == null ? null : new Date(fecemi);
                var fecpro = moment($("#MainContent_txtfechaproceso").val(), "DD/MM/YYYY");
                fecpro = fecpro == null ? null : new Date(fecpro);
                var DETA = {};
                DETA.OC_CNUMORD = $("#MainContent_txtorden").val().trim();
                DETA.OC_CCODPRO = $("#MainContent_lblruc").html();
                DETA.OC_CRAZSOC = $("#MainContent_lblrazonsocial").html();
                DETA.OC_FECEMI =  fecemi;
                DETA.OC_FECPRO = fecpro;
                DETA.OC_CODMON = $("#MainContent_lblmone").html().trim();
                DETA.MONEDA = $("#MainContent_lblmoneda").html().trim();
                DETA.OC_MONTO_PEDIDO = $("#MainContent_txtmsolicitado").val().trim();
                DETA.OC_PERCENTAJE = $("#MainContent_txtporcentaje").val().trim();
                DETA.OC_ANTICIPO = $("#MainContent_txtanticipo").val().trim();
                DETA.OC_TOTAL_PAGAR = $("#MainContent_txtmpagar").val().trim();
                DETA.MOTIVO = $("#MainContent_txtmotivo").val().trim();
                DETA.OC_CTAPROVEEDOR = $("#MainContent_txtcuentaprov").val().trim();
                DETA.OC_BANCO = $("#MainContent_ddlbanco").val().trim();
                DETA.ANT_CODIGO = $("#MainContent_lblsolicitud").html();
                DETA.BANCO = $("#MainContent_ddlbanco option:selected").text();
                DETA.DET_PORCENTAJE=$("#MainContent_txtdetraccion").val();
                DETA.DETRACCION=$("#MainContent_lbldetraccion").html();
                DETA.RET_PORCENTAJE=$("#MainContent_txtretencion").val();
                DETA.RETENCION=$("#MainContent_lblretencion").html();
                DETA.PLAZO_DIAS = $("#MainContent_txtdias").val();
                DETA.ESTADO="P";

                if ((DETA.OC_CNUMORD.trim() == "") || (DETA.OC_CCODPRO.trim() == "") || (DETA.OC_CRAZSOC.trim() == "") || (DETA.OC_CODMON.trim() == "") || (DETA.OC_MONTO_PEDIDO.trim() == "") || (DETA.OC_PERCENTAJE == 0) || (DETA.OC_ANTICIPO == 0) || (DETA.OC_TOTAL_PAGAR == 0) || (DETA.OC_CTAPROVEEDOR.trim() == "") || (DETA.OC_BANCO.trim() == "-1") || (DETA.ANT_CODIGO.trim() == "") || (DETA.BANCO.trim() == "") || (DETA.PLAZO_DIAS.trim() == ""))
                {
                    alert("Complete los Datos antes de continuar");

                }
                else{

                if ($("#MainContent_txtindicador").val() == "G") {
                    $.ajax({

                        type: "POST",
                        url: " AprobAnticipo.aspx/InsertaDet",
                        data: '{DETA: ' + JSON.stringify(DETA) + '}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        //async: false,
                        success: function (response) {
                            alert("Registro Grabado");
                            $("#dvdetalle").dialog('close');
                        },
                        error: function (response) {
                            if (response.length != 0)
                                //alert(response);
                                console.table(response);
                        }

                    });

                }

                if ($("#MainContent_txtindicador").val() == "A") {
                  
                    $.ajax({

                        type: "POST",
                        url: " AprobAnticipo.aspx/ActualizaAnticipo",
                        data: '{DETA: ' + JSON.stringify(DETA) + '}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        //async: false,
                        success: function (response) {
                            alert("Registro Actualizado");
                            $("#dvdetalle").dialog('close');
                        },
                        error: function (response) {
                            if (response.length != 0)
                                //alert(response);
                                console.table(response);
                        }

                    });
                }

                //location.reload();
                filtarsolicitudes()
                }

            }

            $(window).load(function () {
                contarndw = 0;
                cc = 1;
                sw_edicion = 0;
                sw_nuevo = 0;
                contaditem = 0;
                filtarsolicitudesInicio();

            });

                     
            function datosOrdenyProveedor() {
                var codigowh = $("#MainContent_txtorden").val();

                if (codigowh != "") {
                    var prov = "";
                    var ruc = "";
                    var montosol = "";
                    var montodol = "";
                    var moneda = "";
                    var moneda1 = "";
                    $("#MainContent_txtanticipo").val("0.00");
                    $("#MainContent_txtmpagar").val("0.00");
                    $("#MainContent_txtporcentaje").val("0.00");
                    AnticiposAnteriores();

                    $.ajax({

                        type: "POST",
                        url: " AprobAnticipo.aspx/datosproveedor",
                        data: "{dato: '" + codigowh + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (data) {

                            if (data.d.OC_CCODPRO != "") {
                                prov = data.d.OC_CRAZSOC;
                                ruc = data.d.OC_CCODPRO;
                                montosol = (data.d.OC_NIMPMN);
                                montodol = data.d.OC_NIMPUS;
                                moneda = data.d.OC_CCODMON;
                                
                                if (moneda == "MN          ") {
                                    moneda1.trim() = "MONEDA NACIONAL";
                                }
                                if (moneda.trim() == "EU          ") {
                                    monedadescripcio = "EURO";
                                }
                                if (moneda.trim() == "US          ") {
                                    monedadescripcio = "DOLARES";
                                }
                               
                            }
                            else {
                                alert("No existen datos para esta solicitud")
                            }

                        },
                        error: function (data) {
                            if (data.length != 0)
                                alert(data);
                        }

                    });
                    return { prov, ruc, montosol, montodol, moneda , moneda1};

                }
                else {
                    alert("Por favor ingrese una solicitud de anticipo")
                }
            }


            function generar() {
                var solicitud = "";
                var contador = "";

                $.ajax({

                    type: "POST",
                    url: " AprobAnticipo.aspx/GENERAR",
                    data: "{solicitud: '" + solicitud + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        // console.log(data);
                        //alert(data.d);
                        contador = data.d;
                                            
                    },
                    error: function (data) {
                        if (data.length != 0)
                            alert(data);
                    }
                });
                return { contador };
            }
            
            function filtarsolicitudes() {
                var fec1 = moment($("#MainContent_txtfecha1").val(), "DD/MM/YYYY");
                fec1 = new Date(fec1);
                var fec2 = moment($("#MainContent_txtfecha2").val(), "DD/MM/YYYY");
                fec2 = new Date(fec2);
                var VC = {};
                VC.OC_CCODPRO = $("#MainContent_txtidpro").val();
                VC.OC_FECEMI = fec1;
                VC.OC_FECPRO = fec2;
                VC.APROBADO = $("#MainContent_ddlsituacion").val();
                VC.ESTADO = $("#MainContent_ddlestado").val();
                VC.OC_CCODSOL = $("#MainContent_txtcodsol").val();

                $.ajax({

                    type: "POST",
                    url: "AprobAnticipo.aspx/ListarSolicitudes",
                    data: '{VC: ' + JSON.stringify(VC) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        if (data.d.length > 0) {
                            var row = $("[id*=gvordencompra] tr:last-child").clone(true);
                            $("[id*=gvordencompra] tr").not($("[id*=gvordencompra] tr:first-child")).remove();

                            for (var i = 0; i < data.d.length; i++) {
                                $("td", row).eq(0).html(data.d[i].ANT_CODIGO);
                                $("td", row).eq(0).val(data.d[i].OC_CCODSOL);
                                $("td", row).eq(1).html(data.d[i].OC_CNUMORD);
                                $("td", row).eq(1).val(data.d[i].OC_CSOLICT);
                                $("td", row).eq(2).html(data.d[i].OC_CCODPRO);
                                $("td", row).eq(3).html(data.d[i].OC_CRAZSOC);
                                $("td", row).eq(4).html(data.d[i].OC_FECEMI);
                                $("td", row).eq(5).html(data.d[i].OC_FECPRO);
                                $("td", row).eq(6).html(data.d[i].OC_CODMON);
                                $("td", row).eq(6).val(data.d[i].MONEDA);

                                $("td", row).eq(7).html(data.d[i].OC_MONTO_PEDIDO.toFixed(2));
                                $("td", row).eq(7).val(data.d[i].DET_PORCENTAJE.toFixed(2));
                                $("td", row).eq(8).html(data.d[i].OC_PERCENTAJE.toFixed(2));
                                $("td", row).eq(8).val(data.d[i].DETRACCION.toFixed(2));
                                $("td", row).eq(9).html(data.d[i].OC_ANTICIPO.toFixed(2));
                                $("td", row).eq(9).val(data.d[i].RET_PORCENTAJE.toFixed(2));
                                $("td", row).eq(10).html(data.d[i].OC_TOTAL_PAGAR.toFixed(2));
                                $("td", row).eq(10).val(data.d[i].RETENCION.toFixed(2));
                                $("td", row).eq(11).html(data.d[i].MOTIVO);
                                $("td", row).eq(11).val(data.d[i].PLAZO_DIAS);

                               //// $("td", row).eq(12).html(data.d[i].OC_CTAPROVEEDOR);
                               //// $("td", row).eq(12).val(data.d[i].ESTADO);
                               // $("td", row).eq(13).html(data.d[i].OC_BANCO);


                                $("td", row).eq(12).html(data.d[i].BANCO);
                                $("td", row).eq(12).val(data.d[i].OC_CTAPROVEEDOR);
                                $("td", row).eq(13).html(data.d[i].USER1);
                                $("td", row).eq(13).val(data.d[i].ESTADO);
                                $("td", row).eq(14).html(data.d[i].USER2);
                                $("td", row).eq(14).val(data.d[i].APROB);
                                $("td", row).eq(15).html(data.d[i].USER3);
                                $("td", row).eq(15).val(data.d[i].OC_BANCO);
                                $("td", row).eq(16).html(data.d[i].USER4);
                                if (data.d[i].APROB == "A") {
                                    $("td", row).eq(17).html("APROBADO");
                                }
                                if (data.d[i].APROB == "E") {
                                    $("td", row).eq(17).html("EMITIDO");
                                }

                                $("[id*=gvordencompra]").append(row);
                                row = $("[id*=gvordencompra] tr:last-child").clone(true);
                            }
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
                            $("td", row).eq(6).val("");
                            $("td", row).eq(7).html("");
                            $("td", row).eq(8).html("");
                            $("td", row).eq(9).html("");
                            $("td", row).eq(10).html("");
                            $("td", row).eq(11).html("");
                            $("td", row).eq(12).html("");
                            $("td", row).eq(7).val("");
                            $("td", row).eq(8).val("");
                            $("td", row).eq(9).val("");
                            $("td", row).eq(10).val("");
                            $("td", row).eq(11).val("");
                            $("td", row).eq(12).val("");
                            $("td", row).eq(13).html("");
                            $("td", row).eq(14).html("");
                            $("td", row).eq(15).html("");
                            $("td", row).eq(15).val("");
                            $("td", row).eq(16).html("");
                            $("td", row).eq(17).html("");
                             $("[id*=gvordencompra]").append(row);
                            alert("no se encontro registro");
                        }


                    },
                    error: function (response) {
                        if (response.length != 0)
                            alert(response);
                    }
                });

            }


            function filtarsolicitudesInicio() {
                var fec1 = moment($("#MainContent_txtfecha1").val(), "DD/MM/YYYY");
                fec1 = new Date(fec1);
                var fec2 = moment($("#MainContent_txtfecha2").val(), "DD/MM/YYYY");
                fec2 = new Date(fec2);
                var VC = {};
                VC.OC_CCODPRO ="";
                VC.OC_FECEMI = fec1;
                VC.OC_FECPRO = fec2;
                VC.APROBADO ="E";
                VC.ESTADO = "1";
                VC.OC_CCODSOL = "";


                $.ajax({

                    type: "POST",
                    url: "AprobAnticipo.aspx/ListarSolicitudes",
                    data: '{VC: ' + JSON.stringify(VC) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        if (data.d.length > 0) {
                            var row = $("[id*=gvordencompra] tr:last-child").clone(true);
                            $("[id*=gvordencompra] tr").not($("[id*=gvordencompra] tr:first-child")).remove();

                           
                            for (var i = 0; i < data.d.length; i++) {
                                $("td", row).eq(0).html(data.d[i].ANT_CODIGO);
                                $("td", row).eq(0).val(data.d[i].OC_CCODSOL);
                                $("td", row).eq(1).html(data.d[i].OC_CNUMORD);
                                $("td", row).eq(1).val(data.d[i].OC_CSOLICT);
                                $("td", row).eq(2).html(data.d[i].OC_CCODPRO);
                                $("td", row).eq(3).html(data.d[i].OC_CRAZSOC);
                                $("td", row).eq(4).html(data.d[i].OC_FECEMI);
                                $("td", row).eq(5).html(data.d[i].OC_FECPRO);
                                $("td", row).eq(6).html(data.d[i].OC_CODMON);
                                $("td", row).eq(6).val(data.d[i].MONEDA);

                                $("td", row).eq(7).html(data.d[i].OC_MONTO_PEDIDO.toFixed(2));
                                $("td", row).eq(7).val(data.d[i].DET_PORCENTAJE.toFixed(2));
                                $("td", row).eq(8).html(data.d[i].OC_PERCENTAJE.toFixed(2));
                                $("td", row).eq(8).val(data.d[i].DETRACCION.toFixed(2));
                                $("td", row).eq(9).html(data.d[i].OC_ANTICIPO.toFixed(2));
                                $("td", row).eq(9).val(data.d[i].RET_PORCENTAJE.toFixed(2));
                                $("td", row).eq(10).html(data.d[i].OC_TOTAL_PAGAR.toFixed(2));
                                $("td", row).eq(10).val(data.d[i].RETENCION.toFixed(2));
                                $("td", row).eq(11).html(data.d[i].MOTIVO);
                                $("td", row).eq(11).val(data.d[i].PLAZO_DIAS);
                                //$("td", row).eq(12).html(data.d[i].OC_CTAPROVEEDOR);
                                //$("td", row).eq(12).val(data.d[i].ESTADO);

                                //$("td", row).eq(13).html(data.d[i].OC_BANCO);
                                $("td", row).eq(12).html(data.d[i].BANCO);
                                $("td", row).eq(12).val(data.d[i].OC_CTAPROVEEDOR);
                                $("td", row).eq(13).html(data.d[i].USER1);
                                $("td", row).eq(13).val(data.d[i].ESTADO);
                                $("td", row).eq(14).html(data.d[i].USER2);
                                $("td", row).eq(14).val(data.d[i].APROB);
                                $("td", row).eq(15).html(data.d[i].USER3);
                                $("td", row).eq(15).val(data.d[i].OC_BANCO);
                                $("td", row).eq(16).html(data.d[i].USER4);
                                if (data.d[i].APROB=="A") {
                                    $("td", row).eq(17).html("APROBADO");
                                }
                                if (data.d[i].APROB == "E") {
                                    $("td", row).eq(17).html("EMITIDO");
                                }

                                $("[id*=gvordencompra]").append(row);
                                row = $("[id*=gvordencompra] tr:last-child").clone(true);
                            }
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
                            $("td", row).eq(6).val("");
                            $("td", row).eq(7).html("");
                            $("td", row).eq(8).html("");
                            $("td", row).eq(9).html("");
                            $("td", row).eq(10).html("");
                            $("td", row).eq(11).html("");
                            $("td", row).eq(12).html("");
                            $("td", row).eq(7).val("");
                            $("td", row).eq(8).val("");
                            $("td", row).eq(9).val("");
                            $("td", row).eq(10).val("");
                            $("td", row).eq(11).val("");
                            $("td", row).eq(12).val("");
                            $("td", row).eq(13).html("");
                            $("td", row).eq(14).html("");
                            $("td", row).eq(15).html("");
                            $("td", row).eq(15).val("");
                            $("td", row).eq(16).html("");
                            $("td", row).eq(17).html("");
                            $("[id*=gvordencompra]").append(row);
                            alert("no se encontro registro");
                        }


                    },
                    error: function (response) {
                        if (response.length != 0)
                            alert(response);
                    }
                });

            }
            
                   
            function AnticiposAnteriores() {
                var VC = {};
                VC.OC_CNUMORD = $("#MainContent_txtorden").val();
                $.ajax({

                    type: "POST",
                    url: " AprobAnticipo.aspx/sumaranticipos",
                    data: '{VC: ' + JSON.stringify(VC) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        if ((data.d) == "") {
                            $("#MainContent_txtanterior").val("0.00");
                        }
                        else {
                            for (var i = 0; i < data.d.length; i++) {

                                $("#MainContent_txtanterior").val(data.d[i].TOTAL_ANTICIPO.toFixed(2));
                              }
                        }
                    },
                    error: function (response) {
                        if (response.length != 0)
                            alert(response);
                    }
                });

            }
            function calculartotales() {

                if ($("#MainContent_txtindicador").val() == "G") {

                    var montofinal = $("#MainContent_txtmsolicitado").val() * ($("#MainContent_txtporcentaje").val() / 100);

                if (montofinal > 0)
                {
                if ((montofinal + parseFloat($("#MainContent_txtanterior").val())) <= $("#MainContent_txtmsolicitado").val())
                {
                    $("#MainContent_txtanticipo").val(montofinal);
                    var detraccion = montofinal * ($("#MainContent_txtdetraccion").val() / 100);
                    var retencion = montofinal * ($("#MainContent_txtretencion").val() / 100);
                     $("#MainContent_lblretencion").html(retencion);
                    $("#MainContent_lbldetraccion").html(detraccion);
                    $("#MainContent_txtmpagar").val(montofinal-detraccion-retencion);
                }
               else {
                    alert("el porcentaje ingresado supera al monto total de la Orden de Compra")
                    $("#MainContent_txtporcentaje").val("0.00");
                    $("#MainContent_txtanticipo").val("0.00");
                    $("#MainContent_txtmpagar").val("0.00");
                 }
                }
                else {
                    alert("Debe ingresar un monto mayor de cero");
                }
                }
                if ($("#MainContent_txtindicador").val() == "A" ) {

                    var montofinal = $("#MainContent_txtmsolicitado").val() * ($("#MainContent_txtporcentaje").val() / 100);

                    if (montofinal > 0) {
                        if ((montofinal + parseFloat($("#MainContent_txtanterior").val())) <= $("#MainContent_txtmsolicitado").val()) {
                            $("#MainContent_txtanticipo").val(montofinal);
                            var detraccion = montofinal * ($("#MainContent_txtdetraccion").val() / 100);
                            var retencion = montofinal * ($("#MainContent_txtretencion").val() / 100);
                            $("#MainContent_lblretencion").html(retencion);
                            $("#MainContent_lbldetraccion").html(detraccion);
                            $("#MainContent_txtmpagar").val(montofinal - detraccion - retencion);
                        }
                        else {
                            alert("el porcentaje ingresado supera al monto total de la Orden de Compra")
                            $("#MainContent_txtporcentaje").val("0.00");
                            $("#MainContent_txtanticipo").val("0.00");
                            $("#MainContent_txtmpagar").val("0.00");
                        }
                    }
                    else {
                        alert("Debe ingresar un monto mayor de cero");
                    }
                }


            }



            function pad(str, max) {
                if (str != undefined) {
                    str = str.toString();
                    return str.length < max ? pad("0" + str, max) : str;
                }
            }



            $(".btapro").click(function () {
               
                if ( $("#MainContent_txtest").val()=="P"){

                    if ($("#MainContent_txtestadooc").val() != "A" && $("#MainContent_txtestadooc").val() != "E") {
                        alert("La solicitud No se Puede Aprobar, Se Encuentra en Estado: " + estadooc);
                    }
                    else {
                        if (confirm("Desea Aprobar la solicitud: " + $("#MainContent_txtidnumoc").val())) {
                            aprobaroc( $("#MainContent_txtidnumoc").val(), "A",  $("#MainContent_txtusu1").val(),  $("#MainContent_txtusu2").val(),  $("#MainContent_txtusu3").val(),  $("#MainContent_txtusu4").val());
                            $("#dvdetalle").dialog('close')
                            filtarsolicitudesInicio();
                        }
                }
                }
                else {
                    alert("La solicitud ya fue aprobada y se encuentra liquidada");

                }

               });


            $(".btdesapro").click(function () {
                
                if ($("#MainContent_txtest").val() == "P") {
                
                    if ($("#MainContent_txtestadooc").val() == "A") {
                        if (confirm("Desea Desaprobar la Solicitud: " + $("#MainContent_txtidnumoc").val())) {
                            aprobaroc($("#MainContent_txtidnumoc").val(), "E", $("#MainContent_txtusu1").val(), $("#MainContent_txtusu2").val(), $("#MainContent_txtusu3").val(), $("#MainContent_txtusu4").val());
                           $("#dvdetalle").dialog('close')
                            filtarsolicitudesInicio();
                          }
                    }

                    else {
                        alert("No es posible realizar esta operacion , ya que la solicitud aun no ha sido aprobada");

                    }
                }
                else {
                    alert("La solicitud No se Puede Desaprobar porque ya se encuentra liquidada");
                }

               });

            function aprobaroc(idnumoc, indice, usu1, usu2, usu3, usu4) {
                var idnumd = idnumoc;
                var COAPRUEBA = {};
                //  var f = new Date();
                // filtarfechasocpopup(idnumoc);
                COAPRUEBA.ANT_CODIGO = idnumd;
                COAPRUEBA.APROBADO = indice;
                var user = {};
                user = $("#MainContent_lblusuario").html();
                COAPRUEBA.USER1 = usu1;
                COAPRUEBA.USER2 = usu2;
                COAPRUEBA.USER3 = usu3;
                COAPRUEBA.USER4 = usu4;

                if (indice == "A") {

                    if (usu1 == "     " && usu2 == "     " && usu3 == "     " && usu4 == "     ") {
                        COAPRUEBA.USER1 = user;
                        COAPRUEBA.USER2 = usu2;
                        COAPRUEBA.USER3 = usu3;
                        COAPRUEBA.USER4 = usu4;
                        InsertarSolicitudlog(COAPRUEBA.APROBADO, COAPRUEBA.USER1, COAPRUEBA.USER2, COAPRUEBA.USER3, COAPRUEBA.USER4);
                    }

                    if (usu1 != "     " && usu2 == "     " && usu3 == "     " && usu4 == "     ") {
                        COAPRUEBA.USER1 = usu1;
                        COAPRUEBA.USER2 = user;
                        COAPRUEBA.USER3 = usu3;
                        COAPRUEBA.USER4 = usu4;
                        InsertarSolicitudlog(COAPRUEBA.APROBADO, COAPRUEBA.USER1, COAPRUEBA.USER2, COAPRUEBA.USER3, COAPRUEBA.USER4);
                    }
                    if ((usu2 != "     " && usu1 != "     " && usu3 == "     " && usu4 == "     ") || (usu2 != "     " && usu1 != "     " && usu3 == "     " && usu4 != "     ")) {
                        COAPRUEBA.USER1 = usu1;
                        COAPRUEBA.USER2 = usu2;
                        COAPRUEBA.USER3 = user;
                        COAPRUEBA.USER4 = usu4;
                        InsertarSolicitudlog(COAPRUEBA.APROBADO, COAPRUEBA.USER1, COAPRUEBA.USER2, COAPRUEBA.USER3, COAPRUEBA.USER4);
                    }

                    if (usu2 != "     " && usu1 != "     " && usu3 != "     " && usu4 == "     ") {
                        COAPRUEBA.USER1 = usu1;
                        COAPRUEBA.USER2 = usu2;
                        COAPRUEBA.USER3 = usu3;
                        COAPRUEBA.USER4 = user;
                        InsertarSolicitudlog(COAPRUEBA.APROBADO, COAPRUEBA.USER1, COAPRUEBA.USER2, COAPRUEBA.USER3, COAPRUEBA.USER4);
                    }

                    if (usu2 != "     " && usu1 != "     " && usu3 != "     " && usu4 != "     ") {
                        alert("La solicitud ya fue aprobada")
                    }
                    
                }
                else {
                    InsertarSolicitudlog("E", "     ", "     ", "     ", "     ");
                }
               
                $.ajax({

                    type: "POST",
                    url: "AprobAnticipo.aspx/aprobaroc",
                    data: '{COAPRUEBA: ' + JSON.stringify(COAPRUEBA) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        alert("La operación completada correctamente")
                       // filtarsolicitudes()
                    },
                    error: function (response) {
                    }
                });
               

               }
            function InsertarSolicitudlog(apro,usu1,usu2,usu3,usu4) {

                var fecemi = moment($("#MainContent_txtfechaemision").val(), "DD/MM/YYYY");
                fecemi = fecemi == null ? null : new Date(fecemi);
                var fecpro = moment($("#MainContent_txtfechaproceso").val(), "DD/MM/YYYY");
                fecpro = fecpro == null ? null : new Date(fecpro);
                var DETA = {};
                DETA.OC_CNUMORDL = $("#MainContent_txtorden").val().trim();
                DETA.OC_CCODPROL = $("#MainContent_lblruc").html();
                DETA.OC_CRAZSOCL = $("#MainContent_lblrazonsocial").html();
                DETA.OC_FECEMIL = fecemi;
                DETA.OC_FECPROL = fecpro;
                DETA.OC_CODMONL = $("#MainContent_lblmone").html().trim();
                DETA.MONEDAL = $("#MainContent_lblmoneda").html().trim();
                DETA.OC_MONTO_PEDIDOL = $("#MainContent_txtmsolicitado").val().trim();
                DETA.OC_PERCENTAJEL = $("#MainContent_txtporcentaje").val().trim();
                DETA.OC_ANTICIPOL = $("#MainContent_txtanticipo").val().trim();
                DETA.OC_TOTAL_PAGARL = $("#MainContent_txtmpagar").val().trim();
                DETA.MOTIVOL = $("#MainContent_txtmotivo").val().trim();
                DETA.OC_CTAPROVEEDORL = $("#MainContent_txtcuentaprov").val().trim();
                DETA.OC_BANCOL = $("#MainContent_ddlbanco").val().trim();
                DETA.ANT_CODIGOL = $("#MainContent_lblsolicitud").html();
                DETA.BANCOL = $("#MainContent_ddlbanco option:selected").text();
                DETA.DET_PORCENTAJEL = $("#MainContent_txtdetraccion").val();
                DETA.DETRACCIONL = $("#MainContent_lbldetraccion").html();
                DETA.RET_PORCENTAJEL = $("#MainContent_txtretencion").val();
                DETA.RETENCIONL = $("#MainContent_lblretencion").html();
                DETA.PLAZO_DIASL = $("#MainContent_txtdias").val();
                DETA.ESTADOL = "P";
                DETA.USER1L = usu1;
                DETA.USER2L = usu2;
                DETA.USER3L = usu3;
                DETA.USER4L = usu4;
                DETA.OC_CCODSOLL = $("#MainContent_lblcodsol").html();
                DETA.OC_CSOLICTL = $("#MainContent_lblsolicitante").html();
                DETA.USUMODL = $("#MainContent_lblusuario").html();
                DETA.FECHAL = fecemi;
                if (apro== "A") {
                    DETA.OPERACIONL = "Aprobación de Anticipo";
                    if (DETA.USER1L.trim() != "" && DETA.USER2L.trim() != "" && DETA.USER3L.trim() != "" && DETA.USER4L.trim() != "") {
                         DETA.APROBADOL = "A";
                    }
                    else {
                        DETA.APROBADOL = "E";
                    }
                   
                }
                else {
                    DETA.OPERACIONL = "Desaprobacion de Anticipo";
                    DETA.APROBADOL = "E";
                }


                $.ajax({

                    type: "POST",
                    url: "AprobAnticipo.aspx/insertalog",
                    data: '{DETA: ' + JSON.stringify(DETA) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        //alert("Registro Grabado");
                        $("#dvdetalle").dialog('close');
                    },
                    error: function (response) {
                        if (response.length != 0)
                            console.table(response);
                    }

                });
            }


            function traerdatosusu() {
                var COM = {};
                COM.ANT_CODIGO = $("#MainContent_lblsolicitud").html();

                    $.ajax({
                        type: "POST",
                        url: " AprobAnticipo.aspx/traerdatos",
                        data: '{COM: ' + JSON.stringify(COM) + '}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (data) {
                            for (var i = 0; i < data.d.length; i++) {
                               // alert(data.d[i].USER1);
                                $("#MainContent_txtusu1").val(data.d[i].USER1);
                                $("#MainContent_txtusu2").val(data.d[i].USER2);
                                $("#MainContent_txtusu3").val(data.d[i].USER3);
                                $("#MainContent_txtusu4").val(data.d[i].USER4);

                               // $("#MainContent_txtanterior").val(data.d[i].TOTAL_ANTICIPO.toFixed(2));
                            }

                               
                        },
                        error: function (data) {
                            if (data.length != 0)
                                alert(data);
                        }

                    });
                    //return { prov, ruc, montosol, montodol, moneda, moneda1};

               
            }



        });   
    </script>
    <style type="text/css">
        .auto-style1 {
            width: 127px;
        }
        #btnsalir {
            width: 67px;
        }
        #btngrabar {
            width: 67px;
        }
        .auto-style2 {
            height: 15px;
        }
        .auto-style3 {
            width: 127px;
            height: 15px;
        }
        #btncalcular {
            width: 0px;
        }
        #btnonsultaroc {
            width: 2px;
        }
        .auto-style4 {
            width: 26px;
        }
        .auto-style5 {
            width: 90px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <fieldset style="background-color: #99CCFF">
        <legend style="font-weight: bold; background-color: #99CCFF;">
            <asp:Label ID="Label9" runat="server" Text="LISTADO DE SOLICITUDES DE ANTICIPO" Font-Bold="True" Font-Size="12pt"></asp:Label></legend>

        <table>
            <tr>
                <td>Proveedor</td>
                <td colspan="3">
                    <asp:TextBox ID="txtprove" runat="server" Width="350"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtidpro" Enabled="false" runat="server" Width="100"></asp:TextBox>
                </td>

                <td>Fecha:</td>
                <td>
                    <asp:TextBox ID="txtfecha1" runat="server" Width="80"></asp:TextBox>
                </td>
                <td>Fecha al:</td>
                <td>
                    <asp:TextBox ID="txtfecha2" runat="server" Width="80"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblacceso" runat="server" ForeColor="#66CCFF"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    ESTADO</td>
                <td class="auto-style4">
                    <asp:DropDownList ID="ddlestado" runat="server" Height="17px" Width="137px">
                        <asp:ListItem Value="1">TODOS</asp:ListItem>
                        <asp:ListItem Value="L">LIQUIDADA</asp:ListItem>
                        <asp:ListItem Value="P">PENDIENTE</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>SITUACION </td>
                <td>
                    <asp:DropDownList ID="ddlsituacion" runat="server" Height="17px" Width="137px">
                        <asp:ListItem Value="1">TODOS</asp:ListItem>
                        <asp:ListItem Value="A">APROBADO</asp:ListItem>
                        <asp:ListItem Value="E">EMITIDO</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <input class="btbuscar" value="Buscar" type="button" style="width: 100px" />
                    <asp:Label ID="lblusuario" runat="server" ForeColor="#66CCFF"></asp:Label>
                </td>
            </tr>
             <tr>
                <td>Solicitante</td>
                <td colspan="3">
                    <asp:TextBox ID="txtsolicitante" runat="server" Width="300"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtcodsol" runat="server" Width="100"></asp:TextBox>
                </td>
                 </tr>
        </table>
        <table>
            <tr>
                <td>
                    &nbsp;</td>

            </tr>


        </table>
    </fieldset>


    <table>
        <tr>
            <td>
                <asp:GridView ID="gvordencompra" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="ANT_CODIGO" HeaderText="N° SOLICITUD" />
                        <asp:BoundField DataField="OC_CNUMORD" HeaderText="N° DOCUMENTO" />
                        <asp:BoundField DataField="OC_CCODPRO" HeaderText="RUC" />
                        <asp:BoundField DataField="OC_CRAZSOC" HeaderText="PROVEEDOR" />
                        <asp:BoundField DataField="OC_FECEMI" HeaderText="EMISION" />
                        <asp:BoundField DataField="OC_FECPRO" HeaderText="PROCESO" />
                        <asp:BoundField DataField="OC_CODMON" HeaderText="MONEDA" />
                        <asp:BoundField DataField="OC_MONTO_PEDIDO" HeaderText="MONTO PEDIDO" />
                        <asp:BoundField DataField="OC_PERCENTAJE" HeaderText="%." />
                        <asp:BoundField DataField="OC_ANTICIPO" HeaderText="ANTICIPO" />
                        <asp:BoundField DataField="OC_TOTAL_PAGAR" HeaderText="TOT. PAGADO" />
                        <asp:BoundField DataField="MOTIVO" HeaderText="MOTIVO" />

                        <asp:BoundField DataField="BANCO" HeaderText="BANCO" />

                        <asp:BoundField HeaderText="USER1" />
                        <asp:BoundField HeaderText="USER2" />
                        <asp:BoundField HeaderText="USER3" />
                        <asp:BoundField HeaderText="USER4" />

                        <asp:BoundField DataField="APROB" HeaderText="SITUACIÓN" />

                        <asp:TemplateField HeaderText="VER">
                            <ItemTemplate>
                                <div class="btvisualizar" style="text-align: center">
                                    <img alt="" src="../Images/Message_Information.png" width="25" style="cursor: pointer" />
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

    <div id="dvdetalle" style="display:none">
       
        <table>
            <tr>
                <td>Número Solicitud</td>

                <td>
                    <asp:Label ID="lblsolicitud" runat="server" BackColor="#66FF66"></asp:Label>
                </td>
                <td class="auto-style5"> Nro. Orden 
                    <br />
                    Compra </td> 
                <td>
                    <asp:TextBox ID="txtorden" runat="server" Width="135px"></asp:TextBox>
                 </td>
                 <td>
                     <input id="btnonsultaroc" type="button" value="Consultar OC" class="btproveedordatos" />
                 </td>
            </tr>

           
            <tr>
                <td class="auto-style1"> Ruc Proveedor</td>
                <td> <asp:Label ID="lblruc" runat="server" BackColor="Yellow"></asp:Label>&nbsp;&nbsp;&nbsp; </td>
                 <td class="auto-style5">Proveedor</td>
                <td> <asp:Label ID="lblrazonsocial" runat="server" BackColor="Yellow"></asp:Label></td>

            </tr>
            <tr>
                 <td>Cod.Solicitante:</td>
                <td> <asp:Label ID="lblcodsol" runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp; </td>
                 <td class="auto-style5">Solicitante</td>
                <td>  <asp:Label ID="lblsolicitante" runat="server" Text=""></asp:Label></td>
                           
               
            </tr>
            <tr>
                <td class="auto-style1"> Cuenta Proveedor</td> <td>
                    <asp:TextBox ID="txtcuentaprov" runat="server" Width="201px"></asp:TextBox> </td>
            </tr>
            <tr>
                <td class="auto-style1"> Fecha Emision</td> <td>
                    <asp:TextBox ID="txtfechaemision" runat="server" Width="201px" placeholder="00/00/0000"></asp:TextBox> </td>
                <td class="auto-style5"> Fecha Proceso</td> <td>
                    <asp:TextBox ID="txtfechaproceso" runat="server" Width="135px" placeholder="00/00/0000"></asp:TextBox> </td>
            </tr>
            
              <tr>
                <td class="auto-style1"> Moneda </td> <td> 
                  <asp:Label ID="lblmone" runat="server" Text=""></asp:Label>
                     <asp:Label ID="lblmoneda" runat="server" Text=""></asp:Label>
                  &nbsp;</td>
            </tr>
              <tr>
                <td class="auto-style1"> Monto Total Pedido</td> <td>
                    <asp:TextBox ID="txtmsolicitado" runat="server" Enabled="False" Width="201px"></asp:TextBox> </td>
                  <td class="auto-style5"> Detracción </td>
                <td> <asp:TextBox ID="txtdetraccion" runat="server" Width="60px"></asp:TextBox>%
                    <asp:Label ID="lbldetraccion" runat="server" Text=""></asp:Label> 
                </td>
            </tr>
            <tr>
                <td class="auto-style1"> Porcenaje</td> <td>
                    <asp:TextBox ID="txtporcentaje" runat="server" Enabled="True" Width="201px"></asp:TextBox> </td>
             <td>Retención</td>
                <td> <asp:TextBox ID="txtretencion" runat="server" Width="60px"></asp:TextBox>% <asp:Label ID="lblretencion" runat="server" Text=""></asp:Label> </td>
                 <td class="auto-style5">
                <input id="btncalcular" type="button" value="calcular" class="total"/>
            </tr>
            <tr>
                <td class="auto-style1"> Anticipo</td> <td>
                    <asp:TextBox ID="txtanticipo" runat="server" Enabled="False" Width="201px"></asp:TextBox> </td>
                <td class="auto-style1"> Total a Pagar</td> <td>
                    <asp:TextBox ID="txtmpagar" runat="server" Enabled="False" Width="135px"></asp:TextBox> </td>
            </tr>
                        
                    </table>
            <table>
            
            <tr>
                <td class="auto-style1"> Motivo</td> <td> <asp:TextBox ID="txtmotivo" runat="server" Height="75px" TextMode="MultiLine" Width="416px"></asp:TextBox></td>
            </tr>

            <tr>
                <td class="auto-style1"> Cuenta de Banco</td> <td> 
                <asp:DropDownList ID="ddlbanco" runat="server" Height="24px" Width="193px">
                </asp:DropDownList>
                </td>
                <td class="auto-style5">
                      <%--<asp:ImageButton ID="imbeliminar" runat="server" ImageUrl="~/Images/Message_Error.png" Width="25px" OnClick="ib_eliminar_Click" onclientclick="javascript:return confirm('Esta Seguro?')"/>--%>
                </td>
            </tr>
          
            <tr>
                <td class="auto-style2"> Monto Anterior</td>
               <td class="auto-style3">
                    <asp:TextBox ID="txtanterior" runat="server" Width="84px" Enabled="False"></asp:TextBox> 
                </td> </tr>
                <tr>
                <td>Plazo (Dias)
                </td>
                <td>
                    <asp:TextBox ID="txtdias" runat="server" Width="84px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtidnumoc" runat="server" Width="0px" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="txtusu1" runat="server" Width="0px" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="txtusu2" runat="server" Width="0px" BorderStyle="None" ForeColor="White"></asp:TextBox>
                    <asp:TextBox ID="txtusu3" runat="server" Width="0px" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="txtusu4" runat="server" Width="0px" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="txtestadooc" runat="server" Width="0px" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="txtest" runat="server" Width="0px" BorderStyle="None"></asp:TextBox>

                </td>
                <td>
                    <asp:TextBox ID="txtindicador" runat="server" Width="0px" Enabled="False" BorderStyle="None"></asp:TextBox>
                </td>
               </tr>
            
            <tr>
                <td>
                     <input id="btngrabar" type="button" value="Grabar" class="btgrabar"/>
                </td>
                <td>
                    <input id="btnaprobar" type="button" value="Aprobar" class="btapro" style="width:74px; height:28px; color: #003366; background-color: #99CCFF"  />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input id="btdesapro" type="button" value="Desaprobar" class="btdesapro" style="width:74px; height:28px; color: #003366; background-color: #99CCFF" />
                </td>
                
            </tr>
        </table>

    </div>

</asp:Content>

