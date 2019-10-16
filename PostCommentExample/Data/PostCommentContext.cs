using Microsoft.EntityFrameworkCore;
using PostCommentExample.Models;

namespace PostCommentExample.Data
{
    public class PostCommentContext: DbContext
    {
        public PostCommentContext(DbContextOptions<PostCommentContext> options) : base(options) { }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
