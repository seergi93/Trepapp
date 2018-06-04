// Write your JavaScript code.
$('#modalEditar').on('shown.bs.modal', function () {
    $('#myInput').trigger('focus')
})

//Variables globales donde se almacenan datos de registro, aunque estos datos nunca los modificaremos
var accessFailedCount;
var concurrencyStamp;
var emailConfirmed;
var lockoutEnabled;
var lockoutEnd;
var normalizedUserName;
var normalizedEmail;
var passwordHash;
var phoneNumberConfirmed;
var securityStamp;
var twoFactorEnabled;

var j = 0;
var items;
//Variables globales para cada propiedad del usuario
var id;
var userName;
var email;
var phoneNumber;


var role;
var selectRole;


function getUser(id, action) {
    $.ajax({
        type: "POST",
        url: action,
        data: { id },
        success: function (response) {
            mostrarUser(response);
        }
    });
}

function mostrarUser(response) {
    j = 0;
    items = response;

    for (var i = 0; i < 3; i++) {
        var x = document.getElementById('Select');
        x.remove(i);
    }

    $.each(items, function (index, val) {
        $('input[name=Id]').val(val.id);
        $('input[name=UserName]').val(val.userName);
        $('input[name=Email]').val(val.email);
        $('input[name=PhoneNumber]').val(val.phoneNumber);
        document.getElementById('Select').options[0] = new Option(val.role, val.roleId);
        //Mostrar detalles
        $("#dEmail").text(val.email);
        $("#dUserName").text(val.userName);
        $("#dPhoneNumber").text(val.phoneNumber);
        $("#dRol").text(val.role);
        //Mostrar los datos del usuario que deseo eliminar
        $("#eUsuario").text(val.email);
        $('input[name=EIdUsuario]').val(val.id);


    });




}


function getRoles(action) {
    $.ajax({
        type: "POST",
        url: action,
        data: {},
        success: function (response) {
            if (j === 0) {
                for (var i = 0; i < response.length; i++) {
                    document.getElementById('Select').options[i] = new Option(response[i].text, response[i].value);
                }
                j = 1;
            }
        }


    });

}

function editarUser(action) {
    //Obtenemos datos del input formulario
    id = $('input[name=Id]')[0].value;
    email = $('input[name=Email]')[0].value;
    phoneNumber = $('input[name=PhoneNumber]')[0].value;

    role = document.getElementById('Select');
    selectRole = role.options[role.selectedIndex].text;

    $.each(items, function (index, val) {
        accessFailedCount = val.accessFailedCount;
        concurrencyStamp = val.concurrencyStamp;
        emailConfirmed = val.emailConfirmed;
        lockoutEnabled = val.lockoutEnabled;
        lockoutEnd = val.lockoutEnd;
        normalizedUserName = val.normalizedUserName;
        normalizedEmail = val.normalizedEmail;
        passwordHash = val.passwordHash;
        phoneNumberConfirmed = val.phoneNumberConfirmed;
        securityStamp = val.securityStamp;
        twoFactorEnabled = val.twoFactorEnabled;
        userName = val.userName;
    });
    $.ajax({
        type: "POST",
        url: action,
        data: { id, userName, email, phoneNumber, accessFailedCount, concurrencyStamp, emailConfirmed, lockoutEnabled, lockoutEnd, normalizedEmail, normalizedUserName, passwordHash, phoneNumberConfirmed, securityStamp, twoFactorEnabled, selectRole },
        success: function (response) {
            if (response === "Save") {
                window.location.href = "Users";
            } else {
                alert("No se puede editar");
            }

        }
    });
}
function ocultarDetalleUsuario() {
    $("#modalDetalle").modal("hide");
}

function eliminarUsuario(action) {
    var id = $('input[name=EIdUsuario]')[0].value;
    $.ajax({
        type: "POST",
        url: action,
        data: { id },
        success: function (response) {
            if (response === "Delete") {
                window.location.href = "Users";
            }
            else {
                alert("No se puede eliminar el registro");
            }
        }
    });
}

function crearUser(action) {
    //Obtener datos del usuario
    userName = $('input[name=UserNameNuevo]')[0].value;
    email = $('input[name=EmailNuevo]')[0].value;
    phoneNumber = $('input[name=PhoneNumberNuevo]')[0].value;
    passwordHash = $('input[name=PasswordHashNuevo]')[0].value;
    //Siempre entra como user
    selectRole = "User";

    //Validación

    //Enviar ajax
    $.ajax({
        type: "POST",
        url: action,
        data: { userName, email, phoneNumber, passwordHash, selectRole },
        success: function (response) {
            if (response === "Save") {
                $('#mensajeNuevo').html('<div class="alert alert-success" role="alert">El usuario se ha creado correctamente</div >');
            }
            else {
                $('#mensajeNuevo').html('<div class="alert alert-danger" role="alert"> No se puede guardar el usuario. <br/> · Ingrese un email correcto. <br/> · El password debe tener de 6-100 caracteres, al menos un caracter especial, una letra mayúscula y un número<div>');
            }
        }
    });
}