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

        public async Task<ActionResult<City>> GetOneAsync(int id)
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

        [HttpPut("{id}")]
        [Authorize]

        public async Task<ActionResult<City>> Edit(int id, [FromBody] City updatedCity)

        {
            try
            {
                Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
                updatedCity.Id = id;
                City city = _cs.Edit(updatedCity, userInfo?.Id);
                return Ok(city);


            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpDelete("{id}")]
        [Authorize]

        public async Task<ActionResult<string>> Remove(int id)

        {
            try
            {
                Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
                string message = _cs.Remove(id, userInfo.Id);
                return Ok(message);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}