<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MantenimientoBitacora.aspx.cs" Inherits="MantenimientoBitacora" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link type="text/css" href="../../CSS/Base-s.css?2.0" rel="stylesheet" />

    <script type="text/javascript">

       
        //function ModifyEnterKeyPressAsTab(event, info) {

        //    if (event.keyCode == 13) {
        //        cb = parseInt($(info).attr('tabindex'));
        //        cb2 = cb + 1;
        //        if ($(':input[TabIndex=\'' + (cb2) + '\']') != null) {
        //            if ($(':input[TabIndex=\'' + (cb2) + '\']').attr("disabled") == false) {

        //                $(':input[TabIndex=\'' + (cb2) + '\']').focus();
        //                $(':input[TabIndex=\'' + (cb2) + '\']').select();
        //            } else {
        //                $(':input[TabIndex=\'' + (cb2 + 1) + '\']').focus();
        //                $(':input[TabIndex=\'' + (cb2 + 1) + '\']').select();
        //            }
        //            event.preventDefault();
        //            return false;
        //        }
        //    }
        //}




       

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

            $('#dvatender').dialog({
                autoOpen: false,
                modal: true,
                resizable: true,
                width: 800,
                heigth: 50,
                title: 'Atender Solicitud',
                close: function (event, ui) {
                },
                open: function (event, ui) {
                    vfg = 1;
                    var lrow = $("[id*=gvlotexvale] tr:last-child").clone(true);
                    $("[id*=gvlotexvale] tr").not($("[id*=gvlotexvale] tr:first-child")).remove();
                    $("td", lrow).eq(0).html("");
                    $("td", lrow).eq(1).html("");
                    $("td", lrow).eq(2).html("");
                    $("td", lrow).eq(3).html("");
                    $("td", lrow).eq(4).html("");
                    $("td", lrow).eq(5).html("");
                    $("td", lrow).eq(6).html("");
                    $("td", lrow).eq(7).html("");
                    $("[id*=gvlotexvale]").append(lrow);
                    lrow = $("[id*=gvlotexvale] tr:last-child").clone(true);

                }
            });

            $('#dvimprimeml').dialog({
                autoOpen: false,
                modal: true,
                resizable: true,
                width: 300,
                heigth: 80,
                title: 'Impresion',
                close: function (event, ui) { },
            });

            $('#serie').dialog({
                autoOpen: false,
                modal: true,
                resizable: true,
                width: 430,
                heigth: 50,
                title: 'Lotes',
                close: function (event, ui) {
                },
            }
);


            $('#dvdetalle').dialog({
                autoOpen: false,
                modal: true,
                resizable: true,
                width: 600,
                heigth: 50,
                //margin:0 auto,
                title: 'Detalle de Solicitud',
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
                open: function (event, ui) {
                    //Listausuarioproducto(idproductogenal);
                },
                close: function (event, ui) {
                },
            });

        });

    </script>

    <script type="text/javascript">
        $(function () {

            $("#MainContent_txtfinicio").datepicker();
            $("#MainContent_txtffin").datepicker();

            $(".tb1").autocomplete(
    {
        source: function (request, response) {
            $.ajax({
                url: "SOaprobacion.aspx/getMovimientos",
                data: "{ datos: '" + request.term + "',tipo:'S'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            value: item.TM_CDESCRI,
                            id: item.TM_CCODMOV
                        }
                    }))
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    //  alert(textStatus);
                }
            });
        },
        minLength: 1,
        select: function (event, ui) {
            var str = ui.item.id;

            //$('#MainContent_lblCodigoM').text(str);
            Operacion.mask('lblFechaDocD').val(Operacion.mask('lblFechaE').text());
            Operacion.mask('lbltipoRegistro').val(Operacion.mask('lblEntrada').text());
            Operacion.mask('txtIDMOV').val(str);
            Operacion.mask('codM').val(str);
            //Operacion.mask('lblcodigoMovimiento').text(Operacion.mask('txtIDMOV').val() + "-" + Operacion.mask('txtCodigoMov').val());//DETALLE CABECERA

        }
    });
        });
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
                url: "SOaprobacion.aspx/Validausuarioniv",
                data: "{usua: '" + $("#hfusu").val() + "',numnivel:" + numnivel + "}",
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
                url: "SOaprobacion.aspx/Validausuariocuenta",
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
                url: "SOaprobacion.aspx/Extraeunacuenta",
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

        function Validanstockxsoli(almacen, idprod, solict, lote) {
            nvales = 0;
            $.ajax({
                type: "POST",
                url: "SOaprobacion.aspx/ValidaStocxSoli",
                data: "{ almacen: '" + almacen + "',idprod:'" + idprod + "',solict:'" + solict + "',lote:'" + lote + "'}",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.d != null) {
                        nvales = data.d;
                        //alert(nvales); 
                    }
                },
                error: function (response) {
                    console.table(response);
                }
            });
            return { nvales };
        }

        function Cantidadstockxsoli(almacen, idprod, solict, lote) {
            cantdiad = 0;
            $.ajax({
                type: "POST",
                url: "SOaprobacion.aspx/CantidadStocxSoli",
                data: "{ almacen: '" + almacen + "',idprod:'" + idprod + "',solict:'" + solict + "',lote:'" + lote + "'}",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.d != null) {
                        cantdiad = data.d.SS_CANTID;
                        //alert(nvales); 
                    }
                },
                error: function (response) {
                    console.table(response);
                }
            });
            return { cantdiad };
        }



        function mostrarlot(idcodigo) {

            var SDATA = {};
            SDATA.SR_CALMA = Operacion.mask('codAL').val();
            SDATA.SR_CCODIGO = idcodigo;//Operacion.mask('txtidProducto').val();
            SDATA.SR_CSERIE = "S";

            $.ajax({
                type: "POST",
                url: "SOaprobacion.aspx/ListarSL",
                data: '{ SDATA:' + JSON.stringify(SDATA) + '}',
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.d.length > 0) {

                        var row0 = $("[id*=gvSerie] tr:last-child").clone(true);
                        $("[id*=gvSerie] tr").not($("[id*=gvSerie] tr:first-child")).remove();
                        for (var i = 0; i < data.d.length; i++) {
                            $("td", row0).eq(0).html(data.d[i].SR_CSERIE);
                            var fecha = moment(data.d[i].SR_DFECVEN).format('DD/MM/YYYY');
                            $("td", row0).eq(2).html(fecha);
                            //$("td", row).eq(4).html();
                            var nrxusu = Validanstockxsoli(Operacion.mask("txtalma").val(), idcodigo.trim(), Operacion.mask("txtSolicitante").val(), data.d[i].SR_CSERIE.trim()).nvales;
                            var cantxusu = Cantidadstockxsoli(Operacion.mask("txtalma").val(), idcodigo.trim(), Operacion.mask("txtSolicitante").val(), data.d[i].SR_CSERIE.trim()).cantdiad;

                            $('td:eq(3) :text', row0).val("");
                            if (nrxusu < 1) {
                                $("td", row0).eq(1).html(data.d[i].SR_NSKDIS);
                                //$('td:eq(4) :text', row0).attr("disabled",true);
                            } else {
                                $("td", row0).eq(1).html(cantxusu);
                                $('td:eq(3) :text', row0).attr("disabled", false);
                            }

                            $("[id*=gvSerie]").append(row0);
                            row0 = $("[id*=gvSerie] tr:last-child").clone(true);

                        }

                        $('#serie').dialog("open");

                    } else {
                        var row0 = $("[id*=gvSerie] tr:last-child").clone(true);
                        $("[id*=gvSerie] tr").not($("[id*=gvSerie] tr:first-child")).remove();

                        $("td", row0).eq(0).html("");
                        $("td", row0).eq(1).html("");
                        $("td", row0).eq(2).html("");
                        $("td", row0).eq(3).html("");


                        $("[id*=gvSerie]").append(row0);
                        alert("no se encontro registro");
                    }
                },
                error: function (response) {
                    console.table(response);
                }
            });
        }

        function Validaaprobxusuario(codigoprod) {
            rtdatoa = "";
            var parm = {};
            parm.DA_IDUSUA = $("#hfusu").val();
            parm.DA_CODIGO = codigoprod;

            $.ajax({
                type: "POST",
                url: "SOaprobacion.aspx/Extraenaprob",
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
                url: "SOaprobacion.aspx/Subareasnaprob",
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
                url: "SOaprobacion.aspx/Extraenaprobtotal",
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


        function Nareasusuario(codarea, tipoproc) {
            rtdatoa = "";
            $.ajax({
                type: "POST",
                url: "SOaprobacion.aspx/Subareanusua",
                data: "{codusua: '" + $("#hfusu").val() + "',codarea:'" + codarea + "',tipopro:'" + tipoproc + "'}",
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

        function ActulizaEstadoAR(codigoprod, estado) {
            var INF = {};
            INF.SM_ID = codigoprod;
            INF.SM_ESTADO = estado;
            INF.SM_ATENC = "1";
            INF.SM_TIPOS = $("td", trpmod).eq(5).val();//$("#MainContent_ddltipos").val();
            $.ajax({
                type: "POST",
                url: "SOaprobacion.aspx/ActualizaEstado",
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
                url: "SOaprobacion.aspx/Actualizacuenta",
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


        //function InsertadetalleAprob(codigoprod) {

        //    var INF = {};
        //    INF.AR_CCODIGO = codigoprod;
        //    INF.AR_CCONTRO = "A";
        //    $.ajax({

        //        type: "POST",
        //        url: "SOaprobacion.aspx/ActualizaEstado",
        //        data: '{INF: ' + JSON.stringify(INF) + '}',
        //        contentType: "application/json; charset=utf-8",
        //        dataType: "json",
        //        async: false,
        //        success: function (response) {

        //        },
        //        error: function (response) {
        //            if (response.length != 0)
        //                console.table(response);
        //        }
        //    });
        //}


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
                url: "SOaprobacion.aspx/Insertadetallprodusua",
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
                url: "SOaprobacion.aspx/enviofinalemail",
                data: "{idusuario: '" + $("#hfusu").val() + "',idprod:'" + codigoprod + "'}",
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
                url: "SOaprobacion.aspx/eliminausuaprod",
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
                url: "SOaprobacion.aspx/listarusuariosaproba",
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
                            var fech = moment(data.d[i].DA_FECHA).format('DD/MM/YYYY');
                            $("td", row).eq(1).html(fech);
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



        function MostrarInfosolicitud(idsol, tiposo) {

            var Solici = "";
            var Estado = "";
            var Atenci = "";
            var Ccost = "";
            $.ajax({
                type: "POST",
                url: "SOaprobacion.aspx/ObtenerinfSolic",
                data: "{ idsol: '" + idsol + "',tiposo:'" + tiposo + "'}",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {

                    if (data.d != null) {
                        Solici = data.d.SM_IDSOLI;
                        Estado = data.d.SM_ESTADO;
                        Atenci = data.d.SM_ATENC;
                        Ccost = data.d.SM_CCOSTO;

                    } else {
                        Solici = "";
                        Estado = "";
                        Atenci = "";
                        Ccost = "";
                    }
                },
                error: function (response) {
                    console.table(response);
                }
            });
            return { Solici, Estado, Atenci, Ccost };
        }

        function ValidanVale(NV, TDOCX) {

            nvales = 0;
            $.ajax({
                type: "POST",
                url: "SOaprobacion.aspx/Existevale",
                data: "{ dato: '" + NV + "',TDOCX:'" + TDOCX + "'}",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.d != null) {
                        nvales = data.d;
                        //alert(nvales);
                    }
                },
                error: function (response) {
                    console.table(response);
                }
            });
            return { nvales };
        }
        function Mostrarundato(idprod) {
            var a_desc = "";
            var a_und = "";
            var a_clote = "";
            $.ajax({
                type: "POST",
                url: "SOaprobacion.aspx/GEtProductoInf",
                //data: '{CNUMDOC: ' + JSON.stringify(CNUMDOC) + '}',
                data: "{idprod: '" + idprod + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.d != null) {
                        a_desc = data.d.AR_CDESCRI;
                        a_und = data.d.AR_CUNIDAD;
                        a_clote = data.d.AR_CFLOTE;
                    } else {
                        a_desc = "";
                        a_und = "";
                    }
                },
                error: function (data) {
                    if (data.length != 0)
                        alert(data);
                }

            });
            return { a_desc, a_und, a_clote };
        }

        function DatosTABL(codigocons, codigoe) {
            var codigowh = codigoe;
            var codigoconswh = codigocons;
            var ee = "";
            $.ajax({

                type: "POST",
                url: "../../ORDENCOMPRA/OCnueva.aspx/Getdescycodigo",
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

        function ListarGridxVale(idvale, tips) {

            $.ajax({
                type: "POST",
                url: "SOaprobacion.aspx/GetListaVale",
                data: "{numvale: '" + idvale + "',DS_TIPOS:'" + tips + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.d.length > 0) {
                        var row = $("[id*=gvDetalleEntrada] tr:last-child").clone(true);
                        $("[id*=gvDetalleEntrada] tr").not($("[id*=gvDetalleEntrada] tr:first-child")).remove();
                        for (var i = 0; i < data.d.length; i++) {

                            $("td", row).eq(0).html(Number(i) + 1);
                            $("td", row).eq(1).html(data.d[i].DS_CCODIGO);
                            $("td", row).eq(2).html(Mostrarundato(data.d[i].DS_CCODIGO).a_desc);
                            $("td", row).eq(3).html(Mostrarundato(data.d[i].DS_CCODIGO).a_und);
                            $("td", row).eq(3).val(Mostrarundato(data.d[i].DS_CCODIGO).a_clote);
                            $("td", row).eq(4).html($("#MainContent_txtCentroCosto").val());
                            $("td", row).eq(5).html("");
                            $("td", row).eq(6).html("");
                            $("td", row).eq(7).html(Number(data.d[i].DS_CANTID).toFixed(4));


                            if (Mostrarundato(data.d[i].DS_CCODIGO).a_clote == "N") {
                                $("td", row).eq(2).css("color", "black");
                                

                            } else {
                                $("td", row).eq(2).css("color", "#FF5722");
                                Sumatotallote = Number(Sumatotallote) + Number(data.d[i].DS_CANTID);
                                cantcon++;
                            }


                            $("[id*=gvDetalleEntrada]").append(row);
                            row = $("[id*=gvDetalleEntrada] tr:last-child").clone(true);
                        }

                    } else {
                        var row = $("[id*=gvDetalleEntrada] tr:last-child").clone(true);
                        $("[id*=gvDetalleEntrada] tr").not($("[id*=gvDetalleEntrada] tr:first-child")).remove();

                        $("td", row).eq(0).html("");
                        $("td", row).eq(1).html("");
                        $("td", row).eq(2).html("");
                        $("td", row).eq(3).html("");
                        $("td", row).eq(4).html("");
                        $("td", row).eq(5).html("");
                        $("td", row).eq(6).html("");
                        $("td", row).eq(7).html("");

                        $("[id*=gvDetalleEntrada]").append(row);
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
            var sumacant = 0;
            var gridView = document.getElementById("<%=gvSerie.ClientID %>");

            for (var t = 1; t < gridView.rows.length; t++) {
                var inputs = gridView.rows[t].getElementsByTagName('input');
                if (inputs[0].type == "text" && (inputs[0].value != "" || inputs[0].value != 0)) {
                    sumacant = Number(sumacant) + Number(inputs[0].value);
                }
            }
            return { sumacant }
        }

        function correlativo(AL, TD) {
            //AL:ALMACEN ELEGIDO,TD:TIPO DOCUMENTO//CTD

            var idCod = "";
            $.ajax({
                type: "POST",
                url: "SOaprobacion.aspx/correlativoID",
                data: "{ AL: '" + AL.trim() + "', TDOC:'" + TD.trim() + "'}",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    //console.log(data.d);
                    //$('#MainContent_txtNumeroDoc').val(data.d);
                    //$('#MainContent_lblNroDocumento').text(data.d);
                    idCod = data.d;
                    //alert(idCod);
                },
                error: function (response) {
                    console.table(response);
                }
            });
            return { idCod };
        }



        function actualizaSerieS(AL, CD, SE, CT, OP, fmov, fven) {

            var SDATA = {};
            SDATA.SR_CALMA = AL;
            SDATA.SR_CCODIGO = CD;
            SDATA.SR_CSERIE = SE;
            SDATA.SR_NSKDIS = CT;
            SDATA.SR_DFECMOV = fmov;
            SDATA.SR_DFECVEN = fven;

            $.ajax({
                url: "SOaprobacion.aspx/actualizaSSerie",
                data: '{ SDATA: ' + JSON.stringify(SDATA) + ',OP:' + OP + '}',
                dataType: "json",
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    //var GAV = gridView.rows.length;
                    //((GAV - 1) == t ? alert('Se ha registrado los lotes con exito') : "");

                    //console.log("t=>" + t + "Operacion.cadenaMascara(" + Operacion.cadenaMascara((t-1), 4)+"");
                },
                error: function (response) {
                    alert('Hubo error en el ingreso, ponerse en contacto con el area de sistemas');
                    console.log(response);
                }
            });
            //insertaALSE(gitem00, Operacion.cadenaMascara((t - 1), 4), gitem01, gitem11, gitem21);

        }
        function insertaALSE(CODOC, AL, ITA, CD, SL, CL,TPE) {
            //AL:ALMACEN,ITA:ITEM GENERADO,CD:COD PRODUCTO,SL:SERIE/LOTE,CL:CANTIDAD LOTE,FD:FECHA DOCUMENTO
            var fechaDC = moment($("#MainContent_lblFechaDocD").text(), "DD/MM/YYYY");
            fechaDC = fechaDC == null ? null : new Date(fechaDC);
            var ASDATA = {};
            ASDATA.C6_CLOCALI = "0001";
            ASDATA.C6_CALMA = AL;
            ASDATA.C6_CTD = TPE;//CORREGIDO
            ASDATA.C6_CNUMDOC = CODOC;
            ASDATA.C6_CITEM = ITA;
            ASDATA.C6_CCODIGO = CD;
            ASDATA.C6_CSERIE = SL;
            ASDATA.C6_NCANTID = CL;
            ASDATA.C6_CUSUCRE = $('#hfusu').val();
            //ASDATA.C6_DFECCRE=;
            ASDATA.C6_DFECDOC = fechaDC;
            ASDATA.C6_CITEREQ = "";
            ASDATA.C6_CNUMCEL = "";
            ASDATA.C6_NCANRPE = 0;
            $.ajax({
                url: "SOaprobacion.aspx/registraAlmacenSerie",
                data: '{ ASDATA: ' + JSON.stringify(ASDATA) + '}',
                dataType: "json",
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    //alert('Se ha registrado los lotes con exito');
                },
                error: function (response) {
                    alert('Hubo error en el ingreso, ponerse en contacto con el area de sistemas');
                    console.log(response);
                }
            });
        }




        function guardarCabecera(IDE, ALM, CTD, TIPMO, CODMOV, CRFTIPOD, NUMREF, CRFALMA, TIPGUIA, SITGUIA, FLGPEN) {
            var fecha = moment(Operacion.mask('lblFechaDocD').text(), 'DD/MM/YYYY');
            fecha = fecha == null ? null : new Date(fecha);
            var fechac = moment().format("DD/MM/YYYY");
            fechac = fechac == null ? null : new Date(fechac);
            var DATA = {};
            var numDoc = "";

            DATA.C5_CALMA = ALM;//REEMPLAZAR
            DATA.C5_CTD = CTD;
            DATA.C5_CNUMDOC = IDE;//idCod;
            DATA.C5_CLOCALI = "0001";//FIJO SE COORDINO
            DATA.C5_DFECDOC = fecha;
            DATA.C5_DFECVEN = null;
            DATA.C5_CTIPMOV = TIPMO;
            DATA.C5_CCODMOV = CODMOV;
            DATA.C5_CSITUA = "";
            DATA.C5_CRFTDOC = CRFTIPOD;//FT,LQ,RQ
            DATA.C5_CRFNDOC = NUMREF;//pues vale
            DATA.C5_CSOLI = Operacion.mask("txtSolicitante").val();
            DATA.C5_CCENCOS = Operacion.mask("txtcodcos").val();
            DATA.C5_CRFALMA = CRFALMA;
            DATA.C5_CGLOSA1 = Operacion.mask('txtglosa').val();
            DATA.C5_CGLOSA2 = "";
            DATA.C5_CGLOSA3 = "";
            DATA.C5_CTIPANE = "";
            DATA.C5_CCODANE = "";
            DATA.C5_DFECCRE = fechac;
            DATA.C5_CUSUCRE = $("#hfusu").val();
            DATA.C5_DFECMOD = null;
            DATA.C5_CUSUMOD = "";
            DATA.C5_CCODCLI = "";
            DATA.C5_CNOMCLI = "";
            DATA.C5_CRUC = "";
            DATA.C5_CCODCAD = "";
            DATA.C5_CCODINT = "";
            DATA.C5_CCODTRA = "";
            DATA.C5_CNOMTRA = "";
            DATA.C5_CCODVEH = "";
            DATA.C5_CTIPGUI = TIPGUIA;
            DATA.C5_CSITGUI = SITGUIA;//F,A,V
            DATA.C5_CGUIFAC = "";
            DATA.C5_CDESTIN = "";
            DATA.C5_CDIRENV = "";
            DATA.C5_CNUMORD = ""; //aNORD
            DATA.C5_CTIPORD = "";
            DATA.C5_CGUIDEV = "";
            DATA.C5_CCODPRO = "";
            DATA.C5_CNOMPRO = "";//Operacion.mask('txtProveedor').val();
            DATA.C5_CCIAS = "";
            DATA.C5_CFORVEN = "";//006,007,014
            DATA.C5_CCODMON = "";// (Operacion.mask('ddlMoneda').val() != "-1" ? Operacion.mask('ddlMoneda').val() : Operacion.mask('ddlMoneda').val().trim());
            DATA.C5_CVENDE = "";//BROKER
            DATA.C5_NTIPCAM = 0;
            DATA.C5_CCODAGE = "";//001
            DATA.C5_CNUMPED = ""; //PROFORMAS
            DATA.C5_CDIRECC = ""; //DIRECCION
            DATA.C5_NIMPORT = 0;
            DATA.C5_CTIPO = "";
            DATA.C5_CSUBDIA = "";
            DATA.C5_CCOMPRO = "";
            DATA.C5_NPORDE1 = 0;
            DATA.C5_NPORDE2 = 0;
            DATA.C5_CTF = "";//02
            DATA.C5_NFLETE = 0;
            DATA.C5_CCODAUT = "";
            DATA.C5_CRFTDO2 = "";//(Operacion.mask('txtTDRef2').val() != "" ? Operacion.mask('txtTDRef2').val().trim() : "");
            DATA.C5_CRFNDO2 = "";//(Operacion.mask('txtNroDocumento2').val() != "" ? Operacion.mask('txtNroDocumento2').val() : "");
            DATA.C5_CNUMLIQ = "";
            DATA.C5_CORDEN = "";
            DATA.C5_CTIPOGS = "";//
            DATA.C5_DFECANU = null;
            DATA.C5_CCODFER = "";
            DATA.C5_DFECEMB = null;
            DATA.C5_CGLOSA4 = "";//REEMPLAZAR
            DATA.C5_CVENDE2 = "";
            DATA.C5_CESTDEV = "";
            DATA.C5_CEXTOR = "";
            DATA.C5_CRENOM = "";
            DATA.C5_CRERUC = "";
            DATA.C5_CREREF = "";
            DATA.C5_CDSNOM = "";
            DATA.C5_CDSRUC = "";
            DATA.C5_CLLECIU = "";
            DATA.C5_CPARCIU = "";
            DATA.C5_CTTRACT = "";
            DATA.C5_CTRASRE = "";
            DATA.C5_CTRAREM = "";
            DATA.C5_CLICCON = "";
            DATA.C5_CSBNOM = "";
            DATA.C5_CSBRUC = "";
            DATA.C5_CSBMTC = "";
            DATA.C5_CMONPER = "";
            DATA.C5_NIMPPER = 0;
            DATA.C5_CFPERCP = "";
            DATA.C5_CESTFIN = "";
            DATA.C5_CFLGPEN = FLGPEN;
            DATA.C5_CTIPFOR = "";
            DATA.C5_NPORPER = 0;
            DATA.C5_CFLGTRM = "";
            DATA.C5_CAGETRA = "";
            DATA.C5_CCONTAI = "";

            $.ajax({
                type: "POST",
                url: "SOaprobacion.aspx/guardarCabecera",
                data: '{DATA:' + JSON.stringify(DATA) + '}',
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                async:false,
                success: function (response) {
                    ActulizaEstadoAR(numsol.trim(), "5");
                    $("td", trpmod).eq(4).html("ATENDIDO AL USUARIO");
                    $("td", trpmod).eq(4).val("5");
                    $("td", trpmod).eq(0).val($("#MainContent_lblNroDocumento").text());
                    //alert("Se guardo correctamente");
                },
                error: function (response) {
                    console.table(response);
                }
            });
        }


        function actualizaStock(codigo, cantidad, codalmacen, OPE) {
            if (cantidad != null) {
                var CANTFINAL = Number(cantidad);//Number(AUXCANT) + Number(cantidad);
                var DATAI = {};
                DATAI.SK_CALMA = codalmacen;
                DATAI.SK_CCODIGO = codigo;
                DATAI.SK_NSKDIS = CANTFINAL;

                $.ajax({
                    type: "POST",
                    url: "SOaprobacion.aspx/actualizaStock",
                    data: '{DATAI:' + JSON.stringify(DATAI) + ',OP:' + OPE + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {

                    },
                    error: function (response) {
                        console.table(response);
                    }
                });
            }
        }


        function guardardetalleCabecera(IDE, IT, COD, DES, CANT, CALMA, DCTD, CRFALMA, CESTAD, CODMOV,OPE) {
            //stockCOD($('#MainContent_codAL').val(), COD);
            var fechaDC = moment($("#MainContent_lblFechaDocD").text(), "DD/MM/YYYY");
            fechaDC = fechaDC == null ? null : new Date(fechaDC);
            
            var DATAD = {};
            var LDES = DES;
            var NDES = (typeof LDES == 'undefined' ? "" : LDES.substring(0, 50));
            var cant_d= Number(CANT).toFixed(3);
            DATAD.C6_CALMA = CALMA;
            DATAD.C6_CTD = DCTD;//$('#MainContent_txtIDREF').val().trim();
            DATAD.C6_CNUMDOC = IDE;//$('#MainContent_txtNumeroDoc').val();
            DATAD.C6_CITEM = IT;//REEMPLAZAR-4
            DATAD.C6_CLOCALI = "0001";//REEMPLAZAR
            DATAD.C6_CCODIGO = COD;//$('#MainContent_txtidProducto').val();//REEMPLAZAR
            DATAD.C6_NCANTID = cant_d;//$('#MainContent_txtdescripcion').val();//REEMPLAZAR
            DATAD.C6_NCANTEN = 0;
            DATAD.C6_NCANFAC = 0;
            DATAD.C6_NPREUN1 = 0;
            DATAD.C6_NPREUNI = 0;
            DATAD.C6_NMNPRUN = 0;
            DATAD.C6_NUSPRUN = 0;
            DATAD.C6_CSERIE = "";
            DATAD.C6_CSITUA = "-";
            DATAD.C6_DFECDOC = fechaDC;
            DATAD.C6_DFECVEN = null;
            DATAD.C6_DFECENT = null;
            DATAD.C6_CRFALMA = CRFALMA;
            DATAD.C6_CTALLA = "";
            DATAD.C6_CESTADO = CESTAD;
            DATAD.C6_CCODMOV = CODMOV; //$('#MainContent_codM').val());// EP/CO/SP
            DATAD.C6_CORDEN = "";
            DATAD.C6_NVALTOT = 0;
            DATAD.C6_NMNIMPO = 0;
            DATAD.C6_NUSIMPO = 0;
            DATAD.C6_CSUBDIA = "";
            DATAD.C6_CCOMPRO = "";
            DATAD.C6_CCODMON = "";
            DATAD.C6_CTIPO = "";
            DATAD.C6_NTIPCAM = 0;
            DATAD.C6_NPREVTA = 0;
            DATAD.C6_CMONVTA = "";
            DATAD.C6_NUNXENV = 0;
            DATAD.C6_NNUMENV = 0;
            DATAD.C6_NDEVOL = 0;
            DATAD.C6_CCENCOS = Operacion.mask('txtcodcos').val();//CENTRO COSTO-REEMPLAZAR
            DATAD.C6_CSOLI = "";
            DATAD.C6_NPRECIO = 0;
            DATAD.C6_NPRECI1 = 0;
            DATAD.C6_NDESCTO = 0;
            DATAD.C6_NIGV = 0;
            DATAD.C6_NIGVPOR = 0;
            DATAD.C6_NIMPMN = 0;
            DATAD.C6_NIMPUS = 0;
            DATAD.C6_CDESCRI = NDES;//$('#MainContent_txtdescripcion').val();//REEMPLAZAR-DESCRIPCION PRODUCTO
            DATAD.C6_NPORDE1 = 0;
            DATAD.C6_NIMPO1 = 0;
            DATAD.C6_NPORDE2 = 0;
            DATAD.C6_NIMPO2 = 0;
            DATAD.C6_NPORDE3 = 0;
            DATAD.C6_NIMPO3 = 0;
            DATAD.C6_NPORDE4 = 0;
            DATAD.C6_NIMPO4 = 0;
            DATAD.C6_NPORDE5 = 0;
            DATAD.C6_NIMPO5 = 0;
            DATAD.C6_NPORDES = 0;
            DATAD.C6_CTIPITM = "";
            DATAD.C6_CNUMPAQ = "";
            DATAD.C6_CCODLIN = "";
            DATAD.C6_CNROTAB = "";
            DATAD.C6_CNDSCF = "";
            DATAD.C6_CNDSCL = "";
            DATAD.C6_CNDSCA = "";
            DATAD.C6_CNDSCB = "";
            DATAD.C6_CNFLAT = "";
            DATAD.C6_NPESO = 0;
            DATAD.C6_CTR = "";//REVISAR
            DATAD.C6_NPRSIGV = 0;
            DATAD.C6_CTIPANE = "";
            DATAD.C6_CCODANE = "";
            DATAD.C6_CSTOCK = "";
            DATAD.C6_CCODAGE = "";
            DATAD.C6_CCODAUX = "";
            DATAD.C6_CITEREQ = "";
            DATAD.C6_CNROREQ = "";
            DATAD.C6_NTEMPER = 0;
            DATAD.C6_NISCPOR = 0;
            DATAD.C6_NISC = 0;
            DATAD.C6_CITEFAC = "";
            DATAD.C6_NCANRPE = 0;
            DATAD.C6_CNUMREQ = "";
            DATAD.C6_CITERQ = "";
            DATAD.C6_CCODRQ = "";
            DATAD.C6_DFECRQ = null;
            DATAD.C6_CTIPPRO = "";
            DATAD.C6_NCANREQ = 0;
            DATAD.C6_CCTACMO = "";
            DATAD.C6_CNUMORD = "";
            DATAD.C6_CUMREF = "";
            DATAD.C6_NCANDEC = 0;
            DATAD.C6_NCANREF = 0;
            DATAD.C6_CITEMOC = "";
            DATAD.C6_CVANEXO = "";
            DATAD.C6_CVANEX2 = "";
            DATAD.C6_CCODAN2 = "";
            DATAD.C6_CCODEMPQ = "";
            $.ajax({
                type: "POST",
                url: "SOaprobacion.aspx/guardarDetalleCabecera",
                data: '{DATA:' + JSON.stringify(DATAD) + '}',
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                async: false,
                success: function (response) {
                    //alert('ga');
                    actualizaStock(COD, CANT, CALMA, OPE);

                },
                error: function (response) {
                    alert(response);
                    console.log(response);
                }
            });
        }

        function limpiargridxlote() {
            var rowlg = $("[id*=gvlotexvale] tr:last-child").clone(true);
            $("[id*=gvlotexvale] tr").not($("[id*=gvlotexvale] tr:first-child")).remove();

            $("td", rowlg).eq(0).html("");
            $("td", rowlg).eq(1).html("");
            $("td", rowlg).eq(2).html("");
            $("td", rowlg).eq(3).html("");
            $("td", rowlg).eq(4).html("");
            $("td", rowlg).eq(5).html("");
            $("td", rowlg).eq(6).html("");
            $("td", rowlg).eq(7).html("");
            $("[id*=gvlotexvale]").append(rowlg);
        }

        function recorregridconlotes(IDNRO, stado, CALMA, DCTD, CRFALMA, CESTAD, CODMOV, OP, sumres, soliorg, almaorg,TPE) {
            var AL = Operacion.mask('codAL').val();
            var factua = moment($("#MainContent_hffactual").val(),"DD/MM/YYYY");
            factua = factua == null ? null : new Date(factua);

            var gridView = document.getElementById("<%=gvlotexvale.ClientID %>");
            for (var t = 1; t < gridView.rows.length; t++) {
                var cant_va = gridView.rows[t].cells[7];
                //if (cant_va.innerHTML != "&nbsp;" || cant_va.innerHTML !="" || cant_va.innerHTML !=null ) {
                if (cantcon!=0){ 
                    
                    cellPivot00 = gridView.rows[t].cells[0];
                    gitem00 = cellPivot00.innerHTML;
                    cellPivot01 = gridView.rows[t].cells[1];
                    gitem01 = cellPivot01.innerHTML;
                    cellPivot02 = gridView.rows[t].cells[2];
                    gitem02 = cellPivot02.innerHTML;
                    cellPivot03 = gridView.rows[t].cells[5];
                    gitem03 = cellPivot03.innerHTML;
                    //gitem03 = gitem03 == null ? null : new Date(gitem03);
                    ccellPivot031 = gridView.rows[t].cells[6];
                    gitem031c = ccellPivot031.innerHTML;
                    cellPivot04 = gridView.rows[t].cells[7];
                    gitem04 = cellPivot04.innerHTML;
                    var gitem031 = moment(gitem031c, "DD/MM/YYYY");
                    //gitem031 = moment(gitem031).format("DD/MM/YYYY");
                    gitem031 = gitem031 == null ? null : new Date(gitem031);

                    guardardetalleCabecera(IDNRO, Operacion.cadenaMascara(tcontg, 4), gitem01, gitem02, gitem04, CALMA, DCTD, CRFALMA, CESTAD, CODMOV, OP);
                    actualizaSerieS(CALMA, gitem01, gitem03, gitem04, OP, factua, gitem031);
                    insertaALSE(IDNRO, CALMA, Operacion.cadenaMascara(tcontg, 4), gitem01, gitem03, gitem04,TPE);
                    InsertarStockxsoli(CALMA, gitem01, gitem04, gitem03, stado, sumres, soliorg, almaorg);
                    tcontg++;
                }
            }
        }

        function recorregridsinlotes(IDNRO, stado, CALMA, DCTD, CRFALMA, CESTAD, CODMOV, sumres, soliorg, almaorg,OPE) {
            var AL = Operacion.mask('codAL').val();
            var gridView = document.getElementById("<%=gvDetalleEntrada.ClientID %>");
            for (var h = 1; h < gridView.rows.length; h++) {
                cellPivotvf = gridView.rows[h].cells[3];
                if (cellPivotvf.value != "S") {
                    cellPivot000 = gridView.rows[h].cells[0];
                    gitem000 = cellPivot000.innerHTML;
                    cellPivot001 = gridView.rows[h].cells[1];
                    gitem001 = cellPivot001.innerHTML;
                    cellPivot002 = gridView.rows[h].cells[2];
                    gitem002 = cellPivot002.innerHTML;
                    cellPivot003 = gridView.rows[h].cells[5];
                    gitem003 = cellPivot003.innerHTML;
                    //cellPivot031 = gridView.rows[t].cells[6];
                    //gitem031 = cellPivot031.innerHTML;
                    cellPivot004 = gridView.rows[h].cells[7];
                    gitem004 = cellPivot004.innerHTML;
                    guardardetalleCabecera(IDNRO, Operacion.cadenaMascara(tcontg, 4), gitem001, gitem002, gitem004, CALMA, DCTD, CRFALMA, CESTAD, CODMOV,OPE);
                    InsertarStockxsoli(CALMA, gitem001, gitem004, "SIN/SERIE", stado, sumres, soliorg, almaorg);
                    //actualizaSerieS(AL, gitem01, gitem03, gitem04);
                    //insertaALSE(AL, Operacion.cadenaMascara(gitem00, 4), gitem01, gitem03, gitem04);
                    tcontg++;
                }
            }
        }

        function recorregridconlotessuma(idproduv) {
            var sumaglte = 0;
            var gridView = document.getElementById("<%=gvlotexvale.ClientID %>");
                for (var t = 1; t < gridView.rows.length; t++) {
                    var cellPt0p = gridView.rows[t].cells[1];
                    if (cellPt0p.innerHTML == idproduv) {
                        cellPt00 = gridView.rows[t].cells[7];
                        sumacalte = cellPt00.innerHTML;

                        sumaglte = Number(sumaglte) + Number(sumacalte);
                    }
                }
                return { sumaglte }
            }



            function InsertarStockxsoli(CODALM, idcodix, cantix, loteix, stado, sumres, soliorg, almaorg) {

                var ADATA = {};
                ADATA.SS_CCODIGO = idcodix.trim();
                ADATA.SS_ALMACEN = CODALM;
                ADATA.SS_SOLICITAN = Operacion.mask('txtSolicitante').val();
                ADATA.SS_LOTES = loteix.trim();
                ADATA.SS_CANTID = cantix;
                ADATA.SS_ESTADO = stado;
                //ADATA.SS_SOLICORIGEN = soliorg;
                ADATA.SS_ALMAORIG = almaorg;
                $.ajax({
                    type: "POST",
                    url: "SOaprobacion.aspx/ActualizaStockxSolicitan",
                    data: '{ADATA: ' + JSON.stringify(ADATA) + ',OP:' + sumres + '}',
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

            function ActualizaSolitud(idsolicitu, SPS, SPE) {

                var ADATA = {};
                ADATA.SM_ID = idsolicitu.trim();
                ADATA.SM_ATENC = "2";
                ADATA.SM_NPS = SPS;
                ADATA.SM_NPE = SPE;
                //ADATA.SM_TIPOS = SM_TIPOS;
                $.ajax({
                    type: "POST",
                    url: "SOaprobacion.aspx/ActualizaestadoSolic",
                    data: '{ADATA: ' + JSON.stringify(ADATA) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        Operacion.inputEstado("btnFinalizar", 1, false);
                        //$("#MainContent_btnFinalizar").attr("disabled", true);
                        alert("Guardado correctamente");
                    },
                    error: function (response) {
                        if (response.length != 0)
                            console.table(response);
                    }
                });
            }


            function RgridClotesumaT() {
                var sumaglte = 0;
                var gridView = document.getElementById("<%=gvlotexvale.ClientID %>");
            for (var t = 1; t < gridView.rows.length; t++) {
                cellPt00 = gridView.rows[t].cells[7];
                sumacalte = cellPt00.innerHTML;
                if (sumacalte > 0) {
                    sumaglte = Number(sumaglte) + Number(sumacalte);
                } else {
                    sumaglte = Number(sumaglte) + 0;
                }
            }
            return { sumaglte }
        }

        function ListagridVale(nrovale) {

            $.ajax({
                type: "POST",
                url: "SOaprobacion.aspx/ListaDetalleVale",
                //data: '{CO0003MOVD: ' + JSON.stringify(CO0003MOVD) + '}',
                data: "{nrvale: '" + nrovale + "',SM_TIPOS: '"+ Operacion.mask("ddltipos").val()+"' }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.d.length > 0) {
                        var row = $("[id*=gvdetvale] tr:last-child").clone(true);
                        $("[id*=gvdetvale] tr").not($("[id*=gvdetvale] tr:first-child")).remove();
                        for (var i = 0; i < data.d.length; i++) {
                            $("td", row).eq(0).html(i + 1);
                            $("td", row).eq(1).html(data.d[i].VSO_DESPROD);
                            $("td", row).eq(2).html(data.d[i].VSO_UND);
                            $("td", row).eq(3).html(Number(data.d[i].VSO_CANTID).toFixed(2));
                            $("[id*=gvdetvale]").append(row);
                            row = $("[id*=gvdetvale] tr:last-child").clone(true);
                        }
                    } else {
                        var row = $("[id*=gvdetvale] tr:last-child").clone(true);
                        $("[id*=gvdetvale] tr").not($("[id*=gvdetvale] tr:first-child")).remove();
                        $("td", row).eq(0).html("");
                        $("td", row).eq(1).html("");
                        $("td", row).eq(2).html("");
                        $("td", row).eq(3).html("");
                        $("[id*=gvdetvale]").append(row);
                        //alert("no se encontro registro");
                    }
                },
                error: function (response) {
                    if (response.length != 0)
                        alert(response);
                }
            });
        }

        function asignadesmov(datass) {
            $.ajax({
                type: "POST",
                url: "SOaprobacion.aspx/getMovimientosID",
                data: "{ datos: '" + datass + "',tipo:'S'}",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d != null) {
                        $('#MainContent_txtCodigoMov').val(data.d.TM_CDESCRI);
                        //if (data.d.TM_CCODMOV == "TD") {
                        //    $('#MainContent_ddlalma').attr("disabled", false);
                        //} else {
                        //    $('#MainContent_ddlalma').attr("disabled", true);
                        //}
                    } else {
                        $('#MainContent_txtCodigoMov').val("");
                    }
                }
            });
        }


        function VerCabVale(nrovale) {
            var INF = {};
            INF.SM_ID = nrovale;
            INF.SM_TIPOS = Operacion.mask("ddltipos").val();
            $.ajax({
                type: "POST",
                url: "SOaprobacion.aspx/Vercabvale",
                data: '{INF: ' + JSON.stringify(INF) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.d != null) {
                        Operacion.mask("txtdndoc").val(data.d.SO_IDSOLITD);
                        Operacion.mask("txtdfec").val(data.d.SO_FECHA);
                        Operacion.mask("txtdsolic").val(data.d.SO_SOLICITANTE);
                        Operacion.mask("txtdusec").val(data.d.SO_USUARIO);
                    } else {
                        alert("no se encontro registro");
                    }
                },
                error: function (response) {
                    if (response.length != 0)
                        alert(response);
                }
            });

        }

        function VerinfounaSolic(idnumdoc) {
            var SM_AREA = "";
            $.ajax({
                type: "POST",
                url: "SOaprobacion.aspx/ObtenerinfSoli",
                data: "{codnumdoc: '" + idnumdoc + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    SM_AREA = (data.d.SM_AREA);

                },
                error: function (data) {
                    if (data.length != 0)
                        alert(data);
                }
            });
            return { SM_AREA };
        }



    </script>




    <script type="text/javascript">
        $(function () {
          

            $(".btimpr").click(function () {
                var idnumsol = $("td:eq(0)", trpIM).html();
                var NUMPS = $("td:eq(0)", trpIM).val();
                var NUMPE = $("td:eq(1)", trpIM).val();
                var TD = "PS";
                var AL = $("td:eq(2)", trpIM).val();
                var tdocf = $("td:eq(5)", trpIM).val();
                
                if ($("#MainContent_chkimp").find(":checked").val() == "M") {

                    window.open("../Reportes/ReporteFinaliza.aspx?AL=" + AL + "&TD=" + TD + "&ND=" + NUMPS, '_blank');
                } else {

                    window.open("../SOLICITUD/REPORTES/SOreporteaprob.aspx?ID=" + idnumsol + "&TD=" + tdocf, '_blank');

                }

            });

            $(".anu").click(function () {
                trp = $(this).parent().parent();
                idnumoc = $("td:eq(0)", trp).html();
                trpmod = $(this).parent().parent();
                var estadooc = $("td:eq(4)", trp).val();
                var estadoocletra = $("td:eq(4)", trp).html();
                var numreq = $("td:eq(7)", trp).html();
                var Nivelsusua = Rvalidausuarionivel(9).rtdatoa;
                if (Nivelsusua == 0) {
                    alert("No tiene Acceso Anular Vales");
                }else{

                if (estadooc != "") {
                    if (estadooc == "5") {
                        alert("El vale Se encuentra Atendido");
                    } else {
                        if (confirm("Desea Anular la solicitud: " + idnumoc)) {
                            ActulizaEstadoAR(idnumoc, "6");
                            $("td", trp).eq(4).html("ANULADO");
                            $("td", trp).eq(4).val("6");
                        }
                    }
                }
                }
            });

            $(".imprimir").click(function () {

                var idnumsol = $("td:eq(0)", trp).html();

                var tdocf = $("td:eq(5)", trp).val();
                window.open("../SOLICITUD/REPORTES/SOreporteaprob.aspx?ID=" + idnumsol+"&TD="+tdocf, '_blank');
            });

            $(".cerrar").click(function () {
                $("#dvdetalle").dialog("close");
            });

            $(".cerrarate").click(function () {
                $("#dvatender").dialog("close");
            });

            $("#btnimprimesal").click(function () {


                var TD = "PS";
                var ND = Operacion.mask('lblNroDocumento').text();
                var AL = Operacion.mask('txtalma').val();

                window.open("../Reportes/ReporteFinaliza.aspx?AL=" + AL + "&TD=" + TD + "&ND=" + ND, '_blank');
            });

            $("#btimpingreso").click(function () {


                var TD = "PE";
                var ND = Operacion.mask('lblNroDocumento2').text();
                var AL = Operacion.mask('ddlalma').val();

                window.open("../Reportes/ReporteFinaliza.aspx?AL=" + AL + "&TD=" + TD + "&ND=" + ND, '_blank');
            });
            
            $("#btnFinalizar").click(function () {


                var stg = RgridClotesumaT().sumaglte;
                if (Number(stg) < Number(Sumatotallote)) {
                    alert("No Ha completado El Despacho Total del Vale");
                    return;
                } else {
                    var alma1 = Operacion.mask("txtalma").val();
                    var alma2 = Operacion.mask("ddlalma").val();
                    var vtd = Operacion.mask("txtIDMOV").val();
                    if (vtd != "TD") {
                        var IDE = correlativo(alma1, "PS").idCod;
                        Operacion.mask('lblNroDocumento').text(IDE);
                        guardarCabecera(IDE, alma1, "PS", "S", "PR", "VA", numsol, alma2, "", "", "F");//GUARDAR CABECERA
                        recorregridconlotes(IDE, "N", alma1, "PS", alma2, "V", vtd, "0", "0", "", "");
                        recorregridsinlotes(IDE, "N", alma1, "PS", alma2, "V", vtd, "0", "", "","0");
                        ActualizaSolitud(numsol.trim(),IDE,"");
                    } else {
                        //registra salida
                        var IDE = correlativo(alma1, "PS").idCod;
                        var IDE2 = correlativo(alma2, "PE").idCod;
                        Operacion.mask('lblNroDocumento').text(IDE);
                        Operacion.mask('lblNroDocumento2').text(IDE2);
                        //guardarCabecera(IDE, Operacion.mask('codAL').val(), "PS", "S", "VA/PE/PS", numsol, CRFALM, " /TD", " /V", "F/ ");//CABECERA PLANTILLA 
                        guardarCabecera(IDE, alma1, "PS", "S", "TD", "PE", IDE2, alma2, "", "", "F");//GUARDAR CABECERA
                        recorregridconlotes(IDE, "TG", alma1, "PS", alma2, "V", vtd, "0", "0", "", alma2,"PS");
                        recorregridsinlotes(IDE, "TG", alma1, "PS", alma2, "V", vtd,"0", "", alma2,"0");
                        //registra entrada 
                        tcontg = 1;
                        guardarCabecera(IDE2, alma2, "PE", "E", "TD", "PS", IDE, alma1, vtd, "V", "");//GUARDAR CABECERA ingreso
                        recorregridconlotes(IDE2, "TG", alma2, "PE", alma1, "S", vtd, "1", "1", "", alma1,"PE");
                        recorregridsinlotes(IDE2, "TG", alma2, "PE", alma1, "S", vtd, "1", "", alma1,"1");
                        ActualizaSolitud(numsol.trim(), IDE, IDE2);
                    }

                }


            });

            $("#MainContent_btaprob").click(function () {
                if (Nivelsusua == 0) {
                    alert("Su Usuario no tiene Acceso Aprobar");
                } else if (naccesoarea == 0) {
                    alert("Su Usuario no tiene acceso a esta area");
                } else {
                    if ($("td", trp).eq(4).val() != "1") {
                        alert("La solicitud debe estar en Estado Emitida para Aprobar");
                    } else {
                        if (confirm("Desea aprobar el Vale de Salida?")) {

                            ActulizaEstadoAR(codigodoc, "7");
                            $("td", trp).eq(4).html("APROBADO");
                            $("td", trp).eq(4).val(7);
                            $("#dvdetalle").dialog("close");
                        }
                    }
                }
            });

            $(".btEliminar02").click(function () {
                var rowCount = $('#MainContent_gvlotexvale tr').length;
                //console.log(rowCount);
                var trp = $(this).parent().parent();
                if (rowCount == 2) {
                    $("td:eq(0)", trp).html("");
                    $("td:eq(1)", trp).html("");
                    $("td:eq(2)", trp).html("");
                    $("td:eq(3)", trp).html("");
                    $("td:eq(4)", trp).html("");
                    $("td:eq(5)", trp).html("");
                    $("td:eq(6)", trp).html("");
                    $("td:eq(7)", trp).html("");
                    vfg = 1;
                    $("[id*=gvlotexvale]").append(trp);
                } else {
                    //cont1 = 0;
                    $($(this).closest("tr")).remove();
                }
            });

            $(".inf").click(function () {
                trp = $(this).parent().parent();
                trpmod = $(this).parent().parent();
                nrovale = $("td", trp).eq(0).html();
                codigodoc = $("td:eq(0)", trp).html();
                var rsubarea = $("td:eq(3)", trp).val();
                //idproductogenal = codigoprod;
                Nivelsusua = Rvalidausuarionivel(8).rtdatoa;
                //var naprob = TotalAprobaciones(codigoprod).rtdatoa; 
                //var areanvalida = NAprobxarea(codigoprod).rtdatoa;
                naccesoarea = Nareasusuario(rsubarea, "1").rtdatoa;
                VerCabVale(nrovale);
                ListagridVale(nrovale);
                //$(".ui-dialog-titlebar").hide();
                $('#dvdetalle').dialog("open");
            });


            $("#MainContent_txtcodcos").change(function () {
                var textdev = DatosTABL($("#MainContent_txtcodcos").val(), '10').ee;
                if (textdev != "") {
                    $("#MainContent_ddlccost").val(textdev);
                } else {
                    alert("Codigo no existe");
                    $("#MainContent_ddlccost").val("");
                }
            });

            $('#MainContent_txtIDMOV').change(function () {

                Operacion.mask('txtIDMOV').val($(this).val().toUpperCase());
                asignadesmov($(this).val().toUpperCase());

            });

            $("#MainContent_ddlfilt").change(function () {
                FiltragridxArea($("#MainContent_ddlfilt").val());
            });

            $("#MainContent_ddlestad").change(function () {
                FiltragridxArea($("#MainContent_ddlfilt").val());
            });

           


            $(".imp").click(function () {
                trpIM = $(this).parent().parent();
                $("#dvimprimeml").dialog("open");
                //var idnumsol = $("td:eq(0)", trp).html();
                //window.open("../SOLICITUD/REPORTES/SOreporteaprob.aspx?ID=" + idnumsol, '_blank');
            });

            $('.btEditar').click(function () {
                var trrp = $(this).parent().parent();
                idprodc = $("td", trrp).eq(1).html();
                desprodc = $("td", trrp).eq(2).html();
                undc = $("td", trrp).eq(3).html();
                ccostoc = $("td", trrp).eq(4).html();
                validasclot = $("td", trrp).eq(3).val();
                valcantxitem = $("td", trrp).eq(7).html();
                if (validasclot.trim() == "N") {
                    alert("Producto No tiene Lotes");
                } else {

                    mostrarlot(idprodc);
                }
            });


            $(".btimag").click(function (e) {
                var estadoa = $("#MainContent_ddlfilt").val();
                window.open("../ARTICULO/REPORTES/ReporteTarifario.aspx?et=" + estadoa, '_blank');
            });

            $(".clidcuenta").change(function () {
                var info = ExtraeDcuenta($("#MainContent_txtidcuenta").val()).rtdatoa;
                if (info == "") {
                    alert("Cuenta no Existe" + String.fromCharCode(10));
                    $("#MainContent_txtcuenta").val("");
                    $(this).focus();
                    $(this).val("");
                } else {
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
                } else {
                    ActulizacuentaAR(codigoprodpo);
                }
            });

            $('.clstxtdcan').blur(function () {
                var xtfil = $(this).parent().parent();
                var canvali = $("td", xtfil).eq(1).html();

                if (Number($(this).val()) > Number(canvali)) {
                    alert("La Cantidad Excede del Lote");
                    $(this).focus();
                } else {
                    var cantidad = recorregrid().sumacant; 
                    Operacion.mask("txtCantidad").val(cantidad); 
                    next = $(this).closest("tr").next().find("input[type=text]"); 
                    next.focus();
                }
            });

            $('.clstxtdcan').keydown(function (e) {
                if (e.keyCode == 13) {
                    var next = $(this).closest("tr").next().find("input[type=text]");
                    var xtfil = $(this).parent().parent();
                    var canvali = $("td", xtfil).eq(1).html();

                    if (Number($(this).val()) > Number(canvali)) {
                        alert("La Cantidad Excede del Lote");
                        $(this).focus();
                    } else {
                        var cantidad = recorregrid().sumacant;
                        Operacion.mask("txtCantidad").val(cantidad);
                        if (next.length > 0) {
                            next.focus();
                        } else {

                            next = $("[id*=gvDetalleEntrada] input[type=text]").eq(0);
                            //next.focus();
                            $(".clsgrab").focus();
                        }
                        return false;

                    }

                }
            });



            $('.clsgrab').click(function () {

                var sumacant = Number(recorregrid().sumacant) + Number(recorregridconlotessuma(idprodc).sumaglte);

                if (Number(sumacant) != Number(valcantxitem)) {
                    alert("La cantidad debe ser Igual al que solicitó");

                } else {
                    if (confirm("Desea agregar los item?")) {

                        var gridView = document.getElementById("<%=gvSerie.ClientID %>");
                        for (var t = 1; t < gridView.rows.length; t++) {
                            var inputs = gridView.rows[t].getElementsByTagName('input');
                            if (inputs[0].type == "text" && (inputs[0].value != "" || inputs[0].value != 0)) {

                                Gdr01 = gridView.rows[t].cells[0];
                                Seriev = Gdr01.innerHTML;
                                Gdr02 = gridView.rows[t].cells[2];
                                Fechav = Gdr02.innerHTML;
                                cantok = inputs[0].value;

                                var rowt = $("[id*=gvlotexvale] tr:last-child").clone(true);
                                if (vfg == 1) {
                                    $("[id*=gvlotexvale] tr").not($("[id*=gvlotexvale] tr:first-child")).remove();
                                    vfg = 2; contaditem = 0;
                                }
                                contaditem++;
                                $("td", rowt).eq(0).html(contaditem);
                                $("td", rowt).eq(1).html(idprodc);
                                $("td", rowt).eq(2).html(desprodc);
                                $("td", rowt).eq(3).html(undc);
                                $("td", rowt).eq(4).html(ccostoc);
                                $("td", rowt).eq(5).html(Seriev);
                                $("td", rowt).eq(6).html(Fechav);
                                $("td", rowt).eq(7).html(cantok);

                                $("[id*=gvlotexvale]").append(rowt);
                                rowt = $("[id*=gvlotexvale] tr:last-child").clone(true);

                                //actualizaSerieS(Operacion.mask('codAL').val(), idcodix, Seriev, cantok);
                                //insertaALSE(Operacion.mask('codAL').val(), contaditem, idcodix, Seriev, cantok); 
                            }
                        }
                        $("#serie").dialog("close");
                    }
                }
            });




            $(".ate").click(function () {
                cantcon = 0;
                Sumatotallote = 0;
                var trp = $(this).parent().parent();
                trpmod = $(this).parent().parent();
                numsol = $("td", trp).eq(0).html();
                var S_atenc = $("td", trp).eq(4).val();
                var S_alm = $("td", trp).eq(2).val();
                var tips = $("td", trp).eq(5).val();
                var idsolctud = numsol;
                //var S_estado = S_atenc;
                var S_sala = $("td", trp).eq(6).val();
                var S_ctd = $("td", trp).eq(7).val();
                var S_solicitant = MostrarInfosolicitud(idsolctud, tips).Solici;

                var Nivelsusua = Rvalidausuarionivel(9).rtdatoa;
                var S_Ccost = MostrarInfosolicitud(idsolctud, tips).Ccost;
                var info = ValidanVale(idsolctud, tips).nvales;
                var textsolici = DatosTABL(S_solicitant, '12').ee;
                var textcosto = DatosTABL(S_Ccost, '10').ee;
                if (Nivelsusua == 0) {
                    alert("No tiene Acceso Atender Solicitud");
                }else{
                if (Number(info) > 0) {
                    if (S_atenc.trim() == '1') {
                        alert("El vale se encuentra en Estado EMITIDO - Verifique Aprobacion");
                    } else {
                        if (S_atenc.trim() == "5") {
                            alert("El vale se encuentra Atendido");
                        } else {
                            ListarGridxVale(numsol, tips);
                            if (cantcon == 0) {
                                $("#MainContent_gvlotexvale").hide();
                                $("#MainContent_lbinf03").hide();
                            } else {
                                $("#MainContent_gvlotexvale").show();
                                $("#MainContent_lbinf03").show();
                            }
                            $("#dvatender").dialog("open");

                            Operacion.mask("txtTDRef2").focus();
                            Operacion.mask("txtSolicitante").val(S_solicitant.trim());
                            Operacion.mask("lblSolicitante").text(textsolici);
                            Operacion.mask("txtDessolite").val(textsolici);
                            Operacion.mask("txtcodcos").val(S_Ccost);
                            Operacion.mask("ddlccost").val(textcosto);
                            Operacion.mask("txtalma").val(S_alm);
                            Operacion.mask("txtIDMOV").val(S_ctd);
                            if (S_ctd == "TD") {
                                Operacion.mask("lblNroDocumento2").show();
                                Operacion.mask("lbdata2").show();
                                Operacion.mask("btimpingreso").show();
                            } else {
                                Operacion.mask("lblNroDocumento2").hide();
                                Operacion.mask("lbdata2").hide();
                                Operacion.mask("btimpingreso").hide();
                            }
                            asignadesmov(S_ctd);
                            Operacion.mask("ddlalma").val(S_sala);
                            Operacion.mask("txtSolicitante").attr("disabled", true);
                            Operacion.mask("lblSolicitante").attr("disabled", true);
                            Operacion.mask("txtcodcos").attr("disabled", true);
                            Operacion.mask("ddlccost").attr("disabled", true);
                            Operacion.mask("ddlalma").attr("disabled", true);
                        }
                    }
                }
                }


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
                var idval = $("td:eq(0)", trp).html();
                var tipodoc = $("td:eq(5)", trp).val();
                var S_atenc = $("td:eq(4)", trp).val();

                if (S_atenc=="1"){
                    window.location.assign("\SOregistro.aspx?ID=" + idval + "&TD=" + tipodoc);
                } else {
                    alert("El Vale debe estar Emitido para editar");
                }

            });





            $("#MainContent_txtidpro").change(function () {
                if (Mostrarunproveedor($(this).val()).ee == "") {
                    alert("No se encontro informacion");
                    $(this).focus();
                } else {
                    $("#MainContent_txtprove").val(Mostrarunproveedor($(this).val()).ee);
                    $("#MainContent_txtnumref").focus();
                }
            });


            function FiltragridxArea(codarea) {
                var ADATA = {};
                ADATA.SM_AREA = codarea;
                ADATA.SM_ESTADO = Operacion.mask("ddlestad").val();
                ADATA.SM_ID = Operacion.mask("txtnuma").val() == "" ? 0 : Operacion.mask("txtnuma").val();
                ADATA.SM_TIPOS = Operacion.mask("ddltipos").val();
                $.ajax({
                    type: "POST",
                    url: "SOaprobacion.aspx/ListarVales",
                    data: '{ADATA: ' + JSON.stringify(ADATA) + '}',
                    //data: "{codarea: '" + codarea + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {

                        if (data.d.length > 0) {
                            var row = $("[id*=gvsolicitudes] tr:last-child").clone(true);
                            $("[id*=gvsolicitudes] tr").not($("[id*=gvsolicitudes] tr:first-child")).remove();

                            for (var i = 0; i < data.d.length; i++) {
                                $("td", row).eq(0).html(data.d[i].SM_ID);
                                $("td", row).eq(0).val(data.d[i].SM_NPS);
                                $("td", row).eq(1).html(data.d[i].SM_IDSOLI);
                                $("td", row).eq(1).val(data.d[i].SM_NPE);
                                $("td", row).eq(2).html(data.d[i].SM_GLOSA);
                                $("td", row).eq(2).val(data.d[i].SM_ALMA);
                                $("td", row).eq(3).html(data.d[i].SM_AREA);
                                $("td", row).eq(3).val(data.d[i].SM_IDAREA);
                                $("td", row).eq(4).html(data.d[i].SM_ESTADO);
                                $("td", row).eq(4).val(data.d[i].SM_IDESTAD);
                                $("td", row).eq(5).html(data.d[i].SM_USUA);
                                $("td", row).eq(5).val(data.d[i].SM_TIPOS);
                                $("td", row).eq(6).val(data.d[i].SM_SALA);
                                $("td", row).eq(7).val(data.d[i].SM_CTD);
                                $("[id*=gvsolicitudes]").append(row);
                                row = $("[id*=gvsolicitudes] tr:last-child").clone(true);
                            }

                        } else {
                            var row = $("[id*=gvsolicitudes] tr:last-child").clone(true);
                            $("[id*=gvsolicitudes] tr").not($("[id*=gvsolicitudes] tr:first-child")).remove();

                            $("td", row).eq(0).html("");
                            $("td", row).eq(1).html("");
                            $("td", row).eq(2).html("");
                            $("td", row).eq(3).html("");
                            $("td", row).eq(4).html("");
                            $("td", row).eq(5).html("");

                            $("[id*=gvsolicitudes]").append(row);
                            alert("no se encontro registro");

                        }


                    },
                    error: function (response) {
                        if (response.length != 0)
                            alert(response);
                    }
                });

            }

           
        });

    </script>




    <%--    <style type="text/css">
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
    </style>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:HiddenField runat="server" ID="hffactual" />
    <asp:HiddenField runat="server" ID="hfusu" />
    <asp:HiddenField ID="codM" runat="server" />
    <asp:HiddenField ID="codAL" runat="server" />
    <div id="contenedor" style="float: left; width: 1000px">
        <fieldset style="float: left; width: 900px">
            <legend>MANTENIMIENTO DE BITACORAS</legend>

            <table>
                    
                <tr>
                    <td>F.Inicio: </td>
                    <td>
                       

                             <asp:TextBox ID="txtfinicio" runat="server" style="width: 155px" ></asp:TextBox>
                  
                    </td>
                      <td>F.Fin: </td>
                     <td>
                     


                        <asp:TextBox ID="txtffin" runat="server" style="width: 155px" ></asp:TextBox>
                  
                    </td>
                </tr>
                <tr>
                     <td>
                    


                     <asp:Button ID="btbusca" runat="server" Text="Buscar" value="Buscar" class="btn" OnClick="btbusca_Click"/>
                  
                    </td>
                </tr>
              
            </table>
            <table>
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
                            <asp:GridView ID="gvsolicitudes" class="filtrar" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" Width="958px" AutoGenerateColumns="False" >
                                <Columns>
                                    <asp:BoundField DataField="numero" HeaderText="numero" />
                                    <asp:BoundField DataField="placa" HeaderText="placa" />
                                     <asp:BoundField DataField="fechaCreacion" HeaderText="fechaCreacion" />

                                        <asp:BoundField DataField="horallegada" HeaderText="horallegada" />
                                        <asp:BoundField DataField="horaPartida" HeaderText="horaPartida" />

                                     <asp:BoundField DataField="turno" HeaderText="turno" />

                                    <asp:BoundField DataField="detalle_chofer" HeaderText="detalle_chofer" />
                                    <asp:BoundField DataField="detalle_vigilante" HeaderText="detalle_vigilante" />
                                   
                                
                                    <asp:BoundField DataField="procedencia" HeaderText="procedencia" />
                                

                                    
                                    <asp:TemplateField HeaderText="editar">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgeditar" Width="22" runat="server" ImageUrl="~/Images/edit.png" OnClick="imgeditar_Click1" />
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

    </div>



    <div id="dvdetalle" style="position: center; display: none">
        <%--   <fieldset style="background-color:aliceblue">--%>
        <div style="background-color: #006699">
            <table>
                <tr>
                    <td>
                        <input type="button" value="Aprobar" id="btaprob" class="btn" runat="server" style="border-radius: initial; border: solid; border-color: white; background-color: #006699" />
                    </td>
                    <td>
                        <input type="button" value="Imprimir" class="imprimir btn" runat="server" style="border-radius: initial; border: solid; border-color: white; background-color: #006699" />
                    </td>
                    <td>
                        <input type="button" value="Cerrar" class="cerrar btn" runat="server" style="border-radius: initial; border: solid; border-color: white; background-color: #006699" />
                    </td>
                </tr>
            </table>
        </div>
        <%--      </fieldset>--%>
        <table>
            <tr>
                <td colspan="4">-</td>
            </tr>
            <tr>
                <td>N° Documento</td>
                <td>
                    <asp:TextBox runat="server" ID="txtdndoc" Width="100" Enabled="false" />
                </td>
                <td>Fecha:</td>
                <td style="text-align: right">
                    <asp:TextBox runat="server" ID="txtdfec" Width="100" Enabled="false" />
                </td>

            </tr>
            <tr>
                <td>Solicitante</td>
                <td colspan="3">
                    <asp:TextBox runat="server" ID="txtdsolic" Width="280" Enabled="false" />
                </td>
            </tr>
            <tr>
                <td>Usuario Creacion</td>
                <td colspan="3">
                    <asp:TextBox runat="server" ID="txtdusec" Width="280" Enabled="false" />
                </td>
            </tr>

        </table>
        <table>
            <tr>
                <td>
                    <asp:GridView ID="gvdetvale" class="filtrar" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" Width="576px">
                        <Columns>
                            <asp:BoundField DataField="VSO_ITM" HeaderText="ITM" ItemStyle-Width="10" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="VSO_DESPROD" HeaderText="DESCRIPCION" ItemStyle-Width="300">
                                <ItemStyle CssClass="OC_CDESREF"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="VSO_UND" HeaderText="UND" ItemStyle-Width="80" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle CssClass="FECHA"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="VSO_CANTID" HeaderText="CANTIDAD" ItemStyle-Width="70" ItemStyle-HorizontalAlign="Right" />

                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" Height="20" />
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
        </table>
    </div>
    <div id="dvatender" style="display: none">
        <div style="background-color: #006699">
            <table>
                <tr>
                    <td style="text-align: right">
                        <input id="btnFinalizar" class="btn" type="button" value="Finalizar" style="border-radius: initial; border: solid; border-color: white; background-color: #006699" />
                    </td>
                    <td>
                        <input id="btnimprimesal" class="btn" type="button" value="Imprimir Salida" style="border-radius: initial; border: solid; border-color: white; background-color: #006699" />
                    </td>
                    <td>
                        <input id="btimpingreso" class="btn" type="button" value="Imprimir Ingreso" style="border-radius: initial; border: solid; border-color: white; background-color: #006699" />
                    </td>
                    
                    <td>
                        <input type="button" value="Cerrar" class="cerrarate btn" runat="server" style="border-radius: initial; border: solid; border-color: white; background-color: #006699" />
                    </td>
                </tr>
            </table>
        </div>
        <table>
            <tr>
                <td>N° Doc. Salida</td>
                <td colspan="3">
                    <asp:Label Text="" ID="lblNroDocumento" runat="server" BorderStyle="Double" Width="120" Height="15" />
                    
                    <asp:Label Text="N° Doc. Ingreso" ID="lbdata2" runat="server" />
                    <asp:Label Text="" ID="lblNroDocumento2" runat="server" BorderStyle="Double" Width="120" Height="15" />
                </td>
            </tr>
            <tr>
                <td>Fecha Documento</td>
                <td colspan="2">
                    <asp:Label ID="lblFechaDocD" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>

                <td>Solicitante </td>
                <td>
                    <asp:TextBox runat="server" ID="txtSolicitante" Enabled="false" Width="50" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtDessolite" Enabled="false" Width="250" />
                </td>
            </tr>
            <tr>
                <td>Centro Costo </td>
                <td>
                    <asp:TextBox runat="server" ID="txtcodcos" Enabled="true" Width="50" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="ddlccost" Enabled="true" Width="250" />
                </td>
            </tr>
            <tr>
                <td>Almacen</td>
                <td colspan="2">
                    <asp:TextBox runat="server" ID="txtalma" Enabled="false" Width="300" />
                </td>
            </tr>
            <tr>
                <td>Glosa</td>
                <td colspan="2">
                    <asp:TextBox runat="server" ID="txtglosa" Width="300" />
                </td>
            </tr>

            <tr>
                <td>Movimiento</td>
                <td colspan="2">
                    <asp:TextBox ID="txtIDMOV" runat="server" TabIndex="0" Width="35px" Enabled="false"></asp:TextBox>
                    <asp:TextBox ID="txtCodigoMov" Width="263px" runat="server" class="tb1" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Almacen:</td>
                <td colspan="2">
                    <asp:DropDownList ID="ddlalma" class="selalma" runat="server" Width="300" TabIndex="18" Enabled="false"></asp:DropDownList>
                </td>
            </tr>
        </table>
        <hr />
        <table>
            <tr>
                <td colspan="2">
                    <asp:Label Text="__" BackColor="#FF5722" ID="lbinf01" ForeColor="#FF5722" runat="server" />
                    <asp:Label Text="Productos con Lote" ID="lbinf02" runat="server" Font-Bold="true" /></td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="gvDetalleEntrada" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" Width="765px">
                        <Columns>
                            <asp:BoundField DataField="ITEM" HeaderText="ITEM" ItemStyle-HorizontalAlign="center">
                                <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="20" />
                                <ItemStyle Font-Size="8pt" />
                            </asp:BoundField>

                            <asp:BoundField DataField="C6_CCODIGO" HeaderText="Codigo" ItemStyle-HorizontalAlign="center">
                                <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                <ItemStyle Font-Size="8pt" />
                            </asp:BoundField>
                            <asp:BoundField DataField="C6_CDESCRI" HeaderText="Descripcion" ItemStyle-HorizontalAlign="left">
                                <HeaderStyle Font-Size="8pt" HorizontalAlign="left" Width="130" />
                                <ItemStyle Font-Size="8pt" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AR_CUNIDAD" HeaderText="Unidad" ItemStyle-HorizontalAlign="center">
                                <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="50" />
                                <ItemStyle Font-Size="8pt" />
                            </asp:BoundField>
                            <asp:BoundField DataField="C6_CCENCOS" HeaderText="Centro de Costo" ItemStyle-HorizontalAlign="center">
                                <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                <ItemStyle Font-Size="8pt" />
                            </asp:BoundField>
                            <asp:BoundField DataField="C6_CSERIE" HeaderText="Serie" ItemStyle-HorizontalAlign="right">
                                <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                <ItemStyle Font-Size="8pt" />
                            </asp:BoundField>
                            <asp:BoundField DataField="C6_CFECDOC" HeaderText="Fecha" ItemStyle-HorizontalAlign="right">
                                <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                <ItemStyle Font-Size="8pt" />
                            </asp:BoundField>
                            <asp:BoundField DataField="C6_CNCANTIDAD" HeaderText="Cantidad" ItemStyle-HorizontalAlign="right" DataFormatString="&quot;{0:d}&quot;">
                                <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                <ItemStyle Font-Size="8pt" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <div class="btEditar" style="text-align: center">
                                        <img alt="" src="../../Images/EDIT.png" width="25" style="cursor: pointer" />
                                        <%--<asp:ImageButton ID="imbeliminar" runat="server" ImageUrl="~/Images/Message_Error.png" Width="25px" OnClick="ib_eliminar_Click" onclientclick="javascript:return confirm('Esta Seguro?')"/>--%>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <%--                                                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <div class="btlote" style="text-align: center">
                                            <img alt="" src="../Images/EDIT.png" width="25" style="cursor: pointer" />
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
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
                <td>
                    <asp:Label Text="Detalle Productos / Lotes" runat="server" ID="lbinf03" Font-Bold="true" />
                </td>

                <%--<td style="text-align: right">
                        <input id="btnFinalizar" class="btn" type="button" value="Finalizar" />
                    </td>--%>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="gvlotexvale" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" Width="764px">
                        <Columns>
                            <asp:BoundField DataField="ITEM" HeaderText="ITEM" ItemStyle-HorizontalAlign="center">
                                <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="50" />
                                <ItemStyle Font-Size="8pt" />
                            </asp:BoundField>

                            <asp:BoundField DataField="C6_CCODIGO" HeaderText="Codigo" ItemStyle-HorizontalAlign="center">
                                <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                <ItemStyle Font-Size="8pt" />
                            </asp:BoundField>
                            <asp:BoundField DataField="C6_CDESCRI" HeaderText="Descripcion" ItemStyle-HorizontalAlign="left">
                                <HeaderStyle Font-Size="8pt" HorizontalAlign="left" Width="150" />
                                <ItemStyle Font-Size="8pt" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AR_CUNIDAD" HeaderText="Unidad" ItemStyle-HorizontalAlign="center">
                                <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="50" />
                                <ItemStyle Font-Size="8pt" />
                            </asp:BoundField>
                            <asp:BoundField DataField="C6_CCENCOS" HeaderText="Centro de Costo" ItemStyle-HorizontalAlign="center">
                                <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                <ItemStyle Font-Size="8pt" />
                            </asp:BoundField>
                            <asp:BoundField DataField="C6_CSERIE" HeaderText="Serie" ItemStyle-HorizontalAlign="right">
                                <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                <ItemStyle Font-Size="8pt" />
                            </asp:BoundField>
                            <asp:BoundField DataField="C6_CFECDOC" HeaderText="Fecha" ItemStyle-HorizontalAlign="right">
                                <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                <ItemStyle Font-Size="8pt" />
                            </asp:BoundField>
                            <asp:BoundField DataField="C6_CNCANTIDAD" HeaderText="Cantidad" ItemStyle-HorizontalAlign="right" DataFormatString="&quot;{0:d}&quot;">
                                <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                                <ItemStyle Font-Size="8pt" />
                            </asp:BoundField>

                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <div class="btEliminar02" style="text-align: center">
                                        <img alt="" src="../../Images/Trash.png" width="25" style="cursor: pointer" />

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
    <div id="serie" style="display: none">

        <asp:GridView ID="gvSerie" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False">

            <Columns>
                <asp:BoundField DataField="SR_CSERIE" HeaderText="Serie o Lote" ItemStyle-HorizontalAlign="center">
                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                    <ItemStyle Font-Size="8pt" />
                </asp:BoundField>
                <asp:BoundField DataField="SR_NKDIS" HeaderText="Stock Disponible" ItemStyle-HorizontalAlign="center">
                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                    <ItemStyle Font-Size="8pt" />
                </asp:BoundField> 
                <asp:BoundField DataField="SR_DFECVEN" HeaderText="Fecha Vencimiento" ItemStyle-HorizontalAlign="center">
                    <HeaderStyle Font-Size="8pt" HorizontalAlign="CENTER" Width="100" />
                    <ItemStyle Font-Size="8pt" />
                </asp:BoundField>



                <asp:TemplateField HeaderText="Cantidad">
                    <ItemTemplate>
                        <input type="text" runat="server" style="width: 100px" class="clstxtdcan btn02" onkeypress="$(this).numeric('.');" />

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

        <table>
            <tr>
                <td>
                    <input type="button" value="Agregar" class="clsgrab btn" runat="server" />
                </td>
            </tr>
        </table>


    </div>

    <div id="dvimprimeml" style="display: none">
        <table style="margin: 0 auto; width: 250px">
            <tr>
                <td class="auto-style2">Seleccione Documento</td>
            </tr>
            <tr>
                <td style="text-align: center">
                    <asp:RadioButtonList ID="chkimp" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="L" Text="Solicitud" Selected="True"> </asp:ListItem>
                        <asp:ListItem Value="M" Text="Parte Salida" > </asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <hr style="margin-right: 0" />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center">
                    <input type="button" class="btimpr btn" value="IMPRIMIR" />
                </td>
            </tr>
        </table>
    </div>


</asp:Content>

