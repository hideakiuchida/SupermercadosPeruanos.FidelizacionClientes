var ClienteModule = function (config) {

    var _config = {
        urlObtenerClientes: config.urlObtenerClientes,
        urlObtenerCliente: config.urlObtenerCliente,
        urlRegistrar: config.urlRegistrar,
        urlEditar: config.urlEditar,
        urlEliminar: config.urlEliminar
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

    var _obtenerCliente = function (numeroDocumento) {
        $.ajax({
            type: "GET",
            url: _config.urlObtenerCliente,
            data: { numeroDocumento: numeroDocumento},
            success: function (data) {
                if (data.success) {
                    var cliente = data.cliente;
                    $("#txt-codigo-editar").val(cliente.Codigo);
                    $("#select-tipo-documento-editar").val(cliente.TipoDocumentoIdentidad);
                    $("#txt-num-doc-editar").val(cliente.NumeroDocumentoIdentidad);
                    $("#txt-nombres-editar").val(cliente.Nombre);
                    $("#txt-apellido-paterno-editar").val(cliente.ApellidoPaterno);
                    $("#txt-apellido-materno-editar").val(cliente.ApellidoMaterno);
                    $("#txt-telefono-editar").val(cliente.TelefonoFijo);
                    $("#txt-celular-editar").val(cliente.TelefonoMovil);
                    $("#txt-correo-editar").val(cliente.Email);
                    $("#select-sexo-editar").val(cliente.Sexo);
                    $("#txt-fec-nac-editar").val(cliente.FechaNacimientoDisplay);
                    $("#txt-direccion-editar").val(cliente.Direccion);
                    $("#select-situacion-editar").val(cliente.SituacionLaboral);
                    $("#select-vea-club-editar").val(cliente.IndicadorVeaClub);
                    $("#select-tarjeta-oh-editar").val(cliente.IndicadorTarjeta);
                }
                else {
                    alertify.alert("Mensaje", "No existen cliente.");
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alertify.alert("Mensaje", thrownError);
            }
        });
        return false;
    };

    var _registrar = function () {
        var _tipoDocumento = $("#select-tipo-documento").val();
        var _numeroDocumento = $("#txt-num-doc").val();
        if (_numeroDocumento.length > 8) {
            alertify.alert("Mensaje", "El Número de Documento posee más de 8 caracteres.");
            return false;
        }
        var _nombres = $("#txt-nombres").val();
        var _apellidoPaterno = $("#txt-apellido-paterno").val();
        var _apellidoMaterno = $("#txt-apellido-materno").val();
        var _telefono = $("#txt-telefono").val();
        var _celular = $("#txt-celular").val();
        var _correo = $("#txt-correo").val();
        var _sexo = $("#select-sexo").val();
        var _fechaNacimiento = $("#txt-fec-nac").val();
        var _direccion = $("#txt-direccion").val();
        var _situacion = $("#select-situacion").val();
        var _veaClub = $("#select-vea-club").val();
        var _tarjetaOH = $("#select-tarjeta-oh").val();

        $.ajax({
            type: "POST",
            url: _config.urlRegistrar,
            data: {
                Nombre:_nombres,
                ApellidoPaterno: _apellidoPaterno,
                ApellidoMaterno: _apellidoMaterno,
                TipoDocumentoIdentidad: _tipoDocumento,
                NumeroDocumentoIdentidad: _numeroDocumento,
                FechaNacimiento: _fechaNacimiento,
                Sexo: _sexo,
                Email: _correo,
                Direccion: _direccion,
                TelefonoFijo: _telefono,
                TelefonoMovil: _celular,
                SituacionLaboral: _situacion,
                IndicadorTarjeta: _tarjetaOH,
                IndicadorVeaClub: _veaClub
            },
            success: function (data) {
                if (data.success) {
                    alertify.alert("Registro de Cliente", data.mensaje, function () {
                        _limpiar();
                        window.location.reload();
                    });
                }
                else
                    alertify.alert("Mensaje", data.mensaje);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alertify.alert("Mensaje", thrownError);
            }
        });

        return false;
    };

    var _editar = function () {
        var _numeroDocumento = $("#txt-num-doc-editar").val();
        var _telefono = $("#txt-telefono-editar").val();
        var _celular = $("#txt-celular-editar").val();
        var _correo = $("#txt-correo-editar").val();
        var _direccion = $("#txt-direccion-editar").val();
        var _situacion = $("#select-situacion-editar").val();
        var _veaClub = $("#select-vea-club-editar").val();
        var _tarjetaOH = $("#select-tarjeta-oh-editar").val();

        $.ajax({
            type: "POST",
            url: _config.urlEditar,
            data: {
                NumeroDocumentoIdentidad: _numeroDocumento,
                Email: _correo,
                Direccion: _direccion,
                TelefonoFijo: _telefono,
                TelefonoMovil: _celular,
                SituacionLaboral: _situacion,
                IndicadorTarjeta: _tarjetaOH,
                IndicadorVeaClub: _veaClub
            },
            success: function (data) {
                if (data.success) {
                    alertify.alert("Edición de Cliente", data.mensaje, function () {
                        _limpiar();
                        window.location.reload();
                    });
                }
                else
                    alertify.alert("Mensaje", data.mensaje);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alertify.alert("Mensaje", thrownError);
            }
        });

        return false;
    };

    var _eliminar = function (numeroDocumento) {
        var _numeroDocumento = $("#txt-num-doc-eliminar").val();
        $.ajax({
            type: "POST",
            url: _config.urlEliminar,
            data: { numeroDocumento: _numeroDocumento },
            success: function (data) {
                if (data.success) {
                    alertify.alert("Eliminación de Cliente", data.mensaje, function () {
                        _limpiar();
                        window.location.reload();
                    });
                }
                else
                    alertify.alert("Mensaje", data.mensaje);
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
        var table = $('#table_clientes').DataTable({
            destroy: true,
            columns: [
                { data: 'Codigo' },
                { data: 'NumeroDocumentoIdentidad' },
                { data: 'Nombre' },
                { data: 'ApellidosDisplay' },
                { data: 'FechaNacimientoDisplay' },
                { data: 'Direccion' },
                { data: 'IndicadorVeaClub' },
                { data: 'IndicadorTarjeta' },
                {
                    data: null,
                    className: "center",
                    defaultContent: '<button id="btn-editar-cliente" class="btn btn-default btn-sm" data-toggle="modal" data-target="#modal-editar" data-remote="false"> <span class="glyphicon glyphicon-pencil"></span></button> ' + 
                    '<button id="btn-eliminar-cliente" class="btn btn-default btn-sm" data-toggle="modal" data-target="#modal-eliminar" data-remote="false"> <span class="glyphicon glyphicon-remove"></span></button> '
                }
            ],
            data: clientes,
            "language": {
                "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
            }
        });

        $('#table_clientes tbody').on('click', '#btn-editar-cliente', function () {
            var cliente = table.row($(this).parents('tr')).data();
            _obtenerCliente(cliente.NumeroDocumentoIdentidad);
        });

        $('#table_clientes tbody').on('click', '#btn-eliminar-cliente', function () {
            var cliente = table.row($(this).parents('tr')).data();
            $("#txt-num-doc-eliminar").val(cliente.NumeroDocumentoIdentidad);
        });
    };

    var _bindEvents = function () {
        $('#select-departamento').on('change', function () {
            _obtenerClientes();
        });

        $('#select-veaclub').on('change', function () {
            _obtenerClientes();
        });

        $('#select-tarjetaoh').on('change', function () {
            _obtenerClientes();
        });

        $("#modal-registrar").on("show.bs.modal", function (e) {
            var link = $(e.relatedTarget);
            $(this).find(".modal-body").load(link.attr("href"));

        });

        $("#seccion-datos-cliente").submit(function (e) {
            e.preventDefault();
            _registrar();
        });

        $("#seccion-datos-cliente-editar").submit(function (e) {
            e.preventDefault();
            _editar();
        });

        $("#seccion-datos-cliente-eliminar").submit(function (e) {
            e.preventDefault();
            _eliminar();
        });
    };

    var _initialize = function () {
        $("#txt-fec-nac").datepicker();
        _bindEvents();
        _obtenerClientes();
    };

    return {
        initialize: _initialize
    };
};