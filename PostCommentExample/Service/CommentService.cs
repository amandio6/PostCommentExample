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
    public class CommentService: ICommentService
    {

        private readonly PostCommentContext _context;

        public CommentService(PostCommentContext context)
        {
            _context = context;
            _context.Database?.EnsureCreated();
        }

        public async Task<ActionResult<IEnumerable<Comment>>> GetComments()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<ActionResult<Comment>> GetComment(int id)
        {
            return await _context.Comments.FindAsync(id);
            
        }

        public async Task<Comment> PutComment(int id, Comment comment)
        {
            
            _context.Entry(comment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return comment;
        }


        public async Task<ActionResult<Comment>> PostComment(Comment comment)
        {
            comment.dtComment = DateTime.Now;
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return comment;
        }

        public async Task<ActionResult<Comment>> DeleteComment(Comment comment)
        {
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return comment;
        }

        private bool CommentExists(int id)
        {
            return _context.Comments.Any(e => e.CommentId == id);
        }
    }


    public interface ICommentService
    {
        Task<ActionResult<IEnumerable<Comment>>> GetComments();
        
        Task<ActionResult<Comment>> GetComment(int id);

        Task<Comment> PutComment(int id, Comment comment);

        Task<ActionResult<Comment>> PostComment(Comment comment);

        Task<ActionResult<Comment>> DeleteComment(Comment comment);
    }
}
