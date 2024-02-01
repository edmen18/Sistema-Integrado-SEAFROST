<%@ Page Title="Bahias" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Bahias.aspx.cs" Inherits="Bahias" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link type="text/css" href="../CSS/base.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {
            UHTML.id = 'MainContent';
            $(".btadd").click(function () { //  se debe colocar dentrp de una funcion 
                Operacion.iValida("txtcodigo", 1);
                Operacion.iValida("txtcelular", 1);
                Operacion.iValida("txttelefono", 1);
                $("#dvdetalle").dialog('open');
                $("#MainContent_txtindicador").val("G");
                $("#MainContent_txtcodigo").attr("disabled", false);
                
                

                if ($("#MainContent_txtindicador").val() == "G") {
                 
                }
            });
            $(".btaddact").click(function () { //  se debe colocar dentrp de una funcion 
                Operacion.iValida("txtcodigo", 1);
                Operacion.iValida("txtcelular", 1);
                Operacion.iValida("txttelefono", 1);
                $("#dvdetalle").dialog('open');
                $("#MainContent_txtindicador").val("A");

                trp = $(this).parent().parent();
                id = $("td:eq(0)", trp).html();
                $("#MainContent_txtcodigo").val(id);
                nombre = $("td:eq(1)", trp).html();
                $("#MainContent_txtnombres").val(nombre);
                apellido = $("td:eq(2)", trp).html();
                $("#MainContent_txtapellidos").val(apellido);

                telefono = $("td:eq(3)", trp).html();
                $("#MainContent_txttelefono").val(telefono);
                celular = $("td:eq(4)", trp).html();
                $("#MainContent_txtcelular").val(celular);
                glosa1 = $("td:eq(5)", trp).html();
                $("#MainContent_txtglosa1").val(glosa1);
                glosa2 = $("td:eq(6)", trp).html();
                $("#MainContent_txtglosa2").val(glosa2);

                $("#MainContent_txtcodigo").attr("disabled", true);

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

            $("#MainContent_txtbahia").autocomplete(
     {
         source: function (request, response) {
             $.ajax({
                 url: "Bahias.aspx/LISTARDATOSAUTOCOMPLETE",
                 data: "{ 'com': '" + request.term + "' }",
                 dataType: "json",
                 type: "POST",
                 contentType: "application/json; charset=utf-8",
                 dataFilter: function (data) { return data; },
                 success: function (data) {
                     response($.map(data.d, function (item) {
                         return {
                             value: item.ID + "-" + item.B_APELLIDOS + " " + item.B_NOMBRES,
                             id: item.ID,
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

            $(window).load(function () {
                filtarincio();

            });
            $(".btgrabar").click(function () {
                Insertarbahia();

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
                estado = $("td:eq(7)", trp).html();
                DETA.ID = id;
                DETA.B_NOMBRES = nombre;
                DETA.B_APELLIDOS = apellido;
                DETA.B_TEL_CONTACTO = telefono;
                DETA.B_CEL_CONTACTO = celular;
                DETA.B_GLOSA1 = glosa1;
                DETA.B_GLOSA2 = glosa2;
                DETA.B_ESTADO = "I";
                var f = new Date();
                DETA.B_FECHA_C = f;
                DETA.B_USUMOD = $("#MainContent_lblusuario").html();
                if (estado=="INACTIVO"){
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
                estado = $("td:eq(7)", trp).html();
                DETA.ID = id;
                DETA.B_NOMBRES = nombre;
                DETA.B_APELLIDOS = apellido;
                DETA.B_TEL_CONTACTO = telefono;
                DETA.B_CEL_CONTACTO = celular;
                DETA.B_GLOSA1 = glosa1;
                DETA.B_GLOSA2 = glosa2;
                DETA.B_ESTADO = "A";
                var f = new Date();
                DETA.B_FECHA_C = f;
                DETA.B_USUMOD = $("#MainContent_lblusuario").html();
                if (estado == "ACTIVO") {
                    alert("Este Item ya se encuentra activo");
                }
                else {
                    Eliminarbahia(DETA);
                }


            });
            function Insertarbahia() {

                var DETA = {};

                DETA.ID = $("#MainContent_txtcodigo").val();
                DETA.B_NOMBRES = $("#MainContent_txtnombres").val();
                DETA.B_APELLIDOS = $("#MainContent_txtapellidos").val();
                DETA.B_TEL_CONTACTO = $("#MainContent_txttelefono").val();
                DETA.B_CEL_CONTACTO = $("#MainContent_txtcelular").val();
                DETA.B_GLOSA1= $("#MainContent_txtglosa1").val();
                DETA.B_GLOSA2 = $("#MainContent_txtglosa2").val();
                DETA.B_ESTADO = "A";

                var f = new Date();
                DETA.B_FECHA_C = f; 
              if ((DETA.ID == "") || (DETA.B_NOMBRES == "")) {
                    alert("Complete los Datos antes de continuar");

                }
                else {

                    if ($("#MainContent_txtindicador").val() == "G") {
                        DETA.B_USUCRE = $("#MainContent_lblusuario").html();
                     
                        $.ajax({

                            type: "POST",
                            url: "Bahias.aspx/Insertar",
                            data: '{DETA: ' + JSON.stringify(DETA) + '}',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            async: false,
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
                        DETA.B_USUMOD = $("#MainContent_lblusuario").html();

                        $.ajax({

                            type: "POST",
                            url: "Bahias.aspx/ActualizaAnticipo",
                            data: '{DETA: ' + JSON.stringify(DETA) + '}',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            async: false,
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

                    filtarincio();
                }

            }
            function Eliminarbahia(DETA) {
                         $.ajax({

                            type: "POST",
                            url: "Bahias.aspx/ActualizaAnticipo",
                            data: '{DETA: ' + JSON.stringify(DETA) + '}',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            async: false,
                            success: function (response) {
                                if (DETA.B_ESTADO=="I"){
                                    alert("Registro Eliminado");
                                }
                                else {
                                    alert("Registro Habilitado");
                                }
                               
                              },
                            error: function (response) {
                                if (response.length != 0)
                                    console.table(response);
                            }

                        });
                   
                     filtarincio();
                }

           



            function FiltarParametros() {
                var VC = {};
                VC.ID = $("#MainContent_txtidbahia").val();
             
                $.ajax({

                    type: "POST",
                    url: "Bahias.aspx/LISTARDATOSPARAM",
                    data: '{com: ' + JSON.stringify(VC) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                      
                              if (data.d.length > 0) {
                                var row = $("[id*=gvordencompra] tr:last-child").clone(true);
                                $("[id*=gvordencompra] tr").not($("[id*=gvordencompra] tr:first-child")).remove();

                                for (var i = 0; i < data.d.length; i++) {
                                    $("td", row).eq(0).html(data.d[i].ID);
                                    $("td", row).eq(1).html(data.d[i].B_NOMBRES);
                                    $("td", row).eq(2).html(data.d[i].B_APELLIDOS);
                                    $("td", row).eq(3).html(data.d[i].B_TEL_CONTACTO);
                                    $("td", row).eq(4).html(data.d[i].B_CEL_CONTACTO);
                                    $("td", row).eq(5).html(data.d[i].B_GLOSA1);
                                    $("td", row).eq(6).html(data.d[i].B_GLOSA2);
                                    if (data.d[i].B_ESTADO.trim ()== "A") {
                                        $("td", row).eq(7).html("ACTIVO");
                                    }
                                    else {
                                        $("td", row).eq(7).html("INACTIVO");
                                    }
                                  
                                    $("[id*=gvordencompra]").append(row);
                                    row = $("[id*=gvordencompra] tr:last-child").clone(true);
                                }
                            } else {
                                var row = $("[id*=gvordencompra] tr:last-child").clone(true);
                                $("[id*=gvordencompra] tr").not($("[id*=gvordencompra] tr:first-child")).remove();

                                $("td", row).eq(0).html("");
                                $("td", row).eq(1).html("");
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

            function filtarincio() {

                $.ajax({

                    type: "POST",
                    url: "Bahias.aspx/LISTARDATOS",
                    data: '',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        if (data.d.length > 0) {
                            var row = $("[id*=gvordencompra] tr:last-child").clone(true);
                            $("[id*=gvordencompra] tr").not($("[id*=gvordencompra] tr:first-child")).remove();

                            for (var i = 0; i < data.d.length; i++) {
                                $("td", row).eq(0).html(data.d[i].ID);
                                $("td", row).eq(1).html(data.d[i].B_NOMBRES);
                                $("td", row).eq(2).html(data.d[i].B_APELLIDOS);
                                $("td", row).eq(3).html(data.d[i].B_TEL_CONTACTO);
                                $("td", row).eq(4).html(data.d[i].B_CEL_CONTACTO);
                                $("td", row).eq(5).html(data.d[i].B_GLOSA1);
                                $("td", row).eq(6).html(data.d[i].B_GLOSA2);
                                if (data.d[i].B_ESTADO.trim() == "A") {
                                    $("td", row).eq(7).html("ACTIVO");
                                }
                                else {
                                    $("td", row).eq(7).html("INACTIVO");
                                }
                                $("[id*=gvordencompra]").append(row);
                                row = $("[id*=gvordencompra] tr:last-child").clone(true);
                            }
                        } else {
                            var row = $("[id*=gvordencompra] tr:last-child").clone(true);
                            $("[id*=gvordencompra] tr").not($("[id*=gvordencompra] tr:first-child")).remove();

                            $("td", row).eq(0).html("");
                            $("td", row).eq(1).html("");
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
            function limpiardatos() {
               
                $("#MainContent_txtcodigo").val("");
             
                $("#MainContent_txtnombres").val("");
              
                $("#MainContent_txtapellidos").val("");
                             
                $("#MainContent_txttelefono").val("");
             
                $("#MainContent_txtcelular").val("");
              
                $("#MainContent_txtglosa1").val("");
             
                $("#MainContent_txtglosa2").val("");
            }
            $(".btlistar").click(function () {
                FiltarParametros();
                $("#MainContent_txtbahia").val("");
                $("#MainContent_txtidbahia").val("");

            });
                     
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
            <asp:Label ID="Label9" runat="server" Text="LISTADO DE BAHIAS" Font-Bold="True" Font-Size="12pt"></asp:Label></legend>

        <table>
            <tr>
                <td>Bahia</td>
                <td colspan="3">
                    <asp:TextBox ID="txtbahia" runat="server" Width="300"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtidbahia" runat="server" Width="100"></asp:TextBox>
                </td>
                
                </tr>
             <tr>
                
                  <td>
                    <input class="btlistar" value="Buscar" type="button" style="width: 80px; height: 28px;color: #003366" />
                    
                </td>
                  <td>
                    <input id="btnnuevo" type="button" value="Nuevo" class="btadd" style="width: 80px; height: 28px; color: #003366"/></td>
                 <td>
                      <asp:Button ID="btexcel" class="btn" type="button" Style="width: 80px; height: 28px" runat="server" Text="Excel" OnClick="btexcel_Click" /> 

                 </td>
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
                <asp:GridView ID="gvordencompra" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" OnRowCreated="griddata_RowCreated" >
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="CÓDIGO" />
                        <asp:BoundField DataField="B_NOMBRES" HeaderText="NOMBRES" />

                        <asp:BoundField DataField="B_APELLIDOS" HeaderText="APELLIDOS" />
                        <asp:BoundField DataField="B_TEL_CONTACTO" HeaderText="TEL_CONTACTO" />
                        <asp:BoundField DataField="B_CEL_CONTACTO" HeaderText="CEL_CONTACTO" />
                        <asp:BoundField DataField="B_GLOSA1" HeaderText="GLOSA1" />
                        <asp:BoundField DataField="B_GLOSA2" HeaderText="GLOSA2" />

                        <asp:BoundField DataField="B_ESTADO" HeaderText="ESTADO" />

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
    
    <div id="dvdetalle" style="display:none"> <%-- >--%>
       
        <table>
            <tr>
                <td> DNI.</td>

                <td>
                    <asp:TextBox ID="txtcodigo" runat="server" Width="157px" MaxLength="8" ></asp:TextBox>
                </td>
            </tr>

             <tr>
                <td class="auto-style1">Nombres</td> 
                <td>
                    <asp:TextBox ID="txtnombres" runat="server" Width="369px"></asp:TextBox>
                 </td>
                
            </tr>
             <tr>
                <td class="auto-style1">Apellidos</td> 
                <td>
                    <asp:TextBox ID="txtapellidos" runat="server" Width="369px"></asp:TextBox>
                 </td>
                
            </tr>
             <tr>
                <td class="auto-style1">Teléfono</td> 
                <td>
                    <asp:TextBox ID="txttelefono" runat="server" Width="369px"></asp:TextBox>
                 </td>
                
            </tr>
             <tr>
                <td class="auto-style1">Celular</td> 
                <td>
                    <asp:TextBox ID="txtcelular" runat="server" Width="369px"></asp:TextBox>
                 </td>
                
            </tr>
             <tr>
                <td class="auto-style1">Glosa1</td> 
                <td>
                    <asp:TextBox ID="txtglosa1" runat="server" Width="369px"></asp:TextBox>
                 </td>
                
            </tr>
             <tr>
                <td class="auto-style1">Glosa2</td> 
                <td>
                    <asp:TextBox ID="txtglosa2" runat="server" Width="369px"></asp:TextBox>
                 </td>
                
            </tr>
            
            <tr>
                <td>

                </td>
                 <td>
                     <input id="btngrabar" type="button" value="Grabar" class="btgrabar" style="width: 80px; height: 30px; color: #003366; background-color: #99CCFF"/>
                     <asp:TextBox ID="txtindicador" runat="server" Width="0px" BorderStyle="None"></asp:TextBox>
            </td> </tr>
            <tr>
                <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                            ControlToValidate="txttelefono" ErrorMessage="*Ingrese Valores Numericos"
                            ForeColor="Red"
                            ValidationExpression="^[0-9]*">
             </asp:RegularExpressionValidator>
                </td>

            </tr>
            
        </table>
     </div>
</asp:Content>















