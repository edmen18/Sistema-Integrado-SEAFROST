<%@ Page Title="Emisión Cheques" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="EmisionCheques.aspx.cs" Inherits="FINANZAS_TESORERIA_CHEQUES_EmisionCheques" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link type="text/css" href="../../../CSS/base.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {
            mi_detalle = [], dcuentas = []; dfirmas = [];
            M_ARRAY = [];
            var iniciaPGE = function (CO) {
                var PDATA = {};
                PDATA.AF_COD = CO;
                $.ajax({
                    type: "POST",
                    url: "EmisionCheques.aspx/getPARAM",
                    data: '{ PDATA: ' + JSON.stringify(PDATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        if (data.d.length > 0) {
                            jQuery.each(data.d, function (i, v) {
                                M_ARRAY.push(v.AF_TDESCRI1.trim() + "-" + v.AF_TDESCRI2);
                            });
                        } else {
                        }
                    },
                    error: function (response) {
                        console.table(response);
                    }
                });

            }
            iniciaPGE("AD");
            //console.log(M_ARRAY);

            $("#MainContent_txtfecha").datepicker();
            $("#MainContent_txtfechadiferido").datepicker();

            UHTML.id = 'MainContent';
            Operacion.mask('txtcriterio').keypress(function () {
                var s = $(this).val().toUpperCase().split(" ");
                $(".buscar tr:hidden").show();
                $.each(s, function () {
                    $(".buscar tr:visible .pro:not(:contains('" + this + "'))").parent().hide();
                });

            });


            $(".tipocambio").click(function () {

                if ((document.getElementById("<%=rbventa.ClientID%>").checked == true)) {
                     tipocambioVenta();

                 }
                 if ((document.getElementById("<%=rbcompra.ClientID%>").checked == true)) {
                     tipocambiocompra();
                 }

             });


            function tipocambiocompra() {
                var fecemi = moment($("#MainContent_txtfecha").val(), "DD/MM/YYYY");
                fecemi = fecemi == null ? null : new Date(fecemi);
                var com = {};
                com.XDATE = fecemi;
                $.ajax({

                    type: "POST",
                    url: "EmisionCheques.aspx/obetenertcambiocvEdgar",
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
            $(".fecha").change(function () {
                document.getElementById("<%= rbventa.ClientID %>").checked = true;
                tipocambioVenta()
            });
            function tipocambioVenta() {
                var fecemi = moment($("#MainContent_txtfecha").val(), "DD/MM/YYYY");
                fecemi = fecemi == null ? null : new Date(fecemi);
                var com = {};
                com.XDATE = fecemi;
                $.ajax({

                    type: "POST",
                    url: "EmisionCheques.aspx/obetenertcambiocvEdgar",
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
            function GENERARCHEQUE() {
                var banco = Operacion.mask('txtbancor').val();

                $.ajax({

                    type: "POST",
                    url: "EmisionCheques.aspx/ListarDatosBancoID",
                    data: "{ 'ban': '" + banco + "' }",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        if (Operacion.mask('ddlcartera').val() == "1") {
                            Operacion.mask('txtcheque').val(Operacion.cadenaMascara(Number(data.d.CT_NCHEQ01) + 1, 8));
                        }
                        if (Operacion.mask('ddlcartera').val() == "2") {
                            Operacion.mask('txtcheque').val(Operacion.cadenaMascara(Number(data.d.CT_NCHEQ02) + 1, 8));
                        }
                        if (Operacion.mask('ddlcartera').val() == "3") {
                            Operacion.mask('txtcheque').val(Operacion.cadenaMascara(Number(data.d.CT_NCHEQ03) + 1, 8));
                        }
                        Operacion.mask('lblfirma1').text(data.d.CT_CNOMFR1);
                        Operacion.mask('lblfirma2').text(data.d.CT_CNOMFR2);
                        Operacion.mask('lblfirma3').text(data.d.CT_CNOMFR3);
                        Operacion.mask('lblfirma4').text(data.d.CT_CNOMFR4);
                    },
                    error: function (data) {
                        if (data.length != 0)
                            alert(data);
                    }
                });
            }
            $('#adicionales').dialog({
                autoOpen: false,
                modal: true,
                resizable: true,
                width: 1000,
                heigth: 100,
                title: 'Movimientos Adicionales',
                close: function (event, ui) {
                },
            });

            $('#Nuevo').dialog({
                autoOpen: false,
                modal: true,
                resizable: true,
                width: 1000,
                heigth: 100,
                title: 'Registro',
                close: function (event, ui) {
                    if (comprobantefinal !="") {
                    window.open("../CHEQUES/ImprimeCheque.aspx?CHEQUE= " + Operacion.mask('txtcheque').val() + "&SUBDIARIO=" + Operacion.mask('ddlsubdiario').val() + "&COMPROBANTE=" + comprobantefinal, '_blank');
                    location.reload();
                    }
                    
                },
            });
            $(".adicionales").click(function () {
                if (Operacion.mask('txtdctos').val() == "" || Operacion.mask('txtdctos').val() == "0") {
                    alert("No ha seleccionado ningun documento");
                }
                else {
                    $("#adicionales").dialog('open');
                }


            });

            $(".Nuevo").click(function () {
                $("#Nuevo").dialog('open');
                $("#MainContent_ddlarea").val("E01");
                for (var area = 0 ; area < document.getElementById("<%= ddlarea.ClientID %>").length; area++) {
                      if (document.getElementById("<%= ddlarea.ClientID %>").options[area].text == ("E01-E01-PROVEEDORES MATERIA PRIMA"))
                         document.getElementById("<%= ddlarea.ClientID %>").selectedIndex = area;
             }
                 document.getElementById("<%= rbventa.ClientID %>").checked = true;
                 tipocambioVenta();
                 trp = $(this).parent().parent();
                 id = $("td:eq(1)", trp).html();
                 descripcion = $("td:eq(2)", trp).html();
                 anexo = $("td:eq(0)", trp).html();
                 document.getElementById("btnconfirmnar").style.visibility = "hidden";
                 document.getElementById("btnconfirmnar1").style.visibility = "visible";

                 Operacion.mask('txtruc').val(id);
                 Operacion.mask('txtacreedor').val(descripcion);
                 Operacion.mask('txtnombregirar').val(descripcion);
                 Operacion.mask('lblanexo').text(anexo);
                 filtrardetalles();
                 montodetraccion();
             });

            $("#MainContent_txtcuenta").autocomplete(
              {
                  source: function (request, response) {
                      $.ajax({
                          url: "EmisionCheques.aspx/ListaPlanID",
                          data: "{ 'PDATA': '" + request.term + "' }",
                          dataType: "json",
                          type: "POST",
                          contentType: "application/json; charset=utf-8",
                          dataFilter: function (data) { return data; },
                          success: function (data) {
                              response($.map(data.d, function (item) {
                                  return {
                                      id: item.PCUENTA,
                                      value: item.PCUENTA + "-" + item.PDESCRI,

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
                      posicionEspacio = cadena.indexOf("-"),
                      primerApellido = cadena.substring(0, posicionEspacio)
                  }

              });

            $("#MainContent_txtbancor").autocomplete(
                {
                    source: function (request, response) {
                        $.ajax({
                            url: "EmisionCheques.aspx/ListarBancosProg",
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
                        $('#MainContent_lblbancor').val(str);
                        $('#MainContent_txtmoneda').val(ui.item.v);
                        $('#MainContent_txtcuentabanco').val(ui.item.b);
                        GENERARCHEQUE();

                        // VALIDACION
                        $("#MainContent_txtdctos").val("0");
                        $('#MainContent_txtmadicional').val("0.00");
                        var imput = document.getElementsByName('opt');
                        var gridView = document.getElementById("<%=GridView2.ClientID %>");
              for (var i = 0; i < imput.length; i++) {
                  imput[i].checked = false
              }

              for (var i = 0; i < imput.length; i++) {
                  if (imput[i].checked) {
                      gridView.rows[i + 1].cells[8].innerHTML = gridView.rows[i + 1].cells[7].innerHTML
                  }
                  else {
                      gridView.rows[i + 1].cells[8].innerHTML = "";
                  }
              }

              recorregridaux();
              limpiargrilla3();
                     }
                 });


            $("#MainContent_lblbancor").autocomplete(
     {
         source: function (request, response) {
             $.ajax({
                 url: "EmisionCheques.aspx/ListarBancosProg",
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
             $('#MainContent_txtmoneda').val(ui.item.v);
             GENERARCHEQUE();
             // VALIDACION
             $("#MainContent_txtdctos").val("0");
             $('#MainContent_txtmadicional').val("0.00");
             var imput = document.getElementsByName('opt');
             var gridView = document.getElementById("<%=GridView2.ClientID %>");
              for (var i = 0; i < imput.length; i++) {
                  imput[i].checked = false
              }

              for (var i = 0; i < imput.length; i++) {
                  if (imput[i].checked) {
                      gridView.rows[i + 1].cells[8].innerHTML = gridView.rows[i + 1].cells[7].innerHTML
                  }
                  else {
                      gridView.rows[i + 1].cells[8].innerHTML = "";
                  }
              }

              recorregridaux();
              limpiargrilla3();
          }
      });

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

            }
            function limpiargrilla4() {

                var row = $("[id*=GridView4] tr:last-child").clone(true);
                $("[id*=GridView4] tr").not($("[id*=GridView4] tr:first-child")).remove();
                $("td", row).eq(0).html("");
                $("td", row).eq(2).html("");
                $("td", row).eq(3).html("");
                $("td", row).eq(4).html("");
                $("td", row).eq(5).html("");
                $("td", row).eq(6).html("");
                $("td", row).eq(1).html("");
                $("[id*=GridView4]").append(row);

            }

            function filtrardetalles() {
                var VC = {};
                VC.CP_CCODIGO = Operacion.mask('txtruc').val();
                VC.CP_CVANEXO = Operacion.mask('lblanexo').text();

                $.ajax({

                    type: "POST",
                    url: "EmisionCheques.aspx/filtrodetalle",
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
                                $("td", row).eq(5).val(data.d[i].CP_NTIPCAM);
                                $("td", row).eq(5).html(data.d[i].CP_CCODMON);
                                if (data.d[i].CP_CCODMON.trim() == "MN") {
                                    if (data.d[i].CP_CTIPDOC == "PA" || data.d[i].CP_CTIPDOC == "NA") {
                                        $("td", row).eq(6).html(Number(data.d[i].CP_NIMPOMN) * (-1));
                                        $("td", row).eq(7).html(Number(data.d[i].CP_NSALDMN) * (-1));

                                        $("td", row).eq(6).val(Number(data.d[i].CP_NIMPOUS) * (-1));
                                        $("td", row).eq(7).val(Number(data.d[i].CP_NSALDUS) * (-1));
                                    }
                                    else {
                                        $("td", row).eq(6).html(data.d[i].CP_NIMPOMN);
                                        $("td", row).eq(7).html(data.d[i].CP_NSALDMN);

                                        $("td", row).eq(6).val(data.d[i].CP_NIMPOUS);
                                        $("td", row).eq(7).val(data.d[i].CP_NSALDUS);
                                    }

                                }
                                else {
                                    if (data.d[i].CP_CTIPDOC == "PA" || data.d[i].CP_CTIPDOC == "NA") {
                                        $("td", row).eq(6).html(Number(data.d[i].CP_NIMPOUS) * (-1));
                                        $("td", row).eq(7).html(Number(data.d[i].CP_NSALDUS) * (-1));
                                        $("td", row).eq(6).val(Number(data.d[i].CP_NIMPOMN) * (-1));
                                        $("td", row).eq(7).val(Number(data.d[i].CP_NSALDMN) * (-1));
                                    }
                                    else {
                                        $("td", row).eq(6).html(data.d[i].CP_NIMPOUS);
                                        $("td", row).eq(7).html(data.d[i].CP_NSALDUS);
                                        $("td", row).eq(6).val(data.d[i].CP_NIMPOMN);
                                        $("td", row).eq(7).val(data.d[i].CP_NSALDMN);
                                    }


                                }
                                $("td", row).eq(8).html(""); //SELECCION 
                                $("td", row).eq(9).html(data.d[i].CP_CRETE);
                                $("td", row).eq(10).html(data.d[i].CP_NPORRE);

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

            $(".firmas").click(function () {
                var cuentas = 0;
                if ((document.getElementById("<%=firma1.ClientID%>").checked == true)) {
                     cuentas = cuentas + 1;
                 }
                 if ((document.getElementById("<%=firma2.ClientID%>").checked == true)) {
                     cuentas = cuentas + 1;
                 }
                 if ((document.getElementById("<%=firma3.ClientID%>").checked == true)) {
                     cuentas = cuentas + 1;
                 }
                 if ((document.getElementById("<%=firma4.ClientID%>").checked == true)) {
                     cuentas = cuentas + 1;
                 }
                 if (cuentas > 2) {
                     alert("Solo se admiten hasta dos firmantes");
                     document.getElementById("<%=firma1.ClientID%>").checked = false;
                     document.getElementById("<%=firma2.ClientID%>").checked = false;
                     document.getElementById("<%=firma3.ClientID%>").checked = false;
                     document.getElementById("<%=firma4.ClientID%>").checked = false;

                 }
             });

            $(".valida").click(function () {
                if (Operacion.mask('txtbancor').val() == "" || Operacion.mask('lblbancor').val() == "" || Number(Operacion.mask('txttipocambio').val()) <= 0) {
                    alert("debe seleccionar un banco y/o ingresar un tipo de cambio");
                }
                else {


                    acum = 0;
                    if ((document.getElementById("<%=chklistar.ClientID%>").checked == true)) {
                         var imput = document.getElementsByName('opt');
                         var gridView = document.getElementById("<%=GridView2.ClientID %>");
                         for (var i = 0; i < imput.length; i++) {
                             imput[i].checked = true
                             acum = acum + 1;
                         }
                         for (var i = 0; i < imput.length; i++) {
                             if (imput[i].checked) {
                                 gridView.rows[i + 1].cells[8].innerHTML = gridView.rows[i + 1].cells[7].innerHTML
                             }
                             else {
                                 gridView.rows[i + 1].cells[8].innerHTML = "";

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
                                 gridView.rows[i + 1].cells[8].innerHTML = gridView.rows[i + 1].cells[7].innerHTML
                             }
                             else {
                                 gridView.rows[i + 1].cells[8].innerHTML = "";

                             }
                         }
                     }
                     $("#MainContent_txtdctos").val(acum);
                     recorregridaux();
                 }

             });

            function recorregridaux() {
                subtt = 0;
                sumasub = 0;
                sumadol = 0;
                retencion = 0;
                var gridView = document.getElementById("<%=GridView2.ClientID %>");
                for (var t = 1; t < gridView.rows.length; t++) {

                    if (Number(gridView.rows[t].cells[8].innerHTML) != 0) {
                        if (gridView.rows[t].cells[5].innerHTML == "MN") { // EN CASO QUE LA MONEDA DE LA GRILLA SEA EN SOLES 
                            cellPivot = gridView.rows[t].cells[8];
                            subtt = cellPivot.innerHTML;
                            sumasub = new Number(sumasub) + new Number(subtt);
                            sumadol = new Number(sumadol) + (new Number(subtt) / Number(Operacion.mask('txttipocambio').val()));

                            if (gridView.rows[t].cells[9].innerHTML == "A") {
                                if (Operacion.mask('txtmoneda').val() == "MN") {
                                    retencion = (Number(retencion) + (Number(gridView.rows[t].cells[8].innerHTML) * (Number(gridView.rows[t].cells[10].innerHTML) / 100))).toFixed(2);
                                }
                                if (Operacion.mask('txtmoneda').val() == "US") {
                                    retencion = (((Number(gridView.rows[t].cells[8].innerHTML) / Number(Operacion.mask('txttipocambio').val())) * (Number(gridView.rows[t].cells[10].innerHTML) / 100)) + Number(retencion)).toFixed(2);
                                }
                            }
                        }
                        if (gridView.rows[t].cells[5].innerHTML == "US") { // EN CASO QUE LA MONEDA DE LA GRILLA SEA EN DOLARES 
                            cellPivot = gridView.rows[t].cells[8];
                            subtt = cellPivot.innerHTML;
                            sumasub = new Number(sumasub) + (new Number(subtt) * Number(Operacion.mask('txttipocambio').val()));
                            sumadol = new Number(sumadol) + Number(gridView.rows[t].cells[8].innerHTML);

                            if (gridView.rows[t].cells[9].innerHTML == "A") {
                                if (Operacion.mask('txtmoneda').val() == "MN") {
                                    retencion = (Number(retencion) + ((Number(gridView.rows[t].cells[8].innerHTML) * (Number(gridView.rows[t].cells[10].innerHTML) / 100)) * Number(Operacion.mask('txttipocambio').val()))).toFixed(2);
                                }

                                if (Operacion.mask('txtmoneda').val() == "US") {
                                    retencion = (Number(retencion) + (Number(gridView.rows[t].cells[8].innerHTML) * (Number(gridView.rows[t].cells[10].innerHTML) / 100))).toFixed(2);
                                }
                            }
                        }

                    }
                }
                $("#MainContent_txtmontomn").val(Number(sumasub).toFixed(2));
                $("#MainContent_txtmontous").val(Number(sumadol).toFixed(2));
                $("#MainContent_txtmretencion").val(retencion);
                //montos adicionales
                if (Operacion.mask('txtmoneda').val().trim() == "MN") {
                    $("#MainContent_txtmdoc").val(Operacion.mround(sumasub, 2));
                    var total = (sumasub - Number(Operacion.mask('txtmretencion').val()) + Number(Operacion.mask('txtmadicional').val()))
                    $("#MainContent_txtmcheque").val(Operacion.mround(total, 2));
                }
                else {
                    $("#MainContent_txtmdoc").val(Operacion.mround(sumadol, 2));
                    var total = (sumadol - Number(Operacion.mask('txtmretencion').val()) + Number(Operacion.mask('txtmadicional').val()))
                    $("#MainContent_txtmcheque").val(Operacion.mround(total, 2));
                }



                if (Number($("#MainContent_txtmcheque").val()) < 0) {

                    alert("El monto no es válido para el cheque");

                    $("#MainContent_txtmontomn").val("0.00");
                    $("#MainContent_txtmontous").val("0.00");
                    $("#MainContent_txtdctos").val("0");

                    $("#MainContent_txtmdoc").val("0.00");
                    $("#MainContent_txtmcheque").val("0.00");
                    $("#MainContent_txtmretencion").val("0.00");
                    $("#MainContent_txtmadicional").val("0.00");

                    var imput = document.getElementsByName('opt');
                    var gridView = document.getElementById("<%=GridView2.ClientID %>");
                      for (var i = 0; i < imput.length; i++) {
                          imput[i].checked = false
                      }

                      for (var i = 0; i < imput.length; i++) {
                          if (imput[i].checked) {
                              gridView.rows[i + 1].cells[8].innerHTML = gridView.rows[i + 1].cells[7].innerHTML
                          }
                          else {
                              gridView.rows[i + 1].cells[8].innerHTML = "";

                          }
                      }
                  }
              }

            $(".validaunoporuno").click(function () {
                if (Operacion.mask('txtbancor').val() == "" || Operacion.mask('lblbancor').val() == "" || Number(Operacion.mask('txttipocambio').val()) <= 0) {
                    alert("debe seleccionar un banco y/o debe ingresar un tipo de cambio");
                }
                else {
                    acum = 0;
                    var imput = document.getElementsByName('opt');
                    var gridView = document.getElementById("<%=GridView2.ClientID %>");

                    for (var i = 0; i < imput.length; i++) {
                        if (imput[i].checked) {
                            gridView.rows[i + 1].cells[8].innerHTML = gridView.rows[i + 1].cells[7].innerHTML

                            acum = acum + 1;
                        }
                        else {
                            gridView.rows[i + 1].cells[8].innerHTML = "";
                        }
                    }
                    $("#MainContent_txtdctos").val(acum);
                    recorregridaux();
                }
            });


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

                return numero;
            }

            $(".seleciona").change(function () {
                acum = 0;
                var imput = document.getElementsByName('opt');
                var ddlcartera = document.getElementById("<%=ddlcartera.ClientID %>");
                if (Operacion.mask('txtbancor').val().trim() != "") {
                    GENERARCHEQUE();
                }
                if (Operacion.mask('ddlcartera').val() == "2") {
                    var dif = new Date();
                    Operacion.mask('txtfechadiferido').val((moment(dif.toString()).format("DD/MM/YYYY")));
                }
                else {
                    Operacion.mask('txtfechadiferido').val("");
                }
            //else {
            //    alert("Debe ingresar los datos del banco");
            //}

        });

            $(".debehaber").change(function () {

                var ddldebehaber = document.getElementById("<%=ddldebehaber.ClientID %>");
            if (Operacion.mask('ddldebehaber').val().trim() == "D") {
                Operacion.mask('txtcuenta').val(M_ARRAY[1]);
            }
            else {
                Operacion.mask('txtcuenta').val(M_ARRAY[2]);
            }

        });


            $(".agregar").click(function () {
                var gridView = document.getElementById("<%=GridView3.ClientID%>");
                var cuentaitems = gridView.rows.length;
                var cuentaitems2 = 0;
                for (var ch = 1; ch < cuentaitems; ch++) {
                    if (gridView.rows[ch].cells[0].innerHTML.trim() != "&nbsp;") {
                        cuentaitems2 = cuentaitems2 + 1;
                    }
                }

                if ($("#MainContent_txtaux").val() == "")  ///en caso de ser nuevo
                {
                    contaditem = contaditem + 1;
                    if ($("#MainContent_txtcuenta").val() != "" || $("#MainContent_txtdebehaber").html() != "" || $("#MainContent_txtimporte").val() != "" || $("#MainContent_txtglosa").val() != "") {
                        var rowt = 0;
                        rowt = $("[id*=GridView3] tr:last-child").clone(true);
                        if (cc == 1) {
                            $("[id*=GridView3] tr").not($("[id*=GridView3] tr:first-child")).remove();
                            cc = 2;
                        }
                        contarndw = 0;
                        contaditem = 0;

                        $("td", rowt).eq(0).html(Operacion.cadenaMascara((cuentaitems2 + 1), 3));
                        $("td", rowt).eq(1).html($("#MainContent_txtcuenta").val().substring(0, $("#MainContent_txtcuenta").val().indexOf("-")));
                        $("td", rowt).eq(4).html($("#MainContent_ddldebehaber").val());
                        $("td", rowt).eq(5).html($("#MainContent_txtimporte").val());

                        $("[id*=GridView3]").append(rowt);
                        rowt = $("[id*=GridView3] tr:last-child").clone(true);
                        contarndw = contarndw + 1;

                        $("#MainContent_txtcuenta").val("");
                        $("#MainContent_txtimporte").val("");
                    }
                    else {
                        alert("Ingrese los Datos completos");
                    }

                }
                else {  // en caso de edicion               
                    var numcondicion = parseFloat($("#MainContent_txttotal").val()) + parseFloat($("#MainContent_txtmontodet").val());
                    validaredicion();
                    $("#MainContent_txtcuenta").val("");
                    $("#MainContent_txtaux").val("");
                    $("#MainContent_txtimporte").val("");
                }
                var sub01 = recorregrid().sumasub;
                //$("#MainContent_txttotal").val(sub01.toFixed(2));
                sub01 = 0;

            });
            function validaredicion() {
                contarndw = 0;
                subtt = 0; descc = 0; igvv = 0;
                sumasub = 0;

                var gridView = document.getElementById("<%=GridView3.ClientID %>");

            for (var t = 1; t < gridView.rows.length; t++) {
                var inputs = gridView.rows[t].getElementsByTagName('input');
                if ((gridView.rows[t].cells[0].innerHTML == $("#MainContent_txtaux").val())) {
                    gridView.rows[t].cells[0].innerHTML = $("#MainContent_txtaux").val();
                    gridView.rows[t].cells[1].innerHTML = $("#MainContent_txtcuenta").val().substring(0, $("#MainContent_txtcuenta").val().indexOf("-"));

                    if (gridView.rows[t].cells[1].innerHTML.trim() == "") {
                        gridView.rows[t].cells[1].innerHTML = $("#MainContent_txtcuenta").val();
                    }
                    else {
                        gridView.rows[t].cells[1].innerHTML = $("#MainContent_txtcuenta").val().substring(0, $("#MainContent_txtcuenta").val().indexOf("-"));
                    }
                    gridView.rows[t].cells[4].innerHTML = $("#MainContent_ddldebehaber").val();
                    gridView.rows[t].cells[5].innerHTML = $("#MainContent_txtimporte").val();

                }

            }

        }
            $(window).load(function () {
                contarndw = 0;
                cc = 1;
                sw_edicion = 0;
                sw_nuevo = 0;
                contaditem = 0;
                inicio = 0;
                Operacion.mask('txtmdoc').val("0.00");
                Operacion.mask('txtmretencion').val("0.00");
                Operacion.mask('txtmadicional').val("0.00");
                Operacion.mask('txtmcheque').val("0.00");
                comprobantefinal = "";
            });
            $(".bteditar").click(function () {

                trp = $(this).parent().parent();
                ext = $("td:eq(1)", trp).val();

                sub01 = 0;
                trp = $(this).parent().parent();
                codigo = $("td:eq(0)", trp).html();
                $("#MainContent_txtaux").val(codigo)

                trp = $(this).parent().parent();
                factura = $("td:eq(1)", trp).html();
                $("#MainContent_txtcuenta").val(factura)

                trp = $(this).parent().parent();
                monto = $("td:eq(4)", trp).html();
                $("#MainContent_ddldebehaber").val(monto)

                anticipo = $("td:eq(5)", trp).html();
                $("#MainContent_txtimporte").val(anticipo)

                var sub01 = recorregrid1().sumasub;
                //$("#MainContent_txttotal").val(sub01.toFixed(2));
                sub01 = 0;
            });
            $(".btelimina").click(function () {

                trpe = $(this).parent().parent();

                var trp = $(this).parent().parent();
                if (Number(contarndw) > 1) {
                    trp.remove();
                    contarndw = Number(contarndw) - 1;
                } else {
                    $("td:eq(0)", trp).html(""); $("td:eq(1)", trp).html("");
                    $("td:eq(4)", trp).html(""); $("td:eq(5)", trp).html("");
                    cc = 1;
                }

                var sub01 = recorregrid().sumasub;
                //$("#MainContent_txttotal").val(sub01.toFixed(2));
                sub01 = 0;

            });
            function recorregrid() {
                contarndw = 0;
                subtt = 0; descc = 0; igvv = 0;
                sumasub = 0; suu = 0; sumh = 0;
                var gridView = document.getElementById("<%=GridView3.ClientID %>");

            for (var t = 1; t < gridView.rows.length; t++) {
                var inputs = gridView.rows[t].getElementsByTagName('input');


                if (gridView.rows[t].cells[4].innerHTML.trim() == "D") {
                    cellPivot = gridView.rows[t].cells[5];
                    subtt = cellPivot.innerHTML;
                    sumasub = Number(sumasub) + Number(subtt);
                }
                else {
                    cellPivot1 = gridView.rows[t].cells[5];
                    suu = cellPivot1.innerHTML;
                    sumh = Number(sumh) + Number(suu);
                }
                contarndw++;
                Operacion.mask('txtdebe').val(sumasub);
                Operacion.mask('txthaber').val(sumh);
                Operacion.mask('txtdiferencia').val(sumasub - sumh);
            }

            return {
                sumasub
            };
        }

            function recorregrid1() {
                contarndw = 0;
                subtt = 0; descc = 0; igvv = 0;
                sumasub = 0; suu = 0; sumh = 0;
                var gridView = document.getElementById("<%=GridView3.ClientID %>");
            for (var t = 1; t < gridView.rows.length; t++) {
                var inputs = gridView.rows[t].getElementsByTagName('input');


                if (gridView.rows[t].cells[4].innerHTML.trim() == "D") {
                    cellPivot = gridView.rows[t].cells[5];
                    subtt = cellPivot.innerHTML;
                    sumasub = Number(sumasub) + Number(subtt);
                }
                else {
                    cellPivot1 = gridView.rows[t].cells[5];
                    suu = cellPivot1.innerHTML;
                    sumh = Number(sumh) + Number(suu);
                }
                contarndw++;
                Operacion.mask('txtdebe').val(sumasub);
                Operacion.mask('txthaber').val(sumh);
                Operacion.mask('txtdiferencia').val(sumasub - sumh);
            }
            return {
                sumasub
            };
        }

            //PARA PASAR LOS DATOS DE UNA GRILLA A OTRA

            function limpiargrilla3() {
                Operacion.mask("txtdebe").val("");
                Operacion.mask("txthaber").val("");
                Operacion.mask("txtdiferencia").val("");
                Operacion.mask("txtglosa").val("");

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
                $("td", row).eq(0).html("");

                $("[id*=GridView3]").append(row);
            }


            $(".PASARGRILLA").click(function () {
                Operacion.mask('txtmadicional').val(Operacion.mask('txtdiferencia').val());
                $("#MainContent_txtmcheque").val(Operacion.mround((Number($("#MainContent_txtmdoc").val()) - Number(Operacion.mask('txtmretencion').val()) + Number(Operacion.mask('txtmadicional').val())), 2));
                $("#adicionales").dialog('close');

            });

            function montodetraccion() {
                var VC = {};
                VC.AC_CCODIGO = Operacion.mask('txtruc').val();
                VC.AC_CVANEXO = Operacion.mask('lblanexo').text();

                $.ajax({

                    type: "POST",
                    url: "EmisionCheques.aspx/listarMaestroxunID",
                    data: '{ADATA: ' + JSON.stringify(VC) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {

                        //if (data.d.length > 0) {

                        // for (var i = 0; i < data.d.length; i++) {
                        Operacion.mask('txtporretencion').val(data.d.AC_NPORRE);
                        // }

                        // } 
                    },
                    error: function (response) {
                        if (response.length != 0)
                            alert(response);
                    }
                });
            }

            /// INICIO DEL PROCESO DE PAGO DE CHEQUE
            $(".CONFIRMAR1").click(function () {

                // $("#MostrarDetalles").dialog('open');

                if (Operacion.mask('ddlcartera').val() == "2") {
                    if (Operacion.mask('txtfecha').val() == Operacion.mask('txtfechadiferido').val()) {
                        alert("La fecha diferido no es valida");
                    }
                    else {
                        if (Number(Operacion.mask('txtmcheque').val()) > 0) {
                            if (Number(Operacion.mask('txttipocambio').val()) > 0) {
                                var codigo = $('#MainContent_txtcheque').val();
                                var comprobante = generar().ultimodato;
                                if (comprobante != "" && comprobante != null) {
                                    insertadetcomprobante1(comprobante);
                                    recorregriddetalle();
                                    document.getElementById("btnconfirmnar1").style.visibility = "hidden";
                                    document.getElementById("btnconfirmnar").style.visibility = "visible";
                                }
                                else {
                                    alert("No se ha generado ningun comprobante");
                                }
                            }
                            else {
                                alert("Debe ingresar un tipo de cambio para continuar");
                            }

                        }
                        else {
                            alert("No ha seleccionado ningun comprobante");
                        }
                    }
                }
                else {
                    if (Number(Operacion.mask('txtmcheque').val()) > 0) {
                        if (Number(Operacion.mask('txttipocambio').val()) > 0) {
                            var codigo = $('#MainContent_txtcheque').val();
                            var comprobante = generar().ultimodato;
                            if (comprobante != "" && comprobante != null) {
                                insertadetcomprobante1(comprobante);
                                recorregriddetalle();
                                document.getElementById("btnconfirmnar1").style.visibility = "hidden";
                                document.getElementById("btnconfirmnar").style.visibility = "visible";
                            }
                            else {
                                alert("No se ha generado ningun comprobante");
                            }
                        }
                        else {
                            alert("Debe ingresar un tipo de cambio para continuar");
                        }

                    }
                    else {
                        alert("No ha seleccionado ningun comprobante");
                    }
                }



            });

            $(".CONFIRMAR").click(function () {
                var codigo = $('#MainContent_txtcheque').val();
                var comprobante = generar().ultimodato;
                if (comprobante != "" && comprobante != null) {
                    ActCartera(comprobante);
                    $("#Nuevo").dialog('close');
                  }
                else {
                    alert("No se ha generado ningun comprobante");
                }
            });

            // funcion para generar el numero de comprobante con el subdiario 23 correspondiente a cheques
            function generar() {
                var element = $('#MainContent_txtfecha').val();
                var fecha = element.split('/');
                var FECDOC = fecha[2].substr(2, 2) + "" + fecha[1] + "" + fecha[0];
                var ultimodato = "";
                var formato = "";
                var DATA = {};
                DATA.CTSUBDIA = Operacion.mask('ddlsubdiario').val();//Operacion.mask('ddlSDIA').val();
                DATA.CTANO = fecha[2].substr(2, 2);
                DATA.CTMES = fecha[1];

                $.ajax({
                    type: "POST",
                    url: "EmisionCheques.aspx/correlativoCP",
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
            function correlativo(ADATA) {

                // var contador = "";
                var formato = "";
                $.ajax({

                    type: "POST",
                    url: "EmisionCheques.aspx/CORRELATIVO",
                    data: '{ADATA: ' + JSON.stringify(ADATA) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        formato = data.d;
                    },
                    error: function (data) {
                        if (data.length != 0)
                            console.log(ADATA);
                    }
                });
                return { formato };
            }

            function ActCartera(Comprob) {
                var f = moment($("#MainContent_txtfecha").val(), "DD/MM/YYYY");
                f = f == null ? null : new Date(f);
                var dia = "";
                var mes = "";
                var annio = "";
                var i = 0;
                var DETA = {};
                var GD = {};
                var fecha = Operacion.mask('txtfecha').val();
                DETA.CP_CCODIGO = Operacion.mask('txtruc').val();
                DETA.CP_CVANEXO = Operacion.mask('lblanexo').text();


                var imput = document.getElementsByName('opt');
                var gridView = document.getElementById("<%=GridView2.ClientID %>");

                 for (i = 0; i < imput.length; i++) {
                     if (imput[i].checked) {
                         DETA.CP_CTIPDOC = gridView.rows[i + 1].cells[1].innerHTML;
                         DETA.CP_CNUMDOC = gridView.rows[i + 1].cells[2].innerHTML;

                         $.ajax({
                             type: "POST",
                             url: "EmisionCheques.aspx/actualizarsaldoENEJECUCION",
                             data: '{DETA: ' + JSON.stringify(DETA) + '}',
                             contentType: "application/json; charset=utf-8",
                             dataType: "json",
                             async: false,
                             success: function (response) {
                                 //  if (i==(imput.length-1)){

                                 // }

                             },
                             error: function (response) {
                                 if (response.length != 0)
                                     console.log(response);
                             }
                         });

                     }
                 }
                 InsertaPago(Comprob);

             }
            function InsertaPago(Comprob) {

                var f = moment($("#MainContent_txtfecha").val(), "DD/MM/YYYY");
                f = f == null ? null : new Date(f);
                var dia = "";
                var mes = "";
                var annio = "";
                var i = 0;
                var GD = {};
                GD.GD_CCODIGO = Operacion.mask('txtruc').val();
                GD.GD_CVANEXO = Operacion.mask('lblanexo').text();
                var pago = {};
                var gridView = document.getElementById("<%=GridView2.ClientID %>");
                var imput = document.getElementsByName('opt');
                pago.totalcmp = 0;

                for (i = 0; i < imput.length; i++) {
                    if (imput[i].checked) {
                        pago.PG_CVANEXO = Operacion.mask('lblanexo').text();
                        pago.PG_CCODIGO = Operacion.mask('txtruc').val();
                        pago.PG_CTIPDOC = gridView.rows[i + 1].cells[1].innerHTML;
                        pago.PG_CNUMDOC = gridView.rows[i + 1].cells[2].innerHTML;
                        pago.PG_CDEBHAB = ((gridView.rows[i + 1].cells[1].innerHTML == "PA" || gridView.rows[i + 1].cells[1].innerHTML == "NA") ? "H" : "D");
                        // PARA EL CÁLCULO DEL MONTO SEGUN LAS MONEDAS
                        if (Operacion.mask('txtmoneda').val().trim() == "MN") {
                            if ((gridView.rows[i + 1].cells[5].innerHTML).trim() == "US") {
                                pago.PG_NIMPOMN = Math.abs(Operacion.mround(Number((gridView.rows[i + 1].cells[7].value)), 2));
                                pago.PG_NIMPOUS = Math.abs(Operacion.mround(Number((gridView.rows[i + 1].cells[8].innerHTML)), 2));
                                if ((gridView.rows[i + 1].cells[1].innerHTML != "PA" && gridView.rows[i + 1].cells[1].innerHTML != "NA")) {
                                    pago.totalcmp = Number(pago.totalcmp) + Operacion.mround(Number((gridView.rows[i + 1].cells[7].value)), 2);
                                }

                            }
                            if ((gridView.rows[i + 1].cells[5].innerHTML).trim() == "MN") {
                                pago.PG_NIMPOMN = Math.abs(Operacion.mround(Number((gridView.rows[i + 1].cells[8].innerHTML)), 2));
                                pago.PG_NIMPOUS = Math.abs(Operacion.mround(Number((gridView.rows[i + 1].cells[7].value)), 2));
                                if ((gridView.rows[i + 1].cells[1].innerHTML != "PA" && gridView.rows[i + 1].cells[1].innerHTML != "NA")) {
                                    pago.totalcmp = Number(pago.totalcmp) + Operacion.mround(Number((gridView.rows[i + 1].cells[8].innerHTML)), 2);
                                }
                            }
                        }
                        if (Operacion.mask('txtmoneda').val().trim() == "US") {
                            if ((gridView.rows[i + 1].cells[5].innerHTML).trim() == "US") {
                                pago.PG_NIMPOMN = Math.abs(Operacion.mround(Number((gridView.rows[i + 1].cells[7].value)), 2));
                                pago.PG_NIMPOUS = Math.abs(Operacion.mround(Number((gridView.rows[i + 1].cells[8].innerHTML)), 2));
                                if ((gridView.rows[i + 1].cells[1].innerHTML != "PA" && gridView.rows[i + 1].cells[1].innerHTML != "NA")) {
                                    pago.totalcmp = Number(pago.totalcmp) + Operacion.mround(Number((gridView.rows[i + 1].cells[8].innerHTML)), 2);
                                }
                            }
                            if ((gridView.rows[i + 1].cells[5].innerHTML).trim() == "MN") {
                                pago.PG_NIMPOMN = Math.abs(Operacion.mround(Number((gridView.rows[i + 1].cells[7].innerHTML)), 2));
                                pago.PG_NIMPOUS = Math.abs(Operacion.mround(Number((gridView.rows[i + 1].cells[7].value)), 2));
                                if ((gridView.rows[i + 1].cells[1].innerHTML != "PA" && gridView.rows[i + 1].cells[1].innerHTML != "NA")) {
                                    pago.totalcmp = Number(pago.totalcmp) + Operacion.mround((Number(gridView.rows[i + 1].cells[7].value)), 2);
                                }
                            }
                        }
                        // fin CÁLCULO DEL MONTO SEGUN LAS MONEDAS.

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
                        annio = Number(f.getFullYear()).toString();
                        pago.PG_CFECCOM = (annio.substr(2, 2) + "" + mes + "" + dia);
                        pago.PG_CSUBDIA = Operacion.mask('ddlsubdiario').val();
                        pago.PG_CNUMCOM = Comprob;
                        pago.PG_CGLOSA = ("CH.:" + Operacion.mask('txtcheque').val() + ", " + datoscompletardetcomprobante(GD).AC_CNOMBRE).substr(0, 39);
                        pago.PG_CCOGAST = "";
                        pago.PG_CORIGEN = "CP";
                        pago.PG_CUSUARI = $('#MainContent_lblusuario').text();
                        pago.PG_CCODMON = Operacion.mask('txtmoneda').val();
                        pago.PG_DFECCOM = f;
                        pago.PG_CORDKEY = correlativo(pago).formato;
                        //  alert(pago.PG_CORDKEY);


                        $.ajax({
                            type: "POST",
                            url: "EmisionCheques.aspx/InsertaPago",
                            data: '{DETA: ' + JSON.stringify(pago) + '}',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            async: false,
                            success: function (response) {
                                // alert("Pago Grabado");
                                if (i == (imput.length - 1)) {

                                }


                            },
                            error: function (response) {
                                if (response.length != 0)
                                    console.log(pago);
                            }
                        });

                    }

                }
                InsertaCheque(Comprob, pago.totalcmp);

            }

            function datoscompletardetcomprobante(numdoc) {

                var AC_CVANEXO = "";
                var AC_CNOMBRE = "";

                $.ajax({

                    type: "POST",
                    url: "EmisionCheques.aspx/datoscompletardetcomprobante",
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

            function InsertarCabComprobante(comprobante, pagocmp) {
                var f = moment($("#MainContent_txtfecha").val(), "DD/MM/YYYY");
                f = f == null ? null : new Date(f);

                var fecha = new Date();
                var annio = fecha.getFullYear().toString();
                var DETACAB = {};
                DETACAB.CSUBDIA = Operacion.mask('ddlsubdiario').val();
                DETACAB.CCOMPRO = comprobante;
                DETACAB.CFECCOM = annio.substr(2, 2) + (Number(f.getMonth() + 1) < 10 ? "0" + (f.getMonth() + 1) : (f.getMonth() + 1)) + f.getDate();
                DETACAB.CCODMON = Operacion.mask('txtmoneda').val();
                DETACAB.CSITUA = "F";
                DETACAB.CTIPCAM = $('#MainContent_txttipocambio').val();
                DETACAB.CGLOSA = $("#MainContent_txtacreedor").val();
                if (Number(Operacion.mask('txtmadicional').val()) <= 0) { // si es haber
                    DETACAB.CTOTAL = Operacion.mround(pagocmp, 2);
                }
                else {  /// si es debe
                    DETACAB.CTOTAL = Operacion.mround((pagocmp + Number(Operacion.mask('txtmadicional').val())), 2);
                }

                DETACAB.CTIPO = (document.getElementById("<%=rbventa.ClientID%>").checked == true ? "V" : document.getElementById("<%=rbcompra.ClientID%>").checked == true ? "M" : "V");
                            DETACAB.CFLAG = "N";
                            DETACAB.CDATE = fecha;
                            DETACAB.CHORA = fecha.getHours() + ":" + ((fecha.getMinutes()).toString().length < 2 ? "0" + fecha.getMinutes() : fecha.getMinutes());
                            DETACAB.CUSER = $("#MainContent_lblusuario").html();
                            DETACAB.CFECCAM = "      ";
                            DETACAB.CORIG = "CP";
                            DETACAB.CFORM = "A";
                            DETACAB.CTIPCOM = "05";
                            DETACAB.CEXTOR = " ";
                            DETACAB.CFECCOM2 = f;
                            DETACAB.CFECCAM2 = null;
                            DETACAB.CMEMO = " ";
                            DETACAB.CSERCER = "    ";
                            DETACAB.CNUMCER = "          ";
                            $.ajax({
                                type: "POST",
                                url: "EmisionCheques.aspx/InsertCabComprobante",
                                data: '{DETA: ' + JSON.stringify(DETACAB) + '}',
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                async: false,
                                success: function (response) {
                                    //alert("CABCOMPROBANTE GUARDADO");
                                    insertadetcomprobante(comprobante);
                                    ActComprobante(Number((DETACAB.CCOMPRO).substr(2, 4)));
                                },
                                error: function (response) {
                                    if (response.length != 0)
                                        alert(response);
                                    console.log(response);

                                }
                            });
                        }
            function firma() {

                if ((document.getElementById("<%=firma1.ClientID%>").checked == true)) {
                    dfirmas.push(Operacion.mask('lblfirma1').text());
                }
                if ((document.getElementById("<%=firma2.ClientID%>").checked == true)) {
                    dfirmas.push(Operacion.mask('lblfirma2').text());
                }
                if ((document.getElementById("<%=firma3.ClientID%>").checked == true)) {
                    dfirmas.push(Operacion.mask('lblfirma3').text());
                }
                if ((document.getElementById("<%=firma4.ClientID%>").checked == true)) {
                    dfirmas.push(Operacion.mask('lblfirma4').text());
                }
            }

            function InsertaCheque(comprobante, pagocmp) {
                firma();

                var f = moment($("#MainContent_txtfecha").val(), "DD/MM/YYYY");
                f = f == null ? null : new Date(f);

                var fd = moment($("#MainContent_txtfechadiferido").val(), "DD/MM/YYYY");
                fd = fd == null ? null : new Date(fd);

                var fecha = new Date();
                var annio = f.getFullYear().toString();
                var annioa = fecha.getFullYear().toString();
                var anniod = fd.getFullYear().toString();

                var DETACHEQUE = {};
                DETACHEQUE.CH_CNUMCTA = Operacion.mask('txtbancor').val();
                DETACHEQUE.CH_CNUMCHE = Operacion.mask('txtcheque').val();
                DETACHEQUE.CH_CFECCHE = annio.substr(2, 2) + (Number(f.getMonth() + 1) < 10 ? "0" + (f.getMonth() + 1) : (f.getMonth() + 1)) + f.getDate();
                DETACHEQUE.CH_CNOMCHE = Operacion.mask('txtacreedor').val();
                DETACHEQUE.CH_CFECCOM = annio.substr(2, 2) + (Number(f.getMonth() + 1) < 10 ? "0" + (f.getMonth() + 1) : (f.getMonth() + 1)) + f.getDate();
                DETACHEQUE.CH_CSUBDIA = Operacion.mask('ddlsubdiario').val();
                DETACHEQUE.CH_CNUMCOM = comprobante;
                DETACHEQUE.CH_NIMPOCH = Operacion.mround(Number($("#MainContent_txtmcheque").val()), 2);

                DETACHEQUE.CH_CCODMON = Operacion.mask('txtmoneda').val();
                DETACHEQUE.CH_CVANEXO = Operacion.mask('lblanexo').text();
                DETACHEQUE.CH_CCODIGO = Operacion.mask('txtruc').val();
                DETACHEQUE.CH_CESTADO = "C";
                DETACHEQUE.CH_CFECEST = annioa.substr(2, 2) + (Number(fecha.getMonth() + 1) < 10 ? "0" + (fecha.getMonth() + 1) : (fecha.getMonth() + 1)) + fecha.getDate();

                DETACHEQUE.CH_CUSUARI = Operacion.mask('lblusuario').text();
                DETACHEQUE.CH_DFECHA = fecha;
                DETACHEQUE.CH_CHORA = fecha.getHours() + ":" + ((fecha.getMinutes()).toString().length < 2 ? "0" + fecha.getMinutes() : fecha.getMinutes());
                DETACHEQUE.CH_CCTACON = Operacion.mask('txtcuentabanco').val();
                DETACHEQUE.CH_CSITUAC = "";
                DETACHEQUE.CH_DOCREFT = "";
                DETACHEQUE.CH_DOCREFN = "";
                DETACHEQUE.CH_CCOGAST = "";
                DETACHEQUE.CH_CCONCEP = Operacion.mask('txtconcepto').val();
                DETACHEQUE.CH_CFECDIF = (Operacion.mask('txtfechadiferido').val() == "" ? "      " : anniod.substr(2, 2) + (Number(fd.getMonth() + 1) < 10 ? "0" + (fd.getMonth() + 1) : (fd.getMonth() + 1)) + fd.getDate());
                DETACHEQUE.CH_NTIPCAM = Operacion.mask('txttipocambio').val();
                DETACHEQUE.CH_DFECCHE = f;
                DETACHEQUE.CH_DFECCOM = f;
                DETACHEQUE.CH_DFECEST = fecha;
                DETACHEQUE.CH_DFECDIF = (Operacion.mask('txtfechadiferido').val() == "" ? null : fd);
                DETACHEQUE.CH_CNOMCH2 = Operacion.mask('txtnombregirar').val();
                DETACHEQUE.CH_CNOMFR1 = (dfirmas[0] == null ? "" : dfirmas[0]);
                DETACHEQUE.CH_CNOMFR2 = (dfirmas[1] == null ? "" : dfirmas[1]);
                DETACHEQUE.CH_CFLGNEG = (document.getElementById("<%=negociable.ClientID%>").checked == true ? "S" : " ");// no negociable

                $.ajax({
                    type: "POST",
                    url: "EmisionCheques.aspx/InsertaCheques",
                    data: '{DETA: ' + JSON.stringify(DETACHEQUE) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        // alert("Inserta Cheque");
                        InsertarCabComprobante(comprobante, pagocmp)
                    },
                    error: function (response) {
                        if (response.length != 0)
                            alert(response);
                        console.log(response);

                    }
                });
            }
            function ActComprobante(numero) {
                var DETA = {};
                var fecha = new Date();
                DETA.CTSUBDIA = Operacion.mask('ddlsubdiario').val();
                DETA.CTANO = (fecha.getFullYear()).toString().substr(2, 2);
                DETA.CTMES = (Number(fecha.getMonth() + 1) < 10 ? "0" + (fecha.getMonth() + 1).toString() : (fecha.getMonth() + 1).toString());
                DETA.CTNUMER = numero.toString();
                console.log(DETA);
                $.ajax({
                    type: "POST",
                    url: "EmisionCheques.aspx/Numeracion",
                    data: '{DETA: ' + JSON.stringify(DETA) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        // alert("NUMERO DE COMPROBANTE ACTUALIZADO");
                    },
                    error: function (response) {
                        if (response.length != 0)
                            console.log(response);
                    }
                });
            }

            function ActualizarChequera(comprobanteb) {
                var DETA = {};
                DETA.CT_CTIPCTA = Operacion.mask('ddlcartera').val();
                DETA.CT_CNUMCTA = Operacion.mask('txtbancor').val();
                DETA.CT_NCHEQ01 = Operacion.mask('txtcheque').val();
                $.ajax({
                    type: "POST",
                    url: "EmisionCheques.aspx/ActualizaCheque",
                    data: '{DETA: ' + JSON.stringify(DETA) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        alert("se ha generado el comprobante Nº " + Operacion.mask('ddlsubdiario').val() + " - " + comprobanteb); //llamar a impresion.
                        comprobantefinal = comprobanteb;
                    },
                    error: function (response) {
                        if (response.length != 0)
                            console.log(response);
                    }
                });
               
            }


            // VISTA PREVIA
            function recorregriddetalle() {
                contarndw = 0;
                subsoles = 0; descc = 0; igvv = 0;
                sumasoles = 0; subdolares = 0; sumadolares = 0;

                var gridView = document.getElementById("<%=GridView4.ClientID %>");

            for (var t = 1; t < gridView.rows.length; t++) {

                cellPivotdolares = gridView.rows[t].cells[4];
                cellPivotsoles = gridView.rows[t].cells[5];
                subdolares = cellPivotdolares.innerHTML;
                subsoles = cellPivotsoles.innerHTML;

                if (gridView.rows[t].cells[1].innerHTML == "D") {
                    sumasoles = new Number(Operacion.mask('lbldebesoles').text()) + (new Number(subsoles));
                    sumadolares = new Number(Operacion.mask('lbldebedolares').text()) + (new Number(subdolares));
                    Operacion.mask('lbldebedolares').text(Operacion.mround(sumadolares, 2));
                    Operacion.mask('lbldebesoles').text(Operacion.mround(sumasoles, 2));
                }
                if (gridView.rows[t].cells[1].innerHTML == "H") {
                    sumasoles = new Number(Operacion.mask('lblhabersoles').text()) + Math.abs(new Number(subsoles));
                    sumadolares = new Number(Operacion.mask('lblhaberdolares').text()) + Math.abs(new Number(subdolares));
                    Operacion.mask('lblhaberdolares').text(Operacion.mround(sumadolares, 2));
                    Operacion.mask('lblhabersoles').text(Operacion.mround(sumasoles, 2));
                }

            }
            if (Number(Operacion.mask('lblhaberdolares').text()) != Number(Operacion.mask('lbldebedolares').text())) {
                Operacion.mask('lblsobrante').text("1");


                if (Math.abs(Number(Operacion.mask('lblhaberdolares').text()) - Number(Operacion.mask('lbldebedolares').text())) < 0.1) {
                    document.getElementById("btnejecutar").style.visibility = "visible";
                    Operacion.mask("lblmontosobrante").text((Math.abs((Operacion.mask('lblhaberdolares').text()) - Number(Operacion.mask('lbldebedolares').text()))).toFixed(2));
                    if (Number(Operacion.mask('lblhaberdolares').text()) > Number(Operacion.mask('lbldebedolares').text())) {
                        Operacion.mask('lbldebehaber').text("D");
                    }
                    else {
                        Operacion.mask('lbldebehaber').text("H");
                    }
                }
                else {
                    //alert("No es posible procesar la ejecucion debido a que hay una diferencia de cambio mayor a 0.1");
                }
            }

            else {
                //document.getElementById("btnejecutar").style.visibility = "visible";
            }

        }
            function insertadetcomprobante1(COMPROBANTE) {
                var GD = {};
                var pago = {};
                var f = new Date();
                var dia = "";
                var mes = "";
                var annio = "";
                var DETADC = {};
                rowt = $("[id*=GridView4] tr:last-child").clone(true);
                var cont = 0;
                var annioven = "";
                var aannio = "";
                var i = 0;
                annio = Number(f.getFullYear()).toString();

                var ftext = moment($("#MainContent_txtfecha").val(), "DD/MM/YYYY");
                ftext = ftext == null ? null : new Date(ftext);

                var imput = document.getElementsByName('opt');
                var gridView = document.getElementById("<%=GridView2.ClientID%>");
                for (i = 1; i < gridView.rows.length; i++) {
                    if (Number(gridView.rows[i].cells[8].innerHTML) != 0) {
                        cont = cont + 1;
                        DETADC.DSUBDIA = Operacion.mask('ddlsubdiario').val();
                        DETADC.DCOMPRO = COMPROBANTE;

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

                        DETADC.DSECUE = Operacion.cadenaMascara(cont, 4);
                        DETADC.DFECCOM = ftext.getFullYear().toString().substr(2, 2) + (Number(ftext.getMonth() + 1) < 10 ? "0" + (ftext.getMonth() + 1) : (ftext.getMonth() + 1)) + ftext.getDate();
                        // alert(DETADC.DFECCOM);
                        if (gridView.rows[i].cells[1].innerHTML == "MN") {
                            DETADC.DCUENTA = Operacion.mask('lblcuentapago').text();
                        }
                        else {
                            DETADC.DCUENTA = Operacion.mask('lblcuentapagodol').text();
                        }

                        DETADC.DCODANE = Operacion.mask('txtruc').val();
                        DETADC.DCENCOS = " ";
                        DETADC.DCODMON = Operacion.mask('txtmoneda').val();
                        DETADC.DDH = "D";
                        DETADC.DTIPDOC = gridView.rows[i].cells[1].innerHTML;
                        DETADC.DNUMDOC = gridView.rows[i].cells[2].innerHTML;

                        var ftext1 = moment(gridView.rows[i].cells[3].innerHTML, "DD/MM/YYYY");
                        ftext1 = ftext1 == null ? null : new Date(ftext1);
                        DETADC.DFECDOC = ftext1.getFullYear().toString().substr(2, 2) + (Number(ftext1.getMonth() + 1) < 10 ? "0" + (ftext1.getMonth() + 1) : (ftext1.getMonth() + 1)) + ftext1.getDate();

                        var ftext2 = moment(gridView.rows[i].cells[4].innerHTML, "DD/MM/YYYY");
                        ftext2 = ftext2 == null ? null : new Date(ftext2);
                        DETADC.DFECVEN = ftext2.getFullYear().toString().substr(2, 2) + (Number(ftext2.getMonth() + 1) < 10 ? "0" + (ftext2.getMonth() + 1) : (ftext2.getMonth() + 1)) + ftext2.getDate();
                        DETADC.DAREA = "";
                        DETADC.DFLAG = "N";
                        DETADC.DDATE = f;
                        DETADC.DXGLOSA = Operacion.mask('txtconcepto').val();

                        if (Operacion.mask('txtmoneda').val() == "MN" && gridView.rows[i].cells[5].innerHTML == "MN") {
                            DETADC.DMNIMPOR = (Number(gridView.rows[i].cells[8].innerHTML)).toFixed(2);
                            DETADC.DUSIMPOR = (Number(gridView.rows[i].cells[7].value)).toFixed(2);
                            DETADC.DIMPORT = (Number(gridView.rows[i].cells[8].innerHTML)).toFixed(2);
                        }

                        if (Operacion.mask('txtmoneda').val() == "US" && gridView.rows[i].cells[5].innerHTML == "US") {
                            DETADC.DUSIMPOR = (Number(gridView.rows[i].cells[8].innerHTML)).toFixed(2);
                            DETADC.DMNIMPOR = (Number(gridView.rows[i].cells[8].innerHTML) * Number(gridView.rows[i].cells[5].value)).toFixed(2);
                            DETADC.DIMPORT = (Number(gridView.rows[i].cells[8].innerHTML) * Number(gridView.rows[i].cells[5].value)).toFixed(2);
                        }

                        if (Operacion.mask('txtmoneda').val() == "US" && gridView.rows[i].cells[5].innerHTML == "MN") {
                            DETADC.DMNIMPOR = (Number(gridView.rows[i].cells[8].innerHTML)).toFixed(2);
                            DETADC.DUSIMPOR = (Number(gridView.rows[i].cells[7].value)).toFixed(2);
                            DETADC.DIMPORT = Number(gridView.rows[i].cells[7].value).toFixed(2);
                        }
                        if (Operacion.mask('txtmoneda').val() == "MN" && gridView.rows[i].cells[5].innerHTML == "US") {
                            DETADC.DUSIMPOR = (Number(gridView.rows[i].cells[8].innerHTML)).toFixed(2);
                            DETADC.DMNIMPOR = (Number(gridView.rows[i].cells[8].innerHTML) * Number(gridView.rows[i].cells[5].value)).toFixed(2);
                            DETADC.DIMPORT = (Number(gridView.rows[i].cells[8].innerHTML) * Number(gridView.rows[i].cells[5].value)).toFixed(2);
                        }
                        DETADC.DCODARC = "01";
                        DETADC.DFECCOM2 = (moment($("#MainContent_txtfecha").val(), "DD/MM/YYYY"));
                        DETADC.DFECDO2 = (moment(gridView.rows[i].cells[3].innerHTML, "DD/MM/YYYY"));
                        DETADC.DFECVEN2 = (moment(gridView.rows[i].cells[4].innerHTML, "DD/MM/YYYY"));
                        DETADC.DCODANE2 = "";
                        DETADC.DVANEXO = Operacion.mask('lblanexo').text();
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
                        DETADC.DRETE = "";
                        DETADC.DPORRE = 0;


                        $("td", rowt).eq(0).html(DETADC.DCUENTA);
                        $("td", rowt).eq(1).html(DETADC.DDH);
                        $("td", rowt).eq(2).html(DETADC.DIMPORT);
                        $("td", rowt).eq(3).html(DETADC.DXGLOSA);
                        $("td", rowt).eq(4).html(DETADC.DUSIMPOR);
                        $("td", rowt).eq(5).html(DETADC.DMNIMPOR);
                        $("[id*=GridView4]").append(rowt);
                        rowt = $("[id*=GridView4] tr:last-child").clone(true);



                        // EN CASO DE RETENCION
                        if ((gridView.rows[i].cells[9].innerHTML).trim() == "A") {
                            cont = cont + 1;
                            DETADC.DSUBDIA = Operacion.mask('ddlsubdiario').val();
                            DETADC.DCOMPRO = COMPROBANTE;
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

                            DETADC.DSECUE = Operacion.cadenaMascara(cont, 4);
                            DETADC.DFECCOM = ftext.getFullYear().toString().substr(2, 2) + (Number(ftext.getMonth() + 1) < 10 ? "0" + (ftext.getMonth() + 1) : (ftext.getMonth() + 1)) + ftext.getDate();
                            DETADC.DCUENTA = Operacion.mask('lblcuentaretencion').text();
                            DETADC.DCODANE = Operacion.mask('txtruc').val();
                            DETADC.DCENCOS = " ";
                            DETADC.DCODMON = Operacion.mask('txtmoneda').val();
                            DETADC.DDH = "H";
                            DETADC.DTIPDOC = gridView.rows[i].cells[1].innerHTML;
                            DETADC.DNUMDOC = gridView.rows[i].cells[2].innerHTML;
                            DETADC.DFECDOC = ftext1.getFullYear().toString().substr(2, 2) + (Number(ftext1.getMonth() + 1) < 10 ? "0" + (ftext1.getMonth() + 1) : (ftext1.getMonth() + 1)) + ftext1.getDate();
                            DETADC.DFECVEN = ftext2.getFullYear().toString().substr(2, 2) + (Number(ftext2.getMonth() + 1) < 10 ? "0" + (ftext2.getMonth() + 1) : (ftext2.getMonth() + 1)) + ftext2.getDate();
                            DETADC.DAREA = "";
                            DETADC.DFLAG = "N";
                            DETADC.DDATE = f;
                            DETADC.DXGLOSA = Operacion.mask('txtconcepto').val();

                            if (Operacion.mask('txtmoneda').val() == "MN" && gridView.rows[i].cells[5].innerHTML == "MN") {
                                DETADC.DMNIMPOR = ((Number(gridView.rows[i].cells[8].innerHTML) * (Number(gridView.rows[i].cells[10].innerHTML) / 100))).toFixed(2);
                                DETADC.DIMPORT = ((Number(gridView.rows[i].cells[8].innerHTML) * (Number(gridView.rows[i].cells[10].innerHTML) / 100))).toFixed(2);
                                DETADC.DUSIMPOR = ((Number(gridView.rows[i].cells[8].innerHTML) * (Number(gridView.rows[i].cells[10].innerHTML) / 100)) / Number(Operacion.mask('txttipocambio').val())).toFixed(2);
                            }

                            if (Operacion.mask('txtmoneda').val() == "US" && gridView.rows[i].cells[5].innerHTML == "US") {
                                DETADC.DMNIMPOR = (((Number(gridView.rows[i].cells[8].innerHTML) * (Number(gridView.rows[i].cells[10].innerHTML) / 100)) * Operacion.mask('txttipocambio').val())).toFixed(2);
                                DETADC.DUSIMPOR = ((Number(gridView.rows[i].cells[8].innerHTML) * (Number(gridView.rows[i].cells[10].innerHTML) / 100))).toFixed(2);
                                DETADC.DIMPORT = ((Number(gridView.rows[i].cells[8].innerHTML) * (Number(gridView.rows[i].cells[10].innerHTML) / 100))).toFixed(2);
                            }

                            if (Operacion.mask('txtmoneda').val() == "US" && gridView.rows[i].cells[5].innerHTML == "MN") {
                                DETADC.DMNIMPOR = (((Number(gridView.rows[i].cells[8].innerHTML) * (Number(gridView.rows[i].cells[10].innerHTML) / 100)))).toFixed(2);
                                DETADC.DUSIMPOR = (((Number(gridView.rows[i].cells[8].innerHTML) * (Number(gridView.rows[i].cells[10].innerHTML) / 100)) / Operacion.mask('txttipocambio').val())).toFixed(2);
                                DETADC.DIMPORT = (((Number(gridView.rows[i].cells[8].innerHTML) * (Number(gridView.rows[i].cells[10].innerHTML) / 100)) / Operacion.mask('txttipocambio').val())).toFixed(2);
                            }

                            if (Operacion.mask('txtmoneda').val() == "MN" && gridView.rows[i].cells[5].innerHTML == "US") {
                                DETADC.DMNIMPOR = (((Number(gridView.rows[i].cells[8].innerHTML) * (Number(gridView.rows[i].cells[10].innerHTML) / 100)) * Operacion.mask('txttipocambio').val())).toFixed(2);
                                DETADC.DUSIMPOR = (((Number(gridView.rows[i].cells[8].innerHTML) * (Number(gridView.rows[i].cells[10].innerHTML) / 100)))).toFixed(2);
                                DETADC.DIMPORT = (((Number(gridView.rows[i].cells[8].innerHTML) * (Number(gridView.rows[i].cells[10].innerHTML) / 100)) * Operacion.mask('txttipocambio').val())).toFixed(2);

                            }

                            DETADC.DCODARC = "";
                            DETADC.DFECCOM2 = (moment($("#MainContent_txtfecha").val(), "DD/MM/YYYY"));
                            DETADC.DFECDO2 = (moment(gridView.rows[i].cells[3].innerHTML, "DD/MM/YYYY"));
                            DETADC.DFECVEN2 = (moment(gridView.rows[i].cells[4].innerHTML, "DD/MM/YYYY"));
                            DETADC.DCODANE2 = "";
                            DETADC.DVANEXO = Operacion.mask('lblanexo').text();
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
                            DETADC.DRETE = "";
                            DETADC.DPORRE = 0;

                            $("td", rowt).eq(0).html(DETADC.DCUENTA);
                            $("td", rowt).eq(1).html(DETADC.DDH);
                            $("td", rowt).eq(2).html(Operacion.mround(Number(DETADC.DIMPORT), 2));
                            $("td", rowt).eq(3).html(DETADC.DXGLOSA);
                            $("td", rowt).eq(4).html(DETADC.DUSIMPOR);
                            $("td", rowt).eq(5).html(DETADC.DMNIMPOR);

                            $("[id*=GridView4]").append(rowt);
                            rowt = $("[id*=GridView4] tr:last-child").clone(true);

                        } // fin retencion

                    }// if del checked

                } // fin for


              // inicio de datos adicionales

                var adicionales = document.getElementById("<%=GridView3.ClientID %>");
                var MI_LEN = adicionales.rows.length;
                for (var t = 1; t < MI_LEN; t++) {
                    if (Number(adicionales.rows[t].cells[5].innerHTML.trim()) > 0) {
                        cont = cont + 1;
                        DETADC.DSUBDIA = Operacion.mask('ddlsubdiario').val();
                        DETADC.DCOMPRO = COMPROBANTE;

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

                        DETADC.DSECUE = Operacion.cadenaMascara(cont, 4);
                        DETADC.DFECCOM = ftext.getFullYear().toString().substr(2, 2) + (Number(ftext.getMonth() + 1) < 10 ? "0" + (ftext.getMonth() + 1) : (ftext.getMonth() + 1)) + ftext.getDate();
                        // alert(DETADC.DFECCOM);
                        DETADC.DCUENTA = adicionales.rows[t].cells[1].innerHTML;
                        DETADC.DCODANE = "";
                        DETADC.DCENCOS = " ";
                        DETADC.DCODMON = Operacion.mask('txtmoneda').val();
                        DETADC.DDH = adicionales.rows[t].cells[4].innerHTML;
                        DETADC.DTIPDOC = "";
                        DETADC.DNUMDOC = "";
                        DETADC.DFECDOC = "";
                        DETADC.DFECVEN = "";
                        DETADC.DAREA = "";
                        DETADC.DFLAG = "N";
                        DETADC.DDATE = f;
                        DETADC.DXGLOSA = "";

                        if (Operacion.mask('txtmoneda').val() == "MN") {
                            DETADC.DMNIMPOR = (Number(adicionales.rows[t].cells[5].innerHTML)).toFixed(2);
                            DETADC.DUSIMPOR = (Number(adicionales.rows[t].cells[5].innerHTML) / Number(Operacion.mask('txttipocambio').val())).toFixed(2);
                            DETADC.DIMPORT = (Number(adicionales.rows[t].cells[5].innerHTML)).toFixed(2);
                        }

                        if (Operacion.mask('txtmoneda').val() == "US") {
                            DETADC.DMNIMPOR = (Number(adicionales.rows[t].cells[5].innerHTML) * Number(Operacion.mask('txttipocambio').val())).toFixed(2);
                            DETADC.DUSIMPOR = (Number(adicionales.rows[t].cells[5].innerHTML)).toFixed(2);
                            DETADC.DIMPORT = (Number(adicionales.rows[t].cells[5].innerHTML)).toFixed(2);
                        }


                        DETADC.DCODARC = "";
                        DETADC.DFECCOM2 = (moment($("#MainContent_txtfecha").val(), "DD/MM/YYYY"));
                        DETADC.DFECDO2 = null;
                        DETADC.DFECVEN2 = null;
                        DETADC.DCODANE2 = "";
                        DETADC.DVANEXO = "";
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
                        DETADC.DRETE = "";
                        DETADC.DPORRE = 0;
                        $("td", rowt).eq(0).html(DETADC.DCUENTA);
                        $("td", rowt).eq(1).html(DETADC.DDH);
                        $("td", rowt).eq(2).html(Operacion.mround(Number(DETADC.DIMPORT), 2));
                        $("td", rowt).eq(3).html(DETADC.DXGLOSA);
                        $("td", rowt).eq(4).html(DETADC.DUSIMPOR);
                        $("td", rowt).eq(5).html(DETADC.DMNIMPOR);

                        $("[id*=GridView4]").append(rowt);
                        rowt = $("[id*=GridView4] tr:last-child").clone(true);


                    } // fin if

                }


              //fin de datos adicionales

              // inicio  totales
                cont = cont + 1;
                DETADC.DSUBDIA = Operacion.mask('ddlsubdiario').val();
                DETADC.DCOMPRO = COMPROBANTE;
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
                DETADC.DSECUE = Operacion.cadenaMascara(cont, 4);
                DETADC.DFECCOM = ftext.getFullYear().toString().substr(2, 2) + (Number(ftext.getMonth() + 1) < 10 ? "0" + (ftext.getMonth() + 1) : (ftext.getMonth() + 1)) + ftext.getDate();
                DETADC.DCUENTA = Operacion.mask('txtcuentabanco').val();
                DETADC.DCODANE = Operacion.mask('lblbancor').text();
                DETADC.DCENCOS = " ";
                DETADC.DCODMON = Operacion.mask('txtmoneda').val();
                DETADC.DDH = "H";
                DETADC.DTIPDOC = "CH";
                DETADC.DNUMDOC = Operacion.mask('txtcheque').val();
                DETADC.DFECDOC = ftext.getFullYear().toString().substr(2, 2) + (Number(ftext.getMonth() + 1) < 10 ? "0" + (ftext.getMonth() + 1) : (ftext.getMonth() + 1)) + ftext.getDate();
                DETADC.DFECVEN = ""
                DETADC.DAREA = Operacion.mask('ddlarea').val();
                DETADC.DFLAG = "N";
                DETADC.DDATE = f;
                DETADC.DXGLOSA = Operacion.mask('txtconcepto').val();
                DETADC.DIMPORT = Operacion.mask('txtmcheque').val();

                if (Operacion.mask('txtmoneda').val() == "MN") {
                    DETADC.DMNIMPOR = Operacion.mround(Number(Operacion.mask('txtmcheque').val()), 2);
                    DETADC.DUSIMPOR = Operacion.mround((Number(Operacion.mask('txtmcheque').val()) / Number(Operacion.mask('txttipocambio').val())), 2);
                }

                if (Operacion.mask('txtmoneda').val() == "US") {
                    DETADC.DMNIMPOR = Operacion.mround((Number(Operacion.mask('txtmcheque').val()) * Number(Operacion.mask('txttipocambio').val())), 2);
                    DETADC.DUSIMPOR = Operacion.mround(Number(Operacion.mask('txtmcheque').val()), 2);
                }

                DETADC.DCODARC = "2";
                DETADC.DFECCOM2 = (moment($("#MainContent_txtfecha").val(), "DD/MM/YYYY"));
                DETADC.DFECDO2 = (moment($("#MainContent_txtfecha").val(), "DD/MM/YYYY"));
                DETADC.DFECVEN2 = null;
                DETADC.DCODANE2 = "";
                DETADC.DVANEXO = "0";
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
                DETADC.DMEDPAG = Operacion.mask('ddlmediopago').val(); // SE TOMA DEL COMBO Y SOLO SE APLICA PARA EL REGISTRO DEL TOTAL                    
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
                $("[id*=GridView4]").append(rowt);
                rowt = $("[id*=GridView4] tr:last-child").clone(true);
              // fin totales

            }
            $('#MostrarDetalles').dialog({
                autoOpen: false,
                modal: true,
                resizable: true,
                width: 1000,
                heigth: 100,
                title: 'Mostrar Detalles',
                close: function (event, ui) {

                    var row = $("[id*=GridView4] tr:last-child").clone(true);
                    $("[id*=GridView4] tr").not($("[id*=GridView4] tr:first-child")).remove();

                    $("td", row).eq(0).html("");
                    $("td", row).eq(1).html("");
                    $("td", row).eq(2).html("");
                    $("td", row).eq(3).html("");
                    $("td", row).eq(4).html("");
                    $("td", row).eq(5).html("");

                    $("[id*=GridView4]").append(row);
                    Operacion.mask("lblhabersoles").text("");
                    Operacion.mask("lblhaberdolares").text("");
                    Operacion.mask("lbldebesoles").text("");
                    Operacion.mask("lbldebedolares").text("");
                },
            });

            // FIN VISTA

            function insertadetcomprobante(COMPROBANTE) {
                var GD = {};
                var pago = {};
                var f = new Date();
                var dia = "";
                var mes = "";
                var annio = "";
                var DETADC = {};
                var cont = 0;
                var annioven = "";
                var aannio = "";
                var i = 0;
                annio = Number(f.getFullYear()).toString();

                var ftext = moment($("#MainContent_txtfecha").val(), "DD/MM/YYYY");
                ftext = ftext == null ? null : new Date(ftext);

                var imput = document.getElementsByName('opt');
                var gridView = document.getElementById("<%=GridView2.ClientID%>");
                for (i = 1; i < gridView.rows.length; i++) {
                    if (Number(gridView.rows[i].cells[8].innerHTML) != 0) {
                        cont = cont + 1;
                        DETADC.DSUBDIA = Operacion.mask('ddlsubdiario').val();
                        DETADC.DCOMPRO = COMPROBANTE;

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

                        DETADC.DSECUE = Operacion.cadenaMascara(cont, 4);
                        DETADC.DFECCOM = ftext.getFullYear().toString().substr(2, 2) + (Number(ftext.getMonth() + 1) < 10 ? "0" + (ftext.getMonth() + 1) : (ftext.getMonth() + 1)) + ftext.getDate();
                        if (gridView.rows[i].cells[5].innerHTML == "MN") {
                            DETADC.DCUENTA = Operacion.mask('lblcuentapago').text();
                        }
                        else {
                            DETADC.DCUENTA = Operacion.mask('lblcuentapagodol').text();
                        }

                        DETADC.DCODANE = Operacion.mask('txtruc').val();
                        DETADC.DCENCOS = " ";
                        DETADC.DCODMON = Operacion.mask('txtmoneda').val();
                        DETADC.DDH = "D";
                        DETADC.DTIPDOC = gridView.rows[i].cells[1].innerHTML;
                        DETADC.DNUMDOC = gridView.rows[i].cells[2].innerHTML;

                        var ftext1 = moment(gridView.rows[i].cells[3].innerHTML, "DD/MM/YYYY");
                        ftext1 = ftext1 == null ? null : new Date(ftext1);
                        DETADC.DFECDOC = ftext1.getFullYear().toString().substr(2, 2) + (Number(ftext1.getMonth() + 1) < 10 ? "0" + (ftext1.getMonth() + 1) : (ftext1.getMonth() + 1)) + ftext1.getDate();

                        var ftext2 = moment(gridView.rows[i].cells[4].innerHTML, "DD/MM/YYYY");
                        ftext2 = ftext2 == null ? null : new Date(ftext2);
                        DETADC.DFECVEN = ftext2.getFullYear().toString().substr(2, 2) + (Number(ftext2.getMonth() + 1) < 10 ? "0" + (ftext2.getMonth() + 1) : (ftext2.getMonth() + 1)) + ftext2.getDate();
                        DETADC.DAREA = "";
                        DETADC.DFLAG = "N";
                        DETADC.DDATE = f;
                        DETADC.DXGLOSA = Operacion.mask('txtconcepto').val();
                        if (Operacion.mask('txtmoneda').val() == "MN" && gridView.rows[i].cells[5].innerHTML == "MN") {
                            DETADC.DMNIMPOR = Math.abs(Number(gridView.rows[i].cells[8].innerHTML)).toFixed(2);
                            DETADC.DUSIMPOR = Math.abs(Number(gridView.rows[i].cells[7].value)).toFixed(2);
                            DETADC.DIMPORT = Math.abs(Number(gridView.rows[i].cells[8].innerHTML)).toFixed(2);
                        }

                        if (Operacion.mask('txtmoneda').val() == "US" && gridView.rows[i].cells[5].innerHTML == "US") {
                            DETADC.DUSIMPOR = Math.abs(Number(gridView.rows[i].cells[8].innerHTML)).toFixed(2);
                            DETADC.DMNIMPOR = Math.abs(Number(gridView.rows[i].cells[8].innerHTML) * Number(gridView.rows[i].cells[5].value)).toFixed(2);
                            DETADC.DIMPORT = Math.abs(Number(gridView.rows[i].cells[8].innerHTML)).toFixed(2);
                        }

                        if (Operacion.mask('txtmoneda').val() == "US" && gridView.rows[i].cells[5].innerHTML == "MN") {
                            DETADC.DMNIMPOR = Math.abs(Number(gridView.rows[i].cells[8].innerHTML)).toFixed(2);
                            DETADC.DUSIMPOR = Math.abs(Number(gridView.rows[i].cells[7].value)).toFixed(2);
                            DETADC.DIMPORT = Math.abs(Number(gridView.rows[i].cells[7].value)).toFixed(2);
                        }
                        if (Operacion.mask('txtmoneda').val() == "MN" && gridView.rows[i].cells[5].innerHTML == "US") {
                            DETADC.DUSIMPOR = Math.abs(Number(gridView.rows[i].cells[8].innerHTML)).toFixed(2);
                            DETADC.DMNIMPOR = Math.abs(Number(gridView.rows[i].cells[8].innerHTML) * Number(gridView.rows[i].cells[5].value)).toFixed(2);
                            DETADC.DIMPORT = Math.abs(Number(gridView.rows[i].cells[8].innerHTML) * Number(gridView.rows[i].cells[5].value)).toFixed(2);
                        }

                        DETADC.DCODARC = "01";
                        DETADC.DFECCOM2 = (moment($("#MainContent_txtfecha").val(), "DD/MM/YYYY"));
                        DETADC.DFECDOC2 = (moment(gridView.rows[i].cells[3].innerHTML, "DD/MM/YYYY"));
                        DETADC.DFECVEN2 = (moment(gridView.rows[i].cells[4].innerHTML, "DD/MM/YYYY"));
                        DETADC.DCODANE2 = "";
                        DETADC.DVANEXO = Operacion.mask('lblanexo').text();
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
                        DETADC.DRETE = "";
                        DETADC.DPORRE = 0;
                        InsertarDetComprobante(DETADC, 1);

                        // EN CASO DE RETENCION
                        if ((gridView.rows[i].cells[9].innerHTML).trim() == "A") {
                            cont = cont + 1;
                            DETADC.DSUBDIA = Operacion.mask('ddlsubdiario').val();
                            DETADC.DCOMPRO = COMPROBANTE;
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

                            DETADC.DSECUE = Operacion.cadenaMascara(cont, 4);
                            DETADC.DFECCOM = ftext.getFullYear().toString().substr(2, 2) + (Number(ftext.getMonth() + 1) < 10 ? "0" + (ftext.getMonth() + 1) : (ftext.getMonth() + 1)) + ftext.getDate();
                            DETADC.DCUENTA = Operacion.mask('lblcuentaretencion').text();
                            DETADC.DCODANE = Operacion.mask('txtruc').val();
                            DETADC.DCENCOS = " ";
                            DETADC.DCODMON = Operacion.mask('txtmoneda').val();
                            DETADC.DDH = "H";
                            DETADC.DTIPDOC = gridView.rows[i].cells[1].innerHTML;
                            DETADC.DNUMDOC = gridView.rows[i].cells[2].innerHTML;
                            DETADC.DFECDOC = ftext1.getFullYear().toString().substr(2, 2) + (Number(ftext1.getMonth() + 1) < 10 ? "0" + (ftext1.getMonth() + 1) : (ftext1.getMonth() + 1)) + ftext1.getDate();
                            DETADC.DFECVEN = ftext2.getFullYear().toString().substr(2, 2) + (Number(ftext2.getMonth() + 1) < 10 ? "0" + (ftext2.getMonth() + 1) : (ftext2.getMonth() + 1)) + ftext2.getDate();
                            DETADC.DAREA = "";
                            DETADC.DFLAG = "N";
                            DETADC.DDATE = f;
                            DETADC.DXGLOSA = "";
                            if (Operacion.mask('txtmoneda').val() == "MN" && gridView.rows[i].cells[5].innerHTML == "MN") {
                                DETADC.DMNIMPOR = Math.abs((Number(gridView.rows[i].cells[8].innerHTML) * (Number(gridView.rows[i].cells[10].innerHTML) / 100))).toFixed(2);
                                DETADC.DIMPORT = Math.abs((Number(gridView.rows[i].cells[8].innerHTML) * (Number(gridView.rows[i].cells[10].innerHTML) / 100))).toFixed(2);
                                DETADC.DUSIMPOR = Math.abs((Number(gridView.rows[i].cells[8].innerHTML) * (Number(gridView.rows[i].cells[10].innerHTML) / 100)) / Number(Operacion.mask('txttipocambio').val())).toFixed(2);
                            }

                            if (Operacion.mask('txtmoneda').val() == "US" && gridView.rows[i].cells[5].innerHTML == "US") {
                                DETADC.DMNIMPOR = Math.abs(((Number(gridView.rows[i].cells[8].innerHTML) * (Number(gridView.rows[i].cells[10].innerHTML) / 100)) * Operacion.mask('txttipocambio').val())).toFixed(2);
                                DETADC.DUSIMPOR = Math.abs((Number(gridView.rows[i].cells[8].innerHTML) * (Number(gridView.rows[i].cells[10].innerHTML) / 100))).toFixed(2);
                                DETADC.DIMPORT = Math.abs((Number(gridView.rows[i].cells[8].innerHTML) * (Number(gridView.rows[i].cells[10].innerHTML) / 100))).toFixed(2);
                            }

                            if (Operacion.mask('txtmoneda').val() == "US" && gridView.rows[i].cells[5].innerHTML == "MN") {
                                DETADC.DMNIMPOR = Math.abs(((Number(gridView.rows[i].cells[8].innerHTML) * (Number(gridView.rows[i].cells[10].innerHTML) / 100)))).toFixed(2);
                                DETADC.DUSIMPOR = Math.abs(((Number(gridView.rows[i].cells[8].innerHTML) * (Number(gridView.rows[i].cells[10].innerHTML) / 100)) / Operacion.mask('txttipocambio').val())).toFixed(2);
                                DETADC.DIMPORT = Math.abs(((Number(gridView.rows[i].cells[8].innerHTML) * (Number(gridView.rows[i].cells[10].innerHTML) / 100)) / Operacion.mask('txttipocambio').val())).toFixed(2);
                            }

                            if (Operacion.mask('txtmoneda').val() == "MN" && gridView.rows[i].cells[5].innerHTML == "US") {
                                DETADC.DMNIMPOR = Math.abs(((Number(gridView.rows[i].cells[8].innerHTML) * (Number(gridView.rows[i].cells[10].innerHTML) / 100)) * Operacion.mask('txttipocambio').val())).toFixed(2);
                                DETADC.DUSIMPOR = Math.abs(((Number(gridView.rows[i].cells[8].innerHTML) * (Number(gridView.rows[i].cells[10].innerHTML) / 100)))).toFixed(2);
                                DETADC.DIMPORT = Math.abs(((Number(gridView.rows[i].cells[8].innerHTML) * (Number(gridView.rows[i].cells[10].innerHTML) / 100)) * Operacion.mask('txttipocambio').val())).toFixed(2);

                            }
                            DETADC.DCODARC = "";
                            DETADC.DFECCOM2 = (moment($("#MainContent_txtfecha").val(), "DD/MM/YYYY"));
                            DETADC.DFECDOC2 = (moment(gridView.rows[i].cells[3].innerHTML, "DD/MM/YYYY"));
                            DETADC.DFECVEN2 = (moment(gridView.rows[i].cells[4].innerHTML, "DD/MM/YYYY"));
                            DETADC.DCODANE2 = "";
                            DETADC.DVANEXO = Operacion.mask('lblanexo').text();
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
                            DETADC.DRETE = "";
                            DETADC.DPORRE = 0;
                            InsertarDetComprobante(DETADC, 1);

                        } // fin retencion

                    }// if del checked

                } // fin for
                //inicio totales
                cont = cont + 1;
                DETADC.DSUBDIA = Operacion.mask('ddlsubdiario').val();
                DETADC.DCOMPRO = COMPROBANTE;
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
                DETADC.DSECUE = Operacion.cadenaMascara(cont, 4);
                DETADC.DFECCOM = ftext.getFullYear().toString().substr(2, 2) + (Number(ftext.getMonth() + 1) < 10 ? "0" + (ftext.getMonth() + 1) : (ftext.getMonth() + 1)) + ftext.getDate();
                DETADC.DCUENTA = Operacion.mask('txtcuentabanco').val();
                DETADC.DCODANE = Operacion.mask('txtbancor').val();
                DETADC.DCENCOS = " ";
                DETADC.DCODMON = Operacion.mask('txtmoneda').val();
                DETADC.DDH = "H";
                DETADC.DTIPDOC = "CH";
                DETADC.DNUMDOC = Operacion.mask('txtcheque').val();
                DETADC.DFECDOC = ftext.getFullYear().toString().substr(2, 2) + (Number(ftext.getMonth() + 1) < 10 ? "0" + (ftext.getMonth() + 1) : (ftext.getMonth() + 1)) + ftext.getDate();
                DETADC.DFECVEN = ""
                DETADC.DAREA = Operacion.mask('ddlarea').val();
                DETADC.DFLAG = "N";
                DETADC.DDATE = f;
                DETADC.DXGLOSA = Operacion.mask('txtconcepto').val();
                DETADC.DIMPORT = Operacion.mask('txtmcheque').val();

                if (Operacion.mask('txtmoneda').val() == "MN") {
                    DETADC.DMNIMPOR = Operacion.mround(Number(Operacion.mask('txtmcheque').val()), 2);
                    DETADC.DUSIMPOR = Operacion.mround((Number(Operacion.mask('txtmcheque').val()) / Number(Operacion.mask('txttipocambio').val())), 2);
                }

                if (Operacion.mask('txtmoneda').val() == "US") {
                    DETADC.DMNIMPOR = Operacion.mround((Number(Operacion.mask('txtmcheque').val()) * Number(Operacion.mask('txttipocambio').val())), 2);
                    DETADC.DUSIMPOR = Operacion.mround(Number(Operacion.mask('txtmcheque').val()), 2);
                }
                DETADC.DCODARC = "02";
                DETADC.DFECCOM2 = (moment($("#MainContent_txtfecha").val(), "DD/MM/YYYY"));
                DETADC.DFECDOC2 = (moment($("#MainContent_txtfecha").val(), "DD/MM/YYYY"));
                DETADC.DFECVEN2 = (Operacion.mask('ddlcartera').val()=="2"?moment($("#MainContent_txtfechadiferido").val(), "DD/MM/YYYY"):null);
                DETADC.DCODANE2 = "";
                DETADC.DVANEXO = "0";
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
                DETADC.DMEDPAG = Operacion.mask('ddlmediopago').val(); // SE TOMA DEL COMBO Y SOLO SE APLICA PARA EL REGISTRO DEL TOTAL                    
                DETADC.DTIPDO2 = "";
                DETADC.DNUMDO2 = "";
                DETADC.DRETE = "";
                DETADC.DPORRE = 0;
                InsertarDetComprobante(DETADC, 1);
                // fin  totales

                // inicio ajustes dolares
                if ((Number(Operacion.mask('lbldebedolares').text()) > Number(Operacion.mask('lblhaberdolares').text())) || Number(Operacion.mask('lbldebedolares').text()) < Number(Operacion.mask('lblhaberdolares').text())) {
                    cont = cont + 1;
                    DETADC.DSUBDIA = Operacion.mask('ddlsubdiario').val();
                    DETADC.DCOMPRO = COMPROBANTE;
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
                    DETADC.DSECUE = Operacion.cadenaMascara(cont, 4);
                    DETADC.DFECCOM = ftext.getFullYear().toString().substr(2, 2) + (Number(ftext.getMonth() + 1) < 10 ? "0" + (ftext.getMonth() + 1) : (ftext.getMonth() + 1)) + ftext.getDate();
                    DETADC.DCUENTA = (Number(Operacion.mask('lbldebedolares').text()) > Number(Operacion.mask('lblhaberdolares').text()) ? M_ARRAY[2].toString().substr(0, 6) : M_ARRAY[1].toString().substr(0, 6));
                    DETADC.DCODANE = "";
                    DETADC.DCENCOS = " ";
                    DETADC.DCODMON = Operacion.mask('txtmoneda').val();
                    DETADC.DDH = (Number(Operacion.mask('lbldebedolares').text()) > Number(Operacion.mask('lblhaberdolares').text()) ? "H" : "D");
                    DETADC.DTIPDOC = "";
                    DETADC.DIMPORT = (Operacion.mask('txtmoneda').val() == "US" ? Operacion.mround(Math.abs(Number(Operacion.mask('lbldebedolares').text()) - Number(Operacion.mask('lblhaberdolares').text())), 2) : 0);
                    DETADC.DNUMDOC = "";
                    DETADC.DFECDOC = "";
                    DETADC.DFECVEN = "";
                    DETADC.DAREA = "";
                    DETADC.DFLAG = "N";
                    DETADC.DDATE = f;
                    DETADC.DXGLOSA = "";
                    DETADC.DMNIMPOR = 0;
                    DETADC.DUSIMPOR = Operacion.mround(Math.abs(Number(Operacion.mask('lbldebedolares').text()) - Number(Operacion.mask('lblhaberdolares').text())), 2);
                    DETADC.DCODARC = "";
                    DETADC.DFECCOM2 = (moment($("#MainContent_txtfecha").val(), "DD/MM/YYYY"));
                    DETADC.DFECDOC2 = null;
                    DETADC.DFECVEN2 = null;
                    DETADC.DCODANE2 = "";
                    DETADC.DVANEXO = "";
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
                    DETADC.DMEDPAG = "";
                    DETADC.DTIPDO2 = "";
                    DETADC.DNUMDO2 = "";
                    DETADC.DRETE = "";
                    DETADC.DPORRE = 0;
                    InsertarDetComprobante(DETADC, 1);
                }
                // fin ajustres dolares

                // inicio ajustes soles

                if ((Number(Operacion.mask('lbldebesoles').text()) > Number(Operacion.mask('lblhabersoles').text())) || Number(Operacion.mask('lbldebesoles').text()) < Number(Operacion.mask('lblhabersoles').text())) {
                    cont = cont + 1;
                    DETADC.DSUBDIA = Operacion.mask('ddlsubdiario').val();
                    DETADC.DCOMPRO = COMPROBANTE;
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
                    DETADC.DSECUE = Operacion.cadenaMascara(cont, 4);
                    DETADC.DFECCOM = ftext.getFullYear().toString().substr(2, 2) + (Number(ftext.getMonth() + 1) < 10 ? "0" + (ftext.getMonth() + 1) : (ftext.getMonth() + 1)) + ftext.getDate();
                    DETADC.DCUENTA = (Number(Operacion.mask('lbldebesoles').text()) > Number(Operacion.mask('lblhabersoles').text()) ? M_ARRAY[2].toString().substr(0, 6) : M_ARRAY[1].toString().substr(0, 6));
                    DETADC.DCODANE = "";
                    DETADC.DCENCOS = " ";
                    DETADC.DCODMON = Operacion.mask('txtmoneda').val();
                    DETADC.DDH = (Number(Operacion.mask('lbldebesoles').text()) > Number(Operacion.mask('lblhabersoles').text()) ? "H" : "D");
                    DETADC.DTIPDOC = "";
                    DETADC.DIMPORT = (Operacion.mask('txtmoneda').val() == "MN" ? Operacion.mround(Math.abs(Number(Operacion.mask('lbldebesoles').text()) - Number(Operacion.mask('lblhabersoles').text())), 2) : 0);
                    DETADC.DNUMDOC = "";
                    DETADC.DFECDOC = "";
                    DETADC.DFECVEN = "";
                    DETADC.DAREA = "";
                    DETADC.DFLAG = "N";
                    DETADC.DDATE = f;
                    DETADC.DXGLOSA = "";
                    DETADC.DMNIMPOR = Operacion.mround(Math.abs(Number(Operacion.mask('lbldebesoles').text()) - Number(Operacion.mask('lblhabersoles').text())), 2);
                    DETADC.DUSIMPOR = 0;
                    DETADC.DCODARC = "";
                    DETADC.DFECCOM2 = (moment($("#MainContent_txtfecha").val(), "DD/MM/YYYY"));
                    DETADC.DFECDOC2 = null;
                    DETADC.DFECVEN2 = null;
                    DETADC.DCODANE2 = "";
                    DETADC.DVANEXO = "";
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
                    DETADC.DMEDPAG = "";
                    DETADC.DTIPDO2 = "";
                    DETADC.DNUMDO2 = "";
                    DETADC.DRETE = "";
                    DETADC.DPORRE = 0;
                    InsertarDetComprobante(DETADC, 1);
                }
                // fin ajustres soles 

                // inicio de datos adicionales

                var adicionales = document.getElementById("<%=GridView3.ClientID %>");
                var MI_LEN = adicionales.rows.length;
                for (var t = 1; t < MI_LEN; t++) {
                    if (Number(adicionales.rows[t].cells[5].innerHTML.trim()) > 0) {
                        cont = cont + 1;
                        // alert("-"+adicionales.rows[t].cells[5].innerHTML.trim()+"-");
                        DETADC.DSUBDIA = Operacion.mask('ddlsubdiario').val();
                        DETADC.DCOMPRO = COMPROBANTE;

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

                        DETADC.DSECUE = Operacion.cadenaMascara(cont, 4);
                        DETADC.DFECCOM = ftext.getFullYear().toString().substr(2, 2) + (Number(ftext.getMonth() + 1) < 10 ? "0" + (ftext.getMonth() + 1) : (ftext.getMonth() + 1)) + ftext.getDate();
                        DETADC.DCUENTA = adicionales.rows[t].cells[1].innerHTML;
                        DETADC.DCODANE = "";
                        DETADC.DCENCOS = " ";
                        DETADC.DCODMON = Operacion.mask('txtmoneda').val();
                        DETADC.DDH = adicionales.rows[t].cells[4].innerHTML;
                        DETADC.DTIPDOC = "";
                        DETADC.DNUMDOC = "";
                        DETADC.DFECDOC = "";
                        DETADC.DFECVEN = "";
                        DETADC.DAREA = "";
                        DETADC.DFLAG = "N";
                        DETADC.DDATE = f;
                        DETADC.DXGLOSA = "";
                        if (Operacion.mask('txtmoneda').val() == "MN") {
                            DETADC.DMNIMPOR = (Number(adicionales.rows[t].cells[5].innerHTML)).toFixed(2);
                            DETADC.DUSIMPOR = (Number(adicionales.rows[t].cells[5].innerHTML) / Number(Operacion.mask('txttipocambio').val())).toFixed(2);
                            DETADC.DIMPORT = (Number(adicionales.rows[t].cells[5].innerHTML)).toFixed(2);
                        }
                        if (Operacion.mask('txtmoneda').val() == "US") {
                            DETADC.DMNIMPOR = (Number(adicionales.rows[t].cells[5].innerHTML) * Number(Operacion.mask('txttipocambio').val())).toFixed(2);
                            DETADC.DUSIMPOR = (Number(adicionales.rows[t].cells[5].innerHTML)).toFixed(2);
                            DETADC.DIMPORT = (Number(adicionales.rows[t].cells[5].innerHTML)).toFixed(2);
                        }
                        DETADC.DCODARC = "";
                        DETADC.DFECCOM2 = (moment($("#MainContent_txtfecha").val(), "DD/MM/YYYY"));
                        DETADC.DFECDOC2 = null;
                        DETADC.DFECVEN2 = null;
                        DETADC.DCODANE2 = "";
                        DETADC.DVANEXO = "";
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
                        DETADC.DRETE = "";
                        DETADC.DPORRE = 0;
                        InsertarDetComprobante(DETADC, 1);

                    } // fin if

                }
                //fin de movimientos adicionales
                InsertarDetComprobante(DETADC, 0);

            }
            function InsertarDetComprobante(DETADC, indicador) {
                if (indicador == 1) {
                    $.ajax({
                        type: "POST",
                        url: "EmisionCheques.aspx/InsertDetComprobante",
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
                else {
                    ExtraeparaBalh(DETADC.DCOMPRO);
                    InsertaBalh(DETADC.DCOMPRO);
                }
            }

            function InsertaBalh(comprobanteb) {
                var conta = 0;
                var fecha = new Date();
                var gridView5 = document.getElementById("<%=GridView5.ClientID %>");
               var BDATA = {};
               for (var t = 1; t < gridView5.rows.length; t++) {
                   // if ((gridView5.rows[t].cells[6].innerHTML == "FT") || (gridView5.rows[t].cells[6].innerHTML.trim() == "")) {
                   BDATA.BCUENTA = (gridView5.rows[t].cells[0].innerHTML).trim();
                   BDATA.BMNSALA = 0;
                   BDATA.BMNDEBE = (gridView5.rows[t].cells[2].innerHTML == "" ? 0 : Operacion.mround(Number(gridView5.rows[t].cells[2].innerHTML), 2));
                   BDATA.BMNHABER = (gridView5.rows[t].cells[3].innerHTML == "" ? 0 : Operacion.mround(Number(gridView5.rows[t].cells[3].innerHTML), 2));
                   BDATA.BMNSALN = 0;
                   BDATA.BUSSALA = 0;
                   BDATA.BUSDEBE = (gridView5.rows[t].cells[4].innerHTML == "" ? 0 : Operacion.mround(Number(gridView5.rows[t].cells[4].innerHTML), 2));
                   BDATA.BUSHABER = (gridView5.rows[t].cells[5].innerHTML == "" ? 0 : Operacion.mround(Number(gridView5.rows[t].cells[5].innerHTML), 2));
                   BDATA.BUSSALN = 0;
                   BDATA.BMNSALI = 0;
                   BDATA.BUSSALI = 0;
                   BDATA.BFECPRO = "";
                   BDATA.BFORBAL = "1";//CONTROL PARA INCREMENTAR 
                   BDATA.BFORGYP = "";
                   BDATA.BFORRE1 = "";
                   BDATA.BCTAAJU = "";
                   BDATA.BFECPRO2 = (fecha.getFullYear().toString() + "" + (Number(fecha.getMonth() + 1) < 10 ? "0" + (fecha.getMonth() + 1) : (fecha.getMonth() + 1))).trim();
                   $.ajax({
                       type: "POST",
                       url: "EmisionCheques.aspx/ActualizarBalh",
                       data: '{DETA: ' + JSON.stringify(BDATA) + '}',
                       contentType: "application/json; charset=utf-8",
                       dataType: "json",
                       async: false,
                       success: function (response) {
                           conta = 1;
                       },
                       error: function (response) {
                           if (response.length != 0)
                               alert(response);
                           console.log(BDATA);
                           conta = 0;

                       }
                   });

                   // }
               }
               if (conta == 1) {
                   ActualizarChequera(comprobanteb);
               }
           }

            function ExtraeparaBalh(COMPROBANTE) {
                var CODATA = {};
                CODATA.DCOMPRO = COMPROBANTE;
                CODATA.DSUBDIA = Operacion.mask('ddlsubdiario').val();
                $.ajax({
                    type: "POST",
                    url: "EmisionCheques.aspx/LISTARPARABALH",
                    data: '{CODATA: ' + JSON.stringify(CODATA) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        if (data.d.length > 0) {
                            var row = $("[id*=GridView5] tr:last-child").clone(true);
                            $("[id*=GridView5] tr").not($("[id*=GridView5] tr:first-child")).remove();

                            for (var i = 0; i < data.d.length; i++) {
                                $("td", row).eq(0).html(data.d[i].CUENTA);
                                $("td", row).eq(1).html(data.d[i].FECHA);
                                $("td", row).eq(2).html(Operacion.mround(Number(data.d[i].SUMASOLESDEBE), 2));
                                $("td", row).eq(3).html(Operacion.mround(Number(data.d[i].SUMASOLESHABER), 2));
                                $("td", row).eq(4).html(Operacion.mround(Number(data.d[i].SUMADOLARESDEBE), 2));
                                $("td", row).eq(5).html(Operacion.mround(Number(data.d[i].SUMADOLARESHABER), 2));
                                $("td", row).eq(6).html(data.d[i].TIPODOPC);
                                $("[id*=GridView5]").append(row);
                                row = $("[id*=GridView5] tr:last-child").clone(true);
                            }

                        } else {

                            var row = $("[id*=GridView5] tr:last-child").clone(true);
                            $("[id*=GridView5] tr").not($("[id*=GridView5] tr:first-child")).remove();

                            $("td", row).eq(1).html("");
                            $("td", row).eq(2).html("");
                            $("td", row).eq(3).html("");
                            $("td", row).eq(4).html("");
                            $("td", row).eq(5).html("");
                            $("td", row).eq(6).html("");
                            $("[id*=GridView5]").append(row);
                            alert("no se encontro registro");
                        }
                    },
                    error: function (response) {
                        if (response.length != 0)
                            console.log(response);
                    }
                });

            }
            Operacion.mask('txtcriterio').keypress(function () {
                var s = $(this).val().toUpperCase().split(" ");
                $(".buscar tr:hidden").show();
                $.each(s, function () {
                    $(".buscar tr:visible .pro:not(:contains('" + this + "'))").parent().hide();
                });
            });

            Operacion.mask('txtbuscardoc').keypress(function () {
                var s = $(this).val().toUpperCase().split(" ");
                $(".buscardoc tr:hidden").show();
                $.each(s, function () {
                    $(".buscardoc tr:visible .pro:not(:contains('" + this + "'))").parent().hide();
                });
            });


            <%-- $(".buscardoc").click(function () {

                 var gridView = document.getElementById("<%=GridView2.ClientID %>");
                 for (var t = 1; t < gridView.rows.length; t++) {
                    
                     gridView.rows[t].style.backgroundColor = "#FFFFFF";

                 }

                 for (var t = 1; t < gridView.rows.length; t++) {
                     if (gridView.rows[t].cells[2].textContent.trim().indexOf($("#MainContent_txtbuscardoc").val().trim()) >-1)
                        {
                         gridView.rows[t].style.backgroundColor = "#CCFF00";
                        
                                                 
                        }             
              
                     }

                });--%>

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

        .auto-style1 {
            height: 19px;
        }

        .auto-style3 {
            width: 56px;
        }

        #btnadicionales {
            width: 115px;
        }

        #btnfinalizar {
            width: 31px;
        }

        .seleciona {
        }
    </style>
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="contenedor">
        <div id="Creacion" title="Creación">
            <table>
                <tr>
                    <td>Criterio:</td>
                    <td>
                        <asp:TextBox ID="txtcriterio" runat="server" Width="355px"></asp:TextBox></td>
                    <td>
                        <asp:Label ID="lblcuentapago" runat="server" Text="" Style="display: none"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblcuentapagodol" runat="server" Text="" Style="display: none"></asp:Label>
                    </td>

                    <td>
                        <asp:Label ID="lblcuentaretencion" runat="server" Text="" Style="display: none"></asp:Label>
                    </td>
                </tr>
            </table>

            <table>
                <tr>
                    <td>
                        <div style="overflow: auto; width: 850px; height: 550px">
                            <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" OnRowCreated="griddata_RowCreated" Font-Size="Smaller" Width="830px" class="buscar">
                                <Columns>
                                    <asp:BoundField DataField="Ane" HeaderText="ANE" />
                                    <asp:BoundField DataField="Codigo" HeaderText="CODIGO">
                                        <ItemStyle CssClass="pro"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Acreedor" HeaderText="NOMBRE">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Tipo" HeaderText="TIPO" />
                                    <asp:BoundField DataField="Direccion" HeaderText="DIRECCION" />


                                    <asp:TemplateField HeaderText="MODIFICAR">


                                        <ItemTemplate>
                                            <div class="Nuevo" style="text-align: center">
                                                <img alt="" src="../../../Images/historial.png" width="25" style="cursor: pointer" />
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
    <div id="Nuevo">
        <table>
            <tr>
                <td>Acreedor&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td>
                    <asp:Label ID="lblanexo" runat="server" Text=""></asp:Label>
                    <asp:TextBox ID="txtruc" runat="server" ReadOnly="true"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtacreedor" runat="server" ReadOnly="true" Width="436px"></asp:TextBox></td>
            </tr>

            <tr>
                <td>Chequera</td>
                <td>
                    <asp:DropDownList ID="ddlcartera" runat="server" Height="21px" Width="176px" CssClass="seleciona">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>


            <tr>
                <td>Banco&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td>
                    <asp:TextBox ID="txtbancor" runat="server" Width="175px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="lblbancor" runat="server" Width="434px"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td>Moneda
                </td>
                <td>
                    <asp:TextBox ID="txtmoneda" runat="server" Width="175px" ReadOnly="true"></asp:TextBox>
                    <asp:Label ID="lblusuario" runat="server" BorderStyle="None" Style="display: none"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtcuentabanco" runat="server" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
        </table>

        <table>
            <tr>
                <td class="auto-style3">Fecha</td>
                <td>
                    <asp:TextBox ID="txtfecha" runat="server" Width="120px" class="fecha"></asp:TextBox>
                </td>
                <td>Tipo de Cambio</td>
                <td>
                    <asp:TextBox ID="txttipocambio" runat="server" Width="136px" ReadOnly="true"></asp:TextBox>
                    <input id="rbcompra" name="opcion" type="radio" value="1" runat="server" class="tipocambio" />
                    Comp.
                         <input id="rbventa" name="opcion" type="radio" value="2" runat="server" class="tipocambio" />
                    Vent.
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>Area</td>
                <td>
                    <asp:DropDownList ID="ddlarea" runat="server" Height="16px" Width="350px"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Tipo Pago</td>
                <td>
                    <asp:DropDownList ID="ddlmediopago" runat="server" Height="16px" Width="350px"></asp:DropDownList></td>
                <td class="auto-style1">Subdiario</td>
                <td class="auto-style1">
                    <asp:DropDownList ID="ddlsubdiario" runat="server" Height="19px" Width="220px"></asp:DropDownList>
                </td>
            </tr>

        </table>
        <table>

            <tr>
                <td>
                    <asp:Label ID="TextBox1" runat="server" Width="434px" Text="SELECCION DE DOCUMENTOS" ForeColor="Black" Height="21px" Font-Size="Medium"></asp:Label>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:TextBox ID="txtbuscardoc" runat="server" ForeColor="Black"></asp:TextBox>
                    <input id="btnbuscar" type="button" value="Buscar" class="buscardoc" />
                </td>

            </tr>
            <tr>
                <td>
                    <asp:CheckBox runat="server" Text="Todos/Ninguno" class="valida" ID="chklistar" />
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <div style="overflow: auto; width: 850px; height: 100px">
                        <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" OnRowCreated="griddata_RowCreated" Width="782px" Font-Size="Smaller" class="buscardoc">
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
                                <asp:BoundField DataField="CP_CNUMDOC" HeaderText="NUM.DOC.">
                                    <ItemStyle CssClass="pro"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="CP_DFECDOC" HeaderText="FEC. DOC." />
                                <asp:BoundField DataField="CP_DFECVEN" HeaderText="FEC. VEN." DataFormatString="{0:F2}">
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CP_CCODMON" HeaderText="MONEDA" DataFormatString="{0:F2}">
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="IMPORTE"></asp:BoundField>
                                <asp:BoundField HeaderText="SALDO" DataFormatString="{0:F2}">

                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>

                                <asp:BoundField HeaderText="SELECCION">
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="EST. RET." DataField="CP_CRETE">
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="% RET.">

                                    <ItemStyle HorizontalAlign="Right" />
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
        <table>
            <tr>
                <td>Nº Dctos </td>
                <td>
                    <asp:TextBox ID="txtdctos" runat="server" Width="136px" ReadOnly="true"></asp:TextBox></td>
                <td>Pago MN </td>
                <td>
                    <asp:TextBox ID="txtmontomn" runat="server" Width="136px" ReadOnly="true"></asp:TextBox>
                </td>
                <td>Pago US </td>
                <td>
                    <asp:TextBox ID="txtmontous" runat="server" Width="136px" ReadOnly="true"></asp:TextBox></td>
            </tr>

        </table>
        <table>
            <tr>
                <td>Documentos </td>
                <td>
                    <asp:TextBox ID="txtmdoc" runat="server" Width="136px" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Monto Retención </td>
                <td>
                    <asp:TextBox ID="txtmretencion" runat="server" Width="136px" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Mov. Adicional</td>
                <td>
                    <asp:TextBox ID="txtmadicional" runat="server" Width="136px" ReadOnly="true"></asp:TextBox>
                    <asp:TextBox ID="txtporretencion" runat="server" Width="59px" ReadOnly="true" Style="display: none"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td>Monto de Cheque </td>
                <td>
                    <asp:TextBox ID="txtmcheque" runat="server" Width="136px" ReadOnly="true"></asp:TextBox></td>
            </tr>
        </table>
        <table>
            <tr>
                <td>

                    <input id="btnadicionales" type="button" value="Mov. Adicionales" class="adicionales" /></td>

            </tr>

            <tr>
                <td>
                    <asp:Label ID="TextBox2" runat="server" Width="183px" Text="GIRO DE CHEQUES" Font-Size="Medium"></asp:Label>
                </td>
            </tr>
        </table>

        <table>

            <tr>
                <td>Nombre a Girar</td>
                <td>
                    <asp:TextBox ID="txtnombregirar" runat="server" Width="271px" ReadOnly="false"></asp:TextBox>
                </td>
                <td>Concepto</td>
                <td>
                    <asp:TextBox ID="txtconcepto" runat="server" Width="340px"></asp:TextBox></td>
            </tr>

            <tr>
                <td>Nro. Cheque</td>
                <td>
                    <asp:TextBox ID="txtcheque" runat="server" Width="136px"></asp:TextBox></td>
                <td>Fecha Diferido</td>
                <td>
                    <asp:TextBox ID="txtfechadiferido" runat="server" Width="136px"></asp:TextBox>

                    <asp:CheckBox ID="negociable" runat="server" Text="No Negociable" />

                </td>
            </tr>
            <tr>
                <td>Firmante1</td>
                <td>
                    <asp:CheckBox ID="firma1" runat="server" Class="firmas" Tag="fir" />
                    <asp:Label ID="lblfirma1" runat="server" Text="Label"></asp:Label></td>
                <td>Firmante2</td>
                <td>
                    <asp:CheckBox ID="firma2" runat="server" Class="firmas" Tag="fir" />
                    <asp:Label ID="lblfirma2" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td>Firmante3</td>
                <td>
                    <asp:CheckBox ID="firma3" runat="server" Class="firmas" Tag="fir" />
                    <asp:Label ID="lblfirma3" runat="server" Text="Label"></asp:Label></td>
                <td>Firmante4</td>
                <td>
                    <asp:CheckBox ID="firma4" runat="server" Class="firmas" Tag="fir" />
                    <asp:Label ID="lblfirma4" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <input id="btnconfirmnar" type="button" value="Confirmar" class="CONFIRMAR" />
                </td>
                <td>
                    <input id="btnconfirmnar1" type="button" value="Verificar" class="CONFIRMAR1" />&nbsp;
                </td>
            </tr>

            <tr>
                <td>
                    <asp:GridView ID="GridView5" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" AutoGenerateColumns="False" OnRowCreated="griddata_RowCreated" Font-Size="Smaller" Width="510px" Style="display: none">
                        <Columns>
                            <asp:BoundField DataField="CUENTA" HeaderText="CUENTA" />
                            <asp:BoundField DataField="FECHA" HeaderText="FECHA" />
                            <asp:BoundField DataField="SUMASOLESDEBE" HeaderText="DEBE_SOLES" />
                            <asp:BoundField DataField="SUMASOLESHABER" HeaderText="HABER_SOLES" />
                            <asp:BoundField DataField="SUMADOLARESDEBE" HeaderText="DEBE_DOLARES" />
                            <asp:BoundField DataField="SUMADOLARESHABER" HeaderText="HABER_DOLARES"></asp:BoundField>
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
    <div id="adicionales">
        <table>
            <tr>
                <td>-------------MOVIMIENTOS ADICIONALES------------------</td>
            </tr>

        </table>
        <table>
            <tr>
                <td>DEBE</td>
                <td>
                    <asp:TextBox ID="txtdebe" runat="server" ReadOnly="true"></asp:TextBox>
                </td>
                <td>HABER</td>
                <td>
                    <asp:TextBox ID="txthaber" runat="server" ReadOnly="true"></asp:TextBox>
                </td>
                <td>DIFERENCIA</td>
                <td>
                    <asp:TextBox ID="txtdiferencia" runat="server" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <div style="overflow: auto; width: 850px; height: 100px">
                        <asp:GridView ID="GridView3" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" OnRowCreated="griddata_RowCreated" Width="782px" Font-Size="Smaller">
                            <Columns>
                                <asp:BoundField DataField="SEC" HeaderText="SEC" />
                                <asp:BoundField DataField="CUENTA" HeaderText="CUENTA" />
                                <asp:BoundField DataField="ANEXO" HeaderText="ANEXO" />
                                <asp:BoundField DataField="COS" HeaderText="COS">
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="F" HeaderText="F"></asp:BoundField>
                                <asp:BoundField DataField="IMPORTE" HeaderText="IMPORTE">
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="TP" DataField="TP"></asp:BoundField>
                                <asp:BoundField HeaderText="DOCMTO" DataField="DOCMTO"></asp:BoundField>

                                <asp:BoundField HeaderText="FEC DOC" DataField="FEC DOC" DataFormatString="{0:F2}">
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="FEC VEN" DataField="FEC VEN" DataFormatString="{0:F2}">
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="AREA" DataField="AREA">

                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>

                                <asp:TemplateField HeaderText="EDITAR">
                                    <ItemTemplate>
                                        <div class="bteditar" style="text-align: center">
                                            <img alt="" src="../../../Images/edit.png" width="25" style="cursor: pointer" />

                                            <%--<asp:ImageButton ID="imbeliminar" runat="server" ImageUrl="~/Images/Message_Error.png" Width="25px" OnClick="ib_eliminar_Click" onclientclick="javascript:return confirm('Esta Seguro?')"/>--%>
                                        </div>
                                    </ItemTemplate>

                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="ELIMINAR">
                                    <ItemTemplate>
                                        <div class="btelimina" style="text-align: center">
                                            <img alt="" src="../../../Images/Trash.png" width="25" style="cursor: pointer" />

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
        <table>
            <tr>
                <td>Sec.</td>
                <td>
                    <asp:TextBox ID="txtaux" runat="server" Width="64px" ReadOnly="true"></asp:TextBox>
                </td>
                <td>Cuenta </td>
                <td>
                    <asp:TextBox ID="txtcuenta" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>DEBE-HABER </td>
                <td>
                    <asp:DropDownList ID="ddldebehaber" runat="server" Height="16px" Width="53px" Class="debehaber">
                        <asp:ListItem>D</asp:ListItem>
                        <asp:ListItem>H</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>Importe</td>
                <td>
                    <asp:TextBox ID="txtimporte" runat="server"></asp:TextBox>
                </td>
                <td>GLOSA</td>
                <td>
                    <asp:TextBox ID="TXTGLOSA" runat="server"></asp:TextBox>
                </td>
                <td>
                    <input id="btnagregar" type="button" value="Agregar" class="agregar" />
                </td>
                <td>
                    <input id="btnfinalizar" type="button" value="F" class="PASARGRILLA" />
                </td>

            </tr>
        </table>
    </div>
    <div id="MostrarDetalles">
        <table>
            <tr>
                <td>
                    <asp:GridView ID="GridView4" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" OnRowCreated="griddata_RowCreated" Font-Size="Smaller" Width="510px">
                        <Columns>
                            <asp:BoundField HeaderText="CUENTA" />
                            <asp:BoundField HeaderText="DDH" />
                            <asp:BoundField HeaderText="DIMPORT" />
                            <asp:BoundField HeaderText="GLOSA" />
                            <asp:BoundField HeaderText="DUSIMPORT" />
                            <asp:BoundField HeaderText="DMNIMPOR"></asp:BoundField>


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
                <td>
                    <asp:Label ID="lbldebesoles" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Haber s/.</td>
                <td>
                    <asp:Label ID="lblhabersoles" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Debe U$</td>
                <td>
                    <asp:Label ID="lbldebedolares" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Haber U$ </td>
                <td>
                    <asp:Label ID="lblhaberdolares" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
    </div>

</asp:Content>
