<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Bitacora.aspx.cs" Inherits="Bitacora" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link type="text/css" href="../../CSS/Base-s.css?2.5" rel="stylesheet" />

    <script type="text/javascript">

        function ModifyEnterKeyPressAsTab(event, info) {

            if (event.keyCode == 13) {
                cb = parseInt($(info).attr('tabindex'));
                cb2 = cb + 1;
                if ($(':input[TabIndex=\'' + (cb2) + '\']') != null) {
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

         

            $("#MainContent_gvdetalle td:nth-child(5), #MainContent_gvdetalle th:nth-child(5)").hide();
            $("#MainContent_gvdetalle td:nth-child(6), #MainContent_gvdetalle th:nth-child(6)").hide();

            miconsulta = 'getProducto';
            cc = 1;
            sw_edicion = 0;
            sw_nuevo = 0;
            sw_guardar = 0;
            DS_SUMAT = 0;
            DS_SUMATUS = 0;
            DS_SUMATMN = 0;
            contaditem = 0;
            $("#MainContent_txtfecha").datepicker();
            $(function () {
                UHTML.id = 'MainContent';
                Operacion.iValida(Operacion.mask("txtcant"), 1);
            });

            $.urlParam = function (name) {
                var results = new RegExp('[\?&]' + name + '=([^&#]*)').exec(window.location.href);
                return (results != null ? results[1] || 0 : "");
            }


         
            ISSAL = "";
            

            //mostrar informacion a editar
            $.urlParam = function (name) {
                var results = new RegExp('[\?&]' + name + '=([^&#]*)').exec(window.location.href);
                return (results != null ? results[1] || 0 : "");
            }
            var IDSO = $.urlParam("ID");//window.location.search.substring(1);
            var TDC = $.urlParam("TD");
            if (IDSO.length > 0) {
                sw_guardar = 1;
              

            } else {
                Operacion.mask("txtfecha").val(moment().format("DD/MM/YYYY"));
                Operacion.mask("TextBox1").val(moment().format("HH:mm"));
                Operacion.mask("TextBox2").val(moment().format("HH:mm"));
            }

            
            textsuboc = Operacion.mask("ddlsarea").val();
         
          


        });
     
        function grabardetallegrid(numero) {
                eliminaBitacoraDet(numero);
                var gridView = document.getElementById("<%=gvdetalle.ClientID %>");
                for (var t = 1; t < gridView.rows.length; t++) {
                    cellPivot01D = gridView.rows[t].cells[0];
                    cellPivot02D = gridView.rows[t].cells[1];
                    cellPivot03D = gridView.rows[t].cells[2];
                    cellPivot04D = gridView.rows[t].cells[3];

                    codLabor = gridView.rows[t].cells[4];
                    detalle_labor = gridView.rows[t].cells[5];

                    alert(gridView.rows[t].cells[3].value);
                    alert(gridView.rows[t].cells[4].value);

                    var tabla_transporte_detViaje = {};
                    tabla_transporte_detViaje.numero = numero;
                    tabla_transporte_detViaje.codpasajero = cellPivot01D.value;
                    tabla_transporte_detViaje.codparadero = cellPivot02D.value;
                    tabla_transporte_detViaje.codigo = cellPivot01D.innerHTML;

                    tabla_transporte_detViaje.detalle_pasajero = cellPivot02D.innerHTML;
                    tabla_transporte_detViaje.codcco = cellPivot03D.value;
                    tabla_transporte_detViaje.detalle_ccosto = cellPivot04D.value;

                    tabla_transporte_detViaje.codLabor = codLabor.value;
                    tabla_transporte_detViaje.detalle_labor = detalle_labor.value;
                 
                    alert(codLabor);
                    console.log(tabla_transporte_detViaje);
                    
                    
                    InsertarDetalle(tabla_transporte_detViaje);
                  
                }
             }

    

        function InsertarDetalle(tabla_transporte_detViaje) {
                 $.ajax({
                 type: "POST",
                 url: "Bitacora.aspx/InsertaBitacoraDet",
                 data: '{DET: ' + JSON.stringify(tabla_transporte_detViaje) + '}',
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 async: false,
                 success: function (response) { },
                 error: function (response) {
                     if (response.length != 0)
                         console.table(response);
                 }
             });
         }

        function eliminaBitacoraDet(numeroBitacora) {

             $.ajax({
                 type: "POST",
                 url: "Bitacora.aspx/eliminaBitacoraDet",
                 data: "{numero:'" + numeroBitacora + "'}",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 async: false,
                 success: function (response) { },
                 error: function (response) {
                     if (response.length != 0)
                         console.table(response);
                 }
             });

         }
   
         function NumeroBitacora() {
             var dato;

             $.ajax({

                 type: "POST",
                 url: "Bitacora.aspx/obtenNumeroBitacora",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 async: false,
                 success: function (data) {
                   
                     dato = data.d;
                 },
                 error: function (data) {
                     if (data.length != 0)
                         alert(data);
                 }

             });
             return dato;
         }

         function MostrarPersona(codigo) {
             var dato;
           
             $.ajax({

                 type: "POST",
                 url: "Bitacora.aspx/obtenTrabajador",
                 data: "{codigo:'" + codigo + "'}",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 async: false,
                 success: function (data) {
                    
                     dato = data;
                 },
                 error: function (data) {
                     if (data.length != 0)
                         alert(data);
                 }

             });
             return dato;
         }


         function ListarCostos(costo) {
             var dato;

             $.ajax({

                 type: "POST",
                 url: "Bitacora.aspx/ListarCostos",
                 data: "{costo:'" + costo + "'}",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 async: false,
                 success: function (data) {

                     dato = data.d;
                 },
                 error: function (data) {
                     if (data.length != 0)
                         alert(data);
                 }

             });
             return dato;
         }

         function ListarLabores(costo) {
             var dato;

             $.ajax({

                 type: "POST",
                 url: "Bitacora.aspx/ListarLabores",
                 data: "{costo:'" + costo + "'}",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 async: false,
                 success: function (data) {

                     dato = data.d;
                 },
                 error: function (data) {
                     if (data.length != 0)
                         alert(data);
                 }

             });
             return dato;
         }

    

         function MostrarPersonaDetalle(codigo) {
             var dato;

             $.ajax({

                 type: "POST",
                 url: "Bitacora.aspx/obtenTrabajadorDetalle",
                 data: "{codigo:'" + codigo + "'}",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 async: false,
                 success: function (data) {

                     dato = data;
                 },
                 error: function (data) {
                     if (data.length != 0)
                         alert(data);
                 }

             });
             return dato;
         }

        $(function () {
                   

            $(".clbtgrabar").click(function () {

                var fec1 = moment($("#MainContent_txtfecha").val(), "DD/MM/YYYY");
                fec1 = fec1 == null ? null : new Date(fec1);
              
                if (sw_guardar == 0) {
                    var codg =  NumeroBitacora();
                    $("#MainContent_txtnumdoc").val(codg);
                    sw_guardar = 1;
                }
              
                var tabla_transporte_cabViaje = {};
                 tabla_transporte_cabViaje.numero = $("#MainContent_txtnumdoc").val();
                 tabla_transporte_cabViaje.codprocedencia = $("#MainContent_ddlprocedencia").val();
                 tabla_transporte_cabViaje.codplaca = $("#MainContent_ddltipos").val();
                 tabla_transporte_cabViaje.codchofer = $("#MainContent_ddlchofer").val();
                 tabla_transporte_cabViaje.codturno = $("#MainContent_ddlturno").val();
                 tabla_transporte_cabViaje.fechaCreacion = fec1;
                 tabla_transporte_cabViaje.horaPartida = fec1;
                 tabla_transporte_cabViaje.horallegada = fec1;
                 tabla_transporte_cabViaje.codvigilante = $("#MainContent_ddlvigilante").val();
                 tabla_transporte_cabViaje.usuarioCreacion = $("#MainContent_hfusu").val();
                 tabla_transporte_cabViaje.horaPartida = $("#MainContent_TextBox1").val();
                 tabla_transporte_cabViaje.horallegada = $("#MainContent_TextBox2").val();

                 tabla_transporte_cabViaje.detalle_chofer = $("#MainContent_ddlchofer option:selected").text();
                 tabla_transporte_cabViaje.detalle_vigilante = $("#MainContent_ddlvigilante option:selected").text();
             
                
                 InsertarCabecera(tabla_transporte_cabViaje);
               
            });

            $(".clbtnuevo").click(function () {
                $(".ctxtidsoli").val("");
                $(".idart").val("");
                Operacion.mask("txttra").val("");
                Operacion.mask("txtnumdoc").val("");
                //Operacion.mask("txtfecha").val("");
                Operacion.mask("txtund").val("");
                Operacion.mask("txtstock").val("");
                Operacion.mask("txtcant").val("");
                Operacion.mask("txtsoli").val("");
                Operacion.mask("txtidprod").val("");
                Operacion.mask("txtcodcos").val("");
                Operacion.mask("ddlccost").val("");
                $(".ctxtidsoli").focus(); 

                //limpiar gridview
                var lrow = $("[id*=gvdetalle] tr:last-child").clone(true);
                $("[id*=gvdetalle] tr").not($("[id*=gvdetalle] tr:first-child")).remove();
                $("td", lrow).eq(0).html("");
                $("td", lrow).eq(1).html("");
                $("td", lrow).eq(2).html("");
              
                $("[id*=gvdetalle]").append(lrow);
                lrow = $("[id*=gvdetalle] tr:last-child").clone(true);
                cc = 1;
                sw_guardar = 0;
                contaditem = 0;
            });

            function pad(str, max) {
                str = str.toString();
                return str.length < max ? pad("0" + str, max) : str;
            }
            $(".clcant").change(function () {
              var rowt = $("[id*=gvdetalle] tr:last-child").clone(true);
                    if (cc == 1) {
                        $("[id*=gvdetalle] tr").not($("[id*=gvdetalle] tr:first-child")).remove();
                        cc = 2;
                    }
                    paradero = $("#MainContent_ddlparadero option:selected").text();
                    codigo = $("#MainContent_ddlcodigo").val() + pad($("#MainContent_txtund").val(), 5);
                    codparadero = $("#MainContent_ddlparadero").val();
                  
                    persona = MostrarPersona(codigo);
                    trabajador = persona.d.Detalle;


                    dni = persona.d.CodPer;
                    personadetalle = MostrarPersonaDetalle(dni);
                  
                    costo = personadetalle.d.Costo;
                    detalle_costo = ListarCostos(costo);
                    codlabor = personadetalle.d.LaborRealizada;
                    labor = ListarLabores(codlabor);

                    console.log(codlabor);
                    console.log(labor);
                  
                     $("td", rowt).eq(0).html(codigo);
                     $("td", rowt).eq(1).html(trabajador);
                     $("td", rowt).eq(2).html(paradero);

                     $("td", rowt).eq(0).val(dni);
                     $("td", rowt).eq(1).val(codparadero);
                     $("td", rowt).eq(2).val(costo);
                     $("td", rowt).eq(3).val(detalle_costo);

                     $("td", rowt).eq(4).val(codlabor);
                     $("td", rowt).eq(5).val(labor);
                   
                 
                     $("[id*=gvdetalle]").append(rowt);
                    rowt = $("[id*=gvdetalle] tr:last-child").clone(true);
                }
            );
            $(".btelimina").click(function () {
                var trp = $(this).parent().parent();
               
                var nfila = $(".filtrar tr").size() - 1;
                if (nfila == 1) {
                    $("td", trp).eq(0).html("");
                    $("td", trp).eq(1).html("");
                    $("td", trp).eq(2).html("");
                    $("td", trp).eq(0).val("");
                    $("td", trp).eq(1).val("");
                    cc = 1;
                }else{trp.remove();} 

                    
                    
                
            });

            function InsertarCabecera(cabViaje) {
             
                    $.ajax({
                    type: "POST",
                    url: "Bitacora.aspx/InsertaBitacoraCab",
                    data: '{cabViaje: ' + JSON.stringify(cabViaje) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) { grabardetallegrid(cabViaje.numero) },
                    error: function (response) {
                        if (response.length != 0)
                            console.table(response);
                    }
                });

            }

        });

     

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
    <div id="contenedor">
        <fieldset>
            <legend>BITACORA DE TRANSPORTE</legend>
        
            <table>
                <tr>
                    <td>N° Bitacora</td>
                    <td colspan="3">
                        <asp:TextBox runat="server" Width="100" Enabled="false" ID="txtnumdoc" BackColor="#ffffcc"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>Vehiculo</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddltipos"></asp:DropDownList>
                    </td>
                </tr>
               <tr>
                    <td>Procedencia</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlprocedencia"></asp:DropDownList>
                    </td>
                </tr>
                 <tr>
                    <td>Chofer</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlchofer"></asp:DropDownList>
                    </td>
                </tr>
                 <tr>
                    <td>Vigilante</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlvigilante"></asp:DropDownList>
                    </td>
                </tr>
                  <tr>
                    <td>Turno</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlturno"></asp:DropDownList>
                    </td>
                </tr>
              
                <tr>
                    <td>Fecha</td>
                    <td colspan="3">
                        <asp:TextBox ID="txtfecha" runat="server" class="tcamb" placeholder="00/00/0000" Width="100" TabIndex="6" onkeydown="Operacion.MEKPAT(event,this);"></asp:TextBox>
                       
                    </td>
                </tr>
                    <tr>
                    <td>Hora Partida</td>
                    <td colspan="3">
                        <asp:TextBox ID="TextBox1" runat="server" class="tcamb" placeholder="00/00/0000" Width="100" TabIndex="6" onkeydown="Operacion.MEKPAT(event,this);"></asp:TextBox>
                       
                    </td>
                </tr>
                      <tr>
                    <td>Hora Llegada</td>
                    <td colspan="3">
                        <asp:TextBox ID="TextBox2" runat="server" class="tcamb" placeholder="00/00/0000" Width="100" TabIndex="6" onkeydown="Operacion.MEKPAT(event,this);"></asp:TextBox>
                       
                    </td>
                </tr>
               

             

            </table>
            <fieldset>
                <table>
                    
                   
                                 <tr>
                        <td >Paradero:</td>
                        <td>
                            <asp:DropDownList runat="server"  ID="ddlparadero" TabIndex="9" onkeydown="Operacion.MEKPAT(event,this);" /></td>
                    </tr>
                                 <tr>
                        <td colspan="2">Trabajador:
                       
                        <asp:DropDownList runat="server" ID="ddlcodigo"></asp:DropDownList>
                       
                            <asp:TextBox runat="server"  class="clcant" ID="txtund"  ></asp:TextBox>
                       
                          
                        </td>
                    </tr>
                           
                         
                   
                   
                  
              
                   
                  
                </table>
            </fieldset>
            <table>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="gvdetalle" class="filtrar" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" Width="709px">
                            <Columns>
                               
                                <asp:BoundField DataField="SA_ID" HeaderText="CODIGO" ItemStyle-Width="10" ItemStyle-BackColor="#ffffcc" ItemStyle-HorizontalAlign="Right" >
