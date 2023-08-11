namespace aspnetAPI.Services.TestService
{
    public interface ITestService
    {
        Task<List<Test>> GetAllTest();

        Task<Test> GetSingleTest(int id);

        Task<Test> AddTest(Test test);

        Task<Test> EditTest(Test request, int id);

        Task<Test> DeleteTest(int id);
    }
}
