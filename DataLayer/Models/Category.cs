using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Game> Games { get; set; } = new List<Game>();
}
