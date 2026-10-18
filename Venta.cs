using System;
using System.Collections.Generic;

namespace SistemaMaterialesConstruccion.Entidades
{
    public class Venta
    {
        private string _numeroFactura;
        private DateTime _fecha;
        private Cliente _objCliente;
        private Usuario _objUsuario;
        private List<DetalleVenta> _listaDetalleVenta;
        private double _subtotal;
        private double _iva;
        private double _descuento;
        private double _total;
        private string _estadoVenta;
        // CONSTRUCTOR VACÍO
        public Venta()
        {
            _listaDetalleVenta = new List<DetalleVenta>();
        }
        // CONSTRUCTOR CON PARÁMETROS
        public Venta(string numeroFactura, DateTime fecha, Cliente objCliente, Usuario objUsuario, string estadoVenta)
        {
            _numeroFactura = numeroFactura;
            _fecha = fecha;
            _objCliente = objCliente;
            _objUsuario = objUsuario;
            _estadoVenta = estadoVenta;
            _listaDetalleVenta = new List<DetalleVenta>();
        }
        // PROPIEDADES
        public string NumeroFactura { get { return _numeroFactura; } set { _numeroFactura = value; } }
        public DateTime Fecha { get { return _fecha; } set { _fecha = value; } }
        public Cliente ObjCliente { get { return _objCliente; } set { _objCliente = value; } }
        public Usuario ObjUsuario { get { return _objUsuario; } set { _objUsuario = value; } }
        public List<DetalleVenta> ListaDetalleVenta { get { return _listaDetalleVenta; } set { _listaDetalleVenta = value; } }
        public double Subtotal { get { return _subtotal; } set { _subtotal = value; } }
        public double IVA { get { return _iva; } set { _iva = value; } }
        public double Descuento { get { return _descuento; } set { _descuento = value; } }
        public double Total { get { return _total; } set { _total = value; } }
        public string EstadoVenta { get { return _estadoVenta; } set { _estadoVenta = value; } }
        // MÉTODOS
        public bool AgregarDetalle(DetalleVenta objDetalle)
        {
            if (!objDetalle.ValidarDetalle())
            {
                return false;
            }
            for (int i = 0; i < _listaDetalleVenta.Count; i++)
            {
                if (_listaDetalleVenta[i].ObjProducto.Codigo == objDetalle.ObjProducto.Codigo)
                {
                    return false;
                }
            }
            _listaDetalleVenta.Add(objDetalle);
            return true;
        }
        public void EliminarDetalle(int posicion)
        {
            _listaDetalleVenta.RemoveAt(posicion);
        }
        public bool ValidarVenta()
        {
            if (_objCliente == null) return false;
            if (_objUsuario == null) return false;
            if (_listaDetalleVenta.Count == 0) return false;
            return true;
        }
        public void CalcularTotales()
        {
            double subtotalSinDescuento = 0;
            foreach (var item in _listaDetalleVenta)
                subtotalSinDescuento += item.Subtotal;

            _descuento = subtotalSinDescuento * _objCliente.ObtenerDescuento();
            _subtotal = subtotalSinDescuento - _descuento;
            _iva = _subtotal * 0.15;
            _total = _subtotal + _iva;
        }
        public void ProcesarVenta()
        {
            for (int i = 0; i < _listaDetalleVenta.Count; i++)
            {
                _listaDetalleVenta[i].ObjProducto.DisminuirStock(_listaDetalleVenta[i].Cantidad);
            }
            _estadoVenta = "PROCESADA";
        }
        public void CancelarVenta() { _estadoVenta = "CANCELADA"; }
    }
}
