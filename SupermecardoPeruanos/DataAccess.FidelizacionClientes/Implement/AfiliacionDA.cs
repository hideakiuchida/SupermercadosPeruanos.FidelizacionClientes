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
    public class AfiliacionDA : IAfiliacionDA
    {
        private SqlConnection connection;

        public AfiliacionDA()
        {
            connection = DataConnection.GetConnection();
        }
        public AfiliacionTarjetaOH GetByCliente(int codigoCliente)
        {
            AfiliacionTarjetaOH afiliacionTarjetaOH = new AfiliacionTarjetaOH();
        
            SqlCommand command = new SqlCommand("[dbo].[TARJETAOH_Q01]", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@COD_CLIE", codigoCliente));

            connection.Open();

            SqlDataReader dataReader = command.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    afiliacionTarjetaOH.Codigo = Convert.ToInt32(dataReader["COD_TARJ"]);
                    afiliacionTarjetaOH.Tipo = dataReader["TIP_TARJ"].ToString();
                    afiliacionTarjetaOH.NumeroTarjeta = dataReader["NUM_TARJ"].ToString();
                    afiliacionTarjetaOH.Bin = dataReader["BIN_TARJ"].ToString();
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
            command.Parameters.Add(new SqlParameter("@COD_CLIE", codigoCliente));

            connection.Open();

            SqlDataReader dataReader = command.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    Infocorp infocorp = new Infocorp();
                    infocorp.EntidadFinanciera = dataReader["ENT_FINA_INFO"].ToString();
                    infocorp.MontoDeuda = Convert.ToDecimal(dataReader["IMP_MONT_INFO"].ToString());
                    infocorp.CalificacionSBS = dataReader["CAL_SBSS_INFO"].ToString();
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

            
            command.Parameters.AddWithValue("@COD_CLIE", codigoCliente);
            command.Parameters.AddWithValue("@TIP_TARJ", tipo);
            command.Parameters.AddWithValue("@NUM_TARJ", numero);
            
            command.ExecuteNonQuery();


            connection.Close();


        }

        public void UpdateSolicitudDes(int numeroDocumento)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("[dbo].[SOLICITUD_DESAPROBADAI03]", connection);
            command.CommandType = CommandType.StoredProcedure;


            command.Parameters.AddWithValue("@COD_CLIE", numeroDocumento);
            command.ExecuteNonQuery();

            connection.Close();


        }

        public string consultarEstadoSol(string numeroDocumento)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("[dbo].[ESTADO_SOLICITUD]", connection);
            command.CommandType = CommandType.StoredProcedure;
            string Estado = String.Empty;


            command.Parameters.AddWithValue("@NUM_DOCU_IDEN", numeroDocumento);
            command.ExecuteNonQuery();

            SqlDataReader dataReader = command.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    Estado = dataReader["EST_SOLI_AFIL"].ToString();   
                }
            }

            return Estado;


        }

    }
}
