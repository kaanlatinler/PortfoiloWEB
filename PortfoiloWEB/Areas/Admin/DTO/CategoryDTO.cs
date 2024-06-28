using System;
using System.Collections.Generic;

namespace PortfoiloWEB.Areas.Admin.DTO;

public class CategoryDTO
{
    public Guid CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;
}
