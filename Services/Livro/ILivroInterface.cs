using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services.Livro
{
    public interface ILivroInterface
    {
        Task<ResponseModel<List<LivroModel>>> ListarLivros();
        Task<ResponseModel<LivroModel>> BuscarLivroPorId(int IdLivro);
        Task<ResponseModel<LivroModel>> BuscarLivroPorIdAutor(int IdAutor);
        Task<ResponseModel<List<LivroModel>>> CriarLivro();
        Task<ResponseModel<List<LivroModel>>> EditarLivro();
        Task<ResponseModel<List<LivroModel>>> ExcluirLivro();


    }
}
