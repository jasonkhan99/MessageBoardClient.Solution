using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace MessageBoardClient.Models
{
  public class Thread
  {
    public int ThreadId { get; set; }
    public string Title { get; set; }
    public DateTime CreationDate { get; set; }
    public int ParentBoardId { get; set; }
    public Board ParentBoard { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public ICollection<Post> Posts { get; set; }

    public Thread()
    {
      this.Posts = new HashSet<Post>();
    }

     public static List<Thread> GetThreads()
    {
      var apiCallTask = apiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Thread> threadList = JsonConvert.DeserializeObject<List<Thread>>(jsonResponse.ToString());

      return threadList;
    }

    public static Thread GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Thread thread = JsonConvert.DeserializeObject<Thread>(jsonResponse.ToString());
      return thread;
    }

    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.Delete(id);
    }

//should id be postId
  public static Post GetDetailsPost(int postId)
    {
      var apiCallTask = ApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Post post = JsonConvert.DeserializeObject<Post>(jsonResponse.ToString());
      return post;
    }

    public static void PostPost(Post post)
    {
      string jsonPost = jsonConvert.SerializeObject(post);
      var apiCallTask = ApiHelper.post(post.PostId, jsonPost);
    }
  }
}