namespace PortfoiloAPI.DTO.Admin
{
    public class ProjectDTO
    {
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
