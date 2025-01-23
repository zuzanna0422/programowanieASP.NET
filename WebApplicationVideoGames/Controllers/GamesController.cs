using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using WebApplicationVideoGames.Models;
using WebApplicationVideoGames.Models.Games;
using WebApplicationVideoGames.Models.ViewModels;

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
        return View(new GameCreateViewModel());
    }

    [HttpPost]
    public IActionResult Create(Game game, GameCreateViewModel model)
    {
        if (ModelState.IsValid)
        {
                int newId = _context.Games.Max(g => g.Id) + 1;

                game.Id = newId;
                var selectedPublisher = model.SelectedPublisher;
                
                _context.Games.Add(game);
                _context.SaveChanges();
                if (model.SelectedPublisher > 0)
                {
                    
                    int idGamePublisher = _context.GamePublishers.Max(p => p.Id) + 1;
                    Publisher publisher = _context.Publishers.Where(p => p.Id == model.SelectedPublisher).First();
                    var gamePublisher = new GamePublisher
                    {
                        Id = idGamePublisher,
                        Game = game,
                        Publisher = publisher
                    };

                    _context.GamePublishers.Add(gamePublisher);
                    _context.SaveChanges();
                }
                _context.SaveChanges();
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