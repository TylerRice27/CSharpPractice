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
            SELECT 
            c.*,
            a.*
            FROM cities c
            JOIN accounts a on a.id = c.creatorId;
            ";
            List<City> cities = _db.Query<City, Account, City>(sql, (city, account) =>
            {
                city.Creator = account;
                return city;
            }).ToList();
            return cities;
        }

        internal City GetOne(int id)
        {
            string sql = @"
            SELECT
            c.*,
            a.*
            FROM cities c
            JOIN accounts a on a.id = c.creatorId
            WHERE c.id = @id;
            ";
            return _db.Query<City, Account, City>(sql, (city, account) =>
            {
                city.Creator = account;
                return city;
            }, new { id }).FirstOrDefault();

        }

        internal void Remove(int id)
        {
            string sql = @"DELETE FROM cities
            WHERE id = @id;";
            _db.Execute(sql, new { id });
        }
    }
}