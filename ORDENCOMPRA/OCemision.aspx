<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="OCemision.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link type="text/css" href="../CSS/Base-s.css?1.5" rel="stylesheet" />

    <script type="text/javascript">
        $(window).load(function () {
            $("#fotocargando").hide()
        });

        $(function () {
            $("#MainContent_txtfecha1").datepicker();
            $("#MainContent_txtfecha2").datepicker();
            bloqueacombo();
            $('#dvdetalle').dialog({
                autoOpen: false,
                modal: true,
                resizable: true,
                width: 870,
                heigth: 100,
                title: 'Detalle',
                close: function (event, ui) {
                },
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
           
            $('#dvimprimeml2').dialog({
                autoOpen: false,
                modal: true,
                resizable: true,
                width: 300,
                heigth: 80,
                title: 'Impresion',
                close: function (event, ui) { },
            });

            $('#dvimprimileas').dialog({
                autoOpen: false,
                modal: true,
                resizable: true,
                width: 300,
                heigth: 80,
                title: 'Impresion',
                close: function (event, ui) { },
            });
            

        });

    </script>

     <script type="text/javascript">
        
         $(function () {
             $("#MainContent_txtprove").autocomplete(
                 {
                     source: function (request, response) {
                         $.ajax({
                             url: "OCemision.aspx/GetProveedores",
                             data: "{ 'productos': '" + request.term + "','cod':'P' }",
                             dataType: "json",
                             type: "POST",
                             contentType: "application/json; charset=utf-8",
                             dataFilter: function (data) { return data; },
                             success: function (data) {
                                 response($.map(data.d, function (item) {
                                     return {
                                         value: item.ADESANE,
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
                         posicionEspacio = cadena.indexOf("@"), //Obtengo la posición del espacio en la cadena
                         primerApellido = cadena.substring(0, posicionEspacio) //Obtengo la porción deseada de la cadena
                         enMinuscula = primerApellido.toLowerCase(); //Convierto el apellido a minúscula

                         primerApellido = cadena.substring(posicionEspacio + 1, str.length)
                         
                         $('#MainContent_txtidpro').val(str);


                     }
                 });


             $("#MainContent_txtprove").change(function () {
                 if ($("#MainContent_txtprove").val() == "") {
                     $('#MainContent_txtidpro').val("");
                 }
             })

             $("#MainContent_txtidpro").change(function () {
                 if (Mostrarunproveedor($(this).val()).ee == "") {
                     alert("No se encontro informacion");
                     $(this).focus();
                 } else {
                     $("#MainContent_txtprove").val(Mostrarunproveedor($(this).val()).ee);
                     $("#MainContent_txtnumref").focus();
                 }
             });
             $("#MainContent_ddltipo").change(function () {
                 bloqueacombo();
             });

         });

	</script>



    <script type="text/javascript">
        $(function () {
            $(".btbuscar").click(function () {
                $("#fotocargando").show();
                filtarocompra();
            });

            $(".btedita").click(function () {
                var trp = $(this).parent().parent();
                var variableServidor = $("td:eq(0)", trp).html();
                var estadooc = $("td:eq(8)", trp).val();

                var nraprov = ValidanAproOC(variableServidor).ee;
              
                if (estadooc == "1") {
                    if (Number(nraprov) > 0) {
                        alert("La Orden esta Emitida pero tiene Aprobaciones");
                    }else{
                        if (variableServidor != "&nbsp;") {
                            window.location.assign("\OCnueva.aspx?ID=" + variableServidor);
                        }
                    }
                } else {
                    alert("Solo se Puede Editar una orden Emitida");
                }
            });

            $(".ver").click(function () {
                var trp = $(this).parent().parent();
                idordenc = $("td:eq(0)", trp).html();
                var estadooc = $("td:eq(8)", trp).val();
               
                MostrarunRegistro(idordenc);
                filtarListocompra();
                $("#dvdetalle").dialog('open');
            });
            
            $(".btimpr2").click(function () {
                var Tdata = $("#MainContent_chkimp2").find(":checked").val();
                var idnumordj = $("td:eq(0)", trs).html();
                window.open("../ORDENCOMPRA/REPORTES/ACReporteOrden.aspx?ID=" + idnumordj + "&IDAG=" + "0003" + "&FI=" + Tdata, '_blank');
            });


            $(".btimpr").click(function () {

                if ($("#MainContent_chkimp").find(":checked").val() == "M") {
                    window.open("../ORDENCOMPRA/REPORTES/OTReporteOrden.aspx?ID=" + idnumordj + "&IDAG=" + "0003", '_blank');
                } else {
                    window.open("../ORDENCOMPRA/REPORTES/ReporteOrden.aspx?ID=" + idnumordj + "&IDAG=" + "0003", '_blank');
                }
            });

            $(".btimpleasea").click(function () {
                idagencua = "";
                if ($("#MainContent_rbsealea").find(":checked").val() == "S") { idagencua = "0003"; } else { idagencua = "0004"; }

                if (gcondi == '3') {
                    window.open("../ORDENCOMPRA/REPORTES/EXReporteOrden.aspx?ID=" + idnumor + "&IDAG=" + idagencua, '_blank');
                }else if (gcondi == '8') {
                   window.open("../ORDENCOMPRA/REPORTES/ACReporteOrden.aspx?ID=" + idnumor + "&IDAG=" + idagencua, '_blank');
                }else{
                    window.open("../ORDENCOMPRA/REPORTES/ReporteOrden.aspx?ID=" + idnumor + "&IDAG=" + idagencua, '_blank');
                }

            });
            
            

            $(".imprimi").click(function () {

                var trp = $(this).parent().parent();
                trs = $(this).parent().parent();

                idnumor = $("td:eq(0)", trp).html();
                idnumordj = idnumor;
                idprov = $("td:eq(2)", trp).val();
                idprovdj = idprov;
                desprov = $("td:eq(2)", trp).html();
                var condicc = $("td:eq(3)", trp).val();
                gcondi = condicc;
                idprov = idprov.trim();
                idnumor = idnumor.trim();
                desprov = desprov.trim().replace(',', '');
                desprovdj = desprov;
               
                //alert(condicc);
                if (idnumor != "&nbsp;" && idprov != "") {
                    if (condicc == '2') {
                        $('#dvimprimeml').dialog('open');
                    } else if (condicc == '8') {
                        $('#dvimprimeml2').dialog('open');
                    } else if (condicc == '3') {
                        window.open("../ORDENCOMPRA/REPORTES/EXReporteOrden.aspx?ID=" + idnumor.trim() + "&IDAG=0003", '_blank');
                    } else {
                        $('#dvimprimileas').dialog('open');
                    }
                } else {
                    alert("Error en envio de Datos");
                }
            });            
            
            $(".btnuevo").click(function () {
                window.open("../ORDENCOMPRA/OCnueva.aspx", '_blank');
                //window.location.assign("\OCnueva.aspx");
                
            });
            


            $(".btelmi").click(function () {
                trp = $(this).parent().parent();
                idnumoc = $("td:eq(0)", trp).html();
                var estadooc = $("td:eq(8)", trp).val();
                var estadoocletra = $("td:eq(5)", trp).html();
                var numreq = $("td:eq(7)", trp).html();
                if (estadooc != "") {
                if (estadooc != "1") {
                    alert("La orden de Compra No se Puede Anular, Se Encuentra en Estado: " + estadoocletra);
                }else{
                if (confirm("Desea Anular la Orden de Compra: " + idnumoc)) {
                    anulacionoc(idnumoc, numreq);
                    EliminaciondetOC(idnumoc, numreq);
                    $("td", trp).eq(5).html("ANULADA");
                   $("td", trp).eq(8).val("7");
                }
                }
                }
            });

            
        });

    </script>


    <script type="text/javascript">
        /// ver detalle orden
            function recorregrid() {
            subtt = 0; descc = 0; igvv = 0;
            sumasub = 0; sumadesc = 0; sumaigvv = 0; sumatotall = 0;

            var gridView = document.getElementById("<%=GridView1.ClientID %>");

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

            if (separador_miles) {
                // Añadimos los separadores de miles
                var miles = new RegExp("(-?[0-9]+)([0-9]{3})");
                while (miles.test(numero)) {
                    numero = numero.replace(miles, "$1" + separador_miles + "$2");
                }
            }

            return numero;
        }

        function filtarocompra() {
            var fec1 = moment($("#MainContent_txtfecha1").val(), "DD/MM/YYYY");
            fec1 =  fec1 ==null? null: new Date(fec1);// 
            var fec2 = moment($("#MainContent_txtfecha2").val(), "DD/MM/YYYY");
            
            fec2= fec2 == null ? null : new Date(fec2); //
            
            var VC = {};
            VC.OC_CSITORD =  $("#MainContent_ddlestad option:selected").val();
            VC.OC_CTIPORD = $("#MainContent_ddltipo option:selected").val();
            VC.OC_DFECDOC = fec1;
            VC.OC_DFECENT = fec2;
            VC.OC_CCODPRO =$("#MainContent_txtidpro").val();
            VC.OC_CNUMORD = $("#MainContent_txtndoc").val();
            VC.OC_CCONDIC = $("#MainContent_ddlsuboc").val();
            VC.OC_CCODSOL = "";
            $.ajax({

                type: "POST",
                url: "OCemision.aspx/ListarCabOC",
                data: '{VC: ' + JSON.stringify(VC) + '}',
                contentType: "application/json; charset=utf-8", 
                dataType: "json",
                success: function (data) { 

                    if (data.d.length > 0) {
                        $("[id*=gvordencompra]").append("<thead></thead>");
                        var row = $("[id*=gvordencompra] tr:last-child").clone(true);
                        $("[id*=gvordencompra] tr").not($("[id*=gvordencompra] tr:first-child")).remove();

                        for (var i = 0; i < data.d.length; i++) {

                            $("td", row).eq(0).html(data.d[i].OC_CNUMORD);
                            $("td", row).eq(1).html(data.d[i].OC_DFECDOC);
                            $("td", row).eq(2).html(data.d[i].OC_CRAZSOC);
                            $("td", row).eq(2).val($.trim(data.d[i].OC_CODPRO));
                            $("td", row).eq(3).html(data.d[i].OC_CCODMON);
                            $("td", row).eq(3).val(data.d[i].OC_CCONDIC.trim());

                            var monttMN = data.d[i].OC_NIMPMN;
                            var monttUS = data.d[i].OC_NIMPUS;
                            var monttt = "";

                            if (data.d[i].OC_CCODMON == "MN"){
                                monttt = monttMN;
                            } else {
                                monttt = monttUS;
                            }
                            $("td", row).eq(4).html(formato_numero(Number(monttt).toFixed(2), 2, ".", ","));
                            $("td", row).eq(5).html(data.d[i].OC_CTIPORD);
                            $("td", row).eq(6).html(data.d[i].OC_CSITORD);
                            $("td", row).eq(7).html(data.d[i].OC_CCOTIZA);
                            $("td", row).eq(7).val(data.d[i].OC_NAPROB); 
                            $("td", row).eq(8).val(data.d[i].situanum); 
                            

                            $("[id*=gvordencompra]").append(row);
                            row = $("[id*=gvordencompra] tr:last-child").clone(true);

                        }
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
                    $("#fotocargando").hide();

                },
                error: function (response) {
                    if (response.length != 0)
                        alert(response);
                }
            });

        }

        function anulacionoc(idnumoc, numreq) {
            var idnumd = idnumoc;
            var COANULA = {};
            COANULA.OC_CNUMORD = idnumd;
            COANULA.OC_CSITORD = "7";
            COANULA.OC_CCOTIZA = numreq;
            $.ajax({
                type: "POST",
                url: "OCemision.aspx/anularoc",
                data: '{COANULA: ' + JSON.stringify(COANULA) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    alert("Se ha anulado Correctamente");
                },
                error: function (response) {
                    if (response.length != 0)
                        alert(response);
                }
            });
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
            return { ee};
        }


        function ValidanAproOC(ndoc) {
            var ee = 0;
            $.ajax({

                type: "POST",
                url: "OCemision.aspx/validanaprobOC",
                //data: '{CNUMDOC: ' + JSON.stringify(CNUMDOC) + '}',
                data: "{ADATA: '" + ndoc + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {

                    if (data.d != null) {
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
            return { ee};
        }

        function EliminaciondetOC(idnumoc, numreq) {
            var ELIM = {};
            ELIM.OC_CNUMORD = idnumoc;
            ELIM.OC_CNUMREQ = numreq;

            $.ajax({

                type: "POST",
                url: "OCemision.aspx/EliminaDetalleOC",
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

        function MostrarunRegistro(nrodocumento) {

            var ndocr = nrodocumento;
            var INFO = {};
            INFO.OC_CNUMORD = ndocr;

            $.ajax({

                type: "POST",
                url: "OCnueva.aspx/Getcabecerae",
                data: '{INFO: ' + JSON.stringify(INFO) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                //async: false,
                success: function (data) {
                    if (data.d == null) {
                        alert("No Se encuentra Registro");
                    } else {
                        $("#MainContent_txtnumoc").val(data.d.OC_CNUMORD);
                        $("#MainContent_txtidproc").val(data.d.OC_CCODPRO);
                        $("#MainContent_txtprovec").val(data.d.OC_CRAZSOC);
                        $("#MainContent_txtdire").val(data.d.OC_CDIRPRO);
                        $("#MainContent_ddlfpago").val(data.d.OC_CFORPA1);
                        $("#MainContent_ddlmone").val(data.d.OC_CCODMON);
                        $("#MainContent_txttcambio").val(data.d.OC_NTIPCAM);
                        $("#MainContent_txtsoli").val(data.d.OC_CSOLICT);
                        $("#MainContent_txtenvio").val(data.d.OC_CTIPENV);
                        $("#MainContent_txtlentre").val(data.d.OC_CLUGENT);
                        $("#MainContent_txtlugarf").val(data.d.OC_CLUGFAC);
                        $("#MainContent_txtobs").val(data.d.OC_CDETENT);
                        $("#MainContent_txtfecha").val(moment((data.d.OC_DFECDOC)).format("DD/MM/YYYY"));
                        $("#MainContent_txtfechax").val(moment((data.d.OC_DFECENT)).format("DD/MM/YYYY"));
                        $("#MainContent_hfusu").val(data.d.OC_CUSUARI);
                        data.d.OC_CTIPORD == "I" ? $(".bttimp").show() : $(".bttimp").hide();
                        $("#MainContent_ddltipoc").val(data.d.OC_CTIPORD);
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
                    }
                },
                error: function (data) {
                    if (data.length != 0)
                        alert(data);
                }
            });
        }

        function filtarListocompra() {
            var LDE = {};
            LDE.OC_CNUMORD = idordenc.trim();
            
            $.ajax({
                type: "POST",
                url: "OCemision.aspx/GetListaDetalle",
                data: '{LDE: ' + JSON.stringify(LDE) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {

                    if (data.d.length > 0) {
                        var row = $("[id*=GridView1] tr:last-child").clone(true);
                        $("[id*=GridView1] tr").not($("[id*=GridView1] tr:first-child")).remove();

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
                            $("td", row).eq(12).html(data.d[i].OC_NIGV.toFixed(2));//total igv
                            $("td", row).eq(12).val(data.d[i].OC_NIGV.toFixed(2));//total igv
                            var subt = data.d[i].OC_NPREUN2 * data.d[i].OC_NCANORD;
                            $("td", row).eq(13).html(subt.toFixed(2));//subtotal
                            $("td", row).eq(13).val(subt.toFixed(2));//subtotal
                            $("td", row).eq(14).html(data.d[i].OC_NCANTEN);
                            $("td", row).eq(14).val(data.d[i].OC_CSOLICI);
                            $("td", row).eq(15).html(data.d[i].OC_NCANSAL);
                            $("td", row).eq(15).val();//solicitante 
                            $("td", row).eq(16).html(moment(data.d[i].OC_DFECENT).format("DD/MM/YYYY"));
                            $("td", row).eq(16).val(data.d[i].OC_NTOTUS);
                            $("td", row).eq(17).html(data.d[i].OC_COMENTA);
                            $("td", row).eq(17).val(data.d[i].OC_NTOTMN);
                            $("td", row).eq(18).html(data.d[i].OC_NISC);
                            $("td", row).eq(18).val("B");
                            contaditem = Number(data.d[i].OC_CITEM);
                            //contarndw = contarndw + 1;
                            //cc = 2;
                            $("[id*=GridView1]").append(row);
                            row = $("[id*=GridView1] tr:last-child").clone(true);

                        }

                        var sub01 = recorregrid().sumasub; var des01 = recorregrid().sumadesc;
                        var igv01 = recorregrid().sumaigvv; var tot01 = recorregrid().sumatotall;

                        $("#MainContent_txttbrutof").val(sub01.toFixed(2));
                        $("#MainContent_txtdescf").val(des01.toFixed(2));
                        if (Number(sumaigvv) > 0) {
                            var migvv = Number(sumasub) * 0.18;
                        } else {
                            var migvv = 0;
                        }
                        $("#MainContent_txtigvf").val(formato_numero(migvv, 2, ".", ","));
                        var TTo = (Number(migvv) + Number(sumasub)) - Number(des01);
                        $("#MainContent_txtigvf").val(migvv.toFixed(2));
                        $("#MainContent_txtnetof").val(TTo.toFixed(2));
                    } else {
                        var row = $("[id*=GridView1] tr:last-child").clone(true);
                        $("[id*=GridView1] tr").not($("[id*=GridView1] tr:first-child")).remove();

                        $("td", row).eq(0).html("");
                        $("td", row).eq(1).html("");
                        $("td", row).eq(2).html("");
                        $("td", row).eq(3).html("");
                        $("td", row).eq(4).html("");
                        $("td", row).eq(5).html("");
                        $("td", row).eq(6).html("");
                        $("td", row).eq(7).html("");

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
        function Mostrarunproveedor(codigoproo) {
            var ee = "";
            $.ajax({

                type: "POST",
                url: "../ORDENCOMPRA/OCnueva.aspx/Getdescproveedor",
                //data: '{CNUMDOC: ' + JSON.stringify(CNUMDOC) + '}',
                data: "{textocod: '" + codigoproo + "'}",
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
        function bloqueacombo() {
            var textdev = $("#MainContent_ddltipo").val();
            if (textdev.trim() == "S") {
                $("#MainContent_ddlsuboc").attr("disabled", false);
            } else {
                $("#MainContent_ddlsuboc").attr("disabled", true);
            }
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
           .btn {
               height: 28px;
               width: 130px;
           }
           .auto-style1 {
               height: 18px;
           }
           .auto-style2 {
               height: 26px;
           }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <fieldset>
   <legend > <asp:Label ID="Label9" runat="server" Text="MANTENIMIENTO DE ORDENES" Font-Bold="True" Font-Size="12pt"></asp:Label></legend>

    <table >
    <tr>
        <td>Proveedor</td>
        <td colspan="5">
            <asp:TextBox ID="txtprove"  runat="server" Width="300" ></asp:TextBox> 
       
            <asp:TextBox ID="txtidpro" Enabled="true" runat="server" Width="102" ></asp:TextBox> 
        </td>
        <td>Fecha De:</td>
        <td>
             <asp:TextBox ID="txtfecha1" runat="server" Width="80" ></asp:TextBox> 
        </td>
        
         <td rowspan="2">
                <input class="btbuscar btn" value="Buscar" type="button" style="width:74px; height:28px" />
            </td>
    <td rowspan="2" >
                <input class="btnuevo btn" value="Nuevo" type="button" style="width:75px; height:28px" />
            </td>
        <td rowspan="2" >
             <div id="fotocargando" style="width:100%;text-align: center;" >
                <img src="../Images/loading.gif" style="height: 15px; width: 18px">
     </div>
        </td>
    </tr>
        <tr>
            <td>Estado:</td>
        <td>
             <asp:DropDownList ID="ddlestad" runat="server" Width="130" ></asp:DropDownList> 
        </td>
            <td>Tipo:</td>
        <td>
             <asp:DropDownList ID="ddltipo" runat="server" Width="95" ></asp:DropDownList> 
        </td>
             <td>Sub-Tipo</td>
                     <td>
                        <asp:DropDownList ID="ddlsuboc" runat="server" TabIndex="8" onkeydown="ModifyEnterKeyPressAsTab(event,this);" Width="100"></asp:DropDownList>
                    </td>
             <td>Fecha Al :</td>
        <td>
             <asp:TextBox ID="txtfecha2" runat="server" Width="80" ></asp:TextBox> 
        </td>
                
            </tr><tr>
           <td>N° Docum:</td>
        <td colspan="2">
            <asp:TextBox ID="txtndoc" runat="server" Width="120"></asp:TextBox>
        </td>
        </tr>
</table>
                </fieldset>
   <fieldset>

    <table>
        <tr>
            <td>
                <asp:GridView ID="gvordencompra" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"  AutoGenerateColumns="False" OnRowCreated="griddata_RowCreated">
                    
                                     <Columns>
                                         
                                         <asp:BoundField DataField="OC_CNUMORD" HeaderText="N° DOCUMENTO" />
                                         <asp:BoundField DataField="OC_DFECDOC" HeaderText="FECHA" />
                                         <asp:BoundField DataField="OC_CRAZSOC" HeaderText="PROVEEDOR" />
                                         <asp:BoundField DataField="OC_CCODMON" HeaderText="MONEDA" />
                                         <asp:BoundField DataField="OC_NIMPMN" HeaderText="IMPORTE" ItemStyle-HorizontalAlign="Right" />
                                         <asp:BoundField DataField="OC_CSITORD" HeaderText="ESTADO" />
                                         <asp:BoundField DataField="OC_CTIPORD" HeaderText="TIPO" />
                                         <asp:BoundField DataField="OC_CCOTIZA" HeaderText="DOC REF" />
                                         <asp:TemplateField HeaderText="ANUL">
                                             <ItemTemplate>
                                                 <div class="btelmi" style="text-align:center">
                                                      <img alt="" src="../Images/desaprob.png" width="25" style="cursor:pointer"/>
                                                             <%--<asp:ImageButton ID="ib_editar" runat="server" ImageUrl="~/Images/Message_Error.png" Width="25px" OnClick="ib_editar_Click"  />--%>
                                                     </div>
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="MOD">
                                             <ItemTemplate>
                                                 <div class="btedita" style="text-align:center">
                                                     <img alt="" src="../Images/edicion02.png" width="25" style="cursor:pointer"/>
                                                 <%--<asp:ImageButton ID="imbeliminar" runat="server" ImageUrl="~/Images/Message_Error.png" Width="25px" OnClick="ib_eliminar_Click" onclientclick="javascript:return confirm('Esta Seguro?')"/>--%>
                                                     </div>
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="VER" >
                                             <ItemTemplate>
                                                 <div class ="ver" style="text-align:center">
                                                      <img alt="" src="../Images/Detalle.png" width="25" style="cursor:pointer"/>
                                                 </div>
                                             
                                             </ItemTemplate>
                                         </asp:TemplateField>

                                         <asp:TemplateField HeaderText="IMP" >
                                             <ItemTemplate>
                                                 <div class ="imprimi" style="text-align:center" > 
                                                      <img alt="" src="../Images/Printer.png" width="25" style="cursor:pointer"/>
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
       </fieldset>

    <div id="dvimprimeml" style="display:none">
        <table style="margin:0 auto;width:250px"> 
            <tr>
                <td class="auto-style2">Seleccione Area</td>
            </tr>
            <tr>
                <td style="text-align: center">
                    <asp:RadioButtonList ID="chkimp" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="L" Text="Logistica"> </asp:ListItem>
                        <asp:ListItem Value="M" Text="Mantenimiento" Selected="True"> </asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                </tr>
            <tr>
                <td class="auto-style2"><hr style="margin-right: 0" /></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center">
                    <input type="button" class="btimpr btn" value="IMPRIMIR" />
                </td>
            </tr>
        </table>
    </div>

    <div id="dvimprimeml2" style="display:none">
        <table style="margin:0 auto;width:250px"> 
            <tr>
                <td class="auto-style2">Seleccione Area</td>
            </tr>
            <tr>
                <td style="text-align: center">
                    <asp:RadioButtonList ID="chkimp2" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="P" Text="Produccion"> </asp:ListItem>
                        <asp:ListItem Value="V" Text="Proveedor" Selected="True"> </asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                </tr>
            <tr>
                <td class="auto-style2"><hr style="margin-right: 0" /></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center">
                    <input type="button" class="btimpr2 btn" value="IMPRIMIR" />
                </td>
            </tr>
        </table>
    </div>

        <div id="dvimprimileas" style="display:none">
        <table style="margin:0 auto;width:250px">
            <tr>
                <td class="auto-style2">Seleccione forma de Impresion</td>
            </tr>
            <tr>
                <td style="text-align: center">
                    <asp:RadioButtonList ID="rbsealea" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="S" Text="SEAFROST" Selected="True"> </asp:ListItem>
                        <asp:ListItem Value="L" Text="LEASING"> </asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                </tr>
            <tr>
                <td class="auto-style2"><hr style="margin-right: 0" /></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center">
                    <input type="button" class="btimpleasea btn" value="IMPRIMIR" />
                </td>
            </tr>
        </table>
    </div>

       <div id="dvdetalle" style="display:none">
       
        <table>
            <tr>
                <td>Orden Compra:
                </td>
                <td colspan="3">

                    <asp:TextBox ID="txtnumoc" runat="server" Width="100" ReadOnly="true" class="txtmost"  Enabled="false"></asp:TextBox>

                </td>
                <td>Fecha</td>
                <td>
                    <asp:TextBox ID="txtfecha" class="tcamb" runat="server" Width="130" placeholder="00/00/0000" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Proveedor:</td>
                    <td colspan="3">
                        <asp:TextBox ID="txtprovec" runat="server" Width="300"  Enabled="false"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtidproc" Enabled="false" runat="server" Width="100"></asp:TextBox>
                    </td>
                    <td>Fax:<asp:TextBox runat="server" ID="txtfax" Width="102px" Height="18px" Enabled="false"></asp:TextBox>
                    </td>


            </tr>
            <tr>
                <td>direccion</td>
                <td colspan="3">

                    <asp:TextBox ID="txtdire" runat="server" Width="300"  Enabled="false"></asp:TextBox>

                </td>
                <td>Tipo Despacho</td>
                <td>
                    <asp:DropDownList ID="ddltdespa" runat="server" Width="130"   Enabled="false"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Doc Referencia:</td>
                  <td class="auto-style1">
                        <asp:DropDownList ID="ddldocre" runat="server" Width="130" Enabled="false"></asp:DropDownList>
                    </td>
                <td>

                    <asp:TextBox ID="txtnumref" runat="server" Width="161px"  Enabled="false"></asp:TextBox>

                </td>
                <td></td>
                <td>N° Doc Ref.02</td>
                <td>

                    <asp:TextBox ID="txtref2" runat="server" Width="130"  Enabled="false"></asp:TextBox>

                </td>
            </tr>
            <tr>
                  <td>Moneda:</td>
                    <td class="auto-style1">
                        <asp:DropDownList ID="ddlmone" runat="server" Width="130" Enabled="false"></asp:DropDownList>
                    </td>
                <td></td>
                <td></td>

                <td>Tipo O/C:</td>
                <td>
                    <asp:DropDownList ID="ddltipoc" runat="server" Width="130"   Enabled="false"></asp:DropDownList>
                </td>
                <%--<asp:ImageButton ID="imbeliminar" runat="server" ImageUrl="~/Images/Message_Error.png" Width="25px" OnClick="ib_eliminar_Click" onclientclick="javascript:return confirm('Esta Seguro?')"/>--%>
            </tr>
            <tr>
                <td>Forma Pago:</td>
                <td colspan="3">
                    <asp:TextBox ID="ddlfpago" runat="server" Width="292px"  Enabled="false"></asp:TextBox> 
                </td>

                <td>Tipo Cambio</td>
                <td>
                    <asp:TextBox ID="txttcambio" runat="server" Width="130"  Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Fecha al:</td>
                <td>
                    <asp:TextBox ID="txtfechax" runat="server" Width="130" placeholder="00/00/0000"  Enabled="false"></asp:TextBox>
                </td>

                <td colspan="2">Dscto Fina.
                 <asp:TextBox ID="txtdfina" runat="server" Width="92px"  Enabled="false"></asp:TextBox>
                </td>
                <td>Pais
                </td>
                <td>
                    <asp:TextBox ID="lblpais" runat="server" Width="129px"  Enabled="false"></asp:TextBox>
                
                </td>
            </tr>

        </table>
        <hr />
        <table>
            <tr>
                <td>Solicitante:</td>
                <td colspan="6">
                    <asp:TextBox ID="txtidsoli" runat="server" Width="100"  Enabled="false"></asp:TextBox>


                    <asp:TextBox ID="txtsoli" runat="server" Width="300"  Enabled="false"></asp:TextBox>

                </td>

            </tr>
            <tr>
              <td>Centro Costo:</td>
                    <td colspan="6">
                        <asp:TextBox runat="server" ID="txtcodcos" Width="100"  Enabled="false"></asp:TextBox>

                        <asp:TextBox runat="server" ID="ddlccost" Width="300"  Enabled="false"></asp:TextBox>
                    </td>


            </tr>
            <tr>
                <td>Tipo Envio </td>
                <td colspan="2">
                    <asp:TextBox ID="txtenvio" runat="server" Width="300"  Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Almacen:</td>
                <td colspan="2">

                    <asp:TextBox ID="txtalma" runat="server" Width="300"  Enabled="false"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td>Lugar Entrega:</td>
                <td colspan="2">
                    <asp:TextBox ID="txtlentre" runat="server" Width="300"  Enabled="false"></asp:TextBox>
                </td>
                <td>Distri.:</td>
                <td>
                    <asp:TextBox ID="txtdist" runat="server" Width="100"  Enabled="false"></asp:TextBox>
                </td>
                <td>Provinc:</td>
                <td>
                    <asp:TextBox ID="txtprov" runat="server" Width="100"  Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Lugar Factura </td>
                <td colspan="2">
                    <asp:TextBox ID="txtlugarf" runat="server" Width="300"  Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Observaciones:</td>
                <td colspan="6">
                    <asp:TextBox TextMode="MultiLine" Rows="2" runat="server" ID="txtobs" Width="595" MaxLength="80"   Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Remite:</td>
                <td colspan="1">
                    <asp:TextBox ID="txtremi" runat="server" Width="180"  Enabled="false"></asp:TextBox>
                </td>
                <td>Persona Atencion:</td>
                <td colspan="4">
                    <asp:TextBox ID="txtaten" runat="server" Width="180"  Enabled="false"></asp:TextBox>
                </td>
            </tr>

         </table>
         <fieldset style="background-color: #99CCFF">

             <table>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" Font-Size="Smaller">
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

  </fieldset>


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
</asp:Content>

