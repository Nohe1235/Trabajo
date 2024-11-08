using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo
{
    public class Inventario
    {
        private List<Producto> productos = new List<Producto>();

        // Agregar producto al inventario
        public void AgregarProducto(Producto producto)
        {
            productos.Add(producto);
        }

        // Filtrar productos por precio mínimo
        public IEnumerable<Producto> FiltrarPorPrecio(decimal precioMinimo)
        {
            return productos.Where(p => p.Precio > precioMinimo).OrderBy(p => p.Precio);
        }

        // Actualizar precio de un producto específico
        public bool ActualizarPrecio(string nombre, decimal nuevoPrecio)
        {
            foreach (var producto in productos)
            {
                if (producto.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase))
                {
                    producto.Precio = nuevoPrecio;
                    return true;
                }
            }
            return false;
        }

        // Eliminar producto por nombre
        public bool EliminarProducto(string nombre)
        {
            var producto = productos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (producto != null)
            {
                productos.Remove(producto);
                return true;
            }
            return false;
        }

        // Contar y agrupar productos por rango de precio
        public void ContarYAgruparPorRango()
        {
            int menores100 = productos.Count(p => p.Precio < 100);
            int entre100y500 = productos.Count(p => p.Precio >= 100 && p.Precio <= 500);
            int mayores500 = productos.Count(p => p.Precio > 500);

            Console.WriteLine($"Menores a 100: {menores100} productos");
            Console.WriteLine($"Entre 100 y 500: {entre100y500} productos");
            Console.WriteLine($"Mayores a 500: {mayores500} productos");
        }

        // Generar reporte de inventario
        public void GenerarReporte()
        {
            if (productos.Count == 0)
            {
                Console.WriteLine("El inventario está vacío.");
                return;
            }

            int totalProductos = productos.Count;
            decimal precioPromedio = productos.Average(p => p.Precio);
            Producto precioMasAlto = productos.OrderByDescending(p => p.Precio).First();
            Producto precioMasBajo = productos.OrderBy(p => p.Precio).First();

            Console.WriteLine("Reporte de Inventario:");
            Console.WriteLine($"Total de productos: {totalProductos}");
            Console.WriteLine($"Precio promedio: ${precioPromedio:F2}");
            Console.WriteLine($"Producto más caro: {precioMasAlto.Nombre} - ${precioMasAlto.Precio}");
            Console.WriteLine($"Producto más barato: {precioMasBajo.Nombre} - ${precioMasBajo.Precio}");
        }
    }

}
