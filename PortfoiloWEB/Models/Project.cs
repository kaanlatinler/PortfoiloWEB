using System;
using System.Collections.Generic;

namespace PortfoiloWEB.Models;

public partial class Project
{
    public Guid ProjectId { get; set; }

    public string ProjectName { get; set; } = null!;

    public string ProjectDesc { get; set; } = null!;

    public string ProjectUrl { get; set; } = null!;

    public string ProjectClient { get; set; } = null!;

    public DateTime ProjectDate { get; set; }

    public Guid ProjectCatId { get; set; }

    public Guid ProjectLangId { get; set; }

    public Guid ProjectImgId { get; set; }
}
