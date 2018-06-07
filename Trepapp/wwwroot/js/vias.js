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


    agregarVia(id, funcion) {
        if (this.nombre === "") {
            document.getElementById("Nombre").focus();
        } else if (this.descripcion === "") {
            document.getElementById("Descripcion").focus();
        } else if (this.grado === "") {
            document.getElementById("Grado").focus();
        } else if (this.sector === "0") {
            document.getElementById("mensaje").innerHTML = "Seleccione un sector";
        } else {
            var nombre = this.nombre;
            var descripcion = this.descripcion;
            var grado = this.grado;
            var sector = this.sector;
            var action = this.action;
            $.ajax({
                type: "POST",
                url: action,
                data: { id, nombre, descripcion, grado, sector, funcion },
                success: (response) => {

                    if (response[0].code === "Save") {
                        this.restablecer();
                    } else {
                        document.getElementById("mensaje").innerHTML = '<div class="alert alert-danger" role="alert">No se ha podido guardar la vía<div>';
                    }
                }
            });
        }
    }

    restablecer() {
        document.getElementById("Nombre").value = "";
        document.getElementById("Descripcion").value = "";
        document.getElementById("Grado").value = "";
        document.getElementById("SectorVias").selectedIned = 0;
        document.getElementById("mensaje").value = "";

    }

    filtrarVia(numPagina, order) {
        var valor = this.nombre;
        var action = this.action;
        if (valor === "") {
            valor = "null";
        }
        $.ajax({
            type: "POST",
            url: action,
            data: { valor, numPagina, order },
            success: (response) => {
                $("#resultSearch").html(response[0][0]);
                $("#paginado").html(response[0][1]);
            }
        });
    }
}