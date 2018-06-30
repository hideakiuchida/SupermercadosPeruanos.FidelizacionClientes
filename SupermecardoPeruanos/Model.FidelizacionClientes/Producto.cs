using System;
using System.Collections.Generic;
using System.Text;

namespace Model.FidelizacionClientes
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int CategoriaId { get; set; }
        public int Puntos { get; set; }
        public int TipoCanjeId { get; set; }
        public string Descripcion { get; set; }
        public string Condiciones { get; set; }
        public string Imagen { get; set; }
        public int Stock { get; set; }
        public int Cantidad { get; set; }
        public Categoria Categoria { get; set; }        
        public string TipoDescripcion
        { get
            {
                if (TipoCanjeId == 0)
                    return "Producto";
                if(TipoCanjeId == 1)
                    return "Servicio";
                return String.Empty;
            }
        }
        public string CategoriaDescripcion { get; set; }
    }
}
