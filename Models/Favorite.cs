using System;
using System.Collections.Generic;

namespace BootCampStudyBuddy_BackEnd.Models;

public partial class Favorite
{
    public int Id { get; set; }

    public int QuizId { get; set; }

    public string? UserId { get; set; }

    public virtual Quiz Quiz { get; set; } = null!;
}
