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

    public static List<Board> GetBoards()
    {
      string requestAddress = "Boards";
      var apiCallTask = apiHelper.GetAll(requestAddress);
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Board> boardList = JsonConvert.DeserializeObject<List<Board>>(jsonResponse.ToString());

      return boardList;
    }

    public static Board GetDetails(int id)
    {
      string requestAddress = $"Boards/{id}";
      var apiCallTask = ApiHelper.Get(requestAddress);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Board board = JsonConvert.DeserializeObject<Board>(jsonResponse.ToString());
      return board;
    }

    public static void Post(Board board)
    {
      string jsonBoard = JsonConvert.SerializeObject(board);
      var apiCallTask = ApiHelper.Post(jsonBoard);
    }

    public static void Put(Board board)
    {
      string jsonBoard = jsonConvert.SerializeObject(board);
      var apiCallTask = ApiHelper.Put(board.BoardId, jsonboard);
    }

    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.Delete(id);
    }

    public static List<Thread> GetThreads(int boardId)
    {
      // UPdate this to reference Getting all threads!
      string requestAddress = $"Boards/{boardId}/threads"
      var apiCallTask = apiHelper.GetAll(requestAddress);
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Threads> threadList = JsonConvert.DeserializeObject<List<Thread>>(jsonResponse.ToString());

      return threadList;
    }
    
    public static void PutThread(Thread thread)
    {
      string jsonThread = jsonConvert.SerializeObject(thread);
      var apiCallTask = ApiHelper.Put(thread.ThreadId, jsonthread);
    }
    
    public static void PostThread(Thread thread)
    {
      string jsonThread = jsonConvert.SerializeObject(thread);
      var apiCallTask = ApiHelper.Post(thread.ThreadId, jsonthread);
    }
  }
}