namespace RareBE.Models
{
    public class PostReaction
    {
        public int Id { get; set; }
        public int RareUserId { get; set; }
        public int PostId { get; set; }
        public int ReactionId { get; set; }

    }
}
