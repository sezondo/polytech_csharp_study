using System.Net.Http;
using System.Threading.Tasks;
using CsharpStudy.HttpStudy.Common;
using CsharpStudy.HttpStudy.Data;
using CsharpStudy.HttpStudy.DTO;
using CsharpStudy.HttpStudy.Mapper;
using CsharpStudy.HttpStudy.Repository;
using NUnit.Framework;

namespace CsharpStudy.Game.Tests.Repository;

[TestFixture]
[TestOf(typeof(PostRepository))]
public class PostRepositoryTest
{
    
    [Test]
    public async Task PokemonTest()
    {
        HttpClient httpClient = new HttpClient();
        IPokemonApiDataSource dataSource = new RemotePostDataSource(httpClient); //데이터 만들기
        IPokemonRepository postRepository = new PostRepository(dataSource); //레포 생성
        
        Result<Pokemon, PokemonError> pokemon = await postRepository.GetPokemonByNameAsync("dittooo"); // GetPokemonByNameAsync 함수 실행해서 데이터를 DTO로 넣음
        
        //Assert.That(pokemon, Is.True);
        Assert.That(pokemon is Result<Pokemon, PokemonError>.Error(PokemonError.NotFound), Is.True);
    }
    
}