using System;
using System.Collections.Generic;

namespace PortfoiloWEB.Models;

public partial class Image
{
    public Guid ImageId { get; set; }

    public string ImgPath { get; set; } = null!;

    public Guid ProjectId { get; set; }
}
