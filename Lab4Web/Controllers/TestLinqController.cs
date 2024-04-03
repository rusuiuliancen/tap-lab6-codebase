using Lab4Web.Services.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Lab4Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestLinqController : ControllerBase
    {
        private readonly ILinqService _linqService;

        public TestLinqController(ILinqService linqService)
        {
            _linqService = linqService;
        }

        [HttpGet("test-1")]
        public int Get(int age)
        {
            return _linqService.Test1(age);
        }

        public int GetMethod(int value)
        {
            var count1 = _linqService.Test1(value);
            var count2 = _linqService.Test1(value + 10);

            if (_linqService.Test2(count1, count2) == 12)
                throw new ArgumentException("Nu e bine");
            return count1;
        }
    }
}
