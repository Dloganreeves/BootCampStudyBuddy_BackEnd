using System;
using System.Collections.Generic;

namespace BootCampStudyBuddy_BackEnd.Models;

public partial class Quiz
{
    public int Id { get; set; }

    public string Question { get; set; } = null!;

    public string Answer { get; set; } = null!;

    public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
}
