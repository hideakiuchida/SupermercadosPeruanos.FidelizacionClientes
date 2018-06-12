using Common.FidelizacionClientes;
using DataAccess.FidelizacionClientes.Interfaces;
using Model.FidelizacionClientes;
using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.SqlClient;
using System.Linq;
using MySql.Data.MySqlClient;

namespace DataAccess.FidelizacionClientes.Implement
{
    public class ClienteDA : DataConnection, IClienteDA
    {
        public Cliente GetCliente(string numeroDocumento)
        {
            Cliente cliente = new Cliente();

            MySqlCommand command = new MySqlCommand("CLIENTE_Q01",  connection);
            command.CommandType = CommandType.StoredProcedure;  
            command.Parameters.Add(new MySqlParameter("@P_DOCU_IDEN", numeroDocumento));

            connection.Open();

            MySqlDataReader dataReader = command.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    cliente.Codigo = Convert.ToInt32(dataReader["ID_CLIENTE"]);
                    cliente.Nombre = dataReader["NOMBRE_COMPLETO"].ToString();
                    cliente.ApellidoPaterno = dataReader["APELLIDO_PATERNO"].ToString();
                    cliente.ApellidoMaterno = dataReader["APELLIDO_MATERNO"].ToString();
                    cliente.TipoDocumentoIdentidad = dataReader["TIPO_DOCUMENTO"].ToString();
                    cliente.NumeroDocumentoIdentidad = dataReader["NUMERO_DOCUMENTO"].ToString();
                    cliente.FechaNaciemiento = Convert.ToDateTime(dataReader["FECHA_NACIMIENTO"].ToString());
                    cliente.Sexo = dataReader["SEXO"].ToString();
                    cliente.Email = dataReader["EMAIL"].ToString();
                    cliente.Direccion = dataReader["DIRECCION"].ToString();
                    cliente.TelefonoFijo = dataReader["TELEFONO_FIJO"].ToString();
                    cliente.TelefonoMovil = dataReader["TELEFONO_MOVI"].ToString();
                    cliente.SituacionLaboral = dataReader["SITUACION_LABORAL"].ToString();
                    cliente.Estado = dataReader["ESTADO_CLIE"].ToString();
                    cliente.IndicadorTarjeta = dataReader["INDICADOR_TARJETA"].ToString();
                    cliente.IndicadorVeaClub = dataReader["TARJETA_VCLUB"].ToString();
                }
            }

            connection.Close();

            return cliente;
        }
    }
}
