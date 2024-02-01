<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="USSubtipo.aspx.cs" Inherits="Default2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link type="text/css" href="../CSS/Base-s.css?1.9" rel="stylesheet" />

    <script type="text/javascript">

      
        function ModifyEnterKeyPressAsTab(event,info){ 
           
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
    




            //var filtro = function () {
            //    var dd = 0;
            //    $(".filtrar tr:has(td)").each(function () {
            //        var t = $(this).text(); //$("td", rowt).eq(0)
            //        //console.log($(".filtrar td").eq(3).html());
            //        $("<td class='indexColumn'></td>")
                        
            //        .hide().text(t).appendTo(this);
            //        //console.log(t);
            //        dd++;
            //    });
            //    //Agregar el comportamiento al texto (se selecciona por el ID) 
            //    $("#MainContent_txtfiltra").keyup(function () {
            //        var upp = $(this).val().toUpperCase();
            //        var s = upp.split(" ");
            //        //console.log(s);
            //        $(".filtrar tr:hidden").show();
            //        $.each(s, function () {
            //            $(".filtrar tr:visible .indexColumn:not(:contains('"
            //            + this + "'))").parent().hide();
            //        });
            //    });
            //}

            //filtro();




            $("#MainContent_btbuscar").hide();

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

                $(".chktodos").click(function () {
                Operacion.Checktodos(this, "<%= gvareas.ClientID %>", 3);
                });
                 $(".chktodosn").click(function () {
                Operacion.Checktodos(this, "<%= gvnivel.ClientID %>", 2);
                });

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
            $(".clusua").autocomplete(
                          {
                              source: function (request, response) {
                                  $.ajax({
                                      url: "USSubtipo.aspx/listarusuarios",
                                      data: "{ nombre: '" + request.term +  "'}",
                                      dataType: "json",
                                      type: "POST",
                                      contentType: "application/json; charset=utf-8",
                                      dataFilter: function (data) { return data; },
                                      success: function (data) {
                                          response($.map(data.d, function (item) {
                                              return {
                                                  value: item.TU_NOMUSU,
                                                  id: item.TU_ALIAS.trim()
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
                                  $('#MainContent_txtidusua').val(str);

                                  $('#MainContent_btbuscar').trigger('click');
                                 
                                  
                              },
                              change: function (event, ui) {
                                  if (ui.item == null || ui.item == undefined) {
                                      $("#MainContent_txtidusua").val("");
                                      $(".clusua").focus();
                                      alert("No ha seleccionado El usuario");
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
            <legend>ASIGNACION DE USUARIOS POR SUBTIPOS</legend>

            <table>
                <tr><td colspan="2">SELECCIONE USUARIO</td></tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="txtidusua" Width="100" placenholder="CODIGO" OnTextChanged="txtidusua_TextChanged" AutoPostBack="true"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtusua" Width="300" placenholder="USUARIO" class="clusua" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
               
                    <td>AREA</td>
      
                </tr>
                <tr>
                    <td colspan="3" style="vertical-align:top">
                          <asp:GridView ID="gvareas" class="filtrar" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"  AutoGenerateColumns="False" Width="409px" >
                                     <Columns>
                                         <asp:BoundField DataField="IDTipo" HeaderText="ID"  ItemStyle-Width="10"  />
                                         <asp:BoundField DataField="Descripcion" HeaderText="SUBTIPO"  ItemStyle-Width="300"  />
                                         <asp:BoundField DataField="ST_NAPROB" HeaderText="N°APROB"  ItemStyle-Width="10"  />
                               
                                         <asp:TemplateField ItemStyle-Width="11px" >
                                         <HeaderTemplate> 
                                                  <div class ="ver" style="text-align:center" >
                                                      <input type="checkbox" class="chktodos" />
                                                 </div>
                                          </HeaderTemplate>
                                             
                                             <ItemTemplate>
                                                 <div class ="ver" style="text-align:center">
                                                     <asp:CheckBox runat="server" ID="chkSeleccion" />
                                                      <%--<input type="checkbox" class="chkplanilla" id="chkSeleccion" />--%>
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
                    <td style="vertical-align:top">
                        <asp:GridView ID="gvnivel" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"  AutoGenerateColumns="False" Width="228px">
                                     <Columns>
                                         <asp:BoundField DataField="NA_ID" HeaderText="ID"  ItemStyle-Width="10"  />
                                         <asp:BoundField DataField="NA_NIVEL" HeaderText="ACCIONES"  ItemStyle-Width="300"  />
                               
                                         <asp:TemplateField ItemStyle-Width="11px" >
                                         <HeaderTemplate> 
                                                  <div class ="ver" style="text-align:center" >
                                                      <input type="checkbox" class="chktodosn" />
                                                 </div>
                                          </HeaderTemplate>
                                             
                                             <ItemTemplate>
                                                 <div class ="ver" style="text-align:center">
                                                     <asp:CheckBox runat="server" ID="chkSeleccionn" />
                                                      <%--<input type="checkbox" class="chkplanilla" id="chkSeleccion" />--%>
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
                <tr><td>CORREO:</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtcorreo" Width="300" ></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table>
         <%--       <tr>
                    
                    <td>Codigo Almacen</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlalma" Width="350" ></asp:DropDownList> 
                    </td>
                </tr>--%>
                <tr>
                    <td >
                         <asp:Button class="btn" Text="Grabar" runat="server" ID="btacepta" OnClick="btacepta_Click" Enabled="true"></asp:Button>
                    </td>
                    
                </tr>
                </table>
        </fieldset>
            <table>
                <tr>
                    <td>
                        
                     <div id="dvp" style="display:none">
                         <asp:Button class="btn" Text="Buscar" runat="server" ID="btbuscar" Enabled="true" OnClick="btbuscar_Click"></asp:Button>
                         </div>
                    
                    </td>
                </tr>
            </table>
    </div>
 



   
</asp:Content>

