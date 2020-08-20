using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MessageBoardClient.Models
{
  public class Post
  {
    public int PostId { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public string Title { get; set; }
    public string PostBody { get; set; }
    public DateTime CreationDate { get; set; }
    public int ParentThreadId { get; set; }
    public Thread ParentThread { get; set; }
  
  public static List<Post> GetPosts()
    {
      string requestAddress = "Posts";
      var apiCallTask = ApiHelper.GetAll(requestAddress);
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Post> postList = JsonConvert.DeserializeObject<List<Post>>(jsonResponse.ToString());

      return postList;
    }

    public static Post GetDetails(int id)
    {
      string requestAddress = $"Posts/{id}";
      var apiCallTask = ApiHelper.Get(requestAddress);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Post post = JsonConvert.DeserializeObject<Post>(jsonResponse.ToString());
      return post;
    }

    public static void Put(Post post)
    {
      string requestAddress = $"Posts/{post.PostId}";
      string jsonPost = JsonConvert.SerializeObject(post);
      var apiCallTask = ApiHelper.Put(requestAddress, jsonPost);
    }

    public static void Delete(int id)
    {
      string requestAddress = $"Posts/{id}";
      var apiCallTask = ApiHelper.Delete(requestAddress);
    }
  }
}