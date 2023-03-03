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

        internal void Delete(Villain villain)
        {
            string sql = @"
            DELETE FROM villains
            WHERE id = @id LIMIT 1
            ";
            // You can do villain.Id in your new object
            // because you didn't send a id through has the argument
            // If you send the whole object do this 
            _db.Execute(sql, new { villain.Id });
        }

        internal void Edit(Villain originalVillain)
        {
            string sql = @"
            UPDATE villains
            SET
            name = @Name,
            bio = @Bio,
            img = @Img,
            cityId = @CityId,
            updatedAt = @UpdatedAt
            WHERE id = @id;
            "; _db.Execute(sql, originalVillain);

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