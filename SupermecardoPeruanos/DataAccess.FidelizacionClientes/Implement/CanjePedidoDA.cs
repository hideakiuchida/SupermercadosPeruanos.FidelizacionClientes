using System.Linq;
using DataAccess.FidelizacionClientes.Interfaces;
using Model.FidelizacionClientes;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Common.FidelizacionClientes;
using System;
using System.Data;
using System.Text;

namespace DataAccess.FidelizacionClientes.Implement
{
    public class CanjePedidoDA : DataConnection, ICanjePedidoDA
    {

        public List<Producto> ObtieneProductosCanje()
        {
            List<Producto> productos = new List<Producto>();

            MySqlCommand command = new MySqlCommand("Productos_Canje_Pedido", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();

            MySqlDataReader dataReader = command.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    Producto producto = new Producto();
                    producto.Id = Convert.ToInt32(dataReader["ID"]);
                    producto.Descripcion = dataReader["DES_PRODUCT"].ToString();
                    producto.Imagen = dataReader["IMG_RUTA"].ToString();
                    producto.Nombre = dataReader["DES_PRODUCT"].ToString();
                    decimal valorCanje = Convert.ToDecimal(dataReader["VALOR_CANJE"].ToString());
                    producto.Puntos = Convert.ToInt32(valorCanje);
                    decimal stock = Convert.ToDecimal(dataReader["STOCK"].ToString());
                    producto.Stock = Convert.ToInt32(stock);
                    producto.CategoriaId = Convert.ToInt32(dataReader["ID_CATEGORIA"]);
                    producto.TipoCanjeId = Convert.ToInt32(dataReader["TIPO_CANJE"]);
                    producto.CategoriaDescripcion = dataReader["DES_CATEGORIA"].ToString();
                    productos.Add(producto);
                }
            }

            connection.Close();

            return productos;
        }

        public void EliminarItem(int id)
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand("ELIMINAR_PRODUCTO_CANJE", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@PRODUCTO_ID", id);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void InsertarCanjePedido(CanjePedido canje)
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand("sp_insertar_producto_canje",connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("p_id_producto",canje.Productos.Id);
            command.Parameters.AddWithValue("p_id_cliente",canje.Cliente.NumeroDocumentoIdentidad);
            command.Parameters.AddWithValue("p_puntos", canje.CantidadPuntos);
            command.ExecuteNonQuery();
            connection.Close();

        }

        List<Producto> ICanjePedidoDA.ObtieneProductosCanje()
        {
            throw new NotImplementedException();
        }

        void ICanjePedidoDA.EliminarItem(int id)
        {
            throw new NotImplementedException();
        }

        void ICanjePedidoDA.InsertarCanjePedido(CanjePedido canje)
        {
            throw new NotImplementedException();
        }

        List<CanjePedido> ICanjePedidoDA.ListarCanjePedido(int id)
        {
            throw new NotImplementedException();
        }
    }
}
/*
 * 
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Productos_Canje_Pedido`()
Begin
	Select t1.id_producto_canje 'ID', t2.nom_prod_canj 'DES_PRODUCT', 
	t2.img_prod 'IMG_RUTA', t1.id_categoria_canje 'ID_CATEGORIA', 
	t3.nombre_categoria 'DES_CATEGORIA', t2.valor 'VALOR_CANJE', 
	(case when t2.tipo_canje = 1 then 'producto' else 'servicio' end)'TIPO_CANJE', 
	t2.condicion_canje 'CONDI_CANJE', t4.stock 'STOCK'
	from catalogo_canje t1 
	inner join producto_canje t2 on 
	( t2.id = t1.id_producto_canje and t2.id_categoria_producto = t1.id_categoria_canje )
	inner join categoria_canje t3 on 
	( t3.id = t2.id_categoria_producto )
	inner join stock_canje t4 on
	( t2.id = t4.id_stock_producto and t2.id_categoria_producto = t4.id_stock_categoria)
	Order by t1.id_categoria_canje, t1.id_producto_canje;

End$$
DELIMITER ;
 */
