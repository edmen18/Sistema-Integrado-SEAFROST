var empleadoControllers = angular.module('empleadoControllers', []);

empleadoControllers.controller('EmpleadoListadoCtrl', ['$scope', '$http', function ($scope, $http) {
    empleados();
    profesiones();
    
    function empleados() {

        var request = $http({
            method: "POST",
            url: "servicios/servicios.aspx/GetEmployeeIDs",
            data: {}
        });
        request.success(function (data, status) {
            $scope.model = angular.fromJson(data.d);
       
        })
        request.error(function (data, status) {
            $scope.status = status;
        });


       
    }
    
    function profesiones(){
        $http.get('http://localhost:8080/tutoriales/angular/004/api/?a=profesiones').then(function(r){
            $scope.profesiones = r.data;
        });
    }
    
    $scope.retirar = function(id){
        if(confirm('Esta seguro de realizar esta acción?')){
            $http.get('http://localhost:8080/tutoriales/angular/004/api/?a=eliminar&id=' + id).then(function(r){
                empleados();
            });
        }
    }
    
    $scope.registrar = function(){
        var model = {
            Correo: $scope.Correo,
            Nombre: $scope.Nombre,
            Apellido: $scope.Apellido,
            Sexo: $scope.Sexo,
            Sueldo: $scope.Sueldo,
            Profesion_id: $scope.Profesion_id,
            FechaNacimiento: $scope.FechaNacimiento
        };
        
        $http.post('http://localhost:8080/tutoriales/angular/004/api/?a=registrar', model).then(function(r){
            empleados();
            
            $scope.Correo = null;
            $scope.Nombre = null;
            $scope.Apellido = null;
            $scope.Sueldo = null;
            $scope.FechaNacimiento = null;
        });
    }
}]);

empleadoControllers.controller('EmpleadoVerCtrl', ['$scope', '$routeParams', '$http', function ($scope, $routeParams, $http) {

    var codper = $routeParams.CodPer;
    var request = $http({
        method: "POST",
        url: "Sample2.aspx/ObtenerPersonaPorId",
        data: "{'codper':'" + codper + "'}"
    });
    request.success(function (data, status) {
        $scope.model = angular.fromJson(data.d);
    })
    request.error(function (data, status) {
        $scope.status = status;
    });

}]);