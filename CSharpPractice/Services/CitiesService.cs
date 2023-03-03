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

        internal City Edit(City updatedCity, string userId)
        {
            City originalCity = _repo.GetOne(updatedCity.Id);
            if (originalCity.CreatorId != userId)
            {
                throw new Exception("This isnt your city to patrol");
            }
            originalCity.Name = updatedCity.Name ?? originalCity.Name;
            originalCity.Img = updatedCity.Img ?? originalCity.Img;
            City updatedInfo = _repo.Edit(originalCity);
            return updatedInfo;
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

        internal string Remove(int id, string userId)
        {
            City city = this.GetOne(id);
            if (city.CreatorId != userId)
            {
                throw new Exception("You have failed this city!");
            }
            _repo.Remove(id);

            return $"This {city.Name} has been removed";


        }
    }
}