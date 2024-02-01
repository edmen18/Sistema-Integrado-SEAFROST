<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AprobarSolicitud.aspx.cs" Inherits="MANTENIMIENTO_AprobarSolicitud" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
      
    <script type="text/javascript">
        $(function () {
            $("#MainContent_txtfecha").datepicker();
            $("#MainContent_txtfecha1").datepicker();
            $("#MainContent_txtfecha2").datepicker();

            $("#MainContent_txtcencosto").autocomplete(
                       {
                           source: function (request, response) {

                               $.ajax({
                                   url: "TrabajosCurso.aspx/GETVARIOS",
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
                               $('#MainContent_txtcodcencosto').val(str);
                           }
                       });

             $('#dvdetalle').dialog({
                autoOpen: false,
                modal: true,
                resizable: true,
                width: 830,
                heigth: 100,
                title: 'Registro',
                close: function (event, ui) {
               },
             });

             $(".editar").click(function () {

                 $("#dvdetalle").dialog('open');
                 trp = $(this).parent().parent();
                 id = $("td:eq(2)", trp).html();
                 SOL = $("td:eq(0)", trp).html();
                 $("#MainContent_lblsolicitud").html(id);
                
                     var VC = {};
                     VC.TR_CODIGO = id;
                     SUMATORIA();
                     solicitud(SOL);
                     
                     $.ajax({
                         type: "POST",
                         url: "AprobarSolicitud.aspx/traerdatos",
                         data: '{VC: ' + JSON.stringify(VC) + '}',
                         contentType: "application/json; charset=utf-8",
                         dataType: "json",
                         success: function (data) {

                             if (data.d.length > 0) {

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
                              }
                             else {
                                 alert("no se encontro registro");
                             }
                         },
                         error: function (response) {
                             if (response.length != 0)
                                 alert(response); }
                     });
                     
             });

             function solicitud(SOL) {

                 $("#dvdetalle").dialog('open');
                 trp = $(this).parent().parent();
                 id1 = $("td:eq(0)", trp).html();
                 var VC = {};
                 VC.COD_SOLICITUD = SOL;
              
                 $.ajax({
                     type: "POST",
                     url: "AprobarSolicitud.aspx/traerdatossolicitud",
                     data: '{VC: ' + JSON.stringify(VC) + '}',
                     contentType: "application/json; charset=utf-8",
                     dataType: "json",
                     success: function (data) {

                         if (data.d.length > 0) {
                             //formato_numero(sumasub, 2, ".", ",")
                             for (var i = 0; i < data.d.length; i++) {
                                 $("#MainContent_txtpresequipo").val(formato_numero(data.d[i].PE_NUEVO, 2, ".", ","));
                                 $("#MainContent_txtpresmaterial").val(formato_numero(data.d[i].PM_NUEVO, 2, ".", ","));
                                 $("#MainContent_txtmanobra").val(formato_numero(data.d[i].PMO_NUEVO, 2, ".", ","));
                                 $("#MainContent_lblse").html(data.d[i].COD_SOLICITUD);
                                 $("#MainContent_lbltotalnuevo").html(formato_numero(data.d[i].TOTAL_NUEVO, 2, ".", ","));
                                 $("#MainContent_lblestado").html(data.d[i].ESTADO);
                           }
                         }

                         else {
                             alert("no se encontro registro");
                         }
                     },
                     error: function (response) {
                         if (response.length != 0)
                             console.log(response);
                     }
                 });

             }

             function SUMATORIA() {
                 var VC = {};
                 VC.TR_CODIGO = $("#MainContent_lblsolicitud").html();
                 var SUMAs = 0;
                 $.ajax({
                     type: "POST",
                     url: "AprobarSolicitud.aspx/SUMATORIA",
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

             function aprobaroc(idnumoc,est) {
                 var idnumd = idnumoc;
                 var COAPRUEBA = {};
                 COAPRUEBA.COD_SOLICITUD = idnumd;
                 COAPRUEBA.USU_APRO = $("#MainContent_lblusuario").html();
                 COAPRUEBA.ESTADO = est;
                                 
                 $.ajax({
                     type: "POST",
                     url: "AprobarSolicitud.aspx/cambiarestado",
                     data: '{COAPRUEBA: ' + JSON.stringify(COAPRUEBA) + '}',
                     contentType: "application/json; charset=utf-8",
                     dataType: "json",
                     async: false,
                     success: function (response) {
                         if(est=="A"){
                             alert("Se Aprobo Correctamente");
                             Actualizapresupuesto();
                          }
                         else {
                             alert("Se Desaprobo Correctamente");
                         }
                         
                     },
                     error: function (response) {
                         console.log(response);
                     }
                 });               
                     //$("td:eq(8)", trp).html(usu1);
                     //$("td:eq(9)", trp).html(usu2);
                     //$("td:eq(10)", trp).html(usu3);
                
             }


             $(".aprobar").click(function () {
                 if ($("#MainContent_lblacceso").html() != "0" ) {

                 if($("#MainContent_lblestado").html()=="APROBADA"){
                     alert("La solicitud ya fue aprobada");
                 }
                 else {
                     aprobaroc($("#MainContent_lblse").html(), "A")
                 }
                 }
                 else {
                     alert("Ud. no cuenta con permisos para realizar  esta operación");
                 }

             });
             $(".desaprobar").click(function () {
                 if ($("#MainContent_lblacceso").html() != "0" ) {

                 if ($("#MainContent_lblestado").html() == "DESAPROBADA") {
                     alert("La solicitud ya fue desaprobada");
                 }
                 else {
                     aprobaroc($("#MainContent_lblse").html(), "D")
                 }
                 }
                 else {
                     alert("Ud. no cuenta con permisos para realizar  esta operación");
                 }
             });

             function Actualizapresupuesto() {
                 var DETA = {};


                 // $("#MainContent_lbltotalnuevo").html((Number(total) * (Number($("#MainContent_lbladicional").html()) / 100)) + Number(total));

                 DETA.TR_CODIGO = $("#MainContent_lblsolicitud").html();
                 DETA.PRESUPUESTO = (Number($("#MainContent_txtpresequipo").val()) + Number($("#MainContent_txtpresmaterial").val()) + Number($("#MainContent_txtmanobra").val()));
                 DETA.PRES_MANOBRA = $("#MainContent_txtmanobra").val();
                 DETA.PRES_MATERIAL = $("#MainContent_txtpresmaterial").val();
                 DETA.PRES_EQUIPOS = $("#MainContent_txtpresequipo").val();


                 if ((DETA.TR_CODIGO == "") || (DETA.PRESUPUESTO == "")) {
                     //alert("Complete los Datos antes de continuar");
                 }
                 else {
                     $.ajax({
                         type: "POST",
                         url: "AprobarSolicitud.aspx/ActualizaAnticipo",
                         data: '{DETA: ' + JSON.stringify(DETA) + '}',
                         contentType: "application/json; charset=utf-8",
                         dataType: "json",
                         async: false,
                         success: function (response) {
                            // alert("Registro Actualizado");

                         },
                         error: function (response) {
                             if (response.length != 0)
                                 console.table(response);
                         }

                     });
                 }
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

                 //if (separador_miles) {
                 //    // Añadimos los separadores de miles
                 //    var miles = new RegExp("(-?[0-9]+)([0-9]{3})");
                 //    while (miles.test(numero)) {
                 //        numero = numero.replace(miles, "$1" + separador_miles + "$2");
                 //    }
                 //}

                 return numero;
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
            width: 118px;
                height: 15px;
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
            .auto-style12 {
                width: 128px;
            }
            .auto-style13 {
                width: 129px;
            }
            .auto-style14 {
                height: 8px;
            }
            .auto-style15 {
                height: 19px;
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
            <tr>
                <td>
                    Estado</td>
                <td>
                    <asp:DropDownList ID="ddlestado" runat="server" Height="21px" Width="324px">
                        <asp:ListItem Value="T">TODOS</asp:ListItem>
                        <asp:ListItem Value="A">APROBADOS</asp:ListItem>
                        <asp:ListItem Value="E">EMITIDOS</asp:ListItem>
                        <asp:ListItem Value="D">DESAPROBADOS</asp:ListItem>
                    </asp:DropDownList>
                </td>
              
            </tr>
            </table>
        <table>
            <tr>
                  <td>Fecha:</td>
                <td>
                    &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtfecha1" runat="server" Width="80" placeholder="00/00/0000"></asp:TextBox>
                </td>
                <td>Fecha al:</td>
                <td>
                    <asp:TextBox ID="txtfecha2" runat="server" Width="80" placeholder="00/00/0000"></asp:TextBox>
                </td>
            </tr>
            </table>
        <table>
            <tr><td>

               
                <td>

                    <%--<asp:ImageButton ID="imbeliminar" runat="server" ImageUrl="~/Images/Message_Error.png" Width="25px" OnClick="ib_eliminar_Click" onclientclick="javascript:return confirm('Esta Seguro?')"/>--%>
                    <asp:Button ID="btnbuscar" runat="server" Text="Buscar" Width="91px" OnClick="btnbuscar_Click"  />
                &nbsp;</td>
            </tr>
        </table>
      
    </fieldset>


    <table>
        <tr>
            <td>
                <asp:GridView ID="gvordencompra" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" OnRowCreated="griddata_RowCreated">
                    <Columns>
                        <asp:BoundField DataField="COD_SOLICITUD" HeaderText="SOLICITUD Nº" />
                        <asp:BoundField DataField="FECHA_SOL" HeaderText="FECHA" />
                        <asp:BoundField DataField="TR_CODIGO" HeaderText="N° TAREA" />
                        <asp:BoundField DataField="DESCRIPCION" HeaderText="DESCRIPCION" />
                        <asp:BoundField DataField="PMO_ANTERIOR" HeaderText="MO_ACTUAL" DataFormatString="{0:F2}" >
                             <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
                                    </asp:BoundField>
                        <asp:BoundField DataField="PM_ANTERIOR" HeaderText="MAT_ACTUAL" DataFormatString="{0:F2}" >
                             <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
                                    </asp:BoundField>
                        <asp:BoundField DataField="PE_ANTERIOR" HeaderText="EQ_ACTUAL" DataFormatString="{0:F2}" >
                             <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
                                    </asp:BoundField>
                        <asp:BoundField DataField="PRES_ANTERIOR" HeaderText="PRES_ACTUAL" DataFormatString="{0:F2}" >
                             <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
                                    </asp:BoundField>
                        <asp:BoundField DataField="PMO_NUEVO" HeaderText="MO_PROPUESTA" DataFormatString="{0:F2}" >
                             <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
                                    </asp:BoundField>
                        <asp:BoundField DataField="PM_NUEVO" HeaderText="MAT_PROPUESTA" DataFormatString="{0:F2}" >
                             <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
                                    </asp:BoundField>
                        <asp:BoundField DataField="PE_NUEVO" HeaderText="EQ_PROPUESTO" DataFormatString="{0:F2}" >
                             <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
                                    </asp:BoundField>
                        <asp:BoundField DataField="PRES_NUEVO" HeaderText="PRES_PROPUESTO" DataFormatString="{0:F2}" >
                             <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
                                    </asp:BoundField>
                        <asp:BoundField DataField="ESTADO" HeaderText="ESTADO" />
                        <asp:BoundField DataField="USU_APRO" HeaderText="USU_APRO" />
                        <asp:TemplateField HeaderText="REGISTRAR">
                            <ItemTemplate>
                                <div class="editar" style="text-align: center">
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
                <td>DATOS DE LA SOLICITUD Nº </td>
                <td>
                    <asp:Label ID="lblse" runat="server" Text=""></asp:Label></td>
            </tr>

            <tr>
                <td>Estado        :</td>
                <td>
                    <asp:Label ID="lblestado" runat="server" Text=""></asp:Label> </td>

            </tr>

            <tr>
                <td>Pres. Equipos:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td> 
                    &nbsp;<asp:TextBox ID="txtpresequipo" runat="server" Enabled="False"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td>Pres. Materiales:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td> 
                    &nbsp;<asp:TextBox ID="txtpresmaterial" runat="server" Enabled="False"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td class="auto-style14">Pres. Mano Obra:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td class="auto-style14"> 
                    &nbsp;<asp:TextBox ID="txtmanobra" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                             
            </tr>
            <tr>
                <td class="auto-style15" > 
                   Total:
                </td>
                <td class="auto-style15" >
                    <asp:Label ID="lbltotalnuevo" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>  <input id="btnaprobar" type="button" value="Aprobar" class="aprobar btn" />&nbsp;
                      </td>
                <td><input id="btdesapro" type="button" value="Desaprobar" class="desaprobar btn"  />   </td>

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
