using System.Linq;
using DataAccess.FidelizacionClientes.Interfaces;
using Common.FidelizacionClientes;
using Model.FidelizacionClientes;
using System.Collections.Generic;
using System;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess.FidelizacionClientes.Implement
{
    public class AfiliacionDA : DataConnection, IAfiliacionDA
    {
        public AfiliacionTarjetaOH GetByCliente(int codigoCliente)
        {
            AfiliacionTarjetaOH afiliacionTarjetaOH = new AfiliacionTarjetaOH();
        
            SqlCommand command = new SqlCommand("[dbo].[TARJETAOH_Q01]", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@P_ID_CLIENTE", codigoCliente));

            connection.Open();

            SqlDataReader dataReader = command.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    afiliacionTarjetaOH.Codigo = Convert.ToInt32(dataReader["ID_TARJETA_CLIENTE"]);
                    afiliacionTarjetaOH.Tipo = dataReader["TIPO_TARJETA"].ToString();
                    afiliacionTarjetaOH.NumeroTarjeta = dataReader["NUMERO_TARJETA"].ToString();
                    afiliacionTarjetaOH.Bin = dataReader["BIN_TARJETA"].ToString();
                }
            }

            connection.Close();

            return afiliacionTarjetaOH;
        }

        public List<Infocorp> GetInfocorpByCliente(int codigoCliente)
        {
            List<Infocorp> lista = new List<Infocorp>();

            SqlCommand command = new SqlCommand("[dbo].[INFOCORP_Q03]", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@P_ID_CLIENTE", codigoCliente));

            connection.Open();

            SqlDataReader dataReader = command.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    Infocorp infocorp = new Infocorp();
                    infocorp.EntidadFinanciera = dataReader["ENTIDAD_FINANCIERA"].ToString();
                    infocorp.MontoDeuda = Convert.ToDecimal(dataReader["IMPORTE_DEUDA"].ToString());
                    infocorp.CalificacionSBS = dataReader["CALIFICACION_SBSS"].ToString();
                    lista.Add(infocorp);
                }
            }

            connection.Close();

            return lista;
        }

        public void InsertCliente(int codigoCliente, string numero, string tipo)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("[dbo].[TARJETAOH_SOLICITUD_I02]", connection);
            command.CommandType = CommandType.StoredProcedure;

            
            command.Parameters.AddWithValue("@P_ID_CLIENTE", codigoCliente);
            command.Parameters.AddWithValue("@P_TIP_TARJ", tipo);
            command.Parameters.AddWithValue("@P_NUM_TARJ", Convert.ToInt64(numero));
            
            command.ExecuteNonQuery();

            connection.Close();

        }

        public void UpdateSolicitudDes(int numeroDocumento)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("[dbo].[SOLICITUD_DESAPROBADAI03]", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@P_ID_CLIENTE", numeroDocumento);
            command.ExecuteNonQuery();

            connection.Close();
        }

        public string consultarEstadoSol(string numeroDocumento)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("[dbo].[ESTADO_SOLICITUD]", connection);
            command.CommandType = CommandType.StoredProcedure;
            string Estado = String.Empty;

            command.Parameters.AddWithValue("@P_NUM_DOCU_IDEN", numeroDocumento);
            command.ExecuteNonQuery();

            SqlDataReader dataReader = command.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    Estado = dataReader["ESTADO_SOLICITUD"].ToString();   
                }
            }

            return Estado;
        }

    }
}
