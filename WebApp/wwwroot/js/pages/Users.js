// js que maneja todo el comportamiento de la vista de usuarios

// definir una clase JS, usando prototype

function UsersViewController()
{

    this.ViewName = "Users";
    this.ApiEndPointName = "User";

    // Metodo constructor
    this.InitView = function () {
        console.log("User init view --> ok");
        this.LoadTable();

        // Asociar el evento al boton
        $('#btnCreate').click( function () {
            // Llamar al metodo de crear
            var vc = new UsersViewController();
            vc.Create();
        });

        $('#btnUpdate').click(function () {
            // Llamar al metodo de actualizar
            var vc = new UsersViewController();
            vc.Update();
        });

        $('#btnDelete').click(function () {
            // Llamar al metodo de eliminar
            var vc = new UsersViewController();
            vc.Delete();
        });
    }

    this.LoadTable = function (refresh) {

        // URL del API a invocar
        // https://localhost:7162/api/User/RetrieveAll

        var ca = new ControlActions();
        var service = this.ApiEndPointName + "/RetrieveAll";

        var urlService = ca.GetUrlApiService(service);

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

        // Asignar eventos de carga de datos, segun el click
        $('#tblUsers tbody').on('click', 'tr', function () {

            // Extraemos la fila
            var row = $(this).closest('tr');

            // Extraemos DTO
            // Esto devuelve el json de la fila seleccionada por el usuario, segun la data devuelta por el API
            var useDTO = $('#tblUsers').DataTable().row(row).data();

            // Binding con el form
            $('#txtId').val(useDTO.id);
            $('#txtUserCode').val(useDTO.userCode);
            $('#txtName').val(useDTO.name);
            $('#txtEmail').val(useDTO.email);
            $('#txtStatus').val(useDTO.status);

            // Fecha tiene formato
            var onlyDate = useDTO.birthDate.split('T');
            $('#txtBirthDate').val(onlyDate[0]);
        })
    }

    this.Create = function () {

        var userDTO = {};
        // Atributos con valores default, que son controlados por el API
        userDTO.id = 0;
        userDTO.created = "2025-01-01";
        userDTO.updated = "2025-01-01";

        // Valores capturados en pantalla
        userDTO.userCode = $('#txtUserCode').val();
        userDTO.name = $('#txtName').val();
        userDTO.email = $('#txtEmail').val();
        userDTO.status = $('#txtStatus').val();
        userDTO.birthDate = $('#txtBirthDate').val();
        userDTO.password = $('#txtPassword').val();

        // Enviar data al API
        var ca = new ControlActions();
        var urlService = this.ApiEndPointName + "/Create";

        ca.PostToAPI(urlService, userDTO, function () {
            // Recargar la tabla
            $('#tblUsers').DataTable().ajax.reload();
        })
    }

    this.Update = function () {

        var userDTO = {};
        // Atributos con valores default, que son controlados por el API
        userDTO.id = $('#txtId').val();
        userDTO.created = "2025-01-01";
        userDTO.updated = "2025-01-01";

        // Valores capturados en pantalla
        userDTO.userCode = $('#txtUserCode').val();
        userDTO.name = $('#txtName').val();
        userDTO.email = $('#txtEmail').val();
        userDTO.status = $('#txtStatus').val();
        userDTO.birthDate = $('#txtBirthDate').val();
        userDTO.password = $('#txtPassword').val();

        // Enviar la data al API
        var ca = new ControlActions();
        var urlService = this.ApiEndPointName + "/Update";

        ca.PutToAPI(urlService, userDTO, function () {
            // Recargo de la tabla
            $('#tblUsers').DataTable().ajax.reload();
        });
    }

    this.Delete = function () {

        var userDTO = {};
        // Atributos con valores default, que son controlados por el API
        userDTO.id = $('#txtId').val();
        userDTO.created = "2025-01-01";
        userDTO.updated = "2025-01-01";
         
        // Valores capturados en pantalla
        userDTO.userCode = $('#txtUserCode').val();
        userDTO.name = $('#txtName').val();
        userDTO.email = $('#txtEmail').val();
        userDTO.status = $('#txtStatus').val();
        userDTO.birthDate = $('#txtBirthDate').val();
        userDTO.password = $('#txtPassword').val();

        // Enviar la data al API
        var ca = new ControlActions();
        var urlService = this.ApiEndPointName + "/Delete";

        ca.DeleteToAPI(urlService, userDTO, function () {
            // Recargo de la tabla
            $('#tblUsers').DataTable().ajax.reload();
        });
    }


}

$(document).ready(function () {
    var vc = new UsersViewController();
    vc.InitView();
})