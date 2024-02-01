var Operacion = {
    inputEstado: function (val, est, id) {
        /*Permite asignar el atributo de habilitado o desahilitado*/
        if (id == true) {
            if (typeof UHTML.id == 'undefined') {
                alert('No ha definido el valor de UHTML.id');
            }
        }
        var selector = (id == false ? "#" + val : "#" + UHTML.id + "_" + val);
        var mascara = $(selector);
        if (est == 1) {
            mascara.attr('disabled', true);
            //mascara.removeAttr("placeholder");
        } else {
            mascara.removeAttr("disabled");
            //mascara.attr("placeholder", "Requerido");
        }
        //return (est == 1 ? mascara.attr('disabled', true): mascara.removeAttr("disabled"));
    },
    inputVisible: function (val, est) {

        var selector = (typeof val == 'string' ? $("#" + UHTML.id + "_" + val) : val);
        /*Permite mostrar/ocultar un elmento del DOM*/
        return (est == 1 ? selector.hide() : selector.show());
    },
    inputRead: function (val, est) {
        var selector = Operacion.mask(val);
        return (est == 1 ? selector.attr('readonly', true) : selector.removeAttr('readonly'));
    },
    iVALC: function (input) {
        /*Permite validar campos del form*/
        var sw = true;
        $.each(input, function (k, v) {
            sa = true;
            sa = sa && ((Operacion.mask(v).is('[disabled]') ? (v.indexOf('-') != -1 ? false : true) : false));//SI ESTA DESAHABILITADO
            if (sa == false) {
                var cadenae = (v.indexOf('-') != -1 ? v.replace("-", "") : false);//console.log(cadenae);
                if (cadenae == false) {
                    var verifica = (Operacion.mask(v).val() != '' && Operacion.mask(v).val() != null);
                    var excepcion = true;
                    sw = sw && (verifica && excepcion);// || Operacion.mask(v).text() != ''));//COMPRUEBA VALOR
                } else {
                    var verifica = true;//(Operacion.mask(v).val() != '' && Operacion.mask(v).val() != null);
                    var excepcion = (Operacion.mask(cadenae).val() != '' ? true : false);//VALIDA INPUT DESAHABILITADOS
                    sw = sw && (verifica && excepcion);
                }

                if (sw) {
                    sw = true;//NUEVO 02.08.16
                    //Operacion.mask(v).removeAttr('placeholder');
                    //(Operacion.mask(v).is('input') ? Operacion.mask(v).css('border', '#aaaaaa solid 1px') : "");
                    (cadenae != false ? Operacion.mask(cadenae).removeAttr('placeholder') : Operacion.mask(v).removeAttr('placeholder'));
                    (cadenae != false ? (Operacion.mask(cadenae).is('input') ? Operacion.mask(cadenae).css('border', '#aaaaaa solid 1px') : "") : (Operacion.mask(v).is('input') ? Operacion.mask(v).css('border', '#aaaaaa solid 1px') : ""));
                } else {
                    sw = false;
                    Operacion.mask(v).attr('placeholder', 'Campo requerido');
                    (Operacion.mask(v).is('input') ? Operacion.mask(v).css('border', 'red solid 1px') : "");
                    (cadenae != false ? (Operacion.mask(cadenae).is('input') ? Operacion.mask(cadenae).css('border', 'red solid 1px') : "") : "");
                }
                /*Operacion.mask(v).attr('placeholder', 'Campo requerido');
                Operacion.mask(v).addClass('your-class');
                (Operacion.mask(v).is("select") ? Operacion.mask(v).css('color', 'red') : "");
                (Operacion.mask(v).is("input") ? Operacion.mask(v).css('color', 'red') : "");*/
                //console.log("k=>" + k + " v=>" + v + " e=>" + sw + "valor=>" + Operacion.mask(v).val() + "VALOR" + (Operacion.mask(v).val() != '' && Operacion.mask(v).val() != null));
            } else {
                $(this).removeClass('placeholder');
            }
        });
        return sw;
    },
    cadenaMascara: function (str, max) {
        /*Permite completar una cadena con 0*/
        if (str != undefined) {
            str = str.toString();
            return str.length < max ? Operacion.cadenaMascara("0" + str, max) : str;
        }
    },
    mask: function (cad) {
        var selector;
        /*Permite dar una mascara al texto button - input: $(#xxx_yy)*/
        selector = "#" + UHTML.id + "_" + cad;
        return $(selector);
    },
    iValida: function (val, op) {
        /*Permite validar campo no sea numerico, con decimal o coma decimal*/
        var aux = (typeof val == 'string' ? $("#" + UHTML.id + "_" + val) : val);
        switch (op) {
            case 1:
                aux.numeric();
                break;
            case 2:
                aux.numeric('.');
                break;
            case 3:
                aux.numeric(',');
                break;
        }
    },
    mround: function (value, decimals) {
        //REDONDEO
        return Number(Math.round(value + 'e' + decimals) + 'e-' + decimals);
    },
    oAjax: function (url, obj, id) {
        var ID = (id != null ? id : "DATA");
        //console.log(ID);
        var miajax = $.ajax({
            url: url,
            data: '{' + ID + ':' + JSON.stringify(obj) + '}',//(id == "" ? JSON.stringify(obj) : '{' + ID + ':' + JSON.stringify(obj) + '}'),
            contentType: "application/json;charset=utf-8",
            type: "POST",
            async: false,
            dataType: "json",
        });
        return JSON.parse(miajax.response);
    },
    oDialog: function (id, bl) {
        /*Permite asignar a un div configuración dialog*/
        return $("#" + id).dialog({
            autoOpen: bl,
            resizable: true,
            width: 'auto',
            modal: true,
            closeOnEscape: false
        });
    },
    oACD: function (val) {
        var selector = Operacion.mask(val);
        selector.autocomplete("destroy");
        selector.removeClass('ui-autocomplete-loading');
    },
    limpiarIS: function (obj) {
        //$('#MainContent_txtidProducto').val('');
    },
    Checktodos: function (Checkbox, vargrid, ncolumna) {
        var GridVwHeaderChckbox = document.getElementById(vargrid);
        for (y = 0; y < GridVwHeaderChckbox.rows.length; y++) {
            if (GridVwHeaderChckbox.rows[y].cells[ncolumna].getElementsByTagName("input")[0].disabled == false) {
                GridVwHeaderChckbox.rows[y].cells[ncolumna].getElementsByTagName("input")[0].checked = Checkbox.checked;//
            }
        }
    },
    MEKPAT: function (event, info) {
        var mitabindex = [];
        if (event.keyCode == 13) {
            cb = parseInt($(info).attr('tabindex'));
            //
            $("#ctl00 #contenedor input").each(function () {
                var $input = $(this);
                if (!$input.is('[disabled]') && !$input.is(':hidden') && $input.attr('tabindex') != 0) {
                    mitabindex.push(Number($input.attr('tabindex')));
                }
            });
            //
            $("#ctl00 #contenedor select").each(function () {
                var $input = $(this);
                if (!$input.is('[disabled]') && !$input.is(':hidden') && $input.attr('tabindex') != 0) {
                    mitabindex.push(Number($input.attr('tabindex')));
                }
            });

            $(".ui-dialog-content input").each(function () {
                var $input = $(this);
                if (!$input.is('[disabled]') && !$input.is(':hidden') && $input.attr('tabindex') != 0) {
                    mitabindex.push(Number($input.attr('tabindex')));
                }
            });
            var nuevoti = $.unique(mitabindex);
            nuevo = nuevoti.sort(function (a, b) { return a - b });
            miposicion = jQuery.inArray(cb, nuevo);
            mitab = nuevo[miposicion + 1];
            $(':input[TabIndex=\'' + (mitab) + '\']').focus();
        }
    },
    TC: function () {
        var DATC = {};
        DATC.XFECCAM2 = moment().format('DD/MM/YYYY');
        //console.log(DATC);
        $.ajax({
            url: '../menu.aspx/existeTC',
            data: '{DATC:' + JSON.stringify(DATC) + '}',
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.d == 0) {
                    $("#WindowLoad").remove();
                    alert('Ingrese el tipo cambio para la fecha del proceso');
                    var ancho = window.screen.width;
                    var alto = window.innerHeight;
                    ancho = ancho + "px";
                    alto = alto + "px";
                    $('body').append("<div id='WindowLoad' style='width:" + ancho + ";height:" + alto + "' onclik='remover();'></div>");
                    //creamos un input text para que el foco se plasme en este y el usuario no pueda escribir en nada de atras
                    input = document.createElement("input");
                    input.id = "focusInput";
                    input.type = "text"

                    //asignamos el div que bloquea
                    $("#WindowLoad").append(input);

                    //asignamos el foco y ocultamos el input text
                    $("#focusInput").focus();
                    $("#focusInput").hide();
                    //centramos el div del texto
                    //$("#WindowLoad").html(imgCentro);
                    $("#WindowLoad").append(input);
                }
            }, error: function (data) {
                console.log(data);
            }
        });

    },
    block: function (ruta) {
        $.ajax({
            url: ruta,
            data: '{}',
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.d) {
                    //console.log(moment(data.d.AC_DFECPR1).format('DD/MM/YYYY'));
                    //Operacion.mask('FB').val(moment(data.d.AC_DFECPR1).format('DD/MM/YYYY'));
                    $('#HFFB').val(moment(data.d.AC_DFECPR1).format('DD/MM/YYYY'));
                    //$('#FB').val(moment(data.d.AC_DFECPR1).format('DD/MM/YYYY'));
                    //console.log(UHTML.dt);
                }
            }, error: function (data) {
                console.log(data);
            }
        });
    },
    remover: function () {
        $("#WindowLoad").remove();
    },
    conTC: function (op) {
        var nv;
        switch (op) {
            case 'C': break;
            case 'F': break;
            case 'M': nv = 'C'; break;
            case 'V': nv = op; break;
        }
        return nv;
    },
    hora: function () {
        chora = new Date();
        chora = chora.getHours();
        cminu = new Date().getMinutes();
        chora = new String(chora);
        cminu = new String(cminu);
        var hor = chora + ":" + cminu;
        return hor;
    },
    sumaFecha: function (d, fecha) {
        var Fecha = new Date();
        var sFecha = fecha || (Fecha.getDate() + "/" + (Fecha.getMonth() + 1) + "/" + Fecha.getFullYear());
        var sep = sFecha.indexOf('/') != -1 ? '/' : '-';
        var aFecha = sFecha.split(sep);
        var fecha = aFecha[2] + '/' + aFecha[1] + '/' + aFecha[0];
        fecha = new Date(fecha);
        fecha.setDate(fecha.getDate() + parseInt(d));
        var anno = fecha.getFullYear();
        var mes = fecha.getMonth() + 1;
        var dia = fecha.getDate();
        mes = (mes < 10) ? ("0" + mes) : mes;
        dia = (dia < 10) ? ("0" + dia) : dia;
        var fechaFinal = dia + sep + mes + sep + anno;
        return (fechaFinal);
    },
    mi_formato: function (amount, decimals) {

        amount += ''; // por si pasan un numero en vez de un string
        amount = parseFloat(amount.replace(/[^0-9\.]/g, '')); // elimino cualquier cosa que no sea numero o punto

        decimals = decimals || 0; // por si la variable no fue fue pasada

        // si no es un numero o es igual a cero retorno el mismo cero
        if (isNaN(amount) || amount === 0)
            return parseFloat(0).toFixed(decimals);

        // si es mayor o menor que cero retorno el valor formateado como numero
        amount = '' + amount.toFixed(decimals);

        var amount_parts = amount.split('.'),
            regexp = /(\d+)(\d{3})/;

        while (regexp.test(amount_parts[0]))
            amount_parts[0] = amount_parts[0].replace(regexp, '$1' + ',' + '$2');

        return amount_parts.join('.');
    }
}
//Operacion.TC();
//Operacion.block();
var UHTML = function () {
    this.id;
    this.dt;
    this.mk;
    this.field = function (val) {
        var campo = '';
        if (typeof val != undefined) {
            return campo = this.refcia + "" + val;
            //return $("#"+campo+""+val);
        }
    }
    this.rajax = function (data) {
        this.dt = data;
        //console.log(this.dt);
    }
}
/*var urls = window.location.pathname;
urls = urls.replace("/", "R1=");
urls1 = urls.replace("/", "&R2=");
function nuevo(name) {
    var aux1 = new RegExp('[\?&]' + name + '=([^&#]*)').exec(urls1);
    return aux1 = (aux1 != null ? aux1[1] || 0 : "");
}
alert(nuevo('R2'));*/