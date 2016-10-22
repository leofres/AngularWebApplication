using System;
using System.Collections.Generic;
using System.Linq;
using AngularWebApplication.DbContext;
using AngularWebApplication.Models;
using Microsoft.Data.Entity;

namespace AngularWebApplication.Services
{
    public class PeopleService : IPeopleService {
	    private readonly AdventureContext _adventureContext;

	    public PeopleService(AdventureContext adventureContext) {
		    _adventureContext = adventureContext;
	    }

	    public List<Person> GetPeople(Func<Person, bool> filter = null, int page = 1) {
			var peopleQuery = _adventureContext.People.AsEnumerable();

			if (filter != null) {
			    peopleQuery = peopleQuery.Where(filter);
		    }

		    return peopleQuery.Skip((page - 1) * 10).Take(10).ToList();
	    }

	    public Person GetPersonById(int id) {
		    return _adventureContext.People.FirstOrDefault(p => p.BusinessEntityID == id);
	    }

	    public bool AddPerson(Person person) {

		    if (!PersonExists(person.BusinessEntityID)) {
				_adventureContext.People.Add(person);

				_adventureContext.SaveChanges();

			    return true;
		    }
			
		    return false;
	    }

	    public bool UpdatePerson(Person person) {
		    if (PersonExists(person.BusinessEntityID)) {
			    _adventureContext.Entry(person).State = EntityState.Modified;
			    _adventureContext.SaveChanges();

			    return true;
		    }

		    return false;
	    }

	    public Person DeletePerson(int id) {
		    Person person = _adventureContext.People.Single(p => p.BusinessEntityID == id);

		    if (person == null) {
			    return null;
		    }

		    _adventureContext.People.Remove(person);
		    _adventureContext.SaveChanges();

		    return person;
	    }

		private bool PersonExists(int id) {
			return _adventureContext.People.Count(e => e.BusinessEntityID == id) > 0;
		}

	    public void Dispose() {
		    _adventureContext.Dispose();
	    }
    }
}
