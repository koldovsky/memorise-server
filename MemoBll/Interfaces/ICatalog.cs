using MemoDAL.Entities;
using System.Collections.Generic;

namespace MemoBll.Interfaces
{
	public interface ICatalog
	{
		IEnumerable<Category> GetAllCategories();
		IEnumerable<Course> GetAllCourses();
		IEnumerable<Deck> GetAllDecks();
		IEnumerable<Deck> GetAllDecksByCourse(string courseLinking);
		IEnumerable<Deck> GetAllDecksByCategory(string categoryLinking);
		IEnumerable<Course> GetAllCoursesByCategory(string categoryLinking);
		Course GetCourse(string courseName);
	}
}
