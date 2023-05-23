using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lumia.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Image { get; set; }
        public int ProfessionId { get; set; }
        public Profession? profession { get; set; }
    }
}
