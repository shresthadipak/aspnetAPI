namespace aspnetAPI.Services.TestService
{
    public interface ITestService
    {
        List<Test> GetAllTest();

        Test GetSingleTest(int id);

        List<Test> AddTest(Test test);

        List<Test> EditTest(Test request, int id);

        List<Test> DeleteTest(int id);
    }
}
