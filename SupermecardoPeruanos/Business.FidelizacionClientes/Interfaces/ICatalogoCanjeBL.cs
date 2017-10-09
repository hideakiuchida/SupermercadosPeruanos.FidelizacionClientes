using Model.FidelizacionClientes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.FidelizacionClientes.Interfaces
{
    public interface ICatalogoCanjeBL
    {
        CatalogoProducto GetOfertasPersonalizadas(int idCliente, int cantidad, int pagina); 
    }
}
