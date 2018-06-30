using Business.FidelizacionClientes.Interfaces;
using System;
using Model.FidelizacionClientes;
using DataAccess.FidelizacionClientes.Implement;
using DataAccess.FidelizacionClientes.Interfaces;
using System.Collections.Generic;

namespace Business.FidelizacionClientes.Implement
{
    public class AfiliacionBL : IAfiliacionBL
    {
        private IAfiliacionDA afiliacionDA;

        public AfiliacionBL()
        {
            afiliacionDA = new AfiliacionDA();
        }

        public AfiliacionTarjetaOH GetByCliente(int codigoCliente)
        {
            return afiliacionDA.GetByCliente(codigoCliente);
        }

        public List<Infocorp> GetInfocorpByCliente(int codigoCliente)
        {
            return afiliacionDA.GetInfocorpByCliente(codigoCliente);
        }
        public void InsertCliente(int codigoCliente, string numero, string tipo)
        {
           afiliacionDA.InsertCliente(codigoCliente, numero, tipo);
        }
        public void UpdateSolicitudDes(int numeroDocumento)
        {
            afiliacionDA.UpdateSolicitudDes(numeroDocumento);
        }

        public string ConsultarEstadoSol(string numeroDocumento)
        {
            return afiliacionDA.consultarEstadoSol(numeroDocumento);
        }


    }
}
