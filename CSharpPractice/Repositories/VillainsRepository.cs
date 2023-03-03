namespace CSharpPractice.Repositories
{
    public class VillainsRepository
    {
        private readonly IDbConnection _db;

        public VillainsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Villain Create(Villain newVillain)
        {
            string sql = @"
            INSERT INTO villains
            (name, img, bio, cityId, creatorId)
            VALUES
            (@Name, @Img, @Bio, @CityId, @CreatorId);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, newVillain);
            newVillain.Id = id;
            return newVillain;
        }

        internal List<Villain> Get()
        {
            string sql = @"
            SELECT
            v.*,
            a.*
            FROM villains v
            JOIN accounts a ON a.id = v.CreatorId;
            ";
            List<Villain> villains = _db.Query<Villain, Profile, Villain>(sql, (villain, prof) =>
            {
                villain.Creator = prof;
                return villain;
            }).ToList();
            return villains;
        }

        internal Villain GetOne(int id)
        {
            string sql = @"
            SELECT
            v.*,
            a.*
            FROM villains v
            JOIN accounts a on a.id = v.CreatorId
            WHERE v.id = @id;
            ";
            return _db.Query<Villain, Profile, Villain>(sql, (villain, prof) =>
            {
                villain.Creator = prof;
                return villain;
            }, new { id }).FirstOrDefault();
        }
    }
}