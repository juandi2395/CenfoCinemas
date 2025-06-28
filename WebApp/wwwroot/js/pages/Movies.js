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
    }
}

$(document).ready(function () {
    var vc = new MovieViewController();
    vc.InitView();
})