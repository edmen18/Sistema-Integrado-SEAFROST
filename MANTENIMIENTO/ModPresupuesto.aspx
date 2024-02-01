
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ModPresupuesto.aspx.cs" Inherits="Default2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/javascript">
    $(function () {
        $("#MainContent_txtfechad").datepicker();
        $("#MainContent_txtfecha1").datepicker();
        $("#MainContent_txtfecha2").datepicker();

        $("#MainContent_txtcencosto0").autocomplete(
                   {
                       source: function (request, response) {

                           $.ajax({
                               url: "ModPresupuesto.aspx/GETVARIOS",
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

        $(".imprimi").click(function () {

            var trp = $(this).parent().parent();
            var idnumor = $("td:eq(0)", trp).html();
            var valor = $("td:eq(9)", trp).html();
            if (Number(valor)>0){
                if (idnumor != "&nbsp;") {
                    window.open("../MANTENIMIENTO/Reportes/TC_IMPRESION.aspx?ID= " + idnumor, '_blank');
                } else {
                    alert("Error en envio de Datos");
                }
            }
            else {
                alert("El item seleccionado no tiene registrado ningun avance");
            }
           
        });
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
    $('#dvdetalle').dialog({
        autoOpen: false,
        modal: true,
        resizable: true,
        width: 730,
        heigth: 100,
        title: 'INFORMACIÓN',
        close: function (event, ui) {
            $("#MainContent_lbltotalnuevo").html("");
            $("#MainContent_txtpresmaterial").val("");
            $("#MainContent_txtpresequipo").val("");
            $("#MainContent_txtmanobra").val("");
            $("#MainContent_TXTTOTALDETALLE").val("");
            buscar();

        },
    });
    $(".editar").click(function () {
        
        $("#dvdetalle").dialog('open');
        trp = $(this).parent().parent();
        id = $("td:eq(0)", trp).html();
        $("#MainContent_lblsolicitud").html(id);
        var ultimodato = contaremitidas().contador;
        
        if (ultimodato==0){

        
        var VC = {};
        VC.TR_CODIGO = id;
        SUMATORIA();

        $.ajax({
            type: "POST",
            url: "ModPresupuesto.aspx/traerdatos",
            data: '{VC: ' + JSON.stringify(VC) + '}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {

                if (data.d.length > 0) {
                    //formato_numero(sumasub, 2, ".", ",")
                    for (var i = 0; i < data.d.length; i++) {
                        $("#MainContent_lbLsolicitud").html(data.d[i].TR_CODIGO);
                        $("#MainContent_lblcontratista").html(data.d[i].CONTRATISTA);
                        $("#MainContent_lbldescripcion").html(data.d[i].DESCRIPCION);
                        $("#MainContent_lblpresupuesto").html(formato_numero(data.d[i].PRESUPUESTO, 2, ".", ","));
                        $("#MainContent_lblobservaciones").html(data.d[i].OBSERVACIONES);
                        $("#MainContent_lblfecha").html(moment(data.d[i].FECHA).format("DD/MM/YYYY"));
                        $("#MainContent_lblplanta").html(data.d[i].PL_DESCRIPCION);
                        $("#MainContent_lblequipo").html(data.d[i].EQ_DESCRIPCION);
                        $("#MainContent_lblarea").html(data.d[i].AE_DESC);
                        $("#MainContent_lblcentrocosto").html(data.d[i].CENTRO_COSTO);
                        $("#MainContent_lblmoneda").html(data.d[i].MONEDA);
                        $("#MainContent_lblactivos").html(data.d[i].CONTROL_ACTIVOS);
                        $("#MainContent_txtestado").val(data.d[i].ESTADO);
                        $("#MainContent_txtusu1").val(data.d[i].USU1);
                        $("#MainContent_txtusu2").val(data.d[i].USU2);
                        $("#MainContent_txtusu3").val(data.d[i].USU3);
                        $("#MainContent_lblmanoobra").html(formato_numero(data.d[i].PRES_MANOBRA, 2, ".", ","));
                        $("#MainContent_lblpresequipo").html(formato_numero(data.d[i].PRES_EQUIPOS, 2, ".", ","));
                        $("#MainContent_lblpresmaterial").html(formato_numero(data.d[i].PRES_MATERIAL, 2, ".", ","));
                        $("#MainContent_lbladicional").html(formato_numero(data.d[i].PORC_ADICIONAL, 2, ".", ","));
                        $("#MainContent_lbltotal").html(formato_numero(((Number(data.d[i].PORC_ADICIONAL) / 100) * Number(data.d[i].PRESUPUESTO)) + Number(data.d[i].PRESUPUESTO), 2, ".", ","));
                    }
                  //  filtardetalle();

                    
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
        }
        else {
            alert("Ya hay una solicitud de ampliacion de presupuesto pendiente de aprobar, no es posible registrar otra");
            ("#dvdetalle").dialog('close');
        }
    });

    function SUMATORIA() {
        var VC = {};
        VC.TR_CODIGO =  $("#MainContent_lblsolicitud").html();
        var SUMAs =0;
        $.ajax({
            type: "POST",
            url: "ModPresupuesto.aspx/SUMATORIA",
            data: '{VC: ' + JSON.stringify(VC) + '}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {

                if (data.d.length > 0) {

                    for (var i = 0; i < data.d.length; i++) {
                        SUMAs = SUMAs + data.d[i].MONTO
                        $("#MainContent_TXTTOTALDETALLE").val(SUMAs);
                    }
                }
                else {
                   //alert("no se encontro registro");
                }

            },
            error: function (response) {
                if (response.length != 0)
                    alert(response);
            }
        });
    };



    $(".btbuscar").click(function () {

        buscar();

    });
    function buscar() {
        var VC = {};
        if ($("#MainContent_txtcodcencosto0").val() == "") {
            VC.COD_CENCOS = "-1";
        }
        else {
            VC.COD_CENCOS = $("#MainContent_txtcodcencosto0").val();
        }
        VC.FECHA = ($("#MainContent_txtfecha1").val() != "" ? moment($("#MainContent_txtfecha1").val(), "DD/MM/YYYY") : "01/05/2016");
        VC.FECHAFIN = ($("#MainContent_txtfecha2").val() != "" ? moment($("#MainContent_txtfecha2").val(), "DD/MM/YYYY") : moment(Date.now, "DD/MM/YYYY"));
        VC.PL_CODIGO = $("#MainContent_ddlplanta").val();
        VC.EQ_CODIGO = $("#MainContent_ddlequipo").val();
        VC.AE_COD = $("#MainContent_ddlarea").val();


        $.ajax({
            type: "POST",
            url: "ModPresupuesto.aspx/Listarcabecera",
            data: '{VC: ' + JSON.stringify(VC) + '}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {

                if (data.d.length > 0) {
                    var row = $("[id*=gvordencompra] tr:last-child").clone(true);
                    $("[id*=gvordencompra] tr").not($("[id*=gvordencompra] tr:first-child")).remove();

                    for (var i = 0; i < data.d.length; i++) {
                        if (Number(data.d[i].acumulado) < 100) {
                            $("td", row).eq(0).html(data.d[i].TR_CODIGO);
                            $("td", row).eq(1).html(moment(data.d[i].FECH).format("DD/MM/YYYY"));
                            $("td", row).eq(2).html(data.d[i].AE_DESC);
                            $("td", row).eq(3).html(data.d[i].EQ_DESCRIPCION);
                            $("td", row).eq(4).html(data.d[i].PL_DESCRIPCION);
                            $("td", row).eq(5).html(data.d[i].CONTRATISTA);
                            $("td", row).eq(6).html(data.d[i].CENTRO_COSTO);
                            $("td", row).eq(7).html(data.d[i].DESCRIPCION);
                            $("td", row).eq(8).html(data.d[i].CONTROL_ACTIVOS);
                            $("td", row).eq(9).html(data.d[i].PRESUPUESTO);
                            $("td", row).eq(10).html(data.d[i].PORC_ADICIONAL);
                            $("td", row).eq(11).html((Number(data.d[i].PRESUPUESTO) * (Number(data.d[i].PORC_ADICIONAL) / 100)) + Number(data.d[i].PRESUPUESTO));

                            $("[id*=gvordencompra]").append(row);
                            row = $("[id*=gvordencompra] tr:last-child").clone(true);
                        }
                    }

                } else {
                    var row = $("[id*=gvordencompra] tr:last-child").clone(true);
                    $("[id*=gvordencompra] tr").not($("[id*=gvordencompra] tr:first-child")).remove();

                    $("td", row).eq(2).html("");
                    $("td", row).eq(0).html("");
                    $("td", row).eq(1).html("");
                    $("td", row).eq(3).html("");
                    $("td", row).eq(4).html("");
                    $("td", row).eq(5).html("");
                    $("td", row).eq(6).html("");
                    $("td", row).eq(7).html("");
                    $("td", row).eq(8).html("");
                    $("td", row).eq(9).html("");

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
       
        //if (Number($("#MainContent_lblacceso").html()) > 0) {

            if ($("#MainContent_lbltotalnuevo").html()==""){
                var total = (Number($("#MainContent_txtpresequipo").val()) + Number($("#MainContent_txtpresmaterial").val()) + Number($("#MainContent_txtmanobra").val()));
                $("#MainContent_lbltotalnuevo").html((Number(total) * (Number($("#MainContent_lbladicional").html()) / 100)) + Number(total));
            }
            
            if (Number($("#MainContent_lbltotalnuevo").html()) > Number($("#MainContent_TXTTOTALDETALLE").val())) {
                //Actualizapresupuesto();
                InsertaRegistro();
            }
            else {
                alert("no es posible ingresar un presupuesto menor al monto que va empleando hasta el momento");
            }
        //}
        //else {
        //    alert("Ud no tiene permisos para realizar esta operación");
        //}
    });
    $(".calcular").click(function () {

        //if (Number($("#MainContent_lblacceso").html()) > 0) {

            var total = (Number($("#MainContent_txtpresequipo").val()) + Number($("#MainContent_txtpresmaterial").val()) + Number($("#MainContent_txtmanobra").val()));
                     
            $("#MainContent_lbltotalnuevo").html((Number(total) * (Number($("#MainContent_lbladicional").html()) / 100)) + Number(total));

            // }
        //else {
        //    alert("Ud no tiene permisos para realizar esta operación");
        //}
    });
    function pad(str, max) {
        if (str != undefined) {
            str = str.toString();
            return str.length < max ? pad("0" + str, max) : str;
        }
    }

 function InsertaRegistro() {
     var DETA = {};
     var fecemi = moment(Date.now, "DD/MM/YYYY");
     fecemi = fecemi == null ? null : new Date(fecemi);
     var ultimodato = generar().contador;
     var formato = ultimodato.length < 8 ? pad("0" + ultimodato, 8) : ultimodato;
     DETA.COD_SOLICITUD=("SP" + formato);
     alert("Se ha generado la Solicitud de extension de presupuesto Nº " + DETA.COD_SOLICITUD);

     DETA.TR_CODIGO = $("#MainContent_lblsolicitud").html();
     DETA.FECHA_SOL = fecemi;
     DETA.PMO_ANTERIOR = $("#MainContent_lblmanoobra").html();
     DETA.PM_ANTERIOR = $("#MainContent_lblpresmaterial").html();
     DETA.PE_ANTERIOR = $("#MainContent_lblpresequipo").html();
     DETA.PRES_ANTERIOR = $("#MainContent_lblpresupuesto").html();

     DETA.PMO_NUEVO = $("#MainContent_txtmanobra").val();
     DETA.PM_NUEVO = $("#MainContent_txtpresmaterial").val();
     DETA.PE_NUEVO = $("#MainContent_txtpresequipo").val();
     DETA.PRES_NUEVO = Number($("#MainContent_txtmanobra").val()) + Number($("#MainContent_txtpresmaterial").val()) + Number($("#MainContent_txtpresequipo").val())
     DETA.ESTADO = "E";

     DETA.COD_USUARIO = $("#MainContent_lblusuario").html();
     DETA.PORCENTAJE_ANTERIOR = $("#MainContent_lblpresupuesto").html();
     DETA.MONTO_ANTERIOR = $("#MainContent_lbladicional").html();
     DETA.TOTAL_ANTERIOR = $("#MainContent_lbltotal").html();
     DETA.TOTAL_NUEVO = $("#MainContent_lbltotalnuevo").html();

              $.ajax({
                  type: "POST",
                  url: "ModPresupuesto.aspx/guardarModificacion",
                  data: '{DETA: ' + JSON.stringify(DETA) + '}',
                  contentType: "application/json; charset=utf-8",
                  dataType: "json",
                  async: false,
                  success: function (response) {
                      //alert("Registro Grabado")
                                       },
                  error: function (response) {
                      if (response.length != 0)
                          console.table(response);
                  }

              });
             
 }

 function Actualizapresupuesto() {
     var DETA = {};


    // $("#MainContent_lbltotalnuevo").html((Number(total) * (Number($("#MainContent_lbladicional").html()) / 100)) + Number(total));

     DETA.TR_CODIGO = $("#MainContent_lblsolicitud").html();
     DETA.PRESUPUESTO = (Number($("#MainContent_txtpresequipo").val()) + Number($("#MainContent_txtpresmaterial").val()) + Number($("#MainContent_txtmanobra").val()));
     DETA.PRES_MANOBRA = $("#MainContent_txtmanobra").val();
     DETA.PRES_MATERIAL=$("#MainContent_txtpresmaterial").val();
     DETA.PRES_EQUIPOS=$("#MainContent_txtpresequipo").val();


     if ((DETA.TR_CODIGO == "") || (DETA.PRESUPUESTO== "")) {
         alert("Complete los Datos antes de continuar");
     }
     else {
         $.ajax({
                 type: "POST",
                 url: "ModPresupuesto.aspx/ActualizaAnticipo",
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
 }
 function generar() {
     var solicitud = "";
     var contador = "";

     $.ajax({

         type: "POST",
         url: "ModPresupuesto.aspx/GENERAR",
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

 function contaremitidas() {
     var trabajo = $("#MainContent_lblsolicitud").html();
   

     $.ajax({

         type: "POST",
         url: "ModPresupuesto.aspx/contaremitidas",
         data: "{ 'dato': '" + trabajo + "' }",
         contentType: "application/json; charset=utf-8",
         dataType: "json",
         async: false,
         success: function (data) {
             contador = data.d;

         },
         error: function (data) {
             if (data.length != 0)
                 console.log(data);
         }
     });
     return { contador };
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
            width: 81px;
                height: 19px;
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
            .auto-style9 {
                width: 108px;
            }
            .auto-style10 {
                width: 50px;
            }
            .auto-style11 {
                width: 65px;
            }
            #btntotal {
                width: 65px;
            }
            .auto-style12 {
                width: 113px;
            }
            .auto-style13 {
                width: 128px;
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
            </table>
        <table>
            <tr>
                 <td class="auto-style11">Fecha:>
                <td>
                    <asp:TextBox ID="txtfecha1" runat="server" Width="81px" placeholder="00/00/0000"></asp:TextBox>
                </td>
                <td class="auto-style10">Fecha al:</td>
                <td>
                    <asp:TextBox ID="txtfecha2" runat="server" Width="81px" placeholder="00/00/0000"></asp:TextBox>
                </td>
            </tr>
                 
            <tr>
                
                <td class="auto-style11">

                    <%--<asp:ImageButton ID="imbeliminar" runat="server" ImageUrl="~/Images/Message_Error.png" Width="25px" OnClick="ib_eliminar_Click" onclientclick="javascript:return confirm('Esta Seguro?')"/>--%>
                    <input id="btnbuscar" type="button" value="Buscar" class="btbuscar" />
                </td>
                <td class="auto-style10">
                     <asp:Button ID="btnexcel" runat="server" Text="Ver Reporte" OnClick="btnexcel_Click" Width="82px" />
                </td>
            </tr>
        </table>
      
    </fieldset>




    <table>
        <tr>
            <td>
                <asp:GridView ID="gvordencompra" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" OnRowCreated="griddata_RowCreated">
                    <Columns>
                        <asp:BoundField DataField="TR_CODIGO" HeaderText="N° TAREA" />
                        <asp:BoundField DataField="FECH" HeaderText="FECHA" />
                        <asp:BoundField DataField="AE_DESC" HeaderText="AREA" />
                        <asp:BoundField DataField="EQ_DESCRIPCION" HeaderText="EQUIPO" />
                        <asp:BoundField DataField="PL_DESCRIPCION" HeaderText="PLANTA" />
                        <asp:BoundField DataField="CONTRATISTA" HeaderText="CONTRATISTA" />
                        <asp:BoundField DataField="CENTRO_COSTO" HeaderText="CENTRO_COSTO" />
                        <asp:BoundField DataField="DESCRIPCION" HeaderText="DESCRIPCION" />
                        <asp:BoundField DataField="CONTROL_ACTIVOS" HeaderText="CONTROL ACTIVOS" />

                        <asp:BoundField DataField="ACUMULADO" HeaderText="PRESUPUESTO" DataFormatString="{0:F2}" >
                             <ItemStyle HorizontalAlign="Right" VerticalAlign="top"></ItemStyle>
                                    </asp:BoundField>

                        <asp:BoundField DataField="ADICIONAL" HeaderText="% ADICIONAL" DataFormatString="{0:F2}" >
                             <ItemStyle HorizontalAlign="Right" VerticalAlign="top"></ItemStyle>
                                    </asp:BoundField>
                        <asp:BoundField DataField="TOTAL" HeaderText="TOTAL" DataFormatString="{0:F2}" >
                             <ItemStyle HorizontalAlign="Right" VerticalAlign="top"></ItemStyle>
                                    </asp:BoundField>

                        <asp:TemplateField HeaderText="REGISTRAR">

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

    <div id="dvdetalle" style="display:none">
       
        <table>
            <tr>
                <td>Código&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :

                <td>
                    <asp:Label ID="lblsolicitud" runat="server" Text=""></asp:Label>
                </td>
            </tr>

             <tr>
                <td class="auto-style1"> Area&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; : </td> 
                <td>
                    <asp:Label ID="lblarea" runat="server"></asp:Label>
                 </td>
                             </tr>
            <tr>
                 <td class="auto-style1">Equipo&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                <td>  
                    <asp:Label ID="lblequipo" runat="server"></asp:Label>
                 </td>
            </tr>
           
            <tr>
                <td class="auto-style3"> Planta&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                <td class="auto-style2">  
                    <asp:Label ID="lblplanta" runat="server"></asp:Label>
                </td>
                
            </tr>
            <tr>
                <td class="auto-style1">Centro Costo&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                <td>  
                    <asp:Label ID="lblcentrocosto" runat="server"></asp:Label>
                </td>
            </tr>
             
             </table>
            <table>
            <tr>
                <td class="auto-style1"> Descripción&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td> <td>
                    <asp:Label ID="lbldescripcion" runat="server"></asp:Label>
                </td>
            </tr>
                </table>
         <table>

            <tr>
                <td class="auto-style13"> Control Activos&nbsp; :</td> <td>
                <asp:Label ID="lblactivos" runat="server"></asp:Label>
                </td>
                               
                 
            </tr>
             <tr>
                 <td class="auto-style13"> Moneda&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</td>
                 <td>
                     <asp:Label ID="lblmoneda" runat="server"></asp:Label>
                </td>
             </tr>
             <tr>
                 <td class="auto-style13"> Presupuesto&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</td>
                 <td>
                     <asp:Label ID="lblpresupuesto" runat="server"></asp:Label>
                &nbsp;&nbsp;&nbsp
                </td>
                 <td class="auto-style12">% Adicional&nbsp;&nbsp;&nbsp;:</td>
                 <td>
                     <asp:Label ID="lbladicional" runat="server"></asp:Label>
                 &nbsp;&nbsp;&nbsp
                </td>
                  <td class="auto-style9">Total&nbsp;&nbsp;&nbsp;:</td>
                 <td>
                     <asp:Label ID="lbltotal" runat="server"></asp:Label>
                
                </td>
             </tr>



             <tr>
                 <td class="auto-style13"> Pres Mano Obra&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</td>
                 <td>
                     <asp:Label ID="lblmanoobra" runat="server"></asp:Label>
                &nbsp;&nbsp;&nbsp
                </td>
                 <td class="auto-style12">Pres. Materiales&nbsp;&nbsp;&nbsp;:</td>
                 <td>
                     <asp:Label ID="lblpresmaterial" runat="server"></asp:Label>
                 &nbsp;&nbsp;&nbsp
                </td>
                  <td class="auto-style9">Pres. Equipos&nbsp;&nbsp;&nbsp;:</td>
                 <td>
                     <asp:Label ID="lblpresequipo" runat="server"></asp:Label>
                
                </td>
             </tr>
            
             </table>
        <table>

                           
            <tr>
                <td class="auto-style1"> Fecha Registro&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td> <td>
                    <asp:Label ID="lblfecha" runat="server"></asp:Label>
                    
                </td>
            
            </tr>
            <tr>
                <td>Pres. Empleado :</td>
                <td><asp:TextBox ID="TXTTOTALDETALLE" runat="server" Enabled="False"></asp:TextBox></td>
            </tr>
            </table>
        <table>
            <tr>
                <td>Pres. Equipos:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td> 
                    &nbsp;<asp:TextBox ID="txtpresequipo" runat="server"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td>Pres. Materiales:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td> 
                    &nbsp;<asp:TextBox ID="txtpresmaterial" runat="server"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td>Pres. Mano Obra:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td> 
                    &nbsp;<asp:TextBox ID="txtmanobra" runat="server"></asp:TextBox>
                    </td>
                <td> 
                    <input id="btntotal" type="button" value="Ver Total" class="calcular" />
                    <%--<asp:Button ID="BTNCALCULAR" runat="server" Text="---" OnClick="BTNCALCULAR_Click" />--%>

                </td>
                <td>
                    <asp:Label ID="lbltotalnuevo" runat="server" Text=""></asp:Label>
                </td>
                <td> 
                    <input id="btngrabar" type="button" value="Grabar" class="btgrabar" />
                </td>
            </tr>

        </table>


        <table> 
            <tr>
                <td>

                    <asp:TextBox ID="txtusu1" runat="server" Width="0px" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="txtusu2" runat="server" Width="0px" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="txtusu3" runat="server" Width="0px" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="txtestado" runat="server" Width="0px" BorderStyle="None"></asp:TextBox>

                </td>
            </tr>
           
            </table>
      
        <table>
            
        </table>

    </div>

</asp:Content>