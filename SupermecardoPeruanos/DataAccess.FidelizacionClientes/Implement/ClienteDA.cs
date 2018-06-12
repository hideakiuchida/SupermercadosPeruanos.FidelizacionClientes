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
        public void DeleteCliente(int codigo)
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand("CLIENTE_ELIMINADO", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@ID_CLIENTE", codigo);
            command.ExecuteNonQuery();

            connection.Close();
        }

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

        public void InsertCliente(Cliente cliente)
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand("INSERT_CLIENTE", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@NOMBRE_COMPLETO", cliente.Nombre);
            command.Parameters.AddWithValue("@APELLIDO_PATERNO", cliente.ApellidoPaterno);
            command.Parameters.AddWithValue("@APELLIDO_MATERNO", cliente.ApellidoMaterno);
            command.Parameters.AddWithValue("@TIPO_DOCUMENTO", cliente.TipoDocumentoIdentidad);
            command.Parameters.AddWithValue("@NUMERO_DOCUMENTO", cliente.NumeroDocumentoIdentidad);
            command.Parameters.AddWithValue("@FECHA_NACIMIENTO", Convert.ToDateTime(cliente.FechaNaciemiento));
            command.Parameters.AddWithValue("@SEXO", cliente.Sexo);
            command.Parameters.AddWithValue("@EMAIL", cliente.Email);
            command.Parameters.AddWithValue("@DIRECCION", cliente.Direccion);
            command.Parameters.AddWithValue("@TELEFONO_FIJO", cliente.TelefonoFijo);
            command.Parameters.AddWithValue("@TELEFONO_MOVI", cliente.TelefonoMovil);
            command.Parameters.AddWithValue("@SITUACION_LABORAL", cliente.SituacionLaboral);
            command.Parameters.AddWithValue("@ESTADO_CLIE",cliente.Estado );
            command.Parameters.AddWithValue("@INDICADOR_TARJETA", cliente.IndicadorTarjeta);
            command.Parameters.AddWithValue("@TARJETA_VCLUB",cliente.IndicadorVeaClub );
            command.ExecuteNonQuery();

            connection.Close();
        }

        public Cliente ListCliente()
        {
            Cliente cliente = new Cliente();

            MySqlCommand command = new MySqlCommand("LISTAR_CLIENTE", connection);
            command.CommandType = CommandType.StoredProcedure;
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

        public void UpdateCliente(Cliente cliente)
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand("CLIENTE_ACTUALIZADO", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ID_CLIENTE", cliente.Codigo);
            command.Parameters.AddWithValue("@NOMBRE_COMPLETO", cliente.Nombre);
            command.Parameters.AddWithValue("@APELLIDO_PATERNO", cliente.ApellidoPaterno);
            command.Parameters.AddWithValue("@APELLIDO_MATERNO", cliente.ApellidoMaterno);
            command.Parameters.AddWithValue("@TIPO_DOCUMENTO", cliente.TipoDocumentoIdentidad);
            command.Parameters.AddWithValue("@NUMERO_DOCUMENTO", cliente.NumeroDocumentoIdentidad);
            command.Parameters.AddWithValue("@FECHA_NACIMIENTO", Convert.ToDateTime(cliente.FechaNaciemiento));
            command.Parameters.AddWithValue("@SEXO", cliente.Sexo);
            command.Parameters.AddWithValue("@EMAIL", cliente.Email);
            command.Parameters.AddWithValue("@DIRECCION", cliente.Direccion);
            command.Parameters.AddWithValue("@TELEFONO_FIJO", cliente.TelefonoFijo);
            command.Parameters.AddWithValue("@TELEFONO_MOVI", cliente.TelefonoMovil);
            command.Parameters.AddWithValue("@SITUACION_LABORAL", cliente.SituacionLaboral);
            command.Parameters.AddWithValue("@ESTADO_CLIE", cliente.Estado);
            command.Parameters.AddWithValue("@INDICADOR_TARJETA", cliente.IndicadorTarjeta);
            command.Parameters.AddWithValue("@TARJETA_VCLUB", cliente.IndicadorVeaClub);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
