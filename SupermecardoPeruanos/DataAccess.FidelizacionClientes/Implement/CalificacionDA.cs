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
                    calificacion.Codigo = Convert.ToInt32(dataReader["ID"]);
                    calificacion.CalificacionCrediticia = dataReader["CALIFICACION_CREDITICIA"].ToString();
                    calificacion.LineaCredito = Convert.ToDecimal(dataReader["LINEA_CREDITO"].ToString());
                    calificacion.SueldoCliente = Convert.ToDecimal(dataReader["sueldo_cliente"].ToString());
                    calificacion.OtrosIngresos = Convert.ToDecimal(dataReader["otros_ingresos_cliente"].ToString());
                    calificacion.Estado = dataReader["estado_calificacion_cliente"].ToString();
                }
            }

            connection.Close();

            return calificacion;
        }
    }
}
