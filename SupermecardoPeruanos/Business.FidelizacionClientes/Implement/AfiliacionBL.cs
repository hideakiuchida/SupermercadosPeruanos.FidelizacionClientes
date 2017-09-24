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

        public AfiliacionTarjetaOH GetByCliente(string numeroDocumento)
        {
            return afiliacionDA.GetByCliente(numeroDocumento);
        }

        public List<Infocorp> GetInfocorpByCliente(string numeroDocumento)
        {
            return afiliacionDA.GetInfocorpByCliente(numeroDocumento);
        }
    }
}
