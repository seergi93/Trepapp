class Vias {
    constructor(nombre, descripcion, grado, sector, action) {
        this.nombre = nombre;
        this.descripcion = descripcion;
        this.grado = grado;
        this.sector = sector;
        this.action = action;
    }
    getSectores() {
        var action = this.action;
        var count = 1;
        $.ajax({
            type: "POST",
            url: action,
            data: {},
            success: (response) => {
                console.log(response);
                if (0 < response.length) {
                    for (var i = 0; i < response.length; i++) {
                        document.getElementById('SectorVias').options[count] = new Option(response[i].nombre,
                            response[i].sectorId);
                        count++;
                    }
                }
            }
        });
    }
    //filtrarVias(numPagina, order) {
    //    var valor = this.nombre;
    //    var action = this.action;
    //    if (valor == "") {
    //        valor = "null";
    //    }
    //    $.ajax({
    //        type: "POST",
    //        url: action,
    //        data: { valor, numPagina, order },
    //        success: (response) => {
    //            $("#resultSearch").html(response[0][0]);
    //            $("#paginado").html(response[0][1]);
    //        }
    //    });
    //}
}