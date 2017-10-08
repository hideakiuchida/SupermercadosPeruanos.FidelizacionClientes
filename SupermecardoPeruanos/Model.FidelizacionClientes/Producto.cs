using System;
using System.Collections.Generic;
using System.Text;

namespace Model.FidelizacionClientes
{
    public class Producto
    {
        public int Id { get; set; }
        public string Imagen { get; set; }
        public int Puntos { get; set; }
        public int Stock { get; set; }
        public string Descripcion { get; set; }
        public Categoria Categoria { get; set; }
    }
}
