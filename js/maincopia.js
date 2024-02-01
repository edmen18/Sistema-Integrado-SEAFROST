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
        if(est==1){
            mascara.attr('disabled', true);
            //mascara.removeAttr("placeholder");
        }else{
            mascara.removeAttr("disabled");
            //mascara.attr("placeholder", "Requerido");
        }
        //return (est == 1 ? mascara.attr('disabled', true): mascara.removeAttr("disabled"));
    },
    inputVisible: function (val, est) {
        /*Permite mostrar/ocultar un elmento del DOM*/
        return (est == 1 ? val.hide() : val.show());
    },
    iVALC: function (input) {
        /*Permite validar campos del form*/
        var sw= true;       
        $.each(input, function (k, v) {
            sa = true;
            sa = sa && (Operacion.mask(v).is('[disabled]'));//SI ESTA DESAHABILITADO
            if (sa == false) {
                sw = sw && (Operacion.mask(v).val() != '' && Operacion.mask(v).val() != null);//COMPRUEBA VALOR
                //ncad = v.replace("txt", "");
                //(sw==false?alert('Debes completar el campo ' + v.replace("1","")):"");
                //console.log("k=>" + k + "v=>" + v + "e=>" + sw + "valor=>" + Operacion.mask(v).val() + "VALOR" + (Operacion.mask(v).val() != '' && Operacion.mask(v).val() != null));
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
        var aux = val;//$("'#"+val+"'");
        switch(op){
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
    oAjax: function (url, obj) {
        
        $.ajax({
            type: "POST",
            url: url,
            data: JSON.stringify(obj),
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (data) {
                aux = new UHTML();
                aux.rajax(data);
                //console.log(aux.dt);
            },
            error: function (response) {
                console.table(response);
            }
        });
        
    },
    oDialog: function (id, bl) {
        /*Permite asignar a un div configuración dialog*/
        $("#"+id).dialog({
            autoOpen: bl,
            resizable: true,
            width: 'auto',
            modal: true,
            closeOnEscape: false
        });
    },
    limpiarIS: function (obj) {
        //$('#MainContent_txtidProducto').val('');
    },

    Checktodos: function (Checkbox, vargrid, ncolumna) {
        var GridVwHeaderChckbox = document.getElementById(vargrid);
        for (y = 0; y < GridVwHeaderChckbox.rows.length; y++) {
            if (GridVwHeaderChckbox.rows[y].cells[ncolumna].getElementsByTagName("input")[0].disabled==false) {
                GridVwHeaderChckbox.rows[y].cells[ncolumna].getElementsByTagName("input")[0].checked = Checkbox.checked;//
            }
        }
    },
    TC: function () {
        var DATC={};
        DATC.XFECCAM2 = moment().format('DD/MM/YYYY');
        //console.log(DETA);
       
        $.ajax({
            url: "../menu.aspx/existeTC",
            data: '{DATC:' + JSON.stringify(DATC) + '}',
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.d==0) {
                    alert('Ingrese el tipo cambio para la fecha del proceso');
                }
            }, error: function (data) {
                console.log(data);
            }
        });
        
    }

}

var UHTML = function(){
    this.id;
    this.dt;
    this.mk;
    this.field= function (val) {
        var campo = '';
        if (typeof val != undefined) {
            return campo = this.refcia+""+val;
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