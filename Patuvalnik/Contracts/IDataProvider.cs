namespace Patuvalnik.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Patuvalnik.Models;

    public interface IDataProvider
    {
        Task<List<Trip>> GetTrips(int from, int to);

        Task<List<City>> GetCities();
    }
}