var CatalogoModule = function (config) {

    var _config = {
       // urlBuscarAfiliacionCliente: config.urlBuscarAfiliacionCliente
    };


    var _buscarAfiliacionCliente = function () {
        var _numeroDocumento = $("#txtBusquedaPorNumDoc").val();
        $.ajax({
            type: "GET",
            url: _config.urlBuscarAfiliacionCliente,
            data: { numeroDocumento: _numeroDocumento },
            success: function (data) {
                if (data.success) {

                }
                else {
                    alert('No se encontro el Cliente');
                }

            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(xhr.status);
                alert(thrownError);
            }
        });

        return false;
    };

    var _bindEvents = function () {
       /* $("#btnBuscarCliente").click(function () {
            _buscarAfiliacionCliente();
        });*/
    };

    var _initialize = function () {
        _bindEvents();
    };

    return {
        initialize: _initialize
    };
};