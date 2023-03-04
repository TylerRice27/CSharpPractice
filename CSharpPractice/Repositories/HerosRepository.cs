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
    }
}