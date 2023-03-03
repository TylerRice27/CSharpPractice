namespace CSharpPractice.Services
{
    public class TeamsService
    {

        private readonly TeamsRepository _repo;

        public TeamsService(TeamsRepository repo)
        {
            _repo = repo;
        }

        internal Team CreateTeam(Team newTeam)
        {
            Team team = _repo.CreateTeam(newTeam);
            return team;
        }

        internal List<Team> Get()
        {
            List<Team> teams = _repo.Get();
            return teams;
        }

        internal Team GetOne(int id)
        {
            Team team = _repo.GetOne(id);
            if (team == null)
            {
                throw new Exception("Failed to locate Team");
            }
            return team;

        }
    }
}