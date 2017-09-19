using System;
using System.Collections.Generic;
using System.Text;

namespace Model.FidelizacionClientes
{
    public class Inforcorp
    {
        public string EntidadFinanciera { get; set; }
        public decimal MontoDeuda { get; set; }
        public string CalificacionSBS { get; set; }

        public Cliente Cliente { get; set; }
    }
}
