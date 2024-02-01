﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="OCnueva.aspx.cs" Inherits="Default2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link type="text/css" href="../CSS/Base-s.css?1.5" rel="stylesheet" />

    <script type="text/javascript">

      
        function ModifyEnterKeyPressAsTab(event,info) {
           
            if (event.keyCode == 13) {
                cb = parseInt($(info).attr('tabindex'));
                cb2 = cb + 1;
                if ($(':input[TabIndex=\'' + (cb2) + '\']') != null  ) {
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
            
          
            totalpla = 0;
            contarndw = 0;
            cc = 1;
            sw_edicion = 0;
            sw_nuevo = 0;
            sw_plan = 0;
            contaditem = 0; contaditemplan=0;
            guardartmp = [];
            sindatosimport = 0;
            gsumadolaresf = 0; gsumasolesf = 0;
            $(".bttimp").hide();
            $(".btplan").hide();
            $(function () {
                UHTML.id = 'MainContent';
                Operacion.iValida(Operacion.mask("txtdcant"), 1);
                Operacion.iValida(Operacion.mask("txtdprec"), 1);
                Operacion.iValida(Operacion.mask("txttcambio"), 1);
                Operacion.iValida(Operacion.mask("txtdisc"), 1);
                Operacion.iValida(Operacion.mask("txtddesci"), 1);
                Operacion.iValida(Operacion.mask("txtddesca"), 1);
                
                $("#MainContent_txtfecha1").datepicker(({
                     change : function (e) {
                         var curDate = $("#MainContent_txtfecha1").datepicker("getDate");
                        var maxDate = new Date();
                        maxDate.setDate(maxDate.getDate() + 1); // add one day
                        maxDate.setHours(0, 0, 0, 0);           // clear time portion for correct results
                        if (curDate > maxDate) {
                            alert("Invalid date");
                            $(this).datepicker("setDate", maxDate);
                        }
                    }
                }));

            


                $("#MainContent_txtfecha2").datepicker();
                $("#MainContent_txtdfechat1").datepicker();
                $("#MainContent_txtfinis").datepicker();
                $("#MainContent_txtffins").datepicker();
            });
            
            $.urlParam = function (name) {
                var results = new RegExp('[\?&]' + name + '=([^&#]*)').exec(window.location.href);
                return (results != null ? results[1] || 0 : "");
            }
            

            var codextraido = $.urlParam("ID");//window.location.search.substring(1);
            
            if (codextraido.length > 1) {
                MostrarunRegistro(codextraido);
                validaboton();
                $("#MainContent_ddltipo").attr("disabled", true);
                $("#MainContent_ddlsuboc").attr("disabled", true);
                $(".btadd").show();
            } else {
                $("#MainContent_txtfecha1").focus();
            }
            
         
            var tcam = MostrarTcambio();
            $("#MainContent_txttcambio").val(tcam);

            
        });



    </script>

    <script type="text/javascript">

        function recorregrid() {
            subtt = 0; descc = 0; igvv = 0;
            sumasub = 0; sumadesc = 0; sumaigvv = 0; sumatotall = 0;

            var gridView = document.getElementById("<%=gvordencompra.ClientID %>");

            for (var t = 1; t < gridView.rows.length; t++) {
                var inputs = gridView.rows[t].getElementsByTagName('input');

                cellPivot = gridView.rows[t].cells[13];
                subtt = cellPivot.innerHTML;
                sumasub = new Number(sumasub) + new Number(subtt);

                cellPivot02 = gridView.rows[t].cells[11];
                descc = cellPivot02.innerHTML;
                sumadesc = new Number(sumadesc) + new Number(descc);

                cellPivot03 = gridView.rows[t].cells[12];
                igvv = cellPivot03.innerHTML;
                sumaigvv = new Number(sumaigvv) + new Number(igvv);

                sumatotall = (sumasub - sumadesc) + sumaigvv;
            }

            return {
                sumasub, sumadesc, sumaigvv, sumatotall
            };
        }


        function calculo_MNUS(montototal_in) {
            montototal = montototal_in;
            montous = 0; montomn = 0;
            if ($("#MainContent_ddlmone").val().trim() == "MN") {

                montous = Number(montototal) / Number($("#MainContent_txttcambio").val());
                montomn = Number(montototal);

            } else {
                montous = Number(montototal);
                montomn = Number(montototal) * Number($("#MainContent_txttcambio").val());
            }
            return {
                montous, montomn
            };
        }

    </script>





    <script type="text/javascript">


        function VerDetalleGrid() {

            var igvch = ""; var precioconigv = 0;
            var preorig = $("#MainContent_txtdprec").val();

            if ($("#MainContent_chkigv").attr("checked") == true) {
                igvch = $("#MainContent_txtdigv").val();
                precioconigv = preorig / ((igvch / 100) + 1);

            } else {
                igvch = 0;
                precioconigv = preorig;
            }


            precioconigv = new Number(precioconigv);
            var PrecioFinal = 0; var subtotal = 0;
            var dctoc = 0; var totaligv = 0;
            var totalisc = 0; var totaldcto = 0;
            var totaldctox = 0;

            var cantid = $("#MainContent_txtdcant").val();
            var pigv = $("#MainContent_txtdigv").val();
            var dctitem = $("#MainContent_txtddesci").val();
            var dctadic = $("#MainContent_txtddesca").val();
            var tisc = $("#MainContent_txtdisc").val();

            //FORMULAS
            var preciovta = (precioconigv * ((pigv / 100) + 1));
            var descitem = preciovta - (preciovta * (dctitem / 100));
            var desadic = descitem - (descitem * (dctadic / 100));
            //descuentos por porcentaje
            var descitemval = (preciovta - (preciovta * (dctitem / 100))) * dctitem;
            var desadicval = (descitem - (descitem * (dctadic / 100))) * dctadic;
            
            //CALCULO 
            subtotal = cantid * precioconigv;
            dctoc = subtotal * (dctitem / 100);
            dctoadic = (subtotal - dctoc) * (dctadic / 100);
            totaldcto = dctoc + dctoadic;
            totaldctox = new Number(dctitem) + new Number(dctadic);

            preciofinal = desadic;
            totaligv = (subtotal - dctoc - dctoadic) * ((pigv / 100));
            totalisc = (subtotal * (tisc / 100));
            //calulo total por moneda 
            totalall = 0;
            totalall = (new Number(subtotal.toFixed(3)) - new Number(totaldcto.toFixed(3))) + new Number(totaligv.toFixed(3));
            monto_us = calculo_MNUS(totalall).montous;   
            monto_mn = calculo_MNUS(totalall).montomn;   

            //RETORNO
            //$("#MainContent_txtresultado").val(preciofinal.toFixed(9)); //preciofinal            //$("#MainContent_txtsub").val(subtotal.toFixed(3)); //subtotal
            //$("#MainContent_txtdescuentoc").val(dctoc.toFixed(3)); //total descuento            //$("#MainContent_txttotigv").val(totaligv.toFixed(3)); //total igv

            if (sw_edicion == 0) {

                var rowt = $("[id*=gvordencompra] tr:last-child").clone(true);
                if (cc == 1) {
                    $("[id*=gvordencompra] tr").not($("[id*=gvordencompra] tr:first-child")).remove();
                    cc = 2; contarndw = 0; contaditem = 0;
                }

                contaditem = contaditem + 1;
                var nitem = ("000" + contaditem).slice(-4);
                $("td", rowt).eq(0).html(nitem);
                $("td", rowt).eq(1).html($("#MainContent_txtdcodati").val());
                $("td", rowt).eq(1).val($("#MainContent_txtdcodcost").val());
                $("td", rowt).eq(2).html($("#MainContent_txtdarticulo").val());
                $("td", rowt).eq(2).val($("#MainContent_txtdccost").val());

                $("td", rowt).eq(3).html($("#MainContent_txtdumed").val());
                $("td", rowt).eq(3).val($("#MainContent_txtddescf").val());

                $("td", rowt).eq(4).html($("#MainContent_txtdcant").val());
                $("td", rowt).eq(5).html(precioconigv.toFixed(5));

                if ($("#MainContent_txtdcodati").val().substring(0, 1) == "R") {
                    $("td", rowt).eq(2).css("color", "black");
                    $("td", rowt).eq(5).val("R");
                } else {
                    $("td", rowt).eq(2).css("color", "#FF5722");
                    $("td", rowt).eq(5).val("M");
                }
               
                $("td", rowt).eq(6).html($("#MainContent_txtddesca").val());
                $("td", rowt).eq(6).val(desadicval);
                $("td", rowt).eq(7).html($("#MainContent_txtddesci").val());
                $("td", rowt).eq(7).val(descitemval);
                $("td", rowt).eq(8).html($("#MainContent_txtdigv").val());
                $("td", rowt).eq(8).val(igvch);
                $("td", rowt).eq(9).html($("#MainContent_txtdisc").val());
                $("td", rowt).eq(10).html(preciofinal.toFixed(4));

                $("td", rowt).eq(11).html(totaldcto.toFixed(3));
                $("td", rowt).eq(11).val(totaldctox.toFixed(2));
                $("td", rowt).eq(12).html(totaligv.toFixed(3));
                $("td", rowt).eq(12).val(totaligv.toFixed(3));
                $("td", rowt).eq(13).html(subtotal.toFixed(3));
                $("td", rowt).eq(13).val(subtotal.toFixed(3));

                $("td", rowt).eq(14).html(0);
                $("td", rowt).eq(14).val($("#MainContent_txtdcodsoli").val());
                $("td", rowt).eq(15).html($("#MainContent_txtdcant").val());
                $("td", rowt).eq(15).val($("#MainContent_txtdsoli").val());

                $("td", rowt).eq(16).html($("#MainContent_txtdfechat1").val());
                $("td", rowt).eq(16).val(monto_us.toFixed(3));
                $("td", rowt).eq(17).html($("#MainContent_txtdcomen").val());
                $("td", rowt).eq(4).val($("#MainContent_txtdcomen").val());
                $("td", rowt).eq(17).val(monto_mn.toFixed(3));

                $("td", rowt).eq(18).html(totalisc.toFixed(3));


                $("[id*=gvordencompra]").append(rowt);
                rowt = $("[id*=gvordencompra] tr:last-child").clone(true);
                contarndw = contarndw + 1;
                
                $("#MainContent_txtdarticulo").focus();


            } else {

                //var trp = $(this).parent().parent();
                //var itemde = $("td:eq(2)", trp).html();

                // $("td", trpedita).eq(0).html(nitem);
                $("td", trpedita).eq(1).html($("#MainContent_txtdcodati").val());
                $("td", trpedita).eq(1).val($("#MainContent_txtdcodcost").val());
                $("td", trpedita).eq(2).html($("#MainContent_txtdarticulo").val());
                $("td", trpedita).eq(2).val($("#MainContent_txtdccost").val());
                $("td", trpedita).eq(3).html($("#MainContent_txtdumed").val());
                $("td", trpedita).eq(3).val($("#MainContent_txtddescf").val());
                $("td", trpedita).eq(4).html($("#MainContent_txtdcant").val());
                if ($("#MainContent_txtdcodati").val().substring(0, 1) == "R") {
                    $("td", rowt).eq(2).css("color", "black");
                    $("td", rowt).eq(5).val("R");
                } else {
                    $("td", rowt).eq(2).css("color", "#FF5722");
                    $("td", rowt).eq(5).val("M");
                }
                $("td", trpedita).eq(5).html(precioconigv.toFixed(5));
                $("td", trpedita).eq(6).html($("#MainContent_txtddesca").val());
                
                $("td", trpedita).eq(6).val(desadicval);
                $("td", trpedita).eq(7).html($("#MainContent_txtddesci").val());
                $("td", trpedita).eq(7).val(descitemval);
                $("td", trpedita).eq(8).html($("#MainContent_txtdigv").val());
                $("td", trpedita).eq(8).val(igvch);
                $("td", trpedita).eq(9).html($("#MainContent_txtdisc").val());
                $("td", trpedita).eq(10).html(preciofinal.toFixed(4));
                $("td", trpedita).eq(11).html(totaldcto.toFixed(3));
                $("td", trpedita).eq(11).val(totaldctox.toFixed(2));
                $("td", trpedita).eq(12).html(totaligv.toFixed(3));
                $("td", trpedita).eq(12).val(totaligv.toFixed(3));
                $("td", trpedita).eq(13).html(subtotal.toFixed(3));
                $("td", trpedita).eq(13).val(subtotal.toFixed(3));
                $("td", trpedita).eq(14).html(0);
                $("td", trpedita).eq(14).val($("#MainContent_txtdcodsoli").val());
                $("td", trpedita).eq(15).html($("#MainContent_txtdcant").val());
                $("td", trpedita).eq(15).val($("#MainContent_txtdsoli").val());
                $("td", trpedita).eq(16).html($("#MainContent_txtdfechat1").val());
                $("td", trpedita).eq(16).val(monto_us.toFixed(3));
                $("td", trpedita).eq(17).html($("#MainContent_txtdcomen").val().substring(0,50));
                $("td", trpedita).eq(4).val($("#MainContent_txtdcomen").val());
                $("td", trpedita).eq(17).val(monto_mn.toFixed(3));
                $("td", trpedita).eq(18).html(totalisc.toFixed(3));

                alert("Se Actualizo la Informacion");
                $(".btaddd").attr("value", "Agregar");
                sw_edicion = 0;
            }
            limpiartextodetalle();

            var sub01 = recorregrid().sumasub; var des01 = recorregrid().sumadesc;
            var igv01 = recorregrid().sumaigvv; var tot01 = recorregrid().sumatotall;

            $("#MainContent_txttbrutof").val(sub01.toFixed(2));
            $("#MainContent_txtdescf").val(des01.toFixed(2));
            $("#MainContent_txtigvf").val(igv01.toFixed(2));
            $("#MainContent_txtnetof").val(tot01.toFixed(2));
            Operacion.mask('txtdarticulo').focus();

        }
    </script>


    <script type="text/javascript">
        $(function () {
            $('#dvdetalle').dialog({
                autoOpen: false,
                modal: true,
                resizable: true,
                width: 1190,
                heigth: 100,
                closeOnEscape:false,
                title: 'Detalle',
                open: function (event, ui) {
                    limpiartextodetalle();
                    $("#MainContent_txtdarticulo").focus();
                },
                buttons: {
                    Grabar: function () {
                        $("#MainContent_ddlsuboc").val() == "2" ? recorregridpuestopta() : recorregriddetalle();
                        
                        
                    }
                }
            });
        });

        $(function () {
            $('#dvdetallemtto').dialog({
                autoOpen: false,
                modal: true,
                resizable: true,
                width: 800,
                heigth: 100,
                closeOnEscape: false,
                title: 'Detalle',
                open: function (event, ui) {
                }
            });
        });
        

        $(function () {
            $('#dvplanilla').dialog({
                autoOpen: false, modal: true,
                resizable: true,
                width: 950, heigth: 100,
                title: 'Detalle',
                close: function (event, ui) {
                }
              
            });
        });
        

        $(function () {
            $('#dveditar').dialog({
                autoOpen: false,
                modal: true,
                resizable: false,
                width: 380,
                heigth: 45,
                title: 'Detalle'

            });
        });

        $(function () {
            $('#dvimportacion').dialog({
                autoOpen: false,
                modal: true,
                resizable: false,
                width: 380,
                heigth: 45,
                title: 'Importacion'

            });
        });
        


    </script>

    <script type="text/javascript">

        $(function () {
            $("#MainContent_txtprove").autocomplete(
                {
                    source: function (request, response) {

                        var ADATA = {};
                        ADATA.AVANEXO = "P";
                        ADATA.ADESANE = '%' + request.term + '%';
                        ADATA.ATIPTRA = null;

                        $.ajax({
                            url: "OCnueva.aspx/GetProveedores",
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
                                        id: item.ACODANE,
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
                        var str = ui.item.id;
                        var cadena = str;
                        var dire = ui.item.dir;
                        if (str != null || str != undefined) {
                        $('#MainContent_txtidpro').val(str);
                        $('#MainContent_txtdire').val(dire);
                        } else {
                            $('#MainContent_txtidpro').val("");
                            $('#MainContent_txtdire').val("");
                    }
                    },
                    change: function (event, ui) {
                        if (ui.item == null || ui.item == undefined) {
                            $("#MainContent_txtidpro").val("");
                            $("#MainContent_txtprove").val("");
                            $("#MainContent_txtprove").focus();
                            alert("El cliente no se ha seleccionado");
                        }
                    }
                });


            $("#MainContent_txtprove").change(function () {
            if ($("#MainContent_txtprove").val() == "" ) {
                $('#MainContent_txtidpro').val("");
                $('#MainContent_txtdire').val("");
            }
            });

            $("#MainContent_txtidpro").change(function () {
                if (Mostrarunproveedor($(this).val()).ee == "") {
                    alert("No se encontrol informacion");
                    $(this).focus();
                }else{
                    $("#MainContent_txtprove").val(Mostrarunproveedor($(this).val()).ee);
                    $("#MainContent_txtnumref").focus();
                }
            });
            
            $("#MainContent_txtddesca").keypress(function (event) {
                if (event.keyCode == 13) {
                    $('#MainContent_txtdisc').focus();
                }
            });
            

            $("#MainContent_txtcods").change(function () {
                var nomserv = consultaservice($(this).val().trim()).noms;
                if (nomserv == "") {

                    $("#MainContent_txtcods").val("");
                    alert("El Servis no existe");
                } else {
                    $("#MainContent_txtservis").val(nomserv);
                }
            });
            

        });
        $(function () {
            $("#MainContent_ddlccost").autocomplete(
                {
                    source: function (request, response) {
                        $.ajax({
                            url: "OCnueva.aspx/Getcentrocosto",
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
                        var cadena = str
                        posicionEspacio = cadena.indexOf("@"), //Obtengo la posición del espacio en la cadena
                        primerApellido = cadena.substring(0, posicionEspacio) //Obtengo la porción deseada de la cadena
                        enMinuscula = primerApellido.toLowerCase(); //Convierto el apellido a minúscula

                        //primerApellido = cadena.substring(posicionEspacio + 1, str.length)
                        $('#MainContent_txtcodcos').val(str);


                    }
                });

        });

        $(function () {
            $("#MainContent_txtsoli").autocomplete(
                {
                    source: function (request, response) {
                        $.ajax({
                            url: "OCnueva.aspx/Gettablaycodigo",
                            data: "{ 'dato': '" +"%" + request.term+"%" + "',codigo:'12' }",
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
                        posicionEspacio = cadena.indexOf("@"), //Obtengo la posición del espacio en la cadena
                        primerApellido = cadena.substring(0, posicionEspacio) //Obtengo la porción deseada de la cadena
                        enMinuscula = primerApellido.toLowerCase(); //Convierto el apellido a minúscula
                        //primerApellido = cadena.substring(posicionEspacio + 1, str.length)
                        $('#MainContent_txtidsoli').val(str);

                    }
                });




        });

        $(function () {
            $(".soli2").autocomplete(
                {
                    source: function (request, response) {
                        $.ajax({
                            url: "OCnueva.aspx/Gettablaycodigo",
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
                        posicionEspacio = cadena.indexOf("@"), //Obtengo la posición del espacio en la cadena
                        primerApellido = cadena.substring(0, posicionEspacio) //Obtengo la porción deseada de la cadena
                        enMinuscula = primerApellido.toLowerCase(); //Convierto el apellido a minúscula
                        //primerApellido = cadena.substring(posicionEspacio + 1, str.length)
                        $('#MainContent_txtdcodsoli').val(str);

                    }
                });




        });



        $(function () {
            
            $(".idart").autocomplete(

                {
                    source: function (request, response) {
                        $.ajax({
                            url: "OCnueva.aspx/GetProductos", //GetProductos
                            data: "{ 'productos': '" + "%" + request.term + "%" + "',tipop:'" + $("#MainContent_ddltipo").val() + "',subtip:'" + $("#MainContent_ddlsuboc").val() + "',idusuario:'" + $("#hfusu").val() + "',idprovee:'" + $("#MainContent_txtidpro").val() + "',tipolinea:'" + $("#MainContent_chtipolinea").find(":checked").val() + "'  }",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8", 
                            dataFilter: function (data) { return data; },
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        value: item.AR_CDESCRI,
                                        id: item.AR_CCODIGO.trim(),
                                        um: item.AR_CUNIDAD,
                                        igvp: item.AR_NIGVCPR,
                                        fvar: item.AR_CTIPDES,
                                        precu: item.AR_NPRECOM,
                                        estadotar:item.AR_CCONTRO


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
                        var strum = ui.item.um;
                        var strigv = ui.item.igvp;
                        var fijavar = ui.item.fvar;
                        var preciouni = ui.item.precu;
                        var estadotar = ui.item.estadotar;

                        if (estadotar == "S" && $("#Maincontent_ddlsuboc").val() != "2") {

                            alert("El Servicio no se encuetra aprobado");
                            $("#MainContent_txtdcodati").val("");
                            $("#MainContent_txtdarticulo").focus();
                            $("#MainContent_txtdarticulo").val("");
                        } else {

                       

                        if (fijavar.trim() == "F") {
                            $('#MainContent_txtdprec').attr("disabled", true);
                            $('#MainContent_txtdprec').val(preciouni);
                        } else {
                            $('#MainContent_txtdprec').attr("disabled", false);
                            $('#MainContent_txtdprec').val(preciouni);
                        }
                        $('#MainContent_txtdcodati').val(str);
                        $('#MainContent_txtdumed').val(strum);
                        $('#MainContent_txtdigv').val(strigv);
                        }

                        $('#MainContent_hfaprobdesa').val(estadotar);

                    },
                    change: function (event, ui) {
                        if (ui.item == null || ui.item == undefined) {
                            $("#MainContent_txtdcodati").val("");
                            $("#MainContent_txtdarticulo").val("");
                            $("#MainContent_txtdarticulo").focus();
                            alert("No ha seleccionado El producto");
                        }
                    }
                });




        });

        $(function () {
            $(".ccost2").autocomplete(
                {
                    source: function (request, response) {
                        $.ajax({
                            url: "OCnueva.aspx/Getcentrocosto",
                            data: "{ 'dato': '" + request.term + "' }",
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
                            erro0r: function (XMLHttpRequest, textStatus, errorThrown) {
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
                        //primerApellido = cadena.substring(posicionEspacio + 1, str.length)
                        $('#MainContent_txtdcodcost').val(str);


                    }
                });

        });


        $(function () {
            $("#MainContent_ddlfpago").autocomplete(
                {
                    source: function (request, response) {
                        $.ajax({
                            url: "OCnueva.aspx/Getformapago",
                            data: "{ 'texto': '" + request.term + "',cod:'51' }",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            dataFilter: function (data) { return data; },
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        value: item.TG_DESCRI,
                                        id: item.TG_CODIGO.trim()
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


                    }
                });

        });

        $(function () {
            $("#MainContent_txtservis").autocomplete(
                {
                    source: function (request, response) {
                        $.ajax({
                            url: "OCnueva.aspx/GetServis",
                            data: "{ 'texto': '" + request.term + "',area:'"+$("#MainContent_ddlparea").val()+"'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            dataFilter: function (data) { return data; },
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        value: item.descripcion,
                                        id: item.codtra.trim()
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
                        $("#MainContent_txtcods").val(str);
                        $("#MainContent_txtfinis").focus();
                    },
                    change: function (event, ui) {
                        if (ui.item == null || ui.item == undefined) {
                            $("#MainContent_txtcods").val("");
                            $("#MainContent_txtservis").val("");
                            $("#MainContent_txtservis").focus();
                            alert("No ha seleccionado El Service");
                        }
                    }
                });

        });

        

    </script>


    <%-- //clickg --%>

    <script type="text/javascript">
        $(function () {
            $(".btbuscar").click(function () {
                filtarocompra();
            });
            $("#MainContent_chtipolinea").click(function () {
                $(".idart").val("");
                $(".idart").focus();
                
            });
            

            $(".btplan").click(function () {
                if ($("#MainContent_txtidsoli").val() == "") {
                    alert("No ha seleccionado el solicitante");
                    $("#MainContent_txtidsoli").focus();
                } else if ($("#MainContent_txtcodcos").val() == "") {
                    alert("No ha seleccionado el Centro Costo");
                    $("#MainContent_txtcodcos").focus();
                }else{
                guardanomserv = [];
                cont_arrayb = 0;
                sw_plan = 0;
                btnuevo();
                }
            });

            $(".btbuscaplan").click(function () {
                
                var cuentarepe = 0;
                var concatenavar = $("#MainContent_txtcods").val() + $("#MainContent_txtfinis").val()+$("#MainContent_txtffins").val();
                 for (var cr=0;cr<cont_arrayb;cr++){
                     if (concatenavar == guardanomserv[cr]) {
                         cuentarepe = Number(cuentarepe) + 1;
                     }
                 }
                 if (cuentarepe > 0) {
                     alert("El Registro Ya Fue Agregado a la Busqueda");
                 }else{
                     filtarPlanillas();
                 }
            });
            $(".btlimpiaplan").click(function () {
                guardanomserv = [];
                cont_arrayb = 0;
                limpiargrid();
                totalpla = 0;
                $("#MainContent_txttotaplani").val(0);
            });
            
            $(".chktodos").click(function () {
                
                Operacion.Checktodos(this, "<%= gvplan.ClientID %>", 12);
            });

<%--            $(".chktodosmtto").click(function () {
                
                Operacion.Checktodos(this, "<%= gvordencompra.ClientID %>", 21);
            });--%>
            
            $(".btaddplan").click(function () {
                
                recorregriddetalleplan();
            });
            
            $(".txtmost").click(function () {
                //$("#dveditar").dialog('open');
            });

            $(".btmostrar").click(function () {
                var idcompr = $("#MainContent_txtenorden").val();
                MostrarunRegistro(idcompr);
            });

            $(".verinfomtto").click(function () {
                var nordden = $("#MainContent_txtoc").val();
                $('#dvdetallemtto').dialog('open');
                filtarListamtto();
                //MostrarunRegistro(nordden);
            });
            

            $(".bttimp").click(function () {
                $('#dvimportacion').dialog('open');
                MostrarImportacion();

            });
            

            $(".tcamb").change(function () {
                var tcam = MostrarTcambio();
                $("#MainContent_txttcambio").val(tcam);

            });

            $(".btadd").click(function () {
                sw_plan = 1;
                btnuevo();
            });

            $(".imprime").click(function () {
                
                var idnumor = $("#MainContent_txtnumoc").val();
                var idprov = $("#MainContent_txtidpro").val();
                var condicc = $("#MainContent_ddlsuboc").val();
                var desprov = $("#MainContent_txtprove").val().trim().replace(',', '');
                if (idnumor != "" && idprov != "") {
                    if (condicc == '2') {
                        window.open("../ORDENCOMPRA/REPORTES/OTReporteOrden.aspx?ID=" + idnumor + "&IDPROC=" + idprov + "&DEPRO=" + desprov, '_blank');
                    } else if (condicc == '3') {
                        window.open("../ORDENCOMPRA/REPORTES/EXReporteOrden.aspx?ID=" + idnumor + "&IDPROC=" + idprov + "&DEPRO=" + desprov, '_blank');
                    } else {
                        window.open("../ORDENCOMPRA/REPORTES/ReporteOrden.aspx?ID=" + idnumor + "&IDPROC=" + idprov + "&DEPRO=" + desprov, '_blank');
                    }
                } else {
                    alert("Error en envio de Datos");
                }
            });
            


            $(".ctxtidsoli").change(function () {
                
                var textdev = Mostrarundato($("#MainContent_txtidsoli").val(), '12').ee;
                if (textdev != null) {
                    $("#MainContent_txtsoli").val(textdev);
                    Operacion.mask('txtcodcos').focus();
                } else {
                    $("#MainContent_txtsoli").val("");
                    alert("Codigo no existe");
                }
            });

            $("#MainContent_txtdcodsoli").keypress(function (event) {
                if (event.keyCode == 13) {
                    var textdev = Mostrarundato($("#MainContent_txtdcodsoli").val(), '12').ee;
                    if (textdev != "") {
                        $("#MainContent_txtdsoli").val(textdev);
                        $("#MainContent_txtdcodcost").focus();
                    } else {
                        $("#MainContent_txtdsoli").val("");
                        alert("Codigo no existe");
                    }
                }
            });


            $("#MainContent_ddltipo").change(function () {
                validaboton();
            });

            $("#MainContent_ddlsuboc").change(function () {
                validaboton();
            });

            $("#MainContent_txtcodcos").change(function () {
                var textdev = Mostrarundato($("#MainContent_txtcodcos").val(), '10').ee;
                if (textdev != "") {
                    $("#MainContent_ddlccost").val(textdev);

                    if ($("#MainContent_txtenvio").attr("disabled")==false){ 
                        $("#MainContent_txtenvio").focus();
                    }else{
                        $("#MainContent_ddlalma").focus();
                    }
                } else {
                    alert("Codigo no existe");
                    $("#MainContent_ddlccost").val("");
                }
            });

            $("#MainContent_txtdcodcost").keypress(function (event) {
                if (event.keyCode == 13) {

                    var textdev = Mostrarundato($("#MainContent_txtdcodcost").val(), '10').ee;
                    if (textdev != "") {
                        $("#MainContent_txtdccost").val(textdev);
                        Operacion.mask('txtddesci').focus();
                    } else {
                        alert("Codigo no existe");
                        $("#MainContent_txtdccost").val("");
                    }
                }
            });


            $(".btaddd").click(function () {
                if ($("#MainContent_txtdcodati").val() == "") {
                    alert("Debe ingresar el producto");
                    $("#MainContent_txtdarticulo").focus();
                } else if ($("#MainContent_txtdcant").val() == "" || $("#MainContent_txtdcant").val()<1) {
                    alert("Debe ingresar cantidad");
                    $("#MainContent_txtdcant").focus();
                } else if ($("#MainContent_txtdcodsoli").val() == "" || $("#MainContent_txtdsoli").val() == "") {
                    alert("Debe ingresar el solicitante");
                    $("#MainContent_txtdcodsoli").focus();
                } else if ($("#MainContent_txtdcodcost").val() == "" || $("#MainContent_txtdccost").val() == "") {
                    alert("Debe ingresar el Centro Costo");
                    $("#MainContent_txtdcodcost").focus();
                } else if ($("#MainContent_txtdprec").val() == "" || $("#MainContent_txtdprec").val() < 0) {
                    alert("Debe ingresar Precio");
                    $("#MainContent_txtdprec").focus();
                }else if ($("#MainContent_hfaprobdesa").val()== "S") {
                    alert("El Producto Se Encuentra desaprobado");
                    $("#MainContent_txtdarticulo").focus();
                } else {
                    VerDetalleGrid();
                }
            });



            $(".chigv").click(function () {

                if ($("#MainContent_chkigv").attr("checked") == true) {

                    $("#MainContent_txtdigv").attr("disabled", false);
                    Operacion.mask('txtdigv').focus();
                } else {
                    $("#MainContent_txtdigv").attr("disabled", true);
                }
            });

            $(".btiarr").click(function () {

                guardarimporttmp();
                
            }); 

            $(".selalma").change(function () {
                var idc = MostrarDireccionAl();
                var inf01 = idc.dato;
                var inf02 = idc.dato2;
                var inf03 = idc.dato3;

                $("#MainContent_txtlentre").val(inf01);
                $("#MainContent_txtdist").val(inf02);
                $("#MainContent_txtprov").val(inf02);
            });


            $(".btelimina").click(function () {
                ITEM_COD = "";
                CCOD = "";
                var trp = $(this).parent().parent();
                var itemde = $("td:eq(2)", trp).html();
                ITEM_COD = $("td:eq(0)", trp).html();
                CCOD = $("td:eq(1)", trp).html();
                var ques_base = $("td:eq(18)", trp).val();

                if (ITEM_COD !=""){
                if (confirm("Esta Seguro que Desea eliminar el Item: " + itemde)) {
                    if (ques_base == "B") {
                        Eliminaciondet();
                        Eliminaciondetplanilla();
                        if ($("#MainContent_ddlsuboc").val() == "2") { EliminaciondetOT($("#MainContent_txtoc").val()); }
                    }

                    if (Number(contarndw) > 1) {
                        trp.remove();
                        contarndw = Number(contarndw) - 1;
                       
                    } else { 
                        cc = 1;
                        $("td:eq(0)", trp).html(""); $("td:eq(1)", trp).html("");
                        $("td:eq(2)", trp).html(""); $("td:eq(3)", trp).html("");
                        $("td:eq(4)", trp).html(""); $("td:eq(5)", trp).html("");
                        $("td:eq(6)", trp).html(""); $("td:eq(7)", trp).html("");
                        $("td:eq(8)", trp).html(""); $("td:eq(9)", trp).html("");
                        $("td:eq(10)", trp).html(""); $("td:eq(11)", trp).html("");
                        $("td:eq(12)", trp).html(""); $("td:eq(13)", trp).html("");
                        $("td:eq(14)", trp).html(""); $("td:eq(15)", trp).html("");
                        $("td:eq(16)", trp).html(""); $("td:eq(17)", trp).html("");
                        $("td:eq(18)", trp).html("");
                        $("td:eq(0)", trp).val(""); $("td:eq(1)", trp).val("");
                        $("td:eq(2)", trp).val(""); $("td:eq(3)", trp).val("");
                        $("td:eq(4)", trp).val(""); $("td:eq(5)", trp).val("");
                        $("td:eq(6)", trp).val(""); $("td:eq(7)", trp).val("");
                        $("td:eq(8)", trp).val(""); $("td:eq(9)", trp).val("");
                        $("td:eq(10)", trp).val(""); $("td:eq(11)", trp).val("");
                        $("td:eq(12)", trp).val(""); $("td:eq(13)", trp).val("");
                        $("td:eq(14)", trp).val(""); $("td:eq(15)", trp).val("");
                        $("td:eq(16)", trp).val(""); $("td:eq(17)", trp).val("");
                        $("td:eq(18)", trp).val("");
                    }
                    sumapiedetalle();
                }
                }
            });

            $(".btedita").click(function () {

                trpedita = $(this).parent().parent();
                var formaedita = $("td:eq(9)", trpedita).val();
                var itmvacio = $("td:eq(0)", trpedita).html();

                if (itmvacio!=""){
                if (formaedita == "1") {
                    alert("El item no es editable");
                    sw_edicion = 0;
                }else{
                var extraefila = [];
                var extraefilaval = [];
                

                
                for (var i = 0; i < 19; i++) {
                    var itemde = $("td:eq(" + i + ")", trpedita).html();
                    var itemdeval = $("td:eq(" + i + ")", trpedita).val();
                    extraefila[i] = itemde;
                    extraefilaval[i] = itemdeval;
                }

                $("#MainContent_txtdcodati").val(extraefila[1]);
                $("#MainContent_txtdarticulo").val(extraefila[2]);
                $("#MainContent_txtdprec").val(extraefila[5])
                $("#MainContent_txtdumed").val(extraefila[3]);
                $("#MainContent_txtdcant").val(extraefila[4]);
                $("#MainContent_txtddesca").val(extraefila[6]);
                $("#MainContent_txtddesci").val(extraefila[7]);
                $("#MainContent_txtdigv").val(extraefila[8]);
                $("#MainContent_txtdisc").val(extraefila[9]);
                $("#MainContent_txtdfechat1").val(extraefila[16]);
                $("#MainContent_txtdcomen").val(extraefilaval[4]);

                if (extraefilaval[8] == "0") {
                    $("#MainContent_chkigv").attr("checked", false);
                } else {
                    $("#MainContent_chkigv").attr("checked", true);
                }

                $("#MainContent_txtdcodcost").val(extraefilaval[1]);
                $("#MainContent_txtdccost").val(extraefilaval[2]);
                $("#MainContent_txtdcodsoli").val(extraefilaval[14]);
                $("#MainContent_txtdsoli").val(extraefilaval[15]);
                $("#MainContent_txtddescf").val(extraefilaval[3]);

                var textdev = Mostrarundato(extraefilaval[1], '10').ee;
                
                if (textdev != "") {
                    $("#MainContent_txtdccost").val(textdev);
                } else {
                    $("#MainContent_txtdccost").val("");
                }

                var textdev = Mostrarundato(extraefilaval[14], '12').ee;
                if (textdev != "") {
                    $("#MainContent_txtdsoli").val(textdev);
                } else {
                    $("#MainContent_txtdsoli").val("");
                }

                sw_edicion = 1;

                $(".btaddd").attr("value", "Actualizar");
                }

                }

            });

          

        });

    </script>


    <script type="text/javascript">

        function validaboton(){
            var textdev = $("#MainContent_ddltipo").val();
            var textsuboc = $("#MainContent_ddlsuboc").val();
            if (textdev == "I") {
                $(".bttimp").show();
                $(".btplan").hide();
                $("#MainContent_ddlsuboc").attr("disabled", true);
                $(".btadd").show();
                $("#MainContent_ddldocre").attr("disabled", false);
                $("#MainContent_ddltdespa").attr("disabled", false);
                $("#MainContent_txtenvio").attr("disabled", false);
                $("#MainContent_txtremi").attr("disabled", false);
                $("#MainContent_txtaten").attr("disabled", false);
                $("#MainContent_txtdfina").attr("disabled", false);
                $("#MainContent_ddlsuboc").val("-1");
            } else if (textdev == "N") {
                $(".bttimp").hide();
                $(".btplan").hide();
                $(".btadd").show();
                $("#MainContent_ddlsuboc").attr("disabled", true);
                $("#MainContent_ddldocre").attr("disabled", false);
                $("#MainContent_ddltdespa").attr("disabled", false);
                $("#MainContent_txtenvio").attr("disabled", false);
                $("#MainContent_txtremi").attr("disabled", false);
                $("#MainContent_txtaten").attr("disabled", false);
                $("#MainContent_txtdfina").attr("disabled", false);
                $("#MainContent_ddlsuboc").val("-1");
        } else if (textdev == 'S') {
            $("#MainContent_ddlsuboc").attr("disabled", false);
            $("#MainContent_ddldocre").attr("disabled", true);
            if (textsuboc == "3") {
                $("#MainContent_ddltdespa").attr("disabled", false);
            }else{
            $("#MainContent_ddltdespa").attr("disabled", true);
            }
            $("#MainContent_txtenvio").attr("disabled", true);
            $("#MainContent_txtremi").attr("disabled", true);
            $("#MainContent_txtaten").attr("disabled", true);
            $("#MainContent_txtdfina").attr("disabled", true);
            if (textsuboc == "1") {
                $(".bttimp").hide();
                $(".btplan").show();
                $(".btadd").hide();

            } else {

                $(".bttimp").hide();
                $(".btplan").hide();
                $(".btadd").show();
            }
        }
        }

        function limpiartextodetalle() {
            
            $("#MainContent_txtdarticulo").val("");
            $("#MainContent_txtdcodati").val("");
            $("#MainContent_txtdumed").val("");
            $("#MainContent_txtdcant").val("");
            $("#MainContent_txtdprec").val("");
            if ($("#MainContent_ddlsuboc").val()!="3"){
                //$("#MainContent_txtdcodsoli").val("");
                //$("#MainContent_txtdsoli").val("");
                //$("#MainContent_txtdcodcost").val("");
                //$("#MainContent_txtdccost").val(""); 
                //$("#MainContent_txtdfechat1").val("");
            }
            $("#MainContent_txtddesci").val(0);
            $("#MainContent_txtddesca").val(0);
            $("#MainContent_txtdigv").val(0);
            $("#MainContent_txtdisc").val(0);
            $("#MainContent_txtdcomen").val("");
        }


        function sumapiedetalle() {
            var sub01 = recorregrid().sumasub; var des01 = recorregrid().sumadesc;
            var igv01 = recorregrid().sumaigvv; var tot01 = recorregrid().sumatotall;

            $("#MainContent_txttbrutof").val(sub01.toFixed(2));
            $("#MainContent_txtdescf").val(des01.toFixed(2));
            $("#MainContent_txtigvf").val(igv01.toFixed(2));
            $("#MainContent_txtnetof").val(tot01.toFixed(2));
        }
           function recorregriddetalle(){

            gitem = "";
            gidcod = "";
            gdescod = "";
            gobser = "";
            gunid = "";
            gcant = 0;
            gprecfinal = 0; gprecinicial = 0;
            gdesitem = 0; gdesitemx = 0;
            gdesadic = 0; gdesadicx = 0;
            gtotaldesc = 0; gtotaldescx = 0;
            gigv = 0; gigvx = 0; gvalidaigvx = 0;
            gisc = 0; giscx = 0;
            gcantent = 0; gcantsald = 0;
            gtus01 = 0; gtmn01 = 0; gsumasoles = 0; gsumadolares = 0;
            gestado = "1";
            gfechaent = "";
            subbt = "";ccosto="";ccodsol="";

            var gridView = document.getElementById("<%=gvordencompra.ClientID %>");

            for (var t = 1; t < gridView.rows.length; t++) {

                cellPivot = gridView.rows[t].cells[0]; gitem = cellPivot.innerHTML;
                cellPivot02 = gridView.rows[t].cells[1]; gidcod = cellPivot02.innerHTML;
                cellPivot021 = gridView.rows[t].cells[1]; ccosto = cellPivot021.value;
                cellPivot03 = gridView.rows[t].cells[2]; gdescod = cellPivot03.innerHTML;
                cellPivot04 = gridView.rows[t].cells[3]; gunid = cellPivot04.innerHTML;
                cellPivot05 = gridView.rows[t].cells[4]; gcant = cellPivot05.innerHTML;
                cellPivot06 = gridView.rows[t].cells[5]; gprecinicial = cellPivot06.innerHTML;
                cellPivot07 = gridView.rows[t].cells[6]; gdesadicx = cellPivot07.innerHTML;
                cellPivot21 = gridView.rows[t].cells[6]; gdesadic = cellPivot21.value;
                cellPivot08 = gridView.rows[t].cells[7]; gdesitemx = cellPivot08.innerHTML;
                cellPivot20 = gridView.rows[t].cells[7]; gdesitem = cellPivot20.value;
                cellPivot09 = gridView.rows[t].cells[8]; gigvx = cellPivot09.innerHTML;
                cellPivot25 = gridView.rows[t].cells[8]; gvalidaigvx = cellPivot25.value;
                cellPivot10 = gridView.rows[t].cells[9]; giscx = cellPivot10.innerHTML;
                cellPivot11 = gridView.rows[t].cells[10]; gprecfinal = cellPivot11.innerHTML;
                cellPivot12 = gridView.rows[t].cells[11]; gtotaldesc = cellPivot12.innerHTML;
                cellPivot22 = gridView.rows[t].cells[11]; gtotaldescx = cellPivot22.value;
                cellPivot13 = gridView.rows[t].cells[12]; gigv = cellPivot13.innerHTML;
                //cellPivot14 = gridView.rows[t].cells[13]; subbt = cellPivot14.innerHTML;//subtotal 
                cellPivot15 = gridView.rows[t].cells[14]; gcantent = cellPivot15.innerHTML;
                cellPivot151 = gridView.rows[t].cells[14]; ccodsol = cellPivot151.value;
                cellPivot23 = gridView.rows[t].cells[16]; gtus01 = cellPivot23.value;
                cellPivot16 = gridView.rows[t].cells[15]; gcantsald = cellPivot16.innerHTML;
                cellPivot24 = gridView.rows[t].cells[17]; gtmn01 = cellPivot24.value;
                cellPivot17 = gridView.rows[t].cells[16]; gfechaent = cellPivot17.innerHTML;
                cellPivot18 = gridView.rows[t].cells[4]; gobser = cellPivot18.value;
                cellPivot19 = gridView.rows[t].cells[18]; gisc = cellPivot19.innerHTML;
                gsumadolares = Number(gsumadolares) + Number(gtus01);
                gsumasoles = Number(gsumasoles) + Number(gtmn01);

                InsertarDetalle("InsertaDet");
                InsertarDetallecopia();
            }


           
            Modicacabmontos($("#MainContent_txtnumoc").val(), gsumadolares.toFixed(3), gsumasoles.toFixed(3));
            alert("Registro Grabado");
        }


                function recorregriddetalleplan(){



            gitem = ""; gidcod = "";gdescod = ""; gobser = "";gunid = "";
            gcant = 0;
            gprecfinal = 0; gprecinicial = 0;
            gdesitem = 0; gdesitemx = 0;
            gdesadic = 0; gdesadicx = 0;
            gtotaldesc = 0; gtotaldescx = 0;
            gigv = 0; gigvx = 0; gvalidaigvx = 0;
            gisc = 0; giscx = 0;
            gcantent = 0; gcantsald = 0;
            gtus01 = 0; gtmn01 = 0; gsumasoles = 0; gsumadolares = 0;
            gestado = "1"; gfechaent = ""; subbt = ""; ccosto = ""; ccodsol = ""; bknumplan = "";
            bkdescri1 = ""; bkdescri2 = ""; bkdescri3 = ""; bkcodprodplan = ""; bk_nguia = "";

            var gridView = document.getElementById("<%=gvplan.ClientID %>");
                    cuentachk = 0;
            for (var t = 1; t < gridView.rows.length; t++) {
                var inputs = gridView.rows[t].getElementsByTagName('input');
                if (inputs[0].type == "checkbox" && inputs[0].checked) {
                    cellPivot = gridView.rows[t].cells[1]; gitem = cellPivot.value;
                    cellPivot02 = gridView.rows[t].cells[0]; gidcod = cellPivot02.value;//cambiar a value
                    cellPivot03 = gridView.rows[t].cells[6]; gdescod = cellPivot03.innerHTML;
                    cellPivot04 = gridView.rows[t].cells[3]; gunid = "KG";//cellPivot04.innerHTML;
                    cellPivot05 = gridView.rows[t].cells[7]; gcant = cellPivot05.innerHTML;
                    cellPivot06 = gridView.rows[t].cells[8]; gprecinicial = cellPivot06.innerHTML;
                    cellPivot07 = gridView.rows[t].cells[6]; gdesadicx = 0; //cellPivot07.innerHTML;
                    cellPivot21 = gridView.rows[t].cells[6]; gdesadic = 0;//cellPivot21.value;
                    cellPivot08 = gridView.rows[t].cells[7]; gdesitemx = 0; //cellPivot08.innerHTML;
                    cellPivot20 = gridView.rows[t].cells[7]; gdesitem = 0;//cellPivot20.value;
                    cellPivot09 = gridView.rows[t].cells[8]; gigvx = 18;//cellPivot09.innerHTML;
                    cellPivot25 = gridView.rows[t].cells[8]; gvalidaigvx = 18;//cellPivot25.value;
                    cellPivot10 = gridView.rows[t].cells[9]; giscx = 0;// cellPivot10.innerHTML;
                    cellPivot11 = gridView.rows[t].cells[8]; gprecfinal = cellPivot11.value;
                    cellPivot12 = gridView.rows[t].cells[11]; gtotaldesc = 0;//cellPivot12.innerHTML;
                    cellPivot22 = gridView.rows[t].cells[11]; gtotaldescx = 0;// cellPivot22.value;
                    cellPivot13 = gridView.rows[t].cells[12]; gigv = (gprecinicial * gcant) * 0.18;//cellPivot13.innerHTML;
                    //cellPivot14 = gridView.rows[t].cells[13]; subbt = cellPivot14.innerHTML;//subtotal 
                    cellPivot15 = gridView.rows[t].cells[14]; gcantent = 0;//cellPivot15.innerHTML;
                    cellPivot23 = gridView.rows[t].cells[10]; gtus01 = cellPivot23.value;
                    cellPivot16 = gridView.rows[t].cells[7]; gcantsald = cellPivot16.innerHTML;
                    cellPivot24 = gridView.rows[t].cells[9]; gtmn01 = cellPivot24.value;
                    cellPivot17 = gridView.rows[t].cells[0]; gfechaent = cellPivot17.innerHTML;
                    cellPivot18 = gridView.rows[t].cells[17]; gobser = ""; //cellPivot18.innerHTML;
                    cellPivot19 = gridView.rows[t].cells[18]; gisc = 0;//cellPivot19.innerHTML;
                    cellPivot20 = gridView.rows[t].cells[3]; bknumplan = cellPivot20.innerHTML;//numero de planilla
                    cellPivot21 = gridView.rows[t].cells[4]; bkdescri1 = cellPivot21.innerHTML;//descripcion1
                    cellPivot22 = gridView.rows[t].cells[5]; bkdescri2 = cellPivot22.innerHTML;//descripcion2
                    cellPivot23 = gridView.rows[t].cells[6]; bkdescri3 = cellPivot23.innerHTML;//descripcion2
                    cellPivot24 = gridView.rows[t].cells[9]; bktotal = cellPivot24.innerHTML;//descripcion2
                    cellPivot25 = gridView.rows[t].cells[2]; bkcodprodplan = cellPivot25.value;//codigo planilla
                    cellPivot26 = gridView.rows[t].cells[11]; bk_nguia = cellPivot26.innerHTML; //numero guia 
                    gsumadolares = Number(gsumadolares) + Number(gtus01);
                    gsumasoles = Number(gsumasoles) + Number(gtmn01);
                    ccosto = $("#MainContent_txtcodcos").val().trim();
                    ccodsol = $("#MainContent_txtidsoli").val().trim();
                    InsertarDetalle("InsertaDetplanilla");
                    InsertarDetallecopia();
                    InsertarDetalleordenplan();
                    cuentachk++;

                }
            }
            
            Modicacabmontos($("#MainContent_txtnumoc").val(), gsumadolares.toFixed(4), gsumasoles.toFixed(4));
            if (cuentachk > 0) { alert("Registro Grabado"); $(".btadd").show(); } else { alert("No ha Seleccionado Ninguno"); }
                }



                   function recorregridpuestopta(){
                       cuentaregis = 0;
                       gitem = "";
                       gidcod = "";
                       gdescod = "";
                       gobser = "";
                       gunid = "";
                       gcant = 0;
                       gprecfinal = 0; gprecinicial = 0;
                       gdesitem = 0; gdesitemx = 0;
                       gdesadic = 0; gdesadicx = 0;
                       gtotaldesc = 0; gtotaldescx = 0;
                       gigv = 0; gigvx = 0; gvalidaigvx = 0;
                       gisc = 0; giscx = 0;
                       gcantent = 0; gcantsald = 0;
                       gtus01 = 0; gtmn01 = 0; gsumasoles = 0; gsumadolares = 0;
                       gestado = "1";
                       gfechaent = ""; gfechaentt = "";
                       subbt = ""; ccosto = ""; ccodsol = "";
                       gtipoarticulo = "";
                       sumaprecioo = 0;sumadstoitem = 0;sumadstoadic = 0; sumadstofina = 0; sumaigvt = 0; sumapreciof = 0;
                       gitems = ""; sumagtmn = 0; sumagtus = 0; ccostott = ""; ccodsolit = "";
            var gridView = document.getElementById("<%=gvordencompra.ClientID %>");

            for (var t = 1; t < gridView.rows.length; t++) {
                cellPivottp = gridView.rows[t].cells[5]; gtipoarticulo = cellPivottp.value;

                cellPivot = gridView.rows[t].cells[0]; gitem = cellPivot.innerHTML;
                cellPivot02 = gridView.rows[t].cells[1]; gidcod = cellPivot02.innerHTML;
                cellPivot021 = gridView.rows[t].cells[1]; ccosto = cellPivot021.value;
                cellPivot03 = gridView.rows[t].cells[2]; gdescod = cellPivot03.innerHTML;
                cellPivot04 = gridView.rows[t].cells[3]; gunid = cellPivot04.innerHTML;
                cellPivot05 = gridView.rows[t].cells[4]; gcant = cellPivot05.innerHTML;
                cellPivot06 = gridView.rows[t].cells[5]; gprecinicial = cellPivot06.innerHTML;
                cellPivot07 = gridView.rows[t].cells[6]; gdesadicx = cellPivot07.innerHTML;
                cellPivot21 = gridView.rows[t].cells[6]; gdesadic = cellPivot21.value;
                cellPivot08 = gridView.rows[t].cells[7]; gdesitemx = cellPivot08.innerHTML;
                cellPivot20 = gridView.rows[t].cells[7]; gdesitem = cellPivot20.value;
                cellPivot09 = gridView.rows[t].cells[8]; gigvx = cellPivot09.innerHTML;
                cellPivot25 = gridView.rows[t].cells[8]; gvalidaigvx = cellPivot25.value;
                cellPivot10 = gridView.rows[t].cells[9]; giscx = cellPivot10.innerHTML;
                cellPivot11 = gridView.rows[t].cells[10]; gprecfinal = cellPivot11.innerHTML;
                cellPivot12 = gridView.rows[t].cells[11]; gtotaldesc = cellPivot12.innerHTML;
                cellPivot22 = gridView.rows[t].cells[11]; gtotaldescx = cellPivot22.value;
                cellPivot13 = gridView.rows[t].cells[12]; gigv = cellPivot13.innerHTML;
                //cellPivot14 = gridView.rows[t].cells[13]; subbt = cellPivot14.innerHTML;//subtotal 
                cellPivot15 = gridView.rows[t].cells[14]; gcantent = cellPivot15.innerHTML;
                cellPivot151 = gridView.rows[t].cells[14]; ccodsol = cellPivot151.value;
                cellPivot23 = gridView.rows[t].cells[16]; gtus01 = cellPivot23.value;
                cellPivot16 = gridView.rows[t].cells[15]; gcantsald = cellPivot16.innerHTML;
                cellPivot24 = gridView.rows[t].cells[17]; gtmn01 = cellPivot24.value;
                cellPivot17 = gridView.rows[t].cells[16]; gfechaent = cellPivot17.innerHTML;
                cellPivot18 = gridView.rows[t].cells[4]; gobser = cellPivot18.value;
                cellPivot19 = gridView.rows[t].cells[18]; gisc = cellPivot19.innerHTML;
                gsumadolares = Number(gsumadolares) + Number(gtus01);
                gsumasoles = Number(gsumasoles) + Number(gtmn01);

                if (gtipoarticulo == "M") {
                    
                    sumaprecioo = Number(sumaprecioo) + Number(gprecinicial);
                    sumadstoitem = Number(sumadstoitem) + Number(gdesitem);
                    sumadstoadic = Number(sumadstoadic) + Number(gdesadic);
                    //sumadstofina = sumadstofina+;
                    sumaigvt = Number(sumaigvt) + Number(gigv);
                    sumapreciof = Number(sumapreciof) + (Number(gprecfinal) * Number(gcant));
                    sumagtmn = Number(sumagtmn) + Number(gtmn01);
                    sumagtus = Number(sumagtus) + Number(gtus01);
                    cuentaregis++;
                    ccostott = ccosto;
                    ccodsolit = ccodsol;
                    gfechaentt = gfechaent;
                    
                }
                if (gtipoarticulo == "R") {
                    gitems = Number(gitems) + 1;
                    InsertarDetalle("InsertaDet");
                    InsertarDetallecopia();
                }
                if (gidcod.trim() != 'R050010012009') { InsertarDetalle("InsertaDet_Anexo") };

            }
            if (cuentaregis > 0) { InsertarDetalleMtto("InsertaDet"); }
            Modicacabmontos($("#MainContent_txtnumoc").val(), gsumadolares.toFixed(3), gsumasoles.toFixed(3));
            alert("Registro Grabado");
        }
    </script>
    <script type="text/javascript">

        function InsertarDetalle(wmetodo) {

            var horao = obetenerhora();

            var fec1 = moment($("#MainContent_txtfecha1").val(), "DD/MM/YYYY");
            fec1 = fec1 == null ? null : new Date(fec1);
            var fec2 = moment(gfechaent, "DD/MM/YYYY");
            fec2 = fec2 == null ? null : new Date(fec2);

            var dfactual = moment($("#MainContent_hffactual").val(), "DD/MM/YYYY");
            dfactual = dfactual == null ? null : new Date(dfactual);

            var DETA = {};

            DETA.OC_CNUMORD = $("#MainContent_txtnumoc").val().trim();
            DETA.OC_CCODPRO = $("#MainContent_txtidpro").val().trim();
            DETA.OC_CITEM = gitem;
            DETA.OC_CCODIGO = gidcod;
            DETA.OC_CCODREF = "";
            DETA.OC_CDESREF = gdescod;
            DETA.OC_CUNIPRO = "";
            DETA.OC_CDEUNPR = "";
            DETA.OC_CUNIDAD = gunid;
            DETA.OC_NCANORD = gcant;
            DETA.OC_NPREUNI = gprecfinal;
            DETA.OC_NPREUN2 = gprecinicial;
            DETA.OC_NDSCPFI = 0;
            DETA.OC_NDESCFI = 0;
            DETA.OC_NDSCPIT = gdesitemx;
            DETA.OC_NDESCIT = gdesitem;
            DETA.OC_NDSCPAD = gdesadicx;//
            DETA.OC_NDESCAD = gdesadic;
            DETA.OC_NDSCPOR = gtotaldescx;
            DETA.OC_NDESCTO = gtotaldesc;
            DETA.OC_NIGV = gigv;
            DETA.OC_NIGVPOR = gigvx;
            DETA.OC_NISC = gisc;
            DETA.OC_NISCPOR = giscx;
            DETA.OC_NCANTEN = gcantent;
            DETA.OC_NCANSAL = gcantsald;
            DETA.OC_NTOTUS = gtus01;
            DETA.OC_NTOTMN = gtmn01;
            DETA.OC_COMENTA = gobser;
            DETA.OC_CESTADO = gestado;
            DETA.OC_FUNICOM = "";
            DETA.OC_NCANREF = 0;
            DETA.OC_CSERIE = "";
            DETA.OC_NANCHO = 0;
            DETA.OC_NCORTE = 0;
            DETA.OC_DFECDOC = fec1;
            DETA.OC_CTIPORD = $("#MainContent_ddltipo").val().trim();
            DETA.OC_CCENCOS = ccosto;
            DETA.OC_CNUMREQ = "";
            DETA.OC_CSOLICI = ccodsol;
            DETA.OC_CITEREQ = "";
            DETA.OC_CREFCOD = "";
            DETA.OC_CPEDINT = "";
            DETA.OC_CITEINT = "";
            DETA.OC_CREFCOM = "";
            DETA.OC_CNOMFAB = "";
            DETA.OC_NCANEMB = 0;
            DETA.OC_DFECENT = fec2;
            DETA.OC_CITMPOR = (gdesitemx == 0 ? "N" : "S");
            DETA.OC_CDSCPOR = (gdesadicx == 0 ? "N" : "S");
            DETA.OC_CIGVPOR = (gvalidaigvx == 0 ? "N" : "S");
            DETA.OC_CISCPOR = (giscx == 0 ? "N" : "S");
            DETA.OC_NTOTMO = 0;
            DETA.OC_NUNXENV = 0;
            DETA.OC_NNUMENV = 0;
            DETA.OC_NCANFAC = 0;
            $.ajax({

                type: "POST",
                url: "OCnueva.aspx/"+wmetodo,
                data: '{DETA: ' + JSON.stringify(DETA) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (response) {

                },
                error: function (response) {
                    if (response.length != 0)
                        //alert(response);
                        console.table(response);
                }
            });

        }

        function InsertarDetalleMtto(wmetodo) {

            var horao = obetenerhora();

            var fec1 = moment($("#MainContent_txtfecha1").val(), "DD/MM/YYYY");
            fec1 = fec1 == null ? null : new Date(fec1);
            var fec2 = moment(gfechaentt, "DD/MM/YYYY");
            fec2 = fec2 == null ? null : new Date(fec2);

            var dfactual = moment($("#MainContent_hffactual").val(), "DD/MM/YYYY");
            dfactual = dfactual == null ? null : new Date(dfactual);

            var DETA = {};
            gitems = ("000" + (Number(gitems) + 1)).slice(-4);
            DETA.OC_CNUMORD = $("#MainContent_txtnumoc").val().trim();
            DETA.OC_CCODPRO = $("#MainContent_txtidpro").val().trim();
            DETA.OC_CITEM = gitems;
            DETA.OC_CCODIGO = "R050010012009";
            DETA.OC_CCODREF = "";
            DETA.OC_CDESREF = "MATERIALES PUESTO EN PLANTA";
            DETA.OC_CUNIPRO = "";
            DETA.OC_CDEUNPR = "";
            DETA.OC_CUNIDAD = "UND";
            DETA.OC_NCANORD = 1;
            DETA.OC_NPREUNI = sumapreciof;
            DETA.OC_NPREUN2 = sumaprecioo;
            DETA.OC_NDSCPFI = 0;
            DETA.OC_NDESCFI = 0;
            DETA.OC_NDSCPIT = 0;
            DETA.OC_NDESCIT = sumadstoitem;
            DETA.OC_NDSCPAD = 0;//
            DETA.OC_NDESCAD = sumadstoadic;
            DETA.OC_NDSCPOR = 0;
            DETA.OC_NDESCTO = gtotaldesc;
            DETA.OC_NIGV = sumaigvt;
            DETA.OC_NIGVPOR = 18;
            DETA.OC_NISC = 0;
            DETA.OC_NISCPOR = 0;
            DETA.OC_NCANTEN = 1;
            DETA.OC_NCANSAL = 1;
            DETA.OC_NTOTUS = sumagtus;
            DETA.OC_NTOTMN = sumagtmn;
            DETA.OC_COMENTA = "";
            DETA.OC_CESTADO = 1;
            DETA.OC_FUNICOM = "";
            DETA.OC_NCANREF = 0;
            DETA.OC_CSERIE = "";
            DETA.OC_NANCHO = 0;
            DETA.OC_NCORTE = 0;
            DETA.OC_DFECDOC = fec1;
            DETA.OC_CTIPORD = $("#MainContent_ddltipo").val().trim();
            DETA.OC_CCENCOS = ccostott;
            DETA.OC_CNUMREQ = "";
            DETA.OC_CSOLICI = ccodsolit;
            DETA.OC_CITEREQ = "";
            DETA.OC_CREFCOD = "";
            DETA.OC_CPEDINT = "";
            DETA.OC_CITEINT = "";
            DETA.OC_CREFCOM = "";
            DETA.OC_CNOMFAB = "";
            DETA.OC_NCANEMB = 0;
            DETA.OC_DFECENT = fec2;
            DETA.OC_CITMPOR = "N";
            DETA.OC_CDSCPOR = "N";
            DETA.OC_CIGVPOR = "N";
            DETA.OC_CISCPOR = "N";
            DETA.OC_NTOTMO = 0;
            DETA.OC_NUNXENV = 0;
            DETA.OC_NNUMENV = 0;
            DETA.OC_NCANFAC = 0;
            $.ajax({

                type: "POST",
                url: "OCnueva.aspx/" + wmetodo,
                data: '{DETA: ' + JSON.stringify(DETA) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (response) {

                },
                error: function (response) {
                    if (response.length != 0)
                        //alert(response);
                        console.table(response);
                }
            });

        }

        function InsertarDetallecopia() {

            var horao = obetenerhora();

            var fec1 = moment($("#MainContent_txtfecha1").val(), "DD/MM/YYYY");
            fec1 = fec1 == null ? null : new Date(fec1);
            var fec2 = moment(gfechaent, "DD/MM/YYYY");
            fec2 = fec2 == null ? null : new Date(fec2);

            var dfactual = moment($("#MainContent_hffactual").val(), "DD/MM/YYYY");
            dfactual = dfactual == null ? null : new Date(dfactual);

            var DETA = {};

            DETA.PM_CCODMAT=gidcod;
            DETA.PM_CCODPRO=$("#MainContent_txtidpro").val().trim();
            DETA.PM_DFECDOC=fec1;
            DETA.PM_CTIPMON=$("#MainContent_ddlmone").val().trim();
            DETA.PM_NVALOR = gprecinicial;
            DETA.PM_CCOTIZA=$("#MainContent_txtnumref").val().trim();
            DETA.PM_CORDCOM=$("#MainContent_txtnumoc").val().trim();
            DETA.PM_DFECCRE=dfactual;
            //DETA.PM_DFECMOD=;
            DETA.PM_CHORA= horao;
            DETA.PM_CUSER=$("#MainContent_hfusu").val().trim();


            $.ajax({

                type: "POST",
                url: "OCnueva.aspx/InsertarOChistorial",
                data: '{DETA: ' + JSON.stringify(DETA) + '}',
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

        function filtarListocompra() {
            gsumadolaresf = 0; gsumasolesf = 0;
            var LDE = {};
            LDE.OC_CNUMORD = $("#MainContent_txtnumoc").val();
            contarndw = 0;
            $.ajax({
                type: "POST",
                url: "OCnueva.aspx/GetListaDetalle",
                data: '{LDE: ' + JSON.stringify(LDE) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false ,
                success: function (data) {

                    if (data.d.length > 0) {
                        var row = $("[id*=gvordencompra] tr:last-child").clone(true);
                        $("[id*=gvordencompra] tr").not($("[id*=gvordencompra] tr:first-child")).remove();
                        
                        for (var i = 0; i < data.d.length; i++) {

                            $("td", row).eq(0).html(data.d[i].OC_CITEM);
                            $("td", row).eq(1).html(data.d[i].OC_CCODIGO);
                            $("td", row).eq(1).val(data.d[i].OC_CCENCOS);
                            $("td", row).eq(2).html(data.d[i].OC_CDESREF);
                            $("td", row).eq(2).val("");//descripcion centro costo
                            $("td", row).eq(3).html(data.d[i].OC_CUNIDAD);
                            $("td", row).eq(3).val(data.d[i].OC_NDSCPFI);
                            $("td", row).eq(4).html(data.d[i].OC_NCANORD);
                            $("td", row).eq(4).val(data.d[i].OC_COMENTA);
                            $("td", row).eq(5).html(data.d[i].OC_NPREUN2);
                            if (data.d[i].OC_CCODIGO.substring(0, 1) == "R") {
                                $("td", row).eq(2).css("color", "black");
                                $("td", row).eq(5).val("R");
                            } else {
                                $("td", row).eq(2).css("color", "#FF5722");
                                $("td", row).eq(5).val("M");
                            }
                            $("td", row).eq(6).html(data.d[i].OC_NDSCPAD);
                            $("td", row).eq(6).val(data.d[i].OC_NDESCAD);
                            $("td", row).eq(7).html(data.d[i].OC_NDSCPIT);
                            $("td", row).eq(7).val(data.d[i].OC_NDESCIT);
                            $("td", row).eq(8).html(data.d[i].OC_NIGVPOR);
                            var checkigv = data.d[i].OC_CIGVPOR == "S" ? "18" : "0";
                            $("td", row).eq(8).val(checkigv);
                            $("td", row).eq(9).html(data.d[i].OC_NISCPOR);
                            var formaedicion = $("#MainContent_ddlsuboc").val();;
                            $("td", row).eq(9).val(formaedicion);
                            $("td", row).eq(10).html(data.d[i].OC_NPREUNI.toFixed(4));
                            $("td", row).eq(11).html(data.d[i].OC_NDESCTO);
                            $("td", row).eq(11).val(data.d[i].OC_NDSCPOR);
                            $("td", row).eq(12).html(data.d[i].OC_NIGV);//total igv
                            $("td", row).eq(12).val(data.d[i].OC_NIGV);//total igv
                            var subt = data.d[i].OC_NPREUN2 * data.d[i].OC_NCANORD;
                            $("td", row).eq(13).html(subt.toFixed(2));//subtotal
                            $("td", row).eq(13).val(subt.toFixed(2));//subtotal
                            $("td", row).eq(14).html(data.d[i].OC_NCANTEN);
                            $("td", row).eq(14).val(data.d[i].OC_CSOLICI);//solicitante 
                            $("td", row).eq(15).html(data.d[i].OC_NCANSAL);
                            $("td", row).eq(15).val();//centrocosto
                            var fechacarga = data.d[i].OC_DFECENT == null ? "" : moment(data.d[i].OC_DFECENT).format("DD/MM/YYYY");
                            $("td", row).eq(16).html(fechacarga); 
                            $("td", row).eq(16).val(data.d[i].OC_NTOTUS);
                            gsumadolaresf = Number(data.d[i].OC_NTOTUS) + Number(gsumadolaresf);
                            $("td", row).eq(17).html(data.d[i].OC_COMENTA.substring(0,50));
                            $("td", row).eq(17).val(data.d[i].OC_NTOTMN);
                            gsumasolesf = Number(data.d[i].OC_NTOTMN) + Number(gsumasolesf);
                            $("td", row).eq(18).html(data.d[i].OC_NISC);
                            $("td", row).eq(18).val("B");
                            contaditem = Number(data.d[i].OC_CITEM);
                            contarndw = contarndw + 1;
                            if (data.d[i].OC_CCODIGO.trim() == 'R050010012009') { $(".verinfomtto", row).show(); } else { $(".verinfomtto", row).hide(); }
                            cc = 2;
                            $("[id*=gvordencompra]").append(row);
                            row = $("[id*=gvordencompra] tr:last-child").clone(true);

                        }
                        
                        
                        
                        var sub01 = recorregrid().sumasub; var des01 = recorregrid().sumadesc;
                        var igv01 = recorregrid().sumaigvv; var tot01 = recorregrid().sumatotall;

                        $("#MainContent_txttbrutof").val(sub01.toFixed(2));
                        $("#MainContent_txtdescf").val(des01.toFixed(2));
                        $("#MainContent_txtigvf").val(igv01.toFixed(2));
                        $("#MainContent_txtnetof").val(tot01.toFixed(2));

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

        function filtarListamtto() {
            
            var LDE = {};
            LDE.OC_CNUMORD = $("#MainContent_txtnumoc").val().trim();
           
            $.ajax({
                type: "POST",
                url: "OCnueva.aspx/ListarMovmtto",
                data: '{LDE: ' + JSON.stringify(LDE) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {

                    if (data.d.length > 0) {
                        var row = $("[id*=gvmantenimiento] tr:last-child").clone(true);
                        $("[id*=gvmantenimiento] tr").not($("[id*=gvmantenimiento] tr:first-child")).remove();

                        for (var i = 0; i < data.d.length; i++) {
                            if (data.d[i].OC_CCODIGO.substring(0,1)!= "R"){
                            $("td", row).eq(0).html(data.d[i].OC_CDESREF);
                            $("td", row).eq(1).html(data.d[i].OC_CUNIDAD);
                            $("td", row).eq(2).html(data.d[i].OC_NCANORD);
                            $("td", row).eq(3).html(data.d[i].OC_NPREUNI);
                            $("td", row).eq(4).html(data.d[i].OC_NPREUN2);
                            $("td", row).eq(5).html(data.d[i].OC_NIGV);
                            var subtt = Number(data.d[i].OC_NPREUN2) * Number(data.d[i].OC_NCANORD);
                            $("td", row).eq(6).html(subtt);
                            var total = subtt + Number(data.d[i].OC_NIGV);
                            $("td", row).eq(7).html(total);
                            var codsoll = Mostrarundato(data.d[i].OC_CSOLICI,'12').ee;
                            $("td", row).eq(8).html(codsoll);
                            var codcost = Mostrarundato(data.d[i].OC_CCENCOS, "10").ee;
                            $("td", row).eq(9).html(codcost);
                           
                            $("[id*=gvmantenimiento]").append(row);
                            row = $("[id*=gvmantenimiento] tr:last-child").clone(true);
                            }
                        }


                    } else {
                        var row = $("[id*=gvmantenimiento] tr:last-child").clone(true);
                        $("[id*=gvmantenimiento] tr").not($("[id*=gvmantenimiento] tr:first-child")).remove();

                        $("td", row).eq(0).html("");
                        $("td", row).eq(1).html("");
                        $("td", row).eq(2).html("");
                        $("td", row).eq(3).html("");
                        $("td", row).eq(4).html("");
                        $("td", row).eq(5).html("");
                        $("td", row).eq(6).html("");
                        $("td", row).eq(7).html("");
                        $("[id*=gvmantenimiento]").append(row);
                        alert("no se encontro registro");
                    }
                },
                error: function (response) {
                    if (response.length != 0)
                        alert(response);
                }
            });

        }

        function Insertarnumero() {
            var ee;
            var CNUMDOC = {};
            CNUMDOC.TN_CCODIGO = "OC";
            CNUMDOC.TN_CNUMSER = "0001";
            $.ajax({

                type: "POST",
                url: "OCnueva.aspx/insertarnumeracion",
                //data: '{CNUMDOC: ' + JSON.stringify(CNUMDOC) + '}',
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {

                    ee = data.d;
                },
                error: function (data) {
                    if (data.length != 0)
                        alert(data);
                }

            });
            return ee;
        }

        function Mostrarundato(codigocons, codigoe) {
            var codigowh = codigoe;
            var codigoconswh = codigocons;
            var ee = "";
            $.ajax({

                type: "POST",
                url: "OCnueva.aspx/Getdescycodigo",
                //data: '{CNUMDOC: ' + JSON.stringify(CNUMDOC) + '}',
                data: "{dato: '" + codigoconswh + "',codigo:'" + codigowh + "' }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.d !=null ){
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
            return { ee};
        }


        function Mostrarunproveedor(codigoproo) {
            var ee = "";
            $.ajax({

                type: "POST",
                url: "OCnueva.aspx/Getdescproveedor",
                //data: '{CNUMDOC: ' + JSON.stringify(CNUMDOC) + '}',
                data: "{textocod: '" + codigoproo+ "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.d != null) {
                        ee = data.d.ADESANE.trim();
                    } else {
                        ee = "";
                    }
                },
                error: function (data) {
                    if (data.length != 0)
                        alert(data);
                }

            });
            return { ee};
        }

        function MostrarTcambio() {
            var dato;
            var fec1 = moment($("#MainContent_txtfecha1").val(), "DD/MM/YYYY");
            fec1 = new Date(fec1);
           
            var TCAM = {};
            TCAM.XFECCAM2 = fec1;

            $.ajax({

                type: "POST",
                url: "OCnueva.aspx/extraetcambio",
                data: '{TCAM: ' + JSON.stringify(TCAM) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.d == null) {
                        dato = "";
                        alert("No se encuentra registrado tipo de cambio - Comunicarse con contabilidad");
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

        function MostrarDireccionAl() {
            var dato;
            var dato2;
            var CDIR = {};
            CDIR.A1_CALMA = $("#MainContent_ddlalma").val();

            $.ajax({

                type: "POST",
                url: "OCnueva.aspx/extraeDirAlma",
                data: '{CDIR: ' + JSON.stringify(CDIR) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.d == null) {
                        dato = "";
                        alert("No se encuentra Informacion");
                    } else {
                        dato = data.d.A1_CDIRECC;
                        dato2 = data.d.A1_CDISTRI;
                        dato3 = data.d.A1_CPROV;
                    }

                },
                error: function (data) {
                    if (data.length != 0)
                        alert(data);
                }

            });
            return {
                dato: dato,
                dato2: dato2,
                dato3: dato3
            };

        }

        function obetenerhora() {
            chora = new Date();
            chora = chora.getHours();
            cminu = new Date().getMinutes();
            chora = new String(chora);
            cminu = new String(cminu);
            var hor = chora + ":" + cminu;
            return hor;
        }

        function InsertarCabcera(wmetodocabecera) {

            var horao = obetenerhora();

            var fec1 = moment($("#MainContent_txtfecha1").val(), "DD/MM/YYYY");
            fec1 = fec1 == null ? null : new Date(fec1);
            var fec02 = moment($("#MainContent_txtfecha2").val(), "DD/MM/YYYY");
            fec02 = fec02 == null ? null : new Date(fec02);
            var dfactual = moment($("#MainContent_hffactual").val(), "DD/MM/YYYY");
            dfactual = dfactual == null ? null : new Date(dfactual);

            var fpagg = $("#MainContent_ddlfpago").val();
            fpagg = fpagg.substring(0, 30);

            var CABC = {};
            CABC.OC_CNUMORD = $("#MainContent_txtnumoc").val().trim();
            CABC.OC_CCODPRO = $("#MainContent_txtidpro").val().trim();
            CABC.OC_CRAZSOC = $("#MainContent_txtprove").val().trim();
            CABC.OC_CDIRPRO = $("#MainContent_txtdire").val().trim();
            CABC.OC_CCOTIZA = $("#MainContent_txtnumref").val().trim();
            CABC.OC_CCODMON = $("#MainContent_ddlmone").val().trim();
            CABC.OC_CFORPA1 = fpagg;
            CABC.OC_CFORPA2 = "";
            CABC.OC_CFORPA3 = "";
            CABC.OC_NTIPCAM = $("#MainContent_txttcambio").val().trim();
            CABC.OC_DFECENT = fec02;
            CABC.OC_NPORDES = 0;
            CABC.OC_CCARDES = "";
            CABC.OC_NIMPUS = 0;//importe dolares  
            CABC.OC_NIMPMN = 0;//importe soles  
            CABC.OC_CSOLICT = $("#MainContent_txtsoli").val().trim();
            CABC.OC_CTIPENV = $("#MainContent_txtenvio").val().trim();
            CABC.OC_CLUGENT = $("#MainContent_txtlentre").val().trim();
            CABC.OC_CLUGFAC = $("#MainContent_txtlugarf").val().trim();
            CABC.OC_CDETENT = $("#MainContent_txtobs").val();
            CABC.OC_CSITORD = "1";
            CABC.OC_DFECACT = dfactual;
            CABC.OC_CHORA = horao;
            CABC.OC_CUSUARI = $("#MainContent_hfusu").val().trim();
            CABC.OC_DFECDOC = fec1;
            CABC.OC_CTIPORD = $("#MainContent_ddltipo").val().trim();
            CABC.OC_CRESPER1 = "";
            CABC.OC_CRESPER2 = "";
            CABC.OC_CRESPER3 = "";
            CABC.OC_CRESCARG1 = "";
            CABC.OC_CRESCARG2 = "";
            CABC.OC_CRESCARG3 = "";
            CABC.OC_CCOPAIS = $("#MainContent_ddlpais").val().trim();
            CABC.OC_CUSEA01 = "";
            CABC.OC_CUSEA02 = "";
            CABC.OC_CUSEA03 = "";
            //CABC.OC_DFECR01= ;
            //CABC.OC_DFECR02= ;
            //CABC.OC_DFECR03= ;
            CABC.OC_CREMITE = $("#MainContent_txtremi").val().trim();
            CABC.OC_CPERATE = $("#MainContent_txtaten").val().trim();
            CABC.OC_CCONTA1 = "";
            CABC.OC_CCONTA2 = "";
            CABC.OC_CCONTA3 = "";
            CABC.OC_CNUMFAC = "";
            //CABC.OC_DFECEMB= ;
            CABC.OC_CUNIORD = "";
            CABC.OC_CCONVTA = "";
            CABC.OC_CCONEMB = "";
            CABC.OC_CCONDIC = $("#MainContent_ddlsuboc").val().trim();
            CABC.OC_CTIPENT = "";
            CABC.OC_CDIAENT = "";
            CABC.OC_NFLEINT = 0;
            CABC.OC_NDOCCHA = 0;
            CABC.OC_NFLETE = 0;
            CABC.OC_NSEGURO = 0;
            CABC.OC_NIMPFAC = 0;
            CABC.OC_NIMPFOB = 0;
            CABC.OC_NIMPCF = 0;
            CABC.OC_NIMPCIF = 0;
            CABC.OC_CNUMREF = $("#MainContent_txtref2").val().trim();
            CABC.OC_CTIPDSP = $("#MainContent_ddltdespa").val();
            CABC.OC_CTIPDOC = $("#MainContent_ddldocre").val().trim();
            CABC.OC_CALMDES = $("#MainContent_ddlalma").val().trim();
            CABC.OC_CDISTOC = $("#MainContent_txtdist").val().trim();
            CABC.OC_CPROVOC = $("#MainContent_txtprov").val().trim();
            CABC.OC_CCOSTOC = $("#MainContent_txtcodcos").val().trim();
            CABC.OC_CDOCPAG = "";
            //CABC.OC_DFECPAG= ;
            //CABC.OC_DFECVEN= ;
            CABC.OC_CESTPAG = "";
            CABC.OC_CMONPAG = "";
            CABC.OC_NIMPPAG = 0;
            CABC.OC_CGLOPAG = "";
            CABC.OC_CCODSOL = $("#MainContent_txtidsoli").val().trim();
            CABC.OC_CCODAGE = "";
            CABC.OC_CCODTAL = "";
            CABC.OC_CORDTRA = "";
            $.ajax({

                type: "POST",
                url: "OCnueva.aspx/"+wmetodocabecera,
                data: '{CABC: ' + JSON.stringify(CABC) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async:false,
                success: function (response) {
                    if ($("#MainContent_ddltipo").val() == "I" && sindatosimport==1) {
                        InsertarMovi();
                    }
                },
                error: function (response) {
                    if (response.length != 0)
                        console.table(response);
                }
            });

        }

        function MostrarunRegistro(nrodocumento) {

            var ndocr=nrodocumento;
            var INFO = {};
            INFO.OC_CNUMORD = ndocr;

            $.ajax({

                type: "POST",
                url: "OCnueva.aspx/Getcabecerae",
                data: '{INFO: ' + JSON.stringify(INFO) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.d == null) {
                        alert("No Se encuentra Registro");
                    } else {
                        $("#MainContent_txtnumoc").val(data.d.OC_CNUMORD);
                        $("#MainContent_txtidpro").val(data.d.OC_CCODPRO);
                        $("#MainContent_txtprove").val(data.d.OC_CRAZSOC);
                        $("#MainContent_txtdire").val(data.d.OC_CDIRPRO);
                        $("#MainContent_ddlfpago").val(data.d.OC_CFORPA1);
                        $("#MainContent_ddlmone").val(data.d.OC_CCODMON);
                        $("#MainContent_txttcambio").val(data.d.OC_NTIPCAM);
                        $("#MainContent_txtsoli").val(data.d.OC_CSOLICT);
                        $("#MainContent_txtenvio").val(data.d.OC_CTIPENV);
                        $("#MainContent_txtlentre").val(data.d.OC_CLUGENT);
                        $("#MainContent_txtlugarf").val(data.d.OC_CLUGFAC);
                        $("#MainContent_txtobs").val(data.d.OC_CDETENT);
                        $("#MainContent_txtfecha1").val(moment((data.d.OC_DFECDOC)).format("DD/MM/YYYY"));
                        $("#MainContent_txtfecha2").val(moment((data.d.OC_DFECENT)).format("DD/MM/YYYY"));
                        $("#MainContent_hfusu").val(data.d.OC_CUSUARI);
                        data.d.OC_CTIPORD == "I" ? $(".bttimp").show() : $(".bttimp").hide();
                        $("#MainContent_ddltipo").val(data.d.OC_CTIPORD);
                        $("#MainContent_ddlsuboc").val(data.d.OC_CCONDIC.trim());
                        $("#MainContent_ddlpais").val(data.d.OC_CCOPAIS);
                        $("#MainContent_txtremi").val(data.d.OC_CREMITE);
                        $("#MainContent_txtaten").val(data.d.OC_CPERATE);
                        $("#MainContent_txtref2").val(data.d.OC_CNUMREF);
                        $("#MainContent_ddldocre").val(data.d.OC_CTIPDOC);
                        $("#MainContent_txtnumref").val(data.d.OC_CCOTIZA);
                        $("#MainContent_ddlalma").val(data.d.OC_CALMDES);
                        $("#MainContent_txtdist").val(data.d.OC_CDISTOC);
                        $("#MainContent_txtprov").val(data.d.OC_CPROVOC);
                        $("#MainContent_txtcodcos").val(data.d.OC_CCOSTOC);
                        $("#MainContent_txtidsoli").val(data.d.OC_CCODSOL);

                        var textdev = Mostrarundato($("#MainContent_txtcodcos").val(), '10').ee;
                        if (textdev != "") {
                            $("#MainContent_ddlccost").val(textdev);
                        } else {
                            $("#MainContent_ddlccost").val("");
                        }

                        $("#dveditar").dialog('close');

                        
                        sw_nuevo = 1;
                        
                        MostrarImportacion();
                    }
                },
                error: function (data) {
                    if (data.length != 0)
                        alert(data);
                }
            });
        }

        function btnuevo() {

            if ($("#MainContent_ddlmone").val() == "-1") {
                alert("No Ha Seleccionado la Moneda");
                $("#MainContent_ddlmone").focus();
            } else if ($("#MainContent_txtidpro").val() == "") {
                alert("No Ha Seleccionado Proveedor");
                $("#MainContent_txtprove").focus();
            } else if ($("#MainContent_txttcambio").val() == "") {
                alert("No Ha Ingresado Tipo Cambio");
                $("#MainContent_txttcambio").focus();
            } else if ($("#MainContent_txtfecha1").val() == "") {
                alert("No Ha Ingresado Tipo Cambio");
                $("#MainContent_txtfecha1").focus();
            } else if ($("#MainContent_ddltipo").val() == "-1") {
                alert("No Ha Seleccionado el Tipo Orden");
                $("#MainContent_ddltipo").focus();
            } else if ($("#MainContent_ddlalma").val() == "-1") {
                alert("No Ha Seleccionado el Almacen");
                $("#MainContent_ddlalma").focus();
            } else if ($("#MainContent_ddlsuboc").val() == "-1" && $("#MainContent_ddltipo").val() == "S") {
                    alert("No Ha Seleccionado el Subtipo");
                    $("#MainContent_ddlsuboc").focus();
            } else {
                if (sw_nuevo == 0) {

                    var idc = Insertarnumero();
                    $("#MainContent_txtnumoc").val(idc);
                    sw_nuevo = 1;
                    actualizanumeracion();
                } else {
                    if (sw_plan != 0) {
                        $("#MainContent_ddlsuboc").val() == "2" ? $(".verinfomtto").show() : $(".verinfomtto").hide();
                        filtarListocompra();
                    }
                }
                $("#MainContent_txtoc").val($("#MainContent_txtnumoc").val());
                $("#MainContent_txtmostrarmn").val($("#MainContent_ddlmone option:selected").text());
            
                InsertarCabcera("InsertaCab");
                $("#MainContent_ddlsuboc").val() == "2" ? InsertarCabcera("InsertaCab_Anexo"): "";;
                
                Modicacabmontos($("#MainContent_txtnumoc").val(), gsumadolaresf.toFixed(3), gsumasolesf.toFixed(3));
                if (sw_plan == 0) {
                    inidw = 0;
                    limpiargrid();
                    $('#dvplanilla').dialog('open');
                    sw_plan = 1;
                } else {
                    $("#dvdetalle").dialog('open');
                    
                    sw_plan = 1;
                    
                }

                if ($("#MainContent_ddlsuboc").val() == "3") {

                    $("#MainContent_txtdcodsoli").val($("#MainContent_txtidsoli").val());
                    $("#MainContent_txtdsoli").val($("#MainContent_txtsoli").val());
                    $("#MainContent_txtdcodcost").val($("#MainContent_txtcodcos").val());
                    $("#MainContent_txtdccost").val($("#MainContent_ddlccost").val());
                    $("#MainContent_txtdfechat1").val($("#MainContent_txtfecha2").val());

                }
            }
        }

        function Modicacabmontos(nrodocumento,montodolar,montosoles) {

            var ndocr = nrodocumento;
            var mtsoles = montosoles;
            var mtdolares=montodolar ;
            var LDE = {};
            LDE.OC_CNUMORD = ndocr;
            LDE.OC_NIMPMN = montosoles;
            LDE.OC_NIMPUS = montodolar;
            
            $.ajax({

                type: "POST",
                url: "OCnueva.aspx/ModificaMontos",
                data: '{LDE: ' + JSON.stringify(LDE) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    
                },
                error: function (data) {
                    if (data.length != 0)
                        alert(data);
                }
            });
        }

        function Eliminaciondet() {
            var ELIM = {};
            ELIM.OC_CNUMORD = $("#MainContent_txtoc").val();
            ELIM.OC_CITEM = ITEM_COD;

            $.ajax({

                type: "POST",
                url: "OCnueva.aspx/Eliminadetalle",
                data: '{ELIM: ' + JSON.stringify(ELIM) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    alert("Item eliminado");

                },
                error: function (data) {
                    if (data.length != 0)
                        alert(data);
                }
            });
        }


        function EliminaciondetOT(idnumoc) {
            var ELIM = {};
            ELIM.OC_CNUMORD = idnumoc;

            $.ajax({

                type: "POST",
                url: "OCnueva.aspx/eliminadetalleOT",
                data: '{ELIM: ' + JSON.stringify(ELIM) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {

                },
                error: function (data) {
                    if (data.length != 0)
                        alert(data);
                }
            });
        }

        function Eliminaciondetplanilla() {
            var ELIM = {};
            ELIM.BK_NORD = $("#MainContent_txtoc").val().trim();
            ELIM.BK_CITEM = ITEM_COD.trim();
            ELIM.BK_CODIG = CCOD.trim();
            $.ajax({

                type: "POST",
                url: "OCnueva.aspx/Eliminadetalleplanilla",
                data: '{ELIM: ' + JSON.stringify(ELIM) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                   
                },
                error: function (data) {
                    if (data.length != 0)
                        alert(data);
                }
            });
        }


        function guardarimporttmp() {

            guardartmp = [];
            guardartmp[0] = $("#MainContent_txtinom").val();
            guardartmp[1] = $("#MainContent_txtidir").val();
            guardartmp[2] = $("#MainContent_ddlipais").val();
            guardartmp[3] = $("#MainContent_txtitel").val();
            guardartmp[4] = $("#MainContent_txtifax").val();
            guardartmp[5] = $("#MainContent_txtiatt").val();
            guardartmp[6] = $("#MainContent_txtinom2").val();
            guardartmp[7] = $("#MainContent_txtidir2").val();
            guardartmp[8] = $("#MainContent_ddlipais2").val();
            guardartmp[9] = $("#MainContent_txtitel2").val();
            guardartmp[10] = $("#MainContent_txtifax2").val();
            guardartmp[11] = $("#MainContent_txtiatt2").val();
            $("#dvimportacion").dialog('close');
            
        }
        
        function InsertarMovi() {


            var DETA = {};
            DETA.OC_CNUMORD=$("#MainContent_txtnumoc").val().trim();
            DETA.OC_CCODPRO = $("#MainContent_txtidpro").val().trim();
            DETA.OC_CSTNOMC=guardartmp[0];
            DETA.OC_CSTPAIS=guardartmp[2];
            DETA.OC_CSTDIRC=guardartmp[1];
            DETA.OC_CSTTELC=guardartmp[3];
            DETA.OC_CSTFAXC=guardartmp[4];
            DETA.OC_CSTPERA=guardartmp[5];
            DETA.OC_CCTNOMC=guardartmp[6];
            DETA.OC_CCTPAIS=guardartmp[8];
            DETA.OC_CCTDIRC=guardartmp[7];
            DETA.OC_CCTTELC=guardartmp[9];
            DETA.OC_CCTFAXC=guardartmp[10];
            DETA.OC_CCTPERA = guardartmp[11];

            $.ajax({

                type: "POST",
                url: "OCnueva.aspx/InsertarMOvi",
                data: '{DETA: ' + JSON.stringify(DETA) + '}',
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


        function actualizanumeracion() {
            var extraenum=$("#MainContent_txtnumoc").val().trim();
            var datos = {};
            datos.TN_CCODIGO = "OC";
            datos.TN_CNUMSER = "0001";
            datos.TN_NNUMERO = Number(extraenum.substring(5,11)) ;
            $.ajax({

                type: "POST",
                url: "OCnueva.aspx/Actualizanum",
                data: '{datos: ' + JSON.stringify(datos) + '}',
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

        function MostrarImportacion() {

            var DETA = {};

            DETA.OC_CNUMORD = $("#MainContent_txtnumoc").val().trim();
            DETA.OC_CCODPRO = $("#MainContent_txtidpro").val().trim();
           
            $.ajax({

                type: "POST",
                url: "OCnueva.aspx/Mostrarimportacion",
                data: '{DETA: ' + JSON.stringify(DETA) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {

                    if (data.d!=null){
                                                
                        $("#MainContent_txtinom").val(data.d.OC_CSTNOMC);
                        $("#MainContent_txtidir").val(data.d.OC_CSTDIRC);
                        $("#MainContent_ddlipais").val(data.d.OC_CSTPAIS);
                        $("#MainContent_txtitel").val(data.d.OC_CSTTELC);
                        $("#MainContent_txtifax").val(data.d.OC_CSTFAXC);
                        $("#MainContent_txtiatt").val(data.d.OC_CSTPERA);
                        $("#MainContent_txtinom2").val(data.d.OC_CCTNOMC);
                        $("#MainContent_txtidir2").val(data.d.OC_CCTDIRC);
                        $("#MainContent_ddlipais2").val(data.d.OC_CCTPAIS);
                        $("#MainContent_txtitel2").val(data.d.OC_CCTTELC);
                        $("#MainContent_txtifax2").val(data.d.OC_CCTFAXC);
                        $("#MainContent_txtiatt2").val(data.d.OC_CCTPERA);

                        guardartmp[0] = data.d.OC_CSTNOMC;
                        guardartmp[2] = data.d.OC_CSTPAIS;
                        guardartmp[1] = data.d.OC_CSTDIRC;
                        guardartmp[3] = data.d.OC_CSTTELC;
                        guardartmp[4] = data.d.OC_CSTFAXC;
                        guardartmp[5] = data.d.OC_CSTPERA;
                        guardartmp[6] = data.d.OC_CCTNOMC;
                        guardartmp[8] = data.d.OC_CCTPAIS;
                        guardartmp[7] = data.d.OC_CCTDIRC;
                        guardartmp[9] = data.d.OC_CCTTELC;
                        guardartmp[10] = data.d.OC_CCTFAXC;
                        guardartmp[11] = data.d.OC_CCTPERA;
                        sindatosimport = 1;
                    } else {
                        $("#MainContent_txtinom").val("");
                        $("#MainContent_txtidir").val("");
                        //$("#MainContent_ddlipais option:selected").text();
                        $("#MainContent_txtitel").val("");
                        $("#MainContent_txtifax").val("");
                        $("#MainContent_txtiatt").val("");
                        $("#MainContent_txtinom2").val("");
                        $("#MainContent_txtidir2").val("");
                        //$("#MainContent_ddlipais2 option:selected").text();
                        $("#MainContent_txtitel2").val("");
                        $("#MainContent_txtifax2").val("");
                        $("#MainContent_txtiatt2").val("");
                        sindatosimport = 0;
                    }
                },
                error: function (response) {
                    if (response.length != 0)
                        console.table(response);
                }
            });

        }
        
        function consultaservice(codserv) {
            var tbserv = {};
            var noms="";
            tbserv.codtra = codserv;

            $.ajax({

                type: "POST",
                url: "OCnueva.aspx/Getservxcodigo",
                data: '{tbserv: ' + JSON.stringify(tbserv) + ',area:'+$("#MainContent_ddlparea").val()+'}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {

                    if (data.d != null) {
                        noms = data.d.descripcion;
                    } else {
                        noms = "";
                    }
                },
                error: function (response) {
                    if (response.length != 0)
                        console.table(response);
                }
            });
            return{noms}
        }

        function filtarPlanillas() {
            var fec1 = moment($("#MainContent_txtfinis").val(), "DD/MM/YYYY");
            fec1 = new Date(fec1);
            var fec2 = moment($("#MainContent_txtffins").val(), "DD/MM/YYYY");
            fec2 = new Date(fec2);
            
            var T_Planilla = {};
            T_Planilla.responsable = $("#MainContent_txtcods").val();
            T_Planilla.fecha = fec1;
            T_Planilla.FecProduc = fec2;
            $.ajax({

                type: "POST",
                url: "OCnueva.aspx/GetlistaPlanilla",
                data: '{T_Planilla: ' + JSON.stringify(T_Planilla) + ',area:' + $("#MainContent_ddlparea").val() + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    
                   

                    if (data.d.length > 0) {
                        guardanomserv[cont_arrayb] = $("#MainContent_txtcods").val() + $("#MainContent_txtfinis").val() + $("#MainContent_txtffins").val();
                        cont_arrayb = Number(cont_arrayb) + 1;

                        var row = $("[id*=gvplan] tr:last-child").clone(true);
                        if (inidw==0){
                            $("[id*=gvplan] tr").not($("[id*=gvplan] tr:first-child")).remove();
                            inidw = 1;
                            contaditemplan = 0;
                        }

                        for (var i = 0; i < data.d.length; i++) {
                            contaditemplan = contaditemplan + 1;
                            var nitem = ("000" + contaditemplan).slice(-4);

                            $("td", row).eq(0).html(data.d[i].PL_fecha);
                            $("td", row).eq(0).val(data.d[i].PL_codsofcom);
                            $("td", row).eq(1).html(data.d[i].PL_codigo);
                            $("td", row).eq(1).val(data.d[i].PL_coddetpla);
                            $("td", row).eq(2).html(data.d[i].PL_servis);
                            $("td", row).eq(2).val(data.d[i].PL_codplanilla);
                            $("td", row).eq(3).html(data.d[i].PL_planilla);
                            $("td", row).eq(4).html(data.d[i].PL_especie);
                            $("td", row).eq(5).html(data.d[i].PL_presentacion);
                            $("td", row).eq(6).html(data.d[i].PL_tarea);
                            $("td", row).eq(7).html(data.d[i].PL_cantidad);
                           
                            
                            if (data.d[i].PL_codsofcom == "" || data.d[i].PL_codsofcom == null) {
                                $("td", row).eq(6).css("color", "red");
                                $('td:eq(12) :checkbox', row).attr("disabled",true);

                            } else {
                                $("td", row).eq(6).css("color", "black");
                                $('td:eq(12) :checkbox', row).attr("disabled", false);
                            }

                            var preciofinalmasigv = data.d[i].PL_tarifa * 1.18;
                            var totalall = (preciofinalmasigv) * data.d[i].PL_cantidad;
                            totalpla = Number(totalpla) + Number(data.d[i].PL_total.toFixed(2));
                            $("td", row).eq(8).html(data.d[i].PL_tarifa);
                            $("td", row).eq(8).val(preciofinalmasigv);
                            var monto_usplan = calculo_MNUS(totalall).montous;
                            var monto_mnplan = calculo_MNUS(totalall).montomn;
                            //alert(monto_mnplan + "US:" + monto_usplan);
                            $("td", row).eq(9).html(data.d[i].PL_total.toFixed(2));
                            $("td", row).eq(9).val(monto_mnplan);
                            $("td", row).eq(10).html(data.d[i].PL_turno);
                            $("td", row).eq(10).val(monto_usplan);
                            $("td", row).eq(11).html(data.d[i].PL_guia);

                            $("[id*=gvplan]").append(row);
                            row = $("[id*=gvplan] tr:last-child").clone(true);

                        }
                        $("#MainContent_txttotaplani").val(totalpla.toFixed(2));
                    } else {
                        //$("[id*=gvplan]").append(row);
                        alert("no se encontro registros");
                    }
                   

                },
                error: function (response) {
                    if (response.length != 0)
                        alert(response);
                }
            });

        }

        function limpiargrid() {
            var row = $("[id*=gvplan] tr:last-child").clone(true);
            $("[id*=gvplan] tr").not($("[id*=gvplan] tr:first-child")).remove();
            $("td", row).eq(0).html(""); $("td", row).eq(0).val("");
            $("td", row).eq(1).html(""); $("td", row).eq(2).html("");
            $("td", row).eq(3).html(""); $("td", row).eq(4).html("");
            $("td", row).eq(5).html(""); $("td", row).eq(6).html("");
            $("td", row).eq(7).html(""); $("td", row).eq(8).html("");
            $("td", row).eq(9).html(""); $("td", row).eq(10).html("");
            inidw = 0;
            contaditemplan = 0;
            $("[id*=gvplan]").append(row);
            row = $("[id*=gvplan] tr:last-child").clone(true);
        }

        function InsertarDetalleordenplan() {

            var DETA = {};

            DETA.BK_NORD = $("#MainContent_txtnumoc").val().trim();
            DETA.BK_CODIG = gidcod;
            DETA.BK_PLANI = bknumplan;
            DETA.BK_DESC = bkdescri1 + " " + bkdescri2 + " " + bkdescri3;
            DETA.BK_CANT = gcant;
            DETA.BK_TARIF = gprecinicial;
            DETA.BK_TOTA = bktotal;
            DETA.BK_CODPLAN = bkcodprodplan;
            DETA.BK_CITEM = gitem;
            DETA.BK_AREA = $("#MainContent_ddlparea").val();
            DETA.BK_GUIA = bk_nguia;
            $.ajax({

                type: "POST",
                url: "OCnueva.aspx/Insertaplanord",
                data: '{DETA: ' + JSON.stringify(DETA) + '}',
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

    </script>

    <style type="text/css">
        /*.auto-style1 {
            width: 132px;
        }

        fieldset {
            padding: 10px;
            border: 1px solid black;
            border-radius: 5px;
            background-color: white;
            margin:0 auto;
            width: 900px;
        }

        legend {
            padding: 5px;
            font-size: 15px;
            border-radius: 10px;
            background-color: white;
        }*/
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
    <%--<div id="aa">--%> 
        <div id="contenedor">
        <fieldset>
            <legend>MANTENIMIENTO DE ORDENES </legend>

            <table>
                <tr>
                    <td>Orden Compra:
                    </td>
                    <td colspan="3">

                        <asp:TextBox ID="txtnumoc" runat="server" Width="100" Enabled="false" class="txtmost"></asp:TextBox>

                    </td>
                    <td>Fecha</td>
                    <td>
                        <asp:TextBox ID="txtfecha1" TabIndex="1" class="tcamb" runat="server" Width="130" placeholder="00/00/0000" onkeydown ="ModifyEnterKeyPressAsTab(event,this);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Proveedor:</td>
                    <td colspan="3">
                        <asp:TextBox ID="txtprove" TabIndex="2"  runat="server" Width="300" onkeydown="ModifyEnterKeyPressAsTab(event,this);"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtidpro" Enabled="true" runat="server" Width="100" placeholder="RUC" ></asp:TextBox>
                    </td>
                    <td>Fax:<asp:TextBox runat="server" ID="txtfax" Width="102px" Height="18px" Enabled="false"></asp:TextBox>
                    </td>


                </tr>
                <tr>
                    <td>direccion</td>
                    <td colspan="3">

                        <asp:TextBox ID="txtdire" runat="server" Width="300" Enabled="False" ></asp:TextBox>

                    </td>
                    <td>Tipo Despacho</td>
                    <td>
                        <asp:DropDownList ID="ddltdespa" runat="server" Width="130"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Doc Referencia:</td>
                    <td class="auto-style1">
                        <asp:DropDownList ID="ddldocre" TabIndex="3"  runat="server" Width="130" onkeydown ="ModifyEnterKeyPressAsTab(event,this);"></asp:DropDownList>
                    </td>
                    <td>

                        <asp:TextBox ID="txtnumref" runat="server" TabIndex="4" Width="161px" onkeydown="ModifyEnterKeyPressAsTab(event,this);"></asp:TextBox>

                    </td>
                    <td></td>
                    <td>N° Doc Ref.02</td>
                    <td>

                        <asp:TextBox ID="txtref2" runat="server" Width="130"  TabIndex="5"  onkeydown="ModifyEnterKeyPressAsTab(event,this);"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td>Moneda:</td>
                    <td class="auto-style1">
                        <asp:DropDownList ID="ddlmone" runat="server"  TabIndex="6"  Width="130" onkeydown="ModifyEnterKeyPressAsTab(event,this);"></asp:DropDownList>
                    </td>
                    <td></td>
                    <td></td>

                    <td>Tipo O/C:</td>
                    <td>
                        <asp:DropDownList ID="ddltipo" runat="server" TabIndex="7"  onkeydown="ModifyEnterKeyPressAsTab(event,this);" Width="130"></asp:DropDownList>
                    </td>
                   <td>
                <input class="bttimp" value="Importacion" type="button" style="width:85px; height: 22px;" />
                         </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td><td></td>
                        <td></td>
                        <td>Sub-Tipo</td>
                     <td>
                        <asp:DropDownList ID="ddlsuboc" runat="server" TabIndex="8" onkeydown="ModifyEnterKeyPressAsTab(event,this);" Width="130"></asp:DropDownList>
                    </td>
                    <td>
                          <input class="btplan" value="Planilla" type="button" style="width:85px; height: 22px;" />
            </td>
                </tr>
                <tr>
                    <td>Forma Pago:</td>
                    <td colspan="3">
                        
                        <%--<asp:DropDownList runat="server" ID="ddlfpago" Width="300" > </asp:DropDownList>--%>
                    <asp:TextBox ID="ddlfpago" runat="server" Width="300"  TabIndex="9"  MaxLength="30"  onkeydown="ModifyEnterKeyPressAsTab(event,this);"></asp:TextBox>
                    </td>

                    <td>Tipo Cambio</td>
                    <td>
                        <asp:TextBox ID="txttcambio" runat="server" Width="130"  TabIndex="10" onkeydown="ModifyEnterKeyPressAsTab(event,this);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Fecha Entrega:</td>
                    <td>
                        <asp:TextBox ID="txtfecha2" runat="server" Width="130" TabIndex="11"  placeholder="00/00/0000" onkeydown="ModifyEnterKeyPressAsTab(event,this);"></asp:TextBox>
                    </td>

                    <td colspan="2">Dscto Fina.
                 <asp:TextBox ID="txtdfina" runat="server" Width="88px"  TabIndex="12"  onkeydown="ModifyEnterKeyPressAsTab(event,this);"></asp:TextBox>
                    </td>
                    <td>Pais
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlpais" Width="130" TabIndex="13"  onkeydown="ModifyEnterKeyPressAsTab(event,this);"></asp:DropDownList>
                    </td>
                </tr>

            </table>
            <hr />
            <table>
                <tr>
                    <td>Solicitante:</td>
                    <td colspan="6">
                        <asp:TextBox ID="txtidsoli" class="ctxtidsoli" runat="server" Width="100" placeholder="CODIGO"></asp:TextBox>


                        <asp:TextBox ID="txtsoli" runat="server" Width="300" placeholder="SOLICITANTE" TabIndex="14"  onkeydown="ModifyEnterKeyPressAsTab(event,this);"></asp:TextBox>

                    </td>

                </tr>
                <tr>
                    <td>Centro Costo:</td>
                    <td colspan="6">
                        <asp:TextBox runat="server" ID="txtcodcos" Width="100" placeholder="CODIGO"  TabIndex="15"   ></asp:TextBox>

                        <asp:TextBox runat="server" ID="ddlccost" Width="300" placeholder="DESCRIPCION" TabIndex="16"  onkeydown="ModifyEnterKeyPressAsTab(event,this);"></asp:TextBox>
                    </td>


                </tr>
                <tr>
                    <td>Tipo Envio </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtenvio" runat="server" Width="300"   TabIndex="17"  onkeydown="ModifyEnterKeyPressAsTab(event,this);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Almacen:</td>
                    <td colspan="2">

                        <asp:DropDownList ID="ddlalma" class="selalma" runat="server" Width="300" TabIndex="18"  onkeydown="ModifyEnterKeyPressAsTab(event,this);"></asp:DropDownList>

                    </td>
                </tr>
                <tr>
                    <td>Lugar Entrega:</td>
                    <td colspan="2">
                        <asp:TextBox ID="txtlentre" runat="server" Width="300"  TabIndex="19"  onkeydown="ModifyEnterKeyPressAsTab(event,this);"></asp:TextBox>
                    </td>
                    <td>Distri.:</td>
                    <td>
                        <asp:TextBox ID="txtdist" runat="server" Width="100" Enabled="False"></asp:TextBox>
                    </td>
                    <td>Provinc:</td>
                    <td>
                        <asp:TextBox ID="txtprov" runat="server" Width="100" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Lugar Factura </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtlugarf" runat="server" Width="300"  TabIndex="20"  onkeydown="ModifyEnterKeyPressAsTab(event,this);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Observaciones :</td>
                    <td colspan="6">
                        <asp:TextBox TextMode="MultiLine" Rows="2" runat="server" ID="txtobs" Width="595" MaxLength="80" TabIndex="21"  onkeydown="ModifyEnterKeyPressAsTab(event,this);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Remite:</td>
                    <td colspan="1">
                        <asp:TextBox ID="txtremi" runat="server" Width="180"  TabIndex="22"  onkeydown="ModifyEnterKeyPressAsTab(event,this);"></asp:TextBox>
                    </td>
                    <td>Persona Atencion:</td>
                    <td colspan="4">
                        <asp:TextBox ID="txtaten" runat="server" Width="180"  TabIndex="23"  onkeydown="ModifyEnterKeyPressAsTab(event,this);"></asp:TextBox>
                    </td>
                </tr>

            </table>
            <table>
                <tr>
                    <td>
                        <input class="btadd btn" value="Agregar Detalle" type="button" style="width: 120px; height: 35px; border-radius: 5px" />
                    </td>
                     <td>
                <input class="imprime btn" value="Imprimir" type="button" style="width:120px;height:35px;border-radius:5px" />
                </td>
                </tr>
            </table>
        </fieldset>
    </div>
    <div id="dvdetalle"  style="display:none"> 
        <%-- <fieldset style="background-color: #99CCFF"> --%>
        <table style="text-align:left">
            <tr>
                <td>Orden Compra:</td>
                <td>
                    <asp:TextBox ID="txtoc" runat="server" Width="130" Enabled="false"></asp:TextBox>
                </td>
                <td>Moneda</td>
                <td>
                    <asp:TextBox ID="txtmostrarmn" runat="server" Width="130" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <%--  <tr>
           <td>Proveedor:</td>
                <td>
                    <asp:TextBox ID="txtdidprove" runat="server" Width="130"  Enabled="false"></asp:TextBox>
                </td>
                <td colspan="4">
                    <asp:TextBox ID="txtdprove" runat="server" Width="380"  Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>N° Cotizacion:</td>
                <td>
                    <asp:TextBox ID="txtdncot" runat="server" Width="130" Enabled="false"></asp:TextBox>
                </td>
                <td>Fecha Registro:</td>
                <td>
                    <asp:TextBox ID="txtdfechar" runat="server" Width="80"  Enabled="false"></asp:TextBox>
                </td>
               <td>Fecha Entrega:</td>
                <td>
                    <asp:TextBox ID="txtdfechae" runat="server" Width="80" Enabled="false"></asp:TextBox>
                </td>
            </tr>
                        <tr>
                <td>Tipo Moneda:</td>
                <td>
                    <asp:TextBox ID="txtdmone" runat="server" Width="80" Enabled="false"></asp:TextBox>
                </td>
                            <td>Tipo Cambio:</td>
                <td>
                    <asp:TextBox ID="txtdtcambio" runat="server" Width="80" Enabled="false"></asp:TextBox>
                </td>
                            <td>Descuento finan.:</td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Width="80" Enabled="false"></asp:TextBox>
                </td>
            </tr>--%>
        </table>
        <%-- </fieldset>--%>
        <fieldset style="float:left">
            <table >
                <tr>
                    <td>Buscar Por</td>
                    <td>
                        <asp:RadioButtonList runat="server"  RepeatDirection="Horizontal" ID="chtipolinea">
                            <asp:ListItem Value="R" Text="Servicio" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="N" Text="Materiales"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    </tr>
                <tr>
                    <td>Descripcion:</td>
                    <td colspan="5">
                        <asp:TextBox ID="txtdarticulo" runat="server" Width="300" class="idart"  TabIndex="24"  onkeydown="ModifyEnterKeyPressAsTab(event,this);"></asp:TextBox>
                        <asp:TextBox ID="txtdcodati" runat="server" Width="120" Enabled="false" class="clidproducto"></asp:TextBox> 
                        <asp:TextBox ID="txtdumed" runat="server" Width="50" Enabled="False"></asp:TextBox>
                        
                    </td><td><asp:HiddenField runat="server" ID="hfaprobdesa"/></td>
                </tr>


                <tr>
                    <td>Cantidad Pedida</td>
                    <td>
                        <asp:TextBox ID="txtdcant" runat="server" Width="100"  TabIndex="25"  onkeydown="ModifyEnterKeyPressAsTab(event,this);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Precio</td>
                    <td>
                        <asp:TextBox ID="txtdprec" runat="server" Width="100" TabIndex="26"  onkeydown="ModifyEnterKeyPressAsTab(event,this);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>solicitante:</td>
                    <td colspan="5">
                        <asp:TextBox ID="txtdcodsoli" runat="server" TabIndex="27"  Width="100" placeholder="CODIGO"></asp:TextBox>
                        <asp:TextBox ID="txtdsoli" runat="server" Width="300" class="soli2" placeholder="SOLICITANTE" TabIndex="28"  onkeydown="ModifyEnterKeyPressAsTab(event,this);"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td>Centro Costo:</td>
                    <td colspan="5">
                        <asp:TextBox ID="txtdcodcost" runat="server" Width="100" TabIndex="30"  placeholder="CODIGO" ></asp:TextBox>
                        <asp:TextBox ID="txtdccost" runat="server" Width="300" class="ccost2"  placeholder="DESCRIPCION" TabIndex="30"  onkeydown="ModifyEnterKeyPressAsTab(event,this);"></asp:TextBox>

                    </td>

                </tr>
            </table>
        </fieldset>
        <fieldset style="float:left">
            <table>
                <tr>
                    <td>Dscto Finan</td>
                    <td>
                        <asp:TextBox ID="txtddescf" runat="server" Width="100" Enabled="false">0</asp:TextBox>
                        %</td>

                    <td>Dscto Item</td>
                    <td>
                        <asp:TextBox ID="txtddesci" runat="server" Width="100"  TabIndex="31"  onkeydown="ModifyEnterKeyPressAsTab(event,this);" placeholder="0">0</asp:TextBox>
                        %</td>

                    <td>Dscto Adicional</td>
                    <td>
                        <asp:TextBox ID="txtddesca" runat="server" Width="100" TabIndex="32" placeholder="0">0</asp:TextBox>
                        %</td>
                </tr>
            </table>
        </fieldset>
        <fieldset style="float:left">
            <table>

                <tr>
                    <td>
                        <asp:CheckBox runat="server" Text="Incluye IGV" class="chigv" ID="chkigv" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtdigv" runat="server" Width="100" Enabled="false"  TabIndex="33"  onkeydown="ModifyEnterKeyPressAsTab(event,this);"></asp:TextBox>
                        %</td>
                </tr>
                <tr>
                    <td>Incluye ISC</td>
                    <td>
                        <asp:TextBox ID="txtdisc" runat="server" Width="100" TabIndex="34"  onkeydown="ModifyEnterKeyPressAsTab(event,this);">0</asp:TextBox>
                        %</td>
                </tr>
                <tr>
                    <td>Fecha Entrega</td>
                    <td>
                        <asp:TextBox ID="txtdfechat1" runat="server" Width="100" placeholder="00/00/0000"  TabIndex="35"  onkeydown="ModifyEnterKeyPressAsTab(event,this);"></asp:TextBox>
                    </td>
                    <%--<td>
                    <asp:TextBox ID="txtresultado" runat="server" Width="100"></asp:TextBox>
                    </td>
                 <td>
                    <asp:TextBox ID="txtsub" runat="server" Width="100" placeholder="SUBTOTAL"></asp:TextBox>
                    </td>
                 <td>
                     <td>
                    <asp:TextBox ID="txtdescuentoc" runat="server" Width="100" placeholder="DESCUENTO"></asp:TextBox> 
                    </td>
                  <td>
                    <asp:TextBox ID="txttotigv" runat="server" Width="100" placeholder="TOTAL IGV"></asp:TextBox> 
                    </td>--%>
                </tr>
                <tr>
                    <td>Comentario</td>
                    <td colspan="5">
                        <asp:TextBox TextMode="MultiLine" Rows="2" runat="server" ID="txtdcomen" Width="395"  TabIndex="36"  onkeydown="ModifyEnterKeyPressAsTab(event,this);"></asp:TextBox>
                    </td>
                    <td>
                        <input runat="server" type="button" class="btaddd btn" value="Agregar"  TabIndex="37" style="width: 115px; height: 30px; border-radius: 5px" />
                    </td>
                 
                </tr>
            </table>
        </fieldset>


        <table>
            <tr>
                <td colspan="3">
                    <asp:GridView ID="gvordencompra" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" Width="1234px" Font-Size="Smaller">
                        <Columns>
                            <asp:BoundField DataField="OC_CITEM" HeaderText="Item">
                                <ItemStyle Width="8px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="OC_CCODIGO" HeaderText="Codigo">
                                <ItemStyle Width="20px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="OC_CCODREF" HeaderText="Descripcion">
                                <ItemStyle Width="200px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="OC_CUNIDAD" HeaderText="Unid">
                                <ItemStyle Width="8px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="OC_NCANORD" HeaderText="Cant">
                                <ItemStyle Width="8px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="OC_NPREUN2" HeaderText="Precio">
                                <ItemStyle Width="8px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="OC_NDSCPAD" HeaderText="Dto Ad">
                                <ItemStyle Width="5px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="OC_NDSCPIT" HeaderText="Dto IT">
                                <ItemStyle Width="5px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="OC_NIGVPOR" HeaderText="Igv">
                                <ItemStyle Width="8px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="OC_NISCPOR" HeaderText="Isc">
                                <ItemStyle Width="8px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="OC_NPREUNI" HeaderText="Precio Final">
                                <ItemStyle Width="6px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="OC_NDESCTO" HeaderText="T.Dscto">
                                <ItemStyle Width="5px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="OC_NIGV" HeaderText="Total Igv">
                                <ItemStyle Width="8px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="SUBTOTAL" HeaderText="Subtotal">
                                <ItemStyle Width="8px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="OC_NCANTEN" HeaderText="Cant Rec.">
                                <ItemStyle Width="5px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="OC_NCANSAL" HeaderText="CantxRec">
                                <ItemStyle Width="8px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="OC_DFECENT" HeaderText="F Entrega">
                                <ItemStyle Width="8px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="OC_COMENTA" HeaderText="Observacion">
                                <ItemStyle Width="8px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="OC_NISC" HeaderText="T.ISC">
                                <ItemStyle Width="8px"></ItemStyle>
                            </asp:BoundField>

                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <div class="btelimina" style="text-align: center">
                                        <img alt="" src="../Images/Message_Error.png" width="25" style="cursor: pointer" />
                                        <%--<asp:ImageButton ID="ib_editar" runat="server" ImageUrl="~/Images/Message_Error.png" Width="25px" OnClick="ib_editar_Click"  />--%>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <div class="btedita" style="text-align: center">
                                        <img alt="" src="../Images/EDIT.png" width="25" style="cursor: pointer" />
                                        <%--<asp:ImageButton ID="imbeliminar" runat="server" ImageUrl="~/Images/Message_Error.png" Width="25px" OnClick="ib_eliminar_Click" onclientclick="javascript:return confirm('Esta Seguro?')"/>--%>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>

                               <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <div class="verinfomtto" style="text-align: center">
                                        <img alt="" src="../Images/Detalle.png" width="25" style="cursor: pointer" />
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
        <table>
            <tr>
                <td>Total Bruto:</td>
                <td>
                    <asp:TextBox runat="server" Width="150" ID="txttbrutof" Enabled="false" Style="text-align: right"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Total Dcto:</td>
                <td>
                    <asp:TextBox runat="server" Width="150" ID="txtdescf" Enabled="false" Style="text-align: right"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>IGV:</td>
                <td>
                    <asp:TextBox runat="server" Width="150" ID="txtigvf" Enabled="false" Style="text-align: right"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Neto a Pagar:</td>
                <td>
                    <asp:TextBox runat="server" Width="150" ID="txtnetof" Enabled="false" Style="text-align: right"></asp:TextBox>
                </td>
            </tr>
        </table>
        
    </div>
    <div id="dvdetallemtto" style="display:none">
        <table>
            <tr>
             <%--   <td>Num Orden:
                    <asp:TextBox runat="server" Width="100" Enabled="false" ID="txtmtnorden"></asp:TextBox>
                </td>--%>
            </tr>
          <tr>
              <td colspan="3">
                  <asp:GridView ID="gvmantenimiento" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"  AutoGenerateColumns="False" Width="751px">
                                     <Columns>
                                         <asp:BoundField DataField="OC_CDESREF" HeaderText="Producto" ItemStyle-Width="190" />
                                         <asp:BoundField DataField="OC_CUNIDAD" HeaderText="Und"  />
                                         <asp:BoundField DataField="OC_NCANORD" HeaderText="Cant." ItemStyle-HorizontalAlign="Right" />
                                         <asp:BoundField DataField="OC_NPREUNI" HeaderText="Precio Orig"  ItemStyle-HorizontalAlign="Right"  HeaderStyle-Width="20"/>
                                         <asp:BoundField DataField="OC_NPREUN2" HeaderText="Precio Fin" ItemStyle-HorizontalAlign="Right"  ItemStyle-Width="20" HeaderStyle-Width="20"/>
                                         <asp:BoundField DataField="OC_NIGV" HeaderText="IGV" ItemStyle-HorizontalAlign="Right" />
                                         <asp:BoundField DataField="OC_SUBTOTAL" HeaderText="Sub Total" ItemStyle-HorizontalAlign="Right"   HeaderStyle-Width="20"/>
                                         <asp:BoundField DataField="OC_TOTAL" HeaderText="Total" ItemStyle-HorizontalAlign="Right" />
                                         <asp:BoundField DataField="OC_CSOLICI" HeaderText="Solicitante" ItemStyle-Width="100"/>
                                         <asp:BoundField DataField="OC_CCENCOS" HeaderText="Centro Costo" />
                                         
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

    <div id="dveditar"  style="display:none">
        <table>
            <tr>
                <td>Numero Orden</td>
                <td>
                    <asp:TextBox runat="server" ID="txtenorden" Width="150"></asp:TextBox>
                </td>
                <td>
                    <input type="button" class="btmostrar" value="Modificar" style="width: 100px; height: 25px" />
                </td>
            </tr>
        </table>
    </div>

    <div id="dvimportacion"  style="display:none">
        <table>
              <tr>
                <td colspan="2"><strong>SHIP TO:(Compañia)</strong></td>
            </tr>
            <tr>
                <td>Nombre:</td>
                <td>
                    <asp:TextBox ID="txtinom" runat="server" Width="200"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Direccion:</td>
                <td>
                    <asp:TextBox ID="txtidir" runat="server" Width="200"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Pais:</td>
                <td>
                    <asp:DropDownList ID="ddlipais" runat="server" Width="150"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Telefono:</td>
                <td>
                    <asp:TextBox ID="txtitel" runat="server" Width="200"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Fax:</td>
                <td>
                    <asp:TextBox ID="txtifax" runat="server" Width="200"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Att:</td>
                <td>
                    <asp:TextBox ID="txtiatt" runat="server" Width="200"></asp:TextBox>
                </td>
            </tr>
        </table>
        <hr />
        
        <table>
            <tr>
                <td colspan="2"><strong>COSIGN TO:(Compañia)</strong></td>
            </tr>
            <tr>
                <td>Nombre:</td>
                <td>
                    <asp:TextBox ID="txtinom2" runat="server" Width="200"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Direccion:</td>
                <td>
                    <asp:TextBox ID="txtidir2" runat="server" Width="200"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Pais:</td>
                <td>
                    <asp:DropDownList ID="ddlipais2" runat="server" Width="150"></asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td>Telefono:</td>
                <td>
                    <asp:TextBox ID="txtitel2" runat="server" Width="200"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Fax:</td>
                <td>
                    <asp:TextBox ID="txtifax2" runat="server" Width="200"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Att:</td>
                <td>
                    <asp:TextBox ID="txtiatt2" runat="server" Width="200"></asp:TextBox>
                </td>
            </tr>
           </table>
          <hr /><table>
            <tr>
                <td colspan="2">
                    <input class="btiarr" value="Continuar" type="button" style="width:100px;height:25px"  />
                </td>
            </tr>
        </table>


        
    </div>
    <div id="dvplanilla"  style="display:none">
        <fieldset style="float:left">
                <table>
         <tr>
                <td>Area</td>
              <td>
                  <asp:DropDownList runat="server" Width="120" ID="ddlparea"></asp:DropDownList>
              </td>
          </tr>
            <tr>
                <td>Service:</td>
                <td colspan="3">
                     <asp:TextBox ID="txtcods" runat="server" Width="100px" placeholder="CODIGO"></asp:TextBox>
                    <asp:TextBox ID="txtservis" runat="server" Width="300px" placeholder="SERVICE"></asp:TextBox>
                </td>
               <td rowspan="2"><input type="button" class="btbuscaplan btn" value="Agrega Busqueda"  /></td>
                <td rowspan="2"><input type="button" class="btlimpiaplan btn" value="Limpiar Busqueda" /></td>
            </tr>
            <tr>
                <td>Fecha:</td>
                <td>
                    <asp:TextBox ID="txtfinis" runat="server" Width="100" placeholder="00/00/0000"></asp:TextBox>
             Fecha Al:
                    <asp:TextBox ID="txtffins" runat="server" Width="100" placeholder="00/00/0000"></asp:TextBox>
                </td>
              
                
            </tr>
                  </table> 
        </fieldset> <table>
                        <tr>
                      
                            <td style="text-align: right" colspan="3">
                                <input type="button" class="btaddplan btn" value="Guardar" style="height: 27px; width: 86px" />
                            </td>
                        </tr>
           <tr>
               <td colspan="3">
                   <asp:GridView ID="gvplan" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"  AutoGenerateColumns="False" Width="917px">
                                     <Columns>
                                         <asp:BoundField DataField="PL_fecha" HeaderText="FECHA PROD" />
                                         <asp:BoundField DataField="PL_codigo" HeaderText="CODIGO" />
                                         <asp:BoundField DataField="PL_servis" HeaderText="SERVIS" ItemStyle-Width="150" />
                                         <asp:BoundField DataField="PL_planilla" HeaderText="PLANILLA" />
                                         <asp:BoundField DataField="PL_especie" HeaderText="ESPECIE" />
                                         <asp:BoundField DataField="PL_presentacion" HeaderText="PRESENTACION" />
                                         <asp:BoundField DataField="PL_tarea" HeaderText="TAREA" ItemStyle-Width="160"/>
                                 <asp:BoundField DataField="PL_cantidad" HeaderText="CANTIDAD" ItemStyle-HorizontalAlign="Right" />
                                 <asp:BoundField DataField="PL_tarifa" HeaderText="TARIFA" ItemStyle-HorizontalAlign="Right" />
                                 <asp:BoundField DataField="PL_total" HeaderText="TOTAL" ItemStyle-HorizontalAlign="Right" />
                                      <asp:BoundField DataField="PL_turno" HeaderText="TURNO" ItemStyle-HorizontalAlign="Right" />
                                         <asp:BoundField DataField="PL_turno" HeaderText="GUIA" ItemStyle-HorizontalAlign="Right" />
                                         <asp:TemplateField ItemStyle-Width="11px" >
                                         <HeaderTemplate> 
                                                  <div class ="ver" style="text-align:center">
                                                      <input type="checkbox" class="chktodos" />
                                                 </div>
                                          </HeaderTemplate>
                                             <ItemTemplate>
                                                 <div class ="ver" style="text-align:center">
                                                      <input type="checkbox" class="chkplanilla" />
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

        <tr>
            <td>Total:
                <asp:TextBox runat="server" ID="txttotaplani" Width="120" Enabled="false"></asp:TextBox>
            </td>
        </tr>   
        </table>
        


        
    </div>

   
</asp:Content>

