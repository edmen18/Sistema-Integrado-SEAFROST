<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ALcosteo.aspx.cs" Inherits="Default2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link type="text/css" href="../../CSS/Base-s.css?1.4" rel="stylesheet" />

    <script type="text/javascript">

      
        function ModifyEnterKeyPressAsTab(event,info) {
           
            if (event.keyCode == 13) {
                cb = parseInt($(info).attr('tabindex'));
                cb2 = cb + 1;
                if ($(':input[TabIndex=\'' + (cb2) + '\']') != null  ) {
                    if ($(':input[TabIndex=\'' + (cb2) + '\']').attr("disabled") == false) {

                        $(':input[TabIndex=\'' + (cb2) + '\']').focus();
                        $(':input[TabIndex=\'' + (cb2) + '\']').select();
                    } else {
                        $(':input[TabIndex=\'' + (cb2 + 1) + '\']').focus();
                        $(':input[TabIndex=\'' + (cb2 + 1) + '\']').select();
                    }
                    event.preventDefault();

                    return false;
                }
            }
        }




        $(window).load(function () {
            
          

            contarndw = 0;
            cc = 1;
            sw_edicion = 0;
            sw_nuevo = 0;
            sw_plan = 0;
            contaditem = 0; contaditemplan=0;
            guardartmp = [];
            sindatosimport = 0;
            gsumadolaresf = 0; gsumasolesf = 0;
            $(".bttimp").hide();
            $(".btplan").hide();
            $(function () {
                UHTML.id = 'MainContent';
                Operacion.iValida(Operacion.mask("txtdcant"), 1);
                $("#MainContent_txtfecha1").datepicker();

            });
            
            $.urlParam = function (name) {
                var results = new RegExp('[\?&]' + name + '=([^&#]*)').exec(window.location.href);
                return (results != null ? results[1] || 0 : "");
            }
            

            var codextraido = $.urlParam("ID");//window.location.search.substring(1);
            
            if (codextraido.length > 1) {
                MostrarunRegistro(codextraido);
                validaboton();
                $("#MainContent_ddltipo").attr("disabled", true);
                $("#MainContent_ddlsuboc").attr("disabled", true);
                $(".btadd").show();
            } else {
                $("#MainContent_txtfecha1").focus();
            }
        
        });

    </script>

    <script type="text/javascript">

        $(function () {


           

        });




        

    </script>



    <script type="text/javascript">
        $(function () {
            $(".btbuscar").click(function () {
                filtarocompra();
            });


            $("#MainContent_txtidpro").change(function () {
                if (Mostrarunproveedor($(this).val()).ee == "") {
                    alert("No se encontrol informacion");
                    $(this).focus();
                } else {
                    $("#MainContent_txtprove").val(Mostrarunproveedor($(this).val()).ee);
                    $("#MainContent_txtnumref").focus();
                }
            });



        });

    </script>

    <script type="text/javascript">

        function MostrarTcambio() {
            var dato;
            var fec1 = moment($("#MainContent_txtfecha1").val(), "DD/MM/YYYY");
            fec1 = new Date(fec1);

            var TCAM = {};
            TCAM.XFECCAM2 = fec1;

            $.ajax({

                type: "POST",
                url: "OCregistrovb.aspx/extraetcambio",
                data: '{TCAM: ' + JSON.stringify(TCAM) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.d == null) {
                        dato = "";
                        alert("No se encuentra registrado tipo de cambio - Comunicarse con contabilidad");
                    } else {
                        dato = data.d.XMEIMP2;
                    }

                },
                error: function (data) {
                    if (data.length != 0)
                        alert(data);
                }

            });
            return dato;
        }

        function MostrarunRegistroLG() {
            var rtdato;
            $.ajax({
                type: "POST",
                url: "ALcosteo.aspx/GetLogC",
                //data: '{INFO: ' + JSON.stringify(INFO) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d == null) {
                        rtdato = data.d.LC_CPERIODO;
                    }
                },
                error: function (data) {
                    if (data.length != 0)
                        alert(data);
                }
            });
        }
    </script>


    <style type="text/css">
        /*.auto-style1 {
            width: 132px;
        }

        fieldset {
            padding: 10px;
            border: 1px solid black;
            border-radius: 5px;
            background-color: white;
            margin:0 auto;
            width: 900px;
        }

        legend {
            padding: 5px;
            font-size: 15px;
            border-radius: 10px;
            background-color: white;
        }*/
        #btbuscaplan {
            height: 27px;
            width: 126px;
        }
        #btlimpiaplan {
            height: 26px;
            width: 118px;
        }
        .btbuscaplan {
            width: 152px;
            height: 30px;
        }
        .btlimpiaplan {
            width: 179px;
            height: 29px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:HiddenField runat="server" ID="hffactual" />
    <asp:HiddenField runat="server" ID="hfusu" />
        <div id="contenedor">
        <fieldset>
            <legend>PROCESO PROMEDIO DIARIO VALORIZACION</legend>

            <table>
                <tr>
                    <td>Mes Proceso Anterior:
                    </td>
                    <td colspan="3">
                        <asp:TextBox runat="server" ID="txtmesant" Enabled="false" Width="130" />
                    </td>
                    <td>Tipo Proceso:</td>
                    <td rowspan="2">
                        <asp:RadioButtonList runat="server" ID="rbltipop">
                            <asp:ListItem Text="Previo" Value="P" Selected="True" />
                            <asp:ListItem Text="Definitivo" Value="D" />
                        </asp:RadioButtonList>
                    </td>
                    </tr><tr>
                    <td>Fecha de Proceso:</td>
                    <td>
                        <asp:TextBox ID="txtfecha1" TabIndex="1" class="tcamb" runat="server" Width="130" placeholder="dd/mm/aaaa" EnableViewState="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%--<asp:CheckBox Text="Costear Parte de Entrada x TC" runat="server" />--%>
                    </td>
                   </tr>
                <tr>
                    <td>Hora Inicio:</td>
                    <td>
                        <asp:TextBox runat="server" Width="150" ID="txthinicio" Enabled="false"></asp:TextBox>
                    </td>
                    
                    <td colspan="4" rowspan="2" style="text-align: center">
                        <asp:Button class="btn" Text="Aceptar" runat="server" ID="btacepta" OnClick="btacepta_Click" Enabled="true"></asp:Button>
                        <%--<input class="btadd btn" value="Aceptar" type="button" style="width: 120px; height: 35px; border-radius: 5px" />--%>
                    </td>
                </tr>
                <tr>
                    <td>Hora Termino:</td>
                    <td>
                        <asp:TextBox runat="server" Width="150" ID="txthfin" Enabled="false"></asp:TextBox>
                    </td>
              
                    
                </tr>
            </table>
        </fieldset>
    </div>
 


  
   
</asp:Content>

