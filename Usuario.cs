namespace SistemaMaterialesConstruccion.Entidades
{
    public class Usuario : Persona
    {
        private string _codigo;
        private string _usuario;
        private string _contrasena;
        private string _rol;
        private int _intentos;

        // CONSTRUCTOR VACÍO
        public Usuario() { }
        // CONSTRUCTOR CON PARÁMETROS
        public Usuario(string identificacion, string nombre, string telefono, string direccion, bool estado, string codigo, string usuario, string contrasena, string rol, int intentos)
            : base(identificacion, nombre, telefono, direccion, estado)
        {
            _codigo = codigo;
            _usuario = usuario;
            _contrasena = contrasena;
            _rol = rol;
            _intentos = intentos;
        }
        // PROPIEDADES
        public string Codigo { get { return _codigo; } set { _codigo = value; } }
        public string NombreUsuario { get { return _usuario; } set { _usuario = value; } }
        public string Contrasena { get { return _contrasena; } set { _contrasena = value; } }
        public string Rol { get { return _rol; } set { _rol = value; } }
        public int Intentos { get { return _intentos; } set { _intentos = value; } }
        // MÉTODOS
        public bool ValidarLogin(string usuario, string contrasena)
        {
            if (_usuario == usuario && _contrasena == contrasena && Estado == true)
            {
                _intentos = 0;
                return true;
            }
            _intentos++;
            return false;
        }
        public bool EsAdministrador()
        {
            return _rol == "Administrador";
        }
        public void CambiarContrasena(string nuevaClave)
        {
            _contrasena = nuevaClave;
        }
        public override bool ValidarDatos()
        {
            if (!base.ValidarDatos())
            {
                return false;
            }
            if (_codigo == "" || _usuario == "" || _contrasena == "" || _rol == "")
            {
                return false;
            }
            return true;
        }
    }
}
