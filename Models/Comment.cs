using System;
using System.ComponentModel.DataAnnotations;

namespace RareBE.Models;

public class Comment
{
    public int Id { get; set; }
    [Required]
    public int AuthorId { get; set; }
    public int PostId { get; set; }
    
    public string Content { get; set; }
    public DateTime CreatedOn { get; set; }
}