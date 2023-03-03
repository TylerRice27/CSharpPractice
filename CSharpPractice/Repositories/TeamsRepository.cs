namespace CSharpPractice.Repositories
{
    public class TeamsRepository
    {
        private readonly IDbConnection _db;
        public TeamsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Team CreateTeam(Team newTeam)
        {
            string sql = @"
        INSERT INTO teams
        (name, img, creatorId)
        VALUES
        (@Name, @Img, @CreatorId);
        SELECT LAST_INSERT_ID();
        ";
            int id = _db.ExecuteScalar<int>(sql, newTeam);
            newTeam.Id = id;
            return newTeam;
        }
    }
}