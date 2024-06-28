using System;
using System.Collections.Generic;

namespace PortfoiloWEB.Models;

public partial class Contact
{
    public Guid ContactId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Subject { get; set; } = null!;

    public string Message { get; set; } = null!;
}
