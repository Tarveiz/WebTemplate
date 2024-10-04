using WebTemplate.DAL.Entities;
using WebTemplate.DTO.Models;

namespace WebTemplate.Services.Helpers;
public static class Mapper
{
    public static TestDTO Map(EntityTest item)
    {
        if (item == null)
            return new TestDTO();

        return new TestDTO
        {
            Id = item.Id,
            Name = item.Name,
            Description = item.Description
        };
    }
}
