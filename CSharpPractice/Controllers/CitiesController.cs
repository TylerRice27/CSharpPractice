namespace CSharpPractice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController : ControllerBase
    {
        private readonly CitiesService _cs;
        private readonly Auth0Provider _auth0provider;

        public CitiesController(CitiesService cs, Auth0Provider auth0provider)
        {
            _cs = cs;
            _auth0provider = auth0provider;
        }

        [HttpPost]
        [Authorize]

        public async Task<ActionResult<City>> Create([FromBody] City cityData)
        {
            try
            {
                Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
                cityData.CreatorId = userInfo.Id;
                City city = _cs.Create(cityData);
                city.Creator = userInfo;
                return Ok(city);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet]

        public async Task<ActionResult<List<City>>> Get()
        {
            try
            {
                Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
                List<City> cities = _cs.Get();
                return Ok(cities);


            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<City>> GetOne(int id)
        {
            try
            {
                Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
                City city = _cs.GetOne(id);
                return Ok(city);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}