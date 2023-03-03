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
    }
}