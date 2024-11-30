namespace BE_Biblioteca.Models
{
    public class ModeloLivro
    {
        public int Id {  get; set; }
        public string Titulo { get; set; } = string.Empty;
        public int Ano { get; set; }
        public string Autor { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public string Capa { get; set; } = string.Empty;
    }
}
