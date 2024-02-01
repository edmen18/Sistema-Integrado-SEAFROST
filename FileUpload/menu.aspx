<%@ Page Title="Logística" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="menu.aspx.cs" Inherits="menu" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
     <script type="text/javascript">
         $(function () {
             var uus = $("#HeadLoginView_HeadLoginName").html();
             $("#MainContent_hfusuario").val(uus);
             $("#MainContent_TextBox1").datepicker();
             $("#MainContent_TextBox2").datepicker();

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
       </asp:Content>
   
