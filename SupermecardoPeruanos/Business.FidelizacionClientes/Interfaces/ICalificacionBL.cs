﻿using Model.FidelizacionClientes;

namespace Business.FidelizacionClientes.Interfaces
{
    public interface ICalificacionBL
    {
        Calificacion GetByCliente(int codigoCliente);
    }
}
