﻿using RareBE.Models;

public class Post
{
    public int Id { get; set; }
    public int? RareUserId { get; set; }
    public string Title { get; set; }
    public DateTime PublicationDate { get; set; }
    public ICollection<Comment>? Comments { get; set; }
    public string ImageUrl { get; set; }
    public string Content { get; set; }
    public bool Approved { get; set; }
    public List<PostReaction>? PostReactions { get; set; }
}