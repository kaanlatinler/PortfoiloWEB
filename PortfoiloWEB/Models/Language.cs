using System;
using System.Collections.Generic;

namespace PortfoiloWEB.Models;

public partial class Language
{
    public Guid LangId { get; set; }

    public string LangName { get; set; } = null!;
}
