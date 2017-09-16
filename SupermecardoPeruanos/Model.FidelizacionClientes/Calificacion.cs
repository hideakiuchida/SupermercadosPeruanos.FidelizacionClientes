using System;
using System.Collections.Generic;
using System.Text;

namespace Model.FidelizacionClientes
{
    public class Calificacion
    {
        public int Codigo { get; set; }
        public string CalificacionCrediticia { get; set; }
        public decimal LineaCredito { get; set; }
        public decimal SueldoCliente { get; set; }
        public decimal OtrosIngresos { get; set; }
        public string Estado { get; set; }

        public Cliente Cliente { get; set; }
    }
}
