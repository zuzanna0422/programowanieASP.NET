
namespace programowanieASP.NET.Models
{
    public interface ITravelService
    {
        int Add(TravelModel travel);
        void Delete(int id);
        void Update(TravelModel travel);
        List<TravelModel> FindAll();
        TravelModel? FindById(int travel);
    }
}
