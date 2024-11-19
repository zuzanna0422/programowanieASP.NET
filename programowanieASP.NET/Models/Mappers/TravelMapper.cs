using System.Diagnostics;
using Data.Entities;
using programowanieASP.NET.Models;

namespace programowanieASP.NET.Mappers
{
    public static class TravelMapper
    {
        public static TravelModel FromEntity(TravelEntity entity)
        {
            return new TravelModel()
            {
                Id = entity.Id,
                Nazwa = entity.Nazwa,
                DataRozpoczecia = entity.DataRozpoczecia,
                DataZakonczenia = entity.DataZakonczenia,
                MiejscePoczatkowe = entity.MiejscePoczatkowe,
                MiejsceKoncowe = entity.MiejsceKoncowe,
                Uczestnicy = entity.Uczestnicy,
                Przewodnik = entity.Przewodnik,
            };
        }

        public static TravelEntity ToEntity(TravelModel model)
        {
            return new TravelEntity()
            {
                Id = model.Id,
                Nazwa = model.Nazwa,
                DataRozpoczecia = model.DataRozpoczecia,
                DataZakonczenia = model.DataZakonczenia,
                MiejscePoczatkowe = model.MiejscePoczatkowe,
                MiejsceKoncowe = model.MiejsceKoncowe,
                Uczestnicy = model.Uczestnicy,
                Przewodnik = model.Przewodnik,
            };
        }
    }
}
