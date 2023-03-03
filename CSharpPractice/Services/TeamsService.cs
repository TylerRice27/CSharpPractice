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

        internal string Delete(int id, string userId)
        {
            Team team = this.GetOne(id);
            if (team.CreatorId != userId)
            {
                throw new Exception("You think you can stop this team");
            }
            _repo.Delete(id);
            return $"{team.Name} has been eliminated";
        }

        internal Team Edit(Team teamUpdate, string userId)
        {
            Team originalTeam = this.GetOne(teamUpdate.Id);
            if (originalTeam.CreatorId != userId)
            {
                throw new Exception("You dont lead this team");
            }
            originalTeam.Name = teamUpdate.Name ?? originalTeam.Name;
            originalTeam.Img = teamUpdate.Img ?? originalTeam.Img;

            Team updatedTeam = _repo.Edit(originalTeam);
            return updatedTeam;
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