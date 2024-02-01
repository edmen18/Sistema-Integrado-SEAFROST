
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Certificado.aspx.cs" Inherits="Default2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
 
    <script type="text/javascript">
        $(function () {

            $("#MainContent_TXTANALISIS").autocomplete(
                 {
                     source: function (request, response) {
                         $.ajax({
                             url: "Certificado.aspx/GETDATOS",
                             data: "{ 'productos': '" + request.term + "' }",
                             dataType: "json",
                             type: "POST",
                             contentType: "application/json; charset=utf-8",
                             dataFilter: function (data) { return data; },
                             success: function (data) {
                                 response($.map(data.d, function (item) {
                                     return {
                                         value: item.TC_CODIGO +"-"+ item.TC_DESCRIPCION,
                                         id: item.TC_CODIGO,
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
                        
                         $('#MainContent_TXTIDANALISIS').val(str);


                     }
                 });

            $(".btdelete").click(function () { //  se debe colocar dentrp de una funcion 
                var DETA = {};

                trp = $(this).parent().parent();
                id = $("td:eq(0)", trp).html();
                DETA.TC_CODIGO = id;

                trp = $(this).parent().parent();
                id = $("td:eq(1)", trp).html();
                DETA.TC_DESCRIPCION = id;
                DETA.TC_ESTADO = 0;

                if ((DETA.TC_CODIGO == "") || (DETA.TC_DESCRIPCION == "")) {
                    alert("Complete los Datos antes de continuar");

                }
                else {

                    $.ajax({
                        type: "POST",
                        url: "Certificado.aspx/ActualizaAnticipo",
                        data: '{DETA: ' + JSON.stringify(DETA) + '}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (response) {
                            alert("Registro Eliminado");
                        },
                        error: function (response) {
                            if (response.length != 0)
                                console.table(response);
                        }

                    });
                }

                filtarsolicitudes()

            });
            function eliminar() {
               

            }


            function InsertarSolicitud() {

                var DETA = {};
                DETA.TC_DESCRIPCION = $("#MainContent_txtdescripcion").val();
                DETA.TC_CODIGO = $("#MainContent_lblcodigo").html();
                DETA.TC_ESTADO = 1;
              
                if ((DETA.TC_CODIGO == "") || (DETA.TC_DESCRIPCION == ""))
                {
                    alert("Complete los Datos antes de continuar");

                }
                else {

                    if ($("#MainContent_txtindicador").val() == "G") {
                        $.ajax({

                            type: "POST",
                            url: "Certificado.aspx/InsertaDet",
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

                        $.ajax({

                            type: "POST",
                            url: "Certificado.aspx/ActualizaAnticipo",
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

                   filtarsolicitudes()
                }

            }

            $(window).load(function () {
                filtarsolicitudes();

            });

            function filtarsolicitudesParametro() {
                var VC = {};
                VC.TC_CODIGO = $("#MainContent_TXTIDANALISIS").val();
               
                $.ajax({

                    type: "POST",
                    url: "Certificado.aspx/LISTARDATOSPARAM",
                    data: '{DATO: ' + JSON.stringify(VC) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        if (data.d.length > 0) {
                            var row = $("[id*=gvordencompra] tr:last-child").clone(true);
                            $("[id*=gvordencompra] tr").not($("[id*=gvordencompra] tr:first-child")).remove();

                            for (var i = 0; i < data.d.length; i++) {
                                $("td", row).eq(0).html(data.d[i].TC_CODIGO);
                                $("td", row).eq(1).html(data.d[i].TC_DESCRIPCION);
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

            
            function filtarsolicitudes() {
                           
                $.ajax({

                    type: "POST",
                    url: "Certificado.aspx/LISTARDATOS",
                    data: '',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        if (data.d.length > 0) {
                            var row = $("[id*=gvordencompra] tr:last-child").clone(true);
                            $("[id*=gvordencompra] tr").not($("[id*=gvordencompra] tr:first-child")).remove();

                            for (var i = 0; i < data.d.length; i++) {
                                $("td", row).eq(0).html(data.d[i].TC_CODIGO);
                                $("td", row).eq(1).html(data.d[i].TC_DESCRIPCION);
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
            $(".btadd").click(function () { //  se debe colocar dentrp de una funcion 
                $("#dvdetalle").dialog('open');
                $("#MainContent_txtindicador").val("G");
                $("#MainContent_lblcodigo").html("");
                $("#MainContent_txtdescripcion").val("");

                if ($("#MainContent_txtindicador").val() == "G") {
                    var ultimodato = generar().contador;
                    var formato = ultimodato.length < 4 ? pad("0" + ultimodato, 4) : ultimodato;
                    $("#MainContent_lblcodigo").html(formato);
                }
            });
            function pad(str, max) {
                if (str != undefined) {
                    str = str.toString();
                    return str.length < max ? pad("0" + str, max) : str;
                }
            }

        $('#dvdetalle').dialog({
            autoOpen: false,
            modal: true,
            resizable: true,
            width: 800,
            heigth: 100,
            title: 'Registro y Actualización',
            close: function (event, ui) {
                limpiardatos();
                filtarsolicitudes();
            },
           
           
        });
        function generar() {
            var solicitud = "";
            var contador = "";

            $.ajax({

                type: "POST",
                url: "Certificado.aspx/GENERAR",
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
        $(".btgrabar").click(function () {  
           InsertarSolicitud();
                      
        });

        $(".btlistar").click(function () {
            filtarsolicitudesParametro();
            $("#MainContent_TXTIDANALISIS").val("");
            $("#MainContent_TXTANALISIS").val("");

        });

             $(".btaddact").click(function () { //  se debe colocar dentrp de una funcion 
            $("#dvdetalle").dialog('open');
            $("#MainContent_txtindicador").val("A");

            trp = $(this).parent().parent();
            id = $("td:eq(0)", trp).html();
            $("#MainContent_lblcodigo").html(id);

            trp = $(this).parent().parent();
            id = $("td:eq(1)", trp).html();
            $("#MainContent_txtdescripcion").val(id);


            if ($("#MainContent_txtindicador").val() == "A") {

                $("#MainContent_txtdescripcion").attr("disabled", false);
              }

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
            <asp:Label ID="Label9" runat="server" Text="LISTADO DE CERTIFICADO" Font-Bold="True" Font-Size="12pt"></asp:Label></legend>

        <table>
            <tr>
                <td>Certificado</td>
                <td colspan="3">
                    <asp:TextBox ID="TXTANALISIS" runat="server" Width="300"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TXTIDANALISIS" runat="server" Width="100"></asp:TextBox>
                </td>
                
                </tr>
             <tr>
                
                  <td>
                    <input class="btlistar" value="Buscar" type="button" style="width: 80px; height: 30px;color: #003366; background-color: #C0C0C0" />
                    
                </td>
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
                <asp:GridView ID="gvordencompra" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="TC_CODIGO" HeaderText="CÓDIGO" />
                        <asp:BoundField DataField="TC_DESCRIPCION" HeaderText="DESCRIPCION" />

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
                                <div class="btdelete" style="text-align: center">
                                    <img alt="" src="../../Images/Message_Error.png" width="25" style="cursor: pointer" />
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
    <div id="dvdetalle" style="display:none" >
       
        <table>
            <tr>
                <td>Codigo</td>

                <td>
                    <asp:Label ID="lblcodigo" runat="server" Text=""></asp:Label>
                </td>
            </tr>

             <tr>
                <td class="auto-style1">Descripción</td> 
                <td>
                    <asp:TextBox ID="txtdescripcion" runat="server" Width="610px"></asp:TextBox>
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
</asp:Content>
