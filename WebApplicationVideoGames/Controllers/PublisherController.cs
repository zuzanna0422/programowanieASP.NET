using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationVideoGames.Models.ViewModels;
using WebApplicationVideoGames.Models.Games;

namespace WebApplicationVideoGames.Controllers;

public class PublisherController : Controller
{
    private readonly GamesContext _context;

    public PublisherController(GamesContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Details(int id, ViewModel model)

    {
        var publisherDetails = _context.Publishers.Include(publisher => publisher.GamePublishers)
            .ThenInclude(gamePublisher => gamePublisher.GamePlatforms).ToList()
            .Where(p => p.Id == id)
            .Select(p => new ViewModel.PublisherDetailsViewModel
            {
                PublisherName = p.PublisherName,
                Games = p.GamePublishers.Select(gp => new ViewModel.GameDetails
                {
                    GameName = gp.Game?.GameName,
                    Platforms = gp.GamePlatforms.Select(gpl => new ViewModel.PlatformDetails
                    {
                        PlatformName = gpl.Platform?.PlatformName,
                        ReleaseYear = gpl.ReleaseYear,
                        SalesByRegion = _context.RegionSales
                            .Where(rs => rs.GamePlatformId == gpl.Id)
                            .Select(rs => new ViewModel.RegionSalesDetails
                            {
                                RegionName = rs.Region!.RegionName,
                                NumSales = rs.NumSales
                            }).ToList()
                    }).ToList()
                }).ToList()
            })
            .FirstOrDefault();


        if (publisherDetails == null)
        {
            return NotFound();
        }

        return View(publisherDetails);
    }
}