using Common.FidelizacionClientes;
using DataAccess.FidelizacionClientes.Interfaces;
using Model.FidelizacionClientes;
using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Linq;

namespace DataAccess.FidelizacionClientes.Implement
{
    public class ProductoCanjeDA : DataConnection, IProductoCanjeDA
    {
        public Producto Get(int id)
        {
            Producto producto = new Producto();

            MySqlCommand command = new MySqlCommand("PRODUCTO_Q01", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new MySqlParameter("@P_ID_PRODUCTO", id));

            connection.Open();

            MySqlDataReader dataReader = command.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    producto.Id = Convert.ToInt32(dataReader["ID"]);
                    producto.Nombre = dataReader["NOM_PROD_CANJ"].ToString();
                    producto.Descripcion = dataReader["DESCRIPCION_PRODUCTO"].ToString();
                    producto.Imagen = dataReader["imagen"].ToString();
                    decimal valorCanje = Convert.ToDecimal(dataReader["VALOR"].ToString());
                    producto.Puntos = Convert.ToInt32(valorCanje);
                    decimal stock = Convert.ToDecimal(dataReader["STOCK"].ToString());
                    producto.Stock = Convert.ToInt32(stock);
                    producto.CategoriaId = Convert.ToInt32(dataReader["ID_CATEGORIA_PRODUCTO"]);
                    producto.TipoCanjeId = Convert.ToInt32(dataReader["TIPO_CANJE"]);
                    producto.Condiciones = dataReader["CONDICION_CANJE"].ToString(); 
                }
            }

            connection.Close();

