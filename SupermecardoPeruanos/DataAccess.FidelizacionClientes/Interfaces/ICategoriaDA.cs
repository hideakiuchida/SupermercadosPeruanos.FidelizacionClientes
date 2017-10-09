using Model.FidelizacionClientes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.FidelizacionClientes.Interfaces
{
    public interface ICategoriaDA
    {
        List<Categoria> GetAll();
    }
}
