
<%@ Page Title="Aprobar Solicitud" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="AprobacionSolicitud.aspx.cs" Inherits="FINANZAS_TESORERIA_RENDICIONES_AprobacionSolicitud" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link type="text/css" href="../../../CSS/base.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {
            UHTML.id = 'MainContent';
            $("#MainContent_txtfecha").datepicker();
            $("#MainContent_txtfechaini").datepicker();
            $("#MainContent_txtfechafin").datepicker();
            $("#MainContent_txtcuenta").autocomplete(
  {
      source: function (request, response) {
          $.ajax({
              url: "AprobacionSolicitud.aspx/ListarCtaE1",
              data: "{ 'descri': '" + request.term + "', 'moneda': '' }",
              dataType: "json",
              type: "POST",
              contentType: "application/json; charset=utf-8",
              dataFilter: function (data) { return data; },
              success: function (data) {
                  response($.map(data.d, function (item) {
                      return {
                          id: item.PCUENTA,
                          value: item.PDESCRI,

                      }
                  }))
              },
              error: function (XMLHttpRequest, textStatus, errorThrown) {
                }
          });
      },
      minLength: 1,
      select: function (event, ui) {
          var str = ui.item.id;
          var cadena = str
          posicionEspacio = cadena.indexOf("@"), //Obtengo la posición del espacio en la cadena
          primerApellido = cadena.substring(0, posicionEspacio) //Obtengo la porción deseada de la cadena
          enMinuscula = primerApellido.toLowerCase(); //Convierto el apellido a minúscula
          primerApellido = cadena.substring(posicionEspacio + 1, str.length)
          $('#MainContent_txtcodcuenta').val(str);
          

      }
  });

            $("#MainContent_txtcodsolicitante").autocomplete(
   {
       source: function (request, response) {
           $.ajax({
               url: "AprobacionSolicitud.aspx/ListarProveedoresporid",
               data: "{ 'texto': '" + request.term + "','cod': 'T','i': 'C' }",
               dataType: "json",
               type: "POST",
               contentType: "application/json; charset=utf-8",
               dataFilter: function (data) { return data; },
               success: function (data) {
                   response($.map(data.d, function (item) {
                       return {
                           id: item.ADESANE,
                           value: item.ACODANE,

                       }
                   }))
               },
               error: function (XMLHttpRequest, textStatus, errorThrown) {
                 
               }
           });
       },
       minLength: 1,
       select: function (event, ui) {
           var str = ui.item.id;
           var cadena = str
           posicionEspacio = cadena.indexOf("@"), //Obtengo la posición del espacio en la cadena
           primerApellido = cadena.substring(0, posicionEspacio) //Obtengo la porción deseada de la cadena
           enMinuscula = primerApellido.toLowerCase(); //Convierto el apellido a minúscula
           primerApellido = cadena.substring(posicionEspacio + 1, str.length)
           $('#MainContent_txtsolicitante').val(str);
      }
   });
            $("#MainContent_txtcodsolicitanteb").autocomplete(
{
    source: function (request, response) {
        $.ajax({
            url: "AprobacionSolicitud.aspx/ListarProveedoresporid",
            data: "{ 'texto': '" + request.term + "','cod': 'T','i': 'C' }",
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataFilter: function (data) { return data; },
            success: function (data) {
                response($.map(data.d, function (item) {
                    return {
                        id: item.ADESANE,
                        value: item.ACODANE,

                    }
                }))
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {

            }
        });
    },
    minLength: 1,
    select: function (event, ui) {
        var str = ui.item.id;
        var cadena = str
        posicionEspacio = cadena.indexOf("@"), //Obtengo la posición del espacio en la cadena
        primerApellido = cadena.substring(0, posicionEspacio) //Obtengo la porción deseada de la cadena
        enMinuscula = primerApellido.toLowerCase(); //Convierto el apellido a minúscula
        primerApellido = cadena.substring(posicionEspacio + 1, str.length)
        $('#MainContent_txtsolicitanteb').val(str);
       }
});


            $("#MainContent_txtcodbanco").autocomplete(
{
    source: function (request, response) {
        $.ajax({
            url: "AprobacionSolicitud.aspx/ListarBancosProg",
            data: "{ 'productos': '" + request.term + "' }",
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataFilter: function (data) { return data; },
            success: function (data) {
                response($.map(data.d, function (item) {
                    return {
                        id: item.CT_CDESCTA,
                        value: item.CT_CNUMCTA,
                        v: item.CT_CCODMON,
                        b: item.CT_CCUENTA,
                    }
                }))
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
            }
        });
    },
    minLength: 1,
    select: function (event, ui) {
        var str = ui.item.id;
        var cadena = str;
        posicionEspacio = cadena.indexOf("@"), //Obtengo la posición del espacio en la cadena
        primerApellido = cadena.substring(0, posicionEspacio) //Obtengo la porción deseada de la cadena
        enMinuscula = primerApellido.toLowerCase(); //Convierto el apellido a minúscula
        primerApellido = cadena.substring(posicionEspacio + 1, str.length)
        $('#MainContent_txtbanco').val(str);
       }
});

            $("#MainContent_txtcodbancob").autocomplete(
{
    source: function (request, response) {
        $.ajax({
            url: "AprobacionSolicitud.aspx/ListarBancosProg",
            data: "{ 'productos': '" + request.term + "' }",
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataFilter: function (data) { return data; },
            success: function (data) {
                response($.map(data.d, function (item) {
                    return {
                        id: item.CT_CDESCTA,
                        value: item.CT_CNUMCTA,
                        v: item.CT_CCODMON,
                        b: item.CT_CCUENTA,
                    }
                }))
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
            }
        });
    },
    minLength: 1,
    select: function (event, ui) {
        var str = ui.item.id;
        var cadena = str;
        posicionEspacio = cadena.indexOf("@"), //Obtengo la posición del espacio en la cadena
        primerApellido = cadena.substring(0, posicionEspacio) //Obtengo la porción deseada de la cadena
        enMinuscula = primerApellido.toLowerCase(); //Convierto el apellido a minúscula
        primerApellido = cadena.substring(posicionEspacio + 1, str.length)
        $('#MainContent_txtbancob').val(str);
    }
});


            $("#MainContent_txtbanco").autocomplete(
               {
                   source: function (request, response) {
                       $.ajax({
                           url: "AprobacionSolicitud.aspx/ListarBancosProg",
                           data: "{ 'productos': '" + request.term + "' }",
                           dataType: "json",
                           type: "POST",
                           contentType: "application/json; charset=utf-8",
                           dataFilter: function (data) { return data; },
                           success: function (data) {
                               response($.map(data.d, function (item) {
                                   return {
                                       id: item.CT_CNUMCTA,
                                       value: item.CT_CDESCTA,
                                       v: item.CT_CCODMON,
                                       b: item.CT_CCUENTA,
                                   }
                               }))
                           },
                           error: function (XMLHttpRequest, textStatus, errorThrown) {
                               }
                       });
                   },
                   minLength: 1,
                   select: function (event, ui) {
                       var str = ui.item.id;
                       var cadena = str
                       posicionEspacio = cadena.indexOf("@"), //Obtengo la posición del espacio en la cadena
                       primerApellido = cadena.substring(0, posicionEspacio) //Obtengo la porción deseada de la cadena
                       enMinuscula = primerApellido.toLowerCase(); //Convierto el apellido a minúscula
                       primerApellido = cadena.substring(posicionEspacio + 1, str.length)
                       $('#MainContent_txtcodbanco').val(str);
                   }
               });
            $("#MainContent_txtbancob").autocomplete(
          {
              source: function (request, response) {
                  $.ajax({
                      url: "AprobacionSolicitud.aspx/ListarBancosProg",
                      data: "{ 'productos': '" + request.term + "' }",
                      dataType: "json",
                      type: "POST",
                      contentType: "application/json; charset=utf-8",
                      dataFilter: function (data) { return data; },
                      success: function (data) {
                          response($.map(data.d, function (item) {
                              return {
                                  id: item.CT_CNUMCTA,
                                  value: item.CT_CDESCTA,
                                  v: item.CT_CCODMON,
                                  b: item.CT_CCUENTA,
                              }
                          }))
                      },
                      error: function (XMLHttpRequest, textStatus, errorThrown) {
                      }
                  });
              },
              minLength: 1,
              select: function (event, ui) {
                  var str = ui.item.id;
                  var cadena = str
                  posicionEspacio = cadena.indexOf("@"), //Obtengo la posición del espacio en la cadena
                  primerApellido = cadena.substring(0, posicionEspacio) //Obtengo la porción deseada de la cadena
                  enMinuscula = primerApellido.toLowerCase(); //Convierto el apellido a minúscula
                  primerApellido = cadena.substring(posicionEspacio + 1, str.length)
                  $('#MainContent_txtcodbancob').val(str);
              }
          });


            $('#NuevoItem').dialog({
                autoOpen: false,
                modal: true,
                resizable: true,
                width: 700,
                heigth: 100,
                title: 'Registro',
                close: function (event, ui) {
                    Operacion.mask('txtindicador').val("");
                },
            });

            //$(".Nuevo").click(function () {
            //    Operacion.mask('txtindicador').val("1");
            //    $("#NuevoItem").dialog('open');
            //    Operacion.mask('txtnumero').val(Operacion.cadenaMascara(generar().contador,10));
            //});

            $(".modificar").click(function () {
                Operacion.mask('txtindicador').val("2");
                trp = $(this).parent().parent();
                id = $("td:eq(2)", trp).html();
                TIPO = $("td:eq(0)", trp).html();
                $("#NuevoItem").dialog('open');
                    Operacion.mask('txtnumero').val(id);
                    ConsultaUno(TIPO);
                              
                
            });

            function generar() {
                var solicitud = "";
                var contador = 0;

                $.ajax({

                    type: "POST",
                    url: "AprobacionSolicitud.aspx/GENERAR",
                    data: "",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        // console.log(data);
                        //alert(data.d);
                        contador = Number(data.d)+1;

                    },
                    error: function (data) {
                        if (data.length != 0)
                            alert(data);
                    }
                });
                return { contador };
            }
            $(".Aprobar").click(function () {
                if (Operacion.mask('txtestado').val().trim() == "P") {
                    if (confirm("¿ Desea aprobar esta solicitud ? ")) {
                        ActualizaSolicitud("A");
                    }
                   
                }
                else {
                    alert("No es posible la operación ya que la solicitud se encuentra "+(Operacion.mask('txtestado').val()=="A"?"APROBADA": Operacion.mask('txtestado').val()=="L"?"LIQUIDADA":"ANULADA"));
                }
                   
            });
            $(".Desaprobar").click(function () {
                if (Operacion.mask('txtestado').val().trim() == "A") {
                    if (confirm("¿ Desea desaprobar esta solicitud ? ")) {
                        ActualizaSolicitud("P");
                    }

                }
                else {
                    alert("No es posible la operación ya que la solicitud se encuentra " + (Operacion.mask('txtestado').val() == "P" ? "PENDIENTE" : Operacion.mask('txtestado').val() == "L" ? "LIQUIDADA" : "ANULADA"));
                }

            });
            $(".Anular").click(function () {
                if (Operacion.mask('txtestado').val().trim() != "L" && Operacion.mask('txtestado').val().trim() != "N") {
                    if (confirm("¿ Desea anular esta solicitud ? ")) {
                        ActualizaSolicitud("N");
                    }

                }
                else {
                    alert("No es posible la operación ya que la solicitud se encuentra " + (Operacion.mask('txtestado').val() == "A" ? "APROBADA" : Operacion.mask('txtestado').val() == "L" ? "LIQUIDADA" : "ANULADA"));
                }

            });
           
            $(".imprimir").click(function () {
                trp = $(this).parent().parent();
                id = $("td:eq(2)", trp).html();
                Tipo = $("td:eq(0)", trp).html();
                Estado = $("td:eq(7)", trp).html();
                window.open("../RENDICIONES/ImprimirSolicitud.aspx?NUMERO= " + id + "&TIPO=" + Tipo + "&ESTADO=" + Estado, '_blank');

            });

            function ActualizaSolicitud(ESTADO) {
                var datos = {};
                var f = moment($("#MainContent_txtfecha").val(), "DD/MM/YYYY");
                f = f == null ? null : new Date(f);
                var f1 = moment($("#MainContent_txtfechaactual").val(), "DD/MM/YYYY");
                f1 = f1 == null ? null : new Date(f1);
                datos.CODIGO_CAJA = Operacion.mask('ddltipoentrega').val();
                datos.ORDEN_NUMERO = Operacion.mask('txtnumero').val();
                datos.FECHA = f;
                datos.COD_SOLICITANTE = Operacion.mask('txtcodsolicitante').val();
                datos.SOLICITANTE = Operacion.mask('txtsolicitante').val();
                datos.COD_BANCO = Operacion.mask('txtcodbanco').val();
                datos.BANCO = Operacion.mask('txtbanco').val();
                datos.NUMERO_CUENTA = Operacion.mask('txtnumerocuenta').val();
                datos.MONTO = Operacion.mask('txtmonto').val();
                datos.MOTIVO = Operacion.mask('txtcuenta').val();
                if(ESTADO.trim()=="A"){ // SI LO ESTOY APROBANDO
                datos.APROB1 = (Operacion.mask('txtusuario1').val()==""? Operacion.mask('lblusuario').text(): Operacion.mask('txtusuario1').val() );
                datos.APROB2 = ((Operacion.mask('txtusuario2').val()=="" && Operacion.mask('txtusuario1').val()=="")? "":Operacion.mask('lblusuario').text());
                datos.APROB3 = ((Operacion.mask('txtusuario2').val() == "" && Operacion.mask('txtusuario1').val() == "") ? "" : ((Operacion.mask('txtusuario2').val() != "" && Operacion.mask('txtusuario1').val() != "") ? Operacion.mask('lblusuario').text() : ""));
                datos.ESTADO = ((Operacion.mask('txtusuario2').val() != "" && Operacion.mask('txtusuario1').val() != "") ? "A" : "P");
                }
                if (ESTADO.trim() == "N") { // SI LO ESTOY ANULANDO
                    datos.APROB1 = null;
                    datos.APROB2 = null;
                    datos.APROB3 = null;
                    datos.ESTADO ="N";
                }
                if (ESTADO.trim() == "P") { // SI LO ESTOY DESAPROBANDO
                    datos.APROB1 = null;
                    datos.APROB2 = null;
                    datos.APROB3 = null;
                    datos.ESTADO = "P";
                }
                datos.CCOMPRO = null;
                datos.CCUENTA = Operacion.mask('txtcodcuenta').val();
                datos.FECHA_CREACION = f1;
                datos.MONEDA = Operacion.mask('txtmoneda').val();
                datos.USUMOD = Operacion.mask('txtusumod').val();

                $.ajax({
                    type: "POST",
                    url: "AprobacionSolicitud.aspx/modificaoer",
                    data: '{datos: ' + JSON.stringify(datos) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        alert("Datos Guardados");
                        location.reload();
                    },
                    error: function (response) {
                        if (response.length != 0)
                            alert(response);
                        console.log(response);

                    }
                });
            }


            function ConsultaUno(TIPO) {
                var VC = {};
                VC.ORDEN_NUMERO = $("#MainContent_txtnumero").val();
                VC.CODIGO_CAJA=TIPO
                $.ajax({

                    type: "POST",
                    url: "AprobacionSolicitud.aspx/ListarUnDato",
                    data: '{com: ' + JSON.stringify(VC) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {                  
                        for (var i = 0; i < data.d.length; i++)
                        {
                              Operacion.mask('txtnumero').val(data.d[i].ORDEN_NUMERO);
                              Operacion.mask('txtfecha').val((data.d[i].FECHA).substring(0,10));
                              Operacion.mask('txtcodsolicitante').val(data.d[i].COD_SOLICITANTE);
                              Operacion.mask('txtsolicitante').val(data.d[i].SOLICITANTE);
                              Operacion.mask('txtcodbanco').val(data.d[i].COD_BANCO);
                              Operacion.mask('txtbanco').val(data.d[i].BANCO);
                              Operacion.mask('txtnumerocuenta').val(data.d[i].NUMERO_CUENTA);
                              Operacion.mask('txtmonto').val(data.d[i].MONTO);
                              Operacion.mask('txtcuenta').val(data.d[i].MOTIVO);
                              Operacion.mask('txtcodcuenta').val(data.d[i].CCUENTA);
                              Operacion.mask('txtusuario1').val(data.d[i].APROB1);
                              Operacion.mask('txtusuario2').val(data.d[i].APROB2);
                              Operacion.mask('txtusuario3').val(data.d[i].APROB3);
                              Operacion.mask('txtfechaactual').val((data.d[i].FECHA_CREACION).substring(0, 10));
                              Operacion.mask('txtestado').val(data.d[i].ESTADO);
                              Operacion.mask('txtmoneda').val(data.d[i].MONEDA);
                              Operacion.mask('txtusumod').val(data.d[i].USUMOD);
                              Operacion.mask('ddltipoentrega').val(data.d[i].CODIGO_CAJA);
                              
                         }
                    },
                    error: function (response) {
                        if (response.length != 0)
                            console.log(response);
                    }
                });

            }

        });
       

    </script>
    <style type="text/css">
        #btnactualizar {
            width: 69px;
        }

        #btnact {
            width: 146px;
        }

        #btnsalir {
            width: 58px;
        }

        #btnadicionales {
            width: 115px;
        }

        #btnfinalizar {
            width: 31px;
        }

        .seleciona {
        }
        .auto-style1 {
            width: 97px;
        }
        .auto-style2 {
            width: 149px;
        }
        .auto-style4 {
            width: 150px;
        }
        </style>
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="contenedor" style="overflow: auto; width: 1000px; height: 850px">
        <div id="Creacion" title="Creación">
            <table>
                <tr>
                 <td>
                   Número:
               </td>
               <td>
                   <asp:TextBox ID="txtnumerob" runat="server" ReadOnly="True"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td>
                   Fecha Ini:
               </td>
               <td>
                   <asp:TextBox ID="txtfechaini" runat="server" ></asp:TextBox>
               </td>
               <td>
                   Fecha Fin:
               
                   <asp:TextBox ID="txtfechafin" runat="server" ></asp:TextBox>
               </td>
           </tr>

           <tr>
               <td>
                   Solicitante:
               </td>
               <td>
                   <asp:TextBox ID="txtcodsolicitanteb" runat="server" ></asp:TextBox>
               </td>
                <td>
                   <asp:TextBox ID="txtsolicitanteb" runat="server" Width="257px" ></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td>
                   Banco:
               </td>
               <td>
                   <asp:TextBox ID="txtcodbancob" runat="server" ></asp:TextBox>
               </td>
               <td>
                   <asp:TextBox ID="txtbancob" runat="server" Width="257px" ></asp:TextBox>
               </td>
              </tr>
                <tr>
                    <td>
                        Estado:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlestado" runat="server" Height="16px" Width="121px">
                            <asp:ListItem Value="P">PENDIENTE</asp:ListItem>
                            <asp:ListItem Value="A">APROBADO</asp:ListItem>
                            <asp:ListItem Value="N">ANULADO</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="btnver" runat="server" Text="Consultar" OnClick="btnver_Click" />
                        
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        
                        <input id="btnnuevo" type="button" value="Nuevo" class="Nuevo" />
                        <asp:Label ID="lblusuario" runat="server" Text="" style="display:none"></asp:Label>
                        
                   
                    </td>
                </tr>
                <tr>
                    <td>
                       
                    </td>
                </tr>
            </table>
              <table>
                <tr>
                    <td>
                        <div style="overflow: auto; width: 950px; height: 550px">
                            <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" OnRowCreated="griddata_RowCreated" Font-Size="Smaller" Width="950px" class="buscar">
                                <Columns>
                                    <asp:BoundField DataField="CODIGO_CAJA" HeaderText="NUMERO" />
                                    <asp:BoundField DataField="TIPO" HeaderText="DESCRIPCION" />
                                    <asp:BoundField DataField="ORDEN_NUMERO" HeaderText="ORDEN" >
                                       
                                        </asp:BoundField>
                                    <asp:BoundField DataField="FECHA" HeaderText="FECHA" DataFormatString="{0:dd/MM/yyyy}">
                                       
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SOLICITANTE" HeaderText="SOLICITANTE">
                                        
                                           <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MOTIVO" HeaderText="MOTIVO" >
                                        
                                        </asp:BoundField>
                                    <asp:BoundField DataField="MONTO" HeaderText="MONTO" />


                                    <asp:BoundField DataField="ESTADO" HeaderText="ESTADO" >
                                       
                                        </asp:BoundField>


                                    <asp:BoundField DataField="APROB1" HeaderText="APROB1" />
                                    <asp:BoundField DataField="APROB2" HeaderText="APROB2" />
                                    <asp:BoundField DataField="APROB3" HeaderText="APROB3" />


                                    <asp:TemplateField HeaderText="MODIFICAR">


                                        <ItemTemplate>
                                            <div class="modificar" style="text-align: center">
                                                <img alt="" src="../../../Images/Message_Success.png" width="25" style="cursor: pointer" />
                                                <%--<asp:ImageButton ID="imbeliminar" runat="server" ImageUrl="~/Images/Message_Error.png" Width="25px" OnClick="ib_eliminar_Click" onclientclick="javascript:return confirm('Esta Seguro?')"/>--%>
                                            </div>
                                        </ItemTemplate>


                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="IMPRIMIR">


                                        <ItemTemplate>
                                            <div class="imprimir" style="text-align: center">
                                                <img alt="" src="../../../Images/Printer.png" width="25" style="cursor: pointer" />
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
                        </div>
                    </td>

                </tr>
            </table>
        </div>
    </div>
    <div id="NuevoItem" >
     <table>
           <tr>
               <td class="auto-style2">
                   Tipo Entrega:
               </td>
               <td>
                   <asp:DropDownList ID="ddltipoentrega" runat="server" Height="21px" Width="275px" class="generar" style="display" Enabled="False"></asp:DropDownList>
               </td>
           </tr>
           </table>
        <table>

           <tr>
               <td class="auto-style4">
                   Número:
               </td>
               <td>
                   <asp:TextBox ID="txtnumero" runat="server" ReadOnly="True" Enabled="False"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td class="auto-style4">
                   Fecha:
               </td>
               <td>
                   <asp:TextBox ID="txtfecha" runat="server" Enabled="False" ></asp:TextBox>
               </td>
           </tr>

           <tr>
               <td class="auto-style4">
                   Solicitante:
               </td>
               <td>
                   <asp:TextBox ID="txtcodsolicitante" runat="server" Enabled="False" ></asp:TextBox>
               </td>
                <td>
                   <asp:TextBox ID="txtsolicitante" runat="server" Width="257px" Enabled="False" ></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td class="auto-style4">
                   Banco:
               </td>
               <td>
                   <asp:TextBox ID="txtcodbanco" runat="server" Enabled="False" ></asp:TextBox>
               </td>
               <td>
                   <asp:TextBox ID="txtbanco" runat="server" Width="257px" Enabled="False" ></asp:TextBox>
               </td>
                
           </tr>
            <tr>
                <td class="auto-style4">Moneda</td>
                <td> <asp:DropDownList ID="txtmoneda" runat="server" Height="16px" Width="123px" Enabled="False">
                    <asp:ListItem Value="MN">MN (SOLES)</asp:ListItem>
                    <asp:ListItem Value="US">US (DOLARES)</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
           <tr>
               <td class="auto-style4">
                   Número Cuenta:
               </td>
               <td>
                   <asp:TextBox ID="txtnumerocuenta" runat="server" Enabled="False" ></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td class="auto-style4">
                   Monto:
               </td>
               <td>
                   <asp:TextBox ID="txtmonto" runat="server" Enabled="False" ></asp:TextBox>
               </td>
           </tr>
            </table>
         <table>

           <tr>
               <td class="auto-style2">
                   Motivo:
               </td>
               <td>
                   <asp:TextBox ID="txtcuenta" runat="server" Width="377px" Enabled="False"></asp:TextBox>
                    
                   </td>
               <td>
                   <asp:TextBox ID="txtcodcuenta" runat="server" style="display:none"></asp:TextBox>
                   <asp:TextBox ID="txtindicador" runat="server" style="display:none"></asp:TextBox>
                    <asp:TextBox ID="txtusuario1" runat="server" style="display:none"></asp:TextBox>
                    <asp:TextBox ID="txtusuario2" runat="server" style="display:none"></asp:TextBox>
                    <asp:TextBox ID="txtusuario3" runat="server" style="display:none"></asp:TextBox>
                    <asp:TextBox ID="txtfechaactual" runat="server" style="display:none" ></asp:TextBox>
                    <asp:TextBox ID="txtestado" runat="server" style="display:none" ></asp:TextBox>
                   <asp:TextBox ID="txtusumod" runat="server" style="display:none" ></asp:TextBox>

               </td>
           </tr>
             <tr>
                 <td class="auto-style2">
                     <input id="btngrabar" type="button" value="Aprobar" class="Aprobar" />
                 </td>
                 <td class="auto-style1">
                     <input id="btndesaprobar" type="button" value="Desaprobar" class="Desaprobar" />
                     <input id="btnanular" type="button" value="Anular" class="Anular" />
                 </td>
                 <td class="auto-style1">
                     
                 </td>
             </tr>
       </table>
    </div>
  
</asp:Content>

