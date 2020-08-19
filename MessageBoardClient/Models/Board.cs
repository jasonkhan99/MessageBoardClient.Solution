using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MessageBoardClient.Models
{
  public class Board
  {
    public int BoardId { get; set; }
    public string Title { get; set; }
    public ICollection<Thread> Threads { get; set; }

    public Board()
    {
      this.Threads = new HashSet<Thread>();
    }

    public static Board GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Board board = JsonConvert.DeserializeObject<Board>(jsonResponse.ToString());

      return board;
    }
  }
}