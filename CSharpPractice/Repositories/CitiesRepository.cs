namespace CSharpPractice.Repositories
{
    public class CitiesRepository
    {
        private readonly IDbConnection _db;

        public CitiesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal City Create(City cityData)
        {
            string sql = @"
            INSERT INTO cities
            (name, img, creatorId)
            VALUES
            (@Name, @Img, @CreatorId);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, cityData);
            cityData.Id = id;
            return cityData;
        }

        internal List<City> Get()
        {
            string sql = @"
            SELECT * FROM cities c
            JOIN accounts a on a.id = c.creatorId;
            ";
            List<City> cities = _db.Query<City, Account, City>(sql, (city, account) =>
            {
                city.Creator = account;
                return city;
            }).ToList();
            return cities;
        }
    }
}