public enum NombreProductos {
  PC,
  Notebook,
  Celular,
  Mouse,
  Teclado,
  Fuente,
  Auriculares,
  Microprocesador,
  SDD,
  HDD,
  Gabinete,
  Ram,
  Altavoz
}

public enum TamanioProductos {
  Chico,
  Mediano,
  Grande
}

public class Producto {
  private string? nombre;
  private DateTime fechaVencimiento;
  private float precio;
  private string? tamanio;


  public Producto() {
    var random = new Random();

    this.nombre = Enum.GetName(typeof(NombreProductos), random.Next(1, Enum.GetNames(typeof(NombreProductos)).Length));

    this.fechaVencimiento = new DateTime(random.Next(2022, 2026), random.Next(1, 12), random.Next(1, 28));
    this.precio = random.Next(1000, 5000);
    this.tamanio = Enum.GetName(typeof(TamanioProductos), random.Next(1, Enum.GetNames(typeof(TamanioProductos)).Length));
  }

  public void mostrarProducto() {
    Console.WriteLine("Nombre: " + this.nombre);
    Console.WriteLine("Fecha de venimiento: " + this.fechaVencimiento.ToShortDateString());
    Console.WriteLine("Precio: $" + this.precio);
    Console.WriteLine("Tamaño: " + this.tamanio);
  }

  public string? Nombre { get => nombre; set => nombre = value; }
  public DateTime FechaVencimiento { get => fechaVencimiento; set => fechaVencimiento = value; }
  public float Precio { get => precio; set => precio = value; }
  public string? Tamanio { get => tamanio; set => tamanio = value; }
}