using CsharpStudy.HttpStudy.Common;
using CsharpStudy.HttpStudy.Data;
using CsharpStudy.HttpStudy.DTO;
using CsharpStudy.HttpStudy.Mapper;

namespace CsharpStudy.HttpStudy.Repository;

public class PostRepository : IPokemonRepository
{
    private IPokemonApiDataSource<Pokemon> _dataSource;
    
    public PostRepository(IPokemonApiDataSource<Pokemon> dataSource)
    {
        _dataSource = dataSource;
    }

    public async Task<Result<Pokemon, PokemonError>> GetPokemonByNameAsync(string pokemonName)    
    {
        if (string.IsNullOrWhiteSpace(pokemonName))
        {
            return new Result<Pokemon, PokemonError>.Error(PokemonError.InvalidInput);
        }
        
        try
        {
            var response = await _dataSource.GetPokemonAsync(pokemonName);

            switch (response.StatusCode)
            {
                case 200:
                    var dto = response.Body;
                    Pokemon pokemon = Manpper.ToModel(dto);
                    return new Result<Pokemon, PokemonError>.Success(pokemon);
                case 404:
                    return new Result<Pokemon, PokemonError>.Error(PokemonError.NotFound);
                default:
                    return new Result<Pokemon, PokemonError>.Error(PokemonError.UnknownError);
            }
        }
        catch (Exception e)
        {
            return null;
        }
    }
}

