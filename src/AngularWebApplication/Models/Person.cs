using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularWebApplication.Models
{
	[Table("Person", Schema = "Person")]
    public class Person
    {
		[Key]
	    public int BusinessEntityID { get; set; }
		
	    public String FirstName { get; set; }

	    public String MiddleName { get; set; }

	    public String LastName { get; set; }

		public String PersonType { get; set; } = "IN";
	}
}
