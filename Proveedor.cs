namespace SistemaMaterialesConstruccion.Entidades
{
    public class Proveedor : Persona
    {
        private string _codigo;
        private string _empresa;
        private string _correo;
        private string _ruc;
        private string _contacto;
        private double _saldoPendiente;
        // CONSTRUCTOR VACIO
        public Proveedor() { }
        // CONSTRUCTOR CON PARAMETROS
        public Proveedor(string identificacion, string nombre, string telefono, string direccion, bool estado, string codigo, string empresa, string correo, string ruc, string contacto, double saldoPendiente)
            : base(identificacion, nombre, telefono, direccion, estado)
        {
            _codigo = codigo;
            _empresa = empresa;
            _correo = correo;
            _ruc = ruc;
            _contacto = contacto;
            _saldoPendiente = saldoPendiente;
        }
        // PROPIEDADES
        public string Codigo { get { return _codigo; } set { _codigo = value; } }
        public string Empresa { get { return _empresa; } set { _empresa = value; } }
        public string Correo { get { return _correo; } set { _correo = value; } }
        public string Ruc { get { return _ruc; } set { _ruc = value; } }
        public string Contacto { get { return _contacto; } set { _contacto = value; } }
        public double SaldoPendiente { get { return _saldoPendiente; } set { _saldoPendiente = value; } }
        // METODOS
        public override bool ValidarDatos()
        {
            if (!base.ValidarDatos())
            {
                return false;
            }
            if (_codigo == "" || _empresa == "" || _correo == "" || _ruc == "")
            {
                return false;
            }
            return true;
        }
        public void RegistrarDeuda(double valor)
        {
            _saldoPendiente += valor;
        }
        public void AbonarDeuda(double valor)
        {
            _saldoPendiente -= valor;
            if (_saldoPendiente < 0)
            {
                _saldoPendiente = 0;
            }
        }
        public bool TieneDeuda()
        {
            return _saldoPendiente > 0;
        }
        public string MostrarProveedor()
        {
            return _empresa + " - " + _ruc;
        }

    }
}
