namespace PortfoiloAPI.Models
{
    public class Image
    {
        public Guid ImageID { get; set; }
        public string ImgPath { get; set; }
        public Guid ProjectID { get; set; }
    }
}
