using System;
using System.Collections.Generic;

namespace BootCampStudyBuddy_BackEnd.Models;

public partial class User
{
    public int Id { get; set; }

    public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
}
