using System;

namespace Model.FidelizacionClientes
{
    public class Cliente
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Apellidos { get { return string.Format("{0} {1}", ApellidoPaterno, ApellidoMaterno); } }
        public string TipoDocumentoIdentidad { get; set; }
        public string NumeroDocumentoIdentidad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string TelefonoFijo { get; set; }
        public string TelefonoMovil { get; set; }
        public string SituacionLaboral { get; set; }
        public string Estado { get; set; }
        public string IndicadorTarjeta { get; set; }
        public string IndicadorVeaClub { get; set; }
    }
}
