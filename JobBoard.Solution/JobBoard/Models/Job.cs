using System.Collections.Generic;
using System.Linq;

namespace JobBoard.Models
{
	public class Job
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public List<string> Expectations { get; set; }
		public int Wage { get; set; }
		public string ContactInfo { get; set; }
		public int Id { get; }
		private static List<Job> _instances = new List<Job>();

		public Job(string title, string description, string expectations, int wage, string contactInfo)
		{
			Title = title;
			Description = description;
			Expectations = GetExpectations(expectations);
			Wage = wage;
			ContactInfo = contactInfo;
			_instances.Add(this);
			Id = _instances.Count;
		}

		private List<string> GetExpectations(string expectations)
		{
			return expectations.Split(',').ToList();
		}

		public static List<Job> GetAll()
		{
			return _instances;
		}

		public static void ClearAll()
		{
			_instances.Clear();
		}

		public static Job Find(int searchId)
		{
			return _instances[searchId - 1];
		}
	}
}