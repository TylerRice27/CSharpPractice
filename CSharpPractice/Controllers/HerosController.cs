namespace CSharpPractice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HerosController : ControllerBase
    {

        private readonly HerosService _hs;
        private readonly Auth0Provider _auth0provider;

        public HerosController(HerosService hs, Auth0Provider auth0provider)
        {
            _hs = hs;
            _auth0provider = auth0provider;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Hero>> Create([FromBody] Hero newHero)
        {
            try
            {
                Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
                newHero.CreatorId = userInfo.Id;
                Hero hero = _hs.Create(newHero);
                hero.Creator = userInfo;
                return Ok(hero);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Hero>>> Get()
        {
            try
            {
                Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
                List<Hero> heros = _hs.Get();
                return Ok(heros);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}