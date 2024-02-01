<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="LiquidacionAnticipo.aspx.cs" Inherits="Default2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server"> 

    

    <script type="text/javascript">
        $(function () {
            $("#MainContent_txtfecha2").datepicker();
            $("#MainContent_txtfecha1").datepicker();
            $("#MainContent_txtfechaproceso").datepicker();
            $("#MainContent_txtfechaemision").datepicker();

            $("#MainContent_txtsolicitud").autocomplete(
             {
             source: function (request, response) {
            $.ajax({
            url: "LiquidacionAnticipo.aspx/AnticipoOrden",
            data: "{ 'dato': '" + $("#MainContent_txtorden").val() + "','ant': '" + request.term + "' }",
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataFilter: function (data) { return data; },
            success: function (data) {
                response($.map(data.d, function (item) {
                    return {
                        value: item.ANT_CODIGO,
                        id: item.ANT_CODIGO
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
        $('#MainContent_txtsolicitud').val(str);


    }
});



            $("#MainContent_txtorden").autocomplete(
{
    source: function (request, response) {
        $.ajax({
            url: "LiquidacionAnticipo.aspx/getordenes",
            data: "{ 'productos': '" + request.term + "' }",
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataFilter: function (data) { return data; },
            success: function (data) {
                response($.map(data.d, function (item) {
                    return {
                        value: item.OC_CNUMORD,
                        id: item.OC_CNUMORD

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
        // $('#MainContent_txtidpro').val(str);


    }
});

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

            $(".btbuscar").click(function () {
                filtarsolicitudes();
            });



            $(".btadd").click(function () { //  se debe colocar dentrp de una funcion 
                $("#dvdetalle").dialog('open');
                $("#MainContent_txtindicador").val("G");
                $("#MainContent_lblliquidacion").html("");
                $("#MainContent_txtorden").val("");
                //$("#MainContent_lblruc").html("");
                //$("#MainContent_lblrazonsocial").html("");
                //$("#MainContent_txtsolicitud").val("");
                //$("#MainContent_txtfechaemision").val("");
                //$("#MainContent_txtfechaproceso").val("");
                $("#MainContent_lblmoneda").html("");
                $("#MainContent_txtmsolicitado").val("");
                $("#MainContent_txtporcentaje").val("");
                $("#MainContent_txtanticipo").val("");
                $("#MainContent_txtmpagar").val("");
               
                if ($("#MainContent_txtindicador").val() == "G") {

                    $("#MainContent_txtorden").attr("disabled", false);
                    //$("#MainContent_txtsolicitud").attr("disabled", false);
                    //$("#MainContent_txtfechaemision").attr("disabled", true);
                    //$("#MainContent_txtfechaproceso").attr("disabled", false);
                    $("#MainContent_txtporcentaje").attr("disabled", true);
                    
                }

                document.getElementById("btnagregar").style.visibility = "visible";
                document.getElementById("btnonsultaroc").style.visibility = "visible";
                document.getElementById("btngrabar").style.visibility = "visible";

            });

            $(".btvisualizar").click(function () { //  se debe colocar dentrp de una funcion 
                $("#dvdetalle").dialog('open');
                $("#MainContent_txtindicador").val("V");

                trp = $(this).parent().parent();
                id = $("td:eq(0)", trp).html();
                $("#MainContent_lblliquidacion").html(id);

                trp = $(this).parent().parent();
                id = $("td:eq(1)", trp).html();
                $("#MainContent_txtsolicitud").val(id);
              
                trp = $(this).parent().parent();
                orden = $("td:eq(2)", trp).html();
                $("#MainContent_txtorden").val(orden);

                //trp = $(this).parent().parent();
                //ruc = $("td:eq(3)", trp).html();
                //$("#MainContent_lblruc").html(ruc);

                //trp = $(this).parent().parent();
                //prov = $("td:eq(4)", trp).html();
                //$("#MainContent_lblrazonsocial").html(prov);

                //trp = $(this).parent().parent();
                //emision = $("td:eq(5)", trp).html();
                //$("#MainContent_txtfechaemision").val(emision);

                //trp = $(this).parent().parent();
                //proceso = $("td:eq(6)", trp).html();
                //$("#MainContent_txtfechaproceso").val(proceso);

                //trp = $(this).parent().parent();
                //moneda1 = $("td:eq(7)", trp).html();
                //$("#MainContent_lblmoneda").html(moneda1);
               

                //trp = $(this).parent().parent();
                //total = $("td:eq(8)", trp).html();
                //$("#MainContent_txtmsolicitado").val(total);

                //trp = $(this).parent().parent();
                //porcentaje = $("td:eq(9)", trp).html();
                //$("#MainContent_txtporcentaje").val(porcentaje);

                //trp = $(this).parent().parent();
                //anticipo = $("td:eq(10)", trp).html();
                //$("#MainContent_txtanticipo").val(anticipo);

                //trp = $(this).parent().parent();
                //pagar = $("td:eq(11)", trp).html();
                //$("#MainContent_txtmpagar").val(pagar);
                
                if ($("#MainContent_txtindicador").val() == "V") {

                    $("#MainContent_txtorden").attr("disabled", true);
                    $("#MainContent_txtsolicitud").attr("disabled", true);
                    $("#MainContent_txtfechaemision").attr("disabled", true);
                    $("#MainContent_txtfechaproceso").attr("disabled", true);
                    $("#MainContent_txtporcentaje").attr("disabled", true);
                    $("#MainContent_txtmotivo").attr("disabled", true);
                    $("#MainContent_ddlbanco").attr("disabled", true);
                    $("#MainContent_txtdetraccion").attr("disabled", true);
                    $("#MainContent_txtretencion").attr("disabled", true);
                    $("#MainContent_txtdias").attr("disabled", true);
                    $("#MainContent_txtfacturadet").attr("disabled", true);
                    $("#MainContent_txtmontodet").attr("disabled", true);
                    $("#MainContent_txttotal").attr("disabled", true);

                }

                filtardetalle()
                document.getElementById("btnagregar").style.visibility = "hidden";
                document.getElementById("btnonsultaroc").style.visibility = "hidden";
                document.getElementById("btngrabar").style.visibility = "hidden";

            });

            $(".imprimi").click(function () {

                var trp = $(this).parent().parent();
                var idnumor = $("td:eq(0)", trp).html();
              
                window.open("../ANTICIPO/REPORTES/RptLiquidacion.aspx?ID= " + idnumor, '_blank');
                
            });

            $(".btgrabar").click(function () {

                if( recorregridvalidaragregar().bandera==0)
                { 
                    if ($("#MainContent_txtindicador").val() == "G") {
                            InsertarLiquidacion();
                            actualizarestadoanticipo();
                            iNSERTAdETALLE();                       
                     }
                    if ($("#MainContent_txtindicador").val() == "A") {
                                               
                        InsertarLiquidacion();
                        actualizarestadoanticipo();
                            ParaEliminar();
                            iNSERTAdETALLE();                                             

                    }
                }
                else {
                    alert("Cálculo Incorrecto!... Por favor verifique si cuadran los datos de la lista inferior.");
                }
               




            });
            

            $(".btaddact").click(function () { //  se debe colocar dentrp de una funcion 
                $("#dvdetalle").dialog('open');
                $("#MainContent_txtindicador").val("A");
                trp = $(this).parent().parent();
                id = $("td:eq(0)", trp).html();
                $("#MainContent_lblliquidacion").html(id);

               
                if ($("#MainContent_txtindicador").val() == "A") {

                   $("#MainContent_txtorden").attr("disabled", true);
                    //$("#MainContent_txtsolicitud").attr("disabled", true);
                    $("#MainContent_txtfechaemision").attr("disabled", true);
                    $("#MainContent_txtfechaproceso").attr("disabled", false);
                    $("#MainContent_txtporcentaje").attr("disabled", true);
                    $("#MainContent_txtmotivo").attr("disabled", false);
                    $("#MainContent_ddlbanco").attr("disabled", false);
                    $("#MainContent_txtdetraccion").attr("disabled", false);
                    $("#MainContent_txtretencion").attr("disabled", false);
                    $("#MainContent_txtdias").attr("disabled", false);
                }
                filtardetalle();
                traerorden();

                document.getElementById("btnagregar").style.visibility = "visible";
                //document.getElementById("btnonsultaroc").style.visibility = "hidden";
                document.getElementById("btngrabar").style.visibility = "visible";

            });




            //return { prov, ruc, odencompra, fechaemision, moneda, montototal, anticipo, porcentaje, pagado};
            $(".btproveedordatos").click(function () { //  se debe colocar dentrp de una funcion 
                if ($("#MainContent_txtindicador").val() == "G") {
                    var ultimodato = generar().contador;
                    var formato = ultimodato.length < 10 ? pad("0" + ultimodato, 10) : ultimodato;
                    $("#MainContent_lblliquidacion").html(formato);
                }
              
                var monedac = datosOrdenyProveedor().moneda;
                var totalorden = datosOrdenyProveedor().montototal;
                var anticipo = datosOrdenyProveedor().anticipo;
                var porcentaje = datosOrdenyProveedor().porcentaje;
                var pagado = datosOrdenyProveedor().pagado;
              
                if (datosOrdenyProveedor().moneda !=null) {
               
                $("#MainContent_lblmoneda").html(monedac);
                //$("#MainContent_txtorden").val(oc);
                $("#MainContent_txtmsolicitado").val(totalorden);
                $("#MainContent_txtanticipo").val(anticipo);
                $("#MainContent_txtporcentaje").val(porcentaje);
                $("#MainContent_txtmpagar").val(pagado);
              
                $("#MainContent_txtorden").attr("disabled", true);
                }

                else {
                    alert("No existen datos, verifique si la solicitud esta aprobada o ya ha sido liquidada.");

                }
            // }
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
                    filtarsolicitudes();
                    contarndw = 0;
                    contaditem = 0
                    cc = 1;
                },

                buttons: {

                    //  Grabar: function () {
                      
                    //}
                }

            });
        

                                  
               function limpiardatos() {

                $("#MainContent_txtindicador").val("");
                $("#MainContent_lblliquidacion").html("");
                $("#MainContent_txtorden").val("");
                $("#MainContent_lblruc").html("");
                $("#MainContent_lblrazonsocial").html("");
                $("#MainContent_txtsolicitud").val("");
                $("#MainContent_txtfechaemision").val("");
                $("#MainContent_txtfechaproceso").val("");
                $("#MainContent_lblmoneda").html("");
                $("#MainContent_txtmsolicitado").val("0.00");
                $("#MainContent_txtporcentaje").val("0.00");
                $("#MainContent_txtanticipo").val("0.00");
                $("#MainContent_txtmpagar").val("0.00");
                $("#MainContent_txtmotivo").val("");
                $("#MainContent_txtorden").attr("disabled", true);
                $("#MainContent_txtsolicitud").attr("disabled", false);
                $("#MainContent_txtfechaemision").attr("disabled", true);
                $("#MainContent_txtfechaproceso").attr("disabled", false);
                $("#MainContent_txtporcentaje").attr("disabled", true);
                $("#MainContent_txtfacturadet").attr("disabled", false);
                $("#MainContent_txtmontodet").attr("disabled", false);
                $("#MainContent_txttotal").attr("disabled", true);
                $("#MainContent_txtfacturadet").val("");
                $("#MainContent_txtmontodet").val("");
                $("#MainContent_txttotal").val("0.00");

                var row = $("[id*=GridView1] tr:last-child").clone(true);
                $("[id*=GridView1] tr").not($("[id*=GridView1] tr:first-child")).remove();

                $("td", row).eq(0).val("");
                $("td", row).eq(0).html("");
                $("td", row).eq(1).html("");
                $("td", row).eq(2).html("");
                $("td", row).eq(3).html("");

                $("[id*=GridView1]").append(row);
                              
               }

              
                              
           function iNSERTAdETALLE() {
              var DETAIL = {};
              var gridView = document.getElementById("<%=GridView1.ClientID %>");
              for (var t = 1; t < gridView.rows.length; t++)
              {
                  var inputs = gridView.rows[t].getElementsByTagName('input');                 
                  DETAIL.FACTURA = gridView.rows[t].cells[0].innerHTML;
                     DETAIL.MONTO = gridView.rows[t].cells[1].innerHTML;
                     DETAIL.LIQ_NUMERO = $("#MainContent_lblliquidacion").html();
                     DETAIL.ANT_CODIGO = gridView.rows[t].cells[2].innerHTML;


              $.ajax({

                  type: "POST",
                  url: "LiquidacionAnticipo.aspx/InsertaDetalle",
                  data: '{DETAIL: ' + JSON.stringify(DETAIL) + '}',
                  contentType: "application/json; charset=utf-8",
                  dataType: "json",
                  async: false,
                  success: function (response) {
                  },
                  error: function (response) {
                      if (response.length != 0)
                          console.table(response);
                  }

              });
             
             }
           }
                        
            function actualizarestadoanticipo() {
                var solicitud = {};
                var gridView = document.getElementById("<%=GridView1.ClientID %>");
                var ant="";
                     for (var R = 1; R < gridView.rows.length; R++) {
                    var inputs = gridView.rows[R].getElementsByTagName('input');
                    ant = gridView.rows[R].cells[2].innerHTML;
                
                    solicitud.ANT_CODIGO = ant;
                    solicitud.ESTADO = "L";
               // if ($("#MainContent_txtindicador").val() == "G") {
                    $.ajax({

                        type: "POST",
                        url: "LiquidacionAnticipo.aspx/ActualizaSolicitud",
                        data: '{solicitud: ' + JSON.stringify(solicitud) + '}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (response) {

                           // 
                          
                        },
                        error: function (response) {
                            if (response.length != 0)
                                alert(response);
                        }

                    });

                //}
            }

            }

            function InsertarLiquidacion() {

                var fecemi = moment($("#MainContent_txtfechaemision").val(), "DD/MM/YYYY");
                fecemi = fecemi == null ? null : new Date(fecemi);
                var fecpro = moment($("#MainContent_txtfechaproceso").val(), "DD/MM/YYYY");
                fecpro = fecpro == null ? null : new Date(fecpro);
                var DETA = {};
                DETA.FECHA_EMISION = fecemi;
                DETA.FECHA_REG = fecpro;
                //DETA.ANT_CODIGO = $("#MainContent_txtsolicitud").val();
                DETA.LIQ_NUMERO = $("#MainContent_lblliquidacion").html();
                DETA.ESTADO="V";

                if (( DETA.OC_CNUMORD =="") || (DETA.OC_CCODPRO=="") || ( DETA.OC_CRAZSOC=="") ||( DETA.OC_CODMON=="") || ( DETA.OC_MONTO_PEDIDO=="") || ( DETA.OC_PERCENTAJE==0) || ( DETA.OC_ANTICIPO==0) || ( DETA.OC_TOTAL_PAGAR==0) || ( DETA.OC_CTAPROVEEDOR=="") || ( DETA.OC_BANCO=="") || ( DETA.ANT_CODIGO=="") ||  (DETA.BANCO=="")) 
                {
                    alert("Complete los Datos antes de continuar");

                }
                else{

                if ($("#MainContent_txtindicador").val() == "G") {
                    $.ajax({

                        type: "POST",
                        url: "LiquidacionAnticipo.aspx/InsertaDet",
                        data: '{DETA: ' + JSON.stringify(DETA) + '}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (response) {
                            alert("Registro Grabado");
                          },
                        error: function (response) {
                            if (response.length != 0)
                                alert(response);
                        }
                    });
                }

                if ($("#MainContent_txtindicador").val() == "A") {
                  
                    $.ajax({

                        type: "POST",
                        url: "LiquidacionAnticipo.aspx/ActualizaLiquidacion",
                        data: '{DETA: ' + JSON.stringify(DETA) + '}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (response) {
                            alert("Registro Actualizado");
                           // $("#dvdetalle").dialog('close');
                        },
                        error: function (response) {
                            if (response.length != 0)
                                //alert(response);
                                console.table(response);
                        }

                    });
                }
                filtarsolicitudes();
                }

            }

            $(window).load(function () {
                contarndw = 0;
                cc = 1;
                sw_edicion = 0;
                sw_nuevo = 0;
                contaditem = 0;

            });

                     
            function datosOrdenyProveedor() {
                var codigowh = $("#MainContent_txtsolicitud").val();

                if (codigowh != "") {
                    var prov = "";
                    var ruc = "";
                    var odencompra = "";
                    var fechaemision = "";
                    var moneda = "";
                    var montototal = "0.00";
                    var anticipo = "0.00";
                    var porcentaje = "0.00";
                    var pagado = "0.00";

                    $.ajax({

                        type: "POST",
                        url: "LiquidacionAnticipo.aspx/DatosSolicitud",
                        data: "{dato: '" + codigowh + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (data) {

                            if (data.d.OC_CODMON.trim != "") {
                                moneda = data.d.OC_CODMON;
                                montototal = data.d.OC_MONTO_PEDIDO;
                                anticipo = data.d.OC_ANTICIPO;
                                porcentaje = data.d.OC_PERCENTAJE;
                                pagado = data.d.OC_TOTAL_PAGAR;
                                estado = data.d.ESTADO;
                              }
                            else {
                                alert("No existen datos para esta Solicitud")
                            }

                        },
                        error: function (data) {
                            if (data.length != 0)
                                alert(data);
                        }

                    });
                    return { moneda, montototal, anticipo, porcentaje, pagado, estado};

                }
                else {
                    alert("Por favor ingrese una solicitud")
                }
            }


            function generar() {
                var liquidacion = "";
                var contador = "";

                $.ajax({

                    type: "POST",
                    url: "LiquidacionAnticipo.aspx/GENERAR",
                    data: "{solicitud: '" + liquidacion + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
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

                $.ajax({

                    type: "POST",
                    url: "LiquidacionAnticipo.aspx/ListarLiquidaciones",
                    data: '{VC: ' + JSON.stringify(VC) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        if (data.d.length > 0) {
                            var row = $("[id*=gvordencompra] tr:last-child").clone(true);
                            $("[id*=gvordencompra] tr").not($("[id*=gvordencompra] tr:first-child")).remove();

                            for (var i = 0; i < data.d.length; i++) {
                                $("td", row).eq(0).html(data.d[i].LIQ_NUMERO);
                                $("td", row).eq(1).html(data.d[i].ANT_CODIGO);
                                $("td", row).eq(2).html(data.d[i].OC_CNUMORD);
                                $("td", row).eq(3).html(data.d[i].RUC);
                                $("td", row).eq(4).html(data.d[i].PROVEEDOR);
                                $("td", row).eq(5).html(data.d[i].FECHA_EMISION);
                                $("td", row).eq(6).html(data.d[i].FECHA_REG);
                                $("td", row).eq(7).html(data.d[i].MONEDA);
                                $("td", row).eq(8).html(data.d[i].MONTOTOTAL);
                                $("td", row).eq(9).html(data.d[i].PORCENTAJE);
                               $("td", row).eq(10).html(data.d[i].ANTICIPO);
                               $("td", row).eq(11).html(data.d[i].PAGADO);
                              
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
                            $("td", row).eq(7).html("");
                            $("td", row).eq(8).html("");
                            $("td", row).eq(9).html("");
                            $("td", row).eq(10).html("");
                            $("td", row).eq(11).html("");
                                                      
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
            
            function calculartotales() {

                if ($("#MainContent_txtindicador").val() == "A" || $("#MainContent_txtindicador").val() == "G") {

                    var montofinal = $("#MainContent_txtmsolicitado").val() * ($("#MainContent_txtporcentaje").val() / 100);

                if (montofinal > 0)
                {
                if ((montofinal + parseFloat($("#MainContent_txtanterior").val())) <= $("#MainContent_txtmsolicitado").val())
                {
                    $("#MainContent_txtanticipo").val(montofinal);
                    var detraccion = montofinal * ($("#MainContent_txtdetraccion").val() / 100);
                    var retencion = montofinal * ($("#MainContent_txtretencion").val() / 100);
                    alert(detraccion);
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

            }



            function pad(str, max) {
                if (str != undefined) {
                    str = str.toString();
                    return str.length < max ? pad("0" + str, max) : str;
                }
            }

            /////////////////////////////////////detalle liquideacion //////////////////////////////


            function ParaEliminar() {

                var VC = {};
                VC.LIQ_NUMERO = $("#MainContent_lblliquidacion").html();
                $.ajax({
                    type: "POST",
                    url: "LiquidacionAnticipo.aspx/ListarDetalle",
                    data: '{VC: ' + JSON.stringify(VC) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                   async: false,
                    success: function (data) {

                        if (data.d.length > 0) {
                            
                            for (var i = 0; i < data.d.length; i++) {

                                //alert(data.d[i].CODIGO);
                              eliminardetalle(data.d[i].CODIGO);
                                //$("td", row).eq(0).html(data.d[i].FACTURA);
                                //$("td", row).eq(1).html(data.d[i].MONTO);
                            }
                           
                        }
                        else {
                           
                        }
                    },
                    error: function (response) {
                        if (response.length != 0)
                            alert(response);
                    }
                });

            }



            function filtardetalle() {

                var VC = {};
                VC.LIQ_NUMERO = $("#MainContent_lblliquidacion").html();
                $.ajax({
                    type: "POST",
                    url: "LiquidacionAnticipo.aspx/ListarDetalle",
                    data: '{VC: ' + JSON.stringify(VC) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {

                        if (data.d.length > 0) {
                            var row = $("[id*=GridView1] tr:last-child").clone(true);
                            $("[id*=GridView1] tr").not($("[id*=GridView1] tr:first-child")).remove();

                            for (var i = 0; i < data.d.length; i++) {

                                $("td", row).eq(0).val(data.d[i].CODIGO);
                                $("td", row).eq(0).html(data.d[i].FACTURA);
                                $("td", row).eq(1).val(data.d[i].estado);
                                $("td", row).eq(1).html(data.d[i].MONTO);
                                $("td", row).eq(2).html(data.d[i].ANT_CODIGO);
                                $("td", row).eq(3).html(data.d[i].MONTO_ANTICIPO);
                               
                               // contaditem = Number(data.d[i].OC_CITEM);
                               // contarndw = contarndw + 1;
                                cc = 2;
                                $("[id*=GridView1]").append(row);
                                row = $("[id*=GridView1] tr:last-child").clone(true);
                            }
                            var sub01 = recorregrid().sumasub;
                            $("#MainContent_txttotal").val(sub01.toFixed(2));                       

                        } else {
                            var row = $("[id*=GridView1] tr:last-child").clone(true);
                            $("[id*=GridView1] tr").not($("[id*=GridView1] tr:first-child")).remove();

                            $("td", row).eq(0).val("");
                            $("td", row).eq(0).html("");
                            $("td", row).eq(1).html("");
                            $("td", row).eq(2).html("");
                            $("td", row).eq(3).html("");
                           
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

            function recorregrid() {
                contarndw = 0;
            subtt = 0; descc = 0; igvv = 0;
            sumasub = 0; suu = 0;

            var gridView = document.getElementById("<%=GridView1.ClientID %>");

            for (var t = 1; t < gridView.rows.length; t++) {
                var inputs = gridView.rows[t].getElementsByTagName('input');

                cellPivot = gridView.rows[t].cells[1];
                cellPivot1 = gridView.rows[t].cells[3];
                subtt = cellPivot.innerHTML;
                suu = cellPivot1.innerHTML;
                if (Number(suu)> Number(subtt)){
                    sumasub = new Number(sumasub) + Math.abs(new Number(subtt));
                }
                else {
                    if (Number(suu)< Number(subtt)){
                    sumasub = new Number(sumasub) + Math.abs(new Number(suu));
                    }
                    else {
                        sumasub = new Number(sumasub) + Math.abs(new Number(subtt));
                    }
                }
                
               contarndw++;
               }

            return {
                sumasub
            };
        }
            
            function recorregrid1() {
                contarndw = 0;
            subtt = 0; descc = 0; igvv = 0;
            sumasub = 0;
           
            //sumadesc = 0; sumaigvv = 0; sumatotall = 0;

            var gridView = document.getElementById("<%=GridView1.ClientID %>");

            for (var t = 1; t < gridView.rows.length; t++) {
                var inputs = gridView.rows[t].getElementsByTagName('input');
                if ((gridView.rows[t].cells[0].innerHTML != $("#MainContent_txtfacturadet").val()) || (gridView.rows[t].cells[2].innerHTML != $("#MainContent_txtsolicitud").val()))
                {
                    cellPivot = gridView.rows[t].cells[1];
                    cellPivot1 = gridView.rows[t].cells[3];
                    suu = cellPivot1.innerHTML;
                    subtt = cellPivot.innerHTML;
                    if (Number(suu) > Number(subtt)) {
                        sumasub = new Number(sumasub) + Math.abs(new Number(subtt));
                    }
                    else {
                        if (Number(suu) < Number(subtt)) {
                            sumasub = new Number(sumasub) + Math.abs(new Number(suu));
                        }
                        else {
                            sumasub = new Number(sumasub) + Math.abs(new Number(subtt));
                        }
                    }
                }               
               contarndw++;
               }

            return {
                sumasub
            };
            }
             function recorregridvalidaragregar() {
                 var subtotal = 0;
                 var sumatotal = 0;
                 var factura = "";
                 var montofac = 0;
                 var anticipo = "";
                 var monto_anticipo = 0;
                 var bandera = 0;

             var gridView = document.getElementById("<%=GridView1.ClientID %>");

            for (var t = 1; t < gridView.rows.length; t++) {
                var inputs = gridView.rows[t].getElementsByTagName('input');
                factura = gridView.rows[t].cells[0].innerHTML;
                montofac = Number(gridView.rows[t].cells[1].innerHTML);
                anticipo = gridView.rows[t].cells[2].innerHTML;
                monto_anticipo = gridView.rows[t].cells[3].innerHTML;

               
                if (Number(montofac) > Number(monto_anticipo)) {
                    //inicio  for 2
                    for (var u = 1; u < gridView.rows.length; u++) {
                        cellfac= gridView.rows[u].cells[0];
                    if (factura ==cellfac.innerHTML)
                    {  cellPivot = gridView.rows[u].cells[3];
                       subtotal = cellPivot.innerHTML;
                       sumatotal = new Number(sumatotal) + new Number(subtotal);
                    }
                   
                }  //fin for2 
               // alert(sumatotal);
                    
                if (Number(montofac) == Number(sumatotal)) {
                    bandera = bandera + 0;
                }
                else { bandera = bandera + 1; }
                }

                if (Number(montofac) < Number(monto_anticipo)) {
                    //inicio  for 2
                    for (var u = 1; u < gridView.rows.length; u++) {
                        cellfac = gridView.rows[u].cells[2];
                        if (anticipo == cellfac.innerHTML) {
                            cellPivot = gridView.rows[u].cells[1];
                            subtotal = cellPivot.innerHTML;
                            sumatotal = new Number(sumatotal) + new Number(subtotal);
                        }

                    }  //fin for2 
                    // alert(sumatotal);

                    if (Number(monto_anticipo).toFixed(2) == Number(sumatotal).toFixed(2)) {
                        bandera = bandera + 0;
                    }
                    else {
                        bandera = bandera + 1;
                        
                    }
                  
                }



                subtotal = 0;
                sumatotal = 0;
                


               }

            return {
                bandera
            };
        }

             function validaredicion() {
                contarndw = 0;
            subtt = 0; descc = 0; igvv = 0;
            sumasub = 0;
           
           var gridView = document.getElementById("<%=GridView1.ClientID %>");

            for (var t = 1; t < gridView.rows.length; t++) {
                var inputs = gridView.rows[t].getElementsByTagName('input');
                if ((gridView.rows[t].cells[0].innerHTML == $("#MainContent_txtaux").val()) && (gridView.rows[t].cells[2].innerHTML == $("#MainContent_txtsolicitud").val()))
                {
                    gridView.rows[t].cells[0].innerHTML = $("#MainContent_txtfacturadet").val();
                    gridView.rows[t].cells[1].innerHTML = $("#MainContent_txtmontodet").val();
                    gridView.rows[t].cells[2].innerHTML = $("#MainContent_txtsolicitud").val();
                    gridView.rows[t].cells[3].innerHTML = $("#MainContent_txtmpagar").val();
               
                }               
              
               }

            return {
                //sumasub
            };
        }




            $(".btaddgrilla").click(function () {
                if ($("#MainContent_txtindicador").val() != "V") {
                    AgregarGrilla();
                }
            });

            function AgregarGrilla() {
                if ($("#MainContent_txtaux").val() == "")  ///en caso de ser nuevo
                {
                   contaditem = contaditem + 1;
                    if ($("#MainContent_txtsolicitud").val() != "" || $("#MainContent_lblliquidacion").html() != "" || $("#MainContent_txtfacturadet").val() != "" || $("#MainContent_txtmontodet").val() != "")
                    {
                        var rowt = 0;
                        rowt = $("[id*=GridView1] tr:last-child").clone(true);
                        if (cc == 1) {
                            $("[id*=GridView1] tr").not($("[id*=GridView1] tr:first-child")).remove();
                            cc = 2; }
                        contarndw = 0;
                        contaditem = 0;
                        $("td", rowt).eq(0).html($("#MainContent_txtfacturadet").val());
                        $("td", rowt).eq(1).html($("#MainContent_txtmontodet").val());
                        $("td", rowt).eq(2).html($("#MainContent_txtsolicitud").val());
                        $("td", rowt).eq(3).html($("#MainContent_txtanticipo").val());
                        $("[id*=GridView1]").append(rowt);
                        rowt = $("[id*=GridView1] tr:last-child").clone(true);
                        contarndw = contarndw + 1;
                        //
                      
                        $("#MainContent_txtfacturadet").val("");
                        $("#MainContent_txtmontodet").val(""); }
                    else {
                        alert("Ingrese los Datos completos");
                    }
                
                }
                else {  // en caso de edicion               
                    var numcondicion = parseFloat($("#MainContent_txttotal").val()) + parseFloat($("#MainContent_txtmontodet").val());
                    validaredicion();
                    $("#MainContent_txtfacturadet").val("");
                    $("#MainContent_txtmontodet").val("");
                    $("#MainContent_txtaux").val("");
                    $("#MainContent_txtsolicitud").val("");
                    $("#MainContent_txtmpagar").val("");
                    //var sub01 = recorregrid().sumasub;
                    //$("#MainContent_txttotal").val(sub01.toFixed(2));
                    //sub01 = 0;

                    
                }
                var sub01 = recorregrid().sumasub;
                $("#MainContent_txttotal").val(sub01.toFixed(2));
                sub01 = 0;
            }

            $(".btelimina").click(function () {
                if ($("#MainContent_txtindicador").val() != "V")
                {
                    trpe = $(this).parent().parent();
                    exte = $("td:eq(1)", trpe).val();
                    if (exte == "L") {
                        alert("No es posible eliminar este item porque ya se encuentra liquidado");
                    }
                    else{ 
                        var trp = $(this).parent().parent();
                        if (Number(contarndw) > 1) {
                            trp.remove();
                            contarndw = Number(contarndw) - 1;
                        } else {
                            $("td:eq(0)", trp).val(""); $("td:eq(0)", trp).html("");
                            $("td:eq(1)", trp).html("");
                            cc = 1;
                        }
                    }
                    var sub01 = recorregrid().sumasub;
                    $("#MainContent_txttotal").val(sub01.toFixed(2));
                    sub01 = 0;                                       
                }
               });

               $(".bteditar").click(function () {
                   if ($("#MainContent_txtindicador").val() != "V") {
                       trp = $(this).parent().parent();
                       ext = $("td:eq(1)", trp).val();
                       if (ext =="L"){
                           alert("No es posible Modificar este item porque ya esta liquidado");
                       }
                       else{ 
                       sub01 = 0;
                       trp = $(this).parent().parent();
                       codigo = $("td:eq(0)", trp).val();
                       $("#MainContent_lblcodetalle").html(codigo)

                       trp = $(this).parent().parent();
                       factura = $("td:eq(0)", trp).html();
                       $("#MainContent_txtfacturadet").val(factura)
                       $("#MainContent_txtaux").val(factura)

                       trp = $(this).parent().parent();
                       monto = $("td:eq(1)", trp).html();
                       $("#MainContent_txtmontodet").val(monto)
                       anticipo = $("td:eq(2)", trp).html();
                       $("#MainContent_txtsolicitud").val(anticipo)
                       monto_a = $("td:eq(3)", trp).html();
                       $("#MainContent_txtanticipo").val(monto_a)
                   }
                       var sub01 = recorregrid1().sumasub;
                       $("#MainContent_txttotal").val(sub01.toFixed(2));
                       sub01 = 0;
                       
                      }
               });

               function eliminardetalle(codigo) {
                var DETA = {};
                DETA.CODIGO = codigo;
                     $.ajax({

                        type: "POST",
                        url: "LiquidacionAnticipo.aspx/deleteDet",
                        data: '{DETA: ' + JSON.stringify(DETA) + '}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        //async: false,
                        success: function (response) {
                            //alert("Registro ELIMINADO detalle");
                        },
                        error: function (response) {
                            if (response.length != 0)
                                console.table(response);
                        }

                    });

                //}
      
               }
               function traerorden() {

                   var solicitud = "";
                   var orden = "";
                     var gridView = document.getElementById("<%=GridView1.ClientID %>");
                     for (var t = 1; t < gridView.rows.length; t++) {
                         solicitud = gridView.rows[t].cells[2].innerHTML;
                       //  alert(solicitud);
                       $.ajax({
                           type: "POST",
                           url: "LiquidacionAnticipo.aspx/traerorden",
                           data: "{solicitud: '" + solicitud + "'}",
                           contentType: "application/json; charset=utf-8",
                           dataType: "json",
                           async: false,
                           success: function (data) {
                               $("#MainContent_txtorden").val(data.d);
                           },
                           error: function (data) {
                               if (data.length != 0)
                                   alert(data);
                           }
                       });
                   }
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
                    <asp:TextBox ID="txtprove" runat="server" Width="300"></asp:TextBox>
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
                    <input id="btnnuevo" type="button" value="Nuevo" class="btadd" /></td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    <input class="btbuscar" value="Buscar" type="button" style="width: 80px" />
                    <asp:Label ID="lblusuario" runat="server" ForeColor="#66CCFF"></asp:Label>
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
                        <asp:BoundField HeaderText="NUM. LIQ." DataField="LIQ_NUMERO" />
                        <asp:BoundField DataField="ANT_CODIGO" HeaderText="N° SOLICITUD" />
                        <asp:BoundField DataField="OC_CNUMORD" HeaderText="N° DOCUMENTO" />
                        <asp:BoundField DataField="RUC" HeaderText="RUC" />
                        <asp:BoundField DataField="PROVEEDOR" HeaderText="PROVEEDOR" />
                        <asp:BoundField DataField="FECHA_EMISION" HeaderText="EMISION" />
                        <asp:BoundField DataField="FECHA_REG" HeaderText="REGULARIZACION" />
                        <asp:BoundField DataField="MONEDA" HeaderText="MONEDA" />
                        <asp:BoundField DataField="MONTOTOTAL" HeaderText="MONTO PEDIDO" />
                        <asp:BoundField DataField="PORCENTAJE" HeaderText="%." />
                        <asp:BoundField DataField="ANTICIPO" HeaderText="ANTICIPO" />
                        <asp:BoundField DataField="PAGADO" HeaderText="TOT. PAGADO" />

                        <asp:TemplateField HeaderText="VER">
                            <ItemTemplate>
                                <div class="btvisualizar" style="text-align: center">
                                    <img alt="" src="../Images/Message_Information.png" width="25" style="cursor: pointer" />
                                    <%--<asp:ImageButton ID="imbeliminar" runat="server" ImageUrl="~/Images/Message_Error.png" Width="25px" OnClick="ib_eliminar_Click" onclientclick="javascript:return confirm('Esta Seguro?')"/>--%>
                                </div>
                            </ItemTemplate>

                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="EDITAR">

                            <ItemTemplate>
                                <div class="btaddact" style="text-align: center">
                                    <img alt="" src="../Images/edit.png" width="25" style="cursor: pointer" />
                                    <%--<asp:ImageButton ID="imbeliminar" runat="server" ImageUrl="~/Images/Message_Error.png" Width="25px" OnClick="ib_eliminar_Click" onclientclick="javascript:return confirm('Esta Seguro?')"/>--%>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="IMPRIMIR">
                         <ItemTemplate>
                                <div class="imprimi" style="text-align: center">
                                    <img alt="" src="../Images/Printer.png" width="25" style="cursor: pointer" />
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

    <div id="dvdetalle">
       
        <table>
            <tr>
                <td>Número Liquidación</td>

                <td>
                    <asp:Label ID="lblliquidacion" runat="server"></asp:Label>
                </td>
            </tr>
             <tr>
                <td class="auto-style1"> Nro. Orden Compra </td> 
                <td>
                    <asp:TextBox ID="txtorden" runat="server" Width="202px"></asp:TextBox>
                 </td>
                <td>
                      &nbsp;</td>
               
                
            </tr>
              <tr>
                  <td>Selecciona un anticipo</td>
                  <td> 
                    <asp:TextBox ID="txtsolicitud" runat="server" Width="202px"></asp:TextBox>
                  </td>
                  
                   <td>
                      <input id="btnonsultaroc" type="button" value="Consultar " class="btproveedordatos" />
                 </td>
                  </tr>
            
              <tr>
                <td class="auto-style1"> Moneda </td> <td> 
                     <asp:Label ID="lblmoneda" runat="server" Text=""></asp:Label>
                  &nbsp;</td>
                   </tr>
             </table>
            <table>

              <tr>
            
                <td class="auto-style1"> Monto Total Pedido</td> <td>
                    <asp:TextBox ID="txtmsolicitado" runat="server" Enabled="False" Width="66px"></asp:TextBox> </td>
           
                <td class="auto-style1"> Porcenaje</td> <td>
                    <asp:TextBox ID="txtporcentaje" runat="server" Enabled="True" Width="64px"></asp:TextBox> </td>
            
           
                <td class="auto-style1"> Anticipo</td> <td>
                    <asp:TextBox ID="txtanticipo" runat="server" Enabled="False" Width="74px"></asp:TextBox> </td>
            
                <td class="auto-style1">Total Pagado</td> <td>
                    <asp:TextBox ID="txtmpagar" runat="server" Enabled="False" Width="104px"></asp:TextBox> </td>
            </tr>
                 </table>
         <table>
            <tr>
                <td>
                    <asp:TextBox ID="txtindicador" runat="server" Width="0px" Enabled="False" BorderStyle="None"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblcodetalle" runat="server" ForeColor="White" Width="0px"></asp:Label>
                    &nbsp;
                    <asp:TextBox ID="txtaux" runat="server" Width="0px" Enabled="True" BorderStyle="None"></asp:TextBox> 
                </td>
               
            <td> ****  AGREGAR DETALLE ****</td></tr>
            <tr> <td> Comprobante</td> <td>  <asp:TextBox ID="txtfacturadet" runat="server" Width="269px" Enabled="True"></asp:TextBox> </td>  </tr>
             <tr> <td> Monto</td> <td>  <asp:TextBox ID="txtmontodet" runat="server" Width="270px" Enabled="True" Height="23px"></asp:TextBox> </td> <td>
                 <input id="btnagregar" type="submit" value="Agregar" class="btaddgrilla" />&nbsp;
                                                                                                                                                     </td> </tr>


             </table>
         <fieldset style="background-color: #99CCFF">
        <table>
            <tr>

                <td>
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" Font-Size="Smaller" Width="483px">
                    <Columns>
                        <asp:BoundField HeaderText="FACTURA" DataField="FACTURA" />
                        <asp:BoundField DataField="MONTO" HeaderText="MONTO" />

                        <asp:BoundField DataField="ANTICIPO" HeaderText="ANTICIPO" />
                        <asp:BoundField DataField="MONTO_A" HeaderText="MONTO ANT." />

                        <asp:TemplateField HeaderText="EDITAR">
                            <ItemTemplate>
                                <div class="bteditar" style="text-align: center">
                                    <img alt="" src="../Images/edit.png" width="25" style="cursor: pointer" />
                                    
                                    <%--<asp:ImageButton ID="imbeliminar" runat="server" ImageUrl="~/Images/Message_Error.png" Width="25px" OnClick="ib_eliminar_Click" onclientclick="javascript:return confirm('Esta Seguro?')"/>--%>
                                </div>
                            </ItemTemplate>

                        </asp:TemplateField>
                         
                        <asp:TemplateField HeaderText="ELIMINAR">
                            <ItemTemplate>
                                <div class="btelimina" style="text-align: center">
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

        </table>
     </fieldset>

         <table>
            <tr>
                <td>Total Bruto:</td>
                <td>
                    <asp:TextBox runat="server" Width="150" ID="txttotal" Enabled="false" Style="text-align: right">0.00</asp:TextBox>
                </td>

            </tr>
              <tr>
                <td>
                     <input id="btngrabar" type="button" value="Grabar" class="btgrabar"/>
                </td>

            </tr>
                      
        </table>
        </div>


</asp:Content>
