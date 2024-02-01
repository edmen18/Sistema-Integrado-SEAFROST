
<%@ Page Title="Eliminación de Comprobante Cheques" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="EliminarCheque.aspx.cs" Inherits="FINANZAS_TESORERIA_CHEQUES_EliminarCheque" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link type="text/css" href="../../../CSS/base.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {
            UHTML.id = 'MainContent';
            $(window).load(function () {
                SUBDIA = "";
                COMPRO = "";
                CHEQUE = "";


            });

            $(".btdetalles").click(function () {

                $("#dvdetalle").dialog('open');
                trp = $(this).parent().parent();
                SUBDIA = $("td:eq(0)", trp).html();
                COMPRO = $("td:eq(1)", trp).html();
                CHEQUE = $("td:eq(2)", trp).html();
                filtrardetalles(SUBDIA, COMPRO);
                filtrarcabecera(SUBDIA, COMPRO, 0);
               

            });

            $('#dvdetalle').dialog({
                autoOpen: false,
                modal: true,
                resizable: true,
                width: 880,
                heigth: 300,
                title: 'Detalle-Eliminación',
                close: function (event, ui) {

                },

            });

            function filtrarcabecera(SUBDIA, COMPRO,ind) {
                var CODATA = {};
               // alert(SUBDIA + "-" + COMPRO);
                CODATA.CSUBDIA = SUBDIA;
                CODATA.CCOMPRO = COMPRO;
                var CONTROL416 = {};
                var LOG1 = {};
                
                var fecemi = new Date();

                $.ajax({

                    type: "POST",
                    url: "EliminarCheque.aspx/CABECERA",
                    data: '{CODATA: ' + JSON.stringify(CODATA) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                            if (ind==0){
                            Operacion.mask('txtcomprobante').val(data.d.CSUBDIA + " - " + data.d.CCOMPRO);
                            Operacion.mask('txtsituacion').val((data.d.CSITUA.trim() == "F" ? "FINALIZADO" : data.d.CSITUA)); //
                            Operacion.mask('txtfecha').val((moment(data.d.CDATE).format("DD/MM/YYYY")));
                            Operacion.mask('txtmoneda').val(data.d.CCODMON);
                            Operacion.mask('txtglosa').val(data.d.CGLOSA);
                            Operacion.mask('txtconversion').val(data.d.CFLAG);
                            Operacion.mask('txtforma').val((data.d.CFORM.trim() == "A" ? "AUTOMATICA" : "MANUAL")); //
                            Operacion.mask('txttipo').val(data.d.CTIPO);
                            Operacion.mask('txtcompro').val((data.d.CTIPCOM.trim() == "05" ? data.d.CTIPCOM + " CANCELACION DE DOCUMENTOS CON CHEQUE" : data.d.CTIPCOM));
                            Operacion.mask('txtcambio').val(data.d.CTIPCAM);
                        }
                        else {
                            CONTROL416.LG_CSUBDIA = data.d.CSUBDIA;
                            CONTROL416.LG_CCOMPRO = data.d.CCOMPRO;
                            CONTROL416.LG_CSECUEN = Operacion.cadenaMascara(generarsecuencia(SUBDIA, COMPRO).contador, 4);
                            var cdate416 = moment(data.d.CDATE, "DD/MM/YYYY");
                            cdate416 = cdate416 == null ? null : new Date(cdate416);
                            CONTROL416.LG_DCOMPRO = cdate416;
                            CONTROL416.LG_CGLOSA = data.d.CGLOSA;
                            CONTROL416.LG_CCODMON = data.d.CCODMON;
                            CONTROL416.LG_DIMPORT = data.d.CTOTAL;
                            CONTROL416.LG_CUSER = Operacion.mask('lblusuario').text();
                            CONTROL416.LG_CUSUCRE = data.d.CUSER;
                            CONTROL416.LG_DFECELI = fecemi;
                            CONTROL416.LG_DFECCRE = cdate416;
                            INSERTACONTROL16(CONTROL416);

                            LOG1.CSUBDIA = data.d.CSUBDIA;
                            LOG1.CCOMPRO =data.d.CCOMPRO ;
                            LOG1.CFECCOM =data.d.CFECCOM ;
                            LOG1.CSITUA = data.d.CSITUA;
                            LOG1.CCODMON = data.d.CCODMON;
                            LOG1.CTIPCAM =data.d.CTIPCAM ;
                            LOG1.CGLOSA =data.d.CGLOSA ;
                            LOG1.CTOTAL =data.d.CTOTAL ;
                            LOG1.CTIPO =data.d.CTIPO ;
                            LOG1.CFLAG = data.d.CFLAG;
                            var cdate = moment(data.d.CDATE, "DD/MM/YYYY");
                            cdate = cdate == null ? null : new Date(cdate);
                            LOG1.CDATE = cdate;
                            LOG1.CHORA =data.d.CHORA ;
                            LOG1.CFECCAM =data.d.CFECCAM ;
                            LOG1.CUSER =data.d.CUSER ;
                            LOG1.CORIG =data.d.CORIG ;
                            LOG1.CFORM = data.d.CFORM;
                            LOG1.CTIPCOM =data.d.CTIPCOM;
                            LOG1.CDPTO ="" ;
                            LOG1.CEXTOR ="" ;
                            LOG1.CTIPTRA ="EL" ;
                            LOG1.CCOMEN ="" ;
                            LOG1.CCOMEN2 ="" ;
                            LOG1.CDATE2 = fecemi;
                            LOG1.CHORA2 = fecemi.getHours() + ":" + ((fecemi.getMinutes()).toString().length < 2 ? "0" + fecemi.getMinutes() : fecemi.getMinutes());
                            LOG1.CUSER2 = Operacion.mask('lblusuario').text() ;
                            LOG1.CFECCOM2 = null;
                            LOG1.CFVECCAM2 = null;
                            INSERTALOG1(LOG1);

                        }


                    },
                    error: function (response) {
                        if (response.length != 0)
                            alert(response);
                    }
                });
            }


            function filtrardetalles(SUBDIA, COMPRO) {
            var COM = {};
           /// alert(SUBDIA+"-"+COMPRO);       
            COM.DSUBDIA = SUBDIA;
            COM.DCOMPRO = COMPRO;

            $.ajax({

                type: "POST",
                url: "EliminarCheque.aspx/ConsultaunDetalle",
                data: '{COM: ' + JSON.stringify(COM) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {

                    if (data.d.length > 0) {
                        var row = $("[id*=gvdetalle] tr:last-child").clone(true);
                        $("[id*=gvdetalle] tr").not($("[id*=gvdetalle] tr:first-child")).remove();

                        for (var i = 0; i < data.d.length; i++) {
                            $("td", row).eq(0).html(data.d[i].DSECUE);
                            $("td", row).eq(1).html(data.d[i].DCUENTA);
                            $("td", row).eq(1).val(data.d[i].DANECOM);

                            $("td", row).eq(2).html(data.d[i].DVANEXO);
                            $("td", row).eq(2).val(data.d[i].DCODANE);
                            $("td", row).eq(3).html(data.d[i].DCENCOS);
                            $("td", row).eq(4).html(data.d[i].DDH);
                            $("td", row).eq(5).html(data.d[i].DIMPORT);
                            $("td", row).eq(5).val(data.d[i].DMNIMPOR);
                            $("td", row).eq(6).html(data.d[i].DTIPDOC);
                            $("td", row).eq(6).val(data.d[i].DUSIMPOR);
                            $("td", row).eq(7).html(data.d[i].DNUMDOC);

                            $("[id*=gvdetalle]").append(row);
                            row = $("[id*=gvdetalle] tr:last-child").clone(true);
                        }
                    } else {
                        var row = $("[id*=gvdetalle] tr:last-child").clone(true);
                        $("[id*=gvdetalle] tr").not($("[id*=gvdetalle] tr:first-child")).remove();

                        $("td", row).eq(1).html("");
                        $("td", row).eq(2).html("");
                        $("td", row).eq(3).html("");
                        $("td", row).eq(4).html("");
                        $("td", row).eq(5).html("");
                        $("td", row).eq(6).html("");
                        $("td", row).eq(7).html("");
                        $("td", row).eq(0).html("");
                       $("[id*=gvdetalle]").append(row);
                        alert("no se encontro registro");
                    }


                },
                error: function (response) {
                    if (response.length != 0)
                        alert(response);
                }
            });
            }

            function generarsecuencia() {
                var COM = {};
                 COM.LG_CSUBDIA = SUBDIA;
                 COM.LG_CCOMPRO = COMPRO;
                 var contador = "";

                $.ajax({

                    type: "POST",
                    url: "EliminarCheque.aspx/GeneraSecuencia",
                    data: '{COM: ' + JSON.stringify(COM) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                      contador = data.d;

                    },
                    error: function (data) {
                        if (data.length != 0)
                            alert(data);
                    }
                });
                return { contador };
            }

            // PROCESO DE ELIMINACION
            $(".ELIMINA").click(function () {
                if (Operacion.mask('txttipo').val().trim() != "M") {
                    filtrarcabecera(SUBDIA, COMPRO, 1);
                }
                else {
                    alert("El Comprobante se encuentra eliminado");
                }

                

             });

            function INSERTACONTROL16(CONTROL416) {
                 var f = new Date();

                
                                $.ajax({
                                 type: "POST",
                                 url: "EliminarCheque.aspx/insertaCabeceraCONTROL16",
                                 data: '{CONTROL416: ' + JSON.stringify(CONTROL416) + '}',
                                 contentType: "application/json; charset=utf-8",
                                 dataType: "json",
                                 async: false,
                                 success: function (response) {
                                     //alert("REGISTRO GUARDADO");
                                  
                                 },
                                 error: function (response) {
                                            if (response.length != 0)
                                                console.log(response);
                                            console.log(CONTROL416);
                                            }  });
                                
                                                                
            }
            function INSERTALOG1(LOG1) {
                var f = new Date();

               
                    $.ajax({
                        type: "POST",
                        url: "EliminarCheque.aspx/insertaCabeceraLOG1",
                        data: '{LOG1: ' + JSON.stringify(LOG1) + '}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (response) {

                            // alert("REGISTRO GUARDADO");
                            ActCartera();
                        },
                        error: function (response) {
                            if (response.length != 0)
                                console.log(response);
                            console.log(LOG1);
                        }
                    });

            }
                 function ActCartera() {                
                 var i = 0;
                 var DETA = {};         
                                  
                 var gridView = document.getElementById("<%=gvdetalle.ClientID %>");
                     var M_LEN = gridView.rows.length;
                         
                         for (i = 1; i < M_LEN; i++) {
                             if ((gridView.rows[i].cells[2].innerHTML.trim() != "" && gridView.rows[i].cells[2].innerHTML.trim() != "0") && gridView.rows[i].cells[7].innerHTML != "") {
                                 //alert(gridView.rows[i].cells[2].innerHTML +" - "+ gridView.rows[i].cells[7].innerHTML);
                                 DETA.CP_CTIPDOC = gridView.rows[i].cells[6].innerHTML;
                                 DETA.CP_CNUMDOC = gridView.rows[i].cells[7].innerHTML;
                                 DETA.CP_CVANEXO = gridView.rows[i].cells[2].innerHTML;
                                 DETA.CP_CCODIGO = gridView.rows[i].cells[2].value;
                                 $.ajax({
                                 type: "POST",
                                 url: "EliminarCheque.aspx/ActualizarSaldo",
                                 data: '{DETA: ' + JSON.stringify(DETA) + '}',
                                 contentType: "application/json; charset=utf-8",
                                 dataType: "json",
                                 async: false,
                                 success: function (response) {                                    
                                    
                                 },
                                 error: function (response) {
                                            if (response.length != 0)
                                                console.log(response);
                                            }  });
                                
                             }
                             if (Number(M_LEN) - Number(i) == 1) {
                                 InsertaBalh();
                             }
                         }
                      
                
                 }

            function InsertaBalh()
            {
               var conta = 0;
               var fecha = new Date();
               var gridView5 = document.getElementById("<%=gvdetalle.ClientID %>");
               var BDATA = {};
               for (var t = 1; t < gridView5.rows.length; t++) {

                   BDATA.BCUENTA = (gridView5.rows[t].cells[1].innerHTML).trim();
                   BDATA.BMNSALA = 0;
                   if (gridView5.rows[t].cells[4].innerHTML.trim() == "D") {
                       BDATA.BMNDEBE = (gridView5.rows[t].cells[5].value == "" ? 0 : Operacion.mround(Number(gridView5.rows[t].cells[5].value), 2));
                       BDATA.BUSDEBE = (gridView5.rows[t].cells[6].value == "" ? 0 : Operacion.mround(Number(gridView5.rows[t].cells[6].value), 2));
                       BDATA.BMNHABER = 0;
                       BDATA.BUSHABER = 0;
                   }
                   if (gridView5.rows[t].cells[4].innerHTML.trim() == "H") {
                       BDATA.BMNHABER = (gridView5.rows[t].cells[5].value == "" ? 0 : Operacion.mround(Number(gridView5.rows[t].cells[5].value), 2));
                       BDATA.BUSHABER = (gridView5.rows[t].cells[6].value == "" ? 0 : Operacion.mround(Number(gridView5.rows[t].cells[6].value), 2));
                       BDATA.BMNDEBE = 0;
                       BDATA.BUSDEBE = 0;
                   }
                   BDATA.BMNSALN = 0;
                   BDATA.BUSSALA = 0;
                   BDATA.BUSSALN = 0;
                   BDATA.BMNSALI = 0;
                   BDATA.BUSSALI = 0;
                   BDATA.BFECPRO = "";
                   BDATA.BFORBAL = "0";//CONTROL PARA DECREMENTAR 
                   BDATA.BFORGYP = "";
                   BDATA.BFORRE1 = "";
                   BDATA.BCTAAJU = "";
                   BDATA.BFECPRO2 = (fecha.getFullYear().toString() + "" + (Number(fecha.getMonth() + 1) < 10 ? "0" + (fecha.getMonth() + 1) : (fecha.getMonth() + 1))).trim();
                   $.ajax({
                       type: "POST",
                       url: "EliminarCheque.aspx/ActualizarBalh",
                       data: '{DETA: ' + JSON.stringify(BDATA) + '}',
                       contentType: "application/json; charset=utf-8",
                       dataType: "json",
                       async: false,
                       success: function (response) {
                           conta = 1;
                           //alert("Balh actualizado");
                       },
                       error: function (response) {
                           if (response.length != 0)
                               alert(response);
                           console.log(BDATA);
                           conta = 0;
                        }
                   });
               }
               EliminaPago();
               //location.reload();
           }

            function EliminaPago() {
                var DETA = {};
                var gridView = document.getElementById("<%=gvdetalle.ClientID %>");
                var M_LEN = gridView.rows.length;
                
                for (i = 1; i < M_LEN; i++) {
               if ((gridView.rows[i].cells[2].innerHTML.trim() != "" && gridView.rows[i].cells[2].innerHTML.trim() != "0"))
                {
                DETA.PG_CTIPDOC = gridView.rows[i].cells[6].innerHTML.trim();
                DETA.PG_CNUMDOC = gridView.rows[i].cells[7].innerHTML.trim();
                DETA.PG_CVANEXO = gridView.rows[i].cells[2].innerHTML.trim();
                DETA.PG_CCODIGO = gridView.rows[i].cells[2].value.trim();
                DETA.PG_CORDKEY = gridView.rows[i].cells[1].value.trim();
                alert(gridView.rows[i].cells[1].value);
                DETA.PG_CSUBDIA = "23";

                $.ajax({
                    type: "POST",
                    url: "EliminarCheque.aspx/EliminaPago",
                    data: '{DETA: ' + JSON.stringify(DETA) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        //alert("Elimina Pago");
                    },
                    error: function (data) {
                        if (data.length != 0)
                            console.log("pago");
                            console.log(data);
                    }
                });
            }
                }
                EliminaCheque();
       }
            function EliminaCheque() {
                var ELIM = {};
                ELIM.CH_CSUBDIA = SUBDIA;
                ELIM.CH_CNUMCOM = COMPRO;
                ELIM.CH_CNUMCHE = CHEQUE;

                $.ajax({

                    type: "POST",
                    url: "EliminarCheque.aspx/EliminaCheque",
                    data: '{DETA: ' + JSON.stringify(ELIM) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        //alert("Elimina Cheque");
                        EliminaComc16();
                    },
                    error: function (data) {
                        if (data.length != 0)
                            console.log("cheque");
                        console.log(data);
                    }
                });
            }


            function EliminaComc16() {
                var ELIM = {};
                ELIM.CSUBDIA = SUBDIA;
                ELIM.CCOMPRO = COMPRO;

                $.ajax({

                    type: "POST",
                    url: "EliminarCheque.aspx/EliminaComc16",
                    data: '{DETA: ' + JSON.stringify(ELIM) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async:false,
                    success: function (data) {
                        alert("El Comprobante   Nº " + COMPRO+" ha sido eliminado");
                        EliminaComd16();
                        location.reload();
                    },
                    error: function (data) {
                        if (data.length != 0)
                            console.log("cabcomprobante");
                        console.log(data);
                    }
                });
            }

            function EliminaComd16() {
                var ELIM = {};
                ELIM.DSUBDIA = SUBDIA;
                ELIM.DCOMPRO = COMPRO;
                var gridView = document.getElementById("<%=gvdetalle.ClientID %>");
                var M_LEN = gridView.rows.length;
                for (i = 1; i < M_LEN; i++) {
                    ELIM.DSECUE = gridView.rows[i].cells[0].innerHTML;

                $.ajax({

                    type: "POST",
                    url: "EliminarCheque.aspx/EliminaComd16",
                    data: '{DETA: ' + JSON.stringify(ELIM) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                      

                    },
                    error: function (data) {
                        if (data.length != 0)
                            console.log("detcompro");
                        console.log(data);
                    }
                });
                }
                //
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
        .seleciona {}
    </style>
    </asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="contenedor">
      <div id="Creacion" title="Creación">
          <TABLE>

              <tr>
                
                  <td>
                      Comprobante: </td>
                  <td> <asp:TextBox ID="txtcomprobanteb" runat="server"></asp:TextBox></td>
                  <td>
                      Cheque: </td>
                   <td><asp:TextBox ID="txtchequeb" runat="server"></asp:TextBox> </td>
                  <td>
                      <asp:Button ID="btnver" runat="server" Text="Consultar" OnClick="btnver_Click" />
                  </td>
                  <td>
                      <asp:Label ID="lblcuentapago" runat="server" Text="" style="display:none"></asp:Label>
                      <asp:Label ID="lblusuario" runat="server" Text="" style="display:none"></asp:Label>
                  </td>
                  <td>
                      <asp:Label ID="lblcuentaretencion" runat="server" Text="" style="display:none"></asp:Label>
                  </td>
              </tr>
          </TABLE>
   
            <table>
                <tr>
                    <td>
                        <div style="overflow: auto; width: 850px; height: 550px">
                            <asp:GridView ID="gvcomprobantes" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" OnRowCreated="griddata_RowCreated" Font-Size="Smaller" Width="830px">
                                <Columns>
                                    <asp:BoundField DataField="CSUBDIA" HeaderText="SD." />
                                    <asp:BoundField DataField="CCOMPRO" HeaderText="COMPROB." />
                                    <asp:BoundField DataField="CMEMO" HeaderText="NUM. CHEQUE" />
                                    <asp:BoundField DataField="CDATE" HeaderText="FECHA">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CCODMON" HeaderText="MO" />
                                    <asp:BoundField DataField="CTOTAL" HeaderText="TOTAL" />


                                    <asp:BoundField DataField="CGLOSA" HeaderText="GLOSA" />
                                    <asp:BoundField DataField="CSITUA" HeaderText="SIT." />
                                    <asp:BoundField DataField="CEXTOR" HeaderText="EXT." />
                                    <asp:BoundField DataField="CTIPCOM" HeaderText="TIPO" />


                                    <asp:TemplateField HeaderText="ELIMINAR">

                                        
                                    <ItemTemplate>
                                        <div class="btdetalles" style="text-align: center">
                                            <img alt="" src="../../../Images/desaprob.png" width="25" style="cursor: pointer" />
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
    <div id="dvdetalle" style="display:none">
        <table>
             <tr>
                   <td>Comprobante: </td>
                   <td><asp:TextBox ID="txtcomprobante" runat="server" ReadOnly="false" Width="422px"></asp:TextBox></td>
                   <td>Situacion:</td>
                   <td><asp:TextBox ID="txtsituacion" runat="server" ReadOnly="true"></asp:TextBox></td>
                  
        </tr>
            <tr>
                    <td>Fecha Cmprb: </td>
                   <td><asp:TextBox ID="txtfecha" runat="server" ReadOnly="true" Width="422px"></asp:TextBox> </td>
                   <td>Moneda: </td>
                   <td><asp:TextBox ID="txtmoneda" runat="server" ReadOnly="true"></asp:TextBox> </td>
                   
        </tr>
            <tr>
                    <td>Glosa:</td>
                   <td><asp:TextBox ID="txtglosa" runat="server" ReadOnly="true" Width="422px"></asp:TextBox></td>
                   <td>Conversión:</td>
                   <td><asp:TextBox ID="txtconversion" runat="server" ReadOnly="true"></asp:TextBox></td>
                   
        </tr>
            <tr>
                    <td>Forma Regist:</td>
                   <td><asp:TextBox ID="txtforma" runat="server" ReadOnly="true" Width="422px"></asp:TextBox></td>
                   <td>Tipo Convert:</td>
                   <td><asp:TextBox ID="txttipo" runat="server" ReadOnly="true"></asp:TextBox></td>
                 
        </tr>
            <tr>
                    <td>Tipo Compro:</td>
                   <td><asp:TextBox ID="txtcompro" runat="server" ReadOnly="true" Width="422px"></asp:TextBox></td>
                   <td>T.Cambio:</td>
                   <td><asp:TextBox ID="txtcambio" runat="server" ReadOnly="true"></asp:TextBox></td>
                  
        </tr>
        </table>
        <table>
                <tr>
                    <td>
                        <div style="overflow: auto; width: 850px; height: 300px">
                            <asp:GridView ID="gvdetalle" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" OnRowCreated="griddata_RowCreated" Font-Size="Smaller" Width="830px">
                                <Columns>
                                    <asp:BoundField DataField="DSECUE" HeaderText="SEC" />
                                    <asp:BoundField DataField="DCUENTA" HeaderText="CUENTA" />
                                    <asp:BoundField DataField="DVANEXO" HeaderText="ANEXO" />
                                    <asp:BoundField DataField="DCENCOS" HeaderText="C.COS">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DDH" HeaderText="F" />
                                    <asp:BoundField DataField="DIMPORT" HeaderText="IMPORTE" /> 
                                    <asp:BoundField DataField="DTIPDOC" HeaderText="TD" /> 
                                    <asp:BoundField DataField="DNUMDOC" HeaderText="DOCUM." />  
                                                                      
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
                    <input id="btneliminar" type="button" value="Eliminar" class="Elimina" />
                </td>
                

            </tr>
        </table> 

       

    </div>
   
</asp:Content>
