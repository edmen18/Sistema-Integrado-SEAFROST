<%@ Page Title="Logística" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="CAlmacen.aspx.cs" Inherits="CAlmacen" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link type="text/css" href="../CSS/base.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {
            UHTML.id = 'MainContent';
            var uus = $("#HeadLoginView_HeadLoginName").html();
            $("#MainContent_hfusuario").val(uus);
            $(".dpFecha1").datepicker();
            
            /*var obtieneALCIAS = function () {
                var data = {};
                var oajax = Operacion.oAjax('CAlmacen.aspx/getALCIAS', data);
                //Operacion.mask('dpFecha').val(moment(oajax.d.AC_DFECPR1).format('DD/MM/YYYY'));
                Operacion.mask('HFID').val(oajax.d.AC_CCIA);
            }*/
            //obtieneALCIAS();            
        });
    </script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:ScriptManager ID="scriptManager" runat="server" EnablePageMethods="true" />
    <style>
        #contenedor {
            width: 470px;
        }
    </style>
    <div id="contenedor">        
        <fieldset style="width: 430px;">
            <legend>Cierre de Almacén</legend>
            <table style="width: 100%">
                <tr>
                    <td>&nbsp;</td>

                    <td>&nbsp;</td>

                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Ingrese fecha de cierre</td>
                    <td>
                        <asp:TextBox ID="dpFecha" class="dpFecha1" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:HiddenField ID="HFID" runat="server" />
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnAceptar" class="btn" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </fieldset>
    </div>
</asp:Content>

















