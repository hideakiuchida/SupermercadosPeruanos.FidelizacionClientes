﻿var CatalogoModule = function (config) {

    var _config = {
       // urlBuscarAfiliacionCliente: config.urlBuscarAfiliacionCliente
    };

    var _filtros = {Categoria: 0, Puntos: 0};
    var _orden = { value: 0 };
    var _paginaActual = 1;

    var _consultarCatalogo = function (pagina) {

        var data = {
            productos: [
                {
                    imagen: "Content/Images/pic_mountain.jpg",
                    categoria: 1,
                    puntos: 1000
                },
                {
                    imagen: "Content/Images/pic_mountain.jpg",
                    categoria: 2,
                    puntos: 2000
                },
                {
                    id: 1,
                    imagen: "Content/Images/pic_mountain.jpg",
                    categoria: 2,
                    puntos: 3000
                },
                {
                    imagen: "Content/Images/pic_mountain.jpg",
                    categoria: 3,
                    puntos: 4000
                },
                {
                    imagen: "Content/Images/pic_mountain.jpg",
                    categoria: 4,
                    puntos: 5000
                },
                {
                    imagen: "Content/Images/pic_mountain.jpg",
                    categoria: 4,
                    puntos: 6000
                },
                {
                    imagen: "Content/Images/pic_mountain.jpg",
                    categoria: 4,
                    puntos: 7000
                },
                {
                    imagen: "Content/Images/pic_mountain.jpg",
                    categoria: 1,
                    puntos: 8000
                },
                {
                    imagen: "Content/Images/pic_mountain.jpg",
                    categoria: 1,
                    puntos: 1000
                },
                {
                    imagen: "Content/Images/pic_mountain.jpg",
                    categoria: 2,
                    puntos: 2000
                },
                {
                    id: 1,
                    imagen: "Content/Images/pic_mountain.jpg",
                    categoria: 2,
                    puntos: 3000
                },
                {
                    imagen: "Content/Images/pic_mountain.jpg",
                    categoria: 3,
                    puntos: 4000
                },
                {
                    imagen: "Content/Images/pic_mountain.jpg",
                    categoria: 4,
                    puntos: 5000
                },
                {
                    imagen: "Content/Images/pic_mountain.jpg",
                    categoria: 4,
                    puntos: 6000
                },
                {
                    imagen: "Content/Images/pic_mountain.jpg",
                    categoria: 4,
                    puntos: 7000
                },
                {
                    imagen: "Content/Images/pic_mountain.jpg",
                    categoria: 1,
                    puntos: 8000
                },

                {
                    imagen: "Content/Images/pic_mountain.jpg",
                    categoria: 1,
                    puntos: 8000
                }
            ],
            total: 17
        };

        var filteredProducts = _filterOrderProducts(data.productos);
        _drawProductos(filteredProducts);
        _drawPagination(filteredProducts.length, pagina);
      /*  $.ajax({
            type: "GET",
            url: _config.urlBuscarAfiliacionCliente,
            data: _filtros,
            success: function (data) {
                if (data.success) {
                    _drawProductos(data.produtos)
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
    };

    var _consultarProductoDetalle = function () {
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
        var producto = {
            imagen: "Content/Images/pic_mountain.jpg",
            stock: 1,
            puntos: 1000,
            condiciones: "Condiciones condiciones condiciones condiciones condiciones condiciones condiciones condiciones condiciones v condiciones condiciones condiciones condiciones"
        };

        _setProductoDetalle(producto);
    };

    var _setProductoDetalle = function (producto) {
        $("#imgImagenProducto").attr('src', producto.imagen);
        $("#txtPuntos").val(producto.puntos);
        $("#txtStock").val(producto.stock);
        $("#lblCondiciones").val(producto.condiciones);
    };

    var _agregarProducto = function () {
    };

    var _filterOrderProducts = function (productos) {
        if (productos == null || productos.length == 0)
            return;

        if (_filtros.Categoria != 0)
            productos = productos.filter(p => p.categoria == _filtros.Categoria);
        if (_filtros.Puntos != 0) {
            switch (_filtros.Puntos) {
                case 1:
                    productos = productos.filter(p => p.puntos >= 0 && p.puntos <= 500);
                    break;
                case 2:
                    productos = productos.filter(p => p.puntos >= 501 && p.puntos <= 1000);
                    break;
                case 3:
                    productos = productos.filter(p => p.puntos >= 1001 && p.puntos <= 1500);
                    break;
                case 4:
                    productos = productos.filter(p => p.puntos >= 1501 && p.puntos <= 2000);
                    break;
                case 5:
                    productos = productos.filter(p => p.puntos >= 2001 && p.puntos <= 2500);
                    break;
                case 6:
                    productos = productos.filter(p => p.puntos >= 2501);
                    break;
                default:
            }

        }

        if (_orden.value == 1)
            productos = productos.sort(function (a, b) { return a.puntos - b.puntos });
        if (_orden.value == 2)
            productos = productos.reverse(function (a, b) { return b.puntos - a.puntos });

        return productos;
    };

    var _drawProductos = function (productos) {
        $("#gridview-productos").empty();

        if (productos == null || productos.length == 0)
            return;

        var countItems = 0;

        productos.forEach(function (item, index) {
            if (countItems == 0)
                $("#gridview-productos").append("<div id='first-row' class='row'></div>");
            if ((countItems + 1) % 4 == 0)
                $("#gridview-productos").append("<div id='second-row' class='row'></div>");

            if (countItems < 8) {
                if (countItems < 4)
                    $("#first-row").append("<div id='" + index + "-producto' class='col-md-3'></div>");
                else
                    $("#second-row").append("<div id='" + index + "-producto' class='col-md-3'></div>");

                var btnDetalle = "btnDetalle-" + index;
                var btnAgregar = "btnAgregar-" + index;

                $("#" + index + "-producto").append("<img src='" + item.imagen + "' style='width:100%;height: 100%;padding: 2px; text-align:center'>");
                $("#" + index + "-producto").append("<div style='padding:2px;text-align:center'><label>Puntos: <span> " + item.puntos + "</span></label></div>");
                $("#" + index + "-producto").append("<div style='padding:2px;text-align:center'><label>Categoria: <span> " + item.categoria + "</span></label></div>");
                $("#" + index + "-producto").append("<div style='padding:2px;text-align:center'><button id='" + btnDetalle + "' style='width: 100%' type='button' class='btn btn-info' data-toggle='modal' data-target='#modal-producto' data-remote='false'>Ver Detalle</button></div>");
                $("#" + index + "-producto").append("<div style='padding:2px;text-align:center'><button id='" + btnAgregar + "' style='width: 100%' type='button' class='btn btn-success'>Agregar a Carrito</button></div>");

                $(btnDetalle).click(function () { _consultarProductoDetalle()});
                $(btnAgregar).click(function () { _agregarProducto()});
            }
            countItems++;

        });


    };

    var _drawPagination = function (total, pagina) {
        $("#pagination").empty();

        var itemForPage = 8;
        var cantidadPorPagina = total / itemForPage;
        var paginas = Math.trunc(cantidadPorPagina);
        if (cantidadPorPagina > paginas)
            paginas = paginas + 1;

        if (paginas > 0) {
            $("#pagination").append("<a href='#'>&laquo;</a>");
            for (var i = 0; i < paginas; i++) {
                var numeroPagina = (i + 1);
                var element = "<a id='pagina-" + numeroPagina +"' href='#' value='" + numeroPagina + "'>" + numeroPagina + "</a>";
                $("#pagination").append(element);
                $('#pagina-' + numeroPagina).click(function () {
                    _paginaActual = $(this).attr('value');
                    _consultarCatalogo(_paginaActual);
                });                
                if (pagina == numeroPagina)
                    $('#pagina-' + numeroPagina).toggleClass('active');
                else 
                    $('#pagina-' + numeroPagina).removeClass('active');
            }
            $("#pagination").append("<a href='#'>&laquo;</a>");
          
        }
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
                { Id: 6, Descripcion: ">=2501" }]
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
        $('#select-orden').on('change', function () {
            var selected = $(this).find("option:selected").val();
            _orden.value = selected;
            _consultarCatalogo(_paginaActual);
        });
    };

    var _initControls = function () {
        $(function () {
            $("#tabs").tabs();
            $("#lista-categoria").selectable({
                selected: function (event, ui) {
                    if ($(ui.selected).hasClass('selectedfilter')) {
                        $(ui.selected).removeClass('selectedfilter');
                        $(ui.selected).removeClass('ui-selected');
                        _filtros.Categoria = 0;
                    } else {
                        $(ui.selected).addClass('selectedfilter');
                        $(".ui-selected", this).each(function () {
                            _filtros.Categoria = $(this).val();
                        });
                    }               
                    _consultarCatalogo(_paginaActual);
                }
            });
            $("#lista-puntos").selectable({
                selected: function (event, ui) {
                    if ($(ui.selected).hasClass('selectedfilter')) {
                        $(ui.selected).removeClass('selectedfilter');
                        $(ui.selected).removeClass('ui-selected');
                        _filtros.Categoria = 0;
                    } else {
                        $(ui.selected).addClass('selectedfilter');
                        $(".ui-selected", this).each(function () {
                            _filtros.Puntos = $(this).val();
                        });
                    }
                    _consultarCatalogo(_paginaActual);
                }
            });
            _consultarCatalogo(_paginaActual);
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