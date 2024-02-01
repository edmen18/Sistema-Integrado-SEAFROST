<%@ Page Title="Embarcaciones" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Embarcaciones.aspx.cs" Inherits="Embarcaciones" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <%--<asp:ImageButton ID="imbeliminar" runat="server" ImageUrl="~/Images/Message_Error.png" Width="25px" OnClick="ib_eliminar_Click" onclientclick="javascript:return confirm('Esta Seguro?')"/>--%>
  
      <script type="text/javascript">
          $(function () {
              UHTML.id = 'MainContent';
              $(".btadd").click(function () { //  se debe colocar dentrp de una funcion 
                  $("#dvdetalle").dialog('open');
                  $("#MainContent_txtindicador").val("G");
                  $("#MainContent_txtmatricula").attr("disabled", false);
              });

            $("#MainContent_txtbahia").autocomplete(
             {
             source: function (request, response) {
            $.ajax({
                url: "Embarcaciones.aspx/LISTARDATOSAUTOCOMPLETE",
                data: "{ 'com': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            value: item.E_MATRIC + "-" + item.E_NOMBRE,
                            id: item.E_MATRIC,
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

            $('#MainContent_txtidbahia').val(str);


        }
             });

            $(".btgrabar").click(function () {
                Insertarbahia();

            });

            function limpiardatos() {

               $("#MainContent_txtmatricula").val("");
               $("#MainContent_txtnombre").val("");
               $("#MainContent_txtresolucion").val("");
               $("#MainContent_txtcbm3").val("");
               $("#MainContent_txtcbtm").val("");
               $("#MainContent_txtespecie").val("");
               $("#MainContent_txtpermisopesca").val("");
               $("#MainContent_txtpermisozarpe").val("");
            }

            function Insertarbahia() {

                var DETA = {};
                DETA.E_MATRIC = $("#MainContent_txtmatricula").val();
                DETA.E_NOMBRE = $("#MainContent_txtnombre").val();
                DETA.E_RESOLU = $("#MainContent_txtresolucion").val();
                DETA.E_CABOM3 = $("#MainContent_txtcbm3").val();
                DETA.E_CABOTM = $("#MainContent_txtcbtm").val();
                DETA.E_ESPCHD = $("#MainContent_txtespecie").val();
                DETA.E_PERPES = $("#MainContent_txtpermisopesca").val();
                DETA.E_PERZAR = $("#MainContent_txtpermisozarpe").val();
                DETA.E_ESTADO = "AL";
                
                var f = new Date();
                DETA.E_FECCRE = f;
                if ((DETA.E_MATRIC == "") || (DETA.E_NOMBRE == "")) {
                    alert("Complete los Datos antes de continuar");

                }
                else {

                    if ($("#MainContent_txtindicador").val() == "G") {
                        DETA.E_USUCRE = $("#MainContent_lblusuario").html();

                        $.ajax({

                            type: "POST",
                            url: "Embarcaciones.aspx/Insertar",
                            data: '{DETA: ' + JSON.stringify(DETA) + '}',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            async: false,
                            success: function (response) {
                                alert("Registro Grabado");
                                location.reload(true);
                                $("#dvdetalle").dialog('close');
                            },
                            error: function (response) {
                                if (response.length != 0)
                                    console.table(response);
                            }

                        });

                    }

                    if ($("#MainContent_txtindicador").val() == "A") {
                        DETA.E_USUMOD = $("#MainContent_lblusuario").html();

                        $.ajax({

                            type: "POST",
                            url: "Embarcaciones.aspx/ActualizaAnticipo",
                            data: '{DETA: ' + JSON.stringify(DETA) + '}',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            async: false,
                            success: function (response) {
                                alert("Registro Actualizado");
                                $("td:eq(0)", trp).html($("#MainContent_txtmatricula").val());
                                $("td:eq(1)", trp).html($("#MainContent_txtnombre").val());
                                $("td:eq(2)", trp).html($("#MainContent_txtresolucion").val());
                                $("td:eq(3)", trp).html($("#MainContent_txtpermisopesca").val());
                                $("td:eq(4)", trp).html($("#MainContent_txtpermisozarpe").val());
                                $("td:eq(5)", trp).html($("#MainContent_txtespecie").val());
                                $("td:eq(6)", trp).html($("#MainContent_txtcbm3").val());
                                $("td:eq(7)", trp).html($("#MainContent_txtcbtm").val());
                               $("#dvdetalle").dialog('close');
                            },
                            error: function (response) {
                                if (response.length != 0)
                                    console.table(response);
                            }

                        });
                    }

                   }

            }



            $(".btaddact").click(function () { //  se debe colocar dentrp de una funcion 
                $("#dvdetalle").dialog('open');
                $("#MainContent_txtindicador").val("A");

                trp = $(this).parent().parent();
                id = $("td:eq(0)", trp).html();
                $("#MainContent_txtmatricula").val(id);
                nombre = $("td:eq(1)", trp).html();
                $("#MainContent_txtnombre").val(nombre);
                apellido = $("td:eq(2)", trp).html();
                $("#MainContent_txtresolucion").val(apellido);

                telefono = $("td:eq(3)", trp).html();
                $("#MainContent_txtpermisopesca").val(telefono);
                celular = $("td:eq(4)", trp).html();
                $("#MainContent_txtpermisozarpe").val(celular);
                glosa1 = $("td:eq(5)", trp).html();
                $("#MainContent_txtespecie").val(glosa1);
                glosa2 = $("td:eq(6)", trp).html();
                $("#MainContent_txtcbm3").val(glosa2);
                glosa3 = $("td:eq(7)", trp).html();
                $("#MainContent_txtcbtm").val(glosa3);
                $("#MainContent_txtmatricula").attr("disabled", true);


                if ($("#MainContent_txtindicador").val() == "A") {

                }

            });
            $('#dvdetalle').dialog({
                autoOpen: false,
                modal: true,
                resizable: true,
                width: 600,
                heigth: 100,
                title: 'Registro y Actualización',
                close: function (event, ui) {
                    limpiardatos();
                    //filtarsolicitudes();
                },


            });
            $(".bteliminar").click(function () {
                var DETA = {};
                trp = $(this).parent().parent();
                id = $("td:eq(0)", trp).html();
                 nombre = $("td:eq(1)", trp).html();
                 apellido = $("td:eq(2)", trp).html();
                telefono = $("td:eq(3)", trp).html();
                celular = $("td:eq(4)", trp).html();
                glosa1 = $("td:eq(5)", trp).html();
                glosa2 = $("td:eq(6)", trp).html();
                glosa3 = $("td:eq(7)", trp).html();
                estado = $("td:eq(8)", trp).html();
               
                DETA.E_MATRIC =id;
                DETA.E_NOMBRE = nombre
                DETA.E_RESOLU = apellido;
                DETA.E_CABOM3 = glosa2;
                DETA.E_CABOTM = glosa3;
                DETA.E_ESPCHD = glosa1;
                DETA.E_PERPES = telefono;
                DETA.E_PERZAR = celular;
                DETA.E_ESTADO = "BA";
               
                var f = new Date();
                DETA.E_FECMOV = f;
                DETA.E_USUCRE = $("#MainContent_lblusuario").html();
                if (estado == "BA") {
                    alert("Este Item ya fue eliminado");
                }
                else {
                   
                    Eliminarbahia(DETA);
                   }
            });
            $(".bthabilitar").click(function () {
                var DETA = {};
                trp = $(this).parent().parent();
                id = $("td:eq(0)", trp).html();
                nombre = $("td:eq(1)", trp).html();
                apellido = $("td:eq(2)", trp).html();
                telefono = $("td:eq(3)", trp).html();
                celular = $("td:eq(4)", trp).html();
                glosa1 = $("td:eq(5)", trp).html();
                glosa2 = $("td:eq(6)", trp).html();
                glosa3 = $("td:eq(7)", trp).html();
                estado = $("td:eq(8)", trp).html();

                DETA.E_MATRIC = id;
                DETA.E_NOMBRE = nombre
                DETA.E_RESOLU = apellido;
                DETA.E_CABOM3 = glosa2;
                DETA.E_CABOTM = glosa3;
                DETA.E_ESPCHD = glosa1;
                DETA.E_PERPES = telefono;
                DETA.E_PERZAR = celular;
                DETA.E_ESTADO = "AL";


                var f = new Date();
                DETA.E_FECMOV = f;
                DETA.E_USUMOD = $("#MainContent_lblusuario").html();
                if (estado == "AL") {
                    alert("Este Item ya se encuentra activo");
                }
                else {
                    Eliminarbahia(DETA);
                }


            });


            function Eliminarbahia(DETA) {
                //console.log(DETA);
                $.ajax({
                    type: "POST",
                    url: "Embarcaciones.aspx/ActualizaAnticipo",
                    data: '{DETA: ' + JSON.stringify(DETA) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        if (DETA.E_ESTADO == "BA") {
                            alert("Registro Eliminado");
                            $("td:eq(8)", trp).html("BA");
                        }
                        else {
                            alert("Registro Habilitado");
                            $("td:eq(8)", trp).html("AL");
                        }

                    },
                    error: function (response) {
                        console.log(response);
                        //alert(response);
                    }

                });

               // filtarincio();
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
            width: 67px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <fieldset style="background-color: #99CCFF">
        <legend style="font-weight: bold; background-color: #99CCFF;">
            <asp:Label ID="Label9" runat="server" Text="LISTADO DE EMBARCACIONES" Font-Bold="True" Font-Size="12pt"></asp:Label></legend>

        <table>
            <tr>
                <td>Embarcación</td>
                <td colspan="3">
                    <asp:TextBox ID="txtbahia" runat="server" Width="300"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtidbahia" runat="server" Width="100"></asp:TextBox>
                </td>
                
                </tr>
             <tr>
                
                  <td>
                      <%--style="display:none"--%>
                       <asp:Button ID="btbuscar" class="btn" type="button" Style="width: 80px; height: 28px" runat="server" Text="Buscar" OnClick="btbuscar_Click" />                </td>
                  <td>
                    <input id="btnnuevo" type="button" value="Nuevo" class="btadd" style="width: 80px; height: 28px; color: #003366"/></td>
                 <td>
                     <asp:Button ID="btexcel" class="btn" type="button" Style="width: 80px; height: 28px" runat="server" Text="Excel" OnClick="btexcel_Click" /> 
                <asp:Label ID="lblacceso" runat="server" ForeColor="#66CCFF"></asp:Label>
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
                 <div style=" overflow: auto;width: 1300px; height: 480px">
                <asp:GridView ID="gvordencompra" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" >
                    <Columns>
                        <asp:BoundField DataField="E_MATRIC" HeaderText="MATRICULA" />
                        <asp:BoundField DataField="E_NOMBRE" HeaderText="NOMBRE" />

                        <asp:BoundField DataField="E_RESOLU" HeaderText="RESOLUCION" />
                        <asp:BoundField DataField="E_PERPES" HeaderText="PER. PESCA" />
                        <asp:BoundField DataField="E_PERZAR" HeaderText="PER. ZARPE" />
                        <asp:BoundField DataField="E_ESPCHD" HeaderText="ESPECIE" ItemStyle-Width="50px">
                            <FooterStyle ForeColor="Black" />

                            <ItemStyle Width="50px"></ItemStyle>
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="E_CABOM3" HeaderText="CAP. BODEGA M3" />

                        <asp:BoundField DataField="E_CABOTM" HeaderText="CAP. BODEGA TM" />

                        <asp:BoundField DataField="E_ESTADO" HeaderText="ESTADO" />

                        <asp:TemplateField HeaderText="EDITAR">

                            <ItemTemplate>
                                <div class="btaddact" style="text-align: center">
                                    <img alt="" src="../../Images/edit.png" width="25" style="cursor: pointer" />
                                    <%--<asp:ImageButton ID="imbeliminar" runat="server" ImageUrl="~/Images/Message_Error.png" Width="25px" OnClick="ib_eliminar_Click" onclientclick="javascript:return confirm('Esta Seguro?')"/>--%>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="ELIMINAR">
                              <ItemTemplate>
                                <div class="bteliminar" style="text-align: center">
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
     <%--style="display:none"--%>
    
    <div id="dvdetalle"  >
       
        <table>
            <tr>
                <td>Matricula</td>

                <td>
                    <asp:TextBox ID="txtmatricula" runat="server" Width="157px"></asp:TextBox>
                </td>
            </tr>

             <tr>
                <td class="auto-style1">Nombre</td> 
                <td>
                    <asp:TextBox ID="txtnombre" runat="server" Width="369px"></asp:TextBox>
                 </td>
                
            </tr>
             <tr>
                <td class="auto-style1">Resolución</td> 
                <td>
                    <asp:TextBox ID="txtresolucion" runat="server" Width="369px"></asp:TextBox>
                 </td>
                
            </tr>
             <tr>
                <td class="auto-style1">Permiso Pesca</td> 
                <td>
                    <asp:TextBox ID="txtpermisopesca" runat="server" Width="369px"></asp:TextBox>
                 </td>
                
            </tr>
             <tr>
                <td class="auto-style1">Permiso Zarpe</td> 
                <td>
                    <asp:TextBox ID="txtpermisozarpe" runat="server" Width="369px"></asp:TextBox>
                 </td>
                
            </tr>
             <tr>
                <td class="auto-style1">Especie</td> 
                <td>
                    <asp:TextBox ID="txtespecie" runat="server" Width="369px"></asp:TextBox>
                 </td>
                
            </tr>
             <tr>
                <td class="auto-style1">Cap. Bodega M3</td> 
                <td>
                    <asp:TextBox ID="txtcbm3" runat="server" Width="369px"></asp:TextBox>
                 </td>
                
            </tr>
              <tr>
                <td class="auto-style1">Cap. Bodega TM</td> 
                <td>
                    <asp:TextBox ID="txtcbtm" runat="server" Width="369px"></asp:TextBox>
                 </td>
                
            </tr>
            
            <tr>
                <td>

                </td>
                 <td>
                     <%--<asp:Button ID="btgrabar" class="btn" type="button" Style="width: 80px; " runat="server" Text="Grabar" OnClick="btgrabar_Click" />                </td>--%>

                     <input id="btngrabar" type="button" value="Grabar" class="btgrabar" style="width: 80px; height: 30px; color: #003366; background-color: #99CCFF"/>
                     <asp:TextBox ID="txtindicador" runat="server" Width="0px" BorderStyle="None"></asp:TextBox>
            </td> </tr>
        </table>
     </div>
</asp:Content>













