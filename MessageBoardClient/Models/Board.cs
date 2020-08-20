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
      var apiCallTask = ApiHelper.GetAll(requestAddress);
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
      string requestAddress = $"Boards";
      string jsonBoard = JsonConvert.SerializeObject(board);
      var apiCallTask = ApiHelper.Post(requestAddress, jsonBoard);
    }

    public static void Put(Board board)
    {
      string requestAddress = $"Boards/{board.BoardId}";
      string jsonBoard = JsonConvert.SerializeObject(board);
      var apiCallTask = ApiHelper.Put(requestAddress, jsonBoard);
    }

    public static void Delete(int id)
    {
      string requestAddress = $"Boards/{id}";
      var apiCallTask = ApiHelper.Delete(requestAddress);
    }

    // Return all Threads associated with a specific Board
    public static List<Thread> GetThreads(int boardId)
    {
      string requestAddress = $"Boards/{boardId}/threads";
      var apiCallTask = ApiHelper.GetAll(requestAddress);
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Thread> threadList = JsonConvert.DeserializeObject<List<Thread>>(jsonResponse.ToString());

      return threadList;
    }
    
    public static void PutThread(Thread thread)
    {
      string requestAddress = $"Boards/{thread.ParentBoardId}/threads/{thread.ThreadId}";
      string jsonThread = JsonConvert.SerializeObject(thread);
      var apiCallTask = ApiHelper.Put(requestAddress, jsonThread);
    }
    
    public static void PostThread(Thread thread)
    {
      string requestAddress = $"Boards/{thread.ParentBoardId}/Threads";
      string jsonThread = JsonConvert.SerializeObject(thread);
      Console.WriteLine("\n JSON THREAD:\n" + jsonThread);
      var apiCallTask = ApiHelper.Post(requestAddress, jsonThread);
    }
  }
}