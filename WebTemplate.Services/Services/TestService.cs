using Microsoft.EntityFrameworkCore;
using WebTemplate.DAL;
using WebTemplate.DAL.Entities;
using WebTemplate.DTO.Models;
using WebTemplate.Services.Helpers;
using WebTemplate.Services.Interfaces;

namespace WebTemplate.Services.Services
{
    /// <summary>
    ///     Имплементация <see cref="ITestService"/>
    /// </summary>
    public class TestService : ITestService
    {
        private DataContext _context;

        public TestService(DataContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public async Task<TestDTO> GetItem(int id, CancellationToken cancellationToken)
        {
            EntityTest? dataBaseItem = await _context.EntityTest
                .AsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return Mapper.Map(dataBaseItem);
        }
    }
}
