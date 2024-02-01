<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="OCnueva.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">


    <script type="text/javascript">
        $(window).load(function () {
            contarndw = 0;
            cc = 1;
            sw_edicion = 0;
            sw_nuevo = 0;
            contaditem = 0;
            $(function () {
                $("#MainContent_txtfecha1").datepicker();
                $("#MainContent_txtfecha2").datepicker();
                $("#MainContent_txtdfechat1").datepicker();
            });

            var codextraido= window.location.search.substring(1);
            if (codextraido.length > 1) {
                MostrarunRegistro(codextraido);
            }
            

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
                $("td", rowt).eq(5).html(precioconigv.toFixed(9));
                $("td", rowt).eq(6).html($("#MainContent_txtddesca").val());
                $("td", rowt).eq(6).val(desadic);
                $("td", rowt).eq(7).html($("#MainContent_txtddesci").val());
                $("td", rowt).eq(7).val(descitem);
                $("td", rowt).eq(8).html($("#MainContent_txtdigv").val());
                $("td", rowt).eq(8).val(igvch);
                $("td", rowt).eq(9).html($("#MainContent_txtdisc").val());
                $("td", rowt).eq(10).html(preciofinal.toFixed(9));

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
                $("td", rowt).eq(17).val(monto_mn.toFixed(3));

                $("td", rowt).eq(18).html(totalisc.toFixed(3));


                $("[id*=gvordencompra]").append(rowt);
                rowt = $("[id*=gvordencompra] tr:last-child").clone(true);
                contarndw = contarndw + 1;

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
                $("td", trpedita).eq(5).html(precioconigv.toFixed(9));
                $("td", trpedita).eq(6).html($("#MainContent_txtddesca").val());
                $("td", trpedita).eq(6).val(desadic);
                $("td", trpedita).eq(7).html($("#MainContent_txtddesci").val());
                $("td", trpedita).eq(7).val(descitem);
                $("td", trpedita).eq(8).html($("#MainContent_txtdigv").val());
                $("td", trpedita).eq(8).val(igvch);
                $("td", trpedita).eq(9).html($("#MainContent_txtdisc").val());
                $("td", trpedita).eq(10).html(preciofinal.toFixed(9));
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
                $("td", trpedita).eq(17).html($("#MainContent_txtdcomen").val());
                $("td", trpedita).eq(17).val(monto_mn.toFixed(3));
                $("td", trpedita).eq(18).html(totalisc.toFixed(3));

                alert("Se Actualizo la Informacion");
                $(".btaddd").attr("value", "Agregar");
                sw_edicion = 0;
            }


            var sub01 = recorregrid().sumasub; var des01 = recorregrid().sumadesc;
            var igv01 = recorregrid().sumaigvv; var tot01 = recorregrid().sumatotall;

            $("#MainContent_txttbrutof").val(sub01.toFixed(2));
            $("#MainContent_txtdescf").val(des01.toFixed(2));
            $("#MainContent_txtigvf").val(igv01.toFixed(2));
            $("#MainContent_txtnetof").val(tot01.toFixed(2));

        }
    </script>


    <script type="text/javascript">
        $(function () {
            $('#dvdetalle').dialog({
                autoOpen: false,
                modal: true,
                resizable: true,
                width: 950,
                heigth: 100,
                title: 'Detalle',
                close: function (event, ui) {
                },
                buttons: {
                    Grabar: function () {
                        recorregriddetalle();
                        alert("Registro Grabado");
                    }
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



    </script>

    <script type="text/javascript">

        $(function () {
            $("#MainContent_txtprove").autocomplete(
                {
                    source: function (request, response) {
                        $.ajax({
                            url: "OCnueva.aspx/GetProveedores",
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
                        posicionEspacio = cadena.indexOf("@"), //Obtengo la posición del espacio en la cadena
                        primerApellido = cadena.substring(0, posicionEspacio) //Obtengo la porción deseada de la cadena
                        enMinuscula = primerApellido.toLowerCase(); //Convierto el apellido a minúscula

                        primerApellido = cadena.substring(posicionEspacio + 1, str.length)
                        $('#MainContent_txtidpro').val(str);
                        $('#MainContent_txtdire').val(dire);


                    }
                });




        });
        $(function () {
            $("#MainContent_ddlccost").autocomplete(
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
                            data: "{ 'dato': '" + request.term + "',codigo:'12' }",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            dataFilter: function (data) { return data; },
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        value: item.TG_CDESCRI,
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
                            data: "{ 'dato': '" + request.term + "',codigo:'12' }",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            dataFilter: function (data) { return data; },
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        value: item.TG_CDESCRI,
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
                        //primerApellido = cadena.substring(posicionEspacio + 1, str.length)
                        $('#MainContent_txtdcodsoli').val(str);

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
                                        id: item.TG_CCLAVE
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

    </script>


    <%-- //clickg --%>

    <script type="text/javascript">
        $(function () {
            $(".btbuscar").click(function () {
                filtarocompra();
            });

            $(".txtmost").click(function () {

                $("#dveditar").dialog('open');

            });

            $(".btmostrar").click(function () {
                var idcompr = $("#MainContent_txtenorden").val();
                MostrarunRegistro(idcompr);
            });

            //$(".bteliminadet").click(function () {
            //    Eliminaciondet();
            //});


            $(".tcamb").change(function () {
                var tcam = MostrarTcambio();
                $("#MainContent_txttcambio").val(tcam);

            });

            $(".btadd").click(function () {

                if ($("#MainContent_ddlmone").val() == "-1") {
                    alert("No Ha Seleccionado la Moneda");
                    $("#MainContent_ddlmone").focus();

                } else if ($("#MainContent_ddltipo").val() == "-1") {
                    alert("No Ha Seleccionado el Tipo Orden");
                    $("#MainContent_ddltipo").focus();
                } else {
                    if (sw_nuevo == 0) {
                        var idc = Insertarnumero();
                        $("#MainContent_txtnumoc").val(idc);
                        
                        sw_nuevo = 1;
                    } else {
                        filtarListocompra();
                    }
                    $("#MainContent_txtoc").val($("#MainContent_txtnumoc").val());
                    InsertarCabcera();
                    $("#dvdetalle").dialog('open');

                }
            });

            $("#MainContent_txtidsoli").change(function () {
                var textdev = Mostrarundato($("#MainContent_txtidsoli").val(), '12').ee;
                if (textdev != null) {
                    $("#MainContent_txtsoli").val(textdev);
                } else {
                    $("#MainContent_txtsoli").val("");
                    alert("Codigo no existe");
                }
            });

            $("#MainContent_txtdcodsoli").change(function () {
                var textdev = Mostrarundato($("#MainContent_txtdcodsoli").val(), '12').ee;
                if (textdev != "") {
                    $("#MainContent_txtdsoli").val(textdev);
                } else {
                    $("#MainContent_txtdsoli").val("");
                    alert("Codigo no existe");
                }
            });


            $("#MainContent_txtcodcos").change(function () {
                var textdev = Mostrarundato($("#MainContent_txtcodcos").val(), '10').ee;
                if (textdev != "") {
                    $("#MainContent_ddlccost").val(textdev);
                } else {
                    alert("Codigo no existe");
                    $("#MainContent_ddlccost").val("");
                }
            });

            $("#MainContent_txtdcodcost").change(function () {
                var textdev = Mostrarundato($("#MainContent_txtdcodcost").val(), '10').ee;
                if (textdev != "") {
                    $("#MainContent_txtdccost").val(textdev);
                } else {
                    alert("Codigo no existe");
                    $("#MainContent_txtdccost").val("");
                }
            });


            $(".btaddd").click(function () {
                VerDetalleGrid();
            });



            $(".chigv").click(function () {

                if ($("#MainContent_chkigv").attr("checked") == true) {

                    $("#MainContent_txtdigv").attr("disabled", false);
                } else {
                    $("#MainContent_txtdigv").attr("disabled", true);
                }
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
                var trp = $(this).parent().parent();
                var itemde = $("td:eq(2)", trp).html();
                ITEM_COD = $("td:eq(0)", trp).html();
                var ques_base = $("td:eq(18)", trp).val();

                
                

                if (confirm("Esta Seguro que Desea eliminar el Item: " + itemde)) {
                    if (ques_base == "B") {
                        Eliminaciondet();
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
                    }
                }
                //}
            });

            $(".btedita").click(function () {

                trpedita = $(this).parent().parent();

                var extraefila = [];
                var extraefilaval = [];
                //var pit = 0;
                
                for (var i = 0; i < 19; i++) {
                    var itemde = $("td:eq(" + i + ")", trpedita).html();
                    var itemdeval = $("td:eq(" + i + ")", trpedita).val();
                    extraefila[i] = itemde;
                    extraefilaval[i] = itemdeval;
                }

                $("#MainContent_txtdcodati").val(extraefila[1]);
                $("#MainContent_txtdarticulo").val(extraefila[2]);
                $("#MainContent_txtdprec").val(extraefila[10])
                $("#MainContent_txtdumed").val(extraefila[3]);
                $("#MainContent_txtdcant").val(extraefila[4]);
                $("#MainContent_txtddesca").val(extraefila[6]);
                $("#MainContent_txtddesci").val(extraefila[7]);
                $("#MainContent_txtdigv").val(extraefila[8]);
                $("#MainContent_txtdisc").val(extraefila[9]);
                $("#MainContent_txtdfechat1").val(extraefila[16]);
                $("#MainContent_txtdcomen").val(extraefila[17]);

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



                var textdev = Mostrarundato($("#MainContent_txtdcodcost").val(), '10').ee;
                if (textdev != "") {
                    $("#MainContent_txtdccost").val(textdev);
                } else {
                    $("#MainContent_txtdccost").val("");
                }


                var textdev = Mostrarundato($("#MainContent_txtdcodsoli").val(), '12').ee;
                if (textdev != "") {
                    $("#MainContent_txtdsoli").val(textdev);
                } else {
                    $("#MainContent_txtdsoli").val("");
                }

                sw_edicion = 1;

                $(".btaddd").attr("value", "Actualizar");

            });




        });

    </script>


    <script type="text/javascript">

        function recorregriddetalle() {

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
            subbt = "";
            var gridView = document.getElementById("<%=gvordencompra.ClientID %>");

            for (var t = 1; t < gridView.rows.length; t++) {


                cellPivot = gridView.rows[t].cells[0]; gitem = cellPivot.innerHTML;
                cellPivot02 = gridView.rows[t].cells[1]; gidcod = cellPivot02.innerHTML;
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
                cellPivot23 = gridView.rows[t].cells[16]; gtus01 = cellPivot23.value;

                cellPivot16 = gridView.rows[t].cells[15]; gcantsald = cellPivot16.innerHTML;
                cellPivot24 = gridView.rows[t].cells[17]; gtmn01 = cellPivot24.value;

                cellPivot17 = gridView.rows[t].cells[16]; gfechaent = cellPivot17.innerHTML;
                cellPivot18 = gridView.rows[t].cells[17]; gobser = cellPivot18.innerHTML;
                cellPivot19 = gridView.rows[t].cells[18]; gisc = cellPivot19.innerHTML;
                gsumadolares = Number(gsumadolares) + Number(gtus01);
                gsumasoles = Number(gsumadolares) + Number(gtmn01);
                InsertarDetalle();
            }

            Modicacabmontos($("#MainContent_txtnumoc").val(), gsumadolares.toFixed(3), gsumasoles.toFixed(3));
        }
    </script>
    <script type="text/javascript">


        function InsertarDetalle() {

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
            DETA.OC_CCENCOS = $("#MainContent_txtdcodcost").val().trim();
            DETA.OC_CNUMREQ = "";
            DETA.OC_CSOLICI = $("#MainContent_txtdcodsoli").val().trim();
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
                url: "OCnueva.aspx/InsertaDet",
                data: '{DETA: ' + JSON.stringify(DETA) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                //async: false,
                success: function (response) {

                },
                error: function (response) {
                    if (response.length != 0)
                        //alert(response);
                        console.table(response);
                }
            });

        }


    </script>


    <script type="text/javascript">

        function filtarListocompra() {

            var LDE = {};
            LDE.OC_CNUMORD = $("#MainContent_txtnumoc").val();

            $.ajax({
                type: "POST",
                url: "OCnueva.aspx/GetListaDetalle",
                data: '{LDE: ' + JSON.stringify(LDE) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
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
                            $("td", row).eq(5).html(data.d[i].OC_NPREUN2);
                            $("td", row).eq(6).html(data.d[i].OC_NDSCPAD);
                            $("td", row).eq(6).val(data.d[i].OC_NDESCAD);
                            $("td", row).eq(7).html(data.d[i].OC_NDSCPIT);
                            $("td", row).eq(7).val(data.d[i].OC_NDESCIT);
                            $("td", row).eq(8).html(data.d[i].OC_NIGVPOR);
                            var checkigv = data.d[i].OC_CIGVPOR == "S" ? "1" : "0";
                            $("td", row).eq(8).val(checkigv);
                            $("td", row).eq(9).html(data.d[i].OC_NISCPOR);
                            $("td", row).eq(10).html(data.d[i].OC_NPREUNI);
                            $("td", row).eq(11).html(data.d[i].OC_NDESCTO);
                            $("td", row).eq(11).val(data.d[i].OC_NDSCPOR);
                            $("td", row).eq(12).html(data.d[i].OC_NIGV);//total igv
                            $("td", row).eq(12).val(data.d[i].OC_NIGV);//total igv
                            var subt = data.d[i].OC_NPREUN2 * data.d[i].OC_NCANORD;
                            $("td", row).eq(13).html(subt);//subtotal
                            $("td", row).eq(13).val(subt);//subtotal
                            $("td", row).eq(14).html(data.d[i].OC_NCANTEN);
                            $("td", row).eq(14).val(data.d[i].OC_CSOLICI);
                            $("td", row).eq(15).html(data.d[i].OC_NCANSAL);
                            $("td", row).eq(15).val();//solicitante 
                            $("td", row).eq(16).html(moment(data.d[i].OC_DFECENT).format("Dd/MM/YYYY"));
                            $("td", row).eq(16).val(data.d[i].OC_NTOTUS);
                            $("td", row).eq(17).html(data.d[i].OC_COMENTA);
                            $("td", row).eq(17).val(data.d[i].OC_NTOTMN);
                            $("td", row).eq(18).html(data.d[i].OC_NISC);
                            $("td", row).eq(18).val("B");
                            contaditem = Number(data.d[i].OC_CITEM);
                            contarndw = contarndw + 1;
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

                    ee = data.d.TG_CDESCRI;

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

        function InsertarCabcera() {

            var horao = obetenerhora();

            var fec1 = moment($("#MainContent_txtfecha1").val(), "DD/MM/YYYY");
            fec1 = fec1 == null ? null : new Date(fec1);
            var fec02 = moment($("#MainContent_txtfecha2").val(), "DD/MM/YYYY");
            fec02 = fec02 == null ? null : new Date(fec02);
            var dfactual = moment($("#MainContent_hffactual").val(), "DD/MM/YYYY");
            dfactual = dfactual == null ? null : new Date(dfactual);

            var fpagg = $("#MainContent_ddlfpago option:selected").text();
            fpagg = fpagg.substring(0, 30);

            var CABC = {};
            CABC.OC_CNUMORD = $("#MainContent_txtnumoc").val().trim();
            CABC.OC_CCODPRO = $("#MainContent_txtidpro").val().trim();
            CABC.OC_CRAZSOC = $("#MainContent_txtprove").val().trim();
            CABC.OC_CDIRPRO = $("#MainContent_txtdire").val().trim();
            CABC.OC_CCOTIZA = "";
            CABC.OC_CCODMON = $("#MainContent_ddlmone").val().trim();
            CABC.OC_CFORPA1 = fpagg;
            CABC.OC_CFORPA2 = "";
            CABC.OC_CFORPA3 = "";
            CABC.OC_NTIPCAM = $("#MainContent_txttcambio").val();
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
            CABC.OC_CCONDIC = "";
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
            CABC.OC_CTIPDSP = "";
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
                url: "OCnueva.aspx/InsertaCab",
                data: '{CABC: ' + JSON.stringify(CABC) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {

                },
                error: function (response) {
                    if (response.length != 0)
                        alert(response);
                }
            });

        }


        $(function () {
            $(".idart").autocomplete(
                {
                    source: function (request, response) {
                        $.ajax({
                            url: "OCnueva.aspx/GetProductos",
                            data: "{ 'productos': '" + request.term + "' }",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            dataFilter: function (data) { return data; },
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        value: item.AR_CDESCRI,
                                        id: item.AR_CCODIGO,
                                        um: item.AR_CUNIDAD,
                                        igvp: item.AR_NIGVCPR


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
                        $('#MainContent_txtdcodati').val(str);
                        $('#MainContent_txtdumed').val(strum);
                        $('#MainContent_txtdigv').val(strigv);

                    }
                });




        });

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
                        $("#MainContent_ddlfpago option:selected").text(data.d.OC_CDIRPRO);
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
                        $("#MainContent_ddltipo").val(data.d.OC_CTIPORD);
                        $("#MainContent_ddlpais").val(data.d.OC_CCOPAIS);
                        $("#MainContent_txtremi").val(data.d.OC_CREMITE);
                        $("#MainContent_txtaten").val(data.d.OC_CPERATE);
                        $("#MainContent_txtref2").val(data.d.OC_CNUMREF);
                        $("#MainContent_ddldocre").val(data.d.OC_CTIPDOC);
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
                    }
                },
                error: function (data) {
                    if (data.length != 0)
                        alert(data);
                }
            });
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
                    alert("elimnado");

                },
                error: function (data) {
                    if (data.length != 0)
                        alert(data);
                }
            });
        }

    </script>

    <style type="text/css">
        .auto-style1 {
            width: 132px;
        }

        fieldset {
            padding: 10px;
            border: 1px solid black;
            border-radius: 5px;
            background-color: white;
            /*margin:0 auto;*/
            width: 900px;
        }

        legend {
            padding: 5px;
            font-size: 15px;
            border-radius: 10px;
            background-color: white;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:HiddenField runat="server" ID="hffactual" />
    <asp:HiddenField runat="server" ID="hfusu" />
    <div id="aa">
        <fieldset style="background-color: #99CCFF">
            <legend>MANTENIMIENTO DE ORDEN DE COMPRA </legend>

            <table>
                <tr>
                    <td>Orden Compra:
                    </td>
                    <td colspan="3">

                        <asp:TextBox ID="txtnumoc" runat="server" Width="100" ReadOnly="true" class="txtmost"></asp:TextBox>

                    </td>
                    <td>Fecha</td>
                    <td>
                        <asp:TextBox ID="txtfecha1" class="tcamb" runat="server" Width="130" placeholder="00/00/0000"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Proveedor:</td>
                    <td colspan="3">
                        <asp:TextBox ID="txtprove" runat="server" Width="300"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtidpro" Enabled="false" runat="server" Width="100"></asp:TextBox>
                    </td>
                    <td>Fax:<asp:TextBox runat="server" ID="txtfax" Width="102px" Height="18px" Enabled="false"></asp:TextBox>
                    </td>


                </tr>
                <tr>
                    <td>direccion</td>
                    <td colspan="3">

                        <asp:TextBox ID="txtdire" runat="server" Width="300"></asp:TextBox>

                    </td>
                    <td>Tipo Despacho</td>
                    <td>
                        <asp:DropDownList ID="ddltdespa" runat="server" Width="130"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Doc Referencia:</td>
                    <td class="auto-style1">
                        <asp:DropDownList ID="ddldocre" runat="server" Width="130"></asp:DropDownList>
                    </td>
                    <td>

                        <asp:TextBox ID="txtnumref" runat="server" Width="161px"></asp:TextBox>

                    </td>
                    <td></td>
                    <td>N° Doc Ref.02</td>
                    <td>

                        <asp:TextBox ID="txtref2" runat="server" Width="130"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td>Moneda:</td>
                    <td class="auto-style1">
                        <asp:DropDownList ID="ddlmone" runat="server" Width="130"></asp:DropDownList>
                    </td>
                    <td></td>
                    <td></td>

                    <td>Tipo O/C:</td>
                    <td>
                        <asp:DropDownList ID="ddltipo" runat="server" Width="130"></asp:DropDownList>
                    </td>
                    <%-- <td>
                <input class="btbuscar" value="Buscar" type="button" style="width:80px" />
            </td>--%>
                </tr>
                <tr>
                    <td>Forma Pago:</td>
                    <td colspan="3">
                        <asp:DropDownList runat="server" ID="ddlfpago" Width="300"></asp:DropDownList>
                    </td>

                    <td>Tipo Cambio</td>
                    <td>
                        <asp:TextBox ID="txttcambio" runat="server" Width="130"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Fecha al:</td>
                    <td>
                        <asp:TextBox ID="txtfecha2" runat="server" Width="130" placeholder="00/00/0000"></asp:TextBox>
                    </td>

                    <td colspan="2">Dscto Fina.
                 <asp:TextBox ID="txtdfina" runat="server" Width="88px"></asp:TextBox>
                    </td>
                    <td>Pais
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlpais" Width="130"></asp:DropDownList>
                    </td>
                </tr>

            </table>
            <hr />
            <table>
                <tr>
                    <td>Solicitante:</td>
                    <td colspan="6">
                        <asp:TextBox ID="txtidsoli" runat="server" Width="100"></asp:TextBox>


                        <asp:TextBox ID="txtsoli" runat="server" Width="300"></asp:TextBox>

                    </td>

                </tr>
                <tr>
                    <td>Centro Costo:</td>
                    <td colspan="6">
                        <asp:TextBox runat="server" ID="txtcodcos" Width="100"></asp:TextBox>

                        <asp:TextBox runat="server" ID="ddlccost" Width="300"></asp:TextBox>
                    </td>


                </tr>
                <tr>
                    <td>Tipo Envio </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtenvio" runat="server" Width="300"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Almacen:</td>
                    <td colspan="2">

                        <asp:DropDownList ID="ddlalma" class="selalma" runat="server" Width="300"></asp:DropDownList>

                    </td>
                </tr>
                <tr>
                    <td>Lugar Entrega:</td>
                    <td colspan="2">
                        <asp:TextBox ID="txtlentre" runat="server" Width="300"></asp:TextBox>
                    </td>
                    <td>Distri.:</td>
                    <td>
                        <asp:TextBox ID="txtdist" runat="server" Width="100"></asp:TextBox>
                    </td>
                    <td>Provinc:</td>
                    <td>
                        <asp:TextBox ID="txtprov" runat="server" Width="100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Lugar Factura </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtlugarf" runat="server" Width="300"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Observaciones :</td>
                    <td colspan="6">
                        <asp:TextBox TextMode="MultiLine" Rows="2" runat="server" ID="txtobs" Width="595" MaxLength="80"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Remite:</td>
                    <td colspan="1">
                        <asp:TextBox ID="txtremi" runat="server" Width="180"></asp:TextBox>
                    </td>
                    <td>Persona Atencion:</td>
                    <td colspan="4">
                        <asp:TextBox ID="txtaten" runat="server" Width="180"></asp:TextBox>
                    </td>
                </tr>

            </table>
            <table>
                <tr>
                    <td>
                        <input class="btadd" value="Agregar Detalle" type="button" style="width: 120px; height: 35px; border-radius: 5px" />
                    </td>
                    <%-- <td>
                <input class="prueba" value="Agregar Detalle" type="button" style="width:120px;height:35px;border-radius:5px" />
                </td>--%>
                </tr>
            </table>
        </fieldset>
    </div>
    <div id="dvdetalle">
        <%-- <fieldset style="background-color: #99CCFF"> --%>
        <table>
            <tr>
                <td>Orden Compra:</td>
                <td>
                    <asp:TextBox ID="txtoc" runat="server" Width="130" Enabled="false"></asp:TextBox>
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
        <fieldset style="background-color: #99CCFF">
            <table>
                <tr>
                    <td>Articulo:</td>
                    <td colspan="5">
                        <asp:TextBox ID="txtdarticulo" runat="server" Width="300" class="idart"></asp:TextBox>
                        <asp:TextBox ID="txtdcodati" runat="server" Width="100"></asp:TextBox>
                        <asp:TextBox ID="txtdumed" runat="server" Width="50"></asp:TextBox>
                    </td>
                </tr>


                <tr>
                    <td>Cantidad Pedida</td>
                    <td>
                        <asp:TextBox ID="txtdcant" runat="server" Width="100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Precio</td>
                    <td>
                        <asp:TextBox ID="txtdprec" runat="server" Width="100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>solicitante:</td>
                    <td colspan="5">
                        <asp:TextBox ID="txtdcodsoli" runat="server" Width="100"></asp:TextBox>
                        <asp:TextBox ID="txtdsoli" runat="server" Width="300" class="soli2"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td>Centro Costo:</td>
                    <td colspan="5">
                        <asp:TextBox ID="txtdcodcost" runat="server" Width="100"></asp:TextBox>
                        <asp:TextBox ID="txtdccost" runat="server" Width="300" class="ccost2"></asp:TextBox>

                    </td>

                </tr>
            </table>
        </fieldset>
        <fieldset style="background-color: #99CCFF">
            <table>
                <tr>
                    <td>Dscto Finan</td>
                    <td>
                        <asp:TextBox ID="txtddescf" runat="server" Width="100">0</asp:TextBox>
                        %</td>

                    <td>Dscto Item</td>
                    <td>
                        <asp:TextBox ID="txtddesci" runat="server" Width="100">0</asp:TextBox>
                        %</td>

                    <td>Dscto Adicional</td>
                    <td>
                        <asp:TextBox ID="txtddesca" runat="server" Width="100">0</asp:TextBox>
                        %</td>
                </tr>
            </table>
        </fieldset>
        <fieldset style="background-color: #99CCFF">
            <table>

                <tr>
                    <td>
                        <asp:CheckBox runat="server" Text="Incluye IGV" class="chigv" ID="chkigv" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtdigv" runat="server" Width="100" Enabled="false"></asp:TextBox>
                        %</td>
                </tr>
                <tr>
                    <td>Incluye ISC</td>
                    <td>
                        <asp:TextBox ID="txtdisc" runat="server" Width="100">0</asp:TextBox>
                        %</td>
                </tr>
                <tr>
                    <td>Fecha Entrega</td>
                    <td>
                        <asp:TextBox ID="txtdfechat1" runat="server" Width="100" placeholder="00/00/0000"></asp:TextBox>
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
                    <td>Cometario</td>
                    <td colspan="5">
                        <asp:TextBox TextMode="MultiLine" Rows="2" runat="server" ID="txtdcomen" Width="395"></asp:TextBox>
                    </td>
                    <td>
                        <input runat="server" type="button" class="btaddd" value="Agregar" style="width: 115px; height: 30px; border-radius: 5px" />
                    </td>
                  
                </tr>
            </table>
        </fieldset>
        <table>
            <tr>
                <td colspan="3">
                    <asp:GridView ID="gvordencompra" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" Width="1292px" Font-Size="Smaller">
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
                            <asp:BoundField DataField="OC_NDSCPAD" HeaderText="Dcto Adic">
                                <ItemStyle Width="8px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="OC_NDSCPIT" HeaderText="Dcto item">
                                <ItemStyle Width="8px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="OC_NIGVPOR" HeaderText="Igv">
                                <ItemStyle Width="8px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="OC_NISCPOR" HeaderText="Isc">
                                <ItemStyle Width="8px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="OC_NPREUNI" HeaderText="Precio Final">
                                <ItemStyle Width="8px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="OC_NDESCTO" HeaderText="Total dscto">
                                <ItemStyle Width="8px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="OC_NIGV" HeaderText="Total Igv">
                                <ItemStyle Width="8px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="SUBTOTAL" HeaderText="Subtotal">
                                <ItemStyle Width="8px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="OC_NCANTEN" HeaderText="Cant Reci.">
                                <ItemStyle Width="8px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="OC_NCANSAL" HeaderText="Cant Recibir">
                                <ItemStyle Width="8px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="OC_DFECENT" HeaderText="Fecha Entrega">
                                <ItemStyle Width="8px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="OC_COMENTA" HeaderText="Observacion">
                                <ItemStyle Width="8px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="OC_NISC" HeaderText="Total ISC">
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

    <div id="dveditar">
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


</asp:Content>

