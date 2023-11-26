using Microsoft.VisualBasic.ApplicationServices;
using System.Collections;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Proyecto_forms
{
    public partial class Form1 : Form
    {
        List<matriculado> Lista = new List<matriculado>();
        int indiceactual = 0;
        Boolean crear = false;
        Boolean cargado = false;
        OpenFileDialog cargar = new OpenFileDialog();
        public Form1()
        {
            //Creacion de unos registros standar que va a tener la aplicacion siempre.(se pueden modificar)
            matriculado alum1, alum2, alum3;
            String ruta1 = "C:\\Users\\Pablo\\Desktop\\tuto\\2ºDAM\\DI\\C#\\Proyecto forms\\Resources\\default.png";
            String ruta2 = "C:\\Users\\Pablo\\Desktop\\tuto\\2ºDAM\\DI\\C#\\Proyecto forms\\Resources\\foto2.jpg";
            String ruta3 = "C:\\Users\\Pablo\\Desktop\\tuto\\2ºDAM\\DI\\C#\\Proyecto forms\\Resources\\foto3.png";
            byte[] foto1 = File.ReadAllBytes(ruta1);
            byte[] foto2 = File.ReadAllBytes(ruta2);
            byte[] foto3 = File.ReadAllBytes(ruta3);
            alum1 = new matriculado("Pablo", "Rodriguez", 954717171, 'M', true, 1300.5f, foto1);
            alum2 = new matriculado("Alba", "Rodriguez", 954717171, 'M', false, 1300.5f, foto2);
            alum3 = new matriculado("Irene", "Rodriguez", 954717171, 'M', true, 1300.5f, foto3);
            Lista.Add(alum1);
            Lista.Add(alum2);
            Lista.Add(alum3);


            InitializeComponent();
            //Carga de datos desde el archivo .data para cargar todos los registros.
            try
            {
                using (BinaryReader reader = new BinaryReader(File.OpenRead("databank.data")))
                {
                    while (reader.BaseStream.Position < reader.BaseStream.Length)
                    {
                        String nombre;
                        String apellido;
                        int numero;
                        char genero;
                        Boolean beca;
                        float cantidadbeca;
                        Byte[] foto;

                        nombre = reader.ReadString();
                        apellido = reader.ReadString();
                        numero = reader.ReadInt32();
                        genero = reader.ReadChar();
                        beca = reader.ReadBoolean();
                        cantidadbeca = reader.ReadSingle();
                        int numbyte = reader.ReadInt32();
                        foto = reader.ReadBytes(numbyte);
                        matriculado persona = new matriculado(nombre, apellido, numero, genero, beca, cantidadbeca, foto);

                        // Agregar la instancia a la lista
                        Lista.Add(persona);
                    }
                }
            }
            catch
            {

            }
            
            inicio();
            //Añado el metodo creado y le aplico un evento, en este caso que cuando cierre que ejecute el metodo.
            this.FormClosing += new FormClosingEventHandler(Guardar_cerrar);

        }

        //Metodo para guardar los datos al cerrar la aplicacion llamando al metodo.
        public void Guardar_cerrar(object sender, FormClosingEventArgs e)
        {
            GuardarDatos();
        }
        //Metodo para que empiece la aplicacion de manera correcta, con todos los botones disponibles y lo que no desactivados.
        public void inicio()
        {
            matriculado actual = Lista[indiceactual];
            txtnombre.Enabled = false;
            txtnombre.Text = actual.nombre;
            txtapellidos.Enabled = false;
            txtapellidos.Text = actual.apellido;
            txtnumero.Enabled = false;
            txtnumero.Text = "" + actual.numero;
            txtsexo.Enabled = false;
            txtsexo.Text = "" + actual.genero;
            ckbeca.Enabled = false;
            ckbeca.Checked = actual.beca;
            txtcantidad.Enabled = false;
            txtcantidad.Text = string.Format("{0:G}", actual.cantidadbeca);
            //pb.Image = Image.FromFile("C:\\Users\\Pablo\\Desktop\\quini.png");
            //En este if, compruebo si el registro tiene foto, en el caso de que no tenga le pongo una imagen standar.
            if (actual.foto != null)
            {
                pb.Image = byteArrayToImage(actual.foto);
            }
            else
            {
                pb.Image = Image.FromFile("C:\\Users\\Pablo\\Desktop\\tuto\\2ºDAM\\DI\\C#\\Proyecto forms\\Resources\\default.png");
            }
            btcargarimg.Enabled = false;
            btcancelar.Enabled = false;
            btconfirmar.Enabled = false;

            lblnregistros.Text = Convert.ToString(Lista.Count);

        }


        //Boton para cargar una imagen que se activa al darle a crear y al confirmar se desactiva.
        private void btcargarimg_Click(object sender, EventArgs e)
        {
            //Este boolean sirve para poder asignarle una foto standar en el caso de no haber subido ninguna.
            cargado = true;
            cargar.Filter = "JPEG(*.JPG)|*.JPG|BMP(*BMP)|*.BMP";
            if (cargar.ShowDialog() == DialogResult.OK)
            {
                pb.Image = Image.FromFile(cargar.FileName);
            }
        }


        //boton siguiente
        private void btsiguiente_Click(object sender, EventArgs e)
        {
            indiceactual++;
            if (indiceactual == Lista.Count - 1)
            {
                btsiguiente.Enabled = false;
                btanterior.Enabled = true;
            }
            else
            {
                btanterior.Enabled = true;
            }
            inicio();
        }

        //boton anterior
        private void btanterior_Click(object sender, EventArgs e)
        {
            indiceactual--;
            if (indiceactual == 0)
            {
                btsiguiente.Enabled = true;
                btanterior.Enabled = false;
            }
            else
            {
                btsiguiente.Enabled = true;
            }
            inicio();
        }
        //En el boton confirmar tiene dos funcionalidades, la de crear y la de modificar, depende de lo que se le haya dado se hace una cosa u otra.
        private void btconfirmar_Click(object sender, EventArgs e)
        {
            if (crear == true)
            {
                //Al crear coge todos los datos y los guarda para poder añadir un nuevo matriculado con esos datos.
                string nombre;
                string apellidos;
                int num;
                char g;
                Boolean beca;
                float cantidadbeca;
                byte[] foto;
                try
                {
                    nombre = txtnombre.Text;
                }
                catch
                {
                    nombre = null;
                }

                try
                {
                    apellidos = txtapellidos.Text;
                }
                catch
                {
                    apellidos = null;
                }

                try{
                    num = int.Parse(txtnumero.Text);
                }catch {
                    num = 0;
                }
                try
                {
                    g = Convert.ToChar(txtsexo.Text);
                }
                catch
                {
                    g = '/';
                }

                beca = ckbeca.Checked;
                try
                {
                    cantidadbeca = float.Parse(txtcantidad.Text);
                }
                catch
                {
                    cantidadbeca = 0;
                }
                

                if (cargado == true)
                {
                    foto = File.ReadAllBytes(cargar.FileName);
                    cargado = false;
                }
                else
                {
                    foto = null;
                }



                matriculado nuevo = new matriculado(nombre, apellidos, num, g, beca, cantidadbeca, foto);
                Lista.Add(nuevo);

                btcargarimg.Enabled = false;
                btcargarimg.Enabled = false;
                txtnombre.Enabled = false;
                txtapellidos.Enabled = false;
                txtnumero.Enabled = false;
                txtsexo.Enabled = false;
                ckbeca.Enabled = false;
                txtcantidad.Enabled = false;
                btsiguiente.Enabled = true;
                btanterior.Enabled = true;
                btconfirmar.Enabled = false;
                btcancelar.Enabled = false;
                inicio();
                crear = false;

            }
            else
            {
                // Aqui es para modificar los datos, que recoge los datos y los actualiza del matriculado.
                matriculado modificar = Lista[indiceactual];

                String nombre = txtnombre.Text;
                modificar.nombre = nombre;
                String apellidos = txtapellidos.Text;
                modificar.apellido = apellidos;
                int num = int.Parse(txtnumero.Text);
                modificar.numero = num;
                char g = Convert.ToChar(txtsexo.Text);
                modificar.genero = g;
                Boolean beca = ckbeca.Checked;
                modificar.beca = beca;
                float cantidad = float.Parse(txtcantidad.Text);
                modificar.cantidadbeca = cantidad;
                if (cargado == true)
                {
                    Byte[] foto = File.ReadAllBytes(cargar.FileName);
                    modificar.foto = foto;
                    cargado = false;
                }

                btcargarimg.Enabled = false;
                btcargarimg.Enabled = false;
                txtnombre.Enabled = false;
                txtapellidos.Enabled = false;
                txtnumero.Enabled = false;
                txtsexo.Enabled = false;
                ckbeca.Enabled = false;
                txtcantidad.Enabled = false;
                btsiguiente.Enabled = true;
                btanterior.Enabled = true;
                btconfirmar.Enabled = false;
                btcancelar.Enabled = false;
                inicio();
            }

        }
        //Boton crear, activa el booleano y desactiva los botones inecesarios en la creacion.
        private void btcrear_Click(object sender, EventArgs e)
        {
            crear = true;
            btcargarimg.Enabled = true;

            txtnombre.Text = "";
            txtapellidos.Text = "";
            txtnumero.Text = "";
            txtsexo.Text = "";
            ckbeca.Checked = false;
            txtcantidad.Text = "";

            txtnombre.Enabled = true;
            txtapellidos.Enabled = true;
            txtnumero.Enabled = true;
            txtsexo.Enabled = true;
            ckbeca.Enabled = true;
            txtcantidad.Enabled = true;

            btsiguiente.Enabled = false;
            btanterior.Enabled = false;
            btconfirmar.Enabled = true;
            btcancelar.Enabled = true;
        }

        //Boton guardar, para almacenar los registros llamando al metodo
        public void btguardar_Click(object sender, EventArgs e)
        {
            GuardarDatos();
        }

        //Metodo para guardar los datos en un .data
        public void GuardarDatos()
        {
            using (BinaryWriter writer = new BinaryWriter(File.OpenWrite("databank.data")))
            {
                foreach (matriculado persona in Lista)
                {
                    // Escribir los datos en el archivo
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

        //Imagen a bytes
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        //Bytes a imagen
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        //Boton cancelar
        private void btcancelar_Click(object sender, EventArgs e)
        {
            btcargarimg.Enabled = false;
            btcargarimg.Enabled = false;
            txtnombre.Enabled = false;
            txtapellidos.Enabled = false;
            txtnumero.Enabled = false;
            txtsexo.Enabled = false;
            ckbeca.Enabled = false;
            txtcantidad.Enabled = false;
            btsiguiente.Enabled = true;
            btanterior.Enabled = true;
            btconfirmar.Enabled = false;
            btcancelar.Enabled = false;
            inicio();
        }

        //Boton eliminar
        private void bteliminar_Click(object sender, EventArgs e)
        {
            Lista.RemoveAt(indiceactual);
            if (indiceactual == 0)
            {
                btsiguiente.Enabled = true;
                btanterior.Enabled = false;
            }
            if (indiceactual == Lista.Count - 1)
            {
                btsiguiente.Enabled = false;
                btanterior.Enabled = true;
            }
            if (indiceactual == Lista.Count)
            {
                indiceactual--;
            }
            inicio();
        }

        //Boton modificar, activa el booleano  y desactiva los botones inecesarios en la modificacion.
        private void btmodificar_Click(object sender, EventArgs e)
        {
            crear = false;
            btcargarimg.Enabled = true;

            txtnombre.Enabled = true;
            txtapellidos.Enabled = true;
            txtnumero.Enabled = true;
            txtsexo.Enabled = true;
            ckbeca.Enabled = true;
            txtcantidad.Enabled = true;

            btsiguiente.Enabled = false;
            btanterior.Enabled = false;
            btconfirmar.Enabled = true;
            btcancelar.Enabled = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtnombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }



        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
        

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
        
    }


}