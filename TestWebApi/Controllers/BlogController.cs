using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestWebApi.Data;
using TestWebApi.Models;

namespace TestWebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly TestEntities _entitiesDbContext;

        public BlogController(TestEntities entitiesDbContext)
        {
            _entitiesDbContext = entitiesDbContext;
        }

        // GET api/blogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Blog>>> GetBlogs()
        {
            return await _entitiesDbContext.Blogs.ToListAsync();
        }

        // GET api/blogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Blog>> GetBlog(int id)
        {
            return await _entitiesDbContext.Blogs.FirstOrDefaultAsync(blog => blog.Id == id);
        }

        // POST api/blogs
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/blogs/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/blogs/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
