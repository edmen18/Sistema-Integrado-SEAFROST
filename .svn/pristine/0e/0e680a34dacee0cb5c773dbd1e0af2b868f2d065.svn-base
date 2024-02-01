<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AvancesTrabajos.aspx.cs" Inherits="Default2" %>
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
                               url: "AvancesTrabajos.aspx/GETVARIOS",
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
                    window.open("../MANTENIMIENTO/Reportes/TC_IMP_AVANCE.aspx?ID= " + idnumor, '_blank');
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
            url: "AvancesTrabajos.aspx/traerdatos",
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
                        $("#MainContent_lbladicional").html(formato_numero(data.d[i].PORC_ADICIONAL, 2, ".", ","));
                        $("#MainContent_lbltotal").html(formato_numero(((Number(data.d[i].PORC_ADICIONAL) / 100) * Number(data.d[i].PRESUPUESTO)) + Number(data.d[i].PRESUPUESTO), 2, ".", ","));
                    }
                    filtardetalle();

                    
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

    function filtardetalle() {

        var VC = {};
        VC.TR_CODIGO = $("#MainContent_lblsolicitud").html();
        $.ajax({
            type: "POST",
            url: "AvancesTrabajos.aspx/ListarDetalle",
            data: '{VC: ' + JSON.stringify(VC) + '}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {

                if (data.d.length > 0) {
                    var row = $("[id*=GridView1] tr:last-child").clone(true);
                    $("[id*=GridView1] tr").not($("[id*=GridView1] tr:first-child")).remove();

                    for (var i = 0; i < data.d.length; i++) {

                        $("td", row).eq(0).html(data.d[i].ACUMULADO);
                        $("td", row).eq(1).html(data.d[i].NIVEL_AVANCE);
                        $("td", row).eq(2).html(moment(data.d[i].FECHA).format("DD/MM/YYYY"));
                       // $("td", row).eq(3).html(data.d[i].MONTO);

                        $("[id*=GridView1]").append(row);
                        row = $("[id*=GridView1] tr:last-child").clone(true);
                    }

                } else {
                    var row = $("[id*=GridView1] tr:last-child").clone(true);
                    $("[id*=GridView1] tr").not($("[id*=GridView1] tr:first-child")).remove();

                    $("td", row).eq(2).html("");
                    $("td", row).eq(0).html("");
                    $("td", row).eq(1).html("");
                    $("td", row).eq(4).html("");

                    $("[id*=GridView1]").append(row);
                    alert("no se encontro registro");
                }
                recorregrid();
            },
            error: function (response) {
                if (response.length != 0)
                    alert(response);
            }
        });
     

    }
         function recorregrid() {
                contarndw = 0;
            subtt = 0; fecha = ""; acum = 0;
            sumasub = 0;           
          
            var gridView = document.getElementById("<%=GridView1.ClientID %>");

            for (var t = 1; t < gridView.rows.length; t++) {
                var inputs = gridView.rows[t].getElementsByTagName('input');
                fecha = gridView.rows[t].cells[2];
                acum = gridView.rows[t].cells[0];

                $("#MainContent_lblmonto").html(sumasub);
                if (t==1){
                    $("#MainContent_lblfechat").html(fecha.innerHTML);
                    $("#MainContent_lblacumulado").html(acum.innerHTML);
                }
            }

        }
            

    $(".btgrabar").click(function () { //  se debe colocar dentrp de una funcion 
        var fecemi = moment($("#MainContent_txtfechad").val(), "DD/MM/YYYY");
        fecemi = fecemi == null ? null : new Date(fecemi);

        var fecem = moment($("#MainContent_lblfechat").html(), "DD/MM/YYYY");
        fecem = fecem == null ? null : new Date(fecem);
        if (Number($("#MainContent_lblacumulado").html())<100)
        { 

            if ((Number($("#MainContent_txtacumulado").val())>Number($("#MainContent_lblacumulado").html())) )
            {
                // 
                if ((Number($("#MainContent_txtacumulado").val())) <= 100) {

               if ($("#MainContent_lblfechat").html() == "") {
                    iNSERTAdETALLE();
                    $("#MainContent_txtfechad").val("");
                    $("#MainContent_txtacumulado").val("");
                    $("#MainContent_txtnivelavance").val("");

                }
                else {
                    if (fecemi > fecem) {

                        iNSERTAdETALLE();
                        $("#MainContent_txtfechad").val("");
                        $("#MainContent_txtacumulado").val("");
                        $("#MainContent_txtnivelavance").val("");
                    }
                    else {
                        alert("Debe ingresar una fecha mayor a: " + $("#MainContent_lblfechat").html())
                    }
                }
            }
            else {
                    alert("El acumulado no debe ser mayor de 100");
            }
        }
            else {
                alert("No puede ingresar un acumulado menor o igual a: " + $("#MainContent_lblacumulado").html());
               
            }

        }
        else {
            alert("El trabajo ha sido concluido, no es posible agregar mas avances");
        }
    });
         

 function iNSERTAdETALLE() {
     var DETA = {};
     var fecemi = moment($("#MainContent_txtfechad").val(), "DD/MM/YYYY");
     fecemi = fecemi == null ? null : new Date(fecemi);
              DETA.ACUMULADO = $("#MainContent_txtacumulado").val();
              DETA.FECHA = fecemi;
              DETA.NIVEL_AVANCE = $("#MainContent_txtnivelavance").val();
              DETA.TR_CODIGO = $("#MainContent_lblsolicitud").html();

              $.ajax({
                  type: "POST",
                  url: "AvancesTrabajos.aspx/InsertaDet",
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

              if (Number(DETA.ACUMULADO) == 100) {
                  Finalizar();
                  
              }
                  filtardetalle();
               
 }

 function Finalizar() {

             var DETA = {};    
             DETA.FINALIZADO = "S";
             DETA.TR_CODIGO = $("#MainContent_lblsolicitud").html();

             $.ajax({

                 type: "POST",
                 url: "AvancesTrabajos.aspx/ActualizaFinalizado",
                 data: '{DETA: ' + JSON.stringify(DETA) + '}',
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 async: false,
                 success: function (response) {
                    // alert("Registro Grabado");

                 },
                 error: function (response) {
                     if (response.length != 0)
                         //alert(response);
                         console.table(response);
                 }

             });
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
                height: 40px;
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
            .auto-style5 {
                width: 74px;
            }
            .auto-style6 {
                width: 72px;
            }
            .auto-style8 {
                width: 798px;
            }
            .auto-style9 {
                width: 88px;
            }
            .auto-style10 {
                width: 50px;
            }
            .auto-style11 {
                width: 65px;
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
                    <asp:Button ID="btnbuscar" runat="server" Text="Buscar" Width="58px" OnClick="btnbuscar_Click" />
                   
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

                        <asp:BoundField DataField="ACUMULADO" HeaderText="ACUMULADO" DataFormatString="{0:F2}" >
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
                <td class="auto-style1"> Control Activos&nbsp; :</td> <td>
                <asp:Label ID="lblactivos" runat="server"></asp:Label>
                </td>
                               
                 
            </tr>
             <tr>
                 <td class="auto-style6"> Moneda&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</td>
                 <td>
                     <asp:Label ID="lblmoneda" runat="server"></asp:Label>
                </td>
             </tr>
             <tr>
                 <td class="auto-style5"> Presupuesto&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</td>
                 <td>
                     <asp:Label ID="lblpresupuesto" runat="server"></asp:Label>
                &nbsp;&nbsp;&nbsp
                </td>
                 <td class="auto-style9">% Adicinal&nbsp;&nbsp;&nbsp;:</td>
                 <td>
                     <asp:Label ID="lbladicional" runat="server"></asp:Label>
                 &nbsp;&nbsp;&nbsp
                </td>
                  <td class="auto-style9">Total&nbsp;&nbsp;&nbsp;:</td>
                 <td>
                     <asp:Label ID="lbltotal" runat="server"></asp:Label>
                
                </td>
             </tr>
            
             </table>
        <table>

                           
            <tr>
                <td class="auto-style1"> Fecha Registro&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td> <td>
                    <asp:Label ID="lblfecha" runat="server"></asp:Label>
                    
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
            <tr> <td class="auto-style8">DETALLE DE AVANCES</td></tr>
            </table>
        <table> 
            <tr>
                <td>Acumulado</td><td>
                <asp:TextBox ID="txtacumulado" runat="server" Width="85px"></asp:TextBox></td>
                <td>Nivel Avance</td><td><asp:TextBox ID="txtnivelavance" runat="server" Width="54px"></asp:TextBox></td>
                <td>Fecha</td><td><asp:TextBox ID="txtfechad" runat="server"></asp:TextBox></td>
               
                <td>
                    <input id="btngraba" type="button" value="Grabar" class="btgrabar"/></td>
            </tr>
        </table>

          <fieldset style="background-color: #99CCFF">
        <table>
            <tr>

                <td>
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" Font-Size="Smaller" Width="653px">
                    <Columns>
                        <asp:BoundField HeaderText="ACUMULADO" DataField="ACUMULADO" />
                        <asp:BoundField DataField="NIVEL_AVANCE" HeaderText="NIVEL AVANCE" />

                        <asp:BoundField DataField="FECHA" HeaderText="FECHA" />

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
                 <td>Acumulado</td>
                <td>
                    
                    &nbsp;<asp:Label ID="lblacumulado" runat="server" Text=""></asp:Label>
                 </td>
                 <td>Fecha</td>
                  <td>
                   
                      &nbsp;<asp:Label ID="lblfechat" runat="server"></asp:Label>
                 </td>
                                 
            </tr>
        </table>

    </div>

</asp:Content>
