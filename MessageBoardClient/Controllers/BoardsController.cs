using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MessageBoardClient.Models;

namespace MessageBoardClient.Controllers
{
  public class BoardsController : Controller
  {
    
    public IActionResult Index()
    {
      var allBoards = Board.GetBoards();
      return View(allBoards);
    }

    public IActionResult Details(int id)
    {
      var boardDetails = Board.GetDetails(id);
      return View(boardDetails);
    }
    
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Create(Board board)
    {
      Board.Post(board);
      return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
      var boardChange = Board.GetDetails(id);
      return View(boardChange);
    }

    [HttpPost]
    public ActionResult Edit(Board board)
    {
      Board.Put(board);
      return RedirectToAction("Details", new { id = board.BoardId} );
    }

    public IActionResult Delete (int id)
    {
      var boardDetails = Board.GetDetails(id);
      return View(boardDetails);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirm (int id)
    {
      Board.Delete(id);
      return RedirectToAction("Index");
    }

    public IActionResult CreateThread (int id)
    {
      var thread = new Thread();
      thread.ParentBoardId = id;
      return View(thread);
    }

    [HttpPost]
    public IActionResult CreateThread(Thread thread)
    {
      Console.WriteLine("\n" + thread.Title + "\n" + thread.ParentBoardId);
      Board.PostThread(thread);
      return RedirectToAction("Details", new { id = thread.ParentBoardId});
    }

    public IActionResult EditThread(int threadId)
    {
      var threadChange = Thread.GetDetails(threadId);
      return View(threadChange);
    }

    [HttpPost]
    public IActionResult EditThread(Thread thread)
    {
      Board.PutThread(thread);
      return RedirectToAction("Details", "Threads", new { id = thread.ParentBoardId});
    }
  }
}