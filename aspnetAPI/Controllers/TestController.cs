using aspnetAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace aspnetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private static List<Test> tests = new List<Test>
        {
            new Test
            {
                Id=1,
                Name="SpiderMan",
                Place = "New York"
            },
            new Test
            {
                Id=2,
                Name="Iron Man",
                Place = "Virginia"
            },
            new Test
            {
                Id=3,
                Name="Superman",
                Place = "Texas"
            },
        };

        [HttpGet]
        public async Task<ActionResult<List<Test>>> GetAllTest()
        {
            return Ok(tests);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Test>>> GetSingleTest(int id)
        {
            var test = tests.Find(y => y.Id == id);
            if(test is null)
            {
                return NotFound("Sorry!!, " +id+ " is not found.");
            }
            return Ok(test);
        }

        [HttpPost("addTest")]
        public async Task<ActionResult<List<Test>>> AddTest([FromBody] Test test)
        {
            tests.Add(test);
            return Ok(tests);
        }
    }
}
