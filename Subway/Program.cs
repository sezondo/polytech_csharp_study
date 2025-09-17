using Subway.Data;
using Subway.Models;
using Subway.Repository;

namespace Subway;

class Program
{
    static async Task Main(string[] args)
    {
        HttpClient httpClient = new HttpClient();
        ISubwayApiDataSource dataSource = new RemotePostDataSource(httpClient);
        ISubwayRepository postRepository = new PostRepository(dataSource);

        BarvlDt barvlDt = await postRepository.GetSubwayByNameAsync("서울");
        
        Console.Write(barvlDt);
        

    }
}