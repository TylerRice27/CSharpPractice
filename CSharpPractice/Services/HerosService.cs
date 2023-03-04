namespace CSharpPractice.Services
{
    public class HerosService
    {
        private readonly HerosRepository _repo;

        public HerosService(HerosRepository repo)
        {
            _repo = repo;
        }

        internal Hero Create(Hero newHero)
        {
            Hero hero = _repo.Create(newHero);
            return hero;
        }

        internal List<Hero> Get()
        {
            return _repo.Get();
        }

        internal Hero GetOne(int id)
        {
            Hero hero = _repo.GetOne(id);
            if (hero == null)
            {
                throw new Exception("That Hero is MIA");
            }
            return hero;
        }
    }
}