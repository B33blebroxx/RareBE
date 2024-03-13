using RareBE.Models;
using System.ComponentModel.DataAnnotations;
namespace RareBE.DTOs
{
    public class PostTagsDto
    {
        public int TagId { get; set; }
        public int PostId { get; set; }
    }
}
