

namespace aspnetAPI.Services.TestService
{
    public class TestService : ITestService
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

        public List<Test> AddTest(Test test)
        {
            tests.Add(test);
            return tests;
        }

        public List<Test>? DeleteTest(int id)
        {
            var test = tests.Find(x => x.Id == id);
            if (test is null)
                return null;

            tests.Remove(test);
            return tests;
        }

        public List<Test>? EditTest(Test request, int id)
        {
            var test = tests.Find(x => x.Id == id);
            if (test is null)
                return null;

            test.Name = request.Name;
            test.Place = request.Place;

            return tests;
        }

        public List<Test> GetAllTest()
        {
            return tests;
        }

        public Test? GetSingleTest(int id)
        {
            var test = tests.Find(y => y.Id == id);
            if (test is null)
                return null;
            return test;
        }
    }
}
