using System;
using System.Collections.Generic;
using AngularWebApplication.Services;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;

namespace AngularWebApplication.Controllers.Person
{
    [Produces("application/json")]
    [Route("api/People")]
    public class PeopleController : Controller
    {
	    private readonly IPeopleService _peopleService;

        public PeopleController(IPeopleService peopleService) {
	        _peopleService = peopleService;
        }

	    // GET: api/People
        [HttpGet]
        public IEnumerable<Models.Person> GetPeople(
			[FromQuery(Name = "page")] int page = 1,
			[FromQuery(Name = "search")] string search = null
			) {
	        Func<Models.Person, Boolean> filter = null;

			if(search != null)
				filter = x => x.FirstName.Contains(search);

            return _peopleService.GetPeople(page: page, filter: filter);
        }

        // GET: api/People/5
        [HttpGet("{id}", Name = "GetPerson")]
        public IActionResult GetPerson([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Models.Person person = _peopleService.GetPersonById(id);

            if (person == null)
            {
                return HttpNotFound();
            }

            return Ok(person);
        }

        // PUT: api/People/5
        [HttpPut("{id}")]
        public IActionResult PutPerson(int id, [FromBody] Models.Person person)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != person.BusinessEntityID)
            {
                return HttpBadRequest();
            }

	        if (!_peopleService.UpdatePerson(person)) {
		        return HttpNotFound();
	        }

	        return new HttpStatusCodeResult(StatusCodes.Status204NoContent);
        }

        // POST: api/People
        [HttpPost]
        public IActionResult PostPerson([FromBody] Models.Person person)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

	        if (!_peopleService.AddPerson(person)) {
		        return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
	        }

	        return CreatedAtRoute("GetPerson", new { id = person.BusinessEntityID }, person);
        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public IActionResult DeletePerson(int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

	        Models.Person person = _peopleService.DeletePerson(id);

			if (person == null)
            {
                return HttpNotFound();
            }

            return Ok(person);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _peopleService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}