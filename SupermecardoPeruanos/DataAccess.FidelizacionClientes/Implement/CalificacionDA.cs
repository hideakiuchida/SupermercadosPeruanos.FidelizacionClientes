using System.Linq;
using DataAccess.FidelizacionClientes.Interfaces;
using Model.FidelizacionClientes;
using System.Collections.Generic;
//using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Common.FidelizacionClientes;
using System;
using System.Data;

namespace DataAccess.FidelizacionClientes.Implement
{
    public class CalificacionDA : DataConnection, ICalificacionDA
    {
        public Calificacion GetByCliente(int codigoCliente)
        {
            Calificacion calificacion = new Calificacion();

            MySqlCommand command = new MySqlCommand("CALIFICACIONCLIENTE_Q02", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new MySqlParameter("@P_ID_CLIENTE", codigoCliente));

            connection.Open();

            MySqlDataReader dataReader = command.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    calificacion.Codigo = Convert.ToInt32(dataReader["ID_CALIFI_CLIE"]);
                    calificacion.CalificacionCrediticia = dataReader["CAL_CRED"].ToString();
                    calificacion.LineaCredito = Convert.ToDecimal(dataReader["LIN_CRED"].ToString());
                    calificacion.SueldoCliente = Convert.ToDecimal(dataReader["SUE_CLIE"].ToString());
                    calificacion.OtrosIngresos = Convert.ToDecimal(dataReader["OTR_INGR_CLIE"].ToString());
                    calificacion.Estado = dataReader["EST_CALI_CLIE"].ToString();
                }
            }

            connection.Close();

            return calificacion;
        }
    }
}
