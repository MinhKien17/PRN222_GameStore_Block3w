using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models;

public partial class Game
{
    public int Id { get; set; }

    public string Title { get; set; }

    public decimal Price { get; set; }

    [DataType(DataType.Date)]
    public DateOnly? ReleaseDate { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category Category { get; set; }
}
