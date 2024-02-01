<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CartasIS.aspx.cs" Inherits="Default2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
 


    <script type="text/javascript">
        $(function () {
            $("#MainContent_txtfecha2").datepicker();
            $("#MainContent_txtfecha1").datepicker();
            $("#MainContent_txtfinspeccion").datepicker();
            $("#MainContent_txtfechaemision").datepicker();
            $("#MainContent_txttipoanalisis").autocomplete(
                    {
                        source: function (request, response) {
                            $.ajax({
                                url: "CartasIS.aspx/GETTA",
                                data: "{ 'CLAVE': '" + request.term + "' }",
                                dataType: "json",
                                type: "POST",
                                contentType: "application/json; charset=utf-8",
                                dataFilter: function (data) { return data; },
                                success: function (data) {
                                    response($.map(data.d, function (item) {
                                        return {
                                            value: item.TA_DESCRIPCION,
                                            id: item.TA_CODIGO,
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
                            $('#MainContent_lblta').html(str);


                        }
                    });
            $("#MainContent_txtcertificado").autocomplete(
        {
            source: function (request, response) {
                $.ajax({
                    url: "CartasIS.aspx/GETTC",
                    data: "{ 'CLAVE': '" + request.term + "' }",
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataFilter: function (data) { return data; },
                    success: function (data) {
                        response($.map(data.d, function (item) {
                            return {
                                value: item.TC_DESCRIPCION,
                                id: item.TC_CODIGO,

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
               $('#MainContent_lblcertificado').html(str);


            }
        });

            $("#MainContent_txtproducto").autocomplete(
        {
        source: function (request, response) {
        $.ajax({
            url: "CartasIS.aspx/GETPRODUCTO",
            data: "{ 'CLAVE': '" + request.term + "' }",
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataFilter: function (data) { return data; },
            success: function (data) {
                response($.map(data.d, function (item) {
                    return {
                        value: item.PR_DESCRIPCION,
                        id: item.PR_CODIGO,

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
        $('#MainContent_lblproducto').html(str);


    }
        });


            $("#MainContent_txtenvase").autocomplete(
        {
            source: function (request, response) {
                $.ajax({
                    url: "CartasIS.aspx/GETENVASE",
                    data: "{ 'CLAVE': '" + request.term + "' }",
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataFilter: function (data) { return data; },
                    success: function (data) {
                        response($.map(data.d, function (item) {
                            return {
                                value: item.ENV_DESCRIPCION,
                                id: item.ENV_CODIGO,

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
                $('#MainContent_lblenvase').html(str);


            }
        });
            $("#MainContent_txtdestino").autocomplete(
{
    source: function (request, response) {
        $.ajax({
            url: "CartasIS.aspx/GETDESTINO",
            data: "{ 'CLAVE': '" + request.term + "' }",
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataFilter: function (data) { return data; },
            success: function (data) {
                response($.map(data.d, function (item) {
                    return {
                        value: item.DST_DESCRIPCION,
                        id: item.DST_CODIGO,

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
        $('#MainContent_lbldestino').html(str);


    }
});
            $("#MainContent_txtpara").autocomplete(
         {
             source: function (request, response) {
                 $.ajax({
                     url: "CartasIS.aspx/GetProveedores",
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
                 $('#MainContent_lblpara').html(str);


             }
         });


            $(".btnnuevo").click(function () { //  se debe colocar dentrp de una funcion 
                $("#dvdetalle").dialog('open');
                $("#MainContent_txtde").val("");
                $("#MainContent_lblpara").html("");
                $("#MainContent_txtpara").val("");
                $("#MainContent_lblta").html("");
                $("#MainContent_txttipoanalisis").val("");
                $("#MainContent_txtfechaemision").val("00/00/0000");
                $("#MainContent_txtcertificado").val("");
                $("#MainContent_txtorden").val("");
                $("#MainContent_lblcertificado").html("");
                $("#MainContent_txtproductor").val("");
                $("#MainContent_txthabilitacion").val("");
                $("#MainContent_txtproducto").val("");
                $("#MainContent_lblproducto").html("");
                $("#MainContent_txtenvase").val("");
                $("#MainContent_txtlotes").val("");
                $("#MainContent_txtespecificacion").val("");
                $("#MainContent_lbldestino").html("");
                $("#MainContent_lblenvase").html("");
                $("#MainContent_txtdestino").val("");
                $("#MainContent_txtlugar").val("");
                $("#MainContent_txtfinspeccion").val("00/00/0000");
                $("#MainContent_txtcc").val("");
                $("#MainContent_txtindicador").val("G");
                var ultimodato = generar().contador;
                var formato = ultimodato.length < 4 ? pad("0" + ultimodato, 4) : ultimodato;
                $("#MainContent_lblcarta").html(formato);

            });


            function generar() {
                var solicitud = "";
                var contador = "";

                $.ajax({

                    type: "POST",
                    url: "CartasIS.aspx/GENERAR",
                    data: "{solicitud: '" + solicitud + "'}",
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
            function pad(str, max) {
                if (str != undefined) {
                    str = str.toString();
                    return str.length < max ? pad("0" + str, max) : str;
                }
            }


            $(".LISTAR").click(function () { 
                filtarsolicitudes();
            });

            $('#dvdetalle').dialog({
                autoOpen: false,
                modal: true,
                resizable: true,
                width: 550,
                heigth: 100,
                title: 'Registro',
                close: function (event, ui) {
                    //limpiardatos();
                    filtarsolicitudes();
                },
            });

            function filtarsolicitudes() {
                var fec1 = moment($("#MainContent_txtfecha1").val(), "DD/MM/YYYY");
                fec1 = new Date(fec1);
                var fec2 = moment($("#MainContent_txtfecha2").val(), "DD/MM/YYYY");
                fec2 = new Date(fec2);
                var VC = {};
                VC.FECHA = fec1;
                VC.FECHA_INSPECCION = fec2;
                    $.ajax({
                    type: "POST",
                    url: "CartasIS.aspx/ListarSolicitudes",
                    data: '{VC: ' + JSON.stringify(VC) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        if (data.d.length > 0) {
                            var row = $("[id*=gvordencompra] tr:last-child").clone(true);
                            $("[id*=gvordencompra] tr").not($("[id*=gvordencompra] tr:first-child")).remove();

                            for (var i = 0; i < data.d.length; i++) {
                                $("td", row).eq(0).html(data.d[i].NUM_CARTA);
                                $("td", row).eq(1).html(data.d[i].ORDEN_TRABAJO);
                                $("td", row).eq(2).html(data.d[i].RAZONSOCIAL);
                                $("td", row).eq(2).val(data.d[i].PARA);
                                $("td", row).eq(3).html(data.d[i].DE);
                                $("td", row).eq(4).html(data.d[i].FECHA_E);
                                $("td", row).eq(5).html(data.d[i].TA_DESCRIPCION);
                                $("td", row).eq(5).val(data.d[i].TIPO_ANALISIS);
                                $("td", row).eq(6).html(data.d[i].TC_DESCRIPCION);
                                $("td", row).eq(6).val(data.d[i].TIPO_CERTIFICADO);
                                $("td", row).eq(7).html(data.d[i].HABILITACION);
                                $("td", row).eq(8).val(data.d[i].PRODUCTO);
                                $("td", row).eq(8).html(data.d[i].PR_DESCRIPCION);
                                $("td", row).eq(9).html(data.d[i].ESPECIFICACION_INTERNA);
                                $("td", row).eq(10).html(data.d[i].DST_DESCRIPCION);
                                $("td", row).eq(10).val(data.d[i].DESTINO);
                                $("td", row).eq(11).html(data.d[i].LUGAR);
                                $("td", row).eq(12).html(data.d[i].FECHA_I);
                                $("[id*=gvordencompra]").append(row);
                                row = $("[id*=gvordencompra] tr:last-child").clone(true);
                            }
                        } else {
                            var row = $("[id*=gvordencompra] tr:last-child").clone(true);
                            $("[id*=gvordencompra] tr").not($("[id*=gvordencompra] tr:first-child")).remove();

                            $("td", row).eq(0).html("");
                            $("td", row).eq(1).html("");
                            $("td", row).eq(0).val("");
                            $("td", row).eq(1).val("");

                            $("td", row).eq(2).html("");
                            $("td", row).eq(3).html("");
                            $("td", row).eq(4).html("");
                            $("td", row).eq(5).html("");
                            $("td", row).eq(6).html("");
                            $("td", row).eq(6).val("");
                            $("td", row).eq(7).html("");
                            $("td", row).eq(8).html("");
                            $("td", row).eq(9).html("");
                            $("td", row).eq(10).html("");
                            $("td", row).eq(11).html("");
                            $("td", row).eq(12).html("");
                            $("td", row).eq(7).val("");
                            $("td", row).eq(8).val("");
                            $("td", row).eq(9).val("");
                            $("td", row).eq(10).val("");
                            $("td", row).eq(11).val("");
                            $("td", row).eq(12).val("");
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
            $(".btgrabar").click(function () { 
              
                    InsertarSolicitud();
            });

            function InsertarSolicitud() {

                var fecemi = moment($("#MainContent_txtfechaemision").val(), "DD/MM/YYYY");
                fecemi = fecemi == null ? null : new Date(fecemi);
                var fecpro = moment($("#MainContent_txtfinspeccion").val(), "DD/MM/YYYY");
                fecpro = fecpro == null ? null : new Date(fecpro);
                var DETA = {};
                DETA.NUM_CARTA = $("#MainContent_lblcarta").html();
                DETA.PARA = $("#MainContent_lblpara").html();
                DETA.RAZONSOCIAL = $("#MainContent_txtpara").val();
                DETA.DE = $("#MainContent_txtde").val();
                DETA.FECHA = fecemi;
                DETA.ORDEN_TRABAJO = $("#MainContent_txtorden").val();
                DETA.TIPO_ANALISIS = $("#MainContent_lblta").html();
                DETA.TIPO_CERTIFICADO = $("#MainContent_lblcertificado").html();
                DETA.PRODUCTOR = $("#MainContent_txtproductor").val();
                DETA.HABILITACION = $("#MainContent_txthabilitacion").val();
                DETA.PRODUCTO = $("#MainContent_lblproducto").html();
                DETA.ENVASE = $("#MainContent_lblenvase").html();
                DETA.LOTES = $("#MainContent_txtlotes").val();
                DETA.ESPECIFICACION_INTERNA = $("#MainContent_txtespecificacion").val();
                DETA.DESTINO = $("#MainContent_lbldestino").html();
                DETA.LUGAR= $("#MainContent_txtlugar").val();
                DETA.FECHA_INSPECCION = fecpro;
                DETA.CC = $("#MainContent_txtcc").val();
                document.getElementById("btngrabar").style.visibility = "visible";

                // ||


                if ((DETA.NUM_CARTA == "") ||
                    (DETA.PARA == "") ||
                (DETA.RAZONSOCIAL =="") ||
                (DETA.DE =="") ||
                (DETA.FECHA == "") ||
                (DETA.ORDEN_TRABAJO =="") ||
                (DETA.TIPO_ANALISIS == "") ||
               (DETA.TIPO_CERTIFICADO == "") ||
                (DETA.PRODUCTOR == "") ||
                (DETA.HABILITACION == "") ||
                (DETA.PRODUCTO == "") ||
                (DETA.ENVASE == "")  || 
                (DETA.LOTES == "") ||
                (DETA.ESPECIFICACION_INTERNA == "") ||
                (DETA.DESTINO =="") ||
                (DETA.LUGAR== "") ||
                (DETA.FECHA_INSPECCION == "") ||
                (DETA.CC == "")) {

                    alert(      DETA.NUM_CARTA +" NC "+
                    DETA.PARA +" NC "+
                    DETA.RAZONSOCIAL +" NC "+
                    DETA.DE +" NC "+
                    DETA.FECHA +" NC "+
                    DETA.ORDEN_TRABAJO +" NC "+
                    DETA.TIPO_ANALISIS +" NC "+
                    DETA.TIPO_CERTIFICADO +" NC "+
                    DETA.PRODUCTOR +" NC "+
                    DETA.HABILITACION +" NC "+
                    DETA.PRODUCTO +" NC "+
                    DETA.ENVASE +" NC "+
                    DETA.LOTES +" NC "+
                    DETA.ESPECIFICACION_INTERNA +" NC "+
                    DETA.DESTINO +" NC "+
                    DETA.LUGAR+" NC "+
                    DETA.FECHA_INSPECCION+" NC "+
                    DETA.CC+" NC ");

                }
                else {

                    if ($("#MainContent_txtindicador").val() == "G") {
                        $.ajax({

                            type: "POST",
                            url: "CartasIS.aspx/InsertaDet",
                            data: '{DETA: ' + JSON.stringify(DETA) + '}',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            //async: false,
                            success: function (response) {
                                alert("Registro Grabado");
                                $("#dvdetalle").dialog('close');
                            },
                            error: function (response) {
                                if (response.length != 0)
                                 console.table(response);
                            }

                        });

                    }

                    if ($("#MainContent_txtindicador").val() == "A") {

                        $.ajax({

                            type: "POST",
                            url: "CartasIS.aspx/ActualizaAnticipo",
                            data: '{DETA: ' + JSON.stringify(DETA) + '}',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            //async: false,
                            success: function (response) {
                                alert("Registro Actualizado");
                                $("#dvdetalle").dialog('close');
                            },
                            error: function (response) {
                                if (response.length != 0)
                                 console.table(response);
                            }

                        });
                    }

                   filtarsolicitudes()
                }

            }
            $(".btvisualizar").click(function () {
                $("#dvdetalle").dialog('open');
                $("#MainContent_txtindicador").val("V");

               // $("#MainContent_txtdias").attr("disabled", true);

                document.getElementById("btngrabar").style.visibility = "hidden";

                trp = $(this).parent().parent();
                id = $("td:eq(0)", trp).html();
                fecha = $("td:eq(4)", trp).html();
                $("#MainContent_lblcarta").html(id.substring(0, 4));
                var VC = {};
                VC.NUM_CARTA = id.substring(0, 4);
                VC.FECHA = fecha;
                $.ajax({
                    type: "POST",
                    url: "CartasIS.aspx/traerdatos",
                    data: '{VC: ' + JSON.stringify(VC) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        if (data.d.length > 0) {
                           
                            for (var i = 0; i < data.d.length; i++) {
                                $("#MainContent_lblcarta").html(data.d[i].NUM_CARTA);
                                $("#MainContent_lblcomplemento").html(data.d[i].complemento);
                                $("#MainContent_lblpara").html(data.d[i].PARA);
                                $("#MainContent_txtpara").val(data.d[i].RAZONSOCIAL);
                                $("#MainContent_txtde").val(data.d[i].DE);
                               
                                $("#MainContent_txtorden").val(data.d[i].ORDEN_TRABAJO);
                                $("#MainContent_lblta").html(data.d[i].TIPO_ANALISIS);
                                $("#MainContent_lblcertificado").html(data.d[i].TIPO_CERTIFICADO);
                                $("#MainContent_txtcertificado").val(data.d[i].TC_DESCRIPCION);
                                $("#MainContent_txttipoanalisis").val(data.d[i].TA_DESCRIPCION);
                                $("#MainContent_txtproductor").val(data.d[i].PRODUCTOR);
                                $("#MainContent_txthabilitacion").val(data.d[i].HABILITACION);
                                $("#MainContent_lblproducto").html(data.d[i].PRODUCTO);
                                $("#MainContent_txtproducto").val(data.d[i].PR_DESCRIPCION);
                                $("#MainContent_lblenvase").html(data.d[i].ENVASE);
                                $("#MainContent_txtenvase").val(data.d[i].ENV_DESCRIPCION);
                                $("#MainContent_txtlotes").val(data.d[i].LOTES);
                                $("#MainContent_txtespecificacion").val(data.d[i].ESPECIFICACION_INTERNA);
                                $("#MainContent_lbldestino").html(data.d[i].DESTINO);
                                $("#MainContent_txtdestino").val(data.d[i].DST_DESCRIPCION);
                                $("#MainContent_txtlugar").val(data.d[i].LUGAR);
                                $("#MainContent_txtfinspeccion").val(data.d[i].FECHA_I);
                                $("#MainContent_txtfechaemision").val(data.d[i].FECHA_E);
                                $("#MainContent_txtcc").val(data.d[i].CC);
                            }
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

            });

            $(".bteditar").click(function () {
                $("#dvdetalle").dialog('open');
                $("#MainContent_txtindicador").val("A");

                // $("#MainContent_txtdias").attr("disabled", true);

                document.getElementById("btngrabar").style.visibility = "visible";

                trp = $(this).parent().parent();
                id = $("td:eq(0)", trp).html();
                fecha = $("td:eq(4)", trp).html();
                $("#MainContent_lblcarta").html(id.substring(0, 4));
                var VC = {};
                VC.NUM_CARTA = id.substring(0, 4);
                VC.FECHA = fecha;
                $.ajax({
                    type: "POST",
                    url: "CartasIS.aspx/traerdatos",
                    data: '{VC: ' + JSON.stringify(VC) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        if (data.d.length > 0) {

                            for (var i = 0; i < data.d.length; i++) {
                                $("#MainContent_lblcarta").html(data.d[i].NUM_CARTA);
                                $("#MainContent_lblcomplemento").html(data.d[i].complemento);

                                $("#MainContent_lblpara").html(data.d[i].PARA);
                                $("#MainContent_txtpara").val(data.d[i].RAZONSOCIAL);
                                $("#MainContent_txtde").val(data.d[i].DE);

                                $("#MainContent_txtorden").val(data.d[i].ORDEN_TRABAJO);
                                $("#MainContent_lblta").html(data.d[i].TIPO_ANALISIS);
                                $("#MainContent_lblcertificado").html(data.d[i].TIPO_CERTIFICADO);
                                $("#MainContent_txtcertificado").val(data.d[i].TC_DESCRIPCION);
                                $("#MainContent_txttipoanalisis").val(data.d[i].TA_DESCRIPCION);
                                $("#MainContent_txtproductor").val(data.d[i].PRODUCTOR);
                                $("#MainContent_txthabilitacion").val(data.d[i].HABILITACION);
                                $("#MainContent_lblproducto").html(data.d[i].PRODUCTO);
                                $("#MainContent_txtproducto").val(data.d[i].PR_DESCRIPCION);
                                $("#MainContent_lblenvase").html(data.d[i].ENVASE);
                                $("#MainContent_txtenvase").val(data.d[i].ENV_DESCRIPCION);
                                $("#MainContent_txtlotes").val(data.d[i].LOTES);
                                $("#MainContent_txtespecificacion").val(data.d[i].ESPECIFICACION_INTERNA);
                                $("#MainContent_lbldestino").html(data.d[i].DESTINO);
                                $("#MainContent_txtdestino").val(data.d[i].DST_DESCRIPCION);
                                $("#MainContent_txtlugar").val(data.d[i].LUGAR);
                                $("#MainContent_txtfinspeccion").val(data.d[i].FECHA_I);
                                $("#MainContent_txtfechaemision").val(data.d[i].FECHA_E);
                                $("#MainContent_txtcc").val(data.d[i].CC);
                            }
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

            });

            $(".imprimir").click(function () {

                var trp = $(this).parent().parent();
                var idnumor = $("td:eq(0)", trp).html();
                var fecha = $("td:eq(4)", trp).html();
                if (idnumor != "&nbsp;") {
                    window.open("../CrystalReports/CARTAIS.aspx?ID= " + idnumor.substring(0, 4) + "&fecha=" + fecha, '_blank');
                } else {
                    alert("Error en envio de Datos");
                }
            });

        });
                
      
    </script>

    <style type="text/css">
        #btnsalir {
            width: 67px;
        }
        #btngrabar {
            width: 67px;
        }
        .auto-style2 {
            width: 219px;
        }
        .auto-style3 {
            width: 326px;
        }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <fieldset style="background-color: #99CCFF">
        <legend style="font-weight: bold; background-color: #99CCFF;">
            <asp:Label ID="Label9" runat="server" Text="LISTADO CARTAS" Font-Bold="True" Font-Size="12pt"></asp:Label></legend>

        <table>
            <tr>
                <td>Fecha:</td>
                <td>
                    <asp:TextBox ID="txtfecha1" runat="server" Width="80"></asp:TextBox>
                </td>
                <td>Fecha al:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td>
                    <asp:TextBox ID="txtfecha2" runat="server" Width="80"></asp:TextBox>
                </td>
                </tr>
             <tr>
                                 <td>
                    <input class="LISTAR" value="Buscar" type="button" style="width: 80px" />
                    <asp:Label ID="lblusuario" runat="server" ForeColor="#66CCFF"></asp:Label>
                </td>
                 <td>
                    <input id="btnnuevo" type="button" value="Nuevo" class="btnnuevo" style="width: 80px" /></td>
                            </tr>
        </table>
        
    </fieldset>


    <table>
        <tr>
            <td>
                <asp:GridView ID="gvordencompra" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="NUM_CARTA" HeaderText="N° CARTA" />
                        <asp:BoundField DataField="ORDEN_TRABAJO" HeaderText="ORDEN TRABAJO" />
                        <asp:BoundField DataField="PARA" HeaderText="PARA" />
                        <asp:BoundField DataField="DE" HeaderText="DE" />
                        <asp:BoundField DataField="FECHA" HeaderText="FECHA" />
                        <asp:BoundField DataField="TIPO_ANALISIS" HeaderText="TIPO_ANALISIS" />
                        <asp:BoundField DataField="TIPO_CERTIFICADO" HeaderText="CERTIFICADO" />
                        <asp:BoundField DataField="HABILITACION" HeaderText="HABILITACION" />
                        <asp:BoundField DataField="PRODUCTO" HeaderText="PRODUCTO" />
                        <asp:BoundField DataField="ESPECIFICACION_INTERNA" HeaderText="ESPECIFICACION" />
                        <asp:BoundField DataField="DESTINO" HeaderText="DESTINO" />
                        <asp:BoundField DataField="LUGAR" HeaderText="LUGAR" />
                        <asp:BoundField DataField="FECHA_INSPECCION" HeaderText="F. INSPECCION" />

                        <asp:TemplateField HeaderText="VER">
                            <ItemTemplate>
                                <div class="btvisualizar" style="text-align: center">
                                    <img alt="" src="../../Images/Message_Information.png" width="25" style="cursor: pointer" />
                                   </div>
                            </ItemTemplate>

                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="EDITAR">

                            <ItemTemplate>
                                <div class="bteditar" style="text-align: center">
                                    <img alt="" src="../../Images/edit.png" width="25" style="cursor: pointer" />
                                    </div>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="IMPRIMIR">
                         <ItemTemplate>
                                <div class="imprimir" style="text-align: center">
                                    <img alt="" src="../../Images/Printer.png" width="25" style="cursor: pointer" />
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

    <div id="dvdetalle" >
       
        <table>
            <tr>
                <td class="auto-style2">Carta Nº</td>

                <td class="auto-style3">
                    <asp:Label ID="lblcarta" runat="server" BorderStyle="Groove"></asp:Label>
                    <asp:Label ID="lblcomplemento" runat="server"></asp:Label>
                </td>
            </tr>
             <tr>
                <td class="auto-style2"> Orden de Trabajo Nº</td>

                <td class="auto-style3">
                   <asp:TextBox ID="txtorden" runat="server" Width="323px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2"> De:</td> <td class="auto-style3">
                    <asp:TextBox ID="txtde" runat="server" Width="323px"></asp:TextBox> </td>
            </tr>

             <tr>
                <td class="auto-style2"> Para</td> 
                <td class="auto-style3">
                    <asp:Label ID="lblpara" runat="server" Text=""></asp:Label>
                    <br />
                    <asp:TextBox ID="txtpara" runat="server" Width="323px"></asp:TextBox>
                 </td>
                            </tr>
             <tr>
                <td class="auto-style2"> Fecha Emision</td> <td class="auto-style3">
                    <asp:TextBox ID="txtfechaemision" runat="server"  Width="323px" placeholder="00/00/0000"></asp:TextBox> </td>
            </tr>
            <tr>
                <td class="auto-style2">Tipo Analisis</td>
                <td class="auto-style3">
                    <asp:Label ID="lblta" runat="server" Text=""></asp:Label>
                    <br />
                    <asp:TextBox ID="txttipoanalisis" runat="server"  Width="323px"></asp:TextBox></td>

            </tr>
            <tr>
                <td class="auto-style2"> Certificado</td>
                <td class="auto-style3"> &nbsp;<asp:Label ID="lblcertificado" runat="server" Text=""></asp:Label>
                    &nbsp;&nbsp;
                    <br />
                    <asp:TextBox ID="txtcertificado" runat="server" Width="323px"></asp:TextBox>
                </td>

            </tr>
              <tr>
                <td class="auto-style2">Productor</td>
                <td class="auto-style3"> 
                    <asp:TextBox ID="txtproductor" runat="server" Width="323px"></asp:TextBox>
                  </td>

            </tr>
            
           
             <tr>
                <td class="auto-style2"> Habilitación</td> <td class="auto-style3">
                    <asp:TextBox ID="txthabilitacion" runat="server"  Width="323px" ></asp:TextBox> </td>
            </tr>
              <tr>
                <td class="auto-style2"> Producto</td> <td class="auto-style3"> 
                  <asp:Label ID="lblproducto" runat="server" Text=""></asp:Label>
                    <asp:TextBox ID="txtproducto" runat="server" Width="323px"></asp:TextBox>
                  </td>
            </tr>
              <tr>
                <td class="auto-style2"> Envase</td> <td class="auto-style3">
                    <asp:Label ID="lblenvase" runat="server"></asp:Label>
                    <asp:TextBox ID="txtenvase" runat="server" Enabled="True" Width="323px"></asp:TextBox> </td>
            </tr>
            <tr>
                <td class="auto-style2"> lLotes</td> <td class="auto-style3">
                    <asp:TextBox ID="txtlotes" runat="server" Height="83px" TextMode="MultiLine" Width="323px"></asp:TextBox> </td>
            
            </tr>
            <tr>
                <td class="auto-style2"> Especificación Interna</td> <td class="auto-style3">
                    <asp:TextBox ID="txtespecificacion" runat="server" Enabled="True" Width="323px" ></asp:TextBox> </td>
            </tr>
            <tr>
                <td class="auto-style2"> Destino</td>
                <td class="auto-style3">  
                    <asp:Label ID="lbldestino" runat="server" Text=""></asp:Label> 
                    <br />
                    <asp:TextBox ID="txtdestino" runat="server" Width="323px"></asp:TextBox> 
                </td>
               

            </tr>
            
            <tr>
                <td class="auto-style2">Lugar</td>
                <td class="auto-style3"> <asp:TextBox ID="txtlugar" runat="server" Width="323px"></asp:TextBox> </td>
             </tr>

            <tr>
                <td class="auto-style2"> Fecha Inspeccion</td> <td class="auto-style3">
                    <asp:TextBox ID="txtfinspeccion" runat="server" Enabled="True" Width="323px" placeholder="00/00/0000" ></asp:TextBox> </td>
            </tr>
            <tr>
                <td class="auto-style2"> C.C.</td> <td class="auto-style3"> <asp:TextBox ID="txtcc" runat="server" Height="83px" TextMode="MultiLine" Width="323px"></asp:TextBox></td>
            </tr>

                      
           
            <tr>
                <td></td>
                <td class="auto-style2">
                     <input id="btngrabar" type="button" value="Grabar" class="btgrabar"/>
                     <asp:TextBox ID="txtindicador" runat="server" Width="0px" BorderStyle="None"></asp:TextBox>
                </td>

            </tr>
        </table>

    </div>

</asp:Content>
