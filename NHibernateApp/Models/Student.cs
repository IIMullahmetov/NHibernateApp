
namespace NHibernateApp.Models
{
	public class Student
	{
		public virtual int Id { get; set; }
		public virtual string FirstName { get; set; }
		public virtual string MiddleName { get; set; }
		public virtual string LastName { get; set; }
		public virtual string GroupNumber { get; set; }
		public virtual string Email { get; set; }
	}
}
