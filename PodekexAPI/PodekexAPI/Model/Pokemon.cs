using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PodekexAPI.Model
{
    public class Pokemon
    {
        [JsonIgnore]
        public string Id { get; set; }
        public int Pokedex_index { get; set; }
        public string Name { get; set; }
        public int Hp { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpecialAttack { get; set; }
        public int SpecialDefense { get; set; }
        public int Speed { get; set; }
        public int Generation { get; set; }
        public string Type { get; set; }


    }

    public class PokemonValidator : AbstractValidator<Pokemon>
    {
        public PokemonValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Pokedex_index).NotEmpty();
            RuleFor(x => x.Pokedex_index).NotNull();
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Hp).NotNull();
            RuleFor(x => x.Hp).NotEmpty();
            RuleFor(x => x.Attack).NotNull();
            RuleFor(x => x.Attack).NotEmpty();
            RuleFor(x => x.Defense).NotNull();
            RuleFor(x => x.Defense).NotEmpty();
            RuleFor(x => x.SpecialAttack).NotNull();
            RuleFor(x => x.SpecialAttack).NotEmpty();
            RuleFor(x => x.SpecialDefense).NotNull();
            RuleFor(x => x.SpecialDefense).NotEmpty();
            RuleFor(x => x.Speed).NotNull();
            RuleFor(x => x.Speed).NotEmpty();
            RuleFor(x => x.Generation).NotNull();
            RuleFor(x => x.Generation).NotEmpty();

            RuleFor(x => x.Name).MaximumLength(26);
            RuleFor(x => x.Hp).InclusiveBetween(1, 255);
            RuleFor(x => x.Attack).InclusiveBetween(5, 190);
            RuleFor(x => x.Defense).InclusiveBetween(5, 230);
            RuleFor(x => x.SpecialAttack).InclusiveBetween(10, 194);
            RuleFor(x => x.SpecialDefense).InclusiveBetween(20, 230);
            RuleFor(x => x.Speed).InclusiveBetween(5, 180);
            RuleFor(x => x.Generation).InclusiveBetween(1, 6);
        }
    }

}
