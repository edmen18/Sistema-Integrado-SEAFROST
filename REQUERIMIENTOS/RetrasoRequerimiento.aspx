<%@ Page Title="Logística" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="RetrasoRequerimiento.aspx.cs" Inherits="RetrasoRequerimiento" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link type="text/css" href="../CSS/base.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {

            $(".consulta").click(function () {
                    $.ajax({
                    type: "POST",
                    url: "RetrasoRequerimiento.aspx/RETRASOS",
                    data: '', 
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        if (data.d.length > 0) {
                            for (var i = 0; i < data.d.length; i++) {
                               
                                $("#MainContent_Label6").html(data.d[i].CINCO);
                                $("#MainContent_Label1").html((((data.d[i].CINCO) * 100) / data.d[i].TOTALREQ).toFixed(2));

                                $("#MainContent_Label7").html(data.d[i].CINCONUEVE);
                                $("#MainContent_Label2").html((((data.d[i].CINCONUEVE) * 100) / data.d[i].TOTALREQ).toFixed(2));

                                $("#MainContent_Label8").html(data.d[i].DIEZQUINCE);
                                $("#MainContent_Label3").html((((data.d[i].DIEZQUINCE) * 100) / data.d[i].TOTALREQ).toFixed(2));

                                $("#MainContent_Label10").html(data.d[i].QUINCEMAS);
                                $("#MainContent_Label4").html((((data.d[i].QUINCEMAS) * 100) / data.d[i].TOTALREQ).toFixed(2));

                                $("#MainContent_Label11").html(data.d[i].TOTALREQ);
                                $("#MainContent_Label5").html("100");

                            }

                        } else {

                            alert("No se encontraron registros");

                        }
                    },
                    error: function (response) {
                        if (response.length != 0)
                            alert(response);
                    }
                })
            });
            $(".porcinco").click(function () {
                filtarcgrid("5");
                $('.EstadoPedido').dialog('open');
            }),

             function porcinco1()
             {
                 alert("esta funcionando");
                 //filtarcgrid("5");
                 //$('.EstadoPedido').dialog('open');
             },


            $(".por59").click(function () {
                filtarcgrid("59");
                $('.EstadoPedido').dialog('open');
            }),
              $(".por1015").click(function () {
                  filtarcgrid("1015");
                  $('.EstadoPedido').dialog('open');
              }),
              $(".por16").click(function () {
                  filtarcgrid("16");
                  $('.EstadoPedido').dialog('open');
              }),
             $(".todos").click(function () {
                 filtarcgrid("todos");
                 $('.EstadoPedido').dialog('open');
             }),


             $('.EstadoPedido').dialog({
                 autoOpen: false,
                 modal: true,
                 resizable: false,
                 width: 1100,
                 heigth: 500,
                 title: 'Requerimiento',
                 open: function (event, ui) {

                 },
                 close: function (event, ui) {

                 }

             });
            $('.detalle').dialog({
                autoOpen: false,
                modal: true,
                resizable: false,
                width: 900,
                heigth: 300,
                title: 'Detalle Requerimiento',
                open: function (event, ui) {

                },
                close: function (event, ui) {

                }

            });

            function filtarcgrid(ind) {

                var urled ="";

                if (ind =="5"){
                    urled = "RetrasoRequerimiento.aspx/ListarReqIni";
                }
                if (ind == "59") {
                    urled = "RetrasoRequerimiento.aspx/RETRASOS59";
                }
                if (ind == "1015") {
                    urled = "RetrasoRequerimiento.aspx/RETRASOS1015";
                }
                if (ind == "16") {
                    urled = "RetrasoRequerimiento.aspx/RETRASOSMAS15";
                }
                if (ind == "todos") {
                    urled = "RetrasoRequerimiento.aspx/RETRASOSTODOS";
                }

            $.ajax({

                type: "POST",
                url: urled ,
                data: '',
                contentType: "application/json; charset=utf-8",
                async: false,
                dataType: "json",
                success: function (data) {
                    
                    if (data.d.length > 0) {
                        var row = $("[id*=gvRequerimientos] tr:last-child").clone(true);
                        $("[id*=gvRequerimientos] tr").not($("[id*=gvRequerimientos] tr:first-child")).remove();

                        for (var i = 0; i < data.d.length; i++) {

                            $("td", row).eq(0).html(data.d[i].RC_CNROREQ);
                            $("td", row).eq(1).html(moment(data.d[i].RC_DFECREQ.value).format('DD/MM/YYYY'));
                             $("td", row).eq(2).html(moment(data.d[i].RC_DFECA03.value).format('DD/MM/YYYY'));
                            $("td", row).eq(3).html(data.d[i].RC_CNUMORD);
                            $("td", row).eq(4).html(data.d[i].RC_CCODSOLI);
                            $("td", row).eq(5).html(data.d[i].RC_CCENCOS);
                            $("td", row).eq(6).html(data.d[i].RC_CUSEA01);
                            $("td", row).eq(7).html(data.d[i].RC_CUSEA02);
                            $("td", row).eq(8).html(data.d[i].RC_CUSEA03);

                                             
                            $("[id*=gvRequerimientos]").append(row);
                            row = $("[id*=gvRequerimientos] tr:last-child").clone(true);

                        }
                       } else {
                        var row = $("[id*=gvRequerimientos] tr:last-child").clone(true);
                        $("[id*=gvRequerimientos] tr").not($("[id*=gvRequerimientos] tr:first-child")).remove();

                        $("td", row).eq(0).html("");
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

                        $("[id*=gvRequerimientos]").append(row);
                        alert("no se encontro registro");
                    }


                },
                error: function (response) {
                    if (response.length != 0)
                        alert(response);
                }
            });

            }
            function filtarcantidademb(gidpped) {

                rr = gidpped;

                var REQ = {};
                REQ.RD_CNROREQ = rr;

                $.ajax({

                    type: "POST",
                    url: "RetrasoRequerimiento.aspx/ListarReqDetalle",
                    data: '{REQ: ' + JSON.stringify(REQ) + '}',
                    contentType: "application/json; charset=utf-8",
                    async: false,

                    dataType: "json",
                    success: function (data) {

                        if (data.d.length > 0) {
                            var row = $("[id*=gvdetalle] tr:last-child").clone(true);
                            $("[id*=gvdetalle] tr").not($("[id*=gvdetalle] tr:first-child")).remove();

                            for (var i = 0; i < data.d.length; i++) {

                                $("td", row).eq(0).html(data.d[i].RD_CITEM);
                                $("td", row).eq(1).html(data.d[i].RD_CCODIGO);
                                $("td", row).eq(2).html(data.d[i].RD_CDESCRI);
                                $("td", row).eq(3).html(data.d[i].RD_CUNID);
                                $("td", row).eq(4).html(data.d[i].RD_NQPEDI);
                                $("td", row).eq(5).html(data.d[i].RD_COBS);


                                $("[id*=gvdetalle]").append(row);
                                row = $("[id*=gvdetalle] tr:last-child").clone(true);

                            }
                        } else {
                            var row = $("[id*=gvdetalle] tr:last-child").clone(true);
                            $("[id*=gvdetalle] tr").not($("[id*=gvdetalle] tr:first-child")).remove();

                            $("td", row).eq(0).html("");
                            $("td", row).eq(1).html("");
                            $("td", row).eq(2).html("");
                            $("td", row).eq(3).html("");
                            $("td", row).eq(4).html("");
                            $("td", row).eq(5).html("");


                            $("[id*=gvdetalle]").append(row);
                            //alert("no se encontro registro");
                        }


                    },
                    error: function (response) {
                        if (response.length != 0)
                            alert(response);
                    }
                });

            }
            $(".ver").click(function () {

                trp = $(this).parent().parent();
                numero = $("td:eq(0)", trp).html();
                filtarcantidademb(numero);
                $('.detalle').dialog('open');

            });


        });

         </script>
    <style type="text/css">
        #txtproducto0 {
            width: 337px;
        }
        .auto-style1 {
            width: 131px;
        }
        .auto-style2 {
            height: 35px;
        }
        .auto-style3 {
            width: 131px;
            height: 35px;
        }
        #btb {
            width: 99px;
            height: 37px;
        }
        #btb0 {
            width: 81px;
            height: 29px;
        }
        #btexcel {
            width: 77px;
            height: 29px;
        }
        </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:ScriptManager ID="scriptManager" runat="server" EnablePageMethods="true" />
    <table width="100%" cellpadding="5" cellspacing="5" border="0">

        <tr>
            <td>
                <fieldset>
                    <legend >
                        <asp:Label ID="Label9" runat="server" Text="Reporte Días de Retraso en la Atención de Requerimientos" Font-Bold="True" Font-Size="12pt"></asp:Label></legend>

                    <table class="ContainerWrapper" border="0" cellpadding="2" cellspacing="0" style="width:1000px">

                        <tr>
                            <td>

                                <table>
                                    <tr>
                                        <td>
                                             <input type="button" id="btb" class="consulta btn" runat="server" value="Buscar" />
                                           </td>
                                        <td>
                                            <asp:Button ID="Button1" runat="server" Height="34px" OnClick="Button1_Click" Text="Excel" Width="70px" CssClass="btn" />

                                        </td>

                                    </tr>
                                </table>

                            </td>
                        </tr>

                    </table>
                   
                    <table>

                        <tr >
                             <td style="border-color: # #000000; border-width:1px; border-style: solid;background-color:Highlight" >
                                <asp:Label ID="Label14" runat="server" Text="Días Transcurridos" Font-Size="Small" Font-Bold="True" ></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                             <td>
                            <td style="border-color: # #000000; border-width:1px; border-style: solid; background-color:Highlight" class="auto-style1" >
                                <div style="text-align: center">
                                <asp:Label ID="Label15" runat="server" Text="Menor a 5 Días " Font-Size="Small" Font-Bold="True"></asp:Label>
                             </div>
                                </td>
                            <td style="border-color: # #000000; border-width:1px; border-style: solid ; background-color:Highlight" >
                                  <div style="text-align: center">
                                 <asp:Label ID="Label16" runat="server" Text="5 A 9 Días" Font-Size="Small" Font-Bold="True"></asp:Label>
                                     </div> </td>
                             <td style="border-color: # #000000; border-width:1px; border-style: solid; background-color:Highlight" >
                                  <div style="text-align: center">
                                 <asp:Label ID="Label17" runat="server" Text="10 A 15 Días" Font-Size="Small" Font-Bold="True"></asp:Label>
                                     </div></td>
                             <td style="border-color: # #000000; border-width:1px; border-style: solid ; background-color:Highlight" >
                                <div style="text-align: center">
                                 <asp:Label ID="Label18" runat="server" Text="Mayor De 15 Días" Font-Size="Small" Font-Bold="True"></asp:Label>
                                    </div> </td>
                             <td style="border-color: # #000000; border-width:1px; border-style: solid ; background-color:Highlight" >
                                 <div style="text-align: center">
                                 <asp:Label ID="Label19" runat="server" Text="Total" Font-Size="Small" Font-Bold="True"></asp:Label>
                                     </div>
                                     </td>
                            </tr>
                            <tr>
                             <td style="border-color: # #000000; border-width:1px; border-style: solid; background-color:Highlight">
                                <asp:Label ID="Label12" runat="server" Text="Número de Requerimientos" Font-Size="Small" Font-Bold="True"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                             <td>
                            <td style="border-color: # #000000; border-width:1px; border-style: solid; background-color:white" class="auto-style1" >
                                
                                <div class="porcinco" style="text-align: center">
                                 <asp:Label ID="Label6" runat="server" Font-Size="Small" style="cursor: pointer" Font-Italic="False" Font-Overline="False" Font-Underline="True" ForeColor="Blue"></asp:Label >
                                 </div>

                             <td style="border-color:#000000; border-width:1px; border-style: solid; background-color:white" >
                                 <div class="por59" style="text-align: center">
                                <asp:Label ID="Label7" runat="server" Font-Size="Small" style="cursor: pointer" Font-Underline="True" ForeColor="Blue"></asp:Label> 
                                 </div>
                                </td>
                                                             
                                
                                 <td style="border-color: # #000000; border-width:1px; border-style: solid; background-color:white" >
                                 
                                    <div class="por1015" style="text-align: center">
                               <asp:Label ID="Label8" runat="server" Font-Size="Small" style="cursor: pointer" Font-Underline="True" ForeColor="Blue"></asp:Label>
                                 </div>
                                </td>

                             <td style="border-color: # #000000; border-width:1px; border-style: solid ; background-color:white" >
                                                               
                             <div class="por16" style="text-align: center">
                              <asp:Label ID="Label10" runat="server" Font-Size="Small" style="cursor: pointer" Font-Underline="True" ForeColor="Blue"></asp:Label>
                                 </div>
                                </td>
                                
                                
                                <td style="border-color: # #000000; border-width:1px; border-style: solid ; background-color:khaki" >
                               
                                 
                                 <div class="todos" style="text-align: center">
                             <asp:Label ID="Label11" runat="server" Font-Size="Small" style="cursor: pointer" Font-Underline="True" ForeColor="Blue"></asp:Label>
                                 </div>
                                </td>


                            </tr>
                         <tr>
                            <td style="border-color: # #000000; border-width:1px; border-style: solid; background-color:Highlight" class="auto-style2" >
                                <asp:Label ID="Label13" runat="server" Text="Porcentaje %" Font-Size="Small" Font-Bold="True"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                             <td class="auto-style2">
                            <td style="border-color: # #000000; border-width:1px; border-style: solid ; background-color:white" class="auto-style3" >
                                <div style="text-align: center">
                                 <asp:Label ID="Label1" runat="server" Font-Size="Small"></asp:Label>
                                 </div>
                                </td>


                             <td style="border-color: # #000000; border-width:1px; border-style: solid; background-color:white" class="auto-style2" >
                               <div style="text-align: center">
                                 <asp:Label ID="Label2" runat="server" Font-Size="Small"></asp:Label>
                                 </div>
                                </td>
                                

                             
                             <td style="border-color: # #000000; border-width:1px; border-style: solid; background-color:white" class="auto-style2" >
                                 
                                 <div style="text-align: center">
                                <asp:Label ID="Label3" runat="server" Font-Size="Small"></asp:Label>
                                 </div>
                                </td>
                            
                              <td style="border-color: # #000000; border-width:1px; border-style: solid; background-color:white" class="auto-style2" >
                                  <div style="text-align: center">
                               <asp:Label ID="Label4" runat="server" Font-Size="Small"></asp:Label>
                                 </div>
                                </td>
                                  
                                  
                             <td style="border-color: # #000000; border-width:1px; border-style: solid; background-color:khaki" class="auto-style2" >
                                 <div style="text-align: center">
                               <asp:Label ID="Label5" runat="server" Font-Size="Small"></asp:Label>
                                 </div>
                                </td>
                                 
                           </tr>
                          </table>
                </fieldset>
            </td>
        </tr>
    </table>
    <%-- style="display: none" --%>
     <div class="EstadoPedido" style="display: none" >
        <table>
            
              <tr>
                <td class="auto-style1">
                     <div style="overflow: auto; width: 1040px; height: 400px">
                    <asp:GridView ID="gvRequerimientos" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" Height="132px">
                                    <Columns>
                                        <asp:BoundField DataField="RC_CNROREQ" HeaderText="REQUISICION" />
                                        <asp:BoundField DataField="RC_DFECREQ" HeaderText="FECHA" />
                                        <asp:BoundField DataField="RC_DFECA03" HeaderText="FECHA.APROB" />
                                        <asp:BoundField DataField="RC_CNUMORD" HeaderText="NRO.ORDEN" />
                                        <asp:BoundField DataField="USUARIO" HeaderText="USUARIO" />
                                        <asp:BoundField DataField="RC_CCENCOS" HeaderText="CENTRO COSTO" />
                                        <asp:BoundField DataField="RC_CUSEA01" HeaderText="APRUEBA1" />
                                        <asp:BoundField DataField="RC_CUSEA01" HeaderText="APRUEBA2" />
                                        <asp:BoundField DataField="RC_CUSEA01" HeaderText="APRUEBA3" />
                                        <asp:TemplateField HeaderText="VISUALIZAR">
                                            <ItemTemplate>
                                                <div class="ver">
                                                    <img alt="" src="../Images/Message_Information.png" width="25" style="cursor: pointer" />
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
    <div class="detalle" style="display: none" >
        <table>
            
              <tr>
                <td class="auto-style1">
                     <div style="overflow: auto; width: 880px; height: 120px">
                    <asp:GridView ID="gvdetalle" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" Width="859px" Font-Size="8">
                        <Columns>
                            <asp:BoundField DataField="RD_CITEM" HeaderText="ITEM" HeaderStyle-HorizontalAlign="Left" />
                            <asp:BoundField DataField="RD_CCODIGO" HeaderText="CODIGO" HeaderStyle-HorizontalAlign="Left" />
                            <asp:BoundField DataField="RD_CDESCRI" HeaderText="DESCRI" HeaderStyle-HorizontalAlign="Left" />
                            <asp:BoundField DataField="RD_CUNID" HeaderText="UNID" HeaderStyle-HorizontalAlign="Left" />
                            <asp:BoundField DataField="RD_NQPEDI" HeaderText="CANT" HeaderStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                           
                            <asp:BoundField DataField="RD_COBS" HeaderText="OBS" HeaderStyle-HorizontalAlign="Left" />


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

    

</asp:Content>

