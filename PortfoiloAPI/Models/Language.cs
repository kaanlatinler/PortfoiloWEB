using System.ComponentModel.DataAnnotations;

namespace PortfoiloAPI.Models
{
    public class Language
    {
        [Key]
        public Guid LangID { get; set; }
        public string LangName { get; set; }
    }
}
