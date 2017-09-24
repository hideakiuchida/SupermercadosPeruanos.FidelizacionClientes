﻿using Model.FidelizacionClientes;
using System.Collections.Generic;

namespace Business.FidelizacionClientes.Interfaces
{
    public interface IAfiliacionBL
    {
        AfiliacionTarjetaOH GetByCliente(string numeroDocumento);
        List<Infocorp> GetInfocorpByCliente(string numeroDocumento);
    }
}
