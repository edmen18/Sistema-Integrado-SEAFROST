<%@ Page Title="Maestro" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Maestro.aspx.cs" Inherits="Maestro" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link type="text/css" href="../CSS/base.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {

            $(".btadd").click(function () { //  se debe colocar dentrp de una funcion 
                $("#dvdetalle").dialog('open');
                $("#MainContent_txtindicador").val("G");
                $("#MainContent_txtcodigo").attr("disabled", false);
               
            });
            $(".btaddnew").click(function () { //  se debe colocar dentrp de una funcion 
                $("#dvdetalle").dialog('open');
                $("#MainContent_txtindicador").val("G");
                $("#MainContent_txtcodigo").val( $("#MainContent_txtcod").val());
                $("#MainContent_txtcodigo").attr("disabled", true);
            });

            $("#MainContent_txtbahia").autocomplete(
            {
                source: function (request, response) {
                    $.ajax({
                        url: "Maestro.aspx/LISTARDATOSAUTOCOMPLETE",
                        data: "{ 'com': '" + request.term + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    value: item.AF_COD + "-" + item.AF_CCLAVE + "-" + item.AF_TDESCRI1,
                                    id: item.AF_COD + "-" + item.AF_CCLAVE,
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
            $('#dvdetalle').dialog({
                autoOpen: false,
                modal: true,
                resizable: true,
                width: 600,
                heigth: 100,
                title: 'Registro y Actualización',
                close: function (event, ui) {
                    limpiardatos();
              },
            });
            $('#detalle1').dialog({
                autoOpen: false,
                modal: true,
                resizable: true,
                width: 600,
                heigth: 100,
               title: 'Detalle',
                close: function (event, ui) {
                    limpiardatos();
                },

            });
            $(".CARGARDETALLE").click(function () {
                $("#detalle1").dialog('open');
                trp = $(this).parent().parent();
                id = $("td:eq(0)", trp).html();
                clave = $("td:eq(1)", trp).html();
                FiltarParametros(id,clave);
            }),

            $(".btgrabar").click(function () {
                var url1 = "";
                if ((document.getElementById('<%=txtcod.ClientID%>').value).length == 0) {
                    url1 = "Maestro.aspx/Insertar"
                }
                else {
                    url1 = "Maestro.aspx/Insertardet"
                }
                Insertarbahia(url1);

            });

            function Insertarbahia(url1) {

                var DETA = {};
                DETA.AF_COD = $("#MainContent_txtcodigo").val().trim();
                DETA.AF_TDESCRI1 = $("#MainContent_txtdescripcion1").val();
                DETA.AF_TDESCRI2 = $("#MainContent_txtdescripcion2").val();
                DETA.AF_TDESCRI3 = $("#MainContent_txtdescripcion3").val();
                DETA.AF_ESTADO = "A";
                DETA.AF_CCLAVE = $("#MainContent_txtclave").val();
                
                if ((DETA.AF_COD == "") || (DETA.AF_CCLAVE == "")) {
                    alert("Complete los Datos antes de continuar");

                }
                else {

                    if ($("#MainContent_txtindicador").val() == "G") {
                        DETA.AF_CUSUCRE = $("#MainContent_lblusuario").html();
                      
                        var f = new Date();
                        DETA.AF_DFECCRE = f;

                        $.ajax({

                            type: "POST",
                            url: url1,
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
                        DETA.AF_CUSUMOD = $("#MainContent_lblusuario").html();
                        DETA.AF_CCLAVE = $("#MainContent_txtclave").val();
                        var f = new Date();
                        DETA.AF_DFECMOD = f;

                        $.ajax({

                            type: "POST",
                            url: "Maestro.aspx/ActualizaAnticipo",
                            data: '{DETA: ' + JSON.stringify(DETA) + '}',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            async: false,
                            success: function (response) {
                                alert("Registro Actualizado");

                                $("td:eq(0)", trp).html($("#MainContent_txtcodigo").val());
                                $("td:eq(1)", trp).html($("#MainContent_txtclave").val());
                                $("td:eq(2)", trp).html($("#MainContent_txtdescripcion1").val());
                                $("td:eq(3)", trp).html($("#MainContent_txtdescripcion2").val());
                                $("td:eq(4)", trp).html($("#MainContent_txtdescripcion3").val());
                               
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
            function limpiardatos() {

                $("#MainContent_txtcodigo").val("");
               $("#MainContent_txtclave").val("");
                $("#MainContent_txtdescripcion1").val("");
               $("#MainContent_txtdescripcion2").val("");
               $("#MainContent_txtdescripcion3").val("");
               $("#MainContent_txtcod").val("");
            }

            $(".btaddact").click(function () { //  se debe colocar dentrp de una funcion 
                $("#dvdetalle").dialog('open');
                $("#MainContent_txtindicador").val("A");
                $("#MainContent_txtcodigo").attr("disabled", true);
             
                trp = $(this).parent().parent();
                id = $("td:eq(0)", trp).html();
                $("#MainContent_txtcodigo").val(id);
                nombre = $("td:eq(1)", trp).html();
                $("#MainContent_txtclave").val(nombre);
                apellido = $("td:eq(2)", trp).html();
                $("#MainContent_txtdescripcion1").val(apellido);

                telefono = $("td:eq(3)", trp).html();
                $("#MainContent_txtdescripcion2").val(telefono);
                celular = $("td:eq(4)", trp).html();
                $("#MainContent_txtdescripcion3").val(celular);
                
            });
            function generar() {
                var DETA = {};
                DETA.AF_COD = $("#MainContent_txtcodigo").val();

                $.ajax({

                    type: "POST",
                    url: "Maestro.aspx/generar",
                    data: '{DETA: ' + JSON.stringify(DETA) + '}',
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

            function FiltarParametros(id, clave) {
                var VC = {};
                VC.AF_COD = id;
                VC.AF_CCLAVE = clave;
                $("#MainContent_txtcod").val(VC.AF_CCLAVE);
              //  alert(id + "-" + clave);

                $.ajax({

                    type: "POST",
                    url: "Maestro.aspx/LISTARDETALLE",
                    data: '{com: ' + JSON.stringify(VC) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        if (data.d.length > 0) {
                            var row = $("[id*=GridView1] tr:last-child").clone(true);
                            $("[id*=GridView1] tr").not($("[id*=GridView1] tr:first-child")).remove();

                            for (var i = 0; i < data.d.length; i++) {
                                $("td", row).eq(0).html(data.d[i].AF_COD);
                                $("td", row).eq(1).html(data.d[i].AF_CCLAVE);
                                $("td", row).eq(2).html(data.d[i].AF_TDESCRI1);
                                $("td", row).eq(3).html(data.d[i].AF_TDESCRI2);
                                $("td", row).eq(4).html(data.d[i].AF_TDESCRI3);
                                $("[id*=GridView1]").append(row);
                                row = $("[id*=GridView1] tr:last-child").clone(true);
                            }
                        } else {
                            var row = $("[id*=GridView1] tr:last-child").clone(true);
                            $("[id*=GridView1] tr").not($("[id*=GridView1] tr:first-child")).remove();

                            $("td", row).eq(0).html("");
                            $("td", row).eq(1).html("");
                            $("td", row).eq(2).html("");
                            $("td", row).eq(3).html("");
                            $("td", row).eq(4).html("");
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
            
        });
    </script>
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
                    <input id="btnnuevo" type="button" value="Nuevo" class="btadd" style="width: 80px; height: 30px; color: #003366; background-color: #C0C0C0"/></td>
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
                 
 <div style=" overflow: auto;width: 520px; height: 480px">
                <asp:GridView ID="gvordencompra" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" >
                    <Columns>
                        <asp:BoundField DataField="AF_COD" HeaderText="CODIGO" />
                        <asp:BoundField DataField="AF_CCLAVE" HeaderText="CLAVE" />

                        <asp:BoundField DataField="AF_TDESCRI1" HeaderText="DESCRIPCION" />
                        <asp:BoundField DataField="AF_TDESCRI2" HeaderText="DESCRIPCION1" />
                        <asp:BoundField DataField="AF_TDESCRI3" HeaderText="DESCRIPCION2" />

                        <asp:TemplateField HeaderText="EDITAR">

                            <ItemTemplate>
                                <div class="btaddact" style="text-align: center">
                                    <img alt="" src="../../Images/edit.png" width="25" style="cursor: pointer" />
                                    <%--<asp:ImageButton ID="imbeliminar" runat="server" ImageUrl="~/Images/Message_Error.png" Width="25px" OnClick="ib_eliminar_Click" onclientclick="javascript:return confirm('Esta Seguro?')"/>--%>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="VER_DETALLE"><ItemTemplate>
                                <div class="CARGARDETALLE" style="text-align: center">
                                    <img alt="" src="../../Images/Detalle.png" width="25" style="cursor: pointer" />
                                    <%--<asp:ImageButton ID="imbeliminar" runat="server" ImageUrl="~/Images/Message_Error.png" Width="25px" OnClick="ib_eliminar_Click" onclientclick="javascript:return confirm('Esta Seguro?')"/>--%>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
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
                <td>Código</td>

                <td>
                    <asp:TextBox ID="txtcodigo" runat="server" Width="157px"></asp:TextBox>
                </td>
            </tr>

             <tr>
                <td class="auto-style1">Clave</td> 
                <td>
                    <asp:TextBox ID="txtclave" runat="server" Width="369px"></asp:TextBox>
                 </td>
                
            </tr>
             <tr>
                <td class="auto-style1">Descripción1</td> 
                <td>
                    <asp:TextBox ID="txtdescripcion1" runat="server" Width="369px"></asp:TextBox>
                 </td>
                
            </tr>
             <tr>
                <td class="auto-style1">Descripción2</td> 
                <td>
                    <asp:TextBox ID="txtdescripcion2" runat="server" Width="369px"></asp:TextBox>
                 </td>
                
            </tr>
             <tr>
                <td class="auto-style1">Descripción3</td> 
                <td>
                    <asp:TextBox ID="txtdescripcion3" runat="server" Width="369px"></asp:TextBox>
                 </td>
                
            </tr>
             
             
            
            <tr>
                <td>

                </td>
                 <td>
                     <input id="btngrabar" type="button" value="Grabar" class="btgrabar" style="width: 80px; height: 30px; color: #003366; background-color: #99CCFF"/>
                     <asp:TextBox ID="txtindicador" runat="server" Width="0px" BorderStyle="None"></asp:TextBox>
            </td> </tr>
        </table>
     </div>
    <div id="detalle1">
        <table>
            <tr>
                <td>
                     <input id="btnnew" type="button" value="Nuevo" class="btaddnew" style="width: 80px; height: 30px; color: #003366; background-color: #C0C0C0"/>
                    <asp:TextBox ID="txtcod" runat="server"></asp:TextBox>
                </td>

            </tr>

        </table>
         <div style=" overflow: auto;width: 520px; height: 200px">
                <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" >
                    <Columns>
                        <asp:BoundField DataField="AF_COD" HeaderText="CODIGO" />
                        <asp:BoundField DataField="AF_CCLAVE" HeaderText="CLAVE" />

                        <asp:BoundField DataField="AF_TDESCRI1" HeaderText="DESCRIPCION" />
                        <asp:BoundField DataField="AF_TDESCRI2" HeaderText="DESCRIPCION1" />
                        <asp:BoundField DataField="AF_TDESCRI3" HeaderText="DESCRIPCION2" />

                        <asp:TemplateField HeaderText="EDITAR">

                            <ItemTemplate>
                                <div class="btaddact" style="text-align: center">
                                    <img alt="" src="../../Images/edit.png" width="25" style="cursor: pointer" />
                                    <%--<asp:ImageButton ID="imbeliminar" runat="server" ImageUrl="~/Images/Message_Error.png" Width="25px" OnClick="ib_eliminar_Click" onclientclick="javascript:return confirm('Esta Seguro?')"/>--%>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
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
    </div>
</asp:Content>














