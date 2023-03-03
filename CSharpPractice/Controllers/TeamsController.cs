namespace CSharpPractice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamsController : ControllerBase
    {

        private readonly TeamsService _ts;
        private readonly Auth0Provider _auth0Provider;

        public TeamsController(TeamsService ts, Auth0Provider auth0Provider)
        {
            _ts = ts;
            _auth0Provider = auth0Provider;
        }

        [HttpPost]
        [Authorize]

        public async Task<ActionResult<Team>> CreateTeam([FromBody] Team newTeam)

        {
            try
            {
                Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
                newTeam.CreatorId = userInfo.Id;
                Team team = _ts.CreateTeam(newTeam);
                team.Creator = userInfo;
                return Ok(team);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Team>>> Get()

        {
            try
            {
                Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
                List<Team> teams = _ts.Get();
                return Ok(teams);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetOne(int id)
        {
            try
            {
                Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
                Team team = _ts.GetOne(id);
                return team;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<string>> Delete(int id)
        {
            try
            {
                Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
                string message = _ts.Delete(id, userInfo?.Id);
                return Ok(message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }

}