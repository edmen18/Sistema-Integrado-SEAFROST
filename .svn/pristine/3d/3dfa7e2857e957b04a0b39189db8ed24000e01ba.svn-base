
<%@ Page Title="Liquidación Rendición" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ComprobantesCompras.aspx.cs" Inherits="FINANZAS_TESORERIA_RENDICIONES_ComprobantesCompras" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link type="text/css" href="../../../CSS/base.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {

            $(window).load(function () {
              // Llenartipoanexo("R");
            });

            $('.cont_sel').hide();
           
            UHTML.id = 'MainContent';
            $("#MainContent_txtfecha").datepicker();
            $("#MainContent_txtfechaini").datepicker();
            $("#MainContent_txtfechafin").datepicker();

            $("#MainContent_txtfechaemision").datepicker();
            $("#MainContent_txtfechavmto").datepicker();
            $("#MainContent_txtfechaven").datepicker(); 
            $("#MainContent_txtfechaven").datepicker();
            Operacion.mask('txtcencos').autocomplete(
                       {
                           source: function (request, response) {

                               $.ajax({
                                   url: "ComprobantesCompras.aspx/GETVARIOSCENCOS",
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
                               $('#MainContent_txtcodcencos').val(str);


                           }
                       });

            $("#MainContent_txtcodcencos").autocomplete(
                     {
                         source: function (request, response) {

                             $.ajax({
                                 url: "ComprobantesCompras.aspx/GETVARIOSCENCOS",
                                 data: "{ 'CLAVE': '" + request.term + "' ,  'INDICADOR': '10' }",
                                 dataType: "json",
                                 type: "POST",
                                 contentType: "application/json; charset=utf-8",
                                 dataFilter: function (data) { return data; },
                                 success: function (data) {
                                     response($.map(data.d, function (item) {
                                         return {
                                             id: item.TG_CDESCRI + " - " + item.TG_CCLAVE,
                                             value: item.TG_CCLAVE

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
                             $('#MainContent_txtcencos').val(str);


                         }
                     });

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
                    Operacion.mask('ddlmotivo').find("option").remove();
                    var boton = document.getElementById("<%=btnver.ClientID%>");
                     boton.click();
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
               // Operacion.mask('txtmontodeclarado').val(monto);
                //Operacion.mask('lbldiferencia').text(Number(Operacion.mask('lblmonto').text()) - Number(Operacion.mask('txtmontodeclarado').val()));

                $('.cont_sel').show();
                filtrardetalles();
                total();

            });

            $(".glosas").change(function () {
                Operacion.mask('txtglosacomprobante').val(Operacion.mask('txtproveedor').val().trim().substring(0,13) +","+Operacion.mask('ddldocumento').val().trim() + " "+ Operacion.mask('txtdocumento').val());
                Operacion.mask('txtglosamovimiento').val(Operacion.mask('txtproveedor').val().trim().substring(0, 13) + "," + Operacion.mask('ddldocumento').val().trim() + " " + Operacion.mask('txtdocumento').val());

            });
      
            $(".Grabar").click(function () {
                ////(Number(Operacion.mask('lbldiferencia').text())=>0? Number(Operacion.mask('lblmonto').text()): Number(Operacion.mask('txtmontodeclarado').val()))

                //if (Operacion.mask('lblestado').text() != "L") { 
                //    if (Number(Operacion.mask('lbltotal').text())>=0)
                //    {
                        

                //        if ((Number(Operacion.mask('lbltotal').text()).toFixed(2) + Number(Operacion.mask('txtimportetotal').val()).toFixed(2))
                //            < Number(Operacion.mask('lblmonto').text()).toFixed(2))
                //    {
                //        alert("No es posible la operacion ya que el monto ingresado debe ser mayor o igual al total de la solicitud ");
                   
                //    }
                //    else {
                        if (Operacion.mask('txtcodigodetalle').val()==""){
                            InsertaSolicitud();
                        }
                        else {

                            Actualizaitem()
                        }
                    
                        filtrardetalles();
                        total();
                        limpiar();
                //    }
                //    }

                //   else {

                //        if ((Number(Operacion.mask('lbltotal').text()).toFixed(2) + Number(Operacion.mask('txtimportetotal').val()).toFixed(2)) >= Number(Operacion.mask('txtmontodeclarado').val()).toFixed(2)) {
                //            alert("No es posible la operacion ya que el monto ingresado supera al total de la solicitud 1");

                //        }
                //        else {
                //            if (Operacion.mask('txtcodigodetalle').val() == "") {
                //                InsertaSolicitud();
                //            }
                //            else {
                //                Actualizaitem()
                //            }

                //            filtrardetalles();
                //            total();
                //            limpiar();
                //        }
                //    }

                //}
                //else {
                //    alert("No es posible esta operación debido a que la solicitud se encuentra Liquidada");
                //}

            });
           
            $(".imprimir").click(function () {
                trp = $(this).parent().parent();
                id = $("td:eq(2)", trp).html();
                Tipo = $("td:eq(0)", trp).html();
                Estado = $("td:eq(7)", trp).html();
                window.open("../RENDICIONES/ImprimirSolicitud.aspx?NUMERO= " + id + "&TIPO=" + Tipo + "&ESTADO=" + Estado, '_blank');

            });

            $("#MainContent_txtproveedor").autocomplete(
                   {
                       source: function (request, response) {
                           $.ajax({
                               url: "ComprobantesCompras.aspx/GetProveedores",
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
            $("#MainContent_txtcodigoproveedor").autocomplete(
                   {
                       source: function (request, response) {
                           $.ajax({
                               url: "ComprobantesCompras.aspx/GetProveedoresid",
                               data: "{ 'productos': '" + request.term + "' }",
                               dataType: "json",
                               type: "POST",
                               contentType: "application/json; charset=utf-8",
                               dataFilter: function (data) { return data; },
                               success: function (data) {
                                   response($.map(data.d, function (item) {
                                       return {
                                           id: item.ADESANE,
                                           value: item.ACODANE,
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
                           $('#MainContent_txtproveedor').val(str);
                           Operacion.mask('txtruc').val(ui.item.v);
                                                

                       }
                   });
            $(".tipocambio").change(function () {
                //alert("dentro");
                if (Operacion.mask('ddltipodeconversion').val().trim() == "V") {
                    tipocambioVenta();

                }
                if (Operacion.mask('ddltipodeconversion').val().trim() == "M") {
                    tipocambiocompra();
                }
                if (Operacion.mask('ddltipodeconversion').val().trim() == "C") {
                    $('#MainContent_txttipocambio').val("0.00");
                }
                if (Operacion.mask('ddltipodeconversion').val().trim() == "F") {
                    tipocambiocompra();
                }

            });

            $(".IGVCH").click(function () {
               
                if( document.getElementById("<%=chkigv.ClientID %>").checked == true){
                    Operacion.mask('txtmontoigv').val(Operacion.mround(Number(Operacion.mask('txtimportetotal').val()) * (Number(Operacion.mask('txtigv').val()) / 100),2))
                }
                 if( document.getElementById("<%=chkigv.ClientID %>").checked == false){
                    Operacion.mask('txtmontoigv').val("0.00")
                }

            });
             $(".IGVCHAN").change(function () {
               
                if( document.getElementById("<%=chkigv.ClientID %>").checked == true){
                    Operacion.mask('txtmontoigv').val(Operacion.mround(Number(Operacion.mask('txtimportetotal').val()) * (Number(Operacion.mask('txtigv').val()) / 100), 2))
                }
                 if( document.getElementById("<%=chkigv.ClientID %>").checked == false){
                    Operacion.mask('txtmontoigv').val("0.00")
                }

            });

            function tipocambiocompra() {
                var fecemi =new Date();
              
                var com = {};
                com.XDATE = fecemi;
                $.ajax({

                    type: "POST",
                    url: "ComprobantesCompras.aspx/obetenertcambiocvEdgar",
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
                var fecemi = new Date();
                var com = {};
                com.XDATE = fecemi;
                $.ajax({

                    type: "POST",
                    url: "ComprobantesCompras.aspx/obetenertcambiocvEdgar",
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

            function InsertaSolicitud() {
                var datos = {};
                var fe = moment($("#MainContent_txtfechavmto").val(), "DD/MM/YYYY");
                fe = fe == null ? null : new Date(fe);
                var fv = moment($("#MainContent_txtfechaemision").val(), "DD/MM/YYYY");
                fv = fv == null ? null : new Date(fv);

                datos.ORDEN_NUMERO = Operacion.mask('lblsolicitud').text();
                datos.CODIGO_CAJA = Operacion.mask('lblcodtipo').text();
                datos.FECHA_EMISION = fe;
                datos.CODIGO_PROVEEDOR = Operacion.mask('txtcodigoproveedor').val();
                datos.PROVEEDOR = Operacion.mask('txtproveedor').val();
                datos.RUC = Operacion.mask('txtruc').val();
                datos.TIPO_DOCUMENTO = Operacion.mask('ddldocumento').val();
                datos.NUM_DOCUMENTO = Operacion.mask('txtdocumento').val();
                datos.FECHA_VENCIMIENTO = fv;
                datos.MONTO_IGV = Operacion.mask('txtmontoigv').val();
                datos.IGV = Operacion.mask('txtigv').val();
                datos.TOTAL = Number(Operacion.mask('txtimportetotal').val()) + Number(Operacion.mask('txtmontoigv').val());
                datos.PARCIAL  = Operacion.mask('txtimportetotal').val();
                datos.GLOSA_COMPROBANTE = Operacion.mask('txtglosacomprobante').val();
                datos.GLOSA_MOVIMIENTO = Operacion.mask('txtglosamovimiento').val();
                datos.CUENTA = Operacion.mask('ddlmotivo').val();
                datos.MOTIVO = Operacion.mask('ddlmotivo option:selected').text();
                datos.AREA=(Operacion.mask('ddloarea').val()=="X"? null: Operacion.mask('ddloarea').val());
                datos.ANEXO_REFERENCIA=(Operacion.mask('txtanexore').val()==""? null:Operacion.mask('txtanexore').val());
                datos.FECHA_VEN=(Operacion.mask('txtfechaven').val()==""? null:Operacion.mask('txtfechaven').val());
                datos.CENCOS=(Operacion.mask('txtcodcencos').val()==""? null:Operacion.mask('txtcodcencos').val());
                datos.ANEXO_REF2=(Operacion.mask('txtanexore2').val()==""? null:Operacion.mask('txtanexore2').val());
                datos.MEDIOPAG = (Operacion.mask('ddlmedpag').val() == "" ? null : Operacion.mask('ddlmedpag').val());
                datos.TIPO_REF2 = (Operacion.mask('ddldocre2').val() == "" ? null : Operacion.mask('ddldocre2').val());
                datos.SUBDIARIO = SUBDIARIO().subd;
                datos.FECHA_REF2 =   (Operacion.mask('txtfechaanexore2').val() == "" ? null : Operacion.mask('txtfechaanexore2').val()); 
                datos.ESTADO = "P";
                datos.DVANEXO = Operacion.mask('lblanexo').text();
                datos.ANEXO = (Operacion.mask('lblanexo').text().trim() == "P" ? Operacion.mask('txtcodigoproveedor').val() : Operacion.mask('lblanexo').text().trim() == "T" ? Operacion.mask('lblcodsolicitante').text() : Operacion.mask('ddlanexo').val())

                $.ajax({
                    type: "POST",
                    url: "ComprobantesCompras.aspx/insertaoer",
                    data: '{datos: ' + JSON.stringify(datos) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        alert("Registro guardado");
                    },
                    error: function (response) {
                        if (response.length != 0)
                            alert(response);
                        console.log(response);

                    }
                });
            }
            function Actualizaitem() {
                var datos = {};
                var fe = moment($("#MainContent_txtfechavmto").val(), "DD/MM/YYYY");
                fe = fe == null ? null : new Date(fe);
                var fv = moment($("#MainContent_txtfechaemision").val(), "DD/MM/YYYY");
                fv = fv == null ? null : new Date(fv);

                datos.ORDEN_NUMERO = Operacion.mask('lblsolicitud').text();
                datos.CODIGO_CAJA = Operacion.mask('lblcodtipo').text();
                datos.FECHA_EMISION = fe;
                datos.CODIGO_PROVEEDOR = Operacion.mask('txtcodigoproveedor').val();
                datos.PROVEEDOR = Operacion.mask('txtproveedor').val();
                datos.RUC = Operacion.mask('txtruc').val();
                datos.TIPO_DOCUMENTO = Operacion.mask('ddldocumento').val();
                datos.NUM_DOCUMENTO = Operacion.mask('txtdocumento').val();
                datos.FECHA_VENCIMIENTO = fv;
                datos.MONTO_IGV = Operacion.mask('txtmontoigv').val();
                datos.IGV = Operacion.mask('txtigv').val();
                datos.PARCIAL = Number(Operacion.mask('txtimportetotal').val()) - Number(Operacion.mask('txtmontoigv').val());
                datos.TOTAL = Operacion.mask('txtimportetotal').val();
                datos.GLOSA_COMPROBANTE = Operacion.mask('txtglosacomprobante').val();
                datos.GLOSA_MOVIMIENTO = Operacion.mask('txtglosamovimiento').val();
                datos.CODIGO_DETALLE = Operacion.mask('txtcodigodetalle').val();
                datos.CUENTA = Operacion.mask('ddlmotivo').val();
                datos.MOTIVO = Operacion.mask('ddlmotivo option:selected').text();
                datos.AREA = (Operacion.mask('ddloarea').val() == "X" ? null : Operacion.mask('ddloarea').val());
                datos.ANEXO_REFERENCIA = (Operacion.mask('txtanexore').val() == "" ? null : Operacion.mask('txtanexore').val());
                datos.FECHA_VEN = (Operacion.mask('txtfechaven').val() == "" ? null : Operacion.mask('txtfechaven').val());
                datos.CENCOS = (Operacion.mask('txtcodcencos').val() == "" ? null : Operacion.mask('txtcodcencos').val());
                datos.ANEXO_REF2 = (Operacion.mask('txtanexore2').val() == "" ? null : Operacion.mask('txtanexore2').val());
                datos.MEDIOPAG = (Operacion.mask('ddlmedpag').val() == "" ? null : Operacion.mask('ddlmedpag').val());
                datos.TIPO_REF2 = (Operacion.mask('ddldocre2').val() == "" ? null : Operacion.mask('ddldocre2').val());
                datos.SUBDIARIO = SUBDIARIO().subd;
                datos.FECHA_REF2 = (Operacion.mask('txtfechaanexore2').val() == "" ? null : Operacion.mask('txtfechaanexore2').val());
                datos.ESTADO = "P";
                datos.DVANEXO = Operacion.mask('lblanexo').text();
                datos.ANEXO = (Operacion.mask('lblanexo').text().trim() == "P" ? Operacion.mask('txtcodigoproveedor').val() : Operacion.mask('lblanexo').text().trim() == "T" ? Operacion.mask('lblcodsolicitante').text() : Operacion.mask('ddlanexo').val())


                $.ajax({
                    type: "POST",
                    url: "ComprobantesCompras.aspx/actualiza",
                    data: '{datos: ' + JSON.stringify(datos) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        alert("Registro guardado");
                        Operacion.mask('txtcodigodetalle').val("")
                    },
                    error: function (response) {
                        if (response.length != 0)
                            alert(response);
                        console.log(response);

                    }
                });
            }


            function filtrardetalles() {
                var VC = {};
                VC.ORDEN_NUMERO = Operacion.mask('lblsolicitud').text();
                VC.CODIGO_CAJA = Operacion.mask('lblcodtipo').text();

                $.ajax({

                    type: "POST",
                    url: "ComprobantesCompras.aspx/ListarTodos",
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
                                $("td", row).eq(1).html(data.d[i].PROVEEDOR);
                                $("td", row).eq(2).html(data.d[i].TIPO_DOCUMENTO);
                                $("td", row).eq(3).html(data.d[i].NUM_DOCUMENTO);
                                $("td", row).eq(4).html((moment(data.d[i].FECHA_EMISION).format("DD/MM/YYYY")));
                                $("td", row).eq(5).html(Operacion.mround(Number(data.d[i].MONTO_IGV),2));
                                $("td", row).eq(6).html(Operacion.mround(Number(data.d[i].IGV),2));
                                $("td", row).eq(7).html(Operacion.mround(Number(data.d[i].PARCIAL),2));
                                $("td", row).eq(8).html(Operacion.mround(Number(data.d[i].TOTAL), 2));
                                $("td", row).eq(9).html(data.d[i].MOTIVO);
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
                            //alert("no se encontro registro");
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
                      Number(Operacion.mask('lbltotal').text(Operacion.mround(sumasub,2)));
            }

            $(".Elimina").click(function () {
                if (Operacion.mask('lblestado').text() != "L") {
                 if (confirm("¿ Desea Eliminar este item ? ")) {
                     trp = $(this).parent().parent();
                     id = $("td:eq(0)", trp).val();
                    EliminaItem(id);
                    filtrardetalles();
                    total();
                 }
            }
            else {
                  alert("No es posible esta operación debido a que la solicitud se encuentra Liquidada");
                 }
            });

             $(".editar").click(function () {
                 if(Operacion.mask('lblestado').text()!="L"){
                     trp = $(this).parent().parent();
                 id = $("td:eq(0)", trp).val();
                 monto=$("td:eq(8)", trp).html();
                 ConsultaUno(id);
                 total();
                 Operacion.mask('lbltotal').text(Operacion.mround(Number(Operacion.mask('lbltotal').text())-Number(monto),2))
                 }
                 else {
                     alert("No es posible esta operación debido a que la solicitud se encuentra Liquidada");
                 }
            });

            function EliminaItem(id) {
                var datos = {};
                datos.CODIGO_DETALLE = id;
                $.ajax({
                    type: "POST",
                    url: "ComprobantesCompras.aspx/Elimina",
                    data: '{CCAB: ' + JSON.stringify(datos) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        alert("Registro eliminado");
                    },
                    error: function (response) {
                        if (response.length != 0)
                            alert(response);
                        console.log(response);

                    }
                });
            }

            function ConsultaUno(id) {
                var VC = {};
                VC.CODIGO_DETALLE =id;              
                $.ajax({
                    type: "POST",
                    url: "ComprobantesCompras.aspx/ListarUnItem",
                    data: '{com: ' + JSON.stringify(VC) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        for (var i = 0; i < data.d.length; i++) {

                            Operacion.mask('txtcodigodetalle').val(data.d[i].CODIGO_DETALLE);
                           Operacion.mask('txtruc').val(data.d[i].RUC);
                           Operacion.mask('txtproveedor').val(data.d[i].PROVEEDOR);
                           Operacion.mask('ddldocumento').val(data.d[i].TIPO_DOCUMENTO);
                           Operacion.mask('txtdocumento').val(data.d[i].NUM_DOCUMENTO);
                           Operacion.mask('txtglosacomprobante').val(data.d[i].GLOSA_COMPROBANTE);
                           Operacion.mask('txtglosamovimiento').val(data.d[i].GLOSA_MOVIMIENTO);
                           Operacion.mask('txtfechaemision').val((moment(data.d[i].FECHA_EMISION).format("DD/MM/YYYY")));
                           Operacion.mask('txtfechavmto').val((moment(data.d[i].FECHA_VENCIMIENTO).format("DD/MM/YYYY")));
                           Operacion.mask('txtmontoigv').val(Operacion.mround(Number(data.d[i].MONTO_IGV), 2));
                           Operacion.mask('txtigv').val(Operacion.mround(Number(data.d[i].IGV), 2));
                           Operacion.mask('txtcodigoproveedor').val(Operacion.mround(Number(data.d[i].CODIGO_PROVEEDOR), 2));
                           Operacion.mask('txtimportetotal').val(Operacion.mround(Number(data.d[i].TOTAL), 2));
                           Operacion.mask('ddloarea').val(data.d[i].AREA);
                           LlenarCuenta();
                           Operacion.mask('ddlmotivo').val(data.d[i].CUENTA);
                           ConsultaDatosCuenta();                           
                           Operacion.mask('txtanexore').val(data.d[i].ANEXO_REFERENCIA);
                           Operacion.mask('txtanexore2').val(data.d[i].ANEXO_REF2);
                           Operacion.mask('txtfecven').val(data.d[i].FECHA_VEN!=null? (moment(data.d[i].FECHA_VEN).format("DD/MM/YYYY")):"");
                           Operacion.mask('txtcodcencos').val(data.d[i].CENCOS);
                           Operacion.mask('ddlmedpag').val(data.d[i].MEDIOPAG);
                           Operacion.mask('ddldocre2').val(data.d[i].TIPO_REF2);
                           Operacion.mask('txtfechaanexore2').val(data.d[i].FECHA_REF2!= null? (moment(data.d[i].FECHA_REF2).format("DD/MM/YYYY")):"");
                           Operacion.mask('lblanexo').text(data.d[i].DVANEXO)
                           Operacion.mask('ddlanexo').val((data.d[i].DVANEXO != "P" || data.d[i].DVANEXO != "T")? data.d[i].ANEXO : "" )
                        }
                    },
                    error: function (response) {
                        if (response.length != 0)
                            console.log(response);
                    }
                });

            }

            $(".Finalizar").click(function () {
                //if (Operacion.mask('lblestado').text() != "L") {
                    //if(Number(Operacion.mask('txtmontodeclarado').val())==Number(Operacion.mask('lbltotal').text())){
                        ActualizaEstado();

                    //}
                    //else {
                    //    alert("No es posible la operación debido a que el total no coincide con el monto declarado");
                    //}
                   
               // }
                //else {
                //    alert("No es posible esta operación debido a que la solicitud se encuentra Liquidada");
                //}
               
            });
            function ActualizaEstado() {
                var datos = {};
                datos.ORDEN_NUMERO = Operacion.mask('lblsolicitud').text();
                datos.CODIGO_CAJA = Operacion.mask('lblcodtipo').text();
                datos.ESTADO = "L";
                datos.MONTO_DECLARADO = Operacion.mask('lbltotal').val();
                $.ajax({
                    type: "POST",
                    url: "ComprobantesCompras.aspx/ActualizarEstado",
                    data: '{COM: ' + JSON.stringify(datos) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        alert("Registro finalizado");
                        Operacion.mask('txtcodigodetalle').val("")
                        $("#NuevoItem").dialog('close');
                            },
                    error: function (response) {
                        if (response.length != 0)
                            alert(response);
                        console.log(response);

                    }
                });
            }
            $(".llenarcta").change(function () {

                 LlenarCuenta();
            });
            function LlenarCuenta() {
                Operacion.mask('ddlmotivo').find("option").remove();
                var DATA = {};
                DATA.AF_COD = "AC";
                DATA.AF_TDESCRI2 = Operacion.mask('ddloarea').val();
                
                $.ajax({
                    type: "POST",
                    url: "ComprobantesCompras.aspx/cuentasrendicion",
                    data: '{DATA:' + JSON.stringify(DATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        
                            Operacion.mask('ddlmotivo').append($('<option>', {
                                value: "",
                                text: "SELECCIONE...",
                            }));
                      
                        $.each(data.d, function (i, v) {
                            Operacion.mask('ddlmotivo').append($('<option>', {
                                value: v.PCUENTA,
                                text: v.PDESCRI,
                            }));
                        });
                    },
                    error: function (response) {
                        console.log(response);
                    }
                });
            }

            function Llenartipoanexo(anexo) {
                Operacion.mask('txtanexore').find("option").remove();
                var DATA = {};
                DATA.AVANEXO = anexo;
                
                $.ajax({
                    type: "POST",
                    url: "ComprobantesCompras.aspx/anexor",
                    data: '{DTA:' + JSON.stringify(DATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        $.each(data.d, function (i, v) {
                            Operacion.mask('txtanexore').append($('<option>', {
                                value: v.ACODANE,
                                text: v.ACODANE + " - " + v.ADESANE,
                            }));
                        });
                    },
                    error: function (response) {
                        console.log(response);
                    }
                });
            }

            function Llenartipoanexo1(anexo) {
                Operacion.mask('ddlanexo').find("option").remove();
                var DATA = {};
                DATA.AVANEXO = anexo;

                $.ajax({
                    type: "POST",
                    url: "ComprobantesCompras.aspx/anexor",
                    data: '{DTA:' + JSON.stringify(DATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        $.each(data.d, function (i, v) {
                            Operacion.mask('ddlanexo').append($('<option>', {
                                value: v.ACODANE,
                                text: v.ACODANE + " - " + v.ADESANE,
                            }));
                        });
                    },
                    error: function (response) {
                        console.log(response);
                    }
                });
            }

            $(".ConsultaCta").change(function () {

                ConsultaDatosCuenta();
            });

            function ConsultaDatosCuenta() {
                $.ajax({
                    type: "POST",
                    url: "ComprobantesCompras.aspx/ConsultaUnaCuenta",
                    data: '{descri: ' + Operacion.mask('ddlmotivo').val() + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        for (var i = 0; i < data.d.length; i++) {
                            Operacion.mask('lblanexo').text(data.d[i].PVANEXO.trim());
                            if (data.d[i].PVANEXO.trim() != "T" && data.d[i].PVANEXO.trim() != "P") {
                                Llenartipoanexo1(data.d[i].PVANEXO);
                            }
                            else {
                                Llenartipoanexo1("()")                               
                            }

                            if (data.d[i].PVDOCREF.trim()=="S" || data.d[i].PVDOCREF.trim()=="") {
                               // Operacion.mask('txtanexore').attr("disabled", false);
                                Llenartipoanexo("R")
                            }
                            else {
                                Llenartipoanexo("()")
                            // Operacion.mask('txtanexore').attr("disabled", true);
                                                            }
                            if (data.d[i].PVFECVEN.trim() == "S" || data.d[i].PVFECVEN.trim() =="") {
                                Operacion.mask('txtfechaven').attr("disabled", false);
                            }
                            else {
                                Operacion.mask('txtfechaven').val("");
                                Operacion.mask('txtfechaven').attr("disabled", true);
                            }
                            if (data.d[i].PVCENCOS.trim() == "S" || data.d[i].PVCENCOS.trim() =="" ) {
                                Operacion.mask('txtcodcencos').attr("disabled", false);
                                Operacion.mask('txtcencos').attr("disabled", false);
                            }
                            else {
                                Operacion.mask('txtcodcencos').val("");
                                Operacion.mask('txtcencos').val("");
                                Operacion.mask('txtcodcencos').attr("disabled", true);
                                Operacion.mask('txtcencos').attr("disabled", true);

                            }
                            if (data.d[i].PVDOCRE2.trim() == "S" || data.d[i].PVDOCRE2.trim() =="") {
                                Operacion.mask('txtanexore2').attr("disabled", false);
                                Operacion.mask('txtfechaanexore2').attr("disabled", false)
                                Operacion.mask('ddldocre2').attr("disabled", false);
                                Llenaranexo2("06");
                            }
                            else {
                                Operacion.mask('txtanexore2').val("");
                                Operacion.mask('txtfechaanexore2').val("");
                                Operacion.mask('txtanexore2').attr("disabled", true);
                                Operacion.mask('txtfechaanexore2').attr("disabled", true);
                                Llenaranexo2("XYZR");
                                Operacion.mask('ddldocre2').attr("disabled", true);
                            }
                            if (data.d[i].PVMEDPAG.trim() == "S" || data.d[i].PVMEDPAG.trim() =="") {
                                Operacion.mask('ddlmedpag').attr("disabled", false);

                            }
                            else {
                                Operacion.mask('ddlmedpag').val("");
                                Operacion.mask('ddlmedpag').text("");
                                Operacion.mask('ddlmedpag').attr("disabled", true);

                            }
                           
                        }
                    },
                    error: function (response) {
                        if (response.length != 0)
                            console.log(response);
                    }
                });
            }

            function Llenaranexo2(ANEXO) {
                Operacion.mask('ddldocre2').find("option").remove();
                var DATA = {};
                DATA.TCOD =ANEXO;
               
                $.ajax({
                    type: "POST",
                    url: "ComprobantesCompras.aspx/LISTARVARIOSED",
                    data: '{TABG:' + JSON.stringify(DATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {

                        Operacion.mask('ddldocre2').append($('<option>', {
                            value: "",
                            text: "SELECCIONE...",
                        }));

                        $.each(data.d, function (i, v) {
                            Operacion.mask('ddldocre2').append($('<option>', {
                                value: v.TCLAVE.trim(),
                                text: v.TDESCRI,
                            }));
                        });
                    },
                    error: function (response) {
                        console.log(response);
                    }
                });
            }

            function SUBDIARIO() {
                var subd = "";
                var PDATA = {};
                PDATA.AF_COD = "CS";
                PDATA.AF_TDESCRI1 = Operacion.mask('ddldocumento').val();
                $.ajax({
                    type: "POST",
                    url: "ComprobantesCompras.aspx/ObtenerSubdiario",
                    data: '{PDATA:' + JSON.stringify(PDATA) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        subd = data.d;
                    },
                    error: function (data) {
                        if (data.length != 0)
                            alert(data);
                    }
                });
                return { subd };
                }
            
            //$(".calculodif").change(function ()
            //{
            //   Operacion.mask('lbldiferencia').text(Number(Operacion.mask('lblmonto').text()) - Number(Operacion.mask('txtmontodeclarado').val()));
            //});
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
                Operacion.mask('txtanexore').val("");
                Operacion.mask('txtanexore2').val("");
                Operacion.mask('txtfecven').val("");
                Operacion.mask('txtcodcencos').val("");
                Operacion.mask('txtcencos').val("");
                Operacion.mask('ddlmedpag').val("");
                Operacion.mask('txtfechaanexore2').val("");
                Operacion.mask('ddldocre2').find("option").remove();
                Operacion.mask('ddlmedpag').find("option").remove();
                Operacion.mask('ddlanexo').find("option").remove();
                Operacion.mask('lblanexo').text("");
                Operacion.mask('ddlmotivo').val("");
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
        .auto-style10 {
            height: 19px;
        }
        .auto-style11 {
            height: 19px;
            width: 90px;
        }
        .auto-style12 {
            width: 90px;
        }
        .auto-style13 {
            height: 15px;
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
                        &nbsp;</td>
                    <td>
                        
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblusuario" runat="server" Text="" style="display:none"></asp:Label>
                   
                    </td>
                </tr>
                <tr>
                    <td>
                       
                    </td>
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
                                    <asp:BoundField DataField="COD_SOLICITANTE" HeaderText="COD. SOLIC." />
                                    <asp:BoundField DataField="SOLICITANTE" HeaderText="SOLICITANTE">
                                        
                                           <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MOTIVO" HeaderText="MOTIVO" >
                                        
                                        </asp:BoundField>
                                    <asp:BoundField DataField="MONEDA" HeaderText="MONEDA" />
                                    <asp:BoundField DataField="MONTO" HeaderText="MONTO" />


                                    <asp:BoundField DataField="ESTADO" HeaderText="ESTADO" >
                                       
                                        </asp:BoundField>


                                    <asp:TemplateField HeaderText="LIQUIDAR">


                                        <ItemTemplate>
                                            <div class="modificar" style="text-align: center">
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
                     <td class="auto-style13">
                         Monto:
                     </td>
                     <td class="auto-style13">
                          <asp:Label ID="lblmoneda" runat="server" Text=""></asp:Label>-
                         <asp:Label ID="lblmonto" runat="server" Text="">  </asp:Label>
                         <asp:Label ID="lblestado" runat="server" Text="" style="display:none"></asp:Label>
                     </td>
                  
                  
                 </tr>
             </table>
             </fieldset>

         <fieldset class="cont_sel">
                    <legend>Datos del Comprobante</legend>
             <table>
                 <tr>
                     <td>
                         Código Proveedor:
                     </td>
                     <td>
                         <asp:TextBox ID="txtcodigoproveedor" runat="server" class="glosas"></asp:TextBox>
                         <asp:TextBox ID="txtproveedor" runat="server" Width="197px" class="glosas"></asp:TextBox>
                     </td>
                     <td>
                         R.U.C.
                     </td>
                     <td>
                         <asp:TextBox ID="txtruc" runat="server"></asp:TextBox>
                         <asp:TextBox ID="txtcodigodetalle" runat="server" style="display:none"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td>Documento&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                      <td><asp:DropDownList ID="ddldocumento" runat="server" Height="16px" Width="200px" class="glosas"></asp:DropDownList> 
                          <asp:TextBox ID="txtdocumento" runat="server" class="glosas"></asp:TextBox>
                      </td>
                     <%--<td>Anexo Ref:</td>--%>
                     <td>
                         <asp:TextBox ID="txtanexoref" runat="server" style="display:none"></asp:TextBox> </td>
                 </tr>
                 <tr>
                     <td>Fecha Emisión&nbsp;&nbsp;&nbsp; : </td>
                      <td> <asp:TextBox ID="txtfechaemision" runat="server"></asp:TextBox></td>
                      <td>Fecha Vmto:</td>
                      <td>
                          <asp:TextBox ID="txtfechavmto" runat="server"></asp:TextBox> </td>
                 </tr>
                 <tr>
                     <td>Importe Parcial&nbsp; :</td>
                      <td>
                          <asp:TextBox ID="txtimportetotal" runat="server" class="IGVCHAN">0.00</asp:TextBox></td>
                      
                     <td class="auto-style10"> <asp:CheckBox ID="chkigv" runat="server" class="IGVCH" /> %IGV</td>
                      <td class="auto-style10"><asp:TextBox ID="txtigv" runat="server" ReadOnly="true" Text="18"></asp:TextBox> </td>                     
                 </tr>
                 <tr>
                      <td class="auto-style10">Monto IGV&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; : </td>
                      <td class="auto-style10">
                          <asp:TextBox ID="txtmontoigv" runat="server" ReadOnly="true" >0.00</asp:TextBox> </td>

                    
                      
                      <td><asp:TextBox ID="txtanexoigv" runat="server" style="display:none" ></asp:TextBox> </td>
                 </tr>
                 <%--<tr>
                     <td>Tipo de Conversión:</td>
                      <td><asp:DropDownList ID="ddltipodeconversion" runat="server" Height="16px" Width="200px" class="tipocambio"></asp:DropDownList> 
                      <asp:TextBox ID="txttipocambio" runat="server" ReadOnly="true"></asp:TextBox> </td>
                 </tr>--%>
                 <tr>
                     <td>Observacion 1&nbsp;&nbsp; :</td>
                     <td>
                         <asp:TextBox ID="txtglosacomprobante" runat="server"></asp:TextBox> </td>
                     <td>Observacion 2: </td>
                     <td><asp:TextBox ID="txtglosamovimiento" runat="server" Width="123px"></asp:TextBox> </td>
                 </tr>
             <%--</table>
             <table>--%>
                 <tr>
                     
                     <td>Area&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                     <td>
                         <asp:DropDownList ID="ddloarea" runat="server" Height="16px" Width="319px" class="llenarcta">
                             <asp:ListItem>SELECCIONAR</asp:ListItem>
                         </asp:DropDownList></td>
                                         
                 </tr>
             </table>
             <table>
                 <tr>
                     <td>Datos Motivos</td>
                 </tr>
                 <tr>
                     <td>
                         Motivo:
                     </td>
                     <td>
                         <asp:DropDownList ID="ddlmotivo" runat="server" Height="19px" Width="248px" class="ConsultaCta"></asp:DropDownList>
                     </td>

                 </tr>
               
                 <tr>
                     <td class="auto-style10">Centro de Costo</td>
                     <td class="auto-style10">
                         <asp:TextBox ID="txtcodcencos" runat="server" Width="247px"></asp:TextBox></td>
                     <td class="auto-style11"></td>
                     <td class="auto-style10">
                         <asp:TextBox ID="txtcencos" runat="server" Width="259px"></asp:TextBox>
                     </td>
                     </tr>
                 <tr>
                     <td>
                         Dcmto.Ref.
                     </td>
                     <td>
                         <asp:DropDownList ID="ddldocre2" runat="server" Height="16px" Width="248px"></asp:DropDownList>
                     </td>

                 </tr>
                 <tr>
                     <td>Dcmto.Ref.</td>
                     <td>
                         <asp:TextBox ID="txtanexore2" runat="server" Width="104px"></asp:TextBox> 
                         Fecha:
                         <asp:TextBox ID="txtfechaanexore2" runat="server" Width="98px" placeholder="00/00/0000"></asp:TextBox>
                     </td>
                     <td class="auto-style12">Medio de Pago:</td>
                     <td>
                         <asp:DropDownList ID="ddlmedpag" runat="server" Height="16px" Width="261px"></asp:DropDownList> </td>
                 </tr>
                   <tr>
                    <td>Anexo</td>
                      <td>
                         <asp:DropDownList ID="ddlanexo" runat="server" Height="17px" Width="244px"   >
                         </asp:DropDownList>
                     </td>
                       <td>
                           <asp:Label ID="lblanexo" runat="server" Text=""></asp:Label>
                       </td>
                       <td>
                         <asp:DropDownList ID="txtanexore" runat="server" Height="17px" Width="244px" style="display:none"  >
                         </asp:DropDownList>
                       </td>
                    
                   
                     <td class="auto-style10">
                         <asp:TextBox ID="txtfechaven" runat="server" Width="257px" placeholder="00/00/0000" style="display:none" ></asp:TextBox> </td>
                 </tr>
             </table>
             
                </fieldset>
          <table>
            <tr>
                <td>
                    <input id="btngrabar" type="button" value="Grabar" class="grabar"/> 
                    
                 </td>
                <td>
                    <input id="btnfinal" type="button" value="Finalizar" class="Finalizar"/> 
                     </td>
            </tr>
        </table>
           
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
                                    <asp:TemplateField HeaderText="MODIFICAR">
                                         <ItemTemplate>
                                            <div class="editar" style="text-align: center">
                                                <img alt="" src="../../../Images/edit.png" width="25" style="cursor: pointer" />
                                                <%--<asp:ImageButton ID="imbeliminar" runat="server" ImageUrl="~/Images/Message_Error.png" Width="25px" OnClick="ib_eliminar_Click" onclientclick="javascript:return confirm('Esta Seguro?')"/>--%>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="ELIMINAR">
                                         <ItemTemplate>
                                            <div class="Elimina" style="text-align: center">
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
            <tr>
                
                <td>
                    TOTAL:  
                    <asp:Label ID="lbltotal" runat="server" Text=""></asp:Label></td>
            </tr>
        </table>
    </div>
  
</asp:Content>


