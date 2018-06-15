var ProductoCanjeModule = function (config) {

    var _config = {
        urlObtenerProductosCanje: config.urlObtenerProductosCanje,
        urlObtenerCategorias: config.urlObtenerCategorias,
        urlObtenerProductoCanje: config.urlObtenerProductoCanje,
        urlRegistrar: config.urlRegistrar,
        urlEditar: config.urlEditar,
        urlEliminar: config.urlEliminar
    };

    var _obtenerCategorias = function () {
        $.ajax({
            type: "GET",
            url: _config.urlObtenerCategorias,
            success: function (data) {
                if (data.success) {
                    $.each(data.categorias, function (i, d) {
                        $('#select-categoria').append('<option value="' + d.Id + '">' + d.Descripcion + '</option>');
                    });
                    $.each(data.categorias, function (i, d) {
                        $('#select-categoria-registrar').append('<option value="' + d.Id + '">' + d.Descripcion + '</option>');
                    });
                    $.each(data.categorias, function (i, d) {
                        $('#select-categoria-editar').append('<option value="' + d.Id + '">' + d.Descripcion + '</option>');
                    });
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alertify.alert("Mensaje", thrownError);
            }
        });
        return false;
    };

    var _obtenerProductosCanje = function () {
        var tipoId = $("#select-tipo").val();
        var categoriaId = $("#select-categoria").val();

        $.ajax({
            type: "GET",
            url: _config.urlObtenerProductosCanje,
            data: { tipoId: tipoId, categoriaId: categoriaId },
            success: function (data) {
                if (data.success) {
                    _setProductosCanje(data.productos);
                }
                else {
                    alertify.alert("Mensaje", "No existen productos canje.");
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alertify.alert("Mensaje", thrownError);
            }
        });
        return false;
    };

    var _obtenerProductoCanje = function (id) {
        $.ajax({
            type: "GET",
            url: _config.urlObtenerProductoCanje,
            data: { id: id },
            success: function (data) {
                if (data.success) {
                    var producto = data.producto;
                    $("#txt-codigo-editar").val(producto.Id);
                    $("#txt-nombre-editar").val(producto.Nombre);
                    $("#txt-valor-canje-editar").val(producto.Puntos);
                    $("#select-tipo-editar").val(producto.TipoCanjeId);
                    $("#select-categoria-editar").val(producto.CategoriaId);
                    $("#txt-stock-editar").val(producto.Stock);
                    $("#txt-descripcion-editar").val(producto.Descripcion);
                    $("#txt-condiciones-editar").val(producto.Condiciones);
                }
                else {
                    alertify.alert("Mensaje", "No existe productos canje.");
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alertify.alert("Mensaje", thrownError);
            }
        });
        return false;
    };

    var _registrar = function () {
        var _nombre = $("#txt-nombre").val();
        var _valorCanje = $("#txt-valor-canje").val();
        var _tipo = $("#select-tipo-registrar").val();
        var _categoria = $("#select-categoria-registrar").val();
        var _stock = $("#txt-stock").val();
        var _descripcion = $("#txt-descripcion").val();
        var _condiciones = $("#txt-condiciones").val();

        $.ajax({
            type: "POST",
            url: _config.urlRegistrar,
            data: {
                Nombre: _nombre,
                Puntos: _valorCanje,
                TipoCanjeId: _tipo,
                Stock: _stock,
                CategoriaId: _categoria,
                Descripcion: _descripcion,
                Condiciones: _condiciones
            },
            success: function (data) {
                if (data.success) {
                    alertify.alert("Registro de Producto Canje", data.mensaje, function () {
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
        var _id = $("#txt-codigo-editar").val();
        var _nombre = $("#txt-nombre-editar").val();
        var _valorCanje = $("#txt-valor-canje-editar").val();
        var _tipo = $("#select-tipo-editar").val();
        var _categoria = $("#select-categoria-editar").val();
        var _stock = $("#txt-stock-editar").val();
        var _descripcion = $("#txt-descripcion-editar").val();
        var _condiciones = $("#txt-condiciones-editar").val();

        $.ajax({
            type: "POST",
            url: _config.urlEditar,
            data: {
                Id: _id,
                Nombre: _nombre,
                Puntos: _valorCanje,
                TipoCanjeId: _tipo,
                Stock: _stock,
                CategoriaId: _categoria,
                Descripcion: _descripcion,
                Condiciones: _condiciones
            },
            success: function (data) {
                if (data.success) {
                    alertify.alert("Edición de Producto Canje", data.mensaje, function () {
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

    var _eliminar = function () {
        var _id = $("#txt-codigo-eliminar").val();
        $.ajax({
            type: "POST",
            url: _config.urlEliminar,
            data: { id: _id },
            success: function (data) {
                if (data.success) {
                    alertify.alert("Eliminación de Producto Canje", data.mensaje, function () {
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
        var table = $('#table_deudas').DataTable();

        var rows = table
            .rows()
            .remove()
            .draw();
    };

    var _setProductosCanje = function (productos) {
        var table = $('#table_productos').DataTable({
            destroy: true,
            columns: [
                { data: 'Id' },
                { data: 'Nombre' },
                { data: 'Puntos' },
                { data: 'TipoDescripcion' },
                { data: 'CategoriaDescripcion' },
                { data: 'Stock' },
                {
                    data: null,
                    className: "center",
                    defaultContent: '<button id="btn-editar-producto" class="btn btn-default btn-sm" data-toggle="modal" data-target="#modal-editar" data-remote="false"> <span class="glyphicon glyphicon-pencil"></span></button> ' +
                        '<button id="btn-eliminar-producto" class="btn btn-default btn-sm" data-toggle="modal" data-target="#modal-eliminar" data-remote="false"> <span class="glyphicon glyphicon-remove"></span></button> '
                }
            ],
            order: [[0, "desc"]],
            data: productos,
            "language": {
                "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
            }
        });

        $('#table_productos tbody').on('click', '#btn-editar-producto', function () {
            var productoCanje = table.row($(this).parents('tr')).data();
            _obtenerProductoCanje(productoCanje.Id);
        });

        $('#table_productos tbody').on('click', '#btn-eliminar-producto', function () {
            var productoCanje = table.row($(this).parents('tr')).data();
            $("#txt-codigo-eliminar").val(productoCanje.Id);
        });
    };

    var _bindEvents = function () {

        $('#select-tipo').on('change', function () {
            _obtenerProductosCanje();
        });

        $('#select-categoria').on('change', function () {
            _obtenerProductosCanje();
        });

        $("#modal-registrar").on("show.bs.modal", function (e) {
            var link = $(e.relatedTarget);
            $(this).find(".modal-body").load(link.attr("href"));
        });

        $("#seccion-datos-producto").submit(function (e) {
            e.preventDefault();
            _registrar();
        });

        $("#seccion-datos-producto-editar").submit(function (e) {
            e.preventDefault();
            _editar();
        });

        $("#seccion-datos-producto-eliminar").submit(function (e) {
            e.preventDefault();
            _eliminar();
        });

    };

    var _initialize = function () {
        _bindEvents();
        _obtenerCategorias();
        _obtenerProductosCanje();
    };

    return {
        initialize: _initialize
    };
};