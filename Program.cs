using System;
using Trabajo;

public class Program
{
    public static void Main()
    {
        var inventario = new Inventario();

        // Ejemplo de agregar productos
        inventario.AgregarProducto(new Producto("Laptop", 800));
        inventario.AgregarProducto(new Producto("Mouse", 20));
        inventario.AgregarProducto(new Producto("Teclado", 50));
        inventario.AgregarProducto(new Producto("Monitor", 200));

        // Filtrar productos con precio mayor a 100
        Console.WriteLine("Productos con precio mayor a $100:");
        var productosFiltrados = inventario.FiltrarPorPrecio(100);
        foreach (var producto in productosFiltrados)
        {
            producto.MostrarInformacion();
        }

        // Actualizar precio de un producto
        Console.WriteLine("\nActualizando precio de 'Mouse' a $25...");
        if (inventario.ActualizarPrecio("Mouse", 25))
        {
            Console.WriteLine("Precio actualizado con éxito.");
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }

        // Eliminar un producto
        Console.WriteLine("\nEliminando 'Teclado' del inventario...");
        if (inventario.EliminarProducto("Teclado"))
        {
            Console.WriteLine("Producto eliminado con éxito.");
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }

        // Contar y agrupar productos por rango de precio
        Console.WriteLine("\nConteo y agrupación de productos por rango de precio:");
        inventario.ContarYAgruparPorRango();

        // Generar reporte de inventario
        Console.WriteLine("\nGenerando reporte de inventario...");
        inventario.GenerarReporte();
    }
}
