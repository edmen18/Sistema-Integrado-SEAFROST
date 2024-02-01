
<%@ Page Title="Actualizacion de Constancia" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ActualizacionConstancia.aspx.cs" Inherits="FINANZAS_TESORERIA_PAGOS_ActualizacionConstancia" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link type="text/css" href="../../../CSS/base.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {

           // $("#MainContent_txtfechapago").datepicker();
            UHTML.id = 'MainContent';
            //Operacion.mask('txtprogramacionmod').change(function () {
            //    Operacion.oACD('txtprogramacionmod');
            //    cabecera(Operacion.mask('txtprogramacionmod').val())
            //    filtrardetalles(Operacion.mask('txtprogramacionmod').val())
            //});
            $("#MainContent_txtfechapago").datepicker();
            Operacion.mask('txtconstinicial').change(function () {
                var lim = document.getElementById("<%=GridView1.ClientID %>").rows.length;  
                var gridView = document.getElementById("<%=GridView1.ClientID %>");
                Operacion.mask('txtconstfinal').val(Number(Operacion.mask('txtconstinicial').val()) + (Number(lim)-2));
                var i = 0;
                for (i = 0; i < (lim-1); i++){
                   gridView.rows[i+1].cells[7].innerHTML= (Number(Operacion.mask('txtconstinicial').val()) + Number(i));
                }

            });
            $(window).load(function () {
                Constancia();
            });


            //$("#MainContent_txtprogramacionmod").autocomplete(
            //    {
            //        source: function (request, response) {
            //            $.ajax({
            //                url: "ActualizacionConstancia.aspx/autocomplete",
            //                data: "{ 'productos': '" + request.term + "' }",
            //                dataType: "json",
            //                type: "POST",
            //                contentType: "application/json; charset=utf-8",
            //                dataFilter: function (data) { return data; },
            //                success: function (data) {
            //                    response($.map(data.d, function (item) {
            //                        return {
            //                            id: item.GC_CNUMOPE,
            //                            value: item.GC_CNUMOPE,
            //                        }
            //                    }))
            //                },
            //                error: function (XMLHttpRequest, textStatus, errorThrown) {
            //                    //alert(textStatus);
            //                }
            //            });
            //        },
            //        minLength: 1,
            //        select: function (event, ui) {
            //            var str = ui.item.id;
            //            var cadena = str
            //            posicionEspacio = cadena.indexOf("@"), //Obtengo la posición del espacio en la cadena
            //            primerApellido = cadena.substring(0, posicionEspacio) //Obtengo la porción deseada de la cadena
            //            enMinuscula = primerApellido.toLowerCase(); //Convierto el apellido a minúscula
            //            primerApellido = cadena.substring(posicionEspacio + 1, str.length)
            //        }
            //    });
            function Constancia() {
               
                $.ajax({
                    type: "POST",
                    url: "ActualizacionConstancia.aspx/autocomplete",
                   // data: '{dato: ' + JSON.stringify(dato) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        $("#MainContent_txtprogramacionmod").val(data.d);
                    },
                    error: function (data) {
                        if (data.length != 0)
                            console.log(data);
                    }
                });
              
            }

            function Nombre(dato) {
                var NOMBRE = "";

                    $.ajax({
                    type: "POST",
                    url: "ActualizacionConstancia.aspx/NOMBRE",
                    data: '{dato: ' + JSON.stringify(dato) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                       NOMBRE = data.d.AC_CNOMBRE;
                                           },
                    error: function (data) {
                        if (data.length != 0)
                            console.log(data);
                    }
                });
                return { NOMBRE };
            }

            function filtrardetalles(codigo) {
                var long = 0;
                var ADATA = {};

                $.ajax({

                    type: "POST",
                    url: "ActualizacionConstancia.aspx/LISTARTTODOS",
                    data: "{ 'dato': '" + codigo + "' }",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                           if (data.d.length > 0) {
                            var row = $("[id*=GridView1] tr:last-child").clone(true);
                            $("[id*=GridView1] tr").not($("[id*=GridView1] tr:first-child")).remove();

                            for (var i = 0; i < data.d.length; i++) {

                                $("td", row).eq(0).val(data.d[i].GD_CSECUE);
                              
                                $("td", row).eq(0).html(data.d[i].GD_CVANEXO);
                                $("td", row).eq(1).html(data.d[i].GD_CCODIGO);
                                // CODIGO PARA TRAER EL NOMBRE
                                ADATA.AC_CVANEXO = data.d[i].GD_CVANEXO;
                                ADATA.AC_CCODIGO = data.d[i].GD_CCODIGO;
                                $("td", row).eq(2).html(Nombre(ADATA).NOMBRE);
                                // FIN NOMBRE
                                $("td", row).eq(3).html(data.d[i].GD_CTIPDOC);
                                $("td", row).eq(4).html(data.d[i].GD_CNUMDOC);

                                $("td", row).eq(5).html(data.d[i].GD_CSUBDIA);
                                $("td", row).eq(6).html(data.d[i].GD_CCOMPRO);
                               
                                $("td", row).eq(7).html("");
                                $("td", row).eq(8).html(Number(data.d[i].GD_NMNPROG).toFixed(2));
                                $("td", row).eq(9).html(data.d[i].GD_CTASDET);
                            
                                $("[id*=GridView1]").append(row);
                                row = $("[id*=GridView1] tr:last-child").clone(true);
                            }
                        } else {
                            var row = $("[id*=GridView1] tr:last-child").clone(true);
                            $("[id*=GridView1] tr").not($("[id*=GridView1] tr:first-child")).remove();

                            $("td", row).eq(1).html("");
                            $("td", row).eq(2).html("");
                            $("td", row).eq(3).html("");
                            $("td", row).eq(4).html("");
                            $("td", row).eq(5).html("");
                            $("td", row).eq(6).html("");
                            $("td", row).eq(7).html("");
                            $("td", row).eq(8).html("");
                            $("td", row).eq(9).html("");
                            $("td", row).eq(10).html("");
                            $("[id*=GridView1]").append(row);
                            //alert("no se encontro registro");
                        }


                    },
                    error: function (response) {
                        if (response.length != 0)
                            alert(response);
                    }
                });
            }


            function cabecera(codigo) {
                $.ajax({

                    type: "POST",
                    url: "ActualizacionConstancia.aspx/LISTARUNO",
                    data: "{ 'CODATA': '" + codigo + "' }",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {

                        if (data.d.length > 0) {
                            //alert("Se encontro registro");

                            for (var i = 0; i < data.d.length; i++) {
                                $('#MainContent_lblcodagencia').html(data.d[i].AGENCIA);
                                $('#MainContent_lblagencia').html(data.d[i].AGENCIA2);
                               
                                $('#MainContent_lblconcepto').html(data.d[i].CONCEPTO);
                                $('#MainContent_lbltipopago').html(data.d[i].tipopago);
                                $('#MainContent_lblmoneda').html(data.d[i].moneda);
                                $('#MainContent_txttipocambiomod').val(data.d[i].TIPOCAMBIO);
                                $('#MainContent_txtmontomod').val(Number(data.d[i].IMPORTE).toFixed(2));
                                $('#MainContent_txtfechaprogmod').val((moment(data.d[i].fecah).format("DD/MM/YYYY")));
                                $('#MainContent_lbldetraccion').html(data.d[i].TIPODETRACCION);
                                $('#MainContent_lblcoddetraccion').html(data.d[i].TASADETRACCION);
                                $('#MainContent_lbldepartamento').html(data.d[i].DEPARTAMENTO);
                                $('#MainContent_lblcodbanco').html(data.d[i].CODBANCO);
                                $('#MainContent_lblbanco').html(data.d[i].BANCO);
                                $('#MainContent_txtestadomod').val(data.d[i].ESTADO);

                            }
                        } else {

                            alert("No existen Datos para la programacion o ya ha sido actualizada");
                            location.reload();
                        }


                    },
                    error: function (response) {
                        if (response.length != 0)
                            console.log(response);
                    }
                });
            }

            $('#Modificacion').dialog({
                autoOpen: false,
                modal: true,
                resizable: true,
                width: 550,
                heigth: 100,
                title: 'Editar Constancia',
                close: function (event, ui) {
                                   },

            });
            $(".consultar").click(function () {
            Operacion.oACD('txtprogramacionmod');
            cabecera(Operacion.mask('txtprogramacionmod').val())
            filtrardetalles(Operacion.mask('txtprogramacionmod').val())
            });

            $(".editar").click(function () { //  se debe colocar dentrp de una funcion 
                $("#Modificacion").dialog('open');
                Operacion.mask('lblconstfinal').html(Operacion.mask('txtconstfinal').val())
                Operacion.mask('lblconstinicial').html(Operacion.mask('txtconstinicial').val());
                trp = $(this).parent().parent();
                constancia = $("td:eq(7)", trp).html();
                documento = $("td:eq(4)", trp).html();
                acreedor = $("td:eq(1)", trp).html();
                acreedor1 = $("td:eq(2)", trp).html();
                t = $("td:eq(0)", trp).html();
               $("#MainContent_lblconstactual").html(constancia);
                $("#MainContent_lbldocumento").html(documento);
                $("#MainContent_lblacreedor").html(acreedor);
                $("#MainContent_lblacreedor1").html(acreedor1);
                $("#MainContent_lblt").html(t);
            });

            $(".actualizar").click(function () { //  se debe colocar dentrp de una funcion 
                UpdateEjec();
               // location.reload();           

            });


            $(".update").click(function () { //  se debe colocar dentrp de una funcion 
       
                if ((Number($("#MainContent_txtconstnueva").val()) >= Number($("#MainContent_txtconstinicial").val()))
                   && (Number($("#MainContent_txtconstnueva").val()) <= Number($("#MainContent_txtconstfinal").val()))
                  ) {

               
                 var lim = document.getElementById("<%=GridView1.ClientID %>").rows.length;  
                var gridView = document.getElementById("<%=GridView1.ClientID %>");
                var i = 0;
                for (i = 0; i < (lim-1); i++){
                    if ((gridView.rows[i + 1].cells[0].textContent == $("#MainContent_lblt").html())
                        && (gridView.rows[i + 1].cells[1].textContent == $("#MainContent_lblacreedor").html())
                        && (gridView.rows[i + 1].cells[4].textContent == $("#MainContent_lbldocumento").html())
                        ) {
                        alert("actualizado");
                        gridView.rows[i + 1].cells[7].innerHTML = $("#MainContent_txtconstnueva").val();

                    }
                }
                $("#Modificacion").dialog('close');
                }
                else {
                    alert("Ingrese un valor dentro del rango de contancias");
                }
            });

            // ACTUALIZAR DATOS :
            // TABLA EJEC
            function UpdateEjec(){
                var DETA = {};
                var fecha = new Date();
                DETA.GC_CCODAGE = $("#MainContent_lblcodagencia").html().trim();
                DETA.GC_CNUMOPE = $("#MainContent_txtprogramacionmod").val();
                DETA.GC_CNOPEDE = $("#MainContent_txtconstancia").val();
                var f = moment($("#MainContent_txtfechapago").val(), "DD/MM/YYYY");
                f = f == null ? null : new Date(f);
                DETA.GC_DFEDEPD = f;
                        $.ajax({
                            type: "POST",
                            url: "ActualizacionConstancia.aspx/UpdateConstanciaEjec",
                            data: '{DETA: ' + JSON.stringify(DETA) + '}',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            async: false,
                            success: function (response) {
                                alert("Registro Grabado");
                                UpdateEjed();
                                ObtenerDatos();
                            },
                            error: function (response) {
                                if (response.length != 0)
                                  console.log(response);
                            }
                        });
            }
            // ACTUALIZAR DATOS :
            // TABLA EJED
            function UpdateEjed() {
                var DETA = {};
                DETA.GD_CCODAGE = $("#MainContent_lblcodagencia").html().trim();
                DETA.GD_CNUMOPE = $("#MainContent_txtprogramacionmod").val();

                var lim = document.getElementById("<%=GridView1.ClientID %>").rows.length;  
                var gridView = document.getElementById("<%=GridView1.ClientID %>");
                var i = 0;
                for (i = 0; i < (lim - 1) ; i++) {
                    DETA.GD_CSECUE = gridView.rows[i + 1].cells[0].value
                    DETA.GD_CNOCONS= gridView.rows[i + 1].cells[7].innerHTML
                    $.ajax({

                        type: "POST",
                        url: "ActualizacionConstancia.aspx/UpdateConstanciaEjed",
                        data: '{DETA: ' + JSON.stringify(DETA) + '}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (response) {
                           // alert("Registro Grabado detalle");
                        },
                        error: function (response) {
                            if (response.length != 0)
                                console.log(response);
                        }
                    });
                }
            }

             // ACTUALIZAR DATOS :
            // TABLA DETALLE COMPROBANTE
            function UpdateCOMD16(DETA) {
                     $.ajax({
                        type: "POST",
                        url: "ActualizacionConstancia.aspx/ActualizaConstancia",
                        data: '{COM: ' + JSON.stringify(DETA) + '}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (response) {
                          // alert("Registro Grabado detalle");
                        },
                        error: function (response) {
                            if (response.length != 0)
                                console.log(response);
                        }
                    });
               
            }

            // ACTUALIZAR DATOS :
            // obtener datos de la tabla cartera
            function ObtenerDatos() {
                var DETA = {};
                var fecha = new Date();
                var COMPROBANTEDET1 = {};
                var lim = document.getElementById("<%=GridView1.ClientID %>").rows.length;  
                var gridView = document.getElementById("<%=GridView1.ClientID %>");
                var i = 0;
                for (i = 0; i < (lim - 1) ; i++) {
                    DETA.CP_CVANEXO = gridView.rows[i + 1].cells[0].innerHTML;
                    DETA.CP_CCODIGO = gridView.rows[i + 1].cells[1].innerHTML;
                    DETA.CP_CTIPDOC=  gridView.rows[i + 1].cells[3].innerHTML;
                    DETA.CP_CNUMDOC = gridView.rows[i + 1].cells[4].innerHTML;
                  
                    $.ajax({

                        type: "POST",
                        url: "ActualizacionConstancia.aspx/obtenerDOC",
                        data: '{DETA: ' + JSON.stringify(DETA) + '}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (data) {                           
                                    //PARAMETORS PARA LA CONDICION
                                    COMPROBANTEDET1.DSUBDIA = data.d.CP_CSUBDIA;
                                    COMPROBANTEDET1.DCOMPRO=data.d.CP_CCOMPRO;
                                    COMPROBANTEDET1.DNUMDOC = data.d.CP_CNUMDOC;
                                    COMPROBANTEDET1.DSECUE = data.d.CP_CSECDET;
                                    COMPROBANTEDET1.DCODANE = gridView.rows[i + 1].cells[1].innerHTML;
                                    // PARAMETROS PARA LA ACTUALIZACION
                                    COMPROBANTEDET1.DNUMDOR = gridView.rows[i + 1].cells[7].innerHTML;
                                    var f = moment($("#MainContent_txtfechapago").val(), "DD/MM/YYYY");
                                    f = f == null ? null : new Date(f);
                                    COMPROBANTEDET1.DFECDO2 = f;
                                    UpdateCOMD16(COMPROBANTEDET1);
                           
                        },
                        error: function (response) {
                            if (response.length != 0)
                                console.log(response);
                            }
                    });
                }
            }
            
       });

        </script>
    <style type="text/css">
        #btnactualizar {
            width: 69px;
        }
        .auto-style1 {
            width: 131px;
        }
        #btnact {
            width: 146px;
        }
        #btnsalir {
            width: 125px;
        }
    </style>
    </asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   <div id="contenedor">
      <div id="Creacion" title="Creación">

     <table>
                <tr>
                    <td>Agencia&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                    <td>
                        <asp:Label ID="lblcodagencia" runat="server" Text=""></asp:Label>
                        -
                        <asp:Label ID="lblagencia" runat="server" Text=""></asp:Label></td>
                    <td>Monto&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                    <td>
                        <asp:TextBox ID="txtmontomod" runat="server" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Num.Prog.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                    <td>
                        <asp:TextBox ID="txtprogramacionmod" runat="server" Width="170px" Enabled="true"></asp:TextBox>
                         <input id="btverdados" type="button" value="Consultar" class="consultar" />
                    </td>
                 
                    <td>Fech. Prog.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                    <td>
                        <asp:TextBox ID="txtfechaprogmod" runat="server" Enabled="false"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td>Concepto&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                    <td>
                        <asp:Label ID="lblcodconcepto" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lblconcepto" runat="server" Text=""></asp:Label>
                    </td>

                    <td>Tipo Detracción:</td>
                    <td>
                        <asp:Label ID="lblcoddetraccion" runat="server" Text=""></asp:Label>-
                        <asp:Label ID="lbldetraccion" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Tipo Pago&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                    <td>
                        <asp:Label ID="lblcodtipopago" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lbltipopago" runat="server" Text=""></asp:Label>
                    </td>

                    <td>Departamento&nbsp; :</td>
                    <td>
                        <asp:Label ID="lblcoddepartamento" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lbldepartamento" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Moneda&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                    <td>
                        <asp:Label ID="lblcodmoneda" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lblmoneda" runat="server" Text=""></asp:Label>
                    </td>

                    <td>Banco&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                    <td>
                        <asp:Label ID="lblcodbanco" runat="server" Text=""></asp:Label>-
                        <asp:Label ID="lblbanco" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Tipo de Cambio:</td>
                    <td>
                        <asp:TextBox ID="txttipocambiomod" runat="server" Enabled="false"></asp:TextBox>

                    </td>
                    <td>Estado&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                    <td>
                        <asp:TextBox ID="txtestadomod" runat="server" Text="" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
            </table>
          <table>
              <tr>
                  <td>Número Operación</td>
                  <td>
                      <asp:TextBox ID="txtconstancia" runat="server"></asp:TextBox></td>
              </tr>
              <tr>
                  <td>Constancia Inicial:</td>
                  <td>
                      <asp:TextBox ID="txtconstinicial" runat="server"></asp:TextBox></td>
                  <td>Constancia Final</td>
                  <td>
                      <asp:TextBox ID="txtconstfinal" runat="server"></asp:TextBox></td>
                  </tr>
              <tr>
                  <td>Fecha Pago</td>
                  <td>
                      <asp:TextBox ID="txtfechapago" runat="server" ReadOnly="false"></asp:TextBox></td>
              </tr>

          </table>


            <table>
                <tr>
                    <td>
                        <div style="overflow: auto; width: 850px; height: 150px">
                            <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" OnRowCreated="griddata_RowCreated" Font-Size="Smaller" Width="830px">
                                <Columns>
                                    <asp:BoundField DataField="GD_CVANEXO" HeaderText="T" />
                                    <asp:BoundField DataField="GD_CCODIGO" HeaderText="CODIGO" />
                                    <asp:BoundField DataField="ACREEDOR" HeaderText="NOMBRE">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="GD_CTIPDOC" HeaderText="TD" />
                                    <asp:BoundField DataField="GD_CNUMDOC" HeaderText="NRO. DOC" />
                                    <asp:BoundField DataField="GD_CSUBDIA" HeaderText="SUB. D">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="GD_CCOMPRO" HeaderText="COMPRO.">

                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="CONSTANCIA" HeaderText="NRO. CONST.">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="GD_NMNPROG" HeaderText="IMP. PAGO">

                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField= "GD_CTASDET" HeaderText ="TAS. DET.">
                                    <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>


                                    <asp:TemplateField HeaderText="EDIT. CONST.">

                                        
                                    <ItemTemplate>
                                        <div class="editar" style="text-align: center">
                                            <img alt="" src="../../../Images/edit.png" width="25" style="cursor: pointer" />
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
          <table>
              <tr>
                       <td>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <input id="btnact" type="button" value="Actualizar Constancia" class="actualizar" />
                    </td>
                </tr>
          </table>
          </div>
        </div>
      <div id="Modificacion" style="display:none">
      <table>
          <tr> 
          <td>Rango de Constancias: </td>
          <td> <asp:Label ID="lblconstinicial" runat="server" Text=""></asp:Label></td>
              <td> - </td>
          <td> <asp:Label ID="lblconstfinal" runat="server" Text=""></asp:Label></td>
          </tr>
      </table>

          <table>
           
                <tr> 
                  <td class="auto-style1">Documento: </td>
                  <td>
                      <asp:Label ID="lbldocumento" runat="server" Text=""></asp:Label> </td>
              </tr>
                <tr> 
                  <td class="auto-style1">Acreedor:</td>
                  <td>
                      <asp:Label ID="lblt" runat="server" Text=""></asp:Label> 
                      <asp:Label ID="lblacreedor" runat="server" Text=""></asp:Label> 
                       <asp:Label ID="lblacreedor1" runat="server" Text=""></asp:Label>
                  </td>
              </tr>
                 <tr> 
                  <td class="auto-style1">Constancia Actual:</td>
                  <td>
                      <asp:Label ID="lblconstactual" runat="server" Text=""></asp:Label> </td>
              </tr>
               <tr> 
                  <td class="auto-style1">Nueva Constancia: </td>
                  <td>
                      <asp:TextBox ID="txtconstnueva" runat="server" Width="109px"></asp:TextBox>  &nbsp;
                      <input id="btnactualizar" type="button" value="Actualizar" class="update" /></td>
              </tr>

          </table>
      </div>

</asp:Content>
