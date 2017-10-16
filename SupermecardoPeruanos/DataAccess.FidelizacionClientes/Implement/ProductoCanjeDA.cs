using Common.FidelizacionClientes;
using DataAccess.FidelizacionClientes.Interfaces;
using Model.FidelizacionClientes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.FidelizacionClientes.Implement
{
    public class ProductoCanjeDA : DataConnection, IProductoCanjeDA
    {
        public Producto Get(int id)
        {
            Producto producto = new Producto();

            SqlCommand command = new SqlCommand("[dbo].[PRODUCTO_Q01]", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@COD_PROD", id));

            connection.Open();

            SqlDataReader dataReader = command.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    producto.Id = Convert.ToInt32(dataReader["COD_PROD_CANJ"]);
                    producto.Descripcion = dataReader["NOM_PROD_CANJ"].ToString();
                    producto.Nombre = dataReader["DES_PROD_CANJ"].ToString();
                    producto.Imagen = dataReader["IMAGEN"].ToString();
                    decimal valorCanje = Convert.ToDecimal(dataReader["VAL_CANJ"].ToString());
                    producto.Puntos = Convert.ToInt32(valorCanje);
                    decimal stock = Convert.ToDecimal(dataReader["CAN_STOC_CANJ"].ToString());
                    producto.Condiciones = "COndiciones condiciones"; // dataReader["CON_PROD_CANJ"].ToString();
                    producto.Stock = Convert.ToInt32(stock); 
                }
            }

            connection.Close();

            return producto;
        }

        public CatalogoProducto GetOfertasPersonalizadas(int[] categorias, int cantidad, int pagina)
        {
            CatalogoProducto catalogoProducto = new CatalogoProducto();

            List<Producto> lista = new List<Producto>();

            int total = 0;

            SqlCommand command = new SqlCommand("[dbo].[CATALOGO_PERSONALIZADO_Q01]", connection);
            command.CommandType = CommandType.StoredProcedure;

            DataTable dtCategorias = new DataTable();
            DataColumn dcCategorias = new DataColumn("ID");
            dtCategorias.Columns.Add(dcCategorias);
            new List<int>(categorias).ForEach(dr => { DataRow d = dtCategorias.NewRow(); d[dcCategorias] = dr; dtCategorias.Rows.Add(d); });

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@CATEGORIAS";
            parameter.SqlDbType = SqlDbType.Structured;
            parameter.Value = dtCategorias;

            command.Parameters.Add(parameter);
            command.Parameters.Add(new SqlParameter("@CANTIDAD", cantidad));
            command.Parameters.Add(new SqlParameter("@PAGINA", pagina));

            connection.Open();

            SqlDataReader dataReader = command.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    Producto producto = new Producto();
                    producto.Id = Convert.ToInt32(dataReader["COD_PROD_CANJ"].ToString());
                    producto.Descripcion = dataReader["NOM_PROD_CANJ"].ToString();
                    producto.Nombre = dataReader["DES_PROD_CANJ"].ToString();
                    producto.Imagen = dataReader["IMAGEN"].ToString();
                    Categoria categoria = new Categoria();
                    categoria.Id = Convert.ToInt32(dataReader["COD_CATE_PROD"].ToString());
                    producto.Categoria = categoria;
                    total = Convert.ToInt32(dataReader["TOTAL"].ToString());
                    decimal valorCanje = Convert.ToDecimal(dataReader["VAL_CANJ"].ToString());
                    producto.Puntos = Convert.ToInt32(valorCanje);
                    lista.Add(producto);
                }
            }
            catalogoProducto.Productos = lista;
            catalogoProducto.Total = total;

            connection.Close();

            return catalogoProducto;
        }
    }
}
