using NHibernateApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;

namespace NHibernateApp.Models.Tests
{
	[TestClass()]
	public class XmlRepositoryTest
	{
		[TestMethod()]
		public void GetStudentsTest()
		{
			int count = 17;
			int expected = new XmlRepository().GetStudents(@"C:\Users\IMullahmetov\OneDrive\Документы\Visual Studio 2017\Projects\NHibernateApp\NHibernateApp\Students.xml").Count;

			Assert.AreEqual(expected, count);
		}

		[TestMethod()]
		public void OpenSessionTest()
		{
			ISession s = NHibernateSession.OpenSession();
			Assert.IsFalse(s.IsConnected);
		}

		[TestMethod()]
		public void GetStudentsTest2()
		{
			int count = 17;
			int expected = new XmlRepository().GetStudents(@"C:\Users\IMullahmetov\OneDrive\Документы\Visual Studio 2017\Projects\NHibernateApp\NHibernateApp\Students.xml").Count;

			Assert.AreNotEqual(expected, count);
		}
	}
}