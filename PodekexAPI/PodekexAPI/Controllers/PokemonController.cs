using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PodekexAPI.Model;

namespace PodekexAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly PokemonRepository pokemonRepository;
        public PokemonController()
        {
            pokemonRepository = new PokemonRepository();
        }

        [HttpPost("CadastrarPokemon")]
        public ActionResult Post([FromBody] Pokemon pokemon)
        {
            var validator = new PokemonValidator();
            var result = validator.Validate(pokemon);
            if (ModelState.IsValid)
            {
                pokemonRepository.Add(pokemon);
                return Ok();
            }
            return BadRequest(result.Errors);
        }

        [HttpGet("BuscaTodos")]
        public IActionResult Get()
        {
            return Ok(pokemonRepository.GetAll());
        }

    }
}
