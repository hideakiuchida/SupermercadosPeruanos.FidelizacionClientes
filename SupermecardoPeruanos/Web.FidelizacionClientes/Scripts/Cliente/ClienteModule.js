var ClienteModule = function (config) {

    var _config = {
          urlObtenerClientes: config.urlObtenerClientes/*,
          urlEvaluar: config.urlEvaluar,
          urlRegistrar: config.urlRegistrar*/
    };

    var _obtenerClientes = function () {
        var departamentoId = $("#select-departamento").val();
        var tieneVeaClub = $("#select-veaclub").val();
        var tieneTarjetaOh = $("#select-tarjetaoh").val();
        $.ajax({
            type: "GET",
            url: _config.urlObtenerClientes,
            data: { departamentoId: departamentoId, tieneVeaClub: tieneVeaClub, tieneTarjetaOh: tieneTarjetaOh},
            success: function (data) {
                if (data.success) {
                    _setClientes(data.clientes);
                }
                else {
                    alertify.alert("Mensaje", "No existen clientes.");
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alertify.alert("Mensaje", thrownError);
            }
        });
        return false;
    };

    var _limpiar = function () {
        _removerTabla();
    };

    var _removerTabla = function () {
        var table = $('#table_clientes').DataTable();

        var rows = table
            .rows()
            .remove()
            .draw();
    };

    var _setClientes = function (clientes) {
        $('#table_clientes').DataTable({
            destroy: true,
            columns: [
                { data: 'Codigo' },
                { data: 'NumeroDocumentoIdentidad' },
                { data: 'Nombre' },
                { data: 'Apellidos' },
                { data: 'FechaNacimiento' },
                { data: 'Direccion' },
                { data: 'IndicadorVeaClub' },
                { data: 'IndicadorTarjeta' }
            ],
            data: clientes,
            "language": {
                "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
            }

        });
    };

    var _bindEvents = function () {
        /*$("#btnBuscarCliente").click(function () {
            _buscarAfiliacionCliente();
        });*/

        $("#btnRegistrarAfiliacion").click(function () {
            _registrar();
        });
    };

    var _initialize = function () {
        $('#table_clientes').DataTable({
            "language": {
                "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
            }
        });
        _bindEvents();
        _obtenerClientes();
    };

    return {
        initialize: _initialize
    };
};