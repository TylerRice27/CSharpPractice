namespace CSharpPractice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VillainsController : ControllerBase
    {

        private readonly VillainsService _vs;

        private readonly Auth0Provider _auth0provider;

        public VillainsController(VillainsService vs, Auth0Provider auth0provider)
        {
            _vs = vs;
            _auth0provider = auth0provider;
        }


        public async Task<ActionResult<Villain>> Create([FromBody] Villain newVillain)
        {
            try
            {
                Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
                newVillain.CreatorId = userInfo.Id;
                Villain villain = _vs.Create(newVillain);
                villain.Creator = userInfo;
                return Ok(villain);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public async Task<ActionResult<List<Villain>>> Get()
        {

            try
            {

                Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
                List<Villain> villains = _vs.Get();
                return Ok(villains);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



    }
}