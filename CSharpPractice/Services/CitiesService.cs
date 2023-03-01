namespace CSharpPractice.Services
{
    public class CitiesService
    {
        private readonly CitiesRepository _repo;

        public CitiesService(CitiesRepository repo)
        {
            _repo = repo;
        }

        internal City Create(City cityData)
        {
            City city = _repo.Create(cityData);
            return city;
        }

        internal List<City> Get()
        {
            List<City> cities = _repo.Get();
            return cities;
        }
    }
}