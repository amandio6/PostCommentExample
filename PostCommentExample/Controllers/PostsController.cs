
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PostCommentExample.Models;
using PostCommentExample.Service;

namespace PostCommentExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController()]
    public class PostsController : Controller
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService) {
            _postService = postService;
        }

        // GET: api/Posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            return await _postService.AllPosts();
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var post = await _postService.GetPost(id);

            if (post == null)
            {
                return NotFound();
            }

            return post;
        }

        // PUT: api/Posts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(int id, Post post)
        {
            if (id != post.Id)
            {
                return BadRequest();
            }

            var put = await _postService.PutPost(id, post);

            if (put == null)
                return NotFound();

            return NoContent();
        }

        // POST: api/Posts
        [HttpPost]
        public async Task<ActionResult<Post>> PostPost(Post post)
        {
            
            var retPost = await _postService.PostPost(post);

            return CreatedAtAction("GetPost", new { id = retPost.Value.Id }, retPost.Value);
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Post>> DeletePost(int id)
        {
            var post = await _postService.GetPost(id);
            if (post == null)
            {
                return NotFound();
            }
            await _postService.DeletePost(post.Value);
            return post;
        }

    

    }
}