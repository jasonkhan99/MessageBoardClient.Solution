using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MessageBoardClient.Models;

namespace MessageBoardClient.Controllers
{
  public class PostsController : Controller
  {
    public IActionResult Index()
    {
      var posts = Post.GetPosts();
      return View(posts);
    }

    public IActionResult Details(int postId)
    {
      var post = Post.GetDetails(postId);
      return View(post);
    }

    public IActionResult Edit(int postId)
    {
      var post = Post.GetDetails(postId);
      return View(post);
    }

    [HttpPost]
    public IActionResult Edit (Post post)
    {
      Post.Put(post);
      return RedirectToAction("Details", post.PostId);
    }

    public IActionResult Delete(int postId)
    {
      var post = Post.GetDetails(postId);
      return View(post);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirm(int postId)
    {
      Post.Delete(postId);
      return RedirectToAction("Index");
    }
  }
}