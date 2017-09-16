using System;
using System.Collections.Generic;
using System.Text;

namespace Model.FidelizacionClientes
{
    public class SolicitudAfiliacion
    {
        public int Codigo { get; set; }
        public string Estado { get; set; }
        public DateTime FechaSolicitudAfiliacion { get; set; }

        public Cliente Cliente { get; set; }
    }
}
