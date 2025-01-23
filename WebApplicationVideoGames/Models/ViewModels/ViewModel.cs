namespace WebApplicationVideoGames.Models.ViewModels;


public class ViewModel
{
    public class PublisherDetailsViewModel
    {
        public string? PublisherName { get; set; }
        public List<GameDetails>? Games { get; set; }
    }

    public class GameDetails
    {
        public string? GameName { get; set; }
        public List<PlatformDetails>? Platforms { get; set; }
    }

    public class PlatformDetails
    {
        public string? PlatformName { get; set; }
        public int? ReleaseYear { get; set; }
        public List<RegionSalesDetails>? SalesByRegion { get; set; }
    }

    public class RegionSalesDetails
    {
        public string? RegionName { get; set; }
        public double? NumSales { get; set; }
    }

}