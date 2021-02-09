using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Npgsql;

namespace PodekexAPI.Model
{
    public class PokemonRepository
    {
        
        private string connectionString;
        public PokemonRepository()
        {
            connectionString = @"Host=localhost;Username=Access;Password=teste123;Database=db_pokedex";
        }

        public IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(connectionString);
            }
        }

        public void Add(Pokemon pokemon)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string sql = @"SELECT id, type FROM types WHERE type = @Type";
                Type typecheck = dbConnection.Query<Type>(sql, new { type = pokemon.Type }).FirstOrDefault();

                if (typecheck.Id != null)
                {
                    Guid g = Guid.NewGuid();
                    pokemon.Id = g.ToString();
                    sql = @"INSERT INTO pokemons (id, pokedex_index, name, hp, attack, defense, special_attack, special_defense, speed, generation) VALUES(@Id, @Pokedex_index, @Name, @Hp, @Attack, @Defense, @SpecialAttack, @SpecialDefense, @Speed, @Generation);";
                    dbConnection.Execute(sql, pokemon);
                    PokemonType pokemontype = new PokemonType();
                    pokemontype.PokemonId = pokemon.Id;
                    pokemontype.TypeId = typecheck.Id;
                    g = Guid.NewGuid();
                    pokemontype.Id = g.ToString();
                    sql = @"INSERT INTO pokemon_types (id, pokemon_id, type_id) VALUES (@Id, @PokemonId, @TypeId)";
                    dbConnection.Execute(sql, pokemontype);
                }
            }
        }

        public IEnumerable<PokemonALL> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sql = @"SELECT p.id, p.name, p.pokedex_index, p.hp, p.attack, p.defense, p.special_attack, p.special_defense, p.speed, p.generation, t.type, 
                            (p.hp+p.attack+p.defense+p.special_attack+p.special_defense+p.speed) 
                            AS total FROM pokemons p
                            JOIN pokemon_types pt
                            ON (pt.pokemon_id = p.id)
                            JOIN types t
                            ON(t.id = pt.type_id);
                            ";
                return dbConnection.Query<PokemonALL>(sql);
            }
        }



    }
}
