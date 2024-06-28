using System;
using System.Collections.Generic;

namespace PortfoiloWEB.Areas.Admin.DTO;

public partial class ImageDTO
{
    public Guid ImageId { get; set; }

    public string ImgPath { get; set; } = null!;

    public Guid ProjectId { get; set; }
}