<ItemStyle HorizontalAlign="Right" BackColor="#FFFFCC" Width="10px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="SA_DESC" HeaderText="TRABAJADOR" ItemStyle-Width="10" ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center" Width="400px"></ItemStyle>
                                </asp:BoundField>
                               
                                 <asp:BoundField DataField="PARADERO" HeaderText="PARADERO" ItemStyle-Width="10" ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center" Width="10px"></ItemStyle>
                                </asp:BoundField>

                                <asp:TemplateField HeaderText="ELIMINAR">
                                    <ItemTemplate>
                                        <div class="btelimina" style="text-align: center">
                                            <img alt="" src="../../Images/desaprob.png" width="20" style="cursor: pointer" />
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField  />
                                  <asp:BoundField  />
                               

                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="false" ForeColor="White" Height="25" />
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
               
            </table>
            <table>
                <tr>
                    <td>
                          <input runat="server" type="button" class="clbtnuevo btn" value="Nuevo" id="btnuevo" />
                    </td>
                    <td>
                           <input runat="server" type="button" class="clbtgrabar btn" id="btgrabar" value="Guardar"  />
&nbsp;</td>
                </tr>
            </table>
            <asp:HiddenField ID="hfusu" runat="server" />
        </fieldset>
    </div>



</asp:Content>

