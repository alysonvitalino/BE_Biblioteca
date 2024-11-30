using BE_Biblioteca.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_Biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControladorLivros : ControllerBase
    {
        private static List<ModeloLivro> listaLivros = new List<ModeloLivro>
        {
            new ModeloLivro
            {
                Id = 1,
                Titulo = "Dom Casmurro",
                Autor = "Machado de Assis",
                Ano = 1899,
                Quantidade = 2,   
                Capa = "URL AQ",
            },
            new ModeloLivro
            {
                Id = 2,
                Titulo = "Memórias Póstumas de Brás Cubas",
                Autor = "Machado de Assis",
                Ano = 1881,
                Quantidade = 3,
                Capa = "URL AQ",
            },
            new ModeloLivro
            {
                Id = 3,
                Titulo = "Grande Sertão: Veredas",
                Autor = "João Guimarães Rosa",
                Ano = 1956,
                Quantidade = 4,
                Capa = "URL AQ",
            },
            new ModeloLivro
            {
                Id = 4,
                Titulo = "O Cortiço",
                Autor = "Aluísio Azevedo",
                Ano = 1890,
                Quantidade = 4,
                Capa = "URL AQ",
            },
            new ModeloLivro
            {
                Id = 5,
                Titulo = "Iracema",
                Autor = "José de Alencar",
                Ano = 1865,
                Quantidade = 1,
                Capa = "URL AQ",
            },
            new ModeloLivro
            {
                Id = 6,
                Titulo = "Macunaíma",
                Autor = "Mário de Andrade",
                Ano = 1928,
                Quantidade = 11,
                Capa = "URL AQ",
            },
            new ModeloLivro
            {
                Id = 7,
                Titulo = "Capitães da Areia",
                Autor = "Jorge Amado",
                Ano = 1937,
                Quantidade = 2,
                Capa = "URL AQ",
            },
            new ModeloLivro
            {
                Id = 8,
                Titulo = "Vidas Secas",
                Autor = "Graciliano Ramos",
                Ano = 1938,
                Quantidade = 9,
                Capa = "URL AQ",
            },
            new ModeloLivro
            {
                Id = 9,
                Titulo = "A Moreninha",
                Autor = "Joaquim Manuel de Macedo",
                Ano = 1844,
                Quantidade = 2,
                Capa = "URL AQ",
            },
            new ModeloLivro
            {
                Id = 10,
                Titulo = "O Tempo e o Vento",
                Autor = "Erico Verissimo",
                Ano = 1949,
                Quantidade = 1,
                Capa = "URL AQ",
            },
            new ModeloLivro
            {
                Id = 11,
                Titulo = "A Hora da Estrela",
                Autor = "Clarice Lispector",
                Ano = 1977,
                Quantidade = 1,
                Capa = "URL AQ",
            },
            new ModeloLivro
            {
                Id = 12,
                Titulo = "O Quinze",
                Autor = "Rachel de Queiroz",
                Ano = 1930,
                Quantidade = 1,
                Capa = "URL AQ",
            },
            new ModeloLivro
            {
                Id = 13,
                Titulo = "Menino do Engenho",
                Autor = "José Lins do Rego",
                Ano = 1932,
                Quantidade = 5,
                Capa = "URL AQ",
            },
            new ModeloLivro
            {
                Id = 14,
                Titulo = "Sagarana",
                Autor = "João Guimarães Rosa",
                Ano = 1946,
                Quantidade = 3,
                Capa = "URL AQ",
            },
            new ModeloLivro
            {
                Id = 15,
                Titulo = "Fogo Morto",
                Autor = "José Lins do Rego",
                Ano = 1943,
                Quantidade = 1,
                Capa = "URL AQ",
            },
        };

        [HttpGet]
        public ActionResult<List<ModeloLivro>> ListarLivros()
        {
            return Ok(listaLivros);
        }

        [HttpPost]
        public ActionResult<List<ModeloLivro>> AdicionarLivro(ModeloLivro novo)
        {
            if (novo.Id == 0 && listaLivros.Count > 0)
                novo.Id = listaLivros[listaLivros.Count - 1].Id + 1;

            listaLivros.Add(novo);
            return Ok(listaLivros);
        }

        [HttpGet("{id}")]
        public ActionResult<ModeloLivro> BuscaLivro(int id)
        {
            var busca = listaLivros.Find(x => x.Id == id);

            if (busca is null)
                return NotFound("Este personagem não foi encontrado");

            return Ok(busca);
        }
    }
}
