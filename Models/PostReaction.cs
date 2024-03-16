namespace RareBE.Models
{
    public class PostReaction
    {
        public int Id { get; set; }
        public int RareUserId { get; set; }
        public RareUser RareUser { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        public int ReactionId { get; set; }
        public Reaction Reaction { get; set; }
    }
}
