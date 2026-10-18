namespace SistemaMaterialesConstruccion.Entidades
{
    public class DetalleVenta
    {
        private Producto _objProducto;
        private int _cantidad;
        private double _precioUnitario;
        private double _descuento;
        private double _subtotal;
        // CONSTRUCTOR VACÍO
        public DetalleVenta() { }
        // CONSTRUCTOR CON PARÁMETROS
        public DetalleVenta(Producto objProducto, int cantidad, double descuento)
        {
            _objProducto = objProducto;
            _cantidad = cantidad;
            _descuento = descuento;
            _precioUnitario = objProducto.Precio;
            CalcularSubtotal();
        }
        // PROPIEDADES
        public Producto ObjProducto { get { return _objProducto; } set { _objProducto = value; } }
        public int Cantidad { get { return _cantidad; } set { _cantidad = value; } }
        public double PrecioUnitario { get { return _precioUnitario; } set { _precioUnitario = value; } }
        public double Descuento { get { return _descuento; } set { _descuento = value; } }
        public double Subtotal { get { return _subtotal; } set { _subtotal = value; } }
        // MÉTODOS
        public bool ValidarDetalle()
        {
            if (_cantidad <= 0)
            {
                return false;
            }
            if (!_objProducto.HayStock(_cantidad))
            {
                return false;
            }
            return true;
        }
        public void CalcularSubtotal()
        {
            double total = _cantidad * _precioUnitario;
            total = total - (total * _descuento);
            _subtotal = total;
        }
        public double CalcularIVA() { return _subtotal * 0.15; }
        public double CalcularTotal() { return _subtotal + CalcularIVA(); }
    }
}
