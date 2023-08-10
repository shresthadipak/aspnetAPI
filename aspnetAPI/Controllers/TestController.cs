using aspnetAPI.Services.TestService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace aspnetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Test>>> GetAllTest()
        {
            var result = _testService.GetAllTest();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Test>> GetSingleTest(int id)
        {
            var result = _testService.GetSingleTest(id);
            if(result is null)
                return NotFound("Sorry!!, " +id+ " is not found.");

            return Ok(result);
        }

        [HttpPost("addTest")]
        public async Task<ActionResult<List<Test>>> AddTest(Test test)
        {
            var addTest = _testService.AddTest(test);
            return Ok(addTest);
        }

        [HttpPut("editTest/{id}")]
        public async Task<ActionResult<List<Test>>> EditTest(Test request, int id)
        {
            var update = _testService.EditTest(request, id);
            if (update is null)
                return NotFound("Sorry!, " + id + " is not found.");

            return Ok(update);
        }

        [HttpDelete("deleteTest/{id}")]
        public async Task<ActionResult<List<Test>>> DeleteTest(int id)
        {
            var result = _testService.DeleteTest(id);
            if (result is null)
                return NotFound("Sorry!, " + id + " is not found");
            return Ok(result);
        }

        [HttpPut("editTest/{id}")]
        public async Task<ActionResult<List<Test>>> EditTest(Test request, int id)
        {
            var test = tests.Find(x => x.Id == id);
            if (test is null)
                return NotFound("Sorry!!, " + id + " is not found.");

            test.Name = request.Name;
            test.Place = request.Place;

            return Ok(tests);
        }

        [HttpDelete("deleteTest/{id}")]
        public async Task<ActionResult<List<Test>>> DeleteTest(int id)
        {
            var test = tests.Find(x => x.Id == id);
            if (test is null)
                return NotFound("Sorry!!, " + id + " is not found.");

            tests.Remove(test);
            return Ok(tests);
        }
    }
}
