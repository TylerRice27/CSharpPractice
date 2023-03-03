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
    }
}