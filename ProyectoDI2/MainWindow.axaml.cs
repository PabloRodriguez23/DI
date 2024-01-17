using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;

namespace ProyectoDI2
{
    public partial class MainWindow : Window
    {
        private List<matriculado> Lista = new List<matriculado>();
        private int indiceactual = 0;
        private bool crear = false;
        private bool cargado = false;
        private OpenFileDialog cargar = new OpenFileDialog();
        private string archivoSeleccionado;

        //GITHUB: https://github.com/PabloRodriguez23/DI
        public MainWindow()
        {
            InitializeComponent();
            CrearRegistrosStandar();
            CargarDatosDesdeArchivo();
            InicializarInterfaz();
            this.Closing += GuardarCerrar;
        }

        private void CrearRegistrosStandar()
        {
            // Creación de registros estándar
            string ruta1 = "Resources/default.png";
            string ruta2 = "Resources/foto2.jpg";
            string ruta3 = "Resources/foto3.png";

            byte[] foto1 = File.ReadAllBytes(ruta1);
            byte[] foto2 = File.ReadAllBytes(ruta2);
            byte[] foto3 = File.ReadAllBytes(ruta3);

            Lista.Add(new matriculado("Pablo", "Rodriguez", 954717171, 'M', true, 1300.5f, foto1));
            Lista.Add(new matriculado("Alba", "Rodriguez", 954717171, 'M', false, 1700.5f, foto2));
            Lista.Add(new matriculado("Irene", "Rodriguez", 954717171, 'M', true, 1467.5f, foto3));

            btanterior.IsEnabled = false;
        }

        private void CargarDatosDesdeArchivo()
        {
            try
            {
                using (BinaryReader reader = new BinaryReader(File.OpenRead("databank.data")))
                {
                    int vuelta = 0;
                    int total = reader.ReadInt32();
                    Console.WriteLine(total);
                    while (vuelta < total)
                    {
                        vuelta++;
                        string nombre = reader.ReadString();
                        string apellido = reader.ReadString();
                        int numero = reader.ReadInt32();
                        char genero = reader.ReadChar();
                        bool beca = reader.ReadBoolean();
                        float cantidadbeca = reader.ReadSingle();
                        int numbyte = reader.ReadInt32();
                        byte[] foto = reader.ReadBytes(numbyte);

                        matriculado persona = new matriculado(nombre, apellido, numero, genero, beca, cantidadbeca, foto);
                        Lista.Add(persona);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar datos desde el archivo: {ex.Message}");
            }
        }

        private void InicializarInterfaz()
        {
            // Inicializar la interfaz gráfica con los datos del primer matriculado
            
            MostrarMatriculadoActual();
            MostrarImagenActual();
            DesactivarControles();
            lblnregistros.Content = "Nº Registros: " + Lista.Count;
        }

        private void MostrarMatriculadoActual()
        {
            matriculado actual = Lista[indiceactual];
            txtnombre.Text = actual.nombre;
            txtapellidos.Text = actual.apellido;
            txtnumero.Text = actual.numero.ToString();
            txtsexo.Text = actual.genero.ToString();
            ckbeca.IsChecked = actual.beca;
            txtcantidad.Text = string.Format("{0:G}", actual.cantidadbeca);
            MostrarImagenActual();
        }

        private void MostrarImagenActual()
        {
            matriculado actual = Lista[indiceactual];
            MostrarImagen(actual);
        }

        private void MostrarImagen(matriculado actual)
        {
            if (actual.foto != null)
            {
                CargarImagen(actual.foto);
            }
            else
            {
                // Ruta de la imagen predeterminada
                string rutaPredeterminada = "Resources/default.png";

                // Cargar la imagen predeterminada
                try
                {
                    pb.Source = new Bitmap(rutaPredeterminada);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al cargar la imagen predeterminada: {ex.Message}");
                }
            }
        }

        private void CargarImagen(byte[] bytes)
        {
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                Bitmap bitmap = new Bitmap(stream);
                pb.Source = bitmap;
            }
        }

        private void GuardarCerrar(object sender, CancelEventArgs e)
        {
            GuardarDatos();
        }

        private void btguardar_Click(object sender, RoutedEventArgs e)
        {
            GuardarDatos();
        }
        
        private void GuardarDatos()
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.OpenWrite("databank.data")))
                {
                    writer.Write(Lista.Count);
                    foreach (matriculado persona in Lista)
                    {
                        writer.Write(persona.nombre);
                        writer.Write(persona.apellido);
                        writer.Write(persona.numero);
                        writer.Write(persona.genero);
                        writer.Write(persona.beca);
                        writer.Write(persona.cantidadbeca);
                        writer.Write(persona.foto.Length);
                        writer.Write(persona.foto);
                    }
                }

