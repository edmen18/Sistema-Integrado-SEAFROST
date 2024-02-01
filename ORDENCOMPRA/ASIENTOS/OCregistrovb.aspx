<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="OCregistrovb.aspx.cs" Inherits="Default2" %>


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
                Operacion.iValida(Operacion.mask("txtdprec"), 1);
                Operacion.iValida(Operacion.mask("txttcambio"), 1);
                Operacion.iValida(Operacion.mask("txtdisc"), 1);
                Operacion.iValida(Operacion.mask("txtddesci"), 1);
                Operacion.iValida(Operacion.mask("txtddesca"), 1);
                
                $("#MainContent_txtfecha1").datepicker(({
                     change : function (e) {
                         var curDate = $("#MainContent_txtfecha1").datepicker("getDate");
                        var maxDate = new Date();
                        maxDate.setDate(maxDate.getDate() + 1); // add one day
                        maxDate.setHours(0, 0, 0, 0);           // clear time portion for correct results
                        if (curDate > maxDate) {
                            alert("Invalid date");
                            $(this).datepicker("setDate", maxDate);
                        }
                    }
                }));

                $("#MainContent_txtfecha2").datepicker();
                $("#MainContent_txtdfechat1").datepicker();
                $("#MainContent_txtfinis").datepicker();
                $("#MainContent_txtffins").datepicker();
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
            var tcam = MostrarTcambio();
            $("#MainContent_txttcambio").val(tcam);
        });

    </script>

    <script type="text/javascript">

        $(function () {


            $("#MainContent_txtprove").autocomplete(
                {
                    source: function (request, response) {
                        $.ajax({
                            url: "OCregistrovb.aspx/GetProveedores",
                            data: "{ 'productos': '" + "%" + request.term + "%" + "' ,codig:'" + Operacion.mask('ddltprov').val() + "' }",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            dataFilter: function (data) { return data; },
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        value: item.ADESANE.trim(),
                                        id: item.ACODANE,
                                        dir: item.AREFANE 

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
                        var cadena = str;
                        var dire = ui.item.dir;
                        if (str != null || str != undefined) {
                        $('#MainContent_txtidpro').val(str);
                        $('#MainContent_txtdire').val(dire);
                        } else {
                            $('#MainContent_txtidpro').val("");
                            $('#MainContent_txtdire').val("");
                    }
                    },
                    change: function (event, ui) {
                        if (ui.item == null || ui.item == undefined) {
                            $("#MainContent_txtidpro").val("");
                            $("#MainContent_txtprove").val("");
                            $("#MainContent_txtprove").focus();
                            alert("El cliente no se ha seleccionado");
                        }
                    }
                });



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
            <legend>REGISTRO DOCUMENTOS VB </legend>

            <table>
                <tr>
                    <td>Tipo Acreedor:
                    </td>
                    <td colspan="3">

                        <asp:DropDownList runat="server" ID="ddltprov" Width="200"></asp:DropDownList>

                    </td>
                    <td>Fecha</td>
                    <td>
                        <asp:TextBox ID="txtfecha1" TabIndex="1" class="tcamb" runat="server" Width="130" placeholder="00/00/0000" onkeydown ="ModifyEnterKeyPressAsTab(event,this);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Proveedor:</td>
                    <td colspan="3">
                        <asp:TextBox ID="txtprove" TabIndex="2"  runat="server" Width="300" onkeydown="ModifyEnterKeyPressAsTab(event,this);"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtidpro" Enabled="true" runat="server" Width="100" placeholder="RUC" ></asp:TextBox>
                    </td>
                    <td>Fax:<asp:TextBox runat="server" ID="txtfax" Width="102px" Height="18px" Enabled="false"></asp:TextBox>
                    </td>


                </tr>
                <tr>
                    <td>direccion</td>
                    <td colspan="3">

                        <asp:TextBox ID="txtdire" runat="server" Width="300" Enabled="False" ></asp:TextBox>

                    </td>
                    <td>Tipo Despacho</td>
                    <td>
                        <asp:DropDownList ID="ddltdespa" runat="server" Width="130"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Doc Referencia:</td>
                    <td class="auto-style1">
                        <asp:DropDownList ID="ddldocre" TabIndex="3"  runat="server" Width="130" onkeydown ="ModifyEnterKeyPressAsTab(event,this);"></asp:DropDownList>
                    </td>
                    <td>

                        <asp:TextBox ID="txtnumref" runat="server" TabIndex="4" Width="161px" onkeydown="ModifyEnterKeyPressAsTab(event,this);"></asp:TextBox>

                    </td>
                    <td></td>
                    <td>N° Doc Ref.02</td>
                    <td>

                        <asp:TextBox ID="txtref2" runat="server" Width="130"  TabIndex="5"  onkeydown="ModifyEnterKeyPressAsTab(event,this);"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td>Moneda:</td>
                    <td class="auto-style1">
                        <asp:DropDownList ID="ddlmone" runat="server"  TabIndex="6"  Width="130" onkeydown="ModifyEnterKeyPressAsTab(event,this);"></asp:DropDownList>
                    </td>
                    <td></td>
                    <td></td>

                    <td>Tipo O/C:</td>
                    <td>
                        <asp:DropDownList ID="ddltipo" runat="server" TabIndex="7"  onkeydown="ModifyEnterKeyPressAsTab(event,this);" Width="130"></asp:DropDownList>
                    </td>
                   <td>
                <input class="bttimp" value="Importacion" type="button" style="width:85px; height: 22px;" />
                         </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td><td></td>
                        <td></td>
                        <td>Sub-Tipo</td>
                     <td>
                        <asp:DropDownList ID="ddlsuboc" runat="server" TabIndex="8" onkeydown="ModifyEnterKeyPressAsTab(event,this);" Width="130"></asp:DropDownList>
                    </td>
                    <td>
                          <input class="btplan" value="Planilla" type="button" style="width:85px; height: 22px;" />
            </td>
                </tr>
                <tr>
                    <td>Forma Pago:</td>
                    <td colspan="3">
                        
                        <%--<asp:DropDownList runat="server" ID="ddlfpago" Width="300" > </asp:DropDownList>--%>
                    <asp:TextBox ID="ddlfpago" runat="server" Width="300"  TabIndex="9"  MaxLength="30"  onkeydown="ModifyEnterKeyPressAsTab(event,this);"></asp:TextBox>
                    </td>

                    <td>Tipo Cambio</td>
                    <td>
                        <asp:TextBox ID="txttcambio" runat="server" Width="130"  TabIndex="10" onkeydown="ModifyEnterKeyPressAsTab(event,this);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Fecha Entrega:</td>
                    <td>
                        <asp:TextBox ID="txtfecha2" runat="server" Width="130" TabIndex="11"  placeholder="00/00/0000" onkeydown="ModifyEnterKeyPressAsTab(event,this);"></asp:TextBox>
                    </td>

                    <td colspan="2">Dscto Fina.
                 <asp:TextBox ID="txtdfina" runat="server" Width="88px"  TabIndex="12"  onkeydown="ModifyEnterKeyPressAsTab(event,this);"></asp:TextBox>
                    </td>
                    <td>Pais
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlpais" Width="130" TabIndex="13"  onkeydown="ModifyEnterKeyPressAsTab(event,this);"></asp:DropDownList>
                    </td>
                </tr>

            </table>
            <hr />
            <table>
                <tr>
                    <td>Solicitante:</td>
                    <td colspan="6">
                        <asp:TextBox ID="txtidsoli" class="ctxtidsoli" runat="server" Width="100" placeholder="CODIGO"></asp:TextBox>


                        <asp:TextBox ID="txtsoli" runat="server" Width="300" placeholder="SOLICITANTE" TabIndex="14"  onkeydown="ModifyEnterKeyPressAsTab(event,this);"></asp:TextBox>

                    </td>

                </tr>
                <tr>
                    <td>Centro Costo:</td>
                    <td colspan="6">
                        <asp:TextBox runat="server" ID="txtcodcos" Width="100" placeholder="CODIGO"  TabIndex="15"   ></asp:TextBox>

                        <asp:TextBox runat="server" ID="ddlccost" Width="300" placeholder="DESCRIPCION" TabIndex="16"  onkeydown="ModifyEnterKeyPressAsTab(event,this);"></asp:TextBox>
                    </td>


                </tr>
                <tr>
                    <td>Tipo Envio </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtenvio" runat="server" Width="300"   TabIndex="17"  onkeydown="ModifyEnterKeyPressAsTab(event,this);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Almacen:</td>
                    <td colspan="2">

                        <asp:DropDownList ID="ddlalma" class="selalma" runat="server" Width="300" TabIndex="18"  onkeydown="ModifyEnterKeyPressAsTab(event,this);"></asp:DropDownList>

                    </td>
                </tr>
                <tr>
                    <td>Lugar Entrega:</td>
                    <td colspan="2">
                        <asp:TextBox ID="txtlentre" runat="server" Width="300"  TabIndex="19"  onkeydown="ModifyEnterKeyPressAsTab(event,this);"></asp:TextBox>
                    </td>
                    <td>Distri.:</td>
                    <td>
                        <asp:TextBox ID="txtdist" runat="server" Width="100" Enabled="False"></asp:TextBox>
                    </td>
                    <td>Provinc:</td>
                    <td>
                        <asp:TextBox ID="txtprov" runat="server" Width="100" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Lugar Factura </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtlugarf" runat="server" Width="300"  TabIndex="20"  onkeydown="ModifyEnterKeyPressAsTab(event,this);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Observaciones :</td>
                    <td colspan="6">
                        <asp:TextBox TextMode="MultiLine" Rows="2" runat="server" ID="txtobs" Width="595" MaxLength="80" TabIndex="21"  onkeydown="ModifyEnterKeyPressAsTab(event,this);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Remite:</td>
                    <td colspan="1">
                        <asp:TextBox ID="txtremi" runat="server" Width="180"  TabIndex="22"  onkeydown="ModifyEnterKeyPressAsTab(event,this);"></asp:TextBox>
                    </td>
                    <td>Persona Atencion:</td>
                    <td colspan="4">
                        <asp:TextBox ID="txtaten" runat="server" Width="180"  TabIndex="23"  onkeydown="ModifyEnterKeyPressAsTab(event,this);"></asp:TextBox>
                    </td>
                </tr>

            </table>
            <table>
                <tr>
                    <td>
                        <input class="btadd btn" value="Agregar Detalle" type="button" style="width: 120px; height: 35px; border-radius: 5px" />
                    </td>
                     <td>
                <input class="imprime btn" value="Imprimir" type="button" style="width:120px;height:35px;border-radius:5px" />
                </td>
                </tr>
            </table>
        </fieldset>
    </div>
 



   
</asp:Content>

