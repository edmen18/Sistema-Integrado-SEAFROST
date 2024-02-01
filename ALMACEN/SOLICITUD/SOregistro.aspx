<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SOregistro.aspx.cs" Inherits="Default2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link type="text/css" href="../../CSS/Base-s.css?2.5" rel="stylesheet" />

    <script type="text/javascript">

        function ModifyEnterKeyPressAsTab(event, info) {

            if (event.keyCode == 13) {
                cb = parseInt($(info).attr('tabindex'));
                cb2 = cb + 1;
                if ($(':input[TabIndex=\'' + (cb2) + '\']') != null) {
                    if ($(':input[TabIndex=\'' + (cb2) + '\']').attr("disabled") == false) {
                        $(':input[TabIndex=\'' + (cb2) + '\']').focus();
                        $(':input[TabIndex=\'' + (cb2) + '\']').select();
                    } else {
                        $(':input[TabIndex=\'' + (cb2 + 1) + '\']').focus();
                        $(':input[TabIndex=\'' + (cb2 + 1) + '\']').select();
                    }
                    event.preventDefault();
                    return false;
                }
            }
        }

        $(window).load(function () {
            miconsulta = 'getProducto';
            cc = 1;
            sw_edicion = 0;
            sw_nuevo = 0;
            sw_guardar = 0;
            DS_SUMAT = 0;
            DS_SUMATUS = 0;
            DS_SUMATMN = 0;
            contaditem = 0;
            $("#MainContent_txtfecha").datepicker();
            $(function () {
                UHTML.id = 'MainContent';
                Operacion.iValida(Operacion.mask("txtcant"), 1);
            });

            $.urlParam = function (name) {
                var results = new RegExp('[\?&]' + name + '=([^&#]*)').exec(window.location.href);
                return (results != null ? results[1] || 0 : "");
            }


            LlenarComboTrabajo();
            ISSAL = "";
            

            //mostrar informacion a editar
            $.urlParam = function (name) {
                var results = new RegExp('[\?&]' + name + '=([^&#]*)').exec(window.location.href);
                return (results != null ? results[1] || 0 : "");
            }
            var IDSO = $.urlParam("ID");//window.location.search.substring(1);
            var TDC = $.urlParam("TD");
            if (IDSO.length > 0) {
                sw_guardar = 1;
                MostraCabSol(IDSO,TDC);

            } else {
                Operacion.mask("txtfecha").val(moment().format("DD/MM/YYYY"));
            }

            
            textsuboc = Operacion.mask("ddlsarea").val();
            validamostrarcontrol(ISSAL);
            ocultarlote();
            var tolx = Mostrartolerancia().ee;
            Operacion.mask("txtxactual").val(tolx);

            var tcam = MostrarTcambio();
            $("#MainContent_txttcambio").val(tcam);


        });

    </script>


    <script type="text/javascript">
        $(function () {

            $("#MainContent_ddlccost").autocomplete(
                {
                    source: function (request, response) {
                        $.ajax({
                            url: "../../ORDENCOMPRA/OCnueva.aspx/Getcentrocosto",
                            data: "{ 'dato': '" + "%" + request.term + "%" + "' }",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            dataFilter: function (data) { return data; },
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        value: item.TG_CDESCRI,
                                        id: item.TG_CCLAVE.trim()
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
                        $('#MainContent_txtcodcos').val(str.trim());
                    }
                });





            $(".idart").autocomplete({
                              source: function (request, response) {
                                  $.ajax({
                                      url: "SOregistro.aspx/" + miconsulta,//GetProductos
                                      data: "{ 'dato': '" + "%" + request.term + "%" + "',COalm:'"+ $("#MainContent_ddlalma").val() +"' }",
                                      dataType: "json",
                                      type: "POST",
                                      contentType: "application/json; charset=utf-8",
                                      dataFilter: function (data) { return data; },
                                      success: function (data) {
                                          response($.map(data.d, function (item) {
                                              return {
                                                  value: item.AR_CDESCRI + " " + item.AR_CCODIGO.trim(),
                                                  id: item.AR_CCODIGO.trim(),
                                                  um: item.AR_CUNIDAD,
                                                  igvp: item.AR_NIGVCPR,
                                                  cuenta: item.AR_CCUENTA,
                                                  sarea: item.AR_CPARARA,
                                                  moncom: item.AR_CMONCOM,
                                                  tipotfv: item.AR_CTIPDES,
                                                  precio: item.AR_NPRECOM,
                                                  descpp: item.AR_CDESCRI

                                              }
                                          }))
                                      },
                                      error: function (XMLHttpRequest, textStatus, errorThrown) { //alert(textStatus); 
                                      }
                                  });
                              },
                              minLength: 1,
                              select: function (event, ui) {
                                  var str = ui.item.id;
                                  var strum = ui.item.um;
                                  var strigv = ui.item.igvp;
                                  var cta = ui.item.cuenta;
                                  var sarea = ui.item.sarea;
                                  var moncom = ui.item.moncom;
                                  var tipotfv = ui.item.tipotfv;
                                  var precioc = ui.item.precio;
                                  var pdescrp = ui.item.descpp;
                                  $("#MainContent_txtund").val(strum);
                                  $("#MainContent_txtidprod").val(str);
                                  $("#MainContent_hfproducto").val(pdescrp);
                                  var sxsoli = strockxusuario(str, $(".ctxtidsoli").val()).ee < 0 ? 0 : strockxusuario(str, $(".ctxtidsoli").val()).ee;
                                  var sxgeneral = strockxgenr(str).ee;
                                  var precio = MostrarPrecioProd(str).precio;
                                  var moned_p = MostrarPrecioProd(str).moneda;
                                  Operacion.mask("ddlsarea").val() =="5" ? Operacion.mask("txtprecio").val(precio.toFixed(4)) : Operacion.mask("txtprecio").val(0) ;
                                  
                                  Operacion.mask("txtmone").val(moned_p);
                                  Operacion.mask("txtstock").val(Number(sxsoli).toFixed(2));
                                  Operacion.mask("txtstockg").val(Number(sxgeneral).toFixed(2));
                                  $(".clcant").focus();

                              },
                              change: function (event, ui) {
                                  if (ui.item == null || ui.item == undefined) {
                                      //$("#MainContent_txtidprod1").val("");
                                      alert("No ha seleccionado El Producto");
                                      $(".idart").focus();
                                      //} else {
                                      //    $('#MainContent_txtcuenta').focus();
                                      //}
                                  }
                              }
                          }).keypress(function (event, ui) {
                              var str = $("#MainContent_txtidprove").val();
                              if (event.keyCode == 13) {

                                  $("#MainContent_txtcuenta").focus();

                              }
                          });
            $(".clprove").autocomplete(
                          {
                              source: function (request, response) {

                                  var ADATA = {};
                                  ADATA.AVANEXO = "P";
                                  ADATA.ADESANE = '%' + request.term + '%';
                                  ADATA.ATIPTRA = null;

                                  $.ajax({
                                      url: "ARingreso.aspx/GetProveedores",
                                      //data: "{ 'productos': '"+"%"+ request.term +"%"+"' ,codig:'P' }",
                                      data: '{ADATA:' + JSON.stringify(ADATA) + '}',
                                      dataType: "json",
                                      type: "POST",
                                      contentType: "application/json; charset=utf-8",
                                      dataFilter: function (data) { return data; },
                                      success: function (data) {
                                          response($.map(data.d, function (item) {
                                              return {
                                                  value: item.ADESANE.trim(),
                                                  id: item.ACODANE.trim(),
                                                  dir: item.AREFANE
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
                                  var str = ui.item.id.trim();
                                  var cadena = str;
                                  var dire = ui.item.dir;
                                  if (str != null || str != undefined) {
                                      $('#MainContent_txtidprove').val(str);
                                      //$('#MainContent_txtdire').val(dire);
                                  } else {
                                      $('#MainContent_txtidprove').val("");
                                      //$('#MainContent_txtdire').val("");
                                  }
                              },
                              change: function (event, ui) {
                                  if (ui.item == null || ui.item == undefined) {
                                      $("#MainContent_txtidprove").val("");
                                      $("#MainContent_txtprove").val("");
                                      $("#MainContent_txtprove").focus();
                                      alert("El Proveedor no se ha seleccionado");
                                  }
                              }
                          }).keypress(function (event, ui) {
                              //event.preventDefault();
                              var str = $("#MainContent_txtidprove").val();
                              if (event.keyCode == 13) {
                                  if (str == null || str == undefined || str.trim() == "") {
                                      $("#MainContent_txtprove").val("");
                                      $("#MainContent_txtprove").focus();
                                      alert("No ha seleccionado El Proveedor");
                                  } else {
                                      $("#MainContent_ddlsarea").focus();
                                  }
                              }
                          });

            $(".clcuenta").autocomplete(
                          {
                              source: function (request, response) {
                                  $.ajax({
                                      url: "ARingreso.aspx/listactaexis",
                                      data: "{ texto: '" + request.term + "' }",
                                      dataType: "json",
                                      type: "POST",
                                      contentType: "application/json; charset=utf-8",
                                      dataFilter: function (data) { return data; },
                                      success: function (data) {
                                          response($.map(data.d, function (item) {
                                              return {
                                                  value: item.TC_CDESCRI,
                                                  id: item.TC_CEXISTE.trim(),
                                                  vali: item.TC_CEXISTE.trim()
                                              }
                                          }))
                                      },
                                      error: function (XMLHttpRequest, textStatus, errorThrown) { //alert(textStatus); 
                                      }
                                  });
                              },
                              minLength: 1,
                              select: function (event, ui) {
                                  var str = ui.item.id;
                                  var strum = ui.item.um;
                                  $('#MainContent_txtidcuenta').val(str);
                              },
                              change: function (event, ui) {
                                  var str = ui.item;
                                  if (str == null || str == undefined || str.trim() == "") {
                                      $("#MainContent_txtidcuenta").val("");
                                      $("#MainContent_txtcuenta").val("");
                                      $(".clcuenta").focus();
                                      alert("No ha seleccionado El item");
                                  } else {
                                      $(".clprove").focus();
                                  }
                              }
                          }).keypress(function (event, ui) {
                              //event.preventDefault();
                              var str = $("#MainContent_txtidcuenta").val();
                              if (event.keyCode == 13) {
                                  if (str == null || str == undefined || str.trim() == "") {
                                      $("#MainContent_txtidcuenta").val("");
                                      $(".clcuenta").focus();
                                      alert("No ha seleccionado El item");
                                  } else {
                                      $(".clprove").focus();
                                  }
                              }
                          });


        });

    </script>





    <script type="text/javascript">
        function obetenerhora() {
            chora = new Date();
            chora = chora.getHours();
            cminu = new Date().getMinutes();
            chora = new String(chora);
            cminu = new String(cminu);
            var hor = chora + ":" + cminu;
            return hor;
        }


        function calculo_MNUS(controlmone, montototal_in) {
            montototal = montototal_in;
            montous = 0; montomn = 0;
            if (controlmone.trim() == "MN") {
                if (Number(montototal) == 0) {
                    montous = 0;
                } else {
                    montous = Number(montototal) / Number($("#MainContent_txttcambio").val());
                }
                montomn = Number(montototal);
            } else {
                montous = Number(montototal);
                montomn = Number(montototal) * Number($("#MainContent_txttcambio").val());
            }
            return {
                montous, montomn
            };
        }

        //verificar grid 
        function grabardetallegrid() {
            EliminaDetalle();
            DS_CCODIGO1 = "";
            DS_CANTID1 = 0;
            DS_SOLSALDO1 = 0; DS_ALMACEN = "";
            var gridView = document.getElementById("<%=gvdetalle.ClientID %>");//

                for (var t = 1; t < gridView.rows.length; t++) {

                    //cellPivot = gridView.rows[t].cells[0]; gitem = cellPivot.innerHTML;
                    cellPivot01D = gridView.rows[t].cells[3]; DS_CCODIGO1 = cellPivot01D.value;
                    cellPivot02D = gridView.rows[t].cells[1]; DS_CANTID1 = cellPivot02D.innerHTML;
                    cellPivot03D = gridView.rows[t].cells[4]; DS_ALMACEN = cellPivot03D.value;
                    cellPivot04D = gridView.rows[t].cells[4]; DS_PRECIO = cellPivot04D.innerHTML;
                    cellPivot05D = gridView.rows[t].cells[5]; DS_STOTALMN = cellPivot05D.value;
                    cellPivot06D = gridView.rows[t].cells[6]; DS_STOTALUS = cellPivot06D.value;
                    cellPivot07D = gridView.rows[t].cells[2]; DS_MONEDA = cellPivot07D.value;
                    //cellPivot03 = gridView.rows[t].cells[3]; gdescod = cellPivot03.innerHTML;
                    InsertarDetalle();
                }

                alert("Registro Grabado");
            }


            function arraygrid() {

                guardanomprod = [];
                DS_CCODIGO01 = "";
                var gridView = document.getElementById("<%=gvdetalle.ClientID %>");//

             for (var t = 1; t < gridView.rows.length; t++) {
                 cellPivot001 = gridView.rows[t].cells[3];
                 DS_CCODIGO01 = cellPivot001.value;
                 cellPivot002 = gridView.rows[t].cells[5];
                 //DS_SUMAT = Number(DS_SUMAT) + Number(cellPivot002.innerHTML);
                 //cellPivot002 = gridView.rows[t].cells[1]; DS_CANTID01 = cellPivot02.innerHTML;
                 guardanomprod[t - 1] = DS_CCODIGO01;

             }
         }


         function InsertarCabecera(VSM_CTD,DESTALMA,ALORI) {
             var horao = obetenerhora();

             var fec1 = moment($("#MainContent_txtfecha").val(), "DD/MM/YYYY");
             fec1 = fec1 == null ? null : new Date(fec1);
             var dfactual = moment($("#MainContent_hffactual").val(), "DD/MM/YYYY");
             dfactual = dfactual == null ? null : new Date(dfactual);
             var tabla_solicitud = {};
             var ft = moment().format("DD/MM/YYYY h:mm:ss");
             tabla_solicitud.SM_ID = $("#MainContent_txtnumdoc").val();
             tabla_solicitud.SM_IDSOLI = $("#MainContent_txtidsoli").val().trim();
             tabla_solicitud.SM_FECHA = fec1;
             tabla_solicitud.SM_GLOSA = $("#MainContent_txttra").val().trim();
             tabla_solicitud.SM_AREA = $("#MainContent_ddlsarea").val();
             tabla_solicitud.SM_FECHAACT = new Date(ft);
             tabla_solicitud.SM_USUA = $("#hfusu").val();
             tabla_solicitud.SM_ESTADO = "1";
             tabla_solicitud.SM_ORDTRA = Operacion.mask("ddltcur").val();
             tabla_solicitud.SM_MONEDA = Operacion.mask("txtmoneda").val();
             tabla_solicitud.SM_TOTALMN = DS_SUMATMN.toFixed(4);
             tabla_solicitud.SM_TOTALUS = DS_SUMATUS.toFixed(4);
             tabla_solicitud.SM_TCAMB = Operacion.mask("txttcambio").val();
             tabla_solicitud.SM_CCOSTO = Operacion.mask("txtcodcos").val();
             tabla_solicitud.SM_ALMA = ALORI ;
             tabla_solicitud.SM_SALA = DESTALMA;
             tabla_solicitud.SM_CTD = VSM_CTD;
             tabla_solicitud.SM_TIPOS = Operacion.mask("ddltipos").val();
             $.ajax({
                 type: "POST",
                 url: "SOregistro.aspx/InsertSolicitudC",
                 data: '{tabla_solicitud: ' + JSON.stringify(tabla_solicitud) + '}',
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 async: false,
                 success: function (response) { grabardetallegrid(); },
                 error: function (response) {
                     if (response.length != 0)
                         console.table(response);
                 }
             });

         }

         function InsertarDetalle() {

             var TDET = {};
             TDET.DS_IDSOLIC = $("#MainContent_txtnumdoc").val();
             TDET.DS_CCODIGO = DS_CCODIGO1;
             TDET.DS_CANTID = DS_CANTID1;
             TDET.DS_SOLSALDO = DS_SOLSALDO1;
             TDET.DS_ALMACEN = DS_ALMACEN;
             TDET.DS_MONEDA = DS_MONEDA;
             TDET.DS_PRECIO = DS_PRECIO;
             TDET.DS_STOTALMN = Number(DS_STOTALMN).toFixed(4);
             TDET.DS_STOTALUS = Number(DS_STOTALUS).toFixed(4);
             TDET.DS_TIPOS = $("#MainContent_ddltipos").val();
             TDET.DS_LOTE = $("#MainContent_txtlote").val();
             $.ajax({
                 type: "POST",
                 url: "SOregistro.aspx/InsertSolicitudD",
                 data: '{TDET: ' + JSON.stringify(TDET) + '}',
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 async: false,
                 success: function (response) { },
                 error: function (response) {
                     if (response.length != 0)
                         console.table(response);
                 }
             });
         }

         function EliminaDetalle() {

             var TDET = {};
             TDET.DS_IDSOLIC = $("#MainContent_txtnumdoc").val();

             $.ajax({
                 type: "POST",
                 url: "SOregistro.aspx/ElimSolicitudD",
                 data: '{TDET: ' + JSON.stringify(TDET) + '}',
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 async: false,
                 success: function (response) { },
                 error: function (response) {
                     if (response.length != 0)
                         console.table(response);
                 }
             });

         }





         function UltimoCodigo(TDOC_D) {
             var dato;
             $.ajax({
                 type: "POST",
                 url: "SOregistro.aspx/GetcodigoGenerar",
                 data: "{TDOC: '" + TDOC_D + "'}",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 async: false,
                 success: function (data) {
                     if (data.d == null) {
                         dato = "";
                     } else {
                         dato = data.d;
                     }
                 },
                 error: function (data) {
                     if (data.length != 0)
                         alert(data);
                 }
             });
             return dato;
         }

         function Mostrarundato(codigocons, codigoe) {
             var codigowh = codigoe;
             var codigoconswh = codigocons;
             var ee = "";
             $.ajax({

                 type: "POST",
                 url: "SOregistro.aspx/Getdescycodigo",
                 //data: '{CNUMDOC: ' + JSON.stringify(CNUMDOC) + '}',
                 data: "{dato: '" + codigoconswh + "',codigo:'" + codigowh + "' }",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 async: false,
                 success: function (data) {
                     if (data.d != null) {
                         ee = data.d.TG_CDESCRI;
                     } else {
                         ee = "";
                     }
                 },
                 error: function (data) {
                     if (data.length != 0)
                         alert(data);
                 }
             });
             return { ee };
         }


         function MostraCabSol(idsol, tiposol) {
             
             $.ajax({
                 type: "POST",
                 url: "SOregistro.aspx/MostraCabSol",
                 //data: '{CNUMDOC: ' + JSON.stringify(CNUMDOC) + '}',
                 data: "{ndoc: '" + idsol + "',tipod:'" + tiposol + "' }",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 async: false,
                 success: function (data) {
                     if (data.d != null) {

                         Operacion.mask("ddltipos").val(data.d.SM_TIPOS);
                         $(".ctxtidsoli").val(data.d.SM_IDSOLI);
                         var textdev = Mostrarundato(data.d.SM_IDSOLI, '12').ee;
                         var textccos = Mostrarundato(data.d.SM_CCOSTO, '10').ee;
                         Operacion.mask("txtsoli").val(textdev);
                         Operacion.mask("ddlccost").val(textccos);
                         Operacion.mask("txtcodcos").val(data.d.SM_CCOSTO);
                         Operacion.mask("txttra").val(data.d.SM_GLOSA);
                         Operacion.mask("txtnumdoc").val(data.d.SM_ID);
                         Operacion.mask("txtfecha").val(moment(data.d.SM_FECHA).format("DD/MM/YYYY"));
                         Operacion.mask("ddlsarea").val(data.d.SM_AREA);
                         Operacion.mask("ddlalma").val(data.d.SM_ALMA);
                         ISSAL = data.d.SM_SALA;
                         Operacion.mask("ddldest").val(data.d.SM_SALA);
                         MostraDetSol(idsol, tiposol);
                     } else {
                         alert("No se registra informacion");
                     }
                 },
                 error: function (data) {
                     if (data.length != 0)
                         alert(data);
                 }
             });
         }

         function MostraDetSol(idsol, tiposol) {

             $.ajax({
                 type: "POST",
                 url: "SOregistro.aspx/Listardetvale",
                 //data: '{CNUMDOC: ' + JSON.stringify(CNUMDOC) + '}',
                 data: "{codig: '" + idsol + "',DS_TIPOS:'" + tiposol + "' }",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 async: false,
                 success: function (data) {
                     if (data.d.length > 0) {
                         var rowt = $("[id*=gvdetalle] tr:last-child").clone(true);
                         $("[id*=gvdetalle] tr").not($("[id*=gvdetalle] tr:first-child")).remove();
                         cc = 2;
                         for (var i = 0; i < data.d.length; i++) {                            

                             var funi = Mostradatarti(data.d[i].DS_CCODIGO).cunidad;
                             var fdes = Mostradatarti(data.d[i].DS_CCODIGO).cdescri;
                             contaditem = Number(contaditem) + 1;
                             $("td", rowt).eq(0).html(contaditem);
                             $("td", rowt).eq(1).html(data.d[i].DS_CANTID.toFixed(2));
                             $("td", rowt).eq(2).html(funi);
                             $("td", rowt).eq(3).html(fdes);
                             $("td", rowt).eq(3).val(data.d[i].DS_CCODIGO);
                             $("td", rowt).eq(4).val(data.d[i].DS_ALMACEN);
                             var precus = calculo_MNUS(data.d[i].DS_MONEDA, data.d[i].DS_PRECIO).montous;
                             var precmn = calculo_MNUS(data.d[i].DS_MONEDA, data.d[i].DS_PRECIO).montomn;
                             var prmost = data.d[i].DS_MONEDA == "MN" ? precmn : precus;
                             var mtomostrar = prmost.toFixed(4) * Number(data.d[i].DS_CANTID).toFixed(4);
                             $("td", rowt).eq(4).html(prmost.toFixed(4));
                             $("td", rowt).eq(2).val(data.d[i].DS_MONEDA);
                             var calcula_sunt = Number(data.d[i].DS_PRECIO) * Number(data.d[i].DS_CANTID);
                             var cntMN = calculo_MNUS(data.d[i].DS_MONEDA, calcula_sunt).montomn;
                             var cntUS = calculo_MNUS(data.d[i].DS_MONEDA, calcula_sunt).montous;
                             DS_SUMAT = Number(DS_SUMAT.toFixed(4)) + Number(mtomostrar.toFixed(4));
                             Operacion.mask("txttotal").val(DS_SUMAT.toFixed(4));
                             $("td", rowt).eq(5).html(mtomostrar.toFixed(4));
                             
                             $("td", rowt).eq(5).val(cntMN.toFixed(4));
                             $("td", rowt).eq(6).val(cntUS.toFixed(4));


                             $("[id*=gvdetalle]").append(rowt);
                             rowt = $("[id*=gvdetalle] tr:last-child").clone(true);
                         }
                     } else {
                         cc = 1;
                         contaditem = 0;
                     }
                 },
                 error: function (data) {
                     if (data.length != 0)
                         alert(data);
                 }
             });
         }

         

         function strockxusuario(idprod, soli) {
             var ee = 0;
             var valores = {};
             valores.SS_CCODIGO = idprod;
             valores.SS_SOLICITAN = soli;
             valores.SS_ALMACEN = Operacion.mask("ddlalma").val();
             //valores.SS_ESTADO = $("#MainContent_ddlalma").val().trim();//almacen 
             $.ajax({
                 type: "POST",
                 url: "SOregistro.aspx/Stockxsol",
                 data: '{valores: ' + JSON.stringify(valores) + '}',
                 //data: "{dato: '" + codigoconswh + "',codigo:'" + codigowh + "' }",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 async: false,
                 success: function (data) {
                     if (data.d != 0) {
                         ee = data.d;
                     } else {
                         ee = 0;
                     }
                 },
                 error: function (data) {
                     if (data.length != 0)
                         alert(data);
                 }
             });
             return { ee };
         }

         function strockxgenr(idprod) {
             var ee = 0;
             var valores = {};
             valores.SS_CCODIGO = idprod;
             //valores.SS_SOLICITAN = soli;
             valores.SS_ALMACEN = Operacion.mask("ddlalma").val();
             valores.SS_ESTADO = $("#MainContent_ddlalma").val().trim();//almacen 
             $.ajax({
                 type: "POST",
                 url: "SOregistro.aspx/StockGenerall",
                 data: '{valores: ' + JSON.stringify(valores) + '}',
                 //data: "{dato: '" + codigoconswh + "',codigo:'" + codigowh + "' }",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 async: false,
                 success: function (data) {
                     if (data.d != 0) {
                         ee = data.d;
                     } else {
                         ee = 0;
                     }
                 },
                 error: function (data) {
                     if (data.length != 0)
                         alert(data);
                 }
             });
             return { ee };
         }

         function MostrarPrecioProd(idprod) {
             var precio = 0; var moneda = "";
             var ADATA = {};
             ADATA.RD_CCODIGO = idprod;
             $.ajax({
                 type: "POST",
                 url: "SOregistro.aspx/MostrarPrecioUlt",
                 data: '{ADATA: ' + JSON.stringify(ADATA) + '}',
                 //data: "{dato: '" + codigoconswh + "',codigo:'" + codigowh + "' }",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 async: false,
                 success: function (data) {
                     if (data.d != 0) {
                         precio = data.d.OC_NIMPMN;
                         moneda = data.d.OC_CCODMON;
                         //precio = data.d.OC_NIMPMN;
                     } else {
                         precio = 0;
                         moneda = "";
                     }
                 },
                 error: function (data) {
                     if (data.length != 0)
                         alert(data);
                 }
             });
             return { precio, moneda };
         }

         function Mostradatarti(idprod) {
             var cunidad = 0; var cdescri= "";
            
             $.ajax({
                 type: "POST",
                 url: "SOregistro.aspx/Mostrarunarti",
                 //data: '{ADATA: ' + JSON.stringify(ADATA) + '}',
                 data: "{SDATA: '" + idprod + "' }",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 async: false,
                 success: function (data) {
                     if (data.d != 0) {
                         cunidad = data.d.AR_CUNIDAD;
                         cdescri = data.d.AR_CDESCRI;
                         //precio = data.d.OC_NIMPMN;
                     } else {
                         cunidad = 0;
                         cdescri = "";
                     }
                 },
                 error: function (data) {
                     if (data.length != 0)
                         alert(data);
                 }
             });
             return { cunidad, cdescri };
         }


         function strockgeneral(idprod, soli) {
             var ee = 0;
             var valores = {};
             valores.SS_CCODIGO = idprod;
             valores.SS_ALMACEN = Operacion.mask("ddlalma").val();
             $.ajax({
                 type: "POST",
                 url: "SOregistro.aspx/StockGenerall",
                 data: '{valores: ' + JSON.stringify(valores) + '}',
                 //data: "{dato: '" + codigoconswh + "',codigo:'" + codigowh + "' }",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 async: false,
                 success: function (data) {
                     if (data.d != 0) {
                         ee = data.d;
                     } else {
                         ee = 0;
                     }
                 },
                 error: function (data) {
                     if (data.length != 0)
                         alert(data);
                 }
             });
             return { ee };
         }

         function ocultarlote() {
             if (Operacion.mask("ddltipos").val() == "SO") {
                 Operacion.mask("txtlote").hide();
                 Operacion.mask("lblote").hide();
                 Operacion.mask("txtflote").hide();
                 
             } else {
                 Operacion.mask("txtlote").show();
                 Operacion.mask("lblote").show();
                 Operacion.mask("txtflote").show();
             }
         }

         function validamostrarcontrol(ISSAL) {
             if (textsuboc == "5") {

                 //Operacion.mask("ddltcur").val("");
                 Operacion.mask("ddltcur").show();
                 Operacion.mask("txtcur").show();
                 Operacion.mask("txtmoneda").show();
                 Operacion.mask("lbtcurso").show();
                 Operacion.mask("txtxactual").show();
                 Operacion.mask("txtactual").show();
                 Operacion.mask("lbtole").show();
                 Operacion.mask("lbacumulado").show();
                 Operacion.mask("txtacumulado").show();
                 Operacion.mask("lbsaldo").show();
                 Operacion.mask("txtsaldo").show();
                 var tolx = Mostrartolerancia().ee;
                 Operacion.mask("txtxactual").val(tolx);
                 //Operacion.mask("txtactual").val("");

                 $("#MainContent_gvdetalle td:nth-child(5), #MainContent_gvdetalle th:nth-child(5)").show();
                 $("#MainContent_gvdetalle td:nth-child(6), #MainContent_gvdetalle th:nth-child(6)").show();
             } else {

                 $("#MainContent_gvdetalle td:nth-child(5), #MainContent_gvdetalle th:nth-child(5)").hide();
                 $("#MainContent_gvdetalle td:nth-child(6), #MainContent_gvdetalle th:nth-child(6)").hide();
                 Operacion.mask("ddltcur").hide();
                 Operacion.mask("txtcur").hide();
                 Operacion.mask("lbtcurso").hide();
                 Operacion.mask("txtxactual").hide();
                 Operacion.mask("txtmoneda").hide();
                 Operacion.mask("txtactual").hide();
                 Operacion.mask("lbtole").hide();
                 Operacion.mask("lbacumulado").hide();
                 Operacion.mask("txtacumulado").hide();
                 Operacion.mask("lbsaldo").hide();
                 Operacion.mask("txtsaldo").hide();
                 //Operacion.mask("ddltcur").val("");
             }
             if (textsuboc == "4" || textsuboc == "3") {
                 LlenarComboSalas(textsuboc, ISSAL);
                 
                 Operacion.mask("ddldest").show();
                 Operacion.mask("lbdest").show();

             } else {
                 Operacion.mask("ddldest").hide();
                 Operacion.mask("lbdest").hide();

             }
         }

         function calcular_presupuesto() {

             var inft = MostrarinfTrabajo(Operacion.mask("ddltcur").val().trim()).VPRESUPUESTO;
             var infmon = MostrarinfTrabajo(Operacion.mask("ddltcur").val().trim()).COD_MON;
             Operacion.mask("txtmoneda").val(infmon);
             Operacion.mask("txtcur").val(Number(inft).toFixed(4));
             var montot = inft * Number(Number(Operacion.mask("txtxactual").val() / 100) + 1);
             Operacion.mask("txtactual").val(montot.toFixed(4));
             var cantacumpr = Acumuladopr(Operacion.mask("ddltcur").val().trim()).cantpre;
             Operacion.mask("txtacumulado").val(cantacumpr);
             var saldoacu = Number(Operacion.mask("txtcur").val() - Number(Operacion.mask("txtacumulado").val()));
             Operacion.mask("txtsaldo").val(saldoacu);
         }

         function MostrarTcambio() {
             var dato;
             var fec1 = moment($("#MainContent_txtfecha").val(), "DD/MM/YYYY");
             fec1 = new Date(fec1);

             var TCAM = {};
             TCAM.XFECCAM2 = fec1;

             $.ajax({

                 type: "POST",
                 url: "../../ORDENCOMPRA/OCnueva.aspx/extraetcambio",//"/ORDENCOMPRA/OCnueva.aspx/",
                 data: '{TCAM: ' + JSON.stringify(TCAM) + '}',
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 async: false,
                 success: function (data) {
                     if (data.d == null) {
                         dato = 0;
                         //alert("No se encuentra registrado tipo de cambio - Comunicarse con contabilidad");
                     } else {
                         dato = data.d.XMEIMP2;
                     }
                 },
                 error: function (data) {
                     if (data.length != 0)
                         alert(data);
                 }

             });
             return dato;
         }

         function MostrarinfTrabajo(nrotrabajo) {
             var VPRESUPUESTO = "";
             var COD_MON = "";
             $.ajax({
                 type: "POST",
                 url: "../../ORDENCOMPRA/OCnueva.aspx/Mostraruntrabajo",
                 data: "{nrotra:'" + nrotrabajo + "' }",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 async: false,
                 success: function (data) {
                     if (data.d != null) {
                         VPRESUPUESTO = data.d.PRESUPUESTO;
                         COD_MON = data.d.COD_MON;
                     } else {
                         VPRESUPUESTO = "";
                         COD_MON = "";
                     }
                 },
                 error: function (data) {
                     if (data.length != 0)
                         alert(data);
                 }
             });
             return { VPRESUPUESTO, COD_MON };
         }

         function Acumuladopr(nrotrabajo) {
             var cantpre = "";
             $.ajax({
                 type: "POST",
                 url: "../../ORDENCOMPRA/OCnueva.aspx/GetmontoAcumulado",
                 data: "{nrotrabajo:'" + nrotrabajo + "' }",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 async: false,
                 success: function (data) {
                     if (data.d != null) {
                         cantpre = data.d;
                     } else {
                         cantpre = 0;
                     }
                 },
                 error: function (data) {
                     if (data.length != 0)
                         alert(data);
                 }
             });
             return { cantpre };
         }

         function Mostrartolerancia() {
             var ee = "";
             $.ajax({
                 type: "POST",
                 url: "../../ORDENCOMPRA/OCnueva.aspx/Mostrarxactual",
                 data: "{}",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 async: false,
                 success: function (data) {
                     if (data.d != null) {
                         ee = data.d;
                     } else {
                         ee = "";
                     }
                 },
                 error: function (data) {
                     if (data.length != 0)
                         alert(data);
                 }
             });
             return { ee };
         }


         function ValidaLote(Serie) {
             var SDATA = {};
             SDATA.SR_CCODIGO= Operacion.mask("txtidprod").val();
             SDATA.SR_CALMA=Operacion.mask("ddldest").val() ;
             SDATA.SR_CSERIE= Serie; 
             var V_DFECVEN = "";
             $.ajax({
                 type: "POST",
                 url: "SOregistro.aspx/ListarSL",
                 data: '{SDATA:' + JSON.stringify(SDATA) + '  }',
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 async: false,
                 success: function (data) {
                     if (data.d != null) {
                         V_DFECVEN = moment(data.d.SR_DFECVEN).format("DD/MM/YYYY");
                     } else {
                         V_DFECVEN = "";
                     }
                 },
                 error: function (data) {
                     if (data.length != 0)
                         alert(data);
                 }
             });
             return { V_DFECVEN };
         }

         function LlenarComboTrabajo() {
             $.ajax({
                 type: "POST",
                 url: "../../ORDENCOMPRA/OCnueva.aspx/ListarTrabajosCurso",
                 //data: '{LDE: ' + JSON.stringify(LDE) + '}',
                 data: "{}",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 async: false,
                 success: function (data) {
                     if (data.d.length > 0) {
                         var models = (typeof data.d) == 'string' ? eval('(' + data.d + ')') : data.d;
                         $("#MainContent_ddltcur").get(0).options.length = 0;
                         $("#MainContent_ddltcur").get(0).options[$("#MainContent_ddltcur").get(0).options.length] = new Option("", "");
                         for (var i = 0; i < models.length; i++) {
                             var val = models[i].TR_CODIGO;
                             var text = models[i].TR_CODIGO + " - " + models[i].CONTRATISTA;
                             $("#MainContent_ddltcur").get(0).options[$("#MainContent_ddltcur").get(0).options.length] = new Option(text, val);
                         }
                         $("#MainContent_ddltcur").attr("sort");

                     }
                 },
                 error: function (response) {
                     if (response.length != 0)
                         alert(response);
                 }
             });
         }

         function MostrarunRegistrocta(codcuenta) {
             rtdato = "";
             $.ajax({
                 type: "POST",
                 url: "ARingreso.aspx/extraedescuenta",
                 data: "{ncuenta: '" + codcuenta + "'}",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 async: false,
                 success: function (data) {
                     if (data.d == "") {
                         rtdato = "";
                     } else {
                         rtdato = data.d;
                     }
                 },
                 error: function (data) {
                     if (data.length != 0)
                         alert(data);
                 }
             });
             return { rtdato };
         }


         function LlenarComboSalas(CODAR, ISSAL) {
             var PDATA = {};
             PDATA.AF_COD = "SL";
             PDATA.AF_TDESCRI3 = CODAR;

             $.ajax({
                 type: "POST",
                 url: "SOregistro.aspx/Listarcombo",
                 data: '{PDATA: ' + JSON.stringify(PDATA) + '}',
                 //data: "{}",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 async: false,
                 success: function (data) {
                     if (data.d.length > 0) {
                         var models = (typeof data.d) == 'string' ? eval('(' + data.d + ')') : data.d;
                         $("#MainContent_ddldest").get(0).options.length = 0;
                         $("#MainContent_ddldest").get(0).options[$("#MainContent_ddldest").get(0).options.length] = new Option("", "");
                         for (var i = 0; i < models.length; i++) {
                             var val = models[i].AF_TDESCRI2;
                             var text = models[i].AF_TDESCRI1;
                             $("#MainContent_ddldest").get(0).options[$("#MainContent_ddldest").get(0).options.length] = new Option(text, val);
                         }

                         $("#MainContent_ddldest").attr("sort");
                         ISSAL =="" ?$("#MainContent_ddldest").val("") : $("#MainContent_ddldest").val(ISSAL);

                     }
                 },
                 error: function (response) {
                     if (response.length != 0)
                         alert(response);
                 }
             });
         }




         $(function () {
             $("#MainContent_txtsoli").autocomplete(
                 {
                     source: function (request, response) {
                         $.ajax({
                             url: "SOregistro.aspx/Gettablaycodigo",
                             data: "{ 'dato': '" + "%" + request.term + "%" + "',codigo:'12' }",
                             dataType: "json",
                             type: "POST",
                             contentType: "application/json; charset=utf-8",
                             dataFilter: function (data) { return data; },
                             success: function (data) {
                                 response($.map(data.d, function (item) {
                                     return {
                                         value: item.TG_CDESCRI,
                                         id: item.TG_CCLAVE.trim()
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
                         $('#MainContent_txtidsoli').val(str);

                     }
                 });




         });


    </script>


    <script type="text/javascript">
        $(function () {
            $(".btbuscar").click(function () {
                filtarocompra();
            });

            $(".tcamb").change(function () {
                var tcam = MostrarTcambio();
                $("#MainContent_txttcambio").val(tcam);
            });

            $("#MainContent_ddlalma").change(function () {
                Operacion.mask("txtproducto").val();
                Operacion.mask("txtproducto").focus();
            });
            
            $("#MainContent_txtlote").change(function () {
                
                var FechaLot = ValidaLote($("#MainContent_txtlote").val().trim()).V_DFECVEN;
                
                if (FechaLot == "") {
                    alert("Lote no existe");
                    $("#MainContent_txtlote").val("");
                    $("#MainContent_txtlote").focus();
                } else {
                    $("#MainContent_txtflote").val(FechaLot);
                }
            });


            $("#MainContent_txtcodcos").change(function () {
                var textdev = Mostrarundato($("#MainContent_txtcodcos").val(), '10').ee;
                if (textdev != "") {
                    $("#MainContent_ddlccost").val(textdev);
                    $("#MainContent_txttra").focus();
                } else {
                    alert("Codigo no existe");
                    $("#MainContent_ddlccost").val("");
                }
            });

            $('input:radio[name=rb]').click(function () {
                miconsulta = ($(this).val() == "C" ? 'getProductoAS' : 'getProducto');
                Operacion.mask('txtproducto').val('');
                Operacion.mask('txtproducto').focus();
            });

            $(".clbtgrabar").click(function () {
                var contarr = 0;
                var gridView = document.getElementById("<%=gvdetalle.ClientID %>");//

                for (var t = 1; t < gridView.rows.length; t++) {
                    var codj = gridView.rows[t].cells[3].value ;
                    var cantidgv =gridView.rows[t].cells[1].innerHTML;
                    var sxgeneral = strockxgenr(codj).ee;
                    if (cantidgv > sxgeneral  ) {
                        gridView.rows[t].style.backgroundColor= "#FF5722";
                        contarr++;
                    }
                    
             }


                //for (var cr = 0; cr < guardanomprod.length ; cr++) {
                    
                //    if (concatenavar == guardanomprod[cr] ) {
                        
                //    }
                //}


                if (contarr > 0) {
                    alert("El producto Marcado ya fue usado por otro usuario");
                }else if ($(".ctxtidsoli").val() == "") {
                    alert("No ha ingresado el solicitante");
                    $(".ctxtidsoli").focus();
                } else if (Operacion.mask("ddlsarea").val() == "") {
                    alert("No ha ingresado el Area");
                    Operacion.mask("ddlsarea").focus();
                //} else if (Operacion.mask("txttcambio").val() == 0) {
                //    alert("Tipo de Cambio no Valido");
                } else if (Operacion.mask("txttcambio").val() == 0 && Operacion.mask("ddlsarea").val()=="5" ) {
                    alert("El tipo de cambio no esta registrado segun fecha- Vefique Fecha");
                } else if (Operacion.mask("ddlalma").val() == "-1") {
                    alert("No ha ingresado el Almacen");
                    Operacion.mask("ddlalma").focus();
                } else if (Operacion.mask("#MainContent_ddltcur").val() == "" && Operacion.mask("#MainContent_ddlsarea").val() =="5" ) {
                    alert("No ha Seleccionado el Trabajo");
                    Operacion.mask("#MainContent_ddltcur").focus()
                } else if ($(".filtrar tr").size() == 2 && $(".filtrar td").eq(0).html() == "") {
                    alert("No ha ingresado ninguna informacion");
                } else {
                    if (sw_guardar == 0) {
                        var codg = UltimoCodigo($("#MainContent_ddltipos").val());
                        $("#MainContent_txtnumdoc").val(codg);
                        sw_guardar = 1;
                    }
                    var ctd_m = "";
                    var desalma = ""; var ALORI = "";
                    //if ($("#MainContent_ddldest").val()=="") {
                    if ($("#MainContent_ddltipos").val() == "SO") {
                        if (($("#MainContent_ddlsarea").val() == "3" || $("#MainContent_ddlsarea").val() == "4") && $("#MainContent_ddldest").val() != "") {
                            ctd_m = "TD";
                            ALORI = Operacion.mask("ddlalma").val();
                        } else {
                            ctd_m = "PR";
                            ALORI = Operacion.mask("ddlalma").val();
                        }
                        desalma = Operacion.mask("ddldest").val();
                    } else {
                        if (($("#MainContent_ddlsarea").val() == "3" || $("#MainContent_ddlsarea").val() == "4") && $("#MainContent_ddldest").val() != "") {
                            ctd_m = "TD";
                            desalma = "0001";
                            ALORI = Operacion.mask("ddldest").val();
                        } else {
                            ctd_m = "PR";
                            desalma = Operacion.mask("ddlalma").val();
                            ALORI = Operacion.mask("ddlalma").val();
                        }

                    }
                  
                    InsertarCabecera(ctd_m, desalma,ALORI);
                }
            });

            $(".clbtnuevo").click(function () {
                $(".ctxtidsoli").val("");
                $(".idart").val("");
                Operacion.mask("txttra").val("");
                Operacion.mask("txtnumdoc").val("");
                //Operacion.mask("txtfecha").val("");
                Operacion.mask("txtund").val("");
                Operacion.mask("txtstock").val("");
                Operacion.mask("txtcant").val("");
                Operacion.mask("txtsoli").val("");
                Operacion.mask("txtidprod").val("");
                Operacion.mask("txtcodcos").val("");
                Operacion.mask("ddlccost").val("");
                $(".ctxtidsoli").focus(); 

                //limpiar gridview
                var lrow = $("[id*=gvdetalle] tr:last-child").clone(true);
                $("[id*=gvdetalle] tr").not($("[id*=gvdetalle] tr:first-child")).remove();
                $("td", lrow).eq(0).html("");
                $("td", lrow).eq(1).html("");
                $("td", lrow).eq(2).html("");
                $("td", lrow).eq(3).html("");
                $("td", lrow).eq(4).html("");
                $("td", lrow).eq(5).html("");
                $("[id*=gvdetalle]").append(lrow);
                lrow = $("[id*=gvdetalle] tr:last-child").clone(true);
                cc = 1;
                sw_guardar = 0;
                contaditem = 0;
            });

            $("#MainContent_ddltcur").change(function () {
                calcular_presupuesto();
            });

            $("#MainContent_ddltipos").change(function () {
                ocultarlote();
            });
            
            $("#MainContent_ddlsarea").change(function () {
                textsuboc = Operacion.mask("ddlsarea").val();
                validamostrarcontrol();
                //$("#MainContent_gvdetalle td:nth-child(4), #MainContent_gvdetalle th:nth-child(4)").hide();


            });


            $(".ctxtidsoli").change(function () {

                var textdev = Mostrarundato($("#MainContent_txtidsoli").val(), '12').ee;
                if (textdev != "") {
                    $("#MainContent_txtsoli").val(textdev);
                    Operacion.mask('txtcodcos').focus();
                } else {
                    $("#MainContent_txtsoli").val("");
                    alert("Codigo no existe");
                    $(".ctxtidsoli").focus();
                }
            });

            $(".clcant").change(function () {

                var stocf = Number(Operacion.mask("txtstock").val()) + Number(Operacion.mask("txtstockg").val());
                var subtini = $(".clcant").val();
                concatenavar = Operacion.mask("txtidprod").val();
                arraygrid();
                cuentarepe = 0;
                for (var cr = 0; cr < guardanomprod.length ; cr++) {
                    if (concatenavar == guardanomprod[cr]) {
                        cuentarepe = Number(cuentarepe) + 1;
                    }
                }

                if (Operacion.mask("txtidprod").val() == "") {
                    alert("No ha ingresado el Producto");
                    Operacion.mask("txtproducto").focus();
                    Operacion.mask("txtcant").val("");
                } else if (Number(Operacion.mask("txtcant").val()) > (stocf)) {
                    alert("No tiene Stock suficiente de Este Producto");
                    Operacion.mask("txtcant").focus();
                    Operacion.mask("txtcant").val("");
                } else if (Number(Operacion.mask("txtcant").val()) == 0) {
                    alert("La cantidad ingresada debe ser mayor a 0");
                    Operacion.mask("txtcant").focus();
                    Operacion.mask("txtcant").val("");
                } else if (Operacion.mask("txtidsoli").val() == "") {
                    alert("No ha ingresado el Solicitante");
                    Operacion.mask("txtcant").val("");
                    Operacion.mask("txtidsoli").focus();
                } else if ((Operacion.mask("ddldest").val() == Operacion.mask("ddlalma").val()) && Operacion.mask("ddltipos").val() =="SO" ) {
                    alert("El almacen No debe ser igual al destino - Cambie Almacen");
                    Operacion.mask("txtcant").val("");
                    Operacion.mask("ddlalma").focus();
                    Operacion.mask("txtproducto").val("");
                } else if ($(".clcant").val() < 0) {
                    alert("La cantida debe ser mayor a 0");
                    Operacion.mask("txtcant").val("");
                    Operacion.mask("txtcant").focus();
                } else if (Operacion.mask("ddlsarea").val() == "") {
                    alert("No ha ingresado el Area");
                    Operacion.mask("txtcant").val("");
                    Operacion.mask("ddlsarea").focus();
                } else if (Operacion.mask("txtproducto").val() == "") {
                    alert("No se ha Registrado Descripcion");
                    Operacion.mask("txtproducto").focus();
                    Operacion.mask("txtcant").val("");
                } else if (Operacion.mask("ddlalma").val() == "-1") {
                    alert("No ha ingresado el Almacen");
                    Operacion.mask("ddlalma").focus();
                    Operacion.mask("txtcant").val("");
                } else if (Operacion.mask("#MainContent_ddltcur").val() == "" && Operacion.mask("#MainContent_ddlsarea").val() == "5") {
                    alert("No ha Seleccionado el Trabajo");
                    Operacion.mask("#MainContent_ddltcur").focus();
                    Operacion.mask("txtcant").val("");
                } else if ((Operacion.mask("ddlsarea").val() == "3" || Operacion.mask("ddlsarea").val() == "4") && $("#MainContent_ddldest :selected").text() == "") {
                    alert("No ha Seleccionado Destino");
                    Operacion.mask("txtcant").val("");
                    Operacion.mask("ddldest").focus();
                } else if (Operacion.mask("txttcambio").val() == "") {
                    alert("El tipo de cambio no esta registrado segun fecha- Vefique Fecha");
                    Operacion.mask("txtcant").val("");
                } else if (Operacion.mask("txtfecha").val() == "") {
                    alert("No ha ingresado la Fecha del Documento");
                    Operacion.mask("txtcant").val("");
                    Operacion.mask("txtfecha").focus();
                } else if (Number($("#MainContent_txtsaldo").val()) < (Number($("#MainContent_txttotal").val()) + Number(subtini)) && $("#MainContent_ddlsarea").val() == "5") {
                    alert("Excede Del Presupuesto");
                    Operacion.mask("txtcant").focus();
                    Operacion.mask("txtcant").val("");
                } else if (cuentarepe > 0) {
                    alert("Producto ya fue Agregado");
                    Operacion.mask("txtcant").focus();
                    Operacion.mask("txtcant").val(""); 
                } else {

                    var rowt = $("[id*=gvdetalle] tr:last-child").clone(true);
                    if (cc == 1) {
                        $("[id*=gvdetalle] tr").not($("[id*=gvdetalle] tr:first-child")).remove();
                        cc = 2;
                    }
                    
                    contaditem = contaditem + 1;
                    var nitem = (contaditem);
                    $("td", rowt).eq(0).html(nitem);
                    var cantf = $(".clcant").val();
                    $("td", rowt).eq(1).html(Number(cantf).toFixed(2));
                    $("td", rowt).eq(2).html($("#MainContent_txtund").val());
                    $("td", rowt).eq(3).html($("#MainContent_hfproducto").val());
                    $("td", rowt).eq(3).val($("#MainContent_txtidprod").val());
                    $("td", rowt).eq(4).val($("#MainContent_ddlalma").val());
                    var precus = calculo_MNUS(Operacion.mask("txtmone").val(), $("#MainContent_txtprecio").val()).montous;
                    var precmn = calculo_MNUS(Operacion.mask("txtmone").val(), $("#MainContent_txtprecio").val()).montomn;
                    var prmost = Operacion.mask("txtmoneda").val() == "MN" ? precmn : precus;
                    var mtomostrar = prmost.toFixed(4) * Number($("#MainContent_txtcant").val()).toFixed(4);
                    $("td", rowt).eq(4).html(prmost.toFixed(4));
                    $("td", rowt).eq(2).val($("#MainContent_txtmone").val());
                    var calcula_sunt = Number($("#MainContent_txtprecio").val()) * Number($("#MainContent_txtcant").val());
                    var cntMN = calculo_MNUS($("#MainContent_txtmone").val(), calcula_sunt).montomn;
                    var cntUS = calculo_MNUS($("#MainContent_txtmone").val(), calcula_sunt).montous;
                    DS_SUMAT = Number(DS_SUMAT.toFixed(4)) + Number(mtomostrar.toFixed(4));
                    Operacion.mask("txttotal").val(DS_SUMAT.toFixed(4));
                    $("td", rowt).eq(5).html(mtomostrar.toFixed(4));
                    //calculo de moneda
                    $("td", rowt).eq(5).val(cntMN.toFixed(4));
                    $("td", rowt).eq(6).val(cntUS.toFixed(4));
                    //sumatoria de soles y dolares
                    DS_SUMATMN = Number(DS_SUMATMN.toFixed(4)) + Number(cntMN.toFixed(4));
                    DS_SUMATUS = Number(DS_SUMATUS.toFixed(4)) + Number(cntUS.toFixed(4));

                    var sant = Operacion.mask("txtsaldo").val();
                    var sact = Number(sant).toFixed(4) - Number(mtomostrar.toFixed(4));
                    Operacion.mask("txtsaldo").val(sact.toFixed(4));

                    


                    $("[id*=gvdetalle]").append(rowt);
                    rowt = $("[id*=gvdetalle] tr:last-child").clone(true);

                    $(".clbtgrabar").attr("disabled", false);
                    $(".idart").val("");
                    $(".clcant").val("");
                    Operacion.mask("txtstock").val("");
                    Operacion.mask("txtstockg").val("");
                    Operacion.mask("txtund").val("");
                    Operacion.mask("txtidprod").val("");
                    Operacion.mask("txtprecio").val("");
                    Operacion.mask("txtmone").val("");
                    $(".idart").focus();
                }

            });

            $(".btelimina").click(function () {
                var trp = $(this).parent().parent();
                var itemde = $("td:eq(0)", trp).html();
                var montt = $("td:eq(5)", trp).html();
                var monttmn = $("td:eq(5)", trp).val();
                var monttus = $("td:eq(6)", trp).val();
                var nfila = $(".filtrar tr").size() - 1;
                if (nfila == 1) {
                    var sant = Operacion.mask("txtsaldo").val();
                    var sact = Number(sant) + Number(montt);
                    Operacion.mask("txtsaldo").val(sact.toFixed(4));

                    $("td", trp).eq(0).html("");
                    $("td", trp).eq(1).html("");
                    $("td", trp).eq(2).html("");
                    $("td", trp).eq(3).html("");
                    $("td", trp).eq(3).val("");
                    $("td", trp).eq(4).val("");
                    $("td", trp).eq(4).html("");
                    $("td", trp).eq(5).html("");
                    $("td", trp).eq(5).val("");

                    contaditem = 0;
                    cc = 1;
                    DS_SUMAT = 0;
                    DS_SUMATMN = 0;
                    DS_SUMATMN = 0;
                    Operacion.mask("txttotal").val(DS_SUMAT);
                } else {
                    if (Operacion.mask("ddlsarea").val() == "5") {
                        DS_SUMAT = Number(DS_SUMAT.toFixed(4)) - Number(montt.toFixed(4));
                        DS_SUMATMN = Number(DS_SUMATMN.toFixed(4)) - Number(monttmn.toFixed(4));
                        DS_SUMATUS = Number(DS_SUMATUS.toFixed(4)) - Number(monttus.toFixed(4));
                        Operacion.mask("txttotal").val(DS_SUMAT.toFixed(4));
                    }

                    
                    trp.remove();
                }
            });

        });

    </script>

    <style type="text/css">
        #btbuscaplan {
            height: 27px;
            width: 126px;
        }

        #btlimpiaplan {
            height: 26px;
            width: 118px;
        }

        .btbuscaplan {
            width: 152px;
            height: 30px;
        }

        .btlimpiaplan {
            width: 179px;
            height: 29px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:HiddenField runat="server" ID="hffactual" />
    <asp:HiddenField runat="server" ID="hfusu" />
    <asp:HiddenField runat="server" ID="hfaccede" />
    <div id="contenedor">
        <fieldset>
            <legend>SOLICITUD DE MATERIALES</legend>
            <%--<table>
                <tr>
                    <td>
                         <asp:Menu
        ID="Menu1"
        Width="668px"
        runat="server"
        Orientation="Horizontal"
        StaticEnableDefaultPopOutImage="False"
        OnMenuItemClick="Menu1_MenuItemClick">
    <Items>
        <asp:MenuItem ImageUrl="~/Images/item-pointer.gif" 
                      Text="Datos Generales" Value="0"></asp:MenuItem>
        <asp:MenuItem ImageUrl="~/Images/item-pointer.gif" 
                      Text="Datos Venta" Value="1"></asp:MenuItem>
        <asp:MenuItem ImageUrl="~/Images/item-pointer.gif" 
                      Text="Datos Compra" Value="2"></asp:MenuItem>
    </Items>
</asp:Menu>
                    </td>
                </tr>
            </table>--%>
            <table>
                <tr>
                    <td>N° Solicitud</td>
                    <td colspan="3">
                        <asp:TextBox runat="server" Width="100" Enabled="false" ID="txtnumdoc" BackColor="#ffffcc"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>Tipo</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddltipos"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Solicitante</td>
                    <td colspan="6">
                        <asp:TextBox ID="txtidsoli" class="ctxtidsoli" runat="server" Width="100" placeholder="CODIGO"></asp:TextBox>
                        <asp:TextBox ID="txtsoli" runat="server" Width="300" placeholder="SOLICITANTE" TabIndex="2" onkeydown="Operacion.MEKPAT(event,this);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>C. Costo</td>
                    <td colspan="6">
                        <asp:TextBox runat="server" ID="txtcodcos" Width="100" placeholder="CODIGO" TabIndex="3"></asp:TextBox>
                        <asp:TextBox runat="server" ID="ddlccost" Width="300" placeholder="DESCRIPCION" TabIndex="4" onkeydown="ModifyEnterKeyPressAsTab(event,this);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Trabajo</td>
                    <td colspan="6">
                        <asp:TextBox ID="txttra" runat="server" placeholder="TRABAJO" Width="402" TabIndex="5" onkeydown="Operacion.MEKPAT(event,this);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Fecha</td>
                    <td colspan="3">
                        <asp:TextBox ID="txtfecha" runat="server" class="tcamb" placeholder="00/00/0000" Width="100" TabIndex="6" onkeydown="Operacion.MEKPAT(event,this);"></asp:TextBox>
                        <asp:TextBox ID="txttcambio" runat="server" Width="55" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Area</td>
                    <td colspan="3">
                        <asp:DropDownList runat="server" ID="ddlsarea" Width="210" TabIndex="7" onkeydown="Operacion.MEKPAT(event,this);"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label Text="Destino:" runat="server" ID="lbdest" />
                    </td>
                    <td colspan="3">
                        <asp:DropDownList runat="server" Width="105" ID="ddldest"></asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label Text="Trab. Curso" runat="server" ID="lbtcurso" />
                    </td>
                    <td colspan="3">
                        <asp:DropDownList runat="server" Width="210" ID="ddltcur" TabIndex="8" onkeydown="Operacion.MEKPAT(event,this);"></asp:DropDownList>
                    </td>
                    <td colspan="3">
                        <asp:TextBox runat="server" Width="82" ID="txtcur" Enabled="false" Style="text-align: right" />
                        <asp:TextBox runat="server" ID="txtmoneda" Width="35" Enabled="false" Text="MN" />
                    </td>
                    <td></td>

                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Toleranc. %" ID="lbtole" runat="server" />
                    </td>
                    <td colspan="1">
                        <asp:TextBox runat="server" ID="txtxactual" Width="50" Enabled="false" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtactual" Width="80" Enabled="false" Style="text-align: right" />
                    </td>
                    <td>
                        <asp:Label Text="Acumulado" runat="server" ID="lbacumulado" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtacumulado" Width="80" Enabled="false" Style="text-align: right" />
                    </td>
                    <td>
                        <asp:Label Text="Saldo" runat="server" ID="lbsaldo" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtsaldo" Width="100" Enabled="false" Style="text-align: right" />
                    </td>
                </tr>

            </table>
            <fieldset>
                <table>
                    <tr>
                        <td>Almacen:</td>
                        <td>
                            <asp:DropDownList runat="server" Width="350" ID="ddlalma" TabIndex="9" onkeydown="Operacion.MEKPAT(event,this);" /></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:TextBox runat="server" Width="200" Enabled="false" ID="txtidprod"></asp:TextBox>
                        </td>
                        <td></td>
                        <td style="text-align: center"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">&nbsp;</td>
                        <td colspan="2">Filtrar por :&nbsp;
                        <input id="rb1" type="radio" name="rb" value="C" />Codigo
                        <input id="rb2" type="radio" name="rb" value="D" checked="checked" />
                            Descripción
                        </td>
                        <td>Stock Solicit.</td>
                        <td>Stock General</td>
                    </tr>
                    <tr>
                        <td>Producto:</td>
                        <td>
                            <asp:TextBox runat="server" ID="txtproducto" class="idart" Width="350" TabIndex="10" onkeydown="Operacion.MEKPAT(event,this);" />
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtund" Enabled="false" Width="40"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtstock" Enabled="false" Width="90" placeholder="Stock" Style="text-align: right"></asp:TextBox></td>
                        <td>
                            <asp:TextBox runat="server" ID="txtstockg" Enabled="false" Width="90" placeholder="Stock" Style="text-align: right"></asp:TextBox>
                        </td>
                        <td>
                            <asp:HiddenField ID="hfproducto" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label Text="Lote" runat="server" ID="lblote" ></asp:label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" Width="100" ID="txtlote" />
                    
                            <asp:TextBox runat="server" Width="100" ID="txtflote" Enabled="false" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label Text="Precio" ID="lbprec" runat="server" />
                        </td>
                        <td colspan="2">
                            <asp:TextBox runat="server" ID="txtprecio" Width="100" Enabled="false" Style="text-align: right" />
                            <asp:TextBox runat="server" ID="txtmone" Width="25" Enabled="false" Style="text-align: center" />
                        </td>
                    </tr>
                    <tr>
                        <td>Cantidad</td>
                        <td colspan="2">
                            <asp:TextBox ID="txtcant" runat="server" class="clcant" TabIndex="11"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <table>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="gvdetalle" class="filtrar" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" Width="709px">
                            <Columns>
                                <asp:BoundField DataField="SA_ITEM" HeaderText="ITM" ItemStyle-Width="2" />
                                <asp:BoundField DataField="SA_ID" HeaderText="CANTIDAD" ItemStyle-Width="10" ItemStyle-BackColor="#ffffcc" ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField DataField="SA_DESC" HeaderText="UNIDAD" ItemStyle-Width="10" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="SA_NAPROB" HeaderText="MATERIAL" ItemStyle-Width="400" />
                                <asp:BoundField DataField="SA_PRECIO" HeaderText="PRECIO" ItemStyle-Width="70" ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField DataField="SA_SUBTOT" HeaderText="TOTAL" ItemStyle-Width="80" ItemStyle-HorizontalAlign="Right" />

                                <asp:TemplateField HeaderText="ELI">
                                    <ItemTemplate>
                                        <div class="btelimina" style="text-align: center">
                                            <img alt="" src="../../Images/desaprob.png" width="20" style="cursor: pointer" />
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="false" ForeColor="White" Height="25" />
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
                    <td>Total:
                             <asp:TextBox runat="server" ID="txttotal" Enabled="false" Width="100" Style="text-align: right" />
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <%--<asp:Button class="btn" Text="Nuevo" runat="server" ID="btnuevo" Enabled="true" ></asp:Button>--%>
                        <input runat="server" type="button" class="clbtnuevo btn" value="Nuevo" id="btnuevo" />
                    </td>
                    <td>
                        <%-- <asp:Button class="btn" Text="Grabar" runat="server" ID="btgrabar" Enabled="false" OnClick="btgrabar_Click" UseSubmitBehavior="false"></asp:Button>--%>
                        <input runat="server" type="button" class="clbtgrabar btn" id="btgrabar" value="Guardar" disabled="disabled" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>



</asp:Content>

