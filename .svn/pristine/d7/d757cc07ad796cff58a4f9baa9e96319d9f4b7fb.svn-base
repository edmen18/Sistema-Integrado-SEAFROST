
<%@ Page Title="Anulación de Cheques" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="FinEliminacion.aspx.cs" Inherits="FINANZAS_TESORERIA_CHEQUES_FinEliminacion" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link type="text/css" href="../../../CSS/base.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {
            UHTML.id = 'MainContent';
            $("#MainContent_txtfechadiferido").datepicker();
             $(".seleciona").change(function () {
                acum = 0;
                var imput = document.getElementsByName('opt');
                var ddlcartera = document.getElementById("<%=ddlcartera.ClientID %>");
            if (Operacion.mask('txtbancor').val().trim()!=""){
                GENERARCHEQUE();
            }
            else {
              //  alert("Debe ingresar los datos del banco");
            }
               
        });
             $("#MainContent_txtbancor").autocomplete(
                 {
                     source: function (request, response) {
                         $.ajax({
                             url: "FinEliminacion.aspx/ListarBancosProg",
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
                         $('#MainContent_lblbancor').val(str);
                         $('#MainContent_txtmoneda').val(ui.item.v);
                         $('#MainContent_txtcuentabanco').val(ui.item.b);                     
                         GENERARCHEQUE();
          }
                 });


             $("#MainContent_lblbancor").autocomplete(
      {
          source: function (request, response) {
              $.ajax({
                  url: "FinEliminacion.aspx/ListarBancosProg",
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
              var str = ui.item.id;
              var cadena = str
              posicionEspacio = cadena.indexOf("@"), //Obtengo la posición del espacio en la cadena
              primerApellido = cadena.substring(0, posicionEspacio) //Obtengo la porción deseada de la cadena
              enMinuscula = primerApellido.toLowerCase(); //Convierto el apellido a minúscula
              primerApellido = cadena.substring(posicionEspacio + 1, str.length)
              $('#MainContent_txtbancor').val(str);
              $('#MainContent_txtmoneda').val(ui.item.v);
              GENERARCHEQUE();
          }
      });
             function GENERARCHEQUE() {
                 var banco = Operacion.mask('txtbancor').val();

                 $.ajax({

                     type: "POST",
                     url: "FinEliminacion.aspx/ListarDatosBancoID",
                     data: "{ 'ban': '" + banco + "' }",
                     contentType: "application/json; charset=utf-8",
                     dataType: "json",
                     async: false,
                     success: function (data) {
                         if (Operacion.mask('ddlcartera').val() == "1") {
                             Operacion.mask('txtcheque').val(Operacion.cadenaMascara(Number(data.d.CT_NCHEQ01) + 1, 8));
                         }
                         if (Operacion.mask('ddlcartera').val() == "2") {
                             Operacion.mask('txtcheque').val(Operacion.cadenaMascara(Number(data.d.CT_NCHEQ02) + 1, 8));
                         }
                         if (Operacion.mask('ddlcartera').val() == "3") {
                             Operacion.mask('txtcheque').val(Operacion.cadenaMascara(Number(data.d.CT_NCHEQ03) + 1, 8));
                         }
                        
                     },
                     error: function (data) {
                         if (data.length != 0)
                             alert(data);
                     }
                 });
             }
             $(".ma").click(function () {

                if ((document.getElementById("<%=rbautomatico.ClientID%>").checked == true)) {
                    $("#MainContent_txtcheque").attr("disabled", true);
                    if (Operacion.mask('txtbancor').val()!="") {
                        GENERARCHEQUE();
                    } 
                }
                if ((document.getElementById("<%=rbmanual.ClientID%>").checked == true)) {
                    $("#MainContent_txtcheque").attr("disabled", false);
                }

             });

            $(".guardar").click(function () {


                var codigo = $('#MainContent_txtcheque').val();
                var comprobante = generar().ultimodato;

                if (comprobante != "" && comprobante != null) {
                    if (Number(ConsultaCheque().existe)>0) {
                        alert("Este cheque ya se encuentra registrado");
                    }
                    else {
                        InsertaCheque(comprobante);
                    }
               }
                else {
                    alert("No se ha generado ningun comprobante");
                }


            });

            function generar() {

                var f=  new Date();
              
                alert(f.getMonth()+1);

                var ultimodato = "";
                var DATA = {};
                DATA.CTSUBDIA = Operacion.mask('ddlsubdiario').val();//Operacion.mask('ddlSDIA').val();
                DATA.CTANO = f.getFullYear().toString().substring(2,4);
                DATA.CTMES = (Number(f.getMonth()+1) < 10 ? "0"+(f.getMonth()+1): f.getMonth()+1);
                console.log(DATA);
                $.ajax({
                    type: "POST",
                    url: "FinEliminacion.aspx/correlativoCP",
                    data: '{ DATA: ' + JSON.stringify(DATA) + '}',
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        ultimodato = data.d;
                    },
                    error: function (response) {
                        console.log(response);
                    }
                });


                return { ultimodato };
            }
            
            function InsertaCheque(comprobante) {
                //firma();
               
                var f = moment($("#MainContent_txtfechadiferido").val(), "DD/MM/YYYY");
                f = f == null ? null : new Date(f);

                var fd = moment($("#MainContent_txtfechadiferido").val(), "DD/MM/YYYY");
                fd = fd == null ? null : new Date(fd);

                var fecha = new Date();
                var annio = f.getFullYear().toString();
                var annioa = fecha.getFullYear().toString();
                var anniod = fd.getFullYear().toString();

                var DETACHEQUE = {};
                DETACHEQUE.CH_CNUMCTA = Operacion.mask('txtbancor').val();
                DETACHEQUE.CH_CNUMCHE = Operacion.mask('txtcheque').val();
                DETACHEQUE.CH_CFECCHE = annio.substr(2, 2) + (Number(f.getMonth() + 1) < 10 ? "0" + (f.getMonth() + 1) : (f.getMonth() + 1)) + f.getDate();
                DETACHEQUE.CH_CNOMCHE = "ANULADO";
                DETACHEQUE.CH_CFECCOM = annio.substr(2, 2) + (Number(f.getMonth() + 1) < 10 ? "0" + (f.getMonth() + 1) : (f.getMonth() + 1)) + f.getDate();
                DETACHEQUE.CH_CSUBDIA = Operacion.mask('ddlsubdiario').val();
                DETACHEQUE.CH_CNUMCOM = comprobante;
                DETACHEQUE.CH_NIMPOCH = 0;

                DETACHEQUE.CH_CCODMON = Operacion.mask('txtmoneda').val();
                DETACHEQUE.CH_CVANEXO = "";  
                DETACHEQUE.CH_CCODIGO ="";
                DETACHEQUE.CH_CESTADO = "A";
                DETACHEQUE.CH_CFECEST = annioa.substr(2, 2) + (Number(fecha.getMonth() + 1) < 10 ? "0" + (fecha.getMonth() + 1) : (fecha.getMonth() + 1)) + fecha.getDate();

                DETACHEQUE.CH_CUSUARI =Operacion.mask('lblusuario').text(); 
                DETACHEQUE.CH_DFECHA = fecha;
                DETACHEQUE.CH_CHORA =  fecha.getHours() + ":" + ((fecha.getMinutes()).toString().length < 2 ? "0" + fecha.getMinutes() : fecha.getMinutes());
                DETACHEQUE.CH_CCTACON = Operacion.mask('txtcuentabanco').val();
                DETACHEQUE.CH_CSITUAC = "";
                DETACHEQUE.CH_DOCREFT = "";
                DETACHEQUE.CH_DOCREFN = "";
                DETACHEQUE.CH_CCOGAST = "";
                DETACHEQUE.CH_CCONCEP = "";
                DETACHEQUE.CH_CFECDIF = "";
                DETACHEQUE.CH_NTIPCAM = 0;
                DETACHEQUE.CH_DFECCHE = f;
                DETACHEQUE.CH_DFECCOM = f;
                DETACHEQUE.CH_DFECEST = fecha;
                DETACHEQUE.CH_DFECDIF = null;
                DETACHEQUE.CH_CNOMCH2 = "";
                DETACHEQUE.CH_CNOMFR1 = "";
                DETACHEQUE.CH_CNOMFR2 = "";
                DETACHEQUE.CH_CFLGNEG = "";// no negociable

                $.ajax({
                    type: "POST",
                    url: "FinEliminacion.aspx/InsertaCheques",
                    data: '{DETA: ' + JSON.stringify(DETACHEQUE) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        //alert("Inserta Cheque");
                        InsertarCabComprobante(comprobante)
                    },
                    error: function (response) {
                        if (response.length != 0)
                            alert(response);
                        console.log(response);

                    }
                });
            }
            function ActComprobante(numero) {
                var DETA = {};
                var fecha = new Date();
                DETA.CTSUBDIA = Operacion.mask('ddlsubdiario').val();
                DETA.CTANO = (fecha.getFullYear()).toString().substr(2, 2);
                DETA.CTMES = (Number(fecha.getMonth() + 1) < 10 ? "0" + (fecha.getMonth() + 1).toString() : (fecha.getMonth() + 1).toString());
                DETA.CTNUMER = numero.toString();
                var cheq = 0;
                $.ajax({
                    type: "POST",
                    url: "FinEliminacion.aspx/Numeracion",
                    data: '{DETA: ' + JSON.stringify(DETA) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        cheq = Operacion.mask('txtcheque').val();
                        GENERARCHEQUE();
                        if ((Number(Operacion.mask('txtcheque').val())-1)<cheq) {
                            ActualizarChequera(cheq);
                            Operacion.mask('txtcheque').val("");
                        }
                        else {
                            alert("El Cheque Nº " + cheq + " ha sido eliminado satisfactoriamnete");
                            location.reload();
                        }
                       
                    },
                    error: function (response) {
                        if (response.length != 0)
                            console.log(response);
                    }
                });
            }
            // si existe en la tabla
            function ConsultaCheque() {
                var COM = {};
                COM.CH_CNUMCHE = Operacion.mask('txtcheque').val();
                COM.CH_CSUBDIA = Operacion.mask('ddlsubdiario').val();
                COM.CH_CNUMCTA = Operacion.mask('txtbancor').val();
                var existe = 0;

                $.ajax({

                    type: "POST",
                    url: "FinEliminacion.aspx/ConsultaunDetalle",
                    data: '{COM: ' + JSON.stringify(COM) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {

                        if (data.d.length > 0) {
                            existe = data.d.length;
                        }
                    },
                    error: function (response) {
                        if (response.length != 0)
                            alert(response);
                    }
                });
                return{existe}
            }


            function ActualizarChequera(cheq) {
                var DETA = {};
                DETA.CT_CTIPCTA = Operacion.mask('ddlcartera').val();
                DETA.CT_CNUMCTA = Operacion.mask('txtbancor').val();
                DETA.CT_NCHEQ01 = cheq;
                $.ajax({
                    type: "POST",
                    url: "FinEliminacion.aspx/ActualizaCheque",
                    data: '{DETA: ' + JSON.stringify(DETA) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        alert("El Cheque Nº " + Operacion.mask('txtcheque').val() + " ha sido eliminado");
                        location.reload();
                    },
                    error: function (response) {
                        if (response.length != 0)
                            console.log(response);
                    }
                });
            }
       function InsertarCabComprobante(comprobante) {
                var f = moment($("#MainContent_txtfechadiferido").val(), "DD/MM/YYYY");
                f = f == null ? null : new Date(f);

                var fecha = new Date();
                var annio = fecha.getFullYear().toString();
                var DETACAB = {};
                            DETACAB.CSUBDIA = Operacion.mask('ddlsubdiario').val();
                            DETACAB.CCOMPRO = comprobante;
                            DETACAB.CFECCOM = annio.substr(2, 2) + (Number(f.getMonth() + 1) < 10 ? "0" + (f.getMonth() + 1) : (f.getMonth() + 1)) + f.getDate(); 
                            DETACAB.CCODMON = Operacion.mask('txtmoneda').val();
                            DETACAB.CSITUA = "F";
                            DETACAB.CTIPCAM = 0;
                            DETACAB.CGLOSA = "CH.ANUL.CTA "+Operacion.mask('txtbancor').val() +"#"+Operacion.mask('txtcheque').val();
                            DETACAB.CTOTAL = 0;                   
                            DETACAB.CTIPO = "M";
                            DETACAB.CFLAG = "N";  
                            DETACAB.CDATE = fecha;
                            DETACAB.CHORA = fecha.getHours() + ":" + ((fecha.getMinutes()).toString().length<2? "0"+ fecha.getMinutes(): fecha.getMinutes());
                            DETACAB.CUSER = $("#MainContent_lblusuario").html();
                            DETACAB.CFECCAM = "      ";
                            DETACAB.CORIG = "CP";
                            DETACAB.CFORM = "M";
                            DETACAB.CTIPCOM = "99";
                            DETACAB.CEXTOR = " ";
                            DETACAB.CFECCOM2 = f;
                            DETACAB.CFECCAM2 = null;
                            DETACAB.CMEMO = " ";
                            DETACAB.CSERCER = "    ";
                            DETACAB.CNUMCER = "          ";
                $.ajax({
                    type: "POST",
                    url: "FinEliminacion.aspx/InsertCabComprobante",
                    data: '{DETA: ' + JSON.stringify(DETACAB) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response){
                        insertadetcomprobante(comprobante);
                        
                      },
                    error: function (response) {
                        if (response.length != 0)
                            alert(response);
                        console.log(response);

                    }
                });
       }

            
            function insertadetcomprobante(COMPROBANTE)
            {
                var GD = {};
                var pago = {};
                var f = new Date();
                var dia = "";
                var mes = "";
                var annio = "";
                var DETADC = {};
                var cont = 1;
               var annioven = "";
                var aannio = "";
                var i = 0;
                annio = Number(f.getFullYear()).toString();

                var ftext = moment($("#MainContent_txtfechadiferido").val(), "DD/MM/YYYY");
                ftext = ftext == null ? null : new Date(ftext);

                DETADC.DSUBDIA = Operacion.mask('ddlsubdiario').val();
                DETADC.DCOMPRO = COMPROBANTE;
                if (Number((f.getMonth() + 1)) < 10) {
                    mes = "0" + "" + (f.getMonth() + 1);
                }
                else {
                    mes = (f.getMonth() + 1);
                }
                if (Number(f.getDate()) < 10) {
                    dia = "0" + "" + f.getDate();
                }
                else {
                    dia = f.getDate();
                }
                DETADC.DSECUE = Operacion.cadenaMascara(cont, 4);
                DETADC.DFECCOM = ftext.getFullYear().toString().substr(2, 2) + (Number(ftext.getMonth() + 1) < 10 ? "0" + (ftext.getMonth() + 1) : (ftext.getMonth() + 1)) + ftext.getDate();
                DETADC.DCUENTA = Operacion.mask('txtcuentabanco').val(); 
                DETADC.DCODANE = Operacion.mask('txtbancor').val();
                DETADC.DCENCOS = " ";
                DETADC.DCODMON = Operacion.mask('txtmoneda').val();
                DETADC.DDH = "H";
                DETADC.DIMPORT = 0;
                DETADC.DTIPDOC = "CH";
                DETADC.DNUMDOC = Operacion.mask('txtcheque').val();
                DETADC.DFECDOC = ftext.getFullYear().toString().substr(2, 2) + (Number(ftext.getMonth() + 1) < 10 ? "0" + (ftext.getMonth() + 1) : (ftext.getMonth() + 1)) + ftext.getDate();
                DETADC.DFECVEN = ""
                DETADC.DAREA ="";
                DETADC.DFLAG = "N";
                DETADC.DDATE = f;
                DETADC.DXGLOSA = "CHEQUE ANULADO";
                DETADC.DMNIMPOR = 0;
                DETADC.DUSIMPOR = 0;
               
                DETADC.DCODARC = "";
                DETADC.DFECCOM2 = (moment($("#MainContent_txtfechadiferido").val(), "DD/MM/YYYY"));
                DETADC.DFECDO2 = (moment($("#MainContent_txtfechadiferido").val(), "DD/MM/YYYY"));
                DETADC.DFECVEN2 = null;
                DETADC.DCODANE2 = "";
                DETADC.DVANEXO = "0";
                DETADC.DVANEXO2 = "";
                DETADC.DTIPCAM = 0;
                DETADC.DCANTID = 0;
                DETADC.DCTAORI = "";
                DETADC.DCCODMON = "";
                DETADC.DCIMPORT = 0;
                DETADC.DCNUMDOC = "";
                DETADC.DCESTADO = "";
                DETADC.DCCONFEC2 = null;
                DETADC.DCCONNRO = " ";
                DETADC.DCCONPRO = null;
                DETADC.DCNUMEST = "";
                DETADC.DCITEM = "";
                DETADC.DCIMPORTB = 0;
                DETADC.DCANO = "";
                DETADC.DTIPDOR = "";
                DETADC.DNUMDOR = "";
                DETADC.DFECDO2 = null;
                DETADC.DTIPTAS = "";
                DETADC.DIMPTAS = 0;
                DETADC.DIMPBMN = 0;
                DETADC.DIMPBUS = 0;
                DETADC.DMONCOM = "";
                DETADC.DCOLCOM = "";
                DETADC.DBASCOM = 0;
                DETADC.DINACOM = 0;
                DETADC.DIGVCOM = 0;
                DETADC.DTPCONV = "";
                DETADC.DFLGCOM = "";
                DETADC.DANECOM = "";
                DETADC.DTIPACO = "";
                DETADC.DMEDPAG = "";
                DETADC.DTIPDO2 = "";
                DETADC.DNUMDO2 = "";
                DETADC.DRETE = "";
                DETADC.DPORRE = 0;

                $.ajax({
                    type: "POST",
                    url: "FinEliminacion.aspx/InsertDetComprobante",
                    data: '{DETA: ' + JSON.stringify(DETADC) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        ActComprobante(Number((COMPROBANTE).substr(2, 4)));
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
        .auto-style1 {
            height: 19px;
        }
        .auto-style3 {
            width: 56px;
        }
        #btnadicionales {
            width: 115px;
        }
        #btnfinalizar {
            width: 72px;
        }
        .seleciona {}
    </style>
    </asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="contenedor">
      <div id="Creacion" title="Creación">
         <table>
             <tr>
              <td>
              
                  <table>
                   <tr>
                  <td>Chequera</td> <td> <asp:DropDownList ID="ddlcartera" runat="server" Height="21px" Width="176px" CssClass="seleciona">
                  <asp:ListItem>1</asp:ListItem>
                  <asp:ListItem>2</asp:ListItem>
                  <asp:ListItem>3</asp:ListItem>
                  </asp:DropDownList></td>
              </tr>
              <tr>
                  <td>Nro. de Cuenta Bancaria&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                   <td>
                       <asp:TextBox ID="txtbancor" runat="server" Width="175px"></asp:TextBox>
                       </td>
                  <td>
                        <asp:TextBox ID="lblbancor" runat="server" Width="434px"></asp:TextBox>
                    </td>
                 
              </tr>
              <tr>
                  <td>
                      Moneda
                  </td>
                  <td>
                       <asp:TextBox ID="txtmoneda" runat="server" Width="175px" ReadOnly="true"></asp:TextBox>
                       <asp:Label ID="lblusuario" runat="server" BorderStyle="None" style="display:none"></asp:Label>
                  </td>
                  <td>
                      <asp:TextBox ID="txtcuentabanco" runat="server" ReadOnly="true"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                 <td class="auto-style1">Subdiario</td>
                    <td class="auto-style1">
                        <asp:DropDownList ID="ddlsubdiario" runat="server" Height="19px" Width="220px"></asp:DropDownList>
                    </td>
               </tr>
               <tr>
                   <td>Fecha Giro</td>
                  <td><asp:TextBox ID="txtfechadiferido" runat="server" Width="136px"></asp:TextBox> </td>
                                     
                   </tr>
                      <tr>
                          <td>

                          </td>
                           <td> <input id="rbmanual" name="opcion" type="radio" value="1" runat="server" class="ma" />
                        Manual
                         <input id="rbautomatico" name="opcion" type="radio" value="2" runat="server" class="ma" />
                        Automático.
                                          </td>
                      </tr>
                      <tr>
                          <td>Nro. Cheque</td>
                  <td><asp:TextBox ID="txtcheque" runat="server" Width="136px"></asp:TextBox></td>
                          <td>
                               <input id="btnfinalizar" type="button" value="Anular" class="guardar" />                          </td>
                      </tr>
               </table>
                          
  </table>
          </div>
        </div>



</asp:Content>