                Console.WriteLine("Datos guardados en el archivo binario.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar datos en el archivo: {ex.Message}");
            }
        }

        private void btcargarimg_Click(object sender, RoutedEventArgs e)
        {
            cargado = true;
            cargararchivo();
        }

        private async void cargararchivo()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Seleccionar archivo";
            dialog.Filters.Add(new FileDialogFilter() { Name = "Imagen", Extensions = { "jpg", "jpeg", "png", "gif", "bmp" } });

            string[] result = await dialog.ShowAsync(this);

            if (result != null && result.Length > 0)
            {
                archivoSeleccionado = result[0];
                Console.WriteLine($"Archivo seleccionado: {archivoSeleccionado}");
                pb.Source = new Bitmap(archivoSeleccionado);
            }
        }

        private void btsiguiente_Click(object sender, RoutedEventArgs e)
        {
            indiceactual++;
            registro.Content = "Nº de registro: " + (indiceactual+1);
            if (indiceactual == Lista.Count - 1)
            {
                btsiguiente.IsEnabled = false;
                btanterior.IsEnabled = true;
            }
            else
            {
                btanterior.IsEnabled = true;
            }

            InicializarInterfaz();
            MostrarImagenActual();
        }

        private void btanterior_Click(object sender, RoutedEventArgs e)
        {
            indiceactual--;
            registro.Content = "Nº de registro: " + (indiceactual+1);
            if (indiceactual == 0)
            {
                btsiguiente.IsEnabled = true;
                btanterior.IsEnabled = false;
            }
            else
            {
                btsiguiente.IsEnabled = true;
            }

            InicializarInterfaz();
            MostrarImagenActual();
        }

        private void btconfirmar_Click(object sender, RoutedEventArgs e)
        {
            if (crear)
            {
                CrearMatriculado();
            }
            else
            {
                ModificarMatriculado();
            }
        }

        private void CrearMatriculado()
        {
            string nombre = GetValueOrDefault(txtnombre.Text);
            string apellidos = GetValueOrDefault(txtapellidos.Text);
            int num = ParseToInt(txtnumero.Text);
            char g = ParseToChar(txtsexo.Text);
            bool beca = ckbeca.IsChecked ?? false;
            float cantidadbeca = ParseToFloat(txtcantidad.Text);
            byte[] foto = null;
            if (cargado)
            {
                foto = File.ReadAllBytes(archivoSeleccionado);
                cargado = false;
            }
            
            matriculado nuevo = new matriculado(nombre, apellidos, num, g, beca, cantidadbeca, foto);
            Lista.Add(nuevo);

            DesactivarControles();
            if (indiceactual == Lista.Count - 1)
            {
                btsiguiente.IsEnabled = false;
                btanterior.IsEnabled = true;
            }
            else
            {
                if (indiceactual == 0)
                {
                    btsiguiente.IsEnabled = true;
                    btanterior.IsEnabled = false;
                }
                else
                {
                    btsiguiente.IsEnabled = true;
                    btanterior.IsEnabled = true;
                }
            }
            bteliminar.IsEnabled = true;
            InicializarInterfaz();
            crear = false;
        }

        private void ModificarMatriculado()
        {
            matriculado modificar = Lista[indiceactual];

            modificar.nombre = GetValueOrDefault(txtnombre.Text);
            modificar.apellido = GetValueOrDefault(txtapellidos.Text);
            modificar.numero = ParseToInt(txtnumero.Text);
            modificar.genero = ParseToChar(txtsexo.Text);
            modificar.beca = ckbeca.IsChecked ?? false;
            modificar.cantidadbeca = ParseToFloat(txtcantidad.Text);
            if (cargado)
            {
                modificar.foto = File.ReadAllBytes(archivoSeleccionado);
                cargado = false;
            }
            

            DesactivarControles();
            if (indiceactual == Lista.Count - 1)
            {
                btsiguiente.IsEnabled = false;
                btanterior.IsEnabled = true;
            }
            else
            {
                if (indiceactual == 0)
                {
                    btsiguiente.IsEnabled = true;
                    btanterior.IsEnabled = false;
                }else
                {
                    btsiguiente.IsEnabled = true;
                    btanterior.IsEnabled = true;
                }
            }
            InicializarInterfaz();
            
        }

        private void DesactivarControles()
        {
            btcargarimg.IsEnabled = false;
            txtnombre.IsEnabled = false;
            txtapellidos.IsEnabled = false;
            txtnumero.IsEnabled = false;
            txtsexo.IsEnabled = false;
            ckbeca.IsEnabled = false;
            txtcantidad.IsEnabled = false;
            btconfirmar.IsEnabled = false;
            btcancelar.IsEnabled = false;
            btmodificar.IsEnabled = true;
            btcrear.IsEnabled = true;
        }

        private string GetValueOrDefault(string text)
        {
            return string.IsNullOrWhiteSpace(text) ? null : text;
        }

        private int ParseToInt(string text)
        {
            int result;
            return int.TryParse(text, out result) ? result : 0;
        }

        private char ParseToChar(string text)
        {
            char result;
            return char.TryParse(text, out result) ? result : '/';
        }

        private float ParseToFloat(string text)
        {
            float result;
            return float.TryParse(text, out result) ? result : 0;
        }

        private void btcrear_Click(object sender, RoutedEventArgs e)
        {
            crear = true;
            btcargarimg.IsEnabled = true;
            
            LimpiarControles();
            
            ActivarControles();
            btmodificar.IsEnabled = false;
            btcrear.IsEnabled = false;
        }

        private void LimpiarControles()
        {
            txtnombre.Text = "";
            txtapellidos.Text = "";
            txtnumero.Text = "";
            txtsexo.Text = "";
            ckbeca.IsChecked = false;
            txtcantidad.Text = "";
        }

        private void ActivarControles()
        {
            txtnombre.IsEnabled = true;
            txtapellidos.IsEnabled = true;
            txtnumero.IsEnabled = true;
            txtsexo.IsEnabled = true;
            ckbeca.IsEnabled = true;
            txtcantidad.IsEnabled = true;

            btsiguiente.IsEnabled = false;
            btanterior.IsEnabled = false;
            btconfirmar.IsEnabled = true;
            btcancelar.IsEnabled = true;
        }

        private void btcancelar_Click(object sender, RoutedEventArgs e)
        {
            DesactivarControles();
            if (indiceactual == Lista.Count - 1)
            {
                btsiguiente.IsEnabled = false;
                btanterior.IsEnabled = true;
            }
            else
            {
                if (indiceactual == 0)
                {
                    btsiguiente.IsEnabled = true;
                    btanterior.IsEnabled = false;
                }
                else
                {
                    btsiguiente.IsEnabled = true;
                    btanterior.IsEnabled = true;
                }
            }
            InicializarInterfaz();
        }

        private void bteliminar_Click(object sender, RoutedEventArgs e)
        {
            Lista.RemoveAt(indiceactual);
            registro.Content = "Nº de registro: " + (indiceactual+1);
            if (indiceactual == 0)
            {
                btsiguiente.IsEnabled = true;
                btanterior.IsEnabled = false;
            }

            if (Lista.Count == 1)
            {
                btsiguiente.IsEnabled = false;
                btanterior.IsEnabled = false;
                bteliminar.IsEnabled = false;
            }
            if (indiceactual == Lista.Count)
            {
                indiceactual--;
            }

            InicializarInterfaz();
        }

        private void btmodificar_Click(object sender, RoutedEventArgs e)
        {
            crear = false;
            btcargarimg.IsEnabled = true;

            ActivarControles();
            btmodificar.IsEnabled = false;
            btcrear.IsEnabled = false;
        }
    }
}
