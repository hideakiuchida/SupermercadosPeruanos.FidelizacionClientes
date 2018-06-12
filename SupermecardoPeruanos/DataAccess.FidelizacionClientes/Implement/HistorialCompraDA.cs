using Common.FidelizacionClientes;
using DataAccess.FidelizacionClientes.Interfaces;
using Model.FidelizacionClientes;
using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace DataAccess.FidelizacionClientes.Implement
{
    public class HistorialCompraDA : DataConnection, IHistorialCompraDA
    {
        public List<HistorialCompra> GetByCliente(int id)
        {
            List<HistorialCompra> lista = new List<HistorialCompra>();

            MySqlCommand command = new MySqlCommand("HISTORIAL_COMPRA_Q01", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new MySqlParameter("@P_ID_CLIENTE", id));

            connection.Open();

            MySqlDataReader dataReader = command.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    HistorialCompra historialCompra = new HistorialCompra();
                    Producto producto = new Producto();
                    Categoria categoria = new Categoria();
                    historialCompra.Codigo = Convert.ToInt32(dataReader["ID_CLIENTE_HISTORIAL"].ToString());
                    
                    producto.Id = Convert.ToInt32(dataReader["ID_PRODUCTO_HISTORIAL"].ToString()); 
                    categoria.Id = Convert.ToInt32(dataReader["ID_CATEGORIA_HISTORIAL"].ToString());

                    historialCompra.Producto = producto;
                    historialCompra.Categoria = categoria;

                    historialCompra.ImporteCompra = Convert.ToDecimal(dataReader["IMPORTE_COMPRA"].ToString());
                    lista.Add(historialCompra);
                }
            }

            connection.Close();

            return lista;
        }
    }
}
