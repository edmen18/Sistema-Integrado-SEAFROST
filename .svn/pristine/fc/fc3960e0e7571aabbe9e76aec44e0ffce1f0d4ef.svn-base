<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="TrabajosCurso.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
      
    <script type="text/javascript">
        $(function () {
            $("#MainContent_txtfecha").datepicker();
            $("#MainContent_txtfechainicio").datepicker();
            $("#MainContent_txtfechafin").datepicker();
            $("#MainContent_txtfecha1").datepicker();
            $("#MainContent_txtfecha2").datepicker();

            $("#MainContent_txtcencosto").autocomplete(
                       {
                           source: function (request, response) {

                               $.ajax({
                                   url: "TrabajosCurso.aspx/GETVARIOS",
                                   data: "{ 'CLAVE': '" + request.term + "' ,  'INDICADOR': '10' }",
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
                           },
                           minLength: 1,
                           select: function (event, ui) {
                               var str = ui.item.id;
                               var cadena = str
                               posicionEspacio = cadena.indexOf("@"), //Obtengo la posición del espacio en la cadena
                               primerApellido = cadena.substring(0, posicionEspacio) //Obtengo la porción deseada de la cadena
                               enMinuscula = primerApellido.toLowerCase(); //Convierto el apellido a minúscula

                               primerApellido = cadena.substring(posicionEspacio + 1, str.length)
                               $('#MainContent_txtcodcencosto').val(str);


                           }
                       });

            $("#MainContent_txtcencosto0").autocomplete(
                     {
                         source: function (request, response) {

                             $.ajax({
                                 url: "TrabajosCurso.aspx/GETVARIOS",
                                 data: "{ 'CLAVE': '" + request.term + "' ,  'INDICADOR': '10' }",
                                 dataType: "json",
                                 type: "POST",
                                 contentType: "application/json; charset=utf-8",
                                 dataFilter: function (data) { return data; },
                                 success: function (data) {
                                     response($.map(data.d, function (item) {
                                         return {
                                             value: item.TG_CDESCRI + " - " + item.TG_CCLAVE,
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
                             $('#MainContent_txtcodcencosto0').val(str);


                         }
                     });
            $("#MainContent_txtdocumento").autocomplete(
          {
              source: function (request, response) {

                  if ($("#MainContent_ddltipodoc").val().trim() == "1") {
                      var reques = {};
                      reques.OC_CNUMORD = $("#MainContent_txtdocumento").val();
                      reques.OC_CCODMON = $("#MainContent_ddlmoneda").val();

                      $.ajax({
                          url: "TrabajosCurso.aspx/getordenes",
                          data: '{ productos: ' + JSON.stringify(reques) + ' }',
                          dataType: "json",
                          type: "POST",
                          contentType: "application/json; charset=utf-8",
                          dataFilter: function (data) { return data; },
                          success: function (data) {
                              response($.map(data.d, function (item) {
                                  return {
                                      value: item.OC_CNUMORD,
                                      id: item.OC_NIMPMN,

                                  }
                              }))
                          },
                          error: function (XMLHttpRequest, textStatus, errorThrown) {
                              //alert(textStatus);
                          }
                      });
                  }


                  if ($("#MainContent_ddltipodoc").val().trim() == "2") {
                      var reques = {};
                      reques.RC_CNROREQ = $("#MainContent_txtdocumento").val();
                      reques.RC_CCODMON = $("#MainContent_ddlmoneda").val();
                                           
                      $.ajax({
                          url: "TrabajosCurso.aspx/getreque",
                          data: '{ reques: ' + JSON.stringify(reques) + ' }',
                          dataType: "json",
                          type: "POST",
                          contentType: "application/json; charset=utf-8",
                          dataFilter: function (data) { return data; },
                          success: function (data) {
                              response($.map(data.d, function (item) {
                                  return {
                                      value: item.RC_CNROREQ,
                                      id: item.RC_NIMPMN,
                                     
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
                  //posicionEspacio = cadena.indexOf("@"), //Obtengo la posición del espacio en la cadena
                  //primerApellido = cadena.substring(0, posicionEspacio) //Obtengo la porción deseada de la cadena
                  //enMinuscula = primerApellido.toLowerCase(); //Convierto el apellido a minúscula

                  //primerApellido = cadena.substring(posicionEspacio + 1, str.length)
                  $('#MainContent_txtmonto').val(str);

              }

          });

           

            $("#MainContent_txtcontratista").autocomplete(
         {
             source: function (request, response) {
                 $.ajax({
                     url: "TrabajosCurso.aspx/GetProveedores",
                     //  data: "{ 'productos': '" + request.term + "' }",
                     data: "{ 'productos': '" + "%" + request.term + "%" + "' }",
                     dataType: "json",
                     type: "POST",
                     contentType: "application/json; charset=utf-8",
                     dataFilter: function (data) { return data; },
                     success: function (data) {
                         response($.map(data.d, function (item) {
                             return {
                                 value: item.ACODANE + "-" + item.ADESANE,
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
                
                 $('#MainContent_txtcodcontratista').val(str);


             }
         });


            function filtardetalle1() {

                var VC = {};
                VC.TR_CODIGO = $("#MainContent_lblsolicitud").html();
                $.ajax({
                    type: "POST",
                    url: "TrabajosCurso.aspx/ListarDetalleFACCAR",
                    data: '{VC: ' + JSON.stringify(VC) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        if (data.d.length > 0) {
                            var row = $("[id*=GridView1] tr:last-child").clone(true);
                            $("[id*=GridView1] tr").not($("[id*=GridView1] tr:first-child")).remove();

                            for (var i = 0; i < data.d.length; i++) {

                                $("td", row).eq(0).html(data.d[i].CODIGO);
                                $("td", row).eq(1).html(data.d[i].DOCUMENTO);
                                $("td", row).eq(2).html(moment(data.d[i].FECHA).format("DD/MM/YYYY"));
                                $("td", row).eq(3).html(data.d[i].MONEDA);
                                $("td", row).eq(4).html(formato_numero(data.d[i].MONTO, 2, ".", ","));
                                cc = 2;
                                $("[id*=GridView1]").append(row);
                                row = $("[id*=GridView1] tr:last-child").clone(true);
                            }
                            recorregridaux();
                            recorregridaux1();

                        } else {
                            var row = $("[id*=GridView1] tr:last-child").clone(true);
                            $("[id*=GridView1] tr").not($("[id*=GridView1] tr:first-child")).remove();

                            $("td", row).eq(0).val("");
                            $("td", row).eq(1).html("");
                            $("td", row).eq(2).html("");
                            $("td", row).eq(3).html("");
                            $("td", row).eq(4).html("");

                            $("[id*=GridView1]").append(row);
                          //  alert("no se encontro registro");
                        }
                    },
                    error: function (response) {
                        if (response.length != 0)
                            alert(response);
                    }
                });

            }
            function filtardetalleAcum() {

                var VC = {};
                VC.TR_CODIGO = $("#MainContent_lblsolicitud").html();
                VC.COD_MON = $("#MainContent_ddlmoneda").val();
                $.ajax({
                    type: "POST",
                    url: "TrabajosCurso.aspx/ListarDetalleAcum",
                    data: '{VC: ' + JSON.stringify(VC) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        if (data.d.length > 0) {
                            var row = $("[id*=GridView2] tr:last-child").clone(true);
                            $("[id*=GridView2] tr").not($("[id*=GridView2] tr:first-child")).remove();

                            for (var i = 0; i < data.d.length; i++) {

                                $("td", row).eq(0).html(data.d[i].CODIGO);
                                $("td", row).eq(1).html(data.d[i].DOCUMENTO);
                                $("td", row).eq(2).html(moment(data.d[i].FECHA).format("DD/MM/YYYY"));
                                $("td", row).eq(3).html(formato_numero(data.d[i].MONTOMN, 2, ".", ","));
                             
                                $("td", row).eq(4).html(formato_numero(data.d[i].MONTOUS, 2, ".", ","));
                                cc = 2;
                                $("[id*=GridView2]").append(row);
                                row = $("[id*=GridView2] tr:last-child").clone(true);
                            }
                            recorregridaux();
                            recorregridaux1();

                        } else {
                            var row = $("[id*=GridView2] tr:last-child").clone(true);
                            $("[id*=GridView2] tr").not($("[id*=GridView2] tr:first-child")).remove();

                            $("td", row).eq(0).html("");
                            $("td", row).eq(1).html("");
                            $("td", row).eq(2).html("");
                            $("td", row).eq(3).html("");
                            $("td", row).eq(4).html("");

                            $("[id*=GridView2]").append(row);
                            //  alert("no se encontro registro");
                        }
                    },
                    error: function (response) {
                        if (response.length != 0)
                            alert(response);
                    }
                });

            }

            $(window).load(function () {
                contarndw = 0;
                cc = 1;
                sw_edicion = 0;
                sw_nuevo = 0;
                contaditem = 0;

            });

            $('#dvdetalle').dialog({
                autoOpen: false,
                modal: true,
                resizable: true,
                width: 1030,
                heigth: 100,
                title: 'Registro',
                close: function (event, ui) {
                    contarndw = 0;
                    contaditem = 0
                    cc = 1;
                    limpiardatos();
                                   
                    //filtarsolicitudes();
                },

            });

            $('#EstadoPedido').dialog({
                autoOpen: false,
                modal: true,
                resizable: true,
                width: 550,
                heigth: 100,
                title: 'Ver Detalle Documento',
                close: function (event, ui) {
                                  },

            });
            $('#detsolicitud').dialog({
                autoOpen: false,
                modal: true,
                resizable: true,
                width: 550,
                heigth: 100,
                title: 'Ver Detalle Solicitud',
                close: function (event, ui) {
                },

            });
            function limpiardatos() {

                $("#MainContent_txtindicador").val("");
                $("#MainContent_txtcontratista").val("");
                $("#MainContent_txtdescripcion").val("");
                $("#MainContent_txtpresupuesto").val("0.00");
                $("#MainContent_txtadicional").val("0.00");
                $("#MainContent_txtobservaciones").val("");
                $("#MainContent_lblsolicitud").html("");
                $("#MainContent_txtfecha").val("");
                $("#MainContent_txtestado").val("");
                $("#MainContent_txtcodcontratista").val("");
                $("#MainContent_txtmonto").val("0.00");
                $("#MainContent_lbltotalacumulado").html("0.00");
                $("#MainContent_lblacumulado").html("0.00");
                $("#MainContent_txtcodcencosto").val("");
                $("#MainContent_txtcencosto").val("");
                $("#MainContent_txtvalidacion").val("")
            }

            $(".btadd").click(function () { //  se debe colocar dentrp de una funcion 
                $("#dvdetalle").dialog('open');
                var row = $("[id*=GridView1] tr:last-child").clone(true);
                $("[id*=GridView1] tr").not($("[id*=GridView1] tr:first-child")).remove();

                $("td", row).eq(0).val("");
                $("td", row).eq(0).html("");
                $("td", row).eq(1).html("");
                $("td", row).eq(1).val("");
                $("td", row).eq(2).html("");

                $("[id*=GridView1]").append(row);

                $("#MainContent_txtindicador").val("G");
                var fecemi = moment().format("DD/MM/YYYY");
               

                $("#MainContent_lblsolicitud").html("");
                $("#MainContent_txtcontratista").val("");
                $("#MainContent_txtdescripcion").val("");
                $("#MainContent_txtacumulado").val("");
                $("#MainContent_txtcontrolact").val("");
                $("#MainContent_txtobservaciones").val("");
                $("#MainContent_txtfecha").val(fecemi);
                $("#MainContent_txtfechainicio").val(fecemi);
                $("#MainContent_txtfechafin").val(fecemi);
                $("#MainContent_txtnavance").val("");
                $("#MainContent_txtpresupuesto").val("");
                $("#MainContent_txtestado").val("E");
                document.getElementById("btngrabar").style.visibility = "visible";

                var ultimodato = generar().contador;
                var formato = ultimodato.length < 8 ? pad("0" + ultimodato, 8) : ultimodato;
                $("#MainContent_lblsolicitud").html("TR" + formato);
                porcentaje();
               


            });
           
            $(".btvalidar").click(function () {
                if ($("#MainContent_txtvalidacion").val() == "F") {

                    if ($("#MainContent_lblacceso").html() != "0") {
                       
                        var DETA = {};
                        DETA.TR_CODIGO = $("#MainContent_lblsolicitud").html();
                        DETA.VALIDACION = "V";
                        $.ajax({

                            type: "POST",
                            url: "TrabajosCurso.aspx/valida",
                            data: '{DETA: ' + JSON.stringify(DETA) + '}',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            async: false,
                            success: function (response) {
                                alert("Registro Validado");

                            },
                            error: function (response) {
                                if (response.length != 0)
                                    //alert(response);
                                    console.table(response);
                            }

                        });
                    }
                    else {
                        alert("Ud no tiene permisos para realizar esta operación");
                    }
                   
                }
                else {
                    alert("El trabajo en curso ya fue validado");

                }

            });

            $(".btgrabar").click(function () { //  se debe colocar dentrp de una funcion 
                var total = Number($("#MainContent_txtpresupuesto").val()) * (Number($("#MainContent_txtadicional").val()) / 100);
               
                    if ($("#MainContent_txtindicador").val() == "G") {
                        TipoCambio();
                        if (Number(($("#MainContent_lbltipocambio").html()) != 0))
                        {                       
                     InsertarSolicitud();
                     if (Number($("#MainContent_txtmaximo").val()) < 100) {
                         iNSERTAdETALLE();
                     }

                     $("#dvdetalle").dialog('close');
                        }
                        else {
                            alert("No es posible grabar el trabajo en curso pendiente, el tipo de cambio de la fecha seleccionada no ha sido ingresado");
                        }
                }
                 if ($("#MainContent_txtindicador").val() == "A") {

                    if ($("#MainContent_txtestado").val() == "A") {
                        alert("No es posible modificar ya que el trabajo en curso se encuentra APROBADO");
                    }
                    else {
                        InsertarSolicitud();
                    }
                   $("#dvdetalle").dialog('close');
                }
                 location.reload();

              //  document.getElementById("<%=btnbuscar.ClientID%>").click();

            });


            $(".btdetalle").click(function () { //  se debe colocar dentrp de una funcion 
                filtardetalle1();
                filtardetalleAcum();

                            });

            function pad(str, max) {
                if (str != undefined) {
                    str = str.toString();
                    return str.length < max ? pad("0" + str, max) : str;
                }
            }

            function InsertarSolicitud() {
                //PARA EXTRAER EL CONTRATISTA
                var completo = $("#MainContent_txtcontratista").val();
                var str = completo.substring(0, 19);
                var rescontratista = completo.replace(str, "");
                
                //PARA EXTRAER CENTRO DE COSTO
                var completoCC = $("#MainContent_txtcencosto").val();
                var strCC = completoCC.substring(0, 8);
                var CENCOSTO = completoCC.replace(strCC, "");
                //alert(CENCOSTO);

                var fecemi = moment($("#MainContent_txtfecha").val(), "DD/MM/YYYY");
                var fecini = moment($("#MainContent_txtfechainicio").val(), "DD/MM/YYYY");
                var fecfin = moment($("#MainContent_txtfechafin").val(), "DD/MM/YYYY");

                fecemi = fecemi == null ? null : new Date(fecemi);
                fecini = fecemi == null ? null : new Date(fecini);
                fecfin = fecfin == null ? null : new Date(fecfin);

                var DETA = {};
                DETA.AE_COD = $("#MainContent_ddlare").val();
                DETA.EQ_CODIGO = $("#MainContent_ddlequip").val();
                DETA.PL_CODIGO = $("#MainContent_ddlplant").val();
                DETA.FECHA = fecemi;
                DETA.FECHA_INICIO = fecini;
                DETA.FECHA_FIN = fecfin;
                DETA.CONTRATISTA = rescontratista;
                DETA.COD_CONTRATISTA = $("#MainContent_txtcodcontratista").val();
                DETA.COD_CENCOS = $("#MainContent_txtcodcencosto").val();
                DETA.CENTRO_COSTO = CENCOSTO;
                DETA.DESCRIPCION = $("#MainContent_txtdescripcion").val();
                DETA.CONTROL_ACTIVOS = $("#MainContent_ddlcontrolactivos option:selected").text();
                DETA.COD_MON = $("#MainContent_ddlmoneda").val();
                DETA.MONEDA = $("#MainContent_ddlmoneda option:selected").text();
                DETA.OBSERVACIONES = $("#MainContent_txtobservaciones").val();
                $("#MainContent_txtpresupuesto").val(Number($("#MainContent_txtpresequipo").val()) + Number($("#MainContent_txtpresmaterial").val()) + Number($("#MainContent_txtmanobra").val()));
                $("#MainContent_lbltotal").html((Number($("#MainContent_txtpresupuesto").val()) * (Number($("#MainContent_txtadicional").val()) / 100)) + Number($("#MainContent_txtpresupuesto").val()));
                DETA.PRESUPUESTO = $("#MainContent_txtpresupuesto").val();
                DETA.PRES_EQUIPOS = $("#MainContent_txtpresequipo").val();
                DETA.PRES_MATERIAL = $("#MainContent_txtpresmaterial").val();
                DETA.PRES_MANOBRA = $("#MainContent_txtmanobra").val();
                DETA.ESTADO ="E";
                DETA.USU1 = "";
                DETA.USU2 = "";
                DETA.USU3 = "";
                DETA.TR_CODIGO = $("#MainContent_lblsolicitud").html();
                DETA.PORC_ADICIONAL = $("#MainContent_txtadicional").val();
                DETA.TIPO_CAMBIO = $("#MainContent_lbltipocambio").html();
                DETA.COD_TIPO = $("#MainContent_ddltipo").val();
                
                if ((DETA.AE_COD.trim() == "") || (DETA.EQ_CODIGO.trim() == "") || (DETA.PL_CODIGO.trim() == "") || (DETA.CENTRO_COSTO.trim() == "") || (DETA.DESCRIPCION == "") || (DETA.PRESUPUESTO.trim() == "")) {
                    alert("Complete los Datos antes de continuar");
                 }
                else {

                    if ($("#MainContent_txtindicador").val() == "G") {
                        DETA.PI_INICIAL = $("#MainContent_txtpresupuesto").val();
                        DETA.PI_EQUIPOS = $("#MainContent_txtpresequipo").val();
                        DETA.PI_MATERIALES = $("#MainContent_txtpresmaterial").val();
                        DETA.PI_MANOBRA = $("#MainContent_txtmanobra").val();
                        DETA.PORC_INICIAL = $("#MainContent_txtadicional").val();
                        DETA.VALIDACION = "F";
                        DETA.FINALIZADO = "N";
                        
                      $.ajax({

                            type: "POST",
                            url: "TrabajosCurso.aspx/InsertaDet",
                            data: '{DETA: ' + JSON.stringify(DETA) + '}',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            async: false,
                            success: function (response) {
                                alert("Registro Grabado");
                               
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
                            url: "TrabajosCurso.aspx/ActualizaAnticipo",
                            data: '{DETA: ' + JSON.stringify(DETA) + '}',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            async: false,
                            success: function (response) {
                                alert("Registro Actualizado");
                               
                                    },
                            error: function (response) {
                                if (response.length != 0)
                                   console.table(response);
                            }

                        });
                    }

                  //  filtarsolicitudes()
                }

            }
             function iNSERTAdETALLE() {
              var DETAIL = {};
              var gridView = document.getElementById("<%=GridView1.ClientID %>");
              for (var t = 1; t < gridView.rows.length; t++)
              {
                  var inputs = gridView.rows[t].getElementsByTagName('input');                 
                  if (gridView.rows[t].cells[1].innerHTML == "REQUERIMIENTO") {
                      DETAIL.COD_TIPO = "2";
                  }
                  else {
                      DETAIL.COD_TIPO = "1";
                  }
                 
                  DETAIL.NUM_DOC = gridView.rows[t].cells[0].innerHTML;
                  DETAIL.TR_CODIGO = $("#MainContent_lblsolicitud").html();
                  DETAIL.MONTO = gridView.rows[t].cells[4].innerHTML;


              $.ajax({

                  type: "POST",
                  url: "TrabajosCurso.aspx/InsertaDetalle",
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

            function ParaEliminar() {

                var VC = {};
                VC.TR_CODIGO = $("#MainContent_lblsolicitud").html();
                $.ajax({
                    type: "POST",
                    url: "TrabajosCurso.aspx/ListarDetalle",
                    data: '{VC: ' + JSON.stringify(VC) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {

                        if (data.d.length > 0) {

                            for (var i = 0; i < data.d.length; i++) {
                                eliminardetalle(data.d[i].CODIGO);
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

            function eliminardetalle(codigo) {
                var DETA = {};
                DETA.CODIGO = codigo;
                $.ajax({

                    type: "POST",
                    url: "TrabajosCurso.aspx/deleteDet",
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

            function generar() {
                var solicitud = "";
                var contador = "";

                $.ajax({

                    type: "POST",
                    url: "TrabajosCurso.aspx/GENERAR",
                    data: '',
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

           
            $(".calcular").click(function () {
            $("#MainContent_txtpresupuesto").val(Number($("#MainContent_txtpresequipo").val()) + Number($("#MainContent_txtpresmaterial").val()) + Number($("#MainContent_txtmanobra").val()));
            $("#MainContent_lbltotal").html((Number($("#MainContent_txtpresupuesto").val()) * (Number($("#MainContent_txtadicional").val()) / 100)) + Number($("#MainContent_txtpresupuesto").val()));
            });

            function validaredicion() {
                   contarndw = 0;
                   var gridView = document.getElementById("<%=GridView1.ClientID %>");

            for (var t = 1; t < gridView.rows.length; t++) {
                var inputs = gridView.rows[t].getElementsByTagName('input');
                if (gridView.rows[t].cells[0].innerHTML == $("#MainContent_txtaux1").val() && gridView.rows[t].cells[1].value == $("#MainContent_txtaux2").val())
                {
                    gridView.rows[t].cells[0].innerHTML = $("#MainContent_txtdocumento").val();
                    gridView.rows[t].cells[1].innerHTML = $("#MainContent_ddltipodoc option:selected").text();
                    gridView.rows[t].cells[1].val = $("#MainContent_ddltipodoc").val();
                    gridView.rows[t].cells[2].val = $("#MainContent_txtmonto").val();
                }               
              }

            return {
               
            };
        }
              
            // para visualizar
            $(".VISUALIZARSOLICITUD").click(function () {

                $("#detsolicitud").dialog('open');
                trp = $(this).parent().parent();
                id = $("td:eq(0)", trp).html();
               
                var VC = {};
                VC.DS_IDSOLIC = id;
                URL = "TrabajosCurso.aspx/LISTARDETSOLICITUD";
               


                $.ajax({
                    type: "POST",
                    url: URL,
                    data: '{VC: ' + JSON.stringify(VC) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        if (data.d.length > 0) {
                            var row = $("[id*=GridView4] tr:last-child").clone(true);
                            $("[id*=GridView4] tr").not($("[id*=GridView4] tr:first-child")).remove();

                            for (var i = 0; i < data.d.length; i++) {

                                $("td", row).eq(0).html(data.d[i].ITEM);
                                $("td", row).eq(1).html(data.d[i].DESCRIPCION);
                                $("td", row).eq(2).html(data.d[i].UNIDAD);
                                $("td", row).eq(3).html(data.d[i].CANTIDAD);
                                $("td", row).eq(4).html(formato_numero(data.d[i].PRECIOSOLES, 2, ".", ","));
                                $("td", row).eq(5).html(formato_numero(data.d[i].TOTALD, 2, ".", ","));
                                $("td", row).eq(6).html(formato_numero(data.d[i].TOTALS, 2, ".", ","));

                                $("[id*=GridView4]").append(row);
                                row = $("[id*=GridView4] tr:last-child").clone(true);
                            }
                            recorregridaux();
                            recorregridaux1();

                        } else {
                            var row = $("[id*=GridView4] tr:last-child").clone(true);
                            $("[id*=GridView4] tr").not($("[id*=GridView4] tr:first-child")).remove();

                            $("td", row).eq(0).html("");
                            $("td", row).eq(1).html("");
                            $("td", row).eq(2).html("");
                            $("td", row).eq(3).html("");
                            $("td", row).eq(4).html("");
                            $("td", row).eq(5).html("");
                            $("td", row).eq(6).html("");
                          

                            $("[id*=GridView4]").append(row);
                            //  alert("no se encontro registro");
                        }
                    },
                    error: function (response) {
                        if (response.length != 0)
                            alert(response);
                    }
                });
                maximo();


            });

               $(".VISUALIZAR").click(function () {                
                $("#EstadoPedido").dialog('open');
                trp = $(this).parent().parent();
                id = $("td:eq(0)", trp).html();
                tipodoc = $("td:eq(1)", trp).html();
                var URL="";
                var VC = {};
                if (tipodoc == "ORDEN SERVICIO") {
                    VC.OC_CNUMORD = id;
                    URL = "TrabajosCurso.aspx/LISTARDETORDEN";
                }
                if (tipodoc == "REQUERIMIENTO") {
                    VC.RD_CNROREQ = id;
                    URL = "TrabajosCurso.aspx/LISTARDETREQUER";
                }
                          
                
                $.ajax({
                    type: "POST",
                    url: URL ,
                    data: '{VC: ' + JSON.stringify(VC) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        if (data.d.length > 0) {
                            var row = $("[id*=GridView3] tr:last-child").clone(true);
                            $("[id*=GridView3] tr").not($("[id*=GridView3] tr:first-child")).remove();

                            for (var i = 0; i < data.d.length; i++) {

                                $("td", row).eq(0).html(data.d[i].ITEM);
                                $("td", row).eq(1).html(data.d[i].DESCRIPCION);
                                $("td", row).eq(2).html(data.d[i].UNIDAD);
                                $("td", row).eq(3).html(data.d[i].CANTIDAD);
                                $("td", row).eq(4).html(formato_numero(data.d[i].PRECIODOLARES, 2, ".", ","));
                                $("td", row).eq(5).html(formato_numero(data.d[i].PRECIOSOLES, 2, ".", ","));
                                $("td", row).eq(6).html(formato_numero(data.d[i].IGV, 2, ".", ","));

                                $("td", row).eq(7).html(formato_numero(data.d[i].TOTALD, 2, ".", ","));
                                $("td", row).eq(8).html(formato_numero(data.d[i].TOTALS, 2, ".", ","));
                               

                                $("[id*=GridView3]").append(row);
                                row = $("[id*=GridView3] tr:last-child").clone(true);
                            }
                            recorregridaux();
                            recorregridaux1();

                        } else {
                            var row = $("[id*=GridView3] tr:last-child").clone(true);
                            $("[id*=GridView3] tr").not($("[id*=GridView3] tr:first-child")).remove();

                            $("td", row).eq(0).html("");
                            $("td", row).eq(1).html("");
                            $("td", row).eq(2).html("");
                            $("td", row).eq(3).html("");
                            $("td", row).eq(4).html("");
                            $("td", row).eq(5).html("");
                            $("td", row).eq(6).html("");
                            $("td", row).eq(7).html("");
                            $("td", row).eq(8).html("");

                            $("[id*=GridView3]").append(row);
                            //  alert("no se encontro registro");
                        }
                    },
                    error: function (response) {
                        if (response.length != 0)
                            alert(response);
                    }
                });
                maximo();

                                               
            });


            $(".editar").click(function () {
                
                $("#dvdetalle").dialog('open');
                $("#MainContent_txtindicador").val("A");
                trp = $(this).parent().parent();
                id = $("td:eq(0)", trp).html();
                $("#MainContent_lblsolicitud").html(id);
                var VC = {};
                VC.TR_CODIGO = id;
              
                
                $.ajax({
                    type: "POST",
                    url: "TrabajosCurso.aspx/traerdatos",
                    data: '{VC: ' + JSON.stringify(VC) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        if (data.d.length > 0) {

                            for (var i = 0; i < data.d.length; i++) {
                                $("#MainContent_lbLsolicitud").html(data.d[i].TR_CODIGO);
                                $("#MainContent_txtcontratista").val(data.d[i].COD_CONTRATISTA +"-"+data.d[i].CONTRATISTA);
                                $("#MainContent_txtcodcontratista").val(data.d[i].COD_CONTRATISTA);

                                $("#MainContent_txtcodcencosto").val(data.d[i].COD_CENCOS);
                                $("#MainContent_txtcencosto").val(data.d[i].COD_CENCOS +" - "+ data.d[i].CENTRO_COSTO);
                                $("#MainContent_lbltipocambio").html(formato_numero(data.d[i].TIPO_CAMBIO, 2, ".", ","));
                              

                                $("#MainContent_txtdescripcion").val(data.d[i].DESCRIPCION);
                                $("#MainContent_txtpresupuesto").val(formato_numero(data.d[i].PRESUPUESTO, 2, ".", ","));
                                $("#MainContent_txtobservaciones").val(data.d[i].OBSERVACIONES);
                                $("#MainContent_txtfecha").val(moment(data.d[i].FECHA).format("DD/MM/YYYY"));

                                $("#MainContent_txtfechainicio").val(moment(data.d[i].FECHA_INI).format("DD/MM/YYYY"));
                                $("#MainContent_txtfechafin").val(moment(data.d[i].FECHA_FIN).format("DD/MM/YYYY"));

                                $("#MainContent_txtestado").val(data.d[i].ESTADO);
                                $("#MainContent_txtvalidacion").val(data.d[i].VALIDACION);

                                if (data.d[i].VALIDACION == "V") {
                                   $("#MainContent_txtcencosto").attr("disabled", true);
                                }
                                if (data.d[i].VALIDACION == "F") {
                                    $("#MainContent_txtcencosto").attr("disabled", false);
                                }
                               

                                $("#MainContent_txtadicional").val(formato_numero(data.d[i].PORC_ADICIONAL, 2, ".", ","));
                                $("#MainContent_txtmanobra").val(formato_numero(data.d[i].PRES_MANOBRA, 2, ".", ","));
                                $("#MainContent_txtpresequipo").val(formato_numero(data.d[i].PRES_EQUIPOS, 2, ".", ","));
                                $("#MainContent_txtpresmaterial").val(formato_numero(data.d[i].PRES_MATERIAL, 2, ".", ","));
                                $("#MainContent_lbltotal").html(formato_numero((Number(data.d[i].PRESUPUESTO) * (Number(data.d[i].PORC_ADICIONAL) / 100)) + Number(data.d[i].PRESUPUESTO), 2, ".", ","));

                                
                                //para obtener el area
                                $("#MainContent_ddlare").val(data.d[i].AE_COD);
                                for (var area = 0 ; area < document.getElementById("<%= ddlare.ClientID %>").length; area++) {
                                    if (document.getElementById("<%= ddlare.ClientID %>").options[area].text == (data.d[i].AE_DESC))
                                        document.getElementById("<%= ddlare.ClientID %>").selectedIndex = area;
                                }
                                //para obtener el area
                                $("#MainContent_ddltipo").val(data.d[i].COD);
                                for (var tipo = 0 ; tipo < document.getElementById("<%= ddltipo.ClientID %>").length; tipo++) {
                                    if (document.getElementById("<%= ddltipo.ClientID %>").options[tipo].text == (data.d[i].TIPO))
                                        document.getElementById("<%= ddltipo.ClientID %>").selectedIndex = tipo;
                                }
                               
                                // para obtener la planta
                                $("#MainContent_ddlplant").val(data.d[i].PL_CODIGO);
                                for (var planta = 0 ; planta < document.getElementById("<%= ddlplant.ClientID %>").length; planta++) {
                                    if (document.getElementById("<%= ddlplant.ClientID %>").options[planta].text == (data.d[i].PL_DESCRIPCION))
                                        document.getElementById("<%= ddlplant.ClientID %>").selectedIndex = planta;
                                }

                                //para obtener el equipo
                                $("#MainContent_ddlequip").val(data.d[i].EQ_CODIGO);
                                for (var equipo = 0 ; equipo < document.getElementById("<%= ddlequip.ClientID %>").length; equipo++) {
                                    if (document.getElementById("<%= ddlequip.ClientID %>").options[equipo].text == (data.d[i].EQ_DESCRIPCION))
                                        document.getElementById("<%= ddlequip.ClientID %>").selectedIndex = equipo;
                                }

                                //para obtener el centro moneda
                                $("#MainContent_ddlmoneda").val(data.d[i].COD_MON);
                                for (var moneda = 0 ; moneda < document.getElementById("<%= ddlmoneda.ClientID %>").length; moneda++) {
                                    if (document.getElementById("<%= ddlmoneda.ClientID %>").options[moneda].text == (data.d[i].MONEDA))
                                        document.getElementById("<%= ddlmoneda.ClientID %>").selectedIndex = moneda;
                                }

                                //para obtener el trabajo en curso
                                for (var tc = 0 ; tc < document.getElementById("<%= ddlcontrolactivos.ClientID %>").length; tc++) {
                                    if (document.getElementById("<%= ddlcontrolactivos.ClientID %>").options[tc].text == (data.d[i].CONTROL_ACTIVOS))
                                        document.getElementById("<%= ddlcontrolactivos.ClientID %>").selectedIndex = tc;
                                }

                                for (var tc = 0 ; tc < document.getElementById("<%= ddltipo.ClientID %>").length; tc++) {
                                    if (document.getElementById("<%= ddltipo.ClientID %>").options[tc].text == (data.d[i].TIPO))
                                        document.getElementById("<%= ddltipo.ClientID %>").selectedIndex = tc;
                                }

                            }
                            var row = $("[id*=GridView1] tr:last-child").clone(true);
                            $("[id*=GridView1] tr").not($("[id*=GridView1] tr:first-child")).remove();

                            $("td", row).eq(0).val("");
                            $("td", row).eq(0).html("");
                            $("td", row).eq(1).html("");
                            $("td", row).eq(1).val("");
                            $("td", row).eq(2).html("");
                            $("[id*=GridView1]").append(row);
                            
                            filtardetalle1();
                            filtardetalleAcum();
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
                maximo();

                                               
            });
            function maximo() {
                               
                var data = {};
                data.TR_CODIGO = $("#MainContent_lblsolicitud").html();

                $.ajax({
                    type: "POST",
                    url: "TrabajosCurso.aspx/maximo",
                    data: '{data: ' + JSON.stringify(data) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        if (data.d.length > 0) {
                            $("#MainContent_txtmaximo").val(data.d);
                        }
                    },
                    error: function (response) {
                        if (response.length != 0)
                            console.log(response);
                    }
                });
            }

            function TipoCambio() {
               
                var fecemi = moment($("#MainContent_txtfecha").val(), "DD/MM/YYYY");
                fecemi = fecemi == null ? null : new Date(fecemi);
                var data = {};
                data.XFECCAM2 = fecemi;
                $.ajax({
                    type: "POST",
                    url: "TrabajosCurso.aspx/tc",
                    data: '{data: ' + JSON.stringify(data) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        if (data.d.length > 0) {
                         
                              $("#MainContent_lbltipocambio").html(data.d);
                           
                        }
                     },
                    error: function (response) {
                        if (response.length != 0)
                            console.log(response);
                    }
                });
            }

              function porcentaje() {
                    $.ajax({
                    type: "POST",
                    url: "TrabajosCurso.aspx/getporcentaje",
                    data: "",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                       if (data.d.length > 0) {
                       
                                $("#MainContent_txtadicional").val(data.d);
                               
                                                
                        }
                    },
                    error: function (response) {
                        if (response.length != 0)
                            alert(response);
                    }
                });

            };

            $(".imprimi").click(function () {

                var trp = $(this).parent().parent();
                var idnumor = $("td:eq(0)", trp).html();
              if (idnumor != "&nbsp;") {
                    window.open("../MANTENIMIENTO/Reportes/TC_IMPRESION.aspx?ID= " + idnumor, '_blank');
                } else {
                    alert("Error en envio de Datos");
                }
            });

            function recorregridaux() {
            subtt = 0; acum = 0;
            sumasub = 0;           
          
            var gridView = document.getElementById("<%=GridView1.ClientID %>");

            for (var t = 1; t < gridView.rows.length; t++) {
                var inputs = gridView.rows[t].getElementsByTagName('input');

                cellPivot = gridView.rows[t].cells[4];
                subtt = cellPivot.innerHTML;
                sumasub = new Number(sumasub) + new Number(subtt);
            }
               
            $("#MainContent_lbltotalacumulado").html(formato_numero(sumasub, 2, ".", ","));
            }

            function recorregridaux1() {
            subtt = 0; acum = 0;
            sumasub = 0;           
          
            var gridView = document.getElementById("<%=GridView2.ClientID %>");

            for (var t = 1; t < gridView.rows.length; t++) {
                var inputs = gridView.rows[t].getElementsByTagName('input');

                cellPivot = gridView.rows[t].cells[3];
                subtt = cellPivot.innerHTML;
                sumasub = new Number(sumasub) + new Number(subtt);
            }
                // formato_numero(sumasol, 2, ".", ",")
            $("#MainContent_lblacumulado").html(formato_numero(sumasub, 2, ".", ","));
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

                //if (separador_miles) {
                //    // Añadimos los separadores de miles
                //    var miles = new RegExp("(-?[0-9]+)([0-9]{3})");
                //    while (miles.test(numero)) {
                //        numero = numero.replace(miles, "$1" + separador_miles + "$2");
                //    }
                //}

                return numero;
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
            width: 97px;
                height: 27px;
            }
        .auto-style2 {
            height: 15px;
        }
        .auto-style3 {
            width: 127px;
            height: 15px;
        }
         #btnnuevo {
             width: 82px;
         }
         .auto-style4 {
             width: 75px;
         }
            .auto-style5 {
                width: 74px;
                height: 21px;
            }
            .auto-style6 {
                width: 72px;
            }
            .auto-style8 {
                width: 798px;
            }
            .auto-style10 {
                width: 127px;
                height: 19px;
            }
            .auto-style11 {
                height: 19px;
            }
            .auto-style12 {
                width: 128px;
            }
            .auto-style13 {
                width: 89px;
            }
            .auto-style15 {
                width: 69px;
            }
            #btnvalidar {
                width: 101px;
                height: 25px;
            }
            .auto-style16 {
                width: 148px;
            }
            .auto-style17 {
                width: 130px;
            }
            .auto-style18 {
                height: 21px;
            }
            .auto-style19 {
                width: 130px;
                height: 21px;
            }
            .auto-style20 {
                width: 148px;
                height: 21px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <fieldset style="background-color: #99CCFF">
        <legend style="font-weight: bold; background-color: #99CCFF;">
            <asp:Label ID="Label9" runat="server" Text="LISTADO DE TRABAJOS EN CURSO" Font-Bold="True" Font-Size="12pt"></asp:Label></legend>

        <table>
            <tr>
                <td>Area</td>
                <td colspan="3">
                    <asp:DropDownList ID="ddlarea" runat="server" Height="16px" Width="324px">
                        <asp:ListItem Value="1">TODOS</asp:ListItem>
                        <asp:ListItem Value="L">LIQUIDADA</asp:ListItem>
                        <asp:ListItem Value="P">PENDIENTE</asp:ListItem>
                    </asp:DropDownList>
                </td>
              
                <td>
                    <asp:Label ID="lblacceso" runat="server" ForeColor="#66CCFF"></asp:Label>
                </td>
            </tr>
             <tr>
                <td>
                    Equipo</td>
                <td class="auto-style4">
                    <asp:DropDownList ID="ddlequipo" runat="server" Height="22px" Width="324px">
                    </asp:DropDownList>
                </td>
               
                  <td>
                    &nbsp;<asp:Label ID="lblusuario" runat="server" ForeColor="#66CCFF"></asp:Label>
                </td>
                 </tr>
             <tr>
                <td>Planta</td>
                <td colspan="3">
                    <asp:DropDownList ID="ddlplanta" runat="server" Height="16px" Width="324px">
                        <asp:ListItem Value="1">TODOS</asp:ListItem>
                        <asp:ListItem Value="L">LIQUIDADA</asp:ListItem>
                        <asp:ListItem Value="P">PENDIENTE</asp:ListItem>
                    </asp:DropDownList>
                &nbsp;</td>
                
                 </tr>
            <tr>
                <td>
                    C. Costo</td>
                <td>
                    <asp:TextBox ID="txtcencosto0" runat="server" Width="324px"></asp:TextBox> 
                </td>
                <td>
                  <asp:TextBox ID="txtcodcencosto0" runat="server" Width="130px"></asp:TextBox> 
                
                </td>
              
            </tr>
            <tr>
                <td>
                    Estado</td>
                <td>
                    <asp:DropDownList ID="ddlestado" runat="server" Height="21px" Width="324px">
                        <asp:ListItem Value="T">TODOS</asp:ListItem>
                        <asp:ListItem Value="A">APROBADOS</asp:ListItem>
                        <asp:ListItem Value="E">EMITIDOS</asp:ListItem>
                    </asp:DropDownList>
                </td>
              
            </tr>
            </table>
        <table>
            <tr>
                  <td>Fecha:</td>
                <td>
                    &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtfecha1" runat="server" Width="80" placeholder="00/00/0000"></asp:TextBox>
                </td>
                <td>Fecha al:</td>
                <td>
                    <asp:TextBox ID="txtfecha2" runat="server" Width="80" placeholder="00/00/0000"></asp:TextBox>
                </td>
            </tr>
            </table>
        <table>
            <tr><td>

                <input id="btnnuevo" type="button" value="Nuevo" class="btadd" /></td>
                <td>

                    <%--  <table>
           
            <tr>
                 <td> Tipo Documento&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td>

                <asp:DropDownList ID="ddltipodoc" runat="server" Height="29px" Width="178px">
                </asp:DropDownList>

                </td>
                <td class="auto-style9">Nº Documento&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td>
                    <asp:TextBox ID="txtdocumento" runat="server"></asp:TextBox>
                </td>

                <td class="auto-style9">Monto</td>
                <td>
                    <asp:TextBox ID="txtmonto" runat="server" Enabled="False" Height="18px" Width="85px"></asp:TextBox>
                </td>

               
                <td>
                       <input id="btnagregar" type="submit" value="Agregar" class="btaddgrilla" />
                 </td>
                </tr>
            <tr>--%>
                    <asp:Button ID="btnbuscar" runat="server" Text="Buscar" Width="91px" OnClick="btnbuscar_Click" />
                &nbsp;<asp:Button ID="btreporte" runat="server" Text="Reporte" Width="91px" OnClick="btreporte_Click" />
                </td>
            </tr>
        </table>
      
    </fieldset>


    <table>
        <tr>
            <td>
                <asp:GridView ID="gvordencompra" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" OnRowCreated="griddata_RowCreated" OnRowDataBound="gvordencompra_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="TR_CODIGO" HeaderText="N° TAREA" >
                        <ItemStyle VerticalAlign="Top" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FECH" HeaderText="FECHA"  >  
                        <ItemStyle VerticalAlign="Top" />
                        </asp:BoundField>
                        <asp:BoundField DataField="AE_DESC" HeaderText="AREA" >
                         <ItemStyle VerticalAlign="Top" />
                        </asp:BoundField>
                        <asp:BoundField DataField="EQ_DESCRIPCION" HeaderText="EQUIPO" >
                             <ItemStyle VerticalAlign="Top" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PL_DESCRIPCION" HeaderText="PLANTA" >
                             <ItemStyle VerticalAlign="Top" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CONTRATISTA" HeaderText="CONTRATISTA" >
                             <ItemStyle VerticalAlign="Top" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CENTRO_COSTO" HeaderText="CENTRO_COSTO" >
                             <ItemStyle VerticalAlign="Top" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DESCRIPCION" HeaderText="DESCRIPCION" >
                             <ItemStyle VerticalAlign="Top" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CONTROL_ACTIVOS" HeaderText="CONTROL ACTIVOS" >
                             <ItemStyle VerticalAlign="Top" />
                        </asp:BoundField>

                        <asp:BoundField DataField="ESTADO" HeaderText="ESTADO" >
                             <ItemStyle VerticalAlign="Top" />
                        </asp:BoundField>

                        <asp:BoundField DataField="PRESUPUESTO" HeaderText="PRESUP." DataFormatString="{0:F2}" >
                             <ItemStyle HorizontalAlign="Right" VerticalAlign="Top"></ItemStyle>
                                    </asp:BoundField>

                        <asp:BoundField DataField="acumulado" HeaderText="PRES.USADO" DataFormatString="{0:F2}" >
                             <ItemStyle HorizontalAlign="Right" VerticalAlign="Top"></ItemStyle>
                                    </asp:BoundField>

                        <asp:BoundField DataField="PRES_MANOBRA" DataFormatString="{0:F2}" HeaderText="%">
                             <ItemStyle HorizontalAlign="Right" VerticalAlign="Top"></ItemStyle>
                                    </asp:BoundField>

                        <asp:BoundField DataField="PRES_MATERIAL" HeaderText="ACUM." DataFormatString="{0:F2}" >
                             <ItemStyle HorizontalAlign="Right" VerticalAlign="Top"></ItemStyle>
                                    </asp:BoundField>
                        <asp:BoundField DataField="PRES_EQUIPOS" DataFormatString="{0:F2}" HeaderText="%" >
                             <ItemStyle HorizontalAlign="Right" VerticalAlign="Top"></ItemStyle>
                                    </asp:BoundField>
                         <asp:BoundField DataField="TIPO" HeaderText="TIPO" >
                             <ItemStyle VerticalAlign="Top" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="EDITAR">

                            <ItemTemplate>
                                <div class="editar" style="text-align: center">
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
    <%--style="display:none"--%>
    <div id="dvdetalle" style="display:none" >
         
        <table>
            <tr>
                <td>Código</td>

                <td>
                    <asp:Label ID="lblsolicitud" runat="server" Text=""></asp:Label>
                </td>
                 <td class="auto-style3"> Planta</td>
                <td class="auto-style2">  
                <asp:DropDownList ID="ddlplant" runat="server" Height="30px" Width="267px">
                </asp:DropDownList>
                </td>
            </tr>

             <tr>
                <td class="auto-style1"> Area </td> 
                <td>
                <asp:DropDownList ID="ddlare" runat="server" Height="30px" Width="267px">
                </asp:DropDownList>
                 </td>
                 
                <td class="auto-style1">Equipo</td>
                <td>  
                <asp:DropDownList ID="ddlequip" runat="server" Height="30px" Width="267px">
                </asp:DropDownList>
                </td>

                     
              


           
                
            </tr>
           
                         
            <tr>
                <td class="auto-style1"> Contratista</td> <td> 
                    <asp:TextBox ID="txtcontratista" runat="server" Width="267px"></asp:TextBox> 
                </td><td>
                  <asp:TextBox ID="txtcodcontratista" runat="server" Width="130px" Enabled="false"></asp:TextBox> 
                </td>

           </tr>
            <tr>
                <td class="auto-style10">Centro Costo</td> <td class="auto-style11"> 
                    <asp:TextBox ID="txtcencosto" runat="server" Width="267px"></asp:TextBox> 
                </td><td class="auto-style11">
                  <asp:TextBox ID="txtcodcencosto" runat="server" Width="130px" Enabled="false"></asp:TextBox> 
                </td>

           </tr> <tr>
              <td class="auto-style1">Tipo</td>
                <td>  
                <asp:DropDownList ID="ddltipo" runat="server" Height="30px" Width="267px">
                </asp:DropDownList>
                </td></tr>
            </table>

            <table>
            <tr>
                <td class="auto-style1"> Descripción</td> <td>
                    <asp:TextBox ID="txtdescripcion" runat="server" Width="666px" Height="56px" TextMode="MultiLine"></asp:TextBox> </td>
            </tr>
                </table>
         <table>

            <tr>
                <td class="auto-style1"> Control Activos</td> <td>
                <asp:DropDownList ID="ddlcontrolactivos" runat="server" Height="25px" Width="169px">
                    <asp:ListItem>TRABAJO EN CURSO</asp:ListItem>
                    <asp:ListItem>MEJORA TRABAJO EN CURSO</asp:ListItem>
                </asp:DropDownList>
                </td>
                <td class="auto-style6"> Moneda</td>
                 <td>
                <asp:DropDownList ID="ddlmoneda" runat="server" Height="28px" Width="149px">
                </asp:DropDownList>
                 </td>
                </tr>
              <tr>
                <td class="auto-style1"> Fecha Registro</td> <td>
                    <asp:TextBox ID="txtfecha" runat="server" Enabled="True" Width="125px" placeholder="00/00/0000"></asp:TextBox> 
                    <asp:TextBox ID="txtindicador" runat="server" Width="0px" BorderStyle="None"></asp:TextBox>
                &nbsp; 
                    <asp:TextBox ID="txtestado" runat="server" Width="0px" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="txtmaximo" runat="server" Width="0px" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="txtvalidacion" runat="server" Width="0px" BorderStyle="None"></asp:TextBox>
                </td>
                  <td>
                     Tipo Cambio
                 </td>
                 <td> <asp:Label ID="lbltipocambio" runat="server" Text=""></asp:Label></td>
                     
            </tr>
            <tr>
                  <td class="auto-style10"> Fecha Inicio</td>
                <td class="auto-style11">
                    <asp:TextBox ID="txtfechainicio" runat="server" placeholder="00/00/0000"></asp:TextBox></td>
                            <td class="auto-style10"> Fecha Fin</td>
                <td class="auto-style11"> <asp:TextBox ID="txtfechafin" runat="server" placeholder="00/00/0000" Width="146px"></asp:TextBox></td>
            </tr>
                         </table>
        <table>
             <tr>
                 <td class="auto-style12">Pres. Material</td>
                 <td>
                     <asp:TextBox ID="txtpresmaterial" runat="server" Width="75px" style="margin-bottom: 0"></asp:TextBox> 
                 </td>

                 <td class="auto-style13">Pres Equipo</td>
                 <td class="auto-style17"><asp:TextBox ID="txtpresequipo" runat="server" Width="125px" style="margin-bottom: 0"></asp:TextBox> 
                 </td>

                 <td class="auto-style16">&nbsp; Pres. Mano Obra</td>
                 <td class="auto-style15">
                     <asp:TextBox ID="txtmanobra" runat="server" Width="100px" style="margin-bottom: 0"></asp:TextBox> 
                 </td>
                 <td>
                     <input id="btncalcular" type="button" value="Calcular" class="calcular" />
                 </td>

</tr>
            <tr>

                <td class="auto-style5"> Presupuesto</td>
                 <td class="auto-style18">
                     <asp:TextBox ID="txtpresupuesto" runat="server" Width="75px" style="margin-bottom: 0" Enabled="False"></asp:TextBox> 
                 </td>
                  <td class="auto-style5"> % Adicional</td>
                 <td class="auto-style19"><asp:TextBox ID="txtadicional" runat="server" Width="125px" style="margin-bottom: 0" Enabled="False"></asp:TextBox> 
                 </td>
                   <td class="auto-style20">&nbsp; Total</td>
                 <td class="auto-style18">
                    &nbsp;<asp:Label ID="lbltotal" runat="server" Width="67px" style="margin-bottom: 0" Enabled="False"></asp:Label> 
                 </td>
            </tr>
            
             </table>
        <table>

              <tr>
                <td class="auto-style1"> Observaciones</td> <td> 
                    <asp:TextBox ID="txtobservaciones" runat="server" Width="668px" Height="57px" TextMode="MultiLine"></asp:TextBox> </td>
            </tr>
              
           
            <tr>
                <td>
                     <input id="btngrabar" type="button" value="Grabar" class="btgrabar"/>
                </td>
               
                <td>
                     <input id="btnvalidar" type="button" value="Validar" class="btvalidar"/>
                </td>
            </tr>
            </table>
        <table> <tr> <td class="auto-style8">******************* DOCUMENTOS SUSTENTATORIOS*****************</td></tr></table>

      <%-- <td>
                    <asp:TextBox ID="txtaux1" runat="server" BorderStyle="None" Width="0px"></asp:TextBox>
                    <asp:TextBox ID="txtaux2" runat="server" BorderStyle="None" Width="0px"></asp:TextBox>

                </td>
            </tr>

        </table>--%>
               <%-- <td>
                    <asp:TextBox ID="txtaux1" runat="server" BorderStyle="None" Width="0px"></asp:TextBox>
                    <asp:TextBox ID="txtaux2" runat="server" BorderStyle="None" Width="0px"></asp:TextBox>

                </td>
            </tr>

        </table>--%>
          <fieldset style="background-color: #99CCFF">
        <table>
            <tr>

                <td>
                     <div style=" overflow: auto;width: 500px; height: 150px">
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" Font-Size="Smaller" Width="483px">
                    <Columns>
                        <asp:BoundField HeaderText="Nº DOC." DataField="CODIGO" />
                        <asp:BoundField DataField="DOCUMENTO" HeaderText="TIPO DOCUMENTO" />

                        <asp:BoundField DataField="FECHA" HeaderText="FECHA" />

                        <asp:BoundField DataField="MONEDA" HeaderText="MONEDA" />
                        <asp:BoundField DataField="MONTO"  HeaderText="MONTO" >
                             <ItemStyle HorizontalAlign="Right" VerticalAlign="Top"></ItemStyle>
                                    </asp:BoundField>
                         <asp:TemplateField HeaderText="VER">

                            <ItemTemplate>
                                <div class="VISUALIZAR" style="text-align: center">
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
                         </div>
                </td>

                  <td>
                     <div style=" overflow: auto;width: 500px; height: 150px">
                    <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" Font-Size="Smaller" Width="483px">
                    <Columns>
                        <asp:BoundField HeaderText="Nº DOC." DataField="CODIGO" />
                        <asp:BoundField DataField="DOCUMENTO" HeaderText="TIPO DOCUMENTO" />

                        <asp:BoundField DataField="FECHA" HeaderText="FECHA" />

                        <asp:BoundField DataField="MONTOMN" HeaderText="MONTO S/." >
                             <ItemStyle HorizontalAlign="Right" VerticalAlign="Top"></ItemStyle>
                                    </asp:BoundField>
                         <asp:BoundField DataField="MONTOUS" HeaderText="MONTO US$" >
                             <ItemStyle HorizontalAlign="Right" VerticalAlign="Top"></ItemStyle>
                                    </asp:BoundField>
                         <asp:TemplateField HeaderText="VER">

                            <ItemTemplate>
                                <div class="VISUALIZARSOLICITUD" style="text-align: center">
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
                         </div>
                </td>

            </tr>

        </table>
     </fieldset>
        <table>
            <tr>
                <td>Total Proyectado</td>
                <td>
                    <asp:Label ID="lbltotalacumulado" runat="server" Text=""></asp:Label></td>

                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Total Acumulado</td>
                <td>
                    <asp:Label ID="lblacumulado" runat="server" Text=""></asp:Label></td>

                <td>  <input id="btgrabadetalle" type="button" value="Actualizar Detalle" class="btdetalle"/>

                </td>
            </tr>
             
        </table>

    </div>
    <%--style="display:none"--%>
    <div id="EstadoPedido" style="display:none" >
        <table>
            <tr>
                <td>
                     <div style=" overflow: auto;width: 500px; height: 150px">
                    <asp:GridView ID="GridView3" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" Font-Size="Smaller" Width="483px">
                    <Columns>
                        <asp:BoundField HeaderText="ITEM" DataField="ITEM" />
                        <asp:BoundField DataField="DESCRIPCION" HeaderText="DESCRIPCION" />
                        <asp:BoundField DataField="UNIDAD" HeaderText="UNIDAD" />

                        <asp:BoundField DataField="CANTIDAD" HeaderText="CANTIDAD" DataFormatString="{0:F2}"/>
                        <asp:BoundField DataField="PRECIODOLARES" HeaderText="PRECIO US$" DataFormatString="{0:F2}" >
                            <ItemStyle HorizontalAlign="Right" ></ItemStyle>
                                    </asp:BoundField>
                        <asp:BoundField DataField="PRECIOSOLES" HeaderText="PRECIO S/." DataFormatString="{0:F2}" >
                        <ItemStyle HorizontalAlign="Right" ></ItemStyle>
                                    </asp:BoundField>
                         <asp:BoundField DataField="IGV" HeaderText="IGV" DataFormatString="{0:F2}" >
                        <ItemStyle HorizontalAlign="Right" ></ItemStyle>
                                    </asp:BoundField>
                        <asp:BoundField DataField="TOTALD" HeaderText="TOTAL US$" DataFormatString="{0:F2}" >
                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                    </asp:BoundField>
                        <asp:BoundField DataField="TOTALS" HeaderText="TOTAL S/." DataFormatString="{0:F2}" >
                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
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
    </div>
    <%-- --%>
    <div id="detsolicitud" style="display:none" >
        <table>
            <tr>
                <td>
                     <div style=" overflow: auto;width: 500px; height: 150px">
                    <asp:GridView ID="GridView4" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" Font-Size="Smaller" Width="483px">
                    <Columns>
                        <asp:BoundField HeaderText="SOLICITUD" DataField="ITEM" />
                        <asp:BoundField DataField="DESCRIPCION" HeaderText="DESCRIPCION" />
                        <asp:BoundField DataField="UNIDAD" HeaderText="MONEDA" />

                        <asp:BoundField DataField="CANTIDAD" HeaderText="CANTIDAD" DataFormatString="{0:F2}"/>
                        <asp:BoundField DataField="PRECIOSOLES" HeaderText="PRECIO" DataFormatString="{0:F2}" >
                        <ItemStyle HorizontalAlign="Right" ></ItemStyle>
                                    </asp:BoundField>
                        <asp:BoundField DataField="TOTALD" HeaderText="TOTAL US$" DataFormatString="{0:F2}" >
                        <ItemStyle HorizontalAlign="Right" ></ItemStyle>
                                    </asp:BoundField>
                        <asp:BoundField DataField="TOTALS" HeaderText="TOTAL S/." DataFormatString="{0:F2}" >
                        <ItemStyle HorizontalAlign="Right" ></ItemStyle>
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
    </div>


</asp:Content>
