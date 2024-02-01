
<%@ Page Title="Comprobantes de Cheques" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ComprobantesCheques.aspx.cs" Inherits="FINANZAS_TESORERIA_CHEQUES_CONCAR_ComprobantesCheques" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link type="text/css" href="../../../CSS/base.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {
            UHTML.id = 'MainContent';
            dfirmas = [];
            $("#MainContent_txtfecha").datepicker();


            
$("#MainContent_txtcodigogirado").autocomplete(
   { source: function (request, response) {
           $.ajax({
               url: "ComprobantesCheques.aspx/ListarProveedoresporid",
               data: "{ 'texto': '" + request.term + "','cod': '" + Operacion.mask('ddltipoanexo').val().trim() + "','i': 'C' }",
               dataType: "json",
               type: "POST",
               contentType: "application/json; charset=utf-8",
               dataFilter: function (data) { return data; },
               success: function (data) {
                   response($.map(data.d, function (item) {
                       return {
                           id: item.ADESANE,
                           value: item.ACODANE + "-" + item.ADESANE,
                           
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
           $('#MainContent_txtgirado').val(str);
           $('#MainContent_txtgiradoa').val(str);

       }
   });

$("#MainContent_txtcuenta").autocomplete(
{ 
        source: function (request, response) {
        $.ajax({
            url: "ComprobantesCheques.aspx/ListarCtaE1",
            data: "{ 'descri': '" + request.term + "','anexo': '" + Operacion.mask('txtcvanexo').val().trim() + "', 'moneda': '" + Operacion.mask('txtmonedadet').val().trim() + "' }",
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
        //$('#MainContent_txtgirado').val(str);
        //$('#MainContent_txtgiradoa').val(str);

    }
});


            $("#MainContent_txtbancor").autocomplete(
     {
         source: function (request, response) {
             $.ajax({
                 url: "ComprobantesCheques.aspx/ListarBancosProg",
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
            
         }
     });
            function limpiar() {
                Operacion.mask('txttipocambio').val("");
                Operacion.mask('txttipocambio1').val("");
                Operacion.mask('txtcodigogirado').val("");
                Operacion.mask('txtgirado').val("");
                Operacion.mask('txtgiradoa').val("");
                Operacion.mask('txtconcepto').val("");
                Operacion.mask('txtimporte').val("");
                Operacion.mask('txtnumdoc').val("");

            }


  $("#MainContent_lblbancor").autocomplete(
     {
         source: function (request, response) {
             $.ajax({
                 url: "ComprobantesCheques.aspx/ListarBancosProg",
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
             $('#MainContent_txtcuentabanco').val(ui.item.b);
            
         }
     });
            $(".imprimir").click(function () {
                trp = $(this).parent().parent();
                SUBDIA = $("td:eq(0)", trp).html();
                COMPRO = $("td:eq(1)", trp).html();
                CHEQUE = $("td:eq(2)", trp).html();
                estado = $("td:eq(6)", trp).html();
                if (estado.trim() != "ANULADO") {
               if (CHEQUE !="&nbsp;") {
                     window.open("../CHEQUES/ImprimeCheque.aspx?CHEQUE= " + CHEQUE + "&SUBDIARIO=" + SUBDIA + "&COMPROBANTE=" + COMPRO, '_blank');
                }
                else {
                    alert("El cheque esta anulado");
               }
              }
                else {
                    alert("El cheque esta anulado");
             }

            });

            $(".filtrar").click(function () {
                filtrardetalles()
            });
          
            function filtrardetalles() {
                var COM = {};                   
                COM.CH_CNUMCHE = Operacion.mask('txtchequeinicial').val();
                COM.CH_CNOMCHE =  Operacion.mask('txtchequefinal').val();
                COM.CH_CSUBDIA ="23";
                COM.CH_CNUMCTA = Operacion.mask('txtbancor').val();
                $.ajax({

                    type: "POST",
                    url: "ComprobantesCheques.aspx/ConsultaChequeParametros",
                    data: '{COM: ' + JSON.stringify(COM) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {

                        if (data.d.length > 0) {
                            var row = $("[id*=gvcomprobantes] tr:last-child").clone(true);
                            $("[id*=gvcomprobantes] tr").not($("[id*=gvcomprobantes] tr:first-child")).remove();

                            for (var i = 0; i < data.d.length; i++) {
                                $("td", row).eq(0).html(data.d[i].CH_CSUBDIA);
                                $("td", row).eq(1).html(data.d[i].CH_CNUMCOM);
                                $("td", row).eq(2).html(data.d[i].CH_CNUMCHE);
                                $("td", row).eq(3).html((moment(data.d[i].CH_DFECHA).format("DD/MM/YYYY")));
                                $("td", row).eq(4).html(data.d[i].CH_CCODMON);
                                $("td", row).eq(5).html(data.d[i].CH_NIMPOCH);                              
                                $("td", row).eq(6).html(data.d[i].CH_CNOMCHE);

                                $("[id*=gvcomprobantes]").append(row);
                                row = $("[id*=gvcomprobantes] tr:last-child").clone(true);
                            }
                        } else {
                            var row = $("[id*=gvcomprobantes] tr:last-child").clone(true);
                            $("[id*=gvcomprobantes] tr").not($("[id*=gvcomprobantes] tr:first-child")).remove();

                            $("td", row).eq(1).html("");
                            $("td", row).eq(2).html("");
                            $("td", row).eq(3).html("");
                            $("td", row).eq(4).html("");
                            $("td", row).eq(5).html("");
                            $("td", row).eq(6).html("");
                            $("td", row).eq(0).html("");
                            $("[id*=gvcomprobantes]").append(row);
                           // alert("no se encontro registro");
                        }


                    },
                    error: function (response) {
                        if (response.length != 0)
                            alert(response);
                    }
                });
            }


            function ConsultaUnDetalle2(subdia, compro) {

                var COM = {};
                COM.DSUBDIA = subdia;
                COM.DCOMPRO = compro;
                $.ajax({

                    type: "POST",
                    url: "ComprobantesCheques.aspx/ConsultaunDetalle",
                    data: '{COM: ' + JSON.stringify(COM) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        if (data.d.length > 0) {
                            var row = $("[id*=GridView1] tr:last-child").clone(true);
                            $("[id*=GridView2] tr").not($("[id*=GridView2] tr:first-child")).remove();
                            for (var i = 0; i < data.d.length; i++) {
                                $("td", row).eq(0).html(data.d[i].DSECUE);
                                $("td", row).eq(0).val(data.d[i].DXGLOSA);
                                $("td", row).eq(1).html(data.d[i].DCUENTA);
                                $("td", row).eq(1).val(data.d[i].DCODARC);
                                $("td", row).eq(2).html(data.d[i].DCODANE);
                                $("td", row).eq(2).val(data.d[i].DMEDPAG);
                                $("td", row).eq(3).html(data.d[i].DCENCOS);
                                $("td", row).eq(4).html(data.d[i].DDH);
                                $("td", row).eq(5).html(data.d[i].DIMPORT);
                                $("td", row).eq(6).html(data.d[i].DTIPDOC);

                                $("td", row).eq(7).html(data.d[i].DNUMDOC);
                                $("td", row).eq(8).html(moment(data.d[i].DFECDOC2).format("DD/MM/YYYY"));
                                $("td", row).eq(9).html(data.d[i].DFECVEN2 != null ? moment(data.d[i].DFECVEN2).format("DD/MM/YYYY") : "");
                                $("td", row).eq(10).html(data.d[i].DAREA);
                                $("[id*=GridView2]").append(row);
                                row = $("[id*=GridView2] tr:last-child").clone(true);
                            }
                        } else {
                            var row = $("[id*=GridView2] tr:last-child").clone(true);
                            $("[id*=GridView2] tr").not($("[id*=gvcompGridView1robantes] tr:first-child")).remove();

                            $("td", row).eq(1).html("");
                            $("td", row).eq(2).html("");
                            $("td", row).eq(3).html("");
                            $("td", row).eq(4).html("");
                            $("td", row).eq(5).html("");
                            $("td", row).eq(6).html("");
                            $("td", row).eq(0).html("");
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


            function filtrartodos() {
                var COM = {};
                COM.CH_CSUBDIA = "23";
                  $.ajax({

                    type: "POST",
                    url: "ComprobantesCheques.aspx/DETALLE",
                    data: '{CODATA: ' + JSON.stringify(COM) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {

                        if (data.d.length > 0) {
                            var row = $("[id*=gvcomprobantes] tr:last-child").clone(true);
                            $("[id*=gvcomprobantes] tr").not($("[id*=gvcomprobantes] tr:first-child")).remove();

                            for (var i = 0; i < data.d.length; i++) {
                                $("td", row).eq(0).html(data.d[i].CSUBDIA);
                                $("td", row).eq(1).html(data.d[i].CCOMPRO);
                                $("td", row).eq(2).html(data.d[i].CMEMO);
                                $("td", row).eq(3).html(moment(data.d[i].CDATE).format("DD/MM/YYYY"));
                                $("td", row).eq(4).html(data.d[i].CCODMON);
                                $("td", row).eq(5).html(data.d[i].CTOTAL);
                                $("td", row).eq(6).html(data.d[i].CGLOSA);

                                $("[id*=gvcomprobantes]").append(row);
                                row = $("[id*=gvcomprobantes] tr:last-child").clone(true);
                            }
                        } else {
                            var row = $("[id*=gvcomprobantes] tr:last-child").clone(true);
                            $("[id*=gvcomprobantes] tr").not($("[id*=gvcomprobantes] tr:first-child")).remove();

                            $("td", row).eq(1).html("");
                            $("td", row).eq(2).html("");
                            $("td", row).eq(3).html("");
                            $("td", row).eq(4).html("");
                            $("td", row).eq(5).html("");
                            $("td", row).eq(6).html("");
                            $("td", row).eq(0).html("");
                            $("[id*=gvcomprobantes]").append(row);
                            alert("no se encontro registro");
                        }


                    },
                    error: function (response) {
                        if (response.length != 0)
                            console.log(response);
                    }
                });
            }
            $(window).load(function () {
          
               // filtrartodos();
            });
            $('#Nuevo').dialog({
                autoOpen: false,
                modal: true,
                resizable: true,
                width: 1050,
                heigth: 100,
                title: 'Registro',
                close: function (event, ui) {
                    // location.reload();
                    Operacion.mask('txtchequeinicial').val(Operacion.mask('txtcheque').val());
                    Operacion.mask('txtchequefinal').val(Operacion.mask('txtcheque').val());
                    filtrardetalles();
                    limpiar();
                },
            });

            $('#DetComprobante').dialog({
                autoOpen: false,
                modal: true,
                resizable: true,
                width: 1050,
                heigth: 100,
                title: 'Registro',
                close: function (event, ui) {
                    limpiar();
                    },
            });
           
            $(".NuevoCheque").click(function () {

                if (Operacion.mask('txtbancor').val() == "" || Operacion.mask('lblbancor').val() == "") {
                    alert("Debe seleccionar un banco antes de continuar");
                }
            else{

                

                $("#Nuevo").dialog('open');
                Operacion.mask('txtbanco').val(Operacion.mask('txtbancor').val());
                Operacion.mask('txtbanco1').val(Operacion.mask('lblbancor').val());
                GENERARCHEQUE();
                for (var area = 0 ; area < document.getElementById("<%= ddlarea.ClientID %>").length; area++) {
                      
                         if (document.getElementById("<%= ddlarea.ClientID %>").options[area].text.trim() == ("E03-E03 -PROVEEDORES DIVERSOS")) {
                             document.getElementById("<%= ddlarea.ClientID %>").selectedIndex = area;
                             //alert("AQUI");
                         }
                }}

            });

            $(".DetComprobantediv").click(function () {
               
                trp = $(this).parent().parent();
                SUBDIA = $("td:eq(0)", trp).html();
                COMPRO = $("td:eq(2)", trp).html();
                DCOMPRO = $("td:eq(1)", trp).html();
                estado = $("td:eq(6)", trp).html();
                if (estado.trim() != "ANULADO") {
                    $("#DetComprobante").dialog('open');
                    ConsultaUnCheque(SUBDIA, COMPRO);
                    ConsultaUnDetalle(SUBDIA, DCOMPRO);
                    ConsultaUnDetalle2(SUBDIA, DCOMPRO);
                    Operacion.mask('txtcuenta').val(Operacion.mask('txtmoneda').val().trim()=="MN"? Operacion.mask('lblcuentapago').text(): Operacion.mask('lblcuentapagodol').val() );
                    Consultasituacion();
                    }
                else {
                    alert("El documento se encuentra anulado");
                }
                
           });
       

        function GENERARCHEQUE() {
            var banco = Operacion.mask('txtbanco').val();

            $.ajax({

                type: "POST",
                url: "ComprobantesCheques.aspx/ListarDatosBancoID",
                data: "{ 'ban': '" + banco + "' }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    Operacion.mask('txtcheque').val(Operacion.cadenaMascara(Number(data.d.CT_NCHEQ01) + 1, 8));
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

             $(".tipocambio").change(function () {
                 //alert("dentro");
                 if (Operacion.mask('ddltipoconvers').val().trim()=="V") {
                    tipocambioVenta();

                }
                if (Operacion.mask('ddltipoconvers').val().trim()=="M") {
                    tipocambiocompra();
                }
                if (Operacion.mask('ddltipoconvers').val().trim() == "C") {
                    $('#MainContent_txttipocambio').val("0.00");
                }
                if (Operacion.mask('ddltipoconvers').val().trim() == "F") {
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
                    url: "ComprobantesCheques.aspx/obetenertcambiocvEdgar",
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
                var fecemi = moment($("#MainContent_txtfecha").val(), "DD/MM/YYYY");
                fecemi = fecemi == null ? null : new Date(fecemi);
                var com = {};
                com.XDATE = fecemi;
                $.ajax({

                    type: "POST",
                    url: "ComprobantesCheques.aspx/obetenertcambiocvEdgar",
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

            ////////////////////////INICIO DEL PROCESO DEL PRIMER GUARDADO /////////////////////////////////////
           
            $(".CONFIRMAR").click(function () {
                var codigo = $('#MainContent_txtcheque').val();
                var comprobante = generar().ultimodato;
                if (comprobante != "" && comprobante != null) {
                    InsertaCheque(comprobante);
                    
                }
                else {
                    alert("No se ha generado ningun comprobante");
                }
            });
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
                    url: "ComprobantesCheques.aspx/correlativoCP",
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
            function InsertarCabComprobante(comprobante) {
                var f = moment($("#MainContent_txtfecha").val(), "DD/MM/YYYY");
                f = f == null ? null : new Date(f);
                var cadena = "";
                var fecha = new Date();
                var annio = fecha.getFullYear().toString();
                var DETACAB = {};
                            DETACAB.CSUBDIA = Operacion.mask('ddlsubdiario').val();
                            DETACAB.CCOMPRO = comprobante;
                            DETACAB.CFECCOM = annio.substr(2, 2) + (Number(f.getMonth() + 1) < 10 ? "0" + (f.getMonth() + 1) : (f.getMonth() + 1)) + f.getDate(); 
                            DETACAB.CCODMON = Operacion.mask('txtmoneda').val();
                            DETACAB.CSITUA = "P";
                            DETACAB.CTIPCAM = $('#MainContent_txttipocambio').val();
                            cadena = "BCO: " + Operacion.mask('txtbanco').val() + "CH:" + Operacion.mask('txtcheque').val() + " " + $("#MainContent_txtgiradoa").val();
                            DETACAB.CGLOSA = cadena.substr(0, 39);
                         
                            DETACAB.CTOTAL = 0;
                                                       
                            DETACAB.CTIPO = Operacion.mask('ddltipoconvers').val().trim();
                            DETACAB.CFLAG = "S";  
                            DETACAB.CDATE = fecha;
                            DETACAB.CHORA = fecha.getHours() + ":" + ((fecha.getMinutes()).toString().length<2? "0"+ fecha.getMinutes(): fecha.getMinutes());
                            DETACAB.CUSER = $("#MainContent_lblusuario").html();
                            DETACAB.CFECCAM = "      ";
                            DETACAB.CORIG = "--";
                            DETACAB.CFORM = "-";
                            DETACAB.CTIPCOM = "05";
                            DETACAB.CEXTOR = " ";
                            DETACAB.CFECCOM2 = f;
                            DETACAB.CFECCAM2 = null;
                            DETACAB.CMEMO = " ";
                            DETACAB.CSERCER = "    ";
                            DETACAB.CNUMCER = "          ";
                $.ajax({
                    type: "POST",
                    url: "ComprobantesCheques.aspx/InsertCabComprobante",
                    data: '{DETA: ' + JSON.stringify(DETACAB) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response){
                        insertadetcomprobante(comprobante);
                        //ActComprobante(Number((DETACAB.CCOMPRO).substr(2, 4)), DETACAB.CCOMPRO);
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

               

            function InsertaCheque(comprobante) {
                firma();
               
                var f = moment($("#MainContent_txtfecha").val(), "DD/MM/YYYY");
                f = f == null ? null : new Date(f);

                var fecha = new Date();
                var annio = f.getFullYear().toString();
                var annioa = fecha.getFullYear().toString();
               // var anniod = fd.getFullYear().toString();

                var DETACHEQUE = {};
                DETACHEQUE.CH_CNUMCTA = Operacion.mask('txtbanco').val();
                DETACHEQUE.CH_CNUMCHE = Operacion.mask('txtcheque').val();
                DETACHEQUE.CH_CFECCHE = annio.substr(2, 2) + (Number(f.getMonth() + 1) < 10 ? "0" + (f.getMonth() + 1) : (f.getMonth() + 1)) + f.getDate();
                DETACHEQUE.CH_CNOMCHE = Operacion.mask('txtgirado').val();
                DETACHEQUE.CH_CFECCOM = annio.substr(2, 2) + (Number(f.getMonth() + 1) < 10 ? "0" + (f.getMonth() + 1) : (f.getMonth() + 1)) + f.getDate();
                DETACHEQUE.CH_CSUBDIA = Operacion.mask('ddlsubdiario').val();
                DETACHEQUE.CH_CNUMCOM = comprobante;
                DETACHEQUE.CH_NIMPOCH = Operacion.mround(Number($("#MainContent_txtimporte").val()),2);

                DETACHEQUE.CH_CCODMON = Operacion.mask('txtmoneda').val().trim();
                DETACHEQUE.CH_CVANEXO = Operacion.mask('ddltipoanexo').val().trim();  
                DETACHEQUE.CH_CCODIGO = Operacion.mask('txtcodigogirado').val().substr(0,17);
                DETACHEQUE.CH_CESTADO = "C";
                DETACHEQUE.CH_CFECEST = annioa.substr(2, 2) + (Number(fecha.getMonth() + 1) < 10 ? "0" + (fecha.getMonth() + 1) : (fecha.getMonth() + 1)) + fecha.getDate();

                DETACHEQUE.CH_CUSUARI =Operacion.mask('lblusuario').text(); 
                DETACHEQUE.CH_DFECHA = fecha;
                DETACHEQUE.CH_CHORA =  fecha.getHours() + ":" + ((fecha.getMinutes()).toString().length < 2 ? "0" + fecha.getMinutes() : fecha.getMinutes());
                DETACHEQUE.CH_CCTACON = Operacion.mask('txtcuentabanco').val();
                DETACHEQUE.CH_CSITUAC = "";
                DETACHEQUE.CH_DOCREFT = "";
                DETACHEQUE.CH_DOCREFN = "";
                DETACHEQUE.CH_CCOGAST = "0";
                DETACHEQUE.CH_CCONCEP = Operacion.mask('txtconcepto').val();
                DETACHEQUE.CH_CFECDIF = "";
                DETACHEQUE.CH_NTIPCAM = Operacion.mask('txttipocambio').val();
                DETACHEQUE.CH_DFECCHE = f;
                DETACHEQUE.CH_DFECCOM = f;
                DETACHEQUE.CH_DFECEST = null;
                DETACHEQUE.CH_DFECDIF = null;
                DETACHEQUE.CH_CNOMCH2 = Operacion.mask('txtgiradoa').val();
                DETACHEQUE.CH_CNOMFR1 = (dfirmas[0] == null ? "" : dfirmas[0]);
                DETACHEQUE.CH_CNOMFR2 = (dfirmas[1] == null ? "" : dfirmas[1]);
                DETACHEQUE.CH_CFLGNEG = (document.getElementById("<%=negociable.ClientID%>").checked == true ? "S" : " ");// no negociable
               // console.log(DETACHEQUE);
                $.ajax({
                    type: "POST",
                    url: "ComprobantesCheques.aspx/InsertaCheques",
                    data: '{DETA: ' + JSON.stringify(DETACHEQUE) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        //alert("Inserta Cheque");
                        InsertarCabComprobante(DETACHEQUE.CH_CNUMCOM)
                    },
                    error: function (response) {
                        if (response.length != 0)
                            //alert(response);
                        console.log(response);

                    }
                });
            }
            function ActComprobante(numero,compro) {
                var DETA = {};
                var fecha = moment($("#MainContent_txtfecha").val(), "DD/MM/YYYY");
                fecha = fecha == null ? null : new Date(fecha);

                DETA.CTSUBDIA = Operacion.mask('ddlsubdiario').val();
                DETA.CTANO = (fecha.getFullYear()).toString().substr(2, 2);
                DETA.CTMES = (Number(fecha.getMonth() + 1) < 10 ? "0" + (fecha.getMonth() + 1).toString() : (fecha.getMonth() + 1).toString());
                DETA.CTNUMER = numero.toString();
                console.log(DETA);
                $.ajax({
                    type: "POST",
                    url: "ComprobantesCheques.aspx/Numeracion",
                    data: '{DETA: ' + JSON.stringify(DETA) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        ActualizarChequera(compro)
                    },
                    error: function (response) {
                        if (response.length != 0)
                            console.log(response);
                    }
                });
            }

            function ActualizarChequera(comprobanteb) {
                var DETA = {};
                DETA.CT_CTIPCTA = "1";
                DETA.CT_CNUMCTA = Operacion.mask('txtbanco').val();
                DETA.CT_NCHEQ01 = Operacion.mask('txtcheque').val();
                $.ajax({
                    type: "POST",
                    url: "ComprobantesCheques.aspx/ActualizaCheque",
                    data: '{DETA: ' + JSON.stringify(DETA) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        alert("se ha generado el comprobante Nº " + Operacion.mask('ddlsubdiario').val() +" - "+ comprobanteb); //llamar a impresion.
                        $("#Nuevo").dialog('close');
                    },
                    error: function (response) {
                        if (response.length != 0)
                            console.log(response);
                    }
                });
            }

            function insertadetcomprobante(COMPROBANTE) {
                var GD = {};
                var pago = {};
                var f = new Date();
                var dia = "";
                var mes = "";
                var annio = "";
                var DETADC = {};
                var cont = 1;
                var annioven = "";
                var aannio = "";
                var i = 0;
                annio = Number(f.getFullYear()).toString();

                var ftext = moment($("#MainContent_txtfecha").val(), "DD/MM/YYYY");
                ftext = ftext == null ? null : new Date(ftext);

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
                DETADC.DCODANE = Operacion.mask('txtbanco').val();
                DETADC.DCENCOS = " ";
                DETADC.DCODMON = Operacion.mask('txtmoneda').val();
                DETADC.DDH = "H";
                DETADC.DIMPORT = Operacion.mask('txtimporte').val();
                DETADC.DTIPDOC = "CH";
                DETADC.DNUMDOC = Operacion.mask('txtcheque').val();
                DETADC.DFECDOC = ftext.getFullYear().toString().substr(2, 2) + (Number(ftext.getMonth() + 1) < 10 ? "0" + (ftext.getMonth() + 1) : (ftext.getMonth() + 1)) + ftext.getDate();
                DETADC.DFECVEN = ""
                DETADC.DAREA = Operacion.mask('ddlarea').val();
                DETADC.DFLAG = "S";
                DETADC.DDATE = f;
                DETADC.DXGLOSA = Operacion.mask('txtconcepto').val();;
                DETADC.DMNIMPOR = (Operacion.mask('txtmoneda').val().trim() == "MN" ? Operacion.mround(Number(Operacion.mask('txtimporte').val()), 2) : Operacion.mround(Number(Operacion.mask('txtimporte').val())*Number(Operacion.mask('txttipocambio').val()), 2));
                DETADC.DUSIMPOR = (Operacion.mask('txtmoneda').val().trim() == "US" ? Operacion.mround(Number(Operacion.mask('txtimporte').val()), 2) : Operacion.mround(Number(Operacion.mask('txtimporte').val()) / Number(Operacion.mask('txttipocambio').val()), 2));;

                DETADC.DCODARC = "02";
                DETADC.DFECCOM2 = (moment($("#MainContent_txtfecha").val(), "DD/MM/YYYY"));
                DETADC.DFECDOC2 = (moment($("#MainContent_txtfecha").val(), "DD/MM/YYYY"));
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
                DETADC.DMEDPAG =Operacion.mask('ddlmediopago').val();
                DETADC.DTIPDO2 = "";
                DETADC.DNUMDO2 = "";
                DETADC.DRETE = "";
                DETADC.DPORRE = 0;
                console.log(DETADC);

                $.ajax({
                    type: "POST",
                    url: "ComprobantesCheques.aspx/InsertDetComprobante",
                    data: '{DETA: ' + JSON.stringify(DETADC) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        ActComprobante(Number((COMPROBANTE).substr(2, 4)), COMPROBANTE);
                    },
                    error: function (response) {
                        if (response.length != 0)
                            console.log(response);
                    }
                });

            }
        }
        

            function ConsultaUnCheque(subdia, compro) {
                
                var COM = {};
                COM.CH_CSUBDIA = subdia;
                COM.CH_CNUMCHE = compro;
                COM.CH_CNUMCTA = Operacion.mask('txtbancor').val();
                console.log(COM);
                $.ajax({

                    type: "POST",
                    url: "ComprobantesCheques.aspx/ConsultaCheque",
                    data: '{COM: ' + JSON.stringify(COM) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        if (data.d.length > 0) {  
                        
                           for (var i = 0; i < data.d.length; i++) {
                                Operacion.mask('txtsubdiario').val(data.d[i].CH_CSUBDIA);
                                Operacion.mask('txtcomprobantedet').val(data.d[i].CH_CNUMCOM);
                                Operacion.mask('txtmonedadet').val(data.d[i].CH_CCODMON);
                                Operacion.mask('txtfechadet').val(moment(data.d[i].CH_DFECCHE).format("DD/MM/YYYY"));

                                Operacion.mask('txtfecdoc').val(moment(data.d[i].CH_DFECCHE).format("DD/MM/YYYY"));

                                Operacion.mask('txtanexo').val(data.d[i].CH_CCODIGO);
                                Operacion.mask('txtdebehaber').val("D");
                                Operacion.mask('txtimportedet').val(data.d[i].CH_NIMPOCH);
                                Operacion.mask('txtcvanexo').val(data.d[i].CH_CVANEXO);
                                Operacion.mask('txtcnomche').val(data.d[i].CH_CNOMCHE);
                                Operacion.mask('txttipocambio1').val(data.d[i].CH_NTIPCAM);
                            } 
                   } 
                    },
                    error: function (response) {
                        if (response.length != 0)
                            console.log(response);
                    }
                });
            }

            function Consultasituacion() {

                var COM = {};
                COM.CSUBDIA = Operacion.mask('txtsubdiario').val();
                COM.CCOMPRO = Operacion.mask('txtcomprobantedet').val();
                
                $.ajax({

                    type: "POST",
                    url: "ComprobantesCheques.aspx/CABECERA",
                    data: '{COM: ' + JSON.stringify(COM) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                       // if (data.d.length > 0) {

                           // for (var i = 0; i < data.d.length; i++) {
                                Operacion.mask('txtsituacion').val(data.d.CSITUA);
                              // }
                        //}
                    },
                    error: function (response) {
                        if (response.length != 0)
                            console.log(response);
                    }
                });
            }

            function ConsultaUnDetalle(subdia, compro) {

                var COM = {};
                COM.DSUBDIA = subdia;
                COM.DCOMPRO = compro;
                $.ajax({

                    type: "POST",
                    url: "ComprobantesCheques.aspx/ConsultaunDetalle",
                    data: '{COM: ' + JSON.stringify(COM) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        if (data.d.length > 0) {
                            var row = $("[id*=GridView1] tr:last-child").clone(true);
                            $("[id*=GridView1] tr").not($("[id*=GridView1] tr:first-child")).remove();
                            for (var i = 0; i < data.d.length; i++) {
                                $("td", row).eq(0).html(data.d[i].DSECUE);
                                $("td", row).eq(0).val(data.d[i].DXGLOSA);

                                Operacion.mask('txtglosadet').val(data.d[i].DXGLOSA);

                                $("td", row).eq(1).html(data.d[i].DCUENTA);
                                $("td", row).eq(1).val(data.d[i].DCODARC);
                                $("td", row).eq(2).html(data.d[i].DCODANE);
                                $("td", row).eq(2).val(data.d[i].DMEDPAG);
                                $("td", row).eq(3).html(data.d[i].DCENCOS);
                                $("td", row).eq(4).html(data.d[i].DDH);
                                $("td", row).eq(5).html(data.d[i].DIMPORT);
                                $("td", row).eq(6).html(data.d[i].DTIPDOC);

                                $("td", row).eq(7).html(data.d[i].DNUMDOC);
                                $("td", row).eq(8).html(moment(data.d[i].DFECDOC2).format("DD/MM/YYYY"));
                                $("td", row).eq(9).html(data.d[i].DFECVEN2 != null ? moment(data.d[i].DFECVEN2).format("DD/MM/YYYY") : "");
                                $("td", row).eq(10).html(data.d[i].DAREA);
                                $("[id*=GridView1]").append(row);
                                row = $("[id*=GridView1] tr:last-child").clone(true);
                            }
                        } else {
                            var row = $("[id*=GridView1] tr:last-child").clone(true);
                            $("[id*=GridView1] tr").not($("[id*=gvcompGridView1robantes] tr:first-child")).remove();

                            $("td", row).eq(1).html("");
                            $("td", row).eq(2).html("");
                            $("td", row).eq(3).html("");
                            $("td", row).eq(4).html("");
                            $("td", row).eq(5).html("");
                            $("td", row).eq(6).html("");
                            $("td", row).eq(0).html("");
                            $("[id*=GridView1]").append(row);
                            alert("no se encontro registro");
                        }
                    },
                    error: function (response) {
                        if (response.length != 0)
                            console.log(response);
                    }
                });
                // obtener la diferencia
                diferencias();
            }
            function diferencias(){
                subtt = 0; acum = 0;
                sumah = 0;
                sumad = 0;
              
                var gridView = document.getElementById("<%=GridView1.ClientID %>");

                for (var t = 1; t < gridView.rows.length; t++) {
                                      
                    if (gridView.rows[t].cells[4].textContent == "H") {
                        cellPivot = gridView.rows[t].cells[5];
                        subtt = cellPivot.innerHTML;
                        sumah = new Number(sumah) + new Number(subtt);
                    }
                    else {
                        cellPivot = gridView.rows[t].cells[5];
                        subtt = cellPivot.innerHTML;
                        sumad = new Number(sumad) + Number(subtt); 
                             }
                }
                Operacion.mask('txtdebe').val(Operacion.mround(Number(sumad),2));
                Operacion.mask('txthaber').val(Operacion.mround(Number(sumah), 2));
                Operacion.mask('txtdiferencia').val(Operacion.mround(Number(sumad), 2) - Operacion.mround(Number(sumah), 2));
            }
            $(".agregar").click(function () {

                if (Operacion.mask('txtsituacion').val().trim() != "F")
                {
                subtt = 0; acum = 0;
                sumah = 0;
                sumad = 0;
                secuencia = 0;

                var gridView = document.getElementById("<%=GridView1.ClientID %>");
                for (var t = 1; t < gridView.rows.length; t++) {                                      
                    if (gridView.rows[t].cells[4].textContent == "H") {
                        cellPivot = gridView.rows[t].cells[5];
                        subtt = cellPivot.innerHTML;
                        sumah = new Number(sumah) + new Number(subtt);
                        secuencia = gridView.rows[t].cells[0].innerHTML;
                    }
                    else {
                        cellPivot = gridView.rows[t].cells[5];
                        subtt = cellPivot.innerHTML;
                        sumad = new Number(sumad) + Number(subtt); 
                        secuencia = gridView.rows[t].cells[0].innerHTML;
                    }
                }
                
                if (Operacion.mask('txtdebehaber').val()=="D"){
                    sumad =Operacion.mround((Number(sumad) + Number(Operacion.mask('txtimportedet').val())),2);
                }
                else {
                    sumah = Operacion.mround((sumah + Number(Operacion.mask('txtimportedet').val())),2);
                }

                if (sumad <= sumah) {
                    AgregarGrilla(Operacion.cadenaMascara(Number(secuencia) + 1, 4));
                   diferencias();
                }
                else {
                    alert("No es posible agregar este item, corrija el monto ingresado");
                }
                }
                else {
                    alert("No es posible modificar este comprobante ya que se encuentra finalizado");
                }

            });

            $(".grabardetalle").click(function () {

            if (Operacion.mask('txtsituacion').val().trim() != "F")
                {

            if (Number(Operacion.mask('txtdiferencia').val())==0){
                eliminacomprobante();
                InsertarCabComprobante1();
                InsertaBalh();
                ConsultaUnDetalle2(Operacion.mask('txtsubdiario').val(), Operacion.mask('txtcomprobantedet').val())
                filtrardetalles();
                
               // location.reload();
               }
            else {
                alert("No es posible grabar estos datos porque existe una diferencia de : " + Operacion.mask("txtdiferencia").val());
            }
                }
                else {
                    alert("No es posible modificar este comprobante ya que se encuentra finalizado");
                }
            });

            function InsertaBalh() {
                   var fecha = moment($("#MainContent_txtfechadet").val(), "DD/MM/YYYY");
                   fecha = fecha == null ? null : new Date(fecha);
               var gridView = document.getElementById("<%=GridView1.ClientID %>");
               var BDATA = {};
               for (var t = 1; t < gridView.rows.length; t++) {

                   BDATA.BCUENTA = (gridView.rows[t].cells[1].innerHTML).trim();
                   BDATA.BMNSALA = 0;
                   BDATA.BMNDEBE = ((Operacion.mask('txtmonedadet').val().trim() == "MN" && gridView.rows[t].cells[4].innerHTML.trim() == "D") ? Operacion.mround(Number(gridView.rows[t].cells[5].innerHTML), 2) :0 );
                   BDATA.BMNHABER = ((Operacion.mask('txtmonedadet').val().trim() == "MN" && gridView.rows[t].cells[4].innerHTML.trim() == "H") ? Operacion.mround(Number(gridView.rows[t].cells[5].innerHTML), 2) : 0);
                   BDATA.BMNSALN = 0;
                   BDATA.BUSSALA = 0;
                   BDATA.BUSDEBE = ((Operacion.mask('txtmonedadet').val().trim() == "US" && gridView.rows[t].cells[4].innerHTML.trim() == "D") ? Operacion.mround(Number(gridView.rows[t].cells[5].innerHTML), 2) : 0);
                   BDATA.BUSHABER =((Operacion.mask('txtmonedadet').val().trim() == "US" && gridView.rows[t].cells[4].innerHTML.trim() == "H") ? Operacion.mround(Number(gridView.rows[t].cells[5].innerHTML), 2) : 0);
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
                       url: "ComprobantesCheques.aspx/ActualizarBalh",
                       data: '{DETA: ' + JSON.stringify(BDATA) + '}',
                       contentType: "application/json; charset=utf-8",
                       dataType: "json",
                       async: false,
                       success: function (response) {
                          // alert("registroi guardado");
                       },
                       error: function (response) {
                           if (response.length != 0)
                               alert(response);
                           console.log(BDATA);

                       }
                   });
                      
                 }
           }

          function AgregarGrilla(secuencia) {
                
                var gridView3 = document.getElementById("<%=GridView1.ClientID %>");

                var rowt = $("[id*=GridView1] tr:last-child").clone(true);    
               // for (var i = 0; i < gridView3.length; i++) {
                        $("td", rowt).eq(0).html(secuencia);
                        $("td", rowt).eq(1).html(Operacion.mask('txtcuenta').val().substring(0,11));
                        $("td", rowt).eq(2).html(Operacion.mask('txtanexo').val());
                        $("td", rowt).eq(4).html(Operacion.mask('txtdebehaber').val());

                        $("td", rowt).eq(5).html(Operacion.mask('txtimportedet').val());
                        $("td", rowt).eq(6).html(Operacion.mask('ddltipodoc').val());
                        $("td", rowt).eq(7).html(Operacion.mask('txtnumdoc').val());
                        $("td", rowt).eq(8).html(Operacion.mask('txtfechadet').val());

                        $("td", rowt).eq(9).html("");
                        $("td", rowt).eq(10).html(Operacion.mask('ddlareadet').val());
                      
                        
                        $("[id*=GridView1]").append(rowt);
                        rowt = $("[id*=GridView1] tr:last-child").clone(true);
                        
                 
                 }

            $(".eliminarUno").click(function () {

                if (Operacion.mask('txtsituacion').val().trim() != "F") {
                    var trp1 = $(this).parent().parent();
                    if ($("td:eq(1)", trp1).html().trim() != Operacion.mask('txtcuentabanco').val().trim()) {
                        if (confirm("¿ Desea Eliminar este item ?")) {
                            var trp = $(this).parent().parent();
                            trp.remove();
                        }
                    }
                    else {
                        {
                            alert("No es posible eliminar este item");
                        }
                    }
                    diferencias();
                }
                else {
                    alert("No es posible eliminar este comprobante ya que se encuentra finalizado");
                }

            });

            function insertadetcomprobante1(COMPROBANTE) {
                var GD = {};
                var pago = {};
                var f = new Date();
                var dia = "";
                var mes = "";
                var annio = "";
                var DETADC = {};
                var cont = 1;
                var annioven = "";
                var aannio = "";
                var i = 0;
                annio = Number(f.getFullYear()).toString();               

                var gridView = document.getElementById("<%=GridView1.ClientID %>");
                var MI_LEN = gridView.rows.length;
                for (var t = 1; t < MI_LEN; t++) {

                var ftext = moment((gridView.rows[t].cells[8].innerHTML).trim(), "DD/MM/YYYY");
                ftext = ftext == null ? null : new Date(ftext);
                    
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
                DETADC.DSECUE = (gridView.rows[t].cells[0].innerHTML).trim();
                DETADC.DFECCOM = ftext.getFullYear().toString().substr(2, 2) + (Number(ftext.getMonth() + 1) < 10 ? "0" + (ftext.getMonth() + 1) : (ftext.getMonth() + 1)) + ftext.getDate();
                DETADC.DCUENTA = (gridView.rows[t].cells[1].innerHTML).trim();
                DETADC.DCODANE = (gridView.rows[t].cells[2].innerHTML).trim();
                DETADC.DCENCOS = (gridView.rows[t].cells[3].innerHTML).trim();
                DETADC.DCODMON = Operacion.mask('txtmoneda').val();
                DETADC.DDH = (gridView.rows[t].cells[4].innerHTML).trim();
                DETADC.DIMPORT = (gridView.rows[t].cells[5].innerHTML).trim();
                DETADC.DTIPDOC = (gridView.rows[t].cells[6].innerHTML).trim();
                DETADC.DNUMDOC = (gridView.rows[t].cells[7].innerHTML).trim();
                DETADC.DFECDOC = ftext.getFullYear().toString().substr(2, 2) + (Number(ftext.getMonth() + 1) < 10 ? "0" + (ftext.getMonth() + 1) : (ftext.getMonth() + 1)) + ftext.getDate();
                DETADC.DFECVEN = (gridView.rows[t].cells[9].innerHTML).trim();
                DETADC.DAREA = (gridView.rows[t].cells[10].innerHTML).trim();
                DETADC.DFLAG = "S";
                DETADC.DDATE = f;
                DETADC.DXGLOSA = Operacion.mask('txtglosadet').val(),
                DETADC.DMNIMPOR = (Operacion.mask('txtmonedadet').val().trim() == "MN" ? Operacion.mround(Number((gridView.rows[t].cells[5].innerHTML).trim()), 2) : Operacion.mround(Number((gridView.rows[t].cells[5].innerHTML).trim())*Number(Operacion.mask('txttipocambio1').val()), 2));
                DETADC.DUSIMPOR = (Operacion.mask('txtmonedadet').val().trim() == "US" ? Operacion.mround(Number((gridView.rows[t].cells[5].innerHTML).trim()), 2) : Operacion.mround(Number((gridView.rows[t].cells[5].innerHTML).trim()) / Number(Operacion.mask('txttipocambio1').val()), 2));

                DETADC.DCODARC = ((gridView.rows[t].cells[1].innerHTML).trim() == Operacion.mask('txtcuentabanco').val().trim() ? (gridView.rows[t].cells[1].value) : " ");
                DETADC.DFECCOM2 = (moment((gridView.rows[t].cells[8].innerHTML).trim(), "DD/MM/YYYY"));
                DETADC.DFECDOC2 = (moment((gridView.rows[t].cells[8].innerHTML).trim(), "DD/MM/YYYY"));
                DETADC.DFECVEN2 = null;
                DETADC.DCODANE2 = "";
                DETADC.DVANEXO = ((gridView.rows[t].cells[1].innerHTML).trim() == Operacion.mask('txtcuentabanco').val().trim() ? "0" : Operacion.mask('txtcvanexo').val());
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
                DETADC.DMEDPAG = ((gridView.rows[t].cells[1].innerHTML).trim() == Operacion.mask('txtcuentabanco').val().trim() ? (gridView.rows[t].cells[2].value) : ""); 
                DETADC.DTIPDO2 = "";
                DETADC.DNUMDO2 = "";
                DETADC.DRETE = "";
                DETADC.DPORRE = 0;
               // console.log(DETADC);

                $.ajax({
                    type: "POST",
                    url: "ComprobantesCheques.aspx/InsertDetComprobante",
                    data: '{DETA: ' + JSON.stringify(DETADC) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                       // alert(MI_LEN + "-"+ t);
                        if ((MI_LEN - t) == 1) {
                            alert("Datos Guardados correctamente");
                        }
                    },
                    error: function (response) {
                        if (response.length != 0)
                            console.log(response);
                    }
                });
            }
            }
       


            function eliminacomprobante() {
          
                var DETADC = {};                          

                var gridView = document.getElementById("<%=GridView2.ClientID %>");
                var MI_LEN = gridView.rows.length;
                for (var t = 1; t < MI_LEN; t++) {

                var ftext = moment((gridView.rows[t].cells[8].innerHTML).trim(), "DD/MM/YYYY");
                ftext = ftext == null ? null : new Date(ftext);
                    
                DETADC.DSUBDIA = Operacion.mask('ddlsubdiario').val();
                DETADC.DCOMPRO = Operacion.mask('txtcomprobantedet').val();
                DETADC.DSECUE = (gridView.rows[t].cells[0].innerHTML).trim();
               
                $.ajax({
                    type: "POST",
                    url: "ComprobantesCheques.aspx/Elimina",
                    data: '{COM: ' + JSON.stringify(DETADC) + '}',
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

            function InsertarCabComprobante1() {
                var DETACAB = {};
                DETACAB.CSUBDIA = Operacion.mask('ddlsubdiario').val();
                DETACAB.CCOMPRO = Operacion.mask('txtcomprobantedet').val();
                DETACAB.CSITUA = "F";
                DETACAB.CTOTAL = Operacion.mask('txtdebe').val();

                $.ajax({
                    type: "POST",
                    url: "ComprobantesCheques.aspx/ActualizarSituacion",
                    data: '{COM: ' + JSON.stringify(DETACAB) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {

                        insertadetcomprobante1(Operacion.mask('txtcomprobantedet').val())
                       
                    },
                    error: function (response) {
                        if (response.length != 0)
                            alert(response);
                        console.log(response);

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
        .seleciona {}
        #btnfiltrat {
            width: 61px;
        }
        .auto-style1 {
            width: 196px;
        }
        .auto-style2 {
            width: 350px;
        }
        .auto-style3 {
            width: 88px;
        }
    </style>
    </asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="contenedor">
      <div id="Creacion" title="Creación">
          <TABLE>
              <tr>
                
                  <td>
                      &nbsp;</td>
                  <td>
                      <asp:Label ID="lblcuentapago" runat="server" Text="" style="display:none"></asp:Label>
                      <asp:Label ID="lblcuentapagodol" runat="server" Text="" style="display:none"></asp:Label>
                      <asp:Label ID="lblusuario" runat="server" Text="" style="display:none"></asp:Label>
                  </td>
                  <td>
                      <asp:Label ID="lblcuentaretencion" runat="server" Text="" style="display:none"></asp:Label>
                  </td>
              </tr>
          </TABLE>
          <table>
              <tr>
                  <td>Nro. de Cuenta Bancaria&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                   <td>
                       <asp:TextBox ID="txtbancor" runat="server" Width="175px"></asp:TextBox>
                       </td>
                  <td>
                        <asp:TextBox ID="lblbancor" runat="server" Width="434px"></asp:TextBox>
                    </td>
                 
              </tr>
              <tr>
                  <td>
                      Moneda
                  </td>
                  <td>
                       <asp:TextBox ID="txtmoneda" runat="server" Width="175px" ReadOnly="true"></asp:TextBox>
                       <asp:Label ID="Label1" runat="server" BorderStyle="None" style="display:none"></asp:Label>
                  </td>
                  <td>
                      <asp:TextBox ID="txtcuentabanco" runat="server" ReadOnly="true"></asp:TextBox>
                  </td>
                  </tr>
         
              <tr> <td>Cheque Inicial</td> <td>  <asp:TextBox ID="txtchequeinicial" runat="server" Width="175px" ReadOnly="false"></asp:TextBox></td> </tr>
               <tr> <td>Cheque Final</td> <td>  <asp:TextBox ID="txtchequefinal" runat="server" Width="175px" ReadOnly="false"></asp:TextBox></td>
                   <td>
              &nbsp;<input id="btnfiltrat" type="button" value="Filtrar" class="filtrar" />
                        &nbsp;<input id="btnnuevo" type="button" value="Nuevo" class="NuevoCheque" />
              </td>
                   
               </tr>
          
          </table>
   
            <table>
                <tr>
                    <td>
                        <div style="overflow: auto; width: 850px; height: 450px">
                            <asp:GridView ID="gvcomprobantes" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" OnRowCreated="griddata_RowCreated" Font-Size="Smaller" Width="830px">
                                <Columns>
                                    <asp:BoundField DataField="CSUBDIA" HeaderText="SD." />
                                    <asp:BoundField DataField="CCOMPRO" HeaderText="COMPROB." />
                                    <asp:BoundField DataField="CMEMO" HeaderText="NUM. CHEQUE" />
                                    <asp:BoundField DataField="CDATE" HeaderText="FECHA">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CCODMON" HeaderText="MO" />
                                    <asp:BoundField DataField="CTOTAL" HeaderText="TOTAL" />


                                    <asp:BoundField DataField="CGLOSA" HeaderText="GLOSA" />


                                    <asp:TemplateField HeaderText="DETALLES">
                                        <ItemTemplate>
                                            <div class="DetComprobantediv" style="text-align: center">
                                                <img alt="" src="../../../Images/edicion02.png" width="25" style="cursor: pointer" />
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


          <div id="Nuevo" >
         <table>
             <tr>
                 <td>Subdiario: </td>
                  <td> <asp:DropDownList ID="ddlsubdiario" runat="server" Height="27px" Width="351px"></asp:DropDownList> </td>
                  <td>Comprobante</td>
                 <td>
                     <asp:TextBox ID="txtcomprobante" runat="server"></asp:TextBox></td>
             </tr>
             <tr>
                 <td>Código Banco: </td>
                 <td>
                       <asp:TextBox ID="txtbanco" runat="server" Width="350px"></asp:TextBox>
                       </td>
                  
                 <td>Cheque</td>
                 <td>
                     <asp:TextBox ID="txtcheque" runat="server"></asp:TextBox></td>
             </tr>
             <tr>
                 <td>

                 </td>
                 <td>
                        <asp:TextBox ID="txtbanco1" runat="server" Width="350px"></asp:TextBox>
                    </td>
             </tr>
             <tr>
                 <td>Area: </td>
                  <td> <asp:DropDownList ID="ddlarea" runat="server" Height="16px" Width="350px"></asp:DropDownList> </td>
             
                 <td>Fecha</td>
                 <td>
                     <asp:TextBox ID="txtfecha" runat="server" class="tipocambio"></asp:TextBox></td>
             </tr>
             <tr>
                 <td>Tipo Pago: </td>
                  <td> <asp:DropDownList ID="ddlmediopago" runat="server" Height="16px" Width="350px"></asp:DropDownList></td>
             </tr>
             <tr>
                 <td>Tipo Anexo: </td>
                   <td> <asp:DropDownList ID="ddltipoanexo" runat="server" Height="16px" Width="350px"></asp:DropDownList></td>
             </tr>
             <tr>
                 <td>Código Girado: </td>
                  <td>
                      <asp:TextBox ID="txtcodigogirado" runat="server" Text="" Width="351px"></asp:TextBox>
                      </td>
                  
             </tr>
             <tr>
                 <td></td>
                 <td> 
                      <asp:TextBox ID="txtgirado" runat="server" Width="351px"></asp:TextBox>  </td>
             </tr>
             <tr>
                 <td>Girado a: </td>
                  <td> <asp:TextBox ID="txtgiradoa" runat="server" Width="352px"></asp:TextBox></td>
             </tr>
             <tr>
                 <td>Concepto: </td>
                  <td> <asp:TextBox ID="txtconcepto" runat="server" Width="351px"></asp:TextBox></td>
             </tr>
             <tr>
                 <td>Importe: </td>
                  <td> <asp:TextBox ID="txtimporte" runat="server" Width="350px"></asp:TextBox></td>
             </tr>
            </table>
              <table>
                   <tr>
                  <td class="auto-style3">Firmante1</td>
                  <td class="auto-style2">
                      <asp:CheckBox ID="firma1" runat="server" Class="firmas" Tag="fir" /> <asp:Label ID="lblfirma1" runat="server" Text="Label"></asp:Label></td>
                  <td>Firmante2</td>
                  <td class="auto-style1"><asp:CheckBox ID="firma2" runat="server" Class="firmas" Tag="fir" /> <asp:Label ID="lblfirma2" runat="server" Text="Label"></asp:Label></td>
              </tr>
                      <tr>
                  <td class="auto-style3">Firmante3</td>
                          <td class="auto-style2"><asp:CheckBox ID="firma3" runat="server" Class="firmas" Tag="fir" /> <asp:Label ID="lblfirma3" runat="server" Text="Label"></asp:Label></td>
                  <td>Firmante4</td>
                          <td class="auto-style1"><asp:CheckBox ID="firma4" runat="server"  Class="firmas" Tag="fir" /> <asp:Label ID="lblfirma4" runat="server" Text="Label"></asp:Label></td>
              </tr> 
                  <tr>
                      <td> <asp:CheckBox ID="negociable" runat="server" Text="No Negociable" /> </td>
                  </tr>
              </table>
              <table>
                  <tr>
                      <td>Tip. Convers. </td>
                      <td> <asp:DropDownList ID="ddltipoconvers" runat="server" Height="16px" Width="350px" class="tipocambio"></asp:DropDownList></td>
                  </tr>
                  <tr>
                      <td>Tipo Cambio: </td>
                     <td> <asp:TextBox ID="txttipocambio" runat="server" Width="79px"></asp:TextBox></td>
                  </tr>
                  <tr>
                      <td> <input id="btngrabar" type="button" value="Grabar" class="CONFIRMAR" /></td>
                  </tr>
                  
              </table>

     
          </div>
    <div id="DetComprobante">
        <table>
            <tr>
                <td>Subcomprobante </td>
                <td> <asp:TextBox ID="txtsubdiario" runat="server" ReadOnly="true" Width="71px"></asp:TextBox > 
                    <asp:TextBox ID="txtcomprobantedet" runat="server" ReadOnly="true" Width="105px"></asp:TextBox >
                    
                </td>
                <td>Debe </td>
                <td> <asp:TextBox ID="txtdebe" runat="server" ReadOnly="true"></asp:TextBox ></td>
            </tr>
            <tr>
                <td>Moneda </td>
                <td><asp:TextBox ID="txtmonedadet" runat="server" ReadOnly="true" Width="175px"></asp:TextBox > </td>
                <td>Haber </td>
                <td> <asp:TextBox ID="txthaber" runat="server" ReadOnly="true"></asp:TextBox ></td>
            </tr>
            <tr>
                <td>Fecha </td>
                <td><asp:TextBox ID="txtfechadet" runat="server" ReadOnly="true" Width="175px"></asp:TextBox > </td>
                <td>Diferencia </td>
                <td> <asp:TextBox ID="txtdiferencia" runat="server" ReadOnly="true"></asp:TextBox ></td>
                <td> <asp:TextBox ID="txtsituacion" runat="server" ReadOnly="true" style="display:none"></asp:TextBox ></td>
                <td> <asp:TextBox ID="txtcvanexo" runat="server" ReadOnly="true" style="display:none"></asp:TextBox ></td>
                <td> <asp:TextBox ID="txtcnomche" runat="server" ReadOnly="true" style="display:none"></asp:TextBox ></td>
                <td> <asp:TextBox ID="txttipocambio1" runat="server" ReadOnly="true" style="display:none"></asp:TextBox ></td>
                <td> <asp:TextBox ID="txtglosadet" runat="server" ReadOnly="true" ></asp:TextBox ></td>
            </tr>
          </table>
        <table>
            <tr>
                <td>
                    <div style="overflow: auto; width: 850px; height: 170px">
                            <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" OnRowCreated="griddata_RowCreated" Font-Size="Smaller" Width="830px">
                                <Columns>
                                    <asp:BoundField DataField="CSUBDIA" HeaderText="SEC" />
                                    <asp:BoundField DataField="CCOMPRO" HeaderText="CUENTA" />
                                    <asp:BoundField DataField="CMEMO" HeaderText="ANEXO" />
                                    <asp:BoundField DataField="CDATE" HeaderText="COS">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CCODMON" HeaderText="F" />
                                    <asp:BoundField DataField="CTOTAL" HeaderText="IMPORTE" />


                                    <asp:BoundField DataField="CGLOSA" HeaderText="TP" />


                                    <asp:BoundField DataField="DOCMTO" HeaderText="DOCMTO" />
                                    <asp:BoundField DataField="FEC DOC" HeaderText="FEC DOC" />
                                    <asp:BoundField DataField="FEC VEN" HeaderText="FEC VEN" />
                                    <asp:BoundField DataField="AREA" HeaderText="AREA" />


                                    <asp:TemplateField HeaderText="DETALLES">
                                        <ItemTemplate>
                                            <div class="eliminarUno" style="text-align: center">
                                                <img alt="" src="../../../Images/Message_Error.png" width="25" style="cursor: pointer" />
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
                    <div style="overflow: auto; width: 850px; height: 170px; display:none" >
                            <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" OnRowCreated="griddata_RowCreated" Font-Size="Smaller" Width="830px" >
                                <Columns>
                                    <asp:BoundField DataField="CSUBDIA" HeaderText="SEC" />
                                    <asp:BoundField DataField="CCOMPRO" HeaderText="CUENTA" />
                                    <asp:BoundField DataField="CMEMO" HeaderText="ANEXO" />
                                    <asp:BoundField DataField="CDATE" HeaderText="COS">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CCODMON" HeaderText="F" />
                                    <asp:BoundField DataField="CTOTAL" HeaderText="IMPORTE" />


                                    <asp:BoundField DataField="CGLOSA" HeaderText="TP" />


                                    <asp:BoundField DataField="DOCMTO" HeaderText="DOCMTO" />
                                    <asp:BoundField DataField="FEC DOC" HeaderText="FEC DOC" />
                                    <asp:BoundField DataField="FEC VEN" HeaderText="FEC VEN" />
                                    <asp:BoundField DataField="AREA" HeaderText="AREA" />


                                    <asp:TemplateField HeaderText="DETALLES">
                                        <ItemTemplate>
                                            <div class="eliminarUno" style="text-align: center">
                                                <img alt="" src="../../../Images/Message_Error.png" width="25" style="cursor: pointer" />
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
                 <td>Cuenta</td>
                 <td><asp:TextBox ID="txtcuenta" runat="server"></asp:TextBox></td>
                          
                    </tr>

            <tr>
                 <td>Anexo</td>
                 <td><asp:TextBox ID="txtanexo" runat="server"></asp:TextBox></td>
                  </tr>
             <tr>
                 <td>Tipo Pago</td>
                 <td><asp:DropDownlist ID="ddltipopago" runat="server"></asp:DropDownlist></td>
                  </tr>

            <tr>
                 <td>Debe Haber</td>
                 <td><asp:TextBox ID="txtdebehaber" runat="server"></asp:TextBox></td>

                <td>Importe</td>
                 <td><asp:TextBox ID="txtimportedet" runat="server"></asp:TextBox></td>
                  </tr>

            <tr>
                <td>Tipo Doc</td>
                 <td><asp:DropDownlist ID="ddltipodoc" runat="server"></asp:DropDownlist></td>
                <td>Num Doc</td>
                 <td><asp:Textbox ID="txtnumdoc" runat="server"></asp:Textbox></td>
            </tr>
            <tr>
                 <td>Fecha Doc.</td>
                 <td><asp:TextBox ID="txtfecdoc" runat="server"></asp:TextBox></td>
                  </tr>
             <tr>
                 <td>Area</td>
                 <td>
                     <asp:DropDownList ID="ddlareadet" runat="server"></asp:DropDownList> </td>
                  </tr>
             <tr>
                 <td>Glosa</td>
                 <td><asp:TextBox ID="txtglosa" runat="server"></asp:TextBox></td>
                  </tr>
            <tr>
                <td>
                    <input id="btnagregar" type="button" value="Agregar" class="agregar" /> </td>
                <td>
                    <input id="btngrabardetalle" type="button" value="Grabar" class="grabardetalle" /> </td>
            </tr>
        </table>
    </div>
   
   
</asp:Content>
