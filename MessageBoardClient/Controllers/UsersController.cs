using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MessageBoardClient.Models;

namespace MessageBoardClient.Controllers
{
  public class UsersController : Controller
  {
    public IActionResult Index()
    {
      var user = MessageBoardClient.Models.User.GetUsers();
      return View(user);
    }

    public IActionResult Details(int userId)
    {
      var user = MessageBoardClient.Models.User.GetDetails(userId);
      return View(user);
    }

    public IActionResult Create()
    {
      return View();
    }
    
    [HttpPost]
    public IActionResult Create(User user)
    {
      MessageBoardClient.Models.User.Post(user);
      return RedirectToAction("Details", user.UserId);
    }

    public IActionResult Edit(int userId)
    {
      var userToEdit = MessageBoardClient.Models.User.GetDetails(userId);
      return View(userToEdit);
    }

    [HttpPost]
    public IActionResult Edit(User user)
    {
      MessageBoardClient.Models.User.Put(user);
      return RedirectToAction("Details", user.UserId);
    }
    
    public IActionResult Delete(int userId)
    {
      return View(userId);
    }
    
    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirm(int userId)
    {
      MessageBoardClient.Models.User.Delete(userId);
      return RedirectToAction("Index");
    }
  }
}