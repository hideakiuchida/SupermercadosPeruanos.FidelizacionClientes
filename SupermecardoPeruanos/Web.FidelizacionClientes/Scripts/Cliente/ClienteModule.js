var ClienteModule = function (config) {

    var _config = {
          urlObtenerClientes: config.urlObtenerClientes,
          urlRegistrar: config.urlRegistrar
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
                { data: 'ApellidosDisplay' },
                { data: 'FechaNacimientoDisplay' },
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
    };

    var _initialize = function () {
        $('#table_clientes').DataTable({
            "language": {
                "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
            }
        });
        $("#txt-fec-nac").datepicker();
        _bindEvents();
        _obtenerClientes();
    };

    return {
        initialize: _initialize
    };
};