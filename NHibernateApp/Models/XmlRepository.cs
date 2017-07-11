using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Xml.Linq;

namespace NHibernateApp.Models
{
	public class XmlRepository : IDisposable
	{
		public void Dispose() => GC.Collect();

		private Logger logger = LogManager.GetCurrentClassLogger();
		public List<Student> GetStudents(string path)
		{
			List<Student> list = null;
			try
			{
				XDocument document = XDocument.Parse(File.ReadAllText(path));
				list = document.Descendants("Student").Select(s => new Student()
				{
					Email = s.Element("Email").Value,
					FirstName = s.Element("FirstName").Value,
					MiddleName = s.Element("MiddleName").Value,
					LastName = s.Element("LastName").Value,
					GroupNumber = s.Element("GroupNumber").Value,
				}).ToList();
			}
			catch(FileNotFoundException e)
			{
				MessageBox.Show("File not found");
				logger.Error(e.Message + e.FileName);
			}
			catch(Exception e)
			{
				MessageBox.Show("Not available format");
				logger.Error(e.Message);
			}
			return list;
		}
	}
}
