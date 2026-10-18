using SistemaMaterialesConstruccion.Utilidades;

namespace SistemaMaterialesConstruccion.Entidades
{
    public class Cliente : Persona
    {
        private string _correo;
        private string _tipoCliente;
        private double _limiteCredito;
        private double _saldoPendiente;

        // CONSTRUCTOR VACÍO
        public Cliente() { }
        // CONSTRUCTOR CON PARÁMETROS
        public Cliente(string identificacion, string nombre, string telefono, string direccion, bool estado, string correo, string tipoCliente, double limiteCredito, double saldoPendiente)
            : base(identificacion, nombre, telefono, direccion, estado)
        {
            _correo = correo;
            _tipoCliente = tipoCliente;
            _limiteCredito = limiteCredito;
            _saldoPendiente = saldoPendiente;
        }
        // PROPIEDADES
        public string Correo { get { return _correo; } set { _correo = value; } }
        public string TipoCliente { get { return _tipoCliente; } set { _tipoCliente = value; } }
        public double LimiteCredito { get { return _limiteCredito; } set { _limiteCredito = value; } }
        public double SaldoPendiente { get { return _saldoPendiente; } set { _saldoPendiente = value; } }
        // MÉTODOS
        public bool TieneCreditoDisponible(double monto)
        {
            return (_limiteCredito - _saldoPendiente) >= monto;
        }
        public void AumentarSaldo(double monto)
        {
            _saldoPendiente += monto;
        }
        public void DisminuirSaldo(double monto)
        {
            _saldoPendiente -= monto;
        }
        public double ObtenerDescuento()
        {
            double descuento = 0;
            switch (_tipoCliente)
            {
                case "Frecuente":
                    descuento = 0.10;
                    break;
                case "Mayorista":
                    descuento = 0.15;
                    break;
            }
            return descuento;
        }
        public override bool ValidarDatos()
        {
            if (!base.ValidarDatos()) return false;
            if (string.IsNullOrWhiteSpace(_correo)) return false;
            if (!Validaciones.EsCorreo(_correo)) return false;
            return true;
        }
    }
}
