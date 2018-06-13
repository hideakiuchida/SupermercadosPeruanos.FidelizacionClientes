var ProductoCanjeModule = function (config) {

    var _config = {
     /*   urlBuscarAfiliacionCliente: config.urlBuscarAfiliacionCliente,
        urlEvaluar: config.urlEvaluar,
        urlRegistrar: config.urlRegistrar*/
    };

    /*var _buscarAfiliacionCliente = function () {
            $.ajax({
                type: "GET",
                url: _config.urlBuscarAfiliacionCliente,
                data: { numeroDocumento: _numeroDocumento },
                success: function (data) {
                    if (data.success) {
                     

                    }
                    else {
                        alertify.alert("Mensaje", "Cliente no tiene una Solicitud Registrada");
                    }

                },
                error: function (xhr, ajaxOptions, thrownError) {
                    alertify.alert("Mensaje", thrownError);
                }
            });

        }
        return false;
    };*/

    var _limpiar = function () {
        _removerTabla();
    };

    var _removerTabla = function () {
        var table = $('#table_deudas').DataTable();

        var rows = table
            .rows()
            .remove()
            .draw();
    };

   /* var _setSeccionDeudas = function (deudas) {
        $('#table_deudas').DataTable({
            destroy: true,
            columns: [
                { data: 'EntidadFinanciera' },
                { data: 'MontoDeuda' },
                { data: 'CalificacionSBS' }
            ],
            data: deudas,
            "language": {
                "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
            }

        });
    }*/

    var _bindEvents = function () {
        /*$("#btnBuscarCliente").click(function () {
            _buscarAfiliacionCliente();
        });*/

        $("#modal-afiliar").on("show.bs.modal", function (e) {
            var link = $(e.relatedTarget);
            $(this).find(".modal-body").load(link.attr("href"));
            _evaluar();

        });


        $("#btnRegistrarAfiliacion").click(function () {
            _registrar();
        });
    };

    var _initialize = function () {
        $('#table_deudas').DataTable({
            "language": {
                "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
            }
        });
        _bindEvents();
    };

    return {
        initialize: _initialize
    };
};