<%@ Page Title="Logística" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="LibroLiquidaciones.aspx.cs" Inherits="FINANZAS_Reportes_LibroLiquidaciones" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script type="text/javascript">
        $(function () {

        });

    </script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:ScriptManager ID="scriptManager" runat="server" EnablePageMethods="true" />
    <div id="contenedor" style="width: 990px">
        <table width="100%" cellpadding="5" cellspacing="5" border="0">
            <tr>
                <td>
                    <fieldset>
                        <legend>
                            <asp:Label ID="Label9" runat="server" Text="Libro de Liquidaciones de Compras" Font-Bold="True" Font-Size="12pt"></asp:Label></legend>
                    </fieldset>
                </td>
            </tr>

            <tr>
                <td>
                    <fieldset>
                        <table class="ContainerWrapper" border="0" cellpadding="2" cellspacing="0" style="width: 800px">

                            <tr>
                                <td>

                                    <table style="width: 900px">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblAlmacen" runat="server" Text="Agencia:" Font-Bold="True"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlagencia" runat="server" Height="29px" Width="645px"></asp:DropDownList>
                                            <td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label2" runat="server" Text="Moneda:" Font-Bold="True"></asp:Label>

                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlmoneda" runat="server" Height="29px" Width="644px"></asp:DropDownList></td>
                                        </tr>
                                    </table>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Label ID="FechaInicial" runat="server" Text="Periodo AA/MM:" Font-Bold="True"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtannio" runat="server" Width="136px"></asp:TextBox></td>

                                            <td> <asp:DropDownList ID="ddlmes" runat="server" Width="250px">
                                                <asp:ListItem Value="01">ENERO</asp:ListItem>
                     <asp:ListItem Value="02">FEBRERO</asp:ListItem>
                     <asp:ListItem Value="03">MARZO</asp:ListItem>
                     <asp:ListItem Value="04">ABRIL</asp:ListItem>
                     <asp:ListItem Value="05">MAYO</asp:ListItem>
                     <asp:ListItem Value="06">JUNIO</asp:ListItem>
                     <asp:ListItem Value="07">JULIO</asp:ListItem>
                     <asp:ListItem Value="08">AGOSTO</asp:ListItem>
                     <asp:ListItem Value="09">SETIEMBRE</asp:ListItem>
                     <asp:ListItem Value="10">OCTUBRE</asp:ListItem>
                     <asp:ListItem Value="11">NOVIEMBRE</asp:ListItem>
                     <asp:ListItem Value="12">DICIEMBRE</asp:ListItem>
                                                 </asp:DropDownList></td>

                                                                                       <tr>
                                                <td>
                                                    <hr />

                                                    <asp:Button ID="btnBuscar" class="btn" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                                                </td>
                                            </tr>

                                    </table>
                                </td>
                            </tr>
                        </table>


                    </fieldset>
                </td>
            </tr>
        </table>

    </div>
</asp:Content>
