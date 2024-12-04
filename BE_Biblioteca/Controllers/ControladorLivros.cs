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
                QuantidadeEstoque = 2,
                Capa = "C:\\Users\\Aluno\\Desktop\\BE_Biblioteca\\BE_Biblioteca\\assets\\Dom_Casmurro.jpeg",
            },
            new ModeloLivro
            {
                Id = 2,
                Titulo = "Memórias Póstumas de Brás Cubas",
                Autor = "Machado de Assis",
                Ano = 1881,
                QuantidadeEstoque = 3,
                Capa = "C:\\Users\\Aluno\\Desktop\\BE_Biblioteca\\BE_Biblioteca\\assets\\Memorias_Postumas.webp",
            },
            new ModeloLivro
            {
                Id = 3,
                Titulo = "Grande Sertão: Veredas",
                Autor = "João Guimarães Rosa",
                Ano = 1956,
                QuantidadeEstoque = 4,
                Capa = "C:\\Users\\Aluno\\Desktop\\BE_Biblioteca\\BE_Biblioteca\\assets\\Grande_Sertao_Veredas.png",
            },
            new ModeloLivro
            {
                Id = 4,
                Titulo = "O Cortiço",
                Autor = "Aluísio Azevedo",
                Ano = 1890,
                QuantidadeEstoque = 4,
                Capa = "C:\\Users\\Aluno\\Desktop\\BE_Biblioteca\\BE_Biblioteca\\assets\\O_Cortiço.webp",
            },
            new ModeloLivro
            {
                Id = 5,
                Titulo = "Iracema",
                Autor = "José de Alencar",
                Ano = 1865,
                QuantidadeEstoque = 1,
                Capa = "C:\\Users\\Aluno\\Desktop\\BE_Biblioteca\\BE_Biblioteca\\assets\\Iracema.jpg",
            },
            new ModeloLivro
            {
                Id = 6,
                Titulo = "Macunaíma",
                Autor = "Mário de Andrade",
                Ano = 1928,
                QuantidadeEstoque = 11,
                Capa = "C:\\Users\\Aluno\\Desktop\\BE_Biblioteca\\BE_Biblioteca\\assets\\Macunaima.jpg",
            },
            new ModeloLivro
            {
                Id = 7,
                Titulo = "Capitães da Areia",
                Autor = "Jorge Amado",
                Ano = 1937,
                QuantidadeEstoque = 2,
                Capa = "C:\\Users\\Aluno\\Desktop\\BE_Biblioteca\\BE_Biblioteca\\assets\\Capitaes_De_Areia.png",
            },
            new ModeloLivro
            {
                Id = 8,
                Titulo = "Vidas Secas",
                Autor = "Graciliano Ramos",
                Ano = 1938,
                QuantidadeEstoque = 9,
                Capa = "C:\\Users\\Aluno\\Desktop\\BE_Biblioteca\\BE_Biblioteca\\assets\\Vidas_Secas.png",
            },
            new ModeloLivro
            {
                Id = 9,
                Titulo = "A Moreninha",
                Autor = "Joaquim Manuel de Macedo",
                Ano = 1844,
                QuantidadeEstoque = 2,
                Capa = "C:\\Users\\Aluno\\Desktop\\BE_Biblioteca\\BE_Biblioteca\\assets\\A_Moreninha.jpeg",
            },
            new ModeloLivro
            {
                Id = 10,
                Titulo = "O Tempo e o Vento",
                Autor = "Erico Verissimo",
                Ano = 1949,
                QuantidadeEstoque = 1,
                Capa = "C:\\Users\\Aluno\\Desktop\\BE_Biblioteca\\BE_Biblioteca\\assets\\O_Tempo_E_O_Vento.png",
            },
            new ModeloLivro
            {
                Id = 11,
                Titulo = "A Hora da Estrela",
                Autor = "Clarice Lispector",
                Ano = 1977,
                QuantidadeEstoque = 1,
                Capa = "C:\\Users\\Aluno\\Desktop\\BE_Biblioteca\\BE_Biblioteca\\assets\\A_Hora_da_Estrela.png",
            },
            new ModeloLivro
            {
                Id = 12,
                Titulo = "O Quinze",
                Autor = "Rachel de Queiroz",
                Ano = 1930,
                QuantidadeEstoque = 1,
                Capa = "C:\\Users\\Aluno\\Desktop\\BE_Biblioteca\\BE_Biblioteca\\assets\\O_Quinze.jpeg",
            },
            new ModeloLivro
            {
                Id = 13,
                Titulo = "Menino do Engenho",
                Autor = "José Lins do Rego",
                Ano = 1932,
                QuantidadeEstoque = 5,
                Capa = "C:\\Users\\Aluno\\Desktop\\BE_Biblioteca\\BE_Biblioteca\\assets\\Menino_De_Engenho.jpg",
            },
            new ModeloLivro
            {
                Id = 14,
                Titulo = "Sagarana",
                Autor = "João Guimarães Rosa",
                Ano = 1946,
                QuantidadeEstoque = 3,
                Capa = "C:\\Users\\Aluno\\Desktop\\BE_Biblioteca\\BE_Biblioteca\\assets\\Sagarana.jpg",
            },
            new ModeloLivro
            {
                Id = 15,
                Titulo = "Fogo Morto",
                Autor = "José Lins do Rego",
                Ano = 1943,
                QuantidadeEstoque = 1,
                Capa = "C:\\Users\\Aluno\\Desktop\\BE_Biblioteca\\BE_Biblioteca\\assets\\Fogo_Morto.jpg",
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
        [HttpPost("alugar/{id}")]
        public ActionResult<List<ModeloLivro>> AlugarLivro(int id, ModeloLivro editar)
        {
            var busca = listaLivros.Find(x => x.Id == id);

            if (busca is null)
                return NotFound("Livro não encontrado");

            busca.Titulo = editar.Titulo == "" || editar.Titulo == "string" ? busca.Titulo : editar.Titulo;
            busca.Ano = editar.Ano == 0 ? busca.Ano : editar.Ano;
            busca.Autor = editar.Autor == "" || editar.Autor == "string" ? busca.Autor : editar.Autor;
            busca.QuantidadeEstoque = editar.QuantidadeEstoque == 0 ? busca.QuantidadeEstoque : editar.QuantidadeEstoque;

            if (busca.QuantidadeEstoque == 0)
                return Ok("Sem livros no estoque para o empréstimo!");

            busca.QuantidadeEstoque = busca.QuantidadeEstoque - 1;
            busca.QuantidadeEmprestada = busca.QuantidadeEmprestada + 1;

            return Ok(busca);
        }
        [HttpPost("devolucao/{id}")]
        public ActionResult<List<ModeloLivro>> DevolverLivro(int id, ModeloLivro editar)
        {
            var busca = listaLivros.Find(x => x.Id == id);

            if (busca is null)
                return NotFound("Livro não encontrado");

            busca.Titulo = editar.Titulo == "" || editar.Titulo == "string" ? busca.Titulo : editar.Titulo;
            busca.Ano = editar.Ano == 0 ? busca.Ano : editar.Ano;
            busca.Autor = editar.Autor == "" || editar.Autor == "string" ? busca.Autor : editar.Autor;
            busca.QuantidadeEstoque = editar.QuantidadeEstoque == 0 ? busca.QuantidadeEstoque : editar.QuantidadeEstoque;

            if (busca.QuantidadeEmprestada == 0)
                return Ok("Sem livros emprestados para a devolução!");

            busca.QuantidadeEstoque = busca.QuantidadeEstoque + 1;
            busca.QuantidadeEmprestada = busca.QuantidadeEmprestada - 1;

            return Ok(busca);
        }
    }
}
