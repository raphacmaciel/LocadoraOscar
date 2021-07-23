using AutoMapper;
using LocadoraOscar.API.DTO;
using LocadoraOscar.API.Models;
using LocadoraOscar.API.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocadoraOscar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IRepositoryBase _repo;
        private readonly IMapper _mapper;

        public FilmeController(IRepositoryBase repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <summary>
        /// Método responsável por retornar todos os filmes.
        /// </summary>
        /// <returns></returns>
        // GET: api/<FilmeController>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var filmes = await _repo.ObterTodosFilmesAsync();
                var filmesRetorno = _mapper.Map<IEnumerable<FilmeDTO>>(filmes);
                return Ok(filmesRetorno);
            }
            catch (System.Exception)
            {
                return BadRequest("Não foi possível verificar os filmes.");
            }
        }

        /// <summary>
        /// Método responsável por retornar o filme com Id informado.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/<FilmeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                var filme = await _repo.ObterFilmePorIdAsync(id);
                if (filme == null) return BadRequest("Filme não encontrado.");
                var filmeDTO = _mapper.Map<FilmeDTO>(filme);
                return Ok(filmeDTO);
            }
            catch (System.Exception)
            {
                return BadRequest("Não foi possível verificar o filme.");
            }

        }

        /// <summary>
        /// Método responsável por adicionar um novo filme.
        /// </summary>
        /// <param name="filmeNovo"></param>
        /// <returns></returns>
        // POST api/<FilmeController>
        [HttpPost]
        public async Task<IActionResult> PostAsync(FilmeRegistroDTO filmeNovo)
        {
            try
            {
                var filme = _mapper.Map<Filme>(filmeNovo);
                _repo.Add(filme);
                if (_repo.SaveChanges())
                {
                    var filmeCriado = await _repo.ObterFilmePorIdAsync(filme.Id);
                    return Created($"/api/filme/{filmeCriado.Id}", _mapper.Map<FilmeDTO>(filmeCriado));
                }
                return BadRequest("Não foi possível cadastrar o filme.");
            }
            catch (System.Exception)
            {
                return BadRequest("Não foi possível registrar o filme.");
            }
        }

        /// <summary>
        /// Método responsável por alterar um filme cadastrado.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="filmeEditado"></param>
        /// <returns></returns>
        // PUT api/<FilmeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, FilmeEdicaoDTO filmeEditado)
        {
            try
            {
                var filmeEscolhido = await _repo.ObterFilmePorIdAsync(id);
                if (filmeEscolhido == null) return BadRequest("Filme não encontrado.");
                var filme = _mapper.Map<Filme>(filmeEditado);
                _repo.Update(filme);
                if (_repo.SaveChanges()) return Ok(_mapper.Map<FilmeDTO>(filme));

            }
            catch (System.Exception)
            {
                return BadRequest("Não foi possível editar o filme.");
            }

            return BadRequest("Não foi possível editar o filme.");
        }

        /// <summary>
        /// Método responsável por apagar o registro de um filme de acordo com o Id passado.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE api/<FilmeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var filmeEscolhido = await _repo.ObterFilmePorIdAsync(id);
                if (filmeEscolhido == null) return BadRequest("Filme não encontrado");
                _repo.Delete(filmeEscolhido);
                if (_repo.SaveChanges()) return Ok("Filme deletado com sucesso.");
            }
            catch (System.Exception)
            {
                return BadRequest("Não foi possível deletar o filme.");
            }
            return BadRequest("Não foi possível deletar o filme.");
        }

        /// <summary>
        /// Método responsável por apagar o registro de vários filmes de acordo com o Id passado.
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        // DELETE api/<FilmeController>/
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(IEnumerable<int> ids)
        {
            try
            {
                string idsRemovidos = "Os filmes com os seguintes ID's foram removidos:";
                var filmes = await _repo.ObterTodosFilmesAsync();
                foreach (var id in ids)
                {
                    foreach (var filme in filmes)
                    {
                        if (filme.Id == id)
                        {
                            _repo.Delete(filme);
                            idsRemovidos += $" {id},";
                        }
                    }
                }
                idsRemovidos = idsRemovidos.Remove(idsRemovidos.Length - 1);
                idsRemovidos += ".";
                if (_repo.SaveChanges()) return Ok(idsRemovidos);
                return BadRequest("Não foi possível deletar os filmes.");
            }
            catch (System.Exception)
            {
                return BadRequest("Não foi possível deletar os filmes.");
            }
        }
    }
}
