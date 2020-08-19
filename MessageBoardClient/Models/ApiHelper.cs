using System.Threading.Tasks;
using RestSharp;

namespace MessageBoardClient.Models
{
  class ApiHelper
  {
    public static async Task<<string>> GetAll(string requestAddress)
    {
      RestClient client = new RestClient("Http://localhost:5000/api/");
      RestRequest request = new RestRequest($"{requestAddress}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> Get(string requestAddress)
    {
      RestClient client = new RestClient("Http://localhost:5000/api/");
      RestRequest request = new RestRequest($"{requestAddress}", Method.GET);

      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task Post(string requestAddress, string insert)
    {
      RestClient client = new RestClient("Http://localhost:5000/api/");
      RestRequest request = new RestRequest($"{requestAddress}", Method.POST);
      
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(insert);
      var response = await client.ExecuteTaskAsync(request);
    }
    
    public static async Task Put(string requestAddress, string insert)
    {
      RestClient client = new RestClient("Http://localhost:5000/api/");
      RestRequest request = new RestRequest($"{requestAddress}", Method.PUT);

      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(insert);
      var response = await client.ExecuteTeskAsync(request);
    }

    public static async Task Delete(string requestAddress)
    {
      RestClient client = new RestClient("Http://localhost:5000/api/");
      RestRequest request = new RestRequest($"{requestAddress}", Method.DELETE);
      
      request.AddHeader("Content-Type", "application.json");
      var response = await client.ExecuteTaskAsync(request);
    }
    
  }
}
