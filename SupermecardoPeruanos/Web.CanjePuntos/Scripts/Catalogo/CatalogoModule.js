var CatalogoModule = function (config) {

    var _config = {
       // urlBuscarAfiliacionCliente: config.urlBuscarAfiliacionCliente
    };

    var _filtros = {Categoria: 0, Puntos: 0};

    var _consultarCatalogo = function () {
        $.ajax({
            type: "GET",
            url: _config.urlBuscarAfiliacionCliente,
            data: _filtros,
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

    var _loadCategories = function () {
        /*$.ajax({
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

        return false;*/
        var data = {
            categories: [{ Id: 1, Descripcion: "Tecnología"},
                { Id: 2, Descripcion: "Entretenimiento" },
                { Id: 3, Descripcion: "Cocina" },
                { Id: 4, Descripcion: "Servicio de Taxi" }]
        };
        _drawFilters(data.categories, 'ol#lista-categoria');
    };

    var _loadPuntos = function () {
        /*$.ajax({
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

        return false;*/
        var data = {
            puntos: [{ Id: 1, Descripcion: "0-500" },
                { Id: 2, Descripcion: "501-1000"}, { Id: 3, Descripcion: "1001-1500" },
                { Id: 4, Descripcion: "1501-2000" }, { Id: 5, Descripcion: "2001-2500" },
                { Id: 6, Descripcion: "<=2501" }]
        };
        _drawFilters(data.puntos, 'ol#lista-puntos');
    };

    var _drawFilters = function (items, element) {
        if (items != null)
            items.forEach(function (item) {
                $('<li />').appendTo(element).html(item.Descripcion).val(item.Id);
            });
    } 

    var _bindEvents = function () {
    };

    var _initControls = function () {
        $(function () {
            $("#tabs").tabs();
            $("#lista-categoria").selectable({
                selected: function () {
                    $(".ui-selected", this).each(function () {
                        _filtros.Categoria = $(this).val();
                        console.log(".ui-selected - ID: " + _filtros.Categoria);
                    });
                     // _consultarCatalogo();
                }
            });
            $("#lista-puntos").selectable({
                selected: function () {
                    $(".ui-selected", this).each(function () {
                        _filtros.Puntos = $(this).val();
                        console.log(".ui-selected - ID: " + _filtros.Puntos);
                    });
                    // _consultarCatalogo();
                }
            });
            //_consultarCatalogo();
        });
    };

    var _loadControls = function () {
        _loadCategories();
        _loadPuntos();
    };

    var _initialize = function () { 
        _initControls();
        _bindEvents();
        _loadControls();
    };

    return {
        initialize: _initialize
    };
};