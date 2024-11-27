namespace WebApplication1.Models
{
    public class Imovel
    {
        public int Codigo { get; set; }
        public string Foto { get; set; }
        public string Tipo { get; set; }
        public double Valor { get; set; }
		public string Desc { get; internal set; }
	}
}
