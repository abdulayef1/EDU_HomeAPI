using EduHome.Core.Interfaces;

namespace EduHome.Core.Entities;

public class Category : IEntity
{
    public int Id { get; set; }
    public string? Name{ get; set; }
}
