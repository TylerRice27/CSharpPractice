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
    }
}