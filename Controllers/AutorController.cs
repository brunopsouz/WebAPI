using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Dto.Autor;
using WebAPI.Models;
using WebAPI.Services.Autor;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorInterface _autorInterface;

        public AutorController(IAutorInterface autorInterface)
        {
            _autorInterface = autorInterface;
        }

        [HttpGet("ListarAutores")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ListarAutores()
        {
            var autores = await _autorInterface.ListarAutores();
            return Ok(autores);
        }

        [HttpGet("BuscarAutorPorId/{IdAutor}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorId(int IdAutor)
        {
            var autor = await _autorInterface.BuscarAutorPorId(IdAutor);
            return Ok(autor);
        }

        [HttpGet("BuscarAutorPorIdLivro/{IdLivro}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorIdLivro(int IdLivro)
        {
            var autor = await _autorInterface.BuscarAutorPorIdLivro(IdLivro);
            return Ok(autor);
        }

        [HttpPost("CriarAutor")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> CriarAutor(AutorCriacaoDto autorCriacaoDto)
        {
            var autor = await _autorInterface.CriarAutor(autorCriacaoDto);
            return Ok(autorCriacaoDto);
        }

        [HttpPut("EditarAutor")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> EditarAutor(AutorEdicaoDto autorEdicaoDto)
        {
            var autor = await _autorInterface.EditarAutor(autorEdicaoDto);
            return Ok(autor);
        }

        [HttpDelete("DeletarAutor")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> DeletarAutor(int IdAutor)
        {
            var autor = await _autorInterface.DeletarAutor(IdAutor);
            return Ok(autor);
        }
    }
}
