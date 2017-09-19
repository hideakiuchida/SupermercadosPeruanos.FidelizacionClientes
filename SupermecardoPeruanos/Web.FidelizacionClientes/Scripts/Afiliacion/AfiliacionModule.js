var AfiliacionModule = function (config) {

    var _config = {
        urlBuscarAfiliacionCliente: config.urlBuscarAfiliacionCliente
    };

    var _buscarAfiliacionCliente = function () {
        var _numeroDocumento = $("#txtBusquedaPorNumDoc").val();
        $.ajax({
            type: "GET",
            url: _config.urlBuscarAfiliacionCliente,
            data: { numeroDocumento: _numeroDocumento},
            success: function (data) {

            },
            error: function () {
            }
        });

        return false;
    };

    var _bindEvents = function () {
        $("#btnBuscarCliente").click(function () {
            _buscarAfiliacionCliente();
        });
    };

    var _initialize = function () {
        $('#table_id').DataTable();
        _bindEvents();
    };

    return {
        initialize: _initialize,
        buscarAfiliacionCliente: _buscarAfiliacionCliente
    };
};