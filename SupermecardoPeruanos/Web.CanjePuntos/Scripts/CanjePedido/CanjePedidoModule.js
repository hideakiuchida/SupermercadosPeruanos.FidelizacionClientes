var CanjePedidoModule = function () {
    var carritoCanje = JSON.parse(localStorage.getItem("carritoCanje"));
    
    loadGrid();
    function loadGrid() {

        $.ajax({
            type: "GET",
            url: 'http://localhost:52131/api/CarritoCanje/',
            //ids = parametro del controlador
            data: { ids: carritoCanje.idProductos },
            success: function (data) {
                localStorage.setItem("productos", JSON.stringify(data));
                listItems(data);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert("Mensaje", thrownError);
            }
        });
        return false;

        //});
    };

    function listItems(items) {
        var content = "";
        var sum = 0;

        $('#lstCarrito').html('');

        $.each(items, function (index, value) {
            //alert(value.prod);
            //Row
            content += '<div class="row">';
            //Img
            content += '<div class="col-md-2"><img src="' + value.Imagen + '" class="img-responsive w-25" /></div>'
            //content += '<div class="col-md-2"><img src="http://oswinet.org/wp-content/uploads/2017/06/empty.png" class="img-responsive w-25" /></div>'
            //Values Prod / Cod
            content += '<div class="col-md-5"><p>Producto: ' + value.Nombre + '</p>'
            content += '<p>Codigo: ' + value.Id + '</p></div>';
            //Form
            content += '<div class="col-md-4">';
            //input: Cantidad
            content += '<label for="txtCantidad" class="col-sm-4 col-form-label text-right">Cantidad:</label>';
            content += '<div class="col-sm-8"><input type="number" id="txtCantidad" class="form-control text-right" value="' + value.Cantidad + '" onchange="updatesum(this.value, ' + value.Id + ')" onkeypress="updatesum(this.value, ' + value.Id + ')" /></div>';
            //input: puntos
            content += '<label for="txtPuntos" class="col-sm-4 col-form-label text-right">Puntos:</label>';
            content += '<div class="col-sm-8"><input type="number" id="txtPuntos' + value.Id + '" class="form-control text-right" value="' + value.Puntos + '"  readonly/></div>';
            //input: stock
            content += '<label for="txtStock" class="col-sm-4 col-form-label text-right">Stock:</label>';
            content += '<div class="col-sm-8"><input type="number" id="txtStock" class="form-control text-right" value="' + value.Stock + '"  readonly/></div>';
            //End Form
            content += '</div>';
            //Button Delete
            content += '<div class="col-md-1"><button class="btn btn-primary" onclick="removeItem(' + value.Id + ')" >Eliminar</button></div>';
            //End Row
            content += '</div>';
            //Separator
            content += '<div class="row"><div class="col"><hr /></div></div>';

            sum += parseInt(value.Puntos);
        });

        $('#lstCarrito').append(content);

        $('#txtTotal').val(sum);
        var removeItem = function (id) {
            removeItemJS(carritoCanje.idProductos, id);
            //loadGrid();
            if (carritoCanje.idProductos.length == 0) {
                $('#lstCarrito').append('<div class="row text-center"><h1>El carrito de Productos esta vacio</h1></div>');
                $('#footerDiv').hide();
                $('#gotoConfirmDiv').hide();
            }
        }

        var removeItemJS = function (array, item) {
            for (var i in array) {
                if (array[i].Id == item) {
                    array.splice(i, 1);
                    break;
                }
            }
        }
        //function gotoNextStep() {
        //    var lnkGoTo = document.getElementById('lnkGoTo');
        //    lnkGoTo.href = '/canjepedido/confirmarpedido?car=' + JSON.stringify(carritoCanje);
        //}
        function updatesum(valt, id) {
            var sum = 0;

            $.each(productos, function (index, value) {
                if (value.Id == Id) {
                    value.Cantidad = parseInt(valt);
                }

                sum += parseInt(value.Cantidad);
            });

            $('#txtTotal').val(sum);
        }
    }

};