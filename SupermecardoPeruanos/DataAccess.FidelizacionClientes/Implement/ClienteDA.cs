using Common.FidelizacionClientes;
using DataAccess.FidelizacionClientes.Interfaces;
using Model.FidelizacionClientes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccess.FidelizacionClientes.Implement
{
    public class ClienteDA : DataConnection, IClienteDA
    {
        public Cliente GetCliente(string numeroDocumento)
        {
            Cliente cliente = new Cliente();

            SqlCommand command = new SqlCommand("[dbo].[CLIENTE_Q01]", connection);
            command.CommandType = CommandType.StoredProcedure;  
            command.Parameters.Add(new SqlParameter("@NUM_DOCU_IDEN", numeroDocumento));

            connection.Open();

            SqlDataReader dataReader = command.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    cliente.Codigo = Convert.ToInt32(dataReader["COD_CLIE"]);
                    cliente.Nombre = dataReader["NOM_CLIE"].ToString();
                    cliente.ApellidoPaterno = dataReader["APE_PATE_CLIE"].ToString();
                    cliente.ApellidoMaterno = dataReader["APE_MATE_CLIE"].ToString();
                    cliente.TipoDocumentoIdentidad = dataReader["TIP_DOCU_IDEN"].ToString();
                    cliente.NumeroDocumentoIdentidad = dataReader["NUM_DOCU_IDEN"].ToString();
                    cliente.FechaNaciemiento = Convert.ToDateTime(dataReader["FEC_NACI"].ToString());
                    cliente.Sexo = dataReader["SEX_CLIE"].ToString();
                    cliente.Email = dataReader["EMA_CLIE"].ToString();
                    cliente.Direccion = dataReader["DIR_CLIE"].ToString();
                    cliente.TelefonoFijo = dataReader["TEL_FIJO_CLIE"].ToString();
                    cliente.TelefonoMovil = dataReader["TEL_MOVI_CLIE"].ToString();
                    cliente.SituacionLaboral = dataReader["SIT_LABO_CLIE"].ToString();
                    cliente.Estado = dataReader["EST_CLIE"].ToString();
                    cliente.IndicadorTarjeta = dataReader["IND_TARJ"].ToString();
                    cliente.IndicadorVeaClub = dataReader["IND_TARJ_VCLU"].ToString();
                }
            }

            connection.Close();

            return cliente;
        }
    }
}
