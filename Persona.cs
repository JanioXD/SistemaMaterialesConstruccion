namespace SistemaMaterialesConstruccion.Entidades
{
    public class Persona
    {
        private string _identificacion;
        private string _nombre;
        private string _telefono;
        private string _direccion;
        private bool _estado;
        // CONSTRUCTOR VACÍO
        public Persona() { }
        // CONSTRUCTOR CON PARÁMETROS
        public Persona(string identificacion, string nombre, string telefono, string direccion, bool estado)
        {
            _identificacion = identificacion;
            _nombre = nombre;
            _telefono = telefono;
            _direccion = direccion;
            _estado = estado;
        }
        // PROPIEDADES
        public string Identificacion { get { return _identificacion; } set { _identificacion = value; } }
        public string Nombre { get { return _nombre; } set { _nombre = value; } }
        public string Telefono { get { return _telefono; } set { _telefono = value; } }
        public string Direccion { get { return _direccion; } set { _direccion = value; } }
        public bool Estado { get { return _estado; } set { _estado = value; } }
        // MÉTODOS
        public virtual string MostrarDatos() { return _identificacion + " - " + _nombre; }
        public virtual bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(_identificacion) ||
                string.IsNullOrWhiteSpace(_nombre) ||
                string.IsNullOrWhiteSpace(_telefono) ||
                string.IsNullOrWhiteSpace(_direccion))
            {
                return false;
            }
            return true;
        }
        public void Activar()
        {
            _estado = true;
        }
        public void Desactivar()
        {
            _estado = false;
        }
    }
}
