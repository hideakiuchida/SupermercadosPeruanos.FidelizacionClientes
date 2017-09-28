var AfiliacionModule = function (config) {

    var _config = {
        urlBuscarAfiliacionCliente: config.urlBuscarAfiliacionCliente,
        urlEvaluar: config.urlEvaluar
    };

    var _evaluar = function () {
        var _codigoCliente = $("#txtCodigo").val();
        $.ajax({
            type: "GET",
            url: _config.urlEvaluar,
            data: { codigoCliente: _codigoCliente },
            success: function (data) {
                var mensaje = "";
                if (data.EstadoAfiliacion)
                    mensaje = "La tarjata OH ha sido aprobada."
                else
                    mensaje = "La tarjata OH ha sido rechazada."

                $("#lblMensajeAfiliacion").text(mensaje);
                $("#lblNumeroTarjeta").text(data.NumeroTarjeta);          
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(xhr.status);
                alert(thrownError);
            }
        });

        return false;
    };

    var _buscarAfiliacionCliente = function () {
        var _numeroDocumento = $("#txtBusquedaPorNumDoc").val();
        $.ajax({
            type: "GET",
            url: _config.urlBuscarAfiliacionCliente,
            data: { numeroDocumento: _numeroDocumento},
            success: function (data) {
                if (data.success) {
                    _setSeccionDatosCliente(data.Cliente);
                    _setSeccionDatosCalificacion(data.Calificacion);
                    _setSeccionEvaluacion(data.Afiliacion);
                    _setSeccionDeudas(data.Infocorp);
                    
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

    var _setSeccionDatosCliente = function (cliente) {
        $("#txtCodigo").val(cliente.Codigo);
        $("#txtNombres").val(cliente.Nombre);
        $("#txtApellidos").val(cliente.ApellidoPaterno + ' ' + cliente.ApellidoMaterno);        
        $("#txtNumeroDocumento").val(cliente.NumeroDocumentoIdentidad);
    };

    var _setSeccionDatosCalificacion = function (calificacion) {
        $("#txtSueldoMensual").val(calificacion.SueldoCliente);
        $("#txtOtrosIngresos").val(calificacion.OtrosIngresos);
        $("#txtLineaCredito").val(calificacion.LineaCredito);
    };

    var _setSeccionEvaluacion = function (afiliacion) {
        $("#txtNumeroTarjeta").val(afiliacion.NumeroTarjeta);
    };

    var _setSeccionDeudas = function (deudas) {
        $('#table_deudas').DataTable({
            destroy: true,
            columns: [
                { data: 'EntidadFinanciera' },
                { data: 'MontoDeuda' },
                { data: 'CalificacionSBS' }
            ],
            data: deudas

        });
    }

    var _bindEvents = function () {
        $("#btnBuscarCliente").click(function () {
            _buscarAfiliacionCliente();
        });

        $("#modal-afiliar").on("show.bs.modal", function (e) {           
            var link = $(e.relatedTarget);
            $(this).find(".modal-body").load(link.attr("href"));
            _evaluar();
            
        });
    };

    var _initialize = function () {
        $('#table_deudas').DataTable();
        _bindEvents();
    };

    return {
        initialize: _initialize
    };
};