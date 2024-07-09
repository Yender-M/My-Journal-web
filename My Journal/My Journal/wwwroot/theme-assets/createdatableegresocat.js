var table;

function agregarRegistro() {
    // Obtener valores de los inputs
    var nombres = document.getElementById("nombres").value;
    var descripcion = document.getElementById("descripcion").value;

    // Validar que todos los campos estén llenos
    if (!nombres || !descripcion) {
        alert("Todos los campos son obligatorios.");
        return;
    }

    // Crear una nueva fila
    table.row.add([
        nombres,
        descripcion,
        '<button class="btn btn-danger btn-sm" onclick="eliminarRegistro(this)"><i class="fa fa-trash" aria-hidden="true"></i></button>'
    ]).draw(false);

    // Añadir campos ocultos para enviar al controlador
    var form = $('form');
    form.append('<input type="hidden" name="Nombre" value="' + nombres + '">');
    form.append('<input type="hidden" name="Descripcion" value="' + descripcion + '">');

    // Limpiar los campos de entrada
    document.getElementById("nombres").value = '';
    document.getElementById("descripcion").value = '';

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

});

