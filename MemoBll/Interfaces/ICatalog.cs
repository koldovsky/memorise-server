using MemoDAL.Entities;
using System.Collections.Generic;

namespace MemoBll.Interfaces
{
	public interface ICatalog
	{
		IEnumerable<Category> GetAllCategories();
		IEnumerable<Course> GetAllCourses();
		IEnumerable<Deck> GetAllDecks();
		IEnumerable<Deck> GetAllDecksByCourse(string courseName);
		IEnumerable<Deck> GetAllDecksByCategory(string categoryName);
		IEnumerable<Course> GetAllCoursesByCategory(string categoryName);
		Course GetCourse(string courseName);
	}
}
