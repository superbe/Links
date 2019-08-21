using Links.WWW.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Links.WWW.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LinksController : ControllerBase
	{
		private readonly LinksContext _context;

		public LinksController()
		{
			_context = new LinksContext();
		}

		// GET: api/Links
		[HttpGet]
		public IEnumerable<Link> GetLink()
		{
			return _context.Link;
		}

		// GET: api/Links/5
		[HttpGet("{id}")]
		public ActionResult GetLink([FromRoute] int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var link = _context.Link.Find(id);

			if (link == null)
			{
				return NotFound();
			}

			return Ok(link);
		}

		// PUT: api/Links/5
		[HttpPut("{id}")]
		public ActionResult PutLink([FromRoute] int id, [FromBody] Link link)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (id != link.Id)
			{
				return BadRequest();
			}

			_context.Entry(link);

			try
			{
				_context.SaveChanges();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!LinkExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/Links
		[HttpPost]
		public ActionResult PostLink([FromBody] Link link)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			_context.Add(link);
			_context.SaveChanges();

			return CreatedAtAction("GetLink", new { id = link.Id }, link);
		}

		// DELETE: api/Links/5
		[HttpDelete("{id}")]
		public ActionResult DeleteLink([FromRoute] int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			Link link = _context.Link.Find(id);
			if (link == null)
			{
				return NotFound();
			}

			_context.Remove(link);
			_context.SaveChanges();

			return Ok(link);
		}

		private bool LinkExists(int id)
		{
			return _context.Link.Find(id) != null;
		}
	}
}