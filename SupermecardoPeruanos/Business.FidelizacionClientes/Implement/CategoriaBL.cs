using System.Collections.Generic;
using Business.FidelizacionClientes.Interfaces;
using Model.FidelizacionClientes;
using DataAccess.FidelizacionClientes.Interfaces;
using DataAccess.FidelizacionClientes.Implement;

namespace Business.FidelizacionClientes.Implement
{
    public class CategoriaBL : ICategoriaBL
    {
        private ICategoriaDA categoriaDA;

        public CategoriaBL()
        {
            categoriaDA = new CategoriaDA();
        }
        public List<Categoria> GetAll()
        {
            return categoriaDA.GetAll();
        }
    }
}
