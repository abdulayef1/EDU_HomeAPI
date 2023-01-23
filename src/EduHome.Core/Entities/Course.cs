﻿using EduHome.Core.Interfaces;

namespace EduHome.Core.Entities;

public class Course : IEntity
{
    public int Id { get; set; }
    public string? Image{ get; set; }
    public string? Name { get; set; }
    public string? Description{ get; set; }

}
