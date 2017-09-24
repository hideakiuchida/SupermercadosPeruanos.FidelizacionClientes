using Business.FidelizacionClientes.Interfaces;
using DataAccess.FidelizacionClientes.Implement;
using DataAccess.FidelizacionClientes.Interfaces;
using Model.FidelizacionClientes;

namespace Business.FidelizacionClientes.Implement
{
    public class CalificacionBL : ICalificacionBL
    {
        private ICalificacionDA calificacionDA;
        public CalificacionBL()
        {
            calificacionDA = new CalificacionDA();
        }

        public Calificacion GetByCliente(string numeroDocumento)
        {
            return calificacionDA.GetByCliente(numeroDocumento);
        }
    }
}
