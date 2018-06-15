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
                    alertify.alert("Registro de Solicitud", data.message, function () {
                        document.getElementById('btnRegistrarAfiliacion').disabled = true;
                        _limpiar();
                        window.location.reload();
                    });    
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
                var mydiv = document.getElementById('msjs');
                if (data.EstadoAfiliacion) {
                    mensaje = "La tarjeta OH ha sido aprobada.";
                    //$("#msjs").css("display", "normal");
                    mydiv.style.display = "block";
                    $("#lblNumeroTarjeta").text(data.NumeroTarjeta);
                    $("#lblTipo").text(data.Tipo);
                    document.getElementById('btnRegistrarAfiliacion').disabled = false;
                }
                else {
                    mensaje = "La tarjeta OH ha sido rechazada.";
                    //$("#msjs").css("display", "none");
                    mydiv.style.display = "none";
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
        if (_numeroDocumento.length === 8) {

            $.ajax({
                type: "GET",
                url: _config.urlBuscarAfiliacionCliente,
                data: { numeroDocumento: _numeroDocumento },
                success: function (data) {
                    if (data.success) {
                              
                        if (data.Afiliacion.NumeroTarjeta==null) {
                            alertify.alert("Mensaje", "No posee información de Afiliacion.");
                            return false;
                        }
                        _setSeccionDatosCliente(data.Cliente);
                        _setSeccionDatosCalificacion(data.Calificacion);
                        _setSeccionDeudas(data.Infocorp);
                        _setSeccionEvaluacion(data.Afiliacion);

                        if (data.Estado === "DESAPROBADO") {
                            alertify.alert("Estado de Solicitud","La solicitud ya ha sido Desaprobada");
                            document.getElementById('btnEvEstado de Solicitudaluar').disabled = true;
                        } else if (data.Estado === "APROBADO") {
                            alertify.alert("Estado de Solicitud", "La solicitud ya ha sido Aprobada");
                            $("#lblNombres").text(data.Cliente.Nombre);
                            $("#lblApellidos").text(data.Cliente.ApellidoPaterno + ' ' + data.Cliente.ApellidoMaterno);
                            $("#mensajeAprobado").show();    
                            document.getElementById('btnEvaluar').disabled = true;
                        } else {
                            document.getElementById('btnEvaluar').disabled = false;
                        }


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
        else { 
            alertify.alert("Mensaje", "Ingrese DNI Válido");
        }
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
        $("#mensajeAprobado").hide();
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
    };

    var _setSeccionDeudas = function (deudas) {
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
    };

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