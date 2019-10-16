using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostCommentExample.Data;
using PostCommentExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostCommentExample.Service
{

    public class PostService : IPostService
    {
        private readonly PostCommentContext _context;
        public PostService(PostCommentContext dbContext)
        {
            _context = dbContext;
            _context.Database?.EnsureCreated();
        }

        public async Task<ActionResult<IEnumerable<Post>>> AllPosts()
        {
            return await _context.Posts.Include(c => c.Comments).ToListAsync();
        }

        public async Task<ActionResult<Post>> GetPost(int id)
        {
            return await _context.Posts.FindAsync(id);
        }

        public async Task<ActionResult<Post>> PostPost(Post post)
        {
            post.dtRegist = DateTime.Now;
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return post;
        }

        public async Task<ActionResult<Post>> PutPost(int id, Post post)
        {
            _context.Entry(post).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return post;
            
        }

        public async Task<ActionResult<Post>> DeletePost(Post post)
        {
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return post;
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
    }

    public interface IPostService
    {
        Task<ActionResult<IEnumerable<Post>>> AllPosts();
        
        Task<ActionResult<Post>> GetPost(int id);

        Task<ActionResult<Post>> PutPost(int id, Post post);

        Task<ActionResult<Post>> PostPost(Post post);

        Task<ActionResult<Post>> DeletePost(Post post);
    }
}
