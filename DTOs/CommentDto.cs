using RareBE.Models;
using System.ComponentModel.DataAnnotations;
namespace RareBE.DTOs
{
    public class CommentDto
    {
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}
