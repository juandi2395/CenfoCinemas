// js que maneja todo el comportamiento de la vista de peliculas

// definir una clase JS, usando prototype

function MovieViewController()
{
    this.ViewName = "Movies";
    this.ApiEndPointName = "Movie";

    // Metodo constructor
    this.InitView = function () {
        console.log("Movie init view --> ok");
        this.LoadTable();

        // Asociar el evento al boton
        $('#btnCreate').click(function () {
            // Llamar al metodo de crear
            var vc = new MovieViewController();
            vc.Create();
        });

        $('#btnUpdate').click(function () {
            // Llamar al metodo de actualizar
            var vc = new MovieViewController();
            vc.Update();
        });

        $('#btnDelete').click(function () {
            // Llamar al metodo de eliminar
            var vc = new MovieViewController();
            vc.Delete();
        });
    }

    this.LoadTable = function (refresh) {
        // URL del API a invocar
        // https://localhost:7162/api/Movie/RetrieveAll
        var ca = new ControlActions();
        var service = this.ApiEndPointName + "/RetrieveAll";

        var urlService = ca.GetUrlApiService(service);

        var columns = [];
        columns[0] = { 'data': 'id' }
        columns[1] = { 'data': 'title' }
        columns[2] = { 'data': 'description' }
        columns[3] = { 'data': 'releaseDate' }
        columns[4] = { 'data': 'genre' }
        columns[5] = { 'data': 'director' }
        $("#tblMovies").dataTable({
            ajax: {
                url: urlService,
                "dataSrc": ""
            },
            columns: columns
        });

        // Asignar eventos de carga de datos, segun el click
        $('#tblMovies tbody').on('click', 'tr', function () {

            // Extraemos la fila
            var row = $(this).closest('tr');

            // Extraemos DTO
            // Esto devuelve el json de la fila seleccionada por el usuario, segun la data devuelta por el API
            var useDTO = $('#tblMovies').DataTable().row(row).data();

            // Binding con el form
            $('#txtId').val(useDTO.id);
            $('#txtTitle').val(useDTO.title);
            $('#txtDescription').val(useDTO.description);
            $('#txtGenre').val(useDTO.genre);
            $('#txtDirector').val(useDTO.director);

            // Fecha tiene formato
            var onlyDate = useDTO.releaseDate.split('T');
            $('#txtReleaseDate').val(onlyDate[0]);
        })
    }

    this.Create = function () {

        var movieDTO = {};
        // Atributos con valores default, que son controlados por el API
        movieDTO.id = 0;
        movieDTO.created = "2025-01-01";
        movieDTO.updated = "2025-01-01";

        // Valores capturados en pantalla
        movieDTO.title = $('#txtTitle').val();
        movieDTO.description = $('#txtDescription').val();
        movieDTO.releaseDate = $('#txtReleaseDate').val();
        movieDTO.genre = $('#txtGenre').val();
        movieDTO.director = $('#txtDirector').val();

        // Enviar data al API
        var ca = new ControlActions();
        var urlService = this.ApiEndPointName + "/Create";

        console.log(urlService);

        ca.PostToAPI(urlService, movieDTO, function () {
            // Recargar la tabla
            $('#tblMovies').DataTable().ajax.reload();
        })
    }

    this.Update = function () {

        var movieDTO = {};
        // Atributos con valores default, que son controlados por el API
        movieDTO.id = $('#txtId').val();;
        movieDTO.created = "2025-01-01";
        movieDTO.updated = "2025-01-01";

        // Valores capturados en pantalla
        movieDTO.title = $('#txtTitle').val();
        movieDTO.description = $('#txtDescription').val();
        movieDTO.releaseDate = $('#txtReleaseDate').val();
        movieDTO.genre = $('#txtGenre').val();
        movieDTO.director = $('#txtDirector').val();

        // Enviar la data al API
        var ca = new ControlActions();
        var urlService = this.ApiEndPointName + "/Update";

        ca.PutToAPI(urlService, movieDTO, function () {
            // Recargo de la tabla
            $('#tblMovies').DataTable().ajax.reload();
        });
    }

    this.Delete = function () {

        var movieDTO = {};
        // Atributos con valores default, que son controlados por el API
        movieDTO.id = $('#txtId').val();;
        movieDTO.created = "2025-01-01";
        movieDTO.updated = "2025-01-01";

        // Valores capturados en pantalla
        movieDTO.title = $('#txtTitle').val();
        movieDTO.description = $('#txtDescription').val();
        movieDTO.releaseDate = $('#txtReleaseDate').val();
        movieDTO.genre = $('#txtGenre').val();
        movieDTO.director = $('#txtDirector').val();

        // Enviar la data al API
        var ca = new ControlActions();
        var urlService = this.ApiEndPointName + "/Delete";

        ca.DeleteToAPI(urlService, movieDTO, function () {
            // Recargo de la tabla
            $('#tblMovies').DataTable().ajax.reload();
        });
    }
}

$(document).ready(function () {
    var vc = new MovieViewController();
    vc.InitView();
})