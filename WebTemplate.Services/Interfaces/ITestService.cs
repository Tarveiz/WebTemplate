using WebTemplate.DTO.Models;

namespace WebTemplate.Services.Interfaces;

/// <summary>
///     Тестовый сервис (пример)
/// </summary>
public interface ITestService
{
    /// <summary>
    ///     Тестовый метод сервиса по получению данных из базы (пример)
    /// </summary>
    Task<TestDTO> GetItem(int id, CancellationToken cancellationToken);
}
