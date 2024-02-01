<%@ Page Title="Logística" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="SAlmacen.aspx.cs" Inherits="SAlmacen" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link type="text/css" href="../CSS/base.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {
            UHTML.id = 'MainContent';
            var uus = $("#HeadLoginView_HeadLoginName").html();
            $("#MainContent_hfusuario").val(uus);
            $("#MainContent_txtFecha").datepicker();
            $("#MainContent_TextBox2").datepicker();
            $(".dpFecha1").datepicker();
            
            obtieneALCIAS();
            //Operacion.mask('HFID').val($('#FB').val());
        });
    </script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:ScriptManager ID="scriptManager" runat="server" EnablePageMethods="true" />
    <div id="contenedor">
        <fieldset style="width:830px;">
            <legend>Selección de Almacen y Fecha</legend>
            <table>
                <tr>
                    <td>El almacen actual es:</td>

                    <td>
                        <asp:DropDownList Width="350px" class="ddl" ID="ddlAlmacenA" runat="server"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>La fecha del proceso es</td>
                    <td>
                        <asp:TextBox ID="dpFecha" class="dpFecha1" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>El almacen principal es</td>
                    <td>
                        <asp:DropDownList Width="350px" ID="ddlAlmacenP" class="ddl" runat="server"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>
                        <!--<asp:HiddenField ID="HFID" runat="server" />-->
                        <!--<asp:HiddenField ID="HFFB" runat="server" />-->
                    </td>
                    <td>
                        <asp:Button ID="btnAceptar" class="btn" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
</asp:Content>

















