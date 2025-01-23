using WebApplicationVideoGames.Models.Games;

namespace WebApplicationVideoGames.Models.ViewModels
{
    public class GameCreateViewModel
    {
        public int? GenreId { get; set; }
        public string? GameName { get; set; }
        public int SelectedPublisher { get; set; }
    }
}