using System.Text.Json;
using System.Text.Json.Serialization;

Console.Write("Ingrese una cantidad de productos: ");
int cantidadProductos = Convert.ToInt32(Console.ReadLine());
string archivoJSON = Directory.GetCurrentDirectory() + "\\productos.json";

if (!File.Exists(archivoJSON)) {
  File.Create(archivoJSON);
};

List<Producto> ListaProductos = generarProductosAleatoriamente(cantidadProductos);

guardarListadoProductosEnJson(ListaProductos, archivoJSON);

List<Producto> ListaProductosJSON = leerJSON(archivoJSON);

mostrarListado(ListaProductosJSON);

// ---------- Funciones ----------
List<Producto> generarProductosAleatoriamente(int cantidadProductos) {

  List<Producto> ListaProductos = new List<Producto>();

  for (int i = 0; i < cantidadProductos; i++) {
    
    Producto producto = new Producto();

    ListaProductos.Add(producto);
  };

  return ListaProductos;
};

void guardarListadoProductosEnJson(List<Producto> ListaProductos, string archivoJSON) {
  
  string ListaProductosJSON = JsonSerializer.Serialize(ListaProductos);
  
  StreamWriter sw = new StreamWriter(archivoJSON);
  
  sw.WriteLine(ListaProductosJSON);

  sw.Close();
};

List<Producto> leerJSON(string archivoJSON) {
  
  List<Producto> ListadoProductos = new List<Producto>();
  
  StreamReader sr = new StreamReader(archivoJSON);

  string ListadoProductosJSON = sr.ReadLine()!;

  if (!string.IsNullOrEmpty(ListadoProductosJSON)) {
    ListadoProductos = JsonSerializer.Deserialize<List<Producto>>(ListadoProductosJSON);
  };

  return ListadoProductos;
};

void mostrarListado(List<Producto> ListadoProductos) {

  int i = 1;

  foreach (Producto producto in ListadoProductos) {

    Console.WriteLine($"----- Producto { i } -----");

    producto.mostrarProducto();
    
    Console.WriteLine("");

    i++;
  }
};