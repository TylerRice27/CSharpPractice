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

        internal void Delete(int id)
        {
            string sql = @"
            DELETE FROM teams
            WHERE id = @id;
            ";
            _db.Execute(sql, new { id });
        }

        internal List<Team> Get()
        {
            string sql = @"SELECT 
            t.*,
            a.*
            FROM teams t
            JOIN accounts a ON a.id = t.CreatorId;";
            List<Team> teams = _db.Query<Team, Profile, Team>(sql, (team, prof) =>
            {
                team.Creator = prof;
                return team;
            }).ToList();
            return teams;
        }

        internal Team GetOne(int id)
        {
            string sql = @"
            SELECT
        t.*,
        a.*
        FROM teams t
        JOIN accounts a ON a.id = t.CreatorId
        WHERE t.id = @id;";
            Team getOneTeam = _db.Query<Team, Profile, Team>(sql, (team, prof) =>
            {
                team.Creator = prof;
                return team;
            }, new { id }).FirstOrDefault();
            return getOneTeam;
        }
    }
}