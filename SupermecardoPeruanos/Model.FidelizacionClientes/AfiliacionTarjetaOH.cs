using System;
using System.Collections.Generic;
using System.Text;

namespace Model.FidelizacionClientes
{
    public class AfiliacionTarjetaOH
    {
        public int Codigo { get; set; }
        public string Tipo { get; set; }
        public int NumeroTarjeta { get; set; }
        public string Bin { get; set; }

        public Cliente Cliente { get; set; }
    }
}
