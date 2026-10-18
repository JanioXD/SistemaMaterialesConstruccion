namespace SistemaMaterialesConstruccion.Entidades
{
    public class Categoria
    {
        private string _codigo;
        private string _nombre;
        private string _descripcion;
        private bool _estado;
        // CONSTRUCTOR VACÍO
        public Categoria() { }
        // CONSTRUCTOR CON PARÁMETROS
        public Categoria(string codigo, string nombre, string descripcion, bool estado)
        {
            _codigo = codigo;
            _nombre = nombre;
            _descripcion = descripcion;
            _estado = estado;
        }
        // PROPIEDADES
        public string Codigo { get { return _codigo; } set { _codigo = value; } }
        public string Nombre { get { return _nombre; } set { _nombre = value; } }
        public string Descripcion { get { return _descripcion; } set { _descripcion = value; } }
        public bool Estado { get { return _estado; } set { _estado = value; } }
        // MÉTODOS
        public bool ValidarDatos()
        {
            if (_codigo == "" || _nombre == "" || _descripcion == "")
            {
                return false;
            }
            return true;
        }
        public void Activar() { _estado = true; }
        public void Desactivar() { _estado = false; }
        public string MostrarCategoria() { return _nombre; }

    }
}
