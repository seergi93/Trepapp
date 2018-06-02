// Write your JavaScript code.
$('#modalEditar').on('shown.bs.modal', function () {
    $('#myInput').trigger('focus')
})

var items;
//Variables globales para cada propiedad del usuario
var id;
var userName;
var email;
var phoneNumber;
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

    items = response;
    $.each(items, function (index, val) {
        $('input[name=Id]').val(val.id);
        $('input[name=UserName]').val(val.userName);
        $('input[name=Email]').val(val.email);
        $('input[name=PhoneNumber]').val(val.phoneNumber);
    });


}
function editarUser(action) {
    //Obtenemos datos del input formulario
    id = $('input[name=Id]')[0].value;
    email = $('input[name=Email]')[0].value;
    phoneNumber = $('input[name=PhoneNumber]')[0].value;

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
        data: { id, userName, email, phoneNumber, accessFailedCount, concurrencyStamp, emailConfirmed, lockoutEnabled, lockoutEnd, normalizedEmail, normalizedUserName, passwordHash, phoneNumberConfirmed, securityStamp, twoFactorEnabled },
        success: function (response) {
            if (response == "Save") {
                window.location.href = "Users";
            } else {
                alert("No se puede editar");
            }

        }
    })



}