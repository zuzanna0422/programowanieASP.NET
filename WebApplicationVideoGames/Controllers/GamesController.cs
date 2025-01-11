using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using WebApplicationVideoGames.Models;
using WebApplicationVideoGames.Models.Games;

namespace WebApplicationVideoGames.Controllers;

public class GamesController : Controller
{
    private readonly GamesContext _context;

    public GamesController(GamesContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var games = _context.Games
            .Include(g => g.Genre)
            .Include(g => g.GamePublishers)
            .ThenInclude(gp => gp.Publisher);
        return View(games);
    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Genres = _context.Genres.ToList();
        ViewBag.Publishers = _context.Publishers.ToList();
        return View();
    }

    [HttpPost]
    public IActionResult Create(Game game, List<int> selectedPublisher)
    {
        if (ModelState.IsValid)
        {
                _context.Games.Add(game);
                _context.SaveChanges();
                foreach (var publisherId in selectedPublisher)
                {
                    var gamePublisher = new GamePublisher
                    {
                        GameId = game.Id,
                        PublisherId = publisherId
                    };
                    _context.GamePublishers.Add(gamePublisher);

                }

                return RedirectToAction("Index");
        }
        else
        {
            ViewBag.Genres = _context.Genres.ToList();
            ViewBag.Publishers = _context.Publishers.ToList();
            return View();
        }
    }
}