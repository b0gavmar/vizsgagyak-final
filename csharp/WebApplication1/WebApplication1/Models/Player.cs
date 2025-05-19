using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Player
{
    public int? Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public int? Amount { get; set; }
}
