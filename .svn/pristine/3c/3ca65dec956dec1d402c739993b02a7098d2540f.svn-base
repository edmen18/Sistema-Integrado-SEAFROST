<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="OCaprobacion.aspx.cs" Inherits="Default2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">


    <script type="text/javascript">
        $(function () {
            $("#MainContent_txtfecha2").datepicker();
            $("#MainContent_txtfecha1").datepicker();
            

            $("#MainContent_txtprove").autocomplete(
                     {
                         source: function (request, response) {
                             $.ajax({
                                 url: "OCaprobacion.aspx/GetProveedores",
                                 data: "{ 'productos': '" + request.term + "' }",
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

            $(".btbuscar").click(function () {
                filtarocomprapopup();
            });

            $(".btedita").click(function () {
                var trp = $(this).parent().parent();
                idnumoc = $("td:eq(0)", trp).html();
                variableServidor = idnumoc;
                window.location.assign("\OCnueva.aspx?" + variableServidor);

            });

            $(".btapro").click(function () {
                trp = $(this).parent().parent();
                idnumoc = $("td:eq(0)", trp).html();

                //USUARIO  S
                trp18 = $(this).parent().parent();
                usu1 = $("td:eq(11)", trp18).html();

                trp19 = $(this).parent().parent();
                usu2 = $("td:eq(12)", trp19).html();

                trp20 = $(this).parent().parent();
                usu3 = $("td:eq(13)", trp20).html();
                
                var estadooc = $("td:eq(14)", trp).val();
                var acceso = $('#MainContent_lblacceso').html();
                

                if (acceso != "0")
                {

               if (estadooc != "1" && estadooc != "2") {
                    alert("La orden de Compra No se Puede Aprobar, Se Encuentra en Estado: " + estadooc);
                } else {
                    if (confirm("Desea Aprobar la Orden de Compra: " + idnumoc)) {
                        aprobaroc(idnumoc, "2",usu1,usu2,usu3);
                    }
                }

                }
                else {
                    alert("Ud. no tiene permisos para realizar esta operacion");
                    }


            });


            $(".btdesapro").click(function () {
                trp = $(this).parent().parent();
                idnumoc = $("td:eq(0)", trp).html();

                //USUARIO  S
                trp18 = $(this).parent().parent();
                usu1 = $("td:eq(11)", trp18).html();

                trp19 = $(this).parent().parent();
                usu2 = $("td:eq(12)", trp19).html();

                trp20 = $(this).parent().parent();
                usu3 = $("td:eq(13)", trp20).html();

              //  MostrarunRegistro(idnumoc);

                var estadooc = $("td:eq(14)", trp).val();


                var acceso = $('#MainContent_lblacceso').html();
                
               if (acceso != "0")
                {
                    if (estadooc = "2")
                    {
                        if (confirm("Desea Desaprobar la Orden de Compra: " + idnumoc))
                        {
                        aprobaroc(idnumoc, "1", usu1, usu2, usu3);
                        }
                }

                else
                {
                    alert("La orden de Compra No se Puede Desaprobar, Se Encuentra en Estado: " + estadooc);

                }
                }
                else {
                    alert("Ud. no tiene permisos para realizar esta operacion");
                }
            });

               $(".btadd").click(function () { //  se debe colocar dentrp de una funcion 
                $("#dvdetalle").dialog('open');
                //extraer el numero orden
                trp = $(this).parent().parent();
                idnumoc = $("td:eq(0)", trp).html();
                $("#MainContent_txtnumoc").val(idnumoc);

                // extraer datos proveedor
                trp1 = $(this).parent().parent();
                ruc = $("td:eq(0)", trp1).val();
                $("#MainContent_txtruc").val(ruc)

                trp2 = $(this).parent().parent();
                direccion = $("td:eq(1)", trp2).val();
                $("#MainContent_txtdire").val(direccion)

                trp3 = $(this).parent().parent();
                razon = $("td:eq(2)", trp3).html();
                $("#MainContent_txtproveedor").val(razon)

                // extraer fecha
                trp4 = $(this).parent().parent();
                fecha = $("td:eq(1)", trp4).html();
                $("#MainContent_txtfecha").val(fecha);

                // extraer pais
                trp5 = $(this).parent().parent();
                pais = $("td:eq(8)", trp5).html();
                $("#MainContent_lblpais").val(pais);
                //EXTRAER FPAGO
                trp6 = $(this).parent().parent();
                fpago= $("td:eq(9)", trp6).html();
                $("#MainContent_ddlfpago").val(fpago);

                trp7 = $(this).parent().parent();
                envio = $("td:eq(10)", trp7).html();
                $("#MainContent_txtenvio").val(envio);

                trp8 = $(this).parent().parent();
                lentrega = $("td:eq(2)", trp8).val();
                $("#MainContent_txtlentre").val(lentrega);

                trp9 = $(this).parent().parent();
                lfactura = $("td:eq(3)", trp9).val();
                $("#MainContent_txtlugarf").val(lfactura);

                trp10 = $(this).parent().parent();
                distrito = $("td:eq(4)", trp10).val();
                $("#MainContent_txtdist").val(distrito);

                trp11 = $(this).parent().parent();
                provincia = $("td:eq(5)", trp11).val();
                $("#MainContent_txtprov").val(provincia);

                trp12 = $(this).parent().parent();
                cambio = $("td:eq(6)", trp12).val();
                $("#MainContent_txttcambio").val(cambio);

                trp13 = $(this).parent().parent();
                codsol = $("td:eq(7)", trp13).val();
                $("#MainContent_txtidsoli").val(codsol);

                trp14 = $(this).parent().parent();
                solicitante = $("td:eq(8)", trp14).val();
                $("#MainContent_txtsoli").val(solicitante);

                trp15 = $(this).parent().parent();
                remite = $("td:eq(9)", trp15).val();
                $("#MainContent_txtremi").val(remite);

                trp16 = $(this).parent().parent();
                persona = $("td:eq(10)", trp16).val();
                $("#MainContent_txtaten").val(persona);


                trp17 = $(this).parent().parent();
                req = $("td:eq(7)", trp17).html();
                $("#MainContent_txtnumref").val(req);


                trp18 = $(this).parent().parent();
                observaciones = $("td:eq(11)", trp18).val();
                $("#MainContent_txtobs").val(observaciones);


                trp19 = $(this).parent().parent();
                moneda = $("td:eq(12)", trp19).val();
                $("#MainContent_txtmoneda").val(moneda);
               
                trp50 = $(this).parent().parent();
                centrocosto = $("td:eq(13)", trp50).val();
                $("#MainContent_txtcost").val(centrocosto);
                  
                trp20 = $(this).parent().parent();
                almacen = $("td:eq(15)", trp20).val();
                $("#MainContent_txtalma").val(almacen);
                
                trp21 = $(this).parent().parent();
                referencia = $("td:eq(16)", trp21).val();
                $("#MainContent_txtref").val(referencia);
             
                   
                filtarListocompra();
            });
               $(".btaddgrilladetalle").click(function () { //  se debe colocar dentrp de una funcion 
                   $("#dvdetalle").dialog('open');
                   filtarListocompra()


               });
                       


            /// para mostrar div
            $('#dvdetalle').dialog({
                autoOpen: false,
                modal: true,
                resizable: true,
                width: 950,
                heigth: 100,
                title: 'Detalle',
                close: function (event, ui) {
                },
            }
             );

           

            function aprobaroc(idnumoc, indice,usu1,usu2,usu3) {
                var idnumd = idnumoc;
                var COAPRUEBA = {};
              //  var f = new Date();
               // filtarfechasocpopup(idnumoc);
                COAPRUEBA.OC_CNUMORD = idnumd;
                COAPRUEBA.OC_CSITORD = indice;
                var user = {};
                user = $("#MainContent_lblusuario").html();
                COAPRUEBA.OC_CUSEA01 = usu1;
                COAPRUEBA.OC_CUSEA02 = usu2;
                COAPRUEBA.OC_CUSEA03 = usu3;
                   
                if (indice == "2") {

                    if (usu1 == "     " && usu2 == "     " && usu3 == "     ") {
                        COAPRUEBA.OC_CUSEA01 = user;
                        COAPRUEBA.OC_CUSEA02 = usu2;
                        COAPRUEBA.OC_CUSEA03 = usu3;
                     }

                    if (usu1 != "     " && usu2 == "     " && usu3 == "     ") {
                        COAPRUEBA.OC_CUSEA02 = user;
                        COAPRUEBA.OC_CUSEA01 = usu1;
                        COAPRUEBA.OC_CUSEA03 = usu3;
                    }
                    if (usu2 != "     " && usu1 != "     " && usu3 == "     ") {
                        COAPRUEBA.OC_CUSEA03 = user;
                        COAPRUEBA.OC_CUSEA02 = usu2;
                        COAPRUEBA.OC_CUSEA01 = usu1;
                    }

                    if (usu2 != "     " && usu1 != "     " && usu3 != "     ") {
                        alert("La Orden de Compra ya fue aprobada")
                    }
                }
                else {

                    //COAPRUEBA.OC_CUSEA03 = "     ";
                    //COAPRUEBA.OC_CUSEA02 = "     ";
                    //COAPRUEBA.OC_CUSEA01 = "     ";
                }
                    $.ajax({

                        type: "POST",
                        url: "OCaprobacion.aspx/aprobaroc",
                        data: '{COAPRUEBA: ' + JSON.stringify(COAPRUEBA) + '}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {
                            alert("La operación completada correctamente")
                            filtarocomprapopup()
                                                    },
                        error: function (response) {
                        }
                    });

                             

            }

            /// nuevo codigo edgar

            $(window).load(function () {
                contarndw = 0;
                cc = 1;
                sw_edicion = 0;
                sw_nuevo = 0;
                contaditem = 0;

            });


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



            function filtarListocompra() {
               var LDE = {};
                LDE.OC_CNUMORD = $("#MainContent_txtnumoc").val();
                $.ajax({
                    type: "POST",
                    url: "OCaprobacion.aspx/GetListaDetalle",
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
                                $("[id*=GridView1]").append(row);
                                row = $("[id*=GridView1] tr:last-child").clone(true);

                            }

                            var sub01 = recorregrid().sumasub; var des01 = recorregrid().sumadesc;
                            var igv01 = recorregrid().sumaigvv; var tot01 = recorregrid().sumatotall;

                            $("#MainContent_txttbrutof").val(sub01.toFixed(2));
                            $("#MainContent_txtdescf").val(des01.toFixed(2));
                            $("#MainContent_txtigvf").val(igv01.toFixed(2));
                            $("#MainContent_txtnetof").val(tot01.toFixed(2));

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
            function filtarocomprapopup() {
                var fec1 = moment($("#MainContent_txtfecha1").val(), "DD/MM/YYYY");
                fec1 = new Date(fec1);
                var fec2 = moment($("#MainContent_txtfecha2").val(), "DD/MM/YYYY");
                fec2 = new Date(fec2);
                var VC = {};
                VC.OC_CSITORD = $("#MainContent_ddlestad option:selected").val();
                VC.OC_CTIPORD = $("#MainContent_ddltipo option:selected").val();
                VC.OC_DFECDOC = fec1;
                VC.OC_DFECENT = fec2;
                VC.OC_CCODPRO = $("#MainContent_txtidpro").val();

                $.ajax({

                    type: "POST",
                    url: "OCaprobacion.aspx/ListarCabOCpopup",
                    data: '{VC: ' + JSON.stringify(VC) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        if (data.d.length > 0) {
                            var row = $("[id*=gvordencompra] tr:last-child").clone(true);
                            $("[id*=gvordencompra] tr").not($("[id*=gvordencompra] tr:first-child")).remove();

                            for (var i = 0; i < data.d.length; i++) {

                                $("td", row).eq(0).html(data.d[i].OC_CNUMORD);
                                $("td", row).eq(0).val(data.d[i].OC_CCODPRO);
                                $("td", row).eq(1).html(data.d[i].OC_DFECDOC);
                                $("td", row).eq(1).val(data.d[i].OC_CDIRPRO);
                                $("td", row).eq(2).html(data.d[i].OC_CRAZSOC);
                                $("td", row).eq(2).val(data.d[i].OC_CLUGENT);
                                $("td", row).eq(3).html(data.d[i].OC_CCODMON);
                                $("td", row).eq(3).val(data.d[i].OC_CLUGFAC);
                                $("td", row).eq(4).html(data.d[i].OC_NIMPMN);
                                $("td", row).eq(4).val(data.d[i].OC_CDISTOC)
                                $("td", row).eq(5).html(data.d[i].OC_CTIPORD);
                                $("td", row).eq(5).val(data.d[i].OC_CPROVOC);
                                $("td", row).eq(6).html(data.d[i].OC_CSITORD);
                                $("td", row).eq(6).val(data.d[i].OC_NTIPCAM);
                                $("td", row).eq(7).html(data.d[i].OC_CCOTIZA);
                                $("td", row).eq(7).val(data.d[i].OC_CODSOL);
                                $("td", row).eq(8).html(data.d[i].OC_CCOPAIS);
                                $("td", row).eq(8).val(data.d[i].OC_CSOLICIT);
                                $("td", row).eq(9).html(data.d[i].OC_CFORPA1);
                                $("td", row).eq(9).val(data.d[i].OC_CREMITE);
                                $("td", row).eq(10).html(data.d[i].OC_CTIPENV);
                                $("td", row).eq(10).val(data.d[i].OC_CPERATE);
                                $("td", row).eq(11).html(data.d[i].OC_CUSEA01);
                                $("td", row).eq(11).val(data.d[i].OC_CDETENT);
                                $("td", row).eq(12).html(data.d[i].OC_CUSEA02);
                                $("td", row).eq(12).val(data.d[i].MONEDA);
                                $("td", row).eq(13).html(data.d[i].OC_CUSEA03);
                                $("td", row).eq(13).val(data.d[i].CENTROCOSTO);
                                $("td", row).eq(14).val(data.d[i].situanum);
                                $("td", row).eq(15).val(data.d[i].ALMACEN);
                                $("td", row).eq(16).val(data.d[i].REFERENCIA);
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
                            $("td", row).eq(8).html("");
                            $("td", row).eq(9).html("");
                            $("td", row).eq(10).html("");
                            $("td", row).eq(0).val("");
                            $("td", row).eq(1).val("");
                            $("td", row).eq(2).val("");
                            $("td", row).eq(3).val("");
                            $("td", row).eq(4).val("");
                            $("td", row).eq(5).val("");
                            $("td", row).eq(6).val("");
                            $("td", row).eq(7).val("");
                            $("td", row).eq(8).val("");
                            $("td", row).eq(9).val("");
                            $("td", row).eq(10).val("");
                            $("td", row).eq(11).html("");
                            $("td", row).eq(12).html("");
                            $("td", row).eq(13).html("");
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
                                
        });

      
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <fieldset style="background-color: #99CCFF">
        <legend style="font-weight: bold; background-color: #99CCFF;">
            <asp:Label ID="Label9" runat="server" Text="MANTENIMIENTO DE ORDEN DE COMPRA" Font-Bold="True" Font-Size="12pt"></asp:Label></legend>

        <table>
            <tr>
                <td>Proveedor</td>
                <td colspan="3">
                    <asp:TextBox ID="txtprove" runat="server" Width="300"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtidpro" Enabled="false" runat="server" Width="100"></asp:TextBox>
                </td>
                <td>Fecha:</td>
                <td>
                    <asp:TextBox ID="txtfecha1" runat="server" Width="80"></asp:TextBox>
                </td>
                <td>Fecha al:</td>
                <td>
                    <asp:TextBox ID="txtfecha2" runat="server" Width="80"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblacceso" runat="server" ForeColor="#66CCFF"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Estado:</td>
                <td>
                    <asp:DropDownList ID="ddlestad" runat="server" Width="130"></asp:DropDownList>
                </td>
                <td>Tipo:</td>
                <td>
                    <asp:DropDownList ID="ddltipo" runat="server" Width="130"></asp:DropDownList>
                </td>
                <td>
                    <input class="btbuscar" value="Buscar" type="button" style="width: 80px" />
                    <asp:Label ID="lblusuario" runat="server" ForeColor="#66CCFF"></asp:Label>
                </td>
            </tr>
        </table>
    </fieldset>


    <table>
        <tr>
            <td>
                <asp:GridView ID="gvordencompra" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="OC_CNUMORD" HeaderText="N° DOCUMENTO" />
                        <asp:BoundField DataField="OC_DFECDOC" HeaderText="FECHA" />
                        <asp:BoundField DataField="OC_CRAZSOC" HeaderText="PROVEEDOR" />
                        <asp:BoundField DataField="OC_CCODMON" HeaderText="MONEDA" />
                        <asp:BoundField DataField="OC_NIMPMN" HeaderText="IMPORTE" />
                        <asp:BoundField DataField="OC_CSITORD" HeaderText="ESTADO" />
                        <asp:BoundField DataField="OC_CTIPORD" HeaderText="TIPO" />
                        <asp:BoundField DataField="OC_CCOTIZA" HeaderText="COTIZA" />
                        <asp:BoundField DataField="OC_CCOPAIS" HeaderText="PAIS" />
                        <asp:BoundField DataField="OC_CFORPA1" HeaderText="FPAGO" />
                        <asp:BoundField DataField="OC_CTIPENV" HeaderText="TIPO ENVIO" />
                        <asp:BoundField DataField="OC_CUSEA01" HeaderText="USER1" />
                        <asp:BoundField DataField="OC_CUSEA02" HeaderText="USER2" />
                        <asp:BoundField DataField="OC_CUSEA03" HeaderText="USER3" />
                        <asp:TemplateField HeaderText="APROBAR">
                            <ItemTemplate>
                                <div class="btapro" style="text-align: center">
                                    <img alt="" src="../Images/valid.png" width="25" style="cursor: pointer" />
                                    <%--<asp:ImageButton ID="ib_editar" runat="server" ImageUrl="~/Images/Message_Error.png" Width="25px" OnClick="ib_editar_Click"  />--%>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DESAPROBAR">
                            <ItemTemplate>
                                <div class="btdesapro" style="text-align: center">
                                    <img alt="" src="../Images/Message_Error.png" width="25" style="cursor: pointer" />
                                </div>

                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="VISUALIZAR">
                            <ItemTemplate>
                                <div class="btadd" style="text-align: center">
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

            </td>
        </tr>

    </table>

    <div id="dvdetalle">
        <%--<asp:ImageButton ID="imbeliminar" runat="server" ImageUrl="~/Images/Message_Error.png" Width="25px" OnClick="ib_eliminar_Click" onclientclick="javascript:return confirm('Esta Seguro?')"/>--%>
        <table>
            <tr>
                <td>Orden Compra:
                </td>
                <td colspan="3">

                    <asp:TextBox ID="txtnumoc" runat="server" Width="100" ReadOnly="true" class="txtmost"></asp:TextBox>

                </td>
                <td>Fecha</td>
                <td>
                    <asp:TextBox ID="txtfecha" class="tcamb" runat="server" Width="130" placeholder="00/00/0000"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Proveedor:</td>
                <td colspan="3">
                    <asp:TextBox ID="txtproveedor" runat="server" Width="300"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtruc" Enabled="false" runat="server" Width="100"></asp:TextBox>
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

                    <asp:TextBox ID="txtref" runat="server" Width="161px"></asp:TextBox>

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

                    <asp:TextBox ID="txtmoneda" runat="server" Width="161px"></asp:TextBox>

                </td>
                <td></td>
                <td></td>

                <td>Tipo O/C:</td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="130"></asp:DropDownList>
                </td>
                <%--<asp:ImageButton ID="imbeliminar" runat="server" ImageUrl="~/Images/Message_Error.png" Width="25px" OnClick="ib_eliminar_Click" onclientclick="javascript:return confirm('Esta Seguro?')"/>--%>
            </tr>
            <tr>
                <td>Forma Pago:</td>
                <td colspan="3">
                    <asp:TextBox ID="ddlfpago" runat="server" Width="292px"></asp:TextBox> 
                </td>

                <td>Tipo Cambio</td>
                <td>
                    <asp:TextBox ID="txttcambio" runat="server" Width="130"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Fecha al:</td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server" Width="130" placeholder="00/00/0000"></asp:TextBox>
                </td>

                <td colspan="2">Dscto Fina.
                 <asp:TextBox ID="txtdfina" runat="server" Width="92px"></asp:TextBox>
                </td>
                <td>Pais
                </td>
                <td>
                    <asp:TextBox ID="lblpais" runat="server" Width="129px"></asp:TextBox>
                
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

                    <asp:TextBox runat="server" ID="txtcost" Width="399px"></asp:TextBox>
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

                    <asp:TextBox ID="txtalma" runat="server" Width="300"></asp:TextBox>

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


