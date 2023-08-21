using aspnetAPI.Services.TestService;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet, Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<List<Test>>> GetAllTest()
        {
            var result = await _testService.GetAllTest();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Test>> GetSingleTest(int id)
        {
            var result = await _testService.GetSingleTest(id);
            if(result is null)
                return NotFound("Sorry!!, " +id+ " is not found.");

            return Ok(result);
        }

        [HttpPost("addTest")]
        public async Task<ActionResult<List<Test>>> AddTest(Test test)
        {
            var addTest = await _testService.AddTest(test);
            return Ok(addTest);
        }

        [HttpPut("editTest/{id}")]
        public async Task<ActionResult<List<Test>>> EditTest(Test request, int id)
        {
            var update = await _testService.EditTest(request, id);
            if (update is null)
                return NotFound("Sorry!, " + id + " is not found.");

            return Ok(update);
        }

        [HttpDelete("deleteTest/{id}")]
        public async Task<ActionResult<List<Test>>> DeleteTest(int id)
        {
            var result = await _testService.DeleteTest(id);
            if (result is null)
                return NotFound("Sorry!, " + id + " is not found");
            return Ok(result);
        }

        
    }
}
