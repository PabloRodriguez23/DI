namespace Proyecto_forms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblnombre = new Label();
            lblapellido = new Label();
            lblnumero = new Label();
            lblsexo = new Label();
            lbltrabaja = new Label();
            btsiguiente = new Button();
            btanterior = new Button();
            btcrear = new Button();
            btmodificar = new Button();
            btconfirmar = new Button();
            btcancelar = new Button();
            txtnombre = new TextBox();
            txtapellidos = new TextBox();
            txtnumero = new TextBox();
            txtsexo = new TextBox();
            lbltitulo = new Label();
            lblcantidad = new Label();
            txtcantidad = new TextBox();
            ckbeca = new CheckBox();
            img = new PictureBox();
            pb = new PictureBox();
            bteliminar = new Button();
            btcargarimg = new Button();
            openFileDialog1 = new OpenFileDialog();
            pictureBox2 = new PictureBox();
            lblregistro = new Label();
            lblnregistros = new Label();
            btguardar = new Button();
            ((System.ComponentModel.ISupportInitialize)img).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // lblnombre
            // 
            lblnombre.AutoSize = true;
            lblnombre.BackColor = SystemColors.Window;
            lblnombre.Location = new Point(79, 185);
            lblnombre.Name = "lblnombre";
            lblnombre.Size = new Size(105, 15);
            lblnombre.TabIndex = 0;
            lblnombre.Text = "Nombre..................";
            lblnombre.Click += label1_Click;
            // 
            // lblapellido
            // 
            lblapellido.AutoSize = true;
            lblapellido.BackColor = SystemColors.Window;
            lblapellido.Location = new Point(79, 220);
            lblapellido.Name = "lblapellido";
            lblapellido.Size = new Size(107, 15);
            lblapellido.TabIndex = 1;
            lblapellido.Text = "Apellidos.................";
            // 
            // lblnumero
            // 
            lblnumero.AutoSize = true;
            lblnumero.BackColor = SystemColors.Window;
            lblnumero.Location = new Point(79, 256);
            lblnumero.Name = "lblnumero";
            lblnumero.Size = new Size(108, 15);
            lblnumero.TabIndex = 2;
            lblnumero.Text = "Numero...................";
            lblnumero.Click += label3_Click;
            // 
            // lblsexo
            // 
            lblsexo.AutoSize = true;
            lblsexo.BackColor = SystemColors.Window;
            lblsexo.Location = new Point(79, 294);
            lblsexo.Name = "lblsexo";
            lblsexo.Size = new Size(107, 15);
            lblsexo.TabIndex = 3;
            lblsexo.Text = "Sexo(M/F)...............";
            // 
            // lbltrabaja
            // 
            lbltrabaja.AutoSize = true;
            lbltrabaja.BackColor = SystemColors.Window;
            lbltrabaja.Location = new Point(79, 330);
            lbltrabaja.Name = "lbltrabaja";
            lbltrabaja.Size = new Size(109, 15);
            lbltrabaja.TabIndex = 4;
            lbltrabaja.Text = "Solicita beca............";
            lbltrabaja.Click += label8_Click;
            // 
            // btsiguiente
            // 
            btsiguiente.Location = new Point(384, 419);
            btsiguiente.Name = "btsiguiente";
            btsiguiente.Size = new Size(75, 23);
            btsiguiente.TabIndex = 8;
            btsiguiente.Text = "Siguiente";
            btsiguiente.UseVisualStyleBackColor = true;
            btsiguiente.Click += btsiguiente_Click;
            // 
            // btanterior
            // 
            btanterior.Location = new Point(129, 419);
            btanterior.Name = "btanterior";
            btanterior.Size = new Size(75, 23);
            btanterior.TabIndex = 9;
            btanterior.Text = "Anterior";
            btanterior.UseVisualStyleBackColor = true;
            btanterior.Click += btanterior_Click;
            // 
            // btcrear
            // 
            btcrear.Location = new Point(258, 419);
            btcrear.Name = "btcrear";
            btcrear.Size = new Size(75, 23);
            btcrear.TabIndex = 10;
            btcrear.Text = "Crear";
            btcrear.UseVisualStyleBackColor = true;
            btcrear.Click += btcrear_Click;
            // 
            // btmodificar
            // 
            btmodificar.Location = new Point(258, 475);
            btmodificar.Name = "btmodificar";
            btmodificar.Size = new Size(75, 23);
            btmodificar.TabIndex = 11;
            btmodificar.Text = "Modificar";
            btmodificar.UseVisualStyleBackColor = true;
            btmodificar.Click += btmodificar_Click;
            // 
            // btconfirmar
            // 
            btconfirmar.Location = new Point(384, 475);
            btconfirmar.Name = "btconfirmar";
            btconfirmar.Size = new Size(75, 23);
            btconfirmar.TabIndex = 12;
            btconfirmar.Text = "Confirmar";
            btconfirmar.UseVisualStyleBackColor = true;
            btconfirmar.Click += btconfirmar_Click;
            // 
            // btcancelar
            // 
            btcancelar.Location = new Point(129, 475);
            btcancelar.Name = "btcancelar";
            btcancelar.Size = new Size(75, 23);
            btcancelar.TabIndex = 13;
            btcancelar.Text = "Cancelar";
            btcancelar.UseVisualStyleBackColor = true;
            btcancelar.Click += btcancelar_Click;
            // 
            // txtnombre
            // 
            txtnombre.Location = new Point(195, 182);
            txtnombre.Name = "txtnombre";
            txtnombre.Size = new Size(100, 23);
            txtnombre.TabIndex = 14;
            txtnombre.TextChanged += txtnombre_TextChanged;
            // 
            // txtapellidos
            // 
            txtapellidos.Location = new Point(195, 217);
            txtapellidos.Name = "txtapellidos";
            txtapellidos.Size = new Size(100, 23);
            txtapellidos.TabIndex = 15;
            // 
            // txtnumero
            // 
            txtnumero.Location = new Point(195, 253);
            txtnumero.Name = "txtnumero";
            txtnumero.Size = new Size(100, 23);
            txtnumero.TabIndex = 16;
            // 
            // txtsexo
            // 
            txtsexo.Location = new Point(195, 291);
            txtsexo.Name = "txtsexo";
            txtsexo.Size = new Size(100, 23);
            txtsexo.TabIndex = 17;
            // 
            // lbltitulo
            // 
            lbltitulo.AutoSize = true;
            lbltitulo.Location = new Point(235, 11);
            lbltitulo.Name = "lbltitulo";
            lbltitulo.Size = new Size(133, 15);
            lbltitulo.TabIndex = 22;
            lbltitulo.Text = "Matricula IES El Majuelo";
            // 
            // lblcantidad
            // 
            lblcantidad.AutoSize = true;
            lblcantidad.BackColor = SystemColors.Window;
            lblcantidad.Location = new Point(79, 365);
            lblcantidad.Name = "lblcantidad";
            lblcantidad.Size = new Size(113, 15);
            lblcantidad.TabIndex = 5;
            lblcantidad.Text = "Cantidad concedida";
            lblcantidad.Click += label7_Click;
            // 
            // txtcantidad
            // 
            txtcantidad.Location = new Point(195, 362);
            txtcantidad.Name = "txtcantidad";
            txtcantidad.Size = new Size(100, 23);
            txtcantidad.TabIndex = 19;
            // 
            // ckbeca
            // 
            ckbeca.AutoSize = true;
            ckbeca.Location = new Point(195, 333);
            ckbeca.Name = "ckbeca";
            ckbeca.Size = new Size(15, 14);
            ckbeca.TabIndex = 23;
            ckbeca.UseVisualStyleBackColor = true;
            // 
            // img
            // 
            img.Image = Properties.Resources.majuelo;
            img.Location = new Point(235, 45);
            img.Name = "img";
            img.Size = new Size(133, 102);
            img.SizeMode = PictureBoxSizeMode.StretchImage;
            img.TabIndex = 24;
            img.TabStop = false;
            img.Click += pictureBox1_Click;
            // 
            // pb
            // 
            pb.Location = new Point(371, 182);
            pb.Name = "pb";
            pb.Size = new Size(180, 163);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.TabIndex = 25;
            pb.TabStop = false;
            pb.Click += pictureBox1_Click_1;
            // 
            // bteliminar
            // 
            bteliminar.Location = new Point(258, 536);
            bteliminar.Name = "bteliminar";
            bteliminar.Size = new Size(75, 23);
            bteliminar.TabIndex = 26;
            bteliminar.Text = "Eliminar";
            bteliminar.UseVisualStyleBackColor = true;
            bteliminar.Click += bteliminar_Click;
            // 
            // btcargarimg
            // 
            btcargarimg.Location = new Point(423, 357);
            btcargarimg.Name = "btcargarimg";
            btcargarimg.Size = new Size(75, 23);
            btcargarimg.TabIndex = 27;
            btcargarimg.Text = "Cargar";
            btcargarimg.UseVisualStyleBackColor = true;
            btcargarimg.Click += btcargarimg_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.FileOk += openFileDialog1_FileOk;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.fondo;
            pictureBox2.Location = new Point(-8, -26);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(624, 657);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 28;
            pictureBox2.TabStop = false;
            // 
            // lblregistro
            // 
            lblregistro.AutoSize = true;
            lblregistro.BackColor = SystemColors.Window;
            lblregistro.Location = new Point(410, 544);
            lblregistro.Name = "lblregistro";
            lblregistro.Size = new Size(88, 15);
            lblregistro.TabIndex = 29;
            lblregistro.Text = "Nº de registros:";
            lblregistro.Click += label1_Click_1;
            // 
            // lblnregistros
            // 
            lblnregistros.AutoSize = true;
            lblnregistros.BackColor = SystemColors.Window;
            lblnregistros.Location = new Point(494, 544);
            lblnregistros.Name = "lblnregistros";
            lblnregistros.Size = new Size(13, 15);
            lblnregistros.TabIndex = 30;
            lblnregistros.Text = "0";
            // 
            // btguardar
            // 
            btguardar.Location = new Point(129, 536);
            btguardar.Name = "btguardar";
            btguardar.Size = new Size(75, 23);
            btguardar.TabIndex = 31;
            btguardar.Text = "Guardar";
            btguardar.UseVisualStyleBackColor = true;
            btguardar.Click += btguardar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(596, 593);
            Controls.Add(btguardar);
            Controls.Add(lblnregistros);
            Controls.Add(lblregistro);
            Controls.Add(btcargarimg);
            Controls.Add(bteliminar);
            Controls.Add(pb);
            Controls.Add(img);
            Controls.Add(ckbeca);
            Controls.Add(lbltitulo);
            Controls.Add(txtcantidad);
            Controls.Add(txtsexo);
            Controls.Add(txtnumero);
            Controls.Add(txtapellidos);
            Controls.Add(txtnombre);
            Controls.Add(btcancelar);
            Controls.Add(btconfirmar);
            Controls.Add(btmodificar);
            Controls.Add(btcrear);
            Controls.Add(btanterior);
            Controls.Add(btsiguiente);
            Controls.Add(lblcantidad);
            Controls.Add(lbltrabaja);
            Controls.Add(lblsexo);
            Controls.Add(lblnumero);
            Controls.Add(lblapellido);
            Controls.Add(lblnombre);
            Controls.Add(pictureBox2);
            KeyPreview = true;
            Name = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)img).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblnombre;
        private Label lblapellido;
        private Label lblnumero;
        private Label lblsexo;
        private Label lbltrabaja;
        private Button btsiguiente;
        private Button btanterior;
        private Button btcrear;
        private Button btmodificar;
        private Button btconfirmar;
        private Button btcancelar;
        private TextBox txtnombre;
        private TextBox txtapellidos;
        private TextBox txtnumero;
        private TextBox txtsexo;
        private Label lbltitulo;
        private Label lblcantidad;
        private TextBox txtcantidad;
        private CheckBox ckbeca;
        private PictureBox img;
        private PictureBox pb;
        private Button bteliminar;
        private Button btcargarimg;
        private OpenFileDialog openFileDialog1;
        private PictureBox pictureBox2;
        private Label lblregistro;
        private Label lblnregistros;
        private Button btguardar;
    }
}