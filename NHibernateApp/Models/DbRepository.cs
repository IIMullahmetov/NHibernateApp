using NHibernate;
using NLog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace NHibernateApp.Models
{
	public class DbRepository
	{
		private Logger logger;
		public ObservableCollection<Student> Students { get; private set; }
		public ObservableCollection<string> Groups { get; private set; }

		public DbRepository()
		{
			logger = LogManager.GetCurrentClassLogger();
			Students = new ObservableCollection<Student>();
			Groups = new ObservableCollection<string>();
		}
		public void ReadFromFile(string path)
		{
			XmlRepository repository = null;
			ISession session = null;
			try
			{
				session = NHibernateSession.OpenSession();
				logger.Info(session);
				repository = new XmlRepository();
				foreach (Student student in repository.GetStudents(path))
				{
					if (session.QueryOver<Student>().Where(s => s.Email == student.Email) == null)
					{
						session.Save(student);
					}
				}
				logger.Trace(session);
				session.Dispose();
			}
			catch (NullReferenceException e)
			{
				logger.Error(e.Message + e.Source + e.TargetSite);
			}
			catch (Exception e)
			{
				logger.Error(e.Message + e.Source + e.TargetSite);
			}
			repository.Dispose();
		}

		public void FindGroups()
		{
			ISession session = null;
			try
			{
				session = NHibernateSession.OpenSession();
				logger.Info(session);
				Groups.Clear();
				ICriteria criteria = session.CreateCriteria<Student>();
				IEnumerable<string> list = (from student in criteria.List<Student>()
											select student.GroupNumber).Distinct();
				foreach(string s in list)
				{
					Groups.Add(s);
				}
				logger.Trace(session);
				session.Dispose();
			}
			catch (NullReferenceException e)
			{
				logger.Error(e.Message + e.Source + e.TargetSite);
			}
			catch (Exception e)
			{
				logger.Error(e.Message + e.Source + e.TargetSite);
			}
			GC.Collect();
		}

		public void FindStudentsWith(string group)
		{
			Students.Clear();
			ISession session = null;
			try
			{
				session = NHibernateSession.OpenSession();
				logger.Info(session);
				ICriteria criteria = session.CreateCriteria<Student>();
				IEnumerable<Student> list = criteria.List<Student>().Where(s => s.GroupNumber == group);
				foreach (Student s in list)
				{
					Students.Add(s);
				}
				logger.Trace(session);
				session.Dispose();
			}
			catch (NullReferenceException e)
			{
				logger.Error(e.Message + e.Source + e.TargetSite);
			}
			catch (Exception e)
			{
				logger.Error(e.Message + e.Source + e.TargetSite);
			}
			GC.Collect();
		}
	}
}
