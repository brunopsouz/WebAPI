using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Dto.Autor;
using WebAPI.Models;

namespace WebAPI.Services.Livro
{
    public class LivroService : ILivroInterface
    {
        private readonly AppDbContext _context;

        public LivroService(AppDbContext context)
        {
            _context = context;
        }

        public Task<ResponseModel<List<LivroModel>>> ListarLivros()
        {
            throw new NotImplementedException();
        }
        public async Task<ResponseModel<LivroModel>> BuscarLivroPorId(int IdLivro)
        {
            ResponseModel<LivroModel> resposta = new ResponseModel<LivroModel>();

            try
            {
                var livro = await _context.Livros.FirstOrDefaultAsync(livroBanco => livroBanco.Id == IdLivro);

                if (livro == null)
                {
                    resposta.Mensagem = "Não foi encontrado nenhum livro";
                    return resposta;
                }

                resposta.Dados = livro;
                resposta.Mensagem = "Encontrado Livro";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public Task<ResponseModel<LivroModel>> BuscarLivroPorIdAutor(int IdAutor)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<LivroModel>>> CriarLivro()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<LivroModel>>> EditarLivro()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<LivroModel>>> ExcluirLivro()
        {
            throw new NotImplementedException();
        }

       
    }
}
