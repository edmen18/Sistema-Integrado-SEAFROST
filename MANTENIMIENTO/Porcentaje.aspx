<%@ Page Title="Porcentaje" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Porcentaje.aspx.cs" Inherits="Porcentaje" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
<script type="text/javascript">
    $(function () {
        $("#MainContent_txtfecha").datepicker();
        UHTML.id = 'MainContent';
        $(".btadd").click(function () { //  se debe colocar dentrp de una funcion 

            if (recorregridaux().valor=="I") {
                $("#dvdetalle").dialog('open');
                $("#MainContent_txtindicador").val("G");
                $("#MainContent_txtusuario").val($("#MainContent_lblusuario").html());
                $("#MainContent_txtestado").val("A");
            }
            else {
                alert("Ya hay un valor de porcentaje activo, si desea agrgar uno nuevo , elimine el vigente");
            }
         });


        $('#dvdetalle').dialog({
            autoOpen: false,
            modal: true,
            resizable: true,
            width: 300,
            heigth: 100,
            title: 'Registro y Actualización',
            close: function (event, ui) {
                limpiardatos();
                //filtarsolicitudes();
            },
        });

         function recorregridaux() {
            subtt = 0; acum = 0;
            sumasub = 0;
            var valor = "I";
          
            var gridView = document.getElementById("<%=gvordencompra.ClientID %>");

            for (var t = 1; t < gridView.rows.length; t++) {
                var inputs = gridView.rows[t].getElementsByTagName('input');

                cellPivot = gridView.rows[t].cells[2];
                subtt = cellPivot.innerHTML;
                if (subtt=="A") {
                    valor = "A";}
               }
            return { valor };
         }
        $(".btgrabar").click(function () {


            var DETA = {};
           
            monto = $("#MainContent_txtmonto").val();
            estado = $("#MainContent_txtestado").val();
            var fec1 = moment($("#MainContent_txtfecha").val(), "DD/MM/YYYY");
            fec1 = new Date(fec1);
            usuario = $("#MainContent_txtusuario").val();

           // DETA.PORC_CODIGO = codigo;
            DETA.PORC_MONTO = monto
            DETA.PORC_ESTADO = estado;
            DETA.PORC_FECHA = fec1;
            DETA.PORC_USU = usuario;

            Grabar(DETA);
            location.reload();
        });


        $(".bthabilitar").click(function () {
            if (recorregridaux().valor=="I") {

            var DETA = {};
            trp = $(this).parent().parent();
            codigo = $("td:eq(0)", trp).html();
            monto = $("td:eq(1)", trp).html();
            estado = $("td:eq(2)", trp).html();
            var fec1 = moment($("td:eq(3)", trp).html(), "DD/MM/YYYY");
            fec1 = new Date(fec1);
            usuario = $("td:eq(4)", trp).html();

            DETA.PORC_CODIGO = codigo;
            DETA.PORC_MONTO = monto
            DETA.PORC_ESTADO = "A";
            DETA.PORC_FECHA = fec1;
            DETA.PORC_USU = usuario;

            Eliminarbahia(DETA);
            location.reload();
            }
            else {
                alert("Ya hay un valor de porcentaje activo, si desea agrgar uno nuevo , elimine el vigente");
            }
        });



        $(".btdeshabilitar").click(function () {

            
            var DETA = {};
            trp = $(this).parent().parent();
            codigo = $("td:eq(0)", trp).html();
            monto = $("td:eq(1)", trp).html();
            estado = $("td:eq(2)", trp).html();
            var fec1 = moment($("td:eq(3)", trp).html(), "DD/MM/YYYY");
            fec1 = new Date(fec1);
            usuario = $("td:eq(4)", trp).html();
          
            DETA.PORC_CODIGO = codigo;
            DETA.PORC_MONTO = monto
            DETA.PORC_ESTADO = "I";
            DETA.PORC_FECHA = fec1;
            DETA.PORC_USU = usuario;
                      
            Eliminarbahia(DETA);
            location.reload();
           });


        function Eliminarbahia(DETA) {
            
            $.ajax({
                type: "POST",
                url: "Porcentaje.aspx/ActualizaAnticipo",
                data: '{DETA: ' + JSON.stringify(DETA) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (response) {
                    alert("Operacion Exitosa");
                },
                error: function (response) {
                    console.log(response);
                }
            });
        }

        


        function Grabar(DETA) {
           
            $.ajax({
                type: "POST",
                url: "Porcentaje.aspx/Insertar",
                data: '{DETA: ' + JSON.stringify(DETA) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (response) {
                    alert("Registro grabado");
                },
                error: function (response) {
                    console.log(response);
                }
            });
        }

    });

 </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <fieldset style="background-color: #99CCFF">
        <legend style="font-weight: bold; background-color: #99CCFF;">
            <asp:Label ID="Label9" runat="server" Text="PORCENTAJES" Font-Bold="True" Font-Size="12pt"></asp:Label></legend>

        <table>
                        <tr>
                 <td>
                    <input id="btnnuevo" type="button" value="Nuevo" class="btadd" style="width: 80px; height: 28px; color: #003366"/></td>
                 <td>
                     <asp:Button ID="btexcel" class="btn" type="button" Style="width: 80px; height: 28px" runat="server" Text="Excel" /> 
                 <asp:Label ID="lblusuario" runat="server" ForeColor="#66CCFF"></asp:Label>
                 </tr>
         </table>
        <table>
            <tr>
                <td>
                    &nbsp;</td>

            </tr>


        </table>
    </fieldset>


    <table>
        <tr>
            <td>
                 <div style=" overflow: auto;width: 650PX; height: 150PX">
                <asp:GridView ID="gvordencompra" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" >
                    <Columns>
                        <asp:BoundField DataField="PORC_CODIGO" HeaderText="CÓDIGO" />
                        <asp:BoundField DataField="PORC_MONTO" HeaderText="MONTO" />

                        <asp:BoundField DataField="PORC_ESTADO" HeaderText="ESTADO" />
                        <asp:BoundField DataField="PORC_FECHA" HeaderText="FECHA" />
                        <asp:BoundField DataField="PORC_USU" HeaderText="USUARIO" />

                        <asp:TemplateField HeaderText="EDITAR">
                      <ItemTemplate>
                                <div class="bteditar" style="text-align: center">
                                    <img alt="" src="../../Images/edit.png" width="25" style="cursor: pointer" />
                                    <%--<asp:ImageButton ID="imbeliminar" runat="server" ImageUrl="~/Images/Message_Error.png" Width="25px" OnClick="ib_eliminar_Click" onclientclick="javascript:return confirm('Esta Seguro?')"/>--%>
                                </div>
                            </ItemTemplate></asp:TemplateField>

                        <asp:TemplateField HeaderText="ELIMINAR">
                              <ItemTemplate>
                                <div class="btdeshabilitar" style="text-align: center">
                                    <img alt="" src="../../Images/desaprob.png" width="25" style="cursor: pointer" />
                                    <%--<asp:ImageButton ID="imbeliminar" runat="server" ImageUrl="~/Images/Message_Error.png" Width="25px" OnClick="ib_eliminar_Click" onclientclick="javascript:return confirm('Esta Seguro?')"/>--%>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="HABILITAR"> <ItemTemplate>
                                <div class="bthabilitar" style="text-align: center">
                                    <img alt="" src="../../Images/valid.png" width="25" style="cursor: pointer" />
                                    <%--<asp:ImageButton ID="imbeliminar" runat="server" ImageUrl="~/Images/Message_Error.png" Width="25px" OnClick="ib_eliminar_Click" onclientclick="javascript:return confirm('Esta Seguro?')"/>--%>
                                </div>
                            </ItemTemplate></asp:TemplateField>

                    </Columns>
                     <%--<PagerStyle HorizontalAlign = "Right" CssClass = "GridPager" />--%>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" CssClass = "GridPager"/>
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
    <%--<PagerStyle HorizontalAlign = "Right" CssClass = "GridPager" />--%>
    
    <div id="dvdetalle" style="display:none" >
       
        <table>
            <tr>
                <td>Código</td>

                <td>
                    <asp:TextBox ID="txtmatricula" runat="server" Width="157px" Enabled="False"></asp:TextBox>
                </td>
            </tr>

             <tr>
                <td class="auto-style1">Monto</td> 
                <td>
                    <asp:TextBox ID="txtmonto" runat="server" Width="157px"></asp:TextBox>
                 </td>
                
            </tr>
             <tr>
                <td class="auto-style1">Fecha</td> 
                <td>
                    <asp:TextBox ID="txtfecha" runat="server" Width="157px"  placeholder="00/00/0000"></asp:TextBox>
                 </td>
                
            </tr>
             <tr>
                <td class="auto-style1">Usuario</td> 
                <td>
                    <asp:TextBox ID="txtusuario" runat="server" Width="157px" Enabled="False"></asp:TextBox>
                 </td>
                
            </tr>
             <tr>
                <td class="auto-style1">Estado</td> 
                <td>
                    <asp:TextBox ID="txtestado" runat="server" Width="157px" Enabled="False"></asp:TextBox>
                 </td>
                
            </tr>
            
             
                         
            <tr>
                <td>

                </td>
                 <td>
                     <%--<PagerStyle HorizontalAlign = "Right" CssClass = "GridPager" />--%>

                     <input id="btngrabar" type="button" value="Grabar" class="btgrabar" style="width: 80px; height: 30px; color: #003366; background-color: #99CCFF"/>
                     <asp:TextBox ID="txtindicador" runat="server" Width="0px" BorderStyle="None"></asp:TextBox>
            </td> </tr>
        </table>
     </div>
</asp:Content>