            return producto;
        }
        public List<Producto> GetProductosCarritoCanje(int[] productos)
        {
            List<Producto> lstProductos = new List<Producto>();
            if (productos == null || productos.Length == 0)
                return lstProductos;
            string productosString = String.Empty;
            if (productos.Length>2)
            {
                for (int i = 0; i < productos.Length; i++)
                {
                    if (i == (productos.Length - 1))
                        productosString += productos[i].ToString();
                    else
                        productosString += productos[i].ToString()+ ",";
                }
                
            }
            if (productos.Length == 2)
                productosString = productos[0].ToString() + "," + productos[1].ToString();
            if (productos.Length == 1)
                productosString = productos[0].ToString();

            MySqlCommand command = new MySqlCommand("sp_consulta_producto_codigo", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new MySqlParameter("@productos", productosString));
            connection.Open();
            MySqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    Producto producto = new Producto();
                    producto.Id = Convert.ToInt32(dataReader["ID"].ToString());
                    producto.Nombre = dataReader["NOM_PROD_CANJ"].ToString();
                    producto.Imagen = dataReader["imagen"].ToString();
                    decimal valorCanje = Convert.ToDecimal(dataReader["valor"].ToString());
                    producto.Puntos = Convert.ToInt32(valorCanje);
                    decimal stock = Convert.ToDecimal(dataReader["stock"].ToString());
                    producto.Stock = Convert.ToInt32(stock);
                    lstProductos.Add(producto);
                }
            }
            connection.Close();

            return lstProductos;
        }

        public CatalogoProducto GetOfertasPersonalizadas(int[] categorias, int cantidad, int pagina)
        {
            CatalogoProducto catalogoProducto = new CatalogoProducto();

            List<Producto> lista = new List<Producto>();

            string categoriasString = String.Empty;
            if (categorias.Length > 2)
            {
                for (int i = 0; i < categorias.Length; i++)
                {
                    if (i == (categorias.Length - 1))
                        categoriasString += categorias[i].ToString();
                    else
                        categoriasString += categorias[i].ToString() + ",";
                }
            }
            if(categorias.Length == 2)
                categoriasString = categorias[0].ToString() + "," + categorias[1].ToString();
            if (categorias.Length == 1)
                categoriasString = categorias[0].ToString();

            MySqlCommand command = new MySqlCommand("CATALOGO_PERSONALIZADO_Q01", connection);
            command.CommandType = CommandType.StoredProcedure;

            DataTable dtCategorias = new DataTable();
            DataColumn dcCategorias = new DataColumn("ID");
            dtCategorias.Columns.Add(dcCategorias);
            new List<int>(categorias).ForEach(dr => { DataRow d = dtCategorias.NewRow(); d[dcCategorias] = dr; dtCategorias.Rows.Add(d); });

            command.Parameters.Add(new MySqlParameter("@CATEGORIAS", categoriasString));
            command.Parameters.Add(new MySqlParameter("@CANTIDAD", cantidad));
            command.Parameters.Add(new MySqlParameter("@PAGINA", pagina));

            connection.Open();

            MySqlDataReader dataReader = command.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    Producto producto = new Producto();
                    producto.Id = Convert.ToInt32(dataReader["ID"].ToString());
                    producto.Descripcion = dataReader["NOM_PROD_CANJ"].ToString();
                    producto.Nombre = dataReader["descripcion_producto"].ToString();
                    //producto.Imagen = dataReader["imagen"].ToString();
                    producto.Imagen = dataReader["imagen"].ToString();
                    Categoria categoria = new Categoria();
                    categoria.Id = Convert.ToInt32(dataReader["id_categoria_producto"].ToString());
                    producto.Categoria = categoria;
                    decimal valorCanje = Convert.ToDecimal(dataReader["valor"].ToString());
                    producto.Puntos = Convert.ToInt32(valorCanje);
                    lista.Add(producto);
                }
            }
            catalogoProducto.Productos = lista;
            catalogoProducto.Total = catalogoProducto.Productos.Count;

            connection.Close();

            return catalogoProducto;
        }

        public List<Producto> GetProductosCanje()
        {
            List<Producto> productos = new List<Producto>();

            MySqlCommand command = new MySqlCommand("LISTAR_PRODUCTOS", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();

            MySqlDataReader dataReader = command.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    Producto producto = new Producto();
                    producto.Id = Convert.ToInt32(dataReader["ID"]);
                    producto.Descripcion = dataReader["NOM_PROD_CANJ"].ToString();
                    producto.Nombre = dataReader["DESCRIPCION_PRODUCTO"].ToString();
                    decimal valorCanje = Convert.ToDecimal(dataReader["VALOR"].ToString());
                    producto.Puntos = Convert.ToInt32(valorCanje);
                    decimal stock = Convert.ToDecimal(dataReader["STOCK"].ToString());
                    producto.Stock = Convert.ToInt32(stock);
                    producto.CategoriaId = Convert.ToInt32(dataReader["ID_CATEGORIA_PRODUCTO"]);
                    producto.TipoCanjeId = Convert.ToInt32(dataReader["TIPO_CANJE"]);
                    producto.CategoriaDescripcion = dataReader["NOMBRE_CATEGORIA"].ToString();
                    productos.Add(producto);
                }
            }

            connection.Close();

            return productos;
        }

        public void Insertar(Producto producto)
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand("INSERTAR_PRODUCTO_CANJE", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@NOM_PROD_CANJ", producto.Nombre);
            command.Parameters.AddWithValue("@DESCRIPCION_PRODUCTO", producto.Descripcion);
            command.Parameters.AddWithValue("@VALOR", producto.Puntos);
            command.Parameters.AddWithValue("@ID_CATEGORIA_PRODUCTO", producto.CategoriaId);
            command.Parameters.AddWithValue("@TIPO_CANJE", producto.TipoCanjeId);
            command.Parameters.AddWithValue("@STOCK", producto.Stock);
            command.Parameters.AddWithValue("@CONDICION_CANJE", producto.Condiciones);
            command.ExecuteNonQuery();

            connection.Close();
        }

        public void Update(Producto producto)
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand("ACTUALIZAR_PRODUCTO_CANJE", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ID", producto.Id);
            command.Parameters.AddWithValue("@NOM_PROD_CANJ", producto.Nombre);
            command.Parameters.AddWithValue("@DESCRIPCION_PRODUCTO", producto.Descripcion);
            command.Parameters.AddWithValue("@VALOR", producto.Puntos);
            command.Parameters.AddWithValue("@ID_CATEGORIA_PRODUCTO", producto.CategoriaId);
            command.Parameters.AddWithValue("@TIPO_CANJE", producto.TipoCanjeId);
            command.Parameters.AddWithValue("@STOCK", producto.Stock);
            command.Parameters.AddWithValue("@CONDICION_CANJE", producto.Condiciones);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Eliminar(int id)
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand("ELIMINAR_PRODUCTO_CANJE", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@PRODUCTO_ID", id);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
