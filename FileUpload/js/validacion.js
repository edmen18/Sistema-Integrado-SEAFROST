
        function Numeros() {
            var key = window.event.keyCode;
            if (key < 48 || key > 57) {
                window.event.keyCode = 0;
            }
            
        }

        function letras() {
            var key = window.event.keyCode;
            if (key < 48 || key > 57) {
                
            }
            else {
                window.event.keyCode = 0;
            }

        }
     
         function decimales(e, field) {
             key = e.keyCode ? e.keyCode : e.which
             // backspace
             if (key == 8) return true
             // 0-9
             if (key > 47 && key < 58) {
                 if (field.value == "") return true
                 regexp = /.[0-9]{10}$/
                 return !(regexp.test(field.value))
             }
             // .
             if (key == 46) {
                 if (field.value == "") return false
                 regexp = /^[0-9]+$/
                 return regexp.test(field.value)
             }
             // other key
             return false

         }
   
             
   