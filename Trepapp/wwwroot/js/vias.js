//var localStorage = window.localStorage;

var promise = new Promise((resvolve, reject) => {

});

class Vias {
    constructor(nombre, descripcion, grado, sector, action) {
        this.nombre = nombre;
        this.descripcion = descripcion;
        this.grado = grado;
        this.sector = sector;
        this.action = action;
    }
    getSectores(id, funcion) {
        var action = this.action;
        var count = 1;
        $.ajax({
            type: "POST",
            url: action,
            data: {},
            success: (response) => {
                document.getElementById('SectorVias').options[0] = new Option("Seleccione una via", 0);
                if (0 < response.length) {
                    for (var i = 0; i < response.length; i++) {
                        if (0 === funcion) {
                            document.getElementById('SectorVias').options[count] = new Option(response[i].nombre,
                                response[i].sectorId);
                            count++;
                        } else {
                            if (id === response[i].sectorId) {
                                document.getElementById('SectorVias').options[0] = new Option(response[i].nombre,
                                    response[i].sectorId);
                                document.getElementById('SectorVias').selectedIndex = 0;
                                break;
                            }
                        }

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

    getVias(id, funcion) {
        var action = this.action;
        $.ajax({
            type: "POST",
            url: action,
            data: { id },
            success: (response) => {
                if (funcion === 0) {
                    promise = Promise.resolve({
                        id: response[0].sectorId,
                        nombre: response[0].nombre,
                        descripcion: response[0].descripcion,
                        grado: response[0].grado,
                        sector: response[0].sectorId
                    });
                } else {
                    document.getElementById("Nombre").value = response[0].nombre;
                    document.getElementById("Descripcion").value = response[0].descripcion;
                    document.getElementById("Grado").value = response[0].grado;
                    getSectores(response[0].sectorId, 1);



                }
            }
        });
    }

    restablecer() {
        document.getElementById("Nombre").value = "";
        document.getElementById("Descripcion").value = "";
        document.getElementById("Grado").value = "";
        document.getElementById("SectorVias").selectedIndex = 0;
        document.getElementById("mensaje").value = "";
        filtrarVia(1, "nombre");
        $('#ModalCS').modal('hide');
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
    editarVias(id, funcion) {
        var nombre, descripcion, grado, sector;
        var action = this.action;
        promesa.then(data => {
            // id = data.id;
            nombre = data.nombre
            descripcion = data.descripcion;
            grado = data.grado;
            sector = data.sector;
            $.ajax({
                type: "POST",
                url: action,
                data: { id, nombre, descripcion, grado, sector, funcion },
                success: (response) => {
                    if (response[0].code === "Save") {
                        this.restablecer();
                    } else {
                        document.getElementById("titleVia").innerHTML = response[0].descripcion;
                    }
                }
            });
        });
    }
}