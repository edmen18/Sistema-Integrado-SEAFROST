<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ARingreso.aspx.cs" Inherits="Default2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link type="text/css" href="../CSS/Base-s.css?2.1" rel="stylesheet" />

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
                Operacion.iValida(Operacion.mask("txttar"), 1);
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
            $(".idart").autocomplete(
                          {
                              source: function (request, response) {
                                  $.ajax({
                                      url: "ARingreso.aspx/GetProductos",
                                      data: "{ 'productos': '" + "%" + request.term + "%" + "',tipop:'" + "S" + "',subtip:'" + "2" + "',idusuario:'" + $("#hfusu").val() + "',idprovee:'-',tipolinea:'R' }",
                                      dataType: "json",
                                      type: "POST",
                                      contentType: "application/json; charset=utf-8",
                                      dataFilter: function (data) { return data; },
                                      success: function (data) {
                                          response($.map(data.d, function (item) {
                                              return {
                                                  value: item.AR_CDESCRI,
                                                  id: item.AR_CCODIGO.trim(),
                                                  um: item.AR_CUNIDAD,
                                                  igvp: item.AR_NIGVCPR,
                                                  cuenta: item.AR_CCUENTA,
                                                  sarea: item.AR_CPARARA,
                                                  moncom: item.AR_CMONCOM,
                                                  tipotfv: item.AR_CTIPDES,
                                                  precio: item.AR_NPRECOM 

                                              }
                                          }))
                                      },
                                      error: function (XMLHttpRequest, textStatus, errorThrown) { //alert(textStatus); 
                                      }   
                                  });
                              },
                              minLength: 1,
                              select: function (event, ui) {
                                  var str = ui.item.id;
                                  var strum = ui.item.um;
                                  var strigv = ui.item.igvp;
                                  var cta = ui.item.cuenta;
                                  var sarea = ui.item.sarea;
                                  var moncom = ui.item.moncom;
                                  var tipotfv = ui.item.tipotfv;
                                  var precioc = ui.item.precio;
                                  var descuenta = MostrarunRegistrocta(cta.trim()).rtdato;

                                  $('#MainContent_txtidprod1').val(str); 
                                  $('#MainContent_txtidcuenta').val(cta); 
                                  $('#MainContent_txtcuenta').val(descuenta); 
                                  $('#MainContent_ddlsarea').val(sarea); 
                                  $('#MainContent_ddlmone').val(moncom); 
                                  $('#MainContent_ddltipot').val(tipotfv); 
                                  $('#MainContent_txttar').val(precioc); 
                                  $('#MainContent_txtcuenta').focus(); 
                              },
                              change: function (event, ui) {
                                  if (ui.item == null || ui.item == undefined) {
                                      //$("#MainContent_txtidprod1").val("");
                                      //$(".idart").focus();
                                      //alert("No ha seleccionado El Servicio");
                                  } else {
                                      $('#MainContent_txtcuenta').focus();
                                  }
                              }
                          }).keypress(function (event, ui) {
                              var str = $("#MainContent_txtidprove").val();
                              if (event.keyCode == 13) {
                              
                                  $("#MainContent_txtcuenta").focus();
                               
                              }
                          });
            $(".clprove").autocomplete(
                          {
                              source: function (request, response) {

                                  var ADATA = {};
                                  ADATA.AVANEXO = "P"; 
                                  ADATA.ADESANE = '%' + request.term + '%';
                                  ADATA.ATIPTRA = null;

                                  $.ajax({
                                      url: "ARingreso.aspx/GetProveedores",
                                      //data: "{ 'productos': '"+"%"+ request.term +"%"+"' ,codig:'P' }",
                                      data: '{ADATA:' + JSON.stringify(ADATA) + '}',
                                      dataType: "json",
                                      type: "POST",
                                      contentType: "application/json; charset=utf-8",
                                      dataFilter: function (data) { return data; },
                                      success: function (data) {
                                          response($.map(data.d, function (item) {
                                              return {
                                                  value: item.ADESANE.trim(),
                                                  id: item.ACODANE.trim(),
                                                  dir: item.AREFANE
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
                                  var str = ui.item.id.trim();
                                  var cadena = str;
                                  var dire = ui.item.dir;
                                  if (str != null || str != undefined) {
                                      $('#MainContent_txtidprove').val(str);
                                      //$('#MainContent_txtdire').val(dire);
                                  } else {
                                      $('#MainContent_txtidprove').val("");
                                      //$('#MainContent_txtdire').val("");
                                  }
                              },
                              change: function (event, ui) {
                                  if (ui.item == null || ui.item == undefined) {
                                      $("#MainContent_txtidprove").val("");
                                      $("#MainContent_txtprove").val("");
                                      $("#MainContent_txtprove").focus();
                                      alert("El Proveedor no se ha seleccionado");
                                  }
                              }
                          }).keypress(function (event, ui) {
                              //event.preventDefault();
                              var str = $("#MainContent_txtidprove").val();
                              if (event.keyCode == 13) {
                                  if (str == null || str == undefined || str.trim() == "") {
                                      $("#MainContent_txtprove").val("");
                                      $("#MainContent_txtprove").focus();
                                      alert("No ha seleccionado El Proveedor");
                                  } else {
                                      $("#MainContent_ddlsarea").focus();
                                  }
                              }
                          });

            $(".clcuenta").autocomplete(
                          {
                              source: function (request, response) {
                                  $.ajax({
                                      url: "ARingreso.aspx/listactaexis",
                                      data: "{ texto: '" +  request.term  + "' }",
                                      dataType: "json",
                                      type: "POST",
                                      contentType: "application/json; charset=utf-8",
                                      dataFilter: function (data) { return data; },
                                      success: function (data) {
                                          response($.map(data.d, function (item) {
                                              return {
                                                  value: item.TC_CDESCRI,
                                                  id: item.TC_CEXISTE.trim(),
                                                  vali: item.TC_CEXISTE.trim()
                                              }
                                          }))
                                      },
                                      error: function (XMLHttpRequest, textStatus, errorThrown) { //alert(textStatus); 
                                      }
                                  });
                              },
                              minLength: 1,
                              select: function (event, ui) {
                                  var str = ui.item.id;
                                  var strum = ui.item.um;
                                  $('#MainContent_txtidcuenta').val(str);
                              },
                              change: function (event, ui) {
                                  var str = ui.item;
                                  if (str == null || str == undefined || str.trim() == "") {
                                      $("#MainContent_txtidcuenta").val("");
                                      $("#MainContent_txtcuenta").val("");
                                      $(".clcuenta").focus();
                                      alert("No ha seleccionado El item");
                                  } else {
                                      $(".clprove").focus();
                                  }
                              }
                          }).keypress(function (event, ui) {
                              //event.preventDefault();
                              var str = $("#MainContent_txtidcuenta").val();
                              if (event.keyCode == 13) {
                                  if (str == null || str == undefined || str.trim() =="") {
                                      $("#MainContent_txtidcuenta").val("");
                                      $(".clcuenta").focus();
                                      alert("No ha seleccionado El item");
                                  } else {
                                      $(".clprove").focus();
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

        function UltimoCodigoProd() {
            var dato;
            $.ajax({
                type: "POST",
                url: "ARingreso.aspx/GetcodigoGenerar",
                data: "{tipo: 'R'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.d == null) {
                        dato = "";
                    } else {
                        dato = data.d;
                    }
                },
                error: function (data) {
                    if (data.length != 0)
                        alert(data);
                }
            });
            return dato;
        }

        //function MostrarunRegistroLG() {
        //    var rtdato;
        //    $.ajax({
        //        type: "POST",
        //        url: "ALcosteo.aspx/GetLogC",
        //        //data: '{INFO: ' + JSON.stringify(INFO) + '}',
        //        contentType: "application/json; charset=utf-8",
        //        dataType: "json",
        //        success: function (data) {
        //            if (data.d == null) {
        //                rtdato = data.d.LC_CPERIODO;
        //            }
        //        },
        //        error: function (data) {
        //            if (data.length != 0)
        //                alert(data);
        //        }
        //    });


        function MostrarunRegistrocta(codcuenta) {
                rtdato="";
                $.ajax({
                    type: "POST",
                    url: "ARingreso.aspx/extraedescuenta",
                    data: "{ncuenta: '" + codcuenta + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async:false,
                    success: function (data) {
                        if (data.d == "") {
                            rtdato = "";
                        } else {
                            rtdato = data.d;
                        }
                    },
                    error: function (data) {
                        if (data.length != 0)
                            alert(data);
                    }
                });
                return { rtdato } ;

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
    <asp:HiddenField runat="server" ID="hfusu"/>
    <asp:HiddenField runat="server" ID="hfaccede"/> 
        <div id="contenedor">
        <fieldset>
            <legend>MANTENIMIENTO TARIFAS</legend>
            <%--<table>
                <tr>
                    <td>
                         <asp:Menu
        ID="Menu1"
        Width="668px"
        runat="server"
        Orientation="Horizontal"
        StaticEnableDefaultPopOutImage="False"
        OnMenuItemClick="Menu1_MenuItemClick">
    <Items>
        <asp:MenuItem ImageUrl="~/Images/item-pointer.gif" 
                      Text="Datos Generales" Value="0"></asp:MenuItem>
        <asp:MenuItem ImageUrl="~/Images/item-pointer.gif" 
                      Text="Datos Venta" Value="1"></asp:MenuItem>
        <asp:MenuItem ImageUrl="~/Images/item-pointer.gif" 
                      Text="Datos Compra" Value="2"></asp:MenuItem>
    </Items>
</asp:Menu>
                    </td>
                </tr>
            </table>--%>

            <table>
                <tr>
                    <%--<td>Producto:</td>
                    <td>
                        <asp:TextBox runat="server" Width="350" ID="txtprod" class="idart" ></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox runat="server" Width="150" ID="txtidprod1" placenholder="CODIGO"  AutoPostBack="True"  OnTextChanged="txtidprod1_TextChanged" ></asp:TextBox>
                    </td>
                    </tr>--%> 
                 <tr>
                    <td>Descripcion:</td>
                    <td>
                        <asp:TextBox runat="server" Width="350" ID="txtprod2" placeholder="SERVICIO" Enabled="false" class="idart"  ></asp:TextBox>
                       <%-- <input id="txtprod2" runat="server" disabled="disabled"  class="idart" style="width:350px"  />--%>
                    </td>
                    <td>
                        <asp:TextBox runat="server" Width="150" ID="txtnuevocod" placenholder="CODIGO" Enabled="false"></asp:TextBox>
                    </td>
                    </tr>

                    <%-- <tr>
                   <td>Linea:</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddllinea" Width="150"></asp:DropDownList>
                    </td>
                    </tr>--%>

               <%-- <tr>
                    <td>Grupo:</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlgrupo" Width="150"></asp:DropDownList>
                    </td>
                    </tr>--%>
         <%--      <tr>
                    <td>Familia:</td>
                    <td>
                        <asp:TextBox runat="server" ID ="txtfami" Width="350" class="clfami"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID ="txtidfami" Width="150" OnTextChanged="txtidfami_TextChanged" AutoPostBack="true"></asp:TextBox>
                    </td>
                    </tr>--%>
                <%-- <tr>
                    <td>Unidad:</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddluni" Width="150"></asp:DropDownList>
                    </td>
                    </tr>--%>
                
                     <tr>
                    <td>Cuenta:</td>
                    <td>
                        <asp:TextBox runat="server" ID ="txtcuenta" placeholder="CUENTA" Width="350" class="clcuenta" Enabled="false" ></asp:TextBox>
                    </td>
                    <td>
                        
                        <asp:TextBox runat="server" ID ="txtidcuenta" Width="150" OnTextChanged="txtidcuenta_TextChanged" AutoPostBack="true" Enabled="false"></asp:TextBox>
                    </td>

                    </tr>
                    <tr>
                        <td>Proveedor</td>
                        <td>
                            <asp:TextBox ID="txtprove" runat="server" Width="350" placeholder="PROVEEDOR" class="clprove" Enabled="false" ></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtidprove" runat="server" Width="150" OnTextChanged="txtidprove_TextChanged" AutoPostBack="true" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                    <td>Area:</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlsarea" Width="150"  Enabled="false" ></asp:DropDownList> 
                    </td>
                    </tr>

                    <tr>
                    <td>Moneda:</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlmone" Width="150"  Enabled="false"></asp:DropDownList> 
                    </td>
                    </tr>
                  <tr>
                    <td>Tipo Tarifa:</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddltipot" Width="150"  Enabled="false"></asp:DropDownList> 
                    </td>
                    </tr>
                      <%--<tr>
                    <td>Tipo:</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddltipo" Width="150"></asp:DropDownList> 
                    </td>
                    </tr>--%>
                <tr>
                    <td>Tarifa:</td>
                    <td>
                        <asp:TextBox ID="txttar" runat="server" Width="120" Enabled="false"></asp:TextBox>
                    </td> 
                    </tr> 
                <tr>
                    <td >
                         <asp:Button class="btn" Text="Nuevo" runat="server" ID="btnuevo" Enabled="true" OnClick="btnuevo_Click" UseSubmitBehavior="false"></asp:Button>
                    </td>
                    <td>
                         <asp:Button class="btn" Text="Grabar" runat="server" ID="btgrabar" Enabled="false" OnClick="btgrabar_Click"  UseSubmitBehavior="false"></asp:Button>
                    </td>
                </tr>
                </table> 
        </fieldset>
    </div>
 



   
</asp:Content>

