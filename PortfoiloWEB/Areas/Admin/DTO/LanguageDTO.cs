using System;
using System.Collections.Generic;

namespace PortfoiloWEB.Areas.Admin.DTO;

public class LanguageDTO
{
    public Guid LangId { get; set; }

    public string LangName { get; set; } = null!;
}
