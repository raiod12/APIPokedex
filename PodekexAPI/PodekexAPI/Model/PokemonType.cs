using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PodekexAPI.Model
{
    public class PokemonType
    {
        public string Id { get; set; }
        public string PokemonId { get; set; }
        public string TypeId { get; set; }
    }
        public class PokemonTypeValidator : AbstractValidator<PokemonType>
        {

            public PokemonTypeValidator()
            {
                RuleFor(x => x.Id).NotNull();
                RuleFor(x => x.Id).NotEmpty();
                RuleFor(x => x.PokemonId).NotNull();
                RuleFor(x => x.PokemonId).NotEmpty();
                RuleFor(x => x.TypeId).NotNull();
                RuleFor(x => x.TypeId).NotEmpty();
                RuleFor(x => x.Id).Length(36);
                RuleFor(x => x.PokemonId).Length(36);
                RuleFor(x => x.TypeId).Length(36);
            }
        }
}
