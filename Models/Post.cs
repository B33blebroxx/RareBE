using RareBE.Models;

public class Post
{
    public int Id { get; set; }
    public int? Uid { get; set; }
    public string Title { get; set; }
    public DateTime PublicationDate { get; set; }
    public string ImageUrl { get; set; }
    public string Content { get; set; }
    public bool Approved { get; set; }
    public ICollection<Reaction> Reactions { get; set; }
}