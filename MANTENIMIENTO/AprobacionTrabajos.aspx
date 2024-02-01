<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AprobacionTrabajos.aspx.cs" Inherits="MANTENIMIENTO_AprobacionTrabajos" %>--%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AprobacionTrabajos.aspx.cs" Inherits="MANTENIMIENTO_AprobacionTrabajos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server"> 

<script type="text/javascript">
    $(function () {
        $("#MainContent_txtfecha").datepicker();
        $("#MainContent_txtfecha1").datepicker();
        $("#MainContent_txtfecha2").datepicker();

        $("#MainContent_txtcencosto0").autocomplete(
                    {
                        source: function (request, response) {

                            $.ajax({
                                url: "AprobacionTrabajos.aspx/GETVARIOS",
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
            width: 830,
            heigth: 100,
            title: 'INFORMACIÓN',
            close: function (event, ui) {
              },
        });
         $(".editar").click(function () {
                                         
                $("#dvdetalle").dialog('open');
                trp = $(this).parent().parent();
                id = $("td:eq(0)", trp).html();
                $("#MainContent_lblsolicitud").html(id);
                var VC = {};
                VC.TR_CODIGO = id;             
                
                $.ajax({
                    type: "POST",
                    url: "AprobacionTrabajos.aspx/traerdatos",
                    data: '{VC: ' + JSON.stringify(VC) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        if (data.d.length > 0) {

                            for (var i = 0; i < data.d.length; i++) {
                                $("#MainContent_lbLsolicitud").html(data.d[i].TR_CODIGO);
                                $("#MainContent_txtcontratista").val(data.d[i].COD_CONTRATISTA +"-"+data.d[i].CONTRATISTA);
                                $("#MainContent_txtcodcontratista").val(data.d[i].COD_CONTRATISTA);
                                $("#MainContent_txtusu1").val(data.d[i].USU1);
                                $("#MainContent_txtusu2").val(data.d[i].USU2);
                                $("#MainContent_txtusu3").val(data.d[i].USU3);

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
                            
                           // filtardetalle1();
                           // filtardetalleAcum();
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
               // maximo();

                                               
            });
         function filtardetalle() {

             var VC = {};
             VC.TR_CODIGO = $("#MainContent_lblsolicitud").html();
             $.ajax({
                 type: "POST",
                 url: "AprobacionTrabajos.aspx/ListarDetalleFACCAR",
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
                             $("td", row).eq(4).html(data.d[i].MONTO);
                             cc = 2;
                             $("[id*=GridView1]").append(row);
                             row = $("[id*=GridView1] tr:last-child").clone(true);
                         }
                         var sub01 = recorregrid().contarndw;
                         recorregridaux();

                     } else {
                         var row = $("[id*=GridView1] tr:last-child").clone(true);
                         $("[id*=GridView1] tr").not($("[id*=GridView1] tr:first-child")).remove();

                         $("td", row).eq(0).val("");
                         $("td", row).eq(0).html("");
                         $("td", row).eq(1).html("");
                         $("td", row).eq(2).html("");
                         $("td", row).eq(3).html("");
                         $("td", row).eq(4).html("");

                         $("[id*=GridView1]").append(row);
                         //alert("no se encontro registro");
                     }
                 },
                 error: function (response) {
                     if (response.length != 0)
                         alert(response);
                 }
             });

         }
         $(".btapro").click(function () {

             if ($("#MainContent_txtestado").val() == "E") {
                     
                     if (confirm("Desea Aprobar el trabajo en Curso nº: " + $("#MainContent_lblsolicitud").html())) {
                         aprobaroc($("#MainContent_lblsolicitud").html(), "A", $("#MainContent_txtusu1").val(), $("#MainContent_txtusu2").val(), $("#MainContent_txtusu3").val());

                         if ($("td:eq(9)", trp).html().trim() == "&nbsp;") {
                             $("td:eq(9)", trp).html($("#MainContent_lblusuario").html());
                         }
                         else {
                          

                             if ($("td:eq(10)", trp).html().trim() == "&nbsp;") {
                                 $("td:eq(10)", trp).html($("#MainContent_lblusuario").html());
                             }
                             else {
                                 if ($("td:eq(11)", trp).html().trim() == "&nbsp;") {
                                 $("td:eq(11)", trp).html($("#MainContent_lblusuario").html());
                                 $("td:eq(8)", trp).html("APROBADO");
                                 }
                             }
                         }

                         $("#dvdetalle").dialog('close')
                    }
                 
             }
             else {
                 alert("La solicitud ya fue aprobada");

             }

         });


         $(".btdesapro").click(function () {

             if ($("#MainContent_txtestado").val() == "A") {

                 if (confirm("Desea Desaprobar el trabajo en Curso nº: " + $("#MainContent_lblsolicitud").html())) {
                     aprobaroc($("#MainContent_lblsolicitud").html(), "E", $("#MainContent_txtusu1").val(), $("#MainContent_txtusu2").val(), $("#MainContent_txtusu3").val());
                     $("td:eq(9)", trp).html("&nbsp;");
                     $("td:eq(10)", trp).html("&nbsp;");
                     $("td:eq(11)", trp).html("&nbsp;");
                     $("td:eq(8)", trp).html("EMITIDO");
                     $("#dvdetalle").dialog('close')
                 }

             }
             else {
                 alert("La solicitud ya está Desaprobada");

             }

         });

         function aprobaroc(idnumoc, indice, usu1, usu2, usu3) {
             var idnumd = idnumoc;
             var COAPRUEBA = {};
             COAPRUEBA.TR_CODIGO = idnumd;
             COAPRUEBA.ESTADO = indice;
             var user = {};
             user = $("#MainContent_lblusuario").html();
             COAPRUEBA.USU1 = usu1;
             COAPRUEBA.USU2 = usu2;
             COAPRUEBA.USU3 = usu3;
           
             if (indice == "A") {

                 if (usu1.trim() == "" && usu2.trim() == "" && usu3.trim() == "") {
                     COAPRUEBA.USU1 = user;
                     COAPRUEBA.USU2 = usu2;
                     COAPRUEBA.USU3 = usu3;
                  }

                 if (usu1.trim() != "" && usu2.trim() == "" && usu3.trim() == "") {
                     COAPRUEBA.USU1 = usu1;
                     COAPRUEBA.USU2 = user;
                     COAPRUEBA.USU3 = usu3;
                  }
                 if (usu2.trim() != "" && usu1.trim() != "" && usu3.trim() == "") {
                     COAPRUEBA.USU1 = usu1;
                     COAPRUEBA.USU2 = usu2;
                     COAPRUEBA.USU3 = user;
                     }
                                
                 if (usu2.trim() != "" && usu1.trim() != "" && usu3.trim() != "") {
                     alert("El Trabajo ya fue aprobado")
                 }
             }

             $.ajax({

                 type: "POST",
                 url: "AprobacionTrabajos.aspx/aprobaroc",
                 data: '{COAPRUEBA: ' + JSON.stringify(COAPRUEBA) + '}',
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 async: false,
                 success: function (response) {
                     //alert("La operación completada correctamente")
                     // filtarsolicitudes()
                 },
                 error: function (response) {
                 }
             });

         }

         $(".imprimi").click(function () {

             var trp = $(this).parent().parent();
             var idnumor = $("td:eq(0)", trp).html();
             if (idnumor != "&nbsp;") {
                 window.open("../MANTENIMIENTO/Reportes/TC_IMPRESION.aspx?ID= " + idnumor, '_blank');
             } else {
                 alert("Error en envio de Datos");
             }
         });

    });
</script>

    <style type="text/css">
        .auto-style1 {
            height: 19px;
        }
        .auto-style2 {
            height: 19px;
            width: 64px;
        }
    </style>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <fieldset style="background-color: #99CCFF">
        <legend style="font-weight: bold; background-color: #99CCFF;">
            <asp:Label ID="Label9" runat="server" Text="LISTADO DE TRABAJOS EN CURSO PENDIENTES DE APROBACIÓN" Font-Bold="True" Font-Size="12pt"></asp:Label></legend>

        <table>
            <tr>
                <td>Area</td>
                <td colspan="3">
                    <asp:DropDownList ID="ddlarea" runat="server" Height="16px" Width="324px">
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
                 <td class="auto-style1">Fecha:&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtfecha1" runat="server" Width="122px" placeholder="00/00/0000"></asp:TextBox>
                </td>
                <td class="auto-style1">Fecha al:</td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtfecha2" runat="server" Width="141px" placeholder="00/00/0000"></asp:TextBox>
                </td>
            </tr>
            <tr><td>

                &nbsp;</td>
                <td>

                    <%--<asp:ImageButton ID="imbeliminar" runat="server" ImageUrl="~/Images/Message_Error.png" Width="25px" OnClick="ib_eliminar_Click" onclientclick="javascript:return confirm('Esta Seguro?')"/>--%>
                    <asp:Button ID="btnbuscar" runat="server" Text="Buscar" Width="91px" OnClick="btnbuscar_Click" />
                </td>
            </tr>
        </table>
      
    </fieldset>


    <table>
        <tr>
            <td>
                <asp:GridView ID="gvordencompra" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" OnRowCreated="griddata_RowCreated">
                    <Columns>
                        <asp:BoundField DataField="TR_CODIGO" HeaderText="N° TAREA" >
                               <ItemStyle VerticalAlign="Top" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FECH" HeaderText="FECHA" >
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

                        <asp:BoundField DataField="USU1" HeaderText="USER1" >
                               <ItemStyle VerticalAlign="Top" />
                        </asp:BoundField>
                        <asp:BoundField DataField="USU2" HeaderText="USER2" >
                               <ItemStyle VerticalAlign="Top" />
                        </asp:BoundField>
                        <asp:BoundField DataField="USU3" HeaderText="USER3" >
                               <ItemStyle VerticalAlign="Top" />
                        </asp:BoundField>

                        <asp:BoundField DataField="TIPO" HeaderText="TIPO" />

                        <asp:TemplateField HeaderText="VER">

                            <ItemTemplate>
                                <div class="editar" style="text-align: center">
                                    <img alt="" src="../Images/Message_Information.png" width="25" style="cursor: pointer" />
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

    <div id="dvdetalle" style="display: none"    >
       <table>
            <tr>
                <td>Código</td>

                <td>
                    <asp:Label ID="lblsolicitud" runat="server" Text=""></asp:Label>
                </td>
                 <td class="auto-style3"> Planta</td>
                <td class="auto-style2">  
                <asp:DropDownList ID="ddlplant" runat="server" Height="30px" Width="267px" enabled="false">
                </asp:DropDownList>
                </td>
            </tr>

             <tr>
                <td class="auto-style1"> Area </td> 
                <td>
                <asp:DropDownList ID="ddlare" runat="server" Height="30px" Width="267px" enabled="false">
                </asp:DropDownList>
                 </td>
                 
                <td class="auto-style1">Equipo</td>
                <td>  
                <asp:DropDownList ID="ddlequip" runat="server" Height="30px" Width="267px" enabled="false">
                </asp:DropDownList>
                </td>

                     
              


           
                
            </tr>
           
                         
            <tr>
                <td class="auto-style1"> Contratista</td> <td> 
                    <asp:TextBox ID="txtcontratista" runat="server" Width="267px" enabled="false"></asp:TextBox> 
                </td><td>
                  <asp:TextBox ID="txtcodcontratista" runat="server" Width="130px" Enabled="false"></asp:TextBox> 
                </td>

           </tr>
            <tr>
                <td class="auto-style10">Centro Costo</td> <td class="auto-style11"> 
                    <asp:TextBox ID="txtcencosto" runat="server" Width="267px" enabled="false"></asp:TextBox> 
                </td><td class="auto-style11">
                  <asp:TextBox ID="txtcodcencosto" runat="server" Width="130px" Enabled="false"></asp:TextBox> 
                </td>

           </tr> <tr>
              <td class="auto-style1">Tipo&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td>  
                <asp:DropDownList ID="ddltipo" runat="server" Height="30px" Width="267px" enabled="false">
                </asp:DropDownList>
                </td></tr>
            </table>

            <table>
            <tr>
                <td class="auto-style2"> Descripción&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td> <td>
                    <asp:TextBox ID="txtdescripcion" runat="server" Width="666px" Height="56px" TextMode="MultiLine" enabled="false"></asp:TextBox> </td>
            </tr>
                </table>
         <table>

            <tr>
                <td class="auto-style1"> Control Activos</td> <td>
                <asp:DropDownList ID="ddlcontrolactivos" runat="server" Height="25px" Width="169px" enabled="false">
                    <asp:ListItem>TRABAJO EN CURSO</asp:ListItem>
                    <asp:ListItem>MEJORA TRABAJO EN CURSO</asp:ListItem>
                </asp:DropDownList>
                </td>
                <td class="auto-style6"> Moneda</td>
                 <td>
                <asp:DropDownList ID="ddlmoneda" runat="server" Height="28px" Width="149px" enabled="false">
                </asp:DropDownList>
                 </td>
                </tr>
              <tr>
                <td class="auto-style1"> Fecha Registro</td> <td>
                    <asp:TextBox ID="txtfecha" runat="server" Width="125px" placeholder="00/00/0000" enabled="false"></asp:TextBox> 
                    <asp:TextBox ID="txtindicador" runat="server" Width="0px" BorderStyle="None"></asp:TextBox>
                &nbsp; 
                    <asp:TextBox ID="txtestado" runat="server" Width="0px" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="txtmaximo" runat="server" Width="0px" BorderStyle="None"></asp:TextBox>
                    <asp:TextBox ID="txtvalidacion" runat="server" Width="0px" BorderStyle="None"></asp:TextBox>
                </td>
                  <td>
                     Tipo Cambio
                 </td>
                 <td> <asp:Label ID="lbltipocambio" runat="server" Text="" enabled="false"></asp:Label></td>
                     
            </tr>
            <tr>
                  <td class="auto-style10"> Fecha Inicio</td>
                <td class="auto-style11">
                    <asp:TextBox ID="txtfechainicio" runat="server" placeholder="00/00/0000" enabled="false"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                            <td class="auto-style10"> Fecha Fin&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td class="auto-style11"> <asp:TextBox ID="txtfechafin" runat="server" placeholder="00/00/0000" Width="146px"  enabled="false"></asp:TextBox></td>
            </tr>
                         </table>
        <table>
             <tr>
                 <td class="auto-style12">Pres. Material&nbsp;&nbsp; </td>
                 <td>
                     <asp:TextBox ID="txtpresmaterial" runat="server" Width="125px" style="margin-bottom: 0" enabled="false"></asp:TextBox> 
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                 </td>

                 <td class="auto-style13">&nbsp;Pres Equipo&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                 <td class="auto-style17"><asp:TextBox ID="txtpresequipo" runat="server" Width="146px" style="margin-bottom: 0" enabled="false"></asp:TextBox> 
                 </td>

                 <td class="auto-style16">&nbsp; Pres. Mano Obra</td>
                 <td class="auto-style15">
                     <asp:TextBox ID="txtmanobra" runat="server" Width="100px" style="margin-bottom: 0" enabled="false"></asp:TextBox> 
                 </td>
                 <td>
                     &nbsp;</td>

</tr>
            <tr>

                <td class="auto-style5"> Presupuesto</td>
                 <td class="auto-style18">
                     <asp:TextBox ID="txtpresupuesto" runat="server" Width="123px" style="margin-bottom: 0" Enabled="False"></asp:TextBox> 
                 </td>
                  <td class="auto-style5"> &nbsp;% Adicional</td>
                 <td class="auto-style19"><asp:TextBox ID="txtadicional" runat="server" Width="145px" style="margin-bottom: 0" Enabled="False"></asp:TextBox> 
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
                    <asp:TextBox ID="txtobservaciones" runat="server" Width="668px" Height="57px" TextMode="MultiLine" enabled="false"></asp:TextBox> </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtusu1" runat="server" Width="0px" style="margin-bottom: 0" enabled="false" BorderStyle="None"></asp:TextBox> 
                    <asp:TextBox ID="txtusu2" runat="server" Width="0px" style="margin-bottom: 0" enabled="false" BorderStyle="None"></asp:TextBox> 
                    <asp:TextBox ID="txtusu3" runat="server" Width="0px" style="margin-bottom: 0" enabled="false" BorderStyle="None"></asp:TextBox> 
                </td>
            </tr>
              
           
           
            </table>
       
        <table>
             <tr>
                <td>
                     <%--<asp:Button ID="btnaprobar" runat="server" Text="Aprobar   " />--%>
                    <input id="btnaprobar" type="button" value="Aprobar" class="btapro" />
                 </td>
                  <td>
                     <%--<asp:Button ID="btndesaprobar" runat="server" Text="Desaprobar" />--%>
                      <input id="btndesaprobar" type="button" value="Desaprobar" class="btdesapro" />
                 </td>


            </tr>
        </table>

    </div>

</asp:Content>
