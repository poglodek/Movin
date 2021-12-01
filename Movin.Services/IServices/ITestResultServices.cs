using Movin.Dto.TestResult;

namespace Movin.Services.IServices;

public interface ITestResultServices
{
    void SaveTestResult(TestResultDto dto);
}