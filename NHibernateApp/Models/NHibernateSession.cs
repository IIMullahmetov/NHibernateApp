using NHibernate;
using NHibernate.Cfg;

namespace NHibernateApp.Models
{
    public class NHibernateSession
    {
		public static ISession OpenSession() => new Configuration().Configure().BuildSessionFactory().OpenSession();
	}
}
