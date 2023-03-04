namespace CSharpPractice.Repositories
{
    public class HerosRepository
    {

        private readonly IDbConnection _db;

        public HerosRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Hero Create(Hero newHero)
        {
            string sql = @"
            INSERT INTO heros
            (name, bio, img, cityId, creatorId)
            VALUES
            (@Name, @Bio, @Img, @CityId, @CreatorId);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, newHero);
            newHero.Id = id;
            return newHero;
        }

        internal List<Hero> Get()
        {
            string sql = @"
            SELECT
            h.*,
            a.*
            FROM heros h
            JOIN accounts a ON a.id = h.CreatorId;
            ";
            return _db.Query<Hero, Profile, Hero>(sql, (hero, prof) =>
            {
                hero.Creator = prof;
                return hero;
            }).ToList();
        }
    }
}