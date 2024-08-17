using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Dto.Livro;
using WebAPI.Models;
using WebAPI.Services.Livro;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        public ILivroInterface _livroInterface { get; set; }
        public LivroController(ILivroInterface livroInterface)
        {
            _livroInterface = livroInterface;
        }

        [HttpGet("BuscarLivroPorId/{IdLivro}")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarLivroPorId(int IdLivro)
        {
            var livro = await _livroInterface.BuscarLivroPorId(IdLivro);
            return Ok(livro);
        }

        [HttpGet("ListarLivros")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> ListarLivros()
        {
            var livros = await _livroInterface.ListarLivros();
            return Ok(livros);
        }
        [HttpGet("BuscarLivroPorIdAutor/{IdAutor}")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarLivroPorIdAutor(int IdAutor)
        {
            var livros = await _livroInterface.BuscarLivroPorIdAutor(IdAutor);
            return Ok(livros);
        }
        [HttpPost("CriarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> CriarLivro(LivroCriacaoDto livroCriacaoDto)
        {
            var livro = await _livroInterface.CriarLivro(livroCriacaoDto);
            return Ok(livro);
        }
        [HttpPut("EditarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> EditarLivro(LivroEdicaoDto livroEdicaoDto)
        {
            var livro = await _livroInterface.EditarLivro(livroEdicaoDto);
            return Ok(livro);
        }

        [HttpDelete("DeletarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ExcluirLivro(int IdLivro)
        {
            var livro = await _livroInterface.ExcluirLivro(IdLivro);
            return Ok(livro);
        }
    }
}

