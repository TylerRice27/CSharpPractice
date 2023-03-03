namespace CSharpPractice.Services
{
    public class VillainsService
    {

        private readonly VillainsRepository _repo;

        public VillainsService(VillainsRepository repo)
        {
            _repo = repo;
        }

        internal Villain Create(Villain newVillain)
        {
            Villain villain = _repo.Create(newVillain);
            return villain;
        }

        internal List<Villain> Get()
        {
            List<Villain> villains = _repo.Get();
            return villains;
        }

        internal Villain GetOne(int id)
        {
            Villain villain = _repo.GetOne(id);
            return villain;
        }
    }
}