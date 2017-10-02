var AfiliacionModule = function (config) {

    var _config = {
        urlBuscarAfiliacionCliente: config.urlBuscarAfiliacionCliente,
        urlEvaluar: config.urlEvaluar,
        urlRegistrar: config.urlRegistrar
    };

    var _registrar = function () {
        var _numeroDocumento = $("#txtNumeroDocumento").val();
        var _numerotarjeta = $("#lblNumeroTarjeta").text();
        var _tipo = $("#lblTipo").text();

        $.ajax({
            type: "POST",
            url: _config.urlRegistrar,
            data: {
                codigoCliente: _numeroDocumento,
                numero: _numerotarjeta,
                tipo: _tipo
            },
            success: function (data) {
                if (data.success) {
                    alert(data.message);
                    document.getElementById('btnRegistrarAfiliacion').disabled = true;
                    _limpiar();

                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(xhr.status);
                alert(thrownError);
            }
        });

        return false;
    };

    var _evaluar = function () {
        var _codigoCliente = $("#txtCodigo").val();
        var _numeroDocumento = $("#txtBusquedaPorNumDoc").val();
        $.ajax({
            type: "GET",
            url: _config.urlEvaluar,
            data: { codigoCliente: _codigoCliente, numeroDocumento: _numeroDocumento },
            success: function (data) {
                var mensaje = "";
                if (data.EstadoAfiliacion) {
                    mensaje = "La tarjeta OH ha sido aprobada."
                    $("#msjs").css("display", "normal");
                    $("#lblNumeroTarjeta").text(data.NumeroTarjeta)
                    $("#lblTipo").text(data.Tipo)
                    document.getElementById('btnRegistrarAfiliacion').disabled = false;
                }
                else {
                    mensaje = "La tarjeta OH ha sido rechazada."
                    $("#msjs").css("display", "none");
                    document.getElementById('btnRegistrarAfiliacion').disabled = true;
                    _limpiar();
                }

                $("#lblMensajeAfiliacion").text(mensaje);         
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
                    

                    if (data.Estado === "D") {
                        alert("La Solicitud ya ha sido Desaprobada");
                      document.getElementById('btnEvaluar').disabled = true;                     
                    } else if (data.Estado === "A") {
                        alert("La Solicitud ya ha sido Aprobada");
                        document.getElementById('btnEvaluar').disabled = true;                     
                    } else {
                        document.getElementById('btnEvaluar').disabled = false;                     
                    }
                    
                    
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

    var _limpiar = function () {
        $("#txtSueldoMensual").val("");
        $("#txtOtrosIngresos").val("");
        $("#txtLineaCredito").val("");
        $("#txtCodigo").val("");
        $("#txtNombres").val("");
        $("#txtApellidos").val("");
        $("#txtNumeroDocumento").val("");
        $("#txtNumeroTarjeta").val("");
        $("#txtBusquedaPorNumDoc").val("");
        _removerTabla();
        document.getElementById('btnEvaluar').disabled = true; 
    };

    var _setSeccionEvaluacion = function (afiliacion) {
        $("#txtNumeroTarjeta").val(afiliacion.NumeroTarjeta);
    };

    var _removerTabla = function () {
        var table = $('#table_deudas').DataTable();

        var rows = table
            .rows()
            .remove()
            .draw();
    }

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

        $("#btnRegistrarAfiliacion").click(function () {
            _registrar();
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