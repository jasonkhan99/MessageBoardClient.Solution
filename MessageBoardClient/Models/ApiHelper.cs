using System.Threading.Tasks;
using RestSharp;

namespace MessageBoardClient.Models
{
  class ApiHelper
  {
    public static async Task<<string>> GetAll(string requestAddress)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"{requestAddress}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> GetDetails(string requestAddress)
    {
      RestClient client = new RestClient("Http://localhost:5000/api");
      RestRequest request = new RestRequest($"{requestAddress}", Method.GET);

      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
    
  }
}
