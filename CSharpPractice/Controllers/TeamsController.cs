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


    }

}