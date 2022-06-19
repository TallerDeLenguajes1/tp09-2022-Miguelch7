public class Archivo {
  private string nombre;
  private string? extension;

  public Archivo(string nombre, string? extension) {
    this.nombre = nombre;
    this.extension = extension;
  }

  public string Nombre { get => nombre; set => nombre = value; }
  public string? Extension { get => extension; set => extension = value; }
}
