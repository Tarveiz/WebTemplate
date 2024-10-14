using Microsoft.AspNetCore.Mvc;
using WebTemplate.DTO.Models;
using WebTemplate.Services.Interfaces;

namespace WebTemplate.Api.Controllers;

/// <summary>
///     Тестовый контроллер (пример)
/// </summary>
[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private ITestService _testService;

    public TestController(ITestService testService)
    {
        _testService = testService;
    }

    /// <summary>
    ///     Тестовый Get-метод (пример)
    /// </summary>
    [HttpGet]
    public async Task<TestDTO> Get(int id, CancellationToken cancellationToken = default)
    {
        TestDTO item = await _testService.GetItem(id, cancellationToken);

        return item;
    }
}
