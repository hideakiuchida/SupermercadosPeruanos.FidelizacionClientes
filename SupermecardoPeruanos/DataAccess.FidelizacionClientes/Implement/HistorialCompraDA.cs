using Common.FidelizacionClientes;
using DataAccess.FidelizacionClientes.Interfaces;
using Model.FidelizacionClientes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.FidelizacionClientes.Implement
{
    public class HistorialCompraDA : DataConnection, IHistorialCompraDA
    {
        public List<HistorialCompra> GetByCliente(int id)
        {
            List<HistorialCompra> lista = new List<HistorialCompra>();

            SqlCommand command = new SqlCommand("[dbo].[HISTORIAL_COMPRA_Q01]", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@COD_CLIE", id));

            connection.Open();

            SqlDataReader dataReader = command.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    HistorialCompra historialCompra = new HistorialCompra();
                    historialCompra.Codigo = Convert.ToInt32(dataReader["COD_CLIE_HIST"].ToString());
                    Producto producto = new Producto();
                    producto.Id = Convert.ToInt32(dataReader["COD_PROD_HIST"].ToString());
                    historialCompra.Producto = producto;
                    Categoria categoria = new Categoria();
                    categoria.Id = Convert.ToInt32(dataReader["COD_CATE_HIST"].ToString());
                    historialCompra.ImporteCompra = Convert.ToDecimal(dataReader["IMP_COMP_HIST"].ToString());
                    lista.Add(historialCompra);
                }
            }

            connection.Close();

            return lista;
        }
    }
}
