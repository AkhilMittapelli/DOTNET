using System;
namespace Employe.Models
{
	public class AddEmployeViewModel
	{
        public string Name { get; set; }
        public string Email { get; set; }
        public long Salary { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Department { get; set; }
        public Boolean subscribed { get; set; }

    }
}

