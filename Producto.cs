namespace SistemaMaterialesConstruccion.Entidades
{
    public class Producto
    {
        private string _codigo;
        private string _nombre;
        private string _marca;
        private double _precio;
        private int _stock;
        private int _stockMinimo;
        private Categoria _objCategoria;
        private bool _estado;
        // CONSTRUCTOR VACÍO
        public Producto() { }
        // CONSTRUCTOR CON PARÁMETROS
        public Producto(string codigo, string nombre, string marca, double precio, int stock, int stockMinimo, Categoria objCategoria, bool estado)
        {
            _codigo = codigo;
            _nombre = nombre;
            _marca = marca;
            _precio = precio;
            _stock = stock;
            _stockMinimo = stockMinimo;
            _objCategoria = objCategoria;
            _estado = estado;
        }
        // PROPIEDADES
        public string Codigo { get { return _codigo; } set { _codigo = value; } }
        public string Nombre { get { return _nombre; } set { _nombre = value; } }
        public string Marca { get { return _marca; } set { _marca = value; } }
        public double Precio { get { return _precio; } set { _precio = value; } }
        public int Stock { get { return _stock; } set { _stock = value; } }
        public int StockMinimo { get { return _stockMinimo; } set { _stockMinimo = value; } }
        public Categoria ObjCategoria { get { return _objCategoria; } set { _objCategoria = value; } }
        public bool Estado { get { return _estado; } set { _estado = value; } }

        // MÉTODOS
        public bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(_codigo) ||
                string.IsNullOrWhiteSpace(_nombre) ||
                string.IsNullOrWhiteSpace(_marca))
                return false;

            if (_precio <= 0 || _stock < 0 || _stockMinimo < 0)
                return false;

            if (_objCategoria == null) return false;

            return true;
        }
        public bool HayStock(int cantidad) { return _stock >= cantidad; }
        public void DisminuirStock(int cantidad) { _stock -= cantidad; }
        public void AumentarStock(int cantidad) { _stock += cantidad; }
        public bool StockBajo() { return _stock <= _stockMinimo; }
        public double CalcularIVA() { return _precio * 0.15; }
        public double PrecioConIVA() { return _precio + CalcularIVA(); }
        public void AplicarDescuento(double porcentaje) { _precio = _precio - (_precio * porcentaje); }
        public void Activar() { _estado = true; }
        public void Desactivar() { _estado = false; }
        public string MostrarProducto() { return _codigo + " - " + _nombre; }
    }
}

