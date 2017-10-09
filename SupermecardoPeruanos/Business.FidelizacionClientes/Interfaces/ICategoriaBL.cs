using Model.FidelizacionClientes;
using System.Collections.Generic;

namespace Business.FidelizacionClientes.Interfaces
{
    public interface ICategoriaBL
    {
        List<Categoria> GetAll();
    }
}
