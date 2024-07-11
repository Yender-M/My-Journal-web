var table;

function agregarRegistro() {
    // Obtener valores de los inputs

    var ministerio = document.getElementById("ministerio").value;
    console.log(ministerio)
    var descripcion = document.getElementById("descripcion").value;

    var usuarioSelect = document.getElementById("usuario");
    var usuario = usuarioSelect.value;
    var usuarioText = usuarioSelect.options[usuarioSelect.selectedIndex].text;

    // Validar que todos los campos estén llenos
    if (!ministerio || !usuario) {
        alert("Todos los campos son obligatorios.");
        return;
    }

    // Crear una nueva fila
    table.row.add([
        ministerio,
        usuarioText,
        descripcion,
        '<label class="switch"> <input type="checkbox" id="toggleSwitchVer">     <span class="slider"></span></label >',
        '<label class="switch"> <input type="checkbox" id="toggleSwitchCrear">     <span class="slider"></span></label >',
        '<label class="switch"> <input type="checkbox" id="toggleSwitchEditar">     <span class="slider"></span></label >',
        '<label class="switch"> <input type="checkbox" id="toggleSwitchAnular">     <span class="slider"></span></label >',
   
        '<button class="btn btn-danger btn-sm" onclick="eliminarRegistro(this)"><i class="fa fa-trash" aria-hidden="true"></i></button>'
    ]).draw(false);

    var estadoVer = 0;
    var estadoCrear = 0;
    var estadoEditar = 0;
    var estadoAnular = 0;
    document.getElementById('toggleSwitchVer').addEventListener('change', function () {
        if (this.checked) {
            alert("Switch activado");
            estadoVer = 1;
        } else {
            console.log("Switch desactivado");
            estadoVer = 0;

        }
    });    document.getElementById('toggleSwitchCrear').addEventListener('change', function () {
        if (this.checked) {
            alert("Switch activado");
            estadoCrear = 1;
        } else {
            console.log("Switch desactivado");
            estadoCrear = 0;

        }
    });    document.getElementById('toggleSwitchEditar').addEventListener('change', function () {
        if (this.checked) {
            alert("Switch activado");
            estadoEditar = 1;
        } else {
            alert("Switch desactivado");
            estadoEditar = 0;

        }
    });    document.getElementById('toggleSwitchAnular').addEventListener('change', function () {
        if (this.checked) {
            alert("Switch activado");
            estadoAnular = 1;
        } else {
            alert("Switch desactivado");
            estadoAnular = 0;

        }
    });

    // Añadir campos ocultos para enviar al controlador
    var form = $('form');
    form.append('<input type="hidden" name="ministerio" value="' + ministerio + '">');
    form.append('<input type="hidden" name="usuario" value="' + usuario + '">');
    form.append('<input type="hidden" name="Descripcion" value="' + descripcion + '">');
    form.append('<input type="hidden" id="Ver"  name="Ver" value="' + estadoVer + '">');
    form.append('<input type="hidden" name="Crear" value="' + estadoCrear + '">');
    form.append('<input type="hidden" name="Editar" value="' + estadoEditar + '">');
    form.append('<input type="hidden" name="Anular" value="' + estadoAnular + '">');
    // Limpiar los campos de entrada
    document.getElementById("usuario").selectedIndex = 0;

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

    // Establecer la fecha actual en el campo de fecha al cargar la página
});

//function toggleEstado(checkbox) {
//    document.getElementById('toggleSwitch').addEventListener('change', function () {
//        if (this.checked) {
//            console.log("Switch activado");
//        } else {
//            console.log("Switch desactivado");
//        }
//    });
//}

