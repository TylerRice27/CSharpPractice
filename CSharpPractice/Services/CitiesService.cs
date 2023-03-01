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

        internal City GetOne(int id)
        {
            City city = _repo.GetOne(id);
            if (city == null)
            {
                throw new Exception("No City by that Id");

            }

            return city;
        }
    }
}