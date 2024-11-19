
using Data.Entities;
using Data;
using programowanieASP.NET.Mappers;
using System.Diagnostics;

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

    public class EFTravelService : ITravelService
    {
        private AppDbContext _context;
        public EFTravelService(AppDbContext context)
        {
            _context = context;
        }
        public int Add(TravelModel travel)
        {
            var e = _context.Travel.Add(TravelMapper.ToEntity(travel));
            _context.SaveChanges();
            return e.Entity.Id;
        }
        public void Delete(int id)
        {
            TravelEntity? find = _context.Travel.Find(id);
            if (find != null)
            {
                _context.Travel.Remove(find);
            }
        }
        public List<TravelModel> FindAll()
        {
            return _context.Travel.Select(e => TravelMapper.FromEntity(e)).ToList(); ;
        }
        public TravelModel? FindById(int id)
        {
            return TravelMapper.FromEntity(_context.Travel.Find(id));
        }
        public void Update(TravelModel travel)
        {
            _context.Travel.Update(TravelMapper.ToEntity(travel));
        }
    }
}
