var table;

function agregarRegistro() {
    // Obtener valores de los inputs
    var nombres = document.getElementById("nombres").value;
    var apellidos = document.getElementById("apellidos").value;
    var direccion = document.getElementById("direccion").value;
    var telefono = document.getElementById("telefono").value;
    var fechanacimiento = document.getElementById("fechanacimiento").value;
    var fechabautismo = document.getElementById("fechabautismo").value;
    var fechaFormatted = formatDate(fechanacimiento);
    var fechaFormatted1 = formatDate(fechabautismo);

    // Validar que todos los campos estén llenos
    if (!nombres || !apellidos || !direccion || !telefono || !fechanacimiento || !fechabautismo) {
        alert("Todos los campos son obligatorios.");
        return;
    }

    // Crear una nueva fila
    table.row.add([
        nombres,
        apellidos,
        direccion,
        telefono,
        fechaFormatted,
        fechaFormatted1,
        '<button class="btn btn-danger btn-sm" onclick="eliminarRegistro(this)"><i class="fa fa-trash" aria-hidden="true"></i></button>'
    ]).draw(false);

    // Añadir campos ocultos para enviar al controlador
    var form = $('form');
    form.append('<input type="hidden" name="Nombre" value="' + nombres + '">');
    form.append('<input type="hidden" name="Apellido" value="' + apellidos + '">');
    form.append('<input type="hidden" name="Direccion" value="' + direccion + '">');
    form.append('<input type="hidden" name="Telefono" value="' + telefono + '">');
    form.append('<input type="hidden" name="FechaNacimiento" value="' + fechanacimiento + '">');
    form.append('<input type="hidden" name="FechaBautismo" value="' + fechabautismo + '">');

    // Limpiar los campos de entrada
    document.getElementById("nombres").value = '';
    document.getElementById("apellidos").value = '';
    document.getElementById("direccion").value = '';
    document.getElementById("telefono").value = '';
    setTodayDate("fechanacimiento");
    setTodayDate("fechabautismo");

    // Actualizar la tabla para que sea responsive
    table.responsive.recalc();
}

function eliminarRegistro(button) {
    // Obtener la fila padre del botón y eliminarla
    var row = table.row($(button).parents('tr'));
    row.remove().draw();

    // Actualizar la tabla para que sea responsive
    table.responsive.recalc();
}

function formatDate(dateString) {
    var date = new Date(dateString);
    // Ajustar la fecha para evitar el problema de zona horaria
    date.setMinutes(date.getMinutes() + date.getTimezoneOffset());
    var day = ('0' + date.getDate()).slice(-2);
    var month = ('0' + (date.getMonth() + 1)).slice(-2);
    var year = date.getFullYear();
    return day + "/" + month + "/" + year;
}

function setTodayDate(elementId) {
    var today = new Date();
    var day = ('0' + today.getDate()).slice(-2);
    var month = ('0' + (today.getMonth() + 1)).slice(-2);
    var year = today.getFullYear();
    var todayFormatted = year + '-' + month + '-' + day; // Formato 'yyyy-MM-dd' para el campo datetime-local
    document.getElementById(elementId).value = todayFormatted;
}

$(document).ready(function () {
    table = $('#example').DataTable({
        "language": {
            "sProcessing": "Procesando...",
            "sLengthMenu": "Mostrar _MENU_ registros",
            "sZeroRecords": "No se encontraron resultados",
            "sEmptyTable": "Ningún dato disponible en esta tabla",
            "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
            "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
            "sInfoPostFix": "",
            "sSearch": "Buscar:",
            "sUrl": "",
            "sInfoThousands": ",",
            "sLoadingRecords": "Cargando...",
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            },
            "oAria": {
                "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                "sSortDescending": ": Activar para ordenar la columna de manera descendente"
            }
        },
        responsive: true,
        "sScrollX": "100%",
        "sScrollXInner": "110%",
        "bScrollCollapse": true
    });

    // Establecer la fecha actual en el campo de fecha al cargar la página
    setTodayDate("fechanacimiento");
    setTodayDate("fechabautismo");
});
