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
      var apiCallTask = apiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Post> postList = JsonConvert.DeserializeObject<List<Post>>(jsonResponse.ToString());

      return postList;
    }

    public static Post GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Post post = JsonConvert.DeserializeObject<Post>(jsonResponse.ToString());
      return post;
    }

    public static void Put(Post post)
    {
      string jsonPost = jsonConvert.SerializeObject(post);
      var apiCallTask = ApiHelper.Put(post.PostId, jsonpost);
    }

    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.Delete(id);
    }
  }
}