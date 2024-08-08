using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Services.Autor
{
    public class AutorService : IAutorInterface
    {
        private readonly AppDbContext _context;
        public AutorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<AutorModel>> BuscarAutorPorId(int IdAutor)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();

            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == IdAutor);

                if (string.IsNullOrEmpty(autor.ToString()))
                {
                    resposta.Mensagem = "Nenhum Autor Localizado";
                    return resposta;
                }

                resposta.Dados = autor;
                resposta.Mensagem = "Autor Localizado";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int IdLivro)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();

            try
            {
                var livro = await _context.Livros
                    .Include(a => a.Autor)
                    .FirstOrDefaultAsync(livroBanco => livroBanco.Id == IdLivro);

                if (livro == null)
                {
                    resposta.Mensagem = "Autor não encontrado";
                    return resposta;
                }

                resposta.Dados = livro.Autor;
                resposta.Mensagem = "Autor Encontrado";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;

            }
        }

        public async Task<ResponseModel<List<AutorModel>>> ListarAutores()
        {
            ResponseModel <List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            {
                var autores = await _context.Autores.ToListAsync();
                resposta.Dados = autores;
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
