using System;
using System.Collections.Generic;
using AngularWebApplication.Models;

namespace AngularWebApplication.Services {
	public interface IPeopleService :IDisposable {
		bool AddPerson(Person person);
		Person DeletePerson(int id);
		List<Person> GetPeople(Func<Person, bool> filter = null, int page = 1);
		Person GetPersonById(int id);
		bool UpdatePerson(Person person);
	}
}