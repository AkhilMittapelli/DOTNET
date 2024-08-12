using System;
namespace Employe.Models.Entity
{
	public class Worker
	{
		public Guid Id { get; set; }
		 public string Name { get; set; }
        public string Email { get; set; }
        public long Salary { get; set; }
		public DateTime DateOfBirth { get; set; }
        public string Department { get; set; }
		public Boolean subscribed { get; set; }

    }
}

