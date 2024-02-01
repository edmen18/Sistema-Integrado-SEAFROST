<%@ Page Title="SeaProduccion" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="cambiarpass.aspx.cs" Inherits="cambiarpass" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
     <script type="text/javascript">
         $(function () {
             var uus = $("#HeadLoginView_HeadLoginName").html();
             $("#MainContent_hfusuario").val(uus);
          

         });
         function soloNumeros() {
             $(".numeric").numeric();
         }
         $(function () {
             $(".tb").autocomplete(
                 {
                     source: function (request, response) {
                         $.ajax({
                             url: "guiasIngreso.aspx/GetProductos",
                             data: "{ 'productos': '" + request.term + "' }",
                             dataType: "json",
                             type: "POST",
                             contentType: "application/json; charset=utf-8",
                             dataFilter: function (data) { return data; },
                             success: function (data) {
                                 response($.map(data.d, function (item) {
                                     return {
                                         value: item.descripcion,
                                         id: item.idsalida

                                     }
                                 }))
                             },
                             error: function (XMLHttpRequest, textStatus, errorThrown) {
                                 alert(textStatus);
                             }
                         });
                     },
                     minLength: 1,
                     select: function (event, ui) {

                         var str = ui.item.id;
                         $('#codigo0').val(str);
                     }
                 });




         });
	</script>
     <style type="text/css">
         #txtproducto0 {
             width: 337px;
         }
     </style>
</asp:Content>
   <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">



    <asp:Panel ID="Panel1" runat="server" >
    <table bgcolor="#FFFFCC" border="1" style="border-color: #000000">
    <tr>
    <td colspan="2" bgcolor="#CCFFFF" style="font-weight: bold">
    Cambiar Contraseña
    </td>
    </tr>
    <tr>
    <td>
    
        <asp:Label ID="Label1" runat="server" Text="Contraseña Actual:"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="TextBox1" runat="server" TextMode="Password"></asp:TextBox>
    </td>
    </tr>

    <tr>
    <td>
    
        <asp:Label ID="Label2" runat="server" Text="Nueva Contraseña:"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
    </td>
    </tr>

    <tr>
    <td>
    
        <asp:Label ID="Label3" runat="server" Text="Repita Nueva Contraseña:"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td colspan="2">
        <asp:Button ID="Button1" runat="server" Text="Aceptar" 
            onclick="Button1_Click" />
        &nbsp;<asp:Button ID="Button2" runat="server" Text="Cancelar" />
    
    </td>
    
    </tr>
    

    
    
    </table>
    
    </asp:Panel>
    

</asp:Content>