namespace PortfoiloAPI.Models
{
    public class Project
    {
        public Guid ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDesc { get; set; }
        public string ProjectUrl { get; set; }
        public string ProjectClient { get; set; }
        public DateTime ProjectDate { get; set; }
        public Guid ProjectCatID { get; set; }
        public Guid ProjectLangID { get; set; }
        public Guid? ProjectImgID { get; set; }
    }
}
