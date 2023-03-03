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
            if (villain == null)
            {
                throw new Exception("This villain is laying low");
            }
            return villain;
        }
        internal string Delete(int id, string userId)
        {
            Villain villain = this.GetOne(id);
            if (villain.CreatorId != userId)
            {
                throw new Exception("Your power is to weak to handle this threat");
            }
            _repo.Delete(villain);

            return $"{villain.Name}'s justice has been served";
        }

        internal Villain Edit(Villain updatedVillain, string userId)
        {
            Villain originalVillain = this.GetOne(updatedVillain.Id);
            if (originalVillain.CreatorId != userId)
            {
                throw new Exception("You trying to manipulate my power you are to weak");
            }
            originalVillain.Name = updatedVillain.Name ?? originalVillain.Name;
            originalVillain.Bio = updatedVillain.Bio ?? originalVillain.Bio;
            originalVillain.Img = updatedVillain.Img ?? originalVillain.Img;
            originalVillain.cityId = updatedVillain.cityId ?? originalVillain.cityId;
            _repo.Edit(originalVillain);
            return originalVillain;

        }
    }
}