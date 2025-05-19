using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Play
{
    public int? PlayerId { get; set; }

    public int? GameId { get; set; }

    public int? Amount { get; set; }
}
