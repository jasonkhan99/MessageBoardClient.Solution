using System.Threading.Tasks;
using RestSharp;

namespace MessageBoardClient.Models
{
  class ApiHelper
  {
    public static async Task<<string>> GetAll(string request)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"{request}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
  }
}

// http://localhost:5000/api/
// boards/1/threads

//GetAll(string request)

// GetAllBoards();
//GetAllPosts();