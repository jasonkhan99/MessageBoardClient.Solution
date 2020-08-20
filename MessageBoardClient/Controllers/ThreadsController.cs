using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MessageBoardClient.Models;

namespace MessageBoardClient.Controllers
{
  public class ThreadsController : Controller
  {
    public IActionResult Index()
    {
        var allThreads = Thread.GetThreads();
        return View(allThreads);
    }
    public IActionResult Details(int id)
    {
        var threadDetails = Thread.GetDetails(id);
        return View(threadDetails);
    }
    public IActionResult Delete(int threadId)
    {
        var threadDetails= Thread.GetDetails(threadId);
        return View(threadDetails);
    }
    
    [HttpPost, ActionName("Delete")]
    public IActionResult ConfirmDelete(int threadId)
    {
    Thread.Delete(threadId);
    return RedirectToAction("Index");
    }

    public IActionResult CreatePost(int threadId)
    {
        return View(threadId);
    }

    [HttpPost]
    public IActionResult CreatePost(Post post)
    {
        Thread.PostPost(post);
        return View("Details", post.ParentThreadId);
    }
  }
}