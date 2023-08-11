

namespace aspnetAPI.Services.TestService
{
    public class TestService : ITestService
    {
        
        private readonly DataContext _context;

        public TestService(DataContext context)
        {
            _context = context;
        }

        public  async Task<Test> AddTest(Test test)
        {
            var addTest = _context.Tests.Add(test);
            await _context.SaveChangesAsync();
            return addTest.Entity;
        }

        public async Task<Test?> DeleteTest(int id)
        {
            var test = await _context.Tests.FindAsync(id);
            if (test is null)
                return null;

            _context.Tests.Remove(test);
            await _context.SaveChangesAsync();
            return test;
        }

        public async Task<Test?> EditTest(Test request, int id)
        {
            var test = await _context.Tests.FindAsync(id);
            if (test is null)
                return null;

            test.Name = request.Name;
            test.Place = request.Place;

            await _context.SaveChangesAsync();

            return test;
        }

        public async Task<List<Test>> GetAllTest()
        {
            var tests = await _context.Tests.ToListAsync();
            return tests;
        }

        public async Task<Test?> GetSingleTest(int id)
        {
            var test = await _context.Tests.FindAsync(id);
            if (test is null)
                return null;
            return test;
        }
    }
}
