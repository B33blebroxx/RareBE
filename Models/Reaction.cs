using System.ComponentModel.DataAnnotations.Schema;

namespace RareBE.Models
{
    public class Reaction
    {
        public int Id { get; set; }
        public ICollection<Post>? Posts { get; set; }
        public string Label { get; set; }
        public string Image { get; set; }
    }
}
