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
    public IActionResult Edit(Board board)
    {
      Board.Put(board);
      return RedirectToAction("Details", board.BoardId);
    }

    public IActionResult Delete (int boardId)
    {
      var boardDetails = Board.GetDetails(boardId);
      return View(boardDetails);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirm (int boardId)
    {
      Board.Delete(boardId);
      return RedirectToAction("Index");
    }
  }
}