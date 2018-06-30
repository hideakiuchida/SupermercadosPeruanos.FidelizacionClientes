using Business.FidelizacionClientes.Implement;
using Business.FidelizacionClientes.Interfaces;
using Model.FidelizacionClientes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace Web.CanjePuntos.Models
{
    public class CarModel
    {
        [DataType(DataType.Text)]
        public string Detail { get; set; }
        public List<CanjePedido> ListCanjePedido;
        public CarModel()
        {
            ListCanjePedido = new List<CanjePedido>();
        }
        public Boolean AddItem(int idProducto)
        {
            CanjePedido itemVenta = new CanjePedido();
            itemVenta.Productos = new Producto { Id = idProducto };
            ListCanjePedido.Add(itemVenta);
            return true;
        }
        public void CargarDatos()
        {
            ICanjePedidoBL canjePedido = new CanjePedidoBL();
            ListCanjePedido = canjePedido.ListarCanjePedido();
        }

    }
}