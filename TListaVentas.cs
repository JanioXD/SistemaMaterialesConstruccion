using SistemaMaterialesConstruccion.Entidades;
using System.Collections.Generic;

namespace SistemaMaterialesConstruccion.Controlador
{
    public class TListaVentas
    {
        public static List<Venta> _listaVentas = new List<Venta>();

        public static bool Agregar(Venta objVenta)
        {
            if (objVenta == null)
            {
                return false;
            }

            if (!objVenta.ValidarVenta())
            {
                return false;
            }

            objVenta.CalcularTotales();

            objVenta.ProcesarVenta();

            _listaVentas.Add(objVenta);

            return true;
        }

        public static int Buscar(
            string numeroFactura)
        {
            for (int i = 0;
                 i < _listaVentas.Count;
                 i++)
            {
                if (_listaVentas[i].NumeroFactura ==
                    numeroFactura)
                {
                    return i;
                }
            }

            return -1;
        }

        public static Venta Obtener(
            string numeroFactura)
        {
            int posicion =
                Buscar(numeroFactura);

            if (posicion == -1)
            {
                return null;
            }

            return _listaVentas[posicion];
        }

        public static bool Eliminar(
            string numeroFactura)
        {
            int posicion =
                Buscar(numeroFactura);

            if (posicion == -1)
            {
                return false;
            }

            _listaVentas.RemoveAt(posicion);

            return true;
        }

        public static double TotalVentas()
        {
            double total = 0;

            foreach (Venta item in _listaVentas)
            {
                total += item.Total;
            }

            return total;
        }
    }
}
