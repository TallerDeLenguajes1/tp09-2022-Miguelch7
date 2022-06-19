using System.Text.Json;
using System.Text.Json.Serialization;

Console.Write("Ingrese una ruta: ");
string path = Console.ReadLine()!;
string archivoJSON = Directory.GetCurrentDirectory() + "\\index.json";

List<Archivo> ListaArchivos = new List<Archivo>();

if ( !File.Exists(archivoJSON) ) {
  File.Create(archivoJSON);
};

mostrarDirectorioYListar(path, ListaArchivos);
guardarContenidoEnJSON(archivoJSON, ListaArchivos);

void mostrarDirectorioYListar(string path, List<Archivo> ListaArchivos) {

  if (Directory.Exists(path)) {
      
    List<string> listadoCarpetas = Directory.GetDirectories(path).ToList();

    Console.WriteLine("-----Carpetas-----");

    int aux = 1;

    foreach (string carpeta in listadoCarpetas) {

      string[] carpetaAMostrar = carpeta.Split("\\");
      string nombreCarpeta = carpetaAMostrar[carpetaAMostrar.Length - 1];
      Console.WriteLine("/" + nombreCarpeta);

      Archivo carpetaObj = new Archivo(nombreCarpeta, null);

      ListaArchivos.Add(carpetaObj);

      Console.WriteLine("/" + nombreCarpeta);

      aux++;
    };

    Console.WriteLine("-----Archivos-----");

    foreach (string archivo in Directory.GetFiles(path)) {
      
      string[] archivoAMostrar = archivo.Split("\\");
      string[] archivoArray = archivoAMostrar[archivoAMostrar.Length - 1].Split(".");
      string nombreArchivo = archivoArray[0];
      string extensionArchivo = archivoArray[archivoArray.Length - 1];

      Console.WriteLine(nombreArchivo + "." + extensionArchivo);

      Archivo archivoObj = new Archivo(nombreArchivo, extensionArchivo);

      ListaArchivos.Add(archivoObj);

      aux++;
    };
  } else {
    Console.WriteLine("El directorio no existe");
  };
};

void guardarContenidoEnJSON(string archivoJSON, List<Archivo> ListaArchivos) {

  StreamWriter sw = new StreamWriter(archivoJSON);

  string listaArchivosJSON = JsonSerializer.Serialize(ListaArchivos);

  sw.WriteLine(listaArchivosJSON);
  
  sw.Close();
};
