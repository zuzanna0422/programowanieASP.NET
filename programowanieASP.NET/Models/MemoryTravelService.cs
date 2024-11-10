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
            _items.TryGetValue(id, out var travel);
            return travel;
        }
        public void Update(TravelModel item)
        {
            if (_items.ContainsKey(item.Id))
            {
                _items[item.Id] = item;
            }
            else
            {
                throw new KeyNotFoundException("Travel item with specified ID not found.");
            }
        }
    }
}
