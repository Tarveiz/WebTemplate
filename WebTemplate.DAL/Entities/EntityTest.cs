using System.ComponentModel.DataAnnotations.Schema;

namespace WebTemplate.DAL.Entities;

/// <summary>
///     Тестовая Entity (пример)
/// </summary>
public class EntityTest
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

}
