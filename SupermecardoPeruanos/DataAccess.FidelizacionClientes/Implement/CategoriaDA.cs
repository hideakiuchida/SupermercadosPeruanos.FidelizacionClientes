using DataAccess.FidelizacionClientes.Interfaces;
using System;
using System.Collections.Generic;
using Model.FidelizacionClientes;
//using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Common.FidelizacionClientes;
using System.Data;

namespace DataAccess.FidelizacionClientes.Implement
{
    public class CategoriaDA : DataConnection, ICategoriaDA
    {
        public List<Categoria> GetAll()
        {
            List<Categoria> lista = new List<Categoria>();

            MySqlCommand command = new MySqlCommand("CATEGORIA_Q01", connection);
            command.CommandType = CommandType.StoredProcedure;

            connection.Open();

            MySqlDataReader dataReader = command.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    Categoria categoria = new Categoria();
                    categoria.Id = Convert.ToInt32(dataReader["ID_CATEGORIA"].ToString());
                    categoria.Descripcion = dataReader["NOMBRE_CATEGORIA"].ToString();
                    lista.Add(categoria);
                }
            }

            connection.Close();

            return lista;
        }   
    }
}
