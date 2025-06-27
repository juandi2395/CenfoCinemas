// js que maneja todo el comportamiento de la vista de usuarios

// definir una clase JS, usando prototype

function UsersViewController() {

    this.ViewName = "Users";
    this.ApiEndPointName = "User";

    // Metodo constructor
    this.InitView = function () {
        console.log("User init view --> ok");
        this.LoadTable();
    }

    this.LoadTable = function (refresh) {

        // URL del API a invocar
        // https://localhost:7162/api/User/RetrieveAll

        var ca = new ControlActions();
        var service = this.ApiEndPointName + "/RetrieveAll";

        var urlService = ca.GetUrlApiService(service);

        /* FORMATO de JSON
            {
            "userCode": "marco2354",
            "name": "Marco Ruiz",
            "email": "marcoR@test.com",
            "password": "#$s78Tre487Rg",
            "birthDate": "1995-01-01T00:00:00",
            "status": "AC",
            "id": 2,
            "created": "2025-06-13T01:10:42.4466667",
            "updated": "0001-01-01T00:00:00"
            }
        */

       /* FORMATO TABLA
        <tr>
            <th>ID</th>
            <th>User Code</th>
            <th>Name</th>
            <th>Email</th>
            <th>BirthDate</th>
            <th>Status</th>
        </tr>
       */

        var columns = [];
        columns[0] = { 'data': 'id' }
        columns[1] = { 'data': 'userCode' }
        columns[2] = { 'data': 'name' }
        columns[3] = { 'data': 'email' }
        columns[4] = { 'data': 'birthDate' }
        columns[5] = { 'data': 'status' }

        $("#tblUsers").dataTable({
            "ajax": {
                url: urlService,
                "dataSrc": ""
            },
            columns: columns
        });
    }
}

$(document).ready(function () {
    var vc = new UsersViewController();
    vc.InitView();
})