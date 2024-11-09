namespace programowanieASP.NET.Models
{
    public class MemoryTravelService : ITravelService
    {
        private Dictionary<int, TravelModel> _items = new Dictionary<int, TravelModel>();
        public int Add(TravelModel item)
        {
            int id = _items.Keys.Count != 0 ? _items.Keys.Max() : 0;
            item.Id = id + 1; 
            _items.Add(item.Id, item);
            return item.Id;
        }
        public void Delete(int id)
        {
            _items.Remove(id);
        }

        public List<TravelModel> FindAll()
        {
            return _items.Values.ToList();
        }
        public TravelModel? FindById(int id)
        {
            return _items[id];
        }
        public void Update(TravelModel item )
        {
            _items[item.Id] = item;
        }
    }
}
