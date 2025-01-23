﻿using System;
using System.Collections.Generic;

namespace WebApplicationVideoGames.Models.Games;

public partial class Platform
{
    public int Id { get; set; }

    public string? PlatformName { get; set; }

    public virtual ICollection<GamePlatform> GamePlatforms { get; set; } = new List<GamePlatform>();
}
