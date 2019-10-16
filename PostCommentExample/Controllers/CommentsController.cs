using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PostCommentExample.Models;
using PostCommentExample.Service;

namespace PostCommentExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        // GET: api/Comments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComments()
        {
            return await _commentService.GetComments();
        }

        // GET: api/Comments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetComment(int id)
        {
            var comment = await _commentService.GetComment(id);

            if (comment == null)
            {
                return NotFound();
            }

            return comment;
        }

        // PUT: api/Comments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment(int id, Comment comment)
        {
            if (id != comment.CommentId)
            {
                return BadRequest();
            }

            var commentRet = await _commentService.PutComment(id, comment);

            if (commentRet == null)
                return NotFound();
            
            
            return NoContent();
        }

        // POST: api/Comments
        [HttpPost]
        public async Task<ActionResult<Comment>> PostComment(Comment comment)
        {
            var ret = await _commentService.PostComment(comment);
            
            return CreatedAtAction("GetComment", new { id = ret.Value.CommentId}, ret.Value);
        }

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Comment>> DeleteComment(int id)
        {
            var comment = await _commentService.GetComment(id);
            if (comment == null)
            {
                return NotFound();
            }

            await _commentService.DeleteComment(comment.Value);

            return comment;
        }

        
    }
}
