using System;
using System.Collections.Generic;

namespace SistemaMaterialesConstruccion.Entidades
{
    public class Compra
    {
        private string _numeroCompra;
        private DateTime _fecha;
        private Proveedor _objProveedor;
        private Usuario _objUsuario;
        private List<DetalleVenta> _listaDetalleCompra;
        private double _subtotal;
        private double _iva;
        private double _total;
        private string _estado;
        // CONSTRUCTOR VACIO
        public Compra()
        {
            _listaDetalleCompra = new List<DetalleVenta>();
        }
        // CONSTRUCTOR CON PARAMETROS
        public Compra(string numeroCompra, DateTime fecha, Proveedor objProveedor, Usuario objUsuario, string estado)
        {
            _numeroCompra = numeroCompra;
            _fecha = fecha;
            _objProveedor = objProveedor;
            _objUsuario = objUsuario;
            _estado = estado;
            _listaDetalleCompra = new List<DetalleVenta>();
        }
        // PROPIEDADES
        public string NumeroCompra { get { return _numeroCompra; } set { _numeroCompra = value; } }
        public DateTime Fecha { get { return _fecha; } set { _fecha = value; } }
        public Proveedor ObjProveedor { get { return _objProveedor; } set { _objProveedor = value; } }
        public Usuario ObjUsuario { get { return _objUsuario; } set { _objUsuario = value; } }
        public List<DetalleVenta> ListaDetalleCompra { get { return _listaDetalleCompra; } set { _listaDetalleCompra = value; } }
        public double Subtotal { get { return _subtotal; } set { _subtotal = value; } }
        public double IVA { get { return _iva; } set { _iva = value; } }
        public double Total { get { return _total; } set { _total = value; } }
        public string Estado { get { return _estado; } set { _estado = value; } }
        // METODOS
        public void AgregarDetalle(DetalleVenta objDetalle)
        {
            _listaDetalleCompra.Add(objDetalle);
        }
        public bool ValidarCompra()
        {
            if (_objProveedor == null) return false;
            if (_objUsuario == null) return false;
            if (_listaDetalleCompra.Count == 0) return false;
            return true;
        }
        public void CalcularTotales()
        {
            _subtotal = 0;
            foreach (DetalleVenta item in _listaDetalleCompra)
            {
                _subtotal += item.Subtotal;
            }
            _iva = _subtotal * 0.15;
            _total = _subtotal + _iva;
        }
        public void ProcesarCompra()
        {
            foreach (DetalleVenta item in _listaDetalleCompra)
            {
                item.ObjProducto.AumentarStock(item.Cantidad);
            }
            _estado = "PROCESADA";
        }
        public void AnularCompra()
        {
            _estado = "ANULADA";
        }
    }
}
