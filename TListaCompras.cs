using SistemaMaterialesConstruccion.Entidades;
using System.Collections.Generic;

namespace SistemaMaterialesConstruccion.Controlador
{
    public class TListaCompras
    {
        public static List<Compra> _listaCompras = new List<Compra>();

        public static bool Agregar(
            Compra objCompra)
        {
            if (objCompra == null)
            {
                return false;
            }

            if (!objCompra.ValidarCompra())
            {
                return false;
            }

            objCompra.CalcularTotales();

            objCompra.ProcesarCompra();

            _listaCompras.Add(objCompra);

            return true;
        }

        public static int Buscar(
            string numeroCompra)
        {
            for (int i = 0;
                 i < _listaCompras.Count;
                 i++)
            {
                if (_listaCompras[i].NumeroCompra ==
                    numeroCompra)
                {
                    return i;
                }
            }

            return -1;
        }

        public static Compra Obtener(
            string numeroCompra)
        {
            int posicion =
                Buscar(numeroCompra);

            if (posicion == -1)
            {
                return null;
            }

            return _listaCompras[posicion];
        }

        public static bool Eliminar(
            string numeroCompra)
        {
            int posicion =
                Buscar(numeroCompra);

            if (posicion == -1)
            {
                return false;
            }

            _listaCompras.RemoveAt(posicion);

            return true;
        }

        public static double TotalCompras()
        {
            double total = 0;

            foreach (Compra item in _listaCompras)
            {
                total += item.Total;
            }

            return total;
        }
    }
}
