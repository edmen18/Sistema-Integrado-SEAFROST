<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ARaprobacion.aspx.cs" Inherits="Default2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link type="text/css" href="../CSS/Base-s.css?1.9" rel="stylesheet" />

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

            var filtro = function () {
                var dd = 0;
                //Agregar el comportamiento al texto (se selecciona por el ID) 
                $("#MainContent_txtfiltra").keyup(function () {
                    var upp = $(this).val().toUpperCase();
                    var s = upp.split(" ");
                    $(".filtrar tr").show();
                    $.each(s, function () {
                        $(".filtrar tr:visible .producto:not(:contains('" + this + "'))").parent().hide() && $(".filtrar tr:visible .proveed:not(:contains('" + $('#MainContent_txtfiltra0').val() + "'))").parent().hide();
                    });
                });
            }



            var filtro2 = function () {
                var dd = 0;
                //Agregar el comportamiento al texto (se selecciona por el ID) 
                $("#MainContent_txtfiltra0").keyup(function () {
                    var upp = $(this).val().toUpperCase();
                    var s = upp.split(" ");
                    $(".filtrar tr").show();
                    $.each(s, function () {
                        $(".filtrar tr:visible .proveed:not(:contains('" + this + "'))").parent().hide() && $(".filtrar tr:visible .producto:not(:contains('" + $('#MainContent_txtfiltra').val() + "'))").parent().hide();
                    });

                });
            }
            filtro2();
            filtro();




            $("#MainContent_btbuscar").hide();

            contarndw = 0;
            cc = 1;
            sw_edicion = 0;
            sw_nuevo = 0;
            sw_plan = 0;
            contaditem = 0; contaditemplan = 0;
            guardartmp = [];
            sindatosimport = 0;
            gsumadolaresf = 0; gsumasolesf = 0;
            $(".bttimp").hide();
            $(".btplan").hide();
            $(function () {
                UHTML.id = 'MainContent';
                Operacion.iValida(Operacion.mask("txtdcant"), 1);
            });


        });

    </script>
        <script type="text/javascript">
        $(function () {
            $('#dvasiento').dialog({
                autoOpen: false,
                modal: true,
                resizable: true,
                width: 430,
                heigth: 50,
                title: 'Asignacion de Cuenta Contable',
                close: function (event, ui) {
                },
            }
           );

            $('#dvaprobaciones').dialog({
                autoOpen: false,
                modal: true,
                resizable: true,
                width: 430,
                heigth: 50,
                title: 'Usuarios Aprobaciones',
                open: function (event, ui) {
                    Listausuarioproducto(idproductogenal);
                },
                close: function (event, ui) {
                },
            }
            );
            $('#dvhistorico').dialog({
            autoOpen: false,
            modal: true,
            resizable: true,
            width: 600,
            heigth: 50,
            title: 'HISTORIAL DEL SERVICIO',
            open:function(event,ui){
                //Listausuarioproducto(idproductogenal);
            },
            close: function (event, ui) {
            },
            });
            
        });

    </script>

    <script type="text/javascript">
        $(function () {
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
                                                     id: item.TC_CEXISTE.trim()
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
                                     if (ui.item == null || ui.item == undefined) {
                                         $("#MainContent_txtidcuenta").val("");
                                         $(".clcuenta").focus();
                                         alert("No ha seleccionado El item");
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

        function Rvalidausuarionivel(numnivel) {
            rtdatoa = "";
            $.ajax({
                type: "POST",
                url: "ARaprobacion.aspx/Validausuarioniv",
                data: "{usua: '" + $("#hfusu").val() + "',numnivel:"+numnivel+"}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    rtdatoa = data.d;
                },
                error: function (data) {
                    if (data.length != 0)
                        alert(data);
                }
            });
            return { rtdatoa };
        }

        function Rvalidausuariocuenta() {
            rtdatoa = "";
            $.ajax({
                type: "POST",
                url: "ARaprobacion.aspx/Validausuariocuenta",
                data: "{usua: '" + $("#hfusu").val() + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    rtdatoa = data.d;
                },
                error: function (data) {
                    if (data.length != 0)
                        alert(data);
                }
            });
            return { rtdatoa };
        }

        function ExtraeDcuenta(codcuenta) {
            rtdatoa = "";
            $.ajax({
                type: "POST",
                url: "ARaprobacion.aspx/Extraeunacuenta",
                data: "{ncuenta: '" + codcuenta + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    rtdatoa = data.d;
                },
                error: function (data) {
                    if (data.length != 0)
                        alert(data);
                }
            });
            return { rtdatoa };
        }

        function Validaaprobxusuario(codigoprod) {
            rtdatoa = "";
            var parm = {};
            parm.DA_IDUSUA = $("#hfusu").val();
            parm.DA_CODIGO = codigoprod;

            $.ajax({
                type: "POST",
                url: "ARaprobacion.aspx/Extraenaprob",
                data: '{parm: ' + JSON.stringify(parm) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    rtdatoa = data.d;
                },
                error: function (data) {
                    if (data.length != 0)
                        alert(data);
                }
            });
            return { rtdatoa };
        }


        function NAprobxarea(codigoprod) {
            rtdatoa = "";
            //var parm = {};
            //parm.DA_CODIGO = codigoprod;

            $.ajax({
                type: "POST",
                url: "ARaprobacion.aspx/Subareasnaprob",
                data: "{codprod: '" + codigoprod + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    rtdatoa = data.d;
                },
                error: function (data) {
                    if (data.length != 0)
                        alert(data);
                }
            });
            return { rtdatoa };
        }

        function TotalAprobaciones(codigoprod) {
            rtdatoa = "";
            var parm = {};
            //parm.DA_IDUSUA = $("#hfusu").val();
            parm.DA_CODIGO = codigoprod;

            $.ajax({
                type: "POST",
                url: "ARaprobacion.aspx/Extraenaprobtotal",
                data: '{parm: ' + JSON.stringify(parm) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    rtdatoa = data.d;
                },
                error: function (data) {
                    if (data.length != 0)
                        alert(data);
                }
            });
            return { rtdatoa };
        }


        function Nareasusuario(codarea) {
            rtdatoa = "";
            $.ajax({
                type: "POST",
                url: "ARaprobacion.aspx/Subareanusua",
                data: "{codusua: '" + $("#hfusu").val() + "',codarea:'" + codarea + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    rtdatoa = data.d;
                },
                error: function (data) {
                    if (data.length != 0)
                        alert(data);
                }
            });
            return { rtdatoa };
        }

        function ActulizaEstadoAR(codigoprod,estado) {
            var INF = {};
            INF.AR_CCODIGO = codigoprod;
            INF.AR_CCONTRO = estado;
            $.ajax({
                type: "POST",
                url: "ARaprobacion.aspx/ActualizaEstado",
                data: '{INF: ' + JSON.stringify(INF) + '}',
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


        function ActulizacuentaAR(codigoprod) {
            var INF = {};
            INF.AR_CCODIGO = codigoprod;
            INF.AR_CCUENTA = $(".clidcuenta").val();
            INF.AR_CINFTEC = $("#hfusu").val();
            $.ajax({
                type: "POST",
                url: "ARaprobacion.aspx/Actualizacuenta",
                data: '{INF: ' + JSON.stringify(INF) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (response) {
                    alert("Se actualizo correctamente");
                    $("#dvasiento").dialog('close');
                },
                error: function (response) {
                    if (response.length != 0)
                        console.table(response);
                }
            });
        }


        function InsertadetalleAprob(codigoprod) {

            var INF = {};
            INF.AR_CCODIGO = codigoprod;
            INF.AR_CCONTRO = "A";
            $.ajax({

                type: "POST",
                url: "ARaprobacion.aspx/ActualizaEstado",
                data: '{INF: ' + JSON.stringify(INF) + '}',
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


        function Insertadetalleprodusua(codigoprod) {

            var horao = obetenerhora();
            var fecactual = moment($("#MainContent_hfactual").val(), "DD/MM/YYYY");
            fecactual = fecactual == null ? null : new Date(fecactual);

            var INF = {};
            INF.DA_CODIGO = codigoprod;
            INF.DA_IDUSUA = $("#hfusu").val();
            INF.DA_FECHA = fecactual;
            INF.DA_HORA = horao;
            $.ajax({

                type: "POST",
                url: "ARaprobacion.aspx/Insertadetallprodusua",
                data: '{INF: ' + JSON.stringify(INF) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (response) {
                    alert("Se Actualizo la Informacion");
                },
                error: function (response) {
                    if (response.length != 0)
                        console.table(response);
                }
            });
        }

        function EnvioFinalemail(codigoprod) {


            $.ajax({

                type: "POST",
                url: "ARaprobacion.aspx/enviofinalemail",
                data: "{idusuario: '" + $("#hfusu").val() + "',idprod:'"+codigoprod+"'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (response) {
                    alert("Se envio email para su aprobacion Final");
                },
                error: function (response) {
                    if (response.length != 0)
                        console.table(response);
                }
            });
        }

        function Eliminaadetalleprodusua(codigoprod) {

            var horao = obetenerhora();
            var fecactual = moment($("#MainContent_hfactual").val(), "DD/MM/YYYY");
            fecactual = fecactual == null ? null : new Date(fecactual);

            var INF = {};
            INF.DA_CODIGO = codigoprod;
            $.ajax({

                type: "POST",
                url: "ARaprobacion.aspx/eliminausuaprod",
                data: '{INF: ' + JSON.stringify(INF) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (response) {
                    //alert("Se Desaprobo el Servicio");
                },
                error: function (response) {
                    if (response.length != 0)
                        console.table(response);
                }
            });
        }


        function Listausuarioproducto(idproducto) {

  

            $.ajax({
                type: "POST",
                url: "ARaprobacion.aspx/listarusuariosaproba",
                data: "{idproducto: '" + idproducto + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.d.length > 0) {
                        var row = $("[id*=gvusuarios] tr:last-child").clone(true);
                        $("[id*=gvusuarios] tr").not($("[id*=gvusuarios] tr:first-child")).remove();

                        for (var i = 0; i < data.d.length; i++) {
                         
                            $("td", row).eq(0).html(data.d[i].DA_IDUSUA);
                            var fech= moment(data.d[i].DA_FECHA).format('DD/MM/YYYY');
                                $("td", row).eq(1).html( fech);
                                $("td", row).eq(2).html(data.d[i].DA_HORA);
                                $("[id*=gvusuarios]").append(row);
                                row = $("[id*=gvusuarios] tr:last-child").clone(true);
                            
                        }


                    } else {
                        var row = $("[id*=gvusuarios] tr:last-child").clone(true);
                        $("[id*=gvusuarios] tr").not($("[id*=gvusuarios] tr:first-child")).remove();

                        $("td", row).eq(0).html("");
                        $("td", row).eq(1).html("");
                        $("td", row).eq(2).html("");
         
                        $("[id*=gvusuarios]").append(row);
                        alert("no se encontro registro");
                    }
                },
                error: function (response) {
                    if (response.length != 0)
                        alert(response);
                }
            });

        }

        function Listahistoricoproducto(idproducto) {


            var CO0003MOVD = {};
            CO0003MOVD.OC_CCODIGO =idproducto;
            $.ajax({
                type: "POST",
                url: "ARaprobacion.aspx/HistoricoxProducto",
                data: '{CO0003MOVD: ' + JSON.stringify(CO0003MOVD) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.d.length > 0) {
                        var row = $("[id*=gvhistorico] tr:last-child").clone(true);
                        $("[id*=gvhistorico] tr").not($("[id*=gvhistorico] tr:first-child")).remove();

                        for (var i = 0; i < data.d.length; i++) {

                            $("td", row).eq(0).html(data.d[i].OC_CDESREF);
                            var fech = moment(data.d[i].OC_DFECDOC).format('DD/MM/YYYY');
                            $("td", row).eq(1).html(fech);
                            $("td", row).eq(2).html(data.d[i].OC_NTOTMN);
                            $("td", row).eq(3).html(data.d[i].OC_NTOTUS);

                            $("[id*=gvhistorico]").append(row);
                            row = $("[id*=gvhistorico] tr:last-child").clone(true);

                        }
                        $("#dvhistorico").dialog('open');

                    } else {
                        var row = $("[id*=gvhistorico] tr:last-child").clone(true);
                        $("[id*=gvhistorico] tr").not($("[id*=gvhistorico] tr:first-child")).remove();

                        $("td", row).eq(0).html("");
                        $("td", row).eq(1).html("");
                        $("td", row).eq(2).html("");

                        $("[id*=gvhistorico]").append(row);
                        alert("no se encontro registro");
                    }
                },
                error: function (response) {
                    if (response.length != 0)
                        alert(response);
                }
            });

        }

        function VerificaInfodeunArti(idarticulo) {
            var AR_CCUENTA = ""; var AR_CPARARA="";
            $.ajax({ 
                type: "POST",
                url: "ARaprobacion.aspx/ObtenerArticuloun",
                data: "{codarti: '" + idarticulo + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json", 
                async: false, 
                success: function (data) {
                    AR_CCUENTA = (data.d.AR_CCUENTA);
                    AR_CPARARA = (data.d.AR_CPARARA);
                },
                error: function (data) {
                    if (data.length != 0)
                        alert(data);
                }
            });
            return { AR_CCUENTA, AR_CPARARA };
        }



    </script>
    <script type="text/javascript">
        $(function () {
            $(".clusua").autocomplete(
                          {
                              source: function (request, response) {
                                  $.ajax({
                                      url: "USareas.aspx/listarusuarios",
                                      data: "{ nombre: '" + request.term + "'}",
                                      dataType: "json",
                                      type: "POST",
                                      contentType: "application/json; charset=utf-8",
                                      dataFilter: function (data) { return data; },
                                      success: function (data) {
                                          response($.map(data.d, function (item) {
                                              return {
                                                  value: item.TU_NOMUSU,
                                                  id: item.TU_ALIAS.trim()
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
                                  $('#MainContent_txtidusua').val(str);

                                  $('#MainContent_btbuscar').trigger('click');


                              },
                              change: function (event, ui) {
                                  if (ui.item == null || ui.item == undefined) {
                                      $("#MainContent_txtidusua").val("");
                                      $(".clusua").focus();
                                      alert("No ha seleccionado El usuario");
                                  }
                              }
                          });




        });

    </script>



    <script type="text/javascript">
        $(function () {
            $(".btbuscar").click(function () {
                filtarocompra();
            });
            $(".btimag").click(function (e) {

                var estadoa = $("#MainContent_ddlfilt").val();
                window.open("../ARTICULO/REPORTES/ReporteTarifario.aspx?et="+estadoa, '_blank');
              
            });

            $(".clidcuenta").change(function () {
                var info = ExtraeDcuenta($("#MainContent_txtidcuenta").val()).rtdatoa;
                if (info == "") {
                    alert("Cuenta no Existe" + String.fromCharCode(10));
                    $("#MainContent_txtcuenta").val("");
                    $(this).focus();
                    $(this).val("");
                }else{
                    $("#MainContent_txtcuenta").val(info);
                }
            });

            $(".btasig").click(function () {

                
                if ($(".clidcuenta").val() == "") {
                    alert("No ha ingresado el numero de cuenta");
                    $(".clidcuenta").focus();
                } else if ($(".clcuenta").val() == "") {
                    alert("No ha ingresado el nombre de la cuenta");
                    $(".clcuenta").focus();
                }else{
                    ActulizacuentaAR(codigoprodpo);
                }
            });

            $(".aco").click(function () { 
                var trp = $(this).parent().parent();
                var codigoprod = $("td:eq(0)", trp).html();
                codigoprodpo = codigoprod;
                var cuentasusua = Rvalidausuariocuenta().rtdatoa;

                if (cuentasusua == 0) { 
                    alert("Su Usuario no Puede Ingresar Cuenta");
                } else {
                    var rcuenta = VerificaInfodeunArti(codigoprod).AR_CCUENTA;
                    $(".clidcuenta").val(rcuenta.trim());
                    var nomcuenta = ExtraeDcuenta(rcuenta).rtdatoa;
                    $(".clcuenta").val(nomcuenta.trim());

                    var naprob = TotalAprobaciones(codigoprod).rtdatoa;
                    if (naprob > 0) {
                        $(".btasig").attr("disabled", true);
                        $(".clcuenta").attr("disabled", true);
                        $(".clidcuenta").attr("disabled", true);
                    } else { 
                        $(".btasig").attr("disabled", false);
                        $(".clcuenta").attr("disabled", false);
                        $(".clidcuenta").attr("disabled", false);
                    }
                    $("#dvasiento").dialog('open');
                }
            });
            

            $(".ap").click(function () {
                var trp = $(this).parent().parent();
                var codigoprod = $("td:eq(0)", trp).html();
                idproductogenal = codigoprod;
                var Nivelsusua = Rvalidausuarionivel(3).rtdatoa;
                var naprob = TotalAprobaciones(codigoprod).rtdatoa; 
                var areanvalida = NAprobxarea(codigoprod).rtdatoa;
                var rsubarea = VerificaInfodeunArti(codigoprod).AR_CPARARA;
                var naccesoarea = Nareasusuario(rsubarea).rtdatoa;
                var rcuenta = VerificaInfodeunArti(codigoprod).AR_CCUENTA;

                if (Nivelsusua == 0) {
                    alert("Su Usuario no Puede Aprobar Tarifas");
                } else if (naccesoarea == 0) {
                    alert("Su Usuario no tiene acceso a esta area");
                } else if (rcuenta.trim() == "") {
                    alert("Se Debe Asignar la cuenta para poder Aprobar");
                } else {
                    var validanum = Validaaprobxusuario(codigoprod).rtdatoa;

                        if (validanum == 0) {
                            if (confirm("Desea aprobar el Servicio?")) {

                                if (naprob == (Number(areanvalida) - 1) ) {
                                    ActulizaEstadoAR(codigoprod, "A");
                                        trp.remove();
                                }
                                if (naprob == (Number(areanvalida) - 2)) {
                                    EnvioFinalemail(codigoprod);
                                }

                                Insertadetalleprodusua(codigoprod);
                            }
                        } else {
                            alert("El usuario ya aprobo Tarifa");
                            $("#dvaprobaciones").dialog('open');
                        }
                    }
            });

            $(".his").click(function () {
                var trp = $(this).parent().parent();
                var codigoprod = $("td:eq(0)", trp).html();
                Listahistoricoproducto(codigoprod);
                
                
            });
            //$(".des").click(function () {
            //    var trp = $(this).parent().parent();
            //    var codigoprod = $("td:eq(0)", trp).html();
            //    var Nivelsusua = Rvalidausuarionivel(6).rtdatoa;//
            //    var naprob = TotalAprobaciones(codigoprod).rtdatoa;
            //    //var areanvalida = NAprobxarea(codigoprod).rtdatoa;
            //    var rsubarea = VerificaInfodeunArti(codigoprod).AR_CPARARA;//
            //    var naccesoarea = Nareasusuario(rsubarea).rtdatoa;//
            //    if (Nivelsusua == 0) {
            //        alert("Su Usuario no Puede Desaprobar Tarifas");
            //    } else if (naccesoarea == 0) {
            //        alert("Su Usuario no tiene acceso a esta area");
            //    } else if (naprob == 0) {
            //        alert("La Tarifa no cuenta con Aprobacion para Desaprobarla");
            //    } else {
            //        //var validanum = Validaaprobxusuario(codigoprod).rtdatoa;
            //        //if (validanum == 0) {
            //            if (confirm("Desea Desaprobar el Servicio?")) {
            //                //if (naprob == (Number(areanvalida) - 1)) {
            //                    ActulizaEstadoAR(codigoprod,"S"); 
            //                //}
            //                    Eliminaadetalleprodusua(codigoprod);
            //                    trp.remove();
            //            }
            //        //} else {
            //        //    alert("El usuario ya aprobo Tarifa");
            //        //}
            //    }
            //});


            $(".edi").click(function () {
                var trp = $(this).parent().parent();
                var codigoprod = $("td:eq(0)", trp).html();
                var Nivelsusua = Rvalidausuarionivel(2).rtdatoa;
                var naprob = TotalAprobaciones(codigoprod).rtdatoa;
                var areanvalida = NAprobxarea(codigoprod).rtdatoa;
                var rsubarea = VerificaInfodeunArti(codigoprod).AR_CPARARA;
                var naccesoarea = Nareasusuario(rsubarea).rtdatoa;
                var rcuenta = VerificaInfodeunArti(codigoprod).AR_CCUENTA;

                if (Nivelsusua == 0) {
                    alert("Su Usuario no Puede Editar Tarifas");
                } else if (naccesoarea == 0) {
                    alert("Su Usuario no tiene acceso a esta area");
                } else {
                    var naprob = TotalAprobaciones(codigoprod).rtdatoa;
                    //if (naprob == 0) {

                    Eliminaadetalleprodusua(codigoprod);
                    window.location.assign("../ARTICULO/ARingreso.aspx?idp=" + codigoprod.trim());

                    //} else {
                        //alert("La tarifa se encuentra Aprobada");
                    //}
                }
            });





            $("#MainContent_txtidpro").change(function () {
                if (Mostrarunproveedor($(this).val()).ee == "") {
                    alert("No se encontrol informacion");
                    $(this).focus();
                } else {
                    $("#MainContent_txtprove").val(Mostrarunproveedor($(this).val()).ee);
                    $("#MainContent_txtnumref").focus();
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
        .auto-style1 {
            height: 26px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:HiddenField runat="server" ID="hffactual" />
    <asp:HiddenField runat="server" ID="hfusu" />
    <div id="contenedor" style="float:left;width:1000px">
        <fieldset style="float:left;width:900px">
            <legend>APROBACION DE TARIFAS</legend>

            <table>

                <tr>
                    <td>Filtrar Por:
                          <asp:DropDownList runat="server" ID="ddlfilt" Width="230" OnSelectedIndexChanged="ddlfilt_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                
                     
                        <img id="btimaga" class="btimag" runat="server" width="25" height="25" src="~/Images/exel.jpg" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:TextBox runat="server" ID="txtfiltra" Width="300" placeholder="DESCRIPCION"></asp:TextBox>
                        <asp:TextBox runat="server" ID="txtfiltra0" Width="300" placeholder="PROVEEDOR"></asp:TextBox>
                    </td>
                </tr>

                <%--   <tr>
                    <td>
                        <asp:RadioButtonList ID="rbmovi" runat="server" RepeatDirection="Horizontal" Width="449px" OnSelectedIndexChanged="rbmovi_SelectedIndexChanged" AutoPostBack="true" >
                            <asp:ListItem Text="Entradas" Value="PE" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Salidas" Value="PS"></asp:ListItem>
                            <asp:ListItem Text="Ambos" Value="-1"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>--%>
                <tr>
                    <td colspan="4">
                        <div id="expo">
                        <asp:GridView ID="gvproductos" class="filtrar" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" Width="912px">
                            <Columns>
                                <asp:BoundField DataField="AR_CCODIGO" HeaderText="ID" ItemStyle-Width="100">
                                     <ItemStyle CssClass="id"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="AR_CDESCRI" HeaderText="DESCRIPCION" ItemStyle-Width="300">
                                    <ItemStyle CssClass="producto"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="AR_CUNIDAD" HeaderText="UNID" ItemStyle-Width="100"  ItemStyle-HorizontalAlign="center" />
                                <asp:BoundField DataField="AR_NPRECOM" HeaderText="TARIFA" ItemStyle-Width="100" ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField DataField="AR_CMONCOM" HeaderText="MON" ItemStyle-Width="100" ItemStyle-HorizontalAlign="center">
                                    <ItemStyle CssClass="moneda"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="AR_CPARARA" HeaderText="AREA" ItemStyle-Width="100" />
                                <asp:BoundField DataField="AR_CCONTRO" HeaderText="ESTADO" ItemStyle-Width="100" />
                                <asp:BoundField DataField="AR_CUSUCRE" HeaderText="USUARIO" ItemStyle-Width="100" /> 
                                <asp:BoundField DataField="AR_CCODPRO" HeaderText="PROVEEDOR" ItemStyle-Width="220" > 
                                 <ItemStyle CssClass="proveed"></ItemStyle>
                                    </asp:BoundField>
                                <asp:TemplateField ItemStyle-Width="11px" HeaderText="APR"> 
                                    <ItemTemplate>
                                        <div class="ap" style="text-align: center">
                                            <div>
                                                <img alt="" src="../Images/Message_Success.png" width="25" style="cursor: pointer" />
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>



                                <asp:TemplateField ItemStyle-Width="11px" HeaderText="CTA">
                                    <ItemTemplate>
                                        <div class="aco" style="text-align: center">
                                            <div> 
                                                <img alt="" src="../Images/Detalle.png" width="25" style="cursor: pointer" />
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField> 

                                  <asp:TemplateField ItemStyle-Width="11px" HeaderText="EDI">
                                    <ItemTemplate>
                                        <div class="edi" style="text-align:center">
                                            <div> 
                                                <img alt="" src="../Images/edicion02.png" width="25" style="cursor: pointer" />
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField> 

                                      <asp:TemplateField ItemStyle-Width="11px" HeaderText="HIS">
                                    <ItemTemplate>
                                        <div class="his" style="text-align: center">
                                            <div>
                                                <img alt="" src="../Images/historial.png" width="25" style="cursor: pointer" />
                                            </div>
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
                <%--       <tr>
                    
                    <td>Codigo Almacen</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlalma" Width="350" ></asp:DropDownList> 
                    </td>
                </tr>--%>
            </table>
        </fieldset>
        <table>
            <tr>
                <td>

                    <div id="dvp" style="display: compact">
                        <%--<asp:Button class="btn" Text="Buscar" runat="server" ID="btbuscar" Enabled="true" OnClick="btbuscar_Click"></asp:Button>--%>
                    </div>

                </td>
            </tr>
        </table>
    </div>
    <div id="dvasiento" style="display:none">
        <table>
            <tr>
                <td>Cuenta Contable</td>
            </tr>
            <tr>
                
                <td>
                    <asp:TextBox runat="server" ID="txtcuenta" class="clcuenta" Width="300" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtidcuenta" Width="100"  class="clidcuenta"/>
                </td>
            </tr>
            <tr>
                <td colspan="3" class="auto-style1"></td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: center" >
                    <asp:Button Text="Asignar" runat="server" ID="txtas" class="btasig btn" Width="179px" Enabled="true" />
                </td>
            </tr>
        </table>
    </div>

    <div id="dvaprobaciones" style="display:none">
        <table>
            <tr>
                <td>Servicio Aprobado Por</td>
                 </tr>
            <tr>
                <td colspan="3" >
                    <asp:GridView ID="gvusuarios" class="filtrar" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" Width="359px">
                            <Columns>
                                <asp:BoundField DataField="" HeaderText="USUARIO" ItemStyle-Width="200">
                                     <ItemStyle CssClass="DA_IDUSUA"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="DA_FECHA" HeaderText="FECHA" ItemStyle-Width="100">
                                    <ItemStyle CssClass="FECHA"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="DA_HORA" HeaderText="HORA" ItemStyle-Width="100" />
                                
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

      <div id="dvhistorico" style="display:none">
        <table>

            <tr>
                <td colspan="3" >
                    <asp:GridView ID="gvhistorico" class="filtrar" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" Width="576px">
                            <Columns>
                                <asp:BoundField DataField="OC_CDESREF" HeaderText="SERVICIO" ItemStyle-Width="300">
                                     <ItemStyle CssClass="OC_CDESREF"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="OC_DFECDOC" HeaderText="FECHA DOC" ItemStyle-Width="80">
                                    <ItemStyle CssClass="FECHA"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="OC_NTOTMN" HeaderText="PRECIO SOLES" ItemStyle-Width="70"  ItemStyle-HorizontalAlign="Right"/>
                                 <asp:BoundField DataField="OC_NTOTUS" HeaderText="PRECIO DOLARES" ItemStyle-Width="80" ItemStyle-HorizontalAlign="Right" />
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



</asp:Content>

