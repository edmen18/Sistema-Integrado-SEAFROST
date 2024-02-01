﻿
<%@ Page Title="Contabilizacion" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Contabilizacion.aspx.cs" Inherits="FINANZAS_TESORERIA_CAJACHICA_Contabilizacion" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link type="text/css" href="../../../CSS/base.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {

            $(window).load(function () {
           });
            M_ARRAY = [];
            var iniciaPGE = function (CO) {
                var PDATA = {};
                PDATA.AF_COD = CO;
                $.ajax({
                    type: "POST",
                    url: "Contabilizacion.aspx/getPARAM",
                    data: '{ PDATA: ' + JSON.stringify(PDATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                       // console.log(data);
                        if (data.d.length > 0) {
                            jQuery.each(data.d, function (i, v) {
                               // console.log(v);
                                M_ARRAY.push(v.AF_TDESCRI1.trim(), v.AF_TDESCRI2.trim(), v.AF_TDESCRI3.trim());
                            });
                        } else {
                                }
                    },
                    error: function (response) {
                        console.table(response);
                    }
                });
            }
            iniciaPGE("RU");
            M_ARRAY27 = [];
            var iniciaPGE27 = function (CO) {
                var PDATA = {};
                PDATA.AF_COD = CO;
                $.ajax({
                    type: "POST",
                    url: "Contabilizacion.aspx/getPARAM",
                    data: '{ PDATA: ' + JSON.stringify(PDATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        //console.log(data);
                        if (data.d.length > 0) {
                            jQuery.each(data.d, function (i, v) {
                               // console.log(v);
                                M_ARRAY27.push(v.AF_TDESCRI1.trim(), v.AF_TDESCRI2.trim(), v.AF_TDESCRI3.trim());
                            });
                        } else {
                        }
                    },
                    error: function (response) {
                        console.table(response);
                    }
                });
            }
            iniciaPGE27("27");         

            $('.cont_sel').hide();           
            UHTML.id = 'MainContent';
            $("#MainContent_txtfecha").datepicker();
            $("#MainContent_txtfechaini").datepicker();
            $("#MainContent_txtfechafin").datepicker();



       $("#MainContent_txtcodsolicitanteb").autocomplete({
        source: function (request, response) {
        $.ajax({
            url: "SolicitudRendicion.aspx/ListarProveedoresporid",
            data: "{ 'texto': '" + request.term + "','cod': 'T','i': 'C' }",
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataFilter: function (data) { return data; },
            success: function (data) {
                response($.map(data.d, function (item) {
                    return {
                        id: item.ADESANE,
                        value: item.ACODANE,                 
                    }
                }))
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {

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
        $('#MainContent_txtsolicitanteb').val(str);
       }
});


            $("#MainContent_txtcodbancob").autocomplete(
{
    source: function (request, response) {
        $.ajax({
            url: "SolicitudRendicion.aspx/ListarBancosProg",
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
                        v: item.CT_CCODMON,
                        b: item.CT_CCUENTA,
                    }
                }))
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
            }
        });
    },
    minLength: 1,
    select: function (event, ui) {
        var str = ui.item.id;
        var cadena = str;
        posicionEspacio = cadena.indexOf("@"), //Obtengo la posición del espacio en la cadena
        primerApellido = cadena.substring(0, posicionEspacio) //Obtengo la porción deseada de la cadena
        enMinuscula = primerApellido.toLowerCase(); //Convierto el apellido a minúscula
        primerApellido = cadena.substring(posicionEspacio + 1, str.length)
        $('#MainContent_txtbancob').val(str);
        }
    });


            $("#MainContent_txtbancob").autocomplete(
          {
              source: function (request, response) {
                  $.ajax({
                      url: "SolicitudRendicion.aspx/ListarBancosProg",
                      data: "{ 'productos': '" + request.term + "' }",
                      dataType: "json",
                      type: "POST",
                      contentType: "application/json; charset=utf-8",
                      dataFilter: function (data) { return data; },
                      success: function (data) {
                          response($.map(data.d, function (item) {
                              return {
                                  id: item.CT_CNUMCTA,
                                  value: item.CT_CDESCTA,
                                  v: item.CT_CCODMON,
                                  b: item.CT_CCUENTA,
                              }
                          }))
                      },
                      error: function (XMLHttpRequest, textStatus, errorThrown) {
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
                  $('#MainContent_txtcodbancob').val(str);
               }
          });


            $('#NuevoItem').dialog({
                autoOpen: false,
                modal: true,
                resizable: true,
                width: 900,
                heigth: 500,
                title: 'Registro',
                close: function (event, ui) {
                    limpiar();
                     var boton = document.getElementById("<%=btnver.ClientID%>");
                     boton.click();
                    },
            });

             $('#Asiento').dialog({
                autoOpen: false,
                modal: true,
                resizable: true,
                width: 700,
                heigth: 500,
                title: 'Ver Asiento',
                close: function (event, ui) {
                   
                    },
             });
             $('#Asiento27').dialog({
                 autoOpen: false,
                 modal: true,
                 resizable: true,
                 width: 900,
                 heigth: 500,
                 title: 'Ver Asiento Subd. 27',
                 close: function (event, ui) {

                 },
             });

          
            $(".modificar").click(function () {
                trp = $(this).parent().parent();
                id = $("td:eq(2)", trp).html();
                Tipo = $("td:eq(1)", trp).html();
                CodTipo = $("td:eq(0)", trp).html();
                moneda = $("td:eq(7)", trp).html();
                monto = $("td:eq(8)", trp).html();
                estado = $("td:eq(9)", trp).html();
                solicitante = $("td:eq(5)", trp).html();
                codsolicitante = $("td:eq(4)", trp).html();

                $("#NuevoItem").dialog('open');
                Operacion.mask('lbltipo').text(Tipo);
                Operacion.mask('lblcodtipo').text(CodTipo);
                Operacion.mask('lblsolicitud').text(id);
                Operacion.mask('lblmoneda').text(moneda);
                Operacion.mask('lblmonto').text(monto);
                Operacion.mask('lblestado').text(estado);
                Operacion.mask('lblsolicitante').text(solicitante);
                Operacion.mask('lblcodsolicitante').text(codsolicitante);
                $('.cont_sel').show();
                filtrardetalles();
                total();

            });

            $(".glosas").change(function () {
                Operacion.mask('txtglosacomprobante').val(Operacion.mask('txtproveedor').val().trim()+","+Operacion.mask('ddldocumento').val().trim() + " "+ Operacion.mask('txtdocumento').val());
                Operacion.mask('txtglosamovimiento').val(Operacion.mask('txtproveedor').val().trim() + "," + Operacion.mask('ddldocumento').val().trim() + " " + Operacion.mask('txtdocumento').val());

            });
      
          
            $(".imprimir").click(function () {
                trp = $(this).parent().parent();
                id = $("td:eq(2)", trp).html();
                Tipo = $("td:eq(0)", trp).html();
                Estado = $("td:eq(8)", trp).html();
                window.open("../CAJACHICA/ImprimirCaja.aspx?NUMERO= " + id + "&TIPO=" + Tipo + "&ESTADO=" + Estado, '_blank');

                //trp = $(this).parent().parent();
                //id = $("td:eq(2)", trp).html();
                //Tipo = $("td:eq(0)", trp).html();
                //Estado = $("td:eq(7)", trp).html();
               

            });

            $("#MainContent_txtproveedor").autocomplete(
                   {
                       source: function (request, response) {
                           $.ajax({
                               url: "Contabilizacion.aspx/GetProveedores",
                               data: "{ 'productos': '" + request.term + "' }",
                               dataType: "json",
                               type: "POST",
                               contentType: "application/json; charset=utf-8",
                               dataFilter: function (data) { return data; },
                               success: function (data) {
                                   response($.map(data.d, function (item) {
                                       return {
                                           value: item.ADESANE,
                                           id: item.ACODANE,
                                           v: item.ARUC,

                                       }
                                   }))
                               },
                               error: function (XMLHttpRequest, textStatus, errorThrown) {
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
                           $('#MainContent_txtcodigoproveedor').val(str);
                           Operacion.mask('txtruc').val(ui.item.v);
                         }
                   });

            
            function tipocambioVenta() {
                var fecemi = moment(Operacion.mask('txtfechaactual').val(), "DD/MM/YYYY");
                var com = {};
                com.XDATE = fecemi;
                $.ajax({

                    type: "POST",
                    url: "Contabilizacion.aspx/obetenertcambiocvEdgar",
                    data: '{COM: ' + JSON.stringify(com) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        if (data.d.length > 0) {
                            for (var i = 0; i < data.d.length; i++) {
                                $('#MainContent_lbltipocambio').text(data.d[i].XMEIMP2);
                                $('#MainContent_lbltipocambio27').text(data.d[i].XMEIMP2);
                               // $('#MainContent_lbltipocambio').val(data.d[i].XMEIMP); // PARA COMPRA
                            }
                        }
                    },
                    error: function (data) {
                        if (data.length != 0)
                            console.log(data);
                    }
                });
            }




            function filtrardetalles() {
                var VC = {};
                VC.ORDEN_NUMERO = Operacion.mask('lblsolicitud').text();
                VC.CODIGO_CAJA = Operacion.mask('lblcodtipo').text();
               
                $.ajax({

                    type: "POST",
                    url: "Contabilizacion.aspx/ListarTodos",
                    data: '{com: ' + JSON.stringify(VC) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {

                        if (data.d.length > 0) {
                            var row = $("[id*=GridView2] tr:last-child").clone(true);
                            $("[id*=GridView2] tr").not($("[id*=GridView2] tr:first-child")).remove();
                            for (var i = 0; i < data.d.length; i++) {
                                $("td", row).eq(0).val(data.d[i].CODIGO_DETALLE);
                                $("td", row).eq(0).html(data.d[i].CODIGO_PROVEEDOR);
                                $("td", row).eq(1).val(data.d[i].SUBDIARIO);
                                $("td", row).eq(1).html(data.d[i].PROVEEDOR);
                                $("td", row).eq(2).html(data.d[i].TIPO_DOCUMENTO);
                                $("td", row).eq(2).val(data.d[i].ESTADO);
                                $("td", row).eq(3).html(data.d[i].NUM_DOCUMENTO);
                                $("td", row).eq(4).html((moment(data.d[i].FECHA_EMISION).format("DD/MM/YYYY")));
                                $("td", row).eq(5).html(Operacion.mround(Number(data.d[i].MONTO_IGV),2));
                                $("td", row).eq(6).html(Operacion.mround(Number(data.d[i].IGV),2));
                                $("td", row).eq(7).html(Operacion.mround(Number(data.d[i].PARCIAL),2));
                                $("td", row).eq(8).html(Operacion.mround(Number(data.d[i].TOTAL), 2));
                                $("td", row).eq(9).html(data.d[i].MOTIVO);
                                $("td", row).eq(10).html(data.d[i].ESTADO == "P" ? "PENDIENTE" : "CONTABILIZADO");
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
                            $("td", row).eq(0).html("");
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

            function total() {
                subtt = 0;
                sumasub = 0;
                var gridView = document.getElementById("<%=GridView2.ClientID %>");
                var imput = document.getElementById("<%=GridView2.ClientID %>").rows.length;
                      for (var i = 1; i < imput; i++) {
                          cellPivot = gridView.rows[i].cells[8];
                          subtt = cellPivot.innerHTML;
                          sumasub = new Number(sumasub) + new Number(subtt);
                      }
                      Operacion.mround(Number(Operacion.mask('lbltotal').text(sumasub)), 2);
                      Operacion.mround(Number(Operacion.mask('txtmontodeclarado').val(sumasub)), 2);
                      Operacion.mask('lbldiferencia').text(Number(Operacion.mask('lblmonto').text()) - Number(Operacion.mask('txtmontodeclarado').val()));

            }

             $(".editar").click(function () {
                
                 trp = $(this).parent().parent();
                 id = $("td:eq(0)", trp).val();
                 subd = $("td:eq(1)", trp).val();
                 est = $("td:eq(2)", trp).val();
                                
                 if ((subd == "11" || subd == "17" || subd == "16") && est.trim() == "P") {
                     $("#Asiento").dialog('open');
                     Operacion.mask('lblcodigodetalle').text(id);
                     tipocambioVenta();
                     ConsultaUno(id);

                }
                 else {
                     alert("No es posible esta operación para este item");
                 }
             });
            

            function ConsultaUno(id) {
                var VC = {};
                VC.CODIGO_DETALLE =id;              
                $.ajax({
                    type: "POST",
                    url: "Contabilizacion.aspx/ListarUnItem",
                    data: '{com: ' + JSON.stringify(VC) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {                                                
                            var row = $("[id*=gvasiento] tr:last-child").clone(true);
                            $("[id*=gvasiento] tr").not($("[id*=gvasiento] tr:first-child")).remove();
                            for (var i = 0; i < data.d.length; i++) {
                                $("td", row).eq(0).html(data.d[i].SUBDIARIO);
                                $("td", row).eq(1).html(data.d[i].CUENTA);
                                $("td", row).eq(1).val("GA");
                                $("td", row).eq(2).html(data.d[i].CENCOS);
                                $("td", row).eq(3).html("D");
                                $("td", row).eq(4).html(Operacion.mask('lblmoneda').text() == "MN" ? data.d[i].PARCIAL : Operacion.mround(Number(data.d[i].PARCIAL) * Number(Operacion.mask('lbltipocambio').text()), 2));
                                $("td", row).eq(5).html(Operacion.mask('lblmoneda').text() == "US" ? data.d[i].PARCIAL : Operacion.mround(Number(data.d[i].PARCIAL) / Number(Operacion.mask('lbltipocambio').text()), 2));
                                $("td", row).eq(6).html(data.d[i].TIPO_DOCUMENTO);
                                $("td", row).eq(7).html(data.d[i].NUM_DOCUMENTO);
                                $("td", row).eq(8).html(moment(data.d[i].FECHA_EMISION).format("DD/MM/YYYY"));
                                $("td", row).eq(9).html(moment(data.d[i].FECHA_VENCIMIENTO).format("DD/MM/YYYY"));
                               
                                $("[id*=gvasiento]").append(row);
                                row = $("[id*=gvasiento] tr:last-child").clone(true);
                            }
                            for (var i = 0; i < data.d.length; i++) {
                                if (Number(data.d[i].MONTO_IGV)>0){
                                    $("td", row).eq(0).html(data.d[i].SUBDIARIO);
                                    $("td", row).eq(1).html(M_ARRAY[14] == "IGV" ? M_ARRAY[12] : "");
                                    $("td", row).eq(1).val("IG");
                                    $("td", row).eq(2).html("");
                                    $("td", row).eq(3).html("D");
                                    $("td", row).eq(4).html(Operacion.mask('lblmoneda').text() == "MN" ? data.d[i].MONTO_IGV : Operacion.mround(Number(data.d[i].MONTO_IGV) * Number(Operacion.mask('lbltipocambio').text()), 2));
                                    $("td", row).eq(5).html(Operacion.mask('lblmoneda').text() == "US" ? data.d[i].MONTO_IGV : Operacion.mround(Number(data.d[i].MONTO_IGV) / Number(Operacion.mask('lbltipocambio').text()), 2));
                                    $("td", row).eq(6).html(data.d[i].TIPO_DOCUMENTO);
                                    $("td", row).eq(7).html(data.d[i].NUM_DOCUMENTO);
                                    $("td", row).eq(8).html(moment(data.d[i].FECHA_EMISION).format("DD/MM/YYYY"));
                                    $("td", row).eq(9).html(moment(data.d[i].FECHA_VENCIMIENTO).format("DD/MM/YYYY"));
                                    $("[id*=gvasiento]").append(row);
                                    row = $("[id*=gvasiento] tr:last-child").clone(true);
                                }
                            }

                            for (var i = 0; i < data.d.length; i++) {
                               
                                    $("td", row).eq(0).html(data.d[i].SUBDIARIO);
                                    $("td", row).eq(1).html(M_ARRAY[1] == Operacion.mask('lblmoneda').text() ? M_ARRAY[0] : M_ARRAY[4] == Operacion.mask('lblmoneda').text()?  M_ARRAY[3]: "" );
                                    $("td", row).eq(1).val("OB");
                                    $("td", row).eq(2).html("");
                                    $("td", row).eq(3).html("H");
                                    $("td", row).eq(4).html(Operacion.mask('lblmoneda').text() == "MN" ? data.d[i].TOTAL : Operacion.mround(Number(data.d[i].TOTAL) * Number(Operacion.mask('lbltipocambio').text()), 2));
                                    $("td", row).eq(5).html(Operacion.mask('lblmoneda').text() == "US" ? data.d[i].TOTAL : Operacion.mround(Number(data.d[i].TOTAL) / Number(Operacion.mask('lbltipocambio').text()), 2));
                                    $("td", row).eq(6).html(data.d[i].TIPO_DOCUMENTO);
                                    $("td", row).eq(7).html(data.d[i].NUM_DOCUMENTO);
                                    $("td", row).eq(8).html(moment(data.d[i].FECHA_EMISION).format("DD/MM/YYYY"));
                                    $("td", row).eq(9).html(moment(data.d[i].FECHA_VENCIMIENTO).format("DD/MM/YYYY"));
                                    $("[id*=gvasiento]").append(row);
                                    row = $("[id*=gvasiento] tr:last-child").clone(true);
                               
                            }
                            for (var i = 0; i < data.d.length; i++) {
                                if (CUENTASORIGENDESTINO(data.d[i].CUENTA).origen!="") {
                                    $("td", row).eq(0).html(data.d[i].SUBDIARIO);
                                    $("td", row).eq(1).html(CUENTASORIGENDESTINO(data.d[i].CUENTA).origen);
                                    $("td", row).eq(1).val("OR");
                                    $("td", row).eq(2).html("");
                                    $("td", row).eq(3).html("D");
                                    $("td", row).eq(4).html(Operacion.mask('lblmoneda').text() == "MN" ? data.d[i].PARCIAL : Operacion.mround(Number(data.d[i].PARCIAL) * Number(Operacion.mask('lbltipocambio').text()), 2));
                                    $("td", row).eq(5).html(Operacion.mask('lblmoneda').text() == "US" ? data.d[i].PARCIAL : Operacion.mround(Number(data.d[i].PARCIAL) / Number(Operacion.mask('lbltipocambio').text()), 2));
                                    $("td", row).eq(6).html(data.d[i].TIPO_DOCUMENTO);
                                    $("td", row).eq(7).html(data.d[i].NUM_DOCUMENTO);
                                    $("td", row).eq(8).html(moment(data.d[i].FECHA_EMISION).format("DD/MM/YYYY"));
                                    $("td", row).eq(9).html(moment(data.d[i].FECHA_VENCIMIENTO).format("DD/MM/YYYY"));
                                    $("[id*=gvasiento]").append(row);
                                    row = $("[id*=gvasiento] tr:last-child").clone(true);
                                }
                                if (CUENTASORIGENDESTINO(data.d[i].CUENTA).destino != "") {
                                    $("td", row).eq(0).html(data.d[i].SUBDIARIO);
                                    $("td", row).eq(1).html(CUENTASORIGENDESTINO(data.d[i].CUENTA).destino);
                                    $("td", row).eq(1).val("DE");
                                    $("td", row).eq(2).html("");
                                    $("td", row).eq(3).html("H");
                                    $("td", row).eq(4).html(Operacion.mask('lblmoneda').text() == "MN" ? data.d[i].PARCIAL : Operacion.mround(Number(data.d[i].PARCIAL) * Number(Operacion.mask('lbltipocambio').text()), 2));
                                    $("td", row).eq(5).html(Operacion.mask('lblmoneda').text() == "US" ? data.d[i].PARCIAL : Operacion.mround(Number(data.d[i].PARCIAL) / Number(Operacion.mask('lbltipocambio').text()), 2));
                                    $("td", row).eq(6).html(data.d[i].TIPO_DOCUMENTO);
                                    $("td", row).eq(7).html(data.d[i].NUM_DOCUMENTO);
                                    $("td", row).eq(8).html(moment(data.d[i].FECHA_EMISION).format("DD/MM/YYYY"));
                                    $("td", row).eq(9).html(moment(data.d[i].FECHA_VENCIMIENTO).format("DD/MM/YYYY"));
                                    $("[id*=gvasiento]").append(row);
                                    row = $("[id*=gvasiento] tr:last-child").clone(true);
                                }
                                
                            }
                    },
                    error: function (response) {
                        if (response.length != 0)
                            console.log(response);
                    }
                });
                recorregriddetalle();

            }

            $(".Finalizar").click(function () {
                if (Operacion.mask('lblestado').text() != "L") {
                    if(Number(Operacion.mask('txtmontodeclarado').val())==Number(Operacion.mask('lbltotal').text())){
                       

                    }
                    else {
                        alert("No es posible la operación debido a que el total no coincide con el monto declarado");
                    }
                   
                }
                else {
                    alert("No es posible esta operación debido a que la solicitud se encuentra Liquidada");
                }
               
            });    
            
           
            function limpiar(){
                Operacion.mask('txtcodigodetalle').val("");
                Operacion.mask('txtruc').val("");
                Operacion.mask('txtproveedor').val("");
                Operacion.mask('ddldocumento').val("");
                Operacion.mask('txtdocumento').val("");
                Operacion.mask('txtglosacomprobante').val("");
                Operacion.mask('txtglosamovimiento').val("");
                Operacion.mask('txtfechaemision').val((moment(new Date()).format("DD/MM/YYYY")));
                Operacion.mask('txtfechavmto').val((moment(new Date()).format("DD/MM/YYYY")));
                Operacion.mask('txtmontoigv').val("");
                Operacion.mask('txtigv').val("18");
                Operacion.mask('txtcodigoproveedor').val("");
                Operacion.mask('txtimportetotal').val("0.00");
                Operacion.mask('ddlmotivo').val("");
                Operacion.mask('txtanexore').val("");
                Operacion.mask('txtanexore2').val("");
                Operacion.mask('txtfecven').val("");
                Operacion.mask('txtcodcencos').val("");
                Operacion.mask('txtcencos').val("");
                Operacion.mask('ddlmedpag').val("");
                Operacion.mask('txtfechaanexore2').val("");
                Operacion.mask('ddldocre2').find("option").remove();
                Operacion.mask('ddlmotivo').find("option").remove();
                Operacion.mask('ddlmedpag').find("option").remove();
            }

            function CUENTASORIGENDESTINO(CUENTA) {
                var origen = "";
                var destino = "";
                var anexo = "";
                $.ajax({

                    type: "POST",
                    url: "Contabilizacion.aspx/ListaPlanIDE",
                    data: "{ 'PDATA': '" + CUENTA + "' }",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        for (var i = 0; i < data.d.length; i++)
                        {
                            origen = data.d[i].PCTACAR;
                            anexo = data.d[i].PVANEXO;
                            destino = data.d[i].PCTAABO;
                        }
                       
                    },
                    error: function (data) {
                        if (data.length != 0)
                            console.log(data);
                    }
                });
                return { origen, destino, anexo}
            }


            function RETENCIONES(CUENTA) {
                var retencion = "";
                var pretencion = 0;
               
                $.ajax({

                    type: "POST",
                    url: "Contabilizacion.aspx/listarMaestroxunID",
                    data: '{ADATA: ' + JSON.stringify(CUENTA) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                       // for (var i = 0; i < data.d.length; i++) {
                            //alert("LO ASIGNA");
                            retencion = data.d.AC_CRETE;
                            pretencion = data.d.AC_NPORRE;
                         // }

                    },
                    error: function (data) {
                        if (data.length != 0)
                            console.log(data);
                    }
                });
                return { retencion, pretencion }
            }

           function recorregriddetalle() {
            contarndw = 0;
            subsoles = 0; descc = 0; igvv = 0;
            sumasoles = 0; subdolares = 0; sumadolares = 0;

            var gridView = document.getElementById("<%=gvasiento.ClientID %>");

            for (var t = 1; t < gridView.rows.length; t++) {
               
                cellPivotdolares = gridView.rows[t].cells[5];
                cellPivotsoles = gridView.rows[t].cells[4];
                subdolares = cellPivotdolares.innerHTML;
                subsoles = cellPivotsoles.innerHTML;

                if (gridView.rows[t].cells[3].innerHTML == "D") {
                    sumasoles = new Number(Operacion.mask('lbldebesoles').text()) + Math.abs(new Number(subsoles));
                    sumadolares = new Number(Operacion.mask('lbldebedolares').text()) + Math.abs(new Number(subdolares));
                    Operacion.mask('lbldebedolares').text(Operacion.mround(sumadolares,2));
                    Operacion.mask('lbldebesoles').text(Operacion.mround(sumasoles,2));
                }
                if (gridView.rows[t].cells[3].innerHTML == "H") {
                    sumasoles = new Number(Operacion.mask('lblhabersoles').text()) + Math.abs(new Number(subsoles));
                    sumadolares = new Number(Operacion.mask('lblhaberdolares').text()) + Math.abs(new Number(subdolares));
                    Operacion.mask('lblhaberdolares').text(Operacion.mround(sumadolares,2));
                    Operacion.mask('lblhabersoles').text(Operacion.mround(sumasoles,2));
                }
                                           
            }                         
           }




             function filtrardetalles1() {
                 var VC = {};
                 VC.ORDEN_NUMERO = Operacion.mask('lblsolicitud').text();
                 VC.CODIGO_CAJA = Operacion.mask('lblcodtipo').text();

                 $.ajax({

                     type: "POST",
                     url: "Contabilizacion.aspx/ListarTodos",
                     data: '{com: ' + JSON.stringify(VC) + '}',
                     contentType: "application/json; charset=utf-8",
                     dataType: "json",
                     async: false,
                     success: function (data) {

                         if (data.d.length > 0) {
                             var row = $("[id*=GridView2] tr:last-child").clone(true);
                             $("[id*=GridView2] tr").not($("[id*=GridView2] tr:first-child")).remove();
                             for (var i = 0; i < data.d.length; i++) {
                                 $("td", row).eq(0).val(data.d[i].CODIGO_DETALLE);
                                 $("td", row).eq(0).html(data.d[i].CODIGO_PROVEEDOR);
                                 $("td", row).eq(1).val(data.d[i].SUBDIARIO);
                                 $("td", row).eq(1).html(data.d[i].PROVEEDOR);
                                 $("td", row).eq(2).html(data.d[i].TIPO_DOCUMENTO);
                                 $("td", row).eq(2).val(data.d[i].ESTADO);
                                 $("td", row).eq(3).html(data.d[i].NUM_DOCUMENTO);
                                 $("td", row).eq(4).html((moment(data.d[i].FECHA_EMISION).format("DD/MM/YYYY")));
                                 $("td", row).eq(5).html(Operacion.mround(Number(data.d[i].MONTO_IGV), 2));
                                 $("td", row).eq(6).html(Operacion.mround(Number(data.d[i].IGV), 2));
                                 $("td", row).eq(7).html(Operacion.mround(Number(data.d[i].PARCIAL), 2));
                                 $("td", row).eq(8).html(Operacion.mround(Number(data.d[i].TOTAL), 2));
                                 $("td", row).eq(9).html(data.d[i].MOTIVO);
                                 $("td", row).eq(10).html(data.d[i].ESTADO=="P"?"PENDIENTE":"CONTABILIZADO");
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
                             $("td", row).eq(0).html("");
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
            //////////////////////// PROCEDIMIENTO PARA GUARDAR SUBDIARIO 27 /////////////////////////////
             $(".aceptar27").click(function () {
                 InsertarCabComprobante27();
             });

             function ActualizaEstado27(subdiario27,comprobante27) {
                 var datos = {};
                 datos.ORDEN_NUMERO = Operacion.mask('lblsolicitud').text();
                 datos.CODIGO_CAJA = Operacion.mask('lblcodtipo').text();
                 datos.ESTADO = "C";
                 datos.MONTO_DECLARADO = Operacion.mask('txtmontodeclarado').val();
                 datos.SUBDIARIO = subdiario27;
                 datos.COMPROBANTE = comprobante27;
                 datos.FECCOMP = new Date();
                 $.ajax({
                     type: "POST",
                     url: "Contabilizacion.aspx/ActualizarEstado",
                     data: '{COM: ' + JSON.stringify(datos) + '}',
                     contentType: "application/json; charset=utf-8",
                     dataType: "json",
                     async: false,
                     success: function (response) {
                         //lert("Registro finalizado");
                         ActualizaSaldo27();
                       },
                     error: function (response) {
                         if (response.length != 0)
                             alert(response);
                         console.log(response);

                     }
                 });
             }

             function ActualizaSaldo27() {
                 var datos = {};
                 datos.TIPO = "1";
                 datos.CODIGO_CAJA = Operacion.mask('lblcodtipo').text();
                 datos.ESTADO = "0";
                 datos.MONTO_ACTUAL = Number(Operacion.mask('lbltotal').text());
                 $.ajax({
                     type: "POST",
                     url: "Contabilizacion.aspx/ActualizarSaldo",
                     data: '{COM: ' + JSON.stringify(datos) + '}',
                     contentType: "application/json; charset=utf-8",
                     dataType: "json",
                     async: false,
                     success: function (response) {
                         alert("Registro finalizado");
                     },
                     error: function (response) {
                         if (response.length != 0)
                             alert(response);
                         console.log(response);

                     }
                 });
             }

             function InsertarCabComprobante27() {

                 var fecha = new Date();
                 var annio = fecha.getFullYear().toString();
                 var DETACAB = {};
                 DETACAB.CSUBDIA = "27";
                 DETACAB.CCOMPRO = generar("27").ultimodato;
                 DETACAB.CFECCOM = annio.substr(2, 2) + (Number(fecha.getMonth() + 1) < 10 ? "0" + (fecha.getMonth() + 1) : (fecha.getMonth() + 1)) + fecha.getDate();
                 DETACAB.CCODMON = Operacion.mask('lblmoneda').text();
                 DETACAB.CSITUA = "F";
                 DETACAB.CTIPCAM = $('#MainContent_lbltipocambio').text();
                 DETACAB.CGLOSA = "Rendicion de Caja";
                 DETACAB.CTOTAL = (Operacion.mask('lblmoneda').text() == "MN" ? Number(Operacion.mask('lbldebesoles27').text()) : Number(Operacion.mask('lbldebedolares27').text()));
                 DETACAB.CTIPO = "V";
                 DETACAB.CFLAG = "S";
                 DETACAB.CDATE = fecha;
                 DETACAB.CHORA = fecha.getHours() + ":" + ((fecha.getMinutes()).toString().length < 2 ? "0" + fecha.getMinutes() : fecha.getMinutes());
                 DETACAB.CUSER = $("#MainContent_lblusuario").html();
                 DETACAB.CFECCAM = "      ";

                 DETACAB.CORIG = "  ";
                 DETACAB.CFORM = " ";
                 DETACAB.CTIPCOM = "  ";

                 DETACAB.CEXTOR = " ";
                 DETACAB.CFECCOM2 = fecha;
                 DETACAB.CFECCAM2 = null;
                 DETACAB.CMEMO = " ";
                 DETACAB.CSERCER = "    ";
                 DETACAB.CNUMCER = "          ";
                 $.ajax({
                     type: "POST",
                     url: "Contabilizacion.aspx/InsertCabComprobante",
                     data: '{DETA: ' + JSON.stringify(DETACAB) + '}',
                     contentType: "application/json; charset=utf-8",
                     dataType: "json",
                     async: false,
                     success: function (response) {
                         //alert("DATOS GUARDADOS cabecera");
                         insertadetcomprobante27(DETACAB);
                         InsertaBalh(27);
                         ActualizaEstado27(DETACAB.CSUBDIA,DETACAB.CCOMPRO);
                         ActComprobante(Number((DETACAB.CCOMPRO)), DETACAB.CSUBDIA,27);
                     },
                     error: function (response) {
                         if (response.length != 0)
                             alert(response);
                         console.log(response);

                     }
                 });
             }

            ////////////////////////// FIN DE SUBDIARIO 27 /////////////////

             $(".aceptar").click(function () {
                 ConsultaUnog(Operacion.mask('lblcodigodetalle').text());
             });

            
             function generar(CSUBDIARIO) {
                 var element = $('#MainContent_txtfechaactual').val();
                 var fecha = element.split('/');
                 var FECDOC = fecha[2].substr(2, 2) + "" + fecha[1] + "" + fecha[0];
                 var ultimodato = "";
                 var formato = "";
                 var DATA = {};
                 DATA.CTSUBDIA = CSUBDIARIO;
                 DATA.CTANO = fecha[2].substr(2, 2);
                 DATA.CTMES = fecha[1];

                 $.ajax({
                     type: "POST",
                     url: "Contabilizacion.aspx/correlativoCP",
                     data: '{ DATA: ' + JSON.stringify(DATA) + '}',
                     contentType: "application/json;charset=utf-8",
                     dataType: "json",
                     async: false,
                     success: function (data) {
                         ultimodato = data.d;
                     },
                     error: function (response) {
                         console.table(response);
                     }
                 });


                 return { ultimodato };
             }

             function ConsultaUnog(id) {
                 var VC = {};
                 VC.CODIGO_DETALLE = id;
                 var CABECERA = {};

                 $.ajax({
                     type: "POST",
                     url: "Contabilizacion.aspx/ListarUnItem",
                     data: '{com: ' + JSON.stringify(VC) + '}',
                     contentType: "application/json; charset=utf-8",
                     dataType: "json",
                     async: false,
                     success: function (data) {
                         for (var i = 0; i < data.d.length; i++) {

                             CABECERA.GLOSA_MOVIMIENTO = (data.d[i].GLOSA_MOVIMIENTO);
                             CABECERA.GLOSA_COMPROBANTE = (data.d[i].GLOSA_COMPROBANTE);
                             CABECERA.ANEXO = (data.d[i].ANEXO);
                             CABECERA.DVANEXO = (data.d[i].DVANEXO);
                             CABECERA.DCENCOS = (data.d[i].CENCOS);
                             CABECERA.CODIGO_PROVEEDOR = (data.d[i].CODIGO_PROVEEDOR);
                             CABECERA.SUBDIARIO = (data.d[i].SUBDIARIO);
                             CABECERA.CCOMPRO = generar(data.d[i].SUBDIARIO).ultimodato;
                             InsertarCabComprobante(CABECERA);
                           }
                     },
                     error: function (response) {
                         if (response.length != 0)
                             console.log(response);
                     }
                 });

             }
              function insertadetcomprobante(DCOMPRO) {
                var f = new Date();
                var dia = "";
                var mes = "";
                var annio = "";
                var DETADC = {};
                var RETENC = {};
                var annioven = "";
                var aannio = "";
                var cont = 0;
                var i = 0;
                annio = Number(f.getFullYear()).toString();               
                var gridView = document.getElementById("<%=gvasiento.ClientID%>");                               
                for (i = 1; i < gridView.rows.length; i++) {
                    //cont = cont + 1;
                    DETADC.DSUBDIA = gridView.rows[i].cells[0].innerHTML;
                    DETADC.DCOMPRO = DCOMPRO.CCOMPRO;
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

                    DETADC.DSECUE = Operacion.cadenaMascara(i, 4);
                    DETADC.DFECCOM = f.getFullYear().toString().substr(2, 2) + (Number(f.getMonth() + 1) < 10 ? "0" + (f.getMonth() + 1) : (f.getMonth() + 1)) + f.getDate();
                    DETADC.DCUENTA = gridView.rows[i].cells[1].innerHTML;
                    
                    DETADC.DCENCOS = (gridView.rows[i].cells[1].value == "GA" ? DCOMPRO.DCENCOS : "      ");
                    DETADC.DCODMON = Operacion.mask('lblmoneda').text();
                    DETADC.DDH = gridView.rows[i].cells[3].innerHTML;
                    DETADC.DTIPDOC = gridView.rows[i].cells[6].innerHTML.trim();
                    DETADC.DNUMDOC = gridView.rows[i].cells[7].innerHTML;

                    var fecemi = moment(gridView.rows[i].cells[8].innerHTML, "DD/MM/YYYY");
                    fecemi = fecemi == null ? null : new Date(fecemi);
                    var fecven = moment(gridView.rows[i].cells[9].innerHTML, "DD/MM/YYYY");
                    fecven = fecven == null ? null : new Date(fecven);

                    DETADC.DFECDOC = fecemi.getFullYear().toString().substr(2, 2) + (Number(fecemi.getMonth() + 1) < 10 ? "0" + (fecemi.getMonth() + 1) : (fecemi.getMonth() + 1)) + fecemi.getDate();
                    DETADC.DFECVEN = (gridView.rows[i].cells[1].value == "OB" ? fecven.getFullYear().toString().substr(2, 2) + (Number(fecven.getMonth() + 1) < 10 ? "0" + (fecven.getMonth() + 1) : (fecven.getMonth() + 1)) + fecven.getDate() : "      ");

                    DETADC.DAREA = "";
                    DETADC.DFLAG = "S";
                    DETADC.DDATE = ((gridView.rows[i].cells[1].value == "OB" || gridView.rows[i].cells[1].value == "GA" || gridView.rows[i].cells[1].value == "IG") ? f: null);
                    DETADC.DXGLOSA = DCOMPRO.GLOSA_MOVIMIENTO;

                    DETADC.DMNIMPOR = Operacion.mround((Number(gridView.rows[i].cells[4].innerHTML)), 2);
                    DETADC.DUSIMPOR = Operacion.mround((Number(gridView.rows[i].cells[5].innerHTML)), 2);
                    DETADC.DIMPORT = (Operacion.mask('lblmoneda').text() == "MN" ? Operacion.mround((Number(gridView.rows[i].cells[4].innerHTML)), 2) : Operacion.mround((Number(gridView.rows[i].cells[5].innerHTML)), 2));
                    DETADC.DCODARC = ((gridView.rows[i].cells[1].value == "OR" || gridView.rows[i].cells[1].value == "DE") ? "AT" : "  ");
                    DETADC.DFECCOM2 = f;                   
                    DETADC.DFECDOC2 = fecemi;
                    DETADC.DFECVEN2 = (gridView.rows[i].cells[1].value == "OB" ? fecven : null);//(gridView.rows[i].cells[1].val == "OB"?(moment(f, "DD/MM/YYYY")) : null);
                    DETADC.DCODANE2 = "";
                    var anexo = CUENTASORIGENDESTINO(gridView.rows[i].cells[1].innerHTML).anexo;
                    DETADC.DVANEXO = (anexo != null ? anexo : " ");
                    DETADC.DCODANE = (anexo == "T" ? Operacion.mask('lblcodsolicitante').text() : anexo.trim() != "" ? DCOMPRO.CODIGO_PROVEEDOR : "                  ");
                    //alert("-" + DETADC.DCODANE + "-");
                    //PARA CALCULO DE RETENCIONES
                    RETENC.AC_CVANEXO = anexo;
                    RETENC.AC_CCODIGO = DETADC.DCODANE;
                    //FIN CALCULO DE RETENCIONES
                    DETADC.DVANEXO2 = "";
                    DETADC.DTIPCAM = 0;
                    DETADC.DCANTID = 0;
                    DETADC.DCTAORI = ((gridView.rows[i].cells[1].value == "OR" || gridView.rows[i].cells[1].value == "DE") ? gridView.rows[1].cells[1].innerHTML : "");//////////////////////////////////////////////////////////////
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
                    DETADC.DTIPDOR = "";
                    DETADC.DNUMDOR = "";
                    DETADC.DFECDO2 = null;
                    DETADC.DTIPTAS = "";
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
                    DETADC.DMEDPAG = ""; // SE TOMA DEL COMBO Y SOLO SE APLICA PARA EL REGISTRO DEL TOTAL                    
                    DETADC.DTIPDO2 = "";
                    DETADC.DNUMDO2 = "";
                    DETADC.DRETE = ((gridView.rows[i].cells[1].value == "OB" && Number(gridView.rows[i].cells[4].innerHTML)>700)? RETENCIONES(RETENC).retencion:"" );
                    DETADC.DPORRE = ((gridView.rows[i].cells[1].value == "OB" && Number(gridView.rows[i].cells[4].innerHTML) > 700) ? Number(RETENCIONES(RETENC).pretencion) : 0);

                    //if (gridView.rows[i].cells[1].value == "OB") {
                    //    alert(RETENCIONES(RETENC).retencion + "-" + RETENCIONES(RETENC).pretencion);
                    //}
                   
                    $.ajax({
                        type: "POST",
                        url: "Contabilizacion.aspx/InsertDetComprobante",
                        data: '{DETA: ' + JSON.stringify(DETADC) + '}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (response) {
                            //alert("detalle guardado");
                        },
                        error: function (response) {
                            if (response.length != 0)
                                console.log(response);
                        }
                    });
                }
            }

            function insertadetcomprobante27(DATA) {
                var f = new Date();
                var dia = "";
                var mes = "";
                var annio = "";
                var DETADC = {};
                var RETENC = {};
                var annioven = "";
                var aannio = "";
                var cont = 0;
                var i = 0;
                annio = Number(f.getFullYear()).toString();               
                var gridView = document.getElementById("<%=gvsubdiario27.ClientID%>");                               
                for (i = 1; i < gridView.rows.length; i++) {
                    //cont = cont + 1;
                    DETADC.DSUBDIA = gridView.rows[i].cells[0].innerHTML;
                    DETADC.DCOMPRO = DATA.CCOMPRO;
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
                    DETADC.DSECUE = Operacion.cadenaMascara(i, 4);
                    DETADC.DFECCOM = f.getFullYear().toString().substr(2, 2) + (Number(f.getMonth() + 1) < 10 ? "0" + (f.getMonth() + 1) : (f.getMonth() + 1)) + f.getDate();
                    DETADC.DCUENTA = gridView.rows[i].cells[1].innerHTML;                    
                    DETADC.DCENCOS = (gridView.rows[i].cells[2].innerHTML != "" ? gridView.rows[i].cells[2].innerHTML : "      ");

                    DETADC.DCODMON = Operacion.mask('lblmoneda').text();
                    DETADC.DDH = gridView.rows[i].cells[3].innerHTML;
                    DETADC.DTIPDOC = gridView.rows[i].cells[6].innerHTML.trim();
                    DETADC.DNUMDOC = gridView.rows[i].cells[7].innerHTML;
                    var fecemi = moment(gridView.rows[i].cells[8].innerHTML, "DD/MM/YYYY");
                    fecemi = fecemi == null ? null : new Date(fecemi);
                    var fecven = moment(gridView.rows[i].cells[9].innerHTML, "DD/MM/YYYY");
                    fecven = fecven == null ? null : new Date(fecven);
                    DETADC.DFECDOC = fecemi.getFullYear().toString().substr(2, 2) + (Number(fecemi.getMonth() + 1) < 10 ? "0" + (fecemi.getMonth() + 1) : (fecemi.getMonth() + 1)) + fecemi.getDate();

                    //alert("-"+ gridView.rows[i].cells[9].innerHTML +"-");

                    DETADC.DFECVEN = (gridView.rows[i].cells[9].innerHTML != "" ? fecven.getFullYear().toString().substr(2, 2) + (Number(fecven.getMonth() + 1) < 10 ? "0" + (fecven.getMonth() + 1) : (fecven.getMonth() + 1)) + fecven.getDate() : "      ");

                    DETADC.DAREA = "";
                    DETADC.DFLAG = "S";
                    DETADC.DDATE = (gridView.rows[i].cells[3].value);
                    DETADC.DXGLOSA = (gridView.rows[i].cells[1].value).substring(0,29);
                    DETADC.DMNIMPOR = Operacion.mround((Number(gridView.rows[i].cells[4].innerHTML)), 2);
                    DETADC.DUSIMPOR = Operacion.mround((Number(gridView.rows[i].cells[5].innerHTML)), 2);
                    DETADC.DIMPORT = (Operacion.mask('lblmoneda').text() == "MN" ? Operacion.mround((Number(gridView.rows[i].cells[4].innerHTML)), 2) : Operacion.mround((Number(gridView.rows[i].cells[5].innerHTML)), 2));
                    DETADC.DCODARC =  gridView.rows[i].cells[4].value ;
                    DETADC.DFECCOM2 = f;                   
                    DETADC.DFECDOC2 = fecemi;
                    DETADC.DFECVEN2 = (gridView.rows[i].cells[9].innerHTML == "" ? null : fecven);//(gridView.rows[i].cells[1].val == "OB"?(moment(f, "DD/MM/YYYY")) : null);
                    DETADC.DCODANE2 = "";
                    var anexo = CUENTASORIGENDESTINO(gridView.rows[i].cells[1].innerHTML).anexo;
                    DETADC.DVANEXO = (anexo != null ? anexo : " ");
                    DETADC.DCODANE = (gridView.rows[i].cells[0].value != undefined ? gridView.rows[i].cells[0].value : "                  "); // (anexo == "T" ? Operacion.mask('lblcodsolicitante').text() : anexo.trim() != "" ? DATA.CODIGO_PROVEEDOR : "  // CORREGIR                ");
                    //PARA CALCULO DE RETENCIONES
                    RETENC.AC_CVANEXO = anexo;
                    RETENC.AC_CCODIGO = DETADC.DCODANE;
                    //FIN CALCULO DE RETENCIONES
                    DETADC.DVANEXO2 = "";
                    DETADC.DTIPCAM = 0;
                    DETADC.DCANTID = 0;
                    DETADC.DCTAORI = gridView.rows[i].cells[5].value;//////////////////////////////////////////////////////////////
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
                    DETADC.DTIPDOR = "";
                    DETADC.DNUMDOR = "";
                    DETADC.DFECDO2 = null;
                    DETADC.DTIPTAS = "";
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
                    DETADC.DMEDPAG = (gridView.rows[i].cells[1].innerHTML == "101103" ? "004" : "        ");
                    DETADC.DTIPDO2 = "";
                    DETADC.DNUMDO2 = "";
                    DETADC.DRETE = ((gridView.rows[i].cells[1].value == "OB" && Number(gridView.rows[i].cells[4].innerHTML)>700)? RETENCIONES(RETENC).retencion:"" );
                    DETADC.DPORRE = ((gridView.rows[i].cells[1].value == "OB" && Number(gridView.rows[i].cells[4].innerHTML) > 700) ? Number(RETENCIONES(RETENC).pretencion) : 0);
                    console.log(DETADC);
                    $.ajax({
                        type: "POST",
                        url: "Contabilizacion.aspx/InsertDetComprobante",
                        data: '{DETA: ' + JSON.stringify(DETADC) + '}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (response) {
                            
                        },
                        error: function (response) {
                            if (response.length != 0)
                                console.log(response);
                        }
                    });
                }
            }



             function InsertarCabComprobante(CABECERA) {
               
                var fecha = new Date();
                var annio = fecha.getFullYear().toString();
                var DETACAB = {};
                            DETACAB.CSUBDIA = CABECERA.SUBDIARIO;
                            DETACAB.CCOMPRO = CABECERA.CCOMPRO;
                            DETACAB.CFECCOM = annio.substr(2, 2) + (Number(fecha.getMonth() + 1) < 10 ? "0" + (fecha.getMonth() + 1) : (fecha.getMonth() + 1)) + fecha.getDate();
                            DETACAB.CCODMON = Operacion.mask('lblmoneda').text();
                            DETACAB.CSITUA = "F"; 
                            DETACAB.CTIPCAM = $('#MainContent_lbltipocambio').text();
                            DETACAB.CGLOSA = CABECERA.GLOSA_COMPROBANTE;
                            DETACAB.CTOTAL = (Operacion.mask('lblmoneda').text() == "MN" ? Number(Operacion.mask('lbldebesoles').text()) : Number(Operacion.mask('lbldebedolares').text()));
                            DETACAB.CTIPO = "V";
                            DETACAB.CFLAG = "S";
                            DETACAB.CDATE = fecha;
                            DETACAB.CHORA = fecha.getHours() + ":" + ((fecha.getMinutes()).toString().length<2? "0"+ fecha.getMinutes(): fecha.getMinutes());
                            DETACAB.CUSER = $("#MainContent_lblusuario").html();
                            DETACAB.CFECCAM = "      ";

                            DETACAB.CORIG = "  ";
                            DETACAB.CFORM = " ";
                            DETACAB.CTIPCOM = "  ";

                            DETACAB.CEXTOR = " ";
                            DETACAB.CFECCOM2 = fecha;
                            DETACAB.CFECCAM2 = null;
                            DETACAB.CMEMO = " ";
                            DETACAB.CSERCER = "    ";
                            DETACAB.CNUMCER = "          ";
                $.ajax({
                    type: "POST",
                    url: "Contabilizacion.aspx/InsertCabComprobante",
                    data: '{DETA: ' + JSON.stringify(DETACAB) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        insertadetcomprobante(CABECERA);
                        InsertaBalh(11);
                        ActComprobante(Number((DETACAB.CCOMPRO)), DETACAB.CSUBDIA, DETACAB.CSUBDIA);
                    },
                    error: function (response) {
                        if (response.length != 0)
                            alert(response);
                        console.log(response);

                    }
                });
             }

             function ActComprobante(numero, subd, ind) {
                 var DETA = {};
                 var fecha = new Date();
                 DETA.CTSUBDIA = subd;
                 DETA.CTANO = (fecha.getFullYear()).toString().substr(2, 2);
                 DETA.CTMES = (Number(fecha.getMonth() + 1) < 10 ? "0" + (fecha.getMonth() + 1).toString() : (fecha.getMonth() + 1).toString());
                 DETA.CTNUMER = Number(numero.toString().substr(2,4));
                                  
                 $.ajax({
                     type: "POST",
                     url: "Contabilizacion.aspx/Numeracion",
                     data: '{DETA: ' + JSON.stringify(DETA) + '}',
                     contentType: "application/json; charset=utf-8",
                     dataType: "json",
                     async: false,
                     success: function (response) {
                       
                         if (ind!=27){
                             ActualizaEstado();
                             alert("Se ha generado el Comprobante Nº " + subd + " - " + numero);
                             $("#Asiento").dialog('close');
                             filtrardetalles1();
                         }
                         
                         else {
                             window.open("../PAGOSBT/Reportes/IComprobante.aspx?SUB= " + subd + "&COMP=" + Operacion.cadenaMascara(numero, 6) + "&FCOMP=" + DETA.CTANO + "" + DETA.CTMES + "" + Operacion.cadenaMascara(fecha.getDate(), 2) + "&CANT=" + "200", '_blank');
                             alert("Se ha generado el Comprobante Nº " + subd + " - " + numero);
                             $("#Asiento27").dialog('close');
                             $("#NuevoItem").dialog('close');                             
                         }
                         
                     },
                     error: function (response) {
                         if (response.length != 0)
                             console.log(response);
                     }
                 });
             }

             function InsertaBalh(indicador)
             {
                 //alert(indicador);
              var fecha = new Date();
              if (indicador==27){
                var gridView5 = document.getElementById("<%=gvsubdiario27.ClientID %>");
              }
              else {
                  var gridView5 = document.getElementById("<%=gvasiento.ClientID %>");
              }
               
               var BDATA = {};
               for (var t = 1; t < gridView5.rows.length; t++) {
                   if (gridView5.rows[t].cells[2].innerHTML.trim() =="") {                 

                   BDATA.BCUENTA = (gridView5.rows[t].cells[1].innerHTML).trim();
                   BDATA.BMNSALA = 0;
                   if (gridView5.rows[t].cells[3].innerHTML.trim() == "D") {
                       BDATA.BMNDEBE = Operacion.mround(Number(gridView5.rows[t].cells[4].innerHTML), 2);
                       BDATA.BUSDEBE = Operacion.mround(Number(gridView5.rows[t].cells[5].innerHTML), 2);
                       BDATA.BMNHABER = 0;
                       BDATA.BUSHABER = 0;
                   }
                   if (gridView5.rows[t].cells[3].innerHTML.trim() == "H") {
                       BDATA.BMNHABER = Operacion.mround(Number(gridView5.rows[t].cells[4].innerHTML), 2);
                       BDATA.BUSHABER = Operacion.mround(Number(gridView5.rows[t].cells[5].innerHTML), 2);
                       BDATA.BMNDEBE = 0;
                       BDATA.BUSDEBE = 0;
                   }
                   BDATA.BMNSALN = 0;
                   BDATA.BUSSALA = 0;
                   BDATA.BUSSALN = 0;
                   BDATA.BMNSALI = 0;
                   BDATA.BUSSALI = 0;
                   BDATA.BFECPRO = "";
                   BDATA.BFORBAL = "1";//CONTROL PARA DECREMENTAR 
                   BDATA.BFORGYP = "";
                   BDATA.BFORRE1 = "";
                   BDATA.BCTAAJU = "";
                   BDATA.BFECPRO2 = (fecha.getFullYear().toString() + "" + (Number(fecha.getMonth() + 1) < 10 ? "0" + (fecha.getMonth() + 1) : (fecha.getMonth() + 1))).trim();
                   $.ajax({
                       type: "POST",
                       url: "Contabilizacion.aspx/ActualizarBalh",
                       data: '{DETA: ' + JSON.stringify(BDATA) + '}',
                       contentType: "application/json; charset=utf-8",
                       dataType: "json",
                       async: false,
                       success: function (response) {
                          
                           //alert("Balh actualizado");
                       },
                       error: function (response) {
                           if (response.length != 0)
                               alert(response);
                           console.log(response);
                          
                        }
                   });

                   }
                   else {

                       BDATA.CT_CUENTA = (gridView5.rows[t].cells[1].innerHTML).trim();
                       BDATA.CT_CENCOS = (gridView5.rows[t].cells[2].innerHTML).trim();
                      
                       if (gridView5.rows[t].cells[3].innerHTML.trim() == "D") {
                           BDATA.CT_MNDEBE = Operacion.mround(Number(gridView5.rows[t].cells[4].innerHTML), 2);
                           BDATA.CT_USDEBE = Operacion.mround(Number(gridView5.rows[t].cells[5].innerHTML), 2);
                           BDATA.CT_MNHABER = 0;
                           BDATA.CT_USHABER = 0;
                       }
                       if (gridView5.rows[t].cells[3].innerHTML.trim() == "H") {
                           BDATA.CT_MNHABER = Operacion.mround(Number(gridView5.rows[t].cells[4].innerHTML), 2);
                           BDATA.CT_USHABER = Operacion.mround(Number(gridView5.rows[t].cells[5].innerHTML), 2);
                           BDATA.CT_MNDEBE = 0;
                           BDATA.CT_USDEBE = 0;
                       }

                       BDATA.CT_FECPRO = "";
                       BDATA.CT_FORCOS = "1";//CONTROL PARA DECREMENTAR 
                       BDATA.CT_FECPRO2 = (fecha.getFullYear().toString() + "" + (Number(fecha.getMonth() + 1) < 10 ? "0" + (fecha.getMonth() + 1) : (fecha.getMonth() + 1))).trim();
                       $.ajax({
                           type: "POST",
                           url: "Contabilizacion.aspx/ACTUALIZACOST",
                           data: '{DETA: ' + JSON.stringify(BDATA) + '}',
                           contentType: "application/json; charset=utf-8",
                           dataType: "json",
                           async: false,
                           success: function (response) {

                               //alert("COSTO actualizado");
                           },
                           error: function (response) {
                               if (response.length != 0)
                                   alert(response);
                               console.log(response);

                           }
                       });

                   }

               }
              
          }
             function ConsultaDatosCuenta(cuenta) {
                 var anexocuenta="";
                 $.ajax({
                     type: "POST",
                     url: "Contabilizacion.aspx/ConsultaUnaCuenta",
                     data: '{descri: ' + cuenta + '}',
                     contentType: "application/json; charset=utf-8",
                     dataType: "json",
                     async: false,
                     success: function (data) {
                         for (var i = 0; i < data.d.length; i++) {
                                 anexocuenta = (data.d[i].PVANEXO.trim());
                           }
                     },
                     error: function (response) {
                         if (response.length != 0)
                             console.log(response);
                     }
                 });
                 return{anexocuenta};
             }

             function ActualizaEstado() {

                 var fecha = new Date();
                 var annio = fecha.getFullYear().toString();
                 var tabla = {};
                 tabla.CODIGO_DETALLE = Operacion.mask('lblcodigodetalle').text();
                 tabla.ESTADO = "C";
                
                 $.ajax({
                     type: "POST",
                     url: "Contabilizacion.aspx/CambiarEstado",
                     data: '{COM: ' + JSON.stringify(tabla) + '}',
                     contentType: "application/json; charset=utf-8",
                     dataType: "json",
                     async: false,
                     success: function (response) {
                        // ActComprobante(DETACAB.CCOMPRO, DETACAB.CSUBDIA, DETACAB.CSUBDIA);
                     },
                     error: function (response) {  
                         if (response.length != 0)
                             alert(response);
                         console.log(response);

                     }
                 });
             }
             ////asiento 27
             $(".editar27").click(function () {
                 $("#Asiento27").dialog('open');
                
                 tipocambioVenta();
                 filtrardetallespara27();
                 recorregriddetalle27();

             });
                       function recorregriddetalle27() {
            contarndw = 0;
            subsoles = 0; descc = 0; igvv = 0;
            sumasoles = 0; subdolares = 0; sumadolares = 0;

            var gridView = document.getElementById("<%=gvsubdiario27.ClientID %>");

            for (var t = 1; t < gridView.rows.length; t++) {
               
                cellPivotdolares = gridView.rows[t].cells[5];
                cellPivotsoles = gridView.rows[t].cells[4];
                subdolares = cellPivotdolares.innerHTML;
                subsoles = cellPivotsoles.innerHTML;

                if (gridView.rows[t].cells[3].innerHTML == "D") {
                    sumasoles = new Number(Operacion.mask('lbldebesoles27').text()) + Math.abs(new Number(subsoles));
                    sumadolares = new Number(Operacion.mask('lbldebedolares27').text()) + Math.abs(new Number(subdolares));
                    Operacion.mask('lbldebedolares27').text(Operacion.mround(sumadolares,2));
                    Operacion.mask('lbldebesoles27').text(Operacion.mround(sumasoles,2));
                }
                if (gridView.rows[t].cells[3].innerHTML == "H") {
                    sumasoles = new Number(Operacion.mask('lblhabersoles27').text()) + Math.abs(new Number(subsoles));
                    sumadolares = new Number(Operacion.mask('lblhaberdolares27').text()) + Math.abs(new Number(subdolares));
                    Operacion.mask('lblhaberdolares27').text(Operacion.mround(sumadolares,2));
                    Operacion.mask('lblhabersoles27').text(Operacion.mround(sumasoles,2));
                }
                                           
            }                         
           }

             function ConsultaCaja() {
                 var VC = {};
                 VC.TIPO = Operacion.mask('lblcodtipo').text();
                 var cuenta = "";
                 var DESCRIPCION = "";
                 $.ajax({

                     type: "POST",
                     url: "Contabilizacion.aspx/listarCajas",
                     data: '{PDATA: ' + JSON.stringify(VC) + '}',
                     contentType: "application/json; charset=utf-8",
                     dataType: "json",
                     async:false,
                     success: function (data) {
                         for (var i = 0; i < data.d.length; i++) {                            
                             cuenta = data.d[i].CUENTA;
                             if(data.d[i].FLAG==1){
                                 DESCRIPCION = data.d[i].DESCRIPCION
                             }
                             
                         }
                     },
                     error: function (response) {
                         if (response.length != 0)
                             console.log(response);
                     }                     
                 });
                 return { cuenta, DESCRIPCION}
                 }

            function filtrardetallespara27() {
                var VC = {};
                VC.ORDEN_NUMERO = Operacion.mask('lblsolicitud').text();
                VC.CODIGO_CAJA = Operacion.mask('lblcodtipo').text();
                var indicador = 0;
                var fecha = new Date();
                $.ajax({

                    type: "POST",
                    url: "Contabilizacion.aspx/ListarTodos",
                    data: '{com: ' + JSON.stringify(VC) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {

                        if (data.d.length > 0) {
                            var row = $("[id*=gvsubdiario27] tr:last-child").clone(true);
                            $("[id*=gvsubdiario27] tr").not($("[id*=gvsubdiario27] tr:first-child")).remove();
                            for (var i = 0; i < data.d.length; i++) {
                                if (data.d[i].TIPO_DOCUMENTO.trim() == M_ARRAY27[0]) { //|| data.d[i].TIPO_DOCUMENTO.trim() == "RH"
                                                                   
                                    $("td", row).eq(1).html(Operacion.mask('lblmoneda').text() == M_ARRAY27[1] ? M_ARRAY27[2] : M_ARRAY27[5]);
                                    $("td", row).eq(2).html("");
                                    indicador = 0;
                                    $("td", row).eq(9).html(moment(data.d[i].FECHA_VENCIMIENTO).format("DD/MM/YYYY"));
                                }
                                else {
                                    if (data.d[i].TIPO_DOCUMENTO.trim() == M_ARRAY27[6]) { //|| data.d[i].TIPO_DOCUMENTO.trim() == "RH"
                                        $("td", row).eq(1).html(Operacion.mask('lblmoneda').text() == M_ARRAY27[7] ? M_ARRAY27[8] : M_ARRAY27[11]);
                                        $("td", row).eq(2).html("");
                                        indicador = 0;
                                        $("td", row).eq(9).html(moment(data.d[i].FECHA_VENCIMIENTO).format("DD/MM/YYYY"));
                                    }
                                    else {
                                        $("td", row).eq(1).html(data.d[i].CUENTA);
                                        $("td", row).eq(2).html(data.d[i].CENCOS);
                                        indicador = 1;
                                        $("td", row).eq(9).html(null);
                                    }                                    
                                }
                                $("td", row).eq(1).val(data.d[i].MOTIVO);
                                $("td", row).eq(0).html("27");
                                $("td", row).eq(0).val(data.d[i].CODIGO_PROVEEDOR);
                                $("td", row).eq(3).html("D");
                                $("td", row).eq(3).val(new Date());
                                    $("td", row).eq(4).html(Operacion.mask('lblmoneda').text() == "MN" ? data.d[i].TOTAL :Operacion.mround(Number(data.d[i].TOTAL) * Number(Operacion.mask('lbltipocambio27').text()),2));
                                    $("td", row).eq(4).val("  ");
                                    $("td", row).eq(5).html(Operacion.mask('lblmoneda').text() == "US" ? data.d[i].TOTAL : Operacion.mround(Number(data.d[i].TOTAL) / Number(Operacion.mask('lbltipocambio27').text()), 2));
                                    $("td", row).eq(5).val("            ");
                                    $("td", row).eq(6).html(data.d[i].TIPO_DOCUMENTO);
                                    $("td", row).eq(7).html(data.d[i].NUM_DOCUMENTO);
                                    $("td", row).eq(8).html(moment(data.d[i].FECHA_EMISION).format("DD/MM/YYYY"));
                                   // $("td", row).eq(9).html(moment(data.d[i].FECHA_VENCIMIENTO).format("DD/MM/YYYY"));
                                    $("[id*=gvsubdiario27]").append(row);
                                    row = $("[id*=gvsubdiario27] tr:last-child").clone(true);

                                ///origen y destino 
                       if (indicador == 1) {                                      
                            if (CUENTASORIGENDESTINO(data.d[i].CUENTA).origen.trim() != "") {
                                $("td", row).eq(0).html("27");
                                $("td", row).eq(0).val(CUENTASORIGENDESTINO(data.d[i].CUENTA).anexo != "" ? (CUENTASORIGENDESTINO(data.d[i].CUENTA).anexo == "P" ? data.d[i].CODIGO_PROVEEDOR : Operacion.mask('lblcodsolicitante').text()) : "                  ");
                                $("td", row).eq(1).html(CUENTASORIGENDESTINO(data.d[i].CUENTA).origen);
                                $("td", row).eq(1).val(data.d[i].MOTIVO);
                                $("td", row).eq(2).html("");
                                $("td", row).eq(3).html("D");
                                $("td", row).eq(3).val(null);
                                $("td", row).eq(4).html(Operacion.mask('lblmoneda').text() == "MN" ? data.d[i].TOTAL : Operacion.mround(Number(data.d[i].TOTAL) * Number(Operacion.mask('lbltipocambio27').text()), 2));
                                $("td", row).eq(4).val("AT");
                                $("td", row).eq(5).html(Operacion.mask('lblmoneda').text() == "US" ? data.d[i].TOTAL : Operacion.mround(Number(data.d[i].TOTAL) / Number(Operacion.mask('lbltipocambio27').text()), 2));
                                $("td", row).eq(5).val(data.d[i].CUENTA);
                                $("td", row).eq(6).html(data.d[i].TIPO_DOCUMENTO);
                                $("td", row).eq(7).html(data.d[i].NUM_DOCUMENTO);
                                //$("td", row).eq(8).html(moment(data.d[i].FECHA_EMISION).format("DD/MM/YYYY"));
                                // $("td", row).eq(9).html(moment(data.d[i].FECHA_VENCIMIENTO).format("DD/MM/YYYY"));
                                $("td", row).eq(9).html(null);
                                $("[id*=gvsubdiario27]").append(row);
                                row = $("[id*=gvsubdiario27] tr:last-child").clone(true);
                            }
                            if (CUENTASORIGENDESTINO(data.d[i].CUENTA).destino.trim() != "") {
                                $("td", row).eq(0).html("27");
                                $("td", row).eq(0).val(CUENTASORIGENDESTINO(data.d[i].CUENTA).anexo != "" ? (CUENTASORIGENDESTINO(data.d[i].CUENTA).anexo == "P" ? data.d[i].CODIGO_PROVEEDOR : Operacion.mask('lblcodsolicitante').text()) : "                  ");
                                $("td", row).eq(1).html(CUENTASORIGENDESTINO(data.d[i].CUENTA).destino);
                                $("td", row).eq(1).val(data.d[i].MOTIVO);
                                $("td", row).eq(2).html("");
                                $("td", row).eq(3).html("H");
                                $("td", row).eq(3).val(null);
                                $("td", row).eq(4).html(Operacion.mask('lblmoneda').text() == "MN" ? data.d[i].TOTAL : Operacion.mround(Number(data.d[i].TOTAL) * Number(Operacion.mask('lbltipocambio27').text()), 2));
                                $("td", row).eq(4).val("AT");
                                $("td", row).eq(5).html(Operacion.mask('lblmoneda').text() == "US" ? data.d[i].TOTAL : Operacion.mround(Number(data.d[i].TOTAL) / Number(Operacion.mask('lbltipocambio27').text()), 2));
                                $("td", row).eq(5).val(data.d[i].CUENTA);
                                $("td", row).eq(6).html(data.d[i].TIPO_DOCUMENTO);
                                $("td", row).eq(7).html(data.d[i].NUM_DOCUMENTO);
                                $("td", row).eq(9).html(null);
                                //$("td", row).eq(8).html(moment(data.d[i].FECHA_EMISION).format("DD/MM/YYYY"));
                                //$("td", row).eq(9).html(moment(data.d[i].FECHA_VENCIMIENTO).format("DD/MM/YYYY"));
                                $("[id*=gvsubdiario27]").append(row);
                                row = $("[id*=gvsubdiario27] tr:last-child").clone(true);
                            }                         
                       }
                                ////fin origen y destino 
                      }
                            
                        } else {
                            var row = $("[id*=gvsubdiario27] tr:last-child").clone(true);
                            $("[id*=gvsubdiario27] tr").not($("[id*=gvsubdiario27] tr:first-child")).remove();

                            $("td", row).eq(1).html("");
                            $("td", row).eq(2).html("");
                            $("td", row).eq(3).html("");
                            $("td", row).eq(4).html("");
                            $("td", row).eq(5).html("");
                            $("td", row).eq(6).html("");
                            $("td", row).eq(7).html("");
                            $("td", row).eq(8).html("");
                            $("td", row).eq(0).html("");
                            $("[id*=gvsubdiario27]").append(row);
                            alert("no se encontro registro");
                        }
                        // INSERCION DEL TOTAL
                        $("td", row).eq(1).html(ConsultaCaja().cuenta);
                        $("td", row).eq(1).val("RENDICION DE CAJA");
                        $("td", row).eq(0).html("27");
                        $("td", row).eq(0).val(Operacion.mask('lblcodsolicitante').text());
                        $("td", row).eq(2).html("");
                        $("td", row).eq(3).html("H");
                        $("td", row).eq(3).val(new Date());
                        $("td", row).eq(4).html(Operacion.mask('lblmoneda').text() == "MN" ? Operacion.mask('txtmontodeclarado').val() : Operacion.mround(Number(Operacion.mask('txtmontodeclarado').val()) * Number(Operacion.mask('lbltipocambio27').text()), 2));
                        $("td", row).eq(4).val("  ");
                        $("td", row).eq(5).html(Operacion.mask('lblmoneda').text() == "US" ? Operacion.mask('txtmontodeclarado').val() : Operacion.mround(Number(Operacion.mask('txtmontodeclarado').val()) / Number(Operacion.mask('lbltipocambio27').text()), 2));
                        $("td", row).eq(5).val("            ");
                        $("td", row).eq(6).html("VR");
                        $("td", row).eq(7).html(ConsultaCaja().DESCRIPCION == "" ? (fecha.getDate()).toString() + "" + (fecha.getMonth() + 1 < 10 ? "0" + (fecha.getMonth() + 1).toString() : fecha.getMonth() + 1).toString() + "" + (fecha.getFullYear()).toString().substr(2, 4) : ConsultaCaja().DESCRIPCION);
                        //$("td", row).eq(8).html(moment(data.d[i].FECHA_EMISION).format("DD/MM/YYYY"));
                        //$("td", row).eq(9).html(moment(data.d[i].FECHA_VENCIMIENTO).format("DD/MM/YYYY"));
                        $("td", row).eq(9).html(null);
                        $("[id*=gvsubdiario27]").append(row);
                        row = $("[id*=gvsubdiario27] tr:last-child").clone(true);
                        // fin insercion total                                        
                    },
                    error: function (response) {
                        if (response.length != 0)
                            alert(response);
                    }
                });

           
                }

              });       

    </script>
    <style type="text/css">
        #btnactualizar {
            width: 69px;
        }

        #btnact {
            width: 146px;
        }

        #btnsalir {
            width: 58px;
        }

        #btnadicionales {
            width: 115px;
        }

        #btnfinalizar {
            width: 31px;
        }

        .seleciona {
        }
        .auto-style1 {
            overflow: auto;
            width: 932px;
            height: 200px;
        }
        .auto-style2 {
            overflow: auto;
            width: 927px;
            height: 200px;
        }
        .auto-style3 {
            height: 25px;
        }
        </style>
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="contenedor">
        <div id="Creacion" title="Creación">
            <table>
                <tr>
                 <td>
                   Número:
               </td>
               <td>
                   <asp:TextBox ID="txtnumerob" runat="server" ReadOnly="True"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td>
                   Fecha Ini:
               </td>
               <td>
                   <asp:TextBox ID="txtfechaini" runat="server" ></asp:TextBox>
               </td>
               <td>
                   Fecha Fin:
               
                   <asp:TextBox ID="txtfechafin" runat="server" ></asp:TextBox>
               </td>
           </tr>

           <tr>
               <td>
                   Solicitante:
               </td>
               <td>
                   <asp:TextBox ID="txtcodsolicitanteb" runat="server" ></asp:TextBox>
               </td>
                <td>
                   <asp:TextBox ID="txtsolicitanteb" runat="server" Width="257px" ></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td>
                   Banco:
               </td>
               <td>
                   <asp:TextBox ID="txtcodbancob" runat="server" ></asp:TextBox>
               </td>
               <td>
                   <asp:TextBox ID="txtbancob" runat="server" Width="257px" ></asp:TextBox>
               </td>
              </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnver" runat="server" Text="Consultar" OnClick="btnver_Click" />
                        
                    </td>
                    <td>
                       
                        <asp:TextBox ID="txtfechaactual" runat="server"></asp:TextBox>
                       
                    </td>
                    <td>
                        
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblusuario" runat="server" Text="" style="display:none"></asp:Label>
                   
                    </td>
                </tr>
                <tr>
                    <td>
                       
                        &nbsp;</td>
                </tr>
            </table>
              <table>
                <tr>
                    <td>
                        <div style="overflow: auto; width: 850px; height: 550px">
                            <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" OnRowCreated="griddata_RowCreated" Font-Size="Smaller" Width="830px" class="buscar">
                                <Columns>
                                    <asp:BoundField DataField="CODIGO_CAJA" HeaderText="TIPO" />
                                    <asp:BoundField DataField="TIPO" HeaderText="DESCRIPCION" />
                                    <asp:BoundField DataField="ORDEN_NUMERO" HeaderText="ORDEN" >
                                       
                                        </asp:BoundField>
                                    <asp:BoundField DataField="FECHA" HeaderText="FECHA" DataFormatString="{0:dd/MM/yyyy}">
                                       
                                    </asp:BoundField>
                                    <asp:BoundField DataField="COD_SOLICITANTE" HeaderText="COD. SOL." />
                                    <asp:BoundField DataField="SOLICITANTE" HeaderText="SOLICITANTE">
                                        
                                           <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MOTIVO" HeaderText="MOTIVO" >
                                        
                                        </asp:BoundField>
                                    <asp:BoundField DataField="MONEDA" HeaderText="MONEDA" />
                                    <asp:BoundField DataField="MONTO" HeaderText="MONTO" />


                                    <asp:BoundField DataField="ESTADO" HeaderText="ESTADO" >
                                       
                                        </asp:BoundField>


                                    <asp:TemplateField HeaderText="CONTABILIZAR">


                                        <ItemTemplate>
                                            <div class="modificar" style="text-align: center">
                                                <img alt="" src="../../../Images/valid.png" width="25" style="cursor: pointer" />
                                                <%--<asp:ImageButton ID="imbeliminar" runat="server" ImageUrl="~/Images/Message_Error.png" Width="25px" OnClick="ib_eliminar_Click" onclientclick="javascript:return confirm('Esta Seguro?')"/>--%>
                                            </div>
                                        </ItemTemplate>


                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="IMPRIMIR">


                                        <ItemTemplate>
                                            <div class="imprimir" style="text-align: center">
                                                <img alt="" src="../../../Images/Printer.png" width="25" style="cursor: pointer" />
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

                </tr>
            </table>
        </div>
    </div>
    <div id="NuevoItem" >
        
         <fieldset class="cont_sel">
                    <legend>Datos Solicitud</legend>
             <table>
                 <tr>
                     <td>
                         Nº de Solicitud:
                     </td>
                     <td>
                         <asp:Label ID="lblsolicitud" runat="server" Text=""></asp:Label>
                     </td>  
                      <td>Solicitante</td> 
                           <td>
                         <asp:Label ID="lblcodsolicitante" runat="server" Text=""></asp:Label>
                               
                     </td>  
                     <td><asp:Label ID="lblsolicitante" runat="server" Text=""></asp:Label></td>                             
                 </tr>
                 <tr>
                     <td>
                         Tipo:
                     </td>
                     <td>
                         <asp:Label ID="lblcodtipo" runat="server" Text=""></asp:Label>-
                         <asp:Label ID="lbltipo" runat="server" Text=""></asp:Label>
                     </td>
                 </tr>
                 <tr>
                     <td>
                         Monto:
                     </td>
                     <td>
                          <asp:Label ID="lblmoneda" runat="server" Text=""></asp:Label>-
                         <asp:Label ID="lblmonto" runat="server" Text="">  </asp:Label>
                         <asp:Label ID="lblestado" runat="server" Text="" style="display:none"></asp:Label>
                     </td>
                     <td>Monto Declarado:</td>
                     <td>
                         <asp:TextBox ID="txtmontodeclarado" runat="server" class="calculodif" ReadOnly="true"></asp:TextBox> </td>
                     <td>Diferencia: </td>
                     <td> <asp:Label ID="lbldiferencia" runat="server" Text=""></asp:Label></td>
                      <td> <asp:Label ID="lblcuenta" runat="server" Text=""></asp:Label></td>
                 </tr>
             </table>
             </fieldset>
        <table>
            <tr>
                <td>
                    <div style="overflow: auto; width: 850px; height: 200px">
                    <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" OnRowCreated="griddata_RowCreated" Font-Size="Smaller" Width="830px" class="buscar">
                                <Columns>
                                    <asp:BoundField DataField="RUC" HeaderText="RUC" />
                                    <asp:BoundField DataField="PROVEEDOR" HeaderText="PROVEEDOR" />
                                    <asp:BoundField DataField="TIPO_DOCUMENTO" HeaderText="TIP. DOC." >
                                       
                                        </asp:BoundField>
                                    <asp:BoundField DataField="NUMERO_DOCUMENTO" HeaderText="NUM. DOC">
                                       
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FECHA_EMISION" HeaderText="FECHA_EMISION" DataFormatString="{0:dd/MM/yyyy}">
                                        
                                           <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MONTO_IGV" HeaderText="IGV" >
                                        
                                        </asp:BoundField>
                                    <asp:BoundField DataField="IGV" HeaderText="% IGV" />
                                    <asp:BoundField DataField="PARCIAL" HeaderText="PARCIAL" />


                                    <asp:BoundField DataField="TOTAL" HeaderText="TOTAL" >
                                       
                                        </asp:BoundField>
                                    <asp:BoundField DataField="MOTIVO" HeaderText="MOTIVO" />
                                    

                                    <asp:BoundField DataField="ESTADO" HeaderText="ESTADO" />
                                    

                                    <asp:TemplateField HeaderText="VER">
                                         <ItemTemplate>
                                            <div class="editar" style="text-align: center">
                                                <img alt="" src="../../../Images/Message_Success.png" width="25" style="cursor: pointer" />
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
                
            </tr>
            <tr>
                
                <td class="auto-style3">
                    TOTAL:  
                    <asp:Label ID="lbltotal" runat="server" Text=""></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input id="btngenerar" type="button" value="Generar" class="editar27" /> </td>
            </tr>
        </table>
    </div>
    <div id="Asiento" >
        <table>
            <tr>
                <td>Tipo de Cambio</td>
                <td><asp:Label ID="lbltipocambio" runat="server" Text=""></asp:Label> </td>
                <td><asp:Label ID="lblcodigodetalle" runat="server" Text="" style="display:none"></asp:Label> </td>
                
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <div >
                    <asp:GridView ID="gvasiento" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" OnRowCreated="griddata_RowCreated" Font-Size="Small" Width="630px" class="buscar">
                                <Columns>
                                    <asp:BoundField HeaderText="S.DIARIO"  DataField ="SUBDIARIO" >
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="CUENTA" DataField ="CUENTA" >
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="CEN.COSTO" DataField ="CENTRODECOSTO"  >
                                       
                                        <ItemStyle HorizontalAlign="Center" />
                                       
                                        </asp:BoundField>
                                    <asp:BoundField HeaderText="DDHH" DataField ="DDHH" >
                                       
                                    <ItemStyle HorizontalAlign="Center" />
                                       
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="SOLES" DataField ="SOLES" >
                                                                                  
                                    <ItemStyle HorizontalAlign="Right" />
                                                                                  
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="DOLARES" DataField ="DOLARES" >
                                        
                                        <ItemStyle HorizontalAlign="Right" />
                                        
                                        </asp:BoundField>
                                    <asp:BoundField HeaderText="TIP.DOC" DataField ="TIP.DOC" >
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="NUM.DOC"  DataField = "NUM.DOC" >

                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="FECHA_EMISION" HeaderText="F. DOC." />
                                    <asp:BoundField DataField="FECHA_VENCIMIENTO" HeaderText="F.VENC." />

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
        <table>
            <tr>
                <td>

                </td>
                <td>
                    DEBE
                </td>
                <td>
                    HABER
                </td>
            </tr>
            <tr>
                <td>
                    SOLES&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                <td>
                    <asp:Label ID="lbldebesoles" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblhabersoles" runat="server" Text=""></asp:Label>
                </td>
            </tr>
             <tr>
                <td>
                    DOLARES
                    :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td>
                    <asp:Label ID="lbldebedolares" runat="server" Text=""></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td>
                    <asp:Label ID="lblhaberdolares" runat="server" Text=""></asp:Label>
                </td>
                 <td>
                     <input id="btnaceptar" type="button" value="Aceptar" class="aceptar" />
                 </td>
            </tr>
        </table>
    </div>

     <div id="Asiento27" >
        <table>
            <tr>
                <td>Tipo de Cambio</td>
                <td><asp:Label ID="lbltipocambio27" runat="server" Text=""></asp:Label> </td>
                <td><asp:Label ID="Label2" runat="server" Text="" style="display:none"></asp:Label> </td>
                
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <div>
                    <asp:GridView ID="gvsubdiario27" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" OnRowCreated="griddata_RowCreated" Font-Size="Small" Width="837px" class="buscar" Height="121px">
                                <Columns>
                                    <asp:BoundField HeaderText="S.DIARIO"  DataField ="SUBDIARIO" >
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="CUENTA" DataField ="CUENTA" >
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="CEN.COSTO" DataField ="CENTRODECOSTO"  >
                                       
                                        <ItemStyle HorizontalAlign="Center" />
                                       
                                        </asp:BoundField>
                                    <asp:BoundField HeaderText="DDHH" DataField ="DDHH" >
                                       
                                    <ItemStyle HorizontalAlign="Center" />
                                       
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="SOLES" DataField ="SOLES" >
                                                                                  
                                    <ItemStyle HorizontalAlign="Right" />
                                                                                  
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="DOLARES" DataField ="DOLARES" >
                                        
                                        <ItemStyle HorizontalAlign="Right" />
                                        
                                        </asp:BoundField>
                                    <asp:BoundField HeaderText="TIP.DOC" DataField ="TIP.DOC" >
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="NUM.DOC"  DataField = "NUM.DOC" >

                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                      <asp:BoundField DataField="FECHA_EMISION" HeaderText="F. DOC." />
                                    <asp:BoundField DataField="FECHA_VENCIMIENTO" HeaderText="F.VENC." />

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
        <table>
            <tr>
                <td>

                </td>
                <td>
                    DEBE
                </td>
                <td>
                    HABER
                </td>
            </tr>
            <tr>
                <td>
                    SOLES&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                <td>
                    <asp:Label ID="lbldebesoles27" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblhabersoles27" runat="server" Text=""></asp:Label>
                </td>
            </tr>
             <tr>
                <td>
                    DOLARES
                    :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td>
                    <asp:Label ID="lbldebedolares27" runat="server" Text=""></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td>
                    <asp:Label ID="lblhaberdolares27" runat="server" Text=""></asp:Label>
                </td>
                 <td>
                     <input id="btnaceptar27" type="button" value="Aceptar" class="aceptar27" />
                 </td>
            </tr>
        </table>
    </div>
  
</asp:Content>



