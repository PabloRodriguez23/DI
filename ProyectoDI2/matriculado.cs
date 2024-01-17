namespace ProyectoDI2;

public class matriculado
{
    //atributos
    public string? nombre { get; set; }
    public string? apellido { get; set; }
    public int numero { get; set; }
    public char genero { get; set; }
    public bool beca { get; set; }
    public float cantidadbeca { get; set; }
    public byte[] foto { get; set; }

//constructor
    public matriculado(string no,string a,int nu,char g, bool b,float c, byte[] foto)
    {
        this.nombre = no;
        this.apellido = a;
        this.numero = nu;
        this.genero = g;
        this.beca = b;
        this.cantidadbeca = c;
        this.foto = foto;
    }
}