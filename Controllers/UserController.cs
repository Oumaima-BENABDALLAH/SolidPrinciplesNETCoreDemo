using Microsoft.AspNetCore.Mvc;
using SolidPrinciplesNETCoreDemo.Models;
using SolidPrinciplesNETCoreDemo.Services;

public class UserController : Controller
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    public IActionResult Index()
    {
        var users = _userService.GetAllUsers();
        return View(users);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(User user)
    {
        if (ModelState.IsValid)
        {
            _userService.RegisterUser(user);
            return RedirectToAction(nameof(Index));
        }
        return View(user);
    }

    public IActionResult Delete(int id)
    {
        _userService.DeleteUser(id);
        return RedirectToAction(nameof(Index));
    }
}