using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Dto.Vinculos;
using WebAPI.Models;

namespace WebAPI.Dto.Livro
{
    public class LivroCriacaoDto
    {
        public string Titulo { get; set; }
        public AutorVinculoDto Autor { get; set; }
    }
}
