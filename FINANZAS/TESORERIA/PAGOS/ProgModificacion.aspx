
<%@ Page Title="Modificación de Programación" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ProgModificacion.aspx.cs" Inherits="FINANZAS_TESORERIA_PAGOS_ProgModificacion" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link type="text/css" href="../../../CSS/base.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {
            UHTML.id = 'MainContent';
            M_ARRAY = [];
            var pcuenta = "";
            var iniciaPGE = function (CO) {
                var PDATA = {};
                PDATA.AF_COD = CO;
                $.ajax({
                    type: "POST",
                    url: "ProgModificacion.aspx/getPARAM",
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
            pcuenta = M_ARRAY[0];

            $("#MainContent_lblproveedor").autocomplete(
                    {
                        source: function (request, response) {
                            $.ajax({
                                url: "ProgModificacion.aspx/GetProveedoresdes",
                                data: "{ 'texto': '" + request.term + "', 'codigo': 'P'}",
                                dataType: "json",
                                type: "POST",
                                contentType: "application/json; charset=utf-8",
                                dataFilter: function (data) { return data; },
                                success: function (data) {
                                    response($.map(data.d, function (item) {
                                        return {
                                            value: item.ADESANE,
                                            id: item.ACODANE,
                                            v: item.AVANEXO

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
                            $('#MainContent_lblruc').val(str);
                            Operacion.mask('lblanexo').val(ui.item.v);
                            filtrardetalles1();
                            listariguales();

                        }
                    });
            $("#MainContent_lblruc").autocomplete(
                   {
                       source: function (request, response) {
                           $.ajax({
                               url: "ProgModificacion.aspx/GetProveedoresruc",
                               data: "{ 'texto': '" + request.term + "', 'codigo': 'P'}",
                               dataType: "json",
                               type: "POST",
                               contentType: "application/json; charset=utf-8",
                               dataFilter: function (data) { return data; },
                               success: function (data) {
                                   response($.map(data.d, function (item) {
                                       return {
                                           id: item.ADESANE,
                                           value : item.ACODANE,
                                           v: item.AVANEXO

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
                           $('#MainContent_lblproveedor').val(str);
                           Operacion.mask('lblanexo').val(ui.item.v);
                           filtrardetalles1();
                           listariguales();

                       }
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
                    limpiargrilla3();
                    document.getElementById("<%=chklistar.ClientID%>").checked = false;
                },
            });
             function limpiarchecks() {
               var imput = document.getElementsByName('opt');
               for (var i = 0; i < imput.length; i++) {
                    imput[i].checked = false;
                }
            }

            $("#MainContent_txtfecha").datepicker();
            $("#MainContent_txtfechaprog").datepicker();
            $("#MainContent_txtvencimiento1").datepicker();
            $("#MainContent_txtvencimiento2").datepicker();

            $(window).load(function () {
                inicio = 0;
                verificacheck();
            });


            Operacion.oACD('txtdetrar');
            Operacion.mask('txtdetrar').change(function () {
                Operacion.oACD('txtdetrar');
                if ($(this).val() == "99999") {
                    //Operacion.mask('txtdetrar').val($(this).val());
                    Operacion.mask('txtdetrar').val('Todos');
                } else {
                    $("#MainContent_txtdetrar").autocomplete(
                          {
                              source: function (request, response) {
                                  $.ajax({
                                      url: "ProgModificacion.aspx/LISTARdetracciones",
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
                                  $('#MainContent_txtdetrades').val(str);
                              }
                          });
                }
            });

    $("#MainContent_txtbancor").autocomplete(
    {
        source: function (request, response) {
            $.ajax({
                url: "ProgModificacion.aspx/ListarBancosProg",
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
                 url: "ProgModificacion.aspx/ListarBancosProg",
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
            function tipocambiocompra() {
                var fecemi = moment($("#MainContent_txtfechaprog").val(), "DD/MM/YYYY");
                fecemi = fecemi == null ? null : new Date(fecemi);
                var com = {};
                com.XDATE = fecemi;
                $.ajax({

                    type: "POST",
                    url: "ProgModificacion.aspx/obetenertcambiocvEdgar",
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
                    url: "ProgModificacion.aspx/obetenertcambiocvEdgar",
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


            function pad(str, max) {
                if (str != undefined) {
                    str = str.toString();
                    return str.length < max ? pad("0" + str, max) : str;
                }
            }

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

            $(".editar").click(function () {
                trp = $(this).parent().parent();
                id = $("td:eq(1)", trp).html();
                $("#Modificacion").dialog('open');
               // document.getElementById("btnaprobar").style.visibility = "hidden";
                filtrardetalles(id);
                filtrardetallesO(id)
                cabecera(id);
                document.getElementById("<%= rbventa.ClientID %>").checked = true;
                tipocambioVenta();
            });
              $(".fecha").change(function () {
                document.getElementById("<%= rbventa.ClientID %>").checked = true;
                tipocambioVenta()
            });

            function filtrardetalles(codigo) {
                var long = 0;
                $.ajax({

                    type: "POST",
                    url: "ProgModificacion.aspx/LISTARTTODOS",
                    data: "{ 'dato': '" + codigo + "' }",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        //console.log(data);
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

                                $("td", row).eq(12).html(data.d[i].GD_CTASDET.substring(0, 8));

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
            function filtrardetallesO(codigo) {
                var long = 0;
                $.ajax({

                    type: "POST",
                    url: "ProgModificacion.aspx/LISTARTTODOS",
                    data: "{ 'dato': '" + codigo + "' }",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        //console.log(data);
                        if (data.d.length > 0) {
                            var row = $("[id*=GridView2] tr:last-child").clone(true);
                            $("[id*=GridView2] tr").not($("[id*=GridView2] tr:first-child")).remove();

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

                                $("td", row).eq(12).html(data.d[i].GD_CTASDET.substring(0,8));

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
            function cabecera(codigo) {
                $.ajax({

                    type: "POST",
                    url: "ProgModificacion.aspx/LISTARUNO",
                    data: "{ 'CODATA': '" + codigo + "' }",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {

                        if (data.d.length > 0) {

                            for (var i = 0; i < data.d.length; i++) {

                                Operacion.mask('ddlagencia0').val(data.d[i].AGENCIA);
                                for (var tipo = 0 ; tipo < document.getElementById("<%= ddlagencia0.ClientID %>").length; tipo++) {
                                    if (document.getElementById("<%= ddlagencia0.ClientID %>").options[tipo].text == (data.d[i].AGENCIA2))
                                        document.getElementById("<%= ddlagencia0.ClientID %>").selectedIndex = tipo;
                                }
                                $('#MainContent_txtnumprog').val(data.d[i].numope);

                                Operacion.mask('ddlconcepto0').val(data.d[i].ESTADO);
                                for (var tipo = 0 ; tipo < document.getElementById("<%= ddlconcepto0.ClientID %>").length; tipo++) {
                                    if (document.getElementById("<%= ddlconcepto0.ClientID %>").options[tipo].text == (data.d[i].CONCEPTO))
                                        document.getElementById("<%= ddlconcepto0.ClientID %>").selectedIndex = tipo;
                                }

                               // alert(data.d[i].USUCRE + " - " + data.d[i].tipopago);
                                Operacion.mask('ddltipopago0').val(data.d[i].USUCRE);
                                for (var tipo = 0 ; tipo < document.getElementById("<%= ddltipopago0.ClientID %>").length; tipo++) {
                                    if (document.getElementById("<%= ddltipopago0.ClientID %>").options[tipo].text == (data.d[i].tipopago))
                                        document.getElementById("<%= ddltipopago0.ClientID %>").selectedIndex = tipo;
                                }
                                $('#MainContent_txtfechaprog').val((moment(data.d[i].fecah).format("DD/MM/YYYY")));

                                if (data.d[i].TIPODETRACCION != null) {
                                    long = data.d[i].TIPODETRACCION.length;
                                    $('#MainContent_txtdetrades').val(data.d[i].TIPODETRACCION.substring(0, long - 15));
                                }
                                else {
                                    $('#MainContent_txtdetrades').val("TODOS");
                                }
                                $('#MainContent_txtdetrar').val(data.d[i].TASADETRACCION);
                                                               
                                Operacion.mask('ddldepartamento0').val(data.d[i].coddepartamento);                               
                                for (var DEP = 0 ; DEP < document.getElementById("<%= ddldepartamento0.ClientID %>").length; DEP++) {
                                    if (document.getElementById("<%= ddldepartamento0.ClientID %>").options[DEP].text == (data.d[i].DEPARTAMENTO)) {
                                         document.getElementById("<%= ddldepartamento0.ClientID %>").selectedIndex = DEP;
                                    }                                       
                                }
                                $('#MainContent_txtbancor').val(data.d[i].CODBANCO);
                                $('#MainContent_lblbancor').val(data.d[i].BANCO);

                                $('#MainContent_lbltotalacumulado1').html(Number(data.d[i].IMPORTE).toFixed(2));          
                                
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
            //function InsertaLog(ind) {
            //    var f = new Date();
            //    var ADATA = {};
            //    ADATA.L2_CNUMOPE = $('#MainContent_txtprogramacionmod').val();
            //    ADATA.L2_CCODAGE = $('#MainContent_lblcodagencia').html();
            //    ADATA.L2_CUSUCRE = $('#MainContent_lblusuario').html();
            //    ADATA.L2_DFECCRE = f;


            //    if (ind == "A") {
            //        ADATA.L2_CTIPTRA = "03";
            //        ADATA.L2_CDESCRI = "Aprobación de Programación";
            //        ADATA.L2_CORIGEN = "CPPROG10";

            //    }
            //    else {

            //        ADATA.L2_CTIPTRA = "02";
            //        ADATA.L2_CDESCRI = "Eliminación de Programación";
            //        ADATA.L2_CORIGEN = "CPPROG04";
            //    }


            //    $.ajax({
            //        type: "POST",
            //        url: "ProgModificacion.aspx/InsertaLog2",
            //        data: '{ADATA: ' + JSON.stringify(ADATA) + '}',
            //        contentType: "application/json; charset=utf-8",
            //        dataType: "json",
            //        async: false,
            //        success: function (response) {
            //            // alert("Aprobado, ya puede ejecutar la programación");
            //            location.reload();
            //        },
            //        error: function (response) {
            //            if (response.length != 0)
            //                console.log(response);

            //        }
            //    });
            // }

            $(".Estado").click(function () {

                if ($('#MainContent_txtestadomod').val() == "APROBADA") {
                    alert("La programación ya ha sido aprobada");
                }

                else {
                    var DETA = {};
                    DETA.GC_CNUMOPE = $('#MainContent_txtprogramacionmod').val();
                    DETA.GC_CUSUAPR = $('#MainContent_lblusuario').html();
                    DETA.GC_CCODAGE = $('#MainContent_lblcodagencia').html();
                    $.ajax({
                        type: "POST",
                        url: "ProgModificacion.aspx/actualizaEstado",
                        data: '{alumno: ' + JSON.stringify(DETA) + '}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (response) {
                            alert("Aprobado, ya puede ejecutar la programación");
                            InsertaLog("A");
                            location.reload();
                        },
                        error: function (response) {
                            if (response.length != 0)
                                console.log(response);

                        }
                    });
                    $("#Modificacion").dialog('close');
                }
            });

            $(".eliminarUno").click(function () {

                if (confirm("¿ Desea Eliminar este item ?")) {
                    var trp = $(this).parent().parent();
                        trp.remove();
                }
                recorregridaux1();

            });
            $(".agregarmismo").click(function () {

                $("#detalle").dialog('open');
               

            });
            
            $(".grabar").click(function () {

               
                if (confirm("Desea Modificar la programación: " + $('#MainContent_txtnumprog').val())) {
                        var DETA = {};
                        DETA.GC_CNUMOPE = $('#MainContent_txtnumprog').val();
                        DETA.GC_CCODAGE = Operacion.mask('ddlagencia0').val();
                        //InsertaLog("E");
                        $.ajax({
                            type: "POST",
                            url: "ProgModificacion.aspx/ELIMINACABECERA",
                            data: '{alumno: ' + JSON.stringify(DETA) + '}',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            async: false,
                            success: function (response) {
                                //alert("REGISTRO ELIMINADO");
                            },
                            error: function (response) {
                                if (response.length != 0)
                                    console.log(response);

                            }
                        });
                        var ADATA = {};
                        var gridView = document.getElementById("<%=GridView2.ClientID %>");
                        for (var t = 1; t < gridView.rows.length; t++) {

                            ADATA.GD_CNUMOPE = $('#MainContent_txtnumprog').val();
                            ADATA.GD_CCODAGE = Operacion.mask('ddlagencia0').val();
                            ADATA.GD_CSECUE = gridView.rows[t].cells[0].value;

                            $.ajax({
                                type: "POST",
                                url: "ProgModificacion.aspx/ELIMINADETALLE",
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
                    // $("#Modificacion").dialog('close');
                        InsertarSolicitud();
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
                $(".listar").click(function () {
                trp = $(this).parent().parent();
                id = $("td:eq(1)", trp).html();
                $('#MainContent_txtprogramacion').val(id);
                var boton = document.getElementById("<%=btnlistar.ClientID%>");
                boton.click();
                
                });

            function filtrardetalles1() {
                var VC = {};
                VC.CP_CCODIGO = Operacion.mask('lblruc').val();
                VC.CP_CCUENTA = pcuenta;
                VC.CP_CVANEXO = $("#MainContent_lblanexo").val();
                $.ajax({

                    type: "POST",
                    url: "ProgModificacion.aspx/filtrodetalle",
                    data: '{VC: ' + JSON.stringify(VC) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {

                        if (data.d.length > 0) {
                            var row = $("[id*=GridView3] tr:last-child").clone(true);
                            $("[id*=GridView3] tr").not($("[id*=GridView3] tr:first-child")).remove();

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

                                $("[id*=GridView3]").append(row);
                                row = $("[id*=GridView3] tr:last-child").clone(true);
                            }
                        } else {
                            var row = $("[id*=GridView3] tr:last-child").clone(true);
                            $("[id*=GridView3] tr").not($("[id*=GridView3] tr:first-child")).remove();

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
                var gridView = document.getElementById("<%=GridView3.ClientID %>");

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
           $(".valida").click(function () {
                $("#detalle").dialog('open');
                if ((document.getElementById("<%=chklistar.ClientID%>").checked == true)) {
                    var imput = document.getElementsByName('opt');
                    var gridView = document.getElementById("<%=GridView3.ClientID %>");
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
                    var gridView = document.getElementById("<%=GridView3.ClientID %>");
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

                var gridView = document.getElementById("<%=GridView3.ClientID %>");

                for (var t = 1; t < gridView.rows.length; t++) {
                    var inputs = gridView.rows[t].getElementsByTagName('input');

                    cellPivot = gridView.rows[t].cells[12];
                    subtt = cellPivot.innerHTML;
                    sumasub = new Number(sumasub) + new Number(subtt);
                }

                $("#MainContent_lbltotalacumulado").html(sumasub.toFixed(2));
            }
             $(".Continuar").click(function () {

                var gridView = document.getElementById("<%=GridView1.ClientID %>");
                for (var t = 0; t < gridView.rows.length; t++) {
                    if (gridView.rows[t].cells[1].innerHTML == $("#MainContent_lblruc").html()) {
                        gridView.rows[t].cells[6].innerHTML = $("#MainContent_lbltotalacumulado").html();
                    }
                }
                borrariguales();
                var gv3 = document.getElementById("<%=GridView1.ClientID %>");
               
                if (gv3.rows.length == 1) {
                    agregarblanco();
                }
                AgregarGrilla();
                recorregridaux1();
                limpiarchecks();
               // limpiargrilla2();
                //$("#MainContent_lbltotalacumulado").html("0.00")
                document.getElementById("<%=chklistar.ClientID%>").checked = false;
                $("#detalle").dialog('close');
                
             });
            
            function recorregridaux1() {
                subtt = 0; acum = 0;
                sumasub = 0; tc =  Number($("#MainContent_txttipocambio").val());

                var gridView = document.getElementById("<%=GridView1.ClientID %>");

                for (var t = 1; t < gridView.rows.length; t++) {
                    var inputs = gridView.rows[t].getElementsByTagName('input');
                   
                    if (gridView.rows[t].cells[7].textContent == "MN") {
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

                $("#MainContent_lbltotalacumulado1").html(sumasub.toFixed(2));
            }

               function AgregarGrilla() {
                var imput = document.getElementsByName('opt');
                var gridView = document.getElementById("<%=GridView3.ClientID %>");
                var gridView3 = document.getElementById("<%=GridView1.ClientID %>");
                var rowt = $("[id*=GridView1] tr:last-child").clone(true);
    
                for (var i = 0; i < imput.length; i++) {
                    if (imput[i].checked) {
                        $("td", rowt).eq(0).html(Operacion.mask('lblanexo').val());
                        $("td", rowt).eq(1).html(Operacion.mask('lblruc').val());
                        $("td", rowt).eq(2).html(Operacion.mask('lblproveedor').val());
                        $("td", rowt).eq(3).html(gridView.rows[i + 1].cells[1].innerHTML);

                        $("td", rowt).eq(4).html(gridView.rows[i + 1].cells[2].innerHTML);
                        $("td", rowt).eq(5).html(gridView.rows[i + 1].cells[3].innerHTML);
                        $("td", rowt).eq(6).html(gridView.rows[i + 1].cells[4].innerHTML);
                        $("td", rowt).eq(7).html(gridView.rows[i + 1].cells[6].innerHTML);

                        $("td", rowt).eq(8).html(gridView.rows[i + 1].cells[9].innerHTML);
                        $("td", rowt).eq(9).html(gridView.rows[i + 1].cells[10].innerHTML);
                        $("td", rowt).eq(10).html(gridView.rows[i + 1].cells[11].innerHTML);
                        $("td", rowt).eq(11).html(gridView.rows[i + 1].cells[12].innerHTML);
                        $("td", rowt).eq(12).html(gridView.rows[i + 1].cells[13].innerHTML);
                        $("[id*=GridView1]").append(rowt);
                        rowt = $("[id*=GridView1] tr:last-child").clone(true);
                    }
                }
                inicio = 1;
            }
            function agregarblanco() {
                var table = document.getElementById('<%=GridView1.ClientID %>');
                var newRow = table.insertRow();
                var i = 0;
                for (i = 0; i < 14; i++) {
                    var newCell = newRow.insertCell();
                    newCell.innerHTML = '';
                }

            }

            function listariguales() {

                var gridView2 = document.getElementById("<%=GridView3.ClientID %>");//gd
                var gridView3 = document.getElementById("<%=GridView1.ClientID %>");//gs
                var imput = document.getElementsByName('opt');//egd-gd

                for (var t = 0; t < gridView2.rows.length; t++) {
                    for (var u = 0; u < gridView3.rows.length; u++) {
                        
                        //
                        if ((gridView3.rows[u].cells[4].textContent == gridView2.rows[t].cells[2].textContent)
                            && ($("#MainContent_lblruc").val().trim() == gridView3.rows[u].cells[1].textContent.trim())
                            ) {
                           // alert(gridView3.rows[u].cells[4].textContent.trim() + "    " + gridView2.rows[t].cells[2].textContent.trim());
                            imput[t - 1].checked = true;
                            gridView2.rows[t].cells[9].innerHTML = gridView2.rows[t].cells[7].innerHTML
                            gridView2.rows[t].cells[12].innerHTML = Number(gridView2.rows[t].cells[9].innerHTML) - Number(gridView2.rows[t].cells[11].innerHTML)
                        }

                    }
                }
                recorregridaux();
            }

            function borrariguales() {
                var gridView2 = document.getElementById("<%=GridView3.ClientID %>");//gd
                var gridView3 = document.getElementById("<%=GridView1.ClientID %>");//gs

                for (var t = 1; t < gridView2.rows.length; t++) {
                    for (var u = 1; u < gridView3.rows.length; u++) {
                        if ((gridView3.rows[u].cells[4].textContent == gridView2.rows[t].cells[2].textContent) && ($("#MainContent_lblruc").val() == gridView3.rows[u].cells[1].textContent)) {
                            gridView3.deleteRow(u);
                        }
                    }  }              
            }

            function limpiargrilla3() {

                var row = $("[id*=GridView3] tr:last-child").clone(true);
                $("[id*=GridView3] tr").not($("[id*=GridView3] tr:first-child")).remove();
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
                Operacion.mask('lblanexo').val("");
                Operacion.mask('lblruc').val("");
                Operacion.mask('lblproveedor').val("");
                Operacion.mask('lbltotalacumulado').html("0.00");
            }


            //  proceso de insercion
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
                    url: "ProgModificacion.aspx/InsertaDet",
                    data: '{DETA: ' + JSON.stringify(DETA) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        alert("Registro Grabado");
                        InsertarDetalles();
                       location.reload();

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
                    url: "ProgModificacion.aspx/ActualizaProg",
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

                var gridView = document.getElementById("<%=GridView1.ClientID %>");
                var MI_LEN = gridView.rows.length;
                for (var t = 1; t < MI_LEN; t++) {
                    
                                      

                    var N_PRO = $("#MainContent_txtnumprog").val();
                    //var ultimodato = t.toString();
                    var formato = Operacion.cadenaMascara(t, 4);//ultimodato.length < 4 ? pad("0" + ultimodato, 4) : ultimodato;
                    DETA.GD_CCODAGE = $("#MainContent_ddlagencia0").val();
                    DETA.GD_CNUMOPE = N_PRO;
                    DETA.GD_CSECUE = formato;
                    DETA.GD_CVANEXO = (gridView.rows[t].cells[0].innerHTML).trim();
                    DETA.GD_CCODIGO = (gridView.rows[t].cells[1].innerHTML).trim();
                    DETA.GD_CTIPDOC = (gridView.rows[t].cells[3].innerHTML).trim();
                    DETA.GD_CNUMDOC = (gridView.rows[t].cells[4].innerHTML).trim();
                    DETA.GD_DFECPRO = fecemi;

                    var FECDOC = moment(gridView.rows[t].cells[5].innerHTML, "DD/MM/YYYY");
                    FECDOC = FECDOC == null ? null : new Date(FECDOC);
                    DETA.GD_DFECDOC = FECDOC;

                    var FECVEN = moment(gridView.rows[t].cells[6].innerHTML, "DD/MM/YYYY");
                    FECVEN = FECVEN == null ? null : new Date(FECVEN);
                    DETA.GD_DFECVEN = FECVEN;
                    DETA.GD_CMONCAR = gridView.rows[t].cells[7].innerHTML; // moneda
                    DETA.GD_NORPROG = Number(gridView.rows[t].cells[8].innerHTML);
                    DETA.GD_NTIPCAM = Number($("#MainContent_txttipocambio").val());
                    DETA.GD_CCODMON = $("#MainContent_ddlmoneda").val();
                    DETA.GD_NUSPROG = Operacion.mround((Number(gridView.rows[t].cells[11].innerHTML) / Number($("#MainContent_txttipocambio").val())), 2);
                    DETA.GD_NMNPROG = Operacion.mround((Number(gridView.rows[t].cells[11].innerHTML)),2);
                    DETA.GD_CTIPCTA = "";
                    DETA.GD_CTIPPRO = "";
                    DETA.GD_CNUMCTA = "";
                    DETA.GD_CSUBDIA = "";
                    DETA.GD_CCOMPRO = "";
                    DETA.GD_NMNRETE =Operacion.mround((Number(gridView.rows[t].cells[10].innerHTML)),2);
                    DETA.GD_NUSRETE =Operacion.mround((Number(gridView.rows[t].cells[10].innerHTML) / Number($("#MainContent_txttipocambio").val())),2);
                    DETA.GD_NORRETE = Number("0.00");
                    DETA.GD_CRETE ="";
                    DETA.GD_NPORRE = Number("0.00");
                    DETA.GD_CTASDET = (gridView.rows[t].cells[12].innerHTML).trim().substring(0, 8);
                    DETA.GD_CSUBCOM = "";
                    DETA.GD_CNUMCOM = "";
                    DETA.GD_CSECCOM = "";
                    DETA.GD_CTDREF = "";
                    DETA.GD_CNDREF = "";
                    DETA.GD_NTCORI = Number("0.00");
                   
                    $.ajax({
                        type: "POST",
                        url: "ProgModificacion.aspx/InsertaDetalle",
                        data: '{DETA: ' + JSON.stringify(DETA) + '}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (response) {
                           
                        },
                        error: function (response) {
                            if (response.length != 0)
                                console.log(DETA);

                        }
                    });

                    

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
            width: 80px;
        }
       fieldset{
           width:1050px;
       }
        #btnagregarnuevo {
            width: 102px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="contenedor">
        <div id="Creacion" title="Creación">

            <fieldset>
                <legend>
                    MODIFICACIÓN DE PROGRAMACIÓN DE PAGO
                </legend>

            <table>
                 <tr style="display:none">
                    <td>
                        <asp:Label ID="lblusuario" runat="server" ForeColor="#f1f1f1"></asp:Label>
                    </td>

                </tr>
                <tr>
                    <td class="auto-style1">
                        <input id="rbdia" name="opcion" type="radio" value="1" runat="server" class="LIMPIAR" />
                        Dia                                                <br />

                    </td>
                    <td>
                        <asp:TextBox ID="txtfecha" runat="server" Width="146px"></asp:TextBox>
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
                    <td>
                        <asp:Button ID="btnlistar" runat="server" OnClick="btnlistar_Click" Width="0px" BorderStyle="None" />
                        <asp:TextBox ID="txtprogramacion" runat="server" BorderStyle="None" Width="0px"></asp:TextBox>
                    &nbsp;<asp:Button ID="btninconsistencias1" runat="server" Text="inconsistencias" OnClick="btninconsistencias1_Click" Width="0px" BorderStyle="None" />
                    </td>
                </tr>

            </table>
                </fieldset>
            <table>
                <tr>
                    <td>
                        <asp:GridView ID="gvordencompra" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" OnRowCreated="griddata_RowCreated">
                            <Columns>
                                <asp:BoundField DataField="GC_CCODAGE" HeaderText="AGENCIA" />
                                <asp:BoundField DataField="GC_CNUMOPE" HeaderText="PROGRAMACION" />
                                <asp:BoundField DataField="GC_CUSUCRE" HeaderText="FECHA DE PROG">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
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
                                 <asp:TemplateField HeaderText="LISTAR">

                                     <ItemTemplate>
                                        <div class="listar" style="text-align: center">
                                            <img alt="" src="../../../Images/exel.jpg" width="25" style="cursor: pointer" />
                                        </div>
                                    </ItemTemplate>

                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="INFORME">

                                     <ItemTemplate>
                                        <div class="inconsistencia" style="text-align: center">
                                            <img alt="" src="../../../Images/exel.jpg" width="25" style="cursor: pointer" />
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
        <div id="Modificacion" >
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
                        <asp:TextBox ID="txtfechaprog" runat="server" Enabled="true" class="fecha"></asp:TextBox>
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
                        <asp:TextBox ID="txtdetades" runat="server"></asp:TextBox>
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
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <div style="overflow: auto; width: 1000px; height: 250px">
                            <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" OnRowCreated="griddata_RowCreated" Font-Size="Smaller" Width="969px">
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


                                    <asp:TemplateField HeaderText="ELIMINAR">

                                        <ItemTemplate>
                                            <div class="eliminarUno" style="text-align: center">
                                                <img alt="" src="../../../Images/Message_Error.png" width="25" style="cursor: pointer" />
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
                    <td>
                        <div style="overflow: auto; width: 1000px; height: 250px; display:none" >
                            <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" OnRowCreated="griddata_RowCreated" Font-Size="Smaller" Width="969px" style="display:none">
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


                                    <asp:TemplateField HeaderText="ELIMINAR">

                                        <ItemTemplate>
                                            <div class="eliminarUno" style="text-align: center">
                                                <img alt="" src="../../../Images/Message_Error.png" width="25" style="cursor: pointer" />
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
            <table >
                <tr>
                    <td> TOTAL ACUMULADO:      </td>
                    <td>
                        <asp:Label ID="lbltotalacumulado1" runat="server" Text="Label"></asp:Label>
                    </td>
                    
                </tr>

            </table>
            <table >
                <tr>

                    <td>
                        <input id="btnagregar" type="button" value="Agregar" class="agregarmismo" />
                    </td>
                    <td>
                        <input id="btngrabar" type="button" value="Grabar" class="grabar" /></td>
                </tr>

            </table>

        </div>

    </div>
    <br />
            <div id="detalle" style="display:none">
            <table>
                <tr>
                    <td>
                        <asp:CheckBox runat="server" Text="Todos/Ninguno" class="valida" ID="chklistar" />
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Acreedor:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                    
                    <td>
                        <asp:Textbox ID="lblruc" runat="server" Text=""></asp:Textbox></td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Textbox ID="lblproveedor" runat="server" Text=""></asp:Textbox>
                    </td>
                    <td>
                        <asp:Textbox ID="lblanexo" runat="server" Text=""></asp:Textbox>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:GridView ID="GridView3" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" OnRowCreated="griddata_RowCreated" Width="782px" Font-Size="Smaller">
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
</asp:Content>

